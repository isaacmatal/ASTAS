<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCooperativaReporteReciboRetiros
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnImp = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvRetiros = New System.Windows.Forms.DataGridView
        Me.imprimir = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.crvRecibo = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkSelec = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRetiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnImp)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.dpHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dpDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 43)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btnImp
        '
        Me.btnImp.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImp.Location = New System.Drawing.Point(477, 11)
        Me.btnImp.Name = "btnImp"
        Me.btnImp.Size = New System.Drawing.Size(163, 26)
        Me.btnImp.TabIndex = 6
        Me.btnImp.Text = "Imprimir Seleccionados"
        Me.btnImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImp.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.ASTAS.My.Resources.Resources.search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(379, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 26)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dpHasta
        '
        Me.dpHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpHasta.Location = New System.Drawing.Point(251, 13)
        Me.dpHasta.Name = "dpHasta"
        Me.dpHasta.Size = New System.Drawing.Size(99, 20)
        Me.dpHasta.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta:"
        '
        'dpDesde
        '
        Me.dpDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDesde.Location = New System.Drawing.Point(53, 14)
        Me.dpDesde.Name = "dpDesde"
        Me.dpDesde.Size = New System.Drawing.Size(111, 20)
        Me.dpDesde.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde:"
        '
        'dgvRetiros
        '
        Me.dgvRetiros.AllowUserToAddRows = False
        Me.dgvRetiros.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvRetiros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRetiros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRetiros.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvRetiros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetiros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.imprimir})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRetiros.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRetiros.Location = New System.Drawing.Point(1, 51)
        Me.dgvRetiros.Name = "dgvRetiros"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiros.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRetiros.RowHeadersVisible = False
        Me.dgvRetiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRetiros.Size = New System.Drawing.Size(813, 134)
        Me.dgvRetiros.TabIndex = 1
        '
        'imprimir
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle3.NullValue = False
        Me.imprimir.DefaultCellStyle = DataGridViewCellStyle3
        Me.imprimir.HeaderText = "Imprimir"
        Me.imprimir.Name = "imprimir"
        Me.imprimir.Width = 50
        '
        'crvRecibo
        '
        Me.crvRecibo.ActiveViewIndex = -1
        Me.crvRecibo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRecibo.DisplayGroupTree = False
        Me.crvRecibo.Location = New System.Drawing.Point(-1, 187)
        Me.crvRecibo.Name = "crvRecibo"
        Me.crvRecibo.SelectionFormula = ""
        Me.crvRecibo.Size = New System.Drawing.Size(817, 249)
        Me.crvRecibo.TabIndex = 2
        Me.crvRecibo.ViewTimeSelectionFormula = ""
        '
        'chkSelec
        '
        Me.chkSelec.AutoSize = True
        Me.chkSelec.Location = New System.Drawing.Point(23, 54)
        Me.chkSelec.Name = "chkSelec"
        Me.chkSelec.Size = New System.Drawing.Size(15, 14)
        Me.chkSelec.TabIndex = 3
        Me.chkSelec.UseVisualStyleBackColor = True
        '
        'frmCooperativaReporteReciboRetiros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 435)
        Me.Controls.Add(Me.chkSelec)
        Me.Controls.Add(Me.crvRecibo)
        Me.Controls.Add(Me.dgvRetiros)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCooperativaReporteReciboRetiros"
        Me.Text = "frmCooperativaReporteReciboRetiros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvRetiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRetiros As System.Windows.Forms.DataGridView
    Friend WithEvents crvRecibo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkSelec As System.Windows.Forms.CheckBox
    Friend WithEvents imprimir As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnImp As System.Windows.Forms.Button
End Class
