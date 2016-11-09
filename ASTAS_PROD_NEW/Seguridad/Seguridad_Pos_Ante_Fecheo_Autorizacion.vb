Public Class Seguridad_Pos_Ante_Fecheo_Autorizacion
    Dim c_data1 As New jarsClass
    Dim tabla As New DataTable
    Dim bodega As Integer
    Private Sub Seguridad_Pos_Ante_Fecheo_Autorizacion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
    Public Sub cargarGrid()
        tabla = c_data1.ejecutaSQLl_llenaDTABLE("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ", @BANDERA=1")
        Me.dgvFecheo.DataSource = tabla
    End Sub
    Private Sub Seguridad_Pos_Ante_Fecheo_Autorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        
        cargarGrid()
    End Sub
    Private Sub dgvFecheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFecheo.Click
        limpiar()
        Me.lb_bodega.Text = dgvFecheo.CurrentRow.Cells(14).Value.ToString()
        Me.lb_usuario.Text = dgvFecheo.CurrentRow.Cells(3).Value.ToString()
        bodega = dgvFecheo.CurrentRow.Cells(2).Value.ToString()
        Me.lb_fecha.Text = dgvFecheo.CurrentRow.Cells(4).Value.ToString()
        Me.lb_ventana.Text = dgvFecheo.CurrentRow.Cells(6).Value.ToString()
        Me.TextBox1.Text = dgvFecheo.CurrentRow.Cells(7).Value.ToString()
        Me.txt_Codigos.Text = dgvFecheo.CurrentRow.Cells(15).Value.ToString()
        Me.lb_Item.Text = dgvFecheo.CurrentRow.Cells(0).Value.ToString()
        If dgvFecheo.CurrentRow.Cells(5).Value = True Then
            Me.chk_pos.Checked = True
            Me.chk_ante.Checked = False
        Else
            Me.chk_pos.Checked = False
            Me.chk_ante.Checked = True
        End If
    End Sub
    Public Sub limpiar()
        Me.lb_bodega.Text = "Bodega"
        Me.lb_usuario.Text = "Usuario"
        Me.lb_fecha.Text = "Fecha"
        Me.lb_ventana.Text = "Ventana"
        Me.TextBox1.Text = ""
        Me.txt_Codigos.Text = "0"
        Me.lb_Item.Text = "Item"
        bodega = 0
    End Sub
    Private Function Aleatorio(ByVal Minimo As Long, ByVal Maximo As Long) As Long
        Randomize() ' inicializar la semilla  
        Aleatorio = CLng((Minimo - Maximo) * Rnd + Maximo)
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Val(Me.lb_Item.Text) > 0 Then
            Me.txt_Codigos.Text = Aleatorio(CLng(1000), CLng(9999))
            Try
                c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & bodega & ", @BANDERA=2, @ITEM=" & Me.lb_Item.Text & ",@USUARIO='" & Usuario & "', @CLAVE=" & Me.txt_Codigos.Text)
                cargarGrid()
                MsgBox("Solicitud Autorizada con Exito", MsgBoxStyle.Exclamation)

            Catch ex As Exception
                MsgBox("Solicitud NO Autorizada", MsgBoxStyle.Exclamation)
            End Try
        Else
            MsgBox("Debe seleccionar un chequeo", MsgBoxStyle.Exclamation)
        End If
    End Sub

    
End Class