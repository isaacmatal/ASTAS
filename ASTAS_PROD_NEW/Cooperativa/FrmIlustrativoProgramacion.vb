Imports System.Data
Imports System.Data.SqlClient
Public Class FrmIlustrativoProgramacion
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim TCapital, TInteres, TSegDeuda As Double
    Dim NumCuotasA As Integer
    Dim Func As New jarsClass
    Dim Rpts As New FrmCooperativaReportes
    Dim TablaProgs As New DataTable

    Private Sub Deducciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & Compañia & "," & 0 & "," & 3
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "Deducción"
            Me.CbxDeduccion.DisplayMember = "Descripción Deducción"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaInteres()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES " & Compañia & "," & CbxDeduccion.SelectedValue & "," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                LblInteres.Text = DS.Tables(0).Rows(0).Item(2)
                Me.LblSegDeuda.Text = DS.Tables(0).Rows(0).Item(3)
                Me.TxtCuotasMax.Text = DS.Tables(0).Rows(0).Item(4)
                Me.NudNumeroCuot.Maximum = DS.Tables(0).Rows(0).Item(4)
            Else
                LblInteres.Text = "0.00"
                Me.LblSegDeuda.Text = "0.00"
                Me.TxtCuotasMax.Text = "0.00"
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaPeriodos()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION " & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            CbxPeriodo.DataSource = Table
            CbxPeriodo.ValueMember = "PERIODO"
            CbxPeriodo.DisplayMember = "DESCRIPCION_PERIODO"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub MantenimientoProgramacion(ByVal Linea, ByVal FechaP, ByVal SaldoIni, ByVal Capital, ByVal Interes, ByVal SegDeuda, ByVal Cuota, ByVal SaldoFin, ByVal InteresAcum, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_SID ", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@LINEA", SqlDbType.Int).Value = Linea
            DataAdapter.SelectCommand.Parameters.Add("@DEDUCCION", SqlDbType.Int).Value = CbxDeduccion.SelectedValue
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
                DgvProgramacion.DataSource = ds.Tables(0)
            Else
                DgvProgramacion.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub
    Private Function PrimerFechaPago() As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI ", Conexion_Track)
        Dim ds As New DataSet
        Dim DiasP As Integer
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = 2
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINICIO", SqlDbType.DateTime).Value = DtpFechaIniPres.Value
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINIDES", SqlDbType.DateTime).Value = DtpFechaPrimerPag.Value
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@CUOTASDESEADAS", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
            DiasP = ds.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
        Return DiasP
    End Function
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
    Private Function Programacion(ByVal a_BD As Boolean) As Integer
        Dim Saldo As Double = CDbl(TxtMonto.Text)
        Dim Cuota As Double = CDbl(Me.TxtCuota.Text)
        Dim FechaPago As DateTime = DtpFechaPrimerPag.Value
        Dim TasaInteres As Double = (Me.LblInteres.Text) / 100
        Dim Tasa_Seguro As Double = CDbl(Trim(LblSegDeuda.Text) / 100)
        Dim Periodo As Integer = IIf(Me.CbxPeriodo.SelectedValue = "MM", 30, 15)
        Dim InteresAcum As Double = 0
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = PrimerFechaPago()
        Dim i As Integer = 0
        While TablaProgs.Rows.Count > 0
            TablaProgs.Rows.RemoveAt(0)
        End While
        While Saldo > Cuota
            i += 1
            Interes = (Saldo * TasaInteres * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Cuota - Interes - Seguro
            Capital = Math.Round(Capital, 2, MidpointRounding.ToEven)
            If a_BD Then
                MantenimientoProgramacion(i, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum, 1)
            Else
                TablaProgs.Rows.Add(Compañia, 0, i, Me.CbxDeduccion.SelectedValue, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
            End If
            If Me.CbxPeriodo.SelectedValue = "QQ" Then
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
            DiasPP = Periodo
            Saldo -= Capital
        End While
        If Saldo > 0 Then
            i += 1
            Interes = (Saldo * TasaInteres * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Saldo
            Cuota = Saldo + Interes + Seguro
            If a_BD Then
                MantenimientoProgramacion(i, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum, 1)
            Else
                TablaProgs.Rows.Add(Compañia, 0, i, Me.CbxDeduccion.SelectedValue, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
            End If
        End If
        Return i
    End Function
    Private Sub ProgramacionCuota()
        Dim Saldo As Double = CDbl(TxtMonto.Text)
        Dim TotalCuotas As Double = 0
        Dim TasaInteres As Double = CDbl(LblInteres.Text / 100)
        Dim Tasa_Seguro As Double = CDbl(Trim(LblSegDeuda.Text) / 100)
        Dim Periodo As Integer = IIf(Me.CbxPeriodo.SelectedValue = "MM", 30, 15)
        Dim InteresAcum As Double = 0
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim Cuota As Double = 0
        Dim DiasPP As Integer = Periodo   'PrimerFechaPago()
        If TasaInteres > 0 Then
            Dim Inter_E As Double = CDbl(IIf(Me.CbxPeriodo.SelectedValue = "MM", TasaInteres / 12, TasaInteres / 24))
            Dim Factor0 As Double = (1 + Inter_E) ^ -NudNumeroCuot.Value
            Dim Factor1 As Double = IIf(Inter_E > 0, (1 - Factor0) / Inter_E, 0)
            Cuota = IIf(Factor1 > 0, CDbl(Saldo) / Factor1, 0)
            'Dim Cuota2 As Double = Cuota + (((Saldo * Tasa_Seguro) * Periodo) / 30)
        Else
            Cuota = IIf(Me.NudNumeroCuot.Value > 0, Saldo / Me.NudNumeroCuot.Value, 0)
        End If
        Cuota = Math.Round(Cuota, 2, MidpointRounding.ToEven)
        TxtCuota.Text = Math.Round(Cuota, 2, MidpointRounding.ToEven)
        For i As Integer = 1 To Me.NudNumeroCuot.Value
            Interes = (Saldo * TasaInteres * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            If i = Me.NudNumeroCuot.Value Then
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
            'MantenimientoProgramacion(i, DtpFechaPrimerPag.Value, Saldo, Capital, Interes, Seguro, Cuota + Seguro, Saldo - Capital, InteresAcum, 1)
            Saldo -= Capital
            TotalCuotas += Cuota + Seguro
        Next
        Me.TxtCuota.Text = Format(Math.Round(TotalCuotas / Me.NudNumeroCuot.Value, 2), "0.00")
    End Sub
    Private Sub SumarSeguro()
        Dim Seguro As Double = Func.leerDataeader("SELECT ISNULL(SUM(SEG_DEUDA),0) FROM COOPERATIVA_PROGRAMACION_ILUSTRATIVA WHERE COMPAÑIA=" & Compañia & " AND N_SOLICITUD=0", 0)
        Seguro = Math.Round(Seguro, 6) / NudNumeroCuot.Value
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET SEG_DEUDA=" & Seguro & ", CUOTA=CUOTA+" & Math.Round(Seguro, 2, MidpointRounding.ToEven) & " WHERE COMPAÑIA=" & Compañia & " AND N_SOLICITUD=0")
        TxtCuota.Text = Math.Round(TxtCuota.Text + Seguro, 2, MidpointRounding.ToEven)
    End Sub
    Private Sub SumarFechas()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Dias As Integer = 0
        Dim Diasx As Integer = 0
        Dim Contador As Integer = 0
        Dim Linea As Integer = 1
        Dim Fecha As DateTime = DtpFechaPrimerPag.Value
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 3 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & Compañia & "," & 0 & "," & 0
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                Dias = DataReader_Track.Item(0)
                While Contador < Dias
                    If Me.CbxPeriodo.SelectedValue = "MM" Then
                        Diasx = 30
                        If Linea = 1 Then
                            MantenimientoProgramacion(Linea, DtpFechaPrimerPag.Value, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        Else
                            MantenimientoProgramacion(Linea, Fecha, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        End If

                    End If
                    If Me.CbxPeriodo.SelectedValue = "QQ" Then
                        Diasx = 15
                        If Linea = 1 Then
                            MantenimientoProgramacion(Linea, DtpFechaPrimerPag.Value, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        Else
                            MantenimientoProgramacion(Linea, Fecha, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        End If
                    End If
                    Linea = Linea + 1
                    Contador = Contador + 1
                    Select Case Me.CbxPeriodo.SelectedValue
                        Case "QQ"
                            Select Case Fecha.Day.ToString
                                Case "15"
                                    Fecha = DateAdd("d", 15, Fecha)
                                    If Fecha.Day.ToString = "2" Then
                                        Fecha = CDate("28/02/" + Fecha.Year.ToString)
                                    Else
                                        If Fecha.Day.ToString = "1" Then
                                            Fecha = CDate("29/02/" + Fecha.Year.ToString)
                                        End If
                                    End If
                                Case "28"
                                    Fecha = DateAdd("d", 15, Fecha)
                                Case "29"
                                    Fecha = DateAdd("d", 15, Fecha)
                                Case "30"
                                    If Fecha.Month.ToString = "12" Then
                                        Fecha = CDate("15/01/" & (Fecha.Year + 1).ToString)
                                    Else
                                        Fecha = CDate("15/" & (Fecha.Month + 1).ToString & "/" & Fecha.Year.ToString)
                                    End If
                            End Select
                        Case "MM"
                            If Fecha.Month.ToString = "2" And Fecha.Day.ToString = "28" Or Fecha.Day.ToString = "29" Then
                                Fecha = CDate("30/03/" + Fecha.Year.ToString)
                            Else
                                Fecha = DateAdd("m", 1, Fecha)
                            End If
                    End Select
                End While
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvProgramacion.Columns(0).Visible = False
        Me.DgvProgramacion.Columns(1).Visible = False
        Me.DgvProgramacion.Columns(3).Visible = False
        Me.DgvProgramacion.Columns(2).Width = 45
        Me.DgvProgramacion.Columns(4).Width = 100
        Me.DgvProgramacion.Columns(5).Width = 80
        Me.DgvProgramacion.Columns(6).Width = 80
        Me.DgvProgramacion.Columns(7).Width = 80
        Me.DgvProgramacion.Columns(8).Width = 65
        Me.DgvProgramacion.Columns(9).Width = 80
        Me.DgvProgramacion.Columns(10).Width = 80
        Me.DgvProgramacion.Columns(11).Width = 80
        Me.DgvProgramacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacion.Columns(5).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(6).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(7).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(8).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(9).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(10).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacion.Columns(11).DefaultCellStyle.Format = "###,##0.00"
    End Sub
    Private Sub FrmIlustrativoProgramacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Deducciones()
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        GuardarCuotasEspeciales(9)
        CargaPeriodos()
        CargaPeriodosEspeciales()
        CargaInteres()
        CrearTabla()
        Me.DtpFechaPago.Value = CDate("12/12/" & Me.DtpFechaPago.Value.Year.ToString())
        Me.DtpFechaIniPres.Value = Now()
        Iniciando = False
    End Sub

    Private Sub CbxDeduccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxDeduccion.SelectedIndexChanged
        If Iniciando = False Then
            CargaInteres()
        End If
    End Sub

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        Dim numCuotas As Integer = 0
        If Me.TxtCuota.Enabled = False And NudNumeroCuot.Value = 0 Then
            MessageBox.Show("Ingrese un número de cuotas válido", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NudNumeroCuot.Focus()
            Return
        End If
        If Me.NudNumeroCuot.Enabled = False And TxtCuota.Text = Nothing Then
            MessageBox.Show("Ingrese una cuota válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuota.Focus()
            Return
        End If
        If Me.TxtCuota.Text = "0" And Me.TxtCuota.Enabled = True Then
            MessageBox.Show("Ingrese una cuota válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuota.Focus()
            Return
        End If
        If Me.TxtMonto.Text = "0" Or Me.TxtMonto.Text = Nothing Then
            MessageBox.Show("Ingrese un monto válido", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMonto.Focus()
            Return
        End If
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.TxtMonto.Text) Then
            MessageBox.Show("La cuota no puede ser mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuota.Focus()
            Return
        End If
        If Me.DtpFechaIniPres.Value > DtpFechaPrimerPag.Value Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        'If DtpFechaPrimerPag.Value.Day = 15 Or DtpFechaPrimerPag.Value.Day = 30 Or DtpFechaPrimerPag.Value.Day = IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, 29, 28) Then
        If Me.TxtCuota.Text > 0 Then
            Programacion(True)
            MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        Else
            ProgramacionCuota()
            numCuotas = Programacion(False)
            While numCuotas <> Me.NudNumeroCuot.Value
                If Me.NudNumeroCuot.Value < numCuotas Then
                    Me.TxtCuota.Text = Val(Me.TxtCuota.Text) + 0.01
                Else
                    Me.TxtCuota.Text = Val(Me.TxtCuota.Text) - 0.01
                End If
                numCuotas = Programacion(False)
            End While
            Me.DgvProgramacion.DataSource = TablaProgs
            LimpiaGrid()
        End If
        Me.BtnNuevo.Enabled = True
        Me.BtnCalcular.Enabled = False
        For Each row As DataRow In TablaProgs.Rows
            MantenimientoProgramacion(row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1)
        Next
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        LimpiaGrid()
        'Else
        '    MessageBox.Show("Los días válidos a seleccionar son: 15," & IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, "29", "28") & ",30 ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DtpFechaPrimerPag.Focus()
        'End If
    End Sub

    Private Sub TxtCuota_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCuota.GotFocus
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        NudNumeroCuot.Enabled = False
        NudNumeroCuot.Value = 0
        Me.BtnCalcular.Enabled = True
    End Sub

    Private Sub TxtCuota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuota.KeyPress
        Dim cadena As String = TxtCuota.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        Dim cadena As String = TxtMonto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub FrmIlustrativoProgramacion_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        GuardarCuotasEspeciales(9)
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        GuardarCuotasEspeciales(9)
        MuestraProgramacionesCuotasEspeciales(0, 1)
        Total_CuotaEspecial()
        Me.TxtCuota.Enabled = True
        Me.NudNumeroCuot.Enabled = True
        Me.BtnCalcular.Enabled = False
        Me.NudNumeroCuot.Value = 0
        Me.TxtCuota.Text = Nothing
        Me.TxtMonto.Text = Nothing
    End Sub

    Private Sub NudNumeroCuot_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NudNumeroCuot.GotFocus
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        Me.TxtCuota.Text = 0
        Me.TxtCuota.Enabled = False
        Me.BtnCalcular.Enabled = True
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.DgvProgramacion.RowCount <> 0 Or Me.DgvProgramacionesEspeciales.Rows.Count <> 0 Then
            ProgramacionImprimir(Compañia, CbxDeduccion.Text, NudNumeroCuot.Value, CDbl(TxtMonto.Text), CbxPeriodo.Text, DtpFechaIniPres.Value, DtpFechaPrimerPag.Value, CDbl(LblInteres.Text), CDbl(LblSegDeuda.Text), 1)
        Else
            MsgBox("¡Debe Calcular Primero la programación !", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub FrmProgramacion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub SetearFechas()
        Dim Fecha As Date = Me.DtpFechaPrimerPag.Value
        If Me.DtpFechaPrimerPag.Value.Day <= 15 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Me.DtpFechaPrimerPag.Value.Day > 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.DtpFechaPrimerPag.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.DtpFechaPrimerPag.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.DtpFechaPrimerPag.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        End If
    End Sub

    Private Sub DtpFechaPrimerPag_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'SetearFechas()
    End Sub

    Private Sub FechaInicial()
        Dim Fecha As Date = Now().Date
        If Fecha.Day <= 11 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 11 And Fecha.Day <= 27 And Fecha.Day <> 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.DtpFechaPrimerPag.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.DtpFechaPrimerPag.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.DtpFechaPrimerPag.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        ElseIf Fecha.Day > 27 And Fecha.Day <= 31 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString).AddMonths(1)
        End If
    End Sub

    Private Sub MuestraProgramacionesCuotasEspeciales(ByVal Linea, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_CUOTAS_ESPECIALES " & Compañia & ",0," & Linea & "," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            If Bandera = 1 Then
                Table = New DataTable("Datos")
                DataAdapter_.Fill(Table)
                Me.DgvProgramacionesEspeciales.DataSource = Table
            End If
            If Bandera = 2 Then
                Comando_Track.ExecuteNonQuery()
            End If
            LimpiaGridCuotasEspeciales()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGridCuotasEspeciales()
        Me.DgvProgramacionesEspeciales.Columns(0).Width = 0
        Me.DgvProgramacionesEspeciales.Columns(1).Visible = False
        Me.DgvProgramacionesEspeciales.Columns(2).Width = 45
        Me.DgvProgramacionesEspeciales.Columns(3).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(4).Width = 70
        Me.DgvProgramacionesEspeciales.Columns(5).Width = 70
        Me.DgvProgramacionesEspeciales.Columns(6).Width = 70
        Me.DgvProgramacionesEspeciales.Columns(7).Width = 70
        Me.DgvProgramacionesEspeciales.Columns(8).Width = 70
        Me.DgvProgramacionesEspeciales.Columns(9).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(10).Width = 85
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim FechActual As DateTime = Now()
        Dim Fecha As DateTime = DtpFechaPago.Value
        Dim Cuota As Double
        Dim Suma As Double
        Dim Resta As Double
        Cuota = CDbl(Val(Me.TxtCuotaEspecial.Text))
        Suma = Cuota + (Val(Me.TxtTotalCuotasEspeciales.Text))
        If Val(Me.TxtCuotaEspecial.Text) < 0.01 Or Me.TxtCuotaEspecial.Text = Nothing Then
            MessageBox.Show("Monto de la cuota especial no es válido", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuotaEspecial.Focus()
            Return
        End If
        If Me.DgvProgramacion.RowCount <> 0 Then
            MessageBox.Show("No puede ingresar una cuota especial por que ya calculó cuotas normales" & Chr(13) & "Debe Ingresar primero las cuotas Especiales, luego calcular las cuotas normales", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuotaEspecial.Focus()
            Return
        End If
        If Cuota > CDbl(Val(Me.TxtMonto.Text)) Then
            MessageBox.Show("Monto de la cuota especial Sobre pasa al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuotaEspecial.Focus()
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(Fecha.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha de pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        If CDate(Fecha.ToShortDateString) < CDate(FechActual.ToShortDateString) Then
            MessageBox.Show("La fecha de pago no puede ser menor que la fecha actual", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaPago.Focus()
            Return
        End If
        'BONIFICACION
        If Me.CbxPeriodoEspeciales.SelectedValue = "BO" Then
            If Fecha.Month.ToString = "6" And Fecha.Day.ToString = "12" Then
                MantenimientoCuotasEspeciales(2)
                MuestraProgramacionesCuotasEspeciales(0, 1)
                Resta = CDbl(Val(Me.TxtMonto.Text)) - Cuota
                Me.TxtMonto.Text = Resta
                If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                    Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnCalcular.Enabled = True
                End If
                Total_CuotaEspecial()
            Else
                MessageBox.Show("La fecha válida para programar cuotas de Bonificación es :12 de Junio xxxx ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        'AGUINALDO
        If Me.CbxPeriodoEspeciales.SelectedValue = "AG" Then
            If Fecha.Month.ToString = "12" And Fecha.Day.ToString = "12" Then
                MantenimientoCuotasEspeciales(2)
                MuestraProgramacionesCuotasEspeciales(0, 1)
                Resta = CDbl(Val(Me.TxtMonto.Text)) - Cuota
                Me.TxtMonto.Text = Resta
                If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                    Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnCalcular.Enabled = True
                End If
                Total_CuotaEspecial()
            Else
                MessageBox.Show("La fecha válida para programar cuotas de Aguinaldo es :12 de Diciembre xxxx ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub Total_CuotaEspecial()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @NUMERO_SOLICITUD = 0," & vbCrLf
            Sql &= " @BANDERA = 1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                TxtTotalCuotasEspeciales.Text = DataReader_Track.Item(0)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MantenimientoCuotasEspeciales(ByVal Bandera)
        Dim Monto As Double = CDbl(Val(TxtCuotaEspecial.Text))
        Dim TasaInteres As Double = CDbl(Trim(LblInteres.Text) / 100)
        Dim TasaSeguro As Double = CDbl(Trim(LblSegDeuda.Text) / 100)
        Dim InteresPrimero As Double = 0
        Dim SegDeudaPrimero As Double = 0
        Dim Cuota As Double = 0
        Dim DiasPP As Integer
        DiasPP = DiasInteresCuotasEspeciales()
        'Saca la Cuota Previa
        InteresPrimero = (Val(TxtCuotaEspecial.Text) * TasaInteres * DiasPP) / 360
        InteresPrimero = Math.Round(InteresPrimero, 2, MidpointRounding.AwayFromZero)
        SegDeudaPrimero = (Val(TxtCuotaEspecial.Text) * TasaSeguro * DiasPP) / 30
        SegDeudaPrimero = Math.Round(SegDeudaPrimero, 2, MidpointRounding.AwayFromZero)
        Cuota = CDbl(Val(TxtCuotaEspecial.Text) + InteresPrimero + SegDeudaPrimero)
        Cuota = Math.Round(Cuota, 2, MidpointRounding.AwayFromZero)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@NUMERO_SOLICITUD = 0" & vbCrLf
            Sql &= ",@LINEA = 0" & vbCrLf
            Sql &= ",@ENVIADA = 0" & vbCrLf
            Sql &= ",@RECIBIDA = 0" & vbCrLf
            Sql &= ",@FECHA_PAGO = '" & Format(DtpFechaPago.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@SALDO_INI = " & Me.TxtMonto.Text & vbCrLf
            Sql &= ",@CAPITAL = " & TxtCuotaEspecial.Text & vbCrLf
            Sql &= ",@CAPITAL_D = 0" & vbCrLf
            Sql &= ",@INTERES = " & InteresPrimero & vbCrLf
            Sql &= ",@INTERES_D = 0" & vbCrLf
            Sql &= ",@SEG_DEUDA = " & SegDeudaPrimero & vbCrLf
            Sql &= ",@SEG_DEUDA_D = 0" & vbCrLf
            Sql &= ",@CUOTA = " & Cuota & vbCrLf
            Sql &= ",@CUOTA_D = 0" & vbCrLf
            Sql &= ",@SALDO_FIN = " & (Val(Me.TxtMonto.Text) + Val(TxtCuotaEspecial.Text)) & vbCrLf
            Sql &= ",@INTERES_ACUM = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@BANDERA = " & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function DiasInteresCuotasEspeciales() As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI ", Conexion_Track)
        Dim ds As New DataSet
        Dim DiasInteres As Integer
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = 2
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINICIO", SqlDbType.DateTime).Value = DtpFechaIniPres.Value
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINIDES", SqlDbType.DateTime).Value = DtpFechaPago.Value
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@CUOTASDESEADAS", SqlDbType.Int).Value = Val(NudNumeroCuot.Value)
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
            DiasInteres = ds.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
        Return DiasInteres
    End Function

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim Suma As Double
        Dim Valor As Double
        If DgvProgramacionesEspeciales.RowCount <> 0 Then
            MuestraProgramacionesCuotasEspeciales(DgvProgramacionesEspeciales.CurrentRow.Cells(2).Value, 2)
            Valor = DgvProgramacionesEspeciales.CurrentRow.Cells(5).Value
            MuestraProgramacionesCuotasEspeciales(0, 1)
            Suma = CDbl(Val(Me.TxtMonto.Text)) + Valor
            Me.TxtMonto.Text = Suma
            If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                Me.BtnCalcular.Enabled = False
            Else
                Me.BtnCalcular.Enabled = True
            End If
            Total_CuotaEspecial()
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargaPeriodosEspeciales()
        Dim jClass As New jarsClass
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION_ESPECIALES @COMPAÑIA = " & Compañia
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            CbxPeriodoEspeciales.DataSource = Table
            CbxPeriodoEspeciales.ValueMember = "PERIODO"
            CbxPeriodoEspeciales.DisplayMember = "DESCRIPCION_PERIODO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CbxPeriodoEspeciales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxPeriodoEspeciales.SelectedIndexChanged
        If Not Iniciando Then
            If Me.CbxPeriodoEspeciales.SelectedValue = "AG" Then
                If Now < CDate("12/12/" & Me.DtpFechaPago.Value.Year.ToString()) Then
                    Me.DtpFechaPago.Value = CDate("12/12/" & Me.DtpFechaPago.Value.Year.ToString())
                Else
                    Me.DtpFechaPago.Value = CDate("12/12/" & Me.DtpFechaPago.Value.AddYears(1).Year.ToString())
                End If
            Else
                If Now < CDate("12/06/" & Me.DtpFechaPago.Value.Year.ToString()) Then
                    Me.DtpFechaPago.Value = CDate("12/06/" & Me.DtpFechaPago.Value.Year.ToString())
                Else
                    Me.DtpFechaPago.Value = CDate("12/06/" & Me.DtpFechaPago.Value.AddYears(1).Year.ToString())
                End If
            End If
        End If
    End Sub

    Private Sub GuardarCuotasEspeciales(ByVal Bandera As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @NUM_SOLICITUD = 0," & vbCrLf
            Sql &= " @LINEA = 0," & vbCrLf
            Sql &= " @FECHA_PAGO = '" & Format(Now, "dd/MM/yyyy") & "'," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @BANDERA = " & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ProgramacionImprimir(ByVal Compañia, ByVal Deduccion, ByVal Num_Cuota, ByVal Monto, ByVal Periodo, ByVal Fecha_IniPres, ByVal FechaPrimerPag, ByVal TasaInt, ByVal InteresSeg, ByVal Bandera)
        Dim Table As DataTable
        Dim Lineas As Integer
        Dim numCuotas As Integer
        Dim interesAcum As Double = 0
        Dim Rpt As New CooperativaProgIlustrativa
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_RPT "
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ",@N_SOLICITUD = " & 0
            Sql &= ",@NOM_DEDUCCION = '" & Deduccion & "'"
            Sql &= ",@NUM_CUOTA = " & Num_Cuota
            Sql &= ",@MONTO = " & Monto
            Sql &= ",@PERIODO = '" & Periodo & "'"
            Sql &= ",@FECHA_INIPRES =  '" & Format(Fecha_IniPres, "dd-MM-yyyy") & "'"
            Sql &= ",@FECHA_PRIMERPAG = '" & Format(FechaPrimerPag, "dd-MM-yyyy") & "'"
            Sql &= ",@TASA_INTERES = " & TasaInt
            Sql &= ",@INTERES_SEG = " & InteresSeg
            Sql &= ",@BANDERA = " & Bandera
            Table = Func.obtenerDatos(New SqlCommand(Sql))
            If Table.Rows.Count > 0 Then
                Lineas = Table.Rows(Table.Rows.Count - 1).Item("LINEA")
                numCuotas = Table.Rows(Table.Rows.Count - 1).Item("NUMERO DE CUOTAS")
                interesAcum = Table.Rows(Table.Rows.Count - 1).Item("INTERES_ACUM")
            End If
            If Me.DgvProgramacionesEspeciales.Rows.Count > 0 Then
                For Each row As DataGridViewRow In Me.DgvProgramacionesEspeciales.Rows
                    Lineas += 1
                    interesAcum += row.Cells("Interés").Value
                    Table.Rows.Add(Compañia, 0, Lineas, CbxDeduccion.SelectedValue, row.Cells("Fecha Pago").Value, row.Cells("Saldo Inicial").Value, row.Cells("Capital").Value, row.Cells("Interés").Value, row.Cells("Interés Seguro").Value, row.Cells("Cuota").Value, (row.Cells("Saldo Inicial").Value - row.Cells("Capital").Value), interesAcum, "", Now, "", Now, numCuotas, Me.TxtMonto.Text, Me.CbxPeriodo.Text, Me.DtpFechaIniPres.Value, Me.DtpFechaPrimerPag.Value, Me.LblInteres.Text, Me.LblSegDeuda.Text, Deduccion)
                Next
            End If
            Dim MyTable As New DataTable
            Dim MyRows As DataRow() = Table.Select(Nothing, "FECHA_PAGO")
            MyTable = Table.Clone
            For i As Integer = 0 To MyRows.Length - 1
                MyRows(i).Item("LINEA") = i + 1
                MyTable.ImportRow(MyRows(i))
            Next
            Rpt.SetDataSource(MyTable)
            Rpts.CrvCooReporte.ReportSource = Rpt
            Rpts.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tpNormales_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tpNormales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub tpEspeciales_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tpEspeciales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class