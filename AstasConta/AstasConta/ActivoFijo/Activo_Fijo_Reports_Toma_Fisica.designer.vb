<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Reports_Toma_Fisica
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
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radCatAmbos = New System.Windows.Forms.RadioButton
        Me.radNoDepreciable = New System.Windows.Forms.RadioButton
        Me.radDepreciable = New System.Windows.Forms.RadioButton
        Me.dgvClasificacion = New System.Windows.Forms.DataGridView
        Me.dgvTipoBien = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvBienesSeleccionar = New System.Windows.Forms.DataGridView
        Me.txtDescripcionBien = New System.Windows.Forms.TextBox
        Me.chkBienesAll = New System.Windows.Forms.CheckBox
        Me.chkAllTpoBien = New System.Windows.Forms.CheckBox
        Me.chkAllClasificacion = New System.Windows.Forms.CheckBox
        Me.dgvUbicacion = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkAllUbica = New System.Windows.Forms.CheckBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoBien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBienesSeleccionar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.radCatAmbos)
        Me.GroupBox2.Controls.Add(Me.radNoDepreciable)
        Me.GroupBox2.Controls.Add(Me.radDepreciable)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(14, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 48)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Categoría"
        '
        'radCatAmbos
        '
        Me.radCatAmbos.AutoSize = True
        Me.radCatAmbos.BackColor = System.Drawing.Color.Transparent
        Me.radCatAmbos.Checked = True
        Me.radCatAmbos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radCatAmbos.ForeColor = System.Drawing.Color.Navy
        Me.radCatAmbos.Location = New System.Drawing.Point(235, 19)
        Me.radCatAmbos.Name = "radCatAmbos"
        Me.radCatAmbos.Size = New System.Drawing.Size(69, 20)
        Me.radCatAmbos.TabIndex = 9
        Me.radCatAmbos.TabStop = True
        Me.radCatAmbos.Text = "Ambos"
        Me.radCatAmbos.UseVisualStyleBackColor = False
        '
        'radNoDepreciable
        '
        Me.radNoDepreciable.AutoSize = True
        Me.radNoDepreciable.BackColor = System.Drawing.Color.Transparent
        Me.radNoDepreciable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radNoDepreciable.ForeColor = System.Drawing.Color.Navy
        Me.radNoDepreciable.Location = New System.Drawing.Point(109, 19)
        Me.radNoDepreciable.Name = "radNoDepreciable"
        Me.radNoDepreciable.Size = New System.Drawing.Size(124, 20)
        Me.radNoDepreciable.TabIndex = 6
        Me.radNoDepreciable.Text = "No Depreciable"
        Me.radNoDepreciable.UseVisualStyleBackColor = False
        '
        'radDepreciable
        '
        Me.radDepreciable.AutoSize = True
        Me.radDepreciable.BackColor = System.Drawing.Color.Transparent
        Me.radDepreciable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radDepreciable.ForeColor = System.Drawing.Color.Navy
        Me.radDepreciable.Location = New System.Drawing.Point(8, 19)
        Me.radDepreciable.Name = "radDepreciable"
        Me.radDepreciable.Size = New System.Drawing.Size(103, 20)
        Me.radDepreciable.TabIndex = 5
        Me.radDepreciable.Text = "Depreciable"
        Me.radDepreciable.UseVisualStyleBackColor = False
        '
        'dgvClasificacion
        '
        Me.dgvClasificacion.AllowUserToAddRows = False
        Me.dgvClasificacion.AllowUserToDeleteRows = False
        Me.dgvClasificacion.AllowUserToResizeColumns = False
        Me.dgvClasificacion.AllowUserToResizeRows = False
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvClasificacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvClasificacion.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClasificacion.DefaultCellStyle = DataGridViewCellStyle50
        Me.dgvClasificacion.Location = New System.Drawing.Point(17, 75)
        Me.dgvClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvClasificacion.Name = "dgvClasificacion"
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle51.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle51.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle51.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClasificacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle51
        Me.dgvClasificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClasificacion.Size = New System.Drawing.Size(312, 190)
        Me.dgvClasificacion.TabIndex = 19
        '
        'dgvTipoBien
        '
        Me.dgvTipoBien.AllowUserToAddRows = False
        Me.dgvTipoBien.AllowUserToDeleteRows = False
        Me.dgvTipoBien.AllowUserToResizeColumns = False
        Me.dgvTipoBien.AllowUserToResizeRows = False
        DataGridViewCellStyle52.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvTipoBien.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle52
        Me.dgvTipoBien.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvTipoBien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle53.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoBien.DefaultCellStyle = DataGridViewCellStyle53
        Me.dgvTipoBien.Location = New System.Drawing.Point(335, 75)
        Me.dgvTipoBien.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvTipoBien.Name = "dgvTipoBien"
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle54.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle54.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle54.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoBien.RowHeadersDefaultCellStyle = DataGridViewCellStyle54
        Me.dgvTipoBien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoBien.Size = New System.Drawing.Size(420, 190)
        Me.dgvTipoBien.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(141, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Clasificación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(503, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Tipo de Bien"
        '
        'dgvBienesSeleccionar
        '
        Me.dgvBienesSeleccionar.AllowUserToAddRows = False
        Me.dgvBienesSeleccionar.AllowUserToDeleteRows = False
        Me.dgvBienesSeleccionar.AllowUserToResizeColumns = False
        Me.dgvBienesSeleccionar.AllowUserToResizeRows = False
        DataGridViewCellStyle55.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvBienesSeleccionar.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle55
        Me.dgvBienesSeleccionar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBienesSeleccionar.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvBienesSeleccionar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle56.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle56.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBienesSeleccionar.DefaultCellStyle = DataGridViewCellStyle56
        Me.dgvBienesSeleccionar.Location = New System.Drawing.Point(18, 305)
        Me.dgvBienesSeleccionar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvBienesSeleccionar.Name = "dgvBienesSeleccionar"
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle57.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle57.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBienesSeleccionar.RowHeadersDefaultCellStyle = DataGridViewCellStyle57
        Me.dgvBienesSeleccionar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBienesSeleccionar.Size = New System.Drawing.Size(1125, 220)
        Me.dgvBienesSeleccionar.TabIndex = 27
        '
        'txtDescripcionBien
        '
        Me.txtDescripcionBien.Location = New System.Drawing.Point(659, 279)
        Me.txtDescripcionBien.Name = "txtDescripcionBien"
        Me.txtDescripcionBien.Size = New System.Drawing.Size(274, 20)
        Me.txtDescripcionBien.TabIndex = 29
        '
        'chkBienesAll
        '
        Me.chkBienesAll.AutoSize = True
        Me.chkBienesAll.BackColor = System.Drawing.Color.Transparent
        Me.chkBienesAll.ForeColor = System.Drawing.Color.Navy
        Me.chkBienesAll.Location = New System.Drawing.Point(18, 281)
        Me.chkBienesAll.Name = "chkBienesAll"
        Me.chkBienesAll.Size = New System.Drawing.Size(159, 17)
        Me.chkBienesAll.TabIndex = 30
        Me.chkBienesAll.Text = "Seleccione todos los Bienes"
        Me.chkBienesAll.UseVisualStyleBackColor = False
        '
        'chkAllTpoBien
        '
        Me.chkAllTpoBien.AutoSize = True
        Me.chkAllTpoBien.BackColor = System.Drawing.Color.Transparent
        Me.chkAllTpoBien.ForeColor = System.Drawing.Color.Navy
        Me.chkAllTpoBien.Location = New System.Drawing.Point(335, 57)
        Me.chkAllTpoBien.Name = "chkAllTpoBien"
        Me.chkAllTpoBien.Size = New System.Drawing.Size(56, 17)
        Me.chkAllTpoBien.TabIndex = 33
        Me.chkAllTpoBien.Text = "Todos"
        Me.chkAllTpoBien.UseVisualStyleBackColor = False
        '
        'chkAllClasificacion
        '
        Me.chkAllClasificacion.AutoSize = True
        Me.chkAllClasificacion.BackColor = System.Drawing.Color.Transparent
        Me.chkAllClasificacion.ForeColor = System.Drawing.Color.Navy
        Me.chkAllClasificacion.Location = New System.Drawing.Point(17, 57)
        Me.chkAllClasificacion.Name = "chkAllClasificacion"
        Me.chkAllClasificacion.Size = New System.Drawing.Size(56, 17)
        Me.chkAllClasificacion.TabIndex = 32
        Me.chkAllClasificacion.Text = "Todos"
        Me.chkAllClasificacion.UseVisualStyleBackColor = False
        '
        'dgvUbicacion
        '
        Me.dgvUbicacion.AllowUserToAddRows = False
        Me.dgvUbicacion.AllowUserToDeleteRows = False
        Me.dgvUbicacion.AllowUserToResizeColumns = False
        Me.dgvUbicacion.AllowUserToResizeRows = False
        DataGridViewCellStyle58.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvUbicacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle58
        Me.dgvUbicacion.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvUbicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle59.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle59.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUbicacion.DefaultCellStyle = DataGridViewCellStyle59
        Me.dgvUbicacion.Location = New System.Drawing.Point(761, 75)
        Me.dgvUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvUbicacion.Name = "dgvUbicacion"
        DataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle60.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle60.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUbicacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle60
        Me.dgvUbicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUbicacion.Size = New System.Drawing.Size(382, 190)
        Me.dgvUbicacion.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(921, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Ubicación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(349, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(305, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Haga busquedas por Códigos por Descripción o por Ubicación:"
        '
        'chkAllUbica
        '
        Me.chkAllUbica.AutoSize = True
        Me.chkAllUbica.BackColor = System.Drawing.Color.Transparent
        Me.chkAllUbica.Checked = True
        Me.chkAllUbica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllUbica.ForeColor = System.Drawing.Color.Navy
        Me.chkAllUbica.Location = New System.Drawing.Point(761, 55)
        Me.chkAllUbica.Name = "chkAllUbica"
        Me.chkAllUbica.Size = New System.Drawing.Size(56, 17)
        Me.chkAllUbica.TabIndex = 46
        Me.chkAllUbica.Text = "Todos"
        Me.chkAllUbica.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(938, 278)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(58, 23)
        Me.btnReset.TabIndex = 47
        Me.btnReset.Text = "Resetear"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(542, 15)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(69, 32)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(332, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Fecha Impresion:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(426, 21)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(110, 20)
        Me.dtpHasta.TabIndex = 48
        '
        'Activo_Fijo_Reports_Toma_Fisica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 538)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.chkAllUbica)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkAllTpoBien)
        Me.Controls.Add(Me.chkAllClasificacion)
        Me.Controls.Add(Me.dgvUbicacion)
        Me.Controls.Add(Me.dgvClasificacion)
        Me.Controls.Add(Me.chkBienesAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescripcionBien)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvBienesSeleccionar)
        Me.Controls.Add(Me.dgvTipoBien)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Activo_Fijo_Reports_Toma_Fisica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activo Fijo - Reporte Toma Fisica de Inventarios"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipoBien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBienesSeleccionar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radNoDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents radDepreciable As System.Windows.Forms.RadioButton
    Friend WithEvents radCatAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents dgvClasificacion As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipoBien As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvBienesSeleccionar As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescripcionBien As System.Windows.Forms.TextBox
    Friend WithEvents chkBienesAll As System.Windows.Forms.CheckBox
    Friend WithEvents dgvUbicacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAllTpoBien As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllClasificacion As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAllUbica As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
End Class
