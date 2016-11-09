Imports System.Data.SqlClient

Public Class Facturacion_Anulacion_Facturas

    Dim multi As New multiUsos
    Dim jClass As New jarsClass

    Dim Iniciando As Boolean
    Dim Sql As String
    Dim sqlCmd As New SqlCommand

    Private Sub Facturacion_Anulacion_Facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBODEGA)
        multi.CargaTipoDocumentoFact(Compañia, Me.cmbTipDoc)
        Iniciando = False
        Me.cmbBODEGA.SelectedIndex = 0
        Me.cmbTipDoc.SelectedIndex = 0
        CargaGrid(Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, 0, "")
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Not Iniciando Then
            CargaGrid(Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, 0, "")
        End If
    End Sub

    Private Sub cmbTipDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipDoc.SelectedIndexChanged
        If Not Iniciando Then
            CargaGrid(Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, 0, "")
        End If
    End Sub

    Private Sub CargaGrid(ByVal Bodega As Integer, ByVal TipDoc As Integer, ByVal numDoc As Integer, ByVal nomDoc As String)
        Dim tbFacturas As DataTable
        Sql = "SELECT FGE.IMPRIMIR_CONCEPTO AS Anular, FGE.NUMERO_FACTURA AS [Numero Documento], FGE.NOMBRE_FACTURA as [A Nombre de], CONVERT(VARCHAR(10),FGE.FECHA_FACTURA,103) AS [Fecha Documento], FGE.ORDEN_VENTA, FGE.CODIGO_EMPLEADO" & vbCrLf
        Sql &= " FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO FCTD" & vbCrLf
        Sql &= " WHERE FGE.TIPO_DOCUMENTO = FCTD.TIPO_DOCUMENTO AND FGE.COMPAÑIA = FCTD.COMPAÑIA AND FGE.FACTURA_IMPRESA = 1 AND FGE.ANULADA = 0" & vbCrLf
        Sql &= " AND FGE.FECHA_FACTURA >= '" & Format(Now.AddDays(-2), "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= " AND FGE.COMPAÑIA = " & Compañia & vbCrLf
        Sql &= " AND FGE.BODEGA = " & Bodega & vbCrLf
        Sql &= " AND FGE.TIPO_DOCUMENTO = " & TipDoc & vbCrLf
        Sql &= " AND FGE.CONTABILIZADO = 0" & vbCrLf
        Sql &= " AND FGE.TOTAL_FACTURA > 0"
        If nomDoc.Length > 0 Then
            Sql &= " AND FGE.NOMBRE_FACTURA LIKE '%" & nomDoc & "%'"
        End If
        If numDoc > 0 Then
            Sql &= " AND FGE.NUMERO_FACTURA = " & numDoc
        End If
        sqlCmd.CommandText = Sql
        tbFacturas = jClass.obtenerDatos(sqlCmd)
        Me.DataGridView1.DataSource = tbFacturas
        For a As Integer = 0 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns.Item(a).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Select Case a
                Case 0
                    Me.DataGridView1.Columns(a).Width = 50
                Case 1
                    Me.DataGridView1.Columns(a).ReadOnly = False
                    Me.DataGridView1.Columns(a).Width = 70
                    Me.DataGridView1.Columns(a).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case 2
                    Me.DataGridView1.Columns(a).ReadOnly = False
                    Me.DataGridView1.Columns(a).Width = 200
                Case 3
                    Me.DataGridView1.Columns(a).Width = 70
                Case Is > 3
                    Me.DataGridView1.Columns(a).Visible = False
            End Select
        Next
        Me.txtNumDoc.Clear()
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim numFactura, NumOV, RowsAfected As Double
        Dim numSoli, CodBuxis As Integer
        Dim detalleInv, tblAnular As DataTable
        Dim anula As Boolean
        Try
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                anula = False
                numFactura = row.Cells("Numero Documento").Value
                NumOV = row.Cells("ORDEN_VENTA").Value
                anula = row.Cells("Anular").Value
                CodBuxis = row.Cells("CODIGO_EMPLEADO").Value
                If anula Then
                    Sql = "EXECUTE [dbo].[sp_FACTURACION_ANULA_FACTURA_GENERADA]"
                    Sql &= "  @COMPAÑIA = " & Compañia
                    Sql &= ", @BODEGA =  " & Me.cmbBODEGA.SelectedValue
                    Sql &= ", @ORDEN_VENTA = " & NumOV
                    Sql &= ", @TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue
                    Sql &= ", @NUMERO_FACTURA = " & numFactura
                    Sql &= ", @USUARIO = " & Usuario
                    Sql &= ", @IUD = A"
                    sqlCmd.CommandText = Sql
                    RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    Sql = "SELECT FGD.PRODUCTO, ICP.DESCRIPCION_PRODUCTO, RTRIM(ICUM.DESCRIPCION_UNIDAD_MEDIDA) AS DESCRIPCION_UNIDAD_MEDIDA, FGD.CANTIDAD, FGD.PRECIO_UNITARIO, FGD.PRECIO_TOTAL, FGD.BODEGA, FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO, FGE.NUMERO_FACTURA, FGE.ANULADA, FGD.LINEA, IME.TIPO_MOVIMIENTO, IME.MOVIMIENTO, FGE.CODIGO_EMPLEADO, FGE.CODIGO_EMPLEADO_AS, FGE.FORMA_PAGO, FGE.IMPRIMIR_CONCEPTO, FGE.CONCEPTO, FGE.FECHA_FACTURA, FGE.FACTURA_IMPRESA FROM dbo.FACTURACION_GENERADA_ENCABEZADO FGE, dbo.FACTURACION_GENERADA_DETALLE FGD,dbo.INVENTARIOS_MOVIMIENTOS_ENCABEZADO IME, dbo.INVENTARIOS_MOVIMIENTOS_DETALLE IMD, dbo.INVENTARIOS_CATALOGO_PRODUCTOS ICP, dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM WHERE FGE.BODEGA = FGD.BODEGA AND FGE.COMPAÑIA = FGD.COMPAÑIA AND FGE.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO AND FGE.NUMERO_FACTURA = FGD.NUMERO_FACTURA AND FGE.ORDEN_VENTA = IME.ORDEN_VENTA AND IME.COMPAÑIA = IMD.COMPAÑIA AND IME.BODEGA = IMD.BODEGA AND IME.TIPO_MOVIMIENTO = IMD.TIPO_MOVIMIENTO AND IME.MOVIMIENTO = IMD.MOVIMIENTO AND FGD.PRODUCTO = IMD.PRODUCTO AND FGD.COMPAÑIA = ICP.COMPAÑIA AND FGD.PRODUCTO = ICP.PRODUCTO AND ICUM.COMPAÑIA = FGD.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA AND IMD.ENTRADA_SALIDA = 0"
                    Sql &= " AND FGE.COMPAÑIA = " & Compañia
                    Sql &= " AND FGE.BODEGA = " & Me.cmbBODEGA.SelectedValue
                    Sql &= " AND FGE.TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue
                    Sql &= " AND FGE.NUMERO_FACTURA = " & numFactura
                    Sql &= " ORDER BY FGD.LINEA"
                    sqlCmd.CommandText = Sql
                    detalleInv = jClass.obtenerDatos(sqlCmd)
                    For Each TableRow As DataRow In detalleInv.Rows
                        Sql = "UPDATE INVENTARIOS_MOVIMIENTOS_DETALLE"
                        Sql &= " SET ANULADO = 1"
                        Sql &= " WHERE COMPAÑIA = " & Compañia & " AND TIPO_MOVIMIENTO = " & TableRow.Item("TIPO_MOVIMIENTO")
                        Sql &= " AND MOVIMIENTO = " & TableRow.Item("MOVIMIENTO") & " AND PRODUCTO = " & TableRow.Item("PRODUCTO")
                        sqlCmd.CommandText = Sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    Next
                    Sql = "SELECT N_SOLICITUD FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND TIPO_FACTURA = " & Me.cmbTipDoc.SelectedValue & " AND NUMERO_FACTURA = " & numFactura & " AND CODIGO_BUXIS = " & CodBuxis
                    tblAnular = jClass.obtenerDatos(New SqlCommand(Sql))
                    For i As Integer = 0 To tblAnular.Rows.Count - 1
                        numSoli = tblAnular.Rows(i).Item(0)
                        Sql = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION"
                        Sql &= " SET ANULADA = 1"
                        Sql &= ", COMENTARIO_ANULADA = 'ANULACION FACTURA'"
                        Sql &= ", FECHA_ANULADA = GETDATE()"
                        Sql &= ", USUARIO_ANULO = '" & Usuario & "'"
                        Sql &= ", USUARIO_EDICION_FECHA = GETDATE()"
                        Sql &= " WHERE COMPAÑIA = " & Compañia & " AND TIPO_FACTURA = " & Me.cmbTipDoc.SelectedValue & " AND NUMERO_FACTURA = " & numFactura & " AND CODIGO_BUXIS = " & CodBuxis
                        sqlCmd.CommandText = Sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                        Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_ANULADAS_IUD]"
                        Sql &= " @COMPAÑIA = " & Compañia
                        Sql &= ", @NUM_SOLICITUD = " & numSoli
                        Sql &= ", @MOTIVO = 'ANULACION FACTURA'"
                        Sql &= ", @USUARIO = '" & Usuario & "'"
                        Sql &= ", @IUD = 'I'"
                        sqlCmd.CommandText = Sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                        Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD]"
                        Sql &= " @COMPAÑIA = " & Compañia
                        Sql &= ", @NUM_SOLICITUD = " & numSoli
                        Sql &= ", @USUARIO = '" & Usuario & "'"
                        Sql &= ", @IUD = 'I'"
                        sqlCmd.CommandText = Sql
                        RowsAfected = jClass.ejecutarComandoSql(sqlCmd)
                    Next
                End If
            Next
            CargaGrid(Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, 0, "")
            MsgBox("La Factura de Anulo con Exito...", MsgBoxStyle.Critical, "Anulacion")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Anulación")
        End Try
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Me.CargaGrid(Me.cmbBODEGA.SelectedValue, Me.cmbTipDoc.SelectedValue, Val(Me.txtNumDoc.Text), Me.txtNomDoc.Text)
    End Sub
End Class