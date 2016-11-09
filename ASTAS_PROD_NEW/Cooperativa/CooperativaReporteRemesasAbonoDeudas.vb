Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaReporteRemesasAbonoDeudas

    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Inicio As Boolean = True

    Private Sub CooperativaReporteRemesasAbonoDeudas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim Reporte As New Cooperativa_Remesas_Abono_Deudas
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        sql = "SELECT CASE A.ABONO_REMESA WHEN 1 THEN 'REMESA BANCARIA' ELSE 'AHORRO EXTRAORDINARIO' END AS TIPO_ABONO, A.SOLICITUD, TS.DESCRIPCION_SOLICITUD, CONVERT(DATETIME,CONVERT(DATE,A.FECHA_ABONO)) AS FECHA_ABONO, S.CODIGO_EMPLEADO AS [CODIGO BUXIS], S.CODIGO_EMPLEADO_AS AS [CODIGO AS]," & vbCrLf
        sql &= " s.NOMBRE_COMPLETO, A.CANTIDAD_ABONADA, A.ABONO_CAPITAL, A.ABONO_INTERES, A.ABONO_SEG_DEUDA, A.NUM_REMESA, B.DESCRIPCION_BANCO, A.BANCO_REMESA" & vbCrLf
        sql &= " FROM COOPERATIVA_SOLICITUDES_ABONOS A, CONTABILIDAD_CATALOGO_BANCOS B, " & vbCrLf
        sql &= " COOPERATIVA_CATALOGO_SOCIOS S, COOPERATIVA_SOLICITUDES CS, COOPERATIVA_CATALOGO_SOLICITUDES TS" & vbCrLf
        sql &= " WHERE A.CODIGO_BUXIS = S.CODIGO_EMPLEADO" & vbCrLf
        sql &= " AND A.CODIGO_AS = S.CODIGO_EMPLEADO_AS " & vbCrLf
        sql &= " AND A.COMPAÑIA = B.COMPAÑIA " & vbCrLf
        sql &= " AND A.BANCO_REMESA = B.BANCO " & vbCrLf
        sql &= " AND A.COMPAÑIA = CS.COMPAÑIA " & vbCrLf
        sql &= " AND A.SOLICITUD = CS.CORRELATIVO" & vbCrLf
        sql &= " AND CS.SOLICITUD = TS.SOLICITUD" & vbCrLf
        sql &= " AND A.SOLICITUD > 0 AND CONVERT(DATE,A.FECHA_ABONO) BETWEEN CONVERT(DATETIME,'" & Format(Me.dpFechaDesde.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATETIME,'" & Format(Me.dpFechaHasta.Value, "dd/MM/yyyy") & "',103) " & vbCrLf
        sql &= " AND S.ORIGEN IN (" & Permitir & ")"
        sql &= "ORDER BY A.FECHA_ABONO"
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