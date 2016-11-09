<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManSeguro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManSeguro))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.ChxEstado = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.CbxDeduccion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtCorrelativo = New System.Windows.Forms.TextBox
        Me.TxtInteres = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DgvSegDeuda = New System.Windows.Forms.DataGridView
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GbxDatos.SuspendLayout()
        CType(Me.DgvSegDeuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxDatos
        '
        Me.GbxDatos.Controls.Add(Me.ChxEstado)
        Me.GbxDatos.Controls.Add(Me.Label5)
        Me.GbxDatos.Controls.Add(Me.Label7)
        Me.GbxDatos.Controls.Add(Me.BtnEliminar)
        Me.GbxDatos.Controls.Add(Me.BtnNuevo)
        Me.GbxDatos.Controls.Add(Me.BtnGuardar)
        Me.GbxDatos.Controls.Add(Me.CbxDeduccion)
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Controls.Add(Me.CbxCompania)
        Me.GbxDatos.Controls.Add(Me.Label6)
        Me.GbxDatos.Controls.Add(Me.TxtCorrelativo)
        Me.GbxDatos.Controls.Add(Me.TxtInteres)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(104, 8)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Size = New System.Drawing.Size(488, 128)
        Me.GbxDatos.TabIndex = 10
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Registro de Deducciones"
        '
        'ChxEstado
        '
        Me.ChxEstado.AutoSize = True
        Me.ChxEstado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxEstado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChxEstado.Location = New System.Drawing.Point(80, 96)
        Me.ChxEstado.Name = "ChxEstado"
        Me.ChxEstado.Size = New System.Drawing.Size(55, 20)
        Me.ChxEstado.TabIndex = 69
        Me.ChxEstado.Text = "Activo"
        Me.ChxEstado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(304, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Interés Seguro deuda:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Estado:"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(192, 72)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.BtnEliminar.TabIndex = 6
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNuevo.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(144, 72)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.BtnNuevo.TabIndex = 7
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(168, 72)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'CbxDeduccion
        '
        Me.CbxDeduccion.BackColor = System.Drawing.SystemColors.Window
        Me.CbxDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDeduccion.ForeColor = System.Drawing.Color.Navy
        Me.CbxDeduccion.FormattingEnabled = True
        Me.CbxDeduccion.Location = New System.Drawing.Point(80, 48)
        Me.CbxDeduccion.Name = "CbxDeduccion"
        Me.CbxDeduccion.Size = New System.Drawing.Size(227, 24)
        Me.CbxDeduccion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Deducción:"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(80, 24)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(392, 24)
        Me.CbxCompania.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Compañía:"
        '
        'TxtCorrelativo
        '
        Me.TxtCorrelativo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCorrelativo.Enabled = False
        Me.TxtCorrelativo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCorrelativo.ForeColor = System.Drawing.Color.Red
        Me.TxtCorrelativo.Location = New System.Drawing.Point(80, 72)
        Me.TxtCorrelativo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCorrelativo.MaxLength = 100
        Me.TxtCorrelativo.Name = "TxtCorrelativo"
        Me.TxtCorrelativo.Size = New System.Drawing.Size(64, 22)
        Me.TxtCorrelativo.TabIndex = 3
        Me.TxtCorrelativo.Text = "0"
        Me.TxtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtInteres
        '
        Me.TxtInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteres.ForeColor = System.Drawing.Color.Navy
        Me.TxtInteres.Location = New System.Drawing.Point(416, 96)
        Me.TxtInteres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtInteres.MaxLength = 5
        Me.TxtInteres.Name = "TxtInteres"
        Me.TxtInteres.Size = New System.Drawing.Size(56, 22)
        Me.TxtInteres.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Correlativo:"
        '
        'DgvSegDeuda
        '
        Me.DgvSegDeuda.AllowUserToAddRows = False
        Me.DgvSegDeuda.AllowUserToDeleteRows = False
        Me.DgvSegDeuda.AllowUserToResizeColumns = False
        Me.DgvSegDeuda.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSegDeuda.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSegDeuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSegDeuda.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSegDeuda.Location = New System.Drawing.Point(8, 144)
        Me.DgvSegDeuda.MultiSelect = False
        Me.DgvSegDeuda.Name = "DgvSegDeuda"
        Me.DgvSegDeuda.ReadOnly = True
        Me.DgvSegDeuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSegDeuda.Size = New System.Drawing.Size(584, 288)
        Me.DgvSegDeuda.TabIndex = 11
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(8, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(88, 128)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 12
        Me.pbImagen.TabStop = False
        '
        'FrmManSeguro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(598, 437)
        Me.Controls.Add(Me.GbxDatos)
        Me.Controls.Add(Me.DgvSegDeuda)
        Me.Controls.Add(Me.pbImagen)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmManSeguro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Catálogo  Seguro de Deducciones"
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        CType(Me.DgvSegDeuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents TxtInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgvSegDeuda As System.Windows.Forms.DataGridView
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents CbxDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChxEstado As System.Windows.Forms.CheckBox
End Class
