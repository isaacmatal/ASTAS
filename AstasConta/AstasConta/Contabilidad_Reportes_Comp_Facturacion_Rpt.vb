Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Comp_Facturacion_Rpt

    Private Sub Contabilidad_Reportes_Comp_Facturacion_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim Rpt As New Contabilidad_Reportes_Comp_Facturacion
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim jClass As New jarsClass
        Dim table As DataTable
        Dim sqlCmd As New SqlCommand
        Try
            sqlCmd.CommandText = GeneraSQL()
            table = jClass.obtenerDatos(sqlCmd)
            If table.Rows.Count > 0 Then
                Rpt.SetDataSource(table)
                txtObj = Rpt.Section2.ReportObjects.Item("txtEmpresa")
                txtObj.Text = Descripcion_Compañia
                txtObj = Rpt.Section2.ReportObjects.Item("txtPeriodo")
                txtObj.Text = Me.dpFECHA_CONTABLE.Text.ToUpper()
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
                Me.crvReporte.ReportSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Function GeneraSQL() As String
        Dim sqlRep As String
        Dim TipoSoli As String = String.Empty

        If Me.chkDesp.Checked Then
            TipoSoli &= IIf(TipoSoli.Length = 0, "15", ",15")
        End If
        If Me.chkAlm.Checked Then
            TipoSoli &= IIf(TipoSoli.Length = 0, "14", ",14")
        End If
        If Me.chkCafe1.Checked Then
            TipoSoli &= IIf(TipoSoli.Length = 0, "19,20", ",19,20")
        End If
        If Me.chkCafe2.Checked Then
            TipoSoli &= IIf(TipoSoli.Length = 0, "20", ",20")
        End If
        If TipoSoli.Length = 0 Then
            MsgBox("Debe seleccionar al menos un rubro para comparar", MsgBoxStyle.Information, "Proceso Cancelado")
            sqlRep = "SELECT " & Compañia & " AS COMPAÑIA, 0 AS SOLICITUD, 0 AS COD_DETALLE, '' AS NOMBRE_COMPLETO, CONVERT(NUMERIC(18,2),0) AS CARGOS, CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, CONVERT(NUMERIC(18,2),0) AS [DIF CARGOS], CONVERT(NUMERIC(18,2),0) AS ABONOS, CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, CONVERT(NUMERIC(18,2),0) AS [DIF ABONOS], '0' AS CUENTA_COMPLETA, '' AS DESCRIPCION_CUENTA FROM CATALOGO_ALMACEN_DESPENSA"
            Return sqlRep
        End If
        sqlRep = "--ABONOS Y CARGOS CONTABLES" & vbCrLf
        sqlRep &= "SELECT D.COMPAÑIA, MAX(C.SOLICITUD) AS SOLICITUD, D.COD_DETALLE, SUM(D.CARGOS) CARGOS, CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, SUM(D.ABONOS) ABONOS, CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, " & vbCrLf
        sqlRep &= "	   C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, CONVERT(BIT, 0) AS INSERTADO, MAX(C.ORIGEN) AS ORIGEN" & vbCrLf
        sqlRep &= "INTO #CARGOSABONOS" & vbCrLf
        sqlRep &= "  FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO D, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
        sqlRep &= " WHERE D.COMPAÑIA = C.COMPAÑIA" & vbCrLf
        sqlRep &= "   AND D.COMPAÑIA = " & Compañia & vbCrLf
        sqlRep &= "   AND D.CUENTA_CONTABLE = C.CUENTA " & vbCrLf
        sqlRep &= "   AND C.LIBRO_CONTABLE = 1" & vbCrLf
        sqlRep &= "   AND C.SOLICITUD IN ( " & TipoSoli & " )" & vbCrLf
        sqlRep &= "   AND C.CUENTA_MAYOR = 0" & vbCrLf
        sqlRep &= "   AND D.COD_DETALLE BETWEEN 0 AND 999999999" & vbCrLf
        sqlRep &= "   AND CONVERT(DATE, D.FECHA_TRAN) BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
        sqlRep &= "GROUP BY D.COMPAÑIA, D.CUENTA_CONTABLE, D.COD_DETALLE, C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, C.TIPO_CUENTA" & vbCrLf
        If Me.chkAlm.Checked Then
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION ALMACEN" & vbCrLf
            sqlRep &= "SELECT E.COMPAÑIA, B.TIPO_SOLICITUD AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.TOTAL_FACTURA) AS TOTAL, CASE WHEN MAX(E.ORIGEN) = 6 THEN 2 ELSE MAX(E.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "INTO #FACTALM" & vbCrLf
            sqlRep &= "  FROM FACTURACION_GENERADA_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.TOTAL_FACTURA > 0" & vbCrLf
            sqlRep &= "   AND E.ANULADA = 0" & vbCrLf
            sqlRep &= "   AND E.FORMA_PAGO = 2" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD = 14" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA,B.TIPO_SOLICITUD,E.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION ALMACEN DEVOLUCIONES" & vbCrLf
            sqlRep &= "SELECT E.COMPAÑIA, MAX(B.TIPO_SOLICITUD) AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.TOTAL_FACTURA) AS TOTAL, CASE WHEN MAX(E.ORIGEN) = 6 THEN 2 ELSE MAX(E.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "INTO #FACTALMDEV" & vbCrLf
            sqlRep &= "  FROM FACTURACION_GENERADA_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.TOTAL_FACTURA < 0" & vbCrLf
            sqlRep &= "   AND E.ANULADA = 0" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD = 14" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA,E.BODEGA,E.CODIGO_EMPLEADO, E.NOMBRE_FACTURA" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "--ANULACIONES POR CONSOLIDACION ALMACEN CUANDO SE PASA SALDO A PRESTAMO" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, S.SOLICITUD, S.CODIGO_BUXIS, SUM(D.CAPITAL) AS TOTAL, CASE WHEN MAX(SOC.ORIGEN) = 6 THEN 2 ELSE MAX(SOC.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "  INTO #ANULADASALM" & vbCrLf
            sqlRep &= "  FROM COOPERATIVA_SOLICITUDES_AUTORIZACION A, COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS D, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
            sqlRep &= " WHERE A.COMPAÑIA = S.COMPAÑIA AND A.N_SOLICITUD = S.CORRELATIVO" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = D.COMPAÑIA AND A.N_SOLICITUD = D.NUMERO_SOLICITUD" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = SOC.COMPAÑIA AND A.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= "   AND A.CONSOLIDACION_PRESTAMO = 1" & vbCrLf
            sqlRep &= "   AND S.SOLICITUD = 14" & vbCrLf
            sqlRep &= "   AND A.FECHA_ANULADA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= " GROUP BY A.COMPAÑIA, S.SOLICITUD, S.CODIGO_BUXIS" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET CONSUMO_COOP = F.TOTAL" & vbCrLf
            sqlRep &= "FROM #FACTALM F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET PAGOS_COOP = (F.TOTAL * -1)" & vbCrLf
            sqlRep &= "FROM #FACTALMDEV F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET PAGOS_COOP = (PAGOS_COOP + F.TOTAL)" & vbCrLf
            sqlRep &= "FROM #ANULADASALM F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_BUXIS = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       A.TOTAL AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #FACTALM F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "		WHERE C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "  WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	    A.TOTAL AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #FACTALMDEV F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "		WHERE C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "  WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_BUXIS, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   A.TOTAL AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_BUXIS, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #ANULADASALM F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_BUXIS = C.COD_DETALLE" & vbCrLf
            sqlRep &= "		WHERE C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "  WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "DROP TABLE #FACTALM" & vbCrLf
            sqlRep &= "DROP TABLE #FACTALMDEV" & vbCrLf
            sqlRep &= "DROP TABLE #ANULADASALM" & vbCrLf
        End If
        If Me.chkDesp.Checked Then
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION DESPENSA" & vbCrLf
            sqlRep &= "SELECT E.COMPAÑIA, B.TIPO_SOLICITUD AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.TOTAL_FACTURA) AS TOTAL, CASE WHEN MAX(E.ORIGEN) = 6 THEN 2 ELSE MAX(E.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "INTO #FACTDESP" & vbCrLf
            sqlRep &= "  FROM FACTURACION_GENERADA_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.TOTAL_FACTURA > 0" & vbCrLf
            sqlRep &= "   AND E.ANULADA = 0" & vbCrLf
            sqlRep &= "   AND E.FORMA_PAGO = 2" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD = 15" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA,B.TIPO_SOLICITUD,E.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION DESPENSA DEVOLUCIONES" & vbCrLf
            sqlRep &= "SELECT E.COMPAÑIA, MAX(B.TIPO_SOLICITUD) AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.TOTAL_FACTURA) AS TOTAL, CASE WHEN MAX(E.ORIGEN) = 6 THEN 2 ELSE MAX(E.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "INTO #FACTDESPDEV" & vbCrLf
            sqlRep &= "  FROM FACTURACION_GENERADA_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.TOTAL_FACTURA < 0" & vbCrLf
            sqlRep &= "   and E.ANULADA = 0" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD = 15" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA,E.BODEGA,E.CODIGO_EMPLEADO, E.NOMBRE_FACTURA" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "--ANULACIONES POR CONSOLIDACION DESPENSA CUANDO SE PASA SALDO A PRESTAMO" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, S.SOLICITUD, S.CODIGO_BUXIS, SUM(D.CAPITAL) AS TOTAL, CASE WHEN MAX(SOC.ORIGEN) = 6 THEN 2 ELSE MAX(SOC.ORIGEN) END AS ORIGEN " & vbCrLf
            sqlRep &= "  INTO #ANULADASDESP" & vbCrLf
            sqlRep &= "  FROM COOPERATIVA_SOLICITUDES_AUTORIZACION A, COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS D, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
            sqlRep &= " WHERE A.COMPAÑIA = S.COMPAÑIA AND A.N_SOLICITUD = S.CORRELATIVO" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = D.COMPAÑIA AND A.N_SOLICITUD = D.NUMERO_SOLICITUD" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = SOC.COMPAÑIA AND A.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "   AND A.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= "   AND A.CONSOLIDACION_PRESTAMO = 1" & vbCrLf
            sqlRep &= "   AND S.SOLICITUD = 15" & vbCrLf
            sqlRep &= "   AND A.FECHA_ANULADA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= " GROUP BY A.COMPAÑIA, S.SOLICITUD, S.CODIGO_BUXIS" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET CONSUMO_COOP = F.TOTAL" & vbCrLf
            sqlRep &= "FROM #FACTDESP F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET PAGOS_COOP = (F.TOTAL * -1)" & vbCrLf
            sqlRep &= "FROM #FACTDESPDEV F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET PAGOS_COOP = (PAGOS_COOP + F.TOTAL)" & vbCrLf
            sqlRep &= "FROM #ANULADASDESP F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_BUXIS = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       A.TOTAL AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #FACTDESP F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            sqlRep &= "		WHERE F.COMPAÑIA = S.COMPAÑIA AND F.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "		  AND C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "		WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   A.TOTAL AS PAGOS_COOP," & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #FACTDESPDEV F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            sqlRep &= "		WHERE F.COMPAÑIA = S.COMPAÑIA AND F.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "		  AND C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "		WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_BUXIS, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   A.TOTAL AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA,  CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_BUXIS, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #ANULADASDESP F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_BUXIS = C.COD_DETALLE, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            sqlRep &= "		WHERE F.COMPAÑIA = S.COMPAÑIA AND F.CODIGO_BUXIS = S.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "		  AND C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "		WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "DROP TABLE #FACTDESP" & vbCrLf
            sqlRep &= "DROP TABLE #FACTDESPDEV" & vbCrLf
            sqlRep &= "DROP TABLE #ANULADASDESP" & vbCrLf
        End If
        If Me.chkCafe1.Checked Then
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION CAFETERIAS PLANTA 1" & vbCrLf
            sqlRep &= " SELECT E.COMPAÑIA, 19 AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.MONTO) AS TOTAL, E.ORIGEN" & vbCrLf
            sqlRep &= "INTO #FACTCAFE1" & vbCrLf
            sqlRep &= "  FROM CAFETERIA_FACTURACION_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.MONTO > 0" & vbCrLf
            sqlRep &= "   AND E.ANULADO = 0" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD IN (19, 20)" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA, E.CODIGO_EMPLEADO, E.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET CONSUMO_COOP = F.TOTAL" & vbCrLf
            sqlRep &= "FROM #FACTCAFE1 F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS," & vbCrLf
            sqlRep &= "       A.TOTAL AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, S.ORIGEN " & vbCrLf
            sqlRep &= "		FROM #FACTCAFE1 F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
            sqlRep &= "		WHERE F.COMPAÑIA = S.COMPAÑIA AND F.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "		  AND C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "		WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "DROP TABLE #FACTCAFE1" & vbCrLf
        End If
        If Me.chkCafe2.Checked Then
            sqlRep &= "" & vbCrLf
            sqlRep &= "--CARGOS DE FACTURACION CAFETERIAS PLANTA 2" & vbCrLf
            sqlRep &= " SELECT E.COMPAÑIA, MAX(B.TIPO_SOLICITUD) AS SOLICITUD, E.CODIGO_EMPLEADO, SUM(E.MONTO) AS TOTAL, CASE WHEN MAX(E.ORIGEN) = 6 THEN 2 ELSE MAX(E.ORIGEN) END AS ORIGEN" & vbCrLf
            sqlRep &= "INTO #FACTCAFE2" & vbCrLf
            sqlRep &= "  FROM CAFETERIA_FACTURACION_ENCABEZADO E, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            sqlRep &= " WHERE E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA = B.BODEGA" & vbCrLf
            sqlRep &= "   AND E.FECHA_FACTURA BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
            sqlRep &= "   AND E.CODIGO_EMPLEADO > 0" & vbCrLf
            sqlRep &= "   AND E.MONTO > 0" & vbCrLf
            sqlRep &= "   AND E.ANULADO = 0" & vbCrLf
            sqlRep &= "   AND B.TIPO_SOLICITUD = 20" & vbCrLf
            sqlRep &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            sqlRep &= " GROUP BY E.COMPAÑIA,E.CODIGO_EMPLEADO" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
            sqlRep &= "   SET CONSUMO_COOP = F.TOTAL" & vbCrLf
            sqlRep &= "FROM #FACTCAFE2 F, #CARGOSABONOS C" & vbCrLf
            sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
            sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
            sqlRep &= "  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
            sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_EMPLEADO, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
            sqlRep &= "       A.TOTAL AS CONSUMO_COOP, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
            sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS PAGOS_COOP, " & vbCrLf
            sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
            sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_EMPLEADO, F.TOTAL, F.ORIGEN" & vbCrLf
            sqlRep &= "		FROM #FACTCAFE2 F LEFT JOIN #CARGOSABONOS C" & vbCrLf
            sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
            sqlRep &= "		  AND F.CODIGO_EMPLEADO = C.COD_DETALLE" & vbCrLf
            sqlRep &= "		WHERE C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
            sqlRep &= "  WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
            sqlRep &= "" & vbCrLf
            sqlRep &= "DROP TABLE #FACTCAFE2" & vbCrLf
        End If
        sqlRep &= "" & vbCrLf
        sqlRep &= " --ABONOS DE PROGRAMACIONES" & vbCrLf
        sqlRep &= " SELECT COMPAÑIA, SOLICITUD, CODIGO_BUXIS, SUM(PAGADO) AS PAGADO, ORIGEN " & vbCrLf
        sqlRep &= " INTO #COOPPAGOS FROM" & vbCrLf
        sqlRep &= " (SELECT S.COMPAÑIA, CASE S.SOLICITUD WHEN 20 THEN 19 ELSE S.SOLICITUD END AS SOLICITUD, S.CODIGO_BUXIS, SUM(D.CAPITAL) AS PAGADO," & vbCrLf
        sqlRep &= "		CASE WHEN MAX(SOC.ORIGEN) = 6 AND (S.SOLICITUD = 14 OR S.SOLICITUD = 15) THEN 2 ELSE MAX(SOC.ORIGEN) END AS ORIGEN" & vbCrLf
        sqlRep &= " FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
        sqlRep &= "  WHERE D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
        sqlRep &= "    AND S.COMPAÑIA = SOC.COMPAÑIA AND S.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
        sqlRep &= "    AND D.COMPAÑIA = " & Compañia & vbCrLf
        sqlRep &= "    AND D.FECHA_PAGO BETWEEN CONVERT(DATE, '01/" & Format(Me.dpFECHA_CONTABLE.Value, "MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
        sqlRep &= "	AND S.SOLICITUD IN (" & TipoSoli & ")" & vbCrLf
        sqlRep &= "	AND S.CODIGO_BUXIS > 0" & vbCrLf
        sqlRep &= "	AND D.CAPITAL_D = 1" & vbCrLf
        sqlRep &= "GROUP BY S.COMPAÑIA, S.SOLICITUD, S.CODIGO_BUXIS) A" & vbCrLf
        sqlRep &= "GROUP BY COMPAÑIA, SOLICITUD, CODIGO_BUXIS, ORIGEN" & vbCrLf
        'If Me.chkCafe1.Checked Then

        'End If
        sqlRep &= "" & vbCrLf
        sqlRep &= "UPDATE #CARGOSABONOS" & vbCrLf
        sqlRep &= "   SET PAGOS_COOP = (PAGOS_COOP + F.PAGADO)" & vbCrLf
        sqlRep &= "FROM #COOPPAGOS F, #CARGOSABONOS C" & vbCrLf
        sqlRep &= "WHERE F.COMPAÑIA = C.COMPAÑIA" & vbCrLf
        sqlRep &= "  AND F.SOLICITUD  = C.SOLICITUD" & vbCrLf
        sqlRep &= "  AND F.CODIGO_BUXIS = C.COD_DETALLE" & vbCrLf
        sqlRep &= "  AND F.ORIGEN = C.ORIGEN" & vbCrLf
        sqlRep &= "" & vbCrLf
        sqlRep &= "INSERT INTO #CARGOSABONOS" & vbCrLf
        sqlRep &= "SELECT A.COMPAÑIA, A.SOLICITUD, A.CODIGO_BUXIS, CONVERT(NUMERIC(18,2),0) AS CARGOS, " & vbCrLf
        sqlRep &= "       CONVERT(NUMERIC(18,2),0) AS CONSUMO_COOP, " & vbCrLf
        sqlRep &= "	   CONVERT(NUMERIC(18,2),0) AS ABONOS, " & vbCrLf
        sqlRep &= "	   A.PAGADO AS PAGOS_COOP, " & vbCrLf
        sqlRep &= "	   CTAS.CUENTA_COMPLETA, CTAS.DESCRIPCION_CUENTA, CONVERT(BIT, 1) AS INSERTADO, A.ORIGEN" & vbCrLf
        sqlRep &= "  FROM (SELECT F.COMPAÑIA, F.SOLICITUD, F.CODIGO_BUXIS, F.PAGADO, F.ORIGEN" & vbCrLf
        sqlRep &= "		FROM #COOPPAGOS F LEFT JOIN #CARGOSABONOS C" & vbCrLf
        sqlRep &= "		ON F.COMPAÑIA = C.COMPAÑIA AND F.SOLICITUD = C.SOLICITUD" & vbCrLf
        sqlRep &= "		  AND F.CODIGO_BUXIS = C.COD_DETALLE" & vbCrLf
        sqlRep &= "		WHERE C.COD_DETALLE IS NULL) A, CONTABILIDAD_CATALOGO_CUENTAS CTAS" & vbCrLf
        sqlRep &= "  WHERE A.COMPAÑIA = CTAS.COMPAÑIA AND A.SOLICITUD = CTAS.SOLICITUD AND A.ORIGEN = CTAS.ORIGEN" & vbCrLf
        sqlRep &= "" & vbCrLf
        sqlRep &= "SELECT CA.COMPAÑIA, CA.SOLICITUD, CA.COD_DETALLE, S.NOMBRE_COMPLETO, CA.CARGOS, CA.CONSUMO_COOP, CA.CARGOS - CA.CONSUMO_COOP AS [DIF CARGOS], CA.ABONOS, CA.PAGOS_COOP, CA.ABONOS - CA.PAGOS_COOP AS [DIF ABONOS], CA.CUENTA_COMPLETA, CA.DESCRIPCION_CUENTA, CA.INSERTADO" & vbCrLf
        sqlRep &= "  FROM #CARGOSABONOS CA, COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
        sqlRep &= " WHERE CA.COMPAÑIA = S.COMPAÑIA AND CA.COD_DETALLE = S.CODIGO_EMPLEADO" & vbCrLf
        If Me.chkDif.Checked Then
            sqlRep &= "   AND (CA.CARGOS - CA.CONSUMO_COOP <> 0 OR CA.ABONOS - CA.PAGOS_COOP <> 0)" & vbCrLf
        End If
        sqlRep &= "ORDER BY CA.CUENTA_COMPLETA, CA.COD_DETALLE" & vbCrLf
        sqlRep &= "" & vbCrLf
        sqlRep &= "DROP TABLE #CARGOSABONOS" & vbCrLf
        sqlRep &= "DROP TABLE #COOPPAGOS" & vbCrLf
        Return sqlRep
    End Function

    Private Sub Contabilidad_Reportes_Comp_Facturacion_Rpt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class