'Desarrollado por Benjamin Parada, editado por Jonathan Peña
'ReDefinido y Re-elaborado por Isaac Matal porque el usuario 
'dijo que de la forma en que estaba le era muy trabajoso y 
'que además no le funcionaba tener una partida contable por 
'cada solcitud de préstamo pagada por cuestiones de 
'cuadratura contra documentos.

Imports System.Data.SqlClient

Public Class FrmCooperativaPagoSolicitudesPrestamos
    Dim fill As New jarsClass
    Dim genRemesa As New generarRemesa
    Dim sql As String = ""
    Dim LibroContable As Integer = 0
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim CodBco As Integer = 0
    Dim Cod_AS As String
    Dim Cod_Buxis, Cheque, Transaccion As Integer
    Dim Nombre_Socio, Permitir As String
    Dim Partida, CantRems, TipoDoc As Integer
    Dim TotalPda As Double
    Dim CtaBcoCompleta, Documento As String
    Dim TablaPdas As New DataTable("pdas")
    Dim TablaRecibos As New DataTable("recs")

    Private Sub FrmCooperativaPagoSolicitudesPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.DgvProgramaciones.AutoGenerateColumns = False
        Try
            Permitir = fill.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CrearTabla()
        combosIni()
        CargaProgramaciones()
        Me.WindowState = FormWindowState.Normal
        Iniciando = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        CargaProgramaciones()
    End Sub

    Private Sub CargaProgramaciones()
        Try
            LibroContable = fill.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
            CtaBcoCompleta = fill.obtenerEscalar("SELECT CUENTA_BANCARIA FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & LibroContable & " AND CUENTA = " & Me.cmbCuentaBancoAsociacion.SelectedValue)
            CodBco = fill.obtenerEscalar("SELECT BANCO FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & LibroContable & " AND CUENTA = " & Me.cmbCuentaBancoAsociacion.SelectedValue)
            sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PROGRAMACIONES_USUARIO " & Compañia & ",'0000000',0,3, " & CodBco & ", '" & Permitir & "'"
            sqlCmd.CommandText = sql
            Table = fill.obtenerDatos(sqlCmd)
            Me.DgvProgramaciones.DataSource = Table
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function recorrerDGV(ByVal Bloque As Integer) As Boolean
        CantRems = 0
        Dim TablaRecTemp As New DataTable("rectemp")
        Dim Cuenta, corrBAC, OrigenEmp As Integer
        Dim MontoPda As Double
        Dim NumPartida As String = String.Empty
        TablaRecibos.Reset()
        If Me.DgvProgramaciones.Rows.Count > 0 Then
            While TablaPdas.Rows.Count > 0
                TablaPdas.Rows.RemoveAt(0)
            End While
            For i As Integer = 0 To Me.DgvProgramaciones.Rows.Count - 1
                If Me.DgvProgramaciones.Rows(i).Cells(0).Value Then
                    MontoPda += Me.DgvProgramaciones.Rows(i).Cells(7).Value
                    Cuenta += 1
                End If
            Next
            If Cuenta = 0 Then
                MsgBox("Debe seleccionar al menos un registro para procesar.", MsgBoxStyle.Information, "Validación")
                Return False
            End If
            For i As Integer = 0 To Me.DgvProgramaciones.Rows.Count - 1
                If Me.DgvProgramaciones.Rows(i).Cells(0).Value = True Then
                    Me.lblProc.Text &= "."
                    LibroContable = fill.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
                    CtaBcoCompleta = fill.obtenerEscalar("SELECT CUENTA_BANCARIA FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & LibroContable & " AND CUENTA = " & Me.cmbCuentaBancoAsociacion.SelectedValue)
                    CodBco = fill.obtenerEscalar("SELECT BANCO FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & LibroContable & " AND CUENTA = " & Me.cmbCuentaBancoAsociacion.SelectedValue)
                    CantRems += 1
                    genRemesa.monto = 0
                    genRemesa.Bloque = Bloque.ToString
                    genRemesa.TipoTran = "PRESTAMOS"
                    genRemesa.FechaDep = Format(Me.dpFechaProceso.Value, "yyyyMMdd")
                    If CodBco = 3 And CantRems = 1 Then
                        'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
                        corrBAC = CInt(fill.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                        corrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", corrBAC))

                        fill.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (corrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                        genRemesa.EncabBAC = "B4978" & corrBAC.ToString("00000") & Format(Me.dpFechaProceso.Value, "yyyyMMdd").PadLeft(33, " ") & (MontoPda * 100).ToString().PadLeft(13, " ") & Cuenta.ToString().PadLeft(5, " ")
                        genRemesa.setEncab = True
                    Else
                        genRemesa.setEncab = False
                    End If
                    If CantRems = 1 Then
                        genRemesa.sn = True
                    Else
                        genRemesa.sn = False
                    End If
                    If Cuenta = CantRems Then
                        genRemesa.abrirCarpeta = True
                    Else
                        genRemesa.abrirCarpeta = False
                    End If
                    genRemesa.recibirParametros(Compañia, CodBco, CtaBcoCompleta, Me.DgvProgramaciones.Rows(i).Cells(1).Value, Me.DgvProgramaciones.Rows(i).Cells(2).Value, Me.DgvProgramaciones.Rows(i).Cells(3).Value, "PRESTAMO")
                    fill.mttoRemesasProgSolicitudes(Compañia, 0, Me.DgvProgramaciones.Rows(i).Cells(1).Value, Me.DgvProgramaciones.Rows(i).Cells(3).Value, Me.DgvProgramaciones.Rows(i).Cells(2).Value _
                                                     , Me.DgvProgramaciones.Rows(i).Cells(7).Value, CodBco, CtaBcoCompleta _
                                                     , Me.dpFechaProceso.Value.Date, 1, "I", Bloque)
                    sql = "UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS"
                    sql &= " SET BANCO = " & CodBco
                    sql &= ", CUENTA_BANCARIA = " & Me.cmbCuentaBancoAsociacion.SelectedValue
                    sql &= ", REMESA = 1"
                    sql &= ", PAGADA = 1"
                    sql &= " WHERE COMPAÑIA = " & Compañia
                    sql &= " AND CORRELATIVO = " & Me.DgvProgramaciones.Rows(i).Cells(1).Value
                    sqlCmd.CommandText = sql
                    fill.ejecutarComandoSql(sqlCmd)

                    sql = "UPDATE COOPERATIVA_SOLICITUDES"
                    sql &= " SET FECHA_SOLICITUD = '" & Format(Me.dpFechaProceso.Value, "dd/MM/yyyy") & "'"
                    sql &= " WHERE COMPAÑIA = " & Compañia
                    sql &= " AND CORRELATIVO = " & Me.DgvProgramaciones.Rows(i).Cells(1).Value
                    sqlCmd.CommandText = sql
                    fill.ejecutarComandoSql(sqlCmd)

                    sql = "SELECT TIPO_DOCUMENTO FROM COOPERATIVA_CATALOGO_SOLICITUDES" & vbCrLf
                    sql &= " WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = "
                    sql &= fill.obtenerEscalar("SELECT SOLICITUD FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.DgvProgramaciones.Rows(i).Cells(1).Value)
                    TipoDoc = fill.obtenerEscalar(sql)

                    sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                    sql &= " WHERE ORIGEN = " & Me.DgvProgramaciones.Rows(i).Cells(11).Value & vbCrLf
                    sql &= "   AND TIPO_DOCUMENTO = " & TipoDoc & " AND CENTRO_COSTO = 1" & vbCrLf
                    sql &= "   AND CARGO = 1 AND COMPAÑIA = " & Compañia
                    OrigenEmp = Me.DgvProgramaciones.Rows(i).Cells(11).Value
                    LlenarTabla(CInt(fill.obtenerEscalar(sql)), _
                                Me.DgvProgramaciones.Rows(i).Cells(3).Value, _
                                Me.DgvProgramaciones.Rows(i).Cells(11).Value, _
                                Me.DgvProgramaciones.Rows(i).Cells(1).Value, _
                                Me.DgvProgramaciones.Rows(i).Cells(7).Value, _
                                "", _
                                "Solicitud #" & Me.DgvProgramaciones.Rows(i).Cells(1).Value & ", " & Me.DgvProgramaciones.Rows(i).Cells(3).Value & " " & Me.DgvProgramaciones.Rows(i).Cells(4).Value)
                End If
            Next
            '--------------------'
            ' Imprime el recibo  '
            '--------------------'
            If TablaRecibos.Rows.Count > 0 Then
                Dim frmVer As New frmReportes_Ver
                Dim Rpts As New CooperativaSolicitudesPrestamosRecibos
                Dim Rpts1 As New CooperativaSolicitudesPrestamosRecibosATAF
                If OrigenEmp = 5 Or OrigenEmp = 6 Then
                    Rpts1.SetDataSource(TablaRecibos)
                    frmVer.ReportesGenericos(Rpts1)
                Else
                    Rpts.SetDataSource(TablaRecibos)
                    frmVer.ReportesGenericos(Rpts)
                End If
                frmVer.ShowDialog()
            End If
            '---------------------------------'
            '-- Partida                     --'
            '-- Se crea una por cada remesa --'
            '---------------------------------'
            'While True
            '    NumPartida = InputBox("Ingrese un número de partida que esté reservado para este movimiento." & vbCrLf & _
            '                          "SI NO HAY PARTIDA RESERVADA haga click en aceptar y se generará una partida nueva." & vbCrLf & _
            '                          NumPartida, "VENTAS AL CREDITO", "0")
            '    If IsNumeric(NumPartida) Then
            '        Exit While
            '    Else
            '        NumPartida = "El valor debe ser un número de partida válido"
            '    End If
            'End While
            'Partida = Val(NumPartida)
            'If Partida > 0 Then
            '    Transaccion = fill.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & Partida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaProceso.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaProceso.Value.Year & " AND COMPAÑIA = " & Compañia)
            '    If Transaccion = 0 Then
            '        MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
            '        Return False
            '    Else
            '        If fill.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & Transaccion & " AND COMPAÑIA = " & Compañia) Then
            '            MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
            '            Return False
            '        Else
            '            If fill.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
            '                If MsgBox("La partida No." & Partida & " tiene detalle, si continúa el detalle se eliminará." & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
            '                    fill.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            '                Else
            '                    MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
            '                    Return False
            '                End If
            '            End If
            '        End If
            '    End If
            '    fill.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = 'Carta de Préstamos' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            'Else
            '    Transaccion = fill.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & Me.dpFechaProceso.Value.Year & ", @MES = " & Me.dpFechaProceso.Value.Month & ", @ULTIMO = 0")
            '    Partida = fill.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'PAR', @AÑO = " & Me.dpFechaProceso.Value.Year & ", @MES = " & Me.dpFechaProceso.Value.Month & ", @ULTIMO = 0")
            '    fill.EncabezadoPartida2(Transaccion, 1, TipoDoc, "0", Me.dpFechaProceso.Value, LibroContable, "Carta de Préstamos", 0, 0, "I", Partida)
            'End If
            'TotalPda = 0
            'For i As Integer = 0 To TablaPdas.Rows.Count - 1
            '    fill.DetallePartida(Transaccion, 0, TablaPdas.Rows(i).Item(1), Me.dpFechaProceso.Value, LibroContable, TablaPdas.Rows(i).Item(6), TablaPdas.Rows(i).Item(0), "X", TablaPdas.Rows(i).Item(4), 0, "E")
            '    TotalPda += TablaPdas.Rows(i).Item(4)
            '    fill.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOLICITUDES SET PARTIDA = " & Partida & ", TRANSACCION = " & Transaccion & " WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & TablaPdas.Rows(i).Item(3))
            'Next
            'fill.DetallePartida(Transaccion, 0, 0, Me.dpFechaProceso.Value, LibroContable, "Pago de Préstamos con Cheque", Me.cmbCuentaBancoAsociacion.SelectedValue, "X", 0, TotalPda, "E")
            'fill.DetallePartida(Transaccion, 0, 0, Me.dpFechaProceso.Value, LibroContable, String.Empty, 0, "C", 0, 0, "A")
        Else
            MsgBox("¡No hay registros para procesar!", MsgBoxStyle.Information, "Mensaje")
            Return False
        End If
    End Function

    Private Sub combosIni()
        Try
            sql = "SELECT A.DESCRIPCION_BANCO + ' No.' + B.CUENTA_BANCARIA AS CUENTA_BANCARIA, CUENTA "
            sql &= "FROM dbo.CONTABILIDAD_CATALOGO_BANCOS A, dbo.CONTABILIDAD_CATALOGO_BANCOS_CUENTAS B "
            sql &= "WHERE A.COMPAÑIA = B.COMPAÑIA AND A.BANCO = B.BANCO "
            sql &= "UNION SELECT '(Sin definir)' AS CUENTA_BANCARIA, 0 AS CUENTA"
            sqlCmd = New SqlCommand(sql)
            Me.cmbCuentaBancoAsociacion.DataSource = fill.obtenerDatos(sqlCmd)
            Me.cmbCuentaBancoAsociacion.ValueMember = "CUENTA"
            Me.cmbCuentaBancoAsociacion.DisplayMember = "CUENTA_BANCARIA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error cargando combos")
        End Try
    End Sub
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If MsgBox("¿Desea procesar el pago del socio?", MsgBoxStyle.YesNo, "AVISO") = MsgBoxResult.Yes Then
            If Me.cmbCuentaBancoAsociacion.SelectedValue = 0 Then
                MessageBox.Show("Debe seleccionar una cuenta de la asociación.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim Bloque As Integer
            Bloque = fill.obtenerEscalar("SELECT ISNULL(MAX(BLOQUE),0) + 1 FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS WHERE COMPAÑIA = " & Compañia & " AND CONVERT(DATE, FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaProceso.Value, "dd/MM/yyyy") & "', 103)" & " AND UBICACION = 1 AND BANCO = " & CodBco)
            Me.lblProc.Visible = True
            recorrerDGV(Bloque)
            CargaProgramaciones()
            Me.lblProc.Visible = False
            Me.lblProc.Text = "Procesando"
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

    Private Sub LlenarTabla(ByVal cuenta As Integer, ByVal detalle As Integer, ByVal origen As Integer, ByVal tipdoc As Integer, ByVal valor As Double, ByVal documento As String, ByVal concepto As String)
        Dim contador As Integer = 0
        'For i As Integer = 0 To TablaPdas.Rows.Count - 1
        '    If TablaPdas.Rows(i).Item("cuenta") = cuenta And TablaPdas.Rows(i).Item("origen") = origen And TablaPdas.Rows(i).Item("tipdoc") = tipdoc Then
        '        TablaPdas.Rows(i).Item("valor") += valor
        '        TablaPdas.Rows(i).Item("documento") &= "," & documento
        '        TablaPdas.Rows(i).Item("concepto") &= vbCrLf & concepto
        '        TablaPdas.Rows(i).Item("cantidad") += 1
        '        contador += 1
        '    End If
        'Next
        'If contador = 0 Then
        TablaPdas.Rows.Add(cuenta, detalle, origen, tipdoc, valor, documento, concepto, 1)
        'End If
    End Sub

    'Private Sub Reportes()
    '    Dim frmrepo As New FrmCooperativaConsultaChequeRemesaSolicitudPrestamo
    '    frmrepo.Company_Value = Compañia
    '    frmrepo.ShowDialog()
    'End Sub

    Private Sub lblSelecciona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSelecciona.Click
        Dim i As Integer
        Dim valor As Boolean

        If Me.DgvProgramaciones.Rows(0).Cells(0).Value = True Then
            valor = False
        Else
            valor = True
        End If


        For i = 0 To Me.DgvProgramaciones.Rows.Count - 1
            Me.DgvProgramaciones.Rows(i).Cells(0).Value = valor

        Next
        Dim xmonto As Double = 0.0
        For i = 0 To Me.DgvProgramaciones.Rows.Count - 1
            If Me.DgvProgramaciones.Rows(i).Cells("procesa").Value Then
                xmonto += Me.DgvProgramaciones.Rows(i).Cells("monto_pendiente").Value
            End If
        Next
        Me.Label14.Text = "Total: $ " & Format(xmonto, "#,##0.00")
    End Sub

    Private Sub FrmCooperativaPagoSolicitudesPrestamos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub cmbCuentaBancoAsociacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuentaBancoAsociacion.SelectedIndexChanged
        If Not Iniciando Then
            CargaProgramaciones()
            Me.Label14.Text = "Total: $ " & Format(0, "#,##0.00")
        End If
    End Sub

    Private Sub DgvProgramaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProgramaciones.CellContentClick
        Dim i As Integer
        Dim xmonto As Double = 0.0
        If DgvProgramaciones.CurrentRow.Cells("procesa").Value Then
            DgvProgramaciones.CurrentRow.Cells("procesa").Value = False
        Else
            DgvProgramaciones.CurrentRow.Cells("procesa").Value = True
        End If
        For i = 0 To Me.DgvProgramaciones.Rows.Count - 1
            If Me.DgvProgramaciones.Rows(i).Cells("procesa").Value Then
                xmonto += Me.DgvProgramaciones.Rows(i).Cells("monto_pendiente").Value
            End If
        Next
        Me.Label14.Text = "Total: $ " & Format(xmonto, "#,##0.00")
    End Sub
End Class