Public Class frm_reporte_dividendos_socios_cooperativa_global
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Private Sub frm_reporte_dividendos_socios_cooperativa_global_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label4.Text = Descripcion_Compañia
        Me.TxtPorcenta.Text = "3.00"
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Val(Me.TxtMonto.Text) = 0 Or Val(TxtPorcenta.Text) = 0 Then
            MsgBox("AVISO...Debe ingresar monto y/o porcentaje!", MsgBoxStyle.Information)
        Else
            If MsgBox("¿Está seguro(a) que desea emitir el informe General?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Rpts.Dividendos_Socios_Global(Compañia, txtFechaI.Value, txtFechaF.Value, TxtMonto.Text, TxtPorcenta.Text, 0)
                If Hay_Datos Then
                    Rpts.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If TxtMonto.Text.Equals(String.Empty) Then
                    e.Handled = True
                    TxtMonto.Text = ""
                Else
                    e.Handled = TxtMonto.Text.Contains(".")
                End If
            Else
                e.Handled = True
                TxtMonto.Text = ""
            End If
        End If
    End Sub

    Private Sub NumericUpDown1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorcenta.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If TxtPorcenta.Text.Equals(String.Empty) Then
                    e.Handled = True
                    TxtPorcenta.Text = ""
                Else
                    e.Handled = TxtPorcenta.Text.Contains(".")
                End If
            Else
                e.Handled = True
                TxtPorcenta.Text = ""
            End If
        End If
    End Sub
End Class