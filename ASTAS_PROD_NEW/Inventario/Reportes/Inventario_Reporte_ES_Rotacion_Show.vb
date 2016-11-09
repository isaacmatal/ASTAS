Imports System.Data.SqlClient
Public Class Inventario_Reporte_ES_Rotacion_Show
    Public _table_rep As New DataTable

    Private Sub Inventario_Reporte_ES_Rotacion_Show_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Rpt As New Inventarios_Reporte_Analisis_Rotacion
        Rpt.SetDataSource(_table_rep)
        Me.crvReporte.ReportSource = Rpt
    End Sub
End Class