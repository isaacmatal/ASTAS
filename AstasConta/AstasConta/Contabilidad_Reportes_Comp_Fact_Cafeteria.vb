Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Comp_Fact_Cafeteria
    Dim jClass As New jarsClass
    Dim Iniciando As Boolean = True
    Dim fechaIni, fechaFin As String

    Private Sub Contabilidad_Reportes_Comp_Fact_Cafeteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        jClass.CargarCombo(Me.cmbPeriodoPago, "SELECT CONVERT(VARCHAR(10),[PERIODO_FACTURACION_INICIO],103)+'*'+CONVERT(VARCHAR(10),[PERIODO_FACTURACION_FINAL],103) AS FECHAS, CONVERT(VARCHAR(10),[PERIODO_PAGO],103) AS PERIODO_PAGO FROM CAFETERIA_FACTURACION_PERIODOS_DE_COBRO WHERE COMPAÑIA = " & Compañia & " ORDER BY CAFETERIA_FACTURACION_PERIODOS_DE_COBRO.PERIODO_PAGO DESC", "FECHAS", "PERIODO_PAGO")
        Iniciando = False
        cmbPeriodoPago_SelectedIndexChanged(New Object, New System.EventArgs)
    End Sub

    Private Sub cmbPeriodoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriodoPago.SelectedIndexChanged
        Dim Cadena As String
        If Not Iniciando Then
            Cadena = Me.cmbPeriodoPago.SelectedValue
            fechaIni = Cadena.Substring(0, Cadena.IndexOf("*"))
            fechaFin = Cadena.Substring(Cadena.IndexOf("*") + 1)
            Me.dpFECHA_DESDE.Value = Date.Parse(fechaIni)
            Me.dpFECHA_HASTA.Value = Date.Parse(fechaFin)
        End If
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim Rpt As New Contabilidad_Reportes_Comp_Fact_Cafeteria_rpt
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim table As DataTable
        Dim sqlCmd As New SqlCommand
        Try
            sqlCmd.CommandText = "EXECUTE [dbo].[sp_CONTABILIDAD_REPORTE_COMP_FACT_CAFETERIA] @COMPAÑIA = " & Compañia & vbCrLf 'GeneraSQLCargos()
            sqlCmd.CommandText &= ", @FECHA_INICIO = '" & fechaIni & "'" & vbCrLf
            sqlCmd.CommandText &= ", @FECHA_FINAL = '" & fechaFin & "'" & vbCrLf
            sqlCmd.CommandText &= ", @FECHA_PAGO = '" & Me.cmbPeriodoPago.Text & "'" & vbCrLf
            sqlCmd.CommandText &= ", @SOLODIF = " & IIf(Me.chkDif.Checked, 1, 0) & vbCrLf
            sqlCmd.CommandText &= ", @BANDERA = " & IIf(Me.rbCargos.Checked, 1, 2) & vbCrLf
            table = jClass.obtenerDatos(sqlCmd)
            If table.Rows.Count > 0 Then
                Rpt.SetDataSource(table)
                txtObj = Rpt.Section2.ReportObjects.Item("txtEmpresa")
                txtObj.Text = Descripcion_Compañia
                txtObj = Rpt.Section2.ReportObjects.Item("txtTitulo")
                If Me.rbCargos.Checked Then
                    txtObj.Text = "REPORTE COMPARATIVO DE CARGOS PARA DESCUENTOS QUINCENALES (CONTABILIDAD vrs ERP)"
                Else
                    txtObj.Text = "REPORTE COMPARATIVO DE ABONOS PARA DESCUENTOS QUINCENALES (CONTABILIDAD vrs BUXIS)"
                    txtObj = Rpt.Section2.ReportObjects.Item("txtEncab1")
                    txtObj.Text = "ABONOS POR DESCTOS.SEGÚN CONTABILIDAD"
                    txtObj = Rpt.Section2.ReportObjects.Item("txtEncab2")
                    txtObj.Text = "ABONOS POR DESCTOS. SEGÚN BUXIS"
                End If
                txtObj = Rpt.Section2.ReportObjects.Item("txtPeriodo")
                txtObj.Text = "FECHA DE CORTE:   DEL " & Me.dpFECHA_DESDE.Text.ToUpper() & "    AL " & Me.dpFECHA_HASTA.Text.ToUpper()
                txtObj = Rpt.Section5.ReportObjects.Item("txtUsuario")
                txtObj.Text = "USUARIO: " & Usuario
                Me.crvReporte.ReportSource = Rpt
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
                Me.crvReporte.ReportSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub Contabilidad_Reportes_Comp_Fact_Cafeteria_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class