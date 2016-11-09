<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_Usuarios))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkPuedeProcesar = New System.Windows.Forms.CheckBox
        Me.chkPuedeAutorizar = New System.Windows.Forms.CheckBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.chkACTIVO = New System.Windows.Forms.CheckBox
        Me.txtCONTRASEÑA_CONFIRMA = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCONTRASEÑA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.txtNOMBRE_USUARIO = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUSUARIO = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView
        Me.CodigoUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Activo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPuedeProcesar)
        Me.GroupBox1.Controls.Add(Me.chkPuedeAutorizar)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.chkACTIVO)
        Me.GroupBox1.Controls.Add(Me.txtCONTRASEÑA_CONFIRMA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCONTRASEÑA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.txtNOMBRE_USUARIO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUSUARIO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 183)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Usuarios"
        '
        'chkPuedeProcesar
        '
        Me.chkPuedeProcesar.AutoSize = True
        Me.chkPuedeProcesar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPuedeProcesar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkPuedeProcesar.ForeColor = System.Drawing.Color.Red
        Me.chkPuedeProcesar.Location = New System.Drawing.Point(470, 145)
        Me.chkPuedeProcesar.Name = "chkPuedeProcesar"
        Me.chkPuedeProcesar.Size = New System.Drawing.Size(172, 20)
        Me.chkPuedeProcesar.TabIndex = 15
        Me.chkPuedeProcesar.Text = "Puede Procesar Requisiciones"
        Me.chkPuedeProcesar.UseVisualStyleBackColor = True
        '
        'chkPuedeAutorizar
        '
        Me.chkPuedeAutorizar.AutoSize = True
        Me.chkPuedeAutorizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkPuedeAutorizar.ForeColor = System.Drawing.Color.Red
        Me.chkPuedeAutorizar.Location = New System.Drawing.Point(268, 145)
        Me.chkPuedeAutorizar.Name = "chkPuedeAutorizar"
        Me.chkPuedeAutorizar.Size = New System.Drawing.Size(171, 20)
        Me.chkPuedeAutorizar.TabIndex = 14
        Me.chkPuedeAutorizar.Text = "Puede Autorizar Requisiciones"
        Me.chkPuedeAutorizar.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 21)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(135, 152)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 10
        Me.pbImagen.TabStop = False
        '
        'chkACTIVO
        '
        Me.chkACTIVO.AutoSize = True
        Me.chkACTIVO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkACTIVO.Checked = True
        Me.chkACTIVO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkACTIVO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkACTIVO.ForeColor = System.Drawing.Color.Red
        Me.chkACTIVO.Location = New System.Drawing.Point(547, 101)
        Me.chkACTIVO.Name = "chkACTIVO"
        Me.chkACTIVO.Size = New System.Drawing.Size(95, 20)
        Me.chkACTIVO.TabIndex = 4
        Me.chkACTIVO.Text = "Usuario Activo"
        Me.chkACTIVO.UseVisualStyleBackColor = True
        '
        'txtCONTRASEÑA_CONFIRMA
        '
        Me.txtCONTRASEÑA_CONFIRMA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONTRASEÑA_CONFIRMA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCONTRASEÑA_CONFIRMA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTRASEÑA_CONFIRMA.ForeColor = System.Drawing.Color.Red
        Me.txtCONTRASEÑA_CONFIRMA.Location = New System.Drawing.Point(267, 117)
        Me.txtCONTRASEÑA_CONFIRMA.MaxLength = 15
        Me.txtCONTRASEÑA_CONFIRMA.Name = "txtCONTRASEÑA_CONFIRMA"
        Me.txtCONTRASEÑA_CONFIRMA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(176)
        Me.txtCONTRASEÑA_CONFIRMA.Size = New System.Drawing.Size(104, 22)
        Me.txtCONTRASEÑA_CONFIRMA.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(147, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Confirme Contraseña :"
        '
        'txtCONTRASEÑA
        '
        Me.txtCONTRASEÑA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONTRASEÑA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCONTRASEÑA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTRASEÑA.ForeColor = System.Drawing.Color.Red
        Me.txtCONTRASEÑA.Location = New System.Drawing.Point(267, 93)
        Me.txtCONTRASEÑA.MaxLength = 15
        Me.txtCONTRASEÑA.Name = "txtCONTRASEÑA"
        Me.txtCONTRASEÑA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(176)
        Me.txtCONTRASEÑA.Size = New System.Drawing.Size(104, 22)
        Me.txtCONTRASEÑA.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(147, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Ingrese Contraseña :"
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(467, 45)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(80, 24)
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(563, 45)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "&Eiminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(371, 45)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 24)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtNOMBRE_USUARIO
        '
        Me.txtNOMBRE_USUARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtNOMBRE_USUARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOMBRE_USUARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtNOMBRE_USUARIO.Location = New System.Drawing.Point(267, 69)
        Me.txtNOMBRE_USUARIO.MaxLength = 100
        Me.txtNOMBRE_USUARIO.Name = "txtNOMBRE_USUARIO"
        Me.txtNOMBRE_USUARIO.Size = New System.Drawing.Size(376, 22)
        Me.txtNOMBRE_USUARIO.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(147, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre :"
        '
        'txtUSUARIO
        '
        Me.txtUSUARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUARIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUSUARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtUSUARIO.Location = New System.Drawing.Point(267, 45)
        Me.txtUSUARIO.MaxLength = 12
        Me.txtUSUARIO.Name = "txtUSUARIO"
        Me.txtUSUARIO.Size = New System.Drawing.Size(104, 22)
        Me.txtUSUARIO.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(147, 45)
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
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(267, 21)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(376, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(147, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AllowUserToResizeColumns = False
        Me.dgvUsuarios.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvUsuarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUsuarios.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoUsuario, Me.Nombre, Me.Activo, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUsuarios.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(3, 18)
        Me.dgvUsuarios.MultiSelect = False
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(787, 274)
        Me.dgvUsuarios.TabIndex = 8
        '
        'CodigoUsuario
        '
        Me.CodigoUsuario.HeaderText = "Usuario"
        Me.CodigoUsuario.Name = "CodigoUsuario"
        Me.CodigoUsuario.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre Usuario"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Activo
        '
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.ReadOnly = True
        Me.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvUsuarios)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(793, 295)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'Seguridad_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 478)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Seguridad_Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad - Catálogo de Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtNOMBRE_USUARIO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUSUARIO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCONTRASEÑA_CONFIRMA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCONTRASEÑA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkACTIVO As System.Windows.Forms.CheckBox
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents CodigoUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPuedeProcesar As System.Windows.Forms.CheckBox
    Friend WithEvents chkPuedeAutorizar As System.Windows.Forms.CheckBox
End Class
