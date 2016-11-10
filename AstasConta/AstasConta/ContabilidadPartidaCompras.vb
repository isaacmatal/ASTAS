Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ContabilidadPartidaCompras

    Dim iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql As String
    Dim DescBodegas As String
    Dim Table, TblPdaStruc As DataTable
    Dim TableCompras As DataTable

    Private Sub ContabilidadPartidaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvPartidas.AutoGenerateColumns = False
        Me.dgvBodegas.AutoGenerateColumns = False
        CargaBodegas()
        iniciando = False
    End Sub

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.lblMsj.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.lblMsj.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText1(ByVal texto As String, ByVal tipo As Integer)
    Sub SetText1(ByVal texto As String, ByVal tipo As Integer)
        If Me.txtNumPda.InvokeRequired Then
            Dim setea As New CallBackSetText1(AddressOf SetText1)
            Me.Invoke(setea, texto, tipo)
        Else
            Me.txtNumPda.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText2(ByVal texto As String)
    Sub SetText2(ByVal texto As String)
        If Me.txtTransaccionInicial.InvokeRequired Then
            Dim setea As New CallBackSetText2(AddressOf SetText2)
            Me.Invoke(setea, texto)
        Else
            Me.txtTransaccionInicial.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText3(ByVal texto As String)
    Sub SetText3(ByVal texto As String)
        If Me.txtTransaccionFinal.InvokeRequired Then
            Dim setea As New CallBackSetText3(AddressOf SetText3)
            Me.Invoke(setea, texto)
        Else
            Me.txtTransaccionFinal.Text = texto
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim fechas(2) As Date
        Dim bodegas As String = String.Empty
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.btnProcesar.Enabled = False
        Me.lblMsj.Visible = True

        DescBodegas = String.Empty
        For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
            If Me.dgvBodegas.Rows(i).Cells(0).Value Then
                bodegas &= IIf(bodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(2).Value
                DescBodegas &= IIf(DescBodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(1).Value
            End If
        Next
        If bodegas.Length > 0 Then
            'Sql = "SELECT CH.ORDEN_COMPRA, TD.IDENTIFICADOR, CH.DOCUMENTO, CH.FECHA_CONTABLE, CH.SUBTOTAL, CH.IVA, CH.RETENCION, CH.TOTAL_FINAL, P.NOMBRE_PROVEEDOR, CH.BODEGA, B.DESCRIPCION_BODEGA," & vbCrLf
            'Sql &= "       B.CUENTA_CONTABLE_INVENTARIO, P.CUENTA_CONTABLE AS CUENTA_CONTABLE_PROVEEDOR, B.CUENTA_CONTABLE_IVA, E.PROVEEDOR" & vbCrLf
            'Sql &= "  FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES CH, CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO E, CONTABILIDAD_CATALOGO_PROVEEDORES P, FACTURACION_CATALOGO_TIPO_DOCUMENTO TD, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            'Sql &= " WHERE CH.COMPAÑIA = E.COMPAÑIA AND CH.BODEGA = E.BODEGA AND CH.ORDEN_COMPRA = E.ORDEN_COMPRA" & vbCrLf
            'Sql &= "   AND E.COMPAÑIA = P.COMPAÑIA AND E.PROVEEDOR = P.PROVEEDOR" & vbCrLf
            'Sql &= "   AND CH.COMPAÑIA = TD.COMPAÑIA AND CH.TIPO_DOCUMENTO = TD.TIPO_DOCUMENTO" & vbCrLf
            'Sql &= "   AND CH.COMPAÑIA = B.COMPAÑIA AND CH.BODEGA = B.BODEGA" & vbCrLf
            'Sql &= "   AND CH.COMPAÑIA = " & Compañia & vbCrLf
            'Sql &= "   AND CH.BODEGA IN (" & bodegas & ")" & vbCrLf
            'Sql &= "   AND CONVERT(DATE,CH.FECHA_RECEPCION) BETWEEN CONVERT(DATE,'" & Format(Me.dpFechaContable1.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATE,'" & Format(Me.dpFechaContable2.Value, "dd/MM/yyyy") & "',103)"
            Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_PARTIDAS_AUTOMATICAS_CONTABILIZAR_COMPRAS]" & vbCrLf
            Sql &= " @COMPAÑIA      = " & Compañia
            Sql &= ",@BODEGAS       = '" & bodegas & "'"
            Sql &= ",@NOTA_CREDITO  = " & IIf(chkNC.Checked, "1", "0")
            Sql &= ",@FECHA_INICIAL = '" & Format(Me.dpFechaContable1.Value, "dd/MM/yyyy") & "'"
            Sql &= ",@FECHA_FINAL   = '" & Format(Me.dpFechaContable2.Value, "dd/MM/yyyy") & "'"
            sqlCmd.CommandText = Sql
            TableCompras = jClass.obtenerDatos(sqlCmd)
            If TableCompras.Rows.Count > 0 Then
                Me.pbAplicar.Visible = True
                Me.pbAplicar.Maximum = TableCompras.Rows.Count
                Me.pbAplicar.Value = 0
                fechas(0) = Me.dpFechaContable1.Value
                fechas(1) = Me.dpFechaContable2.Value
                Me.bw1.RunWorkerAsync(fechas)
            Else
                Me.btnProcesar.Enabled = True
                Me.lblMsj.Visible = False
                MsgBox("No hay datos para la Fecha y/o" & vbCrLf & " las bodegas seleccionadas", MsgBoxStyle.Information, "Partida Solicitudes")
            End If
        Else
            Me.btnProcesar.Enabled = True
            Me.lblMsj.Visible = False
            MsgBox("Debe seleccionar al menos una bodega para procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
        End If
    End Sub

    Private Sub PartidasContables(ByVal FechaContable1 As Date, ByVal FechaContable2 As Date)
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim poneTextoPdas As New CallBackSetText1(AddressOf SetText1)
        Dim poneTextoTransI As New CallBackSetText2(AddressOf SetText2)
        Dim poneTextoTransF As New CallBackSetText3(AddressOf SetText3)
        Dim CtaContable, Libro, Transaccion, CtaInv, NumOC, CtaPercepcion, CtaIVA, CtaCESC, CtaExento, Partida, CodProveedor As Integer
        Dim TotalDetalle As Double
        Dim ValorNeto As Double
        Dim CargoInv, CargoIVA, ValorPercep, ValorCESC, ValorExento As Double
        Dim FechaPartida As Date
        Dim Concepto As String
        Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        CtaPercepcion = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 31"))
        CtaCESC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 55"))
        If Not jClass.ValidaCierreContable(Compañia, Libro, FechaContable1.Year, FechaContable1.Month, "E") Then
            Return
        End If
        'Partida por Cuotas de Capital de los diferentes rubros
        If TableCompras.Rows.Count > 0 Then
            Partida = Val(Me.txtNumPda.Text)
            If Partida > 0 Then
                Transaccion = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & FechaContable1.Month & " AND YEAR(FECHA_CONTABLE) = " & FechaContable1.Year & " AND COMPAÑIA = " & Compañia)
                If Transaccion = 0 Then
                    MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                    Return
                Else
                    If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & Transaccion & " AND COMPAÑIA = " & Compañia) Then
                        MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                        Return
                    Else
                        If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
                            If MsgBox("La partida No." & Partida & " tiene detalle, si continúa el detalle se eliminará." & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                            Else
                                MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                Return
                            End If
                        End If
                    End If
                End If
                FechaPartida = CDate(jClass.obtenerEscalar("SELECT FECHA_CONTABLE FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & Transaccion & " AND COMPAÑIA = " & Compañia))
                'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            Else
                FechaPartida = FechaContable2
                Concepto = "Registro de " & IIf(Me.chkNC.Checked, "Notas de Crédito", "compras") & " para " & DescBodegas & IIf(FechaContable1 = FechaContable2, " de fecha " & Format(FechaContable1, "dd/MM/yyyy"), ", periodo del " & Format(FechaContable1, "dd/MM/yyyy") & " al " & Format(FechaContable2, "dd/MM/yyyy"))
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & FechaContable2.Year & ", @MES = " & FechaContable2.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 2, 37, 0, FechaContable2, Libro, Concepto, 0, 0, "I")
                Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                poneTextoPdas(Partida.ToString(), 1)
            End If
            poneTextoTransI(Transaccion.ToString())
            poneTextoTransF(Transaccion.ToString())
            TotalDetalle = 0
            For i As Integer = 0 To TableCompras.Rows.Count - 1
                NumOC = TableCompras.Rows(i).Item("ORDEN_COMPRA")
                CtaContable = TableCompras.Rows(i).Item("CUENTA_CONTABLE_PROVEEDOR")
                CodProveedor = TableCompras.Rows(i).Item("PROVEEDOR")
                CtaInv = TableCompras.Rows(i).Item("CUENTA_CONTABLE_INVENTARIO")
                CtaIVA = TableCompras.Rows(i).Item("CUENTA_CONTABLE_IVA")
                ValorNeto = TableCompras.Rows(i).Item("TOTAL_FINAL")
                CargoInv = TableCompras.Rows(i).Item("SUBTOTAL")
                CargoIVA = TableCompras.Rows(i).Item("IVA")
                ValorPercep = TableCompras.Rows(i).Item("RETENCION")
                ValorCESC = TableCompras.Rows(i).Item("CESC")
                ValorExento = TableCompras.Rows(i).Item("VALOR_EXENTO")
                Concepto = IIf(Me.chkNC.Checked, "NC", TableCompras.Rows(i).Item("IDENTIFICADOR")) & " " & TableCompras.Rows(i).Item("DOCUMENTO") & IIf(Me.chkNC.Checked, " DEL " & Format(TableCompras.Rows(i).Item("FECHA_CONTABLE"), "dd/MM/yyyy") & ", APLICADA AL CCF #" & TableCompras.Rows(i).Item("NUMERO_NC"), "") & ", " & TableCompras.Rows(i).Item("NOMBRE_PROVEEDOR") & ", " & IIf(Me.chkNC.Checked, "", Format(TableCompras.Rows(i).Item("FECHA_CONTABLE"), "dd/MM/yyyy") & ", ") & TableCompras.Rows(i).Item("DESCRIPCION_BODEGA")
                'CARGO AL INVENTARIO
                jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, CtaInv, "C", IIf(CargoInv < 0, 0, CargoInv), IIf(CargoInv < 0, (-1.0) * CargoInv, 0), "E")
                'CARGO POR CREDITO FISCAL (IVA)
                If Not CargoIVA = 0 Then
                    jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, CtaIVA, "C", IIf(CargoIVA < 0, 0, CargoIVA), IIf(CargoIVA < 0, (-1.0) * CargoIVA, 0), "E")
                End If
                'CARGO POR PERCEPCION (SI HUBIERE)
                If Not ValorPercep = 0 Then
                    jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, CtaPercepcion, "C", IIf(ValorPercep < 0, 0, ValorPercep), IIf(ValorPercep < 0, (-1.0) * ValorPercep, 0), "E")
                End If
                'CARGO POR CESC (SI HUBIERE)
                If Not ValorCESC = 0 Then
                    jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, CtaCESC, "C", IIf(ValorCESC < 0, 0, ValorCESC), IIf(ValorCESC < 0, (-1.0) * ValorCESC, 0), "E")
                End If
                'CARGO POR EXENTOS (SI HUBIERE)
                If Not ValorExento = 0 Then
                    jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, CtaExento, "C", IIf(ValorExento < 0, 0, ValorExento), IIf(ValorExento < 0, (-1.0) * ValorExento, 0), "E")
                End If
                'ABONO DEUDA AL PROVEEDOR
                jClass.DetallePartida(Transaccion, 0, CodProveedor, FechaPartida, Libro, Concepto, CtaContable, "A", IIf(ValorNeto < 0, (-1.0) * ValorNeto, 0), IIf(ValorNeto < 0, 0, ValorNeto), "E")
                'SETEAR LOS NUMEROS DE TRANSACCION Y PARTIDA EN LOS REGISTROS DE CUENTAS POR PAGAR
                Sql = " UPDATE CONTABILIDAD_ORDEN_COMPRA_CHEQUES " & vbCrLf
                Sql &= "   SET PARTIDA = " & Partida & ", TRANSACCION = " & Transaccion & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND ORDEN_COMPRA = " & NumOC
                Sql &= "   AND DOCUMENTO = " & TableCompras.Rows(i).Item("DOCUMENTO")
                sqlCmd.CommandText = Sql
                jClass.ejecutarComandoSql(sqlCmd)
                bw1.ReportProgress(1)
            Next
            jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaContable2.Value.Date, Libro, "Concepto", 0, "X", 0, 0, "A")
        End If
    End Sub

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        PartidasContables(CDate(e.Argument(0)), CDate(e.Argument(1)))
    End Sub

    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        Try
            Me.pbAplicar.Value += e.ProgressPercentage
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        ProcesoFinalizado()
    End Sub

    Private Sub ProcesoFinalizado()
        CargaPartida_Detalle()
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Recepción desde Buxis")
        Me.pbAplicar.Visible = False
        Me.lblMsj.Visible = False
        Me.lblMsj.Text = "Procesando..."
        Me.btnProcesar.Enabled = True
        For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
            Me.dgvBodegas.Rows(i).Cells(0).Value = False
        Next
        Me.btnReporte.PerformClick()
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpts As New frmReportes_Ver
        If Val(Me.txtTransaccionInicial.Text) > 0 Then
            rpts.CargaPartida(Compañia, jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"), Me.txtTransaccionInicial.Text, Me.txtTransaccionFinal.Text, Me.dpFechaContable1.Value.Year, Me.dpFechaContable1.Value.Month, 1)
            rpts.ShowDialog()
        End If
    End Sub

    Private Sub CargaPartida_Detalle()
        Dim TableDetalle As DataTable
        Dim Libro As Integer
        Try
            Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= ",@TRANSACCION    = " & Me.txtTransaccionInicial.Text & vbCrLf
            Sql &= ",@BANDERA        = 6"
            sqlCmd.CommandText = Sql
            TableDetalle = jClass.obtenerDatos(sqlCmd)
            Me.dgvPartidas.DataSource = TableDetalle
            Me.dgvPartidas.Sort(Me.dgvPartidas.Columns("Abono"), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbTipoSoli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtNumPda.Clear()
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.dgvPartidas.DataSource = Nothing
    End Sub

    Private Sub ContabilidadPartidaCompras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub dpFechaPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaContable1.ValueChanged
        Me.dpFechaContable2.Value = Me.dpFechaContable1.Value
    End Sub

    Private Sub txtNumPda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPda.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub CargaBodegas()
        Sql = "Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compañia & ", 0, '" & Usuario & "'"
        SqlCmd = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(sqlCmd)
        Me.dgvBodegas.DataSource = Table
    End Sub
End Class