Imports System.Data.SqlClient

Public Class frmReportes_Ver
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Sql As String
    Dim Table As DataTable

    Private Sub frmReportes_Ver_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Public Sub ReportesGenericos(ByVal Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Try
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Reportes Genericos")
        End Try
    End Sub

    Public Sub RepActivoFijoMovimientosBienes(ByVal Compañia, ByVal _id_mov)
        Dim Rpt As New Contabilidad_Activo_Fijo_Ficha_Movimiento_Bien
        Try
            Sql = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA='rep_movimiento', @COMPAÑIA=" & Compañia & ", @BIEN_MOVIMIENTO=" & _id_mov
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("No existen datos para mostrar", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RepActivoFijoFicha(ByVal Compañia, ByVal _id)
        Dim Rpt As New Contabilidad_Activo_Fijo_Ficha_Movimiento_Bien
        Try
            Sql = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA='rep_ficha_bie', @COMPAÑIA=" & Compañia & ", @BIEN=" & _id
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("No existen datos para mostrar", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RepActivoFijoListado(ByVal Compañia, ByVal _alta, ByVal _baja_total)
        Dim Rpt As New Contabilidad_Activo_Fijo_Listado
        Try
            Sql = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA='rep_listados', @COMPAÑIA=" & Compañia & ", @ALTA=" & _alta & ", @BAJA_TOTAL=" & _baja_total
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("No existen datos para mostrar", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub


    Public Sub CargaPartida(ByVal Compañia, ByVal Libro, ByVal TransaccionIni, ByVal TransaccionFin, ByVal Año, ByVal Mes, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim Rpt As New Contabilidad_Partida_Contable
        Try
            Conexion_.Open()
            Sql = "SELECT E.PARTIDA," & vbCrLf
            Sql &= "       D.FECHA_TRAN," & vbCrLf
            Sql &= "	   C.CUENTA_COMPLETA," & vbCrLf
            Sql &= "	   D.COD_DETALLE," & vbCrLf
            Sql &= "	   C.DESCRIPCION_CUENTA," & vbCrLf
            Sql &= "	   D.CONCEPTO AS CONCEPTOD," & vbCrLf
            Sql &= "	   D.CARGOS," & vbCrLf
            Sql &= "	   D.ABONOS," & vbCrLf
            Sql &= "	   E.CONCEPTO AS CONCEPTOE," & vbCrLf
            Sql &= "	   E.TIPO_PARTIDA," & vbCrLf
            Sql &= "	   E.DOCUMENTO," & vbCrLf
            Sql &= "	   T.DESCRIPCION_TIPO_PARTIDA," & vbCrLf
            Sql &= "	   (SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = " & Compañia & ") AS EMPRESA," & vbCrLf
            Sql &= "	   E.USUARIO_CREACION," & vbCrLf
            Sql &= "	   E.USUARIO_CREACION_FECHA," & vbCrLf
            Sql &= "	   E.USUARIO_EDICION," & vbCrLf
            Sql &= "       E.USUARIO_EDICION_FECHA," & vbCrLf
            Sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,4) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL1,"
            Sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,6) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL2,"
            Sql &= "       (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,8) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL3,"
            Sql &= "       E.PROCESADO," & vbCrLf
            Sql &= "       CASE D.ABONOS WHEN 0 THEN 'A-CARGOS' ELSE 'B-ABONOS' END AS ORDEN" & vbCrLf
            Sql &= "  FROM [dbo].[CONTABILIDAD_PARTIDAS_ENCABEZADO] E," & vbCrLf
            Sql &= "       [dbo].[CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO] D," & vbCrLf
            Sql &= "	   [dbo].[CONTABILIDAD_CATALOGO_CUENTAS] C," & vbCrLf
            Sql &= "       [dbo].[CONTABILIDAD_CATALOGO_TIPO_PARTIDA] T" & vbCrLf
            Sql &= " WHERE E.COMPAÑIA = D.COMPAÑIA And E.TRANSACCION = D.TRANSACCION" & vbCrLf
            Sql &= "   AND E.COMPAÑIA = T.COMPAÑIA AND E.TIPO_PARTIDA = T.TIPO_PARTIDA" & vbCrLf
            Sql &= "   AND D.COMPAÑIA = C.COMPAÑIA AND D.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
            Sql &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND E.TRANSACCION >= " & TransaccionIni & vbCrLf
            Sql &= "   AND E.TRANSACCION <= " & TransaccionFin & vbCrLf
            Sql &= "   AND C.LIBRO_CONTABLE = " & Libro
            Me.chkNoDet.Visible = True
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        Conexion_.Close()
    End Sub

    Public Sub CargaPartidaIN(ByVal Libro As Integer, ByVal Transacciones As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim Rpt As New Contabilidad_Partida_Contable
        Try
            Conexion_.Open()
            Sql = "SELECT E.PARTIDA," & vbCrLf
            Sql &= "       D.FECHA_TRAN," & vbCrLf
            Sql &= "	   C.CUENTA_COMPLETA," & vbCrLf
            Sql &= "	   D.COD_DETALLE," & vbCrLf
            Sql &= "	   C.DESCRIPCION_CUENTA," & vbCrLf
            Sql &= "	   D.CONCEPTO AS CONCEPTOD," & vbCrLf
            Sql &= "	   D.CARGOS," & vbCrLf
            Sql &= "	   D.ABONOS," & vbCrLf
            Sql &= "	   E.CONCEPTO AS CONCEPTOE," & vbCrLf
            Sql &= "	   E.TIPO_PARTIDA," & vbCrLf
            Sql &= "	   E.DOCUMENTO," & vbCrLf
            Sql &= "	   T.DESCRIPCION_TIPO_PARTIDA," & vbCrLf
            Sql &= "	   (SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = " & Compañia & ") AS EMPRESA," & vbCrLf
            Sql &= "	   E.USUARIO_CREACION," & vbCrLf
            Sql &= "	   E.USUARIO_CREACION_FECHA," & vbCrLf
            Sql &= "	   E.USUARIO_EDICION," & vbCrLf
            Sql &= "       E.USUARIO_EDICION_FECHA," & vbCrLf
            Sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,4) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL1,"
            Sql &= "	   (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,6) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL2,"
            Sql &= "       (SELECT TOP 1 DESCRIPCION_CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_COMPLETA = SUBSTRING(C.CUENTA_COMPLETA,1,8) AND C.LIBRO_CONTABLE = " & Libro & ") AS CTANIVEL3,"
            Sql &= "       E.PROCESADO," & vbCrLf
            Sql &= "       CASE D.ABONOS WHEN 0 THEN 'A-CARGOS' ELSE 'B-ABONOS' END AS ORDEN" & vbCrLf
            Sql &= "  FROM [dbo].[CONTABILIDAD_PARTIDAS_ENCABEZADO] E," & vbCrLf
            Sql &= "       [dbo].[CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO] D," & vbCrLf
            Sql &= "	   [dbo].[CONTABILIDAD_CATALOGO_CUENTAS] C," & vbCrLf
            Sql &= "       [dbo].[CONTABILIDAD_CATALOGO_TIPO_PARTIDA] T" & vbCrLf
            Sql &= " WHERE E.COMPAÑIA = D.COMPAÑIA And E.TRANSACCION = D.TRANSACCION" & vbCrLf
            Sql &= "   AND E.COMPAÑIA = T.COMPAÑIA AND E.TIPO_PARTIDA = T.TIPO_PARTIDA" & vbCrLf
            Sql &= "   AND D.COMPAÑIA = C.COMPAÑIA AND D.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
            Sql &= "   AND E.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND E.TRANSACCION IN (" & Transacciones & ")" & vbCrLf
            Sql &= "   AND C.LIBRO_CONTABLE = " & Libro
            Me.chkNoDet.Visible = True
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        Conexion_.Close()
    End Sub

    Public Sub CargaReporteResultadosMes(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal FechaR)
        Dim Rpt As New Contabilidad_Reportes_Resultados_Mes_RPT
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_RESULTADOS_MES "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & Libro2
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaReporteIngresosAnuales(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal Reporte, ByVal FechaR)
        Dim Rpt As New Contabilidad_Reportes_Ingresos_Anuales_RPT
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_INGRESOS_ANUALES "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & Libro2
            Sql &= ", " & Reporte
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaReporteAcumuladosCostos(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal Reporte, ByVal FechaR)
        Dim Rpt As New Contabilidad_Reportes_Acumulados_Costos_RPT
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_INGRESOS_ANUALES "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & Libro2
            Sql &= ", " & Reporte
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaLibrosLegales(ByVal Compañia, ByVal Libro, ByVal CtaMayor, ByVal FechaR)
        Dim Rpt As New Contabilidad_Reportes_Libros_Legales_Rpt
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_LIBROS_LEGALES_RPT "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & CtaMayor
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Sub CargaReporteAuxiliarContable(ByVal Compañia, ByVal Libro, ByVal CuentaI, ByVal CuentaF, ByVal FechaI, ByVal FechaF)
        Dim Rpt As New Contabilidad_Reportes_Auxiliar_Cuentas_RPT
        Try
            Sql = "Execute dbo.sp_CONTABILIDAD_REPORTES_AUXILIAR_CUENTAS "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @LIBRO = " & Libro
            Sql &= ", @CUENTAI = '" & CuentaI & "'"
            Sql &= ", @CUENTAF = '" & CuentaF & "'"
            Sql &= ", @FECHAI = '" & FechaI & "'"
            Sql &= ", @FECHAF = '" & FechaF & "'"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaBalanceComprobación(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal FechaR, ByVal Reporte)
        Dim Rpt As New Contabilidad_Reportes_Balance_Comprobacion_RPT
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_BALANCE_COMPROBACION_RPT "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & Libro2
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            Sql &= ", " & Reporte
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaBalanceGeneral(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal FechaR, ByVal Reporte)
        Dim Rpt As New Contabilidad_Reportes_Balance_General_RPT
        Try
            Sql = "Execute sp_CONTABILIDAD_REPORTES_BALANCE_COMPROBACION_RPT "
            Sql &= Compañia
            Sql &= ", " & Libro
            Sql &= ", " & Libro2
            Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
            Sql &= ", " & Reporte
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub chkNoDet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoDet.CheckedChanged
        Dim ElReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument = Me.crvReporte.ReportSource
        ElReporte.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = chkNoDet.Checked
        ElReporte.ReportDefinition.Sections("GroupFooterSection1").SectionFormat.EnableSuppress = chkNoDet.Checked
        Me.crvReporte.ReportSource = ElReporte
    End Sub

    Public Sub ReportesActivoFijo(ByVal _hasta, ByVal _tipo, ByVal _aplica, ByVal _totbaja, ByVal _codigos, ByVal _ubicacion)
        If _aplica = 3 Then
            _aplica = "NULL"
        End If
        Dim rpt As New Contabilidad_Activo_Fijo_Depreciaciones_Financiera_Fiscal
        Sql = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_REPORTES_VARIOS @COMPAÑIA=" & Compañia & ", @FECHA_CONSULTA= '" & _hasta & "', @BANDERA=1, @TIPO= '" & _tipo & "', @APLICAR_DEPRECIACION= " & _aplica & ", @BAJA_TOTAL= " & _totbaja & ", @CODIGOS='" & _codigos & "'"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Public Sub ReportesActivoFijoAdquisicion(ByVal _desde, ByVal _hasta, ByVal _tipo, ByVal _aplica, ByVal _totbaja, ByVal _codigos, ByVal _ubicacion)
        If _aplica = 3 Then
            _aplica = "NULL"
        End If
        Dim rpt As New Contabilidad_Activo_Fijo_Depreciaciones_Rango_Fecha
        Sql = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_REPORTES_VARIOS @COMPAÑIA=" & Compañia & ", @FECHA_DESDE='" & _desde & "', @FECHA_CONSULTA= '" & _hasta & "', @BANDERA=2, @TIPO= '" & _tipo & "', @APLICAR_DEPRECIACION= " & _aplica & ", @BAJA_TOTAL= " & _totbaja & ", @CODIGOS='" & _codigos & "'"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Public Sub ReportesActivoFijoBajas(ByVal _desde, ByVal _hasta, ByVal _tipo, ByVal _aplica, ByVal _totbaja, ByVal _codigos, ByVal _ubicacion)
        If _aplica = 3 Then
            _aplica = "NULL"
        End If
        Dim rpt As New Contabilidad_Activo_Fijo_Depreciaciones_Bajas
        Sql = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_REPORTES_VARIOS @COMPAÑIA=" & Compañia & ", @FECHA_DESDE='" & _desde & "', @FECHA_CONSULTA= '" & _hasta & "', @BANDERA=3, @TIPO= '" & _tipo & "', @APLICAR_DEPRECIACION= " & _aplica & ", @BAJA_TOTAL= " & _totbaja & ", @CODIGOS='" & _codigos & "'"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Public Sub ReportesActivoFijoComparativos(ByVal _hasta, ByVal _codigos)
        Dim rpt As New Contabilidad_Activo_Fijo_Comparativo
        Sql = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_REPORTES_VARIOS @COMPAÑIA=" & Compañia & ", @FECHA_CONSULTA= '" & _hasta & "', @BANDERA=4, @TIPO_BIEN='" & _codigos & "'"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Public Sub ReportesActivoFijoTomaFisica(ByVal _fecha, ByVal _codigos)
        Dim rpt As New Contabilidad_Activo_Fijo_Toma_Fisica
        Sql = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_REPORTES_VARIOS @COMPAÑIA=" & Compañia & ", @BANDERA=5, @FECHA_CONSULTA= '" & _fecha & "', @CODIGOS='" & _codigos & "'"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Public Sub RepActivoFijoFichaActualizacion(ByVal Compañia, ByVal _id)
        'Dim Rpt As New Contabilidad_Activo_Fijo_Ficha_DetalleMov
        'Try
        '    sqlCmd.CommandText = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_REP_FICHA @BANDERA='ficha', @COMPAÑIA=" & Compañia & ", @BIEN=" & _id
        '    Table = jClass.obtenerDatos(sqlCmd)
        '    If Table.Rows.Count > 0 Then
        '        Rpt.SetDataSource(Table)

        '        Dim Table2 As New DataTable()
        '        sqlCmd.CommandText = "Execute SP_CONTABILIDAD_ACTIVO_FIJO_REP_FICHA @BANDERA='cuentas', @COMPAÑIA=" & Compañia & ", @BIEN=" & _id

        '        Table2 = jClass.obtenerDatos(sqlCmd)
        '        Rpt.Subreports.Item(0).SetDataSource(Table2)

        '        Me.crvReporte.ReportSource = Rpt
        '    Else
        '        MsgBox("No existen datos para mostrar", MsgBoxStyle.Exclamation, "AVISO")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        'End Try
    End Sub
End Class