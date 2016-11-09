<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Accesos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_Accesos))
        Me.dgvAccesos = New System.Windows.Forms.DataGridView
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Iniciales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Opcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbUSUARIO = New System.Windows.Forms.ComboBox
        Me.cmbOPCION = New System.Windows.Forms.ComboBox
        Me.cmbSUBMODULO = New System.Windows.Forms.ComboBox
        Me.cmbMODULO = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAccesos
        '
        Me.dgvAccesos.AllowUserToAddRows = False
        Me.dgvAccesos.AllowUserToDeleteRows = False
        Me.dgvAccesos.AllowUserToResizeColumns = False
        Me.dgvAccesos.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvAccesos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAccesos.BackgroundColor = System.Drawing.Color.White
        Me.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripción, Me.Iniciales, Me.Opcion, Me.Codigo, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccesos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAccesos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAccesos.GridColor = System.Drawing.Color.Black
        Me.dgvAccesos.Location = New System.Drawing.Point(0, 181)
        Me.dgvAccesos.MultiSelect = False
        Me.dgvAccesos.Name = "dgvAccesos"
        Me.dgvAccesos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccesos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAccesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccesos.Size = New System.Drawing.Size(804, 387)
        Me.dgvAccesos.TabIndex = 7
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Módulo"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        '
        'Iniciales
        '
        Me.Iniciales.HeaderText = "Sub Módulo"
        Me.Iniciales.Name = "Iniciales"
        Me.Iniciales.ReadOnly = True
        '
        'Opcion
        '
        Me.Opcion.HeaderText = "Opción"
        Me.Opcion.Name = "Opcion"
        Me.Opcion.ReadOnly = True
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Usuario"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.cmbUSUARIO)
        Me.GroupBox1.Controls.Add(Me.cmbOPCION)
        Me.GroupBox1.Controls.Add(Me.cmbSUBMODULO)
        Me.GroupBox1.Controls.Add(Me.cmbMODULO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(804, 181)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de accesos a usuarios"
        '
        'cmbUSUARIO
        '
        Me.cmbUSUARIO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUSUARIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUSUARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUSUARIO.ForeColor = System.Drawing.Color.Navy
        Me.cmbUSUARIO.FormattingEnabled = True
        Me.cmbUSUARIO.Location = New System.Drawing.Point(213, 48)
        Me.cmbUSUARIO.Name = "cmbUSUARIO"
        Me.cmbUSUARIO.Size = New System.Drawing.Size(376, 24)
        Me.cmbUSUARIO.TabIndex = 12
        '
        'cmbOPCION
        '
        Me.cmbOPCION.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOPCION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOPCION.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOPCION.ForeColor = System.Drawing.Color.Navy
        Me.cmbOPCION.FormattingEnabled = True
        Me.cmbOPCION.Location = New System.Drawing.Point(213, 122)
        Me.cmbOPCION.Name = "cmbOPCION"
        Me.cmbOPCION.Size = New System.Drawing.Size(376, 24)
        Me.cmbOPCION.TabIndex = 12
        '
        'cmbSUBMODULO
        '
        Me.cmbSUBMODULO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSUBMODULO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSUBMODULO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSUBMODULO.ForeColor = System.Drawing.Color.Navy
        Me.cmbSUBMODULO.FormattingEnabled = True
        Me.cmbSUBMODULO.Location = New System.Drawing.Point(213, 98)
        Me.cmbSUBMODULO.Name = "cmbSUBMODULO"
        Me.cmbSUBMODULO.Size = New System.Drawing.Size(376, 24)
        Me.cmbSUBMODULO.TabIndex = 12
        '
        'cmbMODULO
        '
        Me.cmbMODULO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMODULO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMODULO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMODULO.ForeColor = System.Drawing.Color.Navy
        Me.cmbMODULO.FormattingEnabled = True
        Me.cmbMODULO.Location = New System.Drawing.Point(213, 74)
        Me.cmbMODULO.Name = "cmbMODULO"
        Me.cmbMODULO.Size = New System.Drawing.Size(376, 24)
        Me.cmbMODULO.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(141, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Usuario :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(141, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Opción :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(141, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Sub Módulo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(141, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Módulo :"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(509, 152)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "&Eiminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(213, 152)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 24)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(213, 24)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(376, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(141, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 24)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(120, 140)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 11
        Me.pbImagen.TabStop = False
        '
        'Seguridad_Accesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 568)
        Me.Controls.Add(Me.dgvAccesos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Seguridad_Accesos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad - Seguridad de Accesos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAccesos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMODULO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUSUARIO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOPCION As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSUBMODULO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Iniciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Opcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
End Class
