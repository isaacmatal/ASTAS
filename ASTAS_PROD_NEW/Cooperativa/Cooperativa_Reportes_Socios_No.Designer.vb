<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperativa_Reportes_Socios_No
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cooperativa_Reportes_Socios_No))
        Me.Label = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chktseccion = New System.Windows.Forms.CheckBox
        Me.chktdepto = New System.Windows.Forms.CheckBox
        Me.chktdivision = New System.Windows.Forms.CheckBox
        Me.chktempresa = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbdivision = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbseccion = New System.Windows.Forms.ComboBox
        Me.cmbdepto = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbempresa = New System.Windows.Forms.ComboBox
        Me.ChkFirma = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chknosocios = New System.Windows.Forms.CheckBox
        Me.ChkSocios = New System.Windows.Forms.CheckBox
        Me.TxtCompañia = New System.Windows.Forms.TextBox
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Location = New System.Drawing.Point(190, 311)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(409, 23)
        Me.Label.TabIndex = 115
        Me.Label.Text = "ESPERE MIENTRAS SE GENERA INFORME"
        Me.Label.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.ChkFirma)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TxtCompañia)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(24, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 250)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chktseccion)
        Me.GroupBox3.Controls.Add(Me.chktdepto)
        Me.GroupBox3.Controls.Add(Me.chktdivision)
        Me.GroupBox3.Controls.Add(Me.chktempresa)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cmbdivision)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmbseccion)
        Me.GroupBox3.Controls.Add(Me.cmbdepto)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbempresa)
        Me.GroupBox3.Location = New System.Drawing.Point(141, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(434, 140)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtros"
        '
        'chktseccion
        '
        Me.chktseccion.AutoSize = True
        Me.chktseccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktseccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktseccion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktseccion.Location = New System.Drawing.Point(344, 109)
        Me.chktseccion.Name = "chktseccion"
        Me.chktseccion.Size = New System.Drawing.Size(57, 20)
        Me.chktseccion.TabIndex = 120
        Me.chktseccion.Text = "Todas"
        Me.chktseccion.UseVisualStyleBackColor = True
        '
        'chktdepto
        '
        Me.chktdepto.AutoSize = True
        Me.chktdepto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktdepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktdepto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktdepto.Location = New System.Drawing.Point(344, 78)
        Me.chktdepto.Name = "chktdepto"
        Me.chktdepto.Size = New System.Drawing.Size(57, 20)
        Me.chktdepto.TabIndex = 119
        Me.chktdepto.Text = "Todos"
        Me.chktdepto.UseVisualStyleBackColor = True
        '
        'chktdivision
        '
        Me.chktdivision.AutoSize = True
        Me.chktdivision.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktdivision.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktdivision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktdivision.Location = New System.Drawing.Point(344, 48)
        Me.chktdivision.Name = "chktdivision"
        Me.chktdivision.Size = New System.Drawing.Size(57, 20)
        Me.chktdivision.TabIndex = 118
        Me.chktdivision.Text = "Todas"
        Me.chktdivision.UseVisualStyleBackColor = True
        '
        'chktempresa
        '
        Me.chktempresa.AutoSize = True
        Me.chktempresa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktempresa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktempresa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chktempresa.Location = New System.Drawing.Point(344, 15)
        Me.chktempresa.Name = "chktempresa"
        Me.chktempresa.Size = New System.Drawing.Size(57, 20)
        Me.chktempresa.TabIndex = 117
        Me.chktempresa.Text = "Todas"
        Me.chktempresa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(25, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Depto:"
        '
        'cmbdivision
        '
        Me.cmbdivision.FormattingEnabled = True
        Me.cmbdivision.Location = New System.Drawing.Point(74, 44)
        Me.cmbdivision.Name = "cmbdivision"
        Me.cmbdivision.Size = New System.Drawing.Size(264, 24)
        Me.cmbdivision.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(19, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "División"
        '
        'cmbseccion
        '
        Me.cmbseccion.FormattingEnabled = True
        Me.cmbseccion.Location = New System.Drawing.Point(74, 107)
        Me.cmbseccion.Name = "cmbseccion"
        Me.cmbseccion.Size = New System.Drawing.Size(264, 24)
        Me.cmbseccion.TabIndex = 69
        '
        'cmbdepto
        '
        Me.cmbdepto.FormattingEnabled = True
        Me.cmbdepto.Location = New System.Drawing.Point(74, 76)
        Me.cmbdepto.Name = "cmbdepto"
        Me.cmbdepto.Size = New System.Drawing.Size(264, 24)
        Me.cmbdepto.TabIndex = 71
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(18, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Seccion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Empresa:"
        '
        'cmbempresa
        '
        Me.cmbempresa.FormattingEnabled = True
        Me.cmbempresa.Location = New System.Drawing.Point(74, 13)
        Me.cmbempresa.Name = "cmbempresa"
        Me.cmbempresa.Size = New System.Drawing.Size(264, 24)
        Me.cmbempresa.TabIndex = 0
        '
        'ChkFirma
        '
        Me.ChkFirma.AutoSize = True
        Me.ChkFirma.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFirma.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFirma.Location = New System.Drawing.Point(6, 214)
        Me.ChkFirma.Name = "ChkFirma"
        Me.ChkFirma.Size = New System.Drawing.Size(128, 20)
        Me.ChkFirma.TabIndex = 1
        Me.ChkFirma.Text = "Solicitar Firmas:         "
        Me.ChkFirma.UseVisualStyleBackColor = True
        Me.ChkFirma.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chknosocios)
        Me.GroupBox2.Controls.Add(Me.ChkSocios)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(131, 147)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estatus"
        '
        'chknosocios
        '
        Me.chknosocios.AutoSize = True
        Me.chknosocios.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chknosocios.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknosocios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chknosocios.Location = New System.Drawing.Point(27, 82)
        Me.chknosocios.Name = "chknosocios"
        Me.chknosocios.Size = New System.Drawing.Size(75, 20)
        Me.chknosocios.TabIndex = 63
        Me.chknosocios.Text = "No Socios"
        Me.chknosocios.UseVisualStyleBackColor = True
        '
        'ChkSocios
        '
        Me.ChkSocios.AutoSize = True
        Me.ChkSocios.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSocios.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSocios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSocios.Location = New System.Drawing.Point(27, 38)
        Me.ChkSocios.Name = "ChkSocios"
        Me.ChkSocios.Size = New System.Drawing.Size(76, 20)
        Me.ChkSocios.TabIndex = 0
        Me.ChkSocios.Text = "Socios      "
        Me.ChkSocios.UseVisualStyleBackColor = True
        '
        'TxtCompañia
        '
        Me.TxtCompañia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCompañia.Location = New System.Drawing.Point(118, 24)
        Me.TxtCompañia.Name = "TxtCompañia"
        Me.TxtCompañia.ReadOnly = True
        Me.TxtCompañia.Size = New System.Drawing.Size(391, 15)
        Me.TxtCompañia.TabIndex = 61
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(285, 208)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(173, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha Contable :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.Location = New System.Drawing.Point(701, 247)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(60, 60)
        Me.btnVerBC.TabIndex = 3
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(649, 46)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 169)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 116
        Me.pbImagen.TabStop = False
        '
        'Cooperativa_Reportes_Socios_No
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 369)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnVerBC)
        Me.Name = "Cooperativa_Reportes_Socios_No"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa_Reportes_Socios_No"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents ChkSocios As System.Windows.Forms.CheckBox
    Friend WithEvents ChkFirma As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chknosocios As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbempresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbseccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbdivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbdepto As System.Windows.Forms.ComboBox
    Friend WithEvents chktseccion As System.Windows.Forms.CheckBox
    Friend WithEvents chktdepto As System.Windows.Forms.CheckBox
    Friend WithEvents chktdivision As System.Windows.Forms.CheckBox
    Friend WithEvents chktempresa As System.Windows.Forms.CheckBox
End Class
