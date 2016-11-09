Imports System.Data
Imports System.Data.SqlClient
Public Class FrmCancelaDeudasNoBuxis
    Dim Sql As String
    Dim Iniciando As Boolean = True
    Dim jClass As New jarsClass

    Private Sub FrmReporteDescuentoNoBuxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        cargaOrigen()
        CargaSolicitudes()
        Iniciando = False
    End Sub

    Private Sub cargaOrigen()
        Dim Table As DataTable
        Dim Comando_Track As SqlCommand
        Sql = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES WHERE ORIGEN > 0 AND COMPAÑIA = " & Compañia
        Comando_Track = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(Comando_Track)
        Me.cmbOrigenes.DataSource = Table
        Me.cmbOrigenes.ValueMember = "ORIGEN"
        Me.cmbOrigenes.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbOrigenes.SelectedIndex = 0
    End Sub
    Private Sub CargaSolicitudes()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Dim FechaPeriodo As String = ""
        Try
            If chkAguin.Checked Then
                FechaPeriodo = "12/12/" & Now.Year.ToString
            ElseIf chkBoni.Checked Then
                FechaPeriodo = "12/06/" & Now.Year.ToString
            Else
                FechaPeriodo = Me.DateTimePicker1.Value.ToShortDateString
            End If
            Sql = GeneraSQL() '"Execute Coo.sp_COOPERATIVA_SOLICITUDES_PARA_BUXIS @COMPAÑIA = " & Compañia & ", @BANDERA = 3, @FECHA_PERIODO = '" & FechaPeriodo & "', @ORIGEN = " & Me.cmbOrigenes.SelectedValue
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
            If Me.dgvProgramaciones.Columns.Count > 0 Then
                Me.dgvProgramaciones.Columns(0).Width = 50 'Pagado?
                Me.dgvProgramaciones.Columns(1).Visible = False 'Compañia
                Me.dgvProgramaciones.Columns(2).Width = 50 'Nº Solicitud
                Me.dgvProgramaciones.Columns(4).Visible = False 'Codigo Buxis
                Me.dgvProgramaciones.Columns(5).Width = 55 'Codigo AS 
                Me.dgvProgramaciones.Columns(7).Width = 60 'Monto
                Me.dgvProgramaciones.Columns(8).Width = 85 'Abono Capital
                Me.dgvProgramaciones.Columns(9).Width = 70 'Fecha Pago
                Me.dgvProgramaciones.Columns(10).Width = 50 'Nº Cuotas
                Me.dgvProgramaciones.Columns(11).Width = 70 'Cuota a Descontar
                Me.dgvProgramaciones.Columns(12).Width = 90 'Periodo
                Me.dgvProgramaciones.Columns(13).Width = 90 'Fecha Inicio Prestamo
                Me.dgvProgramaciones.Columns(14).Width = 90 'Fecha Primer Pago
                Me.dgvProgramaciones.Columns(15).Width = 60 'No.Factura
                Me.dgvProgramaciones.Columns(7).DefaultCellStyle.ForeColor = Color.Red
                Me.dgvProgramaciones.Columns(9).DefaultCellStyle.ForeColor = Color.Blue
                Me.dgvProgramaciones.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'Nombre
                Me.dgvProgramaciones.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'Solicitud de
                Me.dgvProgramaciones.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.dgvProgramaciones.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.dgvProgramaciones.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvProgramaciones.Columns.Item(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                For i As Integer = 1 To Me.dgvProgramaciones.Columns.Count - 1
                    Me.dgvProgramaciones.Columns(i).ReadOnly = True
                Next
                Me.dgvProgramaciones.Columns(9).ReadOnly = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim sqlCmd As New SqlCommand
        'Sql = "UPDATE cooperativa_catalogo_socios SET BLOQUEADO = 0 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = 0"
        'sqlCmd.CommandText = Sql
        'jClass.ejecutarComandoSql(sqlCmd)
        guardaInfo()
        CargaSolicitudes()
    End Sub

    Private Sub SelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll.CheckedChanged
        For Each row As DataGridViewRow In Me.dgvProgramaciones.Rows
            row.Cells(0).Value = SelectAll.Checked
        Next
        If SelectAll.Checked Then
            SelectAll.Text = "Deseleccionar Todos"
        Else
            SelectAll.Text = "Seleccionar Todos"
        End If
    End Sub

    Private Sub guardaInfo()
        Dim pagado As Integer = 0
        Dim sqlCmd As New SqlCommand
        For i As Integer = 0 To Me.dgvProgramaciones.Rows.Count - 1
            If Me.dgvProgramaciones.Rows.Item(i).Cells(0).Value Then
                pagado = 1
            Else
                pagado = 0
            End If
            Sql = "UPDATE COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE SET CAPITAL_D = " & pagado & ", INTERES_D = " & pagado & ", SEG_DEUDA_D = " & pagado & ", FECHA_PAGO = '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(9).Value, "dd/MM/yyyy") & "', COMENTARIO = 'ABONO DEL " & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(9).Value, "dd/MM/yyyy") & "'"
            Sql &= " WHERE COMPAÑIA = " & Compañia
            Sql &= " AND NUMERO_SOLICITUD = " & Me.dgvProgramaciones.Rows.Item(i).Cells(2).Value
            Sql &= " AND LINEA = " & Me.dgvProgramaciones.Rows.Item(i).Cells(11).Value
            sqlCmd.CommandText = Sql
            Try
                jClass.ejecutarComandoSql(sqlCmd)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'If pagado = 0 Then
            '    Me.ActualizarDescuentos(Me.dgvProgramaciones.Rows.Item(i).Cells(2).Value, 8, Me.DateTimePicker1.Value)
            'End If
        Next
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Cancelacion Descuentos")
    End Sub

    Private Sub ActualizarDescuentos(ByVal NumSoli As Integer, ByVal Bandera As Integer, ByVal FechaAplicacion As Date)
        Dim sqlCmd As New SqlCommand
        Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS]"
        Sql &= " @COMPAÑIA = " & Compañia
        Sql &= ", @FECHA_PERIODO = '" & FechaAplicacion.ToShortDateString & "'"
        Sql &= ", @NUM_SOLICITUD = " & NumSoli
        Sql &= ", @BANDERA = " & Bandera
        sqlCmd.CommandText = Sql
        Try
            jClass.ejecutarComandoSql(sqlCmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function GeneraSQL() As String
        Dim query As String
        query = "SELECT cooperativa_programacion_solicitudes_detalle.capital_d [Pagado]," & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.compañia," & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.numero_solicitud [N° Solicitud],   " & vbCrLf
        query &= " cooperativa_solicitudes.Nombre,   " & vbCrLf
        query &= " cooperativa_solicitudes.[Codigo Buxis],   " & vbCrLf
        query &= " cooperativa_solicitudes.[Codigo AS],   " & vbCrLf
        query &= " cooperativa_solicitudes.Solicitud [Solicitud de],   " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.monto [Monto],   " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_detalle.capital [Abono Capital],   " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_detalle.fecha_pago [Fecha Pago],   " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.NUM_CUOTAS [Nº Cuotas]," & vbcrlf
        query &= " cooperativa_programacion_solicitudes_detalle.linea [Cuota a Descontar],   " & vbCrLf
        query &= " facturacion_catalogo_periodos_cuota.descripcion_periodo [Periodo],   " & vbCrLf
        query &= " convert(date,cooperativa_programacion_solicitudes_encabezado.ini_prestamo,106) [Inicio Deuda],   " & vbCrLf
        query &= " convert(date,cooperativa_programacion_solicitudes_encabezado.fecha_primer_pag,106) [Primer Pago]," & vbCrLf
        query &= " cooperativa_solicitudes_autorizacion.numero_factura [Factura] " & vbCrLf
        query &= "FROM cooperativa_catalogo_socios,   " & vbCrLf
        query &= "cooperativa_programacion_solicitudes_detalle,   " & vbCrLf
        query &= "cooperativa_programacion_solicitudes_encabezado,   " & vbCrLf
        query &= "VISTA_COOPERATIVA_TODAS_SOLICITUDES as cooperativa_solicitudes,   " & vbCrLf
        query &= "facturacion_catalogo_periodos_cuota, " & vbCrLf
        query &= "cooperativa_solicitudes_autorizacion " & vbCrLf
        query &= " WHERE cooperativa_programacion_solicitudes_encabezado.compañia = cooperativa_programacion_solicitudes_detalle.compañia  and  " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.numero_solicitud = cooperativa_programacion_solicitudes_detalle.numero_solicitud  and  " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.compañia = cooperativa_solicitudes.compañia  and  " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.numero_solicitud = cooperativa_solicitudes.[N° Solicitud]  and " & vbCrLf
        query &= " cooperativa_solicitudes.Compañia = cooperativa_solicitudes_autorizacion.compañia and" & vbCrLf
        query &= " cooperativa_solicitudes.[N° Solicitud] = cooperativa_solicitudes_autorizacion.n_solicitud and" & vbCrLf
        query &= " cooperativa_solicitudes.compañia = cooperativa_catalogo_socios.compañia  and  " & vbCrLf
        query &= " cooperativa_solicitudes.[Codigo AS] = cooperativa_catalogo_socios.codigo_empleado_as  and  " & vbCrLf
        query &= " cooperativa_solicitudes.[Codigo Buxis] = cooperativa_catalogo_socios.codigo_empleado  and  " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.compañia = facturacion_catalogo_periodos_cuota.compañia  and  " & vbCrLf
        query &= " cooperativa_programacion_solicitudes_encabezado.periodo = facturacion_catalogo_periodos_cuota.periodo    and  " & vbCrLf
        query &= " cooperativa_catalogo_socios.ES_BUXIS = 0 and" & vbCrLf
        If Not Me.rbTodos.Checked Then
            If Me.rbPagado.Checked Then
                query &= " cooperativa_programacion_solicitudes_detalle.capital_d = 1 and" & vbCrLf
            ElseIf Me.rbNoPagado.Checked Then
                query &= " cooperativa_programacion_solicitudes_detalle.capital_d = 0 and" & vbCrLf
            End If
        End If
        query &= " cooperativa_solicitudes.Compañia = " & Compañia & " and" & vbCrLf
        query &= " cooperativa_catalogo_socios.origen = " & IIf(Iniciando, 0, Me.cmbOrigenes.SelectedValue) & " and" & vbCrLf
        query &= " CONVERT(DATE,cooperativa_programacion_solicitudes_detalle.fecha_pago) = CONVERT(DATE, '" & Format(Me.DateTimePicker1.Value, "dd/MM/yyyy") & "', 103)"
        Return query
    End Function

    Private Sub rbPagado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPagado.CheckedChanged, rbNoPagado.CheckedChanged, rbTodos.CheckedChanged
        CargaSolicitudes()
    End Sub

    Private Sub FrmCancelaDeudasNoBuxis_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class