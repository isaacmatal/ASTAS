Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmReporteDescuentoNoBuxis
    Dim Sql As String
    Dim Iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim ruta As String
    Dim TableReporte1 As New DataTable("noaplicados")

    Private Sub FrmReporteDescuentoNoBuxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        cargaOrigen()
        Iniciando = False
        CargaSolicitudes()
        LimpiaGrid()
    End Sub

    Private Sub cargaOrigen()
        Dim TableOrigen As DataTable
        Dim Comando_Track As SqlCommand
        Sql = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES WHERE ORIGEN > 0 AND COMPAÑIA = " & Compañia
        Comando_Track = New SqlCommand(Sql)
        TableOrigen = jClass.obtenerDatos(Comando_Track)
        Me.cmbOrigenes.DataSource = TableOrigen
        Me.cmbOrigenes.ValueMember = "ORIGEN"
        Me.cmbOrigenes.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbOrigenes.SelectedIndex = 0
    End Sub

    Private Sub CargaSolicitudes()
        Dim Comando_Track As SqlCommand
        Dim FechaPeriodo As String = ""
        Try
            If chkAguin.Checked Then
                FechaPeriodo = "12/12/" & Now.Year.ToString
            ElseIf chkBoni.Checked Then
                FechaPeriodo = "12/06/" & Now.Year.ToString
            Else
                FechaPeriodo = Me.DateTimePicker1.Value.ToShortDateString
            End If
            'Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PARA_BUXIS @COMPAÑIA = " & Compañia & ", @BANDERA = 2, @FECHA_PERIODO = '" & FechaPeriodo & "', @ORIGEN = " & Me.cmbOrigenes.SelectedValue
            Sql = "SELECT cooperativa_programacion_solicitudes_detalle.fecha_pago," & vbCrLf
            Sql &= "		 cooperativa_programacion_solicitudes_encabezado.compañia," & vbCrLf
            Sql &= "		 cooperativa_programacion_solicitudes_encabezado.numero_solicitud [N° Solicitud],   " & vbCrLf
            Sql &= "         cooperativa_solicitudes.Nombre,   " & vbCrLf
            Sql &= "         cooperativa_solicitudes.[Codigo Buxis],   " & vbCrLf
            Sql &= "         cooperativa_solicitudes.[Codigo AS],   " & vbCrLf
            Sql &= "         cooperativa_solicitudes.Solicitud [Solicitud de],   " & vbCrLf
            Sql &= "         cooperativa_solicitudes.valor [Monto],   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle.capital [Abono Capital],   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle.interes [Abono Intereses],   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle.seg_deuda [Seguro Deuda],   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.Cuota," & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.NUM_CUOTAS [Nº Cuotas]," & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle.linea [Cuota a Descontar],   " & vbCrLf
            Sql &= "         facturacion_catalogo_periodos_cuota.descripcion_periodo [Periodo],   " & vbCrLf
            Sql &= "         convert(date,cooperativa_programacion_solicitudes_encabezado.ini_prestamo,106) [Inicio Deuda],   " & vbCrLf
            Sql &= "         convert(date,cooperativa_programacion_solicitudes_encabezado.fecha_primer_pag,106) [Primer Pago]," & vbCrLf
            Sql &= "         cooperativa_solicitudes_autorizacion.numero_factura [Factura]," & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle.capital_d [Pagado]," & vbCrLf
            Sql &= "         cooperativa_solicitudes.Deduccion" & vbCrLf
            Sql &= "    FROM cooperativa_catalogo_socios,   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_detalle,   " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado,   " & vbCrLf
            Sql &= "         VISTA_COOPERATIVA_TODAS_SOLICITUDES as cooperativa_solicitudes,   " & vbCrLf
            Sql &= "         facturacion_catalogo_periodos_cuota," & vbCrLf
            Sql &= "         cooperativa_solicitudes_autorizacion  " & vbCrLf
            Sql &= "   WHERE cooperativa_programacion_solicitudes_encabezado.compañia = cooperativa_programacion_solicitudes_detalle.compañia  and  " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.numero_solicitud = cooperativa_programacion_solicitudes_detalle.numero_solicitud  and  " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.compañia = cooperativa_solicitudes.compañia  and  " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.numero_solicitud = cooperativa_solicitudes.[N° Solicitud]  and " & vbCrLf
            Sql &= "         cooperativa_solicitudes.Compañia = cooperativa_solicitudes_autorizacion.compañia and" & vbCrLf
            Sql &= "         cooperativa_solicitudes.[N° Solicitud] = cooperativa_solicitudes_autorizacion.n_solicitud and" & vbCrLf
            Sql &= "         cooperativa_solicitudes.compañia = cooperativa_catalogo_socios.compañia  and  " & vbCrLf
            Sql &= "         cooperativa_solicitudes.[Codigo AS] = cooperativa_catalogo_socios.codigo_empleado_as  and  " & vbCrLf
            Sql &= "         cooperativa_solicitudes.[Codigo Buxis] = cooperativa_catalogo_socios.codigo_empleado  and  " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.compañia = facturacion_catalogo_periodos_cuota.compañia  and  " & vbCrLf
            Sql &= "         cooperativa_programacion_solicitudes_encabezado.periodo = facturacion_catalogo_periodos_cuota.periodo    and  " & vbCrLf
            'Sql &= "         cooperativa_programacion_solicitudes_detalle.reprogramada = 0 and" & vbcrlf
            Sql &= "         cooperativa_solicitudes.Compañia = " & Compañia & " and" & vbCrLf
            Sql &= "         cooperativa_catalogo_socios.origen = " & Me.cmbOrigenes.SelectedValue & " and" & vbCrLf
            Sql &= "         cooperativa_catalogo_socios.ES_BUXIS = 0 and" & vbCrLf
            Sql &= "         convert(date, cooperativa_programacion_solicitudes_detalle.fecha_pago) = '" & FechaPeriodo & "'" & vbCrLf

            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            Me.dgvProgramaciones.DataSource = Table
            Me.dgvProgramaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Try
            Me.dgvProgramaciones.Columns(0).Visible = False 'Fecha Pago
            Me.dgvProgramaciones.Columns(1).Visible = False 'Compañia
            Me.dgvProgramaciones.Columns(2).Width = 50 'Nº Solicitud
            Me.dgvProgramaciones.Columns(4).Visible = False 'Codigo Buxis
            Me.dgvProgramaciones.Columns(5).Width = 55 'Codigo AS 
            Me.dgvProgramaciones.Columns(7).Width = 70 'Monto
            Me.dgvProgramaciones.Columns(8).Width = 85 'Abono Capital
            Me.dgvProgramaciones.Columns(9).Width = 60 'Abono Intereses
            Me.dgvProgramaciones.Columns(10).Width = 60 'Seguro Deuda
            Me.dgvProgramaciones.Columns(11).Width = 60 'Cuota
            Me.dgvProgramaciones.Columns(12).Width = 50 'Nº Cuotas
            Me.dgvProgramaciones.Columns(13).Width = 70 'Cuota a Descontar
            Me.dgvProgramaciones.Columns(14).Width = 90 'Periodo
            Me.dgvProgramaciones.Columns(15).Width = 90 'Fecha Inicio Prestamo
            Me.dgvProgramaciones.Columns(16).Width = 90 'Fecha Primer Pago
            Me.dgvProgramaciones.Columns(17).Width = 60 'No.Factura
            Me.dgvProgramaciones.Columns(18).Width = 50 'Pagado?
            Me.dgvProgramaciones.Columns(9).DefaultCellStyle.ForeColor = Color.Blue
            Me.dgvProgramaciones.Columns(7).DefaultCellStyle.ForeColor = Color.Red
            Me.dgvProgramaciones.Columns(7).DefaultCellStyle.Format = "#,##0.00"
            Me.dgvProgramaciones.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Me.dgvProgramaciones.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Me.dgvProgramaciones.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dgvProgramaciones.Columns.Item(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvProgramaciones.Columns.Item(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For i As Integer = 1 To Me.dgvProgramaciones.Columns.Count - 1
                Me.dgvProgramaciones.Columns(i).ReadOnly = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New ReporteDescuentoNoBuxis
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.Section3.ReportObjects.Item("txtOrigen")
        rpt.SetDataSource(Me.dgvProgramaciones.DataSource)
        TextObj.Text = Me.cmbOrigenes.Text
        TextObj = rpt.Section3.ReportObjects.Item("txtEmpresa")
        TextObj.Text = Descripcion_Compañia
        frmVer.ReportesGenericos(rpt)
        frmVer.crvReporte.DisplayGroupTree = False
        frmVer.ShowDialog()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Not Iniciando Then
            chkAguin.Checked = False
            chkBoni.Checked = False
            CargaSolicitudes()
        End If
    End Sub

    Private Sub chkAguin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAguin.CheckedChanged
        If chkAguin.Checked Then
            chkBoni.Checked = False
        End If
        CargaSolicitudes()
    End Sub

    Private Sub chkBoni_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoni.CheckedChanged
        If chkBoni.Checked Then
            chkAguin.Checked = False
        End If
        CargaSolicitudes()
    End Sub

    Private Sub cmbOrigenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrigenes.SelectedIndexChanged
        If Not Iniciando Then
            CargaSolicitudes()
        End If
    End Sub

    Private Sub rbtTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        If Not Iniciando Then
            If rbtTodos.Checked Then
                LlenarGrid(Table)
            End If
        End If
    End Sub

    Private Sub rbtAplic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAplic.CheckedChanged
        Dim TableReporte As New DataTable("noaplicados")
        If Not Iniciando Then
            If rbtAplic.Checked Then
                TableReporte.Reset()
                TableReporte = Table.Clone()
                For Each row As DataRow In Table.Rows
                    If row.Item(18) Then
                        TableReporte.ImportRow(row)
                    End If
                Next
                LlenarGrid(TableReporte)
            End If
        End If
    End Sub

    Private Sub rbtNoAplic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAplic.CheckedChanged
        Dim TableReporte As New DataTable("noaplicados")
        If Not Iniciando Then
            If rbtNoAplic.Checked Then
                TableReporte.Reset()
                TableReporte = Table.Clone()
                For Each row As DataRow In Table.Rows
                    If Not row.Item(18) Then
                        TableReporte.ImportRow(row)
                    End If
                Next
                LlenarGrid(TableReporte)
            End If
        End If
    End Sub

    Private Sub LlenarGrid(ByVal TableGrid As DataTable)
        Me.dgvProgramaciones.DataSource = TableGrid
        LimpiaGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            SaveFileDialog1.FileName = cmbOrigenes.SelectedText
            SaveFileDialog1.Filter = "Archivo de text(*.txt)|*.txt"
            SaveFileDialog1.ShowDialog()
            ruta = SaveFileDialog1.FileName()
            Dim escribir As New StreamWriter(ruta)

            For i As Integer = 0 To dgvProgramaciones.RowCount - 1
                'POLLO CAMPERO
                If cmbOrigenes.SelectedValue = 3 Then
                    Dim letra As String
                    ', numero As String
                    If dgvProgramaciones.Rows(i).Cells(14).Value.ToString() = "QUINCENAL" Then
                        If (DateTimePicker1.Value.Day >= 1) And (DateTimePicker1.Value.Day <= 15) Then
                            letra = "P"
                        Else
                            letra = "S"
                        End If
                    Else
                        letra = "M"
                    End If
                    escribir.WriteLine("""" & dgvProgramaciones.Rows(i).Cells(5).Value.ToString() & """," & """" & dgvProgramaciones.Rows(i).Cells(19).Value.ToString() & """," & """" & dgvProgramaciones.Rows(i).Cells(5).Value.ToString() & """," & """" & Format(Date.Now, "dd/MM/yyyy") & """," & """" & Format(dgvProgramaciones.Rows(i).Cells(0).Value, "dd/MM/yyyy") & """," & """" & dgvProgramaciones.Rows(i).Cells(7).Value.ToString() & """," & """" & "1" & """," & """" & letra & """," & """" & "13" & """")
                ElseIf cmbOrigenes.SelectedValue = 4 Then
                    'SULTANA
                    escribir.WriteLine(dgvProgramaciones.Rows(i).Cells(19).Value.ToString() & "|" & dgvProgramaciones.Rows(i).Cells(5).Value.ToString() & "|" & Format(Date.Now, "dd/MM/yyyy") & "|" & Format(Date.Now, "dd/MM/yyyy") & "|" & "0" & "|" & "0" & "|" & "0" & "|" & "0" & "|" & dgvProgramaciones.Rows(i).Cells(7).Value.ToString())
                ElseIf cmbOrigenes.SelectedValue = 2 Then
                    'AVICOLA o AVINSA
                    escribir.WriteLine(dgvProgramaciones.Rows(i).Cells(19).Value.ToString() & "|" & dgvProgramaciones.Rows(i).Cells(5).Value.ToString() & "|" & Format(Date.Now, "dd/MM/yyyy") & "|" & Format(Date.Now, "dd/MM/yyyy") & "|" & "0" & "|" & "0" & "|" & "0" & "|" & "0" & "|" & dgvProgramaciones.Rows(i).Cells(7).Value.ToString())
                End If
                escribir.Flush()
            Next
        Catch ex As Exception
            MsgBox("Aviso...No se ha podido generar el archivo (.txt)", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub FrmReporteDescuentoNoBuxis_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class