<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolSinAprobar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.CmsAutorizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiAutorizacion = New System.Windows.Forms.ToolStripMenuItem
        Me.btnAutorizar = New System.Windows.Forms.Button
        Me.gbProc = New System.Windows.Forms.GroupBox
        Me.rbSelec = New System.Windows.Forms.RadioButton
        Me.rbTodas = New System.Windows.Forms.RadioButton
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsAutorizacion.SuspendLayout()
        Me.gbProc.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = Global.ASTAS.My.Resources.Resources.down
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(12, 66)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(107, 24)
        Me.BtnBuscar.TabIndex = 25
        Me.BtnBuscar.Text = "Refrescar Grid"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = False
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
        Me.btnAutorizar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutorizar.Location = New System.Drawing.Point(170, 24)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(94, 28)
        Me.btnAutorizar.TabIndex = 29
        Me.btnAutorizar.Text = "Procesar"
        Me.btnAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAutorizar.UseVisualStyleBackColor = False
        '
        'gbProc
        '
        Me.gbProc.BackColor = System.Drawing.Color.Transparent
        Me.gbProc.Controls.Add(Me.rbSelec)
        Me.gbProc.Controls.Add(Me.rbTodas)
        Me.gbProc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProc.ForeColor = System.Drawing.Color.Navy
        Me.gbProc.Location = New System.Drawing.Point(12, 12)
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
        'FrmSolSinAprobar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 596)
        Me.Controls.Add(Me.gbProc)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSolSinAprobar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Gerencia Aprobación de Solicitudes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsAutorizacion.ResumeLayout(False)
        Me.gbProc.ResumeLayout(False)
        Me.gbProc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents CmsAutorizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TsmiAutorizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents gbProc As System.Windows.Forms.GroupBox
    Friend WithEvents rbSelec As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodas As System.Windows.Forms.RadioButton
End Class
