'' Author:		Oscar Avilés
'' Create date: 13-Mar-2011
'' Description:	Busqueda de Recetas por bodega definidas en el manejo de Recetas.
'' =============================================

Imports System.Data.SqlClient
Public Class Cafeteria_Busqueda_Recetas_por_Bodega

    Private Sub Cafeteria_Busqueda_Recetas_por_Bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        CargarGrid(Me.TxtCompañia_cod.Text, Me.TxtBodega_cod.Text, Me.Txt_Producto_codigo.Text, 0)
        Iniciando = False
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

    Sub CargarGrid(ByVal CIA, ByVal Bodega, ByVal Codigo, ByVal Bandera)
        Try
            DS01.Reset()
            OpenConnection()

            SQL = "EXECUTE sp_CAFETERIA_CATALOGO_RECETA_BODEGA "
            SQL &= "@COMPAÑIA = " & Val(CIA)
            SQL &= ",@BODEGA = " & Val(Bodega)
            SQL &= ",@USUARIO = N'" & Usuario & "'"
            SQL &= ",@CODIGO = " & Val(Codigo)
            SQL &= ",@IUD= " & Bandera

            MiddleConnection()
            DataAdapter.Fill(DS01)
            Me.Datagrid_productos.DataSource = DS01.Tables(0)
            CloseConnection()

            'Ajustar el tamaño de las columnas del grid de forma automatica
            For i As Integer = 0 To 2
                Me.Datagrid_productos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try

    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Bandera As Integer
        If Val(Me.Txt_Producto_codigo.Text) > 0 And CStr(Me.Txt_Producto_descripcion.Text) = Nothing Then
            Bandera = 1
        ElseIf Val(Me.Txt_Producto_codigo.Text) <= 0 And CStr(Me.Txt_Producto_descripcion.Text) <> Nothing Then
            Bandera = 2
        ElseIf Val(Me.Txt_Producto_codigo.Text) <= 0 And CStr(Me.Txt_Producto_descripcion.Text) = Nothing Then
            Bandera = 0
        End If
        CargarGrid(Me.TxtCompañia_cod.Text, Me.TxtBodega_cod.Text, Me.Txt_Producto_codigo.Text, Bandera)
    End Sub

    Private Sub Btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_limpiar.Click
        Limpiar()
    End Sub
    Sub Limpiar()
        Me.Txt_Producto_codigo.Clear()
        Me.Txt_Producto_descripcion.Clear()
        Me.Txt_Producto_descripcion.Focus()
    End Sub
    Private Sub Datagrid_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid_productos.Click
        CodigoProducto = Datagrid_productos.CurrentRow.Cells(0).Value
        Descripcion_Producto = Datagrid_productos.CurrentRow.Cells(1).Value
        unidades = Datagrid_productos.CurrentRow.Cells(2).Value.ToString()
        Me.Close()
    End Sub

    Private Sub Txt_Producto_codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class