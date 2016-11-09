'Autor: Mauricio José Gámez Brito
Imports System.Data.SqlClient
Public Class Facturacion_Busqueda_Productos_Precio_Especial
    Dim Sql As String
    Dim iniciado As Boolean
    Public Bodega_Value As Integer
    Dim jClass As New jarsClass
    Dim Comando_ As New SqlCommand
    Dim Table As DataTable
    Private Sub Facturacion_Busqueda_Productos_Precio_Especial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        iniciado = False
        CargaCompañia()
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 5)
        Me.cmbBODEGA.SelectedValue = Bodega_Value
        cargarGrid()
        iniciado = True
    End Sub

    Private Sub CargaCompañia()
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ",@COMPAÑIA= " & Compañia
            Sql &= ",@USUARIO= '" & Usuario & "'"
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If iniciado = True Then
            cargarGrid()
        End If
    End Sub

    Private Sub cargarGrid()
        Sql = "execute SP_INVENTARIOS_CARGAR_PRODUCTOS_PRECIO_ESPECIAL "
        Sql &= Me.cmbCOMPAÑIA.SelectedValue
        Sql &= " , " & Me.cmbBODEGA.SelectedValue
        Comando_.CommandText = Sql
        Table = jClass.obtenerDatos(Comando_)

        Me.dgvproductos.DataSource = Table
        Me.dgvproductos.Columns(0).Visible = False 'ID
        Me.dgvproductos.Columns(1).Width = 80 ' producto
        Me.dgvProductos.Columns(2).Width = 270 ' descripcion producto
        Me.dgvProductos.Columns(3).Width = 70 'cantidad
        Me.dgvProductos.Columns(4).Width = 70 ' precio

        Me.dgvproductos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvproductos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
        Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgvProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProductos.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Producto = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
            Descripcion_Producto = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
            Me.Close()
            Me.Dispose()
        End If
    End Sub
End Class