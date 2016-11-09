Public Class CooperativaRPTCuotasSinCancelar

    Private Sub CooperativaRPTCuotasSinCancelar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub CooperativaRPTCuotasSinCancelar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.btnPrint.Visible = False
        Dim _reporte As New frmReportes_Ver()
        _reporte.RptCuotasSinCancelar(Compañia, CDate(Me.dtpFecha.Value.ToShortDateString()))
        _reporte.ShowDialog()
        Me.btnPrint.Visible = True
    End Sub
End Class