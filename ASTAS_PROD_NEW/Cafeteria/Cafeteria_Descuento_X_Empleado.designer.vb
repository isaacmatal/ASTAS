<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Descuento_X_Empleado
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Descuento_X_Empleado))
        Me.DgvDescuentoSocios = New System.Windows.Forms.DataGridView
        Me.TxtCodigoBuxisB = New System.Windows.Forms.TextBox
        Me.TxtCodigoAsB = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNombreB = New System.Windows.Forms.TextBox
        Me.Bw1 = New System.ComponentModel.BackgroundWorker
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.DgvDescuentoSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvDescuentoSocios
        '
        Me.DgvDescuentoSocios.AllowUserToAddRows = False
        Me.DgvDescuentoSocios.AllowUserToDeleteRows = False
        Me.DgvDescuentoSocios.AllowUserToResizeColumns = False
        Me.DgvDescuentoSocios.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgvDescuentoSocios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDescuentoSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgvDescuentoSocios.BackgroundColor = System.Drawing.Color.Azure
        Me.DgvDescuentoSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDescuentoSocios.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvDescuentoSocios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDescuentoSocios.Location = New System.Drawing.Point(3, 16)
        Me.DgvDescuentoSocios.MultiSelect = False
        Me.DgvDescuentoSocios.Name = "DgvDescuentoSocios"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDescuentoSocios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvDescuentoSocios.RowHeadersVisible = False
        Me.DgvDescuentoSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDescuentoSocios.Size = New System.Drawing.Size(1031, 453)
        Me.DgvDescuentoSocios.TabIndex = 4
        Me.DgvDescuentoSocios.TabStop = False
        '
        'TxtCodigoBuxisB
        '
        Me.TxtCodigoBuxisB.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxisB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoBuxisB.Location = New System.Drawing.Point(373, 39)
        Me.TxtCodigoBuxisB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxisB.MaxLength = 7
        Me.TxtCodigoBuxisB.Name = "TxtCodigoBuxisB"
        Me.TxtCodigoBuxisB.Size = New System.Drawing.Size(102, 22)
        Me.TxtCodigoBuxisB.TabIndex = 1
        '
        'TxtCodigoAsB
        '
        Me.TxtCodigoAsB.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAsB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAsB.Location = New System.Drawing.Point(481, 39)
        Me.TxtCodigoAsB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAsB.MaxLength = 7
        Me.TxtCodigoAsB.Name = "TxtCodigoAsB"
        Me.TxtCodigoAsB.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoAsB.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(6, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(382, 20)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Nombre del Empleado"
        '
        'TxtNombreB
        '
        Me.TxtNombreB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreB.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNombreB.Location = New System.Drawing.Point(6, 39)
        Me.TxtNombreB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombreB.MaxLength = 100
        Me.TxtNombreB.Name = "TxtNombreB"
        Me.TxtNombreB.Size = New System.Drawing.Size(361, 22)
        Me.TxtNombreB.TabIndex = 0
        '
        'Bw1
        '
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(596, 15)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 46)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnGuardar, "Guardar al empleado en la lista de decuentos escogidos.")
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(674, 15)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 46)
        Me.btnPrint.TabIndex = 140
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Guardar al empleado en la lista de decuentos escogidos.")
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.TxtNombreB)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoAsB)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoBuxisB)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1037, 71)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(481, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 20)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "AS"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(373, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 20)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Buxis"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvDescuentoSocios)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1037, 472)
        Me.GroupBox2.TabIndex = 137
        Me.GroupBox2.TabStop = False
        '
        'Cafeteria_Descuento_X_Empleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1037, 543)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MinimizeBox = False
        Me.Name = "Cafeteria_Descuento_X_Empleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Descuento_X_Empleado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DgvDescuentoSocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvDescuentoSocios As System.Windows.Forms.DataGridView
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoBuxisB As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoAsB As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreB As System.Windows.Forms.TextBox
    Friend WithEvents Bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
