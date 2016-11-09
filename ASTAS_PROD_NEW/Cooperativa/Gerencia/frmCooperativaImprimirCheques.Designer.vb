<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCooperativaImprimirCheques
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbBancos = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCuentaBancaria = New System.Windows.Forms.ComboBox
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.chkNoNeg = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 82)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(858, 389)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Banco:"
        '
        'cmbBancos
        '
        Me.cmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancos.FormattingEnabled = True
        Me.cmbBancos.Location = New System.Drawing.Point(52, 9)
        Me.cmbBancos.Name = "cmbBancos"
        Me.cmbBancos.Size = New System.Drawing.Size(241, 21)
        Me.cmbBancos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(310, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cuenta Bancaria:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "No. Cheque:"
        '
        'cmbCuentaBancaria
        '
        Me.cmbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBancaria.FormattingEnabled = True
        Me.cmbCuentaBancaria.Location = New System.Drawing.Point(406, 12)
        Me.cmbCuentaBancaria.Name = "cmbCuentaBancaria"
        Me.cmbCuentaBancaria.Size = New System.Drawing.Size(233, 21)
        Me.cmbCuentaBancaria.TabIndex = 6
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(78, 46)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(100, 20)
        Me.txtCheque.TabIndex = 7
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(196, 43)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 8
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'chkNoNeg
        '
        Me.chkNoNeg.AutoSize = True
        Me.chkNoNeg.BackColor = System.Drawing.Color.Transparent
        Me.chkNoNeg.Checked = True
        Me.chkNoNeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoNeg.Location = New System.Drawing.Point(278, 47)
        Me.chkNoNeg.Name = "chkNoNeg"
        Me.chkNoNeg.Size = New System.Drawing.Size(97, 17)
        Me.chkNoNeg.TabIndex = 9
        Me.chkNoNeg.Text = "No Negociable"
        Me.chkNoNeg.UseVisualStyleBackColor = False
        '
        'frmCooperativaImprimirCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 471)
        Me.Controls.Add(Me.chkNoNeg)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.cmbCuentaBancaria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbBancos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmCooperativaImprimirCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Imprimir Cheques"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents chkNoNeg As System.Windows.Forms.CheckBox
End Class
