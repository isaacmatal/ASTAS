Imports System.Data.SqlClient
Public Class Inventario_Reporte_Catalogo_Productos
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Private Sub Inventario_Reporte_Catalogo_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        txtCompañia.Text = Descripcion_Compañia
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)        
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim rpt As New frmReportes_Ver(Compañia, Me.cmbBODEGA.SelectedValue, 1)
            rpt.ShowDialog()
        Catch ex As Exception
            MsgBox("Error...Ocurrio un problema a la hora de general el documento", MsgBoxStyle.Information)
        End Try        
    End Sub
End Class