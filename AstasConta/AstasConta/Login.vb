Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmLogin
    Inherits System.Windows.Forms.Form
    Dim Sql As String
    Dim onHover As Integer = 0
    Dim ex, ey As Integer
    Dim Arrastre As Boolean
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPANY As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.cmbCOMPANY = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(107, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(142, 63)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Navy
        Me.btnAceptar.Image = Global.AstasConta.My.Resources.Resources.decrypted
        Me.btnAceptar.Location = New System.Drawing.Point(73, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(64, 40)
        Me.btnAceptar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnAceptar, "Accesar")
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Navy
        Me.btnSalir.Image = Global.AstasConta.My.Resources.Resources.salir1
        Me.btnSalir.Location = New System.Drawing.Point(5, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 40)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnSalir, "Salir")
        '
        'cmbCOMPANY
        '
        Me.cmbCOMPANY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbCOMPANY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPANY.DropDownWidth = 400
        Me.cmbCOMPANY.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCOMPANY.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPANY.Location = New System.Drawing.Point(96, 101)
        Me.cmbCOMPANY.Name = "cmbCOMPANY"
        Me.cmbCOMPANY.Size = New System.Drawing.Size(248, 24)
        Me.cmbCOMPANY.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(25, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Compañía :"
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.AcceptsTab = True
        Me.txtPassword.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPassword.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Red
        Me.txtPassword.Location = New System.Drawing.Point(96, 74)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(176)
        Me.txtPassword.Size = New System.Drawing.Size(120, 22)
        Me.txtPassword.TabIndex = 1
        '
        'txtUsuario
        '
        Me.txtUsuario.AcceptsReturn = True
        Me.txtUsuario.AcceptsTab = True
        Me.txtUsuario.BackColor = System.Drawing.Color.Gainsboro
        Me.txtUsuario.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.Blue
        Me.txtUsuario.Location = New System.Drawing.Point(96, 46)
        Me.txtUsuario.MaxLength = 10
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(120, 22)
        Me.txtUsuario.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(16, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(38, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(180, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 30)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Versión"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.AstasConta.My.Resources.Resources.FondoLogin6
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(357, 197)
        Me.Controls.Add(Me.cmbCOMPANY)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TransparencyKey = Color.White
        Lee_Contraseña()
        CargaCompany()
        'Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.IO.Directory.GetCurrentDirectory & "\PPG.ico")
        Dim AppVersion As String = My.Application.Info.Version.ToString
        Dim strVersion As String() = AppVersion.Split(".")
        Dim fechaVersion As Date = CDate("01/01/2000").AddDays(CInt(strVersion(2)))
        Label4.Text &= " " & AppVersion & vbCrLf & "Fecha Versión: " & fechaVersion.ToString("dd/MM/yyyy")
    End Sub

    Private Function Valida_Login() As Boolean
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Usuario_Track As SqlDataReader
        Propietario = "dbo"
        If Me.txtUsuario.Text <> "" And Me.txtPassword.Text <> "" Then
            Sql = "Execute sp_CATALOGO_USUARIOS " & Me.cmbCOMPANY.SelectedValue & ", '" & Trim(Me.txtUsuario.Text) & "', '" & Me.txtPassword.Text & "' , 1 "
            Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
            Try
                Conexion_Track.Open()
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                Usuario_Track = Comando_Track.ExecuteReader()
                If Usuario_Track.Read Then
                    Usuario = Trim(Usuario_Track.Item("USUARIO"))
                    Nombre_Usuario = Trim(Usuario_Track.Item("NOMBRE_USUARIO"))
                    ImagenPath &= "\" & Usuario_Track.Item("LOGO")
                    Compañia = Val(Me.cmbCOMPANY.SelectedValue)
                    Usuario_Track.Close()
                    Conexion_Track.Close()
                    Return True
                Else
                    MsgBox("Acceso Denegado." & vbCrLf & "Verifique la información digitada.", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                Return False
            End Try
        Else
            MsgBox("Favor ingrese 'Usuario' y 'Contraseña' válidos.", MsgBoxStyle.Critical, "Error")
        End If
    End Function

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
            CnnStrBldr.UserID = UsuarioDB
            CnnStrBldr.Password = PasswordDB
            CnnStrBldr.DataSource = Servidor
            CnnStrBldr.InitialCatalog = BaseDatos
            ImagenPath = AppPath '& "\Logo.png"
            IconPath = AppPath & "\icon.ico"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCompany()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_Track.Open()
            Sql = "sp_CATALOGO_COMPAÑIAS '', 0"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPANY.DataSource = Table
            Me.cmbCOMPANY.ValueMember = "COMPAÑIA"
            Me.cmbCOMPANY.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.cmbCOMPANY.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub

    Private Sub TipoCompany()
        Dim DS01 As DataTable
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
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
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter

        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Valida_Login() = True Then
            Dim Prin As New Seguridad_Principal
            AppPath = System.IO.Directory.GetCurrentDirectory
            Me.Hide()
            Prin.Text = Me.cmbCOMPANY.Text
            Prin.tssbtnBarra.DropDownItems.Item(0).Text = "Servidor: " & Servidor
            Prin.tssbtnBarra.DropDownItems.Item(1).Text = "Base de Datos: " & BaseDatos
            Prin.tssbtnBarra.DropDownItems.Item(2).Text = "Usuario: " & Usuario & " - " & Nombre_Usuario
            Descripcion_Compañia = cmbCOMPANY.Text
            Compañia = cmbCOMPANY.SelectedValue
            TipoCompany()
            GetPorcentaje_IVA(1)   'Obtiene el porcentaje del IVA.
            GetPorcentaje_IVA(2)   'Obtiene el porcentaje del Percibido.
            Prin.ShowDialog()
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmLogin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub frmLogin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(sender.MousePosition.X - Me.Location.X - ex, sender.MousePosition.Y - Me.Location.Y - ey))
    End Sub

    Private Sub frmLogin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Arrastre = False
    End Sub
End Class
