Imports System.Data.SqlClient

Public Class Contabilidad_CuentasxPagar_Nota_Credito_Rpt

    Dim jClass As New jarsClass
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable

    Private Sub Contabilidad_CuentasxPagar_Nota_Credito_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub txtCodProv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodProv.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodProv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodProv.LostFocus
        If Me.txtCodProv.Text.Length > 0 Then
            lblProveedor.Text = jClass.obtenerEscalar("SELECT NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR = " & Me.txtCodProv.Text)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim frmver As New frmReportes_Ver
        Dim Reporte As Object 'CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim TxtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        If Me.rbDetalle.Checked Then
            Reporte = New Contabilidad_CuentasxPagar_Nota_Credito_Detalle
        Else
            Reporte = New Contabilidad_CuentasxPagar_Nota_Credito_Resumen
        End If
        TxtObj = Reporte.Section2.ReportObjects.Item("Periodo")
        TxtObj.Text = "DESDE: " & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & " HASTA: " & Format(Me.dtpHasta.Value, "dd/MM/yyyy")
        Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE]"
        Sql &= " @COMPAÑIA = " & Compañia
        If Me.txtOC.Text.Length > 0 Then
            Sql &= ", @ORDEN_COMPRA = " & Me.txtOC.Text
        End If
        Sql &= ", @BANDERA = 5"
        Sql &= ", @FECHA_DESDE = '" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "'"
        Sql &= ", @FECHA_HASTA = '" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "'"
        If Me.txtCodProv.Text.Length > 0 Then
            Sql &= ", @PROVEEDOR = " & Me.txtCodProv.Text
        End If
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Reporte.SetDataSource(Table)
        frmver.ReportesGenericos(Reporte)
        frmver.ShowDialog()
    End Sub

    Private Sub Contabilidad_CuentasxPagar_Nota_Credito_Rpt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class