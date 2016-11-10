<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_Principal))
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ilImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.tssbtnBarra = New System.Windows.Forms.ToolStripSplitButton
        Me.ServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OtroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerceroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuHelpText = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureMantenimiento = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmMenu.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmMenu
        '
        Me.cmMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem})
        Me.cmMenu.Name = "cmMenu"
        Me.cmMenu.Size = New System.Drawing.Size(127, 26)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'ilImagenes
        '
        Me.ilImagenes.ImageStream = CType(resources.GetObject("ilImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ilImagenes.Images.SetKeyName(0, "view_remove.gif")
        Me.ilImagenes.Images.SetKeyName(1, "note05.ico")
        Me.ilImagenes.Images.SetKeyName(2, "crdfle07.ico")
        Me.ilImagenes.Images.SetKeyName(3, "bullseye.ico")
        Me.ilImagenes.Images.SetKeyName(4, "house.ico")
        Me.ilImagenes.Images.SetKeyName(5, "fonts.gif")
        Me.ilImagenes.Images.SetKeyName(6, "note01.ico")
        Me.ilImagenes.Images.SetKeyName(7, "fire.ico")
        Me.ilImagenes.Images.SetKeyName(8, "note16.ico")
        Me.ilImagenes.Images.SetKeyName(9, "w95mbx01.ico")
        Me.ilImagenes.Images.SetKeyName(10, "graph15.ico")
        Me.ilImagenes.Images.SetKeyName(11, "labels.ico")
        Me.ilImagenes.Images.SetKeyName(12, "pen01.ico")
        Me.ilImagenes.Images.SetKeyName(13, "pen03.ico")
        Me.ilImagenes.Images.SetKeyName(14, "pen05.ico")
        Me.ilImagenes.Images.SetKeyName(15, "nethood.ico")
        Me.ilImagenes.Images.SetKeyName(16, "newtodo.gif")
        Me.ilImagenes.Images.SetKeyName(17, "secur02a.ico")
        Me.ilImagenes.Images.SetKeyName(18, "book06.ico")
        Me.ilImagenes.Images.SetKeyName(19, "books02.ico")
        Me.ilImagenes.Images.SetKeyName(20, "clip07.ico")
        Me.ilImagenes.Images.SetKeyName(21, "clip06.ico")
        Me.ilImagenes.Images.SetKeyName(22, "view_text.gif")
        Me.ilImagenes.Images.SetKeyName(23, "note16.ico")
        Me.ilImagenes.Images.SetKeyName(24, "note14.ico")
        Me.ilImagenes.Images.SetKeyName(25, "lock.gif")
        Me.ilImagenes.Images.SetKeyName(26, "contents.gif")
        Me.ilImagenes.Images.SetKeyName(27, "excel_2.ico")
        Me.ilImagenes.Images.SetKeyName(28, "view_left_right.gif")
        Me.ilImagenes.Images.SetKeyName(29, "klipper_dock.gif")
        Me.ilImagenes.Images.SetKeyName(30, "net01.ico")
        Me.ilImagenes.Images.SetKeyName(31, "secur05.ico")
        Me.ilImagenes.Images.SetKeyName(32, "reload_page.gif")
        Me.ilImagenes.Images.SetKeyName(33, "mail02a.ico")
        Me.ilImagenes.Images.SetKeyName(34, "cheque.jpg")
        Me.ilImagenes.Images.SetKeyName(35, "chequelist.jpg")
        Me.ilImagenes.Images.SetKeyName(36, "user.jpg")
        Me.ilImagenes.Images.SetKeyName(37, "user1.jpg")
        Me.ilImagenes.Images.SetKeyName(38, "options.jpg")
        Me.ilImagenes.Images.SetKeyName(39, "secur08.ico")
        Me.ilImagenes.Images.SetKeyName(40, "cafe.jpg")
        Me.ilImagenes.Images.SetKeyName(41, "cierre_libros.png")
        '
        'ssBarra
        '
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssbtnBarra, Me.MenuHelpText, Me.ToolStripStatusLabel1})
        Me.ssBarra.Location = New System.Drawing.Point(0, 498)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.ShowItemToolTips = True
        Me.ssBarra.Size = New System.Drawing.Size(874, 22)
        Me.ssBarra.TabIndex = 3
        '
        'tssbtnBarra
        '
        Me.tssbtnBarra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbtnBarra.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerToolStripMenuItem, Me.OtroToolStripMenuItem, Me.TerceroToolStripMenuItem})
        Me.tssbtnBarra.Image = CType(resources.GetObject("tssbtnBarra.Image"), System.Drawing.Image)
        Me.tssbtnBarra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssbtnBarra.Name = "tssbtnBarra"
        Me.tssbtnBarra.Size = New System.Drawing.Size(32, 20)
        Me.tssbtnBarra.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.tssbtnBarra.ToolTipText = "Datos de Conexión"
        '
        'ServerToolStripMenuItem
        '
        Me.ServerToolStripMenuItem.Image = CType(resources.GetObject("ServerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem"
        Me.ServerToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ServerToolStripMenuItem.Text = "Server = "
        Me.ServerToolStripMenuItem.ToolTipText = "Servidor al que está conectado"
        '
        'OtroToolStripMenuItem
        '
        Me.OtroToolStripMenuItem.Image = CType(resources.GetObject("OtroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtroToolStripMenuItem.Name = "OtroToolStripMenuItem"
        Me.OtroToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.OtroToolStripMenuItem.Text = "Usuario = "
        Me.OtroToolStripMenuItem.ToolTipText = "Base de datos a la que está conectado"
        '
        'TerceroToolStripMenuItem
        '
        Me.TerceroToolStripMenuItem.Image = CType(resources.GetObject("TerceroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TerceroToolStripMenuItem.Name = "TerceroToolStripMenuItem"
        Me.TerceroToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.TerceroToolStripMenuItem.Text = "Base datos ="
        Me.TerceroToolStripMenuItem.ToolTipText = "Usuario del Sistema actual"
        '
        'MenuHelpText
        '
        Me.MenuHelpText.Name = "MenuHelpText"
        Me.MenuHelpText.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipTitle = "Ocultar y Mostrar Menú Principal"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Location = New System.Drawing.Point(394, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(371, 204)
        Me.Panel2.TabIndex = 14
        Me.Panel2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mensaje:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Asunto:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(3, 59)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(308, 22)
        Me.TextBox2.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(317, 170)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 30)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Leido!"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 34)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 102)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(308, 98)
        Me.TextBox1.TabIndex = 1
        '
        'PictureMantenimiento
        '
        Me.PictureMantenimiento.BackColor = System.Drawing.Color.Transparent
        Me.PictureMantenimiento.Image = CType(resources.GetObject("PictureMantenimiento.Image"), System.Drawing.Image)
        Me.PictureMantenimiento.Location = New System.Drawing.Point(151, 173)
        Me.PictureMantenimiento.Name = "PictureMantenimiento"
        Me.PictureMantenimiento.Size = New System.Drawing.Size(647, 184)
        Me.PictureMantenimiento.TabIndex = 12
        Me.PictureMantenimiento.TabStop = False
        Me.PictureMantenimiento.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(20, 498)
        Me.Panel1.TabIndex = 7
        '
        'Seguridad_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(874, 520)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.PictureMantenimiento)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Seguridad_Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "2014"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cmMenu.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilImagenes As System.Windows.Forms.ImageList
    Friend WithEvents cmMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents tssbtnBarra As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents OtroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerceroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureMantenimiento As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuHelpText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
