<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Reporte_Comparativos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.btnPrint = New System.Windows.Forms.Button
        Me.chkAllTpoBien = New System.Windows.Forms.CheckBox
        Me.chkAllClasificacion = New System.Windows.Forms.CheckBox
        Me.dgvClasificacion = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvTipoBien = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgvClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoBien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Fecha Vencimiento Hasta:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(150, 18)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(110, 20)
        Me.dtpHasta.TabIndex = 41
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(268, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(69, 32)
        Me.btnPrint.TabIndex = 42
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkAllTpoBien
        '
        Me.chkAllTpoBien.AutoSize = True
        Me.chkAllTpoBien.BackColor = System.Drawing.Color.Transparent
        Me.chkAllTpoBien.ForeColor = System.Drawing.Color.Navy
        Me.chkAllTpoBien.Location = New System.Drawing.Point(334, 74)
        Me.chkAllTpoBien.Name = "chkAllTpoBien"
        Me.chkAllTpoBien.Size = New System.Drawing.Size(56, 17)
        Me.chkAllTpoBien.TabIndex = 49
        Me.chkAllTpoBien.Text = "Todos"
        Me.chkAllTpoBien.UseVisualStyleBackColor = False
        '
        'chkAllClasificacion
        '
        Me.chkAllClasificacion.AutoSize = True
        Me.chkAllClasificacion.BackColor = System.Drawing.Color.Transparent
        Me.chkAllClasificacion.ForeColor = System.Drawing.Color.Navy
        Me.chkAllClasificacion.Location = New System.Drawing.Point(16, 74)
        Me.chkAllClasificacion.Name = "chkAllClasificacion"
        Me.chkAllClasificacion.Size = New System.Drawing.Size(56, 17)
        Me.chkAllClasificacion.TabIndex = 48
        Me.chkAllClasificacion.Text = "Todos"
        Me.chkAllClasificacion.UseVisualStyleBackColor = False
        '
        'dgvClasificacion
        '
        Me.dgvClasificacion.AllowUserToAddRows = False
        Me.dgvClasificacion.AllowUserToDeleteRows = False
        Me.dgvClasificacion.AllowUserToResizeColumns = False
        Me.dgvClasificacion.AllowUserToResizeRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvClasificacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvClasificacion.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClasificacion.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvClasificacion.Location = New System.Drawing.Point(16, 92)
        Me.dgvClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvClasificacion.Name = "dgvClasificacion"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClasificacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvClasificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClasificacion.Size = New System.Drawing.Size(312, 190)
        Me.dgvClasificacion.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(140, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Clasificación"
        '
        'dgvTipoBien
        '
        Me.dgvTipoBien.AllowUserToAddRows = False
        Me.dgvTipoBien.AllowUserToDeleteRows = False
        Me.dgvTipoBien.AllowUserToResizeColumns = False
        Me.dgvTipoBien.AllowUserToResizeRows = False
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvTipoBien.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvTipoBien.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvTipoBien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoBien.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvTipoBien.Location = New System.Drawing.Point(334, 92)
        Me.dgvTipoBien.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvTipoBien.Name = "dgvTipoBien"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoBien.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvTipoBien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoBien.Size = New System.Drawing.Size(420, 190)
        Me.dgvTipoBien.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(502, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Tipo de Bien"
        '
        'Activo_Fijo_Reporte_Comparativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 295)
        Me.Controls.Add(Me.chkAllTpoBien)
        Me.Controls.Add(Me.chkAllClasificacion)
        Me.Controls.Add(Me.dgvClasificacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvTipoBien)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dtpHasta)
        Me.Name = "Activo_Fijo_Reporte_Comparativos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuadro Comparativo de la Depreciacion Financiera Vrs Fiscal"
        CType(Me.dgvClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipoBien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAllTpoBien As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllClasificacion As System.Windows.Forms.CheckBox
    Friend WithEvents dgvClasificacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvTipoBien As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
