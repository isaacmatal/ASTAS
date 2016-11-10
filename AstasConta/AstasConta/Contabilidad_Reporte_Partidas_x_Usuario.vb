Public Class Contabilidad_Reporte_Partidas_x_Usuario

    Private Sub Contabilidad_Reporte_Partidas_x_Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Dim FrmPartidas As New Contabilidad_Procesar_Partidas(Usuario)
        FrmPartidas.MdiParent = Me.Parent.Parent
        FrmPartidas.Show()
        Me.Timer1.Interval = 50
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class