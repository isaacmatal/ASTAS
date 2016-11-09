Imports System.Data.SqlClient

Public Class Cooperaitiva_Reporte_Deudas_Agrupado_Anual
    Dim jClass As New jarsClass
    Dim rpt As New Cooperativa_Capital_Deudas_Agrupado_Anual

    Private Sub Cooperaitiva_Reporte_Deudas_Agrupado_Anual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaTipoSolicitudes()
        jClass.CargaCompañia(cmbAsociacion)
        Me.cmbAsociacion.SelectedValue = Compañia
    End Sub

    Private Sub CargaTipoSolicitudes()
        Dim sql As String
        Dim Table As DataTable
        sql = "SELECT SOLICITUD, DESCRIPCION_SOLICITUD AS DESCRIPCION FROM COOPERATIVA_CATALOGO_SOLICITUDES"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.dgvTipoSolicitud.DataSource = Table
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim tipos As String = String.Empty
        For i As Integer = 0 To Me.dgvTipoSolicitud.Rows.Count - 1
            If Me.dgvTipoSolicitud.Rows(i).Cells("selec").Value Then
                If tipos.Length = 0 Then
                    tipos &= Me.dgvTipoSolicitud.Rows(i).Cells("tiposoli").Value.ToString()
                Else
                    tipos &= "," & Me.dgvTipoSolicitud.Rows(i).Cells("tiposoli").Value.ToString()
                End If
            End If
        Next
        If tipos.Length = 0 Then
            MsgBox("Seleccione al menos un tipo de solicitud.", MsgBoxStyle.Information, "Seleccionar Tipo")
            Return
        End If
        If tipos.Contains(",") Then
            Me.CrystalReportViewer1.DisplayGroupTree = True
        Else
            Me.CrystalReportViewer1.DisplayGroupTree = False
        End If
        rpt.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE [dbo].[sp_COOPERATIVA_CARTERA_PRESTAMOS_GRUPO_ANUAL] @COMPAÑIA = " & Me.cmbAsociacion.SelectedValue & ", @YEAR = " & Now.Year & ", @TIPOSOLI = '" & tipos & "'")))
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub Cooperaitiva_Reporte_Deudas_Agrupado_Anual_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class