Imports System.Data.SqlClient

Public Class Contabilidad_Orden_Lista_Precios_Proveedor_Browser
    Dim _obj_compras As New Compras()
    Dim _consulta_general As String = String.Empty
    Dim _codigo As Integer = 0

    Private Sub Contabilidad_Orden_Lista_Precios_Proveedor_Browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cargarGrid()
        Me._obj_compras.setearCombo(Me.cmbProveedor, "SELECT PROVEEDOR, NOMBRE_PROVEEDOR FROM dbo.CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA =" & Compañia, "NOMBRE_PROVEEDOR", "PROVEEDOR")

        dgvListaPrecios.Columns(0).HeaderText = "Lista"
        dgvListaPrecios.Columns(0).Width = 50
        dgvListaPrecios.Columns(1).HeaderText = "Proveedor"
        dgvListaPrecios.Columns(1).Width = 225
        dgvListaPrecios.Columns(2).HeaderText = "Creada"
        dgvListaPrecios.Columns(2).Width = 125
        dgvListaPrecios.Columns(3).HeaderText = "Vigente Desde"
        dgvListaPrecios.Columns(3).Width = 125
        dgvListaPrecios.Columns(4).HeaderText = "Vigente Hasta"
        dgvListaPrecios.Columns(4).Width = 125
        dgvListaPrecios.Columns(5).HeaderText = "Usuario Crea"
        dgvListaPrecios.Columns(5).Width = 75
        dgvListaPrecios.Columns(6).HeaderText = "Usuario Modifica"
        dgvListaPrecios.Columns(6).Width = 75
        dgvListaPrecios.Columns(7).HeaderText = "Fecha Modifica"
        dgvListaPrecios.Columns(7).Width = 125
        dgvListaPrecios.Columns(8).HeaderText = "Habilitada"
        dgvListaPrecios.Columns(8).Width = 60
        dgvListaPrecios.Columns(9).HeaderText = "Vigencia"
        dgvListaPrecios.Columns(9).Width = 60
    End Sub

    Private Sub cargarGrid()
        Dim _consulta_condicion = String.Empty
        _consulta_general = "SELECT LP.LISTA,(SELECT TOP 1 NOMBRE_PROVEEDOR FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR=LP.PROVEEDOR AND COMPAÑIA=LP.COMPAÑIA) AS Proveedor" & Environment.NewLine
        _consulta_general &= " ,LP.FECHA,LP.VIGENCIA_DESDE,LP.VIGENCIA_HASTA,LP.USUARIO_CREACION,LP.USUARIO_MODIFICA,LP.FECHA_USUARIO_MODIFICA,HABILITADA, DATEDIFF(DAY, LP.VIGENCIA_DESDE, LP.VIGENCIA_HASTA) As DIAS " & Environment.NewLine
        _consulta_general &= " FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS LP " & Environment.NewLine
        _consulta_condicion = " WHERE LP.COMPAÑIA=" & Compañia
        Me._obj_compras.setearGridView(Me.dgvListaPrecios, _consulta_general & _consulta_condicion)
    End Sub

    Private Sub cargarGrid2()
        Dim _consulta_condicion = String.Empty
        _consulta_general = "SELECT LP.LISTA,(SELECT NOMBRE_PROVEEDOR FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE PROVEEDOR=LP.PROVEEDOR) AS Proveedor" & Environment.NewLine
        _consulta_general &= " ,LP.FECHA,LP.VIGENCIA_DESDE,LP.VIGENCIA_HASTA,LP.USUARIO_CREACION,LP.USUARIO_MODIFICA,LP.FECHA_USUARIO_MODIFICA,HABILITADA, DATEDIFF(DAY, LP.VIGENCIA_DESDE, LP.VIGENCIA_HASTA) As DIAS " & Environment.NewLine
        _consulta_general &= " FROM dbo.CONTABILIDAD_ORDEN_LISTA_PRECIOS LP " & Environment.NewLine
        _consulta_condicion = " WHERE LP.COMPAÑIA=" & Compañia & " AND LP.PROVEEDOR = " & Me.cmbProveedor.SelectedValue
        Me._obj_compras.setearGridView(Me.dgvListaPrecios, _consulta_general & _consulta_condicion)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim _lista_precios As New Contabilidad_Orden_Lista_Precios_Proveedor()
        Me.Visible = False
        _lista_precios.codigo_ = 0
        _lista_precios.accion_ = "insert"
        _lista_precios.ShowDialog()
        Me.Visible = True
        Me.cargarGrid()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If Me._codigo > 0 Then
            Dim _lista_precios As New Contabilidad_Orden_Lista_Precios_Proveedor()
            Me.Visible = False
            _lista_precios.codigo_ = Me._codigo
            _lista_precios.accion_ = "update"
            _lista_precios.ShowDialog()
            Me.Visible = True
            Me.cargarGrid()
        Else
            MsgBox("Seleccione un Registro...", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim _lista_precios As New Contabilidad_Orden_Lista_Precios_Proveedor()
        Me.Visible = False
        _lista_precios.codigo_ = Me._codigo
        _lista_precios.accion_ = "delete"
        _lista_precios.ShowDialog()
        Me.Visible = True
        Me.cargarGrid()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Me._codigo > 0 Then
            Dim _lista_precios As New Contabilidad_Orden_Lista_Precios_Proveedor()
            Me.Visible = False
            _lista_precios.codigo_ = Me._codigo
            _lista_precios.accion_ = "select"
            _lista_precios.ShowDialog()
            Me.Visible = True
            Me.cargarGrid()
        Else
            MsgBox("Seleccione un Registro...", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dgvListaPrecios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaPrecios.CellClick
        Me._codigo = dgvListaPrecios.Rows(dgvListaPrecios.SelectedCells(0).RowIndex).Cells(0).Value
    End Sub

    Private Sub Contabilidad_Orden_Lista_Precios_Proveedor_Browser_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        cargarGrid2()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class