<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Ingreso_Manual_Libro_Compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Ingreso_Manual_Libro_Compras))
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.dpPeriodo = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dpFECHA_OC = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnGuardarEncabezado = New System.Windows.Forms.Button
        Me.GrbProveedor = New System.Windows.Forms.GroupBox
        Me.txtExento = New System.Windows.Forms.TextBox
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.TextBox
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtDocumento = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.TxtProveedor_NombreComercial = New System.Windows.Forms.TextBox
        Me.txtPercepcion = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.txtTotalFact = New System.Windows.Forms.TextBox
        Me.lblPORCENTAJE_PERCEPCION = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtProveedor_Direccion = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtProveedor_Nit = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtProveedor_RegistroFiscal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtProveedor_NombreLegal = New System.Windows.Forms.TextBox
        Me.TxtProveedor_Codigo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.OpenFileDialogAbrir = New System.Windows.Forms.OpenFileDialog
        Me.gbImportar = New System.Windows.Forms.GroupBox
        Me.cmbSheets = New System.Windows.Forms.ComboBox
        Me.btnBuscarExcel = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.lblArchivoExcel = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.gbGral.SuspendLayout()
        Me.GrbProveedor.SuspendLayout()
        Me.gbImportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGral
        '
        Me.gbGral.BackColor = System.Drawing.Color.Transparent
        Me.gbGral.Controls.Add(Me.dpPeriodo)
        Me.gbGral.Controls.Add(Me.Label4)
        Me.gbGral.Controls.Add(Me.dpFECHA_OC)
        Me.gbGral.Controls.Add(Me.Label15)
        Me.gbGral.Controls.Add(Me.cmbBODEGA)
        Me.gbGral.Controls.Add(Me.Label13)
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(7, 5)
        Me.gbGral.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.gbGral.Size = New System.Drawing.Size(710, 98)
        Me.gbGral.TabIndex = 2
        Me.gbGral.TabStop = False
        Me.gbGral.Text = "Datos Generales"
        '
        'dpPeriodo
        '
        Me.dpPeriodo.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpPeriodo.CustomFormat = "MMMM-yyyy"
        Me.dpPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpPeriodo.Location = New System.Drawing.Point(354, 68)
        Me.dpPeriodo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dpPeriodo.Name = "dpPeriodo"
        Me.dpPeriodo.Size = New System.Drawing.Size(130, 22)
        Me.dpPeriodo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(247, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Periodo Contable:"
        '
        'dpFECHA_OC
        '
        Me.dpFECHA_OC.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_OC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFECHA_OC.Location = New System.Drawing.Point(132, 68)
        Me.dpFECHA_OC.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dpFECHA_OC.Name = "dpFECHA_OC"
        Me.dpFECHA_OC.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_OC.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(8, 71)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 16)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Fecha Comprobante: "
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(74, 27)
        Me.cmbBODEGA.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(357, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(8, 27)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Bodega :"
        '
        'btnGuardarEncabezado
        '
        Me.btnGuardarEncabezado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarEncabezado.Image = CType(resources.GetObject("btnGuardarEncabezado.Image"), System.Drawing.Image)
        Me.btnGuardarEncabezado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarEncabezado.Location = New System.Drawing.Point(626, 259)
        Me.btnGuardarEncabezado.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnGuardarEncabezado.Name = "btnGuardarEncabezado"
        Me.btnGuardarEncabezado.Size = New System.Drawing.Size(79, 30)
        Me.btnGuardarEncabezado.TabIndex = 8
        Me.btnGuardarEncabezado.Text = "Guardar"
        Me.btnGuardarEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarEncabezado.UseVisualStyleBackColor = True
        '
        'GrbProveedor
        '
        Me.GrbProveedor.BackColor = System.Drawing.Color.Transparent
        Me.GrbProveedor.Controls.Add(Me.txtExento)
        Me.GrbProveedor.Controls.Add(Me.btnEliminar)
        Me.GrbProveedor.Controls.Add(Me.Label1)
        Me.GrbProveedor.Controls.Add(Me.txtsubtotal)
        Me.GrbProveedor.Controls.Add(Me.cmbTipoDocumento)
        Me.GrbProveedor.Controls.Add(Me.txtIVA)
        Me.GrbProveedor.Controls.Add(Me.txtDocumento)
        Me.GrbProveedor.Controls.Add(Me.txtTotal)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreComercial)
        Me.GrbProveedor.Controls.Add(Me.txtPercepcion)
        Me.GrbProveedor.Controls.Add(Me.BtnBuscar)
        Me.GrbProveedor.Controls.Add(Me.txtTotalFact)
        Me.GrbProveedor.Controls.Add(Me.lblPORCENTAJE_PERCEPCION)
        Me.GrbProveedor.Controls.Add(Me.Label17)
        Me.GrbProveedor.Controls.Add(Me.btnGuardarEncabezado)
        Me.GrbProveedor.Controls.Add(Me.BtnLimpiar)
        Me.GrbProveedor.Controls.Add(Me.Label2)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Direccion)
        Me.GrbProveedor.Controls.Add(Me.Label10)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Nit)
        Me.GrbProveedor.Controls.Add(Me.Label3)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_RegistroFiscal)
        Me.GrbProveedor.Controls.Add(Me.Label8)
        Me.GrbProveedor.Controls.Add(Me.Label11)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreLegal)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Codigo)
        Me.GrbProveedor.Controls.Add(Me.Label12)
        Me.GrbProveedor.Controls.Add(Me.Label6)
        Me.GrbProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbProveedor.ForeColor = System.Drawing.Color.Navy
        Me.GrbProveedor.Location = New System.Drawing.Point(7, 109)
        Me.GrbProveedor.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GrbProveedor.Name = "GrbProveedor"
        Me.GrbProveedor.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GrbProveedor.Size = New System.Drawing.Size(710, 323)
        Me.GrbProveedor.TabIndex = 0
        Me.GrbProveedor.TabStop = False
        Me.GrbProveedor.Text = "Seleccionar Proveedor"
        '
        'txtExento
        '
        Me.txtExento.BackColor = System.Drawing.Color.White
        Me.txtExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExento.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExento.ForeColor = System.Drawing.Color.Navy
        Me.txtExento.Location = New System.Drawing.Point(11, 286)
        Me.txtExento.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtExento.Name = "txtExento"
        Me.txtExento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExento.Size = New System.Drawing.Size(96, 26)
        Me.txtExento.TabIndex = 2
        Me.txtExento.Text = "0.00"
        Me.txtExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = Global.AstasConta.My.Resources.Resources.editdelete
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(626, 289)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(79, 30)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Tipo Documento"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.Color.White
        Me.txtsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtotal.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.ForeColor = System.Drawing.Color.Navy
        Me.txtsubtotal.Location = New System.Drawing.Point(113, 286)
        Me.txtsubtotal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtsubtotal.Size = New System.Drawing.Size(96, 26)
        Me.txtsubtotal.TabIndex = 3
        Me.txtsubtotal.Text = "0.00"
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.ForeColor = System.Drawing.Color.Navy
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(113, 61)
        Me.cmbTipoDocumento.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(318, 24)
        Me.cmbTipoDocumento.TabIndex = 1
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.White
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(217, 286)
        Me.txtIVA.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIVA.Size = New System.Drawing.Size(96, 26)
        Me.txtIVA.TabIndex = 4
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDocumento
        '
        Me.txtDocumento.ForeColor = System.Drawing.Color.Navy
        Me.txtDocumento.Location = New System.Drawing.Point(113, 95)
        Me.txtDocumento.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDocumento.MaxLength = 10
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(117, 22)
        Me.txtDocumento.TabIndex = 1
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(320, 286)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(96, 26)
        Me.txtTotal.TabIndex = 96
        Me.txtTotal.Text = "0.00"
        '
        'TxtProveedor_NombreComercial
        '
        Me.TxtProveedor_NombreComercial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreComercial.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreComercial.Location = New System.Drawing.Point(113, 162)
        Me.TxtProveedor_NombreComercial.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_NombreComercial.Name = "TxtProveedor_NombreComercial"
        Me.TxtProveedor_NombreComercial.ReadOnly = True
        Me.TxtProveedor_NombreComercial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreComercial.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreComercial.TabIndex = 11
        '
        'txtPercepcion
        '
        Me.txtPercepcion.BackColor = System.Drawing.Color.White
        Me.txtPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcion.ForeColor = System.Drawing.Color.Navy
        Me.txtPercepcion.Location = New System.Drawing.Point(425, 286)
        Me.txtPercepcion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPercepcion.Name = "txtPercepcion"
        Me.txtPercepcion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPercepcion.Size = New System.Drawing.Size(96, 26)
        Me.txtPercepcion.TabIndex = 6
        Me.txtPercepcion.Text = "0.00"
        Me.txtPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(209, 29)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(24, 30)
        Me.BtnBuscar.TabIndex = 98
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'txtTotalFact
        '
        Me.txtTotalFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotalFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotalFact.Location = New System.Drawing.Point(529, 286)
        Me.txtTotalFact.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTotalFact.Name = "txtTotalFact"
        Me.txtTotalFact.ReadOnly = True
        Me.txtTotalFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalFact.Size = New System.Drawing.Size(96, 26)
        Me.txtTotalFact.TabIndex = 97
        Me.txtTotalFact.Text = "0.00"
        '
        'lblPORCENTAJE_PERCEPCION
        '
        Me.lblPORCENTAJE_PERCEPCION.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPORCENTAJE_PERCEPCION.Location = New System.Drawing.Point(259, 33)
        Me.lblPORCENTAJE_PERCEPCION.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPORCENTAJE_PERCEPCION.Name = "lblPORCENTAJE_PERCEPCION"
        Me.lblPORCENTAJE_PERCEPCION.Size = New System.Drawing.Size(10, 23)
        Me.lblPORCENTAJE_PERCEPCION.TabIndex = 100
        Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        Me.lblPORCENTAJE_PERCEPCION.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Teal
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(11, 259)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(614, 24)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "     Valor Exento     Valor Gravado                    (+) IVA                   " & _
            "     SubTotal                     (+)   Percep.            Total Comprob."
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(233, 29)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(24, 30)
        Me.BtnLimpiar.TabIndex = 99
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 227)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Direccion"
        '
        'TxtProveedor_Direccion
        '
        Me.TxtProveedor_Direccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Direccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Direccion.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Direccion.Location = New System.Drawing.Point(113, 227)
        Me.TxtProveedor_Direccion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_Direccion.Name = "TxtProveedor_Direccion"
        Me.TxtProveedor_Direccion.ReadOnly = True
        Me.TxtProveedor_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_Direccion.Size = New System.Drawing.Size(592, 22)
        Me.TxtProveedor_Direccion.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(8, 162)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Nombre Comercial"
        '
        'TxtProveedor_Nit
        '
        Me.TxtProveedor_Nit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Nit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Nit.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Nit.Location = New System.Drawing.Point(302, 195)
        Me.TxtProveedor_Nit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_Nit.MaxLength = 17
        Me.TxtProveedor_Nit.Name = "TxtProveedor_Nit"
        Me.TxtProveedor_Nit.ReadOnly = True
        Me.TxtProveedor_Nit.Size = New System.Drawing.Size(128, 22)
        Me.TxtProveedor_Nit.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(272, 195)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "NIT"
        '
        'TxtProveedor_RegistroFiscal
        '
        Me.TxtProveedor_RegistroFiscal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_RegistroFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_RegistroFiscal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_RegistroFiscal.Location = New System.Drawing.Point(113, 195)
        Me.TxtProveedor_RegistroFiscal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_RegistroFiscal.MaxLength = 20
        Me.TxtProveedor_RegistroFiscal.Name = "TxtProveedor_RegistroFiscal"
        Me.TxtProveedor_RegistroFiscal.ReadOnly = True
        Me.TxtProveedor_RegistroFiscal.Size = New System.Drawing.Size(126, 22)
        Me.TxtProveedor_RegistroFiscal.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 195)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Registro Fiscal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(8, 129)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Nombre Legal"
        '
        'TxtProveedor_NombreLegal
        '
        Me.TxtProveedor_NombreLegal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreLegal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreLegal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreLegal.Location = New System.Drawing.Point(113, 129)
        Me.TxtProveedor_NombreLegal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_NombreLegal.Name = "TxtProveedor_NombreLegal"
        Me.TxtProveedor_NombreLegal.ReadOnly = True
        Me.TxtProveedor_NombreLegal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreLegal.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreLegal.TabIndex = 10
        '
        'TxtProveedor_Codigo
        '
        Me.TxtProveedor_Codigo.BackColor = System.Drawing.Color.White
        Me.TxtProveedor_Codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Codigo.ForeColor = System.Drawing.Color.Red
        Me.TxtProveedor_Codigo.Location = New System.Drawing.Point(113, 29)
        Me.TxtProveedor_Codigo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtProveedor_Codigo.Name = "TxtProveedor_Codigo"
        Me.TxtProveedor_Codigo.Size = New System.Drawing.Size(94, 22)
        Me.TxtProveedor_Codigo.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(8, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 98)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "CCF #:"
        '
        'OpenFileDialogAbrir
        '
        Me.OpenFileDialogAbrir.DefaultExt = "xlsx"
        Me.OpenFileDialogAbrir.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos de Excel 97-2003|*.xls"
        Me.OpenFileDialogAbrir.InitialDirectory = "OpenFileDialog1"
        Me.OpenFileDialogAbrir.ReadOnlyChecked = True
        Me.OpenFileDialogAbrir.ShowReadOnly = True
        Me.OpenFileDialogAbrir.SupportMultiDottedExtensions = True
        '
        'gbImportar
        '
        Me.gbImportar.BackColor = System.Drawing.Color.Transparent
        Me.gbImportar.Controls.Add(Me.cmbSheets)
        Me.gbImportar.Controls.Add(Me.btnBuscarExcel)
        Me.gbImportar.Controls.Add(Me.Label27)
        Me.gbImportar.Controls.Add(Me.btnImportarExcel)
        Me.gbImportar.Controls.Add(Me.lblArchivoExcel)
        Me.gbImportar.Controls.Add(Me.Label26)
        Me.gbImportar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImportar.ForeColor = System.Drawing.Color.Navy
        Me.gbImportar.Location = New System.Drawing.Point(7, 437)
        Me.gbImportar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.gbImportar.Name = "gbImportar"
        Me.gbImportar.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.gbImportar.Size = New System.Drawing.Size(607, 98)
        Me.gbImportar.TabIndex = 57
        Me.gbImportar.TabStop = False
        Me.gbImportar.Text = "Importar desde Excel"
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(64, 59)
        Me.cmbSheets.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(458, 24)
        Me.cmbSheets.TabIndex = 1
        '
        'btnBuscarExcel
        '
        Me.btnBuscarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarExcel.Image = CType(resources.GetObject("btnBuscarExcel.Image"), System.Drawing.Image)
        Me.btnBuscarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarExcel.Location = New System.Drawing.Point(576, 30)
        Me.btnBuscarExcel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBuscarExcel.Name = "btnBuscarExcel"
        Me.btnBuscarExcel.Size = New System.Drawing.Size(24, 30)
        Me.btnBuscarExcel.TabIndex = 0
        Me.btnBuscarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarExcel.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(8, 59)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 16)
        Me.Label27.TabIndex = 53
        Me.Label27.Text = "Hojas :"
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImportarExcel.Image = CType(resources.GetObject("btnImportarExcel.Image"), System.Drawing.Image)
        Me.btnImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarExcel.Location = New System.Drawing.Point(526, 59)
        Me.btnImportarExcel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(74, 30)
        Me.btnImportarExcel.TabIndex = 2
        Me.btnImportarExcel.Text = "&Importar"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'lblArchivoExcel
        '
        Me.lblArchivoExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblArchivoExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArchivoExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivoExcel.ForeColor = System.Drawing.Color.Navy
        Me.lblArchivoExcel.Location = New System.Drawing.Point(64, 30)
        Me.lblArchivoExcel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblArchivoExcel.Name = "lblArchivoExcel"
        Me.lblArchivoExcel.Size = New System.Drawing.Size(510, 27)
        Me.lblArchivoExcel.TabIndex = 52
        Me.lblArchivoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Navy
        Me.Label26.Location = New System.Drawing.Point(8, 30)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 16)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Archivo :"
        '
        'Contabilidad_Ingreso_Manual_Libro_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 542)
        Me.Controls.Add(Me.gbImportar)
        Me.Controls.Add(Me.GrbProveedor)
        Me.Controls.Add(Me.gbGral)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Ingreso_Manual_Libro_Compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Ingreso Manual Comprobantes Libro Compras"
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        Me.GrbProveedor.ResumeLayout(False)
        Me.GrbProveedor.PerformLayout()
        Me.gbImportar.ResumeLayout(False)
        Me.gbImportar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents dpFECHA_OC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarEncabezado As System.Windows.Forms.Button
    Friend WithEvents GrbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents TxtProveedor_NombreComercial As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblPORCENTAJE_PERCEPCION As System.Windows.Forms.Label
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Nit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_RegistroFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_NombreLegal As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPercepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFact As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialogAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gbImportar As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSheets As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarExcel As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblArchivoExcel As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtExento As System.Windows.Forms.TextBox
    Friend WithEvents dpPeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
