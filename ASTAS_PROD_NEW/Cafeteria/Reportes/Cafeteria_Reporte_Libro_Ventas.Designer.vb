<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Libro_Ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_Libro_Ventas))
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.btnReporte = New System.Windows.Forms.Button
        Me.gbFiltro = New System.Windows.Forms.GroupBox
        Me.dpFECHA_HASTA = New System.Windows.Forms.DateTimePicker
        Me.dpFECHA_DESDE = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gbGral.SuspendLayout()
        Me.gbFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGral
        '
        Me.gbGral.Controls.Add(Me.btnReporte)
        Me.gbGral.Controls.Add(Me.gbFiltro)
        Me.gbGral.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.gbGral.Controls.Add(Me.Label2)
        Me.gbGral.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.gbGral.Controls.Add(Me.Label4)
        Me.gbGral.Controls.Add(Me.cmbCOMPAÑIA)
        Me.gbGral.Controls.Add(Me.Label1)
        Me.gbGral.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(0, 0)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Size = New System.Drawing.Size(886, 102)
        Me.gbGral.TabIndex = 4
        Me.gbGral.TabStop = False
        Me.gbGral.Text = "Datos Generales"
        '
        'btnReporte
        '
        Me.btnReporte.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnReporte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(701, 17)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(119, 25)
        Me.btnReporte.TabIndex = 8
        Me.btnReporte.Text = "&Ver Libro de Vtas"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'gbFiltro
        '
        Me.gbFiltro.Controls.Add(Me.dpFECHA_HASTA)
        Me.gbFiltro.Controls.Add(Me.dpFECHA_DESDE)
        Me.gbFiltro.Controls.Add(Me.Label10)
        Me.gbFiltro.Controls.Add(Me.Label16)
        Me.gbFiltro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.ForeColor = System.Drawing.Color.Navy
        Me.gbFiltro.Location = New System.Drawing.Point(537, 11)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(158, 85)
        Me.gbFiltro.TabIndex = 4
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Filtros"
        '
        'dpFECHA_HASTA
        '
        Me.dpFECHA_HASTA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_HASTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_HASTA.Location = New System.Drawing.Point(49, 59)
        Me.dpFECHA_HASTA.Name = "dpFECHA_HASTA"
        Me.dpFECHA_HASTA.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_HASTA.TabIndex = 2
        '
        'dpFECHA_DESDE
        '
        Me.dpFECHA_DESDE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_DESDE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_DESDE.Location = New System.Drawing.Point(48, 31)
        Me.dpFECHA_DESDE.Name = "dpFECHA_DESDE"
        Me.dpFECHA_DESDE.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_DESDE.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(1, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Desde :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(2, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 16)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Hasta :"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(91, 45)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(444, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(1, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Libro Contable :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Items.AddRange(New Object() {"Tickets"})
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(91, 72)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(240, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(1, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tipo Documento :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(91, 18)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(444, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(1, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Compañía :"
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.crvReporte.Location = New System.Drawing.Point(0, 102)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(886, 436)
        Me.crvReporte.TabIndex = 5
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'Cafeteria_Reporte_Libro_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(886, 514)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.gbGral)
        Me.Name = "Cafeteria_Reporte_Libro_Ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reporte_Libro_Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents dpFECHA_HASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFECHA_DESDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
