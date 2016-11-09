<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_UsuarioBodegas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_UsuarioBodegas))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.dgvAccesos = New System.Windows.Forms.DataGridView
        Me.CodigoUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fact = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Comp = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Invent = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbUSUARIO = New System.Windows.Forms.ComboBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.chkINVENTARIO = New System.Windows.Forms.CheckBox
        Me.chkCOMPRA = New System.Windows.Forms.CheckBox
        Me.chkFACTURA = New System.Windows.Forms.CheckBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 21)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(118, 131)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 13
        Me.pbImagen.TabStop = False
        '
        'dgvAccesos
        '
        Me.dgvAccesos.AllowUserToAddRows = False
        Me.dgvAccesos.AllowUserToDeleteRows = False
        Me.dgvAccesos.AllowUserToResizeColumns = False
        Me.dgvAccesos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvAccesos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAccesos.BackgroundColor = System.Drawing.Color.White
        Me.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoUsuario, Me.Nombre, Me.User, Me.Fact, Me.Comp, Me.Invent, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccesos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAccesos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAccesos.Location = New System.Drawing.Point(0, 161)
        Me.dgvAccesos.MultiSelect = False
        Me.dgvAccesos.Name = "dgvAccesos"
        Me.dgvAccesos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccesos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccesos.Size = New System.Drawing.Size(905, 287)
        Me.dgvAccesos.TabIndex = 12
        '
        'CodigoUsuario
        '
        Me.CodigoUsuario.HeaderText = ""
        Me.CodigoUsuario.Name = "CodigoUsuario"
        Me.CodigoUsuario.ReadOnly = True
        Me.CodigoUsuario.Width = 50
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Descripción Bodega"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'User
        '
        Me.User.HeaderText = "Usuario"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        '
        'Fact
        '
        Me.Fact.HeaderText = "Factura"
        Me.Fact.Name = "Fact"
        Me.Fact.ReadOnly = True
        Me.Fact.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Comp
        '
        Me.Comp.HeaderText = "Compra"
        Me.Comp.Name = "Comp"
        Me.Comp.ReadOnly = True
        '
        'Invent
        '
        Me.Invent.HeaderText = "Inventario"
        Me.Invent.Name = "Invent"
        Me.Invent.ReadOnly = True
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
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.chkINVENTARIO)
        Me.GroupBox1.Controls.Add(Me.chkCOMPRA)
        Me.GroupBox1.Controls.Add(Me.chkFACTURA)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(905, 161)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Usuarios"
        '
        'cmbUSUARIO
        '
        Me.cmbUSUARIO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUSUARIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUSUARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUSUARIO.ForeColor = System.Drawing.Color.Navy
        Me.cmbUSUARIO.FormattingEnabled = True
        Me.cmbUSUARIO.Location = New System.Drawing.Point(203, 48)
        Me.cmbUSUARIO.Name = "cmbUSUARIO"
        Me.cmbUSUARIO.Size = New System.Drawing.Size(376, 24)
        Me.cmbUSUARIO.TabIndex = 15
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(203, 75)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(376, 24)
        Me.cmbBODEGA.TabIndex = 14
        '
        'chkINVENTARIO
        '
        Me.chkINVENTARIO.AutoSize = True
        Me.chkINVENTARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkINVENTARIO.ForeColor = System.Drawing.Color.Red
        Me.chkINVENTARIO.Location = New System.Drawing.Point(395, 101)
        Me.chkINVENTARIO.Name = "chkINVENTARIO"
        Me.chkINVENTARIO.Size = New System.Drawing.Size(74, 20)
        Me.chkINVENTARIO.TabIndex = 4
        Me.chkINVENTARIO.Text = "Inventario"
        Me.chkINVENTARIO.UseVisualStyleBackColor = True
        '
        'chkCOMPRA
        '
        Me.chkCOMPRA.AutoSize = True
        Me.chkCOMPRA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCOMPRA.ForeColor = System.Drawing.Color.Red
        Me.chkCOMPRA.Location = New System.Drawing.Point(299, 101)
        Me.chkCOMPRA.Name = "chkCOMPRA"
        Me.chkCOMPRA.Size = New System.Drawing.Size(65, 20)
        Me.chkCOMPRA.TabIndex = 4
        Me.chkCOMPRA.Text = "Compra"
        Me.chkCOMPRA.UseVisualStyleBackColor = True
        '
        'chkFACTURA
        '
        Me.chkFACTURA.AutoSize = True
        Me.chkFACTURA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFACTURA.ForeColor = System.Drawing.Color.Red
        Me.chkFACTURA.Location = New System.Drawing.Point(203, 101)
        Me.chkFACTURA.Name = "chkFACTURA"
        Me.chkFACTURA.Size = New System.Drawing.Size(63, 20)
        Me.chkFACTURA.TabIndex = 4
        Me.chkFACTURA.Text = "Factura"
        Me.chkFACTURA.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(594, 51)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(69, 24)
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(594, 21)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 24)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(594, 80)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 24)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(131, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bodega :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(131, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Accesos :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(131, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Usuario :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(203, 21)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(376, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(131, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'Seguridad_UsuarioBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 448)
        Me.Controls.Add(Me.dgvAccesos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Seguridad_UsuarioBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad - Catálogo de Usuarios por Bodega"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents dgvAccesos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFACTURA As System.Windows.Forms.CheckBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUSUARIO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkINVENTARIO As System.Windows.Forms.CheckBox
    Friend WithEvents chkCOMPRA As System.Windows.Forms.CheckBox
    Friend WithEvents CodigoUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fact As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Comp As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Invent As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
