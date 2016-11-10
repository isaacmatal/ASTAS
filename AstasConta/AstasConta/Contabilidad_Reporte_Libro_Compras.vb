Imports System.Data.SqlClient

Public Class CONTABILIDAD_REPORTE_LIBRO_COMPRAS
    Dim jClass As New jarsClass

    Private Sub CONTABILIDAD_REPORTE_LIBRO_COMPRAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.fecha_Ini.Value = Now.AddDays(-Now.Day).AddDays(1)
        Me.Fecha_Fin.Value = Now.AddMonths(1).AddDays(-Now.AddMonths(1).Day)
        Me.dgvBodegas.DataSource = jClass.obtenerDatos(New SqlCommand("Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compañia & ", 0, '" & Usuario & "'"))
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim Sql As String
        Dim Table As DataTable
        Dim Rpt As New Contabilidad_Reporte_Libro_Compras_Rpt
        Dim Bodegas As String = String.Empty
        Dim DescBodegas As String = String.Empty
        Try
            For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
                If Me.dgvBodegas.Rows(i).Cells(0).Value Then
                    Bodegas &= IIf(Bodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(2).Value
                    DescBodegas &= IIf(DescBodegas.Length = 0, "", ", ") & Me.dgvBodegas.Rows(i).Cells(3).Value
                End If
            Next
            If Bodegas.Length > 0 Then
                Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_LIBRO_COMPRAS " & vbCrLf
                Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ",@BODEGA   = '" & Bodegas & "'" & vbCrLf
                Sql &= ",@FEC_INI  = '" & Format(Me.fecha_Ini.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ",@FEC_FIN  = '" & Format(Me.Fecha_Fin.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ",@CONSOLI  = 0" & vbCrLf 'IIf(Me.ChkConsolida.Checked = True, 1, 0) & vbCrLf
                Sql &= ",@USUARIO  = '" & Usuario & "'"
                Table = jClass.obtenerDatos(New SqlCommand(Sql))
                If Table.Rows.Count > 0 Then
                    If Not Me.ChkConsolida.Checked Then
                        txtObj = Rpt.Section2.ReportObjects.Item("txtBodegas")
                        txtObj.Text = DescBodegas
                    End If
                    Rpt.SetDataSource(Table)
                    Me.crvReporte.ReportSource = Rpt
                    Me.crvReporte.Zoom(1)
                Else
                    Me.crvReporte.ReportSource = Nothing
                    MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
                End If
            Else
                MsgBox("Debe seleccionar al menos una bodega para procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "AVISO")
        End Try
    End Sub

    Private Sub CONTABILIDAD_REPORTE_LIBRO_COMPRAS_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub ChkConsolida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkConsolida.CheckedChanged
        For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
            Me.dgvBodegas.Rows(i).Cells(0).Value = Me.ChkConsolida.Checked
        Next
    End Sub
End Class