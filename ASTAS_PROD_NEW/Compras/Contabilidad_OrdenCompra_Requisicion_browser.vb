Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Requisicion_browser
    Dim _obj_compras As New Compras()    
    Dim _consulta_general As String = String.Empty
    Dim _status As String = String.Empty
    Dim _datos_user As New DataTable()
    Dim _codigo As Integer = 0
    Public _puede_procesar As Boolean = False
    Public _puede_autorizar As Boolean = False

    Private Sub Contabilidad_OrdenCompra_Requisicion_browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _datos_user = Me._obj_compras.obtenerDatos("SELECT PROCESAR_DOCUMENTO, AUTORIZAR_DOCUMENTO FROM [dbo].[CATALOGO_USUARIOS] WHERE [USUARIO]='" & Usuario & "' AND COMPAÑIA=" & Compañia)

        If _datos_user.Rows.Count > 0 Then
            For Each row As DataRow In _datos_user.Rows
                Me._puede_procesar = row.Item("PROCESAR_DOCUMENTO")
                Me._puede_autorizar = row.Item("AUTORIZAR_DOCUMENTO")
            Next row
        End If

        Me.cargarGrid()

        Me._obj_compras.setearCombo(Me.cmbBodegas, "Execute sp_INVENTARIOS_CATALOGO_BODEGAS @BANDERA = 13,@COMPAÑIA = " & Compañia & ",@USUARIO='" & Usuario & "'", "Descripción", "Bodega")
        Me._obj_compras.setearCombo(Me.cmbEstatus, "SELECT 0 As ESTATUS, 'Todos los Estatus...' As DESCRIPCION Union SELECT ESTATUS,DESCRIPCION FROM dbo.CONTABILIDAD_ORDEN_ESTATUS", "DESCRIPCION", "ESTATUS")

        Me.crearGrid()
    End Sub

    Private Sub crearGrid()
        If Me._puede_procesar Then
            gvRequisiciones.Columns(0).HeaderText = "Estatus"
            gvRequisiciones.Columns(0).Width = 90
            gvRequisiciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(1).HeaderText = "Requisición No."
            gvRequisiciones.Columns(1).Width = 70
            gvRequisiciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(2).HeaderText = "Fecha Creación"
            gvRequisiciones.Columns(2).Width = 80
            gvRequisiciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(3).HeaderText = "Fecha Solicitada"
            gvRequisiciones.Columns(3).Width = 80
            gvRequisiciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(4).HeaderText = "Bodega"
            gvRequisiciones.Columns(4).Width = 160

            gvRequisiciones.Columns(5).HeaderText = "Proveedor"
            gvRequisiciones.Columns(5).Width = 190

            gvRequisiciones.Columns(6).HeaderText = "Autorización"
            gvRequisiciones.Columns(6).Width = 70
            gvRequisiciones.Columns(7).HeaderText = "Usuario Creación"
            gvRequisiciones.Columns(7).Width = 80
            gvRequisiciones.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(8).HeaderText = "Usuario Modificó"
            gvRequisiciones.Columns(8).Width = 80
            gvRequisiciones.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(9).HeaderText = "Fecha Modificado"
            gvRequisiciones.Columns(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            gvRequisiciones.Columns(9).Width = 80
            gvRequisiciones.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(10).HeaderText = "Orden Compra"
            gvRequisiciones.Columns(10).Width = 150
        Else
            gvRequisiciones.Columns(0).HeaderText = "Estatus"
            gvRequisiciones.Columns(0).Width = 90
            gvRequisiciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(1).HeaderText = "Requisición No."
            gvRequisiciones.Columns(1).Width = 70
            gvRequisiciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(2).HeaderText = "Fecha Creación"
            gvRequisiciones.Columns(2).Width = 80
            gvRequisiciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(3).HeaderText = "Fecha Solicitada"
            gvRequisiciones.Columns(3).Width = 80
            gvRequisiciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(4).HeaderText = "Bodega"
            gvRequisiciones.Columns(4).Width = 175
            gvRequisiciones.Columns(5).HeaderText = "Autorización"
            gvRequisiciones.Columns(5).Width = 70
            gvRequisiciones.Columns(6).HeaderText = "Usuario Creación"
            gvRequisiciones.Columns(6).Width = 80
            gvRequisiciones.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(7).HeaderText = "Usuario Modificó"
            gvRequisiciones.Columns(7).Width = 80
            gvRequisiciones.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(8).HeaderText = "Fecha Modificado"
            gvRequisiciones.Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"
            gvRequisiciones.Columns(8).Width = 80
            gvRequisiciones.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            gvRequisiciones.Columns(9).HeaderText = "Orden Compra"
            gvRequisiciones.Columns(9).Width = 150
        End If
    End Sub

    Private Sub cargarGrid()
        Dim _consulta_condicion = String.Empty

        If Me._puede_procesar Then
            _consulta_general = "SELECT (SELECT DESCRIPCION FROM dbo.CONTABILIDAD_ORDEN_ESTATUS WHERE ESTATUS=R.ESTATUS) As ESTATUS"
            _consulta_general &= ",REQUISICION,FECHA_CREACION,FECHA_SOLICITA"
            _consulta_general &= ",(SELECT DESCRIPCION_BODEGA FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE BODEGA=R.BODEGA AND COMPAÑIA = " & Compañia & ") AS DESCRIPCION_BODEGA"

            _consulta_general &= ",(SELECT TOP 1 (SELECT NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR = RD.PROVEEDOR AND COMPAÑIA = " & Compañia & ") FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION R1 INNER JOIN dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION_DETALLE RD ON R1.REQUISICION = RD.REQUISICION WHERE R1.REQUISICION = R.REQUISICION AND COMPAÑIA = " & Compañia & ") AS PROVEEDORNOMBRE"

            _consulta_general &= ",AUTORIZACION, USUARIO_CREA_SOLICITA, USUARIO_REVISA, FECHA_USUARIO_REVISA, ORDEN_GENERADA "
            _consulta_general &= "FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION R "
            _consulta_general &= " WHERE AFECTAR_INVENTARIO = 1 AND COMPAÑIA = " & Compañia
        Else
            _consulta_general = "SELECT (SELECT DESCRIPCION FROM dbo.CONTABILIDAD_ORDEN_ESTATUS WHERE ESTATUS=R.ESTATUS) As ESTATUS"
            _consulta_general &= ",REQUISICION,FECHA_CREACION,FECHA_SOLICITA"
            _consulta_general &= ",(SELECT DESCRIPCION_BODEGA FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE BODEGA=R.BODEGA AND COMPAÑIA = " & Compañia & ") AS DESCRIPCION_BODEGA"
            _consulta_general &= ",AUTORIZACION, USUARIO_CREA_SOLICITA, USUARIO_REVISA, FECHA_USUARIO_REVISA, ORDEN_GENERADA "
            _consulta_general &= "FROM dbo.CONTABILIDAD_ORDEN_COMPRA_REQUISICION R "
            _consulta_general &= " WHERE AFECTAR_INVENTARIO = 1 AND COMPAÑIA = " & Compañia
        End If

        _consulta_condicion &= " AND R.BODEGA IN (SELECT ICB.BODEGA FROM VISTA_INVENTARIOS_CATALOGOS_BODEGAS ICB INNER JOIN SEGURIDAD_CATALOGO_BODEGAS_USUARIOS SCBU ON ICB.COMPAÑIA= SCBU.COMPAÑIA AND ICB.BODEGA  = SCBU.BODEGA WHERE ICB.COMPAÑIA=" & Compañia & " AND ICB.ACTIVA = 1 AND SCBU.COMPAÑIA =" & Compañia & " AND SCBU.USUARIO = '" & Usuario & "' AND SCBU.COMPRAS  = 1)"
        '_consulta_condicion &= " AND CONVERT(DATE, R.FECHA_CREACION, 103) BETWEEN CONVERT(DATE, '" & Format(Me.dtpCreadasDesde.Value, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dtpCreadasHasta.Value, "dd/MM/yyyy") & "', 103)"
        _consulta_condicion &= " AND R.ESTATUS=1 "
        Me._obj_compras.setearGridView(Me.gvRequisiciones, _consulta_general & _consulta_condicion)
        'Me.btnFilter.PerformClick()
    End Sub

    Private Sub Contabilidad_OrdenCompra_Requisicion_browser_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim _consulta_condicion = String.Empty
        If Me.rad1.Checked Then
            _consulta_condicion = " AND CONVERT(DATE, R.FECHA_CREACION, 103)BETWEEN CONVERT(DATE, '" & Format(Me.dtpCreadasDesde.Value, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dtpCreadasHasta.Value, "dd/MM/yyyy") & "', 103)"
        Else
            _consulta_condicion = " AND CONVERT(DATE, R.FECHA_SOLICITA, 103)BETWEEN CONVERT(DATE, '" & Format(Me.dtpSolicitadasDesde.Value, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dtpSolicitadasHasta.Value, "dd/MM/yyyy") & "', 103)"
        End If

        If Me.cmbBodegas.SelectedValue > 0 Then
            _consulta_condicion &= " AND R.BODEGA=" & Me.cmbBodegas.SelectedValue
        Else
            _consulta_condicion &= " AND R.BODEGA IN (SELECT ICB.BODEGA FROM VISTA_INVENTARIOS_CATALOGOS_BODEGAS ICB INNER JOIN SEGURIDAD_CATALOGO_BODEGAS_USUARIOS SCBU ON ICB.COMPAÑIA= SCBU.COMPAÑIA AND ICB.BODEGA  = SCBU.BODEGA WHERE ICB.COMPAÑIA=" & Compañia & " AND ICB.ACTIVA = 1 AND SCBU.COMPAÑIA =" & Compañia & " AND SCBU.USUARIO = '" & Usuario & "' AND SCBU.COMPRAS  = 1)"
        End If

        If Me.cmbEstatus.SelectedValue > 0 Then
            _consulta_condicion &= " AND R.ESTATUS=" & Me.cmbEstatus.SelectedValue
        End If

        If Me.txtOrdenCompra.Text.Length > 0 Then
            _consulta_condicion &= " AND R.ORDEN_GENERADA Like '%" & Me.txtOrdenCompra.Text & "%'"
        End If

        Me._obj_compras.setearGridView(Me.gvRequisiciones, _consulta_general & _consulta_condicion)

        Me.paintByStatus()
    End Sub

    Private Sub paintByStatus()
        Dim _style_filtro As New DataGridViewCellStyle()
        _style_filtro.BackColor = Color.Azure
        _style_filtro.ForeColor = Color.BlueViolet

        Dim _style As New DataGridViewCellStyle()
        _style.BackColor = Color.White
        _style.ForeColor = Color.Black

        Dim _style_proc As New DataGridViewCellStyle()
        _style_proc.BackColor = Color.Green
        _style_proc.ForeColor = Color.White

        Dim _style_pend As New DataGridViewCellStyle()
        _style_pend.BackColor = Color.Yellow
        _style_pend.ForeColor = Color.Black

        Dim _style_aprob As New DataGridViewCellStyle()
        _style_aprob.BackColor = Color.SkyBlue
        _style_aprob.ForeColor = Color.Black

        Dim _style_rechaz As New DataGridViewCellStyle()
        _style_rechaz.BackColor = Color.Red
        _style_rechaz.ForeColor = Color.White

        For r As Integer = 0 To Me.gvRequisiciones.Rows.Count - 1
            If Me.rad1.Checked Then
                gvRequisiciones.Item(2, r).Style = _style_filtro
                gvRequisiciones.Item(3, r).Style = _style
            Else
                gvRequisiciones.Item(2, r).Style = _style
                gvRequisiciones.Item(3, r).Style = _style_filtro
            End If

            If Me.cmbBodegas.SelectedValue > 0 Then
                gvRequisiciones.Item(4, r).Style = _style_filtro
            Else
                gvRequisiciones.Item(4, r).Style = _style
            End If

            If gvRequisiciones.Rows(r).Cells(0).Value = "PROCESADO" Then
                gvRequisiciones.Item(0, r).Style = _style_proc
            End If

            If gvRequisiciones.Rows(r).Cells(0).Value = "PENDIENTE" Then
                gvRequisiciones.Item(0, r).Style = _style_pend
            End If

            If gvRequisiciones.Rows(r).Cells(0).Value = "AUTORIZADO" Then
                gvRequisiciones.Item(0, r).Style = _style_aprob
            End If

            If gvRequisiciones.Rows(r).Cells(0).Value = "RECHAZADO" Then
                gvRequisiciones.Item(0, r).Style = _style_rechaz
            End If
        Next r
    End Sub

    Private Sub Contabilidad_OrdenCompra_Requisicion_browser_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.paintByStatus()
    End Sub

    Private Sub rad1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad1.Click
        Me.paintByStatus()
    End Sub

    Private Sub rad2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad2.Click
        Me.paintByStatus()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub gvRequisiciones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvRequisiciones.CellEnter
        If e.RowIndex > -1 Then
            Me._codigo = gvRequisiciones.Rows(e.RowIndex).Cells(1).Value
            Me._status = gvRequisiciones.Rows(e.RowIndex).Cells(0).Value
        Else
            Me._codigo = 0
            Me._status = String.Empty
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim _requisicion As New Contabilidad_OrdenCompra_Requisicion()
        Me.Visible = False
        _requisicion.puede_procesar_ = Me._puede_procesar
        _requisicion.puede_autorizar_ = Me._puede_autorizar
        _requisicion.codigo_ = 0
        _requisicion.accion_ = "insert"
        _requisicion.afectan_inventario = True
        _requisicion.ShowDialog()
        Me.Visible = True
        Me.cargarGrid()
        Me.paintByStatus()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click        
        If Me._codigo > 0 Then
            Dim _requisicion As New Contabilidad_OrdenCompra_Requisicion()
            Me.Visible = False
            _requisicion.puede_procesar_ = Me._puede_procesar
            _requisicion.puede_autorizar_ = Me._puede_autorizar
            _requisicion.codigo_ = Me._codigo
            _requisicion.accion_ = "update"
            _requisicion.afectan_inventario = True
            _requisicion.ShowDialog()
            Me.Visible = True
            Me.cargarGrid()
            Me.paintByStatus()
        Else
            MsgBox("Seleccione un Registro.", MsgBoxStyle.Information, "Modificar")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me._codigo > 0 Then
            If Me._status.Equals("PENDIENTE") Then
                Dim _requisicion As New Contabilidad_OrdenCompra_Requisicion()
                Me.Visible = False
                _requisicion.puede_procesar_ = Me._puede_procesar
                _requisicion.puede_autorizar_ = Me._puede_autorizar
                _requisicion.codigo_ = Me._codigo
                _requisicion.accion_ = "delete"
                _requisicion.afectan_inventario = True
                _requisicion.ShowDialog()
                Me.Visible = True
                Me.cargarGrid()
            Else
                MsgBox("Solo se puede Eliminar una Requisición Pendiente.", MsgBoxStyle.Critical, "Eliminar")
            End If
            Me.paintByStatus()
        Else
            MsgBox("Seleccione un Registro.", MsgBoxStyle.Information, "Eliminar")
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Me._codigo > 0 Then
            Dim _requisicion As New Contabilidad_OrdenCompra_Requisicion()
            Me.Visible = False
            _requisicion.puede_procesar_ = Me._puede_procesar
            _requisicion.puede_autorizar_ = Me._puede_autorizar
            _requisicion.codigo_ = Me._codigo
            _requisicion.accion_ = "select"
            _requisicion.afectan_inventario = True
            _requisicion.ShowDialog()
            Me.Visible = True
            Me.cargarGrid()
            Me.paintByStatus()
        Else
            MsgBox("Seleccione un Registro.", MsgBoxStyle.Information, "Consultar")
        End If
    End Sub

    Private Sub cmbBodegas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodegas.Click
        Me.paintByStatus()
    End Sub
End Class