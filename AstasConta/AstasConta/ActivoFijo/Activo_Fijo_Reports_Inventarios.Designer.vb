<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Reports_Inventarios
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
        Me.chkDeBaja = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radCatAmbos = New System.Windows.Forms.RadioButton
        Me.radNoDepreciable = New System.Windows.Forms.RadioButton
        Me.radDepreciable = New System.Windows.Forms.RadioButton
        Me.btnPrint = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkDeBaja
        '
        Me.chkDeBaja.AutoSize = True
        Me.chkDeBaja.BackColor = System.Drawing.Color.Transparent
        Me.chkDeBaja.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkDeBaja.ForeColor = System.Drawing.Color.Navy
        Me.chkDeBaja.Location = New System.Drawing.Point(589, 31)
        Me.chkDeBaja.Name = "chkDeBaja"
        Me.chkDeBaja.Size = New System.Drawing.Size(77, 20)
        Me.chkDeBaja.TabIndex = 23
        Me.chkDeBaja.Text = "De Baja"
        Me.chkDeBaja.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radCatAmbos)
        Me.GroupBox2.Controls.Add(Me.radNoDepreciable)
        Me.GroupBox2.Controls.Add(Me.radDepreciable)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(274, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 48)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Categoría"
        '
        'radCatAmbos
        '
        Me.radCatAmbos.AutoSize = True
        Me.radCatAmbos.BackColor = System.Drawing.Color.Transparent
        Me.radCatAmbos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radCatAmbos.ForeColor = System.Drawing.Color.Navy
        Me.radCatAmbos.Location = New System.Drawing.Point(233, 19)
        Me.radCatAmbos.Name = "radCatAmbos"
        Me.radCatAmbos.Size = New System.Drawing.Size(69, 20)
        Me.radCatAmbos.TabIndex = 9
        Me.radCatAmbos.Text = "Ambos"
        Me.radCatAmbos.UseVisualStyleBackColor = False
        '
        'radNoDepreciable
        '
        Me.radNoDepreciable.AutoSize = True
        Me.radNoDepreciable.BackColor = System.Drawing.Color.Transparent
        Me.radNoDepreciable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radNoDepreciable.ForeColor = System.Drawing.Color.Navy
        Me.radNoDepreciable.Location = New System.Drawing.Point(107, 19)
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
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(663, 23)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 34)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 66)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(868, 328)
        Me.CrystalReportViewer1.TabIndex = 17
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Location = New System.Drawing.Point(12, 26)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(258, 21)
        Me.cmbUbicacion.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Ubicación"
        '
        'Activo_Fijo_Reports_Inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 406)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbUbicacion)
        Me.Controls.Add(Me.chkDeBaja)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Activo_Fijo_Reports_Inventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activo Fijo - Reportes"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDeBaja As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radCatAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents radNoDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents radDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
