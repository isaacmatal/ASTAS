Imports System.Data.SqlClient

Public Class Contabilidad_Reporte_Comp_Deud_Acreed

    Dim jClass As New jarsClass

    Private Sub Contabilidad_Reporte_Comp_Deud_Acreed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaDatos(Now.Year)
        Me.nudYear.Value = Now.Year
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudYear.ValueChanged
        CargaDatos(CInt(Me.nudYear.Value))
    End Sub

    Private Sub CargaDatos(ByVal Year As Integer)
        Dim sql As String = "EXECUTE sp_CONTABILIDAD_REPORTE_AUXILIAR @COMPAÑIA = " & Compañia & ", @TAMAÑO = " & Year
        Dim Table As DataTable = jClass.obtenerDatos(New SqlCommand(sql))
        Dim rpt As New Contabilidad_Comparativo_Deudoras_Acreedoras
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub
End Class