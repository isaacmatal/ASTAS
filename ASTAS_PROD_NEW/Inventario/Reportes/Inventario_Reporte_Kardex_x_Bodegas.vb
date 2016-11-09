Imports System.Data.SqlClient
Public Class Inventario_Reporte_Kardex_x_Bodegas
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Rpts As New frmReportes_Ver
    Dim dtareader As SqlDataReader
    Private Sub Inventario_Reporte_Kardex_x_Bodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA1, 7)
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If MsgBox("¿Está seguro(a) que desea emitir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.CargaInventario_Kardex_x_Bodegas(Compañia, Me.cmbBODEGA1.SelectedValue, Me.cmbBODEGA2.SelectedValue, Me.txtFecha.Value)
            If Hay_Datos Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class