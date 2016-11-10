Imports System.Data.SqlClient

Public Class Facturacion_Partida_Contable_Consumidor_Final

    Dim jClass As New jarsClass
    Dim Sql As String
    Dim SqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim PorcIVA As Double
    Dim LibroC As Integer

    Private Sub Facturacion_Partida_Contable_Consumidor_Final_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PorcIVA = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 1 AND COMPAÑIA = " & Compañia)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBodegas()
        Me.dgvPartidas.AutoGenerateColumns = False
        LibroC = CInt(jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE_PRINCIPAL @COMPAÑIA = " & Compañia))
    End Sub
    Private Sub CargaBodegas()
        Sql = "Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compañia & ", 0, '" & Usuario & "'"
        SqlCmd = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(SqlCmd)
        Me.cmbBodega.DataSource = Table
        Me.cmbBodega.ValueMember = "BODEGA"
        Me.cmbBodega.DisplayMember = "DESCRIPCION_BODEGA"
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim sqlCmd As New SqlCommand
        Dim CtaContable As Integer = 0
        Dim NumPartida As Integer = 0
        Dim NumTran As Integer = 0
        Dim primerDoc, ultDoc, primerDocCCF, ultDocCCF As Integer
        Dim Linea, CtaCargo, CtaAbono, CtaAbonoIVA, CtaCESC As Integer
        Dim TotalFact, TotalIVAFact, SubTotalFact, TotalIVA, SubTotal As Double
        Dim Partida As String = String.Empty
        Dim DevolResult As Boolean
        Me.dgvPartidas.DataSource = Nothing
        Try
            If ValidaCierreContable(Compañia, LibroC, Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), "E") Then
                CtaCESC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 56"))
                'Crédito
                Sql = "SELECT CODIGO_EMPLEADO, CLIENTE, TOTAL_FACTURA AS TOTAL, ORIGEN, CENTRO_COSTO, FORMA_PAGO, AHORRO_EXTRA AS AEXTRA, NUMERO_FACTURA, SUB_TOTAL, TOTAL_IVA, TIPO_DOCUMENTO, RETENCION " & vbCrLf
                Sql &= "  FROM dbo.FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= " WHERE TOTAL_FACTURA >= 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                'Sql &= "   AND TIPO_DOCUMENTO = " & IIf(Me.rbFact.Checked, "1", "2") & vbCrLf
                Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                Sql &= "   AND FORMA_PAGO = 2 " & vbCrLf
                Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                Sql &= "   AND AHORRO_EXTRA <= TOTAL_FACTURA " & vbCrLf
                Sql &= " ORDER BY ORIGEN, CENTRO_COSTO, FORMA_PAGO, NUMERO_FACTURA"
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    'While True
                    '    Partida = InputBox("Ingrese un número de partida que esté reservado para este movimiento." & vbCrLf & _
                    '                       "SI NO HAY PARTIDA RESERVADA haga click en aceptar y se generará una partida nueva." & vbCrLf & _
                    '                       Partida, "VENTAS AL CREDITO", "0")
                    '    If IsNumeric(Partida) Then
                    '        Exit While
                    '    Else
                    '        Partida = "El valor debe ser un número de partida válido"
                    '    End If
                    'End While
                    NumPartida = Val(Me.txtPda.Text)
                    If NumPartida > 0 Then
                        NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & NumPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPAÑIA = " & Compañia)
                        If NumTran = 0 Then
                            MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                            Return
                        Else
                            If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                                MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return
                            Else
                                If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran) > 0 Then
                                    If MsgBox("La partida No." & NumPartida & " tiene detalle, si continúa el detalle se eliminará." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                        jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                                    Else
                                        MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                        Return
                                    End If
                                End If
                            End If
                        End If
                        Partida = "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text
                        'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Partida & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                    Else
                        NumTran = Me.GeneraCorrelativo(Compañia, "TRA", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                        NumPartida = Me.GeneraCorrelativo(Compañia, "PAR", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                        Mantenimiento_TransaccionE(Compañia, NumTran, LibroC, 1, "0", 2, NumPartida, Me.dpFechaContable.Value, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, 0, 0, "I")
                    End If
                    If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                        primerDoc = Table.Rows(0).Item("NUMERO_FACTURA")
                    Else
                        primerDocCCF = Table.Rows(0).Item("NUMERO_FACTURA")
                    End If
                    While Linea <= Table.Rows.Count - 1
                        Origen = Table.Rows(Linea).Item(3)
                        CC = Table.Rows(Linea).Item(4)
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND CARGO = 1 AND COMPAÑIA = " & Compañia
                        CtaCargo = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaCargo = 0 Then CtaCargo = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR > 13 AND COMPAÑIA = " & Compañia
                        CtaAbono = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbono = 0 Then CtaAbono = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR = 13 AND COMPAÑIA = " & Compañia
                        CtaAbonoIVA = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbonoIVA = 0 Then CtaAbonoIVA = 1
                        While CInt(Table.Rows(Linea).Item(3)) = Origen
                            If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                If primerDoc > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDoc < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            Else
                                If primerDocCCF > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDocCCF < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            End If
                            If Table.Rows(Linea).Item("AEXTRA") > 0 Then
                                CtaContable = jClass.obtenerEscalar("SELECT CUENTA_CONTABLE_AHORROS_EXTORD FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & CInt(Table.Rows(Linea).Item(3)))
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CInt(Table.Rows(Linea).Item(0)), CtaContable, "Abono a " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item(6)), "E")
                                If Table.Rows(Linea).Item("TOTAL") - Table.Rows(Linea).Item("AEXTRA") > 0 Then
                                    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, IIf(CInt(Table.Rows(Linea).Item(0)) = 0, CInt(Table.Rows(Linea).Item(1)), CInt(Table.Rows(Linea).Item(0))), CtaCargo, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item(2)) - CDbl(Me.Table.Rows(Linea).Item(6)), "E")
                                End If
                            Else
                                If CInt(Table.Rows(Linea).Item(0)) = 0 Then
                                    CtaContable = CInt(jClass.obtenerEscalar("SELECT [CUENTA_CONTABLE] FROM [dbo].[CONTABILIDAD_CATALOGO_CLIENTES_CUENTAS_CONTABLES] WHERE COMPAÑIA = " & Compañia & " AND [CLIENTE] = " & CInt(Table.Rows(Linea).Item(1)) & " AND BODEGA = " & Me.cmbBodega.SelectedValue))
                                    If CtaContable > 0 Then
                                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaContable, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item(2)), "E")
                                    Else
                                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CInt(Table.Rows(Linea).Item(1)), CtaCargo, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item(2)), "E")
                                    End If
                                Else
                                    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CInt(Table.Rows(Linea).Item(0)), CtaCargo, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item(2)), "E")
                                End If
                            End If
                            If Table.Rows(Linea).Item("RETENCION") > 0 Then
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaCESC, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "A", CDbl(Me.Table.Rows(Linea).Item("RETENCION")), "E")
                            End If
                            'If Me.rbCCF.Checked Then
                            If Me.Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                TotalFact += CDbl(Me.Table.Rows(Linea).Item("SUB_TOTAL"))
                            Else
                                SubTotal += CDbl(Me.Table.Rows(Linea).Item(8))
                                TotalIVA += CDbl(Me.Table.Rows(Linea).Item(9))
                            End If
                            Linea += 1
                            If Linea > Table.Rows.Count - 1 Then
                                Exit While
                            End If
                        End While
                    End While
                    Sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET CONTABILIZADO = 1, NUMERO_PARTIDA = " & NumPartida
                    Sql &= " WHERE TOTAL_FACTURA >= 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                    Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                    'Sql &= "' AND TIPO_DOCUMENTO = " & IIf(Me.rbFact.Checked, "1", "2") & vbCrLf
                    Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                    Sql &= "   AND FORMA_PAGO = 2 " & vbCrLf
                    Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                    Sql &= "   AND AHORRO_EXTRA < TOTAL_FACTURA " & vbCrLf
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                    'If NumTran > 0 Then
                    '    If Me.rbFact.Checked Then
                    '        SubTotal = Math.Round(TotalFact / (1 + (Me.PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
                    '        TotalIVA = Math.Round(TotalFact - SubTotal, 2, MidpointRounding.AwayFromZero)
                    '    End If
                    '    'IVA
                    '    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "Facturación al crédito del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & IIf(Me.rbFact.Checked, " Facturas", " CCF") & " del número " & primerDoc & " al número " & ultDoc, "A", TotalIVA, "E")
                    '    'Venta
                    '    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbono, "Facturación al crédito del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & IIf(Me.rbFact.Checked, " Facturas", " CCF") & " del número " & primerDoc & " al número " & ultDoc, "A", SubTotal, "E")
                    '    'Generar Resumen
                    '    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CC, 0, "Facturación al crédito del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", 0, "A")
                    '    CargaPartida_Detalle(Compañia, LibroC, NumTran, 6)
                    'End If
                End If
                If NumPartida > 0 Then
                    Me.txtPda.Text = NumPartida.ToString()
                    Me.lblTransac.Text = NumTran.ToString()
                    Me.lblTransac2.Text = NumTran.ToString()
                End If
                Linea = 0
                'NumTran = 0
                'NumPartida = 0
                'TotalFact = 0
                'SubTotal = 0
                'TotalIVA = 0
                'primerDoc = 0
                'ultDoc = 0
                'Partida = String.Empty
                'Contado
                Sql = "SELECT CODIGO_EMPLEADO, CLIENTE, TOTAL_FACTURA AS TOTAL, ORIGEN, CENTRO_COSTO, FORMA_PAGO, BANCO_REMESA, CUENTA_BANCO_REMESA, AHORRO_EXTRA AS AEXTRA, NUMERO_FACTURA, SUB_TOTAL, TOTAL_IVA, TIPO_DOCUMENTO, NUMERO_REMESA, VALOR_REMESA, RETENCION " & vbCrLf
                Sql &= "  FROM dbo.FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= " WHERE TOTAL_FACTURA >= 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                'Sql &= "   AND TIPO_DOCUMENTO = " & IIf(Me.rbFact.Checked, "1", "2") & vbCrLf
                Sql &= "   AND FORMA_PAGO = 1 AND (BANCO_REMESA > 0 OR AHORRO_EXTRA > 0) " & vbCrLf
                Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                Sql &= "   AND AHORRO_EXTRA <= TOTAL_FACTURA " & vbCrLf
                Sql &= " ORDER BY FORMA_PAGO, NUMERO_FACTURA"
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    'While True
                    '    Partida = InputBox("Ingrese un número de partida que esté reservado para este movimiento." & vbCrLf & _
                    '                        "SI NO HAY PARTIDA RESERVADA haga click en aceptar y se generará una partida nueva." & vbCrLf & _
                    '                        Partida, "VENTAS AL CONTADO", "0")
                    '    If IsNumeric(Partida) Then
                    '        Exit While
                    '    Else
                    '        Partida = "El valor debe ser un número de partida válido"
                    '    End If
                    'End While
                    If NumTran = 0 Then
                        NumPartida = Val(Me.txtPda.Text)
                        If NumPartida > 0 Then
                            NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & NumPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPAÑIA = " & Compañia)
                            If NumTran = 0 Then
                                MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return
                            Else
                                If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                                    MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                    Return
                                Else
                                    If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran) > 0 Then
                                        If MsgBox("La partida No." & NumPartida & " tiene detalle, si continúa el detalle se eliminará." & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                            jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                                        Else
                                            MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                            Return
                                        End If
                                    End If
                                End If
                            End If
                            Partida = "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text
                            'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Partida & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                        Else
                            NumTran = Me.GeneraCorrelativo(Compañia, "TRA", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                            NumPartida = Me.GeneraCorrelativo(Compañia, "PAR", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                            Mantenimiento_TransaccionE(Compañia, NumTran, LibroC, 7, "0", 1, NumPartida, Me.dpFechaContable.Value, "Facturación Del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, 0, 0, "I")
                        End If
                    End If
                    If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                        If primerDoc = 0 Then
                            primerDoc = Table.Rows(0).Item("NUMERO_FACTURA")
                        End If
                    Else
                        If primerDocCCF = 0 Then
                            primerDocCCF = Table.Rows(0).Item("NUMERO_FACTURA")
                        End If
                    End If
                    While Linea <= Table.Rows.Count - 1
                        Origen = Table.Rows(Linea).Item(3)
                        CC = Table.Rows(Linea).Item(4)
                        Sql = "SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND CUENTA_BANCARIA = '" & Table.Rows(Linea).Item("CUENTA_BANCO_REMESA") & "' AND BANCO = " & Table.Rows(Linea).Item("BANCO_REMESA")
                        CtaCargo = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaCargo = 0 Then CtaCargo = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR > 13 AND COMPAÑIA = " & Compañia
                        CtaAbono = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbono = 0 Then CtaAbono = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR = 13 AND COMPAÑIA = " & Compañia
                        CtaAbonoIVA = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbonoIVA = 0 Then CtaAbonoIVA = 1
                        While CInt(Table.Rows(Linea).Item(3)) = Origen
                            If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                If primerDoc > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDoc < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            Else
                                If primerDocCCF > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDocCCF < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            End If
                            If Table.Rows(Linea).Item("AEXTRA") > 0 Then
                                CtaContable = jClass.obtenerEscalar("SELECT CUENTA_CONTABLE_AHORROS_EXTORD FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & CInt(Table.Rows(Linea).Item(3)))
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CInt(Table.Rows(Linea).Item(0)), CtaContable, "Abono a " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(9).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "C", CDbl(Me.Table.Rows(Linea).Item("AEXTRA")), "E")
                            Else
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, IIf(CInt(Table.Rows(Linea).Item(0)) = 0, CInt(Table.Rows(Linea).Item(0)), CInt(Table.Rows(Linea).Item(1))), CtaCargo, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(9).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & IIf(Me.Table.Rows(Linea).Item("NUMERO_REMESA").ToString().Length > 0, " Ref.#" & Me.Table.Rows(Linea).Item("NUMERO_REMESA"), ""), "C", IIf(CDbl(Me.Table.Rows(Linea).Item("VALOR_REMESA")) > CDbl(Me.Table.Rows(Linea).Item("TOTAL")), CDbl(Me.Table.Rows(Linea).Item("VALOR_REMESA")), CDbl(Me.Table.Rows(Linea).Item("TOTAL"))), "E")
                                If CDbl(Me.Table.Rows(Linea).Item("VALOR_REMESA")) > CDbl(Me.Table.Rows(Linea).Item("TOTAL")) Then
                                    CtaCargo = CInt(jClass.obtenerEscalar("SELECT VALOR FROM dbo.CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 43"))
                                    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CInt(Table.Rows(Linea).Item(1)), CtaCargo, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(9).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & IIf(Me.Table.Rows(Linea).Item("NUMERO_REMESA").ToString().Length > 0, " Ref.#" & Me.Table.Rows(Linea).Item("NUMERO_REMESA"), "") & " (Remanente por liquidar)", "A", CDbl(Me.Table.Rows(Linea).Item("VALOR_REMESA")) - CDbl(Me.Table.Rows(Linea).Item("TOTAL")), "E")
                                End If
                            End If
                            If Table.Rows(Linea).Item("RETENCION") > 0 Then
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaCESC, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "A", CDbl(Me.Table.Rows(Linea).Item("RETENCION")), "E")
                            End If
                            If Me.Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                TotalFact += CDbl(Me.Table.Rows(Linea).Item("SUB_TOTAL"))
                            Else
                                SubTotal += CDbl(Me.Table.Rows(Linea).Item(10))
                                TotalIVA += CDbl(Me.Table.Rows(Linea).Item(11))
                            End If
                            Linea += 1
                            If Linea > Table.Rows.Count - 1 Then
                                Exit While
                            End If
                        End While
                    End While
                    Sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET CONTABILIZADO = 1, NUMERO_PARTIDA = " & NumPartida
                    Sql &= "  FROM dbo.FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                    Sql &= " WHERE TOTAL_FACTURA >= 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                    Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                    Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND FORMA_PAGO = 1 AND (BANCO_REMESA > 0 OR AHORRO_EXTRA > 0) " & vbCrLf
                    Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                    Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                    Sql &= "   AND AHORRO_EXTRA <= TOTAL_FACTURA " & vbCrLf
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                End If
                DevolResult = Devoluciones(NumTran)
                If NumTran > 0 Then
                    If TotalFact > 0 Then
                        SubTotalFact = Math.Round(TotalFact / (1 + (PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
                        TotalIVAFact = Math.Round(TotalFact - SubTotalFact, 2, MidpointRounding.AwayFromZero)
                        'IVA Facturas
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & " Facturas del número " & IIf(primerDoc = 0, ultDoc, primerDoc) & " al número " & ultDoc, "A", TotalIVAFact, "E")
                        'Venta Facturas
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbono, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & " Facturas del número " & IIf(primerDoc = 0, ultDoc, primerDoc) & " al número " & ultDoc, "A", SubTotalFact, "E")
                    End If
                    If SubTotal > 0 Then
                        'IVA CCF
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & " CCF del número " & IIf(primerDocCCF = 0, ultDocCCF, primerDocCCF) & " al número " & ultDocCCF, "A", TotalIVA, "E")
                        'Venta CCF
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbono, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text & " CCF del número " & IIf(primerDocCCF = 0, ultDocCCF, primerDocCCF) & " al número " & ultDocCCF, "A", SubTotal, "E")
                    End If
                    'Generar Resumen
                    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CC, 0, "Facturación del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", 0, "A")
                    CargaPartida_Detalle(Compañia, LibroC, NumTran, 6)
                    Me.txtPda.Text = NumPartida.ToString()
                    Me.lblTransac.Text = NumTran.ToString()
                    Me.lblTransac2.Text = NumTran.ToString()
                End If
                If Val(Me.lblTransac.Text) > 0 Then
                    MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Partida Facturación")
                Else
                    MsgBox("No se generó Partida para la fecha seleccionada." & vbCrLf & vbCrLf & "No hay datos de facturacion o partida ya fue generada.", MsgBoxStyle.Information, "Partida Facturación")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Partida Facturas")
        End Try
    End Sub

    Private Function Devoluciones(ByVal Transaccion As Integer) As Boolean
        Dim sqlCmd As New SqlCommand
        Dim CtaContable As Integer = 0
        Dim NumPartida As Integer = 0
        Dim NumTran As Integer = Transaccion
        Dim primerDoc, ultDoc, primerDocCCF, ultDocCCF As Integer
        Dim Linea, CtaCargo, CtaAbono, CtaAbonoIVA, CtaCosto, CtaInv, CtaCESC As Integer
        Dim TotalFact, TotalIVAFact, SubTotalFact, TotalIVA, SubTotal, CostoDev As Double
        Dim Partida As String = String.Empty
        Dim _error_ As Boolean = False
        Me.dgvPartidas.DataSource = Nothing
        Try
            If ValidaCierreContable(Compañia, LibroC, Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), "E") Then
                CtaCESC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 56"))
                Sql = "SELECT CODIGO_EMPLEADO, CLIENTE, TOTAL_FACTURA * -1 AS TOTAL, ORIGEN, CENTRO_COSTO, FORMA_PAGO, AHORRO_EXTRA AS AEXTRA, NUMERO_FACTURA, SUB_TOTAL * -1 AS SUB_TOTAL, TOTAL_IVA * -1 AS TOTAL_IVA, TIPO_DOCUMENTO, CONCEPTO, RETENCION * -1 AS RETENCION" & vbCrLf
                Sql &= "  FROM dbo.FACTURACION_GENERADA_ENCABEZADO " & vbCrLf
                Sql &= " WHERE TOTAL_FACTURA < 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                Sql &= " ORDER BY ORIGEN, CENTRO_COSTO, FORMA_PAGO"
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    If NumTran = 0 Then
                        NumPartida = Val(Me.txtPda.Text)
                        If NumPartida > 0 Then
                            NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & NumPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaContable.Value.Year & " AND COMPAÑIA = " & Compañia)
                            If NumTran = 0 Then
                                MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                Return False
                            Else
                                If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                                    MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO NO VALIDO")
                                    Return False
                                Else
                                    If jClass.obtenerEscalar("SELECT COUNT(CUENTA_CONTABLE) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran) > 0 Then
                                        If MsgBox("La partida No." & NumPartida & " tiene detalle, si continúa el detalle se eliminará." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                            jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                                        Else
                                            MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                            Return False
                                        End If
                                    End If
                                End If
                            End If
                            Partida = "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text
                            'jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = '" & Partida & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & NumTran)
                        Else
                            NumTran = Me.GeneraCorrelativo(Compañia, "TRA", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                            NumPartida = Me.GeneraCorrelativo(Compañia, "PAR", Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month)
                            Mantenimiento_TransaccionE(Compañia, NumTran, LibroC, 31, "0", 2, NumPartida, Me.dpFechaContable.Value, "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, 0, 0, "I")
                        End If
                    End If
                    Sql = "SELECT CUENTA_CONTABLE_COSTO_VENTAS FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodega.SelectedValue
                    CtaCosto = CInt(jClass.obtenerEscalar(Sql))
                    Sql = "SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodega.SelectedValue
                    CtaInv = CInt(jClass.obtenerEscalar(Sql))
                    If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                        primerDoc = Table.Rows(0).Item("NUMERO_FACTURA")
                    Else
                        primerDocCCF = Table.Rows(0).Item("NUMERO_FACTURA")
                    End If
                    While Linea <= Table.Rows.Count - 1
                        Origen = Table.Rows(Linea).Item(3)
                        CC = Table.Rows(Linea).Item(4)
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND CARGO = 1 AND COMPAÑIA = " & Compañia
                        CtaCargo = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaCargo = 0 Then CtaCargo = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR > 13 AND COMPAÑIA = " & Compañia
                        CtaAbono = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbono = 0 Then CtaAbono = 1
                        Sql = "SELECT CUENTA FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS" & vbCrLf
                        Sql &= "WHERE ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = " & IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "1", "2") & " AND CENTRO_COSTO = " & CC & " AND ABONO = 1 AND VALOR = 13 AND COMPAÑIA = " & Compañia
                        CtaAbonoIVA = CInt(jClass.obtenerEscalar(Sql))
                        'If CtaAbonoIVA = 0 Then CtaAbonoIVA = 1
                        While CInt(Table.Rows(Linea).Item(3)) = Origen
                            If Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                If primerDoc > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDoc < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDoc = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            Else
                                If primerDocCCF > Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    primerDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                                If ultDocCCF < Table.Rows(Linea).Item("NUMERO_FACTURA") Then
                                    ultDocCCF = Table.Rows(Linea).Item("NUMERO_FACTURA")
                                End If
                            End If
                            Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, IIf(CInt(Table.Rows(Linea).Item(0)) = 0, CInt(Table.Rows(Linea).Item(1)), CInt(Table.Rows(Linea).Item(0))), CtaCargo, "Factura No." & Table.Rows(Linea).Item("NUMERO_FACTURA").ToString() & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " por " & Table.Rows(Linea).Item("CONCEPTO"), "A", CDbl(Me.Table.Rows(Linea).Item(2)), "E")
                            If Table.Rows(Linea).Item("RETENCION") > 0 Then
                                Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaCESC, IIf(Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1, "Factura", "CCF") & " No. " & Table.Rows(Linea).Item(7).ToString & " del " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy"), "A", CDbl(Me.Table.Rows(Linea).Item("RETENCION")), "E")
                            End If
                            Sql = "SELECT ROUND(ISNULL(SUM(COSTO_TOTAL),0),2) AS COSTO FROM FACTURACION_GENERADA_DETALLE WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & Me.cmbBodega.SelectedValue & " AND NUMERO_FACTURA = " & Table.Rows(Linea).Item("NUMERO_FACTURA").ToString()
                            CostoDev = CDbl(jClass.obtenerEscalar(Sql))
                            Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaInv, Table.Rows(Linea).Item("CONCEPTO") & " con Factura No." & Table.Rows(Linea).Item("NUMERO_FACTURA").ToString(), "C", CostoDev, "E")
                            Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaCosto, Table.Rows(Linea).Item("CONCEPTO") & " con Factura No." & Table.Rows(Linea).Item("NUMERO_FACTURA").ToString(), "A", CostoDev, "E")
                            If Me.Table.Rows(Linea).Item("TIPO_DOCUMENTO") = 1 Then
                                TotalFact += CDbl(Me.Table.Rows(Linea).Item("SUB_TOTAL"))
                            Else
                                SubTotal += CDbl(Me.Table.Rows(Linea).Item(8))
                                TotalIVA += CDbl(Me.Table.Rows(Linea).Item(9))
                            End If
                            Linea += 1
                            If Linea > Table.Rows.Count - 1 Then
                                Exit While
                            End If
                        End While
                    End While
                    Sql = "UPDATE dbo.FACTURACION_GENERADA_ENCABEZADO SET CONTABILIZADO = 1, NUMERO_PARTIDA = " & NumPartida
                    Sql &= " WHERE TOTAL_FACTURA < 0 AND ANULADA = 0 AND FACTURA_IMPRESA = 1 " & vbCrLf
                    Sql &= "   AND FECHA_FACTURA = '" & Me.dpFechaContable.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
                    Sql &= "   AND COMPAÑIA = " & Compañia & vbCrLf
                    Sql &= "   AND BODEGA= " & Me.cmbBodega.SelectedValue & vbCrLf
                    Sql &= "   AND CONTABILIZADO = 0 " & vbCrLf
                    sqlCmd.CommandText = Sql
                    jClass.ejecutarComandoSql(sqlCmd)
                End If
                Me.txtPda.Text = NumPartida.ToString()
                Me.lblTransac.Text = NumTran.ToString()
                Me.lblTransac2.Text = NumTran.ToString()
                If NumTran > 0 Then
                    If TotalFact > 0 Then
                        SubTotalFact = Math.Round(TotalFact / (1 + (Me.PorcIVA / 100)), 2, MidpointRounding.AwayFromZero)
                        TotalIVAFact = Math.Round(TotalFact - SubTotalFact, 2, MidpointRounding.AwayFromZero)
                        'IVA Facturas
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", TotalIVAFact, "E")
                        'Venta Facturas
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbono, "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", SubTotalFact, "E")
                    End If
                    If SubTotal > 0 Then
                        'IVA CCF
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbonoIVA, "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", TotalIVA, "E")
                        'Venta CCF
                        Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, 0, CtaAbono, "FDevolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "C", SubTotal, "E")
                    End If
                    'Generar Resumen
                    Mantenimiento_TransaccionL(Compañia, LibroC, NumTran, Linea, CC, 0, "Devolución de Mercaderías del Día " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & " de " & Me.cmbBodega.Text, "X", 0, "A")
                    CargaPartida_Detalle(Compañia, LibroC, NumTran, 6)
                    Me.txtPda.Text = NumPartida.ToString()
                    Me.lblTransac.Text = NumTran.ToString()
                    Me.lblTransac2.Text = NumTran.ToString()
                End If
            End If
        Catch ex As Exception
            _error_ = True
        End Try
        Return Not _error_
    End Function

    Private Sub Mantenimiento_TransaccionL(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LINEA          = " & Linea & vbCrLf
            Sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            Sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            Sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_TransaccionE(ByVal Compañia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            Sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            Sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            Sql &= ",@PARTIDA        = " & Partida & vbCrLf
            Sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@ANULADA        = " & Anulada & vbCrLf
            Sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            'Select Case IUD
            '    Case "I"
            '        MsgBox("¡Transacción Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            '    Case "U"
            '        MsgBox("¡Transacción Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            '    Case "D"
            '        MsgBox("¡Transacción Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            Sql &= ",@PROCESADO      = 0" & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO = " & Año & vbCrLf
            Sql &= ",@MES = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            Sql &= ",@PROCESADO = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") = True Then
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@ULTIMO         = 0"
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

    Private Sub CargaPartida_Detalle(ByVal Compañia, ByVal Libro, ByVal Transaccion, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@BANDERA        = " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPartidas.DataSource = Table
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
        Me.txtPda.Text = "0"
        Me.dgvPartidas.DataSource = Nothing
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Val(Me.lblTransac.Text) > 0 Then
            Dim rpts As New frmReportes_Ver
            rpts.CargaPartida(Compañia, LibroC, Me.lblTransac.Text, Me.lblTransac2.Text, Year(Me.dpFechaContable.Value), Month(Me.dpFechaContable.Value), 1)
            rpts.ShowDialog()
        Else
            MsgBox("Número de Partida inválido", MsgBoxStyle.Critical, "Impresión")
        End If
    End Sub

    Private Sub Facturacion_Partida_Contable_Consumidor_Final_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class