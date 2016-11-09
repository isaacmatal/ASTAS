<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Bodegas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Bodegas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbTipoBodega = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbPERIODO = New System.Windows.Forms.ComboBox
        Me.cmbPlantas = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_Margen = New System.Windows.Forms.TextBox
        Me.AutoOrdenamiento = New System.Windows.Forms.CheckBox
        Me.ck_Siempre_Fac = New System.Windows.Forms.CheckBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.cmbDEDUCCION = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.txtCuoFin = New System.Windows.Forms.TextBox
        Me.txtCuotaIni = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbCENTRO_COSTO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkVPDF = New System.Windows.Forms.CheckBox
        Me.chkFDP = New System.Windows.Forms.CheckBox
        Me.chkActiva = New System.Windows.Forms.CheckBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.txtBodega = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvBodegas = New System.Windows.Forms.DataGridView
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(12, 22)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(156, 188)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 35
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.cmbTipoBodega)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbPERIODO)
        Me.GroupBox1.Controls.Add(Me.cmbPlantas)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_Margen)
        Me.GroupBox1.Controls.Add(Me.AutoOrdenamiento)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.ck_Siempre_Fac)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.cmbDEDUCCION)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.txtCuoFin)
        Me.GroupBox1.Controls.Add(Me.txtCuotaIni)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbCENTRO_COSTO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkVPDF)
        Me.GroupBox1.Controls.Add(Me.chkFDP)
        Me.GroupBox1.Controls.Add(Me.chkActiva)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.txtBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(981, 226)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Bodegas"
        '
        'cmbTipoBodega
        '
        Me.cmbTipoBodega.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoBodega.ForeColor = System.Drawing.Color.Navy
        Me.cmbTipoBodega.FormattingEnabled = True
        Me.cmbTipoBodega.Items.AddRange(New Object() {"Otros", "Almacen", "Cafeteria", "Despensa"})
        Me.cmbTipoBodega.Location = New System.Drawing.Point(491, 46)
        Me.cmbTipoBodega.Name = "cmbTipoBodega"
        Me.cmbTipoBodega.Size = New System.Drawing.Size(208, 24)
        Me.cmbTipoBodega.TabIndex = 107
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(705, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 16)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = ":Tipo de Bodega"
        '
        'cmbPERIODO
        '
        Me.cmbPERIODO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPERIODO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPERIODO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPERIODO.ForeColor = System.Drawing.Color.Navy
        Me.cmbPERIODO.FormattingEnabled = True
        Me.cmbPERIODO.Items.AddRange(New Object() {"402 - Despensa", "436 - Almacén"})
        Me.cmbPERIODO.Location = New System.Drawing.Point(724, 170)
        Me.cmbPERIODO.Name = "cmbPERIODO"
        Me.cmbPERIODO.Size = New System.Drawing.Size(18, 24)
        Me.cmbPERIODO.TabIndex = 106
        Me.cmbPERIODO.Visible = False
        '
        'cmbPlantas
        '
        Me.cmbPlantas.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlantas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlantas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlantas.ForeColor = System.Drawing.Color.Navy
        Me.cmbPlantas.FormattingEnabled = True
        Me.cmbPlantas.Items.AddRange(New Object() {"1 - Planta Soyapango", "2 - Planta Zapotitan", "3 - Planta Lourdes", "4 - Otra No clasificada"})
        Me.cmbPlantas.Location = New System.Drawing.Point(281, 121)
        Me.cmbPlantas.Name = "cmbPlantas"
        Me.cmbPlantas.Size = New System.Drawing.Size(208, 24)
        Me.cmbPlantas.TabIndex = 104
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(174, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 16)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Planta :"
        '
        'txt_Margen
        '
        Me.txt_Margen.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Margen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Margen.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Margen.ForeColor = System.Drawing.Color.Navy
        Me.txt_Margen.Location = New System.Drawing.Point(491, 122)
        Me.txt_Margen.Name = "txt_Margen"
        Me.txt_Margen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Margen.Size = New System.Drawing.Size(208, 22)
        Me.txt_Margen.TabIndex = 103
        '
        'AutoOrdenamiento
        '
        Me.AutoOrdenamiento.AutoSize = True
        Me.AutoOrdenamiento.BackColor = System.Drawing.Color.Transparent
        Me.AutoOrdenamiento.Checked = True
        Me.AutoOrdenamiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoOrdenamiento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoOrdenamiento.Location = New System.Drawing.Point(492, 190)
        Me.AutoOrdenamiento.Name = "AutoOrdenamiento"
        Me.AutoOrdenamiento.Size = New System.Drawing.Size(138, 20)
        Me.AutoOrdenamiento.TabIndex = 102
        Me.AutoOrdenamiento.Text = "Búsqueda Dinámica"
        Me.AutoOrdenamiento.UseVisualStyleBackColor = False
        '
        'ck_Siempre_Fac
        '
        Me.ck_Siempre_Fac.AutoSize = True
        Me.ck_Siempre_Fac.BackColor = System.Drawing.Color.Transparent
        Me.ck_Siempre_Fac.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_Siempre_Fac.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ck_Siempre_Fac.Location = New System.Drawing.Point(492, 174)
        Me.ck_Siempre_Fac.Name = "ck_Siempre_Fac"
        Me.ck_Siempre_Fac.Size = New System.Drawing.Size(137, 20)
        Me.ck_Siempre_Fac.TabIndex = 9
        Me.ck_Siempre_Fac.Text = "Siempre Facturable"
        Me.ToolTip1.SetToolTip(Me.ck_Siempre_Fac, "Es utilizado por Cafetería para los productos Misceláneos.")
        Me.ck_Siempre_Fac.UseVisualStyleBackColor = False
        Me.ck_Siempre_Fac.Visible = False
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompañia.Location = New System.Drawing.Point(281, 22)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(418, 22)
        Me.txtCompañia.TabIndex = 23
        '
        'cmbDEDUCCION
        '
        Me.cmbDEDUCCION.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDEDUCCION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDEDUCCION.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDEDUCCION.ForeColor = System.Drawing.Color.Navy
        Me.cmbDEDUCCION.FormattingEnabled = True
        Me.cmbDEDUCCION.Items.AddRange(New Object() {"402 - Despensa", "436 - Almacén"})
        Me.cmbDEDUCCION.Location = New System.Drawing.Point(491, 95)
        Me.cmbDEDUCCION.Name = "cmbDEDUCCION"
        Me.cmbDEDUCCION.Size = New System.Drawing.Size(208, 24)
        Me.cmbDEDUCCION.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(705, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = ":Deducción "
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(820, 84)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(83, 24)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpia todos los campos para ingresar una nueva Bodega")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'txtCuoFin
        '
        Me.txtCuoFin.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuoFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuoFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuoFin.ForeColor = System.Drawing.Color.Navy
        Me.txtCuoFin.Location = New System.Drawing.Point(491, 146)
        Me.txtCuoFin.Name = "txtCuoFin"
        Me.txtCuoFin.Size = New System.Drawing.Size(208, 22)
        Me.txtCuoFin.TabIndex = 5
        Me.txtCuoFin.Text = "5"
        Me.txtCuoFin.Visible = False
        '
        'txtCuotaIni
        '
        Me.txtCuotaIni.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuotaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuotaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuotaIni.ForeColor = System.Drawing.Color.Navy
        Me.txtCuotaIni.Location = New System.Drawing.Point(281, 147)
        Me.txtCuotaIni.Name = "txtCuotaIni"
        Me.txtCuotaIni.Size = New System.Drawing.Size(208, 22)
        Me.txtCuotaIni.TabIndex = 4
        Me.txtCuotaIni.Text = "1"
        Me.txtCuotaIni.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(705, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = ":Cuota Final "
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(174, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Cuota Inicial :"
        Me.Label5.Visible = False
        '
        'cmbCENTRO_COSTO
        '
        Me.cmbCENTRO_COSTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCENTRO_COSTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCENTRO_COSTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCENTRO_COSTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCENTRO_COSTO.FormattingEnabled = True
        Me.cmbCENTRO_COSTO.Items.AddRange(New Object() {"1 - Administración", "2 - Despensa Planta #1", "3 - Despensa Zapotitán", "4 - Almacén Planta #1"})
        Me.cmbCENTRO_COSTO.Location = New System.Drawing.Point(281, 95)
        Me.cmbCENTRO_COSTO.Name = "cmbCENTRO_COSTO"
        Me.cmbCENTRO_COSTO.Size = New System.Drawing.Size(208, 24)
        Me.cmbCENTRO_COSTO.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(174, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Centro de Costo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(709, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = ":Margen %"
        '
        'chkVPDF
        '
        Me.chkVPDF.AutoSize = True
        Me.chkVPDF.BackColor = System.Drawing.Color.Transparent
        Me.chkVPDF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVPDF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkVPDF.Location = New System.Drawing.Point(492, 206)
        Me.chkVPDF.Name = "chkVPDF"
        Me.chkVPDF.Size = New System.Drawing.Size(255, 20)
        Me.chkVPDF.TabIndex = 8
        Me.chkVPDF.Text = "Controla varios períodos de Facturación"
        Me.chkVPDF.UseVisualStyleBackColor = False
        Me.chkVPDF.Visible = False
        '
        'chkFDP
        '
        Me.chkFDP.AutoSize = True
        Me.chkFDP.BackColor = System.Drawing.Color.Transparent
        Me.chkFDP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFDP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFDP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFDP.Location = New System.Drawing.Point(269, 190)
        Me.chkFDP.Name = "chkFDP"
        Me.chkFDP.Size = New System.Drawing.Size(217, 20)
        Me.chkFDP.TabIndex = 7
        Me.chkFDP.Text = "Controla facturación de productos"
        Me.chkFDP.UseVisualStyleBackColor = False
        '
        'chkActiva
        '
        Me.chkActiva.AutoSize = True
        Me.chkActiva.BackColor = System.Drawing.Color.Transparent
        Me.chkActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActiva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActiva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkActiva.Location = New System.Drawing.Point(425, 174)
        Me.chkActiva.Name = "chkActiva"
        Me.chkActiva.Size = New System.Drawing.Size(61, 20)
        Me.chkActiva.TabIndex = 6
        Me.chkActiva.Text = "Activa"
        Me.chkActiva.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(820, 114)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(83, 24)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guarda o Actualiza los datos de Bodega")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(820, 144)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(83, 24)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Elimina datos de una bodega")
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'txtBodega
        '
        Me.txtBodega.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBodega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBodega.ForeColor = System.Drawing.Color.Navy
        Me.txtBodega.Location = New System.Drawing.Point(281, 47)
        Me.txtBodega.Name = "txtBodega"
        Me.txtBodega.ReadOnly = True
        Me.txtBodega.Size = New System.Drawing.Size(208, 22)
        Me.txtBodega.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(174, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Descripción :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.txtDescripcion.Location = New System.Drawing.Point(281, 71)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(418, 22)
        Me.txtDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(174, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(174, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Compañía :"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'dgvBodegas
        '
        Me.dgvBodegas.AllowUserToAddRows = False
        Me.dgvBodegas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvBodegas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBodegas.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBodegas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBodegas.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBodegas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBodegas.Location = New System.Drawing.Point(0, 226)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBodegas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBodegas.RowHeadersVisible = False
        Me.dgvBodegas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBodegas.Size = New System.Drawing.Size(981, 308)
        Me.dgvBodegas.TabIndex = 84
        '
        'Inventario_Bodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 534)
        Me.Controls.Add(Me.dgvBodegas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Inventario_Bodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario - Mantenimiento de Bodegas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtBodega As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkActiva As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkVPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chkFDP As System.Windows.Forms.CheckBox
    Friend WithEvents txtCuoFin As System.Windows.Forms.TextBox
    Friend WithEvents txtCuotaIni As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCENTRO_COSTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbDEDUCCION As System.Windows.Forms.ComboBox
    Friend WithEvents ck_Siempre_Fac As System.Windows.Forms.CheckBox
    Friend WithEvents AutoOrdenamiento As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Margen As System.Windows.Forms.TextBox
    Friend WithEvents cmbPlantas As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvBodegas As System.Windows.Forms.DataGridView
    Friend WithEvents cmbPERIODO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
