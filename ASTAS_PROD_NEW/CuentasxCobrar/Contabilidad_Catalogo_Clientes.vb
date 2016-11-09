Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Contabilidad_Catalogo_Clientes

    'Constructor
    Dim fill As New cmbFill

    'Declaracion de variables
    Dim sql As String = ""
    Dim Iniciando As Boolean

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As New SqlCommand
    Dim DataAdapter_ As New SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader
    Private validarNit As New ValidacionNit

    Private Sub Contabilidad_Catalogo_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaCMB()
        Iniciando = False
    End Sub

    'Al cambiar la compañía, cambian los demás ComboBox
    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            limpiaCampos(Me.gbDC)
            cargaCMB()
            fill.limpiargrid(Me.dgvContactos)
        End If
    End Sub

    'Botón Guardar de Datos Cliente
    Private Sub btnGuardarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCliente.Click
        If MsgBox("Seguro de Adicionar/Modificar datos del cliente?", MsgBoxStyle.YesNo, "ACTUALIZAR") = MsgBoxResult.Yes Then
            Dim IUD As String = ""
            Dim Existe As String = ""
            Dim ClieNit As String = ""
            If valCMB() = Nothing Then
                If valCamposVacios(Me.cmbTIPO_CLIENTE, Me.txtNombreCliente.Text, "Cliente") = Nothing Then
                    If Me.cmbCONTRIBUYENTE.Text = "(No Definido)" Then
                        MsgBox("Debe definir un tipo de contribuyente para proceder.", MsgBoxStyle.Exclamation, "Mensaje")
                        Me.cmbCONTRIBUYENTE.Focus()
                    Else
                        ClieNit = Me.txtNitCliente.Text.Replace("-", "").Trim
                        If ClieNit.Length > 0 Then
                            If Not Me.txtNitCliente.Text.Replace("-", "").Substring(ClieNit.Length - 1, 1).Equals(validarNit.Dig_Verf(IIf(Me.txtNitCliente.Text.Replace("-", "").Length = 14, Me.txtNitCliente.Text.Replace("-", ""), "-1"))) Then
                                MsgBox("Número de NIT NO válido." & vbCrLf & "Proceso Cancelado...", MsgBoxStyle.Exclamation, "Validación NIT")
                                Return
                            End If
                        Else
                            If Val(Me.txtCliente.Text) = 0 Then
                                If MsgBox("Número de NIT VACIO." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "Validación NIT") = MsgBoxResult.No Then
                                    Return
                                End If
                            End If
                        End If
                        If Trim(Me.txtCliente.Text) <> Nothing Then
                            IUD = "U"
                            Existe = ""
                        Else
                            IUD = "I"
                            If ClieNit.Length > 0 Then
                                Existe = Verifica_NIT_DUI_NRC(Me.cmbCOMPAÑIA.SelectedValue, Me.txtNitCliente.Text.Replace("-", ""), IIf(Trim(Me.txtDuiCliente.Text) = "-", "", Me.txtDuiCliente.Text), Me.txtRegFiscal.Text)
                            End If
                        End If
                        If Existe.Trim = "" Then
                            If (Me.txtCliente.Text = Nothing Or Me.txtCliente.Text = "0") Then
                                Me.txtCliente.Text = generaCorrelativo(Me.cmbCOMPAÑIA.SelectedValue)
                            End If
                            mttoClientes(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text, Me.txtNombreCliente.Text, Me.txtDirCliente.Text, Me.txtTelCliente.Text, Me.txtFaxCliente.Text, IIf(Trim(Me.txtDuiCliente.Text) = "-", "", Me.txtDuiCliente.Text), Me.txtNitCliente.Text, Me.cmbTIPO_CLIENTE.SelectedValue, Me.cmbCONTRIBUYENTE.SelectedValue, Me.txtRegFiscal.Text, Me.txtGiro.Text, Me.rbSi.Checked, Me.rbNo.Checked, Me.cmbORIGENES.SelectedValue, IUD)
                            If Me.txtContacto.Text <> Nothing Then
                                limpiaCampos(Me.gbCC)
                                fill.limpiargrid(Me.dgvContactos)
                            End If
                            cargarContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text)
                            If Trim(Me.txtCliente.Text) = Nothing Or Trim(Val(Me.txtCliente.Text)) = 0 Then
                                cargaCMB()
                            End If
                        Else
                            MsgBox("Ya Existe " & Trim(Existe) & " con otro cliente.", MsgBoxStyle.Exclamation, "AVISO")
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function Verifica_NIT_DUI_NRC(ByVal Compañia, ByVal NIT, ByVal DUI, ByVal NRC)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_VERIFICA_NIT_DUI_NRC "
            sql &= Compañia
            sql &= ", '" & NIT & "'"
            sql &= ", '" & DUI & "'"
            sql &= ", '" & NRC & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("EXISTE")
                Conexion_.Close()
            Else
                Return ""
                Conexion_.Close()
            End If
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return ""
        End Try
    End Function

    'En caso haya algún combobox, éste método lo válida, si devuelve un valor que no sea null, no permitirá ninguna operación.
    Private Function valCMB()
        Dim combosVacios As String = ""
        If Me.cmbCOMPAÑIA.SelectedValue = Nothing Then
            combosVacios = vbCrLf & "Compañia"
        End If
        If Me.cmbTIPO_CLIENTE.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Tipo Cliente"
        End If       
        'If Me.cmbCONTRIBUYENTE.SelectedValue = Nothing And Me.cmbCONTRIBUYENTE.Text <> "(No Definido)" Then
        '    combosVacios &= vbCrLf & "Contribuyente"
        'End If
        If combosVacios <> Nothing Then
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
        'Para los campos de Fax, Celular y Telefono
        Dim camposTFC As String = ""
        'Para el campo del email
        Dim campoMail As String = ""

        'Para el nombre, ya sea el Cliente o el Contacto del Cliente
        If nombre = Nothing Then
            nombreVacio = vbCrLf & "Debe escribir el Nombre del " & tipo
        End If

        'Validación de los campos acorde al tipo de cliente.
        'Sólo para el formulario del Cliente, no para el contacto del cliente.
        If tipo = "Cliente" Then
            'If Trim(Me.txtDuiCliente.Text) = "-" Or Trim(Me.txtNitCliente.Text) = "-      -   -" Or Me.txtRegFiscal.Text = Nothing Or Me.txtGiro.Text = Nothing Then
            If Trim(Me.txtDuiCliente.Text) = "-" Or Me.txtRegFiscal.Text = Nothing Or Me.txtGiro.Text = Nothing Then
                'Para ambos tipos de clientes, para dejar solo para persona natural descomentar el codigo
                ''Si es persona natural
                'If tipoCliente.Text = "Persona Natural" Then
                'DUI
                'AGREGADO POR YONATHAN, VALIDACION DE DUI REQUERIDO CUANDO SEA PERSONA NATURAL
                If Trim(Me.txtDuiCliente.Text) = "-" And tipoCliente.Text = "Persona Natural" Then
                    camposVaciosTipoCliente &= vbCrLf & "DUI"
                End If
                'End If
                'Para ambos tipos de clientes
                'NIT
                'If txtNitCliente.Text.Replace("-", "").Length < 14 Then
                '    camposVaciosTipoCliente &= vbCrLf & "NIT"
                'End If
                'Si es persona jurídica
                If tipoCliente.Text = "Persona Jurídica" Then
                    'Registro Fiscal
                    If Me.txtRegFiscal.Text = Nothing Then
                        camposVaciosTipoCliente &= vbCrLf & "Registro Fiscal"
                    End If
                    'Giro
                    If Me.txtGiro.Text = Nothing Then
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

        'Validación de los campos para el contacto de cliente, no para el formulario del cliente.
        If tipo = "Contacto" Then
            If Me.txtTelContacto.Text = Nothing And Me.txtCelContacto.Text = Nothing And Me.txtFaxContacto.Text = Nothing Then
                camposTFC = vbCrLf & "Debe llenar al menos uno de los siguientes campos:" & vbCrLf & "Teléfono" & vbCrLf & "Celular" & vbCrLf & "Fax"
            End If
            If Me.txtEmailContacto.Text <> Nothing Then
                If Regex.IsMatch(Me.txtEmailContacto.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") = False Then
                    campoMail = vbCrLf & "Debe ingresar una dirección de correo válida"
                End If
            End If
        End If

        If camposVaciosTipoCliente <> Nothing Or nombreVacio <> Nothing Or camposTFC <> Nothing Or campoMail <> Nothing Then
            camposVacios = nombreVacio & campoMail & nombreTipoCliente & camposVaciosTipoCliente & camposTFC
        End If

        'Para ambos casos: cliente y contacto, es es el mensaje de advertencia.
        If camposVacios <> Nothing Then
            MsgBox("Atención:" & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If

        Return camposVacios
    End Function

    'Genera Correlativo del Cliente
    Private Function generaCorrelativo(ByVal cia)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            sql &= cia
            sql &= ", 'CLI'"
            sql &= ", " & 0
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("ULTIMO")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    'Metodo para el mantenimiento IUD de los clientes
    Private Sub mttoClientes(ByVal cia, ByVal cliente, ByVal nombre, ByVal dir, ByVal tel, ByVal fax, ByVal dui, ByVal nit, ByVal tipoCliente, ByVal contribuyente, ByVal nrc, ByVal giro, ByVal rbSi, ByVal rbNo, ByVal origen, ByVal IUD)
        Dim exento As Integer = 0
        Dim res As Integer = 0
        Dim DS As New DataSet
        If rbSi <> False Then
            exento = 1
        ElseIf rbNo <> False Then
            exento = 0
        End If
        If cliente = Nothing Then
            cliente = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            DS.Reset()
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

            DataAdapter_.SelectCommand = Comando_

            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Cliente almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Cliente actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        DataAdapter_.Fill(DS)
                        If DS.Tables(0).Rows(0).Item("ELIMINADO") = "S" Then
                            MsgBox("Datos Cliente eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                        Else
                            MsgBox("No se puede eliminar ya que posee facturas emitidas.", MsgBoxStyle.Exclamation, "AVISO")
                        End If
                End Select
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Botón de guardar para contacto de cliente
    Private Sub btnGuardarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarContacto.Click
        Dim IUD As String = ""
        If Me.txtCliente.Text <> Nothing Then
            If valCamposVacios(Me.cmbTIPO_CLIENTE, Me.txtNombreContacto.Text, "Contacto") = Nothing Then
                If Me.cmbCONTRIBUYENTE.Text = "(No Definido)" Then
                    MsgBox("Debe definir un tipo de contribuyente para proceder.", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.cmbCONTRIBUYENTE.Focus()
                Else
                    If Trim(Me.txtContacto.Text) <> Nothing Then
                        IUD = "U"
                    Else
                        IUD = "I"
                    End If
                    mttoContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text, Me.txtContacto.Text, Me.txtNombreContacto.Text, Me.txtDirContacto.Text, Me.txtTelContacto.Text, Me.txtCelContacto.Text, Me.txtFaxContacto.Text, Me.txtEmailContacto.Text, IUD)
                    cargarContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text)
                    limpiaCampos(Me.gbCC)
                End If
            End If
        Else
            MsgBox("Debe elegir un cliente registrado", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    'Mantenimiento para los contactos
    Private Sub mttoContactos(ByVal cia, ByVal cliente, ByVal contacto, ByVal nombre, ByVal dir, ByVal tel, ByVal cel, ByVal fax, ByVal email, ByVal IUD)
        Dim res As Integer = 0
        If contacto = Nothing Then
            contacto = 0
        End If
        COnexion_=fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES_CONTACTOS_IUD "
            sql &= cia
            sql &= ", " & cliente
            sql &= ", " & contacto
            sql &= ", '" & nombre & "'"
            sql &= ", '" & dir & "'"
            sql &= ", '" & tel & "'"
            sql &= ", '" & cel & "'"
            sql &= ", '" & fax & "'"
            sql &= ", '" & email & "'"
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Contacto Cliente almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Contacto Cliente actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Contacto Cliente eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                End Select
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Llenado de datagridview para contacto cliente
    Private Sub cargarContactos(ByVal cia, ByVal cliente)
        If cliente = Nothing Then
            cliente = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_CLIENTES_CONTACTOS "
            sql &= cia
            sql &= ", " & cliente
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvContactos.Columns.Clear()
            Me.dgvContactos.DataSource = Table
            Me.dgvContactos.Columns.Item(9).Visible = False
            Me.dgvContactos.Columns.Item(10).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(11, Me.dgvContactos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Limpia los campos para ingresar un nuevo cliente
    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCliente.Click
        limpiaCampos(Me.gbDC)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaCMB()
        fill.limpiargrid(Me.dgvContactos)
        Me.cmbTIPO_CLIENTE.SelectionStart.ToString()
        Me.cmbCONTRIBUYENTE.SelectionStart.ToString()
    End Sub

    'Limpia los campos para ingresar un nuevo contacto
    Private Sub btnNuevoContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoContacto.Click
        limpiaCampos(Me.gbCC)
        fill.limpiargrid(Me.dgvContactos)
        If Me.txtCliente.Text <> Nothing Then
            cargarContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text)
        End If
    End Sub

    'Limpia todos los textboxs contenidos en un groupbox
    Private Sub limpiaCampos(ByVal sector As GroupBox)
        For Each elemento As Control In sector.Controls
            If TypeOf elemento Is TextBox Or TypeOf elemento Is MaskedTextBox Then
                elemento.Text = ""
            End If
        Next
        If sector.Name = "gbDC" And Me.txtContacto.Text <> Nothing Then
            Me.txtContacto.Clear()
        End If
        If sector.Name = "gbDC" Then
            Me.rbSi.Checked = False
            Me.rbNo.Checked = True
        End If
    End Sub

    'Carga de nuevo los combobox acorde al combobox de la compañia
    Private Sub cargaCMB()
        Iniciando = True
        fill.CargaTipoCliente(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTIPO_CLIENTE)
        fill.CargaContribuyente(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbCONTRIBUYENTE)
        'fill.CargaOrigenes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbORIGENES)
        fill.CargaOrigenesTerceros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbORIGENES)
        Iniciando = False
    End Sub

    'Para la busqueda de clientes
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim clientes As New Contabilidad_BusquedaClientes
        clientes.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        clientes.cmbCOMPAÑIA.Enabled = False
        Producto = ""
        Numero = ""
        Check = 0
        clientes.ShowDialog()
        If Producto <> "" Then
            COnexion_=fill.devuelveCadenaConexion()
            Try
                Conexion_.Open()
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Compañia
                sql &= ", " & Producto
                sql &= ", '" & Numero & "' "
                sql &= ", " & 2
                limpiaCampos(Me.gbDC)
                Comando_ = New SqlCommand(sql, Conexion_)
                DataReader_ = Comando_.ExecuteReader
                If DataReader_.Read = True Then

                    Me.cmbCOMPAÑIA.SelectedValue = DataReader_.Item("Compañia")
                    Me.txtCliente.Text = DataReader_.Item("Cliente")
                    Me.txtNombreCliente.Text = DataReader_.Item("Nombre")
                    Me.txtDirCliente.Text = DataReader_.Item("Dirección")
                    Me.txtTelCliente.Text = DataReader_.Item("Teléfono")
                    Me.txtFaxCliente.Text = DataReader_.Item("Fax")
                    Me.txtDuiCliente.Text = DataReader_.Item("DUI")
                    Me.txtNitCliente.Text = DataReader_.Item("NIT")
                    Me.cmbTIPO_CLIENTE.SelectedValue = DataReader_.Item("Tipo Cliente")
                    Me.cmbCONTRIBUYENTE.SelectedValue = DataReader_.Item("Tipo Contribuyente")
                    Me.cmbORIGENES.SelectedValue = DataReader_.Item("Origen")
                    Me.txtRegFiscal.Text = DataReader_.Item("NRC")
                    Me.txtGiro.Text = DataReader_.Item("Giro")
                    If DataReader_.Item("Exento") = True Then
                        Me.rbSi.Checked = True
                        Me.rbNo.Checked = False
                    ElseIf DataReader_.Item("Exento") = False Then
                        Me.rbNo.Checked = True
                        Me.rbSi.Checked = False
                    End If

                End If
                Conexion_.Close()
                If Me.txtContacto.Text <> Nothing Then
                    limpiaCampos(Me.gbCC)
                End If
                fill.limpiargrid(Me.dgvContactos)
                If Me.txtCliente.Text <> Nothing Then
                    cargarContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            Producto = ""
            Numero = ""
        End If

    End Sub

    'Para eliminar un cliente
    Private Sub btnEliminarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCliente.Click
        If Trim(Me.txtCliente.Text) <> Nothing Then
            Try
                If eliminarContacto() <> "No" Then
                    mttoClientes(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text, Me.txtNombreCliente.Text, Me.txtDirCliente.Text, Me.txtTelCliente.Text, Me.txtFaxCliente.Text, Me.txtDuiCliente.Text, Me.txtNitCliente.Text, Me.cmbTIPO_CLIENTE.SelectedValue, Me.cmbCONTRIBUYENTE.SelectedValue, Me.txtRegFiscal.Text, Me.txtGiro.Text, Me.rbSi.Checked, Me.rbNo.Checked, Me.cmbORIGENES.SelectedValue, "D")
                    limpiaCampos(Me.gbDC)
                    limpiaCampos(Me.gbCC)
                    fill.limpiargrid(Me.dgvContactos)
                    fill.CargaCompañia(Me.cmbCOMPAÑIA)
                    cargaCMB()
                Else
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        Else
            MsgBox("No ha seleccionado un Dato de Cliente valido para eliminar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    'Para validar eliminar el contacto
    Private Function eliminarContacto()
        Dim borrar As String = ""
        If MsgBox("¿Está seguro(a) de querer eliminar el Dato del Cliente Nº " & Me.txtCliente.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            borrar = "Sí"
            If Me.dgvContactos.RowCount <> 0 Then
                If MsgBox("El Cliente Nº " & Me.txtCliente.Text & " tiene contactos registrados ¿Está seguro(a) que querer eliminarlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                    borrar = "Sí"
                Else
                    borrar = "No"
                End If
            End If
        Else
            borrar = "No"
        End If
        Return borrar
    End Function

    'Evento cellclick para el DGV dgvClientes
    Private Sub dgvContactos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContactos.CellClick
        If Me.dgvContactos.RowCount = 0 Then
            Return
        Else
            If Me.dgvContactos.CurrentRow.Index < Me.dgvContactos.Rows.Count Then
                Me.txtContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(0).Value
                Me.txtNombreContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(1).Value
                Me.txtDirContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(2).Value
                Me.txtTelContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(3).Value
                Me.txtCelContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(4).Value
                Me.txtFaxContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(5).Value
                Me.txtEmailContacto.Text = Me.dgvContactos.CurrentRow.Cells.Item(6).Value
            End If
        End If
    End Sub

    'Eliminar un contacto cliente
    Private Sub btnEliminarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarContacto.Click
        If Trim(Me.txtContacto.Text) <> Nothing And Trim(Me.txtContacto.Text) <> "0" Then
            Try
                If MsgBox("¿Está seguro(a) que querer eliminar el Contacto del Cliente Nº " & Me.txtContacto.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                    mttoContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text, Me.txtContacto.Text, Me.txtNombreContacto.Text, Me.txtDirContacto.Text, Me.txtTelContacto.Text, Me.txtCelContacto.Text, Me.txtFaxContacto.Text, Me.txtEmailContacto.Text, "D")
                    cargarContactos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtCliente.Text)
                    limpiaCampos(Me.gbCC)
                Else
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        Else
            MsgBox("No ha seleccionado un Contacto de Cliente valido para eliminar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    'VALIDACION DE COMILLAS SIMPLES
    Private Sub txtNombreCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtDirCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtTelCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtFaxCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtRegFiscal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtGiro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtNombreContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtDirContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtTelContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtFaxContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtEmailContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtCelContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        fill.noComillaSimple(e)
    End Sub

    Private Sub txtNitCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNitCliente.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txtNitCliente.Text <> Nothing Then
                Dim cliente As New Contabilidad_BusquedaClientes
                cliente.buscarClientes(Compañia, "", txtNitCliente.Text)
            End If
        End If
    End Sub
End Class