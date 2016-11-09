Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmEnviarProgramaciones
    Dim Sql As String
    Dim TablaEnviar As New DataTable("Enviar")
    Dim Iniciando As Boolean = True
    Dim jClass As New jarsClass
    Dim ManejadorTexto As New ArchivosTexto
    Dim Table As DataTable
    Dim Periodo As String = "QQ"
    Dim rpts As New frmReportes_Ver
    Dim Archivo As String

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.lblTotalEnviado.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.lblTotalEnviado.Text = texto
        End If
    End Sub

    Private Sub FrmEnviarProgramaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = False
        Me.dpFechaPago.MinDate = Now.AddDays(-2)
        Me.WindowState = FormWindowState.Maximized
        CargaSolicitudes()
        LimpiaGrid()
    End Sub

    Private Sub CargaSolicitudes()
        Dim Comando_Track As SqlCommand
        Dim FechaPeriodo As String = ""
        'Me.lblTotalEnviado.Text = ""
        Try
            If chkAguin.Checked Then
                FechaPeriodo = "12/12/" & IIf(CDate("12/12/" & Now.Year.ToString) > Now(), Now.Year.ToString, (Now.Year + 1).ToString)
            ElseIf chkBoni.Checked Then
                FechaPeriodo = "12/06/" & IIf(CDate("12/06/" & Now.Year.ToString) > Now(), Now.Year.ToString, (Now.Year + 1).ToString)
            Else
                FechaPeriodo = Me.dpFechaPago.Value.ToShortDateString
            End If
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_PARA_BUXIS " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @BANDERA = 1" & vbCrLf
            Sql &= ", @FECHA_PERIODO = '" & FechaPeriodo & "'" & vbCrLf
            If chkAguin.Checked Or Me.chkBoni.Checked Then
                Sql &= ", @PERIODO_PAGO = NULL" & vbCrLf
            Else
                Sql &= ", @PERIODO_PAGO = '" & Periodo & "'" & vbCrLf
            End If
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            Me.dgvProgramaciones.DataSource = Table
            Me.dgvProgramaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            SelectAll.Checked = False
            SelectAll.Text = "Seleccionar Todos (" & Me.dgvProgramaciones.Rows.Count & ")"
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MantenimientoSolicitudesBuxis(ByVal N_Solicitud As Integer, ByVal Bandera As Integer)
        Dim Comando_Track As SqlCommand
        Dim FechaPeriodo As String = ""
        Try
            If chkAguin.Checked Then
                FechaPeriodo = "12/12/" & Now.Year.ToString
            ElseIf chkBoni.Checked Then
                FechaPeriodo = "12/06/" & Now.Year.ToString
            Else
                FechaPeriodo = Me.dpFechaPago.Value.ToShortDateString
            End If
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS @COMPAÑIA = " & Compañia & ", @FECHA_PERIODO = '" & FechaPeriodo & "', @NUM_SOLICITUD = " & N_Solicitud & ", @BANDERA = " & Bandera & ",@PERIODO_PAGO = '" & Periodo & "'"
            Comando_Track = New SqlCommand(Sql)
            jClass.ejecutarComandoSql(Comando_Track)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CreaArchivoTexto(ByVal NombreArchivo As String)
        Dim sqlcmd As New SqlCommand
        Dim TableIndem As DataTable
        'Dim FileMan As IO.File
        Dim Carpeta As String = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 19").ToString.Trim
        sqlcmd.CommandText = "SELECT Cod_mv, COD_MF, FEC_VAL_HD, FEC_ACU_HD, JORNALES_HD, HORAS_HD, UNID_HD, IMPUNI_HD, IMPTOT_HD FROM [dbo].[PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS]"
        TableIndem = jClass.obtenerDatos(sqlcmd)
        If TableIndem.Rows.Count > 0 Then
            If Not ManejadorTexto.enviarDatos(TableIndem, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NombreArchivo) Then
                MsgBox("No fue posible crear el archivo", MsgBoxStyle.Critical, "Archivo Texto")
                Return
            End If
        End If
        Try
            File.Copy(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NombreArchivo, Carpeta & "\" & NombreArchivo, True)
            Shell("explorer.exe root = " & Carpeta, AppWinStyle.NormalFocus)
        Catch ex As Exception
            jClass.msjError(ex, "Enviar Programaciones(Crear Archivo)")
            MsgBox("Error al mover el archivo a la carpeta destino: " & Carpeta & vbCrLf & _
                   "El archivo se creó en la carpeta " & Chr(39) & "Mis Documentos" & Chr(39) & vbCrLf & _
                   "Deberá copiar el archivo: " & NombreArchivo & vbCrLf & "a la carpeta: " & Carpeta & " con el Explorador de Windows", _
                   MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub EnviarIndemnizados()
        Dim Result, CodEmp, _origen As Integer
        Dim sqlcmd As New SqlCommand
        Dim Archivo As String

        Dim _fecha As String = String.Empty
        Dim _codigo As String = String.Empty
        Dim _sub_sql As String = String.Empty
        Try
            For i As Integer = 0 To Me.dgvProgramaciones.Rows.Count - 1
                If Me.dgvProgramaciones.Rows.Item(i).Cells(0).Value Then
                    CodEmp = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value & " AND CODIGO_EMPLEADO_AS = '" & Me.dgvProgramaciones.Rows.Item(i).Cells(5).Value & "'")
                    _origen = CodEmp
                    Sql = "SELECT Cod_emp FROM COOPERATIVA_CATALOGO_ORIGENES_MAPEO WHERE ORIGEN = " & CodEmp
                    CodEmp = jClass.obtenerEscalar(Sql)
                    Sql = "INSERT INTO [dbo].[PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS] "
                    Sql &= "([COD_MV]"
                    Sql &= ",[COD_MF]"
                    Sql &= ",[FEC_VAL_HD]"
                    Sql &= ",[FEC_ACU_HD]"
                    Sql &= ",[UNID_HD]"
                    Sql &= ",[IMPUNI_HD]"
                    Sql &= ",[IMPTOT_HD]"
                    Sql &= ",[Cod_Emp]"
                    Sql &= ") VALUES"
                    Sql &= "(" & Me.dgvProgramaciones.Rows.Item(i).Cells(1).Value
                    Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value
                    Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                    Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                    Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(2).Value
                    Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(8).Value
                    Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(8).Value
                    Sql &= ", " & CodEmp
                    Sql &= ")"

                    '' Modificado Julio Portillo 02/09/2015
                    ''==================================================================================='
                    'If Not _codigo.Equals(Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value.ToString().Trim()) Then
                    '    'agregar al encabezado
                    '    _sub_sql = "INSERT INTO  dbo.INDEMNIZADOS (CODIGO, CANCELADO, COMPAÑIA, ORIGEN) VALUES (" & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value & ",0," & Compañia & ", " & _origen & ")"
                    '    sqlcmd.CommandText = _sub_sql
                    '    Result = jClass.ejecutarComandoSql(sqlcmd)
                    'End If

                    '_sub_sql = "INSERT INTO  dbo.DETALLE_INDEMNIZADOS (CODIGO, CODIGO_DEDUCCION, FECHA, VALOR, IRRECUPERABLE, ESTATUS, COMPAÑIA, FECHA_CANCELADO, TIPO_BAJA, FORMA_LIQUDACION_DEUDA, COMENTARIOS) VALUES (" & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value & "," & Me.dgvProgramaciones.Rows.Item(i).Cells(1).Value & ",'" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'," & Me.dgvProgramaciones.Rows.Item(i).Cells(8).Value & ", 0, 1," & Compañia & ", GETDATE(), 1, 1, '')"
                    'sqlcmd.CommandText = _sub_sql
                    'Result = jClass.ejecutarComandoSql(sqlcmd)
                    '_codigo = Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value.ToString().Trim()
                    ''==================================================================================='

                    sqlcmd.CommandText = Sql
                    Result = jClass.ejecutarComandoSql(sqlcmd)
                    If Me.dgvProgramaciones.Rows.Item(i).Cells(9).Value > 0 Then
                        Sql = "INSERT INTO [dbo].[PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS] "
                        Sql &= "([COD_MV]"
                        Sql &= ",[COD_MF]"
                        Sql &= ",[FEC_VAL_HD]"
                        Sql &= ",[FEC_ACU_HD]"
                        Sql &= ",[UNID_HD]"
                        Sql &= ",[IMPUNI_HD]"
                        Sql &= ",[IMPTOT_HD]"
                        Sql &= ",[Cod_Emp]"
                        Sql &= ") VALUES"
                        Sql &= "(" & Me.dgvProgramaciones.Rows.Item(i).Cells(12).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value
                        Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                        Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(2).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(9).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(9).Value
                        Sql &= ", " & CodEmp
                        Sql &= ")"
                        sqlcmd.CommandText = Sql
                        Result = jClass.ejecutarComandoSql(sqlcmd)
                    End If
                    If Me.dgvProgramaciones.Rows.Item(i).Cells(10).Value > 0 Then
                        Sql = "INSERT INTO [dbo].[PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS] "
                        Sql &= "([COD_MV]"
                        Sql &= ",[COD_MF]"
                        Sql &= ",[FEC_VAL_HD]"
                        Sql &= ",[FEC_ACU_HD]"
                        Sql &= ",[UNID_HD]"
                        Sql &= ",[IMPUNI_HD]"
                        Sql &= ",[IMPTOT_HD]"
                        Sql &= ",[Cod_Emp]"
                        Sql &= ") VALUES"
                        Sql &= "(" & Me.dgvProgramaciones.Rows.Item(i).Cells(13).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(4).Value
                        Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                        Sql &= ", '" & Format(Me.dgvProgramaciones.Rows.Item(i).Cells(16).Value, "dd/MM/yyyy") & "'"
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(2).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(10).Value
                        Sql &= ", " & Me.dgvProgramaciones.Rows.Item(i).Cells(10).Value
                        Sql &= ", " & CodEmp
                        Sql &= ")"
                        sqlcmd.CommandText = Sql
                        Result = jClass.ejecutarComandoSql(sqlcmd)
                    End If
                End If
            Next
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_04 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 1")
            CreaArchivoTexto(Archivo)


            ' Modificado Julio Portillo 02/09/2015
            '==================================================================================='   
            _fecha = Format(Me.dgvProgramaciones.Rows.Item(0).Cells(16).Value, "dd/MM/yyyy")
            If _fecha.Trim.Length > 0 Then
                sqlcmd.CommandText = "EXECUTE dbo.SP_COOPERATIVA_CONTROL_INDEMNIZADOS @COMPAÑIA=" & Compañia & ", @BANDERA=5, @HASTA='" & _fecha & "'"
                jClass.ejecutarComandoSql(sqlcmd)
            Else
                MsgBox("Error en la fecha de envio", MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            jClass.msjError(ex, "Enviar Indemnizados")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Try
            Me.dgvProgramaciones.Columns(0).Width = 50 'Enviada
            Me.dgvProgramaciones.Columns(1).Visible = False 'Compañia
            Me.dgvProgramaciones.Columns(2).Width = 50 'Nº Solicitud
            Me.dgvProgramaciones.Columns(2).Visible = True 'Nº Solicitud
            Me.dgvProgramaciones.Columns(4).Width = 55 'Codigo Buxis
            Me.dgvProgramaciones.Columns(5).Width = 55 'Codigo AS 
            Me.dgvProgramaciones.Columns(7).Width = 60 'Monto
            Me.dgvProgramaciones.Columns(8).Width = 85 'Abono Capital
            Me.dgvProgramaciones.Columns(9).Width = 60 'Abono Intereses
            Me.dgvProgramaciones.Columns(10).Width = 60 'Seguro Deuda
            Me.dgvProgramaciones.Columns(11).Width = 60 'Cuota
            Me.dgvProgramaciones.Columns(12).Width = 50 'Nº Cuotas
            Me.dgvProgramaciones.Columns(12).Visible = True 'Nº Cuotas
            Me.dgvProgramaciones.Columns(13).Width = 70 'Cuota a Descontar
            Me.dgvProgramaciones.Columns(13).Visible = True 'Cuota a Descontar
            Me.dgvProgramaciones.Columns(14).Width = 100 'Periodo
            Me.dgvProgramaciones.Columns(15).Width = 90 'Fecha Inicio Prestamo
            Me.dgvProgramaciones.Columns(16).Width = 90 'Fecha Primer Pago
            Me.dgvProgramaciones.Columns(9).DefaultCellStyle.ForeColor = Color.Blue
            Me.dgvProgramaciones.Columns(7).DefaultCellStyle.ForeColor = Color.Red
            Me.dgvProgramaciones.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvProgramaciones.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.dgvProgramaciones.Columns.Item(7).DefaultCellStyle.Format = "#,##0.00"
            Me.dgvProgramaciones.Columns.Item(8).DefaultCellStyle.Format = "#,##0.00"
            Me.dgvProgramaciones.Columns.Item(9).DefaultCellStyle.Format = "#,##0.00"
            Me.dgvProgramaciones.Columns.Item(10).DefaultCellStyle.Format = "#,##0.00"
            Me.dgvProgramaciones.Columns.Item(11).DefaultCellStyle.Format = "#,##0.00"
            For i As Integer = 1 To Me.dgvProgramaciones.Columns.Count - 1
                Me.dgvProgramaciones.Columns(i).ReadOnly = True
                If i > 16 Then
                    Me.dgvProgramaciones.Columns(i).Visible = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub EnviaSolicitudes()
        Dim NSolicitud As Integer = 0
        Dim totSoli As Integer
        dgvProgramaciones.ReadOnly = True
        For i As Integer = 0 To Me.dgvProgramaciones.Rows.Count - 1
            If Me.dgvProgramaciones.Rows.Item(i).Cells.Item(0).Value Then
                totSoli += 1
            End If
        Next
        If totSoli = 0 Then
            MessageBox.Show("Debe de seleccionar al menos una Programacion ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FijarStatusControl(True)
            Return
        End If
        pbBuxis.Value = 0
        pbBuxis.Maximum = totSoli
        Me.lblEnviando.Visible = True
        Me.lblEnviando.Text = "Enviando..."
        pbBuxis.Visible = True
        If Me.dpFechaPago.Value.Day = 12 Then
            If Me.dpFechaPago.Value.Month = 6 Then
                Archivo = jClass.obtenerEscalar("SELECT CUENTA_01 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 4")
            ElseIf Me.dpFechaPago.Value.Month = 12 Then
                Archivo = jClass.obtenerEscalar("SELECT CUENTA_02 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 4")
            End If
        End If
        If Me.dpFechaPago.Value.Day > 12 Then
            If Me.rbMensual.Checked Then
                Archivo = jClass.obtenerEscalar("SELECT CUENTA_03 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 1")
            ElseIf Me.rbQna.Checked Then
                If Me.dpFechaPago.Value.Day = 15 Then
                    Archivo = jClass.obtenerEscalar("SELECT CUENTA_01 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 1")
                Else
                    Archivo = jClass.obtenerEscalar("SELECT CUENTA_02 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 1")
                End If
            End If
        End If
        '---------------------------
        Dim TablaSolic As DataTable = CType(Me.dgvProgramaciones.DataSource, DataTable)
        Me.bw1.RunWorkerAsync(TablaSolic)
        '----------------------------
        'For i As Integer = 0 To Me.dgvProgramaciones.Rows.Count - 1
        '    If Me.dgvProgramaciones.Rows.Item(i).Cells.Item(0).Value Then
        '        NSolicitud = Me.dgvProgramaciones.Rows.Item(i).Cells.Item(2).Value
        '        MantenimientoSolicitudesBuxis(NSolicitud, 1)
        '        pbBuxis.Value = i + 1
        '    End If
        'Next
        'Me.lblEnviando.Text = "Archivo..."
        'CreaArchivoTexto(Archivo)
        'Me.lblEnviando.Text = "¡Completado!"
        'pbBuxis.Visible = False
        'Me.lblEnviando.Visible = False
        dgvProgramaciones.ReadOnly = False
    End Sub

    Private Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        Dim totalEnviado As Double = 0.0
        Dim totalRegEnviado As Double = 0.0
        Me.lblTotalEnviado.Text = ""
        FijarStatusControl(False)
        MantenimientoSolicitudesBuxis(0, 2)
        If Me.chkIndemnizados.Checked Then
            EnviarIndemnizados()
            BloqueoRetirados()
            MantenimientoSolicitudesBuxis(0, 3)
            totalEnviado = Val(jClass.obtenerEscalar("SELECT ISNULL(SUM(IMPTOT_HD),0) FROM PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS").ToString)
            totalRegEnviado = Val(jClass.obtenerEscalar("SELECT COUNT(IMPTOT_HD) FROM PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS").ToString)
            Me.lblTotalEnviado.Text = "VALOR TOTAL DESCUENTOS ENVIADOS: $ " & Format(totalEnviado, "#,##0.00") & "   TOTAL REGISTROS ENVIADOS: " & Format(totalRegEnviado, "#,##0")
            If totalEnviado > 0 Then
                MessageBox.Show("Las Programaciones seleccionadas ha sido enviadas correctamente.", "¡Completado!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            FijarStatusControl(True)
        Else
            EnviaSolicitudes()
        End If
        'If Me.chkIndemnizados.Checked Then
        '    DeudasIndemnizados()
        'Else
        '    CargaSolicitudes()
        'End If
    End Sub

    Private Sub SetearFechas()
        Dim Fecha As Date = Me.dpFechaPago.Value
        If Me.dpFechaPago.Value.Day <= 15 Then
            Me.dpFechaPago.Value = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Me.dpFechaPago.Value.Day > 15 And Me.dpFechaPago.Value.Day <= Date.DaysInMonth(Me.dpFechaPago.Value.Year, Me.dpFechaPago.Value.Month) Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Me.dpFechaPago.Value = CDate("29/" & (Fecha.Month).ToString.PadLeft(2, "0") & "/" & Fecha.Year.ToString)
                Else
                    Me.dpFechaPago.Value = CDate("28/" & (Fecha.Month).ToString.PadLeft(2, "0") & "/" & Fecha.Year.ToString)
                End If
            Else
                Me.dpFechaPago.Value = CDate("30/" & (Fecha.Month).ToString.PadLeft(2, "0") & "/" & Fecha.Year.ToString)
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaPago.ValueChanged
        If Not Iniciando Then
            If Not (Me.dpFechaPago.Text.Substring(0, 5) = "12/12" Or Me.dpFechaPago.Text.Substring(0, 5) = "12/06") Then
                chkAguin.Checked = False
                chkBoni.Checked = False
                Me.btnCapital.Visible = False
            Else
                If Me.dpFechaPago.Text.Substring(0, 5) = "12/12" Then
                    chkAguin.Checked = True
                ElseIf Me.dpFechaPago.Text.Substring(0, 5) = "12/06" Then
                    chkBoni.Checked = True
                End If
                Me.btnCapital.Visible = True
                End If
                If Me.chkIndemnizados.Checked Then
                    DeudasIndemnizados()
                Else
                    CargaSolicitudes()
                End If
        End If
    End Sub

    Private Sub chkAguin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAguin.CheckedChanged
        If chkAguin.Checked Then
            chkBoni.Checked = False
            If CDate("12/12/" & Year(Now()).ToString) > Now() Then
                Me.dpFechaPago.Value = CDate("12/12/" & Now().Year.ToString)
            Else
                Me.dpFechaPago.Value = CDate("12/12/" & (Now().Year + 1).ToString)
            End If
        End If
        CargaSolicitudes()
    End Sub

    Private Sub chkBoni_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoni.CheckedChanged
        If chkBoni.Checked Then
            chkAguin.Checked = False
            If CDate("12/06/" & Year(Now()).ToString) > Now() Then
                Me.dpFechaPago.Value = CDate("12/06/" & Year(Now()).ToString)
            Else
                Me.dpFechaPago.Value = CDate("12/06/" & (Now().Year + 1).ToString)
            End If
        End If
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

    Private Sub DeudasIndemnizados()
        Dim codigoAs, NombreSocio, Solicitud As String
        Dim codigoBux As Integer
        Dim desde, hasta, Fdesc As Date
        Dim DiasInt, Deduc, TipSol As Integer
        Dim SqlCmd As New SqlCommand
        Dim TablaDeduc As New DataTable("Deduc")
        Dim TablaPorcentajes As New DataTable("Procentajes")
        Dim TablaIndem As New DataTable("Indem")
        Dim tblRep As New DataTable
        'Dim TablaEnviar As New DataTable("Enviar")
        Dim TablaDeducciones As New DataTable("Deducciones")
        Dim Capital, Intereses, SegDeuda As Double
        TablaEnviar = Table.Clone
        'SqlCmd.CommandText = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS] @COMPAÑIA = " & Compañia & ", @FECHA_PERIODO = '" & Me.DateTimePicker1.Value.ToShortDateString & "', @BANDERA = 10"
        'Sql = "SELECT dbo.PadLeft(ISNULL(I.CodigoEmpleadoAS, '0'),'0',6) AS [CODIGO_EMPLEADO_AS], " & vbCrLf
        Sql = "SELECT I.CodigoEmpleadoAS AS [CODIGO_EMPLEADO_AS], " & vbCrLf
        Sql &= "       I.CodigoEmpleado AS [CodigoEmpleado], " & vbCrLf
        Sql &= "       ISNULL((SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = I.CodigoEmpleado), 'EMPLEADO NO EXISTE EN BASE DE DATOS') AS [NOMBRE_COMPLETO]," & vbCrLf
        Sql &= "       I.F_Baja AS [F_Baja], " & vbCrLf
        Sql &= "       I.F_Descuento AS [F_Descuento]" & vbCrLf
        Sql &= "  FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR I " & vbCrLf
        SqlCmd.CommandText = Sql
        TablaIndem = jClass.obtenerDatos(SqlCmd)
        For h As Integer = 0 To TablaIndem.Rows.Count - 1
            codigoAs = TablaIndem.Rows(h).Item(0).ToString().Trim()
            codigoBux = TablaIndem.Rows(h).Item(1)
            NombreSocio = TablaIndem.Rows(h).Item(2)
            hasta = TablaIndem.Rows(h).Item(3)
            Fdesc = TablaIndem.Rows(h).Item(4)
            'desde = Me.UltimoPago(codigoAs, codigoBux)
            'DiasInt = DateDiff(DateInterval.Day, desde, hasta)
            'Para generar la deuda de cafeteria a la fecha en cooperativa
            NoProgCafe(codigoBux)

            SqlCmd.CommandText = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & codigoAs.PadLeft(6, "0") & "',@CodigoBuxis = " & codigoBux & ", @SIUD = 'INTRET'"
            TablaDeduc = jClass.obtenerDatos(SqlCmd)
            If TablaDeduc.Rows.Count > 0 Then
                tblRep = TablaDeduc.Clone
                Deduc = TablaDeduc.Rows(0).Item(3)
                TipSol = TablaDeduc.Rows(0).Item(0)
                Solicitud = TablaDeduc.Rows(0).Item(1)
                Capital = 0
                Intereses = 0
                SegDeuda = 0
                For i As Integer = 0 To TablaDeduc.Rows.Count - 1
                    If Deduc <> TablaDeduc.Rows(i).Item(3) Then
                        Sql = "SELECT CODIGO_DEDUCCION_INTERESES AS INTERES, CODIGO_DEDUCCION_SEGURO_DEUDA AS SEGURO " & vbCrLf
                        Sql &= "FROM dbo.COOPERATIVA_CATALOGO_SOLICITUDES " & vbCrLf
                        Sql &= "WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & TipSol & vbCrLf
                        SqlCmd.CommandText = Sql
                        TablaDeducciones = jClass.obtenerDatos(SqlCmd)
                        TablaEnviar.Rows.Add(False, Deduc, TipSol, NombreSocio, codigoBux, codigoAs.PadLeft(6, "0"), Solicitud, Capital, Capital, Intereses, SegDeuda, (Capital + Intereses + SegDeuda), TablaDeducciones.Rows(0).Item(0), TablaDeducciones.Rows(0).Item(1), "INDEMNIZACION", desde, Fdesc)
                        Deduc = TablaDeduc.Rows(i).Item(3)
                        TipSol = TablaDeduc.Rows(i).Item(0)
                        Solicitud = TablaDeduc.Rows(i).Item(1)
                        Capital = 0
                        Intereses = 0
                        SegDeuda = 0
                    End If
                    If TablaDeduc.Rows(i).Item(6).ToString() = "N" Then
                        desde = TablaDeduc.Rows(i).Item(7)
                    Else
                        desde = TablaDeduc.Rows(i).Item(5)
                    End If
                    DiasInt = DateDiff(DateInterval.Day, desde, Fdesc)
                    ' si los dias son negativos es que no es fecha de descuento, por lo tanto no se generaron intereses
                    If (DiasInt < 0) Then
                        DiasInt = 0
                    Else
                        DiasInt += 1
                    End If
                    Sql = "SELECT CD.INTERES, CDS.INTERES AS SEGURO " & vbCrLf
                    Sql &= "FROM dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD, dbo.COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO CDS " & vbCrLf
                    Sql &= "WHERE CD.COMPAÑIA = CDS.COMPAÑIA " & vbCrLf
                    Sql &= "AND CD.DEDUCCION = CDS.DEDUCCION " & vbCrLf
                    Sql &= "AND CD.COMPAÑIA  = " & Compañia & vbCrLf
                    Sql &= "AND CD.DEDUCCION = " & TablaDeduc.Rows(i).Item(3) & vbCrLf
                    SqlCmd.CommandText = Sql
                    TablaPorcentajes.Reset()
                    TablaPorcentajes = jClass.obtenerDatos(SqlCmd)
                    If TablaPorcentajes.Rows.Count > 0 Then
                        Capital += TablaDeduc.Rows(i).Item(2)
                        Intereses += Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(0) / 100) * DiasInt) / 360), 2)
                        SegDeuda += Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(1) / 100) * DiasInt) / 30), 2)
                        tblRep.Rows.Add(TablaDeduc.Rows(i).Item(0), TablaDeduc.Rows(i).Item(1), TablaDeduc.Rows(i).Item(2), TablaDeduc.Rows(i).Item(3), TablaDeduc.Rows(i).Item(4), TablaDeduc.Rows(i).Item(5), TablaDeduc.Rows(i).Item(6), TablaDeduc.Rows(i).Item(7), Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(0) / 100) * DiasInt) / 360), 2), Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(1) / 100) * DiasInt) / 30), 2))
                    End If
                Next
                Sql = "SELECT CODIGO_DEDUCCION_INTERESES AS INTERES, CODIGO_DEDUCCION_SEGURO_DEUDA AS SEGURO " & vbCrLf
                Sql &= "FROM dbo.COOPERATIVA_CATALOGO_SOLICITUDES " & vbCrLf
                Sql &= "WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = " & TipSol & vbCrLf
                SqlCmd.CommandText = Sql
                TablaDeducciones = jClass.obtenerDatos(SqlCmd)
                TablaEnviar.Rows.Add(False, Deduc, TipSol, NombreSocio, codigoBux, codigoAs.PadLeft(6, "0"), Solicitud, Capital, Capital, Intereses, SegDeuda, (Capital + Intereses + SegDeuda), TablaDeducciones.Rows(0).Item(0), TablaDeducciones.Rows(0).Item(1), "INDEMNIZACION", desde, Fdesc)
                GuardarCalculos(tblRep, codigoBux, Fdesc)
            End If
        Next
        Me.dgvProgramaciones.DataSource = TablaEnviar
        Me.dgvProgramaciones.Columns(2).Visible = False 'Nº Solicitud
        Me.dgvProgramaciones.Columns(12).Visible = False 'Nº Cuotas
        Me.dgvProgramaciones.Columns(13).Visible = False 'Cuota a Descontar
    End Sub

    Private Sub GuardarCalculos(ByVal tblDatos As DataTable, ByVal codigoBux As Integer, ByVal FechaEnvio As Date)
        Sql = "DELETE FROM [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_ENVIADAS] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & codigoBux & " AND FECHA_PROCESO = '" & Format(FechaEnvio, "dd/MM/yyyy") & "'"
        jClass.Ejecutar_ConsultaSQL(Sql)
        For i As Integer = 0 To tblDatos.Rows.Count - 1
            Sql = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_ENVIADAS]" & vbCrLf
            Sql &= "           ([COMPAÑIA]" & vbCrLf
            Sql &= "           ,[NUMERO_SOLICITUD]" & vbCrLf
            Sql &= "           ,[CODIGO_EMPLEADO]" & vbCrLf
            Sql &= "           ,[FECHA_PROCESO]" & vbCrLf
            Sql &= "           ,[FECHA_PAGO]" & vbCrLf
            Sql &= "           ,[FECHA_SOLICITUD]" & vbCrLf
            Sql &= "           ,[CAPITAL]" & vbCrLf
            Sql &= "           ,[INTERES]" & vbCrLf
            Sql &= "           ,[SEG_DEUDA]" & vbCrLf
            Sql &= "           ,[TOTAL_ENVIADO]" & vbCrLf
            Sql &= "           ,[TIPO_CUOTA]" & vbCrLf
            Sql &= "           ,[BUXIS])" & vbCrLf
            Sql &= "    VALUES(" & Compañia & vbCrLf
            Sql &= "           ," & tblDatos.Rows(i).Item("NUMSOL") & vbCrLf
            Sql &= "           ," & codigoBux & vbCrLf
            Sql &= "           ,'" & Format(FechaEnvio, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ,'" & Format(tblDatos.Rows(i).Item("ULTFECPAGO"), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ,'" & Format(tblDatos.Rows(i).Item("FECHASOL"), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ," & tblDatos.Rows(i).Item("DEUDA") & vbCrLf
            Sql &= "           ," & tblDatos.Rows(i).Item("INTERES") & vbCrLf
            Sql &= "           ," & tblDatos.Rows(i).Item("SEGDEUDA") & vbCrLf
            Sql &= "           ," & Format(Val(tblDatos.Rows(i).Item("DEUDA")) + Val(tblDatos.Rows(i).Item("INTERES")) + Val(tblDatos.Rows(i).Item("SEGDEUDA")), "0.00") & vbCrLf
            Sql &= "           ,'" & tblDatos.Rows(i).Item("TIPO_PAGO") & "'" & vbCrLf
            Sql &= "           ,1)" & vbCrLf
            jClass.Ejecutar_ConsultaSQL(Sql)
        Next
    End Sub

    Private Sub chkIndemnizados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndemnizados.CheckedChanged
        If Me.chkIndemnizados.Checked Then
            Me.btnCalculo.Enabled = True
            DeudasIndemnizados()
        Else
            Me.btnCalculo.Enabled = False
            CargaSolicitudes()
        End If
    End Sub

    Private Sub rbQna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna.CheckedChanged
        If Not Iniciando Then
            If rbQna.Checked Then
                Periodo = "QQ"
                CargaSolicitudes()
            End If
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMensual.CheckedChanged
        If Not Iniciando Then
            If rbMensual.Checked Then
                Periodo = "MM"
                CargaSolicitudes()
            End If
        End If
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Me.rbCodEmpleado.Checked Then
            RepCodigoSocio()
        Else
            RepDeduccion()
        End If
    End Sub

    Private Sub RepCodigoSocio()
        Dim sqlCmd As New SqlCommand
        Dim rpt1 As New Descuentos_Enviados_a_Buxis
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt1.Section1.ReportObjects.Item("TextEmpresa")
        txtObj.Text = Descripcion_Compañia
        Sql = "SELECT P.COD_MV AS DEDUCCION, D.DESCRIPCION_DEDUCCION AS [DESCRIPCION DEDUCCION], P.COD_MF AS [CODIGO BUXIS], S.CODIGO_EMPLEADO_AS AS [CODIGO AS], " & vbCrLf
        Sql &= "S.NOMBRE_COMPLETO AS [NOMBRE EMPLEADO], P.IMPTOT_HD AS [VALOR DESCUENTO], CONVERT(VARCHAR,P.FEC_VAL_HD,103) AS [DESDE], CONVERT(VARCHAR,P.FEC_ACU_HD,103) AS [HASTA] " & vbCrLf
        Sql &= "FROM PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS P, COOPERATIVA_CATALOGO_DEDUCCIONES D, COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
        Sql &= "WHERE P.COD_MV = D.DEDUCCION AND P.COD_MF = S.CODIGO_EMPLEADO AND S.COMPAÑIA = " & Compañia & vbCrLf
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        rpt1.SetDataSource(Table)
        If chkResumen.Checked Then
            rpt1.Section3.SectionFormat.EnableSuppress = True
        End If
        rpts.ReportesGenericos(rpt1)
        rpts.ShowDialog()
    End Sub

    Private Sub RepDeduccion()
        Dim sqlCmd As New SqlCommand
        Dim Rpt As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim Encab As String
        If Not Me.chkIndemnizados.Checked Then
            Encab = "DETALLE DE DESCUENTOS PROGRAMADOS ENVIADOS A BUXIS, PLANILLA " & IIf(Periodo = "QQ", "QUINCENAL", "MENSUAL")
            Sql = "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud] as Numero,VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, CONVERT(BIT, 0) AS APLICADO, VS.Deduccion, DA.IMPUNI_HD, DA.JORNALES_HD as LINEA" & vbCrLf
            Sql &= " FROM dbo.PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS DA " & vbCrLf
            Sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, " & vbCrLf
            Sql &= " COOPERATIVA_CATALOGO_SOCIOS S"
            Sql &= " WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis]" ' AND DA.FEC_ACU_HD = '" & dpFechaPago.Value.ToShortDateString & "'"
            'If Not Me.rbTodosPer.Checked Then
            '    Sql &= " AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'"
            'End If
            'If Me.cmbOrigenes.SelectedValue <> 999 Then
            '    Sql &= " AND S.ORIGEN = " & Me.cmbOrigenes.SelectedValue
            'Else
            '    Sql &= " AND S.ORIGEN IN (" & Permitir & ")"
            'End If
        Else
            Encab = "DETALLE DE DEUDAS ENVIADAS A BUXIS PARA PLANILLA INDEMNIZADOS"
            Sql = "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion]," & vbCrLf
            Sql &= "      CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion]," & vbCrLf
            Sql &= "      0 as Numero," & vbCrLf
            Sql &= "      (SELECT DESCRIPCION_SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = CONVERT(INT, DA.UNID_HD)) as Solicitud," & vbCrLf
            Sql &= "      DA.COD_MF AS [Codigo Buxis]," & vbCrLf
            Sql &= "      S.CODIGO_EMPLEADO_AS AS [Codigo AS]," & vbCrLf
            Sql &= "      S.NOMBRE_COMPLETO AS Nombre ," & vbCrLf
            Sql &= "      DA.IMPTOT_HD, " & vbCrLf
            Sql &= "      CONVERT(BIT, 0) AS APLICADO, " & vbCrLf
            Sql &= "      DA.COD_MV AS Deduccion, " & vbCrLf
            Sql &= "      DA.IMPUNI_HD, " & vbCrLf
            Sql &= "      DA.JORNALES_HD as LINEA" & vbCrLf
            Sql &= " FROM dbo.PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS DA " & vbCrLf
            Sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ",  " & vbCrLf
            Sql &= "      COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
            Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO" ' AND DA.FEC_ACU_HD = '" & dpFechaPago.Value.ToShortDateString & "'"
            'If Not Me.rbTodosPer.Checked Then
            '    Sql &= " AND S.PERIODO_PAGO = '" & Periodo & "'" & vbCrLf
            'End If
            'If Me.cmbOrigenes.SelectedValue <> 999 Then
            '    Sql &= " AND S.ORIGEN = " & Me.cmbOrigenes.SelectedValue
            'Else
            '    Sql &= " AND S.ORIGEN IN (" & Permitir & ")"
            'End If
        End If
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        TextObj = Rpt.Section2.ReportObjects.Item("Text13")
        TextObj.Text = Descripcion_Compañia
        TextObj = Rpt.Section2.ReportObjects.Item("Text1")
        TextObj.Text = Encab
        Rpt.Section2.ReportObjects.Item("Text10").ObjectFormat.EnableSuppress = True
        Rpt.Section3.ReportObjects.Item("APLICADO1").ObjectFormat.EnableSuppress = True
        If chkResumen.Checked Then
            Rpt.Section3.SectionFormat.EnableSuppress = True
        End If
        rpts.ReportesGenericos(Rpt)
        'rpts.ReportesGenericos(rpt1)
        rpts.ShowDialog()
    End Sub
    Private Sub FrmEnviarProgramaciones_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub lblIndemnizados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIndemnizados.Click
        Dim TablaDatos As DataTable
        Dim sqlCmd As New SqlCommand
        Dim rpt1 As New Cooperativa_Empleados_A_Indemnizar
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = rpt1.Section1.ReportObjects.Item("TextEmpresa")
        txtObj.Text = Descripcion_Compañia
        'Sql = " SELECT I.CodigoEmpleado AS [COD BUXIS], " & vbCrLf
        'Sql &= "       ISNULL(S.CODIGO_EMPLEADO_AS, '0') AS [COD AS], " & vbCrLf
        'Sql &= "       ISNULL(S.NOMBRE_COMPLETO, 'EMPLEADO NO EXISTE EN BASE DE DATOS') AS [NOMBRE]," & vbCrLf
        'Sql &= "       I.F_Baja AS [FECHA BAJA], " & vbCrLf
        'Sql &= "       I.F_Descuento AS [FECHA DESCUENTO]," & vbCrLf
        'Sql &= "       O.DESCRIPCION_ORIGEN" & vbCrLf
        'Sql &= "  FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR I " & vbCrLf
        'Sql &= "       LEFT JOIN COOPERATIVA_CATALOGO_SOCIOS S ON I.CodigoEmpleado = S.CODIGO_EMPLEADO" & vbCrLf
        'Sql &= "       INNER JOIN COOPERATIVA_CATALOGO_ORIGENES_MAPEO M ON M.Cod_emp = I.Cod_Emp" & vbCrLf
        'Sql &= "       INNER JOIN COOPERATIVA_CATALOGO_ORIGENES O ON O.ORIGEN = M.ORIGEN"
        Sql = "SELECT I.CodigoEmpleado AS [COD BUXIS], "
        Sql &= "       ISNULL(S.CODIGO_EMPLEADO_AS, '0') AS [COD AS], " & vbCrLf
        Sql &= "       ISNULL(S.NOMBRE_COMPLETO, 'EMPLEADO NO EXISTE EN BASE DE DATOS') AS [NOMBRE]," & vbCrLf
        Sql &= "       I.F_Baja AS [FECHA BAJA], " & vbCrLf
        Sql &= "       I.F_Descuento AS [FECHA DESCUENTO]," & vbCrLf
        Sql &= "       ISNULL((SELECT O.DESCRIPCION_ORIGEN " & vbCrLf
        Sql &= "	      FROM COOPERATIVA_CATALOGO_ORIGENES_MAPEO M ," & vbCrLf
        Sql &= "               COOPERATIVA_CATALOGO_ORIGENES O " & vbCrLf
        Sql &= "         WHERE M.Cod_emp = I.Cod_Emp" & vbCrLf
        Sql &= "           AND O.ORIGEN = M.ORIGEN" & vbCrLf
        Sql &= "		   AND I.CodigoEmpleado = S.CODIGO_EMPLEADO" & vbCrLf
        Sql &= "		   AND S.ORIGEN = O.ORIGEN),'AVINSA, S.A. DE C.V.') AS DESCRIPCION_ORIGEN" & vbCrLf
        Sql &= "  FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR I " & vbCrLf
        Sql &= "       LEFT JOIN COOPERATIVA_CATALOGO_SOCIOS S ON I.CodigoEmpleado = S.CODIGO_EMPLEADO"
        sqlCmd.CommandText = Sql
        TablaDatos = jClass.obtenerDatos(sqlCmd)
        rpt1.SetDataSource(TablaDatos)
        rpts.ReportesGenericos(rpt1)
        rpts.ShowDialog()
    End Sub

    Private Function EnviarBuxis(ByVal TablaSol As DataTable) As Integer
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim NSolicitud, NLinea As Integer
        Dim Comando_Track As SqlCommand
        Dim FechaPeriodo As String = ""
        Dim i As Integer = 0
        For i = 0 To TablaSol.Rows.Count - 1
            If TablaSol.Rows(i).Item(0) Then
                NSolicitud = TablaSol.Rows(i).Item(2)
                NLinea = TablaSol.Rows(i).Item(13)
                Try
                    If chkAguin.Checked Then
                        FechaPeriodo = "12/12/" & Now.Year.ToString
                    ElseIf chkBoni.Checked Then
                        FechaPeriodo = "12/06/" & Now.Year.ToString
                    Else
                        FechaPeriodo = Me.dpFechaPago.Value.ToShortDateString
                    End If
                    Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS @COMPAÑIA = " & Compañia & ", @FECHA_PERIODO = '" & FechaPeriodo & "', @NUM_SOLICITUD = " & NSolicitud & ", @BANDERA = 1, @CODBUXIS = " & NLinea
                    Comando_Track = New SqlCommand(Sql)
                    jClass.ejecutarComandoSql(Comando_Track)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
                bw1.ReportProgress(i + 1)
            End If
        Next
        poneTexto("Generando Archivo de Texto: " & Archivo)
        CreaArchivoTexto(Archivo)
        Return i
    End Function

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        e.Result = EnviarBuxis(e.Argument)
    End Sub

    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        Me.pbBuxis.Value = e.ProgressPercentage
    End Sub

    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        MantenimientoSolicitudesBuxis(0, 3)
        Dim totalEnviado As Double = Val(jClass.obtenerEscalar("SELECT ISNULL(SUM(IMPTOT_HD),0) FROM PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS").ToString)
        Dim totalRegEnviado As Double = Val(jClass.obtenerEscalar("SELECT COUNT(IMPTOT_HD) FROM PLANILLA_DESCUENTOS_TRASLADO_A_BUXIS").ToString)
        Me.lblEnviando.Text = ""
        pbBuxis.Visible = False
        Me.lblTotalEnviado.Text = "VALOR TOTAL DESCUENTOS ENVIADOS: $ " & Format(totalEnviado, "#,##0.00") & "   TOTAL REGISTROS ENVIADOS: " & Format(totalRegEnviado, "#,##0")
        If totalEnviado > 0 Then
            MessageBox.Show("Las Programaciones seleccionadas ha sido enviadas correctamente.", "¡Completado!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.lblEnviando.Visible = False
        FijarStatusControl(True)
    End Sub

    Private Sub FijarStatusControl(ByVal Activado As Boolean)
        Me.dpFechaPago.Enabled = Activado
        Me.chkAguin.Enabled = Activado
        Me.chkBoni.Enabled = Activado
        Me.rbMensual.Enabled = Activado
        Me.rbQna.Enabled = Activado
        Me.chkIndemnizados.Enabled = Activado
        Me.chkResumen.Enabled = Activado
        Me.BtnEnviar.Enabled = Activado
        Me.btnVer.Enabled = Activado
        Me.SelectAll.Enabled = Activado
        Me.dgvProgramaciones.Enabled = Activado
    End Sub

    Private Function NoProgCafe(ByVal CodBuxis As String) As Boolean
        Dim FPro As New Facturacion_Procesos
        Dim numSoli As Integer = 0
        Dim Table As DataTable
        Dim sqlCmd As New SqlClient.SqlCommand
        Dim Plantas02 As String
        Dim TipSoliP1, TipSoliP2 As Integer
        Plantas02 = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 16").ToString().Trim
        TipSoliP1 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
        TipSoliP2 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
        'SELECCIONA TODOS LOS TICKETS QUE HA CONSUMIDO EL EMPLEADO DESDE EL ULTIMO ENVIO A BUXIS
        '*****************************************************************************************************
        sqlCmd.CommandText = "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP1 & " AS TIPOSOLI, CONVERT(DATE, '" & Format(SeteaFecha(Now().AddDays(5)), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA NOT IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS" & vbCrLf
        sqlCmd.CommandText &= "UNION" & vbCrLf
        sqlCmd.CommandText &= "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP2 & " AS TIPOSOLI, CONVERT(DATE, '" & Format(SeteaFecha(Now().AddDays(5)), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS"
        'CARGA LOS DATOS EN TABLE
        '*****************************************************************************************************
        Table = jClass.obtenerDatos(sqlCmd)
        'SE GENERAN LAS SOLICITUDES POR CONSUMO DE CAFETERIA PLANTA 1 Y 2
        '*****************************************************************************************************
        If Table.Rows.Count > 0 Then
            For i As Integer = 0 To Table.Rows.Count - 1
                numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
                FPro.SolicitudesFacturacionSocios(Compañia, Table.Rows(i).Item("TIPOSOLI"), numSoli, Table.Rows(i).Item("CODIGO_EMPLEADO_AS"), Table.Rows(i).Item("CODIGO_EMPLEADO"), Now(), 1, Table.Rows(i).Item("MONTO_TOTAL"), 0, 0, "QQ", 1, Table.Rows(i).Item("FECHA_PAGO"), "Consumo en Cafeteria", 0, 0)
                'SE ACTUALIZA EL CAMPO ENVIADO PARA LOS TICKETS PROCESADOS
                '*******************************************************************************************************
                sqlCmd.CommandText = "UPDATE CAFETERIA_FACTURACION_ENCABEZADO SET ENVIADO = 1, N_SOLICITUD = " & numSoli
                sqlCmd.CommandText &= " WHERE COMPAÑIA = " & Compañia & " AND"
                sqlCmd.CommandText &= "	      FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
                If TipSoliP1 = Table.Rows(i).Item("TIPOSOLI") Then
                    sqlCmd.CommandText &= "	      BODEGA NOT IN (" & Plantas02 & ") AND"
                Else
                    sqlCmd.CommandText &= "	      BODEGA IN (" & Plantas02 & ") AND"
                End If
                sqlCmd.CommandText &= "	   	  CODIGO_EMPLEADO = " & CodBuxis & " AND"
                sqlCmd.CommandText &= "	   	  ANULADO = 0 AND"
                sqlCmd.CommandText &= "	   	  ENVIADO = 0 AND"
                sqlCmd.CommandText &= "	   	  FORMA_PAGO = 2 AND"
                sqlCmd.CommandText &= "	   	  CODIGO_EMPLEADO > 0"
                jClass.ejecutarComandoSql(sqlCmd)
            Next
        End If
    End Function

    Private Function SeteaFecha(ByVal FechaEvaluada As Date) As Date
        Dim Fecha As Date = FechaEvaluada
        If FechaEvaluada.Day <= 15 Then
            FechaEvaluada = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf FechaEvaluada.Day > 15 And FechaEvaluada.Day <= Date.DaysInMonth(FechaEvaluada.Year, FechaEvaluada.Month) Then
            If FechaEvaluada.Month = 2 Then
                If FechaEvaluada.Year Mod 4 = 0 Then
                    FechaEvaluada = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    FechaEvaluada = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                FechaEvaluada = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        End If
        Return FechaEvaluada
    End Function

    Private Sub BloqueoRetirados()
        Dim result As Integer
        Dim sqlcmd As New SqlCommand
        Dim tblIndem As DataTable
        Sql = "SELECT CodigoEmpleado, CodigoEmpleadoAS, F_Baja, F_Descuento, Cod_Emp FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR"
        sqlcmd.CommandText = Sql
        tblIndem = jClass.obtenerDatos(sqlcmd)
        For i As Integer = 0 To tblIndem.Rows.Count - 1
            sqlcmd.CommandText = "UPDATE COOPERATIVA_CATALOGO_SOCIOS SET BLOQUEADO = 1, BLOQUEO_MANUAL = 1, MOTIVO_BLOQUEO = 'RETIRO DE LA EMPRESA EL " & Format(tblIndem.Rows(i).Item("F_Baja"), "dd/MM/yyyy") & "' WHERE CODIGO_EMPLEADO = " & tblIndem.Rows(i).Item("CodigoEmpleado") & " AND COMPAÑIA = " & Compañia
            result = jClass.ejecutarComandoSql(sqlcmd)
            sqlcmd.CommandText = "UPDATE CAFETERIA_EMPLEADOS_DESCUENTOS SET BLOQUEADOS = 1 WHERE CODIGO_EMPLEADO = " & tblIndem.Rows(i).Item("CodigoEmpleado") & " AND COMPAÑIA = " & Compañia
            result = jClass.ejecutarComandoSql(sqlcmd)
            'Req.00000095
            jClass.ejecutarComandoSql(New SqlCommand("UPDATE COOPERATIVA_CATALOGO_SOCIOS SET RETIRADO = 1 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & tblIndem.Rows(i).Item("CodigoEmpleado")))
        Next
    End Sub

    Private Sub btnCapital_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapital.Click
        'Req.00000091
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New Cooperativa_Capital_No_Enviado_Periodo_Especial
        rpt.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE Coo.sp_COOPERATIVA_DEUDA @COMPAÑIA = " & Compañia & ", @FECHA_PAGO = '" & Format(Me.dpFechaPago.Value, "dd/MM/yyyy") & "', @BANDERA = 1")))
        frmVer.crvReporte.ReportSource = rpt
        frmVer.ShowDialog()
        frmVer.Dispose()
    End Sub

    Private Sub btnCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculo.Click
        Dim rpt1 As New Cooperativa_calculo_intereses_retiros
        Dim frmVer As New frmReportes_Ver
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject

        txtObj = rpt1.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt1.Section2.ReportObjects.Item("txtFProceso")
        txtObj.Text = "FECHA DE PROCESO: " & Format(Now, "dd/MM/yyyy")

        Sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO_IUD]" & vbCrLf
        Sql &= " @COMPAÑIA           = " & Compañia & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO    = NULL" & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO_AS = NULL" & vbCrLf
        Sql &= ",@PRESTAMO           = 0" & vbCrLf
        Sql &= ",@INTERES            = 0" & vbCrLf
        Sql &= ",@MONTO_PRESTAMO     = 0" & vbCrLf
        Sql &= ",@FECHA_INICIO       = '" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ",@DEDUCCION          = 0" & vbCrLf
        Sql &= ",@ANULADO            = 1 " & vbCrLf
        Sql &= ",@USUARIO            = '" & Usuario & "'" & vbCrLf
        Sql &= ",@IUD                = 'R'"
        rpt1.SetDataSource(jClass.obtenerDatos(New SqlCommand(Sql)))
        frmVer.crvReporte.ReportSource = rpt1
        frmVer.ShowDialog()
    End Sub
End Class