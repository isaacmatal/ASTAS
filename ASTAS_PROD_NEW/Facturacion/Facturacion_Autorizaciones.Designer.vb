<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Autorizaciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grbGenerales = New System.Windows.Forms.GroupBox
        Me.lblClave = New System.Windows.Forms.Label
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.btnAutorizar = New System.Windows.Forms.Button
        Me.grbGenerales.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbGenerales
        '
        Me.grbGenerales.Controls.Add(Me.lblClave)
        Me.grbGenerales.Controls.Add(Me.lblUsuario)
        Me.grbGenerales.Controls.Add(Me.txtClave)
        Me.grbGenerales.Controls.Add(Me.txtUsuario)
        Me.grbGenerales.Controls.Add(Me.btnAutorizar)
        Me.grbGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbGenerales.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grbGenerales.Location = New System.Drawing.Point(0, 0)
        Me.grbGenerales.Name = "grbGenerales"
        Me.grbGenerales.Size = New System.Drawing.Size(249, 130)
        Me.grbGenerales.TabIndex = 0
        Me.grbGenerales.TabStop = False
        Me.grbGenerales.Text = "Datos Generales"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblClave.Location = New System.Drawing.Point(19, 63)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(91, 14)
        Me.lblClave.TabIndex = 4
        Me.lblClave.Text = "Ingrese su Clave:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblUsuario.Location = New System.Drawing.Point(19, 27)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(97, 14)
        Me.lblUsuario.TabIndex = 3
        Me.lblUsuario.Text = "Ingrese el Usuario:"
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtClave.Location = New System.Drawing.Point(122, 63)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 1
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtUsuario.Location = New System.Drawing.Point(122, 21)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizar.Location = New System.Drawing.Point(146, 95)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(75, 23)
        Me.btnAutorizar.TabIndex = 2
        Me.btnAutorizar.Text = "Autorizar"
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Facturacion_Autorizaciones
        '
        Me.AcceptButton = Me.btnAutorizar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 130)
        Me.Controls.Add(Me.grbGenerales)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Facturacion_Autorizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturacion_Autorizaciones"
        Me.grbGenerales.ResumeLayout(False)
        Me.grbGenerales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
End Class
