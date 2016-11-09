Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Simulador_Recetas
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega

    Dim Sql As String, BAN As Boolean

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Reporte_Simulador_Recetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA, 10)
        Iniciando = False
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Val(Me.TxtCantidad.Text) > 0 Then
            If MsgBox("¿Está seguro que desea Procesar e Imprimir datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Rpts.GetReporteSimulador_Recetas(Compañia, Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Val(Me.TxtCantidad.Text), Val(Me.TxtPorcenta.Text))
                If Hay_Datos = True Then
                    Rpts.ShowDialog()
                End If
            End If
        Else
            MsgBox("¿No esta definido el valor a calcular.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "AVISO")
        End If
    End Sub
    Private Sub BtnBuscarCodigo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCodigo1.Click
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()

        Me.txtCODIGO_PRODUCTO.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
        Me.TxtCantidad.Text = 0

        Iniciando = False

    End Sub
    Private Sub txtCODIGO_PRODUCTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCODIGO_PRODUCTO.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.txtCODIGO_PRODUCTO.Text <> "" Then
                'BUSCA SI ESE CODIGO EXISTE EN LA BODEGA
                Me.txtDESCRIPCION1.Text = jasr_fill.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtCODIGO_PRODUCTO.Text & ", @BANDERA=1", 1)

                If txtDESCRIPCION1.Text = "" Then
                    MsgBox("Aviso...Codigo No existe en esta bodega", MsgBoxStyle.Information)
                Else
                    Me.TxtCantidad.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If TxtCantidad.Text.Equals(String.Empty) Then
                    e.Handled = True
                    TxtCantidad.Text = ""
                Else
                    e.Handled = TxtCantidad.Text.Contains(".")
                End If
            Else
                e.Handled = True
                TxtCantidad.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.TxtCantidad.Text <> "" Then
                If Val(Me.TxtCantidad.Text) <= 0 Then
                    MsgBox("Valor debe ser numérico y mayor que cero.", MsgBoxStyle.Information, "AVISO")
                Else
                    Me.TxtPorcenta.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        Me.txtCODIGO_PRODUCTO.Focus()
    End Sub

    Private Sub TxtPorcenta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorcenta.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If TxtPorcenta.Text.Equals(String.Empty) Then
                    e.Handled = True
                    TxtPorcenta.Text = ""
                Else
                    e.Handled = TxtPorcenta.Text.Contains(".")
                End If
            Else
                e.Handled = True
                TxtPorcenta.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.TxtPorcenta.Text <> "" Then
                If Val(Me.TxtPorcenta.Text) <= 0 Then
                    MsgBox("Valor debe ser numérico y mayor que cero.", MsgBoxStyle.Information, "AVISO")
                Else
                    Me.BtnBuscar.Focus()
                End If
            End If
        End If
    End Sub
End Class