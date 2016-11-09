Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_Proveedores

    Public CellClick_Flag As Double
    Private validarNit As New ValidacionNit
    Public bandera As Integer = 0
    Dim columna As Integer = 1 'Valor numero de la columna del DataGridView.
    Dim Table1 As DataTable
    Dim jClass As New jarsClass

#Region "Connection"
    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DS, DS_pc As New DataSet()
    Dim SQL As String
    Dim Contador As Integer
    Dim Accion As String
    Dim Estado As Integer
    Dim Iniciando As Boolean = True
    Dim Resultado As DialogResult
    Dim bandera_inicial As Boolean = False


    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
        'DataAdapter.Fill(DS)
        'Cmb_formapago.DataSource = DS.Tables(0)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
        'CargarDatos()
    End Sub

#End Region

#Region "Borrar cajas de texto"

    Sub BorrarTxtProveedor()
        For Each control As Control In Me.GrbProveedor.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                Me.TxtProveedor_Codigo.Focus()
            End If
        Next
        Me.TxtProveedor_Nit.Text = ""
        For Each control As Control In Me.GroupBox3.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                Me.TxtProveedor_Codigo.Focus()
            End If
        Next
        Me.TxtBusqueda_CodigoProveedor.Focus()
        Me.cmbCtaContable.SelectedIndex = -1
    End Sub
    Sub BorrarTxtProveedorContacto()
        For Each control As Control In Me.GrbProveedorContacto.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                Me.TxtProveedorContacto_Nombre.Focus()
            End If
        Next
        For Each control As Control In Me.GrbProveedorContacto.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                Me.TxtProveedorContacto_Nombre.Focus()
            End If
        Next
        Me.TxtProveedorContacto_Nombre.Focus()
        If Me.TxtProveedor_Codigo.Text <> Nothing Then
            Me.TxtProveedorContacto_NombreProveedor.Text = Me.TxtProveedor_NombreLegal.Text
        End If
    End Sub
#End Region

#Region "Validacion"

    Sub ValidacionTxtProveedor()

        If Me.TxtProveedor_NombreLegal.Text.Trim = Nothing Then
            MessageBox.Show("El NOMBRE del PROVEEDOR NO puede estar vacío", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedor_NombreLegal.Focus()
            Exit Sub
        End If
        If Me.TxtProveedor_NombreComercial.Text.Trim = Nothing Then
            MessageBox.Show("El NOMBRE COMERCIAL del PROVEEDOR NO puede estar vacío", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedor_NombreComercial.Focus()
            Exit Sub
        End If
        If (Me.TxtProveedor_RegistroFiscal.Text.Trim = Nothing) And (Me.CmbTipoContrib.SelectedValue <> "0") Then
            MessageBox.Show("El NUMERO DE REGISTRO del PROVEEDOR NO puede estar vacío", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedor_RegistroFiscal.Focus()
            Exit Sub
        End If
        'VALIDACION DE LA LONGITUD DEL NIT
        If Me.TxtProveedor_Nit.Text.Replace("-", "").Trim.Length > 0 And Me.TxtProveedor_Nit.Text.Replace("-", "").Trim.Length < 14 Then
            MessageBox.Show("El NUMERO DE NIT del PROVEEDOR NO está completo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedor_Nit.Focus()
            Exit Sub
        End If
        'VALIDACION DEL DIGITO VERIFICADOR QUE TRAE EL NIT CONTRA EL VALOR CALCULADO DEL DIGITO VERIFICADOR
        If Me.TxtProveedor_Nit.Text.Replace("-", "").Trim.Length > 0 Then
            If Me.TxtProveedor_Nit.Text.Replace("-", "").Trim.Length = 14 Then
                If Not Me.TxtProveedor_Nit.Text.Replace("-", "").Substring(13, 1).Equals(validarNit.Dig_Verf(Me.TxtProveedor_Nit.Text.Replace("-", ""))) Then
                    MessageBox.Show("El NUMERO DE NIT del PROVEEDOR NO es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TxtProveedor_Nit.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("El NUMERO DE NIT del PROVEEDOR NO es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtProveedor_Nit.Focus()
                Exit Sub
            End If
        End If
        If Me.TxtProveedor_Direccion.Text.Trim = Nothing Then
            MessageBox.Show("La DIRECCION del PROVEEDOR NO puede estar vacía", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedor_Direccion.Focus()
            Exit Sub
        End If
        If Me.CmbProveedor_FormaPago.Text = "" Then
            MessageBox.Show("La FORMA de PAGO al PROVEEDOR NO puede estar vacía", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.CmbProveedor_FormaPago.Focus()
            Exit Sub
        End If
        If Me.CmbProveedor_CondicionPago.Text = "" Then
            MessageBox.Show("La CONDICION de PAGO al PROVEEDOR NO puede estar vacía", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.CmbProveedor_CondicionPago.Focus()
            Exit Sub
        End If
        If Proveedor_Ver_NIT() Then
            Proveedor_SIUD()
        End If
    End Sub
    Public Function Proveedor_Ver_NIT()
        Try
            DS.Reset()
            OpenConnection()
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES_VER_NIT " & _
            Compañia & ", '" & Me.TxtProveedor_RegistroFiscal.Text & "','" & Me.TxtProveedor_Nit.Text.Replace("-", "") & "'"
            MiddleConnection()
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows(0).Item("EXISTE").ToString = "S" Then
                If MsgBox("Ya Existe Proveedor con " & DS.Tables(0).Rows(0).Item("DATOS").ToString & " igual." & vbCrLf & vbCrLf & "¿Desea Continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Validación") = MsgBoxResult.No Then
                    Hay_Datos = False
                Else
                    Hay_Datos = True
                End If
            Else
                Hay_Datos = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
        Return Hay_Datos
    End Function

    Sub ValidacionTxtProveedorContacto()

        If Me.TxtProveedorContacto_NombreProveedor.Text.Trim = Nothing Then
            MessageBox.Show("NO ha seleccionado ningun proveedor, favor seleccione uno en la pestaña 'Datos proveedor'", _
            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TabControl1.SelectedTab = Me.TabControl1.TabPages(0)
            Exit Sub

        ElseIf Me.TxtProveedorContacto_Nombre.Text.Trim = Nothing Then
            MessageBox.Show("El NOMBRE del CONTACTO del PROVEEDOR ''" & Me.TxtProveedorContacto_NombreProveedor.Text & _
            "'' NO puede estar VACÍO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedorContacto_Nombre.Focus()
            Exit Sub

        ElseIf Me.TxtProveedorContacto_Apellido.Text.Trim = Nothing Then
            MessageBox.Show("El APELLIDO del CONTACTO del PROVEEDOR ''" & Me.TxtProveedorContacto_NombreProveedor.Text & _
            "'' NO puede estar VACÍO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedorContacto_Apellido.Focus()
            Exit Sub

        ElseIf Me.TxtProveedorContacto_Telefono1.Text.Trim = Nothing Then
            MessageBox.Show("El 1er TELEFONO NO puede estar VACÍO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtProveedorContacto_Telefono1.Focus()
            Exit Sub

        Else
            ProveedorContacto_SIUD()
        End If

    End Sub

#End Region

#Region "Cargar Combobox's"

    Sub CargarDatosCombobox_Compañia()
        Me.CmbCompania.Text = ""
        Try
            OpenConnection()
            SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            'DataReader_Track = Comando_Track.ExecuteReader
            Me.CmbCompania.DataSource = table
            Me.CmbCompania.ValueMember = "COMPAÑIA"
            Me.CmbCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            'DataReader_Tr ack.Close()
            Me.CmbCompania.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub CargarDatosCombobox_FormaPago()
        Try
            DS.Reset()
            OpenConnection()
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES " & _
             Compañia & ", 1, 'ncr','nit','nombre_proveedor','nombrecomercial','direccion',0,0,0,'codigo astas','" & Usuario & "','SFCFP'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            Me.CmbProveedor_FormaPago.DataSource = table
            Me.CmbProveedor_FormaPago.ValueMember = "FORMA_PAGO"
            Me.CmbProveedor_FormaPago.DisplayMember = "DESCRIPCION_FORMA_PAGO"

            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub CargarDatosCombobox_TiempoPago() '(ByVal Act As Boolean)
        Contador = Contador + 1
        If Contador > 3 Then
            Me.CmbProveedor_CondicionPago.Text = ""
            Try
                'DS.Reset()
                OpenConnection()
                SQL = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES " & Compañia & ", 1, 'ncr','nit','nombre_proveedor','nombrecomercial','direccion',0,'" & Val(Me.CmbProveedor_FormaPago.SelectedValue) & "',0,'codigo astas','" & Usuario & "','TP'"
                Comando_Track = New SqlCommand(SQL, Conexion_Track)
                DataAdapter = New SqlDataAdapter(Comando_Track)
                Dim table As DataTable
                table = New DataTable("Datos")
                DataAdapter.Fill(table)
                Me.CmbProveedor_CondicionPago.DataSource = table
                Me.CmbProveedor_CondicionPago.ValueMember = "CONDICION_PAGO"
                Me.CmbProveedor_CondicionPago.DisplayMember = "DESCRIPCION_CONDICION_PAGO"
                Me.CmbProveedor_CondicionPago.SelectedItem = 1
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

    Public Sub CargarDatosCombobox_TipoProveedor()
        Dim table As DataTable
        Try
            SQL = "EXECUTE sp_CONTABILIDAD_CATALOGO_PROVEEDORES @COMPAÑIA = " & Compañia & ", @SIUD = 'SCCTP'" & vbCrLf
            table = jClass.obtenerDatos(New SqlCommand(SQL))
            Me.CmbTipoContrib.DataSource = table
            Me.CmbTipoContrib.ValueMember = "TIPO_PROVEEDOR"
            Me.CmbTipoContrib.DisplayMember = "DESCRIPCION_TIPO_PROVEEDOR"
            Me.CmbTipoContrib.SelectedIndex = 1

            SQL = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_TIPO_CLIENTE] @COMPAÑIA = " & Compañia & ", @BANDERA = 1" & vbCrLf
            table = jClass.obtenerDatos(New SqlCommand(SQL))
            Me.cmbTipoProv.DataSource = table
            Me.cmbTipoProv.ValueMember = "TIPO_CLIENTE"
            Me.cmbTipoProv.DisplayMember = "DESCRIPCION_TIPO_CLIENTE"
            Me.cmbTipoProv.SelectedIndex = 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub BotonesLimpiar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click, BtnNuevoContacto.Click
        Me.bandera_inicial = False
        If sender Is BtnNuevo Then
            BorrarTxtProveedor()
        ElseIf sender Is BtnNuevoContacto Then
            BorrarTxtProveedorContacto()
        End If
        Me.TxtBusqueda_CodigoProveedor.Clear()
        Me.TxtBusqueda_NRC.Clear()
        Me.TxtBusqueda_NombreProveedor.Clear()
        Me.TxtBusqueda_NIT.Clear()
        Me.dgvProveedores.DataSource = Table1
    End Sub


#Region "Mantenimiento"
    Private Sub Proveedor_SIUD()
        Dim CodProveedor As Integer
        If Accion = Nothing Then
            Exit Sub
        End If
        Try
            CodProveedor = Val(Me.TxtProveedor_Codigo.Text)
            If Me.TxtProveedor_Codigo.Text = Nothing Then
                CodProveedor = 0
            End If
            DS.Reset()
            OpenConnection()
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES " & vbCrLf
            SQL &= "@COMPAÑIA=" & Compañia & vbCrLf
            SQL &= ", @PROVEEDOR=" & CodProveedor & vbCrLf
            SQL &= ", @NRC='" & Me.TxtProveedor_RegistroFiscal.Text & "'" & vbCrLf
            SQL &= ", @NIT='" & Me.TxtProveedor_Nit.Text.Replace("-", "") & "'" & vbCrLf
            SQL &= ", @NOMBRE_PROVEEDOR='" & Me.TxtProveedor_NombreLegal.Text & "'" & vbCrLf
            SQL &= ", @NOMBRE_COMERCIAL='" & Me.TxtProveedor_NombreComercial.Text & "'" & vbCrLf
            SQL &= ", @DIRECCION='" & Me.TxtProveedor_Direccion.Text & "'" & vbCrLf
            SQL &= ", @TIPO_PROVEEDOR=" & Me.CmbTipoContrib.SelectedValue & vbCrLf
            SQL &= ", @FORMA_PAGO=" & Me.CmbProveedor_FormaPago.SelectedValue & vbCrLf
            SQL &= ", @CONDICION_PAGO=" & Me.CmbProveedor_CondicionPago.SelectedValue & vbCrLf
            SQL &= ", @CODIGO_ASTAS='" & Me.cmbCtaContable.SelectedValue & "'" & vbCrLf
            SQL &= ", @USUARIO='" & Usuario & "'" & vbCrLf
            SQL &= ", @SIUD='" & Accion & "'" & vbCrLf
            SQL &= ", @BANCO=" & Me.cmbBancos.SelectedValue & vbCrLf
            SQL &= ", @CUENTA='" & Me.txtCuenta.Text & "'" & vbCrLf
            SQL &= ", @TIPO_CUENTA='" & Me.cmbTipoCuenta.SelectedValue & "'" & vbCrLf
            SQL &= ", @ESTADO=" & Me.cmbTipoProv.SelectedValue & vbCrLf
            MiddleConnection()
            DataAdapter.Fill(DS)
            If Accion = "IP" Then
                MessageBox.Show("Se ha INSERTADO un nuevo registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Accion = "UP" Then
                    MessageBox.Show("Se ha MODIFICADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Accion = "DP" Then
                        If DS.Tables(0).Rows(0).Item("ELIMINADO") = "S" Then
                            MessageBox.Show("Se ha ELIMINADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MsgBox("No se puede eliminar ya que posee movimientos.", MsgBoxStyle.Critical, "AVISO")
                        End If
                    End If
                End If
            End If
            CargarDatosGrid_Proveedores()
            BorrarTxtProveedor()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub
    Public Sub ProveedorContacto_SIUD()
        Dim CodContacto As Integer
        If Accion = Nothing Then
            Exit Sub
        End If
        Try
            CodContacto = Val(Me.TxtProveedorContactoID.Text)
            If Me.TxtProveedorContactoID.Text = Nothing Then
                CodContacto = 0
            End If
            OpenConnection()
            SQL = "EXEC sp_CONTABILIDAD_CATALOGO_PROVEEDORES_CONTACTOS " & _
            Compañia & "," & Val(Me.TxtProveedor_Codigo.Text) & "," & CodContacto & ",'" & Me.TxtProveedorContacto_Nombre.Text & "','" & Me.TxtProveedorContacto_Apellido.Text & "','" & Me.TxtProveedorContacto_Telefono1.Text & "','" & Me.TxtProveedorContacto_Telefono2.Text & "','" & Me.TxtProveedorContacto_CorreoElectronico.Text & "','" & Usuario & "','" & Accion & "'"
            MiddleConnection()
            DataAdapter.Fill(DS)
            If Accion = "IPC" Then
                MessageBox.Show("Se ha INSERTADO un nuevo registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Accion = "UPC" Then
                MessageBox.Show("Se ha MODIFICADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Accion = "DPC" Then
                MessageBox.Show("Se ha ELIMINADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            CargarDatosGrid_ProveedoresContactos()
            BorrarTxtProveedorContacto()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try


    End Sub
#End Region

    Private Sub Contabilidad_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatosCombobox_Compañia()
        BorrarTxtProveedorContacto()
        'PictureBox1.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargarDatosCombobox_FormaPago()
        CargarDatosCombobox_TiempoPago()
        CargarDatosCombobox_TipoProveedor()
        CargarDatosGrid_Proveedores()
        cargaTipoCuenta()
        BorrarTxtProveedor()
        CargaBancos()
        cargarCuentasContables()
        Me.CmbProveedor_CondicionPago.Text = ""
        Iniciando = False
    End Sub
    Private Sub cargarCuentasContables()
        Dim Table As DataTable
        Dim sql As String
        sql = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @SIUD = 'CC'"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbCtaContable.DataSource = Table
        Me.cmbCtaContable.ValueMember = "CUENTA"
        Me.cmbCtaContable.DisplayMember = "DESCRIPCION"
    End Sub
    Private Sub cargaTipoCuenta()
        Dim Table As DataTable
        Try
            SQL = "select TIPO_CUENTA_BANCARIA, DESCRIPCION_TIPO_CUENTA_BANCARIA from CONTABILIDAD_CATALOGO_BANCOS_TIPO_CUENTA where COMPAÑIA=" & Compañia
            Table = jClass.obtenerDatos(New SqlCommand(SQL))
            Me.cmbTipoCuenta.DataSource = Table
            Me.cmbTipoCuenta.ValueMember = "TIPO_CUENTA_BANCARIA"
            Me.cmbTipoCuenta.DisplayMember = "DESCRIPCION_TIPO_CUENTA_BANCARIA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaBancos()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            SQL &= Compañia
            SQL &= ", 0"
            SQL &= ", 3"
            Comando_ = New SqlCommand(SQL, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbBancos.DataSource = Table
            Me.cmbBancos.ValueMember = "Banco"
            Me.cmbBancos.DisplayMember = "Nombre Banco"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CmbProveedor_FormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor_FormaPago.SelectedIndexChanged
        Try
            'MsgBox(Val(Me.CmbProveedor_FormaPago.SelectedValue()))
            CargarDatosCombobox_TiempoPago()
            'CargarDatosCombobox_FormaPago()
        Catch ex As Exception
            'MsgBox(EX.Message)
        End Try
    End Sub

#Region "Cargar grids"

    Sub CargarDatosGrid_Proveedores()
        Try
            SQL = "EXECUTE sp_CONTABILIDAD_CATALOGO_PROVEEDORES " & Compañia & ", 1, 'ncr','nit','nombre_proveedor','nombrecomercial','direccion',0,2,0,'codigo astas','SYSTEM','SP'"
            Table1 = jClass.obtenerDatos(New SqlCommand(SQL))
            dgvProveedores.DataSource = Table1
            Ocultar_Columnas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For i As Integer = 0 To dgvProveedores.ColumnCount - 1
            dgvProveedores.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Sub CargarDatosGrid_ProveedoresContactos()

        Try
            If Me.TxtProveedor_Codigo.Text = Nothing Then
                Exit Sub
            End If
            DS_pc.Reset()
            OpenConnection()
            SQL = "EXEC sp_CONTABILIDAD_CATALOGO_PROVEEDORES_CONTACTOS " & Compañia & "," & Me.TxtProveedor_Codigo.Text & ",1,'JOAN','SERRANO','24535565','24535565','JS@JS.COM','" & Usuario & "','SPC'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            MiddleConnection()
            DataAdapter.Fill(DS_pc)
            dgvProvContactos.DataSource = DS_pc.Tables(0)
            CloseConnection()
            Me.dgvProvContactos.Columns(0).Visible = False 'compañia
            Me.dgvProvContactos.Columns(1).Visible = False 'nombre_compañia
            Me.dgvProvContactos.Columns(2).Visible = False 'proveedor(codigo)
            Me.dgvProvContactos.Columns(3).Visible = False 'nombre_proveedor
            Me.dgvProvContactos.Columns(4).Visible = False 'nombre_comercial
            Me.dgvProvContactos.Columns(5).Visible = False 'contacto(codigo)
            Me.dgvProvContactos.Columns(11).Visible = False 'estado            
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
        Me.dgvProvContactos.Columns.Item(6).Width = 150 'nombre contacto
        Me.dgvProvContactos.Columns.Item(7).Width = 150 'apellido proveedor
        Me.dgvProvContactos.Columns.Item(8).Width = 85 'telefono1
        Me.dgvProvContactos.Columns.Item(9).Width = 85 'telefono 2
        Me.dgvProvContactos.Columns.Item(10).Width = 200 'email
    End Sub

#End Region

#Region "Busquedas"

    Sub CargarDatosGrid_Proveedores_Busqueda()

        Dim CodigoProveedor As Integer
        CodigoProveedor = Val(Me.TxtBusqueda_CodigoProveedor.Text.Trim)

        If Me.TxtBusqueda_CodigoProveedor.Text.Trim <> Nothing _
            Or Me.TxtBusqueda_NombreProveedor.Text.Trim <> Nothing _
            Or Me.TxtBusqueda_NRC.Text.Trim <> Nothing Or Me.TxtBusqueda_NIT.Text.Trim <> Nothing Then
            bandera = 0
        Else : bandera = 1
        End If
        Try
            DS.Reset()
            OpenConnection()

            SQL = "EXEC sp_CONTABILIDAD_CATALOGO_PROVEEDORES_BUSQUEDA " & Compañia & "," & CodigoProveedor & _
            ",'" & Me.TxtBusqueda_NombreProveedor.Text.Trim & "','" & Me.TxtBusqueda_NRC.Text.Trim & "','" & _
            Me.TxtBusqueda_NIT.Text.Trim & "',''," & bandera & ""

            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            MiddleConnection()
            DataAdapter.Fill(DS)
            dgvProveedores.DataSource = DS.Tables(0)
            CloseConnection()
            Ocultar_Columnas()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub
    Sub Ocultar_Columnas()
        Me.dgvProveedores.Columns(0).Visible = False 'compañia
        Me.dgvProveedores.Columns(1).Visible = False 'nombre_compañia
        Me.dgvProveedores.Columns(8).Visible = False 'codas
        Me.dgvProveedores.Columns(9).Visible = False 'stado(proveedor)
        Me.dgvProveedores.Columns(10).Visible = False 'tipo_proveedor
        Me.dgvProveedores.Columns(12).Visible = False 'forma_pago(codigo)
        Me.dgvProveedores.Columns(14).Visible = False 'condicion_pago(codigo)
        Me.dgvProveedores.Columns(16).Visible = False 'dias
        Me.dgvProveedores.Columns(17).Visible = False 'banco(codigo)
        Me.dgvProveedores.Columns(18).Visible = False 'cuenta bancaria
        Me.dgvProveedores.Columns(19).Visible = False 'tipo_cuenta(codigo)
        Me.dgvProveedores.Columns(20).Visible = False 'cuenta_contable(codigo)
        For i As Integer = 1 To 16
            dgvProveedores.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    Sub CargarDatosGrid_ProveedoresContactos_Busqueda()

        Dim CodigoProveedor As Integer
        If Me.TxtProveedor_Codigo.Text <> Nothing Then
            CodigoProveedor = Val(Me.TxtProveedor_Codigo.Text.Trim)
        Else
            MessageBox.Show("Seleccione un probeedor para realizar la busqueda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.TxtBusqueda_ContactoNombre.Text.Trim <> Nothing _
            Or Me.TxtBusqueda_ContactoApellido.Text.Trim <> Nothing _
            Or Me.TxtBusqueda_ContactoTelefono.Text.Trim <> Nothing _
            Or Me.TxtBusqueda_ContactoEmail.Text.Trim <> Nothing Then
            Bandera = 0
        Else : Bandera = 1
        End If

        Try
            DS_pc.Reset()
            OpenConnection()

            SQL = "EXEC sp_CONTABILIDAD_CATALOGO_PROVEEDORES_CONTACTOS_BUSQUEDA " & _
            Compañia & "," & CodigoProveedor & ",'" & Me.TxtBusqueda_ContactoNombre.Text.Trim & "','" & _
            Me.TxtBusqueda_ContactoApellido.Text.Trim & "','" & Me.TxtBusqueda_ContactoTelefono.Text.Trim & _
            "','" & Me.TxtBusqueda_ContactoEmail.Text.Trim & "',0"

            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            MiddleConnection()
            DataAdapter.Fill(DS_pc)
            dgvProvContactos.DataSource = DS_pc.Tables(0)
            CloseConnection()
            'Me.DataGrid2.Columns(0).Visible = False 'compañia
            'Me.DataGrid2.Columns(1).Visible = False 'nombre_compañia
            Me.dgvProvContactos.Columns(2).Visible = False 'proveedor(codigo)
            Me.dgvProvContactos.Columns(3).Visible = False 'nombre_proveedor
            Me.dgvProvContactos.Columns(4).Visible = False 'nombre_comercial
            Me.dgvProvContactos.Columns(5).Visible = False 'contacto(codigo)
            Me.dgvProvContactos.Columns(11).Visible = False 'estado            
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
        Me.dgvProvContactos.Columns.Item(6).Width = 150 'nombre contacto
        Me.dgvProvContactos.Columns.Item(7).Width = 150 'apellido proveedor
        Me.dgvProvContactos.Columns.Item(8).Width = 85 'telefono1
        Me.dgvProvContactos.Columns.Item(9).Width = 85 'telefono 2
        Me.dgvProvContactos.Columns.Item(10).Width = 200 'email
    End Sub

#End Region

#Region "DataGrid CellClick"

    Private Sub DataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProveedores.CellClick
        Try
            If e.RowIndex > -1 Then
                Me.bandera_inicial = True
                Me.TxtProveedor_Codigo.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(2).Value()
                Me.TxtProveedor_NombreLegal.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(3).Value()
                Me.TxtProveedorContacto_NombreProveedor.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(3).Value()
                Me.TxtProveedor_NombreComercial.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(4).Value()
                Me.TxtProveedor_RegistroFiscal.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(5).Value()
                Me.TxtProveedor_Nit.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(6).Value()
                Me.TxtProveedor_Direccion.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(7).Value()
                Me.CmbTipoContrib.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(11).Value()
                Me.CmbProveedor_FormaPago.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(13).Value()
                Me.CmbProveedor_CondicionPago.SelectedValue = Me.dgvProveedores.Rows(e.RowIndex).Cells(14).Value()
                Me.cmbTipoProv.SelectedValue = Me.dgvProveedores.Rows(e.RowIndex).Cells(9).Value()
                Me.cmbBancos.SelectedValue = Me.dgvProveedores.Rows(e.RowIndex).Cells(17).Value()
                Me.txtCuenta.Text = Me.dgvProveedores.Rows(e.RowIndex).Cells(18).Value()
                Me.cmbTipoCuenta.SelectedValue = Me.dgvProveedores.Rows(e.RowIndex).Cells(19).Value()
                Me.cmbCtaContable.SelectedValue = Me.dgvProveedores.Rows(e.RowIndex).Cells(20).Value()
                CargarDatosGrid_ProveedoresContactos()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub DataGrid2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProvContactos.CellClick
        Try
            Me.TxtProveedorContactoID.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(5).Value()
            Me.TxtProveedorContacto_Nombre.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(6).Value()
            Me.TxtProveedorContacto_Apellido.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(7).Value()
            Me.TxtProveedorContacto_Telefono1.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(8).Value()
            Me.TxtProveedorContacto_Telefono2.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(9).Value()
            Me.TxtProveedorContacto_CorreoElectronico.Text = Me.dgvProvContactos.Rows(e.RowIndex).Cells(10).Value()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Botones"

    Private Sub BtnProveedorContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarContacto.Click, BtnEliminarContacto.Click
        'MsgBox(Me.CmbProveedor_TipoProveedor.Text)
        'Exit Sub
        Dim result As DialogResult
        'result = MessageBox.Show("Esta seguro que desea MODIFICAR los datos de este beneficiario", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        'If result = Windows.Forms.DialogResult.Yes Then
        '    Accion = "U"
        '    Estado = 1
        'End If
        If sender Is BtnGuardarContacto Then
            If Me.TxtProveedorContactoID.Text = Nothing Then
                Accion = "IPC"
            Else
                result = MessageBox.Show("Esta seguro que desea modificar los datos de este contacto", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If result = Windows.Forms.DialogResult.Yes Then
                    Accion = "UPC"
                End If
            End If
            ValidacionTxtProveedorContacto()
        ElseIf sender Is BtnEliminarContacto Then
            If Me.TxtProveedorContactoID.Text <> Nothing Then
                result = MessageBox.Show("Esta seguro que desea eliminar los datos de este contacto", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If result = Windows.Forms.DialogResult.Yes Then
                    Accion = "DPC"
                    ValidacionTxtProveedorContacto()
                Else
                    MessageBox.Show("NO se ha selecionado ningun contacto de proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub

#End Region


    Private Sub BtnsBuscarClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar_Proveedor.Click, BtnBuscar_ProveedorContacto.Click

        If sender Is BtnBuscar_Proveedor Then
            CargarDatosGrid_Proveedores_Busqueda()
        ElseIf sender Is BtnBuscar_ProveedorContacto Then
            CargarDatosGrid_ProveedoresContactos_Busqueda()
        End If
        Me.TxtBusqueda_CodigoProveedor.Text = ""
        Me.TxtBusqueda_NombreProveedor.Text = ""
        Me.TxtBusqueda_NRC.Text = ""
        Me.TxtBusqueda_NIT.Text = ""
    End Sub

    Private Sub CmbCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCompania.SelectedIndexChanged
        'Compañia = Val(Me.CmbCompania.SelectedValue)
        'MessageBox.Show(Compañia)
        CargarDatosGrid_Proveedores()
    End Sub

    'Private Sub TxtProveedor_NombreLegal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_NombreLegal.TextChanged
    '    If Iniciando = False Then
    '        If Me.TxtProveedor_NombreLegal.Text.Trim <> "" Then
    '            Try
    '                If Me.bandera_inicial = False Then
    '                    DS.Reset()
    '                    OpenConnection()

    '                    SQL = "SELECT [COMPAÑIA],[NOMBRE_COMPAÑIA],[PROVEEDOR][Código],[NOMBRE_PROVEEDOR][Proveedor Nombre Legal],[NOMBRE_COMERCIAL][Proveedor Nombre Comercial]," & _
    '                          "[NRC],[NIT],[DIRECCION][Dirección],ISNULL([CODIGO_ASTAS],'----')[CodAS],[ESTADO],[TIPO_PROVEEDOR],[DESCRIPCION_TIPO_PROVEEDOR][Tipo Proveedor]," & _
    '                          "[FORMA_PAGO],[DESCRIPCION_FORMA_PAGO][Forma de pago],[CONDICION_PAGO],[DESCRIPCION_CONDICION_PAGO][Condición de pago],[DIAS][Días],[BANCO],[CUENTA],[TIPO_CUENTA],[CUENTA_CONTABLE]" & _
    '                          "FROM VISTA_CONTABILIDAD_PROVEEDORES WHERE COMPAÑIA=" & Compañia & _
    '                          " AND NOMBRE_PROVEEDOR LIKE '" & Me.TxtProveedor_NombreLegal.Text.Trim & "%' ORDER BY NOMBRE_PROVEEDOR"

    '                    Comando_Track = New SqlCommand(SQL, Conexion_Track)
    '                    MiddleConnection()
    '                    DataAdapter.Fill(DS)
    '                    dgvProveedores.DataSource = DS.Tables(0)
    '                    CloseConnection()
    '                    Ocultar_Columnas()
    '                End If
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            Finally
    '                CloseConnection()
    '            End Try
    '        End If
    '    Else
    '        Iniciando = False
    '    End If
    'End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.TxtProveedor_Codigo.Text = Nothing Then
            If MsgBox("Desea ADICIONAR los datos de este PROVEEDOR", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then
                Accion = "IP"
                ValidacionTxtProveedor()
            End If
        Else
            If MsgBox("Esta seguro que desea MODIFICAR los datos de este PROVEEDOR", MsgBoxStyle.YesNo, "MODIFICAR") = MsgBoxResult.Yes Then
                Accion = "UP"
                Proveedor_SIUD()
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Me.bandera_inicial = False
        If MsgBox("Esta seguro que desea ELIMINAR los datos de este PROVEEDOR", MsgBoxStyle.YesNo, "ELIMINAR") = MsgBoxResult.Yes Then
            Accion = "DP"
            Proveedor_SIUD()
            BorrarTxtProveedorContacto()
        End If
    End Sub

    Private Sub TxtProveedor_NombreLegal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProveedor_NombreLegal.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If dgvProveedores.RowCount > 0 Then
                Me.bandera_inicial = True
                Me.TxtProveedor_Codigo.Text = Me.dgvProveedores.Rows(0).Cells(2).Value()
                Me.TxtProveedor_NombreLegal.Text = Me.dgvProveedores.Rows(0).Cells(3).Value()
                Me.TxtProveedorContacto_NombreProveedor.Text = Me.dgvProveedores.Rows(0).Cells(3).Value()
                Me.TxtProveedor_NombreComercial.Text = Me.dgvProveedores.Rows(0).Cells(4).Value()
                Me.TxtProveedor_RegistroFiscal.Text = Me.dgvProveedores.Rows(0).Cells(5).Value()
                Me.TxtProveedor_Nit.Text = Me.dgvProveedores.Rows(0).Cells(6).Value()
                Me.TxtProveedor_Direccion.Text = Me.dgvProveedores.Rows(0).Cells(7).Value()
                Me.CmbTipoContrib.Text = Me.dgvProveedores.Rows(0).Cells(11).Value()
                Me.CmbProveedor_FormaPago.Text = Me.dgvProveedores.Rows(0).Cells(13).Value()
                Me.CmbProveedor_CondicionPago.SelectedValue = Me.dgvProveedores.Rows(0).Cells(14).Value()
                Me.cmbTipoProv.SelectedValue = Me.dgvProveedores.Rows(0).Cells(9).Value()
                Me.cmbBancos.SelectedValue = Me.dgvProveedores.Rows(0).Cells(17).Value()
                Me.txtCuenta.Text = Me.dgvProveedores.Rows(0).Cells(18).Value()
                Me.cmbTipoCuenta.SelectedValue = Me.dgvProveedores.Rows(0).Cells(19).Value()
                Me.cmbCtaContable.SelectedValue = Me.dgvProveedores.Rows(0).Cells(20).Value()
                CargarDatosGrid_ProveedoresContactos()
            End If
        End If
    End Sub

    Private Sub TxtBusqueda_CodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusqueda_CodigoProveedor.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 2
            Dim Ncolumn As String = dgvProveedores.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProveedores.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TxtBusqueda_CodigoProveedor.Text = "" Then
                Me.dgvProveedores.DataSource = Table1
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table1.Select("[" & dgvProveedores.Columns(columna).Name & "] = " & TxtBusqueda_CodigoProveedor.Text & "") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvProveedores.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub TxtBusqueda_NombreProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusqueda_NombreProveedor.TextChanged ', TxtProveedor_NombreLegal.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 3
            Dim Ncolumn As String = dgvProveedores.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProveedores.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TxtBusqueda_NombreProveedor.Text = "" Then
                Me.dgvProveedores.DataSource = Table1
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table1.Select("[" & dgvProveedores.Columns(columna).Name & "] like '" & TxtBusqueda_NombreProveedor.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvProveedores.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub TxtBusqueda_NRC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusqueda_NRC.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 5
            Dim Ncolumn As String = dgvProveedores.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProveedores.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TxtBusqueda_NRC.Text = "" Then
                Me.dgvProveedores.DataSource = Table1
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table1.Select("[" & dgvProveedores.Columns(columna).Name & "] like '" & TxtBusqueda_NRC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvProveedores.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub TxtBusqueda_NIT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusqueda_NIT.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 6
            Dim Ncolumn As String = dgvProveedores.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProveedores.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TxtBusqueda_NIT.Text = "" Then
                Me.dgvProveedores.DataSource = Table1
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table1.Select("[" & dgvProveedores.Columns(columna).Name & "] like '" & TxtBusqueda_NIT.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next
                ' return filtered dt            
                Me.dgvProveedores.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub Contabilidad_Proveedores_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class