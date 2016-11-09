<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Agregar_Bonificacion_Descuento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Agregar_Bonificacion_Descuento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txt_ValDescto = New System.Windows.Forms.TextBox
        Me.Txt_PorDescto = New System.Windows.Forms.TextBox
        Me.txtCOSTO_TOTAL = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPRODUCTO = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.txtDESCRIPCION_PRODUCTO = New System.Windows.Forms.TextBox
        Me.chkSERVICIO = New System.Windows.Forms.CheckBox
        Me.txtCANTIDAD = New System.Windows.Forms.TextBox
        Me.txtLIBRAS = New System.Windows.Forms.TextBox
        Me.txtCOSTO_UNITARIO = New System.Windows.Forms.TextBox
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.btnGuardarDetalle = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_ValDescto)
        Me.GroupBox1.Controls.Add(Me.Txt_PorDescto)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_TOTAL)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtPRODUCTO)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_PRODUCTO)
        Me.GroupBox1.Controls.Add(Me.chkSERVICIO)
        Me.GroupBox1.Controls.Add(Me.txtCANTIDAD)
        Me.GroupBox1.Controls.Add(Me.txtLIBRAS)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_UNITARIO)
        Me.GroupBox1.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.GroupBox1.Controls.Add(Me.btnGuardarDetalle)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(850, 70)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        '
        'Txt_ValDescto
        '
        Me.Txt_ValDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ValDescto.Enabled = False
        Me.Txt_ValDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_ValDescto.Location = New System.Drawing.Point(737, 31)
        Me.Txt_ValDescto.Name = "Txt_ValDescto"
        Me.Txt_ValDescto.Size = New System.Drawing.Size(64, 22)
        Me.Txt_ValDescto.TabIndex = 40
        Me.Txt_ValDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_PorDescto
        '
        Me.Txt_PorDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_PorDescto.Enabled = False
        Me.Txt_PorDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PorDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_PorDescto.Location = New System.Drawing.Point(693, 32)
        Me.Txt_PorDescto.Name = "Txt_PorDescto"
        Me.Txt_PorDescto.Size = New System.Drawing.Size(43, 22)
        Me.Txt_PorDescto.TabIndex = 39
        Me.Txt_PorDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCOSTO_TOTAL
        '
        Me.txtCOSTO_TOTAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_TOTAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_TOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_TOTAL.Location = New System.Drawing.Point(628, 32)
        Me.txtCOSTO_TOTAL.Name = "txtCOSTO_TOTAL"
        Me.txtCOSTO_TOTAL.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_TOTAL.TabIndex = 38
        Me.txtCOSTO_TOTAL.Text = "0.00"
        Me.txtCOSTO_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Teal
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(9, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(792, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = resources.GetString("Label14.Text")
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPRODUCTO
        '
        Me.txtPRODUCTO.BackColor = System.Drawing.Color.White
        Me.txtPRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRODUCTO.ForeColor = System.Drawing.Color.Red
        Me.txtPRODUCTO.Location = New System.Drawing.Point(9, 32)
        Me.txtPRODUCTO.Name = "txtPRODUCTO"
        Me.txtPRODUCTO.Size = New System.Drawing.Size(64, 22)
        Me.txtPRODUCTO.TabIndex = 19
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(73, 32)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 30
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION_PRODUCTO
        '
        Me.txtDESCRIPCION_PRODUCTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_PRODUCTO.Enabled = False
        Me.txtDESCRIPCION_PRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_PRODUCTO.Location = New System.Drawing.Point(97, 32)
        Me.txtDESCRIPCION_PRODUCTO.Name = "txtDESCRIPCION_PRODUCTO"
        Me.txtDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(266, 22)
        Me.txtDESCRIPCION_PRODUCTO.TabIndex = 21
        '
        'chkSERVICIO
        '
        Me.chkSERVICIO.AutoSize = True
        Me.chkSERVICIO.Checked = True
        Me.chkSERVICIO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSERVICIO.Enabled = False
        Me.chkSERVICIO.Location = New System.Drawing.Point(605, 36)
        Me.chkSERVICIO.Name = "chkSERVICIO"
        Me.chkSERVICIO.Size = New System.Drawing.Size(15, 14)
        Me.chkSERVICIO.TabIndex = 37
        Me.chkSERVICIO.UseVisualStyleBackColor = True
        '
        'txtCANTIDAD
        '
        Me.txtCANTIDAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCANTIDAD.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCANTIDAD.ForeColor = System.Drawing.Color.Navy
        Me.txtCANTIDAD.Location = New System.Drawing.Point(458, 32)
        Me.txtCANTIDAD.Name = "txtCANTIDAD"
        Me.txtCANTIDAD.Size = New System.Drawing.Size(71, 22)
        Me.txtCANTIDAD.TabIndex = 23
        Me.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLIBRAS
        '
        Me.txtLIBRAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIBRAS.Enabled = False
        Me.txtLIBRAS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIBRAS.ForeColor = System.Drawing.Color.Navy
        Me.txtLIBRAS.Location = New System.Drawing.Point(462, 32)
        Me.txtLIBRAS.Name = "txtLIBRAS"
        Me.txtLIBRAS.Size = New System.Drawing.Size(64, 22)
        Me.txtLIBRAS.TabIndex = 24
        Me.txtLIBRAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLIBRAS.Visible = False
        '
        'txtCOSTO_UNITARIO
        '
        Me.txtCOSTO_UNITARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_UNITARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_UNITARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_UNITARIO.Location = New System.Drawing.Point(530, 32)
        Me.txtCOSTO_UNITARIO.Name = "txtCOSTO_UNITARIO"
        Me.txtCOSTO_UNITARIO.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_UNITARIO.TabIndex = 25
        Me.txtCOSTO_UNITARIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbUNIDAD_MEDIDA
        '
        Me.cmbUNIDAD_MEDIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUNIDAD_MEDIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUNIDAD_MEDIDA.Enabled = False
        Me.cmbUNIDAD_MEDIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUNIDAD_MEDIDA.ForeColor = System.Drawing.Color.Black
        Me.cmbUNIDAD_MEDIDA.FormattingEnabled = True
        Me.cmbUNIDAD_MEDIDA.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(363, 32)
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(94, 24)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 33
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(807, 12)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(33, 35)
        Me.btnGuardarDetalle.TabIndex = 26
        Me.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'Inventario_Agregar_Bonificacion_Descuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 72)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Inventario_Agregar_Bonificacion_Descuento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulario de Ingreso de Bonificaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_ValDescto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PorDescto As System.Windows.Forms.TextBox
    Friend WithEvents txtCOSTO_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents chkSERVICIO As System.Windows.Forms.CheckBox
    Friend WithEvents txtCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents txtLIBRAS As System.Windows.Forms.TextBox
    Friend WithEvents txtCOSTO_UNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
End Class
