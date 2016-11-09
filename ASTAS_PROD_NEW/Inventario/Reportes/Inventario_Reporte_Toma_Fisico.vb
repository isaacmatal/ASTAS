Imports System.Data.SqlClient
Public Class Inventario_Reporte_Toma_Fisico
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim dtareader As SqlDataReader
    Dim Table As DataTable
    Private Sub Inventario_Reporte_Toma_Fisico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        CargarGrupos()
        CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
        Iniciando = False
    End Sub
    Public Sub CargarGrupos()
        c_data1.CargarCombo(cmbGRUPO, "Execute sp_INVENTARIOS_CATALOGO_GRUPOS @COMPAÑIA=" & Compañia & ", @BANDERA=4", "Grupo", "Descripción_Grupo")
    End Sub
    Private Sub CargaSubGrupo(ByVal Compañia, ByVal Grupo, ByVal Bandera)
        c_data1.CargarCombo(cmbSUBGRUPO, "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS " & Compañia & ", " & cmbGRUPO.SelectedValue.ToString() & ", " & Bandera, "Sub Grupo", "Descripción")
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            If Chk_sin_grupos_subgrupos.Checked = True Then
                Dim rpt As New frmReportes_Ver(Compañia, Me.cmbBODEGA.SelectedValue, Me.fecha_hasta.Value, 11, 0, 0, 0, Me.ChkExist_Cero.Checked, Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue)
                rpt.ShowDialog()
            Else
                Dim rpt As New frmReportes_Ver(Compañia, Me.cmbBODEGA.SelectedValue, Me.fecha_hasta.Value, 52, 0, 0, 0, Me.ChkExist_Cero.Checked, Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue)
                rpt.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("AVISO...Ocurrio un problema a la hora de general el documento", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Chk_sin_grupos_subgrupos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_sin_grupos_subgrupos.CheckedChanged
        If Chk_sin_grupos_subgrupos.Checked = True Then
            Me.cmbSUBGRUPO.Enabled = False
            Me.cmbGRUPO.Enabled = False
        Else
            Me.cmbSUBGRUPO.Enabled = True
            Me.cmbGRUPO.Enabled = True
        End If
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Try
            If txtProducto.Text = "" Then

            Else
                'BUSCA SI ESE CODIGO EXISTE EN LA BODEGA
                Me.txtDescripcion.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto.Text & ", @BANDERA=4", 1)

                txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & cmbBODEGA.SelectedValue & "," & txtProducto.Text & ",'" & Date.Now.Date.ToString("dd/MM/yyyy") & "')", 0)

                Me.txtPrecio.Text = c_data1.obtenerEscalar("SELECT DBO.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & txtProducto.Text & ",'" & Date.Now.Date.ToString("dd/MM/yyyy") & "')") 'Table.Rows(0).Item("PRECIO_UNITARIO").ToString
            End If

        End If

    End Sub

    Private Sub Inventario_Reporte_Toma_Fisico_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim productos As New Inventario_BusquedaProductosBodega("", 4)
        productos.Bodega_Value = Me.cmbBODEGA.SelectedValue
        productos.cmbBODEGA.Enabled = False
        Numero_Factura = 0
        Numero = ""
        Producto = ""
        Descripcion_Producto = ""
        productos.ShowDialog()
        Me.txt_Existencias.Text = ""
        If Producto <> Nothing Then
            Try
                Me.LimpiaCamposDetalleFactura()
                Me.txtProducto.Text = Producto
                Check = 0
                Numero_Factura = 0
                Numero = ""
                Producto = ""
                Descripcion_Producto = ""
                obtieneDatosProducto(Me.txtProducto.Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LimpiaCamposDetalleFactura()
    End Sub
    Private Sub obtieneDatosProducto(ByVal codProducto As String)
        Dim sqlCmdProd As New SqlCommand
        If codProducto = Nothing Or codProducto.Length = 0 Then
            Return
        End If
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        SQL &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & codProducto
        sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = sql
        Table = c_data1.obtenerDatos(sqlCmdProd)
        If Table.Rows.Count = 1 Then
            Me.txtDescripcion.Text = Table.Rows(0).Item("DESCRIPCION_PRODUCTO")
            ''TC

            Me.txtPrecio.Text = c_data1.obtenerEscalar("SELECT DBO.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ",'" & Date.Now.Date.ToString("dd/MM/yyyy") & "')") 'Table.Rows(0).Item("PRECIO_UNITARIO").ToString

            txt_Existencias.Text = Math.Round(c_data1.obtenerEscalar("select dbo.calcular_existencia_actual (" & Compañia & "," & Me.cmbBODEGA.SelectedValue & "," & codProducto & ", '" & Date.Now.Date.ToString("dd/MM/yyyy") & "')"), 2)
        Else
            If Table.Rows.Count > 1 Then
                MsgBox("Existen mas de dos items para la bodega " & Me.cmbBODEGA.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Else
                '  MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            End If
        End If
    End Sub
    Private Sub LimpiaCamposDetalleFactura()
        Me.txtDescripcion.Clear()
        Me.txtPrecio.Clear()
        Me.txtProducto.Clear()
        Me.txt_Existencias.Clear()
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
        End If
    End Sub
End Class