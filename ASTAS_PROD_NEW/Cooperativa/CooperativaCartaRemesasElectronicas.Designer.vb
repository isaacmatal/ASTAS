<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaCartaRemesasElectronicas
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbBanco = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTipoRemesa = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dpFECHA = New System.Windows.Forms.DateTimePicker
        Me.gbOpciones = New System.Windows.Forms.GroupBox
        Me.NudBloque = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.crvRepRemesas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnReporte = New System.Windows.Forms.Button
        Me.gbOpciones.SuspendLayout()
        CType(Me.NudBloque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Banco:"
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(62, 20)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(227, 24)
        Me.cmbBanco.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cuenta:"
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(63, 47)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(226, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Remesas de:"
        '
        'cmbTipoRemesa
        '
        Me.cmbTipoRemesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRemesa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoRemesa.FormattingEnabled = True
        Me.cmbTipoRemesa.Items.AddRange(New Object() {"Prestamos", "Ahorros Extraordinarios"})
        Me.cmbTipoRemesa.Location = New System.Drawing.Point(368, 21)
        Me.cmbTipoRemesa.Name = "cmbTipoRemesa"
        Me.cmbTipoRemesa.Size = New System.Drawing.Size(173, 24)
        Me.cmbTipoRemesa.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(296, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha:"
        '
        'dpFECHA
        '
        Me.dpFECHA.CustomFormat = "dd 'de' MMMM 'de' yyyy"
        Me.dpFECHA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA.Location = New System.Drawing.Point(368, 48)
        Me.dpFECHA.Name = "dpFECHA"
        Me.dpFECHA.Size = New System.Drawing.Size(173, 22)
        Me.dpFECHA.TabIndex = 7
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.NudBloque)
        Me.gbOpciones.Controls.Add(Me.Label7)
        Me.gbOpciones.Controls.Add(Me.cmbTipoRemesa)
        Me.gbOpciones.Controls.Add(Me.dpFECHA)
        Me.gbOpciones.Controls.Add(Me.Label1)
        Me.gbOpciones.Controls.Add(Me.Label4)
        Me.gbOpciones.Controls.Add(Me.cmbBanco)
        Me.gbOpciones.Controls.Add(Me.Label2)
        Me.gbOpciones.Controls.Add(Me.Label3)
        Me.gbOpciones.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.gbOpciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(5, 5)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(682, 82)
        Me.gbOpciones.TabIndex = 8
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'NudBloque
        '
        Me.NudBloque.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudBloque.ForeColor = System.Drawing.Color.Navy
        Me.NudBloque.Location = New System.Drawing.Point(616, 48)
        Me.NudBloque.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudBloque.Name = "NudBloque"
        Me.NudBloque.Size = New System.Drawing.Size(46, 22)
        Me.NudBloque.TabIndex = 53
        Me.NudBloque.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(547, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Correlativo:"
        '
        'crvRepRemesas
        '
        Me.crvRepRemesas.ActiveViewIndex = -1
        Me.crvRepRemesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvRepRemesas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRepRemesas.DisplayGroupTree = False
        Me.crvRepRemesas.Location = New System.Drawing.Point(3, 93)
        Me.crvRepRemesas.Name = "crvRepRemesas"
        Me.crvRepRemesas.SelectionFormula = ""
        Me.crvRepRemesas.Size = New System.Drawing.Size(785, 390)
        Me.crvRepRemesas.TabIndex = 9
        Me.crvRepRemesas.ViewTimeSelectionFormula = ""
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(693, 29)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 23)
        Me.btnReporte.TabIndex = 10
        Me.btnReporte.Text = "Generar"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'CooperativaCartaRemesasElectronicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 485)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.crvRepRemesas)
        Me.Controls.Add(Me.gbOpciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CooperativaCartaRemesasElectronicas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carta Remesas Electronicas"
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.NudBloque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoRemesa As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents crvRepRemesas As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents NudBloque As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
