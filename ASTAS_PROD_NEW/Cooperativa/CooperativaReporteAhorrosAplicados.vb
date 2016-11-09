Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaReporteAhorrosAplicados
    Dim Sql As String
    Dim sqlcmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Rpt As New CooperativaAhorrosDescontadosBuxis
    Dim RptExcel As New CooperativaAhorrosDescontadosBuxisExportarExcel

    Private Sub CooperativaReporteAhorrosAplicados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        TextObj = Rpt.Section2.ReportObjects.Item("TextEmpresa")
        TextObj.Text = Descripcion_Compañia
        Me.WindowState = FormWindowState.Maximized
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargaEmpresas()
    End Sub

    Private Sub CooperativaReporteAhorrosAplicados_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub CargaEmpresas()
        Sql = "SELECT 999 AS ORIGEN, 'TODAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN IN (" & Permitir & ")"
        'Sql = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbEmpresa.DataSource = Table
        Me.cmbEmpresa.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbEmpresa.ValueMember = "ORIGEN"
        Me.cmbEmpresa.SelectedIndex = 0
        Me.cmbEmpresa.SelectedValue = 999
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Sql = "SELECT A.CODIGO_EMPLEADO AS [CODIGO BUXIS], " & vbCrLf
        Sql &= "      A.CODIGO_EMPLEADO_AS AS [CODIGO AS], " & vbCrLf
        Sql &= "      S.NOMBRE_COMPLETO AS NOMBRE, " & vbCrLf
        Sql &= "      A.Valor_Ordinario AS [CUOTA ORDINARIO], " & vbCrLf
        Sql &= "      ISNULL(A.Valor_ExtraOrdinario, 0) AS [CUOTA EXTRAORDINARIO], " & vbCrLf
        Sql &= "      A.Fondo_Defuncion AS [FONDO DEFUNCION]," & vbCrLf
        Sql &= "      S.DESCRIPCION_DIVISION," & vbCrLf
        Sql &= "      S.DESCRIPCION_DEPARTAMENTO," & vbCrLf
        Sql &= "      S.DESCRIPCION_SECCION," & vbCrLf
        Sql &= "      S.DESCRIPCION_CARGO, CONVERT(VARCHAR,A.FECHA_DESCUENTO,103) AS FECHA_PAGO" & vbCrLf
        Sql &= " FROM PLANILLA_AHORROS_APLICADOS A, VISTA_COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
        Sql &= "WHERE A.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO" & vbCrLf
        Sql &= "  AND S.COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "  AND A.FECHA_DESCUENTO = '" & Format(Me.DateTimePicker1.Value, "dd/MM/yyyy") & "'" & vbCrLf
        If Me.cmbEmpresa.SelectedValue < 999 Then
            Sql &= "   AND S.ORIGEN = " & Me.cmbEmpresa.SelectedValue
        Else
            Sql &= "   AND S.ORIGEN IN (" & Permitir & ")"
        End If
        sqlcmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlcmd)
        Rpt.SetDataSource(Table)
        RptExcel.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim filename As String = ""
        With OpenFD
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .FileName = "Libro de Excel"
            .Filter = "Libro de Excel 97-2003|*.xls"
        End With
        If OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = OpenFD.FileName
            RptExcel.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, filename)
        End If
    End Sub
End Class