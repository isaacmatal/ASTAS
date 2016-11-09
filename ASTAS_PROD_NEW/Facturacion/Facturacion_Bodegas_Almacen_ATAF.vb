Imports System.Data.SqlClient
Imports System
Imports System.Drawing.Printing
Imports System.Configuration
Public Class Facturacion_Bodegas_Almacen_ATAF
    'Constructor
    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Dim FactCreada As Boolean = False
    Dim totRegFact, TipCosto As Integer
    Dim UMIndex As Integer
    Dim DisponibleSocio As Double
    Dim codClie As Integer
    Dim TipClie, StatusCliente As Integer
    Dim TipContrib As Integer
    Dim tipoproducto As Integer
    Dim CondPago As Integer
    Dim giro As String
    Dim exento, _error_ As Boolean
    Dim MSJ As Boolean = True
    Dim NRC As String
    Dim dirClie As String
    Dim TipMovInv, TipMovInvFact, TipMovInvCCF, TipoSolicitud As Integer
    Dim PorcIVA, PorcPercep As Double

    ' nuevas
    Dim producto_especial As Integer
    Dim productos_facturados(100, 2) As String
    Dim i As Integer
    Dim cantidad_precio_especial As Double
    Dim origen_autoconsumo As Integer = 9 'Definido en Cooperativa_Catalogo_Origenes
    Dim primerEnter As Boolean = True
    'Variables para almacenar el grupo y subgrupo de los productos
    Public grupoProd As Integer
    Public subgrupoProd As Integer
    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim Table1 As DataTable
    Dim Table2 As DataTable
    Dim Table3 As DataTable
    Dim Table4 As DataTable
    Dim Table5 As DataTable
    Dim DataReader_ As SqlDataReader
    Dim maximo_descuento As Double
    Dim listaTicket As New List(Of String)
    'TC
    Dim intCodAutoconsumo As Integer = -1
    Dim intCodDescuento As Integer = -1
    Dim strDescuento As String = Nothing
    Dim TICKET As New GenerarTicket
    Dim Bodega As Integer, Tiempo As Integer, Estado As String, Caja As String, descripcion_Caja As String, direccion As String, tiempo_c As String
    Dim Resolucion As String, fecha_resolucion As String, fecha_autorizacion As String, del As String, al As String, descripcion_bodega As String, serie As String, fecha_aprovacion As String, correlativo_Actual As String
    Dim codigo_as As String, codigo_buxi As String, A As String, descuento1 As String, NoFact1 As String, Mov As String
    Dim DS01, DS02, DS03 As New DataSet()
    Dim BLOQUEADO As String = "0"
    Dim FORMA_PAGO As Integer
    Dim Subtotal As Double
    Dim sqlCmd As New SqlCommand
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

    Dim IVA As String
    'Creo mi datatable y columnas
    Dim miDataTable As New DataTable
    
    Private Sub Facturacion_Bodegas_Almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        i = 0

        CheckDisponible.Checked = True

        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA_CONTABLE.Value = multi.FechaActual_Servidor()        
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)        

        multi.CargaPeriodo(Compañia, Me.cmbPeriodoPago)
        If (Val(txtCliente.Text) > 0) Then
            rbCredito.Checked = True
            rbEfectivo.Checked = False
            FORMA_PAGO = 2
        Else
            rbCredito.Checked = False
            rbEfectivo.Checked = True
            FORMA_PAGO = 1
        End If
        multi.CargaCondicionPago(Compañia, FORMA_PAGO, Me.cmbCONDICION_PAGO)
        Me.cmbPeriodoPago.SelectedValue = "QQ"

        jClass.CargaBancos(Compañia, Me.cmbBancos)
        Me.cmbBancos.SelectedIndex = 1
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
        '
        Me.cmbCtasBanco.SelectedIndex = 0
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ReadOnly = True
        Me.dgvCuentasEquivalentes.AllowUserToAddRows = False
        Me.dgvCuentasEquivalentes.ReadOnly = True
        Me.DateTimePicker1.Value = setFechaPago()
        Me.DateTimePicker1.MinDate = Me.DateTimePicker1.Value
        'SetearFechas()
        multi.CargaUnidadMedida(Compañia, Me.cmbUNIDAD_MEDIDA)
        Iniciando = False
        TipCosto = 1

        'ObtieneNumeroFactura()

        obtieneCentroCosto()
        ParamBodegas()
        generaGrid()
        PorcIVA = FPro.DevuelveConstante(Compañia, 1)
        PorcPercep = FPro.DevuelveConstante(Compañia, 2)
        BuscaProductos()

        caja_registradora()
        NumeroFactura()

        If Estado = Nothing Or Bodega = 0 Or Tiempo = 0 Or Caja = Nothing Then
            TabControl1.Enabled = False
            MsgBox("Aviso...No hay tiempo de comida aperturado!", MsgBoxStyle.Information)
        Else
            TabControl1.Enabled = True
        End If

        miDataTable.Columns.Add("producto")
        miDataTable.Columns.Add("descripcion")
        miDataTable.Columns.Add("unidad")
        miDataTable.Columns.Add("cantidad")
        miDataTable.Columns.Add("precio")
        miDataTable.Columns.Add("total")
        miDataTable.Columns.Add("Unidadid")
        miDataTable.Columns.Add("idLinea")
        miDataTable.Columns.Add("TIPO_MOVIMIENTO")
        miDataTable.Columns.Add("MOVIMIENTO")
        miDataTable.Columns.Add("ORDEN_VENTA")
        miDataTable.Columns.Add("pdescuento")
        miDataTable.Columns.Add("pporcentaje")
        miDataTable.Columns.Add("pCostou")
        miDataTable.Columns.Add("pCostoT")

        Iniciando = False
    End Sub
    Public Sub caja_registradora()

        Estado = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "', @BANDERA=0", 0)

        Bodega = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 2)
        Caja = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 4)
        Me.txtCaja.Text = Caja
        Tiempo = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 3)
        tiempo_c = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 6)
        descripcion_bodega = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 7)

        If Caja = Nothing Then
        Else
            direccion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ", @CAJA=" & Caja & ", @BANDERA=1", 0)
        End If

        descripcion_Caja = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(dpFECHA_CONTABLE.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "',@BANDERA=0", 6)
    End Sub

    Private Sub obtieneCentroCosto()
        Dim sqlCmd As New SqlCommand
        If Not Iniciando Then
            sql = " Execute dbo.sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO_BODEGA "
            sql &= Compañia
            sql &= ", " & Me.cmbBODEGA.SelectedValue
            sql &= ", 1"
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count = 1 Then
                CC = Table.Rows(0).Item("Centro Costo")
            Else
                CC = 0
            End If
        End If
    End Sub

    Private Function obtieneMAXOV(ByVal cia As Integer) As Integer
        Dim numOV As Integer
        Try
            sql = "SELECT ISNULL(MAX([ORDEN_VENTA]),0) + 1 FROM dbo.FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & cia
            numOV = jClass.obtenerEscalar(sql)
            If numOV = Nothing Then
                Return 0
            Else
                Return numOV
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Function actualizaNumDoc(ByVal CIA As Integer, ByVal Docto As String) As Integer
        Dim numOV As Integer
        Try
            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            sql &= CIA
            sql &= ", '" & Docto & "'"
            sql &= ", " & 0
            numOV = jClass.obtenerEscalar(sql)
            If numOV = Nothing Then
                Return 0
            Else
                Return numOV
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        busquedaClientes()
    End Sub

    'Metodo de busqueda de Socios
    Public Sub busquedaClientes()
        Dim Socios As New Facturacion_BusquedaSocios
        Socios.Compañia_Value = Compañia
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        Dim Clientes As New Contabilidad_BusquedaClientes
        Clientes.Compañia_Value = Compañia
        Clientes.cmbCOMPAÑIA.Enabled = False
        Clientes.numForm = 46882
        Clientes.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        If Producto Is Nothing Then
            Producto = ""
        End If
        If Not Me.chkCliExt.Checked Then
            Socios.ShowDialog()
            datosSocio(Producto, Numero)
        Else
            Clientes.ShowDialog()
            datosCliente(Producto, Numero)
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            'ObtieneNumeroFactura()
            caja_registradora()
            NumeroFactura()
            obtieneCentroCosto()
            ParamBodegas()
            If Iniciando = False Then
                BuscaProductos()
            End If
        End If

    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        Dim Bloqueado As Boolean
        If numSocio <> "" Then
            If jClass.SocioBloqueado(numSocio) Then
                Me.txtCliente.Clear()
                Return
            End If
            Try
                'CheckDisponible.Checked = True
                CheckDisponible.Enabled = True
                sql = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
                sql &= Compañia
                sql &= ", '" & numSocio & "'"
                sql &= ", " & codEmp
                sql &= ", 13" 'BANDERA
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    'TODO Cambio  del codigo que recibe por el de BUXIS
                    'Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.lblCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    If fnBuscaBloqueo(CInt(Table.Rows(0).Item("CODIGO_EMPLEADO")), CStr(Table.Rows(0).Item("CODIGO_EMPLEADO_AS"))) Then
                        Me.txtCliente.Text = ""
                        Me.lblCodBuxis.Text = ""
                        DisponibleSocio = 0
                        Origen = 0
                        MsgBox("El Codigo : " + CStr(Table.Rows(0).Item("CODIGO_EMPLEADO")) + " esta Bloqueado.. " + Chr(13) + " Consulte con el Administrador", MsgBoxStyle.Critical, "Bloqueado")
                        Return
                    Else
                        Me.txtNombreCliente.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                        Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                        Me.txtTelCliente.Text = Table.Rows(0).Item("TELEFONO")
                        Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                        Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                        StatusCliente = Table.Rows(0).Item("ESTATUS")
                        Origen = Table.Rows(0).Item("ORIGEN")
                        If Origen = origen_autoconsumo Then
                            Me.txtdescuento.ReadOnly = True
                        Else
                            Me.txtdescuento.ReadOnly = False
                        End If
                        Me.LimpiaCamposDetalleFactura()
                        If CheckDisponible.Checked = True Then
                            DisponibleSocio = FPro.DisponibleSocio(Compañia, Me.txtCliente.Text, Val(Me.lblCodBuxis.Text))  ' FPro.Determinardisponible(numSocio, codEmp)
                            Me.lblDispSocio.Text = DisponibleSocio.ToString("0.00")
                            sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & numSocio & "'"
                            Bloqueado = jClass.obtenerEscalar(sql)
                            If Bloqueado Then
                                CheckDisponible.Enabled = False
                            End If
                        Else
                            Me.lblDispSocio.Text = "No Verificar"
                        End If
                        codClie = 0
                        giro = "Socio ASTAS"
                        NRC = ""
                        exento = 0
                        TipClie = 1
                        TipContrib = 0
                        dirClie = ""
                        CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                        cargaHistorialFacturas(Me.txtCliente.Text, 2)
                        Me.txtProducto.Focus()
                        If StatusCliente <> 2 Then
                            Me.CheckDisponible.Checked = False
                        End If
                        'JASC
                        If TipClie = 3 Then
                            lblGranContribuyente.Visible = True
                        Else
                            lblGranContribuyente.Visible = False
                            txtGranDescuento.Text = "0.00"
                        End If

                    End If

                Else
                    DisponibleSocio = 0
                    Origen = 0
                    MsgBox("No se encontraron datos para el socio: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub
    'TC
    Private Function fnBuscaBloqueo(ByVal idcodigo As Integer, ByVal idastas As String) As Boolean
        sql = " SELECT COUNT(*) FROM  FACTURACION_BLOQUEOS WHERE COMPAÑIA = 1  AND CODIGO_EMLEADO = " & idcodigo & "  AND  CODIGO_EMPLEADO_AS = '" & idastas & "'"
        Dim intDato As Integer = CInt(jClass.obtenerEscalar(sql))
        If intDato > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub datosCliente(ByVal numCliente As String, ByVal NIT As String)
        Dim sqlCmd As New SqlCommand
        If numCliente.Length > 0 Then
            Try
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Compañia
                sql &= ", '" & numCliente & "'"
                sql &= ", '" & NIT & "' "
                sql &= ", 2"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("Cliente")
                    Me.lblCodBuxis.Text = "0"
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("Nombre")
                    Me.txtNomFact.Text = Table.Rows(0).Item("Nombre")
                    Me.txtTelCliente.Text = Table.Rows(0).Item("Teléfono")
                    Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                    DisponibleSocio = 0
                    Me.lblDispSocio.Text = DisponibleSocio.ToString("0.00")
                    Origen = Table.Rows(0).Item("Origen")
                    If Origen = origen_autoconsumo Then
                        Me.txtdescuento.ReadOnly = True
                    Else
                        Me.txtdescuento.ReadOnly = False
                    End If
                    Me.LimpiaCamposDetalleFactura()
                    codClie = Me.txtCliente.Text
                    giro = Table.Rows(0).Item("Giro")
                    NRC = Table.Rows(0).Item("NRC")
                    exento = Table.Rows(0).Item("Exento")
                    TipClie = Table.Rows(0).Item("Tipo Cliente")
                    TipContrib = Table.Rows(0).Item("Tipo Contribuyente")
                    dirClie = Table.Rows(0).Item("Dirección")
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    cargaHistorialFacturas(Me.txtCliente.Text, 1)
                    If TipContrib = 3 Then
                        lblGranContribuyente.Visible = True
                    Else
                        lblGranContribuyente.Visible = False
                        txtGranDescuento.Text = "0.00"
                    End If
                    Me.txtProducto.Focus()
                Else
                    DisponibleSocio = 0
                    Origen = 0
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    

    'Limpia los campos del Formulario completo
    Private Sub limpiaCampos(ByVal opcion As Integer)
        Me.LimpiaCamposDetalleFactura()        
        Me.lblCodBuxis.Text = ""
        Me.txtNombreCliente.Clear()
        Me.txtGranDescuento.Text = "0.00"
        Me.txtIVA.Text = "0.00"        
        Me.lblDispSocio.Text = "0.00"
        Me.txtNoFact.Clear()
        Me.cargaHistorialFacturas("00000", 2)
        Me.txtNomFact.Clear()
        Me.txtNITCliente.Clear()
        Me.txtDUICliente.Clear()
        Me.txtTelCliente.Clear()
        Me.txtDescAGUI.Clear()
        Me.txtDescBONI.Clear()
        Me.txtAhorroExt.Clear()
        Me.txtNoRemesa.Clear()
        Me.TextBox30.Clear()
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        Me.txtNumCuotas.Text = "1"
        Me.DataGridView1.Columns.Clear()
        Me.Label21.Visible = False
        Me.btnGuardarDetalle.Enabled = True
        Me.btnEliminaDetalle.Enabled = True
        'JASC28082013
        lblGranContribuyente.Visible = False

        'Me.ObtieneNumeroFactura()
        NumeroFactura()
        generaGrid()
        CheckDisponible.Checked = True
        Me.txtCliente.Focus()
        dpFECHA_CONTABLE.Value = Date.Now
        'TC

        Me.lblAutoconsumo.Visible = False
        txtdescuento.Enabled = True
        btnAutocomsumo.Enabled = True
        intCodAutoconsumo = -1
        intCodDescuento = -1
    End Sub

    Private Sub obtieneDatosProducto(ByVal codProducto As String)
        Dim sqlCmdProd As New SqlCommand
        If codProducto = Nothing Or codProducto.Length = 0 Then
            Return
        End If
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Compañia.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & codProducto
        sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmdProd)
        If Table.Rows.Count = 1 Then
            Me.txtDescripcion.Text = Table.Rows(0).Item("DESCRIPCION_PRODUCTO")
            Iniciando = True
            Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(0).Item("UNIDAD_MEDIDA")
            UMIndex = Me.cmbUNIDAD_MEDIDA.SelectedIndex
            Iniciando = False
            ''TC
            If Me.intCodAutoconsumo > 0 Then
                Me.txtPrecio.Text = jClass.obtenerEscalar("select [dbo].[INVENTARIOS_CALCULAR_COSTO_PRODUCTO] (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')")
            Else
                If Origen <> origen_autoconsumo Then
                    Me.txtPrecio.Text = jClass.obtenerEscalar("SELECT DBO.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ",'" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')") 'Table.Rows(0).Item("PRECIO_UNITARIO").ToString
                Else
                    Me.txtPrecio.Text = jClass.obtenerEscalar("select [dbo].[INVENTARIOS_CALCULAR_COSTO_PRODUCTO] (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')")
                End If
            End If
            txt_Existencias.Text = Math.Round(jClass.obtenerEscalar("select dbo.calcular_existencia_actual (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')"), 2)

            grupoProd = Table.Rows(0).Item("GRUPO")
            subgrupoProd = Table.Rows(0).Item("SUBGRUPO")
            TipCosto = Table.Rows(0).Item("TIPO_COSTO")
            Me.txtCantidad.Focus()
            Dim sql2 As String = ""
            sql2 = "SELECT PORCENTAJE_DESCUENTO_MAXIMO FROM dbo.INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS WHERE COMPAÑIA = " & Compañia & " AND GRUPO= " & grupoProd & " AND SUBGRUPO= " & subgrupoProd
            maximo_descuento = jClass.obtenerEscalar(sql2)
            Me.txtdescuento.Text = "0.0" 'maximo_descuento
            If Table.Rows(0).Item("PROMOCION") Is Nothing OrElse IsDBNull(Table.Rows(0).Item("PROMOCION")) Then
                tipoproducto = 0
            Else
                tipoproducto = Table.Rows(0).Item("PROMOCION")
            End If
        Else
            If Table.Rows.Count > 1 Then
                MsgBox("Existen mas de dos items para la bodega " & Me.cmbBODEGA.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Else
                '  MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            End If
        End If
    End Sub

    'TODO Metodo para cargar el numero máximo de líneas
    Private Sub cargaMaximoLineas(ByVal cia As Integer, ByVal bodega As Integer, ByVal serie As Integer, ByVal tipoDoc As Integer)
        If cia = 0 Or cia = Nothing Or bodega = 0 Or bodega = Nothing Or serie = 0 Or serie = Nothing Or tipoDoc = 0 Or tipoDoc = Nothing Then
            Me.lblMaxLineas.Text = "0"
        Else
            Conexion_ = multi.devuelveCadenaConexion()
            Try
                Conexion_.Open()
                sql = " Execute sp_FACTURACION_LINEAS_TIPO_DOCUMENTO "
                sql &= cia
                sql &= ", " & bodega
                sql &= ", " & serie
                sql &= ", " & tipoDoc
                sql &= ", 0"
                sql &= ", 2"
                Comando_ = New SqlCommand(sql, Conexion_)
                DataReader_ = Comando_.ExecuteReader()
                If DataReader_.Read = True Then
                    MaxNumLineas = DataReader_.Item("LINEAS_MAXIMO")
                    Me.lblMaxLineas.Text = DataReader_.Item("LINEAS_MAXIMO")
                Else
                    Me.lblMaxLineas.Text = "0"
                End If
                Conexion_.Close()
                If Me.lblMaxLineas.Text = "0" Then
                    MsgBox("Verifique el Número Máximo de lineas en detalle!!!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    Private Sub LimpiaCamposDetalleFactura()
        Me.txtDescripcion.Clear()
        Me.txtPrecio.Clear()
        Me.txtCantidad.Clear()
        Me.txtProducto.Clear()
        Me.txtdescuento.Clear()
        TipCosto = 1
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) = True Then
            Me.txtDescripcion.Clear()
            Me.txtPrecio.Clear()
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            CheckDisponible.Checked = True
            Me.txtProducto.Focus()
            leerBarra()
        End If        
    End Sub
    Public Sub leerBarra()
        If (txtCliente.Text = "") Then
            Label5.Text = "Debe digitar el codigo del empleado"
        Else
            Label5.Text = ""
            txtNombreCliente.Text = jClass.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCliente.Text.PadLeft(6, "0") & "',@BANDERA=0", 1)

            If txtNombreCliente.Text = "" Then
                txtCliente.Text = ""
                txtCliente.Focus()

            Else
                codigo_as = jClass.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCliente.Text.PadLeft(6, "0") & "',@BANDERA=0", 3)
                codigo_buxi = jClass.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCliente.Text.PadLeft(6, "0") & "',@BANDERA=0", 0)
                Origen = jClass.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCliente.Text.PadLeft(6, "0") & "',@BANDERA=0", 2)
                BLOQUEADO = jClass.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & txtCliente.Text.PadLeft(6, "0") & "',@BANDERA=0", 4)

                If BLOQUEADO <> "False" Then
                    BLOQUEADO = "0"
                    MsgBox("EL EMPLEADO SE ENCUENTRA BLOQUEADO TEMPORALMENTE")
                    txtCliente.Text = ""
                    txtNombreCliente.Text = ""
                    Exit Sub
                End If

                'CALCULA EL DESCUENTO VIGENTE
                'EXECUTE [dbo].[sp_CAFETERIA_FACTURACION_OBTENER_SERIE] @COMPAÑIA=1, @COD_EMPLEADO_AS='06208', @COD_EMPLEADO=4127, @BANDERA=7
                descuento1 = jClass.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@COD_EMPLEADO_AS='" & codigo_as & "',@COD_EMPLEADO=" & codigo_buxi & ", @BANDERA=7", 0)
                If (Val(txtCliente.Text) > 0) Then
                    rbCredito.Checked = True
                    rbEfectivo.Checked = False
                    FORMA_PAGO = 2
                    multi.CargaCondicionPago(Compañia, FORMA_PAGO, Me.cmbCONDICION_PAGO)
                    Me.cmbCONDICION_PAGO.SelectedIndex = 0
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                Else
                    rbCredito.Checked = False
                    rbEfectivo.Checked = True
                    FORMA_PAGO = 1
                    multi.CargaCondicionPago(Compañia, FORMA_PAGO, Me.cmbCONDICION_PAGO)
                    Me.cmbCONDICION_PAGO.SelectedIndex = 0
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                End If
                txtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Dim subtot, ExistenciaProducto, CostoU, CostoT, CantidadFacturada, valdescC As Double
        ', valdesc, totProd, totIVAitem, totProdItem
        'Dim TipMovto, Movto As Integer
        Dim producto_facturado As Integer = 0
        Dim ProductoDuplicado As Boolean

        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            If Val(row.Cells(0).Value) = Val(Me.txtProducto.Text) Then
                ProductoDuplicado = True
            End If
        Next

        If Not validaCamposVacios() Then
            Return
        End If
        If tipoproducto = 0 And Val(txtPrecio.Text) = 0 Then
            MsgBox("El Precio Unitario no Puede Ser CERO...", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Focus()
            Return
        End If
        If Val(Me.txtCantidad.Text) = 0 Then
            MsgBox("La Cantidad del producto debe ser diferente de cero.", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If
        If Me.txtProducto.Text = Nothing Then
            Me.txtProducto.Focus()
            Return
        End If        
        If Val(Me.txtdescuento.Text) > maximo_descuento Then
            MsgBox("El descuento ingresado es mayor al porcentaje de descuento maximo asignado que es de " & Me.maximo_descuento.ToString & "%", MsgBoxStyle.Critical, "Descuento incorrecto")
            Return
        End If
        If Me.txtdescuento.Text.Length = 0 Then
            MsgBox("El porcentaje de descuento no puede ser nulo, al menos debe ser 0", MsgBoxStyle.Critical, "Porcentaje de descuento incorrecto")
            Return
        End If
        If Me.chkPre_normal.Checked = False And Me.cantidad_precio_especial < Me.txtCantidad.Text Then
            MsgBox("La cantidad ingresada es mayor a las existencias con precio especial", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If


        Producto = Me.txtProducto.Text
        producto_facturado = Me.txtProducto.Text
        CantidadFacturada = 0
        
        CantidadFacturada += Val(Me.txtCantidad.Text)
        ExistenciaProducto = validaExistencias(Val(producto_facturado), Me.cmbBODEGA.SelectedValue, Val(Me.txtCantidad.Text), Me.dpFECHA_CONTABLE.Value)
        If ExistenciaProducto < Val(Me.txtCantidad.Text) Then
            MsgBox("La existencia del producto es de " & ExistenciaProducto & " " & Me.cmbUNIDAD_MEDIDA.Text & vbCrLf & "No se puede procesar producto...", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If

        'TC CONSULTAR CUAL ES EL PRECIO A COLOCAR
        If Val(Me.txtdescuento.Text) > 0 Then
            'TC AJSTAR
            Dim frmAutoConsumo As New Facturacion_Autorizaciones(2)
            frmAutoConsumo.ShowDialog()
            intCodDescuento = frmAutoConsumo.idAutotizacion
            If intCodDescuento < 0 Then
                MsgBox("Autorizacion Denegada.....", MsgBoxStyle.Critical, "ASTAS")
                Return
            End If
        End If
        CostoU = obtieneCostoProducto(Compañia, Me.cmbBODEGA.SelectedValue, producto_facturado, Me.dpFECHA_CONTABLE.Value, TipCosto)
        'EL COSTO TOTAL NO DEBE LLEVAR DESCUENTO, SOLO EL PRECIO
        CostoT = CostoU * Val(CantidadFacturada) '* (1 - (Val(Me.txtdescuento.Text) / 100))
        subtot = Val(CantidadFacturada) * Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        Me.txtPrecio.Text = Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        valdescC = subtot * ((Val(Me.txtdescuento.Text)) / 100)
        
        Me.cmbBODEGA.Enabled = False
        
        prIngresar(Producto, Me.txtDescripcion.Text, Me.cmbUNIDAD_MEDIDA.Text.Trim, Me.txtCantidad.Text, Me.txtPrecio.Text, subtot, Me.cmbUNIDAD_MEDIDA.SelectedValue, 0, 0, 0, 0, valdescC, Val(Me.txtdescuento.Text), CostoU, CostoT)
        'totalizaFactura()
        totalizaFacturanew()
        LimpiaCamposDetalleFactura()
        Me.txtProducto.Focus()
        Me.chkPre_normal.Checked = True
        Me.btnAutocomsumo.Enabled = False
        If Me.lblMaxLineas.Text = 0 Then
            MsgBox("Se ha alcanzado el limite maximo de lineas...", MsgBoxStyle.Critical, "Verificar")
            btnGuardarDetalle.Enabled = False
        End If

    End Sub

    'TODO Método para ingreso de producto facturado al grid de detalle
    Private Sub prIngresar(ByVal producto As String, ByVal descripcion As String, ByVal unidad As String, ByVal cantidad As Double,ByVal precio As Double, ByVal total As Double, ByVal Unidadid As Integer, ByVal idLinea As Integer, ByVal TIPO_MOVIMIENTO As Integer, ByVal MOVIMIENTO As Integer, ByVal ORDEN_VENTA As Integer, ByVal pdescuento As Double, ByVal pporcentaje As Double, ByVal pCostou As Double, ByVal pCostoT As Double)        

        Dim Renglon As DataRow = miDataTable.NewRow()
        Renglon("producto") = producto
        Renglon("descripcion") = descripcion
        Renglon("unidad") = unidad
        Renglon("cantidad") = cantidad
        Renglon("precio") = precio
        Renglon("total") = total
        Renglon("Unidadid") = Unidadid
        Renglon("idLinea") = idLinea
        Renglon("TIPO_MOVIMIENTO") = TIPO_MOVIMIENTO
        Renglon("MOVIMIENTO") = MOVIMIENTO
        Renglon("ORDEN_VENTA") = ORDEN_VENTA
        Renglon("pdescuento") = pdescuento
        Renglon("pporcentaje") = pporcentaje
        Renglon("pCostou") = pCostou
        Renglon("pCostoT") = pCostoT
        miDataTable.Rows.Add(Renglon)

        If dgvCuentasEquivalentes.ColumnCount > 15 Then
            dgvCuentasEquivalentes.Columns.Remove("NUMERO_FACTURA")
            dgvCuentasEquivalentes.Columns.Remove("PRODUCTO")
            dgvCuentasEquivalentes.Columns.Remove("DESCRIPCION_PRODUCTO")
            dgvCuentasEquivalentes.Columns.Remove("CANTIDAD")
            dgvCuentasEquivalentes.Columns.Remove("COSTO_UNITARIO")
            dgvCuentasEquivalentes.Columns.Remove("PRECIO_UNITARIO")
            dgvCuentasEquivalentes.Columns.Remove("PRECIO_TOTAL")
            dgvCuentasEquivalentes.Columns.Remove("ANULADA")
            dgvCuentasEquivalentes.Columns.Remove("FECHA_FACTURA")
            dgvCuentasEquivalentes.Columns.Remove("CAJA")
            dgvCuentasEquivalentes.Columns.Remove("CODIGO_EMPLEADO")
            dgvCuentasEquivalentes.Columns.Remove("FORMA_PAGO")
            dgvCuentasEquivalentes.Columns.Remove("IVA")
            dgvCuentasEquivalentes.Columns.Remove("TOTAL_FACTURA")
            dgvCuentasEquivalentes.Columns.Remove("ORIGEN")
            dgvCuentasEquivalentes.Columns.Remove("TIPO_DOCUMENTO")
            dgvCuentasEquivalentes.Columns.Remove("MOVIMIENTO")
            dgvCuentasEquivalentes.Columns.Remove("CODIGO_EMPLEADO1")
            dgvCuentasEquivalentes.Columns.Remove("NOMBRE_COMPLETO")
            dgvCuentasEquivalentes.Columns.Remove("UNIDAD_MEDIDA")
            dgvCuentasEquivalentes.Columns.Remove("ORDEN_VENTA")
            dgvCuentasEquivalentes.Columns.Remove("TIPO_MOVIMIENTO")

        End If

        Me.dgvCuentasEquivalentes.DataSource = miDataTable
        Me.lblMaxLineas.Text = MaxNumLineas - Me.dgvCuentasEquivalentes.Rows.Count
        If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
            Me.dgvCuentasEquivalentes.FirstDisplayedScrollingRowIndex = Me.dgvCuentasEquivalentes.Rows.Count - 1
        End If

    End Sub

    Private Sub totalizaFacturanew()
        Dim TotIVA, totFactura As Double
        Subtotal = 0
        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            Subtotal += Val(row.Cells("Total").Value)
        Next
        totFactura = Subtotal
        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
        Me.txtIVA.Text = TotIVA.ToString("###0.00")
        Me.txtTotFact.Text = Subtotal.ToString("###0.00")
    End Sub

    Private Sub txtdescuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuento.LostFocus
        If Me.txtdescuento.Text.Length = 0 Then
            Me.txtdescuento.Text = "0.0"
        End If
    End Sub
    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        Dim sqlCmd As New SqlCommand
        Dim Cliente As DataTable
        If Me.txtCliente.Text <> Nothing Then
            If Not Me.chkCliExt.Checked Then
                Me.txtCliente.Text = Me.txtCliente.Text.PadLeft(6, "0")
            End If
            If Not chkCliExt.Checked Then
                Numero = "0"
                datosSocio(Me.txtCliente.Text, Numero)
            Else
                sql = "SELECT NOMBRE, NIT FROM dbo.CONTABILIDAD_CATALOGO_CLIENTES WHERE CLIENTE = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Compañia
                sqlCmd.CommandText = sql
                Cliente = jClass.obtenerDatos(sqlCmd)
                If Cliente.Rows.Count = 1 Then
                    datosCliente(Me.txtCliente.Text, Cliente.Rows(0).Item("NIT"))
                Else
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            End If
        End If
    End Sub

    Private Sub txtProducto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.LostFocus
        If Me.txtProducto.Text <> Nothing Then
            If Me.validarproducto(Me.txtProducto.Text) = False Then
                Return
            End If
            If Me.chkPre_normal.Checked = True Then
                obtieneDatosProducto(Me.txtProducto.Text)
            Else
                Obtenerdatos_pro_PrecioEspecial()
            End If
        End If

    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim cadena As String = sender.Text
        Dim Ocurrencias As Boolean
        Ocurrencias = cadena.Contains(".")
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarDetalle.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> ControlChars.Tab And e.KeyChar <> Convert.ToChar(Keys.Enter) Then
            If e.KeyChar = "." Then
                If Ocurrencias Then
                    MsgBox("Ya hay un punto decimal.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            Else
                If Not IsNumeric(e.KeyChar) Then
                    MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub btnEliminaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaDetalle.Click
        Dim CurRow As DataGridViewRow
        CurRow = Me.dgvCuentasEquivalentes.CurrentRow
        If MsgBox("Está seguro de eliminar este item: " & CurRow.Cells("codProd").Value & " " & CurRow.Cells(1).Value, MsgBoxStyle.YesNo, "Eliminar Item") = MsgBoxResult.No Then
            Return
        End If

        If CurRow.Cells("linea").Value > 0 Then
            GuardaEliminaMovimientoInventarioDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 0, "0", CurRow.Cells("codProd").Value, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, CurRow.Cells("TIPO_MOVIMIENTO").Value, CurRow.Cells("MOVIMIENTO").Value, "DD", TipCosto)
            totRegFact = CurRow.Cells("LINEA").Value
            Numero_OV = CurRow.Cells("ORDEN_VENTA").Value

            GuardaEliminaRegistroFacturaGeneradaDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 27, Me.txtNoFact.Text, CurRow.Cells("codProd").Value, "", 0, 0, 0, 0, 0, 0, 0, 0, "D", 0, 0)
            'TODO Se quita esta funcionalidad de ORden Venta
            ''GuardaEliminaRegistroFacturaDetalleOV(Compañia, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, "", 0, 0, 0, 0, 0, 0, 0, exento, "D")
            ''***
            ''If Me.era_producto_especial(CurRow.Cells("PRODUCTO").Value) Then
            ''    Me.Actualizar_inventario_precio_especial(Compañia, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, CurRow.Cells("PRECIO_UNITARIO").Value, obtener_IDPROD_PRE_ESP(CurRow.Cells("PRODUCTO").Value), CurRow.Cells("CANTIDAD").Value, "A")
            ''    Me.Se_encuentra_producto_especial(CurRow.Cells("PRODUCTO").Value)
            ''End If
            ''***
            ''cargaFacturaDetalle(Me.txtNoFact.Text, Me.cmbTipDoc.SelectedValue, Compañia, Me.cmbBODEGA.SelectedValue)
            Me.dgvCuentasEquivalentes.Rows.RemoveAt(Me.dgvCuentasEquivalentes.CurrentRow.Index)
            lblMaxLineas.Text = Val(lblMaxLineas.Text) + 1
            totalizaFacturanew()
            GuardaEliminaFacturaGeneradaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, codClie, 27, Me.txtNoFact.Text, NRC, TipContrib, exento, CondPago, Me.txtNomFact.Text, Val(Me.txtTotFact.Text), Val(0), Val(Me.txtTotFact.Text), Me.chkImpConcepto.Checked, Me.TextBox30.Text, FORMA_PAGO, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.DateTimePicker1.Value, _
                                Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, _
                                Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, TipClie, TipContrib, dirClie, giro, "U")

        Else
            Me.dgvCuentasEquivalentes.Rows.RemoveAt(Me.dgvCuentasEquivalentes.CurrentRow.Index)
            lblMaxLineas.Text = Val(lblMaxLineas.Text) + 1
            totalizaFacturanew()
        End If
        Me.btnGuardarDetalle.Enabled = True
    End Sub
    Public Sub GuardarTicket(ByVal variable As Integer)

        NumeroFactura()
        Dim intTamnio As Integer = direccion.Trim.Length - 8

        Dim strTipo As String
        If (rbEfectivo.Checked = True) Then
            strTipo = "Contado"
        Else
            strTipo = "Credito"
        End If
        TICKET.AbrirArchivo()
        TICKET.EscribirTicket(direccion.Trim.Substring(0, 7))
        TICKET.EscribirTicket(direccion.Trim.Substring(8, intTamnio))
        TICKET.EscribirTicket("=======================================")
        If variable = 2 Then
            TICKET.EscribirTicket("                ANULADO                ")
            TICKET.EscribirTicket("=======================================")
        End If
        TICKET.EscribirTicket("TICKET # " & correlativo_Actual & " " & descripcion_bodega & " CAJA No." & Caja)
        TICKET.EscribirTicket("FECHA   :" & dpFECHA_CONTABLE.Value.ToString())
        TICKET.EscribirTicket("=======================================")
        TICKET.EscribirTicket("RESOLUCION: " & Me.Resolucion)
        TICKET.EscribirTicket("FECHA DE RESOLUCION: " & Format(Me.fecha_resolucion, "Short Date"))
        TICKET.EscribirTicket("AUTORIZADA: " & Format(Me.fecha_autorizacion, "Short Date"))
        TICKET.EscribirTicket("  DEL " & serie.PadRight(6, "0") & del.PadLeft(6, "0"))
        TICKET.EscribirTicket("   AL " & serie.PadRight(6, "0") & al.PadLeft(6, "0"))
        TICKET.EscribirTicket("=======================================")
        TICKET.EscribirTicket("CODIGO C:" & txtCliente.Text & " " & strTipo)
        TICKET.EscribirTicket("CLIENTE :" & txtNombreCliente.Text)
        TICKET.EscribirTicket("TIEMPO C: -----")
        TICKET.EscribirTicket("=======================================")
        '23 ESPACIOS PARA EL PRODUCTO
        TICKET.EscribirTicket("CANT " & ("PRODUCTO").PadRight(20, " ") & "P/U  PREC.T")

        For i As Integer = 0 To listaTicket.Count - 1
            TICKET.EscribirTicket(listaTicket.Item(i).Trim)
        Next
        TICKET.EscribirTicket("")
        'Dim total As Double, gravada As Double
        Dim descuento2 As Double

        descuento2 = Convert.ToDouble(Me.descuento1)

        TICKET.EscribirTicket("=======================================")
        TICKET.EscribirTicket(("SUBTT. VTA. GRAVADA $:").PadRight(23, " ") & txtTotFact.Text.PadLeft(13, " "))
        TICKET.EscribirTicket(("SUBTT. VTA. EXENTA $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))
        'TICKET.EscribirTicket(("SUBTT. VTA. DISPONIBLE $:").PadRight(25, " ") & ("0.00"))
        TICKET.EscribirTicket(("SUBTT. VTA. NO SUJ. $:").PadRight(23, " ") & ("0.00").PadLeft(13, " "))

        TICKET.EscribirTicket(("VENTA TOTAL. $:").PadRight(23, " ") & txtTotFact.Text.PadLeft(13, " "))
        If (Val(txtTotFact.Text) > 200) Then
            TICKET.EscribirTicket("=======================================")
            TICKET.EscribirTicket("")
            TICKET.EscribirTicket("NOMBRE: ")
            TICKET.EscribirTicket("NIT/DUI:")
            TICKET.EscribirTicket("F.______________")
        End If
        TICKET.EscribirTicket("=======================================")
        TICKET.CerrarArchivo(correlativo_Actual, Caja)
    End Sub
    Public Function NumeroFactura()
        Dim permiso As Integer = 0
        serie = jClass.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & Val(Me.txtCaja.Text) & ",@BANDERA=1", 0)
        correlativo_Actual = jClass.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & Val(Me.txtCaja.Text) & ",@BANDERA=1", 3)
        NoFact1 = correlativo_Actual
        txt_correlativo.Text = correlativo_Actual
        txtNoFact.Text = correlativo_Actual
        Resolucion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Val(Caja) & ", @BANDERA=2", 0)
        fecha_resolucion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Val(Caja) & ", @BANDERA=2", 1)
        fecha_autorizacion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Val(Caja) & ", @BANDERA=2", 2)
        del = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Val(Caja) & ", @BANDERA=2", 3)
        al = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Val(Caja) & ", @BANDERA=2", 4)
        permiso = 1
        If ((serie = Nothing) Or (serie = "")) Or ((correlativo_Actual = Nothing) Or (correlativo_Actual = "")) Or ((Resolucion = Nothing) Or (Resolucion = "")) Or ((fecha_resolucion = Nothing) Or (fecha_resolucion = "")) Or ((fecha_autorizacion = Nothing) Or (fecha_autorizacion = "")) Or ((Val(del) = Nothing) Or (del = "")) Or ((al = Nothing) Or (al = "")) Then
            permiso = 0
        End If
        Return permiso
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _error_ = False
        'realiza las programaciones
        imprimeFactura(Compañia, Me.cmbBODEGA.SelectedValue, 27, Me.txtNoFact.Text, Numero_OV, "Factura no. " & Me.txtNoFact.Text)
        'impresion por ticket
        GuardarTicket(1)
        'ACTUALIZA EL NUMERO DEL TICKET
        jClass.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=4")
        NumeroFactura()
        listaTicket.Clear()
        If Not _error_ Then
            Resetear_montomaximo(Me.txtCliente.Text, "")
            Me.Enabled = True
            Me.Label21.Visible = True
            Me.Label21.Text = "FACTURA IMPRESA DISPONIBLE SOLO PARA CONSULTA"
            Me.btnGuardarDetalle.Enabled = False
            Me.btnEliminaDetalle.Enabled = False
            Me.btnGuardaFacturaEncabezado.Enabled = False
            Me.btnGuardarDetalle.Enabled = False
            MsgBox("Factura No." & Me.txtNoFact.Text & " enviada al impresor.", MsgBoxStyle.Information, "Impresión Factura")
            Me.bntNuevaFact.PerformClick()
        Else
            Me.Enabled = True
        End If
    End Sub

    'Genera Correlativo de las Facturas
    Private Function actualizaCorrelativoFactura(ByVal cia As Integer, ByVal bodega As Integer, ByVal serie As Integer, ByVal tipoDoc As Integer) As Integer
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_GENERA_CORRELATIVOS_SERIES "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", " & 0
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                If DataReader_.Item("CORRELATIVO_ACTUAL").ToString = "-1" Then
                    MsgBox("Serie llegó a su límite. Intente con otra.", MsgBoxStyle.Exclamation, "Mensaje")
                    Return 0
                Else
                    Return DataReader_.Item("CORRELATIVO_ACTUAL")
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            Return 0
        End Try
    End Function

    Private Function validaExistencias(ByVal Producto As Integer, ByVal Bodega As Integer, ByVal Cantidad As Double, ByVal fechafact As DateTime) As Double
        Dim ExistenciaDisponible As Double
        sql = " Execute dbo.sp_INVENTARIOS_VERIFICAR_EXISTENCIAS "
        sql &= Cantidad
        sql &= ", " & Producto
        sql &= ", " & Bodega
        sql &= ", " & Compañia
        sql &= ", '" & Format(fechafact, "Short Date") & "'"
        sql &= ", 1"
        ExistenciaDisponible = jClass.obtenerEscalar(sql)
        Return ExistenciaDisponible
    End Function

    'Carga Historial de Facturas
    Private Sub cargaHistorialFacturas(ByVal cliente As String, ByVal flag As Integer)
        Dim TableX As DataTable
        Conexion_ = multi.devuelveCadenaConexion()
        If cliente = Nothing Then
            cliente = 0
        End If
        Try
            Conexion_.Open()
            sql = " SELECT F.FECHA_FACTURA AS FECHA,T.DESCRIPCION_TIPO_DOCUMENTO AS TIPO,F.NUMERO_FACTURA AS FACTURA,F.TOTAL_FACTURA AS TOTAL,F.CUOTAS,F.PERIODO_PAGO AS PERIODO,F.DESCUENTO_AGUINALDO AS AGUINALDO, F.DESCUENTO_BONIFICACION AS BONIFICACION,F.FACTURA_IMPRESA AS IMPRESA FROM dbo.FACTURACION_GENERADA_ENCABEZADO F, dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO T "
            sql &= "WHERE F.TIPO_DOCUMENTO = T.TIPO_DOCUMENTO"
            sql &= " AND F.CODIGO_EMPLEADO_AS = " & cliente
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            TableX = New DataTable("Datos")
            DataAdapter_.Fill(TableX)
            Me.DataGridView1.Columns.Clear()
            Me.DataGridView1.DataSource = TableX
            'Me.DataGridView1.Columns.Item(2).Visible = False
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub crearFactura_OVEncabezado(ByVal CIA As Integer, _
                                            ByVal Bodega As Integer, _
                                            ByVal fechafact As DateTime, _
                                            ByVal TipDoc As Integer, _
                                            ByVal NoFact1 As String, _
                                            ByVal FormaPago As Integer, _
                                            ByVal codBuxis As String, _
                                            ByVal CodCliente As String, _
                                            ByVal NomFact As String, _
                                            ByVal TelCliente As String, _
                                            ByVal txtDUI As String, _
                                            ByVal txtNIT As String, _
                                            ByVal Concepto As String, _
                                            ByVal impConcepto As Short, _
                                            ByVal SubTotal As String, _
                                            ByVal IVA As String, _
                                            ByVal Total As String, _
                                            ByVal numCuotas As Integer, _
                                            ByVal descontarDesde As Date, _
                                            ByVal descuentoAguinaldo As Double, _
                                            ByVal descuentoBonificacion As Double, _
                                            ByVal periodoPago As String, _
                                            ByVal numRemesa As String, _
                                            ByVal Banco As Integer, _
                                            ByVal Numero_Cta As String)
        _error_ = False
        
        GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact1, NRC, TipContrib, exento, CondPago, NomFact, SubTotal, IVA, Total, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "I")        
    End Sub
    Private Sub crearFactura_OVEncabezado2(ByVal CIA As Integer, _
                                            ByVal Bodega As Integer, _
                                            ByVal fechafact As DateTime, _
                                            ByVal TipDoc As Integer, _
                                            ByVal NoFact1 As String, _
                                            ByVal FormaPago As Integer, _
                                            ByVal codBuxis As String, _
                                            ByVal CodCliente As String, _
                                            ByVal NomFact As String, _
                                            ByVal TelCliente As String, _
                                            ByVal txtDUI As String, _
                                            ByVal txtNIT As String, _
                                            ByVal Concepto As String, _
                                            ByVal impConcepto As Short, _
                                            ByVal SubTotal As String, _
                                            ByVal IVA As String, _
                                            ByVal Total As String, _
                                            ByVal numCuotas As Integer, _
                                            ByVal descontarDesde As Date, _
                                            ByVal descuentoAguinaldo As Double, _
                                            ByVal descuentoBonificacion As Double, _
                                            ByVal periodoPago As String, _
                                            ByVal numRemesa As String, _
                                            ByVal Banco As Integer, _
                                            ByVal Numero_Cta As String)
        _error_ = False

        GuardaEliminaFacturaGeneradaEncabezado2(CIA, Bodega, codClie, TipDoc, NoFact1, NRC, TipContrib, exento, CondPago, NomFact, SubTotal, IVA, Total, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "I")
    End Sub
    Private Sub GrabaDetalleFactura2(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact1 As Integer, ByVal FechaMov As DateTime, _
                                        ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                        ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal SubTotalFact As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                        ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Tot_Factura As Double, ByVal totIVA As Double, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal pordesct As Double, ByVal descuento As Double)
        Dim PrecioUnit As Double
        If exento Then
            PrecioUnit = PrecProd / (1 + (PorcIVA / 100))
        Else
            PrecioUnit = PrecProd
        End If
        _error_ = False
        'TODO TC
        'GuardaEliminaRegistroFacturaDetalleOV(CIA, Bodega, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Grupo, SubGrupo, exento, "I")
        'If Not _error_ Then
        '_error_ = False
        GuardaEliminaRegistroFacturaGeneradaDetalle2(CIA, Bodega, 27, txtNoFact.Text, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Total, Grupo, SubGrupo, "I", pordesct, descuento)
        If Not _error_ Then
            _error_ = False
            'TODO En este punto descarga de inventario antes de procesar la factura
            GuardaEliminaMovimientoInventarioDetalle2(CIA, Bodega, 27, txtNoFact.Text, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, TipDoc, Val(NoFact1)), "I", TipCosto)
            'If FactCreada And Not _error_ Then
            '    GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, numdoc, NRC, TipClie, exento, CondPago, NomFact, SubTotalFact, totIVA, Tot_Factura, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "U")
            'End If
        End If
        'End If
    End Sub
    Private Sub GrabaDetalleFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact1 As Integer, ByVal FechaMov As DateTime, _
                                    ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                    ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal SubTotalFact As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                    ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Tot_Factura As Double, ByVal totIVA As Double, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal pordesct As Double, ByVal descuento As Double)
        Dim PrecioUnit As Double
        If exento Then
            PrecioUnit = PrecProd / (1 + (PorcIVA / 100))
        Else
            PrecioUnit = PrecProd
        End If
        _error_ = False
        'TODO TC
        'GuardaEliminaRegistroFacturaDetalleOV(CIA, Bodega, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Grupo, SubGrupo, exento, "I")
        'If Not _error_ Then
        '_error_ = False
        GuardaEliminaRegistroFacturaGeneradaDetalle(CIA, Bodega, 27, txtNoFact.Text, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Total, Grupo, SubGrupo, "I", pordesct, descuento)
        If Not _error_ Then
            _error_ = False
            'TODO En este punto descarga de inventario antes de procesar la factura
            GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, 27, txtNoFact.Text, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, TipDoc, Val(NoFact1)), "I", TipCosto)
            'If FactCreada And Not _error_ Then
            '    GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, numdoc, NRC, TipClie, exento, CondPago, NomFact, SubTotalFact, totIVA, Tot_Factura, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "U")
            'End If
        End If
        'End If
    End Sub

    Private Function obtieneCostoProducto(ByVal CIA As Integer, ByVal bodega As Integer, ByVal producto As Integer, ByVal fecha As DateTime, ByVal tipoCosto As Integer) As Double
        Dim sqlCmd As New SqlCommand
        If tipoCosto = 2 Then
            sql = "SELECT dbo.INVENTARIOS_CALCULAR_COSTOS_UEPS("
        Else
            sql = "SELECT dbo.INVENTARIOS_CALCULAR_COSTOS("
        End If
        sql &= CIA
        sql &= ", " & bodega
        sql &= ", " & producto
        sql &= ", '" & Format(fecha, "Short Date") & "') AS Costo_Unitario"
        Try
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count = 1 Then
                Return Table.Rows(0).Item("Costo_Unitario")
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Function

    Private Sub cargaFacturaDetalle(ByVal numfact As String, ByVal tipdoc As Integer, ByVal CIA As Integer, ByVal Bodega As Integer)
        Dim sqlCmd As New SqlCommand
        Dim descAguin, descBoni, AhorroE, ivaFact, grandesc As Double
        '
        Me.generaGrid()
        '
        If Not Iniciando Then
            Try
                sql = "SELECT FGE.NUMERO_FACTURA, FGE.SERIE, FGE.BODEGA, FGE.ORDEN_VENTA, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGE.ANULADA, FGE.NOMBRE_FACTURA, FGE.PERIODO_PAGO, FGE.CUOTAS, FGE.DESCONTAR_CUOTAS_DESDE, FGE.DESCUENTO_AGUINALDO, FGE.DESCUENTO_BONIFICACION, FGE.NUMERO_REMESA, FGE.SUB_TOTAL, FGE.TOTAL_IVA, FGE.TOTAL_FACTURA, FGE.CLIENTE, FGE.NIT, FGE.BANCO_REMESA, FGE.CUENTA_BANCO_REMESA, FGE.AHORRO_EXTRA, FGE.RETENCION "
                sql &= "FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE"
                sql &= " WHERE FGE.COMPAÑIA = " & CIA
                sql &= " AND FGE.BODEGA = " & Bodega
                sql &= " AND FGE.TIPO_DOCUMENTO = " & 27
                sql &= " AND FGE.NUMERO_FACTURA = " & txt_correlativo.Text
                sqlCmd.CommandText = sql
                Table2 = jClass.obtenerDatos(sqlCmd)
                If Table2.Rows.Count > 0 Then
                    FactCreada = True
                    If Table2.Rows(0).Item("ANULADA") Then
                        Me.Label21.Text = "FACTURA ANULADA DISPONIBLE SOLO PARA CONSULTA"                        
                    ElseIf Table2.Rows(0).Item("FACTURA_IMPRESA") Then
                        Me.Label21.Text = "FACTURA IMPRESA DISPONIBLE SOLO PARA CONSULTA"                                                
                    Else
                        btnProcesar.Enabled = True
                    End If
                    Me.Label21.Visible = Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Numero_Serie = Table2.Rows(0).Item("SERIE")
                    Numero_OV = Table2.Rows(0).Item("ORDEN_VENTA")
                    Me.dpFECHA_CONTABLE.Value = Table2.Rows(0).Item("FECHA_FACTURA")
                    Me.cmbBODEGA.SelectedValue = Table2.Rows(0).Item("BODEGA")
                    If Table2.Rows(0).Item("CLIENTE") = 0 Then
                        Me.txtCliente.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO_AS")
                        Me.lblCodBuxis.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO")
                        datosSocio(Me.txtCliente.Text, Me.lblCodBuxis.Text)
                        Me.chkCliExt.Checked = False
                    Else
                        Me.txtCliente.Text = Table2.Rows(0).Item("CLIENTE")
                        Me.lblCodBuxis.Text = "0"
                        datosCliente(Me.txtCliente.Text, Table2.Rows(0).Item("NIT"))
                        Me.chkCliExt.Checked = True
                    End If
                    'Me.txtCliente.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    'Me.lblCodBuxis.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO")
                    FORMA_PAGO = Table2.Rows(0).Item("FORMA_PAGO")
                    Me.cmbPeriodoPago.SelectedValue = Table2.Rows(0).Item("PERIODO_PAGO")
                    Me.txtNumCuotas.Text = Table2.Rows(0).Item("CUOTAS")
                    If Table2.Rows(0).Item("FORMA_PAGO") = 1 Then
                        Me.txtNoRemesa.Text = Table2.Rows(0).Item("NUMERO_REMESA")
                        Me.cmbBancos.SelectedValue = Table2.Rows(0).Item("BANCO_REMESA")
                        Me.cmbCtasBanco.SelectedValue = Table2.Rows(0).Item("CUENTA_BANCO_REMESA")
                    End If                    
                    ivaFact = Table2.Rows(0).Item("TOTAL_IVA")                    
                    descAguin = Table2.Rows(0).Item("DESCUENTO_AGUINALDO")
                    descBoni = Table2.Rows(0).Item("DESCUENTO_BONIFICACION")
                    AhorroE = Table2.Rows(0).Item("AHORRO_EXTRA")
                    grandesc = Table2.Rows(0).Item("RETENCION")
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue                    
                    Me.txtDescAGUI.Text = descAguin.ToString("0.00")
                    Me.txtDescBONI.Text = descBoni.ToString("0.00")
                    Me.txtAhorroExt.Text = AhorroE.ToString("0.00")
                    Me.txtGranDescuento.Text = grandesc.ToString("0.00")
                    Me.btnGuardarDetalle.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.btnEliminaDetalle.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.btnGuardaFacturaEncabezado.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.cmbBODEGA.Enabled = False
                    'datosSocio(Me.txtCliente.Text, Me.lblCodBuxis.Text)
                    Me.txtNomFact.Text = Table2.Rows(0).Item("NOMBRE_FACTURA")
                    sql = "SELECT FGD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, FGD.CANTIDAD, FGD.PRECIO_UNITARIO, FGD.PRECIO_TOTAL, FGD.BODEGA, FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO, FGE.NUMERO_FACTURA, FGE.ANULADA, FGD.LINEA, IME.TIPO_MOVIMIENTO, IME.MOVIMIENTO, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.IMPRIMIR_CONCEPTO, FGE.CONCEPTO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGD.unidad_medida, PORCENTAJE_DESCUENTO, VALOR_DESCUENTO  FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_GENERADA_DETALLE FGD,dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM WHERE FGE.BODEGA = FGD.BODEGA AND FGE.COMPAÑIA = FGD.COMPAÑIA AND FGE.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO AND FGE.NUMERO_FACTURA = FGD.NUMERO_FACTURA AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FGD.PRODUCTO = IMD.PRODUCTO AND FGD.COMPAÑIA = ICP.COMPAÑIA AND FGD.PRODUCTO = ICP.PRODUCTO AND ICUM.COMPAÑIA = FGD.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA AND IMD.ENTRADA_SALIDA = 0"
                    sql &= " AND FGE.COMPAÑIA = " & CIA
                    sql &= " AND FGE.BODEGA = " & Bodega
                    sql &= " AND FGE.TIPO_DOCUMENTO = " & 27
                    sql &= " AND FGE.NUMERO_FACTURA = " & txt_correlativo.Text
                    sql &= " ORDER BY FGD.LINEA"
                    sqlCmd.CommandText = sql
                    Table = jClass.obtenerDatos(sqlCmd)

                    '**** 
                    For Each dr As DataRow In Table.Rows
                        prIngresar(dr.Item("PRODUCTO"), dr.Item("DESCRIPCION_PRODUCTO"), dr.Item("DESCRIPCION_UNIDAD_MEDIDA"), dr.Item("CANTIDAD"), dr.Item("PRECIO_UNITARIO"), dr.Item("PRECIO_TOTAL"), dr.Item("unidad_medida"), dr.Item("linea"), dr.Item("TIPO_MOVIMIENTO"), dr.Item("MOVIMIENTO"), dr.Item("ORDEN_VENTA"), dr.Item("VALOR_DESCUENTO"), dr.Item("PORCENTAJE_DESCUENTO"), 0, 0)
                    Next

                    For a As Integer = 6 To Me.dgvCuentasEquivalentes.Columns.Count - 1
                        Me.dgvCuentasEquivalentes.Columns(a).Visible = False
                    Next

                    Me.dgvCuentasEquivalentes.Columns(11).Visible = True
                    Me.dgvCuentasEquivalentes.Columns(12).Visible = True

                    If Me.dgvCuentasEquivalentes.Rows.Count > 9 Then
                        Me.dgvCuentasEquivalentes.Width = 707
                    Else
                        Me.dgvCuentasEquivalentes.Width = 694
                    End If
                    If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
                        Me.dgvCuentasEquivalentes.FirstDisplayedScrollingRowIndex = Me.dgvCuentasEquivalentes.Rows.Count - 1
                    End If
                Else
                    Numero_OV = 0
                    FactCreada = False
                    limpiaCampos(0)
                    Me.cmbBODEGA.Enabled = True
                End If
                Me.lblMaxLineas.Text = MaxNumLineas - Me.dgvCuentasEquivalentes.Rows.Count
                If Not Me.Label21.Visible Then
                    If MaxNumLineas - Me.dgvCuentasEquivalentes.Rows.Count = 0 Then
                        'MsgBox("Numero Maximo de líneas en detalle alcalzado." & vbCrLf & "No se puede agregar mas productos.", MsgBoxStyle.Critical, "Detalle Factura Completo")
                        Me.btnGuardarDetalle.Enabled = False
                    Else
                        Me.btnGuardarDetalle.Enabled = True
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Cargar Factura")
            End Try
        End If
    End Sub

    Private Sub txtNoFact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFact.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txtNumTicket.Text = txtNoFact.Text
            cargarFactura()
        End If
    End Sub
    
    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle2(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal Accion As String, ByVal portdes As Double, ByVal descuento As Double)
        Dim corre As Integer
        Dim sqlcmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_FACTURACION_GENERADA_DETALLE_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & Numero_OV
            sql &= ", " & 27
            sql &= ", " & NoFact1
            sql &= ", " & totRegFact
            sql &= ", " & codProd
            sql &= ", '" & descProd & "'"
            sql &= ", " & UM
            sql &= ", " & Cant
            sql &= ", 1"
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", " & PrecProd
            sql &= ", " & Total
            sql &= ", " & Grupo
            sql &= ", " & SubGrupo
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & portdes
            sql &= ", " & descuento
            sqlcmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlcmd)
            'MsgBox("Registros actualizados: " + corre.ToString, MsgBoxStyle.Exclamation, "Factura Detalle")
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Detalle")
            _error_ = True
        End Try
    End Sub
    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal Accion As String, ByVal portdes As Double, ByVal descuento As Double)
        Dim corre As Integer
        Dim sqlcmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_FACTURACION_GENERADA_DETALLE_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & Numero_OV
            sql &= ", " & 27
            sql &= ", " & NoFact1
            sql &= ", " & totRegFact
            sql &= ", " & codProd
            sql &= ", '" & descProd & "'"
            sql &= ", " & UM
            sql &= ", " & Cant
            sql &= ", 0"
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", " & PrecProd
            sql &= ", " & Total
            sql &= ", " & Grupo
            sql &= ", " & SubGrupo
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & portdes
            sql &= ", " & descuento
            sqlcmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlcmd)
            'MsgBox("Registros actualizados: " + corre.ToString, MsgBoxStyle.Exclamation, "Factura Detalle")
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Detalle")
            _error_ = True
        End Try
    End Sub
    Public Sub NumeroMovimiento()
        Mov = jClass.leerDataeader("SELECT ISNULL(MAX(MOVIMIENTO),0)+1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Bodega & " AND TIPO_MOVIMIENTO=2", 0)
    End Sub
    Private Sub GuardaEliminaMovimientoInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov1 As Integer, ByVal Accion As String, ByVal tipoCosto As Integer)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", 0" 'PROVEEDOR?
            sql &= ", " & 2 'TIPO_MOVIMIENTO
            sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            sql &= ", 0" 'MOV1
            sql &= ", " & 27 'TIPO_DOCUMENTO_CONTABLE
            sql &= ", " & NoFact1 'NUMERO_DOCUMENTO_CONTABLE
            sql &= ", '" & Format(FechaMov, "Short Date") & "'" 'FECHA MOVIMIENTO
            sql &= ", 0" 'ANULADO?
            sql &= ", 1" 'PROCESADO
            sql &= ", " & codProd
            sql &= ", " & Cant
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", 0" 'ENTRADA_SALIDA
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & Numero_OV 'ORDEN_VENTA
            sqlCmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            If corre > 0 And tipoCosto = 2 Then
                'Para actualizar las cantidades por los costos UEPS
                If Accion = "D" Or Accion = "DD" Then
                    Cant = -(Cant)
                End If
                sqlCmd.CommandText = "Execute sp_INVENTARIOS_INGRESAR_COMPRAS @COMPAÑIA = " & CIA & ", @BODEGA = " & Bodega & ", @PRODUCTO = " & codProd & ", @ENTRADAS = 0, @SALIDAS = " & Cant & ", @BANDERA = 'O'"
                corre = jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje Inventario Detalle")
            _error_ = True
        End Try
    End Sub
    Private Sub GuardaEliminaMovimientoInventarioDetalle2(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov1 As Integer, ByVal Accion As String, ByVal tipoCosto As Integer)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", 0" 'PROVEEDOR?
            sql &= ", " & 2 'TIPO_MOVIMIENTO
            sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            sql &= ", 0" 'MOV1
            sql &= ", " & 27 'TIPO_DOCUMENTO_CONTABLE
            sql &= ", " & NoFact1 'NUMERO_DOCUMENTO_CONTABLE
            sql &= ", '" & Format(FechaMov, "Short Date") & "'" 'FECHA MOVIMIENTO
            sql &= ", 1" 'ANULADO?
            sql &= ", 1" 'PROCESADO
            sql &= ", " & codProd
            sql &= ", " & Cant
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", 1" 'ENTRADA_SALIDA
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & Numero_OV 'ORDEN_VENTA
            sqlCmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            If corre > 0 And tipoCosto = 2 Then
                'Para actualizar las cantidades por los costos UEPS
                If Accion = "D" Or Accion = "DD" Then
                    Cant = -(Cant)
                End If
                sqlCmd.CommandText = "Execute sp_INVENTARIOS_INGRESAR_COMPRAS @COMPAÑIA = " & CIA & ", @BODEGA = " & Bodega & ", @PRODUCTO = " & codProd & ", @ENTRADAS = 0, @SALIDAS = " & Cant & ", @BANDERA = 'O'"
                corre = jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje Inventario Detalle")
            _error_ = True
        End Try
    End Sub
    Private Sub GuardaEliminaFacturaGeneradaEncabezado2(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                            ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                            ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                            ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, _
                                                            ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal TipClie As Integer, ByVal TipContrib As Integer, ByVal dirClie As String, ByVal giro As String, ByVal Accion As String)

        ''TCENCGENERADAS
        Dim totReg, corre As Integer
        Dim Retencion As Double = 0
        Dim sqlCmd As New SqlCommand
        Try
            If DescuentoAguinaldo = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                Me.cmbPeriodoPago.SelectedValue = "AG"
                periodoPago = "AG"
            End If
            If DescuentoBonificacion = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                Me.cmbPeriodoPago.SelectedValue = "BO"
                periodoPago = "BO"
            End If
            If DescuentoAguinaldo + DescuentoBonificacion = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                periodoPago = "AG"
            End If
            ''If (TipoContribuyente = 1 Or TipoContribuyente = 2) And TipDoc = 2 And Not exento And Contribuyente = 3 Then
            Retencion = CDbl(txtGranDescuento.Text)
            ''End If
            If periodoPago = "BO" Then
                descontarDesde = CDate("12/06/" & Now.Year.ToString)
                If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
                    descontarDesde = descontarDesde.AddYears(1)
                End If
            End If
            If periodoPago = "AG" Then
                descontarDesde = CDate("12/12/" & Now.Year.ToString)
                If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
                    descontarDesde = descontarDesde.AddYears(1)
                End If
            End If
            If Not FactCreada Then
                Numero_OV = obtieneMAXOV(Compañia)
            End If
            If Accion = "I" Then
                NumeroFactura()                
            End If
            sql = " Execute dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & Numero_OV
            sql &= ", " & Me.txtNoFact.Text
            sql &= ", '" & NomFact & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", " & codCliente
            sql &= ", " & Numero_Serie
            sql &= ", " & CC 'CENTRO COSTO
            sql &= ", " & 5
            sql &= ", " & FormaPago
            sql &= ", '" & periodoPago & "'"
            sql &= ", " & Condicion
            sql &= ", " & codBuxis
            sql &= ", '" & codSocio & "'"
            sql &= ", " & TipoContribuyente
            sql &= ", '" & txtDUI & "'"
            sql &= ", '" & txtNIT & "'"
            sql &= ", '" & NRCCliente & "'"
            sql &= ", " & es_exento
            sql &= ", " & impConcepto
            sql &= ", '" & Concepto & "'"
            sql &= ", " & Subtotal
            sql &= ", " & PorcIVA
            sql &= ", " & IVA
            sql &= ", " & Retencion
            sql &= ", " & Total
            sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            sql &= ", " & DescuentoAguinaldo
            sql &= ", " & DescuentoBonificacion
            sql &= ", '" & NumRemesa & "'"
            sql &= ", 1" 'ANULADA?
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & IIf(FormaPago = 1, Banco, 0)
            sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", " & TipClie
            sql &= ", " & TipContrib
            sql &= ", '" & dirClie & "'"
            sql &= ", '" & giro & "'"
            sql &= ", ''" 'Observaciones
            sql &= ", " & txtCaja.Text

            sqlCmd.CommandText = sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If totReg > 0 And Not FactCreada Then
                corre = FPro.actualizaNumDoc(CIA, "OV")
            End If
            If Val(Me.txtAhorroExt.Text) > 0 Then
                sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET AHORRO_EXTRA = " & Val(Me.txtAhorroExt.Text)
                sql &= " WHERE COMPAÑIA = " & CIA & " AND BODEGA = " & Bodega & " AND ORDEN_VENTA = " & Numero_OV
                sql &= " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & Me.txtNoFact.Text
                sqlCmd.CommandText = sql
                jClass.ejecutarComandoSql(sqlCmd)
            End If
            'TC III
            If Me.intCodAutoconsumo > 0 Then
                prRegistroAutorizacion(intCodAutoconsumo, 1, Me.txtNoFact.Text, Numero_OV, 0)
            End If

            FactCreada = True
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Encabezado")
            _error_ = True
        End Try
    End Sub
    Private Sub GuardaEliminaFacturaGeneradaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact1 As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                        ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                        ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                        ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, _
                                                        ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal TipClie As Integer, ByVal TipContrib As Integer, ByVal dirClie As String, ByVal giro As String, ByVal Accion As String)

        ''TCENCGENERADAS
        Dim totReg, corre As Integer
        Dim Retencion As Double = 0
        Dim sqlCmd As New SqlCommand
        Try
            If DescuentoAguinaldo = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                Me.cmbPeriodoPago.SelectedValue = "AG"
                periodoPago = "AG"
            End If
            If DescuentoBonificacion = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                Me.cmbPeriodoPago.SelectedValue = "BO"
                periodoPago = "BO"
            End If
            If DescuentoAguinaldo + DescuentoBonificacion = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                periodoPago = "AG"
            End If
            ''If (TipoContribuyente = 1 Or TipoContribuyente = 2) And TipDoc = 2 And Not exento And Contribuyente = 3 Then
            Retencion = CDbl(txtGranDescuento.Text)
            ''End If
            If periodoPago = "BO" Then
                descontarDesde = CDate("12/06/" & Now.Year.ToString)
                If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
                    descontarDesde = descontarDesde.AddYears(1)
                End If
            End If
            If periodoPago = "AG" Then
                descontarDesde = CDate("12/12/" & Now.Year.ToString)
                If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
                    descontarDesde = descontarDesde.AddYears(1)
                End If
            End If
            If Not FactCreada Then
                Numero_OV = obtieneMAXOV(Compañia)
            End If
            If Accion = "I" Then
                NumeroFactura()
                Me.txtNoFact.Text = NoFact1
            End If
            sql = " Execute dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & Numero_OV
            sql &= ", " & NoFact1
            sql &= ", '" & NomFact & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", " & codCliente
            sql &= ", " & Numero_Serie
            sql &= ", " & CC 'CENTRO COSTO
            sql &= ", " & 5
            sql &= ", " & FormaPago
            sql &= ", '" & periodoPago & "'"
            sql &= ", " & Condicion
            sql &= ", " & codBuxis
            sql &= ", '" & codSocio & "'"
            sql &= ", " & TipoContribuyente
            sql &= ", '" & txtDUI & "'"
            sql &= ", '" & txtNIT & "'"
            sql &= ", '" & NRCCliente & "'"
            sql &= ", " & es_exento
            sql &= ", " & impConcepto
            sql &= ", '" & Concepto & "'"
            sql &= ", " & Subtotal
            sql &= ", " & PorcIVA
            sql &= ", " & IVA
            sql &= ", " & Retencion
            sql &= ", " & Total
            sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            sql &= ", " & DescuentoAguinaldo
            sql &= ", " & DescuentoBonificacion
            sql &= ", '" & NumRemesa & "'"
            sql &= ", 0" 'ANULADA?
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & IIf(FormaPago = 1, Banco, 0)
            sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", " & TipClie
            sql &= ", " & TipContrib
            sql &= ", '" & dirClie & "'"
            sql &= ", '" & giro & "'"
            sql &= ", ''" 'Observaciones
            sql &= ", " & txtCaja.Text

            sqlCmd.CommandText = sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If totReg > 0 And Not FactCreada Then
                corre = FPro.actualizaNumDoc(CIA, "OV")
            End If
            If Val(Me.txtAhorroExt.Text) > 0 Then
                sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET AHORRO_EXTRA = " & Val(Me.txtAhorroExt.Text)
                sql &= " WHERE COMPAÑIA = " & CIA & " AND BODEGA = " & Bodega & " AND ORDEN_VENTA = " & Numero_OV
                sql &= " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & NoFact1
                sqlCmd.CommandText = sql
                jClass.ejecutarComandoSql(sqlCmd)
            End If
            'TC III
            If Me.intCodAutoconsumo > 0 Then
                prRegistroAutorizacion(intCodAutoconsumo, 1, NoFact1, Numero_OV, 0)
            End If

            FactCreada = True
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Encabezado")
            _error_ = True
        End Try
    End Sub

    Private Sub bntNuevaFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevaFact.Click
        Me.limpiaCampos(0)
        i = 0
        Me.cmbBODEGA.Enabled = True
        Me.producto_especial = 0
        Me.cantidad_precio_especial = 0
        Me.chkPre_normal.Checked = True
        btnProcesar.Enabled = True
        Erase Me.productos_facturados
        Me.dgvCuentasEquivalentes.Refresh()
        ReDim Me.productos_facturados(100, 2)        
        Me.txtIVA.Text = 0
        txtTotFact.Text = 0
        Bloquear_Desbloquear(True)
        Label21.Visible = False
    End Sub

    Private Function ValidaNumeroFacturaSerie(ByVal NoFact1 As Integer) As Boolean
        Dim sqlCmd As New SqlCommand
        sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
        sql &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", '0'" 'DESCRIPCION_SERIE
        sql &= ", " & 27
        sql &= ", 1" 'BANDERA
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            For a As Integer = 0 To Table.Rows.Count - 1
                If Table.Rows(a).Item("Activa") Then
                    If NoFact1 >= Table.Rows(a).Item("Inicio") And NoFact1 <= Table.Rows(a).Item("Final") And Table.Rows(a).Item("Activa") Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Private Sub generaGrid()
        Dim rowcount As Integer
        Me.dgvCuentasEquivalentes.AllowUserToAddRows = False
        Try
            rowcount = dgvCuentasEquivalentes.RowCount
            If rowcount > 0 Then
                For a As Integer = 0 To rowcount - 1
                    dgvCuentasEquivalentes.Rows.RemoveAt(0)
                Next
            End If            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardaFacturaEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaFacturaEncabezado.Click
        If Not validaCamposVacios() Then
            Return
        End If
        _error_ = False
        
        If Not _error_ And MSJ Then
            MsgBox("Factura Actualizada con éxito", MsgBoxStyle.Information, "Guardar")

        End If
    End Sub

    

    Private Function validaCamposVacios() As Boolean
        If Me.txtCliente.Text = Nothing Then
            MsgBox("Ingrese un codigo de Socio", MsgBoxStyle.Critical, "Campo Socio Vacio")
            Me.txtCliente.Focus()
            Return False
        End If
        If Me.txtNomFact.Text = Nothing Then
            MsgBox("Ingrese un Nombre para la Factura", MsgBoxStyle.Critical, "Campo Nombre Factura Vacio")
            Me.txtCliente.Focus()
            Return False
        End If
        'If Me.DateTimePicker1.Value.Date < Now.Date Then
        '    MsgBox("Fecha de inicio descuento " & vbCrLf & "no puede ser menor que hoy", MsgBoxStyle.Critical, "Fecha Errónea")
        '    Me.DateTimePicker1.Focus()
        '    Return False
        'End If
        If Val(Me.txtNumCuotas.Text) = 0 And FORMA_PAGO = 2 And (Me.cmbPeriodoPago.SelectedValue = "QQ" Or Me.cmbPeriodoPago.SelectedValue = "MM") Then
            MsgBox("Número Cuotas debe ser mayor que cero", MsgBoxStyle.Critical, "Cuotas No Válido")
            Return False
        End If
        Return True
    End Function

    Private Sub cmbUNIDAD_MEDIDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUNIDAD_MEDIDA.SelectedIndexChanged
        If Not Iniciando Then
            Me.cmbUNIDAD_MEDIDA.SelectedIndex = UMIndex
        End If
    End Sub

    Private Sub chkCliExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliExt.CheckedChanged
        Me.txtNumCuotas.Visible = Not sender.checked
        Me.txtDescAGUI.Visible = Not sender.checked
        Me.txtDescBONI.Visible = Not sender.checked
        Me.Label20.Visible = Not sender.checked
        Me.Label19.Visible = Not sender.checked
        Me.Label18.Visible = Not sender.checked
        Me.lblDispSocio.Visible = Not sender.checked
        Me.Label16.Visible = Not sender.checked
        Me.Label5.Visible = Not sender.checked
        Me.Label2.Visible = Not sender.checked
        Me.cmbPeriodoPago.Visible = Not sender.checked
        Me.DateTimePicker1.Visible = Not sender.checked
        Me.cmbCONDICION_PAGO.Visible = sender.checked
        Me.Label22.Visible = sender.checked
        Me.CheckDisponible.Visible = Not sender.checked
        Me.Label7.Visible = Not sender.checked
        Me.lblCodBuxis.Visible = Not sender.checked
        Me.Label23.Visible = Not sender.checked
        Me.txtAhorroExt.Visible = Not sender.checked
        If sender.checked Then
            Me.Label8.Text = "Cliente    :"
            Me.Label13.Text = "Nombre Cliente:"
            Me.TabPage2.Text = "Historial Facturas del Cliente"            
        Else
            Me.Label8.Text = "Codigo AS  :"
            Me.Label13.Text = "Nombre AS :"
            Me.TabPage2.Text = "Historial Facturas del Socio"            
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Iniciando Then
            multi.CargaCondicionPago(Compañia, FORMA_PAGO, Me.cmbCONDICION_PAGO)
            Me.cmbCONDICION_PAGO.SelectedIndex = 0
            CondPago = Me.cmbCONDICION_PAGO.SelectedValue
            If FORMA_PAGO = 2 Then
                Me.txtNumCuotas.Text = "1"
            Else
                Me.txtNumCuotas.Text = "0"
            End If
            If FORMA_PAGO = 1 Then
                Me.Label17.Visible = True
                Me.Label28.Visible = True
                Me.Label29.Visible = True
                Me.txtNoRemesa.Visible = True
                Me.cmbBancos.Visible = True
                Me.cmbCtasBanco.Visible = True
                Me.cmbBancos.SelectedIndex = 2
            Else
                Me.Label17.Visible = False
                Me.Label28.Visible = False
                Me.Label29.Visible = False
                Me.txtNoRemesa.Visible = False
                Me.cmbBancos.Visible = False
                Me.cmbCtasBanco.Visible = False
            End If
        End If
    End Sub

    Private Sub cmbCONDICION_PAGO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCONDICION_PAGO.SelectedIndexChanged
        If Not Iniciando Then
            CondPago = sender.SelectedValue
        End If
    End Sub

    Private Sub imprimeFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal numFactura As Integer, ByVal numPedido As Integer, ByVal Observ As String)
        Dim sqlCmd As New SqlCommand
        Dim totFact, descPeriodos As Double
        Dim numSoli As Integer
        Dim NumPartida As Integer = 0
        Dim CtaContable As Integer = 0
        Dim descAgui As Double = Val(Me.txtDescAGUI.Text)
        Dim descBoni As Double = Val(Me.txtDescBONI.Text)
        Dim AhorrosExt As Double = Val(Me.txtAhorroExt.Text)
        'Dim documento As CrystalDecisions.CrystalReports.Engine.ReportClass
        Me.btnGuardaFacturaEncabezado.PerformClick()
        MSJ = False
        If Val(Me.txtTotFact.Text) > 0 Then
            If AhorrosExt >= Val(Me.txtTotFact.Text) And Val(Me.txtTotFact.Text) > 0 And FORMA_PAGO = 2 Then
                FORMA_PAGO = 1
                Me.btnGuardaFacturaEncabezado_Click(Me.btnGuardaFacturaEncabezado, New System.EventArgs)
            End If
            '-------------------------------------------
            If Me.cmbPeriodoPago.SelectedValue = "AG" And Val(Me.txtTotFact.Text) > 0 And descBoni = 0 Then
                descAgui = Val(Me.txtTotFact.Text)
                Me.txtDescAGUI.Text = Me.txtTotFact.Text
                Me.btnGuardaFacturaEncabezado_Click(Me.btnGuardaFacturaEncabezado, New System.EventArgs)
            End If
            If Me.cmbPeriodoPago.SelectedValue = "BO" And Val(Me.txtTotFact.Text) > 0 And descAgui = 0 Then
                descBoni = Val(Me.txtTotFact.Text)
                Me.txtDescBONI.Text = Me.txtTotFact.Text
                Me.btnGuardaFacturaEncabezado_Click(Me.btnGuardaFacturaEncabezado, New System.EventArgs)
            End If
            '-------------------------------------------
            If descAgui >= Val(Me.txtTotFact.Text) And Val(Me.txtTotFact.Text) > 0 Then
                Me.cmbPeriodoPago.SelectedValue = "AG"
                Me.btnGuardaFacturaEncabezado_Click(Me.btnGuardaFacturaEncabezado, New System.EventArgs)
            End If
            If descBoni >= Val(Me.txtTotFact.Text) And Val(Me.txtTotFact.Text) > 0 Then
                Me.cmbPeriodoPago.SelectedValue = "BO"
                Me.btnGuardaFacturaEncabezado_Click(Me.btnGuardaFacturaEncabezado, New System.EventArgs)
            End If
            If AhorrosExt > Val(Me.txtTotFact.Text) Or (descAgui + descBoni + AhorrosExt) > Val(Me.txtTotFact.Text) Then
                MsgBox("La suma de :" & vbCrLf & "Descuento Aguinaldo," & vbCrLf & "Descuento Bonificacion" & vbCrLf & "Ahorro Extraordinario" & vbCrLf & "es mayor que el monto total de la factura." & vbCrLf & vbCrLf & "Revisar valores de descuentos.", MsgBoxStyle.Exclamation, "Ahorro Extraordinario")
                _error_ = True
                MSJ = True
                Me.txtAhorroExt.Focus()
                Return
            End If
        End If        

        'Try                        

        totFact = Val(txtTotFact.Text)

        If Not Me.chkCliExt.Checked And Not Label21.Visible And FORMA_PAGO = 2 Then
            If CInt(jClass.obtenerEscalar("SELECT COUNT(NUMERO_FACTURA) FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE NUMERO_FACTURA = " & numFactura & " AND CODIGO_BUXIS = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Compañia)) = 0 Then
                descPeriodos = totFact - descAgui - descBoni - AhorrosExt
                numSoli = FPro.actualizaNumDoc(CIA, "SOL")
                Dim CodDeduc As Integer
                CodDeduc = CInt(jClass.obtenerEscalar("SELECT DEDUCCION FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE SOLICITUD = " & TipoSolicitud & " AND COMPAÑIA = " & Compañia))
                If CodDeduc = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 18 AND COMPAÑIA = " & Compañia)) Then
                    Me.txtNumCuotas.Text = "1"
                    Me.DateTimePicker1.Value = setFechaPago()
                End If
                'TODO Se desahabilita esta función para solventar mensaje de error al imprimir
                'Se activa nuevamente con la entrada en funcionamiento del módulo de Cooperativa
                FPro.SolicitudesFacturacionSocios(CIA, TipoSolicitud, numSoli, Me.txtCliente.Text, Me.lblCodBuxis.Text, Me.dpFECHA_CONTABLE.Value, 1, descPeriodos, descAgui, descBoni, Me.cmbPeriodoPago.SelectedValue, Me.txtNumCuotas.Text, Me.DateTimePicker1.Value, "Factura No. " & txtNoFact.Text & " Generada en " & Me.cmbBODEGA.Text, TipDoc, txtNoFact.Text)
            End If
        End If
        If AhorrosExt > 0 Then
            Dim NumRetiro As Integer
            NumRetiro = jClass.obtenerEscalar("SELECT ISNULL(MAX([RETIRO]), 0) + 1 FROM [dbo].[COOPERATIVA_SOCIO_RETIROS] WHERE COMPAÑIA = " & CIA)
            sql = "INSERT INTO [COOPERATIVA_SOCIO_RETIROS]"
            sql &= "([RETIRO]"
            sql &= ",[COMPAÑIA]"
            sql &= ",[CODIGO_EMPLEADO]"
            sql &= ",[CODIGO_EMPLEADO_AS]"
            sql &= ",[BANCO]"
            sql &= ",[CANTIDAD]"
            sql &= ",[ESTADO]"
            sql &= ",[BANCO_EMITIDO]"
            sql &= ",[TIPO_DOCUMENTO]"
            sql &= ",[USUARIO_CREACION]"
            sql &= ",[USUARIO_CREACION_FECHA]"
            sql &= ",[USUARIO_MODIFICACION]"
            sql &= ",[USUARIO_MODIFICACION_FECHA]"
            sql &= ",[FUR]"
            sql &= ",[COMENTARIO]) "
            sql &= "VALUES"
            sql &= "(" & NumRetiro
            sql &= ", " & CIA
            sql &= ", " & Me.txtCliente.Text
            sql &= ", '" & jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.lblCodBuxis.Text & " AND COMPAÑIA = " & Compañia) & "'"
            sql &= ", 0"
            sql &= ", " & AhorrosExt
            sql &= ", 3"
            sql &= ", 0"
            sql &= ", 3"
            sql &= ", '" & Usuario & "'"
            sql &= ", GETDATE()"
            sql &= ", '" & Usuario & "'"
            sql &= ", GETDATE()"
            sql &= ", GETDATE()"
            sql &= ",'" & "Pago Factura No. " & txtNoFact.Text & "')"
            sqlCmd.CommandText = sql
            jClass.ejecutarComandoSql(sqlCmd)
            sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_AHORROS_IUD] "
            sql &= "@COMPAÑIA = " & CIA & ", "
            sql &= "@CODIGO_EMPLEADO = " & Me.lblCodBuxis.Text & ", "
            sql &= "@CODIGO_EMPLEADO_AS = '" & jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.lblCodBuxis.Text & " AND COMPAÑIA = " & Compañia) & "', "
            sql &= "@AHORRO = " & jClass.obtenerEscalar("SELECT ISNULL(MAX(AHORRO), 0) + 1 FROM COOPERATIVA_SOCIO_AHORROS WHERE COMPAÑIA = " & CIA & " AND CODIGO_EMPLEADO = " & Me.lblCodBuxis.Text & " AND CODIGO_EMPLEADO_AS = '" & Me.txtCliente.Text & "'") & ", "
            sql &= "@FECHA_AHORRO = '" & Now.Date.ToString("dd/MM/yyyy") & "', "
            sql &= "@PORCENTAJE = 0, "
            sql &= "@CUOTA_ORDINARIO = 0, "
            sql &= "@CUOTA_EXTRAORDINARIO = -" & AhorrosExt & ", "
            sql &= "@SALDO_ORDINARIO = 0, "
            sql &= "@SALDO_EXTRAORDINARIO = 0, "
            sql &= "@USUARIO = " & Usuario & ", "
            sql &= "@IUD = 'I'"
            sqlCmd.CommandText = sql
            jClass.ejecutarComandoSql(sqlCmd)
        End If
        MSJ = True
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        '    _error_ = True
        '    MSJ = True
        'End Try
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        SetearFechas()
    End Sub

    Private Sub SetearFechas()
        Dim Fecha As Date = Me.DateTimePicker1.Value
        If Me.DateTimePicker1.Value.Day <= 15 Then
            Me.DateTimePicker1.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Me.DateTimePicker1.Value.Day > 15 And Me.DateTimePicker1.Value.Day <= Date.DaysInMonth(Me.DateTimePicker1.Value.Year, Me.DateTimePicker1.Value.Month) Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.DateTimePicker1.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.DateTimePicker1.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.DateTimePicker1.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        End If
    End Sub

    Private Sub ParamBodegas()
        If Not Iniciando Then
            Dim ParamBodegas As DataTable
            Dim sqlCmd As New SqlCommand
            sql = "SELECT TIPO_FACTURA,TIPO_CCF,TIPO_SOLICITUD FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
            sqlCmd.CommandText = sql
            ParamBodegas = jClass.obtenerDatos(sqlCmd)
            TipMovInvFact = Val(ParamBodegas.Rows(0).Item("TIPO_FACTURA"))
            TipMovInvCCF = Val(ParamBodegas.Rows(0).Item("TIPO_CCF"))
            TipoSolicitud = Val(ParamBodegas.Rows(0).Item("TIPO_SOLICITUD"))            
        End If
    End Sub

    Private Sub CheckDisponible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDisponible.CheckedChanged
        If Not Me.CheckDisponible.Checked Then
            Me.lblDispSocio.Text = "No Verificar"
        Else
            DisponibleSocio = FPro.DisponibleSocio(Compañia, Me.txtCliente.Text, Val(Me.lblCodBuxis.Text))
            Me.lblDispSocio.Text = DisponibleSocio.ToString("0.00")
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.bntNuevaFact.PerformClick()
            Case Keys.F1
                'Add the code for the function key F1 here.
                'Me.btnCopiaPedido.PerformClick()
            Case Keys.F2
                'Add the code for the function key F2 here.
                'Me.btnAnular.PerformClick()
            Case Keys.F3
                'Add the code for the function key F5 here.
                Me.btnBuscarCliente.PerformClick()
            Case Keys.F4
                'Add the code for the function key F6 here.
                Me.btnProcesar.PerformClick()                
            Case Keys.F5
                'Add the code for the function key F7 here.                
            Case Keys.F6
                'Add the code for the function key F9 here.                
            Case Keys.F7
                'Add the code for the function key F10 here.
                'btnEliminarProducto.PerformClick()
                'crvFact.ReportSource = Nothing
                'crvFact.Visible = False
                'crvFact.Dock = DockStyle.None
            Case Keys.F8
                If Origen <> origen_autoconsumo Then
                    BuscarProducto_PrecioEspecial()
                Else
                    MsgBox("No es posible acceder a precios especiales para clientes de auto-consumo", MsgBoxStyle.Critical, "No hay acceso")
                End If
        End Select
    End Sub

    Private Sub Facturacion_Bodegas_Almacen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub cmbBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
        If Not Iniciando Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
            If Me.cmbCtasBanco.Items.Count > 0 Then
                If Me.cmbCONDICION_PAGO.SelectedIndex = 0 Then
                    Me.cmbCtasBanco.SelectedIndex = 3
                Else
                    Me.cmbCtasBanco.SelectedIndex = 0
                End If
            Else
                Me.cmbCtasBanco.Text = ""
            End If
        End If
    End Sub

    Private Sub txtAhorroExt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAhorroExt.TextChanged
        If Val(Me.txtAhorroExt.Text) > 0 And Not Me.Label21.Visible Then
            If Me.txtCliente.Text = Nothing Or Me.txtCliente.Text.Length = 0 Then
                MsgBox("Ingrese código del socio", MsgBoxStyle.Exclamation, "Ahorro Extraordinario")
                Me.txtAhorroExt.Clear()
                Me.txtCliente.Focus()
                Return
            End If
            Dim totAhorroE As Double
            totAhorroE = jClass.obtenerEscalar("SELECT [AHORRO EXTRAORDINARIO] FROM VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCliente.Text)
            If totAhorroE < Val(Me.txtAhorroExt.Text) Then
                MsgBox("El total del Ahorro Extraordinario no es suficiente", MsgBoxStyle.Information, "Ahorro Extraordinario")
                If totAhorroE > 0 Then
                    Me.txtAhorroExt.Text = totAhorroE.ToString("0.00")
                Else
                    Me.txtAhorroExt.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub cmbPeriodoPago_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodoPago.SelectedValueChanged
        If Not Iniciando Then
            If Me.cmbPeriodoPago.SelectedValue = "AG" Then
                Me.txtDescAGUI.Text = Me.txtTotFact.Text
            End If
            If Me.cmbPeriodoPago.SelectedValue = "BO" Then
                Me.txtDescBONI.Text = Me.txtTotFact.Text
            End If
        End If
    End Sub

    Public Function Resetear_montomaximo(ByVal numSocio, ByVal codemp)
        Dim A As Integer
        Dim sqlCmd As New SqlCommand
        If numSocio Is Nothing Then
            sql = "UPDATE COOPERATIVA_CATALOGO_SOCIOS SET MONTO_MAXIMO = 0.0 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = '" & codemp & "'"
        Else
            sql = "UPDATE COOPERATIVA_CATALOGO_SOCIOS SET MONTO_MAXIMO = 0.0 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS= '" & numSocio & "'"
        End If
        sqlCmd.CommandText = sql
        A = jClass.ejecutarComandoSql(sqlCmd)
        Return A
    End Function

    ' busca los productos con precios especiales para la bodega seleccionada
    Private Sub BuscarProducto_PrecioEspecial()
        Me.txtProducto.Clear()
        Dim productoespecial As New Facturacion_Busqueda_Productos_Precio_Especial
        Producto = ""
        productoespecial.cmbCOMPAÑIA.SelectedValue = Compañia
        productoespecial.Bodega_Value = Me.cmbBODEGA.SelectedValue
        productoespecial.cmbCOMPAÑIA.Enabled = False
        productoespecial.cmbBODEGA.Enabled = False
        productoespecial.ShowDialog()
        If Producto <> "" Then

            If Me.dgvCuentasEquivalentes.Rows.Count <> 0 Then
                For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                    If Val(row.Cells("PRODUCTO").Value) <> Producto Then
                        Me.txtProducto.Text = Producto
                        producto_especial = Descripcion_Producto
                        Obtenerdatos_pro_PrecioEspecial()
                        Me.chkPre_normal.Checked = False
                    Else
                        MsgBox("Este producto ya existe en la factura a precio normal, no es posible facturar el mismo producto con un precio especial", MsgBoxStyle.Critical, "Error")
                        LimpiaCamposDetalleFactura()
                        Return
                    End If
                Next
            Else
                Me.txtProducto.Text = Producto
                producto_especial = Descripcion_Producto
                Obtenerdatos_pro_PrecioEspecial()

            End If

        End If
    End Sub

    'obtiene los datos de los productos con precio especial
    Private Sub Obtenerdatos_pro_PrecioEspecial()
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Compañia.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & Me.txtProducto.Text
        sql &= ", '0', 0, 2"
        Comando_.CommandText = sql
        Table = jClass.obtenerDatos(Comando_)
        If Table.Rows.Count = 1 Then
            Me.txtDescripcion.Text = Table.Rows(0).Item("DESCRIPCION_PRODUCTO")
            Iniciando = True
            Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(0).Item("UNIDAD_MEDIDA")
            Iniciando = False
        End If
        sql = "select PRODUCTO, CANTIDAD, PRECIO_ESPECIAL from INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL"
        sql &= " where IDPROD_PRE_ESP = " & producto_especial

        Comando_.CommandText = sql
        Table = jClass.obtenerDatos(Comando_)
        Me.txtPrecio.Text = Table.Rows(0).Item("PRECIO_ESPECIAL")
        Me.cantidad_precio_especial = Table.Rows(0).Item("CANTIDAD")
        Me.chkPre_normal.Checked = False
        Me.txtCantidad.Clear()
        Me.txtCantidad.Focus()
        Me.txtdescuento.Text = "0.0"
        Me.txtdescuento.ReadOnly = True
    End Sub

    'funcion para borrar la matriz por si es un producto especial
    Private Function Se_encuentra_producto_especial(ByVal prod) As Boolean
        Dim respuesta As Boolean = False
        For aux As Integer = 0 To Me.productos_facturados.GetLength(0) - 1
            If Me.productos_facturados(aux, 0) = prod Then
                respuesta = True
                Me.productos_facturados(aux, 0) = 0
                Me.productos_facturados(aux, 1) = 0
                aux = Me.productos_facturados.GetLength(0) - 1
                'MsgBox("es producto especial", MsgBoxStyle.Critical, "mensaje")
            End If
        Next
        Return respuesta
    End Function

    Private Function era_producto_especial(ByVal prod) As Boolean
        Dim respuesta As Boolean = False
        For aux As Integer = 0 To Me.productos_facturados.GetLength(0) - 1
            If Me.productos_facturados(aux, 0) = prod.ToString Then
                respuesta = True
                aux = Me.productos_facturados.GetLength(0) - 1
            End If
        Next
        Return respuesta
    End Function

    ' funcion para actualizar el inventario de productos con precio especial
    Private Sub Actualizar_inventario_precio_especial(ByVal compañia, ByVal bodega, ByVal producto, ByVal precio_especial, ByVal idpro, ByVal cantidad, ByVal accion)
        Dim A As Integer
        Dim sqlCmd As New SqlCommand
        If accion = "A" Then
            sql = "execute sp_INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL_ACTUALIZAR "
            sql &= idpro
            sql &= " , " & cantidad
            sql &= " , '" & accion & "'"
            sql &= " , " & compañia
            sql &= " , " & bodega
            sql &= " , " & producto
            sql &= " , " & precio_especial
            sql &= " , " & Usuario
        Else
            sql = "execute sp_INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL_ACTUALIZAR "
            sql &= idpro
            sql &= " , " & cantidad
            sql &= " , '" & accion & "'"
        End If
        sqlCmd.CommandText = sql
        A = jClass.ejecutarComandoSql(sqlCmd)
    End Sub

    ' funcion para obtener IDPROD_PRE_ESP de la tabla INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL 
    Private Function obtener_IDPROD_PRE_ESP(ByVal prod) As Integer
        Dim id As Integer
        For aux As Integer = 0 To Me.productos_facturados.GetLength(0) - 1
            If Me.productos_facturados(aux, 0) = prod Then
                id = Me.productos_facturados(aux, 1)
                aux = Me.productos_facturados.GetLength(0) - 1
            End If
        Next
        Return id
    End Function

    Private Sub soloNumeros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoRemesa.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtSoloNumeros_y_UnPunto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAhorroExt.KeyPress, txtDescAGUI.KeyPress, txtDescBONI.KeyPress, txtdescuento.KeyPress
        Dim cadena As String = sender.Text
        Dim Ocurrencias As Boolean
        Ocurrencias = cadena.Contains(".")
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> ControlChars.Tab And e.KeyChar <> Convert.ToChar(Keys.Enter) Then
            If e.KeyChar = "." Then
                If Ocurrencias Then
                    MsgBox("Ya hay un punto decimal.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            Else
                If Not IsNumeric(e.KeyChar) Then
                    MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                    e.KeyChar = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub chkPre_normal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPre_normal.CheckedChanged
        If Me.chkPre_normal.Checked = True And Origen <> Me.origen_autoconsumo Then
            Me.txtdescuento.ReadOnly = False
        Else
            Me.txtdescuento.Text = "0.0"
            Me.txtdescuento.ReadOnly = True
        End If
    End Sub

    Private Function validarproducto(ByVal producto) As Boolean
        Dim respuesta As Boolean = True
        Dim sqlCmdProd As New SqlCommand

        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Compañia.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & producto.ToString
        sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmdProd)
        If Table.Rows.Count = 0 Then
            MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Me.txtProducto.Focus()
            respuesta = False
        End If

        Return respuesta
    End Function
    'TODO Función para recuperación de Tamaño de PApel Personalizado
    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim pdprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        pdprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To pdprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If pdprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(pdprint.PrinterSettings.PaperSizes(i).RawKind)
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function
    Private Sub imprimir(ByVal tip As Integer)
        _error_ = False        
        If tip = 1 Then
            'realiza las programaciones
            imprimeFactura(Compañia, Me.cmbBODEGA.SelectedValue, 27, Me.txtNoFact.Text, Numero_OV, "Factura no. " & Me.txtNoFact.Text)
            'impresion por ticket
            GuardarTicket(1)
            'ACTUALIZA EL NUMERO DEL TICKET
            jClass.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=4")
        End If
        NumeroFactura()
        listaTicket.Clear()
        Me.txtCliente.Clear()
        If Not _error_ Then
            Resetear_montomaximo(Me.txtCliente.Text, "")
            Me.Enabled = True
            Me.Label21.Visible = True
            Me.Label21.Text = "FACTURA IMPRESA DISPONIBLE SOLO PARA CONSULTA"
            Me.btnGuardarDetalle.Enabled = False
            Me.btnEliminaDetalle.Enabled = False
            Me.btnGuardaFacturaEncabezado.Enabled = False
            Me.btnGuardarDetalle.Enabled = False
            MsgBox("Factura No." & Val(Me.txtNoFact.Text) - 1 & " enviada al impresor.", MsgBoxStyle.Information, "Impresión Factura")
            Me.bntNuevaFact.PerformClick()
        Else
            Me.Enabled = True
        End If
    End Sub
    Public Sub GuardarFactura(ByVal PRODUCTO2, ByVal CANTIDAD, ByVal COSTO_UNI, ByVal PRECIO_UNITARIO)
        Dim forma_pago As String
        If (Me.rbCredito.Checked = True) Then
            forma_pago = "2" 'CREDITO
        Else
            forma_pago = "1" 'CONTADO
        End If

        IVA = jClass.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=2", 0)
        'DESCUENTO = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@COD_EMPLEADO_AS='" & codigo_as & "',@COD_EMPLEADO=" & txtCodigoEmpleado.Text & ", @BANDERA=7", 0)

        SQL = "Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & Bodega
        SQL &= ",@SERIE = '" & serie & "'"
        SQL &= ",@NUMERO_FACTURA = " & correlativo_Actual
        sql &= ",@FECHA = N'" & Me.dpFECHA_CONTABLE.Text & "'"
        SQL &= ",@TIEMPO = " & Tiempo
        SQL &= ",@CAJA = " & Me.txtCaja.Text
        SQL &= ",@CODIGO_EMPLEADO = " & codigo_buxi
        SQL &= ",@CODIGO_EMPLEADO_AS = '" & codigo_as.PadLeft(6, "0") & "'"
        SQL &= ",@ANULADO = 0"
        SQL &= ",@FORMA_PAGO = " & forma_pago
        Dim ivax As String = ((Val(txtTotFact.Text)) * (Val(IVA) / 100)).ToString()
        SQL &= ",@IVA = " & ivax 'JNJN
        If (rbEfectivo.Checked = True) Then
            sql &= ",@DEUDA = " & 0 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            sql &= ",@MONTO = " & txtTotFact.Text
        Else
            sql &= ",@DEUDA = " & 0 'SE LE INGRESA EL DESCUENTO PERO NO LE CAMBIEN EL NOMBRE DEL PARAMETRO
            sql &= ",@MONTO = " & txtTotFact.Text
        End If

        SQL &= ",@TIPO_DOCUMENTO = 27" 'TICKET DE CAJA DEFINIDO EN CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO
        SQL &= ",@ORIGEN = " & ORIGEN
        SQL &= ",@PROCESADO = 1"
        SQL &= ",@USUARIO_CREACION = '" & Usuario & "'"
        SQL &= ",@BANDERA = 'I'"
        SQL &= ",@PRODUCTO = " & PRODUCTO2
        SQL &= ",@CANTIDAD = " & CANTIDAD
        SQL &= ",@COSTO_UNITARIO = " & COSTO_UNI
        SQL &= ",@PRECIO_UNITARIO = " & PRECIO_UNITARIO
        SQL &= ",@PRECIO_TOTAL = " & CANTIDAD * PRECIO_UNITARIO
        SQL &= ",@TIPO_MOV = " & 2
        sql &= ",@MOV = " & Mov

        jClass.Ejecutar_ConsultaSQL(sql)

    End Sub
    'TODO Proceso de Facturas
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim descrip As String
        Dim precio As Double, total As Double, cantidad As Double
        'Timer1.Enabled = False
        If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
            crearFactura_OVEncabezado(Compañia, _
                                    Me.cmbBODEGA.SelectedValue, _
                                    Me.dpFECHA_CONTABLE.Value, _
                                    27, _
                                    Me.txtNoFact.Text, _
                                    FORMA_PAGO, _
                                    Me.lblCodBuxis.Text, _
                                    Me.txtCliente.Text, _
                                    Me.txtNomFact.Text, _
                                    Me.txtTelCliente.Text, _
                                    Me.txtDUICliente.Text, _
                                    Me.txtNITCliente.Text, _
                                    Me.TextBox30.Text, _
                                    IIf(Me.chkImpConcepto.Checked, 1, 0), _
                                    Me.txtSUBTOTAL.Text, _
                                    Me.txtIVA.Text, _
                                    Me.txtTotFact.Text, _
                                    Val(Me.txtNumCuotas.Text), _
                                    Me.DateTimePicker1.Value, _
                                    Val(Me.txtDescAGUI.Text), _
                                    Val(Me.txtDescBONI.Text), _
                                    Me.cmbPeriodoPago.SelectedValue, _
                                    Me.txtNoRemesa.Text, _
                                    Me.cmbBancos.SelectedValue, _
                                    Me.cmbCtasBanco.SelectedValue)

            'CALCULA EL MOVIMIENTO DE INVENTARIOS
            NumeroMovimiento()

            For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                '
                If row.Cells("idLinea").Value = 0 Then
                    Dim ExistenciaProducto As Double = validaExistencias(Val(row.Cells(0).Value), Me.cmbBODEGA.SelectedValue, Val(row.Cells(3).Value), Me.dpFECHA_CONTABLE.Value)
                    '
                    GrabaDetalleFactura(Compañia, Me.cmbBODEGA.SelectedValue, row.Cells(0).Value, row.Cells(1).Value, Val(Me.txtNoFact.Text), Me.dpFECHA_CONTABLE.Value, row.Cells(6).Value, row.Cells(3).Value, row.Cells(13).Value, row.Cells(14).Value, Val(row.Cells(4).Value), row.Cells(5).Value, grupoProd, subgrupoProd, 27, Me.txtNoFact.Text, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), _
                                 Me.chkImpConcepto.Checked, Me.TextBox30.Text, FORMA_PAGO, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Me.txtNumCuotas.Text, Me.DateTimePicker1.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Val(Me.txtTotFact.Text), Val(Me.txtIVA.Text), _
                                 Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, row.Cells(12).Value, row.Cells(11).Value)
                    If intCodDescuento > 0 And row.Cells("pdescuento").Value > 0 Then
                        prRegistroAutorizacion(intCodDescuento, 27, Val(Me.txtNoFact.Text), Numero_OV, row.Cells("idLinea").Value)
                    End If

                    GuardarFactura(row.Cells(0).Value, row.Cells(3).Value, row.Cells(13).Value, Val(row.Cells(4).Value))

                    precio = row.Cells(4).Value

                    total = row.Cells(5).Value

                    cantidad = row.Cells(3).Value

                    descrip = row.Cells(1).Value

                    If row.Cells(1).Value.Length > 17 Then
                        descrip = row.Cells(1).Value.Substring(0, 17)
                    End If

                    listaTicket.Add(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(17, " ") & " " & precio.ToString("0.00").PadLeft(6, " ") & " " & total.ToString("0.00").PadLeft(6, " "))

                End If
            Next

            Me.generaGrid()
            cargaFacturaDetalle(Me.txtNoFact.Text, 27, Compañia, Me.cmbBODEGA.SelectedValue)
            '
            MessageBox.Show("La Factura ha sido Procesada con exito" & Chr(13) & "Los Inventarios han sido afectados" & Chr(13) & "Haga click sobre el Bonton Imprimir", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            imprimir(1)
        Else
            MessageBox.Show("Debe de ingresar los datos de la Factura", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnAutocomsumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutocomsumo.Click
        Dim frmAutoConsumo As New Facturacion_Autorizaciones(1)
        frmAutoConsumo.ShowDialog()
        intCodAutoconsumo = frmAutoConsumo.idAutotizacion
        If intCodAutoconsumo > 0 Then
            Me.lblAutoconsumo.Visible = True
            txtdescuento.Enabled = False
            Me.btnAutocomsumo.Enabled = False
        Else
            MessageBox.Show("Autorizacion Denegada....", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    'TODO Autorizaciones
    Private Sub prRegistroAutorizacion(ByVal pAutorizacion As Integer, ByVal pTipoauto As Integer, ByVal pfactura As Integer, ByVal porden As Integer, ByVal plinea As Integer)
        Try
            jClass.Ejecutar_ConsultaSQL("INSERT INTO FACTURACION_REGISTRO_AUTORIZACIONES (IDAUTORIZACION, TIPO_AUTORIZACION, NUMERO_FACTURA, ORDEN_VENTA, LINEA ) " & _
                    " VALUES ( " & pAutorizacion & "," & pTipoauto & "," & pfactura & "," & porden & "," & plinea & ")")
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Problemas en Detalle de Autorizacion....", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Function setFechaPago() As Date
        sql = "SELECT FECHA_PAGO FROM [dbo].[FACTURACION_PERIODOS_COBRO]" & vbCrLf
        sql &= " WHERE CONVERT(DATE, [FECHA_INICIO_PERIODO]) <= CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
        sql &= "   AND CONVERT(DATE,[FECHA_FINAL_PERIODO]) >= CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
        Return CDate(jClass.obtenerEscalar(sql))
    End Function

    Private Sub Facturacion_Bodegas_Almacen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
    Private Sub GeneraSQL()
        sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", ''"
        sql &= ", ''"
        sql &= ", " & 999
        sql &= ", " & 4
    End Sub
    Private Sub BuscaProductos()
        Try
            GeneraSQL()            
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = sql
            Table4 = jClass.obtenerDatos(sqlCmd)
            Me.dgvProductos.DataSource = Table4            
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub LimpiaGrid()

        Me.dgvProductos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.dgvProductos.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.dgvProductos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub TxtNombreB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreB.TextChanged
        Dim rows As DataRow()
        Dim CodicionFiltro As String
        Dim Strsort As String = ""

        Select Case dgvProductos.Columns(1).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table4.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNombreB.Text = "" Then
            Me.dgvProductos.DataSource = Table4
        Else
            'Se incluyen los brackets por si el nombre de encabezado esta compuesto por mas de una palabra separada por espacios
            CodicionFiltro = "[" & dgvProductos.Columns(1).Name & "]" & " like '" & TxtNombreB.Text & "%'"
            rows = Table4.Select(CodicionFiltro) 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            ' return filtered dt            
            Me.dgvProductos.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick, dgvCuentasEquivalentes.CellClick
        txtProducto.Text = dgvProductos.CurrentRow.Cells(0).Value.ToString()
        If Me.txtProducto.Text <> Nothing Then
            If Me.validarproducto(Me.txtProducto.Text) = False Then
                Return
            End If
            If Me.chkPre_normal.Checked = True Then
                obtieneDatosProducto(Me.txtProducto.Text)
            Else
                Obtenerdatos_pro_PrecioEspecial()
            End If
        End If
    End Sub
    Public Sub CargarGrid(ByVal cadena, ByVal ds)
        Try
            ds.Reset()
            jClass.MiddleConnection(cadena)
            jClass.DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar la grilla", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub Bloquear_Desbloquear(ByVal true_false)
        GroupBox1.Enabled = true_false
    End Sub
    Private Sub cargarFactura()
        If (dgvCuentasEquivalentes.RowCount <= 0) Then

            If txtNumTicket.Text <> "" Then
                DS02.Clear()
                CargarGrid("EXECUTE [dbo].[sp_CAFETERIA_FACTURACION_OBTENER_SERIE] @COMPAÑIA=" & Compañia & ", @BODEGA=" & Bodega & ",@CAJA=" & txtCaja.Text & ",@NUMERO_FACTURA=" & txtNumTicket.Text & ", @BANDERA=8", DS02)
                dgvCuentasEquivalentes.DataSource = DS02.Tables(0)
                If dgvCuentasEquivalentes.RowCount > 0 Then
                    Bloquear_Desbloquear(False)
                End If

                If Val(dgvCuentasEquivalentes.Rows(0).Cells(7).Value.ToString()) = 1 Then
                    Label21.Visible = True
                Else
                    Label21.Visible = False
                End If

                Dim TotIVA, totFactura As Double
                Subtotal = 0
                For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                    Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
                Next
                totFactura = Subtotal
                Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
                Me.txtIVA.Text = TotIVA.ToString("###0.00")
                Me.txtTotFact.Text = Subtotal.ToString("###0.00")

                txtCliente.Text = dgvCuentasEquivalentes.Rows(0).Cells(17).Value.ToString()
                txtNombreCliente.Text = dgvCuentasEquivalentes.Rows(0).Cells(18).Value.ToString()
                Me.txtCliente_LostFocus(New Object, New System.EventArgs)
                dpFECHA_CONTABLE.Value = dgvCuentasEquivalentes.Rows(0).Cells(8).Value

                serie = jClass.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=1", 0)
                Resolucion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Caja & ", @BANDERA=2", 0)
                fecha_resolucion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Caja & ", @BANDERA=2", 1)
                fecha_autorizacion = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Caja & ", @BANDERA=2", 2)
                del = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Caja & ", @BANDERA=2", 3)
                al = jClass.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @CAJA=" & Caja & ", @BANDERA=2", 4)
                txt_correlativo.Text = txtNumTicket.Text
                txtNoFact.Text = txtNumTicket.Text
                btnProcesar.Enabled = False

            End If

        Else
            MsgBox("Aviso...Debe termina la operacion iniciada!", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        cargarFactura()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'ELIMINA TODA EL TICKET
        Dim descrip As String
        Dim precio As Double, total As Double, cantidad As Double
        Dim respuesta As MsgBoxResult
        Dim numFactura, NumOV, RowsAfected As Double
        Dim numSoli As Integer
        Dim detalleInv As DataTable
        Dim anula As Boolean
        respuesta = MsgBox("Desea eliminar el Ticket?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then

            If Val(dgvCuentasEquivalentes.Rows(0).Cells(7).Value.ToString()) = 1 Then
                MsgBox("Aviso...El Ticket ya fue anulado!", MsgBoxStyle.Information)
                Label21.Visible = True
                Exit Sub
            End If
            'Timer1.Enabled = False
            If Me.dgvCuentasEquivalentes.Rows.Count > 0 And Val(txtNumTicket.Text) > 0 Then
                crearFactura_OVEncabezado2(Compañia, _
                                        Me.cmbBODEGA.SelectedValue, _
                                        Me.dpFECHA_CONTABLE.Value, _
                                        27, _
                                        0, _
                                        FORMA_PAGO, _
                                        Me.lblCodBuxis.Text, _
                                        Me.txtCliente.Text, _
                                        Me.txtNomFact.Text, _
                                        Me.txtTelCliente.Text, _
                                        Me.txtDUICliente.Text, _
                                        Me.txtNITCliente.Text, _
                                        Me.TextBox30.Text, _
                                        IIf(Me.chkImpConcepto.Checked, 1, 0), _
                                        Me.txtSUBTOTAL.Text, _
                                        Me.txtIVA.Text, _
                                        Me.txtTotFact.Text, _
                                        Val(Me.txtNumCuotas.Text), _
                                        Me.DateTimePicker1.Value, _
                                        Val(Me.txtDescAGUI.Text), _
                                        Val(Me.txtDescBONI.Text), _
                                        Me.cmbPeriodoPago.SelectedValue, _
                                        Me.txtNoRemesa.Text, _
                                        Me.cmbBancos.SelectedValue, _
                                        Me.cmbCtasBanco.SelectedValue)

                'CALCULA EL MOVIMIENTO DE INVENTARIOS
                NumeroMovimiento()

                For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                    '

                    Dim ExistenciaProducto As Double = validaExistencias(Val(row.Cells(1).Value), Me.cmbBODEGA.SelectedValue, Val(row.Cells(3).Value), Me.dpFECHA_CONTABLE.Value)
                    '
                    GrabaDetalleFactura2(Compañia, Me.cmbBODEGA.SelectedValue, row.Cells(1).Value, row.Cells(2).Value, Val(Me.txtNoFact.Text), Me.dpFECHA_CONTABLE.Value, row.Cells(19).Value, row.Cells(3).Value, row.Cells(4).Value, (row.Cells(3).Value) * (row.Cells(4).Value), Val(row.Cells(5).Value), row.Cells(6).Value, grupoProd, subgrupoProd, 27, Me.txtNoFact.Text, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), _
                                 Me.chkImpConcepto.Checked, Me.TextBox30.Text, FORMA_PAGO, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Me.txtNumCuotas.Text, Me.DateTimePicker1.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Val(Me.txtTotFact.Text), Val(Me.txtIVA.Text), _
                                 Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, 0, 0)
                    

                    precio = row.Cells(5).Value

                    total = row.Cells(6).Value

                    cantidad = row.Cells(3).Value

                    descrip = row.Cells(2).Value

                    If Val(row.Cells(2).Value.Length) > 17 Then
                        descrip = row.Cells(2).Value.Substring(0, 17)
                    End If

                    listaTicket.Add(cantidad.ToString("0.00").PadLeft(5, " ") & " " & descrip.PadRight(17, " ") & " " & precio.ToString("0.00").PadLeft(6, " ") & " " & total.ToString("0.00").PadLeft(6, " "))

                    numFactura = txtNumTicket.Text
                    NumOV = row.Cells(20).Value
                    anula = row.Cells(7).Value                    
                Next

                Me.generaGrid()

                cargaFacturaDetalle(Me.txtNoFact.Text, 27, Compañia, Me.cmbBODEGA.SelectedValue)
                MsgBox("La Factura de Anulo con Exito...", MsgBoxStyle.Critical, "Anulacion")
                'impresion por ticket
                GuardarTicket(2)

                If anula = False Then
                    sql = "EXECUTE [dbo].[sp_FACTURACION_ANULA_FACTURA_GENERADA]"
                    sql &= "  @COMPAÑIA = " & Compañia
                    sql &= ", @BODEGA =  " & Me.cmbBODEGA.SelectedValue
                    sql &= ", @ORDEN_VENTA = " & NumOV
                    sql &= ", @TIPO_DOCUMENTO = " & 5
                    sql &= ", @NUMERO_FACTURA = " & txtNumTicket.Text
                    sql &= ", @USUARIO = " & Usuario
                    sql &= ", @IUD = A"
                    sqlCmd.CommandText = sql
                    RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    sql = "SELECT FGD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, FGD.CANTIDAD, FGD.PRECIO_UNITARIO, FGD.PRECIO_TOTAL, FGD.BODEGA, FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO, FGE.NUMERO_FACTURA, FGE.ANULADA, FGD.LINEA, IME.TIPO_MOVIMIENTO, IME.MOVIMIENTO, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.IMPRIMIR_CONCEPTO, FGE.CONCEPTO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_GENERADA_DETALLE FGD,dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM WHERE FGE.BODEGA = FGD.BODEGA AND FGE.COMPAÑIA = FGD.COMPAÑIA AND FGE.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO AND FGE.NUMERO_FACTURA = FGD.NUMERO_FACTURA AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FGD.PRODUCTO = IMD.PRODUCTO AND FGD.COMPAÑIA = ICP.COMPAÑIA AND FGD.PRODUCTO = ICP.PRODUCTO AND ICUM.COMPAÑIA = FGD.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA AND IMD.ENTRADA_SALIDA = 0"
                    sql &= " AND FGE.COMPAÑIA = " & Compañia
                    sql &= " AND FGE.BODEGA = " & Me.cmbBODEGA.SelectedValue
                    sql &= " AND FGE.TIPO_DOCUMENTO = " & 5
                    sql &= " AND FGE.NUMERO_FACTURA = " & txtNumTicket.Text
                    sql &= " ORDER BY FGD.LINEA"
                    sqlCmd.CommandText = sql
                    detalleInv = jClass.obtenerDatos(sqlCmd)
                    For Each TableRow As DataRow In detalleInv.Rows
                        sql = "UPDATE INVENTARIOS_MOVIMIENTOS_DETALLE"
                        sql &= " SET ANULADO = 1"
                        sql &= " WHERE COMPAÑIA = " & Compañia & " AND TIPO_MOVIMIENTO = " & TableRow.Item("TIPO_MOVIMIENTO")
                        sql &= " AND MOVIMIENTO = " & TableRow.Item("MOVIMIENTO") & " AND PRODUCTO = " & TableRow.Item("PRODUCTO")
                        sqlCmd.CommandText = sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    Next
                    sql = "SELECT N_SOLICITUD FROM COOPERATIVA_SOLICITUDES_AUTORIZACION"
                    sql &= " WHERE COMPAÑIA = " & Compañia & " AND TIPO_FACTURA = " & 27 & " AND NUMERO_FACTURA = " & txtNumTicket.Text
                    numSoli = jClass.obtenerEscalar(sql)
                    If numSoli > 0 Then
                        sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION"
                        sql &= " SET ANULADA = 1"
                        sql &= ", COMENTARIO_ANULADA = 'ANULACION FACTURA'"
                        sql &= ", FECHA_ANULADA = GETDATE()"
                        sql &= ", USUARIO_ANULO = '" & Usuario & "'"
                        sql &= ", USUARIO_EDICION_FECHA = GETDATE()"
                        sql &= " WHERE COMPAÑIA = " & Compañia & " AND TIPO_FACTURA = " & 27 & " AND NUMERO_FACTURA = " & txtNumTicket.Text
                        sqlCmd.CommandText = sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS_IUD]"
                        sql &= " @COMPAÑIA = " & Compañia
                        sql &= ", @NUM_SOLICITUD = " & numSoli
                        sql &= ", @MOTIVO = 'ANULACION FACTURA'"
                        sql &= ", @USUARIO = '" & Usuario & "'"
                        sql &= ", @IUD = 'I'"
                        sqlCmd.CommandText = sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD]"
                        sql &= " @COMPAÑIA = " & Compañia
                        sql &= ", @NUM_SOLICITUD = " & numSoli
                        sql &= ", @USUARIO = '" & Usuario & "'"
                        sql &= ", @IUD = 'I'"
                        sqlCmd.CommandText = sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    End If
                End If
                imprimir(2)
                'ACTUALIZA EL NUMERO DEL TICKET
                jClass.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@CAJA=" & Me.txtCaja.Text & ",@BANDERA=4")
                bntNuevaFact.PerformClick()
                listaTicket.Clear()
            Else
                MessageBox.Show("Debe de ingresar los datos de la Factura", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub TabPage3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtNumTicket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumTicket.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btnCargar.PerformClick()
        End If
    End Sub
End Class

