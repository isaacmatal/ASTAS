<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlDescuentosIndegnizados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlDescuentosIndegnizados))
        Me.dgvIngdemnizados = New System.Windows.Forms.DataGridView
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tcContainer = New System.Windows.Forms.TabControl
        Me.tpPendientes = New System.Windows.Forms.TabPage
        Me.tpCancelados = New System.Windows.Forms.TabPage
        Me.dgvIndemnCancelados = New System.Windows.Forms.DataGridView
        Me.tpReporte = New System.Windows.Forms.TabPage
        Me.crvReportView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnVer = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbRubro = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbEstatus = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbOrigen = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Desde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Hasta = New System.Windows.Forms.DateTimePicker
        CType(Me.dgvIngdemnizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcContainer.SuspendLayout()
        Me.tpPendientes.SuspendLayout()
        Me.tpCancelados.SuspendLayout()
        CType(Me.dgvIndemnCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvIngdemnizados
        '
        Me.dgvIngdemnizados.AllowUserToAddRows = False
        Me.dgvIngdemnizados.AllowUserToDeleteRows = False
        Me.dgvIngdemnizados.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvIngdemnizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngdemnizados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIngdemnizados.Location = New System.Drawing.Point(3, 3)
        Me.dgvIngdemnizados.Name = "dgvIngdemnizados"
        Me.dgvIngdemnizados.Size = New System.Drawing.Size(884, 537)
        Me.dgvIngdemnizados.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(793, 11)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(96, 23)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Actualizar Datos"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(793, 39)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Guardar Cambios"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tcContainer
        '
        Me.tcContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcContainer.Controls.Add(Me.tpPendientes)
        Me.tcContainer.Controls.Add(Me.tpCancelados)
        Me.tcContainer.Controls.Add(Me.tpReporte)
        Me.tcContainer.Location = New System.Drawing.Point(5, 72)
        Me.tcContainer.Name = "tcContainer"
        Me.tcContainer.SelectedIndex = 0
        Me.tcContainer.Size = New System.Drawing.Size(898, 569)
        Me.tcContainer.TabIndex = 4
        '
        'tpPendientes
        '
        Me.tpPendientes.Controls.Add(Me.dgvIngdemnizados)
        Me.tpPendientes.Location = New System.Drawing.Point(4, 22)
        Me.tpPendientes.Name = "tpPendientes"
        Me.tpPendientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPendientes.Size = New System.Drawing.Size(890, 543)
        Me.tpPendientes.TabIndex = 0
        Me.tpPendientes.Text = "Pendientes"
        Me.tpPendientes.UseVisualStyleBackColor = True
        '
        'tpCancelados
        '
        Me.tpCancelados.Controls.Add(Me.dgvIndemnCancelados)
        Me.tpCancelados.Location = New System.Drawing.Point(4, 22)
        Me.tpCancelados.Name = "tpCancelados"
        Me.tpCancelados.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCancelados.Size = New System.Drawing.Size(890, 543)
        Me.tpCancelados.TabIndex = 1
        Me.tpCancelados.Text = "Cancelados"
        Me.tpCancelados.UseVisualStyleBackColor = True
        '
        'dgvIndemnCancelados
        '
        Me.dgvIndemnCancelados.AllowUserToAddRows = False
        Me.dgvIndemnCancelados.AllowUserToDeleteRows = False
        Me.dgvIndemnCancelados.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvIndemnCancelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndemnCancelados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIndemnCancelados.Location = New System.Drawing.Point(3, 3)
        Me.dgvIndemnCancelados.Name = "dgvIndemnCancelados"
        Me.dgvIndemnCancelados.Size = New System.Drawing.Size(884, 537)
        Me.dgvIndemnCancelados.TabIndex = 1
        '
        'tpReporte
        '
        Me.tpReporte.Controls.Add(Me.crvReportView)
        Me.tpReporte.Controls.Add(Me.btnVer)
        Me.tpReporte.Location = New System.Drawing.Point(4, 22)
        Me.tpReporte.Name = "tpReporte"
        Me.tpReporte.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReporte.Size = New System.Drawing.Size(890, 543)
        Me.tpReporte.TabIndex = 2
        Me.tpReporte.Text = "Reporte"
        Me.tpReporte.UseVisualStyleBackColor = True
        '
        'crvReportView
        '
        Me.crvReportView.ActiveViewIndex = -1
        Me.crvReportView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReportView.Location = New System.Drawing.Point(3, 31)
        Me.crvReportView.Name = "crvReportView"
        Me.crvReportView.SelectionFormula = ""
        Me.crvReportView.Size = New System.Drawing.Size(885, 506)
        Me.crvReportView.TabIndex = 170
        Me.crvReportView.ViewTimeSelectionFormula = ""
        '
        'btnVer
        '
        Me.btnVer.BackColor = System.Drawing.Color.Transparent
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVer.Location = New System.Drawing.Point(6, 5)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 22)
        Me.btnVer.TabIndex = 167
        Me.btnVer.Text = "   Imprimir"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(366, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Rubro Deudas:"
        '
        'CmbRubro
        '
        Me.CmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRubro.FormattingEnabled = True
        Me.CmbRubro.Location = New System.Drawing.Point(460, 40)
        Me.CmbRubro.Name = "CmbRubro"
        Me.CmbRubro.Size = New System.Drawing.Size(327, 21)
        Me.CmbRubro.TabIndex = 168
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(366, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "Estatus:"
        '
        'CmbEstatus
        '
        Me.CmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstatus.FormattingEnabled = True
        Me.CmbEstatus.Location = New System.Drawing.Point(460, 13)
        Me.CmbEstatus.Name = "CmbEstatus"
        Me.CmbEstatus.Size = New System.Drawing.Size(327, 21)
        Me.CmbEstatus.TabIndex = 165
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(9, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "Origen :"
        '
        'CmbOrigen
        '
        Me.CmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOrigen.FormattingEnabled = True
        Me.CmbOrigen.Location = New System.Drawing.Point(62, 40)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(301, 21)
        Me.CmbOrigen.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Desde:"
        '
        'Desde
        '
        Me.Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde.Location = New System.Drawing.Point(62, 13)
        Me.Desde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(114, 20)
        Me.Desde.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(201, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 160
        Me.Label4.Text = "Hasta :"
        '
        'Hasta
        '
        Me.Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta.Location = New System.Drawing.Point(249, 13)
        Me.Hasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(114, 20)
        Me.Hasta.TabIndex = 159
        '
        'frmControlDescuentosIndegnizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 643)
        Me.Controls.Add(Me.tcContainer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.CmbRubro)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Desde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Hasta)
        Me.Controls.Add(Me.CmbEstatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbOrigen)
        Me.Name = "frmControlDescuentosIndegnizados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indemnizados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvIngdemnizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcContainer.ResumeLayout(False)
        Me.tpPendientes.ResumeLayout(False)
        Me.tpCancelados.ResumeLayout(False)
        CType(Me.dgvIndemnCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpReporte.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvIngdemnizados As System.Windows.Forms.DataGridView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tcContainer As System.Windows.Forms.TabControl
    Friend WithEvents tpPendientes As System.Windows.Forms.TabPage
    Friend WithEvents tpCancelados As System.Windows.Forms.TabPage
    Friend WithEvents dgvIndemnCancelados As System.Windows.Forms.DataGridView
    Friend WithEvents tpReporte As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbRubro As System.Windows.Forms.ComboBox
    Friend WithEvents crvReportView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
