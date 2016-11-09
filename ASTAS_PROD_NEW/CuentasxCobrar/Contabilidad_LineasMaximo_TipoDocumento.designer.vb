<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_LineasMaximo_TipoDocumento
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_LineasMaximo_TipoDocumento))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.BarraEstado1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.btnEliminarLinea = New System.Windows.Forms.Button
        Me.btnNuevaLinea = New System.Windows.Forms.Button
        Me.btnBuscarLinea = New System.Windows.Forms.Button
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineasMaximo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerieFacturas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvLineas = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbSERIE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLineas = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbDG = New System.Windows.Forms.GroupBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.lblLibreSiNo = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDG.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarraEstado1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 416)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(817, 22)
        Me.StatusStrip1.TabIndex = 95
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BarraEstado1
        '
        Me.BarraEstado1.Name = "BarraEstado1"
        Me.BarraEstado1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolTip1
        '
        Me.ToolTip1.Tag = ""
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarLinea.Image = CType(resources.GetObject("btnGuardarLinea.Image"), System.Drawing.Image)
        Me.btnGuardarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarLinea.Location = New System.Drawing.Point(504, 79)
        Me.btnGuardarLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(25, 25)
        Me.btnGuardarLinea.TabIndex = 5
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarLinea, "Guarda o Actualiza un máximo de líneas")
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'btnEliminarLinea
        '
        Me.btnEliminarLinea.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminarLinea.ForeColor = System.Drawing.Color.Black
        Me.btnEliminarLinea.Image = CType(resources.GetObject("btnEliminarLinea.Image"), System.Drawing.Image)
        Me.btnEliminarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarLinea.Location = New System.Drawing.Point(528, 79)
        Me.btnEliminarLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEliminarLinea.Name = "btnEliminarLinea"
        Me.btnEliminarLinea.Size = New System.Drawing.Size(25, 25)
        Me.btnEliminarLinea.TabIndex = 6
        Me.btnEliminarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEliminarLinea, "Elimina un máximo de línea seleccionado, para saber si ha seleccionado uno puede " & _
                "ver la barra de estado")
        Me.btnEliminarLinea.UseVisualStyleBackColor = True
        '
        'btnNuevaLinea
        '
        Me.btnNuevaLinea.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevaLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevaLinea.Image = CType(resources.GetObject("btnNuevaLinea.Image"), System.Drawing.Image)
        Me.btnNuevaLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaLinea.Location = New System.Drawing.Point(456, 79)
        Me.btnNuevaLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNuevaLinea.Name = "btnNuevaLinea"
        Me.btnNuevaLinea.Size = New System.Drawing.Size(25, 25)
        Me.btnNuevaLinea.TabIndex = 7
        Me.btnNuevaLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNuevaLinea, "Reestablece los campos para ingresar un nuevo máximo de líneas")
        Me.btnNuevaLinea.UseVisualStyleBackColor = True
        '
        'btnBuscarLinea
        '
        Me.btnBuscarLinea.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarLinea.Image = CType(resources.GetObject("btnBuscarLinea.Image"), System.Drawing.Image)
        Me.btnBuscarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarLinea.Location = New System.Drawing.Point(480, 79)
        Me.btnBuscarLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscarLinea.Name = "btnBuscarLinea"
        Me.btnBuscarLinea.Size = New System.Drawing.Size(25, 25)
        Me.btnBuscarLinea.TabIndex = 8
        Me.btnBuscarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscarLinea, "Busca un máximo de líneas")
        Me.btnBuscarLinea.UseVisualStyleBackColor = True
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha Creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        '
        'LineasMaximo
        '
        Me.LineasMaximo.HeaderText = "Máximo Líneas"
        Me.LineasMaximo.Name = "LineasMaximo"
        Me.LineasMaximo.ReadOnly = True
        '
        'TipoDocumento
        '
        Me.TipoDocumento.HeaderText = "Tipo Documento"
        Me.TipoDocumento.Name = "TipoDocumento"
        Me.TipoDocumento.ReadOnly = True
        '
        'SerieFacturas
        '
        Me.SerieFacturas.HeaderText = "Serie"
        Me.SerieFacturas.Name = "SerieFacturas"
        Me.SerieFacturas.ReadOnly = True
        '
        'Bodega
        '
        Me.Bodega.HeaderText = "Bodega"
        Me.Bodega.Name = "Bodega"
        Me.Bodega.ReadOnly = True
        '
        'Company
        '
        Me.Company.HeaderText = "Compañía"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        '
        'Numero
        '
        Me.Numero.HeaderText = "Nº"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'dgvLineas
        '
        Me.dgvLineas.AllowUserToAddRows = False
        Me.dgvLineas.AllowUserToDeleteRows = False
        Me.dgvLineas.AllowUserToResizeColumns = False
        Me.dgvLineas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.Company, Me.Bodega, Me.SerieFacturas, Me.TipoDocumento, Me.LineasMaximo, Me.UsuarioCreacion, Me.FechaCreacion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLineas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLineas.Location = New System.Drawing.Point(1, 124)
        Me.dgvLineas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvLineas.Name = "dgvLineas"
        Me.dgvLineas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLineas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLineas.Size = New System.Drawing.Size(816, 291)
        Me.dgvLineas.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(1, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Compañía :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(64, 24)
        Me.cmbCOMPAÑIA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(660, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(64, 52)
        Me.cmbBODEGA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(256, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(1, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Bodega :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(64, 81)
        Me.cmbTIPO_DOCUMENTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(256, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(1, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Documento :"
        '
        'cmbSERIE
        '
        Me.cmbSERIE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSERIE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSERIE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSERIE.ForeColor = System.Drawing.Color.Navy
        Me.cmbSERIE.FormattingEnabled = True
        Me.cmbSERIE.Location = New System.Drawing.Point(376, 52)
        Me.cmbSERIE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSERIE.Name = "cmbSERIE"
        Me.cmbSERIE.Size = New System.Drawing.Size(250, 24)
        Me.cmbSERIE.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(320, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Serie :"
        '
        'txtLineas
        '
        Me.txtLineas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineas.Location = New System.Drawing.Point(376, 81)
        Me.txtLineas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLineas.Name = "txtLineas"
        Me.txtLineas.Size = New System.Drawing.Size(80, 22)
        Me.txtLineas.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(320, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Nº Líneas :"
        '
        'gbDG
        '
        Me.gbDG.Controls.Add(Me.lblLibreSiNo)
        Me.gbDG.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.gbDG.Controls.Add(Me.txtLineas)
        Me.gbDG.Controls.Add(Me.btnBuscarLinea)
        Me.gbDG.Controls.Add(Me.btnNuevaLinea)
        Me.gbDG.Controls.Add(Me.btnEliminarLinea)
        Me.gbDG.Controls.Add(Me.Label4)
        Me.gbDG.Controls.Add(Me.btnGuardarLinea)
        Me.gbDG.Controls.Add(Me.Label5)
        Me.gbDG.Controls.Add(Me.cmbSERIE)
        Me.gbDG.Controls.Add(Me.Label3)
        Me.gbDG.Controls.Add(Me.Label2)
        Me.gbDG.Controls.Add(Me.cmbBODEGA)
        Me.gbDG.Controls.Add(Me.cmbCOMPAÑIA)
        Me.gbDG.Controls.Add(Me.Label1)
        Me.gbDG.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDG.ForeColor = System.Drawing.Color.Navy
        Me.gbDG.Location = New System.Drawing.Point(87, 1)
        Me.gbDG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDG.Name = "gbDG"
        Me.gbDG.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbDG.Size = New System.Drawing.Size(728, 122)
        Me.gbDG.TabIndex = 0
        Me.gbDG.TabStop = False
        Me.gbDG.Text = "Datos Generales"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(-1, -1)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(87, 124)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 97
        Me.pbImagen.TabStop = False
        '
        'lblLibreSiNo
        '
        Me.lblLibreSiNo.BackColor = System.Drawing.Color.Blue
        Me.lblLibreSiNo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLibreSiNo.ForeColor = System.Drawing.Color.Yellow
        Me.lblLibreSiNo.Location = New System.Drawing.Point(628, 52)
        Me.lblLibreSiNo.Name = "lblLibreSiNo"
        Me.lblLibreSiNo.Size = New System.Drawing.Size(96, 24)
        Me.lblLibreSiNo.TabIndex = 98
        Me.lblLibreSiNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblLibreSiNo, "Muestra un mensaje indicando si la orden de venta ya fue procesada o no")
        '
        'Contabilidad_LineasMaximo_TipoDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 438)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbDG)
        Me.Controls.Add(Me.dgvLineas)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_LineasMaximo_TipoDocumento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Líneas de detalle por Tipo de Documento"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDG.ResumeLayout(False)
        Me.gbDG.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BarraEstado1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FechaCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineasMaximo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerieFacturas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvLineas As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSERIE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLineas As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnEliminarLinea As System.Windows.Forms.Button
    Friend WithEvents btnNuevaLinea As System.Windows.Forms.Button
    Friend WithEvents btnBuscarLinea As System.Windows.Forms.Button
    Friend WithEvents gbDG As System.Windows.Forms.GroupBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblLibreSiNo As System.Windows.Forms.Label
End Class
