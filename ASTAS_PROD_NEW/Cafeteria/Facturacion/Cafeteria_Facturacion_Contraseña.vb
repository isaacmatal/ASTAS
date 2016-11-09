Public Class Cafeteria_Facturacion_Contraseña

    Dim contraseña As String
    Dim c_data2 As New jarsClass
    Dim Compañia_1 As String, bodega_1 As String, caja_1 As String, bandera_1 As String
    Sub New(ByVal company, ByVal bodega, ByVal caja)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Compañia_1 = company
        bodega_1 = bodega
        caja_1 = caja

    End Sub
    Private Sub Cafeteria_Facturacion_Contraseña_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        contraseña = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia_1 & ",@BODEGA=" & bodega_1 & ",@CAJA=" & caja_1 & ",@BANDERA=6", 0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (contraseña = TextBox1.Text) Then
            Contraseña_Cafeteria = TextBox1.Text
            Me.Close()
        Else
            MsgBox("Aviso...La contraseña no es correcta!", MsgBoxStyle.Information)
        End If        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            Button1.PerformClick()
        End If
    End Sub
End Class