<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Balances_Saldos_Mes_Rpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Balances_Saldos_Mes_Rpt))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Label = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkValoresCero = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbNivelCta = New System.Windows.Forms.ComboBox
        Me.TxtCompañia = New System.Windows.Forms.TextBox
        Me.cmbLIBRO_CONTABLE2 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(649, 57)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(177, 231)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 107
        Me.pbImagen.TabStop = False
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.Transparent
        Me.Label.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Location = New System.Drawing.Point(190, 329)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(409, 23)
        Me.Label.TabIndex = 106
        Me.Label.Text = "ESPERE MIENTRAS SE GENERA INFORME"
        Me.Label.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkValoresCero)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbNivelCta)
        Me.GroupBox1.Controls.Add(Me.TxtCompañia)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(24, 48)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(610, 217)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Balance"
        '
        'chkValoresCero
        '
        Me.chkValoresCero.AutoSize = True
        Me.chkValoresCero.Checked = True
        Me.chkValoresCero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValoresCero.Location = New System.Drawing.Point(146, 175)
        Me.chkValoresCero.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.chkValoresCero.Name = "chkValoresCero"
        Me.chkValoresCero.Size = New System.Drawing.Size(139, 20)
        Me.chkValoresCero.TabIndex = 68
        Me.chkValoresCero.Text = "Excluir valores a cero"
        Me.chkValoresCero.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(340, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "A Nivel de :"
        '
        'cmbNivelCta
        '
        Me.cmbNivelCta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelCta.FormattingEnabled = True
        Me.cmbNivelCta.Location = New System.Drawing.Point(409, 137)
        Me.cmbNivelCta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbNivelCta.Name = "cmbNivelCta"
        Me.cmbNivelCta.Size = New System.Drawing.Size(121, 24)
        Me.cmbNivelCta.TabIndex = 66
        '
        'TxtCompañia
        '
        Me.TxtCompañia.Enabled = False
        Me.TxtCompañia.Location = New System.Drawing.Point(146, 30)
        Me.TxtCompañia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCompañia.Name = "TxtCompañia"
        Me.TxtCompañia.ReadOnly = True
        Me.TxtCompañia.Size = New System.Drawing.Size(384, 22)
        Me.TxtCompañia.TabIndex = 64
        '
        'cmbLIBRO_CONTABLE2
        '
        Me.cmbLIBRO_CONTABLE2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE2.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE2.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE2.Location = New System.Drawing.Point(146, 94)
        Me.cmbLIBRO_CONTABLE2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLIBRO_CONTABLE2.Name = "cmbLIBRO_CONTABLE2"
        Me.cmbLIBRO_CONTABLE2.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE2.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(8, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "A Este Libro Contable :"
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.Location = New System.Drawing.Point(535, 39)
        Me.btnVerBC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(64, 74)
        Me.btnVerBC.TabIndex = 60
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(146, 139)
        Me.dpFECHA_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(8, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha Contable :"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(146, 62)
        Me.cmbLIBRO_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libro Contable :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'Contabilidad_Reportes_Balances_Saldos_Mes_Rpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 405)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Balances_Saldos_Mes_Rpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Balance de Saldo del Mes"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbLIBRO_CONTABLE2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbNivelCta As System.Windows.Forms.ComboBox
    Friend WithEvents chkValoresCero As System.Windows.Forms.CheckBox
End Class
