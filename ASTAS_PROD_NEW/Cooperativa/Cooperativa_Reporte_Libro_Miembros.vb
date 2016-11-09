Imports System.Data.SqlClient

Public Class Cooperativa_Reporte_Libro_Miembros
    Private Sub Cooperativa_Reporte_Constancia_Cancelacion_Prestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim jClass As New jarsClass
        Dim rpt As New Cooperativa_Libro_Miembros_Asociacion
        rpt.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE [Coo].[sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS] @COMPAÑIA = " & Compañia & ", @BANDERA = 17, @FECHA = '" & Format(Me.dtpFechaReporte.Value, "dd/MM/yyyy") & "'")))
        Me.crvReporte.ReportSource = rpt
    End Sub
End Class