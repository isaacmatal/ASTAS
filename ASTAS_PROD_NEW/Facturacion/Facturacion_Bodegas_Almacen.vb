Imports System.Data.SqlClient
Imports System
Imports System.Drawing.Printing
Imports System.Configuration
Public Class Facturacion_Bodegas_Almacen
    'Constructor
    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos

    'Variables
    Dim sql As String = ""
    Dim Iniciando, SoloSocios As Boolean
    Dim FactCreada As Boolean = False
    Dim SerieFinalizada As Boolean = False
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
    Dim PorcIVA, PorcPercep, PorcCESC As Double

    ' nuevas
    Dim producto_especial As Integer
    Dim productos_facturados(100, 2) As String
    Dim i As Integer
    Dim cantidad_precio_especial As Double
    Dim origen_autoconsumo As Integer = 9 'Definido en Cooperativa_Catalogo_Origenes
    'Variables para almacenar el grupo y subgrupo de los productos
    Dim grupoProd As Integer
    Dim subgrupoProd As Integer
    Dim AplicaCESC As Boolean
    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim Table1 As DataTable
    Dim Table2 As DataTable
    Dim DataReader_ As SqlDataReader
    Dim maximo_descuento, LimiteSolic As Double

    'TC
    Dim intCodAutoconsumo As Integer = -1
    Dim intCodDescuento As Integer = -1
    Dim strDescuento As String = Nothing
    Dim PeriodoPago As String

    Private Sub Facturacion_Bodegas_Almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        i = 0
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        multi.CargaFormaPago(Compañia, Me.cmbFormaPago)
        multi.CargaTipoDocumentoFact(Compañia, Me.cmbTipDoc)
        multi.CargaPeriodo(Compañia, Me.cmbPeriodoPago)
        Me.dpFECHA_CONTABLE.Value = FechaCorte()
        Me.cmbFormaPago.SelectedIndex = 1
        multi.CargaCondicionPago(Compañia, Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO)
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        Me.cmbTipDoc.SelectedIndex = 0
        jClass.CargaBancos(Compañia, Me.cmbBancos)
        Me.cmbBancos.SelectedIndex = 6
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
        Me.cmbCtasBanco.SelectedIndex = 0
        Me.dgvCuentasEquivalentes.AllowUserToAddRows = False
        Me.dgvCuentasEquivalentes.ReadOnly = True
        Me.dtpFechaPago.Value = setFechaPago()
        Me.dtpFechaPago.MinDate = Me.dtpFechaPago.Value
        multi.CargaUnidadMedida(Compañia, Me.cmbUNIDAD_MEDIDA)
        Iniciando = False
        TipCosto = 1
        ObtieneNumeroFactura()
        obtieneCentroCosto()
        ParamBodegas()
        generaGrid()
        PorcIVA = FPro.DevuelveConstante(Compañia, 1)
        PorcPercep = FPro.DevuelveConstante(Compañia, 2)
        PorcCESC = FPro.DevuelveConstante(Compañia, 54)
        BuscaProductos()
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
        ObtieneNumeroFactura()
        obtieneCentroCosto()
        ParamBodegas()
        If Iniciando = False Then
            BuscaProductos()
        End If
    End Sub

    Private Sub ObtieneNumeroFactura()
        Dim sqlCmd As New SqlCommand
        If Not Iniciando Then
            Numero_Serie = 0
            FactCreada = False
            sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
            sql &= Compañia
            sql &= ", " & Me.cmbBODEGA.SelectedValue
            sql &= ", '0'" 'DESCRIPCION_SERIE
            sql &= ", " & Me.cmbTipDoc.SelectedValue
            sql &= ", 1" 'BANDERA
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                For a As Integer = 0 To Table.Rows.Count - 1
                    If Table.Rows(a).Item("Activa") Then
                        If CInt(Table.Rows(a).Item("Actual")) > CInt(Table.Rows(a).Item("Final")) Then
                            SerieFinalizada = True
                            txtNoFact.Text = "N/A"
                            Me.lblMaxLineas.Text = "0"
                            Numero_Serie = 0
                        Else
                            SerieFinalizada = False
                            txtNoFact.Text = Table.Rows(a).Item("Actual")
                            Numero_Serie = Table.Rows(a).Item("Serie")
                            cargaMaximoLineas(Compañia, Me.cmbBODEGA.SelectedValue, Numero_Serie, Me.cmbTipDoc.SelectedValue)
                        End If
                    End If
                Next
            End If
            If Numero_Serie <= 0 Then
                SerieFinalizada = True
                txtNoFact.Text = "N/A"
                Me.lblMaxLineas.Text = "0"
                Me.btnGuardarDetalle.Enabled = False
                Me.btnEliminaDetalle.Enabled = False
                Me.btnGuardaFacturaEncabezado.Enabled = False
                MsgBox("Verifique las Series de Facturacion para la Bodega:" & vbCrLf & cmbBODEGA.Text, MsgBoxStyle.Critical, "Correlativos de Factura AGOTADOS")
            Else
                Me.btnGuardarDetalle.Enabled = True
                Me.btnEliminaDetalle.Enabled = True
                Me.btnGuardaFacturaEncabezado.Enabled = True
            End If
        End If
    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        Dim Bloqueado As Boolean
        Dim autorizaciones As DataTable
        Dim monto_maximo, saldoActual, montoAdicional As Double
        If numSocio <> "" Then
            'If jClass.SocioBloqueado(numSocio) Then
            '    Me.txtCliente.Clear()
            '    Return
            'End If
            Try
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
                    'If fnBuscaBloqueo(CInt(Table.Rows(0).Item("CODIGO_EMPLEADO")), CStr(Table.Rows(0).Item("CODIGO_EMPLEADO_AS"))) Then
                    '    Me.txtCliente.Text = ""
                    '    Me.lblCodBuxis.Text = ""
                    '    DisponibleSocio = 0
                    '    Origen = 0
                    '    MsgBox("El Codigo : " + CStr(Table.Rows(0).Item("CODIGO_EMPLEADO")) + " esta Bloqueado.. " + Chr(13) + " Consulte con el Administrador", MsgBoxStyle.Critical, "Bloqueado")
                    '    Return
                    'End If
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtTelCliente.Text = Table.Rows(0).Item("TELEFONO")
                    Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                    StatusCliente = Table.Rows(0).Item("ESTATUS")
                    Origen = Table.Rows(0).Item("ORIGEN")
                    PeriodoPago = Table.Rows(0).Item("PERIODO_PAGO")
                    If Origen = origen_autoconsumo Then
                        Me.txtdescuento.ReadOnly = True
                    Else
                        Me.txtdescuento.ReadOnly = False
                    End If
                    Me.LimpiaCamposDetalleFactura()
                    codClie = 0
                    giro = "Socio ASTAS"
                    NRC = ""
                    exento = 0
                    TipClie = 1
                    TipContrib = 0
                    dirClie = ""
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    'cargaHistorialFacturas(Me.txtCliente.Text, 2)
                    disponibilidad()
                    Me.txtProducto.Focus()
                    'JASC
                    If TipClie = 3 Then
                        lblGranContribuyente.Visible = True
                    Else
                        lblGranContribuyente.Visible = False
                        txtCESC.Text = "0.00"
                    End If
                    sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & numSocio
                    Bloqueado = jClass.obtenerEscalar(sql)
                    If Bloqueado Then
                        sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                        sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                        sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                        sql &= "     AND A.CODIGO_EMPLEADO = " & Me.txtCliente.Text & vbCrLf
                        sql &= "     AND A.SOLICITUD = " & TipoSolicitud & vbCrLf
                        sql &= "     AND A.EXCEDER_LIMITE = 0" & vbCrLf
                        autorizaciones = jClass.obtenerDatos(New SqlCommand(sql))
                        If autorizaciones.Rows.Count > 0 Then
                            monto_maximo = autorizaciones.Rows(0).Item(0)
                        Else
                            monto_maximo = 0
                        End If
                        Me.lblDispSocio.Text = Format(monto_maximo, "0.00")
                        If monto_maximo = 0 Then
                            MsgBox("Bloqueado." & vbCrLf & "Solicitar autorización a Gerencia.", MsgBoxStyle.Critical, Me.txtNombreCliente.Text)
                            Me.bntNuevaFact.PerformClick()
                        End If
                    Else
                        sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS]" & vbCrLf
                        sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
                        sql &= ",@CODIGO_EMPLEADO = " & Me.txtCliente.Text & vbCrLf
                        sql &= ",@SOLICITUD       = " & TipoSolicitud & vbCrLf
                        sql &= ",@BANDERA         = 1" & vbCrLf
                        autorizaciones = jClass.obtenerDatos(New SqlCommand(sql))
                        If autorizaciones.Rows.Count > 0 Then
                            If CDbl(autorizaciones.Rows(0).Item(0)) > 0.0 Then
                                Me.txtMotivoBloqueo.Text = autorizaciones.Rows(0).Item(1).ToString().ToUpper()
                                Me.txtMotivoBloqueo.Visible = True
                                Me.lblDispSocio.Text = Format(autorizaciones.Rows(0).Item(0), "0.00")
                                Bloqueado = True
                            Else
                                MsgBox("Se ha bloqueado este tipo de solicitud para este empleado debido a:" & vbCrLf & vbCrLf & autorizaciones.Rows(0).Item(1).ToString().ToUpper())
                                Me.bntNuevaFact.PerformClick()
                            End If
                        Else
                            LimiteSolic = jClass.obtenerEscalar("SELECT MONTO_MAXIMO FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & TipoSolicitud)
                            If LimiteSolic > 0 Then
                                If PeriodoPago = "MM" And TipoSolicitud = 15 Then
                                    monto_maximo = Math.Round(LimiteSolic * 2, 2, MidpointRounding.AwayFromZero)
                                Else
                                    monto_maximo = LimiteSolic
                                End If
                                If monto_maximo > 0 Then
                                    Bloqueado = True
                                    sql = "SELECT ISNULL(SUM(CAPITAL), 0.00) AS MONTO" & vbCrLf
                                    sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D" & vbCrLf
                                    sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA AND S.CORRELATIVO = D.NUMERO_SOLICITUD" & vbCrLf
                                    sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
                                    sql &= "   AND D.CAPITAL_D = 0 AND S.SOLICITUD = " & TipoSolicitud & vbCrLf
                                    sql &= "   AND S.CODIGO_BUXIS = " & Me.txtCliente.Text
                                    saldoActual = jClass.obtenerEscalar(sql)
                                    sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                                    sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                                    sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                                    sql &= "     AND A.CODIGO_EMPLEADO = " & Me.txtCliente.Text & vbCrLf
                                    sql &= "     AND A.SOLICITUD = " & TipoSolicitud & vbCrLf
                                    sql &= "     AND A.EXCEDER_LIMITE = 1" & vbCrLf
                                    autorizaciones = jClass.obtenerDatos(New SqlCommand(sql))
                                    If autorizaciones.Rows.Count > 0 Then
                                        montoAdicional = autorizaciones.Rows(0).Item(0)
                                    Else
                                        montoAdicional = 0
                                    End If
                                    LimiteSolic = monto_maximo - saldoActual + montoAdicional
                                    If LimiteSolic <= 0 Then
                                        MsgBox("EL LIMITE DE CREDITO PARA " & Me.cmbBODEGA.Text & vbCrLf & " ES HASTA POR LA CANTIDAD DE: $ " & Format(monto_maximo, "0.00"), MsgBoxStyle.Critical, "Límite de Consumo Excedido.")
                                        Me.bntNuevaFact.PerformClick()
                                    Else
                                        Me.lblDispSocio.Text = Format(LimiteSolic, "0.00")
                                        Me.CheckDisponible.Checked = True
                                    End If
                                End If
                            Else
                                Me.CheckDisponible.Checked = False
                                Me.lblDispSocio.Text = "No Verificar"
                            End If
                        End If
                        CheckDisponible.Checked = Bloqueado
                        CheckDisponible.Enabled = Not Bloqueado
                        If StatusCliente = 0 Then
                            MsgBox("¡Empleado esta INACTIVO!", MsgBoxStyle.Exclamation, "AVISO")
                            Me.bntNuevaFact.PerformClick()
                        Else
                            If SoloSocios Then
                                If StatusCliente <> 2 Then
                                    MsgBox("El Tipo de solicitud solo aplica a Socios", MsgBoxStyle.Information, Me.txtCliente.Text & " - " & Me.txtNombreCliente.Text)
                                    Me.bntNuevaFact.PerformClick()
                                End If
                            End If
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
                    'cargaHistorialFacturas(Me.txtCliente.Text, 1)
                    If TipContrib = 3 Then
                        lblGranContribuyente.Visible = True
                    Else
                        lblGranContribuyente.Visible = False
                        txtCESC.Text = "0.00"
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

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim productos As New Inventario_BusquedaProductosBodega("", 1)
        Compañia = Compañia
        productos.Bodega_Value = Me.cmbBODEGA.SelectedValue
        productos.cmbBODEGA.Enabled = False
        Numero_Factura = 0
        Numero = ""
        Producto = ""
        Descripcion_Producto = ""
        productos.ShowDialog()
        Me.txt_Existencias.Text = ""
        If Producto <> Nothing Then
            Try
                Me.LimpiaCamposDetalleFactura()
                grupoProd = 0
                subgrupoProd = 0
                Me.txtProducto.Text = Producto
                grupoProd = Val(Producto)
                subgrupoProd = Val(Descripcion_Producto)
                Check = 0
                Numero_Factura = 0
                Numero = ""
                Producto = ""
                Descripcion_Producto = ""
                Me.chkPre_normal.Checked = True
                obtieneDatosProducto(Me.txtProducto.Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    'Limpia los campos del Formulario completo
    Private Sub limpiaCampos(ByVal opcion As Integer)
        Me.LimpiaCamposDetalleFactura()
        Me.txtCliente.Clear()
        Me.lblCodBuxis.Text = ""
        Me.txtNombreCliente.Clear()
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtCESC.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.lblDispSocio.Text = "0.00"
        Me.txtNoFact.Clear()
        Me.txtNoFact.Tag = Nothing
        'Me.cargaHistorialFacturas("00000", 2)
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
        Me.Label21.Visible = False
        Me.btnGuardarDetalle.Enabled = True
        Me.btnEliminaDetalle.Enabled = True
        Me.txtCodFiador.Clear()
        Me.txtNombreFiador.Clear()
        Me.txtDeudaFiador.Text = "0.00"
        'JASC28082013
        lblGranContribuyente.Visible = False
        cmbFormaPago.SelectedIndex = 1
        Me.ObtieneNumeroFactura()
        generaGrid()
        CheckDisponible.Checked = True
        Me.txtCliente.Focus()
        dpFECHA_CONTABLE.Value = FechaCorte()
        'TC

        Me.lblAutoconsumo.Visible = False
        txtdescuento.Enabled = True
        btnAutocomsumo.Enabled = True
        intCodAutoconsumo = -1
        intCodDescuento = -1
    End Sub

    Private Sub obtieneDatosProducto(ByVal codProducto As String)
        Dim sqlCmdProd As New SqlCommand
        If codProducto = Nothing Then
            Return
        End If
        If codProducto.Length = 0 Then
            Return
        End If
        sql = "EXECUTE dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA " & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        sql &= ",@BODEGA   = " & Me.cmbBODEGA.SelectedValue & vbCrLf
        sql &= ",@PRODUCTO = " & codProducto & vbCrLf
        sql &= ",@BANDERA  = 2"
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
                Me.txtPrecio.Text = jClass.obtenerEscalar("SELECT [dbo].[INVENTARIOS_CALCULAR_COSTO_PRODUCTO] (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')")
            Else
                If Origen <> origen_autoconsumo Then
                    Me.txtPrecio.Text = jClass.obtenerEscalar("SELECT DBO.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ",'" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')") 'Table.Rows(0).Item("PRECIO_UNITARIO").ToString
                Else
                    Me.txtPrecio.Text = jClass.obtenerEscalar("SELECT [dbo].[INVENTARIOS_CALCULAR_COSTO_PRODUCTO] (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')")
                End If
            End If
            txt_Existencias.Text = Math.Round(jClass.obtenerEscalar("SELECT dbo.calcular_existencia_actual (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')"), 2)

            grupoProd = Table.Rows(0).Item("GRUPO")
            subgrupoProd = Table.Rows(0).Item("SUBGRUPO")
            TipCosto = Table.Rows(0).Item("TIPO_COSTO")
            maximo_descuento = Table.Rows(0).Item("PORCENTAJE_DESCUENTO_MAXIMO")
            AplicaCESC = Table.Rows(0).Item("APLICA_CESC")
            Me.txtCantidad.Focus()
            'Dim sql2 As String = ""
            'sql2 = "SELECT PORCENTAJE_DESCUENTO_MAXIMO FROM dbo.INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS WHERE COMPAÑIA = " & Compañia & " AND GRUPO= " & grupoProd & " AND SUBGRUPO= " & subgrupoProd
            'maximo_descuento = jClass.obtenerEscalar(sql2)
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
                If Table.Rows.Count = 0 Then
                    MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
                End If
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
                sql = "EXECUTE sp_FACTURACION_LINEAS_TIPO_DOCUMENTO " & vbCrLf
                sql &= " @COMPAÑIA       = " & cia & vbCrLf
                sql &= ",@BODEGA         = " & bodega & vbCrLf
                sql &= ",@SERIE          = " & serie & vbCrLf
                sql &= ",@TIPO_DOCUMENTO = " & tipoDoc & vbCrLf
                sql &= ",@BANDERA        = 2" & vbCrLf
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
        End If
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Dim subtot, totProd, ExistenciaProducto, CostoU, CostoT, CantidadFacturada, totProdItem, valdescC As Double
        ', valdesc, totIVAitem
        Dim TipMovto, Movto As Integer
        Dim producto_facturado As Integer = 0
        Dim ProductoDuplicado As Boolean

        'For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
        '    If Val(row.Cells(0).Value) = Val(Me.txtProducto.Text) Then
        '        ProductoDuplicado = True
        '    End If
        'Next

        'If ProductoDuplicado = True Then
        '    MsgBox("El producto ya esta registrado...", MsgBoxStyle.Critical, "Cantidad inválida")
        '    Me.txtProducto.Focus()
        '    Return
        'End If

        If Val(Me.lblMaxLineas.Text) = 0 Then
            MsgBox("Se supera el numero maximo de registros...", MsgBoxStyle.Critical, "Cantidad inválida")
            Return
        End If
        If Not validaCamposVacios() Then
            Return
        End If
        If tipoproducto = 0 And Val(txtPrecio.Text) = 0 Then
            MsgBox("El Precio Unitario no Puede Ser CERO...", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Focus()
            Return
        End If
        If Val(Me.txtCantidad.Text) = 0 Then
            MsgBox("La Cantidad del producto debe ser mayor que cero.", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If
        If Me.txtProducto.Text = Nothing Then
            Me.txtProducto.Focus()
            Return
        End If
        If NRC.Length = 0 And Me.cmbTipDoc.SelectedValue = 2 Then
            MsgBox("NRC del cliente está vacio" & vbCrLf & "Cambie el tipo de documento o verifique los datos del cliente", MsgBoxStyle.Critical, "NRC No Válido")
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
        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            If Val(row.Cells(0).Value) = Producto Then
                CantidadFacturada += Val(row.Cells(3).Value)
                totProdItem = Val(row.Cells(5).Value)
                TipMovto = row.Cells(8).Value
                Movto = row.Cells(9).Value
                'totRegFact = row.Cells(7).Value
                ProductoDuplicado = True
            End If
        Next
        'CantidadFacturada += Val(Me.txtCantidad.Text)
        ExistenciaProducto = validaExistencias(Val(producto_facturado), Me.cmbBODEGA.SelectedValue, Val(Me.txtCantidad.Text), Me.dpFECHA_CONTABLE.Value)
        If ExistenciaProducto < (CantidadFacturada + Val(Me.txtCantidad.Text)) Then 'Val(Me.txtCantidad.Text) Then
            MsgBox("La existencia del producto es de " & (ExistenciaProducto - CantidadFacturada).ToString() & " " & Me.cmbUNIDAD_MEDIDA.Text & vbCrLf & "No se puede procesar producto...", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If

        If Me.cmbTipDoc.SelectedValue = 2 Then
            Me.txtPrecio.Text = Math.Round(Val(Me.txtPrecio.Text) / (1 + (PorcIVA / 100)), 4)
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
        CostoT = CostoU * Val(Me.txtCantidad.Text) '* (1 - (Val(Me.txtdescuento.Text) / 100))
        subtot = Val(Me.txtCantidad.Text) * Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        Me.txtPrecio.Text = Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        valdescC = subtot * ((Val(Me.txtdescuento.Text)) / 100)
        totProd = subtot '- valdesc
        If Val(Me.lblDispSocio.Text) - totProd - Val(Me.txtTotFact.Text) < 0 And Not Me.chkCliExt.Checked And (Me.cmbFormaPago.Text.ToUpper = "CREDITO" Or Me.cmbFormaPago.Text.ToUpper = "CRÉDITO") Then
            If Me.CheckDisponible.Checked Then
                MsgBox("Disponible insuficiente para esta transaccion", MsgBoxStyle.Critical, "Verificar Disponible")
                Return
            End If
        End If
        Me.cmbBODEGA.Enabled = False
        prIngresar(Producto, Me.txtDescripcion.Text, Me.cmbUNIDAD_MEDIDA.Text.Trim, Me.txtCantidad.Text, Me.txtPrecio.Text, subtot, Me.cmbUNIDAD_MEDIDA.SelectedValue, 0, 0, 0, 0, valdescC, Val(Me.txtdescuento.Text), CostoU, CostoT, AplicaCESC)
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
    Private Sub prIngresar(ByVal producto As String, ByVal descripcion As String, ByVal unidad As String, ByVal cantidad As Double, ByVal precio As Double, ByVal total As Double, ByVal Unidadid As Integer, ByVal idLinea As Integer, ByVal TIPO_MOVIMIENTO As Integer, ByVal MOVIMIENTO As Integer, ByVal ORDEN_VENTA As Integer, ByVal pdescuento As Double, ByVal pporcentaje As Double, ByVal pCostou As Double, ByVal pCostoT As Double, ByVal AplCESC As Boolean)

        '
        Dim txtproducto As New DataGridViewTextBoxCell
        Dim txtdescripcion As New DataGridViewTextBoxCell
        Dim txtunidad As New DataGridViewTextBoxCell
        Dim txtcantidad As New DataGridViewTextBoxCell
        Dim txtprecio As New DataGridViewTextBoxCell
        Dim txttotal As New DataGridViewTextBoxCell
        Dim txtunidadID As New DataGridViewTextBoxCell
        Dim txtidLinea As New DataGridViewTextBoxCell
        Dim txtTIPO_MOVIMIENTO As New DataGridViewTextBoxCell
        Dim txtMOVIMIENTO As New DataGridViewTextBoxCell
        Dim txtORDEN_VENTA As New DataGridViewTextBoxCell
        Dim txtdescuento As New DataGridViewTextBoxCell
        Dim txtporcentaje As New DataGridViewTextBoxCell
        Dim txtpCostou As New DataGridViewTextBoxCell
        Dim txtpCostoT As New DataGridViewTextBoxCell
        Dim txtAplicaCesc As New DataGridViewCheckBoxCell
        '
        Dim dataGridRow As New DataGridViewRow
        ' 
        txtproducto.Value = producto
        txtdescripcion.Value = descripcion
        txtunidad.Value = unidad
        txtcantidad.Value = cantidad
        txtprecio.Value = precio
        txttotal.Value = total
        txtunidadID.Value = Unidadid
        txtidLinea.Value = idLinea
        txtTIPO_MOVIMIENTO.Value = TIPO_MOVIMIENTO
        txtMOVIMIENTO.Value = MOVIMIENTO
        txtORDEN_VENTA.Value = ORDEN_VENTA
        txtdescuento.Value = pdescuento
        txtporcentaje.Value = pporcentaje
        txtpCostou.Value = pCostou
        txtpCostoT.Value = pCostoT
        txtAplicaCesc.Value = AplCESC
        ' 
        dataGridRow.Cells.Add(txtproducto)
        dataGridRow.Cells.Add(txtdescripcion)
        dataGridRow.Cells.Add(txtunidad)
        dataGridRow.Cells.Add(txtcantidad)
        dataGridRow.Cells.Add(txtprecio)
        dataGridRow.Cells.Add(txttotal)
        dataGridRow.Cells.Add(txtunidadID)
        dataGridRow.Cells.Add(txtidLinea)
        dataGridRow.Cells.Add(txtTIPO_MOVIMIENTO)
        dataGridRow.Cells.Add(txtMOVIMIENTO)
        dataGridRow.Cells.Add(txtORDEN_VENTA)
        dataGridRow.Cells.Add(txtdescuento)
        dataGridRow.Cells.Add(txtporcentaje)
        dataGridRow.Cells.Add(txtpCostou)
        dataGridRow.Cells.Add(txtpCostoT)
        dataGridRow.Cells.Add(txtAplicaCesc)
        '
        Me.dgvCuentasEquivalentes.Rows.Add(dataGridRow)
        Me.lblMaxLineas.Text = MaxNumLineas - Me.dgvCuentasEquivalentes.Rows.Count
        If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
            Me.dgvCuentasEquivalentes.FirstDisplayedScrollingRowIndex = Me.dgvCuentasEquivalentes.Rows.Count - 1
        End If

    End Sub

    'Private Sub totalizaFactura()
    '    Dim Subtotal, TotIVA, totFactura As Double
    '    For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
    '        Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
    '    Next
    '    If Me.cmbTipDoc.SelectedValue = 2 Then
    '        If exento Then
    '            TotIVA = 0
    '        Else
    '            TotIVA = (Subtotal * ((PorcIVA / 100)))
    '        End If
    '    End If
    '    'JASC
    '    If TipContrib = 3 Then
    '        txtGranDescuento.Text = Math.Round(Me.txtSUBTOTAL.Text * 0.1, 2)
    '        totFactura = Subtotal + TotIVA + Val(txtGranDescuento.Text)
    '        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
    '        Me.txtIVA.Text = TotIVA.ToString("###0.00")
    '        Me.txtTotFact.Text = totFactura.ToString("###0.00")
    '    Else
    '        totFactura = Subtotal + TotIVA
    '        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
    '        Me.txtIVA.Text = TotIVA.ToString("###0.00")
    '        Me.txtTotFact.Text = totFactura.ToString("###0.00")
    '    End If
    'End Sub

    Private Sub totalizaFacturanew()
        Dim Subtotal, TotIVA, totFactura, ConCESC As Double
        ConCESC = 0
        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            If row.Cells("apcesc").Value Then
                ConCESC += Math.Round(Val(row.Cells("Total").Value) / (1 + (PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
            End If
            Subtotal += Val(row.Cells("Total").Value)
        Next
        If Me.cmbTipDoc.SelectedValue = 2 Then
            If exento Then
                TotIVA = 0
            Else
                TotIVA = (Subtotal * ((PorcIVA / 100)))
            End If
        End If
        txtCESC.Text = Math.Round((ConCESC * ((PorcCESC / 100))), 2, MidpointRounding.AwayFromZero)
        totFactura = Subtotal + TotIVA + Val(txtCESC.Text)
        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
        Me.txtIVA.Text = TotIVA.ToString("###0.00")
        Me.txtTotFact.Text = totFactura.ToString("###0.00")
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
            'If Not Me.chkCliExt.Checked Then
            '    Me.txtCliente.Text = Me.txtCliente.Text.PadLeft(6, "0")
            'End If
            If Val(Me.txtCliente.Text) = 0 Then
                Me.cmbFormaPago.SelectedValue = 1
                Me.cmbFormaPago.Enabled = False
                Me.txtNomFact.Text = "VENTAS AL CONTADO (CLIENTES VARIOS)"
                Me.lblCodBuxis.Text = "0"
                Me.txtDUICliente.Text = "00000000-0"
                Me.txtNITCliente.Text = "0000-000000-000-0"
                NRC = ""
            Else
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

            GuardaEliminaRegistroFacturaGeneradaDetalle(Compañia, Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, CurRow.Cells("codProd").Value, "", 0, 0, 0, 0, 0, 0, 0, 0, "D", 0, 0, 0)
            'TODO Se quita esta funcionalidad de ORden Venta
            ''GuardaEliminaRegistroFacturaDetalleOV(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, "", 0, 0, 0, 0, 0, 0, 0, exento, "D")
            ''***
            ''If Me.era_producto_especial(CurRow.Cells("PRODUCTO").Value) Then
            ''    Me.Actualizar_inventario_precio_especial(Compañia, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, CurRow.Cells("PRECIO_UNITARIO").Value, obtener_IDPROD_PRE_ESP(CurRow.Cells("PRODUCTO").Value), CurRow.Cells("CANTIDAD").Value, "A")
            ''    Me.Se_encuentra_producto_especial(CurRow.Cells("PRODUCTO").Value)
            ''End If
            ''***
            ''cargaFacturaDetalle(Me.txtNoFact.Text, Me.cmbTipDoc.SelectedValue, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
            Me.dgvCuentasEquivalentes.Rows.RemoveAt(Me.dgvCuentasEquivalentes.CurrentRow.Index)
            lblMaxLineas.Text = Val(lblMaxLineas.Text) + 1
            totalizaFacturanew()
            GuardaEliminaFacturaGeneradaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, codClie, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, NRC, TipContrib, exento, CondPago, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), Val(Me.txtIVA.Text), Val(Me.txtTotFact.Text), Me.chkImpConcepto.Checked, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.dtpFechaPago.Value, _
                                Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, _
                                Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, TipClie, TipContrib, dirClie, giro, "U")

        Else
            Me.dgvCuentasEquivalentes.Rows.RemoveAt(Me.dgvCuentasEquivalentes.CurrentRow.Index)
            lblMaxLineas.Text = Val(lblMaxLineas.Text) + 1
            totalizaFacturanew()
        End If
        Me.btnGuardarDetalle.Enabled = True
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False
        _error_ = False
        imprimeFactura(Compañia, Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, Numero_OV, "Factura no. " & Me.txtNoFact.Text)

        If Not _error_ Then
            Resetear_montomaximo("", Me.txtCliente.Text)
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
    'Private Sub cargaHistorialFacturas(ByVal cliente As String, ByVal flag As Integer)
    '    Dim TableX As DataTable
    '    If cliente = Nothing Then
    '        cliente = 0
    '    End If
    '    Try
    '        sql = "SELECT F.FECHA_FACTURA AS FECHA,T.DESCRIPCION_TIPO_DOCUMENTO AS TIPO,F.NUMERO_FACTURA AS FACTURA,F.TOTAL_FACTURA AS TOTAL,F.CUOTAS,F.PERIODO_PAGO AS PERIODO,F.DESCUENTO_AGUINALDO AS AGUINALDO, F.DESCUENTO_BONIFICACION AS BONIFICACION,F.FACTURA_IMPRESA AS IMPRESA"
    '        sql &= "  FROM dbo.FACTURACION_GENERADA_ENCABEZADO F, dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO T "
    '        sql &= " WHERE F.COMPAÑIA = T.COMPAÑIA AND F.TIPO_DOCUMENTO = T.TIPO_DOCUMENTO"
    '        sql &= "   AND F.CODIGO_EMPLEADO = " & cliente
    '        sql &= "   AND F.BODEGA = " & Me.cmbBODEGA.SelectedValue
    '        sql &= "   AND F.ANULADA = 0"
    '        TableX = jClass.obtenerDatos(New SqlCommand(sql)) 'New DataTable("Datos")
    '        Me.DataGridView1.Columns.Clear()
    '        Me.DataGridView1.DataSource = TableX
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
    '    End Try
    'End Sub

    Private Sub crearFactura_OVEncabezado(ByVal CIA As Integer, _
                                            ByVal Bodega As Integer, _
                                            ByVal fechafact As DateTime, _
                                            ByVal TipDoc As Integer, _
                                            ByVal NoFact As String, _
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
        'TODO Se quita esta funcionalidad de Orden Venta
        'GuardaEliminaOrdenVentaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NomFact, Concepto, FormaPago, CondPago, TipClie, TipContrib, exento, NRC, giro, codBuxis, CodCliente, dirClie, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "I")
        'If Not _error_ Then
        GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NRC, TipContrib, exento, CondPago, NomFact, SubTotal, IVA, Total, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "I")
        'End If
    End Sub

    Private Sub GrabaDetalleFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact As Integer, ByVal FechaMov As DateTime, _
                                    ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                    ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal SubTotalFact As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                    ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Tot_Factura As Double, ByVal totIVA As Double, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal pordesct As Double, ByVal descuento As Double, ByVal aplcesc As Boolean)
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
        GuardaEliminaRegistroFacturaGeneradaDetalle(CIA, Bodega, TipDoc, numdoc, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Total, Grupo, SubGrupo, "I", pordesct, descuento, aplcesc)
        If Not _error_ Then
            _error_ = False
            'TODO En este punto descarga de inventario antes de procesar la factura
            'GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, TipDoc, numdoc, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, TipDoc, Val(NoFact)), "I", TipCosto)
            GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, TipDoc, numdoc, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, 0, Numero_OV), "I", TipCosto)
            'If FactCreada And Not _error_ Then
            '    GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, numdoc, NRC, TipClie, exento, CondPago, NomFact, SubTotalFact, totIVA, Tot_Factura, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, TipClie, TipContrib, dirClie, giro, "U")
            'End If
        Else
            MsgBox("Error al ingresar detalle de factura" & vbCrLf & "- No se pudo agreagar producto " & codProd & " " & descProd, MsgBoxStyle.Information, "Error Procesar")
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
        sql &= ", '" & Format(fecha, "dd/MM/yyyy") & "') AS Costo_Unitario"
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
        Dim descAguin, descBoni, AhorroE, subtotfact, ivaFact, totalfact, grandesc As Double

        'Dim curRow As Integer
        '
        Me.generaGrid()
        '
        If Not Iniciando Then
            Try
                'Esto se hace para encontrar la ultima orden de venta correspondiente al numero de factura
                'ya que si existe el mismo numero de factura en la misma bodega el numero de orden de venta
                'nos sirve como filtro, si no se encuentra una orden de venta entonces el numero de factura
                'no se ha usado para la serie de correlativo actual
                sql = " SELECT ISNULL(MAX(ORDEN_VENTA), 0) FROM FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                sql &= " WHERE COMPAÑIA = " & CIA & vbCrLf
                sql &= "   AND BODEGA = " & Bodega & vbCrLf
                sql &= "   AND TIPO_DOCUMENTO = " & tipdoc & vbCrLf
                sql &= "   AND NUMERO_FACTURA = " & numfact & vbCrLf
                sql &= "   AND SERIE = " & Numero_Serie
                Numero_OV = jClass.obtenerEscalar(sql)

                sql = "SELECT FGE.NUMERO_FACTURA, FGE.SERIE, FGE.BODEGA, FGE.ORDEN_VENTA, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGE.ANULADA, FGE.NOMBRE_FACTURA, FGE.PERIODO_PAGO, FGE.CUOTAS, FGE.DESCONTAR_CUOTAS_DESDE, FGE.DESCUENTO_AGUINALDO, FGE.DESCUENTO_BONIFICACION, FGE.NUMERO_REMESA, FGE.SUB_TOTAL, FGE.TOTAL_IVA, FGE.TOTAL_FACTURA, FGE.CLIENTE, FGE.NIT, FGE.BANCO_REMESA, FGE.CUENTA_BANCO_REMESA, FGE.AHORRO_EXTRA, FGE.RETENCION "
                sql &= "FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE"
                sql &= " WHERE FGE.COMPAÑIA = " & CIA
                sql &= " AND FGE.BODEGA = " & Bodega
                sql &= " AND FGE.TIPO_DOCUMENTO = " & tipdoc
                sql &= " AND FGE.NUMERO_FACTURA = " & numfact
                sql &= " AND FGE.ORDEN_VENTA = " & Numero_OV
                sqlCmd.CommandText = sql
                Table2 = jClass.obtenerDatos(sqlCmd)
                If Table2.Rows.Count > 0 Then
                    FactCreada = True
                    If Table2.Rows(0).Item("ANULADA") Then
                        Me.Label21.Text = "FACTURA ANULADA DISPONIBLE SOLO PARA CONSULTA"
                        btnProcesar.Enabled = False
                        Me.btnImprimir.Enabled = False
                    ElseIf Table2.Rows(0).Item("FACTURA_IMPRESA") Then
                        Me.Label21.Text = "FACTURA IMPRESA DISPONIBLE SOLO PARA CONSULTA"
                        btnProcesar.Enabled = False
                        Me.btnImprimir.Enabled = True
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
                    Me.txtNoFact.Tag = jClass.obtenerEscalar("SELECT N_SOLICITUD FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA = " & Me.txtNoFact.Text & " AND CODIGO_BUXIS = " & Me.txtCliente.Text)
                    If Val(Me.txtNoFact.Tag) > 0 Then
                        llenar_dgvFiadores(Fiadores(5, Me.txtCliente.Text, Me.txtNoFact.Tag, 0))
                    End If
                    'Me.txtCliente.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    'Me.lblCodBuxis.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.cmbFormaPago.SelectedValue = Table2.Rows(0).Item("FORMA_PAGO")
                    Me.cmbPeriodoPago.SelectedValue = Table2.Rows(0).Item("PERIODO_PAGO")
                    Me.txtNumCuotas.Text = Table2.Rows(0).Item("CUOTAS")
                    If Table2.Rows(0).Item("FORMA_PAGO") = 1 Then
                        Me.txtNoRemesa.Text = Table2.Rows(0).Item("NUMERO_REMESA")
                        Me.cmbBancos.SelectedValue = Table2.Rows(0).Item("BANCO_REMESA")
                        Me.cmbCtasBanco.SelectedValue = Table2.Rows(0).Item("CUENTA_BANCO_REMESA")
                    End If
                    subtotfact = Table2.Rows(0).Item("SUB_TOTAL")
                    ivaFact = Table2.Rows(0).Item("TOTAL_IVA")
                    totalfact = Table2.Rows(0).Item("TOTAL_FACTURA")
                    descAguin = Table2.Rows(0).Item("DESCUENTO_AGUINALDO")
                    descBoni = Table2.Rows(0).Item("DESCUENTO_BONIFICACION")
                    AhorroE = Table2.Rows(0).Item("AHORRO_EXTRA")
                    grandesc = Table2.Rows(0).Item("RETENCION")
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    Me.txtSUBTOTAL.Text = subtotfact.ToString("0.00")
                    Me.txtIVA.Text = ivaFact.ToString("0.00")
                    Me.txtTotFact.Text = totalfact.ToString("0.00")
                    Me.txtDescAGUI.Text = descAguin.ToString("0.00")
                    Me.txtDescBONI.Text = descBoni.ToString("0.00")
                    Me.txtAhorroExt.Text = AhorroE.ToString("0.00")
                    Me.txtCESC.Text = grandesc.ToString("0.00")
                    Me.btnGuardarDetalle.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.btnEliminaDetalle.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.btnGuardaFacturaEncabezado.Enabled = Not Table2.Rows(0).Item("FACTURA_IMPRESA")
                    Me.cmbBODEGA.Enabled = False
                    'datosSocio(Me.txtCliente.Text, Me.lblCodBuxis.Text)
                    Me.txtNomFact.Text = Table2.Rows(0).Item("NOMBRE_FACTURA")
                    sql = "SELECT FGD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, FGD.CANTIDAD, FGD.PRECIO_UNITARIO, FGD.PRECIO_TOTAL, FGD.BODEGA, FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO, FGE.NUMERO_FACTURA, FGE.ANULADA, FGD.LINEA, IME.TIPO_MOVIMIENTO, IME.MOVIMIENTO, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.IMPRIMIR_CONCEPTO, FGE.CONCEPTO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGD.unidad_medida, FGD.PORCENTAJE_DESCUENTO, FGD.VALOR_DESCUENTO, FGD.APLICA_CESC  FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_GENERADA_DETALLE FGD,dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM WHERE FGE.BODEGA = FGD.BODEGA AND FGE.COMPAÑIA = FGD.COMPAÑIA AND FGE.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO AND FGE.NUMERO_FACTURA = FGD.NUMERO_FACTURA AND FGD.ORDEN_VENTA = FGE.ORDEN_VENTA AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FGD.PRODUCTO = IMD.PRODUCTO AND FGD.COMPAÑIA = ICP.COMPAÑIA AND FGD.PRODUCTO = ICP.PRODUCTO AND ICUM.COMPAÑIA = FGD.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA AND IMD.ENTRADA_SALIDA = 0"
                    sql &= " AND FGE.COMPAÑIA = " & CIA
                    sql &= " AND FGE.BODEGA = " & Bodega
                    sql &= " AND FGE.TIPO_DOCUMENTO = " & tipdoc
                    sql &= " AND FGE.NUMERO_FACTURA = " & numfact
                    sql &= " AND FGE.ORDEN_VENTA = " & Numero_OV
                    sql &= " ORDER BY FGD.LINEA"
                    sqlCmd.CommandText = sql
                    Table = jClass.obtenerDatos(sqlCmd)

                    '**** 
                    For Each dr As DataRow In Table.Rows
                        prIngresar(dr.Item("PRODUCTO"), dr.Item("DESCRIPCION_PRODUCTO"), dr.Item("DESCRIPCION_UNIDAD_MEDIDA"), dr.Item("CANTIDAD"), dr.Item("PRECIO_UNITARIO"), dr.Item("PRECIO_TOTAL"), dr.Item("unidad_medida"), dr.Item("linea"), dr.Item("TIPO_MOVIMIENTO"), dr.Item("MOVIMIENTO"), dr.Item("ORDEN_VENTA"), dr.Item("VALOR_DESCUENTO"), dr.Item("PORCENTAJE_DESCUENTO"), 0, 0, dr.Item("APLICA_CESC"))
                    Next

                    For a As Integer = 6 To Me.dgvCuentasEquivalentes.Columns.Count - 1
                        Me.dgvCuentasEquivalentes.Columns(a).Visible = False
                    Next

                    Me.dgvCuentasEquivalentes.Columns(11).Visible = True
                    Me.dgvCuentasEquivalentes.Columns(12).Visible = True
                    Me.dgvCuentasEquivalentes.Columns("apcesc").Visible = True

                    If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
                        Me.dgvCuentasEquivalentes.FirstDisplayedScrollingRowIndex = Me.dgvCuentasEquivalentes.Rows.Count - 1
                    End If

                    'If Me.cmbTipDoc.SelectedValue = 2 Then
                    '    For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                    '        row.Cells(4).Value = Math.Round(row.Cells(4).Value / (1 + (PorcIVA / 100)), 4)
                    '        row.Cells(5).Value = Math.Round(row.Cells(5).Value / (1 + (PorcIVA / 100)), 2)
                    '    Next
                    'End If
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
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal Accion As String, ByVal porcdes As Double, ByVal descuento As Double, ByVal CESC As Boolean)
        Dim corre As Integer
        Dim sqlcmd As New SqlCommand
        Try
            sql = "EXECUTE dbo.sp_FACTURACION_GENERADA_DETALLE_IUD " & vbCrLf
            sql &= " @COMPAÑIA        = " & CIA & vbCrLf
            sql &= ",@BODEGA          = " & Bodega & vbCrLf
            sql &= ",@ORDEN_VENTA     = " & Numero_OV & vbCrLf
            sql &= ",@TIPO_DOCUMENTO  = " & TipDoc & vbCrLf
            sql &= ",@NUMERO_FACTURA  = " & NoFact & vbCrLf
            sql &= ",@LINEA           = " & totRegFact & vbCrLf
            sql &= ",@PRODUCTO        = " & codProd & vbCrLf
            sql &= ",@NOMBRE_PRODUCTO = '" & descProd.Replace("'", "-") & "'" & vbCrLf
            sql &= ",@UNIDAD_MEDIDA   = " & UM & vbCrLf
            sql &= ",@CANTIDAD        = " & Cant & vbCrLf
            sql &= ",@LIBRAS          = 0" & vbCrLf
            sql &= ",@COSTO_UNITARIO  = " & CostoU & vbCrLf
            sql &= ",@COSTO_TOTAL     = " & CostoT & vbCrLf
            sql &= ",@PRECIO_UNITARIO = " & PrecProd & vbCrLf
            sql &= ",@PRECIO_TOTAL    = " & Total & vbCrLf
            sql &= ",@CODIGO_GRUPO    = " & Grupo & vbCrLf
            sql &= ",@CODIGO_SUBGRUPO = " & SubGrupo & vbCrLf
            sql &= ",@ORIGEN          = " & Origen & vbCrLf
            sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD             = '" & Accion & "'" & vbCrLf
            sql &= ",@PORDESCTO       = " & porcdes & vbCrLf
            sql &= ",@DESCUENTO       = " & descuento & vbCrLf
            sql &= ",@APLICA_CESC     = " & IIf(CESC, "1", "0") & vbCrLf
            sqlcmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlcmd)
            If corre = 0 Then
                _error_ = True
            End If
            'MsgBox("Registros actualizados: " + corre.ToString, MsgBoxStyle.Exclamation, "Factura Detalle")
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaMovimientoInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov As Integer, ByVal Accion As String, ByVal tipoCosto As Integer)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", 0" 'PROVEEDOR?
            sql &= ", " & TipMov 'TIPO_MOVIMIENTO
            sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            sql &= ", 0" 'MOV1
            sql &= ", " & TipDoc 'TIPO_DOCUMENTO_CONTABLE
            sql &= ", " & NoFact 'NUMERO_DOCUMENTO_CONTABLE
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

    'TODO Se quita esta funcionalidad, se analizó que Orden Venta no se ocupa en sistema 
    'ISAAC MATAL: SI HUBIERAN ANALIZADO MAS, SE HUBIERAN DADO CUENTA QUE EXISTE UN FORMULARIO QUE SI TOMA LOS DATOS DE ORDEN DE VENTA PARA CREAR LAS FACTURAS POR LOTE, SE DISEÑO PARA QUE UNA ORDEN DE VENTA TUVIERA N REGISTROS DE PRODUCTOS Y AL IMPRIMIR, EL PROCESO GENERARIA LAS FACTURAS APROPIADAMENTE, EL FORMULARIO ES Facturacion_Bodegas_Despensa
    '             SOLO TENIAN QUE QUITAR LA FK EN LA BASE DE DATOS QUE RELACIONABA LAS TABLAS DE FACTURACION_GENERADA_ENCABEZADO Y FACTURACION_FACTURAS_ENCABEZADO, LO RARO ES QUE NO QUITARON QUE SE GENERARA EL NUMERO DE ORDEN DE VENTA PARA LA FACTURA GENERADA, ¡QUE GRAN ANALISIS SE HECHARON! ¡Y LO QUE COBRARON CON ALEGRIA POR PONER SOLO TRES MODULOS EN PRODUCCION!
    'Private Sub GuardaEliminaOrdenVentaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NomFact As String, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal Condicion As Integer, ByVal TipoCliente As Integer, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal NRCCliente As String, ByVal GiroClie As String, ByVal codBuxis As String, ByVal codSocio As String, ByVal Direccion As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaMov As Date, _
    '                                                    ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal Accion As String)
    '    ''TCENCPRIMERA
    '    Dim totReg, corre As Integer
    '    Dim sqlCmd As New SqlCommand
    '    Try
    '        If periodoPago = "BO" Then
    '            descontarDesde = CDate("12/06/" & Now.Year.ToString)
    '            If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
    '                descontarDesde = descontarDesde.AddYears(1)
    '            End If
    '        End If
    '        If periodoPago = "AG" Then
    '            descontarDesde = CDate("12/12/" & Now.Year.ToString)
    '            If Now.Date.AddDays(5) >= CDate(descontarDesde) Then
    '                descontarDesde = descontarDesde.AddYears(1)
    '            End If
    '        End If
    '        If Not FactCreada Then
    '            Numero_OV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
    '        End If
    '        sql = " Execute dbo.sp_FACTURACION_FATURAS_ENCABEZADO_IUD "
    '        sql &= CIA
    '        sql &= ", " & Bodega
    '        sql &= ", " & Numero_OV
    '        sql &= ", '" & Format(FechaMov, "Short Date") & "'"
    '        sql &= ", " & TipDoc
    '        sql &= ", " & NoFact
    '        sql &= ", '" & Format(FechaMov, "Short Date") & "'"
    '        sql &= ", " & FormaPago
    '        sql &= ", " & Condicion
    '        sql &= ", " & codCliente
    '        sql &= ", " & codBuxis
    '        sql &= ", '" & codSocio & "'"
    '        sql &= ", " & TipoCliente
    '        sql &= ", " & TipoContribuyente
    '        sql &= ", '" & NomFact & "'"
    '        sql &= ", '" & Direccion & "'"
    '        sql &= ", '" & txtDUI & "'"
    '        sql &= ", '" & txtNIT & "'"
    '        sql &= ", '" & NRCCliente & "'"
    '        sql &= ", '" & GiroClie & "'"
    '        sql &= ", " & es_exento
    '        sql &= ", 0" 'Imprimir Concepto?
    '        sql &= ", '" & Concepto & "'"
    '        sql &= ", ''" 'Observaciones
    '        sql &= ", " & Origen
    '        sql &= ", '" & Usuario & "'"
    '        sql &= ", '" & Accion & "'"
    '        sql &= ", '" & periodoPago & "'"
    '        sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
    '        sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
    '        sql &= ", " & DescuentoAguinaldo
    '        sql &= ", " & DescuentoBonificacion
    '        sql &= ", '" & NumRemesa & "'"
    '        sql &= ", " & IIf(FormaPago = 1, Banco, 0)
    '        sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
    '        sqlCmd.CommandText = sql
    '        totReg = jClass.ejecutarComandoSql(sqlCmd)
    '        If totReg > 0 And Not FactCreada Then
    '            corre = FPro.actualizaNumDoc(CIA, "OV")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
    '        _error_ = True
    '    End Try
    'End Sub

    Private Sub GuardaEliminaFacturaGeneradaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                       ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                       ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                       ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, _
                                                       ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal TipClie As Integer, ByVal TipContrib As Integer, ByVal dirClie As String, ByVal giro As String, ByVal Accion As String)

        ''TCENCGENERADAS
        Dim totReg, corre As Integer
        Dim Retencion As Double = 0
        Dim sqlCmd As New SqlCommand
        Try
            If DescuentoAguinaldo + DescuentoBonificacion = Val(Total) And Val(Me.txtTotFact.Text) > 0 Then
                Cuotas = 0
                Me.txtNumCuotas.Text = "0"
                periodoPago = "AG"
            End If
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
            ''If (TipoContribuyente = 1 Or TipoContribuyente = 2) And TipDoc = 2 And Not exento And Contribuyente = 3 Then
            Retencion = Val(txtCESC.Text)
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
            sql = " Execute dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & Numero_OV
            sql &= ", " & NoFact
            sql &= ", '" & NomFact & "'"
            sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            sql &= ", " & codCliente
            sql &= ", " & Numero_Serie
            sql &= ", " & CC 'CENTRO COSTO
            sql &= ", " & TipDoc
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
            sql &= ", 0" 'Caja
            sqlCmd.CommandText = sql
            jClass.ejecutarComandoSql(sqlCmd)
            sql = "SELECT COUNT(NUMERO_FACTURA) FROM dbo.FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
            sql &= " WHERE COMPAÑIA = " & CIA & " AND BODEGA = " & Bodega & " AND ORDEN_VENTA = " & Numero_OV & vbCrLf
            sql &= " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & NoFact
            totReg = Val(jClass.obtenerEscalar(sql))
            If totReg = 0 Then
                _error_ = True
            End If
            If totReg > 0 And Not FactCreada And Not _error_ Then
                corre = FPro.actualizaNumDoc(CIA, "OV")
                elimAutAguiboni()
                If Accion = "I" Then
                    NoFact = actualizaCorrelativoFactura(CIA, Bodega, Numero_Serie, TipDoc)
                    Me.txtNoFact.Text = NoFact
                End If
            End If
            If Not _error_ Then
                If Val(Me.txtAhorroExt.Text) > 0 Then
                    sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET AHORRO_EXTRA = " & Val(Me.txtAhorroExt.Text)
                    sql &= " WHERE COMPAÑIA = " & CIA & " AND BODEGA = " & Bodega & " AND ORDEN_VENTA = " & Numero_OV
                    sql &= " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & NoFact
                    sqlCmd.CommandText = sql
                    jClass.ejecutarComandoSql(sqlCmd)
                    If Total - Val(Me.txtAhorroExt.Text) = 0 Then
                        sqlCmd.CommandText = "UPDATE FACTURACION_GENERADA_ENCABEZADO SET FORMA_PAGO = 1, CONDICION_PAGO = 8 WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA = " & NoFact & " AND ORDEN_VENTA = " & Numero_OV
                        jClass.ejecutarComandoSql(sqlCmd)
                    End If
                End If
                'TC III
                If Me.intCodAutoconsumo > 0 Then
                    prRegistroAutorizacion(intCodAutoconsumo, 1, NoFact, Numero_OV, 0)
                End If

                FactCreada = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Encabezado")
            _error_ = True
        End Try
    End Sub

    Private Sub bntNuevaFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevaFact.Click
        Me.dpFECHA_CONTABLE.Enabled = True
        Me.limpiaCampos(0)
        i = 0
        Me.cmbBODEGA.Enabled = True
        Me.producto_especial = 0
        Me.cantidad_precio_especial = 0
        Me.chkPre_normal.Checked = True
        Me.cmbFormaPago.Enabled = True
        btnProcesar.Enabled = True
        Erase Me.productos_facturados
        ReDim Me.productos_facturados(100, 2)
        CheckDisponible.Checked = False
        CheckDisponible.Enabled = True
        Me.txtMotivoBloqueo.Visible = False
        Me.txtSinFiador.Clear()
        Me.txtConFiador.Clear()
        While Me.dgvFiadores.Rows.Count > 0
            Me.dgvFiadores.Rows.RemoveAt(0)
        End While
        'Timer1.Enabled = True
    End Sub

    Private Function ValidaNumeroFacturaSerie(ByVal NoFact As Integer) As Boolean
        Dim sqlCmd As New SqlCommand
        sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
        sql &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", '0'" 'DESCRIPCION_SERIE
        sql &= ", " & Me.cmbTipDoc.SelectedValue
        sql &= ", 1" 'BANDERA
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            For a As Integer = 0 To Table.Rows.Count - 1
                If Table.Rows(a).Item("Activa") Then
                    If NoFact >= Table.Rows(a).Item("Inicio") And NoFact <= Table.Rows(a).Item("Final") And Table.Rows(a).Item("Activa") Then
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
            'TODO Se quita esta funcionalidad
            'Me.dgvCuentasEquivalentes.Columns.Clear()
            'Me.dgvCuentasEquivalentes.Columns.Add("Producto", "Producto")
            'Me.dgvCuentasEquivalentes.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(0).Width = 70
            'Me.dgvCuentasEquivalentes.Columns.Add("descprod", "Descripción Producto")
            'Me.dgvCuentasEquivalentes.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(1).Width = 260
            'Me.dgvCuentasEquivalentes.Columns.Add("UM", "Unidad Medida")
            'Me.dgvCuentasEquivalentes.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(2).Width = 70
            'Me.dgvCuentasEquivalentes.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.dgvCuentasEquivalentes.Columns.Add("Cant", "Cantidad")
            'Me.dgvCuentasEquivalentes.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(3).Width = 80
            'Me.dgvCuentasEquivalentes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.dgvCuentasEquivalentes.Columns.Add("PU", "Precio Unit.")
            'Me.dgvCuentasEquivalentes.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(4).Width = 80
            'Me.dgvCuentasEquivalentes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.dgvCuentasEquivalentes.Columns.Add("total", "TOTAL")
            'Me.dgvCuentasEquivalentes.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.dgvCuentasEquivalentes.Columns(5).Width = 90
            'Me.dgvCuentasEquivalentes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.dgvCuentasEquivalentes.Width = 694
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardaFacturaEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaFacturaEncabezado.Click
        If Not validaCamposVacios() Then
            Return
        End If
        _error_ = False
        'TODO Se quita esta funcionalidad
        'GuardaEliminaOrdenVentaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, codClie, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, Me.txtNomFact.Text, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, CondPago, TipClie, TipContrib, exento, NRC, giro, Me.lblCodBuxis.Text, Me.txtCliente.Text, dirClie, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Me.txtNumCuotas.Text, Me.DateTimePicker1.Value, Me.txtDescAGUI.Text, Me.txtDescBONI.Text, Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, IIf(FactCreada, "U", "I"))
        'If Not _error_ Then
        '    _error_ = False
        '    GuardaEliminaFacturaGeneradaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, codClie, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, NRC, TipClie, exento, CondPago, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), Val(Me.txtIVA.Text), Val(Me.txtTotFact.Text), Me.chkImpConcepto.Checked, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.DateTimePicker1.Value, _
        '                        Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, IIf(FactCreada, "U", "I"))
        'End If
        If Not _error_ And MSJ Then
            MsgBox("Factura Actualizada con éxito", MsgBoxStyle.Information, "Guardar")

        End If
    End Sub

    Private Sub txtNoFact_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoFact.LostFocus
        Dim numfactura As String
        'Timer1.Enabled = False
        numfactura = Me.txtNoFact.Text
        If ValidaNumeroFacturaSerie(Val(numfactura)) Then
            cargaFacturaDetalle(Me.txtNoFact.Text, Me.cmbTipDoc.SelectedValue, Compañia, Me.cmbBODEGA.SelectedValue)
        Else
            MsgBox("Factura No." & numfactura & " no corresponde a bodega: " & vbCrLf & Me.cmbBODEGA.Text, MsgBoxStyle.Exclamation, "Factura No Encontrada")
            ObtieneNumeroFactura()
            Return
        End If
        If FactCreada = False Then
            If MsgBox("Factura No. " & numfactura & " aun no ha sido generada" & vbCrLf & vbCrLf & "¿Desea usar este numero en este momento?" & vbCrLf, MsgBoxStyle.YesNo, "Factura No Encontrada") = MsgBoxResult.Yes Then
                Me.txtNoFact.Text = numfactura
            End If
            'Timer1.Enabled = True
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
        If Val(Me.txtNumCuotas.Text) = 0 And Me.cmbFormaPago.SelectedValue = 2 And (Me.cmbPeriodoPago.SelectedValue = "QQ" Or Me.cmbPeriodoPago.SelectedValue = "MM") Then
            MsgBox("Número Cuotas debe ser mayor que cero", MsgBoxStyle.Critical, "Cuotas No Válido")
            Return False
        End If
        Return True
    End Function

    Private Sub cmbTipDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipDoc.SelectedIndexChanged
        limpiaCampos(0)
        Me.cmbBODEGA.Enabled = True
        If Not Iniciando Then
            If Me.cmbTipDoc.SelectedValue = 1 Then
                TipMovInv = TipMovInvFact
            ElseIf Me.cmbTipDoc.SelectedValue = 2 Then
                TipMovInv = TipMovInvCCF
            End If
        End If
    End Sub

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
        Me.dtpFechaPago.Visible = Not sender.checked
        Me.cmbCONDICION_PAGO.Visible = sender.checked
        Me.Label22.Visible = sender.checked
        Me.CheckDisponible.Visible = Not sender.checked
        Me.Label7.Visible = Not sender.checked
        Me.lblCodBuxis.Visible = Not sender.checked
        Me.Label23.Visible = Not sender.checked
        Me.txtAhorroExt.Visible = Not sender.checked
        If sender.checked Then
            Me.Label8.Text = "Cliente :"
            Me.Label13.Text = "Nombre Cliente :"
            'Me.TabPage2.Text = "Historial Facturas del Cliente"
            'Me.cmbTipDoc.SelectedValue = 2
        Else
            Me.Label8.Text = "Codigo :"
            Me.Label13.Text = "Nombre :"
            'Me.TabPage2.Text = "Historial Facturas del Socio"
            'Me.cmbTipDoc.SelectedValue = 1
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If Not Iniciando Then
            multi.CargaCondicionPago(Compañia, Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO)
            Me.cmbCONDICION_PAGO.SelectedIndex = 0
            CondPago = Me.cmbCONDICION_PAGO.SelectedValue
            If cmbFormaPago.Text.ToUpper = "CREDITO" Or cmbFormaPago.Text.ToUpper = "CRÉDITO" Then
                Me.txtNumCuotas.Text = "1"
            Else
                Me.txtNumCuotas.Text = "0"
            End If
            If cmbFormaPago.Text.ToUpper = "CONTADO" Then
                Me.Label17.Visible = True
                Me.Label28.Visible = True
                Me.Label29.Visible = True
                Me.txtNoRemesa.Visible = True
                Me.cmbBancos.Visible = True
                Me.cmbCtasBanco.Visible = True
                Me.cmbBancos.SelectedIndex = 6
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
        Dim FechaPago As Date
        Dim totFact, descPeriodos As Double
        Dim numSoli As Integer
        Dim NumPartida As Integer = 0
        Dim CtaContable As Integer = 0
        Dim descAgui As Double = Val(Me.txtDescAGUI.Text)
        Dim descBoni As Double = Val(Me.txtDescBONI.Text)
        Dim AhorrosExt As Double = Val(Me.txtAhorroExt.Text)
        Dim documento As CrystalDecisions.CrystalReports.Engine.ReportClass
        Me.btnGuardaFacturaEncabezado.PerformClick()
        MSJ = False
        If Val(Me.txtTotFact.Text) > 0 Then
            If AhorrosExt >= Val(Me.txtTotFact.Text) And Val(Me.txtTotFact.Text) > 0 And Me.cmbFormaPago.SelectedValue = 2 Then
                Me.cmbFormaPago.SelectedValue = 1
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

        If TipDoc = 1 Then
            documento = New Facturacion_Factura_Consumidor_Final_Almacen
            sql = "EXECUTE sp_FACTURACION_IMPRIME_FACTURA_CONSUMIDOR_FINAL " & vbCrLf
            sql &= "  @TIPO_DOCUMENTO = " & TipDoc & vbCrLf
            sql &= ", @NUMERO_DOCUMENTO = " & numFactura & vbCrLf
            sql &= ", @BANDERA = 0" & vbCrLf
            sql &= ", @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @BODEGA = " & cmbBODEGA.SelectedValue
            sql &= ", @OV = " & Numero_OV
        Else
            documento = New Contabilidad_CuentasxCobrar_Facturacion_Reportes_CCF
            sql = "EXECUTE sp_FACTURACION_GENERADA_REPORTES_CCF "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numPedido
            sql &= ", " & numFactura
            sql &= ", " & TipDoc
            sql &= ", ''" 'TOTAL EN LETRAS
            sql &= ", 4" 'MUNICIPIO
            sql &= ", 8" 'DEPTO
            sql &= ", 1" 'PAIS
            sql &= ", 1" 'BANDERA
        End If
        Try
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                If TipDoc = 2 Then
                    totFact = Table.Rows(0).Item("SUB_TOTAL")
                Else
                    totFact = Table.Rows(0).Item("TOT_FACT")
                End If
                If Not Me.chkCliExt.Checked And Not Label21.Visible And Me.cmbFormaPago.SelectedValue = 2 Then
                    If CInt(jClass.obtenerEscalar("SELECT COUNT(NUMERO_FACTURA) FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE NUMERO_FACTURA = " & numFactura & " AND CODIGO_BUXIS = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Compañia)) = 0 Then
                        descPeriodos = totFact - descAgui - descBoni - AhorrosExt
                        numSoli = FPro.actualizaNumDoc(CIA, "SOL")
                        Dim CodDeduc As Integer
                        CodDeduc = CInt(jClass.obtenerEscalar("SELECT DEDUCCION FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE SOLICITUD = " & TipoSolicitud & " AND COMPAÑIA = " & Compañia))
                        If CodDeduc = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 18 AND COMPAÑIA = " & Compañia)) Then
                            Me.txtNumCuotas.Text = "1"
                            Me.dtpFechaPago.Value = setFechaPago()
                        End If
                        'TODO Se desahabilita esta función para solventar mensaje de error al imprimir
                        'Se activa nuevamente con la entrada en funcionamiento del módulo de Cooperativa 05/12/2013
                        FechaPago = Me.dtpFechaPago.Value
                        If Me.dtpFechaPago.Value.Day >= 28 And Me.dtpFechaPago.Value.Day <= 30 And jClass.obtenerEscalar("SELECT COUNT(FECHA_PAGO) FROM COOPERATIVA_RESUMEN_DESCUENTOS_ENVIADOS WHERE COMPAÑIA = " & Compañia & " AND FECHA_PAGO = '" & Format(Me.dtpFechaPago.Value, "dd/MM/yyyy") & "' AND PERIODO_PAGO = 'MM'") > 0 And PeriodoPago.Trim() = "MM" Then
                            FechaPago = Me.dtpFechaPago.Value.AddMonths(1)
                        End If
                        If Not ("0,1,4").Contains(Me.txtCliente.Text) Then
                            FPro.SolicitudesFacturacionSocios(CIA, TipoSolicitud, numSoli, Me.txtCliente.Text, Me.lblCodBuxis.Text, Me.dpFECHA_CONTABLE.Value, 1, descPeriodos, descAgui, descBoni, Me.cmbPeriodoPago.SelectedValue, Val(Me.txtNumCuotas.Text), FechaPago, "Factura No. " & numFactura & " Generada en " & Me.cmbBODEGA.Text, TipDoc, numFactura)
                            For i As Integer = 0 To Me.dgvFiadores.Rows.Count - 1
                                Fiadores(2, Me.txtCliente.Text, numSoli, Me.dgvFiadores.Rows(i).Cells(0).Value)
                            Next
                        End If
                    End If
                End If
                Table = jClass.obtenerDatos(sqlCmd)

                'TODO manejo de Impresión Personalizado
                Dim instance As New Printing.PrinterSettings
                Dim impresorPredt As String = instance.PrinterName
                'Dim print_name As String = Configuration.ConfigurationSettings.AppSettings("ImpresorASTAS")
                Dim print_name As String = impresorPredt
                'Obtener nombre de hoja personalizada

                Dim print_paper As String
                'If TipDoc = 1 Then
                '    print_paper = Configuration.ConfigurationSettings.AppSettings("FacturaCF")
                'Else
                '    print_paper = Configuration.ConfigurationSettings.AppSettings("FacturaCCF")
                'End If

                If TipDoc = 1 Then
                    print_paper = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 37").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCF")
                Else
                    print_paper = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 38").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCCF")
                End If

                'Opciones del Crystal Report
                Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
                'Se aplican al informe
                With documento
                    'Se obtienen la opciones de impresion
                    repOptions = .PrintOptions
                    'Se setean las opciones
                    With repOptions
                        'Obtiene el id del papel --> utiliza una función especial
                        .PaperSize = GetPapersizeID(print_name, print_paper)
                        'Señala la impresora a utilizar
                        .PrinterName = print_name
                    End With
                End With


                documento.SetDataSource(Table)
                documento.PrintToPrinter(1, True, 0, 0)
                'Actualizar bandera de impreso para la factura
                sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET FACTURA_IMPRESA = 1, OBSERVACIONES = '" & Observ & "' ,  NUMERO_PARTIDA = " & NumPartida
                sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
                sql &= " AND TIPO_DOCUMENTO=" & TipDoc & " AND NUMERO_FACTURA=" & numFactura
                sqlCmd.CommandText = sql
                jClass.ejecutarComandoSql(sqlCmd)
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
                sql &= ", " & Me.cmbTipDoc.SelectedValue.ToString()
                sql &= ", '" & Usuario & "'"
                sql &= ", GETDATE()"
                sql &= ", '" & Usuario & "'"
                sql &= ", GETDATE()"
                sql &= ", GETDATE()"
                sql &= ",'" & "Pago Factura No. " & numFactura & "')"
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
            Me.btnImprimir.Enabled = False
            Me.btnProcesar.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            _error_ = True
            MSJ = True
        End Try
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaPago.ValueChanged
        SetearFechas()
    End Sub

    Private Sub SetearFechas()
        Dim Fecha As Date = Me.dtpFechaPago.Value
        If Me.dtpFechaPago.Value.Day <= 15 Then
            Me.dtpFechaPago.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Me.dtpFechaPago.Value.Day > 15 And Me.dtpFechaPago.Value.Day <= Date.DaysInMonth(Me.dtpFechaPago.Value.Year, Me.dtpFechaPago.Value.Month) Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.dtpFechaPago.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.dtpFechaPago.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.dtpFechaPago.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
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
            TipMovInvFact = ParamBodegas.Rows(0).Item("TIPO_FACTURA")
            TipMovInvCCF = ParamBodegas.Rows(0).Item("TIPO_CCF")
            TipoSolicitud = ParamBodegas.Rows(0).Item("TIPO_SOLICITUD")
            SoloSocios = jClass.obtenerEscalar("SELECT SOLO_SOCIOS FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & TipoSolicitud)
            If Me.cmbTipDoc.SelectedValue = 1 Then
                TipMovInv = TipMovInvFact
            ElseIf Me.cmbTipDoc.SelectedValue = 2 Then
                TipMovInv = TipMovInvCCF
            End If
        End If
    End Sub

    'Private Sub CheckDisponible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDisponible.CheckedChanged
    '    If Not Me.CheckDisponible.Checked Then
    '        Me.lblDispSocio.Text = "No Verificar"
    '    Else
    '        DisponibleSocio = FPro.DisponibleSocio(Compañia, Me.txtCliente.Text, Val(Me.lblCodBuxis.Text))
    '        Me.lblDispSocio.Text = DisponibleSocio.ToString("0.00")
    '    End If
    'End Sub

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
                Me.btnImprimir.PerformClick()
            Case Keys.F6
                'Add the code for the function key F9 here.
                Me.btnBuscarProducto.PerformClick()
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
                If Me.cmbCONDICION_PAGO.SelectedIndex = 0 And Me.cmbCtasBanco.Items.Count > 3 Then
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
        If Me.txtMotivoBloqueo.Visible Then
            sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS_IUD]" & vbCrLf
            sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            sql &= ",@CODIGO_EMPLEADO = " & Me.txtCliente.Text & vbCrLf
            sql &= ",@SOLICITUD       = " & Me.TipoSolicitud & vbCrLf
            sql &= ",@LIMITE_APROBADO = " & Val(Me.lblDispSocio.Text) - Val(Me.txtTotFact.Text) & vbCrLf
            sql &= ",@MOTIVO          = '" & Me.txtMotivoBloqueo.Text & "'" & vbCrLf
            sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            sql &= ",@MODIFICADO      = 1" & vbCrLf
            sql &= ",@IUD             = 'I'" & vbCrLf
            sqlCmd.CommandText = sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        Else
            sql = "UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
            sql &= "   SET [MONTO_MAXIMO] = [MONTO_MAXIMO] - " & Me.txtTotFact.Text & vbCrLf
            sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND CODIGO_EMPLEADO = " & codemp & vbCrLf
            sql &= "   AND SOLICITUD = " & TipoSolicitud & vbCrLf
            sql &= "   AND EXCEDER_LIMITE = 0" & vbCrLf
            sqlCmd.CommandText = sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        End If
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

    'TODO Proceso de Facturas
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If Me.dgvCuentasEquivalentes.Rows.Count > 0 Then
            If Not FactCreada Then
                crearFactura_OVEncabezado(Compañia, _
                                          Me.cmbBODEGA.SelectedValue, _
                                          Me.dpFECHA_CONTABLE.Value, _
                                          Me.cmbTipDoc.SelectedValue, _
                                          Me.txtNoFact.Text, _
                                          Me.cmbFormaPago.SelectedValue, _
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
                                          Me.dtpFechaPago.Value, _
                                          Val(Me.txtDescAGUI.Text), _
                                          Val(Me.txtDescBONI.Text), _
                                          Me.cmbPeriodoPago.SelectedValue, _
                                          Me.txtNoRemesa.Text, _
                                          Me.cmbBancos.SelectedValue, _
                                          Me.cmbCtasBanco.SelectedValue)
            End If

            If Not _error_ Then
                For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
                    '
                    If row.Cells("linea").Value = 0 Then
                        Dim ExistenciaProducto As Double = validaExistencias(Val(row.Cells(0).Value), Me.cmbBODEGA.SelectedValue, Val(row.Cells(3).Value), Me.dpFECHA_CONTABLE.Value)
                        '
                        GrabaDetalleFactura(Compañia, Me.cmbBODEGA.SelectedValue, row.Cells(0).Value, row.Cells(1).Value, Val(Me.txtNoFact.Text), Me.dpFECHA_CONTABLE.Value, row.Cells(6).Value, row.Cells(3).Value, row.Cells(13).Value, row.Cells(14).Value, Val(row.Cells(4).Value), row.Cells(5).Value, grupoProd, subgrupoProd, Me.cmbTipDoc.SelectedValue, Me.txtNoFact.Text, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), _
                                            Me.chkImpConcepto.Checked, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.dtpFechaPago.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Val(Me.txtTotFact.Text), Val(Me.txtIVA.Text), _
                                            Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, row.Cells(12).Value, row.Cells(11).Value, row.Cells("apcesc").Value)
                        If intCodDescuento > 0 And row.Cells("descuento").Value > 0 Then
                            prRegistroAutorizacion(intCodDescuento, 2, Val(Me.txtNoFact.Text), Numero_OV, row.Cells("linea").Value)
                        End If
                    End If
                Next
                Me.generaGrid()
                cargaFacturaDetalle(Me.txtNoFact.Text, Me.cmbTipDoc.SelectedValue, Compañia, Me.cmbBODEGA.SelectedValue)
                If Not Me.chkCliExt.Checked And Me.CheckDisponible.Checked Then
                    jClass.ejecutarComandoSql(New SqlCommand("UPDATE COOPERATIVA_CATALOGO_SOCIOS SET MONTO_MAXIMO = 0 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCliente.Text))
                End If
                MessageBox.Show("La Factura ha sido Procesada con exito" & vbCrLf & vbCrLf & "Los Inventarios han sido afectados", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnImprimir.Enabled = True
                Me.btnProcesar.Enabled = False
            Else
                MsgBox("Hubieron errores durante el procesamiento" & vbCrLf & "- No se generó el encabezado de la factura." & vbCrLf & vbCrLf & "Por favor vuelva a intentarlo", MsgBoxStyle.Information, "Error Procesar")
            End If
        Else
            MessageBox.Show("Debe ingresar los datos de la Factura", "ASTAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub elimAutAguiboni()
        If Val(Me.txtDescAGUI.Text) > 0 Then
            jClass.ejecutarComandoSql(New SqlCommand("DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.txtCliente.Text & " AND CUENTA_CONTABLE = 'A'"))
        End If
        If Val(Me.txtDescBONI.Text) > 0 Then
            jClass.ejecutarComandoSql(New SqlCommand("DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.txtCliente.Text & " AND CUENTA_CONTABLE = 'B'"))
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ObtieneNumeroFactura()
    End Sub

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

    Private Sub BuscaProductos()
        Try
            sql = "EXECUTE sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA " & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ",@BODEGA   = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            sql &= ",@BANDERA  = 4" & vbCrLf
            Comando_ = New SqlCommand(sql)
            Table1 = jClass.obtenerDatos(Comando_)
            Me.dgvProductos.Columns.Clear()
            Me.dgvProductos.DataSource = Table1
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
        Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNombreB.Text = "" Then
            Me.dgvProductos.DataSource = Table1
        Else
            'Se incluyen los brackets por si el nombre de encabezado esta compuesto por mas de una palabra separada por espacios
            CodicionFiltro = "[" & dgvProductos.Columns(1).Name & "]" & " like '" & TxtNombreB.Text & "%'"
            rows = Table1.Select(CodicionFiltro) 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            ' return filtered dt            
            Me.dgvProductos.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
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

    Private Function FechaCorte() As Date
        Dim TableFechaFact As DataTable
        Dim FechaFact As Date
        TableFechaFact = jClass.obtenerDatos(New SqlCommand("SELECT [FECHA_FACTURACION] FROM [FACTURACION_FECHAS_CIERRE] WHERE [FECHA_REAL] = '" & Format(multi.FechaActual_Servidor(), "dd/MM/yyyy") & "' AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND COMPAÑIA = " & Compañia))
        If TableFechaFact.Rows.Count > 0 Then
            FechaFact = CDate(Format(TableFechaFact.Rows(0).Item(0), "dd/MM/yyyy"))
            Me.dpFECHA_CONTABLE.Enabled = False
        Else
            FechaFact = Now.Date
        End If
        Return FechaFact
    End Function

    Private Sub txtNumCuotas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumCuotas.LostFocus
        If Me.txtNumCuotas.Text = Nothing Then
            Me.txtNumCuotas.Text = "0"
        End If
    End Sub

    Private Sub txtCodFiador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodFiador.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnFiadores.Focus()
        End If
        jClass.soloNumeros(e)
    End Sub

    Private Sub txtCodFiador_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodFiador.LostFocus
        Dim tblDatos As New DataTable
        If Val(Me.txtCodFiador.Text) > 0 Then
            tblDatos = Fiadores(6, 0, 0, Val(Me.txtCodFiador.Text))
            If tblDatos.Rows.Count > 0 Then
                Me.txtNombreFiador.Text = tblDatos.Rows(0).Item(0)
                Me.txtDeudaFiador.Text = Format(tblDatos.Rows(0).Item(1), "#,##0.00")
            Else
                MsgBox("No existen datos para el codigo: " & Me.txtCodFiador.Text, MsgBoxStyle.Information, Me.Text)
            End If
        End If
    End Sub

    Private Sub btnFiadores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnFiadores.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnFiadores.PerformClick()
        End If
    End Sub

    Private Function Fiadores(ByVal Bandera As Integer, ByVal codEmp As Integer, ByVal numSol As Integer, ByVal codigoFiador As Integer) As DataTable
        Dim tblResultado As New DataTable
        Sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]" & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO = " & codEmp & vbCrLf
        Sql &= ",@NUMERO_SOLICITUD = " & numSol & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO_FIADOR = " & codigoFiador & vbCrLf
        Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        Sql &= ",@BANDERA = " & Bandera & vbCrLf
        tblResultado = jclass.obtenerDatos(New SqlCommand(Sql), 1)
        Return tblResultado
    End Function

    Private Sub btnFiadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiadores.Click
        Dim a As Integer = 0
        For i As Integer = 0 To Me.dgvFiadores.Rows.Count - 1
            If Me.txtCodFiador.Text = Me.dgvFiadores.Rows(i).Cells(0).Value Then
                a = i + 1
            End If
        Next
        If a > 0 Then
            Me.dgvFiadores.Rows.RemoveAt(a - 1)
            If Val(Me.txtNoFact.Tag) > 0 Then
                Fiadores(3, Me.txtCliente.Text, Val(Me.txtNoFact.Tag), Me.dgvFiadores.Rows(a - 1).Cells(0).Value)
            End If
        End If
        Me.dgvFiadores.Rows.Add(Me.txtCodFiador.Text, Me.txtNombreFiador.Text, Me.txtDeudaFiador.Text, "X")
        If Val(Me.txtNoFact.Tag) > 0 Then
            Fiadores(2, Me.txtCliente.Text, Val(Me.txtNoFact.Tag), Val(Me.txtCodFiador.Text))
        End If
        Me.txtCodFiador.Clear()
        Me.txtNombreFiador.Clear()
        Me.txtDeudaFiador.Text = "0.00"
        Me.txtCodFiador.Focus()
    End Sub

    Private Sub dgvFiadores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFiadores.CellContentClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 3 Then
                Fiadores(3, Me.txtCliente.Text, Val(Me.txtNoFact.Tag), Me.dgvFiadores.Rows(e.RowIndex).Cells(0).Value)
                Me.dgvFiadores.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub llenar_dgvFiadores(ByVal tblFiadores As DataTable)
        While Me.dgvFiadores.Rows.Count > 0
            Me.dgvFiadores.Rows.RemoveAt(0)
        End While
        For Each row As DataRow In tblFiadores.Rows
            Me.dgvFiadores.Rows.Add(row(0), row(1), row(2), "X")
        Next
    End Sub

    'Req.# 147
    Private Sub txtDescAGUI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescAGUI.LostFocus
        Dim DescAguiTot As Double = 0
        Dim DescAguiAut As Double = 0
        If Val(Me.txtDescAGUI.Text) > 0 Then
            sql = "SELECT ISNULL(SUM(D.CAPITAL), 0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D " & vbCrLf
            sql &= "INNER JOIN COOPERATIVA_SOLICITUDES S ON D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO " & vbCrLf
            sql &= "WHERE S.CODIGO_BUXIS = " & Me.txtCliente.Text & " AND CAPITAL_D = 0 AND CONVERT(DATE, FECHA_PAGO) = CONVERT(DATE, '12/12/" & (Now.Year + IIf(Now.Month > 11, 1, 0)).ToString() & "', 103)"
            DescAguiTot = jClass.obtenerEscalar(sql)
            If DescAguiTot > 0 Then
                DescAguiAut = jClass.obtenerEscalar("SELECT ISNULL(SUM(INTERES_DEUDA), 0.00) FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.txtCliente.Text & " AND CUENTA_CONTABLE = 'A'")
                If Val(Me.txtDescAGUI.Text) > DescAguiAut Then
                    MsgBox(Me.txtNombreCliente.Text & vbCrLf & "TIENE CUOTAS PROGRAMADAS PARA AGUINALDO-" & (Now.Year + IIf(Now.Month > 11, 1, 0)).ToString() & vbCrLf & "POR UN TOTAL DE $ " & Format(DescAguiTot, "0.00") & vbCrLf & vbCrLf & "LIMITE AUTORIZADO $" & Format(DescAguiAut, "0.00"), MsgBoxStyle.Information, "AGUINALDO")
                    Me.txtDescAGUI.Text = Format(DescAguiAut, "0.00")
                End If
            End If
        End If
    End Sub

    'Req.# 147
    Private Sub txtDescBONI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescBONI.LostFocus
        Dim DescBoniTot As Double = 0
        Dim DescBoniAut As Double = 0
        If Val(Me.txtDescBONI.Text) > 0 Then
            sql = "SELECT ISNULL(SUM(D.CAPITAL), 0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D " & vbCrLf
            sql &= "INNER JOIN COOPERATIVA_SOLICITUDES S ON D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO " & vbCrLf
            sql &= "WHERE S.CODIGO_BUXIS = " & Me.txtCliente.Text & " AND CAPITAL_D = 0 AND CONVERT(DATE, FECHA_PAGO) = CONVERT(DATE, '12/06/" & (Now.Year + IIf(Now.Month > 5, 1, 0)).ToString() & "', 103)"
            DescBoniTot = jClass.obtenerEscalar(sql)
            If DescBoniTot > 0 Then
                DescBoniAut = jClass.obtenerEscalar("SELECT ISNULL(SUM(INTERES_DEUDA), 0.00) FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.txtCliente.Text & " AND CUENTA_CONTABLE = 'B'")
                If Val(Me.txtDescBONI.Text) > DescBoniAut Then
                    MsgBox(Me.txtNombreCliente.Text & vbCrLf & "TIENE CUOTAS PROGRAMADAS PARA BONIFICACIÓN-" & (Now.Year + IIf(Now.Month > 5, 1, 0)).ToString() & vbCrLf & "POR UN TOTAL DE $ " & Format(DescBoniTot, "0.00") & vbCrLf & vbCrLf & "LIMITE AUTORIZADO $" & Format(DescBoniAut, "0.00"), MsgBoxStyle.Information, "BONIFICACIÓN")
                    Me.txtDescBONI.Text = Format(DescBoniAut, "0.00")
                End If
            End If
        End If
    End Sub

    'Req.#147
    Private Sub disponibilidad()
        Dim tblDisponible As DataTable
        Dim DeudaFiadores As Integer
        sql = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] " & vbCrLf
        sql &= "@COMPAÑIA = " & Compañia & vbCrLf
        sql &= ", @CODIGO_EMPLEADO = " & Me.txtCliente.Text & vbCrLf
        sql &= ", @BANDERA = 7" & vbCrLf
        DeudaFiadores = jClass.obtenerEscalar(sql)
        tblDisponible = jClass.obtenerDatos(New SqlCommand("SELECT ([AHORRO ORDINARIO]) - [Monto por Saldar] AS SINFIADOR, ([AHORRO ORDINARIO] * 2) - [Monto por Saldar] AS CONFIADOR FROM VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO WHERE CODIGO_EMPLEADO = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Compañia))
        If tblDisponible.Rows.Count > 0 Then
            Me.txtSinFiador.Text = Format(Val(tblDisponible.Rows(0)("SINFIADOR")) - DeudaFiadores, "0.00")
            Me.txtConFiador.Text = Format(Val(tblDisponible.Rows(0)("CONFIADOR")) - DeudaFiadores, "0.00")
        Else
            Me.txtConFiador.Text = "0.00"
            Me.txtSinFiador.Text = "0.00"
        End If
    End Sub

    Private Sub Label24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label24.Click

    End Sub
End Class

