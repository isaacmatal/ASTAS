<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperativa_Reportes_Socios_x_Division
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cooperativa_Reportes_Socios_x_Division))
        Me.Label = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbDivision = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ChkFirma = New System.Windows.Forms.CheckBox
        Me.ChkSocios = New System.Windows.Forms.CheckBox
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.TxtCompañia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Location = New System.Drawing.Point(190, 267)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(409, 23)
        Me.Label.TabIndex = 118
        Me.Label.Text = "ESPERE MIENTRAS SE GENERA INFORME"
        Me.Label.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbDivision)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ChkSocios)
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(24, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 176)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'CmbDivision
        '
        Me.CmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDivision.FormattingEnabled = True
        Me.CmbDivision.Location = New System.Drawing.Point(124, 38)
        Me.CmbDivision.Name = "CmbDivision"
        Me.CmbDivision.Size = New System.Drawing.Size(364, 24)
        Me.CmbDivision.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "División:"
        '
        'ChkFirma
        '
        Me.ChkFirma.AutoSize = True
        Me.ChkFirma.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFirma.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFirma.Location = New System.Drawing.Point(35, 237)
        Me.ChkFirma.Name = "ChkFirma"
        Me.ChkFirma.Size = New System.Drawing.Size(131, 20)
        Me.ChkFirma.TabIndex = 1
        Me.ChkFirma.Text = "Solicitar Firmas:          "
        Me.ChkFirma.UseVisualStyleBackColor = True
        Me.ChkFirma.Visible = False
        '
        'ChkSocios
        '
        Me.ChkSocios.AutoSize = True
        Me.ChkSocios.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSocios.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSocios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSocios.Location = New System.Drawing.Point(8, 69)
        Me.ChkSocios.Name = "ChkSocios"
        Me.ChkSocios.Size = New System.Drawing.Size(130, 20)
        Me.ChkSocios.TabIndex = 0
        Me.ChkSocios.Text = "Reportar Solo Socios:"
        Me.ChkSocios.UseVisualStyleBackColor = True
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.Location = New System.Drawing.Point(518, 32)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(60, 60)
        Me.btnVerBC.TabIndex = 3
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(124, 96)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha:"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(649, 46)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 169)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 119
        Me.pbImagen.TabStop = False
        '
        'TxtCompañia
        '
        Me.TxtCompañia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCompañia.Location = New System.Drawing.Point(139, 15)
        Me.TxtCompañia.Name = "TxtCompañia"
        Me.TxtCompañia.ReadOnly = True
        Me.TxtCompañia.Size = New System.Drawing.Size(492, 13)
        Me.TxtCompañia.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Compañía :"
        '
        'Cooperativa_Reportes_Socios_x_Division
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 329)
        Me.Controls.Add(Me.TxtCompañia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkFirma)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cooperativa_Reportes_Socios_x_Division"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa_Reportes_Socios_x_Division"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkFirma As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSocios As System.Windows.Forms.CheckBox
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
