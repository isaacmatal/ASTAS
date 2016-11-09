Imports System.Data.SqlClient

Public Class Cafeteria_Facturacion_Capturar_Codigo
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable

    Private Sub Cafeteria_Facturacion_Capturar_Codigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Cafeteria_Facturacion_Capturar_Codigo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.LightGreen, Color.DarkGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtCodEmpl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodEmpl.KeyPress
        If Me.txtCodEmpl.Text.Length > 0 Then
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub txtCodEmpl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodEmpl.LostFocus
        If Me.txtCodEmpl.Text.Length > 0 Then
            sql = "SELECT S.NOMBRE_COMPLETO, O.PRECIO_ESPECIAL, O.DESCRIPCION_ORIGEN "
            sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS S, COOPERATIVA_CATALOGO_ORIGENES O"
            sql &= " WHERE S.COMPAÑIA = O.COMPAÑIA AND S.ORIGEN = O.ORIGEN"
            sql &= "   AND S.COMPAÑIA = " & Compañia
            sql &= "   AND S.CODIGO_EMPLEADO = " & Me.txtCodEmpl.Text
            Table = jClass.obtenerDatos(New SqlCommand(sql))
            If Table.Rows.Count = 0 Then
                MsgBox("CODIGO NO EXISTE", MsgBoxStyle.Critical, "BUSQUEDA EMPLEADO")
                Me.chkValido.Checked = False
                Me.txtCodEmpl.Focus()
            Else
                Me.txtNombreEmpl.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.txtOrigen.Text = "EMPLEADO DE " & Table.Rows(0).Item("DESCRIPCION_ORIGEN")
                If Table.Rows(0).Item("PRECIO_ESPECIAL") Then
                    Me.chkValido.Checked = True
                Else
                    MsgBox("EMPLEADO NO APLICA PRECIO NORMAL", MsgBoxStyle.Critical, "VALIDACION CODIGO")
                    Me.chkValido.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Cerrar()
    End Sub

    Private Sub btnCerrar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnCerrar.KeyPress
        If Me.txtCodEmpl.Text.Length > 0 Then
            If Asc(e.KeyChar) = Keys.Enter Then
                Cerrar()
            End If
        End If
    End Sub

    Private Sub Cerrar()
        If Me.chkValido.Checked Then
            Me.Close()
        Else
            If MsgBox("EL CODIGO INGRESADO NO ES VALIDO" & vbCrLf & vbCrLf & "¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "CONFIRMAR") = MsgBoxResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub
End Class