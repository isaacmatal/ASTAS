<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Correlativos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Correlativos))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Cierre_Apertura_Grid = New System.Windows.Forms.DataGridView
        Me.gbAperturaCaja = New System.Windows.Forms.GroupBox
        Me.btnUnLok = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpFechaAutoriza = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtResolucion = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCorrelativoActual = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.txtCorrelativoNotificacion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkActiva = New System.Windows.Forms.CheckBox
        Me.txtCorrelativoFinal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.txtDineroInicial = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDineroInicial = New System.Windows.Forms.Label
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.cbSeleccioneCaja = New System.Windows.Forms.ComboBox
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblSeleccioneCaja = New System.Windows.Forms.Label
        Me.lblFechaTrabajo = New System.Windows.Forms.Label
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAperturaCaja.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 16)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(161, 199)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 82
        Me.pbImagen.TabStop = False
        '
        'Cierre_Apertura_Grid
        '
        Me.Cierre_Apertura_Grid.AllowUserToAddRows = False
        Me.Cierre_Apertura_Grid.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Cierre_Apertura_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cierre_Apertura_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cierre_Apertura_Grid.Location = New System.Drawing.Point(3, 16)
        Me.Cierre_Apertura_Grid.Name = "Cierre_Apertura_Grid"
        Me.Cierre_Apertura_Grid.ReadOnly = True
        Me.Cierre_Apertura_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Cierre_Apertura_Grid.Size = New System.Drawing.Size(874, 231)
        Me.Cierre_Apertura_Grid.TabIndex = 81
        '
        'gbAperturaCaja
        '
        Me.gbAperturaCaja.Controls.Add(Me.btnUnLok)
        Me.gbAperturaCaja.Controls.Add(Me.Label8)
        Me.gbAperturaCaja.Controls.Add(Me.pbImagen)
        Me.gbAperturaCaja.Controls.Add(Me.dtpFechaAutoriza)
        Me.gbAperturaCaja.Controls.Add(Me.Label7)
        Me.gbAperturaCaja.Controls.Add(Me.txtResolucion)
        Me.gbAperturaCaja.Controls.Add(Me.Label6)
        Me.gbAperturaCaja.Controls.Add(Me.txtSerie)
        Me.gbAperturaCaja.Controls.Add(Me.Label5)
        Me.gbAperturaCaja.Controls.Add(Me.txtCorrelativoActual)
        Me.gbAperturaCaja.Controls.Add(Me.Label4)
        Me.gbAperturaCaja.Controls.Add(Me.btnLimpiar)
        Me.gbAperturaCaja.Controls.Add(Me.btnGuardar)
        Me.gbAperturaCaja.Controls.Add(Me.btnEliminar)
        Me.gbAperturaCaja.Controls.Add(Me.txtCorrelativoNotificacion)
        Me.gbAperturaCaja.Controls.Add(Me.Label3)
        Me.gbAperturaCaja.Controls.Add(Me.chkActiva)
        Me.gbAperturaCaja.Controls.Add(Me.txtCorrelativoFinal)
        Me.gbAperturaCaja.Controls.Add(Me.Label2)
        Me.gbAperturaCaja.Controls.Add(Me.txtCompañia)
        Me.gbAperturaCaja.Controls.Add(Me.txtDineroInicial)
        Me.gbAperturaCaja.Controls.Add(Me.Label1)
        Me.gbAperturaCaja.Controls.Add(Me.lblDineroInicial)
        Me.gbAperturaCaja.Controls.Add(Me.dtpFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.cbSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.cbCafeteria)
        Me.gbAperturaCaja.Controls.Add(Me.lblSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.lblFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.lblCafeteria)
        Me.gbAperturaCaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbAperturaCaja.Location = New System.Drawing.Point(0, 0)
        Me.gbAperturaCaja.Name = "gbAperturaCaja"
        Me.gbAperturaCaja.Size = New System.Drawing.Size(880, 223)
        Me.gbAperturaCaja.TabIndex = 80
        Me.gbAperturaCaja.TabStop = False
        Me.gbAperturaCaja.Text = "Detalles"
        '
        'btnUnLok
        '
        Me.btnUnLok.Location = New System.Drawing.Point(696, 36)
        Me.btnUnLok.Name = "btnUnLok"
        Me.btnUnLok.Size = New System.Drawing.Size(75, 23)
        Me.btnUnLok.TabIndex = 135
        Me.btnUnLok.Text = "Desbloquear"
        Me.btnUnLok.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(297, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(393, 22)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'dtpFechaAutoriza
        '
        Me.dtpFechaAutoriza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAutoriza.Location = New System.Drawing.Point(601, 129)
        Me.dtpFechaAutoriza.Name = "dtpFechaAutoriza"
        Me.dtpFechaAutoriza.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAutoriza.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(479, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 13)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Fecha de Autorizacion :"
        '
        'txtResolucion
        '
        Me.txtResolucion.Location = New System.Drawing.Point(579, 85)
        Me.txtResolucion.Name = "txtResolucion"
        Me.txtResolucion.Size = New System.Drawing.Size(108, 20)
        Me.txtResolucion.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(479, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "No. de Resolución:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(601, 151)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(86, 20)
        Me.txtSerie.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(479, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Serie/Prefijo :"
        '
        'txtCorrelativoActual
        '
        Me.txtCorrelativoActual.Location = New System.Drawing.Point(300, 129)
        Me.txtCorrelativoActual.Name = "txtCorrelativoActual"
        Me.txtCorrelativoActual.Size = New System.Drawing.Size(101, 20)
        Me.txtCorrelativoActual.TabIndex = 7
        Me.txtCorrelativoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(172, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Correlativo Actual :"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(458, 61)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(486, 61)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(514, 61)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 13
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtCorrelativoNotificacion
        '
        Me.txtCorrelativoNotificacion.Location = New System.Drawing.Point(300, 151)
        Me.txtCorrelativoNotificacion.Name = "txtCorrelativoNotificacion"
        Me.txtCorrelativoNotificacion.Size = New System.Drawing.Size(101, 20)
        Me.txtCorrelativoNotificacion.TabIndex = 9
        Me.txtCorrelativoNotificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Correlativo Notificacion :"
        '
        'chkActiva
        '
        Me.chkActiva.AutoSize = True
        Me.chkActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActiva.ForeColor = System.Drawing.Color.Red
        Me.chkActiva.Location = New System.Drawing.Point(625, 174)
        Me.chkActiva.Name = "chkActiva"
        Me.chkActiva.Size = New System.Drawing.Size(62, 17)
        Me.chkActiva.TabIndex = 11
        Me.chkActiva.Text = "Activa"
        Me.chkActiva.UseVisualStyleBackColor = True
        '
        'txtCorrelativoFinal
        '
        Me.txtCorrelativoFinal.Location = New System.Drawing.Point(301, 107)
        Me.txtCorrelativoFinal.Name = "txtCorrelativoFinal"
        Me.txtCorrelativoFinal.Size = New System.Drawing.Size(101, 20)
        Me.txtCorrelativoFinal.TabIndex = 5
        Me.txtCorrelativoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Correlativo Final :"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(301, 16)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(387, 20)
        Me.txtCompañia.TabIndex = 0
        Me.txtCompañia.Visible = False
        '
        'txtDineroInicial
        '
        Me.txtDineroInicial.Location = New System.Drawing.Point(301, 85)
        Me.txtDineroInicial.Name = "txtDineroInicial"
        Me.txtDineroInicial.Size = New System.Drawing.Size(101, 20)
        Me.txtDineroInicial.TabIndex = 3
        Me.txtDineroInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(172, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'lblDineroInicial
        '
        Me.lblDineroInicial.AutoSize = True
        Me.lblDineroInicial.Location = New System.Drawing.Point(172, 88)
        Me.lblDineroInicial.Name = "lblDineroInicial"
        Me.lblDineroInicial.Size = New System.Drawing.Size(93, 13)
        Me.lblDineroInicial.TabIndex = 16
        Me.lblDineroInicial.Text = "Correlativo Inicial :"
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(601, 107)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaTrabajo.TabIndex = 6
        '
        'cbSeleccioneCaja
        '
        Me.cbSeleccioneCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeleccioneCaja.FormattingEnabled = True
        Me.cbSeleccioneCaja.Location = New System.Drawing.Point(301, 61)
        Me.cbSeleccioneCaja.Name = "cbSeleccioneCaja"
        Me.cbSeleccioneCaja.Size = New System.Drawing.Size(153, 21)
        Me.cbSeleccioneCaja.TabIndex = 2
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(301, 38)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(387, 21)
        Me.cbCafeteria.TabIndex = 1
        '
        'lblSeleccioneCaja
        '
        Me.lblSeleccioneCaja.AutoSize = True
        Me.lblSeleccioneCaja.Location = New System.Drawing.Point(172, 64)
        Me.lblSeleccioneCaja.Name = "lblSeleccioneCaja"
        Me.lblSeleccioneCaja.Size = New System.Drawing.Size(31, 13)
        Me.lblSeleccioneCaja.TabIndex = 3
        Me.lblSeleccioneCaja.Text = "Caja:"
        '
        'lblFechaTrabajo
        '
        Me.lblFechaTrabajo.AutoSize = True
        Me.lblFechaTrabajo.Location = New System.Drawing.Point(479, 112)
        Me.lblFechaTrabajo.Name = "lblFechaTrabajo"
        Me.lblFechaTrabajo.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaTrabajo.TabIndex = 2
        Me.lblFechaTrabajo.Text = "Fecha de Resolución :"
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(172, 41)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(57, 13)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cierre_Apertura_Grid)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 223)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(880, 250)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        '
        'Cafeteria_Correlativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 473)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbAperturaCaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Cafeteria_Correlativos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Correlativos"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAperturaCaja.ResumeLayout(False)
        Me.gbAperturaCaja.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Cierre_Apertura_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents gbAperturaCaja As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents txtDineroInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDineroInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbSeleccioneCaja As System.Windows.Forms.ComboBox
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeleccioneCaja As System.Windows.Forms.Label
    Friend WithEvents lblFechaTrabajo As System.Windows.Forms.Label
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents chkActiva As System.Windows.Forms.CheckBox
    Friend WithEvents txtCorrelativoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativoNotificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtCorrelativoActual As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtResolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAutoriza As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUnLok As System.Windows.Forms.Button
End Class
