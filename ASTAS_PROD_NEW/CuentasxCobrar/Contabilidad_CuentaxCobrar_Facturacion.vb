Imports System.Data.SqlClient

Public Class Contabilidad_CuentaxCobrar_Facturacion

    'Constructor
    Dim multi As New multiUsos
    Dim jClass As New jarsClass

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Dim CentCost, ClientExterno As Integer
    Dim porcIVA As Double

    'Variable para determinar si se insertara o actualizara un registro
    Public IU As String = "I"
    'Variable para comprobar si los procesos se realizaron correctamente
    Public NumProcess As Integer = 0

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim Table2 As DataTable
    Dim DataReader_ As SqlDataReader

    'Cuando se carga el formulario
    Private Sub Contabilidad_CuentaxCobrar_Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA_OV.Value = Now
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        cargaCMB_1(Compañia)
        jClass.CargaBancos(Compañia, Me.cmbBancos)
        Me.cmbBancos.SelectedValue = 6
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 4, Me.cmbCtasBanco)
        Me.cmbCtasBanco.SelectedIndex = 0
        Me.lblFactSiNo.Text = "Documento Nuevo"
        porcIVA = DevuelveConstante(1)
        ClientExterno = DevuelveConstante(32)
        Iniciando = False
        CentCost = jClass.obtenerEscalar("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue)
    End Sub

    'Carga los combobox del tab Datos
    Private Sub cargaCMB_1(ByVal cia)
        'Cuando se ha elegido ya un detalle de producto
        Dim posProd As Integer = 0
        'multi.CargaOrigenes(cia, Me.cmbORIGENES)
        multi.CargaTipoCliente(cia, Me.cmbTIPO_CLIENTE)
        multi.CargaContribuyente(cia, Me.cmbCONTRIBUYENTE)
        multi.CargaTipoDocumentoFact(cia, Me.cmbTIPO_DOCUMENTO)
        If Me.chkSocio.Checked Then
            multi.CargaFormaPago(cia, Me.cmbFORMA_PAGO)
        Else
            FormaPago()
        End If
        multi.CargaCondicionPago(cia, Me.cmbFORMA_PAGO.SelectedValue, Me.cmbCONDICION_PAGO)
        multi.CargaUnidadMedida(cia, Me.cmbUNIDAD_MEDIDA)
    End Sub

    'Llena el ComboBox de Forma de Pago
    Private Sub FormaPago()
        Dim tblFrmPago As New DataTable("frmpgo")
        Try
            tblFrmPago.Columns.Add("Forma Pago", Type.GetType("System.Int32"))
            tblFrmPago.Columns.Add("Descripción Forma", Type.GetType("System.String"))
            tblFrmPago.Rows.Add(1, "Contado")
            tblFrmPago.Rows.Add(2, "Crédito")
            tblFrmPago.Rows.Add(3, "Liquidación Pendiente")
            cmbFORMA_PAGO.DataSource = tblFrmPago
            cmbFORMA_PAGO.ValueMember = "Forma Pago"
            cmbFORMA_PAGO.DisplayMember = "Descripción Forma"
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Validaciones Comilla Simple
    Private Sub txtDireccionCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionCliente.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtTelCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelCliente.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtFaxCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFaxCliente.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtGiro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGiro.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtNombreFactura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreFactura.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtConcepto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtRegFiscal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegFiscal.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        multi.soloNumeros(e)
    End Sub
    Private Sub txtDescripción_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        multi.noComillaSimple(e)
    End Sub
    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtPrecio.Focus()
        End If
        multi.soloNumerosPuntos(e)
    End Sub
    Private Sub txtPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.btnGuardarDetalle.Focus()
        End If
        multi.soloNumerosPuntos(e)
    End Sub
    Private Sub txtLibras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLibras.KeyPress
        multi.soloNumerosPuntos(e)
    End Sub
    Private Sub txtNombreCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreCliente.Click
        If Trim(Me.txtNombreFactura.Text) = Nothing Then
            Me.txtNombreFactura.Text = Trim(Me.txtNombreCliente.Text)
        End If
    End Sub

    'Eventos KeyDown
    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyValue = 13 Then
            Me.txtCantidad.Focus()
        End If
    End Sub
    Private Sub txtProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        If e.KeyValue = 13 Then
            Me.txtCantidad.Focus()
        End If
    End Sub

    'Busqueda de Clientes
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        busquedaClientes(1, 2)
    End Sub

    'Metodo de busqueda de clientes
    Public Sub busquedaClientes(ByVal tb As Integer, ByVal flag As Integer)
        Dim Socios As New Facturacion_BusquedaSocios
        Socios.Compañia_Value = Compañia
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        Dim clientes As New Contabilidad_BusquedaClientes
        clientes.Compañia_Value = Compañia
        clientes.cmbCOMPAÑIA.Enabled = False
        clientes.numForm = 46882
        clientes.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        If Not Me.chkSocio.Checked Then
            clientes.ShowDialog()
            Me.txtCliente.Text = Producto
            datosCliente()
        Else
            Socios.ShowDialog()
            datosSocio(Producto, Producto)
        End If
        'If Producto <> "" Then
        '    Conexion_ = multi.devuelveCadenaConexion()
        '    Try
        '        limpiarCampos(Me.gbDC)
        '        sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
        '        sql &= Compañia
        '        If flag = 2 Then
        '            sql &= ", " & Producto
        '        ElseIf flag = 3 Then
        '            sql &= ", '" & Producto & "'"
        '        End If
        '        sql &= ", '" & Numero & "' "
        '        sql &= ", " & flag
        '        Conexion_.Open()
        '        DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
        '        Table = New DataTable("Datos")
        '        DataAdapter_.Fill(Table)
        '        Conexion_.Close()
        '        For i As Integer = 0 To Table.Rows.Count - 1
        '            Me.txtCliente.Text = Table.Rows(i).Item("Cliente")
        '            Me.txtNombreFactura.Text = Table.Rows(i).Item("Nombre")
        '            Me.txtNombreCliente.Text = Table.Rows(i).Item("Nombre")
        '            Me.txtDireccionCliente.Text = Table.Rows(i).Item("Dirección")
        '            Me.txtTelCliente.Text = Table.Rows(i).Item("Teléfono")
        '            Me.txtFaxCliente.Text = Table.Rows(i).Item("Fax")
        '            Me.txtDuiCliente.Text = Table.Rows(i).Item("DUI")
        '            Me.txtNitCliente.Text = Table.Rows(i).Item("NIT")
        '            Me.cmbTIPO_CLIENTE.SelectedValue = Table.Rows(i).Item("Tipo Cliente")
        '            Me.cmbCONTRIBUYENTE.SelectedValue = Table.Rows(i).Item("Tipo Contribuyente")
        '            Me.txtRegFiscal.Text = Table.Rows(i).Item("NRC")
        '            Me.txtGiro.Text = Table.Rows(i).Item("Giro")
        '            If Table.Rows(i).Item("Exento") = True Then
        '                Me.chkExento.CheckState = CheckState.Checked
        '            ElseIf Table.Rows(i).Item("Exento") = False Then
        '                Me.chkExento.CheckState = CheckState.Unchecked
        '            End If
        '        Next
        '        Iniciando = True
        '        Me.cmbBODEGA.Enabled = False
        '        Iniciando = False
        '        Producto = ""
        '        Numero = ""
        '        Check = 0
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End If
    End Sub

    Private Sub datosCliente()
        If txtCliente.Text.Length > 0 Then
            Conexion_ = multi.devuelveCadenaConexion()
            Try
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Compañia
                sql &= ", " & txtCliente.Text
                sql &= ", '" & jClass.obtenerEscalar("SELECT NIT FROM dbo.CONTABILIDAD_CATALOGO_CLIENTES WHERE CLIENTE = " & Val(Me.txtCliente.Text) & " AND COMPAÑIA = " & Compañia) & "' "
                sql &= ", 2"
                Conexion_.Open()
                DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
                Table = New DataTable("Datos")
                DataAdapter_.Fill(Table)
                Conexion_.Close()
                If Table.Rows.Count > 0 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("Cliente")
                    Me.txtNombreFactura.Text = Table.Rows(0).Item("Nombre")
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("Nombre")
                    Me.txtDireccionCliente.Text = Table.Rows(0).Item("Dirección")
                    Me.txtTelCliente.Text = Table.Rows(0).Item("Teléfono")
                    Me.txtFaxCliente.Text = Table.Rows(0).Item("Fax")
                    Me.txtDuiCliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNitCliente.Text = Table.Rows(0).Item("NIT")
                    Me.cmbTIPO_CLIENTE.SelectedValue = Table.Rows(0).Item("Tipo Cliente")
                    Me.cmbCONTRIBUYENTE.SelectedValue = Table.Rows(0).Item("Tipo Contribuyente")
                    Me.txtRegFiscal.Text = Table.Rows(0).Item("NRC")
                    Me.txtGiro.Text = Table.Rows(0).Item("Giro")
                    Me.chkExento.Checked = Table.Rows(0).Item("Exento")
                    sql = "EXECUTE [dbo].[sp_FACTURACION_ABONOS]" & vbCrLf
                    sql &= " @COMPAÑIA = " & Compañia & vbCrLf
                    sql &= ",@CLIENTE = " & Me.txtCliente.Text & vbCrLf
                    sql &= ",@BANDERA = 2"
                    Me.txtSaldoPend.Text = Format(jClass.obtenerEscalar(sql), "0.00")
                    Iniciando = True
                    Me.cmbBODEGA.Enabled = False
                    Iniciando = False
                Else
                    MsgBox("No hay datos para el codigo cliente: " & Me.txtCliente.Text, MsgBoxStyle.Information, "Búsqueda")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error Busqueda Enter")
            End Try
        End If
    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        If numSocio <> "" Then
            Try
                sql = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
                sql &= Compañia
                sql &= ", '" & numSocio & "'"
                sql &= ", " & codEmp
                sql &= ", 13" 'BANDERA
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtNombreFactura.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtTelCliente.Text = Table.Rows(0).Item("TELEFONO")
                    Me.txtDuiCliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNitCliente.Text = Table.Rows(0).Item("NIT")
                    Me.txtDireccionCliente.Text = Table.Rows(0).Item("DIRECCION")
                    Origen = Table.Rows(0).Item("ORIGEN")
                    Me.txtProducto.Focus()
                    Me.cmbTIPO_CLIENTE.SelectedValue = 1
                    Me.cmbCONTRIBUYENTE.SelectedValue = 0
                Else
                    Origen = 0
                    MsgBox("No se encontraron datos para el socio: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    'Metodo que limpia los campos acorde al sector especificado
    Private Sub limpiarCampos(ByVal sector As GroupBox)
        Dim elemento As Control
        'Evalua cada elemento y si es un textbox limpia este mismo
        For Each elemento In sector.Controls
            If TypeOf elemento Is TextBox Or TypeOf elemento Is MaskedTextBox Then
                If elemento.Name = "txtConcepto" Or elemento.Name = "txtNombreFactura" Then
                    If elemento.Text = Nothing Then
                        elemento.Text = ""
                    End If
                Else
                    elemento.Text = ""
                End If
            End If
        Next
        If sector.Name = "gbDC" Then
            If Trim(Me.txtLinea.Text) = Nothing Or Trim(Me.txtLinea.Text) = "0" Then
                cargaCMB_1(Compañia)
                Me.chkExento.CheckState = 0
                Me.chkModif.CheckState = 0
                'Me.dpFECHA_OV.Value = multi.FechaActual_Servidor()
                Me.lblFactSiNo.Text = "Documento Nuevo"
            End If
        End If
    End Sub

    'Busqueda de Productos
    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim productos As New Inventario_BusquedaProductos
        productos.Compañia_Value = Compañia
        Numero_Factura = 0
        Numero = ""
        Producto = ""
        Descripcion_Producto = ""
        Me.txtPrecio.Clear()
        productos.ShowDialog()
        If CodigoProducto > 0 Then
            Conexion_ = multi.devuelveCadenaConexion()
            Try
                Conexion_.Open()
                limpiaCamposDetalle()
                Me.txtProducto.Text = CodigoProducto
                Me.txtDescripcion.Text = Numero
                Me.cmbUNIDAD_MEDIDA.SelectedValue = Numero_Factura
                Me.txtPrecio.Text = Math.Round(obtenerCU(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.txtProducto.Text), Me.cmbUNIDAD_MEDIDA.SelectedValue, 1), 2, MidpointRounding.AwayFromZero)
                Me.txtCantidad.Focus()
                Conexion_.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    'Funcion que devuelve el costo Unitario
    Private Function obtenerCU(ByVal cia, ByVal bodega, ByVal producto, ByVal unidad, ByVal flag)
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & producto
            sql &= ", " & unidad
            sql &= ", " & 0
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                If flag = 0 Then
                    Return DataReader_.Item("Costo Unitario")
                ElseIf flag = 1 Then
                    Return DataReader_.Item("Precio Unitario")
                End If
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            Return 0
        End Try
    End Function

    'Limpia los campos del detalle de la orden de venta
    Private Sub limpiaCamposDetalle()
        Me.txtProducto.Clear()
        Me.txtDescripcion.Clear()
        Me.txtCantidad.Clear()
        Me.txtPrecio.Clear()
        Me.txtLinea.Text = "0"
        Me.chkModif.Checked = False
    End Sub

    'Método para Actualizaz los datos del cliente, esto no guarda datos de clientes nuevos.
    Private Sub btnActualizarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCliente.Click
        If valCMB(Me.gbDC, 1) = Nothing Then
            If Trim(Me.txtCliente.Text) <> Nothing Then
                If valCamposVacios(Me.cmbTIPO_CLIENTE, Trim(Me.txtNombreCliente.Text), "Cliente") = Nothing Then
                    If Me.cmbCONTRIBUYENTE.Text = "(No Definido)" Then
                        MsgBox("Debe definir un tipo de contribuyente para proceder.", MsgBoxStyle.Exclamation, "Mensaje")
                        Me.cmbCONTRIBUYENTE.Focus()
                    Else
                        mttoClientes(Compañia, Trim(Me.txtCliente.Text), Trim(Me.txtNombreCliente.Text), Trim(Me.txtDireccionCliente.Text), Trim(Me.txtTelCliente.Text), Trim(Me.txtFaxCliente.Text), Trim(Me.txtDuiCliente.Text), Trim(Me.txtNitCliente.Text), Me.cmbTIPO_CLIENTE.SelectedValue, Me.cmbCONTRIBUYENTE.SelectedValue, Trim(Me.txtRegFiscal.Text), Trim(Me.txtGiro.Text), Me.chkExento.CheckState, ClientExterno, "U", 1)
                        If Me.txtLinea.Text <> Nothing Or Me.txtLinea.Text <> "0" And Me.lblFactSiNo.Text <> "" Or Me.lblFactSiNo.Text <> "ORDEN FACTURADA" Then
                            If Me.dgvDetalleFact.RowCount <> 0 Then
                                cargaTotales()
                            End If
                        End If
                    End If
                End If
            Else
                MsgBox("No hay datos del cliente para actualizar", MsgBoxStyle.Information, "Mensaje")
            End If
        End If
    End Sub

    'En caso haya algún combobox, éste método lo válida, si devuelve un valor que no sea null, no permitirá ninguna operación.
    Private Function valCMB(ByVal sector As GroupBox, ByVal sn As Integer)
        'Para indicar que debe poner una unidad de medida
        Dim um As String = ""
        'Combobox de Datos Generales
        Dim combosVacios As String = ""
        If Compañia = Nothing Then
            combosVacios = vbCrLf & "Compañia"
        End If
        If Me.cmbBODEGA.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Bodega"
        End If
        'Combobox de datos del cliente
        If sector.Name = "gbDC" Then
            If Me.cmbTIPO_CLIENTE.SelectedValue = Nothing Then
                combosVacios &= vbCrLf & "Tipo Cliente"
            End If
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = Nothing Then
                combosVacios &= vbCrLf & "Tipo Documento"
            End If
            If Me.cmbFORMA_PAGO.SelectedValue = Nothing Then
                combosVacios &= vbCrLf & "Forma Pago"
            End If
            If Me.cmbCONDICION_PAGO.SelectedValue = Nothing Then
                combosVacios &= vbCrLf & "Condición Pago"
            End If
        End If
        'Combobox de detalle factura
        If sector.Name <> "gbDC" And sector.Name <> "gbGF" Then
            If Me.cmbUNIDAD_MEDIDA.SelectedValue = Nothing And Me.cmbUNIDAD_MEDIDA.Text <> "(Sin Definir)" Then
                combosVacios &= vbCrLf & "Unidad de Medida"
            End If
        End If
        'Compilador de mensajes
        If combosVacios <> Nothing And sn = 1 Then
            MsgBox("No se puede continuar con la operacion debido a" & vbCrLf & "la falta de información en los siguientes campos: " & combosVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return combosVacios
    End Function

    'Valida los campos para los datos del cliente y contactos del cliente
    Private Function valCamposVacios(ByVal tipoCliente As ComboBox, ByVal nombre As String, ByVal tipo As String)
        'DECLARACION DE VARIABLES
        'Para el MsgBox
        Dim camposVacios As String = ""
        'Para el nombre
        Dim nombreVacio As String = ""
        'Para el Tipo de Cliente
        Dim nombreTipoCliente As String = ""
        'Para los campos necesarios acorde a tipo de cliente
        Dim camposVaciosTipoCliente As String = ""

        'Validación de los campos acorde al tipo de cliente.
        'Sólo para el formulario del Cliente, no para el contacto del cliente.
        If tipo = "Cliente" Then
            If Trim(Me.txtDuiCliente.Text).Replace("-", "").Length = 0 Or Trim(Me.txtNitCliente.Text).Replace("-", "").Length = 0 Or Me.txtRegFiscal.Text.Replace("-", "").Length = 0 Or Me.txtGiro.Text.Replace("-", "").Length = 0 Then
                'Si es persona natural
                If tipoCliente.SelectedValue = 1 Then
                    'DUI
                    If Trim(Me.txtDuiCliente.Text).Replace("-", "").Length = 0 Then
                        camposVaciosTipoCliente &= vbCrLf & "DUI"
                    End If
                End If
                'Para ambos tipos de clientes
                'NIT
                If Trim(Me.txtNitCliente.Text).Replace("-", "").Length = 0 Then
                    camposVaciosTipoCliente &= vbCrLf & "NIT"
                End If
                'Valida que valor remesa no este vacio si el pago es de contado
                If Val(Trim(Me.txtValRemesa.Text).Replace(",", "")) = 0 And Me.cmbFORMA_PAGO.SelectedValue = 1 And Not Me.chkSocio.Checked Then
                    camposVaciosTipoCliente &= vbCrLf & "Valor Remesa"
                End If
                'Valida que el saldo no sea menor que la factura si el pago es liquidacion
                If Val(Trim(Me.txtSaldoPend.Text).Replace(",", "")) < Val(Trim(Me.txtTotalFact.Text).Replace(",", "")) And Me.cmbFORMA_PAGO.SelectedValue = 3 And Not Me.chkSocio.Checked Then
                    If MsgBox("Valor Factura menor que saldo pendiente" & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.No Then
                        camposVaciosTipoCliente &= vbCrLf & "Saldo menor que factura... Verifique."
                    End If
                End If
                'Si es persona jurídica
                If tipoCliente.SelectedValue = 2 Then
                    'Registro Fiscal
                    If Trim(Me.txtRegFiscal.Text) = Nothing Then
                        camposVaciosTipoCliente &= vbCrLf & "Registro Fiscal"
                    End If
                    'Giro
                    If Trim(Me.txtGiro.Text) = Nothing Then
                        camposVaciosTipoCliente &= vbCrLf & "Giro"
                    End If
                End If
                'Si alguno de los campos anteriores no se ha llenado, se mostrara el siguiente mensaje previo
                If camposVaciosTipoCliente <> Nothing Then
                    'Mensaje Previo
                    nombreTipoCliente = vbCrLf & "Para el tipo de cliente "
                    nombreTipoCliente &= tipoCliente.Text
                    nombreTipoCliente &= ", se necesita completar: "
                End If
            End If
        End If

        If camposVaciosTipoCliente <> Nothing Or nombreVacio <> Nothing Then
            camposVacios = nombreVacio & nombreTipoCliente & camposVaciosTipoCliente
        End If

        'Mensaje de advertencia.
        If camposVacios <> Nothing Then
            MsgBox("Atención:" & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If

        Return camposVacios
    End Function

    'Evalua que si procesara un CCF y el tipo de cliente es natural deba tener registro fiscal y giro
    Private Function valTipoDocTipoCliente(ByVal tipoCliente As ComboBox, ByVal tipoDoc As ComboBox, ByVal reg As String, ByVal nit As String)
        Dim camposVacios As String = ""
        If tipoDoc.SelectedValue = 2 Then
            If Trim(reg) = Nothing Then
                camposVacios = vbCrLf & " - NRC"
            End If
            If Trim(nit) = Nothing Then
                camposVacios &= vbCrLf & " - NIT"
            End If
        Else
            camposVacios = Nothing
        End If
        If camposVacios <> Nothing Then
            MsgBox("Para procesar un CCF debe completar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    'Metodo para actualiar los datos de los clientes
    Private Sub mttoClientes(ByVal cia, ByVal cliente, ByVal nombre, ByVal dir, ByVal tel, ByVal fax, ByVal dui, ByVal nit, ByVal tipoCliente, ByVal contribuyente, ByVal nrc, ByVal giro, ByVal exento, ByVal origen, ByVal IUD, ByVal sn)
        Dim res As Integer = 0
        If cliente = Nothing Then
            cliente = 0
        End If
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES_IUD "
            sql &= cia
            sql &= ", " & cliente
            sql &= ", '" & nombre & "'"
            sql &= ", '" & dir & "'"
            sql &= ", '" & tel & "'"
            sql &= ", '" & fax & "'"
            sql &= ", '" & dui & "'"
            sql &= ", '" & nit & "'"
            sql &= ", " & tipoCliente
            sql &= ", " & contribuyente
            sql &= ", '" & nrc & "'"
            sql &= ", '" & giro & "'"
            sql &= ", " & exento
            sql &= ", " & origen
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                If sn = 1 Then
                    Select Case IUD
                        Case "U"
                            MsgBox("Datos Cliente actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    End Select
                ElseIf sn = 0 Then
                    NumProcess += 1
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Para guardar el detalle de las ordenes de venta
    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        'Declaracion de variables
        Try
            If valCamposVaciosDetalle() = String.Empty Then
                If Me.chkModif.Checked Then
                    Me.dgvDetalleFact.Rows.Remove(Me.dgvDetalleFact.CurrentRow)
                End If
                Me.dgvDetalleFact.Rows.Add(Val(Me.txtProducto.Text), Me.txtDescripcion.Text, Me.cmbUNIDAD_MEDIDA.Text, Me.txtCantidad.Text, Me.txtPrecio.Text, Math.Round(Val(Me.txtPrecio.Text) * Val(Me.txtCantidad.Text), 2, MidpointRounding.AwayFromZero), Me.txtLinea.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue)
                limpiaCamposDetalle()
                cargaTotales()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Llena el DataGridView de los detalles
    Private Sub cargaDetalles()
        Try
            While Me.dgvDetalleFact.Rows.Count > 0
                Me.dgvDetalleFact.Rows.RemoveAt(0)
            End While

            sql = "SELECT D.PRODUCTO, D.NOMBRE_PRODUCTO,U.DESCRIPCION_UNIDAD_MEDIDA AS UNIDAD_MEDIDA, D.CANTIDAD,D.PRECIO_UNITARIO, D.PRECIO_TOTAL, D.LINEA, D.UNIDAD_MEDIDA AS UM" & vbCrLf
            sql &= "  FROM FACTURACION_GENERADA_ENCABEZADO F, FACTURACION_GENERADA_DETALLE D, INVENTARIOS_CATALOGO_UNIDAD_MEDIDA U" & vbCrLf
            sql &= " WHERE F.COMPAÑIA = D.COMPAÑIA AND F.BODEGA = D.BODEGA AND F.NUMERO_FACTURA = D.NUMERO_FACTURA" & vbCrLf
            sql &= "   AND D.COMPAÑIA = U.COMPAÑIA AND D.UNIDAD_MEDIDA = U.UNIDAD_MEDIDA" & vbCrLf
            sql &= "   AND F.COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND F.BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            sql &= "   AND F.TIPO_DOCUMENTO = " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
            sql &= "   AND F.NUMERO_FACTURA = " & Me.txtNumFact.Text
            Table2 = jClass.obtenerDatos(New SqlCommand(sql))
            For Each row As DataRow In Table2.Rows
                Me.dgvDetalleFact.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7))
            Next
            cargaTotales()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Carga los subtotales y totales
    Private Sub cargaTotales()
        Dim TotalVta As Double
        Try
            For i As Integer = 0 To Me.dgvDetalleFact.Rows.Count - 1
                TotalVta += Me.dgvDetalleFact.Rows(i).Cells("VT").Value
            Next
            Me.txtSubTotal.Text = Format(TotalVta, "0.00")
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 And Not Me.chkExento.Checked Then
                Me.txtIVA.Text = Format(Math.Round(TotalVta * (porcIVA / 100), 2, MidpointRounding.AwayFromZero), "0.00")
            Else
                Me.txtIVA.Text = "0.00"
            End If
            Me.txtTotal.Text = Format(Val(Me.txtSubTotal.Text) + Val(Me.txtIVA.Text), "0.00")
            Me.txtTotalFact.Text = Me.txtTotal.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Valida los campos de los detalles de la factura
    Private Function valCamposVaciosDetalle() As String
        Dim camposVacios As String = String.Empty
        If Trim(Me.txtDescripcion.Text) = Nothing Then
            camposVacios &= vbCrLf & "Descripción"
        End If
        If Trim(Me.txtCantidad.Text) = Nothing Then
            camposVacios &= vbCrLf & "Cantidad"
        End If
        If Trim(Me.txtPrecio.Text) = Nothing Then
            camposVacios &= vbCrLf & "Precio Unitario"
        End If
        If Me.txtLibras.Enabled = True Then
            If Trim(Me.txtLibras.Text) = Nothing Then
                camposVacios &= vbCrLf & "Libras"
            End If
        End If
        If Me.cmbUNIDAD_MEDIDA.Text = "(Sin Definir)" Then
            camposVacios &= vbCrLf & "Debe definir una Unidad de Medida"
        End If
        If camposVacios <> Nothing Then
            MsgBox(camposVacios, MsgBoxStyle.Information, "Campos Vacios")
        End If
        Return camposVacios
    End Function

    'Genera Correlativo del Cliente
    Private Function generaCorrelativo(ByVal cia)
        Dim numOV As Integer
        Try
            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            sql &= cia
            sql &= ", 'OV'"
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

    'Limpia los campos de Datos Cliente
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Iniciando = True
        Me.txtLinea.Text = "0"
        Me.txtNumFact.Text = "0"
        Me.txtNoRemesa.Clear()
        Me.cmbBODEGA.Enabled = True
        limpiarCampos(Me.gbDC)
        Me.txtNombreFactura.Clear()
        Me.txtConcepto.Clear()
        If Me.tbContFact.SelectedIndex = 1 Then
            Me.tbContFact.SelectedIndex = 0
            multi.limpiargrid(Me.dgvDetalleFact)
            Me.tbContFact.SelectedIndex = 1
        Else
            multi.limpiargrid(Me.dgvDetalleFact)
        End If
        If Trim(Me.txtProducto.Text) <> Nothing Then
            Me.limpiaCamposDetalle()
        End If
        If Me.txtSubTotal.Text <> Nothing Then
            Me.txtSubTotal.Clear()
            Me.txtIVA.Clear()
            Me.txtTotal.Clear()
            Me.txtPercepcion.Clear()
            Me.txtTotalFact.Clear()
            Me.txtSubTotal.Text = "0.00"
            Me.txtIVA.Text = "0.00"
            Me.txtTotal.Text = "0.00"
            Me.txtPercepcion.Text = "0.00"
            Me.txtTotalFact.Text = "0.00"
        End If
        botonesEnable(True)
        IU = "I"
        Iniciando = False
        Me.lblFactSiNo.Text = "Documento Nuevo"
        cmbFORMA_PAGO_SelectedIndexChanged(New Object, New System.EventArgs)
        cmbTIPO_DOCUMENTO_SelectedIndexChanged(New Object, New System.EventArgs)
    End Sub

    'Carga los detalles de las facturas/ordenes de venta
    Private Sub dgvDetalleFact_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleFact.CellClick
        If e.RowIndex = -1 Then
            Return
        Else
            Try
                Me.txtProducto.Text = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("CodProd").Value
                Me.txtDescripcion.Text = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("nomProd").Value
                Me.cmbUNIDAD_MEDIDA.SelectedValue = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("UM").Value
                Me.txtCantidad.Text = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("CantidadProd").Value
                Me.txtPrecio.Text = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("PU").Value
                Me.txtLinea.Text = Me.dgvDetalleFact.Rows(e.RowIndex).Cells("LineaDetalle").Value
                Me.chkModif.Checked = True
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    'Valida los campos de la Orden de Venta
    Private Function valCamposOV()
        Dim camposVacios As String = ""
        If Trim(Me.txtNombreFactura.Text) = Nothing Then
            camposVacios = vbCrLf & "Nombre Factura"
        End If
        If Me.chkModif.CheckState = CheckState.Checked Then
            If Trim(Me.txtConcepto.Text) = Nothing Then
                camposVacios &= vbCrLf & "Concepto"
            End If
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe llenar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    'Mantenimiento de Orden de Ventas
    Private Sub mttoOV(ByVal cia, ByVal bodega, ByVal ov, ByVal fechaOV, ByVal tipoDoc, ByVal numFact, ByVal formaPago, ByVal condicionPago, ByVal cliente, ByVal tipoCliente, ByVal contribuyente, ByVal nomFact, ByVal dir, ByVal dui, ByVal nit, ByVal nrc, ByVal giro, ByVal exento, ByVal imprimirConcepto, ByVal concepto, ByVal origen, ByVal IUD, ByVal sn)
        Dim res As String = 0
        If numFact = Nothing Or numFact = 0 Then
            numFact = 0
        End If
        Dim fechaNumFact As Date = Now
        Dim observaciones As String = " "
        If numFact > 0 Then
            observaciones = "Factura No. " & numFact
        End If
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_FATURAS_ENCABEZADO_IUD "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & ov
            sql &= ", '" & Format(fechaOV, "Short Date") & "'"
            sql &= ", " & tipoDoc
            sql &= ", " & numFact
            sql &= ", '" & Format(fechaNumFact, "Short Date") & "'"
            sql &= ", " & formaPago
            sql &= ", " & condicionPago
            sql &= ", " & cliente
            sql &= ", 0" 'CODIGO BUXIS
            sql &= ", 0" 'CODIGO SOCIO
            sql &= ", " & tipoCliente
            sql &= ", " & contribuyente
            sql &= ", '" & nomFact & "'"
            sql &= ", '" & dir & "'"
            sql &= ", '" & dui & "'"
            sql &= ", '" & nit & "'"
            sql &= ", '" & nrc & "'"
            sql &= ", '" & giro & "'"
            sql &= ", " & exento
            sql &= ", " & imprimirConcepto
            sql &= ", '" & concepto & "'"
            sql &= ", '" & observaciones & "'"
            sql &= ", " & origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & IUD & "'"
            sql &= ", ''" 'PERIODO PAGO
            sql &= ", 0" 'CUOTAS
            sql &= ", 0" 'DESCONTAR DESDE
            sql &= ", 0" 'DESCUENTO AGUINALDO
            sql &= ", 0" 'DESCUENTO BONIFICACION
            sql &= ", '" & Me.txtNoRemesa.Text & "'" 'NUMERO REMESA
            sql &= ", " & IIf(formaPago = 1, Me.cmbBancos.SelectedValue, 0)
            sql &= ", '" & IIf(formaPago = 1, Me.cmbCtasBanco.SelectedValue, "") & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                If sn = 1 Then
                    Select Case IUD
                        Case "I"
                            MsgBox("Orden de Venta almacenada con éxito", MsgBoxStyle.Information, "Mensaje")
                        Case "U"
                            MsgBox("Orden de Venta actualizada con éxito", MsgBoxStyle.Information, "Mensaje")
                        Case "D"
                            MsgBox("Orden de Venta eliminada con éxito", MsgBoxStyle.Information, "Mensaje")
                    End Select
                ElseIf sn = 0 Then
                    NumProcess += 1
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Habilita o no los botones especificados en caso la orden este procesada o no
    Private Sub botonesEnable(ByVal flag As Boolean)
        Me.btnActualizarCliente.Enabled = flag
        Me.btnBuscarCliente.Enabled = flag
        Me.btnBuscarProducto.Enabled = flag
        Me.btnGuardarDetalle.Enabled = flag
        Me.btnEliminarDetFact.Enabled = flag
        Me.btnLimpiarDetalle.Enabled = flag
        Me.btnGenerar.Enabled = flag
    End Sub


    'Metodo de cambio de indice de combobox Forma de Pago
    Private Sub cmbFORMA_PAGO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFORMA_PAGO.SelectedIndexChanged
        If Iniciando = False Then
            multi.CargaCondicionPago(Compañia, Me.cmbFORMA_PAGO.SelectedValue, Me.cmbCONDICION_PAGO)
            If Me.cmbFORMA_PAGO.SelectedValue = 1 Then
                Me.txtNoRemesa.Enabled = True
                Me.cmbBancos.Enabled = True
                Me.cmbCtasBanco.Enabled = True
                Me.txtValRemesa.Enabled = True
                Me.Label5.Visible = False
                Me.txtSaldoPend.Visible = False
            Else
                Me.txtNoRemesa.Enabled = False
                Me.cmbBancos.Enabled = False
                Me.cmbCtasBanco.Enabled = False
                Me.txtValRemesa.Enabled = False
                Me.Label5.Visible = True
                Me.txtSaldoPend.Visible = True
            End If
        End If
    End Sub

    'Metodo de cambio de indice de combobox Bodega
    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            Try
                CentCost = jClass.obtenerEscalar("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Centro Costo Bodega")
            End Try
        End If
    End Sub

    'Cuando se cambia el valor del tipo de documento
    Private Sub cmbTIPO_DOCUMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_DOCUMENTO.SelectedIndexChanged
        If Iniciando = False Then
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Then
                Me.Label59.Text = "Nº FACT:"
            Else
                Me.Label59.Text = "Nº CCF:"
            End If
            cargaTotales()
        End If
    End Sub

    'Para eliminar un detalle
    Private Sub btnEliminarDetFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDetFact.Click
        If MsgBox("¿Está seguro(a) que desea eliminar el detalle seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.dgvDetalleFact.Rows.Remove(Me.dgvDetalleFact.CurrentRow)
            sql = "DELETE FROM FACTURACION_GENERADA_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA = " & Me.txtNumFact.Text & " AND LINEA = " & Me.txtLinea.Text
            jClass.ejecutarComandoSql(New SqlCommand(sql))
            limpiaCamposDetalle()
        Else
            MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    'Metodo del boton de limpieza
    Private Sub btnLimpiarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarDetalle.Click
        limpiaCamposDetalle()
    End Sub

    'Genera la factura
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim IUD As String = ""
        Dim NumFactGenerado As Integer = 0
        Dim CtaContable As Integer = 0
        If VerificarPeriodo() Then
            Return
        End If
        If Me.cmbFORMA_PAGO.SelectedValue = 2 And Val(Me.txtCliente.Text) = 0 Then
            MsgBox("No se puede elegir Crédito como forma de pago," & vbCrLf & "Debe eligir un cliente del Catálogo.", MsgBoxStyle.Information, "Forma de Pago")
            Me.cmbFORMA_PAGO.Focus()
            Return
        End If
        'sql = "SELECT COUNT(NUMERO_FACTURA) FROM [FACTURACION_GENERADA_ENCABEZADO] WHERE COMPAÑIA = " & Compañia & " AND TIPO_DOCUMENTO = " & Me.cmbTIPO_DOCUMENTO.SelectedValue & " AND NUMERO_FACTURA = " & Me.txtNumFact.Text
        'Numero = jClass.obtenerEscalar(sql)
        'If Numero > 0 Then
        '    MsgBox("No se puede continuar ya existe " & vbCrLf & Me.cmbTIPO_DOCUMENTO.Text & " No. " & Me.txtNumFact.Text, MsgBoxStyle.Information, "Numero Duplicado")
        '    Return
        'End If
        NumProcess = 0
        'Evalua que el tipo
        If valTipoDocTipoCliente(Me.cmbTIPO_CLIENTE, Me.cmbTIPO_DOCUMENTO, Me.txtRegFiscal.Text, Me.txtNitCliente.Text) = Nothing Then
            If Me.dgvDetalleFact.Rows.Count = 0 Then
                MsgBox("Debe detallar la factura para poder generarla", MsgBoxStyle.Information, "Mensaje")
            Else
                If Me.txtNumFact.Text.Length = 0 Then
                    MsgBox("Ingrese un número de factura válido", MsgBoxStyle.Information, "Mensaje")
                Else
                    'Evalua que los campos del cliente no esten vacios
                    If valCamposVacios(Me.cmbTIPO_CLIENTE, Trim(Me.txtNombreCliente.Text), "Cliente") = Nothing And valCamposOV() = Nothing Then
                        'Evalua que los campos de los totales esten generados
                        NumFactGenerado = Val(Me.txtNumFact.Text)
                        'Inician las inserciones
                        IUD = IU
                        'Llena el Encabezado de la Factura Generada
                        If IU = "I" Then
                            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS " & Compañia & ", 'OV', 0"
                            Numero_OV = jClass.obtenerEscalar(sql)
                        End If
                        procesaFacturaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, Numero_OV, NumFactGenerado _
                                                 , Me.txtNombreFactura.Text, Val(Me.txtCliente.Text), 0, CentCost, Me.cmbTIPO_DOCUMENTO.SelectedValue _
                                                 , IIf(Me.cmbFORMA_PAGO.SelectedValue = 3, 2, Me.cmbFORMA_PAGO.SelectedValue) _
                                                 , IIf(Me.cmbFORMA_PAGO.SelectedValue = 3, 1, Me.cmbCONDICION_PAGO.SelectedValue) _
                                                 , Me.cmbCONTRIBUYENTE.SelectedValue, Me.txtDuiCliente.Text _
                                                 , Me.txtNitCliente.Text, Me.txtRegFiscal.Text, Me.chkExento.CheckState, Me.chkModif.CheckState, Me.txtConcepto.Text _
                                                 , Me.txtSubTotal.Text, Me.txtIVA.Text, Me.txtTotal.Text, Me.txtPercepcion.Text, Me.txtTotalFact.Text, 0, IIf(Me.chkSocio.Checked, Origen, ClientExterno), IUD, 0)
                        'Llena el Detalle de la Factura Generada
                        procesaFacturaDetalle(Compañia, Me.cmbBODEGA.SelectedValue, Me.txtLinea.Text, NumFactGenerado, IUD, 0, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.chkExento.Checked)
                        'Me.lblFactSiNo.Text = ""
                        'Me.botonesEnable(False)
                        If NumProcess >= 4 Then
                            'Actualizar bandera de impreso para la factura o CCF
                            Dim sqlCmd As New SqlCommand
                            sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET FACTURA_IMPRESA = 1"
                            sql &= " WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue & " AND ORDEN_VENTA= " & Numero_OV
                            sql &= " AND TIPO_DOCUMENTO=" & Me.cmbTIPO_DOCUMENTO.SelectedValue & " AND NUMERO_FACTURA=" & Me.txtNumFact.Text
                            sqlCmd.CommandText = sql
                            jClass.ejecutarComandoSql(sqlCmd)
                            MsgBox(Me.cmbTIPO_DOCUMENTO.Text & " #" & Me.txtNumFact.Text & " guardada correctamente.", MsgBoxStyle.Information, "Resultado")
                        ElseIf NumProcess = 1 Then
                            MsgBox("¡Ocurrieron errores durante el proceso de Contabilización!" & vbCrLf & "Algunos procesos no se realizaron correctamente, verifique.", MsgBoxStyle.Exclamation, "Error Detalles")
                        ElseIf NumProcess = 0 Then
                            MsgBox("¡Ocurrieron errores durante el proceso de facturación!" & vbCrLf & "Algunos procesos no se realizaron correctamente, verifique.", MsgBoxStyle.Exclamation, "Error Partida")
                        Else
                            MsgBox("¡Ocurrieron errores durante el proceso de facturación!" & vbCrLf & "Algunos procesos no se realizaron correctamente, verifique.", MsgBoxStyle.Exclamation, "Error Desconocido")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    'Evalua si se han procesado los totales
    Private Function valTotales()
        Dim camposVacios As String = ""
        If Me.txtSubTotal.Text = "0.00" Then
            camposVacios = vbCrLf & "Subtotal"
        End If
        If Me.chkExento.CheckState = 0 And Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
            If Me.txtIVA.Text = "0.00" Then
                camposVacios &= vbCrLf & "IVA"
            End If
        End If
        If Me.txtTotal.Text = "0.00" Then
            camposVacios &= vbCrLf & "Total"
        End If
        If Me.txtTotalFact.Text = "0.00" Then
            camposVacios &= vbCrLf & "Total Factura"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Para procesar la factura deben" & vbCrLf & "generarse los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    'Metodo para llenar el encabezado de la factura generada
    Private Sub procesaFacturaEncabezado(ByVal cia As Integer, ByVal bodega As Integer, ByVal ov As Integer, ByVal numFact As Integer, ByVal nomFact As String, ByVal cliente As Integer, ByVal serie As Integer, ByVal centroCosto As Integer, ByVal tipoDoc As Integer, ByVal formaPago As Integer, ByVal condicionPago As Integer, ByVal contribuyente As Integer, ByVal dui As String, ByVal nit As String, ByVal nrc As String, ByVal exento As Boolean, ByVal imprimir As Integer, ByVal concepto As String, ByVal subtotal As Double, ByVal iva As Double, ByVal total As Double, ByVal percepcion As Double, ByVal totalFact As Double, ByVal anulada As Integer, ByVal origen As Integer, ByVal IUD As String, ByVal sn As Integer)
        Dim res As Integer = 0
        Dim codAS As String
        Dim fechaNumFact As Date = Me.dpFECHA_OV.Value.Date
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            'sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS " & Compañia & ", 'OV', 0"
            'ov = jClass.obtenerEscalar(sql)
            'Numero_OV = ov
            If Me.chkSocio.Checked Then
                codAS = jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Val(Me.txtCliente.Text)).ToString()
            Else
                codAS = "0"
            End If
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & ov
            sql &= ", " & numFact
            sql &= ", '" & nomFact & "'"
            sql &= ", '" & Format(Me.dpFECHA_OV.Value, "dd/MM/yyyy") & "'"
            sql &= ", " & IIf(Me.chkSocio.Checked, 0, Val(Me.txtCliente.Text))
            sql &= ", " & serie
            sql &= ", " & centroCosto
            sql &= ", " & tipoDoc
            sql &= ", " & formaPago
            sql &= ", 'MM'" 'PERIODO PAGO
            sql &= ", " & condicionPago
            sql &= ", " & IIf(Me.chkSocio.Checked, Val(Me.txtCliente.Text), 0) 'Codigo Buxis
            sql &= ", '" & codAS & "'" 'Codigo Socio AS
            sql &= ", " & contribuyente
            sql &= ", '" & dui & "'"
            sql &= ", '" & nit & "'"
            sql &= ", '" & nrc & "'"
            sql &= ", " & exento
            sql &= ", " & imprimir
            sql &= ", '" & concepto & "'"
            sql &= ", " & subtotal
            sql &= ", " & porcIVA ' % iva
            sql &= ", " & iva 'TOTAL IVA
            sql &= ", " & percepcion
            sql &= ", " & totalFact
            sql &= ", 0" 'Cuotas
            sql &= ", 0" 'descontar Desde
            sql &= ", 0" '& Descuento Aguinaldo
            sql &= ", 0" '& Descuento Bonificacion
            sql &= ", '" & Me.txtNoRemesa.Text & "'" '& Numero Remesa
            sql &= ", " & anulada
            sql &= ", " & origen
            sql &= ", " & Usuario
            sql &= ", " & IU
            sql &= ", " & IIf(formaPago = 1, Me.cmbBancos.SelectedValue, 0)
            sql &= ", '" & IIf(formaPago = 1, Me.cmbCtasBanco.SelectedValue, "") & "'"
            sql &= ", '" & Format(Now, "dd/MM/yyyy") & "'" '@ORDEN_VENTA_FECHA DA
            sql &= ", '" & Format(Now, "dd/MM/yyyy") & "'" '@NUMERO_FACTURA_FECHA
            sql &= ", " & Me.cmbTIPO_CLIENTE.SelectedValue '@TIPO_CLIENTE INT,
            sql &= ", " & Me.cmbCONTRIBUYENTE.SelectedValue '@TIPO_CONTRIBUYENTE I
            sql &= ", '" & Me.txtDireccionCliente.Text & "'" '@DIRECCION NVARCHAR(2
            sql &= ", '" & Me.txtGiro.Text & "'"  '@GIRO NVARCHAR(150),
            sql &= ", 'Facturacion Libre'"  '@OBSERVACIONES NVARCHAR
            sql &= ", 0" '@CAJA INT=NULL
            sql &= ", " & Val(Me.txtValRemesa.Text) '@VALOR_REMESA NUMERIC(18,2)
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res > 0 Then
                If Val(Me.txtCliente.Text) > 0 And Not Me.chkSocio.Checked Then
                    If Me.cmbFORMA_PAGO.SelectedValue = 1 And Val(Me.txtValRemesa.Text) > Val(Me.txtTotalFact.Text) Then
                        sql = "EXECUTE [dbo].[sp_FACTURACION_ABONOS_IUD]"
                        sql &= "	 @COMPAÑIA      = " & Compañia & vbCrLf
                        sql &= "	,@BODEGA        = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                        sql &= "	,@ORDEN_VENTA   = 0" & vbCrLf
                        sql &= "	,@NUMERO_FACTURA= " & Me.txtNumFact.Text & vbCrLf
                        sql &= "	,@CLIENTE       = " & Me.txtCliente.Text & vbCrLf
                        sql &= "	,@TIPO_DOCUMENTO= " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
                        sql &= "	,@FORMA_PAGO    = " & Me.cmbFORMA_PAGO.SelectedValue & vbCrLf
                        sql &= "	,@NUMERO_REMESA = '" & Me.txtNoRemesa.Text & "'" & vbCrLf
                        sql &= "	,@CARGO         = 0.0" & vbCrLf
                        sql &= "	,@ABONO         = " & Val(Me.txtValRemesa.Text) & vbCrLf
                        sql &= "	,@FECHA_CONTABLE= '" & Format(Me.dpFECHA_OV.Value, "dd/MM/yyyy") & "'" & vbCrLf
                        sql &= "	,@CONCEPTO      = 'Remesa No." & Me.txtNoRemesa.Text & " (" & Me.cmbBODEGA.Text & ")'" & vbCrLf
                        sql &= "	,@USUARIO       = '" & Usuario & "'" & vbCrLf
                        sql &= "	,@IUD           = '" & IUD & "'" & vbCrLf
                        Comando_.CommandText = sql
                        res = Comando_.ExecuteNonQuery()
                    End If
                    If Me.cmbFORMA_PAGO.SelectedValue = 3 Or (Me.cmbFORMA_PAGO.SelectedValue = 1 And Val(Me.txtValRemesa.Text) > Val(Me.txtTotalFact.Text)) Then
                        sql = "EXECUTE [dbo].[sp_FACTURACION_ABONOS_IUD]"
                        sql &= "	 @COMPAÑIA      = " & Compañia & vbCrLf
                        sql &= "	,@BODEGA        = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                        sql &= "	,@ORDEN_VENTA   = " & ov & vbCrLf
                        sql &= "	,@NUMERO_FACTURA= " & Me.txtNumFact.Text & vbCrLf
                        sql &= "	,@CLIENTE       = " & Me.txtCliente.Text & vbCrLf
                        sql &= "	,@TIPO_DOCUMENTO= " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
                        sql &= "	,@FORMA_PAGO    = " & Me.cmbFORMA_PAGO.SelectedValue & vbCrLf
                        sql &= "	,@NUMERO_REMESA = '" & Me.txtNoRemesa.Text & "'" & vbCrLf
                        sql &= "	,@CARGO         = " & Me.txtTotalFact.Text & vbCrLf
                        sql &= "	,@ABONO         = 0.0" & vbCrLf
                        sql &= "	,@FECHA_CONTABLE= '" & Format(Me.dpFECHA_OV.Value, "dd/MM/yyyy") & "'" & vbCrLf
                        sql &= "	,@CONCEPTO      = '" & Me.cmbTIPO_DOCUMENTO.Text & " No." & Me.txtNumFact.Text & " (" & Me.cmbBODEGA.Text & ") " & IIf(Me.cmbFORMA_PAGO.SelectedValue = 1, "Remesa No." & Me.txtNoRemesa.Text, Me.cmbFORMA_PAGO.Text) & "'" & vbCrLf
                        sql &= "	,@USUARIO       = '" & Usuario & "'" & vbCrLf
                        sql &= "	,@IUD           = '" & IUD & "'" & vbCrLf
                        Comando_.CommandText = sql
                        res = Comando_.ExecuteNonQuery()
                    End If
                End If
                If sn = 1 Then
                    Select Case IUD
                        Case "I"
                            MsgBox("Encabezado de Factura almacenado con éxito", MsgBoxStyle.Information, "Mensaje")
                            IU = "U"
                        Case "U"
                            MsgBox("Encabezado de Factura actualizado con éxito", MsgBoxStyle.Information, "Mensaje")
                        Case "D"
                            MsgBox("Encabezado de Factura eliminado con éxito", MsgBoxStyle.Information, "Mensaje")
                    End Select
                ElseIf sn = 0 Then
                    NumProcess += 1
                    IU = "U"
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Metodo para llenar el encabezado de la factura generada
    Private Sub procesaFacturaDetalle(ByVal cia As Integer, ByVal bodega As Integer, ByVal ov As Integer, ByVal numFact As Integer, ByVal IUD As String, ByVal sn As Integer, ByVal TipDoc As Integer, ByVal Exento As Boolean)
        Dim res As Integer = 0
        Dim sqlCmd As New SqlCommand
        Try
            For Each row As DataGridViewRow In Me.dgvDetalleFact.Rows
                sql = " Execute sp_FACTURACION_GENERADA_DETALLE_IUD "
                sql &= Compañia
                sql &= ", " & Me.cmbBODEGA.SelectedValue
                sql &= ", " & Numero_OV
                sql &= ", " & TipDoc
                sql &= ", " & numFact
                sql &= ", " & row.Cells("LineaDetalle").Value
                sql &= ", " & row.Cells("CodProd").Value
                sql &= ", '" & row.Cells("nomProd").Value & "'"
                sql &= ", " & row.Cells("UM").Value
                sql &= ", " & row.Cells("CantidadProd").Value
                sql &= ", 0" 'libras
                sql &= ", 0" 'Costo Unitario
                sql &= ", 0" 'Costo Total
                sql &= ", " & row.Cells("PU").Value
                sql &= ", " & row.Cells("VT").Value
                sql &= ", 0" 'Grupo
                sql &= ", 0" 'Subgrupo
                sql &= ", " & IIf(Me.chkSocio.Checked, Origen, ClientExterno) 'Origen
                sql &= ", '" & Usuario & "'"
                sql &= ", '" & IIf(CInt(row.Cells("LineaDetalle").Value) = 0, "I", "U") & "'"
                sql &= ",0" '@PORCDESCTO
                sql &= ",0" '@DESCUENTO
                sqlCmd.CommandText = sql
                res += jClass.ejecutarComandoSql(sqlCmd)
            Next
            If res > 0 Then
                If sn = 1 Then
                    Select Case IUD
                        Case "I"
                            MsgBox("Detalles de Factura almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                        Case "U"
                            MsgBox("Detalles de Factura actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                        Case "D"
                            MsgBox("Detalles de Factura eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                    End Select
                ElseIf sn = 0 Then
                    NumProcess = 4
                End If
            Else
                NumProcess = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub CargaEncabezado()
        Dim TableFactEnc As DataTable
        Try
            Comando_ = New SqlCommand("SELECT * FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND NUMERO_FACTURA = " & Me.txtNumFact.Text & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue)
            TableFactEnc = jClass.obtenerDatos(Comando_)
            If TableFactEnc.Rows.Count > 0 Then
                Me.lblFactSiNo.Text = "Listo para Modificar"
                Numero_OV = TableFactEnc.Rows(0).Item("ORDEN_VENTA")
                Me.txtCliente.Text = TableFactEnc.Rows(0).Item("CLIENTE")
                Me.txtNombreCliente.Text = IIf(TableFactEnc.Rows(0).Item("CLIENTE") = 0, "CLIENTE NO REGISTRADO", jClass.obtenerEscalar("SELECT * FROM CONTABILIDAD_CATALOGO_CLIENTES WHERE COMPAÑIA = " & Compañia & " AND CLIENTE = " & TableFactEnc.Rows(0).Item("CLIENTE")))
                Me.txtDireccionCliente.Text = TableFactEnc.Rows(0).Item("DIRECCION")
                Me.txtDuiCliente.Text = TableFactEnc.Rows(0).Item("DUI")
                Me.txtNitCliente.Text = TableFactEnc.Rows(0).Item("NIT")
                Me.txtRegFiscal.Text = TableFactEnc.Rows(0).Item("NRC")
                Me.txtGiro.Text = TableFactEnc.Rows(0).Item("GIRO")
                Me.txtNombreFactura.Text = TableFactEnc.Rows(0).Item("NOMBRE_FACTURA")
                Me.txtConcepto.Text = TableFactEnc.Rows(0).Item("CONCEPTO")
                Me.cmbTIPO_CLIENTE.SelectedValue = TableFactEnc.Rows(0).Item("TIPO_CLIENTE")
                Me.cmbCONTRIBUYENTE.SelectedValue = TableFactEnc.Rows(0).Item("TIPO_CONTRIBUYENTE")
                Me.cmbTIPO_DOCUMENTO.SelectedValue = TableFactEnc.Rows(0).Item("TIPO_DOCUMENTO")
                Me.cmbFORMA_PAGO.SelectedValue = TableFactEnc.Rows(0).Item("FORMA_PAGO")
                Me.cmbCONDICION_PAGO.SelectedValue = TableFactEnc.Rows(0).Item("CONDICION_PAGO")
                Me.chkExento.Checked = TableFactEnc.Rows(0).Item("EXENTO")
                Me.dpFECHA_OV.Value = TableFactEnc.Rows(0).Item("FECHA_FACTURA")
                Me.txtNoRemesa.Text = TableFactEnc.Rows(0).Item("NUMERO_REMESA")
                Me.txtValRemesa.Text = TableFactEnc.Rows(0).Item("VALOR_REMESA")
                If TableFactEnc.Rows(0).Item("FORMA_PAGO") = 1 Then
                    Me.cmbBancos.SelectedValue = TableFactEnc.Rows(0).Item("BANCO_REMESA")
                    Me.cmbCtasBanco.SelectedValue = TableFactEnc.Rows(0).Item("CUENTA_BANCO_REMESA")
                End If
                IU = "U"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Encabezado")
        End Try
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

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        If Me.chkSocio.Checked Then
            datosSocio(Val(Me.txtCliente.Text), Val(Me.txtCliente.Text))
        Else
            datosCliente()
        End If
    End Sub

    Private Sub bntImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntImprimir.Click
        If Val(Me.txtNumFact.Text) > 0 And IU = "U" And Me.dgvDetalleFact.Rows.Count > 0 Then
            Dim rpt As New Contabilidad_CuentasxCobrar_Facturacion_RPT
            rpt.Municipio = 4
            rpt.Depto = 8
            rpt.Pais = 1
            rpt.cia = Compañia
            rpt.bodega = Me.cmbBODEGA.SelectedValue
            rpt.ov = CInt(Me.txtLinea.Text)
            rpt.factura = Me.txtNumFact.Text
            rpt.tipoDoc = Me.cmbTIPO_DOCUMENTO.SelectedValue
            rpt.totalFact = Val(Me.txtTotal.Text)
            rpt.flag = 1
            rpt.Multiple = False
            rpt.ShowDialog()
        End If
    End Sub

    Public Function DevuelveConstante(ByVal Constante As Integer) As Double
        Dim Retorno As Double
        sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = " & Constante
        Retorno = jClass.obtenerEscalar(sql)
        If Retorno = Nothing Then
            Retorno = 0
        End If
        Return Retorno
    End Function

    Private Sub txtNumFact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFact.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumFact_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumFact.LostFocus
        If Val(Me.txtNumFact.Text) > 0 Then
            CargaEncabezado()
            cargaDetalles()
        End If
    End Sub

    Private Sub chkSocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSocio.CheckedChanged
        If chkSocio.Checked Then
            multi.CargaFormaPago(Compañia, Me.cmbFORMA_PAGO)
            Label8.Text = "Cod. Buxis:"
            Me.cmbFORMA_PAGO.SelectedValue = 2
            Me.Label5.Visible = False
            Me.txtSaldoPend.Visible = False
        Else
            FormaPago()
            Label8.Text = "Cliente :"
            Me.cmbFORMA_PAGO.SelectedValue = 1
            Me.Label5.Visible = True
            Me.txtSaldoPend.Visible = True
        End If
    End Sub

    Private Sub txtValRemesa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValRemesa.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtDescripcion.Focus()
        End If
        multi.soloNumerosPuntos(e)
    End Sub

    Private Sub btnElimFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElimFact.Click
        If MsgBox(Me.cmbTIPO_DOCUMENTO.Text & " No." & Me.txtNumFact.Text & " se eliminará completamente." & vbCrLf & vbCrLf & "¿Confirma que desea continuar?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            sql = "DELETE FROM FACTURACION_GENERADA_DETALLE WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND ORDEN_VENTA = " & Numero_OV & " AND NUMERO_FACTURA = " & Me.txtNumFact.Text & " AND TIPO_DOCUMENTO = " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
            sql &= "GO" & vbCrLf
            sql &= "DELETE FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND ORDEN_VENTA = " & Numero_OV & " AND NUMERO_FACTURA = " & Me.txtNumFact.Text & " AND TIPO_DOCUMENTO = " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
            sql &= "GO" & vbCrLf
            If jClass.ejecutarComandoSql(New SqlCommand(sql)) > 0 Then
                sql = "EXECUTE [dbo].[sp_FACTURACION_ABONOS_IUD]"
                sql &= "	 @COMPAÑIA      = " & Compañia & vbCrLf
                sql &= "	,@BODEGA        = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                sql &= "	,@ORDEN_VENTA   = " & Numero_OV & vbCrLf
                sql &= "	,@NUMERO_FACTURA= " & Me.txtNumFact.Text & vbCrLf
                sql &= "	,@CLIENTE       = " & Me.txtCliente.Text & vbCrLf
                sql &= "	,@TIPO_DOCUMENTO= " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
                sql &= "	,@FORMA_PAGO    = " & Me.cmbFORMA_PAGO.SelectedValue & vbCrLf
                sql &= "	,@NUMERO_REMESA = 'ELIMINAR'" & vbCrLf
                sql &= "	,@CARGO         = 0.0" & vbCrLf
                sql &= "	,@ABONO         = 0.0" & vbCrLf
                sql &= "	,@FECHA_CONTABLE= '" & Format(Me.dpFECHA_OV.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "	,@CONCEPTO      = 'Remesa No." & Me.txtNoRemesa.Text & " (" & Me.cmbBODEGA.Text & ")'" & vbCrLf
                sql &= "	,@USUARIO       = '" & Usuario & "'" & vbCrLf
                sql &= "	,@IUD           = 'D'" & vbCrLf
                jClass.ejecutarComandoSql(New SqlCommand(sql))
                MsgBox(Me.cmbTIPO_DOCUMENTO.Text & " No." & Me.txtNumFact.Text & " se eliminó correctamente.", MsgBoxStyle.Information, "Resultado")
                Me.btnNuevo.PerformClick()
            Else
                MsgBox(Me.cmbTIPO_DOCUMENTO.Text & " No." & Me.txtNumFact.Text & " no se pudo eliminar.", MsgBoxStyle.Information, "Resultado")
            End If
        End If
    End Sub

    Private Function VerificarPeriodo() As Boolean
        Dim periodo_cerrado As Integer
        Dim resultado As Boolean = False
        periodo_cerrado = jClass.obtenerEscalar("SELECT COUNT(COMPAÑIA) FROM FACTURACION_MANUAL_LIBRO_VENTAS WHERE COMPAÑIA = " & Compañia & " AND MONTH(FECHA_FACTURA) = " & Me.dpFECHA_OV.Value.Month.ToString() & " AND YEAR(FECHA_FACTURA) = " & Me.dpFECHA_OV.Value.Year.ToString() & " AND PERIODO_CERRADO = 1")
        If periodo_cerrado > 0 Then
            MsgBox("El período " & Format(Me.dpFECHA_OV.Value, "MMMM/yyyy") & " ya fue cerrado.", MsgBoxStyle.Information, "Validación Período")
            resultado = True
        End If
        Return resultado
    End Function
End Class