Public Class frmRepDeudasSociosRetirados

    Private Sub frmRepDeudasSociosRetirados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.btnPrint.Visible = False
        Dim _reporte As New frmReportes_Ver()
        _reporte.RptDeudasSociosRetirados(Compañia, Usuario)
        _reporte.ShowDialog()
        Me.btnPrint.Visible = True
    End Sub

    Private Sub frmRepDeudasSociosRetirados_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class