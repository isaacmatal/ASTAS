Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_Reporte_Auditoria_Partidas_DesProcesadas

    Dim Table As DataTable
    Dim sql As String
    Dim jClass As New jarsClass
    Dim rpt As New Contabilidad_Auditoria_Partidas_DesProcesadas

    Private Sub Contabilidad_Reporte_Auditoria_Partidas_DesProcesadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFechaContable.Value = CDate(jClass.obtenerEscalar("SELECT TOP 1 CONVERT(VARCHAR,AÑO) + '-' + DBO.PadLeft(CONVERT(VARCHAR,MES),'0',2) + '-01'  FROM [dbo].[CONTABILIDAD_CATALOGO_CIERRE_CONTABLE] ORDER BY AÑO DESC, MES DESC"))
        Me.CargarDatos()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargarDatos()
        sql = "SELECT C.NOMBRE_COMPAÑIA, "
        sql &= "       D.PARTIDA, "
        sql &= "	   D.TRANSACCION, "
        sql &= "	   D.FECHA_PARTIDA, "
        sql &= "	   D.MOTIVO, "
        sql &= "	   D.CORRELATIVO, "
        sql &= "	   U.NOMBRE_USUARIO AS USUARIO_CREACION, "
        sql &= "       D.USUARIO_CREACION_FECHA"
        sql &= "  FROM CONTABILIDAD_AUDITORIA_PARTIDAS_DESPROCESADAS D, CATALOGO_COMPAÑIAS C, CATALOGO_USUARIOS U"
        sql &= " WHERE D.COMPAÑIA = C.COMPAÑIA AND D.COMPAÑIA = U.COMPAÑIA AND D.USUARIO_CREACION = U.USUARIO"
        sql &= "   AND MONTH(D.FECHA_PARTIDA) = " & Me.dpFechaContable.Value.Month & " AND YEAR(D.FECHA_PARTIDA) = " & Me.dpFechaContable.Value.Year
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub dpFechaContable_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaContable.ValueChanged
        Me.CargarDatos()
    End Sub

    Private Sub Contabilidad_Reporte_Auditoria_Partidas_DesProcesadas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class