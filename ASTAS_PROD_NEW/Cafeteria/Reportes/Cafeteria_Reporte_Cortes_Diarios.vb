Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Cortes_Diarios
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Reporte_Cortes_Diarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 7)
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If MsgBox("¿Está seguro que desea Imprimir Ventas por Corte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.GetReporteVentas_Cortes(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFechaI.Value, "dd-MM-yyyy"), Format(Me.txtFechaF.Value, "dd-MM-yyyy"), "Y")
            Rpts.ShowDialog()
        End If
    End Sub
End Class