<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnularSolicitudReversion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnularSolicitudReversion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxCotizacion = New System.Windows.Forms.GroupBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnAnular = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFechaAnulado = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.CbxDeduccion = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblSegDeuda = New System.Windows.Forms.Label
        Me.LblInteres = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtCapital = New System.Windows.Forms.TextBox
        Me.txtNoSolicitud = New System.Windows.Forms.Label
        Me.DgvDetalleProgramaciones = New System.Windows.Forms.DataGridView
        Me.GbxCotizacion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvDetalleProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxCotizacion
        '
        Me.GbxCotizacion.BackColor = System.Drawing.Color.Transparent
        Me.GbxCotizacion.Controls.Add(Me.TxtNombre)
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoAs)
        Me.GbxCotizacion.Controls.Add(Me.Label9)
        Me.GbxCotizacion.Controls.Add(Me.Label1)
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxCotizacion.Controls.Add(Me.Label2)
        Me.GbxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCotizacion.ForeColor = System.Drawing.Color.Navy
        Me.GbxCotizacion.Location = New System.Drawing.Point(12, 13)
        Me.GbxCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Name = "GbxCotizacion"
        Me.GbxCotizacion.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Size = New System.Drawing.Size(711, 100)
        Me.GbxCotizacion.TabIndex = 128
        Me.GbxCotizacion.TabStop = False
        Me.GbxCotizacion.Text = "Datos del Socio:"
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(95, 59)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(355, 22)
        Me.TxtNombre.TabIndex = 127
        Me.TxtNombre.TabStop = False
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(343, 24)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.ReadOnly = True
        Me.TxtCodigoAs.Size = New System.Drawing.Size(107, 22)
        Me.TxtCodigoAs.TabIndex = 126
        Me.TxtCodigoAs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(0, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 16)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Nombre del Socio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Codigo Buxis:"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(95, 22)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.ReadOnly = True
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(107, 22)
        Me.TxtCodigoBuxis.TabIndex = 126
        Me.TxtCodigoBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(284, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Codigo AS:"
        '
        'btnAnular
        '
        Me.btnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnAnular.ForeColor = System.Drawing.Color.Black
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(622, 119)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(72, 25)
        Me.btnAnular.TabIndex = 129
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpFechaAnulado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtConcepto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnAnular)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.CbxDeduccion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LblSegDeuda)
        Me.GroupBox1.Controls.Add(Me.LblInteres)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.TxtCapital)
        Me.GroupBox1.Controls.Add(Me.txtNoSolicitud)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 120)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(711, 151)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Solicitud:"
        '
        'dtpFechaAnulado
        '
        Me.dtpFechaAnulado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAnulado.Location = New System.Drawing.Point(518, 122)
        Me.dtpFechaAnulado.Name = "dtpFechaAnulado"
        Me.dtpFechaAnulado.Size = New System.Drawing.Size(94, 22)
        Me.dtpFechaAnulado.TabIndex = 212
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(519, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 16)
        Me.Label7.TabIndex = 211
        Me.Label7.Text = "Fecha Anulación:"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(106, 94)
        Me.txtConcepto.MaxLength = 500
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(400, 50)
        Me.txtConcepto.TabIndex = 210
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 16)
        Me.Label6.TabIndex = 209
        Me.Label6.Text = "Motivo Anulación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(249, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "Saldo Actual:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(33, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "No. solicitud:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(487, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 16)
        Me.Label22.TabIndex = 203
        Me.Label22.Text = "%"
        '
        'CbxDeduccion
        '
        Me.CbxDeduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CbxDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDeduccion.Enabled = False
        Me.CbxDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDeduccion.ForeColor = System.Drawing.Color.Navy
        Me.CbxDeduccion.FormattingEnabled = True
        Me.CbxDeduccion.Location = New System.Drawing.Point(106, 55)
        Me.CbxDeduccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxDeduccion.Name = "CbxDeduccion"
        Me.CbxDeduccion.Size = New System.Drawing.Size(298, 24)
        Me.CbxDeduccion.TabIndex = 205
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(619, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 16)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "%"
        '
        'LblSegDeuda
        '
        Me.LblSegDeuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblSegDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSegDeuda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSegDeuda.Location = New System.Drawing.Point(590, 56)
        Me.LblSegDeuda.Name = "LblSegDeuda"
        Me.LblSegDeuda.Size = New System.Drawing.Size(26, 20)
        Me.LblSegDeuda.TabIndex = 201
        Me.LblSegDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblInteres
        '
        Me.LblInteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteres.Location = New System.Drawing.Point(458, 56)
        Me.LblInteres.Name = "LblInteres"
        Me.LblInteres.Size = New System.Drawing.Size(26, 20)
        Me.LblInteres.TabIndex = 200
        Me.LblInteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(55, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 16)
        Me.Label19.TabIndex = 204
        Me.Label19.Text = "Solicitid:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(509, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(81, 16)
        Me.Label26.TabIndex = 199
        Me.Label26.Text = "Seguro Deuda:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(410, 58)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 198
        Me.Label27.Text = "Interés:"
        '
        'TxtCapital
        '
        Me.TxtCapital.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCapital.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCapital.ForeColor = System.Drawing.Color.Navy
        Me.TxtCapital.Location = New System.Drawing.Point(317, 21)
        Me.TxtCapital.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCapital.Name = "TxtCapital"
        Me.TxtCapital.ReadOnly = True
        Me.TxtCapital.Size = New System.Drawing.Size(87, 20)
        Me.TxtCapital.TabIndex = 194
        Me.TxtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoSolicitud
        '
        Me.txtNoSolicitud.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNoSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNoSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoSolicitud.ForeColor = System.Drawing.Color.Navy
        Me.txtNoSolicitud.Location = New System.Drawing.Point(106, 20)
        Me.txtNoSolicitud.Name = "txtNoSolicitud"
        Me.txtNoSolicitud.Size = New System.Drawing.Size(107, 20)
        Me.txtNoSolicitud.TabIndex = 195
        Me.txtNoSolicitud.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgvDetalleProgramaciones
        '
        Me.DgvDetalleProgramaciones.AllowUserToAddRows = False
        Me.DgvDetalleProgramaciones.AllowUserToDeleteRows = False
        Me.DgvDetalleProgramaciones.AllowUserToResizeColumns = False
        Me.DgvDetalleProgramaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DgvDetalleProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDetalleProgramaciones.BackgroundColor = System.Drawing.Color.Azure
        Me.DgvDetalleProgramaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvDetalleProgramaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgvDetalleProgramaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgvDetalleProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetalleProgramaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvDetalleProgramaciones.Location = New System.Drawing.Point(12, 278)
        Me.DgvDetalleProgramaciones.MultiSelect = False
        Me.DgvDetalleProgramaciones.Name = "DgvDetalleProgramaciones"
        Me.DgvDetalleProgramaciones.ReadOnly = True
        Me.DgvDetalleProgramaciones.RowHeadersVisible = False
        Me.DgvDetalleProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalleProgramaciones.Size = New System.Drawing.Size(711, 156)
        Me.DgvDetalleProgramaciones.TabIndex = 178
        '
        'frmAnularSolicitudReversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 446)
        Me.Controls.Add(Me.DgvDetalleProgramaciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GbxCotizacion)
        Me.Name = "frmAnularSolicitudReversion"
        Me.Text = " "
        Me.GbxCotizacion.ResumeLayout(False)
        Me.GbxCotizacion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvDetalleProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbxCotizacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CbxDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblSegDeuda As System.Windows.Forms.Label
    Friend WithEvents LblInteres As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtNoSolicitud As System.Windows.Forms.Label
    Friend WithEvents DgvDetalleProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaAnulado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
