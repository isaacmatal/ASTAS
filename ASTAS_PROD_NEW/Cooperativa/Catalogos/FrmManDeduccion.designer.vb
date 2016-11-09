<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManDeduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManDeduccion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.txtSegDeuda = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblNombreEmpresa = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.TxtCuentade = New System.Windows.Forms.TextBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.CbxLibroContable = New System.Windows.Forms.ComboBox
        Me.BtnBuscarCuenta = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtInteresDeuda = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCuentaCont = New System.Windows.Forms.TextBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.TxtCodigoDeducc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DgvDeducciones = New System.Windows.Forms.DataGridView
        Me.GbxDatos.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxDatos
        '
        Me.GbxDatos.BackColor = System.Drawing.Color.Transparent
        Me.GbxDatos.Controls.Add(Me.pbImagen)
        Me.GbxDatos.Controls.Add(Me.txtSegDeuda)
        Me.GbxDatos.Controls.Add(Me.Label7)
        Me.GbxDatos.Controls.Add(Me.lblNombreEmpresa)
        Me.GbxDatos.Controls.Add(Me.lblCodigo)
        Me.GbxDatos.Controls.Add(Me.TxtCuentade)
        Me.GbxDatos.Controls.Add(Me.BtnEliminar)
        Me.GbxDatos.Controls.Add(Me.BtnNuevo)
        Me.GbxDatos.Controls.Add(Me.BtnGuardar)
        Me.GbxDatos.Controls.Add(Me.CbxLibroContable)
        Me.GbxDatos.Controls.Add(Me.BtnBuscarCuenta)
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Controls.Add(Me.Label6)
        Me.GbxDatos.Controls.Add(Me.TxtInteresDeuda)
        Me.GbxDatos.Controls.Add(Me.Label5)
        Me.GbxDatos.Controls.Add(Me.TxtCuentaCont)
        Me.GbxDatos.Controls.Add(Me.TxtDescripcion)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoDeducc)
        Me.GbxDatos.Controls.Add(Me.Label4)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.GbxDatos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(0, 0)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Size = New System.Drawing.Size(906, 178)
        Me.GbxDatos.TabIndex = 2
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Registro de Deducciones"
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(12, 16)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(136, 156)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 9
        Me.pbImagen.TabStop = False
        '
        'txtSegDeuda
        '
        Me.txtSegDeuda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSegDeuda.ForeColor = System.Drawing.Color.Navy
        Me.txtSegDeuda.Location = New System.Drawing.Point(596, 141)
        Me.txtSegDeuda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSegDeuda.MaxLength = 5
        Me.txtSegDeuda.Name = "txtSegDeuda"
        Me.txtSegDeuda.Size = New System.Drawing.Size(104, 22)
        Me.txtSegDeuda.TabIndex = 16
        Me.txtSegDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(463, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Interés Seguro de deuda:"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(250, 16)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(57, 15)
        Me.lblNombreEmpresa.TabIndex = 1
        Me.lblNombreEmpresa.Text = "Compañia"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodigo.Location = New System.Drawing.Point(358, 144)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(14, 16)
        Me.lblCodigo.TabIndex = 14
        Me.lblCodigo.Text = "1"
        Me.lblCodigo.Visible = False
        '
        'TxtCuentade
        '
        Me.TxtCuentade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCuentade.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TxtCuentade.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuentade.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuentade.Location = New System.Drawing.Point(378, 114)
        Me.TxtCuentade.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuentade.MaxLength = 5
        Me.TxtCuentade.Name = "TxtCuentade"
        Me.TxtCuentade.ReadOnly = True
        Me.TxtCuentade.Size = New System.Drawing.Size(322, 22)
        Me.TxtCuentade.TabIndex = 11
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(706, 66)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.BtnEliminar.TabIndex = 6
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNuevo.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(706, 89)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.BtnNuevo.TabIndex = 7
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(706, 113)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'CbxLibroContable
        '
        Me.CbxLibroContable.BackColor = System.Drawing.SystemColors.Window
        Me.CbxLibroContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxLibroContable.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxLibroContable.ForeColor = System.Drawing.Color.Navy
        Me.CbxLibroContable.FormattingEnabled = True
        Me.CbxLibroContable.Location = New System.Drawing.Point(250, 90)
        Me.CbxLibroContable.Name = "CbxLibroContable"
        Me.CbxLibroContable.Size = New System.Drawing.Size(288, 24)
        Me.CbxLibroContable.TabIndex = 7
        '
        'BtnBuscarCuenta
        '
        Me.BtnBuscarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBuscarCuenta.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarCuenta.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarCuenta.Image = CType(resources.GetObject("BtnBuscarCuenta.Image"), System.Drawing.Image)
        Me.BtnBuscarCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCuenta.Location = New System.Drawing.Point(354, 114)
        Me.BtnBuscarCuenta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarCuenta.Name = "BtnBuscarCuenta"
        Me.BtnBuscarCuenta.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarCuenta.TabIndex = 10
        Me.BtnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(154, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Libro Contable :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(154, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Compañía:"
        '
        'TxtInteresDeuda
        '
        Me.TxtInteresDeuda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresDeuda.ForeColor = System.Drawing.Color.Navy
        Me.TxtInteresDeuda.Location = New System.Drawing.Point(250, 141)
        Me.TxtInteresDeuda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtInteresDeuda.MaxLength = 5
        Me.TxtInteresDeuda.Name = "TxtInteresDeuda"
        Me.TxtInteresDeuda.Size = New System.Drawing.Size(104, 22)
        Me.TxtInteresDeuda.TabIndex = 13
        Me.TxtInteresDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(154, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Interés deuda:"
        '
        'TxtCuentaCont
        '
        Me.TxtCuentaCont.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TxtCuentaCont.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuentaCont.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuentaCont.Location = New System.Drawing.Point(250, 114)
        Me.TxtCuentaCont.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuentaCont.Name = "TxtCuentaCont"
        Me.TxtCuentaCont.ReadOnly = True
        Me.TxtCuentaCont.Size = New System.Drawing.Size(104, 22)
        Me.TxtCuentaCont.TabIndex = 9
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.TxtDescripcion.Location = New System.Drawing.Point(250, 66)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtDescripcion.MaxLength = 100
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(450, 22)
        Me.TxtDescripcion.TabIndex = 5
        '
        'TxtCodigoDeducc
        '
        Me.TxtCodigoDeducc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCodigoDeducc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoDeducc.ForeColor = System.Drawing.Color.Red
        Me.TxtCodigoDeducc.Location = New System.Drawing.Point(250, 42)
        Me.TxtCodigoDeducc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoDeducc.MaxLength = 5
        Me.TxtCodigoDeducc.Name = "TxtCodigoDeducc"
        Me.TxtCodigoDeducc.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoDeducc.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(154, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cuenta Contable:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(154, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(154, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código deducción:"
        '
        'DgvDeducciones
        '
        Me.DgvDeducciones.AllowUserToAddRows = False
        Me.DgvDeducciones.AllowUserToDeleteRows = False
        Me.DgvDeducciones.AllowUserToResizeColumns = False
        Me.DgvDeducciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvDeducciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDeducciones.BackgroundColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDeducciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDeducciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvDeducciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDeducciones.Location = New System.Drawing.Point(0, 178)
        Me.DgvDeducciones.MultiSelect = False
        Me.DgvDeducciones.Name = "DgvDeducciones"
        Me.DgvDeducciones.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDeducciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvDeducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDeducciones.Size = New System.Drawing.Size(906, 308)
        Me.DgvDeducciones.TabIndex = 8
        '
        'FrmManDeduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 486)
        Me.Controls.Add(Me.DgvDeducciones)
        Me.Controls.Add(Me.GbxDatos)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmManDeduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  "
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TxtInteresDeuda As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaCont As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoDeducc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DgvDeducciones As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents CbxLibroContable As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentade As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombreEmpresa As System.Windows.Forms.Label
    Friend WithEvents txtSegDeuda As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
