Imports System.Data
Imports System.Data.SqlClient

Public Class socio_hojadatos
    Dim Permitir As String
    Dim jc As New jarsClass
    Dim Plantas02 As String
    Dim TipSoliP1, TipSoliP2 As Integer
    Dim Solicitudes As String

    Private Sub socio_hojadatos_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        If Solicitudes <> Nothing Then
            EliminaSolicitudesTemporales()
        End If
    End Sub

    Private Sub socio_hojadatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub socio_hojadatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            Permitir = jc.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

#Region "Connection"

    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim DS04, DS05, DS06 As New DataSet()
    Dim DS07, DS08, DS09 As New DataSet()
    Dim DS10, DS11, DS12 As New DataSet()
    Dim DS13, DS14, DS15, DS16, DS17 As New DataSet()
    Dim SQL As String
    Dim Beneficiario, Estado, Parentesco As Integer
    Dim Accion As String
    Dim PorcenBene, DeudaSocio As Double
    Dim contador As Integer

    'Dim CodBeneficiario As Integer
    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'DS.Reset()
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        'DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
        'DataAdapter.Fill(DS01)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

    Sub limpiardataset()
        DS01.Reset() : DS02.Reset() : DS03.Reset()
        DS04.Reset() : DS05.Reset() : DS06.Reset()
        DS07.Reset() : DS08.Reset() : DS09.Reset()
        While DataGrid_deudas.Rows.Count > 0
            DataGrid_deudas.Rows.RemoveAt(0)
        End While
    End Sub

#End Region

#Region "Busqueda"
    Sub BusquedaDatosSocios(ByVal Origenes As String)
        DS01.Reset()
        Dim CodAS, Accion As String
        Dim CBuxi As Integer
        CodAS = ""
        Accion = ""
        If Trim(ParamcodigoAs) = Nothing And Val(ParamcodigoBux) <= 0 Then
            MessageBox.Show("Ingrese al menos un CODIGO" & Chr(13) & "CODIGO AS O CODIGO BUXI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtCodAS.Focus()
            Exit Sub
        ElseIf Trim(ParamcodigoAs) <> Nothing Or Val(ParamcodigoBux) > 0 Then
            CodAS = ParamcodigoAs.Trim()
            CBuxi = Val(ParamcodigoBux)
            If CodAS <> Nothing And CBuxi <= 0 Then
                Accion = "cas"
            ElseIf CodAS = Nothing And CBuxi > 0 Then
                Accion = "cbuxi"
            ElseIf CodAS <> Nothing And CBuxi > 0 Then
                Accion = "ambos"
            End If
        End If
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','" & CodAS & "','" & Accion & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)

            If (DS01.Tables.Item(0).Rows.Count) <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Hay_Datos = False
                CloseConnection()
                Exit Sub
            End If

            Origen = jc.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & DS01.Tables(0).Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & DS01.Tables(0).Rows(0).Item(3))
            Dim Autorizado As Boolean = False
            Dim arrOrig() As String = Origenes.Split(",")
            For i As Integer = 0 To arrOrig.Length - 1
                If Origen = CInt(arrOrig(i)) Then
                    Autorizado = True
                End If
            Next
            If Not Autorizado Then
                MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, DS01.Tables(0).Rows(0).Item(2) & " - " & DS01.Tables(0).Rows(0).Item(3))
                CloseConnection()
                Return
            End If

            Hay_Datos = True
            If Solicitudes <> Nothing Then
                EliminaSolicitudesTemporales()
            End If

            If CInt(jc.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CODIGO_BUXIS = " & DS01.Tables(0).Rows(0).Item(3).ToString() & " AND CORRELATIVO > 2000000000 AND DEDUCCION IN (234, 245)")) = 0 Then
                NoProgCafe(DS01.Tables(0).Rows(0).Item(3))
            End If

            Me.TxtCodAS.Text = DS01.Tables(0).Rows(0).Item(2)
            Me.TxtCodBuxy.Text = DS01.Tables(0).Rows(0).Item(3)
            Me.TxtSoNombre.Text = DS01.Tables(0).Rows(0).Item(4)
            Me.TxtSoApellido.Text = DS01.Tables(0).Rows(0).Item(5)
            Me.TxtDUI.Text = DS01.Tables(0).Rows(0).Item(15)
            Me.TxtNit.Text = DS01.Tables(0).Rows(0).Item(16)
            Me.TxtDivision.Text = DS01.Tables(0).Rows(0).Item(6)
            Me.TxtDepto.Text = DS01.Tables(0).Rows(0).Item(7)
            Me.TxtSeccion.Text = DS01.Tables(0).Rows(0).Item(8)
            Me.TxtCargo.Text = DS01.Tables(0).Rows(0).Item(9)
            Me.Txt_sueldo_mensual.Text = DS01.Tables(0).Rows(0).Item(19)
            If Val(Txt_sueldo_mensual.Text) > 0 Then
                Me.Txt_capacidad_pago.Text = Format((Val(Txt_sueldo_mensual.Text) * 0.2), "#,##0.00")
            End If
            Me.TxtFechaContratacion.Text = Format(Convert.ToDateTime(DS01.Tables(0).Rows(0).Item(12)), "MMM dd, yyyy")
            Me.Txt_so_direccion.Text = DS01.Tables(0).Rows(0).Item(17)
            Me.Txt_so_telefono.Text = DS01.Tables(0).Rows(0).Item(18)
            Me.txtEmpresa.Text = jc.obtenerEscalar("SELECT DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & Origen)
            Me.TxtDeducciones.Text = Format(DS01.Tables(0).Rows(0).Item(21), "#,##0.00")
            Me.TxtIndemnizacion.Text = Format(DS01.Tables(0).Rows(0).Item(20), "#,##0.00")
            Me.TxtIndemnizacion_mitad.Text = Format((Val(Me.TxtIndemnizacion.Text) / 2), "#,##0.00")
            Me.TxtPorcAhorOrd.Text = Format(DS01.Tables(0).Rows(0).Item("Ahor Ord"), "#,##0.00")
            Me.TxtPorcAhorExt.Text = Format(DS01.Tables(0).Rows(0).Item("Ahor Ext"), "#,##0.00")
            Me.TxtPorcAhorTot.Text = Format(Val(Me.TxtPorcAhorOrd.Text) + Val(Me.TxtPorcAhorExt.Text), "#,##0.00")

            ParamcodigoAs = Me.TxtCodAS.Text
            ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
            CloseConnection()
            'CargarDatosGrid_historialahorro()
            CargarDatosGrid_beneficiarios()
            'Asociadion_AhorrosOrdinarioExtraordinario()
            'Asociadion_SocioTotalDeudas()

            CargarDatosGrid_deudas()

            DisponibleSocio()
            UltimoRetiroAhorros()
            FiadoresDelSocio()
            'SocioFiadorSocio()
            Dim jClass As New jarsClass
            If CBool(jClass.obtenerEscalar("SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & " AND CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "' AND COMPAÑIA = " & Compañia)) Then
                Me.Label38.Visible = True
            Else
                Me.Label38.Visible = False
            End If
            Asociacion_Ingreso()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Asociacion_Ingreso()
        Try
            Dim TblFechas As DataTable
            Dim FechaIngr As Date = CDate("01/01/1900")
            Dim FechaEgr As Date = CDate("01/01/1900")
            Dim Motivo As String = ""
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_ASOCIACION_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','INGR'"
            TblFechas = jc.obtenerDatos(New SqlCommand(SQL))
            If (TblFechas.Rows.Count) > 0 Then
                FechaIngr = CDate(TblFechas.Rows(0).Item(2))
            End If
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_ASOCIACION_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','RET'"
            TblFechas = jc.obtenerDatos(New SqlCommand(SQL))
            If (TblFechas.Rows.Count) > 0 Then
                Motivo = TblFechas.Rows(0).Item(1)
                FechaEgr = CDate(TblFechas.Rows(0).Item(2))
            End If
            If Format(FechaIngr, "dd/MM/yyyy") <> "01/01/1900" Then
                Me.TxtFechaIngresoAS.Text = Format(FechaIngr, "dd/MM/yyyy")
            End If
            If FechaIngr < FechaEgr Then
                Me.txtMotivo.Visible = True
                Me.txtMotivo.Text = Motivo
                Me.GrpPrestamos.Text = "Motivo Retiro"
                Me.Label38.Visible = True
                Me.Label38.Text = "RETIRO ASOCIACION:  " & Format(FechaEgr, "dd/MM/yyyy")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Asociacion_AhorrosOrdinarioExtraordinario()
        Try
            OpenConnection()
            'SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            SQL = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','SAOE'"
            MiddleConnection()
            DataAdapter.Fill(DS05)
            If (DS05.Tables.Item(0).Rows.Count) <= 0 Then
                'MessageBox.Show("No hay ahorros que mostrar...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtTotalAhorro_Ordinario.Text = "0.00"
                Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                Me.TxtTotalAhorro.Text = "0.00"
                Exit Sub
            End If
            Me.TxtTotalAhorro_Ordinario.Text = Format(Val(DS05.Tables(0).Rows(0).Item(0)), "##,##0.00")
            Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(Val(DS05.Tables(0).Rows(0).Item(1)), "##,##0.00")
            Me.TxtTotalAhorro.Text = Format(Val(DS05.Tables(0).Rows(0).Item(2)), "##,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub UltimoRetiroAhorros()
        Dim mytable As DataTable
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','FURPRDF'"
            MiddleConnection()
            DataAdapter.Fill(DS07)

            If (DS07.Tables.Item(0).Rows.Count) <= 0 Then
                Me.TxtFechaURetiro.Text = "Sin Retiro"
                Me.TxtFechaPRetiro.Text = "Sin Retiro"
                Me.TxtDiasFaltantes.Text = 0
                Me.TxtCantidadRetirada.Text = "0.00"
                Exit Sub
            End If
            mytable = DS07.Tables(0)
            Me.TxtFechaURetiro.Text = Format(Convert.ToDateTime(mytable.Rows(0).Item("Ultima Fecha Retiro")), "dd MMM yyyy")
            Me.TxtFechaPRetiro.Text = Format(Convert.ToDateTime(mytable.Rows(0).Item("Proxima Fecha Retiro")), "dd MMM yyyy")
            If mytable.Rows(0).Item("Dias Faltantes") < 0 Then
                Me.TxtDiasFaltantes.Text = 0
            Else
                Me.TxtDiasFaltantes.Text = mytable.Rows(0).Item("Dias Faltantes")
            End If
            Me.TxtCantidadRetirada.Text = Format(mytable.Rows(0).Item("Cantidad Retirada"), "##,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub Asociacion_SocioTotalDeudas()
        DS06.Reset()
        Try
            OpenConnection()
            SQL = "exec Coo.sp_COOPERATIVA_DEUDA " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",0,1"
            MiddleConnection()
            DataAdapter.Fill(DS06)
            If (DS06.Tables.Item(0).Rows.Count) <= 0 Then
                DeudaSocio = 0
                'MessageBox.Show("El socio no Tiene Deudas...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else : DeudaSocio = Format(DS06.Tables(0).Rows(0).Item(3), "##,##0.00")
            End If

            If Me.TxtTotalAhorro_Ordinario.Text > 0 Then
                Me.TxtPrestamo_SinFiador.Text = Val(Me.TxtTotalAhorro_Ordinario.Text) - DeudaSocio
                Me.TxtPrestamo_ConFiador.Text = (Val(Me.TxtTotalAhorro_Ordinario.Text) * 2) - DeudaSocio
                ''MessageBox.Show(DeudaSocio)
            Else
                Me.TxtPrestamo_SinFiador.Text = "0.00"
                Me.TxtPrestamo_ConFiador.Text = "0.00"
            End If
            Me.TxtTotalDeudasSocio.Text = Format(DeudaSocio, "##,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub DisponibleSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim AhorroOrdi, AhorroExtraOrdi As Double
        Dim Deuda, DeudaFiador As Double
        Dim ConFiador, SinFiador, ptmos As Double
        Dim Bandera As Integer

        If ParamcodigoAs.Length > 0 And ParamcodigoBux > 0 Then
            Bandera = 1
        ElseIf ParamcodigoAs.Length > 0 And ParamcodigoBux = 0 Then
            Bandera = 2
        ElseIf ParamcodigoAs.Length = 0 And ParamcodigoBux > 0 Then
            Bandera = 3
        End If
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            SQL = "Execute Coo.sp_COOPERATIVA_DISPONIBLE_DEL_SOCIO '" & Trim(ParamcodigoAs) & "', " & Trim(ParamcodigoBux) & ", " & Compañia & ", " & Bandera
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataReader_Track = Comando_Track.ExecuteReader
            AhorroOrdi = 0
            AhorroExtraOrdi = 0
            Deuda = 0
            If DataReader_Track.Read = True Then
                AhorroOrdi = DataReader_Track.Item("AHORRO ORDINARIO")
                AhorroExtraOrdi = DataReader_Track.Item("AHORRO EXTRAORDINARIO")
                For Each row As DataGridViewRow In Me.DataGrid_deudas.Rows
                    Deuda += row.Cells(2).Value
                Next
                Me.TxtTotalAhorro_Ordinario.Text = Format(AhorroOrdi, "##,##0.00")
                Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(AhorroExtraOrdi, "##,##0.00")
                Me.TxtTotalAhorro.Text = Format(AhorroOrdi + AhorroExtraOrdi, "##,##0.00")
                Me.TxtTotalDeudasSocio.Text = Format(Deuda, "##,##0.00")
            End If
            SQL = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] " & vbCrLf
            SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
            SQL &= ", @CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & vbCrLf
            SQL &= ", @BANDERA = 7" & vbCrLf
            DeudaFiador = jc.obtenerEscalar(SQL)
            If DeudaFiador > 0 Then
                Me.TxtSocioFiadorSocio.Text = "SI"
                Me.BtnFiadoresSocio_esfiador.Enabled = True
            Else
                Me.TxtSocioFiadorSocio.Text = "NO"
                Me.BtnFiadoresSocio_esfiador.Enabled = False
            End If
            If Origen = 5 Or Origen = 6 Then
                SQL = "SELECT ISNULL(SUM(D.CAPITAL),0.00) AS CAPITAL"
                SQL &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D"
                SQL &= " WHERE S.COMPAÑIA = D.COMPAÑIA"
                SQL &= "   AND S.CORRELATIVO = D.NUMERO_SOLICITUD"
                SQL &= "   AND S.CODIGO_BUXIS = " & Me.TxtCodBuxy.Text
                SQL &= "   AND D.CAPITAL_D = 0"
                SQL &= "   AND S.COMPAÑIA = " & Compañia
                SQL &= "   AND S.DEDUCCION = " & CInt(jc.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")).ToString()
                ptmos = jc.obtenerEscalar(SQL)
                SinFiador = (AhorroOrdi + AhorroExtraOrdi) - ptmos - DeudaFiador
                ConFiador = ((AhorroOrdi + AhorroExtraOrdi) * 1.75) - ptmos - DeudaFiador
            Else
                SinFiador = Val(Me.TxtTotalAhorro_Ordinario.Text.Replace(",", "")) - Deuda - DeudaFiador
                ConFiador = (Val(Me.TxtTotalAhorro_Ordinario.Text.Replace(",", "")) * 2) - Deuda - DeudaFiador
            End If

            If SinFiador > 0 Then
                Me.TxtPrestamo_SinFiador.Text = SinFiador.ToString("##,##0.00")
            Else
                Me.TxtPrestamo_SinFiador.Text = "0.00"
            End If
            If ConFiador > 0 Then
                Me.TxtPrestamo_ConFiador.Text = ConFiador.ToString("##,##0.00")
            Else
                Me.TxtPrestamo_ConFiador.Text = "0.00"
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error DisponibleSocio")
        End Try
    End Sub

    Sub FiadoresDelSocio()
        DS07.Reset()
        Try
            OpenConnection()
            'SQL = "Execute sp_COOPERATIVA_SOCIO_FIADORES " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",'FS'"
            SQL = "execute [Coo].[sp_COOPERATIVA_MOSTRAR_FIADORES_SOCIO_DEUDA] " & Compañia & ", " & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "',0"
            MiddleConnection()
            DataAdapter.Fill(DS07)
            If (DS07.Tables.Item(0).Rows.Count) <= 0 Then
                'MessageBox.Show("El socio no tiene fiadores en sus prestamos...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtSocioFiadores.Text = "NO"
                Me.BtnFiadoresSocio_tienefiador.Enabled = False
                Exit Sub
            Else
                Me.TxtSocioFiadores.Text = "SI"
                Me.BtnFiadoresSocio_tienefiador.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub
    Sub SocioFiadorSocio()
        DS08.Reset()
        Try
            OpenConnection()
            'SQL = "Execute sp_COOPERATIVA_SOCIO_FIADORES " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",'SFS'"
            'SQL = "Execute [Coo].[sp_COOPERATIVA_MOSTRAR_SOCIO_DEPENDIENTE_FIADOR_DEUDA] " & Compañia & ", 0, " & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "', 1"
            SQL = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]  " & vbCrLf
            SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
            SQL &= ", @CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & vbCrLf
            SQL &= ", @BANDERA = 4" & vbCrLf
            MiddleConnection()
            DataAdapter.Fill(DS08)
            If (DS08.Tables.Item(0).Rows.Count) <= 0 Then
                'MessageBox.Show("El socio no ES fiadores en prestamos de socios...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtSocioFiadorSocio.Text = "NO"
                Me.BtnFiadoresSocio_esfiador.Enabled = False
                Exit Sub
            Else
                Me.TxtSocioFiadorSocio.Text = "SI"
                Me.BtnFiadoresSocio_esfiador.Enabled = True
            End If
            'MsgBox(DS08.Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

#End Region

#Region "Texbox Upper Case and Trim"
    Sub TextoConversion()
        For Each control As Control In GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.Text = Trim(control.Text)
                control.Text = UCase(control.Text)
            End If
        Next
    End Sub
#End Region

#Region "Borrar Textbox"

    Sub BorrarCajasTexto()
        For Each control As Control In Me.GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrpFechaIngreso.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrpAhorros.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrpSueldo.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrpPrestamos.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrpFiador.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.GrbRetiros.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next

        Me.TxtTotalDeudasSocio.Clear()

    End Sub
#End Region

#Region "Ahorros"
    Sub Porcentaje_ahorro()
        'Try
        '    If Val(Me.Txt_por_ahorrar_total.Text) < 2.5 Then
        '        MessageBox.Show("El Porcentaje de Ahorro no puede ser menor al 2.5", "Error...!!!")
        '        Me.Txt_por_ahorrar_total.Focus()
        '    ElseIf Val(Me.Txt_por_ahorrar_total.Text) >= 2.5 And Val(Me.Txt_por_ahorrar_total.Text) <= 5 Then
        '        Me.Txt_por_ahorrar_ordinario.Text = Val(Me.Txt_por_ahorrar_total.Text)
        '        Me.Txt_por_ahorrar_extraordinario.Text = 0
        '    ElseIf Val(Me.Txt_por_ahorrar_total.Text) > 5 Then
        '        Me.Txt_por_ahorrar_ordinario.Text = 5
        '        Me.Txt_por_ahorrar_extraordinario.Text = Val(Me.Txt_por_ahorrar_total.Text) - 5
        '    End If
        '    'MessageBox.Show(Txt_por_ahorrar_ordinario.Text & ";" & Txt_por_ahorrar_extraordinario.Text)
        '    Me.Txt_ahorrar_total.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_total.Text / 100), "0.00")
        '    Me.Txt_ahorrar_ordinario.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_ordinario.Text / 100), ".00")
        '    Me.Txt_ahorrar_extraordinario.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_extraordinario.Text / 100), ".00")
        'Catch ex As Exception
        'Finally

        'End Try
    End Sub

    Sub CargarDatosGrid_historialahorro()

        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Exit Sub
        End If
        Try
            DS02.Reset()
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_PORCENTAJE_AHORRO_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "',0,0,'" & Usuario & "','SDHA'"
            MiddleConnection()
            DataAdapter.Fill(DS02)
            'DataGrid_AhorrosHistorial.DataSource = DS02.Tables(0)
            CloseConnection()
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            CloseConnection()
            'MsgBox("Hola")
        End Try
        'SumaPorcentajesBeneficiarios()
        For i As Integer = 1 To 4
            'DataGrid_AhorrosHistorial.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

#End Region

#Region "Deudas"
    Sub CargarDatosGrid_deudas()

        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Exit Sub
        End If
        Try
            DS13.Reset()
            OpenConnection()
            SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",'TDSDA'"
            MiddleConnection()
            DataAdapter.Fill(DS13)
            DataGrid_deudas.DataSource = DS13.Tables(0)
            CloseConnection()
            DataGrid_deudas.Columns(0).Visible = False
            DataGrid_deudas.Columns(1).Width = 140
            Me.TxtTotalDeudasSocio.Left = 150
            DataGrid_deudas.Columns(2).Width = 90
            DataGrid_deudas.Columns(2).DefaultCellStyle.Format = "##,##0.00"
            DataGrid_deudas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
        'SumaPorcentajesBeneficiarios()
        Try
            DS14.Reset()
            OpenConnection()
            SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",'TDXP'"
            MiddleConnection()
            DataAdapter.Fill(DS14)
            dgvDescPeriodo.DataSource = DS14.Tables(0)
            dgvDescPeriodo.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDescPeriodo.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDescPeriodo.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDescPeriodo.Columns(1).DefaultCellStyle.Format = "##,##0.00"
            dgvDescPeriodo.Columns(0).Width = 90
            dgvDescPeriodo.Columns(1).Width = 80

            DS15.Reset()
            SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCodBuxy.Text & ",'TDXTIPO'"
            MiddleConnection()
            DataAdapter.Fill(DS15)
            dgvDeducciones.DataSource = DS15.Tables(0)
            dgvDeducciones.Columns(0).Width = 80
            dgvDeducciones.Columns(0).HeaderText = "TIPO SOLICITUD"
            dgvDeducciones.Columns(0).Visible = False
            dgvDeducciones.Columns(1).Width = 150
            dgvDeducciones.Columns(1).HeaderText = "DESCRIPCION DEUDA"
            dgvDeducciones.Columns(2).Width = 80
            dgvDeducciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDeducciones.Columns(2).DefaultCellStyle.Format = "##,##0.00"
            dgvDeducciones.Columns(3).Width = 80
            dgvDeducciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error al Cargar Deudas Socio")
        Finally
            CloseConnection()
            'MsgBox("Hola")
        End Try
    End Sub
#End Region

#Region "Beneficiarios"
    Sub CargarDatosGrid_beneficiarios()

        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Exit Sub
        End If
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_BENEFICIARIOS_AGREGAR " & Compañia & ", '" & Beneficiario & "', '" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','" & Parentesco & "','Me.Txt_be_nombre.Text','Me.Txt_be_apellido.Text','Me.Txt_be_telefono1.Text','Me.Txt_be_telefono2.Text','0','Me.Txt_be_direccion.Text','" & Usuario & "',1,'S'"
            MiddleConnection()
            DataAdapter.Fill(DS03)
            DataGrid_Beneficiarios.DataSource = DS03.Tables(0)
            CloseConnection()
            Me.DataGrid_Beneficiarios.Columns(0).Visible = False 'compañia
            Me.DataGrid_Beneficiarios.Columns(4).Visible = False 'codigo parentesco
            Me.DataGrid_Beneficiarios.Columns(2).Visible = False 'codigo buxi
            Me.DataGrid_Beneficiarios.Columns(3).Visible = False 'codigo as
            Me.DataGrid_Beneficiarios.Columns(12).Visible = False 'estado
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            CloseConnection()
            'MsgBox("Hola")
        End Try
        Me.DataGrid_Beneficiarios.Columns.Item(1).Width = 45 'codigo beneficiario
        Me.DataGrid_Beneficiarios.Columns.Item(5).Width = 200 'nombre beneficiario
        Me.DataGrid_Beneficiarios.Columns.Item(6).Width = 200 'Apellido beneficiario
        Me.DataGrid_Beneficiarios.Columns.Item(7).Width = 150 'descripcion beneficiario
        Me.DataGrid_Beneficiarios.Columns.Item(8).Width = 130 'telefono 1
        Me.DataGrid_Beneficiarios.Columns.Item(9).Width = 130 'telefono 2
        Me.DataGrid_Beneficiarios.Columns.Item(10).Width = 60 'porcentaje
        Me.DataGrid_Beneficiarios.Columns.Item(11).Width = 300 'porcentaje
        'SumaPorcentajesBeneficiarios()

    End Sub
#End Region

    Private Sub Btn_Socio_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BorrarCajasTexto()
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = Me.TxtCodAS.Text '""
        ParamcodigoBux = Val(Me.TxtCodBuxy.Text) '0
        StadoBusqueda = 2
        If Me.TxtSoNombre.Text <> Nothing Then
            DS01.Reset()
        End If
        If Trim(Me.TxtCodAS.Text) <> "" Or Trim(Me.TxtCodBuxy.Text) <> "" Then
            BusquedaDatosSocios(Permitir)
            Porcentaje_ahorro()
        Else
            Dim Prin As New FrmBuscarSocios
            Prin.Compañia_Value = Compañia
            Prin.ShowDialog()
            If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
                Me.TxtCodBuxy.Text = ParamcodigoBux
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios(Permitir)
            End If
        End If
    End Sub

    Sub Btn_Socio_limpiar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click
        BorrarCajasTexto()
        limpiardataset()
        Me.DataGrid_Beneficiarios.DataSource = Nothing
        Me.DataGrid_deudas.DataSource = Nothing
        Me.dgvDeducciones.DataSource = Nothing
        Me.dgvDeduccionesDetalle.DataSource = Nothing
        Me.dgvDescPeriodo.DataSource = Nothing
        Me.dgvDeudaFechas.DataSource = Nothing
        Me.TxtCodBuxy.Focus()
        Me.Label38.Visible = False
        Me.txtMotivo.Visible = False
        Me.GrpPrestamos.Text = "Montos a Financiar"
        Me.Label38.Text = "CREDITO BLOQUEADO " & vbCrLf & "CONSULTAR A GERENCIA"
        If Solicitudes <> Nothing Then
            EliminaSolicitudesTemporales()
        End If
    End Sub

    Private Sub Txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress, TxtCodAS.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Dim jClass As New jarsClass
            If Me.TxtCodAS.Text <> Nothing Or Me.TxtCodBuxy.Text <> Nothing Then
                If Me.TxtCodAS.Text <> Nothing Then
                    ParamcodigoAs = Me.TxtCodAS.Text.PadLeft(6, "0")
                Else
                    ParamcodigoAs = ""
                End If
                ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
                Btn_Socio_limpiar.PerformClick()
                BusquedaDatosSocios(Permitir)
                ParamcodigoAs = Me.TxtCodAS.Text
                ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
                If Hay_Datos Then
                    Porcentaje_ahorro()
                End If
            End If
        End If
    End Sub

    Private Sub BtnFiadoresSocio_esfiador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiadoresSocio_esfiador.Click
        If Me.BtnFiadoresSocio_esfiador.Enabled = True Then
            Dim Prin As New frm_hojadatos_fiadordesocios
            AppPath = System.IO.Directory.GetCurrentDirectory
            ParamcodigoBux = Me.TxtCodBuxy.Text.Trim
            ParamcodigoAs = Me.TxtCodAS.Text.Trim
            Prin.CargarDatosGrid_SocioFiador_deSocios(1)
            Prin.ShowDialog()
        End If
    End Sub


    Private Sub dgvDeducciones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDeducciones.CellEnter
        OpenConnection()
        SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ", '" & Me.TxtCodAS.Text & "', " & Me.TxtCodBuxy.Text & ", 'TDXDEDUC', " & dgvDeducciones.CurrentRow.Cells(0).Value
        DS16.Reset()
        MiddleConnection()
        DataAdapter.Fill(DS16)
        dgvDeduccionesDetalle.DataSource = DS16.Tables(0)
        CloseConnection()
        dgvDeduccionesDetalle.DataSource = DS16.Tables(0)
        For i As Integer = 0 To dgvDeduccionesDetalle.Columns.Count - 1
            dgvDeduccionesDetalle.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            If i > 2 Then
                dgvDeduccionesDetalle.Columns(i).Width = 70
                dgvDeduccionesDetalle.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvDeduccionesDetalle.Columns(i).DefaultCellStyle.Format = "##,##0.00"
            End If
        Next
        dgvDeduccionesDetalle.Columns(0).Width = 50
        dgvDeduccionesDetalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeduccionesDetalle.Columns(1).Width = 200
        dgvDeduccionesDetalle.Columns(2).Width = 90
        dgvDeduccionesDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 3).Width = 50
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 3).DefaultCellStyle.Format = "###"
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 2).Width = 70
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 2).DefaultCellStyle.Format = "dd/MM/yyyy"
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 1).Width = 70
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 1).HeaderText = "NUMERO FACTURA"
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 1).DefaultCellStyle.Format = ""
        dgvDeduccionesDetalle.Columns(dgvDeduccionesDetalle.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub dgvDescPeriodo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDescPeriodo.CellEnter
        OpenConnection()
        SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ", '" & Me.TxtCodAS.Text & "', " & Me.TxtCodBuxy.Text & ", 'TDXFECHA', 0, '" & Format(dgvDescPeriodo.CurrentRow.Cells(0).Value, "Short Date") & "'"
        DS17.Reset()
        MiddleConnection()
        DataAdapter.Fill(DS17)
        dgvDeudaFechas.DataSource = DS17.Tables(0)
        CloseConnection()
        For i As Integer = 0 To dgvDeudaFechas.Columns.Count - 1
            dgvDeudaFechas.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            If i > 3 Then
                dgvDeudaFechas.Columns(i).Width = 60
                dgvDeudaFechas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvDeudaFechas.Columns(i).DefaultCellStyle.Format = "##,##0.00"
            End If
        Next
        dgvDeudaFechas.Columns(0).Width = 50
        dgvDeudaFechas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeudaFechas.Columns(1).Width = 130
        dgvDeudaFechas.Columns(2).Width = 65
        dgvDeudaFechas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeudaFechas.Columns(3).Width = 70
        dgvDeudaFechas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDeudaFechas.Columns(3).DefaultCellStyle.Format = "##,##0.00"
        dgvDeudaFechas.Columns(dgvDeudaFechas.Columns.Count - 1).Width = 50
        dgvDeudaFechas.Columns(dgvDeudaFechas.Columns.Count - 1).DefaultCellStyle.Format = ""
        dgvDeudaFechas.Columns(dgvDeudaFechas.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BtnFiadoresSocio_tienefiador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiadoresSocio_tienefiador.Click
        'If Me.BtnFiadoresSocio_esfiador.Enabled = True Then
        Dim Prin As New frm_hojadatos_fiadordesocios
        AppPath = System.IO.Directory.GetCurrentDirectory
        ParamcodigoBux = Me.TxtCodBuxy.Text.Trim
        ParamcodigoAs = Me.TxtCodAS.Text.Trim
        Prin.CargarDatosGrid_SocioFiador_deSocios(2)
        Prin.ShowDialog()
        'End If
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Dim sql, compa As String
        Dim cmdSql As New SqlCommand
        Dim tbl As New DataTable("rptTable")
        Dim rpt1 As New Cooperativa_Deudas_Socio_Solicitud
        Dim rpts As New frmReportes_Ver
        Dim i As Integer
        Dim jars As New jarsClass
        sql = ""
        'Dim rpt1 As New coopEnviarProgramaciones
        ' preparar data table
        If MessageBox.Show("¿Desea generar el reporte?", "CONFIRMACION", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            tbl.Columns.Add("N° Solicitud", GetType(Integer))
            tbl.Columns.Add("DESCRIPCION DEDUCCION", GetType(String))
            tbl.Columns.Add("FECHA PAGO", GetType(Date))
            tbl.Columns.Add("Monto Otorgado", GetType(Double))
            tbl.Columns.Add("CUOTA", GetType(Double))
            tbl.Columns.Add("CAPITAL", GetType(Double))
            tbl.Columns.Add("INTERES", GetType(Double))
            tbl.Columns.Add("SEGURO DEUDA", GetType(Double))
            tbl.Columns.Add("Nº CUOTA", GetType(Integer))
            tbl.Columns.Add("FECHA OTORGADO", GetType(Date))
            tbl.Columns.Add("Numero Factura", GetType(Integer))
            tbl.Columns.Add("compania", GetType(String)) '-----
            tbl.Columns.Add("codas", GetType(String))
            tbl.Columns.Add("codbux", GetType(Integer))
            tbl.Columns.Add("nombres", GetType(String))
            tbl.Columns.Add("apellidos", GetType(String))
            tbl.Columns.Add("usuario", GetType(String))

            compa = jars.obtenerEscalar("select NOMBRE_COMPAÑIA from CATALOGO_COMPAÑIAS where COMPAÑIA=" & Compañia)
            For i = 0 To Me.dgvDeduccionesDetalle.Rows.Count - 1
                tbl.Rows.Add(Me.dgvDeduccionesDetalle.Rows(i).Cells(0).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(1).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(2).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(3).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(4).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(5).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(6).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(7).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(8).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(9).Value, _
                        Me.dgvDeduccionesDetalle.Rows(i).Cells(10).Value, _
                        compa, _
                        Me.TxtCodAS.Text, _
                        Me.TxtCodBuxy.Text, _
                        Me.TxtSoNombre.Text, _
                        Me.TxtSoApellido.Text, _
                        Usuario)
            Next

            rpt1.SetDataSource(tbl)
            rpts.ReportesGenericos(rpt1)
            rpts.ShowDialog()
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.Btn_Socio_limpiar.PerformClick()
            Case Keys.F1
                'Add the code for the function key F1 here.
                'Me.btnCopiaPedido.PerformClick()
            Case Keys.F2
                'Add the code for the function key F2 here.
                'Me.btnAnular.PerformClick()
            Case Keys.F3
                'Add the code for the function key F5 here.
                'Me.btnBuscarCliente.PerformClick()
            Case Keys.F4
                'Add the code for the function key F6 here.
                'Me.btnProcesar.PerformClick()
            Case Keys.F5
                'Add the code for the function key F7 here.
                'Me.btnImprimir.PerformClick()
            Case Keys.F6
                'Add the code for the function key F9 here.
                'Me.btnBuscarProducto.PerformClick()
            Case Keys.F7
                'Add the code for the function key F10 here.
                'btnEliminarProducto.PerformClick()
                'crvFact.ReportSource = Nothing
                'crvFact.Visible = False
                'crvFact.Dock = DockStyle.None
            Case Keys.F8
                'algo pasará
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim jars As New jarsClass
        Dim tbl As New DataTable("rptTable")
        Dim rpt1 As New cooperativa_ahorros_socios
        Dim rpts As New frmReportes_Ver
        Dim cmd As New SqlCommand
        Dim compa As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtCompania"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim nombreSocio As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtNombre"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim cod_as As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("tctCodAs"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim cod_bx As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtCodBux"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim Motivo As CrystalDecisions.CrystalReports.Engine.TextObject = rpt1.Section2.ReportObjects.Item("txtMotivo")

        cmd = New SqlCommand("execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','RPTH'")
        tbl = jars.obtenerDatos(cmd)

        If Origen = 5 Or Origen = 6 Then
            compa.Text = jc.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2")
        Else
            compa.Text = Descripcion_Compañia
        End If
        nombreSocio.Text = Me.TxtSoNombre.Text + " " + Me.TxtSoApellido.Text
        cod_as.Text = Me.TxtCodAS.Text
        cod_bx.Text = Me.TxtCodBuxy.Text
        If Me.txtMotivo.Visible Then
            Motivo.Text = Me.Label38.Text & Chr(10) & Me.txtMotivo.Text
        End If

        rpt1.SetDataSource(tbl)
        rpts.ReportesGenericos(rpt1)
        rpts.ShowDialog()
        'End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim jars As New jarsClass
        Dim tbl As New DataTable("rptTable")
        Dim rpt1 As New Cooperativa_Deudas_Periodo
        Dim rpts As New frmReportes_Ver
        Dim cmd As New SqlCommand
        Dim compa As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtCompania"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim nombreSocio As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtNombre"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim cod_as As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtCodAS"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim cod_bx As CrystalDecisions.CrystalReports.Engine.TextObject = CType(rpt1.ReportDefinition.ReportObjects.Item("txtCodBx"), CrystalDecisions.CrystalReports.Engine.TextObject)

        If MessageBox.Show("¿Desea generar el reporte?", "CONFIRMACION", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            compa.Text = jars.obtenerEscalar("select NOMBRE_COMPAÑIA from CATALOGO_COMPAÑIAS where COMPAÑIA=" & Compañia)
            cod_bx.Text = Me.TxtCodBuxy.Text
            cod_as.Text = Me.TxtCodAS.Text
            nombreSocio.Text = Me.TxtSoNombre.Text + " " + Me.TxtSoApellido.Text

            cmd = New SqlCommand("EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ", '" & Me.TxtCodAS.Text & "', " & Me.TxtCodBuxy.Text & ",'RPTTDXP'")

            tbl = jars.obtenerDatos(cmd)
            rpt1.SetDataSource(tbl)
            rpts.ReportesGenericos(rpt1)
            rpts.ShowDialog()
        End If
    End Sub

    Private Sub socio_hojadatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage5_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage5.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub socio_hojadatos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not Me.Parent.Text = "Hoja de Datos" Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Function NoProgCafe(ByVal CodBuxis As String) As Boolean
        Dim Table As DataTable
        Dim sqlCmd As New SqlClient.SqlCommand
        Plantas02 = jc.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 16").ToString().Trim
        TipSoliP1 = jc.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
        TipSoliP2 = jc.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
        'SELECCIONA TODOS LOS TICKETS QUE HA CONSUMIDO EL EMPLEADO DESDE EL ULTIMO ENVIO A BUXIS
        '*****************************************************************************************************
        sqlCmd.CommandText = "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, "
        sqlCmd.CommandText &= "COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP1 & " AS TIPOSOLI, "
        sqlCmd.CommandText &= "CONVERT(DATE, '" & Format(Now(), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA NOT IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS" & vbCrLf
        sqlCmd.CommandText &= "UNION ALL" & vbCrLf
        sqlCmd.CommandText &= "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP2 & " AS TIPOSOLI, CONVERT(DATE, '" & Format(Now(), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS"
        'CARGA LOS DATOS EN TABLE
        Table = jc.obtenerDatos(sqlCmd)
        '*****************************************************************************************************
        If Table.Rows.Count > 0 Then
            CrearProgramaciones(Table)
        End If
    End Function

    Private Function CrearProgramaciones(ByVal Tabla As DataTable) As Boolean
        Dim Cmd As New SqlClient.SqlCommand
        Dim FPro As New Facturacion_Procesos
        Dim cuantos As Integer
        Dim numSoli As Integer = 2147483647
        Dim RowsAfected As Integer = 0
        Dim Resultado As Boolean = False
        Solicitudes = ""
        cuantos = jc.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
        For i As Integer = 0 To Tabla.Rows.Count - 1
            While cuantos > 0
                numSoli = numSoli - 1 'FPro.actualizaNumDoc(Compañia, "SOL")
                cuantos = jc.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
            End While
            Solicitudes &= IIf(i = 0, "", ",") & numSoli
            FPro.SolicitudesFacturacionSocios(Compañia, Tabla.Rows(i).Item("TIPOSOLI"), numSoli, Tabla.Rows(i).Item("CODIGO_EMPLEADO_AS"), Tabla.Rows(i).Item("CODIGO_EMPLEADO"), Now(), 1, Tabla.Rows(i).Item("MONTO_TOTAL"), 0, 0, "QQ", 1, Tabla.Rows(i).Item("FECHA_PAGO"), "Consumo en Cafeteria", 0, 0)
            jc.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOLICITUDES SET USUARIO_EDICION = 'HOJA DATOS' WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
            numSoli = numSoli - 1
            cuantos = jc.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
        Next
        Return Resultado
    End Function

    Private Sub EliminaSolicitudesTemporales()
        Dim solicitudesArray As String() = Solicitudes.Split(",")
        For Each solicitud As Integer In solicitudesArray
            jc.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & solicitud)
            jc.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & solicitud)
            jc.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud)
            jc.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & solicitud)
        Next
    End Sub
    Private Function SetearFechas() As Date
        Dim Fecha As Date = Now()
        If Fecha.Day <= 11 Then
            Fecha = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 11 And Fecha.Day <= 27 And Fecha.Day <> 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Fecha = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Fecha = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Fecha = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        ElseIf Fecha.Day > 27 And Fecha.Day <= 31 And Fecha.Day <> 30 Then
            Fecha = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString).AddMonths(1)
        End If
        Return Fecha
    End Function
End Class