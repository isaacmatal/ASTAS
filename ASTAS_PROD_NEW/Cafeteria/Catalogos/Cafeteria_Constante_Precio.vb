Public Class Cafeteria_Constante_Precio
    Dim c_data2 As New jarsClass

    Private Sub Cafeteria_Constante_Precio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnGuardar.Enabled = False
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        txtDescrip.Text = c_data2.leerDataeader("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 34", 0)
        Dim _val As String = Format(CDbl(c_data2.leerDataeader("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 34", 0)), "0.00")
        txtValor.Text = _val
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Val(txtValor.Text) > 0 Then
                Dim _respuesta As MsgBoxResult
                _respuesta = MsgBox("¿Desea guardar el cambio realizado?", MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                If _respuesta = MsgBoxResult.Yes Then
                    c_data2.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & txtValor.Text & " WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 34")
                    btnGuardar.Enabled = False
                    MsgBox("Guardado con Exito...", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Valor Incorrecto...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.TextChanged
        btnGuardar.Enabled = True
        If Val(Me.txtValor.Text) > 100 Then
            btnGuardar.Enabled = False
            MsgBox("Porcentaje no puede ser mayor a 100%.", MsgBoxStyle.Information)
        End If
    End Sub
End Class