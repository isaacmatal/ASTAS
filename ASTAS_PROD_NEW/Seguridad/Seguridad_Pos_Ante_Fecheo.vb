Class Seguridad_Pos_Ante_Fecheo
    Dim c_data1 As New jarsClass
    Dim bodega As Integer
    Sub New(ByVal bodega_text As String, ByVal bodega_item As Integer, ByVal ventana As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lb_bodega.Text = bodega_text
        bodega = bodega_item
        Me.lb_usuario.Text = Usuario
        Me.lb_ventana.Text = ventana
    End Sub


    Private Sub Seguridad_Pos_Ante_Fecheo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.chk_pos.Checked = True
    End Sub

    Private Sub chk_ante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_ante.CheckedChanged
        If Me.chk_ante.Checked = True Then
            Me.chk_pos.Checked = False
        Else
            Me.chk_pos.Checked = True
        End If
    End Sub

    Private Sub chk_pos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_pos.CheckedChanged
        If Me.chk_pos.Checked = True Then
            Me.chk_ante.Checked = False
        Else
            Me.chk_ante.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cheque As Boolean
        If Me.chk_pos.Checked = True Then
            cheque = True
        Else
            cheque = False
        End If
        Try
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & bodega & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @POS_ANTE=" & cheque & ",@NOMBRE_VENTANA='" & Me.lb_ventana.Text & "', @COMENTARIO='" & IIf(Me.TextBox1.Text = "", "SIN COMENTARIO", Me.TextBox1.Text) & "', @BANDERA=0, @NOMBRE_BODEGA='" & Me.lb_bodega.Text & "'")
            MsgBox("Solicitud enviada con exito", MsgBoxStyle.Exclamation)
            Me.Close()
        Catch ex As Exception
            MsgBox("Solicitud NO enviada", MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Private Sub Seguridad_Pos_Ante_Fecheo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class