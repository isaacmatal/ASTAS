Imports System.Data.SqlClient

Public Class Contabilidad_Orden_ComprasPorPorveedor_RPT
    Dim _obj_compras As New Compras()
    Dim Rpts As New frmReportes_Ver

    Private Sub Contabilidad_Orden_ComprasPorPorveedor_RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me._obj_compras.setearCombo(Me.cmbBodegas, "Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA=13,@COMPAÑIA=" & Compañia & ",@USUARIO='" & Usuario & "'", "Descripción", "Bodega")
        Me._obj_compras.setearCombo(Me.cmbProveedor, "SELECT PROVEEDOR, NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA =" & Compañia & " ORDER BY NOMBRE_PROVEEDOR", "NOMBRE_PROVEEDOR", "PROVEEDOR")

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.cmbBodegas.SelectedValue = 0 Or Me.cmbBodegas.SelectedValue = -1 Then
            MsgBox("Seleccione una Bodega...", MsgBoxStyle.Critical, "AVISO")
            Return
        End If
        If Me.dtpDesde.Value > Me.dtpHasta.Value Then
            MsgBox("La fecha Desde No puede ser mayor que la fecha Hasta...", MsgBoxStyle.Critical, "AVISO")
            Return
        End If

        If MsgBox("Imprimir Requisición?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
            Rpts.CargarRptComprasPorProveedor(Compañia, Format(Me.dtpDesde.Value, "dd/MM/yyyy"), Format(Me.dtpHasta.Value, "dd/MM/yyyy"), Me.cmbBodegas.SelectedValue, Me.cmbProveedor.SelectedValue, IIf(Me.txtDocumento.Text.Length > 0, Me.txtDocumento.Text, 0), Usuario)
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub Contabilidad_Orden_ComprasPorPorveedor_RPT_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class