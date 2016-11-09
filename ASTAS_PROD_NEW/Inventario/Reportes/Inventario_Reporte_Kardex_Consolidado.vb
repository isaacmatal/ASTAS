Imports System.Data.SqlClient
Public Class Inventario_Reporte_Kardex_Consolidado
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Rpts As New frmReportes_Ver
    Dim dtareader As SqlDataReader
    Private Sub Inventario_Reporte_Kardex_Consolidado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
    End Sub
    Private Sub txtProducto1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.txtProducto1.Text.Trim IsNot Nothing Then
                Try
                    Me.txtDESCRIPCION1.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto1.Text & ", @BANDERA=1", 1)
                    Me.txtMedida1.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto1.Text & ", @BANDERA=1", 2)
                    Me.txtProducto2.Focus()
                Catch ex As Exception
                    MsgBox("El código debe ser numérico", MsgBoxStyle.Information)
                End Try
            End If
        End If
    End Sub

    Private Sub txtProducto2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.txtProducto2.Text.Trim IsNot Nothing Then
                Try
                    Me.txtDESCRIPCION2.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto2.Text & ", @BANDERA=1", 1)
                    Me.txtMedida2.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto2.Text & ", @BANDERA=1", 2)
                Catch ex As Exception
                    MsgBox("El código debe ser numérico", MsgBoxStyle.Information)
                End Try
            End If
        End If
    End Sub

    Private Sub btnBuscarProducto1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto1.Click
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia

        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue

        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()

        Me.txtProducto1.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
        Me.txtMedida1.Text = unidades
    End Sub

    Private Sub btnBuscarProducto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto2.Click
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia

        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue

        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.txtProducto2.Text = CodigoProducto
        Me.txtDESCRIPCION2.Text = Descripcion_Producto
        Me.txtMedida2.Text = unidades
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If MsgBox("¿Está seguro(a) que desea emitir el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Rpts.CargaInventario_Kardex_Consolidado(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.txtProducto1.Text), Val(Me.txtProducto2.Text), Me.txtFecha.Value)
            If Hay_Datos Then
                Rpts.ShowDialog()
            End If
        End If
    End Sub
End Class