Imports System.Data.SqlClient

Public Class Inventario_Compras
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim Iniciando As Boolean = True
    Dim numeroEntrada As String
    Dim dgvError As Boolean
    Dim Costo_Anterior As Double = 0
    Dim Precio_Anterior As Double = 0
    Dim Existencia_Anterior As Double = 0
    Dim porcIVA, porcPerc, porcIntanNatural, porcIntanJuridica, porcServicios, porcCESC As Double

    Private Sub Inventario_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBodegas()
        CombosGrid()
        porcIVA = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 1")) / 100, 2)
        porcPerc = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 2")) / 100, 2)
        porcIntanNatural = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 46")) / 100, 2)
        porcIntanJuridica = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 10")) / 100, 2)
        porcServicios = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 5")) / 100, 2)
        porcCESC = Math.Round(CDbl(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 54")) / 100, 2)
        Me.dpFechaDesde.Value = Now.AddDays(-Now.Day + 1)
        Me.dpFechaDesde.Value = Me.dpFechaDesde.Value.AddMonths(-Now.Month + 1)
        BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "6")
        Me.dgvOrdenesCompra.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Me.dgvOrdenesCompra.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Me.dgvDetalleOC.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Me.dgvDetalleOC.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Iniciando = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CombosGrid()
        Dim tblBod As New DataTable
        Dim cmbTipo As System.Windows.Forms.DataGridViewComboBoxColumn
        Try
            Sql = "EXECUTE sp_INVENTARIOS_CATALOGO_BODEGAS " & vbCrLf
            Sql &= "  @BANDERA  = 4" & vbCrLf
            Sql &= ", @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @USUARIO  = '" & Usuario & "' "
            tblBod = jClass.obtenerDatos(New SqlCommand(Sql))
            cmbTipo = Me.dgvDetalleOC.Columns.Item("destinobodega")
            cmbTipo.DataSource = tblBod
            cmbTipo.ValueMember = "Bodega"
            cmbTipo.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error CombosGrid")
        End Try
    End Sub

    Private Sub CargaBodegas()
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_INVENTARIOS_CATALOGO_BODEGAS " & vbCrLf
            Sql &= "  @BANDERA  = 4" & vbCrLf
            Sql &= ", @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @USUARIO  = '" & Usuario & "' "
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarOC(ByVal Compañia As Integer, ByVal Bodega As Integer, ByVal OC As Integer, ByVal NombreProveedor As String, ByVal NombreComercial As String, ByVal NIT As String, ByVal NRC As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Bandera As Integer)
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA " & vbCrLf
            Sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
            Sql &= ",@BODEGA           = " & Bodega & vbCrLf
            Sql &= ",@ORDEN_COMPRA     = " & OC & vbCrLf
            Sql &= ",@NOMBRE_PROVEEDOR = '" & NombreProveedor & "'" & vbCrLf
            Sql &= ",@NOMBRE_COMERCIAL = '" & NombreComercial & "'" & vbCrLf
            Sql &= ",@NIT              = '" & NIT & "'" & vbCrLf
            Sql &= ",@NRC              = '" & NRC & "'" & vbCrLf
            Sql &= ",@FECHA_INICIAL    = '" & Format(FechaIni, "dd-MM-yyyy 00:00:01") & "'" & vbCrLf
            Sql &= ",@FECHA_FINAL      = '" & Format(FechaFin, "dd-MM-yyyy 23:59:59") & "'" & vbCrLf
            Sql &= ",@BANDERA          = " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvOrdenesCompra.DataSource = Table
            If Me.dgvOrdenesCompra.Rows.Count = 0 Then
                While Me.dgvDetalleOC.Rows.Count > 0
                    Me.dgvDetalleOC.Rows.RemoveAt(0)
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle(ByVal Compañia As Integer, ByVal OrdenCompra As Integer, ByVal Bandera As Integer)
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 " & vbCrLf
            Sql &= " @COMPAÑIA     = " & Compañia & vbCrLf
            Sql &= ",@ORDEN_COMPRA = " & OrdenCompra & vbCrLf
            Sql &= ",@BANDERA      = " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvDetalleOC.DataSource = Table
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                Me.dgvDetalleOC.Rows(i).Cells("cantidadrec").Value = "0.00"
                Me.dgvDetalleOC.Rows(i).Cells("costotot").Value = "0.00"
            Next
            If Me.dgvOrdenesCompra.CurrentRow.Cells("ainvoc").Value Then
                Me.dgvDetalleOC.Columns(10).Visible = False
                Me.dgvDetalleOC.Columns(11).Visible = False
            Else
                Me.dgvDetalleOC.Columns(10).Visible = True
                Me.dgvDetalleOC.Columns(11).Visible = True
            End If
            dgvError = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GuardaItemsRecibidos(ByVal Compañia As Integer, ByVal OC As Integer)
        Try
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO_IUD "
                Sql &= " @COMPAÑIA             = " & Compañia
                Sql &= ",@ORDEN_COMPRA         = " & OC
                Sql &= ",@LINEA                = " & Me.dgvDetalleOC.Rows(i).Cells.Item("line").Value
                Sql &= ",@PRODUCTO             = " & Me.dgvDetalleOC.Rows(i).Cells.Item("producto").Value
                Sql &= ",@DESCRIPCION_PRODUCTO = ''"
                Sql &= ",@UNIDAD_MEDIDA        = " & Me.dgvDetalleOC.Rows(i).Cells.Item("destinobodega").Value
                Sql &= ",@CANTIDAD             = " & TipoDocto
                Sql &= ",@LIBRAS               = " & NumeDocto
                Sql &= ",@COSTO_UNITARIO       = " & Me.dgvDetalleOC.Rows(i).Cells.Item("costotot").Value
                Sql &= ",@SERVICIO             = 0"
                Sql &= ",@CANTIDAD_RECIBIDO    = " & Me.dgvDetalleOC.Rows(i).Cells.Item("cantidadrec").Value
                Sql &= ",@LIBRAS_RECIBIDO      = " & Me.dgvOrdenesCompra.CurrentRow.Cells("codprovoc").Value
                Sql &= ",@CANTIDAD_PENDIENTE   = " & Me.dgvDetalleOC.Rows(i).Cells.Item("cantpend").Value
                Sql &= ",@LIBRAS_PENDIENTE     = 0"
                Sql &= ",@RECIBIDO             = " & IIf(Me.dgvDetalleOC.Rows(i).Cells.Item("cantpend").Value = 0, 1, 0)
                Sql &= ",@A_INVENTARIO         = " & Me.dgvOrdenesCompra.CurrentRow.Cells("ainvoc").Value
                Sql &= ",@USUARIO              = '" & Usuario & "' "
                Sql &= ",@IUD                  = 'U'"
                jClass.ejecutarComandoSql(New SqlCommand(Sql))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "6")
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "6")
        End If
    End Sub

    Private Sub dgvOrdenesCompra_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrdenesCompra.CellEnter
        setearTextBox()
        If Me.dgvOrdenesCompra.Rows.Count > 0 Then
            CargaOC_Detalle(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, 4)
        End If
    End Sub

    Private Sub dgvDetalleOC_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleOC.CellEndEdit
        Dim Subtotal As Double = 0.0
        Dim cantidadPend As Double = 0.0
        Try
            If Me.dgvDetalleOC.CurrentRow.Cells.Item("cantidadrec").FormattedValue = "" Then
                Me.dgvDetalleOC.CurrentRow.Cells.Item("cantidadrec").Value = "0.00"
                Return
            End If
            cantidadPend = jClass.obtenerEscalar("SELECT CANTIDAD_PENDIENTE FROM CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells(0).Value & " AND LINEA = " & Me.dgvDetalleOC.CurrentRow.Cells.Item("line").Value)
            If Val(Me.dgvDetalleOC.CurrentRow.Cells.Item("cantidadrec").Value) > cantidadPend Then
                MessageBox.Show("La cantidad Recibida debe de ser menor o igual a la Cantidad Pendiente ...", "Cantidad Recibida Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvDetalleOC.CurrentRow.Cells.Item("cantidadrec").Value = cantidadPend
            End If
            Me.dgvDetalleOC.CurrentRow.Cells.Item("cantpend").Value = cantidadPend - Me.dgvDetalleOC.CurrentRow.Cells.Item("Cantidadrec").Value
            Me.dgvDetalleOC.CurrentRow.Cells.Item("costotot").Value = Me.dgvDetalleOC.CurrentRow.Cells.Item("Cantidadrec").Value * Me.dgvDetalleOC.CurrentRow.Cells.Item("costounit").Value
            TotalesComprobante()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TotalesComprobante()
        If Not Iniciando Then
            Dim Subtotal As Double = 0.0
            Dim Subtotal2 As Double = 0.0
            Dim Servicios As Double = 0.0
            Dim Intangible As Double = 0.0
            Dim TotalISR As Double = 0.0
            For i As Integer = 0 To Me.dgvDetalleOC.Rows.Count - 1
                Subtotal += Val(Me.dgvDetalleOC.Rows(i).Cells.Item("costotot").Value)
                If Me.dgvDetalleOC.Rows(i).Cells.Item("itemservicio").Value Then
                    Servicios += Val(Me.dgvDetalleOC.Rows(i).Cells.Item("costotot").Value)
                End If
                If Me.dgvDetalleOC.Rows(i).Cells.Item("itemintangible").Value Then
                    Intangible += Val(Me.dgvDetalleOC.Rows(i).Cells.Item("costotot").Value)
                End If
                If AplicaCESC(Me.dgvDetalleOC.Rows(i).Cells.Item("producto").Value) Then
                    Subtotal2 += Val(Me.dgvDetalleOC.Rows(i).Cells.Item("costotot").Value)
                End If
            Next
            Subtotal = Subtotal - Val(Me.txtDescuento.Text)
            Me.txtSubtotal.Text = Format(Subtotal, "0.00")
            Me.txtCESC.Text = Format(Math.Round(Subtotal2 * porcCESC, 2), "0.00")
            If Me.dgvOrdenesCompra.CurrentRow.Cells("tipoprovoc").Value = 1 Then
                TotalISR = Math.Round(Servicios * porcServicios, 2)
                TotalISR += Math.Round(Intangible * porcIntanNatural, 2)
            Else
                TotalISR = Intangible * porcIntanJuridica
            End If
            Me.txtISR.Text = Format(TotalISR, "0.00")
            If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("tipodococ").Value = 2 Then
                Me.txtIVA.Text = Format(Math.Round(Subtotal * porcIVA, 2), "0.00")
                If Subtotal > 100 And Me.dgvOrdenesCompra.CurrentRow.Cells.Item("contribuyenteoc").Value = 3 Then
                    Me.txtPercepcion.Text = Format(Math.Round(Subtotal * porcPerc, 2), "0.00")
                Else
                    Me.txtPercepcion.Text = "0.00"
                End If
            Else
                Me.txtIVA.Text = "0.00"
                Me.txtPercepcion.Text = "0.00"
            End If
            Me.txtTotal.Text = Format(Val(Me.txtSubtotal.Text) + Val(Me.txtIVA.Text), "0.00")
            Me.txtTotalRecibido.Text = Format(Val(Me.txtSubtotal.Text) + Val(Me.txtIVA.Text) + Val(Me.txtPercepcion.Text) - Val(Me.txtISR.Text), "0.00")
        End If
    End Sub

    Private Sub obtenerMovEntrada()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE TIPO_MOVIMIENTO = 3"
        numeroEntrada = jClass.leerDataeader(consulta, 0)
    End Sub

    Private Function InventarioCerrado(ByVal mes As Integer, ByVal anio As Integer, ByVal bodega As Integer) As Boolean
        Dim result As Boolean = Not CBool(jClass.obtenerEscalar("SELECT ISNULL((SELECT ESTADO FROM INVENTARIOS_CIERRE WHERE MES = " & mes & " AND AÑO = " & anio & " AND BODEGA = " & bodega & "), 1)"))
        Return result
    End Function

    Private Sub btnRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibir.Click
        Dim i As Integer
        Dim TipoCt As Integer
        Dim SubTot As Decimal
        Dim frmRep As New frmReportes_Ver()
        Dim reporte_10 As New Inventario_Compras_Recibir_rpt
        Dim reporte_11 As New CuentasxPagar_Quedan
        Dim reporte_12 As New Inventario_Compras_Recibir_No_Inv_rpt
        If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("ainvoc").Value Then
            If InventarioCerrado(Me.dpFechaProceso.Value.Month, Me.dpFechaProceso.Value.Year, Me.cmbBODEGA.SelectedValue) Then
                MsgBox("La fecha de proceso no es válida." & vbCrLf & vbCrLf & "El periodo " & Me.dpFechaProceso.Value.Month.ToString().PadLeft(2, "0") & "-" & Me.dpFechaProceso.Value.Year.ToString() & " ya fue cerrado.", MsgBoxStyle.Information, "Recibir Compras")
                Return
            End If
        End If
        If Val(Me.txtTotalRecibido.Text) = 0 Then
            If MsgBox("El valor total a recibir es CERO" & vbCrLf & "¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Recibir Compras") = MsgBoxResult.No Then
                Return
            End If
        End If
        If Me.dgvOrdenesCompra.Rows.Count > 0 Then
            If MsgBox("¿Desea dar Ingreso a Orden de Compra N° " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value.ToString.Trim & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
                Dim Recibir As New Inventario_ComprasRecibir
                Recibir.dpFecha_Comp.Value = Me.dpFechaProceso.Value
                Recibir.dtpFechaRecep.Value = Me.dpFechaProceso.Value
                Recibir.Bodega_Value = Me.cmbBODEGA.SelectedValue
                Recibir.lblOC.Text = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("numoc").Value
                Recibir.lblNOMBRE_PROVEEDOR.Text = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("provoc").Value
                Recibir.Lbl_Descto.Text = Me.txtDescuento.Text
                Recibir.lblSubTotal.Text = Me.txtSubtotal.Text
                Recibir.lblIVA.Text = Me.txtIVA.Text
                Recibir.lblCESC.Text = Me.txtCESC.Text
                Recibir.lblRetencion.Text = Me.txtPercepcion.Text
                Recibir.lblISR.Text = Me.txtISR.Text
                Recibir.lblTotalCompra.Text = Me.txtTotalRecibido.Text
                Recibir.chkInv.Checked = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("ainvoc").Value
                Recibir.Compañia_Value = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("tipodococ").Value
                Recibir.chkContado.Checked = (Me.dgvOrdenesCompra.CurrentRow.Cells("formapagooc").Value = 1)
                Recibir.lblExento.Text = Me.txtExento.Text
                'Recibir.lblTotal.Text = Me.txtCESC.Text
                Recibir.ShowDialog()
                If Recibido And Me.dgvOrdenesCompra.CurrentRow.Cells.Item("ainvoc").Value Then
                    obtenerMovEntrada()
                    For i = 0 To Me.dgvDetalleOC.RowCount - 1
                        If Me.dgvDetalleOC.Rows(i).Cells("cantidadrec").Value > 0 Then
                            TipoCt = jClass.obtenerEscalar("SELECT TIPO_COSTO FROM INVENTARIOS_CATALOGO_PRODUCTOS WHERE COMPAÑIA = " & Compañia & " AND PRODUCTO = " & Me.dgvDetalleOC.Rows(i).Cells("producto").Value)
                            SubTot = Me.dgvDetalleOC.Rows(i).Cells("costotot").Value
                            cadenaSIUD(Compañia, "I", Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, Me.dgvDetalleOC.Rows(i).Cells("line").Value, Me.dgvDetalleOC.Rows(i).Cells("destinobodega").Value, Me.dgvDetalleOC.Rows(i).Cells("producto").Value.ToString(), Me.dgvDetalleOC.Rows(i).Cells("cantidadrec").Value.ToString(), Me.dgvDetalleOC.Rows(i).Cells("costounit").Value.ToString(), SubTot, TipoCt)
                            jClass.Ejecutar_ConsultaSQL(Sql)
                            If TipoCt = 2 Then 'Si es Costo UEPS
                                jClass.IngresarCostoUeps(Compañia, Me.dgvDetalleOC.Rows(i).Cells("destinobodega").Value, Me.dgvDetalleOC.Rows(i).Cells("producto").Value.ToString, Me.dgvDetalleOC.Rows(i).Cells("cantidadrec").Value.ToString, "0", "I", Me.dgvDetalleOC.Rows(i).Cells("costounit").Value.ToString)
                            End If
                        End If
                    Next
                    MsgBox("Los inventarios han sido modificados con exito! Espere por el informe de ingreso.", MsgBoxStyle.Exclamation)
                End If
                If Recibido Then
                    GuardaItemsRecibidos(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value)
                    If Me.dgvOrdenesCompra.CurrentRow.Cells("formapagooc").Value = 1 Then
                        Dim frmChq As New Contabilidad_Cheques_Generar
                        frmChq.lblOC.Text = Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value
                        frmChq.lblNOMBRE_PROVEEDOR.Text = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("provoc").Value
                        frmChq.lblTotalCheque.Text = Me.txtTotalRecibido.Text
                        frmChq.dpFECHA_CH.Value = Me.dpFechaProceso.Value
                        frmChq.lblFACTURA.Text = NumeDocto
                        frmChq.lblBodega.Text = Me.dgvOrdenesCompra.CurrentRow.Cells.Item("bodoc").Value
                        frmChq.ShowDialog()
                    End If
                    'REPORTE RECIBIDO
                    If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("ainvoc").Value Then
                        reporte_10.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & ", @BANDERA = 1, @DOCUMENTO = " & NumeDocto)))
                        frmRep.ReportesGenericos(reporte_10)
                        frmRep.ShowDialog()
                    Else
                        reporte_12.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & ", @BANDERA = 1, @DOCUMENTO = " & NumeDocto)))
                        frmRep.ReportesGenericos(reporte_12)
                        frmRep.ShowDialog()
                    End If
                    'QUEDAN
                    If Me.dgvOrdenesCompra.CurrentRow.Cells("formapagooc").Value = 2 Then
                        reporte_11.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & ", @BANDERA = 6, @DOCUMENTO = " & NumeDocto)))
                        frmRep.ReportesGenericos(reporte_11)
                        frmRep.ShowDialog()
                    End If
                    Recibido = False
                    setearTextBox()
                    BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "6")
                    'CargaOC_Detalle(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, 4)
                End If
            End If
        Else
            MsgBox("¡Debe seleccionar una Orden de Compra válida!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Function AplicaCESC(ByVal prod As Integer) As Boolean
        Dim result As Boolean
        Sql = "SELECT S.APLICA_CESC FROM INVENTARIOS_CATALOGO_PRODUCTOS P, INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS S" & vbCrLf
        Sql &= " WHERE P.COMPAÑIA = S.COMPAÑIA AND P.GRUPO = S.GRUPO AND P.SUBGRUPO = S.SUBGRUPO AND P.PRODUCTO = " & prod & " AND P.COMPAÑIA = " & Compañia
        result = jClass.obtenerEscalar(Sql)
        Return result
    End Function

    Private Sub cadenaSIUD(ByVal CIA As Integer, ByVal SIUD As String, ByVal OdC As Integer, ByVal Linea As Integer, ByVal BODEGA As Integer, ByVal producto As Integer, ByVal cantidad As Double, ByVal costo_uni As Double, ByVal total As Double, ByVal TipoCto As Integer)
        Dim tipoMovimiento As Integer
        Try
            If TipoCto = 1 Then
                Costo_Anterior = jClass.obtenerEscalar("SELECT dbo.INVENTARIOS_CALCULAR_COSTOS(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Else
                Costo_Anterior = jClass.obtenerEscalar("SELECT dbo.INVENTARIOS_CALCULAR_COSTOS_UEPS(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            End If
            Existencia_Anterior = jClass.obtenerEscalar("SELECT dbo.calcular_existencia_actual(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Precio_Anterior = jClass.obtenerEscalar("SELECT dbo.INVENTARIOS_CALCULAR_PRECIO_VENTA(" & CIA & "," & BODEGA & "," & producto & ", '" & Format(Me.dpFechaProceso.Value, "dd-MM-yyyy 00:00:01") & "')")
            Sql = "UPDATE CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO SET PRECIO_ANTERIOR=" & Precio_Anterior & ", EXISTENCIA_ANTERIOR=" & Existencia_Anterior & ", COSTO_ANTERIOR=" & Costo_Anterior
            Sql &= " WHERE COMPAÑIA = " & CIA
            Sql &= " AND ORDEN_COMPRA = " & OdC
            Sql &= " AND LINEA = " & Linea
            jClass.Ejecutar_ConsultaSQL(Sql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If costo_uni = 0 Then
            tipoMovimiento = 16 'Ingreso por regalias
        Else
            tipoMovimiento = 3 'ingreso por compra
        End If

        Sql = "EXECUTE [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] " & vbCrLf
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

    Private Sub setearTextBox()
        For Each item As Control In Me.gbMontos.Controls
            If TypeOf (item) Is TextBox Then
                item.Text = "0.00"
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frmNuevo As New Inventario_Agregar_Bonificacion_Descuento(Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, Compañia, Me.cmbBODEGA.SelectedValue, 0)
        frmNuevo.ShowDialog()
        CargaOC_Detalle(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, 4)
    End Sub

    Private Sub soloNumeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotal.KeyPress, txtIVA.KeyPress, txtTotal.KeyPress, txtPercepcion.KeyPress, txtTotalRecibido.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtDescuento.Text.IndexOf(".") + 1 > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress, txtIVA.KeyPress, txtPercepcion.KeyPress, txtSubtotal.KeyPress, txtISR.KeyPress
        If Not Char.IsControl(e.KeyChar) Then
            If InStr("0123456789.", e.KeyChar) = 0 Then
                e.Handled = True
            Else
                If e.KeyChar = "." Then
                    If CType(sender, TextBox).Text.Contains(".") Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        End If
    End Sub

    Private Sub txtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.TextChanged
        TotalesComprobante()
    End Sub

    Private Sub Inventario_Compras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub On_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtotal.TextChanged, txtIVA.TextChanged, txtPercepcion.TextChanged, txtISR.TextChanged, txtCESC.TextChanged, txtExento.TextChanged
        Me.txtTotal.Text = Format(Val(Me.txtSubtotal.Text) + Val(Me.txtIVA.Text), "0.00")
        Me.txtTotalRecibido.Text = Format(Val(Me.txtTotal.Text) + Val(Me.txtPercepcion.Text) - Val(Me.txtISR.Text) + Val(Me.txtCESC.Text) + Val(Me.txtExento.Text), "0.00")
    End Sub

    Private Sub dgvDetalleOC_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDetalleOC.DataError
        If dgvError Then
            MsgBox("Solicite acceso a la bodega código No. " & Me.dgvDetalleOC.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & vbCrLf & "de lo contrario no podrá recibir productos" & vbCrLf & " en esa bodega", MsgBoxStyle.Information, "Recibir Compras")
            dgvError = False
        End If
    End Sub
End Class