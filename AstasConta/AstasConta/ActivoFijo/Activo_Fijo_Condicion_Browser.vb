Public Class Activo_Fijo_Condicion_Browser
    Dim objEntidad As New EntidadGenerica
    Dim _form As New Activo_Fijo_Condicion

    Private Sub Activo_Fijo_Condicion_Browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.fillData()
        Iniciando = False
    End Sub

    Public Sub fillData()
        objEntidad.entidad_ = "dbo.CONTABILIDAD_ACTIVO_FIJO_CONDICION"
        objEntidad.fields_ = "CONDICION, DESCRIPCION As ""Condición del Bien"""
        objEntidad.where_filter_ = "1=1"
        dgvConsulta.DataSource = objEntidad.getData()
        dgvConsulta.Columns(0).Visible = False
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        objEntidad.cadena_ = " SELECT  CONDICION, DESCRIPCION As ""Condición del Bien"" FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CONDICION WHERE DESCRIPCION Like '%" & Me.txtBuscar.Text & "%'"
        dgvConsulta.DataSource = objEntidad.getData()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Visible = False
        _form.accion_ = "insert"
        _form.ShowDialog()
        Me.Visible = True
        Me.fillData()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If _form.codigo_ > 0 Then
            Me.Visible = False
            _form.accion_ = "update"
            _form.codigo_ = _form.codigo_
            _form.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If _form.codigo_ > 0 Then
            Me.Visible = False
            _form.accion_ = "select"
            _form.codigo_ = _form.codigo_
            _form.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If _form.codigo_ > 0 Then
            Me.Visible = False
            _form.accion_ = "delete"
            _form.codigo_ = _form.codigo_
            _form.ShowDialog()
            Me.Visible = True
            Me.fillData()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dgvConsulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        _form.codigo_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(0).Value
        _form._contenido = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(1).Value
    End Sub
End Class