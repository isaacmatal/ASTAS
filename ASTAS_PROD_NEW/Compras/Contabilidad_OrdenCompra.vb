Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra
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
    
    Private Sub Contabilidad_OrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.CargaPorcentajeImpuestos(1)
        Me.CargaPorcentajeImpuestos(54)
        BuscaProductos()
        Iniciando = False
    End Sub
    Private Sub GeneraSQL()
        Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        Sql &= Compañia
        Sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", ''"
        sql &= ", ''"
        sql &= ", " & 999
        sql &= ", " & 4
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

    End Sub

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
        CargaDetalle = True
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE"
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
    End Sub

    Private Function AplicaCESC(ByVal prod As Integer) As Boolean
        Dim result As Boolean
        Sql = "SELECT S.APLICA_CESC FROM INVENTARIOS_CATALOGO_PRODUCTOS P, INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS S" & vbCrLf
        Sql &= " WHERE P.COMPAÑIA = S.COMPAÑIA AND P.GRUPO = S.GRUPO AND P.SUBGRUPO = S.SUBGRUPO AND P.PRODUCTO = " & prod & " AND P.COMPAÑIA = " & Compañia
        result = Proc.obtenerEscalar(Sql)
        Return result
    End Function
    Private Sub CargaOC_Detalle_Total(ByVal Compañia, ByVal OrdenCompra, ByVal Bandera)
        Dim Descuento, SubTotal, SubTotal_Inicial, conIVA, subtotal1, subtotal2, Percibido As Double
        Descuento = 0
        SubTotal = 0
        SubTotal_Inicial = 0
        subtotal2 = 0
        conIVA = 0
        subtotal1 = 0
        Percibido = 0
        For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
            'sub total con porcentaje aplicado            
            SubTotal += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            'Descuento Global
            'Descuento += subtotal1 * (Me.dgvDetalleOC.Rows(i).Cells(13).Value / 100)
            'SubTotal_Inicial += (subtotal1 / (1 - (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100)))
            If AplicaCESC(Me.dgvDetalleOC.Rows(i).Cells(1).Value) Then
                subtotal2 += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            End If
            'subtotal2 = (subtotal1 / (1 - (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100)))
            'Descuento individual'
            'Descuento += (subtotal2 * (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100))
            'SubTotal += subtotal1
        Next
        
        'JASC
        'Me.TxtTotalDet.Text = (Math.Round(SubTotal_Inicial, 2)).ToString("#,##0.00")

        'SubTotal = Math.Round(SubTotal - Descuento, 2)

        'Me.Txt_Descuento.Text = (Descuento).ToString("#,##0.00")
        Me.txtSubTotal.Text = Format(Math.Round(SubTotal, 2), "#,##0.00")
        Me.TxtCESC.Text = Format(Math.Round(subtotal2 * (porcCESC / 100), 2), "#,##0.00")
        If Me.cmbTipoDocumento.SelectedValue = 2 Then
            conIVA = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (IVA / 100), 2)
            Me.txtIVA.Text = conIVA.ToString("#,##0.00")

            'JASC II
            'Solamente para compras mayores a $100 se realizará percepción (o igual a $100 segun dijeron despues).
            If SubTotal >= 100 And CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                Percibido = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (1 / 100), 2)
                Me.txtPercepcion.Text = Percibido.ToString("#,##0.00")
                If ChkQuitarPerc.Checked = False Then
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Percibido + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", ""))).ToString("#,##0.00")
                Else
                    Me.txtPercepcion.Text = "0.00"
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", ""))).ToString("#,##0.00")
                End If
            Else
                Percibido = 0.0
                Me.txtPercepcion.Text = "0.00"
                Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", ""))).ToString("#,##0.00")
            End If
        Else
            Me.txtIVA.Text = "0.00"
            Me.txtTotal.Text = Val(Me.txtSubTotal.Text.Replace(",", "")).ToString("#,##0.00")
            Me.txtPercepcion.Text = "0.00"
            Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", ""))).ToString("#,##0.00")
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
        Dim Procesada As Boolean = False
        Dim tblOC As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Bandera
            tblOC = Proc.obtenerDatos(New SqlCommand(Sql))
            If tblOC.Rows.Count > 0 Then
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
                Me.TxtCESC.Text = tblOC.Rows(0).Item("CESC")
                Me.txtExento.Text = tblOC.Rows(0).Item("VALOR_EXENTO")
                'JASC30082013
                'Me.TxtporDescTotal.Text = tblOC.Rows(0).Item("Porcentaje_descuento")
                'Me.txtDescuentoGlobal.Text = tblOC.Rows(0).Item("valor_descuento")

                Procesada = tblOC.Rows(0).Item("PROCESADA")
                WPercepcion = tblOC.Rows(0).Item("PORCENTAJE_PERCEPCION")
                If WPercepcion = 0 Then
                    Me.ChkQuitarPerc.Checked = True
                Else
                    Me.ChkQuitarPerc.Checked = False
                End If
                Sql = "SELECT ISNULL(ANULADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                Sql &= " COMPAÑIA= " & Compañia
                Sql &= " AND "
                Sql &= " ORDEN_COMPRA= " & OrdenCompra
                Dim Anulada As Boolean = Proc.obtenerEscalar(Sql)
                If Not Anulada Then

                    Sql = "SELECT ISNULL(AUTORIZADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                    Sql &= " COMPAÑIA= " & Compañia
                    Sql &= " AND "
                    Sql &= " ORDEN_COMPRA= " & OrdenCompra
                    Dim Autorizado As Boolean = Proc.obtenerEscalar(Sql)
                    Me.lblMensaje.Visible = Autorizado
                    If Autorizado Then
                        'DeshabilitarCampos Todos
                        Me.lblMensaje.Text = "OdC AUTORIZADA"
                        Deshabilita(False)
                    Else
                        Me.LblProcesada.Visible = Procesada
                        Deshabilita(True)
                    End If
                    Me.btnAnular.Enabled = True
                    Me.btnFinRecepción.Enabled = True
                Else
                    Me.btnAnular.Enabled = False
                    Me.btnFinRecepción.Enabled = False
                    Me.lblMensaje.Visible = True
                    Me.lblMensaje.Text = "OdC ANULADA"
                    Deshabilita(False)
                End If
                HabilitaDeshabilita(False)
            Else
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

    Private Sub Mantenimiento_Encabezado(ByVal Compañia, ByVal OrdenCompra, ByVal FechaOC, ByVal Procesada, ByVal Bodega, ByVal Proveedor, ByVal TipoContribuyente, ByVal PorcentajePercepcion, ByVal FormaPago, ByVal CondicionPago, ByVal Observaciones, ByVal IUD)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD "
            Sql &= "  @COMPAÑIA = " & Compañia
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
            Sql &= ", @AFECTAR_INVENTARIOS = '1'"
            Sql &= ", @TIPO_DOCUMENTO = " & Me.cmbTipoDocumento.SelectedValue
            Sql &= ", @CESC = " & Me.TxtCESC.Text & vbCrLf
            Sql &= ", @VALOR_EXENTO = " & Me.txtExento.Text & vbCrLf
            If Proc.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                Correo()
            End If
            'JASC
            If IUD = "U" Then
                Dim comando1 As New SqlCommand("update CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO set PORCENTAJE_PERCEPCION = " & WPercepcion & " where COMPAÑIA =  " & Compañia & " and ORDEN_COMPRA = " & OrdenCompra)
                Proc.ejecutarComandoSql(comando1)
            End If
            Select Case IUD
                Case "I"
                    MsgBox("¡Orden de Compra almacenada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡Orden de Compra actualizada con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("¡Orden de Compra eliminada con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_OCAutorizacion(ByVal Compañia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD, ByVal Descuento)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Autorizada
            Sql &= ", " & Anulada
            Sql &= ", " & SubTotal
            Sql &= ", " & IVA
            Sql &= ", " & Total
            Sql &= ", " & Percepcion
            Sql &= ", " & TotalCompra
            Sql &= ", '" & Comentario & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= "," & 0
            Sql &= ", " & Descuento
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
            Dim comando1 As New SqlCommand("update CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO set subtotal = " & SubTotal & _
            ",  iva = " & IVA & " , total = " & Total & ", percepcion = " & Percepcion & " , renta = " & 0 & _
            ", total_final = " & TotalCompra & " , PORCENTAJE_PERCEPCION = " & WPercepcion & " where COMPAÑIA =  " & Compañia & " and ORDEN_COMPRA = " & OrdenCompra)
            Proc.ejecutarComandoSql(comando1)
            'MsgBox("¡Orden de Compra Procesada con éxito!", MsgBoxStyle.Information, "Mensaje")
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

    Private Sub Correo()
        'clase para enviar correos
        Try
            Dim sendMail As New EnviarCorreo
            Sql = "SELECT REQUISICION, " & vbCrLf
            Sql &= "      (SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_CREA_SOLICITA) AS SOLICITANTE, " & vbCrLf
            Sql &= "      (SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_CREA_SOLICITA) AS CORREO_SOLICITANTE, " & vbCrLf
            Sql &= "      (SELECT NOMBRE_USUARIO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_REVISA) AS AUTORIZADOR," & vbCrLf
            Sql &= "      (SELECT CORREO_ELECTRONICO FROM CATALOGO_USUARIOS WHERE COMPAÑIA = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.COMPAÑIA AND USUARIO = CONTABILIDAD_ORDEN_COMPRA_REQUISICION.USUARIO_REVISA) AS CORREO_AUTORIZADOR," & vbCrLf
            Sql &= "       FECHA_SOLICITA" & vbCrLf
            Sql &= "  FROM CONTABILIDAD_ORDEN_COMPRA_REQUISICION WHERE COMPAÑIA = " & Compañia & " AND ORDEN_GENERADA LIKE '%" & Me.txtOC.Text & "%'" & vbCrLf
            Dim tblDatosReq As DataTable = Proc.obtenerDatos(New SqlCommand(Sql))
            'para el autorizador requisiciones
            sendMail.Enviar(tblDatosReq.Rows(0).Item("CORREO_AUTORIZADOR"), _
                            IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                            "Orden de Compra No. " & Me.txtOC.Text & " Finalizada (Req.#" & tblDatosReq.Rows(0).Item("REQUISICION") & ")", _
                            "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                            "Procesado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                            "Usuario Solicitante: <strong>" & tblDatosReq.Rows(0).Item("SOLICITANTE") & "</strong><br />" & _
                            "Bodega Solicitante: <strong>" & Me.cmbBODEGA.Text & "</strong><br />" & _
                            "Producto requeridos para el <strong><u>" & CDate(tblDatosReq.Rows(0).Item("FECHA_SOLICITA")).ToLongDateString() & "</u></strong><br /><br />" & _
                            "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>PENDIENTE AUTORIZACION DE GERENCIA</strong><p></div>")

            'para el solicitante
            sendMail.Enviar(tblDatosReq.Rows(0).Item("CORREO_SOLICITANTE"), _
                            IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                            "Orden de Compra No. " & Me.txtOC.Text & " Finalizada (Req.#" & tblDatosReq.Rows(0).Item("REQUISICION") & ")", _
                            "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                            "Procesado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                            "Req. Autorizada por: <strong>" & tblDatosReq.Rows(0).Item("AUTORIZADOR") & "</strong><br />" & _
                            "Producto requeridos para el <strong><u>" & CDate(tblDatosReq.Rows(0).Item("FECHA_SOLICITA")).ToLongDateString() & "</u></strong><br /><br />" & _
                            "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>PENDIENTE AUTORIZACION DE GERENCIA</strong><p></div>")

            'para el autorizador orden compra
            sendMail.Enviar(Proc.obtenerEscalar("SELECT CORREO_AUTORIZAOC FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue), _
                            IIf(Correo_Usuario.Length = 0, "soporte@astas.com.sv", Correo_Usuario), _
                            "Orden de Compra No. " & Me.txtOC.Text & " FINALIZADA (Req.#" & tblDatosReq.Rows(0).Item("REQUISICION") & ")", _
                            "<div style=" & Chr(34) & "font-family: Courier New;font-size: 12pt; color: Navy;" & Chr(34) & ">" & _
                            "Procesado por: <strong>" & Nombre_Usuario & "</strong><br />" & _
                            "Usuario Solicitante: <strong>" & tblDatosReq.Rows(0).Item("SOLICITANTE") & "</strong><br />" & _
                            "Bodega Solicitante: <strong>" & Me.cmbBODEGA.Text & "</strong><br />" & _
                            "Requisición Autorizada por: <strong>" & tblDatosReq.Rows(0).Item("AUTORIZADOR") & "</strong><br />" & _
                            "Producto requeridos para el <strong><u>" & CDate(tblDatosReq.Rows(0).Item("FECHA_SOLICITA")).ToLongDateString() & "</u></strong><br /><br />" & _
                            "<p style=" & Chr(34) & "font-family: Courier New;font-size: 14pt; color: Brown;" & Chr(34) & "><strong>PENDIENTE AUTORIZACION DE GERENCIA</strong><p></div>")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiaCamposOC()
        Iniciando = True
        Me.txtOC.Text = "0"
        Me.lblMensaje.Visible = False
        Me.lblMensaje.Text = ""
        Me.dgvDetalleOC.DataSource = Nothing
        Me.txtOBSERVACIONES.Text = ""
        LimpiaCamposProveedor()
        LimpiaCamposProducto()
        'Me.TxtTotalDet.Text = "0.00"
        'Me.txtDescuentoGlobal.Text = "0.00"
        'Me.Txt_Descuento.Text = "0.00"
        'Me.TxtporDescTotal.Text = "0.00"
        Me.txtSubTotal.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotal.Text = "0.00"
        Me.txtPercepcion.Text = "0.00"
        Me.txtTotalFact.Text = "0.00"
        Me.cmbTipoDocumento.SelectedValue = 2
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
        Me.Txt_PorDescto.Text = ""
        Me.Txt_ValDescto.Text = ""
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
        Me.chkBono.Checked = False
        bonificacion = 0
        Accion = "I"
        Linea = 0
        'If dgvDetalleOC.RowCount = 0 Then
        '    TxtporDescTotal.Text = 0
        '    txtDescuentoGlobal.Text = 0
        'End If
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

    Private Sub Deshabilita(ByVal Bandera)
        'Me.lblMensaje.Visible = Not Bandera
        Me.GrbProveedor.Enabled = Bandera
        Me.btnGuardarDetalle.Enabled = Bandera
        Me.btnGuardarEncabezado.Enabled = Bandera
        Me.BtnBuscar.Enabled = Bandera
        Me.btnProcesar.Enabled = Bandera
        Me.miMenu_Eliminar.Enabled = Bandera
        Me.bntEliminar.Enabled = Bandera
    End Sub

    Private Function ValidaCamposEncabezado() As Boolean
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra no puede ser guardada, ya está Procesada!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            MsgBox("¡Código de Proveedor no es válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("¡Proveedor No posee un Nombre Legal definido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("¡Proveedor No posee NIT.! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbBODEGA.Text = "" Then
            MsgBox("¡Debe seleccionar Bodega!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
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
        'JASC21082013
        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 And bonificacion = 0 Then
            MsgBox("¡El costo unitario es menor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
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
            MsgBox("¡Debe seleccionar un Proveedor válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un Nombre Legal válido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("¡Debe seleccionar un Proveedor con un NIT válido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deberá hacerlo en Catálogo de Proveedores.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtTotalFact.Text = "0.00" Then
            MsgBox("¡La Orden de Compra no puede ser procesada con monto $0.00! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
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
        If MsgBox("Guardar los datos generales de la Orden de Compra?", MsgBoxStyle.YesNo, "GUARDAR") = MsgBoxResult.Yes Then
            If ValidaCamposEncabezado() = True Then
                Dim IUD As String
                If Me.txtOC.Text = "0" Then
                    Me.txtOC.Text = GeneraCorrelativo(Me.cmbCOMPAÑIA.SelectedValue, "OC").ToString
                    IUD = "I"
                Else
                    IUD = "U"
                End If
                Mantenimiento_Encabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 0, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, WPercepcion, Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), IUD)
                CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
                If Me.lblMensaje.Visible = True Then
                    HabilitaDeshabilita(False)
                End If
            End If
        End If
    End Sub

    Private Sub btnLimpiarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarOC.Click
        LimpiaCamposOC()
        HabilitaDeshabilita(True)
        Deshabilita(True)
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Me.btnGuardarEncabezado.PerformClick()
        If ValidaCamposLinea() = True Then
            'Busca la descripcion y unidad de medida del producto.
            BuscarProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            'Ingresa el detalle a la tabla de detalles
            Mantenimiento_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.txtCANTIDAD.Text, Val(Me.Txt_PorDescto.Text), Me.txtCOSTO_UNITARIO.Text, "0", "U3", bonificacion)
            'Muestra el detalle de la oc en el grid
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            'Calcula los totales de las cajas de texto.
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
            Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)
            LimpiaCamposProducto()
            'jasc23082013
            'TxtporDescTotal.Enabled = True
            'txtDescuentoGlobal.Enabled = True
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
        If Val(Me.txtOC.Text) > 0 Then
            If MsgBox("Al dar Finalizada la Orden pasará para Autorización. Continuar?", MsgBoxStyle.YesNo, "FINALIZA") = MsgBoxResult.Yes Then
                Mantenimiento_Encabezado(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 1, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, Me.lblPORCENTAJE_PERCEPCION.Text, Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), "U") 'Val(Me.TxtporDescTotal.Text), Val(Me.txtDescuentoGlobal.Text))

                Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 0, 0, Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)

                'JASC II
                btnGuardarEncabezado.Enabled = False
            End If
        Else
            MsgBox("No hay Orden de Compra a enviar para Autorizar.", MsgBoxStyle.Exclamation, "AVISO")
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.txtOC.Text <> "0" Then
            If MsgBox("Imprimir Orden de Compra?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
                If Me.txtSubTotal.Text <> "0.00" Then
                    Rpts.CargaOC(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text)
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
                MessageBox.Show("Ingrese el Codigo del Producto...", "ASTAS", MessageBoxButtons.OK)
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
        'CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
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
                MessageBox.Show("Debe de Digitar Bien el codigo del Empleador", "ASTAS", MessageBoxButtons.OK)
                Me.TxtProveedor_Codigo.Focus()
            Else
                txtPRODUCTO.Focus()
            End If
        End If
    End Sub

    Private Sub TxtProveedor_Codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.LostFocus
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub TxtProveedor_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.TextChanged
        If Not IsNumeric(TxtProveedor_Codigo.Text) Then
            TxtProveedor_Codigo.Text = ""
            TxtProveedor_Codigo.Focus()
        Else
            If Me.TxtProveedor_Codigo.Text <> "" Then
                Try
                    Dim Sql As String
                    Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
                    Sql = Sql & " WHERE COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text

                    Dim Conexion_Track As New SqlConnection
                    Dim Comando_Track As SqlCommand
                    Dim DataAdapter As SqlDataAdapter
                    Dim DS As New DataSet()

                    Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                    Try
                        Conexion_Track.Open()
                        Comando_Track = New SqlCommand(Sql, Conexion_Track)
                        DataAdapter = New SqlDataAdapter(Comando_Track)
                        'DS = New DataTable("Datos")
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
            Me.Txt_PorDescto.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(6).Value
            Me.Txt_ValDescto.Text = Math.Round(Val(Me.txtCOSTO_TOTAL.Text) * (Val(Me.Txt_PorDescto.Text)) / 100, 2)
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
            Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)
        End If
    End Sub

    Private Sub btnEliminarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro de eliminar Toda la Orden de Compra No. " & Me.txtOC.Text & " completamente?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                'JASC21082013
                Mantenimiento_Detalle(Compañia, Me.txtOC.Text, Me.dgvDetalleOC.Rows(i).Cells("Línea").Value, 0, "", 0, 0, 0, 0, 0, "D", 0)
            Next
            Mantenimiento_Encabezado(Compañia, Me.txtOC.Text, Format(Now, "dd-MM-yyyy HH:mm:ss"), 0, 0, 0, 0, 0, 0, 0, "", "D") ', 0, 0)
            Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "D", 0)
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
        'If Not IsNumeric(txtPRODUCTO.Text) Then
        '    txtPRODUCTO.Text = ""
        '    txtPRODUCTO.Focus()
        'Else
        '    If Linea = 0 Then
        '        BuscarProducto(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
        '    End If
        'End If
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
                Me.Txt_PorDescto.Focus()
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
                Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)
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
                Me.Txt_PorDescto.Focus()
            End If
            If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
                e.KeyChar = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Debe ingresar un Costo Unitario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub Txt_PorDescto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PorDescto.KeyPress
        Dim cadena As String = Me.Txt_PorDescto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Val(Me.Txt_PorDescto.Text) = 0 Then
                Me.Txt_ValDescto.Focus()
            Else
                Me.Txt_ValDescto.Text = Math.Round((Val(Me.txtCOSTO_TOTAL.Text) * Val(Me.Txt_PorDescto.Text)) / 100, 2)
                Me.btnGuardarDetalle.Focus()
            End If
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If

    End Sub

    Private Sub Txt_ValDescto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ValDescto.KeyPress
        Dim cadena As String = Me.Txt_ValDescto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If (Val(Me.Txt_ValDescto.Text) > 0) And (Val(txtCOSTO_TOTAL.Text) > 0) Then
                Txt_PorDescto.Text = Math.Round((Val(Txt_ValDescto.Text) / Val(txtCOSTO_TOTAL.Text)) * 100, 2)
            Else
                Txt_PorDescto.Text = 0
            End If
            Me.btnGuardarDetalle.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If

    End Sub


    Private Sub chkBono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBono.Click
        If chkBono.Checked = True Then
            bonificacion = 1
        Else
            bonificacion = 0
        End If

    End Sub

    'Private Sub TxtporDescTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtporDescTotal.KeyPress
    '    'JASC23082013
    '    Dim cadena As String = Me.TxtporDescTotal.Text
    '    Dim Ocurrencias As Byte = 0
    '    Dim str As String() = cadena.Split(".")
    '    For I As Integer = 0 To str.Length - 1
    '        Ocurrencias = Ocurrencias + 1
    '    Next
    '    Ocurrencias = Ocurrencias - 1
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        If Val(Me.TxtporDescTotal.Text) = 0 Then
    '            Me.txtDescuentoGlobal.Focus()
    '        Else
    '            Me.txtDescuentoGlobal.Text = Math.Round(Math.Round((CDbl(Me.txtSubTotal.Text) * CDbl(Me.TxtporDescTotal.Text)), 2) / 100, 2)
    '            Me.btnGuardarEncabezado.PerformClick()
    '            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
    '            'EAGP 25/02/2014
    '            'Actualiza los costos unitarios en base al descuento general
    '            Mantenimiento_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.TxtporDescTotal.Text, Val(Me.Txt_PorDescto.Text), Me.txtCOSTO_UNITARIO.Text, "0", "U2", bonificacion)
    '            'Actualiza el datagrid de los detalles
    '            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
    '            'Actualiza los totales del documento del lado derecho de la ventana
    '            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
    '            'Envia la orden para autorizacion
    '            Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", Me.Txt_Descuento.Text)
    '        End If
    '    End If
    '    If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
    '        e.KeyChar = Nothing
    '    End If
    'End Sub

    'Private Sub txtDescuentoGlobal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoGlobal.KeyPress
    '    'JASC23082013
    '    Dim cadena As String = Me.txtDescuentoGlobal.Text
    '    Dim Ocurrencias As Byte = 0
    '    Dim str As String() = cadena.Split(".")
    '    For I As Integer = 0 To str.Length - 1
    '        Ocurrencias = Ocurrencias + 1
    '    Next
    '    Ocurrencias = Ocurrencias - 1
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        If (Val(Me.txtDescuentoGlobal.Text) > 0) And (Val(Me.txtSubTotal.Text) > 0) Then
    '            TxtporDescTotal.Text = Math.Round((Me.txtDescuentoGlobal.Text / Me.TxtTotalDet.Text) * 100, 2)
    '            Me.btnGuardarEncabezado.PerformClick()
    '            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
    '            Mantenimiento_OCAutorizacion(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", Me.Txt_Descuento.Text)
    '        Else
    '            TxtporDescTotal.Text = 0
    '        End If
    '        Me.btnGuardarDetalle.Focus()
    '    End If
    '    If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
    '        e.KeyChar = Nothing
    '    End If

    'End Sub

    'JASC II
    Private Sub Contabilidad_OrdenCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F3 Then
            Me.btnBuscarProducto.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub Contabilidad_OrdenCompra_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
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

            ' return filtered dt            
            Me.dgvProductos.DataSource = tablaT
        End If
    End Sub
    Private Function validarproducto(ByVal producto) As Boolean
        Dim respuesta As Boolean = True
        Dim sqlCmdProd As New SqlCommand

        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & producto.ToString
        sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = sql
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
        sql = " Execute dbo.sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
        sql &= Me.cmbCOMPAÑIA.SelectedValue.ToString
        sql &= ", " & Me.cmbBODEGA.SelectedValue.ToString
        sql &= ", " & codProducto
        sql &= ", '0', 0, 2"
        sqlCmdProd.CommandText = sql
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

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If Val(Me.txtOC.Text) > 0 Then
            If MsgBox("Desea Anular la Orden?", MsgBoxStyle.YesNo, "AVISO") = MsgBoxResult.Yes Then
                Try
                    Dim _comentario_anular As String = String.Empty
                    Dim _frm_coment As New Contabilidad_OrdenCompra_ComentariosAnular()

                    _frm_coment.ShowDialog()
                    _comentario_anular = _frm_coment._comentarios
                    _frm_coment.Dispose()

                    If _comentario_anular.Trim().Length > 0 Then
                        Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
                        Sql &= Compañia
                        Sql &= ", " & Me.txtOC.Text
                        Sql &= ", 0" 'Autorizada
                        Sql &= ", 1" 'Anulada
                        Sql &= ", 0" ' SubTotal
                        Sql &= ", 0" ' IVA
                        Sql &= ", 0" ' Total
                        Sql &= ", 0" ' Percepcion
                        Sql &= ", 0" ' TotalCompra
                        Sql &= ", '" & _comentario_anular & "'"
                        Sql &= ", '" & Usuario & "'"
                        Sql &= ", 'U'"
                        Sql &= ", 0" 'Renta
                        Sql &= ", 0" 'Descuento
                        If Proc.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                            MsgBox("Orden de Compra Anulada con éxito.", MsgBoxStyle.Information, "Anular Orden de Compra")
                        Else
                            MsgBox("Orden de compra sin cambios.", MsgBoxStyle.Information, "Anular Orden de Compra")
                        End If
                        btnAnular.Enabled = False
                        btnGuardarEncabezado.Enabled = False
                    Else
                        MsgBox("Ingrese un comentario para continuar!", MsgBoxStyle.Information, "Anular Orden de Compra")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try

            End If
        Else
            MsgBox("No hay Orden de Compra para Anular.", MsgBoxStyle.Exclamation, "AVISO")
        End If
    End Sub

    Private Sub btnFinRecepción_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinRecepción.Click
        Dim cuantos As Integer
        Dim comentar As String = String.Empty
        cuantos = Proc.obtenerEscalar("SELECT COUNT(ORDEN_COMPRA) FROM CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & Me.txtOC.Text & " AND CANTIDAD_PENDIENTE > 0")
        If cuantos > 0 Then
            If MsgBox("¿Desea finalizar la recepción de productos al inventario de la Orden de Compra #" & Me.txtOC.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Recibir Compras") = MsgBoxResult.Yes Then
                Dim frmcomentario As New Contabilidad_OrdenCompra_ComentariosAnular()
                frmcomentario.ShowDialog()
                comentar = frmcomentario.txtComentariosAnular.Text
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.txtOC.Text & ", @BANDERA = 7, @COMENTARIOS = '" & comentar & "'"
                If Proc.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                    Me.txtOBSERVACIONES.Text &= IIf(Me.txtOBSERVACIONES.Text.Length > 0, ". ", "") & comentar
                    MsgBox("Proceso finalizado" & vbCrLf & "Ya no se podrán recibir más items al inventario de la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
                Else
                    MsgBox("Proceso bloqueado" & vbCrLf & "No se pudo modificar la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
                End If
            End If
        Else
            MsgBox("No hay productos pendientes de recibir de la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
        End If
    End Sub

    Private Sub txtOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOC.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtOC_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOC.LostFocus
        If Me.txtOC.Text.Length > 0 Then
            If Not Proc.obtenerEscalar("SELECT AFECTAR_INVENTARIOS FROM CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & Me.txtOC.Text) Then
                MsgBox("La orden de compra no aplica para esta ventana" & vbCrLf & "Use la opción Orden de Compra - Sin Afectar Inventarios", MsgBoxStyle.Information, "Validación")
                Return
            End If
            BuscarOC(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle_Total(Me.cmbCOMPAÑIA.SelectedValue, Me.txtOC.Text, 2)
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("¡La Orden de Compra ya está Autorizada!" & Chr(13) & "No podrá realizar cambios.", MsgBoxStyle.Critical, "Mensaje")
            HabilitaDeshabilita(False)
        Else
            HabilitaDeshabilita(True)
        End If
    End Sub

    Private Sub On_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged, txtIVA.TextChanged, txtPercepcion.TextChanged, TxtCESC.TextChanged, txtExento.TextChanged
        Me.txtTotal.Text = Format(Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.txtIVA.Text.Replace(",", "")), "#,##0.00")
        Me.txtTotalFact.Text = Format(Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.txtIVA.Text.Replace(",", "")) + Val(Me.txtPercepcion.Text.Replace(",", "")) + Val(Me.TxtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")), "#,##0.00")
    End Sub
End Class
