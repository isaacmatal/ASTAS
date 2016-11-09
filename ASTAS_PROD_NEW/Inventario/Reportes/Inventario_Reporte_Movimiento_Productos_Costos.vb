Imports System.Data.SqlClient
Public Class Inventario_Reporte_Movimiento_Productos_Costos
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Rpts As New frmReportes_Ver
    Dim dtareader As SqlDataReader
    Private Sub Inventario_Reporte_Movimiento_Productos_Costos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA1, 7)
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)
        rbn_Astas_da.Checked = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If Me.txtFecha1.Value <= Me.txtFecha2.Value Then
            If MsgBox("¿Está seguro(a) que desea emitir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                If Me.rbn_astas.Checked = True Then
                    Rpts.CargaInventario_Movimiento_Productos_Costos(Compañia, Me.cmbBODEGA1.SelectedValue, Me.cmbBODEGA2.SelectedValue, Me.txtFecha1.Value, Me.txtFecha2.Value)
                Else
                    Rpts.CargaInventario_Movimiento_Productos_Costos_Cafeteria(Compañia, Me.cmbBODEGA1.SelectedValue, Me.cmbBODEGA2.SelectedValue, Me.txtFecha1.Value, Me.txtFecha2.Value)
                End If
                If Hay_Datos Then
                    Rpts.ShowDialog()
                End If
            End If
        Else
            MsgBox("Fecha Inicial es Mayor que Fecha Final", MsgBoxStyle.Exclamation, "Mensaje")
            Me.txtFecha1.Value = Now()
            Me.txtFecha2.Value = Now()
            Me.txtFecha1.Focus()
        End If
    End Sub
    Private Sub txtFecha1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha1.Leave
        Me.txtFecha2.Value = Me.txtFecha1.Value
        Me.txtFecha2.Focus()
    End Sub

    Private Sub rbn_Astas_da_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn_Astas_da.CheckedChanged
        If Me.rbn_Astas_da.Checked = True Then
            rbn_astas.Checked = False
        Else
            rbn_astas.Checked = True
        End If
    End Sub

    Private Sub rbn_astas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn_astas.CheckedChanged
        If Me.rbn_astas.Checked = True Then
            rbn_Astas_da.Checked = False
        Else
            rbn_Astas_da.Checked = True
        End If
    End Sub

    Private Sub Inventario_Reporte_Movimiento_Productos_Costos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub GroupBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class