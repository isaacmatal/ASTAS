<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Cheques_Emitidos_Firmas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Cheques_Emitidos_Firmas))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFechaF = New System.Windows.Forms.DateTimePicker
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.txtFechaI = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(628, 15)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(152, 140)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 143
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaF)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.txtFechaI)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 130)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cheques Enviados a su Cancelación"
        '
        'txtFechaF
        '
        Me.txtFechaF.Location = New System.Drawing.Point(125, 101)
        Me.txtFechaF.Name = "txtFechaF"
        Me.txtFechaF.Size = New System.Drawing.Size(220, 22)
        Me.txtFechaF.TabIndex = 122
        Me.txtFechaF.Visible = False
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(126, 23)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(431, 22)
        Me.txtCompañia.TabIndex = 121
        '
        'txtFechaI
        '
        Me.txtFechaI.Location = New System.Drawing.Point(125, 73)
        Me.txtFechaI.Name = "txtFechaI"
        Me.txtFechaI.Size = New System.Drawing.Size(220, 22)
        Me.txtFechaI.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(17, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Fecha desde:"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(125, 48)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 1
        Me.cmbBODEGA.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(17, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Bodega:"
        Me.Label6.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Compañía :"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(488, 79)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 45)
        Me.BtnBuscar.TabIndex = 4
        Me.BtnBuscar.Text = "Imprimir"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'Contabilidad_Reportes_Cheques_Emitidos_Firmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 255)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Contabilidad_Reportes_Cheques_Emitidos_Firmas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad_Reportes_Cheques_Emitidos_Firmas"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtFechaF As System.Windows.Forms.DateTimePicker
End Class
