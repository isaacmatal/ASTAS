<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_Margen_Ganancias
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbCCF = New System.Windows.Forms.RadioButton
        Me.rdbCF = New System.Windows.Forms.RadioButton
        Me.fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dtsReporte = New System.Data.DataSet
        Me.tblreporte = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.DataColumn8 = New System.Data.DataColumn
        Me.DataColumn9 = New System.Data.DataColumn
        Me.DataColumn10 = New System.Data.DataColumn
        Me.DataColumn11 = New System.Data.DataColumn
        Me.DataColumn12 = New System.Data.DataColumn
        Me.DataColumn13 = New System.Data.DataColumn
        Me.DataColumn14 = New System.Data.DataColumn
        Me.DataColumn15 = New System.Data.DataColumn
        Me.DataColumn17 = New System.Data.DataColumn
        Me.DataColumn18 = New System.Data.DataColumn
        Me.DataColumn19 = New System.Data.DataColumn
        Me.DataColumn20 = New System.Data.DataColumn
        Me.DataColumn21 = New System.Data.DataColumn
        Me.DataColumn22 = New System.Data.DataColumn
        Me.DataColumn24 = New System.Data.DataColumn
        Me.DataColumn16 = New System.Data.DataColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtsReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblreporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbCCF)
        Me.GroupBox1.Controls.Add(Me.rdbCF)
        Me.GroupBox1.Controls.Add(Me.fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1042, 67)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles Genericos"
        '
        'rdbCCF
        '
        Me.rdbCCF.AutoSize = True
        Me.rdbCCF.Location = New System.Drawing.Point(492, 38)
        Me.rdbCCF.Name = "rdbCCF"
        Me.rdbCCF.Size = New System.Drawing.Size(113, 20)
        Me.rdbCCF.TabIndex = 101
        Me.rdbCCF.Text = "Credito Fiscal"
        Me.rdbCCF.UseVisualStyleBackColor = True
        '
        'rdbCF
        '
        Me.rdbCF.AutoSize = True
        Me.rdbCF.Checked = True
        Me.rdbCF.Location = New System.Drawing.Point(491, 15)
        Me.rdbCF.Name = "rdbCF"
        Me.rdbCF.Size = New System.Drawing.Size(138, 20)
        Me.rdbCF.TabIndex = 100
        Me.rdbCF.TabStop = True
        Me.rdbCF.Text = "Consumidor Final"
        Me.rdbCF.UseVisualStyleBackColor = True
        '
        'fecha_desde
        '
        Me.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde.Location = New System.Drawing.Point(59, 43)
        Me.fecha_desde.MinDate = New Date(2013, 9, 1, 0, 0, 0, 0)
        Me.fecha_desde.Name = "fecha_desde"
        Me.fecha_desde.Size = New System.Drawing.Size(112, 22)
        Me.fecha_desde.TabIndex = 98
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 14)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Desde :"
        '
        'fecha_hasta
        '
        Me.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta.Location = New System.Drawing.Point(227, 43)
        Me.fecha_hasta.Name = "fecha_hasta"
        Me.fecha_hasta.Size = New System.Drawing.Size(112, 22)
        Me.fecha_hasta.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(177, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Hasta  :"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Location = New System.Drawing.Point(424, 40)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 25)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Generar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(52, 18)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Bodega :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1054, 518)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1048, 499)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'dtsReporte
        '
        Me.dtsReporte.DataSetName = "dtsReporte"
        Me.dtsReporte.Tables.AddRange(New System.Data.DataTable() {Me.tblreporte})
        '
        'tblreporte
        '
        Me.tblreporte.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn15, Me.DataColumn17, Me.DataColumn18, Me.DataColumn19, Me.DataColumn20, Me.DataColumn21, Me.DataColumn22, Me.DataColumn24, Me.DataColumn16})
        Me.tblreporte.TableName = "tblreporte"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "DESCRIPCION_BODEGA"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "CODIGO_GRUPO"
        Me.DataColumn2.DataType = GetType(Integer)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "DESCP_GRUPO"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "CODIGO_SUBGRUPO"
        Me.DataColumn4.DataType = GetType(Integer)
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "DESCP_SUBGRUPO"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "PRODUCTO"
        Me.DataColumn6.DataType = GetType(Integer)
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "NOMBRE_PRODUCTO"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "DESCRIPCION_UNIDAD_MEDIDA"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "CANTIDAD"
        Me.DataColumn9.DataType = GetType(Double)
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "COSTO_TOTAL"
        Me.DataColumn10.DataType = GetType(Double)
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "IVA"
        Me.DataColumn11.DataType = GetType(Double)
        '
        'DataColumn12
        '
        Me.DataColumn12.Caption = "MARGEN"
        Me.DataColumn12.ColumnName = "MARGEN"
        Me.DataColumn12.DataType = GetType(Double)
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "PRECIO_TOTAL"
        Me.DataColumn13.DataType = GetType(Double)
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "PORCENTAJE_MARGEN"
        Me.DataColumn14.DataType = GetType(Double)
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "BODEGA"
        Me.DataColumn15.DataType = GetType(Integer)
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "NUMERO_FACTURA"
        Me.DataColumn17.DataType = GetType(Integer)
        '
        'DataColumn18
        '
        Me.DataColumn18.ColumnName = "NOMBRE_FACTURA"
        '
        'DataColumn19
        '
        Me.DataColumn19.ColumnName = "FECHA_FACTURA"
        Me.DataColumn19.DataType = GetType(Date)
        '
        'DataColumn20
        '
        Me.DataColumn20.ColumnName = "LINEA"
        Me.DataColumn20.DataType = GetType(Integer)
        '
        'DataColumn21
        '
        Me.DataColumn21.ColumnName = "COSTO_UNITARIO"
        Me.DataColumn21.DataType = GetType(Double)
        '
        'DataColumn22
        '
        Me.DataColumn22.ColumnName = "PRECIO_UNITARIO"
        Me.DataColumn22.DataType = GetType(Double)
        '
        'DataColumn24
        '
        Me.DataColumn24.ColumnName = "COMPAÑIA"
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "DESCRIPCION"
        '
        'Reporte_Margen_Ganancias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 603)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Reporte_Margen_Ganancias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario Margen de Ganancia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtsReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblreporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtsReporte As System.Data.DataSet
    Friend WithEvents tblreporte As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents DataColumn18 As System.Data.DataColumn
    Friend WithEvents DataColumn19 As System.Data.DataColumn
    Friend WithEvents DataColumn20 As System.Data.DataColumn
    Friend WithEvents DataColumn21 As System.Data.DataColumn
    Friend WithEvents DataColumn22 As System.Data.DataColumn
    Friend WithEvents DataColumn24 As System.Data.DataColumn
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents rdbCCF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCF As System.Windows.Forms.RadioButton
End Class

