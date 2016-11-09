Imports System.Data.SqlClient
Public Class Inventario_Regalias
    Dim c_data2 As New jarsClass
    Dim Sql As String
    Dim Iniciando, CargaDetalle As Boolean
    Dim Accion As String
    Public codigoProveedor As Integer
    Public codigoBodega As Integer
    Public tipoDocumento As Integer
    Dim Linea As Integer

    Private Sub Inventario_Regalias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Accion = "I"
        Linea = 0
        CargaUnidadMedida(1)
        CargaOC_Detalle(Me.txtOc.Text, 1)
        Iniciando = False
    End Sub
    Private Sub CargaUnidadMedida(ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = c_data2.obtenerDatos(New SqlCommand(Sql))
            Me.cmbUNIDAD_MEDIDA.DataSource = Table
            Me.cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            Me.cmbUNIDAD_MEDIDA.DisplayMember = "Descripción Unidad"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim productos As New Inventario_Productos
        'productos.ShowDialog()
    End Sub

    

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
        Busqueda.Compañia_Value = Compañia
        Busqueda.Bodega_Value = codigoBodega
        Busqueda.cmbBODEGA.Enabled = False
        Busqueda.BuscaTodos = True
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtPRODUCTO.Text = Producto
            BuscarProducto(codigoBodega, Me.txtPRODUCTO.Text)
            Producto = ""
        End If
        Me.txtCANTIDAD.Focus()
    End Sub
    Private Sub BuscarProducto(ByVal Bodega, ByVal Producto)
        Dim tblProd As DataTable
        Accion = "I"
        Linea = 0
        Try
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Producto
            Sql &= ", '' " 'Descripción del Producto
            Sql &= ", 0" 'Código de Grupo
            Sql &= ", 2" 'Bandera
            tblProd = c_data2.obtenerDatos(New SqlCommand(Sql))
            If tblProd.Rows.Count > 0 Then
                Me.txtPRODUCTO.Text = tblProd.Rows(0).Item("PRODUCTO")
                Me.txtDESCRIPCION_PRODUCTO.Text = tblProd.Rows(0).Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.SelectedValue = tblProd.Rows(0).Item("UNIDAD_MEDIDA")
                Me.txtLIBRAS.Enabled = tblProd.Rows(0).Item("UNIDAD_LIBRA")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        If ValidaCamposLinea() = True Then
            Mantenimiento_Detalle(Me.txtOc.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.txtCANTIDAD.Text, Val(Me.txtLIBRAS.Text), Me.txtCOSTO_UNITARIO.Text, "0", Accion)

            If Accion = "I" Then
                AutorizaOC(Me.txtOc.Text, "1", "0", "", "R")
            Else
                c_data2.Ejecutar_ConsultaSQL("DELETE CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & Me.txtOc.Text & " and PRODUCTO='" & Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value & "' AND COSTO_UNITARIO=0 AND LINEA=" & Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value)
                AutorizaOC(Me.txtOc.Text, "1", "0", "", "R")
            End If

            CargaOC_Detalle(Me.txtOc.Text, 1)
            LimpiaCamposProducto()
            Me.txtPRODUCTO.Focus()
        End If
    End Sub
    Private Function ValidaCamposLinea()
        If Me.txtOc.Text = "" Then
            MsgBox("¡Se debe seleccionar una orden de compra valida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtCodProv.Text = "" Then
            MsgBox("¡Debe seleccionar un Proveedor válido para la Orden de Compra! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtPRODUCTO.Text = "" Then
            MsgBox("¡Debe seleccionar un Producto! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar una Cantidad mayor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtLIBRAS.Enabled = True And Val(Trim(Me.txtLIBRAS.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar una Cantidad en Libras válida para el producto! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If

        Return True
    End Function
    Private Sub Mantenimiento_Detalle(ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Servicio, ByVal IUD)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Linea
            Sql &= ", " & Producto
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & UnidadMedida
            Sql &= ", " & Cantidad
            Sql &= ", " & Libras
            Sql &= ", " & CostoUnitario
            Sql &= ", " & Servicio
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            c_data2.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaOC_Detalle(ByVal OrdenCompra, ByVal Bandera)
        Dim Table As DataTable
        CargaDetalle = True
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @ORDEN_COMPRA = " & OrdenCompra
            Sql &= ", @BANDERA = " & Bandera
            Sql &= ", @TIPO_DOCUMENTO = " & tipoDocumento
            Table = c_data2.obtenerDatos(New SqlCommand(Sql))
            Me.dgvDetalleOC.Columns.Clear()
            Me.dgvDetalleOC.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid()
        Me.dgvDetalleOC.Columns(0).Width = 50 'Línea
        Me.dgvDetalleOC.Columns(1).Width = 80 'Cod Producto
        Me.dgvDetalleOC.Columns(2).Width = 175 'Descripción
        Me.dgvDetalleOC.Columns(3).Width = 50 'Cod UM
        Me.dgvDetalleOC.Columns(4).Width = 80 'Unidad Medida
        Me.dgvDetalleOC.Columns(5).Width = 70 'Cantidad
        Me.dgvDetalleOC.Columns(7).Width = 70 'Costo Unit
        Me.dgvDetalleOC.Columns(8).Width = 70 'Sub Total
        Me.dgvDetalleOC.Columns(9).Width = 70 'Con IVA
        Me.dgvDetalleOC.Columns(10).Width = 70 'Percepcion

        Me.dgvDetalleOC.Columns(0).Visible = False
        Me.dgvDetalleOC.Columns(3).Visible = False
        Me.dgvDetalleOC.Columns(6).Visible = False 'Libras
        Me.dgvDetalleOC.Columns(11).Visible = False 'SERVICIO
        Me.dgvDetalleOC.Columns(12).Visible = False 'INTANGIBLE
        Me.dgvDetalleOC.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.ForeColor = Color.Red

    End Sub
    Private Sub LimpiaCamposProducto()
        TextBox1.Text = ""
        Me.txtPRODUCTO.Text = ""
        txtCOSTO_UNITARIO.Text = "0"
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.txtCANTIDAD.Text = ""
        Me.txtLIBRAS.Text = ""
        Me.txtCOSTO_UNITARIO.Text = "0"
        Me.TextBox1.Text = "0"
        'habilita botones
        Me.txtPRODUCTO.Enabled = True
        Me.txtCANTIDAD.Enabled = True
        Me.btnBuscarProducto.Enabled = True
        Me.bntEliminar.Enabled = True
        Me.btnGuardarDetalle.Enabled = True
        Accion = "I"
        Linea = 0
    End Sub

    Private Sub bntEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntEliminar.Click
        If MsgBox("¿Está seguro de eliminar el producto: " & vbCrLf & Me.txtDESCRIPCION_PRODUCTO.Text & "?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            miMenu_Eliminar.PerformClick()
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMenu_Eliminar.Click
        If Val(Me.txtCOSTO_UNITARIO.Text) <> 0 Then
            MessageBox.Show("El elemento que se desea eliminar no es una regalia, el producto no sera eliminado", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Mantenimiento_Detalle(Me.txtOc.Text, Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value, Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value, "", 0, 0, 0, 0, 0, "D")
        c_data2.Ejecutar_ConsultaSQL("DELETE CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & Me.txtOc.Text & " and PRODUCTO='" & Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value & "' AND COSTO_UNITARIO=0 AND LINEA=" & Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value)
        LimpiaCamposProducto()
        CargaOC_Detalle(Me.txtOc.Text, 1)
    End Sub

    Private Sub dgvDetalleOC_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleOC.CellEnter
        If Not CargaDetalle Then
            Accion = "U"
            Linea = dgvDetalleOC.Rows(e.RowIndex).Cells(0).Value
            Me.txtPRODUCTO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(1).Value
            Me.txtDESCRIPCION_PRODUCTO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(2).Value
            Me.cmbUNIDAD_MEDIDA.SelectedValue = dgvDetalleOC.Rows(e.RowIndex).Cells(3).Value
            Me.txtCANTIDAD.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(5).Value
            Me.txtCOSTO_UNITARIO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(7).Value
            Me.TextBox1.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(8).Value
            Me.txtPRODUCTO.Enabled = False
            Me.txtCANTIDAD.Focus()

            If Val(Me.txtCOSTO_UNITARIO.Text) <> 0 Then
                Me.txtCANTIDAD.Enabled = False
                Me.txtPRODUCTO.Enabled = False
                Me.btnBuscarProducto.Enabled = False
                Me.bntEliminar.Enabled = False
                Me.btnGuardarDetalle.Enabled = False
            Else
                Me.txtCANTIDAD.Enabled = True
                Me.txtPRODUCTO.Enabled = True
                Me.btnBuscarProducto.Enabled = True
                Me.bntEliminar.Enabled = True
                Me.btnGuardarDetalle.Enabled = True
            End If
        Else
            CargaDetalle = False
            Accion = "I"
        End If
    End Sub

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        LimpiaCamposProducto()
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub AutorizaOC(ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal Comentario, ByVal IUD)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Autorizada
            Sql &= ", " & Anulada
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", 0"
            Sql &= ", '" & Comentario & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            c_data2.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class