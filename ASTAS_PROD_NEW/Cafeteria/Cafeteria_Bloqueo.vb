Public Class Cafeteria_Bloqueo
    Dim transferencia_activa As String
    Dim c_data2 As New jarsClass
    Dim Bodega As String
    Sub New(ByVal usuario_traslado As String, ByVal ventana As String, ByVal Maquina As String, ByVal bodega1 As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lb_maquina.Text = Maquina
        Me.lb_usuario.Text = Usuario
        Me.lb_ventana.Text = ventana
        Bodega = bodega1
    End Sub
    Private Sub Cafeteria_Bloqueo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        transferencia_activa = c_data2.leerDataeader("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & Bodega & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=2", 0)
        If transferencia_activa <> "True" Then
            Me.Close()
        End If
    End Sub
End Class