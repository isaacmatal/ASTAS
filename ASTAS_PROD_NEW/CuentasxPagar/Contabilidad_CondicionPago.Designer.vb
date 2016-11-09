<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CondicionPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CondicionPago))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TTBeneficiarios = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnLimpiarBeneficiarios = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbCompania = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCreditoDescripcion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCod = New System.Windows.Forms.TextBox
        Me.TxtDiasPago = New System.Windows.Forms.TextBox
        Me.DataGrid = New System.Windows.Forms.DataGridView
        Me.BtnActualizar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbFORMA_PAGO = New System.Windows.Forms.ComboBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "edittrash.gif")
        Me.ImageList1.Images.SetKeyName(1, "editdelete.gif")
        Me.ImageList1.Images.SetKeyName(2, "editshred.gif")
        Me.ImageList1.Images.SetKeyName(3, "edit.gif")
        Me.ImageList1.Images.SetKeyName(4, "fileclose.gif")
        Me.ImageList1.Images.SetKeyName(5, "filenew.gif")
        Me.ImageList1.Images.SetKeyName(6, "filesave.gif")
        Me.ImageList1.Images.SetKeyName(7, "filesaveas.gif")
        Me.ImageList1.Images.SetKeyName(8, "find.gif")
        Me.ImageList1.Images.SetKeyName(9, "reload_page.gif")
        Me.ImageList1.Images.SetKeyName(10, "search.gif")
        Me.ImageList1.Images.SetKeyName(11, "viewmag.gif")
        Me.ImageList1.Images.SetKeyName(12, "cancel.gif")
        Me.ImageList1.Images.SetKeyName(13, "button_cancel.gif")
        Me.ImageList1.Images.SetKeyName(14, "no.gif")
        Me.ImageList1.Images.SetKeyName(15, "down.gif")
        Me.ImageList1.Images.SetKeyName(16, "attach.gif")
        Me.ImageList1.Images.SetKeyName(17, "reload3.gif")
        '
        'TTBeneficiarios
        '
        Me.TTBeneficiarios.ToolTipTitle = "Condicion pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAgregar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(256, 72)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(72, 24)
        Me.BtnAgregar.TabIndex = 21
        Me.BtnAgregar.Text = "Guardar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TTBeneficiarios.SetToolTip(Me.BtnAgregar, "Guardar nueva Condición de Pago")
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(336, 72)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.BtnEliminar.TabIndex = 22
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TTBeneficiarios.SetToolTip(Me.BtnEliminar, "Elimina Condición de Pago seleccionada")
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnLimpiarBeneficiarios
        '
        Me.BtnLimpiarBeneficiarios.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnLimpiarBeneficiarios.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiarBeneficiarios.Image = CType(resources.GetObject("BtnLimpiarBeneficiarios.Image"), System.Drawing.Image)
        Me.BtnLimpiarBeneficiarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiarBeneficiarios.Location = New System.Drawing.Point(176, 72)
        Me.BtnLimpiarBeneficiarios.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnLimpiarBeneficiarios.Name = "BtnLimpiarBeneficiarios"
        Me.BtnLimpiarBeneficiarios.Size = New System.Drawing.Size(72, 24)
        Me.BtnLimpiarBeneficiarios.TabIndex = 20
        Me.BtnLimpiarBeneficiarios.Text = "Nuevo"
        Me.BtnLimpiarBeneficiarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TTBeneficiarios.SetToolTip(Me.BtnLimpiarBeneficiarios, "Limpia campos")
        Me.BtnLimpiarBeneficiarios.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'CmbCompania
        '
        Me.CmbCompania.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CmbCompania.ForeColor = System.Drawing.Color.Navy
        Me.CmbCompania.FormattingEnabled = True
        Me.CmbCompania.Location = New System.Drawing.Point(96, 24)
        Me.CmbCompania.Name = "CmbCompania"
        Me.CmbCompania.Size = New System.Drawing.Size(376, 24)
        Me.CmbCompania.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Condición Pago :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Días de Pago :"
        '
        'TxtCreditoDescripcion
        '
        Me.TxtCreditoDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCreditoDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCreditoDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.TxtCreditoDescripcion.Location = New System.Drawing.Point(96, 96)
        Me.TxtCreditoDescripcion.MaxLength = 50
        Me.TxtCreditoDescripcion.Name = "TxtCreditoDescripcion"
        Me.TxtCreditoDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCreditoDescripcion.Size = New System.Drawing.Size(376, 22)
        Me.TxtCreditoDescripcion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción :"
        '
        'TxtCod
        '
        Me.TxtCod.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCod.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod.ForeColor = System.Drawing.Color.Red
        Me.TxtCod.Location = New System.Drawing.Point(96, 74)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.ReadOnly = True
        Me.TxtCod.Size = New System.Drawing.Size(72, 22)
        Me.TxtCod.TabIndex = 7
        '
        'TxtDiasPago
        '
        Me.TxtDiasPago.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDiasPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiasPago.ForeColor = System.Drawing.Color.Navy
        Me.TxtDiasPago.Location = New System.Drawing.Point(96, 120)
        Me.TxtDiasPago.Name = "TxtDiasPago"
        Me.TxtDiasPago.Size = New System.Drawing.Size(72, 22)
        Me.TxtDiasPago.TabIndex = 21
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.AllowUserToResizeColumns = False
        Me.DataGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGrid.Location = New System.Drawing.Point(8, 168)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrid.Size = New System.Drawing.Size(592, 256)
        Me.DataGrid.TabIndex = 30
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnActualizar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizar.ImageKey = "reload3.gif"
        Me.BtnActualizar.ImageList = Me.ImageList1
        Me.BtnActualizar.Location = New System.Drawing.Point(376, 120)
        Me.BtnActualizar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(84, 24)
        Me.BtnActualizar.TabIndex = 23
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizar.UseVisualStyleBackColor = True
        Me.BtnActualizar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnActualizar)
        Me.GroupBox1.Controls.Add(Me.BtnLimpiarBeneficiarios)
        Me.GroupBox1.Controls.Add(Me.BtnEliminar)
        Me.GroupBox1.Controls.Add(Me.TxtDiasPago)
        Me.GroupBox1.Controls.Add(Me.BtnAgregar)
        Me.GroupBox1.Controls.Add(Me.TxtCod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtCreditoDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbFORMA_PAGO)
        Me.GroupBox1.Controls.Add(Me.CmbCompania)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 152)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Condiciones de Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Forma Pago :"
        '
        'cmbFORMA_PAGO
        '
        Me.cmbFORMA_PAGO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFORMA_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFORMA_PAGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbFORMA_PAGO.ForeColor = System.Drawing.Color.Navy
        Me.cmbFORMA_PAGO.FormattingEnabled = True
        Me.cmbFORMA_PAGO.Location = New System.Drawing.Point(96, 48)
        Me.cmbFORMA_PAGO.Name = "cmbFORMA_PAGO"
        Me.cmbFORMA_PAGO.Size = New System.Drawing.Size(152, 24)
        Me.cmbFORMA_PAGO.TabIndex = 1
        '
        'pbImagen
        '
        Me.pbImagen.Image = CType(resources.GetObject("pbImagen.Image"), System.Drawing.Image)
        Me.pbImagen.Location = New System.Drawing.Point(496, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(104, 152)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 60
        Me.pbImagen.TabStop = False
        '
        'Contabilidad_CondicionPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 427)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGrid)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_CondicionPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Catálogo de Condiciones de Pago"
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TTBeneficiarios As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbCompania As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCreditoDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtDiasPago As System.Windows.Forms.TextBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiarBeneficiarios As System.Windows.Forms.Button
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFORMA_PAGO As System.Windows.Forms.ComboBox
End Class
