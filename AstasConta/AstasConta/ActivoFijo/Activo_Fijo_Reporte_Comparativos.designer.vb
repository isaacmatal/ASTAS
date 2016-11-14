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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.btnPrint = New System.Windows.Forms.Button
        Me.chkAllTpoBien = New System.Windows.Forms.CheckBox
        Me.chkAllClasificacion = New System.Windows.Forms.CheckBox
        Me.dgvClasificacion = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvTipoBien = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radCategoria = New System.Windows.Forms.RadioButton
        Me.btnTipoBien = New System.Windows.Forms.RadioButton
        CType(Me.dgvClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoBien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(251, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Fecha de Emisión del Reporte:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(405, 26)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(110, 20)
        Me.dtpHasta.TabIndex = 41
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(523, 20)
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
        Me.chkAllTpoBien.Location = New System.Drawing.Point(334, 78)
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
        Me.chkAllClasificacion.Location = New System.Drawing.Point(16, 78)
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvClasificacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClasificacion.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClasificacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClasificacion.Location = New System.Drawing.Point(16, 96)
        Me.dgvClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvClasificacion.Name = "dgvClasificacion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClasificacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvClasificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClasificacion.Size = New System.Drawing.Size(312, 198)
        Me.dgvClasificacion.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(140, 79)
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
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvTipoBien.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTipoBien.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvTipoBien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoBien.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTipoBien.Location = New System.Drawing.Point(334, 96)
        Me.dgvTipoBien.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvTipoBien.Name = "dgvTipoBien"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoBien.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTipoBien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoBien.Size = New System.Drawing.Size(420, 198)
        Me.dgvTipoBien.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(502, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Tipo de Bien"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTipoBien)
        Me.GroupBox1.Controls.Add(Me.radCategoria)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 54)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agrupación"
        '
        'radCategoria
        '
        Me.radCategoria.AutoSize = True
        Me.radCategoria.Location = New System.Drawing.Point(17, 25)
        Me.radCategoria.Name = "radCategoria"
        Me.radCategoria.Size = New System.Drawing.Size(72, 17)
        Me.radCategoria.TabIndex = 0
        Me.radCategoria.TabStop = True
        Me.radCategoria.Text = "Categoría"
        Me.radCategoria.UseVisualStyleBackColor = True
        '
        'btnTipoBien
        '
        Me.btnTipoBien.AutoSize = True
        Me.btnTipoBien.Location = New System.Drawing.Point(130, 25)
        Me.btnTipoBien.Name = "btnTipoBien"
        Me.btnTipoBien.Size = New System.Drawing.Size(85, 17)
        Me.btnTipoBien.TabIndex = 1
        Me.btnTipoBien.TabStop = True
        Me.btnTipoBien.Text = "Tipo de Bien"
        Me.btnTipoBien.UseVisualStyleBackColor = True
        '
        'Activo_Fijo_Reporte_Comparativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 303)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTipoBien As System.Windows.Forms.RadioButton
    Friend WithEvents radCategoria As System.Windows.Forms.RadioButton
End Class
