<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Catalogo_Plantas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Catalogo_Plantas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.gbAperturaCaja = New System.Windows.Forms.GroupBox
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.numeroPlanta = New System.Windows.Forms.TextBox
        Me.lblDineroInicial = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gridPlantas = New System.Windows.Forms.DataGridView
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAperturaCaja.SuspendLayout()
        CType(Me.gridPlantas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(6, 19)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(161, 142)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 83
        Me.pbImagen.TabStop = False
        '
        'gbAperturaCaja
        '
        Me.gbAperturaCaja.BackgroundImage = CType(resources.GetObject("gbAperturaCaja.BackgroundImage"), System.Drawing.Image)
        Me.gbAperturaCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gbAperturaCaja.Controls.Add(Me.txtCompañia)
        Me.gbAperturaCaja.Controls.Add(Me.Label5)
        Me.gbAperturaCaja.Controls.Add(Me.pbImagen)
        Me.gbAperturaCaja.Controls.Add(Me.btnLimpiar)
        Me.gbAperturaCaja.Controls.Add(Me.btnGuardar)
        Me.gbAperturaCaja.Controls.Add(Me.btnEliminar)
        Me.gbAperturaCaja.Controls.Add(Me.Descripcion)
        Me.gbAperturaCaja.Controls.Add(Me.Label2)
        Me.gbAperturaCaja.Controls.Add(Me.numeroPlanta)
        Me.gbAperturaCaja.Controls.Add(Me.lblDineroInicial)
        Me.gbAperturaCaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbAperturaCaja.Location = New System.Drawing.Point(0, 0)
        Me.gbAperturaCaja.Name = "gbAperturaCaja"
        Me.gbAperturaCaja.Size = New System.Drawing.Size(843, 174)
        Me.gbAperturaCaja.TabIndex = 82
        Me.gbAperturaCaja.TabStop = False
        Me.gbAperturaCaja.Text = "Detalles de Plantas"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(284, 93)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 24)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(365, 93)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 24)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(446, 93)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 24)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'Descripcion
        '
        Me.Descripcion.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion.Location = New System.Drawing.Point(284, 67)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(506, 20)
        Me.Descripcion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(180, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Nombre de planta:"
        '
        'numeroPlanta
        '
        Me.numeroPlanta.BackColor = System.Drawing.Color.SteelBlue
        Me.numeroPlanta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numeroPlanta.Location = New System.Drawing.Point(284, 41)
        Me.numeroPlanta.Name = "numeroPlanta"
        Me.numeroPlanta.Size = New System.Drawing.Size(101, 20)
        Me.numeroPlanta.TabIndex = 2
        '
        'lblDineroInicial
        '
        Me.lblDineroInicial.AutoSize = True
        Me.lblDineroInicial.BackColor = System.Drawing.Color.Transparent
        Me.lblDineroInicial.Location = New System.Drawing.Point(180, 44)
        Me.lblDineroInicial.Name = "lblDineroInicial"
        Me.lblDineroInicial.Size = New System.Drawing.Size(40, 13)
        Me.lblDineroInicial.TabIndex = 16
        Me.lblDineroInicial.Text = "Planta:"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.SteelBlue
        Me.txtCompañia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompañia.Location = New System.Drawing.Point(284, 15)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(506, 20)
        Me.txtCompañia.TabIndex = 138
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(180, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Compañía :"
        '
        'gridPlantas
        '
        Me.gridPlantas.AllowUserToAddRows = False
        Me.gridPlantas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridPlantas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridPlantas.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPlantas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridPlantas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPlantas.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridPlantas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPlantas.Location = New System.Drawing.Point(0, 174)
        Me.gridPlantas.Name = "gridPlantas"
        Me.gridPlantas.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPlantas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridPlantas.RowHeadersVisible = False
        Me.gridPlantas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPlantas.Size = New System.Drawing.Size(843, 243)
        Me.gridPlantas.TabIndex = 83
        '
        'Cafeteria_Catalogo_Plantas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(843, 417)
        Me.Controls.Add(Me.gridPlantas)
        Me.Controls.Add(Me.gbAperturaCaja)
        Me.Name = "Cafeteria_Catalogo_Plantas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Catalogo_Plantas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAperturaCaja.ResumeLayout(False)
        Me.gbAperturaCaja.PerformLayout()
        CType(Me.gridPlantas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents gbAperturaCaja As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numeroPlanta As System.Windows.Forms.TextBox
    Friend WithEvents lblDineroInicial As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gridPlantas As System.Windows.Forms.DataGridView
End Class
