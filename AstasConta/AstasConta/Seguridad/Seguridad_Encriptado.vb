
Public Class Seguridad_Encriptado
    Dim Encrip_desencrip As New Encriptar_Desencriptar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = Encrip_desencrip.Encriptar(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Text = Encrip_desencrip.Desencriptar(TextBox1.Text)
    End Sub
End Class