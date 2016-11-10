<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Ingreso_Manual_Libro_Ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Ingreso_Manual_Libro_Ventas))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtDUI = New System.Windows.Forms.MaskedTextBox
        Me.txtNIT = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCompReten = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRetencion = New System.Windows.Forms.TextBox
        Me.txtCaja = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRegIva = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.chkAnulada = New System.Windows.Forms.CheckBox
        Me.btnGuardaFactura = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.txtTotFact = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNomFact = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSUBTOTAL = New System.Windows.Forms.TextBox
        Me.bntNuevaFact = New System.Windows.Forms.Button
        Me.txtNoFact = New System.Windows.Forms.TextBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.cmbTipDoc = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbImportar = New System.Windows.Forms.GroupBox
        Me.cmbSheets = New System.Windows.Forms.ComboBox
        Me.btnBuscarExcel = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.lblArchivoExcel = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.OpenFileDialogAbrir = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox4.SuspendLayout()
        Me.gbImportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtDUI)
        Me.GroupBox4.Controls.Add(Me.txtNIT)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtCompReten)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtRetencion)
        Me.GroupBox4.Controls.Add(Me.txtCaja)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtRegIva)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.btnEliminar)
        Me.GroupBox4.Controls.Add(Me.chkAnulada)
        Me.GroupBox4.Controls.Add(Me.btnGuardaFactura)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtConcepto)
        Me.GroupBox4.Controls.Add(Me.txtTotFact)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtNomFact)
        Me.GroupBox4.Controls.Add(Me.txtIVA)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtSUBTOTAL)
        Me.GroupBox4.Controls.Add(Me.bntNuevaFact)
        Me.GroupBox4.Controls.Add(Me.txtNoFact)
        Me.GroupBox4.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox4.Controls.Add(Me.cmbTipDoc)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox4.Location = New System.Drawing.Point(1, 5)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(508, 368)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generales"
        '
        'txtDUI
        '
        Me.txtDUI.Location = New System.Drawing.Point(108, 164)
        Me.txtDUI.Mask = "00000000-0"
        Me.txtDUI.Name = "txtDUI"
        Me.txtDUI.Size = New System.Drawing.Size(114, 22)
        Me.txtDUI.TabIndex = 1508
        '
        'txtNIT
        '
        Me.txtNIT.Location = New System.Drawing.Point(338, 164)
        Me.txtNIT.Mask = "0000-000000-000-0"
        Me.txtNIT.Name = "txtNIT"
        Me.txtNIT.Size = New System.Drawing.Size(114, 22)
        Me.txtNIT.TabIndex = 1507
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(289, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 1506
        Me.Label9.Text = "NIT :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(15, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 16)
        Me.Label8.TabIndex = 1504
        Me.Label8.Text = "DUI:"
        '
        'txtCompReten
        '
        Me.txtCompReten.BackColor = System.Drawing.SystemColors.Window
        Me.txtCompReten.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompReten.ForeColor = System.Drawing.Color.Navy
        Me.txtCompReten.Location = New System.Drawing.Point(338, 194)
        Me.txtCompReten.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompReten.MaxLength = 200
        Me.txtCompReten.Name = "txtCompReten"
        Me.txtCompReten.Size = New System.Drawing.Size(114, 22)
        Me.txtCompReten.TabIndex = 7
        Me.txtCompReten.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(180, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 16)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Comprobante de Retención N° :"
        Me.Label7.Visible = False
        '
        'txtRetencion
        '
        Me.txtRetencion.BackColor = System.Drawing.Color.White
        Me.txtRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRetencion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetencion.ForeColor = System.Drawing.Color.Navy
        Me.txtRetencion.Location = New System.Drawing.Point(312, 327)
        Me.txtRetencion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRetencion.Name = "txtRetencion"
        Me.txtRetencion.Size = New System.Drawing.Size(90, 26)
        Me.txtRetencion.TabIndex = 13
        Me.txtRetencion.Text = "0.00"
        Me.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCaja
        '
        Me.txtCaja.BackColor = System.Drawing.SystemColors.Window
        Me.txtCaja.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaja.ForeColor = System.Drawing.Color.Navy
        Me.txtCaja.Location = New System.Drawing.Point(338, 194)
        Me.txtCaja.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCaja.MaxLength = 200
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(63, 22)
        Me.txtCaja.TabIndex = 5
        Me.txtCaja.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(252, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Caja N° :"
        Me.Label6.Visible = False
        '
        'txtRegIva
        '
        Me.txtRegIva.BackColor = System.Drawing.SystemColors.Window
        Me.txtRegIva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegIva.ForeColor = System.Drawing.Color.Navy
        Me.txtRegIva.Location = New System.Drawing.Point(338, 131)
        Me.txtRegIva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRegIva.MaxLength = 200
        Me.txtRegIva.Name = "txtRegIva"
        Me.txtRegIva.Size = New System.Drawing.Size(114, 22)
        Me.txtRegIva.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(252, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "N° Registro :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtCliente.Location = New System.Drawing.Point(108, 131)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(114, 22)
        Me.txtCliente.TabIndex = 4
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(15, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Codigo Cliente:"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.AstasConta.My.Resources.Resources.editdelete
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(416, 329)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 30)
        Me.btnEliminar.TabIndex = 15
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'chkAnulada
        '
        Me.chkAnulada.AutoSize = True
        Me.chkAnulada.Location = New System.Drawing.Point(108, 196)
        Me.chkAnulada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAnulada.Name = "chkAnulada"
        Me.chkAnulada.Size = New System.Drawing.Size(70, 20)
        Me.chkAnulada.TabIndex = 6
        Me.chkAnulada.Text = "Anulada"
        Me.chkAnulada.UseVisualStyleBackColor = True
        '
        'btnGuardaFactura
        '
        Me.btnGuardaFactura.Image = CType(resources.GetObject("btnGuardaFactura.Image"), System.Drawing.Image)
        Me.btnGuardaFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardaFactura.Location = New System.Drawing.Point(416, 300)
        Me.btnGuardaFactura.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardaFactura.Name = "btnGuardaFactura"
        Me.btnGuardaFactura.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardaFactura.TabIndex = 14
        Me.btnGuardaFactura.Text = "Guardar"
        Me.btnGuardaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardaFactura.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(18, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 24)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "              Subtotal                          IVA        Total Factura         " & _
            "     Retención"
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.txtConcepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.ForeColor = System.Drawing.Color.Navy
        Me.txtConcepto.Location = New System.Drawing.Point(108, 265)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(388, 22)
        Me.txtConcepto.TabIndex = 9
        '
        'txtTotFact
        '
        Me.txtTotFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotFact.Location = New System.Drawing.Point(214, 327)
        Me.txtTotFact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotFact.Name = "txtTotFact"
        Me.txtTotFact.ReadOnly = True
        Me.txtTotFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotFact.Size = New System.Drawing.Size(96, 26)
        Me.txtTotFact.TabIndex = 1502
        Me.txtTotFact.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(15, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Concepto:"
        '
        'txtNomFact
        '
        Me.txtNomFact.BackColor = System.Drawing.SystemColors.Window
        Me.txtNomFact.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomFact.ForeColor = System.Drawing.Color.Navy
        Me.txtNomFact.Location = New System.Drawing.Point(109, 233)
        Me.txtNomFact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNomFact.MaxLength = 200
        Me.txtNomFact.Name = "txtNomFact"
        Me.txtNomFact.Size = New System.Drawing.Size(388, 22)
        Me.txtNomFact.TabIndex = 8
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.White
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(116, 327)
        Me.txtIVA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(96, 26)
        Me.txtIVA.TabIndex = 11
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(16, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 16)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Nombre Factura :"
        '
        'txtSUBTOTAL
        '
        Me.txtSUBTOTAL.BackColor = System.Drawing.Color.White
        Me.txtSUBTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSUBTOTAL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBTOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtSUBTOTAL.Location = New System.Drawing.Point(18, 327)
        Me.txtSUBTOTAL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSUBTOTAL.Name = "txtSUBTOTAL"
        Me.txtSUBTOTAL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSUBTOTAL.Size = New System.Drawing.Size(96, 26)
        Me.txtSUBTOTAL.TabIndex = 10
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtSUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bntNuevaFact
        '
        Me.bntNuevaFact.Image = Global.AstasConta.My.Resources.Resources.filenew
        Me.bntNuevaFact.Location = New System.Drawing.Point(469, 27)
        Me.bntNuevaFact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bntNuevaFact.Name = "bntNuevaFact"
        Me.bntNuevaFact.Size = New System.Drawing.Size(27, 30)
        Me.bntNuevaFact.TabIndex = 16
        Me.bntNuevaFact.UseVisualStyleBackColor = True
        '
        'txtNoFact
        '
        Me.txtNoFact.BackColor = System.Drawing.Color.Yellow
        Me.txtNoFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoFact.ForeColor = System.Drawing.Color.Red
        Me.txtNoFact.Location = New System.Drawing.Point(108, 94)
        Me.txtNoFact.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.Size = New System.Drawing.Size(114, 26)
        Me.txtNoFact.TabIndex = 2
        Me.txtNoFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"01 - Despensa Planta 01", "02 - Despensa Zapotitán"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(108, 26)
        Me.cmbBODEGA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(344, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Navy
        Me.Label52.Location = New System.Drawing.Point(15, 97)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(80, 16)
        Me.Label52.TabIndex = 48
        Me.Label52.Text = "N° Documento:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(245, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 16)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "Fecha Docto. :"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Navy
        Me.Label58.Location = New System.Drawing.Point(15, 30)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(51, 16)
        Me.Label58.TabIndex = 0
        Me.Label58.Text = "Bodega :"
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(338, 99)
        Me.dpFECHA_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(114, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 3
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipDoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipDoc.ForeColor = System.Drawing.Color.Navy
        Me.cmbTipDoc.FormattingEnabled = True
        Me.cmbTipDoc.Items.AddRange(New Object() {"Consumidor Final", "Crédito Fiscal"})
        Me.cmbTipDoc.Location = New System.Drawing.Point(108, 60)
        Me.cmbTipDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.Size = New System.Drawing.Size(344, 24)
        Me.cmbTipDoc.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(15, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Tipo Documento :"
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
        Me.gbImportar.Location = New System.Drawing.Point(1, 381)
        Me.gbImportar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbImportar.Name = "gbImportar"
        Me.gbImportar.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbImportar.Size = New System.Drawing.Size(508, 98)
        Me.gbImportar.TabIndex = 64
        Me.gbImportar.TabStop = False
        Me.gbImportar.Text = "Importar desde Excel"
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(64, 59)
        Me.cmbSheets.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(354, 24)
        Me.cmbSheets.TabIndex = 2
        '
        'btnBuscarExcel
        '
        Me.btnBuscarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarExcel.Image = CType(resources.GetObject("btnBuscarExcel.Image"), System.Drawing.Image)
        Me.btnBuscarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarExcel.Location = New System.Drawing.Point(472, 27)
        Me.btnBuscarExcel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.btnImportarExcel.Location = New System.Drawing.Point(422, 57)
        Me.btnImportarExcel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(72, 30)
        Me.btnImportarExcel.TabIndex = 1
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
        Me.lblArchivoExcel.Name = "lblArchivoExcel"
        Me.lblArchivoExcel.Size = New System.Drawing.Size(406, 27)
        Me.lblArchivoExcel.TabIndex = 52
        Me.lblArchivoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Navy
        Me.Label26.Location = New System.Drawing.Point(8, 30)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 16)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Archivo :"
        '
        'OpenFileDialogAbrir
        '
        Me.OpenFileDialogAbrir.DefaultExt = "xlsx"
        Me.OpenFileDialogAbrir.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos de Excel 97-2003|*.xls"
        Me.OpenFileDialogAbrir.ReadOnlyChecked = True
        Me.OpenFileDialogAbrir.ShowReadOnly = True
        Me.OpenFileDialogAbrir.SupportMultiDottedExtensions = True
        '
        'Contabilidad_Ingreso_Manual_Libro_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 489)
        Me.Controls.Add(Me.gbImportar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(750, 1837)
        Me.Name = "Contabilidad_Ingreso_Manual_Libro_Ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad Ingreso Manual Libro Ventas"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbImportar.ResumeLayout(False)
        Me.gbImportar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardaFactura As System.Windows.Forms.Button
    Friend WithEvents bntNuevaFact As System.Windows.Forms.Button
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNomFact As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotFact As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAnulada As System.Windows.Forms.CheckBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRegIva As System.Windows.Forms.TextBox
    Friend WithEvents txtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbImportar As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSheets As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarExcel As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblArchivoExcel As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialogAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtCompReten As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNIT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDUI As System.Windows.Forms.MaskedTextBox
End Class
