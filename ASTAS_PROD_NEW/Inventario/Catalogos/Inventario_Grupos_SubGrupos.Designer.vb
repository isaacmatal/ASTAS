<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Grupos_SubGrupos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Grupos_SubGrupos))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkPertenece = New System.Windows.Forms.CheckBox
        Me.AutoOrdenamiento = New System.Windows.Forms.CheckBox
        Me.txtMARGEN = New System.Windows.Forms.TextBox
        Me.chkMARGEN = New System.Windows.Forms.CheckBox
        Me.btnNuevoGrupos = New System.Windows.Forms.Button
        Me.btnGuardarGrupos = New System.Windows.Forms.Button
        Me.btnEliminarGrupos = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_GRUPO = New System.Windows.Forms.TextBox
        Me.lblGRUPO = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtdescmaximo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.AutoOrdenamiento2 = New System.Windows.Forms.CheckBox
        Me.lblSUB_GRUPO = New System.Windows.Forms.Label
        Me.btnGuardarSubGrupos = New System.Windows.Forms.Button
        Me.btnNuevoSubGrupos = New System.Windows.Forms.Button
        Me.btnEliminarSubGrupos = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_SUB_GRUPO = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvSubGrupos = New System.Windows.Forms.DataGridView
        Me.dgvGrupos = New System.Windows.Forms.DataGridView
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSubGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPertenece)
        Me.GroupBox1.Controls.Add(Me.AutoOrdenamiento)
        Me.GroupBox1.Controls.Add(Me.txtMARGEN)
        Me.GroupBox1.Controls.Add(Me.chkMARGEN)
        Me.GroupBox1.Controls.Add(Me.btnNuevoGrupos)
        Me.GroupBox1.Controls.Add(Me.btnGuardarGrupos)
        Me.GroupBox1.Controls.Add(Me.btnEliminarGrupos)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_GRUPO)
        Me.GroupBox1.Controls.Add(Me.lblGRUPO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(614, 99)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Grupos de productos"
        '
        'chkPertenece
        '
        Me.chkPertenece.AutoSize = True
        Me.chkPertenece.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkPertenece.ForeColor = System.Drawing.Color.Red
        Me.chkPertenece.Location = New System.Drawing.Point(378, 74)
        Me.chkPertenece.Name = "chkPertenece"
        Me.chkPertenece.Size = New System.Drawing.Size(69, 20)
        Me.chkPertenece.TabIndex = 104
        Me.chkPertenece.Text = "Cafeteria"
        Me.chkPertenece.UseVisualStyleBackColor = True
        '
        'AutoOrdenamiento
        '
        Me.AutoOrdenamiento.AutoSize = True
        Me.AutoOrdenamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AutoOrdenamiento.Location = New System.Drawing.Point(453, 76)
        Me.AutoOrdenamiento.Name = "AutoOrdenamiento"
        Me.AutoOrdenamiento.Size = New System.Drawing.Size(126, 20)
        Me.AutoOrdenamiento.TabIndex = 103
        Me.AutoOrdenamiento.Text = "AutoOrdenamiento"
        Me.AutoOrdenamiento.UseVisualStyleBackColor = False
        Me.AutoOrdenamiento.Visible = False
        '
        'txtMARGEN
        '
        Me.txtMARGEN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMARGEN.Enabled = False
        Me.txtMARGEN.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMARGEN.ForeColor = System.Drawing.Color.Navy
        Me.txtMARGEN.Location = New System.Drawing.Point(272, 72)
        Me.txtMARGEN.Name = "txtMARGEN"
        Me.txtMARGEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMARGEN.Size = New System.Drawing.Size(100, 22)
        Me.txtMARGEN.TabIndex = 2
        Me.txtMARGEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkMARGEN
        '
        Me.chkMARGEN.AutoSize = True
        Me.chkMARGEN.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkMARGEN.ForeColor = System.Drawing.Color.Red
        Me.chkMARGEN.Location = New System.Drawing.Point(96, 72)
        Me.chkMARGEN.Name = "chkMARGEN"
        Me.chkMARGEN.Size = New System.Drawing.Size(177, 20)
        Me.chkMARGEN.TabIndex = 23
        Me.chkMARGEN.Text = "Controla Margen de Precio (%)"
        Me.chkMARGEN.UseVisualStyleBackColor = True
        '
        'btnNuevoGrupos
        '
        Me.btnNuevoGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevoGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoGrupos.Image = CType(resources.GetObject("btnNuevoGrupos.Image"), System.Drawing.Image)
        Me.btnNuevoGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoGrupos.Location = New System.Drawing.Point(176, 24)
        Me.btnNuevoGrupos.Name = "btnNuevoGrupos"
        Me.btnNuevoGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevoGrupos.TabIndex = 0
        Me.btnNuevoGrupos.Text = "&Nuevo"
        Me.btnNuevoGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoGrupos.UseVisualStyleBackColor = True
        '
        'btnGuardarGrupos
        '
        Me.btnGuardarGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardarGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarGrupos.Image = CType(resources.GetObject("btnGuardarGrupos.Image"), System.Drawing.Image)
        Me.btnGuardarGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarGrupos.Location = New System.Drawing.Point(256, 24)
        Me.btnGuardarGrupos.Name = "btnGuardarGrupos"
        Me.btnGuardarGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardarGrupos.TabIndex = 3
        Me.btnGuardarGrupos.Text = "&Guardar"
        Me.btnGuardarGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarGrupos.UseVisualStyleBackColor = True
        '
        'btnEliminarGrupos
        '
        Me.btnEliminarGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminarGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminarGrupos.Image = CType(resources.GetObject("btnEliminarGrupos.Image"), System.Drawing.Image)
        Me.btnEliminarGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarGrupos.Location = New System.Drawing.Point(336, 24)
        Me.btnEliminarGrupos.Name = "btnEliminarGrupos"
        Me.btnEliminarGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminarGrupos.TabIndex = 4
        Me.btnEliminarGrupos.Text = "&Eliminar"
        Me.btnEliminarGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarGrupos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción :"
        '
        'txtDESCRIPCION_GRUPO
        '
        Me.txtDESCRIPCION_GRUPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_GRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_GRUPO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_GRUPO.Location = New System.Drawing.Point(96, 48)
        Me.txtDESCRIPCION_GRUPO.Name = "txtDESCRIPCION_GRUPO"
        Me.txtDESCRIPCION_GRUPO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_GRUPO.Size = New System.Drawing.Size(408, 22)
        Me.txtDESCRIPCION_GRUPO.TabIndex = 1
        '
        'lblGRUPO
        '
        Me.lblGRUPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblGRUPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGRUPO.ForeColor = System.Drawing.Color.Red
        Me.lblGRUPO.Location = New System.Drawing.Point(96, 25)
        Me.lblGRUPO.Name = "lblGRUPO"
        Me.lblGRUPO.Size = New System.Drawing.Size(72, 22)
        Me.lblGRUPO.TabIndex = 2
        Me.lblGRUPO.Text = "0"
        Me.lblGRUPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Grupo :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtdescmaximo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.AutoOrdenamiento2)
        Me.GroupBox2.Controls.Add(Me.lblSUB_GRUPO)
        Me.GroupBox2.Controls.Add(Me.btnGuardarSubGrupos)
        Me.GroupBox2.Controls.Add(Me.btnNuevoSubGrupos)
        Me.GroupBox2.Controls.Add(Me.btnEliminarSubGrupos)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDESCRIPCION_SUB_GRUPO)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(6, 267)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 105)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Registro de Sub Grupos de productos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(220, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 16)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "%"
        '
        'txtdescmaximo
        '
        Me.txtdescmaximo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescmaximo.ForeColor = System.Drawing.Color.Navy
        Me.txtdescmaximo.Location = New System.Drawing.Point(176, 74)
        Me.txtdescmaximo.Name = "txtdescmaximo"
        Me.txtdescmaximo.Size = New System.Drawing.Size(42, 22)
        Me.txtdescmaximo.TabIndex = 106
        Me.txtdescmaximo.Text = "0"
        Me.txtdescmaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(9, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 16)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "% Máximo de Descuento :"
        '
        'AutoOrdenamiento2
        '
        Me.AutoOrdenamiento2.AutoSize = True
        Me.AutoOrdenamiento2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AutoOrdenamiento2.Location = New System.Drawing.Point(457, 27)
        Me.AutoOrdenamiento2.Name = "AutoOrdenamiento2"
        Me.AutoOrdenamiento2.Size = New System.Drawing.Size(126, 20)
        Me.AutoOrdenamiento2.TabIndex = 104
        Me.AutoOrdenamiento2.Text = "AutoOrdenamiento"
        Me.AutoOrdenamiento2.UseVisualStyleBackColor = False
        Me.AutoOrdenamiento2.Visible = False
        '
        'lblSUB_GRUPO
        '
        Me.lblSUB_GRUPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSUB_GRUPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSUB_GRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSUB_GRUPO.ForeColor = System.Drawing.Color.Red
        Me.lblSUB_GRUPO.Location = New System.Drawing.Point(96, 25)
        Me.lblSUB_GRUPO.Name = "lblSUB_GRUPO"
        Me.lblSUB_GRUPO.Size = New System.Drawing.Size(72, 22)
        Me.lblSUB_GRUPO.TabIndex = 21
        Me.lblSUB_GRUPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardarSubGrupos
        '
        Me.btnGuardarSubGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardarSubGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarSubGrupos.Image = CType(resources.GetObject("btnGuardarSubGrupos.Image"), System.Drawing.Image)
        Me.btnGuardarSubGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarSubGrupos.Location = New System.Drawing.Point(256, 24)
        Me.btnGuardarSubGrupos.Name = "btnGuardarSubGrupos"
        Me.btnGuardarSubGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardarSubGrupos.TabIndex = 2
        Me.btnGuardarSubGrupos.Text = "Guardar"
        Me.btnGuardarSubGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarSubGrupos.UseVisualStyleBackColor = True
        '
        'btnNuevoSubGrupos
        '
        Me.btnNuevoSubGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevoSubGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoSubGrupos.Image = CType(resources.GetObject("btnNuevoSubGrupos.Image"), System.Drawing.Image)
        Me.btnNuevoSubGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoSubGrupos.Location = New System.Drawing.Point(176, 24)
        Me.btnNuevoSubGrupos.Name = "btnNuevoSubGrupos"
        Me.btnNuevoSubGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevoSubGrupos.TabIndex = 0
        Me.btnNuevoSubGrupos.Text = "Nuevo"
        Me.btnNuevoSubGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoSubGrupos.UseVisualStyleBackColor = True
        '
        'btnEliminarSubGrupos
        '
        Me.btnEliminarSubGrupos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminarSubGrupos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminarSubGrupos.Image = CType(resources.GetObject("btnEliminarSubGrupos.Image"), System.Drawing.Image)
        Me.btnEliminarSubGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarSubGrupos.Location = New System.Drawing.Point(336, 24)
        Me.btnEliminarSubGrupos.Name = "btnEliminarSubGrupos"
        Me.btnEliminarSubGrupos.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminarSubGrupos.TabIndex = 3
        Me.btnEliminarSubGrupos.Text = "Eliminar"
        Me.btnEliminarSubGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarSubGrupos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descripción :"
        '
        'txtDESCRIPCION_SUB_GRUPO
        '
        Me.txtDESCRIPCION_SUB_GRUPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_SUB_GRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_SUB_GRUPO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_SUB_GRUPO.Location = New System.Drawing.Point(96, 48)
        Me.txtDESCRIPCION_SUB_GRUPO.Name = "txtDESCRIPCION_SUB_GRUPO"
        Me.txtDESCRIPCION_SUB_GRUPO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_SUB_GRUPO.Size = New System.Drawing.Size(500, 22)
        Me.txtDESCRIPCION_SUB_GRUPO.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Sub Grupo :"
        '
        'dgvSubGrupos
        '
        Me.dgvSubGrupos.AllowUserToAddRows = False
        Me.dgvSubGrupos.AllowUserToDeleteRows = False
        Me.dgvSubGrupos.AllowUserToOrderColumns = True
        Me.dgvSubGrupos.AllowUserToResizeColumns = False
        Me.dgvSubGrupos.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvSubGrupos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSubGrupos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSubGrupos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvSubGrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSubGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSubGrupos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSubGrupos.Location = New System.Drawing.Point(3, 378)
        Me.dgvSubGrupos.Name = "dgvSubGrupos"
        Me.dgvSubGrupos.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubGrupos.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSubGrupos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSubGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubGrupos.Size = New System.Drawing.Size(611, 161)
        Me.dgvSubGrupos.TabIndex = 41
        '
        'dgvGrupos
        '
        Me.dgvGrupos.AllowUserToAddRows = False
        Me.dgvGrupos.AllowUserToDeleteRows = False
        Me.dgvGrupos.AllowUserToOrderColumns = True
        Me.dgvGrupos.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvGrupos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvGrupos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGrupos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvGrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGrupos.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvGrupos.Location = New System.Drawing.Point(3, 102)
        Me.dgvGrupos.MultiSelect = False
        Me.dgvGrupos.Name = "dgvGrupos"
        Me.dgvGrupos.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGrupos.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGrupos.Size = New System.Drawing.Size(611, 159)
        Me.dgvGrupos.TabIndex = 43
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(266, 77)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(93, 20)
        Me.CheckBox1.TabIndex = 108
        Me.CheckBox1.Text = "Aplica CESC"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Inventario_Grupos_SubGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 543)
        Me.Controls.Add(Me.dgvGrupos)
        Me.Controls.Add(Me.dgvSubGrupos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Inventario_Grupos_SubGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario -  Catálogo de Grupos y Sub Grupos de Productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvSubGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardarGrupos As System.Windows.Forms.Button
    Friend WithEvents btnEliminarGrupos As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_GRUPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardarSubGrupos As System.Windows.Forms.Button
    Friend WithEvents btnEliminarSubGrupos As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_SUB_GRUPO As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMARGEN As System.Windows.Forms.TextBox
    Friend WithEvents chkMARGEN As System.Windows.Forms.CheckBox
    Friend WithEvents lblGRUPO As System.Windows.Forms.Label
    Friend WithEvents btnNuevoGrupos As System.Windows.Forms.Button
    Friend WithEvents lblSUB_GRUPO As System.Windows.Forms.Label
    Friend WithEvents dgvSubGrupos As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevoSubGrupos As System.Windows.Forms.Button
    Friend WithEvents AutoOrdenamiento As System.Windows.Forms.CheckBox
    Friend WithEvents AutoOrdenamiento2 As System.Windows.Forms.CheckBox
    Friend WithEvents dgvGrupos As System.Windows.Forms.DataGridView
    Friend WithEvents txtdescmaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkPertenece As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
