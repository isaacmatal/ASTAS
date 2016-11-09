Imports System.Data.SqlClient
Public Class Inventario_Ingreso_Fisico_y_Ajuste
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim dtareader As SqlDataReader
    Dim Procesos_Contables As New Contabilidad_Procesos
    Dim AJUSTE As Double = 0, EXIST_TEO As Double = 0, EXIST_FIS As Double = 0
    Dim OPERACION As String = "", numeroSalida As String, numeroEntrada As String
    Dim item As String = 0
    Dim pos_ante As String
    Private Sub Inventario_Ingreso_Fisico_y_Ajuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        sugerirMovTransferencia()
        Iniciando = False
    End Sub
    Public Sub sugerirMovTransferencia()        
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO),0)+1 FROM INVENTARIOS_PRODUCTOS_BODEGAS_FISICOS_AJUSTE_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue
        Txt_tipo_movimiento_numero.Text = c_data1.leerDataeader(consulta, 0)
    End Sub
    Public Sub SacarAjuste()
        EXIST_TEO = Convert.ToDouble(Val(Txt_Producto_cantidad.Text))
        EXIST_FIS = Convert.ToDouble(Val(Txt_Exist_Fisicas.Text))
        AJUSTE = EXIST_TEO - EXIST_FIS
        If AJUSTE = 0 Then
            OPERACION = "0"
        Else
            OPERACION = IIf(AJUSTE > 0, "+", "-")
        End If
        Me.Txt_Producto_costo_total.Text = OPERACION & AJUSTE.ToString()
    End Sub
    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        Dim h As String = String.Empty
        If ((Txt_tipo_movimiento_numero.Text = "") Or (Txt_Producto_codigo.Text = "") Or (Txt_Producto_descripcion.Text = "") Or (Txt_Exist_Fisicas.Text = "")) Then
            MsgBox("AVISO...Verificar que todos los campos contengan datos!", MsgBoxStyle.Information)
        Else
            Try
                Me.Txt_Producto_cantidad.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & ", " & Me.cmbBODEGA.SelectedValue & ", " & Me.Txt_Producto_codigo.Text & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                SacarAjuste()
                h = c_data1.leerDataeader("execute sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE " & Compañia & ", " & cmbBODEGA.SelectedValue & ", " & Txt_Producto_codigo.Text & ", " & Txt_tipo_movimiento_numero.Text & ", " & Txt_Producto_cantidad.Text & ", " & Txt_Exist_Fisicas.Text & ", '" & OPERACION & "'," & AJUSTE & ", 0, '" & Usuario & "', 1", 0)
            Catch ex As Exception
                MsgBox("AVISO...Mal cálculo de las existencias", MsgBoxStyle.Information)
            End Try
            If h = "0" Then
                MsgBox("AVISO...Ya se ha ajustado un producto con este código!", MsgBoxStyle.Information)
            End If
            If h = "1" Then
                MsgBox("Producto ajustado con éxito!", MsgBoxStyle.Information)
            End If
            CargarGrid("execute sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE " & Compañia & ", " & cmbBODEGA.SelectedValue & ", " & Txt_Producto_codigo.Text & ", " & Txt_tipo_movimiento_numero.Text & ", " & Txt_Producto_cantidad.Text & ", " & Txt_Exist_Fisicas.Text & ", '" & OPERACION & "'," & Math.Abs(AJUSTE) & ", 0, '" & Usuario & "', 0")
            Limpiar()
            Txt_Producto_codigo.Focus()
        End If
    End Sub

#Region "Connection"

    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Resultado As DialogResult

#End Region
    Public Sub CargarGrid(ByVal consulta As String)
        Try
            DS01.Reset()
            c_data1.MiddleConnection(consulta)
            c_data1.DataAdapter.Fill(DS01)
            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data1.cerrarConexion()
            For i As Integer = 1 To dgvMovtos.ColumnCount
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
            dgvMovtos_Aling()
        Catch ex As Exception
            MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub Limpiar()
        Txt_Producto_codigo.Text = ""
        Txt_Producto_descripcion.Text = ""
        Txt_Producto_cantidad.Text = "0"
        Txt_Exist_Fisicas.Text = ""
        Txt_Producto_costo_total.Text = "0"
        txtFecheo.Text = ""
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Limpiar()
        Txt_Exist_Fisicas.ReadOnly = False
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.Txt_Producto_codigo.Text = CodigoProducto
        Me.Txt_Producto_descripcion.Text = Descripcion_Producto
        Me.Txt_Producto_cantidad.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & ", " & Me.cmbBODEGA.SelectedValue & ", " & Me.Txt_Producto_codigo.Text & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "')", 0)
        Me.txt_Unidades.Text = unidades
    End Sub


    Private Sub Txt_Exist_Fiscicas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Exist_Fisicas.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If (Txt_Exist_Fisicas.Text = "") Then
                MsgBox("Debe ingresar una Existencia Fisica para poder realizar el ajuste", MsgBoxStyle.Information)
            Else
                btnGuardarLinea.Focus()
            End If
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
        If DateTimePicker1.Enabled = True Then
            DateTimePicker1.Enabled = False
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Ingreso_Fisico_y_Ajuste', @BANDERA=4, @ITEM=" & item)
            DateTimePicker1.Value = Date.Now
        End If

        Me.cmbBODEGA.SelectedIndex = 0
        sugerirMovTransferencia()
        DateTimePicker1.Refresh()
        DateTimePicker1.Value = Date.Now
        dgvMovtos.DataSource = Nothing
        btnGuardarLinea.Enabled = True
        btnProcesar.Enabled = True
        BtnLimpiar.Enabled = True
        Button3.Enabled = True
        txt_Unidades.Text = ""
        Me.lblProcesado.Text = "NUEVO AJUSTE DE INVENTARIO"
    End Sub

    Private Sub Txt_Producto_codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_codigo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                Me.Txt_Producto_descripcion.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 1)
                Me.txt_Unidades.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 2)
                Try
                    Me.Txt_Producto_cantidad.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & ", " & Me.cmbBODEGA.SelectedValue & ", " & Me.Txt_Producto_codigo.Text & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "')", 0)
                Catch ex As Exception
                    MsgBox("AVISO...Al calcular las existencias", MsgBoxStyle.Information)
                End Try
                If Txt_Producto_descripcion.Text = "" Then
                    MsgBox("AVISO...Código No existe en esta bodega", MsgBoxStyle.Information)
                Else
                    Txt_Exist_Fisicas.Focus()
                End If
            Catch ex As Exception
                MsgBox("El código ingresado no existe!", MsgBoxStyle.Information)
            End Try
        End If
    End Sub


    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If dgvMovtos.RowCount = 0 Then
            MsgBox("Debe ingresar al menos un ajuste para poder procesar", MsgBoxStyle.Exclamation)
        Else
            Dim ajuste_1 As Double = 0
            Dim cantidad As String = 0
            Dim COSTO_PROM As String = 0
            Dim Costo_Total As Double = 0
            Dim Costo_Total_doc As Double = 0

            sugerirMovSalida()
            sugerirMovEntrada()  'Único para los sobrantes

            For i As Integer = 1 To dgvMovtos.RowCount
                ajuste_1 = Convert.ToDouble(dgvMovtos.Rows(i - 1).Cells(5).Value.ToString())
                Dim tipo_costo As String = c_data1.leerDataeader("EXEC [dbo].[sp_INVENTARIOS_INGRESAR_COMPRAS] @COMPAÑIA=" & Compañia & ",@PRODUCTO=" & Val(dgvMovtos.Rows(i - 1).Cells(0).Value.ToString()) & ",@BANDERA='V'", 0)
                If Val(tipo_costo) = 1 Then
                    'COSTO PROMEDIO
                    COSTO_PROM = Math.Round(Convert.ToDouble(c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Val(dgvMovtos.Rows(i - 1).Cells(0).Value.ToString()) & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)), 2)
                Else
                    'UEPS
                    COSTO_PROM = c_data1.IngresarCostoUeps(Compañia, cmbBODEGA.SelectedValue, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
                End If

                cantidad = Math.Round(Math.Abs(ajuste_1), 2)
                Costo_Total = Math.Round((cantidad * COSTO_PROM), 2)
                Costo_Total_doc = Costo_Total_doc + Costo_Total

                If ajuste_1 < 0 Then

                    '6 con parámetro 1 después de numeroEntrada Y 7 con parámetro 0 (ENTRADA Y SALIDA POR AJUSTE.)
                    cadenaSIUD(Compañia, "I", 6, numeroEntrada, 1, COSTO_PROM, Costo_Total, dgvMovtos.Rows(i - 1).Cells(0).Value.ToString(), cantidad, 1)
                    c_data1.Ejecutar_ConsultaSQL(SQL)
                End If
                If ajuste_1 > 0 Then
                    '6 con parámetro 1 después de numeroEntrada Y 7 con parámetro 0 (ENTRADA Y SALIDA POR AJUSTE.)
                    cadenaSIUD(Compañia, "I", 7, numeroSalida, 0, COSTO_PROM, Costo_Total, dgvMovtos.Rows(i - 1).Cells(0).Value.ToString(), cantidad, 1)
                    c_data1.Ejecutar_ConsultaSQL(SQL)
                End If
            Next

            'CREACION DE PARTIDA DE AJUSTES.
            'SE DETERMINA EL NUMERO DE TRANSACCION
            'Dim Transaccion As Integer = c_data1.leerDataeader("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & DateTimePicker1.Value.Year & ", @MES = " & DateTimePicker1.Value.Month & ", @ULTIMO = 0", 0)
            ''SE DETERMINA EL LIBRO CONTABLE
            'Dim Libro As Integer = c_data1.leerDataeader("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1", 0)
            ''SE DETERMINA EL CENTRO DE COSTO
            'Dim CentCosto As Integer = c_data1.leerDataeader("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue, 0)
            ''SE DETERMINA LA CUENTA A CARGAR
            'Dim CtaCargada As Integer = c_data1.leerDataeader("SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & Libro & "AND CENTRO_COSTO=" & CentCosto & " AND TIPO_DOCUMENTO=18 AND TIPO_MOVIMIENTO=9 AND CARGO=1", 0)
            ''SE DETERMINA LA CUENTA ABONAR
            'Dim CtaAbonada As Integer = c_data1.leerDataeader("SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & Libro & "AND CENTRO_COSTO=" & CentCosto & " AND TIPO_DOCUMENTO=18 AND TIPO_MOVIMIENTO=9 AND CARGO=0", 0)

            '**************************************************************************************************************************
            'Procesos_Contables.EncabezadoPartida(Transaccion, 2, 18, numeroEntrada, DateTimePicker1.Value, Libro, "Ajuses de Inventario por Sobrante en Físico ", 0, 0, "I")
            'Procesos_Contables.DetallePartida(Transaccion, 0, CentCosto, DateTimePicker1.Value, Libro, "Ajuste por sobrante en toma de Inventario Físico", CtaAbonada, "A", 0, Costo_Total_doc, "I")

            '**************************************************************************************************************************


            'Dim sqlCmd As New SqlCommand("EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPAÑIA = " & Compañia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'")
            'c_data1.ejecutarComandoSql(sqlCmd)
            c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @MOVIMIENTO=" & Me.Txt_tipo_movimiento_numero.Text & ", @BANDERA=2")
            Me.lblProcesado.Text = "AJUSTE PROCESADO"
            Try
                CargarGrid("execute sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @MOVIMIENTO =" & Txt_tipo_movimiento_numero.Text & ", @BANDERA=0")
            Catch ex As Exception
                Me.dgvMovtos.DataSource = Nothing
            End Try
            If DateTimePicker1.Enabled = True Then
                DateTimePicker1.Enabled = False
                c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Ingreso_Fisico_y_Ajuste', @BANDERA=4, @ITEM=" & item)
                DateTimePicker1.Value = Date.Now
            End If
            MsgBox("AVISO...SE HA PROCESADO CON EXITO!", MsgBoxStyle.Exclamation)
            btnProcesar.Enabled = False
            btnGuardarLinea.Enabled = False
        End If
    End Sub
    Public Function sugerirMov(ByVal consulta)
        Dim mov As String
        mov = c_data1.leerDataeader(consulta, 0)
        Return mov
    End Function
    Public Sub sugerirMovSalida()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue & " AND TIPO_MOVIMIENTO = 7"
        numeroSalida = sugerirMov(consulta)
    End Sub
    Public Sub sugerirMovEntrada()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue & " AND TIPO_MOVIMIENTO = 6"
        numeroEntrada = sugerirMov(consulta)
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD, ByVal TIPO_movimiento, ByVal mov, ByVal ENTRADA_SALIDA, ByVal costo_uni, ByVal costo_total, Optional ByVal producto = 0, Optional ByVal cantidad = 0, Optional ByVal procesar = 0)        
        'Dim existencias As Double = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        SQL &= ",@PROVEEDOR = 0"
        SQL &= ",@TIPO_MOVIMIENTO = " & TIPO_movimiento
        SQL &= ",@MOV = " & mov
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & procesar
        'Dim cantidad_R As Double = Math.Abs(cantidad - existencias)

        If procesar = 1 Then
            Dim costox As String = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Val(producto) & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
            SQL &= ",@PRODUCTO = " & Val(producto)
            SQL &= ",@CANTIDAD = " & Math.Abs(Val(cantidad))
            SQL &= ",@COSTO_UNIDAD = " & Val(costox)
            SQL &= ",@COSTO_TOTAL = " & (Val(costox) * Math.Abs(Val(cantidad))).ToString()
        Else
            Dim costox As String = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
            SQL &= ",@PRODUCTO = " & Val(Me.Txt_Producto_codigo.Text)
            SQL &= ",@CANTIDAD = " & Math.Abs(Val(cantidad))
            SQL &= ",@COSTO_UNIDAD = " & Val(costox)
            SQL &= ",@COSTO_TOTAL = " & (Val(costox) * Val(Me.Txt_Producto_cantidad.Text)).ToString()
        End If
        SQL &= ",@ENTRADA_SALIDA =" & ENTRADA_SALIDA
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'" & SIUD & "'"
    End Sub

    Private Sub Btn_Buscar_Movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Movimiento.Click
        If Txt_tipo_movimiento_numero.Text = "" Then
            MsgBox("AVISO...Debe ingresar un número de documento a buscar!", MsgBoxStyle.Exclamation)
        Else
            CargarGrid("execute sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @BANDERA=0")
            If (dgvMovtos.RowCount > 0) Then
                dgvMovtos_Aling()
                If (dgvMovtos.Rows(0).Cells(9).Value.ToString() = True) Then
                    Me.lblProcesado.Text = "AJUSTE PROCESADO"
                    btnGuardarLinea.Enabled = False
                    btnProcesar.Enabled = False
                    BtnLimpiar.Enabled = False
                    Button3.Enabled = False
                Else
                    Me.lblProcesado.Text = "AJUSTE PENDIENTE DE PROCESAR"
                    btnGuardarLinea.Enabled = True
                    btnProcesar.Enabled = True
                    BtnLimpiar.Enabled = True
                    Button3.Enabled = True
                End If
            End If
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

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            sugerirMovTransferencia()
        End If        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "ELIMINAR") = MsgBoxResult.Yes Then
            c_data1.leerDataeader("execute sp_INVENTARIOS_MOVIMIENTOS_TOMA_AJUSTE " & Compañia & ", " & cmbBODEGA.SelectedValue & ", " & Txt_Producto_codigo.Text & ", " & Txt_tipo_movimiento_numero.Text & ", 0, 0, '-',0, 0, '" & Usuario & "', 3", 0)
        End If
    End Sub


    Private Sub dgvMovtos_Aling()
        Me.dgvMovtos.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvMovtos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvMovtos.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub dgvMovtos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMovtos.Click
        Txt_Producto_codigo.Text = dgvMovtos.CurrentRow.Cells(0).Value.ToString()
        Txt_Producto_descripcion.Text = dgvMovtos.CurrentRow.Cells(1).Value.ToString()
        Txt_Exist_Fisicas.Text = dgvMovtos.CurrentRow.Cells(3).Value.ToString()
        Txt_Exist_Fisicas.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtFecheo.Text = "" Then
            Dim fecheo As New Seguridad_Pos_Ante_Fecheo(Me.cmbBODEGA.Text, Me.cmbBODEGA.SelectedValue, "Inventario_Ingreso_Fisico_y_Ajuste")
            fecheo.ShowDialog()
        Else
            Dim clave As String            
            clave = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Ingreso_Fisico_y_Ajuste', @BANDERA=3", 0)
            item = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Ingreso_Fisico_y_Ajuste', @BANDERA=3", 1)
            pos_ante = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Ingreso_Fisico_y_Ajuste', @BANDERA=3", 2)
            If Val(clave) = Val(Me.txtFecheo.Text) Then
                DateTimePicker1.Enabled = True
            Else
                DateTimePicker1.Enabled = False
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If pos_ante = "True" Then
            If DateTimePicker1.Value.Date < Date.Now.Date Then
                MsgBox("Imposible realizar un AnteFecheo porque usted solicito un PosFecheo", MsgBoxStyle.Exclamation)
                DateTimePicker1.Value = Date.Now
            End If
        Else
            If DateTimePicker1.Value.Date > Date.Now.Date Then
                MsgBox("Imposible realizar un PosFecheo porque usted solicito un AnteFecheo", MsgBoxStyle.Exclamation)
                DateTimePicker1.Value = Date.Now
            End If
        End If
    End Sub

    
End Class