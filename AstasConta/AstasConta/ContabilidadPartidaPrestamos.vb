Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ContabilidadPartidaPrestamos

    Dim iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql As String
    Dim Periodo As String = "QQ"
    Dim Table, TblPdaStruc As DataTable
    Dim TableSolic As DataTable
    Dim pdaDeudas, pdaAhorro, pdaInt As Integer
    Dim TablaPdas As New DataTable("pdas")

    Private Sub ContabilidadPartidaPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvPartidas.AutoGenerateColumns = False
        jClass.CargaBancos(Compañia, Me.cmbBancos)
        CrearTabla()
        iniciando = False
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.btnProcesar.Enabled = False
        Me.lblMsj.Visible = True
        If Me.rbPrestamos.Checked Then
            If Me.rbRemesa.Checked Then
                Sql = "SELECT C.CUENTA, R.CODIGO_EMPLEADO, " & vbCrLf
                Sql &= "       (SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = 1 AND CODIGO_EMPLEADO = R.CODIGO_EMPLEADO) AS ORIGEN," & vbCrLf
                Sql &= "       R.MONTO, 'SOLICITUD DE PRESTAMO #' + CONVERT(VARCHAR,R.SOLICITUD) AS CONCEPTO, S.SOLICITUD, 0 AS PAPELERIA" & vbCrLf
                Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS R, CONTABILIDAD_CATALOGO_BANCOS_CUENTAS C, COOPERATIVA_SOLICITUDES S" & vbCrLf
                Sql &= " WHERE R.COMPAÑIA = C.COMPAÑIA And R.BANCO = C.BANCO And R.CUENTA_BANCARIA = C.CUENTA_BANCARIA" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = S.COMPAÑIA AND R.SOLICITUD = S.CORRELATIVO" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND CONVERT(DATE, R.FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
                Sql &= "   AND R.UBICACION = 1 " & vbCrLf
                Sql &= "   AND R.BANCO = " & Me.cmbBancos.SelectedValue & vbCrLf
                Sql &= "   AND R.BLOQUE = " & CInt(Me.nudCorrelat.Value)
            Else
                Sql = "SELECT C.CUENTA, R.CODIGO_EMPLEADO, " & vbCrLf
                Sql &= "       (SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = 1 AND CODIGO_EMPLEADO = R.CODIGO_EMPLEADO) AS ORIGEN," & vbCrLf
                Sql &= "       R.TOTAL AS MONTO, 'SOLICITUD DE PRESTAMO #' + CONVERT(VARCHAR,R.SOLICITUD) + ', Cheque #'+ CONVERT(VARCHAR, R.CHEQUE) AS CONCEPTO, S.SOLICITUD, R.PAPELERIA" & vbCrLf
                Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES R, CONTABILIDAD_CATALOGO_BANCOS_CUENTAS C, COOPERATIVA_SOLICITUDES S" & vbCrLf
                Sql &= " WHERE R.COMPAÑIA = C.COMPAÑIA AND R.BANCO = C.BANCO AND R.CUENTA_BANCARIA = C.CUENTA_BANCARIA" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = S.COMPAÑIA AND R.SOLICITUD = S.CORRELATIVO" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND CONVERT(DATE, R.FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
                Sql &= "   AND R.PERIODO IN (SELECT PERIODO FROM FACTURACION_CATALOGO_PERIODOS_CUOTA WHERE COMPAÑIA = " & Compañia & ")" & vbCrLf
                Sql &= "   AND R.BANCO = " & Me.cmbBancos.SelectedValue
            End If
        Else
            If Me.rbRemesa.Checked Then
                Sql = "SELECT C.CUENTA, R.CODIGO_EMPLEADO, " & vbCrLf
                Sql &= "       (SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = 1 AND CODIGO_EMPLEADO = R.CODIGO_EMPLEADO) AS ORIGEN," & vbCrLf
                Sql &= "       R.MONTO, 'RETIRO DE AHORRO EXTRAORDINARIO' AS CONCEPTO, 0 AS SOLICITUD, 0 AS PAPELERIA" & vbCrLf
                Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS R, CONTABILIDAD_CATALOGO_BANCOS_CUENTAS C, COOPERATIVA_SOCIO_RETIROS S" & vbCrLf
                Sql &= " WHERE R.COMPAÑIA = C.COMPAÑIA AND R.BANCO = C.BANCO AND R.CUENTA_BANCARIA = C.CUENTA_BANCARIA" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = S.COMPAÑIA AND R.SOLICITUD = S.RETIRO" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND CONVERT(DATE, R.FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
                Sql &= "   AND R.UBICACION = 2 " & vbCrLf
                Sql &= "   AND R.BANCO = " & Me.cmbBancos.SelectedValue & vbCrLf
                Sql &= "   AND R.BLOQUE = " & CInt(Me.nudCorrelat.Value) & vbCrLf
                Sql &= "   AND S.RETIRO_ASOCIACION = 0"
            Else
                Sql = "SELECT C.CUENTA, R.CODIGO_EMPLEADO, " & vbCrLf
                Sql &= "       (SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = 1 AND CODIGO_EMPLEADO = R.CODIGO_EMPLEADO) AS ORIGEN," & vbCrLf
                Sql &= "       R.TOTAL AS MONTO, 'RETIRO DE AHORRO EXTRAORDINARIO, Cheque #'+ CONVERT(VARCHAR, R.CHEQUE) AS CONCEPTO, 0 AS SOLICITUD, R.PAPELERIA" & vbCrLf
                Sql &= "  FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES R, CONTABILIDAD_CATALOGO_BANCOS_CUENTAS C, COOPERATIVA_SOCIO_RETIROS S" & vbCrLf
                Sql &= " WHERE R.COMPAÑIA = C.COMPAÑIA And R.BANCO = C.BANCO AND R.CUENTA_BANCARIA = C.CUENTA_BANCARIA" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = S.COMPAÑIA AND R.SOLICITUD = S.RETIRO" & vbCrLf
                Sql &= "   AND R.COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND CONVERT(DATE, R.FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103) " & vbCrLf
                Sql &= "   AND R.PERIODO like 'Retiro%' " & vbCrLf
                Sql &= "   AND R.BANCO = " & Me.cmbBancos.SelectedValue
                Sql &= "   AND S.RETIRO_ASOCIACION = 0"
            End If
        End If
        sqlCmd.CommandText = Sql
        TableSolic = jClass.obtenerDatos(sqlCmd)
        If TableSolic.Rows.Count > 0 Then
            Me.pbAplicar.Visible = True
            Me.pbAplicar.Maximum = TableSolic.Rows.Count * 2
            Me.pbAplicar.Value = 0
            PartidasContables()
        Else
            Me.btnProcesar.Enabled = True
            Me.lblMsj.Visible = False
            MsgBox("No hay datos para la Fecha y/o" & vbCrLf & " el Banco seleccionados", MsgBoxStyle.Information, "Partida Remesas")
        End If
    End Sub

    Private Sub PartidasContables()
        Dim TipoDoc, CtaCargo, CtaAbono, Partida, Transaccion, LibroContable, ctaPapeleria As Integer
        Dim TotalPda, TotPapeleria As Double
        TotPapeleria = 0
        Try
            LibroContable = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
            If jClass.ValidaCierreContable(Compañia, LibroContable, Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month, "E") Then
                While TablaPdas.Rows.Count > 0
                    TablaPdas.Rows.RemoveAt(0)
                End While
                CtaAbono = TableSolic.Rows(0).Item(0)
                For Each row As DataRow In TableSolic.Rows
                    If Me.rbPrestamos.Checked Then
                        Sql = "SELECT TIPO_DOCUMENTO FROM COOPERATIVA_CATALOGO_SOLICITUDES" & vbCrLf
                        Sql &= " WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & row.Item(5).ToString()
                        TipoDoc = jClass.obtenerEscalar(Sql)

                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= " WHERE ORIGEN = " & row.Item(2).ToString() & vbCrLf
                        Sql &= "   AND TIPO_DOCUMENTO = " & TipoDoc & " AND CENTRO_COSTO = 1" & vbCrLf
                        Sql &= "   AND CARGO = 1 AND COMPAÑIA = " & Compañia
                        CtaCargo = jClass.obtenerEscalar(Sql)
                    Else
                        CtaCargo = jClass.obtenerEscalar("SELECT CUENTA_CONTABLE_AHORROS_EXTORD FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & row.Item(2))
                    End If
                    If Me.rbRemesa.Checked Then
                        TotPapeleria = 0
                    Else
                        TotPapeleria += CDbl(row.Item(6))
                    End If
                    TablaPdas.Rows.Add(CtaCargo, row.Item(1), row.Item(2), TipoDoc, row.Item(3), "0", row.Item(4), 1)
                    Me.pbAplicar.Value += 1
                Next
                '---------------------------------'
                '-- Partida                     --'
                '-- Se crea una por cada remesa --'
                '---------------------------------'
                Partida = Val(Me.txtNumPda.Text)
                If Partida > 0 Then
                    Transaccion = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPAÑIA = " & Compañia)
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
                    'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & IIf(Me.rbPrestamos.Checked, "Pago de Solicitudes Préstamos", "Pago de Retiros Ahorros Extraordinarios") & IIf(Me.rbRemesa.Checked, " por Abono a Cuenta", " con Cheque") & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                Else
                    Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & Me.dpFechaContable.Value.Year & ", @MES = " & Me.dpFechaContable.Value.Month & ", @ULTIMO = 0")
                    Partida = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'PAR', @AÑO = " & Me.dpFechaContable.Value.Year & ", @MES = " & Me.dpFechaContable.Value.Month & ", @ULTIMO = 0")
                    jClass.EncabezadoPartida2(Transaccion, 1, TipoDoc, "0", Me.dpFechaContable.Value, LibroContable, IIf(Me.rbPrestamos.Checked, "Pago de Solicitudes Préstamos", "Pago de Retiros Ahorros Extraordinarios") & IIf(Me.rbRemesa.Checked, " por Abono a Cuenta", " con Cheque"), 0, 0, "I", Partida)
                End If
                Me.txtTransaccionInicial.Text = Transaccion
                Me.txtTransaccionFinal.Text = Transaccion
                Me.txtNumPda.Text = Partida.ToString()
                TotalPda = 0
                For i As Integer = 0 To TablaPdas.Rows.Count - 1
                    jClass.DetallePartida(Transaccion, 0, TablaPdas.Rows(i).Item(1), Me.dpFechaContable.Value, LibroContable, TablaPdas.Rows(i).Item(6), TablaPdas.Rows(i).Item(0), "X", TablaPdas.Rows(i).Item(4), 0, "E")
                    TotalPda += TablaPdas.Rows(i).Item(4)
                    Me.pbAplicar.Value += 1
                Next
                jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaContable.Value, LibroContable, "Pago de " & IIf(Me.rbPrestamos.Checked, "Préstamos", "Ahorros Extraordinarios") & IIf(Me.rbRemesa.Checked, " por Abono a Cuenta", " con Cheque"), CtaAbono, "X", 0, TotalPda - TotPapeleria, "E")
                If TotPapeleria > 0 Then
                    ctaPapeleria = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 23"))
                    jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaContable.Value, LibroContable, "Pago de " & IIf(Me.rbPrestamos.Checked, "Préstamos con cheque", "Ahorros Extraordinarios con cheque"), ctaPapeleria, "X", 0, TotPapeleria, "E")
                End If
                jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaContable.Value, LibroContable, String.Empty, 0, "C", 0, 0, "A")
            End If
            ProcesoFinalizado()
        Catch ex As Exception
            jClass.msjError(ex, "Partida Remesas")
        End Try
    End Sub

    Private Sub ProcesoFinalizado()
        CargaPartida_Detalle()
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Partida Remesas")
        Me.pbAplicar.Visible = False
        Me.lblMsj.Visible = False
        Me.lblMsj.Text = "Procesando..."
        Me.btnProcesar.Enabled = True
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpts As New frmReportes_Ver
        If Val(Me.txtTransaccionInicial.Text) > 0 Then
            rpts.CargaPartida(Compañia, jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"), Me.txtTransaccionInicial.Text, Me.txtTransaccionFinal.Text, Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month, 1)
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

    Private Sub cmbTipoSoli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
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

    Private Sub txtNumPda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPda.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub CrearTabla()
        TablaPdas.Columns.Add("cuenta", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("detalle", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("origen", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("tipdoc", Type.GetType("System.Int32"))
        TablaPdas.Columns.Add("valor", Type.GetType("System.Double"))
        TablaPdas.Columns.Add("documento", Type.GetType("System.String"))
        TablaPdas.Columns.Add("concepto", Type.GetType("System.String"))
        TablaPdas.Columns.Add("cantidad", Type.GetType("System.Int32"))
    End Sub
End Class