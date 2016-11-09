<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cinta_Auditora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cinta_Auditora))
        Me.Cierre_Apertura_Grid = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gbAperturaCaja = New System.Windows.Forms.GroupBox
        Me.lblCantTKT = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtInicial = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbTo2Tiempos = New System.Windows.Forms.CheckBox
        Me.PB1 = New System.Windows.Forms.ProgressBar
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnCargar = New System.Windows.Forms.Button
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.cbSeleccioneCaja = New System.Windows.Forms.ComboBox
        Me.cbTiempoComida = New System.Windows.Forms.ComboBox
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblSeleccioneCaja = New System.Windows.Forms.Label
        Me.lblFechaTrabajo = New System.Windows.Forms.Label
        Me.lblTiempoComida = New System.Windows.Forms.Label
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Bw1 = New System.ComponentModel.BackgroundWorker
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbAperturaCaja.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cierre_Apertura_Grid
        '
        Me.Cierre_Apertura_Grid.AllowUserToAddRows = False
        Me.Cierre_Apertura_Grid.BackgroundColor = System.Drawing.Color.White
        Me.Cierre_Apertura_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Cierre_Apertura_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cierre_Apertura_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cierre_Apertura_Grid.Location = New System.Drawing.Point(0, 247)
        Me.Cierre_Apertura_Grid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cierre_Apertura_Grid.MultiSelect = False
        Me.Cierre_Apertura_Grid.Name = "Cierre_Apertura_Grid"
        Me.Cierre_Apertura_Grid.ReadOnly = True
        Me.Cierre_Apertura_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Cierre_Apertura_Grid.Size = New System.Drawing.Size(1012, 404)
        Me.Cierre_Apertura_Grid.TabIndex = 84
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.gbAperturaCaja)
        Me.GroupBox2.Controls.Add(Me.pbImagen)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1012, 247)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        '
        'gbAperturaCaja
        '
        Me.gbAperturaCaja.Controls.Add(Me.lblCantTKT)
        Me.gbAperturaCaja.Controls.Add(Me.btnCancelar)
        Me.gbAperturaCaja.Controls.Add(Me.txtInicial)
        Me.gbAperturaCaja.Controls.Add(Me.Label4)
        Me.gbAperturaCaja.Controls.Add(Me.PictureBox1)
        Me.gbAperturaCaja.Controls.Add(Me.Label2)
        Me.gbAperturaCaja.Controls.Add(Me.Label3)
        Me.gbAperturaCaja.Controls.Add(Me.rbTo2Tiempos)
        Me.gbAperturaCaja.Controls.Add(Me.PB1)
        Me.gbAperturaCaja.Controls.Add(Me.btnImprimir)
        Me.gbAperturaCaja.Controls.Add(Me.btnCargar)
        Me.gbAperturaCaja.Controls.Add(Me.txtCompañia)
        Me.gbAperturaCaja.Controls.Add(Me.Label1)
        Me.gbAperturaCaja.Controls.Add(Me.dtpFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.cbSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.cbTiempoComida)
        Me.gbAperturaCaja.Controls.Add(Me.cbCafeteria)
        Me.gbAperturaCaja.Controls.Add(Me.lblSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.lblFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.lblTiempoComida)
        Me.gbAperturaCaja.Controls.Add(Me.lblCafeteria)
        Me.gbAperturaCaja.Location = New System.Drawing.Point(126, 15)
        Me.gbAperturaCaja.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbAperturaCaja.Name = "gbAperturaCaja"
        Me.gbAperturaCaja.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbAperturaCaja.Size = New System.Drawing.Size(507, 219)
        Me.gbAperturaCaja.TabIndex = 14
        Me.gbAperturaCaja.TabStop = False
        Me.gbAperturaCaja.Text = "Parámetros Generales"
        '
        'lblCantTKT
        '
        Me.lblCantTKT.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantTKT.ForeColor = System.Drawing.Color.DarkRed
        Me.lblCantTKT.Location = New System.Drawing.Point(4, 155)
        Me.lblCantTKT.Name = "lblCantTKT"
        Me.lblCantTKT.Size = New System.Drawing.Size(91, 24)
        Me.lblCantTKT.TabIndex = 138
        Me.lblCantTKT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Brown
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(264, 139)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 26)
        Me.btnCancelar.TabIndex = 137
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Visible = False
        '
        'txtInicial
        '
        Me.txtInicial.Location = New System.Drawing.Point(374, 166)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(75, 22)
        Me.txtInicial.TabIndex = 136
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Iniciar en el Ticket No."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(453, 151)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 80
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(98, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 22)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(322, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 15)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Imprimiendo Cinta Auditora"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'rbTo2Tiempos
        '
        Me.rbTo2Tiempos.AutoSize = True
        Me.rbTo2Tiempos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbTo2Tiempos.Location = New System.Drawing.Point(258, 118)
        Me.rbTo2Tiempos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbTo2Tiempos.Name = "rbTo2Tiempos"
        Me.rbTo2Tiempos.Size = New System.Drawing.Size(57, 20)
        Me.rbTo2Tiempos.TabIndex = 5
        Me.rbTo2Tiempos.Text = "Todos"
        Me.rbTo2Tiempos.UseVisualStyleBackColor = True
        Me.rbTo2Tiempos.Visible = False
        '
        'PB1
        '
        Me.PB1.Location = New System.Drawing.Point(3, 192)
        Me.PB1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(495, 20)
        Me.PB1.TabIndex = 80
        Me.PB1.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(179, 151)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(76, 33)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(97, 151)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(76, 33)
        Me.btnCargar.TabIndex = 6
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(97, 20)
        Me.txtCompañia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(376, 22)
        Me.txtCompañia.TabIndex = 87
        Me.txtCompañia.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(366, 87)
        Me.dtpFechaTrabajo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(101, 22)
        Me.dtpFechaTrabajo.TabIndex = 2
        '
        'cbSeleccioneCaja
        '
        Me.cbSeleccioneCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeleccioneCaja.FormattingEnabled = True
        Me.cbSeleccioneCaja.Location = New System.Drawing.Point(97, 85)
        Me.cbSeleccioneCaja.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbSeleccioneCaja.Name = "cbSeleccioneCaja"
        Me.cbSeleccioneCaja.Size = New System.Drawing.Size(158, 24)
        Me.cbSeleccioneCaja.TabIndex = 3
        '
        'cbTiempoComida
        '
        Me.cbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTiempoComida.FormattingEnabled = True
        Me.cbTiempoComida.Location = New System.Drawing.Point(97, 118)
        Me.cbTiempoComida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbTiempoComida.Name = "cbTiempoComida"
        Me.cbTiempoComida.Size = New System.Drawing.Size(158, 24)
        Me.cbTiempoComida.TabIndex = 1
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(97, 52)
        Me.cbCafeteria.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(376, 24)
        Me.cbCafeteria.TabIndex = 0
        '
        'lblSeleccioneCaja
        '
        Me.lblSeleccioneCaja.AutoSize = True
        Me.lblSeleccioneCaja.Location = New System.Drawing.Point(6, 85)
        Me.lblSeleccioneCaja.Name = "lblSeleccioneCaja"
        Me.lblSeleccioneCaja.Size = New System.Drawing.Size(33, 16)
        Me.lblSeleccioneCaja.TabIndex = 3
        Me.lblSeleccioneCaja.Text = "Caja:"
        '
        'lblFechaTrabajo
        '
        Me.lblFechaTrabajo.AutoSize = True
        Me.lblFechaTrabajo.Location = New System.Drawing.Point(261, 90)
        Me.lblFechaTrabajo.Name = "lblFechaTrabajo"
        Me.lblFechaTrabajo.Size = New System.Drawing.Size(99, 16)
        Me.lblFechaTrabajo.TabIndex = 2
        Me.lblFechaTrabajo.Text = "Fecha de Trabajo :"
        '
        'lblTiempoComida
        '
        Me.lblTiempoComida.AutoSize = True
        Me.lblTiempoComida.Location = New System.Drawing.Point(6, 118)
        Me.lblTiempoComida.Name = "lblTiempoComida"
        Me.lblTiempoComida.Size = New System.Drawing.Size(88, 16)
        Me.lblTiempoComida.TabIndex = 1
        Me.lblTiempoComida.Text = "Tiempo Comida :"
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(6, 52)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(56, 16)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 23)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(114, 180)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 79
        Me.pbImagen.TabStop = False
        '
        'Bw1
        '
        Me.Bw1.WorkerReportsProgress = True
        Me.Bw1.WorkerSupportsCancellation = True
        '
        'Cinta_Auditora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 651)
        Me.Controls.Add(Me.Cierre_Apertura_Grid)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cinta_Auditora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria - Reimpresión Cinta Auditora"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.gbAperturaCaja.ResumeLayout(False)
        Me.gbAperturaCaja.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cierre_Apertura_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gbAperturaCaja As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbTo2Tiempos As System.Windows.Forms.CheckBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbSeleccioneCaja As System.Windows.Forms.ComboBox
    Friend WithEvents cbTiempoComida As System.Windows.Forms.ComboBox
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeleccioneCaja As System.Windows.Forms.Label
    Friend WithEvents lblFechaTrabajo As System.Windows.Forms.Label
    Friend WithEvents lblTiempoComida As System.Windows.Forms.Label
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCantTKT As System.Windows.Forms.Label
End Class
