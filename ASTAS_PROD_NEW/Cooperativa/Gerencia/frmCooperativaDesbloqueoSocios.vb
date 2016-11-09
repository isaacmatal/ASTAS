Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCooperativaDesbloqueoSocios

    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim CodBuxis, Origen As Integer
    Dim Sql As String
    Dim Table As DataTable
    Dim TableReporte As New DataTable("noaplicados")
    Dim FPro As New Facturacion_Procesos


    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New ReporteDescuentoNoBuxis
        Dim Rpt1 As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        If CodBuxis = 0 Then
            rpt = New ReporteDescuentoNoBuxis
            TextObj = rpt.Section3.ReportObjects.Item("txtOrigen")
            TextObj.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & Origen)
            TextObj = rpt.Section3.ReportObjects.Item("txtEmpresa")
            TextObj.Text = Descripcion_Compañia
            rpt.SetDataSource(Me.dgvNoAplicados.DataSource)
            frmVer.ReportesGenericos(rpt)
        Else
            Rpt1 = New CooperativaReporteDescuentosNoAplicados
            TextObj = Rpt1.Section2.ReportObjects.Item("Text13")
            TextObj.Text = Descripcion_Compañia
            Rpt1.SetDataSource(Me.dgvNoAplicados.DataSource)
            frmVer.ReportesGenericos(Rpt1)
        End If
        frmVer.crvReporte.DisplayGroupTree = False
        frmVer.ShowDialog()
    End Sub

    Private Sub CargaRegistros(ByVal opcion As Integer)
        Try
            If opcion = 4 Then
                Sql = "EXECUTE [Coo].[sp_COOPERATIVA_SOLICITUDES_PARA_BUXIS] "
                Sql &= "@COMPAÑIA = " & Compañia & ", "
                Sql &= "@BANDERA = " & opcion & ", "
                Sql &= "@FECHA_PERIODO = '" & dtpFechaPago.Value.ToShortDateString & "', "
                Sql &= "@ORIGEN = " & Origen & ", "
                Sql &= "@CODAS = '" & Me.txtCodigo.Text & "', "
                Sql &= "@CODBUXIS = " & CodBuxis
            Else
                Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS] "
                Sql &= "@COMPAÑIA = " & Compañia & ", "
                Sql &= "@FECHA_PERIODO = '" & dtpFechaPago.Value.ToShortDateString & "', "
                Sql &= "@NUM_SOLICITUD = 0, "
                Sql &= "@BANDERA = 9, "
                Sql &= "@CODAS = '" & Me.txtCodigo.Text & "', "
                Sql &= "@CODBUXIS = " & CodBuxis
            End If
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            LlenarGrid(Table)
            Try
                Me.txtAplic.Text = "$" & Format(Table.Compute("Sum(IMPTOT_HD)", "APLICADO"), "#,##0.00").PadLeft(9, " ")
            Catch exAplic As Exception
                Me.txtAplic.Text = "$     0.00"
            End Try
            Try
                Me.txtNoAplic.Text = "$" & Format(Table.Compute("Sum(IMPTOT_HD)", "NOT APLICADO"), "#,##0.00").PadLeft(9, " ")
            Catch excNoAplic As Exception
                Me.txtNoAplic.Text = "$     0.00"
            End Try
            Try
                Me.txtTotalDesc.Text = "$" & Format(Table.Compute("Sum(IMPTOT_HD)", ""), "#,##0.00").PadLeft(9, " ")
            Catch excTotal As Exception
                Me.txtTotalDesc.Text = "$     0.00"
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
        End Try
    End Sub

    Private Sub LlenarGrid(ByVal TableGrid As DataTable)
        Me.dgvNoAplicados.Columns.Clear()
        Me.dgvNoAplicados.DataSource = TableGrid
        If CodBuxis = 0 Then
            Me.dgvNoAplicados.Columns(0).Visible = False 'Fecha Pago
            Me.dgvNoAplicados.Columns(1).Visible = False 'Compañia
            Me.dgvNoAplicados.Columns(2).Width = 50 'Nº Solicitud
            Me.dgvNoAplicados.Columns(4).Visible = False 'Codigo Buxis
            Me.dgvNoAplicados.Columns(5).Width = 55 'Codigo AS 
            Me.dgvNoAplicados.Columns(7).Width = 60 'Monto
            Me.dgvNoAplicados.Columns(8).Width = 85 'Abono Capital
            Me.dgvNoAplicados.Columns(9).Visible = False 'Abono Intereses
            Me.dgvNoAplicados.Columns(10).Visible = False 'Seguro Deuda
            Me.dgvNoAplicados.Columns(11).Visible = False 'Cuota
            Me.dgvNoAplicados.Columns(12).Width = 50 'Nº Cuotas
            Me.dgvNoAplicados.Columns(13).Width = 70 'Cuota a Descontar
            Me.dgvNoAplicados.Columns(14).Width = 90 'Periodo
            Me.dgvNoAplicados.Columns(15).Width = 90 'Fecha Inicio Prestamo
            Me.dgvNoAplicados.Columns(16).Width = 90 'Fecha Primer Pago
            Me.dgvNoAplicados.Columns(17).Width = 60 'No.Factura
            Me.dgvNoAplicados.Columns(18).Width = 50 'Pagado?
            Me.dgvNoAplicados.Columns(9).DefaultCellStyle.ForeColor = Color.Blue
            Me.dgvNoAplicados.Columns(7).DefaultCellStyle.ForeColor = Color.Red
            Me.dgvNoAplicados.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNoAplicados.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNoAplicados.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns.Item(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns.Item(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For i As Integer = 1 To Me.dgvNoAplicados.Columns.Count - 1
                Me.dgvNoAplicados.Columns(i).ReadOnly = True
            Next
        Else
            Me.dgvNoAplicados.Columns(3).HeaderText = "Nº Solicitud"
            Me.dgvNoAplicados.Columns(8).HeaderText = "Valor Descuento"
            Me.dgvNoAplicados.Columns(9).HeaderText = "Aplicado"
            Me.dgvNoAplicados.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dgvNoAplicados.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            Me.dgvNoAplicados.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dgvNoAplicados.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvNoAplicados.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvNoAplicados.Columns(10).Visible = False
            Me.dgvNoAplicados.Columns(0).Width = 80
            Me.dgvNoAplicados.Columns(1).Width = 70
            Me.dgvNoAplicados.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNoAplicados.Columns(3).Width = 70
            Me.dgvNoAplicados.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNoAplicados.Columns(5).Width = 60
            Me.dgvNoAplicados.Columns(6).Width = 60
            Me.dgvNoAplicados.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNoAplicados.Columns(8).Width = 80
            Me.dgvNoAplicados.Columns(8).DefaultCellStyle.Format = "$ #,##0.00"
            Me.dgvNoAplicados.Columns(9).Width = 50
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress, txtCodBuxis.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            cargaStatus()
        End If
    End Sub

    Private Sub cargaStatus()
        Dim establoqueado As Boolean
        Dim mensaje As String = ""
        Dim SocioDatos, SolicActivas As DataTable
        If Me.txtCodigo.Text <> Nothing Or Me.txtCodBuxis.Text <> Nothing Then
            Me.dgvNoAplicados.DataSource = Nothing
            Me.txtCodigo.Text = Me.txtCodigo.Text.PadLeft(6, "0")
            Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ORIGEN, BLOQUEADO, MOTIVO_BLOQUEO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia
            If Me.txtCodBuxis.Text <> Nothing Then
                Sql &= " AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text
            Else
                Sql &= " AND CODIGO_EMPLEADO_AS = '" & Me.txtCodigo.Text & "'"
            End If
            sqlCmd.CommandText = Sql
            SocioDatos = jClass.obtenerDatos(sqlCmd)
            If SocioDatos.Rows.Count > 0 Then
                CodBuxis = SocioDatos.Rows(0).Item("CODIGO_EMPLEADO")
                Me.txtCodBuxis.Text = CodBuxis
                lblNombre.Text = SocioDatos.Rows(0).Item("NOMBRE_COMPLETO")
                Origen = SocioDatos.Rows(0).Item("ORIGEN")
                establoqueado = SocioDatos.Rows(0).Item("BLOQUEADO")
                Me.txtMotivo.Text = SocioDatos.Rows(0).Item("MOTIVO_BLOQUEO")
                Me.txtCodigo.Text = SocioDatos.Rows(0).Item("CODIGO_EMPLEADO_AS")
                Me.txtCodBuxis.Text = SocioDatos.Rows(0).Item("CODIGO_EMPLEADO")
                Me.txtmonto.Enabled = True
                Me.btmDesbloqueo.Enabled = True
                Me.btnReporte.Enabled = True
                'If CodBuxis > 0 Then
                CargaRegistros(5)
                'Else
                '    CargaRegistros(4)
                'End If
                If establoqueado Then
                    Sql = "   SELECT S.DESCRIPCION_SOLICITUD, A.MONTO_MAXIMO " & vbCrLf
                    Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A, COOPERATIVA_CATALOGO_SOLICITUDES S" & vbCrLf
                    Sql &= "   WHERE A.COMPAÑIA = S.COMPAÑIA AND A.SOLICITUD = S.SOLICITUD" & vbCrLf
                    Sql &= "     AND A.COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "     AND A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
                    Sql &= "     AND A.MONTO_MAXIMO > 0" '& vbCrLf
                    'Sql &= "     AND CONVERT(DATE, A.VIGENTE_HASTA) >= CONVERT(DATE, '" & Format(Now, "dd/MM/yyyy") & "', 103)"
                    sqlCmd.CommandText = Sql
                    SolicActivas = jClass.obtenerDatos(sqlCmd)
                    Me.txtmonto.Enabled = True
                    Me.btmDesbloqueo.Enabled = True
                    mensaje = "El socio está bloqueado" & vbCrLf
                    If SolicActivas.Rows.Count > 0 Then
                        mensaje &= "Consumos Habilitados:" & vbCrLf
                        For i As Integer = 0 To SolicActivas.Rows.Count - 1
                            mensaje &= SolicActivas.Rows(i).Item(0).ToString() & " - MONTO MAXIMO: $ " & Format(SolicActivas.Rows(i).Item(1), "0.00") & vbCrLf
                        Next
                    Else
                        mensaje &= "No tiene consumos habilitados."
                    End If
                    Me.btnBloquear.Enabled = False
                    Me.Button1.Visible = True
                    Me.Label7.Visible = True
                    Me.txtMotivo.Visible = True
                Else
                    Me.txtmonto.Enabled = False
                    Me.btmDesbloqueo.Enabled = False
                    Me.btnBloquear.Enabled = True
                    Me.Button1.Visible = False
                    Me.Label7.Visible = False
                    Me.txtMotivo.Visible = False
                    mensaje = "El socio no está bloqueado"
                End If
            Else
                Me.txtCodBuxis.Text = ""
                Me.lblNombre.Text = ""
                Me.Lblmensaje.Text = ""
                mensaje = ""
                Me.txtmonto.Enabled = False
                Me.btmDesbloqueo.Enabled = False
                Me.btnReporte.Enabled = False
            End If
        Else
            Me.txtCodBuxis.Text = ""
            Me.lblNombre.Text = ""
            Me.Lblmensaje.Text = ""
            mensaje = ""
            Me.txtmonto.Enabled = False
            Me.btmDesbloqueo.Enabled = False
            Me.btnReporte.Enabled = False
            Me.Label7.Visible = False
            Me.txtMotivo.Visible = False
        End If
        Me.Lblmensaje.Text = mensaje
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaPago.ValueChanged
        If Not Iniciando Then
            If txtCodigo.Text <> Nothing Then
                If CodBuxis > 0 Then
                    CargaRegistros(5)
                Else
                    CargaRegistros(4)
                End If
            End If
        End If
    End Sub

    Private Sub btmDesbloqueo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmDesbloqueo.Click
        Dim A As Integer

        If lblNombre.Text.Length > 0 Then
            If MsgBox("¿Está seguro(a) que desea Desbloquear a " & Me.lblNombre.Text.ToString & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                'Inicio desbloqueo
                Sql = "UPDATE COOPERATIVA_CATALOGO_SOCIOS SET BLOQUEADO = 0, MOTIVO_BLOQUEO = '', BLOQUEO_MANUAL = 0 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text
                sqlCmd.CommandText = Sql
                A = jClass.ejecutarComandoSql(sqlCmd)
                If A > 0 Then
                    Sql &= "  UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
                    Sql &= "     SET [MONTO_MAXIMO] = 0" & vbCrLf
                    Sql &= "        ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
                    Sql &= "        ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
                    Sql &= "   WHERE COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "     AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                    MsgBox(lblNombre.Text & " DESBLOQUEADO CON EXITO", MsgBoxStyle.Information, "Información")
                Else
                    MsgBox(lblNombre.Text & " NO FUE DESBLOQUEADO", MsgBoxStyle.Information, "Información")
                End If
                'Fin desbloqueo
                Me.txtCodBuxis.Clear()
                Me.txtCodigo.Clear()
                Me.txtmonto.Clear()
                Me.Lblmensaje.Clear()
                Me.lblNombre.Clear()
                Me.txtCodBuxis.Focus()
            End If
        End If
        cargaStatus()
    End Sub

    Private Function validar() As Integer
        Dim valido As Integer
        'valido = 1 SI    valido = 0 NO
        valido = 1
        Return valido
    End Function

    Private Function mensaje() As String
        Dim texto As String
        texto = " desbloqueo completo"
        Return texto
    End Function

    Private Sub txtmonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        Dim cadena As String = Me.txtmonto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btmDesbloqueo.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub frmCooperativaDesbloqueoSocios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtmonto.Enabled = False
        Me.btmDesbloqueo.Enabled = False
        Me.btnReporte.Enabled = False
    End Sub

    Private Sub frmCooperativaDesbloqueoSocios_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnBloquear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBloquear.Click
        Dim strMotivo As String
        If lblNombre.Text.Length > 0 Then
            strMotivo = InputBox("Ingrese la razón de Bloqueo del empleado" & vbCrLf & "(Máximo 500 caracteres)", "Motivo Bloqueo")
            Me.txtMotivo.Text = strMotivo
            If Me.txtMotivo.Text.Length > 0 Then
                Sql = "UPDATE COOPERATIVA_CATALOGO_SOCIOS SET BLOQUEADO = 1, MOTIVO_BLOQUEO = '" & Me.txtMotivo.Text & "', BLOQUEO_MANUAL = 1 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text
                sqlCmd.CommandText = Sql
                If jClass.ejecutarComandoSql(sqlCmd) > 0 Then
                    MsgBox(lblNombre.Text & " BLOQUEADO CON EXITO", MsgBoxStyle.Information, "Información")
                    'Me.txtCodBuxis.Clear()
                    'Me.txtCodigo.Clear()
                    'Me.txtmonto.Clear()
                    Me.Lblmensaje.Text = "Socio bloqueado"
                    'Me.lblNombre.Clear()
                    'Me.txtCodBuxis.Focus()
                    Me.Button1.Visible = True
                    cargaStatus()
                Else
                    MsgBox(lblNombre.Text & " NO FUE BLOQUEADO", MsgBoxStyle.Information, "Información")
                End If
            Else
                MsgBox("Debe ingresar un motivo de bloqueo.", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.txtCodBuxis.Clear()
        Me.txtCodigo.Clear()
        Me.txtmonto.Clear()
        Me.Lblmensaje.Clear()
        Me.lblNombre.Clear()
        Me.txtCodBuxis.Focus()
        Me.Label7.Visible = False
        Me.txtMotivo.Visible = False
        Me.dgvNoAplicados.DataSource = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frmaccess As New CooperativaAccesoBloqueoConsumo(Me.txtCodBuxis.Text, Me.lblNombre.Text)
        frmaccess.ShowDialog()
        cargaStatus()
    End Sub

    Private Sub btnRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRep.Click
        Dim TableRep As DataTable
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New CooperativaReporteEmpleadosBloqueados
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Sql = "SELECT dbo.PadLeft( SOC.CODIGO_EMPLEADO,'0',5) AS CODIGO_EMPLEADO, " & vbCrLf
        Sql &= "       SOC.NOMBRE_COMPLETO," & vbCrLf
        Sql &= "	   SOC.MOTIVO_BLOQUEO, " & vbCrLf
        Sql &= "	   ISNULL(S.DESCRIPCION_SOLICITUD  + ' POR $ ' + CONVERT(VARCHAR, A.MONTO_MAXIMO),'NO TIENE CREDITO AUTORIZADO') AS [CREDITOS AUTORIZADOS]" & vbCrLf
        Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
        Sql &= "       LEFT JOIN COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO A ON A.COMPAÑIA = SOC.COMPAÑIA AND A.CODIGO_EMPLEADO = SOC.CODIGO_EMPLEADO AND A.MONTO_MAXIMO > 0" & vbCrLf
        Sql &= "       LEFT JOIN COOPERATIVA_CATALOGO_SOLICITUDES S ON A.COMPAÑIA = S.COMPAÑIA AND A.SOLICITUD = S.SOLICITUD" & vbCrLf
        Sql &= " WHERE SOC.COMPAÑIA = 1" & vbCrLf
        Sql &= "   AND SOC.BLOQUEADO = 1" & vbCrLf
        Sql &= "   AND SOC.ESTATUS > 0"
        TableRep = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(TableRep)
        txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        frmVer.ReportesGenericos(rpt)
        frmVer.ShowDialog()
    End Sub
End Class