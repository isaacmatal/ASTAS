<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentasxCobrar_Facturacion_Reportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CuentasxCobrar_Facturacion_Reportes))
        Me.DgvFacturas = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkIncluyeFecha = New System.Windows.Forms.CheckBox
        Me.btnReporte = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.dpFECHA = New System.Windows.Forms.DateTimePicker
        Me.chkAllSelected = New System.Windows.Forms.CheckBox
        Me.cmbSELECCION = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GbxCotizacion = New System.Windows.Forms.GroupBox
        Me.txtNoFact = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.gbDetCCF = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbMUNICIPIO = New System.Windows.Forms.ComboBox
        Me.cmbPAIS = New System.Windows.Forms.ComboBox
        Me.cmbDEPTO = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GbxCotizacion.SuspendLayout()
        Me.gbDetCCF.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvFacturas
        '
        Me.DgvFacturas.AllowUserToAddRows = False
        Me.DgvFacturas.AllowUserToDeleteRows = False
        Me.DgvFacturas.AllowUserToResizeColumns = False
        Me.DgvFacturas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvFacturas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvFacturas.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvFacturas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvFacturas.Location = New System.Drawing.Point(1, 129)
        Me.DgvFacturas.MultiSelect = False
        Me.DgvFacturas.Name = "DgvFacturas"
        Me.DgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFacturas.Size = New System.Drawing.Size(866, 296)
        Me.DgvFacturas.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkIncluyeFecha)
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.BtnBuscar)
        Me.GroupBox2.Controls.Add(Me.dpFECHA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(463, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 124)
        Me.GroupBox2.TabIndex = 130
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'chkIncluyeFecha
        '
        Me.chkIncluyeFecha.AutoSize = True
        Me.chkIncluyeFecha.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncluyeFecha.ForeColor = System.Drawing.Color.Red
        Me.chkIncluyeFecha.Location = New System.Drawing.Point(12, 54)
        Me.chkIncluyeFecha.Name = "chkIncluyeFecha"
        Me.chkIncluyeFecha.Size = New System.Drawing.Size(154, 20)
        Me.chkIncluyeFecha.TabIndex = 4
        Me.chkIncluyeFecha.Text = "Incluir Fecha en Búsqueda"
        Me.chkIncluyeFecha.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Enabled = False
        Me.btnReporte.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnReporte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(96, 87)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(69, 25)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.Text = "&Ver CF"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(7, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha :"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(21, 87)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.BtnBuscar.TabIndex = 5
        Me.BtnBuscar.Text = "&Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'dpFECHA
        '
        Me.dpFECHA.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA.Location = New System.Drawing.Point(57, 23)
        Me.dpFECHA.Name = "dpFECHA"
        Me.dpFECHA.Size = New System.Drawing.Size(116, 22)
        Me.dpFECHA.TabIndex = 3
        '
        'chkAllSelected
        '
        Me.chkAllSelected.AutoSize = True
        Me.chkAllSelected.Enabled = False
        Me.chkAllSelected.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllSelected.ForeColor = System.Drawing.Color.Navy
        Me.chkAllSelected.Location = New System.Drawing.Point(297, 71)
        Me.chkAllSelected.Name = "chkAllSelected"
        Me.chkAllSelected.Size = New System.Drawing.Size(115, 20)
        Me.chkAllSelected.TabIndex = 108
        Me.chkAllSelected.Text = "Seleccionar Todos"
        Me.chkAllSelected.UseVisualStyleBackColor = True
        Me.chkAllSelected.Visible = False
        '
        'cmbSELECCION
        '
        Me.cmbSELECCION.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSELECCION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSELECCION.Enabled = False
        Me.cmbSELECCION.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSELECCION.ForeColor = System.Drawing.Color.Navy
        Me.cmbSELECCION.FormattingEnabled = True
        Me.cmbSELECCION.Items.AddRange(New Object() {"Simple", "Múltiple"})
        Me.cmbSELECCION.Location = New System.Drawing.Point(335, 69)
        Me.cmbSELECCION.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbSELECCION.Name = "cmbSELECCION"
        Me.cmbSELECCION.Size = New System.Drawing.Size(110, 24)
        Me.cmbSELECCION.TabIndex = 107
        Me.cmbSELECCION.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(269, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Selección :"
        Me.Label2.Visible = False
        '
        'GbxCotizacion
        '
        Me.GbxCotizacion.Controls.Add(Me.txtNoFact)
        Me.GbxCotizacion.Controls.Add(Me.Label5)
        Me.GbxCotizacion.Controls.Add(Me.chkAllSelected)
        Me.GbxCotizacion.Controls.Add(Me.txtNombreCliente)
        Me.GbxCotizacion.Controls.Add(Me.Label8)
        Me.GbxCotizacion.Controls.Add(Me.cmbBODEGA)
        Me.GbxCotizacion.Controls.Add(Me.Label1)
        Me.GbxCotizacion.Controls.Add(Me.cmbSELECCION)
        Me.GbxCotizacion.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.GbxCotizacion.Controls.Add(Me.Label2)
        Me.GbxCotizacion.Controls.Add(Me.Label3)
        Me.GbxCotizacion.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GbxCotizacion.Controls.Add(Me.Label14)
        Me.GbxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCotizacion.ForeColor = System.Drawing.Color.Navy
        Me.GbxCotizacion.Location = New System.Drawing.Point(4, 3)
        Me.GbxCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Name = "GbxCotizacion"
        Me.GbxCotizacion.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Size = New System.Drawing.Size(453, 124)
        Me.GbxCotizacion.TabIndex = 131
        Me.GbxCotizacion.TabStop = False
        Me.GbxCotizacion.Text = "Datos Generales"
        '
        'txtNoFact
        '
        Me.txtNoFact.Location = New System.Drawing.Point(335, 70)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.Size = New System.Drawing.Size(110, 22)
        Me.txtNoFact.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(278, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Factura #"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreCliente.Location = New System.Drawing.Point(93, 96)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreCliente.Size = New System.Drawing.Size(352, 22)
        Me.txtNombreCliente.TabIndex = 133
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(1, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Nombre Factura :"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(64, 42)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(383, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(1, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Bodega :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Items.AddRange(New Object() {"Cheques", "Remesas"})
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(64, 69)
        Me.cmbTIPO_DOCUMENTO.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(211, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(1, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Documento :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Enabled = False
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(64, 15)
        Me.cmbCOMPAÑIA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(383, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(1, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 16)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Compañía:"
        '
        'gbDetCCF
        '
        Me.gbDetCCF.Controls.Add(Me.Label9)
        Me.gbDetCCF.Controls.Add(Me.Label11)
        Me.gbDetCCF.Controls.Add(Me.cmbMUNICIPIO)
        Me.gbDetCCF.Controls.Add(Me.cmbPAIS)
        Me.gbDetCCF.Controls.Add(Me.cmbDEPTO)
        Me.gbDetCCF.Controls.Add(Me.Label10)
        Me.gbDetCCF.Enabled = False
        Me.gbDetCCF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetCCF.ForeColor = System.Drawing.Color.Navy
        Me.gbDetCCF.Location = New System.Drawing.Point(658, 99)
        Me.gbDetCCF.Name = "gbDetCCF"
        Me.gbDetCCF.Size = New System.Drawing.Size(199, 19)
        Me.gbDetCCF.TabIndex = 131
        Me.gbDetCCF.TabStop = False
        Me.gbDetCCF.Text = "Detalle sólo para CCF"
        Me.gbDetCCF.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Municipio :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(6, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 16)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = "País :"
        '
        'cmbMUNICIPIO
        '
        Me.cmbMUNICIPIO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMUNICIPIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMUNICIPIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMUNICIPIO.ForeColor = System.Drawing.Color.Navy
        Me.cmbMUNICIPIO.FormattingEnabled = True
        Me.cmbMUNICIPIO.Items.AddRange(New Object() {"Simple", "Múltiple"})
        Me.cmbMUNICIPIO.Location = New System.Drawing.Point(68, 74)
        Me.cmbMUNICIPIO.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbMUNICIPIO.Name = "cmbMUNICIPIO"
        Me.cmbMUNICIPIO.Size = New System.Drawing.Size(125, 24)
        Me.cmbMUNICIPIO.TabIndex = 135
        '
        'cmbPAIS
        '
        Me.cmbPAIS.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPAIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAIS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPAIS.ForeColor = System.Drawing.Color.Navy
        Me.cmbPAIS.FormattingEnabled = True
        Me.cmbPAIS.Items.AddRange(New Object() {"Simple", "Múltiple"})
        Me.cmbPAIS.Location = New System.Drawing.Point(68, 20)
        Me.cmbPAIS.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbPAIS.Name = "cmbPAIS"
        Me.cmbPAIS.Size = New System.Drawing.Size(125, 24)
        Me.cmbPAIS.TabIndex = 109
        '
        'cmbDEPTO
        '
        Me.cmbDEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDEPTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDEPTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbDEPTO.FormattingEnabled = True
        Me.cmbDEPTO.Items.AddRange(New Object() {"Simple", "Múltiple"})
        Me.cmbDEPTO.Location = New System.Drawing.Point(68, 47)
        Me.cmbDEPTO.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbDEPTO.Name = "cmbDEPTO"
        Me.cmbDEPTO.Size = New System.Drawing.Size(125, 24)
        Me.cmbDEPTO.TabIndex = 134
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 16)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Depto :"
        '
        'Contabilidad_CuentasxCobrar_Facturacion_Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 425)
        Me.Controls.Add(Me.gbDetCCF)
        Me.Controls.Add(Me.GbxCotizacion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DgvFacturas)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_CuentasxCobrar_Facturacion_Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Impresión de Facturas"
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GbxCotizacion.ResumeLayout(False)
        Me.GbxCotizacion.PerformLayout()
        Me.gbDetCCF.ResumeLayout(False)
        Me.gbDetCCF.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllSelected As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSELECCION As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIncluyeFecha As System.Windows.Forms.CheckBox
    Friend WithEvents GbxCotizacion As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbDetCCF As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDEPTO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPAIS As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMUNICIPIO As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
