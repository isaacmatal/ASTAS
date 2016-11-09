<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperativa_Autorizacion_Desc_Agui_Boni
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cooperativa_Autorizacion_Desc_Agui_Boni))
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.BtnBuscarSocio = New System.Windows.Forms.Button
        Me.grbAgui = New System.Windows.Forms.GroupBox
        Me.txtValAgui = New System.Windows.Forms.TextBox
        Me.grbBoni = New System.Windows.Forms.GroupBox
        Me.txtValBoni = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.lblNombre = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.grbAgui.SuspendLayout()
        Me.grbBoni.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Código :"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.White
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(69, 12)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(70, 26)
        Me.TxtCodigoBuxis.TabIndex = 0
        '
        'BtnBuscarSocio
        '
        Me.BtnBuscarSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSocio.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSocio.Image = CType(resources.GetObject("BtnBuscarSocio.Image"), System.Drawing.Image)
        Me.BtnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSocio.Location = New System.Drawing.Point(142, 14)
        Me.BtnBuscarSocio.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnBuscarSocio.Name = "BtnBuscarSocio"
        Me.BtnBuscarSocio.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSocio.TabIndex = 3
        Me.BtnBuscarSocio.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSocio.UseVisualStyleBackColor = True
        '
        'grbAgui
        '
        Me.grbAgui.BackColor = System.Drawing.Color.Transparent
        Me.grbAgui.Controls.Add(Me.txtValAgui)
        Me.grbAgui.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbAgui.Location = New System.Drawing.Point(15, 107)
        Me.grbAgui.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grbAgui.Name = "grbAgui"
        Me.grbAgui.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grbAgui.Size = New System.Drawing.Size(203, 88)
        Me.grbAgui.TabIndex = 1
        Me.grbAgui.TabStop = False
        Me.grbAgui.Text = " Aguinaldo "
        '
        'txtValAgui
        '
        Me.txtValAgui.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValAgui.ForeColor = System.Drawing.Color.Navy
        Me.txtValAgui.Location = New System.Drawing.Point(43, 35)
        Me.txtValAgui.Name = "txtValAgui"
        Me.txtValAgui.Size = New System.Drawing.Size(117, 29)
        Me.txtValAgui.TabIndex = 0
        Me.txtValAgui.Text = "0.00"
        Me.txtValAgui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbBoni
        '
        Me.grbBoni.BackColor = System.Drawing.Color.Transparent
        Me.grbBoni.Controls.Add(Me.txtValBoni)
        Me.grbBoni.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbBoni.Location = New System.Drawing.Point(14, 205)
        Me.grbBoni.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grbBoni.Name = "grbBoni"
        Me.grbBoni.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grbBoni.Size = New System.Drawing.Size(204, 88)
        Me.grbBoni.TabIndex = 2
        Me.grbBoni.TabStop = False
        Me.grbBoni.Text = " Bonificación "
        '
        'txtValBoni
        '
        Me.txtValBoni.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValBoni.ForeColor = System.Drawing.Color.Navy
        Me.txtValBoni.Location = New System.Drawing.Point(44, 36)
        Me.txtValBoni.Name = "txtValBoni"
        Me.txtValBoni.Size = New System.Drawing.Size(117, 29)
        Me.txtValBoni.TabIndex = 0
        Me.txtValBoni.Text = "0.00"
        Me.txtValBoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(194, 14)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Navy
        Me.lblNombre.Location = New System.Drawing.Point(16, 44)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(202, 59)
        Me.lblNombre.TabIndex = 11
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.Color.Black
        Me.btnNuevo.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(168, 14)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Cooperativa_Autorizacion_Desc_Agui_Boni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 307)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.grbBoni)
        Me.Controls.Add(Me.grbAgui)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCodigoBuxis)
        Me.Controls.Add(Me.BtnBuscarSocio)
        Me.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cooperativa_Autorizacion_Desc_Agui_Boni"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización Cuotas Especiales"
        Me.grbAgui.ResumeLayout(False)
        Me.grbAgui.PerformLayout()
        Me.grbBoni.ResumeLayout(False)
        Me.grbBoni.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSocio As System.Windows.Forms.Button
    Friend WithEvents grbAgui As System.Windows.Forms.GroupBox
    Friend WithEvents grbBoni As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtValAgui As System.Windows.Forms.TextBox
    Friend WithEvents txtValBoni As System.Windows.Forms.TextBox
End Class
