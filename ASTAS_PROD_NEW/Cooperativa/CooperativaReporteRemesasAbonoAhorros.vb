Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaReporteRemesasAbonoAhorros

    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Inicio As Boolean = True

    Private Sub CooperativaReporteRemesasAbonoAhorros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim Reporte As New Cooperativa_Remesas_Ahorro_Extra
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        sql = "SELECT A.FECHA_ABONO, S.CODIGO_EMPLEADO AS [CODIGO BUXIS], S.CODIGO_EMPLEADO_AS AS [CODIGO AS]," & vbCrLf
        sql &= " S.NOMBRE_COMPLETO, A.CANTIDAD_ABONADA, B.DESCRIPCION_BANCO, A.NUM_REMESA" & vbCrLf
        sql &= " FROM COOPERATIVA_SOLICITUDES_ABONOS A, CONTABILIDAD_CATALOGO_BANCOS B, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
        sql &= " WHERE A.CODIGO_BUXIS = S.CODIGO_EMPLEADO AND A.CODIGO_AS = S.CODIGO_EMPLEADO_AS AND A.BANCO_REMESA = B.BANCO" & vbCrLf
        sql &= " AND A.SOLICITUD = 0 AND CONVERT(DATE,A.FECHA_ABONO) BETWEEN CONVERT(DATETIME,'" & Format(Me.dpFechaDesde.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATETIME,'" & Format(Me.dpFechaHasta.Value, "dd/MM/yyyy") & "',103) " & vbCrLf
        sql &= " AND S.ORIGEN IN (" & Permitir & ")" & vbCrLf
        sql &= " ORDER BY A.FECHA_ABONO"
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            txtObj = Reporte.Section1.ReportObjects.Item("TextEmpresa")
            txtObj.Text = Descripcion_Compañia
            txtObj = Reporte.Section1.ReportObjects.Item("TextPeriodo")
            txtObj.Text = "DESDE: " & Format(Me.dpFechaDesde.Value, "dd/MM/yyyy") & "     HASTA: " & Format(Me.dpFechaHasta.Value, "dd/MM/yyyy")
            Reporte.SetDataSource(Table)
            Me.crvRepRemesas.ReportSource = Reporte
        Else
            MsgBox("No hay datos para los paramétros especificados", MsgBoxStyle.Information, "Reporte")
            Me.crvRepRemesas.ReportSource = Nothing
        End If
    End Sub
End Class