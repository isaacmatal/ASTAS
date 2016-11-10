Imports System.Data
Imports System.Data.SqlClient

Public Class Activo_Fijo_Reports_FichaBienAdquirido
    Dim Table As DataTable
    Dim sql As String
    Dim jClass As New jarsClass
    Dim rpt As New Contabilidad_ActivoFijo_FichaBienAdquirido
    Dim objEntidad As New EntidadGenerica

    Private Sub Activo_Fijo_Reports_FichaBienAdquirido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized

        objEntidad.fillComboBox(Me.cmbTipo, "SELECT 0 TIPO,'Todos los Tipos' As DESCRIPCION_TIPO UNION SELECT TIPO, DESCRIPCION_TIPO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO", "TIPO", "DESCRIPCION_TIPO")
    End Sub

    Private Sub CargarDatos()
        sql = "Exec dbo.sp_reporte_activo_fijo @fecha_= '" & dtpHasta.Value.ToShortDateString() & "', @bandera_=1, @tipo_ = '" & IIf(radFinanciero.Checked, "financiero", "fiscal") & "', @aplica_ = " & IIf(Me.radCatAmbos.Checked, 3, IIf(Me.radDepreciable.Checked, 1, 0)) & ", @activo_ = " & IIf(Me.chkDeBaja.Checked, 1, 0) & " ,@tpo_=" & Me.cmbTipo.SelectedValue & " ,@codigo_bien_='" & Me.txtCodigo.Text.Trim() & "'"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.CargarDatos()
    End Sub

    Private Sub Activo_Fijo_Reports_FichaBienAdquirido_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub GroupBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub GroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class