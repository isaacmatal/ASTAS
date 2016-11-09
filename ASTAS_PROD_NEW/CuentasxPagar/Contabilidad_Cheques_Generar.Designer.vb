<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Cheques_Generar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Cheques_Generar))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblBodega = New System.Windows.Forms.Label
        Me.txtNumChq = New System.Windows.Forms.TextBox
        Me.lblNOMBRE_PROVEEDOR = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblTotalCheque = New System.Windows.Forms.Label
        Me.lblCUENTA_COMPLETA = New System.Windows.Forms.Label
        Me.dpFECHA_CH = New System.Windows.Forms.DateTimePicker
        Me.cmbBANCO = New System.Windows.Forms.ComboBox
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblCUENTA = New System.Windows.Forms.Label
        Me.lblFACTURA = New System.Windows.Forms.Label
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.lblOC = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblBodega)
        Me.GroupBox1.Controls.Add(Me.txtNumChq)
        Me.GroupBox1.Controls.Add(Me.lblNOMBRE_PROVEEDOR)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTotalCheque)
        Me.GroupBox1.Controls.Add(Me.lblCUENTA_COMPLETA)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CH)
        Me.GroupBox1.Controls.Add(Me.cmbBANCO)
        Me.GroupBox1.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblCUENTA)
        Me.GroupBox1.Controls.Add(Me.lblFACTURA)
        Me.GroupBox1.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.GroupBox1.Controls.Add(Me.lblOC)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(477, 231)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cheque "
        '
        'lblBodega
        '
        Me.lblBodega.AutoSize = True
        Me.lblBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBodega.Location = New System.Drawing.Point(156, 27)
        Me.lblBodega.Name = "lblBodega"
        Me.lblBodega.Size = New System.Drawing.Size(14, 16)
        Me.lblBodega.TabIndex = 119
        Me.lblBodega.Text = "0"
        Me.lblBodega.Visible = False
        '
        'txtNumChq
        '
        Me.txtNumChq.Location = New System.Drawing.Point(82, 182)
        Me.txtNumChq.Name = "txtNumChq"
        Me.txtNumChq.Size = New System.Drawing.Size(90, 22)
        Me.txtNumChq.TabIndex = 118
        '
        'lblNOMBRE_PROVEEDOR
        '
        Me.lblNOMBRE_PROVEEDOR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNOMBRE_PROVEEDOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNOMBRE_PROVEEDOR.ForeColor = System.Drawing.Color.Navy
        Me.lblNOMBRE_PROVEEDOR.Location = New System.Drawing.Point(82, 56)
        Me.lblNOMBRE_PROVEEDOR.Name = "lblNOMBRE_PROVEEDOR"
        Me.lblNOMBRE_PROVEEDOR.ReadOnly = True
        Me.lblNOMBRE_PROVEEDOR.Size = New System.Drawing.Size(382, 22)
        Me.lblNOMBRE_PROVEEDOR.TabIndex = 118
        Me.lblNOMBRE_PROVEEDOR.Text = "999"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(12, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Cheque:"
        '
        'lblTotalCheque
        '
        Me.lblTotalCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotalCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCheque.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheque.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalCheque.Location = New System.Drawing.Point(82, 87)
        Me.lblTotalCheque.Name = "lblTotalCheque"
        Me.lblTotalCheque.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalCheque.TabIndex = 117
        Me.lblTotalCheque.Text = "0.00"
        Me.lblTotalCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(368, 182)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(96, 22)
        Me.lblCUENTA_COMPLETA.TabIndex = 2
        Me.lblCUENTA_COMPLETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCUENTA_COMPLETA.Visible = False
        '
        'dpFECHA_CH
        '
        Me.dpFECHA_CH.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CH.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CH.Location = New System.Drawing.Point(352, 86)
        Me.dpFECHA_CH.Name = "dpFECHA_CH"
        Me.dpFECHA_CH.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CH.TabIndex = 44
        '
        'cmbBANCO
        '
        Me.cmbBANCO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBANCO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBANCO.ForeColor = System.Drawing.Color.Navy
        Me.cmbBANCO.FormattingEnabled = True
        Me.cmbBANCO.Location = New System.Drawing.Point(82, 116)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(382, 24)
        Me.cmbBANCO.TabIndex = 108
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(196, 188)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 114
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(263, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Fecha Cheque :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 152)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Cta.Banco :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Total Pagado:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Banco :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Proveedor"
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(225, 188)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 113
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'lblFACTURA
        '
        Me.lblFACTURA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFACTURA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFACTURA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblFACTURA.ForeColor = System.Drawing.Color.Navy
        Me.lblFACTURA.Location = New System.Drawing.Point(347, 24)
        Me.lblFACTURA.Name = "lblFACTURA"
        Me.lblFACTURA.Size = New System.Drawing.Size(117, 22)
        Me.lblFACTURA.TabIndex = 2
        Me.lblFACTURA.Text = "999"
        Me.lblFACTURA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(82, 149)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(382, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 107
        '
        'lblOC
        '
        Me.lblOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOC.ForeColor = System.Drawing.Color.Red
        Me.lblOC.Location = New System.Drawing.Point(82, 24)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(66, 22)
        Me.lblOC.TabIndex = 2
        Me.lblOC.Text = "999"
        Me.lblOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(270, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Cuenta Completa:"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(266, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Comprobante:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° OC :"
        '
        'btnGenerar
        '
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(207, 257)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 24)
        Me.btnGenerar.TabIndex = 105
        Me.btnGenerar.Text = "&Guardar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Contabilidad_Cheques_Generar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Contabilidad_Cheques_Generar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos del Pago de Contado"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheque As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA_COMPLETA As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumChq As System.Windows.Forms.TextBox
    Friend WithEvents lblNOMBRE_PROVEEDOR As System.Windows.Forms.TextBox
    Friend WithEvents dpFECHA_CH As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFACTURA As System.Windows.Forms.Label
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBodega As System.Windows.Forms.Label
End Class
