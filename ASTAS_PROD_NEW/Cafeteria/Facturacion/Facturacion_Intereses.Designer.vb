<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Intereses
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Facturacion_Intereses))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.rbQna1 = New System.Windows.Forms.RadioButton
        Me.rbQna2 = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Pb1 = New System.Windows.Forms.ProgressBar
        Me.btnBuscaGlobal = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnExportExcel = New System.Windows.Forms.Button
        Me.dtpFechaProceso = New System.Windows.Forms.DateTimePicker
        Me.btnCerrarCaja = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_Manuales2 = New System.Windows.Forms.TextBox
        Me.txt_Manuales1 = New System.Windows.Forms.TextBox
        Me.txt_Automaticos2 = New System.Windows.Forms.TextBox
        Me.txt_Automatico1 = New System.Windows.Forms.TextBox
        Me.cbCaja = New System.Windows.Forms.ComboBox
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblSeleccioneCaja = New System.Windows.Forms.Label
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgvDetallesInt = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDetAuto = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalAuto = New System.Windows.Forms.TextBox
        Me.dgvAutomaticos = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnProcesarAuto = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dgvDatosManuales = New System.Windows.Forms.DataGridView
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtHojaMan = New System.Windows.Forms.TextBox
        Me.btnValidaMan = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnNvoMan = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRutaMan = New System.Windows.Forms.TextBox
        Me.btnProcesarMan = New System.Windows.Forms.Button
        Me.btnCargaMan = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTotalMan = New System.Windows.Forms.TextBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.OpenFD = New System.Windows.Forms.SaveFileDialog
        Me.bwAutomaticos = New System.ComponentModel.BackgroundWorker
        Me.bwManuales = New System.ComponentModel.BackgroundWorker
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.bwCargaAutomaticos = New System.ComponentModel.BackgroundWorker
        Me.bwTabla = New System.ComponentModel.BackgroundWorker
        Me.bwAvance = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDetallesInt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvAutomaticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvDatosManuales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.GroupBox9)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.Pb1)
        Me.GroupBox1.Controls.Add(Me.btnBuscaGlobal)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.btnExportExcel)
        Me.GroupBox1.Controls.Add(Me.dtpFechaProceso)
        Me.GroupBox1.Controls.Add(Me.btnCerrarCaja)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txt_Manuales2)
        Me.GroupBox1.Controls.Add(Me.txt_Manuales1)
        Me.GroupBox1.Controls.Add(Me.txt_Automaticos2)
        Me.GroupBox1.Controls.Add(Me.txt_Automatico1)
        Me.GroupBox1.Controls.Add(Me.cbCaja)
        Me.GroupBox1.Controls.Add(Me.cbCafeteria)
        Me.GroupBox1.Controls.Add(Me.lblSeleccioneCaja)
        Me.GroupBox1.Controls.Add(Me.lblCafeteria)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(915, 156)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkRed
        Me.Label15.Location = New System.Drawing.Point(552, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 24)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "Procesando..."
        Me.Label15.Visible = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rbQna1)
        Me.GroupBox9.Controls.Add(Me.rbQna2)
        Me.GroupBox9.ForeColor = System.Drawing.Color.White
        Me.GroupBox9.Location = New System.Drawing.Point(135, 19)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(95, 74)
        Me.GroupBox9.TabIndex = 129
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Quincena"
        '
        'rbQna1
        '
        Me.rbQna1.AutoSize = True
        Me.rbQna1.BackColor = System.Drawing.Color.Transparent
        Me.rbQna1.Checked = True
        Me.rbQna1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbQna1.ForeColor = System.Drawing.Color.White
        Me.rbQna1.Location = New System.Drawing.Point(9, 21)
        Me.rbQna1.Name = "rbQna1"
        Me.rbQna1.Size = New System.Drawing.Size(67, 17)
        Me.rbQna1.TabIndex = 113
        Me.rbQna1.TabStop = True
        Me.rbQna1.Text = "Primera"
        Me.rbQna1.UseVisualStyleBackColor = False
        '
        'rbQna2
        '
        Me.rbQna2.AutoSize = True
        Me.rbQna2.BackColor = System.Drawing.Color.Transparent
        Me.rbQna2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbQna2.ForeColor = System.Drawing.Color.White
        Me.rbQna2.Location = New System.Drawing.Point(9, 46)
        Me.rbQna2.Name = "rbQna2"
        Me.rbQna2.Size = New System.Drawing.Size(75, 17)
        Me.rbQna2.TabIndex = 114
        Me.rbQna2.Text = "Segunda"
        Me.rbQna2.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(233, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 13)
        Me.Label18.TabIndex = 128
        Me.Label18.Text = "Fecha a Procesar:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(266, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 127
        Me.Label17.Text = "Ticket Final:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(259, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "Ticket Inicial:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.MediumBlue
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(136, 115)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 23)
        Me.btnCancelar.TabIndex = 125
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Visible = False
        '
        'Pb1
        '
        Me.Pb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pb1.Location = New System.Drawing.Point(135, 142)
        Me.Pb1.Name = "Pb1"
        Me.Pb1.Size = New System.Drawing.Size(773, 10)
        Me.Pb1.Step = 1
        Me.Pb1.TabIndex = 124
        '
        'btnBuscaGlobal
        '
        Me.btnBuscaGlobal.BackColor = System.Drawing.Color.Yellow
        Me.btnBuscaGlobal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaGlobal.ForeColor = System.Drawing.Color.Black
        Me.btnBuscaGlobal.Location = New System.Drawing.Point(693, 90)
        Me.btnBuscaGlobal.Name = "btnBuscaGlobal"
        Me.btnBuscaGlobal.Size = New System.Drawing.Size(70, 23)
        Me.btnBuscaGlobal.TabIndex = 123
        Me.btnBuscaGlobal.Text = "Cargar"
        Me.btnBuscaGlobal.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Yellow
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(574, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(278, 16)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "Dia procesado, solo Exportar a Excel..."
        Me.Label19.Visible = False
        '
        'btnExportExcel
        '
        Me.btnExportExcel.BackColor = System.Drawing.Color.YellowGreen
        Me.btnExportExcel.Enabled = False
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Image = Global.ASTAS.My.Resources.Resources.down
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.Location = New System.Drawing.Point(693, 116)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(159, 23)
        Me.btnExportExcel.TabIndex = 121
        Me.btnExportExcel.Text = "Exportar a Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'dtpFechaProceso
        '
        Me.dtpFechaProceso.CustomFormat = "dd-MMMM-yyyy"
        Me.dtpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProceso.Location = New System.Drawing.Point(346, 57)
        Me.dtpFechaProceso.Name = "dtpFechaProceso"
        Me.dtpFechaProceso.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaProceso.TabIndex = 120
        '
        'btnCerrarCaja
        '
        Me.btnCerrarCaja.BackColor = System.Drawing.Color.Red
        Me.btnCerrarCaja.Enabled = False
        Me.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarCaja.ForeColor = System.Drawing.Color.Black
        Me.btnCerrarCaja.Location = New System.Drawing.Point(769, 90)
        Me.btnCerrarCaja.Name = "btnCerrarCaja"
        Me.btnCerrarCaja.Size = New System.Drawing.Size(83, 23)
        Me.btnCerrarCaja.TabIndex = 119
        Me.btnCerrarCaja.Text = "Cerrar/Salir"
        Me.btnCerrarCaja.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(463, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 117
        Me.Label14.Text = "Carga Excel"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(356, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "Automaticos"
        '
        'txt_Manuales2
        '
        Me.txt_Manuales2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Manuales2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Manuales2.Location = New System.Drawing.Point(453, 115)
        Me.txt_Manuales2.Name = "txt_Manuales2"
        Me.txt_Manuales2.ReadOnly = True
        Me.txt_Manuales2.Size = New System.Drawing.Size(93, 20)
        Me.txt_Manuales2.TabIndex = 112
        '
        'txt_Manuales1
        '
        Me.txt_Manuales1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Manuales1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Manuales1.Location = New System.Drawing.Point(453, 93)
        Me.txt_Manuales1.Name = "txt_Manuales1"
        Me.txt_Manuales1.ReadOnly = True
        Me.txt_Manuales1.Size = New System.Drawing.Size(93, 20)
        Me.txt_Manuales1.TabIndex = 111
        '
        'txt_Automaticos2
        '
        Me.txt_Automaticos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Automaticos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Automaticos2.Location = New System.Drawing.Point(346, 115)
        Me.txt_Automaticos2.Name = "txt_Automaticos2"
        Me.txt_Automaticos2.ReadOnly = True
        Me.txt_Automaticos2.Size = New System.Drawing.Size(93, 20)
        Me.txt_Automaticos2.TabIndex = 108
        '
        'txt_Automatico1
        '
        Me.txt_Automatico1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Automatico1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Automatico1.Location = New System.Drawing.Point(346, 93)
        Me.txt_Automatico1.Name = "txt_Automatico1"
        Me.txt_Automatico1.ReadOnly = True
        Me.txt_Automatico1.Size = New System.Drawing.Size(93, 20)
        Me.txt_Automatico1.TabIndex = 107
        '
        'cbCaja
        '
        Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCaja.FormattingEnabled = True
        Me.cbCaja.Location = New System.Drawing.Point(346, 35)
        Me.cbCaja.Name = "cbCaja"
        Me.cbCaja.Size = New System.Drawing.Size(200, 21)
        Me.cbCaja.TabIndex = 102
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(346, 13)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(506, 21)
        Me.cbCafeteria.TabIndex = 101
        '
        'lblSeleccioneCaja
        '
        Me.lblSeleccioneCaja.AutoSize = True
        Me.lblSeleccioneCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblSeleccioneCaja.ForeColor = System.Drawing.Color.White
        Me.lblSeleccioneCaja.Location = New System.Drawing.Point(308, 38)
        Me.lblSeleccioneCaja.Name = "lblSeleccioneCaja"
        Me.lblSeleccioneCaja.Size = New System.Drawing.Size(36, 13)
        Me.lblSeleccioneCaja.TabIndex = 103
        Me.lblSeleccioneCaja.Text = "Caja:"
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.BackColor = System.Drawing.Color.Transparent
        Me.lblCafeteria.ForeColor = System.Drawing.Color.White
        Me.lblCafeteria.Location = New System.Drawing.Point(280, 16)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(64, 13)
        Me.lblCafeteria.TabIndex = 100
        Me.lblCafeteria.Text = "Cafetería:"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Image = CType(resources.GetObject("pbImagen.Image"), System.Drawing.Image)
        Me.pbImagen.Location = New System.Drawing.Point(19, 13)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(92, 137)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 99
        Me.pbImagen.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Enabled = False
        Me.TabControl1.Location = New System.Drawing.Point(0, 156)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(915, 439)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDetallesInt)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.dgvAutomaticos)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(907, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Automáticos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvDetallesInt
        '
        Me.dgvDetallesInt.AllowUserToAddRows = False
        Me.dgvDetallesInt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDetallesInt.BackgroundColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetallesInt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetallesInt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetallesInt.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetallesInt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetallesInt.Location = New System.Drawing.Point(3, 282)
        Me.dgvDetallesInt.Name = "dgvDetallesInt"
        Me.dgvDetallesInt.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetallesInt.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetallesInt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetallesInt.Size = New System.Drawing.Size(901, 80)
        Me.dgvDetallesInt.TabIndex = 12
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtDetAuto)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 362)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(901, 48)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(347, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Total del detalle"
        '
        'txtDetAuto
        '
        Me.txtDetAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetAuto.Location = New System.Drawing.Point(471, 16)
        Me.txtDetAuto.Name = "txtDetAuto"
        Me.txtDetAuto.Size = New System.Drawing.Size(100, 20)
        Me.txtDetAuto.TabIndex = 104
        Me.txtDetAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.txtTotalAuto)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 247)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(901, 35)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(348, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Total Global"
        '
        'txtTotalAuto
        '
        Me.txtTotalAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAuto.Location = New System.Drawing.Point(472, 9)
        Me.txtTotalAuto.Name = "txtTotalAuto"
        Me.txtTotalAuto.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAuto.TabIndex = 0
        Me.txtTotalAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvAutomaticos
        '
        Me.dgvAutomaticos.AllowUserToAddRows = False
        Me.dgvAutomaticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAutomaticos.BackgroundColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAutomaticos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAutomaticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAutomaticos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAutomaticos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvAutomaticos.Location = New System.Drawing.Point(3, 48)
        Me.dgvAutomaticos.Name = "dgvAutomaticos"
        Me.dgvAutomaticos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAutomaticos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAutomaticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAutomaticos.Size = New System.Drawing.Size(901, 199)
        Me.dgvAutomaticos.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Controls.Add(Me.btnProcesarAuto)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(901, 45)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'btnProcesarAuto
        '
        Me.btnProcesarAuto.BackColor = System.Drawing.Color.PaleGreen
        Me.btnProcesarAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesarAuto.Location = New System.Drawing.Point(8, 9)
        Me.btnProcesarAuto.Name = "btnProcesarAuto"
        Me.btnProcesarAuto.Size = New System.Drawing.Size(101, 33)
        Me.btnProcesarAuto.TabIndex = 5
        Me.btnProcesarAuto.Text = "Procesar"
        Me.btnProcesarAuto.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvDatosManuales)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(907, 413)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Carga Excel"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvDatosManuales
        '
        Me.dgvDatosManuales.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Yellow
        Me.dgvDatosManuales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDatosManuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDatosManuales.BackgroundColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosManuales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDatosManuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDatosManuales.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDatosManuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatosManuales.Location = New System.Drawing.Point(3, 97)
        Me.dgvDatosManuales.Name = "dgvDatosManuales"
        Me.dgvDatosManuales.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosManuales.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDatosManuales.Size = New System.Drawing.Size(901, 267)
        Me.dgvDatosManuales.TabIndex = 10
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.txtHojaMan)
        Me.GroupBox5.Controls.Add(Me.btnValidaMan)
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.btnNvoMan)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtRutaMan)
        Me.GroupBox5.Controls.Add(Me.btnProcesarMan)
        Me.GroupBox5.Controls.Add(Me.btnCargaMan)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(901, 94)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(540, 41)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 16)
        Me.Label20.TabIndex = 102
        Me.Label20.Text = "Nombre de la Hoja:"
        '
        'txtHojaMan
        '
        Me.txtHojaMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHojaMan.Location = New System.Drawing.Point(654, 39)
        Me.txtHojaMan.Name = "txtHojaMan"
        Me.txtHojaMan.Size = New System.Drawing.Size(75, 20)
        Me.txtHojaMan.TabIndex = 101
        Me.txtHojaMan.Text = "Hoja1"
        '
        'btnValidaMan
        '
        Me.btnValidaMan.BackColor = System.Drawing.Color.PaleGreen
        Me.btnValidaMan.Location = New System.Drawing.Point(171, 11)
        Me.btnValidaMan.Name = "btnValidaMan"
        Me.btnValidaMan.Size = New System.Drawing.Size(102, 23)
        Me.btnValidaMan.TabIndex = 100
        Me.btnValidaMan.Text = "Validar"
        Me.btnValidaMan.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(176, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(289, 22)
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 16)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Encabezado Archivo de Excel:"
        '
        'btnNvoMan
        '
        Me.btnNvoMan.BackColor = System.Drawing.Color.PaleGreen
        Me.btnNvoMan.Location = New System.Drawing.Point(90, 11)
        Me.btnNvoMan.Name = "btnNvoMan"
        Me.btnNvoMan.Size = New System.Drawing.Size(75, 23)
        Me.btnNvoMan.TabIndex = 94
        Me.btnNvoMan.Text = "Nuevo"
        Me.btnNvoMan.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Ruta del archivo:"
        '
        'txtRutaMan
        '
        Me.txtRutaMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaMan.Enabled = False
        Me.txtRutaMan.Location = New System.Drawing.Point(110, 39)
        Me.txtRutaMan.Name = "txtRutaMan"
        Me.txtRutaMan.Size = New System.Drawing.Size(424, 20)
        Me.txtRutaMan.TabIndex = 92
        '
        'btnProcesarMan
        '
        Me.btnProcesarMan.BackColor = System.Drawing.Color.PaleGreen
        Me.btnProcesarMan.Location = New System.Drawing.Point(279, 11)
        Me.btnProcesarMan.Name = "btnProcesarMan"
        Me.btnProcesarMan.Size = New System.Drawing.Size(102, 23)
        Me.btnProcesarMan.TabIndex = 5
        Me.btnProcesarMan.Text = "Procesar"
        Me.btnProcesarMan.UseVisualStyleBackColor = False
        '
        'btnCargaMan
        '
        Me.btnCargaMan.BackColor = System.Drawing.Color.PaleGreen
        Me.btnCargaMan.Location = New System.Drawing.Point(9, 11)
        Me.btnCargaMan.Name = "btnCargaMan"
        Me.btnCargaMan.Size = New System.Drawing.Size(75, 23)
        Me.btnCargaMan.TabIndex = 0
        Me.btnCargaMan.Text = "Archivo"
        Me.btnCargaMan.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.txtTotalMan)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(3, 364)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(901, 46)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(331, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Total en Archivo:"
        '
        'txtTotalMan
        '
        Me.txtTotalMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMan.Location = New System.Drawing.Point(439, 14)
        Me.txtTotalMan.Name = "txtTotalMan"
        Me.txtTotalMan.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalMan.TabIndex = 106
        Me.txtTotalMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(907, 413)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Listado Excel"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(907, 413)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'OpenFD
        '
        Me.OpenFD.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos de Excel 97-2003|*.xls"
        '
        'bwAutomaticos
        '
        Me.bwAutomaticos.WorkerReportsProgress = True
        Me.bwAutomaticos.WorkerSupportsCancellation = True
        '
        'bwManuales
        '
        Me.bwManuales.WorkerReportsProgress = True
        Me.bwManuales.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'bwCargaAutomaticos
        '
        Me.bwCargaAutomaticos.WorkerReportsProgress = True
        Me.bwCargaAutomaticos.WorkerSupportsCancellation = True
        '
        'bwTabla
        '
        Me.bwTabla.WorkerReportsProgress = True
        Me.bwTabla.WorkerSupportsCancellation = True
        '
        'bwAvance
        '
        Me.bwAvance.WorkerReportsProgress = True
        Me.bwAvance.WorkerSupportsCancellation = True
        '
        'Facturacion_Intereses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 595)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Facturacion_Intereses"
        Me.Text = "Facturacion Intereses Descontados en Planilla"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvDetallesInt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgvAutomaticos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvDatosManuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvAutomaticos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcesarAuto As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcesarMan As System.Windows.Forms.Button
    Friend WithEvents btnCargaMan As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRutaMan As System.Windows.Forms.TextBox
    Friend WithEvents btnNvoMan As System.Windows.Forms.Button
    Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeleccioneCaja As System.Windows.Forms.Label
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAuto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvDatosManuales As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetallesInt As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDetAuto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMan As System.Windows.Forms.TextBox
    Friend WithEvents btnValidaMan As System.Windows.Forms.Button
    Friend WithEvents txt_Manuales2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Manuales1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Automaticos2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Automatico1 As System.Windows.Forms.TextBox
    Friend WithEvents rbQna2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQna1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCerrarCaja As System.Windows.Forms.Button
    Friend WithEvents dtpFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents OpenFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaGlobal As System.Windows.Forms.Button
    Friend WithEvents txtHojaMan As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents bwAutomaticos As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents bwManuales As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents bwCargaAutomaticos As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwTabla As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwAvance As System.ComponentModel.BackgroundWorker
End Class
