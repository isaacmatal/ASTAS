<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_TipoDocumento
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_TipoDocumento))
        Me.dgvTipoDocumento = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Identificador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Documento_Contable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Chb_Requiere_documento = New System.Windows.Forms.CheckBox
        Me.Chb_Requiere_costo = New System.Windows.Forms.CheckBox
        Me.cmbES = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbDOCUMENTO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.txtIDENTIFICADOR = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_TIPO_DOCUMENTO = New System.Windows.Forms.TextBox
        Me.lblTIPO_DOCUMENTO = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvTipoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTipoDocumento
        '
        Me.dgvTipoDocumento.AllowUserToAddRows = False
        Me.dgvTipoDocumento.AllowUserToDeleteRows = False
        Me.dgvTipoDocumento.AllowUserToResizeColumns = False
        Me.dgvTipoDocumento.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvTipoDocumento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTipoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoDocumento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Identificador, Me.DataGridViewTextBoxColumn3, Me.Documento_Contable, Me.DataGridViewTextBoxColumn5, Me.Column1})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoDocumento.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvTipoDocumento.Location = New System.Drawing.Point(4, 172)
        Me.dgvTipoDocumento.Name = "dgvTipoDocumento"
        Me.dgvTipoDocumento.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoDocumento.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTipoDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoDocumento.Size = New System.Drawing.Size(614, 240)
        Me.dgvTipoDocumento.TabIndex = 12
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tipo Documento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Identificador
        '
        Me.Identificador.HeaderText = "Identificador"
        Me.Identificador.Name = "Identificador"
        Me.Identificador.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Documento_Contable
        '
        Me.Documento_Contable.HeaderText = "Documento Contable"
        Me.Documento_Contable.Name = "Documento_Contable"
        Me.Documento_Contable.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn5.HeaderText = "Usuario Creación"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Fecha Creación"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(4, 6)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(104, 160)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 13
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.Chb_Requiere_documento)
        Me.GroupBox1.Controls.Add(Me.Chb_Requiere_costo)
        Me.GroupBox1.Controls.Add(Me.cmbES)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbDOCUMENTO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.txtIDENTIFICADOR)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_TIPO_DOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.lblTIPO_DOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(114, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 155)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(118, 24)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(375, 22)
        Me.txtCompañia.TabIndex = 98
        '
        'Chb_Requiere_documento
        '
        Me.Chb_Requiere_documento.AutoSize = True
        Me.Chb_Requiere_documento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Chb_Requiere_documento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Chb_Requiere_documento.Location = New System.Drawing.Point(318, 124)
        Me.Chb_Requiere_documento.Name = "Chb_Requiere_documento"
        Me.Chb_Requiere_documento.Size = New System.Drawing.Size(127, 20)
        Me.Chb_Requiere_documento.TabIndex = 6
        Me.Chb_Requiere_documento.Text = "Requiere Documento"
        Me.Chb_Requiere_documento.UseVisualStyleBackColor = True
        '
        'Chb_Requiere_costo
        '
        Me.Chb_Requiere_costo.AutoSize = True
        Me.Chb_Requiere_costo.Enabled = False
        Me.Chb_Requiere_costo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Chb_Requiere_costo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Chb_Requiere_costo.Location = New System.Drawing.Point(318, 97)
        Me.Chb_Requiere_costo.Name = "Chb_Requiere_costo"
        Me.Chb_Requiere_costo.Size = New System.Drawing.Size(98, 20)
        Me.Chb_Requiere_costo.TabIndex = 5
        Me.Chb_Requiere_costo.Text = "Requiere costo"
        Me.Chb_Requiere_costo.UseVisualStyleBackColor = True
        '
        'cmbES
        '
        Me.cmbES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbES.FormattingEnabled = True
        Me.cmbES.Items.AddRange(New Object() {"Entrada", "Salida"})
        Me.cmbES.Location = New System.Drawing.Point(192, 122)
        Me.cmbES.Name = "cmbES"
        Me.cmbES.Size = New System.Drawing.Size(120, 24)
        Me.cmbES.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Documento Contable"
        '
        'cmbDOCUMENTO_CONTABLE
        '
        Me.cmbDOCUMENTO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDOCUMENTO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDOCUMENTO_CONTABLE.FormattingEnabled = True
        Me.cmbDOCUMENTO_CONTABLE.Location = New System.Drawing.Point(118, 95)
        Me.cmbDOCUMENTO_CONTABLE.Name = "cmbDOCUMENTO_CONTABLE"
        Me.cmbDOCUMENTO_CONTABLE.Size = New System.Drawing.Size(194, 24)
        Me.cmbDOCUMENTO_CONTABLE.TabIndex = 2
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(192, 48)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtIDENTIFICADOR
        '
        Me.txtIDENTIFICADOR.BackColor = System.Drawing.SystemColors.Window
        Me.txtIDENTIFICADOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDENTIFICADOR.ForeColor = System.Drawing.Color.Navy
        Me.txtIDENTIFICADOR.Location = New System.Drawing.Point(118, 122)
        Me.txtIDENTIFICADOR.MaxLength = 2
        Me.txtIDENTIFICADOR.Name = "txtIDENTIFICADOR"
        Me.txtIDENTIFICADOR.Size = New System.Drawing.Size(72, 22)
        Me.txtIDENTIFICADOR.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Identificador"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(216, 48)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(240, 48)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Descripción"
        '
        'txtDESCRIPCION_TIPO_DOCUMENTO
        '
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Location = New System.Drawing.Point(118, 72)
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Name = "txtDESCRIPCION_TIPO_DOCUMENTO"
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Size = New System.Drawing.Size(376, 22)
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.TabIndex = 1
        '
        'lblTIPO_DOCUMENTO
        '
        Me.lblTIPO_DOCUMENTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTIPO_DOCUMENTO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Red
        Me.lblTIPO_DOCUMENTO.Location = New System.Drawing.Point(118, 49)
        Me.lblTIPO_DOCUMENTO.Name = "lblTIPO_DOCUMENTO"
        Me.lblTIPO_DOCUMENTO.Size = New System.Drawing.Size(72, 22)
        Me.lblTIPO_DOCUMENTO.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tipo Documento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Compañía"
        '
        'Inventario_TipoDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 414)
        Me.Controls.Add(Me.dgvTipoDocumento)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_TipoDocumento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Inventario - Tipo Documento"
        CType(Me.dgvTipoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvTipoDocumento As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Identificador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento_Contable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbDOCUMENTO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtIDENTIFICADOR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_TIPO_DOCUMENTO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTIPO_DOCUMENTO As System.Windows.Forms.Label
    Friend WithEvents cmbES As System.Windows.Forms.ComboBox
    Friend WithEvents Chb_Requiere_costo As System.Windows.Forms.CheckBox
    Friend WithEvents Chb_Requiere_documento As System.Windows.Forms.CheckBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
End Class
