Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_Reporte_Comparativo_Saldos_Cooperativa
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Solic As String = String.Empty
    Dim Orig As String = String.Empty
    Dim Table As DataTable

    Private Sub Contabilidad_Reporte_Comparativo_Saldos_Cooperativa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaOrigen()
        CargaTiposoli()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim MesAnt As Integer = Me.dtpFechaContable.Value.AddMonths(-1).Month
        Dim YearAnt As Integer = Me.dtpFechaContable.Value.AddMonths(-1).Year
        Dim Empresa As Integer
        Solic = ""
        Orig = ""
        Dim Libro As Integer = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        For i As Integer = 0 To Me.dgvEmpresas.Rows.Count - 1
            If Me.dgvEmpresas.Rows(i).Cells(0).Value Then
                Orig &= IIf(Orig.Length = 0, "", ",") & Me.dgvEmpresas.Rows(i).Cells(1).Value
            End If
        Next
        If Orig.Length = 0 Then
            MsgBox("Debe elegir al menos una Empresa", MsgBoxStyle.Information, "Proceso cancelado")
            Return
        End If

        If Me.rbDeudas.Checked Then
            For i As Integer = 0 To Me.dgvTipoSol.Rows.Count - 1
                If Me.dgvTipoSol.Rows(i).Cells(0).Value Then
                    Solic &= IIf(Solic.Length = 0, "", ",") & Me.dgvTipoSol.Rows(i).Cells(1).Value
                End If
            Next
            If Solic.Length = 0 Then
                MsgBox("Debe elegir al menos un Tipo de Solicitud", MsgBoxStyle.Information, "Proceso cancelado")
                Return
            End If
            If Me.chkRptGuardado.Checked Then
                sql = "SELECT [CUENTA_COMPLETA] ,[DETALLE] ,[DESCRIPCION_CUENTA] ,[DESCRIPCION_DETALLE] AS [DESCRIPCION DETALLE],[SALDO_CONTABLE] ,[CODIGO_BUXIS] ,[NOMBRE] ,[SALDO] ,[DIF] ,[SOLICITUD] ,[DESCRIPCION_SOLICITUD] FROM CONTABILIDAD_COMPARATIVO_DEUDAS_COOPERATIVA WHERE COMPAÑIA = " & Compañia & " AND FECHA_CONTABLE = '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "' AND SOLICITUD IN (" & Solic & ") AND ORIGEN IN (" & Orig & ")" & vbCrLf
            Else
                sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
                sql &= "SELECT C.COMPAÑIA, C.LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, C.CUENTA,C.CUENTA_COMPLETA, 0 AS DETALLE, 0 AS SALDO," & vbCrLf
                sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
                sql &= "FROM CONTABILIDAD_CATALOGO_CUENTAS C " & vbCrLf
                sql &= "   LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
                sql &= "   ON C.COMPAÑIA = D.COMPAÑIA" & vbCrLf
                sql &= "  AND C.LIBRO_CONTABLE = D.LIBRO_CONTABLE" & vbCrLf
                sql &= "  AND C.CUENTA_COMPLETA = D.CUENTA_COMPLETA" & vbCrLf
                sql &= "  AND D.MES = " & MesAnt & vbCrLf
                sql &= "  AND AÑO = " & YearAnt & vbCrLf
                sql &= "  AND D.LIBRO_CONTABLE = " & Libro & vbCrLf
                sql &= "WHERE C.LIBRO_CONTABLE = " & Libro & vbCrLf
                sql &= "  AND C.CUENTA_MAYOR = 0" & vbCrLf
                sql &= "  AND C.COMPAÑIA = " & Compañia & vbCrLf
                sql &= "  AND D.SALDO IS NULL" & vbCrLf
                sql &= "  AND C.CUENTA_COMPLETA IS NOT NULL"
                jClass.ejecutarComandoSql(New SqlCommand(sql))

                sql = "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
                sql &= "SELECT DISTINCT E.COMPAÑIA, " & Libro & " AS LIBRO_CONTABLE, " & YearAnt & " AS AÑO, " & MesAnt & " AS MES, E.CUENTA_CONTABLE AS CUENTA, " & vbCrLf
                sql &= "    (SELECT CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = E.COMPAÑIA AND CUENTA = E.CUENTA_CONTABLE AND LIBRO_CONTABLE = " & Libro & " AND COMPAÑIA = " & Compañia & " ) AS CUENTA_CAT," & vbCrLf
                sql &= "	E.COD_DETALLE, 0 AS SALDO," & vbCrLf
                sql &= "'" & Usuario & "' AS USUARIO_CREACION, GETDATE() AS USUARIO_CREACION_FECHA, '" & Usuario & "' AS USUARIO_EDICION, GETDATE() AS USUARIO_EDICION_FECHA" & vbCrLf
                sql &= "FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO E LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE D" & vbCrLf
                sql &= "   ON E.COMPAÑIA = D.COMPAÑIA " & vbCrLf
                sql &= "  AND E.CUENTA_CONTABLE = D.CUENTA " & vbCrLf
                sql &= "  AND D.MES = " & MesAnt & vbCrLf
                sql &= "  AND D.AÑO = " & YearAnt & vbCrLf
                sql &= "  AND E.COD_DETALLE = D.DETALLE" & vbCrLf
                sql &= "WHERE CONVERT(DATE, E.FECHA_TRAN) BETWEEN CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value.AddDays(-Me.dtpFechaContable.Value.Day).AddDays(1), "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
                sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
                sql &= "  AND D.CUENTA IS NULL"
                sql &= "  AND E.CUENTA_CONTABLE > 0"
                jClass.ejecutarComandoSql(New SqlCommand(sql))

                sql = "SELECT X.CUENTA_COMPLETA, ISNULL(SD.DETALLE,0) AS DETALLE, X.DESCRIPCION_CUENTA, COD.DESCRIPCION AS [DESCRIPCION DETALLE]," & vbCrLf
                sql &= "       ISNULL(SD.SALDO,0.00) AS SALDO_ANTERIOR," & vbCrLf
                sql &= "       ISNULL(A.CARGOS,0.00) AS CARGOS, ISNULL(A.ABONOS,0.00) AS ABONOS," & vbCrLf
                sql &= "       CASE WHEN A.TIPO_CUENTA = 1 OR A.TIPO_CUENTA = 4 THEN ISNULL(SD.SALDO,0.00) + ISNULL(A.CARGOS,0.00) - ISNULL(A.ABONOS,0.00) ELSE ISNULL(SD.SALDO,0.00) - ISNULL(A.CARGOS,0.00) + ISNULL(A.ABONOS,0.00) END AS SALDO, X.SOLICITUD " & vbCrLf
                '---- AGREGADO PARA INCUIR CODIGO DE ORIGEN EN LOS SALDOS DE COOPERATIVA
                sql &= "       , ISNULL(X.ORIGEN, 0) AS ORIGEN" & vbCrLf
                '---- FIN AGREGADO PARA INCUIR CODIGO DE ORIGEN EN LOS SALDOS CONTABLES
                sql &= "  INTO #TEMPORAL" & vbCrLf
                sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS X " & vbCrLf
                sql &= "       LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE SD ON X.COMPAÑIA = SD.COMPAÑIA AND X.CUENTA = SD.CUENTA AND X.LIBRO_CONTABLE = SD.LIBRO_CONTABLE AND SD.MES = " & MesAnt & " AND SD.AÑO = " & YearAnt & vbCrLf
                sql &= "       LEFT JOIN (SELECT D.COMPAÑIA, D.CUENTA_CONTABLE, D.COD_DETALLE, SUM(D.CARGOS) CARGOS, SUM(D.ABONOS) ABONOS, " & vbCrLf
                sql &= "	                     C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, C.TIPO_CUENTA, " & Libro & " AS LIBRO_CONTABLE, MAX(C.CATALOGO) AS CATALOGO" & vbCrLf
                sql &= "					FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO D, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
                sql &= "                   WHERE D.COMPAÑIA = C.COMPAÑIA" & vbCrLf
                sql &= "                     AND D.COMPAÑIA = " & Compañia & vbCrLf
                sql &= "					 AND D.CUENTA_CONTABLE = C.CUENTA " & vbCrLf
                sql &= "					 AND C.LIBRO_CONTABLE = " & Libro & vbCrLf
                sql &= "					 AND C.CUENTA_COMPLETA LIKE '110301%' " & vbCrLf
                sql &= "					 AND C.CUENTA_MAYOR = 0" & vbCrLf
                sql &= "					 AND D.COD_DETALLE BETWEEN 0 AND 2147483647" & vbCrLf
                sql &= "					 AND CONVERT(DATE, D.FECHA_TRAN) BETWEEN CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value.AddDays(-Me.dtpFechaContable.Value.Day).AddDays(1), "dd/MM/yyyy") & "',103) AND CONVERT(DATE, '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "',103)" & vbCrLf
                sql &= "				   GROUP BY D.COMPAÑIA, D.CUENTA_CONTABLE, D.COD_DETALLE, C.CUENTA_COMPLETA, C.DESCRIPCION_CUENTA, C.TIPO_CUENTA) A " & vbCrLf
                sql &= "		ON X.COMPAÑIA = A.COMPAÑIA AND X.LIBRO_CONTABLE = A.LIBRO_CONTABLE AND X.CUENTA = A.CUENTA_CONTABLE AND SD.DETALLE = A.COD_DETALLE" & vbCrLf
                sql &= "        LEFT JOIN CONTABILIDAD_CATALOGO_CODIGO_DETALLE COD ON X.COMPAÑIA = COD.COMPAÑIA AND X.CATALOGO = COD.TIPO AND SD.DETALLE = COD.CODIGO" & vbCrLf
                sql &= " WHERE X.LIBRO_CONTABLE = " & Libro & " AND X.CUENTA_MAYOR = 0 AND X.COMPAÑIA = " & Compañia & vbCrLf
                sql &= "   AND X.CUENTA_COMPLETA LIKE '110301%'" & vbCrLf
                '-------------------- AGREGADO -------------------------
                sql &= "   AND X.SOLICITUD IN (" & Solic & ")" & vbCrLf
                sql &= "   AND COD.ORIGEN IN (" & Orig & ")" & vbCrLf
                '------------------ FIN AGREGADO -----------------------
                sql &= " ORDER BY CUENTA_COMPLETA, DETALLE" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "CREATE TABLE #SALDOS(Compañia VARCHAR(250),FECHA DATETIME, DEDUCCION INT, TIPO VARCHAR(150), CODIGO_AS VARCHAR(6), CODIGO_BUXIS INT, NOMBRE VARCHAR(250), SALDO NUMERIC(10,2))" & vbCrLf
                sql &= "" & vbCrLf
                For i As Integer = 0 To Me.dgvEmpresas.Rows.Count - 1
                    If Me.dgvEmpresas.Rows(i).Cells(0).Value Then
                        Empresa = Me.dgvEmpresas.Rows(i).Cells(1).Value
                        For j As Integer = 0 To Me.dgvTipoSol.Rows.Count - 1
                            If Me.dgvTipoSol.Rows(j).Cells(0).Value Then
                                If Not "5,6".Contains(Empresa.ToString) Then
                                    sql &= "INSERT INTO #SALDOS EXECUTE [Coo].[sp_COOPERATIVA_REPORTE_CARTERA_SOCIOS_I] " & Compañia & ", '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', " & Me.dgvTipoSol.Rows(j).Cells(1).Value & ", " & Empresa & vbCrLf
                                Else
                                    If "01,04,14,15,19,20".Contains(Me.dgvTipoSol.Rows(j).Cells(1).Value.ToString.PadLeft(2, "0")) Then
                                        sql &= "INSERT INTO #SALDOS EXECUTE [Coo].[sp_COOPERATIVA_REPORTE_CARTERA_SOCIOS_I] " & Compañia & ", '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "', " & Me.dgvTipoSol.Rows(j).Cells(1).Value & ", " & Empresa & vbCrLf
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                '---- AGREGADO PARA CONSOLIDAR CONSUMO CAFETERIA P1 Y P2 POR CAMBIO DE CUENTAS CONTABLES
                sql &= "SELECT Compañia ,CONVERT(DATETIME,'" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "',103) AS FECHA , 234 AS DEDUCCION , 'CONSUMO CAFETERIA' AS TIPO , CODIGO_AS , CODIGO_BUXIS , NOMBRE, SUM(SALDO) AS SALDO" & vbCrLf
                sql &= "INTO #SALDOSCAF " & vbCrLf
                sql &= "FROM #SALDOS" & vbCrLf
                sql &= "WHERE #SALDOS.DEDUCCION IN (234,245)" & vbCrLf
                sql &= "GROUP BY Compañia, CODIGO_BUXIS, CODIGO_AS, NOMBRE" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "DELETE FROM #SALDOS WHERE DEDUCCION IN (234,245)" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "INSERT INTO #SALDOS" & vbCrLf
                sql &= "SELECT Compañia, FECHA, DEDUCCION, TIPO, CODIGO_AS, CODIGO_BUXIS, NOMBRE, SALDO" & vbCrLf
                sql &= "FROM #SALDOSCAF" & vbCrLf
                sql &= "" & vbCrLf
                '---- FIN AGREGADO PARA CONSOLIDAR CONSUMO CAFETERIA P1 Y P2 POR CAMBIO DE CUENTAS CONTABLES
                '---- AGREGADO PARA INCUIR CODIGO DE ORIGEN EN LOS SALDOS DE COOPERATIVA
                sql &= "ALTER TABLE #SALDOS ADD ORIGEN INT" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "UPDATE #SALDOS" & vbCrLf
                sql &= "   SET ORIGEN = SOC.ORIGEN" & vbCrLf
                sql &= "  FROM #SALDOS SDO, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
                sql &= " WHERE SOC.COMPAÑIA = " & Compañia & " AND SDO.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
                sql &= "" & vbCrLf
                '---- FIN AGREGADO PARA INCUIR CODIGO DE ORIGEN EN LOS SALDOS DE COOPERATIVA
                sql &= "" & vbCrLf
                sql &= "SELECT T.CUENTA_COMPLETA, T.DETALLE, T.DESCRIPCION_CUENTA, T.[DESCRIPCION DETALLE], T.SALDO AS SALDO_CONTABLE,SD.CODIGO_BUXIS, SD.NOMBRE,ISNULL(SD.SALDO,0) AS SALDO, T.SALDO - ISNULL(SD.SALDO,0) AS DIF, T.SOLICITUD, SD.DESCRIPCION_SOLICITUD" & vbCrLf
                sql &= "INTO #TEMPORALDEUDAS " & vbCrLf
                sql &= "FROM #TEMPORAL T LEFT JOIN" & vbCrLf
                sql &= "	(SELECT CS.SOLICITUD, S.CODIGO_BUXIS, S.NOMBRE, S.SALDO, CS.DESCRIPCION_SOLICITUD, S.ORIGEN" & vbCrLf
                sql &= "	FROM COOPERATIVA_CATALOGO_SOLICITUDES CS, #SALDOS S" & vbCrLf
                'sql &= "	WHERE CS.DEDUCCION = S.DEDUCCION AND CS.COMPAÑIA = " & Compañia & ") SD ON T.SOLICITUD = SD.SOLICITUD AND T.DETALLE = SD.CODIGO_BUXIS" & vbCrLf
                sql &= "	WHERE CS.DEDUCCION = S.DEDUCCION AND CS.COMPAÑIA = " & Compañia & ") SD ON T.SOLICITUD = SD.SOLICITUD AND T.DETALLE = SD.CODIGO_BUXIS AND T.ORIGEN = SD.ORIGEN" & vbCrLf 'No funciono modificacion para relacionar origen
                sql &= "" & vbCrLf
                sql &= "INSERT INTO #TEMPORALDEUDAS" & vbCrLf
                sql &= "SELECT ISNULL(T.CUENTA_COMPLETA,'1103019999' + ISNULL(dbo.PadLeft(CONVERT(VARCHAR, SD.SOLICITUD), '0', 3),'000')) AS CUENTA_COMPLETA, ISNULL(T.DETALLE, SD.CODIGO_BUXIS) AS DETALLE, ISNULL(T.DESCRIPCION_CUENTA, CASE WHEN SD.SOLICITUD = 19 THEN 'CONSUMO CAFETERIA' ELSE SD.DESCRIPCION_SOLICITUD  END + ' NO CONTABILIZADO') AS DESCRIPCION_CUENTA, T.[DESCRIPCION DETALLE], ISNULL(T.SALDO,0.00) AS SALDO_CONTABLE,SD.CODIGO_BUXIS, SD.NOMBRE,ISNULL(SD.SALDO,0) AS SALDO, ISNULL(T.SALDO,0.00) - ISNULL(SD.SALDO,0) AS DIF,SD.SOLICITUD, SD.DESCRIPCION_SOLICITUD" & vbCrLf
                'sql &= "SELECT ISNULL(T.CUENTA_COMPLETA,'00_NO_CONTAB_' + SD.DESCRIPCION_SOLICITUD) AS CUENTA_COMPLETA, ISNULL(T.DETALLE, SD.CODIGO_BUXIS) AS DETALLE, ISNULL(T.DESCRIPCION_CUENTA,'') AS DESCRIPCION_CUENTA, T.[DESCRIPCION DETALLE], ISNULL(T.SALDO,0.00) AS SALDO_CONTABLE,SD.CODIGO_BUXIS, SD.NOMBRE,ISNULL(SD.SALDO,0) AS SALDO, ISNULL(T.SALDO,0.00) - ISNULL(SD.SALDO,0) AS DIF,SD.SOLICITUD, SD.DESCRIPCION_SOLICITUD" & vbCrLf
                sql &= "FROM (SELECT CS.SOLICITUD, S.CODIGO_BUXIS, S.NOMBRE, S.SALDO, CS.DESCRIPCION_SOLICITUD, S.ORIGEN " & vbCrLf
                sql &= "	FROM COOPERATIVA_CATALOGO_SOLICITUDES CS, #SALDOS S" & vbCrLf
                'sql &= "	WHERE CS.DEDUCCION = S.DEDUCCION AND CS.COMPAÑIA = " & Compañia & ") SD LEFT JOIN #TEMPORAL T ON T.SOLICITUD = SD.SOLICITUD AND T.DETALLE = SD.CODIGO_BUXIS WHERE T.[DESCRIPCION DETALLE] IS NULL" & vbCrLf
                sql &= "	WHERE CS.DEDUCCION = S.DEDUCCION AND CS.COMPAÑIA = " & Compañia & ") SD LEFT JOIN #TEMPORAL T ON T.SOLICITUD = SD.SOLICITUD AND T.DETALLE = SD.CODIGO_BUXIS AND T.ORIGEN = SD.ORIGEN WHERE T.[DESCRIPCION DETALLE] IS NULL" & vbCrLf 'No funciono modificacion para relacionar origen
                sql &= "" & vbCrLf
                sql &= "DROP TABLE #TEMPORAL" & vbCrLf
                sql &= "DROP TABLE #SALDOS" & vbCrLf
                '---- AGREGADO PARA CONSOLIDAR CONSUMO CAFETERIA P1 Y P2 POR CAMBIO DE CUENTAS CONTABLES
                sql &= "DROP TABLE #SALDOSCAF" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "UPDATE #TEMPORALDEUDAS" & vbCrLf
                sql &= "   SET DESCRIPCION_SOLICITUD = 'CONSUMO CAFETERIA'" & vbCrLf
                sql &= " WHERE DESCRIPCION_SOLICITUD = 'CONSUMO CAFETERIA (PLANTA 1)'" & vbCrLf
                sql &= "" & vbCrLf
                '---- FIN AGREGADO PARA CONSOLIDAR CONSUMO CAFETERIA P1 Y P2 POR CAMBIO DE CUENTAS CONTABLES
                sql &= "SELECT * FROM #TEMPORALDEUDAS WHERE SALDO_CONTABLE <> 0 OR SALDO <> 0 ORDER BY CUENTA_COMPLETA, DETALLE" & vbCrLf
                sql &= "" & vbCrLf
                sql &= "DROP TABLE #TEMPORALDEUDAS"
            End If
        End If
        If Me.rbAhorros.Checked Then
            If Me.chkOrdin.Checked And Me.chkExtra.Checked Then
                Empresa = 0
            ElseIf Me.chkOrdin.Checked Then
                Empresa = 1
            ElseIf Me.chkExtra.Checked Then
                Empresa = 2
            End If
            sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_AHORROS_IUD]" & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @AHORRO = " & Empresa & vbCrLf
            sql &= ", @FECHA_AHORRO  = '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ", @USUARIO = '" & Orig & "'" & vbCrLf
            sql &= ", @IUD = 'CA'" & vbCrLf
            Me.btnGuardar.Enabled = False
        End If
        CargaRep()
    End Sub

    Private Sub CargaRep()
        Dim Reporte As New Contabilidad_Comparativo_Saldos_Cooperativa
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TableNew As New DataTable
        Dim saldosRows As DataRow()
        Dim frmVer As New frmReportes_Ver
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        If Table.Rows.Count > 0 And Not Me.chkRptGuardado.Checked Then
            Me.btnGuardar.Enabled = True
        Else
            Me.btnGuardar.Enabled = False
        End If
        If Me.chkSoloDif.Checked Then
            TableNew = Table.Clone
            saldosRows = Table.Select("DIF <> 0")
            For i As Integer = 0 To saldosRows.Length - 1
                TableNew.ImportRow(saldosRows(i))
            Next
            Reporte.SetDataSource(TableNew)
        Else
            Reporte.SetDataSource(Table)
        End If
        txtObj = Reporte.Section2.ReportObjects("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = Reporte.Section2.ReportObjects("txtPeriodo")
        txtObj.Text = "AL " & Format(Me.dtpFechaContable.Value, "dd-MMMM-yyyy").ToUpper()
        txtObj = Reporte.Section2.ReportObjects("txtFiltros")
        txtObj.ObjectFormat.EnableSuppress = True
        'txtObj.Text = " EMPRESA: " & Me.cmbOrigen.Text & "             RUBRO: " & Me.cmbTipoSoli.Text
        If Me.rbAhorros.Checked Then
            txtObj = Reporte.Section2.ReportObjects("Text12")
            txtObj.Text = "REPORTE COMPARATIVO ENTRE SALDOS CONTABLES Y SALDOS APORTACIONES DE SOCIOS COOPERATIVA"
        End If
        'Me.crvReporte.ReportSource = Reporte
        frmVer.ReportesGenericos(Reporte)
        frmVer.ShowDialog()
    End Sub

    Private Sub CargaTiposoli()
        Dim tableTipSol As DataTable
        sql = "SELECT SOLICITUD, DESCRIPCION_SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & vbCrLf
        sql &= " AND DESCRIPCION_SOLICITUD NOT LIKE '%ATAF%'"
        tableTipSol = jClass.obtenerDatos(New SqlCommand(sql))
        Me.dgvTipoSol.DataSource = tableTipSol
    End Sub

    Private Sub CargaOrigen()
        Dim tableTipEmp As DataTable
        sql = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN <> 21" & vbCrLf
        tableTipEmp = jClass.obtenerDatos(New SqlCommand(sql))
        Me.dgvEmpresas.DataSource = tableTipEmp
    End Sub

    Private Sub chkEmpresasTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpresasTodas.CheckedChanged
        For i As Integer = 0 To Me.dgvEmpresas.Rows.Count - 1
            Me.dgvEmpresas.Rows(i).Cells("selec").Value = Me.chkEmpresasTodas.Checked
        Next
    End Sub

    Private Sub chkRubrosTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRubrosTodos.CheckedChanged
        For i As Integer = 0 To Me.dgvTipoSol.Rows.Count - 1
            Me.dgvTipoSol.Rows(i).Cells(0).Value = Me.chkRubrosTodos.Checked
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim OrigenEmpl As Integer
        sql = "DELETE FROM CONTABILIDAD_COMPARATIVO_DEUDAS_COOPERATIVA WHERE COMPAÑIA = " & Compañia & " AND FECHA_CONTABLE = '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "' AND SOLICITUD IN (" & Solic & ") AND ORIGEN IN (" & Orig & ")" & vbCrLf
        sql &= "INSERT INTO CONTABILIDAD_COMPARATIVO_DEUDAS_COOPERATIVA " & vbCrLf
        sql &= "VALUES"
        For Each row As DataRow In Table.Rows
            If Not IsDBNull(row(1)) Then
                OrigenEmpl = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & row(1))
            ElseIf Not IsDBNull(row(5)) Then
                OrigenEmpl = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & row(5))
            Else
                OrigenEmpl = 0
            End If
            sql &= "('" & row(0) & "', " & IIf(IsDBNull(row(1)), "null", row(1)) & ", '" & row(2) & "', '" & row(3) & "', " & row(4) & ", " & IIf(IsDBNull(row(5)), "null", row(5)) & ", '" & row(6) & "', " & row(7) & ", " & row(8) & ", " & row(9) & ", '" & row(10) & "', " & OrigenEmpl & ", " & Compañia & ", '" & Format(Me.dtpFechaContable.Value, "dd/MM/yyyy") & "')," & vbCrLf
        Next
        sql = sql.Substring(0, sql.LastIndexOf(","))
        If jClass.ejecutarComandoSql(New SqlCommand(sql)) > 0 Then
            MsgBox(Table.Rows.Count & " Registros Guardados", MsgBoxStyle.Information, "Resultado")
        End If
    End Sub

    Private Sub Contabilidad_Reporte_Comparativo_Saldos_Cooperativa_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub rbAhorros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAhorros.CheckedChanged
        Me.gbTipoAh.Enabled = rbAhorros.Checked
    End Sub
End Class