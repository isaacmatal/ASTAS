Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlClient


Public Class Facturacion_Reportes
    Dim c_data2 As New jarsClass
    Dim multi As New multiUsos
    Dim Iniciando As Boolean
    Dim Detallado As Boolean = False
    Dim Anulados As Integer
    Dim FormaPago As Integer = 0
    Dim Iniciando2 As Boolean
    Dim DS01, DS02 As New DataSet()
    Dim bodega_ataf As Integer = 82

    Private Sub Facturacion_Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        bodega_ataf = c_data2.leerDataeader("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE=29", 0)
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBodega)
        multi.CargaTipoDocumentoFact(Compañia, Me.cmbTipDoc)
        multi.CargaOrigenes(Compañia, Me.cmbORIGEN)
        Me.cmbTipDoc.SelectedIndex = 0
        Me.cmbBodega.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
        cargarCajas()
        c_data2.CargarCombo(Me.cmbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compañia & ", " & "'S'", "Tiempo de Comida", "Descripción")
        Iniciando = False
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBodega.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            Me.cmbCajas.Enabled = False
            Me.cmbTiempoComida.Enabled = False
        Else
            c_data2.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBodega.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
            Me.cmbCajas.Enabled = True
            Me.cmbTiempoComida.Enabled = True
        End If
    End Sub
    Sub GetReporteCafeteria()        
        Try
            Dim Sql As String
            Dim anulado As String
            Dim ORIGEN As String
            Dim forma_pago As String = String.Empty
            Dim tiempos As String
            Dim detallado_ As String
            Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject

            If CheckBox1.Checked = False Then
                anulado = "0"
            Else
                anulado = "1"
            End If
            If chkFiltro.Checked = False Then
                ORIGEN = "0"
            Else
                ORIGEN = cmbORIGEN.SelectedValue
            End If
            If rbFPTodos.Checked = True Then
                forma_pago = 0
            End If
            If rbFPContado.Checked = True Then
                forma_pago = 1
            End If
            If rbFPCredito.Checked = True Then
                forma_pago = 2
            End If
            If CheckBox2.Checked = True Then
                tiempos = 0
            Else
                tiempos = cmbTiempoComida.SelectedValue
            End If
            'Si es piden detallado
            If RadioButton1.Checked = True Then
                Sql = "Execute sp_CAFETERIA_REPORTE_VENTAS_DETALLADO "
                detallado_ = "1"
            Else
                Sql = "Execute sp_CAFETERIA_REPORTE_VENTAS "
                detallado_ = "0"
            End If

            Sql &= " @BODEGA = " & cmbBodega.SelectedValue
            Sql &= ", @FECHA1 = '" & Format(dpFechaDesde.Value, "dd/MM/yyyy") & "'"
            Sql &= ", @FECHA2 = '" & Format(dpFechaHasta.Value, "dd/MM/yyyy") & "'"
            Sql &= ", @CAJA = '" & cmbCajas.SelectedValue & "'"
            Sql &= ", @ANULADO = " & anulado
            Sql &= ", @ORIGEN = " & ORIGEN
            Sql &= ", @FORMA_PAGO = " & forma_pago
            Sql &= ", @TIEMPO = " & tiempos
            Sql &= ", @DETALLADO = " & detallado_

            DS01 = c_data2.ObtenerDataSet(Sql)

            'Si es piden detallado
            If RadioButton1.Checked = True Then
                Dim Rpt1 As New Facturacion_Facturas_Cafeteria_Detallado_RPT
                txtObj = Rpt1.Section2.ReportObjects.Item("txtEmpresa")
                txtObj.Text = Descripcion_Compañia
                Rpt1.SetDataSource(DS01.Tables(0))
                Me.CrystalReportViewer1.ReportSource = Rpt1
            Else
                Dim Rpt2 As New Facturacion_Facturas_Cafeteria_Resumen_RPT
                Rpt2.SetDataSource(DS01.Tables(0))
                Me.CrystalReportViewer1.ReportSource = Rpt2
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Me.cmbCajas.Enabled = False Or Me.cmbBodega.SelectedValue = bodega_ataf Then
            CargaRPT()
        Else
            GetReporteCafeteria()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked Then
            Detallado = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked Then
            Detallado = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Anulados = 1
        Else
            Anulados = 0
        End If
    End Sub

    Private Sub CargaRPT()
        Dim jClass As New jarsClass
        If Not Iniciando Then
            Try
                Me.CrystalReportViewer1.ReportSource = Nothing
                Dim report As Object
                Dim sqlcom As New SqlCommand
                Dim table As DataTable
                Dim Sql As String
                If Detallado Then
                    report = New Facturacion_Facturas_Detalle_RPT
                Else
                    report = New Facturacion_Facturas_Resumen_RPT
                End If
                Dim TextORIGEN As CrystalDecisions.CrystalReports.Engine.TextObject
                Sql = "SELECT FGD.PRODUCTO, FGD.NOMBRE_PRODUCTO AS DESCRIPCION_PRODUCTO,"
                Sql &= "( SELECT DESCRIPCION_UNIDAD_MEDIDA FROM dbo.INVENTARIOS_CATALOGO_UNIDAD_MEDIDA ICUM "
                Sql &= "	  WHERE ICUM.COMPAÑIA=FGE.COMPAÑIA AND ICUM.UNIDAD_MEDIDA = FGD.UNIDAD_MEDIDA ) AS DESCRIPCION_UNIDAD_MEDIDA,"
                Sql &= "	FGD.CANTIDAD ,FGD.PRECIO_UNITARIO,FGD.PRECIO_TOTAL,FGE.TOTAL_FACTURA,FGE.BODEGA,"
                Sql &= "	( SELECT DESCRIPCION_BODEGA FROM dbo.INVENTARIOS_CATALOGO_BODEGAS ICB WHERE ICB.COMPAÑIA=FGE.COMPAÑIA AND ICB.BODEGA=FGE.BODEGA ) AS DESCRIPCION_BODEGA,"
                Sql &= "	FGD.ORDEN_VENTA, FGD.TIPO_DOCUMENTO,FGE.NUMERO_FACTURA ,FGD.LINEA ,FGE.CODIGO_EMPLEADO ,FGE.CODIGO_EMPLEADO_AS ,FGE.NOMBRE_FACTURA ,FGE.CUOTAS,"
                Sql &= "	UPPER(DATENAME(MONTH,FGE.DESCONTAR_CUOTAS_DESDE)) AS INICIO_DESCUENTO_MES ,DATENAME(YEAR,FGE.DESCONTAR_CUOTAS_DESDE) AS INICIO_DESCUENTO_AÑO,"
                Sql &= "	FGE.FORMA_PAGO ,"
                Sql &= "	( SELECT DESCRIPCION_FORMA_PAGO FROM dbo.FACTURACION_CATALOGO_FORMA_PAGO FCFP WHERE FCFP.COMPAÑIA=FGE.COMPAÑIA AND FCFP.FORMA_PAGO = FGE.FORMA_PAGO) DESCRIPCION_FORMA_PAGO,"
                Sql &= "	FGE.PERIODO_PAGO ,FGE.IMPRIMIR_CONCEPTO ,FGE.CONCEPTO ,FGE.FECHA_FACTURA ,FGE.FACTURA_IMPRESA ,FGE.NUMERO_REMESA,"
                Sql &= "	FGE.DESCUENTO_AGUINALDO,FGE.DESCUENTO_BONIFICACION,FGE.CLIENTE ,FGE.DESCONTAR_CUOTAS_DESDE,"
                Sql &= "	(  SELECT CC.NOMBRE_COMPAÑIA  FROM  dbo.CATALOGO_COMPAÑIAS CC WHERE CC.COMPAÑIA=FGE.COMPAÑIA ) NOMBRE_COMPAÑIA, "
                Sql &= "	( SELECT DESCRIPCION_TIPO_DOCUMENTO FROM dbo.FACTURACION_CATALOGO_TIPO_DOCUMENTO FCTD  WHERE FCTD.COMPAÑIA = FGD.COMPAÑIA AND FCTD.TIPO_DOCUMENTO = FGD.TIPO_DOCUMENTO) "
                Sql &= "	AS DESCRIPCION_TIPO_DOCUMENTO, FGE.ANULADA, '" & Me.dpFechaDesde.Text & "' AS DESDE, '" & Me.dpFechaHasta.Text & "' AS HASTA,"
                Sql &= "    FGE.SUB_TOTAL, FGE.TOTAL_IVA, FGE.RETENCION, "
                Sql &= "	FGE.NUMERO_PARTIDA  AS NUMERO_PARTIDA, FGE.AHORRO_EXTRA AS TOTAL_REPORTE, 1 AS PDANO"
                Sql &= "    FROM FACTURACION_GENERADA_ENCABEZADO FGE, FACTURACION_GENERADA_DETALLE FGD "
                Sql &= "    WHERE FGD.COMPAÑIA=FGE.COMPAÑIA AND FGD.BODEGA=FGE.BODEGA AND FGD.NUMERO_FACTURA=FGE.NUMERO_FACTURA AND FGD.ORDEN_VENTA=FGE.ORDEN_VENTA AND"
                Sql &= "	FGE.COMPAÑIA = " & Compañia & "  AND FGE.BODEGA = " & Me.cmbBodega.SelectedValue & "  AND FGE.ANULADA = " & Anulados & " AND "
                Sql &= "	FGE.TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue & " AND CONVERT(DATE, FGE.FECHA_FACTURA) BETWEEN CONVERT(DATE, '" & Format(Me.dpFechaDesde.Value, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, '" & Format(Me.dpFechaHasta.Value, "dd/MM/yyyy") & "', 103)"
                'Sql = "EXECUTE sp_FACTURACION_FACTURAS_DETALLE_RPT "
                'Sql &= Compañia
                'Sql &= "," & Me.cmbBodega.SelectedValue
                'Sql &= ",'" & Format(Me.dpFechaDesde.Value, "dd-MM-yyyy 00:00:01") & "'"
                'Sql &= ",'" & Format(Me.dpFechaHasta.Value, "dd-MM-yyyy 23:59:59") & "'"
                'Sql &= ", " & Anulados
                'Sql &= ", " & Me.cmbTipDoc.SelectedValue
                If Me.chkFiltro.Checked Then
                    'If Me.cmbORIGEN.SelectedValue > 0 Then
                    Sql &= " AND FGE.ORIGEN = " & Me.cmbORIGEN.SelectedValue
                Else
                    'Sql &= ", null "
                    'End If
                    'Else
                    'Sql &= ", null "
                End If
                If FormaPago > 0 Then
                    Sql &= " AND FGE.FORMA_PAGO = " & FormaPago
                Else
                    'Sql &= ", null "
                End If
                If Me.chkAExtra.Checked Then
                    Sql &= " AND FGE.AHORRO_EXTRA > 0"
                End If
                Sql &= " ORDER BY FGE.FECHA_FACTURA, FGE.NUMERO_FACTURA, FGE.ORDEN_VENTA"
                sqlcom.CommandText = Sql
                table = jClass.obtenerDatos(sqlcom)
                If table.Rows.Count = 0 Then
                    MsgBox("No hay Datos para los parametros establecidos", MsgBoxStyle.Information, "Reportes")
                Else
                    report.SetDataSource(table)
                    TextORIGEN = report.Section2.ReportObjects.Item("ORIGEN")
                    TextORIGEN.Text = Me.cmbORIGEN.Text.ToUpper
                    If Me.cmbORIGEN.SelectedValue = 0 Then
                        report.Section2.ReportObjects.Item("txtnumpda").ObjectFormat.EnableSuppress = True
                    End If
                    If Me.cmbTipDoc.SelectedValue = 2 Then
                        report.GroupFooterSection1.ReportObjects.Item("Line21").ObjectFormat.EnableSuppress = True
                    End If
                    If chkFiltro.Checked = False Then
                        TextORIGEN.Text = "TODOS LOS ORIGENES"
                    End If
                    Me.CrystalReportViewer1.ReportSource = report
                End If
            Catch ex As Exception
                jClass.msjError(ex, "Reporte Facturación")
            End Try

            'Sql &= ", @FECHA_DESDE = '" & Format(Me.DateTimePicker1.Value, "Short Date") & "'"
            'Sql &= ", @FECHA_HASTA = '" & Format(Me.DateTimePicker2.Value, "Short Date") & "'"

        End If
    End Sub

    Private Sub chkFiltro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltro.CheckedChanged
        Me.cmbORIGEN.Enabled = Me.chkFiltro.Checked
        'If Not Me.chkFiltro.Checked Then
        Me.cmbORIGEN.SelectedValue = 1
        'End If
    End Sub

    Private Sub rbFPTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFPTodos.CheckedChanged
        If Me.rbFPTodos.Checked Then
            FormaPago = 0
        End If
    End Sub

    Private Sub rbFPContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFPContado.CheckedChanged
        If Me.rbFPContado.Checked Then
            FormaPago = 1
        End If
    End Sub

    Private Sub rbFPCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFPCredito.CheckedChanged
        If Me.rbFPCredito.Checked Then
            FormaPago = 2
        End If
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            Iniciando2 = False
        End If
    End Sub

    Private Sub GroupBox3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            cmbTiempoComida.Enabled = False
        Else
            cmbTiempoComida.Enabled = True
        End If

    End Sub
End Class