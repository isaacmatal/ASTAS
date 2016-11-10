Imports System.Data.SqlClient

Public Class Contabilidad_Reporte_Comparativo_Saldos_Mensuales
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim Sql As String
    Dim rpt As New Contabilidad_Reporte_Comparativo_Saldos_Mensuales_rpt

    Private Sub Contabilidad_Reporte_Comparativo_Saldos_Mensuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        cargaMeses()
        Me.nudYear.Value = Now.Year
        If CInt(jClass.obtenerEscalar("SELECT CONVERT(INT, VALOR) FROM [dbo].[CONTABILIDAD_CATALOGO_CONSTANTE] WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 53")) = 1 Then
            Me.chkGober.Visible = True
        End If
    End Sub

    Private Sub cargaMeses()
        Sql = "SELECT MES, UPPER(DESCRIPCION_MES) AS DESCRIPCION_MES FROM [dbo].[CONTABILIDAD_CATALOGO_MESES]"
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        Me.cmbMeses.DataSource = Table
        Me.cmbMeses.DisplayMember = "DESCRIPCION_MES"
        Me.cmbMeses.ValueMember = "MES"
        Me.cmbMeses.SelectedValue = Now.Month
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Sql = "EXECUTE dbo.sp_CONTABILIDAD_REPORTES_COMPARATIVO_SALDOS_MENSUALES "
        Sql &= " @COMPAÑIA = " & Compañia
        Sql &= ",@MES = " & Me.cmbMeses.SelectedValue
        Sql &= ",@AÑO = " & Me.nudYear.Value
        If Me.chkGober.Checked Then
            Sql &= ",@CATGOBER = " & IIf(Me.chkGober.Checked, "2", "1")
        End If
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        rpt.SetDataSource(Table)
        txtObj = rpt.Section5.ReportObjects.Item("txtUsuario")
        txtObj.Text = Usuario
        Me.crvReporte.ReportSource = rpt
    End Sub
End Class