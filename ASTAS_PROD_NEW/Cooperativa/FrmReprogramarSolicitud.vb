Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReprogramarSolicitud
    Public Compañia_Value As Integer
    Public NumSolicitud_Value As Integer
    Public Linea_Value As Integer
    Public Periodo_Value As String
    Public InteresAcum_value As Double
    Public InteresSeguro_Value As Double
    Public Interes_Value As Double
    Public SaldoIni_Value As Double
    Public SaldoFin_Value As Double
    Public Cuota_Value As Double
    Public Automatic As Boolean = False
    Dim Procesado As Boolean = False
    Dim Sql As String
    Dim Func As New jarsClass
    Dim TablaProgs As New DataTable
    Private fechaInicio As String
    Private Sub setFechaInicio()
        Dim Fecha As Date = Format(CDate(getUltimaFechaPago()), "Short Date")  ' 'Me.DtpFechaPrimerPag.Value
        Me.DtpFechaIniPres.Value = Now

        Fecha = DateAdd(DateInterval.Day, 1, Fecha)
    
        Me.DtpFechaIniPres.Value = Format(Fecha.ToString, "Short Date")
       
    End Sub
    Private Sub setOrigen()
        Origen = Func.obtenerEscalar("select ORIGEN from COOPERATIVA_CATALOGO_SOCIOS where COMPAÑIA=" & Compañia & " and CODIGO_EMPLEADO_AS='" & Trim(Me.TxtCodigoAs.Text) & "' and CODIGO_EMPLEADO=" & Trim(Me.TxtCodigoBuxis.Text))
    End Sub

    Private Sub FrmReprogramarSolicitud_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CUOTA_D = 1 WHERE COMPAÑIA = " & Compañia & " AND CAPITAL_D = 0 AND NUMERO_SOLICITUD = " & Me.txtNoSolicitud.Text
        Func.ejecutarComandoSql(New SqlCommand(Sql))
    End Sub
    Private Sub FrmReprogramarSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtNoSolicitud.Text = NumSolicitud_Value
        carga()
    End Sub
    Private Sub carga()
        SetearFechas()
        CargaPeriodos()
        CargaDetalleProgramaciones()
        Deducciones()
        setOrigen()
        setTasasInteres()
        CargaPeriodosEspeciales()
        Me.txtMonto.Text = Me.TxtCapital.Text
        bloqueaControlesReprogra()
        CrearTabla()
        setFechaInicio()
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
    Private Sub bloqueaControlesReprogra()
        Me.RadioButton1.Enabled = False
        Me.RadioButton2.Enabled = False
        Me.CbxPeriodo.Enabled = False
        Me.DtpFechaIniPres.Enabled = False
        Me.DtpFechaPrimerPag.Enabled = False
        Me.BtnAgregar.Enabled = False
        Me.BtnEliminar.Enabled = False
    End Sub
    Private Sub desbloqueControlesReprogra()
        Me.RadioButton1.Enabled = True
        Me.RadioButton2.Enabled = True
        Me.CbxPeriodo.Enabled = True
        Me.DtpFechaIniPres.Enabled = True
        Me.DtpFechaPrimerPag.Enabled = True
        Me.BtnAgregar.Enabled = True
        Me.BtnEliminar.Enabled = True
    End Sub
    Private Sub setTasasInteres()
        Me.LblInteres.Text = getTasaInteres()
        Me.LblSegDeuda.Text = getTasaSeguro()
    End Sub
    Private Function getTasaSeguro()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Dim Valor As Double = 0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT INTERES FROM COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO WHERE COMPAÑIA=" & compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            If Table.Rows.Count > 0 Then
                If Origen = 5 Or Origen = 6 Then
                    If CbxDeduccion.SelectedValue = CInt(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")) Then
                        Valor = Format(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 30"), "0.000")
                    Else
                        Valor = Table.Rows(0).Item(0)
                    End If
                Else
                    Valor = Table.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Function getTasaInteres()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Valor As Double = 0
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES where COMPAÑIA=" & compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            If Table.Rows.Count > 0 Then
                Valor = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Sub Deducciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT CCD.DEDUCCION, CS.DESCRIPCION_SOLICITUD, CS.CUOTA_INICIAL, CS.CUOTA_FINAL " & vbCrLf
            Sql &= "FROM COOPERATIVA_SOLICITUDES CCD " & vbCrLf
            Sql &= "INNER JOIN COOPERATIVA_CATALOGO_SOLICITUDES CS " & vbCrLf
            Sql &= "ON CS.SOLICITUD = CCD.SOLICITUD " & vbCrLf
            Sql &= "WHERE CCD.COMPAÑIA = " & compañia & vbCrLf
            Sql &= "  AND CCD.CORRELATIVO = " & Me.txtNoSolicitud.Text
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "DEDUCCION"
            Me.CbxDeduccion.DisplayMember = "DESCRIPCION_SOLICITUD"
            Me.NudNumeroCuot.Minimum = Table.Rows(0).Item("CUOTA_INICIAL")
            Me.NudNumeroCuot.Maximum = Table.Rows(0).Item("CUOTA_FINAL")
            Me.NudNumeroCuot.Value = Table.Rows(0).Item("CUOTA_FINAL")
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function esPrestamo()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Dim totalReg As Integer
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()

            Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
            Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
            Sql &= "inner join COOPERATIVA_SOLICITUDES_PRESTAMOS csp "
            Sql &= "on csp.DEDUCCION=ccd.DEDUCCION "
            Sql &= "where ccd.COMPAÑIA=" & compañia
            Sql &= "and csp.CORRELATIVO=" & Me.txtNoSolicitud.Text
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            DataReader_Track = Comando_Track.ExecuteReader
            totalReg = Table.Rows.Count
            If (totalReg > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return False
    End Function
    Private Sub SetearFechas()
        Dim Fecha As Date = Me.DtpFechaPrimerPag.Value
        If Me.DtpFechaPrimerPag.Value.Day <= 11 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Me.DtpFechaPrimerPag.Value.Day > 11 And Me.DtpFechaPrimerPag.Value.Day <= 27 And Me.DtpFechaPrimerPag.Value.Day <> 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.DtpFechaPrimerPag.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.DtpFechaPrimerPag.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.DtpFechaPrimerPag.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        ElseIf Me.DtpFechaPrimerPag.Value.Day > 27 And Me.DtpFechaPrimerPag.Value.Day <= 31 And Me.DtpFechaPrimerPag.Value.Day <> 30 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString).AddMonths(1)
        End If
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
            Sql = "Execute Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION " & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            CbxPeriodo.DataSource = Table
            CbxPeriodo.ValueMember = "PERIODO"
            CbxPeriodo.DisplayMember = "DESCRIPCION_PERIODO"
            Conexion_Track.Close()
            CbxPeriodo.SelectedValue = "QQ"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CargaDetalleProgramaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & Me.txtNoSolicitud.Text & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            Me.DgvDetalleProgramaciones.Columns.Clear()
            DataAdapter.Fill(Table)
            Me.DgvDetalleProgramaciones.DataSource = Table
            LimpiaGridDetalle()
            Comando_Track.CommandText = "SELECT PERIODO FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.txtNoSolicitud.Text
            Periodo_Value = Comando_Track.ExecuteScalar.ToString
            If Periodo_Value = "QQ" Or Periodo_Value = "MM" Then
                Me.CbxPeriodo.SelectedValue = Periodo_Value
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub LimpiaGridDetalle()
        Me.DgvDetalleProgramaciones.Columns(0).Width = 50
        Me.DgvDetalleProgramaciones.Columns(1).Width = 50
        Me.DgvDetalleProgramaciones.Columns(2).Width = 95
        Me.DgvDetalleProgramaciones.Columns(3).Width = 75
        Me.DgvDetalleProgramaciones.Columns(4).Width = 75
        Me.DgvDetalleProgramaciones.Columns(5).Width = 57
        Me.DgvDetalleProgramaciones.Columns(6).Width = 75
        Me.DgvDetalleProgramaciones.Columns(7).Width = 57
        Me.DgvDetalleProgramaciones.Columns(8).Width = 75
        Me.DgvDetalleProgramaciones.Columns(9).Width = 57
        Me.DgvDetalleProgramaciones.Columns(10).Width = 75
        Me.DgvDetalleProgramaciones.Columns(11).Width = 57
        Me.DgvDetalleProgramaciones.Columns(12).Width = 75
        Me.DgvDetalleProgramaciones.Columns(13).Width = 75
        Me.DgvDetalleProgramaciones.Columns(14).Width = 57
        Me.DgvDetalleProgramaciones.Columns(15).Width = 57
        Me.DgvDetalleProgramaciones.Columns(16).Visible = False
    End Sub
    Private Sub CargaPeriodosEspeciales()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION_ESPECIALES " & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            CbxPeriodoEspeciales.DataSource = Table
            CbxPeriodoEspeciales.ValueMember = "PERIODO"
            CbxPeriodoEspeciales.DisplayMember = "DESCRIPCION_PERIODO"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        Dim numCuotas As Integer = 0
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        Dim Fecha As DateTime = FechaActual()
        If (Not (Me.RadioButton1.Checked Or Me.RadioButton2.Checked)) Then
            MessageBox.Show("Se debe seleccionar el tipo de programación (cuota o numero de cuotas) a realizar.", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Val(Me.TxtCapital.Text)) = 0 Then
            MessageBox.Show("Monto no válido para calcular programación", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If TxtCuota.Enabled = True And (TxtCuota.Text = Nothing Or TxtCuota.Text = 0) Then
            MessageBox.Show("Cuota no válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If NudNumeroCuot.Enabled = True And NudNumeroCuot.Value = Nothing And NudNumeroCuot.Value = 0 Then
            MessageBox.Show("El número de Cuotas no es válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.TxtCapital.Text) Then
            MessageBox.Show("La cuota es mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        If DtpFechaPrimerPag.Value.Day = 15 Or DtpFechaPrimerPag.Value.Day = 30 Or DtpFechaPrimerPag.Value.Day = IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, 29, 28) Then
            If Me.RadioButton1.Checked Then
                Programacion(True)
                MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
            ElseIf Me.RadioButton2.Checked Then
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
            Else
                Return
            End If
            Me.BtnNuevo.Enabled = True
            Me.BtnCalcular.Enabled = False
            For Each row As DataRow In TablaProgs.Rows
                MantenimientoProgramacion(row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1)
            Next
            MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
            LimpiaGrid()
        Else
            MessageBox.Show("Los días válidos a seleccionar son: 15," & IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, "29", "28") & ",30 ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaPrimerPag.Focus()
        End If

        Me.BtnGuardar.Enabled = True
    End Sub

    Private Function Programacion(ByVal a_BD As Boolean) As Integer
        Dim Saldo As Double = CDbl(Me.txtMonto.Text)
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
        Dim Saldo As Double = CDbl(Me.txtMonto.Text)
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
        Dim Linea As Integer = getLineaMinIlustrativa() '= 1
        Dim Fecha As DateTime = DtpFechaPrimerPag.Value
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 3 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & compañia & "," & Trim(Val(Me.txtNoSolicitud.Text)) & "," & NudNumeroCuot.Value
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                Dias = DataReader_Track.Item(0)
                While Contador < Dias
                    If Me.CbxPeriodo.SelectedValue = "MM" Then
                        Diasx = 30
                        If Linea = getLineaMinIlustrativa() Then 'Linea = 1 
                            MantenimientoProgramacion(Linea, DtpFechaPrimerPag.Value, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        Else
                            MantenimientoProgramacion(Linea, Fecha, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 4)
                        End If

                    End If
                    If Me.CbxPeriodo.SelectedValue = "QQ" Then
                        Diasx = 15
                        If Linea = getLineaMinIlustrativa() Then '=1 Then
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
    Private Sub NuevaCuota()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 4 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & compañia & "," & Trim(Val(txtNoSolicitud.Text)) & "," & NudNumeroCuot.Value
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                TxtCuota.Text = Format(DataReader_Track.Item("CUOTA_NUEVA"), ".00")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Total_CuotaEspecial()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & compañia & "," & Me.txtNoSolicitud.Text & "," & 1
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
    Private Sub MantenimientoProgramacionEncabezado()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & vbCrLf
            Sql &= "@COMPAÑIA  = " & compañia & "," & vbCrLf
            Sql &= "@NUM_SOLICITUD = " & CInt(Me.txtNoSolicitud.Text) & "," & vbCrLf
            Sql &= "@DEDUCCION = " & CbxDeduccion.SelectedValue & "," & vbCrLf
            Sql &= "@NUM_CUOTAS = " & NudNumeroCuot.Value & "," & vbCrLf
            Sql &= "@CUOTA = " & Trim(Me.TxtCuota.Text) & "," & vbCrLf
            Sql &= "@MONTO = " & Me.TxtCapital.Text & "," & vbCrLf
            Sql &= "@PERIODO   = '" & CbxPeriodo.SelectedValue & "'," & vbCrLf
            Sql &= "@INI_PRESTAMO = '" & Format(DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss") & "'," & vbCrLf
            Sql &= "@FECHA_PIMERPAG = '" & Format(DtpFechaPrimerPag.Value, "dd-MM-yyyy HH:mm:ss") & "'," & vbCrLf
            Sql &= "@TASA_INTERES = " & LblInteres.Text & "," & vbCrLf
            Sql &= "@TASA_INTERES_SEG = " & LblSegDeuda.Text & "," & vbCrLf
            Sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= "@BANDERA =  2"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MantenimientoProgramacionDetalle()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & vbCrLf
            Sql &= "@COMPAÑIA = " & compañia & "," & vbCrLf
            Sql &= "@NUM_SOLICITUD = " & Val(Me.txtNoSolicitud.Text) & "," & vbCrLf
            Sql &= "@LINEA = 0," & vbCrLf
            Sql &= "@FECHA_PAGO = '" & Format(Now, "dd/MM/yyyy") & "'," & vbCrLf
            Sql &= "@USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= "@BANDERA = 1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub GuardarCuotasEspeciales(ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Dim Linea As Integer
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT ISNULL(MAX(LINEA), 0) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & Me.txtNoSolicitud.Text
            Linea = Func.obtenerEscalar(Sql)
            Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_CUOTAS_ESPECIALES SET LINEA = LINEA + " & Linea & " WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & Me.txtNoSolicitud.Text
            Func.Ejecutar_ConsultaSQL(Sql)
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," _
            & CInt(Me.txtNoSolicitud.Text) & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub GuardarVariasCuotasEspeciales(ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLUCITUDES_DETALLE_ESPECIALES_IUD " & compañia & "," _
            & CInt(Me.txtNoSolicitud.Text) & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
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
        Dim Sql As String
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & compañia & "," _
            & Val(txtNoSolicitud.Text) & "," & 0 & "," & 0 & "," & 0 & ",'" & Format(DtpFechaPago.Value, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & Val(TxtCuotaEspecial.Text) & "," & 0 & "," & InteresPrimero & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    'Cuotas especiales para intereses pendientes
    Private Sub MantenimientoCuotasEspecialesPendientes(ByVal Bandera)
        Dim Monto As Double = CDbl(Val(TxtCuotaEspecial.Text))
        Dim TasaInteres As Double = 0
        Dim TasaSeguro As Double = 0
        Dim InteresPrimero As Double = 0
        Dim SegDeudaPrimero As Double = 0
        Dim Cuota As Double = 0
        Dim DiasPP As Integer
        Dim Sql As String
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & compañia & "," _
            & Val(txtNoSolicitud.Text) & "," & 0 & "," & 0 & "," & 0 & ",'" & Format(DtpFechaPago.Value, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & Val(TxtCuotaEspecial.Text) & "," & 0 & "," & InteresPrimero & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = Trim(Val(Me.txtNoSolicitud.Text))
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
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)

        GuardarCuotasEspeciales(9)
        Me.BtnGuardar.Enabled = False
        Me.BtnCalcular.Enabled = True
        Me.TxtCuota.Text = "0.00"

        desbloqueControlesReprogra()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.TxtCuota.Enabled = True
            Me.NudNumeroCuot.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked Then
            Me.TxtCuota.Enabled = False
            Me.TxtCuota.Text = 0
            Me.NudNumeroCuot.Enabled = True
        End If
    End Sub
    Private Function FechaActual() As Date
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Fecha As Date
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR'" & 0 & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DataAdapter_.Fill(DS)
            Fecha = DS.Tables(0).Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Fecha
    End Function
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(txtNoSolicitud.Text))
            DataAdapter.SelectCommand.Parameters.Add("@CUOTASDESEADAS", SqlDbType.Int).Value = NudNumeroCuot.Value
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(txtNoSolicitud.Text))
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            'setFechaInicio()
            'No hay  cuotas especiales                
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount = 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtNoSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    eliminaProgramacionesNoDescontadas() 'Eliminar no descontadas
                    MantenimientoProgramacionEncabezado()
                    MantenimientoProgramacionDetalle()
                    Me.BtnGuardar.Enabled = False
                    Me.BtnCalcular.Enabled = False
                    Me.TxtCuota.Enabled = False
                    Me.NudNumeroCuot.Enabled = False
                    Me.BtnNuevo.Enabled = False
                    'Me.btnImprimir.Enabled = True
                    Me.BtnAgregar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                    MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Return
                End If
            End If
            'No hay  cuotas  “Normales”               
            If DgvProgramacionesEspeciales.RowCount <> 0 And DgvProgramacion.RowCount = 0 And CDbl(Val(Me.TxtCapital.Text)) = 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtNoSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    eliminaProgramacionesNoDescontadas() 'Eliminar no descontadas
                    MantenimientoProgramacionEncabezado()
                    GuardarVariasCuotasEspeciales(1)
                    GuardarCuotasEspeciales(9)
                    Me.BtnGuardar.Enabled = False
                    Me.BtnCalcular.Enabled = False
                    Me.TxtCuota.Enabled = False
                    Me.NudNumeroCuot.Enabled = False
                    Me.BtnNuevo.Enabled = False
                    'Me.btnImprimir.Enabled = True
                    Me.BtnAgregar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                    MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Return
                End If
            End If
            'Hay  cuotas  “Normales”   y Especiales            
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount <> 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtNoSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    eliminaProgramacionesNoDescontadas() 'Eliminar cuotas no descontadas
                    MantenimientoProgramacionEncabezado()
                    MantenimientoProgramacionDetalle()
                    GuardarVariasCuotasEspeciales(1)
                    GuardarCuotasEspeciales(9)
                    Me.BtnGuardar.Enabled = False
                    Me.BtnCalcular.Enabled = False
                    Me.TxtCuota.Enabled = False
                    Me.NudNumeroCuot.Enabled = False
                    Me.BtnNuevo.Enabled = False
                    'Me.btnImprimir.Enabled = True
                    Me.BtnAgregar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                    MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Close()
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox("¡No puede guardar la programación, favor verificar Datos !", MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub
    Private Function getLineaMax()
        Dim Saldo As Double = CDbl(Me.TxtCuotaEspecial.Text)
        Dim Cuota As Double = CDbl(Me.txtCanCuotaEspecial.Text)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select MAX(linea) as ultima from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.txtNoSolicitud.Text & " AND COMPAÑIA=" & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Return Table.Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return 0
    End Function
    Private Function getLineaMaxNoDescontada()
        'Devuelve el numero de linea maximo de la s cuotas no descontadas
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select ISNULL(MAX(linea),0) as ultima from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD = " & Me.txtNoSolicitud.Text
            Sql &= " And Compañia = " & compañia & " and CAPITAL_D=1 and INTERES_D=1 and SEG_DEUDA_D=1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Return Table.Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return 0
    End Function
    Private Function getLineaMinIlustrativa()
        'Devuelve el numero de la primera linea de la programacion demostrativa actual
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select MIN(linea) as primera from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD = " & Me.txtNoSolicitud.Text
            Sql &= " And Compañia = " & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Return Table.Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return 0
    End Function
    Private Function getTotalLineas()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select count(*) as total from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.txtNoSolicitud.Text & " AND COMPAÑIA=" & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Return Table.Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return 0
    End Function
    'Devuleve la ultima fecha de pago
    Private Function getUltimaFechaPago() As String
        Dim f1 As Date
        Dim fecha As String = Now
        Dim i As Integer
        Dim hayPago As Boolean = False

        For i = 0 To Me.DgvDetalleProgramaciones.Rows.Count - 1
            If Me.DgvDetalleProgramaciones.Rows(i).Cells(5).Value = True And Me.DgvDetalleProgramaciones.Rows(i).Cells(7).Value = True And Me.DgvDetalleProgramaciones.Rows(i).Cells(9).Value = True Then
                fecha = Me.DgvDetalleProgramaciones.Rows(i).Cells(2).Value
                hayPago = True
            End If
        Next

        If Not hayPago Then
            fecha = Me.DgvDetalleProgramaciones.Rows(0).Cells(2).Value
            f1 = CDate(fecha)
            fecha = DateAdd(DateInterval.Day, -1, f1).ToString
        End If

        Return fecha
    End Function
    Private Function getUltimaFecha()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select FECHA_PAGO from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where LINEA=" & getLineaMax() & " AND N_SOLICITUD=" & Me.txtNoSolicitud.Text & " AND COMPAÑIA=" & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Return Table.Rows(0).Item(0)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Now
    End Function
    Private Sub MuestraProgramacionesCuotasEspeciales(ByVal Linea, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_CUOTAS_ESPECIALES " & compañia & "," & Trim(Val(txtNoSolicitud.Text)) & "," & Linea & "," & Bandera
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
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim FechActual As DateTime = FechaActual()
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
        'Para las programaciones especiales que no son intereses pendientes
        'If (Me.chkInteSeg.Checked = False) Then
        If Cuota > CDbl(Val(Me.TxtCapital.Text)) Then
            MessageBox.Show("Monto de la cuota especial Sobrepasa al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuotaEspecial.Focus()
            Return
        End If
        'BONIFICACION
        If Me.CbxPeriodoEspeciales.SelectedValue = "BO" Then
            If Fecha.Month.ToString = "6" And Fecha.Day.ToString = "12" Then

                MantenimientoCuotasEspeciales(2)
                MuestraProgramacionesCuotasEspeciales(0, 1)
                Resta = CDbl(Val(Me.TxtCapital.Text)) - Cuota
                Me.TxtCapital.Text = Resta
                If CDbl(Val(Me.TxtCapital.Text)) = 0 Then
                    Me.BtnGuardar.Enabled = True
                    Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnGuardar.Enabled = False
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
                Resta = CDbl(Val(Me.TxtCapital.Text)) - Cuota
                Me.TxtCapital.Text = Resta
                If CDbl(Val(Me.TxtCapital.Text)) = 0 Then
                    Me.BtnGuardar.Enabled = True
                    Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnGuardar.Enabled = False
                    Me.BtnCalcular.Enabled = True
                End If
                Total_CuotaEspecial()
            Else
                MessageBox.Show("La fecha válida para programar cuotas de Aguinaldo es :12 de Diciembre xxxx ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim Suma As Double
        Dim Valor As Double
        If DgvProgramacionesEspeciales.RowCount <> 0 Then
            MuestraProgramacionesCuotasEspeciales(DgvProgramacionesEspeciales.CurrentRow.Cells(2).Value, 2)
            Valor = DgvProgramacionesEspeciales.CurrentRow.Cells(5).Value
            'valorInteres = DgvProgramacionesEspeciales.CurrentRow.Cells(6).Value
            'If (valorInteres <> 0) Then
            Suma = CDbl(Val(Me.TxtCapital.Text)) + Valor
            Me.TxtCapital.Text = Suma
            MuestraProgramacionesCuotasEspeciales(0, 1)
            Total_CuotaEspecial()
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub Insertar_SolicitudesN(ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_IU " & compañia & ",'" _
            & getNumSolicitud() & "'," & Me.CbxDeduccion.SelectedValue & "," & Me.txtNoSolicitud.Text & ",'" & (Me.TxtCodigoAs.Text) & "'," _
            & CInt(Me.TxtCodigoBuxis.Text) & ",'0','" & fechaInicio & "'," _
            & "0,'0','" & LblInteres.Text & "','" & CbxPeriodo.SelectedValue & "','" & Me.getTotalLineas - 1 & "','" & Usuario & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function getNumSolicitud()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select TIPO_SOLICITUD "
            Sql &= "from CATALOGO_SOLICITUDES "
            Sql &= "where CODIGO_DEDUCCION = " & Me.CbxDeduccion.SelectedValue & " AND COMPAÑIA='" & Compañia & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return 0
    End Function
    Private Sub ActualizarAutorizaciones(ByVal Autorizacion)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = CInt(Me.txtNoSolicitud.Text)
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = "CONSOLIDACIÓN (" & Me.txtNoSolicitud.Text & ")"
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Me.DtpFechaIniPres.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = "CONSOLIDACIÓN (" & Me.txtNoSolicitud.Text & ")"
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = "CONSOLIDACIÓN (" & Me.txtNoSolicitud.Text & ")"
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = Me.TxtCodigoAs.Text
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_BUXIS", SqlDbType.Int).Value = Me.TxtCodigoBuxis.Text
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_CREACION", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = Autorizacion
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub

    Private Sub setSolicitudPrestamos()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_PRESTAMOS_IU  "
            Sql = Sql & compañia & ",'" ' @COMPAÑIA int, 
            Sql = Sql & getNumSolicitud() & "'," '@SOLICITUD int,
            Sql = Sql & Me.CbxDeduccion.SelectedValue  '@DEDUCCION int,
            Sql = Sql & "," & Me.txtNoSolicitud.Text & ",'" '@CORRELATIVO int,
            Sql = Sql & (Me.TxtCodigoAs.Text) & "'," '@CODIGO_AS Nvarchar(6)
            Sql = Sql & CInt(Me.TxtCodigoBuxis.Text)             '@CODIGO_BUXIS int,
            Sql = Sql & ",'" & fechaInicio & "'," '@FECHA_SOLICITUD datetime,
            Sql = Sql & "'" & Usuario & "'," ' '@RECIBIDO Nvarchar(100),
            Sql = Sql & "'" & Usuario & "'," '@REVISADO Nvarchar(100),
            Sql = Sql & "0," '@AUTORIZACION_EX bit,
            Sql = Sql & "'" & Me.TxtCapital.Text & "',"  '@CANTIDAD Money,
            Sql = Sql & "'CONSOLIDACIÓN','" '@RAZON NVARCHAR(100),
            Sql = Sql & Me.LblInteres.Text '      @INTERES Money,
            Sql = Sql & "','" & CbxPeriodo.SelectedValue '@PERIODO nvarchar(50),
            Sql = Sql & "'," & Me.getTotalLineas - 1 '@PLAZO int,
            Sql = Sql & ",0," '      @PRIMER_QUINCENA Bit,
            Sql = Sql & "'Reprogramacion (" & Me.txtNoSolicitud.Text & ")'," '@OBSERVACIONES Nvarchar(150),"
            Sql = Sql & "0," '      @CODIGO_ASFI Nvarchar(6),
            Sql = Sql & "0," '@CODIGO_BUXISFI Int,
            Sql = Sql & "0," '      @CODIGO_ASFI2 Nvarchar(6),
            Sql = Sql & "0," '      @CODIGO_BUXISFI2 Int,
            Sql = Sql & "0," '      @CODIGO_ASFI3 Nvarchar(6),
            Sql = Sql & "0," '      @CODIGO_BUXISFI3 Int,
            Sql = Sql & "'" & Usuario & "'" '      @USUARIO varchar(12)
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub setSolicitudRemesa(ByVal Bandera As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS_IUD "
            Sql &= Compañia & "," ' @COMPAÑIA int, 
            Sql &= "0," ',@REMESA INT = 0"
            Sql &= Me.txtNoSolicitud.Text & "," ',@SOLICITUD INT = 0
            Sql &= Me.TxtCodigoBuxis.Text & ",'" ',@CODIGO_EMPLEADO INT = 0
            Sql &= Me.TxtCodigoAs.Text & "','" ',@CODIGO_EMPLEADO_AS NVARCHAR(6) = ''
            Sql &= Me.TxtCapital.Text & "'," ',@MONTO MONEY = 0
            Sql &= "0,'" ',@BANCO INT = 0
            Sql &= "0','" ',@CUENTA_BANCARIA NVARCHAR(50) = ''
            Sql &= Format(Me.DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss") & "'," ',@FECHA_CONTABLE DATETIME = 0
            Sql &= "0,'" ',@UBICACION INT = 0"
            Sql &= Usuario & "'," ',@USUARIO NVARCHAR(12) = ''
            Sql &= "'" & Bandera & "'" ',@BANDERA CHAR(1) =
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub eliminaProgramacionesNoDescontadas()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Dim Linea As Integer
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD "
            Sql &= Compañia & ","
            Sql &= Me.txtNoSolicitud.Text & ","
            Sql &= "'" & Usuario & "','E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Linea = Comando_Track.ExecuteScalar()
            Sql = "UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET LINEA = LINEA + " & Linea & " WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.txtNoSolicitud.Text
            Comando_Track.CommandText = Sql
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCapital.TextChanged
        Me.txtMonto.Text = Me.TxtCapital.Text
    End Sub

    Private Sub CargaDetalles()
        CargaDetalleProgramaciones()
        For i As Integer = 0 To Me.DgvDetalleProgramaciones.Rows.Count - 1
            If Me.DgvDetalleProgramaciones.Rows.Item(i).Cells("Reprogramada").Value = "SI" Then
                Me.DgvDetalleProgramaciones.Rows.Item(i).DefaultCellStyle.ForeColor = Color.Red
                Me.DgvDetalleProgramaciones.Rows.Item(i).DefaultCellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub

    
    Private Sub CbxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxPeriodo.SelectedIndexChanged
        'setFechaInicio()
    End Sub

    Private Sub FrmReprogramarSolicitud_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage4.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub DtpFechaPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaPago.ValueChanged
        Dim DescEspTot As Double = 0, Sql As String
        If Me.DtpFechaPago.Value.Day = 12 And (Me.DtpFechaPago.Value.Month = 6 Or Me.DtpFechaPago.Value.Month = 12) Then
            Sql = "SELECT ISNULL(SUM(D.CAPITAL), 0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D " & vbCrLf
            Sql &= "INNER JOIN COOPERATIVA_SOLICITUDES S ON D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO " & vbCrLf
            Sql &= "WHERE S.CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & " AND CAPITAL_D = 0 AND CONVERT(DATE, FECHA_PAGO) = CONVERT(DATE, '" & Format(Me.DtpFechaPago.Value, "dd/MM/yyyy") & "', 103)"
            DescEspTot = Func.obtenerEscalar(Sql)
            If DescEspTot > 0 Then
                MsgBox(Me.TxtNombre.Text & vbCrLf & "TIENE CUOTAS PROGRAMADAS PARA " & IIf(Me.DtpFechaPago.Value.Month = 6, "BONIFICACIÓN", "AGUINALDO") & "-" & Me.DtpFechaPago.Value.Year & vbCrLf & "POR UN TOTAL DEL $ " & Format(DescEspTot, "0.00"), MsgBoxStyle.Information, "AGUINALDO")
            End If
        End If
    End Sub
End Class