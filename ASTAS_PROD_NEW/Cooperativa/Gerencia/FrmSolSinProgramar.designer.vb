<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolSinProgramar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolSinProgramar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TxtNumSol = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CbxTipoSolicitudes = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.DpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.CmsAutorizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiAutorizacion = New System.Windows.Forms.ToolStripMenuItem
        Me.btnAutorizar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.dpFechaAut = New System.Windows.Forms.DateTimePicker
        Me.gbProc = New System.Windows.Forms.GroupBox
        Me.rbSelec = New System.Windows.Forms.RadioButton
        Me.rbTodas = New System.Windows.Forms.RadioButton
        Me.btnDenegar = New System.Windows.Forms.Button
        Me.btnAnular = New System.Windows.Forms.Button
        Me.GbxCriterioBusq.SuspendLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsAutorizacion.SuspendLayout()
        Me.gbProc.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNumSol
        '
        Me.TxtNumSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtNumSol.ForeColor = System.Drawing.Color.Navy
        Me.TxtNumSol.Location = New System.Drawing.Point(486, 25)
        Me.TxtNumSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumSol.Name = "TxtNumSol"
        Me.TxtNumSol.Size = New System.Drawing.Size(80, 22)
        Me.TxtNumSol.TabIndex = 3
        Me.TxtNumSol.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(53, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'CbxTipoSolicitudes
        '
        Me.CbxTipoSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxTipoSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipoSolicitudes.FormattingEnabled = True
        Me.CbxTipoSolicitudes.Location = New System.Drawing.Point(95, 23)
        Me.CbxTipoSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxTipoSolicitudes.Name = "CbxTipoSolicitudes"
        Me.CbxTipoSolicitudes.Size = New System.Drawing.Size(315, 24)
        Me.CbxTipoSolicitudes.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(7, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Tipo de Solicitud:"
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
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(5, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(576, 86)
        Me.GbxCriterioBusq.TabIndex = 24
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'DpFechaFin
        '
        Me.DpFechaFin.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaFin.Location = New System.Drawing.Point(307, 51)
        Me.DpFechaFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaFin.Name = "DpFechaFin"
        Me.DpFechaFin.Size = New System.Drawing.Size(103, 22)
        Me.DpFechaFin.TabIndex = 27
        '
        'DpFechaIni
        '
        Me.DpFechaIni.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaIni.Location = New System.Drawing.Point(93, 51)
        Me.DpFechaIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaIni.Name = "DpFechaIni"
        Me.DpFechaIni.Size = New System.Drawing.Size(103, 22)
        Me.DpFechaIni.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(267, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta:"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(494, 54)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 24)
        Me.BtnBuscar.TabIndex = 25
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(415, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "N° Solicitud:"
        Me.Label14.Visible = False
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSolicitudes.ContextMenuStrip = Me.CmsAutorizacion
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvSolicitudes.Location = New System.Drawing.Point(8, 96)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.RowHeadersVisible = False
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(936, 496)
        Me.DgvSolicitudes.TabIndex = 26
        '
        'CmsAutorizacion
        '
        Me.CmsAutorizacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiAutorizacion})
        Me.CmsAutorizacion.Name = "CmsAutorizacion"
        Me.CmsAutorizacion.Size = New System.Drawing.Size(145, 26)
        '
        'TsmiAutorizacion
        '
        Me.TsmiAutorizacion.Name = "TsmiAutorizacion"
        Me.TsmiAutorizacion.Size = New System.Drawing.Size(144, 22)
        Me.TsmiAutorizacion.Text = "Autorizacion"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackColor = System.Drawing.Color.Transparent
        Me.btnAutorizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizar.ForeColor = System.Drawing.Color.Navy
        Me.btnAutorizar.Image = CType(resources.GetObject("btnAutorizar.Image"), System.Drawing.Image)
        Me.btnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutorizar.Location = New System.Drawing.Point(849, 4)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(94, 28)
        Me.btnAutorizar.TabIndex = 29
        Me.btnAutorizar.Text = "Autorizar"
        Me.btnAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAutorizar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(612, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Fecha Autorización:"
        '
        'dpFechaAut
        '
        Me.dpFechaAut.CustomFormat = "dd/MMM/yyyy"
        Me.dpFechaAut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaAut.Location = New System.Drawing.Point(719, 10)
        Me.dpFechaAut.Name = "dpFechaAut"
        Me.dpFechaAut.Size = New System.Drawing.Size(103, 22)
        Me.dpFechaAut.TabIndex = 31
        '
        'gbProc
        '
        Me.gbProc.BackColor = System.Drawing.Color.Transparent
        Me.gbProc.Controls.Add(Me.rbSelec)
        Me.gbProc.Controls.Add(Me.rbTodas)
        Me.gbProc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProc.ForeColor = System.Drawing.Color.Navy
        Me.gbProc.Location = New System.Drawing.Point(645, 38)
        Me.gbProc.Name = "gbProc"
        Me.gbProc.Size = New System.Drawing.Size(152, 47)
        Me.gbProc.TabIndex = 32
        Me.gbProc.TabStop = False
        Me.gbProc.Text = "Marcar"
        '
        'rbSelec
        '
        Me.rbSelec.Checked = True
        Me.rbSelec.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSelec.ForeColor = System.Drawing.Color.Black
        Me.rbSelec.Location = New System.Drawing.Point(67, 20)
        Me.rbSelec.Name = "rbSelec"
        Me.rbSelec.Size = New System.Drawing.Size(81, 20)
        Me.rbSelec.TabIndex = 1
        Me.rbSelec.TabStop = True
        Me.rbSelec.Text = "Individual"
        Me.rbSelec.UseVisualStyleBackColor = True
        '
        'rbTodas
        '
        Me.rbTodas.AutoSize = True
        Me.rbTodas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodas.ForeColor = System.Drawing.Color.Black
        Me.rbTodas.Location = New System.Drawing.Point(6, 20)
        Me.rbTodas.Name = "rbTodas"
        Me.rbTodas.Size = New System.Drawing.Size(56, 20)
        Me.rbTodas.TabIndex = 0
        Me.rbTodas.Text = "Todas"
        Me.rbTodas.UseVisualStyleBackColor = True
        '
        'btnDenegar
        '
        Me.btnDenegar.BackColor = System.Drawing.Color.Transparent
        Me.btnDenegar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDenegar.ForeColor = System.Drawing.Color.Navy
        Me.btnDenegar.Image = Global.ASTAS.My.Resources.Resources.todo
        Me.btnDenegar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDenegar.Location = New System.Drawing.Point(849, 34)
        Me.btnDenegar.Name = "btnDenegar"
        Me.btnDenegar.Size = New System.Drawing.Size(94, 28)
        Me.btnDenegar.TabIndex = 33
        Me.btnDenegar.Text = "Denegar"
        Me.btnDenegar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDenegar.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.Transparent
        Me.btnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnular.ForeColor = System.Drawing.Color.Navy
        Me.btnAnular.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(849, 64)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(94, 28)
        Me.btnAnular.TabIndex = 34
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'FrmSolSinProgramar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 596)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnDenegar)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.gbProc)
        Me.Controls.Add(Me.dpFechaAut)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSolSinProgramar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Gerencia Aprobación de Solicitudes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsAutorizacion.ResumeLayout(False)
        Me.gbProc.ResumeLayout(False)
        Me.gbProc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtNumSol As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CbxTipoSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents CmsAutorizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TsmiAutorizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dpFechaAut As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbProc As System.Windows.Forms.GroupBox
    Friend WithEvents rbSelec As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodas As System.Windows.Forms.RadioButton
    Friend WithEvents btnDenegar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
End Class
