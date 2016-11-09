Imports System.Data
Imports System.Data.SqlClient

Public Class FrmProgramacionEspecial
    Public Compañia_Value As Integer
    Public Num_Solicitud As Integer
    Public Monto_value As Integer
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim TCapital, TInteres, TSegDeuda As Double
    Dim NumCuotasA As Integer
    Dim jClass As New jarsClass
    Dim Rpts As New FrmCooperativaReportes
    Dim TablaProgs As New DataTable
    Dim DescAgui, DescBoni As Double

    Private Sub FrmProgramacionEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.DtpFechaPago.Value = Now()
        Me.DtpFechaIniPres.Value = Now()
        Me.DtpFechaPrimerPag.Value = Now()
        TxtNumSolicitud.Text = Num_Solicitud
        Iniciando = True
        Deducciones()
        CargaPeriodos()
        MuestraSolicitud()
        CargaInteres()
        Me.DtpFechaPago.Value = FechaInicial()
        Me.DtpFechaPrimerPag.Value = Me.DtpFechaIniPres.Value
        CrearTabla()
        Me.DgvProgramacionesEspeciales.DataSource = TablaProgs
        LimpiaGrid()
        Iniciando = False
        If DescAgui > 0 Then
            Me.TxtCuotaEspecial.Text = Format(DescAgui, "0.00")
        End If
    End Sub

    Private Sub Deducciones()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        'Conexion = New SqlConnection("Server=" & Servidor & ";Database=" & BaseDatos & ";User Id=" & UsuarioDB & ";Password=" & PasswordDB & ";Connect Timeout=60")
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @DEDUCCION = 0," & vbCrLf
            Sql &= " @BANDERA = 3"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            Me.CbxDeduccion.DataSource = Table
            Me.CbxDeduccion.ValueMember = "Deducción"
            Me.CbxDeduccion.DisplayMember = "Descripción Deducción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaInteres()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_DEDUCCIONES" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Sql &= " @DEDUCCION = " & CbxDeduccion.SelectedValue & "," & vbCrLf
            Sql &= " @BANDERA = 2"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            LblInteres.Text = Table.Rows(0).Item(2)
            Me.LblSegDeuda.Text = Table.Rows(0).Item(3)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub CrearTabla()
        TablaProgs.Columns.Add("COMPAÑIA", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("N_SOLICITUD", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Nº", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Deduccion", Type.GetType("System.Int32"))
        TablaProgs.Columns.Add("Fecha Pago", Type.GetType("System.DateTime"))
        TablaProgs.Columns.Add("Saldo Inicial", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Capital", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Interes", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Seguro Deuda", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Cuota", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Saldo Final", Type.GetType("System.Double"))
        TablaProgs.Columns.Add("Interes Acumulado", Type.GetType("System.Double"))
    End Sub

    Private Sub CargaPeriodos()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_PERIODOS_PROGRAMACION" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            CbxPeriodo.DataSource = Table
            CbxPeriodo.ValueMember = "PERIODO"
            CbxPeriodo.DisplayMember = "DESCRIPCION_PERIODO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub MuestraSolicitud()
        Dim Comando_Track As SqlCommand
        Dim Table As DataTable
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_TODAS_LAS_SOLICITUDES_APROBADA"
            Sql &= " @COMPAÑIA = " & Compañia & ","
            Sql &= " @T_SOLICITUD = 0,"
            Sql &= " @N_SOLICITUD = " & Val(Trim(TxtNumSolicitud.Text)) & ","
            Sql &= " @FECHA_INI = 0,"
            Sql &= " @FECHA_FIN = 0,"
            Sql &= " @BANDERA = 5"
            Comando_Track = New SqlCommand(Sql)
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                Me.CbxDeduccion.SelectedValue = Table.Rows(0).Item("DEDUCCION")
                Me.TxtCodigoAs.Text = Table.Rows(0).Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
                Me.TxtNombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.TxtDivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                Me.TxtDepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                Me.TxtSección.Text = Table.Rows(0).Item("DESCRIPCION_SECCION")
                Me.TxtMonto.Text = Format(Table.Rows(0).Item("VALOR_VALE"), ".00")
                Me.CbxPeriodo.SelectedValue = Table.Rows(0).Item("PERIODO")
                Me.LblInteres.Text = Format(Table.Rows(0).Item("INTERES"), ".00")
                DescAgui = Format(Table.Rows(0).Item("DESCUENTO_AGUINALDO"), ".00")
                DescBoni = Format(Table.Rows(0).Item("DESCUENTO_BONIFICACION"), ".00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Total_CuotaEspecial()
        TxtTotalCuotasEspeciales.Text = 0
    End Sub
    Private Sub LimpiaGrid()
        Me.DgvProgramacionesEspeciales.Columns(0).Visible = False
        Me.DgvProgramacionesEspeciales.Columns(1).Visible = False
        Me.DgvProgramacionesEspeciales.Columns(3).Visible = False
        Me.DgvProgramacionesEspeciales.Columns(2).Width = 45
        Me.DgvProgramacionesEspeciales.Columns(4).Width = 100
        Me.DgvProgramacionesEspeciales.Columns(5).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(6).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(7).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(8).Width = 65
        Me.DgvProgramacionesEspeciales.Columns(9).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(10).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(11).Width = 80
        Me.DgvProgramacionesEspeciales.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvProgramacionesEspeciales.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvProgramacionesEspeciales.Columns(5).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(6).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(7).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(8).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(9).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(10).DefaultCellStyle.Format = "###,##0.00"
        Me.DgvProgramacionesEspeciales.Columns(11).DefaultCellStyle.Format = "###,##0.00"
    End Sub

    Private Sub MantenimientoProgramacionEncabezado()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO_IU " & Compañia & "," _
            & CInt(Me.TxtNumSolicitud.Text) & "," & CbxDeduccion.SelectedValue & "," & Me.DgvProgramacionesEspeciales.Rows.Count & "," & Me.DgvProgramacionesEspeciales.Rows(0).Cells("Cuota").Value & "," & _
            Monto_value & ",'" & CbxPeriodo.SelectedValue & "','" & Format(DtpFechaIniPres.Value, "dd/MM/yyyy") & "','" & Format(Me.DgvProgramacionesEspeciales.Rows(0).Cells("Fecha Pago").Value, "dd/MM/yyyy") & "'," _
            & LblInteres.Text & "," & LblSegDeuda.Text & ",'" & Usuario & "'," & 1
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Comando_Track.ExecuteNonQuery()
            Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROGRAMADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.TxtNumSolicitud.Text
            Comando_Track.CommandText = Sql
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MantenimientoProgramacionDetalle()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            For Each row As DataRow In Me.TablaProgs.Rows
                Sql = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]"
                Sql &= "([COMPAÑIA]"
                Sql &= ",[NUMERO_SOLICITUD]"
                Sql &= ",[LINEA]"
                Sql &= ",[ENVIADA]"
                Sql &= ",[RECIBIDA]"
                Sql &= ",[FECHA_PAGO]"
                Sql &= ",[SALDO_INI]"
                Sql &= ",[CAPITAL]"
                Sql &= ",[CAPITAL_D]"
                Sql &= ",[INTERES]"
                Sql &= ",[INTERES_D]"
                Sql &= ",[SEG_DEUDA]"
                Sql &= ",[SEG_DEUDA_D]"
                Sql &= ",[CUOTA]"
                Sql &= ",[CUOTA_D]"
                Sql &= ",[SALDO_FIN]"
                Sql &= ",[INTERES_ACUM]"
                Sql &= ",[REPROGRAMADA]"
                Sql &= ",[CUOTA_NO_DESCONTADA]"
                Sql &= ",[USUARIO_CREACION]"
                Sql &= ",[USUARIO_CREACION_FECHA]"
                Sql &= ",[USUARIO_EDICION]"
                Sql &= ",[USUARIO_EDICION_FECHA])"
                Sql &= "VALUES"
                Sql &= "(" & Compañia
                Sql &= "," & row.Item("N_SOLICITUD")
                Sql &= "," & row.Item(2)
                Sql &= ",0"
                Sql &= ",0"
                Sql &= ",'" & Format(row.Item("Fecha Pago"), "dd/MM/yyyy") & "'"
                Sql &= "," & row.Item("Saldo Inicial")
                Sql &= "," & row.Item("Capital")
                Sql &= ",0"
                Sql &= "," & row.Item("Interes")
                Sql &= ",0"
                Sql &= "," & row.Item("Seguro Deuda")
                Sql &= ",0"
                Sql &= "," & row.Item("Cuota")
                Sql &= ",0"
                Sql &= "," & row.Item("Saldo Final")
                Sql &= "," & row.Item("Interes Acumulado")
                Sql &= ",0"
                Sql &= ",0"
                Sql &= ",'" & Usuario & "'"
                Sql &= ",GETDATE()"
                Sql &= ",'" & Usuario & "'"
                Sql &= ",GETDATE())"
                Comando_Track = New SqlCommand(Sql, Conexion_Track)
                Comando_Track.ExecuteNonQuery()
            Next
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.DgvProgramacionesEspeciales.Rows.Count <> 0 Then
            Dim Localizacion As String = TxtDivision.Text.Trim + " - " + TxtSección.Text.Trim + " - " + TxtDepartamento.Text.Trim
            Rpts.ProgramacionSolicitudes(Compañia, Compañia, Val(TxtNumSolicitud.Text), CbxDeduccion.Text, TxtNombre.Text, TxtCodigoAs.Text, TxtCodigoBuxis.Text, Localizacion, 0, CDbl(TxtMonto.Text), CbxPeriodo.Text, DtpFechaIniPres.Value, DtpFechaPrimerPag.Value, CDbl(LblInteres.Text), CDbl(LblSegDeuda.Text), 3)
            Rpts.ShowDialog()
            Return
        End If
        MsgBox("¡Debe Calcular la programación o debe de guardarla!", MsgBoxStyle.Critical, "Validación")
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If DgvProgramacionesEspeciales.Rows.Count <> 0 And Val(Me.TxtTotalCuotasEspeciales.Text) = Val(Me.TxtMonto.Text) Then
            If MsgBox("¿Está seguro(a) que desea Guardar la programación de la solicitud: " & TxtNumSolicitud.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ADVERTENCIA") = MsgBoxResult.Yes Then
                MantenimientoProgramacionEncabezado()
                MantenimientoProgramacionDetalle()
                Me.BtnGuardar.Enabled = False
                Me.btnImprimir.Enabled = True
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
            End If
        Else
            MsgBox("¡No puede guardar la programación, favor verificar Datos!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub TxtCuotaEspecial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuotaEspecial.KeyPress
        Dim cadena As String = TxtCuotaEspecial.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ("."c)) Or (e.KeyChar = ("."c) And Ocurrencias <> 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim Suma As Double = Val(Me.TxtCuotaEspecial.Text) + (Val(Me.TxtTotalCuotasEspeciales.Text))
        Try
            Select Case Me.DtpFechaPago.Value.Month
                Case 2
                    Select Case Me.DtpFechaPago.Value.Day
                        Case 15
                        Case 28
                            If Me.DtpFechaPago.Value.Year Mod 4 = 0 Then
                                MsgBox("Fecha de pago no válida" & vbCrLf & "Fechas válidas son 15/02/" & Me.DtpFechaPago.Value.Year & " ó 29/02/" & Me.DtpFechaPago.Value.Year, MsgBoxStyle.Information, "RESTRICCIÓN")
                                Return
                            End If
                        Case 29
                        Case Else
                            MsgBox("Fecha de pago no válida" & vbCrLf & "Fechas válidas son 15/02/" & Me.DtpFechaPago.Value.Year & " ó " & IIf(Me.DtpFechaPago.Value.Year Mod 4 = 0, "29/02/", "28/02/") & Me.DtpFechaPago.Value.Year, MsgBoxStyle.Information, "RESTRICCIÓN")
                            Return
                    End Select
                Case 6
                    Select Case Me.DtpFechaPago.Value.Day
                        Case 12
                        Case 15, 30
                        Case Else
                            MsgBox("Fecha de pago no válida" & vbCrLf & "Días válidos son 12, 15 ó 30", MsgBoxStyle.Information, "RESTRICCIÓN")
                            Return
                    End Select
                Case 1, 3, 4, 5, 7, 8, 9, 10, 11
                    Select Case Me.DtpFechaPago.Value.Day
                        Case 15, 30
                        Case Else
                            MsgBox("Fecha de pago no válida" & vbCrLf & "Días válidos son 15 ó 30", MsgBoxStyle.Information, "RESTRICCIÓN")
                            Return
                    End Select
                Case 12
                    Select Case Me.DtpFechaPago.Value.Day
                        Case 12
                        Case 15, 30
                        Case Else
                            MsgBox("Fecha de pago no válida" & vbCrLf & "Días válidos son 12, 15 ó 30", MsgBoxStyle.Information, "RESTRICCIÓN")
                            Return
                    End Select
                Case Else
            End Select
            If Val(Me.TxtCuotaEspecial.Text) <= 0 Or Me.TxtCuotaEspecial.Text = Nothing Then
                MessageBox.Show("Monto de la cuota especial no es válido", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCuotaEspecial.Focus()
                Return
            End If
            If TablaProgs.Select("[Fecha Pago] = '" & Format(Me.DtpFechaPago.Value, "dd/MM/yyyy") & "'").Length > 0 Then
                MsgBox("Ya se ha programado la fecha " & Format(Me.DtpFechaPago.Value, "dd/MM/yyyy"), MsgBoxStyle.Information, "RESTRICCIÓN")
                Return
            End If
            If Suma > CDbl(Val(Me.TxtMonto.Text)) Then
                MessageBox.Show("Monto de cuotas excede al monto de la solicitud", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCuotaEspecial.Focus()
                Return
            End If
            If Me.DtpFechaIniPres.Value.Date > Me.DtpFechaPago.Value.Date Then
                MessageBox.Show("La fecha inicial del préstamo no puede ser  mayor que la fecha de pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtpFechaIniPres.Focus()
                Return
            End If
            If Me.DtpFechaPago.Value.Date < Now.Date Then
                MessageBox.Show("La fecha de pago no puede ser menor que la fecha actual", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtpFechaPago.Focus()
                Return
            End If
            Me.TablaProgs.Rows.Add(0, 0, 0, 0, Me.DtpFechaPago.Value.Date, 0, Val(Me.TxtCuotaEspecial.Text), 0, 0, 0, 0, 0)
            calcIntereses()
            Me.DtpFechaIniPres.Enabled = False
        Catch ex As Exception
            jClass.msjError(ex, "Programaciones Preferenciales")
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim Suma As Double
        Dim Valor As Double
        If DgvProgramacionesEspeciales.RowCount <> 0 Then
            Valor = DgvProgramacionesEspeciales.CurrentRow.Cells("Capital").Value
            Suma = Val(Me.TxtTotalCuotasEspeciales.Text) - Valor
            Me.TxtTotalCuotasEspeciales.Text = Suma
            TablaProgs.Rows.RemoveAt(DgvProgramacionesEspeciales.CurrentRow.Index)
            If TablaProgs.Rows.Count = 0 Then
                Me.DtpFechaIniPres.Enabled = True
            Else
                calcIntereses()
            End If
        Else
            MessageBox.Show("¡¡Tiene que seleccionar la cuota que desea eliminar!! ", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DtpFechaPrimerPag_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaPrimerPag.Leave
        If Me.DtpFechaIniPres.Value.Date > DtpFechaPrimerPag.Value.Date Then
            MessageBox.Show("La fecha inicial del préstamo no puede ser mayor que la fecha del primer pago", "RESTRICCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DtpFechaIniPres.Focus()
        End If
    End Sub

    Private Sub TbpNormales_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub FrmProgramacionEspecial_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TbpEspeciales_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TbpEspeciales.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Function FechaInicial() As Date
        Dim Fecha As Date = Now().Date
        If Fecha.Day <= 11 Then
            Return CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 11 And Fecha.Day <= 27 And Fecha.Day <> 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Return CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Return CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Return CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        ElseIf Fecha.Day > 27 And Fecha.Day <= 31 Then
            Return CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString).AddMonths(1)
        End If
    End Function

    Private Sub DtpFechaIniPres_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaIniPres.ValueChanged
        Me.DtpFechaPrimerPag.Value = Me.DtpFechaIniPres.Value
    End Sub

    Private Sub calcIntereses()
        If Me.TablaProgs.Rows.Count = 0 Then
            Return
        End If
        Dim Cuota, Interes, SegDeuda As Double
        Dim Capital As Double = Val(Me.TxtMonto.Text)
        Dim IntAcum As Double = 0
        Dim Linea As Integer = 0
        Dim DiasInt As Integer = 0
        Dim MyTable As New DataTable
        Dim MyRows As DataRow() = Me.TablaProgs.Select("[Capital] > 0", "[Fecha Pago] ASC")
        Dim FechaPagoAnt As Date = Me.DtpFechaIniPres.Value.Date
        MyTable = Me.TablaProgs.Clone
        For i As Integer = 0 To MyRows.Length - 1
            MyTable.ImportRow(MyRows(i))
        Next
        While Me.TablaProgs.Rows.Count > 0
            Me.TablaProgs.Rows.RemoveAt(0)
        End While
        Try
            For Each row As DataRow In MyTable.Rows
                Linea += 1
                If Val(Me.LblInteres.Text) > 0 Then
                    DiasInt = DateDiff(DateInterval.Day, FechaPagoAnt, row.Item("Fecha Pago"))
                    Interes = Math.Round((Capital * (Val(Me.LblInteres.Text) / 100) * DiasInt) / 360, 2, MidpointRounding.AwayFromZero)
                    SegDeuda = Math.Round((Capital * (Val(Me.LblSegDeuda.Text) / 100) * DiasInt) / 30, 2, MidpointRounding.AwayFromZero)
                    IntAcum += Interes
                End If
                Cuota = Val(row.Item("Capital")) + Interes + SegDeuda
                Me.TablaProgs.Rows.Add(Compañia, Me.TxtNumSolicitud.Text, Linea, Me.CbxDeduccion.SelectedValue, row.Item("Fecha Pago"), Capital, _
                row.Item("Capital"), Interes, SegDeuda, Cuota, Capital - row.Item("Capital"), IntAcum)
                Capital -= row.Item("Capital")
                FechaPagoAnt = row.Item("Fecha Pago")
            Next
            Me.DtpFechaPrimerPag.Value = FechaPagoAnt
            Me.TxtTotalCuotasEspeciales.Text = Val(Me.TxtMonto.Text) - Capital
        Catch ex As Exception
            jClass.msjError(ex, "Programaciones Preferenciales - calcIntereses")
        End Try
    End Sub
End Class