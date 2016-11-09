<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Ingreso_Comp_Retencion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Facturacion_Ingreso_Comp_Retencion))
        Me.txtNoFact = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtNomFact = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotFact = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.lblSubtotal = New System.Windows.Forms.Label
        Me.lblRetencion = New System.Windows.Forms.Label
        Me.txtSUBTOTAL = New System.Windows.Forms.TextBox
        Me.txtRetencion = New System.Windows.Forms.TextBox
        Me.lblIVA = New System.Windows.Forms.Label
        Me.lblTotalFactura = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumComp = New System.Windows.Forms.TextBox
        Me.btnGuardaFacturaEncabezado = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtNoFact
        '
        Me.txtNoFact.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoFact.ForeColor = System.Drawing.Color.Black
        Me.txtNoFact.Location = New System.Drawing.Point(97, 9)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.ReadOnly = True
        Me.txtNoFact.Size = New System.Drawing.Size(71, 26)
        Me.txtNoFact.TabIndex = 70
        Me.txtNoFact.Text = "0"
        Me.txtNoFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(8, 15)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(74, 20)
        Me.Label52.TabIndex = 69
        Me.Label52.Text = "N° C.C.F. :"
        '
        'txtNomFact
        '
        Me.txtNomFact.BackColor = System.Drawing.SystemColors.Window
        Me.txtNomFact.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomFact.ForeColor = System.Drawing.Color.Navy
        Me.txtNomFact.Location = New System.Drawing.Point(97, 48)
        Me.txtNomFact.Name = "txtNomFact"
        Me.txtNomFact.ReadOnly = True
        Me.txtNomFact.Size = New System.Drawing.Size(299, 22)
        Me.txtNomFact.TabIndex = 71
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 14)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "Nombre Factura :"
        '
        'txtTotFact
        '
        Me.txtTotFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotFact.Location = New System.Drawing.Point(202, 106)
        Me.txtTotFact.Name = "txtTotFact"
        Me.txtTotFact.ReadOnly = True
        Me.txtTotFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotFact.Size = New System.Drawing.Size(96, 26)
        Me.txtTotFact.TabIndex = 116
        Me.txtTotFact.Text = "0.00"
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(104, 106)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIVA.Size = New System.Drawing.Size(96, 26)
        Me.txtIVA.TabIndex = 115
        Me.txtIVA.Text = "0.00"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.Color.Teal
        Me.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubtotal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.Yellow
        Me.lblSubtotal.Location = New System.Drawing.Point(6, 84)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(96, 20)
        Me.lblSubtotal.TabIndex = 119
        Me.lblSubtotal.Text = "Subtotal"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRetencion
        '
        Me.lblRetencion.BackColor = System.Drawing.Color.Teal
        Me.lblRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRetencion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetencion.ForeColor = System.Drawing.Color.Yellow
        Me.lblRetencion.Location = New System.Drawing.Point(300, 84)
        Me.lblRetencion.Name = "lblRetencion"
        Me.lblRetencion.Size = New System.Drawing.Size(96, 20)
        Me.lblRetencion.TabIndex = 117
        Me.lblRetencion.Text = "Retencion:"
        '
        'txtSUBTOTAL
        '
        Me.txtSUBTOTAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSUBTOTAL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBTOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtSUBTOTAL.Location = New System.Drawing.Point(6, 106)
        Me.txtSUBTOTAL.Name = "txtSUBTOTAL"
        Me.txtSUBTOTAL.ReadOnly = True
        Me.txtSUBTOTAL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSUBTOTAL.Size = New System.Drawing.Size(96, 26)
        Me.txtSUBTOTAL.TabIndex = 114
        Me.txtSUBTOTAL.Text = "0.00"
        '
        'txtRetencion
        '
        Me.txtRetencion.BackColor = System.Drawing.Color.White
        Me.txtRetencion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetencion.ForeColor = System.Drawing.Color.Navy
        Me.txtRetencion.Location = New System.Drawing.Point(300, 106)
        Me.txtRetencion.Name = "txtRetencion"
        Me.txtRetencion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRetencion.Size = New System.Drawing.Size(96, 26)
        Me.txtRetencion.TabIndex = 1
        Me.txtRetencion.Text = "0.00"
        '
        'lblIVA
        '
        Me.lblIVA.BackColor = System.Drawing.Color.Teal
        Me.lblIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIVA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA.ForeColor = System.Drawing.Color.Yellow
        Me.lblIVA.Location = New System.Drawing.Point(104, 84)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(96, 20)
        Me.lblIVA.TabIndex = 120
        Me.lblIVA.Text = "IVA"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalFactura
        '
        Me.lblTotalFactura.BackColor = System.Drawing.Color.Teal
        Me.lblTotalFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalFactura.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFactura.ForeColor = System.Drawing.Color.Yellow
        Me.lblTotalFactura.Location = New System.Drawing.Point(202, 84)
        Me.lblTotalFactura.Name = "lblTotalFactura"
        Me.lblTotalFactura.Size = New System.Drawing.Size(96, 20)
        Me.lblTotalFactura.TabIndex = 121
        Me.lblTotalFactura.Text = "Total Factura"
        Me.lblTotalFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(175, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Comprobante N°:"
        '
        'txtNumComp
        '
        Me.txtNumComp.BackColor = System.Drawing.Color.Yellow
        Me.txtNumComp.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumComp.ForeColor = System.Drawing.Color.Red
        Me.txtNumComp.Location = New System.Drawing.Point(291, 9)
        Me.txtNumComp.Name = "txtNumComp"
        Me.txtNumComp.Size = New System.Drawing.Size(71, 26)
        Me.txtNumComp.TabIndex = 0
        Me.txtNumComp.Text = "0"
        Me.txtNumComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGuardaFacturaEncabezado
        '
        Me.btnGuardaFacturaEncabezado.Image = CType(resources.GetObject("btnGuardaFacturaEncabezado.Image"), System.Drawing.Image)
        Me.btnGuardaFacturaEncabezado.Location = New System.Drawing.Point(368, 9)
        Me.btnGuardaFacturaEncabezado.Name = "btnGuardaFacturaEncabezado"
        Me.btnGuardaFacturaEncabezado.Size = New System.Drawing.Size(25, 25)
        Me.btnGuardaFacturaEncabezado.TabIndex = 2
        Me.btnGuardaFacturaEncabezado.UseVisualStyleBackColor = True
        '
        'Facturacion_Ingreso_Comp_Retencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 143)
        Me.Controls.Add(Me.btnGuardaFacturaEncabezado)
        Me.Controls.Add(Me.txtNumComp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotFact)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.lblSubtotal)
        Me.Controls.Add(Me.lblRetencion)
        Me.Controls.Add(Me.txtSUBTOTAL)
        Me.Controls.Add(Me.txtRetencion)
        Me.Controls.Add(Me.lblIVA)
        Me.Controls.Add(Me.lblTotalFactura)
        Me.Controls.Add(Me.txtNomFact)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNoFact)
        Me.Controls.Add(Me.Label52)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Facturacion_Ingreso_Comp_Retencion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Comprobante Retencion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtNomFact As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotFact As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblRetencion As System.Windows.Forms.Label
    Friend WithEvents txtSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents txtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents lblTotalFactura As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumComp As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardaFacturaEncabezado As System.Windows.Forms.Button
End Class
