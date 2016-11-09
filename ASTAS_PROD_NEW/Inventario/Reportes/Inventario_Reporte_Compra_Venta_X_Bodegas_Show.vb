Imports System.Data.SqlClient

Public Class Inventario_Reporte_Compra_Venta_X_Bodegas_Show
    Public _table_rep As New DataTable

    Private Sub Inventario_Reporte_Compra_Venta_X_Bodegas_Show_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Rpt As New Inventario_Reporte_ES_Por_Bodega
        Rpt.SetDataSource(_table_rep)
        Me.crvReporte.ReportSource = Rpt
    End Sub
End Class