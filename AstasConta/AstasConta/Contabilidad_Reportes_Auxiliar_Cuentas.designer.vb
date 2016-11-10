<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Auxiliar_Cuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Auxiliar_Cuentas))
        Me.Label = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCONCEPTO_F = New System.Windows.Forms.TextBox
        Me.txtCUENTA_F = New System.Windows.Forms.TextBox
        Me.txtCONCEPTO_I = New System.Windows.Forms.TextBox
        Me.txtCUENTA_I = New System.Windows.Forms.TextBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.dpFecha_F = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dpFecha_I = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.btnBuscarCuenta2 = New System.Windows.Forms.Button
        Me.btnBuscarCuenta1 = New System.Windows.Forms.Button
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.Transparent
        Me.Label.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Location = New System.Drawing.Point(190, 267)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(409, 23)
        Me.Label.TabIndex = 109
        Me.Label.Text = "ESPERE MIENTRAS SE GENERA INFORME"
        Me.Label.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnBuscarCuenta2)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCuenta1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO_F)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_F)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO_I)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_I)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.dpFecha_F)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.dpFecha_I)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(24, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 229)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(11, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Cuenta Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Cuenta Inicial:"
        '
        'txtCONCEPTO_F
        '
        Me.txtCONCEPTO_F.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO_F.Enabled = False
        Me.txtCONCEPTO_F.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO_F.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO_F.Location = New System.Drawing.Point(217, 128)
        Me.txtCONCEPTO_F.MaxLength = 100
        Me.txtCONCEPTO_F.Name = "txtCONCEPTO_F"
        Me.txtCONCEPTO_F.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_F.Size = New System.Drawing.Size(382, 22)
        Me.txtCONCEPTO_F.TabIndex = 66
        '
        'txtCUENTA_F
        '
        Me.txtCUENTA_F.BackColor = System.Drawing.Color.White
        Me.txtCUENTA_F.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_F.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_F.Location = New System.Drawing.Point(97, 128)
        Me.txtCUENTA_F.Name = "txtCUENTA_F"
        Me.txtCUENTA_F.Size = New System.Drawing.Size(96, 22)
        Me.txtCUENTA_F.TabIndex = 2
        '
        'txtCONCEPTO_I
        '
        Me.txtCONCEPTO_I.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO_I.Enabled = False
        Me.txtCONCEPTO_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO_I.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO_I.Location = New System.Drawing.Point(217, 96)
        Me.txtCONCEPTO_I.MaxLength = 100
        Me.txtCONCEPTO_I.Name = "txtCONCEPTO_I"
        Me.txtCONCEPTO_I.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_I.Size = New System.Drawing.Size(382, 22)
        Me.txtCONCEPTO_I.TabIndex = 64
        '
        'txtCUENTA_I
        '
        Me.txtCUENTA_I.BackColor = System.Drawing.Color.White
        Me.txtCUENTA_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_I.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_I.Location = New System.Drawing.Point(97, 97)
        Me.txtCUENTA_I.Name = "txtCUENTA_I"
        Me.txtCUENTA_I.Size = New System.Drawing.Size(96, 22)
        Me.txtCUENTA_I.TabIndex = 1
        '
        'txtCompañia
        '
        Me.txtCompañia.AcceptsReturn = True
        Me.txtCompañia.Location = New System.Drawing.Point(97, 33)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.Size = New System.Drawing.Size(406, 22)
        Me.txtCompañia.TabIndex = 63
        '
        'dpFecha_F
        '
        Me.dpFecha_F.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_F.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_F.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha_F.Location = New System.Drawing.Point(97, 196)
        Me.dpFecha_F.Name = "dpFecha_F"
        Me.dpFecha_F.Size = New System.Drawing.Size(100, 22)
        Me.dpFecha_F.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(8, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Fecha Final:"
        '
        'dpFecha_I
        '
        Me.dpFecha_I.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_I.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha_I.Location = New System.Drawing.Point(97, 168)
        Me.dpFecha_I.Name = "dpFecha_I"
        Me.dpFecha_I.Size = New System.Drawing.Size(100, 22)
        Me.dpFecha_I.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(8, 169)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha Inicial:"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(97, 62)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(406, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 63)
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
        Me.Label1.Location = New System.Drawing.Point(8, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(649, 44)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 218)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 110
        Me.pbImagen.TabStop = False
        '
        'btnBuscarCuenta2
        '
        Me.btnBuscarCuenta2.Image = CType(resources.GetObject("btnBuscarCuenta2.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta2.Location = New System.Drawing.Point(192, 126)
        Me.btnBuscarCuenta2.Name = "btnBuscarCuenta2"
        Me.btnBuscarCuenta2.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCuenta2.TabIndex = 112
        Me.btnBuscarCuenta2.UseVisualStyleBackColor = True
        '
        'btnBuscarCuenta1
        '
        Me.btnBuscarCuenta1.Image = CType(resources.GetObject("btnBuscarCuenta1.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta1.Location = New System.Drawing.Point(192, 94)
        Me.btnBuscarCuenta1.Name = "btnBuscarCuenta1"
        Me.btnBuscarCuenta1.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCuenta1.TabIndex = 111
        Me.btnBuscarCuenta1.UseVisualStyleBackColor = True
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVerBC.Location = New System.Drawing.Point(519, 33)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(74, 46)
        Me.btnVerBC.TabIndex = 5
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'Contabilidad_Reportes_Auxiliar_Cuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 329)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Contabilidad_Reportes_Auxiliar_Cuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auxiliar de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFecha_F As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFecha_I As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents txtCONCEPTO_I As System.Windows.Forms.TextBox
    Friend WithEvents txtCUENTA_I As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCONCEPTO_F As System.Windows.Forms.TextBox
    Friend WithEvents txtCUENTA_F As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuenta1 As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCuenta2 As System.Windows.Forms.Button
End Class
