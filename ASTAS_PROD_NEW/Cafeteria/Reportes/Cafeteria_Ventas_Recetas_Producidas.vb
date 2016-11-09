Imports System.Data.SqlClient

Public Class Cafeteria_Ventas_Recetas_Producidas
    Dim Rpts As New frmReportes_Ver

    Private Sub Cafeteria_Ventas_Recetas_Producidas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.dtpDesde.Value > Me.dtpHasta.Value Then
            MsgBox("Fechas Incorrectas...", MsgBoxStyle.Critical, "Sistema")
            Return
        End If
        If MsgBox("Desea imprimir el reporte?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
            Me.btnPrint.Visible = False
            Dim _pta As Integer = 0

            If Me.radPlantaUno.Checked Then
                _pta = 1
            Else
                _pta = 2
            End If
            Rpts.RepCafeteriaRecetasProducidas(Me.dtpDesde.Value, Me.dtpHasta.Value, _pta, Compañia, Usuario)
            Rpts.ShowDialog()
            Me.btnPrint.Visible = True
        End If
    End Sub

    Private Sub Cafeteria_Ventas_Recetas_Producidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
    End Sub
End Class