Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FrmCooperativaReporteReciboChequeSolicitudPrestamo

    'Constructor
    Dim fill As New jarsClass
    Dim NL As New NumeroLetras

    'Variables
    Dim sql As String = ""
    'Tipos de reporte:
    'BAC: 1 Cheque, 2 Remesa.
    'Citi: 3 Cheque, 4 Remesa.
    Public tipoReporte As Integer
    Public Company_Value As Integer
    Public Documento As Integer
    Public Banco As Integer
    Public CondicionFecha As Integer
    Public FechaDoc As Date
    Public Bandera As Integer
    Public Monto As Double
    Public NumChequeRem As Integer

    'Para los detalles del cheque
    'Para imprimir si es negociable o no
    Public Negociable As Integer

    'Reportes
    Dim Rpt5 As New CooperativaSolicitudesPrestamosRecibos
    Dim Rpt6 As New CooperativaSolicitudesPrestamosRecibosATAF

    'Cuando carga el formulario
    Private Sub FrmCooperativaReporteReciboChequeSolicitudPrestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Dim Table As DataTable
        'Manda a llamar el recibo solo para los cheques sin importar el banco
        Table = fill.cargaRPT_RCR(Company_Value, Documento, Banco, CondicionFecha, FechaDoc, NumChequeRem, Negociable, Bandera)
        Origen = fill.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item("CODIGO_EMPLEADO_AS") & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item("CODIGO_EMPLEADO"))
        If Origen = 5 Or Origen = 6 Then
            Rpt6.SetDataSource(Table)
            crvReporte.ReportSource = Rpt6
        Else
            Rpt5.SetDataSource(Table)
            crvReporte.ReportSource = Rpt5
        End If
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class