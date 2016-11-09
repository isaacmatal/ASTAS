<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManAutorizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManAutorizacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.CbxCorrelativos = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.CbxTipoSolicitud = New System.Windows.Forms.ComboBox
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.CbxUsuarios = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DgvAutorizaciones = New System.Windows.Forms.DataGridView
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.GbxDatos.SuspendLayout()
        CType(Me.DgvAutorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxDatos
        '
        Me.GbxDatos.Controls.Add(Me.dtpHasta)
        Me.GbxDatos.Controls.Add(Me.dtpDesde)
        Me.GbxDatos.Controls.Add(Me.CbxCorrelativos)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Controls.Add(Me.BtnEliminar)
        Me.GbxDatos.Controls.Add(Me.BtnGuardar)
        Me.GbxDatos.Controls.Add(Me.CbxTipoSolicitud)
        Me.GbxDatos.Controls.Add(Me.CbxCompania)
        Me.GbxDatos.Controls.Add(Me.CbxUsuarios)
        Me.GbxDatos.Controls.Add(Me.Label6)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(10, 8)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Size = New System.Drawing.Size(496, 128)
        Me.GbxDatos.TabIndex = 12
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Registro de Autorizaciones de Solicitudes"
        '
        'CbxCorrelativos
        '
        Me.CbxCorrelativos.DisplayMember = "1"
        Me.CbxCorrelativos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCorrelativos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxCorrelativos.ForeColor = System.Drawing.Color.Navy
        Me.CbxCorrelativos.FormattingEnabled = True
        Me.CbxCorrelativos.Location = New System.Drawing.Point(96, 96)
        Me.CbxCorrelativos.Name = "CbxCorrelativos"
        Me.CbxCorrelativos.Size = New System.Drawing.Size(206, 24)
        Me.CbxCorrelativos.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "N° Autorización:"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(376, 96)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(304, 96)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.BtnGuardar.TabIndex = 11
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'CbxTipoSolicitud
        '
        Me.CbxTipoSolicitud.DisplayMember = "1"
        Me.CbxTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxTipoSolicitud.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipoSolicitud.FormattingEnabled = True
        Me.CbxTipoSolicitud.Location = New System.Drawing.Point(96, 48)
        Me.CbxTipoSolicitud.Name = "CbxTipoSolicitud"
        Me.CbxTipoSolicitud.Size = New System.Drawing.Size(312, 24)
        Me.CbxTipoSolicitud.TabIndex = 1
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(96, 24)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(392, 24)
        Me.CbxCompania.TabIndex = 0
        '
        'CbxUsuarios
        '
        Me.CbxUsuarios.DisplayMember = "1"
        Me.CbxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxUsuarios.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxUsuarios.ForeColor = System.Drawing.Color.Navy
        Me.CbxUsuarios.FormattingEnabled = True
        Me.CbxUsuarios.Location = New System.Drawing.Point(96, 72)
        Me.CbxUsuarios.Name = "CbxUsuarios"
        Me.CbxUsuarios.Size = New System.Drawing.Size(206, 24)
        Me.CbxUsuarios.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo Solicitud:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Compañía:"
        '
        'DgvAutorizaciones
        '
        Me.DgvAutorizaciones.AllowUserToAddRows = False
        Me.DgvAutorizaciones.AllowUserToDeleteRows = False
        Me.DgvAutorizaciones.AllowUserToResizeColumns = False
        Me.DgvAutorizaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvAutorizaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvAutorizaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvAutorizaciones.Location = New System.Drawing.Point(8, 144)
        Me.DgvAutorizaciones.MultiSelect = False
        Me.DgvAutorizaciones.Name = "DgvAutorizaciones"
        Me.DgvAutorizaciones.ReadOnly = True
        Me.DgvAutorizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAutorizaciones.Size = New System.Drawing.Size(728, 384)
        Me.DgvAutorizaciones.TabIndex = 13
        '
        'pbImagen
        '
        Me.pbImagen.Image = CType(resources.GetObject("pbImagen.Image"), System.Drawing.Image)
        Me.pbImagen.Location = New System.Drawing.Point(627, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(93, 128)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 14
        Me.pbImagen.TabStop = False
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(309, 68)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(91, 22)
        Me.dtpDesde.TabIndex = 16
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(406, 68)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpHasta.TabIndex = 17
        '
        'FrmManAutorizacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(741, 532)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GbxDatos)
        Me.Controls.Add(Me.DgvAutorizaciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmManAutorizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Catálogo de Autorizaciones de Solicitudes"
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        CType(Me.DgvAutorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents CbxTipoSolicitud As System.Windows.Forms.ComboBox
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents CbxUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvAutorizaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CbxCorrelativos As System.Windows.Forms.ComboBox
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
End Class
