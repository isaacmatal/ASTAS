<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Imprimir_Cheques
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.chkSelAntes = New System.Windows.Forms.CheckBox
        Me.btnSelImpresora = New System.Windows.Forms.Button
        Me.dgvCheques = New System.Windows.Forms.DataGridView
        Me.ListView1 = New System.Windows.Forms.ListView
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImprimir.Location = New System.Drawing.Point(11, 6)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(96, 28)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPreview.Location = New System.Drawing.Point(162, 3)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(96, 28)
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Vista preliminar"
        Me.btnPreview.Visible = False
        '
        'chkSelAntes
        '
        Me.chkSelAntes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelAntes.Checked = True
        Me.chkSelAntes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSelAntes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSelAntes.Location = New System.Drawing.Point(332, 6)
        Me.chkSelAntes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSelAntes.Name = "chkSelAntes"
        Me.chkSelAntes.Size = New System.Drawing.Size(176, 25)
        Me.chkSelAntes.TabIndex = 3
        Me.chkSelAntes.Text = "Seleccionar antes de imprimir"
        Me.chkSelAntes.Visible = False
        '
        'btnSelImpresora
        '
        Me.btnSelImpresora.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelImpresora.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSelImpresora.Location = New System.Drawing.Point(488, 3)
        Me.btnSelImpresora.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSelImpresora.Name = "btnSelImpresora"
        Me.btnSelImpresora.Size = New System.Drawing.Size(96, 28)
        Me.btnSelImpresora.TabIndex = 1
        Me.btnSelImpresora.Text = "Sel. Impresora"
        Me.btnSelImpresora.Visible = False
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvCheques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCheques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCheques.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCheques.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCheques.Location = New System.Drawing.Point(11, 39)
        Me.dgvCheques.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.ReadOnly = True
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCheques.Size = New System.Drawing.Size(663, 261)
        Me.dgvCheques.TabIndex = 5
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(40, 69)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(402, 57)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Contabilidad_Imprimir_Cheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 313)
        Me.Controls.Add(Me.dgvCheques)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnSelImpresora)
        Me.Controls.Add(Me.chkSelAntes)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnImprimir)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Imprimir_Cheques"
        Me.Text = "Imprimir Cheques"
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents chkSelAntes As System.Windows.Forms.CheckBox
    Friend WithEvents btnSelImpresora As System.Windows.Forms.Button
    Friend WithEvents dgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView


End Class
