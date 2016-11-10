Public Class Activo_Fijo_Bien_Browser
    Dim objEntidad As New EntidadGenerica
    Dim _form As New Activo_Fijo_Bien
    Dim _empresa = String.Empty
    Dim _clasificacion = String.Empty
    Dim _asignacion = String.Empty
    Dim _tipo_bien = String.Empty
    Dim _codigo = String.Empty

    Private Sub Activo_Fijo_Bien_Browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        objEntidad.fillComboBox(Me.cmbEmpresa, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_empresa', @COMPA�IA = " & Compa�ia, "EMPRESA", "NOMBRE_EMPRESA")
        objEntidad.fillComboBox(Me.cmbClasificacion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_clasificacion', @COMPA�IA = " & Compa�ia, "CLASIFICACION", "DESCRIPCION_CLASIFICACION")
        objEntidad.fillComboBox(Me.cmbAsignacion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_asignacion', @COMPA�IA = " & Compa�ia, "ASIGNACION", "DESCRIPCION_ASIGNACION")        

        dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia)
        dgvConsulta.Columns(0).Visible = False
        Iniciando = False
    End Sub

    Public Sub fillData()
        setearParametros()
        dgvConsulta.DataSource = Nothing
        dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia & ", @EMPRESA = " & _empresa & ",@CLASIFICACION=" & _clasificacion & ",@ASIGNACION=" & _asignacion & ",@TIPO_BIEN=" & _tipo_bien & ",@CODIGO=" & _codigo)
        dgvConsulta.Columns(0).Visible = False
    End Sub

    Public Sub setearParametros()
        If Me.cmbEmpresa.SelectedValue = 0 Then
            _empresa = "NULL"
        Else
            _empresa = Me.cmbEmpresa.SelectedValue
        End If

        If Me.cmbClasificacion.SelectedValue = 0 Then
            _clasificacion = "NULL"
        Else
            _clasificacion = Me.cmbClasificacion.SelectedValue
        End If

        If Me.cmbAsignacion.SelectedValue = 0 Then
            _asignacion = "NULL"
        Else
            _asignacion = Me.cmbAsignacion.SelectedValue
        End If

        If Me.cmbTipoBien.SelectedValue = 0 Then
            _tipo_bien = "NULL"
        Else
            _tipo_bien = Me.cmbTipoBien.SelectedValue
        End If

        If Me.txtFind.Text.Length > 0 Then
            Me._codigo = "'" & Me.txtFind.Text & "'"
        Else
            Me._codigo = "NULL"
        End If
    End Sub

    Private Sub cmbClasificacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClasificacion.SelectedIndexChanged
        If Not Iniciando Then
            If Me.cmbClasificacion.SelectedValue = 0 Then
                Me.cmbTipoBien.DataSource = Nothing
            Else
                objEntidad.fillComboBox(Me.cmbTipoBien, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_tpobien', @COMPA�IA = " & Compa�ia & ",@CLASIFICACION=" & Me.cmbClasificacion.SelectedValue, "TIPO_BIEN", "DESCRPCION")
            End If
        End If        
    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        fillData()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Visible = False
        _form.id_bien = 0
        _form.accion_ = "insert"
        _form.ShowDialog()
        Me.Visible = True
        dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia)
        dgvConsulta.Columns(0).Visible = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If _form.id_bien > 0 Then
            Me.Visible = False
            _form.accion_ = "update"
            _form.ShowDialog()
            Me.Visible = True
            dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia)
            dgvConsulta.Columns(0).Visible = False
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If _form.id_bien > 0 Then
            Me.Visible = False
            _form.accion_ = "select"
            _form.ShowDialog()
            Me.Visible = True
            dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia)
            dgvConsulta.Columns(0).Visible = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If _form.id_bien > 0 Then
            Me.Visible = False
            _form.accion_ = "delete"
            _form.ShowDialog()
            Me.Visible = True
            dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_bien', @COMPA�IA = " & Compa�ia)
            dgvConsulta.Columns(0).Visible = False
        End If
    End Sub

    Private Sub dgvConsulta_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        _form.id_bien = dgvConsulta.Rows(dgvConsulta.SelectedCells(0).RowIndex).Cells(0).Value
    End Sub

    Private Sub txtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged
        If txtFind.Text.Length > 0 Then
            dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_like', @COMPA�IA = " & Compa�ia & ", @DESCRIPCION_BIEN=" & txtFind.Text)
            dgvConsulta.Columns(0).Visible = False
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text.Length > 0 Then
            dgvConsulta.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_like', @COMPA�IA = " & Compa�ia & ", @CODIGO=" & Me.txtCodigo.Text)
            dgvConsulta.Columns(0).Visible = False
        End If        
    End Sub
End Class