Imports System.Data.SqlClient

Public Class Contabilidad_OC_BuscarProductos
    Dim _obj_compras As New Compras()
    Dim _sql As String = String.Empty
    Public _bodega As Integer
    Dim _iniciando As Boolean

    Private Sub Contabilidad_OC_BuscarProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _iniciando = True
        Me.CargaBodegas()
        Me.CargarArticulos()
        _iniciando = False

        Me.dgvProductos.Columns(0).Width = 60
        Me.dgvProductos.Columns(1).Width = 300
        Me.dgvProductos.Columns(2).Width = 100
    End Sub

    Private Sub CargaBodegas()
        Try
            Dim _tblbodegas As New DataTable()
            _tblbodegas = _obj_compras.obtenerDatos("Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA=13,@COMPAÑIA=" & Compañia & ",@USUARIO='" & Usuario & "'")
            Me.cmbBODEGA.DataSource = _tblbodegas
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
            Me.cmbBODEGA.SelectedValue = _bodega
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargarArticulos()
        Try
            Dim _tbl_productos As New DataTable()
            _sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=0, @DESCRIPCION_PRODUCTO='" & Me.txtDESCRIPCION_PRODUCTO.Text.Trim() & "', @GRUPO=0, @BANDERA=5, @SUBGRUPO=0"
            _tbl_productos = Me._obj_compras.obtenerDatos(_sql)
            Me.dgvProductos.DataSource = _tbl_productos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Not _iniciando Then
            Me.CargarArticulos()
        End If
    End Sub

    Private Sub txtDESCRIPCION_PRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_PRODUCTO.TextChanged
        If Not _iniciando Then
            Me.CargarArticulos()
        End If
    End Sub

    Private Sub dgvProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        Producto = dgvProductos.Rows(dgvProductos.SelectedCells(0).RowIndex).Cells(0).Value.ToString()
        Descripcion_Producto = dgvProductos.Rows(dgvProductos.SelectedCells(0).RowIndex).Cells(1).Value.ToString()
        Me.Dispose()
    End Sub
End Class