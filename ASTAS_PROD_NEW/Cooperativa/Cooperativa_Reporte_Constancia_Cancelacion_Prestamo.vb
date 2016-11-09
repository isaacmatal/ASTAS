Imports System.Data
Imports System.Data.SqlClient
Public Class Cooperativa_Reporte_Constancia_Cancelacion_Prestamo
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sql As String
    Dim Periodo As String = "QQ"
    Dim sqlCmd As New SqlCommand
    Dim rpt As New CooperativaReporteDescuentosAplicadosBuxis

    Dim Iniciando As Boolean
    Private Sub Cooperativa_Reporte_Constancia_Cancelacion_Prestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        Iniciando = False
    End Sub
    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        sql = " SELECT S.DEDUCCION, DD.DESCRIPCION_SOLICITUD, D.NUMERO_SOLICITUD, S.CODIGO_BUXIS, S.CODIGO_AS, C.NOMBRE_COMPLETO, D.CAPITAL, D.LINEA" & vbCrLf
        sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOCIOS C, COOPERATIVA_CATALOGO_SOLICITUDES DD, COOPERATIVA_CATALOGO_DEDUCCIONES DED" & vbCrLf
        sql &= " WHERE D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
        sql &= "  AND S.COMPAÑIA = C.COMPAÑIA AND S.CODIGO_BUXIS = C.CODIGO_EMPLEADO AND S.CODIGO_AS = C.CODIGO_EMPLEADO_AS" & vbCrLf
        sql &= "  AND S.COMPAÑIA = DD.COMPAÑIA AND S.SOLICITUD = DD.SOLICITUD" & vbCrLf
        sql &= "  AND S.COMPAÑIA = DED.COMPAÑIA AND S.DEDUCCION = DED.DEDUCCION" & vbCrLf
        sql &= "  AND D.FECHA_PAGO = '" & Format(Me.dtpFechaPago.Value, "dd/MM/yyyy") & "' AND D.CAPITAL_D = 1 AND D.CAPITAL > 0" & vbCrLf
        sql &= "  AND D.USUARIO_EDICION = 'buxis'" & vbCrLf
        sql &= "  AND C.PERIODO_PAGO = '" & Periodo & "'" & vbCrLf
        sql &= "UNION ALL" & vbCrLf
        sql &= "SELECT DD.CODIGO_DEDUCCION_INTERESES,DED.DESCRIPCION_DEDUCCION, D.NUMERO_SOLICITUD, S.CODIGO_BUXIS, S.CODIGO_AS, C.NOMBRE_COMPLETO, D.INTERES, D.LINEA" & vbCrLf
        sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOCIOS C, COOPERATIVA_CATALOGO_SOLICITUDES DD, COOPERATIVA_CATALOGO_DEDUCCIONES DED" & vbCrLf
        sql &= " WHERE D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
        sql &= "   AND S.COMPAÑIA = C.COMPAÑIA AND S.CODIGO_BUXIS = C.CODIGO_EMPLEADO AND S.CODIGO_AS = C.CODIGO_EMPLEADO_AS" & vbCrLf
        sql &= "   AND S.COMPAÑIA = DD.COMPAÑIA AND S.SOLICITUD = DD.SOLICITUD" & vbCrLf
        sql &= "   AND DD.COMPAÑIA = DED.COMPAÑIA AND DD.CODIGO_DEDUCCION_INTERESES = DED.DEDUCCION" & vbCrLf
        sql &= "   AND D.FECHA_PAGO = '" & Format(Me.dtpFechaPago.Value, "dd/MM/yyyy") & "' AND D.INTERES_D = 1 AND D.INTERES > 0" & vbCrLf
        sql &= "   AND D.USUARIO_EDICION = 'buxis'" & vbCrLf
        sql &= "   AND C.PERIODO_PAGO = '" & Periodo & "'" & vbCrLf
        sql &= "UNION ALL" & vbCrLf
        sql &= "SELECT DD.CODIGO_DEDUCCION_SEGURO_DEUDA,DED.DESCRIPCION_DEDUCCION, D.NUMERO_SOLICITUD, S.CODIGO_BUXIS, S.CODIGO_AS, C.NOMBRE_COMPLETO, D.SEG_DEUDA, D.LINEA" & vbCrLf
        sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOCIOS C, COOPERATIVA_CATALOGO_SOLICITUDES DD, COOPERATIVA_CATALOGO_DEDUCCIONES DED" & vbCrLf
        sql &= " WHERE D.COMPAÑIA = S.COMPAÑIA And D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
        sql &= "  AND S.COMPAÑIA = C.COMPAÑIA AND S.CODIGO_BUXIS = C.CODIGO_EMPLEADO AND S.CODIGO_AS = C.CODIGO_EMPLEADO_AS" & vbCrLf
        sql &= "  AND S.COMPAÑIA = DD.COMPAÑIA AND S.SOLICITUD = DD.SOLICITUD" & vbCrLf
        sql &= "  AND DD.COMPAÑIA = DED.COMPAÑIA AND DD.CODIGO_DEDUCCION_SEGURO_DEUDA = DED.DEDUCCION" & vbCrLf
        sql &= "  AND D.FECHA_PAGO = '" & Format(Me.dtpFechaPago.Value, "dd/MM/yyyy") & "' AND D.SEG_DEUDA_D = 1 AND D.SEG_DEUDA > 0" & vbCrLf
        sql &= "  AND D.USUARIO_EDICION = 'buxis'" & vbCrLf
        sql &= "  AND C.PERIODO_PAGO = '" & Periodo & "'"
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt.Section1.ReportObjects.Item("TextPeriodo")
        txtObj.Text = "PERIODO DE PAGO: " & Format(Me.dtpFechaPago.Value, "dd/MM/yyyy")
        rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub rbQna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna.CheckedChanged
        If rbQna.Checked Then
            Periodo = "QQ"
        End If
    End Sub

    Private Sub rbMes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMes.CheckedChanged
        If rbMes.Checked Then
            Periodo = "MM"
        End If
    End Sub
End Class