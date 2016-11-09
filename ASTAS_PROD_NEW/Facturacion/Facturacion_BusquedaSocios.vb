Imports System.Data.SqlClient

Public Class Facturacion_BusquedaSocios

    'Declaración de variables
    Dim Iniciando As Boolean
    Dim sql As String = ""
    Public Compañia_Value As Integer

    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Solo para formulario de facturacion clientes socios
    Public numForm As Integer
    Public Bodega_Fact As Integer
    ''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Constructor
    Dim fill As New cmbFill

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader As SqlDataReader

    Private Sub Contabilidad_BusquedaClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        If Compañia_Value <> Nothing Then
            Me.cmbCOMPAÑIA.SelectedValue = Compañia_Value
        End If
        Iniciando = False
        buscarClientes(Me.cmbCOMPAÑIA.SelectedValue, "XZXZXXZXZXZXZX", "", "0")
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscarClientes(Me.cmbCOMPAÑIA.SelectedValue, Trim(Me.txtNombreCliente.Text), Trim(Me.txtNumSocio.Text), Trim(Me.txtCodEmp.Text))
        limpiaCampos()
    End Sub

    Private Sub buscarClientes(ByVal cia As Integer, ByVal nomCliente As String, ByVal NumSocio As String, ByVal codEmpleado As String)
        Dim opcion As String
        Conexion_ = fill.devuelveCadenaConexion()
        If cia = Nothing Then
            cia = 0
        End If
        If nomCliente = Nothing Then
            nomCliente = ""
        End If
        If NumSocio = Nothing Then
            NumSocio = ""
        End If
        If codEmpleado = Nothing Then
            codEmpleado = "0"
        End If
        opcion = "0"
        If codEmpleado <> "0" Then
            opcion = "1"
        End If
        If nomCliente.Length > 0 Then
            opcion = "2"
        End If
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_CATALOGO_SOCIOS_BUSQUEDA_EN_VISTA "
            sql &= cia
            sql &= ", '" & nomCliente & "'"
            sql &= ", '" & NumSocio & "'"
            sql &= ", " & codEmpleado
            sql &= ", " & opcion
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvClientes.Columns.Clear()
            Me.dgvClientes.DataSource = Table
            For a As Integer = 0 To Me.dgvClientes.Columns.Count - 1
                Me.dgvClientes.Columns.Item(a).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            Me.dgvClientes.Columns.Item(0).Visible = False
            Me.dgvClientes.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvClientes.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvClientes.Columns.Item(1).Width = 70
            Me.dgvClientes.Columns.Item(2).Width = 70
            Me.dgvClientes.Columns.Item(3).Width = 250
            Me.dgvClientes.Columns.Item(5).Width = 150
            Me.dgvClientes.Columns.Item(7).Width = 150
            Me.dgvClientes.Columns.Item(9).Width = 150
            Me.dgvClientes.Columns.Item(11).Width = 150
            Me.dgvClientes.Columns.Item(4).Visible = False
            Me.dgvClientes.Columns.Item(6).Visible = False
            Me.dgvClientes.Columns.Item(8).Visible = False
            Me.dgvClientes.Columns.Item(10).Visible = False
            For a As Integer = 12 To Me.dgvClientes.Columns.Count - 1
                Me.dgvClientes.Columns(a).Visible = False
            Next
            If Table.Rows.Count = 0 Then
                fill.limpiargrid(Me.dgvClientes)
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub limpiaCampos()
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        If Compañia_Value <> Nothing Then
            Me.cmbCOMPAÑIA.SelectedValue = Compañia_Value
        End If
        Me.txtNombreCliente.Clear()
        Me.txtNumSocio.Clear()
    End Sub

    Private Sub dgvClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If Me.dgvClientes.RowCount = 0 Then
            Return
        Else
            If Me.dgvClientes.CurrentRow.Index < Me.dgvClientes.Rows.Count Then
                Compañia = 0
                Producto = ""
                Numero = ""
                Compañia = Me.dgvClientes.CurrentRow.Cells.Item(0).Value
                Producto = Me.dgvClientes.CurrentRow.Cells.Item(2).Value
                Numero = Me.dgvClientes.CurrentRow.Cells.Item(2).Value.ToString
                Check = Me.dgvClientes.CurrentRow.Cells.Item(19).Value
                Me.Dispose()
                Me.Close()
            Else
                Compañia = 0
                Producto = ""
                Numero = ""
                Check = 0
            End If
        End If
    End Sub

    'Validacion comilla simple
    Private Sub txtNombreCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreCliente.KeyPress
        'fill.noComillaSimple(e)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{F3}")
            If (Me.dgvClientes.RowCount > 0) Then
                Compañia = 0
                Producto = ""
                Numero = ""
                Compañia = Me.dgvClientes.CurrentRow.Cells.Item(0).Value
                Producto = Me.dgvClientes.CurrentRow.Cells.Item(2).Value
                Numero = Me.dgvClientes.CurrentRow.Cells.Item(2).Value.ToString
                Check = Me.dgvClientes.CurrentRow.Cells.Item(19).Value
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.Close()
            Case Keys.F1
                'Add the code for the function key F1 here.
                'Me.btnCopiaPedido.PerformClick()
            Case Keys.F2
                'Add the code for the function key F2 here.
                'Me.btnAnular.PerformClick()
            Case Keys.F3
                'Add the code for the function key F5 here.
                Me.btnBuscar.PerformClick()
            Case Keys.F4
                'Add the code for the function key F6 here.
            Case Keys.F5
                'Add the code for the function key F7 here.
            Case Keys.F6
                'Add the code for the function key F9 here.
            Case Keys.F7
                'Add the code for the function key F10 here.
                'btnEliminarProducto.PerformClick()
        End Select
    End Sub

    Private Sub Facturacion_BusquedaSocios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumSocio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSocio.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumSocio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumSocio.LostFocus
        If txtNumSocio.Text.Length > 0 Then
            txtNumSocio.Text = txtNumSocio.Text.PadLeft(6, "0")
        End If
    End Sub

    Private Sub txtNumSocio_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtNumSocio.MaskInputRejected
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = dgvClientes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvClientes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtNumSocio.Text = "" Then
            Me.dgvClientes.DataSource = Table
        Else
            rows = Table.Select("[" & dgvClientes.Columns(columna).Name & "] like '" & txtNumSocio.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvClientes.DataSource = tablaT
        End If
    End Sub

    Private Sub txtCodEmp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodEmp.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 2
        Dim Ncolumn As String = dgvClientes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvClientes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtCodEmp.Text = "" Then
            Me.dgvClientes.DataSource = Table
        Else
            rows = Table.Select("[" & dgvClientes.Columns(columna).Name & "] like '%" & txtCodEmp.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvClientes.DataSource = tablaT
        End If
    End Sub

    Private Sub txtNombreCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreCliente.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 3
        Dim Ncolumn As String = dgvClientes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvClientes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtNombreCliente.Text = "" Then
            Me.dgvClientes.DataSource = Table
        Else
            'JASC 27082013
            rows = Table.Select("[" & dgvClientes.Columns(columna).Name & "] like '%" & txtNombreCliente.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvClientes.DataSource = tablaT
        End If
    End Sub
End Class