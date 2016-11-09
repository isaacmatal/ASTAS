Imports System.Data.SqlClient

Public Class Facturacion_Bodegas_Despensa
    'Constructor
    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Dim PedidoCreado As Boolean = False
    Dim UMIndex As Integer
    Dim myTipDoc As Integer
    Dim totRegFact As Integer
    Dim DisponibleSocio As Double
    Dim numeroOV As Integer
    Dim codClie As Integer
    Dim TipClie, StatusCliente As Integer
    Dim TipContrib As Integer
    Dim CondPago As Integer
    Dim giro As String
    Dim exento, _error_ As Boolean
    Dim NRC As String
    Dim dirClie As String
    Dim grupoProducto As Integer
    Dim subgrupoProducto As Integer
    Dim tipoCosto As Integer = 1
    Dim TipMovInv, TipMovInvFact, TipMovInvCCF, TipoSolicitud As Integer
    Dim PorcIVA, PorcPercep As Double

    ' nuevas
    Dim producto_especial As Integer
    Dim productos_facturados(100, 2) As String
    Dim i As Integer
    Dim cantidad_precio_especial As Double
    Dim origen_autoconsumo As Integer = 8
    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim Table2 As DataTable
    Dim DataReader_ As SqlDataReader
    Dim maximo_descuento As Double

    Private Sub Facturacion_Bodegas_Almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        i = 0
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA_CONTABLE.Value = multi.FechaActual_Servidor()
        multi.CargaCompañia(Me.cmbCOMPAÑIA)
        multi.CargaBodegaSeguridadUsuario(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA)
        multi.CargaFormaPago(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbFormaPago)
        multi.CargaTipoDocumentoFact(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTipDoc)
        multi.CargaPeriodo(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbPeriodoPago)
        Me.cmbFormaPago.SelectedIndex = 1
        multi.CargaCondicionPago(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO)
        jClass.CargaBancos(Compañia, Me.cmbBancos)
        Me.cmbBancos.SelectedIndex = 1
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
        Me.cmbCtasBanco.SelectedIndex = 0
        multi.CargaUnidadMedida(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbUNIDAD_MEDIDA)
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        Me.cmbTipDoc.SelectedIndex = 0
        Me.dgvHistorialFacturas.AllowUserToAddRows = False
        Me.dgvHistorialFacturas.ReadOnly = True
        Me.dgvDetallePedido.AllowUserToAddRows = False
        Me.dgvDetallePedido.ReadOnly = True
        Me.chkPre_normal.Visible = False
        SetearFechas()
        Iniciando = False
        generaGrid()
        cargaPedidosPendientes(0)
        myTipDoc = 0
        cargaSeriesFacturas()
        numeroOV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
        Me.txtNoOrden.Text = numeroOV
        obtieneCentroCosto()
        ParamBodegas()
        generaGrid()
        PorcIVA = FPro.DevuelveConstante(Compañia, 1)
        PorcPercep = FPro.DevuelveConstante(Compañia, 2)
        For c As Integer = 0 To Me.dgvSeriesFacturas.Columns.Count - 1
            Me.dgvSeriesFacturas.Columns(c).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Private Sub obtieneCentroCosto()
        Dim sqlCmd As New SqlCommand
        If Not Iniciando Then
            sql = " Execute dbo.sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO_BODEGA "
            sql &= Me.cmbCOMPAÑIA.SelectedValue
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
            sql = "SELECT ISNULL(MAX([ORDEN_VENTA]),0) + 1 FROM dbo.FACTURACION_FACTURAS_ENCABEZADO WHERE COMPAÑIA = " & cia
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

    Private Function actualizaNumDoc(ByVal cia As Integer, ByVal Docto As String) As Integer
        Dim numOV As Integer
        Try
            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            sql &= cia
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
        Socios.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        Dim Clientes As New Contabilidad_BusquedaClientes
        Clientes.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
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
        Me.limpiaCampos(0)
        numeroOV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
        Me.txtNoOrden.Text = numeroOV
        obtieneCentroCosto()
        cargaPedidosPendientes(0)
        myTipDoc = 0
        cargaSeriesFacturas()
        ParamBodegas()
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
                CheckDisponible.Checked = True
                CheckDisponible.Enabled = True
                sql = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
                sql &= Me.cmbCOMPAÑIA.SelectedValue
                sql &= ", '" & numSocio & "'"
                sql &= ", " & codEmp
                sql &= ", 13" 'BANDERA
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.lblCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtTelCliente.Text = Table.Rows(0).Item("TELEFONO")
                    Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                    StatusCliente = Table.Rows(0).Item("ESTATUS")
                    If CheckDisponible.Checked Then
                        DisponibleSocio = FPro.Determinardisponible(numSocio, codEmp)
                        Me.lblDispSocio.Text = DisponibleSocio.ToString("0.00")
                        sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & numSocio & "'"
                        Bloqueado = jClass.obtenerEscalar(sql)
                        If Bloqueado Then
                            CheckDisponible.Enabled = False
                        End If
                    Else
                        Me.lblDispSocio.Text = "No Verificar"
                    End If
                    Origen = Table.Rows(0).Item("ORIGEN")
                    If Origen = origen_autoconsumo Then
                        Me.txtdescuento.ReadOnly = True
                    Else
                        Me.txtdescuento.ReadOnly = False
                    End If
                    Me.LimpiaCamposDetallePedido()
                    codClie = 0
                    giro = "Socio ASTAS"
                    NRC = ""
                    exento = 0
                    TipClie = 1
                    TipContrib = 0
                    dirClie = ""
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    cargaHistorialFacturas(Me.txtCliente.Text, 2)
                    If StatusCliente <> 2 Then
                        Me.CheckDisponible.Checked = False
                    End If
                    Me.txtProducto.Focus()
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

    Private Sub datosCliente(ByVal numCliente As String, ByVal NIT As String)
        Dim sqlCmd As New SqlCommand
        If numCliente.Length > 0 Then
            Try
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Me.cmbCOMPAÑIA.SelectedValue
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
                    Me.LimpiaCamposDetallePedido()
                    codClie = Me.txtCliente.Text
                    giro = Table.Rows(0).Item("Giro")
                    NRC = Table.Rows(0).Item("NRC")
                    exento = Table.Rows(0).Item("Exento")
                    TipClie = Table.Rows(0).Item("Tipo Cliente")
                    TipContrib = Table.Rows(0).Item("Tipo Contribuyente")
                    dirClie = Table.Rows(0).Item("Dirección")
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    cargaHistorialFacturas(Me.txtCliente.Text, 1)
                    Me.txtProducto.Focus()
                Else
                    DisponibleSocio = 0
                    origen = 0
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
        End Try
        End If
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim productos As New Inventario_BusquedaProductosBodega("", 1)
        'Dim precioProd As Double
        productos.Bodega_Value = Me.cmbBODEGA.SelectedValue
        productos.cmbBODEGA.Enabled = False
        Numero = ""
        Producto = ""
        Descripcion_Producto = ""
        productos.ShowDialog()
        If Producto <> Nothing Then
            Try
                Me.LimpiaCamposDetallePedido()
                grupoProducto = 0
                subgrupoProducto = 0
                Me.txtProducto.Text = Producto
                Numero = ""
                Producto = ""
                Me.chkPre_normal.Checked = True
                obtieneDatosProducto(Me.txtProducto.Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 9")
            End Try
        End If
    End Sub

    'Limpia los campos del Formulario completo
    Private Sub limpiaCampos(ByVal opcion As Integer)
        Me.LimpiaCamposDetallePedido()
        Me.txtCliente.Clear()
        Me.lblCodBuxis.Text = ""
        Me.txtNombreCliente.Clear()
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.lblDispSocio.Text = "0.00"
        Me.cargaHistorialFacturas("00000", 2)
        Me.txtNomFact.Clear()
        Me.txtNITCliente.Clear()
        Me.txtDUICliente.Clear()
        Me.txtTelCliente.Clear()
        Me.txtDescAGUI.Clear()
        Me.txtDescBONI.Clear()
        Me.TextBox30.Clear()
        Me.txtObserv.Clear()
        Me.txtNoRemesa.Clear()
        Me.txtNumCuotas.Text = "1"
        Me.dgvHistorialFacturas.Columns.Clear()
        Me.btnGuardarDetalle.Enabled = True
        Me.btnEliminaDetalle.Enabled = True
        Me.btnGuardaPedidoEncabezado.Enabled = True
        Me.chkCliExt.Enabled = True
        Me.Label21.Visible = False
        numeroOV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
        Me.txtNoOrden.Text = numeroOV
        generaGrid()
        Me.txtCliente.Focus()
    End Sub

    Private Sub obtieneDatosProducto(ByVal codProducto As String)
        Dim sqlCmdProd As New SqlCommand
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
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
            If Origen <> origen_autoconsumo Then
                Me.txtPrecio.Text = jClass.obtenerEscalar("SELECT DBO.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ",'" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')") 'Table.Rows(0).Item("PRECIO_UNITARIO").ToString
            Else
                Me.txtPrecio.Text = jClass.obtenerEscalar("select [dbo].[INVENTARIOS_CALCULAR_COSTO_PRODUCTO] (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Me.dpFECHA_CONTABLE.Value.ToShortDateString & "')")
            End If
            grupoProducto = Table.Rows(0).Item("GRUPO")
            subgrupoProducto = Table.Rows(0).Item("SUBGRUPO")
            tipoCosto = Table.Rows(0).Item("TIPO_COSTO")
            Me.txtCantidad.Focus()
            Dim sql2 As String = ""
            sql2 = "SELECT PORCENTAJE_DESCUENTO_MAXIMO FROM dbo.INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS WHERE COMPAÑIA = " & Compañia & " AND GRUPO= " & Me.grupoProducto & " AND SUBGRUPO= " & Me.subgrupoProducto
            maximo_descuento = jClass.obtenerEscalar(sql2)
            Me.txtdescuento.Text = "0.0" 'maximo_descuento
        Else
            If Table.Rows.Count > 1 Then
                MsgBox("Existen mas de dos items para la bodega " & Me.cmbBODEGA.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Else
                'MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
                Me.txtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub LimpiaCamposDetallePedido()
        Me.txtDescripcion.Clear()
        Me.txtPrecio.Clear()
        Me.txtCantidad.Clear()
        Me.txtProducto.Clear()
        Me.txtdescuento.Clear()
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Dim Tecla As String = Convert.ToChar(Keys.Enter)
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
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Dim subtot, valdesc, totProd, ExistenciaProducto, CostoU, CostoT, CantidadFacturada As Double
        Dim TipMovto, Movto As Integer
        Dim producto_facturado As Integer = 0
        Dim ProductoDuplicado As Boolean
        If Not validaCamposVacios() Then
            Return
        End If
        If Val(Me.txtProducto.Text) <= 0 Then
            MsgBox("Elija un Producto para proceder.", MsgBoxStyle.Critical, "Producto inválido")
            Me.txtProducto.Focus()
            Return
        End If
        If Val(Me.txtCantidad.Text) = 0 Then
            MsgBox("La Cantidad del producto debe ser diferente de cero.", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If
        If Val(Me.txtdescuento.Text) > maximo_descuento Then
            MsgBox("El descuento ingresado es mayor al porcentaje de descuento maximo asignado que es de " & Me.maximo_descuento & "%", MsgBoxStyle.Critical, "Descuento incorrecto")
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
        For Each row As DataGridViewRow In Me.dgvDetallePedido.Rows
            If Val(row.Cells("PRODUCTO").Value) = Producto Then
                CantidadFacturada += Val(row.Cells("CANTIDAD").Value)
                TipMovto = row.Cells("TIPO_MOVIMIENTO").Value
                Movto = row.Cells("MOVIMIENTO").Value
                totRegFact = row.Cells("LINEA").Value
                ProductoDuplicado = True
            End If
        Next
        CantidadFacturada += Val(Me.txtCantidad.Text)
        ExistenciaProducto = ExistenciasActuales(Val(producto_facturado), Me.cmbBODEGA.SelectedValue, CantidadFacturada, Me.dpFECHA_CONTABLE.Value)
        If ExistenciaProducto < CantidadFacturada Then
            MsgBox("la existencia del producto es de " & ExistenciaProducto & " " & Me.cmbUNIDAD_MEDIDA.Text & vbCrLf & "No se puede procesar producto...", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Clear()
            Me.txtCantidad.Focus()
            Return
        End If
        CostoU = obtieneCostoProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtProducto.Text, Me.dpFECHA_CONTABLE.Value, tipoCosto)
        CostoT = CostoU * Val(CantidadFacturada) * (1 - (Val(Me.txtdescuento.Text) / 100))
        subtot = Val(CantidadFacturada) * Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        Me.txtPrecio.Text = Val(Me.txtPrecio.Text) * (1 - (Val(Me.txtdescuento.Text) / 100))
        valdesc = 0 'subtot * ((Val(Me.txtDesc.Text)) / 100)
        totProd = subtot - valdesc
        If Val(Me.lblDispSocio.Text) - totProd - Val(Me.txtTotFact.Text) < 0 And Not Me.chkCliExt.Checked And (Me.cmbFormaPago.Text.ToUpper = "CREDITO" Or Me.cmbFormaPago.Text.ToUpper = "CRÉDITO") Then
            If Me.CheckDisponible.Checked Then
                MsgBox("Disponible insuficiente para esta transaccion", MsgBoxStyle.Critical, "Verificar Disponible")
                Return
            End If
        End If
        If ProductoDuplicado Then
            GuardaEliminaMovimientoInventarioDetalle(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "0", Producto, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, TipMovto, Movto, "DD", tipoCosto)
            GuardaEliminaRegistroFacturaDetalleOV(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Producto, "", 0, 0, 0, 0, 0, 0, 0, True, "D")
        End If
        Me.txtSUBTOTAL.Text = (Val(Me.txtSUBTOTAL.Text) + IIf(Me.cmbTipDoc.SelectedValue = 2, (subtot / (1 + (PorcIVA / 100))), subtot)) '.ToString("0.00")
        Me.txtIVA.Text = (Val(Me.txtIVA.Text) + IIf(Me.cmbTipDoc.SelectedValue = 2, (subtot / (1 + (PorcIVA / 100))) * (PorcIVA / 100), 0)) '.ToString("0.00")
        Me.txtTotFact.Text = (Val(Me.txtSUBTOTAL.Text) + Val(Me.txtIVA.Text))
        If Not PedidoCreado Then
            crearFactura_OVEncabezado(Me.cmbCOMPAÑIA.SelectedValue, _
                                    Me.cmbBODEGA.SelectedValue, _
                                    Me.dpFECHA_CONTABLE.Value, _
                                    Me.cmbTipDoc.SelectedValue, _
                                    "0", _
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
                                    Me.DateTimePicker1.Value, _
                                    Val(Me.txtDescAGUI.Text), _
                                    Val(Me.txtDescBONI.Text), _
                                    Me.cmbPeriodoPago.SelectedValue, _
                                    Me.txtNoRemesa.Text, _
                                    Me.cmbBancos.SelectedValue, _
                                    Me.cmbCtasBanco.SelectedValue)
        End If
        Me.cmbBODEGA.Enabled = False
        GrabaDetallePedido(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, producto_facturado, Me.txtDescripcion.Text, 0, Me.dpFECHA_CONTABLE.Value, Me.cmbUNIDAD_MEDIDA.SelectedValue, CantidadFacturada, CostoU, CostoT, Val(Me.txtPrecio.Text), totProd, grupoProducto, subgrupoProducto, Me.cmbTipDoc.SelectedValue, "0", Me.txtNomFact.Text, Val(Me.txtIVA.Text), _
                            Me.chkImpConcepto.Checked, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Me.txtNumCuotas.Text, Me.DateTimePicker1.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Val(Me.txtTotFact.Text), Val(Me.txtIVA.Text), Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue)
        cargaPedidoDetalle(Me.txtNoOrden.Text, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
        If Me.chkPre_normal.Checked = False Then
            productos_facturados(i, 0) = producto_facturado ' producto
            productos_facturados(i, 1) = Me.producto_especial ' codigo del IDPROD_PRE_ESP
            Me.Actualizar_inventario_precio_especial("", "", "", "", productos_facturados(i, 1), CantidadFacturada, "D")
            i = i + 1
        End If
        totalizaFactura()
        LimpiaCamposDetallePedido()
        Me.txtProducto.Focus()
        Me.chkPre_normal.Checked = True
    End Sub

    Private Sub totalizaFactura()
        Dim Subtotal, TotIVA, totFactura As Double
        For Each row As DataGridViewRow In Me.dgvDetallePedido.Rows
            Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
        Next
        If Me.cmbTipDoc.SelectedValue = 2 Then
            If exento Then
                TotIVA = 0
            Else
                TotIVA = (Subtotal * ((PorcIVA / 100)))
            End If
        End If
        totFactura = Subtotal + TotIVA
        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
        Me.txtIVA.Text = TotIVA.ToString("###0.00")
        Me.txtTotFact.Text = totFactura.ToString("###0.00")
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
                sql = "SELECT NOMBRE, NIT FROM dbo.CONTABILIDAD_CATALOGO_CLIENTES WHERE CLIENTE = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Me.cmbCOMPAÑIA.SelectedValue
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub btnEliminaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaDetalle.Click
        Dim CurRow As DataGridViewRow
        CurRow = Me.dgvDetallePedido.CurrentRow
        If MsgBox("Está seguro de eliminar este item: " & CurRow.Cells("PRODUCTO").Value & " " & CurRow.Cells(1).Value, MsgBoxStyle.YesNo, "Eliminar Item") = MsgBoxResult.No Then
            Return
        End If
        GuardaEliminaMovimientoInventarioDetalle(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "0", CurRow.Cells("PRODUCTO").Value, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, CurRow.Cells("TIPO_MOVIMIENTO").Value, CurRow.Cells("MOVIMIENTO").Value, "DD", tipoCosto)
        totRegFact = CurRow.Cells("LINEA").Value
        GuardaEliminaRegistroFacturaDetalleOV(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, "", 0, 0, 0, 0, 0, 0, 0, True, "D")

        '***
        If Me.era_producto_especial(CurRow.Cells("PRODUCTO").Value) Then
            Me.Actualizar_inventario_precio_especial(Compañia, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, CurRow.Cells("PRECIO_UNITARIO").Value, obtener_IDPROD_PRE_ESP(CurRow.Cells("PRODUCTO").Value), CurRow.Cells("CANTIDAD").Value, "A")
            Me.Se_encuentra_producto_especial(CurRow.Cells("PRODUCTO").Value)
        End If

        '***
        cargaPedidoDetalle(Me.txtNoOrden.Text, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
        totalizaFactura()
        Me.chkPre_normal.Checked = True
    End Sub

    Private Function ExistenciasActuales(ByVal Producto As Integer, ByVal Bodega As Integer, ByVal Cantidad As Double, ByVal fechafact As DateTime) As Double
        Dim ExistenciaDisponible As Double
        sql = " Execute dbo.sp_INVENTARIOS_VERIFICAR_EXISTENCIAS "
        sql &= Cantidad
        sql &= ", " & Producto
        sql &= ", " & Bodega
        sql &= ", " & Me.cmbCOMPAÑIA.SelectedValue
        sql &= ", '" & Format(fechafact, "Short Date") & "'"
        sql &= ", 1"
        ExistenciaDisponible = jClass.obtenerEscalar(sql)
        Return ExistenciaDisponible
    End Function

    'Carga Historial de Facturas
    Private Sub cargaHistorialFacturas(ByVal cliente As String, ByVal flag As Integer)
        Dim sqlCmd As New SqlCommand
        Dim TableX As DataTable
        If cliente = Nothing Then
            cliente = "0"
        End If
        Try
            sql = " SELECT F.FECHA_FACTURA AS FECHA,T.DESCRIPCION_TIPO_DOCUMENTO AS TIPO,F.NUMERO_FACTURA AS FACTURA,F.TOTAL_FACTURA AS TOTAL,F.CUOTAS,F.PERIODO_PAGO AS PERIODO,F.DESCUENTO_AGUINALDO AS AGUINALDO, F.DESCUENTO_BONIFICACION AS BONIFICACION,F.FACTURA_IMPRESA AS IMPRESA,F.ORDEN_VENTA FROM dbo.FACTURACION_GENERADA_ENCABEZADO F, dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO T "
            sql &= "WHERE F.TIPO_DOCUMENTO = T.TIPO_DOCUMENTO"
            If flag = 1 Then
                sql &= " AND F.CLIENTE = " & cliente
            Else
                sql &= " AND F.CODIGO_EMPLEADO_AS = '" & cliente & "'"
            End If
            sqlCmd.CommandText = sql
            TableX = jClass.obtenerDatos(sqlCmd)
            Me.dgvHistorialFacturas.Columns.Clear()
            Me.dgvHistorialFacturas.DataSource = TableX
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 1")
        End Try
    End Sub

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
        GuardaEliminaOrdenVentaEncabezado(CIA, Bodega, codClie, TipDoc, "0", NomFact, Concepto, FormaPago, CondPago, TipClie, TipContrib, exento, NRC, giro, codBuxis, CodCliente, dirClie, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "I")
    End Sub

    Private Sub GrabaDetallePedido(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact As Integer, ByVal FechaMov As DateTime, _
                                    ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                    ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal IVA As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                    ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Total_Factura As Double, ByVal totIVA As Double, ByVal Banco As Integer, ByVal Numero_Cta As String)
        _error_ = False
        GuardaEliminaRegistroFacturaDetalleOV(CIA, Bodega, codProd, descProd, UM, cant, CostoU, CostoT, PrecProd, Grupo, SubGrupo, exento, "I")
        If Not _error_ Then
            _error_ = False
            GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, TipDoc, numdoc, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, 0, numeroOV), "I", tipoCosto)
            If PedidoCreado And Not _error_ Then
                GuardaEliminaOrdenVentaEncabezado(CIA, Bodega, codClie, TipDoc, "0", NomFact, Concepto, FormaPago, Me.cmbCONDICION_PAGO.SelectedValue, TipClie, TipContrib, exento, NRC, giro, codBuxis, CodCliente, dirClie, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "U")
            End If
        End If
    End Sub

    Private Function obtieneCostoProducto(ByVal CIA As Integer, ByVal bodega As Integer, ByVal producto As Integer, ByVal fecha As DateTime, ByVal TipoCosto As Integer) As Double
        Dim sqlCmd As New SqlCommand
        If TipoCosto = 2 Then
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
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 2")
        End Try
    End Function

    Private Sub cargaPedidoDetalle(ByVal numPedido As String, ByVal CIA As Integer, ByVal Bodega As Integer)
        Dim sqlCmd As New SqlCommand
        Dim descAguin, descBoni As Double
        Me.TabControl1.SelectTab(0)
        If Not Iniciando Then
            Try
                sql = "SELECT FFE.ORDEN_VENTA, FFE.CODIGO_EMPLEADO_AS, FFE.CODIGO_EMPLEADO, FFE.FORMA_PAGO, FFE.TIPO_DOCUMENTO, FFE.NUMERO_FACTURA, FFE.NUMERO_FACTURA_FECHA, FFE.NOMBRE_FACTURA, FFE.BODEGA, FFE.PERIODO_PAGO, FFE.CUOTAS, FFE.DESCONTAR_CUOTAS_DESDE, FFE.DESCUENTO_AGUINALDO, FFE.DESCUENTO_BONIFICACION, FFE.NUMERO_REMESA, FFE.OBSERVACIONES, FFE.CLIENTE, FFE.NIT, FFE.BANCO_REMESA, FFE.CUENTA_BANCO_REMESA FROM dbo.FACTURACION_FACTURAS_ENCABEZADO FFE"
                sql &= " WHERE FFE.COMPAÑIA = " & CIA
                sql &= " AND FFE.BODEGA = " & Bodega
                sql &= " AND FFE.ORDEN_VENTA = " & numPedido
                sqlCmd.CommandText = sql
                Table2 = jClass.obtenerDatos(sqlCmd)
                If Table2.Rows.Count > 0 Then
                    PedidoCreado = True
                    numeroOV = Table2.Rows(0).Item("ORDEN_VENTA")
                    Me.txtNoOrden.Text = numeroOV
                    Me.dpFECHA_CONTABLE.Value = Table2.Rows(0).Item("NUMERO_FACTURA_FECHA")
                    Me.DateTimePicker1.Value = Table2.Rows(0).Item("DESCONTAR_CUOTAS_DESDE")
                    Me.cmbTipDoc.SelectedValue = Table2.Rows(0).Item("TIPO_DOCUMENTO")
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
                    Me.cmbFormaPago.SelectedValue = Table2.Rows(0).Item("FORMA_PAGO")
                    Me.cmbPeriodoPago.SelectedValue = Table2.Rows(0).Item("PERIODO_PAGO")
                    Me.txtNumCuotas.Text = Table2.Rows(0).Item("CUOTAS")
                    If Table2.Rows(0).Item("FORMA_PAGO") = 1 Then
                        Me.txtNoRemesa.Text = Table2.Rows(0).Item("NUMERO_REMESA")
                        Me.cmbBancos.SelectedValue = Table2.Rows(0).Item("BANCO_REMESA")
                        Me.cmbCtasBanco.SelectedValue = Table2.Rows(0).Item("CUENTA_BANCO_REMESA")
                    End If
                    descAguin = Table2.Rows(0).Item("DESCUENTO_AGUINALDO")
                    descBoni = Table2.Rows(0).Item("DESCUENTO_BONIFICACION")
                    CondPago = Me.cmbCONDICION_PAGO.SelectedValue
                    Me.txtDescAGUI.Text = descAguin.ToString("0.00")
                    Me.txtDescBONI.Text = descBoni.ToString("0.00")
                    Me.txtObserv.Text = Table2.Rows(0).Item("OBSERVACIONES")
                    Me.btnAnular.Enabled = (Table2.Rows(0).Item("NUMERO_FACTURA") = 0)
                    Me.btnGuardarDetalle.Enabled = (Table2.Rows(0).Item("NUMERO_FACTURA") = 0)
                    Me.btnEliminaDetalle.Enabled = (Table2.Rows(0).Item("NUMERO_FACTURA") = 0)
                    Me.btnGuardaPedidoEncabezado.Enabled = (Table2.Rows(0).Item("NUMERO_FACTURA") = 0)
                    Me.Label21.Visible = Not (Table2.Rows(0).Item("NUMERO_FACTURA") = 0)
                    Me.cmbBODEGA.Enabled = False
                    Me.chkCliExt.Enabled = False
                    Me.txtNomFact.Text = Table2.Rows(0).Item("NOMBRE_FACTURA")
                    sql = "SELECT FFD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, FFD.CANTIDAD, FFD.PRECIO_UNITARIO, FFD.PRECIO_TOTAL, FFD.LINEA, FFE.CODIGO_EMPLEADO, FFE.CODIGO_EMPLEADO_AS, IMD.TIPO_MOVIMIENTO, IMD.MOVIMIENTO, FFE.PERIODO_PAGO "
                    sql &= "FROM dbo.FACTURACION_FACTURAS_ENCABEZADO FFE, dbo.FACTURACION_FACTURAS_DETALLE FFD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM "
                    sql &= "WHERE FFE.COMPAÑIA = FFD.COMPAÑIA AND FFE.BODEGA = FFD.BODEGA AND FFE.ORDEN_VENTA = FFD.ORDEN_VENTA AND FFE.COMPAÑIA = IME.COMPAÑIA AND FFE.BODEGA = IME.BODEGA AND FFE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FFD.COMPAÑIA = ICP.COMPAÑIA AND FFD.PRODUCTO = ICP.PRODUCTO AND FFD.COMPAÑIA = ICUM.COMPAÑIA AND FFD.UNIDAD_MEDIDA = ICUM.UNIDAD_MEDIDA AND FFD.PRODUCTO = IMD.PRODUCTO AND FFD.COMPAÑIA = ICP.COMPAÑIA AND FFD.PRODUCTO = ICP.PRODUCTO "
                    sql &= "AND FFE.COMPAÑIA = " & CIA
                    sql &= " AND FFE.BODEGA = " & Bodega
                    sql &= " AND FFE.ORDEN_VENTA = " & numPedido
                    sql &= " ORDER BY FFD.LINEA"
                    sqlCmd.CommandText = sql
                    Table = jClass.obtenerDatos(sqlCmd)
                    Me.dgvDetallePedido.Columns.Clear()
                    Me.dgvDetallePedido.DataSource = Table
                    Me.dgvDetallePedido.Columns(0).HeaderText = "Producto"
                    Me.dgvDetallePedido.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(0).Width = 70
                    Me.dgvDetallePedido.Columns(1).HeaderText = "Descripcion Producto"
                    Me.dgvDetallePedido.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(1).Width = 260
                    Me.dgvDetallePedido.Columns(2).HeaderText = "Unidad Medida"
                    Me.dgvDetallePedido.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(2).Width = 70
                    Me.dgvDetallePedido.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(3).HeaderText = "Cantidad"
                    Me.dgvDetallePedido.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(3).Width = 80
                    Me.dgvDetallePedido.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvDetallePedido.Columns(4).HeaderText = "Precio Unit."
                    Me.dgvDetallePedido.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(4).Width = 80
                    Me.dgvDetallePedido.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvDetallePedido.Columns(5).HeaderText = "TOTAL"
                    Me.dgvDetallePedido.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvDetallePedido.Columns(5).Width = 90
                    Me.dgvDetallePedido.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    For a As Integer = 6 To Me.dgvDetallePedido.Columns.Count - 1
                        Me.dgvDetallePedido.Columns(a).Visible = False
                    Next
                    If Me.dgvDetallePedido.Rows.Count > 9 Then
                        Me.dgvDetallePedido.Width = 707
                    Else
                        Me.dgvDetallePedido.Width = 694
                    End If
                    If Me.dgvDetallePedido.RowCount > 0 Then
                        Me.dgvDetallePedido.FirstDisplayedScrollingRowIndex = Me.dgvDetallePedido.RowCount - 1
                    End If
                    If Me.cmbTipDoc.SelectedValue = 2 Then
                        For Each row As DataGridViewRow In Me.dgvDetallePedido.Rows
                            row.Cells(4).Value = Math.Round(row.Cells(4).Value / (1 + (PorcIVA / 100)), 4)
                            row.Cells(5).Value = Math.Round(row.Cells(5).Value / (1 + (PorcIVA / 100)), 2)
                        Next
                    End If
                Else
                    numeroOV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
                    PedidoCreado = False
                    limpiaCampos(0)
                    Me.txtNoOrden.Text = numeroOV
                    Me.cmbBODEGA.Enabled = True
                    MsgBox("Numero de Pedido " & numPedido & " no está creado" & vbCrLf & " o no corresponde a Bodega " & Me.cmbBODEGA.Text & ".", MsgBoxStyle.Information, "Error")
                End If
                totalizaFactura()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Cargar Factura")
            End Try
        End If
    End Sub

    Private Sub txtNoOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOrden.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GuardaEliminaRegistroFacturaDetalleOV(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal es_exento As Boolean, ByVal Accion As String)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Dim PrecioUnit As Double
        If es_exento Then
            PrecioUnit = PrecProd / (1 + (PorcIVA / 100))
        Else
            PrecioUnit = PrecProd
        End If
        Try
            sql = " Execute dbo.sp_FACTURACION_FACTURAS_DETALLE_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numeroOV
            sql &= ", " & totRegFact
            sql &= ", " & codProd
            sql &= ", '" & descProd & "'"
            sql &= ", " & UM
            sql &= ", " & Cant
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", " & PrecioUnit
            sql &= ", " & Grupo
            sql &= ", " & SubGrupo
            sql &= ", " & origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sqlCmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            'MsgBox("Registros actualizados: " & corre, MsgBoxStyle.Exclamation, "O.V. Detalle")
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje O.V. Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaMovimientoInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov As Integer, ByVal Accion As String, ByVal TipoCosto As Integer)
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
            sql &= ", " & numeroOV
            sqlCmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            If corre > 0 And TipoCosto = 2 Then
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

    Private Sub GuardaEliminaOrdenVentaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NomFact As String, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal Condicion As Integer, ByVal TipoCliente As Integer, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal NRCCliente As String, ByVal GiroClie As String, ByVal codBuxis As String, ByVal codSocio As String, ByVal Direccion As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaMov As Date, _
                                                        ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal Accion As String)
        Dim totReg As Integer
        Dim sqlCmd As New SqlCommand
        Try
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
            If Not PedidoCreado Then
                numeroOV = obtieneMAXOV(Me.cmbCOMPAÑIA.SelectedValue)
            End If
            sql = " Execute dbo.sp_FACTURACION_FATURAS_ENCABEZADO_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numeroOV
            sql &= ", '" & Format(FechaMov, "Short Date") & "'"
            sql &= ", " & TipDoc
            sql &= ", " & NoFact
            sql &= ", '" & Format(FechaMov, "Short Date") & "'"
            sql &= ", " & FormaPago
            sql &= ", " & Condicion
            sql &= ", " & codCliente
            sql &= ", " & codBuxis
            sql &= ", '" & codSocio & "'"
            sql &= ", " & TipoCliente
            sql &= ", " & TipoContribuyente
            sql &= ", '" & NomFact & "'"
            sql &= ", '" & Direccion & "'"
            sql &= ", '" & txtDUI & "'"
            sql &= ", '" & txtNIT & "'"
            sql &= ", '" & NRCCliente & "'"
            sql &= ", '" & GiroClie & "'"
            sql &= ", " & es_exento
            sql &= ", 0" 'Imprimir Concepto?
            sql &= ", '" & Concepto & "'"
            sql &= ", ''" 'Observaciones
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", '" & periodoPago & "'"
            sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            sql &= ", " & DescuentoAguinaldo
            sql &= ", " & DescuentoBonificacion
            sql &= ", '" & NumRemesa & "'"
            sql &= ", " & IIf(FormaPago = 1, Banco, 0)
            sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
            sqlCmd.CommandText = sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If totReg > 0 And Not PedidoCreado Then
                actualizaNumDoc(CIA, "OV")
            End If
            Me.chkCliExt.Enabled = False
            Me.txtNoOrden.Text = numeroOV
            PedidoCreado = True
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 3")
            _error_ = True
        End Try
    End Sub

    Private Sub bntNuevaOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevaOrden.Click
        Me.limpiaCampos(0)
        Me.cmbBODEGA.Enabled = True
        Me.producto_especial = 0
        Me.cantidad_precio_especial = 0
        Me.chkPre_normal.Checked = True
        Erase Me.productos_facturados
        ReDim Me.productos_facturados(100, 2)
    End Sub

    Private Function AhorrosSocio(ByVal CodSocio As String, ByVal CodBuxy As String) As Double
        Dim sqlCmd As New SqlCommand
        Dim Ahorros As DataTable
        sql = "exec Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO '" & CodSocio & "'," & CodBuxy & "," & Me.cmbCOMPAÑIA.SelectedValue & ",1"
        Try
            sqlCmd.CommandText = sql
            Ahorros = jClass.obtenerDatos(sqlCmd)
            If Ahorros.Rows.Count = 1 Then
                Return Ahorros.Rows(0).Item(6) + Ahorros.Rows(0).Item(7)
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "AhorrosSocio")
        End Try
    End Function

    Private Sub generaGrid()
        Dim rowcount As Integer
        Me.dgvDetallePedido.AllowUserToAddRows = False
        Try
            rowcount = Me.dgvDetallePedido.RowCount
            For a As Integer = 1 To rowcount
                Me.dgvDetallePedido.Rows.RemoveAt(0)
            Next
            Me.dgvDetallePedido.Columns.Clear()
            Me.dgvDetallePedido.Columns.Add("Producto", "Producto")
            Me.dgvDetallePedido.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(0).Width = 70
            Me.dgvDetallePedido.Columns.Add("descprod", "Descripción Producto")
            Me.dgvDetallePedido.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(1).Width = 260
            Me.dgvDetallePedido.Columns.Add("UM", "Unidad Medida")
            Me.dgvDetallePedido.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(2).Width = 70
            Me.dgvDetallePedido.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dgvDetallePedido.Columns.Add("Cant", "Cantidad")
            Me.dgvDetallePedido.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(3).Width = 80
            Me.dgvDetallePedido.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvDetallePedido.Columns.Add("PU", "Precio Unit.")
            Me.dgvDetallePedido.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(4).Width = 80
            Me.dgvDetallePedido.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvDetallePedido.Columns.Add("total", "TOTAL")
            Me.dgvDetallePedido.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetallePedido.Columns(5).Width = 90
            Me.dgvDetallePedido.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvDetallePedido.Width = 694
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardaPedidoEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaPedidoEncabezado.Click
        If validaCamposVacios() Then
            _error_ = False
            GuardaEliminaOrdenVentaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, codClie, Me.cmbTipDoc.SelectedValue, "0", Me.txtNomFact.Text, "", Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO.SelectedValue, TipClie, TipContrib, exento, NRC, giro, Me.lblCodBuxis.Text, Me.txtCliente.Text, dirClie, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.DateTimePicker1.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, IIf(PedidoCreado, "U", "I"))
            If Not _error_ Then
                MsgBox("Pedido Guardado con éxito", MsgBoxStyle.Information, "Guardar")
                Resetear_montomaximo(Me.txtCliente.Text, "")
            End If
        End If
    End Sub

    Private Sub txtNoOrden_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOrden.LostFocus
        Dim numOrden As String
        numOrden = Me.txtNoOrden.Text
        cargaPedidoDetalle(Me.txtNoOrden.Text, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
    End Sub

    Private Function validaCamposVacios() As Boolean
        If Me.txtCliente.Text = Nothing Or Me.txtCliente.Text.Length = 0 Then
            MsgBox("Ingrese un codigo de Socio", MsgBoxStyle.Critical, "Campo Socio Vacio")
            Return False
        End If
        If Me.txtNomFact.Text = Nothing Or Me.txtNomFact.Text.Length = 0 Then
            MsgBox("Ingrese un Nombre para la Factura", MsgBoxStyle.Critical, "Campo Nombre Factura Vacio")
            Return False
        End If
        If Me.DateTimePicker1.Value.Date < Now.Date Then
            MsgBox("Fecha de inicio descuento " & vbCrLf & "no puede ser menor que hoy", MsgBoxStyle.Critical, "Fecha Errónea")
            Me.DateTimePicker1.Focus()
            Return False
        End If
        If NRC.Length = 0 And Me.cmbTipDoc.SelectedValue = 2 Then
            MsgBox("NRC del cliente está vacio" & vbCrLf & "Cambie el tipo de documento o verifique los datos del cliente", MsgBoxStyle.Critical, "NRC No Válido")
            Return False
        End If
        If Val(Me.txtNumCuotas.Text) = 0 And Me.cmbFormaPago.SelectedValue = 2 Then
            MsgBox("Número Cuotas debe ser mayor que cero", MsgBoxStyle.Critical, "Cuotas No Válido")
            Return False
        End If
        Return True
    End Function

    Private Sub cmbTipDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipDoc.SelectedIndexChanged
        If Not Iniciando Then
            totalizaFactura()
        End If
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

    Private Sub cargaPedidosPendientes(ByVal opcion As Integer)
        If Not Iniciando Then
            Dim sqlCmd As New SqlCommand
            Dim Pedidos As DataTable
            sql = "SELECT FFE.IMPRIMIR_CONCEPTO AS OPCION,FFE.ORDEN_VENTA, FCTD.DESCRIPCION_TIPO_DOCUMENTO,CONVERT(VARCHAR(10),FFE.NUMERO_FACTURA_FECHA,103) AS FECHA_FACTURA,FFE.CODIGO_EMPLEADO_AS, FFE.CODIGO_EMPLEADO, FFE.NOMBRE_FACTURA, FFE.TIPO_DOCUMENTO "
            sql &= "FROM dbo.FACTURACION_FACTURAS_ENCABEZADO FFE, dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO FCTD "
            sql &= "WHERE(FFE.COMPAÑIA = FCTD.COMPAÑIA) AND FFE.TIPO_DOCUMENTO = FCTD.TIPO_DOCUMENTO "
            sql &= "AND FFE.NUMERO_FACTURA = 0 AND FFE.BODEGA = " & Me.cmbBODEGA.SelectedValue
            If opcion > 0 Then
                sql &= " AND FFE.TIPO_DOCUMENTO = " & opcion
            End If
            Try
                sqlCmd.CommandText = sql
                Pedidos = jClass.obtenerDatos(sqlCmd)
                Me.dgvPedidosSinFacturar.DataSource = Pedidos
                Me.dgvPedidosSinFacturar.Columns(0).HeaderText = ""
                Me.dgvPedidosSinFacturar.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(0).Width = 30
                Me.dgvPedidosSinFacturar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(1).HeaderText = "Orden Venta"
                Me.dgvPedidosSinFacturar.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(1).Width = 50
                Me.dgvPedidosSinFacturar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(2).HeaderText = "Tipo Docto."
                Me.dgvPedidosSinFacturar.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(2).Width = 150
                Me.dgvPedidosSinFacturar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.dgvPedidosSinFacturar.Columns(3).HeaderText = "Fecha"
                Me.dgvPedidosSinFacturar.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(3).Width = 70
                Me.dgvPedidosSinFacturar.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(4).HeaderText = "Codigo AS"
                Me.dgvPedidosSinFacturar.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(4).Width = 60
                Me.dgvPedidosSinFacturar.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(5).HeaderText = "Codigo BUXIS"
                Me.dgvPedidosSinFacturar.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(5).Width = 60
                Me.dgvPedidosSinFacturar.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(6).HeaderText = "A Nombre de"
                Me.dgvPedidosSinFacturar.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvPedidosSinFacturar.Columns(6).Width = 250
                Me.dgvPedidosSinFacturar.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.dgvPedidosSinFacturar.Columns(7).Visible = False
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 4")
            End Try
        End If
    End Sub

    Private Sub dgvPedidosSinFacturar_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPedidosSinFacturar.CellContentDoubleClick
        Me.cargaPedidoDetalle(Me.dgvPedidosSinFacturar.Rows(e.RowIndex).Cells("ORDEN_VENTA").Value, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
        Me.TabControl1.SelectTab(0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim numFact, TipDoc, MaxNumLineas, numPedido, LineasFactura, secuenciaFactura As Integer
        Dim Subtotal, IVA, Total As Double
        Dim descSerie, observ As String
        Dim sqlCmd As New SqlCommand
        Dim PedidoFactura As DataTable
        descSerie = ""
        observ = ""
        Try
            For Each row As DataGridViewRow In Me.dgvSeriesFacturas.Rows
                If row.Cells("Seleccion").Value Then
                    Numero_Serie = row.Cells("numSerie").Value
                    TipDoc = row.Cells("Tipo_documento").Value
                    descSerie = row.Cells("Tipodoc").Value
                    numFact = row.Cells("Actual").Value
                End If
            Next
            If numFact = 0 Then
                MsgBox("El tipo documento No ha sido establecido!!", MsgBoxStyle.Critical, "Serie Facturación")
                Return
            End If
            MaxNumLineas = cargaMaximoLineas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Numero_Serie, TipDoc)
            If MaxNumLineas = 0 Then
                MsgBox("El numero de lineas para el tipo documento " & descSerie & vbCrLf & "No ha sido establecido", MsgBoxStyle.Critical, "Numero Lineas")
                Return
            End If
            For Each row As DataGridViewRow In Me.dgvPedidosSinFacturar.Rows
                If row.Cells("OPCION").Value And row.Cells("TIPO_DOCUMENTO").Value = TipDoc Then
                    numPedido = row.Cells("ORDEN_VENTA").Value
                    If numPedido = Me.txtNoOrden.Text Then
                        limpiaCampos(0)
                    End If
                    numeroOV = numPedido
                    sql = "SELECT FFD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, FFD.UNIDAD_MEDIDA, FFD.CANTIDAD, FFD.COSTO_UNITARIO, FFD.COSTO_TOTAL, FFD.CODIGO_GRUPO, FFD.CODIGO_SUBGRUPO, FFD.ORIGEN, FFD.PRECIO_UNITARIO, FFD.PRECIO_TOTAL, FFD.LINEA, FFE.CODIGO_EMPLEADO, FFE.CODIGO_EMPLEADO_AS, FFE.DUI, FFE.NIT, IMD.TIPO_MOVIMIENTO, IMD.MOVIMIENTO, FFE.NUMERO_FACTURA, FFE.NUMERO_FACTURA_FECHA, FFE.NOMBRE_FACTURA, FFE.BODEGA, FFE.PERIODO_PAGO, FFE.CUOTAS, FFE.DESCONTAR_CUOTAS_DESDE, FFE.DESCUENTO_AGUINALDO, FFE.DESCUENTO_BONIFICACION, FFE.NUMERO_REMESA, FFE.FORMA_PAGO, FFE.CONDICION_PAGO, FFE.NRC, FFE.GIRO, FFE.CLIENTE, FFE.TIPO_CLIENTE, FFE.TIPO_CONTRIBUYENTE, FFE.EXENTO, FFE.BANCO_REMESA, FFE.CUENTA_BANCO_REMESA, FFE.ORIGEN "
                    sql &= "FROM dbo.FACTURACION_FACTURAS_ENCABEZADO FFE, dbo.FACTURACION_FACTURAS_DETALLE FFD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM "
                    sql &= "WHERE FFE.COMPAÑIA = FFD.COMPAÑIA AND FFE.BODEGA = FFD.BODEGA AND FFE.ORDEN_VENTA = FFD.ORDEN_VENTA AND FFE.COMPAÑIA = IME.COMPAÑIA AND FFE.BODEGA = IME.BODEGA AND FFE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FFD.COMPAÑIA = ICP.COMPAÑIA AND FFD.PRODUCTO = ICP.PRODUCTO AND FFD.COMPAÑIA = ICUM.COMPAÑIA AND FFD.UNIDAD_MEDIDA = ICUM.UNIDAD_MEDIDA AND FFD.PRODUCTO = IMD.PRODUCTO AND FFD.COMPAÑIA = ICP.COMPAÑIA AND FFD.PRODUCTO = ICP.PRODUCTO "
                    sql &= "AND FFE.COMPAÑIA = " & Me.cmbCOMPAÑIA.SelectedValue
                    sql &= " AND FFE.BODEGA = " & Me.cmbBODEGA.SelectedValue
                    sql &= " AND FFE.ORDEN_VENTA = " & numPedido
                    sqlCmd.CommandText = sql
                    PedidoFactura = jClass.obtenerDatos(sqlCmd)
                    For Each TableRow As DataRow In PedidoFactura.Rows
                        LineasFactura += 1
                        Origen = TableRow.Item("ORIGEN")
                        If LineasFactura = 1 Then
                            GuardaEliminaFacturaGeneradaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, PedidoFactura.Rows(0).Item("CLIENTE"), TipDoc, numFact, PedidoFactura.Rows(0).Item("NRC"), PedidoFactura.Rows(0).Item("TIPO_CONTRIBUYENTE"), PedidoFactura.Rows(0).Item("EXENTO"), PedidoFactura.Rows(0).Item("CONDICION_PAGO"), PedidoFactura.Rows(0).Item("NOMBRE_FACTURA"), 0, 0, 0, 0, "", PedidoFactura.Rows(0).Item("FORMA_PAGO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO_AS"), PedidoFactura.Rows(0).Item("DUI"), PedidoFactura.Rows(0).Item("NIT"), PedidoFactura.Rows(0).Item("NUMERO_FACTURA_FECHA"), PedidoFactura.Rows(0).Item("CUOTAS"), PedidoFactura.Rows(0).Item("DESCONTAR_CUOTAS_DESDE"), PedidoFactura.Rows(0).Item("DESCUENTO_AGUINALDO"), PedidoFactura.Rows(0).Item("DESCUENTO_BONIFICACION"), PedidoFactura.Rows(0).Item("PERIODO_PAGO"), PedidoFactura.Rows(0).Item("NUMERO_REMESA"), PedidoFactura.Rows(0).Item("BANCO_REMESA"), PedidoFactura.Rows(0).Item("CUENTA_BANCO_REMESA"), "I")
                        End If
                        GuardaEliminaRegistroFacturaGeneradaDetalle(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, TipDoc, numFact, TableRow.Item("PRODUCTO"), TableRow.Item("DESCRIPCION_PRODUCTO"), TableRow.Item("UNIDAD_MEDIDA"), TableRow.Item("CANTIDAD"), TableRow.Item("COSTO_UNITARIO"), TableRow.Item("COSTO_TOTAL"), TableRow.Item("PRECIO_UNITARIO"), TableRow.Item("PRECIO_TOTAL"), TableRow.Item("CODIGO_GRUPO"), TableRow.Item("CODIGO_SUBGRUPO"), TableRow.Item("EXENTO"), "I")
                        ActualizaInventarioDetalle(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, numPedido, TableRow.Item("TIPO_MOVIMIENTO"), TableRow.Item("MOVIMIENTO"), numFact, TipDoc)
                        If TipDoc = 1 Then
                            Subtotal += TableRow.Item("PRECIO_TOTAL")
                        Else
                            If TableRow.Item("EXENTO") Then
                                Subtotal += TableRow.Item("PRECIO_TOTAL")
                                IVA = 0
                            Else
                                Subtotal += Math.Round((TableRow.Item("PRECIO_TOTAL") / (1 + (PorcIVA / 100))), 2)
                                IVA += Math.Round((TableRow.Item("PRECIO_TOTAL") / (1 + (PorcIVA / 100))) * (PorcIVA / 100), 2)
                            End If
                        End If
                        If LineasFactura >= MaxNumLineas Then
                            If TipDoc = 2 Then
                                If TableRow.Item("EXENTO") Then
                                    IVA = 0
                                Else
                                    IVA = Math.Round(Subtotal * (PorcIVA / 100), 2)
                                End If
                            End If
                            Total = Subtotal + IVA
                            GuardaEliminaFacturaGeneradaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, PedidoFactura.Rows(0).Item("CLIENTE"), TipDoc, numFact, PedidoFactura.Rows(0).Item("NRC"), PedidoFactura.Rows(0).Item("TIPO_CONTRIBUYENTE"), PedidoFactura.Rows(0).Item("EXENTO"), PedidoFactura.Rows(0).Item("CONDICION_PAGO"), PedidoFactura.Rows(0).Item("NOMBRE_FACTURA"), Subtotal, IVA, Total, 0, "", PedidoFactura.Rows(0).Item("FORMA_PAGO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO_AS"), PedidoFactura.Rows(0).Item("DUI"), PedidoFactura.Rows(0).Item("NIT"), PedidoFactura.Rows(0).Item("NUMERO_FACTURA_FECHA"), PedidoFactura.Rows(0).Item("CUOTAS"), PedidoFactura.Rows(0).Item("DESCONTAR_CUOTAS_DESDE"), PedidoFactura.Rows(0).Item("DESCUENTO_AGUINALDO"), PedidoFactura.Rows(0).Item("DESCUENTO_BONIFICACION"), PedidoFactura.Rows(0).Item("PERIODO_PAGO"), PedidoFactura.Rows(0).Item("NUMERO_REMESA"), PedidoFactura.Rows(0).Item("BANCO_REMESA"), PedidoFactura.Rows(0).Item("CUENTA_BANCO_REMESA"), "U")
                            If observ.Length > 0 Then
                                observ &= " ," & numFact
                            Else
                                observ = descSerie & " No. " & numFact
                            End If
                            secuenciaFactura += 1
                            imprimeFactura(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, TipDoc, numFact, numPedido, observ, secuenciaFactura)
                            LineasFactura = 0
                            numFact += 1
                            Subtotal = 0
                            IVA = 0
                            Total = 0
                        End If
                    Next
                    If TipDoc = 2 Then
                        If PedidoFactura.Rows(0).Item("EXENTO") Then
                            IVA = 0
                        Else
                            IVA = Math.Round(Subtotal * (PorcIVA / 100), 2)
                        End If
                    End If
                    Total = Subtotal + IVA
                    GuardaEliminaFacturaGeneradaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, PedidoFactura.Rows(0).Item("CLIENTE"), TipDoc, numFact, PedidoFactura.Rows(0).Item("NRC"), PedidoFactura.Rows(0).Item("TIPO_CONTRIBUYENTE"), PedidoFactura.Rows(0).Item("EXENTO"), PedidoFactura.Rows(0).Item("CONDICION_PAGO"), PedidoFactura.Rows(0).Item("NOMBRE_FACTURA"), Subtotal, IVA, Total, 0, "", PedidoFactura.Rows(0).Item("FORMA_PAGO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO"), PedidoFactura.Rows(0).Item("CODIGO_EMPLEADO_AS"), PedidoFactura.Rows(0).Item("DUI"), PedidoFactura.Rows(0).Item("NIT"), PedidoFactura.Rows(0).Item("NUMERO_FACTURA_FECHA"), PedidoFactura.Rows(0).Item("CUOTAS"), PedidoFactura.Rows(0).Item("DESCONTAR_CUOTAS_DESDE"), PedidoFactura.Rows(0).Item("DESCUENTO_AGUINALDO"), PedidoFactura.Rows(0).Item("DESCUENTO_BONIFICACION"), PedidoFactura.Rows(0).Item("PERIODO_PAGO"), PedidoFactura.Rows(0).Item("NUMERO_REMESA"), PedidoFactura.Rows(0).Item("BANCO_REMESA"), PedidoFactura.Rows(0).Item("CUENTA_BANCO_REMESA"), "U")
                    If observ.Length > 0 Then
                        observ &= " y " & numFact
                    Else
                        observ = descSerie & " No. " & numFact
                    End If
                    secuenciaFactura += 1
                    imprimeFactura(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, TipDoc, numFact, numPedido, observ, secuenciaFactura)
                    observ = ""
                    LineasFactura = 0
                    numFact += 1
                    Subtotal = 0
                    IVA = 0
                    Total = 0
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        cargaPedidosPendientes(0)
        myTipDoc = 0
        cargaSeriesFacturas()
        Me.TabControl1.SelectTab(0)
        Me.txtCliente.Focus()
    End Sub

    Private Function ObtieneNumeroFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal DescSerie As String) As Integer
        Dim sqlCmd As New SqlCommand
        If Not Iniciando Then
            Numero_Serie = 0
            sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", '" & DescSerie & "'"
            sql &= ", " & TipDoc
            sql &= ", 1" 'BANDERA
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                If Table.Rows(0).Item("Activa") Then
                    Return Table.Rows(0).Item("Actual")
                Else
                    Return 0
                End If
            End If
        End If
        Return 0
    End Function

    Private Function cargaMaximoLineas(ByVal cia As Integer, ByVal bodega As Integer, ByVal serie As Integer, ByVal tipoDoc As Integer) As Integer
        Try
            sql = " Execute sp_FACTURACION_LINEAS_TIPO_DOCUMENTO "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", 0" 'LINEAS MAXIMO
            sql &= ", 2" 'BANDERA
            MaxNumLineas = jClass.obtenerEscalar(sql)
            Return MaxNumLineas
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 5")
        End Try
    End Function

    Private Sub GuardaEliminaFacturaGeneradaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                        ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                        ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                        ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, _
                                                        ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal Accion As String)
        Dim totReg, corre As Integer
        Dim Retencion As Double = 0
        Dim sqlCmd As New SqlCommand
        If DescuentoAguinaldo + DescuentoBonificacion = Val(Total) Then
            Cuotas = 0
        End If
        If (TipoContribuyente = 1 Or TipoContribuyente = 2) And TipDoc = 2 And Not exento And Contribuyente = 3 Then
            Retencion = Math.Round(Subtotal * (PorcPercep / 100), 2)
        End If
        Try
            sql = " Execute dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numeroOV
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
            sql &= ", " & (Total - Retencion)
            sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            sql &= ", " & DescuentoAguinaldo
            sql &= ", " & DescuentoBonificacion
            sql &= ", '" & NumRemesa & "'"
            sql &= ", 0" 'ANULADA?
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & Banco
            sql &= ", '" & Numero_Cta & "'"
            sqlCmd.CommandText = sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If Accion = "I" Then
                corre = actualizaCorrelativoFactura(CIA, Bodega, Numero_Serie, TipDoc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Encabezado")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal es_exento As Boolean, ByVal Accion As String)
        Dim corre As Integer
        Dim sqlcmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_FACTURACION_GENERADA_DETALLE_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numeroOV
            sql &= ", " & TipDoc
            sql &= ", " & NoFact
            sql &= ", " & totRegFact
            sql &= ", " & codProd
            sql &= ", '" & descProd & "'"
            sql &= ", " & UM
            sql &= ", " & Cant
            sql &= ", 0" 'LIBRAS?
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", " & PrecProd
            sql &= ", " & Total
            sql &= ", " & Grupo
            sql &= ", " & SubGrupo
            sql &= ", " & Origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sqlcmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlcmd)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub cargaSeriesFacturas()
        Dim sqlCmd As New SqlCommand
        Dim rowcount As Integer
        If Not Iniciando Then
            sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
            sql &= Me.cmbCOMPAÑIA.SelectedValue
            sql &= ", " & Me.cmbBODEGA.SelectedValue
            sql &= ", '0'" 'DESCRIPCION_SERIE
            sql &= ", 0" 'TIPO DOCUMENTO
            sql &= ", 1" 'BANDERA
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            rowcount = Me.dgvSeriesFacturas.RowCount
            For a As Integer = 1 To rowcount
                Me.dgvSeriesFacturas.Rows.RemoveAt(0)
            Next
            For b As Integer = 0 To Table.Rows.Count - 1
                Me.dgvSeriesFacturas.Rows.Add(False, Table.Rows(b).Item("Serie"), Table.Rows(b).Item("Descripción"), Table.Rows(b).Item("Tipo Documento"), Table.Rows(b).Item("Inicio"), Table.Rows(b).Item("Final"), Table.Rows(b).Item("Actual"), Table.Rows(b).Item("TipoDocumento"))
            Next
        End If
    End Sub

    Private Function actualizaCorrelativoFactura(ByVal cia As Integer, ByVal bodega As Integer, ByVal serie As Integer, ByVal tipoDoc As Integer) As Integer
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_GENERA_CORRELATIVOS_SERIES "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", " & 0 'ACTUAL (Se genera automaticamente en el SP)
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                If DataReader_.Item("CORRELATIVO_ACTUAL").ToString = "-1" Then
                    MsgBox("Serie llegó a su límite. Intente con otra.", MsgBoxStyle.Exclamation, "Mensaje 6")
                    Return 0
                Else
                    Return DataReader_.Item("CORRELATIVO_ACTUAL")
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 7")
            Return 0
        End Try
    End Function

    Private Sub dgvSeriesFacturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeriesFacturas.CellContentClick
        Dim colname As String
        colname = sender.Columns(e.ColumnIndex).Name
        If colname = "Seleccion" Then
            For a As Integer = 0 To sender.rows.count - 1
                If e.RowIndex <> a Then
                    Me.dgvSeriesFacturas.Rows.Item(a).Cells("Seleccion").Value = False
                End If
            Next
        End If
    End Sub

    Private Sub dgvPedidosSinFacturar_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPedidosSinFacturar.CellEndEdit
        If myTipDoc = 0 And sender.Columns(e.ColumnIndex).Name = "OPCION" And Me.dgvPedidosSinFacturar.Rows.Item(e.RowIndex).Cells("OPCION").Value Then
            Me.dgvPedidosSinFacturar.Rows.Item(e.RowIndex).Cells(0).Value = False
            MsgBox("Debe elegir una Serie de Facturación", MsgBoxStyle.Critical, "Serie no Seleccionada")
            Return
        End If
        If myTipDoc <> Me.dgvPedidosSinFacturar.Rows.Item(e.RowIndex).Cells("TIPO_DOCUMENTO").Value And Me.dgvPedidosSinFacturar.Rows.Item(e.RowIndex).Cells("OPCION").Value Then
            Me.dgvPedidosSinFacturar.Rows.Item(e.RowIndex).Cells(0).Value = False
            MsgBox("Tipo de Factura no coincide con la Serie elegida", MsgBoxStyle.Critical, "Tipo incorrecto")
        End If
    End Sub

    Private Sub dgvSeriesFacturas_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeriesFacturas.CellEndEdit
        Dim colname As String
        Dim isSel As Boolean
        colname = sender.Columns(e.ColumnIndex).Name
        If colname = "Seleccion" Then
            isSel = Me.dgvSeriesFacturas.Rows.Item(e.RowIndex).Cells(colname).Value
            If isSel Then
                myTipDoc = sender.Rows.Item(e.RowIndex).Cells("Tipo_documento").Value
            Else
                myTipDoc = 0
            End If
        End If
    End Sub

    Private Sub imprimeFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal numFactura As Integer, ByVal numPedido As Integer, ByVal Observ As String, ByVal secuencia As Integer)
        Dim sqlCmd As New SqlCommand
        Dim totFact, descAgui, descBoni, descPeriodos As Double
        Dim numSoli, Banco As Integer
        Dim NumPartida As Integer = 0
        Dim CtaBanco As String
        Dim CtaContable As Integer = 0
        Dim documento As CrystalDecisions.CrystalReports.Engine.ReportClass
        'Actualiza el numero de factura en la Orden de Venta
        sql = "UPDATE dbo.FACTURACION_FACTURAS_ENCABEZADO SET NUMERO_FACTURA = " & numFactura & ", OBSERVACIONES = '" & Observ & "'"
        sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
        sqlCmd.CommandText = sql
        jClass.ejecutarComandoSql(sqlCmd)
        'Imprimir factura
        If TipDoc = 1 Then
            documento = New Facturacion_Factura_Consumidor_Final_Almacen
            sql = "EXECUTE sp_FACTURACION_IMPRIME_FACTURA_CONSUMIDOR_FINAL @TIPO_DOCUMENTO = " & TipDoc
            sql &= ", @NUMERO_DOCUMENTO = " & numFactura
            sql &= ", @BANDERA = 0"
            sql &= ", @COMPAÑIA = " & Compañia
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
                If Table.Rows(0).Item("CLIENTE") = 0 And Not Table.Rows(0).Item("FACTURA_IMPRESA") And Table.Rows(0).Item("FORMA_PAGO") = 2 Then
                    If secuencia = 1 Then
                        descAgui = Table.Rows(0).Item("DESCUENTO_AGUINALDO")
                        descBoni = Table.Rows(0).Item("DESCUENTO_BONIFICACION")
                    End If
                    descPeriodos = totFact - descAgui - descBoni
                    numSoli = actualizaNumDoc(CIA, "SOL")
                    FPro.SolicitudesFacturacionSocios(CIA, TipoSolicitud, numSoli, Table.Rows(0).Item("CODIGO_EMPLEADO_AS"), Table.Rows(0).Item("CODIGO_EMPLEADO"), Now.Date, 1, descPeriodos, descAgui, descBoni, Table.Rows(0).Item("PERIODO_PAGO"), Table.Rows(0).Item("CUOTAS"), Table.Rows(0).Item("DESCONTAR_CUOTAS_DESDE"), "Factura No." & numFactura & " Generada en " & Me.cmbBODEGA.Text, TipDoc, numFactura)
                End If
                Table = jClass.obtenerDatos(sqlCmd)
                documento.SetDataSource(Table)
                documento.PrintToPrinter(1, True, 0, 0)
                If TipDoc = 2 And Not Table.Rows(0).Item("FACTURA_IMPRESA") Then
                    If Table.Rows(0).Item("FORMA_PAGO") = 1 Then
                        Banco = jClass.obtenerEscalar("SELECT BANCO_REMESA FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & numFactura)
                        CtaBanco = jClass.obtenerEscalar("SELECT CUENTA_BANCO_REMESA FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TIPO_DOCUMENTO = " & TipDoc & " AND NUMERO_FACTURA = " & numFactura)
                        If Banco > 0 And CtaBanco.Length > 0 Then
                            CtaContable = jClass.obtenerEscalar("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_BANCARIA = '" & CtaBanco & "' AND BANCO = " & Banco)
                        End If
                    End If
                    NumPartida = multi.Contabiliza_Partida_Automatica_Standard(CIA _
                                                                  , CC _
                                                                  , multi.Busca_TipoDocumento_Contable(CIA, TipDoc) _
                                                                  , Origen _
                                                                  , numFactura _
                                                                  , Format(multi.FechaActual_Servidor(), "dd-MM-yyyy HH:mm:ss") _
                                                                  , CtaContable _
                                                                  , numPedido _
                                                                  , totFact _
                                                                  , "CCF# " & numFactura & " generado el " & Format(multi.FechaActual_Servidor(), "dd-MM-yyyy HH:mm:ss"))
                End If
                'Actualizar bandera de impreso para la factura
                sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET FACTURA_IMPRESA = 1, NUMERO_PARTIDA = " & NumPartida
                sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
                sql &= " AND TIPO_DOCUMENTO=" & TipDoc & " AND NUMERO_FACTURA=" & numFactura
                sqlCmd.CommandText = sql
                jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje 8")
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        cargaSeriesFacturas()
        cargaPedidosPendientes(0)
    End Sub

    Private Sub ActualizaInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal numPedido As Integer, ByVal tipmov As Integer, ByVal movto As Integer, ByVal NumFactura As Integer, ByVal TipDoc As Integer)
        Dim sqlCmd As New SqlCommand
        'Actualiza los registros del inventario con el numero de factura generado
        sql = "UPDATE dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO SET NUMERO_DOCUMENTO_CONTABLE = " & NumFactura & ", TIPO_DOCUMENTO_CONTABLE = " & TipDoc
        sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
        sql &= " AND TIPO_MOVIMIENTO=" & tipmov & " AND MOVIMIENTO=" & movto
        sqlCmd.CommandText = sql
        jClass.ejecutarComandoSql(sqlCmd)
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
        Me.Label24.Visible = sender.checked
        Me.cmbCONDICION_PAGO.Visible = sender.checked
        Me.CheckDisponible.Visible = Not sender.checked
        Me.Label7.Visible = Not sender.checked
        Me.lblCodBuxis.Visible = Not sender.checked
        If sender.checked Then
            Me.Label8.Text = "Cliente    :"
            Me.Label13.Text = "Nombre Cliente:"
            Me.TabPage2.Text = "Historial Facturas del Cliente"
            Me.cmbTipDoc.SelectedValue = 2
        Else
            Me.Label8.Text = "Codigo AS  :"
            Me.Label13.Text = "Nombre AS :"
            Me.TabPage2.Text = "Historial Facturas del Socio"
            Me.cmbTipDoc.SelectedValue = 1
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If Not Iniciando Then
            multi.CargaCondicionPago(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO)
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

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        SetearFechas()
    End Sub
    Private Sub SetearFechas()
        Dim Fecha As Date = Me.DateTimePicker1.Value
        If Me.DateTimePicker1.Value.Day < 15 Then
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
            sql = "SELECT TIPO_FACTURA,TIPO_CCF,TIPO_SOLICITUD FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Me.cmbCOMPAÑIA.SelectedValue & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
            sqlCmd.CommandText = sql
            ParamBodegas = jClass.obtenerDatos(sqlCmd)
            TipMovInvFact = ParamBodegas.Rows(0).Item("TIPO_FACTURA")
            TipMovInvCCF = ParamBodegas.Rows(0).Item("TIPO_CCF")
            TipoSolicitud = ParamBodegas.Rows(0).Item("TIPO_SOLICITUD")
            If Me.cmbTipDoc.SelectedValue = 1 Then
                TipMovInv = TipMovInvFact
            ElseIf Me.cmbTipDoc.SelectedValue = 2 Then
                TipMovInv = TipMovInvCCF
            End If
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

    Private Sub btnCopiaPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiaPedido.Click
        Dim sqlCmd As New SqlCommand
        Dim RegCopiados As Integer
        Dim PedidoAnterior As String
        If validaCamposVacios() Then
            PedidoCreado = False
            PedidoAnterior = Me.txtNoOrden.Text
            GuardaEliminaOrdenVentaEncabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, codClie, Me.cmbTipDoc.SelectedValue, "0", Me.txtNomFact.Text, "", Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO.SelectedValue, TipClie, TipContrib, exento, NRC, giro, Me.lblCodBuxis.Text, Me.txtCliente.Text, dirClie, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, Val(Me.txtNumCuotas.Text), Me.DateTimePicker1.Value, Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNoRemesa.Text, Me.cmbBancos.SelectedValue, Me.cmbCtasBanco.SelectedValue, "I")
            sql = "EXECUTE dbo.sp_FACTURACION_FACTURAS_DETALLE_DUPLICA_ORDEN_VENTA"
            sql &= " @COMPAÑIA = " & Compañia
            sql &= ", @BODEGA = " & Me.cmbBODEGA.SelectedValue
            sql &= ", @ORDEN_VENTA_OLD = " & PedidoAnterior
            sql &= ", @ORDEN_VENTA_NEW = " & numeroOV
            sql &= ", @USUARIO = '" & Usuario & "'"
            sqlCmd.CommandText = sql
            RegCopiados = jClass.ejecutarComandoSql(sqlCmd)
            For Each row As DataGridViewRow In Me.dgvDetallePedido.Rows
                GuardaEliminaMovimientoInventarioDetalle(Compañia, Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, "0", row.Cells("PRODUCTO").Value, row.Cells("CANTIDAD").Value, Me.obtieneCostoProducto(Compañia, Me.cmbBODEGA.SelectedValue, row.Cells("PRODUCTO").Value, Me.DateTimePicker1.Value.Date, tipoCosto), obtieneCostoProducto(Compañia, Me.cmbBODEGA.SelectedValue, row.Cells("PRODUCTO").Value, Me.DateTimePicker1.Value.Date, tipoCosto) * row.Cells("CANTIDAD").Value, multi.FechaActual_Servidor(), TipMovInv, FPro.ObtieneCorrelativoInventario(Compañia, Me.cmbBODEGA.SelectedValue, 0, numeroOV), "I", tipoCosto)
            Next
            Me.txtNoOrden.Text = numeroOV.ToString("0")
            Me.cargaPedidoDetalle(numeroOV, Compañia, Me.cmbBODEGA.SelectedValue)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If MsgBox("¿Está seguro de eliminar este Pedido COMPLETAMENTE?", MsgBoxStyle.YesNo, "Eliminar Item") = MsgBoxResult.No Then
            Return
        End If
        Dim sqlCmd As New SqlCommand
        Dim TipMov, NumMov As Integer
        For Each CurRow As DataGridViewRow In Me.dgvDetallePedido.Rows
            TipMov = CurRow.Cells("TIPO_MOVIMIENTO").Value
            NumMov = CurRow.Cells("MOVIMIENTO").Value
            GuardaEliminaMovimientoInventarioDetalle(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "0", CurRow.Cells("PRODUCTO").Value, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, CurRow.Cells("TIPO_MOVIMIENTO").Value, CurRow.Cells("MOVIMIENTO").Value, "DD", tipoCosto)
            totRegFact = CurRow.Cells("LINEA").Value
            GuardaEliminaRegistroFacturaDetalleOV(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCTO").Value, "", 0, 0, 0, 0, 0, 0, 0, True, "D")
        Next
        sql = "DELETE FROM FACTURACION_FACTURAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia
        sql &= " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
        sql &= " AND ORDEN_VENTA = " & Me.txtNoOrden.Text
        sqlCmd.CommandText = sql
        jClass.ejecutarComandoSql(sqlCmd)
        sql = "DELETE FROM DBO.INVENTARIOS_MOVIMIENTOS_ENCABEZADO"
        sql &= " WHERE COMPAÑIA = " & Compañia
        sql &= " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
        sql &= " AND TIPO_MOVIMIENTO = " & TipMov
        sql &= " AND MOVIMIENTO = " & NumMov
        sqlCmd.CommandText = sql
        jClass.ejecutarComandoSql(sqlCmd)
        limpiaCampos(0)
    End Sub

    Private Sub SelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll.CheckedChanged
        For Each row As DataGridViewRow In Me.dgvPedidosSinFacturar.Rows
            row.Cells(0).Value = SelectAll.Checked
        Next
        If SelectAll.Checked Then
            SelectAll.Text = "Deseleccionar Todos"
        Else
            SelectAll.Text = "Seleccionar Todos"
        End If
    End Sub

    Private Sub Facturacion_Bodegas_Despensa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.bntNuevaOrden.PerformClick()
            Case Keys.F1
                'Add the code for the function key F1 here.
                'Me.btnAnular.PerformClick()
            Case Keys.F2
                'Add the code for the function key F2 here.
            Case Keys.F3
                'Add the code for the function key F5 here.
                Me.btnBuscarCliente.PerformClick()
            Case Keys.F4
                'Add the code for the function key F6 here.
                Me.btnAnular.PerformClick()
            Case Keys.F5
                'Add the code for the function key F7 here.
                Me.btnCopiaPedido.PerformClick()
            Case Keys.F6
                'Add the code for the function key F9 here.
                Me.btnBuscarProducto.PerformClick()
            Case Keys.F7
                'Add the code for the function key F10 here.
                'btnEliminarProducto.PerformClick()
            Case Keys.F8
                If Origen <> origen_autoconsumo Then
                    BuscarProducto_PrecioEspecial()
                Else
                    MsgBox("No es posible acceder a precios especiales para clientes de auto-consumo", MsgBoxStyle.Critical, "No hay acceso")
                End If
        End Select
    End Sub

    Private Sub cmbBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
        If Not Iniciando Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
            If Me.cmbCtasBanco.Items.Count > 0 Then
                Me.cmbCtasBanco.SelectedIndex = 0
            Else
                Me.cmbCtasBanco.Text = ""
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

    Private Sub txtdescuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuento.LostFocus
        If Me.txtdescuento.Text.Length = 0 Then
            Me.txtdescuento.Text = "0.0"
        End If
    End Sub


    ' busca los productos con precios especiales para la bodega seleccionada
    Private Sub BuscarProducto_PrecioEspecial()
        Dim productoespecial As New Facturacion_Busqueda_Productos_Precio_Especial
        Me.txtProducto.Clear()
        Producto = ""
        productoespecial.cmbCOMPAÑIA.SelectedValue = Compañia
        productoespecial.Bodega_Value = Me.cmbBODEGA.SelectedValue
        productoespecial.cmbCOMPAÑIA.Enabled = False
        productoespecial.cmbBODEGA.Enabled = False
        productoespecial.ShowDialog()
        If Producto <> "" Then

            If Me.dgvDetallePedido.Rows.Count <> 0 Then
                For Each row As DataGridViewRow In Me.dgvDetallePedido.Rows
                    If Val(row.Cells("PRODUCTO").Value) <> Producto Then
                        Me.txtProducto.Text = Producto
                        producto_especial = Descripcion_Producto
                        Obtenerdatos_pro_PrecioEspecial()
                        Me.chkPre_normal.Checked = False
                        Me.txtdescuento.Text = "0.0"
                    Else
                        MsgBox("Este producto ya existe en la factura a precio normal, no es posible facturar el mismo producto con un precio especial", MsgBoxStyle.Critical, "Error")
                        LimpiaCamposDetallePedido()
                        Return
                    End If
                Next
            Else
                Me.txtProducto.Text = Producto
                producto_especial = Descripcion_Producto
                Obtenerdatos_pro_PrecioEspecial()
                Me.txtdescuento.Text = "0.0"
            End If

        End If
    End Sub

    'obtiene los datos de los productos con precio especial
    Private Sub Obtenerdatos_pro_PrecioEspecial()
        Dim Comando_sql As New SqlCommand
        Dim sql As String
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & Me.txtProducto.Text
        sql &= ", '0', 0, 2"
        Comando_sql.CommandText = sql
        Table = jClass.obtenerDatos(Comando_sql)
        If Table.Rows.Count = 1 Then
            Me.txtDescripcion.Text = Table.Rows(0).Item("DESCRIPCION_PRODUCTO")
            Iniciando = True
            Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(0).Item("UNIDAD_MEDIDA")
            Iniciando = False
        End If
        sql = "select PRODUCTO, CANTIDAD, PRECIO_ESPECIAL from INVENTARIOS_PRODUCTOS_PRECIO_ESPECIAL"
        sql &= " where IDPROD_PRE_ESP = " & producto_especial

        Comando_sql.CommandText = sql
        Table = jClass.obtenerDatos(Comando_sql)
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

    Private Sub txtNoRemesa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoRemesa.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtSoloNumeros_y_UnPunto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescAGUI.KeyPress, txtDescBONI.KeyPress, txtdescuento.KeyPress
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
        sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
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

End Class
