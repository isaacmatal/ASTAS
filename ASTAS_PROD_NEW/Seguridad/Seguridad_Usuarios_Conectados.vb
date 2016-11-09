Public Class Seguridad_Usuarios_Conectados
    Dim c_data1 As New jarsClass
    Dim sqlcmd As New SqlClient.SqlCommand

    Private Sub Seguridad_Usuarios_Conectados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        Me.btnRefresh.PerformClick()
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuariosConectados.CellEnter
        txtUsrMsj.Text = ""
        Try
            txtUsrMsj.Text = dgvUsuariosConectados.CurrentRow.Cells(0).Value.ToString()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BotonEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If txtUsrMsj.Text <> "" Then
            If txtMensaje.Text <> "" Then
                c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_ENVIO='" & Usuario & "', @USUARIO_RECEPCION='" & txtUsrMsj.Text & "', @MENSAJE='" & txtMensaje.Text & "', @ESTADO=1, @ASUNTO='" & txtMsjAsunto.Text & "', @BANDERA='I'")
                txtUsrMsj.Text = ""
                txtMensaje.Text = ""
                MsgBox("Mensaje Enviado")
            Else
                MsgBox("No se ha escrito mensaje")
            End If
        Else
            MsgBox("No se ha seleccionado usuario")
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.dgvUsuariosConectados.DataSource = c_data1.ejecutaSQLl_llenaDTABLE("EXECUTE SP_USUARIOS_CONECTADOS_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='S'")
        Me.dgvUsuariosConectados.Columns(0).HeaderText = "Usuarios (" & Me.dgvUsuariosConectados.Rows.Count & ")"
    End Sub

    Private Sub btnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOut.Click
        If Me.txtUsrMsj.Text.Length > 0 Then
            If MsgBox("El usuario " & Me.txtUsrMsj.Text & " será desconectado." & vbCrLf & vbCrLf & "¿Desea Continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Desconectar usuario") = MsgBoxResult.Yes Then
                sqlcmd.CommandText = "EXECUTE SP_USUARIOS_CONECTADOS_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO=" & Me.txtUsrMsj.Text & ", @BANDERA='U', @HOST='" & Me.dgvUsuariosConectados.CurrentRow.Cells(4).Value & "', @IPADDRESS='" & Me.dgvUsuariosConectados.CurrentRow.Cells(5).Value & "',  @INSTANCIA = " & Me.dgvUsuariosConectados.CurrentRow.Cells(8).Value & ", @VERSION = '" & Me.dgvUsuariosConectados.CurrentRow.Cells(7).Value & "'"
                If c_data1.ejecutarComandoSql(sqlcmd) > 0 Then
                    Me.dgvUsuariosConectados.CurrentRow.DefaultCellStyle.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub Seguridad_Usuarios_Conectados_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.btnRefresh.PerformClick()
    End Sub
End Class