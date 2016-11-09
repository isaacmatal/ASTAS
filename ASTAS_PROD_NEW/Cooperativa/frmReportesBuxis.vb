Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReportesBuxis

    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Iniciando As Boolean = True
    Dim Periodo As String = "QQ"
    Dim Sql As String
    Dim Table As DataTable
    Dim TableReporte As New DataTable("noaplicados")

    Private Sub frmReportesBuxis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DateTimePicker1.Value = SeteaFecha(Now.AddDays(-15.0))
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        cargaOrigen()
        Iniciando = False
        CargaBuxis()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaBuxis()
    End Sub

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

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim frmVer As New frmReportes_Ver
        Dim Rpt As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Try
            TextObj = Rpt.Section2.ReportObjects.Item("Text13")
            TextObj.Text = Descripcion_Compañia
            TextObj = Rpt.Section2.ReportObjects.Item("Text1")
            TextObj.Text = "DESCUENTOS " & IIf(Me.rbtAplic.Checked, "APLICADOS", IIf(Me.rbtNoAplic.Checked, "NO APLICADOS", "")) & " EN PLANILLA " & IIf(Periodo = "QQ", "QUINCENAL", "MENSUAL") & " (" & Me.cmbOrigenes.Text & ")"
            Rpt.SetDataSource(TableReporte)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
        frmVer.ReportesGenericos(Rpt)
        frmVer.ShowDialog()
        frmVer.Dispose()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Not Iniciando Then
            Me.dgvNoAplicados.Columns.Clear()
            CargaBuxis()
        End If
    End Sub

    Private Sub CargaBuxis()
        Try
            'Sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS] "
            'Sql &= "@COMPAÑIA = " & Compañia & ", "
            'Sql &= "@FECHA_PERIODO = '" & DateTimePicker1.Value.ToShortDateString & "', "
            'Sql &= "@NUM_SOLICITUD = 0, "
            'Sql &= "@BANDERA = 4, "
            'Sql &= "@PERIODO_PAGO = '" & Periodo & "'"
            If DateTimePicker1.Value.Day = 15 Or DateTimePicker1.Value.Day = 30 Or (DateTimePicker1.Value.Day = 28 And DateTimePicker1.Value.Month = 2) Or (DateTimePicker1.Value.Day = 29 And DateTimePicker1.Value.Month = 2) Or (DateTimePicker1.Value.Day = 12 And DateTimePicker1.Value.Month = 6) Or (DateTimePicker1.Value.Day = 12 And DateTimePicker1.Value.Month = 12) Then
                Sql = "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion],CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion],VS.[N° Solicitud],VS.Solicitud,VS.[Codigo Buxis],VS.[Codigo AS],VS.Nombre ,DA.IMPTOT_HD, DA.APLICADO, VS.Deduccion, DA.IMPUNI_HD, DA.JORNALES_HD as LINEA" & vbCrLf
                Sql &= " FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA " & vbCrLf
                Sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ", dbo.VISTA_COOPERATIVA_TODAS_SOLICITUDES VS, " & vbCrLf
                Sql &= " COOPERATIVA_CATALOGO_SOCIOS S"
                Sql &= " WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND DA.UNID_HD = VS.[N° Solicitud] AND DA.COD_MF = VS.[Codigo Buxis] AND DA.FEC_ACU_HD = '" & DateTimePicker1.Value.ToShortDateString & "'"
                If Not Me.rbTodosPer.Checked Then
                    Sql &= " AND VS.PERIODO_PAGO_EMPLEADO = '" & Periodo & "'"
                End If
                If Me.cmbOrigenes.SelectedValue <> 999 Then
                    Sql &= " AND S.ORIGEN = " & Me.cmbOrigenes.SelectedValue
                Else
                    Sql &= " AND S.ORIGEN IN (" & Permitir & ")"
                End If
            Else
                Sql = "SELECT DISTINCT DA.FEC_ACU_HD AS [Periodo Descuento],DA.COD_MV as [Codigo Deduccion]," & vbCrLf
                Sql &= "      CD.DESCRIPCION_DEDUCCION as [Descripcion Deduccion]," & vbCrLf
                Sql &= "      0 as Numero," & vbCrLf
                Sql &= "      (SELECT DESCRIPCION_SOLICITUD FROM COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD = CONVERT(INT, DA.UNID_HD)) as Solicitud," & vbCrLf
                Sql &= "      DA.COD_MF AS [Codigo Buxis]," & vbCrLf
                Sql &= "      S.CODIGO_EMPLEADO_AS AS [Codigo AS]," & vbCrLf
                Sql &= "      S.NOMBRE_COMPLETO AS Nombre ," & vbCrLf
                Sql &= "      DA.IMPTOT_HD, " & vbCrLf
                Sql &= "      DA.APLICADO, " & vbCrLf
                Sql &= "      DA.COD_MV AS Deduccion, " & vbCrLf
                Sql &= "      DA.IMPUNI_HD, " & vbCrLf
                Sql &= "      DA.JORNALES_HD as LINEA" & vbCrLf
                Sql &= " FROM dbo.PLANILLA_DESCUENTOS_APLICADOS DA " & vbCrLf
                Sql &= " LEFT JOIN dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD ON DA.COD_MV = CD.DEDUCCION AND CD.COMPAÑIA = " & Compañia & ",  " & vbCrLf
                Sql &= "      COOPERATIVA_CATALOGO_SOCIOS S " & vbCrLf
                Sql &= "WHERE DA.COD_MF = S.CODIGO_EMPLEADO AND DA.FEC_ACU_HD = '" & DateTimePicker1.Value.ToShortDateString & "'"
                If Not Me.rbTodosPer.Checked Then
                    Sql &= " AND S.PERIODO_PAGO = '" & Periodo & "'" & vbCrLf
                End If
                If Me.cmbOrigenes.SelectedValue <> 999 Then
                    Sql &= " AND S.ORIGEN = " & Me.cmbOrigenes.SelectedValue
                Else
                    Sql &= " AND S.ORIGEN IN (" & Permitir & ")"
                End If
            End If
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            TableReporte.Reset()
            TableReporte = Table.Clone()
            For Each row As DataRow In Table.Rows
                TableReporte.ImportRow(row)
            Next
            LlenarGrid(Table)
            If Not Me.rbtTodos.Checked Then
                Iniciando = True
                Me.rbtTodos.Checked = True
                Iniciando = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
        End Try
    End Sub

    Private Sub rbtTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTodos.CheckedChanged
        If Not Iniciando Then
            If rbtTodos.Checked Then
                TableReporte.Reset()
                TableReporte = Table.Clone()
                For Each row As DataRow In Table.Rows
                    TableReporte.ImportRow(row)
                Next
                LlenarGrid(TableReporte)
            End If
        End If
    End Sub

    Private Sub rbtAplic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAplic.CheckedChanged
        If Not Iniciando Then
            If rbtAplic.Checked Then
                TableReporte.Reset()
                TableReporte = Table.Clone()
                For Each row As DataRow In Table.Rows
                    If row.Item(9) Then
                        TableReporte.ImportRow(row)
                    End If
                Next
                LlenarGrid(TableReporte)
            End If
        End If
    End Sub

    Private Sub rbtNoAplic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAplic.CheckedChanged
        If Not Iniciando Then
            If rbtNoAplic.Checked Then
                TableReporte.Reset()
                TableReporte = Table.Clone()
                For Each row As DataRow In Table.Rows
                    If Not row.Item(9) Then
                        TableReporte.ImportRow(row)
                    End If
                Next
                LlenarGrid(TableReporte)
            End If
        End If
    End Sub

    Private Sub LlenarGrid(ByVal TableGrid As DataTable)
        Me.dgvNoAplicados.Columns.Clear()
        Me.dgvNoAplicados.DataSource = TableGrid
        Try
            If Me.dgvNoAplicados.Columns.Count > 0 Then
                Me.dgvNoAplicados.Columns(3).HeaderText = "Nº Solicitud"
                Me.dgvNoAplicados.Columns(8).HeaderText = "Valor Descuento"
                Me.dgvNoAplicados.Columns(9).HeaderText = "Aplicado"
                Me.dgvNoAplicados.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.dgvNoAplicados.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                Me.dgvNoAplicados.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.dgvNoAplicados.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.dgvNoAplicados.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dgvNoAplicados.Columns(10).Visible = False
                Me.dgvNoAplicados.Columns(11).Visible = False
                Me.dgvNoAplicados.Columns(12).Visible = False
                Me.dgvNoAplicados.Columns(0).Width = 80
                Me.dgvNoAplicados.Columns(1).Width = 70
                Me.dgvNoAplicados.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Me.dgvNoAplicados.Columns(3).Width = 70
                Me.dgvNoAplicados.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Me.dgvNoAplicados.Columns(5).Width = 60
                Me.dgvNoAplicados.Columns(6).Width = 60
                Me.dgvNoAplicados.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Me.dgvNoAplicados.Columns(8).Width = 80
                Me.dgvNoAplicados.Columns(8).DefaultCellStyle.Format = "$ #,##0.00"
                Me.dgvNoAplicados.Columns(9).Width = 50
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
        End Try
    End Sub

    Private Sub cargaOrigen()
        Dim Table As DataTable
        Dim Comando_Track As SqlCommand
        Sql = "SELECT 999 AS ORIGEN, 'TODAS LAS EMPRESAS' AS DESCRIPCION_ORIGEN UNION SELECT ORIGEN, DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES WHERE ORIGEN IN (" & Permitir & ") AND COMPAÑIA = " & Compañia
        Comando_Track = New SqlCommand(Sql)
        Table = jClass.obtenerDatos(Comando_Track)
        Me.cmbOrigenes.DataSource = Table
        Me.cmbOrigenes.ValueMember = "ORIGEN"
        Me.cmbOrigenes.DisplayMember = "DESCRIPCION_ORIGEN"
        Me.cmbOrigenes.SelectedValue = 999
    End Sub

    Private Sub rbQna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna.CheckedChanged
        If Not Iniciando Then
            If rbQna.Checked Then
                Periodo = "QQ"
                CargaBuxis()
            End If
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMensual.CheckedChanged
        If Not Iniciando Then
            If rbMensual.Checked Then
                Periodo = "MM"
                CargaBuxis()
            End If
        End If
    End Sub

    Private Sub rbTodosPer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodosPer.CheckedChanged
        If Not Iniciando Then
            If rbTodosPer.Checked Then
                Periodo = "TT"
                CargaBuxis()
            End If
        End If
    End Sub

    Private Sub cmbOrigenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrigenes.SelectedIndexChanged
        If Not Iniciando Then
            CargaBuxis()
        End If
    End Sub

    Private Sub frmReportesBuxis_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class