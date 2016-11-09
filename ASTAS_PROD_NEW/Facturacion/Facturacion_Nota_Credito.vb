Imports System.Data.SqlClient

Public Class Facturacion_Nota_Credito

    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos
    Dim sqlCmd As New SqlCommand
    Dim totRegFact, TipCosto As Integer
    Dim Table As DataTable
    Dim Sql As String
    Dim inv, _error_, FactCreada As Boolean
    Dim codClie As Integer
    Dim TipClie, StatusCliente As Integer
    Dim TipContrib As Integer
    Dim FormaPagoCCF, CondPago As Integer
    Dim giro As String
    Dim exento As Boolean
    Dim MSJ As Boolean = True
    Dim NRC As String
    Dim dirClie As String
    Dim TipMovInv As Integer = 21
    Dim LineaMod, OVCCF, numPDA, Transac As Integer
    Dim PorcIVA, PorcPercep, CantVend, CostoU As Double
    Dim grupoProd, subgrupoProd As Integer

    Private Sub Facturacion_Nota_Credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Try
            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
            Me.dgvDetalleNC.AutoGenerateColumns = False
            jClass.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
            jClass.CargaUnidadMedida(Compañia, Me.cmbUNIDAD_MEDIDA)
            If Me.cmbUNIDAD_MEDIDA.Items.Count > 1 Then
                Me.cmbUNIDAD_MEDIDA.SelectedIndex = 1
            End If
            PorcIVA = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 1")
            PorcPercep = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 2")
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Load")
        End Try
        Iniciando = False
    End Sub

    Private Sub Facturacion_Nota_Credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
            Case Keys.F1
                'Add the code for the function key F1 here.
            Case Keys.F2
                'Add the code for the function key F2 here.
            Case Keys.F3
                'Add the code for the function key F5 here.
            Case Keys.F4
                'Add the code for the function key F4 here.
            Case Keys.F5
                'Add the code for the function key F5 here.
            Case Keys.F6
                'Add the code for the function key F6 here.
            Case Keys.F7
                'Add the code for the function key F7 here.
        End Select
    End Sub

    Private Sub txtCCF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCCF.KeyPress
        Try
            If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
                MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                e.KeyChar = Nothing
            End If
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Load")
            _error_ = True
        End Try
    End Sub

    Private Sub txtCCF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCCF.LostFocus
        Dim SubTotFact, IVAFact, TotalFact As Double
        Dim FechaCCF As DateTime
        Dim Concepto As String
        Me.txtNC.ReadOnly = False
        Try
            If Val(Me.txtCCF.Text) > 0 Then
                Concepto = Me.txtCCF.Text
                LimpiarCampos()
                Me.txtCCF.Text = Concepto
                Sql = "SELECT FGE.NUMERO_FACTURA, FGE.CONDICION_PAGO, FGE.BODEGA, FGE.ORDEN_VENTA, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGE.ANULADA, FGE.NOMBRE_FACTURA, FGE.PERIODO_PAGO, FGE.CONCEPTO, FGE.DESCONTAR_CUOTAS_DESDE, FGE.DESCUENTO_AGUINALDO, FGE.DESCUENTO_BONIFICACION, FGE.NUMERO_REMESA, FGE.SUB_TOTAL, FGE.TOTAL_IVA, FGE.TOTAL_FACTURA, FGE.CLIENTE, FGE.NIT, FGE.BANCO_REMESA, FGE.CUENTA_BANCO_REMESA, FGE.CONTABILIZADO "
                Sql &= "FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE"
                Sql &= " WHERE FGE.COMPAÑIA = " & Compañia
                Sql &= " AND FGE.BODEGA = " & Me.cmbBODEGA.SelectedValue
                Sql &= " AND FGE.TIPO_DOCUMENTO = 2"
                Sql &= " AND FGE.NUMERO_FACTURA = " & Me.txtCCF.Text
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("CLIENTE")
                    datosCliente(Me.txtCliente.Text, Table.Rows(0).Item("NIT"))
                    Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_FACTURA")
                    FechaCCF = Table.Rows(0).Item("FECHA_FACTURA")
                    SubTotFact = Table.Rows(0).Item("SUB_TOTAL")
                    IVAFact = Table.Rows(0).Item("TOTAL_IVA")
                    TotalFact = Table.Rows(0).Item("TOTAL_FACTURA")
                    Me.lblFechaCCF.Text = FechaCCF.ToString("dd/MM/yyyy")
                    Me.lblFormaPago.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_FORMA_PAGO FROM FACTURACION_CATALOGO_FORMA_PAGO WHERE COMPAÑIA = " & Compañia & " AND FORMA_PAGO = " & Table.Rows(0).Item("FORMA_PAGO"))
                    Me.lblConPago.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_CONDICION_PAGO WHERE COMPAÑIA = " & Compañia & " AND FORMA_PAGO = " & Table.Rows(0).Item("FORMA_PAGO") & " AND CONDICION_PAGO = " & Table.Rows(0).Item("CONDICION_PAGO"))
                    Me.lblSubtotal.Text = SubTotFact.ToString("#,##0.00")
                    Me.lblIVA.Text = IVAFact.ToString("#,##0.00")
                    Me.lblTotal.Text = TotalFact.ToString("#,##0.00")
                    CondPago = Table.Rows(0).Item("CONDICION_PAGO")
                    FormaPagoCCF = Table.Rows(0).Item("FORMA_PAGO")
                    Concepto = Table.Rows(0).Item("CONCEPTO")
                    OVCCF = Table.Rows(0).Item("ORDEN_VENTA")
                    If Concepto.Length > 0 Then
                        Me.txtNC.Text = Concepto.Substring(Concepto.IndexOf(".") + 1).Trim
                        Numero_OV = jClass.obtenerEscalar("SELECT ORDEN_VENTA FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND TIPO_DOCUMENTO = 4 AND NUMERO_FACTURA = " & Me.txtNC.Text)
                        CargaDetalleNC(Val(Me.txtNC.Text), Me.cmbBODEGA.SelectedValue)
                        FactCreada = True
                    End If
                    If FormaPagoCCF = 2 And Not Table.Rows(0).Item("CONTABILIZADO") Then
                        Me.btnContabilizar.Enabled = True
                    End If
                Else
                    MsgBox("CCF No." & Me.txtCCF.Text & " No existe o no corresponde a bodega " & vbCrLf & Me.cmbBODEGA.Text, MsgBoxStyle.Information, "CCF No Encontrado")
                End If
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito txtCCF.Lostfocus")
            _error_ = True
        End Try
    End Sub

    Private Sub datosCliente(ByVal numCliente As String, ByVal NIT As String)
        Dim datClie As DataTable
        If numCliente.Length > 0 Then
            Try
                Sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                Sql &= Compañia
                Sql &= ", '" & numCliente & "'"
                Sql &= ", '" & NIT & "' "
                Sql &= ", 2"
                sqlCmd.CommandText = Sql
                datClie = jClass.obtenerDatos(sqlCmd)
                If datClie.Rows.Count = 1 Then
                    Me.txtNombreCliente.Text = datClie.Rows(0).Item("Nombre")
                    Me.txtTelCliente.Text = datClie.Rows(0).Item("Teléfono")
                    Me.txtDUICliente.Text = datClie.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = datClie.Rows(0).Item("NIT")
                    Me.txtNRC.Text = datClie.Rows(0).Item("NRC")
                    Origen = datClie.Rows(0).Item("Origen")
                    codClie = datClie.Rows(0).Item("Cliente")
                    giro = datClie.Rows(0).Item("Giro")
                    exento = datClie.Rows(0).Item("Exento")
                    TipClie = datClie.Rows(0).Item("Tipo Cliente")
                    TipContrib = datClie.Rows(0).Item("Tipo Contribuyente")
                    dirClie = datClie.Rows(0).Item("Dirección")
                Else
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                jClass.msjError(ex, "Nota Crédito datosCliente")
                _error_ = True
            End Try
        End If
    End Sub

    Private Sub CargaDetalleNC(ByVal numNC As Integer, ByVal Bodega As Integer)
        Try
            GenerarSQL(0, 4)
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            Me.dgvDetalleNC.DataSource = Table
            If Table.Rows.Count > 0 Then
                Me.txtNC.ReadOnly = True
                totalizaNC()
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito CargaDetalleNC")
            _error_ = True
        End Try
    End Sub

    Private Sub bntNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevo.Click
        LimpiarCampos()
        LimpiaCamposDetalleNC()
    End Sub

    Private Sub LimpiarCampos()
        Me.txtCCF.Clear()
        Me.txtNC.Clear()
        Me.txtNC.ReadOnly = False
        Me.txtCliente.Clear()
        Me.txtNomFact.Clear()
        Me.txtNombreCliente.Clear()
        Me.txtTelCliente.Clear()
        Me.txtDUICliente.Clear()
        Me.txtNITCliente.Clear()
        Me.txtNRC.Clear()
        Me.lblConPago.Text = ""
        Me.lblFormaPago.Text = ""
        Me.lblConPago.Text = ""
        Me.lblSubtotal.Text = ""
        Me.lblIVA.Text = ""
        Me.lblTotal.Text = ""
        Me.txtProducto.Clear()
        Me.txtDescripcion.Clear()
        Me.txtCantidad.Clear()
        Me.txtPrecio.Clear()
        Me.txtPrecio.ReadOnly = False
        Me.txtProducto.ReadOnly = False
        Me.txtDescripcion.ReadOnly = False
        Me.cmbBODEGA.Enabled = True
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.btnContabilizar.Enabled = False
        While Me.dgvDetalleNC.Rows.Count > 0
            Me.dgvDetalleNC.Rows.RemoveAt(0)
        End While
    End Sub

    Private Sub txtNC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNC.KeyPress
        Try
            If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
                MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                e.KeyChar = Nothing
            End If
            If Asc(e.KeyChar) = Keys.Enter Then
                Me.txtProducto.Focus()
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Keypress")
            _error_ = True
        End Try
    End Sub

    Private Sub txtNC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNC.LostFocus
        Dim Concepto As String
        If Val(Me.txtNC.Text) > 0 Then
            Concepto = jClass.obtenerEscalar("SELECT CONCEPTO FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND TIPO_DOCUMENTO = 4 AND NUMERO_FACTURA = " & Me.txtNC.Text)
            If Concepto <> Nothing Then
                If Concepto.Length > 0 Then
                    txtCCF.Text = Concepto.Substring(Concepto.IndexOf(".") + 1).Trim
                    txtCCF_LostFocus(sender, e)
                    FactCreada = True
                    'CargaDetalleNC(Val(Me.txtNC.Text), Me.cmbBODEGA.SelectedValue)
                End If
            End If
        End If
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
            e.KeyChar = Nothing
        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub SoloNumerosyUnPunto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress, txtPrecio.KeyPress
        Try
            Dim cadena As String = sender.Text
            Dim Ocurrencias As Boolean
            Ocurrencias = cadena.Contains(".")
            If e.KeyChar <> ControlChars.Back And e.KeyChar <> ControlChars.Tab And e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                If e.KeyChar = "." Then
                    If Ocurrencias Then
                        MsgBox("Ya hay un punto decimal.", MsgBoxStyle.Information, "Validación")
                        e.KeyChar = Nothing
                    End If
                Else
                    If Not IsNumeric(e.KeyChar) Then
                        MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
                        e.KeyChar = Nothing
                    End If
                End If
            End If
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Numeros Punto")
            _error_ = True
        End Try
    End Sub

    Private Sub GenerarSQL(ByVal Producto As Integer, ByVal TipDoc As Integer)
        Try
            Sql = "SELECT FGD.PRODUCTO, " & vbCrLf
            Sql &= "      FGD.NOMBRE_PRODUCTO, " & vbCrLf
            Sql &= "      FGD.UNIDAD_MEDIDA, " & vbCrLf
            Sql &= "      RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, " & vbCrLf
            Sql &= "      " & IIf(TipDoc = 4, "-", "") & "(FGD.CANTIDAD) AS CANTIDAD, " & vbCrLf
            Sql &= "      (FGD.PRECIO_UNITARIO / " & (1 + (PorcIVA / 100)) & ") AS PRECIO_UNITARIO, " & vbCrLf
            Sql &= "      (FGD.PRECIO_TOTAL / " & IIf(TipDoc = 4, "-", "") & (1 + (PorcIVA / 100)) & ") AS PRECIO_TOTAL, " & vbCrLf
            Sql &= "      FGD.COSTO_UNITARIO, " & vbCrLf
            Sql &= "      FGD.COSTO_TOTAL, " & vbCrLf
            Sql &= "      FGD.CODIGO_GRUPO, " & vbCrLf
            Sql &= "      FGD.CODIGO_SUBGRUPO, " & vbCrLf
            Sql &= "      FGD.LINEA, " & vbCrLf
            Sql &= "      IME.TIPO_MOVIMIENTO, " & vbCrLf
            Sql &= "      IME.MOVIMIENTO, " & vbCrLf
            Sql &= "      FGE.CONTABILIZADO, " & vbCrLf
            Sql &= "      FGE.ORDEN_VENTA, " & vbCrLf
            Sql &= "      FGE.FORMA_PAGO, " & vbCrLf
            Sql &= "      FGE.FECHA_FACTURA " & vbCrLf
            Sql &= "FROM dbo.FACTURACION_GENERADA_DETALLE FGD " & vbCrLf
            Sql &= "LEFT JOIN dbo.FACTURACION_GENERADA_ENCABEZADO FGE " & vbCrLf
            Sql &= "  ON FGD.COMPAÑIA = FGE.COMPAÑIA " & vbCrLf
            Sql &= "     AND FGD.BODEGA = FGD.BODEGA " & vbCrLf
            Sql &= "     AND FGD.TIPO_DOCUMENTO = FGE.TIPO_DOCUMENTO " & vbCrLf
            Sql &= "     AND FGD.NUMERO_FACTURA = FGE.NUMERO_FACTURA " & vbCrLf
            Sql &= "LEFT JOIN dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME " & vbCrLf
            Sql &= "  ON FGE.COMPAÑIA = IME.COMPAÑIA " & vbCrLf
            Sql &= "     AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA " & vbCrLf
            Sql &= "LEFT JOIN dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD " & vbCrLf
            Sql &= "  ON IME.COMPAÑIA = IMD.COMPAÑIA " & vbCrLf
            Sql &= "     AND IME.BODEGA = IMD.BODEGA " & vbCrLf
            Sql &= "     AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO " & vbCrLf
            Sql &= "     AND IME.MOVIMIENTO = IMD.MOVIMIENTO" & vbCrLf
            Sql &= "     AND FGD.PRODUCTO = IMD.PRODUCTO " & vbCrLf
            Sql &= "LEFT JOIN dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM " & vbCrLf
            Sql &= "  ON ICUM.COMPAÑIA = FGD.COMPAÑIA " & vbCrLf
            Sql &= "     AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA " & vbCrLf
            Sql &= " WHERE FGE.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND FGE.BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            Sql &= "   AND FGE.TIPO_DOCUMENTO = " & TipDoc & vbCrLf
            Sql &= "   AND FGE.NUMERO_FACTURA = " & IIf(TipDoc = 2, Val(Me.txtCCF.Text), Val(Me.txtNC.Text)) & vbCrLf
            If Producto > 0 Then
                Sql &= "   AND FGD.PRODUCTO = " & Producto & vbCrLf
            End If
            Sql &= " ORDER BY FGD.LINEA"
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Numeros Punto")
            _error_ = True
        End Try
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim frmProd As New Facturacion_Busqueda_Productos_CCF
        Try
            Me.txtDescripcion.ReadOnly = False
            Me.txtDescripcion.Clear()
            Me.txtPrecio.ReadOnly = False
            Me.txtPrecio.Clear()
            CantVend = 0
            inv = False
            GenerarSQL(0, 2)
            sqlCmd.CommandText = Sql
            Numero = -1
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                frmProd.dgvProductos.AutoGenerateColumns = False
                frmProd.dgvProductos.DataSource = Table
                frmProd.ShowDialog()
                If Numero >= 0 Then
                    Me.txtProducto.Text = Table.Rows(Numero).Item("PRODUCTO")
                    Me.txtDescripcion.Text = Table.Rows(Numero).Item("NOMBRE_PRODUCTO")
                    Me.txtPrecio.Text = Format(Table.Rows(Numero).Item("PRECIO_UNITARIO"), "0.00000")
                    Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(Numero).Item("UNIDAD_MEDIDA")
                    CantVend = Table.Rows(Numero).Item("CANTIDAD")
                    CostoU = Table.Rows(Numero).Item("COSTO_UNITARIO")
                    grupoProd = Table.Rows(Numero).Item("CODIGO_GRUPO")
                    subgrupoProd = Table.Rows(Numero).Item("CODIGO_SUBGRUPO")
                    Me.txtDescripcion.ReadOnly = True
                    Me.txtPrecio.ReadOnly = True
                    inv = True
                End If
            Else
                MsgBox("No hay detalle para CCF No. " & Me.txtCCF.Text, MsgBoxStyle.Information, "Búsqueda")
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Buscar Producto")
            _error_ = True
        End Try
    End Sub

    Private Sub txtProducto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.LostFocus
        Try
            Me.txtDescripcion.ReadOnly = False
            Me.txtDescripcion.Clear()
            Me.txtPrecio.ReadOnly = False
            Me.txtPrecio.Clear()
            CantVend = 0
            inv = False
            If Val(Me.txtProducto.Text) > 0 Then
                sqlCmd.CommandText = "SELECT PRODUCTO FROM INVENTARIOS_CATALOGO_PRODUCTOS WHERE PRODUCTO = " & Me.txtProducto.Text
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 0 Then
                    MsgBox("Producto código " & Me.txtProducto.Text & vbCrLf & "No existe en el Inventario", MsgBoxStyle.Information, "Búsqueda")
                    Me.txtProducto.Clear()
                    Me.txtProducto.Focus()
                    Return
                End If
                GenerarSQL(Val(Me.txtProducto.Text), 2)
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Me.txtProducto.Text = Table.Rows(0).Item("PRODUCTO")
                    Me.txtDescripcion.Text = Table.Rows(0).Item("NOMBRE_PRODUCTO")
                    Me.txtPrecio.Text = Format(Table.Rows(0).Item("PRECIO_UNITARIO"), "0.00000")
                    Me.cmbUNIDAD_MEDIDA.SelectedValue = Table.Rows(0).Item("UNIDAD_MEDIDA")
                    CantVend = Table.Rows(0).Item("CANTIDAD")
                    CostoU = Table.Rows(0).Item("COSTO_UNITARIO")
                    grupoProd = Table.Rows(0).Item("CODIGO_GRUPO")
                    subgrupoProd = Table.Rows(0).Item("CODIGO_SUBGRUPO")
                    Me.txtDescripcion.ReadOnly = True
                    Me.txtPrecio.ReadOnly = True
                    inv = True
                Else
                    MsgBox("No existe producto codigo " & Me.txtProducto.Text & " para CCF No. " & Me.txtCCF.Text, MsgBoxStyle.Information, "Búsqueda")
                    Me.txtProducto.Clear()
                End If
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Producto Buscar")
            _error_ = True
        End Try
    End Sub

    Private Sub crearFactura_OVEncabezado(ByVal CIA As Integer, _
                                               ByVal Bodega As Integer, _
                                               ByVal fechafact As DateTime, _
                                               ByVal TipDoc As Integer, _
                                               ByVal NoFact As String, _
                                               ByVal FormaPago As Integer, _
                                               ByVal codBuxis As String, _
                                               ByVal CodCliente As String, _
                                               ByVal NomFact As String, _
                                               ByVal TelCliente As String, _
                                               ByVal txtDUI As String, _
                                               ByVal txtNIT As String, _
                                               ByVal Concepto As String, _
                                               ByVal impConcepto As Short, _
                                               ByVal SubTotal As String, _
                                               ByVal IVA As String, _
                                               ByVal Total As String, _
                                               ByVal numCuotas As Integer, _
                                               ByVal descontarDesde As Date, _
                                               ByVal descuentoAguinaldo As Double, _
                                               ByVal descuentoBonificacion As Double, _
                                               ByVal periodoPago As String, _
                                               ByVal numRemesa As String, _
                                               ByVal Banco As Integer, _
                                               ByVal Numero_Cta As String)
        _error_ = False
        GuardaEliminaOrdenVentaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NomFact, Concepto, FormaPago, CondPago, TipClie, TipContrib, exento, NRC, giro, codBuxis, CodCliente, dirClie, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "I")
        If Not _error_ Then
            GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NRC, TipContrib, exento, CondPago, NomFact, SubTotal, IVA, Total, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "I")
        End If
    End Sub

    Private Sub GrabaDetalleFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact As Integer, ByVal FechaMov As DateTime, _
                                    ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                    ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal SubTotalFact As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                    ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Tot_Factura As Double, ByVal totIVA As Double, ByVal Banco As Integer, ByVal Numero_Cta As String)
        Dim PrecioUnit As Double
        PrecioUnit = PrecProd
        _error_ = False
        GuardaEliminaRegistroFacturaDetalleOV(CIA, Bodega, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Grupo, SubGrupo, exento, "I")
        If Not _error_ Then
            If inv Then
                GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, TipDoc, numdoc, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, TipDoc, Val(NoFact)), "I", TipCosto)
            End If
            If Not _error_ Then
                GuardaEliminaRegistroFacturaGeneradaDetalle(CIA, Bodega, TipDoc, numdoc, codProd, descProd, UM, cant, CostoU, CostoT, PrecioUnit, Total, Grupo, SubGrupo, "I")
                If FactCreada And Not _error_ Then
                    GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, numdoc, NRC, TipClie, exento, CondPago, NomFact, SubTotalFact, totIVA, Tot_Factura, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, Banco, Numero_Cta, "U")
                End If
            End If
        End If
    End Sub

    Private Sub GuardaEliminaOrdenVentaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NomFact As String, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal Condicion As Integer, ByVal TipoCliente As Integer, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal NRCCliente As String, ByVal GiroClie As String, ByVal codBuxis As String, ByVal codSocio As String, ByVal Direccion As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaMov As Date, _
                                                        ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal Accion As String)
        Dim totReg, corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            If Not FactCreada Then
                Numero_OV = obtieneMAXOV(Compañia)
            End If
            Sql = " Execute dbo.sp_FACTURACION_FATURAS_ENCABEZADO_IUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", " & Numero_OV
            Sql &= ", '" & Format(FechaMov, "Short Date") & "'"
            Sql &= ", " & TipDoc
            Sql &= ", " & NoFact
            Sql &= ", '" & Format(FechaMov, "Short Date") & "'"
            Sql &= ", " & FormaPago
            Sql &= ", " & Condicion
            Sql &= ", " & codCliente
            Sql &= ", " & codBuxis
            Sql &= ", '" & codSocio & "'"
            Sql &= ", " & TipoCliente
            Sql &= ", " & TipoContribuyente
            Sql &= ", '" & NomFact & "'"
            Sql &= ", '" & Direccion & "'"
            Sql &= ", '" & txtDUI & "'"
            Sql &= ", '" & txtNIT & "'"
            Sql &= ", '" & NRCCliente & "'"
            Sql &= ", '" & GiroClie & "'"
            Sql &= ", " & es_exento
            Sql &= ", 0" 'Imprimir Concepto?
            Sql &= ", '" & Concepto & "'"
            Sql &= ", ''" 'Observaciones
            Sql &= ", " & Origen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Accion & "'"
            Sql &= ", '" & periodoPago & "'"
            Sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            Sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            Sql &= ", " & DescuentoAguinaldo
            Sql &= ", " & DescuentoBonificacion
            Sql &= ", '" & NumRemesa & "'"
            Sql &= ", " & IIf(FormaPago = 1, Banco, 0)
            Sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
            sqlCmd.CommandText = Sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If totReg > 0 And Not FactCreada Then
                corre = FPro.actualizaNumDoc(CIA, "OV")
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito O.V. Encabezado")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaFacturaGeneradaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                        ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                        ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                        ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, _
                                                        ByVal Banco As Integer, ByVal Numero_Cta As String, ByVal Accion As String)
        Dim totReg As Integer
        Dim Retencion As Double = 0
        Try
            Sql = " Execute dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", " & Numero_OV
            Sql &= ", " & NoFact
            Sql &= ", '" & NomFact & "'"
            Sql &= ", '" & Format(FechaFact, "Short Date") & "'"
            Sql &= ", " & codCliente
            Sql &= ", " & Numero_Serie
            Sql &= ", " & jClass.obtenerEscalar("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Bodega) 'CENTRO COSTO
            Sql &= ", " & TipDoc
            Sql &= ", " & FormaPago
            Sql &= ", '" & periodoPago & "'"
            Sql &= ", " & Condicion
            Sql &= ", " & codBuxis
            Sql &= ", '" & codSocio & "'"
            Sql &= ", " & TipoContribuyente
            Sql &= ", '" & txtDUI & "'"
            Sql &= ", '" & txtNIT & "'"
            Sql &= ", '" & NRCCliente & "'"
            Sql &= ", " & es_exento
            Sql &= ", " & impConcepto
            Sql &= ", '" & Concepto & "'"
            Sql &= ", " & -Subtotal
            Sql &= ", " & PorcIVA
            Sql &= ", " & -IVA
            Sql &= ", " & -Retencion
            Sql &= ", " & -(Total - Retencion)
            Sql &= ", " & IIf(FormaPago = 1, 0, Cuotas)
            Sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
            Sql &= ", " & DescuentoAguinaldo
            Sql &= ", " & DescuentoBonificacion
            Sql &= ", '" & NumRemesa & "'"
            Sql &= ", 0" 'ANULADA?
            Sql &= ", " & Origen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Accion & "'"
            Sql &= ", " & IIf(FormaPago = 1, Banco, 0)
            Sql &= ", '" & IIf(FormaPago = 1, Numero_Cta, "") & "'"
            sqlCmd.CommandText = Sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If totReg > 0 And Accion = "I" Then
                FactCreada = True
                Sql = "UPDATE FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= "SET CONCEPTO = 'NC No. " & Me.txtNC.Text.Trim & "' " & vbCrLf
                Sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND BODEGA = " & Bodega & vbCrLf
                Sql &= "  AND TIPO_DOCUMENTO = 2" & vbCrLf
                Sql &= "  AND NUMERO_FACTURA = " & Me.txtCCF.Text
                sqlCmd.CommandText = Sql
                totReg = jClass.ejecutarComandoSql(sqlCmd)
                Sql = "UPDATE FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= "SET FACTURA_IMPRESA = 1" & vbCrLf
                Sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND BODEGA = " & Bodega & vbCrLf
                Sql &= "  AND TIPO_DOCUMENTO = 4" & vbCrLf
                Sql &= "  AND ORDEN_VENTA = " & Numero_OV & vbCrLf
                Sql &= "  AND NUMERO_FACTURA = " & NoFact
                sqlCmd.CommandText = Sql
                totReg = jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Fact.Encab.")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaRegistroFacturaDetalleOV(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal es_exento As Boolean, ByVal Accion As String)

        'TCDETPRIMERA
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            Sql = " Execute dbo.sp_FACTURACION_FACTURAS_DETALLE_IUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", " & Numero_OV
            Sql &= ", " & totRegFact
            Sql &= ", " & codProd
            Sql &= ", '" & descProd & "'"
            Sql &= ", " & UM
            Sql &= ", " & -Cant
            Sql &= ", " & CostoU
            Sql &= ", " & CostoT
            Sql &= ", " & PrecProd
            Sql &= ", " & Grupo
            Sql &= ", " & SubGrupo
            Sql &= ", " & Origen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Accion & "'"
            sqlCmd.CommandText = Sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            jClass.msjError(ex, "O.V. Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal Accion As String)
        Dim corre As Integer
        Try
            Sql = " Execute dbo.sp_FACTURACION_GENERADA_DETALLE_IUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", " & Numero_OV
            Sql &= ", " & TipDoc
            Sql &= ", " & NoFact
            Sql &= ", " & totRegFact
            Sql &= ", " & codProd
            Sql &= ", '" & descProd & "'"
            Sql &= ", " & UM
            Sql &= ", " & -Cant
            Sql &= ", 0"
            Sql &= ", " & CostoU
            Sql &= ", " & CostoT
            Sql &= ", " & PrecProd
            Sql &= ", " & -Total
            Sql &= ", " & Grupo
            Sql &= ", " & SubGrupo
            Sql &= ", " & Origen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Accion & "'"
            sqlCmd.CommandText = Sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            'MsgBox("Registros actualizados: " + corre.ToString, MsgBoxStyle.Exclamation, "Factura Detalle")
        Catch ex As Exception
            jClass.msjError(ex, "Factura Detalle")
            _error_ = True
        End Try
    End Sub

    Private Sub GuardaEliminaMovimientoInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov As Integer, ByVal Accion As String, ByVal tipoCosto As Integer)
        If codProd = 0 Then
            Return
        End If
        Dim corre As Integer
        Try
            Sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            Sql &= CIA
            Sql &= ", " & Bodega
            Sql &= ", 0" 'PROVEEDOR?
            Sql &= ", " & TipMov 'TIPO_MOVIMIENTO
            Sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            Sql &= ", 0" 'MOV1
            Sql &= ", " & TipDoc 'TIPO_DOCUMENTO_CONTABLE
            Sql &= ", " & NoFact 'NUMERO_DOCUMENTO_CONTABLE
            Sql &= ", '" & Format(FechaMov, "Short Date") & "'" 'FECHA MOVIMIENTO
            Sql &= ", 0" 'ANULADO?
            Sql &= ", 1" 'PROCESADO
            Sql &= ", " & codProd
            Sql &= ", " & Cant
            Sql &= ", " & CostoU
            Sql &= ", " & CostoT
            Sql &= ", 1" 'ENTRADA_SALIDA
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & Accion & "'"
            Sql &= ", " & Numero_OV 'ORDEN_VENTA
            sqlCmd.CommandText = Sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
            If corre > 0 And tipoCosto = 2 Then
                'Para actualizar las cantidades por los costos UEPS
                If Accion = "D" Or Accion = "DD" Then
                    Cant = -(Cant)
                End If
                sqlCmd.CommandText = "Execute sp_INVENTARIOS_INGRESAR_COMPRAS @COMPAÑIA = " & CIA & ", @BODEGA = " & Bodega & ", @PRODUCTO = " & codProd & ", @ENTRADAS = 0, @SALIDAS = " & Cant & ", @BANDERA = 'O'"
                corre = jClass.ejecutarComandoSql(sqlCmd)
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito Inventario Detalle")
            _error_ = True
        End Try
    End Sub

    Private Function obtieneMAXOV(ByVal cia As Integer) As Integer
        Dim numOV As Integer
        Try
            Sql = "SELECT ISNULL(MAX([ORDEN_VENTA]),0) + 1 FROM dbo.FACTURACION_FACTURAS_ENCABEZADO WHERE COMPAÑIA = " & cia
            numOV = jClass.obtenerEscalar(Sql)
            If numOV = Nothing Then
                Return 0
            Else
                Return numOV
            End If
            Return 0
        Catch ex As Exception
            jClass.msjError(ex, "Nota Crédito obtieneMAXOV")
            _error_ = True
        End Try
    End Function

    Private Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        If Val(Me.txtCantidad.Text) > CantVend And inv = True Then
            MsgBox("Cantidad mayor a cantidad vendida.", MsgBoxStyle.Information, "Cantidad")
            Me.txtCantidad.Text = CantVend.ToString("0.00")
        End If
    End Sub

    Private Function validaCamposVacios() As Boolean
        If Val(Me.txtCCF.Text) = 0 Then
            MsgBox("Ingrese un Número de CCF", MsgBoxStyle.Critical, "Campo CCF Vacio")
            Me.txtCCF.Focus()
            Return False
        End If
        If Val(Me.txtNC.Text) = 0 Then
            MsgBox("Ingrese un Número de Nota de Crédito", MsgBoxStyle.Critical, "Campo NC Vacio")
            Me.txtNC.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnGuardaEncabezadoNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaEncabezadoNC.Click
        If Not validaCamposVacios() Then
            Return
        End If
        _error_ = False
        GuardaEliminaOrdenVentaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, codClie, 4, Me.txtNC.Text, Me.txtNomFact.Text, "CCF No. " & Me.txtCCF.Text, FormaPagoCCF, CondPago, TipClie, TipContrib, exento, NRC, giro, "0", Me.txtCliente.Text, dirClie, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, 0, Me.dpFECHA_CONTABLE.Value, 0, 0, "QQ", "", 0, "", IIf(FactCreada, "U", "I"))
        If Not _error_ Then
            _error_ = False
            GuardaEliminaFacturaGeneradaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, codClie, 4, Me.txtNC.Text, NRC, TipClie, exento, CondPago, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), Val(Me.txtIVA.Text), Val(Me.txtTotFact.Text), 0, "CCF No. " & Me.txtCCF.Text, FormaPagoCCF, "0", Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, 0, Now, 0, 0, "QQ", "", 0, "", IIf(FactCreada, "U", "I"))
        End If
        If Not _error_ And MSJ Then
            MsgBox("Factura Actualizada con éxito", MsgBoxStyle.Information, "Guardar")
        End If
    End Sub

    Private Sub totalizaNC()
        Dim Subtotal, TotIVA, totFactura As Double
        For Each row As DataGridViewRow In Me.dgvDetalleNC.Rows
            Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
        Next
        TotIVA = (Subtotal * ((PorcIVA / 100)))
        totFactura = Subtotal + TotIVA
        Me.txtSUBTOTAL.Text = Subtotal.ToString("###0.00")
        Me.txtIVA.Text = TotIVA.ToString("###0.00")
        Me.txtTotFact.Text = totFactura.ToString("###0.00")
    End Sub

    Private Sub LimpiaCamposDetalleNC()
        Me.txtDescripcion.Clear()
        Me.txtDescripcion.ReadOnly = False
        Me.txtPrecio.Clear()
        Me.txtPrecio.ReadOnly = False
        Me.txtCantidad.Clear()
        Me.txtProducto.Clear()
        Me.cmbUNIDAD_MEDIDA.SelectedValue = 1
        CostoU = 0
        subgrupoProd = 0
        grupoProd = 0
        TipCosto = 1
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        Dim subtot, totProd, CostoT, CantidadFacturada, totProdItem As Double
        Dim TipMovto, Movto As Integer
        Dim ProductoDuplicado As Boolean
        If Not validaCamposVacios() Then
            Return
        End If
        If Me.txtDescripcion.Text.Length = 0 Then
            MsgBox("Debe suministrar una descripción.", MsgBoxStyle.Critical, "Descripción inválida")
            Me.txtDescripcion.Focus()
            Return
        End If
        If Val(Me.txtCantidad.Text) = 0 Then
            MsgBox("La Cantidad del producto debe ser diferente de cero.", MsgBoxStyle.Critical, "Cantidad inválida")
            Me.txtCantidad.Focus()
            Return
        End If
        Producto = Val(Me.txtProducto.Text)
        CantidadFacturada = 0
        If Producto > 0 Then
            For Each row As DataGridViewRow In Me.dgvDetalleNC.Rows
                If Val(row.Cells("PRODUCT").Value) = Producto Then
                    totProdItem = row.Cells("PRECIO_TOTAL").Value
                    TipMovto = row.Cells("TIPO_MOVIMIENTO").Value
                    Movto = row.Cells("MOVIMIENTO").Value
                    totRegFact = row.Cells("LINEA").Value
                    ProductoDuplicado = True
                End If
            Next
        Else
            If LineaMod > 0 Then
                totProdItem = Me.dgvDetalleNC.Rows(LineaMod).Cells("PRECIO_TOTAL").Value
                TipMovto = Me.dgvDetalleNC.Rows(LineaMod).Cells("TIPO_MOVIMIENTO").Value
                Movto = Me.dgvDetalleNC.Rows(LineaMod).Cells("MOVIMIENTO").Value
                totRegFact = Me.dgvDetalleNC.Rows(LineaMod).Cells("LINEA").Value
                ProductoDuplicado = True
            End If
        End If
        If ProductoDuplicado Then
            GuardaEliminaMovimientoInventarioDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 0, "0", Producto, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, TipMovto, Movto, "DD", TipCosto)
            GuardaEliminaRegistroFacturaGeneradaDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 4, Me.txtNC.Text, Producto, "", 0, 0, 0, 0, 0, 0, 0, 0, "D")
            GuardaEliminaRegistroFacturaDetalleOV(Compañia, Me.cmbBODEGA.SelectedValue, Producto, "", 0, 0, 0, 0, 0, 0, 0, exento, "D")
        End If
        CantidadFacturada = Val(Me.txtCantidad.Text)
        CostoT = CostoU * Val(CantidadFacturada)
        subtot = Val(CantidadFacturada) * Val(Me.txtPrecio.Text)
        totProd = subtot
        Me.txtSUBTOTAL.Text = Val(Me.txtSUBTOTAL.Text) + subtot - totProdItem
        Me.txtIVA.Text = Math.Round(Val(Me.txtSUBTOTAL.Text) * (PorcIVA / 100), 2)
        Me.txtTotFact.Text = ((Val(Me.txtSUBTOTAL.Text) + Val(Me.txtIVA.Text)))
        Me.cmbBODEGA.Enabled = False
        _error_ = False
        If Not FactCreada Then
            crearFactura_OVEncabezado(Compañia, _
                                    Me.cmbBODEGA.SelectedValue, _
                                    Me.dpFECHA_CONTABLE.Value, _
                                    4, _
                                    Me.txtNC.Text, _
                                    FormaPagoCCF, _
                                    "0", _
                                    Me.txtCliente.Text, _
                                    Me.txtNomFact.Text, _
                                    Me.txtTelCliente.Text, _
                                    Me.txtDUICliente.Text, _
                                    Me.txtNITCliente.Text, _
                                    "CCF No. " & Me.txtCCF.Text, _
                                    0, _
                                    Me.txtSUBTOTAL.Text, _
                                    Me.txtIVA.Text, _
                                    Me.txtTotFact.Text, _
                                    0, _
                                    Now, _
                                    0, _
                                    0, _
                                    "QQ", _
                                    "", _
                                    0, _
                                    "")
        End If
        If Not _error_ Then
            GrabaDetalleFactura(Compañia, Me.cmbBODEGA.SelectedValue, Producto, Me.txtDescripcion.Text, Val(Me.txtNC.Text), Me.dpFECHA_CONTABLE.Value, Me.cmbUNIDAD_MEDIDA.SelectedValue, CantidadFacturada, CostoU, CostoT, Val(Me.txtPrecio.Text) * (1 + (PorcIVA / 100)), totProd * (1 + (PorcIVA / 100)), grupoProd, subgrupoProd, 4, Me.txtNC.Text, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), _
                                0, "CCF No. " & Me.txtCCF.Text, FormaPagoCCF, "0", Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, 0, Now, 0, 0, "QQ", "", Val(Me.txtTotFact.Text), Val(Me.txtIVA.Text), 0, "")
        End If
        CargaDetalleNC(Me.txtNC.Text, Me.cmbBODEGA.SelectedValue)
        LimpiaCamposDetalleNC()
        Me.txtProducto.Focus()
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        LimpiarCampos()
        LimpiaCamposDetalleNC()
    End Sub

    Private Sub btnEliminaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaDetalle.Click
        Dim CurRow As DataGridViewRow
        CurRow = Me.dgvDetalleNC.CurrentRow
        If MsgBox("Está seguro de eliminar este item: " & CurRow.Cells("PRODUCT").Value & " " & CurRow.Cells(1).Value, MsgBoxStyle.YesNo, "Eliminar Item") = MsgBoxResult.No Then
            Return
        End If
        GuardaEliminaMovimientoInventarioDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 0, "0", CurRow.Cells("PRODUCT").Value, 0, 0, 0, Me.dpFECHA_CONTABLE.Value, CurRow.Cells("TIPO_MOVIMIENTO").Value, CurRow.Cells("MOVIMIENTO").Value, "DD", TipCosto)
        totRegFact = CurRow.Cells("LINEA").Value
        GuardaEliminaRegistroFacturaGeneradaDetalle(Compañia, Me.cmbBODEGA.SelectedValue, 4, Me.txtNC.Text, CurRow.Cells("PRODUCT").Value, "", 0, 0, 0, 0, 0, 0, 0, 0, "D")
        GuardaEliminaRegistroFacturaDetalleOV(Compañia, Me.cmbBODEGA.SelectedValue, CurRow.Cells("PRODUCT").Value, "", 0, 0, 0, 0, 0, 0, 0, exento, "D")
        CargaDetalleNC(Me.txtNC.Text, Me.cmbBODEGA.SelectedValue)
        totalizaNC()
        GuardaEliminaFacturaGeneradaEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, codClie, 4, Me.txtNC.Text, NRC, TipContrib, exento, CondPago, Me.txtNomFact.Text, Val(Me.txtSUBTOTAL.Text), Val(Me.txtIVA.Text), Val(Me.txtTotFact.Text), 0, "CCF No. " & Me.txtCCF.Text, FormaPagoCCF, "0", Me.txtCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, 0, Now, 0, 0, "QQ", "", 0, "", "U")
        LimpiaCamposDetalleNC()
    End Sub

    Private Sub dgvDetalleNC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleNC.CellClick
        If e.RowIndex > -1 Then
            Me.txtProducto.Text = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("PRODUCT").Value
            Me.txtDescripcion.Text = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("NOMBRE_PRODUCTO").Value
            Me.cmbUNIDAD_MEDIDA.SelectedValue = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("UNIDAD_MEDIDA").Value
            Me.txtCantidad.Text = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("CANTIDAD").Value
            Me.txtPrecio.Text = Format(Me.dgvDetalleNC.Rows(e.RowIndex).Cells("PRECIO_UNITARIO").Value, "0.00000")
            CostoU = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("COSTO_UNITARIO").Value
            subgrupoProd = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("CODIGO_GRUPO").Value
            grupoProd = Me.dgvDetalleNC.Rows(e.RowIndex).Cells("CODIGO_SUBGRUPO").Value
            LineaMod = e.RowIndex
            If Val(Me.txtProducto.Text) > 0 Then
                Me.txtDescripcion.ReadOnly = True
                Me.txtPrecio.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub btnGuardarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGuardarDetalle.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btnGuardarDetalle_Click(sender, e)
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Mtto de Abonos y notas de abonos
    Private Sub AbonosPorNotaCredito(ByVal cia As Integer _
                                , ByVal numAbono As Integer, ByVal formaPago As Integer _
                                , ByVal abono As Double, ByVal fechaAbono As Date, ByVal saldo As Double, ByVal numDoc As String _
                                , ByVal concepto As String, ByVal bco As Integer, ByVal ctaBco As Integer, ByVal centro As Integer _
                                , ByVal fechaContable As Date, ByVal origen As Integer, ByVal IUD As String)
        Dim res As Integer = 0
        Try
            Sql = " Execute sp_FACTURACION_ABONOS_NOTAS_DEBITO " & vbCrLf
            Sql &= " @COMPAÑIA = " & cia & vbCrLf
            Sql &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            Sql &= ",@ORDEN_VENTA = " & OVCCF & vbCrLf
            Sql &= ",@NUMERO_FACTURA = " & Me.txtCCF.Text & vbCrLf
            Sql &= ",@NUMERO_ABONO = " & numAbono & vbCrLf
            Sql &= ",@CLIENTE = " & Me.txtCliente.Text & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = 2" & vbCrLf
            Sql &= ",@FORMA_PAGO = " & formaPago & vbCrLf
            Sql &= ",@ABONO = " & abono & vbCrLf
            Sql &= ",@FECHA_ABONO = '" & Format(fechaAbono, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@SALDO = " & saldo & vbCrLf
            Sql &= ",@NUMERO_DOCUMENTO = '" & numDoc & "'" & vbCrLf
            Sql &= ",@CONCEPTO_ABONO = '" & concepto & "'" & vbCrLf
            Sql &= ",@BANCO = " & bco & vbCrLf
            Sql &= ",@CUENTA_BANCARIA = " & ctaBco & vbCrLf
            Sql &= ",@CENTRO_COSTO = " & centro & vbCrLf
            Sql &= ",@FECHA_CONTABLE = '" & Format(fechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@ORIGEN = " & origen & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "'" & vbCrLf
            Sql &= ",@NUMERO_REMESA = ''"
            sqlCmd.CommandText = Sql
            res = jClass.ejecutarComandoSql(sqlCmd)
            If res > 0 Then
                Sql = "SELECT ISNULL(MAX(NUMERO_ABONO), 0) " & vbCrLf
                Sql &= "FROM FACTURACION_ABONOS " & vbCrLf
                Sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "  AND ORDEN_VENTA = " & OVCCF & vbCrLf
                Sql &= "  AND BODEGA = " & Me.cmbBODEGA.SelectedValue & vbCrLf
                Sql &= "  AND NUMERO_FACTURA = " & Me.txtCCF.Text
                res = 0
                res = jClass.obtenerEscalar(Sql)
                If res > 0 Then
                    Sql = "UPDATE FACTURACION_ABONOS " & vbCrLf
                    Sql &= "SET TRANSACCION = " & Transac & ", PARTIDA = " & numPDA & vbCrLf
                    Sql &= "WHERE COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "  AND TIPO_DOCUMENTO = 2" & vbCrLf
                    Sql &= "  AND ORDEN_VENTA = " & OVCCF & vbCrLf
                    Sql &= "  AND NUMERO_FACTURA = " & Me.txtCCF.Text & vbCrLf
                    Sql &= "  AND NUMERO_ABONO = " & res
                    sqlCmd.CommandText = Sql
                    res = jClass.ejecutarComandoSql(sqlCmd)
                End If
                MsgBox("Aplicación de Abono realizada con éxito", MsgBoxStyle.Information, "Mensaje")
                Me.btnContabilizar.Enabled = False
            End If
        Catch ex As Exception
            jClass.msjError(ex, "Nota de Crédito-Abono")
            _error_ = True
        End Try
    End Sub

    Private Sub btnContabilizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContabilizar.Click
        Dim res As Integer
        Dim abonos, saldo As Double
        If FormaPagoCCF = 2 Then
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDA_DEVOLUCION_FACTURACION " & vbCrLf
            Sql &= "@COMPAÑIA           = " & Compañia & vbCrLf
            Sql &= ", @CENTRO_COSTO       = " & jClass.obtenerEscalar("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue) & vbCrLf
            Sql &= ", @TIPO_DOCUMENTO     = 2" & vbCrLf
            Sql &= ", @ORIGEN             = " & Origen & vbCrLf
            Sql &= ", @NUMERO_DOCUMENTO   = " & Me.txtCCF.Text & vbCrLf
            Sql &= ", @FECHA_CONTABLE     = '" & Me.dpFECHA_CONTABLE.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @CUENTA_BANCO       = 0" & vbCrLf
            Sql &= ", @DOCUMENTO_ASOCIADO = 0" & vbCrLf
            Sql &= ", @TOTAL              = " & Me.txtSUBTOTAL.Text & vbCrLf
            Sql &= ", @CONCEPTO           = 'Nota de Crédito No. " & Me.txtNC.Text & " del " & Me.dpFECHA_CONTABLE.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @USUARIO            = '" & Usuario & "'" & vbCrLf
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Transac = Table.Rows(0).Item(0)
                numPDA = Table.Rows(0).Item(1)
                Sql = "UPDATE FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= "SET CONTABILIZADO = 1, NUMERO_PARTIDA = " & numPDA & vbCrLf
                Sql &= "WHERE COMPAÑIA = " & Compañia & " AND TIPO_DOCUMENTO = 4 AND NUMERO_FACTURA = " & Me.txtNC.Text & " AND ORDEN_VENTA = " & Numero_OV
                sqlCmd.CommandText = Sql
                res = jClass.ejecutarComandoSql(sqlCmd)
            End If
            Sql = "EXECUTE [dbo].[sp_FACTURACION_SUMA_ABONOS] " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@BODEGA         = " & Me.cmbBODEGA.SelectedValue & vbCrLf
            Sql &= ",@ORDEN_VENTA    = " & Numero_OV & vbCrLf
            Sql &= ",@CLIENTE        = " & Me.txtCliente.Text & vbCrLf
            Sql &= ",@NUMERO_FACTURA = " & Me.txtCCF.Text & vbCrLf
            Sql &= ",@BANDERA        = 1" & vbCrLf
            abonos = jClass.obtenerEscalar(Sql)
            saldo = Val(Me.lblTotal.Text.Replace(",", "")) - abonos
            If saldo >= Val(Me.txtTotFact.Text) Then
                saldo = saldo - Val(Me.txtTotFact.Text)
                AbonosPorNotaCredito(Compañia, 0, 0, Me.txtTotFact.Text, Me.dpFECHA_CONTABLE.Value.Date, saldo, Numero_OV & "-" & Me.txtNC.Text & "-0", "Nota de Crédito No. " & Me.txtNC.Text & " del " & Me.dpFECHA_CONTABLE.Value.ToString("dd/MM/yyyy"), 0, 0, jClass.obtenerEscalar("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue), Me.dpFECHA_CONTABLE.Value.Date, Origen, "N")
            End If
        End If
    End Sub
End Class