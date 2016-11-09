<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProgramarSolicitudes
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProgramarSolicitudes))
        Me.CbxTipoSolicitudes = New System.Windows.Forms.ComboBox
        Me.DpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.TxtNumSol = New System.Windows.Forms.TextBox
        Me.BtnProgramacion = New System.Windows.Forms.Button
        Me.btnProgEspecial = New System.Windows.Forms.Button
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbxTipoSolicitudes
        '
        Me.CbxTipoSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxTipoSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipoSolicitudes.FormattingEnabled = True
        Me.CbxTipoSolicitudes.Location = New System.Drawing.Point(82, 21)
        Me.CbxTipoSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxTipoSolicitudes.Name = "CbxTipoSolicitudes"
        Me.CbxTipoSolicitudes.Size = New System.Drawing.Size(315, 24)
        Me.CbxTipoSolicitudes.TabIndex = 23
        '
        'DpFechaFin
        '
        Me.DpFechaFin.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaFin.Location = New System.Drawing.Point(309, 50)
        Me.DpFechaFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaFin.Name = "DpFechaFin"
        Me.DpFechaFin.Size = New System.Drawing.Size(88, 22)
        Me.DpFechaFin.TabIndex = 27
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvSolicitudes.Location = New System.Drawing.Point(8, 96)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(944, 456)
        Me.DgvSolicitudes.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(10, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Tipo Solicitud:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(80, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'DpFechaIni
        '
        Me.DpFechaIni.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaIni.Location = New System.Drawing.Point(120, 49)
        Me.DpFechaIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaIni.Name = "DpFechaIni"
        Me.DpFechaIni.Size = New System.Drawing.Size(88, 22)
        Me.DpFechaIni.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(269, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(405, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "N° Solicitud:"
        Me.Label14.Visible = False
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.BackColor = System.Drawing.Color.Transparent
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaFin)
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaIni)
        Me.GbxCriterioBusq.Controls.Add(Me.Label1)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscar)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxTipoSolicitudes)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNumSol)
        Me.GbxCriterioBusq.Controls.Add(Me.Label12)
        Me.GbxCriterioBusq.Controls.Add(Me.Label2)
        Me.GbxCriterioBusq.Controls.Add(Me.Label14)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 8)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(560, 80)
        Me.GbxCriterioBusq.TabIndex = 30
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(478, 49)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 24)
        Me.BtnBuscar.TabIndex = 25
        Me.BtnBuscar.Text = "&Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtNumSol
        '
        Me.TxtNumSol.ForeColor = System.Drawing.Color.Navy
        Me.TxtNumSol.Location = New System.Drawing.Point(469, 22)
        Me.TxtNumSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumSol.Name = "TxtNumSol"
        Me.TxtNumSol.Size = New System.Drawing.Size(81, 22)
        Me.TxtNumSol.TabIndex = 3
        Me.TxtNumSol.Visible = False
        '
        'BtnProgramacion
        '
        Me.BtnProgramacion.BackColor = System.Drawing.Color.Transparent
        Me.BtnProgramacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnProgramacion.ForeColor = System.Drawing.Color.Black
        Me.BtnProgramacion.Image = CType(resources.GetObject("BtnProgramacion.Image"), System.Drawing.Image)
        Me.BtnProgramacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnProgramacion.Location = New System.Drawing.Point(585, 13)
        Me.BtnProgramacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnProgramacion.Name = "BtnProgramacion"
        Me.BtnProgramacion.Size = New System.Drawing.Size(72, 40)
        Me.BtnProgramacion.TabIndex = 32
        Me.BtnProgramacion.Text = "&Programar"
        Me.BtnProgramacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnProgramacion.UseVisualStyleBackColor = False
        '
        'btnProgEspecial
        '
        Me.btnProgEspecial.BackColor = System.Drawing.Color.Transparent
        Me.btnProgEspecial.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProgEspecial.ForeColor = System.Drawing.Color.Black
        Me.btnProgEspecial.Image = Global.ASTAS.My.Resources.Resources.todo
        Me.btnProgEspecial.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProgEspecial.Location = New System.Drawing.Point(663, 13)
        Me.btnProgEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProgEspecial.Name = "btnProgEspecial"
        Me.btnProgEspecial.Size = New System.Drawing.Size(72, 40)
        Me.btnProgEspecial.TabIndex = 33
        Me.btnProgEspecial.Text = "&Preferencial"
        Me.btnProgEspecial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProgEspecial.UseVisualStyleBackColor = False
        '
        'FrmProgramarSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 555)
        Me.Controls.Add(Me.btnProgEspecial)
        Me.Controls.Add(Me.BtnProgramacion)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmProgramarSolicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Programación de Solicitudes"
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CbxTipoSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents BtnProgramacion As System.Windows.Forms.Button
    Friend WithEvents DpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumSol As System.Windows.Forms.TextBox
    Friend WithEvents btnProgEspecial As System.Windows.Forms.Button
End Class
