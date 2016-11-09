'' =============================================
'' Author:		Joan Serrano
'' Create date: 07-Feb-2011
'' Description:	Movimiento de inventarios Busqueda
'' =============================================

Imports System.Data
Imports System.Data.SqlClient

Public Class Inventario_Movimientos_Busqueda

    Dim fill As New cmbFill
    Dim Iniciando As Boolean

    Private Sub Inventario_Movimientos_Busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        'Cargar datos de compañia con la clace compañia         
        CargaGrupo_busqueda(Compañia, 2)
        CargaSubGrupo_busqueda(Compañia, Me.cmbGRUPO.SelectedValue, 2)
        'Cargar la grid con todos los datos de productos
        LlenarGrid(Compañia, 999, 999, "", 1)
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

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

#Region "Cargar Grupos y Sub Grupos"

    Private Sub CargaGrupo_busqueda(ByVal Compañia, ByVal Bandera)
        Try
            OpenConnection()
            SQL = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS "
            SQL &= Compañia
            SQL &= ", " & Bandera
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            Me.cmbGRUPO.DataSource = table
            Me.cmbGRUPO.ValueMember = "Grupo"
            Me.cmbGRUPO.DisplayMember = "Descripción Grupo"
            Me.cmbGRUPO.SelectedValue = 999
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub CargaSubGrupo_busqueda(ByVal Compañia, ByVal Grupo, ByVal Bandera)
        Try
            OpenConnection()
            SQL = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS "
            SQL &= Compañia
            SQL &= ", " & Grupo
            SQL &= ", " & Bandera
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)
            Me.cmbSUBGRUPO.DataSource = table
            Me.cmbSUBGRUPO.ValueMember = "Sub Grupo"
            Me.cmbSUBGRUPO.DisplayMember = "Descripción"
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubGrupo_busqueda(Compañia, Me.cmbGRUPO.SelectedValue, 2)
        End If
    End Sub

#End Region

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        'enviar parametros para la busqueda
        LlenarGrid(Compañia, Me.cmbGRUPO.SelectedValue, IIf(Me.cmbSUBGRUPO.SelectedValue = Nothing, "999", Me.cmbSUBGRUPO.SelectedValue), Trim(Me.Txt_Producto_descripcion.Text), 1)
    End Sub

#Region "Busqueda"

    Sub LlenarGrid(ByVal Compañia0, ByVal Grupo0, ByVal Subgrupo0, ByVal DescripcionProducto0, ByVal Bandera0)
        Try
            DS01.Reset()
            OpenConnection()
            SQL = "Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS_BUSQUEDA "
            SQL &= Compañia0
            SQL &= ", " & Grupo0
            SQL &= ", " & Subgrupo0
            SQL &= ", '" & DescripcionProducto0 & "'"
            SQL &= ", " & Bandera0
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Datagrid_productos.DataSource = DS01.Tables(0)
            CloseConnection()
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            CloseConnection()
            'MsgBox("Hola")
        End Try
        Datagrid_productos.Columns.Item(2).Visible = False
        Datagrid_productos.Columns.Item(3).Visible = False
        Datagrid_productos.Columns.Item(4).Visible = False
        Datagrid_productos.Columns.Item(5).Visible = False
        Datagrid_productos.Columns.Item(6).Visible = False
        Datagrid_productos.Columns.Item(7).Visible = False
        Datagrid_productos.Columns.Item(8).Visible = False
        Datagrid_productos.Columns.Item(9).Visible = False
        Datagrid_productos.Columns.Item(10).Visible = False
        Datagrid_productos.Columns.Item(11).Visible = False
        Datagrid_productos.Columns.Item(13).Visible = False
        For i As Integer = 1 To 16
            Datagrid_productos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Private Sub Datagrid_productos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagrid_productos.CellEnter
        Me.Txt_Producto_codigo.Text = Me.Datagrid_productos.CurrentRow.Cells.Item(0).Value
        Me.Txt_Producto_descripcion.Text = Me.Datagrid_productos.CurrentRow.Cells.Item(1).Value
    End Sub

    Private Sub Datagrid_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagrid_productos.CellContentClick
        Try
            If Datagrid_productos.RowCount = 0 Then
                Return
            Else
                CodigoProducto = Datagrid_productos.CurrentRow.Cells(0).Value
                Descripcion_Producto = Datagrid_productos.CurrentRow.Cells(1).Value
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub Txt_Producto_descripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Producto_descripcion.KeyDown
        If e.KeyValue = 13 Then
            'MessageBox.Show("Presiono la tecla enter")
            btnBuscarProducto_Click(sender, e)
        End If
    End Sub

End Class