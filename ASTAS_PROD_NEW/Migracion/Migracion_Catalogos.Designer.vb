<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Migracion_Catalogos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Migracion_Catalogos))
        Me.btnMigracion = New System.Windows.Forms.Button
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbAIndemnizar = New System.Windows.Forms.RadioButton
        Me.rbCatBenef = New System.Windows.Forms.RadioButton
        Me.rbDescuentos = New System.Windows.Forms.RadioButton
        Me.rbCatEmpl = New System.Windows.Forms.RadioButton
        Me.rbAhorros = New System.Windows.Forms.RadioButton
        Me.OpenFD = New System.Windows.Forms.OpenFileDialog
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox
        Me.pB1 = New System.Windows.Forms.ProgressBar
        Me.BwDesc = New System.ComponentModel.BackgroundWorker
        Me.BwBenef = New System.ComponentModel.BackgroundWorker
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BwAhorros = New System.ComponentModel.BackgroundWorker
        Me.btnArchivo = New System.Windows.Forms.Button
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMigracion
        '
        Me.btnMigracion.BackColor = System.Drawing.Color.Transparent
        Me.btnMigracion.Image = CType(resources.GetObject("btnMigracion.Image"), System.Drawing.Image)
        Me.btnMigracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMigracion.Location = New System.Drawing.Point(207, 128)
        Me.btnMigracion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMigracion.Name = "btnMigracion"
        Me.btnMigracion.Size = New System.Drawing.Size(119, 30)
        Me.btnMigracion.TabIndex = 5
        Me.btnMigracion.Text = "&Cargar Archivo"
        Me.btnMigracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnMigracion, "Ejecuta el proceso de migracion para los datos indicados")
        Me.btnMigracion.UseVisualStyleBackColor = False
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(12, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(125, 166)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 13
        Me.pbImagen.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbAIndemnizar)
        Me.GroupBox2.Controls.Add(Me.rbCatBenef)
        Me.GroupBox2.Controls.Add(Me.rbDescuentos)
        Me.GroupBox2.Controls.Add(Me.btnMigracion)
        Me.GroupBox2.Controls.Add(Me.rbCatEmpl)
        Me.GroupBox2.Controls.Add(Me.rbAhorros)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(152, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 173)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Archivos"
        '
        'rbAIndemnizar
        '
        Me.rbAIndemnizar.AutoSize = True
        Me.rbAIndemnizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbAIndemnizar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbAIndemnizar.Location = New System.Drawing.Point(16, 81)
        Me.rbAIndemnizar.Name = "rbAIndemnizar"
        Me.rbAIndemnizar.Size = New System.Drawing.Size(143, 20)
        Me.rbAIndemnizar.TabIndex = 2
        Me.rbAIndemnizar.Text = "Empleados A Indemnizar"
        Me.rbAIndemnizar.UseVisualStyleBackColor = True
        '
        'rbCatBenef
        '
        Me.rbCatBenef.AutoSize = True
        Me.rbCatBenef.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbCatBenef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbCatBenef.Location = New System.Drawing.Point(16, 138)
        Me.rbCatBenef.Name = "rbCatBenef"
        Me.rbCatBenef.Size = New System.Drawing.Size(145, 20)
        Me.rbCatBenef.TabIndex = 4
        Me.rbCatBenef.Text = "Catálogo de Beneficiarios"
        Me.rbCatBenef.UseVisualStyleBackColor = True
        '
        'rbDescuentos
        '
        Me.rbDescuentos.AutoSize = True
        Me.rbDescuentos.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbDescuentos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbDescuentos.Location = New System.Drawing.Point(16, 53)
        Me.rbDescuentos.Name = "rbDescuentos"
        Me.rbDescuentos.Size = New System.Drawing.Size(254, 20)
        Me.rbDescuentos.TabIndex = 1
        Me.rbDescuentos.Text = "Descuentos Aplicados y No Aplicados en Planilla"
        Me.rbDescuentos.UseVisualStyleBackColor = True
        '
        'rbCatEmpl
        '
        Me.rbCatEmpl.AutoSize = True
        Me.rbCatEmpl.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCatEmpl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbCatEmpl.Location = New System.Drawing.Point(16, 110)
        Me.rbCatEmpl.Name = "rbCatEmpl"
        Me.rbCatEmpl.Size = New System.Drawing.Size(138, 20)
        Me.rbCatEmpl.TabIndex = 3
        Me.rbCatEmpl.Text = "Catálogo de Empleados"
        Me.rbCatEmpl.UseVisualStyleBackColor = True
        '
        'rbAhorros
        '
        Me.rbAhorros.AutoSize = True
        Me.rbAhorros.Checked = True
        Me.rbAhorros.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbAhorros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbAhorros.Location = New System.Drawing.Point(16, 26)
        Me.rbAhorros.Name = "rbAhorros"
        Me.rbAhorros.Size = New System.Drawing.Size(163, 20)
        Me.rbAhorros.TabIndex = 0
        Me.rbAhorros.TabStop = True
        Me.rbAhorros.Text = "Ahorros Aplicados en Planilla"
        Me.rbAhorros.UseVisualStyleBackColor = True
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRutaArchivo.BackColor = System.Drawing.Color.White
        Me.txtRutaArchivo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaArchivo.Location = New System.Drawing.Point(152, 180)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.ReadOnly = True
        Me.txtRutaArchivo.Size = New System.Drawing.Size(334, 20)
        Me.txtRutaArchivo.TabIndex = 2
        '
        'pB1
        '
        Me.pB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pB1.Location = New System.Drawing.Point(4, 206)
        Me.pB1.Name = "pB1"
        Me.pB1.Size = New System.Drawing.Size(482, 23)
        Me.pB1.TabIndex = 3
        '
        'BwDesc
        '
        Me.BwDesc.WorkerReportsProgress = True
        '
        'BwBenef
        '
        Me.BwBenef.WorkerReportsProgress = True
        Me.BwBenef.WorkerSupportsCancellation = True
        '
        'BwAhorros
        '
        Me.BwAhorros.WorkerReportsProgress = True
        Me.BwAhorros.WorkerSupportsCancellation = True
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Location = New System.Drawing.Point(4, 177)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(144, 27)
        Me.btnArchivo.TabIndex = 1
        Me.btnArchivo.Text = "Seleccionar Archivo"
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'Migracion_Catalogos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 233)
        Me.Controls.Add(Me.btnArchivo)
        Me.Controls.Add(Me.pB1)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pbImagen)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Migracion_Catalogos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Migracion - Carga Archivos de Texto"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMigracion As System.Windows.Forms.Button
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRutaArchivo As System.Windows.Forms.TextBox
    Friend WithEvents rbCatBenef As System.Windows.Forms.RadioButton
    Friend WithEvents rbCatEmpl As System.Windows.Forms.RadioButton
    Friend WithEvents rbAIndemnizar As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescuentos As System.Windows.Forms.RadioButton
    Friend WithEvents rbAhorros As System.Windows.Forms.RadioButton
    Friend WithEvents pB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BwDesc As System.ComponentModel.BackgroundWorker
    Friend WithEvents BwBenef As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BwAhorros As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnArchivo As System.Windows.Forms.Button
End Class
