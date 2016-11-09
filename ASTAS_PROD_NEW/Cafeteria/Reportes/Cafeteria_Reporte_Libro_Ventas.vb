Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Libro_Ventas
    'Constructor
    Dim multi As New multiUsos
    Dim c_data1 As New jarsClass
    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Public UToo As Boolean
    Public NoResults As Boolean = False

    Private Sub Cafeteria_Reporte_Libro_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.crvReporte.Width = Me.Width - 11
        Me.crvReporte.Height = Val(Me.Height) - 133
        multi.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaCMB(Me.cmbCOMPAÑIA.SelectedValue)
        asignarFechas()
        cmbTIPO_DOCUMENTO.SelectedIndex = 0
        Iniciando = False
    End Sub
    'Carga los combobox
    Private Sub cargaCMB(ByVal cia As Integer)

        multi.CargaLibrosContables(cia, Me.cmbLIBRO_CONTABLE)
    End Sub

    'Asigna las fechas respectivas al servidor
    Private Sub asignarFechas()

        Me.dpFECHA_DESDE.Value = multi.devuelvePrimerUltimoDiaMes(5)
        Me.dpFECHA_HASTA.Value = multi.devuelvePrimerUltimoDiaMes(6)
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim Tabla As DataTable
        Dim sqlCmd1 As New SqlCommand

        Dim reporte_30 As New Cafeteria_Libro_ventas
        sqlCmd1.CommandText = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(Me.dpFECHA_DESDE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA2='" & Format(Me.dpFECHA_HASTA.Value, "dd-MM-yyyy 00:00:01") & "',@BANDERA=8"
        Tabla = c_data1.obtenerDatos(sqlCmd1)
        reporte_30.SetDataSource(Tabla)
        crvReporte.ReportSource = reporte_30
    End Sub


End Class