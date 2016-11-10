Public Class Activo_Fijo_Consultar_Ubicaciones
    Dim objEntidad As New EntidadGenerica
    Dim ubicaciones_ As New Activo_Fijo_Ubicaciones

    Private Sub Activo_Fijo_Ubicaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.fillData()
        Iniciando = False
    End Sub

    Public Sub fillData()
        objEntidad.entidad_ = "dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION"
        objEntidad.fields_ = "UBICACION, DESCRIPCION_UBICACION"
        objEntidad.where_filter_ = "1=1"
        dgvConsulta.DataSource = objEntidad.getData()
        dgvConsulta.Columns(0).Visible = False
    End Sub

    Private Sub txtUbicacion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUbicacion.Leave
        objEntidad.cadena_ = " SELECT UBICACION, DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION WHERE DESCRIPCION_UBICACION Like '%" & txtUbicacion.Text & "%'"
        dgvConsulta.DataSource = objEntidad.getData()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ubicaciones_.codigo_ > 0 Then
            Me.Visible = False
            ubicaciones_.accion_ = "delete"
            ubicaciones_.codigo_ = ubicaciones_.codigo_
            ubicaciones_.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If ubicaciones_.codigo_ > 0 Then
            Me.Visible = False
            ubicaciones_.accion_ = "select"
            ubicaciones_.codigo_ = ubicaciones_.codigo_
            ubicaciones_.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ubicaciones_.codigo_ > 0 Then
            Me.Visible = False
            ubicaciones_.accion_ = "update"
            ubicaciones_.codigo_ = ubicaciones_.codigo_
            ubicaciones_.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub dgvConsulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        ubicaciones_.codigo_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(0).Value
        ubicaciones_._contenido = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(1).Value
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Visible = False
        ubicaciones_.accion_ = "insert"
        ubicaciones_.ShowDialog()
        Me.Visible = True
        Me.fillData()
    End Sub

    Private Sub Activo_Fijo_Consultar_Ubicaciones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class