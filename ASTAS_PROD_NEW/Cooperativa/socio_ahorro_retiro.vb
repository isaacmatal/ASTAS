Imports System.Data
Imports System.Data.SqlClient

Public Class socio_ahorro_retiro
    Dim Iniciando As Boolean
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub socio_ahorro_retiro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Me.RdbAhorro_continuar.Checked = True
        BorrarCajasTexto(2) : BorrarCajasTexto(1) : BorrarCajasTexto(3) : BorrarCajasTexto(4)
        Iniciando = False
        DisableEnableControls(True)
        RegistrosEmitidos()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub
#Region "Connection"

    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As New SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS, DS01, DS02, DS03, DS04, DS05, DS06, DS07, DS08, DS09 As New DataSet()
    Dim SQL As String
    Dim Beneficiario, Estado, Parentesco As Integer
    Dim Accion As String
    Dim PorcenBene As Double

    Dim Resultado As DialogResult
    Dim SalarioMensual As Double

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub

    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub

    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Sub UltimoRetiroAhorros()
        DS01.Reset()
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','FURPRDF'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If (DS01.Tables.Item(0).Rows.Count) <= 0 Then
                Me.TxtFechaURetiro.Text = "Sin Retiro"
                Me.TxtFechaPRetiro.Text = "Sin Retiro"
                Me.TxtDiasFaltantes.Text = 0
                Me.TxtCantidadRetirada.Text = "0.00"

                Exit Sub
            End If
            Me.TxtFechaURetiro.Text = DS01.Tables(0).Rows(0).Item(0)
            Me.TxtFechaPRetiro.Text = DS01.Tables(0).Rows(0).Item(1)
            If Val(DS01.Tables(0).Rows(0).Item(2)) < 0 Then
                Me.TxtDiasFaltantes.Text = 0
            Else
                Me.TxtDiasFaltantes.Text = DS01.Tables(0).Rows(0).Item(2)
            End If
            Me.TxtCantidadRetirada.Text = Format(DS01.Tables(0).Rows(0).Item(3), "0.00")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub Asociacion_AhorrosOrdinarioExtraordinario()
        DS02.Reset()
        Dim ptmos As Double = 0
        Dim ptmosFiador As Double = 0
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','SAOE'"
            MiddleConnection()
            DataAdapter.Fill(DS02)
            If (DS02.Tables.Item(0).Rows.Count) <= 0 Then
                Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                Exit Sub
            End If
            If Origen = 5 Or Origen = 6 Then
                SQL = "SELECT ISNULL(SUM(D.CAPITAL),0.00) AS CAPITAL"
                SQL &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE D"
                SQL &= " WHERE S.COMPAÑIA = D.COMPAÑIA"
                SQL &= "   AND S.CORRELATIVO = D.NUMERO_SOLICITUD"
                SQL &= "   AND S.CODIGO_BUXIS = " & Me.TxtCodBuxy.Text
                SQL &= "   AND D.CAPITAL_D = 0"
                SQL &= "   AND S.COMPAÑIA = " & Compañia
                SQL &= "   AND S.DEDUCCION = " & CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 11")).ToString()
                ptmos = jClass.obtenerEscalar(SQL)
                SQL = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] " & vbCrLf
                SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
                SQL &= ", @CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & vbCrLf
                SQL &= ", @BANDERA = 7" & vbCrLf
                ptmosFiador = jClass.obtenerEscalar(SQL)
                If Val(DS02.Tables(0).Rows(0).Item(2)) < (ptmos - ptmosFiador) Then
                    MessageBox.Show("Deuda es mayor que total de ahorros.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                    Return
                End If
            End If
            If Val(DS02.Tables(0).Rows(0).Item(1)) <= 0 Then
                MessageBox.Show("El saldo de ahorro extraordinario del socio es ""Cero"", no se puede realizar ningún retiro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                Me.TxtCantidad_retirar.Enabled = False
                Me.CheckBox1.Enabled = False
                DisableEnableControls(True)
            Else
                If Math.Round(Val(DS02.Tables(0).Rows(0).Item(2)) - ptmos - ptmosFiador) > 0 Then
                    If Math.Round(Val(DS02.Tables(0).Rows(0).Item(2)) - ptmos - ptmosFiador) >= Math.Round(Val(DS02.Tables(0).Rows(0).Item(1)), 2) Then
                        Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(Val(DS02.Tables(0).Rows(0).Item(1)), "0.00")
                    Else
                        Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(Val(DS02.Tables(0).Rows(0).Item(1)) - (ptmos - ptmosFiador - Val(DS02.Tables(0).Rows(0).Item(0))), "0.00")
                    End If
                    Me.TxtCantidad_retirar.Enabled = True
                    Me.CheckBox1.Enabled = True
                    DisableEnableControls(False)
                Else
                    MessageBox.Show("Ahorro Extraordinario insuficiente, no se puede realizar ningún retiro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                    Me.TxtCantidad_retirar.Enabled = False
                    Me.CheckBox1.Enabled = False
                    DisableEnableControls(True)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub


#Region "Basic"

    Sub BorrarCajasTexto(ByVal accion)

        If accion = 1 Then
            For Each control As Control In Me.GrpDatosSocios.Controls
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            Next
            Me.TxtCodAS.Focus()
        End If

        If accion = 2 Then
            Me.TxtCantidad_retirar.Clear()
            Me.TxtCantidad_retirar.Focus()
            Me.CheckBox1.Checked = False
        End If

        If accion = 3 Then
            For Each control As Control In Me.GroupBox2.Controls
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            Next
            Me.DateTimePicker1.Text = Today
        End If

        If accion = 4 Then
            For Each control As Control In GroupBox5.Controls
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            Next
        End If

        DS.Reset()
    End Sub

    Private Sub Btn_Socio_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click, Btn_ah_limpiar.Click
        If sender Is Btn_Socio_limpiar Then
            BorrarCajasTexto(3) : BorrarCajasTexto(2) : BorrarCajasTexto(1)
        ElseIf sender Is Btn_ah_limpiar Then
            BorrarCajasTexto(2)
        End If
        RegistrosEmitidos()
    End Sub

    Sub DisableEnableControls(ByVal accion As Boolean)
        If accion = True Then
            Me.TxtCantidad_retirar.Enabled = False
            Me.Btn_ah_limpiar.Enabled = False
            Me.CheckBox1.Enabled = False
            Me.Btn_guardar.Enabled = False
        Else
            Me.TxtCantidad_retirar.Enabled = True
            Me.Btn_ah_limpiar.Enabled = True
            Me.CheckBox1.Enabled = True
            Me.Btn_guardar.Enabled = True
        End If

    End Sub

#End Region

    Private Sub Fechas_No_Permitidas()
        DS04.Reset()
        Dim CantidadRegistros As Integer
        Me.Btn_guardar.Enabled = True
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS_DIAS_NO_PERMITIDOS " & Compañia & ",0"
            MiddleConnection()
            DataAdapter.Fill(DS04)
            If (DS04.Tables.Item(0).Rows.Count) <= 0 Then
                'MessageBox.Show("No hay registros que mostrar...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                CantidadRegistros = DS04.Tables(0).Rows(0).Item(0)
                'MsgBox(CantidadRegistros)
            End If
            DS04.Reset()
            'OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS_DIAS_NO_PERMITIDOS " & Compañia & ",1"
            MiddleConnection()
            DataAdapter.Fill(DS04)
            If (DS04.Tables.Item(0).Rows.Count) <= 0 Then
                'MessageBox.Show("No hay registros que mostrar...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else

                For i As Integer = 0 To CantidadRegistros - 1
                    'MsgBox("Pocision: " & (i + 1) & ": " & DS04.Tables(0).Rows(i).Item(0))
                    If Val(Me.DateTimePicker1.Value.Day) = Val(DS04.Tables(0).Rows(i).Item(0)) Then
                        Me.Btn_guardar.Enabled = False
                        If Me.TxtSoNombre.Text <> Nothing And Me.TxtSoApellido.Text <> Nothing Then
                            MessageBox.Show("No se permite el trámite de retiros de ahorros en esta fecha...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                Next

            End If
            'Me.TxtCodAS.Text = DS.Tables(0).Rows(0).Item(2)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click

        ParamcodigoAs = ""
        ParamcodigoBux = 0
        If Me.TxtSoNombre.Text <> Nothing Then
            DS.Reset()
        End If
        If Trim(Me.TxtCodAS.Text) <> "" Or Trim(Me.TxtCodBuxy.Text) <> "" Then
            BusquedaDatosSocios()
        Else
            Dim Prin As New FrmBuscarSocios
            Prin.ShowDialog(Me)
            If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
                Me.TxtCodBuxy.Text = ParamcodigoBux
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios()
            End If
        End If

    End Sub

    Private Sub BusquedaDatosSocios()
        DS.Reset()
        Dim CodAS, Accion As String
        Dim CBuxi As Integer
        CodAS = ""
        Accion = ""
        If Trim(Me.TxtCodAS.Text) = Nothing And Val(Me.TxtCodBuxy.Text) <= 0 Then
            MessageBox.Show("Ingrese al menos un CODIGO" & Chr(13) & "CODIGO AS O CODIGO BUXI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtCodAS.Focus()
            Exit Sub
        ElseIf Trim(Me.TxtCodAS.Text) <> Nothing Or Val(Me.TxtCodBuxy.Text) > 0 Then
            CodAS = Me.TxtCodAS.Text.Trim
            CBuxi = Val(Me.TxtCodBuxy.Text)
            If CodAS <> Nothing And CBuxi <= 0 Then
                Accion = "cas"
                'CBuxi = 1
            ElseIf CodAS = Nothing And CBuxi > 0 Then
                Accion = "cbuxi"
                'CodAS = "1"
            ElseIf CodAS <> Nothing And CBuxi > 0 Then
                Accion = "ambos"
            End If
        End If
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','" & CodAS & "','" & Accion & "'"
            MiddleConnection()
            DataAdapter.Fill(DS)
            If (DS.Tables.Item(0).Rows.Count) <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DisableEnableControls(True)
                Me.TxtCodAS.Text = ""
                Me.TxtCodBuxy.Text = ""
                Hay_Datos = False
                Exit Sub
            Else
                DisableEnableControls(False)
            End If
            Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & DS.Tables(0).Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & DS.Tables(0).Rows(0).Item(3))
            If Not Permitir.Contains(Origen.ToString()) Then
                MsgBox("No esta autorizado a procesar este código", MsgBoxStyle.Information, DS.Tables(0).Rows(0).Item(3) & " - " & DS.Tables(0).Rows(0).Item(2))
                DisableEnableControls(True)
                Hay_Datos = False
                Return
            Else
                DisableEnableControls(False)
            End If
            Hay_Datos = True
            Me.TxtCodAS.Text = DS.Tables(0).Rows(0).Item(2)
            Me.TxtCodBuxy.Text = DS.Tables(0).Rows(0).Item(3)
            Me.TxtSoNombre.Text = DS.Tables(0).Rows(0).Item(4)
            Me.TxtSoApellido.Text = DS.Tables(0).Rows(0).Item(5)
            Me.TxtDUI.Text = DS.Tables(0).Rows(0).Item(15)
            Me.TxtNit.Text = DS.Tables(0).Rows(0).Item(16)
            Me.TxtDivision.Text = DS.Tables(0).Rows(0).Item(6)
            Me.TxtDepto.Text = DS.Tables(0).Rows(0).Item(7)
            Me.TxtSeccion.Text = DS.Tables(0).Rows(0).Item(8)
            Me.TxtCargo.Text = DS.Tables(0).Rows(0).Item(9)
            Me.TxtBanco_nombre.Text = DS.Tables(0).Rows(0).Item(10)
            Me.TxtBanco_cod.Text = DS.Tables(0).Rows(0).Item(25)
            Me.TxtBanco_cuenta.Text = DS.Tables(0).Rows(0).Item(11)
            SalarioMensual = DS.Tables(0).Rows(0).Item(19)

            Asociacion_AhorrosOrdinarioExtraordinario()
            UltimoRetiroAhorros()
            'BusquedaBancos()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub BusquedaBancos()

        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','SDB'"
            MiddleConnection()
            DataAdapter.Fill(DS06)
            If (DS06.Tables.Item(0).Rows.Count) <= 0 Then
                DisableEnableControls(True)
                Exit Sub
            End If

            Me.TxtBanco_cod.Text = DS06.Tables(0).Rows(0).Item(0)
            Me.TxtBanco_nombre.Text = DS06.Tables(0).Rows(0).Item(1)
            If (DS06.Tables(0).Rows(0).Item(0)) = 0 Then
                Me.TxtBanco_cuenta.Text = "Sin cuenta "
            Else
                Me.TxtBanco_cuenta.Text = DS06.Tables(0).Rows(0).Item(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.TxtCantidad_retirar.Enabled = False
            Me.TxtCantidad_retirar.Text = Me.TxtTotalAhorro_ExtraOrdinario.Text
            Me.Btn_ah_limpiar.Enabled = False
        Else
            Me.TxtCantidad_retirar.Enabled = True
            Me.Btn_ah_limpiar.Enabled = True
            BorrarCajasTexto(2)
        End If
    End Sub

    Private Sub TxtCantidad_retirar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad_retirar.KeyPress
        Dim cadena As String = TxtCantidad_retirar.Text
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

    Private Sub TxtCodAS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress, TxtCodAS.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodAS.Text.Length > 0 Or Me.TxtCodBuxy.Text.Length > 0 Then
                If Me.TxtCodAS.Text.Length > 0 Then
                    Me.TxtCodAS.Text = Me.TxtCodAS.Text.PadLeft(6, "0")
                End If
                ParamcodigoAs = Me.TxtCodAS.Text
                ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
                BusquedaDatosSocios()
            End If
        End If
    End Sub

#Region "Retiro Ahorros Socio"

    Sub RetiroAhorro() 'almacenamiento de retiro de ahorro en tabla cooperativa_socio_retiros
        DS09.Reset()
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS 0," & Compañia & "," & Me.TxtBanco_cod.Text & "," & IIf(Val(Me.TxtBanco_cod.Text) = 0, "6", "3") & ",'" & Me.TxtBanco_cuenta.Text & "'," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "'," & Me.TxtCantidad_retirar.Text & ",1,'" & Usuario & "','" & Format(Me.DateTimePicker1.Value, "dd/MM/yyyy") & "','I'"
            MiddleConnection()
            DataAdapter.Fill(DS09)
            If UCase(DS09.Tables(0).Rows(0).Item(0)) = UCase("Existe") Then
                MessageBox.Show("Ya existe un trámite de Retiro y está en proceso de Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                MessageBox.Show("El trámite de retiro de ahorros del socio ha sido agregado exitosamente!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                BorrarCajasTexto(3) : BorrarCajasTexto(2) : BorrarCajasTexto(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            RegistrosEmitidos()
            CloseConnection()
        End Try
    End Sub

    Sub RegistrosEmitidos() 'Cantidad de registros emitidos

        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS 0," & Compañia & ",2,0,'4',5,'6',7,8,'" & Usuario & "','" & Today & "','SR'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            Dim datareader_ As SqlDataReader
            datareader_ = Comando_Track.ExecuteReader()
            If datareader_.Read = True Then
                Me.TxtRetiros_cantidad.Text = (datareader_.Item(0))
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try

    End Sub

#End Region

    Private Sub Btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_guardar.Click

        If Me.DateTimePicker1.Value < Now.Date Then
            MessageBox.Show("La fecha seleccionada no puede ser menor a la fecha actual", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.DateTimePicker1.Focus()
            Exit Sub
        End If

        If Val(Me.TxtDiasFaltantes.Text) > 0 Then
            If MessageBox.Show("El socio aun no puede realizar su retiro de ahorro extraordinario" & Chr(13) & "Desea hacer dicha excepción...???", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Btn_guardar_Click02()
            End If
        Else
            Btn_guardar_Click02()
        End If
    End Sub

    Sub Btn_guardar_Click02()
        Dim msgbResultado As MsgBoxResult
        If Val(Me.TxtCantidad_retirar.Text) > Val(Me.TxtTotalAhorro_ExtraOrdinario.Text) Or Val(Me.TxtCantidad_retirar.Text) <= 0 Then
            MessageBox.Show("La cantidad a retirar no puede ser mayor a la que el socio posee" & Chr(13) & "Ni menores o iguales a cero ''0''", _
            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If Me.TxtCantidad_retirar.Text <= 5 Then
                msgbResultado = MessageBox.Show("Recuerde que la cantidad menor para realizar un cheque es de ''1.25'' menos el descuento de ''25 centavos'' " & _
                                                "y para realizar remesas la cantidad mínima es de ''5''", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            RetiroAhorro()
            PorcentajeAhorroSocioInsertar()
        End If
    End Sub

    Sub PorcentajeAhorroSocioInsertar()
        If Me.RdbAhorro_nocontinuar.Checked = True Then
            Try
                OpenConnection()
                SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_PORCENTAJE_AHORRO_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "',5," & Val(SalarioMensual * 0.05) & ",'" & Usuario & "','I'"
                MiddleConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

    Private Sub socio_ahorro_retiro_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class
