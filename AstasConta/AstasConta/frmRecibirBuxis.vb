Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRecibirBuxis

    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Indemnizados As Boolean
    Dim Sql As String
    Dim Periodo As String = "QQ"
    Dim Table As DataTable
    'Dim Table, TableAhorros As DataTable
    'Dim TableAbonos As DataTable
    Dim pdaDeudas, pdaAhorro, pdaInt As Integer

    Private Sub frmRecibirBuxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.Label2.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.Label2.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText1(ByVal texto As String, ByVal tipo As Integer)
    Sub SetText1(ByVal texto As String, ByVal tipo As Integer)
        If Me.lblPdas.InvokeRequired Then
            Dim setea As New CallBackSetText1(AddressOf SetText1)
            Me.Invoke(setea, texto, tipo)
        Else
            Select Case tipo
                Case 1
                    Me.txtPdaDeuda.Text = texto
                Case 2
                    Me.txtPdaAh.Text = texto
                Case 3
                    Me.txtPdaInt.Text = texto
            End Select
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
        Dim FechaAhorros As Date = Me.dpFechaPago.Value
        If Not (Me.dpFechaPago.Value.Day = 12 Or Me.dpFechaPago.Value.Day = 15 Or Me.dpFechaPago.Value.Day = 30 Or (Me.dpFechaPago.Value.Month = 2 And Me.dpFechaPago.Value.Day = 28) Or (Me.dpFechaPago.Value.Month = 2 And Me.dpFechaPago.Value.Day = 29)) Then
            Indemnizados = True
        Else
            Indemnizados = False
            If (Me.dpFechaPago.Value.Month = 1 Or Me.dpFechaPago.Value.Month = 3 Or Me.dpFechaPago.Value.Month = 5 Or Me.dpFechaPago.Value.Month = 7 Or Me.dpFechaPago.Value.Month = 8 Or Me.dpFechaPago.Value.Month = 10 Or Me.dpFechaPago.Value.Month = 12) And Me.dpFechaPago.Value.Day = 30 Then
                FechaAhorros = Me.dpFechaPago.Value.AddDays(1)
            End If
        End If
        Sql = "SELECT COUNT(COMPAÑIA) FROM COOPERATIVA_SOLICITUDES_CON_PARTIDAS WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & Format(Me.dpFechaPago.Value, "yyyyMMdd") & IIf(Me.rbQna.Checked, "01", "02")
        If jClass.obtenerEscalar(Sql) = 0 Then
            MsgBox("No se puede proceder." & vbCrLf & "Se debe ejecutar el proceso de Recepción descuentos desde el" & vbCrLf & "módulo de Cooperativa antes de generar la Partida Contable", MsgBoxStyle.Information, "Proceso cancelado")
            Return
        End If
        'Sql = "SELECT COUNT(COMPAÑIA) FROM COOPERATIVA_SOLICITUDES_CON_PARTIDAS WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & Format(Me.dpFechaPago.Value, "yyyyMMdd") & IIf(Me.rbQna.Checked, "01", "02") & " AND USUARIO_EDICION = 'contapda1'"
        'If jClass.obtenerEscalar(Sql) > 0 Then
        '    MsgBox("No se puede proceder." & vbCrLf & "El proceso ya fue ejecutado para ese periodo de pago.", MsgBoxStyle.Information, "Proceso cancelado")
        '    Return
        'End If
        Me.lblPdas.Text = "Partidas Generadas:"
        Me.txtTransaccionInicial.Clear()
        Me.txtTransaccionFinal.Clear()
        Me.btnProcesar.Enabled = False
        Me.Label2.Visible = True
        Me.pbAplicar.Visible = True
        Timer1.Enabled = True
        Me.pbAplicar.Value = 0
        Me.bw1.RunWorkerAsync(Me.dpFechaPago.Value)
    End Sub

    Private Sub PartidasContables(ByVal FechaPago As Date)
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim poneTextoPdas As New CallBackSetText1(AddressOf SetText1)
        Dim poneTextoTransI As New CallBackSetText2(AddressOf SetText2)
        Dim poneTextoTransF As New CallBackSetText3(AddressOf SetText3)
        Dim CtaContable, Libro, Transaccion, CtaAbono, Partida As Integer
        Dim TotalAbonos, TotalInteres, TotalSegDeuda As Double
        Dim Concepto As String = IIf(Indemnizados, "INDEMNIZADOS", "PLANILLA ") & IIf(FechaPago.Day = 12, IIf(FechaPago.Month = 6, "DE BONIFICACION/", "DE AGUINALDO/") & FechaPago.Year.ToString(), " DEL " & FechaPago.ToShortDateString)
        Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        If Not jClass.ValidaCierreContable(Compañia, Libro, FechaPago.Year, FechaPago.Month, "E") Then
            Return
        End If
        CtaContable = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 20")
        If Indemnizados Then
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS]"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @FECHA_PERIODO = '" & FechaPago.ToShortDateString & "'"
            Sql &= ", @PERIODO_PAGO = '" & Periodo & "'"
            Sql &= ", @BANDERA = 18"
        Else
            Sql = "SELECT ISNULL(SUM(IMPTOT_HD), 0) AS INTERESES FROM (SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud] as Numero,VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, DA.APLICADO, VS.Deduccion, DA.IMPUNI_HD" & vbCrLf
            Sql &= "FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, COOPERATIVA_CATALOGO_SOCIOS s " & vbCrLf
            Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND S.COMPAÑIA = " & Compañia & " AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis] AND DA.FEC_ACU_HD = '" & Format(FechaPago, "dd/MM/yyyy") & "' AND DA.COD_MV IN (SELECT CODIGO_DEDUCCION_INTERESES FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE CODIGO_DEDUCCION_INTERESES > 0) AND DA.APLICADO = 1" & vbCrLf ' AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'" & vbCrLf
            Sql &= "AND S.ORIGEN NOT IN (5,6)" & vbCrLf
            Sql &= " UNION" & vbCrLf
            Sql &= "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud] as Numero,VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, DA.APLICADO, VS.Deduccion, DA.IMPUNI_HD" & vbCrLf
            Sql &= "FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, COOPERATIVA_CATALOGO_SOCIOS s " & vbCrLf
            Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND S.COMPAÑIA = " & Compañia & " AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis] AND DA.FEC_ACU_HD = '" & Format(FechaPago, "dd/MM/yyyy") & "' AND DA.COD_MV IN (SELECT CODIGO_DEDUCCION_INTERESES FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE CODIGO_DEDUCCION_INTERESES > 0) AND DA.APLICADO = 1" & vbCrLf ' AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'" & vbCrLf
            Sql &= "AND S.ORIGEN IN (5,6) AND VS.Deduccion <> 240) A"
        End If
        TotalInteres = jClass.obtenerEscalar(Sql)

        If Indemnizados Then
            Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS]"
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ", @FECHA_PERIODO = '" & FechaPago.ToShortDateString & "'"
            Sql &= ", @PERIODO_PAGO = '" & Periodo & "'"
            Sql &= ", @BANDERA = 19"
        Else
            Sql = "SELECT ISNULL(SUM(IMPTOT_HD), 0) AS INTERESES FROM (SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud] as Numero,VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, DA.APLICADO, VS.Deduccion, DA.IMPUNI_HD" & vbCrLf
            Sql &= "FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, COOPERATIVA_CATALOGO_SOCIOS s " & vbCrLf
            Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND S.COMPAÑIA = " & Compañia & " AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis] AND DA.FEC_ACU_HD = '" & Format(FechaPago, "dd/MM/yyyy") & "' AND DA.COD_MV IN (SELECT CODIGO_DEDUCCION_SEGURO_DEUDA FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE CODIGO_DEDUCCION_SEGURO_DEUDA > 0) AND DA.APLICADO = 1" & vbCrLf ' AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'" & vbCrLf
            Sql &= "AND S.ORIGEN NOT IN (5,6)" & vbCrLf
            Sql &= " UNION" & vbCrLf
            Sql &= "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud] as Numero,VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, DA.APLICADO, VS.Deduccion, DA.IMPUNI_HD" & vbCrLf
            Sql &= "FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, COOPERATIVA_CATALOGO_SOCIOS s " & vbCrLf
            Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND S.COMPAÑIA = " & Compañia & " AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis] AND DA.FEC_ACU_HD = '" & Format(FechaPago, "dd/MM/yyyy") & "' AND DA.COD_MV IN (SELECT CODIGO_DEDUCCION_SEGURO_DEUDA FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE CODIGO_DEDUCCION_SEGURO_DEUDA > 0) AND DA.APLICADO = 1" & vbCrLf ' AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'" & vbCrLf
            Sql &= "AND S.ORIGEN IN (5,6) AND VS.Deduccion <> 240) A"
        End If
        TotalSegDeuda = jClass.obtenerEscalar(Sql)

        'Partida por Cuotas de Capital de los diferentes rubros
        poneTexto("Procesando... DESCUENTOS POR DEUDAS")
        Partida = Val(Me.txtPdaDeuda.Text)
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
            jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = 'RETENCIONES POR PRESTAMOS A EMPLEADOS, " & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
        Else
            Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & FechaPago.Year & ", @MES = " & FechaPago.Month & ", @ULTIMO = 0")
            jClass.EncabezadoPartida(Transaccion, 2, 35, 0, Me.dpFechaPago.Value.Date, Libro, "RETENCIONES POR PRESTAMOS A EMPLEADOS, " & Concepto, 0, 0, "I")
            Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            poneTextoPdas(Partida.ToString(), 1)
        End If
        poneTextoTransI(Transaccion.ToString())
        poneTextoTransF(Transaccion.ToString())
        Sql = "UPDATE [dbo].[COOPERATIVA_SOLICITUDES_CON_PARTIDAS] SET TRN_CAPITAL = " & Transaccion & " WHERE COMPAÑIA = " & Compañia & " AND [SOLICITUD] = '" & Format(Me.dpFechaPago.Value, "yyyyMMdd") & "01'"
        jClass.ejecutarComandoSql(New SqlCommand(Sql))
        TotalAbonos = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_GENERAR_PARTIDAS_DESCUENTOS @COMPAÑIA = " & Compañia & ",@FECHA_PAGO = '" & Format(FechaPago, "dd/MM/yyyy") & "', @TRANSACCION = " & Transaccion & ", @PARTIDA = " & Partida & ", @USUARIO = '" & Usuario & "', @BANDERA = 1, @CONCEPTO = '" & Concepto & "'")
        jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaPago.Value.Date, Libro, "RETENCIONES POR PRESTAMOS A EMPLEADOS, " & Concepto, CtaContable, "C", TotalAbonos, 0, "E")
        jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaPago.Value.Date, Libro, "RETENCIONES POR PRESTAMOS A EMPLEADOS, " & Concepto, 0, "X", 0, 0, "A")

        If FechaPago.Day <> 12 Then
            'Partida por Ahorros descontados
            TotalAbonos = 0
            poneTexto("Procesando... DESCUENTOS POR AHORROS")
            Partida = Val(Me.txtPdaAh.Text)
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
                            If MsgBox("La partida No." & Partida & " tiene detalle, si continúa el detalle se eliminará." & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "CONFIRMACION ELIMINACION DETALLE") = MsgBoxResult.Yes Then
                                jClass.obtenerEscalar("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                            Else
                                MsgBox("Proceso Cancelado", MsgBoxStyle.Information, "GENERAR PARTIDA")
                                Return
                            End If
                        End If
                    End If
                End If
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = 'CUOTAS DE AHORRO DESCONTADOS, " & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            Else
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & FechaPago.Year & ", @MES = " & FechaPago.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 2, 35, 0, FechaPago.Date, Libro, "CUOTAS DE AHORRO DESCONTADOS, " & Concepto, 0, 0, "I")
                Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                poneTextoPdas(Partida.ToString(), 2)
            End If
            poneTextoTransF(Transaccion.ToString())
            Sql = "UPDATE [dbo].[COOPERATIVA_SOLICITUDES_CON_PARTIDAS] SET TRN_AHORROS = " & Transaccion & " WHERE COMPAÑIA = " & Compañia & " AND [SOLICITUD] = '" & Format(Me.dpFechaPago.Value, "yyyyMMdd") & "01'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
            If Me.txtTransaccionInicial.Text.Length = 0 Then
                poneTextoTransI(Transaccion.ToString())
            End If
            TotalAbonos = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_GENERAR_PARTIDAS_DESCUENTOS @COMPAÑIA = " & Compañia & ",@FECHA_PAGO = '" & Format(FechaPago, "dd/MM/yyyy") & "', @TRANSACCION = " & Transaccion & ", @PARTIDA = " & Partida & ", @USUARIO = '" & Usuario & "', @BANDERA = 2, @CONCEPTO = '" & Concepto & "'")
            jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaPago.Value.Date, Libro, "CUOTAS DE AHORRO DESCONTADOS, " & Concepto, CtaContable, "C", TotalAbonos, 0, "E")
            jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaPago.Value.Date, Libro, "CUOTAS DE AHORRO DESCONTADOS, " & Concepto, CtaContable, "X", 0, 0, "A")
        End If
        'Partida por Interes y Seguro de Deuda
        If TotalInteres > 0 Or TotalSegDeuda > 0 Then
            Partida = Val(Me.txtPdaInt.Text)
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
                jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO SET CONCEPTO = 'CUOTAS DE AHORRO DESCONTADOS, " & Concepto & "' WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
            Else
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & Now.Year & ", @MES = " & Now.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 2, 35, 0, Me.dpFechaPago.Value.Date, Libro, "INTERESES Y SEGURO DEUDA DESCONTADO, " & Concepto, 0, 0, "I")
                Partida = jClass.obtenerEscalar("SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion)
                poneTextoPdas(Partida.ToString(), 3)
            End If
            poneTextoTransF(Transaccion.ToString())
            Sql = "UPDATE [dbo].[COOPERATIVA_SOLICITUDES_CON_PARTIDAS] SET TRN_INTERESES = " & Transaccion & " WHERE COMPAÑIA = " & Compañia & " AND [SOLICITUD] = '" & Format(Me.dpFechaPago.Value, "yyyyMMdd") & "01'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
            If Me.txtTransaccionInicial.Text.Length = 0 Then
                poneTextoTransI(Transaccion.ToString())
            End If
            If TotalInteres > 0 Then
                CtaAbono = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 21")
                jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaPago.Value.Date, Libro, "INTERESES DESCONTADOS, " & IIf(Me.Indemnizados, "INDEMNIZADOS", "PLANILLA " & IIf(Me.rbQna.Checked, Me.rbQna.Text.ToUpper, Me.rbMensual.Text.ToUpper)) & " DEL " & Me.dpFechaPago.Text, CtaAbono, "A", 0, TotalInteres, "E")
            End If
            If TotalSegDeuda > 0 Then
                CtaAbono = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 22")
                jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaPago.Value.Date, Libro, "SEGURO DEUDA DESCONTADO, " & IIf(Me.Indemnizados, "INDEMNIZADOS", "PLANILLA " & IIf(Me.rbQna.Checked, Me.rbQna.Text.ToUpper, Me.rbMensual.Text.ToUpper)) & " DEL " & Me.dpFechaPago.Text, CtaAbono, "A", 0, TotalSegDeuda, "E")
            End If
            jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaPago.Value.Date, Libro, "INTERESES Y SEGURO DEUDA DESCONTADO, " & Concepto, CtaContable, "C", TotalSegDeuda + TotalInteres, 0, "E")
            jClass.DetallePartida(Transaccion, 0, 1, Me.dpFechaPago.Value.Date, Libro, "INTERESES Y SEGURO DEUDA DESCONTADO, " & Concepto, 0, "X", 0, 0, "A")
        End If
    End Sub

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        PartidasContables(CDate(e.Argument))
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
        Sql = " UPDATE [dbo].[COOPERATIVA_SOLICITUDES_CON_PARTIDAS]" & vbCrLf
        Sql &= "   SET [USUARIO_EDICION] = 'contapda1'" & vbCrLf
        Sql &= " WHERE [COMPAÑIA] = " & Compañia & vbCrLf
        Sql &= "   AND [SOLICITUD] = " & Format(Me.dpFechaPago.Value, "yyyyMMdd") & IIf(Me.rbQna.Checked, "01", "02") & vbCrLf
        Sql &= "   AND [DESCRICPCION] = 'DESCUENTOS DEL " & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "'"
        sqlCmd.CommandText = Sql
        jClass.ejecutarComandoSql(sqlCmd)
        Me.Timer1.Enabled = False
        Me.pbAplicar.Value = 100
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Recepción desde Buxis")
        Me.pbAplicar.Visible = False
        Me.Label2.Visible = False
        Me.Label2.Text = "Procesando..."
        Me.btnProcesar.Enabled = True
    End Sub

    Private Sub rbQna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna.CheckedChanged
        If Not Iniciando Then
            If rbQna.Checked Then
                Periodo = "QQ"
            End If
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMensual.CheckedChanged
        If Not Iniciando Then
            If rbMensual.Checked Then
                Periodo = "MM"
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpts As New frmReportes_Ver
        rpts.CargaPartida(Compañia, jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"), Me.txtTransaccionInicial.Text, Me.txtTransaccionFinal.Text, Me.dpFechaPago.Value.Year, Me.dpFechaPago.Value.Month, 1)
        rpts.ShowDialog()
    End Sub

    Private Sub frmRecibirBuxis_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtPdaDeuda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPdaDeuda.KeyPress, txtPdaAh.KeyPress, txtPdaInt.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.pbAplicar.Value >= 100 Then
            Me.pbAplicar.Value = 0
        End If
        Me.pbAplicar.Value += 1
    End Sub
End Class