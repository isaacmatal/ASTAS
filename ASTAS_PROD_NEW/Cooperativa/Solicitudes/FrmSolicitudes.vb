Imports System.Data
Imports System.Data.SqlClient
Public Class FrmSolicitudes
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim autorizacionAutomatica As Boolean = False
    Dim Bloqueado, SoloSocios As Boolean
    Dim periodoPago As String

    Private Sub FrmSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaSolicitudes(Compañia)
        ParamSolicitud(Compañia, CbxSolicitudes.SelectedValue)
        Iniciando = False
        DpFechaSol.Value = Now()
        Me.CbxPeriodo.Text = "QUINCENAL"
        Me.TbcSolicitudes.DrawMode = TabDrawMode.OwnerDrawFixed
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub CargaSolicitudes(ByVal compañia)
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_SINCOTIZACION " & compañia
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            CbxSolicitudes.ValueMember = "SOLICITUD"
            CbxSolicitudes.DisplayMember = "DESCRIPCION_SOLICITUD"
            CbxSolicitudes.DataSource = Table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function SolicitudesNoModificables() As Boolean
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim bandera As Boolean
        If jClass.obtenerEscalar("SELECT PROGRAMADA FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & TxtNumeroSol.Text) Then
            Return True
        End If
        If autorizacionAutomatica Then
            Return False
        End If
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_NO_MODIFICABLES " & Compañia & "," & TxtNumeroSol.Text
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
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
            Sql = "SELECT CUOTA_INICIAL, CUOTA_FINAL, INTERES, DEDUCCION, MONTO_FINAL, MONTO_MAXIMO, DESCUENTOS_VARIOS_PERIODOS, SOLO_SOCIOS "
            Sql &= "FROM VISTA_COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND SOLICITUD = " & Solicitud
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.NudPlazo.Maximum = Table.Rows(0).Item("CUOTA_FINAL")
                Me.NudPlazo.Value = Table.Rows(0).Item("CUOTA_FINAL")
                Me.lblInteres.Text = Format(Table.Rows(0).Item("INTERES"), "0.00")
                Me.LblDeduccion.Text = Format(Table.Rows(0).Item("DEDUCCION"), "0.00")
                Me.LblMontoMax.Text = Format(Table.Rows(0).Item("MONTO_MAXIMO"), "0.00")
                If Val(Table.Rows(0).Item("MONTO_MAXIMO")) <= 0 Then
                    Me.LblMontoMax.Visible = False
                Else
                    Me.LblMontoMax.Visible = True
                End If
                Me.LblMontoMax.Text = Format(Table.Rows(0).Item("MONTO_MAXIMO"), "0.00")
                autorizacionAutomatica = Table.Rows(0).Item("DESCUENTOS_VARIOS_PERIODOS")
                SoloSocios = Table.Rows(0).Item("SOLO_SOCIOS")
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
        'Dim ds As New DataSet
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
            DataAdapter.SelectCommand.Parameters.Add("@NUMERO_FACTURA", SqlDbType.Int).Value = Val(txtNumVale.Text)
            DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            DataAdapter.SelectCommand.ExecuteNonQuery()
            'DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion_Track.Close()
            DataAdapter.Dispose()
        End Try
    End Sub

    Private Sub BuscaSocio()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "','" & Trim(ParamcodigoBux) & "'" & "," & Compañia
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item(1))
                periodoPago = jClass.obtenerEscalar("SELECT PERIODO_PAGO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item(0) & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item(1))
                If Not Permitir.Contains(Origen.ToString()) Then
                    MsgBox("No esta autorizado a procesar este código", MsgBoxStyle.Information, Table.Rows(0).Item(1) & " - " & Table.Rows(0).Item(0))
                    Hay_Datos = False
                    Return
                End If
                'If jClass.SocioBloqueado(Table.Rows(0).Item(1)) Then
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
                MsgBox("¡Código de socio no existe!", MsgBoxStyle.Exclamation, "AVISO")
                Limpiar_Objetos()
                Hay_Datos = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DisponibleSocio()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Dim AhorroOrdi, AhorroExtOrdi As Double
        Dim Deducciones As Double
        Dim DeudaPagada, ptmos As Double
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO '" & Trim(ParamcodigoAs) & "'," & Trim(ParamcodigoBux) & "," & Compañia & "," & 1
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
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
                    Sql &= "   AND S.DEDUCCION = " & CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")).ToString()
                    ptmos = jClass.obtenerEscalar(Sql)
                    LblDisponible.Text = Format(((1.75 * (AhorroOrdi + AhorroExtOrdi))) - ptmos, "0.00")
                Else
                    LblDisponible.Text = Format(((2 * AhorroOrdi) - Deducciones), "0.00")
                End If
            End If
            If LblDisponible.Text < 0 Then
                LblDisponible.Text = "0.00"
            End If
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
            Table = jClass.obtenerDatos(Comando_Track)
            LblIndemnizacion.Text = "0.00"
            If Table.Rows.Count > 0 Then
                LblIndemnizacion.Text = Format(Table.Rows(0).Item("INDEMNIZACION"), "0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MuestraSolicitud()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES " & Compañia _
                  & "," & ParamcodSolicitud & "," & 0 & "," & 0 & ",'" & Nothing & "'," & 1 & "," & Cotizacion
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.TxtNumeroSol.Text = Table.Rows(0).Item("CORRELATIVO")
                Me.CbxSolicitudes.SelectedValue = Table.Rows(0).Item("SOLICITUD")
                ParamSolicitud(1, Table.Rows(0).Item("SOLICITUD"))
                Me.TxtCodigoAs.Text = Table.Rows(0).Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
                Me.TxtNombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.TxtDepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                Me.TxtDivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                'ParamCodProvee = Table.Rows(0).Item("PROVEEDOR")
                Me.DpFechaSol.Value = Table.Rows(0).Item("FECHA_SOLICITUD")
                Me.NudPlazo.Value = Table.Rows(0).Item("PLAZO")
                If Table.Rows(0).Item("PERIODO") = "QQ" Then
                    Me.CbxPeriodo.SelectedIndex = 0
                Else
                    Me.CbxPeriodo.SelectedIndex = 1
                End If
                Me.TxtValVale.Text = Format(Table.Rows(0).Item("VALOR_VALE"), "0.00")
                Me.CbxPeriodo.SelectedValue = Table.Rows(0).Item("PERIODO")
                Me.ChxAutorizacionExp.Checked = Table.Rows(0).Item("AUTORIZACION_EX")
                Me.txtBonif.Text = Table.Rows(0).Item("DESCUENTO_BONIFICACION")
                Me.txtAguin.Text = Table.Rows(0).Item("DESCUENTO_AGUINALDO")
                Me.txtNumVale.Text = jClass.obtenerEscalar("SELECT NUMERO_FACTURA FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & Me.TxtNumeroSol.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnBuscarSocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocio.Click
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
            'socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)  '(765, 375)
            '***************
            BuscaSocio()
            Determinardisponible()
            Indemnizacion()
            Me.TxtValVale.Text = ""
        End If
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress
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
                    ParamcodigoBux = TxtCodigoBuxis.Text
                    'Hoja de datos
                    socio_hojadatos.TopMost = False
                    socio_hojadatos.TopLevel = False
                    socio_hojadatos.Parent = Me.TbpHojaDatos
                    socio_hojadatos.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    socio_hojadatos.Show()
                    socio_hojadatos.Btn_Socio_limpiar_Click_1(sender, e)
                    socio_hojadatos.TxtCodAS.Text = ParamcodigoAs
                    socio_hojadatos.TxtCodBuxy.Text = ParamcodigoBux
                    socio_hojadatos.BusquedaDatosSocios(Permitir)
                    socio_hojadatos.GrpDatosSocios.Visible = False
                    socio_hojadatos.TabControl1.Location = New System.Drawing.Point(1, 3)
                    socio_hojadatos.ClientSize = New System.Drawing.Size(780, 600)
                    '***************
                    Determinardisponible()
                    Indemnizacion()
                    Me.TxtValVale.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Limpiar_Objetos()
        Me.TxtCodigoAs.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtNombre.Text = Nothing
        Me.TxtDepartamento.Text = Nothing
        Me.TxtDivision.Text = Nothing
        Me.TxtValVale.Text = Nothing
        Me.lblInteres.Text = "0.00"
        Me.ChxAutorizacionExp.Checked = False
        Me.NudPlazo.Text = 1
        Me.TxtNumeroSol.Text = 0
        Me.LblDisponible.Text = "0.00"
        Me.LblIndemnizacion.Text = "0.00"
        Me.txtBonif.Text = "0.00"
        Me.txtAguin.Text = "0.00"
        While Me.dgvFiadores.Rows.Count > 0
            Me.dgvFiadores.Rows.RemoveAt(0)
        End While
        Me.BtnGuardar.Enabled = True
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
            If Me.TxtCodigoBuxis.Text.Length > 0 Then
                ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoBux = Me.TxtCodigoBuxis.Text
                BuscaSocio()
                If Hay_Datos Then
                    'Hoja de datos
                    ParamcodigoAs = Me.TxtCodigoAs.Text
                    ParamcodigoBux = Me.TxtCodigoBuxis.Text
                    Indemnizacion()
                    Determinardisponible()
                    Me.TxtValVale.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        Limpiar_Objetos()
        Me.DpFechaSol.Enabled = True
        Me.TxtCodigoAs.Enabled = True
        Me.NudPlazo.Enabled = True
        Me.TxtValVale.Enabled = True
        Me.BtnBuscarSocio.Enabled = True
        Me.ChxAutorizacionExp.Enabled = True
        Me.txtMotivoBloqueo.Visible = False
        Me.TxtCodigoBuxis.Focus()
    End Sub

    Private Sub Numero_Orden()
        Dim Comando_Track As New SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Exec sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS'" & Compañia & "','SOL','" & 0 & "'"
            Comando_Track.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                TxtNumeroSol.Text = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Insertar_SolicitudesN(ByVal IUD)
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_SOLICITUDES_IU'" & Compañia & "','" _
            & Me.CbxSolicitudes.SelectedValue & "','" & CInt(Me.LblDeduccion.Text) & "','" & Me.TxtNumeroSol.Text & "','" & (Me.TxtCodigoAs.Text) & "','" _
            & CInt(Me.TxtCodigoBuxis.Text) & "','0','" & Format(Me.DpFechaSol.Value, "dd-MM-yyyy HH:mm:ss") & "'," _
            & IIf(ChxAutorizacionExp.Checked = True, "1", "0") & ",'" & TxtValVale.Text & "','" & lblInteres.Text & "','" & StrDup(2, CbxPeriodo.Text.Substring(0, 1)) & "','" & NudPlazo.Value & "','" & Usuario & "'" & ", 1, " & Val(Me.txtBonif.Text) & "," & Val(Me.txtAguin.Text)
            jClass.Ejecutar_ConsultaSQL(Sql)
            Select Case IUD
                Case "I"
                    MsgBox("¡Solicitud No." & Me.TxtNumeroSol.Text & " Guardada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡La solicitud No." & Me.TxtNumeroSol.Text & " ha sido modificada con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
            Resetear_montomaximo("", Me.TxtCodigoBuxis.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Trim(Me.TxtCodigoAs.Text) = Nothing And Trim(Me.TxtCodigoBuxis.Text) = Nothing Then
            MsgBox("¡No se puede guardar la Solicitud! Favor ingrese código del Socio.", MsgBoxStyle.Critical, "Validación")
            Me.BtnBuscarSocio.Focus()
            Return
        End If
        If Val(Me.TxtValVale.Text) = 0 Then
            MsgBox("¡No se puede guardar la Solicitud! Favor ingrese un valor mayor que cero", MsgBoxStyle.Critical, "Validación")
            Me.TxtValVale.Clear()
            Me.TxtValVale.Focus()
            Return
        End If
        'If CDbl(Me.TxtValVale.Text) > CDbl(Me.LblMontoMax.Text) Then
        '    If MsgBox("¡Monto excede del monto máximo a otorgar!" & vbCrLf & vbCrLf & "¿Desea hacer una excepción para esta solicitud?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
        '        Me.ChxAutorizacionExp.Checked = True
        '    Else
        '        Me.TxtValVale.Clear()
        '        Me.TxtValVale.Focus()
        '        Return
        '    End If
        'End If
        If CDbl(Trim(Me.TxtValVale.Text)) > CDbl(LblDisponible.Text) Then
            If Bloqueado Then
                MsgBox("¡No se puede guardar la Solicitud! Valor del Vale es mayor al disponible el cual es $ " & CStr(CDbl(Me.LblDisponible.Text)), MsgBoxStyle.OkOnly, "Validación")
                Return
            Else
                If MsgBox("¡No se puede guardar la Solicitud! Valor del Vale es mayor al disponible el cual es $ " & CStr(CDbl(Me.LblDisponible.Text)) & vbCrLf & vbCrLf & "¿Desea hacer una excepción para esta solicitud?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                    Me.ChxAutorizacionExp.Checked = True
                Else
                    Me.TxtValVale.Clear()
                    Me.TxtValVale.Focus()
                    Return
                End If
            End If
        End If
        If SolicitudesNoModificables() = True Then
            Me.BtnGuardar.Enabled = False
            MsgBox("¡La Solicitud esta en proceso de autorización!" & vbCrLf & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
            Return
        Else
            Me.BtnGuardar.Enabled = True
        End If
        If Me.TxtNumeroSol.Text.Length = 0 Or Val(Me.TxtNumeroSol.Text) = 0 Then
            Try
                Numero_Orden()
                Insertar_SolicitudesN("I")
                InsertaAutorizaciones()
                For i As Integer = 0 To Me.dgvFiadores.Rows.Count - 1
                    Fiadores(2, Me.TxtCodigoBuxis.Text, Me.TxtNumeroSol.Text, Me.dgvFiadores.Rows(i).Cells(0).Value)
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            Try
                If SolicitudesNoModificables() = True Then
                    Me.BtnGuardar.Enabled = False
                    MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
                Else
                    Me.BtnGuardar.Enabled = True
                    Insertar_SolicitudesN("U")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
        Me.BtnNueva.Enabled = True
    End Sub

    Private Sub BtnBuscarSol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        Cotizacion = False
        ParamcodSolicitud = Nothing
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSol As New FrmBuscarSolicitudes
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
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
            If SolicitudesNoModificables() = True Then
                Me.BtnGuardar.Enabled = False
                Me.DpFechaSol.Enabled = False
                Me.TxtCodigoAs.Enabled = False
                Me.NudPlazo.Enabled = False
                Me.TxtValVale.Enabled = False
                Me.BtnBuscarSocio.Enabled = False
                Me.ChxAutorizacionExp.Enabled = False
                MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
            Else
                Me.BtnGuardar.Enabled = True
                Me.DpFechaSol.Enabled = True
                Me.TxtCodigoAs.Enabled = True
                Me.NudPlazo.Enabled = True
                Me.TxtValVale.Enabled = True
                Me.BtnBuscarSocio.Enabled = True
                Me.ChxAutorizacionExp.Enabled = True
            End If
            Determinardisponible()
            Indemnizacion()
            llenar_dgvFiadores(Fiadores(5, Me.TxtCodigoBuxis.Text, Me.TxtNumeroSol.Text, 0))
        End If
    End Sub

    Private Sub TxtValVale_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValVale.KeyPress, txtAguin.KeyPress, txtBonif.KeyPress
        Dim cadena As String = TxtValVale.Text
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

    Private Sub NudPlazo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NudPlazo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TbcSolicitudes_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TbcSolicitudes.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = TbcSolicitudes.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

        sf.Alignment = StringAlignment.Center

        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If TbcSolicitudes.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the background color of the tab page
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, TbcSolicitudes.Font, br, r, sf)
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, TbcSolicitudes.Font, br, r, sf)
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
            autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
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
                    saldoActual = jClass.obtenerEscalar(Sql)
                    Sql = "   SELECT TOP 1 A.MONTO_MAXIMO " & vbCrLf
                    Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A" & vbCrLf
                    Sql &= "   WHERE A.COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "     AND A.CODIGO_EMPLEADO = " & codEmp & vbCrLf
                    Sql &= "     AND A.SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
                    Sql &= "     AND A.EXCEDER_LIMITE = 1" & vbCrLf
                    autorizaciones = jClass.obtenerDatos(New SqlCommand(Sql))
                    If autorizaciones.Rows.Count > 0 Then
                        montoAdicional = autorizaciones.Rows(0).Item(0)
                    Else
                        montoAdicional = 0
                    End If
                    disponible = monto_maximo - IIf(Val(Me.LblDisponible.Text) < Val(Me.LblMontoMax.Text), 0, saldoActual) + montoAdicional
                    If disponible <= 0 Then
                        MsgBox("DISPONIBLE INSUFICIENTE.", MsgBoxStyle.Critical, "Límite de Consumo Excedido.")
                        Me.BtnGuardar.Enabled = False
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
            Sql &= ",@LIMITE_APROBADO = " & Val(Me.LblDisponible.Text) - Val(Me.TxtValVale.Text) & vbCrLf
            Sql &= ",@MOTIVO          = '" & Me.txtMotivoBloqueo.Text & "'" & vbCrLf
            Sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ",@MODIFICADO      = 1" & vbCrLf
            Sql &= ",@IUD             = 'I'" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        Else
            Sql = "UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
            Sql &= "   SET [MONTO_MAXIMO] = [MONTO_MAXIMO] - " & Me.TxtValVale.Text & vbCrLf
            Sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
            Sql &= "      ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO = " & codemp & vbCrLf
            Sql &= "   AND SOLICITUD = " & Me.CbxSolicitudes.SelectedValue & vbCrLf
            Sql &= "   AND EXCEDER_LIMITE = 0" & vbCrLf
            sqlCmd.CommandText = Sql
            A = jClass.ejecutarComandoSql(sqlCmd)
        End If
        Return A
    End Function

    Private Sub FrmSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
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

    Private Sub CbxSolicitudes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxSolicitudes.SelectedIndexChanged
        If Iniciando = False Then
            ParamSolicitud(Compañia, CbxSolicitudes.SelectedValue)
            If Val(Me.TxtCodigoBuxis.Text) > 0 Then
                Determinardisponible()
            End If
        End If
    End Sub

    Private Sub TxtValVale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValVale.LostFocus
        If Bloqueado And Val(Me.TxtValVale.Text) > Val(Me.LblDisponible.Text) Then
            MsgBox("El valor máximo autorizado es de $ " & Me.LblDisponible.Text, MsgBoxStyle.Information, Me.Text)
            Me.TxtValVale.Text = Me.LblDisponible.Text
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
        tblResultado = jClass.obtenerDatos(New SqlCommand(Sql), 1)
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