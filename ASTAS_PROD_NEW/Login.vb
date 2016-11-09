Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmLogin
    Inherits System.Windows.Forms.Form
    Dim Sql As String
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Dim jClass As jarsClass

    Dim Encrip_desencrip As New Encriptar_Desencriptar
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents cmbCOMPANY As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.cmbCOMPANY = New System.Windows.Forms.ComboBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmbCOMPANY
        '
        Me.cmbCOMPANY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPANY.DropDownWidth = 400
        Me.cmbCOMPANY.Enabled = False
        Me.cmbCOMPANY.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCOMPANY.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPANY.Location = New System.Drawing.Point(12, 256)
        Me.cmbCOMPANY.Name = "cmbCOMPANY"
        Me.cmbCOMPANY.Size = New System.Drawing.Size(64, 24)
        Me.cmbCOMPANY.TabIndex = 3
        Me.cmbCOMPANY.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(315, 130)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(168, 26)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Ingresar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(369, 408)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 26)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.AcceptsTab = True
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Red
        Me.txtPassword.Location = New System.Drawing.Point(315, 109)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(176)
        Me.txtPassword.Size = New System.Drawing.Size(168, 15)
        Me.txtPassword.TabIndex = 1
        '
        'txtUsuario
        '
        Me.txtUsuario.AcceptsReturn = True
        Me.txtUsuario.AcceptsTab = True
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsuario.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.Blue
        Me.txtUsuario.Location = New System.Drawing.Point(315, 85)
        Me.txtUsuario.MaxLength = 10
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(168, 15)
        Me.txtUsuario.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(325, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Versión"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(336, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ASTAS-ATAF"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(374, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ERP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(830, 435)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCOMPANY)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtPassword)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lee_Contraseña()
        jClass = New jarsClass
        CargaCompany()
        'Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Dim AppVersion As String = My.Application.Info.Version.ToString
        Dim split As String() = AppVersion.Split(New [Char]() {"."c, ","c, CChar(vbTab)})
        Dim fechaVersion As Date = CDate("01/01/2000").AddDays(CInt(split(2)))
        Label4.Text &= " " & AppVersion & vbCrLf & "Fecha Versión: " & fechaVersion.ToString("dd/MM/yyyy")
    End Sub


    Private Function Valida_Login() As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Usuario_Track As SqlDataReader
        'NOMBRE DE LA BASE DE DATOS CON LA QUE TRABAJARA LA APLICACION
        Propietario = "dbo"
        'Conexion.Usuario = UsuarioDB
        'Conexion.Password = PasswordDB
        'Conexion.Servidor = Servidor
        'Conexion.Catalogo = BaseDatos
        If Me.txtUsuario.Text <> "" And Me.txtPassword.Text <> "" Then
            Sql = "Execute sp_CATALOGO_USUARIOS " & Me.cmbCOMPANY.SelectedValue & ", '" & Trim(Me.txtUsuario.Text) & "', '" & Me.txtPassword.Text & "' , 1 "
            Conexion_Track = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
            Try
                Conexion_Track.Open()
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                Usuario_Track = Comando_Track.ExecuteReader()
                If Usuario_Track.Read Then
                    Usuario = Trim(Usuario_Track.Item("USUARIO"))
                    Nombre_Usuario = Trim(Usuario_Track.Item("NOMBRE_USUARIO"))
                    Correo_Usuario = Trim(Usuario_Track.Item("CORREO_ELECTRONICO"))
                    ImagenPath &= "\" & Usuario_Track.Item("LOGO")
                    Compañia = Val(Me.cmbCOMPANY.SelectedValue)
                    Usuario_Track.Close()
                    Conexion_Track.Close()
                    Return True
                Else
                    'My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ladrido.wav")
                    MsgBox("Acceso Denegado." & Chr(13) & "Verifique la información digitada.", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                jClass.msjError(ex, "Login")
                Return False
            End Try
        Else
            MsgBox("Favor ingrese 'Usuario' y 'Contraseña' válidos.", MsgBoxStyle.Critical, "Error")
        End If
    End Function

    '        UsuarioDB = "wsCafeteria"
    '        PasswordDB = "w5Caf3teria"
    '        BaseDatos = "ASTAS_DB_Produccion"

    '        UsuarioDB = "usrAstasDesarrollo"
    '        PasswordDB = "DesAsta2014"
    '        BaseDatos = "ASTAS_DB_Desarrollo"

    '        'UsuarioDB = "usrAstasTesting"
    '        'PasswordDB = "TestAsta2014"
    '        'BaseDatos = "ASTAS_DB_Testing"

    '        Servidor = "SRVDBSVAST1"

    Private Sub Lee_Contraseña()
        Dim Archivo As System.IO.StreamReader
        Dim AppPath As String = System.IO.Directory.GetCurrentDirectory()
        Dim newArchivo As System.IO.StreamWriter
        Dim Texto_Leido As String, strConexion As String()
        Try
            If Not System.IO.File.Exists(AppPath & "\Astas.txt") Then
                newArchivo = New System.IO.StreamWriter(AppPath & "\Astas.txt", False)
                newArchivo.WriteLine("SY0ZHeX4W582ZwCRqmLC2kXUtqDkFojonzcMMIlPyywhiaxt6j/4+37AdUHFUZVLDua9yO11PsA=")
                newArchivo.Close()
            End If
            Archivo = New System.IO.StreamReader(AppPath & "\Astas.txt", False)
            Texto_Leido = Encrip_desencrip.Desencriptar(Archivo.ReadLine)
            Archivo.Close()
            strConexion = Texto_Leido.Split("%")
            UsuarioDB = strConexion(0)
            PasswordDB = strConexion(1)
            Servidor = strConexion(2)
            BaseDatos = strConexion(3)
            ImagenPath = AppPath '& "\Logo.png"
            IconPath = AppPath & "\icon.ico"
        Catch ex As Exception
            jClass.msjError(ex, "Lee_Contraseña()")
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub CargaCompany()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        'Conexion.Usuario = UsuarioDB
        'Conexion.Password = PasswordDB
        'Conexion.Servidor = Servidor
        'Conexion.Catalogo = BaseDatos
        'MessageBox.Show(Conexion.Obtiene_Cadena_Cnn_SQL(), "CADENA", MessageBoxButtons.OK)

        Conexion_Track = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_Track.Open()
            Sql = "sp_CATALOGO_COMPAÑIAS '', 0"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            'DataReader_Track = Comando_Track.ExecuteReader
            Me.cmbCOMPANY.DataSource = Table
            Me.cmbCOMPANY.ValueMember = "COMPAÑIA"
            Me.cmbCOMPANY.DisplayMember = "NOMBRE_COMPAÑIA"
            'DataReader_Track.Close()
            Me.cmbCOMPANY.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub TipoCompany()
        Dim DS01 As DataTable
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter

        Conexion_Track = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_Track.Open()
            Sql = "sp_CATALOGO_COMPAÑIAS_CONTRIBUYENTE " & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DS01 = New DataTable("Datos")
            DataAdapter_.Fill(DS01)
            Contribuyente = DS01.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub GetPorcentaje_IVA(ByVal Parametro)      'Obtener el porcentaje de IVA que se encuentra en la tabla CONTABILIDAD_CATALOGO_CONSTANTE
        Dim DS01 As DataTable
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter

        Conexion_Track = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_Track.Open()
            Sql = "sp_CONTABILIDAD_CATALOGO_CONSTANTES " & Compañia & "," & Parametro
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DS01 = New DataTable("Datos")
            DataAdapter_.Fill(DS01)
            If Parametro = 1 Then
                Por_IVA = DS01.Rows(0).Item(0)        'Variable definida como Publica que tiene el porcentaje del IVA. Se encuentra en Definitions.vb (en Otros)
            Else
                Por_Percibido = DS01.Rows(0).Item(0)  'Variable definida como Publica que tiene el porcentaje del Percibido. Se encuentra en Definitions.vb (en Otros)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub

    Private Sub LimpiaCampos()
        Me.txtUsuario.Text = ""
        Me.txtPassword.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Valida_Login() = True Then
                Dim Prin As New Seguridad_Principal
                'Dim Prin As New Explorer1
                AppPath = System.IO.Directory.GetCurrentDirectory
                LimpiaCampos()
                Me.Hide()
                'Prin.Text = "(Servidor: " & Servidor & "  BD: " & BaseDatos & ") " & Me.cmbCOMPANY.Text
                Prin.Text = Me.cmbCOMPANY.Text
                Prin.tssbtnBarra.DropDownItems.Item(0).Text = "Servidor: " & Servidor
                Prin.tssbtnBarra.DropDownItems.Item(1).Text = "Base de Datos: " & BaseDatos
                Prin.tssbtnBarra.DropDownItems.Item(2).Text = "Usuario: " & Usuario & " - " & Nombre_Usuario
                Prin.tssbtnBarra.DropDownItems.Item(3).Text = Label4.Text
                Descripcion_Compañia = cmbCOMPANY.Text
                Compañia = cmbCOMPANY.SelectedValue
                TipoCompany()
                GetPorcentaje_IVA(1)   'Obtiene el porcentaje del IVA.
                GetPorcentaje_IVA(2)   'Obtiene el porcentaje del Percibido.
                Prin.ShowDialog()
                Me.Dispose()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try    
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmbCOMPANY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCOMPANY.KeyPress
        If e.KeyChar <> "" Then
            Me.cmbCOMPANY.Text = ""
        End If
    End Sub

End Class
