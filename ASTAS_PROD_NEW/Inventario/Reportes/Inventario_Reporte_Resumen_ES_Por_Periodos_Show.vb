Imports System.Data.SqlClient
Public Class Inventario_Reporte_Resumen_ES_Por_Periodos_Show
    Public _table_rep As New DataTable
    Dim ExpExcel As New ExportDataExcel

    Private Sub Inventario_Reporte_Resumen_ES_Por_Periodos_Show_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgvResumenES.DataSource = _table_rep
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        If MsgBox("¿Desea exportar los datos a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            ExpExcel.ExportarDatosExcel(Me.dgvResumenES, "DatosExportados")
        End If
    End Sub
End Class