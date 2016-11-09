Imports System.Data.SqlClient
Public Class Cafeteria_Rep_inventarios_bodegas_plantas
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Tiempo As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader

    Private Sub Cafeteria_Rep_inventarios_bodegas_plantas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            If Me.fecha_desde.Value <= Me.fecha_hasta.Value Then
                Dim Tabla As DataTable
                Dim sqlCmd As New SqlCommand
                Dim rptver As New frmReportes_Ver

                Dim rep As New Inventarios_Resumen_Por_Bodega_Planta
                Dim planta_ As String = "1"

                If Not rbPlanta1.Checked = True Then
                    planta_ = "2"
                End If
                sqlCmd.CommandText = "EXECUTE sp_INVENTARIOS_RESUMEN_POR_BODEGA_PLANTA @PLANTA= " & planta_ & " ,@COMPAÑIA=" & Compañia & ", @USUARIO='" & Usuario & "',@FECHA_DESDE='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA_HASTA='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "'"
                Tabla = c_data1.obtenerDatos(sqlCmd)
                rep.SetDataSource(Tabla)
                CrystalReportViewer1.ReportSource = rep
            Else
                MsgBox("Fecha de Desde no puede ser mayor a fecha Hasta", MsgBoxStyle.Information, "Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub
End Class