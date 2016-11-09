<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutorizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutorizaciones))
        Me.CbxUsuarios = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SpcAutorizacion_1_2 = New System.Windows.Forms.SplitContainer
        Me.BtnAutorizacion1 = New System.Windows.Forms.Button
        Me.DpFechaA1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtComentario1 = New System.Windows.Forms.TextBox
        Me.ChxAutorizacionUno = New System.Windows.Forms.CheckBox
        Me.BtnAutorizacion2 = New System.Windows.Forms.Button
        Me.DpFechaA2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtComentario2 = New System.Windows.Forms.TextBox
        Me.ChxAutorizacionDos = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.PlAutorizacion_3 = New System.Windows.Forms.Panel
        Me.BtnAutorizacion3 = New System.Windows.Forms.Button
        Me.DpFechaA3 = New System.Windows.Forms.DateTimePicker
        Me.ChxAutorizacionTres = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtComentario3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.SpcAutorizacion_D_A = New System.Windows.Forms.SplitContainer
        Me.BtnDenegar = New System.Windows.Forms.Button
        Me.DpFechaDenegada = New System.Windows.Forms.DateTimePicker
        Me.ChxDenegada = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtComenDenegada = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.DpFechaAnulada = New System.Windows.Forms.DateTimePicker
        Me.BtnAnular = New System.Windows.Forms.Button
        Me.ChxAnulada = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtComentAnulada = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblNumeroSol = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblAutoriza1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblAutoriza2 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblAutoriza3 = New System.Windows.Forms.Label
        Me.SpcAutorizacion_1_2.Panel1.SuspendLayout()
        Me.SpcAutorizacion_1_2.Panel2.SuspendLayout()
        Me.SpcAutorizacion_1_2.SuspendLayout()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.PlAutorizacion_3.SuspendLayout()
        Me.SpcAutorizacion_D_A.Panel1.SuspendLayout()
        Me.SpcAutorizacion_D_A.Panel2.SuspendLayout()
        Me.SpcAutorizacion_D_A.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbxUsuarios
        '
        Me.CbxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxUsuarios.Enabled = False
        Me.CbxUsuarios.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxUsuarios.ForeColor = System.Drawing.Color.Navy
        Me.CbxUsuarios.FormattingEnabled = True
        Me.CbxUsuarios.Location = New System.Drawing.Point(80, 32)
        Me.CbxUsuarios.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.CbxUsuarios.Name = "CbxUsuarios"
        Me.CbxUsuarios.Size = New System.Drawing.Size(253, 24)
        Me.CbxUsuarios.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Usuario:"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Enabled = False
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(80, 8)
        Me.CbxCompania.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(471, 24)
        Me.CbxCompania.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Compañia:"
        '
        'SpcAutorizacion_1_2
        '
        Me.SpcAutorizacion_1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SpcAutorizacion_1_2.Location = New System.Drawing.Point(8, 24)
        Me.SpcAutorizacion_1_2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SpcAutorizacion_1_2.Name = "SpcAutorizacion_1_2"
        Me.SpcAutorizacion_1_2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SpcAutorizacion_1_2.Panel1
        '
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.BtnAutorizacion1)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.DpFechaA1)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.lblAutoriza1)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.Label16)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.Label1)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.Label8)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.TxtComentario1)
        Me.SpcAutorizacion_1_2.Panel1.Controls.Add(Me.ChxAutorizacionUno)
        '
        'SpcAutorizacion_1_2.Panel2
        '
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.BtnAutorizacion2)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.DpFechaA2)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.lblAutoriza2)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.Label18)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.Label2)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.Label9)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.TxtComentario2)
        Me.SpcAutorizacion_1_2.Panel2.Controls.Add(Me.ChxAutorizacionDos)
        Me.SpcAutorizacion_1_2.Size = New System.Drawing.Size(330, 177)
        Me.SpcAutorizacion_1_2.SplitterDistance = 88
        Me.SpcAutorizacion_1_2.SplitterWidth = 1
        Me.SpcAutorizacion_1_2.TabIndex = 32
        '
        'BtnAutorizacion1
        '
        Me.BtnAutorizacion1.Enabled = False
        Me.BtnAutorizacion1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAutorizacion1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAutorizacion1.Image = CType(resources.GetObject("BtnAutorizacion1.Image"), System.Drawing.Image)
        Me.BtnAutorizacion1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAutorizacion1.Location = New System.Drawing.Point(240, 56)
        Me.BtnAutorizacion1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.BtnAutorizacion1.Name = "BtnAutorizacion1"
        Me.BtnAutorizacion1.Size = New System.Drawing.Size(80, 24)
        Me.BtnAutorizacion1.TabIndex = 38
        Me.BtnAutorizacion1.Text = "Autorizar"
        Me.BtnAutorizacion1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAutorizacion1.UseVisualStyleBackColor = True
        '
        'DpFechaA1
        '
        Me.DpFechaA1.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaA1.Enabled = False
        Me.DpFechaA1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaA1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaA1.Location = New System.Drawing.Point(88, 56)
        Me.DpFechaA1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DpFechaA1.Name = "DpFechaA1"
        Me.DpFechaA1.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaA1.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Comentario: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 16)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Fecha:"
        '
        'TxtComentario1
        '
        Me.TxtComentario1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComentario1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtComentario1.ForeColor = System.Drawing.Color.Navy
        Me.TxtComentario1.Location = New System.Drawing.Point(88, 32)
        Me.TxtComentario1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtComentario1.Name = "TxtComentario1"
        Me.TxtComentario1.ReadOnly = True
        Me.TxtComentario1.Size = New System.Drawing.Size(232, 22)
        Me.TxtComentario1.TabIndex = 33
        '
        'ChxAutorizacionUno
        '
        Me.ChxAutorizacionUno.AutoSize = True
        Me.ChxAutorizacionUno.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAutorizacionUno.ForeColor = System.Drawing.Color.Red
        Me.ChxAutorizacionUno.Location = New System.Drawing.Point(16, 8)
        Me.ChxAutorizacionUno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChxAutorizacionUno.Name = "ChxAutorizacionUno"
        Me.ChxAutorizacionUno.Size = New System.Drawing.Size(100, 20)
        Me.ChxAutorizacionUno.TabIndex = 32
        Me.ChxAutorizacionUno.Text = "Autorización #1"
        Me.ChxAutorizacionUno.UseVisualStyleBackColor = True
        '
        'BtnAutorizacion2
        '
        Me.BtnAutorizacion2.Enabled = False
        Me.BtnAutorizacion2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAutorizacion2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAutorizacion2.Image = CType(resources.GetObject("BtnAutorizacion2.Image"), System.Drawing.Image)
        Me.BtnAutorizacion2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAutorizacion2.Location = New System.Drawing.Point(240, 56)
        Me.BtnAutorizacion2.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.BtnAutorizacion2.Name = "BtnAutorizacion2"
        Me.BtnAutorizacion2.Size = New System.Drawing.Size(80, 24)
        Me.BtnAutorizacion2.TabIndex = 39
        Me.BtnAutorizacion2.Text = "Autorizar"
        Me.BtnAutorizacion2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAutorizacion2.UseVisualStyleBackColor = True
        '
        'DpFechaA2
        '
        Me.DpFechaA2.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaA2.Enabled = False
        Me.DpFechaA2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaA2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaA2.Location = New System.Drawing.Point(88, 56)
        Me.DpFechaA2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DpFechaA2.Name = "DpFechaA2"
        Me.DpFechaA2.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaA2.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Comentario: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 16)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Fecha:"
        '
        'TxtComentario2
        '
        Me.TxtComentario2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComentario2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtComentario2.ForeColor = System.Drawing.Color.Navy
        Me.TxtComentario2.Location = New System.Drawing.Point(88, 32)
        Me.TxtComentario2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtComentario2.Name = "TxtComentario2"
        Me.TxtComentario2.ReadOnly = True
        Me.TxtComentario2.Size = New System.Drawing.Size(232, 22)
        Me.TxtComentario2.TabIndex = 36
        '
        'ChxAutorizacionDos
        '
        Me.ChxAutorizacionDos.AutoSize = True
        Me.ChxAutorizacionDos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAutorizacionDos.ForeColor = System.Drawing.Color.Red
        Me.ChxAutorizacionDos.Location = New System.Drawing.Point(16, 8)
        Me.ChxAutorizacionDos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChxAutorizacionDos.Name = "ChxAutorizacionDos"
        Me.ChxAutorizacionDos.Size = New System.Drawing.Size(100, 20)
        Me.ChxAutorizacionDos.TabIndex = 35
        Me.ChxAutorizacionDos.Text = "Autorización #2"
        Me.ChxAutorizacionDos.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(392, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 16)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "N° Solicitud:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(17, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Comentario: "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(85, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(235, 20)
        Me.TextBox1.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(17, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Comentario: "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(88, 31)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(235, 20)
        Me.TextBox2.TabIndex = 36
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.Controls.Add(Me.PlAutorizacion_3)
        Me.GbxCriterioBusq.Controls.Add(Me.SpcAutorizacion_D_A)
        Me.GbxCriterioBusq.Controls.Add(Me.SpcAutorizacion_1_2)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 64)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(680, 304)
        Me.GbxCriterioBusq.TabIndex = 37
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Autorizaciones"
        '
        'PlAutorizacion_3
        '
        Me.PlAutorizacion_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PlAutorizacion_3.Controls.Add(Me.BtnAutorizacion3)
        Me.PlAutorizacion_3.Controls.Add(Me.DpFechaA3)
        Me.PlAutorizacion_3.Controls.Add(Me.lblAutoriza3)
        Me.PlAutorizacion_3.Controls.Add(Me.Label20)
        Me.PlAutorizacion_3.Controls.Add(Me.ChxAutorizacionTres)
        Me.PlAutorizacion_3.Controls.Add(Me.Label6)
        Me.PlAutorizacion_3.Controls.Add(Me.TxtComentario3)
        Me.PlAutorizacion_3.Controls.Add(Me.Label10)
        Me.PlAutorizacion_3.Location = New System.Drawing.Point(8, 200)
        Me.PlAutorizacion_3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PlAutorizacion_3.Name = "PlAutorizacion_3"
        Me.PlAutorizacion_3.Size = New System.Drawing.Size(330, 88)
        Me.PlAutorizacion_3.TabIndex = 37
        '
        'BtnAutorizacion3
        '
        Me.BtnAutorizacion3.Enabled = False
        Me.BtnAutorizacion3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAutorizacion3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAutorizacion3.Image = CType(resources.GetObject("BtnAutorizacion3.Image"), System.Drawing.Image)
        Me.BtnAutorizacion3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAutorizacion3.Location = New System.Drawing.Point(240, 56)
        Me.BtnAutorizacion3.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.BtnAutorizacion3.Name = "BtnAutorizacion3"
        Me.BtnAutorizacion3.Size = New System.Drawing.Size(80, 24)
        Me.BtnAutorizacion3.TabIndex = 40
        Me.BtnAutorizacion3.Text = "Autorizar"
        Me.BtnAutorizacion3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAutorizacion3.UseVisualStyleBackColor = True
        '
        'DpFechaA3
        '
        Me.DpFechaA3.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaA3.Enabled = False
        Me.DpFechaA3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaA3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaA3.Location = New System.Drawing.Point(88, 56)
        Me.DpFechaA3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DpFechaA3.Name = "DpFechaA3"
        Me.DpFechaA3.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaA3.TabIndex = 41
        '
        'ChxAutorizacionTres
        '
        Me.ChxAutorizacionTres.AutoSize = True
        Me.ChxAutorizacionTres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAutorizacionTres.ForeColor = System.Drawing.Color.Red
        Me.ChxAutorizacionTres.Location = New System.Drawing.Point(16, 10)
        Me.ChxAutorizacionTres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChxAutorizacionTres.Name = "ChxAutorizacionTres"
        Me.ChxAutorizacionTres.Size = New System.Drawing.Size(100, 20)
        Me.ChxAutorizacionTres.TabIndex = 38
        Me.ChxAutorizacionTres.Text = "Autorización #3"
        Me.ChxAutorizacionTres.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Comentario: "
        '
        'TxtComentario3
        '
        Me.TxtComentario3.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComentario3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtComentario3.ForeColor = System.Drawing.Color.Navy
        Me.TxtComentario3.Location = New System.Drawing.Point(88, 32)
        Me.TxtComentario3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtComentario3.Name = "TxtComentario3"
        Me.TxtComentario3.ReadOnly = True
        Me.TxtComentario3.Size = New System.Drawing.Size(232, 22)
        Me.TxtComentario3.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Fecha:"
        '
        'SpcAutorizacion_D_A
        '
        Me.SpcAutorizacion_D_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SpcAutorizacion_D_A.Location = New System.Drawing.Point(344, 24)
        Me.SpcAutorizacion_D_A.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SpcAutorizacion_D_A.Name = "SpcAutorizacion_D_A"
        Me.SpcAutorizacion_D_A.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SpcAutorizacion_D_A.Panel1
        '
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.BtnDenegar)
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.DpFechaDenegada)
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.ChxDenegada)
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.Label7)
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.TxtComenDenegada)
        Me.SpcAutorizacion_D_A.Panel1.Controls.Add(Me.Label11)
        '
        'SpcAutorizacion_D_A.Panel2
        '
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.DpFechaAnulada)
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.BtnAnular)
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.ChxAnulada)
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.Label13)
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.TxtComentAnulada)
        Me.SpcAutorizacion_D_A.Panel2.Controls.Add(Me.Label15)
        Me.SpcAutorizacion_D_A.Size = New System.Drawing.Size(330, 177)
        Me.SpcAutorizacion_D_A.SplitterDistance = 88
        Me.SpcAutorizacion_D_A.SplitterWidth = 1
        Me.SpcAutorizacion_D_A.TabIndex = 35
        '
        'BtnDenegar
        '
        Me.BtnDenegar.Enabled = False
        Me.BtnDenegar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnDenegar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnDenegar.Image = CType(resources.GetObject("BtnDenegar.Image"), System.Drawing.Image)
        Me.BtnDenegar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDenegar.Location = New System.Drawing.Point(248, 56)
        Me.BtnDenegar.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.BtnDenegar.Name = "BtnDenegar"
        Me.BtnDenegar.Size = New System.Drawing.Size(75, 24)
        Me.BtnDenegar.TabIndex = 41
        Me.BtnDenegar.Text = "Denegar"
        Me.BtnDenegar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDenegar.UseVisualStyleBackColor = True
        '
        'DpFechaDenegada
        '
        Me.DpFechaDenegada.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaDenegada.Enabled = False
        Me.DpFechaDenegada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaDenegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaDenegada.Location = New System.Drawing.Point(88, 56)
        Me.DpFechaDenegada.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DpFechaDenegada.Name = "DpFechaDenegada"
        Me.DpFechaDenegada.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaDenegada.TabIndex = 36
        '
        'ChxDenegada
        '
        Me.ChxDenegada.AutoSize = True
        Me.ChxDenegada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxDenegada.ForeColor = System.Drawing.Color.Red
        Me.ChxDenegada.Location = New System.Drawing.Point(16, 10)
        Me.ChxDenegada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChxDenegada.Name = "ChxDenegada"
        Me.ChxDenegada.Size = New System.Drawing.Size(77, 20)
        Me.ChxDenegada.TabIndex = 35
        Me.ChxDenegada.Text = "Denegada"
        Me.ChxDenegada.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Comentario: "
        '
        'TxtComenDenegada
        '
        Me.TxtComenDenegada.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComenDenegada.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtComenDenegada.ForeColor = System.Drawing.Color.Navy
        Me.TxtComenDenegada.Location = New System.Drawing.Point(88, 32)
        Me.TxtComenDenegada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtComenDenegada.Name = "TxtComenDenegada"
        Me.TxtComenDenegada.ReadOnly = True
        Me.TxtComenDenegada.Size = New System.Drawing.Size(232, 22)
        Me.TxtComenDenegada.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 16)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Fecha:"
        '
        'DpFechaAnulada
        '
        Me.DpFechaAnulada.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaAnulada.CustomFormat = "dd-MMM-yyy"
        Me.DpFechaAnulada.Enabled = False
        Me.DpFechaAnulada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaAnulada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaAnulada.Location = New System.Drawing.Point(88, 56)
        Me.DpFechaAnulada.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DpFechaAnulada.Name = "DpFechaAnulada"
        Me.DpFechaAnulada.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaAnulada.TabIndex = 40
        '
        'BtnAnular
        '
        Me.BtnAnular.Enabled = False
        Me.BtnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAnular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnAnular.Image = CType(resources.GetObject("BtnAnular.Image"), System.Drawing.Image)
        Me.BtnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAnular.Location = New System.Drawing.Point(248, 56)
        Me.BtnAnular.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(75, 24)
        Me.BtnAnular.TabIndex = 40
        Me.BtnAnular.Text = "Anular"
        Me.BtnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAnular.UseVisualStyleBackColor = True
        '
        'ChxAnulada
        '
        Me.ChxAnulada.AutoSize = True
        Me.ChxAnulada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAnulada.ForeColor = System.Drawing.Color.Red
        Me.ChxAnulada.Location = New System.Drawing.Point(16, 10)
        Me.ChxAnulada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChxAnulada.Name = "ChxAnulada"
        Me.ChxAnulada.Size = New System.Drawing.Size(66, 20)
        Me.ChxAnulada.TabIndex = 38
        Me.ChxAnulada.Text = "Anulada"
        Me.ChxAnulada.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Comentario: "
        '
        'TxtComentAnulada
        '
        Me.TxtComentAnulada.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComentAnulada.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtComentAnulada.ForeColor = System.Drawing.Color.Navy
        Me.TxtComentAnulada.Location = New System.Drawing.Point(88, 32)
        Me.TxtComentAnulada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtComentAnulada.Name = "TxtComentAnulada"
        Me.TxtComentAnulada.ReadOnly = True
        Me.TxtComentAnulada.Size = New System.Drawing.Size(232, 22)
        Me.TxtComentAnulada.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 16)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Fecha:"
        '
        'lblNumeroSol
        '
        Me.lblNumeroSol.BackColor = System.Drawing.Color.Blue
        Me.lblNumeroSol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroSol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSol.ForeColor = System.Drawing.Color.Yellow
        Me.lblNumeroSol.Location = New System.Drawing.Point(472, 32)
        Me.lblNumeroSol.Name = "lblNumeroSol"
        Me.lblNumeroSol.Size = New System.Drawing.Size(80, 24)
        Me.lblNumeroSol.TabIndex = 33
        Me.lblNumeroSol.Text = "0"
        Me.lblNumeroSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(184, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 16)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Autoriza: "
        '
        'lblAutoriza1
        '
        Me.lblAutoriza1.BackColor = System.Drawing.Color.Blue
        Me.lblAutoriza1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoriza1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoriza1.ForeColor = System.Drawing.Color.White
        Me.lblAutoriza1.Location = New System.Drawing.Point(240, 8)
        Me.lblAutoriza1.Name = "lblAutoriza1"
        Me.lblAutoriza1.Size = New System.Drawing.Size(80, 20)
        Me.lblAutoriza1.TabIndex = 34
        Me.lblAutoriza1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(184, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 16)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Autoriza: "
        '
        'lblAutoriza2
        '
        Me.lblAutoriza2.BackColor = System.Drawing.Color.Blue
        Me.lblAutoriza2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoriza2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoriza2.ForeColor = System.Drawing.Color.White
        Me.lblAutoriza2.Location = New System.Drawing.Point(240, 7)
        Me.lblAutoriza2.Name = "lblAutoriza2"
        Me.lblAutoriza2.Size = New System.Drawing.Size(80, 20)
        Me.lblAutoriza2.TabIndex = 34
        Me.lblAutoriza2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(184, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 16)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Autoriza: "
        '
        'lblAutoriza3
        '
        Me.lblAutoriza3.BackColor = System.Drawing.Color.Blue
        Me.lblAutoriza3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoriza3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoriza3.ForeColor = System.Drawing.Color.White
        Me.lblAutoriza3.Location = New System.Drawing.Point(240, 8)
        Me.lblAutoriza3.Name = "lblAutoriza3"
        Me.lblAutoriza3.Size = New System.Drawing.Size(80, 20)
        Me.lblAutoriza3.TabIndex = 34
        Me.lblAutoriza3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmAutorizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 370)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.lblNumeroSol)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.CbxCompania)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CbxUsuarios)
        Me.Controls.Add(Me.Label12)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmAutorizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Autorización de Solicitudes"
        Me.SpcAutorizacion_1_2.Panel1.ResumeLayout(False)
        Me.SpcAutorizacion_1_2.Panel1.PerformLayout()
        Me.SpcAutorizacion_1_2.Panel2.ResumeLayout(False)
        Me.SpcAutorizacion_1_2.Panel2.PerformLayout()
        Me.SpcAutorizacion_1_2.ResumeLayout(False)
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.PlAutorizacion_3.ResumeLayout(False)
        Me.PlAutorizacion_3.PerformLayout()
        Me.SpcAutorizacion_D_A.Panel1.ResumeLayout(False)
        Me.SpcAutorizacion_D_A.Panel1.PerformLayout()
        Me.SpcAutorizacion_D_A.Panel2.ResumeLayout(False)
        Me.SpcAutorizacion_D_A.Panel2.PerformLayout()
        Me.SpcAutorizacion_D_A.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbxUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SpcAutorizacion_1_2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtComentario1 As System.Windows.Forms.TextBox
    Friend WithEvents ChxAutorizacionUno As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtComentario2 As System.Windows.Forms.TextBox
    Friend WithEvents ChxAutorizacionDos As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DpFechaA1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DpFechaA2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents SpcAutorizacion_D_A As System.Windows.Forms.SplitContainer
    Friend WithEvents DpFechaDenegada As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChxDenegada As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtComenDenegada As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DpFechaAnulada As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChxAnulada As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtComentAnulada As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PlAutorizacion_3 As System.Windows.Forms.Panel
    Friend WithEvents DpFechaA3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChxAutorizacionTres As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtComentario3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnAutorizacion1 As System.Windows.Forms.Button
    Friend WithEvents BtnAutorizacion2 As System.Windows.Forms.Button
    Friend WithEvents BtnAutorizacion3 As System.Windows.Forms.Button
    Friend WithEvents BtnDenegar As System.Windows.Forms.Button
    Friend WithEvents BtnAnular As System.Windows.Forms.Button
    Friend WithEvents lblNumeroSol As System.Windows.Forms.Label
    Friend WithEvents lblAutoriza1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblAutoriza2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblAutoriza3 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
