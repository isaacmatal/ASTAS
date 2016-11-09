Imports System.Data
Imports System.Data.SqlClient

Public Class frm_reporte_cooperativa_retiro_ahorro_recibo
    Dim jClass As New jarsClass
    Dim SQL As String

    Public Sub Reporte()
        Dim Table As DataTable
        Dim Rpt As New rpt_reporte_cooperativa_retiro_ahorro_recibo1
        Try
            SQL = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & Me.lblRetiro.Text & ", " & Me.lblBuxis.Text & ", '" & Me.lblSocio.Text & "', 'SE', 'Monto'"
            Table = jClass.obtenerDatos(New SqlCommand(SQL))
            Rpt.SetDataSource(Table)
            Me.CrystalReportViewer1.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frm_reporte_cooperativa_retiro_ahorro_carta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reporte()
    End Sub
End Class