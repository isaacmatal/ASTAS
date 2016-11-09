Imports System.Data.SqlClient

Public Class Contabilidad_Orden_Lista_Precios_Proveedor
    Public codigo_ As Integer
    Public accion_ As String
    Dim _obj_compras As New Compras()
    Dim _encabezado As New DataTable()
    Dim _producto As New DataTable()
    Dim _detalle As New DataTable()
    Dim _combo_unidad_medida As New DataGridViewComboBoxColumn
    Dim Rpts As New frmReportes_Ver

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compañia_Value = Compañia
        Busqueda.CbxCompania.Enabled = False
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.cmbProveedor.SelectedValue = ParamCodProvee
        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""
    End Sub

    Private Sub Contabilidad_Orden_Lista_Precios_Proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ToolTip1 As New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(Me.btnBuscarProveedor, "Buscar Proveedor")

        Me._obj_compras.setearCombo(Me.cmbProveedor, "SELECT PROVEEDOR, NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA =" & Compañia, "NOMBRE_PROVEEDOR", "PROVEEDOR")

        Select Case Me.accion_
            Case "select"
                Me.brnGuardar.Enabled = False
                Me.cargarEncabezado()
                Me.cargarDetalle(True)
                Me.habilitarControles(False)
                calcularPeriodo()
            Case "insert"
                Me.txtusuarioCreo.Text = Usuario
                Me.txtusuarioModifica.Text = Usuario
                Me.cargarDetalle(True)
                Me.habilitarControles(True)
                Me.chkHabilitado.Checked = True
            Case "update"
                Me.txtusuarioModifica.Text = Usuario
                Me.dtpFechaModifica.Value = DateTime.Now.ToLongDateString().Replace("a.m.", String.Empty).Replace("p.m.", String.Empty)
                Me.cargarEncabezado()
                Me.cargarDetalle(True)
                calcularPeriodo()
            Case "delete"
                Me.brnGuardar.Text = "Eliminar"
                Me.brnGuardar.Image = My.Resources.editdelete
                Me.cargarEncabezado()
                Me.cargarDetalle(True)
                Me.habilitarControles(False)
                calcularPeriodo()
        End Select

        setTitulo()
        Me.txtLista.Enabled = False
        Me.txtusuarioModifica.Enabled = False
        Me.txtusuarioCreo.Enabled = False
        Me.dtpFechaCrea.Enabled = False
        Me.dtpFechaModifica.Enabled = False

        Me.dgvLista.Focus()
        'Me.dgvLista.Rows(0).Cells(0).Selected = True
        Me.dgvLista.CurrentCell = Me.dgvLista.Rows(0).Cells(0)
    End Sub

    Private Sub setTitulo()
        Select Case Me.accion_
            Case "select"
                Me.Text = "[Compras Listado de Precios] Consultar Documento"
            Case "insert"
                Me.Text = "[Compras Listado de Precios] Nuevo Documento"
            Case "update"
                Me.Text = "[Compras Listado de Precios] Modificar Documento"
            Case "delete"
                Me.Text = "[Compras Listado de Precios] Eliminar Documento"
        End Select
    End Sub

    Private Sub cargarEncabezado()
        Try
            Dim Tabla As DataTable
            Tabla = _obj_compras.obtenerDatos("SELECT LISTA,COMPAÑIA,FECHA,VIGENCIA_DESDE,VIGENCIA_HASTA,PROVEEDOR,USUARIO_CREACION,USUARIO_MODIFICA,FECHA_USUARIO_MODIFICA,TIEMPOS_ENTREGA,HABILITADA FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS WHERE LISTA=" & Me.codigo_)

            If Tabla.Rows.Count > 0 Then
                For Each _row As DataRow In Tabla.Rows
                    Me.txtLista.Text = Me.codigo_
                    Me.dtpFechaCrea.Text = _row.Item("FECHA")
                    Me.dtpVigenciaDesde.Text = _row.Item("VIGENCIA_DESDE")
                    Me.dtpVigenciaHasta.Text = _row.Item("VIGENCIA_HASTA")
                    Me.cmbProveedor.SelectedValue = _row.Item("PROVEEDOR")
                    Me.txtusuarioCreo.Text = _row.Item("USUARIO_CREACION")
                    Me.txtusuarioModifica.Text = _row.Item("USUARIO_MODIFICA")
                    Me.dtpFechaModifica.Text = _row.Item("FECHA_USUARIO_MODIFICA")
                    Me.nudTiemposEntrega.Value = _row.Item("TIEMPOS_ENTREGA")
                    Me.chkHabilitado.Checked = _row.Item("HABILITADA")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub cargarDetalle(ByVal _add_columns As Boolean)
        Try
            Me.dgvLista.DataSource = Nothing
            dgvLista.AutoGenerateColumns = False

            Dim Tabla As DataTable
            Tabla = _obj_compras.obtenerDatos("SELECT L.PRODUCTO,P.DESCRIPCION_PRODUCTO AS DESCRIPCION,P.UNIDAD_MEDIDA,COSTO_UNITARIO FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE L INNER JOIN dbo.INVENTARIOS_CATALOGO_PRODUCTOS P ON L.PRODUCTO = P.PRODUCTO WHERE P.COMPAÑIA =1 AND LISTA=" & Me.codigo_)
            dgvLista.DataSource = Tabla

            If _add_columns Then
                Dim _codigo_producto As New DataGridViewTextBoxColumn()
                _codigo_producto.Name = "PRODUCTO"
                _codigo_producto.DataPropertyName = "PRODUCTO"

                Dim _btn_find As New DataGridViewButtonColumn()
                _btn_find.Name = "BUSCAR"
                _btn_find.Text = "..."

                Dim _descripcion_producto As New DataGridViewTextBoxColumn()
                _descripcion_producto.Name = "DESCRIPCION"
                _descripcion_producto.DataPropertyName = "DESCRIPCION"

                _combo_unidad_medida.Name = "UNIDAD_COMPRA"
                _combo_unidad_medida.DataPropertyName = "UNIDAD_MEDIDA"
                _combo_unidad_medida.DisplayMember = "DESCRIPCION_UNIDAD_MEDIDA"
                _combo_unidad_medida.ValueMember = "UNIDAD_MEDIDA"
                _combo_unidad_medida.DataSource = _obj_compras.obtenerDatos("SELECT UNIDAD_MEDIDA,DESCRIPCION_UNIDAD_MEDIDA FROM dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA WHERE COMPAÑIA=" & Compañia)
                _combo_unidad_medida.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

                Dim _costo As New DataGridViewTextBoxColumn()
                _costo.Name = "COSTO"
                _costo.DataPropertyName = "COSTO_UNITARIO"

                dgvLista.Columns.Add(_codigo_producto)
                dgvLista.Columns.Add(_descripcion_producto)
                dgvLista.Columns.Add(_btn_find)
                dgvLista.Columns.Add(_combo_unidad_medida)
                dgvLista.Columns.Add(_costo)

                dgvLista.Columns(0).Width = 100
                dgvLista.Columns(0).HeaderText = "Código"

                dgvLista.Columns(1).ReadOnly = True
                dgvLista.Columns(1).Width = 325
                dgvLista.Columns(1).HeaderText = "Descripción"

                dgvLista.Columns(2).Width = 25
                dgvLista.Columns(2).HeaderText = "Buscar"
                If Me.accion_.Equals("delete") Or Me.accion_.Equals("select") Then
                    dgvLista.Columns(2).Visible = False
                End If

                dgvLista.Columns(3).HeaderText = "Unidad Medida"
                'dgvLista.Columns(3).ReadOnly = True
                dgvLista.Columns(3).Width = 150

                dgvLista.Columns(4).Width = 100
                dgvLista.Columns(4).HeaderText = "Costo"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub nuevoDocumento()
        Try
            Dim _sentencia As String = String.Empty
            Dim _sentenciadet As String = String.Empty
            _sentencia &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS(COMPAÑIA,FECHA,VIGENCIA_DESDE,VIGENCIA_HASTA,PROVEEDOR,USUARIO_CREACION,USUARIO_MODIFICA,FECHA_USUARIO_MODIFICA,HABILITADA, TIEMPOS_ENTREGA)" & Environment.NewLine
            _sentencia &= " VALUES (" & Compañia & ",GETDATE(),'" & Me.dtpVigenciaDesde.Value.ToShortDateString().Replace("p.m.", "").Replace("a.m.", "") & "','" & Me.dtpVigenciaHasta.Value.ToShortDateString().Replace("p.m.", "").Replace("a.m.", "") & "', " & Me.cmbProveedor.SelectedValue & ",'" & Usuario & "', '" & Usuario & "', GETDATE(), " & IIf(Me.chkHabilitado.Checked, "1", "0") & "," & Me.nudTiemposEntrega.Value & ")" & Environment.NewLine
            _sentencia &= " SELECT SCOPE_IDENTITY() " & Environment.NewLine

            For Each row As DataGridViewRow In Me.dgvLista.Rows
                If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                    If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) And (row.Cells("COSTO").Value > 0) Then
                        _sentenciadet &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE(LISTA,PRODUCTO,DESCRIPCION,UNIDAD_MEDIDA,COSTO_UNITARIO) VALUES(<id>," & row.Cells("PRODUCTO").Value & ",'" & row.Cells("DESCRIPCION").Value & "'," & row.Cells("UNIDAD_COMPRA").Value & "," & row.Cells("COSTO").Value & ")" & Environment.NewLine
                    End If
                End If
            Next

            Me.txtLista.Text = _obj_compras.agregarDatos(_sentencia, _sentenciadet, "Select @@Identity")

            Me.habilitarControles(False)

            MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try

    End Sub

    Private Sub actualizarDocumento()
        Try
            Dim _filas_count As Integer = Me.dgvLista.Rows.Count
            Dim _filas_num As Integer = 1

            Dim _sentencia As String = String.Empty
            _sentencia = "UPDATE dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS SET VIGENCIA_DESDE = '" & Format(Me.dtpVigenciaDesde.Value, "dd/MM/yyyy") & "' ,VIGENCIA_HASTA = '" & Format(Me.dtpVigenciaHasta.Value, "dd/MM/yyyy") & "' ,PROVEEDOR = " & Me.cmbProveedor.SelectedValue & "  ,USUARIO_MODIFICA = '" & Usuario & "' ,FECHA_USUARIO_MODIFICA=GETDATE(), HABILITADA=" & IIf(Me.chkHabilitado.Checked, "1", "0") & ",TIEMPOS_ENTREGA=" & Me.nudTiemposEntrega.Value & " WHERE LISTA=" & Me.txtLista.Text & Environment.NewLine
            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE WHERE LISTA=" & Me.txtLista.Text & Environment.NewLine

            For Each row As DataGridViewRow In Me.dgvLista.Rows
                If (row.Cells("DESCRIPCION").Value IsNot Nothing) Then
                    If (Not row.Cells("DESCRIPCION").Value.Equals(DBNull.Value)) And (row.Cells("COSTO").Value > 0) Then
                        _sentencia &= "INSERT INTO dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE(LISTA,PRODUCTO,DESCRIPCION,UNIDAD_MEDIDA,COSTO_UNITARIO) VALUES(" & Me.txtLista.Text & "," & row.Cells("PRODUCTO").Value & ",'" & row.Cells("DESCRIPCION").Value & "'," & row.Cells("UNIDAD_COMPRA").Value & "," & row.Cells("COSTO").Value & ")" & Environment.NewLine
                    End If
                End If
            Next

            Dim _exito As Integer = _obj_compras.actualizarDatos(_sentencia)

            If _exito > 0 Then
                MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub borrarDocumento()
        Try
            Dim _sentencia As String = String.Empty
            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS_DETALLE WHERE LISTA=" & Me.txtLista.Text & Environment.NewLine
            _sentencia &= " DELETE FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS WHERE LISTA=" & Me.txtLista.Text

            Dim _exito As Integer = _obj_compras.actualizarDatos(_sentencia)

            If _exito > 0 Then
                MsgBox("Operación Exitosa...", MsgBoxStyle.Information, "Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
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

        Me.dgvLista.ReadOnly = Not (_enabled)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
            Busqueda.Compañia_Value = Compañia
            Busqueda.Bodega_Value = 1
            Busqueda.BuscaTodos = True
            Busqueda.ShowDialog()
            If Producto <> "" Then
                Me.dgvLista(0, e.RowIndex).Value = Producto
                Me.dgvLista(0, e.RowIndex).Selected = True
                Producto = String.Empty
            End If
        End If
    End Sub

    Private Sub brnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnGuardar.Click
        Dim _continuar As Boolean = True
        setTitulo()

        If Me.cmbProveedor.SelectedValue = 0 Then
            _continuar = False
            Me.ErrorProvider1.SetError(Me.cmbProveedor, "Seleccione un Proveedor")
        End If

        If Me.dtpVigenciaHasta.Value <= Me.dtpVigenciaDesde.Value Then
            _continuar = False
            Me.ErrorProvider1.SetError(Me.dtpVigenciaHasta, "Debe ser Mayor a Fecha Desde")
        End If

        If Me.dgvLista.Rows.Count <= 0 Then
            _continuar = False
            MsgBox("No ha agregado un detalle de Articulos", MsgBoxStyle.Critical, "Sistema")
        End If

        If _continuar Then
            Select Case Me.accion_
                Case "insert"
                    Me.nuevoDocumento()
                Case "update"
                    Me.actualizarDocumento()
                Case "delete"
                    If MsgBox("Desea Eliminar el Siguiente Registro?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                        Me.borrarDocumento()
                    End If
            End Select
        End If
    End Sub

    Private Sub dgvLista_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellEndEdit
        If e.ColumnIndex = 0 And dgvLista(0, e.RowIndex).Value.ToString().Length > 0 Then
            Me._producto = Me._obj_compras.obtenerDatos("SELECT P.PRODUCTO,P.DESCRIPCION_PRODUCTO, P.UNIDAD_MEDIDA, P.UNIDAD_COMPRA FROM dbo.INVENTARIOS_CATALOGO_PRODUCTOS P WHERE P.PRODUCTO = " & dgvLista(0, e.RowIndex).Value.ToString())
            If Me._producto.Rows.Count > 0 Then
                For Each _row As DataRow In _producto.Rows
                    Me.dgvLista(1, e.RowIndex).Value = _row.Item("DESCRIPCION_PRODUCTO")
                    Me.dgvLista(3, e.RowIndex).Value = _row.Item("UNIDAD_COMPRA")
                    Me.dgvLista(4, e.RowIndex).Value = 0.0
                Next
            End If
        End If
    End Sub

    Private Sub dgvLista_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvLista.CellFormatting
        If e.ColumnIndex = Me.dgvLista.Columns(2).Index Then
            With Me.dgvLista.Rows(e.RowIndex).Cells(e.ColumnIndex)
                .ToolTipText = "Buscar Productos"
            End With
        End If
    End Sub

    Private Sub calcularPeriodo()
        Dim dt1 As DateTime = Convert.ToDateTime(dtpVigenciaDesde.Text)
        Dim dt2 As DateTime = Convert.ToDateTime(dtpVigenciaHasta.Text)
        Dim ts As TimeSpan = dt2.Subtract(dt1)
        Me.txtPeriodo.Text = Convert.ToInt32(ts.Days)
    End Sub

    Private Sub dtpVigenciaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVigenciaHasta.ValueChanged
        calcularPeriodo()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MsgBox("Imprimir Listado de Precios?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
            Rpts.CargaListaProveedor(Me.txtLista.Text.Trim())
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub Contabilidad_Orden_Lista_Precios_Proveedor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class