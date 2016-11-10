Public Class Activo_Fijo_Consultar_Depreciacion
    Dim objEntidad As New EntidadGenerica
    'Public depreciacion_ As New Activo_Fijo_Depreciacion

    Private Sub Activo_Fijo_Depreciacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        objEntidad.fillComboBox(Me.cmbTipo, "SELECT 0 TIPO,'Seleccione...' As DESCRIPCION_TIPO UNION SELECT TIPO, DESCRIPCION_TIPO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_TIPO", "TIPO", "DESCRIPCION_TIPO")        
        objEntidad.fillComboBox(Me.cmbUbicacion, "SELECT 0 UBICACION,'Seleccione...' As [DESCRIPCION_UBICACION] UNION SELECT UBICACION, DESCRIPCION_UBICACION FROM dbo.CONTABILIDAD_ACTIVO_FIJO_UBICACION", "UBICACION", "DESCRIPCION_UBICACION")

        Me.fillData(String.Empty)
        Iniciando = False
    End Sub

    Public Sub fillData(ByVal where_string_ As String)
        dgvConsulta.DataSource = Nothing
        Dim _sql As String = String.Empty

        _sql += "SELECT DP.DEPRECIACION "
        _sql += ",(SELECT T.DESCRIPCION_TIPO FROM CONTABILIDAD_ACTIVO_FIJO_TIPO T WHERE T.TIPO=DP.TIPO) As [Tipo]"        
        _sql += ",(SELECT AC.NOMBRE_ACTIVO FROM CONTABILIDAD_ACTIVO_FIJO_ACTIVO AC WHERE AC.ACTIVO = DP.ACTIVO ) As [Activo]"
        _sql += ",(SELECT (PR.NOMBRE_PRESENTACION + ' ' + PR.MARCA + ' ' + PR.MODELO) FROM CONTABILIDAD_ACTIVO_FIJO_PRESENTACION PR WHERE PR.PRESENTACION = DP.PRESENTACION) As [Presentación]"
        _sql += ",(SELECT U.DESCRIPCION_UBICACION FROM CONTABILIDAD_ACTIVO_FIJO_UBICACION U WHERE U.UBICACION = DP.UBICACION) As [Ubicación]"
        _sql += ",DP.FECHA_ADQUICICION As [Adquisicion],DP.FECHA_VENCIMIENTO_FINAN As [Vencimiento Financiero]"
        _sql += ",DP.TIPO,DP.UBICACION,DP.ACTIVO, DP.PRESENTACION"
        _sql += ",PRECIO_ORIGINAL_FINAN, VALOR_DEPRECIAR_FINAN, VIDA_UTIL_FINAN, DEPRECIACION_MENSUAL_FINAN, REMANENTE_FINAN"
        _sql += ",FECHA_VENCIMIENTO_FISCAL As [Vencimiento Fiscal], PRECIO_ORIGINAL_FISCAL, VALOR_DEPRECIAR_FISCAL, VIDA_UTIL_FISCAL, DEPRECIACION_MENSUAL_FISCAL, REMANENTE_FISCAL"
        _sql += ",ENCARGADO, COMENTARIOS, APLICAR_DEPRECIACION, DP.CODIGO, DP.CANTIDAD, DP.NUMERO_SERIE, DP.RETIRADO, DP.FECHABAJA "
        _sql += ",PORCENTAJENODEPFINAN, PORCENTAJENODEPFISCAL, VALOR_RESIDUAL_FINAN, VALOR_RESIDUAL_FISCAL"
        _sql += " FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIENES DP "

        If Not String.IsNullOrEmpty(where_string_) Then
            _sql += " WHERE " & where_string_
        End If

        dgvConsulta.DataSource = objEntidad.getData(_sql)

        dgvConsulta.Columns(0).Visible = False
        dgvConsulta.Columns(7).Visible = False
        dgvConsulta.Columns(8).Visible = False
        dgvConsulta.Columns(9).Visible = False
        dgvConsulta.Columns(10).Visible = False
        dgvConsulta.Columns(11).Visible = False
        dgvConsulta.Columns(12).Visible = False
        dgvConsulta.Columns(13).Visible = False
        dgvConsulta.Columns(14).Visible = False
        dgvConsulta.Columns(15).Visible = False
        dgvConsulta.Columns(17).Visible = False
        dgvConsulta.Columns(18).Visible = False
        dgvConsulta.Columns(19).Visible = False
        dgvConsulta.Columns(20).Visible = False
        dgvConsulta.Columns(21).Visible = False
        dgvConsulta.Columns(22).Visible = False
        dgvConsulta.Columns(23).Visible = False
        dgvConsulta.Columns(24).Visible = False
        'dgvConsulta.Columns(25).Visible = False
        dgvConsulta.Columns(26).Visible = False
        dgvConsulta.Columns(27).Visible = False
        dgvConsulta.Columns(28).Visible = False

        dgvConsulta.Columns(30).Visible = False
        dgvConsulta.Columns(31).Visible = False
        dgvConsulta.Columns(32).Visible = False
        dgvConsulta.Columns(33).Visible = False
    End Sub

    Private Sub dgvConsulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        'depreciacion_.id_depreciacion = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(0).Value

        'depreciacion_.tipo_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(7).Value
        'depreciacion_.ubicacion_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(8).Value
        'depreciacion_.activo_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(9).Value
        'depreciacion_.id_presentacion_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(10).Value
        'depreciacion_.fecha_adquisicion_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(5).Value

        'depreciacion_.fecha_vencimiento_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(6).Value
        'depreciacion_.precio_original_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(11).Value
        'depreciacion_.valor_depreciar_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(12).Value
        'depreciacion_.vida_util_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(13).Value
        'depreciacion_.depreciacion_mensual_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(14).Value
        'depreciacion_.remanente_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(15).Value

        'depreciacion_.fecha_vencimiento_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(16).Value
        'depreciacion_.precio_original_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(17).Value
        'depreciacion_.valor_depreciar_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(18).Value
        'depreciacion_.vida_util_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(19).Value
        'depreciacion_.depreciacion_mensual_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(20).Value
        'depreciacion_.remanente_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(21).Value

        'depreciacion_.encargado_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(22).Value
        'depreciacion_.comentarios_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(23).Value
        'depreciacion_.codigo_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(25).Value
        'depreciacion_.cantidad_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(26).Value
        'depreciacion_.numero_serie_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(27).Value

        'depreciacion_.activa_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(24).Value
        'depreciacion_.retirado_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(28).Value
        'depreciacion_.fecha_baja_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(29).Value

        'depreciacion_.porcentaje_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(30).Value
        'depreciacion_.porcentaje_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(31).Value
        'depreciacion_.valor_residual_finan_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(32).Value
        'depreciacion_.valor_residual_fiscal_ = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(33).Value

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Visible = False
        'depreciacion_.accion_ = "insert"
        'depreciacion_.ShowDialog()
        Me.Visible = True
        Me.fillData(String.Empty)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'If depreciacion_.id_presentacion_ > 0 Then
        '    Me.Visible = False
        '    depreciacion_.accion_ = "update"
        '    depreciacion_.ShowDialog()
        '    Me.Visible = True
        '    Me.fillData(String.Empty)
        'End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'If depreciacion_.id_presentacion_ > 0 Then
        '    Me.Visible = False
        '    depreciacion_.accion_ = "select"
        '    depreciacion_.ShowDialog()
        '    Me.Visible = True
        '    Me.fillData(String.Empty)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'If depreciacion_.id_presentacion_ > 0 Then
        '    Me.Visible = False
        '    depreciacion_.accion_ = "delete"
        '    depreciacion_.ShowDialog()
        '    Me.Visible = True
        '    Me.fillData(String.Empty)
        'End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub Activo_Fijo_Consultar_Depreciacion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Me.cmbTipo.SelectedValue = 0
        Me.fillData(String.Empty)
    End Sub

    Private Sub dtpAdquicicion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAdquicicion.ValueChanged
        If Not Iniciando Then
            Me.fillData(" DP.FECHA_ADQUICICION='" & dtpAdquicicion.Value.ToShortDateString() & "'")
        End If
    End Sub

    Private Sub dtpVencimientoFinanciero_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVencimientoFinanciero.ValueChanged
        If Not Iniciando Then
            Me.fillData(" MONTH(DP.FECHA_VENCIMIENTO_FINAN)=" & dtpVencimientoFinanciero.Value.Month & " AND YEAR(DP.FECHA_VENCIMIENTO_FINAN)=" & dtpVencimientoFinanciero.Value.Year)
        End If
    End Sub

    Private Sub dtpVencimientoFiscal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVencimientoFiscal.ValueChanged
        If Not Iniciando Then
            Me.fillData(" MONTH(DP.FECHA_VENCIMIENTO_FISCAL)=" & dtpVencimientoFiscal.Value.Month & " AND YEAR(DP.FECHA_VENCIMIENTO_FISCAL)=" & dtpVencimientoFiscal.Value.Year)
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If Not Iniciando Then
            Iniciando = True
            objEntidad.fillComboBox(Me.cmbActivo, "SELECT 0 ACTIVO,'Seleccione...' As NOMBRE_ACTIVO, 0 As TIPO UNION SELECT ACTIVO, NOMBRE_ACTIVO, TIPO FROM dbo.CONTABILIDAD_ACTIVO_FIJO_ACTIVO WHERE TIPO=" & cmbTipo.SelectedValue, "ACTIVO", "NOMBRE_ACTIVO")
            Me.fillData(" DP.TIPO=" & cmbTipo.SelectedValue)
            Iniciando = False
        End If
    End Sub

    Private Sub cmbUbicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUbicacion.SelectedIndexChanged
        If Not Iniciando Then
            Me.fillData(" DP.UBICACION =" & cmbUbicacion.SelectedValue)
        End If
    End Sub

    Private Sub cmbActivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActivo.SelectedIndexChanged
        If Not Iniciando And (Not cmbActivo Is Nothing) Then
            Me.fillData(" DP.ACTIVO =" & cmbActivo.SelectedValue)
        End If
    End Sub

    Private Sub txtPresentacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresentacion.TextChanged
        Me.fillData(" DP.PRESENTACION IN (SELECT PRESENTACION  FROM [dbo].[CONTABILIDAD_ACTIVO_FIJO_PRESENTACION] WHERE NOMBRE_PRESENTACION Like '%" & txtPresentacion.Text & "%')")
    End Sub

    Private Sub btnFindFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindFilters.Click
        Me.fillData(" DP.FECHA_ADQUICICION BETWEEN '" & dtpAdquisicionDesde.Value.ToShortDateString() & "' AND '" & dtpAdquisicionHasta.Value.ToShortDateString() & "'")
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        Me.fillData(" DP.CODIGO IN (SELECT CODIGO  FROM [dbo].[CONTABILIDAD_ACTIVO_FIJO_PRESENTACION] WHERE CODIGO Like '%" & Me.txtCodigo.Text & "%')")
    End Sub
End Class