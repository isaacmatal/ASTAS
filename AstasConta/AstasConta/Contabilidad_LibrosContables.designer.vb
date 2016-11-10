<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_LibrosContables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_LibrosContables))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkLIBRO_PRINCIPAL = New System.Windows.Forms.CheckBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.txtLIBRO_CONTABLE_INICIALES = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_LIBRO_CONTABLE = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLIBRO_CONTABLE = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvLibros_Contables = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Iniciales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMenu_Eliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.ttipMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLibros_Contables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmMenu.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkLIBRO_PRINCIPAL)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.txtLIBRO_CONTABLE_INICIALES)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_LIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(112, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(464, 152)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Libros Contables"
        '
        'chkLIBRO_PRINCIPAL
        '
        Me.chkLIBRO_PRINCIPAL.AutoSize = True
        Me.chkLIBRO_PRINCIPAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkLIBRO_PRINCIPAL.ForeColor = System.Drawing.Color.Red
        Me.chkLIBRO_PRINCIPAL.Location = New System.Drawing.Point(160, 122)
        Me.chkLIBRO_PRINCIPAL.Name = "chkLIBRO_PRINCIPAL"
        Me.chkLIBRO_PRINCIPAL.Size = New System.Drawing.Size(94, 20)
        Me.chkLIBRO_PRINCIPAL.TabIndex = 7
        Me.chkLIBRO_PRINCIPAL.Text = "Libro Principal"
        Me.chkLIBRO_PRINCIPAL.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(152, 48)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttipMensaje.SetToolTip(Me.btnNuevo, "Limpia los campos relacionados para ingresar neuva información")
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(296, 48)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "&Eiminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttipMensaje.SetToolTip(Me.btnEliminar, "Elimina el Libro Contable seleccionado")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(224, 48)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttipMensaje.SetToolTip(Me.btnGuardar, "Guardar un Libro Contable")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtLIBRO_CONTABLE_INICIALES
        '
        Me.txtLIBRO_CONTABLE_INICIALES.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIBRO_CONTABLE_INICIALES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIBRO_CONTABLE_INICIALES.ForeColor = System.Drawing.Color.Navy
        Me.txtLIBRO_CONTABLE_INICIALES.Location = New System.Drawing.Point(80, 120)
        Me.txtLIBRO_CONTABLE_INICIALES.MaxLength = 2
        Me.txtLIBRO_CONTABLE_INICIALES.Name = "txtLIBRO_CONTABLE_INICIALES"
        Me.txtLIBRO_CONTABLE_INICIALES.Size = New System.Drawing.Size(72, 22)
        Me.txtLIBRO_CONTABLE_INICIALES.TabIndex = 1
        Me.ttipMensaje.SetToolTip(Me.txtLIBRO_CONTABLE_INICIALES, "Identificador del Libro Contable")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(3, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Iniciales :"
        '
        'txtDESCRIPCION_LIBRO_CONTABLE
        '
        Me.txtDESCRIPCION_LIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_LIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Location = New System.Drawing.Point(80, 72)
        Me.txtDESCRIPCION_LIBRO_CONTABLE.MaxLength = 100
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Multiline = True
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Name = "txtDESCRIPCION_LIBRO_CONTABLE"
        Me.txtDESCRIPCION_LIBRO_CONTABLE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Size = New System.Drawing.Size(376, 48)
        Me.txtDESCRIPCION_LIBRO_CONTABLE.TabIndex = 0
        Me.ttipMensaje.SetToolTip(Me.txtDESCRIPCION_LIBRO_CONTABLE, "Descripción o nombre del Libro Contable")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(3, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción :"
        '
        'txtLIBRO_CONTABLE
        '
        Me.txtLIBRO_CONTABLE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Red
        Me.txtLIBRO_CONTABLE.Location = New System.Drawing.Point(80, 48)
        Me.txtLIBRO_CONTABLE.Name = "txtLIBRO_CONTABLE"
        Me.txtLIBRO_CONTABLE.ReadOnly = True
        Me.txtLIBRO_CONTABLE.Size = New System.Drawing.Size(72, 22)
        Me.txtLIBRO_CONTABLE.TabIndex = 3
        Me.ttipMensaje.SetToolTip(Me.txtLIBRO_CONTABLE, "Código asignado al Libro Contable")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código LC :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(80, 24)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(376, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        Me.ttipMensaje.SetToolTip(Me.cmbCOMPAÑIA, "Nombre de la Compañía con la cual se trabajará actualmente")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'dgvLibros_Contables
        '
        Me.dgvLibros_Contables.AllowUserToAddRows = False
        Me.dgvLibros_Contables.AllowUserToDeleteRows = False
        Me.dgvLibros_Contables.AllowUserToResizeColumns = False
        Me.dgvLibros_Contables.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvLibros_Contables.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLibros_Contables.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvLibros_Contables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLibros_Contables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripción, Me.Iniciales, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLibros_Contables.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLibros_Contables.Location = New System.Drawing.Point(10, 168)
        Me.dgvLibros_Contables.MultiSelect = False
        Me.dgvLibros_Contables.Name = "dgvLibros_Contables"
        Me.dgvLibros_Contables.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLibros_Contables.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLibros_Contables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLibros_Contables.Size = New System.Drawing.Size(564, 209)
        Me.dgvLibros_Contables.TabIndex = 1
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Descripción"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        '
        'Iniciales
        '
        Me.Iniciales.HeaderText = "Iniciales"
        Me.Iniciales.Name = "Iniciales"
        Me.Iniciales.ReadOnly = True
        '
        'UsuarioC
        '
        Me.UsuarioC.HeaderText = "Usuario Creación"
        Me.UsuarioC.Name = "UsuarioC"
        Me.UsuarioC.ReadOnly = True
        '
        'FechaC
        '
        Me.FechaC.HeaderText = "Fecha Creación"
        Me.FechaC.Name = "FechaC"
        Me.FechaC.ReadOnly = True
        '
        'cmMenu
        '
        Me.cmMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMenu_Eliminar})
        Me.cmMenu.Name = "cmMenu"
        Me.cmMenu.Size = New System.Drawing.Size(118, 26)
        '
        'miMenu_Eliminar
        '
        Me.miMenu_Eliminar.Name = "miMenu_Eliminar"
        Me.miMenu_Eliminar.Size = New System.Drawing.Size(117, 22)
        Me.miMenu_Eliminar.Text = "Eliminar"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(10, 12)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(96, 152)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 2
        Me.pbImagen.TabStop = False
        '
        'Contabilidad_LibrosContables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 389)
        Me.Controls.Add(Me.dgvLibros_Contables)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbImagen)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_LibrosContables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Catálogo de Libros Contables"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvLibros_Contables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmMenu.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDESCRIPCION_LIBRO_CONTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLIBRO_CONTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtLIBRO_CONTABLE_INICIALES As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvLibros_Contables As System.Windows.Forms.DataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Iniciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMenu_Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents ttipMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents chkLIBRO_PRINCIPAL As System.Windows.Forms.CheckBox

End Class
