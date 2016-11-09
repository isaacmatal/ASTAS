Imports System.Data.SqlClient
Public Class Inventario_Reporte_Antiguedades
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Private Sub Inventario_Reporte_Antiguedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If (Me.fecha_desde.Value <= Me.fecha_hasta.Value) Then
            If MsgBox("Desea emitir el reporte?", MsgBoxStyle.YesNo, "REPORTE") = MsgBoxResult.Yes Then
                Try
                    Dim rpt As New frmReportes_Ver(Compañia, Me.cmbBODEGA.SelectedValue, Me.fecha_desde.Value, Me.fecha_hasta.Value, 6)
                    'If Hay_Datos = True Then
                    rpt.ShowDialog()
                    'Else
                    'MsgBox("No Existen Datos para dicha especificación.", MsgBoxStyle.Exclamation)
                    'End If
                Catch ex As Exception
                    MsgBox("AVISO. Ocurrio un problema a la hora de general el documento", MsgBoxStyle.Information, "INTENTE MAS TARDE")
                End Try
            End If
        Else
            MsgBox("Fecha Inicial mayor a la final.", MsgBoxStyle.Exclamation, "FECHAS")
        End If
    End Sub
End Class