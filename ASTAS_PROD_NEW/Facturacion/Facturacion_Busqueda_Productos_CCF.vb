Public Class Facturacion_Busqueda_Productos_CCF
    Private Sub dgvProductos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex = -1 Then
            Return
        End If
        Numero = e.RowIndex
        Me.Close()
    End Sub
End Class