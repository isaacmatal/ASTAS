<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperativa_Origenes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV_Datos = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.PbImagen = New System.Windows.Forms.PictureBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtDivision
        '
        Me.TxtDivision.Location = New System.Drawing.Point(209, 44)
        Me.TxtDivision.MaxLength = 50
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.Size = New System.Drawing.Size(346, 20)
        Me.TxtDivision.TabIndex = 47
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(209, 18)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(79, 20)
        Me.TxtCodigo.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Origen:"
        '
        'DGV_Datos
        '
        Me.DGV_Datos.AllowUserToAddRows = False
        Me.DGV_Datos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DGV_Datos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Datos.BackgroundColor = System.Drawing.Color.White
        Me.DGV_Datos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGV_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Datos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Datos.Location = New System.Drawing.Point(0, 165)
        Me.DGV_Datos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGV_Datos.Name = "DGV_Datos"
        Me.DGV_Datos.ReadOnly = True
        Me.DGV_Datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_Datos.Size = New System.Drawing.Size(717, 247)
        Me.DGV_Datos.TabIndex = 44
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.PbImagen)
        Me.GroupBox4.Controls.Add(Me.BtnEliminar)
        Me.GroupBox4.Controls.Add(Me.TxtDivision)
        Me.GroupBox4.Controls.Add(Me.TxtCodigo)
        Me.GroupBox4.Controls.Add(Me.BtnAgregar)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox4.Size = New System.Drawing.Size(717, 165)
        Me.GroupBox4.TabIndex = 43
        Me.GroupBox4.TabStop = False
        '
        'PbImagen
        '
        Me.PbImagen.Location = New System.Drawing.Point(5, 12)
        Me.PbImagen.Name = "PbImagen"
        Me.PbImagen.Size = New System.Drawing.Size(121, 147)
        Me.PbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbImagen.TabIndex = 48
        Me.PbImagen.TabStop = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(209, 121)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(66, 32)
        Me.BtnEliminar.TabIndex = 22
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(281, 121)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(66, 32)
        Me.BtnAgregar.TabIndex = 21
        Me.BtnAgregar.Text = "Guardar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(137, 121)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(66, 32)
        Me.BtnLimpiar.TabIndex = 20
        Me.BtnLimpiar.Text = "Nuevo"
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Descripcion:"
        '
        'Cooperativa_Origenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(717, 412)
        Me.Controls.Add(Me.DGV_Datos)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "Cooperativa_Origenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa_Origenes"
        CType(Me.DGV_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Datos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
