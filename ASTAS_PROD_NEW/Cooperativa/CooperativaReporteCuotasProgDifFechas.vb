Public Class CooperativaReporteCuotasProgDifFechas
    Dim Rpts As New frmReportes_Ver
    Dim c_data1 As New jarsClass

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If MsgBox("Desea imprimir el reporte?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
            Me.Label.Visible = True
            Me.btnPrint.Visible = False
            Rpts.RepCuotasProgDistintasFechas(Compañia, Format(Me.dtpFecha.Value, "dd/MM/yyyy"), Usuario, Me.cmbRubro.SelectedValue)
            Rpts.ShowDialog()
            Me.btnPrint.Visible = True
            Me.Label.Visible = False
        End If
    End Sub

    Private Sub CooperativaReporteCuotasProgDifFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        c_data1.CargarCombo(cmbRubro, "SELECT 0 As DEDUCCION, 'Todos los Rubros' As DESCRIPCION_DEDUCCION UNION ALL SELECT DEDUCCION, DESCRIPCION_DEDUCCION FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE DEDUCCION <> 0 AND COMPAÑIA = " & Compañia, "DEDUCCION", "DESCRIPCION_DEDUCCION")
    End Sub

    Private Sub CooperativaReporteCuotasProgDifFechas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class