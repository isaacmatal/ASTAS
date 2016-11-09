Imports System.Data.SqlClient

Public Class Inventario_BusquedaProductosBodega
    Dim Sql As String
    Dim Iniciando As Boolean
    Public Compañia_Value As Integer
    Public Bodega_Value As Integer
    Public BuscaTodos As Boolean
    Dim Table As DataTable
    Public MuestraExistencia As Boolean
    Dim nombre1 As String = ""
    Dim intPromocion As Integer = 1
    Dim jClass As New jarsClass

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal nombre As String, ByVal bandera As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nombre1 = nombre
        intPromocion = bandera
    End Sub

    Private Sub Inventario_BusquedaProductosBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        txtDESCRIPCION_PRODUCTO.Focus()
        CargaBodegas(Compañia, 4)
        CargaGrupos(Compañia, 2)
        Me.cmbBODEGA.SelectedValue = Bodega_Value
        Iniciando = False
        GeneraSQL()
        BuscaProductos()
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA =  " & Bandera & ", "
            Sql &= "@COMPAÑIA = " & Compañia & ", "
            Sql &= "@USUARIO  = '" & Usuario & "'"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaGrupos(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbGRUPO.DataSource = Table
            Me.cmbGRUPO.ValueMember = "Grupo"
            Me.cmbGRUPO.DisplayMember = "Descripción_Grupo"
            Me.cmbGRUPO.SelectedValue = 999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GeneraSQL()
        Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        Sql &= Compañia
        Sql &= ", " & Me.cmbBODEGA.SelectedValue
        Sql &= ", " & IIf(Trim(Me.txtPRODUCTO.Text) <> "", Val(Me.txtPRODUCTO.Text), 0)
        Sql &= ", '" & Trim(Me.txtDESCRIPCION_PRODUCTO.Text) & "'"
        Sql &= ", " & Me.cmbGRUPO.SelectedValue
        Sql &= ", " & intPromocion
    End Sub

    Private Sub BuscaProductos()
        Try
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvProductos.Columns.Clear()
            Me.dgvProductos.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Me.txtDESCRIPCION_PRODUCTO.Focus()
    End Sub

    Private Sub LimpiaGrid()
        Dim i As Integer
        For i = 0 To dgvProductos.ColumnCount - 1
            Me.dgvProductos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvProductos.Columns.Item(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        If intPromocion <> 4 Then
            Me.dgvProductos.Columns.Item(3).DefaultCellStyle.ForeColor = Color.Blue
            Me.dgvProductos.Columns.Item(5).DefaultCellStyle.ForeColor = Color.Navy

            Me.dgvProductos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProductos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProductos.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If MuestraExistencia = False Then
                Me.dgvProductos.Columns(8).Visible = False
                Me.dgvProductos.Columns(9).Visible = False
            End If
        End If        
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaBodegas(Compañia, 1)
            CargaGrupos(Compañia, 2)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        GeneraSQL()
        BuscaProductos()
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.Close()
            Case Keys.F1
                'Add the code for the function key F1 here.
            Case Keys.F2
                'Add the code for the function key F2 here.
            Case Keys.F3
                'Add the code for the function key F3 here.
                Me.btnBuscar.PerformClick()
            Case Keys.F4
                'Add the code for the function key F4 here.
            Case Keys.F5
                'Add the code for the function key F5 here.
            Case Keys.F6
                'Add the code for the function key F6 here.
                Me.btnBuscar.PerformClick()
            Case Keys.F7
                'Add the code for the function key F7 here.
                'btnEliminarProducto.PerformClick()
        End Select
    End Sub

    Private Sub Inventario_BusquedaProductosBodega_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub txtPRODUCTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{F3}")
            If (Me.dgvProductos.RowCount > 0) Then
                If BuscaTodos = True Then
                    Producto = Me.dgvProductos.Rows(0).Cells.Item(0).Value
                    Descripcion_Producto = Me.dgvProductos.Rows(0).Cells.Item(1).Value
                    Me.Close()
                    Me.Dispose()
                Else
                    If intPromocion <> 4 Then
                        If Me.dgvProductos.Rows(0).Cells.Item(6).Value = False Then
                            Producto = Me.dgvProductos.Rows(0).Cells.Item(0).Value
                            Descripcion_Producto = Me.dgvProductos.Rows(0).Cells.Item(1).Value
                            Me.Close()
                            Me.Dispose()
                        Else
                            MsgBox("¡Debe seleccionar un Producto que no sea Servicio! Verifique", MsgBoxStyle.Critical, "Validación")
                        End If
                    Else
                        Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
                        Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                        Me.Close()
                        Me.Dispose()
                    End If                    
                End If
            Else
                Producto = ""
            End If
        End If
    End Sub

    Private Sub txtDESCRIPCION_PRODUCTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDESCRIPCION_PRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{F3}")
            
            If (Me.dgvProductos.RowCount > 0) Then
                If BuscaTodos = True Then
                    Producto = Me.dgvProductos.Rows(0).Cells.Item(0).Value
                    Descripcion_Producto = Me.dgvProductos.Rows(0).Cells.Item(1).Value
                    Me.Close()
                    Me.Dispose()
                Else
                    If intPromocion <> 4 Then
                        If Me.dgvProductos.Rows(0).Cells.Item(6).Value = False Then
                            Producto = Me.dgvProductos.Rows(0).Cells.Item(0).Value
                            Descripcion_Producto = Me.dgvProductos.Rows(0).Cells.Item(1).Value
                            Me.Close()
                            Me.Dispose()
                        Else
                            MsgBox("¡Debe seleccionar un Producto que no sea Servicio! Verifique", MsgBoxStyle.Critical, "Validación")
                        End If
                    Else
                        Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
                        Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                        Me.Close()
                        Me.Dispose()
                    End If                    
                End If
            Else
                Producto = ""
            End If
        End If
    End Sub

    Private Sub txtDESCRIPCION_PRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_PRODUCTO.TextChanged
        Dim rows As DataRow()
        Dim CodicionFiltro As String
        Dim Strsort As String = ""

        Select Case dgvProductos.Columns(1).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_PRODUCTO.Text = "" Then
            Me.dgvProductos.DataSource = Table
        Else
            'Se incluyen los brackets por si el nombre de encabezado esta compuesto por mas de una palabra separada por espacios
            CodicionFiltro = "[" & dgvProductos.Columns(1).Name & "]" & " like '" & txtDESCRIPCION_PRODUCTO.Text & "%'"
            rows = Table.Select(CodicionFiltro) 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            ' return filtered dt            
            Me.dgvProductos.DataSource = tablaT
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPromocion.CheckedChanged
        If Me.chkPromocion.Checked = True Then
            intPromocion = 3
        Else
            intPromocion = 1
        End If
    End Sub

    Private Sub dgvProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProductos.DoubleClick
        'If e.RowIndex = -1 Then
        '    Return
        'End If
        If (Me.dgvProductos.RowCount > 0) Then
            If BuscaTodos = True Then
                Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
                Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                Me.Close()
                Me.Dispose()
            Else
                If intPromocion <> 4 Then
                    If Me.dgvProductos.CurrentRow.Cells.Item(6).Value = False Then
                        Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
                        Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                        Me.Close()
                        Me.Dispose()
                    Else
                        MsgBox("¡Debe seleccionar un Producto que no sea Servicio! Verifique", MsgBoxStyle.Critical, "Validación")
                    End If
                Else
                    Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
                    Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
                    Me.Close()
                    Me.Dispose()
                End If
            End If
        Else
            Producto = ""
        End If
    End Sub

    Private Sub Inventario_BusquedaProductosBodega_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    
End Class