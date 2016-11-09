<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Facturacion_Periodos_Pago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Facturacion_Periodos_Pago))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DSPeriodosCobro = New ASTAS.DSPeriodosCobro
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter = New ASTAS.DSPeriodosCobroTableAdapters.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DSPeriodosCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.SuspendLayout()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DSPeriodosCobro
        '
        Me.DSPeriodosCobro.DataSetName = "DSPeriodosCobro"
        Me.DSPeriodosCobro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource
        '
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource.DataMember = "CAFETERIA_FACTURACION_PERIODOS_DE_COBRO"
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource.DataSource = Me.DSPeriodosCobro
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource.Sort = "PERIODO_PAGO DESC"
        '
        'CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter
        '
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter.ClearBeforeFill = True
        '
        'CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator
        '
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.BindingSource = Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem})
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.Name = "CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator"
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.Size = New System.Drawing.Size(335, 25)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.TabIndex = 0
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem
        '
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Image = CType(resources.GetObject("CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Name = "CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem"
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView
        '
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.AllowUserToAddRows = False
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.AllowUserToOrderColumns = True
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.DataSource = Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Location = New System.Drawing.Point(0, 25)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Name = "CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView"
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.RowHeadersWidth = 20
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.Size = New System.Drawing.Size(335, 280)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "COMPAÑIA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "COMPAÑIA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PERIODO_PAGO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Periodo de Pago"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PERIODO_FACTURACION_INICIO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha Inicio Descuento"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PERIODO_FACTURACION_FINAL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "d"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Final Descuento"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'Cafeteria_Facturacion_Periodos_Pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 305)
        Me.Controls.Add(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView)
        Me.Controls.Add(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Cafeteria_Facturacion_Periodos_Pago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Definición Periodos Pago"
        CType(Me.DSPeriodosCobro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.ResumeLayout(False)
        Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator.PerformLayout()
        CType(Me.CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DSPeriodosCobro As ASTAS.DSPeriodosCobro
    Friend WithEvents CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter As ASTAS.DSPeriodosCobroTableAdapters.CAFETERIA_FACTURACION_PERIODOS_DE_COBROTableAdapter
    Friend WithEvents CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CAFETERIA_FACTURACION_PERIODOS_DE_COBROBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CAFETERIA_FACTURACION_PERIODOS_DE_COBRODataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
