Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReportes_Ver
    Dim Sql As String
    Dim c_data1 As New jarsClass
    Dim DataAdapter_ As New SqlDataAdapter
    Dim reporte As New Inventario_Catalogo_Productos_RPT
    Dim reporte_1 As New Inventario_Reporte_Existencias_RPT
    Dim reporte_2 As New Inventario_Reporte_Entradas_Salidas_RPT
    Dim reporte_3 As New Inventario_Reporte_Ajustes_RPT
    Dim reporte_4 As New Inventario_Reporte_Antiguedad_RPT
    Dim reporte_5 As New Cafeteria_Reporte_Compra_RPT
    'Dim reporte_6 As Clinica_Catalogo_Requerimiento_Aprobacion_RPT
    'Dim reporte_7 As Clinica_Catalogo_Citas_RPT
    'Dim reporte_8 As Clinica_Catalogo_Incapacidades
    Dim reporte_9 As New Inventario_Reporte_Toma_Fisico_RPT
    Dim reporte_22 As New Inventario_Reporte_Toma_Fisico_Existencias
    Dim reporte_10 As New Inventario_Compras_Recibir_rpt
    'Dim reporte_12 As CooperativaReporteDividendosSocios
    'Dim reporte_13 As CooperativaReporteDividendosPorSocio
    'Dim reporte_20 As Contabilidad_Conciliacion_Bancaria_Rpt
    Dim reporte_30 As New Inventario_Reporte_Transferencias
    Dim DS20 As New DataSet() 'Conciliaciones_Bancarias_Source
    Dim DS As New DataSet()
    Dim ban As Integer = 0
    Dim Exi As Integer = 0
    Dim Docto As Integer = 0
    Dim compañia_1 As Integer, bodega_1 As Integer = 0, bodega_2 As Integer, bander As Integer, bandera_1 As Integer, tipo_mov_1 As Integer = 0, in_out_1 As Integer = 0
    Dim CodigoRPT As Integer, Orden_Compra As Integer, monto_1 As String, porcentaje_1 As String, tiempo1 As String = 0, DoctoCCF As String, A_Grabar As Integer = 0
    Dim grupo1 As Integer = 0, subgrupo1 As Integer = 0
    Dim fecha_1 As Date = Date.Now, fecha_2 As Date = Date.Now
    Dim codigoBodega1 As Integer
    'Conciliacion Bancaria
    Dim consultaConciliacion As String

    'Dim reporte_21 As Clinica_Detalle_Radiografia

    'PARA REPORTE DE HOJA DE TRABAJO DE LA CLINICA DENTAL
    Dim CompañiaDeFiador As Integer
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal bandera As Integer, ByVal consultaConciliacionBanc As String)
        ' 2 Param
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.bandera_1 = bandera 'bandera es 20

        Me.consultaConciliacion = consultaConciliacionBanc
        'reporte_20 = New Contabilidad_Conciliacion_Bancaria_Rpt
        'DS20 = New Conciliaciones_Bancarias_Source

    End Sub

    Public Sub New(ByVal bandera As Integer, ByVal codigoRTP As Integer, Optional ByVal CompañiaFiador As Integer = 0)
        ' 2 ó 3 Param
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.bandera_1 = bandera
        Me.CodigoRPT = codigoRTP

        'Select Case bandera_1
        '    Case 8
        '        reporte_6 = New Clinica_Catalogo_Requerimiento_Aprobacion_RPT
        '        CompañiaDeFiador = CompañiaFiador
        '    Case 9
        '        reporte_7 = New Clinica_Catalogo_Citas_RPT
        '    Case 10
        '        reporte_8 = New Clinica_Catalogo_Incapacidades
        '    Case 21
        '        reporte_21 = New Clinica_Detalle_Radiografia

        'End Select

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal compañia, ByVal bodega, ByVal bandera)
        ' 3 Param
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        Orden_Compra = bodega
        bandera_1 = bandera
    End Sub
    Public Sub New(ByVal compañia, ByVal fecha1, ByVal fecha2, ByVal bandera)
        ' 4 Param
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bandera_1 = bandera
        fecha_1 = fecha1
        fecha_2 = fecha2

    End Sub
    Public Sub New(ByVal compañia, ByVal bodega, ByVal fecha1, ByVal fecha2, ByVal bandera)
        ' 5 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        bandera_1 = bandera
        fecha_1 = fecha1
        fecha_2 = fecha2
    End Sub

    Public Sub New(ByVal compañia As Integer, ByVal bodega As Integer, ByVal fecha1 As String, ByVal fecha2 As String, ByVal bandera As Integer, ByVal tiempo As Integer)
        ' 6 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        bandera_1 = bandera
        fecha_1 = fecha1
        fecha_2 = fecha2
        tiempo1 = tiempo
    End Sub
    Public Sub New(ByVal compañia As Integer, ByVal bodega As Integer, ByVal fecha1 As String, ByVal bandera As Integer, Optional ByVal nada As Integer = 0, Optional ByVal nada1 As Integer = 0)
        ' 6 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        fecha_1 = fecha1
        bandera_1 = bandera
    End Sub
    Public Sub New(ByVal compañia, ByVal bodega, ByVal tipo_mov, ByVal entrada_salida, ByVal fecha1, ByVal fecha2, ByVal bandera)
        ' 7 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        bandera_1 = bandera
        tipo_mov_1 = tipo_mov
        in_out_1 = entrada_salida
        fecha_1 = fecha1
        fecha_2 = fecha2
    End Sub
    Public Sub New(ByVal compañia, ByVal bodega, ByVal fecha1, ByVal bandera, ByVal nada, ByVal nada1, ByVal nada2, ByVal SoloCon)
        ' 8 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        fecha_1 = fecha1
        bandera_1 = bandera
        Exi = IIf(SoloCon = True, 1, 0)
        If bandera = 11 Then
            bander = 1
            bandera_1 = 3
        Else
            bander = bandera
        End If
    End Sub
    Public Sub New(ByVal compañia, ByVal bodega, ByVal tipo_mov, ByVal entrada_salida, ByVal fecha1, ByVal fecha2, ByVal bandera, ByVal Bodega2, ByVal Docto)
        ' 9 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        bodega_2 = Bodega2
        bandera_1 = bandera
        tipo_mov_1 = tipo_mov
        in_out_1 = entrada_salida
        fecha_1 = fecha1
        fecha_2 = fecha2
        DoctoCCF = Docto
    End Sub
    Public Sub New(ByVal compañia, ByVal bodega, ByVal fecha1, ByVal bandera, ByVal nada, ByVal nada1, ByVal nada2, ByVal SoloCon, ByVal grupo, ByVal subgrupo)
        ' 10 Parametros
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        compañia_1 = compañia
        bodega_1 = bodega
        fecha_1 = fecha1
        bandera_1 = bandera
        grupo1 = grupo
        subgrupo1 = subgrupo
        Exi = IIf(SoloCon = True, 1, 0)
        
        If bandera = 11 Then
            bander = 1
            bandera_1 = 3
        ElseIf bandera = 52 Then
            bander = 2
            bandera_1 = 3
        Else
        bander = bandera
        End If
    End Sub

    Private Sub frmReportes_Ver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)

        'Le indicamos al BackgroundWorker que puede reportar progresos
        Bw1.WorkerReportsProgress = True
        'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
        Bw1.WorkerSupportsCancellation = True
        'Iniciamos el proceso pesado
        Bw1.RunWorkerAsync()

    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        Comando_Track.CommandTimeout = 7200
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Public Sub CargaPartida(ByVal Compañia, ByVal Libro, ByVal TransaccionIni, ByVal TransaccionFin, ByVal Año, ByVal Mes, ByVal Bandera)
        Dim Table As DataTable
        Dim Rpt As New Contabilidad_Partida_Contable
        Try
            'Sql = "Execute sp_CONTABILIDAD_PARTIDAS_RPT "
            'Sql &= Compañia
            'Sql &= ", " & Libro
            'Sql &= ", " & TransaccionIni
            'Sql &= ", " & TransaccionFin
            'Sql &= ", " & Año
            'Sql &= ", " & Mes
            'Sql &= ", " & Bandera
            'Sql &= ", '" & Usuario & "'"
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
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    'Public Sub CargaBalanceComprobación(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal FechaR, ByVal Reporte)
    '    Dim Rpt As New Contabilidad_Reportes_Balance_Comprobacion_RPT
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_BALANCE_COMPROBACION_RPT "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro
    '        Sql &= ", " & Libro2
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        Sql &= ", " & Reporte
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub
    'Public Sub CargaReporteResultadosMes(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal FechaR)
    '    Dim Rpt As New Contabilidad_Reportes_Resultados_Mes_RPT
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_RESULTADOS_MES "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro
    '        Sql &= ", " & Libro2
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    '    CloseConnection()
    'End Sub
    'Public Sub CargaReporteIngresosAnuales(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal Reporte, ByVal FechaR)
    '    Dim Rpt As New Contabilidad_Reportes_Ingresos_Anuales_RPT
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_INGRESOS_ANUALES "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro
    '        Sql &= ", " & Libro2
    '        Sql &= ", " & Reporte
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    '    CloseConnection()
    'End Sub

    Public Sub CargaCatalogoEmpleados(ByVal Compañia, ByVal Bandera, ByVal Firma)
        Dim Rpt As New Cooperativa_Reportes_Socios_No_RPT
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
            Sql &= Compañia
            Sql &= ", " & 1
            Sql &= ", " & 9999999
            Sql &= ", " & Bandera
            Sql &= ", " & Firma
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub

    'Public Sub Recetas_Medicas(ByVal NombrePaciente, ByVal Tratamiento, ByVal Fecha)
    '    Dim Rpt As New Clinica_Reporte_Receta_Medica
    '    Dim Sql As SqlCommand = New SqlCommand("SELECT '" & NombrePaciente & "' AS Nombre, '" & Tratamiento & "' AS Tratamiento, '" & Format(Fecha, "dd/MM/yyyy 00:00:01") & "' AS Fecha")
    '    Dim DS01 As DataTable = c_data1.obtenerDatos(Sql)
    '    Rpt.SetDataSource(DS01)
    '    Me.crvReporte.ReportSource = Rpt
    'End Sub

    Public Sub Dividendos_Socios_Global(ByVal Compañia, ByVal Fecha1, ByVal Fecha2, ByVal Monto, ByVal Porcenta, ByVal Bandera)
        Dim Rpt As New CooperativaReporteDividendosSociosGlobal
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "EXECUTE sp_COOPERATIVA_REPORTE_DIVIDENDOS_SOCIOS "
            Sql &= "  @COMPAÑIA=" & Compañia
            Sql &= ", @FECHA1='" & Format(Fecha1, "dd/MM/yyyy") & "'"
            Sql &= ", @FECHA2='" & Format(Fecha2, "dd/MM/yyyy") & "'"
            Sql &= ", @MONTO_TOTAL=" & Monto
            Sql &= ", @PORCENTAJE=" & Porcenta
            Sql &= ", @BANDERA=" & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    Public Sub Dividendos_Socios(ByVal Compañia, ByVal Bandera)
        Dim Rpt As New CooperativaReporteDividendosSocios
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "EXECUTE sp_COOPERATIVA_REPORTE_DIVIDENDOS_SOCIOS "
            Sql &= "  @COMPAÑIA=" & Compañia
            Sql &= ", @BANDERA=" & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    Public Sub Dividendos_Socios_Renta(ByVal Compañia, ByVal Bandera)
        Dim Rpt As New CooperativaReporteDividendosSociosRenta
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "EXECUTE sp_COOPERATIVA_REPORTE_DIVIDENDOS_SOCIOS_II "  'Calculo de la Renta.
            Sql &= "  @COMPAÑIA=" & Compañia
            Sql &= ", @BANDERA=" & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    Public Sub Dividendos_Socios_Renta_Global(ByVal Compañia, ByVal Bandera)
        Dim Rpt As New CooperativaReporteDividendosSociosRentaGlobal
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "EXECUTE sp_COOPERATIVA_REPORTE_DIVIDENDOS_SOCIOS_II "  'Calculo de la Renta.
            Sql &= "  @COMPAÑIA=" & Compañia
            Sql &= ", @BANDERA=" & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    Public Sub CargaCatalogo_x_Division(ByVal Compañia, ByVal Division, ByVal Firma, ByVal Bandera)
        Dim Rpt As New Cooperativa_Reportes_Catalogo_x_Division_RPT
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute dbo.sp_COOPERATIVA_REPORTE_CATALOGO_X_DIVISION "
            Sql &= Compañia
            Sql &= ", " & Division
            Sql &= ", " & Firma
            Sql &= ", " & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub

    'Public Sub CargaReporteAcumuladosCostos(ByVal Compañia, ByVal Libro, ByVal Libro2, ByVal Reporte, ByVal FechaR)
    '    Dim Rpt As New Contabilidad_Reportes_Acumulados_Costos_RPT
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_INGRESOS_ANUALES "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro
    '        Sql &= ", " & Libro2
    '        Sql &= ", " & Reporte
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    '    CloseConnection()
    'End Sub
    'Public Sub CargaPrestamos_Denegados(ByVal Compañia, ByVal FechaI, ByVal FechaF)
    '    Dim Rpt As New Cooperativa_Reporte_Prestamos_Devegado_Rpt
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute Coo.sp_COOPERATIVA_REPORTE_PRESTAMOS_DENEGADOS "
    '        Sql &= Compañia
    '        Sql &= ", '" & Format(FechaI, "dd/MM/yyyy 00:00:01") & "'"
    '        Sql &= ", '" & Format(FechaF, "dd/MM/yyyy 00:00:01") & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
    '    End Try
    'End Sub
    'Public Sub CargaEstadoResultados(ByVal Compañia, ByVal Libro1, ByVal Libro2, ByVal CuentaIni, ByVal CuentaFin, ByVal FechaR, ByVal Bandera)
    '    Dim Rpt As New Contabilidad_Reportes_Estado_Resultado_Rpt
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_ESTADO_RESULTADOS_RPT "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro1
    '        Sql &= ", " & Libro2
    '        Sql &= ", " & CuentaIni
    '        Sql &= ", " & CuentaFin
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        Sql &= ", " & Bandera
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub
    'Public Sub CargaLibrosLegales(ByVal Compañia, ByVal Libro, ByVal CtaMayor, ByVal FechaR)
    '    Dim Rpt As New Contabilidad_Reportes_Libros_Legales_Rpt
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_LIBROS_LEGALES_RPT "
    '        Sql &= Compañia
    '        Sql &= ", " & Libro
    '        Sql &= ", " & CtaMayor
    '        Sql &= ", '" & Format(FechaR, "dd/MM/yyyy") & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub
    'Sub GetReporteLibro_Compras(ByVal Compañia, ByVal Bodega, ByVal FechaI, ByVal FechaF, ByVal Consolida)
    '    Dim Rpt As New Contabilidad_Reporte_Libro_Compras_Rpt
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_LIBRO_COMPRAS "
    '        Sql &= "@COMPAÑIA = " & Compañia
    '        Sql &= ", @BODEGA = " & Bodega
    '        Sql &= ", @FEC_INI = '" & FechaI & "'"
    '        Sql &= ", @FEC_FIN = '" & FechaF & "'"
    '        Sql &= ", @CONSOLI = " & Consolida
    '        Sql &= ", @USUARIO = '" & Usuario & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub

    Public Sub CargaMenuRecetas(ByVal Compañias, ByVal Bodegas, ByVal Producto1, ByVal Producto2)
        Dim Rpt As New Cafeteria_Reportes_Catalogo_Menu_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTES_CATALOGO_MENU_RPT "
            Sql &= Compañias
            Sql &= ", " & Bodegas
            Sql &= ", " & Producto1
            Sql &= ", " & Producto2
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReportePreciosCafeteria(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo, ByVal Codigo, ByVal Cantidad, ByVal IUD)
        Dim Rpt As New Cafeteria_Reporte_Precios_Venta_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Codigo
            Sql &= ", " & Cantidad
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteProduccionDiaria(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo)
        Dim Rpt As New Cafeteria_Reporte_Produccion_Diaria_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTE_PROGRAMACION_DIARIA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteProduccionDiaria2(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo)
        Dim Rpt As New Cafeteria_Reporte_Produccion_Diaria_Rpt_Cocina
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTE_PROGRAMACION_DIARIA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteResumenProduccionDiaria(ByVal Compañia, ByVal Bodega, ByVal FechaI, ByVal FechaF, ByVal Tiempo)
        Dim Rpt As New Cafeteria_Reporte_Resumen_Produccion_Diaria_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTE_RESUMEN_PROGRAMACION_DIARIA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & FechaI & "'"
            Sql &= ", '" & FechaF & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteSimulador_Recetas(ByVal Compañia, ByVal Bodega, ByVal Producto, ByVal Cantidad, ByVal Porcenta)
        Dim Rpt As New Cafeteria_Reporte_Simulador_Receta_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTE_SIMULADOR_RECETA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Producto
            Sql &= ", " & Cantidad
            Sql &= ", " & Porcenta
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteCarteraSocios(ByVal Compañia, ByVal Fecha)
        Dim Rpt As New Cooperativa_Reporte_Cartera_Socios_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute Coo.sp_COOPERATIVA_REPORTE_CARTERA_SOCIOS "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @FECHA = '" & Fecha & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteCarteraSociosDeduccion(ByVal Compañia, ByVal Fecha)
        Dim Rpt As New Cooperativa_Reporte_Cartera_Socios_DeduccionRpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute Coo.sp_COOPERATIVA_REPORTE_CARTERA_SOCIOS_I "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @FECHA = '" & Fecha & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteAhorrosSocios(ByVal Compañia, ByVal Fecha)
        Dim Rpt As New Cooperativa_Reporte_Ahorros_Socios_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute Coo.sp_COOPERATIVA_REPORTE_AHORROS_SOCIOS "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @FECHA = '" & Fecha & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    'Sub CargaReporteAuxiliarContable(ByVal Compañia, ByVal Libro, ByVal CuentaI, ByVal CuentaF, ByVal FechaI, ByVal FechaF)
    '    Dim Rpt As New Contabilidad_Reportes_Auxiliar_Cuentas_RPT
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute dbo.sp_CONTABILIDAD_REPORTES_AUXILIAR_CUENTAS "
    '        Sql &= "@COMPAÑIA = " & Compañia
    '        Sql &= ", @LIBRO = " & Libro
    '        Sql &= ", @CUENTAI = '" & CuentaI & "'"
    '        Sql &= ", @CUENTAF = '" & CuentaF & "'"
    '        Sql &= ", @FECHAI = '" & FechaI & "'"
    '        Sql &= ", @FECHAF = '" & FechaF & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub

    Sub GetReporteDetalleCortes(ByVal Compañia, ByVal Bodega, ByVal Caja, ByVal FechaI, ByVal FechaF, ByVal IUD)
        Dim Rpt As New Cafeteria_Reporte_Detalle_Corte_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_FACTURACION_SIUD "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @CAJA = " & Caja
            Sql &= ", @FEC_INI = '" & FechaI & "'"
            Sql &= ", @FEC_FIN = '" & FechaF & "'"
            Sql &= ", @BANDERA = '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Rpt.SetDataSource(DS01.Tables(0))
            Me.crvReporte.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteVentas_Cortes(ByVal Compañia, ByVal Bodega, ByVal FechaI, ByVal FechaF, ByVal IUD)
        Dim Rpt As New Cafeteria_Reporte_Corte_Diario_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_FACTURACION_SIUD "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @FEC_INI = '" & FechaI & "'"
            Sql &= ", @FEC_FIN = '" & FechaF & "'"
            Sql &= ", @BANDERA = '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Rpt.SetDataSource(DS01.Tables(0))
            Me.crvReporte.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReportePromedio_Semanal_Costo(ByVal Compañia, ByVal Bodega, ByVal FechaI, ByVal FechaF, ByVal IUD)
        Dim Rpt As New Cafeteria_Reporte_Promedio_Semanal_Costo_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_PROMEDIO_SEMANAL_COSTOS "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @FEC_INI = '" & FechaI & "'"
            Sql &= ", @FEC_FIN = '" & FechaF & "'"
            Sql &= ", @BANDERA = '" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))

                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteResumen_Promedio_Semanal_Costo(ByVal Compañia, ByVal Bodega, ByVal FechaI, ByVal FechaF, ByVal IUD)
        Dim Rpt As New Cafeteria_Reporte_Resumen_Promedio_Semanal_Costo_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_REPORTES_RESUMEN_PROMEDIO_SEMANAL_COSTOS "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @FEC_INI = '" & FechaI & "'"
            Sql &= ", @FEC_FIN = '" & FechaF & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaInventario_Kardex(ByVal Compañias, ByVal Bodegas, ByVal Producto1, ByVal Producto2, ByVal FechaI, ByVal FechaF)
        Dim Rpt As New Inventario_Reporte_Kardex_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_INVENTARIOS_REPORTES_KARDEX_RPT "
            Sql &= Compañias
            Sql &= ", " & Bodegas
            Sql &= ", " & Producto1
            Sql &= ", " & Producto2
            Sql &= ", '" & Format(FechaI, "dd/MM/yyyy") & "'"
            Sql &= ", '" & Format(FechaF, "dd/MM/yyyy") & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables.Count() > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaInventario_Kardex_x_Bodegas(ByVal Compañias, ByVal Bodega1, ByVal Bodega2, ByVal Fecha)
        Dim Rpt As New Inventario_Reporte_Kardex_x_Bodegas_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_INVENTARIOS_REPORTES_KARDEX_X_BODEGAS_RPT "
            Sql &= Compañias
            Sql &= ", " & Bodega1
            Sql &= ", " & Bodega2
            Sql &= ", '" & Format(Fecha, "dd/MM/yyyy") & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables.Count() > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaInventario_Movimiento_Productos_Costos_Cafeteria(ByVal Compañias, ByVal Bodega1, ByVal Bodega2, ByVal Fecha1, ByVal Fecha2)
        Dim Rpt As New Inventario_Reporte_Movimiento_Producto_Costos_Rpt_Cafeteria
        Try
            DS01.Reset()
            OpenConnection()
            
            Sql = "DECLARE @COMPAÑIA             AS INTEGER    = " & Compañia & ", " & vbCrLf
            Sql &= " @BODEGA_INI           AS INTEGER    = " & Bodega1 & "," & vbCrLf
            Sql &= " @BODEGA_FIN           AS INTEGER    = " & Bodega2 & "," & vbCrLf
            Sql &= " @FECHA_DESDE          AS DATE       = '" & Format(Fecha1, "dd/MM/yyyy") & "',    	" & vbCrLf
            Sql &= " @USUARIO              AS VARCHAR(12)= '" & Usuario & "'," & vbCrLf
            Sql &= " @FECHA_HASTA          AS DATE       = '" & Format(Fecha2, "dd/MM/yyyy") & "'    	" & vbCrLf
            Sql &= " DECLARE @DESCRIPCION_COMPAÑIA NVARCHAR(MAX)," & vbCrLf
            Sql &= " @PERIODO              NVARCHAR(MAX)," & vbCrLf
            Sql &= " @FECHA_INICIAL        AS DATE," & vbCrLf
            Sql &= " @FECHA                AS DATE," & vbCrLf
            Sql &= " @FECHA_MES_PASADO     AS DATE" & vbCrLf
            Sql &= " DECLARE @BODEGA               AS INTEGER," & vbCrLf
            Sql &= " @PRODUCTO             AS INTEGER," & vbCrLf
            Sql &= " @INICIANDO            AS BIT" & vbCrLf
            Sql &= " DECLARE @TABLA_1 AS TABLE (COMPAÑIA                  NVARCHAR(MAX), " & vbCrLf
            Sql &= " BODEGA                    INTEGER," & vbCrLf
            Sql &= " BODEGAD                   NVARCHAR(MAX)," & vbCrLf
            Sql &= " GRUPO                     INTEGER," & vbCrLf
            Sql &= " GRUPOD                    NVARCHAR(MAX)," & vbCrLf
            Sql &= " SUBGRUPO                  INTEGER," & vbCrLf
            Sql &= " SUBGRUPOD                 NVARCHAR(MAX)," & vbCrLf
            Sql &= " PRODUCTO                  INTEGER," & vbCrLf
            Sql &= " DESCRIPCION               NVARCHAR(MAX)," & vbCrLf
            Sql &= " MEDIDA                    NUMERIC(18,6)," & vbCrLf
            Sql &= " FECHA_HASTA               DATETIME," & vbCrLf
            Sql &= " TIPO_COSTO                NUMERIC(18,6)," & vbCrLf
            Sql &= " CANT_INV_INI              NUMERIC(18,6)," & vbCrLf
            Sql &= " UNIT_INV_INI              NUMERIC(18,6)," & vbCrLf
            Sql &= " COST_INV_INI              NUMERIC(18,6)," & vbCrLf
            Sql &= " CANT_INGRESO              NUMERIC(18,6)," & vbCrLf
            Sql &= " UNIT_INGRESO              NUMERIC(18,6)," & vbCrLf
            Sql &= " COST_INGRESO              NUMERIC(18,6)," & vbCrLf
            Sql &= " CANT_SALIDAS              NUMERIC(18,6)," & vbCrLf
            Sql &= " COST_SALIDAS              NUMERIC(18,6)," & vbCrLf
            Sql &= " CANT_DEVOLUC              NUMERIC(18,6)," & vbCrLf
            Sql &= " COST_DEVOLUC              NUMERIC(18,6)," & vbCrLf
            Sql &= " PERIODO                   NVARCHAR(MAX)," & vbCrLf
            Sql &= " IN_AJUS					 NUMERIC(18,6))" & vbCrLf
            Sql &= " SET @PERIODO = DBO.fn_INVENTARIOS_PERIODO_SEGUN_FECHA(CONVERT(nvarchar(10), @FECHA_DESDE, 103), " & vbCrLf
            Sql &= " CONVERT(nvarchar(10), @FECHA_HASTA, 103))" & vbCrLf
            Sql &= " SET @DESCRIPCION_COMPAÑIA = (SELECT NOMBRE_COMPAÑIA " & vbCrLf
            Sql &= " FROM CATALOGO_COMPAÑIAS" & vbCrLf
            Sql &= " WHERE COMPAÑIA = @COMPAÑIA) " & vbCrLf
            Sql &= " SET @FECHA_MES_PASADO =DBO.EOMONTH(DATEADD(MONTH, -1,@FECHA_DESDE))" & vbCrLf
            Sql &= " SET @FECHA_INICIAL = CONVERT(DATE, '01-' + CONVERT(NVARCHAR,MONTH( @FECHA_DESDE )) + '-' + CONVERT(NVARCHAR,YEAR ( @FECHA_DESDE )))" & vbCrLf
            Sql &= " SET @FECHA         = CASE DAY(@FECHA_DESDE) WHEN 1 THEN @FECHA_DESDE ELSE DATEADD(day,-1,@FECHA_DESDE) END" & vbCrLf
            Sql &= " SET @INICIANDO     = CASE DAY(@FECHA_DESDE) WHEN 1 " & vbCrLf
            Sql &= " THEN " & vbCrLf
            Sql &= " 1" & vbCrLf
            Sql &= " ELSE " & vbCrLf
            Sql &= " 0" & vbCrLf
            Sql &= " End" & vbCrLf

            Sql &= " SELECT BODEGA," & vbCrLf
            Sql &= " PRODUCTO," & vbCrLf
            Sql &= " FECHA_MOVIMIENTO," & vbCrLf
            Sql &= " TIPO_MOVIMIENTO," & vbCrLf
            Sql &= " ENTRADA_SALIDA," & vbCrLf
            Sql &= " CANTIDAD," & vbCrLf
            Sql &= " COSTO_UNITARIO," & vbCrLf
            Sql &= " COSTO_TOTAL" & vbCrLf
            Sql &= " INTO #DATOS" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE AS a" & vbCrLf
            Sql &= " WHERE a.COMPAÑIA  = @COMPAÑIA       AND" & vbCrLf
            Sql &= " (a.BODEGA BETWEEN @BODEGA_INI  AND @BODEGA_FIN) AND" & vbCrLf
            Sql &= " a.PROCESADO = 1               AND" & vbCrLf
            Sql &= " a.ANULADO   = 0               AND" & vbCrLf
            Sql &= " (CONVERT(DATE,a.FECHA_MOVIMIENTO) BETWEEN @FECHA_DESDE AND @FECHA_HASTA)" & vbCrLf
            Sql &= " ORDER BY BODEGA, PRODUCTO, FECHA_MOVIMIENTO" & vbCrLf

            Sql &= " SELECT PRODUCTO, SUM(COSTO_TOTAL) 'COSTO', SUM(CANTIDAD) 'CANTIDAD'" & vbCrLf
            Sql &= " INTO #DATOS1" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE" & vbCrLf
            Sql &= " WHERE MOVIMIENTO IN (SELECT MOVIMIENTO FROM CAFETERIA_FACTURACION_ENCABEZADO" & vbCrLf
            Sql &= " WHERE COMPAÑIA=@COMPAÑIA AND BODEGA=@BODEGA AND ANULADO=1 AND CONVERT(DATE,FECHA_FACTURA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and TIPO_DOCUMENTO=27)" & vbCrLf
            Sql &= " GROUP BY PRODUCTO" & vbCrLf

            Sql &= " DECLARE TEMPORAL CURSOR FOR" & vbCrLf
            Sql &= " SELECT	BODEGA,PRODUCTO  FROM INVENTARIOS_PRODUCTOS_BODEGAS AS c" & vbCrLf
            Sql &= " WHERE  c.COMPAÑIA = @COMPAÑIA        AND" & vbCrLf
            Sql &= " (c.BODEGA  BETWEEN @BODEGA_INI AND @BODEGA_FIN) AND" & vbCrLf
            Sql &= " (c.BODEGA IN (SELECT d.BODEGA FROM SEGURIDAD_CATALOGO_BODEGAS_USUARIOS d" & vbCrLf
            Sql &= " WHERE d.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " d.USUARIO  = @USUARIO))" & vbCrLf
            Sql &= " OPEN TEMPORAL" & vbCrLf
            Sql &= " FETCH NEXT FROM TEMPORAL" & vbCrLf
            Sql &= " INTO @BODEGA, @PRODUCTO" & vbCrLf
            Sql &= " WHILE @@FETCH_STATUS = 0" & vbCrLf
            Sql &= " BEGIN" & vbCrLf
            Sql &= " INSERT INTO @TABLA_1" & vbCrLf
            Sql &= " SELECT @DESCRIPCION_COMPAÑIA                      AS COMPAÑIA," & vbCrLf
            Sql &= " @BODEGA                                    AS BODEGA," & vbCrLf
            Sql &= " (SELECT TOP 1 DESCRIPCION_BODEGA " & vbCrLf
            Sql &= " FROM  INVENTARIOS_CATALOGO_BODEGAS z" & vbCrLf
            Sql &= " WHERE z.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " z.BODEGA   = @BODEGA)        AS BODEGAD," & vbCrLf
            Sql &= " (SELECT TOP 1   GRUPO" & vbCrLf
            Sql &= " FROM  VISTA_INVENTARIOS_CATALOGO_PRODUCTOS y" & vbCrLf
            Sql &= " WHERE y.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " y.PRODUCTO = @PRODUCTO)      AS GRUPO," & vbCrLf
            Sql &= " (SELECT TOP 1   DESCRIPCION_GRUPO" & vbCrLf
            Sql &= " FROM  VISTA_INVENTARIOS_CATALOGO_PRODUCTOS x" & vbCrLf
            Sql &= " WHERE x.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " x.PRODUCTO = @PRODUCTO)      AS GRUPOD," & vbCrLf
            Sql &= " (SELECT TOP 1   SUBGRUPO" & vbCrLf
            Sql &= " FROM  VISTA_INVENTARIOS_CATALOGO_PRODUCTOS y" & vbCrLf
            Sql &= " WHERE y.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " y.PRODUCTO = @PRODUCTO)      AS SUBGRUPO," & vbCrLf
            Sql &= " (SELECT TOP 1   DESCRIPCION_SUBGRUPO" & vbCrLf
            Sql &= " FROM  VISTA_INVENTARIOS_CATALOGO_PRODUCTOS x" & vbCrLf
            Sql &= " WHERE x.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " x.PRODUCTO = @PRODUCTO)      AS SUBGRUPOD," & vbCrLf
            Sql &= " @PRODUCTO                                  AS PRODUCTO," & vbCrLf
            Sql &= " (SELECT TOP 1   DESCRIPCION_PRODUCTO " & vbCrLf
            Sql &= " FROM  VISTA_INVENTARIOS_CATALOGO_PRODUCTOS w" & vbCrLf
            Sql &= " WHERE w.COMPAÑIA = @COMPAÑIA AND" & vbCrLf
            Sql &= " w.PRODUCTO = @PRODUCTO)      AS DESCRIPCION,				" & vbCrLf
            Sql &= " CONVERT(NUMERIC(18,6),(ISNULL((SELECT SUM(s1.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS s1" & vbCrLf
            Sql &= " WHERE s1.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " s1.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " s1.TIPO_MOVIMIENTO = 1  AND   " & vbCrLf
            Sql &= " s1.ENTRADA_SALIDA = 1),0.00)) )     AS MEDIDA,			   " & vbCrLf
            Sql &= " @FECHA_HASTA                               AS FECHA_HASTA,			   " & vbCrLf
            Sql &= " CONVERT(NUMERIC(18,6),(ISNULL((SELECT SUM(s1.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS s1" & vbCrLf
            Sql &= " WHERE s1.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " s1.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " s1.TIPO_MOVIMIENTO = 4  AND   " & vbCrLf
            Sql &= " s1.ENTRADA_SALIDA = 0),0.00)))" & vbCrLf
            Sql &= " AS TIPO_COSTO," & vbCrLf
            Sql &= " CASE WHEN @INICIANDO = 1 THEN DBO.calcular_existencia_actual(@COMPAÑIA,@BODEGA,@PRODUCTO,@FECHA_MES_PASADO)" & vbCrLf
            Sql &= " ELSE" & vbCrLf
            Sql &= " (DBO.calcular_existencia_actual(@COMPAÑIA,@BODEGA,@PRODUCTO,@FECHA)) " & vbCrLf
            Sql &= " END              AS CANT_INV_INI, " & vbCrLf
            Sql &= " 0                                         AS UNIT_INV_INI, " & vbCrLf
            Sql &= " CASE WHEN @INICIANDO = 1 THEN " & vbCrLf
            Sql &= " ((" & vbCrLf
            Sql &= " Select ISNULL(SUM(COSTO_INICIAL), 0.0)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_SALDOS " & vbCrLf
            Sql &= " WHERE COMPAÑIA = @COMPAÑIA        AND " & vbCrLf
            Sql &= " PRODUCTO = @PRODUCTO        AND" & vbCrLf
            Sql &= " BODEGA   = @BODEGA          AND" & vbCrLf
            Sql &= " AÑO_PERIODO = YEAR (@FECHA_MES_PASADO) AND" & vbCrLf
            Sql &= " MES_PERIODO = MONTH(@FECHA_MES_PASADO))" & vbCrLf
            Sql &= " +				" & vbCrLf
            Sql &= " (SELECT ISNULL(SUM(COSTO_TOTAL),0.00)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE " & vbCrLf
            Sql &= " WHERE ENTRADA_SALIDA = 1    AND " & vbCrLf
            Sql &= " COMPAÑIA  = @COMPAÑIA AND" & vbCrLf
            Sql &= " PRODUCTO  = @PRODUCTO AND" & vbCrLf
            Sql &= " BODEGA    = @BODEGA   AND" & vbCrLf
            Sql &= " PROCESADO = 1         AND" & vbCrLf
            Sql &= " ANULADO   = 0         AND" & vbCrLf
            Sql &= " CONVERT(DATE,FECHA_MOVIMIENTO) BETWEEN CONVERT(DATE,'01/'+ CONVERT(VARCHAR,MONTH(DBO.EOMONTH(DATEADD(MONTH, -1,@FECHA_DESDE)))) + '/' + CONVERT(VARCHAR(4),YEAR(DBO.EOMONTH(DATEADD(MONTH, -1,@FECHA_DESDE))))) AND @FECHA_MES_PASADO)" & vbCrLf
            Sql &= " -                " & vbCrLf
            Sql &= " (SELECT ISNULL(SUM(COSTO_TOTAL),0.00)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE " & vbCrLf
            Sql &= " WHERE ENTRADA_SALIDA = 0    AND " & vbCrLf
            Sql &= " COMPAÑIA  = @COMPAÑIA AND 					 " & vbCrLf
            Sql &= " PRODUCTO  = @PRODUCTO AND" & vbCrLf
            Sql &= " BODEGA    = @BODEGA   AND" & vbCrLf
            Sql &= " PROCESADO = 1         AND" & vbCrLf
            Sql &= " ANULADO   = 0         AND" & vbCrLf
            Sql &= " CONVERT(DATE,FECHA_MOVIMIENTO) BETWEEN CONVERT(DATE,'01/'+ CONVERT(VARCHAR,MONTH(DBO.EOMONTH(DATEADD(MONTH, -1,@FECHA_DESDE)))) + '/' + CONVERT(VARCHAR(4),YEAR(DBO.EOMONTH(DATEADD(MONTH, -1,@FECHA_DESDE)))))  AND @FECHA_MES_PASADO))" & vbCrLf
            Sql &= " ELSE                         				" & vbCrLf
            Sql &= " ((SELECT ISNULL(SUM(COSTO_INICIAL),0.00)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_SALDOS " & vbCrLf
            Sql &= " WHERE COMPAÑIA = @COMPAÑIA        AND " & vbCrLf
            Sql &= " PRODUCTO = @PRODUCTO        AND" & vbCrLf
            Sql &= " BODEGA   = @BODEGA          AND" & vbCrLf
            Sql &= " AÑO_PERIODO = YEAR (@FECHA) AND" & vbCrLf
            Sql &= " MES_PERIODO = MONTH(@FECHA))" & vbCrLf
            Sql &= " +				" & vbCrLf
            Sql &= " (SELECT ISNULL(SUM(COSTO_TOTAL),0.00)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE " & vbCrLf
            Sql &= " WHERE ENTRADA_SALIDA = 1    AND " & vbCrLf
            Sql &= " COMPAÑIA  = @COMPAÑIA AND" & vbCrLf
            Sql &= " PRODUCTO  = @PRODUCTO AND" & vbCrLf
            Sql &= " BODEGA    = @BODEGA   AND" & vbCrLf
            Sql &= " PROCESADO = 1         AND" & vbCrLf
            Sql &= " ANULADO   = 0         AND" & vbCrLf
            Sql &= " CONVERT(DATE,FECHA_MOVIMIENTO) BETWEEN @FECHA_INICIAL AND @FECHA)				" & vbCrLf
            Sql &= " -" & vbCrLf
            Sql &= " (SELECT ISNULL(SUM(COSTO_TOTAL),0.00)" & vbCrLf
            Sql &= " FROM INVENTARIOS_MOVIMIENTOS_DETALLE " & vbCrLf
            Sql &= " WHERE ENTRADA_SALIDA = 0    AND " & vbCrLf
            Sql &= " COMPAÑIA  = @COMPAÑIA AND 					 " & vbCrLf
            Sql &= " PRODUCTO  = @PRODUCTO AND" & vbCrLf
            Sql &= " BODEGA    = @BODEGA   AND" & vbCrLf
            Sql &= " PROCESADO = 1         AND" & vbCrLf
            Sql &= " ANULADO   = 0         AND" & vbCrLf
            Sql &= " CONVERT(DATE,FECHA_MOVIMIENTO) BETWEEN @FECHA_INICIAL AND @FECHA))" & vbCrLf
            Sql &= " END          AS COST_INV_INI, " & vbCrLf
            Sql &= " ISNULL((SELECT SUM(t.CANTIDAD) " & vbCrLf
            Sql &= " FROM #DATOS AS t" & vbCrLf
            Sql &= " WHERE t.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " t.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " t.ENTRADA_SALIDA = 1 AND t.TIPO_MOVIMIENTO NOT IN (13)),0.00) AS CANT_INGRESO," & vbCrLf
            Sql &= " 0                                         AS UNIT_INGRESO,               " & vbCrLf
            Sql &= " ISNULL((SELECT SUM(s.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS s" & vbCrLf
            Sql &= " WHERE s.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " s.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " s.TIPO_MOVIMIENTO = 3  AND   " & vbCrLf
            Sql &= " s.ENTRADA_SALIDA = 1),0.00) AS COST_INGRESO,				" & vbCrLf

            Sql &= " round(ISNULL((SELECT SUM(r.CANTIDAD) " & vbCrLf
            Sql &= " FROM #DATOS AS r" & vbCrLf
            Sql &= " WHERE r.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " r.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " r.TIPO_MOVIMIENTO IN (2, 8, 10) AND " & vbCrLf
            Sql &= " r.ENTRADA_SALIDA = 0),0.00) -" & vbCrLf

            Sql &= " ISNULL((SELECT SUM(p.CANTIDAD)" & vbCrLf
            Sql &= " FROM #DATOS AS p" & vbCrLf
            Sql &= " WHERE p.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " p.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " p.TIPO_MOVIMIENTO in (13) AND" & vbCrLf
            Sql &= " p.ENTRADA_SALIDA = 1),0.00),2) AS CANT_SALIDAS,				" & vbCrLf

            Sql &= " round(ISNULL((SELECT SUM(o.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS o" & vbCrLf
            Sql &= " WHERE o.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " o.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " o.TIPO_MOVIMIENTO IN (2, 8, 10) AND " & vbCrLf
            Sql &= " o.ENTRADA_SALIDA = 0),0.00) -" & vbCrLf

            Sql &= " ISNULL((SELECT SUM(p.COSTO_TOTAL)"
            Sql &= " FROM #DATOS AS p"
            Sql &= " WHERE p.PRODUCTO = @PRODUCTO AND"
            Sql &= " p.BODEGA   = @BODEGA   AND"
            Sql &= " p.TIPO_MOVIMIENTO in (13) AND"
            Sql &= " p.ENTRADA_SALIDA = 1),0.00),2) AS COST_SALIDAS,				"

            Sql &= " ISNULL((SELECT SUM(p.CANTIDAD)" & vbCrLf
            Sql &= " FROM #DATOS AS p" & vbCrLf
            Sql &= " WHERE p.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " p.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " p.TIPO_MOVIMIENTO NOT IN (2, 8, 10) AND  " & vbCrLf
            Sql &= " p.ENTRADA_SALIDA = 0),0.00)" & vbCrLf
            Sql &= " AS CANT_DEVOLUC,				" & vbCrLf
            Sql &= " ISNULL((SELECT SUM(p.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS p" & vbCrLf
            Sql &= " WHERE p.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " p.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " p.TIPO_MOVIMIENTO NOT IN (2, 4,8, 10) AND  " & vbCrLf
            Sql &= " p.ENTRADA_SALIDA = 0),0.00)" & vbCrLf
            Sql &= " AS COST_DEVOLUC,				" & vbCrLf
            Sql &= " @PERIODO                                   AS PERIODO," & vbCrLf
            Sql &= " ISNULL((SELECT SUM(p.COSTO_TOTAL)" & vbCrLf
            Sql &= " FROM #DATOS AS p" & vbCrLf
            Sql &= " WHERE p.PRODUCTO = @PRODUCTO AND" & vbCrLf
            Sql &= " p.BODEGA   = @BODEGA   AND" & vbCrLf
            Sql &= " p.TIPO_MOVIMIENTO not in (1, 3, 13) AND  " & vbCrLf
            Sql &= " p.ENTRADA_SALIDA = 1),0.00)	AS IN_AJUS		   			   " & vbCrLf
            Sql &= " FETCH NEXT FROM TEMPORAL" & vbCrLf
            Sql &= " INTO @BODEGA, @PRODUCTO " & vbCrLf
            Sql &= " END;" & vbCrLf
            Sql &= " Close TEMPORAL" & vbCrLf
            Sql &= " DEALLOCATE TEMPORAL " & vbCrLf
            Sql &= " SELECT * FROM @TABLA_1" & vbCrLf
            Sql &= " WHERE (CANT_INV_INI <> 0) OR " & vbCrLf
            Sql &= " (CANT_INGRESO <> 0) OR" & vbCrLf
            Sql &= " (CANT_SALIDAS <> 0) OR" & vbCrLf
            Sql &= " (CANT_DEVOLUC <> 0)               " & vbCrLf
            Sql &= " ORDER BY BODEGA, GRUPO, SUBGRUPO, PRODUCTO"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables.Count() > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaInventario_Movimiento_Productos_Costos(ByVal Compañias, ByVal Bodega1, ByVal Bodega2, ByVal Fecha1, ByVal Fecha2)
        Dim Rpt As New Inventario_Reporte_Movimiento_Producto_Costos_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_INVENTARIOS_REPORTES_MOVIMIENTO_PRODUCTOS_COSTOS_RPT "
            Sql &= Compañias
            Sql &= ", " & Bodega1
            Sql &= ", " & Bodega2
            Sql &= ", '" & Format(Fecha1, "dd/MM/yyyy") & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Format(Fecha2, "dd/MM/yyyy") & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables.Count() > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Public Sub CargaInventario_Kardex_Consolidado(ByVal Compañias, ByVal Bodegas, ByVal Producto1, ByVal Producto2, ByVal Fecha)
        Dim Rpt As New Inventario_Reporte_Kardex_Consolidado_Rpt
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_INVENTARIOS_REPORTES_KARDEX_CONSOLIDADO_RPT "
            Sql &= Compañias
            Sql &= ", " & Bodegas
            Sql &= ", " & Producto1
            Sql &= ", " & Producto2
            Sql &= ", '" & Format(Fecha, "dd/MM/yyyy") & "'"
            Sql &= ", '" & Usuario & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables.Count() > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Sub GetReporteProgramacion_Pagos_Proveedores(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Bandera)
        Dim Rpt As New Contabilidad_Reportes_Programacion_Pagos_Proveedores_Rpt    'Para todas las bodegas

        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_REPORTES_PROGRAMACION_PAGOS_PROVEEDORES_RPT "
            Sql &= "@COMPAÑIA = " & Compañia
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @FECHA = '" & Fecha & "'"
            Sql &= ", @BANDERA = " & Bandera
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub
    'Sub GetReporteCheques_Emitidos_Proveedores_Firma(ByVal Compañia, ByVal FechaI, ByVal FechaF, ByVal Bandera)
    '    Dim Rpt As New Contabilidad_Reportes_Cheques_Emitidos_Firmas_Rpt

    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_CUENTASxPAGAR_CHEQUES_EMITIDOS_FIRMAS_RPT "
    '        Sql &= "@COMPAÑIA = " & Compañia
    '        Sql &= ", @FECHAI = '" & FechaI & "'"
    '        Sql &= ", @BANDERA = " & Bandera
    '        Sql &= ", @FECHAF = '" & FechaF & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    '    CloseConnection()
    'End Sub
    'Sub GetReporteAuxiliar_Cuentas_Pagar(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Bandera)
    '    Dim Rpt As New Contabilidad_Reportes_Auxiliar_Cuentas_Pagar_RPT

    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_CONTABILIDAD_REPORTES_ANTIGUEDAD_SALDOS_PROVEEDORES_RPT "
    '        Sql &= "@COMPAÑIA = " & Compañia
    '        Sql &= ", @BODEGA = " & Bodega
    '        Sql &= ", @FECHA = '" & Fecha & "'"
    '        Sql &= ", @BANDERA = " & Bandera
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '            MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    '    CloseConnection()
    'End Sub

    Public Sub CargaOC(ByVal Compañia, ByVal OC)
        Dim Table As DataTable
        Dim Rpt As New Contabilidad_OC
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_RPT "
            Sql &= Compañia
            Sql &= ", " & OC
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub ReporteDetalle(ByVal TipoReporte, ByVal Valor)
        'Dim Reporte As New frmReportes
        Dim ParametroRango01 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim Parametro01 As New CrystalDecisions.Shared.ParameterField

        Dim ParametroRango02 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim Parametro02 As New CrystalDecisions.Shared.ParameterField

        Dim ParametroRango03 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim Parametro03 As New CrystalDecisions.Shared.ParameterField

        Dim ParametroRango04 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim Parametro04 As New CrystalDecisions.Shared.ParameterField

        Dim Parametros As New CrystalDecisions.Shared.ParameterFields
        Parametro01.ParameterFieldName = "@COMPAÑIA"
        ParametroRango01.Value = 1
        Parametro01.CurrentValues.Add(ParametroRango01)
        Parametros.Add(Parametro01)

        Parametro02.ParameterFieldName = "@BODEGA"
        ParametroRango02.Value = 1
        Parametro02.CurrentValues.Add(ParametroRango02)
        Parametros.Add(Parametro02)

        'Parametro02.ParameterFieldName = "@LIBRO_CONTABLE"
        'ParametroRango02.Value = Producto
        'Parametro02.CurrentValues.Add(ParametroRango02)
        'Parametros.Add(Parametro02)

        Parametro03.ParameterFieldName = "@BANDERA"
        ParametroRango03.Value = 1
        Parametro03.CurrentValues.Add(ParametroRango03)
        Parametros.Add(Parametro03)

        'Parametro04.ParameterFieldName = "@DIRECCION_CONTACTO_DETALLE"
        'ParametroRango04.Value = Tipo
        'Parametro04.CurrentValues.Add(ParametroRango04)
        'Parametros.Add(Parametro04)
        Me.crvReporte.ParameterFieldInfo = Parametros
        'Me.crvReporte.Refresh()
        Select Case TipoReporte
            Case 0 'Partida
                Me.crvReporte.ReportSource = AppPath & "\Reports\Test.rpt"
        End Select
        Me.crvReporte.ShowExportButton = True
        Me.crvReporte.Zoom(85)
    End Sub

    Public Sub ReporteNoAplicados(ByVal Table As DataTable)
        Dim Rpt As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Try
            TextObj = Rpt.Section2.ReportObjects.Item("Text13")
            TextObj.Text = Descripcion_Compañia
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub ReportesGenericos(ByVal RepByRef As ReportDocument)
        Try
            Me.crvReporte.ReportSource = RepByRef
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    


    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        Bw1.ReportProgress(5)

        If (bandera_1 = 7) Then
            c_data1.MiddleConnection("EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & compañia_1 & ",@FECHA1='" & Format(fecha_1, "dd-MM-yyyy hh:mm:ss") & "'" & ",@FECHA2='" & Format(fecha_2, "dd-MM-yyyy hh:mm:ss") & "',@BANDERA=1, @BODEGA=" & bodega_1 & ", @TIEMPO=" & tiempo1)
        Else
            If bandera_1 = 8 Then
                Dim consultaSql As String = "EXECUTE sp_CLINICA_CATALOGO_REQUERIMIENTO_APROBACION_RPT @CODIGO_PACIENTE=" & CodigoRPT & ",@COMPAÑIA_FIADOR=" & CompañiaDeFiador
                If ParamcodigoAs <> Nothing Then
                    consultaSql = consultaSql & ",@CODIGO_EMPLEADO_FIADOR=" & ParamcodigoBux
                End If
                If ParamcodigoBux <> Nothing Then
                    consultaSql = consultaSql & ",@CODIGO_EMPLEADOAS_FIADOR='" & ParamcodigoAs & "'"
                End If

                c_data1.MiddleConnection(consultaSql)

            Else
                If bandera_1 = 9 Then
                    c_data1.MiddleConnection("EXECUTE sp_CLINICA_CATALOGO_CITAS_RPT @CODIGO_CITA=" & CodigoRPT)
                Else
                    If bandera_1 = 10 Then
                        c_data1.MiddleConnection("EXEC sp_CLINICA_INCAPACIDADES_RPT @CODIGO_CITA=" & CodigoRPT)
                    Else
                        If (bandera_1 = 3) Or (bandera_1 = 30) Then
                            If bandera_1 = 30 Then
                                c_data1.MiddleConnection("EXECUTE sp_INVENTARIOS_REPORTE_TRANSFERENCIAS @COMPAÑIA=" & compañia_1 & ",@BODEGA1=" & bodega_1 & ",@BODEGA2=" & bodega_2 & ",@TIPO_MOVIMIENTO=" & tipo_mov_1 & ",@ENTRADA_SALIDA =" & in_out_1 & ",@FECHA1='" & Format(fecha_1, "dd-MM-yyyy 00:00:01") & "',@DOCTO='" & DoctoCCF & "'")
                            Else
                                If bander = 1 Then
                                    bandera_1 = 1
                                ElseIf bander = 2 Then
                                    bandera_1 = 52
                                End If
                                c_data1.MiddleConnection("EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & compañia_1 & ",@BODEGA=" & bodega_1 & ",@BANDERA=" & bandera_1 & ",@TIPO_MOVIMIENTO=" & tipo_mov_1 & ",@ENTRADA_SALIDA =" & in_out_1 & ",@FECHA1='" & Format(fecha_1, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(fecha_1, "dd-MM-yyyy 00:00:01") & "', @BODEGA2=" & bodega_2 & ",@GRUPO=" & grupo1 & ", @SUBGRUPO=" & subgrupo1)
                                If bandera_1 = 52 Then
                                    bandera_1 = 11
                                ElseIf bandera_1 = 1 Then
                                    bandera_1 = 11
                                End If
                            End If
                        Else
                            If bandera_1 = 12 Then
                                c_data1.MiddleConnection("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ",@ORDEN_COMPRA = " & Orden_Compra & ",@BANDERA = 1, @DOCUMENTO = " & Docto)
                            Else
                                If bandera_1 = 20 Then
                                    'DS20 = c_data1.CargarConciliacionBancaria(consultaConciliacion)
                                Else

                                    If bandera_1 = 21 Then
                                        c_data1.MiddleConnection("EXECUTE sp_CLINICA_RADIOGRAFIAS_RPT @CODIGO_RADIOGRAFIA=" & Me.CodigoRPT)
                                    Else
                                        c_data1.MiddleConnection("EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & compañia_1 & ",@BODEGA=" & bodega_1 & ",@BANDERA=" & bandera_1 & ",@TIPO_MOVIMIENTO=" & tipo_mov_1 & ",@ENTRADA_SALIDA =" & in_out_1 & ",@FECHA1='" & Format(fecha_1, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(fecha_2, "dd-MM-yyyy 00:00:01") & "', @A_Cero = " & Exi & ",@GRUPO=" & grupo1 & ", @SUBGRUPO=" & subgrupo1)
                                        'c_data1.MiddleConnection("EXECUTE sp_INVENTARIOS_GENERAR_REPORTES @COMPAÑIA=" & compañia_1 & ",@BODEGA=" & bodega_1 & ",@BANDERA=" & bandera_1 & ",@TIPO_MOVIMIENTO=" & tipo_mov_1 & ",@ENTRADA_SALIDA =" & in_out_1 & ",@FECHA1='" & #1/1/2013# & "', @FECHA2='" & #1/1/2014# & "', @A_Cero = " & Exi)
                                    End If

                                End If

                            End If
                        End If
                    End If
                End If
            End If

        End If
        'Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Bw1.ReportProgress(50)
        If bandera_1 <> 20 Then
            c_data1.DataAdapter.Fill(DS)
        End If

        Bw1.ReportProgress(100)

    End Sub
    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            pB1.Value = 0
            Bw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            Bw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            Bw2.RunWorkerAsync()
            If bandera_1 = 1 Then
                reporte.SetDataSource(DS.Tables(0))
                Me.crvReporte.ReportSource = reporte
            End If
            If (bandera_1 = 2) Or (bandera_1 = 51) Then
                reporte_1.SetDataSource(DS.Tables(0))
                Me.crvReporte.ReportSource = reporte_1
            End If

            If bandera_1 = 3 Or bandera_1 = 30 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    Hay_Datos = True
                    If bandera_1 = 3 Then
                        reporte_2.SetDataSource(DS.Tables(0))
                        Me.crvReporte.ReportSource = reporte_2
                    Else
                        reporte_30.SetDataSource(DS.Tables(0))
                        Me.crvReporte.ReportSource = reporte_30
                    End If
                Else
                    Hay_Datos = False
                End If
            End If

            If bandera_1 = 5 Then
                reporte_3.SetDataSource(DS.Tables(0))
                Me.crvReporte.ReportSource = reporte_3
            End If
            If bandera_1 = 6 Then
                reporte_4.SetDataSource(DS.Tables(0))
                If DS.Tables(0).Columns.Count > 0 Then
                    Hay_Datos = True
                    Me.crvReporte.ReportSource = reporte_4
                Else
                    Hay_Datos = False
                End If
            End If
            If bandera_1 = 7 Then
                reporte_5.SetDataSource(DS.Tables(0))
                Me.crvReporte.ReportSource = reporte_5
            End If
            'If bandera_1 = 8 Then
            '    reporte_6.SetDataSource(DS.Tables(0))
            '    Me.crvReporte.ReportSource = reporte_6
            'End If
            'If bandera_1 = 9 Then
            '    reporte_7.SetDataSource(DS.Tables(0))
            '    Me.crvReporte.ReportSource = reporte_7
            'End If

            'If bandera_1 = 10 Then
            '    reporte_8.SetDataSource(DS.Tables(0))
            '    Me.crvReporte.ReportSource = reporte_8
            'End If
            If bandera_1 = 11 Then
                If Exi = 1 Then
                    reporte_22.SetDataSource(DS.Tables(0))
                    Me.crvReporte.ReportSource = reporte_22
                Else
                    reporte_9.SetDataSource(DS.Tables(0))
                    Me.crvReporte.ReportSource = reporte_9
                End If
            End If
            If bandera_1 = 12 Then
                reporte_10.SetDataSource(DS.Tables(0))
                Me.crvReporte.ReportSource = reporte_10
            End If

            'If bandera_1 = 20 Then
            '    reporte_20.SetDataSource(DS20)
            '    Me.crvReporte.ReportSource = reporte_20
            'End If
            'If bandera_1 = 21 Then
            '    reporte_21.SetDataSource(DS.Tables(0))
            '    Me.crvReporte.ReportSource = reporte_21
            'End If

        End If
        ban = 1

    End Sub

    Private Sub Bw1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw1.ProgressChanged
        'Al reportar el progreso, actualizamos el progressBar
        pB1.Value = e.ProgressPercentage

    End Sub


    Private Sub Bw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw2.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub Bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If Bw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                Bw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        Bw2.ReportProgress(100)

    End Sub
    'REPORTES LUIS HERNANDEZ
    'Sub GetReporteConstanciaCancelacionPrestamo(ByVal Compañia, ByVal Codigo_AS, ByVal Solicitud)
    '    Dim Rpt As New REPORTE_CONSTANCIA_CANCELACION_PRESTAMO
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_COOPETATIVA_REPORTE_CONSTANCIAS_CANCELACIONES_PRESTAMOS"
    '        Sql &= " @COMPAÑIA = " & Compañia
    '        Sql &= ", @CODIGO_AS = '" & Codigo_AS & "'"
    '        Sql &= ", @SOLICITUD = '" & Solicitud & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        Hay_Datos = False
    '        'MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub


    'Sub GetReporteConstanciaCancelacionDeudaPrestamo(ByVal Compañia, ByVal Codigo_AS, ByVal Solicitud)
    '    Dim Rpt As New COOPERATIVA_REPORTE_CONSTANCIA_CANCELACION_PRESTAMO_DEUDA
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_COOPERATIVA_REPORTE_CONSTANCIA_CANCELACION_DEUDA_PRESTAMO"
    '        Sql &= " @COMPAÑIA = " & Compañia
    '        Sql &= ", @CODIGO_EMPLEADO_AS = '" & Codigo_AS & "'"
    '        Sql &= ", @SOLICITUD = '" & Solicitud & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub

    'Sub GetReporteConstanciaCancelacionDeuda(ByVal Compañia, ByVal Codigo_AS, ByVal Solicitud)
    '    Dim Rpt As New COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS"
    '        Sql &= " @COMPAÑIA = " & Compañia
    '        Sql &= ", @CODIGO_AS = '" & Codigo_AS & "'"
    '        Sql &= ", @SOLICITUD = '" & Solicitud & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub


    'Sub GetReporteConstanciaAhorro(ByVal Compañia, ByVal Codigo_AS) ', ByVal Solicitud
    '    Dim Rpt As New REPORTE_COOPERATIVA_CONSTANCIA_AHORROS
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_COOPERATIVA_REPORTE_CONSTANCIA_AHORROS"
    '        Sql &= " @COMPAÑIA = " & Compañia
    '        Sql &= ", @CODIGO_AS = '" & Codigo_AS & "'"
    '        'Sql &= ", @SOLICITUD = '" & Solicitud & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub

    'Sub GetReporteReporteHistoricoPrestamos(ByVal Compañia, ByVal Codigo_AS) ', ByVal Solicitud
    '    Dim Rpt As New Reporte_Constancia_Historico_Prestamos_Socios
    '    Try
    '        DS01.Reset()
    '        OpenConnection()
    '        Sql = "Execute sp_COOPERATIVA_REPORTE_HISTORIAL_PRESTAMOS"
    '        Sql &= " @COMPAÑIA = " & Compañia
    '        Sql &= ", @CODIGO_AS = '" & Codigo_AS & "'"
    '        'Sql &= ", @SOLICITUD = '" & Solicitud & "'"
    '        MiddleConnection()
    '        DataAdapter.Fill(DS01)
    '        If DS01.Tables(0).Rows.Count > 0 Then
    '            Hay_Datos = True
    '            Rpt.SetDataSource(DS01.Tables(0))
    '            Me.crvReporte.ReportSource = Rpt
    '        Else
    '            Hay_Datos = False
    '        End If
    '        CloseConnection()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
    '    End Try
    'End Sub

    Public Sub CargaReporteSociosNO(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Firmas As Integer, ByVal Empresa As Integer, ByVal Division As Integer, ByVal Departamento As Integer, ByVal Seccion As Integer, ByVal fecha As String)
        Dim Rpt As New Cooperativa_Reporte_Socios_NoSocios
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS " & vbCrLf
            Sql &= Compañia & vbCrLf
            Sql &= "," & 1 & vbCrLf
            Sql &= "," & 9999999 & vbCrLf
            Sql &= "," & Bandera & vbCrLf
            Sql &= "," & Firmas & vbCrLf
            Sql &= "," & Empresa & vbCrLf
            Sql &= "," & Division & vbCrLf
            Sql &= "," & Departamento & vbCrLf
            Sql &= "," & Seccion & vbCrLf
            Sql &= ", '" & fecha & "'" & vbCrLf
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        CloseConnection()
    End Sub

    Sub GetReporteHistoricoCuotas(ByVal datos_ As DataTable) ', ByVal Solicitud
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim Rpt As New CooperativaReporteHistoricoCuotas
        Try
            Rpt.SetDataSource(datos_)
            txtObj = Rpt.Section2.ReportObjects.Item("txtEmpresa")
            txtObj.Text = Descripcion_Compañia
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Sub GetInformeConciliacionAhorroDeducciones(ByVal Compañia)
        Dim Rpt As New Cooperativa_Informe_Conciliacion_Ahorro_Deducciones
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_COOPERATIVA_REPORTE_INFORME_CONCILIACION_AHORRO_DEDUCCIONES"
            Sql &= " @COMPAÑIA = " & Compañia
            'Sql &= ", @CODIGO_AS = '" & Codigo_AS & "'"
            'Sql &= ", @SOLICITUD = '" & Solicitud & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If DS01.Tables(0).Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(DS01.Tables(0))
                Me.crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaRequisicion(ByVal _requisicion As String)
        Dim Table As DataTable
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim reporte_requisicion As New Contabilidad_Reporte_Orden_Requisicion
        Try
            Sql = "Execute SP_CONTABILIDAD_ORDEN_REQUISICION @REQUISICION=" & _requisicion & ",@COMPAÑIA=" & Compañia
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte_requisicion.SetDataSource(Table)
            Try
                txtObj = reporte_requisicion.Section2.ReportObjects("Text41")
                txtObj.Text = Descripcion_Compañia
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Me.crvReporte.ReportSource = reporte_requisicion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaListaProveedor(ByVal _lista As String)
        Dim Table As DataTable
        Dim reporte_lista_provee As New Contabilidad_Reporte_Lista_Precios_Proveedores
        Try
            Sql = "Execute SP_CONTABILIDAD_ORDEN_LISTA_PRECIOS @LISTA=" & _lista & ",@COMPAÑIA=" & Compañia
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte_lista_provee.SetDataSource(Table)
            Me.crvReporte.ReportSource = reporte_lista_provee
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargaOC_Directa(ByVal Compañia As Integer, ByVal OC As Integer)
        Dim Table As DataTable
        Dim Rpt As New Contabilidad_OC_Directa
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_RPT "
            Sql &= Compañia
            Sql &= ", " & OC
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            Rpt.SetDataSource(Table)
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargarRptComprasPorProveedor(ByVal _compania, ByVal _desde, ByVal _hasta, ByVal _bodega, ByVal _proveedor, ByVal _documento, ByVal _user)
        Dim Table_rcpp As DataTable
        Dim reporte_compra_por_proveedor As New Contabilidad_Reporte_CompraPorProveedor
        Try
            Sql = "Execute sp_COMPRAS_POR_PROVEEDOR_RPT @COMPAÑIA= " & _compania & ", @DESDE ='" & _desde & "', @HASTA='" & _hasta & "', @BODEGA=" & _bodega & ", @PROVEEDOR =" & _proveedor & ", @DOCUMENTO = " & _documento & ", @USUARIO = '" & _user & "'"
            Table_rcpp = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte_compra_por_proveedor.SetDataSource(Table_rcpp)
            Me.crvReporte.ReportSource = reporte_compra_por_proveedor
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RepCuotasProgDistintasFechas(ByVal _company As Integer, ByVal _fecha As Date, ByVal _user As String, ByVal _rubro As Integer)
        Dim Table As DataTable
        Dim reporte As New Cooperativa_Deudas_Prog_Diferentes_Fechas
        Try
            If _rubro = 0 Then
                Sql = "Execute dbo.SP_COOPERATIVA_DEUDAS_PROGRAMADAS_DIFERENTES_FECHAS @COMPAÑIA = " & _company & ",@FECHA='" & _fecha & "',@USUARIO='" & _user & "',@RUBRO= NULL"
            Else
                Sql = "Execute dbo.SP_COOPERATIVA_DEUDAS_PROGRAMADAS_DIFERENTES_FECHAS @COMPAÑIA = " & _company & ",@FECHA='" & _fecha & "',@USUARIO='" & _user & "',@RUBRO= " & _rubro
            End If
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte.SetDataSource(Table)
            Me.crvReporte.ReportSource = reporte
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargarRptDescuentosEmpleados(ByVal _compania As Integer, ByVal _origenes As String)
        Dim _datos As DataTable
        Dim _reporte As New Cooperativa_Reporte_Empleados_Bloqueados
        Try
            Sql = "Exec dbo.sp_CAFETERIA_DESCUENTOS_X_EMPLEADOS_SIUD @COMPAÑIA=" & _compania & ",@CODIGO_EMPLEADO=0,@CODIGO_EMPLEADO_AS='',@CODIGO=0,@BLOQUEADO=0,@BANDERA= 4,@USUARIO='',@ORIGENES='" & _origenes & "'"
            _datos = c_data1.obtenerDatos(New SqlCommand(Sql))
            _reporte.SetDataSource(_datos)
            Me.crvReporte.ReportSource = _reporte
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RepCafeteriaRecetasProducidas(ByVal _desde As Date, ByVal _hasta As Date, ByVal _planta As Integer, ByVal _company As Integer, ByVal _user As String)
        Dim Table As DataTable
        Try
            Sql = "Exec SP_VENTAS_RECETAS_PRODUCIDAS @DESDE='" & Format(_desde, "dd/MM/yyyy") & "',@HASTA = '" & Format(_hasta, "dd/MM/yyyy") & "', @PLANTA=" & _planta & ", @PRODUCTOS='', @COMPAÑIA = " & _company & ", @USUARIO='" & _user & "'"
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))

            If _planta = 1 Then
                Dim rep_pta1 As New Cafeteria_Reporte_Ventas_Recetas_Producidas
                rep_pta1.SetDataSource(Table)
                Me.crvReporte.ReportSource = rep_pta1
            Else
                Dim rep_pta2 As New Cafeteria_Reporte_Ventas_Recetas_Producidas2
                rep_pta2.SetDataSource(Table)
                Me.crvReporte.ReportSource = rep_pta2
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RepResumenDeudasProgramadas(ByVal _company, ByVal _user, ByVal _rubro, ByVal _empleado, ByVal _periodo)
        Dim Table As DataTable
        Dim reporte_resumen_deudas As New CooperativaResumenDeudasProgramadasRPT
        Try
            If _rubro = 0 Then
                Sql = "Execute dbo.SP_COOPERATIVA_RESUMEN_DEUDAS_PROGRAMADAS_REP @COMPAÑIA = " & _company & ",@USUARIO='" & _user & "',@RUBRO= NULL" & ", @COD_EMPLEADO=" & _empleado & ", @PERIODO='" & _periodo & "'"
            Else
                Sql = "Execute dbo.SP_COOPERATIVA_RESUMEN_DEUDAS_PROGRAMADAS_REP @COMPAÑIA = " & _company & ",@USUARIO='" & _user & "',@RUBRO= '" & _rubro & "', @COD_EMPLEADO=" & _empleado & ", @PERIODO='" & _periodo & "'"
            End If
            Table = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte_resumen_deudas.SetDataSource(Table)
            Me.crvReporte.ReportSource = reporte_resumen_deudas
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargarRptVisualizarDetalles(ByVal _compania, ByVal _socio, ByVal _solicitud, ByVal _hasta, ByVal _normal, ByVal _especial)
        Dim _datos As DataTable
        Dim reporte_visualizar_detalles As New Cooperativa_Visualizar_Detalles
        Try
            Sql = "EXECUTE dbo.SP_COOPERATIVA_VISUALIZAR_DETALLES @COMPAÑIA=" & _compania & ", @SOCIO = " & _socio & ", @SOLICITUD  = " & _solicitud & ", @HASTA = '" & CDate(_hasta).ToString("dd/MM/yyyy") & "', @BANDERA = 2, @MONTO_NORMAL = " & _normal & ", @MONTO_ESPECIAL = " & _especial
            _datos = c_data1.obtenerDatos(New SqlCommand(Sql))
            reporte_visualizar_detalles.SetDataSource(_datos)
            Me.crvReporte.ReportSource = reporte_visualizar_detalles
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargarRptVisualizarTotalizados(ByVal _compania, ByVal _socio, ByVal _hasta, ByVal _solicitudes, ByVal _tipos)
        Dim _datos As DataTable
        Dim _reporte As New CooperativaReporteVisualizarDetallePorSolicitudes
        Try
            Sql = "EXECUTE dbo.SP_COOPERATIVA_VISUALIZAR_DETALLES_POR_SOLICITUDES @BANDERA=2, @COMPAÑIA=" & Compañia & ", @SOCIO = " & _socio & ", @FHASTA = '" & _hasta & "', @SOLICITUDES  = '" & _solicitudes & "', @TPO_SOLICITUDES='" & _tipos & "'"
            _datos = c_data1.obtenerDatos(New SqlCommand(Sql))
            _reporte.SetDataSource(_datos)
            Me.crvReporte.ReportSource = _reporte
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RptDeudasSociosRetirados(ByVal _compania, ByVal _usuario)
        Dim _datos As DataTable
        Dim _reporte As New Cooperativa_Deudas_Empleados_Retirados
        Try
            Sql = "Exec SP_COOPERATIVA_REPORTE_DEUDAS_SOCIOS_RETIRADOS @COMPAÑIA = " & _compania & ", @USUARIO='" & _usuario & "'"
            _datos = c_data1.obtenerDatos(New SqlCommand(Sql))
            _reporte.SetDataSource(_datos)
            Me.crvReporte.ReportSource = _reporte
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub RptCuotasSinCancelar(ByVal _compania, ByVal _hasta)
        Dim _datos As DataTable
        Dim _reporte As New CooperativaRPTCuotasSinCancelarFechasAnteriores
        Try
            Sql = "EXECUTE dbo.SP_COOPERATIVA_CUOTAS_SIN_CANCELAR_FECHAS_ANTERIORES @COMPAÑIA=" & _compania & ", @HASTA = '" & _hasta & "'"
            _datos = c_data1.obtenerDatos(New SqlCommand(Sql))
            _reporte.SetDataSource(_datos)
            Me.crvReporte.ReportSource = _reporte
            Me.crvReporte.DisplayGroupTree = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
End Class