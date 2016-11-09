
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_aplicar_DescuentoOC
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




    Public Sub New(ByVal pOC As Integer, ByVal PIDcompania As Integer, ByVal idpbodega As Integer, ByVal pidLinea As Integer, _
    ByVal Codigo As String, ByVal descripcion As String, ByVal cantidad As Double, ByVal costounit As Double, ByVal total As Double)
        intpOC = pOC
        intpCompania = PIDcompania
        intpbodega = idpbodega
        intlinea = pidLinea
        '
        strCodigo = Codigo
        strDescripcion = descripcion
        dblCantidad = cantidad
        dblCostoUni = costounit
        dblTotal = total
        InitializeComponent()

    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txt_ValDescto = New System.Windows.Forms.TextBox
        Me.Txt_PorDescto = New System.Windows.Forms.TextBox
        Me.txtCOSTO_TOTAL = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPRODUCTO = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION_PRODUCTO = New System.Windows.Forms.TextBox
        Me.txtCANTIDAD = New System.Windows.Forms.TextBox
        Me.txtCOSTO_UNITARIO = New System.Windows.Forms.TextBox
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txt_ValDescto)
        Me.GroupBox1.Controls.Add(Me.Txt_PorDescto)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_TOTAL)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtPRODUCTO)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_PRODUCTO)
        Me.GroupBox1.Controls.Add(Me.txtCANTIDAD)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_UNITARIO)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(805, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Txt_ValDescto
        '
        Me.Txt_ValDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ValDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_ValDescto.Location = New System.Drawing.Point(661, 31)
        Me.Txt_ValDescto.Name = "Txt_ValDescto"
        Me.Txt_ValDescto.Size = New System.Drawing.Size(64, 22)
        Me.Txt_ValDescto.TabIndex = 2
        Me.Txt_ValDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_PorDescto
        '
        Me.Txt_PorDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_PorDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PorDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_PorDescto.Location = New System.Drawing.Point(603, 31)
        Me.Txt_PorDescto.Name = "Txt_PorDescto"
        Me.Txt_PorDescto.Size = New System.Drawing.Size(43, 22)
        Me.Txt_PorDescto.TabIndex = 1
        Me.Txt_PorDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCOSTO_TOTAL
        '
        Me.txtCOSTO_TOTAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_TOTAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_TOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_TOTAL.Location = New System.Drawing.Point(516, 31)
        Me.txtCOSTO_TOTAL.Name = "txtCOSTO_TOTAL"
        Me.txtCOSTO_TOTAL.ReadOnly = True
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
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(-38, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(779, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPRODUCTO
        '
        Me.txtPRODUCTO.BackColor = System.Drawing.Color.White
        Me.txtPRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRODUCTO.ForeColor = System.Drawing.Color.Red
        Me.txtPRODUCTO.Location = New System.Drawing.Point(9, 32)
        Me.txtPRODUCTO.Name = "txtPRODUCTO"
        Me.txtPRODUCTO.ReadOnly = True
        Me.txtPRODUCTO.Size = New System.Drawing.Size(64, 22)
        Me.txtPRODUCTO.TabIndex = 19
        '
        'txtDESCRIPCION_PRODUCTO
        '
        Me.txtDESCRIPCION_PRODUCTO.BackColor = System.Drawing.Color.White
        Me.txtDESCRIPCION_PRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_PRODUCTO.Location = New System.Drawing.Point(79, 32)
        Me.txtDESCRIPCION_PRODUCTO.Name = "txtDESCRIPCION_PRODUCTO"
        Me.txtDESCRIPCION_PRODUCTO.ReadOnly = True
        Me.txtDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(266, 22)
        Me.txtDESCRIPCION_PRODUCTO.TabIndex = 21
        '
        'txtCANTIDAD
        '
        Me.txtCANTIDAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCANTIDAD.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCANTIDAD.ForeColor = System.Drawing.Color.Navy
        Me.txtCANTIDAD.Location = New System.Drawing.Point(351, 32)
        Me.txtCANTIDAD.Name = "txtCANTIDAD"
        Me.txtCANTIDAD.ReadOnly = True
        Me.txtCANTIDAD.Size = New System.Drawing.Size(71, 22)
        Me.txtCANTIDAD.TabIndex = 23
        Me.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCOSTO_UNITARIO
        '
        Me.txtCOSTO_UNITARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_UNITARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_UNITARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_UNITARIO.Location = New System.Drawing.Point(435, 32)
        Me.txtCOSTO_UNITARIO.Name = "txtCOSTO_UNITARIO"
        Me.txtCOSTO_UNITARIO.ReadOnly = True
        Me.txtCOSTO_UNITARIO.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_UNITARIO.TabIndex = 25
        Me.txtCOSTO_UNITARIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAplicar
        '
        Me.btnAplicar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAplicar.Location = New System.Drawing.Point(745, 24)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(58, 28)
        Me.btnAplicar.TabIndex = 3
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(19, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(167, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(354, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(424, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Prec .Unitario"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(528, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(598, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "% Desc."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(656, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Descuento"
        '
        'Inventario_aplicar_DescuentoOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 72)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Inventario_aplicar_DescuentoOC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicar Descuento"
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
    Friend WithEvents txtDESCRIPCION_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents txtCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents txtCOSTO_UNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
