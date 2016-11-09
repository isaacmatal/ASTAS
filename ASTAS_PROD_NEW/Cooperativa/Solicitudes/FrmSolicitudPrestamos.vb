Imports System.Data.SqlClient

Public Class FrmSolicitudPrestamos
    Dim Sql As String
    Dim Iniciando, BloqueoSelectivo As Boolean
    Dim Bandera As Boolean = True
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim autorizacionAutomatica As Boolean
    Dim Bloqueado, SoloSocios As Boolean
    Dim LimiteSolic As Double

    Private Sub FrmSolicitudPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtRecibido.Text = Usuario
        Me.CbxPeriodo.SelectedIndex = 0
        CargaSolicitud(Compañia)
        BuscaPeriodo()
        Me.DpFechaSol.Value = Now
        Iniciando = False
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub CargaSolicitud(ByVal compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PRESTAMO " & compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable
            DataAdapter_.Fill(Table)
            CbxSolicitud.ValueMember = "SOLICITUD"
            CbxSolicitud.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxSolicitud.DataSource = Table
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                LblDeduccion.Text = DataReader_Track.Item("DEDUCCION")
                Me.TxtInteres.Text = DataReader_Track.Item("INTERES")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function SolicitudesNoModificables() As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim Table As DataTable
        Dim bandera As Boolean
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_NO_MODIFICABLES " & Compañia & "," & TxtNumeroSol.Text
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                bandera = True
            Else
                bandera = False
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bandera
    End Function

    Private Sub Numero_Orden()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Exec sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ",@TIPO_DOCUMENTO = 'SOL', @ULTIMO = 0"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                TxtNumeroSol.Text = DataReader_Track.Item(0)
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Limpiar_Objetos()
        Me.TxtCodigoAs.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtDepartamento.Text = Nothing
        Me.TxtDivision.Text = Nothing
        Me.TxtTel.Text = Nothing
        Me.TxtNit.Text = Nothing
        Me.TxtDui.Text = Nothing
        Me.TxtDireccion.Text = Nothing
        Me.TxtNombreSocio.Text = Nothing
        'Me.TxtRecibido.Text = Nothing
        Me.TxtRevisado.Text = Nothing
        Me.TxtRazon.Text = Nothing
        Me.TxtCodigoAsFi.Text = Nothing
        Me.TxtCodigoBuFi.Text = Nothing
        Me.TxtTelFi.Text = Nothing
        Me.TxtDuiFi.Text = Nothing
        Me.TxtNitFi.Text = Nothing
        Me.TxtNombreFiador.Text = Nothing
        Me.TxtDeparFi.Text = Nothing
        Me.TxtDivisionFi.Text = Nothing
        Me.TxtDireccionFi.Text = Nothing
        Me.TxtObservaciones.Text = Nothing
        Me.LblDisponibleFi.Text = "0.00"
        Me.TxtHastaSin.Text = "0.00"
        Me.TxtDesdeCon.Text = "0.00"
        Me.LblTHastaCon.Text = "0.00"
        Me.LblIndemnizacion.Text = "0.00"
        Me.TxtCantidad.Text = "0.00"
        Me.ChxAutorizacionExp.Checked = Nothing
        Me.NudPlazo.Value = 1
        Me.TxtNumeroSol.Text = "0"
        Me.DgvFiadores.DataSource = Nothing
        Me.BtnGuardar.Enabled = True
        Me.DpFechaSol.Value = Now
        Me.TxtRevisado.Text = Nothing
        Me.CheckBox1.Checked = False
        Me.txtBonif.Text = "0.00"
        Me.txtAguin.Text = "0.00"
        Limpia_Campos_Fiador()
        Limpia_Campos_Fiador2()
        Limpia_Campos_Fiador3()
    End Sub
    Private Sub Limpia_Campos_Fiador()
        Me.TxtCodigoAsFi.Text = Nothing
        Me.TxtCodigoBuFi.Text = Nothing
        Me.TxtTelFi.Text = Nothing
        Me.TxtDuiFi.Text = Nothing
        Me.TxtNitFi.Text = Nothing
        Me.TxtNombreFiador.Text = Nothing
        Me.TxtDeparFi.Text = Nothing
        Me.TxtDivisionFi.Text = Nothing
        Me.TxtDireccionFi.Text = Nothing
        Me.LblDisponibleFi.Text = "0.00"
        Me.DgvFiadores.DataSource = Nothing
    End Sub
    Private Sub Limpia_Campos_Fiador2()
        Me.TxtCodigoAsFi2.Text = Nothing
        Me.TxtCodigoBuFi2.Text = Nothing
        Me.TxtTelFi2.Text = Nothing
        Me.TxtDuiFi2.Text = Nothing
        Me.TxtNitFi2.Text = Nothing
        Me.TxtNombreFiador2.Text = Nothing
        Me.TxtDeparFi2.Text = Nothing
        Me.TxtDivisionFi2.Text = Nothing
        Me.TxtDireccionFi2.Text = Nothing
        Me.LblDisponibleFi2.Text = "0.00"
        Me.DgvFiadores2.DataSource = Nothing
    End Sub
    Private Sub Limpia_Campos_Fiador3()
        Me.TxtCodigoAsFi3.Text = Nothing
        Me.TxtCodigoBuFi3.Text = Nothing
        Me.TxtTelFi3.Text = Nothing
        Me.TxtDuiFi3.Text = Nothing
        Me.TxtNitFi3.Text = Nothing
        Me.TxtNombreFiador3.Text = Nothing
        Me.TxtDeparFi3.Text = Nothing
        Me.TxtDivisionFi3.Text = Nothing
        Me.TxtDireccionFi3.Text = Nothing
        Me.LblDisponibleFi3.Text = "0.00"
        Me.DgvFiadores3.DataSource = Nothing
    End Sub

    Private Sub Insertar_SolicitudesdePretamosN(ByVal IU)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE Coo.sp_COOPERATIVA_SOLICITUDES_IU'" & Compañia & "','" _
            & Me.CbxSolicitud.SelectedValue & "','" & CInt(Me.LblDeduccion.Text) & "','" & Me.TxtNumeroSol.Text & "','" & (Me.TxtCodigoAs.Text) & "','" _
            & CInt(Me.TxtCodigoBuxis.Text) & "','0','" & Format(Me.DpFechaSol.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & IIf(ChxAutorizacionExp.Checked = True, "1", "0") & ",'" & TxtCantidad.Text & "','" & TxtInteres.Text & "','" & StrDup(2, CbxPeriodo.Text.Substring(0, 1)) & "','" & NudPlazo.Value & "','" & Usuario & "'" & ", 1, " & Val(Me.txtBonif.Text) & ", " & Val(Me.txtAguin.Text)
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()

            Sql = "EXECUTE Coo.sp_COOPERATIVA_SOLICITUDES_PRESTAMOS_IU"
            Sql &= " @COMPAÑIA = " & Compañia & ","
            Sql &= " @SOLICITUD = " & Me.CbxSolicitud.SelectedValue & ","
            Sql &= " @DEDUCCION = " & CInt(Me.LblDeduccion.Text) & ","
            Sql &= " @CORRELATIVO = " & Me.TxtNumeroSol.Text & ","
            Sql &= " @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "',"
            Sql &= " @CODIGO_BUXIS = " & CInt(Me.TxtCodigoBuxis.Text) & ","
            Sql &= " @FECHA_SOLICITUD = '" & Format(Me.DpFechaSol.Value, "dd-MM-yyyy HH:mm:ss") & "',"
            Sql &= " @RECIBIDO = '" & Trim(Me.TxtRecibido.Text) & "',"
            Sql &= " @REVISADO = '" & Me.TxtRevisado.Text & "',"
            Sql &= " @AUTORIZACION_EX = " & IIf(ChxAutorizacionExp.Checked = True, "1", "0") & ","
            Sql &= " @CANTIDAD = " & TxtCantidad.Text & ","
            Sql &= " @RAZON = '" & Me.TxtRazon.Text.Trim & "',"
            Sql &= " @INTERES = " & TxtInteres.Text & ","
            Sql &= " @PERIODO = '" & StrDup(2, CbxPeriodo.Text.Substring(0, 1)) & "',"
            Sql &= " @PLAZO = " & NudPlazo.Value & ","
            Sql &= " @PRIMER_QUINCENA = 0,"
            Sql &= " @OBSERVACIONES = '" & Me.TxtObservaciones.Text & "',"
            Sql &= " @CODIGO_ASFI = '" & IIf(Me.TxtCodigoAsFi.Text = Nothing, "0", Me.TxtCodigoAsFi.Text) & "',"
            Sql &= " @CODIGO_BUXISFI  = " & CInt(IIf(Me.TxtCodigoBuFi.Text = Nothing, "0", Me.TxtCodigoBuFi.Text)) & ","
            Sql &= " @CODIGO_ASFI2 = '" & IIf(Me.TxtCodigoAsFi2.Text = Nothing, "0", Me.TxtCodigoAsFi2.Text) & "',"
            Sql &= " @CODIGO_BUXISFI2 = " & CInt(IIf(Me.TxtCodigoBuFi2.Text = Nothing, "0", Me.TxtCodigoBuFi2.Text)) & ","
            Sql &= " @CODIGO_ASFI3 = '" & IIf(Me.TxtCodigoAsFi3.Text = Nothing, "0", Me.TxtCodigoAsFi3.Text) & "',"
            Sql &= " @CODIGO_BUXISFI3 = " & CInt(IIf(Me.TxtCodigoBuFi3.Text = Nothing, "0", Me.TxtCodigoBuFi3.Text)) & ","
            Sql &= " @USUARIO = '" & Usuario & "'"
            Comando_Track.CommandText = Sql
            If Comando_Track.ExecuteNonQuery() > 0 Then
                If Val(Me.TxtCodigoBuFi.Text) > 0 Then
                    Fiadores(2, Val(Me.TxtCodigoBuxis.Text), Me.TxtNumeroSol.Text, Me.TxtCodigoBuFi.Text)
                End If
                If Val(Me.TxtCodigoBuFi2.Text) > 0 Then
                    Fiadores(2, Val(Me.TxtCodigoBuxis.Text), Me.TxtNumeroSol.Text, Me.TxtCodigoBuFi2.Text)
                End If
                If Val(Me.TxtCodigoBuFi3.Text) > 0 Then
                    Fiadores(2, Val(Me.TxtCodigoBuxis.Text), Me.TxtNumeroSol.Text, Me.TxtCodigoBuFi3.Text)
                End If
            End If
            If CInt(Me.LblDeduccion.Text.Trim) = 242 And Not Me.chkElectro.Checked Then
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS" & vbCrLf
                Sql &= " SET PAGADA = 1" & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= " AND CORRELATIVO = " & Me.TxtNumeroSol.Text & vbCrLf
                Comando_Track.CommandText = Sql
                Comando_Track.ExecuteNonQuery()
            End If
            If Me.chkEfectivo.Checked Then
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS" & vbCrLf
                Sql &= " SET PAGADA = 1, REVISADO = '" & Usuario & "'" & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= " AND CORRELATIVO = " & Me.TxtNumeroSol.Text & vbCrLf
                Comando_Track.CommandText = Sql
                Comando_Track.ExecuteNonQuery()
            End If
            Select Case IU
                Case "I"
                    MsgBox("¡Solicitud: " + Me.TxtNumeroSol.Text + " Guardada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡La solicitud: " + Me.TxtNumeroSol.Text + " ha sido modificada con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
            Resetear_montomaximo("", Me.TxtCodigoBuxis.Text)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscaSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & DS.Tables(0).Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & DS.Tables(0).Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a procesar este código", MsgBoxStyle.Information, DS.Tables(0).Rows(0).Item(1) & " - " & DS.Tables(0).Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                'If jClass.SocioBloqueado(DS.Tables(0).Rows(0).Item(1).ToString()) Then
                '    Me.TxtCodigoAs.Clear()
                '    Hay_Datos = False
                '    Return
                'End If
                TxtCodigoAs.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuxis.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombreSocio.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDepartamento.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivision.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTel.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNit.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDui.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccion.Text = DS.Tables(0).Rows(0).Item(8)
                If DS.Tables(0).Rows(0).Item("ESTATUS") = 0 Then
                    MsgBox("¡Empleado esta INACTIVO!", MsgBoxStyle.Exclamation, "AVISO")
                    Limpiar_Objetos()
                    Hay_Datos = False
                Else
                    If SoloSocios Then
                        If DS.Tables(0).Rows(0).Item("ESTATUS") = 2 Then
                            Hay_Datos = True
                        Else
                            MsgBox("El Tipo de solicitud solo aplica a Socios", MsgBoxStyle.Information, DS.Tables(0).Rows(0).Item(1) & " - " & DS.Tables(0).Rows(0).Item(2))
                            Limpiar_Objetos()
                            Hay_Datos = False
                        End If
                    Else
                        Hay_Datos = True
                    End If
                End If
            Else
                MsgBox("Código no existe!", MsgBoxStyle.Exclamation, "AVISO")
                Limpiar_Objetos()
                Hay_Datos = False
            End If
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BuscaSocioFiador()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If jClass.SocioBloqueado(ParamcodigoAs) Then
            Me.TxtCodigoAsFi.Clear()
            Hay_Datos = False
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                TxtCodigoAsFi.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi.Text = DS.Tables(0).Rows(0).Item(1)
                ParamcodigoBux = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi.Text = DS.Tables(0).Rows(0).Item(8)
                DataReader_Track = Comando_Track.ExecuteReader
                Hay_Datos = True
            Else
                MsgBox("Código de socio no existe.!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub BuscaSocioFiador2()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If jClass.SocioBloqueado(ParamcodigoAs) Then
            Me.TxtCodigoAsFi2.Clear()
            Hay_Datos = False
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                TxtCodigoAsFi2.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi2.Text = DS.Tables(0).Rows(0).Item(1)
                ParamcodigoBux = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador2.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi2.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi2.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi2.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi2.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi2.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi2.Text = DS.Tables(0).Rows(0).Item(8)
                DataReader_Track = Comando_Track.ExecuteReader
                Hay_Datos = True
            Else
                MsgBox("Código de socio no existe.!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub BuscaSocioFiador3()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If jClass.SocioBloqueado(ParamcodigoAs) Then
            Me.TxtCodigoAsFi3.Clear()
            Hay_Datos = False
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                TxtCodigoAsFi3.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi3.Text = DS.Tables(0).Rows(0).Item(1)
                ParamcodigoBux = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador3.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi3.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi3.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi3.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi3.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi3.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi3.Text = DS.Tables(0).Rows(0).Item(8)
                DataReader_Track = Comando_Track.ExecuteReader
                Hay_Datos = True
            Else
                MsgBox("Código de socio no existe.!", MsgBoxStyle.Exclamation, "AVISO")
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub DetalleSocioFiador()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If Val(Me.TxtCodigoAsFi.Text) = 0 Then
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(Me.TxtCodigoAsFi.Text) & "','" & Trim(Me.TxtCodigoBuFi.Text) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count = 0 Then
                Limpia_Campos_Fiador()
            Else
                TxtCodigoAsFi.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi.Text = DS.Tables(0).Rows(0).Item(8)
            End If
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub DetalleSocioFiador2()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If Val(Me.TxtCodigoAsFi2.Text) = 0 Then
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(Me.TxtCodigoAsFi2.Text) & "','" & Trim(Me.TxtCodigoBuFi2.Text) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count = 0 Then
                Limpia_Campos_Fiador2()
            Else
                TxtCodigoAsFi2.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi2.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador2.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi2.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi2.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi2.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi2.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi2.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi2.Text = DS.Tables(0).Rows(0).Item(8)
            End If
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub DetalleSocioFiador3()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        If Val(Me.TxtCodigoAsFi3.Text) = 0 Then
            Return
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO'" & Trim(Me.TxtCodigoAsFi3.Text) & "','" & Trim(Me.TxtCodigoBuFi3.Text) & "'," & Compañia
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables(0).Rows.Count = 0 Then
                Limpia_Campos_Fiador3()
            Else
                TxtCodigoAsFi3.Text = DS.Tables(0).Rows(0).Item(0)
                TxtCodigoBuFi3.Text = DS.Tables(0).Rows(0).Item(1)
                TxtNombreFiador3.Text = DS.Tables(0).Rows(0).Item(2)
                TxtDeparFi3.Text = DS.Tables(0).Rows(0).Item(3)
                TxtDivisionFi3.Text = DS.Tables(0).Rows(0).Item(4)
                TxtTelFi3.Text = DS.Tables(0).Rows(0).Item(5)
                TxtNitFi3.Text = DS.Tables(0).Rows(0).Item(6)
                TxtDuiFi3.Text = DS.Tables(0).Rows(0).Item(7)
                TxtDireccionFi3.Text = DS.Tables(0).Rows(0).Item(8)
            End If
            DataReader_Track = Comando_Track.ExecuteReader
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MuestraSolicitud()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_PRESTAMOS " & Compañia _
            & "," & ParamcodSolicitud & "," & 0 & "," & 0 & ",'" & Nothing & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Me.CbxSolicitud.SelectedValue = DataReader_Track.Item("SOLICITUD")
                Me.TxtNumeroSol.Text = DataReader_Track.Item("CORRELATIVO")
                Me.TxtCodigoAs.Text = DataReader_Track.Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = DataReader_Track.Item("CODIGO_BUXIS")
                Me.TxtNombreSocio.Text = DataReader_Track.Item("NOMBRE_COMPLETO")
                Me.TxtDepartamento.Text = DataReader_Track.Item("DESCRIPCION_DEPARTAMENTO")
                Me.TxtDivision.Text = DataReader_Track.Item("DESCRIPCION_DIVISION")
                Me.DpFechaSol.Value = DataReader_Track.Item("FECHA_SOLICITUD")
                Me.TxtTel.Text = DataReader_Track.Item("TELEFONO")
                Me.TxtNit.Text = DataReader_Track.Item("NIT")
                Me.TxtDui.Text = DataReader_Track.Item("DUI")
                Me.TxtDireccion.Text = DataReader_Track.Item("DIRECCION")
                Me.TxtRecibido.Text = DataReader_Track.Item("RECIBIDO")
                Me.TxtRevisado.Text = DataReader_Track.Item("REVISADO")
                Me.TxtRazon.Text = DataReader_Track.Item("RAZON")
                Me.TxtObservaciones.Text = DataReader_Track.Item("OBSERVACIONES")
                Me.TxtCodigoAsFi.Text = IIf(Val(DataReader_Track.Item("CODIGO_ASFI")) = 0, "", DataReader_Track.Item("CODIGO_ASFI"))
                Me.TxtCodigoBuFi.Text = IIf(DataReader_Track.Item("CODIGO_BUXISFI") = 0, "", DataReader_Track.Item("CODIGO_BUXISFI"))
                Me.TxtCodigoAsFi2.Text = IIf(Val(DataReader_Track.Item("CODIGO_ASFI2")) = 0, "", DataReader_Track.Item("CODIGO_ASFI2"))
                Me.TxtCodigoBuFi2.Text = IIf(DataReader_Track.Item("CODIGO_BUXISFI2") = 0, "", DataReader_Track.Item("CODIGO_BUXISFI2"))
                Me.TxtCodigoAsFi3.Text = IIf(Val(DataReader_Track.Item("CODIGO_ASFI3")) = 0, "", DataReader_Track.Item("CODIGO_ASFI3"))
                Me.TxtCodigoBuFi3.Text = IIf(DataReader_Track.Item("CODIGO_BUXISFI3") = 0, "", DataReader_Track.Item("CODIGO_BUXISFI3"))
                Me.ChxAutorizacionExp.Checked = DataReader_Track.Item("AUTORIZACION_EX")
                Me.TxtCantidad.Text = Format(DataReader_Track.Item("CANTIDAD"), ".00")
                Me.NudPlazo.Value = DataReader_Track.Item("PLAZO")
                If DataReader_Track.Item("PERIODO") = "QQ" Then
                    Me.CbxPeriodo.SelectedIndex = 0
                Else
                    Me.CbxPeriodo.SelectedIndex = 1
                End If
                Me.txtBonif.Text = DataReader_Track.Item("DESCUENTO_BONIFICACION")
                Me.txtAguin.Text = DataReader_Track.Item("DESCUENTO_AGUINALDO")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub DisponibleSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi, AhorroExtraOrdi, ptmos As Double
        Dim Deducciones, SinFiador, ConFiador As Double
        Dim DeudaPagada As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deducciones = 0
            DeudaPagada = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                AhorroExtraOrdi = DataReader_Track.Item("AHORRO EXTRAORDINARIO")
                Deducciones = DataReader_Track.Item("MONTO POR SALDAR")
                DeudaPagada = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")
                If Origen = 5 Or Origen = 6 Then
                    Sql = "SELECT ISNULL(SUM(D.CAPITAL),0.00) AS CAPITAL"
                    Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D"
                    Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA"
                    Sql &= "   AND S.CORRELATIVO = D.NUMERO_SOLICITUD"
                    Sql &= "   AND S.CODIGO_BUXIS = " & Trim(ParamcodigoBux)
                    Sql &= "   AND D.CAPITAL_D = 0"
                    Sql &= "   AND S.COMPAÑIA = " & Compañia
                    Sql &= "   AND S.DEDUCCION = " & CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")).ToString()
                    ptmos = jClass.obtenerEscalar(Sql)
                    SinFiador = (AhorroOrdi + AhorroExtraOrdi) - ptmos
                    ConFiador = (AhorroOrdi + AhorroExtraOrdi * 1.75) - ptmos
                Else
                    SinFiador = AhorroOrdi - Deducciones
                    ConFiador = (AhorroOrdi * 2) - Deducciones
                End If
                If SinFiador < 0 Then
                    SinFiador = 0
                End If
                If ConFiador < 0 Then
                    ConFiador = 0
                End If
                If DataReader_Track.Item("DESCRIPCION_DEPARTAMENTO") = "VENTAS PARACENTRAL" Then
                    TxtDesdeSin.Text = "0.01"
                    TxtHastaSin.Text = Format(SinFiador, "0.00")
                    TxtDesdeCon.Text = CStr(TxtDesdeSin.Text)
                    LblTHastaCon.Text = CStr(TxtHastaSin.Text)
                Else
                    TxtDesdeSin.Text = "0.01"
                    TxtHastaSin.Text = Format(SinFiador, "0.00")
                    TxtDesdeCon.Text = Format(SinFiador + IIf(SinFiador > 0, 0.01, 0.0), "0.00")
                    LblTHastaCon.Text = Format(ConFiador, "0.00")
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Conexion_Track.Close()
        End Try
    End Sub
    Private Sub DisponibleSocioFi()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deducciones As Double
        Dim DeudaPagada As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deducciones = 0
            DeudaPagada = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                Deducciones = DataReader_Track.Item("MONTO POR SALDAR")
                DeudaPagada = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")
                If (AhorroOrdi - Deducciones) < 0 Then
                    LblDisponibleFi.Text = "0.00"
                Else
                    LblDisponibleFi.Text = Format((AhorroOrdi - Deducciones), "0.00") ' + DeudaPagada, "0.00")
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub DisponibleSocioFi2()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deducciones As Double
        Dim DeudaPagada As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deducciones = 0
            DeudaPagada = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                Deducciones = DataReader_Track.Item("MONTO POR SALDAR")
                DeudaPagada = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")
                If (AhorroOrdi - Deducciones) < 0 Then
                    LblDisponibleFi2.Text = "0.00"
                Else
                    LblDisponibleFi2.Text = Format((AhorroOrdi - Deducciones), "0.00") ' + DeudaPagada, "0.00")
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub DisponibleSocioFi3()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deducciones As Double
        Dim DeudaPagada As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deducciones = 0
            DeudaPagada = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                Deducciones = DataReader_Track.Item("MONTO POR SALDAR")
                DeudaPagada = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")
                If (AhorroOrdi - Deducciones) < 0 Then
                    LblDisponibleFi3.Text = "0.00"
                Else
                    LblDisponibleFi3.Text = Format((AhorroOrdi - Deducciones), "0.00") ' + DeudaPagada, "0.00")
                End If
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Muestra_Fiadores(ByVal codigo As Integer, ByVal dgv As DataGridView)
        Try
            dgv.DataSource = Fiadores(4, codigo, 0, 0)
            StyleGrid(dgv)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Muestra_Fiadores2()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_MOSTRAR_SOCIO_DEPENDIENTE_FIADOR_DEUDA] " & Compañia & ",0," & TxtCodigoBuFi2.Text & ",'" & TxtCodigoAsFi2.Text & "',1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvFiadores2.Columns.Clear()
            If Val(TxtCodigoAsFi2.Text) = 0 And Val(TxtCodigoBuFi2.Text) = 0 Or TxtCodigoAsFi2.Text = Nothing And TxtCodigoBuFi2.Text = Nothing Then
                Return
            End If
            DgvFiadores2.DataSource = DS.Tables(0)
            StyleGrid(DgvFiadores2)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Muestra_Fiadores3()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Dim DS As New DataSet()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_MOSTRAR_SOCIO_DEPENDIENTE_FIADOR_DEUDA] " & Compañia & ",0," & TxtCodigoBuFi3.Text & ",'" & TxtCodigoAsFi3.Text & "',1"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvFiadores3.Columns.Clear()
            If Val(TxtCodigoAsFi3.Text) = 0 And Val(TxtCodigoBuFi3.Text) = 0 Or TxtCodigoAsFi3.Text = Nothing And TxtCodigoBuFi3.Text = Nothing Then
                Return
            End If
            DgvFiadores3.DataSource = DS.Tables(0)
            StyleGrid(DgvFiadores3)
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub InsertaAutorizaciones()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Dim DataAdapter As New SqlDataAdapter("Coo.sp_COOPERATIVA_SOLICITUDES_AUTORIZACION_IU", Conexion_Track)
        Dim ds As New DataSet
        Try
            Conexion_Track.Open()
            DataAdapter.SelectCommand.Parameters.Add("@COMPAÑIA", SqlDbType.Int).Value = Compañia
            DataAdapter.SelectCommand.Parameters.Add("@N_SOLICITUD", SqlDbType.Int).Value = CInt(TxtNumeroSol.Text)
            DataAdapter.SelectCommand.Parameters.Add("@ORDEN_DE_COMPRA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = Me.chkEfectivo.Checked
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = IIf(Me.chkEfectivo.Checked, "DESTINO: " & Me.TxtRazon.Text & " (PAGADO EN EFECTIVO)", "")
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = IIf(Me.chkEfectivo.Checked, Me.DpFechaSol.Value, Now)
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION2", SqlDbType.Bit).Value = False
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO2", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = Now
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION3", SqlDbType.Bit).Value = False
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO3", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA3", SqlDbType.DateTime).Value = Now
            DataAdapter.SelectCommand.Parameters.Add("@DENEGADA", SqlDbType.Bit).Value = False
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_DENEGADA", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_DENEGADA", SqlDbType.DateTime).Value = Now
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_DENEGO", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@ANULADA", SqlDbType.Bit).Value = False
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO_ANULADA", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@FECHA_ANULADA", SqlDbType.DateTime).Value = Now
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_ANULO", SqlDbType.NVarChar).Value = ""
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = TxtCodigoAs.Text
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_BUXIS", SqlDbType.Int).Value = Val(TxtCodigoBuxis.Text)
            DataAdapter.SelectCommand.Parameters.Add("@USUARIO_CREACION", SqlDbType.NVarChar).Value = Usuario
            DataAdapter.SelectCommand.Parameters.Add("@BANDERA", SqlDbType.Int).Value = 0
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub
    Private Sub MuestraDisponibleSocioFi()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deuda As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(IIf(Me.TxtCodigoAsFi.Text = Nothing, "0", Me.TxtCodigoAsFi.Text)) & "'," & Trim(IIf(Me.TxtCodigoBuFi.Text = Nothing, "0", Me.TxtCodigoBuFi.Text)) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deuda = 0
            If DataReader_Track.HasRows <> 0 Then
                If DataReader_Track.Read = True Then
                    AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                    Deuda = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")       'MONTO POR DESCONTAR EN SOLICITUDES")
                    If DataReader_Track.Item("DESCRIPCION_DEPARTAMENTO") = "VENTAS PARACENTRAL" Then
                        LblDisponibleFi.Text = CStr(AhorroOrdi - Deuda)
                    Else

                        LblDisponibleFi.Text = CStr(2 * (AhorroOrdi) - Deuda)
                    End If
                End If
            Else
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MuestraDisponibleSocioFi2()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deuda As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(IIf(Me.TxtCodigoAsFi2.Text = Nothing, "0", Me.TxtCodigoAsFi2.Text)) & "'," & Trim(IIf(Me.TxtCodigoBuFi2.Text = Nothing, "0", Me.TxtCodigoBuFi2.Text)) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deuda = 0
            If DataReader_Track.HasRows <> 0 Then
                If DataReader_Track.Read = True Then
                    AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                    Deuda = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")   'MONTO POR DESCONTAR EN SOLICITUDES")
                    If DataReader_Track.Item("DESCRIPCION_DEPARTAMENTO") = "VENTAS PARACENTRAL" Then
                        LblDisponibleFi2.Text = CStr(AhorroOrdi - Deuda)
                    Else
                        LblDisponibleFi2.Text = CStr(2 * (AhorroOrdi) - Deuda)
                    End If
                End If
            Else
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub MuestraDisponibleSocioFi3()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi As Double
        Dim Deuda As Double
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(IIf(Me.TxtCodigoAsFi3.Text = Nothing, "0", Me.TxtCodigoAsFi3.Text)) & "'," & Trim(IIf(Me.TxtCodigoBuFi3.Text = Nothing, "0", Me.TxtCodigoBuFi3.Text)) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            Deuda = 0
            If DataReader_Track.HasRows <> 0 Then
                If DataReader_Track.Read = True Then
                    AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                    Deuda = DataReader_Track.Item("MONTO DESCONTADO EN SOLICITUDES")   'MONTO POR DESCONTAR EN SOLICITUDES")
                    If DataReader_Track.Item("DESCRIPCION_DEPARTAMENTO") = "VENTAS PARACENTRAL" Then
                        LblDisponibleFi3.Text = CStr(AhorroOrdi - Deuda)
                    Else
                        LblDisponibleFi3.Text = CStr(2 * (AhorroOrdi) - Deuda)
                    End If
                End If
            Else
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            'Hoja de datos
            Me.TbpFiadores.Enabled = True
            'socio_hojadatos.TopMost = False
            'socio_hojadatos.TopLevel = False
            'socio_hojadatos.Parent = Me.TbpHojaDatos
            'socio_hojadatos.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'socio_hojadatos.Show()
            'socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
            'socio_hojadatos.TxtCodAS.Text = ParamcodigoAs
            'socio_hojadatos.TxtCodBuxy.Text = ParamcodigoBux
            'socio_hojadatos.BusquedaDatosSocios(Permitir)
            'socio_hojadatos.GrpDatosSocios.Visible = False
            'socio_hojadatos.TabControl1.Location = New System.Drawing.Point(1, 3)
            'socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)
            '***************
            BuscaSocio()
            Indemnizacion()
            Determinardisponible()
        End If
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoAs.Text <> Nothing Then
                Me.TxtCodigoAs.Text = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodigoAs.Text
                ParamcodigoBux = 0
                BuscaSocio()
                If Hay_Datos = True Then
                    ParamcodigoBux = Me.TxtCodigoBuxis.Text
                    'Hoja de datos
                    Me.TbpFiadores.Enabled = True
                    'socio_hojadatos.TopMost = False
                    'socio_hojadatos.TopLevel = False
                    'socio_hojadatos.Parent = Me.TbpHojaDatos
                    'socio_hojadatos.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    'socio_hojadatos.Show()
                    'socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
                    'socio_hojadatos.TxtCodAS.Text = ParamcodigoAs
                    'socio_hojadatos.TxtCodBuxy.Text = ParamcodigoBux
                    'socio_hojadatos.BusquedaDatosSocios(Permitir)
                    'socio_hojadatos.GrpDatosSocios.Visible = False
                    'socio_hojadatos.TabControl1.Location = New System.Drawing.Point(1, 3)
                    'socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)
                    '***************
                    Indemnizacion()
                    Determinardisponible()
                    Me.TxtCantidad.Focus()
                End If
            End If
        End If
    End Sub

    Private Function VerificaDisponibleDeLosFiadores() As Boolean
        Dim Disponible1 As Double = Val(LblDisponibleFi.Text)
        Dim Disponible2 As Double = Val(LblDisponibleFi2.Text)
        Dim Disponible3 As Double = Val(LblDisponibleFi3.Text)
        Dim Cantidad As Double = Val(TxtCantidad.Text)
        Dim Total As Double
        Total = IIf(Disponible1 > 0, Disponible1, 0) + IIf(Disponible2 > 0, Disponible2, 0) + IIf(Disponible3 > 0, Disponible3, 0)
        Try
            If Cantidad > Total Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function VerificaFiadores() As Boolean
        Try
            If Me.TxtNombreFiador3.Text <> Nothing And Me.TxtNombreFiador2.Text = Nothing Then
                MsgBox("¡Si Desea ingresar un tercer Fiador tiene que ingresar un segundo !", MsgBoxStyle.Information, "Validación")
                Return True
            End If
            If Me.TxtNombreFiador3.Text <> Nothing And Me.TxtNombreFiador2.Text <> Nothing And Me.TxtNombreFiador.Text = Nothing Then
                MsgBox("¡Si Desea ingresar segundo y tercer Fiador tiene que ingresar un Primero !", MsgBoxStyle.Information, "Validación")
                Return True
            End If
            If Me.TxtNombreFiador3.Text <> Nothing And Me.TxtNombreFiador.Text = Nothing Then
                MsgBox("¡Si Desea ingresar un segundo Fiador tiene que ingresar un primero !", MsgBoxStyle.Information, "Validación")
                Return True
            End If
            If Me.TxtNombreFiador2.Text <> Nothing And Me.TxtNombreFiador.Text = Nothing Then
                MsgBox("¡Si Desea ingresar un segundo Fiador tiene que ingresar un primero !", MsgBoxStyle.Information, "Validación")
                Return True
            End If
            If CDbl(Trim(Me.TxtCantidad.Text)) > CDbl(TxtHastaSin.Text) Then
                If Me.TxtNombreFiador.Text.Length = 0 And Not Me.ChxAutorizacionExp.Checked Then
                    If Bloqueado Then
                        MsgBox("La cantidad solicitada es mayor a la autorizada.", MsgBoxStyle.OkOnly, "Validación")
                        Return True
                    Else
                        If MsgBox("La cantidad solicitada es mayor a la permitida sin fiador." & vbCrLf & vbCrLf & "¿Desea hacer una excepción para esta solicitud?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                            Me.ChxAutorizacionExp.Checked = True
                        Else
                            Me.TxtCantidad.Focus()
                            Return True
                        End If
                    End If
                End If
            End If
            If (Me.TxtNombreFiador.Text <> Nothing Or Me.TxtNombreFiador2.Text <> Nothing Or Me.TxtNombreFiador3.Text <> Nothing) And Not Me.ChxAutorizacionExp.Checked Then
                If CDbl(Trim(Me.TxtCantidad.Text)) > CDbl(LblTHastaCon.Text) Then
                    If MsgBox("La cantidad solicitada es mayor a la permitida con fiador." & vbCrLf & vbCrLf & "¿Desea hacer una excepción para esta solicitud?", MsgBoxStyle.YesNo, "Validación") Then
                        Me.ChxAutorizacionExp.Checked = True
                    Else
                        Me.TxtCantidad.Focus()
                        Return True
                    End If
                End If
            End If
            If TxtCodigoAsFi.Text <> Nothing Then
                If TxtCodigoAsFi.Text = TxtCodigoAsFi2.Text And TxtCodigoBuFi.Text = TxtCodigoBuFi2.Text Then
                    MsgBox("¡Fiador Uno no puede ser fiador Dos!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
                If TxtCodigoAsFi.Text = TxtCodigoAsFi3.Text And TxtCodigoBuFi.Text = TxtCodigoBuFi3.Text Then
                    MsgBox("¡Fiador Uno no puede ser fiador Tres!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
            End If
            If TxtCodigoAsFi2.Text <> Nothing Then
                If TxtCodigoAsFi2.Text = TxtCodigoAsFi.Text And TxtCodigoBuFi2.Text = TxtCodigoBuFi.Text Then
                    MsgBox("¡Fiador Dos no puede ser fiador Uno!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
                If TxtCodigoAsFi2.Text = TxtCodigoAsFi3.Text And TxtCodigoBuFi2.Text = TxtCodigoBuFi3.Text Then
                    MsgBox("¡Fiador Dos no puede ser fiador Tres!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
            End If
            If TxtCodigoAsFi3.Text <> Nothing Then
                If TxtCodigoAsFi3.Text = TxtCodigoAsFi2.Text And TxtCodigoBuFi3.Text = TxtCodigoBuFi2.Text Then
                    MsgBox("¡Fiador Tres no puede ser fiador Dos!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
                If TxtCodigoAsFi3.Text = TxtCodigoAsFi.Text And TxtCodigoBuFi3.Text = TxtCodigoBuFi.Text Then
                    MsgBox("¡Fiador Tres no puede ser fiador Uno!", MsgBoxStyle.Information, "Validación")
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Sub BtnBuscarSocFi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocioFiador()
            DisponibleSocioFi()
            Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores)
        End If
    End Sub

    Private Sub BtnBuscarSol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        ParamcodSolicitud = Nothing
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSol As New FrmBuscarSolicitudesPrestamo
        FrmBuscarSol.origenes = Permitir
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
            Limpiar_Objetos()
            'Hoja de datos
            'socio_hojadatos.TopMost = False
            'socio_hojadatos.TopLevel = False
            'socio_hojadatos.Parent = Me.TbpHojaDatos
            'socio_hojadatos.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'socio_hojadatos.Show()
            'socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
            'socio_hojadatos.TxtCodAS.Text = ParamcodigoAs
            'socio_hojadatos.TxtCodBuxy.Text = ParamcodigoBux
            'socio_hojadatos.BusquedaDatosSocios(Permitir)
            'socio_hojadatos.GrpDatosSocios.Visible = False
            'socio_hojadatos.TabControl1.Location = New System.Drawing.Point(1, 3)
            'socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)
            '***************
            MuestraSolicitud()
            Determinardisponible()
            Indemnizacion()
            DetalleSocioFiador()
            DetalleSocioFiador2()
            DetalleSocioFiador3()
            If Trim(Me.TxtCodigoAsFi.Text) <> Nothing And Trim(Me.TxtCodigoBuFi.Text) <> Nothing Then
                MuestraDisponibleSocioFi()
                Muestra_Fiadores(Me.TxtCodigoBuFi.Text, Me.DgvFiadores)
            Else
                Me.LblDisponibleFi.Text = 0
            End If

            If Trim(Me.TxtCodigoAsFi2.Text) <> Nothing And Trim(Me.TxtCodigoBuFi2.Text) <> Nothing Then
                MuestraDisponibleSocioFi2()
                Muestra_Fiadores2()
            Else
                Me.LblDisponibleFi2.Text = 0
            End If

            If Trim(Me.TxtCodigoAsFi3.Text) <> Nothing And Trim(Me.TxtCodigoBuFi3.Text) <> Nothing Then
                MuestraDisponibleSocioFi3()
                Muestra_Fiadores3()
            Else
                Me.LblDisponibleFi3.Text = 0
            End If
            ''''''''''''''''
            ''''''''''''''''''''
            If Me.TxtRevisado.Text = Nothing Then
                Me.CheckBox1.Checked = False
            Else
                Me.CheckBox1.Checked = True
            End If
            If SolicitudesNoModificables() = True Then
                If TxtRecibido.Text.Trim <> "" And Me.TxtRevisado.Text.Trim <> "" Then
                    Me.BtnGuardar.Enabled = False
                    MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
                Else
                    MsgBox("Faltó definir el Revisado o Recibido", MsgBoxStyle.Exclamation, "AVISO")
                End If
            Else
                Me.BtnGuardar.Enabled = True
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        Dim cadena As String = TxtCantidad.Text
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Trim(Me.TxtRecibido.Text) = Nothing Then
            MsgBox("Favor ingrese la persona que recibió solicitud", MsgBoxStyle.Critical, "Validación")
            Me.TxtRecibido.Focus()
            Return
        End If
        If Trim(Me.TxtCodigoAs.Text) = Nothing And Trim(Me.TxtCodigoBuxis.Text) = Nothing Then
            MsgBox("Favor ingrese datos del Socio válidos.", MsgBoxStyle.Critical, "Validación")
            Me.BtnBuscarSoc.Focus()
            Return
        End If
        If Val(Me.TxtCantidad.Text) <= 0 Then
            MsgBox("Favor ingrese un Monto válido", MsgBoxStyle.Critical, "Validación")
            Me.TxtCantidad.Clear()
            Me.TxtCantidad.Focus()
            Return
        End If
        If Trim(Me.TxtRazon.Text) = Nothing Then
            MsgBox("Favor ingrese Motivo de solicitud", MsgBoxStyle.Critical, "Validación")
            Me.TxtRazon.Focus()
            Return
        End If
        If Me.TxtCodigoAs.Text = Me.TxtCodigoAsFi.Text And Me.TxtCodigoBuxis.Text = Me.TxtCodigoBuFi.Text Then
            MessageBox.Show("El Socio Fiador no puede ser el mismo que el socio solicitante", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.BtnBuscarSocFi.Focus()
            Return
        End If
        If Me.TxtCodigoAs.Text = Me.TxtCodigoAsFi2.Text And Me.TxtCodigoBuxis.Text = Me.TxtCodigoBuFi2.Text Then
            MessageBox.Show("El Socio Fiador no puede ser el mismo que el socio solicitante", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.BtnBuscarSocFi2.Focus()
            Return
        End If
        If Me.TxtCodigoAs.Text = Me.TxtCodigoAsFi3.Text And Me.TxtCodigoBuxis.Text = Me.TxtCodigoBuFi3.Text Then
            MessageBox.Show("El Socio Fiador no puede ser el mismo que el socio solicitante", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.BtnBuscarSocFi3.Focus()
            Return
        End If
        If Me.TxtNombreFiador.Text <> Nothing And VerificaDisponibleDeLosFiadores() = True Then
            'MessageBox.Show("El Socio Fiador no cubre la deuda del socio solicitante", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If MsgBox("El Socio Fiador no cubre la deuda del socio solicitante" & vbCrLf & vbCrLf & "¿Desea hacer una excepcion para esta solicitud?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Return
            Else
                ChxAutorizacionExp.Checked = True
            End If
        End If
        If VerificaFiadores() = True Then
            Return
        End If
        '''''''''''''''''''''''''''''''
        If SolicitudesNoModificables() = True Then
            Me.BtnGuardar.Enabled = False
            MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
            Return
        Else
            Me.BtnGuardar.Enabled = True
        End If
        If Trim(Me.TxtNumeroSol.Text) = "" Or Trim(Me.TxtNumeroSol.Text) = 0 Then
            Try
                Numero_Orden()
                Insertar_SolicitudesdePretamosN("I")
                InsertaAutorizaciones()
                If Trim(Me.TxtCodigoBuFi.Text) <> "" And Trim(Me.TxtCodigoAsFi.Text) <> "" Then
                    Muestra_Fiadores(Me.TxtCodigoBuFi.Text, Me.DgvFiadores)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            Try
                Insertar_SolicitudesdePretamosN("U")
                Muestra_Fiadores(Me.TxtCodigoBuFi.Text, Me.DgvFiadores)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub
    Private Sub BuscaPeriodo()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "SELECT CUOTA_INICIAL, CUOTA_FINAL, INTERES, DEDUCCION, MONTO_FINAL, MONTO_MAXIMO, DESCUENTOS_VARIOS_PERIODOS, SOLO_SOCIOS "
            Sql &= "FROM VISTA_COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND SOLICITUD = " & CbxSolicitud.SelectedValue
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read Then
                Me.NudPlazo.Minimum = DataReader_Track.Item("CUOTA_INICIAL")
                Me.NudPlazo.Maximum = DataReader_Track.Item("CUOTA_FINAL")
                Me.TxtInteres.Text = DataReader_Track.Item("INTERES")
                LblDeduccion.Text = DataReader_Track.Item("DEDUCCION")
                LimiteSolic = DataReader_Track.Item("MONTO_MAXIMO")
                autorizacionAutomatica = DataReader_Track.Item("DESCUENTOS_VARIOS_PERIODOS")
                SoloSocios = DataReader_Track.Item("SOLO_SOCIOS")
            Else
                Me.NudPlazo.Maximum = 1
            End If
        Catch ex As Exception
            Me.NudPlazo.Maximum = 1
        End Try
        Conexion_Track.Close()
    End Sub
    Private Sub Indemnizacion()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.sp_COOPERATIVA_INDEMNIZACION_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            LblIndemnizacion.Text = 0
            If DataReader_Track.Read = True Then
                LblIndemnizacion.Text = Format(DataReader_Track.Item("INDEMNIZACION"), "0.00")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtRecibido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRecibido.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtRevisado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRevisado.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtRazon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRazon.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtObservaciones_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObservaciones.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        Limpiar_Objetos()
        Limpia_Campos_Fiador2()
        Limpia_Campos_Fiador3()
        socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
        Me.TxtCodigoBuxis.Focus()
    End Sub

    Private Sub NudPlazo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudPlazo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpia_Campos_Fiador()
    End Sub

    Private Sub CbxSolicitud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxSolicitud.SelectedIndexChanged
        BuscaPeriodo()
    End Sub

    Private Sub CbxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxPeriodo.SelectedIndexChanged
        If Iniciando = False Then
            BuscaPeriodo()
        End If
    End Sub

    Private Sub BtnBuscarSocFi_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocFi.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocioFiador()
            If Hay_Datos Then
                DisponibleSocioFi()
                Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores)
            End If
        End If
    End Sub

    Private Sub BtnLimpiar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpia_Campos_Fiador()
    End Sub

    Private Sub BtnBuscarSocFi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocFi2.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocioFiador2()
            If Hay_Datos Then
                DisponibleSocioFi2()
                Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores2)
            End If
        End If
    End Sub

    Private Sub BtnBuscarSocFi3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocFi3.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
            BuscaSocioFiador3()
            If Hay_Datos Then
                DisponibleSocioFi3()
                Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores3)
            End If
        End If
    End Sub

    Private Sub BtnLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar2.Click
        Limpia_Campos_Fiador2()
    End Sub

    Private Sub BtnLimpiar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar3.Click
        Limpia_Campos_Fiador3()
    End Sub

    Function CantidadSolicitadadePrestamo() As Double
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim Cantidad As Double = 0.0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Coo.sp_COOPERATIVA_SOLICITUDES_VALOR_PRESTAMO " & Compañia & "," & Val(TxtNumeroSol.Text) & "," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            If DataReader_Track.Read = True Then
                Cantidad = Format(DataReader_Track.Item("CANTIDAD"), "0.00")
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Cantidad
    End Function

    Private Sub TxtCodigoAsFi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAsFi.KeyPress, TxtCodigoBuFi.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtNombreSocio.Text.Length = 0 Then
                MsgBox("Primero debe ingresar el código" & vbCrLf & "del socio solicitante.", MsgBoxStyle.Information, "Aviso")
                Me.TxtCodigo.Focus()
                Return
            End If
            If Me.TxtCodigoAsFi.Text <> Nothing Or Me.TxtCodigoBuFi.Text <> Nothing Then
                Me.TxtCodigoAsFi.Text = Me.TxtCodigoAsFi.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodigoAsFi.Text
                ParamcodigoBux = Val(Me.TxtCodigoBuFi.Text)
                BuscaSocioFiador()
                ParamcodigoAs = Me.TxtCodigoAsFi.Text
                ParamcodigoBux = Val(Me.TxtCodigoBuFi.Text)
                If Hay_Datos Then
                    Hay_Datos = False
                    Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores)
                    DisponibleSocioFi()
                    If Me.DgvFiadores.Rows.Count > 0 Then
                        For i As Integer = 0 To Me.DgvFiadores.Rows.Count - 1
                            If Me.DgvFiadores.Rows(i).Cells(2).Value.ToString() = Me.TxtCodigoBuxis.Text Then
                                Hay_Datos = True
                            End If
                        Next
                        If Not Hay_Datos Then
                            If MsgBox(Me.TxtNombreFiador.Text & " ya es fiador de otro socio".ToUpper() & vbCrLf & vbCrLf & "¿Desea hacer una excepción y continuar?", MsgBoxStyle.YesNo, "Primer Fiador") = MsgBoxResult.No Then
                                Limpia_Campos_Fiador()
                            End If
                        End If
                    End If
                Else
                    Me.TxtCodigoAsFi.Clear()
                    Me.TxtCodigoBuFi.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub TxtCodigoAsFi2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAsFi2.KeyPress, TxtCodigoBuFi2.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoAsFi2.Text <> Nothing Or Me.TxtCodigoBuFi2.Text <> Nothing Then
                If Me.TxtNombreSocio.Text.Length = 0 Then
                    MsgBox("Primero debe ingresar el código" & vbCrLf & "del socio que solicitante.", MsgBoxStyle.Information, "Aviso")
                    Me.TxtCodigo.Focus()
                    Return
                End If
                If Me.TxtCodigoAsFi2.Text <> Nothing Or Me.TxtCodigoBuFi2.Text <> Nothing Then
                    Me.TxtCodigoAsFi2.Text = Me.TxtCodigoAsFi2.Text.PadLeft(6, "0")
                    ParamcodigoAs = Me.TxtCodigoAsFi2.Text
                    ParamcodigoBux = Val(Me.TxtCodigoBuFi2.Text)
                    BuscaSocioFiador2()
                    ParamcodigoAs = Me.TxtCodigoAsFi2.Text
                    ParamcodigoBux = Val(Me.TxtCodigoBuFi2.Text)
                    If Hay_Datos Then
                        Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores2)
                        DisponibleSocioFi2()
                        If Me.DgvFiadores2.Rows.Count > 0 Then
                            For i As Integer = 0 To Me.DgvFiadores2.Rows.Count - 1
                                If Me.DgvFiadores2.Rows(i).Cells(2).Value.ToString() = Me.TxtCodigoBuxis.Text Then
                                    Hay_Datos = True
                                End If
                            Next
                            If Not Hay_Datos Then
                                If MsgBox(Me.TxtNombreFiador2.Text & " ya es fiador de otro socio".ToUpper & vbCrLf & vbCrLf & "¿Desea hacer una excepción y continuar?", MsgBoxStyle.YesNo, "Primer Fiador") = MsgBoxResult.No Then
                                    Me.Limpia_Campos_Fiador2()
                                End If
                            End If
                        End If
                    Else
                        Me.TxtCodigoAsFi2.Clear()
                        Me.TxtCodigoBuFi2.Clear()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtCodigoAsFi3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAsFi3.KeyPress, TxtCodigoBuFi3.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtNombreSocio.Text.Length = 0 Then
                MsgBox("Primero debe ingresar el código" & vbCrLf & "del socio que solicitante.", MsgBoxStyle.Information, "Aviso")
                Me.TxtCodigo.Focus()
                Return
            End If
            If Me.TxtCodigoAsFi3.Text <> Nothing Or Me.TxtCodigoBuFi3.Text <> Nothing Then
                Me.TxtCodigoAsFi3.Text = Me.TxtCodigoAsFi3.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodigoAsFi3.Text
                ParamcodigoBux = Val(Me.TxtCodigoBuFi3.Text)
                BuscaSocioFiador3()
                ParamcodigoAs = Me.TxtCodigoAsFi3.Text
                ParamcodigoBux = Val(Me.TxtCodigoBuFi3.Text)
                If Hay_Datos Then
                    Muestra_Fiadores(ParamcodigoBux, Me.DgvFiadores3)
                    DisponibleSocioFi3()
                    If Me.DgvFiadores3.Rows.Count > 0 Then
                        For i As Integer = 0 To Me.DgvFiadores3.Rows.Count - 1
                            If Me.DgvFiadores3.Rows(i).Cells(2).Value.ToString() = Me.TxtCodigoBuxis.Text Then
                                Hay_Datos = True
                            End If
                        Next
                        If Not Hay_Datos Then
                            If MsgBox(Me.TxtNombreFiador3.Text & " ya es fiador de otro socio".ToUpper & vbCrLf & vbCrLf & "¿Desea hacer una excepción y continuar?", MsgBoxStyle.YesNo, "Primer Fiador") = MsgBoxResult.No Then
                                Me.Limpia_Campos_Fiador3()
                            End If
                        End If
                    End If
                Else
                    Me.TxtCodigoAsFi3.Clear()
                    Me.TxtCodigoBuFi3.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub StyleGrid(ByRef datagrid As DataGridView)
        datagrid.Columns(0).Width = 50 'Compañia
        datagrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        datagrid.Columns(0).Visible = False
        datagrid.Columns(1).Width = 50 'Codigo Empleado
        datagrid.Columns(1).HeaderText = "Código"
        datagrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        datagrid.Columns(2).Width = 200 'Nombre Completo
        datagrid.Columns(2).HeaderText = "Nombre"
        datagrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        datagrid.Columns(3).Width = 70 'No Solicitud
        datagrid.Columns(3).HeaderText = "No.Solic."
        datagrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        datagrid.Columns(4).Width = 150 'Descripcion
        datagrid.Columns(4).HeaderText = "Descripción"
        datagrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        datagrid.Columns(5).Width = 70 'Saldo Actual
        datagrid.Columns(5).HeaderText = "Saldo Actual"
        datagrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        datagrid.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        datagrid.Columns(6).Width = 70 'Total Deudas
        datagrid.Columns(6).HeaderText = "Disponible"
        datagrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        datagrid.Columns(6).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.CheckState = CheckState.Checked Then
            Me.TxtRevisado.Text = Usuario
        Else
            Me.TxtRevisado.Text = ""
        End If
    End Sub

    Public Sub Determinardisponible()
        Dim numSocio As String = Me.TxtCodigoAs.Text
        Dim codEmp As String = Me.TxtCodigoBuxis.Text
        Dim disponible, saldoActual As Double
        Dim monto_maximo, montoAdicional As Double
        Dim autorizaciones As DataTable
        Sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & numSocio & "'"
        Bloqueado = jClass.obtenerEscalar(Sql)
        If Bloqueado = True Then
            Sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
            Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
            Sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "     AND A.CODIGO_EMPLEADO = " & codEmp & vbCrLf
            Sql &= "     AND A.SOLICITUD = " & Me.CbxSolicitud.SelectedValue & vbCrLf
            Sql &= "     AND A.EXCEDER_LIMITE = 0" & vbCrLf
            autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
            If autorizaciones.Rows.Count > 0 Then
                monto_maximo = autorizaciones.Rows(0).Item(0)
            Else
                monto_maximo = 0
            End If
            disponible = monto_maximo
            If monto_maximo = 0 Then
                MsgBox("Bloqueado." & vbCrLf & "Solicitar autorización a Gerencia.", MsgBoxStyle.Critical, Me.TxtNombreSocio.Text)
                Me.BtnNueva.PerformClick()
            Else
                Me.TxtHastaSin.Text = Format(disponible, "0.00")
                Me.TxtDesdeCon.Text = "0.01"
                Me.LblTHastaCon.Text = Format(disponible, "0.00")
                Me.TbpFiadores.Enabled = False
            End If
        Else
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS]" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & vbCrLf
            Sql &= ",@SOLICITUD       = " & Me.CbxSolicitud.SelectedValue & vbCrLf
            Sql &= ",@BANDERA         = 1" & vbCrLf
            autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
            If autorizaciones.Rows.Count > 0 Then
                If CDbl(autorizaciones.Rows(0).Item(0)) > 0.0 Then
                    Me.TxtObservaciones.Text = autorizaciones.Rows(0).Item(1).ToString().ToUpper()
                    Me.TxtDesdeSin.Text = "0.01"
                    Me.TxtHastaSin.Text = Format(autorizaciones.Rows(0).Item(0), "0.00")
                    Me.TxtDesdeCon.Text = "0.01"
                    Me.LblTHastaCon.Text = Format(autorizaciones.Rows(0).Item(0), "0.00")
                    BloqueoSelectivo = True
                    Bloqueado = True
                Else
                    MsgBox("Se ha bloqueado este tipo de solicitud para este empleado debido a:" & vbCrLf & vbCrLf & autorizaciones.Rows(0).Item(1).ToString().ToUpper())
                    Me.BtnNueva.PerformClick()
                End If
            Else
                DisponibleSocio()
                If LimiteSolic > 0 Then
                    If Val(Me.LblTHastaCon.Text) < LimiteSolic Then
                        monto_maximo = Val(Me.LblTHastaCon.Text)
                    Else
                        monto_maximo = LimiteSolic
                    End If
                    If monto_maximo > 0 Then
                        Bloqueado = True
                        Sql = "SELECT ISNULL(SUM(CAPITAL), 0.00) AS MONTO" & vbCrLf
                        Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D" & vbCrLf
                        Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA AND S.CORRELATIVO = D.NUMERO_SOLICITUD" & vbCrLf
                        Sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
                        Sql &= "   AND D.CAPITAL_D = 0 AND S.SOLICITUD = " & Me.CbxSolicitud.SelectedValue & vbCrLf
                        Sql &= "   AND S.CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
                        saldoActual = jClass.obtenerEscalar(Sql)
                        Sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                        Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                        Sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                        Sql &= "     AND A.CODIGO_EMPLEADO = " & codEmp & vbCrLf
                        Sql &= "     AND A.SOLICITUD = " & Me.CbxSolicitud.SelectedValue & vbCrLf
                        Sql &= "     AND A.EXCEDER_LIMITE = 1" & vbCrLf
                        autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
                        If autorizaciones.Rows.Count > 0 Then
                            montoAdicional = autorizaciones.Rows(0).Item(0)
                        Else
                            montoAdicional = 0
                        End If
                        disponible = monto_maximo - IIf(Val(Me.LblTHastaCon.Text) < LimiteSolic, 0, saldoActual) + montoAdicional
                        If disponible <= 0 Then
                            MsgBox("EL LIMITE DE CREDITO PARA " & Me.CbxSolicitud.Text & vbCrLf & " ES HASTA POR LA CANTIDAD DE: $ " & Format(monto_maximo, "0.00"), MsgBoxStyle.Critical, "Límite de Consumo Excedido.")
                            Me.BtnNueva.PerformClick()
                            LblTHastaCon.Text = "0.00"
                        Else
                            LblTHastaCon.Text = Format(disponible, "0.00")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Function Resetear_montomaximo(ByVal numSocio, ByVal codemp)
        Dim A As Integer
        Dim sqlCmd As New SqlCommand
        If BloqueoSelectivo Then
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS_IUD]" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & vbCrLf
            Sql &= ",@SOLICITUD       = " & Me.CbxSolicitud.SelectedValue & vbCrLf
            Sql &= ",@LIMITE_APROBADO = " & Val(Me.TxtHastaSin.Text) - Val(Me.TxtCantidad.Text) & vbCrLf
            Sql &= ",@MOTIVO          = '" & Me.TxtObservaciones.Text & "'" & vbCrLf
            Sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ",@MODIFICADO      = 1" & vbCrLf
            Sql &= ",@IUD             = 'I'" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        Else
            Sql = "UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
            Sql &= "   SET [MONTO_MAXIMO] = [MONTO_MAXIMO] - " & Me.TxtCantidad.Text & vbCrLf
            Sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            Sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO = " & codemp & vbCrLf
            Sql &= "   AND SOLICITUD = " & Me.CbxSolicitud.SelectedValue & vbCrLf
            Sql &= "   AND EXCEDER_LIMITE = 0" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        End If
        Return A
    End Function

    Private Sub FrmSolicitudPrestamos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpSolicitud_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpSolicitud.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpFiador1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpFiador1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpFiador2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpFiador2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpFiador3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpFiador3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpHojaDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpHojaDatos.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoBuxis.Text <> Nothing Then
                ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoBux = Me.TxtCodigoBuxis.Text
                BuscaSocio()
                If Hay_Datos = True Then
                    ParamcodigoAs = Me.TxtCodigoAs.Text
                    ParamcodigoBux = Me.TxtCodigoBuxis.Text
                    'Hoja de datos
                    Me.TbpFiadores.Enabled = True
                    'socio_hojadatos.TopMost = False
                    'socio_hojadatos.TopLevel = False
                    'socio_hojadatos.Parent = Me.TbpHojaDatos
                    'socio_hojadatos.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    'socio_hojadatos.Show()
                    'socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
                    'socio_hojadatos.TxtCodAS.Text = ParamcodigoAs
                    'socio_hojadatos.TxtCodBuxy.Text = ParamcodigoBux
                    'socio_hojadatos.BusquedaDatosSocios(Permitir)
                    'socio_hojadatos.GrpDatosSocios.Visible = False
                    'socio_hojadatos.TabControl1.Location = New System.Drawing.Point(1, 3)
                    'socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)
                    '***************
                    Indemnizacion()
                    Determinardisponible()
                    Me.TxtCantidad.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub TxtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.LostFocus
        If LimiteSolic = 0 Then
            If Bloqueado And Val(Me.TxtCantidad.Text) > Val(Me.TxtHastaSin.Text) Then
                MsgBox("El valor máximo autorizado es de $ " & Me.TxtHastaSin.Text, MsgBoxStyle.Information, Me.Text)
                Me.TxtCantidad.Text = Me.TxtHastaSin.Text
            End If
        Else
            If Bloqueado And Val(Me.TxtCantidad.Text) > Val(Me.LblTHastaCon.Text) Then
                MsgBox("El valor máximo autorizado es de $ " & Me.LblTHastaCon.Text, MsgBoxStyle.Information, Me.Text)
                Me.TxtCantidad.Text = Me.LblTHastaCon.Text
            End If
        End If
    End Sub

    Private Function Fiadores(ByVal Bandera As Integer, ByVal codEmp As Integer, ByVal numSol As Integer, ByVal codigoFiador As Integer) As DataTable
        Dim tblResultado As New DataTable
        Sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]" & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO = " & codEmp & vbCrLf
        Sql &= ",@NUMERO_SOLICITUD = " & numSol & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO_FIADOR = " & codigoFiador & vbCrLf
        Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        Sql &= ",@BANDERA = " & Bandera & vbCrLf
        tblResultado = jClass.obtenerDatos(New SqlCommand(Sql), 1)
        Return tblResultado
    End Function
End Class
