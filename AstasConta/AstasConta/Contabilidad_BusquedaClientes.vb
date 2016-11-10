Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaClientes

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
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscarClientes(Me.cmbCOMPAÑIA.SelectedValue, Trim(Me.txtNombreCliente.Text), Trim(Me.txtNitCliente.Text))
        limpiaCampos()
    End Sub

    Public Sub buscarClientes(ByVal cia, ByVal nomCliente, ByVal nit)
        Conexion_ = fill.devuelveCadenaConexion()
        If cia = Nothing Then
            cia = 0
        End If
        If nomCliente = Nothing Then
            nomCliente = "0"
        End If
        If nit = "-      -   -" Then
            nit = "0"
        End If
        Try
            Conexion_.Open()
            sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
            sql &= cia
            sql &= ", '" & nomCliente & "'"
            sql &= ", '" & nit & "'"
            sql &= ", " & 1
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            If Table.Rows.Count <> 0 Then
                Me.dgvClientes.Columns.Clear()
                Me.dgvClientes.DataSource = Table
                Me.dgvClientes.Columns.Item(0).Visible = False
                Me.dgvClientes.Columns.Item(8).Visible = False
                Me.dgvClientes.Columns.Item(9).Visible = False
                Me.dgvClientes.Columns.Item(13).Visible = False
                fill.ajustarGrid(16, Me.dgvClientes)
            Else
                MsgBox("No se encuentran registros", MsgBoxStyle.Information, "Mensaje")
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
        Me.txtNitCliente.Clear()
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
                Producto = Me.dgvClientes.CurrentRow.Cells.Item(1).Value
                Numero = Me.dgvClientes.CurrentRow.Cells.Item(7).Value
                Check = Me.dgvClientes.CurrentRow.Cells.Item(13).Value
                'Esto es para la facturacion de los clientes socios en caso no sea ese formulario sólo tomará los datos
                If numForm = 4688 Then
                    If (Bodega_Fact = 14 Or Bodega_Fact = 15 Or Bodega_Fact = 16) And Check <> 0 Then
                        Me.Close()
                        Me.Dispose()
                    ElseIf (Bodega_Fact = 14 Or Bodega_Fact = 15 Or Bodega_Fact = 16) And Check = 0 Then
                        MsgBox("Para el tipo de bodega que ha escogido, debe elegir otro tipo de cliente", MsgBoxStyle.Exclamation, "Atención")
                        Compañia = 0
                        Producto = ""
                        Numero = ""
                        Check = 0
                    ElseIf (Bodega_Fact <> 14 And Bodega_Fact <> 15 And Bodega_Fact <> 16) And Check = 0 Then
                        Me.Close()
                        Me.Dispose()
                    ElseIf (Bodega_Fact <> 14 And Bodega_Fact <> 15 And Bodega_Fact <> 16) And Check <> 0 Then
                        MsgBox("Para el tipo de bodega que ha escogido, debe elegir otro tipo de cliente", MsgBoxStyle.Exclamation, "Atención")
                        Compañia = 0
                        Producto = ""
                        Numero = ""
                        Check = 0
                    End If
                Else
                    Me.Close()
                    Me.Dispose()
                End If
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
        fill.noComillaSimple(e)
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

    Private Sub Contabilidad_BusquedaClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub
End Class