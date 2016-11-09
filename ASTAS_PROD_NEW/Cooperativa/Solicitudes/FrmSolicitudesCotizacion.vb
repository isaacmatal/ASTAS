Imports System.Data
Imports System.Data.SqlClient
Public Class FrmSolicitudesCotizacion
    Dim Sql As String
    Dim Con_IVA As Boolean
    Dim Iniciando, Bloqueado, SoloSocios As Boolean
    Dim Permitir As String
    Dim jclass As New jarsClass
    Dim autorizacionAutomatica As Boolean
    Dim linea, lineabd As Integer

    Private Sub FrmSolicitudesCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label26.Text = "Pre./Unit Con IVA"
        Me.ChkEs_Factura.Checked = True
        CargaSolicitudes(Compañia)
        ParamSolicitud(Compañia, CbxSolicitudes.SelectedValue)
        Muestra_Detalle()
        Me.CbxPeriodo.SelectedIndex = 0
        Iniciando = False
        DpFechaSol.Value = Now()
        Try
            Permitir = jclass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub CargaSolicitudes(ByVal compañia)
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_COTIZACION " & compañia
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            CbxSolicitudes.DataSource = Table
            CbxSolicitudes.ValueMember = "SOLICITUD"
            CbxSolicitudes.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxSolicitudes.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Indemnizacion()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_INDEMNIZACION_DEL_SOCIO '" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            LblIndemnizacion.Text = "0.00"
            If Table.Rows.Count > 0 Then
                LblIndemnizacion.Text = Format(Table.Rows(0).Item("INDEMNIZACION"), "0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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
            DataAdapter.SelectCommand.Parameters.Add("@AUTORIZACION1", SqlDbType.Bit).Value = autorizacionAutomatica
            DataAdapter.SelectCommand.Parameters.Add("@COMENTARIO1", SqlDbType.NVarChar).Value = "CREDITO OTORGADO"
            DataAdapter.SelectCommand.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Now
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
            DataAdapter.SelectCommand.Parameters.Add("@CODIGO_AS", SqlDbType.VarChar).Value = Val(TxtCodigoAs.Text)
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

    Private Sub Limpiar_Objetos()
        Me.TxtCodigoAs.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtNombre.Text = Nothing
        Me.TxtDepartamento.Text = Nothing
        Me.TxtDivision.Text = Nothing
        Me.TxtProveedor.Text = Nothing
        Me.TxtNumCotizacion.Text = Nothing
        Me.TxtTotalCotizacion.Text = 0
        Me.TxtSubTotalCotizacion.Text = 0
        Me.TxtIVACotizacion.Text = 0
        Me.LblDisponible.Text = 0
        Me.LblIndemnizacion.Text = 0
        Me.ChxAutorizacionExp.Checked = Nothing
        Me.NudPlazo.Value = 1
        Me.TxtNumeroSol.Text = 0
        Me.TxtInteres.Text = 0.0
        Me.DgCotizacion.DataSource = Nothing
        Me.BtnAgregar.Enabled = True
        Me.BtnEliminar.Enabled = True
        Me.ChkEs_Factura.Checked = True
        Me.txtAguin.Text = "0.00"
        Me.txtBonif.Text = "0.00"
        Me.btnNvoDetalle.PerformClick()
        While Me.dgvFiadores.Rows.Count > 0
            Me.dgvFiadores.Rows.RemoveAt(0)
        End While
        lineabd = 0
    End Sub

    Private Sub BuscaSocio()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'," & Compañia
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Origen = jclass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a procesar este código", MsgBoxStyle.Information, Table.Rows(0).Item(1) & " - " & Table.Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                'If jclass.SocioBloqueado(Table.Rows(0).Item(1)) Then
                '    Me.TxtCodigoAs.Clear()
                '    Me.TxtCodigoBuxis.Clear()
                '    Hay_Datos = False
                '    Return
                'End If
                TxtCodigoAs.Text = Table.Rows(0).Item(0)
                TxtCodigoBuxis.Text = Table.Rows(0).Item(1)
                TxtNombre.Text = Table.Rows(0).Item(2)
                TxtDepartamento.Text = Table.Rows(0).Item(3)
                TxtDivision.Text = Table.Rows(0).Item(4)
                If Table.Rows(0).Item("ESTATUS") = 0 Then
                    MsgBox("¡Empleado esta INACTIVO!", MsgBoxStyle.Exclamation, "AVISO")
                    Limpiar_Objetos()
                    Hay_Datos = False
                Else
                    If SoloSocios Then
                        If Table.Rows(0).Item("ESTATUS") = 2 Then
                            Hay_Datos = True
                        Else
                            MsgBox("El Tipo de solicitud solo aplica a Socios", MsgBoxStyle.Information, Table.Rows(0).Item(1) & " - " & Table.Rows(0).Item(2))
                            Limpiar_Objetos()
                            Hay_Datos = False
                        End If
                    Else
                        Hay_Datos = True
                    End If
                End If
            Else
                MsgBox("No existe código de socio!", MsgBoxStyle.Exclamation, "AVISO")
                Limpiar_Objetos()
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function SolicitudesNoModificables() As Boolean
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim bandera As Boolean
        If jclass.obtenerEscalar("SELECT PROGRAMADA FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & TxtNumeroSol.Text) Then
            Return True
        End If
        If autorizacionAutomatica Then
            If Val(lblOC.Text) > 0 Then
                Return True
            Else
                Return False
            End If
        End If
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_NO_MODIFICABLES " & Compañia & "," & TxtNumeroSol.Text
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                bandera = True
            Else
                bandera = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bandera
    End Function

    Private Sub ParamSolicitud(ByVal Compañia, ByVal Solicitud)
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "SELECT CUOTA_INICIAL, CUOTA_FINAL, INTERES, DEDUCCION, MONTO_FINAL, MONTO_MAXIMO, DESCUENTOS_VARIOS_PERIODOS, CON_IVA, SOLO_SOCIOS "
            Sql &= "FROM VISTA_COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND SOLICITUD = " & Solicitud
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.NudPlazo.Minimum = Table.Rows(0).Item("CUOTA_INICIAL")
                Me.NudPlazo.Maximum = Table.Rows(0).Item("CUOTA_FINAL")
                Me.NudPlazo.Value = Table.Rows(0).Item("CUOTA_FINAL")
                Me.TxtInteres.Text = Format(Table.Rows(0).Item("INTERES"), "0.00")
                Me.LblDeduccion.Text = Format(Table.Rows(0).Item("DEDUCCION"), "0.00")
                Me.LblMontoMax.Text = Format(Table.Rows(0).Item("MONTO_MAXIMO"), "0.00")
                autorizacionAutomatica = Table.Rows(0).Item("DESCUENTOS_VARIOS_PERIODOS")
                SoloSocios = Table.Rows(0).Item("SOLO_SOCIOS")
                Con_IVA = Table.Rows(0).Item("CON_IVA")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DisponibleSocio()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim AhorroOrdi, AhorroExtOrdi, ptmos As Double
        Dim Deducciones As Double
        Dim DeudaPagada As Double
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO'" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            AhorroOrdi = 0
            Deducciones = 0
            DeudaPagada = 0
            If Table.Rows.Count > 0 Then
                AhorroOrdi = Table.Rows(0).Item("AHORRO ORDINARIO")
                AhorroExtOrdi = Table.Rows(0).Item("AHORRO EXTRAORDINARIO")
                Deducciones = Table.Rows(0).Item("MONTO POR SALDAR")
                DeudaPagada = Table.Rows(0).Item("MONTO DESCONTADO EN SOLICITUDES")
                If Origen = 5 Or Origen = 6 Then
                    Sql = "SELECT ISNULL(SUM(D.CAPITAL),0.00) AS CAPITAL"
                    Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D"
                    Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA"
                    Sql &= "   AND S.CORRELATIVO = D.NUMERO_SOLICITUD"
                    Sql &= "   AND S.CODIGO_BUXIS = " & Trim(ParamcodigoBux)
                    Sql &= "   AND D.CAPITAL_D = 0"
                    Sql &= "   AND S.COMPAÑIA = " & Compañia
                    Sql &= "   AND S.DEDUCCION = " & CInt(jclass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")).ToString()
                    ptmos = jclass.obtenerEscalar(Sql)
                    LblDisponible.Text = Format(((1.75 * (AhorroOrdi + AhorroExtOrdi))) - ptmos, "0.00")
                Else
                    LblDisponible.Text = Format(((2 * AhorroOrdi) - Deducciones), "0.00")
                End If
                If LblDisponible.Text < 0 Then
                    LblDisponible.Text = "0.00"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function Numero_Orden() As Boolean
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS"
            Sql &= " @COMPAÑIA = " & Compañia & ","
            Sql &= " @TIPO_DOCUMENTO = 'SOL',"
            Sql &= " @ULTIMO = 0"
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                TxtNumeroSol.Text = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Function Guardar_Solicitudes() As Boolean
        If Trim(Me.TxtCodigoAs.Text) = Nothing And Trim(Me.TxtCodigoBuxis.Text) = Nothing Then
            MsgBox("Favor ingrese datos del Socio válidos.", MsgBoxStyle.Critical, "Validación")
            Me.TxtCodigoAs.Focus()
            Return False
        End If
        If Trim(Me.TxtProveedor.Text) = Nothing Then
            MsgBox("Favor seleccione un Proveedor válido", MsgBoxStyle.Critical, "Validación")
            Me.BtnBuscarProv.PerformClick()
            Return False
        End If
        If CDbl(Val(Me.TxtTotalCotizacion.Text)) > CDbl(Val(Me.LblDisponible.Text)) And Not Me.ChxAutorizacionExp.Checked Then
            If Bloqueado Then
                MsgBox("¡No se puede guardar la Solicitud! Valor del Vale es mayor al disponible el cual es $ " & CStr(CDbl(Me.LblDisponible.Text)), MsgBoxStyle.OkOnly, "Validación")
                Return False
            Else
                If MessageBox.Show("Cotización es por $ " & Me.TxtTotalCotizacion.Text & vbCrLf & "Mayor al disponible del socio" & vbCrLf & vbCrLf & "¿Desea agregar una excepción?", "RESTRICCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes Then
                    Me.ChxAutorizacionExp.Checked = True
                Else
                    Return False
                End If
            End If
        End If
        'If CDbl(Val(Me.TxtTotalCotizacion.Text)) > CDbl(Me.LblMontoMax.Text) And Not Me.ChxAutorizacionExp.Checked Then
        '    If Bloqueado Then
        '        MsgBox("¡No se puede guardar la Solicitud! Valor del Vale es mayor al disponible el cual es $ " & CStr(CDbl(Me.LblDisponible.Text)), MsgBoxStyle.OkOnly, "Validación")
        '        Return False
        '    Else
        '        If MsgBox("Cotización es por $ " & Me.TxtTotalCotizacion.Text & vbCrLf & "Monto excede del monto máximo a otorgar" & vbCrLf & vbCrLf & "¿Desea hacer una excepción para esta solicitud?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
        '            Me.ChxAutorizacionExp.Checked = True
        '        Else
        '            Return False
        '        End If
        '    End If
        'End If
        If Val(Me.TxtNumeroSol.Text) = 0 Then
            If Not Numero_Orden() Then
                Return False
            End If
        End If
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_IU" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & "," & vbCrLf
            Sql &= " @DEDUCCION = " & CInt(Me.LblDeduccion.Text) & "," & vbcrlf
            Sql &= " @CORRELATIVO = " & Me.TxtNumeroSol.Text & "," & vbCrLf
            Sql &= " @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'," & vbCrLf
            Sql &= " @CODIGO_BUXIS = " & CInt(Me.TxtCodigoBuxis.Text) & "," & vbCrLf
            Sql &= " @PROVEEDOR = '" & ParamCodProvee & "'," & vbCrLf
            Sql &= " @FECHA_SOLICITUD = '" & Format(Me.DpFechaSol.Value, "dd-MM-yyyy HH:mm:ss") & "'," & vbCrLf
            Sql &= " @AUTORIZACION_EX = " & IIf(ChxAutorizacionExp.Checked = True, "1", "0") & "," & vbCrLf
            Sql &= " @VALOR_VALE = " & Val(Me.TxtTotalCotizacion.Text) & "," & vbCrLf
            Sql &= " @INTERES = " & Val(TxtInteres.Text) & "," & vbCrLf
            Sql &= " @PERIODO = '" & StrDup(2, CbxPeriodo.Text.Substring(0, 1)) & "'," & vbCrLf
            Sql &= " @PLAZO = " & NudPlazo.Value & "," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbcrlf
            Sql &= " @ES_FACTURA = " & IIf(ChkEs_Factura.Checked = True, "1", "0") & "," & vbCrLf
            Sql &= " @BONIFICACION = " & Val(Me.txtBonif.Text) & "," & vbCrLf
            Sql &= " @AGUINALDO = "& Val(Me.txtAguin.Text)
            jclass.Ejecutar_ConsultaSQL(Sql)
            If esPrestamo(Me.CbxSolicitudes.SelectedValue) Then
                Sql = "EXECUTE Coo.sp_COOPERATIVA_SOLICITUDES_PRESTAMOS_IU"
                Sql &= " @COMPAÑIA = " & Compañia & ","
                Sql &= " @SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & ","
                Sql &= " @DEDUCCION = " & CInt(Me.LblDeduccion.Text) & ","
                Sql &= " @CORRELATIVO = " & Me.TxtNumeroSol.Text & ","
                Sql &= " @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "',"
                Sql &= " @CODIGO_BUXIS = " & CInt(Me.TxtCodigoBuxis.Text) & ","
                Sql &= " @FECHA_SOLICITUD = '" & Format(Me.DpFechaSol.Value, "dd-MM-yyyy HH:mm:ss") & "',"
                Sql &= " @RECIBIDO = '" & Usuario & "',"
                Sql &= " @REVISADO = '',"
                Sql &= " @AUTORIZACION_EX = " & IIf(ChxAutorizacionExp.Checked = True, "1", "0") & ","
                Sql &= " @CANTIDAD = " & Val(Me.TxtTotalCotizacion.Text) & ","
                Sql &= " @RAZON = '',"
                Sql &= " @INTERES = " & Val(TxtInteres.Text) & ","
                Sql &= " @PERIODO = '" & StrDup(2, CbxPeriodo.Text.Substring(0, 1)) & "',"
                Sql &= " @PLAZO = " & NudPlazo.Value & ","
                Sql &= " @USUARIO = '" & Usuario & "'"
                jclass.Ejecutar_ConsultaSQL(Sql)
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS SET PAGADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.TxtNumeroSol.Text
                jclass.Ejecutar_ConsultaSQL(Sql)
            End If
            Resetear_montomaximo("", Me.TxtCodigoBuxis.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Function Insertar_Cotizacion(ByVal Cantidad As Double, ByVal Desc As String, ByVal precUnit As Double, ByVal Linea As Integer, ByVal Accion As String) As Integer
        Dim sqlCmd As New SqlCommand
        Try
            Sql = "EXECUTE sp_COOPERATIVA_SOLICITUDES_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & ", " & vbCrLf
            Sql &= " @CORRELATIVO = " & Me.TxtNumeroSol.Text & "," & vbCrLf
            Sql &= " @LINEA = " & Linea & "," & vbCrLf
            Sql &= " @NUM_COTIZACION = '" & Trim(Me.TxtNumCotizacion.Text) & "'," & vbCrLf
            Sql &= " @CANTIDAD = " & Cantidad & "," & vbCrLf
            Sql &= " @DESCRIPCION = '" & Desc & "'," & vbCrLf
            Sql &= " @PRECIO_UNITARIO = " & precUnit & "," & vbCrLf
            Sql &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Sql &= " @IUD = '" & Accion & "'," & vbCrLf
            Sql &= " @FECHA = '" & Format(Me.DtpFechaCotiza.Value, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            Return jclass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
        Return 0
    End Function

    Private Sub MuestraSolicitud()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Iniciando = True
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES " & Compañia _
                    & "," & ParamcodSolicitud & "," & 0 & "," & 0 & ",'" & Nothing & "'," & 1 & "," & Cotizacion
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.TxtNumeroSol.Text = Table.Rows(0).Item("CORRELATIVO")
                Me.CbxSolicitudes.SelectedValue = Table.Rows(0).Item("SOLICITUD")
                ParamSolicitud(Compañia, Table.Rows(0).Item("SOLICITUD"))
                Me.TxtCodigoAs.Text = Table.Rows(0).Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
                Me.TxtNombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.TxtDepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                Me.TxtDivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                ParamCodProvee = Table.Rows(0).Item("PROVEEDOR")
                Me.TxtProveedor.Text = Table.Rows(0).Item("NOMBRE_PROVEEDOR")
                Me.DpFechaSol.Value = Table.Rows(0).Item("FECHA_SOLICITUD")
                Me.NudPlazo.Value = Table.Rows(0).Item("PLAZO")
                If Table.Rows(0).Item("PERIODO") = "QQ" Then
                    Me.CbxPeriodo.SelectedIndex = 0
                Else
                    Me.CbxPeriodo.SelectedIndex = 1
                End If
                Me.ChxAutorizacionExp.Checked = Table.Rows(0).Item("AUTORIZACION_EX")
                Me.txtBonif.Text = Table.Rows(0).Item("DESCUENTO_BONIFICACION")
                Me.txtAguin.Text = Table.Rows(0).Item("DESCUENTO_AGUINALDO")
                If Table.Rows(0).Item("ES_FACTURA") = False Then
                    Me.ChkEs_Factura.Checked = False
                    Me.Label26.Text = "Pre./Unit Sin IVA"
                Else
                    Me.ChkEs_Factura.Checked = True
                    Me.Label26.Text = "Pre./Unit Con IVA"
                End If
                Me.lblOC.Text = jclass.obtenerEscalar("SELECT ORDEN_DE_COMPRA FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.TxtNumeroSol.Text)
                Dim autorizada As Boolean = jclass.obtenerEscalar("SELECT AUTORIZACION1 FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.TxtNumeroSol.Text)
                If Val(Me.lblOC.Text) > 0 Then
                    Me.btnGenerarOC.Text = "Imprimir Orden Compra"
                    Me.btnGenerarOC.Enabled = True
                    Me.btnGuardar.Enabled = False
                    Me.BtnAgregar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                Else
                    Me.btnGenerarOC.Text = "Generar Orden Compra"
                    If autorizada Then
                        Me.btnGenerarOC.Enabled = True
                        If Not autorizacionAutomatica Then
                            Me.btnGuardar.Enabled = False
                            Me.BtnAgregar.Enabled = False
                            Me.BtnEliminar.Enabled = False
                        Else
                            Me.btnGuardar.Enabled = True
                            Me.BtnAgregar.Enabled = True
                            Me.BtnEliminar.Enabled = True
                        End If
                    Else
                        'Me.btnGenerarOC.Enabled = False
                    End If
                End If
            End If
            Iniciando = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Muestra_Detalle()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Iniciando = True
            While Me.DgCotizacion.Rows.Count > 0
                Me.DgCotizacion.Rows.RemoveAt(0)
            End While
            lineabd = 0
            Sql = "Execute Coo.Sp_COOPERATIVA_SOLICITUDES_DETALLE " & Compañia & ",'" & TxtNumeroSol.Text & "'"
            Comando_Track.CommandText = Sql
            Table = jclass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.TxtNumCotizacion.Text = Table.Rows(0).Item(7)
                Me.DtpFechaCotiza.Value = Table.Rows(0).Item(8)
            End If
            For i As Integer = 0 To Table.Rows.Count - 1
                Me.DgCotizacion.Rows.Add(Table.Rows(i).Item(3), Table.Rows(i).Item(4), Table.Rows(i).Item(5), Table.Rows(i).Item(6), Table.Rows(i).Item(2), False, False)
                lineabd = Table.Rows(i).Item(2)
            Next
            Iniciando = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Total_Detalle()
        Dim TotalCotizacion As Double = 0.0
        Try
            For Each row As DataGridViewRow In DgCotizacion.Rows
                TotalCotizacion += row.Cells(3).Value
            Next
            TxtSubTotalCotizacion.Text = Format(TotalCotizacion, "0.00")
            If Con_IVA = True Then
                If Me.ChkEs_Factura.Checked = False Then
                    TxtIVACotizacion.Text = Format(Math.Round(CDbl(TxtSubTotalCotizacion.Text) * (Por_IVA / 100), 2), "0.00")
                Else
                    TxtIVACotizacion.Text = "0.00"
                End If
                Me.Label7.Visible = Not Me.ChkEs_Factura.Checked
                Me.Label24.Visible = Not Me.ChkEs_Factura.Checked
                Me.Label25.Visible = Not Me.ChkEs_Factura.Checked
                Me.TxtIVACotizacion.Visible = Not Me.ChkEs_Factura.Checked
                Me.TxtTotalCotizacion.Visible = Not Me.ChkEs_Factura.Checked
            Else
                TxtIVACotizacion.Text = "0.00"
            End If

            TxtTotalCotizacion.Text = Format(CDbl(TxtSubTotalCotizacion.Text) + CDbl(TxtIVACotizacion.Text), "0.00")
            If Val(TxtTotalCotizacion.Text) < Val(Me.LblDisponible.Text) Then
                If Val(TxtTotalCotizacion.Text) < Val(Me.LblMontoMax.Text) Then
                    Me.ChxAutorizacionExp.Checked = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiarTexboxSocio()
        Me.TxtNombre.Clear()
        Me.TxtDepartamento.Clear()
        Me.TxtDivision.Clear()
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocio.Click
        StadoBusqueda = 2
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoAs <> Nothing And ParamcodigoBux <> Nothing Then
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
            BuscaSocio()
            Determinardisponible()
            Indemnizacion()
        End If
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Try
            If DgCotizacion.RowCount = 0 Then
                MessageBox.Show("Debe seleccionar una cotizacion", "REQUERIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If SolicitudesNoModificables() = True Then
                    Me.BtnAgregar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                    MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
                    Return
                Else
                    Me.BtnAgregar.Enabled = True
                    Me.BtnEliminar.Enabled = True
                End If
                If Me.DgCotizacion.CurrentRow.Cells(4).Value > 0 Then
                    Insertar_Cotizacion(0, "", 0, Me.DgCotizacion.CurrentRow.Cells(4).Value, "D")
                    linea = 0
                End If
                Muestra_Detalle()
                Total_Detalle()
            End If
            btnNvoDetalle.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Agregar_Detalle()
        For Each row As DataGridViewRow In Me.DgCotizacion.Rows
            If row.Cells("nueva").Value Then
                Insertar_Cotizacion(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, "I")
            ElseIf row.Cells("modificada").Value Then
                Insertar_Cotizacion(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, "U")
            End If
        Next
        MsgBox("Solicitud: " + Me.TxtNumeroSol.Text.Trim + " Guardada con éxito", MsgBoxStyle.Information, "Mensaje")
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.TxtDescripcion.Focus()
        End If
    End Sub

    Private Sub TxtValUnitario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValUnitario.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Val(TxtValUnitario.Text) > 0 Then
                Me.BtnAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub TxtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
                e.KeyChar = ""
            End If
            Me.TxtValUnitario.Focus()
        End If
    End Sub

    Private Sub BtnBuscarProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProv.Click
        Dim FrmBuscarProvee As New FrmBuscarProveedor
        FrmBuscarProvee.Compañia_Value = Compañia
        FrmBuscarProvee.CbxCompania.Enabled = False
        FrmBuscarProvee.ShowDialog()
        Me.TxtProveedor.Text = ParamNomProvee
    End Sub

    Private Sub BtnBuscarSol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        Cotizacion = True
        ParamcodSolicitud = Nothing
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSol As New FrmBuscarSolicitudes
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
            'Hoja de datos
            Limpiar_Objetos()
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
            'socio_hojadatos.ClientSize = New System.Drawing.Size(Me.Width, Me.Height)
            '***************
            MuestraSolicitud()
            If SolicitudesNoModificables() Then
                Me.btnGuardar.Enabled = False
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
                MsgBox("¡La Solicitud esta autorizada!" & vbCrLf & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
            Else
                Me.btnGuardar.Enabled = True
                Me.BtnAgregar.Enabled = True
                Me.BtnEliminar.Enabled = True
            End If
            Determinardisponible()
            Indemnizacion()
            Muestra_Detalle()
            Total_Detalle()
            llenar_dgvFiadores(Fiadores(5, Me.TxtCodigoBuxis.Text, Me.TxtNumeroSol.Text, 0))
        End If
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        Limpiar_Objetos()
        DpFechaSol.Value = Now()
        Me.txtMotivoBloqueo.Visible = False
        'socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
        While Me.DgCotizacion.Rows.Count > 0
            Me.DgCotizacion.Rows.RemoveAt(0)
        End While
        Me.TxtCodigoBuxis.Focus()
    End Sub

    Private Sub TxtNumCotizacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumCotizacion.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> Convert.ToChar(Keys.Delete) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoAs.Text <> Nothing Then
                Me.TxtCodigoAs.Text = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodigoAs.Text
                ParamcodigoBux = 0
                BuscaSocio()
                If Hay_Datos Then
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
                    'socio_hojadatos.ClientSize = New System.Drawing.Size(Me.Width, Me.Height)
                    '***************
                    ParamcodigoBux = TxtCodigoBuxis.Text
                    Determinardisponible()
                    Indemnizacion()
                    Me.TxtValSol.Focus()
                End If
            End If
        End If
    End Sub

    Public Sub Determinardisponible()
        Dim numSocio As String = Me.TxtCodigoAs.Text
        Dim codEmp As String = Me.TxtCodigoBuxis.Text
        Dim disponible, montoAdicional As Double
        Dim monto_maximo, saldoActual As Double
        Dim autorizaciones As DataTable
        Sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = '" & codEmp & "'"
        Bloqueado = jClass.obtenerEscalar(Sql)
        If Bloqueado Then
            Sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
            Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
            Sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "     AND A.CODIGO_EMPLEADO = " & codEmp & vbCrLf
            Sql &= "     AND A.SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
            Sql &= "     AND A.EXCEDER_LIMITE = 0" & vbCrLf
            autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
            If autorizaciones.Rows.Count > 0 Then
                monto_maximo = autorizaciones.Rows(0).Item(0)
            Else
                monto_maximo = 0
            End If
            disponible = monto_maximo
            If monto_maximo = 0 Then
                MsgBox("Bloqueado." & vbCrLf & "Solicitar autorización a Gerencia.", MsgBoxStyle.Critical, Me.TxtNombre.Text)
                Me.BtnNueva.PerformClick()
            Else
                LblDisponible.Text = Format(disponible, "0.00")
            End If
        Else
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS]" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & vbCrLf
            Sql &= ",@SOLICITUD       = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
            Sql &= ",@BANDERA         = 1" & vbCrLf
            autorizaciones = jclass.obtenerDatos(New SqlCommand(Sql))
            If autorizaciones.Rows.Count > 0 Then
                If CDbl(autorizaciones.Rows(0).Item(0)) > 0.0 Then
                    Me.txtMotivoBloqueo.Text = autorizaciones.Rows(0).Item(1).ToString().ToUpper()
                    Me.txtMotivoBloqueo.Visible = True
                    Me.LblDisponible.Text = Format(autorizaciones.Rows(0).Item(0), "0.00")
                    Bloqueado = True
                Else
                    MsgBox("Se ha bloqueado este tipo de solicitud para este empleado debido a:" & vbCrLf & vbCrLf & autorizaciones.Rows(0).Item(1).ToString().ToUpper())
                    Me.BtnNueva.PerformClick()
                End If
            Else
                DisponibleSocio()
                If Val(Me.LblMontoMax.Text) > 0 Then
                    If Val(Me.LblDisponible.Text) < Val(Me.LblMontoMax.Text) Then
                        monto_maximo = Val(Me.LblDisponible.Text)
                    Else
                        monto_maximo = Val(Me.LblMontoMax.Text)
                    End If
                    Bloqueado = True
                    Sql = "SELECT ISNULL(SUM(CAPITAL), 0.00) AS MONTO" & vbCrLf
                    Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D" & vbCrLf
                    Sql &= " WHERE S.COMPAÑIA = D.COMPAÑIA AND S.CORRELATIVO = D.NUMERO_SOLICITUD" & vbCrLf
                    Sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND D.CAPITAL_D = 0 AND S.SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
                    Sql &= "   AND S.CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
                    saldoActual = jclass.obtenerEscalar(Sql)
                    Sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                    Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                    Sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "     AND A.CODIGO_EMPLEADO = " & codEmp & vbCrLf
                    Sql &= "     AND A.SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
                    Sql &= "     AND A.EXCEDER_LIMITE = 1" & vbCrLf
                    autorizaciones = jclass.obtenerDatos(New SqlCommand(Sql))
                    If autorizaciones.Rows.Count > 0 Then
                        montoAdicional = autorizaciones.Rows(0).Item(0)
                    Else
                        montoAdicional = 0
                    End If
                    disponible = monto_maximo - IIf(Val(Me.LblDisponible.Text) < Val(Me.LblMontoMax.Text), 0, saldoActual) + montoAdicional
                    If disponible <= 0 Then
                        MsgBox("DISPONIBLE INSUFICIENTE.", MsgBoxStyle.Critical, "Límite de Consumo Excedido.")
                        Me.btnGuardar.Enabled = False
                        LblDisponible.Text = "0.00"
                    Else
                        LblDisponible.Text = Format(disponible, "0.00")
                    End If
                End If
            End If
        End If
    End Sub

    Public Function Resetear_montomaximo(ByVal numSocio, ByVal codemp)
        Dim A As Integer
        Dim sqlCmd As New SqlCommand
        If Me.txtMotivoBloqueo.Visible Then
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS_IUD]" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & vbCrLf
            Sql &= ",@SOLICITUD       = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
            Sql &= ",@LIMITE_APROBADO = " & Val(Me.LblDisponible.Text) - Val(Me.TxtTotalCotizacion.Text) & vbCrLf
            Sql &= ",@MOTIVO          = '" & Me.txtMotivoBloqueo.Text & "'" & vbCrLf
            Sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ",@MODIFICADO      = 1" & vbCrLf
            Sql &= ",@IUD             = 'I'" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jclass.ejecutarComandoSql(sqlCmd)
        Else
            Sql = "UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
            Sql &= "   SET [MONTO_MAXIMO] = [MONTO_MAXIMO] - " & Me.TxtTotalCotizacion.Text & vbCrLf
            Sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            Sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO = " & codemp & vbCrLf
            Sql &= "   AND SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
            Sql &= "   AND EXCEDER_LIMITE = 0" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jclass.ejecutarComandoSql(sqlCmd)
        End If
        Return A
    End Function

    Private Sub chkPreciosIva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEs_Factura.CheckedChanged
        If Me.ChkEs_Factura.Checked = True Then
            Me.Label26.Text = "Pre./Unit Con IVA"
        Else
            Me.Label26.Text = "Pre./Unit Sin IVA"
        End If
        Total_Detalle()
    End Sub

    Private Sub FrmSolicitudesCotizacion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpSolicitud_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpSolicitud.Paint
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        'Agregar_Detalle
        If Me.TxtCantidad.Text = Nothing Then
            MsgBox("¡El Campo cantidad no puede estar Vacío!")
            Me.TxtCantidad.Focus()
            Return
        End If
        If CDbl(Me.TxtCantidad.Text) = 0 Then
            MsgBox("¡Favor ingresar una cantidad mayor que 0!")
            Me.TxtCantidad.Clear()
            Me.TxtCantidad.Focus()
            Return
        End If
        If Trim(Me.TxtDescripcion.Text) = Nothing Then
            MsgBox("El Campo descripción no puede estar Vacío")
            Me.TxtDescripcion.Focus()
            Return
        End If
        If Me.TxtValUnitario.Text = Nothing Then
            MsgBox("El Campo precio unitario no puede estar Vacío")
            Me.TxtValUnitario.Focus()
            Return
        End If
        If linea = 0 Then
            Me.DgCotizacion.Rows.Add(Me.TxtCantidad.Text, Me.TxtDescripcion.Text, Format(Val(Me.TxtValUnitario.Text), "0.00"), Format(Val(Me.TxtValUnitario.Text) * Val(Me.TxtCantidad.Text), "0.00"), "0", True, False)
        Else
            Dim ModRow As DataGridViewRow = Me.DgCotizacion.Rows(linea)
            ModRow.Cells(0).Value = Me.TxtCantidad.Text
            ModRow.Cells(1).Value = Me.TxtDescripcion.Text
            ModRow.Cells(2).Value = Format(Val(Me.TxtValUnitario.Text), "0.00")
            ModRow.Cells(3).Value = Format(Val(Me.TxtValUnitario.Text) * Val(Me.TxtCantidad.Text), "0.00")
            If Not ModRow.Cells("nueva").Value Then
                ModRow.Cells("modificada").Value = True
            End If
        End If
        Total_Detalle()
        btnNvoDetalle.PerformClick()
    End Sub

    Private Sub BtnAgregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BtnAgregar.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'Agregar_Detalle
            BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub btnNvoDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNvoDetalle.Click
        Me.TxtCantidad.Clear()
        Me.TxtDescripcion.Clear()
        Me.TxtValUnitario.Clear()
        Me.TxtCantidad.Focus()
        linea = 0
    End Sub

    Private Sub DgCotizacion_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCotizacion.CellEnter
        If Not Iniciando Then
            linea = e.RowIndex
            Me.TxtCantidad.Text = Me.DgCotizacion.Rows(e.RowIndex).Cells(0).Value
            Me.TxtDescripcion.Text = Me.DgCotizacion.Rows(e.RowIndex).Cells(1).Value
            Me.TxtValUnitario.Text = Me.DgCotizacion.Rows(e.RowIndex).Cells(2).Value
        End If
    End Sub

    Private Sub btnGenerarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarOC.Click
        Dim NuevosModif As Integer
        For Each row As DataGridViewRow In Me.DgCotizacion.Rows
            If row.Cells("nueva").Value Or row.Cells("modificada").Value Then
                NuevosModif += 1
            End If
        Next
        If NuevosModif > 0 Then
            MsgBox("Guarde sus cambios" & vbCrLf & "antes de continuar.", MsgBoxStyle.Critical, "Verificación")
            Return
        End If
        If Not jclass.obtenerEscalar("SELECT AUTORIZACION1 FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.TxtNumeroSol.Text) Then
            MsgBox("Solicitud no ha sido autorizada.", MsgBoxStyle.Critical, "Proceso cancelado")
            Return
        End If
        Dim NumOC As Integer
        If jclass.obtenerEscalar("SELECT PROGRAMADA FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & TxtNumeroSol.Text) Then
            MsgBox("Solicitud ya ha sido programada.", MsgBoxStyle.Critical, "Proceso cancelado")
            Return
        End If
        Dim Rpts As New frmReportes_Ver
        If Val(Me.TxtNumeroSol.Text) > 0 Then
            If Val(Me.lblOC.Text) = 0 Then
                If MsgBox("¿Desea Generar Orden de Compra para esta Solicitud?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
                    Sql = "Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'OC', @ULTIMO = 0"
                    NumOC = jclass.obtenerEscalar(Sql)
                    Mantenimiento_Encabezado(NumOC)
                    Rpts.CargaOC_Directa(Compañia, NumOC)
                    Rpts.ShowDialog()
                    Me.BtnAgregar.Enabled = False
                    Me.btnGuardar.Enabled = False
                    Me.BtnEliminar.Enabled = False
                    btnGenerarOC.Text = "Imprimir Orden Compra"
                End If
            Else
                If MsgBox("¿Desea Imprimir Orden de Compra para esta Solicitud?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
                    Rpts.CargaOC_Directa(Compañia, Val(Me.lblOC.Text))
                    Rpts.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub Mantenimiento_Encabezado(ByVal OrdenCompra As Integer)
        Dim Comando_ As SqlCommand
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD" & vbCrLf
            Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @ORDEN_COMPRA = " & OrdenCompra & vbCrLf
            Sql &= ", @PROCESADA = 1" & vbCrLf
            Sql &= ", @BODEGA = " & jclass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 13 AND COMPAÑIA = " & Compañia).ToString() & vbCrLf
            Sql &= ", @PROVEEDOR = " & ParamCodProvee & vbCrLf
            Sql &= ", @TIPO_CONTRIBUYENTE = " & jclass.obtenerEscalar("SELECT TIPO_PROVEEDOR FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR = " & ParamCodProvee & " AND COMPAÑIA = " & Compañia).ToString() & vbCrLf
            Sql &= ", @PORCENTAJE_PERCEPCION = 0" & vbCrLf
            Sql &= ", @FORMA_PAGO = 2" & vbCrLf
            Sql &= ", @CONDICION_PAGO = 3" & vbCrLf
            Sql &= ", @OBSERVACIONES = 'SOLICITUD DE " & Me.CbxSolicitudes.Text & " No." & Me.TxtNumeroSol.Text & vbCrLf & "PROGRAMAR AL SOCIO: " & Me.TxtCodigoBuxis.Text.Trim & " - " & Me.TxtNombre.Text & "'"
            Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD = 'I'" & vbCrLf
            Sql &= ", @AFECTAR_INVENTARIOS = '0'" & vbCrLf
            Sql &= ", @TIPO_DOCUMENTO = " & IIf(Me.ChkEs_Factura.Checked, "1", "2") & vbCrLf
            Sql &= ", @PORDESC = 0" & vbCrLf
            Sql &= ", @DESCUENTO = 0" & vbCrLf
            Sql &= ", @COMPRA_DIRECTA = 1"
            Comando_ = New SqlCommand(Sql)
            If jclass.ejecutarComandoSql(Comando_) > 0 Then
                Mantenimiento_OCAutorizacion(OrdenCompra)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_OCAutorizacion(ByVal OrdenCompra)
        Dim Comando_ As SqlCommand
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD" & vbCrLf
            Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @ORDEN_COMPRA = " & OrdenCompra & vbCrLf
            Sql &= ", @AUTORIZADA = 0" & vbCrLf
            Sql &= ", @ANULADA = 0" & vbCrLf
            Sql &= ", @SUBTOTAL = " & Me.TxtSubTotalCotizacion.Text & vbCrLf
            Sql &= ", @IVA = " & Me.TxtIVACotizacion.Text & vbCrLf
            Sql &= ", @TOTAL = " & Me.TxtTotalCotizacion.Text & vbCrLf
            Sql &= ", @PERCEPCION = 0" & vbCrLf
            Sql &= ", @TOTAL_FINAL = " & Me.TxtTotalCotizacion.Text & vbCrLf
            Sql &= ", @COMENTARIO =  'SOLICITUD DE " & Me.CbxSolicitudes.Text & " No." & Me.TxtNumeroSol.Text & "'" & vbCrLf
            Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD = 'I'" & vbCrLf
            Sql &= ", @RENTA = 0" & vbCrLf
            Sql &= ", @DESCUENTO = 0"
            Comando_ = New SqlCommand(Sql)
            If jclass.ejecutarComandoSql(Comando_) > 0 Then
                Me.lblOC.Text = OrdenCompra.ToString
                Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION" & vbCrLf
                Sql &= "   SET ORDEN_DE_COMPRA = " & OrdenCompra & vbCrLf
                Sql &= " WHERE N_SOLICITUD = " & Me.TxtNumeroSol.Text & vbCrLf
                Sql &= "   AND COMPAÑIA = " & Compañia
                Comando_.CommandText = Sql
                jclass.ejecutarComandoSql(Comando_)
                Mantenimiento_Detalle(OrdenCompra)
                Sql = "UPDATE [dbo].[CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO]" & vbCrLf
                Sql &= "   SET subtotal = " & Me.TxtSubTotalCotizacion.Text & ", " & vbCrLf
                Sql &= "       iva = " & Me.TxtIVACotizacion.Text & ", " & vbCrLf
                Sql &= "	   total = " & Me.TxtTotalCotizacion.Text & ", " & vbCrLf
                Sql &= "	   percepcion = 0, " & vbCrLf
                Sql &= "	   renta = 0, " & vbCrLf
                Sql &= "	   total_final = " & Me.TxtTotalCotizacion.Text & "," & vbCrLf
                Sql &= "	   USUARIO_CREA_SOLICITA = '" & Usuario & "', " & vbCrLf
                Sql &= "	   FECHA_USUARIO_SOLICITA = GETDATE(), " & vbCrLf
                Sql &= "	   USUARIO_REVISA = '" & Usuario & "', " & vbCrLf
                Sql &= "       FECHA_USUARIO_REVISA = GETDATE()" & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND ORDEN_COMPRA = " & OrdenCompra & vbCrLf
                Comando_.CommandText = Sql
                jclass.ejecutarComandoSql(Comando_)
                Sql = "EXECUTE [Coo].[sp_COOPERATIVA_ORDEN_COMPRA_ENCABEZADO_I]" & vbCrLf
                Sql &= " @COMPAÑIA           = " & Compañia & vbCrLf
                Sql &= ",@ORDEN_COMPRA       = " & OrdenCompra & vbCrLf
                Sql &= ",@FECHA_OC           = '" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ",@PROCESADA          = 1" & vbCrLf
                Sql &= ",@CORRELATIVO        = 0" & vbCrLf
                Sql &= ",@PROVEEDOR          = " & ParamCodProvee & vbCrLf
                Sql &= ",@TIPO_CONTRIBUYENTE = " & jclass.obtenerEscalar("SELECT TIPO_PROVEEDOR FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR = " & ParamCodProvee & " AND COMPAÑIA = " & Compañia).ToString() & vbCrLf
                Sql &= ",@PORCENTAJE_PERCEP  = 0" & vbCrLf
                Sql &= ",@FORMA_PAGO         = 2" & vbCrLf
                Sql &= ",@CONDICION_PAGO     = 3" & vbCrLf
                Sql &= ",@OBSERVACIONES      = 'SOLICITUD DE " & Me.CbxSolicitudes.Text & " No." & Me.TxtNumeroSol.Text & " SOCIO: " & Me.TxtCodigoBuxis.Text.Trim & " - " & Me.TxtNombre.Text & "'"
                Sql &= ",@USUARIO            = '" & Usuario & "'" & vbCrLf
                Comando_.CommandText = Sql
                jclass.ejecutarComandoSql(Comando_)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal OrdenCompra)
        Dim Comando_ As New SqlCommand
        Muestra_Detalle()
        Try
            For Each row As DataGridViewRow In Me.DgCotizacion.Rows
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD" & vbCrLf
                Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
                Sql &= ", @ORDEN_COMPRA = " & OrdenCompra & vbCrLf
                Sql &= ", @LINEA = 0" & vbCrLf
                Sql &= ", @PRODUCTO = 0" & vbCrLf
                Sql &= ", @DESCRIPCION_PRODUCTO = '" & row.Cells(1).Value & "'" & vbCrLf
                Sql &= ", @UNIDAD_MEDIDA = 1" & vbCrLf
                Sql &= ", @CANTIDAD = " & row.Cells(0).Value & vbCrLf
                Sql &= ", @LIBRAS = 0" & vbCrLf
                Sql &= ", @COSTO_UNITARIO = " & row.Cells(2).Value & vbCrLf
                Sql &= ", @SERVICIO = 0" & vbCrLf
                Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
                Sql &= ", @IUD = 'I'" & vbCrLf
                Sql &= ", @BONO = 0"
                Comando_.CommandText = Sql
                jclass.ejecutarComandoSql(Comando_)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Guardar_Solicitudes() Then
            ParamcodSolicitud = Val(Me.TxtNumeroSol.Text)
            InsertaAutorizaciones()
            For i As Integer = 0 To Me.dgvFiadores.Rows.Count - 1
                Fiadores(2, Me.TxtCodigoBuxis.Text, Me.TxtNumeroSol.Text, Me.dgvFiadores.Rows(i).Cells(0).Value)
            Next
            Agregar_Detalle()
            MuestraSolicitud()
            Muestra_Detalle()
            Total_Detalle()
        End If
    End Sub

    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoBuxis.Text <> Nothing Then
                ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoBux = Me.TxtCodigoBuxis.Text
                BuscaSocio()
                If Hay_Datos Then
                    'Hoja de datos
                    ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                    ParamcodigoBux = Me.TxtCodigoBuxis.Text
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
                    'socio_hojadatos.ClientSize = New System.Drawing.Size(Me.Width, Me.Height)
                    '***************
                    ParamcodigoBux = TxtCodigoBuxis.Text
                    Determinardisponible()
                    Indemnizacion()
                    Me.TxtValSol.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CbxSolicitudes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxSolicitudes.SelectedIndexChanged
        If Not Iniciando Then
            ParamSolicitud(Compañia, Me.CbxSolicitudes.SelectedValue)
        End If
    End Sub

    Private Sub txtAguin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAguin.KeyPress, txtBonif.KeyPress, TxtValUnitario.KeyPress
        Dim cadena As String = sender.Text
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

    Private Function esPrestamo(ByVal tipoSoli As Integer) As Boolean
        Return jclass.obtenerEscalar("SELECT ES_PRESTAMO FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & tipoSoli)
    End Function

    Private Sub TxtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.LostFocus
        If Bloqueado And Val(Me.TxtCantidad.Text) > Val(Me.LblDisponible.Text) Then
            MsgBox("El valor máximo autorizado es de $ " & Me.LblDisponible.Text, MsgBoxStyle.Information, Me.Text)
            Me.TxtCantidad.Text = Me.LblDisponible.Text
        End If
    End Sub

    Private Sub txtCodFiador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodFiador.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnFiadores.Focus()
        End If
        jClass.soloNumeros(e)
    End Sub

    Private Sub txtCodFiador_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodFiador.LostFocus
        Dim tblDatos As New DataTable
        If Val(Me.txtCodFiador.Text) > 0 Then
            tblDatos = Fiadores(6, 0, 0, Val(Me.txtCodFiador.Text))
            If tblDatos.Rows.Count > 0 Then
                Me.txtNombreFiador.Text = tblDatos.Rows(0).Item(0)
                Me.txtDeudaFiador.Text = Format(tblDatos.Rows(0).Item(1), "#,##0.00")
            Else
                MsgBox("No existen datos para el codigo: " & Me.txtCodFiador.Text, MsgBoxStyle.Information, Me.Text)
            End If
        End If
    End Sub

    Private Sub btnFiadores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnFiadores.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnFiadores.PerformClick()
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
        tblResultado = jclass.obtenerDatos(New SqlCommand(Sql), 1)
        Return tblResultado
    End Function

    Private Sub btnFiadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiadores.Click
        Dim a As Integer = 0
        For i As Integer = 0 To Me.dgvFiadores.Rows.Count - 1
            If Me.txtCodFiador.Text = Me.dgvFiadores.Rows(i).Cells(0).Value Then
                a = i + 1
            End If
        Next
        If a > 0 Then
            Me.dgvFiadores.Rows.RemoveAt(a - 1)
        End If
        Me.dgvFiadores.Rows.Add(Me.txtCodFiador.Text, Me.txtNombreFiador.Text, Me.txtDeudaFiador.Text, "X")
        Me.txtCodFiador.Clear()
        Me.txtNombreFiador.Clear()
        Me.txtDeudaFiador.Text = "0.00"
        Me.txtCodFiador.Focus()
    End Sub

    Private Sub dgvFiadores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFiadores.CellContentClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 3 Then
                Fiadores(3, Me.TxtCodigoBuxis.Text, Val(Me.TxtNumeroSol.Text), Me.dgvFiadores.Rows(e.RowIndex).Cells(0).Value)
                Me.dgvFiadores.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub llenar_dgvFiadores(ByVal tblFiadores As DataTable)
        While Me.dgvFiadores.Rows.Count > 0
            Me.dgvFiadores.Rows.RemoveAt(0)
        End While
        For Each row As DataRow In tblFiadores.Rows
            Me.dgvFiadores.Rows.Add(row(0), row(1), row(2), "X")
        Next
    End Sub
End Class