Imports System.Data.SqlClient

Public Class frmControlDescuentosIndegnizados
    Dim _combo As New DataGridViewComboBoxColumn
    Dim _combo2 As New DataGridViewComboBoxColumn
    Dim _combo_tpo_baja As New DataGridViewComboBoxColumn
    Dim _combo_forma_liq As New DataGridViewComboBoxColumn
    Dim _combo_tpo_baja2 As New DataGridViewComboBoxColumn
    Dim _combo_forma_liq2 As New DataGridViewComboBoxColumn
    Dim jClass As New jarsClass
    Dim Table As New DataTable
    Dim Iniciando As Boolean
    Dim sql As String
    Dim c_data1 As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim _deduccion As String = String.Empty
    Dim _origen As String = String.Empty
    Dim _estatus As String = String.Empty
    Dim _string_update As String = String.Empty

    Private Sub frmControlDescuentosIndegnizados_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub frmControlDescuentosIndegnizados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.Desde.Value = FirstDayOfMonth(Date.Now)        
        c_data1.CargarCombo(CmbOrigen, "SELECT -1 As ORIGEN, 'Todos los Origenes' As DESCRIPCION_ORIGEN UNION ALL SELECT ORIGEN, DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES", "ORIGEN", "DESCRIPCION_ORIGEN")
        c_data1.CargarCombo(CmbEstatus, "SELECT -1 As ESTATUS, 'Todos los Estatus' As DESCRIPCION UNION ALL SELECT ESTATUS, DESCRIPCION FROM INDEMNIZADOS_ESTATUS", "ESTATUS", "DESCRIPCION")
        c_data1.CargarCombo(CmbRubro, "SELECT -1 As DEDUCCION, 'Todos los Rubros' As DESCRIPCION_DEDUCCION UNION ALL SELECT DEDUCCION, DESCRIPCION_DEDUCCION FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE DEDUCCION <> 0 AND COMPAÑIA = " & Compañia, "DEDUCCION", "DESCRIPCION_DEDUCCION")
        loadCompensation(True)
        loadCompensationCancel(True)
    End Sub

    Private Sub loadCompensation(ByVal _add_columns As Boolean)
        Try
            Dim sqlcmd As New SqlCommand
            dgvIngdemnizados.DataSource = Nothing
            dgvIngdemnizados.AutoGenerateColumns = False

            If Me.CmbOrigen.SelectedValue <> -1 Then
                _origen = ", @ORIGEN=" & Me.CmbOrigen.SelectedValue
            Else
                _origen = String.Empty
            End If

            If Me.CmbRubro.SelectedValue <> -1 Then
                _deduccion = ", @DEDUCCION=" & Me.CmbRubro.SelectedValue
            Else
                _deduccion = String.Empty
            End If

            If Me.CmbEstatus.SelectedValue <> -1 Then
                _estatus = ", @ESTATUS=" & Me.CmbEstatus.SelectedValue
            Else
                _estatus = String.Empty
            End If

            Dim Tabla As DataTable
            sqlcmd.CommandText = "Exec dbo.SP_COOPERATIVA_CONTROL_INDEMNIZADOS @COMPAÑIA=" & Compañia & ", @BANDERA=1 , @DESDE='" & Format(Me.Desde.Value, "dd/MM/yyyy") & "', @HASTA='" & Format(Me.Hasta.Value, "dd/MM/yyyy") & "'" & _origen & _deduccion & _estatus
            Tabla = jClass.obtenerDatos(sqlcmd)
            dgvIngdemnizados.DataSource = Tabla

            If _add_columns Then
                Dim _id_col As New DataGridViewTextBoxColumn()
                _id_col.Name = "ID"
                _id_col.DataPropertyName = "ID"
                _id_col.ReadOnly = True

                Dim _det_id_col As New DataGridViewTextBoxColumn()
                _det_id_col.Name = "DETALLE_ID"
                _det_id_col.DataPropertyName = "DETALLE_ID"
                _det_id_col.ReadOnly = True

                Dim _estatus As DataTable
                sqlcmd.CommandText = "SELECT ESTATUS, DESCRIPCION FROM INDEMNIZADOS_ESTATUS"
                _estatus = jClass.obtenerDatos(sqlcmd)
                _combo.Name = "STATUS"
                _combo.DataPropertyName = "ID_ESTATUS"
                _combo.DisplayMember = "DESCRIPCION"
                _combo.ValueMember = "ESTATUS"
                _combo.DataSource = _estatus

                Dim _fecha_col As New DataGridViewTextBoxColumn()
                _fecha_col.Name = "FECHA"
                _fecha_col.DataPropertyName = "FECHA"
                _fecha_col.ReadOnly = True

                Dim _codigo_col As New DataGridViewTextBoxColumn()
                _codigo_col.Name = "CODIGO"
                _codigo_col.DataPropertyName = "CODIGO"
                _codigo_col.ReadOnly = True

                Dim _nombre_col As New DataGridViewTextBoxColumn()
                _nombre_col.Name = "NOMBRE_COMPLETO"
                _nombre_col.DataPropertyName = "NOMBRE_COMPLETO"
                _nombre_col.ReadOnly = True

                Dim _deduccion_col As New DataGridViewTextBoxColumn()
                _deduccion_col.Name = "DEDUCCION"
                _deduccion_col.DataPropertyName = "DEDUCCION"
                _deduccion_col.ReadOnly = True

                Dim _valor_col As New DataGridViewTextBoxColumn()
                _valor_col.Name = "VALOR"
                _valor_col.DataPropertyName = "Valor"
                _valor_col.ReadOnly = True

                Dim _irrecuperable_col As New DataGridViewTextBoxColumn()
                _irrecuperable_col.Name = "IRRECUPERABLE"
                _irrecuperable_col.DataPropertyName = "Irrecuperable"

                Dim _cancelado_col As New DataGridViewCheckBoxColumn()
                _cancelado_col.DataPropertyName = "CANCELADO"
                _cancelado_col.Name = "CANCELADO"
                _cancelado_col.DataPropertyName = "CANCELADO"
                _cancelado_col.ReadOnly = True

                'Dim _fecha_concelacion_col As New CalendarCell()
                Dim _fecha_cancel_col As New CalendarColumn()
                'Dim _fecha_cancel_col As New DataGridViewTextBoxColumn()
                _fecha_cancel_col.Name = "FECHA_CANCELADO"
                _fecha_cancel_col.DataPropertyName = "FECHA_CANCELADO"
                _fecha_cancel_col.ReadOnly = False

                Dim _tipo_baja As DataTable
                sqlcmd.CommandText = "SELECT TIPO_BAJA, DESCRIPCION FROM dbo.INDEMNIZADOS_TIPO_BAJA"
                _tipo_baja = jClass.obtenerDatos(sqlcmd)
                _combo_tpo_baja.Name = "TIPO_BAJA"
                _combo_tpo_baja.DataPropertyName = "ID_TIPO_BAJA"
                _combo_tpo_baja.DisplayMember = "DESCRIPCION"
                _combo_tpo_baja.ValueMember = "TIPO_BAJA"
                _combo_tpo_baja.DataSource = _tipo_baja

                Dim _forma_liq As DataTable
                sqlcmd.CommandText = "SELECT FORMA_LIQUIDACION, DESCRIPCION FROM dbo.INDEMNIZADOS_FORMA_LIQUIDACION"
                _forma_liq = jClass.obtenerDatos(sqlcmd)
                _combo_forma_liq.Name = "FORMA_LIQUIDACION"
                _combo_forma_liq.DataPropertyName = "ID_FORMA_LIQUDACION_DEUDA"
                _combo_forma_liq.DisplayMember = "DESCRIPCION"
                _combo_forma_liq.ValueMember = "FORMA_LIQUIDACION"
                _combo_forma_liq.DataSource = _forma_liq

                Dim _comentarios_col As New DataGridViewTextBoxColumn()
                _comentarios_col.Name = "COMENTARIOS"
                _comentarios_col.DataPropertyName = "COMENTARIOS"

                Dim _cod_deduccion_col As New DataGridViewTextBoxColumn()
                _cod_deduccion_col.Name = "CODIGO_DEDUCCION"
                _cod_deduccion_col.DataPropertyName = "CODIGO_DEDUCCION"
                _cod_deduccion_col.ReadOnly = True

                dgvIngdemnizados.Columns.Add(_id_col)
                dgvIngdemnizados.Columns.Add(_det_id_col)
                dgvIngdemnizados.Columns.Add(_combo)
                dgvIngdemnizados.Columns.Add(_fecha_col)
                dgvIngdemnizados.Columns.Add(_codigo_col)
                dgvIngdemnizados.Columns.Add(_nombre_col)
                dgvIngdemnizados.Columns.Add(_deduccion_col)
                dgvIngdemnizados.Columns.Add(_valor_col)
                dgvIngdemnizados.Columns.Add(_irrecuperable_col)
                dgvIngdemnizados.Columns.Add(_cancelado_col)
                dgvIngdemnizados.Columns.Add(_fecha_cancel_col)
                dgvIngdemnizados.Columns.Add(_combo_tpo_baja)
                dgvIngdemnizados.Columns.Add(_combo_forma_liq)
                dgvIngdemnizados.Columns.Add(_comentarios_col)
                dgvIngdemnizados.Columns.Add(_cod_deduccion_col)

                dgvIngdemnizados.Columns(0).Visible = False
                dgvIngdemnizados.Columns(1).Visible = False
                dgvIngdemnizados.Columns(2).Width = 250
                dgvIngdemnizados.Columns(2).HeaderText = "Estatus"
                dgvIngdemnizados.Columns(3).HeaderText = "Fecha"
                dgvIngdemnizados.Columns(3).Width = 70
                dgvIngdemnizados.Columns(4).Width = 60
                dgvIngdemnizados.Columns(4).HeaderText = "Código"
                dgvIngdemnizados.Columns(5).Width = 240
                dgvIngdemnizados.Columns(5).HeaderText = "Nombre"
                dgvIngdemnizados.Columns(6).Width = 190
                dgvIngdemnizados.Columns(6).HeaderText = "Deducción"
                dgvIngdemnizados.Columns(7).HeaderText = "Valor"
                dgvIngdemnizados.Columns(7).Width = 65
                dgvIngdemnizados.Columns(8).HeaderText = "Irrecuperable"
                dgvIngdemnizados.Columns(8).Width = 65
                dgvIngdemnizados.Columns(9).HeaderText = "Cancelado"
                dgvIngdemnizados.Columns(9).Width = 70
                dgvIngdemnizados.Columns(10).HeaderText = "Fecha Cancelación"
                dgvIngdemnizados.Columns(10).Width = 85
                dgvIngdemnizados.Columns(11).HeaderText = "Tipo de Baja"
                dgvIngdemnizados.Columns(11).Width = 150
                dgvIngdemnizados.Columns(12).HeaderText = "Forma de Liquidación"
                dgvIngdemnizados.Columns(12).Width = 150
                dgvIngdemnizados.Columns(13).HeaderText = "Comentarios"
                dgvIngdemnizados.Columns(13).Width = 150
                dgvIngdemnizados.Columns(14).Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub loadCompensationCancel(ByVal _add_columns As Boolean)
        Try
            Dim sqlcmd As New SqlCommand
            dgvIndemnCancelados.DataSource = Nothing
            dgvIndemnCancelados.AutoGenerateColumns = False

            If Me.CmbOrigen.SelectedValue <> -1 Then
                _origen = ", @ORIGEN=" & Me.CmbOrigen.SelectedValue
            Else
                _origen = String.Empty
            End If

            If Me.CmbRubro.SelectedValue <> -1 Then
                _deduccion = ", @DEDUCCION=" & Me.CmbRubro.SelectedValue
            Else
                _deduccion = String.Empty
            End If

            If Me.CmbEstatus.SelectedValue <> -1 Then
                _estatus = ", @ESTATUS=" & Me.CmbEstatus.SelectedValue
            Else
                _estatus = String.Empty
            End If

            Dim Tabla2 As DataTable
            sqlcmd.CommandText = "Exec dbo.SP_COOPERATIVA_CONTROL_INDEMNIZADOS @COMPAÑIA=" & Compañia & ", @BANDERA=2 , @DESDE='" & Format(Me.Desde.Value, "dd/MM/yyyy") & "', @HASTA='" & Format(Me.Hasta.Value, "dd/MM/yyyy") & "'" & _origen & _deduccion & _estatus
            Tabla2 = jClass.obtenerDatos(sqlcmd)
            dgvIndemnCancelados.DataSource = Tabla2

            If _add_columns Then
                Dim _id_col2 As New DataGridViewTextBoxColumn()
                _id_col2.Name = "ID"
                _id_col2.DataPropertyName = "ID"
                _id_col2.ReadOnly = True

                Dim _det_id_col2 As New DataGridViewTextBoxColumn()
                _det_id_col2.Name = "DETALLE_ID"
                _det_id_col2.DataPropertyName = "DETALLE_ID"
                _det_id_col2.ReadOnly = True

                Dim _estatus2 As DataTable
                sqlcmd.CommandText = "SELECT ESTATUS, DESCRIPCION FROM INDEMNIZADOS_ESTATUS"
                _estatus2 = jClass.obtenerDatos(sqlcmd)
                _combo2.Name = "STATUS"
                _combo2.DataPropertyName = "ID_ESTATUS"
                _combo2.DisplayMember = "DESCRIPCION"
                _combo2.ValueMember = "ESTATUS"
                _combo2.DataSource = _estatus2
                _combo2.ReadOnly = True

                Dim _fecha_col2 As New DataGridViewTextBoxColumn()
                _fecha_col2.Name = "FECHA"
                _fecha_col2.DataPropertyName = "FECHA"
                _fecha_col2.ReadOnly = True

                Dim _codigo_col2 As New DataGridViewTextBoxColumn()
                _codigo_col2.Name = "CODIGO"
                _codigo_col2.DataPropertyName = "CODIGO"
                _codigo_col2.ReadOnly = True

                Dim _nombre_col2 As New DataGridViewTextBoxColumn()
                _nombre_col2.Name = "NOMBRE_COMPLETO"
                _nombre_col2.DataPropertyName = "NOMBRE_COMPLETO"
                _nombre_col2.ReadOnly = True

                Dim _deduccion_col2 As New DataGridViewTextBoxColumn()
                _deduccion_col2.Name = "DEDUCCION"
                _deduccion_col2.DataPropertyName = "DEDUCCION"
                _deduccion_col2.ReadOnly = True

                Dim _valor_col2 As New DataGridViewTextBoxColumn()
                _valor_col2.Name = "VALOR"
                _valor_col2.DataPropertyName = "Valor"
                _valor_col2.ReadOnly = True

                Dim _irrecuperable_col2 As New DataGridViewTextBoxColumn()
                _irrecuperable_col2.Name = "IRRECUPERABLE"
                _irrecuperable_col2.DataPropertyName = "Irrecuperable"
                _irrecuperable_col2.ReadOnly = True

                Dim _cancelado_col2 As New DataGridViewCheckBoxColumn()
                _cancelado_col2.DataPropertyName = "CANCELADO"
                _cancelado_col2.Name = "CANCELADO"
                _cancelado_col2.DataPropertyName = "CANCELADO"
                _cancelado_col2.ReadOnly = True

                Dim _fecha_cancel_col2 As New DataGridViewTextBoxColumn()
                _fecha_cancel_col2.Name = "FECHA_CANCELADO"
                _fecha_cancel_col2.DataPropertyName = "FECHA_CANCELADO"
                _fecha_cancel_col2.ReadOnly = True

                Dim _tipo_baja As DataTable
                sqlcmd.CommandText = "SELECT TIPO_BAJA, DESCRIPCION FROM dbo.INDEMNIZADOS_TIPO_BAJA"
                _tipo_baja = jClass.obtenerDatos(sqlcmd)
                _combo_tpo_baja2.Name = "TIPO_BAJA"
                _combo_tpo_baja2.DataPropertyName = "ID_TIPO_BAJA"
                _combo_tpo_baja2.DisplayMember = "DESCRIPCION"
                _combo_tpo_baja2.ValueMember = "TIPO_BAJA"
                _combo_tpo_baja2.DataSource = _tipo_baja
                _combo_tpo_baja2.ReadOnly = True

                Dim _forma_liq As DataTable
                sqlcmd.CommandText = "SELECT FORMA_LIQUIDACION, DESCRIPCION FROM dbo.INDEMNIZADOS_FORMA_LIQUIDACION"
                _forma_liq = jClass.obtenerDatos(sqlcmd)
                _combo_forma_liq2.Name = "FORMA_LIQUIDACION"
                _combo_forma_liq2.DataPropertyName = "ID_FORMA_LIQUDACION_DEUDA"
                _combo_forma_liq2.DisplayMember = "DESCRIPCION"
                _combo_forma_liq2.ValueMember = "FORMA_LIQUIDACION"
                _combo_forma_liq2.DataSource = _forma_liq
                _combo_forma_liq2.ReadOnly = True

                Dim _comentarios_col2 As New DataGridViewTextBoxColumn()
                _comentarios_col2.Name = "COMENTARIOS"
                _comentarios_col2.DataPropertyName = "COMENTARIOS"
                _comentarios_col2.ReadOnly = True

                Dim _cod_deduccion_col2 As New DataGridViewTextBoxColumn()
                _cod_deduccion_col2.Name = "CODIGO_DEDUCCION"
                _cod_deduccion_col2.DataPropertyName = "CODIGO_DEDUCCION"
                _cod_deduccion_col2.ReadOnly = True

                dgvIndemnCancelados.Columns.Add(_id_col2)
                dgvIndemnCancelados.Columns.Add(_det_id_col2)
                dgvIndemnCancelados.Columns.Add(_combo2)
                dgvIndemnCancelados.Columns.Add(_fecha_col2)
                dgvIndemnCancelados.Columns.Add(_codigo_col2)
                dgvIndemnCancelados.Columns.Add(_nombre_col2)
                dgvIndemnCancelados.Columns.Add(_deduccion_col2)
                dgvIndemnCancelados.Columns.Add(_valor_col2)
                dgvIndemnCancelados.Columns.Add(_irrecuperable_col2)
                dgvIndemnCancelados.Columns.Add(_cancelado_col2)
                dgvIndemnCancelados.Columns.Add(_fecha_cancel_col2)
                dgvIndemnCancelados.Columns.Add(_combo_tpo_baja2)
                dgvIndemnCancelados.Columns.Add(_combo_forma_liq2)
                dgvIndemnCancelados.Columns.Add(_comentarios_col2)
                dgvIndemnCancelados.Columns.Add(_cod_deduccion_col2)

                dgvIndemnCancelados.Columns(0).Visible = False
                dgvIndemnCancelados.Columns(1).Visible = False
                dgvIndemnCancelados.Columns(2).Width = 250
                dgvIndemnCancelados.Columns(2).HeaderText = "Estatus"
                dgvIndemnCancelados.Columns(3).HeaderText = "Fecha"
                dgvIndemnCancelados.Columns(3).Width = 70
                dgvIndemnCancelados.Columns(4).Width = 60
                dgvIndemnCancelados.Columns(4).HeaderText = "Código"
                dgvIndemnCancelados.Columns(5).Width = 240
                dgvIndemnCancelados.Columns(5).HeaderText = "Nombre"
                dgvIndemnCancelados.Columns(6).Width = 190
                dgvIndemnCancelados.Columns(6).HeaderText = "Deducción"
                dgvIndemnCancelados.Columns(7).HeaderText = "Valor"
                dgvIndemnCancelados.Columns(7).Width = 65
                dgvIndemnCancelados.Columns(8).HeaderText = "Irrecuperable"
                dgvIndemnCancelados.Columns(8).Width = 65
                dgvIndemnCancelados.Columns(9).HeaderText = "Cancelado"
                dgvIndemnCancelados.Columns(9).Width = 70
                dgvIndemnCancelados.Columns(10).HeaderText = "Fecha Cancelación"
                dgvIndemnCancelados.Columns(10).Width = 85
                dgvIndemnCancelados.Columns(11).HeaderText = "Tipo de Baja"
                dgvIndemnCancelados.Columns(11).Width = 150
                dgvIndemnCancelados.Columns(12).HeaderText = "Forma de Liquidación"
                dgvIndemnCancelados.Columns(12).Width = 150
                dgvIndemnCancelados.Columns(13).HeaderText = "Comentarios"
                dgvIndemnCancelados.Columns(13).Width = 150
                dgvIndemnCancelados.Columns(14).Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub paintByStatus()
        For i As Integer = 0 To dgvIngdemnizados.Rows.Count - 1
            If dgvIngdemnizados.Rows(i).Cells(2).Value = 1 Then
                dgvIngdemnizados.Rows(i).DefaultCellStyle.BackColor = Color.Pink
            Else
                If dgvIngdemnizados.Rows(i).Cells(2).Value = 2 Then
                    dgvIngdemnizados.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    If dgvIngdemnizados.Rows(i).Cells(2).Value = 3 Then
                        dgvIngdemnizados.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    Else
                        dgvIngdemnizados.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                    End If
                End If
            End If

            If dgvIngdemnizados.Rows(i).Cells(8).Value > 0 Then
                dgvIngdemnizados.Rows(i).DefaultCellStyle.BackColor = Color.PapayaWhip
            End If
        Next
    End Sub

    Private Sub saveChanges()
        Dim _string_sql As String = String.Empty
        Dim Result As Integer
        Dim sqlcmd As New SqlCommand
        Dim _update_date As String
        Dim _comentarios As String

        Try
            For i As Integer = 0 To dgvIngdemnizados.Rows.Count - 1

                If dgvIngdemnizados.Rows(i).Cells(2).Value = 2 Then
                    _update_date = ", FECHA_CANCELADO = '" & CDate(dgvIngdemnizados.Rows(i).Cells(10).Value).ToString("dd/MM/yyyy HH:mm:ss") & "'"
                Else
                    _update_date = String.Empty
                End If
                If Me.dgvIngdemnizados.Rows.Item(i).Cells(13).Value.ToString().Trim().Length > 1 Then
                    _comentarios = ", COMENTARIOS='" & Me.dgvIngdemnizados.Rows.Item(i).Cells(13).Value.ToString().Trim() & "'"
                Else
                    _comentarios = String.Empty
                End If

                _string_sql = "UPDATE dbo.DETALLE_INDEMNIZADOS SET ESTATUS = " & dgvIngdemnizados.Rows(i).Cells(2).Value & _update_date & ", TIPO_BAJA = " & Me.dgvIngdemnizados.Rows.Item(i).Cells(11).Value.ToString().Trim() & ", FORMA_LIQUDACION_DEUDA = " & Me.dgvIngdemnizados.Rows.Item(i).Cells(12).Value.ToString().Trim() & ", IRRECUPERABLE = " & Me.dgvIngdemnizados.Rows.Item(i).Cells(8).Value.ToString().Trim() & _comentarios & "  WHERE DETALLE_ID=  " & dgvIngdemnizados.Rows(i).Cells(1).Value & " AND COMPAÑIA =" & Compañia
                sqlcmd.CommandText = _string_sql
                Result = jClass.ejecutarComandoSql(sqlcmd)

                If dgvIngdemnizados.Rows(i).Cells(2).Value = 2 Then
                    'Cambio 20/07/2016 Julio Galeas
                    Dim _datos As New DataTable()
                    Dim _consulta_sql As String = String.Empty
                    _consulta_sql &= "EXEC SP_COOPERATIVA_REGISTRAR_RETIROS_SOCIOS @COMPAÑIA=" & Compañia
                    _consulta_sql &= " ,@CODIGO_EMPLEADO = " & dgvIngdemnizados.Rows(i).Cells(4).Value
                    _consulta_sql &= " ,@DEDUCC =" & dgvIngdemnizados.Rows(i).Cells(14).Value
                    _consulta_sql &= " ,@FECHA = '" & CDate(dgvIngdemnizados.Rows(i).Cells(10).Value).ToString("dd/MM/yyyy HH:mm:ss") & "'"
                    _consulta_sql &= " ,@USUARIO = " & Usuario
                    _consulta_sql &= " ,@COMENTARIO = '" & dgvIngdemnizados.Rows(i).Cells(13).Value & "'"
                    sqlcmd.CommandText = _consulta_sql
                    _datos = jClass.obtenerDatos(sqlcmd)
                End If
            Next

            Dim _codigo As String = String.Empty
            Dim _sub_sql As String = String.Empty
            For i As Integer = 0 To dgvIngdemnizados.Rows.Count - 1
                If Not _codigo.Equals(Me.dgvIngdemnizados.Rows.Item(i).Cells(4).Value.ToString().Trim()) Then
                    _sub_sql = "Exec dbo.SP_COOPERATIVA_CONTROL_INDEMNIZADOS @COMPAÑIA=" & Compañia & ", @BANDERA=3, @ID=" & Me.dgvIngdemnizados.Rows.Item(i).Cells(0).Value.ToString().Trim() & ", @DETALLE_ID=" & Me.dgvIngdemnizados.Rows.Item(i).Cells(1).Value.ToString().Trim() & ", @CODIGO=" & Me.dgvIngdemnizados.Rows.Item(i).Cells(4).Value.ToString().Trim()
                    sqlcmd.CommandText = _sub_sql
                    Result = jClass.ejecutarComandoSql(sqlcmd)
                End If
                _codigo = Me.dgvIngdemnizados.Rows.Item(i).Cells(4).Value.ToString().Trim()
            Next
                        
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        loadCompensation(False)
        loadCompensationCancel(False)
        paintByStatus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If MsgBox("¿Desea guardar los cambios?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Me.saveChanges()
            loadCompensation(False)
            loadCompensationCancel(False)
            paintByStatus()
        End If        
    End Sub

    Private Sub frmControlDescuentosIndegnizados_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        paintByStatus()
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        btnVer.Visible = False        

        If Me.CmbOrigen.SelectedValue <> -1 Then
            _origen = ", @ORIGEN=" & Me.CmbOrigen.SelectedValue
        Else
            _origen = String.Empty
        End If

        If Me.CmbRubro.SelectedValue <> -1 Then
            _deduccion = ", @DEDUCCION=" & Me.CmbRubro.SelectedValue
        Else
            _deduccion = String.Empty
        End If

        If Me.CmbEstatus.SelectedValue <> -1 Then
            _estatus = ", @ESTATUS=" & Me.CmbEstatus.SelectedValue
        Else
            _estatus = String.Empty
        End If

        Dim Rpt As New Cooperativa_Control_Indemnizados
        sqlCmd.CommandText = "Exec dbo.SP_COOPERATIVA_CONTROL_INDEMNIZADOS @BANDERA=4, @COMPAÑIA=" & Compañia & ", @DESDE='" & Format(Me.Desde.Value, "dd/MM/yyyy") & "', @HASTA='" & Format(Me.Hasta.Value, "dd/MM/yyyy") & "'" & _origen & _deduccion & _estatus
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        Me.crvReportView.ReportSource = Rpt
        btnVer.Visible = True
    End Sub

    Public Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
    End Function
End Class