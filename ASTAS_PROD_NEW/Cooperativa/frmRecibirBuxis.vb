Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRecibirBuxis

    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql, Concepto As String
    Dim Periodo As String = "QQ"
    Dim Table, TableAhorros As DataTable
    Dim TablaProgs As New DataTable
    Dim TableNoAplic As New DataTable("noaplicados")
    Dim CuotaDef As Double = 0

    Private Sub frmRecibirBuxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dpFechaPago.Value = SeteaFecha(Now.AddDays(-15.0))
        CrearTabla()
    End Sub

    Private Sub CargaBuxis()
        Dim fechaAhorro As Date = Me.dpFechaPago.Value
        Dim mesAhorro As Integer = Me.dpFechaPago.Value.Month
        Dim RowsAffected As Integer
        Dim NoDesc As DataRow()
        Try
            If mesAhorro = 1 Or mesAhorro = 3 Or mesAhorro = 5 Or mesAhorro = 7 Or mesAhorro = 8 Or mesAhorro = 10 Or mesAhorro = 12 Then
                If Me.dpFechaPago.Value.Day = 30 Then
                    fechaAhorro = Me.dpFechaPago.Value.AddDays(1)
                End If
            End If
            'Concepto = "RETENCIONES A EMPLEADOS, " & IIf(Me.Indemnizados, "INDEMNIZADOS", "PLANILLA " & IIf(Me.rbQna.Checked, Me.rbQna.Text.ToUpper, Me.rbMensual.Text.ToUpper)) & " DEL " & Me.dpFechaPago.Text
            Sql = "SELECT COUNT(COMPAÑIA) FROM COOPERATIVA_SOLICITUDES_CON_PARTIDAS WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & Format(Me.dpFechaPago.Value, "yyyyMMdd") & IIf(Me.rbQna.Checked, "01", "02")
            If jClass.obtenerEscalar(Sql) > 0 Then
                MsgBox("No se puede proceder." & vbCrLf & "El proceso ya fue ejecutado para ese periodo de pago.", MsgBoxStyle.Information, "Proceso cancelado")
                Me.btnProcesar.Enabled = True
                Me.Label2.Visible = False
                Return
            End If
            Indemnizados = False
            If Me.dpFechaPago.Value.Day = 15 Or Me.dpFechaPago.Value.Day = 30 Or (Me.dpFechaPago.Value.Month = 2 And Me.dpFechaPago.Value.Day = 28) Or (Me.dpFechaPago.Value.Month = 2 And Me.dpFechaPago.Value.Day = 29) Then
                Me.Label2.Text = "Cargando Ahorros Descontados..."
                If MsgBox("Se procederá a cargar los Ahorros Descontados" & vbCrLf & vbCrLf & "¿Desea Continuar?", MsgBoxStyle.YesNo, "Ahorros Descontados") = MsgBoxResult.Yes Then
                    sqlCmd.CommandTimeout = 7200
                    sqlCmd.CommandText = "EXECUTE [sp_COOPERATIVA_SOCIO_AHORROS_IUD] @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO_AS = '" & Periodo & "', @FECHA_AHORRO = '" & Format(fechaAhorro, "dd/MM/yyyy") & "',@IUD = 'BA', @USUARIO = 'buxis'"
                    TableAhorros = jClass.obtenerDatos(sqlCmd)
                    If TableAhorros.Rows.Count > 0 Then
                        MsgBox("TOTAL ORDINARIO: $ " & Format(TableAhorros.Rows(0).Item(1), "#,###.00") & vbCrLf & "TOTAL EXTRAORDINARIO: $ " & Format(TableAhorros.Rows(0).Item(0), "#,###.00"), MsgBoxStyle.Information, "AHORROS CARGADOS")
                    End If
                End If
            End If
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS] "
            Sql &= "@COMPAÑIA = " & Compañia & ", "
            Sql &= "@FECHA_PERIODO = '" & dpFechaPago.Value.ToShortDateString & "', "
            Sql &= "@PERIODO_PAGO = '" & Periodo & "', "
            sqlCmd.CommandText = Sql & "@BANDERA = 4"
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count = 0 Then
                'Para datos de indemnizados
                sqlCmd.CommandText = Sql & "@BANDERA = 16"
                Table = jClass.obtenerDatos(sqlCmd)
                Indemnizados = True
            End If
            If Table.Rows.Count = 0 Then
                MsgBox("No hay datos que procesar.", MsgBoxStyle.Information, "Recepción Buxis")
                Me.btnProcesar.Enabled = True
                Me.Label2.Visible = False
                Return
            End If
            TableNoAplic = Table.Clone()
            Me.pbAplicar.Value = 0
            Me.pbAplicar.Maximum = Table.Rows.Count
            Me.pbAplicar.Visible = True
            Me.Label2.Text = "Actualizando Cuotas Descontadas en planilla..."
            If Not Indemnizados Then
                'CAPITAL DESCONTADO
                Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
                Sql &= "SET COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.CAPITAL_D = 1, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION = 'buxis', COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION_FECHA = GETDATE(), COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.COMENTARIO = 'ABONO EN PLANILLA DEL " & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, PLANILLA_DESCUENTOS_APLICADOS DA, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES CS, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
                Sql &= "WHERE D.NUMERO_SOLICITUD = DA.UNID_HD" & vbCrLf
                Sql &= "  AND D.LINEA = DA.JORNALES_HD" & vbCrLf
                Sql &= "  AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
                Sql &= "  AND S.SOLICITUD = CS.SOLICITUD" & vbCrLf
                Sql &= "  AND DA.IMPTOT_HD = D.CAPITAL" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = CONVERT(DATE,D.FECHA_PAGO)" & vbCrLf
                Sql &= "  AND DA.COD_MF = SOC.CODIGO_EMPLEADO AND SOC.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND RTRIM(SOC.PERIODO_PAGO) = '" & Periodo & "'" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = '" & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "  AND DA.COD_MV = CS.DEDUCCION" & vbCrLf
                Sql &= "  AND DA.APLICADO = 1" & vbCrLf
                Sql &= "  AND D.COMPAÑIA = " & Compañia
                sqlCmd.CommandText = Sql
                RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
                'MsgBox(RowsAffected.ToString & vbCrLf & Me.pbAplicar.Maximum.ToString, MsgBoxStyle.Information, "CAPITAL")
                'Me.pbAplicar.Value = RowsAffected
                Try
                    Me.pbAplicar.Value += RowsAffected
                Catch ex As Exception
                End Try
                'INTERESES DESCONTADOS
                Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
                Sql &= "SET COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.INTERES_D = 1, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION = 'buxis', COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION_FECHA = GETDATE(), COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.COMENTARIO = 'ABONO EN PLANILLA DEL " & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, PLANILLA_DESCUENTOS_APLICADOS DA, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES CS, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
                Sql &= "WHERE D.NUMERO_SOLICITUD = DA.UNID_HD" & vbCrLf
                Sql &= "  AND D.LINEA = DA.JORNALES_HD" & vbCrLf
                Sql &= "  AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
                Sql &= "  AND S.SOLICITUD = CS.SOLICITUD" & vbCrLf
                Sql &= "  AND DA.IMPTOT_HD = D.INTERES" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = CONVERT(DATE,D.FECHA_PAGO)" & vbCrLf
                Sql &= "  AND DA.COD_MF = SOC.CODIGO_EMPLEADO AND SOC.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND RTRIM(SOC.PERIODO_PAGO) = '" & Periodo & "'" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = '" & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "  AND DA.COD_MV = CS.CODIGO_DEDUCCION_INTERESES" & vbCrLf
                Sql &= "  AND DA.APLICADO = 1"
                Sql &= "  AND D.COMPAÑIA = " & Compañia
                sqlCmd.CommandText = Sql
                RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
                'MsgBox(RowsAffected.ToString & vbCrLf & Me.pbAplicar.Maximum.ToString, MsgBoxStyle.Information, "INTERESES")
                'Me.pbAplicar.Value += RowsAffected
                Try
                    Me.pbAplicar.Value += RowsAffected
                Catch ex As Exception
                End Try
                'SEGURO DEUDA DESCONTADOS
                Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
                Sql &= "SET COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.SEG_DEUDA_D = 1, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION = 'buxis', COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.USUARIO_EDICION_FECHA = GETDATE(), COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE.COMENTARIO = 'ABONO EN PLANILLA DEL " & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D, PLANILLA_DESCUENTOS_APLICADOS DA, COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES CS, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
                Sql &= "WHERE D.NUMERO_SOLICITUD = DA.UNID_HD" & vbCrLf
                Sql &= "  AND D.LINEA = DA.JORNALES_HD" & vbCrLf
                Sql &= "  AND D.NUMERO_SOLICITUD = S.CORRELATIVO" & vbCrLf
                Sql &= "  AND S.SOLICITUD = CS.SOLICITUD" & vbCrLf
                Sql &= "  AND DA.IMPTOT_HD = D.SEG_DEUDA" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = CONVERT(DATE,D.FECHA_PAGO)" & vbCrLf
                Sql &= "  AND DA.COD_MF = SOC.CODIGO_EMPLEADO AND SOC.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND RTRIM(SOC.PERIODO_PAGO) = '" & Periodo & "'" & vbCrLf
                Sql &= "  AND DA.FEC_ACU_HD = '" & Format(dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "  AND DA.COD_MV = CS.CODIGO_DEDUCCION_SEGURO_DEUDA" & vbCrLf
                Sql &= "  AND DA.APLICADO = 1"
                Sql &= "  AND D.COMPAÑIA = " & Compañia
                sqlCmd.CommandText = Sql
                RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
                'MsgBox(RowsAffected.ToString & vbCrLf & Me.pbAplicar.Maximum.ToString, MsgBoxStyle.Information, "SEGURO DEUDA")
                'Me.pbAplicar.Value += RowsAffected
                Try
                    Me.pbAplicar.Value += RowsAffected
                Catch ex As Exception
                End Try
                NoDesc = Table.Select("NOT APLICADO")
                For i As Integer = 0 To NoDesc.Length - 1
                    TableNoAplic.ImportRow(NoDesc(i))
                Next
            Else
                For Each row As DataRow In Table.Rows
                    If row.Item(9) And row.Item(1) = row.Item(10) Then
                        CancelarDeudasIndemnizados(row.Item(5), row.Item(6), row.Item(3), row.Item(11), row.Item(8))
                    End If
                    TableNoAplic.ImportRow(row)
                    Try
                        Me.pbAplicar.Value += 1
                    Catch ex As Exception
                    End Try
                Next
            End If
            Dim sortExp As String = "Numero"
            Dim drarray() As DataRow
            Dim NSol As Integer = 0
            Dim MyTABLE As DataTable
            MyTABLE = TableNoAplic.Clone
            drarray = TableNoAplic.Select(Nothing, sortExp)
            For i As Integer = 0 To (drarray.Length - 1)
                MyTABLE.ImportRow(drarray(i))
            Next
            For Each row As System.Data.DataRow In MyTABLE.Rows
                Me.dgvNoAplicados.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10))
            Next
            If Not Indemnizados Then
                'MsgBox(MyTABLE.Rows.Count.ToString & vbCrLf & Me.pbAplicar.Maximum.ToString, MsgBoxStyle.Information, "No Desc")
                Me.Label2.Text = "REPROGRAMANDO CUOTAS NO DESCONTADAS..."
                Me.bw1.RunWorkerAsync(MyTABLE)
            Else
                ProcesadoFinalizado()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
        End Try
    End Sub

    Private Function SeteaFecha(ByVal FechaEvaluada As Date) As Date
        Dim Fecha As Date = FechaEvaluada
        If FechaEvaluada.Day <= 15 Then
            FechaEvaluada = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf FechaEvaluada.Day > 15 And FechaEvaluada.Day <= Date.DaysInMonth(FechaEvaluada.Year, FechaEvaluada.Month) Then
            If FechaEvaluada.Month = 2 Then
                If FechaEvaluada.Year Mod 4 = 0 Then
                    FechaEvaluada = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    FechaEvaluada = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                FechaEvaluada = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        End If
        Return FechaEvaluada
    End Function

    Private Sub ActualizarDescuentos(ByVal NumSoli As Integer, ByVal Bandera As Integer, ByVal FechaAplicacion As Date, ByVal ValorDesc As Double)
        If Bandera = 8 Then
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS]"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @FECHA_PERIODO = '" & Format(FechaAplicacion, "dd/MM/yyyy") & "'"
            Sql &= ", @BANDERA = " & Bandera
        Else
            Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
            If Bandera = 5 Then 'CAPITAL PAGADO
                Sql &= " SET CAPITAL_D = 1," & vbCrLf
            End If
            If Bandera = 6 Then 'INTERES PAGADO
                Sql &= " SET INTERES_D = 1," & vbCrLf
            End If
            If Bandera = 7 Then 'SEGURO DEUDA PAGADO
                Sql &= " SET SEG_DEUDA_D = 1," & vbCrLf
            End If
            Sql &= " USUARIO_EDICION = 'buxis'," & vbCrLf
            Sql &= " USUARIO_EDICION_FECHA = GETDATE()" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= " AND NUMERO_SOLICITUD = " & NumSoli & vbCrLf
            Sql &= " AND FECHA_PAGO = '" & FechaAplicacion.ToShortDateString & "'" & vbCrLf
            Sql &= " AND LINEA = " & CInt(ValorDesc)
        End If
        sqlCmd.CommandText = Sql
        Try
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If Bandera <> 8 Then
            'MARCA DE PROCESADO POR SI EL PROCESO TUVIERA ALGUN CORTE
            'YA SEA POR ERRORES O DESCONEXION DE LA BASE DE DATOS
            sqlCmd.CommandText = "UPDATE PLANILLA_DESCUENTOS_APLICADOS SET HORAS_HD = 1 WHERE UNID_HD = " & NumSoli & " AND JORNALES_HD = " & ValorDesc & " AND FEC_ACU_HD = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
            jClass.ejecutarComandoSql(sqlCmd)
        End If
    End Sub

    Private Function ValidarDeduccion(ByVal NumSoli As Integer, ByVal codDeduc As Integer, ByVal Bandera As Integer) As Boolean
        Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS]"
        Sql &= " @COMPAÑIA = " & Compañia
        Sql &= ", @NUM_SOLICITUD = " & NumSoli
        Sql &= ", @BANDERA = " & Bandera
        Try
            If codDeduc = jClass.obtenerEscalar(Sql) Then
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
        Return False
    End Function

    Private Sub CancelarDeudasIndemnizados(ByVal CodigoEmpleado As Integer, ByVal CodigoAS As String, ByVal TipoSoli As Integer, ByVal MontoDescontado As Double, ByVal MontoTotal As Double)
        Try
            Dim TablaSolPend As DataTable
            Dim NumSoli, Linea, RowsAffected As Integer
            TablaSolPend = DeudasPendientes(CodigoEmpleado, CodigoAS, TipoSoli)
            For i As Integer = 0 To TablaSolPend.Rows.Count - 1
                NumSoli = TablaSolPend.Rows(i).Item(0)
                sqlCmd.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_DEUDA_PAGO_PR " & Compañia & ", '" & CodigoAS & "', " & CodigoEmpleado & ", " & NumSoli & ", '" & Usuario & "', 'UDSP'"
                jClass.ejecutarComandoSql(sqlCmd)
            Next
            If MontoTotal > MontoDescontado Then 'Se descontó solo una parte del saldo de la deuda
                'Es necesario crear una entrada para que la deuda pueda ser descontada de los ahorros del socio
                Linea = jClass.obtenerEscalar("SELECT ISNULL(MAX(LINEA), 0) + 1 FROM dbo.COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & NumSoli)
                Sql = "INSERT INTO [COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]"
                Sql &= "([COMPAÑIA]"
                Sql &= ",[NUMERO_SOLICITUD]"
                Sql &= ",[LINEA]"
                Sql &= ",[FECHA_PAGO]"
                Sql &= ",[SALDO_INI]"
                Sql &= ",[CAPITAL]"
                Sql &= ",[INTERES]"
                Sql &= ",[SEG_DEUDA]"
                Sql &= ",[CUOTA]"
                Sql &= ",[SALDO_FIN]"
                Sql &= ",[INTERES_ACUM]"
                Sql &= ",[USUARIO_CREACION]"
                Sql &= ",[USUARIO_CREACION_FECHA]"
                Sql &= ",[USUARIO_EDICION]"
                Sql &= ",[USUARIO_EDICION_FECHA])"
                Sql &= "VALUES"
                Sql &= "(" & Compañia
                Sql &= "," & NumSoli
                Sql &= "," & Linea
                Sql &= ",'" & Me.dpFechaPago.Value.ToShortDateString & "'"
                Sql &= "," & MontoTotal - MontoDescontado
                Sql &= "," & MontoTotal - MontoDescontado
                Sql &= ",0"
                Sql &= ",0"
                Sql &= "," & MontoTotal - MontoDescontado
                Sql &= ",0"
                Sql &= ",0"
                Sql &= ",'" & Usuario & "'"
                Sql &= ",'" & Now.ToShortDateString & "'"
                Sql &= ",'" & Usuario & "'"
                Sql &= ",'" & Now.ToShortDateString & "')"
                sqlCmd.CommandText = Sql
                RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Cancelar Deudas Indemnizados")
        End Try
    End Sub

    Private Function DeudasPendientes(ByVal CodigoEmpleado As Integer, ByVal CodigoAS As String, ByVal TipoSoli As Integer) As DataTable
        Dim SolPend As DataTable
        Sql = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS"
        Sql &= " @Compañia = " & Compañia
        Sql &= ", @CodigoAS = '" & CodigoAS & "'"
        Sql &= ", @CodigoBuxis = " & CodigoEmpleado
        Sql &= ", @SIUD = 'TDXTIPOSOLI'"
        Sql &= ", @DEDUCCION = " & TipoSoli
        sqlCmd.CommandText = Sql
        SolPend = jClass.obtenerDatos(sqlCmd)
        Return SolPend
    End Function

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim frmVer As New frmReportes_Ver
        Dim Rpt As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Try
            TextObj = Rpt.Section2.ReportObjects.Item("Text13")
            TextObj.Text = Descripcion_Compañia
            TextObj = Rpt.Section2.ReportObjects.Item("Text1")
            TextObj.Text = "REPORTE DE DESCUENTOS NO APLICADOS EN PLANILLA " & IIf(Periodo = "QQ", "QUINCENAL", "MENSUAL") & " (BUXIS)"
            Rpt.SetDataSource(TableNoAplic)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        frmVer.ReportesGenericos(Rpt)
        frmVer.ShowDialog()
        frmVer.Dispose()
    End Sub

    Private Sub ReprogramarCuotas(ByVal FechaPago As Date, ByVal NumSoli As Integer, ByVal Linea As Integer, ByVal codBuxis As Integer)
        Try
            Dim TableRep, TableSaldos As DataTable
            Dim PeriodoPago, PeriodoPagoSolic As String
            Dim NuevaFecha As Date
            Dim Capital, Interes, segDeuda, IntAcum As Double
            Dim Deduccion As Integer
            Dim CuotasPend As Integer
            Dim numCuotas As Integer = 0
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU] "
            Sql &= "@COMPAÑIA = " & Compañia & ", "
            Sql &= "@NUM_SOLICITUD = " & NumSoli & ", "
            Sql &= "@LINEA = " & Linea & ", "
            Sql &= "@FECHA_PAGO = '" & Format(dpFechaPago.Value, "dd/MM/yyyy") & "', "
            Sql &= "@USUARIO = '" & Usuario & "', "
            Sql &= "@BANDERA = 11"
            sqlCmd.CommandText = Sql
            TableRep = jClass.obtenerDatos(sqlCmd)
            If TableRep.Rows.Count = 0 Then
                Return
            End If
            PeriodoPagoSolic = jClass.obtenerEscalar("SELECT PERIODO FROM [dbo].[COOPERATIVA_SOLICITUDES] WHERE CORRELATIVO = " & NumSoli & " AND COMPAÑIA = " & Compañia)
            PeriodoPago = jClass.obtenerEscalar("SELECT PERIODO_PAGO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & codBuxis & " AND COMPAÑIA = " & Compañia).ToString.Trim
            Deduccion = jClass.obtenerEscalar("SELECT DEDUCCION FROM [dbo].[COOPERATIVA_SOLICITUDES] WHERE CORRELATIVO = " & NumSoli & " AND COMPAÑIA = " & Compañia)
            Interes = jClass.obtenerEscalar("SELECT INTERES FROM dbo.COOPERATIVA_CATALOGO_DEDUCCIONES WHERE DEDUCCION = " & Deduccion & " AND COMPAÑIA = " & Compañia)
            segDeuda = jClass.obtenerEscalar("SELECT INTERES FROM dbo.COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO WHERE DEDUCCION = " & Deduccion & " AND COMPAÑIA = " & Compañia)
            If PeriodoPago = "QQ" And PeriodoPagoSolic = "MM" Then
                PeriodoPago = "MM"
            End If
            NuevaFecha = FechaPago
            If PeriodoPago.Trim = "QQ" Then
                If NuevaFecha.Day = 15 Then
                    If NuevaFecha.Month = 2 Then
                        If NuevaFecha.Year Mod 4 = 0 Then
                            NuevaFecha = CDate("29/" & NuevaFecha.Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.Year.ToString)
                        Else
                            NuevaFecha = CDate("28/" & NuevaFecha.Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.Year.ToString)
                        End If
                    Else
                        NuevaFecha = CDate("30/" & NuevaFecha.Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.Year.ToString)
                    End If
                Else
                    NuevaFecha = CDate("15/" & NuevaFecha.AddDays(15).Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.AddDays(15).Year.ToString)
                End If
            ElseIf PeriodoPago.Trim = "MM" Then
                If NuevaFecha.Day = 15 Then
                    NuevaFecha = CDate("15/" & NuevaFecha.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.AddMonths(1).Year.ToString)
                Else
                    If NuevaFecha.Month = 1 And NuevaFecha.Day = 30 Then
                        If NuevaFecha.Year Mod 4 = 0 Then
                            NuevaFecha = CDate("29/" & NuevaFecha.AddDays(3).Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.AddDays(3).Year.ToString)
                        Else
                            NuevaFecha = CDate("28/" & NuevaFecha.AddDays(3).Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.AddDays(3).Year.ToString)
                        End If
                    Else
                        NuevaFecha = CDate("30/" & NuevaFecha.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/" & NuevaFecha.AddMonths(1).Year.ToString)
                    End If
                End If
            End If
            If Not TableRep.Rows(0).Item("Seguro Deuda D") And TableRep.Rows(0).Item("Seguro Deuda") > 0 Then
                NoPagado(codBuxis, TableRep.Rows(0).Item("Seguro Deuda"), 1, PeriodoPago, NuevaFecha)
                Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE " & vbCrLf
                Sql &= "   SET SEG_DEUDA = 0.00, SEG_DEUDA_D = 1" & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND NUMERO_SOLICITUD = " & NumSoli & vbCrLf
                Sql &= "   AND LINEA = " & Linea & vbCrLf
                Sql &= "   AND FECHA_PAGO = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                jClass.Ejecutar_ConsultaSQL(Sql)
            End If
            If Not TableRep.Rows(0).Item("Interes D") And TableRep.Rows(0).Item("Interes") > 0 Then
                NoPagado(codBuxis, TableRep.Rows(0).Item("Interes"), 2, PeriodoPago, NuevaFecha)
                Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE " & vbCrLf
                Sql &= "   SET INTERES = 0.00, INTERES_D = 1" & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND NUMERO_SOLICITUD = " & NumSoli & vbCrLf
                Sql &= "   AND LINEA = " & Linea & vbCrLf
                Sql &= "   AND FECHA_PAGO = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                jClass.Ejecutar_ConsultaSQL(Sql)
            End If
            If Not TableRep.Rows(0).Item("Capital D") And TableRep.Rows(0).Item("Capital") > 0 Then
                If Deduccion = 523 Or Deduccion = 524 Or Deduccion = 566 Or Deduccion = 567 Then
                    'cuota no descontada de INTERESES REPROGRAMADOS o SEGURO DEUDA REPROGRAMADO
                    Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE " & vbCrLf
                    Sql &= "   SET FECHA_PAGO = '" & Format(NuevaFecha, "dd/MM/yyyy") & "' " & vbCrLf
                    Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND NUMERO_SOLICITUD = " & NumSoli & vbCrLf
                    Sql &= "   AND LINEA = " & Linea & vbCrLf
                    Sql &= "   AND FECHA_PAGO = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                Else
                    Sql = "SELECT ISNULL(SUM(CAPITAL), 0) AS CAPITAL, COUNT(LINEA) AS CUOTAS" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
                    Sql &= " WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & NumSoli
                    Sql &= "   AND CAPITAL_D = 0"
                    sqlCmd.CommandText = Sql
                    TableSaldos = jClass.obtenerDatos(sqlCmd)
                    Capital = TableSaldos.Rows(0).Item("CAPITAL")
                    CuotasPend = TableSaldos.Rows(0).Item("CUOTAS")
                    ProgramacionCuota(Capital, Interes, segDeuda, PeriodoPago, CuotasPend)
                    Sql = "SELECT ISNULL(SUM(INTERES), 0) AS INT_ACUM" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
                    Sql &= " WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & NumSoli
                    Sql &= "   AND INTERES_D = 1"
                    IntAcum = jClass.obtenerEscalar(Sql)
                    numCuotas = Programacion(NumSoli, Deduccion, Capital, Interes, segDeuda, PeriodoPago, NuevaFecha, IntAcum)
                    While numCuotas <> CuotasPend
                        If CuotasPend < numCuotas Then
                            CuotaDef = CuotaDef + 0.01
                        Else
                            CuotaDef = CuotaDef - 0.01
                        End If
                        numCuotas = Programacion(NumSoli, Deduccion, Capital, Interes, segDeuda, PeriodoPago, NuevaFecha, IntAcum)
                    End While
                    For Each row As DataRow In TablaProgs.Rows
                        MantenimientoProgramacion(NumSoli, Deduccion, row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1)
                    Next
                    Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE " & vbCrLf
                    Sql &= "   SET CAPITAL = 0.00, CAPITAL_D = 1, SALDO_FIN = SALDO_INI, INTERES_ACUM = " & Format(IntAcum, "0.00") & vbCrLf
                    Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND NUMERO_SOLICITUD = " & NumSoli & vbCrLf
                    Sql &= "   AND LINEA = " & Linea & vbCrLf
                    Sql &= "   AND FECHA_PAGO = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
                    jClass.Ejecutar_ConsultaSQL(Sql)
                    eliminaProgramacionesNoDescontadas(NumSoli)
                    MantenimientoProgramacionDetalle(NumSoli)
                End If
            End If
            'MARCA DE PROCESADO POR SI EL PROCESO TUVIERA ALGUN CORTE
            'YA SEA POR ERRORES O DESCONEXION DE LA BASE DE DATOS
            sqlCmd.CommandText = "UPDATE PLANILLA_DESCUENTOS_APLICADOS SET HORAS_HD = 1 WHERE UNID_HD = " & NumSoli & " AND JORNALES_HD = " & Linea & " AND FEC_ACU_HD = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Reprogramar Deudas")
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If Me.dpFechaPago.Value.Day <> 12 Then
            ActualizarDescuentos(0, 8, Me.dpFechaPago.Value, 0)
        End If
        Me.btnProcesar.Enabled = False
        Me.Label2.Visible = True
        CargaBuxis()
    End Sub

    Private Sub rbQna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna.CheckedChanged
        If Not Iniciando Then
            If rbQna.Checked Then
                Periodo = "QQ"
            End If
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMensual.CheckedChanged
        If Not Iniciando Then
            If rbMensual.Checked Then
                Periodo = "MM"
            End If
        End If
    End Sub

    Private Sub frmRecibirBuxis_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    '-------------------------------------------------------------------------------------------------------------------
    'AQUI COMIENZA EL NUEVO PROCESO PARA REPROGRAMAR CUOTAS NO DESCONTADAS Y REPROGAMACION DE CAPITAL NO PAGADO
    Private Sub eliminaProgramacionesNoDescontadas(ByVal numSoli As Integer)
        'Eliminamos las cuotas pendientes de pago antes de realizar la nueva programación
        Dim Linea As Integer
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= "@NUM_SOLICITUD = " & numSoli & "," & vbCrLf
            Sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= "@IUD = 'E'"
            Linea = jClass.obtenerEscalar(Sql)
            Sql = "UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET LINEA = LINEA + " & Linea & " WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & numSoli
            sqlCmd.CommandText = Sql
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MantenimientoProgramacionDetalle(ByVal NumSoli As Integer)
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= "@NUM_SOLICITUD = " & NumSoli & "," & vbCrLf
            Sql &= "@LINEA = 0," & vbCrLf
            Sql &= "@FECHA_PAGO = '" & Format(Now, "dd/MM/yyyy") & "'," & vbCrLf
            Sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= "@BANDERA = 1"
            sqlCmd.CommandText = Sql
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function Programacion(ByVal numSoli As Integer, ByVal Deduccion As Integer, ByVal Saldo As Double, ByVal TasaInteres As Double, ByVal Tasa_Seguro As Double, ByVal Periodo As String, ByVal FechaPago As DateTime, ByVal InteresAcum As Double) As Integer
        'Calcula la programación basado en la cuota enviada
        'Retorna la cantidad de cuotas que se generan en base a la cuota definida 
        MantenimientoProgramacion(numSoli, Deduccion, 0, Now(), 0, 0, 0, 0, 0, 0, 0, 3)
        Dim TotalCuotas As Double = 0
        Dim Cuota As Double = CuotaDef
        'Dim InteresAcum As Double = 0
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = IIf(Periodo = "QQ", 15, 30)
        Dim i As Integer = 0
        While TablaProgs.Rows.Count > 0
            TablaProgs.Rows.RemoveAt(0)
        End While
        While Saldo > Cuota
            i += 1
            Interes = (Saldo * (TasaInteres / 100) * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * (Tasa_Seguro / 100)) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Cuota - Interes - Seguro
            Capital = Math.Round(Capital, 2, MidpointRounding.ToEven)
            TablaProgs.Rows.Add(Compañia, numSoli, i, Deduccion, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
            If Periodo = "QQ" Then
                If FechaPago.Day = 15 Then
                    If FechaPago.Month = 2 Then
                        If (FechaPago.Year Mod 4) = 0 Then
                            FechaPago = FechaPago.AddDays(14)
                        Else
                            FechaPago = FechaPago.AddDays(13)
                        End If
                    Else
                        FechaPago = FechaPago.AddDays(15)
                    End If
                Else
                    FechaPago = CDate("15/" & FechaPago.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/" & FechaPago.AddMonths(1).Year.ToString())
                End If
            Else
                If FechaPago.Day = 15 Then
                    FechaPago = CDate("15/" & FechaPago.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/" & FechaPago.AddMonths(1).Year.ToString)
                Else
                    If FechaPago.Month = 1 And FechaPago.Day = 30 Then
                        If FechaPago.Year Mod 4 = 0 Then
                            FechaPago = CDate("29/" & FechaPago.AddDays(3).Month.ToString.PadLeft(2, "0") & "/" & FechaPago.AddDays(3).Year.ToString)
                        Else
                            FechaPago = CDate("28/" & FechaPago.AddDays(3).Month.ToString.PadLeft(2, "0") & "/" & FechaPago.AddDays(3).Year.ToString)
                        End If
                    Else
                        FechaPago = CDate("30/" & FechaPago.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/" & FechaPago.AddMonths(1).Year.ToString)
                    End If
                End If
            End If
            'DiasPP = IIf(Periodo = "QQ", 15, 30)
            Saldo -= Capital
        End While
        If Saldo > 0 Then
            i += 1
            Interes = (Saldo * (TasaInteres / 100) * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            Seguro = ((Saldo * (Tasa_Seguro / 100)) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Saldo
            Cuota = Saldo + Interes + Seguro
            TablaProgs.Rows.Add(Compañia, numSoli, i, Deduccion, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
        End If
        Return i
    End Function

    Private Sub ProgramacionCuota(ByVal Saldo As Double, ByVal TasaInteres As Double, ByVal Tasa_Seguro As Double, ByVal Periodo As String, ByVal NumCuotas As Integer)
        Dim InteresAcum As Double = 0
        Dim TotalCuotas As Double
        Dim Cuota As Double
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = IIf(Periodo = "QQ", 15, 30)
        If TasaInteres > 0 Then
            Dim Inter_E As Double = CDbl(IIf(Periodo = "MM", (TasaInteres / 100) / 12, (TasaInteres / 100) / 24))
            Dim Factor0 As Double = (1 + Inter_E) ^ -NumCuotas
            Dim Factor1 As Double = IIf(Inter_E > 0, (1 - Factor0) / Inter_E, 0)
            Cuota = IIf(Factor1 > 0, CDbl(Saldo) / Factor1, 0)
        Else
            Cuota = IIf(NumCuotas > 0, Saldo / NumCuotas, 0)
        End If
        Cuota = Math.Round(Cuota, 2, MidpointRounding.ToEven)
        For i As Integer = 1 To NumCuotas
            Interes = (Saldo * (TasaInteres / 100) * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * (Tasa_Seguro / 100)) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            If i = NumCuotas Then
                Capital = Saldo
                Cuota = Saldo + Interes
            Else
                If Saldo > Cuota Then
                    Capital = Cuota - Interes
                Else
                    Cuota = Saldo + Interes
                    Capital = Saldo
                End If
                Capital = Math.Round(Capital, 2, MidpointRounding.ToEven)
            End If
            Saldo -= Capital
            TotalCuotas += Cuota + Seguro
        Next
        CuotaDef = Math.Round(TotalCuotas / NumCuotas, 2)
    End Sub

    Private Sub CrearTabla()
        TablaProgs.Columns.Add("COMPAÑIA", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("N_SOLICITUD", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Nº", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Deduccion", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Fecha Pago", Type.GetType("System.DateTime"))
        TablaProgs.Columns.Add("Saldo Inicial", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Capital", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Interes", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Seguro Deuda", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Cuota", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Saldo Final", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Interes Acumulado", Type.GetType("System.Double"))
    End Sub

    Private Sub MantenimientoProgramacion(ByVal numSoli As Integer, ByVal Deduccion As Integer, ByVal Linea As Integer, ByVal FechaP As DateTime, ByVal SaldoIni As Double, ByVal Capital As Double, ByVal Interes As Double, ByVal SegDeuda As Double, ByVal Cuota As Double, ByVal SaldoFin As Double, ByVal InteresAcum As Double, ByVal Bandera As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_SID ", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = numSoli
            DataAdapter.SelectCommand.Parameters.Add("@LINEA", SqlDbType.Int).Value = Linea
            DataAdapter.SelectCommand.Parameters.Add("@DEDUCCION", SqlDbType.Int).Value = Deduccion
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_PAGO", SqlDbType.DateTime).Value = FechaP
            DataAdapter.SelectCommand.Parameters.Add("@SALDO_INI", SqlDbType.Money).Value = SaldoIni
            DataAdapter.SelectCommand.Parameters.Add("@CAPITAL", SqlDbType.Money).Value = Capital
            DataAdapter.SelectCommand.Parameters.Add("@INTERES", SqlDbType.Money).Value = Interes
            DataAdapter.SelectCommand.Parameters.Add("@SEG_DEUDA", SqlDbType.Money).Value = SegDeuda
            DataAdapter.SelectCommand.Parameters.Add("@CUOTA", SqlDbType.Money).Value = Cuota
            DataAdapter.SelectCommand.Parameters.Add("@SALDO_FIN", SqlDbType.Money).Value = SaldoFin
            DataAdapter.SelectCommand.Parameters.Add("@INTERES_ACUM", SqlDbType.Money).Value = InteresAcum
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = Bandera
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub

    Private Sub NoPagado(ByVal codigo As Integer, ByVal Valor As Double, ByVal Tipo As Integer, ByVal Periodo As String, ByVal fechaPago As Date)
        Dim numSolSD As Integer
        Dim CodAS As String = jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & codigo)
        Dim Linea As Integer
        Dim TipoSol As Integer
        Dim Deduccion As Integer
        Dim OrigenEmpl As Integer = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & codigo)
        Sql = "SELECT ISNULL(MAX(CORRELATIVO), 0) FROM COOPERATIVA_SOLICITUDES " & vbCrLf
        Sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
        If Tipo = 1 Then
            If OrigenEmpl = 5 Then
                Sql &= "  AND DEDUCCION = 566" & vbCrLf
                TipoSol = 33
                Deduccion = 566
            Else
                Sql &= "  AND DEDUCCION = 524" & vbCrLf
                TipoSol = 18
                Deduccion = 524
            End If
        Else
            If OrigenEmpl = 5 Then
                Sql &= "  AND DEDUCCION = 567" & vbCrLf
                TipoSol = 34
                Deduccion = 567
            Else
                Sql &= "  AND DEDUCCION = 523" & vbCrLf
                TipoSol = 17
                Deduccion = 523
            End If
        End If
        Sql &= "  AND CODIGO_BUXIS = " & codigo
        numSolSD = jClass.obtenerEscalar(Sql)
        If numSolSD = 0 Then
            numSolSD = Numero_Orden()
            Insertar_Solicitud(numSolSD, Deduccion, CodAS, codigo, Valor, Periodo, TipoSol, fechaPago)
        End If
        Linea = jClass.obtenerEscalar("SELECT ISNULL(MAX(LINEA), 0) + 1 AS LINEA FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & numSolSD)
        insertarDetalleProg(numSolSD, fechaPago, Valor, Linea)
    End Sub

    Private Function Numero_Orden() As Integer
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim numSol As Integer = 0
        Try
            Sql = "EXECUTE sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @TIPO_DOCUMENTO = 'SOL'," & vbCrLf
            Sql &= " @ULTIMO = 0"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                numSol = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return numSol
    End Function

    Private Sub Insertar_Solicitud(ByVal NumSol As Integer, ByVal Deduccion As Integer, ByVal CodAS As String, ByVal CodBuxis As Integer, ByVal Valor As Double, ByVal Periox As String, ByVal TipoSol As Integer, ByVal fechaPago As Date)
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_SOLICITUDES_IU " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & ","
            Sql &= " @SOLICITUD = " & TipoSol & ","
            Sql &= " @DEDUCCION = " & Deduccion & ","
            Sql &= " @CORRELATIVO = " & NumSol & ","
            Sql &= " @CODIGO_AS  = '" & CodAS & "',"
            Sql &= " @CODIGO_BUXIS = " & CodBuxis & ","
            Sql &= " @PROVEEDOR = 0,"
            Sql &= " @FECHA_SOLICITUD = '" & Format(Me.dpFechaPago.Value, "dd-MM-yyyy") & "',"
            Sql &= " @AUTORIZACION_EX = 0,"
            Sql &= " @VALOR_VALE = " & Valor & " ,"
            Sql &= " @INTERES = 0,"
            Sql &= " @PERIODO = '" & Periox & "',"
            Sql &= " @PLAZO = 1,"
            Sql &= " @USUARIO = '" & Usuario & "',"
            Sql &= " @ES_FACTURA = 1,"
            Sql &= " @BONIFICACION = 0,"
            Sql &= " @AGUINALDO = 0"
            sqlCmd.CommandText = Sql
            If jClass.ejecutarComandoSql(sqlCmd) > 0 Then
                Sql = "EXECUTE [Coo].[sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU]" & vbCrLf
                Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
                Sql &= " ,@N_SOLICITUD = " & NumSol & vbcrlf
                Sql &= " ,@ORDEN_DE_COMPRA = 0" & vbCrLf
                Sql &= " ,@AUTORIZACION1 = 1" & vbcrlf
                Sql &= " ,@COMENTARIO1 = 'Cuotas no descontadas en planilla'" & vbCrLf
                Sql &= " ,@FECHA1 = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= " ,@AUTORIZACION2 = 0" & vbcrlf
                Sql &= " ,@COMENTARIO2 = ''" & vbCrLf
                Sql &= " ,@FECHA2 = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbcrlf
                Sql &= " ,@AUTORIZACION3 = 0" & vbCrLf
                Sql &= " ,@COMENTARIO3 = ''" & vbCrLf
                Sql &= " ,@FECHA3 = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= " ,@DENEGADA = 0" & vbcrlf
                Sql &= " ,@COMENTARIO_DENEGADA = ''" & vbCrLf
                Sql &= " ,@FECHA_DENEGADA = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= " ,@USUARIO_DENEGO = ''" & vbCrLf
                Sql &= " ,@ANULADA = 0" & vbCrLf
                Sql &= " ,@COMENTARIO_ANULADA = ''" & vbCrLf
                Sql &= " ,@FECHA_ANULADA = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= " ,@USUARIO_ANULO = ''"
                Sql &= " ,@CODIGO_AS = '" & CodAS & "'"
                Sql &= " ,@CODIGO_BUXIS = " & CodBuxis
                Sql &= " ,@USUARIO_CREACION = '" & Usuario & "'"
                Sql &= " ,@BANDERA = 0"
                Sql &= " ,@TIPO_FACTURA = 0"
                Sql &= " ,@NUMERO_FACTURA = 0"
                sqlCmd.CommandText = Sql
                If jClass.ejecutarComandoSql(sqlCmd) > 0 Then
                    jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOLICITUDES SET PROGRAMADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & NumSol)
                    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & vbCrLf
                    Sql &= "@COMPAÑIA  = " & Compañia & "," & vbCrLf
                    Sql &= "@NUM_SOLICITUD = " & NumSol & "," & vbCrLf
                    Sql &= "@DEDUCCION = " & Deduccion & "," & vbCrLf
                    Sql &= "@NUM_CUOTAS = 1," & vbCrLf
                    Sql &= "@CUOTA = " & Valor & "," & vbCrLf
                    Sql &= "@MONTO = " & Valor & "," & vbCrLf
                    Sql &= "@PERIODO = '" & Periox & "'," & vbCrLf
                    Sql &= "@INI_PRESTAMO = '" & Format(Now(), "dd-MM-yyyy") & "'," & vbCrLf
                    Sql &= "@FECHA_PIMERPAG = '" & Format(fechaPago, "dd-MM-yyyy") & "'," & vbCrLf
                    Sql &= "@TASA_INTERES = 0," & vbCrLf
                    Sql &= "@TASA_INTERES_SEG = 0," & vbCrLf
                    Sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
                    Sql &= "@BANDERA = 1"
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub insertarDetalleProg(ByVal numSol As Integer, ByVal fechaPago As Date, ByVal Valor As Double, ByVal Linea As Integer)
        Try
            Sql = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]" & vbCrLf
            Sql &= "([COMPAÑIA]" & vbCrLf
            Sql &= ",[NUMERO_SOLICITUD]" & vbCrLf
            Sql &= ",[LINEA]" & vbCrLf
            Sql &= ",[ENVIADA]" & vbCrLf
            Sql &= ",[RECIBIDA]" & vbCrLf
            Sql &= ",[FECHA_PAGO]" & vbCrLf
            Sql &= ",[SALDO_INI]" & vbCrLf
            Sql &= ",[CAPITAL]" & vbCrLf
            Sql &= ",[CAPITAL_D]" & vbCrLf
            Sql &= ",[INTERES]" & vbCrLf
            Sql &= ",[INTERES_D]" & vbCrLf
            Sql &= ",[SEG_DEUDA]" & vbCrLf
            Sql &= ",[SEG_DEUDA_D]" & vbCrLf
            Sql &= ",[CUOTA]" & vbCrLf
            Sql &= ",[CUOTA_D]" & vbCrLf
            Sql &= ",[SALDO_FIN]" & vbCrLf
            Sql &= ",[INTERES_ACUM]" & vbCrLf
            Sql &= ",[REPROGRAMADA]" & vbCrLf
            Sql &= ",[CUOTA_NO_DESCONTADA]" & vbCrLf
            Sql &= ",[USUARIO_CREACION]" & vbCrLf
            Sql &= ",[USUARIO_CREACION_FECHA]" & vbCrLf
            Sql &= ",[USUARIO_EDICION]" & vbCrLf
            Sql &= ",[USUARIO_EDICION_FECHA])" & vbCrLf
            Sql &= "VALUES" & vbCrLf
            Sql &= "(" & Compañia & vbCrLf
            Sql &= "," & numSol & vbCrLf 'NUMERO_SOLICITUD
            Sql &= "," & Linea & vbCrLf 'LINEA
            Sql &= ",0" & vbCrLf 'ENVIADA
            Sql &= ",0" & vbCrLf 'RECIBIDA
            Sql &= ",'" & Format(fechaPago, "dd/MM/yyyy") & "'" & vbCrLf 'FECHA_PAGO
            Sql &= "," & Valor & vbCrLf 'SALDO_INI
            Sql &= "," & Valor & vbCrLf 'CAPITAL
            Sql &= ",0" & vbCrLf 'CAPITAL_D
            Sql &= ",0" & vbCrLf 'INTERES
            Sql &= ",0" & vbCrLf 'INTERES_D
            Sql &= ",0" & vbCrLf 'SEG_DEUDA
            Sql &= ",0" & vbCrLf 'SEG_DEUDA
            Sql &= "," & Valor & vbCrLf 'CUOTA
            Sql &= ",0" & vbCrLf 'CUOTA_D
            Sql &= ",0" & vbCrLf 'SALDO_FIN
            Sql &= ",0" & vbCrLf 'INTERES_ACUM
            Sql &= ",0" & vbCrLf 'REPROGRAMADA
            Sql &= ",0" & vbCrLf 'CUOTA_NO_DESCONTADA
            Sql &= ",'" & Usuario & "'" & vbCrLf 'USUARIO_CREACION
            Sql &= ",'" & Format(Now(), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",'" & Usuario & "'" & vbCrLf
            Sql &= ",'" & Format(Now(), "dd/MM/yyyy") & "')"
            jClass.Ejecutar_ConsultaSQL(Sql)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Insertar Detalle")
        End Try
    End Sub

    Private Sub CreaRegistroRetiro(ByVal CodBuxis As Integer, ByVal CodAS As String)
        Try
            Dim A_Pagar, TotDeudas, AhorroOrd, AhorroExt As Double
            Dim bancoSocio As Integer = jClass.obtenerEscalar("SELECT BANCO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodBuxis)
            Dim TablaSaldosFinales As DataTable
            Sql = "SELECT [AHORRO ORDINARIO], [AHORRO EXTRAORDINARIO], [Monto por Saldar] FROM VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodBuxis
            sqlCmd.CommandText = Sql
            TablaSaldosFinales = jClass.obtenerDatos(sqlCmd)
            AhorroOrd = TablaSaldosFinales.Rows(0).Item(0)
            AhorroExt = TablaSaldosFinales.Rows(0).Item(1)
            TotDeudas = TablaSaldosFinales.Rows(0).Item(2)
            A_Pagar = AhorroOrd + AhorroExt - TotDeudas
            If A_Pagar > 0 Then
                Sql = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS"
                Sql &= "  @RETIRO = 0"
                Sql &= ", @COMPAÑIA = " & Compañia
                Sql &= ", @BANCO = " & bancoSocio
                Sql &= ", @TIPO_DOCUMENTO = " & IIf(bancoSocio = 0, "6", "3")
                Sql &= ", @CUENTA = '" & jClass.obtenerEscalar("SELECT CUENTA_BANCARIA FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodBuxis) & "'"
                Sql &= ", @CODIGO_EMPLEADO = " & CodBuxis
                Sql &= ", @CODIGO_EMPLEADO_AS = '" & CodAS & "'"
                Sql &= ", @CANTIDAD = " & A_Pagar
                Sql &= ", @ESTADO = 1"
                Sql &= ", @USUARIO = '" & Usuario & "'"
                Sql &= ", @FECHA = '" & Format(Now, "dd/MM/yyyy") & "'"
                Sql &= ", @SIUD = 'I'"
                Sql &= ", @FECHA_DESDE = '" & Format(Now, "dd/MM/yyyy") & "'"
                Sql &= ", @FECHA_HASTA = '" & Format(Now, "dd/MM/yyyy") & "'"
                Sql &= ", @TOTAL_INTERESES = 0"
                Sql &= ", @TOTAL_SEGURODEUDA = 0"
                Sql &= ", @TOTAL_DEUDAS = " & TotDeudas
                Sql &= ", @TOTAL_AHORROS_ORD = " & AhorroOrd
                Sql &= ", @TOTAL_AHORROS_EXT = " & AhorroExt
                Sql &= ", @RETIRO_ASOC = 1"
                Sql &= ", @PORCENTAJE_ESCOLARIDAD = 0"
                Sql &= ", @TOTAL_ESCOLARIDAD = 0"
                Sql &= ", @PORCENTAJE_RENTA = 0"
                Sql &= ", @TOTAL_RENTA = 0"
                Sql &= ", @COMENTARIO = 'POR INDEMNIZACION'"
                sqlCmd.CommandText = Sql
                jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Recibir Buxis")
        End Try
    End Sub

    Private Sub NoDescontadas(ByVal MyTable As DataTable)
        Dim NSol As Integer = 0
        For Each row As System.Data.DataRow In MyTable.Rows
            If NSol <> row.Item(3) Then
                If CDate(row.Item(0)).Day > 12 Then
                    ReprogramarCuotas(CDate(row.Item(0)), row.Item(3), row.Item("LINEA"), row.Item("Codigo Buxis"))
                End If
            Else
                If row.Item(1) = 523 Or row.Item(1) = 524 Or row.Item(1) = 566 Or row.Item(1) = 567 Then
                    ReprogramarCuotas(CDate(row.Item(0)), row.Item(3), row.Item("LINEA"), row.Item("Codigo Buxis"))
                End If
            End If
            NSol = row.Item(3)
            bw1.ReportProgress(1)
        Next
    End Sub

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        NoDescontadas(e.Argument)
    End Sub

    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        Try
            Me.pbAplicar.Value += e.ProgressPercentage
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        'Se deshabilita la creación de partida hasta nuevo aviso
        'PartidasContables()
        ProcesadoFinalizado()
    End Sub

    Private Sub ProcesadoFinalizado()
        Sql = "INSERT INTO [dbo].[COOPERATIVA_SOLICITUDES_CON_PARTIDAS]" & vbCrLf
        Sql &= "           ([COMPAÑIA]" & vbCrLf
        Sql &= "           ,[SOLICITUD]" & vbCrLf
        Sql &= "           ,[DESCRICPCION]" & vbCrLf
        Sql &= "           ,[USUARIO_CREACION]" & vbCrLf
        Sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
        Sql &= "           ,[USUARIO_EDICION]" & vbCrLf
        Sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
        Sql &= "        VALUES" & vbCrLf
        Sql &= "           (" & Compañia & vbCrLf
        Sql &= "           ," & Format(Me.dpFechaPago.Value, "yyyyMMdd") & IIf(Me.rbQna.Checked, "01", "02") & vbCrLf
        Sql &= "           ,'DESCUENTOS DEL " & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= "           ,'" & Usuario & "'" & vbCrLf
        Sql &= "           ,GETDATE()" & vbCrLf
        Sql &= "           ,'buxis'" & vbCrLf
        Sql &= "           ,GETDATE())"
        sqlCmd.CommandText = Sql
        jClass.ejecutarComandoSql(sqlCmd)
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Recepción desde Buxis")
        Me.pbAplicar.Visible = False
        Me.Label2.Visible = False
        Me.Label2.Text = "Procesando..."
        Me.btnProcesar.Enabled = True
    End Sub

    Private Function eliminaProgramacionesNoDescontadas(ByVal solicitud As String) As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Dim Retorno As Integer = 0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @NUM_SOLICITUD = " & solicitud & "," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @IUD = 'E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Retorno = Comando_Track.ExecuteScalar()
            Comando_Track.CommandText = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET COMENTARIO_ANULADA = 'CANCELADO POR RETIRO EMPRESA' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Retorno
    End Function
End Class