<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reportes_Catalogo_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reportes_Catalogo_Menu))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnBuscarProducto2 = New System.Windows.Forms.Button
        Me.btnBuscarProducto1 = New System.Windows.Forms.Button
        Me.txtProducto2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION2 = New System.Windows.Forms.TextBox
        Me.txtMedida2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label = New System.Windows.Forms.Label
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION1 = New System.Windows.Forms.TextBox
        Me.txtProducto1 = New System.Windows.Forms.TextBox
        Me.txtMedida1 = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(608, 13)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 169)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 106
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtProducto1)
        Me.GroupBox1.Controls.Add(Me.txtMedida1)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto2)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto1)
        Me.GroupBox1.Controls.Add(Me.txtProducto2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION2)
        Me.GroupBox1.Controls.Add(Me.txtMedida2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label)
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.cmbBodega)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 190)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recetas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(72, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(393, 22)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'btnBuscarProducto2
        '
        Me.btnBuscarProducto2.Image = CType(resources.GetObject("btnBuscarProducto2.Image"), System.Drawing.Image)
        Me.btnBuscarProducto2.Location = New System.Drawing.Point(137, 125)
        Me.btnBuscarProducto2.Name = "btnBuscarProducto2"
        Me.btnBuscarProducto2.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto2.TabIndex = 3
        Me.btnBuscarProducto2.UseVisualStyleBackColor = True
        '
        'btnBuscarProducto1
        '
        Me.btnBuscarProducto1.Image = CType(resources.GetObject("btnBuscarProducto1.Image"), System.Drawing.Image)
        Me.btnBuscarProducto1.Location = New System.Drawing.Point(137, 102)
        Me.btnBuscarProducto1.Name = "btnBuscarProducto1"
        Me.btnBuscarProducto1.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto1.TabIndex = 1
        Me.btnBuscarProducto1.UseVisualStyleBackColor = True
        '
        'txtProducto2
        '
        Me.txtProducto2.BackColor = System.Drawing.Color.White
        Me.txtProducto2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto2.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto2.Location = New System.Drawing.Point(72, 129)
        Me.txtProducto2.Name = "txtProducto2"
        Me.txtProducto2.Size = New System.Drawing.Size(63, 22)
        Me.txtProducto2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(4, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Menú Final :"
        '
        'txtDESCRIPCION2
        '
        Me.txtDESCRIPCION2.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION2.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION2.Location = New System.Drawing.Point(164, 129)
        Me.txtDESCRIPCION2.MaxLength = 100
        Me.txtDESCRIPCION2.Name = "txtDESCRIPCION2"
        Me.txtDESCRIPCION2.ReadOnly = True
        Me.txtDESCRIPCION2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION2.Size = New System.Drawing.Size(316, 22)
        Me.txtDESCRIPCION2.TabIndex = 4
        '
        'txtMedida2
        '
        Me.txtMedida2.BackColor = System.Drawing.SystemColors.Control
        Me.txtMedida2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida2.ForeColor = System.Drawing.Color.Navy
        Me.txtMedida2.Location = New System.Drawing.Point(485, 129)
        Me.txtMedida2.Name = "txtMedida2"
        Me.txtMedida2.ReadOnly = True
        Me.txtMedida2.Size = New System.Drawing.Size(117, 22)
        Me.txtMedida2.TabIndex = 127
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(4, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Menú Inicial :"
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Location = New System.Drawing.Point(158, 217)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(409, 23)
        Me.Label.TabIndex = 62
        Me.Label.Text = "ESPERE MIENTRAS SE GENERA INFORME"
        Me.Label.Visible = False
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.Location = New System.Drawing.Point(532, 22)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(60, 60)
        Me.btnVerBC.TabIndex = 5
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'cmbBodega
        '
        Me.cmbBodega.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega.ForeColor = System.Drawing.Color.Navy
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(74, 50)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(401, 24)
        Me.cmbBodega.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(4, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(74, 24)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(401, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        Me.cmbCOMPAÑIA.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(4, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        Me.Label1.Visible = False
        '
        'txtDESCRIPCION1
        '
        Me.txtDESCRIPCION1.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION1.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION1.Location = New System.Drawing.Point(165, 104)
        Me.txtDESCRIPCION1.MaxLength = 100
        Me.txtDESCRIPCION1.Name = "txtDESCRIPCION1"
        Me.txtDESCRIPCION1.ReadOnly = True
        Me.txtDESCRIPCION1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION1.Size = New System.Drawing.Size(316, 22)
        Me.txtDESCRIPCION1.TabIndex = 1
        '
        'txtProducto1
        '
        Me.txtProducto1.BackColor = System.Drawing.Color.White
        Me.txtProducto1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto1.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto1.Location = New System.Drawing.Point(72, 104)
        Me.txtProducto1.Name = "txtProducto1"
        Me.txtProducto1.Size = New System.Drawing.Size(63, 22)
        Me.txtProducto1.TabIndex = 0
        '
        'txtMedida1
        '
        Me.txtMedida1.BackColor = System.Drawing.SystemColors.Control
        Me.txtMedida1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida1.ForeColor = System.Drawing.Color.Navy
        Me.txtMedida1.Location = New System.Drawing.Point(485, 104)
        Me.txtMedida1.Name = "txtMedida1"
        Me.txtMedida1.ReadOnly = True
        Me.txtMedida1.Size = New System.Drawing.Size(117, 22)
        Me.txtMedida1.TabIndex = 123
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 190)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(984, 315)
        Me.CrystalReportViewer1.TabIndex = 106
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Cafeteria_Reportes_Catalogo_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 505)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cafeteria_Reportes_Catalogo_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reportes_Catalogo_Menu"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents txtProducto2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMedida2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION1 As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMedida1 As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto2 As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProducto1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
