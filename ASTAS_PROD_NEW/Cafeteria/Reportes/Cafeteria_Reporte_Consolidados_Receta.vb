Imports System.Data.SqlClient

Public Class Cafeteria_Reporte_Consolidados_Receta
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Tiempo As String
    Dim dtareader As SqlDataReader

    Private Sub Cafeteria_Reporte_Consolidados_Receta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_data1.CargarCombo(Me.cmbTiempo, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ",'S'", "Tiempo de Comida", "Descripción")
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim reporte_ As New Cafeteria_Reporte_ConsolidadosRecetas
            Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim Tabla As New DataTable("TDatos")
            Dim comando_ As New SqlCommand
            Dim time_food_ As String

            If chkTodosLosTiempos.Checked Then
                time_food_ = "0"
            Else
                time_food_ = cmbTiempo.SelectedValue.ToString()
            End If

            If rbPlanta1.Checked = True Then
                comando_.CommandText = "EXEC sp_CAFETERIA_CONSOLIDADO_RECETAS @fecha_desde='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @fecha_hasta='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "', @compania_=" & Compañia & ", @tiempo_=" & time_food_ & ",@planta_=1"
            Else
                comando_.CommandText = "EXEC sp_CAFETERIA_CONSOLIDADO_RECETAS @fecha_desde='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @fecha_hasta='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "', @compania_=" & Compañia & ", @tiempo_=" & time_food_ & ",@planta_=2"
            End If

            Tabla = c_data1.obtenerDatos(comando_)
            reporte_.SetDataSource(Tabla)
            txtObj = reporte_.Section2.ReportObjects.Item("txtEmpresa")
            txtObj.Text = Descripcion_Compañia
            txtObj = reporte_.Section2.ReportObjects.Item("txtPeriodo")
            txtObj.Text = " PERIODO DEL " & Me.fecha_desde.Text & " AL " & Me.fecha_hasta.Text
            CrystalReportViewer1.ReportSource = reporte_
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de generar el documento, revise los parametros!", MsgBoxStyle.Information)
        End Try
    End Sub
End Class