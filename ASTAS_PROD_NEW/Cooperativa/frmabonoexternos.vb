Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class frmabonoexternos
    Dim Sql As String
    Dim Iniciando As Boolean = True
    Dim xabono As Double = 0.0
    Dim xsaldo As Double = 0.0
    Dim xnuevosaldo As Double = 0.0
    Dim xtasainteres As Double = 0.0
    Dim xinteres As Double = 0.0
    Dim xtasaseguro As Double = 0.0
    Dim xseguro As Double = 0.0
    Dim xperiodo As String = ""
    Dim xdeduccion As Integer = 0
    Dim xsolicitud As Integer = 0
    Dim xsolicitudes As String = ""
    Dim xcodigo As Integer = 0
    Dim xcodigoas As String
    Dim xSql As String
    Dim xsqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim jClass As New jarsClass
    Dim xcuota As Double = 0.0
    Dim xfechaabono As Date = Today()
    Dim xbanco As Integer = 0
    Dim xnuevasoli As Integer = 0
    Dim oExcelApp = CreateObject("EXCEL.Application")
    Dim TablaProgs As New DataTable
    Dim CnnStrBldr As New SqlConnectionStringBuilder
    Dim OrigenEmpl As Integer

    Private Sub limpiar_variables()

        xabono = 0.0
        xsaldo = 0.0
        xnuevosaldo = 0.0
        xtasainteres = 0.0
        xinteres = 0.0
        xtasaseguro = 0.0
        xseguro = 0.0
        xperiodo = ""
        xdeduccion = 0
        xsolicitud = 0
        xsolicitudes = ""
        xcodigo = 0
        xcodigoas = ""
        xcuota = 0.0
        xnuevasoli = 0
    End Sub
    Private Sub frmabonoexternos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CnnStrBldr.UserID = UsuarioDB
        CnnStrBldr.Password = PasswordDB
        CnnStrBldr.DataSource = Servidor
        CnnStrBldr.InitialCatalog = BaseDatos
        Me.DtpFechaAbono.Value = Now
        Me.lblLIBRO_CONTABLE.Text = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE LIBRO_PRINCIPAL = 1 AND COMPAÑIA = " & Compañia).ToString()
        jClass.CargaBancos2(Compañia, Me.cmbBANCO)
        Me.cmbBANCO.SelectedIndex = 1
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 5, Me.cmbCUENTA_BANCARIA)
        CargaCuentaContable()
        SetearFechas()
        Iniciando = False
    End Sub
    Private Sub btnabonar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabonar.Click
        If Not jClass.ValidaCierreContable(Compañia, Me.lblLIBRO_CONTABLE.Text, Me.DtpFechaAbono.Value.Year, Me.DtpFechaAbono.Value.Month, "E") Then
            Return
        End If
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim sumaMontos As Double = 0.0
        Dim TotalAbonos As Double = 0.0
        Dim TotCuotas As Integer = 0
        'Variables para la partida contable
        Dim numPartida As Integer = Val(Me.txtPartida.Text)
        Dim NumTran As Integer
        Dim Transaccion As String = String.Empty
        Try
            If numPartida > 0 Then
                NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & numPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.DtpFechaAbono.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.DtpFechaAbono.Value.Year & " AND COMPAÑIA = " & Compañia)
                If NumTran = 0 Then
                    MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                    Return
                Else
                    Transaccion = NumTran
                    If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                        MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                        Return
                    End If
                    If jClass.obtenerEscalar("SELECT COUNT(TRANSACCION) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
                        If MsgBox("Al procesar eliminará los registros existentes de la Partida #" & Me.txtPartida.Text & vbCrLf & "¿Está seguro(a) que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.No Then
                            MsgBox("Proceso cancelado por usuario.", MsgBoxStyle.Information, "Mensaje")
                            Return
                        Else
                            jClass.ejecutarComandoSql(New SqlCommand("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion))
                        End If
                    End If
                End If
            Else
                If MsgBox("No ha ingresado un número de partida." & vbCrLf & vbCrLf & "¿Desea Crear la partida automaticamente?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                    Return
                Else
                    '***************************************************************
                    Transaccion = jClass.GeneraCorrelativo(Compañia, "TRA", Me.DtpFechaAbono.Value.Year, Me.DtpFechaAbono.Value.Month).ToString
                    Me.txtPartida.Text = jClass.GeneraCorrelativo(Compañia, "PAR", Me.DtpFechaAbono.Value.Year, Me.DtpFechaAbono.Value.Month).ToString
                    If Mantenimiento_TransaccionE(Compañia, Transaccion, Val(lblLIBRO_CONTABLE.Text), 7, 0, 1, Me.txtPartida.Text, Me.DtpFechaAbono.Value, Trim(Me.txtConcepto.Text), "0", "0", "I") = 0 Then
                        MsgBox("Error al Generar Partida", MsgBoxStyle.Critical, "Partida Contable")
                        Return
                    End If
                    '***************************************************************
                End If
            End If

            If Me.dgvAbonos.RowCount > 0 Then
                'Recorre cada Fila del DataGriViewer
                For i = 0 To Me.dgvAbonos.Rows.Count - 1
                    limpiar_variables()
                    sumaMontos = 0.0
                    Numero_Orden(0)
                    j = 0
                    xcodigo = Me.dgvAbonos.Rows(i).Cells(0).Value
                    xSql = "select CODIGO_EMPLEADO_AS from cooperativa_catalogo_socios where CODIGO_EMPLEADO=" & xcodigo & " AND COMPAÑIA = " & Compañia
                    xcodigoas = jClass.obtenerEscalar(xSql)
                    xSql = "select ORIGEN from cooperativa_catalogo_socios where CODIGO_EMPLEADO=" & xcodigo & " AND COMPAÑIA = " & Compañia
                    OrigenEmpl = jClass.obtenerEscalar(xSql)
                    xabono = (Me.dgvAbonos.Rows(i).Cells(2).Value)
                    TotalAbonos += xabono
                    xdeduccion = (Me.dgvAbonos.Rows(i).Cells(3).Value)
                    xperiodo = (Me.dgvAbonos.Rows(i).Cells(4).Value)
                    xSql = "select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES where Deduccion=" & xdeduccion & " AND COMPAÑIA = " & Compañia
                    xtasainteres = jClass.obtenerEscalar(xSql)
                    xSql = "select INTERES from COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO where Deduccion=" & xdeduccion & " AND COMPAÑIA = " & Compañia
                    xtasaseguro = jClass.obtenerEscalar(xSql)
                    xSql = "select sol.CORRELATIVO, det.CAPITAL from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE as det inner join COOPERATIVA_SOLICITUDES as sol  on det.NUMERO_SOLICITUD=sol.CORRELATIVO AND det.COMPAÑIA = sol.COMPAÑIA  where sol.CODIGO_BUXIS= " & xcodigo & " and sol.DEDUCCION= " & xdeduccion & "and det.CAPITAL_D=0"
                    xsqlCmd.CommandText = xSql
                    Table = jClass.obtenerDatos(xsqlCmd)
                    Sql = "SELECT P.CUENTA FROM COOPERATIVA_CATALOGO_SOLICITUDES C, CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS P" & vbCrLf
                    Sql &= " WHERE C.COMPAÑIA = P.COMPAÑIA AND C.TIPO_DOCUMENTO = P.TIPO_DOCUMENTO AND P.CENTRO_COSTO = " & IIf(xdeduccion = 236, "4", IIf(xdeduccion = 257, "5", "1")) & vbCrLf
                    Sql &= "   AND P.CARGO = 1 AND P.ORIGEN = " & OrigenEmpl & vbCrLf
                    Sql &= "   AND C.COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND C.DEDUCCION = " & xdeduccion & vbCrLf
                    NumTran = jClass.obtenerEscalar(Sql)
                    Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, xcodigo, NumTran, "Abono de Fecha " & Me.DtpFechaAbono.Value.ToShortDateString(), "A", xabono, "E")
                    'Recorrido del datatable que contiene todas las solicitudes con sus montos
                    For Each dr As DataRow In Table.Rows
                        If j = 0 Then
                            xsolicitudes &= dr(0).ToString
                        Else
                            xsolicitudes &= "," & dr(0).ToString
                        End If
                        sumaMontos += dr(1)
                        TotCuotas += 1
                        j += 1
                    Next
                    xsaldo = sumaMontos
                    If j > 1 Then
                        'NUEVO
                        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
                        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
                        'CALCULAR
                        Dim numCuotas As Integer = 0
                        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
                        Programacion(True)
                        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)

                        For Each row As DataRow In TablaProgs.Rows
                            MantenimientoProgramacion(row.Item(2), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10), row.Item(11), 1)
                        Next
                        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)

                        ' GUARDAR
                        Insertar_SolicitudesN()
                        ActualizarAutorizaciones(1) 'Se autoriza la solicitud
                        MantenimientoProgramacionEncabezado()
                        MantenimientoProgramacionDetalle()
                        anularSolicitudes()

                    Else
                        Dim solicitudes As Array
                        Dim solicitud As String
                        solicitudes = Split(xsolicitudes, ",")
                        For Each solicitud In solicitudes
                            xsolicitud = solicitud
                        Next
                        xnuevasoli = xsolicitud
                    End If

                    'ABONO
                    xsaldo = xsaldo - xabono
                    'Nuevo cálculo
                    MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
                    MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
                    'calculo
                    realizaAbono(0)
                    'nuevo 
                    MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
                    MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
                    'calcular

                    CalcularReprogramacion()
                    Me.realizaAbono(1)
                    If xnuevosaldo > 0 Then
                        setInteresAcumulado()

                        xSql = "select sol.CORRELATIVO, det.CAPITAL from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE as det inner join COOPERATIVA_SOLICITUDES as sol  on det.NUMERO_SOLICITUD=sol.CORRELATIVO and det.COMPAÑIA=sol.COMPAÑIA  where sol.CODIGO_BUXIS= " & xcodigo & " and sol.DEDUCCION= " & xdeduccion & "and det.CAPITAL_D=0 and det.numero_solicitud  <> " & xsolicitud
                        xsqlCmd.CommandText = xSql
                        Table = jClass.obtenerDatos(xsqlCmd)
                        'Recoorido del datatable que contiene todas las solicitudes con sus montos
                        For Each dr As DataRow In Table.Rows
                            xsolicitud = dr(0)
                            ' anularSolicitudes()
                        Next
                        'MessageBox.Show("Los días válidos a seleccionar son: 15," & IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, "29", "28") & ",30 ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                Next
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text), "C", TotalAbonos, "E")
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text), "C", TotalAbonos, "A")
                MessageBox.Show("Proceso Finalizado")
                If Transaccion > 0 Then
                    Dim frmVer As New frmReportes_Ver
                    frmVer.CargaPartida(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, Transaccion, Me.DtpFechaAbono.Value.Year, Me.DtpFechaAbono.Value.Month, 1)
                    frmVer.ShowDialog()
                End If
            Else
                MessageBox.Show("DEBE CARGAR DATOS A ABONAR")
                Me.btnabonar.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function anularSolicitudes()
        ' Anular solicitudes 
        'para anular las solicitudes utilizar el sp 
        'Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION()
        '@compañia @num_solicitud @motivo @usuario @bandera
        'para todo el proceso utilizar la bandera = 1
        Dim solicitudes As Array
        Dim solicitud, motivo As String
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As New SqlCommand
        Dim Sql As String

        Try
            'anula las programaciones consolidadas
            solicitudes = Split(xsolicitudes, ",")
            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            Conexion_Track.Open()
            Comando_Track.Connection = Conexion_Track
            For Each solicitud In solicitudes
                motivo = "CONSOLIDACIÓN DE SALDO A NUEVA PROGRAMACION No." & xnuevasoli
                '@compañia @num_solicitud @motivo @usuario @bandera
                Sql = "execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION " & Compañia & "," & solicitud & ",'" & motivo & ")','" & Usuario & "', 1"
                'Sql = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD " & vbCrLf
                'Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
                'Sql &= " @NUM_SOLICITUD = " & solicitud & "," & vbCrLf
                'Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
                'Sql &= " @IUD = 'E'"
                Comando_Track.CommandText = Sql
                'Comando_Track.Connection = Conexion_Track
                Comando_Track.ExecuteNonQuery()
                'DataAdapter_ = New SqlDataAdapter(Comando_Track)
                'Table = New DataTable("Datos")
                'DataAdapter_.Fill(Table)
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET FECHA_ANULADA = '" & Format(Me.DtpFechaAbono.Value, "dd/MM/yyyy") & "' "
                Sql &= "WHERE N_SOLICITUD = " & solicitud & " AND COMPAÑIA = " & Compañia
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                Comando_Track.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "ERROR")
        Finally
            Conexion_Track.Close()
        End Try
        Return 0
    End Function


    Private Sub MantenimientoProgramacionEncabezado()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim Sql As String
        xcuota = xsaldo
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & Compañia & "," _
            & xnuevasoli & "," & xdeduccion & "," & "1" & "," & xcuota & "," & _
            0 & ",'" & xperiodo & "','" & Format(DtpFechaAbono.Value, "dd-MM-yyyy HH:mm:ss") & "','" & Format(DtpFechaPrimerPag.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & xtasainteres & "," & xtasaseguro & ",'" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROGRAMADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & xnuevasoli
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
            & xnuevasoli & "," & 0 & ",'" & Format(Now, "Short Date") & "','" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ActualizarAutorizaciones(ByVal Autorizacion)
        Dim Comentario As String = ""
        Dim Sql As String = "SELECT C.DESCRIPCION_SOLICITUD FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES C WHERE S.COMPAÑIA = C.COMPAÑIA AND S.SOLICITUD = C.SOLICITUD AND S.COMPAÑIA = " & Compañia & " AND S.CORRELATIVO = "
        Dim SqlSaldo As String = "SELECT ISNULL(SUM(CAPITAL),0.00) FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE CAPITAL_D =0 AND COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = "
        Dim SqlFact As String = "SELECT NUMERO_FACTURA FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = "
        Dim solicitudes As String() = Split(xsolicitudes, ",")
        Dim solicitud As String
        Dim SaldoPend As Double
        Dim comentario1 As String
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Comentario = "CONSOLIDACIÓN DE SALDOS " & xsolicitudes
        For Each solicitud In solicitudes
            comentario1 = jClass.obtenerEscalar(Sql & solicitud).ToString()
            SaldoPend = Format(jClass.obtenerEscalar(SqlSaldo & solicitud), "$0.00")
            Comentario = Comentario.Replace(solicitud, vbCrLf & "-SOLICITUD #" & solicitud & " DE " & comentario1 & " ($" & Format(SaldoPend, "0.00") & ")")
        Next

        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = xnuevasoli
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = Comentario
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Me.DtpFechaAbono.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = "NUEVA SOLICITUD No." & xnuevasoli
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = Me.DtpFechaAbono.Value
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = 1
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = Me.DtpFechaAbono.Value
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = Me.DtpFechaAbono.Value
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = Me.DtpFechaAbono.Value
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = " "
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = xcodigoas
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_BUXIS", SqlDbType.Int).Value = xcodigo
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
            & getNumSolicitud() & "," & xdeduccion & "," & xnuevasoli & ",'" & xcodigoas & "'," _
            & xcodigo & ",0,'" & Format(Me.DtpFechaAbono.Value, "dd/MM/yyyy") & "'," _
            & "0," & xsaldo & "," & xtasainteres & ",'" & xperiodo & "'," & "1" & ",'" & Usuario & "'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
                xnuevasoli = DataReader_Track.Item(0)
            End If
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
            Sql &= "WHERE DEDUCCION = " & xdeduccion & " AND COMPAÑIA= " & Compañia
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


    Private Sub setInteresAcumulado()
        Dim i As Integer
        Dim lineaMax As Integer
        Dim interesAcumulado As Double

        lineaMax = jClass.obtenerEscalar("select MAX(linea) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & xsolicitud & " and COMPAÑIA=" & Compañia)
        For i = 1 To lineaMax
            interesAcumulado = jClass.obtenerEscalar("select isnull(sum(interes),0) from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE where NUMERO_SOLICITUD=" & xsolicitud & " and COMPAÑIA=" & Compañia & " and LINEA<=" & i)
            jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET INTERES_ACUM=" & interesAcumulado & " where NUMERO_SOLICITUD=" & xsolicitud & " and COMPAÑIA=" & Compañia & " and LINEA=" & i)
        Next
    End Sub
    Private Sub CalcularReprogramacion()
        Dim numCuotas As Integer = 0
        MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 3)
        If DtpFechaPrimerPag.Value.Day = 15 Or DtpFechaPrimerPag.Value.Day = 30 Or DtpFechaPrimerPag.Value.Day = IIf((Me.DtpFechaPrimerPag.Value.Year Mod 4) = 0, 29, 28) Then

            Programacion(True)
            MantenimientoProgramacion(0, DtpFechaPrimerPag.Value, 0, 0, 0, 0, 0, 0, 0, 2)
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

    Private Sub MantenimientoProgramacion(ByVal Linea, ByVal FechaP, ByVal SaldoIni, ByVal Capital, ByVal Interes, ByVal SegDeuda, ByVal Cuota, ByVal SaldoFin, ByVal InteresAcum, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_SID ", Conexion_Track)
        Dim ds As New DataSet
        'MessageBox.Show(txtNoSolicitud.Text)
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = xnuevasoli
            DataAdapter.SelectCommand.Parameters.Add("@LINEA", SqlDbType.Int).Value = Linea
            DataAdapter.SelectCommand.Parameters.Add("@DEDUCCION", SqlDbType.Int).Value = xdeduccion
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
    '---------------------------------------------------------
    '--------------------- REPROGRAMACION --------------------
    '---------------------------------------------------------
    Private Function Programacion(ByVal a_BD As Boolean) As Integer
        Dim Saldo As Double = xsaldo '= xnuevosaldo
        Dim Cuota As Double = xsaldo 'xnuevosaldo
        Dim FechaPago As DateTime = DtpFechaPrimerPag.Value
        Dim TasaInteres As Double = xtasainteres / 100
        Dim Tasa_Seguro As Double = xtasaseguro / 100
        Dim Periodo As Integer = IIf(xperiodo = "MM", 30, 15)
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
                TablaProgs.Rows.Add(Compañia, 0, i, xdeduccion, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
            End If
            If xperiodo = "QQ" Then
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
                TablaProgs.Rows.Add(Compañia, 0, i, xdeduccion, FechaPago, Saldo, Capital, Interes, Seguro, Cuota, Saldo - Capital, InteresAcum)
            End If
        End If
        Return i
    End Function

    Private Sub realizaAbono(ByVal bandera As Integer)
        Dim query As String
        Dim abono As Double = xabono
        Dim solicitudes As Array = Split(xsolicitudes, ",")
        Dim capital As Double
        Dim capitalDescontado As Double
        Dim interes As Double
        Dim seguro As Double
        Dim corrAbono As Integer
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
            abono = abono - xinteres - xseguro
            xnuevosaldo = Format(xsaldo - abono, "0.00")
            'If xnuevosaldo = 0 Then
            'MsgBox("Se ha cancelado la deuda en su totalidad." & vbCrLf & "Haga click en abonar para guardar los cambios.", MsgBoxStyle.Information, "Abono Deudas")
            'Me.BtnNuevo_Click(New Object, New System.EventArgs)
            ' End If
        End If
        'realizo el proceso 
        If bandera = 1 Then
            xSql = "select sol.CORRELATIVO, det.CAPITAL, det.INTERES, det.SEG_DEUDA from COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE as det inner join COOPERATIVA_SOLICITUDES as sol  on det.NUMERO_SOLICITUD=sol.CORRELATIVO  where sol.CODIGO_BUXIS= " & xcodigo & " and sol.DEDUCCION= " & xdeduccion & "and det.CAPITAL_D=0"
            xsqlCmd.CommandText = xSql
            Table = jClass.obtenerDatos(xsqlCmd)
            For Each dr As DataRow In Table.Rows
                capital = Math.Round(dr(1), 2)

                If xinteres > 0 Then
                    interes = Math.Round(dr(2), 2)
                Else
                    interes = 0
                End If
                If xseguro > 0 Then
                    seguro = Math.Round(dr(3), 2)
                Else
                    seguro = 0
                End If


                'Next
                abono = Math.Round(abono - interes - seguro, 2)

                If abono >= capital Then
                    capitalDescontado = capital
                Else
                    capitalDescontado = abono
                    xsolicitud = dr(0).ToString
                End If
                xnuevosaldo = capital - abono
                abono = Math.Round(abono - capital, 2)

                Linea = Me.eliminaProgramacionesNoDescontadas(dr(0))
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
                query &= "," & dr(0)
                query &= "," & Linea
                query &= ",0"
                query &= ",0"
                query &= ",'" & Format(Me.DtpFechaAbono.Value, "dd/MM/yyyy") & "'"
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
                query &= ",'APLICACION REMESA EFECTUADA POR " & Me.dgvAbonos.Rows(0).Cells(6).Value & " DE FECHA " & Format(Me.DtpFechaAbono.Value, "dd/MM/yyyy") & "')"
                jClass.Ejecutar_ConsultaSQL(query)
                'generaPartidaSolicitud(solicitud, capitalDescontado)
                'guarda informacion del abono
                query = "EXEC dbo.sp_COOPERATIVA_ABONOS " & Compañia
                query &= "," & dr(0) & ",'" & xcodigoas & "',"
                query &= xcodigo & "," & (interes + seguro + capitalDescontado).ToString()
                query &= "," & interes & "," & seguro & "," & capitalDescontado & "," & IIf((capital - capitalDescontado) > 0, "0", "1") & ","
                query &= "1,"
                query &= "0,"
                query &= xbanco & ","
                query &= "0,"
                query &= Usuario & ",1"
                jClass.Ejecutar_ConsultaSQL(query)
                query = "SELECT ISNULL(MAX(CORRELATIVO),0) AS CORRELATIVO FROM COOPERATIVA_SOLICITUDES_ABONOS" & vbCrLf
                query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                query &= " AND CODIGO_AS = '" & xcodigoas & "'" & vbCrLf
                query &= " AND CODIGO_BUXIS = " & xcodigo
                corrAbono = CInt(jClass.obtenerEscalar(query))
                query = "UPDATE COOPERATIVA_SOLICITUDES_ABONOS " & vbCrLf
                query &= "SET FECHA_ABONO = '" & Format(Me.DtpFechaAbono.Value, "dd/MM/yyyy") & "'" & vbCrLf
                query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                query &= " AND CODIGO_AS = '" & xcodigoas & "'" & vbCrLf
                query &= " AND CODIGO_BUXIS = " & xcodigo & vbCrLf
                query &= " AND CORRELATIVO = " & corrAbono
                jClass.Ejecutar_ConsultaSQL(query)
                If abono <= 0 Then
                    Exit For
                End If
            Next
            If xnuevosaldo > 0 And Me.DgvProgramacion.Rows.Count > 0 Then
                ''Si todavia hay saldo pendiente de pago, se inserta la programación calculada
                'query = "DELETE FROM COOPERATIVA_PROGRAMACION_ILUSTRATIVA WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & xsolicitud
                'jClass.Ejecutar_ConsultaSQL(query)
                query = "UPDATE COOPERATIVA_PROGRAMACION_ILUSTRATIVA SET LINEA = LINEA + " & Linea & ", N_SOLICITUD = " & xsolicitud & " WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD =" & xsolicitud
                jClass.Ejecutar_ConsultaSQL(query)
                MantenimientoProgramacionDetalle()
            End If

        End If
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
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD "
            Sql &= Compañia & ","
            Sql &= solicitud & ","
            Sql &= "'" & Usuario & "','E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Retorno = Comando_Track.ExecuteScalar()
            Comando_Track.CommandText = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET COMENTARIO_ANULADA = 'CANCELADO CON ABONO (" & 0 & ")' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Retorno
    End Function

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
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINICIO", SqlDbType.DateTime).Value = xfechaabono
            DataAdapter.SelectCommand.Parameters.Add("@FECHAINIDES", SqlDbType.DateTime).Value = DtpFechaPrimerPag.Value
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA ", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@NUM_SOLICITUD", SqlDbType.Int).Value = xsolicitud
            DataAdapter.SelectCommand.Parameters.Add("@CUOTASDESEADAS", SqlDbType.Int).Value = 1
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

    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click

        Try
            'Instanciamos nuestro cuadro de dialogo
            Dim openFileDialog1 As New OpenFileDialog
            'Directorio Predeterminado
            openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            'Filtramos solo archivos con extension *.xls
            openFileDialog1.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos Excel 97-2003|*.xls"

            'Si se presiona abrir entonces...
            If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Asignamos la ruta donde se almacena el fichero excel que se va a importar
                Me.lblArchivoExcel.Text = openFileDialog1.FileName
                ListarHojasExcel(Me.lblArchivoExcel.Text)
                cargaGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cargaGrid()
        Try
            If Me.lblArchivoExcel.Text.Length > 0 Then
                'Instanciamos nuestra cadena de conexion especial para excel,indicando la ruta del fichero
                'Dim cadconex As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.lblArchivoExcel.Text.Trim & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
                Dim cadconex As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.lblArchivoExcel.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
                Dim cn As New OleDb.OleDbConnection(cadconex)
                Dim cmd As New OleDbCommand
                Dim da As New OleDb.OleDbDataAdapter
                Dim dt As New DataTable

                cmd.Connection = cn
                'Consultamos la hoja llamada Clientes de nuestro archivo *.xls
                If Me.lblArchivoExcel.Text.Length = 0 Then
                    MsgBox("DEBE ESTABLECER EL NOMBRE DEL ARCHIVO DE EXCEL")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT * FROM [" & Me.cmbSheets.Text & "$]"
                cmd.CommandType = CommandType.Text

                da.SelectCommand = cmd
                'Llenamos el datatable
                da.Fill(dt)
                'Llenamos el Datagridview
                Me.dgvAbonos.DataSource = dt
                'Ajustamos las columnas del DataGridView
                dgvAbonos.AutoSizeColumnsMode = 6
                If Me.dgvAbonos.RowCount > 0 Then
                    Me.btnabonar.Enabled = True
                    Try
                        Me.txtConcepto.Text = "Abonos por consumo de " & Me.dgvAbonos.Rows(0).Cells("EMPRESA").Value
                    Catch ex As Exception
                        Me.txtConcepto.Text = "Abonos por consumo de empresas externas"
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmabonoexternos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
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

    Private Sub ListarHojasExcel(ByVal XLSFile As String)
        Try
            While Me.cmbSheets.Items.Count > 0
                Me.cmbSheets.Items.RemoveAt(0)
            End While
            oExcelApp.WorkBooks.Open(XLSFile)
            Dim oExcelSheets = oExcelApp.WorkBooks(1).Sheets
            Dim CntSheets As Integer = oExcelSheets.Count
            For i As Integer = 1 To CntSheets
                Me.cmbSheets.Items.Add(oExcelSheets(i).Name)
            Next

            oExcelApp.WorkBooks(1).Close()
            Me.cmbSheets.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbSheets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheets.SelectedIndexChanged
        cargaGrid()
    End Sub

    Private Function Mantenimiento_TransaccionE(ByVal Compañia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim A As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            sql &= ",@PARTIDA        = " & Partida & vbCrLf
            sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            sql &= ",@ANULADA        = " & Anulada & vbCrLf
            sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            A = Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Partida Reservada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Partida Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Partida Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return A
    End Function

    Private Function Mantenimiento_TransaccionL(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim A As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LINEA          = " & Linea & vbCrLf
            Sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            Sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            Sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'" & vbCrLf
            Sql &= ",@CUENTANEW	     = 0" & vbCrLf
            Sql &= ",@DETALLENEW     = 0" & vbCrLf
            Comando_ = New SqlCommand(Sql, Conexion_)
            A = Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return A
    End Function

    Private Sub CargaCuentaContable()
        Dim Conexion_ As New SqlConnection(CnnStrBldr.ConnectionString)
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            Sql &= Compañia
            Sql &= ", " & Me.cmbBANCO.SelectedValue
            Sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= ", " & 0
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Me.lblCUENTA_COMPLETA.Text = DataReader_.Item("CUENTA_COMPLETA")
                Me.lblCUENTA.Text = DataReader_.Item("CUENTA")
                Me.lblLIBRO_CONTABLE.Text = DataReader_.Item("LIBRO_CONTABLE")
            Else
                Me.lblCUENTA_COMPLETA.Text = ""
                Me.lblCUENTA.Text = "0"
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 4, Me.cmbCUENTA_BANCARIA)
            CargaCuentaContable()
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub cmbCUENTA_BANCARIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCUENTA_BANCARIA.SelectedIndexChanged
        If Iniciando = False And Me.cmbCUENTA_BANCARIA.ValueMember <> "" Then
            CargaCuentaContable()
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub
End Class