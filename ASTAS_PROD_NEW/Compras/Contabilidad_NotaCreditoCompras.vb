Imports System.Data.SqlClient

Public Class Contabilidad_NotaCreditoCompras

    Dim jClass As New jarsClass
    Dim Sql As String
    Dim Iniciando, CargaDetalle, _error_ As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim Accion As String = "I"
    Dim Linea As Integer = 0
    Dim Comando_ As New SqlCommand
    Dim Table As DataTable
    Dim IVA, Percepcion As Double
    Dim CantOrigen As Double
    Dim CentCosto As Integer
    Dim ValorDevolucion As Double = 0

    Private Sub Contabilidad_OrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        lblCompañia.Text = Descripcion_Compañia
        CargaBodegas(Compañia, 4)
        CargaUnidadMedida(Compañia, 1)
        Iniciando = False
        CargaPorcentajeImpuestos(1)
        CargaPorcentajeImpuestos(2)
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA  =  " & Bandera & ", "
            Sql &= "@COMPAÑIA =  " & Compañia & ", "
            Sql &= "@USUARIO  = '" & Usuario & "'"
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPorcentajeImpuestos(ByVal Constante As Integer)
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONSTANTES "
            Sql &= Compañia
            Sql &= ", " & Constante
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            If Constante = 1 Then
                IVA = Table.Rows(0).Item(0)
            ElseIf Constante = 2 Then
                Percepcion = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUnidadMedida(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbUNIDAD_MEDIDA.DataSource = Table
            Me.cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            Me.cmbUNIDAD_MEDIDA.DisplayMember = "Descripción Unidad"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle(ByVal Compañia As Integer, ByVal OrdenCompra As Integer, ByVal Documento As Integer)
        CargaDetalle = True
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1" & vbCrLf
            Sql &= "  @COMPAÑIA     = " & Compañia & vbCrLf
            Sql &= ", @ORDEN_COMPRA = " & OrdenCompra & vbCrLf
            Sql &= ", @BANDERA      = 5" & vbCrLf
            Sql &= ", @DOCUMENTO    = " & Documento & vbCrLf
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.dgvDetalleOC.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle_Total()
        Dim subtotal As Double
        Try
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                subtotal += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            Next
            Me.txtSubTotal.Text = subtotal.ToString("#,##0.00")
            Me.txtIVA.Text = (subtotal * (IVA / 100)).ToString("#,##0.00")
            Me.txtTotal.Text = (subtotal + (subtotal * (IVA / 100))).ToString("#,##0.00")
            If Me.chkPercep.Checked Then
                Me.txtPercepcion.Text = "0.00"
            Else
                If CDbl(jClass.obtenerEscalar("SELECT RETENCION FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & CInt(Val(Me.txtOC.Text)) & " AND DOCUMENTO = " & CInt(Val(Me.txtCCF.Text)))) > 0.0 Then
                    Me.txtPercepcion.Text = (subtotal * (Percepcion / 100)).ToString("#,##0.00")
                Else
                    Me.txtPercepcion.Text = "0.00"
                End If
            End If
            Me.txtTotalFact.Text = Format((subtotal + (subtotal * (IVA / 100))) + IIf(Me.chkPercep.Checked, 0.0, ((subtotal * Percepcion / 100))), "#,##0.00")
            If Me.chkAjustarInv.Checked And Me.dgvDetalleOC.Rows.Count > 0 Then
                If Me.dgvDetalleOC.Rows(0).Cells(1).Value = 0 Then
                    Me.chkAjustarInv.Checked = False
                End If
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Carga Detalle Total")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Try
            Me.dgvDetalleOC.Columns(0).Width = 50 'Línea
            Me.dgvDetalleOC.Columns(1).Width = 80 'Cod Producto
            Me.dgvDetalleOC.Columns(2).Width = 250 'Descripción
            'Me.dgvDetalleOC.Columns(3).Width = 50 'Cod UM
            Me.dgvDetalleOC.Columns(4).Width = 100 'Unidad Medida
            Me.dgvDetalleOC.Columns(5).Width = 70 'Cantidad
            'Me.dgvDetalleOC.Columns(6).Width = 50 'Libras
            Me.dgvDetalleOC.Columns(7).Width = 95 'Costo Unit
            Me.dgvDetalleOC.Columns(8).Width = 90 'Sub Total

            Me.dgvDetalleOC.Columns(0).Visible = False
            Me.dgvDetalleOC.Columns(3).Visible = False
            Me.dgvDetalleOC.Columns(6).Visible = False
            Me.dgvDetalleOC.Columns(9).Visible = False 'Servicio
            Me.dgvDetalleOC.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetalleOC.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetalleOC.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvDetalleOC.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.ForeColor = Color.Navy
            Me.dgvDetalleOC.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            jClass.msjError(ex, "LimpiarGrid")
        End Try
    End Sub

    Private Sub BuscarOC(ByVal Compañia As Integer, ByVal OrdenCompra As Integer, ByVal Bandera As Integer)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Bandera
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            If Table.Rows.Count > 0 Then
                Me.cmbBODEGA.SelectedValue = Table.Rows(0).Item("BODEGA")
                Me.TxtProveedor_Direccion.Text = Table.Rows(0).Item("DIRECCION")
                Me.txtOBSERVACIONES.Text = Table.Rows(0).Item("OBSERVACIONES")
                CentCosto = Table.Rows(0).Item("CENTRO_COSTO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProveedor(ByVal Compañia As Integer, ByVal Proveedor As Integer)
        Try
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = " & Compañia & " AND PROVEEDOR = " & Proveedor
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            If Table.Rows.Count > 0 Then
                Me.TxtProveedor_NombreLegal.Text = Table.Rows(0).Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = Table.Rows(0).Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = Table.Rows(0).Item("NRC")
                Me.TxtProveedor_Nit.Text = Table.Rows(0).Item("NIT")
                Me.TxtProveedor_Direccion.Text = Table.Rows(0).Item("DIRECCION")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProducto(ByVal Compañia As Integer, ByVal Bodega As Integer, ByVal Producto As Integer)
        Accion = "I"
        Linea = 0
        Try
            Sql = "SELECT LINEA, PRODUCTO, DESCRIPCION_PRODUCTO, UNIDAD_MEDIDA, CANTIDAD, COSTO_UNITARIO, SERVICIO"
            Sql &= "  FROM dbo.CONTABILIDAD_ORDEN_COMPRA_COMPROBANTE_RECIBIDO"
            Sql &= " WHERE COMPAÑIA = " & Compañia
            Sql &= "   AND ORDEN_COMPRA = " & Me.txtOC.Text
            Sql &= "   AND PRODUCTO = " & Producto
            Sql &= "   AND TIPO_DOCUMENTO = 2"
            Sql &= "   AND DOCUMENTO = " & Me.txtCCF.Text
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            LimpiaCamposProducto()
            If Table.Rows.Count > 0 Then
                Me.txtPRODUCTO.Text = Table.Rows(0).Item("PRODUCTO")
                Me.txtDESCRIPCION_PRODUCTO.Text = Table.Rows(0).Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(0).Item("UNIDAD_MEDIDA")
                CantOrigen = Table.Rows(0).Item("CANTIDAD")
                Me.txtCOSTO_UNITARIO.Text = Table.Rows(0).Item("COSTO_UNITARIO")
                Me.chkSERVICIO.Checked = Not Table.Rows(0).Item("SERVICIO")
            Else
                MsgBox("El producto código: " & Producto & vbCrLf & " no es parte del CCF# " & Me.txtCCF.Text, MsgBoxStyle.Information, "Búsqueda Producto")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal Compañia As Integer, ByVal OrdenCompra As Integer, ByVal Linea As Integer, _
                                      ByVal Producto As Integer, ByVal Descripcion As String, ByVal UnidadMedida As Integer, _
                                      ByVal Cantidad As Double, ByVal Libras As Double, ByVal CostoUnitario As Double, _
                                      ByVal Servicio As Integer, ByVal IUD As String)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO_IUD "
            Sql &= " @COMPAÑIA             = " & Compañia
            Sql &= ",@ORDEN_COMPRA         = " & OrdenCompra
            Sql &= ",@LINEA                = " & Linea
            Sql &= ",@PRODUCTO             = " & Producto
            Sql &= ",@DESCRIPCION_PRODUCTO = '" & Descripcion & "'"
            Sql &= ",@UNIDAD_MEDIDA        = " & UnidadMedida
            Sql &= ",@CANTIDAD             = " & Cantidad
            Sql &= ",@LIBRAS               = " & Me.txtNC.Text
            Sql &= ",@COSTO_UNITARIO       = " & CostoUnitario
            Sql &= ",@SERVICIO             = " & Servicio
            Sql &= ",@CANTIDAD_RECIBIDO    = " & Me.txtCCF.Text
            Sql &= ",@LIBRAS_RECIBIDO      = " & Me.TxtProveedor_Codigo.Text
            Sql &= ",@CANTIDAD_PENDIENTE   = " & Me.cmbBODEGA.SelectedValue
            Sql &= ",@LIBRAS_PENDIENTE     = 3" 'por ser nota de crédito segun catalogo de facturacion
            Sql &= ",@RECIBIDO             = 0"
            Sql &= ",@A_INVENTARIO         = " & IIf(Me.chkAjustarInv.Checked, "1", "0")
            Sql &= ",@USUARIO              = '" & Usuario & "' "
            Sql &= ",@IUD                  = 'N'"
            Comando_.CommandText = Sql
            jClass.ejecutarComandoSql(Comando_)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCamposOC()
        Me.dgvDetalleOC.DataSource = Nothing
        Me.txtOBSERVACIONES.Text = ""
        LimpiaCamposProveedor()
        Me.TxtProveedor_Codigo.Clear()
        LimpiaCamposProducto()
        Me.txtSubTotal.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotal.Text = "0.00"
        Me.txtPercepcion.Text = "0.00"
        Me.txtTotalFact.Text = "0.00"
        Me.txtCCF.ReadOnly = False
        Me.TxtProveedor_Codigo.ReadOnly = False
        Me.txtNC.Text = "0"
        Me.txtOC.Text = "0"
        Me.txtCCF.Clear()
    End Sub

    Private Sub LimpiaCamposProveedor()
        Me.TxtProveedor_NombreLegal.Text = ""
        Me.TxtProveedor_NombreComercial.Text = ""
        Me.TxtProveedor_RegistroFiscal.Text = ""
        Me.TxtProveedor_Nit.Text = ""
        Me.TxtProveedor_Direccion.Text = ""
    End Sub

    Private Sub LimpiaCamposProducto()
        Me.txtPRODUCTO.Text = ""
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.txtCANTIDAD.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.chkSERVICIO.Checked = False
        Me.txtPRODUCTO.Enabled = True
        Me.cmbUNIDAD_MEDIDA.SelectedValue = 0
        CantOrigen = 0
        Linea = 0
    End Sub

    Private Sub Deshabilita(ByVal Bandera As Boolean)
        Me.GrbProveedor.Enabled = Bandera
        Me.btnGuardarDetalle.Enabled = Bandera
        Me.BtnBuscar.Enabled = Bandera
        Me.btnProcesar.Enabled = Bandera
        Me.miMenu_Eliminar.Enabled = Bandera
        Me.bntEliminar.Enabled = Bandera
    End Sub

    Private Function ValidaCamposEncabezado() As Boolean
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un Nombre Legal válido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un NIT válido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Me.cmbBODEGA.Text = "" Then
            MsgBox("¡Debe seleccionar una Bodega válida!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        Return True
    End Function

    Private Function ValidaCamposLinea() As Boolean
        If Me.TxtProveedor_Codigo.Text = "" Then
            MsgBox("¡Debe seleccionar un Proveedor válido para la Orden de Compra!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Me.txtPRODUCTO.Text = "" And Me.chkAjustarInv.Checked Then
            MsgBox("¡Debe seleccionar un Producto válido!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 And Me.chkAjustarInv.Checked Then
            MsgBox("¡Debe seleccionar una Cantidad válida para el producto!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Val(Trim(Me.txtCANTIDAD.Text)) > CantOrigen And Me.chkAjustarInv.Checked Then
            MsgBox("¡La Cantidad no puede ser mayor a la" & vbCrLf & "que se guardó originalmente en el CCF# " & Me.txtCCF.Text, MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar un Precio Unitario válido!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        Return True
    End Function

    Private Function ValidaNC() As Boolean
        If Val(Me.txtNC.Text) = 0 Then
            MsgBox("¡Debe Ingresar un Número de Nota de Crédito válido!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor válido!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un Nombre Legal válido!" & vbCrLf & "Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un NIT válido!" & vbCrLf & "Verifique" & vbCrLf & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Me.txtTotalFact.Text = "0.00" Then
            MsgBox("¡La Nota de Crédito no puede ser procesada con monto $0.00!" & vbCrLf & "Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Me.chkAjustarInv.Checked And Me.dgvDetalleOC.Rows.Count > 0 Then
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                If Me.dgvDetalleOC.Rows(i).Cells(1).Value = 0 Then
                    MsgBox("Los códigos de productos no se pueden procesar" & "en el inventario, por favor verifique...", MsgBoxStyle.Information, "Error Aplicar a Inventario")
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiaCamposProveedor()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compañia_Value = Compañia
        Busqueda.CbxCompania.Enabled = False
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
            Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
            BuscarProveedor(Compañia, Me.TxtProveedor_Codigo.Text)
        Else
            BuscarProveedor(0, 0)
            Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Busqueda As New Inventario_BusquedaProductosBodega
        Busqueda.Compañia_Value = Compañia
        Busqueda.Bodega_Value = Me.cmbBODEGA.SelectedValue
        Busqueda.cmbBODEGA.Enabled = False
        Busqueda.BuscaTodos = True
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtPRODUCTO.Text = Producto
            BuscarProducto(Compañia, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            Producto = ""
        End If
    End Sub

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        LimpiaCamposProducto()
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub btnGuardarEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaCamposEncabezado() = True Then
            CargaOC_Detalle(Compañia, Me.txtOC.Text, Me.txtNC.Text)
            CargaOC_Detalle_Total()
        End If
    End Sub

    Private Sub btnLimpiarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarOC.Click
        LimpiaCamposOC()
        Me.lblMensaje.Visible = False
        Me.chkPercep.Checked = False
        Me.chkPercep.Enabled = True
        Deshabilita(True)
        Me.TxtProveedor_Codigo.Focus()
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        If ValidaCamposLinea() = True Then
            Mantenimiento_Detalle(Compañia, Me.txtOC.Text, Linea, Val(Me.txtPRODUCTO.Text), Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.txtCANTIDAD.Text, 0, Me.txtCOSTO_UNITARIO.Text, IIf(Me.chkSERVICIO.Checked = True, "0", "1"), Accion)
            CargaOC_Detalle(Compañia, Me.txtOC.Text, Me.txtNC.Text)
            CargaOC_Detalle_Total()
            LimpiaCamposProducto()
            Me.txtPRODUCTO.Focus()
        End If
    End Sub

    Private Sub txtCANTIDAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCANTIDAD.KeyPress
        Dim cadena As String = Me.txtCANTIDAD.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCOSTO_UNITARIO.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtCOSTO_UNITARIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOSTO_UNITARIO.KeyPress
        Dim cadena As String = Me.txtCOSTO_UNITARIO.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarDetalle.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim PDA As Integer = 0
        Dim Transac As Integer = 0
        Dim numMov As Integer
        _error_ = False
        If ValidaNC() Then
            If Me.chkAjustarInv.Checked And Me.dgvDetalleOC.Rows.Count > 0 Then
                If Me.dgvDetalleOC.Rows(0).Cells(1).Value = 0 Then
                    MsgBox("Los códigos de productos no se pueden procesar" & "en el inventario, por favor verifique...", MsgBoxStyle.Information, "Error Aplicar a Inventario")
                    Return
                End If
            End If
            If MsgBox("Al Procesar la Nota de Crédito ya no podrá realizar cambios." & vbCrLf & vbCrLf & "¿Desea Procesar la Nota de Crédito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                If AjustarPagoCCF(Compañia, Me.txtOC.Text, Me.txtSubTotal.Text, Me.txtIVA.Text, Me.txtTotal.Text, Me.txtPercepcion.Text, Me.txtTotalFact.Text) Then
                    If Me.chkAjustarInv.Checked Then
                        'procesar salidas de inventario
                        Sql = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO"
                        Sql &= " WHERE COMPAÑIA = " & Compañia
                        Sql &= " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
                        Sql &= " AND TIPO_MOVIMIENTO = 23"
                        numMov = jClass.obtenerEscalar(Sql)
                        For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                            If Not _error_ Then
                                ValorDevolucion += Me.dgvDetalleOC.Rows(i).Cells(8).Value
                                MovimientoInventario(Compañia, Me.cmbBODEGA.SelectedValue, Val(Me.TxtProveedor_Codigo.Text), Me.dgvDetalleOC.Rows(i).Cells(1).Value, Me.dgvDetalleOC.Rows(i).Cells(5).Value, Me.dgvDetalleOC.Rows(i).Cells(7).Value, Me.dgvDetalleOC.Rows(i).Cells(8).Value, Me.dpFECHA_NC.Value.Date, numMov)
                            End If
                        Next
                    End If
                Else
                    MsgBox("No se pudo ajustar el valor a pagar del CCF #" & Me.txtCCF.Text, MsgBoxStyle.Critical, "Error Ajustando valores")
                    _error_ = True
                End If
                If Not _error_ Then
                    If Not Mantenimiento_Cheques(Compañia, Me.txtOC.Text, Me.cmbBODEGA.SelectedValue, Me.txtSubTotal.Text, Me.txtIVA.Text, Me.txtTotal.Text, Me.txtPercepcion.Text, Me.txtTotalFact.Text, Me.txtNC.Text, Transac, PDA, Me.dpFECHA_NC.Value) Then
                        MsgBox("No se pudo guardar Nota de Crédito #" & Me.txtNC.Text, MsgBoxStyle.Critical, "Error Insertando NC")
                    End If
                    Deshabilita(False)
                End If
            Else
                MsgBox("Proceso Cancelado por Usuario", MsgBoxStyle.Information, "Cancelado")
            End If
        End If
    End Sub

    Private Sub txtPRODUCTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCANTIDAD.Focus()
        End If
    End Sub

    Private Sub txtPRODUCTO_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRODUCTO.LostFocus
        If Val(Me.txtPRODUCTO.Text) > 0 Then
            BuscarProducto(Compañia, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMenu_Eliminar.Click
        Mantenimiento_Detalle(Compañia, Me.txtOC.Text, Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value, Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value, "", 0, 0, 0, 0, 0, "D")
        LimpiaCamposProducto()
        CargaOC_Detalle(Compañia, Me.txtOC.Text, Me.txtNC.Text)
        CargaOC_Detalle_Total()
    End Sub

    Private Sub TxtProveedor_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.TextChanged
        If Me.TxtProveedor_Codigo.Text <> "" Then
            Dim Sql As String
            Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
            Sql = Sql & " Where ESTADO  = 1 AND COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text

            Dim Conexion_Track As New SqlConnection
            Dim Comando_Track As SqlCommand
            Dim DataAdapter As SqlDataAdapter
            Dim DS As New DataSet()

            Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
            Try
                Conexion_Track.Open()
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                DataAdapter = New SqlDataAdapter(Comando_Track)
                DataAdapter.Fill(DS)
                If DS.Tables(0).Rows.Count = 0 Then
                    MsgBox("¡No se encontró ningun proveedor!", MsgBoxStyle.Question, "Mensaje")
                    LimpiaCamposProveedor()
                Else
                    Me.TxtProveedor_Codigo.Text = DS.Tables(0).Rows(0).Item(0)
                    Me.TxtProveedor_NombreLegal.Text = DS.Tables(0).Rows(0).Item(1)
                    Me.TxtProveedor_NombreComercial.Text = DS.Tables(0).Rows(0).Item(2)
                    Me.TxtProveedor_RegistroFiscal.Text = DS.Tables(0).Rows(0).Item(3)
                    Me.TxtProveedor_Nit.Text = DS.Tables(0).Rows(0).Item(4)
                    Me.TxtProveedor_Direccion.Text = DS.Tables(0).Rows(0).Item(5)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            Conexion_Track.Close()
        Else
            LimpiaCamposProveedor()
        End If
    End Sub

    Private Sub dgvDetalleOC_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleOC.CellEnter
        If Not CargaDetalle Then
            Accion = "U"
            Linea = dgvDetalleOC.Rows(e.RowIndex).Cells(0).Value
            Me.txtPRODUCTO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(1).Value
            Me.txtDESCRIPCION_PRODUCTO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(2).Value
            Me.cmbUNIDAD_MEDIDA.SelectedValue = dgvDetalleOC.Rows(e.RowIndex).Cells(3).Value
            Me.txtCANTIDAD.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(5).Value
            Me.txtCOSTO_UNITARIO.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(7).Value
            Me.txtPRODUCTO.Enabled = False
            Me.txtCANTIDAD.Focus()
        Else
            CargaDetalle = False
            Accion = "I"
        End If
    End Sub

    Private Sub bntEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntEliminar.Click
        If MsgBox("¿Está seguro de eliminar el producto: " & vbCrLf & Me.txtDESCRIPCION_PRODUCTO.Text & "?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            jClass.Ejecutar_ConsultaSQL("DELETE FROM CONTABILIDAD_ORDEN_COMPRA_COMPROBANTE_RECIBIDO WHERE ITEM = " & Linea)
            CargaOC_Detalle(Compañia, Me.txtOC.Text, Me.txtNC.Text)
        End If
    End Sub

    Private Sub txtCCF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCCF.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtPRODUCTO.Focus()
        End If
    End Sub

    Private Sub txtCCF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCCF.LostFocus
        Dim OC As String
        If Val(txtNC.Text) = 0 Then
            MsgBox("Debe ingresar un Número de NOTA DE CREDITO", MsgBoxStyle.Exclamation, "Busqueda")
            Return
        End If
        If Me.txtCCF.Text.Length > 0 And Me.TxtProveedor_Codigo.Text.Length > 0 Then
            Sql = "SELECT OC.ORDEN_COMPRA" & vbCrLf
            Sql &= "  FROM dbo.CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO OC, dbo.CONTABILIDAD_ORDEN_COMPRA_CHEQUES CH" & vbCrLf
            Sql &= " WHERE OC.COMPAÑIA = CH.COMPAÑIA" & vbCrLf
            Sql &= "   AND OC.ORDEN_COMPRA = CH.ORDEN_COMPRA" & vbCrLf
            Sql &= "   AND CH.TIPO_DOCUMENTO = 2" & vbCrLf
            Sql &= "   AND CH.DOCUMENTO =  " & Me.txtCCF.Text & vbCrLf
            Sql &= "   AND OC.PROVEEDOR = " & Me.TxtProveedor_Codigo.Text & vbCrLf
            OC = jClass.obtenerEscalar(Sql)
            If OC = Nothing Then
                MsgBox("No existe el CCF #" & Me.txtCCF.Text & " para el proveedor: " & Me.TxtProveedor_NombreComercial.Text, MsgBoxStyle.Information, "No encontrado")
                Me.txtOC.Text = "0"
            Else
                Me.txtOC.Text = OC.ToString
                Me.txtCCF.ReadOnly = True
                Me.TxtProveedor_Codigo.ReadOnly = True
                'Sql = "SELECT TOP 1 DOCUMENTO FROM CONTABILIDAD_ORDEN_COMPRA_COMPROBANTE_RECIBIDO WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & OC & " AND CCF_NC =  " & Me.txtCCF.Text
                'txtNC.Text = CInt(Val(jClass.obtenerEscalar(Sql))).ToString()
                If CInt(jClass.obtenerEscalar("SELECT COUNT(DOCUMENTO) FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & OC & " AND DOCUMENTO =  " & Val(txtNC.Text) & " AND NOTA_CREDITO = 1")) > 0 Then
                    Me.btnProcesar.Enabled = False
                    Me.btnGuardarDetalle.Enabled = False
                    Me.bntEliminar.Enabled = False
                    Me.lblMensaje.Visible = True
                    If Val(jClass.obtenerEscalar("SELECT ISNULL(SUM(RETENCION), 0.00) FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & OC & " AND DOCUMENTO =  " & txtNC.Text & " AND NOTA_CREDITO = 1")) = 0.0 Then
                        Me.chkPercep.Checked = True
                        Me.chkPercep.Enabled = False
                    End If
                Else
                    Me.lblMensaje.Visible = False
                End If
                BuscarOC(Compañia, OC, 1)
                CargaOC_Detalle(Compañia, OC, Me.txtNC.Text)
                CargaOC_Detalle_Total()
            End If
        End If
    End Sub

    Private Function AjustarPagoCCF(ByVal CIA As Integer, ByVal OC As Integer, _
                                    ByVal SubTotal As Double, ByVal IVA As Double, ByVal Total As Double, _
                                    ByVal Retencion As Double, ByVal TotalFinal As Double) As Boolean
        Dim Resultado As Integer
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD "
            Sql &= "  @COMPAÑIA        = " & CIA
            Sql &= ", @ORDEN_COMPRA    = " & OC
            Sql &= ", @BODEGA          = 0" 'Bodega
            Sql &= ", @CHEQUE          = 0" 'Cheque
            Sql &= ", @SUBTOTAL        = " & SubTotal
            Sql &= ", @IVA             = " & IVA
            Sql &= ", @TOTAL           = " & Total
            Sql &= ", @RETENCION       = " & Retencion
            Sql &= ", @TOTAL_FINAL     = " & TotalFinal
            Sql &= ", @DOCUMENTO       = " & txtCCF.Text 'Numero documento
            Sql &= ", @BANCO           = 0"  'Banco
            Sql &= ", @CUENTA_BANCARIA = ''" 'CuentaBancaria
            Sql &= ", @LIBRO_CONTABLE  = 0"  'Libro Contable
            Sql &= ", @CUENTA          = " & Me.txtNC.Text 'Cuenta contable de cuenta bancaria
            Sql &= ", @TRANSACCION     = 0"  'Transaccion
            Sql &= ", @PARTIDA         = 0"  'Partida
            Sql &= ", @FECHA_CONTABLE  = '" & Format(Me.dpFECHA_NC.Value, "dd/MM/yyyy") & "'"
            Sql &= ", @ORDENES_COMPRA  = ''"  'Ordenes Compra
            Sql &= ", @USUARIO         = '" & Usuario & "'"
            Sql &= ", @IUD             = 'X'" 'IUD
            Sql &= ", @NOTA_CREDITO    = 0"
            Comando_.CommandText = Sql
            Resultado = jClass.ejecutarComandoSql(Comando_)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Mantenimiento Cheques")
            Resultado = -1
        End Try
        If Resultado > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function Mantenimiento_Cheques(ByVal CIA As Integer, ByVal OC As Integer, ByVal Bodega As Integer, _
                                            ByVal SubTotal As Double, ByVal IVA As Double, ByVal Total As Double, _
                                            ByVal Retencion As Double, ByVal TotalFinal As Double, _
                                            ByVal NC As Integer, ByVal Transaccion As Integer, ByVal Partida As Integer, _
                                            ByVal FechaContable As DateTime) As Boolean
        Dim Resultado As Integer
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD "
            Sql &= " @COMPAÑIA        = " & CIA & vbCrLf
            Sql &= ",@ORDEN_COMPRA    = " & OC & vbCrLf
            Sql &= ",@BODEGA          = " & Bodega & vbCrLf
            Sql &= ",@CHEQUE          = -1" & vbCrLf
            Sql &= ",@SUBTOTAL        = " & -SubTotal & vbCrLf
            Sql &= ",@IVA             = " & -IVA & vbCrLf
            Sql &= ",@TOTAL           = " & -Total & vbCrLf
            Sql &= ",@RETENCION       = " & -Retencion & vbCrLf
            Sql &= ",@TOTAL_FINAL     = " & -TotalFinal & vbCrLf
            Sql &= ",@DOCUMENTO       = " & NC & vbCrLf
            Sql &= ",@BANCO           = 0" & vbCrLf
            Sql &= ",@CUENTA_BANCARIA = ''" & vbCrLf
            Sql &= ",@LIBRO_CONTABLE  = 0" & vbCrLf
            Sql &= ",@CUENTA          = 0" & vbCrLf 'Código Cuenta contable de cuenta bancaria
            Sql &= ",@TRANSACCION     = " & Transaccion & vbCrLf
            Sql &= ",@PARTIDA         = " & Partida & vbCrLf
            Sql &= ",@FECHA_CONTABLE  = '" & Format(FechaContable, "dd/MM/yyyy HH:mm:ss") & "'" & vbCrLf
            Sql &= ",@ORDENES_COMPRA  = ''" & vbCrLf
            Sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD             = 'I'" & vbCrLf
            Sql &= ",@NOTA_CREDITO    =  1" & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO  =  2" & vbCrLf
            Sql &= ",@CCF             =  '" & Me.txtCCF.Text & "'" & vbCrLf
            Sql &= ",@FECHA_RECEPCION = '" & Format(FechaContable, "dd/MM/yyyy HH:mm:ss") & "'" & vbCrLf
            Sql &= ",@PAGADO          =  1" & vbCrLf
            Comando_.CommandText = Sql
            Resultado = jClass.ejecutarComandoSql(Comando_)
            If Resultado > 0 Then
                MsgBox("Proceso ejecutado exitosamente", MsgBoxStyle.Information, "Nota Crédito")
            ElseIf Resultado = 0 Then
                MsgBox("Proceso no modificó ningún registro en Cuentas por Pagar", MsgBoxStyle.Information, "Nota Crédito")
                Return False
            ElseIf Resultado = -1 Then
                MsgBox("Proceso provocó un error al insertar en Cuentas por Pagar", MsgBoxStyle.Information, "Nota Crédito")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Mantenimiento Cheques")
            Return False
        End Try
        Return True
    End Function

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAjustarInv.CheckedChanged
        If Not Me.chkAjustarInv.Checked Then
            Me.btnLimpiarProducto.PerformClick()
        End If
        Me.txtPRODUCTO.Enabled = Me.chkAjustarInv.Checked
        Me.txtDESCRIPCION_PRODUCTO.Enabled = Not Me.chkAjustarInv.Checked
    End Sub

    Private Sub MovimientoInventario(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal Proveedor As Integer, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal Mov As Integer)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            Sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", " & Proveedor
            Sql &= ", 23" 'TIPO_MOVIMIENTO - Nota de Crédito x compras
            Sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            Sql &= ", 0" 'MOV1
            Sql &= ", 32" 'TIPO_DOCUMENTO_CONTABLE - Nota de Crédito x compras
            Sql &= ", " & Me.txtNC.Text 'NUMERO_DOCUMENTO_CONTABLE
            Sql &= ", '" & Format(FechaMov, "Short Date") & "'" 'FECHA MOVIMIENTO
            Sql &= ", 0" 'ANULADO?
            Sql &= ", 1" 'PROCESADO
            Sql &= ", " & codProd
            Sql &= ", " & Cant
            Sql &= ", " & CostoU
            Sql &= ", " & CostoT
            Sql &= ", 0" 'ENTRADA_SALIDA
            Sql &= ", '" & Usuario & "'"
            Sql &= ", 'I'" 'SIUD
            Sql &= ", 0" 'ORDEN_VENTA
            sqlCmd.CommandText = Sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje Inventario Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub chkPercep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPercep.CheckedChanged
        Me.CargaOC_Detalle_Total()
    End Sub

    Private Sub Contabilidad_NotaCreditoCompras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub tabDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabDatos.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtCCF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCF.TextChanged

    End Sub
End Class
