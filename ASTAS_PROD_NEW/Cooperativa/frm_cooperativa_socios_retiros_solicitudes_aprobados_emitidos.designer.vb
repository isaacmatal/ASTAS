<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos))
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TT02 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TTSocio = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TT01 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblMensaje03 = New System.Windows.Forms.Label
        Me.Btn_aceptar02 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbVerporfechas = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DataGrid_aprobadas_y_emitidos = New System.Windows.Forms.DataGridView
        Me.CmbCompania = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkFiltroFacturas = New System.Windows.Forms.CheckBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.lblNumRegs = New System.Windows.Forms.Label
        CType(Me.DataGrid_aprobadas_y_emitidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TT02
        '
        Me.TT02.Tag = ""
        Me.TT02.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'TTSocio
        '
        Me.TTSocio.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TTSocio.ToolTipTitle = "Datos Socio"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "edittrash.gif")
        Me.ImageList1.Images.SetKeyName(1, "editdelete.gif")
        Me.ImageList1.Images.SetKeyName(2, "editshred.gif")
        Me.ImageList1.Images.SetKeyName(3, "edit.gif")
        Me.ImageList1.Images.SetKeyName(4, "fileclose.gif")
        Me.ImageList1.Images.SetKeyName(5, "filenew.gif")
        Me.ImageList1.Images.SetKeyName(6, "filesave.gif")
        Me.ImageList1.Images.SetKeyName(7, "filesaveas.gif")
        Me.ImageList1.Images.SetKeyName(8, "find.gif")
        Me.ImageList1.Images.SetKeyName(9, "reload_page.gif")
        Me.ImageList1.Images.SetKeyName(10, "search.gif")
        Me.ImageList1.Images.SetKeyName(11, "viewmag.gif")
        Me.ImageList1.Images.SetKeyName(12, "cancel.gif")
        Me.ImageList1.Images.SetKeyName(13, "button_cancel.gif")
        Me.ImageList1.Images.SetKeyName(14, "no.gif")
        Me.ImageList1.Images.SetKeyName(15, "down.gif")
        Me.ImageList1.Images.SetKeyName(16, "reload3.gif")
        Me.ImageList1.Images.SetKeyName(17, "toggle_log.gif")
        Me.ImageList1.Images.SetKeyName(18, "editpaste.gif")
        Me.ImageList1.Images.SetKeyName(19, "fileprint.gif")
        Me.ImageList1.Images.SetKeyName(20, "apply.gif")
        Me.ImageList1.Images.SetKeyName(21, "forward.gif")
        '
        'TT01
        '
        Me.TT01.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT01.ToolTipTitle = "Tipo proceso de las solicitudes"
        '
        'LblMensaje03
        '
        Me.LblMensaje03.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblMensaje03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblMensaje03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblMensaje03.ForeColor = System.Drawing.Color.Navy
        Me.LblMensaje03.Location = New System.Drawing.Point(8, 178)
        Me.LblMensaje03.Name = "LblMensaje03"
        Me.LblMensaje03.Size = New System.Drawing.Size(214, 72)
        Me.LblMensaje03.TabIndex = 108
        Me.LblMensaje03.Text = "Label3"
        '
        'Btn_aceptar02
        '
        Me.Btn_aceptar02.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Btn_aceptar02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_aceptar02.Image = CType(resources.GetObject("Btn_aceptar02.Image"), System.Drawing.Image)
        Me.Btn_aceptar02.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_aceptar02.Location = New System.Drawing.Point(464, 51)
        Me.Btn_aceptar02.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Btn_aceptar02.Name = "Btn_aceptar02"
        Me.Btn_aceptar02.Size = New System.Drawing.Size(72, 24)
        Me.Btn_aceptar02.TabIndex = 3
        Me.Btn_aceptar02.Text = "Buscar"
        Me.Btn_aceptar02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_aceptar02.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(167, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 16)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Hasta"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(208, 51)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(96, 22)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 16)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Desde"
        '
        'CmbVerporfechas
        '
        Me.CmbVerporfechas.BackColor = System.Drawing.SystemColors.Window
        Me.CmbVerporfechas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVerporfechas.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CmbVerporfechas.ForeColor = System.Drawing.Color.Navy
        Me.CmbVerporfechas.FormattingEnabled = True
        Me.CmbVerporfechas.Items.AddRange(New Object() {"Día específico", "Mes y año", "Año", "Rango de fechas", "Todas"})
        Me.CmbVerporfechas.Location = New System.Drawing.Point(558, 2)
        Me.CmbVerporfechas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbVerporfechas.Name = "CmbVerporfechas"
        Me.CmbVerporfechas.Size = New System.Drawing.Size(110, 24)
        Me.CmbVerporfechas.TabIndex = 0
        Me.CmbVerporfechas.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(224, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Ver por Fecha"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(64, 51)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DataGrid_aprobadas_y_emitidos
        '
        Me.DataGrid_aprobadas_y_emitidos.AllowUserToAddRows = False
        Me.DataGrid_aprobadas_y_emitidos.AllowUserToDeleteRows = False
        Me.DataGrid_aprobadas_y_emitidos.AllowUserToOrderColumns = True
        Me.DataGrid_aprobadas_y_emitidos.AllowUserToResizeColumns = False
        Me.DataGrid_aprobadas_y_emitidos.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid_aprobadas_y_emitidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.DataGrid_aprobadas_y_emitidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid_aprobadas_y_emitidos.BackgroundColor = System.Drawing.Color.Azure
        Me.DataGrid_aprobadas_y_emitidos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_aprobadas_y_emitidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DataGrid_aprobadas_y_emitidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid_aprobadas_y_emitidos.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGrid_aprobadas_y_emitidos.Location = New System.Drawing.Point(8, 96)
        Me.DataGrid_aprobadas_y_emitidos.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.DataGrid_aprobadas_y_emitidos.Name = "DataGrid_aprobadas_y_emitidos"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_aprobadas_y_emitidos.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.DataGrid_aprobadas_y_emitidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrid_aprobadas_y_emitidos.Size = New System.Drawing.Size(832, 378)
        Me.DataGrid_aprobadas_y_emitidos.TabIndex = 54
        '
        'CmbCompania
        '
        Me.CmbCompania.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompania.Enabled = False
        Me.CmbCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CmbCompania.ForeColor = System.Drawing.Color.Navy
        Me.CmbCompania.FormattingEnabled = True
        Me.CmbCompania.Location = New System.Drawing.Point(64, 22)
        Me.CmbCompania.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbCompania.Name = "CmbCompania"
        Me.CmbCompania.Size = New System.Drawing.Size(472, 24)
        Me.CmbCompania.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(8, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Compañía"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkFiltroFacturas)
        Me.GroupBox1.Controls.Add(Me.CmbCompania)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblMensaje03)
        Me.GroupBox1.Controls.Add(Me.Btn_aceptar02)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 81)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'chkFiltroFacturas
        '
        Me.chkFiltroFacturas.AutoSize = True
        Me.chkFiltroFacturas.Location = New System.Drawing.Point(311, 52)
        Me.chkFiltroFacturas.Name = "chkFiltroFacturas"
        Me.chkFiltroFacturas.Size = New System.Drawing.Size(127, 20)
        Me.chkFiltroFacturas.TabIndex = 109
        Me.chkFiltroFacturas.Text = "Pago de Facturas"
        Me.chkFiltroFacturas.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(752, 2)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(88, 90)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 109
        Me.pbImagen.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(558, 45)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 110
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblNumRegs
        '
        Me.lblNumRegs.AutoSize = True
        Me.lblNumRegs.BackColor = System.Drawing.Color.Transparent
        Me.lblNumRegs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumRegs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNumRegs.ForeColor = System.Drawing.Color.Blue
        Me.lblNumRegs.Location = New System.Drawing.Point(558, 71)
        Me.lblNumRegs.Name = "lblNumRegs"
        Me.lblNumRegs.Size = New System.Drawing.Size(148, 18)
        Me.lblNumRegs.TabIndex = 111
        Me.lblNumRegs.Text = "0 Registros Encontrados"
        '
        'frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 479)
        Me.Controls.Add(Me.lblNumRegs)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGrid_aprobadas_y_emitidos)
        Me.Controls.Add(Me.CmbVerporfechas)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Consulta de solicitudes de retiro"
        CType(Me.DataGrid_aprobadas_y_emitidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TT02 As System.Windows.Forms.ToolTip
    Friend WithEvents TTSocio As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TT01 As System.Windows.Forms.ToolTip
    Friend WithEvents LblMensaje03 As System.Windows.Forms.Label
    Friend WithEvents Btn_aceptar02 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CmbVerporfechas As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGrid_aprobadas_y_emitidos As System.Windows.Forms.DataGridView
    Friend WithEvents CmbCompania As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents chkFiltroFacturas As System.Windows.Forms.CheckBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblNumRegs As System.Windows.Forms.Label
End Class
