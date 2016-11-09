<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CMSSolicitutes_noaprobadas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CMSSolicitudes_aprobadasnoemitidas_undoactual = New System.Windows.Forms.ToolStripMenuItem
        Me.CMSSolicitudes_aprobadasnoemitidas_undotodas = New System.Windows.Forms.ToolStripMenuItem
        Me.CmbBanco = New System.Windows.Forms.ComboBox
        Me.CmbCuentaBancaria = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Lbl_Cantidad_registros_seleccionados02 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblMensaje02 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Btn_Aprobar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GrpDatosAhorro = New System.Windows.Forms.GroupBox
        Me.TxtISR_porcentaje = New System.Windows.Forms.TextBox
        Me.TxtEscolaridad_porcentaje = New System.Windows.Forms.TextBox
        Me.TxtTotalBruto01 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtISR = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtEscolaridad = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtTotalAhorro = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtTotalAhorro_ExtraOrdinario = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtTotalAhorro_Ordinario = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DrpDatosLibresDeuda = New System.Windows.Forms.GroupBox
        Me.txtSegDeuda = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtInteres = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtTotalDeudas = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtTotalBruto02 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dpFechaContable = New System.Windows.Forms.DateTimePicker
        Me.SelectAll = New System.Windows.Forms.CheckBox
        Me.lblProcesando = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgvRetirosEmitidos = New System.Windows.Forms.DataGridView
        Me.CMSSolicitutes_noaprobadas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GrpDatosAhorro.SuspendLayout()
        Me.DrpDatosLibresDeuda.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRetirosEmitidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMSSolicitutes_noaprobadas
        '
        Me.CMSSolicitutes_noaprobadas.AccessibleDescription = ""
        Me.CMSSolicitutes_noaprobadas.AccessibleName = ""
        Me.CMSSolicitutes_noaprobadas.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CMSSolicitutes_noaprobadas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripSeparator1, Me.CMSSolicitudes_aprobadasnoemitidas_undoactual, Me.CMSSolicitudes_aprobadasnoemitidas_undotodas})
        Me.CMSSolicitutes_noaprobadas.Name = "ContextMenuStrip1"
        Me.CMSSolicitutes_noaprobadas.Size = New System.Drawing.Size(174, 98)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(173, 22)
        Me.ToolStripMenuItem2.Text = "Opciones"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'CMSSolicitudes_aprobadasnoemitidas_undoactual
        '
        Me.CMSSolicitudes_aprobadasnoemitidas_undoactual.Image = CType(resources.GetObject("CMSSolicitudes_aprobadasnoemitidas_undoactual.Image"), System.Drawing.Image)
        Me.CMSSolicitudes_aprobadasnoemitidas_undoactual.Name = "CMSSolicitudes_aprobadasnoemitidas_undoactual"
        Me.CMSSolicitudes_aprobadasnoemitidas_undoactual.Size = New System.Drawing.Size(173, 22)
        Me.CMSSolicitudes_aprobadasnoemitidas_undoactual.Text = "Anular Seleccionada"
        '
        'CMSSolicitudes_aprobadasnoemitidas_undotodas
        '
        Me.CMSSolicitudes_aprobadasnoemitidas_undotodas.Image = CType(resources.GetObject("CMSSolicitudes_aprobadasnoemitidas_undotodas.Image"), System.Drawing.Image)
        Me.CMSSolicitudes_aprobadasnoemitidas_undotodas.Name = "CMSSolicitudes_aprobadasnoemitidas_undotodas"
        Me.CMSSolicitudes_aprobadasnoemitidas_undotodas.Size = New System.Drawing.Size(173, 22)
        Me.CMSSolicitudes_aprobadasnoemitidas_undotodas.Text = "Anular todas"
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBanco.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CmbBanco.ForeColor = System.Drawing.Color.Navy
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(112, 50)
        Me.CmbBanco.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(400, 24)
        Me.CmbBanco.TabIndex = 100
        '
        'CmbCuentaBancaria
        '
        Me.CmbCuentaBancaria.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCuentaBancaria.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CmbCuentaBancaria.ForeColor = System.Drawing.Color.Navy
        Me.CmbCuentaBancaria.FormattingEnabled = True
        Me.CmbCuentaBancaria.Location = New System.Drawing.Point(112, 81)
        Me.CmbCuentaBancaria.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbCuentaBancaria.Name = "CmbCuentaBancaria"
        Me.CmbCuentaBancaria.Size = New System.Drawing.Size(400, 24)
        Me.CmbCuentaBancaria.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(507, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 42)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Registros seleccionados"
        Me.Label6.Visible = False
        '
        'Lbl_Cantidad_registros_seleccionados02
        '
        Me.Lbl_Cantidad_registros_seleccionados02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Lbl_Cantidad_registros_seleccionados02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Cantidad_registros_seleccionados02.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Lbl_Cantidad_registros_seleccionados02.ForeColor = System.Drawing.Color.Navy
        Me.Lbl_Cantidad_registros_seleccionados02.Location = New System.Drawing.Point(510, 218)
        Me.Lbl_Cantidad_registros_seleccionados02.Name = "Lbl_Cantidad_registros_seleccionados02"
        Me.Lbl_Cantidad_registros_seleccionados02.Size = New System.Drawing.Size(49, 27)
        Me.Lbl_Cantidad_registros_seleccionados02.TabIndex = 102
        Me.Lbl_Cantidad_registros_seleccionados02.Text = "0"
        Me.Lbl_Cantidad_registros_seleccionados02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lbl_Cantidad_registros_seleccionados02.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Banco"
        '
        'LblMensaje02
        '
        Me.LblMensaje02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblMensaje02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblMensaje02.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblMensaje02.ForeColor = System.Drawing.Color.Navy
        Me.LblMensaje02.Location = New System.Drawing.Point(5, 176)
        Me.LblMensaje02.Name = "LblMensaje02"
        Me.LblMensaje02.Size = New System.Drawing.Size(499, 43)
        Me.LblMensaje02.TabIndex = 99
        Me.LblMensaje02.Text = "Label3"
        Me.LblMensaje02.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "No. Cuenta:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(8, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Compañía"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Lbl_Cantidad_registros_seleccionados02)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CmbCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.LblMensaje02)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CmbBanco)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 113)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar Banco y Cuenta"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(112, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(398, 22)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Label7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_Aprobar
        '
        Me.Btn_Aprobar.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Aprobar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Btn_Aprobar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_Aprobar.Image = CType(resources.GetObject("Btn_Aprobar.Image"), System.Drawing.Image)
        Me.Btn_Aprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Aprobar.Location = New System.Drawing.Point(445, 117)
        Me.Btn_Aprobar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Btn_Aprobar.Name = "Btn_Aprobar"
        Me.Btn_Aprobar.Size = New System.Drawing.Size(76, 24)
        Me.Btn_Aprobar.TabIndex = 98
        Me.Btn_Aprobar.Text = "Procesar"
        Me.Btn_Aprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Aprobar.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(650, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(277, 452)
        Me.TabControl1.TabIndex = 105
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GrpDatosAhorro)
        Me.TabPage1.Controls.Add(Me.DrpDatosLibresDeuda)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(269, 423)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Retiro"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GrpDatosAhorro
        '
        Me.GrpDatosAhorro.BackColor = System.Drawing.Color.Transparent
        Me.GrpDatosAhorro.Controls.Add(Me.TxtISR_porcentaje)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtEscolaridad_porcentaje)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtTotalBruto01)
        Me.GrpDatosAhorro.Controls.Add(Me.Label13)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtISR)
        Me.GrpDatosAhorro.Controls.Add(Me.Label12)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtEscolaridad)
        Me.GrpDatosAhorro.Controls.Add(Me.Label11)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtTotalAhorro)
        Me.GrpDatosAhorro.Controls.Add(Me.Label10)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtTotalAhorro_ExtraOrdinario)
        Me.GrpDatosAhorro.Controls.Add(Me.Label8)
        Me.GrpDatosAhorro.Controls.Add(Me.TxtTotalAhorro_Ordinario)
        Me.GrpDatosAhorro.Controls.Add(Me.Label1)
        Me.GrpDatosAhorro.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GrpDatosAhorro.ForeColor = System.Drawing.Color.Navy
        Me.GrpDatosAhorro.Location = New System.Drawing.Point(5, 24)
        Me.GrpDatosAhorro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpDatosAhorro.Name = "GrpDatosAhorro"
        Me.GrpDatosAhorro.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpDatosAhorro.Size = New System.Drawing.Size(258, 183)
        Me.GrpDatosAhorro.TabIndex = 2
        Me.GrpDatosAhorro.TabStop = False
        Me.GrpDatosAhorro.Text = "Datos de ahorro y escolaridad"
        '
        'TxtISR_porcentaje
        '
        Me.TxtISR_porcentaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtISR_porcentaje.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtISR_porcentaje.ForeColor = System.Drawing.Color.Navy
        Me.TxtISR_porcentaje.Location = New System.Drawing.Point(163, 124)
        Me.TxtISR_porcentaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtISR_porcentaje.Name = "TxtISR_porcentaje"
        Me.TxtISR_porcentaje.ReadOnly = True
        Me.TxtISR_porcentaje.Size = New System.Drawing.Size(37, 23)
        Me.TxtISR_porcentaje.TabIndex = 13
        Me.TxtISR_porcentaje.Text = "000"
        Me.TxtISR_porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEscolaridad_porcentaje
        '
        Me.TxtEscolaridad_porcentaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtEscolaridad_porcentaje.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtEscolaridad_porcentaje.ForeColor = System.Drawing.Color.Navy
        Me.TxtEscolaridad_porcentaje.Location = New System.Drawing.Point(163, 98)
        Me.TxtEscolaridad_porcentaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtEscolaridad_porcentaje.Name = "TxtEscolaridad_porcentaje"
        Me.TxtEscolaridad_porcentaje.ReadOnly = True
        Me.TxtEscolaridad_porcentaje.Size = New System.Drawing.Size(37, 23)
        Me.TxtEscolaridad_porcentaje.TabIndex = 12
        Me.TxtEscolaridad_porcentaje.Text = "000"
        Me.TxtEscolaridad_porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalBruto01
        '
        Me.TxtTotalBruto01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalBruto01.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalBruto01.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalBruto01.Location = New System.Drawing.Point(163, 150)
        Me.TxtTotalBruto01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalBruto01.Name = "TxtTotalBruto01"
        Me.TxtTotalBruto01.ReadOnly = True
        Me.TxtTotalBruto01.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalBruto01.TabIndex = 11
        Me.TxtTotalBruto01.Text = "0000000.00"
        Me.TxtTotalBruto01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(7, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 17)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Total Ahorro"
        '
        'TxtISR
        '
        Me.TxtISR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtISR.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtISR.ForeColor = System.Drawing.Color.DarkRed
        Me.TxtISR.Location = New System.Drawing.Point(203, 124)
        Me.TxtISR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtISR.Name = "TxtISR"
        Me.TxtISR.ReadOnly = True
        Me.TxtISR.Size = New System.Drawing.Size(49, 23)
        Me.TxtISR.TabIndex = 9
        Me.TxtISR.Text = "0.00"
        Me.TxtISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(157, 17)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "(-) Impuesto Sobre la Renta %"
        '
        'TxtEscolaridad
        '
        Me.TxtEscolaridad.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtEscolaridad.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtEscolaridad.ForeColor = System.Drawing.Color.Navy
        Me.TxtEscolaridad.Location = New System.Drawing.Point(203, 98)
        Me.TxtEscolaridad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtEscolaridad.Name = "TxtEscolaridad"
        Me.TxtEscolaridad.ReadOnly = True
        Me.TxtEscolaridad.Size = New System.Drawing.Size(49, 23)
        Me.TxtEscolaridad.TabIndex = 7
        Me.TxtEscolaridad.Text = "0.00"
        Me.TxtEscolaridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(6, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 17)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Intereses Escolaridad %"
        '
        'TxtTotalAhorro
        '
        Me.TxtTotalAhorro.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalAhorro.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalAhorro.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalAhorro.Location = New System.Drawing.Point(163, 72)
        Me.TxtTotalAhorro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalAhorro.Name = "TxtTotalAhorro"
        Me.TxtTotalAhorro.ReadOnly = True
        Me.TxtTotalAhorro.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalAhorro.TabIndex = 5
        Me.TxtTotalAhorro.Text = "0000000.00"
        Me.TxtTotalAhorro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "SubTotal"
        '
        'TxtTotalAhorro_ExtraOrdinario
        '
        Me.TxtTotalAhorro_ExtraOrdinario.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalAhorro_ExtraOrdinario.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalAhorro_ExtraOrdinario.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalAhorro_ExtraOrdinario.Location = New System.Drawing.Point(163, 46)
        Me.TxtTotalAhorro_ExtraOrdinario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalAhorro_ExtraOrdinario.Name = "TxtTotalAhorro_ExtraOrdinario"
        Me.TxtTotalAhorro_ExtraOrdinario.ReadOnly = True
        Me.TxtTotalAhorro_ExtraOrdinario.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalAhorro_ExtraOrdinario.TabIndex = 3
        Me.TxtTotalAhorro_ExtraOrdinario.Text = "0000000.00"
        Me.TxtTotalAhorro_ExtraOrdinario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Ahorro Extraordinario"
        '
        'TxtTotalAhorro_Ordinario
        '
        Me.TxtTotalAhorro_Ordinario.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalAhorro_Ordinario.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalAhorro_Ordinario.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalAhorro_Ordinario.Location = New System.Drawing.Point(163, 20)
        Me.TxtTotalAhorro_Ordinario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalAhorro_Ordinario.Name = "TxtTotalAhorro_Ordinario"
        Me.TxtTotalAhorro_Ordinario.ReadOnly = True
        Me.TxtTotalAhorro_Ordinario.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalAhorro_Ordinario.TabIndex = 1
        Me.TxtTotalAhorro_Ordinario.Text = "0000000.00"
        Me.TxtTotalAhorro_Ordinario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ahorro Ordinario"
        '
        'DrpDatosLibresDeuda
        '
        Me.DrpDatosLibresDeuda.BackColor = System.Drawing.Color.Transparent
        Me.DrpDatosLibresDeuda.Controls.Add(Me.txtSegDeuda)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.Label4)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.txtInteres)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.Label2)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.TxtTotal)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.Label17)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.TxtTotalDeudas)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.Label18)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.TxtTotalBruto02)
        Me.DrpDatosLibresDeuda.Controls.Add(Me.Label19)
        Me.DrpDatosLibresDeuda.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DrpDatosLibresDeuda.ForeColor = System.Drawing.Color.Navy
        Me.DrpDatosLibresDeuda.Location = New System.Drawing.Point(5, 232)
        Me.DrpDatosLibresDeuda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrpDatosLibresDeuda.Name = "DrpDatosLibresDeuda"
        Me.DrpDatosLibresDeuda.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrpDatosLibresDeuda.Size = New System.Drawing.Size(258, 156)
        Me.DrpDatosLibresDeuda.TabIndex = 3
        Me.DrpDatosLibresDeuda.TabStop = False
        Me.DrpDatosLibresDeuda.Text = "Datos Liquidación"
        '
        'txtSegDeuda
        '
        Me.txtSegDeuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSegDeuda.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.txtSegDeuda.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSegDeuda.Location = New System.Drawing.Point(162, 97)
        Me.txtSegDeuda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSegDeuda.Name = "txtSegDeuda"
        Me.txtSegDeuda.ReadOnly = True
        Me.txtSegDeuda.Size = New System.Drawing.Size(90, 23)
        Me.txtSegDeuda.TabIndex = 9
        Me.txtSegDeuda.Text = "0.00"
        Me.txtSegDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Total Seguro Deuda a Pagar"
        '
        'txtInteres
        '
        Me.txtInteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInteres.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.txtInteres.ForeColor = System.Drawing.Color.DarkRed
        Me.txtInteres.Location = New System.Drawing.Point(162, 71)
        Me.txtInteres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.ReadOnly = True
        Me.txtInteres.Size = New System.Drawing.Size(90, 23)
        Me.txtInteres.TabIndex = 7
        Me.txtInteres.Text = "0.00"
        Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Total Intereses a Pagar"
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotal.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotal.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotal.Location = New System.Drawing.Point(162, 123)
        Me.TxtTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotal.TabIndex = 5
        Me.TxtTotal.Text = "0.00"
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(5, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 17)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Total a Devolver"
        '
        'TxtTotalDeudas
        '
        Me.TxtTotalDeudas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalDeudas.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalDeudas.ForeColor = System.Drawing.Color.DarkRed
        Me.TxtTotalDeudas.Location = New System.Drawing.Point(162, 45)
        Me.TxtTotalDeudas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalDeudas.Name = "TxtTotalDeudas"
        Me.TxtTotalDeudas.ReadOnly = True
        Me.TxtTotalDeudas.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalDeudas.TabIndex = 3
        Me.TxtTotalDeudas.Text = "0.00"
        Me.TxtTotalDeudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(5, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 17)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Total Deudas pendientes"
        '
        'TxtTotalBruto02
        '
        Me.TxtTotalBruto02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalBruto02.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.TxtTotalBruto02.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalBruto02.Location = New System.Drawing.Point(162, 19)
        Me.TxtTotalBruto02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalBruto02.Name = "TxtTotalBruto02"
        Me.TxtTotalBruto02.ReadOnly = True
        Me.TxtTotalBruto02.Size = New System.Drawing.Size(90, 23)
        Me.TxtTotalBruto02.TabIndex = 1
        Me.TxtTotalBruto02.Text = "0.00"
        Me.TxtTotalBruto02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(5, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 17)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Total Ahorro"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(530, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(115, 170)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 106
        Me.pbImagen.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(250, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Fecha Depósito:"
        '
        'dpFechaContable
        '
        Me.dpFechaContable.CustomFormat = "dd/MMM/yyyy"
        Me.dpFechaContable.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaContable.Location = New System.Drawing.Point(338, 118)
        Me.dpFechaContable.Name = "dpFechaContable"
        Me.dpFechaContable.Size = New System.Drawing.Size(102, 22)
        Me.dpFechaContable.TabIndex = 108
        '
        'SelectAll
        '
        Me.SelectAll.AutoSize = True
        Me.SelectAll.BackColor = System.Drawing.Color.Transparent
        Me.SelectAll.Location = New System.Drawing.Point(10, 118)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(115, 20)
        Me.SelectAll.TabIndex = 111
        Me.SelectAll.Text = "Seleccionar Todos"
        Me.SelectAll.UseVisualStyleBackColor = False
        '
        'lblProcesando
        '
        Me.lblProcesando.AutoSize = True
        Me.lblProcesando.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblProcesando.ForeColor = System.Drawing.Color.Red
        Me.lblProcesando.Location = New System.Drawing.Point(120, 120)
        Me.lblProcesando.Name = "lblProcesando"
        Me.lblProcesando.Size = New System.Drawing.Size(119, 16)
        Me.lblProcesando.TabIndex = 112
        Me.lblProcesando.Text = "Procesando... Espere"
        Me.lblProcesando.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(6, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 113
        Me.Label14.Text = "Total: $ 0.00"
        '
        'dgvRetirosEmitidos
        '
        Me.dgvRetirosEmitidos.AllowUserToAddRows = False
        Me.dgvRetirosEmitidos.AllowUserToDeleteRows = False
        Me.dgvRetirosEmitidos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvRetirosEmitidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRetirosEmitidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRetirosEmitidos.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetirosEmitidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRetirosEmitidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetirosEmitidos.ContextMenuStrip = Me.CMSSolicitutes_noaprobadas
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRetirosEmitidos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRetirosEmitidos.Location = New System.Drawing.Point(5, 164)
        Me.dgvRetirosEmitidos.MultiSelect = False
        Me.dgvRetirosEmitidos.Name = "dgvRetirosEmitidos"
        Me.dgvRetirosEmitidos.RowHeadersVisible = False
        Me.dgvRetirosEmitidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRetirosEmitidos.Size = New System.Drawing.Size(639, 284)
        Me.dgvRetirosEmitidos.TabIndex = 126
        '
        'frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 454)
        Me.Controls.Add(Me.lblProcesando)
        Me.Controls.Add(Me.dgvRetirosEmitidos)
        Me.Controls.Add(Me.SelectAll)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dpFechaContable)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Btn_Aprobar)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Pago de Retiro de Ahorro Extraordinario"
        Me.CMSSolicitutes_noaprobadas.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GrpDatosAhorro.ResumeLayout(False)
        Me.GrpDatosAhorro.PerformLayout()
        Me.DrpDatosLibresDeuda.ResumeLayout(False)
        Me.DrpDatosLibresDeuda.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRetirosEmitidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMSSolicitutes_noaprobadas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMSSolicitudes_aprobadasnoemitidas_undoactual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSSolicitudes_aprobadasnoemitidas_undotodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Cantidad_registros_seleccionados02 As System.Windows.Forms.Label
    Friend WithEvents CmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblMensaje02 As System.Windows.Forms.Label
    Friend WithEvents CmbCuentaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Aprobar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DrpDatosLibresDeuda As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalDeudas As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalBruto02 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GrpDatosAhorro As System.Windows.Forms.GroupBox
    Friend WithEvents TxtISR_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents TxtEscolaridad_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalBruto01 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtISR As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtEscolaridad As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAhorro As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAhorro_ExtraOrdinario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAhorro_Ordinario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents txtSegDeuda As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dpFechaContable As System.Windows.Forms.DateTimePicker
    Friend WithEvents SelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblProcesando As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvRetirosEmitidos As System.Windows.Forms.DataGridView
End Class
