Imports System.Data.SqlClient
Public Class Reporte_Calendario_Recetas_Programadas
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Private Sub Reporte_Calendario_Recetas_Programadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBodegas(Compañia, 5, cmbBODEGA, "Bodega", "Descripción")
           End Sub
    Private Sub CargaBodegas(ByVal Compañia As Object, ByVal Bandera As Object, ByVal Cmb As ComboBox, ByVal value As Object, ByVal display As Object)
        'Dim i As Integer
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ",@COMPAÑIA= " & Compañia
            Sql &= ",@USUARIO= '" & Usuario & "'"
            c_data1.CargarCombo(Cmb, SQL, value, display)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02, DS03, DS04 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_1 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_2
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_2 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_3
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_3 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_4
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_4 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_5
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_5 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_6
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_6 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Rpt As New Cafeteria_Reporte_Calendario_Recetas_Programadas_7
        Try
            DS03.Reset()
            OpenConnection()
            SQL = "Execute sp_CAFETERIA_REPORTE_CALENDARIO_7 "
            SQL &= "@COMPAÑIA=" & Compañia
            SQL &= ",@BODEGA=" & cmbBODEGA.SelectedValue
            SQL &= ",@FECHA1='" & Format(fecha_desde.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@FECHA2='" & Format(fecha_hasta.Value, "yyyy-MM-dd") & "'"
            SQL &= ",@BANDERA=" & 0
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Rpt.SetDataSource(DS03.Tables(0))

            Me.CrystalReportViewer1.ReportSource = Rpt
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class