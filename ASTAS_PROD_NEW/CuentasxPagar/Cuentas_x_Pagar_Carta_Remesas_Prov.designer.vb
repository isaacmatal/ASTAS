<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cuentas_x_Pagar_Carta_Remesas_Prov
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCorrRemesa = New System.Windows.Forms.ComboBox
        Me.gbOpciones = New System.Windows.Forms.GroupBox
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnReporte = New System.Windows.Forms.Button
        Me.crvRepRemesas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gbOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 24)
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
        Me.cmbBanco.Location = New System.Drawing.Point(62, 21)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(293, 24)
        Me.cmbBanco.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Remesas desde:"
        '
        'cmbCorrRemesa
        '
        Me.cmbCorrRemesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorrRemesa.DropDownWidth = 304
        Me.cmbCorrRemesa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCorrRemesa.FormattingEnabled = True
        Me.cmbCorrRemesa.Items.AddRange(New Object() {"Prestamos", "Ahorros Extraordinarios"})
        Me.cmbCorrRemesa.Location = New System.Drawing.Point(498, 21)
        Me.cmbCorrRemesa.Name = "cmbCorrRemesa"
        Me.cmbCorrRemesa.Size = New System.Drawing.Size(304, 24)
        Me.cmbCorrRemesa.TabIndex = 5
        '
        'gbOpciones
        '
        Me.gbOpciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbOpciones.BackColor = System.Drawing.Color.Transparent
        Me.gbOpciones.Controls.Add(Me.dtpFechaFinal)
        Me.gbOpciones.Controls.Add(Me.Label4)
        Me.gbOpciones.Controls.Add(Me.dtpFechaInicial)
        Me.gbOpciones.Controls.Add(Me.Label2)
        Me.gbOpciones.Controls.Add(Me.btnReporte)
        Me.gbOpciones.Controls.Add(Me.cmbCorrRemesa)
        Me.gbOpciones.Controls.Add(Me.Label1)
        Me.gbOpciones.Controls.Add(Me.cmbBanco)
        Me.gbOpciones.Controls.Add(Me.Label3)
        Me.gbOpciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(12, 5)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(859, 87)
        Me.gbOpciones.TabIndex = 8
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(259, 55)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(96, 22)
        Me.dtpFechaFinal.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(215, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Hasta:"
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(105, 55)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(96, 22)
        Me.dtpFechaInicial.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(393, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nombe Proveedor:"
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(396, 45)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(79, 36)
        Me.btnReporte.TabIndex = 10
        Me.btnReporte.Text = "Generar"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'crvRepRemesas
        '
        Me.crvRepRemesas.ActiveViewIndex = -1
        Me.crvRepRemesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvRepRemesas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvRepRemesas.Location = New System.Drawing.Point(12, 111)
        Me.crvRepRemesas.Name = "crvRepRemesas"
        Me.crvRepRemesas.SelectionFormula = ""
        Me.crvRepRemesas.Size = New System.Drawing.Size(859, 362)
        Me.crvRepRemesas.TabIndex = 9
        Me.crvRepRemesas.ViewTimeSelectionFormula = ""
        '
        'Cuentas_x_Pagar_Carta_Remesas_Prov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 485)
        Me.Controls.Add(Me.crvRepRemesas)
        Me.Controls.Add(Me.gbOpciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cuentas_x_Pagar_Carta_Remesas_Prov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carta Remesas Electronicas"
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCorrRemesa As System.Windows.Forms.ComboBox
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents crvRepRemesas As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
