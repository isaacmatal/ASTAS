<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radDefault = New System.Windows.Forms.RadioButton
        Me.radNoAfectan = New System.Windows.Forms.RadioButton
        Me.radSiAfectan = New System.Windows.Forms.RadioButton
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.radDefault)
        Me.GroupBox1.Controls.Add(Me.radNoAfectan)
        Me.GroupBox1.Controls.Add(Me.radSiAfectan)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 122)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'radDefault
        '
        Me.radDefault.AutoSize = True
        Me.radDefault.Checked = True
        Me.radDefault.Location = New System.Drawing.Point(484, 19)
        Me.radDefault.Name = "radDefault"
        Me.radDefault.Size = New System.Drawing.Size(14, 13)
        Me.radDefault.TabIndex = 2
        Me.radDefault.TabStop = True
        Me.radDefault.UseVisualStyleBackColor = True
        Me.radDefault.Visible = False
        '
        'radNoAfectan
        '
        Me.radNoAfectan.Appearance = System.Windows.Forms.Appearance.Button
        Me.radNoAfectan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radNoAfectan.Location = New System.Drawing.Point(104, 71)
        Me.radNoAfectan.Name = "radNoAfectan"
        Me.radNoAfectan.Size = New System.Drawing.Size(280, 30)
        Me.radNoAfectan.TabIndex = 1
        Me.radNoAfectan.Text = "Compras que No Afectan Inventarios"
        Me.radNoAfectan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radNoAfectan.UseVisualStyleBackColor = True
        '
        'radSiAfectan
        '
        Me.radSiAfectan.Appearance = System.Windows.Forms.Appearance.Button
        Me.radSiAfectan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSiAfectan.Location = New System.Drawing.Point(104, 19)
        Me.radSiAfectan.Name = "radSiAfectan"
        Me.radSiAfectan.Size = New System.Drawing.Size(280, 30)
        Me.radSiAfectan.TabIndex = 0
        Me.radSiAfectan.Text = "Compras que Afectan Inventarios"
        Me.radSiAfectan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radSiAfectan.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(267, 140)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(98, 40)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = Global.ASTAS.My.Resources.Resources.ok
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(144, 140)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 40)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmSeleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 183)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Tipo de Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radNoAfectan As System.Windows.Forms.RadioButton
    Friend WithEvents radSiAfectan As System.Windows.Forms.RadioButton
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents radDefault As System.Windows.Forms.RadioButton
End Class
