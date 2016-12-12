Imports System.Data
Imports System.Data.SqlClient
Public Class FrmProgramacion
    Public Compañia_Value As Integer
    Public Num_Solicitud As Integer
    Public Monto_value As Integer
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim TCapital, TInteres, TSegDeuda As Double
    Dim NumCuotasA As Integer
    Dim jClass As New jarsClass
    Dim Rpts As New FrmCooperativaReportes
    Dim TablaProgs As New DataTable
    Dim DescAgui, DescBoni As Double
    Dim var As Integer = 0
    Dim fecpag As Date
    Dim PeriodoPago As String

    Private Sub FrmProgramacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sql = "SELECT SOC.PERIODO_PAGO FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
        Sql &= " WHERE S.COMPAÑIA = SOC.COMPAÑIA AND S.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
        Sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "   AND S.CORRELATIVO = " & Num_Solicitud
        PeriodoPago = jClass.obtenerEscalar(Sql).ToString().Trim()
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Me.DtpFechaPago.Value = Now()
        Me.DtpFechaIniPres.Value = Now()
        Me.DtpFechaPrimerPag.MinDate = CDate(Format(Now(), "dd/MM/yyyy"))
        Me.DtpFechaPrimerPag.Value = Now()
        TxtNumSolicitud.Text = Num_Solicitud
        Deducciones()
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        CargaPeriodos()
        CargaPeriodosEspeciales()
        MuestraSolicitud()
        CargaInteres()
        GuardarCuotasEspeciales(9)
        FechaInicial(Now)
        fecpag = Me.DtpFechaPrimerPag.Value
        If verificarFechaEnviada(fecpag) Then
            FechaInicial(fecpag.AddDays(2))
        End If
        CrearTabla()
        Iniciando = False
        If DescAgui > 0 Then
            Me.TxtCuotaEspecial.Text = Format(DescAgui, "0.00")
        End If
    End Sub

    Private Sub Deducciones()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        'Conexion = New SqlConnection("Server=" & Servidor & ";Database=" & BaseDatos & ";User Id=" & UsuarioDB & ";Password=" & PasswordDB & ";Connect Timeout=60")
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @DEDUCCION = 0," & vbCrLf
            Sql &= " @BANDERA = 3"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "Deducción"
            Me.CbxDeduccion.DisplayMember = "Descripción Deducción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaInteres()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @DEDUCCION = " & CbxDeduccion.SelectedValue & "," & vbCrLf
            Sql &= " @BANDERA = 2"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            If Origen = 2 And CbxDeduccion.SelectedValue = 257 Then
                LblInteres.Text = "0.00"
            Else
                LblInteres.Text = Table.Rows(0).Item(2)
            End If
            If Origen = 5 Or Origen = 6 Then
                If CbxDeduccion.SelectedValue = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 33")) Then
                    LblSegDeuda.Text = Format(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 30"), "0.000")
                Else
                    LblSegDeuda.Text = Table.Rows(0).Item(3)
                End If
            Else
                If Origen = 2 And CbxDeduccion.SelectedValue = 257 Then
                    LblSegDeuda.Text = "0.00"
                Else
                    Me.LblSegDeuda.Text = Table.Rows(0).Item(3)
                End If
            End If
            Me.TxtCuotasMax.Text = Table.Rows(0).Item(4)
            Me.NudNumeroCuot.Maximum = Table.Rows(0).Item(4)
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
        Dim MaxCuotas As Integer
        Try
            Conexion_Track.Open()
            If Bandera = 3 Then
                Dim solicitudes As String() = Split(Me.TxtNumSolicitud.Text, ",")
                For Each strSolic As String In solicitudes
                    jClass.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_PROGRAMACION_ILUSTRATIVA WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & strSolic)
                Next
            Else
                DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
                DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = Trim(Val(Me.TxtNumSolicitud.Text))
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
                    var = ds.Tables(0).Rows.Count - 1
                    MaxCuotas = CInt(Val(Me.TxtCuotasMax.Text) / IIf(Me.CbxPeriodo.SelectedValue = "QQ", 1.0, 2.0))
                    If MaxCuotas <= 0 Then
                        MaxCuotas = 1
                    End If
                    If ds.Tables(0).Rows.Count <> 0 Then
                        If var > MaxCuotas Then
                            MessageBox.Show("Cuotas Calculadas: " & var.ToString() & vbCrLf & vbCrLf & "Número de Cuotas generadas mayores al límite" & vbCrLf & "Plazo Maximo: " & CInt(Val(Me.TxtCuotasMax.Text) / IIf(Me.CbxPeriodo.SelectedValue = "QQ", 1.0, 2.0)).ToString() & " Cuotas " & Me.CbxPeriodo.Text.ToLower() & "es", "Programación Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            DgvProgramacion.DataSource = Nothing
                        Else
                            DgvProgramacion.DataSource = ds.Tables(0)

                        End If
                    Else
                        DgvProgramacion.DataSource = ds.Tables(0)
                    End If
                Else
                    DgvProgramacion.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
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

    Private Sub CargaPeriodos()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            CbxPeriodo.DataSource = Table
            CbxPeriodo.ValueMember = "PERIODO"
            CbxPeriodo.DisplayMember = "DESCRIPCION_PERIODO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargaPeriodosEspeciales()
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

    Private Sub MuestraSolicitud()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Dim saldoPendiente As Double
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_TODAS_LAS_SOLICITUDES_APROBADA"
            Sql &= " @COMPAÑIA = " & Compañia & ","
            Sql &= " @T_SOLICITUD = 0,"
            Sql &= " @N_SOLICITUD = " & Val(Trim(TxtNumSolicitud.Text)) & ","
            Sql &= " @FECHA_INI = 0,"
            Sql &= " @FECHA_FIN = 0,"
            Sql &= " @BANDERA = 5"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.CbxDeduccion.SelectedValue = Table.Rows(0).Item("DEDUCCION")
                Me.TxtCodigoAs.Text = Table.Rows(0).Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
                Me.TxtNombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.TxtDivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION").ToString().Trim()
                Me.TxtDepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO").ToString().Trim()
                Me.TxtSección.Text = Table.Rows(0).Item("DESCRIPCION_SECCION").ToString().Trim()
                Me.NudNumeroCuot.Value = Table.Rows(0).Item("PLAZO")
                Me.TxtMonto.Text = Format(Table.Rows(0).Item("VALOR_VALE"), ".00")
                Me.CbxPeriodo.SelectedValue = Table.Rows(0).Item("PERIODO")
                Me.LblInteres.Text = Format(Table.Rows(0).Item("INTERES"), ".00")
                DescAgui = Format(Table.Rows(0).Item("DESCUENTO_AGUINALDO"), ".00")
                DescBoni = Format(Table.Rows(0).Item("DESCUENTO_BONIFICACION"), ".00")
                Origen = CInt(jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text))
            End If
            If Me.CbxDeduccion.SelectedValue = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = " & IIf("5,6".Contains(Origen.ToString()), "33", "11"))) Then
                Sql = "SELECT ISNULL(SUM(D.CAPITAL), 0) AS DEUDA_PRESTAMOS, S.CORRELATIVO AS NUMSOL" & vbCrLf
                Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D" & vbCrLf
                Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA AND S.CORRELATIVO = D.NUMERO_SOLICITUD" & vbCrLf
                Sql &= "   AND S.CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
                Sql &= "   AND S.CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & vbCrLf
                Sql &= "   AND S.DEDUCCION = " & Me.CbxDeduccion.SelectedValue & vbCrLf
                Sql &= "   AND D.CAPITAL_D = 0" & vbCrLf
                Sql &= " GROUP BY S.CORRELATIVO"
                Me.lblSolAnt.Text = ""
                Comando_Track.CommandText = Sql
                Table = jClass.obtenerDatos(Comando_Track)
                If Table.Rows.Count > 0 Then
                    For i As Integer = 0 To Table.Rows.Count - 1
                        saldoPendiente += Table.Rows(i).Item(0)
                        If i = 0 Then
                            Me.lblSolAnt.Text &= Table.Rows(i).Item(1).ToString()
                        Else
                            Me.lblSolAnt.Text &= "," & Table.Rows(i).Item(1).ToString()
                        End If
                    Next
                Else
                    saldoPendiente = 0
                    Me.lblSolAnt.Text = "0"
                End If
                If saldoPendiente > 0 Then
                    chkIncluirDeuda.Visible = True
                End If
                Me.Label14.Visible = True
                Me.txtSaldoPend.Visible = True
                Me.txtSaldoPend.Text = Format(saldoPendiente, "0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_CUOTAS_ESPECIALES " & Compañia & "," & Trim(Val(TxtNumSolicitud.Text)) & "," & Linea & "," & Bandera
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
    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        Dim numCuotas As Integer = Me.NudNumeroCuot.Value
        Dim PeriodoPago As String = jClass.obtenerEscalar("SELECT PERIODO_PAGO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & " AND CODIGO_EMPLEADO_AS = '" & Me.TxtCodigoAs.Text & "' AND COMPAÑIA = " & Compañia).ToString.Trim
        If PeriodoPago = "MM" Then
            If Me.CbxPeriodo.SelectedValue = "QQ" Then
                MsgBox("El periodo de la programación se ha cambiado a MENSUAL" & vbCrLf & "ya que el periodo de pago del empleado es MENSUAL." & vbCrLf & "Click en Aceptar para continuar.", MsgBoxStyle.Information, "Calcular Programación")
                Me.CbxPeriodo.SelectedValue = PeriodoPago
            End If
            If DtpFechaPrimerPag.Value.Day = 15 Then
                If DtpFechaPrimerPag.Value.Month = 2 Then
                    If DtpFechaPrimerPag.Value.Year Mod 4 = 0 Then
                        DtpFechaPrimerPag.Value = "29/" & DtpFechaPrimerPag.Value.Month.ToString.PadLeft(2, "0") & "/" & DtpFechaPrimerPag.Value.Year.ToString
                    Else
                        DtpFechaPrimerPag.Value = "28/" & DtpFechaPrimerPag.Value.Month.ToString.PadLeft(2, "0") & "/" & DtpFechaPrimerPag.Value.Year.ToString
                    End If
                Else
                    DtpFechaPrimerPag.Value = "30/" & DtpFechaPrimerPag.Value.Month.ToString.PadLeft(2, "0") & "/" & DtpFechaPrimerPag.Value.Year.ToString
                End If
            End If
        End If
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        Dim Fecha As DateTime = Now()
        If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
            MessageBox.Show("Monto no válido para calcular programación", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If TxtCuota.Enabled = True And TxtCuota.Text = Nothing Then
            MessageBox.Show("Cuota no válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If NudNumeroCuot.Enabled = True And NudNumeroCuot.Value = Nothing And NudNumeroCuot.Value = 0 Then
            MessageBox.Show("El número de Cuotas no es válida", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.TxtMonto.Text) Then
            MessageBox.Show("La cuota es mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        If DtpFechaPrimerPag.Value.Day = 15 Or DtpFechaPrimerPag.Value.Day = 30 Or DtpFechaPrimerPag.Value.Day = IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, 29, 28) Then
            If Me.TxtCuota.Text > 0 Then
                Programacion(True)
                'MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
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
                'Me.DgvProgramacion.DataSource = TablaProgs
                'LimpiaGrid()
            End If
            Me.BtnNuevo.Enabled = True
            Me.btnImprimir.Enabled = True
            Me.BtnCalcular.Enabled = False
            For Each row As DataRow In TablaProgs.Rows
                MantenimientoProgramacion(row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1)
            Next
            MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)

            If Me.TxtCuota.Enabled = False Or (TxtCuota.Enabled = True And var <= Me.TxtCuotasMax.Text) Then
                LimpiaGrid()
            End If
        Else
            MessageBox.Show("Los días válidos a seleccionar son: 15," & IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, "29", "28") & ",30 ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaPrimerPag.Focus()
        End If
        Me.BtnGuardar.Enabled = True
    End Sub
    Private Function Programacion(ByVal a_BD As Boolean) As Integer
        Dim Saldo As Double = CDbl(TxtMonto.Text) + IIf(Me.chkIncluirDeuda.Checked, CDbl(Me.txtSaldoPend.Text), 0)
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
        Try
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
                    TablaProgs.Rows.Add(Compañia, Me.TxtNumSolicitud.Text, i, Me.CbxDeduccion.SelectedValue, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
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
                    TablaProgs.Rows.Add(Compañia, Me.TxtNumSolicitud.Text, i, Me.CbxDeduccion.SelectedValue, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Programación Valor Cuota")
            i = 0
        End Try
        Return i
    End Function
    Private Sub ProgramacionCuota()
        Dim Saldo As Double = CDbl(TxtMonto.Text) + IIf(Me.chkIncluirDeuda.Checked, CDbl(Me.txtSaldoPend.Text), 0)
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
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Programación Número Cuotas")
        End Try
    End Sub
    Private Sub SumarSeguro()
        Dim Seguro As Double = jClass.leerDataeader("SELECT ISNULL(SUM(SEG_DEUDA),0) FROM COOPERATIVA_PROGRAMACION_ILUSTRATIVA WHERE COMPAÑIA=" & Compañia & " AND N_SOLICITUD=0", 0)
        Seguro = Math.Round(Seguro, 6) / NudNumeroCuot.Value
        jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET SEG_DEUDA=" & Seguro & ", CUOTA=CUOTA+" & Math.Round(Seguro, 2, MidpointRounding.ToEven) & " WHERE COMPAÑIA=" & Compañia & " AND N_SOLICITUD=0")
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
            Sql = "Exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 3 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & Compañia & "," & Trim(Val(TxtNumSolicitud.Text)) & "," & NudNumeroCuot.Value
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
                                    ElseIf Fecha.Day.ToString = "1" Then
                                        Fecha = CDate("29/02/" + Fecha.Year.ToString)
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
                            If Fecha.Month.ToString = "2" And (Fecha.Day.ToString = "28" Or Fecha.Day.ToString = "29") Then
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
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(TxtNumSolicitud.Text))
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Val(TxtNumSolicitud.Text.Trim)
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
    Private Sub NuevaCuota()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 4 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & Compañia & "," & Trim(Val(TxtNumSolicitud.Text)) & "," & NudNumeroCuot.Value
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
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @NUMERO_SOLICITUD = " & Me.TxtNumSolicitud.Text & "," & vbCrLf
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
    Private Sub LimpiaGrid()
        If Me.DgvProgramacion.Columns.Count > 10 Then
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
        End If
        Me.btnImprimir.Enabled = True
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

    Private Sub BuscaPeriodo()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT * FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND DEDUCCION = " & CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                Me.NudNumeroCuot.Maximum = DataReader_Track.Item("CUOTA_FINAL")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MantenimientoProgramacionEncabezado()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & "," & CbxDeduccion.SelectedValue & "," & NudNumeroCuot.Value & "," & Trim(Me.TxtCuota.Text) & "," & _
            IIf(Me.chkIncluirDeuda.Checked, (Val(Me.TxtMonto.Text) + IIf(Me.chkIncluirDeuda.Checked, Val(Me.txtSaldoPend.Text), 0.0)).ToString(), Val(Me.TxtMonto.Text).ToString()) & ",'" & _
            CbxPeriodo.SelectedValue & "','" & Format(DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss") & "','" & Format(DtpFechaPrimerPag.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & LblInteres.Text & "," & LblSegDeuda.Text & ",'" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROGRAMADA = 1, PROG_MANUAL = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.TxtNumSolicitud.Text
            Comando_Track.CommandText = Sql
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
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
            Sql &= " @NUM_SOLICITUD = " & CInt(Me.TxtNumSolicitud.Text) & "," & vbCrLf
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
    Private Sub GuardarVariasCuotasEspeciales(ByVal Bandera As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLUCITUDES_DETALLE_ESPECIALES_IUD" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @NUM_SOLICITUD = " & CInt(Me.TxtNumSolicitud.Text) & "," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @BANDERA = " & Bandera
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & Compañia & "," _
            & Val(TxtNumSolicitud.Text) & "," & 0 & "," & 0 & "," & 0 & ",'" & Format(DtpFechaPago.Value, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & Val(TxtCuotaEspecial.Text) & "," & 0 & "," & InteresPrimero & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
   
    'Private Sub CbxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxPeriodo.SelectedIndexChanged
    '    If Iniciando = False Then
    '        BuscaPeriodo()
    '    End If
    'End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim repts As New frmReportes_Ver
        Dim Reporte As New CooperativaProgramacion
        Dim Table As DataTable
        Dim fieldObj As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim pctr As CrystalDecisions.CrystalReports.Engine.PictureObject
        Dim solicitudes As String() = Split(Me.TxtNumSolicitud.Text, ",")
        For Each strSolic As String In solicitudes
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_RPT]"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @N_SOLICITUD = " & strSolic
            Sql &= ", @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'"
            Sql &= ", @CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
            Sql &= ", @BANDERA = 3"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Reporte.SetDataSource(Table)
            If Origen = 5 Or Origen = 6 Then
                pctr = Reporte.Section1.ReportObjects.Item("picture1")
                pctr.ObjectFormat.EnableSuppress = True
                pctr = Reporte.Section1.ReportObjects.Item("picture2")
                pctr.ObjectFormat.EnableSuppress = False
                fieldObj = Reporte.Section1.ReportObjects.Item("NOMBRECOMPAÑIA1")
                fieldObj.ObjectFormat.EnableSuppress = True
                txtObj = Reporte.Section1.ReportObjects.Item("txtATAF")
                txtObj.ObjectFormat.EnableSuppress = False
                txtObj.Text = jClass.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2")
            End If
            repts.ReportesGenericos(Reporte)
            repts.ShowDialog()
        Next
        'Normales
        'If Me.DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount = 0 Then
        '    Dim Localizacion As String = TxtDivision.Text + " - " + TxtSección.Text + " - " + TxtDepartamento.Text
        '    Rpts.ProgramacionSolicitudes(Compañia, Compañia, Val(TxtNumSolicitud.Text), CbxDeduccion.Text, TxtNombre.Text, TxtCodigoAs.Text, TxtCodigoBuxis.Text, Localizacion, NudNumeroCuot.Value, CDbl(TxtMonto.Text), CbxPeriodo.Text, DtpFechaIniPres.Value, DtpFechaPrimerPag.Value, CDbl(LblInteres.Text), CDbl(LblSegDeuda.Text), 1)
        '    Rpts.ShowDialog()
        '    Return
        'End If
        'Especiales y normales 
        'If Me.DgvProgramacionesEspeciales.RowCount <> 0 And Me.DgvProgramacion.RowCount <> 0 And Me.BtnGuardar.Enabled = False Then
        '    Dim Localizacion As String = TxtDivision.Text + " - " + TxtSección.Text + " - " + TxtDepartamento.Text
        '    Rpts.ReProgramacionSolicitudes(Compañia, Compañia, Val(TxtNumSolicitud.Text), CbxDeduccion.Text, TxtNombre.Text, TxtCodigoAs.Text, TxtCodigoBuxis.Text, Localizacion, 0, Monto_value, CbxPeriodo.Text, DtpFechaPrimerPag.Value, CDbl(LblInteres.Text), CDbl(LblSegDeuda.Text), 1)
        '    Rpts.ShowDialog()
        '    Return
        'End If
        'Solo Especiales 
        'If Me.DgvProgramacionesEspeciales.RowCount <> 0 And Me.DgvProgramacion.RowCount = 0 And Me.BtnGuardar.Enabled = False And CDbl(Val(Me.TxtMonto.Text)) = 0 Then
        '    Dim Localizacion As String = TxtDivision.Text + " - " + TxtSección.Text + " - " + TxtDepartamento.Text
        '    Rpts.ReProgramacionSolicitudes(Compañia, Compañia, Val(TxtNumSolicitud.Text), CbxDeduccion.Text, TxtNombre.Text, TxtCodigoAs.Text, TxtCodigoBuxis.Text, Localizacion, 0, Monto_value, CbxPeriodo.Text, DtpFechaPago.Value, CDbl(LblInteres.Text), CDbl(LblSegDeuda.Text), 1)
        '    Rpts.ShowDialog()
        '    Return
        'End If
        'MsgBox("¡Debe Calcular  la programación o debe de guardarla  !", MsgBoxStyle.Critical, "Validación")
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'No hay cuotas especialeS solo normales            
        If DgvProgramacion.Rows.Count > 0 And DgvProgramacionesEspeciales.Rows.Count = 0 Then
            If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                MantenimientoProgramacionEncabezado()
                MantenimientoProgramacionDetalle()
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False
                Me.btnImprimir.Enabled = True
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
                AnularProgramacionesPendientes()
                Return
            End If
        End If
        'No hay cuotas Normales solo Especiales
        If DgvProgramacionesEspeciales.Rows.Count > 0 And DgvProgramacion.Rows.Count = 0 And CDbl(Val(Me.TxtMonto.Text)) = 0 Then
            If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                MantenimientoProgramacionEncabezado()
                GuardarCuotasEspeciales(8)
                GuardarCuotasEspeciales(9)
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False
                Me.btnImprimir.Enabled = True
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
                AnularProgramacionesPendientes()
                If DgvProgramacionesEspeciales.Rows.Count > 1 Then
                    TablaProgs = jClass.obtenerDatos(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & Me.TxtNumSolicitud.Text & "'"))
                    If TablaProgs.Rows.Count > 0 Then
                        Me.TxtNumSolicitud.Text = ""
                        Sql = "SE CREARON PROGRAMACIONES SEPARADAS PARA LAS CUOTAS ESPECIALES:" & vbCrLf
                        For i As Integer = 0 To TablaProgs.Rows.Count - 1
                            Sql &= "  " & (i + 1).ToString() & ") SOLICITUD #" & TablaProgs.Rows(i).Item(0) & " POR $ " & Format(TablaProgs.Rows(i).Item(2), "#,##0.00") & IIf(CDate(TablaProgs.Rows(i).Item(3)).Month = 6, " BONIFICACION-", " AGUINALDO-") & Format(TablaProgs.Rows(i).Item(3), "yyyy") & vbCrLf
                            Me.TxtNumSolicitud.Text &= IIf(i = 0, "", ",") & TablaProgs.Rows(i).Item(0)
                        Next
                        MsgBox(Sql, MsgBoxStyle.Information, Me.Text)
                    End If
                End If
                Return
            End If
        End If
        'Hay cuotas Normales y Especiales            
        If DgvProgramacion.Rows.Count > 0 And DgvProgramacionesEspeciales.Rows.Count > 0 Then
            If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                MantenimientoProgramacionEncabezado()
                MantenimientoProgramacionDetalle()
                GuardarVariasCuotasEspeciales(1)
                GuardarCuotasEspeciales(9)
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False
                Me.btnImprimir.Enabled = True
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
                AnularProgramacionesPendientes()
                TablaProgs = jClass.obtenerDatos(New SqlCommand("EXECUTE sp_COOPERATIVA_PROGRAMACION_SEPARAR_ESPECIALES @COMPAÑIA = " & Compañia & ", @A_SEPARAR = '" & Me.TxtNumSolicitud.Text & "'"))
                If TablaProgs.Rows.Count > 0 Then
                    Sql = "SE CREARON PROGRAMACIONES SEPARADAS PARA LAS CUOTAS ESPECIALES:" & vbCrLf
                    For i As Integer = 0 To TablaProgs.Rows.Count - 1
                        Sql &= "  " & (i + 1).ToString() & ") SOLICITUD #" & TablaProgs.Rows(i).Item(0) & " POR $ " & Format(TablaProgs.Rows(i).Item(2), "#,##0.00") & IIf(CDate(TablaProgs.Rows(i).Item(3)).Month = 6, " BONIFICACION-", " AGUINALDO-") & Format(TablaProgs.Rows(i).Item(3), "yyyy") & vbCrLf
                        Me.TxtNumSolicitud.Text &= "," & TablaProgs.Rows(i).Item(0)
                    Next
                    MsgBox(Sql, MsgBoxStyle.Information, Me.Text)
                End If
                Return
            End If
        End If
        MsgBox("¡No puede guardar la programación, favor verificar Datos !", MsgBoxStyle.Critical, "Validación")
    End Sub

    Private Sub AnularProgramacionesPendientes()
        Dim Solicitudes As String() = Split(Me.lblSolAnt.Text, ",")
        For Each solicitud As String In Solicitudes
            If Val(Me.txtSaldoPend.Text) > 0 And Me.chkIncluirDeuda.Checked Then
                Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION]" & vbCrLf
                Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
                Sql &= " @NUM_SOLICITUD = " & solicitud & "," & vbCrLf
                Sql &= " @MOTIVO = 'TRASLADO DE SALDO A NUEVA SOLICITUD DE PRESTAMO No." & Me.TxtNumSolicitud.Text & "'," & vbCrLf
                Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
                Sql &= " @BANDERA = 1"
                jClass.Ejecutar_ConsultaSQL(Sql)
            End If
        Next
    End Sub

    Private Sub FrmProgramacion_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        GuardarCuotasEspeciales(9)
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        GuardarCuotasEspeciales(9)
        Me.TxtCuota.Enabled = True
        Me.BtnGuardar.Enabled = True
        Me.NudNumeroCuot.Enabled = True
        Me.BtnCalcular.Enabled = False
        Me.NudNumeroCuot.Value = 0
        Me.TxtCuota.Text = 0
    End Sub

    Private Sub TxtCuotaEspecial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuotaEspecial.KeyPress
        Dim cadena As String = TxtCuotaEspecial.Text
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
                Resta = CDbl(Val(Me.TxtMonto.Text)) - Cuota
                Me.TxtMonto.Text = Resta
                If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
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
            MuestraProgramacionesCuotasEspeciales(0, 1)
            Suma = CDbl(Val(Me.TxtMonto.Text)) + Valor
            Me.TxtMonto.Text = Suma
            If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                Me.BtnGuardar.Enabled = True
                Me.BtnCalcular.Enabled = False
            Else
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = True
            End If
            Total_CuotaEspecial()
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
       
    End Sub
    Private Sub TxtCuota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuota.KeyPress
        Dim cadena As String = TxtCuota.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For i As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
        Me.BtnCalcular.Enabled = True
    End Sub
    Private Sub TxtCuota_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCuota.Leave
        If Me.TxtCuota.Text > 0 Then
            'MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
            NudNumeroCuot.Enabled = False
            NudNumeroCuot.Value = 0
            Me.BtnCalcular.Enabled = True
        End If
    End Sub

    Private Sub DtpFechaPrimerPag_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaPrimerPag.Leave
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
        Else
            Me.BtnCalcular.Enabled = True
        End If
    End Sub
    Private Sub NudNumeroCuot_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudNumeroCuot.Leave
        If NudNumeroCuot.Value > 0 Then
            'MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
            Me.TxtCuota.Text = 0
            Me.TxtCuota.Enabled = False
            Me.BtnCalcular.Enabled = True
        End If
    End Sub

    Private Sub NudNumeroCuot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudNumeroCuot.ValueChanged
        If NudNumeroCuot.Value > 0 Then
            'MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
            Me.TxtCuota.Text = 0
            Me.TxtCuota.Enabled = False
            Me.BtnCalcular.Enabled = True
        End If
    End Sub

    Private Sub TbpNormales_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpNormales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub FrmProgramacion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpEspeciales_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpEspeciales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub SetearFechas(ByVal Fecha As Date)
        'Dim Fecha As Date = Me.DtpFechaPrimerPag.Value
        If Fecha.Day <= 15 Then
            Me.DtpFechaPrimerPag.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.DtpFechaPrimerPag.Value = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Me.DtpFechaPrimerPag.Value = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Try
                    Me.DtpFechaPrimerPag.Value = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub DtpFechaPrimerPag_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaPrimerPag.ValueChanged
        SetearFechas(DtpFechaPrimerPag.Value)
        fecpag = Me.DtpFechaPrimerPag.Value
        If verificarFechaEnviada(fecpag) Then
            SetearFechas(fecpag.AddDays(2))
        End If
    End Sub

    Private Sub FechaInicial(ByVal Fecha As Date)
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

    Private Sub CbxPeriodoEspeciales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxPeriodoEspeciales.SelectedIndexChanged
        If Not Iniciando Then
            If Me.CbxPeriodoEspeciales.SelectedValue = "AG" Then
                If DescAgui > 0 Then
                    Me.TxtCuotaEspecial.Text = Format(DescAgui, "0.00")
                Else
                    Me.TxtCuotaEspecial.Clear()
                End If
            Else
                If DescBoni > 0 Then
                    Me.TxtCuotaEspecial.Text = Format(DescBoni, "0.00")
                Else
                    Me.TxtCuotaEspecial.Clear()
                End If
            End If
        End If
    End Sub

    Private Function verificarFechaEnviada(ByVal Fecha As Date) As Boolean
        Dim result As Boolean
        'If jClass.obtenerEscalar("SELECT TOP 1 FECHA_PAGO FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND FECHA_PAGO = '" & Format(Fecha, "dd/MM/yyyy") & "' AND ENVIADA = 1") Is Nothing Then
        If jClass.obtenerEscalar("SELECT TOP 1 FECHA_PAGO FROM COOPERATIVA_RESUMEN_DESCUENTOS_ENVIADOS WHERE COMPAÑIA = " & Compañia & " AND FECHA_PAGO = '" & Format(Fecha, "dd/MM/yyyy") & "' AND PERIODO_PAGO = '" & PeriodoPago & "'") Is Nothing Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    Private Sub DtpFechaPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaPago.ValueChanged
        Dim DescEspTot As Double = 0, Sql As String
        If Not Iniciando Then
            If Me.DtpFechaPago.Value.Day = 12 And (Me.DtpFechaPago.Value.Month = 6 Or Me.DtpFechaPago.Value.Month = 12) Then
                Sql = "SELECT ISNULL(SUM(D.CAPITAL), 0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D " & vbCrLf
                Sql &= "INNER JOIN COOPERATIVA_SOLICITUDES S ON D.COMPAÑIA = S.COMPAÑIA AND D.NUMERO_SOLICITUD = S.CORRELATIVO " & vbCrLf
                Sql &= "WHERE S.CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & " AND CAPITAL_D = 0 AND CONVERT(DATE, FECHA_PAGO) = CONVERT(DATE, '" & Format(Me.DtpFechaPago.Value, "dd/MM/yyyy") & "', 103)"
                DescEspTot = jClass.obtenerEscalar(Sql)
                If DescEspTot > 0 Then
                    MsgBox(Me.TxtNombre.Text & vbCrLf & "TIENE CUOTAS PROGRAMADAS PARA " & IIf(Me.DtpFechaPago.Value.Month = 6, "BONIFICACIÓN", "AGUINALDO") & "-" & Me.DtpFechaPago.Value.Year & vbCrLf & "POR UN TOTAL DEL $ " & Format(DescEspTot, "0.00"), MsgBoxStyle.Information, "AGUINALDO")
                End If
            End If
        End If
    End Sub
End Class