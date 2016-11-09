<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Cierre_Periodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Cierre_Periodo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRevertir = New System.Windows.Forms.Button
        Me.pB1 = New System.Windows.Forms.ProgressBar
        Me.txt_Nota = New System.Windows.Forms.TextBox
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.NumericUpDown_Mes = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Btn_Buscar_Movimiento = New System.Windows.Forms.Button
        Me.Txt_tipo_movimiento_numero = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        Me.Bw1 = New System.ComponentModel.BackgroundWorker
        Me.Bw2 = New System.ComponentModel.BackgroundWorker
        Me.BwRevertirCierre = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnRevertir)
        Me.GroupBox1.Controls.Add(Me.pB1)
        Me.GroupBox1.Controls.Add(Me.txt_Nota)
        Me.GroupBox1.Controls.Add(Me.btnProcesar)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown_Mes)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.Btn_Buscar_Movimiento)
        Me.GroupBox1.Controls.Add(Me.Txt_tipo_movimiento_numero)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1026, 210)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Apertura de Inventario"
        '
        'btnRevertir
        '
        Me.btnRevertir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.btnRevertir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRevertir.Image = Global.ASTAS.My.Resources.Resources.down
        Me.btnRevertir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRevertir.Location = New System.Drawing.Point(623, 135)
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(89, 40)
        Me.btnRevertir.TabIndex = 100
        Me.btnRevertir.Text = "&Revertir Cierre"
        Me.btnRevertir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRevertir.UseVisualStyleBackColor = True
        '
        'pB1
        '
        Me.pB1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pB1.Location = New System.Drawing.Point(3, 178)
        Me.pB1.Name = "pB1"
        Me.pB1.Size = New System.Drawing.Size(1020, 29)
        Me.pB1.Step = 1
        Me.pB1.TabIndex = 99
        '
        'txt_Nota
        '
        Me.txt_Nota.BackColor = System.Drawing.Color.Yellow
        Me.txt_Nota.Location = New System.Drawing.Point(734, 20)
        Me.txt_Nota.Multiline = True
        Me.txt_Nota.Name = "txt_Nota"
        Me.txt_Nota.Size = New System.Drawing.Size(199, 142)
        Me.txt_Nota.TabIndex = 98
        Me.txt_Nota.Text = "Nota:                                         . Espere unos segundos mientras se " & _
            "realiza el cierre de mes."
        Me.txt_Nota.Visible = False
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(623, 101)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(89, 33)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 20)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(171, 148)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 97
        Me.pbImagen.TabStop = False
        '
        'NumericUpDown_Mes
        '
        Me.NumericUpDown_Mes.CustomFormat = "MMMM - yyyy"
        Me.NumericUpDown_Mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.NumericUpDown_Mes.Location = New System.Drawing.Point(281, 107)
        Me.NumericUpDown_Mes.Name = "NumericUpDown_Mes"
        Me.NumericUpDown_Mes.Size = New System.Drawing.Size(155, 22)
        Me.NumericUpDown_Mes.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(600, 76)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(281, 21)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(432, 22)
        Me.txtCompañia.TabIndex = 82
        '
        'Btn_Buscar_Movimiento
        '
        Me.Btn_Buscar_Movimiento.Image = CType(resources.GetObject("Btn_Buscar_Movimiento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Movimiento.Location = New System.Drawing.Point(442, 101)
        Me.Btn_Buscar_Movimiento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Buscar_Movimiento.Name = "Btn_Buscar_Movimiento"
        Me.Btn_Buscar_Movimiento.Size = New System.Drawing.Size(24, 30)
        Me.Btn_Buscar_Movimiento.TabIndex = 3
        Me.Btn_Buscar_Movimiento.UseVisualStyleBackColor = True
        '
        'Txt_tipo_movimiento_numero
        '
        Me.Txt_tipo_movimiento_numero.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_tipo_movimiento_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tipo_movimiento_numero.ForeColor = System.Drawing.Color.Navy
        Me.Txt_tipo_movimiento_numero.Location = New System.Drawing.Point(281, 78)
        Me.Txt_tipo_movimiento_numero.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_tipo_movimiento_numero.Name = "Txt_tipo_movimiento_numero"
        Me.Txt_tipo_movimiento_numero.Size = New System.Drawing.Size(155, 22)
        Me.Txt_tipo_movimiento_numero.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(185, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "N° Movimiento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(185, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Aperturar Mes :"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(281, 48)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(185, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(185, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Compañía :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(493, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha de cierre:"
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.AllowUserToDeleteRows = False
        Me.dgvMovtos.AllowUserToResizeColumns = False
        Me.dgvMovtos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvMovtos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovtos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovtos.Location = New System.Drawing.Point(0, 210)
        Me.dgvMovtos.MultiSelect = False
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(1026, 236)
        Me.dgvMovtos.TabIndex = 136
        '
        'Bw1
        '
        Me.Bw1.WorkerReportsProgress = True
        '
        'Bw2
        '
        Me.Bw2.WorkerReportsProgress = True
        Me.Bw2.WorkerSupportsCancellation = True
        '
        'BwRevertirCierre
        '
        '
        'Inventario_Cierre_Periodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 446)
        Me.Controls.Add(Me.dgvMovtos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_Cierre_Periodo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Cierre_Periodo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Buscar_Movimiento As System.Windows.Forms.Button
    Friend WithEvents Txt_tipo_movimiento_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents NumericUpDown_Mes As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_Nota As System.Windows.Forms.TextBox
    Friend WithEvents pB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Bw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnRevertir As System.Windows.Forms.Button
    Friend WithEvents BwRevertirCierre As System.ComponentModel.BackgroundWorker
End Class
