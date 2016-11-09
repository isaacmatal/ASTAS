'' =============================================
'' Author:		Joan Serrano/Esteban Gámez
'' Create date: 22-Feb-2011
'' Description:	Movimiento de inventarios busqueda de productos por bodega
'' =============================================

Imports System.Data.SqlClient

Public Class Inventario_Movimiento_busqueda_productos_por_bodega

    Private Sub Inventario_Movimiento_busqueda_productos_por_bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        CargarGrid(Val(Me.TxtCompañia_cod.Text), 0, "", 0)
        Me.TxtCompañia.Text = Descripcion_Compañia
        Me.Txt_Producto_descripcion.Focus()
        Iniciando = False
    End Sub
    Public Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Left
                Txt_Codigo.Focus()
            Case Keys.Right
                Txt_Producto_descripcion.Focus()
        End Select
    End Sub

#Region "Connection"

    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Resultado As DialogResult
    ''
    Public Iniciando As Boolean

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        'DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

    Sub CargarGrid(ByVal CIA, ByVal PROD_COD, ByVal PROD_DESC, ByVal BANDERA)
        Try
            DS01.Reset()
            OpenConnection()            
            SQL = "EXECUTE sp_VISTA_INVENTARIOS_BODEGAS_Y_PRODUCTOS_POR_USUARIO_S "
            SQL &= "@COMPAÑIA = " & Val(Me.TxtCompañia_cod.Text)
            SQL &= ",@BODEGA = " & Val(Me.TxtBodega_cod.Text)
            SQL &= ",@PRODUCTO = " & Val(0)
            SQL &= ",@PRODUCTO_DESCRIPCION = '" & Me.Txt_Producto_descripcion.Text & "'"
            SQL &= ",@USUARIO = N'" & Usuario & "'"
            SQL &= ",@SIUD = " & BANDERA
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Me.Datagrid_productos.DataSource = DS01.Tables(0)
            CloseConnection()
            'Ajusntar el tamaño de las columnas del grid de forma automatica
            For i As Integer = 0 To Me.Datagrid_productos.ColumnCount - 1
                Me.Datagrid_productos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next            
        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
    End Sub   

    Private Sub Txt_Producto_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Producto_descripcion.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 1
            Dim Ncolumn As String = Datagrid_productos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case Datagrid_productos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = DS01.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If Txt_Producto_descripcion.Text = "" Then
                Me.Datagrid_productos.DataSource = DS01.Tables(0)
            Else                
                rows = DS01.Tables(0).Select("[" & Datagrid_productos.Columns(columna).Name & "] like '" & Txt_Producto_descripcion.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next
                
                Me.Datagrid_productos.DataSource = tablaT
            End If
        End If        
    End Sub

    Private Sub Datagrid_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid_productos.Click
        Try
            If Datagrid_productos.RowCount = 0 Then
                Return
            Else
                CodigoProducto = Datagrid_productos.CurrentRow.Cells(0).Value
                Descripcion_Producto = Datagrid_productos.CurrentRow.Cells(1).Value
                Producto = CodigoProducto
                unidades = Datagrid_productos.CurrentRow.Cells(2).Value
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Txt_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Codigo.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 0
            Dim Ncolumn As String = Datagrid_productos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case Datagrid_productos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = DS01.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If Txt_Codigo.Text = "" Then
                Me.Datagrid_productos.DataSource = DS01.Tables(0)
            Else
                rows = DS01.Tables(0).Select("[" & Datagrid_productos.Columns(columna).Name & "] like '" & Txt_Codigo.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                Me.Datagrid_productos.DataSource = tablaT


            End If
        End If
    End Sub

    Private Sub Txt_Codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Inventario_Movimiento_busqueda_productos_por_bodega_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class