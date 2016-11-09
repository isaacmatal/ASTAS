Imports System.Data
Imports System.Data.SqlClient

Public Class frm_cooperativa_socios_ahorros_historial
    Dim jClass As New jarsClass
    Dim SQL As String

    Private Sub frm_cooperativa_socios_ahorros_historial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BusquedaSocio()
    End Sub

#Region "Busqueda Socio"
    Sub BusquedaSocio()
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2
        Dim Prin As New Busquedas_empleados_avicola
        Prin.Compañia_Value = Compañia
        Prin.CbxCompania.Enabled = False
        AppPath = System.IO.Directory.GetCurrentDirectory
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Reporte(ParamcodigoBux, ParamcodigoAs)
        End If
    End Sub
#End Region

#Region "Reporte cooperativa socios ahorros historial"
    Sub Reporte(ByVal CBuxi, ByVal CodAS)
        Dim Table As DataTable
        Dim Rpt As New rpt_cooperativa_socios_ahorros_historial
        Try
            SQL = "EXECUTE sp_VISTA_REPORTE_COOPERATIVA_SOCIO_HISTORIAL " & Compañia & "," & CBuxi & ",'" & CodAS & "'"
            Table = jClass.obtenerDatos(New SqlCommand(SQL))
            Rpt.SetDataSource(Table)
            Me.CrystalReportViewer1.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region


End Class