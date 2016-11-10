Imports System.Data
Imports System.Data.SqlClient

Public Class Activo_Fijo_Reports_Inventarios
    Dim Table As DataTable
    Dim sql As String
    Dim jClass As New jarsClass
    Dim objEntidad As New EntidadGenerica
    Dim rpt As New Contabilidad_ActivoFijo_Inventarios

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.CargarDatos()
    End Sub

    Private Sub CargarDatos()
        ' Exec dbo.sp_reporte_activo_fijo @bandera_=2, @aplica_=1, @ubicacion = 2, @activo_=0
        sql = "Exec dbo.sp_reporte_activo_fijo @bandera_= 2, @aplica_ = " & IIf(Me.radCatAmbos.Checked, 3, IIf(Me.radDepreciable.Checked, 1, 0)) & ", @ubicacion =" & Me.cmbUbicacion.SelectedValue & ", @activo_ = " & IIf(Me.chkDeBaja.Checked, 1, 0)
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub Activo_Fijo_Reports_Inventarios_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub Activo_Fijo_Reports_Inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        objEntidad.fillComboBox(Me.cmbUbicacion, "SELECT 0 UBICACION,'Todas las Ubicaciones...' As [DESCRIPCION_UBICACION] UNION SELECT UBICACION, DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION", "UBICACION", "DESCRIPCION_UBICACION")
    End Sub
End Class