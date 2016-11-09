Imports System.Data.SqlClient

Public Class Facturacion_Procesos
    Inherits jarsClass
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim TCapital, TInteres, TSegDeuda, CuotaDefinitiva As Double
    Dim TipoDeduccion As Integer
    Dim TablaProgs As New DataTable

    Public Function SolicitudesFacturacionSocios(ByVal CIA As Integer, ByVal TipSoli As Integer, ByVal numSoli As Integer, ByVal codSocio As String, ByVal codBuxis As Integer, ByVal fechaSoli As Date, ByVal Autorizacion As Short, ByVal DescPeriodos As Double, ByVal DescAgui As Double, ByVal DescBoni As Double, ByVal Periodo As String, ByVal Plazo As Integer, ByVal FechaDesc As DateTime, ByVal Comentario As String, ByVal TipFactura As Integer, ByVal numFactura As Integer) As Integer
        Dim RowsAfected, DocContable As Integer
        Dim PeriodoPago As String
        Dim ParamDeducciones As DataTable
        Dim Interes, SeguroDeuda, Valor_Cuota As Double
        Dim valor_solicitud As Double = DescPeriodos + DescAgui + DescBoni
        Dim numCuotas As Integer
        codSocio = obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & codBuxis & " AND COMPAÑIA = " & Compañia)
        PeriodoPago = obtenerEscalar("SELECT PERIODO_PAGO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & codBuxis & " AND CODIGO_EMPLEADO_AS = '" & codSocio & "' AND COMPAÑIA = " & Compañia).ToString.Trim
        If PeriodoPago = "MM" Then
            Periodo = PeriodoPago
            If FechaDesc.Day = 15 Then
                If FechaDesc.Month = 2 Then
                    If FechaDesc.Year Mod 4 = 0 Then
                        FechaDesc = "29/" & FechaDesc.Month.ToString.PadLeft(2, "0") & "/" & FechaDesc.Year.ToString
                    Else
                        FechaDesc = "28/" & FechaDesc.Month.ToString.PadLeft(2, "0") & "/" & FechaDesc.Year.ToString
                    End If
                Else
                    FechaDesc = "30/" & FechaDesc.Month.ToString.PadLeft(2, "0") & "/" & FechaDesc.Year.ToString
                End If
            End If
        End If
        CrearTabla()
        If valor_solicitud > 0 Then
            If DescPeriodos = 0 Then
                Plazo = 0
            End If
            If DescAgui > 0 And DescPeriodos = 0 Then
                Periodo = "AG"
                Plazo += 1
                Comentario &= ", Aguin.$" & DescAgui.ToString("0.00")
            End If
            If DescBoni > 0 And DescPeriodos = 0 Then
                Periodo = "BO"
                Plazo += 1
                Comentario &= ", Bonif.$" & DescBoni.ToString("0.00")
            End If
            Try
                Sql = "SELECT CCS.DEDUCCION, CCS.TIPO_DOCUMENTO, CCDS.INTERES AS SEGURO_DEUDA, CCD.INTERES, CCD.LIBRO_CONTABLE, CCD.CUENTA "
                Sql &= "FROM COOPERATIVA_CATALOGO_SOLICITUDES CCS,"
                Sql &= "COOPERATIVA_CATALOGO_DEDUCCIONES CCD,"
                Sql &= "COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO CCDS "
                Sql &= "WHERE CCS.COMPAÑIA = CCD.COMPAÑIA  "
                Sql &= "AND CCS.DEDUCCION = CCD.DEDUCCION "
                Sql &= "AND CCS.COMPAÑIA = CCDS.COMPAÑIA "
                Sql &= "AND CCS.DEDUCCION = CCDS.DEDUCCION "
                Sql &= "AND CCS.COMPAÑIA = " & CIA
                Sql &= "AND CCS.SOLICITUD = " & TipSoli
                sqlCmd.CommandText = Sql
                ParamDeducciones = obtenerDatos(sqlCmd)
                TipoDeduccion = ParamDeducciones.Rows(0).Item("DEDUCCION")
                Interes = ParamDeducciones.Rows(0).Item("INTERES")
                SeguroDeuda = ParamDeducciones.Rows(0).Item("SEGURO_DEUDA")
                DocContable = ParamDeducciones.Rows(0).Item("TIPO_DOCUMENTO")
                GeneraSolicitud(CIA, numSoli, TipSoli, codSocio, codBuxis, fechaSoli, valor_solicitud, Interes, Periodo, Plazo, Autorizacion, Comentario, TipFactura, numFactura, DocContable)
                If DescPeriodos > 0 Then
                    ProgramacionCuota(DescPeriodos, Interes, SeguroDeuda, Periodo, Plazo, fechaSoli, FechaDesc)
                    numCuotas = Programacion(numSoli, TipoDeduccion, DescPeriodos, Interes, SeguroDeuda, Periodo, FechaDesc, fechaSoli)
                    While numCuotas <> Plazo
                        If Plazo < numCuotas Then
                            CuotaDefinitiva += 0.01
                        Else
                            CuotaDefinitiva -= 0.01
                        End If
                        numCuotas = Programacion(numSoli, TipoDeduccion, DescPeriodos, Interes, SeguroDeuda, Periodo, FechaDesc, fechaSoli)
                    End While
                    For Each row As DataRow In TablaProgs.Rows
                        MantenimientoProgramacion(row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1, CIA, TipoDeduccion, numSoli)
                    Next
                    MantenimientoProgramacionEncabezado(CIA, numSoli, FechaDesc, fechaSoli, valor_solicitud, Interes, CuotaDefinitiva, Plazo, Periodo, SeguroDeuda)
                    MantenimientoProgramacionDetalle(CIA, numSoli)
                End If
                If DescAgui > 0 Or DescBoni > 0 Then
                    If DescBoni > 0 Then
                        FechaDesc = CDate("12/06/" & Now.Year.ToString)
                        If Now.Date.AddDays(5) >= CDate(FechaDesc) Then
                            FechaDesc = FechaDesc.AddYears(1)
                        End If
                        Valor_Cuota = MantenimientoCuotasEspeciales(2, DescBoni, CIA, numSoli, fechaSoli, FechaDesc, Interes, SeguroDeuda)
                        If DescPeriodos <= 0 And DescAgui = 0 Then
                            MantenimientoProgramacionEncabezado(CIA, numSoli, FechaDesc, fechaSoli, valor_solicitud, Interes, Valor_Cuota, Plazo, Periodo, SeguroDeuda)
                        End If
                    End If
                    If DescAgui > 0 Then
                        FechaDesc = CDate("12/12/" & Now.Year.ToString)
                        If Now.Date.AddDays(5) >= CDate(FechaDesc) Then
                            FechaDesc = FechaDesc.AddYears(1)
                        End If
                        'GeneraSolicitud(CIA, numSoliAgui, TipSoli, codSocio, codBuxis, fechaSoli, valor_solicitud, Interes, Periodo, Plazo, Autorizacion, Comentario, TipFactura, numFactura)
                        Valor_Cuota = MantenimientoCuotasEspeciales(2, DescAgui, CIA, numSoli, fechaSoli, FechaDesc, Interes, SeguroDeuda)
                        If DescPeriodos <= 0 Then
                            MantenimientoProgramacionEncabezado(CIA, numSoli, FechaDesc, fechaSoli, valor_solicitud, Interes, Valor_Cuota, Plazo, Periodo, SeguroDeuda)
                        End If
                    End If
                    GuardarCuotasEspeciales(8, CIA, numSoli)
                    GuardarCuotasEspeciales(9, CIA, numSoli)
                End If
                If DescAgui > 0 And DescBoni > 0 Then
                    ejecutarComandoSql(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & numSoli & "'"))
                Else
                    If DescPeriodos > 0 And (DescAgui > 0 Or DescBoni > 0) Then
                        ejecutarComandoSql(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & numSoli & "'"))
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error SolicitudesFacturacionSocios()")
                RowsAfected = -1
            End Try
        End If
        Return RowsAfected
    End Function

    Public Function ObtieneCorrelativoInventario(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal numDocto As Integer) As Integer
        Dim correlativoInventario As Integer
        Try
            Sql = "SELECT ISNULL(MAX(MOVIMIENTO), 0) " & vbCrLf
            Sql &= "  FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO " & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & CIA & vbCrLf
            Sql &= "   AND BODEGA = " & Bodega & vbCrLf
            If TipDoc > 0 Then
                Sql &= "   AND TIPO_DOCUMENTO_CONTABLE = " & TipDoc & vbCrLf
                Sql &= "   AND NUMERO_DOCUMENTO_CONTABLE = " & numDocto & vbCrLf
            Else
                Sql &= "   AND ORDEN_VENTA = " & numDocto & vbCrLf
            End If
            correlativoInventario = obtenerEscalar(Sql)
            If correlativoInventario = Nothing Then
                correlativoInventario = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error ObtieneCorrelativoInventario()")
        End Try
        Return correlativoInventario
    End Function

    Private Function Programacion(ByVal numSoli As Integer, ByVal Deduccion As Integer, ByVal Saldo As Double, ByVal TasaInteres As Double, ByVal Tasa_Seguro As Double, ByVal Periodo As String, ByVal FechaPago As DateTime, ByVal FechaSoli As DateTime) As Integer
        'Calcula la programación basado en la cuota enviada
        'Retorna la cantidad de cuotas que se generan en base a la cuota definida 
        MantenimientoProgramacion(0, Now(), 0, 0, 0, 0, 0, 0, 0, 3, Compañia, Deduccion, numSoli)
        Dim TotalCuotas As Double = 0
        Dim Cuota As Double = CuotaDefinitiva
        Dim InteresAcum As Double = 0
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = DateDiff(DateInterval.Day, FechaSoli, FechaPago)
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
            DiasPP = IIf(Periodo = "QQ", 15, 30)
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

    Private Sub ProgramacionCuota(ByVal Saldo As Double, ByVal TasaInteres As Double, ByVal Tasa_Seguro As Double, ByVal Periodo As String, ByVal NumCuotas As Integer, ByVal fechaSoli As DateTime, ByVal fechaPago As Date)
        Dim InteresAcum As Double = 0
        Dim TotalCuotas, Cuota As Double
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = DateDiff(DateInterval.Day, fechaSoli, fechaPago)
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
            DiasPP = IIf(Periodo = "QQ", 15, 30)
            Saldo -= Capital
            TotalCuotas += Cuota + Seguro
        Next
        CuotaDefinitiva = Math.Round(TotalCuotas / NumCuotas, 2)
    End Sub

    Private Sub CrearTabla()
        If TablaProgs.Columns.Count = 0 Then
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
        End If
    End Sub

    Private Function DiasInteresCuotasEspeciales(ByVal CIA As Integer, ByVal NumSoli As Integer, ByVal NumeroCuotas As Integer, ByVal FechaPago As DateTime, ByVal FechaIniPres As DateTime) As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI ", Conexion_Track)
        Dim ds As New DataSet
        Dim DiasInteres As Integer
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = 2
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINICIO", SqlDbType.DateTime).Value = FechaIniPres
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINIDES", SqlDbType.DateTime).Value = FechaPago
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = CIA
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = NumSoli
            DataAdapter.SelectCommand.Parameters.Add("@CUOTASDESEADAS", SqlDbType.Int).Value = NumeroCuotas
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
            DiasInteres = ds.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error DiasInteresCuotasEspeciales()")
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
        Return DiasInteres
    End Function

    Private Function Total_CuotaEspecial(ByVal CIA As Integer, ByVal NumSoli As Integer) As Double
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim TotalCuotasEspeciales As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & CIA & "," & NumSoli & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                TotalCuotasEspeciales = DataReader_Track.Item(0)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Total_CuotaEspecial()")
        End Try
        Return TotalCuotasEspeciales
    End Function

    Private Function MantenimientoProgramacion(ByVal Linea, ByVal FechaP, ByVal SaldoIni, ByVal Capital, ByVal Interes, ByVal SegDeuda, ByVal Cuota, ByVal SaldoFin, ByVal InteresAcum, ByVal Bandera, ByVal CIA, ByVal Deduccion, ByVal NumSoli) As DataTable
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim TableProgra As New DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_SID ", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = CIA
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = NumSoli
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
            If Bandera = 2 Then
                Return ds.Tables(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "PROGRAMACION ILUSTRATIVA - Mtto.Prog.")
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
        Return TableProgra
    End Function

    Private Sub MantenimientoProgramacionEncabezado(ByVal CIA As Integer, ByVal NumSoli As Integer, ByVal FechaPrimerPag As DateTime, ByVal FechaIniPres As DateTime, ByVal Monto As Double, ByVal PorcInteres As Double, ByVal Cuota As Double, ByVal NumeroCuotas As Double, ByVal PeriodoPago As String, ByVal PorcSegDeuda As Double)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & CIA & "," _
            & NumSoli & "," & TipoDeduccion & "," & NumeroCuotas & "," & Cuota & "," & _
            Monto & ",'" & PeriodoPago & "','" & Format(FechaIniPres, "dd-MM-yyyy HH:mm:ss") & "','" & Format(FechaPrimerPag, "dd-MM-yyyy HH:mm:ss") & "'," _
            & PorcInteres & "," & PorcSegDeuda & ",'" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error MantenimientoProgramacionEncabezado()")
        End Try
    End Sub

    Private Sub MantenimientoProgramacionDetalle(ByVal CIA As Integer, ByVal NumSoli As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & CIA & "," _
            & NumSoli & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub GuardarCuotasEspeciales(ByVal Bandera As Integer, ByVal CIA As Integer, ByVal NumSoli As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & CIA & "," _
            & NumSoli & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GuardarVariasCuotasEspeciales(ByVal Bandera As Integer, ByVal CIA As Integer, ByVal NumSoli As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLUCITUDES_DETALLE_ESPECIALES_IUD " & CIA & "," _
            & NumSoli & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function MantenimientoCuotasEspeciales(ByVal Bandera As Integer, ByVal CuotaEspecial As Double, ByVal CIA As Integer, ByVal NumSoli As Integer, ByVal FechaIniPres As DateTime, ByVal FechaPago As DateTime, ByVal PorcInteres As Double, ByVal PorcSegDeuda As Double) As Double
        Dim TasaInteres As Double = PorcInteres / 100
        Dim TasaSeguro As Double = PorcSegDeuda / 100
        Dim InteresPrimero As Double = 0
        Dim SegDeudaPrimero As Double = 0
        Dim Cuota As Double = 0
        Dim DiasPP, Linea As Integer
        Dim sqlineaNormal As String = "SELECT ISNULL(MAX([LINEA]),0) + 1 FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & CIA & " AND NUMERO_SOLICITUD = " & NumSoli
        Dim sqlineaEspecial As String = "SELECT ISNULL(MAX([LINEA]),0) + 1 FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_CUOTAS_ESPECIALES WHERE COMPAÑIA = " & CIA & " AND NUMERO_SOLICITUD = " & NumSoli
        Linea = obtenerEscalar(sqlineaEspecial)
        If Linea = 1 Then
            Linea = obtenerEscalar(sqlineaNormal)
        End If
        DiasPP = DiasInteresCuotasEspeciales(CIA, NumSoli, 1, FechaPago, FechaIniPres)
        'Saca la Cuota Previa
        InteresPrimero = (CuotaEspecial * TasaInteres * DiasPP) / 360
        InteresPrimero = Math.Round(InteresPrimero, 2, MidpointRounding.AwayFromZero)
        SegDeudaPrimero = (CuotaEspecial * TasaSeguro * DiasPP) / 30
        SegDeudaPrimero = Math.Round(SegDeudaPrimero, 2, MidpointRounding.AwayFromZero)
        Cuota = CuotaEspecial + InteresPrimero + SegDeudaPrimero
        Cuota = Math.Round(Cuota, 2, MidpointRounding.AwayFromZero)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & CIA & "," _
            & NumSoli & "," & Linea & "," & 0 & "," & 0 & ",'" & Format(FechaPago, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & CuotaEspecial & "," & 0 & "," & InteresPrimero & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Cuota
    End Function

    Public Function actualizaNumDoc(ByVal CIA As Integer, ByVal Docto As String) As Integer
        Dim numDoc As Integer
        Try
            sql = " Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            sql &= CIA
            sql &= ", '" & Docto & "'"
            sql &= ", " & 0
            numDoc = obtenerEscalar(Sql)
            If numDoc = Nothing Then
                Return 0
            Else
                Return numDoc
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Function GeneraSolicitud(ByVal CIA As Integer, ByVal numSoli As Integer, ByVal TipSoli As Integer, ByVal codSocio As String, ByVal codBuxis As Integer, ByVal fechaSoli As DateTime, ByVal Valor_Solicitud As Double, ByVal Interes As Double, ByVal Periodo As String, ByVal Plazo As Integer, ByVal Autorizacion As Short, ByVal Comentario As String, ByVal TipFact As Integer, ByVal numFact As Integer, ByVal DocContable As Integer) As Integer
        Dim RowsAfected As Integer
        Sql = "Coo.sp_COOPERATIVA_SOLICITUDES_IU '" & CIA & "','" _
        & TipSoli & "','" & TipoDeduccion & "','" & numSoli & "','" & codSocio & "','" _
        & codBuxis & "','','" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "', 0, '" & Valor_Solicitud & "','" & Interes & "','" & Periodo & "','" & Plazo & "','" & Usuario & "'"
        sqlCmd.CommandText = Sql
        RowsAfected = ejecutarComandoSql(sqlCmd)
        Sql = "Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU "
        Sql &= CIA '@COMPAÑIA
        Sql &= " ," & numSoli '@N_SOLICITUD
        Sql &= " , 0" '@ORDEN_DE_COMPRA
        Sql &= " , " & Autorizacion '@AUTORIZACION1
        Sql &= " , '" & Comentario & "'" '@COMENTARIO1
        Sql &= " , '" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "'" '@FECHA1
        Sql &= " , " & Autorizacion '@AUTORIZACION2
        Sql &= " , ''" '@COMENTARIO2
        Sql &= " , '" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "'" '@FECHA2
        Sql &= " , " & Autorizacion  '@AUTORIZACION3
        Sql &= " , ''" '@COMENTARIO3
        Sql &= " , '" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "'" '@FECHA3
        Sql &= " , 0" '@DENEGADA
        Sql &= " , ''" '@COMENTARIO_DENEGADA
        Sql &= " , '" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "'" '@FECHA_DENEGADA
        Sql &= " , ''" '@USUARIO_DENEGO
        Sql &= " , 0" '@ANULADA
        Sql &= " , ''" '@COMENTARIO_ANULADA
        Sql &= " , '" & Format(fechaSoli, "dd-MM-yyyy HH:mm:ss") & "'" '@FECHA_ANULADA
        Sql &= " , ''" '@USUARIO_ANULO
        Sql &= " , '" & codSocio & "'" '@CODIGO_AS
        Sql &= " , " & codBuxis '@CODIGO_BUXIS
        Sql &= " , '" & Usuario & "'" '@USUARIO_CREACION
        Sql &= " , 0" '@BANDERA
        Sql &= " , " & TipFact '@TIPO_FACTURA
        Sql &= " , " & numFact '@NUMERO_FACTURA
        sqlCmd.CommandText = Sql
        RowsAfected = ejecutarComandoSql(sqlCmd)
        Return RowsAfected
    End Function

    Public Function DisponibleSocio(ByVal CIA As Integer, ByVal CodSocio As String, ByVal codBuxis As Integer) As Double
        Dim sqlCmd As New SqlCommand
        Dim Dispo As DataTable
        Dim AhorroOrdin, AhorroExtra, Deducciones, DeudaPagada As Double
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO '" & CodSocio & "'," & codBuxis & "," & CIA & "," & 1
            sqlCmd.CommandText = Sql
            Dispo = obtenerDatos(sqlCmd)
            If Dispo.Rows.Count > 0 Then
                AhorroOrdin = Dispo.Rows(0).Item("AHORRO ORDINARIO")
                AhorroExtra = Dispo.Rows(0).Item("AHORRO EXTRAORDINARIO")
                Deducciones = Dispo.Rows(0).Item("DEDUCCION")
                DeudaPagada = Dispo.Rows(0).Item("MONTO DESCONTADO EN SOLICITUDES")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Disponible Socio")
        End Try
        Return ((AhorroOrdin + AhorroExtra) - Deducciones) + DeudaPagada
    End Function

    Public Function DevuelveConstante(ByVal cia As Integer, ByVal Constante As Integer) As Double
        Dim Retorno As Double
        Sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & cia & " AND CONSTANTE = " & Constante
        Retorno = obtenerEscalar(Sql)
        If Retorno = Nothing Then
            Retorno = 0
        End If
        Return Retorno
    End Function
    Public Function Determinardisponible(ByVal numSocio, ByVal codEmp) As Double
        Dim disponible As Double
        Dim Bloqueado As Boolean
        Dim monto_maximo As Double
        sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & numSocio & "'"
        Bloqueado = obtenerEscalar(Sql)
        If Bloqueado = True Then
            sql = "SELECT monto_maximo FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & numSocio & "'"
            monto_maximo = obtenerEscalar(Sql)
            disponible = monto_maximo
        Else
            disponible = DisponibleSocio(Compañia, numSocio, codEmp)
        End If
        Return disponible
    End Function
End Class
