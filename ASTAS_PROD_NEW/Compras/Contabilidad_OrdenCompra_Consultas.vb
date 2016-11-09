Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Consultas
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass
    Dim Comando_ As New SqlCommand
    Dim Table, TableOC As DataTable

    Private Sub Contabilidad_OrdenCompra_Consultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBodegas(Compañia, 2)
        Me.dpFechaDesde.Value = Now.AddDays(-3)
        Iniciando = False
        BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "4")
    End Sub

    Private Sub CargaBodegas(ByVal Compañia As Integer, ByVal Bandera As Integer)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS " & vbCrLf
            Sql &= Bandera & vbCrLf
            Sql &= ", " & Compañia & vbCrLf
            Sql &= ", ''" & vbCrLf
            Comando_.CommandText = Sql
            Table = jClass.obtenerDatos(Comando_)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
            Me.cmbBODEGA.SelectedValue = 999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvOrdenesCompra.Columns(0).Width = 50 'N° OC
        Me.dgvOrdenesCompra.Columns(1).Width = 100 'Comprobantes
        Me.dgvOrdenesCompra.Columns(2).Width = 80 'Quedan
        Me.dgvOrdenesCompra.Columns(3).Width = 60 'Partida
        Me.dgvOrdenesCompra.Columns(4).Width = 70 'Fecha OC
        Me.dgvOrdenesCompra.Columns(5).Width = 70 'Finalizada
        Me.dgvOrdenesCompra.Columns(6).Width = 70 'Autorizada
        Me.dgvOrdenesCompra.Columns(7).Width = 60 'Recibida
        Me.dgvOrdenesCompra.Columns(8).Width = 60 'Pagada
        Me.dgvOrdenesCompra.Columns(9).Width = 60 'Anulada
        Me.dgvOrdenesCompra.Columns(10).Width = 220 'Bodega
        Me.dgvOrdenesCompra.Columns(11).Width = 220 'Proveedor
        Me.dgvOrdenesCompra.Columns(12).Width = 70 'Sub Total
        Me.dgvOrdenesCompra.Columns(13).Width = 70 'IVA
        Me.dgvOrdenesCompra.Columns(14).Width = 70 'Total
        Me.dgvOrdenesCompra.Columns(15).Width = 70 '(+)Percep.
        Me.dgvOrdenesCompra.Columns(16).Width = 70 '(-)Retenc.
        Me.dgvOrdenesCompra.Columns(17).Width = 70 'Total Compra
        Me.dgvOrdenesCompra.Columns(18).Width = 70 'Forma Pago
        Me.dgvOrdenesCompra.Columns(19).Width = 80 'Condición Pago
        Me.dgvOrdenesCompra.Columns(20).Width = 70 'Usuario Autorización
        Me.dgvOrdenesCompra.Columns(21).Width = 130 'Fecha Autorización
        Me.dgvOrdenesCompra.Columns(22).Width = 300 'OBSERVACIONES
        Me.dgvOrdenesCompra.Columns(23).Width = 70 'Afecta Inventario

        Me.dgvOrdenesCompra.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(13).DefaultCellStyle.ForeColor = Color.Blue
        Me.dgvOrdenesCompra.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(14).DefaultCellStyle.ForeColor = Color.Red
        Me.dgvOrdenesCompra.Columns.Item(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(15).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvOrdenesCompra.Columns.Item(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.dgvOrdenesCompra.Columns.Item(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns.Item(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns.Item(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i As Integer = 0 To 9
            Me.dgvOrdenesCompra.Columns(i).DefaultCellStyle.BackColor = Color.LightGray
        Next
        Me.dgvOrdenesCompra.Columns(9).Frozen = True
    End Sub

    Private Sub BuscarOC(ByVal Compañia As Integer, ByVal Bodega As Integer, ByVal OC As Integer, ByVal NombreProveedor As String, ByVal NombreComercial As String, ByVal NIT As String, ByVal NRC As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Bandera As Integer)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA " & vbCrLf
            Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @BODEGA = " & Bodega & vbCrLf
            Sql &= ", @ORDEN_COMPRA = " & OC & vbCrLf
            Sql &= ", @NOMBRE_PROVEEDOR = '" & NombreProveedor & "'" & vbCrLf
            Sql &= ", @NOMBRE_COMERCIAL = '" & NombreComercial & "'" & vbCrLf
            Sql &= ", @NIT = '" & NIT & "'" & vbCrLf
            Sql &= ", @NRC = '" & NRC & "'" & vbCrLf
            Sql &= ", @FECHA_INICIAL = '" & Format(FechaIni, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @FECHA_FINAL = '" & Format(FechaFin, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @BANDERA = " & Bandera & vbCrLf
            Comando_.CommandText = Sql
            TableOC = jClass.obtenerDatos(Comando_)
            Me.dgvOrdenesCompra.Columns.Clear()
            Me.cmbEstado.SelectedIndex = 0
            Me.dgvOrdenesCompra.DataSource = TableOC
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "4")
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value <> Nothing Then
            If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("Compra Directa").Value Then
                Rpts.CargaOC_Directa(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value)
            Else
                Rpts.CargaOC(Compañia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value) 'CargaOC
            End If
            Rpts.ShowDialog()
        Else
            MsgBox("¡Debe seleccionar una Orden de Compra válida!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Not Iniciando Then
            BuscarOC(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "4")
        End If
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Dim Estado As String = Me.cmbEstado.Text
        Dim TableReporte As New DataTable("OC")
        TableReporte = TableOC.Clone()
        If Not Iniciando Then
            Select Case Estado
                Case "Todas"
                    Me.dgvOrdenesCompra.DataSource = TableOC
                Case "Finalizadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(4, True)
                Case "No Finalizadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(4, False)
                Case "Autorizadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(5, True)
                Case "No Autorizadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(5, False)
                Case "Recibidas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(6, True)
                Case "No Recibidas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(6, False)
                Case "Pagadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(7, True)
                Case "No Pagadas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(7, False)
                Case "Anuladas"
                    Me.dgvOrdenesCompra.DataSource = FiltrarTabla(8, True)
            End Select
        End If
    End Sub

    Private Function FiltrarTabla(ByVal Opcion As Integer, ByVal Tipo As Boolean) As DataTable
        Dim TableReporte As New DataTable("OC")
        TableReporte = TableOC.Clone()
        For Each row As DataRow In TableOC.Rows
            If row.Item(Opcion) = Tipo Then
                TableReporte.ImportRow(row)
            End If
        Next
        Return TableReporte
    End Function

    Private Sub bntListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntListado.Click
        Dim frmrep As New frmReportes_Ver
        Dim rpt As New Cuentas_x_Pagar_OC_Consultas
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        TextObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        TextObj.Text = Descripcion_Compañia
        TextObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        TextObj.Text = "DESDE: " & Me.dpFechaDesde.Value.ToShortDateString & "        HASTA: " & Me.dpFechaHasta.Value.ToShortDateString
        TextObj = rpt.Section2.ReportObjects.Item("txtFiltro")
        If Me.cmbEstado.Text = "Todas" Then
            TextObj.Text = "TODAS LAS ORDENES DE COMPRA DEL PERIODO SELECCIONADO"
        Else
            TextObj.Text = "ORDENES DE COMPRA " & Me.cmbEstado.Text.ToUpper & " DEL PERIODO SELECCIONADO"
        End If
        rpt.SetDataSource(Me.dgvOrdenesCompra.DataSource)
        frmrep.ReportesGenericos(rpt)
        frmrep.ShowDialog()
    End Sub

    Private Sub btnRepRecibido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepRecibido.Click
        If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("Comprobantes").Value.ToString().Length = 0 Then
            Return
        End If
        Dim frmRep As New frmReportes_Ver()
        Dim tbl_Reporte As DataTable
        Dim reporte_10 As New Inventario_Compras_Recibir_rpt
        Dim reporte_12 As New Inventario_Compras_Recibir_No_Inv_rpt
        Dim Comprobantes As String = Me.dgvOrdenesCompra.CurrentRow.Cells.Item(1).Value
        Dim ArrComprob As String() = Comprobantes.Split(",")
        For Each comprob As String In ArrComprob
            tbl_Reporte = jClass.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & ", @BANDERA = 1, @DOCUMENTO = " & comprob))
            If Me.dgvOrdenesCompra.CurrentRow.Cells.Item("Afecta Inventario").Value Then
                reporte_10.SetDataSource(tbl_Reporte)
                frmRep.ReportesGenericos(reporte_10)
            Else
                reporte_12.SetDataSource(tbl_Reporte)
                frmRep.ReportesGenericos(reporte_12)
            End If
            frmRep.ShowDialog()
        Next
    End Sub

    Private Sub btnRepQuedan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepQuedan.Click
        Dim frmRep As New frmReportes_Ver()
        Dim tbl_Quedan As DataTable
        Dim Quedan As Integer = 0
        Dim reporte_11 As New CuentasxPagar_Quedan
        Dim Comprobantes As String = Me.dgvOrdenesCompra.CurrentRow.Cells.Item(1).Value
        Dim ArrComprob As String() = Comprobantes.Split(",")
        For Each comprob As String In ArrComprob
            tbl_Quedan = jClass.obtenerDatos(New SqlCommand("EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 @COMPAÑIA = " & Compañia & ", @ORDEN_COMPRA = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & ", @BANDERA = 6, @DOCUMENTO = " & comprob))
            If Quedan <> tbl_Quedan.Rows(0).Item("QUEDAN") Then
                reporte_11.SetDataSource(tbl_Quedan)
                frmRep.ReportesGenericos(reporte_11)
                frmRep.ShowDialog()
            End If
            Quedan = tbl_Quedan.Rows(0).Item("QUEDAN")
        Next
    End Sub

    Private Sub Contabilidad_OrdenCompra_Consultas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class