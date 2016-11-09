<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmabonoexternos
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
        Me.DtpFechaPrimerPag = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvAbonos = New System.Windows.Forms.DataGridView
        Me.btnabonar = New System.Windows.Forms.Button
        Me.DgvProgramacion = New System.Windows.Forms.DataGridView
        Me.DtpFechaAbono = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.lblArchivoExcel = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbSheets = New System.Windows.Forms.ComboBox
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.lblCUENTA_COMPLETA = New System.Windows.Forms.Label
        Me.cmbBANCO = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.lblCUENTA = New System.Windows.Forms.Label
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvProgramacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtpFechaPrimerPag
        '
        Me.DtpFechaPrimerPag.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaPrimerPag.Location = New System.Drawing.Point(295, 10)
        Me.DtpFechaPrimerPag.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DtpFechaPrimerPag.Name = "DtpFechaPrimerPag"
        Me.DtpFechaPrimerPag.Size = New System.Drawing.Size(99, 22)
        Me.DtpFechaPrimerPag.TabIndex = 226
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(213, 12)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 227
        Me.Label10.Text = "Próximo Pago:"
        '
        'dgvAbonos
        '
        Me.dgvAbonos.AllowUserToAddRows = False
        Me.dgvAbonos.AllowUserToDeleteRows = False
        Me.dgvAbonos.AllowUserToResizeRows = False
        Me.dgvAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAbonos.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvAbonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAbonos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAbonos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAbonos.Location = New System.Drawing.Point(12, 230)
        Me.dgvAbonos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvAbonos.MultiSelect = False
        Me.dgvAbonos.Name = "dgvAbonos"
        Me.dgvAbonos.ReadOnly = True
        Me.dgvAbonos.RowHeadersVisible = False
        Me.dgvAbonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAbonos.Size = New System.Drawing.Size(481, 262)
        Me.dgvAbonos.TabIndex = 229
        '
        'btnabonar
        '
        Me.btnabonar.BackColor = System.Drawing.Color.Transparent
        Me.btnabonar.Location = New System.Drawing.Point(415, 7)
        Me.btnabonar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnabonar.Name = "btnabonar"
        Me.btnabonar.Size = New System.Drawing.Size(78, 31)
        Me.btnabonar.TabIndex = 231
        Me.btnabonar.Text = "ABONAR"
        Me.btnabonar.UseVisualStyleBackColor = False
        '
        'DgvProgramacion
        '
        Me.DgvProgramacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProgramacion.Location = New System.Drawing.Point(32, 245)
        Me.DgvProgramacion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DgvProgramacion.Name = "DgvProgramacion"
        Me.DgvProgramacion.Size = New System.Drawing.Size(432, 245)
        Me.DgvProgramacion.TabIndex = 233
        '
        'DtpFechaAbono
        '
        Me.DtpFechaAbono.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaAbono.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DtpFechaAbono.Location = New System.Drawing.Point(104, 10)
        Me.DtpFechaAbono.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DtpFechaAbono.Name = "DtpFechaAbono"
        Me.DtpFechaAbono.Size = New System.Drawing.Size(99, 22)
        Me.DtpFechaAbono.TabIndex = 234
        Me.DtpFechaAbono.Value = New Date(2015, 3, 5, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Fecha de Abono:"
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnImportarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImportarExcel.Image = Global.ASTAS.My.Resources.Resources.bookmark_folder
        Me.btnImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarExcel.Location = New System.Drawing.Point(468, 43)
        Me.btnImportarExcel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(25, 33)
        Me.btnImportarExcel.TabIndex = 239
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportarExcel.UseVisualStyleBackColor = False
        '
        'lblArchivoExcel
        '
        Me.lblArchivoExcel.BackColor = System.Drawing.Color.White
        Me.lblArchivoExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblArchivoExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivoExcel.ForeColor = System.Drawing.Color.Navy
        Me.lblArchivoExcel.Location = New System.Drawing.Point(104, 43)
        Me.lblArchivoExcel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblArchivoExcel.Name = "lblArchivoExcel"
        Me.lblArchivoExcel.Size = New System.Drawing.Size(360, 35)
        Me.lblArchivoExcel.TabIndex = 240
        Me.lblArchivoExcel.Text = "CARGUE UN DOCUMENTO DE EXCEL"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(12, 47)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 16)
        Me.Label26.TabIndex = 241
        Me.Label26.Text = "Archivo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "Hojas :"
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.DropDownWidth = 300
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(104, 86)
        Me.cmbSheets.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(228, 24)
        Me.cmbSheets.TabIndex = 243
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(433, 85)
        Me.txtPartida.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(60, 22)
        Me.txtPartida.TabIndex = 245
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(344, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "Número Partida :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(14, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(104, 121)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(389, 22)
        Me.txtConcepto.TabIndex = 247
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.BackColor = System.Drawing.Color.Transparent
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Black
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(398, 19)
        Me.lblLIBRO_CONTABLE.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 248
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(392, 193)
        Me.lblCUENTA_COMPLETA.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(100, 27)
        Me.lblCUENTA_COMPLETA.TabIndex = 251
        Me.lblCUENTA_COMPLETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBANCO
        '
        Me.cmbBANCO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBANCO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBANCO.ForeColor = System.Drawing.Color.Navy
        Me.cmbBANCO.FormattingEnabled = True
        Me.cmbBANCO.Location = New System.Drawing.Point(104, 153)
        Me.cmbBANCO.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(389, 24)
        Me.cmbBANCO.TabIndex = 249
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(12, 196)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "Cuenta Banco :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(14, 157)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Banco :"
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.DropDownWidth = 350
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(104, 193)
        Me.cmbCUENTA_BANCARIA.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(282, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 250
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(398, 0)
        Me.lblCUENTA.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 254
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'frmabonoexternos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 502)
        Me.Controls.Add(Me.lblCUENTA)
        Me.Controls.Add(Me.lblCUENTA_COMPLETA)
        Me.Controls.Add(Me.cmbBANCO)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbSheets)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnImportarExcel)
        Me.Controls.Add(Me.lblArchivoExcel)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtpFechaAbono)
        Me.Controls.Add(Me.btnabonar)
        Me.Controls.Add(Me.dgvAbonos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DtpFechaPrimerPag)
        Me.Controls.Add(Me.DgvProgramacion)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmabonoexternos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Aplicar Abonos por grupo"
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvProgramacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtpFechaPrimerPag As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvAbonos As System.Windows.Forms.DataGridView
    Friend WithEvents btnabonar As System.Windows.Forms.Button
    Friend WithEvents DgvProgramacion As System.Windows.Forms.DataGridView
    Friend WithEvents DtpFechaAbono As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblArchivoExcel As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label

    Friend WithEvents OpenFileDialogAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSheets As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA_COMPLETA As System.Windows.Forms.Label
    Friend WithEvents cmbBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
End Class
