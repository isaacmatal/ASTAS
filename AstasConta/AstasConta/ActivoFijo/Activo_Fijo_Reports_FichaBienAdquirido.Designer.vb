<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Reports_FichaBienAdquirido
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
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radFiscal = New System.Windows.Forms.RadioButton
        Me.radFinanciero = New System.Windows.Forms.RadioButton
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radCatAmbos = New System.Windows.Forms.RadioButton
        Me.radNoDepreciable = New System.Windows.Forms.RadioButton
        Me.radDepreciable = New System.Windows.Forms.RadioButton
        Me.chkDeBaja = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(688, 14)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 29)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(14, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Hasta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radFiscal)
        Me.GroupBox1.Controls.Add(Me.radFinanciero)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(218, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 48)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Reporte"
        '
        'radFiscal
        '
        Me.radFiscal.AutoSize = True
        Me.radFiscal.BackColor = System.Drawing.Color.Transparent
        Me.radFiscal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radFiscal.ForeColor = System.Drawing.Color.Navy
        Me.radFiscal.Location = New System.Drawing.Point(100, 19)
        Me.radFiscal.Name = "radFiscal"
        Me.radFiscal.Size = New System.Drawing.Size(63, 20)
        Me.radFiscal.TabIndex = 6
        Me.radFiscal.Text = "Fiscal"
        Me.radFiscal.UseVisualStyleBackColor = False
        '
        'radFinanciero
        '
        Me.radFinanciero.AutoSize = True
        Me.radFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.radFinanciero.Checked = True
        Me.radFinanciero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radFinanciero.ForeColor = System.Drawing.Color.Navy
        Me.radFinanciero.Location = New System.Drawing.Point(8, 19)
        Me.radFinanciero.Name = "radFinanciero"
        Me.radFinanciero.Size = New System.Drawing.Size(94, 20)
        Me.radFinanciero.TabIndex = 5
        Me.radFinanciero.TabStop = True
        Me.radFinanciero.Text = "Financiero"
        Me.radFinanciero.UseVisualStyleBackColor = False
        '
        'dtpHasta
        '
        Me.dtpHasta.Location = New System.Drawing.Point(12, 31)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(200, 20)
        Me.dtpHasta.TabIndex = 10
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 102)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(868, 292)
        Me.CrystalReportViewer1.TabIndex = 9
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radCatAmbos)
        Me.GroupBox2.Controls.Add(Me.radNoDepreciable)
        Me.GroupBox2.Controls.Add(Me.radDepreciable)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(385, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 48)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Categoría"
        '
        'radCatAmbos
        '
        Me.radCatAmbos.AutoSize = True
        Me.radCatAmbos.BackColor = System.Drawing.Color.Transparent
        Me.radCatAmbos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radCatAmbos.ForeColor = System.Drawing.Color.Navy
        Me.radCatAmbos.Location = New System.Drawing.Point(227, 19)
        Me.radCatAmbos.Name = "radCatAmbos"
        Me.radCatAmbos.Size = New System.Drawing.Size(69, 20)
        Me.radCatAmbos.TabIndex = 8
        Me.radCatAmbos.Text = "Ambos"
        Me.radCatAmbos.UseVisualStyleBackColor = False
        '
        'radNoDepreciable
        '
        Me.radNoDepreciable.AutoSize = True
        Me.radNoDepreciable.BackColor = System.Drawing.Color.Transparent
        Me.radNoDepreciable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radNoDepreciable.ForeColor = System.Drawing.Color.Navy
        Me.radNoDepreciable.Location = New System.Drawing.Point(108, 19)
        Me.radNoDepreciable.Name = "radNoDepreciable"
        Me.radNoDepreciable.Size = New System.Drawing.Size(124, 20)
        Me.radNoDepreciable.TabIndex = 6
        Me.radNoDepreciable.Text = "No Depreciable"
        Me.radNoDepreciable.UseVisualStyleBackColor = False
        '
        'radDepreciable
        '
        Me.radDepreciable.AutoSize = True
        Me.radDepreciable.BackColor = System.Drawing.Color.Transparent
        Me.radDepreciable.Checked = True
        Me.radDepreciable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radDepreciable.ForeColor = System.Drawing.Color.Navy
        Me.radDepreciable.Location = New System.Drawing.Point(8, 19)
        Me.radDepreciable.Name = "radDepreciable"
        Me.radDepreciable.Size = New System.Drawing.Size(103, 20)
        Me.radDepreciable.TabIndex = 5
        Me.radDepreciable.TabStop = True
        Me.radDepreciable.Text = "Depreciable"
        Me.radDepreciable.UseVisualStyleBackColor = False
        '
        'chkDeBaja
        '
        Me.chkDeBaja.AutoSize = True
        Me.chkDeBaja.BackColor = System.Drawing.Color.Transparent
        Me.chkDeBaja.Location = New System.Drawing.Point(388, 73)
        Me.chkDeBaja.Name = "chkDeBaja"
        Me.chkDeBaja.Size = New System.Drawing.Size(64, 17)
        Me.chkDeBaja.TabIndex = 17
        Me.chkDeBaja.Text = "De Baja"
        Me.chkDeBaja.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(14, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(12, 71)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(200, 21)
        Me.cmbTipo.TabIndex = 19
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(218, 72)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(161, 20)
        Me.txtCodigo.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(218, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Código del Bien"
        '
        'Activo_Fijo_Reports_FichaBienAdquirido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 406)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.chkDeBaja)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Activo_Fijo_Reports_FichaBienAdquirido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activo Fijo - Ficha Bien Adquirido"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radFiscal As System.Windows.Forms.RadioButton
    Friend WithEvents radFinanciero As System.Windows.Forms.RadioButton
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radNoDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents radDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents chkDeBaja As System.Windows.Forms.CheckBox
    Friend WithEvents radCatAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
