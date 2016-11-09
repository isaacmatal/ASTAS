Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_reporte_cooperativa_retiro_ahorro_cheque

    Dim jClass As New jarsClass
    Dim Sql As String

    Private Sub frm_reporte_cooperativa_retiro_ahorro_cheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim valor As Double
        valor = jClass.obtenerEscalar("SELECT CANTIDAD FROM COOPERATIVA_SOCIO_RETIROS WHERE COMPAÑIA = " & Compañia & " and RETIRO = " & Me.lblRetiro.Text)
        If valor < 150.0 Then
            Me.CheckBox1.Checked = False
        Else
            Me.CheckBox1.Checked = True
        End If
        Reporte()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Reporte()
    End Sub

    Private Sub Reporte()
        Dim Comando_ As New SqlCommand
        Dim Table As DataTable
        Dim Rpt As New rpt_reporte_cooperativa_retiro_ahorro_cheque1
        Try
            Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & Me.lblRetiro.Text & ", " & Me.lblBuxis.Text & ", '" & Me.lblSocio.Text & "', 'SE', 'Monto'"
            Table = jClass.obtenerDatos(Comando_)
            Rpt.SetDataSource(Table)
            Me.CrystalReportViewer1.ReportSource = Rpt
            Rpt.Section3.ReportObjects.Item("Text5").ObjectFormat.EnableSuppress = Not CheckBox1.Checked
            Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject = Rpt.Section3.ReportObjects.Item("Text1")
            TextObj.Text = Me.Banco.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class