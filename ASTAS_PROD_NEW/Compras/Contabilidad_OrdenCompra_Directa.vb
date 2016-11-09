Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Directa
    Public afectan_inventario As Boolean
    Dim Sql As String
    Dim Iniciando As Boolean = True
    Dim CargaDetalle As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim Accion As String = "I"
    Dim Linea As Integer = 0
    Dim IVA, Percepcion, WPercepcion, porcCESC As Double
    Dim bonificacion As Integer
    Dim intFindProveedor As Integer = 0
    Dim Proc As New jarsClass
    Dim Table1 As DataTable
    Dim Table2 As DataTable
    Dim Costo_Anterior As Double = 0
    Dim Precio_Anterior As Double = 0
    Dim Existencia_Anterior As Double = 0
    Dim numeroEntrada As String

    Private Sub Contabilidad_OrdenCompra_Directa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.gbFormaPago.Visible = False
        Me.setTipoCompra()
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 4)
        CargaTipoContribuyente(Me.cmbCOMPAÑIA.SelectedValue, 1)
        CargaFormaPago(Me.cmbCOMPAÑIA.SelectedValue, 1)
        CargaCondicionPago(Me.cmbCOMPAÑIA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
        CargaUnidadMedida(Me.cmbCOMPAÑIA.SelectedValue, 1)
        CargaTipoDocumento(Compañia)
        Me.cmbTipoDocumento.SelectedValue = 2
        Me.ChkQuitarPerc.Checked = False
        CargaPorcentajeImpuestos(1)
        CargaPorcentajeImpuestos(54)
        BuscaProductos()
        Iniciando = False
        If Not afectan_inventario Then
            Me.Label24.Text = "Fecha de Proceso:"
        End If
        Me.cmbCOMPAÑIA.Enabled = False
        If Me.afectan_inventario Then
            cmbUNIDAD_MEDIDA.Enabled = False
        Else
            cmbUNIDAD_MEDIDA.Enabled = True
        End If
    End Sub

    'Setea valores segun tipo de compra
    Private Sub setTipoCompra()
        Me.Text = "Compras Directas - [" & IIf(Me.afectan_inventario, "", "No") & " Afectan Inventario]"

        If Me.afectan_inventario Then
            Me.lblProducto.Text = "Producto"
            Me.btnBuscarProducto.Visible = True
            Me.txtPRODUCTO.Visible = True
            Me.txtDESCRIPCION_PRODUCTO.Enabled = False
        Else
            Me.lblProducto.Text = String.Empty
            Me.btnBuscarProducto.Visible = False
            Me.txtPRODUCTO.Visible = False
            Me.txtDESCRIPCION_PRODUCTO.Enabled = True
        End If

        IIf(Me.afectan_inventario, Me.dgvDetalleOC.Columns(1).Visible = True, Me.dgvDetalleOC.Columns(1).Visible = False)
    End Sub

    Private Sub GeneraSQL()
        Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        Sql &= Compañia
        Sql &= ", " & Me.cmbBODEGA.SelectedValue
        Sql &= ", ''"
        Sql &= ", ''"
        Sql &= ", " & 999
        Sql &= ", " & 4
    End Sub
    Private Sub BuscaProductos()
        Try
            GeneraSQL()
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = Sql
            Table1 = Proc.obtenerDatos(sqlCmd)
            Me.dgvProductos.Columns.Clear()
            Me.dgvProductos.DataSource = Table1
            LimpiaGrid1()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub LimpiaGrid1()

        Me.dgvProductos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.dgvProductos.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.dgvProductos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProductos.Columns.Item(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        'IIf(Me.afectan_inventario, Me.dgvDetalleOC.Columns(1).Visible = True, Me.dgvDetalleOC.Columns(1).Visible = False)
    End Sub

    Private Function AplicaCESC(ByVal prod As Integer) As Boolean
        Dim result As Boolean
        Sql = "SELECT S.APLICA_CESC FROM INVENTARIOS_CATALOGO_PRODUCTOS P, INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS S" & vbCrLf
        Sql &= " WHERE P.COMPAÑIA = S.COMPAÑIA AND P.GRUPO = S.GRUPO AND P.SUBGRUPO = S.SUBGRUPO AND P.PRODUCTO = " & prod & " AND P.COMPAÑIA = " & Compañia
        result = Proc.obtenerEscalar(Sql)
        Return result
    End Function

    Private Sub CargaCompañia()
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", " & Compañia
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Me.cmbCOMPAÑIA.SelectedValue = Compañia
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA  =  " & Bandera & ", "
            Sql &= "@COMPAÑIA =  " & Compañia & ", "
            Sql &= "@USUARIO  = '" & Usuario & "'"
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoContribuyente(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_TipoProveedor.DataSource = Table
            Me.CmbProveedor_TipoProveedor.ValueMember = "TIPO_PROVEEDOR"
            Me.CmbProveedor_TipoProveedor.DisplayMember = "DESCRIPCION_TIPO_PROVEEDOR"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaFormaPago(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_FormaPago.DataSource = Table
            Me.CmbProveedor_FormaPago.ValueMember = "Pago"
            Me.CmbProveedor_FormaPago.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPorcentajeImpuestos(ByVal Constante As Integer)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONSTANTES "
            Sql &= Compañia
            Sql &= ", " & Constante
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            If Constante = 1 Then
                IVA = Table.Rows(0).Item(0)
            ElseIf Constante = 2 Then
                Percepcion = Table.Rows(0).Item(0)
                WPercepcion = Table.Rows(0).Item(0)
            ElseIf Constante = 54 Then
                porcCESC = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCondicionPago(ByVal Compañia, ByVal FormaPago, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO "
            Sql &= Compañia
            Sql &= ", " & FormaPago
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_CondicionPago.DataSource = Table
            Me.CmbProveedor_CondicionPago.ValueMember = "Condición Pago"
            Me.CmbProveedor_CondicionPago.DisplayMember = "Descripción Pago"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUnidadMedida(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbUNIDAD_MEDIDA.DataSource = Table
            Me.cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            Me.cmbUNIDAD_MEDIDA.DisplayMember = "Descripción Unidad"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle(ByVal Compañia, ByVal OrdenCompra, ByVal Bandera)
        Dim Table As DataTable
        If Me.TxtProveedor_Codigo.Text.Length > 0 Then
            CargaDetalle = True
            Try
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE"
                Sql &= " @COMPAÑIA = " & Compañia
                Sql &= ", @ORDEN_COMPRA = " & OrdenCompra
                Sql &= ", @BANDERA = " & Bandera
                Sql &= ", @TIPO_DOCUMENTO = " & Me.cmbTipoDocumento.SelectedValue
                Table = Proc.obtenerDatos(New SqlCommand(Sql))
                Me.dgvDetalleOC.Columns.Clear()
                Me.dgvDetalleOC.DataSource = Table
                LimpiaGrid()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub CargaOC_Detalle_Total(ByVal Compañia, ByVal OrdenCompra, ByVal Bandera)
        Dim SubTotal, SubTotal_Inicial, conIVA, subtotal1, subtotal2, Percibido As Double
        SubTotal = 0
        SubTotal_Inicial = 0
        subtotal2 = 0
        conIVA = 0
        subtotal1 = 0
        Percibido = 0
        For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
            SubTotal += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            If AplicaCESC(Me.dgvDetalleOC.Rows(i).Cells(1).Value) Then
                subtotal2 += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            End If
        Next

        Me.txtSubTotal.Text = (Math.Round(SubTotal, 2)).ToString("#,##0.00")
        If afectan_inventario Then
            Me.TxtCESC.Text = Format(Math.Round(subtotal2 * (porcCESC / 100), 2), "#,##0.00")
        End If
        If Me.cmbTipoDocumento.SelectedValue = 2 Then
            conIVA = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (IVA / 100), 2)
            Me.txtIVA.Text = conIVA.ToString("#,##0.00")

            'Solamente para compras mayores a $100 se realizará percepción.
            If SubTotal >= 100 And CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                Percibido = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (Percepcion / 100), 2)
                Me.txtPercepcion.Text = Percibido.ToString("#,##0.00")
                If ChkQuitarPerc.Checked = False Then
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Percibido + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")) - Val(Me.txtRenta.Text)).ToString("#,##0.00")
                Else
                    Me.txtPercepcion.Text = "0.00"
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")) - Val(Me.txtRenta.Text)).ToString("#,##0.00")
                End If
            Else
                Percibido = 0.0
                Me.txtPercepcion.Text = "0.00"
                Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")) - Val(Me.txtRenta.Text)).ToString("#,##0.00")
            End If
        Else
            Me.txtIVA.Text = "0.00"
            Me.txtPercepcion.Text = "0.00"
            Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")) - Val(Me.txtRenta.Text)).ToString("#,##0.00")
        End If
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvDetalleOC.Columns(0).Width = 50 'Línea
        Me.dgvDetalleOC.Columns(1).Width = 80 'Cod Producto
        Me.dgvDetalleOC.Columns(2).Width = 225 'Descripción
        Me.dgvDetalleOC.Columns(3).Width = 50 'Cod UM
        Me.dgvDetalleOC.Columns(4).Width = 80 'Unidad Medida
        Me.dgvDetalleOC.Columns(5).Width = 70 'Cantidad
        Me.dgvDetalleOC.Columns(6).Width = 70 'Descuento
        Me.dgvDetalleOC.Columns(7).Width = 70 'Costo Unit
        Me.dgvDetalleOC.Columns(8).Width = 70 'Sub Total
        Me.dgvDetalleOC.Columns(9).Width = 70 'Con IVA
        Me.dgvDetalleOC.Columns(10).Width = 70 'Percepcion

        'Segun tipo de compra aculta columna producto
        IIf(Me.afectan_inventario, Me.dgvDetalleOC.Columns(1).Visible = True, Me.dgvDetalleOC.Columns(1).Visible = False)

        Me.dgvDetalleOC.Columns(0).Visible = False
        Me.dgvDetalleOC.Columns(3).Visible = False
        Me.dgvDetalleOC.Columns(6).Visible = False 'Descuento %
        Me.dgvDetalleOC.Columns(9).Visible = False 'IVA
        Me.dgvDetalleOC.Columns(10).Visible = False 'Percepcion
        Me.dgvDetalleOC.Columns(11).Visible = False 'SERVICIO
        Me.dgvDetalleOC.Columns(12).Visible = False 'INTANGIBLE
        Me.dgvDetalleOC.Columns(13).Visible = False
        Me.dgvDetalleOC.Columns(14).Width = 200 'Comentarios
        Me.dgvDetalleOC.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(8).DefaultCellStyle.ForeColor = Color.Red
        Me.dgvDetalleOC.Columns.Item(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvDetalleOC.Columns.Item(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvDetalleOC.Columns(6).Visible = False
    End Sub

    Private Sub BuscarOC(ByVal Compañia, ByVal OrdenCompra, ByVal Bandera)
        Me.btnLimpiarOC.PerformClick()
        Dim Procesada As Boolean = False
        Dim tblOC As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Bandera
            Sql &= ", 1"
            tblOC = Proc.obtenerDatos(New SqlCommand(Sql))
            If tblOC.Rows.Count > 0 Then
                Me.txtOC.Text = tblOC.Rows(0).Item("ORDEN_COMPRA")
                Me.cmbBODEGA.SelectedValue = tblOC.Rows(0).Item("BODEGA")
                Me.dpFECHA_OC.Value = tblOC.Rows(0).Item("FECHA_ORDEN_COMPRA")
                Me.TxtProveedor_Codigo.Text = tblOC.Rows(0).Item("PROVEEDOR")
                Me.TxtProveedor_NombreLegal.Text = tblOC.Rows(0).Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = tblOC.Rows(0).Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = tblOC.Rows(0).Item("NRC")
                Me.TxtProveedor_Nit.Text = tblOC.Rows(0).Item("NIT")
                Me.TxtProveedor_Direccion.Text = tblOC.Rows(0).Item("DIRECCION")
                Me.CmbProveedor_TipoProveedor.SelectedValue = tblOC.Rows(0).Item("TIPO_CONTRIBUYENTE")
                Me.CmbProveedor_FormaPago.SelectedValue = tblOC.Rows(0).Item("FORMA_PAGO")
                Me.CmbProveedor_CondicionPago.SelectedValue = tblOC.Rows(0).Item("CONDICION_PAGO")
                Me.txtOBSERVACIONES.Text = tblOC.Rows(0).Item("OBSERVACIONES")
                Me.cmbTipoDocumento.SelectedValue = tblOC.Rows(0).Item("TIPO_DOCUMENTO")

                If (CInt(tblOC.Rows(0).Item("FORMA_PAGO")) = 1) Then
                    Me.radCajaChica.Checked = True
                    Me.radCxP.Checked = False
                Else
                    Me.radCajaChica.Checked = False
                    Me.radCxP.Checked = True
                End If

                Procesada = tblOC.Rows(0).Item("PROCESADA")
                WPercepcion = tblOC.Rows(0).Item("PORCENTAJE_PERCEPCION")
                If WPercepcion = 0 Then
                    Me.ChkQuitarPerc.Checked = True
                Else
                    Me.ChkQuitarPerc.Checked = False
                End If
                Sql = "SELECT ISNULL(ANULADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                Sql &= " COMPAÑIA= " & Compañia
                Sql &= " AND ORDEN_COMPRA= " & OrdenCompra
                Dim Anulada As Boolean = Proc.obtenerEscalar(Sql)
                If Not Anulada Then

                    Sql = "SELECT ISNULL(AUTORIZADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                    Sql &= " COMPAÑIA= " & Compañia
                    Sql &= " AND ORDEN_COMPRA= " & OrdenCompra
                    Dim Autorizado As Boolean = Proc.obtenerEscalar(Sql)
                    Me.lblMensaje.Visible = Autorizado
                    If Autorizado Then
                        'DeshabilitarCampos Todos
                        Me.lblMensaje.Text = "OdC AUTORIZADA"
                        Deshabilita(False)
                    Else
                        Me.LblProcesada.Visible = Procesada
                        Deshabilita(Not Procesada)
                        Me.grbQuedan.Enabled = True
                    End If
                Else
                    Me.lblMensaje.Visible = True
                    Me.lblMensaje.Text = "OdC ANULADA"
                    Deshabilita(False)
                End If
                Sql = "SELECT TOP 1 DOCUMENTO, FECHA_CONTABLE, FECHA_RECEPCION, QUEDAN FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & OrdenCompra
                tblOC = Proc.obtenerDatos(New SqlCommand(Sql))
                If tblOC.Rows.Count > 0 Then
                    Me.dpFechaDocumento.Value = tblOC.Rows(0).Item("FECHA_CONTABLE")
                    Me.dpFechaProceso.Value = tblOC.Rows(0).Item("FECHA_RECEPCION")
                    Me.txtNumDocumento.Text = tblOC.Rows(0).Item("DOCUMENTO")
                    Me.txtQuedan.Text = tblOC.Rows(0).Item("QUEDAN")
                End If
                HabilitaDeshabilita(False)
            Else
                MsgBox("Verifique si la orden de compra existe y si es compra directa", MsgBoxStyle.Information, "Busqueda O.C.#" & Me.txtOC.Text)
                Me.txtOC.Text = "0"
                HabilitaDeshabilita(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProveedor(ByVal Compañia, ByVal Proveedor)
        Dim tblProv As DataTable
        Try
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = " & Compañia & " AND PROVEEDOR = " & Proveedor
            tblProv = Proc.obtenerDatos(New SqlCommand(Sql))
            If tblProv.Rows.Count > 0 Then
                Me.TxtProveedor_NombreLegal.Text = tblProv.Rows(0).Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = tblProv.Rows(0).Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = tblProv.Rows(0).Item("NRC")
                Me.TxtProveedor_Nit.Text = tblProv.Rows(0).Item("NIT")
                Me.TxtProveedor_Direccion.Text = tblProv.Rows(0).Item("DIRECCION")
                Me.CmbProveedor_TipoProveedor.SelectedValue = tblProv.Rows(0).Item("TIPO_PROVEEDOR")
                Me.CmbProveedor_FormaPago.SelectedValue = tblProv.Rows(0).Item("FORMA_PAGO")
                Me.CmbProveedor_CondicionPago.SelectedValue = tblProv.Rows(0).Item("CONDICION_PAGO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProducto(ByVal Compañia, ByVal Bodega, ByVal Producto)
        Accion = "I"
        Linea = 0
        Dim tblProd As DataTable
        Try

            'JASC
            '18082013
            Dim valor As String
            If Producto.ToString = "" Then
                valor = "''"
            Else
                valor = Producto.ToString
            End If

            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & valor
            Sql &= ", '' " 'Descripción del Producto
            Sql &= ", 0" 'Código de Grupo
            Sql &= ", 2" 'Bandera
            tblProd = Proc.obtenerDatos(New SqlCommand(Sql))
            If tblProd.Rows.Count > 0 Then
                Me.txtPRODUCTO.Text = tblProd.Rows(0).Item("PRODUCTO")
                Me.txtDESCRIPCION_PRODUCTO.Text = tblProd.Rows(0).Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.SelectedValue = tblProd.Rows(0).Item("UNIDAD_MEDIDA")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Mantenimiento_Encabezado(ByVal Compañia, ByVal OrdenCompra, ByVal FechaOC, ByVal Procesada, ByVal Bodega, ByVal Proveedor, ByVal TipoContribuyente, ByVal PorcentajePercepcion, ByVal FormaPago, ByVal CondicionPago, ByVal Observaciones, ByVal IUD, ByVal pordesc, ByVal descuento, ByVal _mostrar_mensaje)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD "
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @ORDEN_COMPRA = " & OrdenCompra
            Sql &= ", @PROCESADA = " & Procesada
            Sql &= ", @BODEGA = " & Bodega
            Sql &= ", @PROVEEDOR = " & Proveedor
            Sql &= ", @TIPO_CONTRIBUYENTE = " & TipoContribuyente
            Sql &= ", @PORCENTAJE_PERCEPCION = " & PorcentajePercepcion
            Sql &= ", @FORMA_PAGO = " & FormaPago
            Sql &= ", @CONDICION_PAGO = " & CondicionPago
            Sql &= ", @OBSERVACIONES = '" & Observaciones & "'"
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Sql &= ", @IUD = '" & IUD & "'"
            Sql &= ", @AFECTAR_INVENTARIOS = " & IIf(Me.afectan_inventario, "'1'", "'0'")
            Sql &= ", @TIPO_DOCUMENTO = " & Me.cmbTipoDocumento.SelectedValue
            Sql &= ", @PORDESC = " & pordesc
            Sql &= ", @IVA = " & Val(Me.txtIVA.Text)
            Sql &= ", @RENTA = " & Val(Me.txtRenta.Text)
            Sql &= ", @DESCUENTO = " & descuento
            Sql &= ", @COMPRA_DIRECTA = 1"
            Sql &= ", @CESC = " & Val(Me.TxtCESC.Text)
            Sql &= ", @VALOR_EXENTO = " & Val(Me.txtExento.Text)
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
            If _mostrar_mensaje Then
                Select Case IUD
                    Case "I"
                        MsgBox("¡Orden de Compra almacenada con éxito!", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("¡Orden de Compra actualizada con éxito!", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("¡Orden de Compra eliminada con éxito!", MsgBoxStyle.Information, "Mensaje")
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub Mantenimiento_OCAutorizacion(ByVal Compañia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD, ByVal Descuento)
    '    Try
    '        Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
    '        Sql &= Compañia
    '        Sql &= ", " & OrdenCompra
    '        Sql &= ", " & Autorizada
    '        Sql &= ", " & Anulada
    '        Sql &= ", " & SubTotal
    '        Sql &= ", " & IVA
    '        Sql &= ", " & Total
    '        Sql &= ", " & Percepcion
    '        Sql &= ", " & TotalCompra
    '        Sql &= ", '" & Comentario & "'"
    '        Sql &= ", '" & Usuario & "'"
    '        Sql &= ", '" & IUD & "'"
    '        Sql &= "," & 0
    '        Sql &= ", " & Descuento
    '        Proc.ejecutarComandoSql(New SqlCommand(Sql))
    '        Dim comando1 As New SqlCommand("update CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO set subtotal = " & SubTotal & _
    '        ",  iva = " & IVA & " , total = " & Total & ", percepcion = " & Percepcion & " , renta = " & 0 & _
    '        ", total_final = " & TotalCompra & " , PORCENTAJE_PERCEPCION = " & WPercepcion & " where COMPAÑIA =  " & Compañia & " and ORDEN_COMPRA = " & OrdenCompra)
    '        Proc.ejecutarComandoSql(comando1)
    '        'MsgBox("¡Orden de Compra Procesada con éxito!", MsgBoxStyle.Information, "Mensaje")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    Private Sub Mantenimiento_OCAutorizacionAplicar(ByVal Compañia, ByVal OrdenCompra, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD, ByVal Descuento)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= "  @COMPAÑIA    = " & Compañia
            Sql &= ", @ORDEN_COMPRA= " & OrdenCompra
            Sql &= ", @AUTORIZADA  = 0" 'Autorizada Original(True) Requerimiento 114 23/06/2016 (False)
            Sql &= ", @ANULADA     = 0" 'Anulada
            Sql &= ", @SUBTOTAL    = " & SubTotal
            Sql &= ", @IVA         = " & IVA
            Sql &= ", @TOTAL       = " & Total
            Sql &= ", @PERCEPCION  = " & Percepcion
            Sql &= ", @TOTAL_FINAL = " & TotalCompra
            Sql &= ", @COMENTARIO  = 'Compra Directa al Proveedor: " & Me.TxtProveedor_NombreLegal.Text.Trim() & "'"
            Sql &= ", @USUARIO     = '" & Usuario & "'"
            Sql &= ", @IUD         = 'I'"
            Sql &= ", @RENTA       = " & Val(Me.txtRenta.Text)
            Sql &= ", @DESCUENTO   = " & Descuento
            Sql &= ", @COMPRA_DIR  = 1"
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
            Dim comando1 As New SqlCommand("UPDATE CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO SET subtotal = " & SubTotal & _
            ",  iva = " & IVA & " , total = " & Total & ", percepcion = " & Percepcion & _
            ", total_final = " & TotalCompra & " , PORCENTAJE_PERCEPCION = " & WPercepcion & " WHERE COMPAÑIA =  " & Compañia & " AND ORDEN_COMPRA = " & OrdenCompra)
            Proc.ejecutarComandoSql(comando1)

            'Autorizar
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= "  @COMPAÑIA    = " & Compañia
            Sql &= ", @ORDEN_COMPRA= " & OrdenCompra
            Sql &= ", @AUTORIZADA  = 1" 'Autorizada (True)
            Sql &= ", @ANULADA     = 0" 'Anulada
            Sql &= ", @SUBTOTAL    = 0"
            Sql &= ", @IVA         = 0"
            Sql &= ", @TOTAL       = 0"
            Sql &= ", @PERCEPCION  = 0"
            Sql &= ", @TOTAL_FINAL = 0"
            Sql &= ", @COMENTARIO  = 'Compra Directa al Proveedor: " & Me.TxtProveedor_NombreLegal.Text.Trim() + "'"
            Sql &= ", @USUARIO     = '" & Usuario & "'"
            Sql &= ", @IUD         = 'U'"
            Sql &= ", @COMPRA_DIR  = 1"
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal Compañia, ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Servicio, ByVal IUD, ByVal bono)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Linea
            Sql &= ", " & Val(Producto)
            Sql &= ", '" & IIf(Descripcion = "", 0, Descripcion) & "'"
            Sql &= ", " & UnidadMedida
            Sql &= ", " & Val(Cantidad)
            Sql &= ", " & Libras
            Sql &= ", " & Val(CostoUnitario) - Val(Val(CostoUnitario) * (Libras / 100))
            Sql &= ", " & Servicio
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", '" & bono & "'"
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCamposOC()
        Iniciando = True
        Me.txtOC.Text = "0"
        Me.chkNada.Checked = True
        Me.txtQuedan.Text = "0"
        Me.txtQuedan.Enabled = True
        Me.lblMensaje.Visible = False
        Me.lblMensaje.Text = ""
        Me.dgvDetalleOC.DataSource = Nothing
        Me.txtOBSERVACIONES.Text = ""
        LimpiaCamposProveedor()
        LimpiaCamposProducto()
        Accion = "I"
        'Me.TxtTotalDet.Text = "0.00"    
        Me.txtSubTotal.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.TxtCESC.Text = "0.00"
        Me.txtPercepcion.Text = "0.00"
        Me.txtTotalFact.Text = "0.00"
        Me.cmbTipoDocumento.SelectedValue = 2
        Me.txtNumDocumento.Clear()
        ''JASC II
        Me.lblMensaje.Text = Nothing
        Me.lblMensaje.Visible = False
        LblProcesada.Visible = False
        intFindProveedor = 0
        Iniciando = False
    End Sub

    Private Sub LimpiaCamposProveedor()
        Me.TxtProveedor_Codigo.Text = ""
        Me.TxtProveedor_NombreLegal.Text = ""
        Me.TxtProveedor_NombreComercial.Text = ""
        Me.TxtProveedor_RegistroFiscal.Text = ""
        Me.TxtProveedor_Nit.Text = ""
        Me.TxtProveedor_Direccion.Text = ""
        Me.ChkQuitarPerc.Checked = False
        Me.ChkQuitarPerc.Enabled = False
    End Sub

    Private Sub LimpiaCamposProducto()

        Me.txtCOSTO_TOTAL.Text = ""
        Me.txtPRODUCTO.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.txtCANTIDAD.Text = ""
        Me.txtLIBRAS.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.txtPRODUCTO.Enabled = True
        Me.btnLimpiarProducto.Enabled = True
        Me.btnBuscarProducto.Enabled = True
        bonificacion = 0
        Accion = "I"
        Linea = 0
    End Sub

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento) As Integer
        Dim tblUltimo As DataTable
        Try
            Sql = "Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            Sql &= Compañia
            Sql &= ", '" & TipoDocumento & "'"
            Sql &= ", 0"
            tblUltimo = Proc.obtenerDatos(New SqlCommand(Sql))
            If tblUltimo.Rows.Count > 0 Then
                Return tblUltimo.Rows(0).Item("ULTIMO")
                Exit Function
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub HabilitaDeshabilita(ByVal Bandera)
        Me.cmbCOMPAÑIA.Enabled = Bandera
        Me.cmbBODEGA.Enabled = Bandera
        Me.dpFECHA_OC.Enabled = Bandera
    End Sub

    Private Sub Deshabilita(ByVal Estado As Boolean)
        'Me.lblMensaje.Visible = Not Bandera
        'Me.GrbProveedor.Enabled = Estado
        bloqueaControl(Estado)
        Me.btnGuardarDetalle.Enabled = Estado
        Me.btnGuardarEncabezado.Enabled = Estado
        Me.BtnBuscar.Enabled = Estado
        Me.btnProcesar.Enabled = Estado
        Me.miMenu_Eliminar.Enabled = Estado
        'Me.btnEliminarOC.Enabled = Estado
        Me.bntEliminar.Enabled = Estado
    End Sub

    Private Sub bloqueaControl(ByVal estado As Boolean)
        For Each ctrl As Control In Me.GrbProveedor.Controls
            If ctrl.Name <> "grbQuedan" Then
                ctrl.Enabled = estado
            End If
        Next
    End Sub

    Private Function ValidaCamposEncabezado() As Boolean
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra no puede ser guardada, ya está Procesada!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_Codigo, "¡Código de Proveedor no es válido!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_Codigo, String.Empty)
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_NombreLegal, "¡Proveedor No posee un Nombre Legal definido!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_NombreLegal, String.Empty)
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_Nit, "¡Proveedor No posee NIT.!")
            Return False
            Exit Function
        End If
        If Me.cmbBODEGA.Text = "" Then
            Me.errp.SetError(Me.cmbBODEGA, "¡Debe seleccionar Bodega!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.cmbBODEGA, String.Empty)
        End If
        Return True
    End Function

    Private Function ValidaCamposLinea() As Boolean
        If Me.txtOC.Text = "0" Then
            MsgBox("¡Pimero debe guardar un número de Orden de Compra! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.TxtProveedor_Codigo.Text = "" Then
            Me.errp.SetError(Me.TxtProveedor_Codigo, "Seleccione un Proveedor")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_Codigo, String.Empty)
        End If

        If Me.afectan_inventario Then
            If Me.txtPRODUCTO.Text = "" Then
                Me.errp.SetError(Me.txtPRODUCTO, "Seleccione un Producto")
                Return False
                Exit Function
            Else
                Me.errp.SetError(Me.txtPRODUCTO, String.Empty)
            End If
        End If

        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 Then
            Me.errp.SetError(Me.txtCANTIDAD, "¡Debe seleccionar una Cantidad mayor que cero!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.txtCANTIDAD, String.Empty)
        End If

        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 Then
            Me.errp.SetError(Me.txtCOSTO_UNITARIO, "¡El costo unitario es menor que cero!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.txtCOSTO_UNITARIO, String.Empty)
        End If

        Return True
    End Function

    Private Function ValidaOC() As Boolean
        If Me.txtOC.Text = "0" Then
            MsgBox("¡Debe generar un número de Orden de Compra válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_Codigo, "Seleccione un Proveedor")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_Codigo, String.Empty)
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_NombreLegal, "¡Debe seleccionar un Proveedor con un Nombre Legal válido!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_NombreLegal, String.Empty)
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            Me.errp.SetError(Me.TxtProveedor_Nit, "¡Debe seleccionar un Proveedor con un NIT válido!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.TxtProveedor_Nit, String.Empty)
        End If
        If Me.txtTotalFact.Text = "0.00" Then
            Me.errp.SetError(Me.txtTotalFact, "¡La Orden de Compra no puede ser procesada con monto $0.00!")
            Return False
            Exit Function
        Else
            Me.errp.SetError(Me.txtTotalFact, String.Empty)
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra no puede ser guardada pues ya está Procesada!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCamposProveedor()
            CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 4)
            CargaTipoContribuyente(Me.cmbCOMPAÑIA.SelectedValue, 1)
            CargaFormaPago(Me.cmbCOMPAÑIA.SelectedValue, 1)
            CargaCondicionPago(Me.cmbCOMPAÑIA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
            CargaUnidadMedida(Me.cmbCOMPAÑIA.SelectedValue, 1)
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiaCamposProveedor()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Busqueda.CbxCompania.Enabled = False
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
            Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
            BuscarProveedor(Me.cmbCOMPAÑIA.SelectedValue, Me.TxtProveedor_Codigo.Text)
        Else
            BuscarProveedor(0, 0)
            Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""
        Me.ChkQuitarPerc.Enabled = False
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub CmbProveedor_FormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor_FormaPago.SelectedIndexChanged
        If Iniciando = False Then
            CargaCondicionPago(Me.cmbCOMPAÑIA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
        Busqueda.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Busqueda.Bodega_Value = Me.cmbBODEGA.SelectedValue
        Busqueda.cmbBODEGA.Enabled = False
        Busqueda.BuscaTodos = True
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtPRODUCTO.Text = Producto
            BuscarProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            Producto = ""
        End If
        Me.txtCANTIDAD.Focus()
    End Sub

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        LimpiaCamposProducto()
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub btnGuardarEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEncabezado.Click
        If Not Me.radCajaChica.Checked And Not Me.radCxP.Checked Then
            Me.errp.SetError(Me.gbFormaPago, "Seleccione una forma de pago para esta compra, Cxp o Caja Chica?")
            Return
        Else
            Me.errp.SetError(Me.gbFormaPago, String.Empty)
        End If

        If Not Me.txtNumDocumento.Text.Length > 0 Then
            Me.errp.SetError(Me.txtNumDocumento, "Ingrese un numero de Documento")
            Return
        Else
            Me.errp.SetError(Me.txtNumDocumento, String.Empty)
        End If

        'If MsgBox("Guardar los datos generales de la Orden de Compra?", MsgBoxStyle.YesNo, "GUARDAR") = MsgBoxResult.Yes Then
        If ValidaCamposEncabezado() = True Then
            Dim IUD As String
            If Me.txtOC.Text = "0" Then
                Me.txtOC.Text = GeneraCorrelativo(Me.cmbCOMPAÑIA.SelectedValue, "OC").ToString
                IUD = "I"
            Else
                IUD = "U"
            End If
            Mantenimiento_Encabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 0, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, WPercepcion, IIf(Me.radCajaChica.Checked, 1, 2), Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), IUD, 0, 0, False)
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            If Me.lblMensaje.Visible = True Then
                HabilitaDeshabilita(False)
            End If
        End If
        'End If
    End Sub

    Private Sub btnLimpiarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarOC.Click
        Me.gbFormaPago.Visible = False
        LimpiaCamposOC()
        HabilitaDeshabilita(True)
        Deshabilita(True)
        btnProcesar.Enabled = True
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Me.btnGuardarEncabezado.PerformClick()
        If ValidaCamposLinea() = True Then

            'Ingresa el detalle a la tabla de detalles
            Mantenimiento_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.txtCANTIDAD.Text, 0, Me.txtCOSTO_UNITARIO.Text, "0", Accion, bonificacion)
            'Muestra el detalle de la oc en el grid
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            'Calcula los totales de las cajas de texto.
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            LimpiaCamposProducto()
            ChkQuitarPerc.Enabled = True
            If Me.CmbProveedor_TipoProveedor.SelectedValue = 3 And Contribuyente < 3 Then
                ChkQuitarPerc.Enabled = True
            End If
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

    Private Sub txtLIBRAS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLIBRAS.KeyPress
        Dim cadena As String = Me.txtLIBRAS.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnBuscarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarOC.Click
        Dim Busqueda As New Contabilidad_BusquedaOrdenCompra
        Producto = ""
        Descripcion_Producto = ""
        Busqueda.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Busqueda.Bodega_Value = Me.cmbBODEGA.SelectedValue
        Busqueda.cmbCOMPAÑIA.Enabled = False
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtOC.Text = Producto
            Me.cmbBODEGA.SelectedValue = Descripcion_Producto
            BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            Producto = ""
            Descripcion_Producto = ""
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra ya está Autorizada!" & Chr(13) & "No podrá realizar cambios.", MsgBoxStyle.Critical, "Mensaje")
            HabilitaDeshabilita(False)
        Else
            HabilitaDeshabilita(True)
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim reporte_10 As New Inventario_Compras_Recibir_rpt
        If Proc.obtenerEscalar("SELECT PROCESADA FROM CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & Me.txtOC.Text) Then
            MsgBox("Compra procesada y finalizada", MsgBoxStyle.Information, "Compra Directa")
            Return
        End If
        If Val(Me.txtOC.Text) > 0 Then
            If Val(Me.txtQuedan.Text) > 0 Then
                If Proc.obtenerEscalar("SELECT COUNT(QUEDAN) FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND QUEDAN = " & Me.txtQuedan.Text) = 0 Then
                    MsgBox("El Número de Quedan no ha sido generado aún..." & vbCrLf & "VERIFIQUE", MsgBoxStyle.Information, "VALIDACION")
                    Return
                Else
                    If Not Proc.obtenerEscalar("SELECT TOP 1 OC.PROVEEDOR FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES C INNER JOIN CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO OC ON C.COMPAÑIA = OC.COMPAÑIA AND C.ORDEN_COMPRA = OC.ORDEN_COMPRA WHERE C.COMPAÑIA = " & Compañia & " AND C.QUEDAN = " & Me.txtQuedan.Text).ToString().Equals(Me.TxtProveedor_Codigo.Text) Then
                        MsgBox("El Proveedor del Quedan ingresado no es el mismo que en el documento actual..." & vbCrLf & "VERIFIQUE", MsgBoxStyle.Information, "VALIDACION")
                        Return
                    End If
                End If
            End If
            If MsgBox("Advertencia: Ya no podrá hacer cambios." & vbCrLf & "¿Desea Procesar Orden De Compra?", MsgBoxStyle.YesNo, "FINALIZAR") = MsgBoxResult.Yes Then
                btnProcesar.Enabled = False
                Mantenimiento_Encabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 1, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, Me.lblPORCENTAJE_PERCEPCION.Text, IIf(Me.radCajaChica.Checked, 1, 2), Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), "U", 0, 0, False)
                'Aplicar Autorización
                Mantenimiento_OCAutorizacionAplicar(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", "0")
                'JASC II

                If Me.afectan_inventario Then
                    'Aplicar en inventarios
                    Dim SubTot As Decimal

                    obtenerMovEntrada()
                    For i As Integer = 0 To Me.dgvDetalleOC.RowCount - 1
                        SubTot = Me.dgvDetalleOC.Rows(i).Cells("Sub Total").Value
                        cadenaSIUD(Compañia, "I", Me.txtOC.Text, Me.dgvDetalleOC.Rows(i).Cells("Línea").Value, Me.cmbBODEGA.SelectedValue, Me.dgvDetalleOC.Rows(i).Cells("Producto").Value.ToString(), Me.dgvDetalleOC.Rows(i).Cells("Cantidad").Value.ToString(), Me.dgvDetalleOC.Rows(i).Cells("Costo Unit.").Value.ToString(), SubTot)
                        Proc.Ejecutar_ConsultaSQL(Sql)
                    Next
                End If
                'Generar cuenta por pagar
                Mantenimiento_Cheques(Compañia, Me.txtOC.Text, Me.cmbBODEGA.SelectedValue, 0, Me.txtSubTotal.Text, Me.txtIVA.Text, (Val(Me.txtSubTotal.Text) + Val(Me.txtIVA.Text)), _
                                     Me.txtPercepcion.Text, Me.txtTotalFact.Text, Me.txtNumDocumento.Text, 0, "", 0, 0, 0, 0, Me.dpFechaDocumento.Value, "", "I")
                'Datos reporte recibido
                For i As Integer = 0 To Me.dgvDetalleOC.RowCount - 1
                    Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO_IUD "
                    Sql &= " @COMPAÑIA             = " & Compañia
                    Sql &= ",@ORDEN_COMPRA         = " & Me.txtOC.Text
                    Sql &= ",@LINEA                = " & Me.dgvDetalleOC.Rows(i).Cells.Item("Línea").Value
                    Sql &= ",@PRODUCTO             = " & Me.dgvDetalleOC.Rows(i).Cells("Producto").Value
                    Sql &= ",@DESCRIPCION_PRODUCTO = ''"
                    Sql &= ",@UNIDAD_MEDIDA        = " & Me.cmbBODEGA.SelectedValue
                    Sql &= ",@CANTIDAD             = " & Me.cmbTipoDocumento.SelectedValue
                    Sql &= ",@LIBRAS               = " & Me.txtNumDocumento.Text
                    Sql &= ",@COSTO_UNITARIO       = " & Me.dgvDetalleOC.Rows(i).Cells("Sub Total").Value
                    Sql &= ",@SERVICIO             = 0"
                    Sql &= ",@CANTIDAD_RECIBIDO    = " & Me.dgvDetalleOC.Rows(i).Cells("Cantidad").Value
                    Sql &= ",@LIBRAS_RECIBIDO      = " & Me.TxtProveedor_Codigo.Text
                    Sql &= ",@CANTIDAD_PENDIENTE   = 0"
                    Sql &= ",@LIBRAS_PENDIENTE     = 0"
                    Sql &= ",@RECIBIDO             = 1"
                    Sql &= ",@A_INVENTARIO         = " & IIf(afectan_inventario, "1", "0")
                    Sql &= ",@USUARIO              = '" & Usuario & "' "
                    Sql &= ",@IUD                  = 'U'"
                    Proc.ejecutarComandoSql(New SqlCommand(Sql))
                Next
                'reporte recibido
                reporte_10.SetDataSource(Proc.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.txtOC.Text & ", @BANDERA = 1, @DOCUMENTO = " & Me.txtNumDocumento.Text)))
                Rpts.ReportesGenericos(reporte_10)
                Rpts.ShowDialog()

                btnGuardarEncabezado.Enabled = False
                'btnEliminarOC.Enabled = False

                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "OC FINALIZADA"
                Deshabilita(False)
                Me.grbQuedan.Enabled = True

                'Imprimiendo OC
                Rpts.CargaOC_Directa(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text)
                Rpts.ShowDialog()

                If Me.radCajaChica.Checked Then
                    'cancelar cuenta por pagar
                    Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD" & vbCrLf
                    Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= ", @ORDEN_COMPRA = " & txtOC.Text & vbCrLf
                    Sql &= ", @BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                    Sql &= ", @CHEQUE = 0" & vbCrLf
                    Sql &= ", @SUBTOTAL = 0" & vbCrLf
                    Sql &= ", @IVA = 0" & vbCrLf
                    Sql &= ", @TOTAL = " & Me.txtTotalFact.Text & vbCrLf
                    Sql &= ", @RETENCION = 0" & vbCrLf
                    Sql &= ", @TOTAL_FINAL = " & Me.txtTotalFact.Text & vbCrLf
                    Sql &= ", @DOCUMENTO = " & Me.txtNumDocumento.Text & vbCrLf
                    Sql &= ", @BANCO = 0" & vbCrLf
                    Sql &= ", @CUENTA_BANCARIA = ''" & vbCrLf
                    Sql &= ", @LIBRO_CONTABLE = 0" & vbCrLf
                    Sql &= ", @CUENTA = 0" & vbCrLf
                    Sql &= ", @TRANSACCION = 0" & vbCrLf
                    Sql &= ", @PARTIDA = 0" & vbCrLf
                    Sql &= ", @FECHA_CONTABLE = '" & Format(Me.dpFECHA_OC.Value, "dd/MM/yyyy") & "'" & vbCrLf
                    Sql &= ", @ORDENES_COMPRA = ''" & vbCrLf
                    Sql &= ", @USUARIO  = '" & Usuario & "'" & vbCrLf
                    Sql &= ", @IUD = 'PAGADO'" & vbCrLf
                    Proc.ejecutarComandoSql(New SqlCommand(Sql))
                End If
            End If
        Else
            MsgBox("No hay Orden de Compra a enviar para Autorizar.", MsgBoxStyle.Exclamation, "AVISO")
        End If
    End Sub

    'Carga a Inventarios
    Private Sub cadenaSIUD(ByVal CIA As Integer, ByVal SIUD As String, ByVal OdC As Integer, ByVal Linea As Integer, ByVal BODEGA As Integer, ByVal producto As Integer, ByVal cantidad As Double, ByVal costo_uni As Double, ByVal total As Double)
        Dim tipoMovimiento As Integer
        Try
            Costo_Anterior = Proc.obtenerEscalar("SELECT dbo.INVENTARIOS_CALCULAR_COSTOS(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Existencia_Anterior = Proc.obtenerEscalar("SELECT dbo.calcular_existencia_actual(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Precio_Anterior = Proc.obtenerEscalar("SELECT dbo.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Sql = "UPDATE CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO SET PRECIO_ANTERIOR=" & Precio_Anterior & ", EXISTENCIA_ANTERIOR=" & Existencia_Anterior & ", COSTO_ANTERIOR=" & Costo_Anterior
            Sql &= " WHERE COMPAÑIA = " & CIA
            Sql &= " AND ORDEN_COMPRA = " & OdC
            Sql &= " AND LINEA = " & Linea
            Proc.Ejecutar_ConsultaSQL(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        tipoMovimiento = 3 'ingreso por compra

        Sql = "EXECUTE dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD " & vbCrLf
        Sql &= "  @COMPAÑIA = " & CIA & vbCrLf
        Sql &= ", @BODEGA = " & BODEGA & vbCrLf
        Sql &= ", @PROVEEDOR = 1" & vbCrLf
        Sql &= ", @TIPO_MOVIMIENTO = " & tipoMovimiento & vbCrLf
        Sql &= ", @MOV = " & numeroEntrada & vbCrLf
        Sql &= ", @TIPO_DOCUMENTO_CONTABLE = " & TipoDocto & vbCrLf
        Sql &= ", @NUMERO_DOCUMENTO_CONTABLE = " & NumeDocto & vbCrLf
        Sql &= ", @FECHA_MOVIMIENTO = N'" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "'" & vbCrLf
        Sql &= ", @ANULADO = 0" & vbCrLf
        Sql &= ", @PROCESADO = 1" & vbCrLf
        Sql &= ", @PRODUCTO = " & producto & vbCrLf
        Sql &= ", @CANTIDAD = " & cantidad & vbCrLf
        Sql &= ", @COSTO_UNIDAD = " & costo_uni & vbCrLf
        Sql &= ", @COSTO_TOTAL = " & total & vbCrLf
        Sql &= ", @ENTRADA_SALIDA = 1" & vbCrLf
        Sql &= ", @USUARIO = N'" & Usuario & "'" & vbCrLf
        Sql &= ", @SIUD = N'" & SIUD & "'" & vbCrLf
    End Sub

    Private Sub obtenerMovEntrada()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE TIPO_MOVIMIENTO = 3"
        numeroEntrada = Proc.leerDataeader(consulta, 0)
    End Sub

    'Pago
    Private Function Mantenimiento_Cheques(ByVal Compañia As Integer, ByVal OC As Integer, ByVal Bodega As Integer, _
                                           ByVal Cheque As Integer, ByVal SubTotal As Double, ByVal IVA As Double, _
                                           ByVal Total As Double, ByVal Retencion As Double, _
                                           ByVal TotalFinal As Double, ByVal CCF As Double, ByVal Banco As Double, _
                                           ByVal CuentaBancaria As String, ByVal LC As Integer, _
                                           ByVal Cuenta As Integer, ByVal Transaccion As Integer, _
                                           ByVal Partida As Integer, ByVal FechaContable As Date, _
                                           ByVal OrdenesCompra As String, ByVal IUD As String) As Boolean
        NumeDocto = CCF
        TipoDocto = Me.cmbTipoDocumento.SelectedValue
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD" & vbCrLf
            Sql &= "  @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ", @ORDEN_COMPRA    = " & OC & vbCrLf
            Sql &= ", @BODEGA          = " & Bodega & vbCrLf
            Sql &= ", @CHEQUE          = " & Cheque & vbCrLf
            Sql &= ", @SUBTOTAL        = " & SubTotal & vbCrLf
            Sql &= ", @IVA             = " & IVA & vbCrLf
            Sql &= ", @TOTAL           = " & Total & vbCrLf
            Sql &= ", @RETENCION       = " & Retencion & vbCrLf
            Sql &= ", @TOTAL_FINAL     = " & TotalFinal & vbCrLf
            Sql &= ", @DOCUMENTO       = " & CCF & vbCrLf
            Sql &= ", @BANCO           = " & Banco & vbCrLf
            Sql &= ", @CUENTA_BANCARIA = '" & CuentaBancaria & "'" & vbCrLf
            Sql &= ", @LIBRO_CONTABLE  = " & LC & vbCrLf
            Sql &= ", @CUENTA          = " & Cuenta & vbCrLf
            Sql &= ", @TRANSACCION     = " & Transaccion & vbCrLf
            Sql &= ", @PARTIDA         = " & Partida & vbCrLf
            Sql &= ", @FECHA_CONTABLE  = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @ORDENES_COMPRA  = '" & OrdenesCompra & "'" & vbCrLf
            Sql &= ", @USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD             = '" & IUD & "'" & vbCrLf
            Sql &= ", @TIPO_DOCUMENTO  = " & Me.cmbTipoDocumento.SelectedValue & vbCrLf
            Sql &= ", @DESCUENTO       = 0" & vbCrLf
            Sql &= ", @FECHA_RECEPCION = '" & Format(Me.dpFechaProceso.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @RENTA           = " & Val(Me.txtRenta.Text) & vbCrLf
            Sql &= ", @PAGADO          = " & IIf(Me.radCajaChica.Checked, 1, 0) & vbCrLf
            Sql &= ", @QUEDAN          = " & Val(Me.txtQuedan.Text) & vbCrLf
            Sql &= ", @CESC            = " & Val(Me.TxtCESC.Text) & vbCrLf
            Sql &= ", @VALOR_EXENTO    = " & Val(Me.txtExento.Text) & vbCrLf
            If Proc.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                If Val(Me.txtQuedan.Text) = 0 Then
                    Me.txtQuedan.Text = CInt(Val(Proc.obtenerEscalar("SELECT TOP 1 QUEDAN FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & OC & " AND DOCUMENTO = " & CCF)))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.txtOC.Text <> "0" Then
            If MsgBox("Imprimir Orden de Compra?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
                If Me.txtSubTotal.Text <> "0.00" Then
                    Rpts.CargaOC_Directa(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text)
                    Rpts.ShowDialog()
                Else
                    MsgBox("No se han definido Costos en la Orden de Compra.", MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            MsgBox("¡Debe seleccionar una Orden de Compra!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub txtPRODUCTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) = True Then
            'Busca la descripcion y unidad de medida del producto.
            BuscarProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            If Me.txtDESCRIPCION_PRODUCTO.Text.Trim.Length = 0 Then
                Me.errp.SetError(Me.txtDESCRIPCION_PRODUCTO, "Ingrese el Codigo del Producto")
                Me.txtPRODUCTO.Focus()
            Else
                Me.txtCANTIDAD.Clear()
                Me.txtCANTIDAD.Focus()
            End If

        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMenu_Eliminar.Click
        Mantenimiento_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value, Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value, "", 0, 0, 0, 0, 0, "D", 0)
        LimpiaCamposProducto()
        CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
        Me.btnProcesar.PerformClick()
    End Sub

    Private Sub TxtProveedor_Codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProveedor_Codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'JASC II
            If intFindProveedor = 0 Then
                Me.gbFormaPago.Visible = False
                MessageBox.Show("Debe de Digitar Bien el codigo del Empleador", "ASTAS", MessageBoxButtons.OK)
                Me.TxtProveedor_Codigo.Focus()
            Else
                Me.gbFormaPago.Visible = True
                txtPRODUCTO.Focus()
            End If
        End If
    End Sub

    Private Sub TxtProveedor_Codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.LostFocus
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub TxtProveedor_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.TextChanged
        If Not IsNumeric(TxtProveedor_Codigo.Text) Then
            Me.gbFormaPago.Visible = False
            TxtProveedor_Codigo.Text = ""
            TxtProveedor_Codigo.Focus()
        Else
            If Me.TxtProveedor_Codigo.Text <> "" Then
                Try
                    Me.gbFormaPago.Visible = True
                    Dim Sql As String
                    Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
                    Sql &= " WHERE COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text

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
                            'JASC II
                            intFindProveedor = 0
                        Else
                            Me.TxtProveedor_Codigo.Text = DS.Tables(0).Rows(0).Item(0)
                            Me.TxtProveedor_NombreLegal.Text = DS.Tables(0).Rows(0).Item(1)
                            Me.TxtProveedor_NombreComercial.Text = DS.Tables(0).Rows(0).Item(2)
                            Me.TxtProveedor_RegistroFiscal.Text = DS.Tables(0).Rows(0).Item(3)
                            Me.TxtProveedor_Nit.Text = DS.Tables(0).Rows(0).Item(4)
                            Me.TxtProveedor_Direccion.Text = DS.Tables(0).Rows(0).Item(5)
                            Me.CmbProveedor_TipoProveedor.SelectedValue = DS.Tables(0).Rows(0).Item(6)
                            If DS.Tables(0).Rows(0).Item(6) = 4 Then
                                Me.cmbTipoDocumento.SelectedValue = 1
                            Else
                                Me.cmbTipoDocumento.SelectedValue = 2
                            End If
                            If DS.Tables(0).Rows(0).Item(6) = 3 Then
                                Me.ChkQuitarPerc.Enabled = True
                            Else
                                Me.ChkQuitarPerc.Enabled = False
                            End If
                            Me.CmbProveedor_FormaPago.SelectedValue = DS.Tables(0).Rows(0).Item(7)
                            Me.CmbProveedor_CondicionPago.SelectedValue = DS.Tables(0).Rows(0).Item(8)
                            intFindProveedor = 1
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                    Conexion_Track.Close()
                Catch ex As Exception

                End Try
            Else
                LimpiaCamposProveedor()
            End If
        End If
    End Sub

    Private Sub CmbProveedor_TipoProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor_TipoProveedor.SelectedIndexChanged
        If Not Iniciando Then
            If Me.CmbProveedor_TipoProveedor.SelectedValue = 3 And Contribuyente < 3 Then
                Me.CargaPorcentajeImpuestos(2)
                Me.lblPORCENTAJE_PERCEPCION.Text = Percepcion.ToString("0.00")
            Else
                Me.lblPORCENTAJE_PERCEPCION.Text = 0.0
                Percepcion = 0.0
            End If
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
            Me.txtCOSTO_TOTAL.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(8).Value
            Me.txtPRODUCTO.Enabled = False
            Me.btnBuscarProducto.Enabled = False
            Me.txtCANTIDAD.Focus()
        Else
            CargaDetalle = False
            Accion = "I"
        End If
    End Sub

    Private Sub bntEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntEliminar.Click
        If MsgBox("¿Está seguro de eliminar el producto: " & vbCrLf & Me.txtDESCRIPCION_PRODUCTO.Text & "?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            'JASC21082013
            Mantenimiento_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Me.dgvDetalleOC.CurrentRow.Cells("Línea").Value, Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value, "", 0, 0, 0, 0, 0, "D", 0)
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            LimpiaCamposProducto()
            'Calcula los totales de las cajas de texto.
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            'Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", "0")
        End If
    End Sub

    Private Sub btnEliminarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro de eliminar Toda la Orden de Compra No. " & Me.txtOC.Text & " completamente?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                'JASC21082013
                Mantenimiento_Detalle(Compañia, Me.txtOC.Text, Me.dgvDetalleOC.Rows(i).Cells("Línea").Value, 0, "", 0, 0, 0, 0, 0, "D", 0)
            Next
            Mantenimiento_Encabezado(Compañia, Me.txtOC.Text, Format(Now, "dd-MM-yyyy HH:mm:ss"), 0, 0, 0, 0, 0, 0, 0, "", "D", 0, 0, False)
            'Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "D", 0)
            'Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), 0, Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "D", 0)
            Me.btnLimpiarOC.PerformClick()
        End If
    End Sub

    Private Sub CargaTipoDocumento(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim sqlConStr As String = "User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & "; Workstation ID="
        Conexion_ = New SqlConnection(sqlConStr)
        Try
            Conexion_.Open()
            Sql = "SELECT TIPO_DOCUMENTO_CONTABLE, IDENTIFICADOR + ' - ' + DESCRIPCION_TIPO_DOCUMENTO AS DESCRIPCION_TIPO_DOCUMENTO FROM dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPAÑIA = " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTipoDocumento.DataSource = Table
            Me.cmbTipoDocumento.ValueMember = "TIPO_DOCUMENTO_CONTABLE"
            Me.cmbTipoDocumento.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Conexion_.Close()
        End Try
    End Sub

    Private Sub cmbTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDocumento.SelectedIndexChanged
        If Not Iniciando Then
            If Val(Me.txtOC.Text) > 0 Then
                CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
                CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            End If
        End If
    End Sub

    Private Sub txtPRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRODUCTO.TextChanged
        If Not IsNumeric(txtPRODUCTO.Text) Then
            txtPRODUCTO.Text = ""
            txtPRODUCTO.Focus()
        Else
            If Linea = 0 Then
                BuscarProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            End If
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
            If Val(txtCOSTO_UNITARIO.Text) = 0 Then
                txtCOSTO_UNITARIO.Text = 0
                txtCOSTO_TOTAL.Focus()
            Else
                txtCOSTO_TOTAL.Text = Val(txtCANTIDAD.Text) * Val(txtCOSTO_UNITARIO.Text)
            End If
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub ChkQuitarPerc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkQuitarPerc.Click
        If Not Iniciando Then
            If Me.ChkQuitarPerc.Checked Then
                WPercepcion = 0
            Else
                WPercepcion = Percepcion
            End If
            If Me.txtOC.Text.Trim > "" Then
                CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            End If
        End If
    End Sub

    Private Sub TxtCostTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOSTO_TOTAL.KeyPress
        Dim cadena As String = Me.txtCOSTO_TOTAL.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        'TODO Se agregó validación para determinar cuando no ingresan costo unitario
        Try

            For I As Integer = 0 To str.Length - 1
                Ocurrencias = Ocurrencias + 1
            Next
            Ocurrencias = Ocurrencias - 1
            If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
                If txtCOSTO_TOTAL.Text > 0 Then
                    txtCOSTO_UNITARIO.Text = Math.Round(Val(txtCOSTO_TOTAL.Text) / Val(txtCANTIDAD.Text), 6)
                End If
            End If
            If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
                e.KeyChar = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Debe ingresar un Costo Unitario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'JASC II
    Private Sub Contabilidad_OrdenCompra_Directa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F3 Then
            Me.btnBuscarProducto.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub Contabilidad_OrdenCompra_Directa_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub tabDatos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabDatos.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub



    Private Sub TxtNombreB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreB.TextChanged
        Dim rows As DataRow()
        Dim CodicionFiltro As String
        Dim Strsort As String = ""

        Select Case dgvProductos.Columns(1).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNombreB.Text = "" Then
            Me.dgvProductos.DataSource = Table1
        Else
            'Se incluyen los brackets por si el nombre de encabezado esta compuesto por mas de una palabra separada por espacios
            CodicionFiltro = "[" & dgvProductos.Columns(1).Name & "]" & " like '" & TxtNombreB.Text & "%'"
            rows = Table1.Select(CodicionFiltro) 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvProductos.DataSource = tablaT
        End If
    End Sub

    Private Function validarproducto(ByVal producto) As Boolean
        Dim respuesta As Boolean = True
        Dim sqlCmdProd As New SqlCommand

        Sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        Sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
        Sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        Sql &= ", " & producto.ToString
        Sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = Sql
        Table2 = Proc.obtenerDatos(sqlCmdProd)
        If Table2.Rows.Count = 0 Then
            MsgBox("No se encontró producto numero: " & Me.txtPRODUCTO.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Me.txtPRODUCTO.Focus()
            respuesta = False
        End If

        Return respuesta
    End Function

    Private Sub obtieneDatosProducto(ByVal codProducto As String)
        Dim sqlCmdProd As New SqlCommand
        If codProducto = Nothing Or codProducto.Length = 0 Then
            Return
        End If
        Sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        Sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
        Sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        Sql &= ", " & codProducto
        Sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = Sql
        Table2 = Proc.obtenerDatos(sqlCmdProd)
        If Table2.Rows.Count = 1 Then
            Me.txtDESCRIPCION_PRODUCTO.Text = Table2.Rows(0).Item("DESCRIPCION_PRODUCTO")
            Me.cmbUNIDAD_MEDIDA.SelectedValue = Table2.Rows(0).Item("UNIDAD_MEDIDA")
        Else
            If Table2.Rows.Count > 1 Then
                MsgBox("Existen mas de dos items para la bodega " & Me.cmbBODEGA.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            Else
                '  MsgBox("No se encontró producto numero: " & Me.txtProducto.Text, MsgBoxStyle.Critical, "Busqueda Producto")
            End If
        End If
    End Sub

    Private Sub dgvProductos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        txtPRODUCTO.Text = dgvProductos.CurrentRow.Cells(0).Value.ToString()
        If Me.txtPRODUCTO.Text <> Nothing Then
            If Me.validarproducto(Me.txtPRODUCTO.Text) = False Then
                Return
            End If
            obtieneDatosProducto(Me.txtPRODUCTO.Text)

        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            BuscaProductos()
        End If
    End Sub

    Private Sub txtOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOC.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtOC_Validated_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOC.Validated
        If Me.txtOC.Text.Length > 0 Then
            BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            btnProcesar.Enabled = True
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra ya está Autorizada!" & Chr(13) & "No podrá realizar cambios.", MsgBoxStyle.Critical, "Mensaje")
            HabilitaDeshabilita(False)
            btnProcesar.Enabled = False
        Else
            HabilitaDeshabilita(True)
        End If
    End Sub

    Private Sub radCajaChica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCajaChica.CheckedChanged
        If radCajaChica.Checked Then
            CmbProveedor_FormaPago.SelectedValue = 1
            Me.txtQuedan.Enabled = False
            Me.txtQuedan.Text = "0"
        End If
    End Sub

    Private Sub radCxP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCxP.CheckedChanged
        If radCxP.Checked Then
            CmbProveedor_FormaPago.SelectedValue = 2
            Me.txtQuedan.Enabled = True
        End If
    End Sub

    Private Sub btnImpQuedan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpQuedan.Click
        If Val(Me.txtQuedan.Text) = 0 Then
            Return
        End If
        'Imprimir Quedan
        Dim _quedan As New CuentasxPagar_Quedan
        _quedan.SetDataSource(Proc.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.txtOC.Text & ", @BANDERA = 6, @COMENTARIOS = '" & Me.txtQuedan.Text & "'")))
        Rpts.ReportesGenericos(_quedan)
        Rpts.ShowDialog()
    End Sub

    Private Sub On_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExento.TextChanged, txtSubTotal.TextChanged, TxtCESC.TextChanged, txtIVA.TextChanged, txtPercepcion.TextChanged, txtRenta.TextChanged
        Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.txtIVA.Text.Replace(",", "")) + Val(Me.txtPercepcion.Text.Replace(",", "")) + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")) - Val(Me.txtRenta.Text.Replace(",", ""))).ToString("#,##0.00")
    End Sub
End Class
