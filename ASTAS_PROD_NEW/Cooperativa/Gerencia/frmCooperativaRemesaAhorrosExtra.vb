Imports System.Data
Imports System.Data.SqlClient

Public Class frmCooperativaRemesaAhorrosExtra
    Dim jClass As New jarsClass
    Dim query As String
    Dim Comando_Track As New SqlCommand
    Dim Table As DataTable

    Private Sub frmCooperativaRemesaAhorrosExtra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBancos(Compañia, cmbBancos)
        If cmbBancos.Items.Count > 0 Then
            cmbBancos.SelectedIndex = 0
        End If
    End Sub

    Private Sub GuardaAbono()
        Dim corrAbono As Integer
        query = "EXECUTE [dbo].[sp_COOPERATIVA_ABONOS]" & vbCrLf
        query &= " @COMPAÑIA = " & Compañia & vbCrLf
        query &= ", @SOLICITUD = 0" & vbCrLf
        query &= ", @CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
        query &= ", @CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & vbCrLf
        query &= ", @CANTIDAD_ABONADA = " & Me.txtAbono.Text & vbCrLf
        query &= ", @ABONO_INTERES = 0" & vbCrLf
        query &= ", @ABONO_SEG_DEUDA = 0" & vbCrLf
        query &= ", @ABONO_CAPITAL = 0" & vbCrLf
        query &= ", @DEUDA_SALDADA = 1" & vbCrLf
        query &= ", @ABONO_REMESA = 0" & vbCrLf
        query &= ", @ABONO_AHORRO_EXTRA = 1" & vbCrLf
        query &= ", @BANCO_REMESA = " & Me.cmbBancos.SelectedValue & vbCrLf
        query &= ", @NUM_REMESA = '" & Me.txtNoRemesa.Text & "'" & vbCrLf
        query &= ", @USUARIO = " & Usuario & vbCrLf
        query &= ", @BANDERA = 1"
        Comando_Track.CommandText = query
        jClass.ejecutarComandoSql(Comando_Track)
        query = "SELECT ISNULL(MAX(CORRELATIVO),0) AS CORRELATIVO FROM COOPERATIVA_SOLICITUDES_ABONOS" & vbCrLf
        query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        query &= " AND CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
        query &= " AND CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text
        corrAbono = CInt(jClass.obtenerEscalar(query))
        query = "UPDATE COOPERATIVA_SOLICITUDES_ABONOS " & vbCrLf
        query &= "SET FECHA_ABONO = '" & Format(Me.dtpFechaAbono.Value, "dd/MM/yyyy") & "'" & vbCrLf
        query &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        query &= " AND CODIGO_AS = '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
        query &= " AND CODIGO_BUXIS = " & Me.TxtCodigoBuxis.Text & vbCrLf
        query &= " AND CORRELATIVO = " & corrAbono
        Comando_Track.CommandText = query
        jClass.ejecutarComandoSql(Comando_Track)
    End Sub

    Private Sub retirarDelExtra()
        Dim rowsAffected As Integer
        query = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_IUD " & vbCrLf
        query &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
        query &= " @CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & "," & vbCrLf
        query &= " @CODIGO_EMPLEADO_AS = '" & Me.TxtCodigoAs.Text & "'," & vbCrLf
        query &= " @FECHA_AHORRO = '" & Format(Me.dtpFechaAbono.Value, "dd/MM/yyyy") & "'," & vbCrLf
        query &= " @CUOTA_EXTRAORDINARIO = " & Me.txtAbono.Text.Trim & "," & vbCrLf
        query &= " @USUARIO = '" & Usuario & "'," & vbCrLf
        query &= " @IUD = 'I'"
        Comando_Track.CommandText = query
        rowsAffected = jClass.ejecutarComandoSql(Comando_Track)
        If rowsAffected > 0 Then
            Me.TxtSaldoE.Text = Format(Val(Me.TxtSaldoE.Text.Replace(",", "")) + Val(Me.txtAbono.Text), "#,###.00")
            If Val(Me.txtAbono.Text.Replace(",", "")) < 0 Then
                generaRecibo()
            End If
        End If
    End Sub

    Private Sub generaRecibo()
        Dim idRetiro As Integer
        Dim frmver As New frmReportes_Ver
        Dim RptAhorro As New rpt_reporte_cooperativa_retiro_ahorro_recibo1
        Dim VLetras As New NumeroLetras
        Dim TableAho As DataTable
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        'insertar registro en COOPERATIVA_SOCIO_RETIRO
        idRetiro = jClass.obtenerEscalar("SELECT ISNULL(MAX([RETIRO]), 0) + 1 FROM [dbo].[COOPERATIVA_SOCIO_RETIROS] WHERE COMPAÑIA = " & Compañia)
        query = "INSERT INTO [dbo].[COOPERATIVA_SOCIO_RETIROS]"
        query &= "    ([RETIRO]"
        query &= "    ,[COMPAÑIA]"
        query &= "    ,[CODIGO_EMPLEADO]"
        query &= "    ,[CODIGO_EMPLEADO_AS]"
        query &= "    ,[BANCO]"
        query &= "    ,[BANCO_NOMBRE]"
        query &= "    ,[CUENTA]"
        query &= "    ,[CANTIDAD]"
        query &= "    ,[ESTADO]"
        query &= "    ,[BANCO_EMITIDO]"
        query &= "    ,[TIPO_CUENTA_EMITIDO]"
        query &= "    ,[CUENTA_EMITIDO]"
        query &= "    ,[TIPO_DOCUMENTO]"
        query &= "    ,[USUARIO_CREACION]"
        query &= "    ,[USUARIO_CREACION_FECHA]"
        query &= "    ,[USUARIO_MODIFICACION]"
        query &= "    ,[USUARIO_MODIFICACION_FECHA]"
        query &= "    ,[SELECIONADO]"
        query &= "    ,[NUMERO]"
        query &= "    ,[FUR]"
        query &= "    ,[CUENTA_CONTABLE_BANCO]"
        query &= "    ,[TRANSACCION]"
        query &= "    ,[PARTIDA]"
        query &= "    ,[COMENTARIO]"
        query &= "    ,[INTERES_DESDE]"
        query &= "    ,[INTERES_HASTA]"
        query &= "    ,[TOTAL_INTERESES]"
        query &= "    ,[TOTAL_SEGURO_DEUDA]"
        query &= "    ,[TOTAL_DEUDAS]"
        query &= "    ,[TOTAL_AHORRO_ORDINARIO]"
        query &= "    ,[TOTAL_AHORRO_EXTRAORDINARIO]"
        query &= "    ,[RETIRO_ASOCIACION]"
        query &= "    ,[PORCENTAJE_ESCOLARIDAD]"
        query &= "    ,[TOTAL_ESCOLARIDAD]"
        query &= "    ,[PORCENTAJE_RENTA]"
        query &= "    ,[TOTAL_RENTA])"
        query &= "VALUES("
        query &= "    " & idRetiro & vbCrLf
        query &= "    ," & Compañia & vbCrLf
        query &= "    ," & Me.TxtCodigoBuxis.Text & vbCrLf
        query &= "    ,'" & Me.TxtCodigoAs.Text & "'" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,''" & vbCrLf
        query &= "    ,''" & vbCrLf
        query &= "    ," & Me.txtAbono.Text.Replace("-", "") & vbCrLf
        query &= "    ,3" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,'PAGADO EN EFECTIVO'" & vbCrLf
        query &= "    ,'CAJA CHICA'" & vbCrLf
        query &= "    ,46" & vbCrLf
        query &= "    ,'" & Usuario & "'" & vbCrLf
        query &= "    ,GETDATE()" & vbCrLf
        query &= "    ,'" & Usuario & "'" & vbCrLf
        query &= "    ,GETDATE()" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,NULL" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,'RETIRO AHORRO EXTRA PAGADO EN EFECTIVO'" & vbCrLf
        query &= "    ,NULL" & vbCrLf
        query &= "    ,NULL" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0" & vbCrLf
        query &= "    ,0)" & vbCrLf
        If jClass.ejecutarComandoSql(New SqlCommand(query)) > 0 Then
            'insertar registro en COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO
            query = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO]" & vbCrLf
            query &= "  @COMPAÑIA	= " & Compañia & vbCrLf
            query &= " ,@RETIRO		= " & idRetiro & vbCrLf
            query &= " ,@COD_BU		= " & Me.TxtCodigoBuxis.Text & vbCrLf
            query &= " ,@COD_AS		= '" & Me.TxtCodigoAs.Text & "'" & vbCrLf
            query &= " ,@SIUD		= 'Insertar'" & vbCrLf
            query &= " ,@MONTO_LETRAS = '" & VLetras.Letras(Me.txtAbono.Text.Replace("-", "")) & "'" & vbCrLf
            If jClass.ejecutarComandoSql(New SqlCommand(query)) > 0 Then
                query = "SELECT * FROM VISTA_COOPERATIVA_SOCIOS_RETIROS_CARTAS_CHEQUES" & vbCrLf
                query &= " WHERE COMPAÑIA=" & Compañia & " AND RETIRO = " & idRetiro
                TableAho = jClass.obtenerDatos(New SqlCommand(query))
                RptAhorro.SetDataSource(TableAho)
                If Origen = 5 Or Origen = 6 Then
                    RptAhorro.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                    RptAhorro.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                    RptAhorro.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                    RptAhorro.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                    txtObj = RptAhorro.Section3.ReportObjects.Item("Text22")
                    txtObj.Text = "NIT 0501-200694-101-6"
                End If
                frmver.ReportesGenericos(RptAhorro)
                frmver.ShowDialog()
            End If
        End If
    End Sub

    Private Sub frmCooperativaRemesaAhorrosExtra_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub BuscaSocio()
        Try
            Comando_Track.CommandText = "EXECUTE Coo.sp_COOPERATIVA_BUSQUEDA_SOCIO '" & Trim(ParamcodigoAs) & "', " & Trim(ParamcodigoBux) & "," & Compañia
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                TxtCodigoAs.Text = Table.Rows(0).Item(0)
                TxtCodigoBuxis.Text = Table.Rows(0).Item(1)
                TxtNombre.Text = Table.Rows(0).Item(2)
                Me.TxtSaldoE.Text = Format(jClass.obtenerEscalar("SELECT [AHORRO EXTRAORDINARIO] FROM VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO WHERE CODIGO_EMPLEADO = " & Me.TxtCodigoBuxis.Text & " AND CODIGO_EMPLEADO_AS = '" & Me.TxtCodigoAs.Text & "' AND COMPAÑIA = " & Compañia), "#,##0.00")
            Else
                MsgBox("No se encontró código", MsgBoxStyle.Information, "Búsqueda Falló")
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
            BuscaSocio()
        End If
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress, TxtCodigoBuxis.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodigoBuxis.Text.Length Or Me.TxtCodigoAs.Text.Length > 0 Then
                ParamcodigoAs = Me.TxtCodigoAs.Text.PadLeft(6, "0")
                ParamcodigoBux = Val(Me.TxtCodigoBuxis.Text)
                BuscaSocio()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Val(Me.txtAbono.Text) = 0 Then
            MsgBox("Abono debe ser diferente que cero", MsgBoxStyle.Information, "Validación")
            Return
        End If
        GuardaAbono()
        retirarDelExtra()
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Información")
    End Sub

    Private Sub txtAbono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbono.KeyPress
        Dim cadena As String = txtAbono.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> "-") And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            If e.KeyChar <> "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.TxtCodigoBuxis.Clear()
        Me.TxtCodigoAs.Clear()
        Me.TxtNombre.Clear()
        Me.txtNoRemesa.Clear()
        Me.TxtSaldoE.Text = "0.00"
        Me.txtAbono.Text = "0"
    End Sub
End Class