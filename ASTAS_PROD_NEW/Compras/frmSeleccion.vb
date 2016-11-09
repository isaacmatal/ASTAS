Public Class frmSeleccion

    Private Sub frmSeleccion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Not Me.radSiAfectan.Checked And Not Me.radNoAfectan.Checked Then
            MsgBox("No ha seleccionado el tipo de compra...", MsgBoxStyle.Critical, "Sistema")
            Return
        End If

        Dim _compra As New Contabilidad_OrdenCompra_Directa()
        _compra.MdiParent = Me.Parent.Parent
        _compra.afectan_inventario = Me.radSiAfectan.Checked
        _compra.Show()

        Me.Dispose()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub radSiAfectan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSiAfectan.CheckedChanged

    End Sub
End Class