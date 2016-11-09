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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Opción")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sub Módulo", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo", New System.Windows.Forms.TreeNode() {TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Menú Principal", New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ilImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.tssbtnBarra = New System.Windows.Forms.ToolStripSplitButton
        Me.ServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OtroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerceroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VersionStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstanciaStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.treeMenu = New System.Windows.Forms.TreeView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
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
        Me.cmMenu.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ilImagenes.Images.SetKeyName(0, "Logo.ico")
        Me.ilImagenes.Images.SetKeyName(1, "forward.gif")
        Me.ilImagenes.Images.SetKeyName(2, "foward.gif")
        Me.ilImagenes.Images.SetKeyName(3, "ok.gif")
        Me.ilImagenes.Images.SetKeyName(4, "bookmark.gif")
        '
        'ssBarra
        '
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssbtnBarra, Me.ToolStripStatusLabel1})
        Me.ssBarra.Location = New System.Drawing.Point(0, 498)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.ShowItemToolTips = True
        Me.ssBarra.Size = New System.Drawing.Size(874, 22)
        Me.ssBarra.TabIndex = 3
        '
        'tssbtnBarra
        '
        Me.tssbtnBarra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbtnBarra.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerToolStripMenuItem, Me.OtroToolStripMenuItem, Me.TerceroToolStripMenuItem, Me.VersionStripMenuItem, Me.InstanciaStripMenuItem})
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
        Me.ServerToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ServerToolStripMenuItem.Text = "Server = "
        Me.ServerToolStripMenuItem.ToolTipText = "Servidor al que está conectado"
        '
        'OtroToolStripMenuItem
        '
        Me.OtroToolStripMenuItem.Image = CType(resources.GetObject("OtroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtroToolStripMenuItem.Name = "OtroToolStripMenuItem"
        Me.OtroToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.OtroToolStripMenuItem.Text = "Otro = "
        Me.OtroToolStripMenuItem.ToolTipText = "Base de datos a la que está conectado"
        '
        'TerceroToolStripMenuItem
        '
        Me.TerceroToolStripMenuItem.Image = CType(resources.GetObject("TerceroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TerceroToolStripMenuItem.Name = "TerceroToolStripMenuItem"
        Me.TerceroToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.TerceroToolStripMenuItem.Text = "Tercero?"
        Me.TerceroToolStripMenuItem.ToolTipText = "Usuario del Sistema actual"
        '
        'VersionStripMenuItem
        '
        Me.VersionStripMenuItem.Image = Global.ASTAS.My.Resources.Resources.version
        Me.VersionStripMenuItem.Name = "VersionStripMenuItem"
        Me.VersionStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.VersionStripMenuItem.Text = "VersionStripMenuItem"
        Me.VersionStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.VersionStripMenuItem.ToolTipText = "Versión Aplicativo"
        '
        'InstanciaStripMenuItem
        '
        Me.InstanciaStripMenuItem.Image = Global.ASTAS.My.Resources.Resources.instancia
        Me.InstanciaStripMenuItem.Name = "InstanciaStripMenuItem"
        Me.InstanciaStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.InstanciaStripMenuItem.Text = "Instancia"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(19, 93)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "MENU"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(20, 498)
        Me.Panel1.TabIndex = 7
        '
        'Button3
        '
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(0, 105)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(19, 136)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "SOPORTE "
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'treeMenu
        '
        Me.treeMenu.BackColor = System.Drawing.Color.White
        Me.treeMenu.ContextMenuStrip = Me.cmMenu
        Me.treeMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.treeMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeMenu.HotTracking = True
        Me.treeMenu.ImageIndex = 4
        Me.treeMenu.ImageList = Me.ilImagenes
        Me.treeMenu.LineColor = System.Drawing.Color.Navy
        Me.treeMenu.Location = New System.Drawing.Point(20, 0)
        Me.treeMenu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.treeMenu.Name = "treeMenu"
        TreeNode1.ImageIndex = 3
        TreeNode1.Name = "Nodo2"
        TreeNode1.Text = "Opción"
        TreeNode2.ImageIndex = 2
        TreeNode2.Name = "Nodo0"
        TreeNode2.Text = "Sub Módulo"
        TreeNode3.ImageIndex = 1
        TreeNode3.Name = "Nodo1"
        TreeNode3.Text = "Módulo"
        TreeNode4.ImageIndex = 4
        TreeNode4.Name = "Nodo0"
        TreeNode4.Text = "Menú Principal"
        Me.treeMenu.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.treeMenu.SelectedImageIndex = 4
        Me.treeMenu.ShowNodeToolTips = True
        Me.treeMenu.Size = New System.Drawing.Size(368, 498)
        Me.treeMenu.TabIndex = 8
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipTitle = "Ocultar y Mostrar Menú Principal"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "MENU PRINCIPAL"
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
        Me.PictureMantenimiento.Location = New System.Drawing.Point(227, 138)
        Me.PictureMantenimiento.Name = "PictureMantenimiento"
        Me.PictureMantenimiento.Size = New System.Drawing.Size(647, 184)
        Me.PictureMantenimiento.TabIndex = 12
        Me.PictureMantenimiento.TabStop = False
        Me.PictureMantenimiento.Visible = False
        '
        'Seguridad_Principal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(874, 520)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.treeMenu)
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
        Me.Text = "2015"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cmMenu.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents treeMenu As System.Windows.Forms.TreeView
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents VersionStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstanciaStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
