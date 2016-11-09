<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaDepositosBecasBuscar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCooperativaDepositosBecasBuscar))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscarSoc = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFindText = New System.Windows.Forms.TextBox
        Me.dgvMaestro = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dpFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarSoc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFindText)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(713, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'dpFecha
        '
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFecha.Location = New System.Drawing.Point(487, 23)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(101, 22)
        Me.dpFecha.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(402, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Fecha Remesa:"
        '
        'BtnBuscarSoc
        '
        Me.BtnBuscarSoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSoc.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSoc.Image = CType(resources.GetObject("BtnBuscarSoc.Image"), System.Drawing.Image)
        Me.BtnBuscarSoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSoc.Location = New System.Drawing.Point(360, 22)
        Me.BtnBuscarSoc.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarSoc.Name = "BtnBuscarSoc"
        Me.BtnBuscarSoc.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSoc.TabIndex = 23
        Me.BtnBuscarSoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSoc.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Concepto:"
        '
        'txtFindText
        '
        Me.txtFindText.Location = New System.Drawing.Point(74, 23)
        Me.txtFindText.Name = "txtFindText"
        Me.txtFindText.Size = New System.Drawing.Size(281, 22)
        Me.txtFindText.TabIndex = 0
        '
        'dgvMaestro
        '
        Me.dgvMaestro.AllowUserToAddRows = False
        Me.dgvMaestro.AllowUserToDeleteRows = False
        Me.dgvMaestro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvMaestro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvMaestro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaestro.Location = New System.Drawing.Point(12, 94)
        Me.dgvMaestro.Name = "dgvMaestro"
        Me.dgvMaestro.ReadOnly = True
        Me.dgvMaestro.Size = New System.Drawing.Size(713, 384)
        Me.dgvMaestro.TabIndex = 2
        '
        'FrmCooperativaDepositosBecasBuscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(737, 490)
        Me.Controls.Add(Me.dgvMaestro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmCooperativaDepositosBecasBuscar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFindText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSoc As System.Windows.Forms.Button
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMaestro As System.Windows.Forms.DataGridView
End Class
