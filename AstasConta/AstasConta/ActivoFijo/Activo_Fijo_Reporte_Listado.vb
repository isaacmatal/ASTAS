Public Class Activo_Fijo_Reporte_Listado

    Private Sub Activo_Fijo_Reporte_Listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.btnPrint.Visible = False
        Dim _reportes As New frmReportes_Ver()
        Dim _alta As String = String.Empty
        Dim _baja_total As String = String.Empty

        If Me.radAlta.Checked Then
            _alta = "1"
            _baja_total = "NULL"
        End If
        If Me.radBaja.Checked Then
            _alta = "0"
            _baja_total = "1"
        End If
        If Me.radAmbos.Checked Then
            _alta = "NULL"
            _baja_total = "NULL"
        End If

        _reportes.RepActivoFijoListado(Compañia, _alta, _baja_total)
        _reportes.ShowDialog()
        Me.btnPrint.Visible = True
    End Sub
End Class