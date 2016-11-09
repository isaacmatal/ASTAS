<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Permisos_Tickets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_Permisos_Tickets))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblFecha = New System.Windows.Forms.Label
        Me.txtNumeroTckets = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.lblFechaTrabajo = New System.Windows.Forms.Label
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCajas = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.txtNumeroTckets)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.lblFechaTrabajo)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCajas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(844, 210)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Permisos para anulación de Tickets"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(243, 136)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(387, 28)
        Me.lblFecha.TabIndex = 136
        Me.lblFecha.Text = "fecha"
        '
        'txtNumeroTckets
        '
        Me.txtNumeroTckets.Location = New System.Drawing.Point(246, 100)
        Me.txtNumeroTckets.MaxLength = 10
        Me.txtNumeroTckets.Name = "txtNumeroTckets"
        Me.txtNumeroTckets.Size = New System.Drawing.Size(171, 22)
        Me.txtNumeroTckets.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(242, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(393, 22)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(12, 21)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(127, 177)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 14
        Me.pbImagen.TabStop = False
        '
        'lblFechaTrabajo
        '
        Me.lblFechaTrabajo.AutoSize = True
        Me.lblFechaTrabajo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaTrabajo.ForeColor = System.Drawing.Color.Black
        Me.lblFechaTrabajo.Location = New System.Drawing.Point(151, 136)
        Me.lblFechaTrabajo.Name = "lblFechaTrabajo"
        Me.lblFechaTrabajo.Size = New System.Drawing.Size(41, 16)
        Me.lblFechaTrabajo.TabIndex = 101
        Me.lblFechaTrabajo.Text = "Fecha:"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(246, 174)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(123, 24)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Registrar Ticket"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(374, 174)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(147, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 16)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Numero de Ticket:"
        '
        'cmbCajas
        '
        Me.cmbCajas.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.ForeColor = System.Drawing.Color.Navy
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(246, 73)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(384, 24)
        Me.cmbCajas.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(147, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 16)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Caja"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(246, 21)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(384, 22)
        Me.txtCompañia.TabIndex = 85
        Me.txtCompañia.Visible = False
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(246, 43)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(384, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(147, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(147, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.AllowUserToDeleteRows = False
        Me.dgvMovtos.AllowUserToResizeColumns = False
        Me.dgvMovtos.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvMovtos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovtos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovtos.Location = New System.Drawing.Point(0, 210)
        Me.dgvMovtos.MultiSelect = False
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(844, 262)
        Me.dgvMovtos.TabIndex = 30
        '
        'Seguridad_Permisos_Tickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(844, 472)
        Me.Controls.Add(Me.dgvMovtos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Seguridad_Permisos_Tickets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad_Permisos_Tickets"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblFechaTrabajo As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTckets As System.Windows.Forms.TextBox
End Class
