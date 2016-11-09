Public Class frm_reporte_dividendos_socios_cooperativa
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Private Sub frm_reporte_dividendos_socios_cooperativa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Label4.Text = Descripcion_Compa�ia
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("�Est� seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DETALLE DIVIDENDOS") = MsgBoxResult.Yes Then
            Rpts.Dividendos_Socios(Compa�ia, 1)
            If Hay_Datos Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class