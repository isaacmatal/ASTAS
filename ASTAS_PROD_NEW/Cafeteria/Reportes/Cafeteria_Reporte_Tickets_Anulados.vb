Public Class Cafeteria_Reporte_Tickets_Anulados
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Private Sub Cafeteria_Reporte_Tickets_Anulados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = False
    End Sub
    Public Sub CargaReporte()
        Dim Rpt As New Cafeteria_Reporte_Tickets_Anulados_Rpt
        Try
            DS01.Reset()
            Sql = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=5"
            c_data1.ejecutaSQLl_llenaDTABLE(Sql)
            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))
            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            CargaReporte()
        End If
    End Sub
End Class