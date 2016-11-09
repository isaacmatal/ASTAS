'Imports BioEnable.SDK.BioEnBSP
'Imports NITGEN.SDK.NBioBSP
Imports System.Data.SqlClient
Imports System

Public Class Cafeteria_Facturacion
    'Dim m_NBioAPI As New BioAPI
    'Dim m_IndexSearch As New BioAPI.IndexSearch(m_NBioAPI)
    Dim c_data2 As New jarsClass
    Dim c_data As New cmbFill
    Dim Iniciando As Boolean
    Dim codigo_as As String, codigo_buxi As String, codVtaContado As String
    Dim DS01, DS02, DS03 As New DataSet()
    Dim Bodega As Integer, Tiempo As Integer, Estado As String, Caja As String, descripcion_Caja As String
    Dim Resolucion As String, fecha_resolucion As String, fecha_autorizacion As String, del As String, al As String, descripcion_bodega As String
    Dim Movimiento As String, PRODUCTO1 As String, item As String, serie As String, fecha_aprovacion As String, tiempo_c As String, correlativo_Actual As String
    Dim SQL As String, COSTO_PROM As String, IVA As String, DESCUENTO As String, ORIGEN As String, TIPOX As String, cobrarx As Boolean = False
    Dim bandera As Boolean = False, bandera1 As Boolean = False, direccion As String, A As String, saldo As Double, DESCUX As String
    Dim TICKET As New GenerarTicket
    Dim PARTIDAS As New Facturacion_Procesos
    Dim listaTicket As New List(Of String)
    Dim BLOQUEADO As String = "0"
    Dim PRECIO_ESPECIAL As String = "0"
    Dim ban As Integer = 0
    Dim Table As DataTable
    Dim transferencia_activa As String, user1 As String, maquina As String, ventana As String
    Dim maximo As String
    Dim ACTUAL As String
    Dim NOTIFICACION As String
    Dim monto_maximo, LimiteSolic As Double
    Dim dedos As String() = {"Ninguno", "Pulgar Derecho", "Indice Derecho", "Medio Derecho", "Anular Derecho", "Meñique Derecho", "Pulgar Izquierdo", "Indice Izquierdo", "Medio Izquierdo", "Anular Izquierdo", "Meñique Izquierdo"}
    Dim TipoSoli, FPTimer As Integer
    Dim factor_ As Decimal
    Dim Planta, IDdedo As Integer
    Dim fecha_impresion_ As Date
    Dim forzar_efectivo_ As Boolean

    Private Sub Cafeteria_Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim ret As UInteger
        'If CInt(c_data2.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 16")) = 1 Then
        '    Try
        '        ret = m_IndexSearch.InitEngine()
        '        If ret <> NBioAPI.Error.NONE Then
        '            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) & " [" & ret.ToString() & "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '        cargaIndex()
        '    Catch ex As Exception
        '        c_data2.msjError(ex, "Lector Huella")
        '    End Try
        'End If
        forzar_efectivo_ = False
        FPTimer = c_data2.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 37")
        Dim tblDatosCaja As DataTable
        'Timer2.Enabled = False
        Iniciando = True
        'VERIFICAR APERTURA        
        dtpFechaTrabajo.Value = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @BANDERA=4", 0)
        tblDatosCaja = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "', @BANDERA=0"))
        If tblDatosCaja.Rows.Count() > 0 Then
            Estado = tblDatosCaja.Rows(0).Item(0)
            Bodega = tblDatosCaja.Rows(0).Item(2)
            Caja = tblDatosCaja.Rows(0).Item(4)
            Tiempo = tblDatosCaja.Rows(0).Item(3)
            tiempo_c = tblDatosCaja.Rows(0).Item(6)
            descripcion_bodega = tblDatosCaja.Rows(0).Item(7)
        Else
            Estado = String.Empty
            Bodega = 0
            Caja = String.Empty
            Tiempo = 0
            tiempo_c = String.Empty
            descripcion_bodega = String.Empty
        End If

        If Caja = Nothing Then
        Else
            direccion = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=1", 0)
        End If

        descripcion_Caja = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 6)

        txtCodigoCajero.Text = Usuario
        txtTiempoComida.Text = descripcion_Caja
        txtCaja.Text = Caja

        If Estado = Nothing Or Bodega = 0 Or Tiempo = 0 Or Caja = Nothing Then
            txtCantidad.Enabled = False
            btnReimprimir.Enabled = False
            btnCobrar.Enabled = False
            MsgBox("Aviso...No hay tiempo de comida aperturado!", MsgBoxStyle.Information)
            Return
        End If

        Planta = c_data2.obtenerEscalar("SELECT PLANTA FROM [dbo].[CAFETERIA_CATALOGO_BODEGA_CAJA] WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Bodega & " AND CAJA = " & Caja)
        If Planta = 1 Then
            TipoSoli = c_data2.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
        Else
            TipoSoli = c_data2.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
        End If

        LimiteSolic = c_data2.obtenerEscalar("SELECT MONTO_MAXIMO FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & TipoSoli)

        txtCodigoEmpleado.Focus()
        Me.ActiveControl = txtCodigoEmpleado

        maximo = c_data2.leerDataeader("SELECT CORRELATIVO_FINAL FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)
        ACTUAL = c_data2.leerDataeader("SELECT CORRELATIVO_ACTUAL FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)
        NOTIFICACION = c_data2.leerDataeader("SELECT CORRELATIVO_NOTIFICACION FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)

        If Val(ACTUAL) > Val(maximo) Then
            MsgBox("CORRELATIVO DE TICKETS AGOTADO!", MsgBoxStyle.Information)
            Me.Close()
        End If
        If Val(ACTUAL) >= Val(NOTIFICACION) Then
            lb_notificacion2.Visible = True
            lb_notificacion1.Visible = True
            lb_notificacion2.Text = Val(maximo - ACTUAL).ToString()
        Else
            lb_notificacion2.Visible = False
            lb_notificacion1.Visible = False
        End If
        Iniciando = False
    End Sub

    Public Function NumeroFactura()
        Dim permiso As Integer = 0
        'Forma de obtener datos de E.Gamez
        'serie = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=1", 0)
        'correlativo_Actual = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=1", 3)
        'Resolucion = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2", 0)
        'fecha_resolucion = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2", 1)
        'fecha_autorizacion = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2", 2)
        'del = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2", 3)
        'al = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2", 4)

        'nueva forma de hacer lo mismo pero haciendo una sola consulta al servidor
        Dim tblDatosApCie As DataTable = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2"))
        Dim tblDatosFact As DataTable = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=1"))
        serie = tblDatosFact.Rows(0).Item(0)
        correlativo_Actual = tblDatosFact.Rows(0).Item(3)
        txt_correlativo.Text = correlativo_Actual
        Resolucion = tblDatosApCie.Rows(0).Item(0)
        fecha_resolucion = tblDatosApCie.Rows(0).Item(1)
        fecha_autorizacion = tblDatosApCie.Rows(0).Item(2)
        del = tblDatosApCie.Rows(0).Item(3)
        al = tblDatosApCie.Rows(0).Item(4)
        permiso = 1
        If ((serie = Nothing) Or (serie = "")) Or ((correlativo_Actual = Nothing) Or (correlativo_Actual = "")) Or ((Resolucion = Nothing) Or (Resolucion = "")) Or ((fecha_resolucion = Nothing) Or (fecha_resolucion = "")) Or ((fecha_autorizacion = Nothing) Or (fecha_autorizacion = "")) Or ((Val(del) = Nothing) Or (del = "")) Or ((al = Nothing) Or (al = "")) Then
            permiso = 0
        End If

        Return permiso
    End Function
    Public Sub CargarFacturaAnterior()
        CargarGrid(SQL, DS01)
        dgvDetalleVenta.DataSource = DS01.Tables(0)
        c_data2.cerrarConexion()
    End Sub
    Public Sub CargarMenuDetalle()
        CargarDetalle(1)
        CargarGrid(SQL, DS02)
        dgvDetalleVenta.DataSource = DS02.Tables(0)
        c_data2.cerrarConexion()

        For i As Integer = 0 To 4
            dgvDetalleVenta.Columns.Item(i).Visible = False
        Next
        dgvDetalleVenta.Columns.Item(8).Visible = False
        dgvDetalleVenta.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleVenta.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleVenta.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleVenta.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleVenta.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        For i As Integer = 0 To dgvDetalleVenta.ColumnCount - 1
            dgvDetalleVenta.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

    End Sub

    Public Sub CargarGrid(ByVal cadena, ByVal ds)
        Try
            ds.Reset()
            c_data2.MiddleConnection(cadena)
            c_data2.DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar la grilla", MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub cadenaSIUD(ByVal CIA)
        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_CARGAR_BODEGAS_SIEMPRE] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA1 = " & Bodega
        SQL &= ",@BODEGA_PLATILOS = " & 19 'BODEGA PLATILLOS
        SQL &= ",@TIEMPO = " & Tiempo
        SQL &= ",@FECHA = '" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy") & "'"
        SQL &= ",@IVA = " & 13
    End Sub

    Public Sub Limpiar()
        TextBox2.Text = ""
        txtProducto.Text = ""
        txtDescripcion.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""
        txtTotal.Text = ""
        txtExistencias.Text = ""
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Limpiar()
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = "Cafeteria Productos Facturacion"
        Frm_Busqueda.TxtBodega_cod.Text = Bodega
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.txtProducto.Text = CodigoProducto
        'Descripcion
        Me.txtDescripcion.Text = Descripcion_Producto

        If txtDescripcion.Text = "" Then
            MsgBox("Aviso...Codigo No existe en esta bodega o no esta programado para este turno!", MsgBoxStyle.Information)
        Else
            If (txtCodigoEmpleado.Text = "") Then
                MsgBox("Aviso...Debe seleccionar el empleado", MsgBoxStyle.Information)
                txtCodigoEmpleado.Focus()
            Else
                If (txtProducto.Text = "") Then
                Else
                    txtExistencias.Text = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Bodega & "," & txtProducto.Text & ",'" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

                    Me.TextBox2.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @PRODUCTO=" & Me.txtProducto.Text & ", @BANDERA=1", 3)
                    If factor_ > 0 Then
                        If PRECIO_ESPECIAL <> "True" Then
                            txtPrecio.Text = Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0)) * factor_
                        Else
                            txtPrecio.Text = Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0))
                        End If
                    Else
                        txtPrecio.Text = Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0))
                    End If
                    Me.txtCantidad.Text = "1"
                    Me.txtCantidad.Focus()
                End If


            End If

        End If
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress

    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        If (e.KeyChar = "") Then
            TextBox2.Focus()
        End If
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
            'RETROCESO
        Else

            e.Handled = True
            txtCantidad.Text = ""

        End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.rbCredito.Checked Then
                If Val(txtTotalPagar.Text) + (Val(Me.txtPrecio.Text) * Val(Me.txtCantidad.Text)) > monto_maximo And LimiteSolic > 0 Then
                    MsgBox("LIMITE DE CREDITO EXCEDIDO.", MsgBoxStyle.Information, "Facturación")
                    Limpiar()
                    Return
                End If
            End If
            maximo = c_data2.leerDataeader("SELECT CORRELATIVO_FINAL FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)
            ACTUAL = c_data2.leerDataeader("SELECT CORRELATIVO_ACTUAL FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)

            If Val(ACTUAL) > Val(maximo) Then
                MsgBox("CORRELATIVO DE TICKETS AGOTADO!", MsgBoxStyle.Information)
                Me.Close()
            End If

            NOTIFICACION = c_data2.leerDataeader("SELECT CORRELATIVO_NOTIFICACION FROM CAFETERIA_CATALOGO_BODEGA_CAJA_CORRELATIVO WHERE BODEGA=" & Bodega & " AND ACTIVA=1 AND CAJA=" & Caja, 0)
            If Val(ACTUAL) >= Val(NOTIFICACION) Then
                lb_notificacion2.Visible = True
                lb_notificacion1.Visible = True
                lb_notificacion2.Text = Val(maximo - ACTUAL).ToString()
            Else
                lb_notificacion2.Visible = False
                lb_notificacion1.Visible = False
            End If

            If txtCantidad.Text = "" Or txtCantidad.Text = "0" Then
                MsgBox("Aviso...DEBE INGRESAR UNA CANTIDAD", MsgBoxStyle.Information)
            Else
                If (Val(txtCantidad.Text) <= Val(txtExistencias.Text)) Then

                    If (txtCantidad.Text >= 5) Then
                        If MsgBox("AVISO...SE ESTAN FACTURANDO " & txtCantidad.Text & " " & txtDescripcion.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    If ((Me.dgvDetalleVenta.RowCount = 0)) Then
                        'CALCULA EL NUMERO DE MOVIMIENTO SIGUIENTE                   
                        NumeroMovimiento()
                    End If

                    COSTO_PROM = c_data2.leerDataeader("Exec sp_CAFETERIA_CALCULAR_COSTO_PLATO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@PRODUCTO=" & txtProducto.Text & ",@TIEMPO=" & Tiempo & ",@FECHA='" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "'", 0)

                    'SE RELLENA LA CADENA DE INGRESO DE LOS MOVIMIENTOS
                    cadenaSIUDMovimientos("I", 0)

                    'SE EJECUTA EL MOVIMIENTO
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                    'SE RELLENA LA CADENA DE INGRESO DE TABLA TEMPORAL
                    CargarDetalle(4)

                    'SE EJECUTA EL INGRESO
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                    'SE CARGA EL DETALLE DE LA FACTURA
                    CargarMenuDetalle()

                    'SE ACTUALIZA EL MONTO TOTAL VISTO POR EL USUARIO
                    txtTotalPagar.Text = IIf(txtTotalPagar.Text = "", 0, txtTotalPagar.Text) + (Me.txtPrecio.Text * Me.txtCantidad.Text)
                    txtTotalPagar.Text = Format(Math.Round(Val(txtTotalPagar.Text), 2), "0.00")
                    If Me.rbCredito.Checked Then
                        Me.txtDisponible.Text = Format(monto_maximo - Val(Me.txtTotalPagar.Text), "0.00")
                        If Val(Me.txtDisponible.Text) < 2 Then
                            Me.txtDisponible.ForeColor = Color.Red
                        End If
                    End If
                    Limpiar()
                    'FOCALIZA AL TEXT DE CODIGO
                    TextBox2.Focus()
                    NumeroFactura()
                Else
                    MsgBox("AVISO...EL PRODUCTO NO ESTA DISPONIBLE PARA ESTE TIEMPO DE COMIDA!!!", MsgBoxStyle.Information)
                End If
            End If

        End If
    End Sub
    Public Sub EliminarDetalle(ByVal SIUD, ByVal producto2, ByVal item)
        SQL = "Execute [sp_CAFETERIA_FACTURACION_TEMPORAL_SIUD] "
        SQL &= "@ITEM = " & item
        SQL &= ",@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@CAJA = " & txtCaja.Text
        SQL &= ",@FECHA = N'" & Format(Me.dtpFechaTrabajo.Value, "dd/MM/yyyy 00:00:00") & "'"
        SQL &= ",@PRODUCTO = " & producto2
        SQL &= ",@CANTIDAD = 0"
        SQL &= ",@COSTO_UNITARIO = 0"
        SQL &= ",@PRECIO_UNITARIO = 0"
        SQL &= ",@BANDERA = " & SIUD
    End Sub
    Public Sub CargarDetalle(ByVal SIUD)
        SQL = "Execute [sp_CAFETERIA_FACTURACION_TEMPORAL_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@CAJA = " & txtCaja.Text
        SQL &= ",@FECHA = N'" & Me.dtpFechaTrabajo.Text & "'"
        SQL &= ",@PRODUCTO = " & IIf(txtProducto.Text = "", 0, txtProducto.Text)
        SQL &= ",@CANTIDAD = " & IIf(Me.txtCantidad.Text = "", 0, txtCantidad.Text)
        SQL &= ",@COSTO_UNITARIO = " & IIf(COSTO_PROM = "", 0, COSTO_PROM)
        SQL &= ",@PRECIO_UNITARIO = " & IIf(txtPrecio.Text = "", 0, txtPrecio.Text)
        SQL &= ",@BANDERA = " & SIUD
    End Sub

    Public Sub NumeroMovimiento()
        Movimiento = c_data2.leerDataeader("SELECT ISNULL(MAX(MOVIMIENTO),0)+1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND TIPO_MOVIMIENTO=2", 0)
    End Sub
    Public Sub EliminarDetalleTemporal(ByVal SIUD, ByVal producto2)
        If (bandera1 = True) Then
            Movimiento = dgvDetalleVenta.Rows(0).Cells(22).Value.ToString()
        End If
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@TIPO_MOVIMIENTO = 2"
        SQL &= ",@MOV = " & Movimiento
        SQL &= ",@PRODUCTO = " & Val(producto2)
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'" & SIUD & "'"
    End Sub
    Public Sub cadenaSIUDMovimientos(ByVal SIUD, ByVal in_out)
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@PROVEEDOR = 0"
        SQL &= ",@TIPO_MOVIMIENTO = 2"
        SQL &= ",@MOV = " & Movimiento
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 1"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@FECHA_MOVIMIENTO = N'" & Format(Me.dtpFechaTrabajo.Value, "dd/MM/yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & Val(Me.txtProducto.Text)
        SQL &= ",@CANTIDAD = " & Val(Me.txtCantidad.Text)
        SQL &= ",@COSTO_UNIDAD = " & COSTO_PROM
        SQL &= ",@COSTO_TOTAL = " & IIf(COSTO_PROM = "", 0, Val((COSTO_PROM * Val(txtCantidad.Text))))
        SQL &= ",@ENTRADA_SALIDA = " & in_out
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'" & SIUD & "'"
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtPrecio.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtPrecio.Text = ""
                Else
                    e.Handled = txtPrecio.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtPrecio.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtTotal.Focus()
        End If
    End Sub
    Private Sub txtCodigoEmpleado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoEmpleado.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)))) Then
            e.Handled = False
        Else
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
                'leerBarra()  
                'SendKeys.Send("{TAB}")
                Me.TextBox2.Focus()
            Else
                txtCodigoEmpleado.Text = ""
                txtNombreEmpleado.Text = ""
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnEliminarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarProducto.Click

        If Me.txtComentario.Text.Length = 0 Then
            MsgBox("Debe ingresar un motivo de anulación", MsgBoxStyle.Information, "Facturación")
            Return
        End If
        Dim _SQL As String = "Execute sp_CAFETERIA_PERMISOS_TICKETS @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @NUMEROTKT= " & txtNumTicket.Text.Trim() & ", @USUARIO='" & Usuario & "', @BANDERA = 'S'"
        Dim result_ As String = c_data2.leerDataeader(_SQL, 0)

        If result_.Equals("True") Then
            If (bandera1 = False) Then
                If (item <> "" And PRODUCTO1 <> "") Then
                    'SE RELLENA LA CADENA DE ELIMINACION DE MOVIMIENTO
                    EliminarDetalleTemporal("DD", PRODUCTO1)

                    'SE EJECUTA LA ELIMINACION
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                    'SE RELLENA LA CADENA DE ELIMINACION DE TABLA TEMPORAL
                    EliminarDetalle(2, PRODUCTO1, item)

                    'SE EJECUTA LA ELIMINACION
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                    'SE CARGA EL DETALLE DE LA FACTURA
                    CargarMenuDetalle()

                    'RECALCULA EL TOTAL
                    txtTotalPagar.Text = "0.0"
                    For i As Integer = 0 To dgvDetalleVenta.RowCount - 1
                        txtTotalPagar.Text = (Val(dgvDetalleVenta.Rows(i).Cells(10).Value.ToString()) + Val(txtTotalPagar.Text)).ToString()
                    Next

                End If

                item = ""
                PRODUCTO1 = ""
                Me.txtComentario.Visible = False
                Me.lblEtiquetaAnulado.Visible = False

            Else
                'ELIMINA TODO EL TICKET
                'pendiente
                Dim respuesta As MsgBoxResult
                respuesta = MsgBox("Desea eliminar el Ticket?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                If respuesta = MsgBoxResult.Yes Then

                    'VALIDA SI EL TICKET YA FUE ANULADO
                    If Val(dgvDetalleVenta.Rows(0).Cells(11).Value.ToString()) = 1 Then
                        MsgBox("Aviso...El Ticket ya fue anulado!", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    'ESTABLECE EN ANULADO=1 Y REGRESA LOS PRODUCTOS AL INVENTARIO
                    If GuardarFacturaNegativa1(dgvDetalleVenta.Rows(0).Cells(2).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(3).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(12).Value, dgvDetalleVenta.Rows(0).Cells(13).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(14).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(15).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(16).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(17).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(18).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(19).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(20).Value.ToString(), dgvDetalleVenta.Rows(0).Cells(5).Value.ToString()) Then
                        If (cobrarx = False) Then
                            Dim tipo_impresor As String
                            tipo_impresor = c_data2.leerDataeader("execute sp_TIPO_IMPRESOR @COMPAÑIA=" & Compañia & ", @BODEGA= " & Bodega & ",@CAJA=" & Caja, 0)
                            If tipo_impresor = "False" Then
                                GuardarTicketAnulado()
                            Else
                                GuardarTicketFiscalAnulado()
                            End If
                        Else
                            MsgBox("Aviso!", MsgBoxStyle.Information)
                        End If

                        'SE CARGA EL DETALLE DE LA FACTURA
                        CargarMenuDetalle()

                        MsgBox("Aviso...Se ha anulado el Ticket con exito!", MsgBoxStyle.Information)
                    End If
                End If
            End If
            btnNuevo.PerformClick()
        Else
            MsgBox("No tiene permiso de Anular este Ticket!" & vbCrLf & "Comuniquese con Contabilidad de ASTAS", MsgBoxStyle.Information)
        End If


    End Sub
    Public Function GuardarFacturaNegativa1(ByVal SERIE1, ByVal NUMERO_FACTURA1, ByVal FECHA1, ByVal TIEMPO1, ByVal CAJA1, ByVal CODIGO_EMPLEADO1, ByVal FORMA_PAGO1, ByVal IVA1, ByVal DESCUENTO1, ByVal MONTO1, ByVal ORIGEN1, ByVal PRODUCTO2) As Boolean
        correlativo_Actual = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & CAJA1 & ",@BANDERA=1", 3)

        Dim result_ As String
        SQL = "Execute sp_CAFETERIA_ANULACION_TICKET @COMPAÑIA =" & Compañia & ", @BODEGA=" & Bodega & ", @SERIE='" & SERIE1 & "', @NUMERO_FACTURA=" & NUMERO_FACTURA1 & ", @MOV=" & dgvDetalleVenta.Rows(0).Cells(22).Value.ToString() & ", @FECHA_='" & Format(dtpFechaTrabajo.Value, "dd/MM/yyyy") & "'"
        If Me.txtComentario.Text.Length > 0 Then
            SQL += ", @COMENTARIO='" & txtComentario.Text.Trim() & "'"
        End If
        result_ = c_data2.leerDataeader(SQL, 0)
        If result_.Equals("EXITO") Then
            GuardarFacturaNegativa1 = True
            c_data2.leerDataeader("Execute sp_CAFETERIA_PERMISOS_TICKETS @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @NUMEROTKT= " & txtNumTicket.Text.Trim() & ", @USUARIO='" & Usuario & "', @BANDERA = 'A'", 0)
        Else
            GuardarFacturaNegativa1 = False
            MsgBox(result_, MsgBoxStyle.Information)
        End If

    End Function

    Public Sub GuardarFacturaNegativa(ByVal SERIE1, ByVal NUMERO_FACTURA1, ByVal FECHA1, ByVal TIEMPO1, ByVal CAJA1, ByVal CODIGO_EMPLEADO1, ByVal FORMA_PAGO1, ByVal IVA1, ByVal DESCUENTO1, ByVal MONTO1, ByVal ORIGEN1, ByVal PRODUCTO2)
        correlativo_Actual = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & CAJA1 & ",@BANDERA=1", 3)

        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@SERIE = '" & SERIE1 & "'"
        SQL &= ",@NUMERO_FACTURA = " & NUMERO_FACTURA1
        SQL &= ",@TIEMPO = " & TIEMPO1
        SQL &= ",@CAJA = " & CAJA1
        SQL &= ",@CODIGO_EMPLEADO = " & CODIGO_EMPLEADO1
        SQL &= ",@ANULADO = 1"
        SQL &= ",@FORMA_PAGO = " & FORMA_PAGO1
        SQL &= ",@IVA = " & IVA1 'JNJN
        SQL &= ",@DEUDA = " & DESCUENTO1 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
        SQL &= ",@MONTO = " & MONTO1
        SQL &= ",@TIPO_DOCUMENTO = 27" 'TICKET DE CAJA DEFINIDO EN CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO
        SQL &= ",@ORIGEN = " & ORIGEN1
        SQL &= ",@PROCESADO = 1"
        SQL &= ",@USUARIO_CREACION = '" & Usuario & "'"
        SQL &= ",@BANDERA = 'U'"
        SQL &= ",@PRODUCTO = " & PRODUCTO2
        SQL &= ",@CANTIDAD = 0"
        SQL &= ",@COSTO_UNITARIO = 0"
        SQL &= ",@PRECIO_UNITARIO = 0"
        SQL &= ",@PRECIO_TOTAL = 0"
        SQL &= ",@TIPO_MOV = 2"
        SQL &= ",@MOV = " & dgvDetalleVenta.Rows(0).Cells(22).Value.ToString()
        c_data2.Ejecutar_ConsultaSQL(SQL)
    End Sub
    Public Sub obtenerDatosFacturacionCaja()
        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_OBTENER_SERIE] "
        SQL &= ",@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@CAJA = " & txtCaja.Text
        SQL &= ",@BANDERA = 1"
    End Sub
    Public Sub GuardarFactura(ByVal PRODUCTO2, ByVal CANTIDAD, ByVal COSTO_UNI, ByVal PRECIO_UNITARIO)
        Dim forma_pago As String
        If (Me.rbCredito.Checked = True) Then
            forma_pago = "2" 'CREDITO
        Else
            forma_pago = "1" 'CONTADO
        End If

        IVA = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=2", 0)
        'DESCUENTO = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@COD_EMPLEADO_AS='" & codigo_as & "',@COD_EMPLEADO=" & txtCodigoEmpleado.Text & ", @BANDERA=7", 0)

        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@SERIE = '" & serie & "'"
        SQL &= ",@NUMERO_FACTURA = " & correlativo_Actual
        SQL &= ",@FECHA = N'" & Me.dtpFechaTrabajo.Text & "'"
        SQL &= ",@TIEMPO = " & Tiempo
        SQL &= ",@CAJA = " & Me.txtCaja.Text
        SQL &= ",@CODIGO_EMPLEADO = " & codigo_buxi
        SQL &= ",@CODIGO_EMPLEADO_AS = '" & codigo_as.PadLeft(6, "0") & "'"
        SQL &= ",@ANULADO = 0"
        SQL &= ",@FORMA_PAGO = " & forma_pago
        Dim ivax As String = ((Val(DESCUENTO) + Val(txtTotalPagar.Text)) * (Val(IVA) / 100)).ToString()
        SQL &= ",@IVA = " & ivax 'JNJN
        If (rbEfectivo.Checked = True) Then
            SQL &= ",@DEUDA = " & Me.DESCUENTO 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            SQL &= ",@MONTO = " & txtTotalPagar.Text
        Else
            SQL &= ",@DEUDA = " & Me.DESCUENTO 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            SQL &= ",@MONTO = " & txtTotalPagar.Text
        End If

        SQL &= ",@TIPO_DOCUMENTO = 27" 'TICKET DE CAJA DEFINIDO EN CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO
        SQL &= ",@ORIGEN = " & ORIGEN
        SQL &= ",@PROCESADO = 0"
        SQL &= ",@USUARIO_CREACION = '" & Usuario & "'"
        SQL &= ",@BANDERA = 'I'"
        SQL &= ",@PRODUCTO = " & PRODUCTO2
        SQL &= ",@CANTIDAD = " & CANTIDAD
        SQL &= ",@COSTO_UNITARIO = " & COSTO_UNI
        SQL &= ",@PRECIO_UNITARIO = " & PRECIO_UNITARIO
        SQL &= ",@PRECIO_TOTAL = " & CANTIDAD * PRECIO_UNITARIO
        SQL &= ",@TIPO_MOV = " & 2
        SQL &= ",@MOV = " & Movimiento
        SQL &= ",@SERIECOMPLETA = '" & serie & "'"

        c_data2.Ejecutar_ConsultaSQL(SQL)

        If codigo_buxi = "1" Then
            SQL = "UPDATE CAFETERIA_FACTURACION_ENCABEZADO SET COMENTARIO = 'CODIGO: " & codVtaContado & " " & Me.txtNombreEmpleado.Tag & "'" & vbCrLf
            SQL &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            SQL &= "   AND BODEGA = " & Bodega & vbCrLf
            SQL &= "   AND SERIE_COMPLETA = '" & serie.Trim & "'" & vbCrLf
            SQL &= "   AND NUMERO_FACTURA = " & correlativo_Actual & vbCrLf
            SQL &= "   AND FECHA_FACTURA = '" & Me.dtpFechaTrabajo.Text & "'" & vbCrLf
            c_data2.ejecutarComandoSql(New SqlCommand(SQL))
            'Else
            '    SQL = "UPDATE CAFETERIA_FACTURACION_ENCABEZADO SET PROCESADO = 1, COMENTARIO = 'EMPLEADO: " & Me.txtCodigoEmpleado.Text & " " & Me.txtNombreEmpleado.Text & " IDENTIFICADO " & IIf(IDdedo = 0, "CON CODIGO", "CON HUELLA (" & dedos(IDdedo) & ")") & "'" & vbCrLf
            '    SQL &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            '    SQL &= "   AND BODEGA = " & Bodega & vbCrLf
            '    SQL &= "   AND SERIE_COMPLETA = '" & serie.Trim & "'" & vbCrLf
            '    SQL &= "   AND NUMERO_FACTURA = " & correlativo_Actual & vbCrLf
            '    SQL &= "   AND FECHA_FACTURA = '" & Me.dtpFechaTrabajo.Text & "'" & vbCrLf
            '    c_data2.ejecutarComandoSql(New SqlCommand(SQL))
        End If
    End Sub

    Public Sub ActualizarEncabezadoFactura()
        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@SERIE = '" & serie & "'"
        SQL &= ",@NUMERO_FACTURA = " & correlativo_Actual
        SQL &= ",@FECHA = N'" & Me.dtpFechaTrabajo.Text & "'"
        SQL &= ",@IVA = " & (Val(A) * (Val(IVA) / 100)).ToString() 'JNJN

        If (rbEfectivo.Checked = True) Then
            SQL &= ",@DEUDA = " & Me.DESCUENTO 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            SQL &= ",@MONTO = " & txtTotalPagar.Text
        Else
            SQL &= ",@DEUDA = " & Me.DESCUENTO 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            SQL &= ",@MONTO = " & txtTotalPagar.Text
        End If

        SQL &= ",@BANDERA = 'U1'"
        SQL &= ",@SERIECOMPLETA = '" & serie & "'"
    End Sub

    Private Sub dgvDetalleVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalleVenta.Click
        Try
            txtProducto.Text = PRODUCTO1
            txtDescripcion.Text = ""

            PRODUCTO1 = dgvDetalleVenta.CurrentRow.Cells(5).Value.ToString()
            item = dgvDetalleVenta.CurrentRow.Cells(0).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ProcesarMovimientosInv()
        SQL = "EXECUTE sp_INVENTARIOS_MOVIMIENTO_SIUD "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@MOV1 = " & Movimiento
        SQL &= ",@MOV = " & correlativo_Actual
        SQL &= ",@SIUD = 'U2'"
    End Sub

    Private Sub btnCobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobrar.Click
        Dim barrido As String, sumatoria As String ', tipoSolicitud As String, numeroSolicitud As Integer
        Dim tblEstadoCaja As DataTable
        tblEstadoCaja = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0"))
        If tblEstadoCaja.Rows.Count = 0 Then
            txtCantidad.Enabled = False
            btnReimprimir.Enabled = False
            btnCobrar.Enabled = False
            MsgBox("La caja ya fue cerrada", MsgBoxStyle.Critical, "CERRADO")
            Return
        End If
        If dgvDetalleVenta.Rows.Count = 0 Then
            Exit Sub
        Else
            Try
                'CALCULA EL NUMERO DE FACTURA SIGUIENTE
                If NumeroFactura() = 0 Then
                    MsgBox("Aviso...Verifique los permisos Legales para que esta caja facture!", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'ESTABLECE LOS MOVIMIENTOS DE INVENTARIOS EN PROCESADOS Y GUARDA EL NUMERO DE FACTURA
                ProcesarMovimientosInv()

                c_data2.Ejecutar_ConsultaSQL(SQL)
                Dim precio As Double, total As Double, cantidad As Double, descrip As String

                barrido = "0.0"
                DESCUX = 0
                A = txtTotalPagar.Text
                sumatoria = "0.0"
                saldo = "0.0"
                DESCUENTO = "0.0"

                Dim Cobro As New Cafeteria_Cobro(txtTotalPagar.Text)
                Cobro.ShowDialog()

                If Cobrar = 0 Then
                    Exit Sub
                End If
                'CREA EL TICKET
                For i As Integer = 0 To dgvDetalleVenta.RowCount - 1

                    'producto/cantidad/costo unitario/precio unitario
                    GuardarFactura(dgvDetalleVenta.Rows(i).Cells(5).Value.ToString(), dgvDetalleVenta.Rows(i).Cells(7).Value.ToString(), dgvDetalleVenta.Rows(i).Cells(8).Value.ToString(), dgvDetalleVenta.Rows(i).Cells(9).Value.ToString())

                    precio = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(9).Value.ToString()), 2)

                    total = Math.Round(Convert.ToDouble((dgvDetalleVenta.Rows(i).Cells(9).Value.ToString() * dgvDetalleVenta.Rows(i).Cells(7).Value.ToString()).ToString.Trim()), 2)

                    cantidad = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(7).Value.ToString().Trim()))

                    descrip = dgvDetalleVenta.Rows(i).Cells(6).Value.ToString()

                    If descrip.Length > 17 Then
                        descrip = descrip.Substring(0, 17)
                    End If
                    listaTicket.Add(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(16, " ") & " " & precio.ToString("0.00").PadLeft(6, " ") & " " & total.ToString("0.00").PadLeft(6, " "))
                Next

                'ACTUALIZA EL MONTO TOTAL DE LA VENTA, DESCUENTO E IVA            
                ActualizarEncabezadoFactura()
                c_data2.Ejecutar_ConsultaSQL(SQL)
                'SE ACTUALIZA EL MONTO MAXIMO DE CONSUMO SI EL EMPLEADO ESTA EN CONDICION DE CONSUMO RESTRINGIDO
                If BLOQUEADO <> "False" Then
                    If Me.txtMotivoBloqueo.Visible Then
                        SQL = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS_IUD]" & vbCrLf
                        SQL &= " @COMPAÑIA        = " & Compañia & vbCrLf
                        SQL &= ",@CODIGO_EMPLEADO = " & Me.txtCodigoEmpleado.Text & vbCrLf
                        SQL &= ",@SOLICITUD       = " & TipoSoli & vbCrLf
                        SQL &= ",@LIMITE_APROBADO = " & Val(Me.txtDisponible.Text) & vbCrLf
                        SQL &= ",@MOTIVO          = '" & Me.txtMotivoBloqueo.Text & "'" & vbCrLf
                        SQL &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
                        SQL &= ",@MODIFICADO      = 1" & vbCrLf
                        SQL &= ",@IUD             = 'I'" & vbCrLf
                        c_data2.Ejecutar_ConsultaSQL(SQL)
                    Else
                        SQL = "UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
                        SQL &= "   SET [MONTO_MAXIMO] = [MONTO_MAXIMO] - " & Me.txtTotalPagar.Text & vbCrLf
                        SQL &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
                        SQL &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
                        SQL &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                        SQL &= "   AND CODIGO_EMPLEADO = " & txtCodigoEmpleado.Text & vbCrLf
                        SQL &= "   AND SOLICITUD = " & TipoSoli & vbCrLf
                        SQL &= "   AND EXCEDER_LIMITE = 0" & vbCrLf
                        c_data2.Ejecutar_ConsultaSQL(SQL)
                    End If
                End If

                Imprimir()

                'ELIMINA EL DETALLE DE LA TABLA TEMPORAL
                For i As Integer = 0 To dgvDetalleVenta.RowCount - 1

                    EliminarDetalle(2, dgvDetalleVenta.Rows(i).Cells(5).Value.ToString(), dgvDetalleVenta.Rows(i).Cells(0).Value.ToString())

                    'SE EJECUTA LA ELIMINACION
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                Next

                'SE CARGA EL DETALLE DE LA FACTURA, INCREMENTA EL CORRELATIVO, ACTUALIZA LA TABLA DE CORRELATIVOS
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=4")

                CargarMenuDetalle()

                'NumeroFactura()
                Contraseña_Cafeteria = ""
                btnCobrar.Enabled = False


                limpiar_Cliente()
                txtCodigoEmpleado.Focus()

                cobrarx = True
                listaTicket.Clear()
                'CargarMenuDia()
                btnNuevo.PerformClick()

            Catch ex As Exception
                MsgBox("Aviso...NO se ha procesado su factura", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Public Sub limpiar_Cliente()
        txtCodigoEmpleado.Text = ""
        txtNombreEmpleado.Text = ""
        txtTotalPagar.Text = "0.0"
    End Sub

    Public Sub Bloquear_Desbloquear(ByVal true_false)
        txtProducto.Enabled = true_false
        txtDescripcion.Enabled = true_false
        txtCantidad.Enabled = true_false
        btnCobrar.Enabled = true_false
        txtNumTicket.Enabled = true_false
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim tblDatosFact As DataTable
        If (dgvDetalleVenta.RowCount <= 0) Then
            Try
                If txtNumTicket.Text = "" Then
                Else
                    bandera1 = True
                    Me.lblEtiquetaAnulado.Visible = True
                    Me.txtComentario.Visible = True

                    CargarGrid("EXECUTE [dbo].[sp_CAFETERIA_FACTURACION_OBTENER_SERIE] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ",@CAJA=" & txtCaja.Text & ",@NUMERO_FACTURA=" & txtNumTicket.Text & ", @BANDERA=5", DS02)
                    dgvDetalleVenta.DataSource = DS02.Tables(0)
                    If dgvDetalleVenta.RowCount > 0 Then
                        Bloquear_Desbloquear(False)
                    End If
                    dgvDetalleVenta.Columns.Item(0).Visible = False
                    dgvDetalleVenta.Columns.Item(1).Visible = False
                    dgvDetalleVenta.Columns.Item(2).Visible = False
                    dgvDetalleVenta.Columns.Item(3).Visible = False

                    txtNombreEmpleado.Text = dgvDetalleVenta.Rows(0).Cells(24).Value.ToString()
                    txtCodigoEmpleado.Text = dgvDetalleVenta.Rows(0).Cells(23).Value.ToString()
                    If DS02.Tables(0).Rows(0).Item("FORMA_PAGO") = 2 Then
                        Me.rbCredito.Checked = True
                    Else
                        Me.rbEfectivo.Checked = True
                    End If
                    'CALCULA LOS TOTALES DEL TICKET A ANULAR
                    txtTotalPagar.Text = "0.00"
                    For i As Integer = 0 To dgvDetalleVenta.RowCount - 1
                        txtTotalPagar.Text = Format(Val(txtTotalPagar.Text) + Val(dgvDetalleVenta.Rows(i).Cells(10).Value), "0.00")
                    Next

                    serie = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=1", 0)
                    tblDatosFact = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=2"))
                    Resolucion = tblDatosFact.Rows(0).Item(0)
                    fecha_resolucion = tblDatosFact.Rows(0).Item(1)
                    fecha_autorizacion = tblDatosFact.Rows(0).Item(2)
                    del = tblDatosFact.Rows(0).Item(3)
                    al = tblDatosFact.Rows(0).Item(4)
                    txt_correlativo.Text = txtNumTicket.Text
                    Me.txtComentario.Text = c_data2.leerDataeader("SELECT COMENTARIO FROM dbo.CAFETERIA_FACTURACION_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND SERIE_COMPLETA='" & serie & "' AND NUMERO_FACTURA=" & txtNumTicket.Text & " AND CAJA=" & Caja, 0)
                End If
            Catch ex As Exception
                MsgBox("Aviso...El numero de la factura no coincide con ninguno en la base!", MsgBoxStyle.Information)
            End Try
        Else
            MsgBox("Aviso...Debe termina la operacion iniciada!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtNumTicket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumTicket.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnCargar.PerformClick()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.txtComentario.Visible = False
        Me.lblEtiquetaAnulado.Visible = False
        Me.txtMotivoBloqueo.Visible = False
        txtCodigoEmpleado.Text = ""
        txtNombreEmpleado.Text = ""
        txtProducto.Text = ""
        txtDescripcion.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""
        txtTotal.Text = ""
        txtExistencias.Text = ""
        txtTotalPagar.Text = ""
        TextBox2.Text = ""
        txt_correlativo.Text = ""
        txtDisponible.Text = "0.00"
        Me.txtDisponible.ForeColor = Color.Black
        txtCodigoEmpleado.Focus()
        Me.lblDispoCred.Visible = False
        Me.txtDisponible.Visible = False
        Label5.Text = ""
        IDdedo = 0
        If (bandera1 = False) Then
            For i As Integer = 0 To dgvDetalleVenta.RowCount - 1

                PRODUCTO1 = dgvDetalleVenta.Rows(i).Cells(5).Value.ToString()

                item = dgvDetalleVenta.Rows(i).Cells(0).Value.ToString()

                If (item <> "" And PRODUCTO1 <> "") Then

                    'SE RELLENA LA CADENA DE ELIMINACION DE MOVIMIENTO
                    EliminarDetalleTemporal("DD", PRODUCTO1)

                    'SE EJECUTA LA ELIMINACION
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                    'SE RELLENA LA CADENA DE ELIMINACION DE TABLA TEMPORAL
                    EliminarDetalle(2, PRODUCTO1, item)

                    'SE EJECUTA LA ELIMINACION
                    c_data2.Ejecutar_ConsultaSQL(SQL)

                End If
            Next

        End If

        'SE CARGA EL DETALLE DE LA FACTURA
        CargarMenuDetalle()

        If (bandera1 = True) Then
            Bloquear_Desbloquear(True)
            dgvDetalleVenta.DataSource = Nothing
            btnCobrar.Enabled = True
            bandera1 = False
            txtNumTicket.Text = ""
            txtCodigoEmpleado.Text = ""
            txtNombreEmpleado.Text = ""

            txtCodigoEmpleado.Focus()
        Else

            cobrarx = False
            btnCobrar.Enabled = True
        End If
        'Me.btnHuella.PerformClick()
    End Sub

    Private Sub btnPassw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassw.Click
        'Dim myValue As String = InputBox("Ingrese la contraseña", "Descuento Empleado")
        If ((Bodega = 0) Or (Me.Caja = "")) Then
            MsgBox("Aviso...La caja no ha sido aperturada", MsgBoxStyle.Information)
        Else
            If (dgvDetalleVenta.RowCount = 0) Then
                MsgBox("Aviso...Debe tener producto agregado en la bandeja!", MsgBoxStyle.Information)
            Else
                Dim Facturacion_Contraseña As New Cafeteria_Facturacion_Contraseña(Compañia, Bodega, Me.Caja)
                Facturacion_Contraseña.ShowDialog()
            End If
        End If
    End Sub

    Private Function getRegisterDate() As String
        Dim cadena_ As String = "SELECT USUARIO_CREACION_FECHA FROM [dbo].[CAFETERIA_FACTURACION_ENCABEZADO] WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA =" & txt_correlativo.Text.Trim() & " AND SERIE = '" & serie.Substring(0, 3) & "' AND BODEGA = " & Bodega & " AND CAJA = " & Caja

        fecha_impresion_ = c_data2.obtenerEscalar(cadena_)
        getRegisterDate = Format(fecha_impresion_, "dd/MM/yyyy") & " " & Format(fecha_impresion_, "hh:mm:ss tt")
    End Function

    Private Function getFormaPago() As Integer
        Dim cadena_ As String = "SELECT FORMA_PAGO FROM [dbo].[CAFETERIA_FACTURACION_ENCABEZADO] WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA =" & txt_correlativo.Text.Trim() & " AND SERIE = '" & serie.Substring(0, 3) & "' AND BODEGA = " & Bodega & " AND CAJA = " & Caja
        getFormaPago = c_data2.obtenerEscalar(cadena_)
    End Function

    Public Sub GuardarTicket()

        Dim intTamnio As Integer = direccion.Trim.Length - 8

        Dim strTipo As String
        If (rbEfectivo.Checked = True) Then
            strTipo = "C O N T A D O"
        Else
            strTipo = "C R E D I T O"
        End If
        TICKET.AbrirArchivo()
        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7))
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio))
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("TICKET # " & correlativo_Actual & " " & descripcion_bodega & " CAJA No." & Caja)
        'TICKET.EscribirTicket("FECHA   :" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & " " & Date.Now.Hour & ":" & Date.Now.Minute)
        TICKET.EscribirTicket("FECHA   :" & getRegisterDate())
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("RESOLUCION: " & Me.Resolucion)
        TICKET.EscribirTicket("FECHA DE RESOLUCION: " & Format(Me.fecha_resolucion, "Short Date"))
        TICKET.EscribirTicket("AUTORIZADA: " & Format(Me.fecha_autorizacion, "Short Date"))
        TICKET.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        TICKET.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("CODIGO C:" & txtCodigoEmpleado.Text & "   " & strTipo)
        TICKET.EscribirTicket("CLIENTE :" & txtNombreEmpleado.Text)
        TICKET.EscribirTicket("TIEMPO C:" & tiempo_c)
        TICKET.EscribirTicket("---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicket("CANT " & ("PRODUCTO").PadRight(20, " ") & "P/U  PREC.T")

        For i As Integer = 0 To listaTicket.Count - 1
            TICKET.EscribirTicket(listaTicket.Item(i).Trim)
        Next
        TICKET.EscribirTicket("")
        Dim total As Double, descuento1 As Double, gravada As Double

        gravada = Convert.ToDouble(txtTotalPagar.Text)
        descuento1 = Convert.ToDouble(Me.DESCUENTO)

        If (rbEfectivo.Checked = True) Then
            total = Val(txtTotalPagar.Text)
        Else
            'CREDITO 
            total = Val(A)
        End If
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket(("SUBTT. VTA. GRAVADA $:").PadRight(23, " ") & total.ToString("0.00").PadLeft(13, " "))
        TICKET.EscribirTicket(("SUBTT. VTA. EXENTA  $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))
        TICKET.EscribirTicket(("SUBTT. VTA. NO SUJ. $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))

        TICKET.EscribirTicket(("VENTA TOTAL. $:").PadRight(23, " ") & total.ToString("0.00").PadLeft(13, " "))
        If (txtTotalPagar.Text > 226) Then
            TICKET.EscribirTicket("---------------------------------------")
            TICKET.EscribirTicket("")
            TICKET.EscribirTicket("NOMBRE: ")
            TICKET.EscribirTicket("NIT/DUI:")
            TICKET.EscribirTicket("F.______________")
        End If
        TICKET.CerrarArchivo(correlativo_Actual, Caja)
    End Sub

    Public Sub ReimprimirTicket()
        A = txtTotalPagar.Text
        Dim strTipo As String
        If (rbEfectivo.Checked = True) Then
            strTipo = "C O N T A D O"
        Else
            strTipo = "C R E D I T O"
        End If

        Dim intTamnio As Integer = direccion.Trim.Length - 8

        Dim anulado_ As String = dgvDetalleVenta.Rows(0).Cells(11).Value.ToString()

        TICKET.AbrirArchivo()
        If anulado_ Then
            TICKET.EscribirTicket("- D E V O L U C I O N DE T I C K E T -")
        End If

        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7))
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio))
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("TICKET # " & txt_correlativo.Text & " " & descripcion_bodega & " CAJA No." & Caja)
        'TICKET.EscribirTicket("FECHA   :" & dtpFechaTrabajo.Value.ToString())
        TICKET.EscribirTicket("FECHA   :" & getRegisterDate())
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("RESOLUCION: " & Me.Resolucion)
        TICKET.EscribirTicket("FECHA DE RESOLUCION: " & Format(Me.fecha_resolucion, "Short Date"))
        TICKET.EscribirTicket("AUTORIZADA: " & Format(Me.fecha_autorizacion, "Short Date"))
        TICKET.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        TICKET.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("CODIGO C:" & txtCodigoEmpleado.Text & "   " & strTipo)
        TICKET.EscribirTicket("CLIENTE :" & txtNombreEmpleado.Text)
        TICKET.EscribirTicket("TIEMPO C:" & tiempo_c)
        TICKET.EscribirTicket("---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicket("CANT " & ("PRODUCTO").PadRight(19, " ") & " P/U  PREC.T")
        Dim precio As Double, total1 As Double, cantidad As Double, descrip As String
        For i As Integer = 0 To dgvDetalleVenta.RowCount - 1
            precio = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(9).Value.ToString()), 2)

            total1 = Math.Round(Convert.ToDouble((dgvDetalleVenta.Rows(i).Cells(9).Value.ToString() * dgvDetalleVenta.Rows(i).Cells(7).Value.ToString()).ToString.Trim()), 2)

            cantidad = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(7).Value.ToString().Trim()))

            descrip = dgvDetalleVenta.Rows(i).Cells(6).Value.ToString().Trim()
            If descrip.Length > 17 Then
                descrip = descrip.Substring(0, 17)
            End If

            'anulado_ = dgvDetalleVenta.Rows(0).Cells(11).Value.ToString()
            If anulado_.Equals("False") Then
                TICKET.EscribirTicket(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(17, " ") & " " & precio.ToString("0.00").PadLeft(5, " ") & " " & total1.ToString("0.00").PadLeft(6, " "))
            Else
                TICKET.EscribirTicket(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(17, " ") & " " & precio.ToString("0.00").PadLeft(5, " ") & " " & (-1 * total1).ToString("0.00").PadLeft(6, " "))
            End If
        Next
        TICKET.EscribirTicket("")
        Dim total As Double, descuento1 As Double, gravada As Double

        gravada = Convert.ToDouble(txtTotalPagar.Text)

        descuento1 = Convert.ToDouble(Me.DESCUENTO)


        'TICKET.EscribirTicket(("DESC.APLICAR $:").PadRight(25, " ") & ("0.00").PadLeft(13, " "))
        'TICKET.EscribirTicket(("DISP.DESCUEN $:").PadRight(25, " ") & ("0.00").PadLeft(12, " "))
        If (rbEfectivo.Checked = True) Then
            total = Val(txtTotalPagar.Text)
        Else
            'CREDITO 
            total = Val(A)
        End If
        TICKET.EscribirTicket("---------------------------------------")

        If anulado_ Then
            TICKET.EscribirTicket(("SUBTT. VTA. GRAVADA $:").PadRight(23, " ") & (-1 * total).ToString("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket(("SUBTT. VTA. EXENTA  $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket(("SUBTT. VTA. NO SUJ. $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))

            TICKET.EscribirTicket(("VENTA TOTAL. $:").PadRight(23, " ") & (-1 * total).ToString("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket("")
        Else
            TICKET.EscribirTicket(("SUBTT. VTA. GRAVADA $:").PadRight(23, " ") & total.ToString("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket(("SUBTT. VTA. EXENTA  $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket(("SUBTT. VTA. NO SUJ. $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))

            TICKET.EscribirTicket(("VENTA TOTAL. $:").PadRight(23, " ") & total.ToString("0.00").PadLeft(13, " "))
            TICKET.EscribirTicket("")
        End If

        If (txtTotalPagar.Text > 226) Or anulado_ Then
            TICKET.EscribirTicket("")
            TICKET.EscribirTicket("NOMBRE: " & txtNombreEmpleado.Text.Trim)
            TICKET.EscribirTicket("NIT/DUI:")
            TICKET.EscribirTicket("F.______________")
        End If

        TICKET.EscribirTicket("")
        TICKET.EscribirTicketFiscal(Chr(27) & Chr(105))
        TICKET.EscribirTicketFiscal(Chr(25))
        TICKET.CerrarArchivo(txt_correlativo.Text, Caja)
    End Sub

    Public Sub GuardarTicketAnulado()
        Dim intTamnio As Integer = direccion.Trim.Length - 8
        A = txtTotalPagar.Text
        Dim strTipo As String
        If (rbEfectivo.Checked = True) Then
            strTipo = "C O N T A D O"
        Else
            strTipo = "C R E D I T O"
        End If

        TICKET.AbrirArchivo()
        TICKET.EscribirTicket("- D E V O L U C I O N DE T I C K E T -")
        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7))
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio))
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("TICKET # " & txt_correlativo.Text & " " & descripcion_bodega & " CAJA No." & Caja)
        'TICKET.EscribirTicket("FECHA   :" & dtpFechaTrabajo.Value.ToString())
        TICKET.EscribirTicket("FECHA   :" & getRegisterDate())
        TICKET.EscribirTicket("                                       ")
        TICKET.EscribirTicket("RESOLUCION: " & Me.Resolucion)
        TICKET.EscribirTicket("FECHA DE RESOLUCION: " & Format(Me.fecha_resolucion, "Short Date"))
        TICKET.EscribirTicket("AUTORIZADA: " & Format(Me.fecha_autorizacion, "Short Date"))
        TICKET.EscribirTicket("  DEL " & serie.Trim().PadRight(6, "0") & del.PadLeft(6, "0"))
        TICKET.EscribirTicket("   AL " & serie.Trim().PadRight(6, "0") & al.PadLeft(6, "0"))
        TICKET.EscribirTicket("---------------------------------------")
        TICKET.EscribirTicket("CODIGO C:" & txtCodigoEmpleado.Text & "   " & strTipo)
        TICKET.EscribirTicket("CLIENTE :" & txtNombreEmpleado.Text)
        TICKET.EscribirTicket("TIEMPO C:" & tiempo_c)
        TICKET.EscribirTicket("---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicket("CANT " & ("PRODUCTO").PadRight(19, " ") & " P/U  PREC.T")
        Dim precio As Double, total1 As Double = 0, cantidad As Double, descrip As String

        For i As Integer = 0 To dgvDetalleVenta.RowCount - 1
            precio = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(9).Value.ToString()), 2)

            total1 = Math.Round(Convert.ToDouble((dgvDetalleVenta.Rows(i).Cells(9).Value.ToString() * dgvDetalleVenta.Rows(i).Cells(7).Value.ToString()).ToString.Trim()), 2)

            cantidad = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(7).Value.ToString().Trim()))

            descrip = dgvDetalleVenta.Rows(i).Cells(6).Value.ToString()

            If descrip.Length > 17 Then
                descrip = descrip.Substring(0, 17)
            End If

            TICKET.EscribirTicket(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(17, " ") & " " & precio.ToString("0.00").PadLeft(5, " ") & " " & (-1 * total1).ToString("0.00").PadLeft(6, " "))
        Next
        TICKET.EscribirTicket("")
        TICKET.EscribirTicket("---------------------------------------")

        Dim total As Double, descuento1 As Double, gravada As Double

        gravada = Convert.ToDouble(txtTotalPagar.Text)

        descuento1 = Convert.ToDouble(Me.DESCUENTO)

        If (rbEfectivo.Checked = True) Then
            total = Val(txtTotalPagar.Text)
        Else
            'CREDITO 
            total = Val(A)
        End If
        TICKET.EscribirTicket(("SUBTT. VTA. GRAVADA $:").PadRight(23, " ") & (-1 * total).ToString("0.00").PadLeft(13, " "))
        TICKET.EscribirTicket(("SUBTT. VTA. EXENTA  $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))
        TICKET.EscribirTicket(("SUBTT. VTA. NO SUJ. $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))

        TICKET.EscribirTicket(("VENTA TOTAL. $:").PadRight(23, " ") & (-1 * total).ToString("0.00").PadLeft(13, " "))
        TICKET.EscribirTicket("")

        'If (txtTotalPagar.Text > 200) Then
        TICKET.EscribirTicket("")
        TICKET.EscribirTicket("NOMBRE: " & txtNombreEmpleado.Text.Trim)
        TICKET.EscribirTicket("NIT/DUI:")
        TICKET.EscribirTicket("F.______________")
        'End If

        TICKET.EscribirTicket(" ")

        TICKET.CerrarArchivo(txt_correlativo.Text, Caja)
    End Sub

    Public Sub GuardarTicketFiscal()

        TICKET.AbrirArchivoFiscal()
        TICKET.EscribirTicketFiscal(direccion)
        TICKET.EscribirTicketFiscal(("Ticket # " & correlativo_Actual).PadRight(39, " ") & "   " & ("Ticket # " & correlativo_Actual).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Bodega : " & descripcion_bodega).PadRight(39, " ") & "   " & ("Bodega : " & descripcion_bodega).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("CAJA No." & Caja).PadRight(39, " ") & "   " & ("CAJA No." & Caja).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Fecha   :" & dtpFechaTrabajo.Value.ToString()).PadRight(39, " ") & "   " & ("Fecha   :" & dtpFechaTrabajo.Value.ToString()).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        TICKET.EscribirTicketFiscal(("Resolucion: " & Me.Resolucion).PadRight(39, " ") & "   " & ("Resolucion: " & Me.Resolucion).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Fecha de Resolucion: " & Format(Me.fecha_resolucion, "Short Date")).PadRight(39, " ") & "   " & ("Fecha de Resolucion: " & Format(Me.fecha_resolucion, "Short Date")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Autorizada: " & Format(Me.fecha_autorizacion, "Short Date")).PadRight(39, " ") & "   " & ("Autorizada: " & Format(Me.fecha_autorizacion, "Short Date")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("  Del " & serie.PadRight(6, "0") & del.PadLeft(6, "0")).PadRight(39, " ") & "   " & ("  Del " & serie.PadRight(6, "0") & del.PadLeft(6, "0")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("   al " & serie.PadRight(6, "0") & al.PadLeft(6, "0")).PadRight(39, " ") & "   " & ("   al " & serie.PadRight(6, "0") & al.PadLeft(6, "0")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        TICKET.EscribirTicketFiscal(("Codigo C:" & txtCodigoEmpleado.Text).PadRight(39, " ") & "   " & ("Codigo C:" & txtCodigoEmpleado.Text).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Cliente :" & txtNombreEmpleado.Text.PadLeft(39, " ")) & "   " & ("Cliente :" & txtNombreEmpleado.Text.PadLeft(39, " ")))
        TICKET.EscribirTicketFiscal(("Tiempo C:" & tiempo_c).PadRight(39, " ") & "   " & ("Tiempo C:" & tiempo_c).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicketFiscal(("Cant Producto---------------P/U--Prec.T").PadRight(39, " ") & "   " & ("Cant Producto---------------P/U--Prec.T").PadRight(39, " "))

        For i As Integer = 0 To listaTicket.Count - 1
            TICKET.EscribirTicketFiscal((listaTicket.Item(i).Trim).PadRight(39, " ") & "   " & (listaTicket.Item(i).Trim).PadRight(39, " "))
        Next
        TICKET.EscribirTicketFiscal("")
        Dim total As Double, descuento1 As Double, gravada As Double

        gravada = Convert.ToDouble(txtTotalPagar.Text)

        descuento1 = Convert.ToDouble(Me.DESCUENTO)


        TICKET.EscribirTicketFiscal(("         Desc.Aplicar    :" & descuento1.ToString("0.00").PadLeft(13, ".")).PadRight(39, " ") & "   " & ("         Desc.Aplicar    :" & descuento1.ToString("0.00").PadLeft(13, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("         Dispon Desc.    :" & saldo.ToString("0.00").PadLeft(13, ".")).PadRight(39, " ") & "   " & ("         Dispon Desc.    :" & saldo.ToString("0.00").PadLeft(13, ".")).PadRight(39, " "))
        If (rbEfectivo.Checked = True) Then
            total = Val(txtTotalPagar.Text) + Val(Me.DESCUENTO)
        Else
            'CREDITO 
            total = Val(A)
        End If
        TICKET.EscribirTicketFiscal(("Subtt. Vta. Gravada     $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " ") & "   " & ("Subtt. Vta. Gravada     $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Subtt. Vta. Exenta      $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. Exenta      $:.........0.00").PadRight(39, " "))
        'TICKET.EscribirTicketFiscal(("Subtt. Vta. Disponible  $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. Disponible  $:.........0.00").PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Subtt. Vta. No Suj.     $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. No Suj.     $:.........0.00").PadRight(39, " "))

        TICKET.EscribirTicketFiscal(("Venta Total             $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " ") & "   " & ("Venta Total             $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("")

        If (txtTotalPagar.Text > 200) Then
            TICKET.EscribirTicketFiscal("")
            TICKET.EscribirTicketFiscal("Nombre: ")
            TICKET.EscribirTicketFiscal("Nit/Dui:")
            TICKET.EscribirTicketFiscal("F.______________")
        End If

        TICKET.EscribirTicketFiscal("")
        TICKET.EscribirTicketFiscal(Chr(27) & Chr(105))
        TICKET.EscribirTicketFiscal(Chr(25))
        TICKET.CerrarArchivoFiscal()
    End Sub

    Public Sub GuardarTicketFiscalAnulado()

        Dim intTamnio As Integer = direccion.Trim.Length - 8
        TICKET.AbrirArchivoFiscal()
        TICKET.EscribirTicketFiscal("----------------ANULADO----------------" & "   " & "----------------ANULADO----------------")
        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7))
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio))
        TICKET.EscribirTicketFiscal(("Ticket # " & correlativo_Actual).PadRight(39, " ") & "   " & ("Ticket # " & correlativo_Actual).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Bodega : " & descripcion_bodega).PadRight(39, " ") & "   " & ("Bodega : " & descripcion_bodega).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("CAJA No." & Caja).PadRight(39, " ") & "   " & ("CAJA No." & Caja).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Fecha   :" & dtpFechaTrabajo.Value.ToString()).PadRight(39, " ") & "   " & ("Fecha   :" & dtpFechaTrabajo.Value.ToString()).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        TICKET.EscribirTicketFiscal(("Resolucion: " & Me.Resolucion).PadRight(39, " ") & "   " & ("Resolucion: " & Me.Resolucion).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Fecha de Resolucion: " & Format(Me.fecha_resolucion, "Short Date")).PadRight(39, " ") & "   " & ("Fecha de Resolucion: " & Format(Me.fecha_resolucion, "Short Date")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Autorizada: " & Format(Me.fecha_autorizacion, "Short Date")).PadRight(39, " ") & "   " & ("Autorizada: " & Format(Me.fecha_autorizacion, "Short Date")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("  Del " & serie.PadRight(6, "0") & del.PadLeft(6, "0")).PadRight(39, " ") & "   " & ("  Del " & serie.PadRight(6, "0") & del.PadLeft(6, "0")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("   al " & serie.PadRight(6, "0") & al.PadLeft(6, "0")).PadRight(39, " ") & "   " & ("   al " & serie.PadRight(6, "0") & al.PadLeft(6, "0")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        TICKET.EscribirTicketFiscal(("Codigo C:" & txtCodigoEmpleado.Text).PadRight(39, " ") & "   " & ("Codigo C:" & txtCodigoEmpleado.Text).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Cliente :" & txtNombreEmpleado.Text.PadLeft(39, " ")) & "   " & ("Cliente :" & txtNombreEmpleado.Text.PadLeft(39, " ")))
        TICKET.EscribirTicketFiscal(("Tiempo C:" & tiempo_c).PadRight(39, " ") & "   " & ("Tiempo C:" & tiempo_c).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("---------------------------------------" & "   " & "---------------------------------------")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicketFiscal(("Cant Producto---------------P/U--Prec.T").PadRight(39, " ") & "   " & ("Cant Producto---------------P/U--Prec.T").PadRight(39, " "))

        Dim precio As Double, total1 As Double, cantidad As Double, descrip As String
        For i As Integer = 0 To dgvDetalleVenta.RowCount - 1
            precio = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(9).Value.ToString()), 2)

            total1 = Math.Round(Convert.ToDouble((dgvDetalleVenta.Rows(i).Cells(9).Value.ToString() * dgvDetalleVenta.Rows(i).Cells(7).Value.ToString()).ToString.Trim()), 2)

            cantidad = Math.Round(Convert.ToDouble(dgvDetalleVenta.Rows(i).Cells(7).Value.ToString().Trim()))

            descrip = dgvDetalleVenta.Rows(i).Cells(6).Value.ToString().Trim()

            TICKET.EscribirTicket(Math.Round(cantidad, 2).ToString("0.00") & " " & descrip.PadRight(22, " ") & " " & precio.ToString("0.00") & " " & total1.ToString("0.00").PadLeft(5, " "))
        Next

        TICKET.EscribirTicketFiscal("")
        Dim total As Double, descuento1 As Double, gravada As Double

        gravada = Convert.ToDouble(txtTotalPagar.Text)

        descuento1 = Convert.ToDouble(Me.DESCUENTO)


        TICKET.EscribirTicketFiscal(("         Desc.Aplicar    :" & descuento1.ToString("0.00").PadLeft(13, ".")).PadRight(39, " ") & "   " & ("         Desc.Aplicar    :" & descuento1.ToString("0.00").PadLeft(13, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("         Dispon Desc.    :" & saldo.ToString("0.00").PadLeft(13, ".")).PadRight(39, " ") & "   " & ("         Dispon Desc.    :" & saldo.ToString("0.00").PadLeft(13, ".")).PadRight(39, " "))
        If (rbEfectivo.Checked = True) Then
            total = Val(txtTotalPagar.Text) + Val(Me.DESCUENTO)
        Else
            'CREDITO 
            total = Val(A)
        End If
        TICKET.EscribirTicketFiscal(("Subtt. Vta. Gravada     $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " ") & "   " & ("Subtt. Vta. Gravada     $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Subtt. Vta. Exenta      $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. Exenta      $:.........0.00").PadRight(39, " "))
        'TICKET.EscribirTicketFiscal(("Subtt. Vta. Disponible  $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. Disponible  $:.........0.00").PadRight(39, " "))
        TICKET.EscribirTicketFiscal(("Subtt. Vta. No Suj.     $:.........0.00").PadRight(39, " ") & "   " & ("Subtt. Vta. No Suj.     $:.........0.00").PadRight(39, " "))

        TICKET.EscribirTicketFiscal(("Venta Total             $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " ") & "   " & ("Venta Total             $:" & total.ToString("0.00").PadLeft(9, ".")).PadRight(39, " "))
        TICKET.EscribirTicketFiscal("")

        If (txtTotalPagar.Text > 200) Then
            TICKET.EscribirTicketFiscal("")
            TICKET.EscribirTicketFiscal("Nombre: ")
            TICKET.EscribirTicketFiscal("Nit/Dui:")
            TICKET.EscribirTicketFiscal("F.______________")
        End If

        TICKET.EscribirTicketFiscal("")
        TICKET.EscribirTicketFiscal(Chr(27) & Chr(105))
        TICKET.EscribirTicketFiscal(Chr(25))
        TICKET.CerrarArchivoFiscal()
    End Sub

    Public Sub Imprimir()
        If txtNumTicket.Enabled = False Then
            If (cobrarx = False) Then
                Dim tipo_impresor As String
                tipo_impresor = c_data2.leerDataeader("execute sp_TIPO_IMPRESOR @COMPAÑIA=" & Compañia & ", @BODEGA= " & Bodega & ",@CAJA=" & Caja, 0)
                If tipo_impresor = "False" Then
                    ReimprimirTicket()
                Else
                    ReimprimirTicket()
                End If
            Else
                MsgBox("Aviso!", MsgBoxStyle.Information)
            End If
        Else
            If (cobrarx = False) Then
                Dim tipo_impresor As String
                tipo_impresor = c_data2.leerDataeader("execute sp_TIPO_IMPRESOR @COMPAÑIA=" & Compañia & ", @BODEGA= " & Bodega & ",@CAJA=" & Caja, 0)
                If tipo_impresor = "False" Then
                    GuardarTicket()
                Else
                    GuardarTicketFiscal()
                End If
            Else
                MsgBox("Aviso!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub btnReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReimprimir.Click
        If (dgvDetalleVenta.RowCount <> 0) And Val(txtNumTicket.Text) <> 0 Then
            Imprimir()
            btnNuevo.PerformClick()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        Me.txtTotal.Text = (Val(txtCantidad.Text) * Val(Me.txtPrecio.Text)).ToString()
    End Sub

    Private Sub Cafeteria_Facturacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'When the function keys are pressed, FuncKeysModule is called. 
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
        If rbCredito.Enabled And rbEfectivo.Enabled Then
            If e.KeyValue = Keys.F1 Then
                If Val(Me.txtCodigoEmpleado.Text) > 1 Then
                    rbCredito.Checked = True
                    rbEfectivo.Checked = False
                End If
            End If
            If Val(Me.txtCodigoEmpleado.Text) > 1 Then
                If e.KeyValue = Keys.F5 Then
                    rbCredito.Checked = False
                    rbEfectivo.Checked = True
                End If
            End If
        End If
    End Sub

    Public Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.F1
                'Add the code for the function key F1 here.                
            Case Keys.F2
                'Add the code for the function key F2 here.
                btnCobrar.PerformClick()
            Case Keys.F3
                'Add the code for the function key F3 here.
                btnNuevo.PerformClick()
            Case Keys.F4
                'Add the code for the function key F3 here.
                btnBuscarProducto.PerformClick()
            Case Keys.F5
                'Add the code for the function key F5 here.                
            Case Keys.F6
                'Add the code for the function key F5 here.
                btnReimprimir.PerformClick()
            Case Keys.F7
                'Add the code for the function key F7 here.
                btnBuscarCliente.PerformClick()
            Case Keys.F8
                btnBuscarProducto.PerformClick()
            Case Keys.F9
                'Add the code for the function key F9 here.
                btnPassw.PerformClick()
            Case Keys.F10
                'Add the code for the function key F10 here.
                btnEliminarProducto.PerformClick()
            Case Keys.F11
                If Estado = Nothing Or Bodega = 0 Or Tiempo = 0 Or Caja = Nothing Then
                    txtCantidad.Enabled = False
                    btnReimprimir.Enabled = False
                    btnCobrar.Enabled = False
                    MsgBox("Aviso...No hay tiempo de comida aperturado!", MsgBoxStyle.Information)
                Else
                    Me.Timer1.Enabled = False
                End If
            Case Keys.F12
                Me.Close()
            Case Keys.Left
                TextBox2.Focus()
            Case Keys.Right
                If txtCantidad.Text = "" Then
                    MsgBox("Aviso...Ingrese primero el codigo del producto!", MsgBoxStyle.Information)
                Else
                    txtCantidad.Focus()
                End If

        End Select
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        'If dgvDetalleVenta.Rows.Count <> 0 Then
        '    MsgBox("Aviso...Tiene productos en bandeja!", MsgBoxStyle.Information)
        'Else
        Me.Close()
        'End If
    End Sub

    Public Sub leerBarra()
        Dim autorizaciones, tblDatosEmp As DataTable
        If Val(Me.txtCodigoEmpleado.Text) = 1 Then
            Me.rbEfectivo.Checked = True
            Dim myForm As New Cafeteria_Facturacion_Capturar_Codigo
            myForm.ShowDialog(Me)
            If Not myForm.chkValido.Checked Then
                Me.txtCodigoEmpleado.Text = ""
                Me.txtCodigoEmpleado.Focus()
                PRECIO_ESPECIAL = "False"
            Else
                PRECIO_ESPECIAL = "True"
                codVtaContado = myForm.txtCodEmpl.Text
                Me.txtNombreEmpleado.Tag = myForm.txtNombreEmpl.Text
                Label5.Text = codVtaContado & " " & Me.txtNombreEmpleado.Tag.ToString()
            End If
            myForm.Dispose()
        End If
        If (txtCodigoEmpleado.Text = "") Then
            Label5.Text = "Debe digitar el codigo del empleado"
        Else
            If txtCodigoEmpleado.Text <> "1" Then
                Label5.Text = ""
            End If
            tblDatosEmp = c_data2.obtenerDatos(New SqlCommand("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCodigoEmpleado.Text.Trim() & "',@BANDERA=0"))
            If Not IsDBNull(tblDatosEmp.Rows(0).Item(0)) Then
                txtNombreEmpleado.Text = tblDatosEmp.Rows(0).Item(1)
                codigo_as = tblDatosEmp.Rows(0).Item(3)
                codigo_buxi = tblDatosEmp.Rows(0).Item(0)
                ORIGEN = tblDatosEmp.Rows(0).Item(2)
                BLOQUEADO = tblDatosEmp.Rows(0).Item(4)
            Else
                MsgBox("CODIGO NO EXISTE", MsgBoxStyle.Information, "Facturación")
                Me.txtCodigoEmpleado.Clear()
                Return
            End If
            If (Val(txtCodigoEmpleado.Text) > 0) Then
                If Val(txtCodigoEmpleado.Text) > 1 Then
                    PRECIO_ESPECIAL = tblDatosEmp.Rows(0).Item(5)
                End If
                If LimiteSolic > 0 Then
                    Me.lblDispoCred.Visible = True
                    Me.txtDisponible.Visible = True
                End If
                If (Val(txtCodigoEmpleado.Text) = 1) Then
                    Me.rbEfectivo.Checked = True
                Else
                    Me.rbCredito.Checked = True
                End If
            Else
                PRECIO_ESPECIAL = "False"
                Me.txtDisponible.Visible = False
                Me.lblDispoCred.Visible = False
                Me.rbCredito.Checked = False
            End If

            factor_ = 0
            If PRECIO_ESPECIAL <> "True" Then
                factor_ = c_data2.leerDataeader("EXECUTE sp_GET_SHARE_PRICE_SALE_CAFE", 0)
            End If

            If BLOQUEADO <> "False" Then
                SQL = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                SQL &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                SQL &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                SQL &= "     AND A.CODIGO_EMPLEADO = " & Val(codigo_buxi) & vbCrLf
                SQL &= "     AND A.SOLICITUD = " & TipoSoli & vbCrLf
                SQL &= "     AND A.MONTO_MAXIMO > 0 " & vbCrLf
                SQL &= "     AND A.EXCEDER_LIMITE = 0 " & vbCrLf
                autorizaciones = c_data2.obtenerDatos(New SqlCommand(SQL))
                If autorizaciones.Rows.Count > 0 Then
                    monto_maximo = autorizaciones.Rows(0).Item(0)
                Else
                    monto_maximo = 0
                End If
                Me.txtDisponible.Text = Format(monto_maximo, "0.00")
                If monto_maximo < 2 Then
                    Me.txtDisponible.ForeColor = Color.Red
                End If
                If LimiteSolic = 0 Then
                    Me.txtDisponible.Visible = True
                    Me.lblDispoCred.Visible = True
                End If
                If monto_maximo = 0 And Not forzar_efectivo_ Then
                    BLOQUEADO = "0"
                    Dim respuesta As MsgBoxResult
                    respuesta = MsgBox("EL EMPLEADO SE ENCUENTRA BLOQUEADO TEMPORALMENTE. Desea Cobrar en Efectivo?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                    If respuesta = MsgBoxResult.No Then
                        txtCodigoEmpleado.Text = ""
                        txtNombreEmpleado.Text = ""
                        Me.txtDisponible.Text = "0.00"
                        forzar_efectivo_ = False
                        Return
                    Else
                        forzar_efectivo_ = True
                    End If
                End If
            Else
                'si no está bloqueado individualmente se VALIDA el límite de consumo del tipo de solicitud (Tiposoli)
                If Me.rbCredito.Checked Then
                    SQL = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS]" & vbCrLf
                    SQL &= " @COMPAÑIA        = " & Compañia & vbCrLf
                    SQL &= ",@CODIGO_EMPLEADO = " & Me.txtCodigoEmpleado.Text & vbCrLf
                    SQL &= ",@SOLICITUD       = " & TipoSoli & vbCrLf
                    SQL &= ",@BANDERA         = 1" & vbCrLf
                    autorizaciones = c_data2.obtenerDatos(New SqlCommand(SQL))
                    If autorizaciones.Rows.Count > 0 Then
                        If CDbl(autorizaciones.Rows(0).Item(0)) > 0.0 Then
                            Me.txtMotivoBloqueo.Text = autorizaciones.Rows(0).Item(1).ToString().ToUpper()
                            Me.txtMotivoBloqueo.Visible = True
                            Me.txtDisponible.Text = Format(autorizaciones.Rows(0).Item(0), "0.00")
                            monto_maximo = autorizaciones.Rows(0).Item(0)
                            BLOQUEADO = "True"
                        Else
                            MsgBox("Se ha bloqueado este empleado debido a:" & vbCrLf & vbCrLf & autorizaciones.Rows(0).Item(1).ToString().ToUpper())
                            Me.btnNuevo.PerformClick()
                            Return
                        End If
                    Else
                        If LimiteSolic > 0 Then
                            monto_maximo = c_data2.obtenerEscalar("EXECUTE dbo.sp_COOPERATIVA_CREDITO_DISPONIBLE_X_EMPLEADO @COMPAÑIA = " & Compañia & ", @TIPOSOLI = " & TipoSoli & ", @CODIGO_EMPLEADO = " & codigo_buxi)
                            If monto_maximo < 2 Then
                                Me.txtDisponible.ForeColor = Color.Red
                            End If
                            If monto_maximo <= 0 And Not forzar_efectivo_ Then
                                BLOQUEADO = "0"
                                Dim respuesta As MsgBoxResult
                                respuesta = MsgBox("EL LIMITE DE CREDITO PARA CAFETERIA PLANTA " & Planta & vbCrLf & " ES HASTA POR LA CANTIDAD DE: $ " & Format(LimiteSolic, "0.00") & vbCrLf & vbCrLf & "       DESEA COBRAR EN EFECTIVO?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Límite de Consumo Excedido.")
                                If respuesta = MsgBoxResult.No Then
                                    txtCodigoEmpleado.Text = ""
                                    txtNombreEmpleado.Text = ""
                                    Me.txtDisponible.Text = "0.00"
                                    forzar_efectivo_ = False
                                    Return
                                Else
                                    forzar_efectivo_ = True
                                End If
                            Else
                                Me.txtDisponible.Text = Format(monto_maximo, "0.00")
                            End If
                        End If
                    End If
                End If
            End If
            If txtNombreEmpleado.Text = "" Then
                txtCodigoEmpleado.Text = ""
                txtCodigoEmpleado.Focus()

            Else
                'CALCULA EL DESCUENTO VIGENTE
                DESCUENTO = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@COD_EMPLEADO_AS='" & codigo_as & "',@COD_EMPLEADO=" & codigo_buxi & ", @BANDERA=7", 0)
                If (Val(txtCodigoEmpleado.Text) > 0) Then
                    'Me.Timer2.Enabled = True
                    'Me.Timer2.Start()
                    If forzar_efectivo_ Then
                        rbCredito.Enabled = False
                        rbEfectivo.Enabled = False

                        rbCredito.Checked = False
                        rbEfectivo.Checked = True
                    Else
                        rbCredito.Enabled = True
                        rbEfectivo.Enabled = True
                        If (Val(txtCodigoEmpleado.Text) > 1) Then
                            rbCredito.Checked = True
                        Else
                            rbEfectivo.Checked = True
                        End If
                    End If
                Else
                    rbCredito.Enabled = False
                    rbEfectivo.Enabled = False

                    rbCredito.Checked = False
                    rbEfectivo.Checked = True
                End If
            End If
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Enter
        forzar_efectivo_ = False
    End Sub

    Private Sub txtCodigoEmpleado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoEmpleado.Leave
        leerBarra()
    End Sub

    Public Sub seleccionProducto(ByVal texto As String)
        If texto = "" Then
            Label5.Text = "Debe digitar el codigo del producto"
        Else
            'BUSCA SI ESE CODIGO EXISTE EN LA BODEGA
            Label5.Text = ""
            Me.txtDescripcion.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @PRODUCTO=" & texto & ", @BANDERA=4", 1)
            Me.txtProducto.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @PRODUCTO=" & texto & ", @BANDERA=4", 0)

            If txtDescripcion.Text = "" Then
                MsgBox("Aviso...Codigo No existe en esta bodega o no esta programado para este turno!", MsgBoxStyle.Information)
            Else
                If (txtCodigoEmpleado.Text = "") Then
                    Label5.Text = "Debe digitar el codigo del empleado"
                    txtCodigoEmpleado.Focus()
                Else
                    Label5.Text = ""
                    If (txtProducto.Text = "") Then
                    Else
                        txtExistencias.Text = Val(c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Bodega & "," & txtProducto.Text & ",'" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0))

                        If factor_ > 0 Then
                            If PRECIO_ESPECIAL <> "True" Then
                                txtPrecio.Text = Format(Math.Round(Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0)) * factor_, 2, MidpointRounding.AwayFromZero), "0.00")
                            Else
                                txtPrecio.Text = Format(Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0)), "0.00")
                            End If
                        Else
                            txtPrecio.Text = Format(Val(c_data2.leerDataeader("SELECT PRECIO_UNITARIO FROM INVENTARIOS_PRODUCTOS_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND PRODUCTO=" & txtProducto.Text, 0)), "0.00")
                        End If

                        Me.txtCantidad.Text = "1"
                        Me.txtCantidad.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            seleccionProducto(TextBox2.Text)
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        'flecha Hacia ABAJO
        If (e.KeyCode = Keys.Left) Then
            TextBox2.Focus()
        End If

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Right) Then
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub Cafeteria_Facturacion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'transferencia_activa = c_data2.leerDataeader("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=2", 0)
        'If transferencia_activa = "True" Then
        '    If (bloqueos = 0) Then
        '        ventana = c_data2.leerDataeader("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=2", 1)
        '        user1 = c_data2.leerDataeader("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=2", 2)
        '        maquina = c_data2.leerDataeader("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=2", 3)
        '        Dim ventana_form_bloqueo As New Cafeteria_Bloqueo(user1, ventana, maquina, Bodega)
        '        bloqueos = 1

        '        ventana_form_bloqueo.ShowDialog()
        '        bloqueos = 0

        '    Else

        '    End If
        'End If

    End Sub
    'Metodo de busqueda de Socios
    Public Sub busquedaClientes()
        Dim Socios As New Facturacion_BusquedaSocios
        Socios.Compañia_Value = Compañia
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Bodega
        Socios.ShowDialog()
        datosSocio(Producto, Numero)
    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        Try

            SQL = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
            SQL &= Compañia
            SQL &= ", '" & numSocio & "'"
            SQL &= ", " & codEmp
            SQL &= ", 13" 'BANDERA
            sqlCmd.CommandText = SQL
            Table = c_data2.obtenerDatos(sqlCmd)
            If Table.Rows.Count = 1 Then
                'TODO Cambio  del codigo que recibe por el de BUXIS
                'Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                Me.txtCodigoEmpleado.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")

                Me.txtNombreEmpleado.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
            End If
            leerBarra()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        busquedaClientes()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.rbCredito.Checked Then
            If Me.rbCredito.Visible Then
                Me.rbCredito.Visible = False
            Else
                Me.rbCredito.Visible = True
            End If
            Me.rbCredito.BackColor = Color.Red
        Else
            Me.rbCredito.Visible = True
            Me.rbCredito.BackColor = Color.DarkGray
        End If
        If Me.rbEfectivo.Checked Then
            If Me.rbEfectivo.Visible Then
                Me.rbEfectivo.Visible = False
            Else
                Me.rbEfectivo.Visible = True
            End If
            Me.rbEfectivo.BackColor = Color.Lime
        Else
            Me.rbEfectivo.Visible = True
            Me.rbEfectivo.BackColor = Color.DarkGray
        End If
        'If Me.lblFormaPago.Visible Then
        '    Me.lblFormaPago.Visible = False
        'Else
        '    Me.lblFormaPago.Visible = True
        'End If
    End Sub

    Private Sub rbCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCredito.Click
        If LimiteSolic > 0 Or BLOQUEADO <> "False" Then
            Me.lblDispoCred.Visible = True
            Me.txtDisponible.Visible = True
        End If
        'Me.Timer2.Stop()
        'Me.Timer2.Enabled = False
    End Sub

    Private Sub rbEfectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEfectivo.Click
        Me.lblDispoCred.Visible = False
        Me.txtDisponible.Visible = False
        'Me.Timer2.Stop()
        'Me.Timer2.Enabled = False
    End Sub


    'Private Sub cargaIndex()
    '    Dim fpInfo As NBioAPI.IndexSearch.FP_INFO()
    '    Dim ret As UInteger
    '    Dim myconnection As SqlConnection
    '    Dim cmd As SqlCommand = New SqlCommand("Select USERID, FPData from FingerPrintData")
    '    myconnection = New SqlConnection()
    '    myconnection.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & BaseDatos & ";uid=" & UsuarioDB & ";password=" & PasswordDB & ";" 'Set database path to connection string
    '    myconnection.Open()
    '    cmd.Connection = myconnection
    '    Dim reader As SqlDataReader = cmd.ExecuteReader()
    '    Dim nUserID As UInteger = 0
    '    Dim Fpdata As String = ""
    '    Dim textFIR As NBioAPI.Type.FIR_TEXTENCODE
    '    While reader.Read()
    '        nUserID = reader.GetInt32(0)
    '        Fpdata = reader.GetString(1)
    '        textFIR = New NBioAPI.Type.FIR_TEXTENCODE()
    '        textFIR.TextFIR = Fpdata
    '        ret = m_IndexSearch.AddFIR(textFIR, nUserID, fpInfo)
    '        If ret <> NBioAPI.Error.NONE Then
    '            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) & " [" & ret.ToString() & "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return
    '        End If
    '    End While

    '    myconnection.Close()

    'End Sub

    'Public Function myCallback(ByRef cbParam0 As NBioAPI.IndexSearch.CALLBACK_PARAM_0, ByVal userParam As IntPtr) As UInteger
    '    progressIdentify.Value = Convert.ToInt32(cbParam0.ProgressPos)
    '    Return NBioAPI.IndexSearch.CALLBACK_RETURN.OK
    'End Function

    'Private Sub DisplayErrorMsg(ByVal ret As UInteger)
    '    MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) & " [" & ret.ToString() & "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End Sub

    'Private Sub btnHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuella.Click
    '    Dim hCapturedFIR As New NBioAPI.Type.HFIR
    '    Dim ret As UInteger
    '    ' Get FIR data
    '    ret = m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)
    '    If ret = 257 Then
    '        Return
    '    End If

    '    ret = m_NBioAPI.Capture(hCapturedFIR, FPTimer, New NITGEN.SDK.NBioBSP.NBioAPI.Type.WINDOW_OPTION)
    '    If ret <> NBioAPI.Error.NONE Then
    '        If ret <> 513 And ret <> 516 And ret <> 261 Then
    '            DisplayErrorMsg(ret)
    '        End If
    '        m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)
    '        Return

    '    End If

    '    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '    Dim nMax As UInteger
    '    m_IndexSearch.GetDataCount(nMax)
    '    progressIdentify.Minimum = 0
    '    progressIdentify.Maximum = Convert.ToInt32(nMax)
    '    Dim cbInfo0 As NBioAPI.IndexSearch.CALLBACK_INFO_0 = New NBioAPI.IndexSearch.CALLBACK_INFO_0()
    '    cbInfo0.CallBackFunction = New NBioAPI.IndexSearch.INDEXSEARCH_CALLBACK(AddressOf myCallback)

    '    ' Identify FIR to IndexSearch DB
    '    Dim fpInfo As NBioAPI.IndexSearch.FP_INFO
    '    ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, fpInfo, cbInfo0)
    '    If ret <> NBioAPI.Error.NONE Then
    '        DisplayErrorMsg(ret)
    '        Return
    '    End If
    '    Me.txtCodigoEmpleado.Text = fpInfo.ID.ToString()
    '    IDdedo = fpInfo.FingerID
    '    Me.txtCodigoEmpleado.Focus()
    '    Me.txtProducto.Focus()
    'End Sub
End Class