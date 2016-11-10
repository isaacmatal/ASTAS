Public Class Activo_Fijo_Ubicaciones
    Public codigo_ As Integer
    Public accion_ As String
    Dim objEntidad As New EntidadGenerica
    Public _contenido As String

    Private Sub Activo_Fijo_Ubicaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnGuardar.Enabled = True
        If Me.accion_.Equals("delete") Then
            Me.btnGuardar.Text = "Eliminar"
        Else
            Me.btnGuardar.Text = "Guardar"
        End If

        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        If Not Me.accion_.Equals("insert") Then
            Me.txtUbicacion.Text = Me._contenido
        Else
            Me.txtUbicacion.Text = String.Empty
        End If

        If Me.accion_.Equals("select") Then
            Me.btnGuardar.Text = "Aceptar"
            Me.txtUbicacion.Enabled = False
        Else
            Me.txtUbicacion.Enabled = True
            Me.btnGuardar.Text = "Guardar"
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim statement_ As String = String.Empty
        Dim salvar_ As Boolean = True

        If txtUbicacion.Text.Length > 0 Then
            Me.btnGuardar.Enabled = False
            errP.SetError(txtUbicacion, "")

            Select Case accion_
                Case "insert"
                    statement_ = "INSERT INTO dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION (DESCRIPCION_UBICACION) VALUES ('" & txtUbicacion.Text & "')"
                Case "update"
                    statement_ = "UPDATE dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION  SET [DESCRIPCION_UBICACION] = '" & txtUbicacion.Text & "' WHERE UBICACION = " & Me.codigo_
                Case "delete"
                    statement_ = "DELETE FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION WHERE UBICACION = " & Me.codigo_
                Case "select"
                    salvar_ = False
            End Select

            If salvar_ Then
                objEntidad.execute(statement_)
                MsgBox("Operación Exitosa", MsgBoxStyle.Information, "Contabilidad Activo Fijo")                
            End If
            Me.Close()
        Else
            errP.SetError(txtUbicacion, "Requerido")
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Activo_Fijo_Ubicaciones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class