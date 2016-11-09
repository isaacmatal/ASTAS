Imports System.Data
Imports System.Data.SqlClient
Public Class frmAbonoEfectivo
    Public Compañia_Value As Integer
    Public Num_Solicitud As String
    Public Monto_value As Double
    Public totalSolicitudes As Integer
    Public Cod_buxis
    Public Cod_AS
    Public Socio
    'Variables de partida
    Private centroCostos As String = "1"
    Private tipoDoc As String
    Private origen As String
    Dim Func As New jarsClass
    Dim TablaProgs As New DataTable

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
    Private Sub setOrigen()
        origen = Func.obtenerEscalar("select ORIGEN from COOPERATIVA_CATALOGO_SOCIOS where COMPAÑIA=" & Compañia & " and CODIGO_EMPLEADO_AS='" & Trim(Me.TxtCodigoAs.Text) & "' and CODIGO_EMPLEADO=" & Trim(Me.TxtCodigoBuxis.Text))
    End Sub
    Private Sub frmAbonoEfectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        compañia = Compañia_Value
        Me.TxtCodigoBuxis.Text = Cod_buxis
        Me.TxtCodigoAs.Text = Cod_AS
        Me.TxtNombre.Text = Socio
        Me.TxtNumSolicitud.Text = Num_Solicitud
        CrearTabla()
        Iniciando = True
        setOrigen()
        'getPrimerSolicitud()
        'primeros calculos 
        'getDetalleSolicitudes0()
        getDetalleSolicitudes()
        Total_Intereses()
        'Presentacion en pantalla
        Deducciones(getPrimerSolicitud())
        setTasasInteres()
        cargaDetalleProgramacionesSolicitud(getPrimerSolicitud())
        CargaPeriodos()
        CargaPeriodosEspeciales()
        SetearFechas()
        'realizaAbono(0)
        setSolicitudReprogramar()
        BlockBotones()
        Me.txtAbono.Enabled = False
        Me.cmbBancos.Enabled = False
        Me.txtNoRemesa.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.rbrnRemesa.Enabled = False
        Me.rbtnAhorroExtraordinario.Enabled = False
        Me.TabPage6.Parent = Nothing
        Func.CargaBancos(compañia, Me.cmbBancos)
        setOrigen()
        UltimoRetiroAhorros()
        DisponibleSocio()
        Iniciando = False
    End Sub
    Private Sub BlockBotones()
        Me.btnAbonar.Enabled = False
        Me.RadioButton1.Enabled = False
        Me.RadioButton2.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.btnPreCalculo.Enabled = False
        Me.BtnCalcular.Enabled = False
        Me.btnAbonar.Enabled = False
    End Sub
    Private Sub NoBlockBotones()
        Me.btnAbonar.Enabled = True
        Me.RadioButton1.Enabled = True
        Me.RadioButton2.Enabled = True
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
            Sql = "Select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO where COMPAÑIA=" & compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If Table.Rows.Count > 0 Then
                If origen = 5 Or origen = 6 Then
                    If CbxDeduccion.SelectedValue = CInt(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")) Then
                        Valor = Format(Func.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 30"), "0.000")
                    Else
                        Valor = Table.Rows(0).Item(0)
                    End If
                Else
                    If origen = 2 And Me.CbxDeduccion.SelectedValue = 257 Then
                        Valor = 0.0
                    Else
                        Valor = Table.Rows(0).Item(0)
                    End If
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Valor
    End Function
    Private Function getTasaInteres()
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
            Sql = "Select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES where COMPAÑIA=" & compañia & " and DEDUCCION=" & Me.CbxDeduccion.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If Table.Rows.Count > 0 Then
                If origen = 2 And Me.CbxDeduccion.SelectedValue = 257 Then
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
    Private Sub Deducciones(ByVal solicitud As String)
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
            Sql &= "ON CS.SOLICITUD = CCD.SOLICITUD " & VBCRLF
            Sql &= "WHERE CCD.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "  AND CCD.CORRELATIVO = " & solicitud
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            'me.CbxDeduccion.
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "DEDUCCION"
            Me.CbxDeduccion.DisplayMember = "DESCRIPCION_DEDUCCION"
            Me.NudNumeroCuot.Minimum = Table.Rows(0).Item("CUOTA_INICIAL")
            Me.NudNumeroCuot.Maximum = Table.Rows(0).Item("CUOTA_FINAL")
            Me.NudNumeroCuot.Value = Table.Rows(0).Item("CUOTA_FINAL")
            setTasasInteres()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
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
            Sql &= "where ccd.COMPAÑIA=" & compañia
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
    Private Function getPrimerSolicitud()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        Dim i As Integer
        Dim prim As String

        i = 0
        prim = ""
        For Each solicitud As String In solicitudes
            If i = 0 Then
                prim = solicitud
            End If
            i += 1
        Next

        Return prim
    End Function
    Private Sub setSolicitudReprogramar()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        If solicitudes.Length > 0 Then
            origen = Func.obtenerEscalar("SELECT PERIODO FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & solicitudes(0)).ToString
            If origen = "QQ" Or origen = "MM" Then
                Me.CbxPeriodo.SelectedValue = origen
            End If
        End If
        Me.txtSolicitud.Text = "0" 'Func.obtenerEscalar("SELECT ULTIMO FROM dbo.COOPERATIVA_CORRELATIVOS_DOCUMENTOS WHERE TIPO_DOCUMENTO = 'SOL'").ToString()
    End Sub
    Private Function getUltimaSolicitud()
        Dim ultima As String

        ultima = Func.obtenerEscalar("select ultimo from dbo.COOPERATIVA_CORRELATIVOS_DOCUMENTOS WHERE TIPO_DOCUMENTO = 'SOL'").ToString()

        Return ultima
    End Function
    '----------------------------------------------------------------------
    '----------------------------------------------------------------------
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        realizaAbono(0)
        '-----------------------------------------------------------
        ' Validacion de reprogramacion
        If (Not (Me.RadioButton1.Checked Or Me.RadioButton2.Checked)) Then
            MessageBox.Show("Se debe seleccionar el tipo de programación (cuota o numero de cuotas) a realizar.", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Val(Me.txtNuevoSaldo.Text)) = 0 Then
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
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.txtNuevoSaldo.Text) Then
            MessageBox.Show("La cuota es mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        realizaAbono(0)
    End Sub
    Private Sub realizaAbono(ByVal bandera As Integer)
        Dim query As String
        Dim abono As Double = CDbl(Me.txtAbono.Text)
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        Dim capital As Double
        Dim capitalDescontado As Double
        Dim interes As Double
        Dim seguro As Double
        Dim i, corrAbono As Integer
        Dim Linea As Integer
        'Para calculo previo de datos
        If bandera = 0 Then
            'For Each solicitud As String In solicitudes
            '    Deducciones(solicitud)
            '    cargaDetalleProgramacionesSolicitud(solicitud)
            '    interesesFecha = getInteresesFecha(solicitud, 0)
            '    capital = getDescripcionCapital(solicitud, 0)

            '    abono = abono - interesesFecha

            '    If abono > capital Then
            '        abono = abono - capital
            '        capital = 0
            '    Else
            '        capital = capital - abono
            '    End If
            'Next
            abono = abono - Val(Me.txtInteres.Text) - Val(Me.txtSeguro.Text)
            Me.txtNuevoSaldo.Text = Format(Val(Me.TxtMonto.Text) - abono, "0.00")
            If Val(Me.txtNuevoSaldo.Text) = 0 Then
                MsgBox("Se ha cancelado la deuda en su totalidad." & vbCrLf & "Haga click en abonar para guardar los cambios.", MsgBoxStyle.Information, "Abono Deudas")
                Me.BtnNuevo_Click(New Object, New System.EventArgs)
            End If
        End If
        'realizo el proceso 
        If bandera = 1 Then
            'For Each solicitud As String In solicitudes
            'Deducciones(solicitud)
            'cargaDetalleProgramacionesSolicitud(solicitud)
            'interesesFecha = getInteresesFecha(solicitud, 0)
            'capital = getDescripcionCapital(solicitud, 0)

            For i = 0 To Me.DgvDetalleSolicitudes.Rows.Count - 1
                'If Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value = solicitud Then
                capital = Math.Round(Me.DgvDetalleSolicitudes.Rows(i).Cells(2).Value, 2)
                If Val(Me.txtInteres.Text) > 0 Then
                    interes = Math.Round(Me.DgvDetalleSolicitudes.Rows(i).Cells(3).Value, 2)
                Else
                    interes = 0
                End If
                If Val(Me.txtSeguro.Text) > 0 Then
                    seguro = Math.Round(Me.DgvDetalleSolicitudes.Rows(i).Cells(4).Value, 2)
                Else
                    seguro = 0
                End If
                'Next

                abono = Math.Round(abono - interes - seguro, 2)

                If abono >= capital Then
                    capitalDescontado = capital
                Else
                    capitalDescontado = abono
                    Me.txtSolicitud.Text = Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value
                End If
                abono = Math.Round(abono - capital, 2)

                'If capital = 0 Then
                'Cancelar solicitud parcial o total
                Linea = Me.eliminaProgramacionesNoDescontadas(Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value)
                Linea += 1
                query = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]"
                query &= "([COMPAÑIA]"
                query &= ",[NUMERO_SOLICITUD]"
                query &= ",[LINEA]"
                query &= ",[ENVIADA]"
                query &= ",[RECIBIDA]"
                query &= ",[FECHA_PAGO]"
                query &= ",[SALDO_INI]"
                query &= ",[CAPITAL]"
                query &= ",[CAPITAL_D]"
                query &= ",[INTERES]"
                query &= ",[INTERES_D]"
                query &= ",[SEG_DEUDA]"
                query &= ",[SEG_DEUDA_D]"
                query &= ",[CUOTA]"
                query &= ",[CUOTA_D]"
                query &= ",[SALDO_FIN]"
                query &= ",[INTERES_ACUM]"
                query &= ",[REPROGRAMADA]"
                query &= ",[CUOTA_NO_DESCONTADA]"
                query &= ",[USUARIO_CREACION]"
                query &= ",[USUARIO_CREACION_FECHA]"
                query &= ",[USUARIO_EDICION]"
                query &= ",[USUARIO_EDICION_FECHA]"
                query &= ",[COMENTARIO])"
                query &= "VALUES"
                query &= "(" & Compañia
                query &= "," & Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value
                query &= "," & Linea
                query &= ",0"
                query &= ",0"
                query &= ",'" & Format(Me.dtpFechaAbono.Value, "dd/MM/yyyy") & "'"
                query &= "," & capital
                query &= "," & capitalDescontado
                query &= ",1"
                query &= "," & interes
                query &= ",1"
                query &= "," & seguro
                query &= ",1"
                query &= "," & (capitalDescontado + interes + seguro).ToString()
                query &= ",0"
                query &= "," & (capital - capitalDescontado).ToString()
                query &= ",0"
                query &= ",0"
                query &= ",0"
                query &= ",'" & Usuario & "'"
                query &= ",GETDATE()"
                query &= ",'" & Usuario & "'"
                query &= ",GETDATE()"
                query &= ",'" & Me.txtComentario.Text & "')"
                Func.Ejecutar_ConsultaSQL(query)
                'guarda informacion del abono
                query = "EXEC dbo.sp_COOPERATIVA_ABONOS " & compañia
                query &= "," & Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value & ",'" & Me.TxtCodigoAs.Text.Trim & "',"
                query &= Me.TxtCodigoBuxis.Text.Trim & "," & (interes + seguro + capitalDescontado).ToString()
                query &= "," & interes & "," & seguro & "," & capitalDescontado & "," & IIf((capital - capitalDescontado) > 0, "0", "1") & ","
                If (Me.rbrnRemesa.Checked = True) Then
                    query &= "1,"
                Else
                    query &= "0,"
                End If
                If (Me.rbtnAhorroExtraordinario.Checked = True) Then
                    query &= "1,"
                Else
                    query &= "0,"
                End If
                query &= Me.cmbBancos.SelectedValue & ","

                If Me.rbrnRemesa.Checked = True Then
                    query &= "'" & Me.txtNoRemesa.Text.Trim & "',"
                Else
                    query &= "0,"
                End If

                query &= Usuario & ",1"
                Func.Ejecutar_ConsultaSQL(query)
                query = "SELECT ISNULL(MAX(CORRELATIVO),0) AS CORRELATIVO FROM COOPERATIVA_SOLICITUDES_ABONOS" & vbCrLf
                query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                query &= " AND CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
                query &= " AND CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
                corrAbono = CInt(Func.obtenerEscalar(query))
                query = "UPDATE COOPERATIVA_SOLICITUDES_ABONOS " & vbCrLf
                query &= "SET FECHA_ABONO = '" & Format(Me.dtpFechaAbono.Value, "dd/MM/yyyy") & "'" & vbCrLf
                query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                query &= " AND CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
                query &= " AND CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & vbCrLf
                query &= " AND CORRELATIVO = " & corrAbono
                Func.Ejecutar_ConsultaSQL(query)
                If abono <= 0 Then
                    Exit For
                End If
            Next
            If Val(Me.txtNuevoSaldo.Text) > 0 And Me.DgvProgramacion.Rows.Count > 0 Then
                'Si todavia hay saldo pendiente de pago, se inserta la programación calculada
                query = "DELETE FROM COOPERATIVA_PROGRAMACION_ILUSTRATIVA WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.txtSolicitud.Text
                Func.Ejecutar_ConsultaSQL(query)
                query = "UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET LINEA = LINEA + " & Linea & ", N_SOLICITUD = " & Me.txtSolicitud.Text & " WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = 0"
                Func.Ejecutar_ConsultaSQL(query)
                MantenimientoProgramacionDetalle()
            End If
            If Me.DgvProgramacionesEspeciales.Rows.Count > 0 Then
                'Si todavia hay saldo pendiente para cuotas especiales, se inserta la programación calculada
                query = "DELETE FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_CUOTAS_ESPECIALES WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & Me.txtSolicitud.Text
                Func.Ejecutar_ConsultaSQL(query)
                query = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_CUOTAS_ESPECIALES SET NUMERO_SOLICITUD = " & Me.txtSolicitud.Text & " WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = 0"
                Func.Ejecutar_ConsultaSQL(query)
                GuardarVariasCuotasEspeciales(1)
            End If
        End If
    End Sub
    'Detalles de retiro Ahorro extraordinario
    Sub UltimoRetiroAhorros()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Sql As String
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & compañia & "," & Me.TxtCodigoBuxis.Text & ",'" & Me.TxtCodigoAs.Text & "','FURPRDF'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            If (Table.Rows.Count) <= 0 Then
                Me.TxtFechaURetiro.Text = "Sin Retiro"
                Me.TxtFechaPRetiro.Text = "Sin Retiro"
                Me.TxtDiasFaltantes.Text = 0
                Me.TxtCantidadRetirada.Text = "0.00"
                Exit Sub
            End If

            Me.TxtFechaURetiro.Text = Table.Rows(0).Item("Ultima Fecha Retiro")
            Me.TxtFechaPRetiro.Text = Table.Rows(0).Item("Proxima Fecha Retiro")
            If Table.Rows(0).Item("Dias Faltantes") < 0 Then
                Me.TxtDiasFaltantes.Text = 0
            Else
                Me.TxtDiasFaltantes.Text = Table.Rows(0).Item("Dias Faltantes")
            End If
            Me.TxtCantidadRetirada.Text = Format(Table.Rows(0).Item("Cantidad Retirada"), "0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
        End Try
    End Sub
    Private Sub DisponibleSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi, AhorroExtraOrdi As Double
        Dim Deuda As Double
        Dim Bandera As Integer
        Dim SQL

        Bandera = 1
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            SQL = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO '" & Trim(Me.TxtCodigoAs.Text) & "', " & Trim(Me.TxtCodigoBuxis.Text) & ", " & compañia & ", " & Bandera
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            AhorroExtraOrdi = 0
            Deuda = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                AhorroExtraOrdi = DataReader_Track.Item("AHORRO EXTRAORDINARIO")
                Deuda = DataReader_Track.Item("MONTO POR SALDAR")
                Me.TxtTotalAhorro_Ordinario.Text = Format(AhorroOrdi, "0.00")
                Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(AhorroExtraOrdi, "0.00")
                Me.TxtTotalAhorro.Text = Format(AhorroOrdi + AhorroExtraOrdi, "0.00")
                'Me.TxtTotalDeudasSocio.Text = Format(Deuda, "0.00")
            End If
            'If Val(Me.TxtTotalAhorro_Ordinario.Text) > 0 And AhorroOrdi > Deuda Then
            '    Me.TxtPrestamo_SinFiador.Text = (Val(Me.TxtTotalAhorro_Ordinario.Text) - Deuda).ToString("0.00")
            '    Me.TxtPrestamo_ConFiador.Text = ((Val(Me.TxtTotalAhorro_Ordinario.Text) * 2) - Deuda).ToString("0.00")
            'Else
            '    Me.TxtPrestamo_SinFiador.Text = "0.00"
            '    Me.TxtPrestamo_ConFiador.Text = "0.00"
            'End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error DisponibleSocio")
        End Try
    End Sub
    Private Sub corregircorrelativo()
        Dim lineamax As Integer
        Dim linea As Integer
        Dim newLinea As Integer
        Dim ajuste As Integer

        lineamax = Func.obtenerEscalar("select MAX(LINEA) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & Me.txtSolicitud.Text & "  and COMPAÑIA=" & Compañia)
        linea = Func.obtenerEscalar("select MIN(LINEA) from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.txtSolicitud.Text & " and COMPAÑIA=" & Compañia)

        newLinea = lineamax + 1
        ajuste = newLinea - linea
        If ajuste < 0 Then
            ajuste = ajuste * -1
        End If

        Func.Ejecutar_ConsultaSQL("update COOPERATIVA_PROGRAMACION_ILUSTRATIVA set linea=(LINEA+" & ajuste & ") where N_SOLICITUD=" & Me.txtSolicitud.Text & " and COMPAÑIA=" & Compañia)
    End Sub
    Private Sub GuardarNuevaProgramacion()
        Try
            'No hay  cuotas especiales                
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount = 0 Then
                'If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                MantenimientoProgramacionEncabezado()
                corregircorrelativo() ' Para evitar duplicidad de llaves primarias 
                MantenimientoProgramacionDetalle()
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False

                Me.BtnGuardar.Enabled = False
                Me.BtnEliminar.Enabled = False
                MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Return
                'End If
            End If
            'No hay  cuotas  “Normales”               
            If DgvProgramacionesEspeciales.RowCount <> 0 And DgvProgramacion.RowCount = 0 And CDbl(Val(Me.txtNuevoSaldo.Text)) = 0 Then
                'If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtNoSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then

                MantenimientoProgramacionEncabezado()
                GuardarCuotasEspeciales(8)
                GuardarCuotasEspeciales(9)
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False

                Me.BtnGuardar.Enabled = False
                Me.BtnEliminar.Enabled = False
                MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Return
                'End If
            End If
            'Hay  cuotas  “Normales”   y Especiales            
            If DgvProgramacion.RowCount <> 0 And DgvProgramacionesEspeciales.RowCount <> 0 Then
                'If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & txtNoSolicitud.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then

                MantenimientoProgramacionEncabezado()
                MantenimientoProgramacionDetalle()
                GuardarVariasCuotasEspeciales(1)
                GuardarCuotasEspeciales(9)
                Me.BtnGuardar.Enabled = False
                Me.BtnCalcular.Enabled = False
                Me.TxtCuota.Enabled = False
                Me.NudNumeroCuot.Enabled = False
                Me.BtnNuevo.Enabled = False

                Me.BtnGuardar.Enabled = False
                Me.BtnEliminar.Enabled = False
                MessageBox.Show("La solicitud se ha programado de manera exitosa", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()
                Return
                'End If
            End If
        Catch ex As Exception
            MsgBox("¡No puede guardar la programación, favor verificar Datos !", MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub
    Private Sub cancelarDeuda(ByVal solicitud As String)
        Dim Linea As Integer
        Linea = Me.eliminaProgramacionesNoDescontadas(solicitud)
        'modificaIntereses(solicitud)
        ' Poner banderas de descuentos a 1
        'Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CAPITAL_D=1, INTERES_D=1, SEG_DEUDA_D=1 WHERE COMPAÑIA=" & compañia & " and NUMERO_SOLICITUD=" & solicitud)
    End Sub
    Private Sub modificaIntereses(ByVal solicitud As String)
        Dim fechaActual As String = Format(getFechaActual(), "Short Date")
        Dim fechaProxPago = Func.obtenerEscalar("select MIN(fecha_pago) as FECHA_PAGO from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where COMPAÑIA=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and CAPITAL_D=0 and INTERES_D=0 and SEG_DEUDA_D=0")
        Dim interesFecha As Double = 0
        Dim SeguroFecha As Double = 0
        Dim i As Integer

        For i = 0 To Me.DgvDetalleSolicitudes.Rows.Count - 1
            If Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value = solicitud Then
                interesFecha = Me.DgvDetalleSolicitudes.Rows(i).Cells(3).Value
                SeguroFecha = Me.DgvDetalleSolicitudes.Rows(i).Cells(4).Value
            End If
        Next

        'Cambio los intereses del proximo pago a la fecha
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES=" & interesFecha & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        'Setea los intereses a 0 
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES=0 where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO > '" & fechaProxPago & "'")
        'Mismo procedimiento para el seguro de deuda SEG_DEUDA
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET SEG_DEUDA=" & SeguroFecha & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET SEG_DEUDA=0 where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO > '" & fechaProxPago & "'")
        'Cambio la fehca del proximo pago a la actual
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET FECHA_PAGO=GETDATE() where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
    End Sub
    Private Sub modificaProxPago(ByVal solicitud As String, ByVal capital As String)
        Dim fechaActual As String = Format(Now(), "Short Date")
        Dim fechaProxPago As String = Format(Func.obtenerEscalar("select MIN(fecha_pago) as FECHA_PAGO from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where COMPAÑIA=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and INTERES_D=0"), "dd/MM/yyyy")
        'Try
        '    'Trata de acortar la fecha, 
        '    'el formato del abono es yyyy-MM-dd HH:mm:ss
        '    'el formato cuando se reprograma es yyyy/MM/dd 
        '    fechaProxPago = fechaProxPago.Substring(0, 19)
        'Catch
        'End Try
        Dim SaldoInicio As Double = Func.obtenerEscalar("SELECT SALDO_INI FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Dim interesFecha As Double = 0
        Dim SeguroFecha As Double = 0
        Dim interesesAcumulados As Double
        Dim i As Integer

        For i = 0 To Me.DgvDetalleSolicitudes.Rows.Count - 1
            If Me.DgvDetalleSolicitudes.Rows(i).Cells(0).Value = solicitud Then
                interesFecha = Me.DgvDetalleSolicitudes.Rows(i).Cells(3).Value
                SeguroFecha = Me.DgvDetalleSolicitudes.Rows(i).Cells(4).Value
            End If
        Next

        'Cambio capital,Intereses, seguro, saldos y fehca del pago
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CAPITAL=" & capital & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES=" & interesFecha & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        interesesAcumulados = Func.obtenerEscalar("SELECT ISNULL(SUM(INTERES),0) INTERES_ACUMULADO from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO<='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET SEG_DEUDA=" & SeguroFecha & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET SALDO_FIN=" & (CDbl(SaldoInicio) - CDbl(capital)) & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CUOTA=" & (CDbl(capital) + CDbl(interesFecha) + CDbl(SeguroFecha)) & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES_ACUM=" & interesesAcumulados & " where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        'Marcar programacion de descontada
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CAPITAL_D=1, INTERES_D=1, SEG_DEUDA_D=1 WHERE Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
        Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET FECHA_PAGO=GETDATE() where Compañia=" & compañia & " and NUMERO_SOLICITUD=" & solicitud & " and FECHA_PAGO='" & fechaProxPago & "'")
    End Sub

    Private Function getMinimoRequerido()
        Dim totalIntereses As Double
        Dim minimo As Double
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        Dim i As Integer = totalSolicitudes

        totalIntereses = CDbl(Me.txtInteres.Text) + CDbl(Me.txtSeguro.Text)
        minimo = 0
        For Each solicitud As String In solicitudes
            If i = 1 Then
                minimo += 0.01
            Else
                minimo += getDescripcionCapital(solicitud, 0)
            End If
            i = i - 1
        Next
        minimo += totalIntereses

        Return minimo
    End Function

    Private Function getInteresesFecha(ByVal solicitud As String, ByVal bandera As Integer)
        'Obtiene los intereses Generados a la fecha a partir del ultimo pago
        Deducciones(solicitud)
        setTasasInteres()
        Dim fechaActual As String = Format(Now(), "Short Date")
        Dim fechaUltimoPago As String = Format(getUltimaFechaPago(solicitud, 1), "Short Date")
        Dim Saldo As Double = getDescripcionCapital(solicitud, 0)
        Dim TasaInteres As Double = (Me.LblInteres.Text) / 100
        Dim Tasa_Seguro As Double = CDbl(Trim(LblSegDeuda.Text) / 100)
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

    Private Function getDiffDias(ByVal fechaActual As String, ByVal fechaAnterior As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            'exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI 2,'2012-01-01','2012-016-03',1,0,0
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI 2,'" & fechaAnterior & "','" & fechaActual & "',1,0,0"
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
        Return 0
    End Function
    Private Function getFechaActual()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DS As New DataSet()
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "dbo.sp_FECHA_ACTUAL_SERVIDOR 010001"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            DataAdapter_.Fill(DS)
            Return DS.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_Track.Close()
        End Try
        Return Now
    End Function
    Private Function getUltimaFechaPago(ByVal solicitud As String, ByVal bandera As Integer)
        Dim fecha As String = Now
        Dim i As Integer
        Dim hayPago As Boolean = False

        For i = 0 To Me.DgvDetalleProgra.Rows.Count - 1
            If Me.DgvDetalleProgra.Rows(i).Cells(5).Value = True And Me.DgvDetalleProgra.Rows(i).Cells(7).Value = True And Me.DgvDetalleProgra.Rows(i).Cells(9).Value = True Then
                fecha = Me.DgvDetalleProgra.Rows(i).Cells(2).Value
                hayPago = True
            End If
            If Not hayPago And i = 0 Then
                fecha = Me.DgvDetalleProgra.Rows(i).Cells(2).Value
            End If
        Next
        Return fecha
    End Function
    Private Function esNumero(ByVal cad As String)
        Try
            Dim abono As Double
            abono = Convert.ToDecimal(cad)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub Total_Intereses()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        Dim totalIntereses As Double
        Dim totalSeguro As Double
        Dim fechaActual As String = Format(getFechaActual(), "Short Date")
        Dim fechaUltimoPago As String
        Dim Saldo As Double
        Dim TasaInteres As Double
        Dim Tasa_Seguro As Double
        Dim DiasPP As Integer
        Dim interes As Double
        Dim seguro As Double

        totalIntereses = 0
        totalSeguro = 0
        For Each solicitud As String In solicitudes
            Deducciones(solicitud)
            setTasasInteres()
            cargaDetalleProgramacionesSolicitud(solicitud)

            TasaInteres = CDbl(Me.LblInteres.Text) / 100
            Tasa_Seguro = CDbl(Trim(LblSegDeuda.Text) / 100)

            Saldo = getDescripcionCapital(solicitud, 0)
            fechaUltimoPago = Format(getUltimaFechaPago(solicitud, 1), "Short Date")
            DiasPP = getDiffDias(fechaActual, fechaUltimoPago)

            If DiasPP < 0 Then
                DiasPP = 0
            End If

            interes = (Saldo * TasaInteres * DiasPP) / 360
            interes = Math.Round(interes, 2, MidpointRounding.ToEven)

            seguro = ((Saldo * Tasa_Seguro) * DiasPP) / 30
            seguro = Math.Round(seguro, 2, MidpointRounding.ToEven)

            totalIntereses = totalIntereses + interes
            totalSeguro = totalSeguro + seguro
        Next

        Me.txtInteres.Text = totalIntereses
        Me.txtSeguro.Text = totalSeguro

    End Sub
    Private Sub getDetalleSolicitudes()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        Dim totalInteres As String
        Dim totalSeguro As String
        Dim capital As String
        Dim descripcionSolicitud As String
        Dim deudaTotal As Double
        Dim dt As DataTable = New DataTable("Datos")
        Dim columna As DataColumn
        Dim reg As DataRow
        Dim i As Integer

        i = 0

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.Int32")
        columna.ColumnName = "Solicitud"
        columna.Caption = "No.Solicitud"
        dt.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.String")
        columna.ColumnName = "Descripcion"
        columna.Caption = "Solicitud"
        dt.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.Double")
        columna.ColumnName = "Capital"
        columna.Caption = "Capital"
        dt.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.Double")
        columna.ColumnName = "Intereses"
        columna.Caption = "Intereses"
        dt.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.Double")
        columna.ColumnName = "Seguro"
        columna.Caption = "Seguro"
        dt.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = System.Type.GetType("System.Double")
        columna.ColumnName = "Total"
        columna.Caption = "Total"
        dt.Columns.Add(columna)

        For Each solicitud As String In solicitudes
            Try
                Deducciones(solicitud)
                setTasasInteres()
                cargaDetalleProgramacionesSolicitud(solicitud)

                totalInteres = getInteresesFecha(solicitud, 1)
                totalSeguro = getInteresesFecha(solicitud, 2)
                descripcionSolicitud = getDescripcionCapital(solicitud, 1)
                capital = getDescripcionCapital(solicitud, 0)
                deudaTotal = CDbl(capital) + CDbl(totalInteres) + CDbl(totalSeguro)

                reg = dt.NewRow()
                reg("Solicitud") = solicitud
                reg("Descripcion") = descripcionSolicitud
                reg("Capital") = capital
                reg("Intereses") = totalInteres
                reg("Seguro") = totalSeguro
                reg("Total") = Math.Round(deudaTotal, 2, MidpointRounding.ToEven)
                dt.Rows.Add(reg)
            Catch ex As Exception

            End Try
        Next

        Me.DgvDetalleSolicitudes.DataSource = dt
    End Sub
    Private Function getDescripcionCapital(ByVal solicitud As String, ByVal bandera As Integer)
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
            Sql &= "INNER JOIN COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd "
            Sql &= "ON sd.NUMERO_SOLICITUD=s.CORRELATIVO "
            Sql &= "WHERE s.COMPAÑIA= " & compañia & " AND s.CODIGO_AS='" & Me.TxtCodigoAs.Text & "' AND s.CODIGO_BUXIS=" & Me.TxtCodigoBuxis.Text
            Sql &= "AND s.CORRELATIVO=" & solicitud
            Sql &= " AND sd.CAPITAL_D=0 group by s.CORRELATIVO, s.DESCRIPCION_SOLICITUD"

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            Conexion_Track.Close()
            If bandera = 1 Then
                Return Table.Rows(0).Item(1)
            Else
                Return Table.Rows(0).Item(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Nothing
    End Function

    Private Function getSeguro(ByVal solicitud As String)
        Try
            Dim Conexion As New DLLConnection.Connection
            Dim Conexion_Track As New SqlConnection
            Dim Comando_Track As New SqlCommand
            Dim DataAdapter_ As New SqlDataAdapter
            Dim Table As DataTable
            Dim Sql As String

            Sql = ""
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            Conexion_Track.Open()

            Sql = "SELECT ISNULL(SUM(sd.SEG_DEUDA),0) AS DEUDA FROM VISTA_COOPERATIVA_PROGRAMACION_SOLICITUDES s inner join COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd on sd.NUMERO_SOLICITUD=s.CORRELATIVO"
            Sql = Sql & " WHERE s.COMPAÑIA='" & compañia & "' AND s.CODIGO_AS='" & Trim((TxtCodigoAs.Text)) & "' AND s.CODIGO_BUXIS='" & Trim(Val(TxtCodigoBuxis.Text)) & "' AND s.CORRELATIVO NOT IN(SELECT NUMERO_SOLICITUD FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS) AND sd.SEG_DEUDA_D = 0"
            Sql = Sql & " AND s.CORRELATIVO = '" & solicitud & "'"
            'Sql = Sql & " group by s.CORRELATIVO, s.DESCRIPCION_SOLICITUD"

            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)

            Conexion_Track.Close()

            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return 0
    End Function

    Private Sub DgvDetalleSolicitudes_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetalleSolicitudes.CellContentClick
        If DgvDetalleSolicitudes.RowCount > 0 Then
            Deducciones(Me.DgvDetalleSolicitudes.CurrentRow.Cells(0).Value)
            cargaDetalles()
        End If
    End Sub
    Private Sub cargaDetalles()
        CargaDetalleProgramaciones()
        For i As Integer = 0 To Me.DgvDetalleProgra.Rows.Count - 1
            If Me.DgvDetalleProgra.Rows.Item(i).Cells("Reprogramada").Value = "SI" Then
                Me.DgvDetalleProgra.Rows.Item(i).DefaultCellStyle.ForeColor = Color.Red
                Me.DgvDetalleProgra.Rows.Item(i).DefaultCellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub CargaDetalleProgramaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & Me.DgvDetalleSolicitudes.CurrentRow.Cells(0).Value & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            Me.DgvDetalleProgra.Columns.Clear()
            DataAdapter_.Fill(Table)
            Me.DgvDetalleProgra.DataSource = Table
            'LimpiaGridDetalle()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub cargaDetalleProgramacionesSolicitud(ByVal solicitud As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," & solicitud & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 2
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            Me.DgvDetalleProgra.Columns.Clear()
            DataAdapter_.Fill(Table)
            Me.DgvDetalleProgra.DataSource = Table
            'LimpiaGridDetalle()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub getDetalleSolicitudes0()
        Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        'Dim totalInteres As String
        'Dim totalSeguro As String
        'Dim totalCapital As String
        'Dim capital As String
        'Dim descripcionSolicitud As String
        'Dim deudaTotal As Double
        'Dim columna As DataColumn
        'Dim reg As DataRow
        'Dim i As Integer = 0
        Dim sqlCmd As New SqlCommand
        Dim Sql As String
        Dim dt As DataTable = New DataTable("Datos")

        'columna = New DataColumn
        'columna.DataType = System.Type.GetType("System.Int32")
        'columna.ColumnName = "Solicitud"
        'columna.Caption = "No.Solicitud"
        'dt.Columns.Add(columna)

        'columna = New DataColumn
        'columna.DataType = System.Type.GetType("System.String")
        'columna.ColumnName = "Descripcion"
        'columna.Caption = "Solicitud"
        'dt.Columns.Add(columna)

        'columna = New DataColumn
        'columna.DataType = System.Type.GetType("System.Double")
        'columna.ColumnName = "Capital"
        'columna.Caption = "Capital"
        'dt.Columns.Add(columna)


        'For Each solicitud As String In solicitudes
        '    totalInteres = getInteresesFecha(solicitud, 1)
        '    totalSeguro = getInteresesFecha(solicitud, 2)
        '    descripcionSolicitud = getDescripcionCapital(solicitud, 1)
        '    capital = getDescripcionCapital(solicitud, 0)
        '    deudaTotal = CDbl(capital) + CDbl(totalInteres) + CDbl(totalSeguro)
        '    reg = dt.NewRow()
        '    reg("Solicitud") = solicitud
        '    reg("Descripcion") = descripcionSolicitud
        '    reg("Capital") = capital
        '    dt.Rows.Add(reg)
        'Next
        Sql = "SELECT s.CORRELATIVO[Nº Solicitud],s.DESCRIPCION_SOLICITUD[Solicitud],SUM(sd.CAPITAL) AS DEUDA "
        Sql &= "FROM VISTA_COOPERATIVA_PROGRAMACION_SOLICITUDES s "
        Sql &= "INNER JOIN COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE sd "
        Sql &= "ON sd.NUMERO_SOLICITUD=s.CORRELATIVO "
        Sql &= "WHERE s.COMPAÑIA= " & compañia & " AND s.CODIGO_AS='" & Me.TxtCodigoAs.Text & "' AND s.CODIGO_BUXIS=" & Me.TxtCodigoBuxis.Text
        Sql &= "AND s.CORRELATIVO IN (" & Me.TxtNumSolicitud.Text & ")"
        Sql &= " AND sd.CAPITAL_D=0 group by s.CORRELATIVO, s.DESCRIPCION_SOLICITUD"
        sqlCmd.CommandText = Sql
        dt = Func.obtenerDatos(sqlCmd)
        Me.DgvDetalleSolicitudes.DataSource = dt
    End Sub
    '---------------------------------------------------------
    '--------------------- REPROGRAMACION --------------------
    '---------------------------------------------------------
    Private Function Programacion(ByVal a_BD As Boolean) As Integer
        Dim Saldo As Double = CDbl(Me.txtNuevoSaldo.Text)
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
        Dim Saldo As Double = CDbl(Me.txtNuevoSaldo.Text)
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
            Sql = "Exec Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 3 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & compañia & "," & Trim(Val(Me.txtSolicitud.Text)) & "," & NudNumeroCuot.Value
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
    Private Sub NuevaCuota(ByVal solicitud As String)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_TOTAL_CUOTAPROXI " & 4 & ",'" & Format(Now, "Short Date") & "','" & Format(Now, "Short Date") & "'," & compañia & "," & Trim(solicitud) & "," & NudNumeroCuot.Value
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

    Private Sub MantenimientoProgramacion(ByVal Linea, ByVal FechaP, ByVal SaldoIni, ByVal Capital, ByVal Interes, ByVal SegDeuda, ByVal Cuota, ByVal SaldoFin, ByVal InteresAcum, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_SID ", Conexion_Track)
        Dim ds As New DataSet
        'MessageBox.Show(txtNoSolicitud.Text)
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = Trim(Val(Me.txtSolicitud.Text))
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
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(Me.txtSolicitud.Text))
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
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINIDES", SqlDbType.DateTime).Value = Me.DtpFechaPrimerPag.Value
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = Trim(Val(Me.txtSolicitud.Text))
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
    Private Function getLineaMax()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "select MAX(linea) as ultima from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.txtSolicitud.Text & " AND COMPAÑIA=" & Compañia
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
            Sql = "select ISNULL(MAX(linea),0) as ultima from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD = " & Me.txtSolicitud.Text
            Sql &= " And Compañia = " & Compañia & " and CAPITAL_D=1 and INTERES_D=1 and SEG_DEUDA_D=1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Conexion_Track.Close()

            Return Table.Rows(0).Item(0)
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
            Sql = "select MIN(linea) as primera from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD = " & Me.txtSolicitud.Text
            Sql &= " And Compañia = " & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
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
            Sql = "select count(*) as total from COOPERATIVA_PROGRAMACION_ILUSTRATIVA where N_SOLICITUD=" & Me.txtSolicitud.Text & " AND COMPAÑIA=" & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            Conexion_Track.Close()
            Return Table.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return 0
    End Function
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
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD "
            Sql &= Compañia & ","
            Sql &= solicitud & ","
            Sql &= "'" & Usuario & "','E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Retorno = Comando_Track.ExecuteScalar()
            Comando_Track.CommandText = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET COMENTARIO_ANULADA = 'CANCELADO CON ABONO (" & Me.txtNoRemesa.Text & ")' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Retorno
    End Function

    Private Sub CalcularReprogramacion()
        Dim numCuotas As Integer = 0
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
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
    End Sub
    '----------------------------------
    'Cuotas especiales
    Private Sub MantenimientoCuotasEspeciales(ByVal Bandera)
        Dim Monto As Double = CDbl(Val(TxtCuotaEspecial.Text))
        Dim TasaInteres As Double = CDbl(Trim(LblInteres.Text) / 100)
        Dim TasaSeguro As Double = CDbl(Trim(LblSegDeuda.Text) / 100)
        Dim InteresPrimero As Double = 0
        Dim SegDeudaPrimero As Double = 0
        Dim Cuota As Double = 0
        Dim DiasPP As Integer
        Dim Sql As String
        DiasPP = getDiffDias(Me.DtpFechaPago.Value.ToString("dd/MM/yyyy"), Me.DtpFechaIniPres.Value.ToString("dd/MM/yyyy"))  'DiasInteresCuotasEspeciales()
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
            & Val(Me.txtSolicitud.Text) & "," & 0 & "," & 0 & "," & 0 & ",'" & Format(DtpFechaPago.Value, "dd-MM-yyyy HH:mm:ss") & "'," & 0 & "," _
            & Val(TxtCuotaEspecial.Text) & "," & 0 & "," & InteresPrimero & "," & 0 & "," & SegDeudaPrimero & "," & 0 & "," & Cuota & "," & 0 & "," & 0 & "," & 0 & ",'" & Usuario & "'," & Bandera
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
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & Compañia & "," _
            & CInt(Me.txtSolicitud.Text) & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & Bandera
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
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLUCITUDES_DETALLE_ESPECIALES_IUD @COMPAÑIA = " & Compañia & ", @NUM_SOLICITUD = " _
            & CInt(Me.txtSolicitud.Text) & ", @USUARIO= '" & Usuario & "', @BANDERA = " & Bandera
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
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
            Sql = "Exec Coo.sp_COOPERATIVA_SOLICITUDES_TOTAL_CUOTAS_ESPECIALES " & Compañia & "," & Me.txtSolicitud.Text & "," & 1
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_CUOTAS_ESPECIALES " & Compañia & "," & Trim(Val(Me.txtSolicitud.Text)) & "," & Linea & "," & Bandera
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
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
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

        If Cuota > CDbl(Val(Me.txtNuevoSaldo.Text)) Then
            MessageBox.Show("Monto de la cuota especial Sobre pasa al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCuotaEspecial.Focus()
            Return
        End If
        'BONIFICACION
        If Me.CbxPeriodoEspeciales.SelectedValue = "BO" Then
            If Fecha.Month.ToString = "6" And Fecha.Day.ToString = "12" Then

                MantenimientoCuotasEspeciales(2)
                MuestraProgramacionesCuotasEspeciales(0, 1)
                Resta = CDbl(Val(Me.txtNuevoSaldo.Text)) - Cuota
                Me.txtNuevoSaldo.Text = Format(Resta, "0.00")
                If CDbl(Me.txtNuevoSaldo.Text) = 0 Then
                    Me.BtnGuardar.Enabled = False
                    'Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnGuardar.Enabled = True
                    'Me.BtnCalcular.Enabled = True
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
                Resta = CDbl(Val(Me.txtNuevoSaldo.Text)) - Cuota
                Me.txtNuevoSaldo.Text = Format(Resta, "0.00")
                If CDbl(Val(Me.txtNuevoSaldo.Text)) = 0 Then
                    Me.BtnGuardar.Enabled = False
                    'Me.BtnCalcular.Enabled = False
                Else
                    Me.BtnGuardar.Enabled = True
                    'Me.BtnCalcular.Enabled = True
                End If
                Total_CuotaEspecial()
            Else
                MessageBox.Show("La fecha válida para programar cuotas de Aguinaldo es :12 de Diciembre xxxx ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If Resta = 0 Then
            Me.btnAbonar.Enabled = True
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
            Suma = CDbl(Val(Me.txtNuevoSaldo.Text)) + Valor
            Me.txtNuevoSaldo.Text = Suma

            MuestraProgramacionesCuotasEspeciales(0, 1)
            If CDbl(Val(Me.txtNuevoSaldo.Text)) = 0 Then
                Me.BtnGuardar.Enabled = False
                'Me.BtnCalcular.Enabled = False
            Else
                Me.BtnGuardar.Enabled = True
                'Me.BtnCalcular.Enabled = True
            End If
            Total_CuotaEspecial()
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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

    Private Sub btnPreCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreCalculo.Click
        Dim opcEspecial As Integer

        If String.IsNullOrEmpty(Me.txtAbono.Text.Trim) Then
            MessageBox.Show("No se ha ingresado el monto a abonar", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtAbono.Focus()
            Return
        End If
        If Not esNumero(Me.txtAbono.Text.Trim) Then
            MessageBox.Show("El monto debe ser un numero", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtAbono.Text = ""
            Me.txtAbono.Focus()
            Return
        End If
        If CDbl(Me.txtAbono.Text) > (CDbl(Me.TxtMonto.Text) + CDbl(Me.txtInteres.Text) + CDbl(Me.txtSeguro.Text)) Then
            MessageBox.Show("La cantidada abonar no puede ser mayor que el total adeudado", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtAbono.Focus()
            Return
        End If
        If Val(Me.txtAbono.Text) < (Val(Me.txtInteres.Text) + Val(Me.txtSeguro.Text)) Then 'getMinimoRequerido() Then
            MessageBox.Show("LA CANTIDAD A ABONAR DEBE CUBRIR AL MENOS EL " & vbCrLf & "INTERÉS Y EL SEGURO DE DEUDA CALCULADO." & vbLf & "MONTO MÍNIMO: " & getMinimoRequerido(), "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtAbono.Focus()
            Return
        End If
        'If Me.rbrnRemesa.Checked = True And Me.cmbBancos.SelectedIndex = 0 Then
        '    MessageBox.Show("No se ha seleccionada el banco donde se realizó la remesa", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If
        'If Me.rbrnRemesa.Checked = True Then
        '    If Not esNumero(Me.txtNoRemesa.Text.Trim) Then
        '        MessageBox.Show("El campo # Remesa debe contener un valor numérico", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Me.txtNoRemesa.Text = ""
        '        Me.txtNoRemesa.Focus()
        '        Return
        '    End If
        'End If
        'If Me.rbrnRemesa.Checked = True And (Me.txtNoRemesa.Text.Length = 0 Or String.IsNullOrEmpty(Me.txtNoRemesa.Text.Trim)) Then
        '    MessageBox.Show("No se ha ingresado el número de remesa", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If
        ''''''''''''
        If Me.rbtnAhorroExtraordinario.Checked = True And (CDbl(Me.TxtTotalAhorro_ExtraOrdinario.Text) < CDbl(Me.txtAbono.Text)) Then
            MessageBox.Show("La cantidad que desea abonar sobrepasa el saldo del ahorro extraordinario." & ControlChars.NewLine & "   Monto disponible $ " & Me.TxtTotalAhorro_ExtraOrdinario.Text, "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        '''' Opcion de saltar limite de retiro de ahorro extra?
        If Me.rbtnAhorroExtraordinario.Checked = True And CInt(Me.TxtDiasFaltantes.Text) <> 0 Then
            opcEspecial = MessageBox.Show("Faltan " & Me.TxtDiasFaltantes.Text & " días para retirar fondos del ahorro extraordinario. ¿Desea realizar el retiro de todas formas?", "VALIDACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If opcEspecial <> 6 Then
                Return
            End If
        End If
        'Deducciones(Me.txtSolicitud.Text)
        'setTasasInteres()
        Me.realizaAbono(0)
        Me.BtnNuevo.Enabled = True
        Me.btnPreCalculo.Enabled = False
        bloquearControlesAbono()
    End Sub
    Private Sub bloquearControlesAbono()
        Me.txtAbono.Enabled = False
        Me.cmbBancos.Enabled = False
        Me.txtNoRemesa.Enabled = False
        Me.rbrnRemesa.Enabled = False
        Me.rbtnAhorroExtraordinario.Enabled = False
        Me.btnPreCalculo.Enabled = False
    End Sub
    Private Sub desbloqueaControlesAbono()
        Me.txtAbono.Enabled = True
        If Me.rbrnRemesa.Checked = True Then
            Me.cmbBancos.Enabled = True
            Me.txtNoRemesa.Enabled = True
        End If
        Me.rbrnRemesa.Enabled = True
        Me.rbtnAhorroExtraordinario.Enabled = True
    End Sub
    Private Sub btnAbonar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbonar.Click
        If Me.rbtnAhorroExtraordinario.Checked = True Then
            ' Retiro de fondos de ahorro
            RetiroAhorroExtraSocio()
            retirarDelExtra()
        End If
        Me.realizaAbono(1)
        If Val(Me.txtNuevoSaldo.Text) > 0 Then
            setInteresAcumulado()
        End If
        'Deducciones(Me.txtSolicitud.Text)
        'setTasasInteres()
        '------------------------------------------
        ' Bloque todos los botones
        Me.btnPreCalculo.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnCalcular.Enabled = False
        Me.btnAbonar.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnEliminar.Enabled = False
        Me.DtpFechaIniPres.Enabled = False
        Me.DtpFechaPago.Enabled = False
        Me.CbxPeriodo.Enabled = False
        Me.RadioButton1.Enabled = False
        Me.RadioButton2.Enabled = False
        Me.TxtCuota.Enabled = False
        Me.NudNumeroCuot.Enabled = False 'Luego los del precalculo
        bloquearControlesAbono()
        Me.Close()
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

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        If (Not (Me.RadioButton1.Checked Or Me.RadioButton2.Checked)) Then
            MessageBox.Show("Se debe seleccionar el tipo de programación (cuota o numero de cuotas) a realizar.", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDbl(Val(Me.txtNuevoSaldo.Text)) = 0 Then
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
        If CDbl(Me.TxtCuota.Text) > CDbl(Me.txtNuevoSaldo.Text) Then
            MessageBox.Show("La cuota es mayor que el monto", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If CDate(Me.DtpFechaIniPres.Value.ToShortDateString) > CDate(DtpFechaPrimerPag.Value.ToShortDateString) Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
            Return
        End If
        CalcularReprogramacion()

        Me.BtnCalcular.Enabled = False
        limpiarGridReprograma()
        me.btnAbonar.Enabled=True
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

    Private Sub setInteresAcumulado()
        Dim i As Integer
        Dim lineaMax As Integer
        Dim interesAcumulado As Double

        lineaMax = Func.obtenerEscalar("select MAX(linea) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & Me.txtSolicitud.Text & " and COMPAÑIA=" & compañia)
        For i = 1 To lineaMax
            interesAcumulado = Func.obtenerEscalar("select isnull(sum(interes),0) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & Me.txtSolicitud.Text & " and COMPAÑIA=" & compañia & " and LINEA<=" & i)
            Func.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES_ACUM=" & interesAcumulado & " where NUMERO_SOLICITUD=" & Me.txtSolicitud.Text & " and COMPAÑIA=" & compañia & " and LINEA=" & i)
        Next
    End Sub
    Private Sub limpiarGridReprograma()
        Me.DgvProgramacion.Columns(0).Visible = False
        Me.DgvProgramacion.Columns(1).Visible = False
        Me.DgvProgramacion.Columns(3).Visible = False
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        'Deducciones(Me.txtSolicitud.Text)
        'setTasasInteres()
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        Me.limpiarGridReprograma()
        Me.txtCanNoCuotaEspecial.Text = 1
        'Me.txtCanCuotaEspecial.Text = Me.txtMontoInteSeg.Text
        GuardarCuotasEspeciales(9)
        MuestraProgramacionesCuotasEspeciales(0, 1)
        'Me.TxtCuota.Enabled = True
        'Me.BtnGuardar.Enabled = False
        'Me.NudNumeroCuot.Enabled = True
        If CDbl(Me.txtNuevoSaldo.Text) = 0 Then
            Me.BtnCalcular.Enabled = True
        End If
        Me.TxtCuota.Text = 0
        'Deducciones(Me.txtSolicitud.Text)
        'setTasasInteres()
        NoBlockBotones()
        Me.BtnCalcular.Enabled = True
        Me.BtnGuardar.Enabled = True
        Me.BtnEliminar.Enabled = True
        Me.btnAbonar.Enabled = False
        If CDbl(Me.txtNuevoSaldo.Text) < 0.01 Then
            Me.BtnCalcular.Enabled = False
            Me.btnAbonar.Enabled = True
        End If

    End Sub
    Private Sub LblInteres_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblInteres.TextChanged
        Me.lblInteresReprogramacion.Text = Me.LblInteres.Text
    End Sub

    Private Sub LblSegDeuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSegDeuda.TextChanged
        Me.lblSeguroReprogramacion.Text = Me.LblSegDeuda.Text
    End Sub

    Private Sub TabPage2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        Deducciones(Me.txtSolicitud.Text)
        setTasasInteres()
    End Sub

    Private Sub rbrnRemesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbrnRemesa.CheckedChanged
        If Me.rbrnRemesa.Checked = True Then
            Me.cmbBancos.Enabled = True
            Me.txtNoRemesa.Enabled = True
            comentario()
        Else
            Me.cmbBancos.Enabled = False
            Me.txtNoRemesa.Enabled = False
        End If
    End Sub

    Private Sub comentario()
        If Not Iniciando Then
            If Me.rbrnRemesa.Checked Then
                Me.txtComentario.Text = "ABONO REMESA #" & Me.txtNoRemesa.Text
            Else
                Me.txtComentario.Text = "ABONO CON AHORRO EXTRAORDINARIO"
            End If
            If Me.cmbBancos.SelectedValue > 0 And Me.rbrnRemesa.Checked Then
                Me.txtComentario.Text &= " DEL " & Me.cmbBancos.Text.ToUpper()
            End If
            Me.txtComentario.Text &= " DE FECHA " & Me.dtpFechaAbono.Value.ToShortDateString()
        End If
    End Sub
    Private Sub btnNuevoPreCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPreCalculo.Click
        'Dim solicitudes As Array = Split(Me.TxtNumSolicitud.Text, ",")
        'Deducciones(solicitudes(0))
        'setTasasInteres()
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
        limpiarGridReprograma()
        Me.txtCanNoCuotaEspecial.Text = 1
        'Me.txtCanCuotaEspecial.Text = Me.txtMontoInteSeg.Text
        GuardarCuotasEspeciales(9)
        'Me.TxtCuota.Enabled = True
        'Me.BtnGuardar.Enabled = False
        'Me.NudNumeroCuot.Enabled = True
        Me.BtnCalcular.Enabled = True
        Me.TxtCuota.Text = 0
        'Deducciones(Me.txtSolicitud.Text)
        'setTasasInteres()
        BlockBotones()
        Me.BtnNuevo.Enabled = False
        Me.btnPreCalculo.Enabled = True
        desbloqueaControlesAbono()
    End Sub
    Private Sub MantenimientoProgramacionEncabezado()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & compañia & "," _
            & CInt(Me.txtSolicitud.Text) & "," & CbxDeduccion.SelectedValue & "," & NudNumeroCuot.Value & "," & Trim(Me.TxtCuota.Text) & "," & _
            Me.txtNuevoSaldo.Text & ",'" & CbxPeriodo.SelectedValue & "','" & Format(DtpFechaIniPres.Value, "dd-MM-yyyy HH:mm:ss") & "','" & Format(DtpFechaPrimerPag.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & LblInteres.Text & "," & LblSegDeuda.Text & ",'" & Usuario & "'," & 1
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
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_IU " & compañia & "," _
            & CInt(Me.txtSolicitud.Text) & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub rbtnAhorroExtraordinario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAhorroExtraordinario.CheckedChanged
        If Me.rbtnAhorroExtraordinario.Checked = True Then
            UltimoRetiroAhorros()
            DisponibleSocio()
            comentario()
        End If
    End Sub
    '------------------------------------------------------------------------------
    '-------------------------------- Retiro de ahorro de socio
    Private Sub RetiroAhorroExtraSocio() 'almacenamiento de retiro de ahorro en tabla cooperativa_socio_retiros
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_COOPERATIVA_SOCIO_RETIROS" & vbCrLf
            Sql &= " @RETIRO = 0," & vbCrLf
            Sql &= " @COMPAÑIA = " & compañia & "," & vbCrLf
            Sql &= " @BANCO = " & Me.TxtBanco_cod.Text & "," & vbCrLf
            Sql &= " @TIPO_DOCUMENTO = 0," & vbCrLf
            Sql &= " @CUENTA = '" & Me.TxtBanco_cuenta.Text & "'," & vbCrLf
            Sql &= " @CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & "," & vbCrLf
            Sql &= " @CODIGO_EMPLEADO_AS = '" & Me.TxtCodigoAs.Text & "'," & vbCrLf
            Sql &= " @CANTIDAD = " & Me.txtAbono.Text & "," & vbCrLf
            Sql &= " @ESTADO = 3," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @FECHA = '" & Format(Me.DtpFechaIniPres.Value, "dd/MM/yyyy") & "'," & vbCrLf
            Sql &= " @SIUD = 'I'," & vbCrLf
            Sql &= " @COMENTARIO = 'ABONO A DEUDAS DE SOLICITUD" & IIf(Me.TxtNumSolicitud.Text.Contains(","), "ES ", " ") & Me.TxtNumSolicitud.Text & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub retirarDelExtra()
        Dim query As String
        Dim saldOridinario As Double
        Dim saldoExtra As Double
        Dim Ahorro As Integer ' Linea del ahorro


        Ahorro = Func.obtenerEscalar("SELECT ISNULL(MAX(AHORRO), 0) FROM COOPERATIVA_SOCIO_AHORROS WHERE COMPAÑIA = " & compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text.Trim & " AND CODIGO_EMPLEADO_AS = " & Me.TxtCodigoAs.Text.Trim)
        saldOridinario = Func.obtenerEscalar("select SALDO_ORDINARIO from COOPERATIVA_SOCIO_AHORROS WHERE COMPAÑIA = " & compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text.Trim & " AND CODIGO_EMPLEADO_AS = " & Me.TxtCodigoAs.Text.Trim & " AND AHORRO=" & Ahorro)
        saldoExtra = Func.obtenerEscalar("select SALDO_EXTRAORDINARIO from COOPERATIVA_SOCIO_AHORROS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text.Trim & " AND CODIGO_EMPLEADO_AS = " & Me.TxtCodigoAs.Text.Trim & " AND AHORRO=" & Ahorro)

        query = "exec sp_COOPERATIVA_SOCIO_AHORROS_IUD "
        query &= Compañia & ","
        query &= Me.TxtCodigoBuxis.Text & ","
        query &= "'" & Me.TxtCodigoAs.Text & "',"
        query &= "0,"
        query &= "'" & Format(getFechaActual(), "Short Date") & "',"
        query &= "0,"
        query &= "0,"
        query &= "-" & Me.txtAbono.Text.Trim & ","
        query &= saldOridinario & ","
        query &= (saldoExtra - CDbl(Me.txtAbono.Text)) & ","
        query &= "'" & Usuario & "', 'I'"

        Func.Ejecutar_ConsultaSQL(query)
    End Sub

    Private Sub txtAbono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbono.KeyPress
        Dim cadena As String = txtAbono.Text
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

    Private Sub frmAbonoEfectivo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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

    Private Sub TabPage6_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage6.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtNoRemesa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoRemesa.LostFocus
        comentario()
    End Sub

    Private Sub cmbBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
        comentario()
    End Sub

    Private Sub dtpFechaAbono_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAbono.ValueChanged
        comentario()
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

