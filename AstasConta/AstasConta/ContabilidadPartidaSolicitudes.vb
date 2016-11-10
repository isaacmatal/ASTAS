Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ContabilidadPartidaSolicitudes

    Dim iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql As String
    Dim Periodo As String = "QQ"
    Dim Table, TblPdaStruc As DataTable
    Dim TableSolic As DataTable
    Dim pdaDeudas, pdaAhorro, pdaInt As Integer

    Private Sub ContabilidadPartidaSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvPartidas.AutoGenerateColumns = False
        CargaTiposoli()
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
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.btnProcesar.Enabled = False
        Me.lblMsj.Visible = True
        Sql = "SELECT S.SOLICITUD" & vbCrLf
        Sql &= "      ,C.DESCRIPCION_SOLICITUD" & vbCrLf
        Sql &= "      ,S.DEDUCCION" & vbCrLf
        Sql &= "      ,S.CORRELATIVO" & vbCrLf
        Sql &= "	  ,S.CODIGO_BUXIS" & vbCrLf
        Sql &= "	  ,S.CODIGO_AS" & vbCrLf
        Sql &= "	  ,S.VALOR_VALE" & vbCrLf
        Sql &= "	  ,SOC.ORIGEN" & vbCrLf
        Sql &= "	  ,A.NUMERO_FACTURA" & vbCrLf
        Sql &= "	  ,C.TIPO_DOCUMENTO" & vbCrLf
        Sql &= "	  ,S.PROVEEDOR" & vbCrLf
        Sql &= "  FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES C, COOPERATIVA_SOLICITUDES_AUTORIZACION A, COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
        Sql &= " WHERE S.COMPAÑIA = C.COMPAÑIA AND S.SOLICITUD = C.SOLICITUD" & vbCrLf
        Sql &= "   AND S.COMPAÑIA = A.COMPAÑIA AND S.CORRELATIVO = A.N_SOLICITUD" & vbCrLf
        Sql &= "   AND S.COMPAÑIA = SOC.COMPAÑIA AND S.CODIGO_BUXIS = SOC.CODIGO_EMPLEADO" & vbCrLf
        Sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "   AND CONVERT(DATE, S.FECHA_SOLICITUD) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
        Sql &= "   AND S.PROGRAMADA = 1" & vbCrLf
        Sql &= "   AND S.SOLICITUD NOT IN (2,9,14,15)" & vbCrLf
        Sql &= "   AND S.SOLICITUD = " & Me.cmbTipoSoli.SelectedValue
        sqlCmd.CommandText = Sql
        TableSolic = jClass.obtenerDatos(sqlCmd)
        If TableSolic.Rows.Count > 0 Then
            Me.pbAplicar.Visible = True
            Me.pbAplicar.Maximum = TableSolic.Rows.Count
            Me.pbAplicar.Value = 0
            fechas(0) = Me.dpFechaSoli.Value
            fechas(1) = Me.dpFechaContable.Value
            pdaInt = Me.cmbTipoSoli.SelectedValue
            'PartidasContables(Me.dpFechaPago.Value)
            Me.bw1.RunWorkerAsync(fechas)
        Else
            Me.btnProcesar.Enabled = True
            Me.lblMsj.Visible = False
            MsgBox("No hay datos para la Fecha y/o" & vbCrLf & " el Tipo de Solicitud seleccionados", MsgBoxStyle.Information, "Partida Solicitudes")
        End If
    End Sub

    Private Sub PartidasContables(ByVal FechaPago As Date, ByVal FechaContable As Date)
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim poneTextoPdas As New CallBackSetText1(AddressOf SetText1)
        Dim poneTextoTransI As New CallBackSetText2(AddressOf SetText2)
        Dim poneTextoTransF As New CallBackSetText3(AddressOf SetText3)
        Dim CtaContable, Libro, Transaccion, TipDoc, CtaDetalle, TipoSoli, Partida As Integer
        Dim TotalDetalle As Double
        Dim ValorNeto As Double
        Dim Cargo, Abono As Double
        Dim RowCta As DataRow() = Me.TableSolic.Select()
        Dim Concepto As String = TableSolic.Rows(0).Item("DESCRIPCION_SOLICITUD") & " DEL " & FechaPago.ToShortDateString
        Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        If Not jClass.ValidaCierreContable(Compañia, Libro, FechaPago.Year, FechaPago.Month, "E") Then
            Return
        End If
        'Partida por Cuotas de Capital de los diferentes rubros
        If TableSolic.Rows.Count > 0 Then
            Partida = Val(Me.txtNumPda.Text)
            If Partida > 0 Then
                Transaccion = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & FechaPago.Month & " AND YEAR(FECHA_CONTABLE) = " & FechaPago.Year & " AND COMPAÑIA = " & Compañia)
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
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            Else
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & FechaContable.Year & ", @MES = " & FechaContable.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 2, TableSolic.Rows(0).Item("TIPO_DOCUMENTO"), 0, FechaContable, Libro, Concepto, 0, 0, "I")
                Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                poneTextoPdas(Partida.ToString(), 1)
            End If
            poneTextoTransI(Transaccion.ToString())
            poneTextoTransF(Transaccion.ToString())
            TotalDetalle = 0
            For i As Integer = 0 To TableSolic.Rows.Count - 1
                TipoSoli = TableSolic.Rows(i).Item("SOLICITUD")
                TipDoc = TableSolic.Rows(i).Item("TIPO_DOCUMENTO")
                sqlCmd.CommandText = "SELECT CUENTA, CARGO, VALOR, OBSERVACIONES FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS WHERE COMPAÑIA = " & Compañia & " AND TIPO_DOCUMENTO = " & TipDoc & " AND ORIGEN = " & TableSolic.Rows(i).Item("ORIGEN") & " AND CENTRO_COSTO = 1"
                TblPdaStruc = jClass.obtenerDatos(sqlCmd)
                If TblPdaStruc.Rows.Count > 0 Then
                    RowCta = TblPdaStruc.Select("[OBSERVACIONES] = 'DETALLE'")
                    If RowCta.Length > 0 Then
                        CtaDetalle = RowCta(0).Item("CUENTA")
                    Else
                        CtaDetalle = 0
                    End If
                    jClass.DetallePartida(Transaccion, 0, TableSolic.Rows(i).Item("CODIGO_BUXIS"), FechaPago.Date, Libro, Concepto & IIf(TableSolic.Rows(i).Item("NUMERO_FACTURA") > 0, " No." & TableSolic.Rows(i).Item("NUMERO_FACTURA"), ""), CtaDetalle, "C", TableSolic.Rows(i).Item("VALOR_VALE"), 0, "E")
                    If TableSolic.Rows(i).Item("PROVEEDOR") > 0 Then
                        For J As Integer = 0 To TblPdaStruc.Rows.Count - 1
                            If TblPdaStruc.Rows(J).Item("OBSERVACIONES") = "PROVEEDOR" Then
                                CtaContable = TblPdaStruc.Rows(J).Item("CUENTA")
                                jClass.DetallePartida(Transaccion, 0, TableSolic.Rows(i).Item("PROVEEDOR"), Me.dpFechaSoli.Value.Date, Libro, Concepto, CtaContable, "A", Cargo, TableSolic.Rows(i).Item("VALOR_VALE"), "E")
                            End If
                        Next
                    Else
                        TotalDetalle += TableSolic.Rows(i).Item("VALOR_VALE")
                    End If
                    bw1.ReportProgress(1)
                End If
            Next
            ValorNeto = 0
            Cargo = 0
            Abono = 0
            If TotalDetalle > 0 Then
                ValorNeto = Math.Round(TotalDetalle / ((RowCta(0).Item("VALOR") / 100)), 2, MidpointRounding.AwayFromZero)
                For i As Integer = 0 To TblPdaStruc.Rows.Count - 1
                    If TblPdaStruc.Rows(i).Item("OBSERVACIONES") <> "DETALLE" And TblPdaStruc.Rows(i).Item("OBSERVACIONES") <> "PROVEEDOR" Then
                        CtaContable = TblPdaStruc.Rows(i).Item("CUENTA")
                        Cargo = IIf(CBool(Me.TblPdaStruc.Rows(i).Item("CARGO")), ValorNeto * (Me.TblPdaStruc.Rows(i).Item("VALOR") / 100), 0)
                        Abono = IIf(Not CBool(Me.TblPdaStruc.Rows(i).Item("CARGO")), ValorNeto * (Me.TblPdaStruc.Rows(i).Item("VALOR") / 100), 0)
                        jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaSoli.Value.Date, Libro, Concepto, CtaContable, "C", Cargo, Abono, "E")
                    End If
                Next
            End If
            jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaContable.Value.Date, Libro, Concepto, 0, "X", 0, 0, "A")
            Sql = " UPDATE COOPERATIVA_SOLICITUDES " & vbCrLf
            Sql &= "   SET PARTIDA = " & Partida & ", TRANSACCION = " & Transaccion & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CONVERT(DATE, FECHA_SOLICITUD) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
            Sql &= "   AND PROGRAMADA = 1" & vbCrLf
            Sql &= "   AND SOLICITUD NOT IN (2,9,14,15)" & vbCrLf
            Sql &= "   AND SOLICITUD = " & pdaInt
            sqlCmd.CommandText = Sql
            jClass.ejecutarComandoSql(sqlCmd)
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
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpts As New frmReportes_Ver
        If Val(Me.txtTransaccionInicial.Text) > 0 Then
            rpts.CargaPartida(Compañia, jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"), Me.txtTransaccionInicial.Text, Me.txtTransaccionFinal.Text, Me.dpFechaSoli.Value.Year, Me.dpFechaSoli.Value.Month, 1)
            rpts.ShowDialog()
        End If
    End Sub

    Private Sub CargaTiposoli()
        sqlCmd.CommandText = "SELECT SOLICITUD, DESCRIPCION_SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD NOT IN (2,9,14,15)"
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbTipoSoli.DataSource = Table
        Me.cmbTipoSoli.ValueMember = "SOLICITUD"
        Me.cmbTipoSoli.DisplayMember = "DESCRIPCION_SOLICITUD"
        Me.cmbTipoSoli.SelectedIndex = 0
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

    Private Sub cmbTipoSoli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoSoli.SelectedIndexChanged
        Me.txtNumPda.Clear()
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.dgvPartidas.DataSource = Nothing
    End Sub

    Private Sub ContabilidadPartidaSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub dpFechaPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaSoli.ValueChanged
        Me.dpFechaContable.Value = Me.dpFechaSoli.Value
    End Sub

    Private Sub txtNumPda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPda.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub
End Class