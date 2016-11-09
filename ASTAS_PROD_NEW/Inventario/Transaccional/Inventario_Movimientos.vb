'' =============================================
'' Author:		Esteban Gámez
'' Create date: 05-Feb-2011// Esteban Gamez ni siquiera trabajaba en ASTAS para esa fecha. Inicio sus labores en Outs 
'' en marzo del 2012.
'' Description:	Movimiento de inventarios
'' =============================================

Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Inventario_Movimientos
    Dim ProcesosContables As New Contabilidad_Procesos
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim c_data2 As New Facturacion_Procesos
    Dim Iniciando As Boolean, Iniciando2 As Boolean = False
    Dim ENTRADA_SALIDA As String = "False"
    Dim Requiere_costo, Requiere_Documento As Boolean
    Dim Tipo_Moviniento, Movimiento, Detalle, CtroCosto As Integer
    Dim MensajeString As String, PERCEPCION As String
    Dim dtareader As SqlDataReader
    Dim RC As String, bodega_inv As String
    Dim ret_per As New Recepcion_Percepcion
    Dim COSTO_PROM As String = 0
    Dim cantidad As String = 0
    Dim Costo_Total As Double = 0
    Dim Costo_Total_doc As Double = 0
    Dim TotalFact As Double = 0
    Dim PorcIVA As Double
    Dim PorcPercep As Double
    Dim item As String = 0
    Dim pos_ante As String
    Dim clave As String
    Dim tdetalle_ As New DataTable("Detalle")
    Dim salida_ajustes_ As String
    Dim movimiento_actual_ As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Iniciando2 = False
    End Sub
    Public Sub New(ByVal var)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bodega_inv = var
        cmbBODEGA.Enabled = False
        cmbTIPO_MOVIMIENTO.Enabled = False
        Btn_Buscar_Proveedor.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
        Btn_Buscar_Movimiento.Enabled = False
        Txt_tipo_movimiento_numero.Enabled = False
        Cmb_tipo_documento.Enabled = False
        Txt_tipo_documento_numero.Enabled = False

        Iniciando2 = True
    End Sub


    Private Sub Inventario_Movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        tdetalle_.Columns.Add("Compañia", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("No", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Producto", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Nombre Producto", Type.GetType("System.String"))
        tdetalle_.Columns.Add("Cantidad", Type.GetType("System.Double"))
        tdetalle_.Columns.Add("Costo Unitario", Type.GetType("System.Double"))
        tdetalle_.Columns.Add("Costo Total", Type.GetType("System.Double"))
        tdetalle_.Columns.Add("PROVEEDOR", Type.GetType("System.String"))
        tdetalle_.Columns.Add("Proveedor Nombre Legal", Type.GetType("System.String"))
        tdetalle_.Columns.Add("Proveedor Nombre Comercial", Type.GetType("System.String"))
        tdetalle_.Columns.Add("BODEGA", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Descripción Bodega", Type.GetType("System.String"))
        tdetalle_.Columns.Add("TIPO_MOVIMIENTO", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Tipo Movimiento", Type.GetType("System.String"))
        tdetalle_.Columns.Add("TIPO_DOCUMENTO_CONTABLE", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Tipo Documento Contable", Type.GetType("System.String"))
        tdetalle_.Columns.Add("Numero Documento", Type.GetType("System.Int32"))
        tdetalle_.Columns.Add("Fecha en Documento", Type.GetType("System.String"))
        tdetalle_.Columns.Add("FECHA_MOVIMIENTO", Type.GetType("System.String"))
        tdetalle_.Columns.Add("Usuario Creacion", Type.GetType("System.String"))
        tdetalle_.Columns.Add("PROCESADO", Type.GetType("System.Boolean"))

        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)

        Txt_tipo_movimiento_numero.Text = "0"
        Me.txtCompañia.Text = Descripcion_Compañia

        'LLENA EL COMBO DE BODEGAS
        If (Iniciando2 = True) Then

            'CARGAR EL TIPO DE MOVIMIENTO EN EL COMBO RESPECTIVO
            c_data.CargaTipoDocumentoInventario(Compañia, Me.cmbTIPO_MOVIMIENTO, 3)

            c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 8, bodega_inv)
        Else
            'CARGAR EL TIPO DE MOVIMIENTO EN EL COMBO RESPECTIVO
            c_data.CargaTipoDocumentoInventario(Compañia, Me.cmbTIPO_MOVIMIENTO, 2)

            c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        End If

        c_data2.Tipo_Documento_Contable(Compañia, 1, Me.Cmb_tipo_documento)
        'CargarGrid(Compañia, "ST")
        Try
            TxtProveedor_Item.Text = "0"
        Catch ex As Exception
        End Try

        Movimiento_numero(Compañia)
        'CARGA EL COMBO DE LOS TIPOS DE MOVIMIENTO
        RC = c_data2.CargaTipoDocumentoInventario_rc(Compañia, Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0, Me.Txt_Tipo_Movimiento_requiere, Me.Txt_Tipo_Documento_requiere)

        CargaTipoContribuyente(Compañia, 1)
        CargaFormaPago(Compañia, 1)
        CargaCondicionPago(Compañia, Me.CmbProveedor_FormaPago.SelectedValue, 1)

        PorcIVA = c_data2.DevuelveConstante(Compañia, 1)
        PorcPercep = c_data2.DevuelveConstante(Compañia, 2)
        Iniciando = False
    End Sub

    Public Sub NuevoMovimiento()
        Txt_tipo_movimiento_numero.Text = c_data2.leerDataeader("SELECT ISNULL(MAX(MOVIMIENTO),0)+1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue & " AND TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0)
    End Sub

    Private Sub CmbCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Iniciando = False Then

            c_data.CargaBodega(Compañia, Me.cmbBODEGA)
            c_data.CargaTipoDocumentoInventario(Compañia, Me.cmbTIPO_MOVIMIENTO, 2)
            c_data2.Tipo_Documento_Contable(Compañia, 1, Me.Cmb_tipo_documento)
            c_data2.CargaTipoDocumentoInventario_rc(Compañia, Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0, Me.Txt_Tipo_Movimiento_requiere, Me.Txt_Tipo_Documento_requiere)
            c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 7)

        End If

    End Sub

#Region "Connection"

    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Resultado As DialogResult

#End Region

    Private Sub HabilitaCamposTransaccionE(ByVal Bandera)
        Me.cmbTIPO_MOVIMIENTO.Enabled = Bandera
    End Sub

    Public Sub ActualizarCostos(ByVal producto, ByVal cantidad, ByVal costo_unitario, ByVal costo_total)

        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        SQL &= ",@PROVEEDOR = " & Me.TxtProveedor_Item.Text
        SQL &= ",@TIPO_MOVIMIENTO = " & Me.cmbTIPO_MOVIMIENTO.SelectedValue
        SQL &= ",@MOV = " & Me.Txt_tipo_movimiento_numero.Text
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = " & Me.Cmb_tipo_documento.SelectedValue
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = " & IIf(Me.Txt_tipo_documento_numero.Text = "", 0, Me.Txt_tipo_documento_numero.Text)
        SQL &= ",@FECHA_MOVIMIENTO = N'" & Me.dpFECHA_CONTABLE.Text & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & producto
        SQL &= ",@CANTIDAD = " & cantidad
        SQL &= ",@COSTO_UNIDAD = " & costo_unitario
        SQL &= ",@COSTO_TOTAL = " & costo_total
        SQL &= ",@ENTRADA_SALIDA =" & ENTRADA_SALIDA
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'U'"
        c_data2.Ejecutar_ConsultaSQL(SQL)
    End Sub

    Public Sub Actualizar_Estado()
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        SQL &= ",@TIPO_MOVIMIENTO = " & Me.cmbTIPO_MOVIMIENTO.SelectedValue
        SQL &= ",@MOV = " & IIf(Me.Txt_tipo_movimiento_numero.Text = "", 0, Me.Txt_tipo_movimiento_numero.Text)
        SQL &= ",@SIUD = N'U1'"
        c_data2.Ejecutar_ConsultaSQL(SQL)
    End Sub

    Public Function cadenaSIUD(ByVal CIA, ByVal SIUD)
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        If ChkHabilitar.Checked = True Then
            SQL &= ",@BODEGA = " & Me.cmbMultiBodega.SelectedValue
        Else
            SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        End If
        SQL &= ",@PROVEEDOR = " & IIf(Me.TxtProveedor_Item.Text = "", 0, Me.TxtProveedor_Item.Text)
        SQL &= ",@TIPO_MOVIMIENTO = " & Me.cmbTIPO_MOVIMIENTO.SelectedValue
        SQL &= ",@MOV = " & IIf(Me.Txt_tipo_movimiento_numero.Text = "", 0, Me.Txt_tipo_movimiento_numero.Text)
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = " & Me.Cmb_tipo_documento.SelectedValue
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = " & Val(Me.Txt_tipo_documento_numero.Text)
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & Val(Me.Txt_Producto_codigo.Text)
        SQL &= ",@CANTIDAD = " & Val(Me.Txt_Producto_cantidad.Text)
        Dim costo_uni As String
        Dim tipo_costo As String = c_data2.leerDataeader("EXEC [dbo].[sp_INVENTARIOS_INGRESAR_COMPRAS] @COMPAÑIA=" & Compañia & ",@PRODUCTO=" & Val(Txt_Producto_codigo.Text) & ",@BANDERA='V'", 0)

        If (Val(Me.Txt_Producto_costo_unitario.Text) = 0) Then
            'Valida si es multibodegas o una sola
            If ChkHabilitar.Checked = True Then
                If Val(tipo_costo) = 1 Then
                    'COSTO PROMEDIO
                    costo_uni = c_data2.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbMultiBodega.SelectedValue & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Else
                    'UEPS
                    costo_uni = c_data2.IngresarCostoUeps(Compañia, Me.cmbMultiBodega.SelectedValue, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
                End If
            Else
                If Val(tipo_costo) = 1 Then
                    'COSTO PROMEDIO
                    costo_uni = c_data2.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Else
                    'UEPS
                    costo_uni = c_data2.IngresarCostoUeps(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
                End If
            End If

            SQL &= ",@COSTO_UNIDAD = " & Val(costo_uni)
            SQL &= ",@COSTO_TOTAL = " & (Val(Me.Txt_Producto_cantidad.Text) * Val(costo_uni)).ToString()
        Else
            costo_uni = Txt_Producto_costo_unitario.Text
            SQL &= ",@COSTO_UNIDAD = " & Val(Me.Txt_Producto_costo_unitario.Text)
            SQL &= ",@COSTO_TOTAL = " & Val(Me.Txt_Producto_costo_unitario.Text) * Val(Me.Txt_Producto_cantidad.Text)
        End If

        SQL &= ",@ENTRADA_SALIDA =" & ENTRADA_SALIDA
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'" & SIUD & "'"

        If (costo_uni = Nothing) Or (costo_uni = 0) Then
            costo_uni = -1
        End If
        Return costo_uni
    End Function

    Public Function addDetailsTmp(ByVal CIA, ByVal SIUD)
        Dim tbl_dat_ As DataTable
        Dim descrip_producto_ As String
        Dim descrip_bodega_ As String
        Dim sqlCmd As New SqlCommand
        sqlCmd.CommandText = "SELECT PRODUCTO,DESCRIPCION_PRODUCTO FROM  INVENTARIOS_CATALOGO_PRODUCTOS  WHERE COMPAÑIA= " & Compañia & " AND PRODUCTO = " & Me.Txt_Producto_codigo.Text
        tbl_dat_ = c_data1.obtenerDatos(sqlCmd)
        descrip_producto_ = tbl_dat_.Rows(0).Item("DESCRIPCION_PRODUCTO").ToString()
        
        Dim costo_uni As String
        Dim tipo_costo As String = c_data2.leerDataeader("EXEC [dbo].[sp_INVENTARIOS_INGRESAR_COMPRAS] @COMPAÑIA=" & Compañia & ",@PRODUCTO=" & Val(Txt_Producto_codigo.Text) & ",@BANDERA='V'", 0)

        If (Val(Me.Txt_Producto_costo_unitario.Text) = 0) Then
            'Valida si es multibodegas o una sola
            If ChkHabilitar.Checked = True Then
                If Val(tipo_costo) = 1 Then
                    'COSTO PROMEDIO
                    costo_uni = c_data2.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbMultiBodega.SelectedValue & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Else
                    'UEPS
                    costo_uni = c_data2.IngresarCostoUeps(Compañia, Me.cmbMultiBodega.SelectedValue, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
                End If
            Else
                If Val(tipo_costo) = 1 Then
                    'COSTO PROMEDIO
                    costo_uni = c_data2.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Else
                    'UEPS
                    costo_uni = c_data2.IngresarCostoUeps(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
                End If
            End If
        Else
            costo_uni = Txt_Producto_costo_unitario.Text
        End If
        'Julio Portillo Agregando el detalle
        Dim R As DataRow = tdetalle_.NewRow
        R("Compañia") = CIA
        tbl_dat_.Clear()
        If ChkHabilitar.Checked = True Then
            R("BODEGA") = Me.cmbMultiBodega.SelectedValue
            sqlCmd.CommandText = "SELECT DESCRIPCION_BODEGA FROM  INVENTARIOS_CATALOGO_BODEGAS  WHERE COMPAÑIA= " & Compañia & " AND BODEGA = " & Me.cmbMultiBodega.SelectedValue
        Else
            R("BODEGA") = Me.cmbBODEGA.SelectedValue
            sqlCmd.CommandText = "SELECT DESCRIPCION_BODEGA FROM  INVENTARIOS_CATALOGO_BODEGAS  WHERE COMPAÑIA= " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
        End If
        tbl_dat_ = c_data1.obtenerDatos(sqlCmd)
        descrip_bodega_ = tbl_dat_.Rows(0).Item("DESCRIPCION_BODEGA").ToString()

        R("TIPO_MOVIMIENTO") = salida_ajustes_
        R("Tipo Movimiento") = movimiento_actual_
        R("TIPO_DOCUMENTO_CONTABLE") = CInt(cmbTIPO_MOVIMIENTO.SelectedValue.ToString())
        R("Tipo Documento Contable") = movimiento_actual_
        R("Numero Documento") = CInt(IIf(Txt_tipo_documento_numero.Text.Length = 0, 0, Txt_tipo_documento_numero.Text))
        R("FECHA_MOVIMIENTO") = Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        R("PRODUCTO") = Val(Me.Txt_Producto_codigo.Text)
        R("PROCESADO") = 0
        R("CANTIDAD") = CDbl(Txt_Producto_cantidad.Text)
        R("Costo Unitario") = CDbl(costo_uni) 'FormatNumber(CDbl(costo_uni), 2)
        R("Costo Total") = CDbl(Txt_Producto_cantidad.Text) * CDbl(costo_uni) 'FormatNumber(CDbl(Val(Txt_Producto_cantidad.Text) * costo_uni), 2)
        R("Proveedor Nombre Legal") = "SIN PROVEEDOR"        
        R("PROVEEDOR") = 0
        R("Proveedor Nombre Comercial") = "SIN PROVEEDOR"        
        R("Nombre Producto") = descrip_producto_
        R("No") = Txt_tipo_movimiento_numero.Text
        R("Descripción Bodega") = descrip_bodega_
        R("Fecha en Documento") = Date.Now.ToShortDateString()
        R("FECHA_MOVIMIENTO") = Date.Now.ToShortDateString()
        R("Usuario Creacion") = Usuario
        tdetalle_.Rows.Add(R)

        If (costo_uni = Nothing) Or (costo_uni = 0) Then
            costo_uni = -1
        End If
        Return costo_uni
    End Function

    Sub Movimiento_numero(ByVal CIA)
        Try
            DS03.Reset()
            cadenaSIUD(CIA, "SNM")
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS03)
            If (DS03.Tables.Item(0).Rows.Count) <= 0 Then
                MessageBox.Show("No hay datos que mostrar...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Exit Sub
            End If
            Me.Txt_tipo_movimiento_numero.Text = DS03.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Aviso...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub

    Sub LoadGrid(ByVal CIA, ByVal SIUD)
        Try
            Me.dgvMovtos.DataSource = tdetalle_
            'Ocultar columnas
            Me.dgvMovtos.Columns.Item(0).Visible = False 'Compañia

            Me.dgvMovtos.Columns.Item(7).Visible = False 'Proveedor
            Me.dgvMovtos.Columns.Item(10).Visible = False 'Bodega
            Me.dgvMovtos.Columns.Item(12).Visible = False 'Tipo Movimiento
            Me.dgvMovtos.Columns.Item(14).Visible = False 'Tipo Documento Contable
            'justificar(derecha)
            Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            'Formato a los campos numericos con decimales
            Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Format = "N6"
            Me.dgvMovtos.Columns.Item(5).DefaultCellStyle.Format = "N6"
            Me.dgvMovtos.Columns.Item(6).DefaultCellStyle.Format = "N6"
            For i As Integer = 1 To 16
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Código no Encontrado, Favor Verificar.", MsgBoxStyle.Information)
            MessageBox.Show(ex.Message, "AVISO: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarGrid(ByVal CIA, ByVal SIUD)
        Try
            DS01.Reset()
            cadenaSIUD(Compañia, SIUD)
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)

            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()
            'Ocultar columnas
            Me.dgvMovtos.Columns.Item(0).Visible = False 'Compañia

            Me.dgvMovtos.Columns.Item(7).Visible = False 'Proveedor
            Me.dgvMovtos.Columns.Item(10).Visible = False 'Bodega
            Me.dgvMovtos.Columns.Item(12).Visible = False 'Tipo Movimiento
            Me.dgvMovtos.Columns.Item(14).Visible = False 'Tipo Documento Contable
            'Me.dgvMovtos.Columns.Item(20).Visible = False 'Detalle

            'justificar derecha
            Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            For i As Integer = 1 To 16
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next

        Catch ex As Exception
            MsgBox("Código no Encontrado, Favor Verificar.", MsgBoxStyle.Information)
            MessageBox.Show(ex.Message, "AVISO: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub


#Region "Busqueda Productos"
    Private Sub btnBuscarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Limpiar()
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia

        If ChkHabilitar.Checked = True Then
            Frm_Busqueda.TxtBodega.Text = Me.cmbMultiBodega.Text
            Frm_Busqueda.TxtBodega_cod.Text = Me.cmbMultiBodega.SelectedValue
        Else
            Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
            Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        End If

        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()

        Me.Txt_Producto_codigo.Text = CodigoProducto
        Me.Txt_Producto_descripcion.Text = Descripcion_Producto
        Me.txt_Unidades.Text = unidades
        If ChkHabilitar.Checked = True Then
            Me.Txt_Existencias.Text = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbMultiBodega.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        Else
            Me.Txt_Existencias.Text = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        End If
        Me.Txt_Producto_cantidad.Focus()
    End Sub
#End Region

    Sub Limpiar()
        Detalle = 0
        Me.Txt_Producto_codigo.Clear()
        Me.Txt_Producto_descripcion.Clear()
        Me.Txt_Producto_cantidad.Clear()
        Me.Txt_Producto_costo_unitario.Clear()
        Me.Txt_Producto_costo_total.Clear()
        Me.txt_Unidades.Text = ""
    End Sub

#Region "Validación"
    Private Function FindProductInGrid() As Boolean
        Dim retorno_ As Boolean = False
        For i As Integer = 0 To dgvMovtos.RowCount - 1
            If dgvMovtos.Rows(i).Cells(2).Value = Txt_Producto_codigo.Text Then
                retorno_ = True
            End If
        Next
        Return retorno_
    End Function
    Private Sub btnGuardarLinea_y_BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click, BtnLimpiar.Click
        If Iniciando = False Then
            Dim CANTIDAD As String = 1
            'Determina si es entrada o salida el proceso a realizar
            ENTRADA_SALIDA = c_data2.leerDataeader("Exec sp_INVENTARIOS_DETERMINAR_SI_ES_ENTRADA_SALIDA @TIPO_DOCUMENTO=" & cmbTIPO_MOVIMIENTO.SelectedValue, 5)
            'fin
            If sender Is btnGuardarLinea Then
                'Julio Portillo
                If salida_ajustes_ = "7" Then
                    If FindProductInGrid() Then
                        Exit Sub
                    End If
                End If

                If Val(Detalle) > 0 Then
                    Accion_producto_bandeja("UR")
                Else
                    Dim a As Integer = Validacion()
                    If (a = 2) Then
                        Exit Sub
                    Else
                        If (ENTRADA_SALIDA = False) Then
                            '-----------------------Si es una salida
                            'Verifica si hay suficientes existencias                           
                            If ChkHabilitar.Checked = True Then
                                CANTIDAD = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & cmbMultiBodega.SelectedValue & "," & Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                            Else
                                CANTIDAD = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                            End If
                            '-----------------------Si el el proc devuelve 0 es porque no hay suficientes
                            If (Val(CANTIDAD) < Val(Txt_Producto_cantidad.Text)) Then
                                MsgBox("LAS EXISTENCIAS NO SON SUFICIENTE", MsgBoxStyle.Information)
                                Exit Sub
                            Else
                                If dgvMovtos.RowCount = 0 Then
                                    Dim mov_1 As String
                                    mov_1 = Txt_tipo_movimiento_numero.Text
                                    NuevoMovimiento()
                                    If (mov_1 <> Txt_tipo_movimiento_numero.Text) Then
                                        MsgBox("NUMERO DE MOVIMIENTO : " & mov_1 & " YA EXISTE, SE ACTUALIZO A: " & Txt_tipo_movimiento_numero.Text, MsgBoxStyle.Information)
                                    End If

                                    Ingresar()
                                Else
                                    Ingresar()
                                End If
                            End If
                        Else
                            '-----------------------Si es una entrada
                            If cmbTIPO_MOVIMIENTO.SelectedValue = 3 Then
                                'Entrada por compra
                                If ChkHabilitar.Checked = True Then
                                    c_data2.IngresarCostoUeps(Compañia, Me.cmbMultiBodega.SelectedValue, Val(Me.Txt_Producto_codigo.Text), Val(Txt_Producto_cantidad.Text), 0, "I", Val(Txt_Producto_costo_unitario.Text))
                                Else
                                    c_data2.IngresarCostoUeps(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.Txt_Producto_codigo.Text), Val(Txt_Producto_cantidad.Text), 0, "I", Val(Txt_Producto_costo_unitario.Text))
                                End If
                            End If

                            If dgvMovtos.RowCount = 0 Then
                                Dim mov_1 As String
                                mov_1 = Txt_tipo_movimiento_numero.Text
                                NuevoMovimiento()
                                If (mov_1 <> Txt_tipo_movimiento_numero.Text) Then
                                    MsgBox("EL NUMERO DE MOVIMIENTO: " & mov_1 & " YA EXISTE, ACTUALIZADO A:" & Txt_tipo_movimiento_numero.Text, MsgBoxStyle.Information)
                                End If
                                Ingresar()
                            Else
                                Ingresar()
                            End If
                        End If
                    End If

                End If
                cmbMultiBodega.Enabled = False
                Txt_Existencias.Text = "0.00"
                calcularTotales()
                If cmbTIPO_MOVIMIENTO.SelectedValue = 3 Then
                    If Contribuyente = 3 Then
                        If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                            Label25.Text = " (+/-) Retencion/ISR."
                            txt_Renta.Text = 0
                        ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                            'NATURAL                        
                            Label25.Text = "   (-) ISR."
                            txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                        Else
                            Label25.Text = "   (-) Retencion."
                            txt_Renta.Text = ret_per.recepcion_percepcion(0, Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                        End If
                    ElseIf Contribuyente = 0 Then
                        If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                            Label25.Text = "   (+) ISR."
                            txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                        ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                            Label25.Text = "   (+) ISR."
                            txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                        Else
                            Label25.Text = " (+/-) Retencion/ISR."
                            txt_Renta.Text = 0
                        End If
                    Else
                        If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                            Label25.Text = "   (+) Retencion."
                            If Val(txtSubTotal.Text) > 100 Then
                                txt_Renta.Text = ret_per.recepcion_percepcion(0, Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            Else
                                txt_Renta.Text = "0.00"
                            End If
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                        ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                            Label25.Text = "   (-) ISR."
                            txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                            txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                        Else
                            Label25.Text = " (+/-) Retencion/ISR."
                            txt_Renta.Text = 0
                        End If
                    End If
                End If
            ElseIf sender Is BtnLimpiar Then
                Limpiar()
                cmbMultiBodega.Enabled = False
            End If

        End If
        Me.Txt_Producto_codigo.Focus()
    End Sub

    Public Sub Ingresar()
        Dim verificar_cierre As String = c_data2.leerDataeader("EXECUTE sp_INVENTARIOS_CIERRE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@FECHA_AÑO='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA_MES='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@BIT=0", 0)
        If (verificar_cierre = 0) Then
            Accion_producto_bandeja("I")
            Limpiar()
        End If
        If (verificar_cierre = 1) Then
            MsgBox("El mes ya fue cerrado", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Function Validacion()
        Dim cf As String = "Campo Faltante:" & Chr(13)
        If Me.Txt_Producto_codigo.Text.Trim = Nothing Then
            MessageBox.Show("No ha ingresado el código de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBuscarProducto.Focus()
            Return 2
        End If
        If Me.Txt_Producto_descripcion.Text.Trim = Nothing Then
            MessageBox.Show(cf & "No ha ingresado la descripción de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBuscarProducto.Focus()
            Return 2
        End If
        If Val(Me.Txt_Producto_cantidad.Text) <= 0 Then
            MessageBox.Show(cf & "No ha ingresado la cantidad de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_Producto_cantidad.Clear()
            Me.Txt_Producto_cantidad.Focus()
            Return 2
        End If
        If Me.Txt_Tipo_Movimiento_requiere.Text = True Then
            If Val(Me.Txt_Producto_costo_unitario.Text) <= 0 And _
            Val(Me.Txt_Producto_costo_total.Text) <= 0 Then
                MessageBox.Show(cf & "Debe ingresar el costo unitario o el costo total...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Txt_Producto_costo_unitario.Clear()
                Me.Txt_Producto_costo_total.Clear()
                Me.Txt_Producto_costo_unitario.Focus()
                Return 2
            End If
        End If
        If Val(Me.Txt_Producto_cantidad.Text) > 0 And Val(Me.Txt_Producto_costo_unitario.Text) > 0 Then
            Me.Txt_Producto_costo_total.Text = Val(Me.Txt_Producto_cantidad.Text) * Val(Me.Txt_Producto_costo_unitario.Text)
            Return 1
        ElseIf Val(Me.Txt_Producto_cantidad.Text) > 0 And Val(Me.Txt_Producto_costo_total.Text) > 0 Then
            Me.Txt_Producto_costo_unitario.Text = Val(Me.Txt_Producto_costo_total.Text) / Val(Me.Txt_Producto_cantidad.Text)
            Return 1
        End If
        Return 1
    End Function

    Sub Accion_producto_bandeja(ByVal SIUD)
        Dim msn As String
        Try
            DS02.Reset()
            'Julio Portillo
            'Este metodo inserta el maestro y el detalle
            'aqui es donde se debe modificar
            If salida_ajustes_ <> "7" Then
                msn = cadenaSIUD(Compañia, SIUD)
            Else
                msn = addDetailsTmp(Compañia, SIUD)
            End If

            If Val(msn) = -1 Then
                MsgBox("El producto no posee Costo.", MessageBoxIcon.Information)
                c_data2.cerrarConexion()
                CargarGrid(Compañia, "SPNM")
                Exit Sub
            Else
                'Este se debe cambiar en el boton procesar
                'Julio Portillo
                If salida_ajustes_ <> "7" Then
                    c_data2.Ejecutar_ConsultaSQL(SQL)
                End If
            End If
            If SIUD = "I" Then
                MensajeString = "Dato Adicionado Exitosamente"
            ElseIf SIUD = "UR" Then
                MensajeString = "Dato Modificado Exitosamente: "
            ElseIf SIUD = "DR" Then
                MensajeString = "No se pudieron Eliminar los datos por: "
            End If
            MessageBox.Show(MensajeString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'evalua el tipo de movimiento "Entrada por compra" (No se usó nunca, se quitó el formulario "Inventario_Productos_Lotes" del proyecto)
            'If cmbTIPO_MOVIMIENTO.SelectedValue = 3 Then
            '    If ChkLote.Checked Then
            '        Dim ventana As New Inventario_Productos_Lotes(cmbBODEGA.SelectedValue, Val(Me.Txt_Producto_codigo.Text), Txt_Producto_descripcion.Text, txt_Unidades.Text, Txt_Producto_cantidad.Text)
            '        ventana.ShowDialog()
            '    End If

            'End If

        Catch ex As Exception
            If SIUD = "UR" Then
                MensajeString = "No se pudieron Actualizar los datos por: "
                MessageBox.Show(MensajeString & Chr(13) & ex.Message, "Error...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf SIUD = "DR" Then
                MensajeString = "No se pudieron Eliminar los datos por: "
                MessageBox.Show(MensajeString & Chr(13) & ex.Message, "Error...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf SIUD = "I" Then
                MensajeString = "No se pudo insertar los datos porque ya existe en la bandeja "
                MessageBox.Show(MensajeString, "Error...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If salida_ajustes_ <> "7" Then
                c_data2.cerrarConexion()
                CargarGrid(Compañia, "SPNM")
            Else
                LoadGrid(Compañia, "SPNM")
            End If
        End Try
    End Sub

    Sub EliminarDetalle(ByVal SIUD)
        Try
            If salida_ajustes_ <> "7" Then
                DS02.Reset()
                SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
                SQL &= "@COMPAÑIA = " & Compañia
                SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
                SQL &= ",@TIPO_MOVIMIENTO = " & Me.cmbTIPO_MOVIMIENTO.SelectedValue
                SQL &= ",@MOV = " & Me.Txt_tipo_movimiento_numero.Text
                SQL &= ",@PRODUCTO = " & Me.Txt_Producto_codigo.Text
                SQL &= ",@SIUD = '" & SIUD & "'"

                c_data2.Ejecutar_ConsultaSQL(SQL)
                If SIUD = "DD" Then
                    MensajeString = "Dato Eliminado Exitosamente"
                End If
            Else
                'Julio Portillo
                'En este punto se eliminara el Detalle del DataTable 
                '============================================================
                Dim i As Integer = 0
                Dim d_ As Integer = 0

                Do While Not i = tdetalle_.Rows.Count - 1
                    If tdetalle_.Rows(i).Item("PRODUCTO") = Txt_Producto_codigo.Text Then
                        d_ = i
                    End If
                    i += 1
                Loop
                'tdetalle_.AcceptChanges()
                tdetalle_.Rows.RemoveAt(d_)
                '============================================================
                LoadGrid(Compañia, "SPNM")
            End If
            
            MessageBox.Show(MensajeString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            If SIUD = "DD" Then
                MensajeString = "No se pudo insertar los datos porque ya existe en la bandeja "
                MessageBox.Show(MensajeString, "Error...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If salida_ajustes_ <> "7" Then
                c_data2.cerrarConexion()
                CargarGrid(Compañia, "SPNM")
            End If
        End Try
    End Sub
#End Region

    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Proveedor.Click, Btn_Buscar_Movimiento.Click
        If sender Is Btn_Buscar_Proveedor Then
            Dim frm_pb As New FrmBuscarProveedor
            frm_pb.Compañia_Value = Compañia
            frm_pb.ShowDialog()
            Me.Txt_Proveedores.Text = IIf(ParamNomProvee = "", "SIN PROVEEDOR", ParamNomProvee)
            Me.TxtProveedor_Item.Text = IIf(ParamCodProvee = Nothing, 0, ParamCodProvee)

        ElseIf sender Is Btn_Buscar_Movimiento Then
            If (Txt_tipo_movimiento_numero.Text = "") Then
                MsgBox("Aviso...Debe ingresar el numero del movimiento a buscar", MsgBoxStyle.Information)
            Else
                Dim var As String = c_data2.leerDataeader("Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @SIUD='ESTADO', @MOV=" & IIf(Txt_tipo_movimiento_numero.Text = "", 0, Txt_tipo_movimiento_numero.Text) & ", @TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0)
                CargarGrid(Compañia, "SPNM")
                Try
                    If var = "False" Then
                        'VERIFICAR SI ESTA ANULADO
                        Dim var1 As String = c_data2.leerDataeader("Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @SIUD='ANULADO', @MOV=" & IIf(Txt_tipo_movimiento_numero.Text = "", 0, Txt_tipo_movimiento_numero.Text) & ", @TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0)
                        If var1 = "False" Then
                            Me.lblProcesado.Text = "DOCUMENTO NO PROCESADO"
                            btnProcesarPartida.Enabled = True
                            btnGuardarLinea.Enabled = True
                        Else
                            Me.lblProcesado.Text = "DOCUMENTO ANULADO"
                            btnProcesarPartida.Enabled = False
                            btnGuardarLinea.Enabled = False
                        End If
                    End If
                    If var = "True" Then
                        Me.lblProcesado.Text = "DOCUMENTO PROCESADO"
                        btnProcesarPartida.Enabled = False
                        btnGuardarLinea.Enabled = False
                    End If
                    If var <> "True" And var <> "False" Then
                        MessageBox.Show("AVISO...DOCUMENTO NO EXISTE")
                        Me.lblProcesado.Text = "DOCUMENTO NO EXISTE"
                        btnProcesarPartida.Enabled = False
                        btnGuardarLinea.Enabled = False
                    End If
                    habilitarBotonProcesar()
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Private Sub Txt_Producto_cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_cantidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If Txt_Producto_cantidad.Text.Equals(String.Empty) Then
                    e.Handled = True
                    Txt_Producto_cantidad.Text = ""
                Else
                    e.Handled = Txt_Producto_cantidad.Text.Contains(".")
                End If
            Else
                e.Handled = True
                Txt_Producto_cantidad.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'If Val(Me.Txt_Producto_costo_total.Text) > 0 Then
            Me.Txt_Producto_costo_unitario.Focus()
            'Me.btnGuardarLinea.Focus()
            'End If
            'If (RC = "True") Then
            '    Txt_Producto_costo_unitario.Focus()

            'Else
            '    btnGuardarLinea.Focus()
            'End If
        End If
        c_data2.soloNumerosPuntos(e)

    End Sub

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento) As Integer
        Try
            SQL = "Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            SQL &= Compañia
            SQL &= ", '" & TipoDocumento & "'"
            SQL &= ", 0"
            Return c_data2.leerDataeader(SQL, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub CargaTipoContribuyente(ByVal Compañia, ByVal Bandera)
        Try
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR "
            SQL &= Compañia
            SQL &= ", " & Bandera
            Me.c_data2.CargarCombo(CmbProveedor_TipoProveedor, SQL, "TIPO_PROVEEDOR", "DESCRIPCION_TIPO_PROVEEDOR")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub CargaFormaPago(ByVal Compañia, ByVal Bandera)
        Try
            SQL = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO "
            SQL &= Compañia
            SQL &= ", " & Bandera
            Me.c_data2.CargarCombo(CmbProveedor_FormaPago, SQL, "Pago", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub CargaCondicionPago(ByVal Compañia, ByVal FormaPago, ByVal Bandera)
        Try
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO "
            SQL &= Compañia
            SQL &= ", " & FormaPago
            SQL &= ", " & Bandera
            Me.c_data2.CargarCombo(CmbProveedor_CondicionPago, SQL, "Condición Pago", "Descripción Pago")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

#Region "CmbTipoMovimiento"
    'Estos metodos 
    Private Sub cmbTIPO_MOVIMIENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_MOVIMIENTO.SelectedIndexChanged
        'Dim varbit As Boolean
        salida_ajustes_ = cmbTIPO_MOVIMIENTO.SelectedValue.ToString()
        movimiento_actual_ = Me.cmbTIPO_MOVIMIENTO.Text
        If Iniciando = False Then
            'llena el grid
            NuevoMovimiento()
            BtnLimpiar.PerformClick()
            dgvMovtos.DataSource = Nothing
            RC = c_data2.CargaTipoDocumentoInventario_rc(Compañia, Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0, Me.Txt_Tipo_Movimiento_requiere, Me.Txt_Tipo_Documento_requiere)
            If (RC = "True") Then
                Btn_Buscar_Proveedor.Enabled = True
            Else
                Btn_Buscar_Proveedor.Enabled = False
            End If
            If cmbTIPO_MOVIMIENTO.SelectedValue = 3 Then
                CmbProveedor_FormaPago.Enabled = True
                CmbProveedor_CondicionPago.Enabled = True
                Me.Label5.Visible = True
                Me.Label12.Visible = True
                Me.Label25.Visible = True
                Me.Label26.Visible = True
                Me.Label17.Visible = True

                txtSubTotal.Visible = True
                txtIVA.Visible = True
                txtTotal.Visible = True
                txt_Renta.Visible = True
                txtDIFERENCIA.Visible = True
            Else
                CmbProveedor_TipoProveedor.Enabled = False
                CmbProveedor_FormaPago.Enabled = False
                CmbProveedor_CondicionPago.Enabled = False
                Me.Label5.Visible = False
                Me.Label12.Visible = True
                Me.Label25.Visible = False
                Me.Label26.Visible = False
                Me.Label17.Visible = False
                txtSubTotal.Visible = False
                txtIVA.Visible = False
                txtTotal.Visible = False
                txt_Renta.Visible = False
                txtDIFERENCIA.Visible = True
            End If
        End If
    End Sub

    Private Sub BuscarProveedor(ByVal Compañia, ByVal Proveedor)
        Try
            SQL = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = "
            SQL &= Compañia & " AND PROVEEDOR = " & TxtProveedor_Item.Text
            Me.CmbProveedor_TipoProveedor.SelectedValue = c_data2.leerDataeader(SQL, 7) '"TIPO_PROVEEDOR")
            Me.CmbProveedor_FormaPago.SelectedValue = c_data2.leerDataeader(SQL, 8) '"FORMA_PAGO")
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbTIPO_MOVIMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_MOVIMIENTO.Click
        If Iniciando = False Then
            Movimiento_numero(Compañia)
        End If
    End Sub
#End Region
    Private Sub Btn_Buscar_Movimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Btn_Buscar_Movimiento.KeyDown
        If e.KeyValue = 13 Then
            'MessageBox.Show("Presiono la tecla enter")
            'Btn_Buscar_Click(sender, e)
            CargarGrid(Compañia, "SPNM")
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            Movimiento_numero(Compañia)
            BtnLimpiar.PerformClick()
            dgvMovtos.DataSource = Nothing
            Me.TxtBodega.Text = Me.cmbBODEGA.SelectedValue
        End If
    End Sub

#Region "Txt de requerimientos"
    Private Sub Txt_Tipo_Movimiento_y_Txt_Tipo_Documento_requiere_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Tipo_Movimiento_requiere.TextChanged, Txt_Tipo_Documento_requiere.TextChanged
        If sender Is Txt_Tipo_Movimiento_requiere Then
            If Me.Txt_Tipo_Movimiento_requiere.Text = False Then
                Me.Txt_Producto_costo_unitario.ReadOnly = True
                Me.Txt_Producto_costo_total.ReadOnly = True
                Me.Txt_Producto_costo_unitario.Clear()
                Me.Txt_Producto_costo_total.Clear()
            Else
                Txt_Producto_costo_unitario.ReadOnly = False
                Txt_Producto_costo_total.ReadOnly = False
            End If
        ElseIf sender Is Txt_Tipo_Documento_requiere Then
            If Me.Txt_Tipo_Documento_requiere.Text = "False" Then
                Me.Cmb_tipo_documento.SelectedIndex = 0
                Me.Txt_tipo_documento_numero.ReadOnly = True
                Me.Txt_tipo_documento_numero.Clear()
            Else
                Me.Txt_tipo_documento_numero.ReadOnly = False
            End If
        End If
    End Sub
#End Region

    Private Sub Mantenimiento_Encabezado(ByVal Compañia, ByVal OrdenCompra, ByVal FechaOC, ByVal Procesada, ByVal Bodega, ByVal Proveedor, ByVal TipoContribuyente, ByVal PorcentajePercepcion, ByVal FormaPago, ByVal CondicionPago, ByVal Observaciones, ByVal IUD0)
        Try
            SQL = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD "
            SQL &= "  @COMPAÑIA = " & Compañia
            SQL &= ", @ORDEN_COMPRA = " & OrdenCompra
            SQL &= ", @FECHA_ORDEN_COMPRA = '" & FechaOC & "'"
            SQL &= ", @PROCESADA = " & Procesada
            SQL &= ", @BODEGA = " & Bodega
            SQL &= ", @PROVEEDOR = " & Proveedor
            SQL &= ", @TIPO_CONTRIBUYENTE = " & TipoContribuyente
            SQL &= ", @PORCENTAJE_PERCEPCION = " & PorcentajePercepcion
            SQL &= ", @FORMA_PAGO = " & FormaPago
            SQL &= ", @CONDICION_PAGO = " & CondicionPago
            SQL &= ", @OBSERVACIONES = '" & Observaciones & "'"
            SQL &= ", @USUARIO = '" & Usuario & "'"
            SQL &= ", @IUD = '" & IUD0 & "'"
            SQL &= ", @TIPO_DOCUMENTO = " & Me.Cmb_tipo_documento.SelectedValue

            c_data2.Ejecutar_ConsultaSQL(SQL)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal Compañia, ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Servicio, ByVal IUD0)
        Try
            SQL = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD "
            SQL &= Compañia
            SQL &= ", " & OrdenCompra
            SQL &= ", " & Linea
            SQL &= ", " & Producto
            SQL &= ", '" & Descripcion & "'"
            SQL &= ", " & UnidadMedida
            SQL &= ", " & Cantidad
            SQL &= ", " & Libras
            SQL &= ", " & CostoUnitario
            SQL &= ", " & Servicio
            SQL &= ", '" & Usuario & "'"
            SQL &= ", '" & IUD0 & "'"

            c_data2.Ejecutar_ConsultaSQL(SQL)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GuardaLineasOC_0(ByVal Compañia, ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal CostoUnitario)
        Try
            SQL = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO_IUD "
            SQL &= Compañia
            SQL &= ", " & OrdenCompra
            SQL &= ", " & Linea
            SQL &= ", " & Producto
            SQL &= ", '" & Descripcion & "'"
            SQL &= ", " & UnidadMedida
            SQL &= ", " & Cantidad
            SQL &= ", 0"
            SQL &= ", " & CostoUnitario
            SQL &= ", 0"
            SQL &= ", 0"
            SQL &= ", 0"
            SQL &= ", 0"
            SQL &= ", 0"
            SQL &= ", 1"  'RECIBIDO
            SQL &= ", 1"  'A_INVENTARIO
            SQL &= ", '" & Usuario & "' "
            SQL &= ", 'I' "

            c_data2.Ejecutar_ConsultaSQL(SQL)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub calcularTotales()

        If (RC = "False") Then
            Costo_Total_doc = 0
            For i As Integer = 1 To dgvMovtos.RowCount

                COSTO_PROM = Math.Round(Convert.ToDouble(c_data2.leerDataeader("Exec sp_INVENTARIOS_CALCULAR_COSTOS @COMPAÑIA=" & Compañia & ",@BODEGA=" & dgvMovtos.Rows(i - 1).Cells(10).Value.ToString() & ",@PRODUCTO=" & dgvMovtos.Rows(i - 1).Cells(2).Value.ToString() & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "'", 0)), 5)
                cantidad = Math.Round(Convert.ToDouble(dgvMovtos.Rows(i - 1).Cells(4).Value.ToString()), 5)
                Costo_Total = Math.Round((cantidad * COSTO_PROM), 5)
                ActualizarCostos(dgvMovtos.Rows(i - 1).Cells(2).Value.ToString(), cantidad, COSTO_PROM, Costo_Total.ToString())
                Costo_Total_doc = Costo_Total_doc + Costo_Total
            Next
            'Julio Portillo
            'Se debe controlar que no cargue de nuevo en esta parte            
            If salida_ajustes_ <> "7" Then
                CargarGrid(Compañia, "SPNM")
            End If
        Else
            Costo_Total_doc = 0
            For i As Integer = 0 To dgvMovtos.RowCount - 1
                Costo_Total_doc = Costo_Total_doc + Convert.ToDouble(dgvMovtos.Rows(i).Cells(6).Value.ToString())
            Next

        End If

        If (Cmb_tipo_documento.SelectedValue = 2) Then
            txtSubTotal.Text = Costo_Total_doc.ToString()
            txtIVA.Text = (Val(Costo_Total_doc) * (Por_IVA / 100)).ToString()
            txtDIFERENCIA.Text = (Val(txtSubTotal.Text) + Val(txtIVA.Text)).ToString()
        Else
            txtSubTotal.Text = Costo_Total_doc.ToString()
            txtDIFERENCIA.Text = Costo_Total_doc.ToString()

        End If

        txtTotal.Text = txtDIFERENCIA.Text

        txtSubTotal.Text = Math.Round(Val(txtSubTotal.Text), 2)
        txtIVA.Text = Math.Round(Val(txtIVA.Text), 2)
        txtTotal.Text = Math.Round(Val(txtTotal.Text), 2)
        txt_Renta.Text = Math.Round(Val(txt_Renta.Text), 2)
        txtDIFERENCIA.Text = Math.Round(Val(txtDIFERENCIA.Text), 2)
    End Sub

    Private Sub GuardarSalidasAjustes(ByVal producto_ As String, ByVal cantidad_ As String, ByVal costo_ As String, ByVal costo_tot_ As String)
        SQL &= "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        If ChkHabilitar.Checked = True Then
            SQL &= ",@BODEGA = " & Me.cmbMultiBodega.SelectedValue
        Else
            SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        End If
        SQL &= ",@PROVEEDOR = 0,@TIPO_MOVIMIENTO = " & salida_ajustes_
        SQL &= ",@MOV = " & IIf(Me.Txt_tipo_movimiento_numero.Text = "", 0, Me.Txt_tipo_movimiento_numero.Text)
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = " & Me.Cmb_tipo_documento.SelectedValue
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = " & Val(Me.Txt_tipo_documento_numero.Text)
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & producto_
        SQL &= ",@CANTIDAD = " & cantidad_
        SQL &= ",@COSTO_UNIDAD = " & costo_
        SQL &= ",@COSTO_TOTAL = " & costo_tot_
        SQL &= ",@ENTRADA_SALIDA =" & ENTRADA_SALIDA
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'I'" & vbCrLf
    End Sub

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        btnGuardarLinea.Enabled = False       
        RC = c_data2.CargaTipoDocumentoInventario_rc(Compañia, Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0, Me.Txt_Tipo_Movimiento_requiere, Me.Txt_Tipo_Documento_requiere)
        calcularTotales()
        If cmbTIPO_MOVIMIENTO.SelectedValue = 7 Then
            SQL = String.Empty
            For i As Integer = 0 To dgvMovtos.RowCount - 1
                GuardarSalidasAjustes(dgvMovtos.Rows(i).Cells(2).Value.ToString(), dgvMovtos.Rows(i).Cells(4).Value.ToString(), dgvMovtos.Rows(i).Cells(5).Value.ToString(), dgvMovtos.Rows(i).Cells(6).Value.ToString())
            Next

            DS02.Reset()
            c_data2.Ejecutar_ConsultaSQL(SQL)
            c_data2.cerrarConexion()
        Else
            If cmbTIPO_MOVIMIENTO.SelectedValue = 3 Then

                'Se ingresa el registro encabezado de la orden de compra
                If Contribuyente = 3 Then
                    If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                        Label25.Text = " (+/-) Retencion/ISR."
                        txt_Renta.Text = 0
                    ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                        'NATURAL                        
                        Label25.Text = "   (-) ISR."
                        txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                    Else
                        Label25.Text = "   (-) Retencion."
                        txt_Renta.Text = ret_per.recepcion_percepcion(0, Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                    End If
                ElseIf Contribuyente = 0 Then
                    If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                        Label25.Text = "   (+) ISR."
                        txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                    ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                        Label25.Text = "   (+) ISR."
                        txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                    Else
                        Label25.Text = " (+/-) Retencion/ISR."
                        txt_Renta.Text = 0
                    End If
                Else
                    If CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                        Label25.Text = "   (+) Retencion."
                        If Val(txtSubTotal.Text) > 100 Then
                            txt_Renta.Text = ret_per.recepcion_percepcion(0, Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        Else
                            txt_Renta.Text = "0.00"
                        End If
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) + Val(txt_Renta.Text), "0.00")
                    ElseIf CmbProveedor_TipoProveedor.SelectedValue = 0 Then
                        Label25.Text = "   (-) ISR."
                        txt_Renta.Text = ret_per.Renta(Val(CmbProveedor_TipoProveedor.SelectedValue), Val(txtSubTotal.Text))
                        txtDIFERENCIA.Text = Format(Val(txtTotal.Text) - Val(txt_Renta.Text), "0.00")
                    Else
                        Label25.Text = " (+/-) Retencion/ISR."
                        txt_Renta.Text = 0
                    End If
                End If

                Dim IUD1 As String
                If Val(txtOC.Text) = 0 Then
                    Me.txtOC.Text = GeneraCorrelativo(Compañia, "OC").ToString
                    IUD1 = "I"
                Else
                    IUD1 = "U"
                End If

                TotalFact = Val(txtDIFERENCIA.Text) '- Val(txt_Renta.Text)
                Mantenimiento_Encabezado(Compañia, Me.txtOC.Text, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy HH:mm:ss"), 1, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Item.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, IIf(Val(txt_Renta.Text) > 0, PorcPercep, 0), Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, "ENTRADA POR COMPRA", IUD1)
                Mantenimiento_OCAutorizacion(Compañia, Me.txtOC.Text, "1", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txt_Renta.Text.Replace(",", ""), TotalFact, "ENTRADA POR COMPRA", "I")
                For i As Integer = 0 To dgvMovtos.RowCount - 1
                    Mantenimiento_Detalle(Compañia, Me.txtOC.Text, 0, dgvMovtos.Rows(i).Cells(2).Value.ToString(), dgvMovtos.Rows(i).Cells(3).Value.ToString(), 0, dgvMovtos.Rows(i).Cells(4).Value.ToString(), 0, dgvMovtos.Rows(i).Cells(5).Value.ToString(), "0", "I")
                    GuardaLineasOC_0(Compañia, Me.txtOC.Text, 0, dgvMovtos.Rows(i).Cells(2).Value.ToString(), dgvMovtos.Rows(i).Cells(3).Value.ToString(), 0, dgvMovtos.Rows(i).Cells(4).Value.ToString(), dgvMovtos.Rows(i).Cells(5).Value.ToString())
                Next

                Dim Recibir As New Inventario_ComprasRecibir
                'Cheque.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
                Recibir.Bodega_Value = cmbBODEGA.SelectedValue
                Recibir.lblOC.Text = txtOC.Text
                Recibir.lblNOMBRE_PROVEEDOR.Text = IIf(Txt_Proveedores.Text = "", "Sin proveedor", Txt_Proveedores.Text)
                Recibir.lblSubTotal.Text = txtSubTotal.Text
                Recibir.lblIVA.Text = txtIVA.Text
                Recibir.lblCESC.Text = txtTotal.Text
                Recibir.lblRetencion.Text = txt_Renta.Text
                Recibir.lblTotalCompra.Text = Val(txtDIFERENCIA.Text) '- Val(txt_Renta.Text)
                Recibir.txtFACTURA.Text = Txt_tipo_documento_numero.Text
                Recibir.dpFecha_Comp.Value = dpFECHA_CONTABLE.Value
                Recibir.chkInv.Checked = True
                Recibir.Compañia_Value = Me.Cmb_tipo_documento.SelectedValue
                Recibir.ShowDialog()
                MsgBox("AVISO...Documento procesado.!", MsgBoxStyle.Information)
            Else
                Dim ExistePdaAuto As Integer
                CtroCosto = c_data2.leerDataeader("SELECT ISNULL(CENTRO_COSTO,0) FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia.ToString & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue.ToString, 0)
                ExistePdaAuto = c_data2.leerDataeader("SELECT COUNT(CUENTA) FROM VISTA_CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS_CENTRO_COSTO WHERE COMPAÑIA = " & Compañia & " AND CENTRO_COSTO = " & CtroCosto & " AND TIPO_DOCUMENTO = " & TipoDocto & " AND ORIGEN  = 0", 0)
                If ExistePdaAuto > 0 Then
                    NumeDocto = ProcesosContables.Contabiliza_Partida_Automatica_Standard(Compañia, CtroCosto, TipoDocto, 0, Val(Me.Txt_tipo_documento_numero.Text), Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy HH:mm:ss"), 0, Val(Me.Txt_tipo_documento_numero.Text), Val(txtDIFERENCIA.Text) - Val(txt_Renta.Text), Me.cmbTIPO_MOVIMIENTO.Text.Trim & " No." & Me.Txt_tipo_movimiento_numero.Text & " Para " & Me.cmbBODEGA.Text)
                End If
                MsgBox("AVISO...Documento procesado.!", MsgBoxStyle.Information)
            End If
        End If
        
        Me.lblProcesado.Text = "DOCUMENTO PROCESADO"

        Actualizar_Estado()
        btnProcesarPartida.Enabled = False
        Button3.Enabled = False
        Dim pr As String = 0
        If dpFECHA_CONTABLE.Enabled = True Then
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Movimientos_Entradas_y_Salidas', @BANDERA=4, @ITEM=" & item)
            dpFECHA_CONTABLE.Value = Date.Now
        End If
    End Sub

    Private Sub Mantenimiento_OCAutorizacion(ByVal Compañia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            SQL = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            SQL &= Compañia
            SQL &= ", " & OrdenCompra
            SQL &= ", " & Autorizada
            SQL &= ", " & Anulada
            SQL &= ", " & SubTotal
            SQL &= ", " & IVA
            SQL &= ", " & Total
            SQL &= ", " & Percepcion
            SQL &= ", " & TotalCompra
            SQL &= ", '" & Comentario & "'"
            SQL &= ", '" & Usuario & "'"
            SQL &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(SQL, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            'MsgBox("¡Orden de Compra Procesada con éxito!", MsgBoxStyle.Information, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        If tdetalle_.Rows.Count > 0 Then
            tdetalle_.Clear()
        End If
        Txt_tipo_movimiento_numero.Text = "0"
        Me.cmbBODEGA.SelectedIndex = 0
        Me.cmbTIPO_MOVIMIENTO.SelectedIndex = 0
        TxtProveedor_Item.Text = "1"
        txt_Unidades.Text = ""
        Me.Txt_Proveedores.Text = ""
        Movimiento_numero(Compañia)
        Limpiar()
        dgvMovtos.DataSource = Nothing
        Me.lblProcesado.Text = "NUEVO DOCUMENTO"
        btnProcesarPartida.Enabled = True
        btnGuardarLinea.Enabled = True
        txtDIFERENCIA.Text = "0.0"
        txtIVA.Text = "0.0"
        txtSubTotal.Text = "0.0"

        txtTotal.Text = "0.0"
        Button3.Enabled = True
        txtOC.Clear()
        If dpFECHA_CONTABLE.Enabled = True Then

            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Movimientos_Entradas_y_Salidas', @BANDERA=4, @ITEM=" & item)
            dpFECHA_CONTABLE.Value = Date.Now
        End If
    End Sub
    Private Sub Txt_tipo_movimiento_numero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_tipo_movimiento_numero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Me.Btn_Buscar_Movimiento.PerformClick()
        End If

    End Sub

    Public Sub habilitarBotonProcesar()
        If ((lblProcesado.Text = "DOCUMENTO NO PROCESADO") Or ((lblProcesado.Text = "NUEVO DOCUMENTO"))) Then
            btnProcesarPartida.Enabled = True
        Else
            btnProcesarPartida.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim var As String = c_data2.leerDataeader("Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @SIUD='ESTADO', @MOV=" & Txt_tipo_movimiento_numero.Text & ", @TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0)
        Try
            If salida_ajustes_ <> "7" Then
                If var = "True" Then
                    Me.lblProcesado.Text = "DOCUMENTO PROCESADO"
                    btnProcesarPartida.Enabled = False
                    btnGuardarLinea.Enabled = False
                    MsgBox("AVISO...Imposible anular, DOCUMENTO PROCESADO", MsgBoxStyle.Information)
                End If
                If var = "False" Then
                    'VERIFICAR SI ESTA ANULADO
                    var = c_data2.leerDataeader("Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @SIUD='ANULADO', @MOV=" & Txt_tipo_movimiento_numero.Text & ", @TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue, 0)
                    If var = "False" Then
                        c_data2.Ejecutar_ConsultaSQL("Execute sp_INVENTARIOS_ANULAR_DOCUMENTOS @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIPO_MOVIMIENTO=" & Me.cmbTIPO_MOVIMIENTO.SelectedValue & ", @MOVIMIENTO_IN_OUT=" & Txt_tipo_movimiento_numero.Text & ", @BANDERA=1")
                        MsgBox("OK...El Documento ha sido anulado", MsgBoxStyle.Information)
                        Me.lblProcesado.Text = "DOCUMENTO ANULADO"
                    Else
                        Me.lblProcesado.Text = "DOCUMENTO ANULADO"
                        btnProcesarPartida.Enabled = False
                        btnGuardarLinea.Enabled = False
                    End If
                End If
                If var <> "True" And var <> "False" Then
                    MsgBox("AVISO...DOCUMENTO NO EXISTE", MsgBoxStyle.Information)
                    Me.lblProcesado.Text = "DOCUMENTO NO EXISTE"
                    btnProcesarPartida.Enabled = False
                    btnGuardarLinea.Enabled = False
                End If
                habilitarBotonProcesar()
            Else
                If var = "True" Then
                    Me.lblProcesado.Text = "DOCUMENTO PROCESADO"
                    btnProcesarPartida.Enabled = False
                    btnGuardarLinea.Enabled = False
                    MsgBox("AVISO...Imposible anular, DOCUMENTO PROCESADO", MsgBoxStyle.Information)
                Else
                    If MsgBox("Desea cancelar el documento?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
                        Nuevo()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Producto_codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                If ChkHabilitar.Checked = True Then
                    Me.Txt_Producto_descripcion.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbMultiBodega.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 1)
                    Me.txt_Unidades.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbMultiBodega.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 2)
                    Me.Txt_Existencias.Text = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbMultiBodega.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Else
                    Me.Txt_Producto_descripcion.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 1)
                    Me.txt_Unidades.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 2)
                    Me.Txt_Existencias.Text = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                End If
                If Txt_Producto_descripcion.Text = "" Then
                    MsgBox("AVISO...Codigo No existe en esta bodega", MsgBoxStyle.Information)
                Else
                    Me.Txt_Producto_cantidad.Focus()
                End If
            Catch ex As Exception
                Txt_Producto_codigo.Text = ""
                MsgBox("El codigo es numerico", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub Txt_Producto_costo_unitario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_costo_unitario.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If Txt_Producto_costo_unitario.Text.Equals(String.Empty) Then
                    e.Handled = True
                    Txt_Producto_costo_unitario.Text = ""
                Else
                    e.Handled = Txt_Producto_costo_unitario.Text.Contains(".")
                End If
            Else
                e.Handled = True
                Txt_Producto_costo_unitario.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Val(Me.Txt_Producto_costo_unitario.Text) = 0 Then
                Me.Txt_Producto_costo_total.Focus()
            Else
                Me.Txt_Producto_costo_total.Text = Val(Me.Txt_Producto_costo_unitario.Text) * Val(Me.Txt_Producto_cantidad.Text)
                Me.btnGuardarLinea.Focus()
            End If

        End If
    End Sub

    Private Sub Txt_tipo_documento_numero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_tipo_documento_numero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        EliminarDetalle("DD")
        cmbMultiBodega.Enabled = False
    End Sub

    Private Sub ChkHabilitar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkHabilitar.CheckedChanged
        If ChkHabilitar.Checked = True Then
            cmbMultiBodega.Enabled = True
            c_data2.CargaBodegas(Compañia, Me.cmbMultiBodega, 7)
        Else
            cmbMultiBodega.Enabled = False
            Me.cmbMultiBodega.DataSource = Nothing
        End If
    End Sub

    Private Sub dgvMovtos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMovtos.Click
        Try
            Me.Txt_tipo_movimiento_numero.Text = Me.dgvMovtos.CurrentRow.Cells.Item(1).Value
            Me.Txt_Producto_codigo.Text = Me.dgvMovtos.CurrentRow.Cells.Item(2).Value
            Me.Txt_Producto_descripcion.Text = Me.dgvMovtos.CurrentRow.Cells.Item(3).Value
            Me.Txt_Producto_cantidad.Text = Me.dgvMovtos.CurrentRow.Cells.Item(4).Value
            Me.Txt_Producto_costo_unitario.Text = Me.dgvMovtos.CurrentRow.Cells.Item(5).Value
            Me.Txt_Producto_costo_total.Text = Me.dgvMovtos.CurrentRow.Cells.Item(6).Value
            Me.Txt_Proveedores.Text = Me.dgvMovtos.CurrentRow.Cells.Item(8).Value
            Me.cmbBODEGA.Text = Me.dgvMovtos.CurrentRow.Cells.Item(11).Value
            Me.cmbTIPO_MOVIMIENTO.Text = Me.dgvMovtos.CurrentRow.Cells.Item(13).Value
            Me.Cmb_tipo_documento.Text = Me.dgvMovtos.CurrentRow.Cells.Item(15).Value
            Me.Txt_tipo_documento_numero.Text = Me.dgvMovtos.CurrentRow.Cells.Item(16).Value

            'Me.Txt_c.Text = Me.dgvMovtos.CurrentRow.Cells.Item(0).Value 'Compañia
            Movimiento = Me.dgvMovtos.CurrentRow.Cells.Item(1).Value 'Movimiento
            Tipo_Moviniento = Me.dgvMovtos.CurrentRow.Cells.Item(12).Value 'Tipo Movimiento
            Detalle = Val(Me.dgvMovtos.CurrentRow.Cells.Item(20).Value) 'Detalle
        Catch ex As Exception

        End Try

        'MessageBox.Show("Movimiento: " & Movimiento & Chr(13) & _
        '                "Tipo Moviniento: " & Tipo_Moviniento & Chr(13) & _
        '                "Detalle: " & Detalle, Me.Text, MessageBoxButtons.OK)
    End Sub

    Private Sub Cmb_tipo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_tipo_documento.SelectedIndexChanged
        If Iniciando = False Then
            If Cmb_tipo_documento.SelectedValue = 0 Then
                Txt_tipo_documento_numero.BackColor = Color.White

            Else
                Txt_tipo_documento_numero.BackColor = Color.Yellow
                Txt_tipo_documento_numero.Focus()

            End If
        End If
    End Sub

    Private Sub CmbProveedor_FormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor_FormaPago.SelectedIndexChanged
        If Iniciando = False Then
            CargaCondicionPago(Compañia, Me.CmbProveedor_FormaPago.SelectedValue, 1)
        End If
    End Sub

    Private Sub TxtProveedor_Item_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Item.TextChanged        
        BuscarProveedor(Compañia, TxtProveedor_Item.Text)
    End Sub

    Private Sub Txt_Producto_costo_total_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_costo_total.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If Txt_Producto_costo_unitario.Text.Equals(String.Empty) Then
                    e.Handled = True
                    Txt_Producto_costo_unitario.Text = ""
                Else
                    e.Handled = Txt_Producto_costo_unitario.Text.Contains(".")
                End If
            Else
                e.Handled = True
                Txt_Producto_costo_unitario.Text = ""
            End If
        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Me.Txt_Producto_costo_unitario.Text = Val(Me.Txt_Producto_costo_total.Text) / Val(Me.Txt_Producto_cantidad.Text)
            Me.btnGuardarLinea.Focus()
        End If
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.txtFecheo.Text = "" Then
            Dim fecheo As New Seguridad_Pos_Ante_Fecheo(Me.cmbBODEGA.Text, Me.cmbBODEGA.SelectedValue, "Inventario_Movimientos_Entradas_y_Salidas")
            fecheo.ShowDialog()
        Else
            clave = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Movimientos_Entradas_y_Salidas', @BANDERA=3", 0)
            item = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Movimientos_Entradas_y_Salidas', @BANDERA=3", 1)
            pos_ante = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Movimientos_Entradas_y_Salidas', @BANDERA=3", 2)

        End If
    End Sub

    Private Sub dpFECHA_CONTABLE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFECHA_CONTABLE.ValueChanged
        Dim fecha_adelante As Date
        Dim fecha_atras As Date
        fecha_adelante = DateAdd("d", 1, Date.Now)
        fecha_atras = DateAdd("d", -2, Date.Now)

        If clave <> "" Then
            If pos_ante = "True" Then
                If dpFECHA_CONTABLE.Value.Date < Date.Now.Date Then
                    MsgBox("Imposible realizar un AnteFecheo porque usted solicito un PosFecheo", MsgBoxStyle.Exclamation)
                    dpFECHA_CONTABLE.Value = Date.Now
                End If
            Else
                If dpFECHA_CONTABLE.Value.Date > Date.Now.Date Then
                    MsgBox("Imposible realizar un PosFecheo porque usted solicito un AnteFecheo", MsgBoxStyle.Exclamation)
                    dpFECHA_CONTABLE.Value = Date.Now
                End If
            End If
        Else
            If (dpFECHA_CONTABLE.Value.Date > fecha_adelante) Or (dpFECHA_CONTABLE.Value.Date < fecha_atras) Then
                MsgBox("Imposible realizar un cambios de fecha de 2 dias, retorna a fecha actual " & Date.Now, MsgBoxStyle.Exclamation)
                dpFECHA_CONTABLE.Value = Date.Now
            End If
        End If
    End Sub
End Class
