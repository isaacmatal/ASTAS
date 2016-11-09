Public Class Cafeteria_Facturacion_Enviar_Buxis

    Dim jClass As New jarsClass
    Dim FPro As New Facturacion_Procesos
    Dim fechaIni, fechaFin As String
    Dim Plantas02 As String
    Dim TipSoliP1, TipSoliP2 As Integer

    Private Sub Cafeteria_Facturacion_Enviar_Buxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBodegas(Compañia, Me.cbCafeteria, 9)
        jClass.CargarCombo(Me.cbSeleccioneCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=2, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        jClass.CargarCombo(Me.cmbPeriodoPago, "SELECT CONVERT(VARCHAR(10),[PERIODO_FACTURACION_INICIO],103)+'*'+CONVERT(VARCHAR(10),[PERIODO_FACTURACION_FINAL],103) AS LABEL, CONVERT(VARCHAR(10),[PERIODO_PAGO],103) AS PERIODO_PAGO FROM CAFETERIA_FACTURACION_PERIODOS_DE_COBRO WHERE COMPAÑIA = " & Compañia & " ORDER BY CAFETERIA_FACTURACION_PERIODOS_DE_COBRO.PERIODO_PAGO DESC", "LABEL", "PERIODO_PAGO")
        cargarCajas()
        Iniciando = False
        If Me.cbSeleccioneCaja.Items.Count > 0 Then
            cargaReporte()
        End If
    End Sub

    Private Sub cargarCajas()
        If Not Iniciando Then
            Dim a As String = jClass.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
            If (a = Nothing) Then
                MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
            Else
                jClass.CargarCombo(Me.cbSeleccioneCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
            End If
        End If
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If Not Iniciando Then
            cargarCajas()
            'cargaReporte()
        End If
    End Sub

    Private Sub cmbPeriodoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriodoPago.SelectedIndexChanged
        If Not Iniciando Then
            cargaReporte()
        End If
    End Sub

    Private Sub cargaReporte()
        If Me.cbSeleccioneCaja.Text.Length = 0 And Not CheckBox1.Checked Then
            Me.CrystalReportViewer1.ReportSource = Nothing
            Return
        End If
        Dim rpt As New Cafeteria_Facturacion_Enviar_Buxis_rpt
        Dim Cadena As String
        Dim sqlCmd As New SqlClient.SqlCommand
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Cadena = Me.cmbPeriodoPago.SelectedValue
        fechaIni = Cadena.Substring(0, Cadena.IndexOf("*"))
        fechaFin = Cadena.Substring(Cadena.IndexOf("*") + 1)
        If CheckBox1.Checked = True Then
            Cadena = "EXECUTE sp_CAFETERIA_FACTURACION_SIUD @COMPAÑIA = " & Compañia & ", @BODEGA = " & Me.cbCafeteria.SelectedValue & ", @CAJA = 0,@BANDERA = 'Z', @FEC_INI = '" & fechaIni & "', @FEC_FIN = '" & fechaFin & "'"
        Else
            Try
                Cadena = "EXECUTE sp_CAFETERIA_FACTURACION_SIUD @COMPAÑIA = " & Compañia & ", @BODEGA = " & Me.cbCafeteria.SelectedValue & ", @CAJA = " & Me.cbSeleccioneCaja.SelectedValue & ",@BANDERA = 'R', @FEC_INI = '" & fechaIni & "', @FEC_FIN = '" & fechaFin & "'"
            Catch ex As Exception
                'MsgBox("Elija una caja.", MsgBoxStyle.Information, "Reporte")
                Return
            End Try
        End If
        TextObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        TextObj.Text = "Periodo del " & fechaIni & " al " & fechaFin
        TextObj = rpt.Section2.ReportObjects.Item("txtPeriodoPago")
        TextObj.Text = "Periodo de Pago a Aplicar: " & Me.cmbPeriodoPago.Text
        sqlCmd.CommandText = Cadena
        rpt.SetDataSource(jClass.obtenerDatos(sqlCmd))
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub cbSeleccioneCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeleccioneCaja.SelectedIndexChanged
        If Not Iniciando Then
            cargaReporte()
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If MsgBox("Está seguro de querer procesar?.", MsgBoxStyle.YesNo, "PROCESO") = MsgBoxResult.Yes Then
            Dim Table As DataTable
            Dim sqlCmd As New SqlClient.SqlCommand
            Plantas02 = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 16").ToString().Trim
            TipSoliP1 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
            TipSoliP2 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
            'SELECCIONA TODOS LOS EMPLEADOS QUE HAN CONSUMIDO EN EL INETERVALO SEÑALADO Y SUS RESPECTIVOS MONTOS
            '*****************************************************************************************************
            'sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_FACTURACION_PROGRAMACION_DESCUENTOS @COMPAÑIA = " & Compañia & ", @BODEGA = " & Me.cbCafeteria.SelectedValue & ", @NUMERO_SOLICITUD = 0, @CAJA = " & Me.cbSeleccioneCaja.SelectedValue & ", @CODIGO_EMPLEADO = 0, @CODIGO_EMPLEADO_AS = '0', @FEC_INI = '" & fechaIni & "', @FEC_FIN = '" & fechaFin & "', @BANDERA = 2"
            sqlCmd.CommandText = "SELECT A.CODIGO_EMPLEADO, A.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP1 & " AS TIPOSOLI, CONVERT(DATE, '" & Me.cmbPeriodoPago.Text & "', 103) AS FECHA_PAGO, MAX(B.PERIODO_PAGO) AS PERIODO_PAGO" & vbCrLf
            sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
            sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
            sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
            sqlCmd.CommandText &= "			A.COMPAÑIA = 1          AND" & vbCrLf
            sqlCmd.CommandText &= "			A.BODEGA NOT IN (" & Plantas02 & ") AND" & vbCrLf
            sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
            sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
            sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
            sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO > 0   AND" & vbCrLf
            sqlCmd.CommandText &= "         CONVERT(DATE, A.FECHA_FACTURA) BETWEEN CONVERT(DATE,'" & fechaIni & "',103) AND CONVERT(DATE,'" & fechaFin & "',103) " & vbCrLf
            sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, A.CODIGO_EMPLEADO_AS" & vbCrLf
            sqlCmd.CommandText &= "UNION" & vbCrLf
            sqlCmd.CommandText &= "SELECT A.CODIGO_EMPLEADO, A.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP2 & " AS TIPOSOLI, CONVERT(DATE, '" & Me.cmbPeriodoPago.Text & "', 103) AS FECHA_PAGO, MAX(B.PERIODO_PAGO) AS PERIODO_PAGO" & vbCrLf
            sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
            sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
            sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
            sqlCmd.CommandText &= "			A.COMPAÑIA = 1          AND" & vbCrLf
            sqlCmd.CommandText &= "			A.BODEGA IN (" & Plantas02 & ") AND" & vbCrLf
            sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
            sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
            sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
            sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO > 0   AND" & vbCrLf
            sqlCmd.CommandText &= "         CONVERT(DATE, A.FECHA_FACTURA) BETWEEN CONVERT(DATE,'" & fechaIni & "',103) AND CONVERT(DATE,'" & fechaFin & "',103) " & vbCrLf
            sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, A.CODIGO_EMPLEADO_AS"
            'CARGA LOS DATOS EN TABLE
            Table = jClass.obtenerDatos(sqlCmd)
            '*****************************************************************************************************
            If Table.Rows.Count > 0 Then
                PB.Maximum = Table.Rows.Count
                PB.Value = 0
                PB.Visible = True
                btnGenerar.Enabled = False
                'CrearProgramaciones(Table)
                Me.bw1.RunWorkerAsync(Table)
            Else
                MsgBox("No existen datos que procesar.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cbCafeteria.Enabled = False
            cbSeleccioneCaja.Enabled = False
        Else
            cbCafeteria.Enabled = True
            cbSeleccioneCaja.Enabled = True
        End If
        cargaReporte()
    End Sub

    Private Function CrearProgramaciones(ByVal Tabla As DataTable) As Boolean
        Dim Cmd As New SqlClient.SqlCommand
        Dim numSoli As Integer = 0
        Dim RowsAfected As Integer = 0
        Dim Resultado As Boolean = False
        Dim FechaPago As Date
        For i As Integer = 0 To Tabla.Rows.Count - 1
            FechaPago = CDate(Tabla.Rows(i).Item("FECHA_PAGO"))
            If CDate(Tabla.Rows(i).Item("FECHA_PAGO")).Day >= 28 And CDate(Tabla.Rows(i).Item("FECHA_PAGO")).Day <= 30 And Tabla.Rows(i).Item("PERIODO_PAGO").ToString().Trim() = "MM" Then
                FechaPago = CDate(Tabla.Rows(i).Item("FECHA_PAGO")).AddMonths(1)
            End If
            numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
            FPro.SolicitudesFacturacionSocios(Compañia, Tabla.Rows(i).Item("TIPOSOLI"), numSoli, Tabla.Rows(i).Item("CODIGO_EMPLEADO_AS"), Tabla.Rows(i).Item("CODIGO_EMPLEADO"), CDate(fechaFin), 1, Tabla.Rows(i).Item("MONTO_TOTAL"), 0, 0, "QQ", 1, FechaPago, "Consumo en Cafeteria", 0, 0)
            Cmd.CommandText = "UPDATE CAFETERIA_FACTURACION_ENCABEZADO SET ENVIADO = 1, N_SOLICITUD = " & numSoli
            Cmd.CommandText &= " WHERE COMPAÑIA = " & Compañia & " AND"
            If TipSoliP1 = Tabla.Rows(i).Item("TIPOSOLI") Then
                Cmd.CommandText &= "	   BODEGA NOT IN (" & Plantas02 & ") AND"
            Else
                Cmd.CommandText &= "	   BODEGA IN (" & Plantas02 & ") AND"
            End If
            Cmd.CommandText &= "	   CODIGO_EMPLEADO = " & Tabla.Rows(i).Item("CODIGO_EMPLEADO") & " AND"
            Cmd.CommandText &= "	   ANULADO = 0 AND"
            Cmd.CommandText &= "	   ENVIADO = 0 AND"
            Cmd.CommandText &= "	   FORMA_PAGO = 2 AND"
            Cmd.CommandText &= "	   CODIGO_EMPLEADO > 0 AND"
            Cmd.CommandText &= "	   CONVERT(DATE,FECHA_FACTURA) BETWEEN CONVERT(DATE,'" & fechaIni & "',103) AND CONVERT(DATE,'" & fechaFin & "',103) "
            RowsAfected = jClass.ejecutarComandoSql(Cmd)
            bw1.ReportProgress(i + 1)
        Next
        Return Resultado
    End Function

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        CrearProgramaciones(e.Argument)
    End Sub

    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        PB.Value = e.ProgressPercentage
    End Sub

    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Descuentos")
        PB.Visible = False
        btnGenerar.Enabled = True
    End Sub
End Class