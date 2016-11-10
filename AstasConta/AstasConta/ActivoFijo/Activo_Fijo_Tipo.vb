Public Class Activo_Fijo_Tipo
    Public codigo_ As Integer
    Public cuenta_ As String
    Public accion_ As String
    Dim objEntidad As New EntidadGenerica
    Public tipo_ As String

    Private Sub Activo_Fijo_Tipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnGuardar.Enabled = True
        If Me.accion_.Equals("delete") Then
            Me.btnGuardar.Text = "Eliminar"
        Else
            Me.btnGuardar.Text = "Guardar"
        End If

        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        If Not Me.accion_.Equals("insert") Then
            Me.txtUbicacion.Text = Me.tipo_
            Me.txtCuenta.Text = Me.cuenta_
        Else
            Me.txtUbicacion.Text = String.Empty
            Me.txtCuenta.Text = String.Empty
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
        Dim value_ As String = String.Empty
        Dim existe_cuenta_ As Boolean = objEntidad.checkFor("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_CUENTAS WHERE CUENTA_COMPLETA = '" & Me.txtCuenta.Text.Trim() & "' AND COMPAÑIA=" & Compañia, "CUENTA", value_)

        If txtUbicacion.Text.Length > 0 And Me.txtCuenta.Text.Length > 0 Then
            If existe_cuenta_ Then
                Me.btnGuardar.Enabled = False
                errP.SetError(txtUbicacion, "")
                errP.SetError(txtCuenta, "")

                Dim salvar_ As Boolean = True

                Select Case accion_
                    Case "insert"
                        statement_ = "INSERT INTO [dbo].[CONTABILIDAD_ACTIVO_FIJO_TIPO] (DESCRIPCION_TIPO, CUENTACONTABLE, CUENTACOMPLETA) VALUES ('" & txtUbicacion.Text & "', " & value_ & ", '" & Me.txtCuenta.Text & "')"
                    Case "update"
                        statement_ = "UPDATE [dbo].[CONTABILIDAD_ACTIVO_FIJO_TIPO] SET DESCRIPCION_TIPO = '" & txtUbicacion.Text & "', CUENTACONTABLE=" & value_ & ", CUENTACOMPLETA='" & Me.txtCuenta.Text & "' WHERE TIPO = " & Me.codigo_
                    Case "delete"
                        statement_ = "DELETE FROM  dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO WHERE TIPO = " & codigo_
                    Case "select"
                        salvar_ = False
                End Select

                If salvar_ Then
                    objEntidad.execute(statement_)
                    MsgBox("Operación Exitosa", MsgBoxStyle.Information, "Contabilidad Activo Fijo")
                End If
                Me.Close()
            Else
                MsgBox("No existe esta cuenta contable", MsgBoxStyle.Critical, "Contabilidad Activo Fijo")
            End If
        Else
            errP.SetError(txtUbicacion, "Requerido")
            errP.SetError(txtCuenta, "Requerido")
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Activo_Fijo_Tipo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnFindCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCuentas.Click
        Dim cuentas_ As New Contabilidad_BusquedaCuentas
        cuentas_.LibroContable_Value = 1
        cuentas_.ShowDialog()
        Me.txtCuenta.Text = Tipo
    End Sub
End Class