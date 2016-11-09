Imports System.Data.SqlClient

Public Class Facturacion_Bodegas_Devoluciones
    'Constructor
    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean
    Dim FactCreada As Boolean = False
    Dim totRegFact As Integer
    Dim UMIndex As Integer
    Dim DisponibleSocio, PorcIVA, PorcCESC As Double
    Dim codClie As Integer
    Dim TipClie As Integer
    Dim TipContrib As Integer
    Dim CondPago As Integer
    Dim NumOV As Integer
    Dim giro As String
    Dim exento As Boolean
    Dim NRC As String
    Dim dirClie As String
    Dim NumSerie As Integer
    Dim TipMovInv, TipMovInvFact, TipMovInvCCF, TipoSolicitud As Integer

    'Variables para almacenar el grupo y subgrupo de los productos
    Public grupoProd As Integer
    Public subgrupoProd As Integer
    'Conexion
    Dim Table As DataTable
    Dim Table2 As DataTable

    Private Sub Facturacion_Bodegas_Almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmFact As Form = jClass.CheckForm("Facturacion_Bodegas_Almacen")
        If frmFact IsNot Nothing Then
            frmFact.Close()
        End If
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA_CONTABLE.Value = multi.FechaActual_Servidor()
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        multi.CargaFormaPago(Compañia, Me.cmbFormaPago)
        multi.CargaTipoDocumentoFact(Compañia, Me.cmbTipDoc)
        multi.CargaPeriodo(Compañia, Me.cmbPeriodoPago)
        Me.cmbFormaPago.SelectedIndex = 1
        multi.CargaCondicionPago(Compañia, Me.cmbFormaPago.SelectedValue, Me.cmbCONDICION_PAGO)
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        Me.cmbTipDoc.SelectedIndex = 0
        Iniciando = False
        obtieneCentroCosto()
        ParamBodegas()
        generaGrid()
        Label14.Text = "Siguiente Numero Factura a Imprimir: " & ObtieneNumeroFactura()
    End Sub

    Private Sub obtieneCentroCosto()
        Dim sqlCmd As New SqlCommand
        If Not Iniciando Then
            sql = " Execute dbo.sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO_BODEGA "
            sql &= Compañia
            sql &= ", " & Me.cmbBODEGA.SelectedValue
            sql &= ", 1"
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count = 1 Then
                CC = Table.Rows(0).Item("Centro Costo")
            Else
                CC = 0
            End If
        End If
    End Sub

    Public Sub busquedaClientes()
        Dim Socios As New Facturacion_BusquedaSocios
        Socios.Compañia_Value = Compañia
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        Dim Clientes As New Contabilidad_BusquedaClientes
        Clientes.Compañia_Value = Compañia
        Clientes.cmbCOMPAÑIA.Enabled = False
        Clientes.numForm = 46882
        Clientes.Bodega_Fact = Me.cmbBODEGA.SelectedValue
        If Not Me.chkCliExt.Checked Then
            Socios.ShowDialog()
            datosSocio(Producto, Numero)
        Else
            Clientes.ShowDialog()
            datosCliente(Producto, Numero)
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        obtieneCentroCosto()
        If Not Iniciando Then
            Label14.Text = "Siguiente Numero Factura a Imprimir: " & ObtieneNumeroFactura()
        End If
        ParamBodegas()
    End Sub

    Private Function ObtieneNumeroFactura() As Integer
        Dim sqlCmd As New SqlCommand
        Dim numFact As Integer = 0
        NumSerie = 0
        FactCreada = False
        sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
        sql &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", '0'" 'DESCRIPCION_SERIE
        sql &= ", " & Me.cmbTipDoc.SelectedValue
        sql &= ", 1" 'BANDERA
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            For a As Integer = 0 To Table.Rows.Count - 1
                If Table.Rows(a).Item("Activa") Then
                    numFact = Table.Rows(a).Item("Actual")
                    NumSerie = Table.Rows(a).Item("Serie")
                End If
            Next
        End If
        If NumSerie <= 0 Then
            MsgBox("Verifique las Series de Facturacion para la Bodega:" & vbCrLf & cmbBODEGA.Text, MsgBoxStyle.Critical, "Numero de Factura no válido")
            numFact = -1
        End If
        Return numFact
    End Function

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        If numSocio <> "" Then
            Try
                sql = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
                sql &= Compañia
                sql &= ", '" & numSocio & "'"
                sql &= ", " & codEmp
                sql &= ", 13" 'BANDERA
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.lblCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    If Me.txtNomFact.Text.Length = 0 Then
                        Me.txtNomFact.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    End If
                    Me.txtTelCliente.Text = Table.Rows(0).Item("TELEFONO")
                    Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                    origen = Table.Rows(0).Item("ORIGEN")
                    codClie = 0
                    giro = "Socio ASTAS"
                    NRC = ""
                    exento = 0
                    TipClie = 1
                    TipContrib = 0
                    dirClie = ""
                Else
                    DisponibleSocio = 0
                    Origen = 0
                    MsgBox("No se encontraron datos para el socio: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    Private Sub datosCliente(ByVal numCliente As String, ByVal NIT As String)
        Dim sqlCmd As New SqlCommand
        If numCliente.Length > 0 Then
            Try
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Compañia
                sql &= ", '" & numCliente & "'"
                sql &= ", '" & NIT & "' "
                sql &= ", 2"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("Cliente")
                    Me.lblCodBuxis.Text = "0"
                    Me.txtNombreCliente.Text = Table.Rows(0).Item("Nombre")
                    If Me.txtNomFact.Text.Length = 0 Then
                        Me.txtNomFact.Text = Table.Rows(0).Item("Nombre")
                    End If
                    Me.txtTelCliente.Text = Table.Rows(0).Item("Teléfono")
                    Me.txtDUICliente.Text = Table.Rows(0).Item("DUI")
                    Me.txtNITCliente.Text = Table.Rows(0).Item("NIT")
                    DisponibleSocio = 0
                    origen = Table.Rows(0).Item("Origen")
                    codClie = Me.txtCliente.Text
                    giro = Table.Rows(0).Item("Giro")
                    NRC = Table.Rows(0).Item("NRC")
                    exento = Table.Rows(0).Item("Exento")
                    TipClie = Table.Rows(0).Item("Tipo Cliente")
                    TipContrib = Table.Rows(0).Item("Tipo Contribuyente")
                    dirClie = Table.Rows(0).Item("Dirección")
                Else
                    DisponibleSocio = 0
                    Origen = 0
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    Private Sub limpiaCampos(ByVal opcion As Integer)
        Me.lblCodBuxis.Text = ""
        Me.txtSUBTOTAL.Text = "0.00"
        Me.txtIVA.Text = "0.00"
        Me.txtTotFact.Text = "0.00"
        Me.txtNoFact.Text = ""
        Me.txtNumCuotas.Text = "0"
        Me.txtCliente.Clear()
        Me.txtNombreCliente.Clear()
        Me.txtNomFact.Clear()
        Me.txtNoRemesa.Clear()
        Me.txtNITCliente.Clear()
        Me.txtDUICliente.Clear()
        Me.txtTelCliente.Clear()
        Me.TextBox30.Clear()
        Me.dpFECHA_CONTABLE.Value = Today()
        Me.cmbBODEGA.Enabled = True
        Label14.Text = "Siguiente Numero Factura a Imprimir: " & ObtieneNumeroFactura()
        generaGrid()
    End Sub

    Private Sub totalizaFactura()
        Dim Subtotal, TotIVA, totFactura As Double
        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            If Me.cmbTipDoc.SelectedValue = 2 Then
                If exento Then
                    Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
                    TotIVA = 0
                Else
                    Subtotal += Val(row.Cells("PRECIO_TOTAL").Value) / (1 + (PorcIVA / 100)) '1.13
                    TotIVA += Val(row.Cells("PRECIO_TOTAL").Value) - (Val(row.Cells("PRECIO_TOTAL").Value) / (1 + (PorcIVA / 100)))
                End If
            Else
                Subtotal += Val(row.Cells("PRECIO_TOTAL").Value)
            End If
        Next
        totFactura = Subtotal + TotIVA
        Me.txtSUBTOTAL.Text = Subtotal.ToString("#,##0.00")
        Me.txtIVA.Text = TotIVA.ToString("#,##0.00")
        Me.txtTotFact.Text = totFactura.ToString("#,##0.00")
    End Sub

    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        Dim sqlCmd As New SqlCommand
        Dim Cliente As DataTable
        If Me.txtCliente.Text <> Nothing Then
            If Not chkCliExt.Checked Then
                Numero = "0"
                datosSocio(Me.txtCliente.Text, Numero)
            Else
                sql = "SELECT NOMBRE, NIT FROM dbo.CONTABILIDAD_CATALOGO_CLIENTES WHERE CLIENTE = " & Me.txtCliente.Text & " AND COMPAÑIA = " & Compañia
                sqlCmd.CommandText = sql
                Cliente = jClass.obtenerDatos(sqlCmd)
                If Cliente.Rows.Count = 1 Then
                    datosCliente(Me.txtCliente.Text, Cliente.Rows(0).Item("NIT"))
                Else
                    MsgBox("No se encontraron datos para el Cliente: " + Me.txtCliente.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            End If
        End If
    End Sub

    Private Function actualizaCorrelativoFactura(ByVal cia As Integer, ByVal bodega As Integer, ByVal serie As Integer, ByVal tipoDoc As Integer) As Integer
        Dim numFact As Integer
        Try
            sql = "Execute sp_FACTURACION_CATALOGO_GENERA_CORRELATIVOS_SERIES "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", 0"
            numFact = jClass.obtenerEscalar(sql)
            If numFact = -1 Then
                MsgBox("Serie llegó a su límite. Intente con otra.", MsgBoxStyle.Exclamation, "Correlativo Factura")
                Return 0
            Else
                Return numFact
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            Return 0
        End Try
    End Function

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
                                            ByVal numRemesa As String)
        'GuardaEliminaOrdenVentaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NomFact, Concepto, FormaPago, CondPago, TipClie, TipContrib, exento, NRC, giro, codBuxis, CodCliente, dirClie, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, "I")
        GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, NoFact, NRC, TipContrib, exento, CondPago, NomFact, SubTotal, IVA, Total, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, TipClie, TipContrib, dirClie, giro, "I")
    End Sub

    Private Sub GrabaDetalleFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As String, ByVal descProd As String, ByVal NoFact As Integer, ByVal FechaMov As DateTime, _
                                    ByVal UM As Integer, ByVal cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, _
                                    ByVal TipDoc As Integer, ByVal numdoc As String, ByVal NomFact As String, ByVal SubTotalFact As Double, ByVal impConcepto As Short, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal CodCliente As String, ByVal txtDUI As String, ByVal txtNIT As String, _
                                    ByVal fechafact As DateTime, ByVal numCuotas As Integer, ByVal descontarDesde As Date, ByVal descuentoAguinaldo As Double, ByVal descuentoBonificacion As Double, ByVal periodoPago As String, ByVal numRemesa As String, ByVal Tot_Factura As Double, ByVal totIVA As Double)
        'GuardaEliminaRegistroFacturaDetalleOV(CIA, Bodega, codProd, descProd, UM, cant, CostoU, CostoT, PrecProd, Grupo, SubGrupo, exento, "I")
        GuardaEliminaRegistroFacturaGeneradaDetalle(CIA, Bodega, TipDoc, numdoc, codProd, descProd, UM, cant, CostoU, CostoT, PrecProd, Total, Grupo, SubGrupo, "I")
        GuardaEliminaMovimientoInventarioDetalle(CIA, Bodega, TipDoc, numdoc, codProd, cant, CostoU, CostoT, Me.dpFECHA_CONTABLE.Value, TipMovInv, FPro.ObtieneCorrelativoInventario(CIA, Bodega, TipDoc, Val(NoFact)), "I")
        'If FactCreada Then
        '    GuardaEliminaFacturaGeneradaEncabezado(CIA, Bodega, codClie, TipDoc, numdoc, NRC, TipClie, exento, CondPago, NomFact, SubTotalFact, totIVA, Tot_Factura, impConcepto, Concepto, FormaPago, codBuxis, CodCliente, txtDUI, txtNIT, fechafact, numCuotas, descontarDesde, descuentoAguinaldo, descuentoBonificacion, periodoPago, numRemesa, "U")
        'End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim numFact As Integer = 0
        Dim TablePend As DataTable
        Dim Subtotal, IVA, Total, CapitalAdeudado As Double
        Dim Subtotal1, IVA1, Total1, AplicarCESC As Double
        Dim Valor_Devuelto As Double = 0
        Dim porAG, porBO As Double
        Dim sqlCmd As New SqlCommand
        Dim numSoli As Integer
        Dim msj, msjUsr, solsAnular As String
        AplicarCESC = 0
        For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
            If row.Cells("Anular").Value Then
                numFact += 1
            End If
        Next
        If numFact = 0 Then
            MsgBox("Debe marcar al menos un producto a devolver", MsgBoxStyle.Information, "Devolución")
            Return
        End If
        numFact = ObtieneNumeroFactura()
        If numFact <= 0 Then
            Return
        End If
        'TC OCTUBRE
        For i As Integer = 0 To Me.dgvCuentasEquivalentes.Rows.Count - 1
            Dim row As DataGridViewRow = Me.dgvCuentasEquivalentes.Rows(i)
            If row.Cells(0).Value And row.Cells("A_DEVOLVER").Value > 0 And (row.Cells("A_DEVOLVER").Value <= row.Cells("CANTIDAD").Value) Then
                If Me.cmbTipDoc.SelectedValue = 2 Then
                    If exento Then
                        Subtotal1 += Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value
                        IVA1 = 0
                    Else
                        Subtotal1 += Val(row.Cells("PRECIO_UNITARIO").Value) / (1 + (PorcIVA / 100)) * row.Cells("A_DEVOLVER").Value
                        IVA1 += (Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value) - ((Val(row.Cells("PRECIO_UNITARIO").Value) / (1 + (PorcIVA / 100))) * row.Cells("A_DEVOLVER").Value)
                    End If
                Else
                    Subtotal1 += Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value
                End If
                If row.Cells("APLICA_CESC").Value Then
                    AplicarCESC += Math.Round((Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value) / (1 + (PorcIVA / 100)), 2)
                End If
                Total1 = Subtotal1 + IVA1
            End If
        Next

        crearFactura_OVEncabezado(Compañia, Me.cmbBODEGA.SelectedValue, Today(), Me.cmbTipDoc.SelectedValue, _
                                numFact, Me.cmbFormaPago.SelectedValue, Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtNomFact.Text, _
                                Me.txtTelCliente.Text, Me.txtDUICliente.Text, Me.txtNITCliente.Text, Me.TextBox30.Text, _
                                IIf(Me.chkImpConcepto.Checked, 1, 0), Subtotal1, IVA1, Total1, 1, Me.dpFechaDesc.Value, _
                                0, Math.Round(AplicarCESC * (PorcCESC / 100), 2), Me.cmbPeriodoPago.SelectedValue, "")
        'For Each row As DataGridViewRow In Me.dgvCuentasEquivalentes.Rows
        'JASC 27082013
        For i As Integer = 0 To Me.dgvCuentasEquivalentes.Rows.Count - 1
            Dim row As DataGridViewRow = Me.dgvCuentasEquivalentes.Rows(i)
            If row.Cells(0).Value And row.Cells("A_DEVOLVER").Value > 0 And (row.Cells("A_DEVOLVER").Value <= row.Cells("CANTIDAD").Value) Then
                If Me.cmbTipDoc.SelectedValue = 2 Then
                    If exento Then
                        Subtotal += Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value
                        IVA = 0
                    Else
                        Subtotal += Val(row.Cells("PRECIO_UNITARIO").Value) / (1 + (PorcIVA / 100)) * row.Cells("A_DEVOLVER").Value
                        IVA += (Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value) - ((Val(row.Cells("PRECIO_UNITARIO").Value) / (1 + (PorcIVA / 100))) * row.Cells("A_DEVOLVER").Value)
                    End If
                Else
                    Subtotal += Val(row.Cells("PRECIO_UNITARIO").Value) * row.Cells("A_DEVOLVER").Value
                End If
                Total = Subtotal + IVA
                GrabaDetalleFactura(Compañia, Me.cmbBODEGA.SelectedValue, _
                                    row.Cells("PRODUCTO").Value, _
                                    row.Cells("DESCRIPCION_PRODUCTO").Value, numFact, Me.dpFECHA_CONTABLE.Value, _
                                    row.Cells("UNIDAD_MEDIDA").Value, _
                                    row.Cells("A_DEVOLVER").Value, _
                                    row.Cells("COSTO_UNITARIO").Value, _
                                    row.Cells("COSTO_UNITARIO").Value * row.Cells("A_DEVOLVER").Value, _
                                    row.Cells("PRECIO_UNITARIO").Value, _
                                    row.Cells("PRECIO_UNITARIO").Value * row.Cells("A_DEVOLVER").Value, _
                                    grupoProd, subgrupoProd, Me.cmbTipDoc.SelectedValue, numFact, Me.txtNomFact.Text, _
                                    Subtotal, Me.chkImpConcepto.Checked, Me.TextBox30.Text, Me.cmbFormaPago.SelectedValue, _
                                    Me.lblCodBuxis.Text, Me.txtCliente.Text, Me.txtDUICliente.Text, _
                                    Me.txtNITCliente.Text, Me.dpFECHA_CONTABLE.Value, 0, Me.dpFechaDesc.Value, _
                                    0, 0, Me.cmbPeriodoPago.SelectedValue, "", Total, IVA)
                Valor_Devuelto += row.Cells("PRECIO_UNITARIO").Value * row.Cells("A_DEVOLVER").Value
                sql = "UPDATE dbo.FACTURACION_GENERADA_DETALLE SET DEVOLUCION_CANTIDAD = DEVOLUCION_CANTIDAD + " & row.Cells("A_DEVOLVER").Value
                sql &= " WHERE Compañia = " & Compañia
                sql &= " AND BODEGA = " & row.Cells("BODEGA").Value
                sql &= " AND ORDEN_VENTA = " & row.Cells("ORDEN_VENTA").Value
                sql &= " AND TIPO_DOCUMENTO = " & row.Cells("TIPO_DOCUMENTO").Value
                sql &= " AND NUMERO_FACTURA = " & row.Cells("NUMERO_FACTURA").Value
                sql &= " AND LINEA = " & row.Cells("LINEA").Value
                sql &= " AND PRODUCTO = " & row.Cells("PRODUCTO").Value
                sqlCmd.CommandText = sql
                jClass.ejecutarComandoSql(sqlCmd)
            Else
                If row.Cells(0).Value = True And (row.Cells("A_DEVOLVER").Value > row.Cells("CANTIDAD").Value) Then
                    MsgBox("La cantidad a devolver no puede ser mayor a la vendida...", MsgBoxStyle.Critical, "Devolución")
                    Return
                End If
            End If
        Next
        imprimeFactura(Compañia, Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, numFact, NumOV, "")
        'SE RECALCULA LA DEUDA DEL SOCIO SI ES A CREDITO Y SI HAY SALDO PENDIENTE
        sql = "SELECT N_SOLICITUD FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND TIPO_FACTURA = " & Me.cmbTipDoc.SelectedValue & " AND NUMERO_FACTURA = " & Me.txtNoFact.Text & " AND CODIGO_BUXIS = " & Me.lblCodBuxis.Text
        Table2 = jClass.obtenerDatos(New SqlCommand(sql))
        solsAnular = ""
        If Table2.Rows.Count > 0 Then
            For i As Integer = 0 To Table2.Rows.Count - 1
                solsAnular &= IIf(i = 0, "", ",") & Table2.Rows(i).Item(0)
            Next
            sql = "SELECT ISNULL(SUM(CAPITAL),0) AS CAPITAL, COUNT(COMPAÑIA) AS CUOTAS FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD IN (" & solsAnular & ") AND CAPITAL_D = 0"
            sqlCmd.CommandText = sql
            TablePend = jClass.obtenerDatos(sqlCmd)
            CapitalAdeudado = TablePend.Rows(0).Item("CAPITAL") - Total
            If TablePend.Rows(0).Item("CAPITAL") <> Val(Me.txtTotFact.Text) Then
                msj = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE DECRIPCION LIKE '%NOTIFICA%'")
                msjUsr = msj.Substring(msj.IndexOf(":") + 1).Trim
                msj = "Se ha realizado una devolución a fact.No." & Me.txtNoFact.Text & vbCrLf
                msj &= "El valor original es de $ " & Me.txtTotFact.Text & vbCrLf
                msj &= " y el capital pendiente es de $ " & CapitalAdeudado & vbCrLf
                msj &= " FAVOR VERIFICAR SI LA NUEVA PROGRAMACION ES CORRECTA."
                sql = "INSERT INTO [dbo].[USUARIOS_MENSAJES]" & vbCrLf
                sql &= "           ([COMPAÑIA]" & vbCrLf
                sql &= "           ,[USUARIO_ENVIO]" & vbCrLf
                sql &= "           ,[USUARIO_RECEPCION]" & vbCrLf
                sql &= "           ,[MENSAJE]" & vbCrLf
                sql &= "           ,[FECHA]" & vbCrLf
                sql &= "           ,[ESTADO]" & vbCrLf
                sql &= "           ,[ASUNTO])" & vbCrLf
                sql &= "     VALUES" & vbCrLf
                sql &= "           (" & Compañia & vbCrLf
                sql &= "           ,'" & Usuario & "'" & vbCrLf
                sql &= "           ,'" & msjUsr & "'" & vbCrLf
                sql &= "           ,'" & msj & "'" & vbCrLf
                sql &= "           ,'" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= "           ,1" & vbCrLf
                sql &= "           ,'DEVOLUCION FACT.No." & numFact & "')"
                jClass.Ejecutar_ConsultaSQL(sql)
            End If
            '--------------------------------------------------------------
            'VALIDACION DE LA FECHA DE DESCUENTO
            'se busca el siguiente periodo de pago sin enviar
            sql = "SELECT ISNULL(MIN(FECHA_PAGO),CONVERT(DATETIME, '" & Format(Me.dpFechaDesc.Value, "dd/MM/yyyy") & "', 103)) AS FECHA " & vbCrLf
            sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE" & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND NUMERO_SOLICITUD IN (" & solsAnular & ")" & vbCrLf
            sql &= "   AND ENVIADA = 0"
            Me.dpFechaDesc.Value = CDate(jClass.obtenerEscalar(sql))
            Me.txtNumCuotas.Text = TablePend.Rows(0).Item("CUOTAS").ToString
            For i As Integer = 0 To Table2.Rows.Count - 1
                eliminaSolicitud(numFact, Me.cmbTipDoc.SelectedValue, Table2.Rows(i).Item(0))
            Next
            '--------------------------------------------------------------
            'Si son iguales las cantidades significa que solo 
            'se descontarán en esos pagos (AG o BO)y no hay cuotas a 
            'descontar del salario
            If Val(Me.txtDescAGUI.Text) = Val(Me.txtTotFact.Text) Then
                Me.txtDescAGUI.Text = CapitalAdeudado.ToString("0.00")
                Me.txtDescBONI.Text = "0.00"
            End If
            If Val(Me.txtDescBONI.Text) = Val(Me.txtTotFact.Text) Then
                Me.txtDescBONI.Text = CapitalAdeudado.ToString("0.00")
                Me.txtDescAGUI.Text = "0.00"
            End If
            '--------------------------------------------------------------
            'Si hay valor en AG y BO y el total de la fact. es igual
            'a la suma de los dos significa que se descontará en esos pagos
            If Val(Me.txtDescAGUI.Text) > 0 And Val(Me.txtDescBONI.Text) > 0 And (Val(Me.txtDescAGUI.Text) + Val(Me.txtDescBONI.Text)) = Val(Me.txtTotFact.Text) Then
                porAG = (Val(Me.txtDescAGUI.Text) / Val(Me.txtTotFact.Text))
                Me.txtDescAGUI.Text = (Math.Round((CapitalAdeudado * porAG), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
                Me.txtDescBONI.Text = (CapitalAdeudado - Val(Me.txtDescAGUI.Text)).ToString("0.00")
            End If
            '--------------------------------------------------------------
            'Si hay valor en AG y BO y el total de la fact. es mayor
            'a la suma de los dos significa que se descontará en esos pagos
            'una parte y el resto en cuotas en el salario
            If (Val(Me.txtDescAGUI.Text) > 0 Or Val(Me.txtDescBONI.Text) > 0) And (Val(Me.txtDescAGUI.Text) + Val(Me.txtDescBONI.Text)) < Val(Me.txtTotFact.Text) Then
                porBO = (Val(Me.txtDescBONI.Text) / Val(Me.txtTotFact.Text))
                Me.txtDescBONI.Text = (Math.Round((CapitalAdeudado * porBO), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
                porAG = (Val(Me.txtDescAGUI.Text) / Val(Me.txtTotFact.Text))
                Me.txtDescAGUI.Text = (Math.Round((CapitalAdeudado * porAG), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
                If Val(Me.txtDescBONI.Text) > 0 Then
                    Me.txtNumCuotas.Text = Val(Me.txtNumCuotas.Text) - 1
                End If
                If Val(Me.txtDescAGUI.Text) > 0 Then
                    Me.txtNumCuotas.Text = Val(Me.txtNumCuotas.Text) - 1
                End If
            End If
            '--------------------------------------------------------------
            If CapitalAdeudado > 0 Then
                numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
                FPro.SolicitudesFacturacionSocios(Compañia, TipoSolicitud, numSoli, Me.txtCliente.Text, Me.lblCodBuxis.Text, Now, 1, CapitalAdeudado - Val(Me.txtDescAGUI.Text) - Val(Me.txtDescBONI.Text), Val(Me.txtDescAGUI.Text), Val(Me.txtDescBONI.Text), Me.cmbPeriodoPago.SelectedValue, Me.txtNumCuotas.Text, Me.dpFechaDesc.Value, "Factura No. " & numFact & " (DEVOLUCION)", Me.cmbTipDoc.SelectedValue, numFact)
            End If
        End If
        limpiaCampos(0)
    End Sub

    Private Sub cargaFacturaDetalle(ByVal numfact As String, ByVal tipdoc As Integer, ByVal CIA As Integer, ByVal Bodega As Integer)
        Dim sqlCmd As New SqlCommand
        Dim descAguin, descBoni, subtotfact, ivaFact, totalfact As Double
        If Not Iniciando Then
            Try
                'Esto se hace para encontrar la ultima orden de venta correspondiente al numero de factura
                'ya que si existe el mismo numero de factura en la misma bodega el numero de orden de venta
                'nos sirve como filtro, si no se encuentra una orden de venta entonces el numero de factura
                'no se ha usado para la serie de correlativo actual
                sql = " SELECT ISNULL(MAX(ORDEN_VENTA), 0) FROM FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                sql &= " WHERE COMPAÑIA = " & CIA & vbCrLf
                sql &= "   AND BODEGA = " & Bodega & vbCrLf
                sql &= "   AND TIPO_DOCUMENTO = " & tipdoc & vbCrLf
                sql &= "   AND NUMERO_FACTURA = " & numfact & vbCrLf
                sql &= "   AND SERIE = " & NumSerie
                Numero_OV = jClass.obtenerEscalar(sql)

                sql = "SELECT FGE.NUMERO_FACTURA, FGE.SERIE, FGE.BODEGA, FGE.ORDEN_VENTA, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGE.NOMBRE_FACTURA, FGE.PERIODO_PAGO, FGE.CUOTAS, FGE.DESCONTAR_CUOTAS_DESDE, FGE.DESCUENTO_AGUINALDO, FGE.DESCUENTO_BONIFICACION, FGE.NUMERO_REMESA, FGE.SUB_TOTAL, FGE.TOTAL_IVA, FGE.TOTAL_FACTURA, FGE.CLIENTE, FGE.NIT, FGE.ANULADA, FGE.CONDICION_PAGO, FGE.RETENCION FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE"
                sql &= " WHERE FGE.COMPAÑIA = " & CIA
                sql &= "   AND FGE.BODEGA = " & Bodega
                sql &= "   AND FGE.TIPO_DOCUMENTO = " & tipdoc
                sql &= "   AND FGE.NUMERO_FACTURA = " & numfact
                sql &= "   AND FGE.ORDEN_VENTA = " & Numero_OV
                sqlCmd.CommandText = sql
                Table2 = jClass.obtenerDatos(sqlCmd)
                If Table2.Rows.Count > 0 Then
                    If Table2.Rows(0).Item("ANULADA") Then
                        MsgBox("Factura está Anulada", MsgBoxStyle.Critical, "Devoluciones")
                        Return
                    End If
                    If Not Table2.Rows(0).Item("FACTURA_IMPRESA") Then
                        MsgBox("Factura no está impresa, aún puede modificarse.", MsgBoxStyle.Critical, "Devoluciones")
                        Return
                    End If
                    If Table2.Rows(0).Item("FECHA_FACTURA") < Now.AddMonths(-3) Then
                        MsgBox("Invoice is older than " & Now.AddMonths(-3).ToShortDateString, MsgBoxStyle.Critical, "Returns")
                        Return
                    End If
                    FactCreada = True
                    NumSerie = Table2.Rows(0).Item("SERIE")
                    NumOV = Table2.Rows(0).Item("ORDEN_VENTA")
                    Me.dpFECHA_CONTABLE.Value = Table2.Rows(0).Item("FECHA_FACTURA")
                    Me.dpFechaDesc.Value = Table2.Rows(0).Item("DESCONTAR_CUOTAS_DESDE")
                    Me.cmbBODEGA.SelectedValue = Table2.Rows(0).Item("BODEGA")
                    If Table2.Rows(0).Item("CLIENTE") = 0 Then
                        Me.txtCliente.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO_AS")
                        Me.lblCodBuxis.Text = Table2.Rows(0).Item("CODIGO_EMPLEADO")
                        datosSocio(Me.txtCliente.Text, Me.lblCodBuxis.Text)
                        Me.chkCliExt.Checked = False
                    Else
                        Me.txtCliente.Text = Table2.Rows(0).Item("CLIENTE")
                        Me.lblCodBuxis.Text = "0"
                        datosCliente(Me.txtCliente.Text, Table2.Rows(0).Item("NIT"))
                        Me.chkCliExt.Checked = True
                    End If
                    Me.cmbFormaPago.SelectedValue = Table2.Rows(0).Item("FORMA_PAGO")
                    Me.cmbCONDICION_PAGO.SelectedValue = Table2.Rows(0).Item("CONDICION_PAGO")
                    CondPago = Table2.Rows(0).Item("CONDICION_PAGO")
                    Me.cmbPeriodoPago.SelectedValue = Table2.Rows(0).Item("PERIODO_PAGO")
                    Me.txtNumCuotas.Text = Table2.Rows(0).Item("CUOTAS")
                    Me.txtNoRemesa.Text = Table2.Rows(0).Item("NUMERO_REMESA")
                    subtotfact = Table2.Rows(0).Item("SUB_TOTAL")
                    ivaFact = Table2.Rows(0).Item("TOTAL_IVA")
                    totalfact = Table2.Rows(0).Item("TOTAL_FACTURA")
                    descAguin = Table2.Rows(0).Item("DESCUENTO_AGUINALDO")
                    descBoni = Table2.Rows(0).Item("DESCUENTO_BONIFICACION")
                    Me.txtCESC.Text = Format(Table2.Rows(0).Item("RETENCION"), "0.00")
                    Me.txtSUBTOTAL.Text = subtotfact.ToString("0.00")
                    Me.txtIVA.Text = ivaFact.ToString("0.00")
                    Me.txtTotFact.Text = totalfact.ToString("0.00")
                    Me.txtDescAGUI.Text = descAguin.ToString("0.00")
                    Me.txtDescBONI.Text = descBoni.ToString("0.00")
                    Me.cmbBODEGA.Enabled = False
                    Me.txtNomFact.Text = Table2.Rows(0).Item("NOMBRE_FACTURA")
                    sql = "SELECT FGE.IMPRIMIR_CONCEPTO AS ANULAR, FGD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(LTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA)) AS DESCRIPCION_UNIDAD_MEDIDA, (FGD.CANTIDAD - FGD.DEVOLUCION_CANTIDAD) AS CANTIDAD, FGD.CANTIDAD AS A_DEVOLVER, FGD.PRECIO_UNITARIO, FGD.PRECIO_TOTAL, FGD.BODEGA, FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO, FGE.NUMERO_FACTURA, FGD.LINEA, IME.TIPO_MOVIMIENTO, IME.MOVIMIENTO, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.CONCEPTO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA, FGE.ANULADA, FGD.COSTO_UNITARIO, FGD.COSTO_TOTAL, FGD.UNIDAD_MEDIDA, FGD.DEVOLUCION_CANTIDAD, FGD.APLICA_CESC " & vbCrLf
                    sql &= "FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_GENERADA_DETALLE FGD, dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM " & vbCrLf
                    sql &= "WHERE FGE.BODEGA = FGD.BODEGA AND FGE.COMPAÑIA = FGD.COMPAÑIA AND FGE.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO AND FGE.NUMERO_FACTURA = FGD.NUMERO_FACTURA AND FGD.ORDEN_VENTA = FGE.ORDEN_VENTA AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FGD.PRODUCTO = IMD.PRODUCTO AND FGD.COMPAÑIA = ICP.COMPAÑIA AND FGD.PRODUCTO = ICP.PRODUCTO AND ICUM.COMPAÑIA = FGD.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA AND IMD.ENTRADA_SALIDA = 0" & vbCrLf
                    sql &= " AND FGE.COMPAÑIA = " & CIA & vbCrLf
                    sql &= " AND FGE.BODEGA = " & Bodega & vbCrLf
                    sql &= " AND FGE.TIPO_DOCUMENTO = " & tipdoc & vbCrLf
                    sql &= " AND FGE.NUMERO_FACTURA = " & numfact & vbCrLf
                    sql &= " AND FGE.ORDEN_VENTA = " & Numero_OV & vbCrLf
                    sqlCmd.CommandText = sql
                    Table = jClass.obtenerDatos(sqlCmd)
                    Me.dgvCuentasEquivalentes.Columns.Clear()
                    Me.dgvCuentasEquivalentes.DataSource = Table
                    Me.dgvCuentasEquivalentes.Columns(0).HeaderText = ""
                    Me.dgvCuentasEquivalentes.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(0).Width = 25
                    Me.dgvCuentasEquivalentes.Columns(1).HeaderText = "Producto"
                    Me.dgvCuentasEquivalentes.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(1).Width = 70
                    Me.dgvCuentasEquivalentes.Columns(2).HeaderText = "Descripcion Producto"
                    Me.dgvCuentasEquivalentes.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(2).Width = 235
                    Me.dgvCuentasEquivalentes.Columns(3).HeaderText = "Unidad Medida"
                    Me.dgvCuentasEquivalentes.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(3).Width = 70
                    Me.dgvCuentasEquivalentes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvCuentasEquivalentes.Columns(4).HeaderText = "Cantidad"
                    Me.dgvCuentasEquivalentes.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(4).Width = 65
                    Me.dgvCuentasEquivalentes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvCuentasEquivalentes.Columns(5).HeaderText = "Cant. A Devolver"
                    Me.dgvCuentasEquivalentes.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(5).HeaderCell.Style.Font = New System.Drawing.Font("Arial", 9, 7, GraphicsUnit.Point)
                    Me.dgvCuentasEquivalentes.Columns(5).HeaderCell.Style.ForeColor = Color.Navy
                    Me.dgvCuentasEquivalentes.Columns(5).Width = 65
                    Me.dgvCuentasEquivalentes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvCuentasEquivalentes.Columns(6).HeaderText = "Precio Unit."
                    Me.dgvCuentasEquivalentes.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentasEquivalentes.Columns(6).Width = 80
                    Me.dgvCuentasEquivalentes.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvCuentasEquivalentes.Columns(7).HeaderText = "TOTAL"
                    Me.dgvCuentasEquivalentes.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    If Me.dgvCuentasEquivalentes.Rows.Count > 9 Then
                        Me.dgvCuentasEquivalentes.Columns(7).Width = 70
                    Else
                        Me.dgvCuentasEquivalentes.Columns(7).Width = 80
                    End If
                    Me.dgvCuentasEquivalentes.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    For a As Integer = 1 To Me.dgvCuentasEquivalentes.Columns.Count - 1
                        If a <> 5 Then
                            Me.dgvCuentasEquivalentes.Columns(a).ReadOnly = True
                        Else
                            Me.dgvCuentasEquivalentes.Columns(a).ReadOnly = False
                        End If
                        If a >= 8 Then
                            Me.dgvCuentasEquivalentes.Columns(a).Visible = False
                        End If
                    Next
                    For a As Integer = 0 To Me.dgvCuentasEquivalentes.Rows.Count - 1
                        If Me.dgvCuentasEquivalentes.Rows(a).Cells("DEVOLUCION_CANTIDAD").Value > 0 Then
                            Me.dgvCuentasEquivalentes.Rows(a).Cells("A_DEVOLVER").Value = Me.dgvCuentasEquivalentes.Rows(a).Cells("CANTIDAD").Value
                            Me.dgvCuentasEquivalentes.Rows(a).DefaultCellStyle.ForeColor = Color.Red
                            Me.dgvCuentasEquivalentes.Rows(a).DefaultCellStyle.SelectionForeColor = Color.Yellow
                            Me.dgvCuentasEquivalentes.Rows(a).DefaultCellStyle.SelectionBackColor = Color.Teal
                        End If
                    Next
                Else
                    MsgBox("No se encontró factura No." & Me.txtNoFact.Text, MsgBoxStyle.Critical, "Devoluciones")
                    NumOV = 0
                    FactCreada = False
                    limpiaCampos(0)
                    Me.cmbBODEGA.Enabled = True
                End If
                Label14.Text = "Siguiente Numero Factura a Imprimir: " & ObtieneNumeroFactura()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Cargar Factura")
            End Try
        End If
    End Sub

    Private Sub txtNoFact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFact.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub GuardaEliminaRegistroFacturaDetalleOV(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal es_exento As Boolean, ByVal Accion As String)
    '    Dim corre As Integer
    '    Dim sqlCmd As New SqlCommand
    '    Try
    '        sql = " Execute dbo.sp_FACTURACION_FACTURAS_DETALLE_IUD "
    '        sql &= CIA
    '        sql &= ", " & Bodega
    '        sql &= ", " & NumOV
    '        sql &= ", " & totRegFact
    '        sql &= ", " & codProd
    '        sql &= ", '" & descProd & "'"
    '        sql &= ", " & UM
    '        sql &= ", " & -(Cant)
    '        sql &= ", " & CostoU
    '        sql &= ", " & CostoT
    '        sql &= ", " & PrecProd
    '        sql &= ", " & Grupo
    '        sql &= ", " & SubGrupo
    '        sql &= ", " & origen
    '        sql &= ", '" & Usuario & "'"
    '        sql &= ", '" & Accion & "'"
    '        sqlCmd.CommandText = sql
    '        corre = jClass.ejecutarComandoSql(sqlCmd)
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje O.V. Detalle")
    '    End Try
    'End Sub

    Private Sub GuardaEliminaRegistroFacturaGeneradaDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal descProd As String, ByVal UM As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal PrecProd As Double, ByVal Total As Double, ByVal Grupo As Integer, ByVal SubGrupo As Integer, ByVal Accion As String)
        Dim corre As Integer
        Dim sqlcmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_FACTURACION_GENERADA_DETALLE_IUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & NumOV
            sql &= ", " & TipDoc
            sql &= ", " & NoFact
            sql &= ", " & totRegFact
            sql &= ", " & codProd
            sql &= ", '" & descProd & "'"
            sql &= ", " & UM
            sql &= ", " & -(Cant)
            sql &= ", 0"
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", " & PrecProd
            sql &= ", " & -(Total)
            sql &= ", " & Grupo
            sql &= ", " & SubGrupo
            sql &= ", " & origen
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "',0,0"
            sqlcmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlcmd)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Detalle")
        End Try
    End Sub

    Private Sub GuardaEliminaMovimientoInventarioDetalle(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal codProd As Integer, ByVal Cant As Double, ByVal CostoU As Double, ByVal CostoT As Double, ByVal FechaMov As Date, ByVal TipMov As Integer, ByVal Mov As Integer, ByVal Accion As String)
        Dim corre As Integer
        Dim sqlCmd As New SqlCommand
        Try
            sql = " Execute dbo.sp_INVENTARIOS_MOVIMIENTO_SIUD "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", 0" 'PROVEEDOR?
            sql &= ", " & TipMov 'TIPO_MOVIMIENTO
            sql &= ", " & Mov 'MOVIMIENTO A MODIFICAR/ELIMINAR
            sql &= ", 0" 'MOV1
            sql &= ", " & TipDoc 'TIPO_DOCUMENTO_CONTABLE
            sql &= ", " & NoFact 'NUMERO_DOCUMENTO_CONTABLE
            sql &= ", '" & Format(Now(), "dd/MM/yyyy") & "'" 'FECHA MOVIMIENTO
            sql &= ", 0" 'ANULADO?
            sql &= ", 1" 'PROCESADO
            sql &= ", " & codProd
            sql &= ", " & Cant
            sql &= ", " & CostoU
            sql &= ", " & CostoT
            sql &= ", 1" 'ENTRADA_SALIDA
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & Accion & "'"
            sql &= ", " & NumOV 'ORDEN_VENTA
            sqlCmd.CommandText = sql
            corre = jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje Inventario Detalle")
        End Try
    End Sub

    'Private Sub GuardaEliminaOrdenVentaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NomFact As String, ByVal Concepto As String, ByVal FormaPago As Integer, ByVal Condicion As Integer, ByVal TipoCliente As Integer, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal NRCCliente As String, ByVal GiroClie As String, ByVal codBuxis As String, ByVal codSocio As String, ByVal Direccion As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaMov As Date, _
    '                                                    ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, ByVal Accion As String)
    '    Dim totReg, CorreOV As Integer
    '    Dim sqlCmd As New SqlCommand
    '    Try
    '        If Not FactCreada Then
    '            CorreOV = FPro.actualizaNumDoc(CIA, "OV")
    '        End If
    '        sql = " Execute dbo.sp_FACTURACION_FATURAS_ENCABEZADO_IUD "
    '        sql &= CIA
    '        sql &= ", " & Bodega
    '        sql &= ", " & CorreOV
    '        sql &= ", '" & Format(FechaMov, "Short Date") & "'"
    '        sql &= ", " & TipDoc
    '        sql &= ", " & NoFact
    '        sql &= ", '" & Format(FechaMov, "Short Date") & "'"
    '        sql &= ", " & FormaPago
    '        sql &= ", " & Condicion
    '        sql &= ", " & codCliente
    '        sql &= ", " & codBuxis
    '        sql &= ", '" & codSocio & "'"
    '        sql &= ", " & TipoCliente
    '        sql &= ", " & TipoContribuyente
    '        sql &= ", '" & NomFact & "'"
    '        sql &= ", '" & Direccion & "'"
    '        sql &= ", '" & txtDUI & "'"
    '        sql &= ", '" & txtNIT & "'"
    '        sql &= ", '" & NRCCliente & "'"
    '        sql &= ", '" & GiroClie & "'"
    '        sql &= ", " & es_exento
    '        sql &= ", 0" 'Imprimir Concepto?
    '        sql &= ", '" & Concepto & "'"
    '        sql &= ", ''" 'Observaciones
    '        sql &= ", " & origen
    '        sql &= ", '" & Usuario & "'"
    '        sql &= ", '" & Accion & "'"
    '        sql &= ", '" & periodoPago & "'"
    '        sql &= ", " & Cuotas
    '        sql &= ", '" & Format(descontarDesde, "Short Date") & "'"
    '        sql &= ", " & DescuentoAguinaldo
    '        sql &= ", " & DescuentoBonificacion
    '        sql &= ", '" & NumRemesa & "'"
    '        sqlCmd.CommandText = sql
    '        totReg = jClass.ejecutarComandoSql(sqlCmd)
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
    '    End Try
    'End Sub

    Private Sub GuardaEliminaFacturaGeneradaEncabezado(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal codCliente As Integer, ByVal TipDoc As Integer, ByVal NoFact As String, ByVal NRCCliente As String, ByVal TipoContribuyente As Integer, ByVal es_exento As Short, ByVal Condicion As Integer, _
                                                       ByVal NomFact As String, ByVal Subtotal As Double, ByVal IVA As Double, ByVal Total As Double, ByVal impConcepto As Short, ByVal Concepto As String, _
                                                       ByVal FormaPago As Integer, ByVal codBuxis As String, ByVal codSocio As String, ByVal txtDUI As String, ByVal txtNIT As String, ByVal FechaFact As Date, _
                                                       ByVal Cuotas As Integer, ByVal descontarDesde As Date, ByVal DescuentoAguinaldo As Double, ByVal DescuentoBonificacion As Double, ByVal periodoPago As String, ByVal NumRemesa As String, ByVal TipClie As Integer, ByVal TipContrib As Integer, ByVal dirClie As String, ByVal giro As String, ByVal Accion As String)
        Dim totReg, corre As Integer
        Dim retencion As Double = 0
        Dim sqlCmd As New SqlCommand
        retencion = DescuentoBonificacion
        Try
            sql = "EXECUTE dbo.sp_FACTURACION_GENERADA_ENCABEZADO_IUD " & vbCrLf
            sql &= " @COMPAÑIA               = " & CIA & vbCrLf
            sql &= ",@BODEGA                 = " & Bodega & vbCrLf
            sql &= ",@ORDEN_VENTA            = " & NumOV & vbCrLf
            sql &= ",@NUMERO_FACTURA         = " & NoFact & vbCrLf
            sql &= ",@NOMBRE_FACTURA         = '" & NomFact & "'" & vbCrLf
            sql &= ",@FECHA_FACTURA          = '" & Format(FechaFact, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@CLIENTE                = " & codCliente & vbCrLf
            sql &= ",@SERIE                  = " & NumSerie & vbCrLf
            sql &= ",@CENTRO_COSTO           = " & CC & vbCrLf
            sql &= ",@TIPO_DOCUMENTO         = " & TipDoc & vbCrLf
            sql &= ",@FORMA_PAGO             = " & FormaPago & vbCrLf
            sql &= ",@PERIODO_PAGO           = '" & periodoPago & "'" & vbCrLf
            sql &= ",@CONDICION_PAGO         = " & Condicion & vbCrLf
            sql &= ",@CODIGO_EMPLEADO        = " & codBuxis & vbCrLf
            sql &= ",@CODIGO_EMPLEADO_AS     = '" & codSocio & "'" & vbCrLf
            sql &= ",@CONTRIBUYENTE          = " & TipoContribuyente & vbCrLf
            sql &= ",@DUI                    = '" & txtDUI & "'" & vbCrLf
            sql &= ",@NIT                    = '" & txtNIT & "'" & vbCrLf
            sql &= ",@NRC                    = '" & NRCCliente & "'" & vbCrLf
            sql &= ",@EXENTO                 = " & es_exento & vbCrLf
            sql &= ",@IMPRIMIR_CONCEPTO      = " & impConcepto & vbCrLf
            sql &= ",@CONCEPTO               = '" & Concepto & "'" & vbCrLf
            sql &= ",@SUB_TOTAL              = " & -(Subtotal) & vbCrLf
            sql &= ",@IVA                    = " & PorcIVA & vbCrLf
            sql &= ",@TOTAL_IVA              = " & -(IVA) & vbCrLf
            sql &= ",@RETENCION              = " & -(retencion) & vbCrLf
            sql &= ",@TOTAL_FACTURA          = " & -(Total + retencion) & vbCrLf
            sql &= ",@CUOTAS                 = " & Cuotas & vbCrLf
            sql &= ",@DESCONTAR_CUOTAS_DESDE = '" & Format(descontarDesde, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@DESCUENTO_AGUINALDO    = 0" & vbCrLf
            sql &= ",@DESCUENTO_BONIFICACION = 0" & vbCrLf
            sql &= ",@NUMERO_REMESA          = '" & NumRemesa & "'" & vbCrLf
            sql &= ",@ANULADA                = 0" & vbCrLf
            sql &= ",@ORIGEN                 = " & Origen & vbCrLf
            sql &= ",@USUARIO                = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD                    = '" & Accion & "'" & vbCrLf
            sql &= ",@BANCO                  = 0" & vbCrLf
            sql &= ",@CUENTA_BANCO           = ''" & vbCrLf
            sql &= ",@ORDEN_VENTA_FECHA      = '" & Format(FechaFact, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@NUMERO_FACTURA_FECHA   = '" & Format(FechaFact, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@TIPO_CLIENTE           = " & TipClie & vbCrLf
            sql &= ",@TIPO_CONTRIBUYENTE     = " & TipContrib & vbCrLf
            sql &= ",@DIRECCION              = '" & dirClie & "'" & vbCrLf
            sql &= ",@GIRO                   = '" & giro & "'" & vbCrLf
            sql &= ",@OBSERVACIONES          = ''" & vbCrLf
            sql &= ",@CAJA                   = 0" & vbCrLf
            sql &= ",@VALOR_REMESA           = 0.00" & vbCrLf

            sqlCmd.CommandText = sql
            totReg = jClass.ejecutarComandoSql(sqlCmd)
            If Accion = "I" Then
                corre = actualizaCorrelativoFactura(CIA, Bodega, NumSerie, TipDoc)
            End If
            FactCreada = True
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Factura Encabezado")
        End Try
    End Sub

    Private Function ValidaNumeroFacturaSerie(ByVal NoFact As Integer) As Boolean
        Dim sqlCmd As New SqlCommand
        sql = " Execute dbo.sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
        sql &= Compañia
        sql &= ", " & Me.cmbBODEGA.SelectedValue
        sql &= ", '0'" 'DESCRIPCION_SERIE
        sql &= ", " & Me.cmbTipDoc.SelectedValue
        sql &= ", 1" 'BANDERA
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            For a As Integer = 0 To Table.Rows.Count - 1
                If Table.Rows(a).Item("Activa") Then
                    If NoFact >= Table.Rows(a).Item("Inicio") And NoFact <= Table.Rows(a).Item("Final") And Table.Rows(a).Item("Activa") Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Private Sub generaGrid()
        Dim rowcount As Integer
        Try
            rowcount = dgvCuentasEquivalentes.RowCount
            For a As Integer = 1 To rowcount
                dgvCuentasEquivalentes.Rows.RemoveAt(0)
            Next
            Me.dgvCuentasEquivalentes.Columns.Clear()
            Me.dgvCuentasEquivalentes.Columns.Add("Anular", "")
            Me.dgvCuentasEquivalentes.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(0).Width = 25
            Me.dgvCuentasEquivalentes.Columns.Add("Producto", "Producto")
            Me.dgvCuentasEquivalentes.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(1).Width = 70
            Me.dgvCuentasEquivalentes.Columns.Add("descprod", "Descripción Producto")
            Me.dgvCuentasEquivalentes.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(2).Width = 235
            Me.dgvCuentasEquivalentes.Columns.Add("UM", "Unidad Medida")
            Me.dgvCuentasEquivalentes.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(3).Width = 70
            Me.dgvCuentasEquivalentes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvCuentasEquivalentes.Columns.Add("Cant", "Cantidad")
            Me.dgvCuentasEquivalentes.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(4).Width = 65
            Me.dgvCuentasEquivalentes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvCuentasEquivalentes.Columns.Add("A_DEVOLVER", "Cant. A Devolver")
            Me.dgvCuentasEquivalentes.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(5).Width = 65
            Me.dgvCuentasEquivalentes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvCuentasEquivalentes.Columns.Add("PU", "Precio Unit.")
            Me.dgvCuentasEquivalentes.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(6).Width = 80
            Me.dgvCuentasEquivalentes.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvCuentasEquivalentes.Columns.Add("total", "TOTAL")
            Me.dgvCuentasEquivalentes.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvCuentasEquivalentes.Columns(7).Width = 80
            Me.dgvCuentasEquivalentes.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtNoFact_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoFact.LostFocus
        Dim numfactura As String
        numfactura = Me.txtNoFact.Text
        If ValidaNumeroFacturaSerie(Val(numfactura)) Then
            cargaFacturaDetalle(Me.txtNoFact.Text, Me.cmbTipDoc.SelectedValue, Compañia, Me.cmbBODEGA.SelectedValue)
            Me.TextBox30.Text = "Devolución F.#" & Me.txtNoFact.Text.Trim()
        Else
            MsgBox("Factura No." & numfactura & " no corresponde a bodega: " & vbCrLf & Me.cmbBODEGA.Text, MsgBoxStyle.Exclamation, "Factura No Encontrada")
            ObtieneNumeroFactura()
            Return
        End If
    End Sub

    Private Function validaCamposVacios() As Boolean
        If Me.txtCliente.Text = Nothing Then
            MsgBox("Ingrese un codigo de Socio", MsgBoxStyle.Critical, "Campo Socio Vacio")
            Return False
        End If
        If Me.txtNomFact.Text = Nothing Then
            MsgBox("Ingrese un Nombre para la Factura", MsgBoxStyle.Critical, "Campo Nombre Factura Vacio")
            Return False
        End If
        Return True
    End Function

    Private Sub imprimeFactura(ByVal CIA As Integer, ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal numFactura As Integer, ByVal numPedido As Integer, ByVal Observ As String)
        Dim sqlCmd As New SqlCommand
        'Dim totFact, descAgui, descBoni, descPeriodos As Double
        'Dim numSoli As Integer
        Dim NumPartida As Integer
        Dim documento As CrystalDecisions.CrystalReports.Engine.ReportClass
        ' TODO TC
        '' ''Actualiza el numero de factura en la Orden de Venta
        ' ''sql = "UPDATE FACTURACION_GENERADA_ENCABEZADO SET NUMERO_FACTURA = " & numFactura & ", OBSERVACIONES = '" & Observ & "'"
        ' ''sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
        ' ''sqlCmd.CommandText = sql
        ' ''jClass.ejecutarComandoSql(sqlCmd)
        '
        'Imprimir factura
        If TipDoc = 1 Then
            documento = New Facturacion_Factura_Consumidor_Final_Almacen

            sql = "DECLARE @NUMSOLICITUD INT " & vbCrLf
            sql &= " SELECT @NUMSOLICITUD = N_SOLICITUD FROM COOPERATIVA_SOLICITUDES_AUTORIZACION " & vbCrLf
            sql &= " WHERE TIPO_FACTURA = " & TipDoc & " AND NUMERO_FACTURA = " & numFactura & " " & vbCrLf
            sql &= " IF @NUMSOLICITUD IS NULL " & vbCrLf
            sql &= " BEGIN " & vbCrLf
            sql &= " SET @NUMSOLICITUD = 0 " & vbCrLf
            sql &= " End " & vbCrLf
            sql &= " SET NOCOUNT ON;	" & vbCrLf
            sql &= " Select FGD.PRODUCTO " & vbCrLf
            sql &= " ,	CASE " & vbCrLf
            sql &= " WHEN VALOR_DESCUENTO  > 0  " & vbCrLf
            sql &= " THEN ('*' + ICP.DESCRIPCION_PRODUCTO)  " & vbCrLf
            sql &= " ELSE ICP.DESCRIPCION_PRODUCTO END AS DESCRIPCION_PRODUCTO " & vbCrLf
            sql &= " ,ICUM.DESCRIPCION_UNIDAD_MEDIDA " & vbCrLf
            sql &= " ,FGD.CANTIDAD " & vbCrLf
            sql &= " ,FGD.PRECIO_UNITARIO " & vbCrLf
            sql &= " ,FGD.PRECIO_TOTAL " & vbCrLf
            sql &= " ,CONVERT(FLOAT, FGE.TOTAL_FACTURA) AS TOT_FACT " & vbCrLf
            sql &= " ,FGE.BODEGA " & vbCrLf
            sql &= " ,ICB.DESCRIPCION_BODEGA " & vbCrLf
            sql &= " ,FGD.ORDEN_VENTA " & vbCrLf
            sql &= " ,FGD.TIPO_DOCUMENTO " & vbCrLf
            sql &= " ,FGE.NUMERO_FACTURA " & vbCrLf
            sql &= " ,FGD.LINEA " & vbCrLf
            sql &= " ,IME.TIPO_MOVIMIENTO " & vbCrLf
            sql &= " ,IME.MOVIMIENTO " & vbCrLf
            sql &= " ,FGE.CODIGO_EMPLEADO " & vbCrLf
            sql &= " ,FGE.CODIGO_EMPLEADO_AS " & vbCrLf
            sql &= " ,FGE.NOMBRE_FACTURA " & vbCrLf
            sql &= " ,FGE.CUOTAS " & vbCrLf
            sql &= " ,UPPER(DATENAME(MONTH,FGE.DESCONTAR_CUOTAS_DESDE)) AS INICIO_DESCUENTO_MES " & vbCrLf
            sql &= " ,DATENAME(YEAR,FGE.DESCONTAR_CUOTAS_DESDE) AS INICIO_DESCUENTO_AÑO " & vbCrLf
            sql &= " ,FGE.FORMA_PAGO " & vbCrLf
            sql &= " ,FCFP.DESCRIPCION_FORMA_PAGO " & vbCrLf
            sql &= " ,FGE.PERIODO_PAGO " & vbCrLf
            sql &= " ,FGE.IMPRIMIR_CONCEPTO " & vbCrLf
            sql &= " ,FGE.CONCEPTO " & vbCrLf
            sql &= " ,FGE.FECHA_FACTURA " & vbCrLf
            sql &= " ,FGE.FACTURA_IMPRESA " & vbCrLf
            sql &= " ,FGE.NUMERO_REMESA " & vbCrLf
            sql &= " ,FGE.DESCUENTO_AGUINALDO " & vbCrLf
            sql &= " ,FGE.DESCUENTO_BONIFICACION " & vbCrLf
            sql &= " ,CATSEC.DESCRIPCION_SECCION " & vbCrLf
            sql &= " ,FGE.CLIENTE " & vbCrLf
            sql &= " ,FGE.DESCONTAR_CUOTAS_DESDE " & vbCrLf
            sql &= " ,@NUMSOLICITUD AS NUMSOLI " & vbCrLf
            sql &= " ,FGD.PORCENTAJE_DESCUENTO " & vbCrLf
            sql &= " ,FGD.VALOR_DESCUENTO " & vbCrLf
            sql &= " FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE " & vbCrLf
            sql &= " INNER JOIN dbo.FACTURACION_GENERADA_DETALLE FGD " & vbCrLf
            sql &= " ON FGD.COMPAÑIA=FGE.COMPAÑIA AND FGD.BODEGA=FGE.BODEGA AND FGD.TIPO_DOCUMENTO=FGE.TIPO_DOCUMENTO AND FGD.NUMERO_FACTURA=FGE.NUMERO_FACTURA " & vbCrLf
            sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_SOCIOS CCS " & vbCrLf
            sql &= " ON FGE.CODIGO_EMPLEADO = CCS.CODIGO_EMPLEADO AND FGE.COMPAÑIA = CCS.COMPAÑIA " & vbCrLf
            sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_SECCIONES CATSEC " & vbCrLf
            sql &= " ON CCS.COMPAÑIA = CATSEC.COMPAÑIA AND CCS.DIVISION = CATSEC.DIVISION AND CCS.DEPARTAMENTO = CATSEC.DEPARTAMENTO AND CCS.SECCION = CATSEC.SECCION		" & vbCrLf
            sql &= " ,dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME " & vbCrLf
            sql &= " ,dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD " & vbCrLf
            sql &= " ,dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP " & vbCrLf
            sql &= " ,dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM " & vbCrLf
            sql &= " ,dbo.FACTURACION_CATALOGO_FORMA_PAGO FCFP " & vbCrLf
            sql &= " ,dbo.INVENTARIOS_CATALOGO_BODEGAS ICB	" & vbCrLf
            sql &= " WHERE FGE.BODEGA=" & cmbBODEGA.SelectedValue & " " & vbCrLf
            sql &= " AND IMD.ENTRADA_SALIDA = " & 1 & " " & vbCrLf
            sql &= " AND FGD.TIPO_DOCUMENTO = " & TipDoc & " " & vbCrLf
            sql &= " AND FGE.NUMERO_FACTURA = " & numFactura & " " & vbCrLf
            sql &= " AND FGE.COMPAÑIA = " & Compañia & " " & vbCrLf
            sql &= " AND FGE.TIPO_DOCUMENTO = IME.TIPO_DOCUMENTO_CONTABLE " & vbCrLf
            sql &= " AND FGE.NUMERO_FACTURA = IME.NUMERO_DOCUMENTO_CONTABLE " & vbCrLf
            sql &= " AND FGE.BODEGA = ICB.BODEGA " & vbCrLf
            sql &= " AND FGE.COMPAÑIA = FCFP.COMPAÑIA " & vbCrLf
            sql &= " AND FGE.FORMA_PAGO = FCFP.FORMA_PAGO " & vbCrLf
            sql &= " AND IME.COMPAÑIA = IMD.COMPAÑIA " & vbCrLf
            sql &= " AND IME.BODEGA = IMD.BODEGA " & vbCrLf
            sql &= " AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO " & vbCrLf
            sql &= " AND IME.MOVIMIENTO = IMD.MOVIMIENTO " & vbCrLf
            sql &= " AND FGD.PRODUCTO = IMD.PRODUCTO " & vbCrLf
            sql &= " AND FGD.COMPAÑIA = ICP.COMPAÑIA " & vbCrLf
            sql &= " AND FGD.PRODUCTO = ICP.PRODUCTO " & vbCrLf
            sql &= " AND ICUM.COMPAÑIA = FGD.COMPAÑIA " & vbCrLf
            sql &= " AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA" & vbCrLf

            sql = "EXECUTE sp_FACTURACION_IMPRIME_FACTURA_CONSUMIDOR_FINAL " & vbCrLf
            sql &= "  @TIPO_DOCUMENTO = " & TipDoc & vbCrLf
            sql &= ", @NUMERO_DOCUMENTO = " & numFactura & vbCrLf
            sql &= ", @BANDERA = 0" & vbCrLf
            sql &= ", @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @BODEGA = " & cmbBODEGA.SelectedValue
            sql &= ", @OV = " & Numero_OV
        Else
            documento = New Contabilidad_CuentasxCobrar_Facturacion_Reportes_CCF
            sql = "EXECUTE sp_FACTURACION_GENERADA_REPORTES_CCF "
            sql &= CIA
            sql &= ", " & Bodega
            sql &= ", " & numPedido
            sql &= ", " & numFactura
            sql &= ", " & TipDoc
            sql &= ", ''" 'TOTAL EN LETRAS
            sql &= ", 4" 'MUNICIPIO
            sql &= ", 8" 'DEPTO
            sql &= ", 1" 'PAIS
            sql &= ", 1" 'BANDERA
        End If
        Try
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                documento.SummaryInfo.ReportTitle = "Factura_" & numFactura
                documento.SetDataSource(Table)
                'If TipDoc = 2 Then
                '    totFact = Table.Rows(0).Item("SUB_TOTAL")
                'Else
                '    totFact = Table.Rows(0).Item("TOT_FACT")
                'End If
                'TC URGENCIA
                Dim instance As New Printing.PrinterSettings
                Dim impresorPredt As String = instance.PrinterName
                Dim print_name As String = impresorPredt '"EPSON"
                'Obtener nombre de hoja personalizada
                Dim print_paper As String

                If TipDoc = 1 Then
                    print_paper = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 37").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCF")
                Else
                    print_paper = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 38").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCCF")
                End If

                'Opciones del Crystal Report
                Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
                'Se aplican al informe
                With documento
                    'Se obtienen la opciones de impresion
                    repOptions = .PrintOptions
                    'Se setean las opciones
                    With repOptions
                        'Obtiene el id del papel --> utiliza una función especial
                        .PaperSize = GetPapersizeID(print_name, print_paper)
                        'Señala la impresora a utilizar
                        .PrinterName = print_name
                    End With
                End With
                'TC URGENCIA
                documento.PrintToPrinter(1, True, 1, 1)
                
            End If
            'Actualizar bandera de impreso para la factura
            sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET FACTURA_IMPRESA = 1, NUMERO_PARTIDA = " & NumPartida
            sql &= " WHERE COMPAÑIA=" & CIA & " AND BODEGA=" & Bodega & " AND ORDEN_VENTA=" & numPedido
            sql &= " AND TIPO_DOCUMENTO=" & TipDoc & " AND NUMERO_FACTURA=" & numFactura
            sqlCmd.CommandText = sql
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub ParamBodegas()
        If Not Iniciando Then
            Dim ParamBodegas As DataTable
            Dim sqlCmd As New SqlCommand
            sql = "SELECT TIPO_FACTURA,TIPO_CCF,TIPO_SOLICITUD FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue
            sqlCmd.CommandText = sql
            ParamBodegas = jClass.obtenerDatos(sqlCmd)
            TipMovInvFact = ParamBodegas.Rows(0).Item("TIPO_FACTURA")
            TipMovInvCCF = ParamBodegas.Rows(0).Item("TIPO_CCF")
            TipoSolicitud = ParamBodegas.Rows(0).Item("TIPO_SOLICITUD")
            If Me.cmbTipDoc.SelectedValue = 1 Then
                TipMovInv = TipMovInvFact
            ElseIf Me.cmbTipDoc.SelectedValue = 2 Then
                TipMovInv = TipMovInvCCF
            End If
            sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 1"
            PorcIVA = Val(jClass.obtenerEscalar(sql))
            sql = "SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 54"
            PorcCESC = Val(jClass.obtenerEscalar(sql))
        End If
    End Sub

    Private Sub bntNuevaFact_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevaFact.Click
        limpiaCampos(0)
    End Sub

    Private Sub eliminaSolicitud(ByVal numFactura As Integer, ByVal TipDoc As Integer, ByVal numsoli As Integer)
        Dim sqlCmd As New SqlCommand
        Dim RowsAfected As Integer
        sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION"
        sql &= " SET ANULADA = 1"
        sql &= ", COMENTARIO_ANULADA = 'DEVOLUCION A FACTURA No." & Me.txtNoFact.Text & " EN FACTURA No." & numFactura & "'"
        sql &= ", FECHA_ANULADA = GETDATE()"
        sql &= ", USUARIO_ANULO = '" & Usuario & "'"
        sql &= ", USUARIO_EDICION_FECHA = GETDATE()"
        sql &= " WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & numsoli & " AND TIPO_FACTURA = " & TipDoc & " AND NUMERO_FACTURA = " & Me.txtNoFact.Text
        sqlCmd.CommandText = sql
        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS_IUD]"
        sql &= " @COMPAÑIA = " & Compañia
        sql &= ", @NUM_SOLICITUD = " & numsoli
        sql &= ", @MOTIVO = 'DEVOLUCION A FACTURA No." & Me.txtNoFact.Text & " EN FACTURA No." & numFactura & "'"
        sql &= ", @USUARIO = '" & Usuario & "'"
        sql &= ", @IUD = 'I'"
        sqlCmd.CommandText = sql
        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD]"
        sql &= " @COMPAÑIA = " & Compañia
        sql &= ", @NUM_SOLICITUD = " & numsoli
        sql &= ", @USUARIO = '" & Usuario & "'"
        sql &= ", @IUD = 'I'"
        sqlCmd.CommandText = sql
        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
    End Sub

    Private Function capitalPagadoSolicitud(ByVal numSoli As Integer, ByVal CIA As Integer) As Integer
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CONSULTAS] "
        sql &= " @COMPAÑIA = " & CIA & ", @NUM_SOLICITUD = " & numSoli & ", @BANDERA = 6"
        Return jClass.obtenerEscalar(sql)
    End Function

    'TC
    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim pdprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        pdprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To pdprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If pdprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(pdprint.PrinterSettings.PaperSizes(i).RawKind)
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function
End Class