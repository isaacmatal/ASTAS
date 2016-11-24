Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Requisicion
    Public codigo_ As Integer
    Public accion_ As String
    Public _reabrir As Boolean = False
    Dim Rpts As New frmReportes_Ver
    Public puede_procesar_ As Boolean
    Public puede_autorizar_ As Boolean
    Public afectan_inventario As Boolean
    Dim _obj_compras As New Compras()
    Dim _encabezado As New DataTable()
    Dim _producto As New DataTable()
    Dim _tbl_proveedor As New DataTable()
    Dim _detalle As New DataTable()
    Dim _combo_unidad_solicitada As New DataGridViewComboBoxColumn
    Dim _combo_unidad_comprar As New DataGridViewComboBoxColumn
    Dim _proveedor As New DataGridViewComboBoxColumn
    Dim _servicio As New DataGridViewCheckBoxColumn
    Dim _intangible As New DataGridViewCheckBoxColumn
    'clases para enviar correos
    Dim sendMail As New EnviarCorreo
    Dim jClass As New jarsClass

    Private Sub Contabilidad_OrdenCompra_Requisicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ToolTip1 As New System.Windows.Forms.ToolTip()
        Iniciando = True
        Me._obj_compras.setearCombo(Me.cmbBodegas, "Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA=13,@COMPAÑIA=" & Compañia & ",@USUARIO='" & Usuario & "'", "Descripción", "Bodega")
        Me._obj_compras.setearCombo(Me.cmbEstatus, "SELECT 0 As ESTATUS, 'Todos los Estatus...' As DESCRIPCION Union SELECT ESTATUS,DESCRIPCION FROM dbo.CONTABILIDAD_ORDEN_ESTATUS", "DESCRIPCION", "ESTATUS")
        Me.cmbBodegas.SelectedValue = 0

        Me.radAutorizar.Enabled = Me.puede_autorizar_
        Me.radRechazar.Enabled = Me.puede_autorizar_
        Me.rad1.Enabled = Me.puede_autorizar_

        Select Case Me.accion_
            Case "select"
                Me.brnGuardar.Enabled = False
                Me.cargarEncabezado()
                Me.cargarDetalle(True)
                Me.habilitarControles(False)
                Me.btnProcesar.Enabled = False
            Case "insert"
                Me.cmbEstatus.SelectedValue = 1
                Me.cargarDetalle(True)
                Me.habilitarControles(True)
                Me.radAutorizar.Enabled = False
                Me.btnProcesar.Enabled = False
            Case "update"
                Me.cargarEncabezado()
                Me.cargarDetalle(True)

                If Me.cmbEstatus.SelectedValue = 1 Or (Me.cmbEstatus.SelectedValue = 2 And (Me.puede_procesar_ Or Me.puede_autorizar_)) Then
                    Me.brnGuardar.Enabled = True
                    Me.habilitarControles(True)
                Else
                    Me.brnGuardar.Enabled = False
                    Me.habilitarControles(False)
                End If
            Case "delete"
                Me.brnGuardar.Text = "Eliminar"
                Me.brnGuardar.Image = My.Resources.editdelete
                Me.cargarEncabezado()
                Me.cargarDetalle(True)
                Me.habilitarControles(False)
                Me.btnProcesar.Enabled = False
        End Select

        setTitulo()
        Me.btnProcesar.Enabled = Me.puede_procesar_
        Me.txtRequisicion.Enabled = False
        Me.cmbEstatus.Enabled = False
        Me.txtOCGenerada.Enabled = False
        Me.txtUsuarioSolicita.Enabled = False
        Me.txtUsuarioReviso.Enabled = False
        Me.dtpFechaReviso.Enabled = False
        Me.dtpFechaCrea.Enabled = False
        If Me.cmbEstatus.SelectedValue = 4 Then
            Me.btnProcesar.Enabled = False
            Me.dgvDetalle.ReadOnly = True
        End If
        Iniciando = False
    End Sub

    Private Sub setTitulo()
        Select Case Me.accion_
            Case "select"
                Me.Text = "[Compras Requisición" & IIf(Me.afectan_inventario, " - Afectan Inventario", " - No Afectan Inventario") & "] Consultar Documento"
            Case "insert"
                Me.Text = "[Compras Requisición" & IIf(Me.afectan_inventario, " - Afectan Inventario", " - No Afectan Inventario") & "] Nuevo Documento"
            Case "update"
                Me.Text = "[Compras Requisición" & IIf(Me.afectan_inventario, " - Afectan Inventario", " - No Afectan Inventario") & "] Modificar Documento"
            Case "delete"
                Me.Text = "[Compras Requisición" & IIf(Me.afectan_inventario, " - Afectan Inventario", " - No Afectan Inventario") & "] Eliminar Documento"
        End Select
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        _reabrir = False
        Me.Dispose()
    End Sub

    Private Sub habilitarControles(ByVal _enabled As Boolean)
        For Each ctrl As Control In GroupBox1.Controls
            If ctrl.[GetType]().Name = "ComboBox" Then
                Dim _cmb As ComboBox = TryCast(ctrl, ComboBox)
                _cmb.Enabled = _enabled
            End If

            If ctrl.[GetType]().Name = "TextBox" Then
                Dim _txt As TextBox = TryCast(ctrl, TextBox)
                _txt.Enabled = _enabled
            End If

            If ctrl.[GetType]().Name = "DateTimePicker" Then
                Dim _dtp As DateTimePicker = TryCast(ctrl, DateTimePicker)
                _dtp.Enabled = _enabled
            End If

            If ctrl.[GetType]().Name = "Button" Then
                Dim _btn As Button = TryCast(ctrl, Button)
                _btn.Enabled = _enabled
            End If

            If ctrl.[GetType]().Name = "RadioButton" Then
                Dim _rad As RadioButton = TryCast(ctrl, RadioButton)
                _rad.Enabled = _enabled
            End If
        Next

        Me.dgvDetalle.ReadOnly = Not (_enabled)

        If Me.cmbEstatus.SelectedValue = 4 Or Me.accion_.Equals("insert") Or Me.accion_.Equals("select") Then
            Me.rad1.Enabled = False
            Me.radAutorizar.Enabled = False
            Me.radRechazar.Enabled = False
        End If
    End Sub

    Private Sub brnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnGuardar.Click
        Dim _continuar As Boolean = True

        If Me.cmbBodegas.SelectedValue = 0 Then
            _continuar = False
            Me.errorProvider.SetError(Me.cmbBodegas, "Seleccione una Bodega")
        End If

        If Me.dgvDetalle.Rows.Count <= 0 Then
            _continuar = False
            MsgBox("No ha agregado un detalle de Articulos", MsgBoxStyle.Critical, "Sistema")
        End If

        If _continuar Then
            Select Case Me.accion_
                Case "insert"
                    Me.brnGuardar.Enabled = False
                    Me.nuevoDocumento()
                Case "update"
                    Me.actualizarDocumento()
                Case "delete"
                    If MsgBox("¿Desea Eliminar la Requisición No." & Me.txtRequisicion.Text & "?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        Me.borrarDocumento()
                    End If
            End Select
            _reabrir = True
            setTitulo()
            Me.Dispose()

        End If
    End Sub

    Private Sub nuevoDocumento()
        Try
            Dim _sentencia As String = String.Empty
            Dim _sentenciadet As String = String.Empty
            'clases para enviar correos
            Dim sendMail As New EnviarCorreo
            _sentencia = "DECLARE @ID BIGINT " & Environment.NewLine
            _sentencia &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION(COMPAÑIA,FECHA_CREACION,FECHA_SOLICITA,BODEGA,ESTATUS,COMENTARIOS,AFECTAR_INVENTARIO,AUTORIZACION,USUARIO_CREA_SOLICITA,USUARIO_REVISA,FECHA_USUARIO_REVISA,ORDEN_GENERADA) " & Environment.NewLine
            _sentencia &= " VALUES (" & Compañia & ",'" & Format(Me.dtpFechaCrea.Value, "dd/MM/yyyy HH:mm:ss") & "','" & Format(Me.dtpFechaSolicitadas.Value, "dd/MM/yyyy HH:mm:ss") & "'," & Me.cmbBodegas.SelectedValue & ", 1,'" & Me.txtComentarios.Text & "'," & IIf(Me.afectan_inventario, "1", "0") & "," & IIf(Me.radAutorizar.Checked, "1", "0") & ", '" & Usuario & "', '" & Usuario & "', getdate(),0)" & Environment.NewLine
            _sentencia &= " SELECT @ID = SCOPE_IDENTITY() " & Environment.NewLine

            If Me.afectan_inventario Then
                For Each row As DataGridViewRow In Me.dgvDetalle.Rows
                    If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                        If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) And (row.Cells("CANTIDAD_SOLICITADA").Value > 0) Then
                            _sentenciadet &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE(REQUISICION, PRODUCTO, DESCRIPCION, UNIDAD_MEDIDA_SOLICITADA, PROVEEDOR, CANTIDAD_SOLICITADA, CANTIDAD_APROBADA, UNIDAD_MEDIDA_INVENTARIOS, EXISTENCIA, VERIFICAR, OBSERVACION, FACTOR_COMVERSION, SERVICIO, INTANGIBLE) VALUES(<id>, " & IIf(Me.afectan_inventario, row.Cells("PRODUCTO").Value, "0") & ", '" & row.Cells("DESCRIPCION").Value & "', " & row.Cells("UNIDAD_SOLICITADA").Value & ", " & row.Cells("PROVEEDOR").Value & ", " & row.Cells("CANTIDAD_SOLICITADA").Value & ", " & row.Cells("CANTIDAD_COMPRAR").Value & ", " & IIf(Me.afectan_inventario, row.Cells("UNIDAD_COMPRAR").Value, row.Cells("UNIDAD_SOLICITADA").Value) & ", " & IIf(Me.afectan_inventario, row.Cells("EXISTENCIA").Value, "0") & ", 0, '" & row.Cells("OBSERVACION").Value & "', " & IIf(Me.afectan_inventario, row.Cells("FACTOR").Value, "1") & ", 0, 0)" & Environment.NewLine
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In Me.dgvDetalle.Rows
                    If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                        If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) Then
                            Dim _servicio_val As String = "0"
                            Dim _intangible_val As String = "0"

                            If (Not row.Cells("SERVICIOS").Value.Equals(DBNull.Value)) Then
                                _servicio_val = IIf(row.Cells("SERVICIOS").Value = True, "1", "0")
                            End If

                            If (Not row.Cells("INTANGIBLES").Value.Equals(DBNull.Value)) Then
                                _intangible_val = IIf(row.Cells("INTANGIBLES").Value = True, "1", "0")
                            End If

                            _sentenciadet &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE(REQUISICION, PRODUCTO, DESCRIPCION, UNIDAD_MEDIDA_SOLICITADA, PROVEEDOR, CANTIDAD_SOLICITADA, CANTIDAD_APROBADA, UNIDAD_MEDIDA_INVENTARIOS, EXISTENCIA, VERIFICAR, OBSERVACION, FACTOR_COMVERSION, SERVICIO, INTANGIBLE) VALUES(<id>, " & IIf(Me.afectan_inventario, row.Cells("PRODUCTO").Value, "0") & ", '" & row.Cells("DESCRIPCION").Value & "', " & row.Cells("UNIDAD_SOLICITADA").Value & "," & IIf(row.Cells("PROVEEDOR").Value.ToString().Trim().Length > 0, row.Cells("PROVEEDOR").Value, "0") & ", 0, " & row.Cells("CANTIDAD_COMPRAR").Value & ", " & IIf(Me.afectan_inventario, row.Cells("UNIDAD_COMPRAR").Value, row.Cells("UNIDAD_SOLICITADA").Value) & ", " & IIf(Me.afectan_inventario, row.Cells("EXISTENCIA").Value, "0") & ", 0, '" & row.Cells("OBSERVACION").Value & "', " & IIf(Me.afectan_inventario, row.Cells("FACTOR").Value, "1") & ", " & _servicio_val & ", " & _intangible_val & ")" & Environment.NewLine
                        End If
                    End If
                Next
            End If

            Me.txtRequisicion.Text = _obj_compras.agregarDatos(_sentencia, _sentenciadet, "Select @@Identity")

            Me.habilitarControles(False)
            If CBool(Int(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 52"))) Then
                sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_AUTORIZADOR FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodegas.SelectedValue), _
                                IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                "Nueva Requisición No." & Me.txtRequisicion.Text, _
                                "<div style=" & Chr(34) & "font-family: Courier New;font-size: 11pt; color: Navy;" & Chr(34) & ">" & _
                                "Solicitante: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                "Bodega Solicitante: <strong>" & Me.cmbBodegas.Text & "</strong><br />" & _
                                "Producto requeridos para el <strong><u>" & Me.dtpFechaSolicitadas.Value.ToLongDateString() & "</u></strong><br /><br />" & _
                                "<strong>" & Me.txtComentarios.Text & "</strong></div>")
            End If

            MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
        Catch ex As Exception
            Me.brnGuardar.Enabled = True
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub actualizarDocumento()
        'Solo se ejecuta si esta en estado pendiente
        If (Me.cmbEstatus.SelectedValue = 1) Or ((Me.puede_autorizar_ Or Me.puede_procesar_) And (Me.cmbEstatus.SelectedValue <> 4)) Then
            Dim _filas_count As Integer = Me.dgvDetalle.Rows.Count
            Dim _filas_num As Integer = 1

            Dim _sentencia As String = String.Empty
            _sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION " & vbCrLf
            _sentencia &= "   SET FECHA_SOLICITA = '" & Format(Me.dtpFechaSolicitadas.Value, "dd/MM/yyyy HH:mm:ss") & "'" & vbCrLf
            _sentencia &= "     , BODEGA = " & Me.cmbBodegas.SelectedValue & vbCrLf
            _sentencia &= "     , ESTATUS = " & Me.cmbEstatus.SelectedValue & vbCrLf
            _sentencia &= "     , COMENTARIOS = '" & Me.txtComentarios.Text & "'" & vbCrLf
            '_sentencia &= "     , AUTORIZACION=" & IIf(Me.radAutorizar.Checked, "1", "0") & vbCrLf
            '_sentencia &= "     , USUARIO_REVISA='" & IIf(Me.puede_procesar_, Me.txtUsuarioReviso.Text, Usuario) & "'" & vbCrLf
            '_sentencia &= "     , FECHA_USUARIO_REVISA='" & IIf(Me.puede_procesar_, Format(Me.dtpFechaReviso.Value, "dd/MM/yyyy HH:mm:ss"), Format(Now, "dd/MM/yyyy HH:mm:ss")) & "'" & vbCrLf
            _sentencia &= " WHERE REQUISICION=" & Me.txtRequisicion.Text & vbCrLf

            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE WHERE REQUISICION=" & Me.txtRequisicion.Text & Environment.NewLine

            If Me.afectan_inventario Then
                For Each row As DataGridViewRow In Me.dgvDetalle.Rows
                    If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                        If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) And (row.Cells("CANTIDAD_SOLICITADA").Value > 0) Then
                            _sentencia &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE(REQUISICION, PRODUCTO, DESCRIPCION, UNIDAD_MEDIDA_SOLICITADA, CANTIDAD_SOLICITADA, PROVEEDOR, CANTIDAD_APROBADA, UNIDAD_MEDIDA_INVENTARIOS, EXISTENCIA, VERIFICAR, OBSERVACION, FACTOR_COMVERSION, SERVICIO, INTANGIBLE) VALUES(" & Me.txtRequisicion.Text & "," & IIf(Me.afectan_inventario, row.Cells("PRODUCTO").Value, "0") & ",'" & row.Cells("DESCRIPCION").Value & "'," & row.Cells("UNIDAD_SOLICITADA").Value & ", " & row.Cells("CANTIDAD_SOLICITADA").Value & ", " & row.Cells("PROVEEDOR").Value & ", " & row.Cells("CANTIDAD_COMPRAR").Value & ", " & IIf(Me.afectan_inventario, row.Cells("UNIDAD_COMPRAR").Value, row.Cells("UNIDAD_SOLICITADA").Value) & ", " & IIf(Me.afectan_inventario, row.Cells("EXISTENCIA").Value, "0") & ", 0, '" & row.Cells("OBSERVACION").Value & "', " & IIf(Me.afectan_inventario, row.Cells("FACTOR").Value, "1") & ", 0, 0)" & Environment.NewLine
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In Me.dgvDetalle.Rows
                    If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                        If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) Then
                            Dim _servicio_val As String = "0"
                            Dim _intangible_val As String = "0"

                            If (Not row.Cells("SERVICIOS").Value.Equals(DBNull.Value)) Then
                                _servicio_val = IIf(row.Cells("SERVICIOS").Value = True, "1", "0")
                            End If

                            If (Not row.Cells("INTANGIBLES").Value.Equals(DBNull.Value)) Then
                                _intangible_val = IIf(row.Cells("INTANGIBLES").Value = True, "1", "0")
                            End If

                            _sentencia &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE(REQUISICION, PRODUCTO, DESCRIPCION, UNIDAD_MEDIDA_SOLICITADA, CANTIDAD_SOLICITADA, PROVEEDOR, CANTIDAD_APROBADA, UNIDAD_MEDIDA_INVENTARIOS, EXISTENCIA, VERIFICAR, OBSERVACION, FACTOR_COMVERSION, SERVICIO, INTANGIBLE) VALUES(" & Me.txtRequisicion.Text & "," & IIf(Me.afectan_inventario, row.Cells("PRODUCTO").Value, "0") & ",'" & row.Cells("DESCRIPCION").Value & "'," & row.Cells("UNIDAD_SOLICITADA").Value & ", 0," & IIf(row.Cells("PROVEEDOR").Value.ToString().Trim().Length > 0, row.Cells("PROVEEDOR").Value, "0") & ", " & row.Cells("CANTIDAD_COMPRAR").Value & ", " & IIf(Me.afectan_inventario, row.Cells("UNIDAD_COMPRAR").Value, row.Cells("UNIDAD_SOLICITADA").Value) & ", " & IIf(Me.afectan_inventario, row.Cells("EXISTENCIA").Value, "0") & ",0,'" & row.Cells("OBSERVACION").Value & "', " & IIf(Me.afectan_inventario, row.Cells("FACTOR").Value, "1") & ", " & _servicio_val & ", " & _intangible_val & ")" & Environment.NewLine
                        End If
                    End If
                Next
            End If

            Dim _exito As Integer = _obj_compras.actualizarDatos(_sentencia)

            If _exito > 0 Then
                MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
            Else
                MsgBox("Falló la actualización", MsgBoxStyle.Information, "Sistema")
            End If
        Else
            MsgBox("No Puede Modificar el Documento.", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub borrarDocumento()
        'Solo se ejecuta si esta en estado pendiente
        If Me.cmbEstatus.SelectedValue = 1 Then
            Dim _sentencia As String = String.Empty
            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE WHERE REQUISICION=" & Me.txtRequisicion.Text & Environment.NewLine
            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION WHERE REQUISICION=" & Me.txtRequisicion.Text

            Dim _exito As Integer = _obj_compras.actualizarDatos(_sentencia)

            If _exito > 0 Then
                MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
                Me.Close()
            End If
        Else
            MsgBox("Solo Puede Eliminar un Documento Pendiente", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub cargarEncabezado()
        Try
            Dim Tabla As DataTable
            Tabla = _obj_compras.obtenerDatos("SELECT REQUISICION, FECHA_CREACION, FECHA_SOLICITA, BODEGA, ESTATUS, COMENTARIOS, AUTORIZACION, ORDEN_GENERADA, USUARIO_CREA_SOLICITA, USUARIO_REVISA, FECHA_USUARIO_REVISA FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION WHERE COMPAÑIA=" & Compañia & " AND REQUISICION=" & Me.codigo_)

            If Tabla.Rows.Count > 0 Then
                For Each _row As DataRow In Tabla.Rows
                    Me.txtRequisicion.Text = Me.codigo_
                    Me.dtpFechaCrea.Text = _row.Item("FECHA_CREACION")
                    Me.dtpFechaSolicitadas.Text = _row.Item("FECHA_SOLICITA")
                    Me.cmbBodegas.SelectedValue = _row.Item("BODEGA")
                    Me.txtComentarios.Text = _row.Item("COMENTARIOS")
                    Me.radAutorizar.Checked = _row.Item("AUTORIZACION")
                    'Se coloca de ultimo por que radAutorizar.Checked cambia el status 
                    Me.cmbEstatus.SelectedValue = _row.Item("ESTATUS")
                    Me.txtOCGenerada.Text = _row.Item("ORDEN_GENERADA")
                    Me.txtUsuarioSolicita.Text = _row.Item("USUARIO_CREA_SOLICITA")
                    Me.txtUsuarioReviso.Text = _row.Item("USUARIO_REVISA")
                    Me.dtpFechaReviso.Text = _row.Item("FECHA_USUARIO_REVISA")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub cargarDetalle(ByVal _add_columns As Boolean)
        Try
            dgvDetalle.DataSource = Nothing
            dgvDetalle.AutoGenerateColumns = False

            Dim Tabla As DataTable
            Tabla = _obj_compras.obtenerDatos("SELECT PRODUCTO, DESCRIPCION, UNIDAD_MEDIDA_SOLICITADA, CANTIDAD_SOLICITADA, PROVEEDOR, EXISTENCIA, UNIDAD_MEDIDA_INVENTARIOS, CANTIDAD_APROBADA, OBSERVACION, FACTOR_COMVERSION, (CANTIDAD_APROBADA*FACTOR_COMVERSION) AS EQUIVALENTE, SERVICIO, INTANGIBLE FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE WHERE REQUISICION=" & Me.codigo_)
            dgvDetalle.DataSource = Tabla

            If _add_columns Then
                Dim _codigo_producto As New DataGridViewTextBoxColumn()
                _codigo_producto.Name = "PRODUCTO"
                _codigo_producto.DataPropertyName = "PRODUCTO"

                Dim _btn_find As New DataGridViewButtonColumn()
                _btn_find.Name = "BUSCAR"
                _btn_find.Text = "Buscar"
                _btn_find.HeaderText = "Buscar"
                _btn_find.UseColumnTextForButtonValue = True

                Dim _descripcion_producto As New DataGridViewTextBoxColumn()
                _descripcion_producto.Name = "DESCRIPCION"
                _descripcion_producto.DataPropertyName = "DESCRIPCION"


                _combo_unidad_solicitada.Name = "UNIDAD_SOLICITADA"
                _combo_unidad_solicitada.DataPropertyName = "UNIDAD_MEDIDA_SOLICITADA"
                _combo_unidad_solicitada.DisplayMember = "DESCRIPCION_UNIDAD_MEDIDA"
                _combo_unidad_solicitada.ValueMember = "UNIDAD_MEDIDA"
                _combo_unidad_solicitada.DataSource = _obj_compras.obtenerDatos("SELECT UNIDAD_MEDIDA,DESCRIPCION_UNIDAD_MEDIDA FROM dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA WHERE COMPAÑIA=" & Compañia)
                _combo_unidad_solicitada.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

                Dim _cnt_solicitada As New DataGridViewTextBoxColumn()
                _cnt_solicitada.Name = "CANTIDAD_SOLICITADA"
                _cnt_solicitada.DataPropertyName = "CANTIDAD_SOLICITADA"

                _proveedor.Name = "PROVEEDOR"
                _proveedor.DataPropertyName = "PROVEEDOR"
                _proveedor.DisplayMember = "NOMBRE_PROVEEDOR"
                _proveedor.ValueMember = "PROVEEDOR"
                _proveedor.DataSource = _obj_compras.obtenerDatos("SELECT PROVEEDOR, NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA =" & Compañia & " ORDER BY NOMBRE_PROVEEDOR")
                _proveedor.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                _proveedor.AutoComplete = True


                Dim _existencia_col As New DataGridViewTextBoxColumn()
                _existencia_col.Name = "EXISTENCIA"
                _existencia_col.DataPropertyName = "EXISTENCIA"
                '_existencia_col.ReadOnly = True

                _combo_unidad_comprar.Name = "UNIDAD_COMPRAR"
                _combo_unidad_comprar.DataPropertyName = "UNIDAD_MEDIDA_INVENTARIOS"
                _combo_unidad_comprar.DisplayMember = "DESCRIPCION_UNIDAD_MEDIDA"
                _combo_unidad_comprar.ValueMember = "UNIDAD_MEDIDA"
                _combo_unidad_comprar.DataSource = _obj_compras.obtenerDatos("SELECT UNIDAD_MEDIDA,DESCRIPCION_UNIDAD_MEDIDA FROM dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA WHERE COMPAÑIA=" & Compañia)
                _combo_unidad_comprar.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

                Dim _cnt_equivalente As New DataGridViewTextBoxColumn()
                _cnt_equivalente.Name = "CNT_EQUIVALENTE"
                _cnt_equivalente.DataPropertyName = "EQUIVALENTE"

                Dim _cnt_comprar As New DataGridViewTextBoxColumn()
                _cnt_comprar.Name = "CANTIDAD_COMPRAR"
                _cnt_comprar.DataPropertyName = "CANTIDAD_APROBADA"

                Dim _observacion_col As New DataGridViewTextBoxColumn()
                _observacion_col.Name = "OBSERVACION"
                _observacion_col.DataPropertyName = "OBSERVACION"

                '
                Dim _factor_col As New DataGridViewTextBoxColumn()
                _factor_col.Name = "FACTOR"
                _factor_col.DataPropertyName = "FACTOR_COMVERSION"

                _servicio.Name = "SERVICIOS"
                _servicio.DataPropertyName = "SERVICIO"

                _intangible.Name = "INTANGIBLES"
                _intangible.DataPropertyName = "INTANGIBLE"

                dgvDetalle.Columns.Add(_codigo_producto)         '0               
                dgvDetalle.Columns.Add(_descripcion_producto)    '1
                dgvDetalle.Columns.Add(_btn_find)                '2
                dgvDetalle.Columns.Add(_combo_unidad_solicitada) '3
                dgvDetalle.Columns.Add(_cnt_solicitada)          '4

                dgvDetalle.Columns.Add(_proveedor)               '5

                dgvDetalle.Columns.Add(_cnt_comprar)             '6

                dgvDetalle.Columns.Add(_existencia_col)          '7
                dgvDetalle.Columns.Add(_combo_unidad_comprar)    '8
                dgvDetalle.Columns.Add(_cnt_equivalente)         '9     
                dgvDetalle.Columns.Add(_observacion_col)         '10
                dgvDetalle.Columns.Add(_factor_col)              '11

                dgvDetalle.Columns.Add(_servicio)                '12
                dgvDetalle.Columns.Add(_intangible)              '13

                dgvDetalle.Columns(1).Width = 215
                dgvDetalle.Columns(1).HeaderText = "Descripción"

                dgvDetalle.Columns(3).HeaderText = "Unidad Solicitada"

                dgvDetalle.Columns(4).Width = 70
                dgvDetalle.Columns(4).HeaderText = "Cantidad Solicitada"
                dgvDetalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dgvDetalle.Columns(5).HeaderText = "Proveedor"
                dgvDetalle.Columns(5).Width = 70

                dgvDetalle.Columns(6).HeaderText = IIf(Not afectan_inventario, "Cantidad", "Cantidad Aprobada")
                dgvDetalle.Columns(6).Width = 70
                dgvDetalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dgvDetalle.Columns(8).Width = 110
                dgvDetalle.Columns(8).HeaderText = "Unidad de Compra"

                dgvDetalle.Columns(9).Width = 70
                dgvDetalle.Columns(9).HeaderText = "Cantidad Comprar"
                dgvDetalle.Columns(9).ReadOnly = True
                dgvDetalle.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvDetalle.Columns(9).DefaultCellStyle.Format = "#,##0.00"

                dgvDetalle.Columns(10).Width = 175
                dgvDetalle.Columns(10).HeaderText = "Observaciones"

                dgvDetalle.Columns(11).HeaderText = "Factor"
                dgvDetalle.Columns(11).Visible = False

                dgvDetalle.Columns(12).HeaderText = "Servicio"
                dgvDetalle.Columns(12).Width = 75
                dgvDetalle.Columns(13).HeaderText = "Intangible"
                dgvDetalle.Columns(13).Width = 75

                'Solo el que procesa puede ver los proveedores
                If Me.puede_procesar_ Then
                    dgvDetalle.Columns(5).Visible = True
                    dgvDetalle.Columns(5).Width = 200
                Else
                    dgvDetalle.Columns(5).Visible = False
                End If

                If Me.afectan_inventario Then
                    dgvDetalle.Columns(0).Width = 60
                    dgvDetalle.Columns(0).HeaderText = "Código"
                    dgvDetalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvDetalle.Columns(1).ReadOnly = True

                    '************************************************************
                    dgvDetalle.Columns(2).Width = 45
                    dgvDetalle.Columns(2).HeaderText = "Buscar"
                    dgvDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Select Case Me.accion_
                        Case "select"
                            dgvDetalle.Columns(2).Visible = False
                            Me.dgvDetalle.ReadOnly = True
                        Case "insert"
                            dgvDetalle.Columns(2).Visible = True
                            Me.dgvDetalle.ReadOnly = False
                        Case "update"
                            dgvDetalle.Columns(2).Visible = True
                            Me.dgvDetalle.ReadOnly = False
                        Case "delete"
                            dgvDetalle.Columns(2).Visible = False
                            Me.dgvDetalle.ReadOnly = True
                    End Select
                    '************************************************************
                    dgvDetalle.Columns(3).Visible = True
                    dgvDetalle.Columns(3).ReadOnly = True
                    dgvDetalle.Columns(3).Width = 110

                    dgvDetalle.Columns(4).Visible = True

                    dgvDetalle.Columns(7).Width = 70
                    dgvDetalle.Columns(7).HeaderText = "Existencia"
                    dgvDetalle.Columns(7).ReadOnly = True
                    dgvDetalle.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvDetalle.Columns(7).DefaultCellStyle.Format = "#,##0.00"

                    dgvDetalle.Columns(8).ReadOnly = True

                    dgvDetalle.Columns(12).Visible = False
                    dgvDetalle.Columns(13).Visible = False
                Else
                    dgvDetalle.Columns(0).Visible = False
                    dgvDetalle.Columns(1).ReadOnly = False
                    dgvDetalle.Columns(2).Visible = False
                    dgvDetalle.Columns(3).ReadOnly = False
                    dgvDetalle.Columns(4).Visible = False
                    dgvDetalle.Columns(7).Visible = False
                    dgvDetalle.Columns(8).Visible = False
                    dgvDetalle.Columns(9).Visible = False

                    dgvDetalle.Columns(12).Visible = True
                    dgvDetalle.Columns(13).Visible = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim contador As Integer = 0
        Dim Sql, OCS As String
        Sql = "SELECT ORDEN_GENERADA FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION WHERE REQUISICION = " & Me.txtRequisicion.Text.Trim()
        OCS = jClass.obtenerEscalar(Sql)
        If OCS.Length > 1 Then
            MsgBox("ESTA REQUISICION YA FUE PROCESADA" & vbCrLf & vbCrLf & " ORDENES DE COMPRA GENERADAS: " & OCS)
            Return
        End If
        If Me.cmbEstatus.SelectedValue = 2 And Me.puede_procesar_ Then
            If MsgBox("Desea Procesar y Generar la Orden de Compra?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                Try
                    Me.btnProcesar.Enabled = False
                    Dim _exito As Integer = 0
                    'Separando los proveedores
                    Sql = "SELECT PROVEEDOR FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE WHERE REQUISICION = " & Me.txtRequisicion.Text.Trim() & " GROUP BY PROVEEDOR"
                    Dim _oc_proveedores As New DataTable()
                    _oc_proveedores = _obj_compras.obtenerDatos(Sql)

                    Dim _num_oc As String = String.Empty

                    If _oc_proveedores.Rows.Count > 0 Then
                        For Each _proveedor_orden_compra As DataRow In _oc_proveedores.Rows
                            contador += 1
                            'Validando que el Proveedor se ha definido
                            If _proveedor_orden_compra.Item("PROVEEDOR").Equals(DBNull.Value) Then
                                Throw New Exception("No ha definido un proveedor para esta requisición.")
                            End If

                            If _proveedor_orden_compra.Item("PROVEEDOR") = 0 Then
                                Throw New Exception("No ha definido un proveedor para esta requisición.")
                            End If
                            '============================================================='
                            Dim Percepcion As Integer = 0

                            Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO,NRC FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
                            Sql = Sql & " WHERE COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & _proveedor_orden_compra.Item("PROVEEDOR")
                            Dim _provee As New DataTable()
                            _provee = _obj_compras.obtenerDatos(Sql)
                            Sql = "Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS " & Compañia & ", 'OC', 0"
                            Dim _corre As New DataTable()
                            _corre = _obj_compras.obtenerDatos(Sql)
                            If _provee.Rows.Count > 0 Then
                                For Each row As DataRow In _provee.Rows
                                    If _corre.Rows.Count > 0 Then
                                        For Each _correla As DataRow In _corre.Rows

                                            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONSTANTES " & Compañia & ", " & IIf(row.Item("TIPO_PROVEEDOR") = 3, "2", "1")
                                            Dim _percepcion As New DataTable()
                                            _percepcion = _obj_compras.obtenerDatos(Sql)
                                            If _percepcion.Rows.Count > 0 Then
                                                For Each _constante As DataRow In _percepcion.Rows

                                                    _num_oc &= IIf(contador = 1, "", ",") & _correla.Item("ULTIMO").ToString()

                                                    Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD "
                                                    Sql &= " @COMPAÑIA = " & Compañia
                                                    Sql &= ", @ORDEN_COMPRA = " & _correla.Item("ULTIMO")
                                                    Sql &= ", @PROCESADA = 0"
                                                    Sql &= ", @BODEGA = " & Me.cmbBodegas.SelectedValue
                                                    Sql &= ", @PROVEEDOR = " & _proveedor_orden_compra.Item("PROVEEDOR")
                                                    Sql &= ", @TIPO_CONTRIBUYENTE = " & row.Item("TIPO_PROVEEDOR")
                                                    Sql &= ", @PORCENTAJE_PERCEPCION = " & _constante.Item("CONSTANTE")
                                                    Sql &= ", @FORMA_PAGO = " & row.Item("FORMA_PAGO")
                                                    Sql &= ", @CONDICION_PAGO = " & row.Item("CONDICION_PAGO")
                                                    Sql &= ", @OBSERVACIONES = ''"
                                                    Sql &= ", @USUARIO = '" & Usuario & "'"
                                                    Sql &= ", @IUD = 'I'"
                                                    Sql &= ", @AFECTAR_INVENTARIOS = " & IIf(Me.afectan_inventario, "'1'", "'0'")
                                                    'Tipo Documento 2 es credito Fiscal
                                                    Sql &= ", @TIPO_DOCUMENTO = " & IIf(row.Item("NRC").Equals(String.Empty), 7, 2)
                                                    Sql &= ", @PORDESC = 0"
                                                    Sql &= ", @USUARIO_CREA_SOLICITA='" & Me.txtUsuarioSolicita.Text & "'"
                                                    Sql &= ", @USUARIO_REVISA='" & Me.txtUsuarioReviso.Text & "'"
                                                    Sql &= ", @FECHA_USUARIO_REVISA='" & Format(Me.dtpFechaReviso.Value, "dd/MM/yyyy HH:mm:ss") & "'"
                                                    Sql &= ", @FECHA_USUARIO_SOLICITA='" & Format(Me.dtpFechaCrea.Value, "dd/MM/yyyy HH:mm:ss") & "'"
                                                    Sql &= ", @DESCUENTO = 0" & Environment.NewLine

                                                    Dim _linea As Integer = 0
                                                    Dim _costo_tot As Decimal = 0

                                                    For Each _fila As DataGridViewRow In Me.dgvDetalle.Rows
                                                        If (_fila.Cells("DESCRIPCION").Value IsNot Nothing) Then
                                                            If (Not _fila.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) Then

                                                                'Solo los articulos de proveedor en curso
                                                                If CInt(_proveedor_orden_compra.Item("PROVEEDOR").ToString()) = _fila.Cells("PROVEEDOR").Value Then
                                                                    'Aqui es de traer de las listas el costo
                                                                    Dim _costo_unit As Decimal = 0
                                                                    If Me.afectan_inventario Then
                                                                        _costo_unit = obtenerPrecioLista(_fila.Cells("PRODUCTO").Value, _fila.Cells("PROVEEDOR").Value)
                                                                    End If
                                                                    _linea = _linea + 1
                                                                    _costo_tot = _costo_tot + _costo_unit * (_fila.Cells("CANTIDAD_COMPRAR").Value * _fila.Cells("FACTOR").Value)

                                                                    'Servicio y Intangibles
                                                                    Dim _servicio_val As String = "0"
                                                                    Dim _intangible_val As String = "0"

                                                                    If Not Me.afectan_inventario Then
                                                                        If (Not _fila.Cells("SERVICIOS").Value.Equals(DBNull.Value)) Then
                                                                            _servicio_val = IIf(_fila.Cells("SERVICIOS").Value = True, "1", "0")
                                                                        End If

                                                                        If (Not _fila.Cells("INTANGIBLES").Value.Equals(DBNull.Value)) Then
                                                                            _intangible_val = IIf(_fila.Cells("INTANGIBLES").Value = True, "1", "0")
                                                                        End If
                                                                    End If

                                                                    Sql &= "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD " & Compañia & ", " & _correla.Item("ULTIMO") & ", " & _linea & ", " & IIf(Me.afectan_inventario, _fila.Cells("PRODUCTO").Value, "0") & ", '" & _fila.Cells("DESCRIPCION").Value.ToString().ToUpper() & "', " & _fila.Cells("UNIDAD_COMPRAR").Value & ", " & (_fila.Cells("CANTIDAD_COMPRAR").Value * _fila.Cells("FACTOR").Value) & ", 0, " & _costo_unit & ", " & _servicio_val & ", '" & Usuario & "', 'I', '0',0," & _intangible_val & ",'" & IIf(_fila.Cells("OBSERVACION").Value IsNot Nothing, _fila.Cells("OBSERVACION").Value, "Sin Comentarios") & "'" & Environment.NewLine
                                                                End If
                                                            End If
                                                        End If
                                                    Next

                                                    If CInt(row.Item("TIPO_PROVEEDOR")) = 3 And _costo_tot >= 100 Then
                                                        Percepcion = 1
                                                    End If

                                                    Sql &= "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & _correla.Item("ULTIMO") & ", @AUTORIZADA = 0, @ANULADA =0, @SUBTOTAL = " & _costo_tot & ", @IVA =0.00, @TOTAL = " & _costo_tot & ", @PERCEPCION =" & Percepcion & ", @TOTAL_FINAL =" & _costo_tot & ", @COMENTARIO ='', @USUARIO ='" & Usuario & "', @IUD ='Y',	@RENTA = 0,	@DESCUENTO = 0.00" & Environment.NewLine

                                                    _exito = _obj_compras.actualizarDatos(Sql)
                                                Next _constante
                                            End If
                                        Next _correla
                                    End If
                                Next row
                            End If
                            '============================================================='
                        Next

                        Dim _sentencia As String = String.Empty
                        '_sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION SET USUARIO_REVISA ='" & Usuario & "', FECHA_USUARIO_REVISA=GETDATE(), ESTATUS = 4, ORDEN_GENERADA='" & _num_oc & "' WHERE REQUISICION=" & Me.txtRequisicion.Text & Environment.NewLine
                        _sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION SET ESTATUS = 4, ORDEN_GENERADA='" & _num_oc & "' WHERE REQUISICION=" & Me.txtRequisicion.Text & Environment.NewLine

                        _exito = _obj_compras.actualizarDatos(_sentencia)
                        If _exito > 0 Then
                            Me.cmbEstatus.SelectedValue = 4
                            Me.txtOCGenerada.Text = _num_oc
                            MsgBox("Se genero la Orden de Compra con el Numero: " & _num_oc & ", Operación Exitosa..", MsgBoxStyle.Information, "Sistema")
                        End If
                    End If
                    If CBool(Int(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 52"))) Then
                        'para el autorizador
                        sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_AUTORIZADOR FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodegas.SelectedValue), _
                                        IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                        "Requisición No." & Me.txtRequisicion.Text & " procesada", _
                                        "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                                        "Orden(es) Generada(s): <strong>" & Me.txtOCGenerada.Text & "</strong><br />" & _
                                        "Usuario Solicitante: <strong>" & jClass.obtenerEscalar("SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioSolicita.Text & "'") & "</strong><br />" & _
                                        "Bodega Solicitante: <strong>" & Me.cmbBodegas.Text & "</strong><br />" & _
                                        "Producto requeridos para el <strong>" & Me.dtpFechaSolicitadas.Value.ToLongDateString() & "</strong><br /><br />" & _
                                        "Procesado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                        "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>PENDIENTE FINALIZACION ORDEN DE COMPRA Y <br />AUTORIZACION DE GERENCIA</strong><p></div>")

                        'para el solicitante
                        sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioSolicita.Text & "'"), _
                                        IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                        "Requisición No." & Me.txtRequisicion.Text & " procesada", _
                                        "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                                        "Orden(es) de Compra Generada(s): <strong>" & Me.txtOCGenerada.Text & "</strong><br />" & _
                                        "Req. Autorizada por: <strong>" & jClass.obtenerEscalar("SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioReviso.Text & "'") & "</strong><br />" & _
                                        "Producto requeridos para el <strong>" & Me.dtpFechaSolicitadas.Value.ToLongDateString() & "</strong><br />" & _
                                        "Procesado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                        "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>PENDIENTE FINALIZACION ORDEN DE COMPRA Y <br />AUTORIZACION DE GERENCIA</strong><p></div>")
                    End If
                Catch ex As Exception
                    Me.btnProcesar.Enabled = True
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
                End Try


            End If
        Else
            If Me.cmbEstatus.SelectedValue = 4 Then
                Me.btnProcesar.Enabled = True
                MsgBox("El Documento ya Esta Procesado.", MsgBoxStyle.Critical, "Sistema")
            Else
                Me.btnProcesar.Enabled = True
                MsgBox("No Puede Procesar un Documento No Autorizado.", MsgBoxStyle.Critical, "Sistema")
            End If

        End If
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstatus.SelectedIndexChanged

        Select Case cmbEstatus.SelectedValue.ToString()
            Case "1"
                'PENDIENTE
                cmbEstatus.BackColor = Color.Yellow
                cmbEstatus.ForeColor = Color.Black                
            Case "2"
                'AUTORIZADO
                cmbEstatus.BackColor = Color.SkyBlue
                cmbEstatus.ForeColor = Color.Black
            Case "3"
                'RECHAZADO
                cmbEstatus.BackColor = Color.Red
                cmbEstatus.ForeColor = Color.White
            Case "4"
                'PROCESADO
                cmbEstatus.BackColor = Color.Green
                cmbEstatus.ForeColor = Color.White
        End Select
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Try
            If Me.afectan_inventario Then
                If e.ColumnIndex = 0 And dgvDetalle(0, e.RowIndex).Value.ToString().Length > 0 Then
                    Me._producto = Me._obj_compras.obtenerDatos("SELECT P.PRODUCTO,P.DESCRIPCION_PRODUCTO, P.UNIDAD_MEDIDA, P.UNIDAD_COMPRA, (SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBodegas.SelectedValue.ToString() & ", P.PRODUCTO, GETDATE())) As EXISTENCIA, P.FACTOR_COMVERSION FROM dbo.INVENTARIOS_CATALOGO_PRODUCTOS P WHERE P.PRODUCTO = " & dgvDetalle(0, e.RowIndex).Value.ToString())

                    Me._tbl_proveedor = Me._obj_compras.obtenerDatos("SELECT PROVEEDOR FROM [dbo].[CONTABILIDAD_ORDEN_LISTA_PRECIOS] P INNER JOIN [dbo].[CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE] D ON P.LISTA = D.LISTA WHERE P.HABILITADA=1 AND COMPAÑIA = 1 AND D.PRODUCTO=" & dgvDetalle(0, e.RowIndex).Value.ToString() & " GROUP BY PROVEEDOR")

                    If Me._producto.Rows.Count > 0 Then
                        If Me._tbl_proveedor.Rows.Count > 0 Then
                            For Each _row As DataRow In _producto.Rows
                                Me.dgvDetalle(1, e.RowIndex).Value = _row.Item("DESCRIPCION_PRODUCTO")
                                Me.dgvDetalle(3, e.RowIndex).Value = _row.Item("UNIDAD_COMPRA")

                                If DBNull.Value.Equals(Me.dgvDetalle(4, e.RowIndex).Value) Then
                                    Me.dgvDetalle(4, e.RowIndex).Value = 0.0  'Cantidad Solicitada
                                End If

                                If DBNull.Value.Equals(Me.dgvDetalle(6, e.RowIndex).Value) Then
                                    Me.dgvDetalle(6, e.RowIndex).Value = 0.0  'Cantidad Aprobada
                                End If

                                Me.dgvDetalle(7, e.RowIndex).Value = _row.Item("EXISTENCIA")
                                Me.dgvDetalle(8, e.RowIndex).Value = _row.Item("UNIDAD_MEDIDA")

                                If DBNull.Value.Equals(Me.dgvDetalle(9, e.RowIndex).Value) Then
                                    Me.dgvDetalle(9, e.RowIndex).Value = 0.0  'Cantidad Equivalente
                                End If

                                If DBNull.Value.Equals(Me.dgvDetalle(10, e.RowIndex).Value) Then
                                    Me.dgvDetalle(10, e.RowIndex).Value = ""
                                End If

                                Me.dgvDetalle(11, e.RowIndex).Value = _row.Item("FACTOR_COMVERSION")

                                'Proveedor
                                For Each _row_provee As DataRow In _tbl_proveedor.Rows
                                    Me.dgvDetalle(5, e.RowIndex).Value = _row_provee.Item("PROVEEDOR")
                                Next
                                If Me._tbl_proveedor.Rows.Count > 1 Then
                                    Me.dgvDetalle(10, e.RowIndex).Value = "Varios Proveedores Suministran este Artículo, Consulte"
                                End If
                                'Servicio e Intangibles son falsos
                                If DBNull.Value.Equals(Me.dgvDetalle(12, e.RowIndex).Value) Then
                                    Me.dgvDetalle(12, e.RowIndex).Value = 0
                                End If
                                If DBNull.Value.Equals(Me.dgvDetalle(13, e.RowIndex).Value) Then
                                    Me.dgvDetalle(13, e.RowIndex).Value = 0
                                End If
                            Next
                        Else
                            Throw New Exception("No existe un listado de articulos para este proveedor.")
                        End If
                    Else
                        Throw New Exception("No existe este artículo.")
                    End If
                End If

                If (dgvDetalle(0, e.RowIndex).Value.ToString().Length > 0) Then
                    'Seteando la misma cantidad solicitada en aprobada
                    If Not DBNull.Value.Equals(Me.dgvDetalle(6, e.RowIndex).Value) And e.ColumnIndex = 4 Then
                        If Me.dgvDetalle(6, e.RowIndex).Value >= 0 Then
                            Me.dgvDetalle(6, e.RowIndex).Value = Me.dgvDetalle(4, e.RowIndex).Value
                            Me.dgvDetalle(9, e.RowIndex).Value = Me.dgvDetalle(6, e.RowIndex).Value * Me.dgvDetalle(11, e.RowIndex).Value
                        End If
                    End If

                    'Seteando las cantidades equivalentes si se modifican las aprobadas
                    If e.ColumnIndex = 6 And String.IsNullOrEmpty(Convert.ToString(Me.dgvDetalle(11, e.RowIndex).Value)) = False Then
                        Me.dgvDetalle(9, e.RowIndex).Value = Me.dgvDetalle(6, e.RowIndex).Value * Me.dgvDetalle(11, e.RowIndex).Value
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: No existe el Código Ingresado, " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
        If Me.afectan_inventario Then

            If Me.cmbBodegas.SelectedValue > 0 Then
                Dim senderGrid = DirectCast(sender, DataGridView)
                If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
                    Dim Busqueda As New Contabilidad_OC_BuscarProductos()                    
                    Busqueda._bodega = Me.cmbBodegas.SelectedValue
                    'Busqueda._bodegas
                    'Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
                    'Busqueda.Compañia_Value = Compañia
                    'Busqueda.Bodega_Value = Me.cmbBodegas.SelectedValue
                    'Busqueda.cmbBODEGA.Enabled = False
                    'Busqueda.BuscaTodos = True
                    Busqueda.ShowDialog()
                    If Producto <> "" Then
                        Me.dgvDetalle(0, e.RowIndex).Value = Producto
                        Me.dgvDetalle(0, e.RowIndex).Selected = True
                        Me.dgvDetalle(1, e.RowIndex).Value = Descripcion_Producto
                        Me.dgvDetalle.CurrentCell = dgvDetalle.Rows(e.RowIndex).Cells(0)
                        Producto = String.Empty
                    End If
                End If
            Else
                MsgBox("Seleccione una bodega...", MsgBoxStyle.Information, "Sistema")
            End If
            
        End If
    End Sub

    'Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Busqueda As New FrmBuscarProveedor
    '    Busqueda.Compañia_Value = Compañia
    '    Busqueda.CbxCompania.Enabled = False
    '    Busqueda.ShowDialog()
    '    If ParamNomProvee <> "" Then
    '        Me.cmbProveedor.SelectedValue = ParamCodProvee
    '    End If
    '    ParamCodProvee = Nothing
    '    ParamNomProvee = ""
    'End Sub

    Private Sub radAutorizar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAutorizar.CheckedChanged
        Dim _actual As Integer = Me.cmbEstatus.SelectedValue
        If Me.radAutorizar.Checked Then
            Me.cmbEstatus.SelectedValue = 2
            Dim _sentencia As String = String.Empty
            If Not Iniciando Then
                _sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION " & vbCrLf
                _sentencia &= "   SET AUTORIZACION = 1" & vbCrLf
                _sentencia &= "     , ESTATUS = 2" & vbCrLf
                _sentencia &= "     , USUARIO_REVISA = '" & Usuario & "'" & vbCrLf
                _sentencia &= "     , FECHA_USUARIO_REVISA = CONVERT(DATETIME, '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "', 103)" & vbCrLf
                _sentencia &= " WHERE REQUISICION=" & CInt(Val(Me.txtRequisicion.Text)) & vbCrLf
                If jClass.ejecutarComandoSql(New SqlCommand(_sentencia)) > 0 Then
                    If CBool(Int(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 52"))) Then
                        'para el encargado de compras
                        sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_COMPRAS FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodegas.SelectedValue), _
                                        IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                        "Requisición No." & Me.txtRequisicion.Text & " autorizada", _
                                        "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                                        "Solicitante: <strong>" & jClass.obtenerEscalar("SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioSolicita.Text & "'") & "</strong><br />" & _
                                        "Bodega Solicitante: <strong>" & Me.cmbBodegas.Text & "</strong><br />" & _
                                        "Autorizado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                        "Producto requeridos para el <strong><u>" & Me.dtpFechaSolicitadas.Value.ToLongDateString() & "</u></strong><br /><br />" & _
                                        "<strong>" & Me.txtComentarios.Text & "</strong></div>")

                        'para el solicitante
                        sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioSolicita.Text & "'"), _
                                        IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                        "Requisición No." & Me.txtRequisicion.Text & " autorizada", _
                                        "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                                        "Autorizado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                        "Producto requeridos para el <strong><u>" & Me.dtpFechaSolicitadas.Value.ToLongDateString() & "</u></strong><br /><br />" & _
                                        "<strong>" & Me.txtComentarios.Text & "</strong></div>")
                    End If
                End If
            Else
                Me.cmbEstatus.SelectedValue = _actual
            End If
        End If
    End Sub

    Private Sub radRechazar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRechazar.CheckedChanged
        Dim _actual As Integer = Me.cmbEstatus.SelectedValue
        If Me.radRechazar.Checked Then
            Me.cmbEstatus.SelectedValue = 3
            Dim _sentencia As String = String.Empty
            If Not Iniciando Then
                _sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION " & vbCrLf
                _sentencia &= "   SET AUTORIZACION = 0" & vbCrLf
                _sentencia &= "     , ESTATUS = 3" & vbCrLf
                _sentencia &= "     , USUARIO_REVISA = '" & Usuario & "'" & vbCrLf
                _sentencia &= "     , FECHA_USUARIO_REVISA = CONVERT(DATETIME, '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "', 103)" & vbCrLf
                _sentencia &= " WHERE REQUISICION=" & CInt(Val(Me.txtRequisicion.Text)) & vbCrLf
                If jClass.ejecutarComandoSql(New SqlCommand(_sentencia)) > 0 Then
                    If CBool(Int(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 52"))) Then
                        'para el solicitante
                        sendMail.Enviar(jClass.obtenerEscalar("SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Me.txtUsuarioSolicita.Text & "'"), _
                                        IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                                        "Requisición No." & Me.txtRequisicion.Text & " RECHAZADA", _
                                        "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                                        "Rechazada por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                                        "<strong>" & Me.txtComentarios.Text & "</strong></div>")
                    End If
                End If
            Else
                Me.cmbEstatus.SelectedValue = _actual
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetalle.CellFormatting
        Try
            If e.ColumnIndex = Me.dgvDetalle.Columns(2).Index Then
                With Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    .ToolTipText = "Buscar Productos"
                End With
            End If

            If e.ColumnIndex = Me.dgvDetalle.Columns(1).Index Then
                If e.Value IsNot Nothing Then
                    e.Value = e.Value.ToString().ToUpper()
                    e.FormattingApplied = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Function obtenerPrecioLista(ByVal _producto As Integer, ByVal _provee As Integer) As Decimal
        Dim _precio As Decimal = 0.0
        Dim _lista As New DataTable()
        Dim _sql As String = String.Empty
        _sql = "SELECT COSTO_UNITARIO " & Environment.NewLine
        _sql &= "FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS P " & Environment.NewLine
        _sql &= "INNER JOIN dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE D " & Environment.NewLine
        _sql &= "ON P.LISTA = D.LISTA " & Environment.NewLine
        _sql &= "WHERE HABILITADA=1 AND PROVEEDOR=" & _provee & " AND PRODUCTO=" & _producto.ToString() & Environment.NewLine
        _sql &= "AND CONVERT(DATE, GETDATE(), 103) BETWEEN CONVERT(DATE, VIGENCIA_DESDE, 103) AND CONVERT(DATE, VIGENCIA_HASTA, 103)" & Environment.NewLine
        _lista = Me._obj_compras.obtenerDatos(_sql)

        If _lista.Rows.Count > 0 Then
            For Each _constante As DataRow In _lista.Rows
                _precio = _constante.Item("COSTO_UNITARIO")
            Next _constante
        Else
            Throw New Exception("No existe precio para este articulo: " & _producto.ToString())
        End If

        Return _precio
    End Function

    Private Sub dgvDetalle_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellLeave
        Try
            If e.ColumnIndex = 0 And dgvDetalle(0, e.RowIndex).Value.ToString().Length > 0 Then
                dgvDetalle.BeginEdit(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Desea Copiar el Documento Completo?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            Me.nuevoDocumento()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Rpts.CargaRequisicion(Me.txtRequisicion.Text)
        Rpts.ShowDialog()
    End Sub

    Private Sub Contabilidad_OrdenCompra_Requisicion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class