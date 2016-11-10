<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Consulta_Cheques_Emergencia
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dpdesde = New System.Windows.Forms.DateTimePicker
        Me.dphasta = New System.Windows.Forms.DateTimePicker
        Me.btnconsultar = New System.Windows.Forms.Button
        Me.btnReporte = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnChqInd = New System.Windows.Forms.Button
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.txtBanco = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.txtCuentaBco = New System.Windows.Forms.TextBox
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnImpCheque = New System.Windows.Forms.Button
        Me.btnguardar = New System.Windows.Forms.Button
        Me.dgvchequeemergencia = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.noneg = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvchequeemergencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dpdesde
        '
        Me.dpdesde.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpdesde.CustomFormat = "dd-MMM-yyyy"
        Me.dpdesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpdesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpdesde.Location = New System.Drawing.Point(60, 15)
        Me.dpdesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpdesde.MinDate = New Date(2001, 1, 1, 0, 0, 0, 0)
        Me.dpdesde.Name = "dpdesde"
        Me.dpdesde.Size = New System.Drawing.Size(112, 22)
        Me.dpdesde.TabIndex = 0
        Me.dpdesde.Value = New Date(2013, 1, 1, 0, 0, 0, 0)
        '
        'dphasta
        '
        Me.dphasta.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dphasta.CustomFormat = "dd-MMM-yyyy"
        Me.dphasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dphasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dphasta.Location = New System.Drawing.Point(251, 15)
        Me.dphasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dphasta.MinDate = New Date(2001, 1, 1, 0, 0, 0, 0)
        Me.dphasta.Name = "dphasta"
        Me.dphasta.Size = New System.Drawing.Size(112, 22)
        Me.dphasta.TabIndex = 1
        Me.dphasta.Value = New Date(2013, 1, 29, 0, 0, 0, 0)
        '
        'btnconsultar
        '
        Me.btnconsultar.ForeColor = System.Drawing.Color.Navy
        Me.btnconsultar.Image = Global.AstasConta.My.Resources.Resources.find
        Me.btnconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnconsultar.Location = New System.Drawing.Point(407, 13)
        Me.btnconsultar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnconsultar.Name = "btnconsultar"
        Me.btnconsultar.Size = New System.Drawing.Size(82, 31)
        Me.btnconsultar.TabIndex = 6
        Me.btnconsultar.Text = "Buscar"
        Me.btnconsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnconsultar.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.ForeColor = System.Drawing.Color.Navy
        Me.btnReporte.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(586, 13)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(99, 31)
        Me.btnReporte.TabIndex = 3
        Me.btnReporte.Text = "Ver Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Desde :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(197, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Hasta :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnChqInd)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.txtBanco)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO)
        Me.GroupBox1.Controls.Add(Me.txtCuentaBco)
        Me.GroupBox1.Controls.Add(Me.txtCheque)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnImpCheque)
        Me.GroupBox1.Controls.Add(Me.btnguardar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnReporte)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnconsultar)
        Me.GroupBox1.Controls.Add(Me.dpdesde)
        Me.GroupBox1.Controls.Add(Me.dphasta)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(948, 98)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        '
        'btnChqInd
        '
        Me.btnChqInd.ForeColor = System.Drawing.Color.Navy
        Me.btnChqInd.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnChqInd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChqInd.Location = New System.Drawing.Point(833, 13)
        Me.btnChqInd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnChqInd.Name = "btnChqInd"
        Me.btnChqInd.Size = New System.Drawing.Size(108, 31)
        Me.btnChqInd.TabIndex = 136
        Me.btnChqInd.Text = "Imp.Individual"
        Me.btnChqInd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChqInd.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuario.Location = New System.Drawing.Point(840, 71)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(97, 22)
        Me.txtUsuario.TabIndex = 5
        Me.txtUsuario.Tag = "Usuario"
        '
        'txtBanco
        '
        Me.txtBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBanco.Location = New System.Drawing.Point(165, 71)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(95, 22)
        Me.txtBanco.TabIndex = 2
        Me.txtBanco.Tag = "Banco"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(619, 71)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(217, 22)
        Me.txtNombre.TabIndex = 4
        Me.txtNombre.Tag = "A Nombre de"
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(261, 71)
        Me.txtCONCEPTO.MaxLength = 50
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.Size = New System.Drawing.Size(356, 22)
        Me.txtCONCEPTO.TabIndex = 3
        Me.txtCONCEPTO.Tag = "Concepto"
        '
        'txtCuentaBco
        '
        Me.txtCuentaBco.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuentaBco.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaBco.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentaBco.Location = New System.Drawing.Point(92, 71)
        Me.txtCuentaBco.MaxLength = 8
        Me.txtCuentaBco.Name = "txtCuentaBco"
        Me.txtCuentaBco.Size = New System.Drawing.Size(72, 22)
        Me.txtCuentaBco.TabIndex = 1
        Me.txtCuentaBco.Tag = "Cuenta Bancaria"
        '
        'txtCheque
        '
        Me.txtCheque.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheque.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.ForeColor = System.Drawing.Color.Navy
        Me.txtCheque.Location = New System.Drawing.Point(8, 71)
        Me.txtCheque.MaxLength = 8
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(83, 22)
        Me.txtCheque.TabIndex = 0
        Me.txtCheque.Tag = "N° Cheque"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(840, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 20)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Usuario"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(619, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 20)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "A Nombre de"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(261, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(355, 20)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Concepto"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(166, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Banco"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(93, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 20)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Cuenta Bancaria"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 20)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "N° Cheque"
        '
        'btnImpCheque
        '
        Me.btnImpCheque.ForeColor = System.Drawing.Color.Navy
        Me.btnImpCheque.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnImpCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImpCheque.Location = New System.Drawing.Point(691, 13)
        Me.btnImpCheque.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImpCheque.Name = "btnImpCheque"
        Me.btnImpCheque.Size = New System.Drawing.Size(136, 31)
        Me.btnImpCheque.TabIndex = 123
        Me.btnImpCheque.Text = "Imp.Seleccionados"
        Me.btnImpCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImpCheque.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.ForeColor = System.Drawing.Color.Navy
        Me.btnguardar.Image = Global.AstasConta.My.Resources.Resources.filesave
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnguardar.Location = New System.Drawing.Point(495, 13)
        Me.btnguardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(85, 31)
        Me.btnguardar.TabIndex = 7
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'dgvchequeemergencia
        '
        Me.dgvchequeemergencia.AllowUserToAddRows = False
        Me.dgvchequeemergencia.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        Me.dgvchequeemergencia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvchequeemergencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvchequeemergencia.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvchequeemergencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvchequeemergencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvchequeemergencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.noneg})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvchequeemergencia.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvchequeemergencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvchequeemergencia.Location = New System.Drawing.Point(12, 132)
        Me.dgvchequeemergencia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvchequeemergencia.MultiSelect = False
        Me.dgvchequeemergencia.Name = "dgvchequeemergencia"
        Me.dgvchequeemergencia.RowHeadersVisible = False
        Me.dgvchequeemergencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvchequeemergencia.Size = New System.Drawing.Size(948, 280)
        Me.dgvchequeemergencia.TabIndex = 124
        '
        'selec
        '
        Me.selec.HeaderText = ""
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'noneg
        '
        Me.noneg.HeaderText = "No Neg"
        Me.noneg.Name = "noneg"
        Me.noneg.Width = 40
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(948, 19)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "LAS MODIFICACIONES A UN CHEQUE SOLO PUEDEN SER REALIZADAS POR EL MISMO USUARIO QU" & _
            "E LO ELABORÓ Y EL CHEQUE NO HA SIDO IMPRESO "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Contabilidad_Consulta_Cheques_Emergencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 425)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvchequeemergencia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Consulta_Cheques_Emergencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar cheques"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvchequeemergencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnconsultar As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvchequeemergencia As System.Windows.Forms.DataGridView
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnImpCheque As System.Windows.Forms.Button
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents noneg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaBco As System.Windows.Forms.TextBox
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnChqInd As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
