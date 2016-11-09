Imports System.Data
Imports System.Data.SqlClient

Public Class frmCooperativaReporteReciboRetiros
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim Table, TableAho As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub frmCooperativaReporteReciboRetiros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        Iniciando = False
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Me.btnBuscar.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Sql = "SELECT R.RETIRO AS CORRELATIVO, R.CODIGO_EMPLEADO AS [COD BUXIS], "
        Sql &= "       R.CODIGO_EMPLEADO_AS AS [COD AS], S.NOMBRE_COMPLETO AS [NOMBRE], R.CANTIDAD, R.USUARIO_CREACION_FECHA AS FECHA, R.RETIRO_ASOCIACION, CONVERT(BIT, CUENTA_CONTABLE_BANCO) AS [RETIRO EMPRESA]"
        Sql &= "  FROM [dbo].[COOPERATIVA_SOCIO_RETIROS] R, COOPERATIVA_CATALOGO_SOCIOS S"
        Sql &= " WHERE R.COMPAÑIA = S.COMPAÑIA"
        Sql &= "   AND R.CODIGO_EMPLEADO = S.CODIGO_EMPLEADO "
        Sql &= "   AND R.CODIGO_EMPLEADO_AS = S.CODIGO_EMPLEADO_AS"
        Sql &= "   AND R.COMPAÑIA = " & Compañia
        Sql &= "   AND R.ESTADO = 3"
        Sql &= "   AND CONVERT(DATE,R.USUARIO_CREACION_FECHA) BETWEEN CONVERT(DATE,'" & Format(Me.dpDesde.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATE,'" & Format(Me.dpHasta.Value, "dd/MM/yyyy") & "',103)"
        Sql &= "   AND S.ORIGEN IN (" & Permitir & ")"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.dgvRetiros.DataSource = Table
        GridStyle()
    End Sub

    'Private Sub dgvRetiros_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiros.CellClick
    'End Sub

    Private Sub Reporte(ByVal IdRetiro As Integer, ByVal RetAsoc As Boolean, ByVal RetEmp As Boolean, ByVal SoloVer As Boolean)
        Dim codAs As String
        Dim deudas As Double
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        'ParamcodigoAs = Me.dgvRetiros.Rows(e.RowIndex).Cells("COD AS").Value
        'ParamcodigoBux = Me.dgvRetiros.Rows(e.RowIndex).Cells("COD BUXIS").Value
        'IdRetiro = Me.dgvRetiros.Rows(e.RowIndex).Cells("CORRELATIVO").Value
        Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "' AND CODIGO_EMPLEADO = " & ParamcodigoBux)
        If RetAsoc Then
            Dim RptAsoc As New rpt_reporte_retiro_asociacion
            deudas = jClass.obtenerEscalar("SELECT TOTAL_DEUDAS + TOTAL_INTERESES + TOTAL_SEGURO_DEUDA AS DEUDA_PAGADA FROM COOPERATIVA_SOCIO_RETIROS WHERE COMPAÑIA = " & Compañia & " AND RETIRO = " & IdRetiro)
            Sql = "SELECT COMPAÑIA, NOMBRE_COMPAÑIA, NIT, CODIGO_EMPLEADO [Cod Buxis], CODIGO_EMPLEADO_AS [Cod AS], NOMBRE_COMPLETO," & vbCrLf
            Sql &= "Retiro, (Escolaridad - ISR + AHORRO_O + AHORRO_OE - " & Format(deudas, "0.00") & ") as Monto, AHORRO_O, AHORRO_OE , Escolaridad, ISR, (AHORRO_O + AHORRO_OE) [Ahorro Total]," & vbCrLf
            Sql &= "CANTIDAD_LETRAS, NIT_SOCIO,DUI," & Format(deudas, "0.00") & " AS TOTAL_DEUDAS" & vbCrLf
            Sql &= "FROM VISTA_COOPERATIVA_RETIRO_ASOCIACION" & vbCrLf
            Sql &= "WHERE COMPAÑIA= " & Compañia & " AND" & vbCrLf
            Sql &= "CODIGO_EMPLEADO=" & ParamcodigoBux & " AND" & vbCrLf
            Sql &= "CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "' AND" & vbCrLf
            Sql &= "RETIRO=" & IdRetiro
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            RptAsoc.SetDataSource(Table)
            '---------------------------------------------------------
            Dim TableDeudas As DataTable
            Sql = "SELECT D.DEDUCCION AS TIPO_SOLI, D.DESCRIPCION_DEDUCCION AS [DESCRIPCION DEDUCCION], E.MONTO_PRESTAMO AS DEUDA, E.PRESTAMO AS Deduccion" & vbCrLf
            Sql &= "FROM [dbo].[COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO] E, COOPERATIVA_CATALOGO_DEDUCCIONES D" & vbCrLf
            Sql &= "WHERE E.COMPAÑIA = D.COMPAÑIA" & vbCrLf
            Sql &= "  AND E.PRESTAMO = D.DEDUCCION" & vbCrLf
            Sql &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "  AND E.DEDUCCION = " & IdRetiro & vbCrLf
            Sql &= "  AND E.CODIGO_EMPLEADO = " & ParamcodigoBux & vbCrLf
            Sql &= "  AND E.CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "'"
            sqlCmd.CommandText = Sql '"EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & ParamcodigoAs & "'," & ParamcodigoBux & ",'TDXSOLI'"
            TableDeudas = jClass.obtenerDatos(sqlCmd)
            RptAsoc.Subreports.Item(0).SetDataSource(TableDeudas)
            If TableDeudas.Rows.Count > 0 Then
                RptAsoc.Subreports.Item(0).ReportDefinition.Sections.Item("ReportHeaderSection1").SectionFormat.EnableSuppress = False
                RptAsoc.Subreports.Item(0).ReportDefinition.Sections.Item("ReportHeaderSection2").SectionFormat.EnableSuppress = False
                RptAsoc.Subreports.Item(0).ReportDefinition.Sections.Item("DetailSection1").SectionFormat.EnableSuppress = False
                RptAsoc.Subreports.Item(0).ReportDefinition.Sections.Item("ReportFooterSection1").SectionFormat.EnableSuppress = False
            End If
            'txtObj = RptAsoc.Section3.ReportObjects.Item("txtDUI")
            'txtObj.Text = jClass.obtenerEscalar("SELECT DUI FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & ParamcodigoBux & " AND CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "' AND COMPAÑIA = " & Compañia).ToString
            'Sql = "SELECT CUENTA_CONTABLE_BANCO FROM COOPERATIVA_SOCIO_RETIROS WHERE RETIRO = " & IdRetiro & "' AND COMPAÑIA = " & Compañia
            'codBuxis = CInt(jClass.obtenerEscalar(Sql).ToString)
            txtObj = RptAsoc.Section3.ReportObjects.Item("txtEncab")
            txtObj.Text = "LIQUIDACION POR RETIRO DE LA " & IIf(RetEmp, "EMPRESA", "ASOCIACION")
            Sql = "SELECT COMENTARIO FROM COOPERATIVA_SOCIO_RETIROS WHERE RETIRO = " & IdRetiro & " AND COMPAÑIA = " & Compañia
            codAs = jClass.obtenerEscalar(Sql).ToString
            txtObj = RptAsoc.Section3.ReportObjects.Item("txtMotivo")
            txtObj.Text = "Motivo Retiro: " & codAs
            '---------------------------------------------------------
            If Origen = 5 Or Origen = 6 Then
                RptAsoc.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                RptAsoc.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                RptAsoc.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                RptAsoc.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                txtObj = RptAsoc.Section3.ReportObjects.Item("Text2")
                txtObj.Text = "NIT 0501-200694-101-6"
            End If
            If SoloVer Then
                Me.crvRecibo.ReportSource = RptAsoc
            Else
                RptAsoc.PrintToPrinter(1, False, 1, 1000)
            End If
        Else
            Dim RptAhorro As New rpt_reporte_cooperativa_retiro_ahorro_recibo1
            Sql = "SELECT * FROM VISTA_COOPERATIVA_SOCIOS_RETIROS_CARTAS_CHEQUES" & vbCrLf
            Sql &= " WHERE COMPAÑIA=" & Compañia & " AND RETIRO = " & IdRetiro
            sqlCmd.CommandText = Sql
            TableAho = jClass.obtenerDatos(sqlCmd)
            RptAhorro.SetDataSource(TableAho)
            If Origen = 5 Or Origen = 6 Then
                RptAhorro.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                RptAhorro.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                RptAhorro.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                RptAhorro.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                txtObj = RptAhorro.Section3.ReportObjects.Item("Text22")
                txtObj.Text = "NIT 0501-200694-101-6"
                'RptAhorro.Section3.ReportObjects.Item("Text2").ObjectFormat.EnableSuppress = False
            End If
            If SoloVer Then
                Me.crvRecibo.ReportSource = RptAhorro
            Else
                RptAhorro.PrintToPrinter(1, False, 1, 1000)
            End If
        End If
    End Sub
    Private Sub GridStyle()
        Me.dgvRetiros.Columns(1).HeaderText = "No."
        Me.dgvRetiros.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(1).Width = 50
        Me.dgvRetiros.Columns(1).ReadOnly = True
        Me.dgvRetiros.Columns(2).HeaderText = "Cód. Buxis"
        Me.dgvRetiros.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(2).Width = 50
        Me.dgvRetiros.Columns(2).ReadOnly = True
        Me.dgvRetiros.Columns(3).HeaderText = "Cód. AS"
        Me.dgvRetiros.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(3).Width = 50
        Me.dgvRetiros.Columns(3).ReadOnly = True
        Me.dgvRetiros.Columns(4).HeaderText = "Nombre"
        Me.dgvRetiros.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.dgvRetiros.Columns(4).Width = 250
        Me.dgvRetiros.Columns(5).HeaderText = "Valor Retiro"
        Me.dgvRetiros.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvRetiros.Columns(5).DefaultCellStyle.Format = "#,###.00"
        Me.dgvRetiros.Columns(5).Width = 80
        Me.dgvRetiros.Columns(5).ReadOnly = True
        Me.dgvRetiros.Columns(6).HeaderText = "Fecha Retiro"
        Me.dgvRetiros.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(6).Width = 80
        Me.dgvRetiros.Columns(7).HeaderText = "Retiro Asoc."
        Me.dgvRetiros.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(7).Width = 40
        Me.dgvRetiros.Columns(7).ReadOnly = True
        Me.dgvRetiros.Columns(8).HeaderText = "Retiro Empresa"
        Me.dgvRetiros.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvRetiros.Columns(8).Width = 50
        'Me.dgvCuentasEquivalentes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub frmCooperativaReporteReciboRetiros_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub chkSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelec.CheckedChanged
        For i As Integer = 0 To Me.dgvRetiros.Rows.Count - 1
            Me.dgvRetiros.Rows(i).Cells(0).Value = Me.chkSelec.Checked
        Next
    End Sub

    Private Sub dgvRetiros_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiros.CellContentClick
        If e.RowIndex > -1 Then
            ParamcodigoAs = Me.dgvRetiros.Rows(e.RowIndex).Cells("COD AS").Value
            ParamcodigoBux = Me.dgvRetiros.Rows(e.RowIndex).Cells("COD BUXIS").Value
            Reporte(Me.dgvRetiros.Rows(e.RowIndex).Cells("CORRELATIVO").Value, _
                    Me.dgvRetiros.Rows(e.RowIndex).Cells("RETIRO_ASOCIACION").Value, _
                    Me.dgvRetiros.Rows(e.RowIndex).Cells("RETIRO EMPRESA").Value, _
                    True)
        End If
    End Sub

    Private Sub btnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImp.Click
        For i As Integer = 0 To Me.dgvRetiros.Rows.Count - 1
            If Me.dgvRetiros.Rows(i).Cells("imprimir").Value Then
                ParamcodigoAs = Me.dgvRetiros.Rows(i).Cells("COD AS").Value
                ParamcodigoBux = Me.dgvRetiros.Rows(i).Cells("COD BUXIS").Value
                Reporte(Me.dgvRetiros.Rows(i).Cells("CORRELATIVO").Value, _
                        Me.dgvRetiros.Rows(i).Cells("RETIRO_ASOCIACION").Value, _
                        Me.dgvRetiros.Rows(i).Cells("RETIRO EMPRESA").Value, _
                        False)
            End If
        Next
    End Sub
End Class