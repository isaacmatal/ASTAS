Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_No_Inventarios
    Dim Sql As String
    Dim Iniciando, CargaDetalle As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim Accion As String = "I"
    Dim Linea As Integer = 0
    Dim IVA, WPercepcion, Percepcion, PorcRenta, porcRentaInt As Double
    Dim Proc As New jarsClass
    Dim bonificacion As Integer
    Dim intFindProveedor As Integer = 0

    Private Sub Contabilidad_OrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaTipoDocumento(Compa�ia)
        CargaBodegas(Me.cmbCOMPA�IA.SelectedValue, 4)
        CargaTipoContribuyente(Me.cmbCOMPA�IA.SelectedValue, 1)
        CargaFormaPago(Me.cmbCOMPA�IA.SelectedValue, 1)
        CargaCondicionPago(Me.cmbCOMPA�IA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
        CargaUnidadMedida(Me.cmbCOMPA�IA.SelectedValue, 1)
        Me.cmbTipoDocumento.SelectedValue = 2
        Me.ChkQuitarPerc.Checked = False
        Iniciando = False        
        Me.CargaPorcentajeImpuestos(1)
        Me.CargaPorcentajeImpuestos(5)
        Me.CargaPorcentajeImpuestos(10)
    End Sub

    Private Sub CargaCompa�ia()
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", " & Compa�ia
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            Me.cmbCOMPA�IA.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compa�ia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA  =  " & Bandera & ", "
            Sql &= "@COMPA�IA =  " & Compa�ia & ", "
            Sql &= "@USUARIO  = '" & Usuario & "'"
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripci�n"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoContribuyente(ByVal Compa�ia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR "
            Sql &= Compa�ia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_TipoProveedor.DataSource = Table
            Me.CmbProveedor_TipoProveedor.ValueMember = "TIPO_PROVEEDOR"
            Me.CmbProveedor_TipoProveedor.DisplayMember = "DESCRIPCION_TIPO_PROVEEDOR"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaFormaPago(ByVal Compa�ia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO "
            Sql &= Compa�ia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_FormaPago.DataSource = Table
            Me.CmbProveedor_FormaPago.ValueMember = "Pago"
            Me.CmbProveedor_FormaPago.DisplayMember = "Descripci�n"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPorcentajeImpuestos(ByVal Constante As Integer)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONSTANTES "
            Sql &= Compa�ia
            Sql &= ", " & Constante
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            If Constante = 1 Then
                IVA = Table.Rows(0).Item(0)
            ElseIf Constante = 2 Then
                Percepcion = Table.Rows(0).Item(0)
            ElseIf Constante = 5 Then
                PorcRenta = Table.Rows(0).Item(0)
            ElseIf Constante = 10 Then 'Intangibles
                porcRentaInt = Table.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCondicionPago(ByVal Compa�ia, ByVal FormaPago, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CONDICION_PAGO "
            Sql &= Compa�ia
            Sql &= ", " & FormaPago
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.CmbProveedor_CondicionPago.DataSource = Table
            Me.CmbProveedor_CondicionPago.ValueMember = "Condici�n Pago"
            Me.CmbProveedor_CondicionPago.DisplayMember = "Descripci�n Pago"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUnidadMedida(ByVal Compa�ia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compa�ia
            Sql &= ", " & Bandera
            Table = Proc.obtenerDatos(New SqlCommand(Sql))
            Me.cmbUNIDAD_MEDIDA.DataSource = Table
            Me.cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            Me.cmbUNIDAD_MEDIDA.DisplayMember = "Descripci�n Unidad"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle(ByVal Compa�ia, ByVal OrdenCompra, ByVal Bandera)
        Dim Table As DataTable
        CargaDetalle = True
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE"
            Sql &= " @COMPA�IA = " & Compa�ia
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

    Private Sub CargaOC_Detalle_Total(ByVal Compa�ia, ByVal OrdenCompra, ByVal Bandera)
        Dim Descuento, SubTotal, conIVA, Percibido, Renta, Servicios As Double
        Dim SubTotal_Inicial, subtotal1, subtotal2 As Double
        Dim Intangibles As Double
        Dim rentaInt As Double
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
            'Descuento += subtotal1 * (Me.dgvDetalleOC.Rows(i).Cells(13).Value / 100)
            'SubTotal_Inicial += (subtotal1 / (1 - (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100)))
            'subtotal2 = (subtotal1 / (1 - (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100)))
            'Descuento += (subtotal2 * (Me.dgvDetalleOC.Rows(i).Cells(6).Value / 100))
            'SubTotal += subtotal1
            If Me.dgvDetalleOC.Rows(i).Cells("SERVICIO").Value Then
                Servicios += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            End If
        Next

        'JASC
        'Me.TxtTotalDet.Text = (Math.Round(SubTotal_Inicial, 2)).ToString("#,##0.00")

        'SubTotal = Math.Round(SubTotal - Descuento, 2)

        'Me.Txt_Descuento.Text = (Descuento).ToString("#,##0.00")
        Me.txtSubTotal.Text = Format(SubTotal, "#,##0.00")

        'INICIO EAGP 2014
        For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
            If Me.dgvDetalleOC.Rows(i).Cells("INTANGIBLE").Value Then
                Intangibles += Me.dgvDetalleOC.Rows(i).Cells(8).Value
            End If
        Next

        '============================================================='
        'Julio Galeas 2016/Marzo/18        
        If Me.TxtProveedor_Codigo.Text.Length > 0 Then
            Me.EstadoProveedor(Compa�ia, Me.TxtProveedor_Codigo.Text)
            Renta = 0.0

            'Persona Natural y son Servicios o Intangibles aplica el 10% de Renta
            If CInt(Me.lblProveedorEstado.Text) = 1 Then
                If Servicios > 0 Then
                    Renta = Servicios * (PorcRenta / 100)
                End If

                If Intangibles > 0 Then
                    rentaInt = Intangibles * (PorcRenta / 100)
                    Renta = Renta + rentaInt
                End If
            End If
          
            'Proveedor como Persona Juridica y es Intangible procede el 5%
            If CInt(Me.lblProveedorEstado.Text) = 2 And Intangibles > 0 Then
                Renta = Intangibles * (Me.porcRentaInt / 100)
            End If
        End If
        '============================================================='

        If Me.cmbTipoDocumento.SelectedValue = 2 Then
            conIVA = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (IVA / 100), 2)
            Me.txtIVA.Text = conIVA.ToString("#,##0.00")
            Me.txtTotal.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA).ToString("#,##0.00")

            'JASC II
            'Solamente para compras mayores a $100 se realizar� percepci�n (o igual a $100 segun dijeron despues).
            If SubTotal >= 100 And CmbProveedor_TipoProveedor.SelectedValue = 3 Then
                Percibido = Math.Round(Val(Me.txtSubTotal.Text.Replace(",", "")) * (1 / 100), 2)
                Me.txtPercepcion.Text = Percibido.ToString("#,##0.00")
                Me.txtRenta.Text = Renta.ToString("#,##0.00")
                If ChkQuitarPerc.Checked = False Then
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA + Percibido - Renta + Val(Me.txtCESC.Text) + Val(Me.txtExento.Text)).ToString("#,##0.00")
                Else
                    Me.txtPercepcion.Text = "0.00"
                    Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA - Renta + Val(Me.txtCESC.Text) + Val(Me.txtExento.Text)).ToString("#,##0.00")
                End If
            Else
                Percibido = 0.0
                Me.txtPercepcion.Text = "0.00"
                Me.txtRenta.Text = Renta.ToString("#,##0.00")
                Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) + conIVA - Renta + Val(Me.txtCESC.Text) + Val(Me.txtExento.Text)).ToString("#,##0.00")
            End If
        Else
            Me.txtIVA.Text = "0.00"
            Me.txtTotal.Text = Val(Me.txtSubTotal.Text.Replace(",", "")).ToString("#,##0.00")
            Me.txtPercepcion.Text = "0.00"
            Me.txtRenta.Text = Renta.ToString("#,##0.00")
            Me.txtTotalFact.Text = (Val(Me.txtSubTotal.Text.Replace(",", "")) - Renta + Val(Me.txtCESC.Text) + Val(Me.txtExento.Text)).ToString("#,##0.00")
        End If

    End Sub

    Private Sub LimpiaGrid()
        Me.dgvDetalleOC.Columns(0).Width = 50 'L�nea
        Me.dgvDetalleOC.Columns(1).Width = 80 'Cod Producto
        Me.dgvDetalleOC.Columns(2).Width = 260 'Descripci�n
        Me.dgvDetalleOC.Columns(3).Width = 50 'Cod UM
        Me.dgvDetalleOC.Columns(4).Width = 80 'Unidad Medida
        Me.dgvDetalleOC.Columns(5).Width = 70 'Cantidad
        Me.dgvDetalleOC.Columns(6).Width = 70 '% Descuento
        Me.dgvDetalleOC.Columns(7).Width = 70 'Costo Unit
        Me.dgvDetalleOC.Columns(8).Width = 70 'Sub Total
        Me.dgvDetalleOC.Columns(9).Width = 70 'Con IVA
        Me.dgvDetalleOC.Columns(11).Width = 60 'Percepcion
        Me.dgvDetalleOC.Columns(12).Width = 70 'Percepcion
        Me.dgvDetalleOC.Columns(14).Width = 200 'Comentarios

        Me.dgvDetalleOC.Columns(0).Visible = False 'L�nea
        Me.dgvDetalleOC.Columns(1).Visible = False 'Cod Producto
        Me.dgvDetalleOC.Columns(3).Visible = False 'Cod UM
        Me.dgvDetalleOC.Columns(9).Visible = False 'Libras
        Me.dgvDetalleOC.Columns(10).Visible = False 'Percepcion
        Me.dgvDetalleOC.Columns(11).Visible = True 'Servicio
        Me.dgvDetalleOC.Columns(12).Visible = True 'Intangible
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
        Me.dgvDetalleOC.Columns.Item(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvDetalleOC.Columns.Item(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BuscarOC(ByVal Compa�ia, ByVal OrdenCompra, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Procesada As Boolean = False
        Dim DataReader_ As SqlDataReader
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO "
            Sql &= Compa�ia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Me.cmbBODEGA.SelectedValue = DataReader_.Item("BODEGA")
                'Me.lblMensaje.Visible = DataReader_.Item("PROCESADA")
                'If DataReader_.Item("PROCESADA") = True Then
                '    'DeshabilitarCampos Todos
                '    Me.lblMensaje.Text = "OC FINALIZADA"
                '    Deshabilita(False)
                'Else
                '    Deshabilita(True)
                'End If
                Me.dpFECHA_OC.Value = DataReader_.Item("FECHA_ORDEN_COMPRA")
                Me.TxtProveedor_Codigo.Text = DataReader_.Item("PROVEEDOR")
                Me.TxtProveedor_NombreLegal.Text = DataReader_.Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = DataReader_.Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = DataReader_.Item("NRC")
                Me.TxtProveedor_Nit.Text = DataReader_.Item("NIT")
                Me.TxtProveedor_Direccion.Text = DataReader_.Item("DIRECCION")
                Me.CmbProveedor_TipoProveedor.SelectedValue = DataReader_.Item("TIPO_CONTRIBUYENTE")
                Me.CmbProveedor_FormaPago.SelectedValue = DataReader_.Item("FORMA_PAGO")
                Me.CmbProveedor_CondicionPago.SelectedValue = DataReader_.Item("CONDICION_PAGO")
                Me.txtOBSERVACIONES.Text = DataReader_.Item("OBSERVACIONES")
                Me.cmbTipoDocumento.SelectedValue = DataReader_.Item("TIPO_DOCUMENTO")
                Me.txtCESC.Text = DataReader_.Item("CESC")
                Me.txtExento.Text = DataReader_.Item("VALOR_EXENTO")
                Procesada = DataReader_.Item("PROCESADA")
                WPercepcion = DataReader_.Item("PORCENTAJE_PERCEPCION")
                If WPercepcion = 0 Then
                    Me.ChkQuitarPerc.Checked = True
                Else
                    Me.ChkQuitarPerc.Checked = False
                End If
                Sql = "SELECT ISNULL(ANULADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                Sql &= " COMPA�IA= " & Compa�ia
                Sql &= " AND "
                Sql &= " ORDEN_COMPRA= " & OrdenCompra
                Dim Anulada As Boolean = Proc.obtenerEscalar(Sql)
                If Not Anulada Then

                    Sql = "SELECT ISNULL(AUTORIZADA,0) FROM CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES WHERE "
                    Sql &= " COMPA�IA= " & Compa�ia
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
                Else
                    Me.lblMensaje.Visible = True
                    Me.lblMensaje.Text = "OdC ANULADA"
                    Deshabilita(False)
                End If
                HabilitaDeshabilita(False)
            Else
                HabilitaDeshabilita(True)
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProveedor(ByVal Compa�ia, ByVal Proveedor)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPA�IA = "
            Sql &= Compa�ia & " AND PROVEEDOR = " & Proveedor
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Me.TxtProveedor_NombreLegal.Text = DataReader_.Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = DataReader_.Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = DataReader_.Item("NRC")
                Me.TxtProveedor_Nit.Text = DataReader_.Item("NIT")
                Me.TxtProveedor_Direccion.Text = DataReader_.Item("DIRECCION")
                Me.CmbProveedor_TipoProveedor.SelectedValue = DataReader_.Item("TIPO_PROVEEDOR")
                Me.CmbProveedor_FormaPago.SelectedValue = DataReader_.Item("FORMA_PAGO")
                Me.CmbProveedor_CondicionPago.SelectedValue = DataReader_.Item("CONDICION_PAGO")
                Me.lblProveedorEstado.Text = DataReader_.Item("ESTADO")

                'If DataReader_.Item("TIPO_PROVEEDOR") = 3 Then
                '    Me.ChkQuitarPerc.Enabled = True
                'Else
                '    Me.ChkQuitarPerc.Enabled = False
                'End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarPorcentajePercepcion(ByVal Compa�ia, ByVal bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR "
            Sql &= Compa�ia
            Sql &= ", " & bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            While DataReader_.Read
                If Me.CmbProveedor_TipoProveedor.SelectedValue = DataReader_.Item("TIPO_PROVEEDOR") Then
                    Me.lblPORCENTAJE_PERCEPCION.Text = DataReader_.Item("PORCENTAJE_PERCEPCION")
                End If
            End While
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProducto(ByVal Compa�ia, ByVal Bodega, ByVal Producto)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Accion = "I"
        Linea = 0
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            Sql &= Compa�ia
            Sql &= ", " & Bodega
            Sql &= ", " & Producto
            Sql &= ", '' " 'Descripci�n del Producto
            Sql &= ", 0" 'C�digo de Grupo
            Sql &= ", 2" 'Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            LimpiaCamposProducto()
            If DataReader_.Read Then
                Me.txtPRODUCTO.Text = DataReader_.Item("PRODUCTO")
                Me.txtDESCRIPCION_PRODUCTO.Text = DataReader_.Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.SelectedValue = DataReader_.Item("UNIDAD_MEDIDA")
                Me.txtLIBRAS.Enabled = DataReader_.Item("UNIDAD_LIBRA")
                Me.chkSERVICIO.Checked = Not DataReader_.Item("SERVICIO")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Encabezado(ByVal Compa�ia, ByVal OrdenCompra, ByVal FechaOC, ByVal Procesada, ByVal Bodega, ByVal Proveedor, ByVal TipoContribuyente, ByVal PorcentajePercepcion, ByVal FormaPago, ByVal CondicionPago, ByVal Observaciones, ByVal IUD) ', ByVal pordesc, ByVal descuento)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_IUD " & vbCrLf
            Sql &= " @COMPA�IA               = " & Compa�ia & vbCrLf
            Sql &= ", @ORDEN_COMPRA          = " & OrdenCompra & vbCrLf
            Sql &= ", @PROCESADA             = " & Procesada & vbCrLf
            Sql &= ", @BODEGA                = " & Bodega & vbCrLf
            Sql &= ", @PROVEEDOR             = " & Proveedor & vbCrLf
            Sql &= ", @TIPO_CONTRIBUYENTE    = " & TipoContribuyente & vbCrLf
            Sql &= ", @PORCENTAJE_PERCEPCION = " & PorcentajePercepcion & vbCrLf
            Sql &= ", @FORMA_PAGO            = " & FormaPago & vbCrLf
            Sql &= ", @CONDICION_PAGO        = " & CondicionPago & vbCrLf
            Sql &= ", @OBSERVACIONES         = '" & Observaciones & "'" & vbCrLf
            Sql &= ", @USUARIO               = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD                   = '" & IUD & "'" & vbCrLf
            Sql &= ", @AFECTAR_INVENTARIOS   = 0" & vbCrLf
            Sql &= ", @TIPO_DOCUMENTO        = " & Me.cmbTipoDocumento.SelectedValue & vbCrLf
            Sql &= ", @RENTA                 = " & Me.txtRenta.Text.Replace(",", "") & vbCrLf
            Sql &= ", @IVA                   = " & Me.txtIVA.Text.Replace(",", "") & vbCrLf
            Sql &= ", @CESC                  = " & Me.txtCESC.Text & vbCrLf
            Sql &= ", @VALOR_EXENTO          = " & Me.txtExento.Text & vbCrLf
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
            'JASC
            If IUD = "U" Then
                Dim comando1 As New SqlCommand("update CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO set PORCENTAJE_PERCEPCION = " & WPercepcion & " where COMPA�IA =  " & Compa�ia & " and ORDEN_COMPRA = " & OrdenCompra)
                Proc.ejecutarComandoSql(comando1)
            End If
            Select Case IUD
                Case "I"
                    MsgBox("�Orden de Compra almacenada con �xito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("�Orden de Compra actualizada con �xito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("�Orden de Compra eliminada con �xito!", MsgBoxStyle.Information, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_OCAutorizacion(ByVal Compa�ia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD, ByVal Descuento)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD " & vbCrLf
            Sql &= Compa�ia & vbCrLf
            Sql &= ", " & OrdenCompra & vbCrLf
            Sql &= ", " & Autorizada & vbCrLf
            Sql &= ", " & Anulada & vbCrLf
            Sql &= ", " & SubTotal & vbCrLf
            Sql &= ", " & IVA & vbCrLf
            Sql &= ", " & Total & vbCrLf
            Sql &= ", " & Percepcion & vbCrLf
            Sql &= ", " & TotalCompra & vbCrLf
            Sql &= ", '" & Comentario & "'" & vbCrLf
            Sql &= ", '" & Usuario & "'" & vbCrLf
            Sql &= ", '" & IUD & "'" & vbCrLf
            Sql &= ", " & Me.txtRenta.Text.Replace(",", "") & vbCrLf
            Sql &= ", " & Descuento & vbCrLf
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
            Dim comando1 As New SqlCommand("update CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO set subtotal = " & SubTotal & _
            ",  iva = " & IVA & " , total = " & Total & ", percepcion = " & Percepcion & _
            ", total_final = " & TotalCompra & " WHERE COMPA�IA =  " & Compa�ia & " AND ORDEN_COMPRA = " & OrdenCompra)
            Proc.ejecutarComandoSql(comando1)
            'MsgBox("�Orden de Compra Procesada con �xito!", MsgBoxStyle.Information, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal Compa�ia, ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Servicio, ByVal IUD, ByVal bono, ByVal Intangible)
        Try
            'Renta
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD " & vbCrLf
            Sql &= Compa�ia & vbCrLf
            Sql &= ", " & OrdenCompra & vbCrLf
            Sql &= ", " & Linea & vbCrLf
            Sql &= ", " & Val(Producto) & vbCrLf
            Sql &= ", '" & IIf(Descripcion = "", 0, Descripcion) & "'" & vbCrLf
            Sql &= ", " & UnidadMedida & vbCrLf
            Sql &= ", " & Val(Cantidad) & vbCrLf
            Sql &= ", " & Libras & vbCrLf
            Sql &= ", " & Val(CostoUnitario) - Val(Val(CostoUnitario) * (Libras / 100)) & vbCrLf
            Sql &= ", " & Servicio & vbCrLf
            Sql &= ", '" & Usuario & "'" & vbCrLf
            Sql &= ", '" & IUD & "'" & vbCrLf
            Sql &= ", '" & bono & "', 0" & vbCrLf
            Sql &= ", " & Intangible & vbCrLf
            Proc.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCamposOC()
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
        Me.txtRenta.Text = "0.00"
        Me.txtPercepcion.Text = "0.00"
        Me.txtTotalFact.Text = "0.00"
        Me.cmbTipoDocumento.SelectedValue = 2
    End Sub

    Private Sub LimpiaCamposProveedor()
        Me.TxtProveedor_Codigo.Text = ""
        Me.TxtProveedor_NombreLegal.Text = ""
        Me.TxtProveedor_NombreComercial.Text = ""
        Me.TxtProveedor_RegistroFiscal.Text = ""
        Me.TxtProveedor_Nit.Text = ""
        Me.TxtProveedor_Direccion.Text = ""
        Me.ChkQuitarPerc.Checked = False

    End Sub

    Private Sub LimpiaCamposProducto()
        Me.txtPRODUCTO.Text = ""
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.txtCANTIDAD.Text = ""
        Me.txtLIBRAS.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.Txt_PorDescto.Text = ""
        Me.Txt_ValDescto.Text = ""
        txtCOSTO_TOTAL.Text = ""
        Me.chkSERVICIO.Checked = False
        Me.chkINTANGIBLE.Checked = False
        Me.txtPRODUCTO.Enabled = True
        Linea = 0
        Accion = "I"
    End Sub

    Private Function GeneraCorrelativo(ByVal Compa�ia, ByVal TipoDocumento) As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_COOPERATIVA_CORRELATIVOS_DOCUMENTOS "
            Sql &= Compa�ia
            Sql &= ", '" & TipoDocumento & "'"
            Sql &= ", 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("ULTIMO")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub HabilitaDeshabilita(ByVal Bandera)
        Me.cmbCOMPA�IA.Enabled = Bandera
        Me.cmbBODEGA.Enabled = Bandera
        Me.dpFECHA_OC.Enabled = Bandera
    End Sub

    Private Sub Deshabilita(ByVal Bandera)
        Me.lblMensaje.Visible = Not Bandera
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
            MsgBox("�La Orden de Compra no puede ser guardada pues ya est� Autorizada!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor con un Nombre Legal v�lido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deber� hacerlo en Cat�logo de Proveedores.", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor con un NIT v�lido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deber� hacerlo en Cat�logo de Proveedores.", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.cmbBODEGA.Text = "" Then
            MsgBox("�Debe seleccionar una Bodega v�lida!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ValidaCamposLinea() As Boolean
        If Me.txtOC.Text = "0" Then
            MsgBox("�Pimero debe guardar un n�mero de Orden de Compra v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.TxtProveedor_Codigo.Text = "" Then
            MsgBox("�Debe seleccionar un Proveedor v�lido para la Orden de Compra! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 Then
            MsgBox("�Debe seleccionar una Cantidad v�lida para el producto! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.txtLIBRAS.Enabled = True And Val(Trim(Me.txtLIBRAS.Text)) <= 0 Then
            MsgBox("�Debe seleccionar una Cantidad en Libras v�lida para el producto! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 Then
            MsgBox("�Debe seleccionar un Precio Unitario v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Function ValidaOC() As Boolean
        If Me.txtOC.Text = "0" Then
            MsgBox("�Debe generar un n�mero de Orden de Compra v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Codigo.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_NombreLegal.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor con un Nombre Legal v�lido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deber� hacerlo en Cat�logo de Proveedores.", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.TxtProveedor_Nit.Text) = "" Then
            MsgBox("�Debe seleccionar un Proveedor con un NIT v�lido! Verifique" & Chr(13) & "Para cambiar datos del Proveedor deber� hacerlo en Cat�logo de Proveedores.", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("�La Orden de Compra no puede ser guardada pues ya est� Autorizada!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCamposProveedor()
            CargaBodegas(Me.cmbCOMPA�IA.SelectedValue, 4)
            CargaTipoContribuyente(Me.cmbCOMPA�IA.SelectedValue, 1)
            CargaFormaPago(Me.cmbCOMPA�IA.SelectedValue, 1)
            CargaCondicionPago(Me.cmbCOMPA�IA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
            CargaUnidadMedida(Me.cmbCOMPA�IA.SelectedValue, 1)
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiaCamposProveedor()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Busqueda.CbxCompania.Enabled = False
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
            Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
            BuscarProveedor(Me.cmbCOMPA�IA.SelectedValue, Me.TxtProveedor_Codigo.Text)
        Else
            BuscarProveedor(0, 0)
            Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""

        Me.txtDESCRIPCION_PRODUCTO.Focus()
    End Sub

    Private Sub CmbProveedor_FormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor_FormaPago.SelectedIndexChanged
        If Iniciando = False Then
            CargaCondicionPago(Me.cmbCOMPA�IA.SelectedValue, Me.CmbProveedor_FormaPago.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
        Busqueda.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Busqueda.Bodega_Value = Me.cmbBODEGA.SelectedValue
        Busqueda.cmbBODEGA.Enabled = False
        Busqueda.BuscaTodos = True
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtPRODUCTO.Text = Producto
            BuscarProducto(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
            Producto = ""
        End If
    End Sub

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        LimpiaCamposProducto()
        Me.txtPRODUCTO.Focus()
    End Sub

    Private Sub btnGuardarEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEncabezado.Click
        If MsgBox("Guardar los Datos Generales de la Orden de Compra?", MsgBoxStyle.YesNo, "GUARDAR") = MsgBoxResult.Yes Then
            If ValidaCamposEncabezado() = True Then
                Dim IUD As String
                If Me.txtOC.Text = "0" Then
                    Me.txtOC.Text = GeneraCorrelativo(Me.cmbCOMPA�IA.SelectedValue, "OC").ToString
                    IUD = "I"
                Else
                    IUD = "U"
                End If
                Mantenimiento_Encabezado(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 0, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, WPercepcion, Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), IUD) ', Val(Me.TxtporDescTotal.Text), Val(Me.txtDescuentoGlobal.Text))
                CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
                'solo deshabilita la fecha y la bodega si la OC ya fue procesada
                If Me.lblMensaje.Visible = True Then
                    HabilitaDeshabilita(False)
                Else
                    HabilitaDeshabilita(True)
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
        Dim servicio As String
        Dim intangible As String
        Me.btnGuardarEncabezado.PerformClick()
        If ValidaCamposLinea() = True Then
            'Ingresa el detalle a la tabla de detalles
            If chkSERVICIO.Checked = False Then
                servicio = "0"
            Else
                servicio = "1"
            End If

            If chkINTANGIBLE.Checked = False Then
                intangible = "0"
            Else
                intangible = "1"
            End If

            Mantenimiento_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.txtCANTIDAD.Text, Val(Me.Txt_PorDescto.Text), Me.txtCOSTO_UNITARIO.Text, servicio, Accion, bonificacion, intangible)
            'Muestra el detalle de la oc en el grid
            CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
            'MUESTRA LOS TOTALES DE LOS DETALLES EN LAS CAJAS DE TEXTO
            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
            Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)

            If chkSERVICIO.Checked = True Or chkINTANGIBLE.Checked = True Then
                Mantenimiento_Encabezado(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 0, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, WPercepcion, Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), "U") ', Val(Me.TxtporDescTotal.Text), Val(Me.txtDescuentoGlobal.Text))
            End If

            LimpiaCamposProducto()
            ChkQuitarPerc.Enabled = True
            If Me.CmbProveedor_TipoProveedor.SelectedValue = 3 And Contribuyente < 3 Then
                ChkQuitarPerc.Enabled = True
            End If


            Me.txtPRODUCTO.Focus()
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
                Me.Txt_PorDescto.Focus()
            End If
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnBuscarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarOC.Click
        Dim Busqueda As New Contabilidad_BusquedaOrdenCompra
        Producto = ""
        Descripcion_Producto = ""
        Busqueda.Compa�ia_Value = Me.cmbCOMPA�IA.SelectedValue
        Busqueda.Bodega_Value = Me.cmbBODEGA.SelectedValue
        Busqueda.cmbCOMPA�IA.Enabled = False
        Busqueda.cbAfectanInventarios.Checked = False
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtOC.Text = Producto
            Me.cmbBODEGA.SelectedValue = Descripcion_Producto
            BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
            Producto = ""
            Descripcion_Producto = ""
        End If
        If Me.lblMensaje.Visible = True Then
            HabilitaDeshabilita(False)
            MsgBox("�La Orden de Compra ya est� Autorizada!" & Chr(13) & "No podr� realizar cambios.", MsgBoxStyle.Critical, "Mensaje")
        Else
            HabilitaDeshabilita(True)
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If Val(Me.txtOC.Text) > 0 Then
            'CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
            If MsgBox("Al dar Finalizada la Orden pasar� para Autorizaci�n. Continuar?", MsgBoxStyle.YesNo, "FINALIZA") = MsgBoxResult.Yes Then
                Mantenimiento_Encabezado(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss"), 1, Me.cmbBODEGA.SelectedValue, Me.TxtProveedor_Codigo.Text, Me.CmbProveedor_TipoProveedor.SelectedValue, Me.lblPORCENTAJE_PERCEPCION.Text, Me.CmbProveedor_FormaPago.SelectedValue, Me.CmbProveedor_CondicionPago.SelectedValue, Trim(Me.txtOBSERVACIONES.Text), "U") ', Val(Me.TxtporDescTotal.Text), Val(Me.txtDescuentoGlobal.Text))
                Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", Me.txtRenta.Text.Replace(",", ""))
                'Deshabilita(False)
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
                    Rpts.CargaOC(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text)
                    Rpts.ShowDialog()
                Else
                    MsgBox("No posee costos la Orden de Compra", MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            MsgBox("�Debe seleccionar una Orden de Compra v�lido!", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub txtPRODUCTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCANTIDAD.Focus()
        End If
    End Sub

    Private Sub txtPRODUCTO_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRODUCTO.LostFocus
        If Me.txtPRODUCTO.Text.Length > 0 Then
            BuscarProducto(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtPRODUCTO.Text)
        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMenu_Eliminar.Click
        Mantenimiento_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Me.dgvDetalleOC.CurrentRow.Cells("L�nea").Value, Me.dgvDetalleOC.CurrentRow.Cells("Producto").Value, "", 0, 0, 0, 0, 0, "D", 0, "0")
        LimpiaCamposProducto()
        CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
        CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
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
                txtDESCRIPCION_PRODUCTO.Focus()
            End If
        End If
    End Sub

    Private Sub TxtProveedor_Codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.LostFocus
        Me.txtDESCRIPCION_PRODUCTO.Focus()
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
                    Sql = Sql & " WHERE COMPA�IA = " & Compa�ia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text

                    Dim Conexion_Track As New SqlConnection
                    Dim Comando_Track As SqlCommand
                    Dim DataAdapter As SqlDataAdapter
                    'Dim DataReader As SqlDataReader
                    Dim DS As New DataSet()

                    Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                    Try
                        Conexion_Track.Open()
                        Comando_Track = New SqlCommand(Sql, Conexion_Track)
                        DataAdapter = New SqlDataAdapter(Comando_Track)
                        'DS = New DataTable("Datos")
                        DataAdapter.Fill(DS)
                        If DS.Tables(0).Rows.Count = 0 Then
                            MsgBox("�No se encontr� ningun proveedor!", MsgBoxStyle.Question, "Mensaje")
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
            Me.chkSERVICIO.Checked = dgvDetalleOC.Rows(e.RowIndex).Cells(11).Value
            Me.chkINTANGIBLE.Checked = Me.dgvDetalleOC.Rows(e.RowIndex).Cells(12).Value
            Me.Txt_PorDescto.Text = dgvDetalleOC.Rows(e.RowIndex).Cells(6).Value
            Me.Txt_ValDescto.Text = Math.Round(Val(Me.txtCANTIDAD.Text) * Val(Me.txtCOSTO_UNITARIO.Text) * (Val(Me.Txt_PorDescto.Text)) / 100, 2)
            Me.txtPRODUCTO.Enabled = False
            Me.txtCANTIDAD.Focus()
        Else
            CargaDetalle = False
            Accion = "I"
        End If
    End Sub

    Private Sub bntEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntEliminar.Click
        If MsgBox("�Est� seguro de Eliminar el Producto: " & vbCrLf & Me.txtDESCRIPCION_PRODUCTO.Text.Trim & "?", MsgBoxStyle.YesNo, "ELIMINAR ITEM") = MsgBoxResult.Yes Then
            If txtDESCRIPCION_PRODUCTO.Text = "" Then
                MsgBox("�Selecciones el producto o servicio a eliminar!", MsgBoxStyle.Question, "Mensaje")
            Else
                miMenu_Eliminar.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnEliminarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("�Est� seguro de eliminar Toda la Orden de Compra No. " & Me.txtOC.Text & " completamente?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                'JASC21082013
                Mantenimiento_Detalle(Compa�ia, Me.txtOC.Text, Me.dgvDetalleOC.Rows(i).Cells("L�nea").Value, 0, "", 0, 0, 0, 0, 0, "D", 0, "0")
            Next
            Mantenimiento_Encabezado(Compa�ia, Me.txtOC.Text, Format(Now, "dd-MM-yyyy HH:mm:ss"), 0, 0, 0, 0, 0, 0, 0, "", "D") ', 0, 0)
            Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "D", 0)
            Me.btnLimpiarOC.PerformClick()
        End If
    End Sub
    Private Sub CargaTipoDocumento(ByVal Compa�ia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim sqlConStr As String = "User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & "; Workstation ID="
        Conexion_ = New SqlConnection(sqlConStr)
        Try
            Conexion_.Open()
            Sql = "SELECT TIPO_DOCUMENTO_CONTABLE, IDENTIFICADOR + ' - ' + DESCRIPCION_TIPO_DOCUMENTO AS DESCRIPCION_TIPO_DOCUMENTO FROM dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPA�IA = " & Compa�ia
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
                CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
                CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
            End If
        End If
    End Sub

    '*******************************************
    'MAURICIO JOS�

    Private Sub chkSERVICIO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSERVICIO.CheckedChanged
        chkINTANGIBLE.Checked = False
    End Sub

    Private Sub chkINTANGIBLE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkINTANGIBLE.CheckedChanged
        chkSERVICIO.Checked = False
    End Sub

    Private Sub chkINTANGIBLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkINTANGIBLE.Click
        chkINTANGIBLE.Checked = True
    End Sub

    Private Sub chkSERVICIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSERVICIO.Click
        chkSERVICIO.Checked = True
    End Sub
    Private Sub chkSERVICIO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkSERVICIO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.chkINTANGIBLE.Focus()
        End If
    End Sub
    Private Sub chkINTANGIBLE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkINTANGIBLE.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.Txt_PorDescto.Focus()
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
                CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
                Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", 0)
            End If
        End If
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

    Private Sub txtDESCRIPCION_PRODUCTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDESCRIPCION_PRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCANTIDAD.Focus()
        End If
    End Sub

    Private Sub txtCANTIDAD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCANTIDAD.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCOSTO_UNITARIO.Focus()
        End If
    End Sub

    Private Sub Contabilidad_OrdenCompra_No_Inventarios_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub tabDatos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabDatos.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtCOSTO_TOTAL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOSTO_TOTAL.KeyPress
        Dim cadena As String = Me.txtCOSTO_TOTAL.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        'TODO Se agreg� validaci�n para determinar cuando no ingresan costo unitario
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
            MessageBox.Show("Debe ingresar un Costo Unitario", "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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
    '            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
    '            'EAGP 25/02/2014
    '            'Actualiza los costos unitarios en base al descuento general
    '            Mantenimiento_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, Linea, Me.txtPRODUCTO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Me.TxtporDescTotal.Text, Val(Me.Txt_PorDescto.Text), Me.txtCOSTO_UNITARIO.Text, "0", "U2", bonificacion, "0")
    '            'Actualiza el datagrid de los detalles
    '            CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
    '            'Actualiza los totales del documento del lado derecho de la ventana
    '            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
    '            'Envia la orden para autorizacion
    '            Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", Me.Txt_Descuento.Text)
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
    '            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
    '            Mantenimiento_OCAutorizacion(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, "0", "0", Me.txtSubTotal.Text.Replace(",", ""), Me.txtIVA.Text.Replace(",", ""), Me.txtTotal.Text.Replace(",", ""), Me.txtPercepcion.Text.Replace(",", ""), Me.txtTotalFact.Text.Replace(",", ""), "", "I", Me.Txt_Descuento.Text)
    '        Else
    '            TxtporDescTotal.Text = 0
    '        End If
    '        Me.btnGuardarDetalle.Focus()
    '    End If
    '    If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
    '        e.KeyChar = Nothing
    '    End If

    'End Sub

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
                        Sql &= Compa�ia
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
                            MsgBox("Orden de Compra Anulada con �xito.", MsgBoxStyle.Information, "Anular Orden de Compra")
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

    Private Sub txtOC_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOC.LostFocus
        If Me.txtOC.Text.Length > 0 Then
            If Proc.obtenerEscalar("SELECT AFECTAR_INVENTARIOS FROM CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO WHERE COMPA�IA = " & Compa�ia & " AND ORDEN_COMPRA = " & Me.txtOC.Text) Then
                MsgBox("La orden de compra no aplica para esta ventana" & vbCrLf & "Use la opci�n Orden de Compra", MsgBoxStyle.Information, "Validaci�n")
                Return
            End If
            BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 1)
            CargaOC_Detalle_Total(Me.cmbCOMPA�IA.SelectedValue, Me.txtOC.Text, 2)
        End If
        If Me.lblMensaje.Visible = True Then
            MsgBox("�La Orden de Compra ya est� Autorizada!" & Chr(13) & "No podr� realizar cambios.", MsgBoxStyle.Critical, "Mensaje")
            HabilitaDeshabilita(False)
        Else
            HabilitaDeshabilita(True)
        End If
    End Sub

    Private Sub EstadoProveedor(ByVal Compa�ia, ByVal Proveedor)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "SELECT Estado FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPA�IA = "
            Sql &= Compa�ia & " AND PROVEEDOR = " & Proveedor
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Me.lblProveedorEstado.Text = DataReader_.Item("ESTADO")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtOC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOC.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnFinRecepci�n_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinRecepci�n.Click
        Dim cuantos As Integer
        Dim comentar As String = String.Empty
        cuantos = Proc.obtenerEscalar("SELECT COUNT(ORDEN_COMPRA) FROM CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO WHERE COMPA�IA = " & Compa�ia & " AND ORDEN_COMPRA = " & Me.txtOC.Text & " AND CANTIDAD_PENDIENTE > 0")
        If cuantos > 0 Then
            If MsgBox("�Desea finalizar la recepci�n de productos al inventario de la Orden de Compra #" & Me.txtOC.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Recibir Compras") = MsgBoxResult.Yes Then
                Dim frmcomentario As New Contabilidad_OrdenCompra_ComentariosAnular()
                frmcomentario.ShowDialog()
                comentar = frmcomentario.txtComentariosAnular.Text
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPA�IA = " & Compa�ia & ", @ORDEN_COMPRA = " & Me.txtOC.Text & ", @BANDERA = 7, @COMENTARIOS = '" & comentar & "'"
                If Proc.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                    Me.txtOBSERVACIONES.Text &= IIf(Me.txtOBSERVACIONES.Text.Length > 0, ". ", "") & comentar
                    MsgBox("Proceso finalizado" & vbCrLf & "Ya no se podr�n recibir m�s items al inventario de la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
                Else
                    MsgBox("Proceso bloqueado" & vbCrLf & "No se pudo modificar la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
                End If
            End If
        Else
            MsgBox("No hay productos pendientes de recibir de la Orden de Compra #" & Me.txtOC.Text, MsgBoxStyle.Information, "Recibir Compras")
        End If
    End Sub


    Private Sub On_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged, txtIVA.TextChanged, txtPercepcion.TextChanged, txtCESC.TextChanged, txtExento.TextChanged
        Me.txtTotal.Text = Format(Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.txtIVA.Text.Replace(",", "")), "#,##0.00")
        Me.txtTotalFact.Text = Format(Val(Me.txtSubTotal.Text.Replace(",", "")) + Val(Me.txtIVA.Text.Replace(",", "")) + Val(Me.txtPercepcion.Text.Replace(",", "")) + Val(Me.txtCESC.Text.Replace(",", "")) + Val(Me.txtExento.Text.Replace(",", "")), "#,##0.00")
    End Sub
End Class
