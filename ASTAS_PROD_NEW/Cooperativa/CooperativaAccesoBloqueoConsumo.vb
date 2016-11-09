Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaAccesoBloqueoConsumo
    Dim _codBuxis As Integer = 0
    Dim _Nombre As String
    Dim exceder_limite As Integer
    Dim jClass As New jarsClass
    Dim Sql As String

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        exceder_limite = 1
    End Sub
    Sub New(ByVal codBuxis, ByVal Nombre)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _codBuxis = codBuxis
        _Nombre = Nombre
        exceder_limite = 0
    End Sub
    Private Sub CooperativaAccesoBloqueoConsumo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        If exceder_limite = 0 Then
            Me.txtCodBux.Text = _codBuxis
            Me.lblEmpleado.Text = _Nombre
            cargaDatos()
        Else
            Me.btnBuscar.Visible = True
            Me.txtCodBux.Enabled = True
            Me.Text = "Exceder Limite Crédito a Empleado NO Bloqueado"
        End If
        CargaTipoSolicitudes()
    End Sub

    Private Sub CargaTipoSolicitudes()
        Dim sql As String
        Dim Table As DataTable
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_CATALOGO_SOLICITUDES] @COMPAÑIA = " & Compañia & ", @BANDERA = 1" & vbCrLf
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbTipoSolic.DataSource = Table
        Me.cmbTipoSolic.DisplayMember = "DESCRIPCION_SOLICITUD"
        Me.cmbTipoSolic.ValueMember = "SOLICITUD"
        Me.cmbTipoSolic.SelectedIndex = 0
    End Sub

    Private Sub CooperativaAccesoBloqueoConsumo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub cargaDatos()
        Try
            Dim TableData As DataTable
            Sql = "   SELECT S.DESCRIPCION_SOLICITUD, A.MONTO_MAXIMO, A.SOLICITUD, A.VIGENTE_HASTA " & vbCrLf
            Sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A, COOPERATIVA_CATALOGO_SOLICITUDES S" & vbCrLf
            Sql &= "   WHERE A.COMPAÑIA = S.COMPAÑIA AND A.SOLICITUD = S.SOLICITUD" & vbCrLf
            Sql &= "     AND A.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "     AND A.CODIGO_EMPLEADO = " & _codBuxis & vbCrLf
            Sql &= "     AND A.EXCEDER_LIMITE = " & exceder_limite & vbCrLf
            TableData = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvAccesos.DataSource = TableData
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Sql = "IF NOT EXISTS(SELECT COMPAÑIA, CODIGO_EMPLEADO, SOLICITUD FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & _codBuxis & " AND SOLICITUD = " & Me.cmbTipoSolic.SelectedValue & ")" & vbCrLf
        Sql &= "BEGIN" & vbCrLf
        Sql &= "INSERT INTO [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
        Sql &= "           ([COMPAÑIA]" & vbCrLf
        Sql &= "           ,[CODIGO_EMPLEADO]" & vbCrLf
        Sql &= "           ,[SOLICITUD]" & vbCrLf
        Sql &= "           ,[VIGENTE_HASTA]" & vbCrLf
        Sql &= "           ,[MONTO_MAXIMO]" & vbCrLf
        Sql &= "           ,[EXCEDER_LIMITE]" & vbCrLf
        Sql &= "           ,[USUARIO_CREACION]" & vbCrLf
        Sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
        Sql &= "           ,[USUARIO_EDICION]" & vbCrLf
        Sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
        Sql &= "     VALUES" & vbCrLf
        Sql &= "           (" & Compañia & vbCrLf
        Sql &= "           ," & _codBuxis & vbCrLf
        Sql &= "           ," & Me.cmbTipoSolic.SelectedValue & vbCrLf
        Sql &= "           ,'" & Format(Me.dtpVigencia.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= "           ," & Val(Me.txtMontoMax.Text) & vbCrLf
        Sql &= "           ," & exceder_limite & vbCrLf
        Sql &= "           ,'" & Usuario & "'" & vbCrLf
        Sql &= "           ,GETDATE()" & vbCrLf
        Sql &= "           ,'" & Usuario & "'" & vbCrLf
        Sql &= "           ,GETDATE())" & vbCrLf
        Sql &= "END" & vbCrLf
        Sql &= "ELSE" & vbCrLf
        Sql &= "BEGIN" & vbCrLf
        Sql &= "  UPDATE [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
        Sql &= "     SET [VIGENTE_HASTA] = '" & Format(Me.dtpVigencia.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= "        ,[MONTO_MAXIMO] = " & Val(Me.txtMontoMax.Text) & vbCrLf
        Sql &= "        ,[EXCEDER_LIMITE] = " & exceder_limite & vbCrLf
        Sql &= "        ,[USUARIO_EDICION] = '" & Usuario & "'" & vbCrLf
        Sql &= "        ,[USUARIO_EDICION_FECHA] = GETDATE()" & vbCrLf
        Sql &= "   WHERE COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "     AND CODIGO_EMPLEADO = " & _codBuxis & vbCrLf
        Sql &= "     AND SOLICITUD = " & Me.cmbTipoSolic.SelectedValue & vbCrLf
        Sql &= "END"
        If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            Sql = "INSERT INTO [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO_HISTORIAL]" & vbCrLf
            Sql &= "           ([COMPAÑIA]" & vbCrLf
            Sql &= "           ,[CODIGO_EMPLEADO]" & vbCrLf
            Sql &= "           ,[SOLICITUD]" & vbCrLf
            Sql &= "           ,[VIGENTE_HASTA]" & vbCrLf
            Sql &= "           ,[MONTO_MAXIMO]" & vbCrLf
            Sql &= "           ,[USUARIO_CREACION]" & vbCrLf
            Sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
            Sql &= "           ,[USUARIO_EDICION]" & vbCrLf
            Sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           (" & Compañia & vbCrLf
            Sql &= "           ," & _codBuxis & vbCrLf
            Sql &= "           ," & Me.cmbTipoSolic.SelectedValue & vbCrLf
            Sql &= "           ,'" & Format(Me.dtpVigencia.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ," & Val(Me.txtMontoMax.Text) & vbCrLf
            Sql &= "           ,'" & Usuario & "'" & vbCrLf
            Sql &= "           ,GETDATE()" & vbCrLf
            Sql &= "           ,'" & Usuario & "'" & vbCrLf
            Sql &= "           ,GETDATE())" & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
            cargaDatos()
            MsgBox("Registro guardado con éxito", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("Esta seguro de eliminar el registro seleccionado", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Sql = "DELETE FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO]" & vbCrLf
            Sql &= "   WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "     AND CODIGO_EMPLEADO = " & _codBuxis & vbCrLf
            Sql &= "     AND SOLICITUD = " & Me.cmbTipoSolic.SelectedValue
            If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                cargaDatos()
                MsgBox("Registro eliminado con éxito", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub dgvAccesos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellEnter
        If e.RowIndex > -1 Then
            Me.cmbTipoSolic.SelectedValue = Me.dgvAccesos.Rows(e.RowIndex).Cells("solicitud").Value
            Me.txtMontoMax.Text = Me.dgvAccesos.Rows(e.RowIndex).Cells("montomax").Value
            Me.dtpVigencia.Value = Me.dgvAccesos.Rows(e.RowIndex).Cells("vigencia").Value
        End If
    End Sub

    Private Sub cmbTipoSolic_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoSolic.SelectedIndexChanged
        Me.txtMontoMax.Text = ""
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        Me.txtCodBux.Text = ParamcodigoBux
        Me.txtCodBux.Focus()
        Me.cmbTipoSolic.Focus()
    End Sub

    Private Sub txtCodBux_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBux.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.cmbTipoSolic.Focus()
        End If
    End Sub

    Private Sub txtCodBux_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodBux.LostFocus
        Dim tblEmpl As DataTable
        If Val(Me.txtCodBux.Text) > 0 Then
            tblEmpl = jClass.obtenerDatos(New SqlCommand("SELECT NOMBRE_COMPLETO, BLOQUEADO, MOTIVO_BLOQUEO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodBux.Text))
            If tblEmpl.Rows.Count > 0 Then
                Me.lblEmpleado.Text = tblEmpl.Rows(0).Item("NOMBRE_COMPLETO") 'jClass.obtenerEscalar("SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodBux.Text)
                If tblEmpl.Rows(0).Item("BLOQUEADO") Then
                    MsgBox("EMPLEADO BLOQUEADO" & vbCrLf & "MOTIVO: " & tblEmpl.Rows(0).Item("MOTIVO_BLOQUEO").ToString().ToUpper() & vbCrLf & vbCrLf & "USE LA OPCION DESBLOQUEO SOCIOS", MsgBoxStyle.Information, "INFORMACION")
                    Return
                End If
                _codBuxis = Me.txtCodBux.Text
                cargaDatos()
            Else
                MsgBox("Código no existe.", MsgBoxStyle.Information, "Busqueda Empleados")
            End If
        End If
    End Sub
End Class