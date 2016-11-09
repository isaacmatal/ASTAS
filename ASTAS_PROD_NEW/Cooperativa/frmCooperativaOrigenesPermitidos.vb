Imports System.Data.SqlClient

Public Class frmCooperativaOrigenesPermitidos

    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sql As String
    Dim Permitir As String

    Private Sub frmCooperativaOrigenesPermitidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaUsuarios()
        cargaOrigen()
        Me.dgvOrigenes.AutoGenerateColumns = False
        origenesUsuario()
    End Sub

    Private Sub cargaUsuarios()
        sql = "SELECT DISTINCT U.USUARIO, U.NOMBRE_USUARIO" & vbCrLf
        sql &= "  FROM CATALOGO_USUARIOS U, SEGURIDAD_CATALOGO_ACCESOS A" & vbCrLf
        sql &= " WHERE U.COMPAÑIA = A.COMPAÑIA" & vbCrLf
        sql &= "   AND U.USUARIO = A.USUARIO" & vbCrLf
        sql &= "   AND A.MODULO = 4"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.cmbUsuarios.DataSource = Table
        Me.cmbUsuarios.DisplayMember = "NOMBRE_USUARIO"
        Me.cmbUsuarios.ValueMember = "USUARIO"
        Me.cmbUsuarios.SelectedIndex = 0
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        origenesUsuario()
    End Sub

    Private Sub cargaOrigen()
        Table = jClass.obtenerDatos(New SqlCommand("SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES"))
        Me.dgvOrigenes.DataSource = Table
    End Sub

    Private Sub origenesUsuario()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Me.cmbUsuarios.SelectedValue & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Dim usuarioOrigenesPermitidos As String() = Split(Permitir, ",")
        For i As Integer = 0 To Me.dgvOrigenes.Rows.Count - 1
            Me.dgvOrigenes.Rows(i).Cells("selec").Value = False
        Next
        If Permitir = "0" Then
            Return
        End If
        For Each origenUsuario As String In usuarioOrigenesPermitidos
            For i As Integer = 0 To Me.dgvOrigenes.Rows.Count - 1
                If CInt(Me.dgvOrigenes.Rows(i).Cells("origen").Value) = CInt(origenUsuario) Then
                    Me.dgvOrigenes.Rows(i).Cells("selec").Value = True
                End If
            Next
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Permitir = String.Empty
        Try
            For i As Integer = 0 To Me.dgvOrigenes.Rows.Count - 1
                If Me.dgvOrigenes.Rows(i).Cells("selec").Value Then
                    Permitir &= "," & Me.dgvOrigenes.Rows(i).Cells("origen").Value.ToString
                End If
            Next
            If Permitir.Length > 0 Then
                Permitir = Permitir.Substring(1)
            End If
            sql = "SELECT COUNT(FUNCION) FROM [dbo].[CATALOGO_FUNCIONES_ASOCIACION]" & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Me.cmbUsuarios.SelectedValue & "'"
            If CInt(jClass.obtenerEscalar(sql)) = 0 Then
                sql = "INSERT INTO [dbo].[CATALOGO_FUNCIONES_ASOCIACION]"
                sql &= "           ([COMPAÑIA]"
                sql &= "           ,[FUNCION]"
                sql &= "           ,[DESCRIPCION_FUNCION]"
                sql &= "           ,[DETALLE]"
                sql &= "           ,[USUARIO_CREACION]"
                sql &= "           ,[FECHA_USUARIO_CREACION]"
                sql &= "           ,[USUARIO_EDICION]"
                sql &= "           ,[FECHA_USUARIO_EDICION])"
                sql &= "     VALUES"
                sql &= "           (" & Compañia
                sql &= "           ," & CInt(jClass.obtenerEscalar("SELECT ISNULL(MAX(FUNCION), 0) + 1 FROM [dbo].[CATALOGO_FUNCIONES_ASOCIACION] WHERE COMPAÑIA = " & Compañia))
                sql &= "           ,'" & Me.cmbUsuarios.SelectedValue & "'"
                sql &= "           ,'" & Permitir & "'"
                sql &= "           ,'" & Usuario & "'"
                sql &= "           ,GETDATE()"
                sql &= "           ,'" & Usuario & "'"
                sql &= "           ,GETDATE())"
            Else
                sql = "UPDATE [dbo].[CATALOGO_FUNCIONES_ASOCIACION]"
                sql &= "   SET [DETALLE] = '" & Permitir & "'"
                sql &= "      ,[USUARIO_EDICION] = '" & Usuario & "'"
                sql &= "      ,[FECHA_USUARIO_EDICION] = GETDATE()"
                sql &= " WHERE [COMPAÑIA] = " & Compañia
                sql &= "   AND [FUNCION] = " & CInt(jClass.obtenerEscalar("SELECT FUNCION FROM [dbo].[CATALOGO_FUNCIONES_ASOCIACION] WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Me.cmbUsuarios.SelectedValue & "'"))
                sql &= "   AND [DESCRIPCION_FUNCION] = '" & Me.cmbUsuarios.SelectedValue & "'"
            End If
            If jClass.ejecutarComandoSql(New SqlCommand(sql)) > 0 Then
                MsgBox("Actualización Exitosa", MsgBoxStyle.Information, "Accesos")
            Else
                MsgBox("No se actualizó la información", MsgBoxStyle.Information, "Accesos")
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Asignar origen a usuarios")
        End Try
    End Sub

    Private Sub frmCooperativaOrigenesPermitidos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class