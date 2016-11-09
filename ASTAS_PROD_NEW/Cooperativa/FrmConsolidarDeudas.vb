Imports System.Data
Imports System.Data.SqlClient
Public Class FrmConsolidarDeudas
    Public Compañia_Value As Integer
    Public Num_Solicitud As Integer
    Public Monto_value As Integer
    Public Cod_buxis
    Public Cod_AS
    Public Socio
    Public TipoDeuda
    Public totalDeudas
    Public horaActual As String
    Private fechaInicio As String
    Dim Func As New jarsClass
    Dim TablaProgs As New DataTable
    Dim deduccionPtmo As Integer
    Private Sub setOrigen()
        Origen = Func.obtenerEscalar("select ORIGEN from COOPERATIVA_CATALOGO_SOCIOS where COMPAÑIA=" & Compañia & " and CODIGO_EMPLEADO_AS='" & Trim(Me.TxtCodigoAs.Text) & "' and CODIGO_EMPLEADO=" & Trim(Me.TxtCodigoBuxis.Text))
    End Sub

    Private Sub FrmConsolidarDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Compañia = Compañia_Value
        Me.DtpFechaPago.Value = Now()
        Me.DtpFechaIniPres.Value = Now()
        Me.DtpFechaPrimerPag.Value = Now()
        Me.TxtCodigoBuxis.Text = Cod_buxis
        Me.TxtCodigoAs.Text = Cod_AS
        Me.TxtNombre.Text = Socio
        Me.CmbProgramaInteres.SelectedIndex = 1
        Dim interes As Double
        Dim seguro As Double
        Iniciando = True
        setOrigen()
        GetMonto()
        getIntereses()
        Deducciones()
        getTasaInteres()
        CargaPeriodos()
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        CargaPeriodosEspeciales()
        'MuestraSolicitud()
        Numero_Orden(0)
        GuardarCuotasEspeciales(9)
        interes = Convert.ToDouble(Me.txtInteres.Text)
        seguro = Convert.ToDouble(Me.txtSeguro.Text)
        'Me.TxtCuotaEspecial.Text = (interes + seguro)
        Me.txtMontoInteSeg.Text = (interes + seguro)
        Me.txtCanCuotaEspecial.Text = (interes + seguro)
        Me.txtCanNoCuotaEspecial.Text = 1
        CrearTabla()
        bloqueaControlesReprogra()
        Me.BtnCalcular.Enabled = False
        SetearFechas()
        Me.CbxDeduccion.SelectedValue = deduccionPtmo
        Iniciando = False
    End Sub
    Private Sub setHoraActual()
        horaActual = Now()
    End Sub
    Private Sub setFechaInicio()
        fechaInicio = Format(Me.DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss")
    End Sub
    Private Sub Numero_Orden(ByVal bandera As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            'If bandera = 0 Then
            '    Sql = "SELECT ULTIMO FROM COOPERATIVA_CORRELATIVOS_DOCUMENTOS"
            '    Sql &= " WHERE COMPAÑIA=" & Compañia & " AND TIPO_DOCUMENTO='SOL'"
            'Else
            Sql = "Exec sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS " & Compañia & ",'SOL',0 "
            'End If
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Me.TxtNumSolicitud.Text = DataReader_Track.Item(0)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
            Sql = "Execute Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION_ESPECIALES " & Compañia
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
    Private Sub Deducciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim TableDeduc As DataTable
        Dim Sql As String
        deduccionPtmo = Func.obtenerEscalar("SELECT CONVERT(INT, VALOR) AS VALOR FROM [dbo].[CONTABILIDAD_CATALOGO_CONSTANTE] WHERE CONSTANTE = 11")
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()

            Sql = "SELECT DEDUCCION, DESCRIPCION_SOLICITUD, DESCRIPCION_SOLICITUD, CUOTA_INICIAL, CUOTA_FINAL " & vbCrLf
            Sql &= "FROM COOPERATIVA_CATALOGO_SOLICITUDES " & vbCrLf
            'Sql &= "WHERE DEDUCCION = " & deduccionPtmo & " AND COMPAÑIA = " & Compañia

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            TableDeduc = New DataTable("Datos")
            DataAdapter_.Fill(TableDeduc)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDeduccion.DataSource = TableDeduc
            Me.CbxDeduccion.ValueMember = "DEDUCCION"
            Me.CbxDeduccion.DisplayMember = "DESCRIPCION_SOLICITUD"
            Me.CbxDeduccion.SelectedValue = deduccionPtmo
            ParamDeduc(deduccionPtmo)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub GetMonto()
        Try
            Dim monto As Double
            Dim soli
            Dim i As Integer
            Dim sql As String
            Dim Conexion As New DLLConnection.Connection
            Dim Conexion_Track As New SqlConnection
            Dim Comando_Track As New SqlCommand
            Dim DataAdapter_ As New SqlDataAdapter
            Dim Table As DataTable
            soli = Split(Me.TxtNumSolicitudes.Text, ",")
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            monto = 0
            For i = 0 To totalDeudas - 1
                Conexion_Track.Open()
                sql = "SELECT SUM(sd.CAPITAL) AS DEUDA FROM VISTA_COOPERATIVA_PROGRAMACION_SOLICITUDES s inner join COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd on sd.NUMERO_SOLICITUD=s.CORRELATIVO"
                sql = sql & " WHERE s.COMPAÑIA='" & Compañia & "' AND s.CODIGO_AS='" & Trim((TxtCodigoAs.Text)) & "' AND s.CODIGO_BUXIS='" & Trim(Val(TxtCodigoBuxis.Text)) & "' AND s.CORRELATIVO NOT IN(SELECT NUMERO_SOLICITUD FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS) AND sd.CAPITAL_D=0"
                sql = sql & " AND s.CORRELATIVO = '" & soli(i) & "'"
                Comando_Track = New SqlCommand(sql, Conexion_Track)
                DataAdapter_ = New SqlDataAdapter(Comando_Track)
                Table = New DataTable("Datos")
                DataAdapter_.Fill(Table)
                monto = monto + Table.Rows(0).Item(0)
                Conexion_Track.Close()
            Next
            Me.TxtMonto.Text = monto
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
        Dim Sql As String
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
            CbxPeriodo.SelectedValue = "QQ"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub getIntereses()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitudes.Text, ",")
        Dim interes As Double = 0
        Dim seguro As Double = 0

        For Each solicitud As String In solicitudes
            interes += getInteresesFecha(solicitud, 1)
            seguro += getInteresesFecha(solicitud, 2)
        Next

        Me.txtInteres.Text = interes
        Me.txtSeguro.Text = seguro
        Me.txtMontoInteSeg.Text = (interes + seguro)
    End Sub
    Private Function getInteresesFecha(ByVal solicitud As String, ByVal bandera As Integer)
        'Obtiene los intereses Generados a la fecha a partir del ultimo pago
        Dim deduccion As String = Me.Deducciones2(solicitud)
        Dim fechaActual As String = Format(Now(), "Short Date")
        Dim fechaUltimoPago As String = Format(getUltimaFechaPago(solicitud), "Short Date")
        Dim Saldo As Double = getDescripcionCapital(solicitud, 2)
        Dim TasaInteres As Double = CDbl(Trim(getTasaInteresSol(deduccion))) / 100
        Dim Tasa_Seguro As Double = CDbl(Trim(getTasaSeguroSol(deduccion))) / 100
        Dim DiasPP As Integer = getDiffDias(fechaActual, fechaUltimoPago)
        Dim interes As Double
        Dim seguro As Double

        If DiasPP < 0 Then
            'Si da Negativo indica que fechaUltimoPago es mayor que fechaActual 
            'En este caso no se han iniciado los descuentos por lo tanto no ha
            'intereses aun
            DiasPP = 0
        End If

        interes = (Saldo * TasaInteres * DiasPP) / 360
        interes = Math.Round(interes, 2, MidpointRounding.ToEven)

        seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
        seguro = Math.Round(seguro, 2, MidpointRounding.ToEven)

        If bandera = 0 Then
            Return (interes + seguro)
        End If
        If bandera = 1 Then
            Return interes
        Else
            Return seguro
        End If
    End Function
    Private Function getTasaSeguroSol(ByVal deduccion As String)
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
            Sql = "SELECT INTERES FROM COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO WHERE COMPAÑIA=" & Compañia & " AND DEDUCCION=" & deduccion
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            If Table.Rows.Count > 0 Then
                If Origen = 5 Or Origen = 6 Then
                    If CbxDeduccion.SelectedValue = CInt(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")) Then
                        Valor = Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 30")
                    Else
                        Valor = Table.Rows(0).Item(0)
                    End If
                Else
                    If Origen = 2 And deduccion = 257 Then
                        Valor = 0.0
                    Else
                        Valor = Table.Rows(0).Item(0)
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Function getTasaInteresSol(ByVal deduccion As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Valor As Double = 0
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT INTERES FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE COMPAÑIA=" & Compañia & " AND DEDUCCION=" & deduccion
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If Table.Rows.Count > 0 Then
                If Origen = 2 And deduccion = 257 Then
                    Valor = 0.0
                Else
                    Valor = Table.Rows(0).Item(0)
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Function Deducciones2(ByVal solicitud As String)
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
            If esPrestamo(solicitud) Then
                Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
                Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
                Sql &= "inner join COOPERATIVA_SOLICITUDES_PRESTAMOS csp "
                Sql &= "on csp.DEDUCCION=ccd.DEDUCCION "
                Sql &= "where ccd.COMPAÑIA=" & Compañia
                Sql &= " and csp.CORRELATIVO=" & solicitud
            Else
                Sql = "select ccd.DEDUCCION, ccd.DESCRIPCION_DEDUCCION "
                Sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES ccd "
                Sql &= "inner join COOPERATIVA_SOLICITUDES cs "
                Sql &= "on cs.DEDUCCION=ccd.DEDUCCION "
                Sql &= "where ccd.COMPAÑIA=" & Compañia
                Sql &= " and cs.CORRELATIVO=" & solicitud
            End If
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader

            Me.CbxDeduccion.DataSource = Table
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return 0
    End Function
    Private Function esPrestamo(ByVal solicitud As String)
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
            Sql &= "where ccd.COMPAÑIA=" & Compañia
            Sql &= "and csp.CORRELATIVO=" & solicitud
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
    Private Function getDescripcionCapital(ByVal solicitud As String, ByVal bandera As Integer)
        'bandera 1: retorna descripcion solicitud 
        'bandera 2: retorna(deuda)
        Try
            Dim Conexion As New DLLConnection.Connection
            Dim Conexion_Track As New SqlConnection
            Dim Comando_Track As New SqlCommand
            Dim DataAdapter_ As New SqlDataAdapter
            Dim Table As DataTable
            Dim Sql As String

            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            Conexion_Track.Open()

            Sql = "SELECT s.CORRELATIVO[Nº Solicitud],s.DESCRIPCION_SOLICITUD[Solicitud],SUM(sd.CAPITAL) AS DEUDA "
            Sql &= "FROM VISTA_COOPERATIVA_PROGRAMACION_SOLICITUDES s "
            Sql &= "inner join COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd "
            Sql &= "on sd.NUMERO_SOLICITUD=s.CORRELATIVO "
            Sql &= "WHERE s.COMPAÑIA=" & Compañia & " AND s.CODIGO_AS='" & Me.TxtCodigoAs.Text & "' AND s.CODIGO_BUXIS=" & Me.TxtCodigoBuxis.Text
            Sql &= " AND s.CORRELATIVO=" & solicitud
            Sql &= " AND sd.CAPITAL_D=0 group by s.CORRELATIVO, s.DESCRIPCION_SOLICITUD"

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            Conexion_Track.Close()

            Return Table.Rows(0).Item(bandera)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return "0"
    End Function
    Private Function getDiffDias(ByVal fechaActual As String, ByVal fechaAnterior As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI 2,'" & fechaAnterior & "','" & fechaActual & "',1,0,0"
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception

        End Try
        Return 0
    End Function
    Private Function getFechaActual() As Date
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Sql As String
        Dim Valor As Date = Now.Date
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR '" & 0 & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DataAdapter_.Fill(DS)
            Conexion_Track.Close()
            Valor = CDate(DS.Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Sub getTasaInteres()
        Try
            Dim monto As Double
            Dim soli
            'Dim i As Integer
            Dim sql As String
            Dim Conexion As New DLLConnection.Connection
            Dim Conexion_Track As New SqlConnection
            Dim Comando_Track As New SqlCommand
            Dim DataAdapter_ As New SqlDataAdapter
            Dim Table As DataTable
            soli = Split(Me.TxtNumSolicitudes.Text, ",")
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            monto = 0
            Conexion_Track.Open()

            sql = "select d.DEDUCCION, d.INTERES, s.INTERES as SEGURO "
            sql &= "from COOPERATIVA_CATALOGO_DEDUCCIONES d "
            sql &= "inner join COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO s "
            sql &= "on d.DEDUCCION=s.DEDUCCION "
            sql &= "where DESCRIPCION_DEDUCCION = 'PRESTAMOS' AND d.COMPAÑIA=" & Compañia
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            LblInteres.Text = Table.Rows(0).Item(1)
            If Origen = 5 Or Origen = 6 Then
                If CbxDeduccion.SelectedValue = CInt(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")) Then
                    LblSegDeuda.Text = Format(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 30"), "0.000")
                Else
                    LblSegDeuda.Text = Table.Rows(0).Item(2)
                End If
            Else
                Me.LblSegDeuda.Text = Table.Rows(0).Item(2)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub bloqueaControlesReprogra()
        Me.CmbProgramaInteres.Enabled = False
        Me.rbtValorCuota.Enabled = False
        Me.rbtNumCuotas.Enabled = False
        Me.CbxPeriodo.Enabled = False
        Me.DtpFechaIniPres.Enabled = False
        Me.DtpFechaPrimerPag.Enabled = False
        'Me.TabControl2.Enabled = False
        Me.BtnAgregar.Enabled = False
        Me.BtnEliminar.Enabled = False
    End Sub
    Private Sub desbloqueControlesReprogra()
        Me.CmbProgramaInteres.Enabled = True
        Me.rbtValorCuota.Enabled = True
        Me.rbtNumCuotas.Enabled = True
        Me.CbxPeriodo.Enabled = True
        Me.DtpFechaIniPres.Enabled = True
        Me.DtpFechaPrimerPag.Enabled = True
        'Me.TabControl2.Enabled = True
        Me.BtnAgregar.Enabled = True
        Me.BtnEliminar.Enabled = True
    End Sub
    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        Dim numCuotas As Integer = 0
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        Dim Fecha As DateTime = FechaActual()
        'If (CDbl(Me.txtMontoInteSeg.Text) = 0) And (Me.CmbProgramaInteres.SelectedIndex <> 3) Then
        '    MessageBox.Show("La solicitud no posee intereses pendientes, favor escoger el tipo de programación especial para los intereses", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If
        If (Not (Me.rbtValorCuota.Checked Or Me.rbtNumCuotas.Checked)) Then
            MessageBox.Show("Se debe seleccionar el tipo de programación (cuota o numero de cuotas) a realizar.", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
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
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.TxtMonto.Text) Then
            MessageBox.Show("La cuota es mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        'If Me.CmbProgramaInteres.SelectedIndex = 3 And (CDbl(Me.txtMontoInteSeg.Text) > 0) Then
        '    MessageBox.Show("Existen intereses pendientes de programar. Debe seleccionar otro tipo de programación distinto de la especial para los intereses.", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If
        'If CDate(Me.DtpFechaPrimerPag.Value.ToShortDateString) < CDate(Fecha.ToShortDateString) Then
        '    MessageBox.Show("La fecha del primer pago no puede ser menor que la fecha actual", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DtpFechaIniPres.Focus()
        '    Return
        'End If
        If DtpFechaPrimerPag.Value.Day = 15 Or DtpFechaPrimerPag.Value.Day = 30 Or DtpFechaPrimerPag.Value.Day = IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, 29, 28) Then
            If Me.rbtValorCuota.Checked Then
                Programacion(True)
                MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
            ElseIf Me.rbtNumCuotas.Checked Then
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
        bloqueaControlesReprogra()
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
        Dim Sql As String
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
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & Compañia & "," & Me.TxtNumSolicitud.Text & "," & 1
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & "," & CbxDeduccion.SelectedValue & "," & NudNumeroCuot.Value & "," & Trim(Me.TxtCuota.Text) & "," & _
            Monto_value & ",'" & CbxPeriodo.SelectedValue & "','" & Format(DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss") & "','" & Format(DtpFechaPrimerPag.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & LblInteres.Text & "," & LblSegDeuda.Text & ",'" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROGRAMADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.TxtNumSolicitud.Text
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
        Dim Sql As String
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
    Private Sub GuardarCuotasEspeciales(ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & Bandera
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLUCITUDES_DETALLE_ESPECIALES_IUD " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & ",'" & Usuario & "'," & Bandera
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_CUOTA_NO_DESCONTADA_IUD " & Compañia & "," _
            & Val(TxtNumSolicitud.Text) & "," & 0 & "," & 0 & "," & 0 & ",'" & Format(DtpFechaPago.Value, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & 0 & "," & 0 & "," & Val(TxtCuotaEspecial.Text) & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
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
        'MessageBox.Show(TxtNumSolicitud.Text)
        Try
            Conexion_Track.Open()
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
        Me.CmbProgramaInteres.SelectedIndex = 1
        Me.txtCanNoCuotaEspecial.Text = 1
        Me.txtCanCuotaEspecial.Text = Me.txtMontoInteSeg.Text
        'GuardarCuotasEspeciales(9)
        'Me.TxtCuota.Enabled = True
        Me.BtnGuardar.Enabled = False
        'Me.NudNumeroCuot.Enabled = True
        Me.BtnCalcular.Enabled = True
        Me.TxtCuota.Text = 0
        desbloqueControlesReprogra()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtValorCuota.CheckedChanged
        If Me.rbtValorCuota.Checked = True Then
            Me.TxtCuota.Enabled = True
            Me.NudNumeroCuot.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNumCuotas.CheckedChanged
        If Me.rbtNumCuotas.Checked Then
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
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR '" & 0 & "'"
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(TxtNumSolicitud.Text))
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
            setFechaInicio()
            'No hay  cuotas especiales                
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount = 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    'Numero_Orden(1)
                    Insertar_SolicitudesN()     'Se crea la solicitud
                    If Me.CbxDeduccion.SelectedValue = deduccionPtmo Then
                        setSolicitudPrestamos()     'Se crea solicitud en prestamos 
                        setSolicitudPagada("I")    'se actualiza como pagada
                    End If
                    ActualizarAutorizaciones(1) 'Se autoriza la solicitud
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
                    anularSolicitudes()
                    Me.Close()
                    Return
                End If
            End If
            'No hay  cuotas  “Normales”               
            If DgvProgramacionesEspeciales.RowCount <> 0 And DgvProgramacion.RowCount = 0 And CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    'Numero_Orden(1)
                    Insertar_SolicitudesN()
                    If Me.CbxDeduccion.SelectedValue = deduccionPtmo Then
                        setSolicitudPrestamos()     'Se crea solicitud en prestamos 
                        setSolicitudPagada("I")     'se guarda en remesas
                    End If
                    ActualizarAutorizaciones(1) 'Se autoriza la solicitud
                    MantenimientoProgramacionEncabezado()
                    GuardarCuotasEspeciales(8)
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
                    anularSolicitudes()
                    Me.Close()
                    Return
                End If
            End If
            'Hay  cuotas  “Normales”   y Especiales            
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount <> 0 Then
                If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                    'Numero_Orden(1)
                    Insertar_SolicitudesN()
                    If Me.CbxDeduccion.SelectedValue = deduccionPtmo Then
                        setSolicitudPrestamos()     'Se crea solicitud en prestamos 
                        setSolicitudPagada("I")     'se guarda en remesas
                    End If
                    ActualizarAutorizaciones(1) 'Se autoriza la solicitud
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
                    anularSolicitudes()
                    Me.Close()
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox("¡No puede guardar la programación, favor verificar Datos !", MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub
    Private Function anularSolicitudes()
        ' Anular solicitudes 
        Dim solicitudes As Array
        Dim solicitud As String
        Dim numfact As Integer
        Dim motivo As String = String.Empty
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As New SqlCommand
        Dim Deduccion2 As Integer
        Dim Sql As String

        Try
            'anula las programaciones consolidadas
            Deduccion2 = Func.obtenerEscalar("SELECT COUNT(DEDUCCION) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO IN (" & Me.TxtNumSolicitudes.Text & ") AND DEDUCCION <> " & Me.CbxDeduccion.SelectedValue)
            solicitudes = Split(Me.TxtNumSolicitudes.Text, ",")
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            Conexion_Track.Open()
            Comando_Track.Connection = Conexion_Track
            For Each solicitud In solicitudes
                numfact = Func.obtenerEscalar("SELECT NUMERO_FACTURA FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud)
                If Deduccion2 > 0 Then
                    motivo = "TRASLADO DE SALDO A " & Me.CbxDeduccion.Text & IIf(numfact > 0, " DE FACTURA No." & numfact, " SOLICITUD No." & solicitud) & ". NUEVA SOLICITUD No." & Me.TxtNumSolicitud.Text
                Else
                    motivo = "CONSOLIDACION DE SALDO " & IIf(numfact > 0, " DE FACTURA No." & numfact, " DE SOLICITUD No." & solicitud) & " A NUEVA PROGRAMACION No." & Me.TxtNumSolicitud.Text
                End If
                '@compañia @num_solicitud @motivo @usuario @bandera
                Sql = "execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION " & Compañia & "," & solicitud & ",'" & motivo & "','" & Usuario & "', 1"
                'Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD " & vbCrLf
                'Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
                'Sql &= " @NUM_SOLICITUD = " & solicitud & "," & vbCrLf
                'Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
                'Sql &= " @IUD = 'E'"
                Comando_Track.CommandText = Sql
                Comando_Track.ExecuteNonQuery()
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET FECHA_ANULADA = '" & Format(Me.DtpFechaIniPres.Value, "dd/MM/yyyy") & "', CONSOLIDACION_PRESTAMO = 1" & vbCrLf
                Sql &= "WHERE N_SOLICITUD = " & solicitud & " AND COMPAÑIA = " & Compañia
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                Comando_Track.ExecuteNonQuery()
            Next
            'If Deduccion2 > 0 Then
            Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET CONSOLIDACION_PRESTAMO = 1" & vbCrLf
            Sql &= "WHERE N_SOLICITUD = " & Me.TxtNumSolicitud.Text & " AND COMPAÑIA = " & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            'End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "ERROR")
        Finally
            Conexion_Track.Close()
        End Try
        Return 0
    End Function
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
            Sql = "select MAX(linea) as ultima from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
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
            Sql = "select count(*) as total from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
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
    'Devuleve la ultima fecha
    Private Function getUltimaFechaPago(ByVal solicitud As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try

            Conexion_Track.Open()
            Sql = "SELECT MAX(FECHA_PAGO) as f FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE "
            Sql &= "WHERE NUMERO_SOLICITUD=" & solicitud & " And Compañia = " & Compañia & " AND "
            Sql &= "INTERES_D=1 "
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Conexion_Track.Close()

            If Table.Rows(0).Item(0) Is DBNull.Value Then
                Return getPrimeraProgramacion(solicitud)
            Else
                Return Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Now
    End Function
    Private Function getPrimeraProgramacion(ByVal solicitud)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select MIN(FECHA_PAGO) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & solicitud & " AND COMPAÑIA=" & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Now
    End Function
    ' Programacion de cuota especiales para intereses pendientes
    Private Sub ProgramacionEspecial()
        Dim Saldo As Double = CDbl(Me.TxtCuotaEspecial.Text)
        Dim Cuota As Double = CDbl(Me.txtCanCuotaEspecial.Text)
        Dim TasaInteres As Double = 0
        Dim Tasa_Seguro As Double = 0
        Dim Periodo As Integer = IIf(Me.CbxPeriodo.SelectedValue = "MM", 30, 15)
        Dim InteresAcum As Double = 0
        Dim Capital As Double = 0
        Dim Interes As Double = 0
        Dim Seguro As Double = 0
        Dim DiasPP As Integer = PrimerFechaPago()
        Dim i As Integer = 1
        'Dim ultimaFecha As String
        'Dim mayor As String
        If Me.CmbProgramaInteres.SelectedIndex = 0 Or Me.CmbProgramaInteres.SelectedIndex = 1 Then
            Saldo = Me.txtMontoInteSeg.Text
            Cuota = Saldo
        End If
        If (Me.CmbProgramaInteres.SelectedIndex = 0) Then
            i = 1
        End If
        ' Si los intereses se programaran al final 
        If (Me.CmbProgramaInteres.SelectedIndex = 1) Then
            'MantenimientoProgramacion(linea, fecgaP, saldoIni, Capital, Interes, seguroDeuda, Cuota, saldoFin, InteresAcum, Bandera)
            MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
            i = Me.DgvProgramacion.Rows.Count
            'ultimaFecha = getUltimaFecha()
            'MessageBox.Show(ultimaFecha)
            'MessageBox.Show(Me.DgvProgramacion.Rows(i - 1).Cells(1).Value.ToString)
        End If


        While Saldo > Cuota
            Interes = (Saldo * TasaInteres * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            InteresAcum += Interes
            Seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Cuota - Interes - Seguro
            Capital = Math.Round(Capital, 2, MidpointRounding.ToEven)
            MantenimientoProgramacion(i, DtpFechaPrimerPag.Value, 0, 0, Capital, 0, Cuota, Saldo - Capital, InteresAcum, 1)
            DiasPP = Periodo
            Saldo -= Capital
            i += 1
        End While
        If Saldo > 0 Then
            Interes = (Saldo * TasaInteres * DiasPP) / 360
            Interes = Math.Round(Interes, 2, MidpointRounding.ToEven)
            Seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            Seguro = Math.Round(Seguro, 2, MidpointRounding.ToEven)
            Capital = Saldo
            Cuota = Saldo + Interes + Seguro
            MantenimientoProgramacion(i, DtpFechaPrimerPag.Value, 0, 0, Capital, 0, Cuota, Saldo - Capital, InteresAcum, 1)
        End If
    End Sub
    'Programa intereses pendientes a la par de la cuota
    Private Sub ProgramacionEspecial2()
        Dim Saldo As Double = CDbl(Me.txtMontoInteSeg.Text)
        Dim Cuota As Double = CDbl(Me.txtCanCuotaEspecial.Text)
        Dim TasaInteres As Double = 0
        Dim Tasa_Seguro As Double = 0
        Dim i As Integer
        Dim interes_nuevo As Double
        Dim interes_viejo As Double
        Dim NuevaCuota As Double
        Dim ViejaCuota As Double
        Dim numMaxLinea = getLineaMax()
        For i = 1 To numMaxLinea
            interes_viejo = getInteresViejo(i)
            ViejaCuota = getViejaCuota(i)
            If (i <> numMaxLinea) Then
                interes_nuevo = interes_viejo + Cuota
                NuevaCuota = ViejaCuota + Cuota
            Else
                NuevaCuota = ViejaCuota + Saldo
                interes_nuevo = interes_viejo + Saldo
            End If
            setInteresNuevo(i, interes_nuevo)
            setNuevaCuota(i, NuevaCuota)
            Saldo = Saldo - Cuota
        Next

    End Sub
    Private Function getViejaCuota(ByVal linea As Integer)
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

            Sql = "select CUOTA "
            Sql &= "from COOPERATIVA_PROGRAMACION_ILUSTRATIVA "
            Sql &= "where N_SOLICITUD = " & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
            Sql &= " AND LINEA=" & linea
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
    Private Sub setNuevaCuota(ByVal linea As Integer, ByVal NuevaCuota As Double)
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
            'select INTERES from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where  N_SOLICITUD=10890 and LINEA=1 
            Sql = "update COOPERATIVA_PROGRAMACION_ILUSTRATIVA "
            Sql &= "set CUOTA=" & NuevaCuota
            Sql &= " where N_SOLICITUD = " & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
            Sql &= " AND LINEA=" & linea
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub setInteresNuevo(ByVal linea As Integer, ByVal nuevoInteres As Double)
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

            Sql = "update COOPERATIVA_PROGRAMACION_ILUSTRATIVA "
            Sql &= "set INTERES=" & nuevoInteres
            Sql &= " where N_SOLICITUD = " & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
            Sql &= " AND LINEA=" & linea
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Function getInteresViejo(ByVal linea As Integer)
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

            Sql = "select INTERES "
            Sql &= "from COOPERATIVA_PROGRAMACION_ILUSTRATIVA "
            Sql &= "where N_SOLICITUD = " & Me.TxtNumSolicitud.Text & " AND COMPAÑIA=" & Compañia
            Sql &= " AND LINEA=" & linea
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
    Private Sub ProgramacionCuotaEspecial()
        Dim Saldo As Double = CDbl(Me.TxtCuotaEspecial.Text)

        Dim TasaInteres As Double = 0
        Dim Tasa_Seguro As Double = 0
        Dim Periodo As Integer = IIf(Me.CbxPeriodo.SelectedValue = "MM", 29, 14)
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
            MantenimientoProgramacion(i, DtpFechaPrimerPag.Value, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum, 1)
            Saldo -= Capital
            'DiasPP = Periodo
        Next
        SumarSeguro()
    End Sub

    Private Sub CmbProgramaInteres_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProgramaInteres.SelectedIndexChanged
        If (Me.CmbProgramaInteres.SelectedIndex = 0) Or (Me.CmbProgramaInteres.SelectedIndex = 1) Then
            Me.txtCanCuotaEspecial.Text = Me.txtMontoInteSeg.Text
            Me.txtCanNoCuotaEspecial.Text = 1
        End If
    End Sub
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
        If (Me.chkInteSeg.Checked = False) Then
            If Cuota > CDbl(Val(Me.TxtMonto.Text)) Then
                MessageBox.Show("Monto de la cuota especial Sobre pasa al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCuotaEspecial.Focus()
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
        Else
            'Si es una programacion de intereses pendientes
            'MantenimientoCuotasEspecialesPendientes
            'If Cuota > CDbl(Val(Me.txtMontoInteSeg.Text)) Then
            '    MessageBox.Show("Monto de la cuota especial Sobre pasa al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    TxtCuotaEspecial.Focus()
            '    Return
            'End If
            'BONIFICACION
            If Me.CbxPeriodoEspeciales.SelectedValue = "BO" Then
                If Fecha.Month.ToString = "6" And Fecha.Day.ToString = "12" Then
                    MantenimientoCuotasEspecialesPendientes(2)
                    MuestraProgramacionesCuotasEspeciales(0, 1)
                    Resta = CDbl(Val(Me.txtMontoInteSeg.Text)) - Cuota
                    Me.txtMontoInteSeg.Text = Resta
                    If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                        Me.BtnGuardar.Enabled = True
                        Me.BtnCalcular.Enabled = False
                    Else
                        Me.BtnGuardar.Enabled = False
                        Me.BtnCalcular.Enabled = True
                    End If
                    Total_CuotaEspecial()
                Else
                    MessageBox.Show("La fecha válida para programar cuotas de Bonificación es :12 de Junio ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            'AGUINALDO
            If Me.CbxPeriodoEspeciales.SelectedValue = "AG" Then
                If Fecha.Month.ToString = "12" And Fecha.Day.ToString = "12" Then
                    MantenimientoCuotasEspecialesPendientes(2)
                    MuestraProgramacionesCuotasEspeciales(0, 1)
                    Resta = CDbl(Val(Me.txtMontoInteSeg.Text)) - Cuota
                    Me.txtMontoInteSeg.Text = Resta
                    If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
                        Me.BtnGuardar.Enabled = True
                        Me.BtnCalcular.Enabled = False
                    Else
                        Me.BtnGuardar.Enabled = False
                        Me.BtnCalcular.Enabled = True
                    End If
                    Total_CuotaEspecial()
                Else
                    MessageBox.Show("La fecha válida para programar cuotas de Aguinaldo es :12 de Diciembre ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim Suma As Double
        Dim Valor As Double
        Dim valorInteres As Double
        If DgvProgramacionesEspeciales.RowCount <> 0 Then
            MuestraProgramacionesCuotasEspeciales(DgvProgramacionesEspeciales.CurrentRow.Cells(2).Value, 2)
            Valor = DgvProgramacionesEspeciales.CurrentRow.Cells(5).Value
            valorInteres = DgvProgramacionesEspeciales.CurrentRow.Cells(6).Value
            If (Valor <> 0) Then
                Suma = CDbl(Val(Me.TxtMonto.Text)) + Valor
                Me.TxtMonto.Text = Suma
            Else
                Suma = CDbl(Val(Me.txtMontoInteSeg.Text)) + valorInteres
                Me.txtMontoInteSeg.Text = Suma
            End If
            MuestraProgramacionesCuotasEspeciales(0, 1)
            '4:

            'If CDbl(Val(Me.TxtMonto.Text)) = 0 Then
            '    Me.BtnGuardar.Enabled = True
            '    Me.BtnCalcular.Enabled = False
            'Else
            '    Me.BtnGuardar.Enabled = False
            '    Me.BtnCalcular.Enabled = True
            'End If
            Total_CuotaEspecial()
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub txtMontoInteSeg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoInteSeg.TextChanged
        Me.TxtCuotaEspecial.Text = Me.txtMontoInteSeg.Text
        Me.txtCanCuotaEspecial.Text = Me.txtMontoInteSeg.Text
    End Sub
    Private Sub Insertar_SolicitudesN()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_IU " & Compañia & "," _
            & getNumSolicitud() & "," & Me.CbxDeduccion.SelectedValue & "," & Me.TxtNumSolicitud.Text & ",'" & Me.TxtCodigoAs.Text & "'," _
            & CInt(Me.TxtCodigoBuxis.Text) & ",0,'" & Format(Me.DtpFechaIniPres.Value, "dd/MM/yyyy") & "'," _
            & "0," & Me.TxtMonto.Text & "," & LblInteres.Text & ",'" & CbxPeriodo.SelectedValue & "'," & Me.NudNumeroCuot.Value & ",'" & Usuario & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function getNumSolicitud() As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        Dim ValorRetorno As Integer = 0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT SOLICITUD "
            Sql &= "FROM COOPERATIVA_CATALOGO_SOLICITUDES "
            Sql &= "WHERE DEDUCCION = " & Me.CbxDeduccion.SelectedValue & " AND COMPAÑIA= " & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
            If Table.Rows.Count > 0 Then
                ValorRetorno = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return ValorRetorno
    End Function

    Private Sub ActualizarAutorizaciones(ByVal Autorizacion As Integer)
        Dim Comentario As String = ""
        Dim Sql As String = "SELECT C.DESCRIPCION_SOLICITUD FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES C WHERE S.COMPAÑIA = C.COMPAÑIA AND S.SOLICITUD = C.SOLICITUD AND S.COMPAÑIA = " & Compañia & " AND S.CORRELATIVO = "
        Dim SqlSaldo As String = "SELECT ISNULL(SUM(CAPITAL),0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE CAPITAL_D =0 AND COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = "
        Dim SqlFact As String = "SELECT NUMERO_FACTURA FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = "
        Dim solicitudes As String() = Split(Me.TxtNumSolicitudes.Text, ",")
        Dim solicitud As String
        Dim SaldoPend As Double
        Dim NumFact, Deduccion2 As Integer
        Dim comentario1 As String ', comentario3
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Deduccion2 = Func.obtenerEscalar("SELECT COUNT(DEDUCCION) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO IN (" & Me.TxtNumSolicitudes.Text & ") AND DEDUCCION <> " & Me.CbxDeduccion.SelectedValue)
        If Deduccion2 > 0 Then
            Comentario = "CONSOLIDACIÓN POR TRASLADO DE SALDOS A " & Me.CbxDeduccion.Text & " " & Me.TxtNumSolicitudes.Text
        Else
            Comentario = "CONSOLIDACIÓN DE SALDOS " & Me.TxtNumSolicitudes.Text
        End If
        For Each solicitud In solicitudes
            comentario1 = Func.obtenerEscalar(Sql & solicitud).ToString()
            SaldoPend = Format(Func.obtenerEscalar(SqlSaldo & solicitud), "$0.00")
            NumFact = Func.obtenerEscalar(SqlFact & solicitud)
            Comentario = Comentario.Replace(solicitud, IIf(NumFact = 0, vbCrLf & "-SOLICITUD #" & solicitud, vbCrLf & "-FACT. #" & NumFact) & " DE " & comentario1 & " ($" & Format(SaldoPend, "0.00") & ")")
        Next
        'If Comentario.Length > 150 Then
        '    comentario1 = Comentario.Substring(0, 150)
        '    comentario3 = Comentario.Substring(149)
        'Else
        '    comentario1 = Comentario
        '    comentario3 = " "
        'End If
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = CInt(Me.TxtNumSolicitud.Text)
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = Comentario
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Me.DtpFechaIniPres.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = vbCrLf & "NUEVA SOLICITUD No." & Me.TxtNumSolicitud.Text
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = fechaInicio
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = ""
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
            Sql = Sql & Compañia & ",'" ' @COMPAÑIA int, 
            Sql = Sql & getNumSolicitud() & "'," '@SOLICITUD int,
            Sql = Sql & Me.CbxDeduccion.SelectedValue  '@DEDUCCION int,
            Sql = Sql & "," & Me.TxtNumSolicitud.Text & ",'" '@CORRELATIVO int,
            Sql = Sql & (Me.TxtCodigoAs.Text) & "'," '@CODIGO_AS Nvarchar(6)
            Sql = Sql & CInt(Me.TxtCodigoBuxis.Text)             '@CODIGO_BUXIS int,
            Sql = Sql & ",'" & Format(Me.DtpFechaIniPres.Value, "dd/MM/yyyy") & "'," '@FECHA_SOLICITUD datetime,
            Sql = Sql & "'" & Usuario & "'," ' '@RECIBIDO Nvarchar(100),
            Sql = Sql & "'" & Usuario & "'," '@REVISADO Nvarchar(100),
            Sql = Sql & "0," '@AUTORIZACION_EX bit,
            Sql = Sql & Me.TxtMonto.Text & ","  '@CANTIDAD Money,
            Sql = Sql & "'CONSOLIDACIÓN SOLICITUDES No." & Me.TxtNumSolicitudes.Text & "'," '@RAZON NVARCHAR(100),
            Sql = Sql & Me.LblInteres.Text '      @INTERES Money,
            Sql = Sql & ",'" & CbxPeriodo.SelectedValue '@PERIODO nvarchar(50),
            Sql = Sql & "'," & Me.NudNumeroCuot.Value '@PLAZO int,
            Sql = Sql & ",0," '      @PRIMER_QUINCENA Bit,
            Sql = Sql & "'CONSOLIDACIÓN SOLICITUDES No." & Me.TxtNumSolicitudes.Text & "'," '@OBSERVACIONES Nvarchar(150),"
            Sql = Sql & "'0'," '      @CODIGO_ASFI Nvarchar(6),
            Sql = Sql & "0," '@CODIGO_BUXISFI Int,
            Sql = Sql & "'0'," '      @CODIGO_ASFI2 Nvarchar(6),
            Sql = Sql & "0," '      @CODIGO_BUXISFI2 Int,
            Sql = Sql & "'0'," '      @CODIGO_ASFI3 Nvarchar(6),
            Sql = Sql & "0," '      @CODIGO_BUXISFI3 Int,
            Sql = Sql & "'" & Usuario & "'" '      @USUARIO varchar(12)
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub setSolicitudPagada(ByVal Bandera As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS " & vbCrLf
            Sql &= " SET PAGADA = 1" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= " AND CORRELATIVO = " & Me.TxtNumSolicitud.Text
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

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

    Private Sub FrmConsolidarDeudas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpNormales_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpNormales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpEspeciales_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpEspeciales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub CbxDeduccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxDeduccion.SelectedIndexChanged
        If Not Iniciando Then
            Me.LblInteres.Text = Me.getTasaInteresSol(CbxDeduccion.SelectedValue)
            Me.LblSegDeuda.Text = Me.getTasaSeguroSol(CbxDeduccion.SelectedValue)
            ParamDeduc(CbxDeduccion.SelectedValue)
        End If
    End Sub

    Private Sub ParamDeduc(ByVal deduc As Integer)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_Track As SqlDataReader
        Dim Table As DataTable
        Dim Sql As String
        deduccionPtmo = Func.obtenerEscalar("SELECT CONVERT(INT, VALOR) AS VALOR FROM [dbo].[CONTABILIDAD_CATALOGO_CONSTANTE] WHERE CONSTANTE = 11")
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()

            Sql = "SELECT DEDUCCION, DESCRIPCION_SOLICITUD, DESCRIPCION_SOLICITUD, CUOTA_INICIAL, CUOTA_FINAL " & vbCrLf
            Sql &= "FROM COOPERATIVA_CATALOGO_SOLICITUDES " & vbCrLf
            Sql &= "WHERE DEDUCCION = " & deduc & " AND COMPAÑIA = " & Compañia

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.NudNumeroCuot.Minimum = Table.Rows(0).Item("CUOTA_INICIAL")
            Me.NudNumeroCuot.Maximum = Table.Rows(0).Item("CUOTA_FINAL")
            Me.NudNumeroCuot.Value = Table.Rows(0).Item("CUOTA_FINAL")
            'Me.CbxDeduccion.SelectedValue = deduccionPtmo
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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