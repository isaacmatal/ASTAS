<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Generar_Partidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Activo_Fijo_Generar_Partidas))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnProcesarPartida = New System.Windows.Forms.Button
        Me.txtPartidaGral = New System.Windows.Forms.TextBox
        Me.txtPartidaDetalle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTransaccion = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpTipos = New System.Windows.Forms.TabPage
        Me.dgvTipos = New System.Windows.Forms.DataGridView
        Me.tpDetalle = New System.Windows.Forms.TabPage
        Me.dgvDetalles = New System.Windows.Forms.DataGridView
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpTipos.SuspendLayout()
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDetalle.SuspendLayout()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Image = CType(resources.GetObject("pbImagen.Image"), System.Drawing.Image)
        Me.pbImagen.Location = New System.Drawing.Point(843, 1)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(60, 82)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 44
        Me.pbImagen.TabStop = False
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(17, 35)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 45
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(17, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 16)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Fecha Contable"
        '
        'btnProcesarPartida
        '
        Me.btnProcesarPartida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnProcesarPartida.BackColor = System.Drawing.Color.Transparent
        Me.btnProcesarPartida.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesarPartida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarPartida.Image = CType(resources.GetObject("btnProcesarPartida.Image"), System.Drawing.Image)
        Me.btnProcesarPartida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarPartida.Location = New System.Drawing.Point(389, 17)
        Me.btnProcesarPartida.Name = "btnProcesarPartida"
        Me.btnProcesarPartida.Size = New System.Drawing.Size(74, 46)
        Me.btnProcesarPartida.TabIndex = 48
        Me.btnProcesarPartida.Text = "&Procesar"
        Me.btnProcesarPartida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesarPartida.UseVisualStyleBackColor = False
        '
        'txtPartidaGral
        '
        Me.txtPartidaGral.Location = New System.Drawing.Point(137, 36)
        Me.txtPartidaGral.Name = "txtPartidaGral"
        Me.txtPartidaGral.Size = New System.Drawing.Size(112, 20)
        Me.txtPartidaGral.TabIndex = 51
        '
        'txtPartidaDetalle
        '
        Me.txtPartidaDetalle.Location = New System.Drawing.Point(255, 36)
        Me.txtPartidaDetalle.Name = "txtPartidaDetalle"
        Me.txtPartidaDetalle.Size = New System.Drawing.Size(112, 20)
        Me.txtPartidaDetalle.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(137, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Partida General"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(255, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Partida Detalle"
        '
        'txtTransaccion
        '
        Me.txtTransaccion.Enabled = False
        Me.txtTransaccion.Location = New System.Drawing.Point(373, 36)
        Me.txtTransaccion.Name = "txtTransaccion"
        Me.txtTransaccion.Size = New System.Drawing.Size(10, 20)
        Me.txtTransaccion.TabIndex = 55
        Me.txtTransaccion.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpTipos)
        Me.TabControl1.Controls.Add(Me.tpDetalle)
        Me.TabControl1.Location = New System.Drawing.Point(7, 87)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(899, 208)
        Me.TabControl1.TabIndex = 56
        '
        'tpTipos
        '
        Me.tpTipos.Controls.Add(Me.dgvTipos)
        Me.tpTipos.Location = New System.Drawing.Point(4, 22)
        Me.tpTipos.Name = "tpTipos"
        Me.tpTipos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTipos.Size = New System.Drawing.Size(891, 182)
        Me.tpTipos.TabIndex = 0
        Me.tpTipos.Text = "Por Tipo"
        Me.tpTipos.UseVisualStyleBackColor = True
        '
        'dgvTipos
        '
        Me.dgvTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTipos.BackgroundColor = System.Drawing.Color.White
        Me.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTipos.Location = New System.Drawing.Point(3, 3)
        Me.dgvTipos.Name = "dgvTipos"
        Me.dgvTipos.Size = New System.Drawing.Size(885, 176)
        Me.dgvTipos.TabIndex = 50
        '
        'tpDetalle
        '
        Me.tpDetalle.Controls.Add(Me.dgvDetalles)
        Me.tpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tpDetalle.Name = "tpDetalle"
        Me.tpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetalle.Size = New System.Drawing.Size(891, 382)
        Me.tpDetalle.TabIndex = 1
        Me.tpDetalle.Text = "Por Detalle"
        Me.tpDetalle.UseVisualStyleBackColor = True
        '
        'dgvDetalles
        '
        Me.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalles.Location = New System.Drawing.Point(3, 3)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.Size = New System.Drawing.Size(885, 376)
        Me.dgvDetalles.TabIndex = 49
        '
        'Activo_Fijo_Generar_Partidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 501)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtTransaccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPartidaDetalle)
        Me.Controls.Add(Me.txtPartidaGral)
        Me.Controls.Add(Me.btnProcesarPartida)
        Me.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.pbImagen)
        Me.MaximizeBox = False
        Me.Name = "Activo_Fijo_Generar_Partidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Partidas Contables"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpTipos.ResumeLayout(False)
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDetalle.ResumeLayout(False)
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnProcesarPartida As System.Windows.Forms.Button
    Friend WithEvents txtPartidaGral As System.Windows.Forms.TextBox
    Friend WithEvents txtPartidaDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTransaccion As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpTipos As System.Windows.Forms.TabPage
    Friend WithEvents tpDetalle As System.Windows.Forms.TabPage
    Friend WithEvents dgvDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipos As System.Windows.Forms.DataGridView
End Class
