Imports System.Data.SqlClient

Public Class Contabilidad_Reporte_Comparativo_Saldos_Proveedores
    Dim jClass As New jarsClass
    Dim Sql As String
    Dim Table As DataTable

    Private Sub Contabilidad_Reporte_Comparativo_Saldos_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaMeses()
        Me.nudYear.Value = Now.Year
        Me.crvReporte.BackColor = Color.Transparent
    End Sub

    Private Sub CargaMeses()
        Sql = "SELECT MES, UPPER(DESCRIPCION_MES) AS DESCRIPCION_MES FROM [dbo].[CONTABILIDAD_CATALOGO_MESES]"
        Me.cmbMeses.DataSource = jClass.obtenerDatos(New SqlCommand(Sql))
        Me.cmbMeses.DisplayMember = "DESCRIPCION_MES"
        Me.cmbMeses.ValueMember = "MES"
        Me.cmbMeses.SelectedValue = Now.Month
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim Reporte As New Contabilidad_Comparativo_Saldos_Cooperativa
        Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_CHEQUES" & vbCrLf
        Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
        Sql &= ",@FECHA_CONTABLE = '" & Date.DaysInMonth(Me.nudYear.Value, Me.cmbMeses.SelectedValue).ToString() & "/" & Me.cmbMeses.SelectedValue.ToString().PadLeft(2, "0") & "/" & Me.nudYear.Value.ToString() & "'" & vbCrLf
        Sql &= ",@DIF		     = " & IIf(Me.chkDif.Checked, 1, 0) & vbCrLf
        Table = jClass.obtenerDatos(New SqlCommand(Sql))
        Reporte.SetDataSource(Table)
        txtObj = Reporte.Section2.ReportObjects("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = Reporte.Section2.ReportObjects("txtPeriodo")
        txtObj.Text = "PERIODO CONTABLE: " & Me.cmbMeses.Text & "-" & Me.nudYear.Value
        txtObj = Reporte.Section2.ReportObjects("txtFiltros")
        txtObj.ObjectFormat.EnableSuppress = True
        txtObj = Reporte.Section2.ReportObjects("Text12")
        txtObj.Text = "REPORTE COMPARATIVO ENTRE SALDOS CONTABLES Y SALDOS DE PROVEEDORES"
        txtObj = Reporte.Section2.ReportObjects("Text16")
        txtObj.Text = "S A L D O S   P R O V E E D O R E S"
        txtObj = Reporte.Section2.ReportObjects("Text6")
        txtObj.Text = "CODIGO PROVEEDOR"
        txtObj = Reporte.Section2.ReportObjects("Text2")
        txtObj.ObjectFormat.EnableSuppress = True
        Me.crvReporte.ReportSource = Reporte
    End Sub

    Private Sub Contabilidad_Reporte_Comparativo_Saldos_Proveedores_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class