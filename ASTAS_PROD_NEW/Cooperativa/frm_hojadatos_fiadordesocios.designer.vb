<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_hojadatos_fiadordesocios
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGrid01 = New System.Windows.Forms.DataGridView
        Me.company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codempl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codfiad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombrecomp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numsol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descsol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sdoact = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totdeu = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid01
        '
        Me.DataGrid01.AllowUserToAddRows = False
        Me.DataGrid01.AllowUserToDeleteRows = False
        Me.DataGrid01.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid01.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.company, Me.codempl, Me.codfiad, Me.nombrecomp, Me.numsol, Me.descsol, Me.sdoact, Me.totdeu})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid01.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGrid01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid01.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid01.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DataGrid01.MultiSelect = False
        Me.DataGrid01.Name = "DataGrid01"
        Me.DataGrid01.ReadOnly = True
        Me.DataGrid01.RowHeadersVisible = False
        Me.DataGrid01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrid01.Size = New System.Drawing.Size(595, 266)
        Me.DataGrid01.TabIndex = 36
        '
        'company
        '
        Me.company.DataPropertyName = "COMPAÑIA"
        Me.company.HeaderText = "Compañia"
        Me.company.Name = "company"
        Me.company.ReadOnly = True
        Me.company.Visible = False
        '
        'codempl
        '
        Me.codempl.DataPropertyName = "CODIGO_EMPLEADO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codempl.DefaultCellStyle = DataGridViewCellStyle3
        Me.codempl.HeaderText = "Codigo Buxis"
        Me.codempl.Name = "codempl"
        Me.codempl.ReadOnly = True
        Me.codempl.Width = 60
        '
        'codfiad
        '
        Me.codfiad.DataPropertyName = "CODIGO_EMPLEADO_FIADOR"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codfiad.DefaultCellStyle = DataGridViewCellStyle4
        Me.codfiad.HeaderText = "Codigo Empleado"
        Me.codfiad.Name = "codfiad"
        Me.codfiad.ReadOnly = True
        Me.codfiad.Width = 60
        '
        'nombrecomp
        '
        Me.nombrecomp.DataPropertyName = "NOMBRE_COMPLETO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.nombrecomp.DefaultCellStyle = DataGridViewCellStyle5
        Me.nombrecomp.HeaderText = "Nombre"
        Me.nombrecomp.Name = "nombrecomp"
        Me.nombrecomp.ReadOnly = True
        Me.nombrecomp.Width = 210
        '
        'numsol
        '
        Me.numsol.DataPropertyName = "NUMERO_SOLICITUD"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numsol.DefaultCellStyle = DataGridViewCellStyle6
        Me.numsol.HeaderText = "#Solicit."
        Me.numsol.Name = "numsol"
        Me.numsol.ReadOnly = True
        Me.numsol.Width = 60
        '
        'descsol
        '
        Me.descsol.DataPropertyName = "DESCRIPCION_SOLICITUD"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.descsol.DefaultCellStyle = DataGridViewCellStyle7
        Me.descsol.HeaderText = "Concepto"
        Me.descsol.Name = "descsol"
        Me.descsol.ReadOnly = True
        Me.descsol.Width = 180
        '
        'sdoact
        '
        Me.sdoact.DataPropertyName = "SALDO_ACTUAL"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.sdoact.DefaultCellStyle = DataGridViewCellStyle8
        Me.sdoact.HeaderText = "Saldo Actual"
        Me.sdoact.Name = "sdoact"
        Me.sdoact.ReadOnly = True
        Me.sdoact.Width = 70
        '
        'totdeu
        '
        Me.totdeu.DataPropertyName = "TOTAL_DEUDAS"
        Me.totdeu.HeaderText = "Total Deudas"
        Me.totdeu.Name = "totdeu"
        Me.totdeu.ReadOnly = True
        Me.totdeu.Visible = False
        '
        'frm_hojadatos_fiadordesocios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 266)
        Me.Controls.Add(Me.DataGrid01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frm_hojadatos_fiadordesocios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Hoja datos fiador de socios"
        CType(Me.DataGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codempl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codfiad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombrecomp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numsol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descsol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sdoact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totdeu As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
