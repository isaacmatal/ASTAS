Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaOrdenCompra
    Dim Sql As String
    Dim Iniciando As Boolean
    Public Compañia_Value As Integer
    Public Bodega_Value As Integer
    Dim columna As Integer = 1 'Valor numero de la columna del DataGridView.
    Dim Table As DataTable

    Private Sub Contabilidad_BusquedaOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        Me.cmbCOMPAÑIA.SelectedValue = Compañia_Value
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 4)
        Me.cmbBODEGA.SelectedValue = Bodega_Value
        btnBuscar.PerformClick()
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA  = " & Bandera & ", "
            Sql &= "@COMPAÑIA = " & Compañia & ", "
            Sql &= "@USUARIO  = '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarOC(ByVal Compañia, ByVal Bodega, ByVal OC, ByVal NombreProveedor, ByVal NombreComercial, ByVal NIT, ByVal NRC, ByVal FechaIni, ByVal FechaFin, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter

        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & OC
            Sql &= ", '" & NombreProveedor & "'"
            Sql &= ", '" & NombreComercial & "'"
            Sql &= ", '" & NIT & "'"
            Sql &= ", '" & NRC & "'"
            Sql &= ", '" & Format(FechaIni, "dd-MM-yyyy 00:00:01") & "'"
            Sql &= ", '" & Format(FechaFin, "dd-MM-yyyy 23:59:59") & "'"
            Sql &= ", " & Bandera
            Sql &= ",'" & IIf(cbAfectanInventarios.Checked, "1", "0") & "'" 'VALOR DE FILTRADO SI ES OC NORMAL O QUE NO AFECTEN INVENTARIOS
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")

            DataAdapter_.Fill(Table)
            ''
            ''''''''
            Me.dgvOrdenesCompra.Columns.Clear()
            Me.dgvOrdenesCompra.DataSource = Table
            'Me.dgvOrdenesCompra.Columns(0).ValueType = GetType(Integer)
            Conexion_.Close()
            LimpiaGrid()
        Catch ex As Exception
            MsgBox("NO HAY ORDENES DE COMPRA")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtOC.Text = ""
        Me.txtNOMBRE_PROVEEDOR.Text = ""
        Me.txtNOMBER_COMERCIAL.Text = ""
        Me.txtNIT.Text = ""
        Me.txtNRC.Text = ""
    End Sub

    Private Sub LimpiaGrid()
        If Me.dgvOrdenesCompra.ColumnCount > 0 Then
            Me.dgvOrdenesCompra.Columns(0).Width = 50 'OC
            Me.dgvOrdenesCompra.Columns(1).Width = 125 'Fecha
            Me.dgvOrdenesCompra.Columns(2).Width = 60 'Procesada
            Me.dgvOrdenesCompra.Columns(3).Width = 200 'Nombre
            Me.dgvOrdenesCompra.Columns(4).Width = 150 'Comercial
            ' Me.dgvOrdenesCompra.Columns(5).Width = 50 'NIT
            Me.dgvOrdenesCompra.Columns(6).Width = 50 'NRC
            Me.dgvOrdenesCompra.Columns(7).Width = 75 'FormaPago
            Me.dgvOrdenesCompra.Columns(8).Width = 75 'Condicion
            Me.dgvOrdenesCompra.Columns(9).Width = 75 'Usuario
            Me.dgvOrdenesCompra.Columns(10).Width = 125 'Fecha

        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Val(Trim(Me.txtOC.Text)), Trim(Me.txtNOMBRE_PROVEEDOR.Text), Trim(Me.txtNOMBER_COMERCIAL.Text), Trim(Me.txtNIT.Text), Trim(Me.txtNRC.Text), Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "0", "1"))
        LimpiaCampos()
    End Sub

    Private Sub dgvOrdenesCompra_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrdenesCompra.CellClick
        'If Me.dgvOrdenesCompra.CurrentRow.Index < Me.dgvOrdenesCompra.Rows.Count Then
        '    Producto = Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value
        '    Descripcion_Producto = Me.cmbBODEGA.SelectedValue
        '    Me.Close()
        '    Me.Dispose()
        'Else
        '    Producto = ""
        '    Descripcion_Producto = ""
        'End If
    End Sub



    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 2)
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub txtNOMBRE_PROVEEDOR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNOMBRE_PROVEEDOR.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 3
            Dim Ncolumn As String = dgvOrdenesCompra.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvOrdenesCompra.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If txtNOMBRE_PROVEEDOR.Text = "" Then
                Me.dgvOrdenesCompra.DataSource = Table
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table.Select("[" & dgvOrdenesCompra.Columns(columna).Name & "] like '" & txtNOMBRE_PROVEEDOR.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvOrdenesCompra.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub txtNOMBER_COMERCIAL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNOMBER_COMERCIAL.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 4
            Dim Ncolumn As String = dgvOrdenesCompra.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvOrdenesCompra.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If txtNOMBER_COMERCIAL.Text = "" Then
                Me.dgvOrdenesCompra.DataSource = Table
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table.Select("[" & dgvOrdenesCompra.Columns(columna).Name & "] like '" & txtNOMBER_COMERCIAL.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvOrdenesCompra.DataSource = tablaT
            End If
        End If
    End Sub

    Private Sub txtNIT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIT.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 5
            Dim Ncolumn As String = dgvOrdenesCompra.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvOrdenesCompra.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If txtNIT.Text = "" Then
                Me.dgvOrdenesCompra.DataSource = Table
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table.Select("[" & dgvOrdenesCompra.Columns(columna).Name & "] like '" & txtNIT.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvOrdenesCompra.DataSource = tablaT
            End If
        End If
    End Sub

    Private Sub txtNRC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNRC.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            columna = 6
            Dim Ncolumn As String = dgvOrdenesCompra.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvOrdenesCompra.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If txtNRC.Text = "" Then
                Me.dgvOrdenesCompra.DataSource = Table
            Else
                'rows = Table.Select(dgvOrdene%sCompra.Columns(columna).Name & " like '" & txtOC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                rows = Table.Select("[" & dgvOrdenesCompra.Columns(columna).Name & "] like '" & txtNRC.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvOrdenesCompra.DataSource = tablaT
            End If
        End If
    End Sub

    Private Sub txtOC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOC.KeyPress
        If Iniciando = False Then
            If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
                BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Val(Trim(Me.txtOC.Text)), Trim(Me.txtNOMBRE_PROVEEDOR.Text), Trim(Me.txtNOMBER_COMERCIAL.Text), Trim(Me.txtNIT.Text), Trim(Me.txtNRC.Text), Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, IIf(Me.chkFechas.Checked = True, "0", "1"))
                LimpiaCampos()
            End If
        End If
    End Sub

    Private Sub dgvOrdenesCompra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOrdenesCompra.DoubleClick
        If Me.dgvOrdenesCompra.CurrentRow.Index < Me.dgvOrdenesCompra.Rows.Count Then
            Producto = Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value
            Descripcion_Producto = Me.cmbBODEGA.SelectedValue
            Me.Close()
            Me.Dispose()
        Else
            Producto = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub Contabilidad_BusquedaOrdenCompra_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class