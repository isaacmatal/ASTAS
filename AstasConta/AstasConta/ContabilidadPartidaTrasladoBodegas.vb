Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ContabilidadPartidaTrasladoBodegas

    Dim iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql As String
    Dim DescBodegas As String
    Dim Table, TblPdaStruc As DataTable
    Dim TableTraslada As DataTable

    Private Sub ContabilidadPartidaTrasladoBodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                DescBodegas &= IIf(bodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(1).Value
            End If
        Next
        If bodegas.Length > 0 Then
            Sql = "SELECT MAX(A.DESCRIPCION_BODEGA) AS BODEGA, A.MOVIMIENTO, CUENTA, SUM(CARGO) AS CARGO, SUM(ABONO) AS ABONO, MAX(A.CONTRA_BOD_DESC) AS CONTRA_BOD, FECHA_MOVIMIENTO FROM" & vbCrLf
            Sql &= "(SELECT D.PRODUCTO, E.BODEGA_FINAL AS BODEGA, B.DESCRIPCION_BODEGA, E.BODEGA_INICIAL AS CONTRA_BOD, (SELECT DESCRIPCION_BODEGA FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = 1 AND BODEGA = E.BODEGA_INICIAL) AS CONTRA_BOD_DESC, CASE D.ENTRADA_SALIDA WHEN 1 THEN ROUND(D.COSTO_TOTAL,2) ELSE 0 END AS CARGO, 0.0 AS ABONO," & vbCrLf
            Sql &= "       B.CUENTA_CONTABLE_INVENTARIO AS CUENTA, E.MOVIMIENTO, (SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = 1 AND BODEGA = E.BODEGA_INICIAL) AS BOD, E.FECHA_MOVIMIENTO" & vbCrLf
            Sql &= "FROM INVENTARIOS_TRANSFERENCIAS_ENCABEZADOS E, INVENTARIOS_MOVIMIENTOS_DETALLE D, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            Sql &= "WHERE E.COMPAÑIA = D.COMPAÑIA AND E.BODEGA_FINAL = D.BODEGA AND E.NUMERO_ENTRADA = D.MOVIMIENTO" & vbCrLf
            Sql &= "  AND E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA_FINAL = B.BODEGA" & vbCrLf
            Sql &= "  AND CONVERT(DATE,E.FECHA_MOVIMIENTO) = CONVERT(DATE,'" & Format(Me.dpFechaContable1.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
            Sql &= "  AND D.TIPO_MOVIMIENTO = 1" & vbCrLf
            Sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "  AND E.BODEGA_INICIAL IN (" & bodegas & ")" & vbCrLf
            Sql &= "UNION" & vbCrLf
            Sql &= "SELECT D.PRODUCTO, E.BODEGA_INICIAL AS BODEGA, B.DESCRIPCION_BODEGA, E.BODEGA_FINAL AS CONTRA_BOD, (SELECT DESCRIPCION_BODEGA FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = 1 AND BODEGA = E.BODEGA_FINAL) AS CONTRA_BOD_DESC, 0.0 AS CARGO, CASE D.ENTRADA_SALIDA WHEN 0 THEN ROUND(D.COSTO_TOTAL,2) ELSE 0 END AS ABONO," & vbCrLf
            Sql &= "       B.CUENTA_CONTABLE_INVENTARIO AS CUENTA, E.MOVIMIENTO, (SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = 1 AND BODEGA = E.BODEGA_FINAL) AS BOD, E.FECHA_MOVIMIENTO" & vbCrLf
            Sql &= "FROM INVENTARIOS_TRANSFERENCIAS_ENCABEZADOS E, INVENTARIOS_MOVIMIENTOS_DETALLE D, INVENTARIOS_CATALOGO_BODEGAS B" & vbCrLf
            Sql &= "WHERE E.COMPAÑIA = D.COMPAÑIA AND E.BODEGA_INICIAL = D.BODEGA AND E.NUMERO_SALIDA = D.MOVIMIENTO" & vbCrLf
            Sql &= "  AND E.COMPAÑIA = B.COMPAÑIA AND E.BODEGA_INICIAL = B.BODEGA" & vbCrLf
            Sql &= "  AND CONVERT(DATE,E.FECHA_MOVIMIENTO) = CONVERT(DATE,'" & Format(Me.dpFechaContable1.Value, "dd/MM/yyyy") & "', 103)" & vbCrLf
            Sql &= "  AND D.TIPO_MOVIMIENTO = 4" & vbCrLf
            Sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "  AND E.BODEGA_INICIAL IN (" & bodegas & ")) A WHERE A.CUENTA <> A.BOD  " & vbCrLf
            Sql &= "GROUP BY MOVIMIENTO, CUENTA, FECHA_MOVIMIENTO" & vbCrLf
            Sql &= "ORDER BY MOVIMIENTO, ABONO, FECHA_MOVIMIENTO" & vbCrLf
            sqlCmd.CommandText = Sql
            TableTraslada = jClass.obtenerDatos(sqlCmd)
            If TableTraslada.Rows.Count > 0 Then
                Me.pbAplicar.Visible = True
                Me.pbAplicar.Maximum = TableTraslada.Rows.Count
                Me.pbAplicar.Value = 0
                fechas(0) = Me.dpFechaContable1.Value
                fechas(1) = Me.dpFechaContable1.Value
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
        Dim Libro, Transaccion, NumMovimiento, CtaPercepcion, Partida As Integer
        Dim TotalDetalle As Double
        Dim FechaPartida, FechaMov As Date
        Dim Concepto As String
        Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        CtaPercepcion = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 31"))
        If Not jClass.ValidaCierreContable(Compañia, Libro, FechaContable1.Year, FechaContable1.Month, "E") Then
            Return
        End If
        'Partida por Cuotas de Capital de los diferentes rubros
        If TableTraslada.Rows.Count > 0 Then
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
                Concepto = "Traslado de mercaderías " & DescBodegas & " de fecha " & Format(FechaContable1, "dd/MM/yyyy")
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & FechaContable2.Year & ", @MES = " & FechaContable2.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 2, 34, 0, FechaContable2, Libro, Concepto, 0, 0, "I")
                Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                poneTextoPdas(Partida.ToString(), 1)
            End If
            poneTextoTransI(Transaccion.ToString())
            poneTextoTransF(Transaccion.ToString())
            TotalDetalle = 0
            For i As Integer = 0 To TableTraslada.Rows.Count - 1
                FechaMov = TableTraslada.Rows(i).Item("FECHA_MOVIMIENTO")
                NumMovimiento = TableTraslada.Rows(i).Item("MOVIMIENTO")
                If TableTraslada.Rows(i).Item("CARGO") > 0 Then
                    Concepto = "N.R." & TableTraslada.Rows(i).Item("MOVIMIENTO") & " Traslado productos desde bodega " & TableTraslada.Rows(i).Item("CONTRA_BOD") & ", " & Format(TableTraslada.Rows(i).Item("FECHA_MOVIMIENTO"), "dd/MM/yyyy")
                Else
                    Concepto = "N.R." & TableTraslada.Rows(i).Item("MOVIMIENTO") & " Traslado productos hacia bodega " & TableTraslada.Rows(i).Item("CONTRA_BOD") & ", " & Format(TableTraslada.Rows(i).Item("FECHA_MOVIMIENTO"), "dd/MM/yyyy")
                End If
                jClass.DetallePartida(Transaccion, 0, 0, FechaPartida, Libro, Concepto, TableTraslada.Rows(i).Item("CUENTA"), IIf(TableTraslada.Rows(i).Item("CARGO") > 0, "C", "A"), TableTraslada.Rows(i).Item("CARGO"), TableTraslada.Rows(i).Item("ABONO"), "E")
                Sql = " UPDATE INVENTARIOS_TRANSFERENCIAS_ENCABEZADOS " & vbCrLf
                Sql &= "   SET PARTIDA = " & Partida & ", TRANSACCION = " & Transaccion & vbCrLf
                Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND MOVIMIENTO = " & NumMovimiento & vbCrLf
                Sql &= "   AND FECHA_MOVIMIENTO = CONVERT(DATETIME, '" & Format(FechaMov, "yyyy-MM-dd HH:mm:ss.fff") & "', 121)"
                sqlCmd.CommandText = Sql
                jClass.ejecutarComandoSql(sqlCmd)
                bw1.ReportProgress(1)
            Next
            jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaContable1.Value.Date, Libro, "Concepto", 0, "X", 0, 0, "A")
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
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Partida por Compras")
        Me.pbAplicar.Visible = False
        Me.lblMsj.Visible = False
        Me.lblMsj.Text = "Procesando..."
        Me.btnProcesar.Enabled = True
        For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
            Me.dgvBodegas.Rows(i).Cells(0).Value = False
        Next
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

    Private Sub ContabilidadPartidaTrasladoBodegas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
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