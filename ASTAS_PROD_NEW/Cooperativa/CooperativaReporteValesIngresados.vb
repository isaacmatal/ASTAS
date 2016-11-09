Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaReporteValesIngresados
    Dim sql As String
    Dim Table As DataTable
    Dim sqlcmd As New SqlCommand
    Dim jClass As New jarsClass

    Private Sub CooperativaReporteValesIngresados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CooperativaReporteValesIngresados_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim rpt As New CooperativaListadoValesIngresados
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject

        txtObj = rpt.Section1.ReportObjects.Item("TextEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt.Section1.ReportObjects.Item("TextPeriodo")
        txtObj.Text = "PERIODO DEL " & Format(Me.dpDesde.Value, "dd/MM/yyyy") & " AL " & Format(Me.dpHasta.Value, "dd/MM/yyyy")
        sql = "SELECT S.CODIGO_BUXIS AS [CODIGO BUXIS], " & vbCrLf
        sql &= "       S. CODIGO_AS AS [CODIGO AS]," & vbCrLf
        sql &= "	   SOC.NOMBRE_COMPLETO AS [NOMBRE]," & vbCrLf
        sql &= "	   A.NUMERO_FACTURA AS [NUMERO VALE]," & vbCrLf
        sql &= "	   S.VALOR_VALE AS VALOR," & vbCrLf
        sql &= "	   S.FECHA_SOLICITUD AS [FECHA SOLICITUD]," & vbCrLf
        sql &= "	   CS.DESCRIPCION_SOLICITUD AS [DESCRIPCION]," & vbCrLf
        sql &= "	   S.CORRELATIVO AS [SOLICITUD No]," & vbCrLf
        sql &= "	   A.AUTORIZACION1 AS [AUTORIZADA]," & vbCrLf
        sql &= "       S.PROGRAMADA" & vbCrLf
        sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES CS, COOPERATIVA_CATALOGO_DEDUCCIONES D, COOPERATIVA_CATALOGO_SOCIOS SOC, COOPERATIVA_SOLICITUDES_AUTORIZACION A" & vbCrLf
        sql &= " WHERE S.COMPAÑIA = CS.COMPAÑIA" & vbCrLf
        sql &= "   AND S.SOLICITUD = CS.SOLICITUD" & vbCrLf
        sql &= "   AND S.COMPAÑIA = A.COMPAÑIA" & vbCrLf
        sql &= "   AND S.CORRELATIVO = A.N_SOLICITUD" & vbCrLf
        sql &= "   AND CS.DEDUCCION = D.DEDUCCION" & vbCrLf
        sql &= "   AND S.COMPAÑIA = SOC.COMPAÑIA" & vbCrLf
        sql &= "   AND S.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
        sql &= "   AND S.CODIGO_AS = SOC.CODIGO_EMPLEADO_AS" & vbCrLf
        sql &= "   AND CS.DESCRIPCION_SOLICITUD LIKE 'VALE%'" & vbCrLf
        sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
        sql &= "   AND CONVERT(DATE, S.FECHA_SOLICITUD) BETWEEN CONVERT(DATE, '" & Format(Me.dpDesde.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpHasta.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
        sqlcmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlcmd)
        rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class