<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaReporteRemesasAbonoAhorros
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.dpFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.gbOpciones = New System.Windows.Forms.GroupBox
        Me.btnReporte = New System.Windows.Forms.Button
        Me.dpFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.crvRepRemesas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gbOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Desde:"
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.CustomFormat = "dd 'de' MMMM 'de' yyyy"
        Me.dpFechaDesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaDesde.Location = New System.Drawing.Point(60, 20)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(173, 22)
        Me.dpFechaDesde.TabIndex = 7
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.btnReporte)
        Me.gbOpciones.Controls.Add(Me.dpFechaHasta)
        Me.gbOpciones.Controls.Add(Me.Label1)
        Me.gbOpciones.Controls.Add(Me.dpFechaDesde)
        Me.gbOpciones.Controls.Add(Me.Label4)
        Me.gbOpciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(5, 5)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(640, 55)
        Me.gbOpciones.TabIndex = 8
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(529, 20)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(84, 23)
        Me.btnReporte.TabIndex = 10
        Me.btnReporte.Text = "Generar"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.CustomFormat = "dd 'de' MMMM 'de' yyyy"
        Me.dpFechaHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaHasta.Location = New System.Drawing.Point(324, 20)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(173, 22)
        Me.dpFechaHasta.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(280, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Hasta:"
        '
        'crvRepRemesas
        '
        Me.crvRepRemesas.ActiveViewIndex = -1
        Me.crvRepRemesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvRepRemesas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvRepRemesas.DisplayGroupTree = False
        Me.crvRepRemesas.Location = New System.Drawing.Point(3, 66)
        Me.crvRepRemesas.Name = "crvRepRemesas"
        Me.crvRepRemesas.SelectionFormula = ""
        Me.crvRepRemesas.Size = New System.Drawing.Size(785, 417)
        Me.crvRepRemesas.TabIndex = 9
        Me.crvRepRemesas.ViewTimeSelectionFormula = ""
        '
        'CooperativaReporteRemesasAbonoAhorros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 485)
        Me.Controls.Add(Me.crvRepRemesas)
        Me.Controls.Add(Me.gbOpciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CooperativaReporteRemesasAbonoAhorros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Remesas Ahorro Extraordinario"
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents crvRepRemesas As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents dpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
