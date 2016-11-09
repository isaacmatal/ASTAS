Imports System.Data
Imports System.Data.SqlClient

Public Class frmCooperativaImprimirCheques
    Dim Sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim jClass As New jarsClass

    Private Sub frmCooperativaImprimirCheques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        jClass.CargaBancos2(Compañia, Me.cmbBancos)
        Me.cmbBancos.SelectedIndex = 1
        jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 5, Me.cmbCuentaBancaria)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = False
    End Sub

    Private Sub frmCooperativaImprimirCheques_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub imprimirCheque()
        Dim DT01 As DataTable
        Dim sqlCmd As New SqlCommand
        Dim ImpCheque As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
        Sql = "SELECT CHEQUE, (TOTAL - PAPELERIA) AS VALOR, FECHA_CONTABLE, A_NOMBRE_DE,TOTAL_LETRAS_L1, TOTAL_LETRAS_L2 " & vbCrLf
        Sql &= "  FROM [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES]" & vbCrLf
        Sql &= " WHERE COMPAÑIA = " & Compañia & " AND BANCO = " & Me.cmbBancos.SelectedValue & " AND CUENTA_BANCARIA = '" & Me.cmbCuentaBancaria.SelectedValue & "' AND CHEQUE = " & Me.txtCheque.Text
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            Dim textObj As CrystalDecisions.CrystalReports.Engine.TextObject = ImpCheque.Section2.ReportObjects.Item("txtNoNeg")
            ImpCheque.Section2.ReportObjects.Item("txtNoNeg").ObjectFormat.EnableSuppress = Not Me.chkNoNeg.Checked
            Sql = "EXECUTE sp_CONTABILIDAD_EMITIR_CHEQUE "
            Sql &= Val(Me.txtCheque.Text)
            Sql &= ", '" & Table.Rows(0).Item("A_NOMBRE_DE") & "'"
            Sql &= ", " & Table.Rows(0).Item("VALOR")
            Sql &= ", '" & Table.Rows(0).Item("TOTAL_LETRAS_L1") & " " & Table.Rows(0).Item("TOTAL_LETRAS_L2") & "'"
            Sql &= ", " & IIf(Me.chkNoNeg.Checked, "1", "0")
            sqlCmd.CommandText = Sql
            DT01 = jClass.obtenerDatos(sqlCmd)
            ImpCheque.SetDataSource(DT01)
            ImpCheque.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            'ImpCheque.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopeB6
            Me.CrystalReportViewer1.ReportSource = ImpCheque
            'ImpCheque.PrintToPrinter(1, False, 1, 1)
        Else
            MsgBox("No se encontró el cheque buscado", MsgBoxStyle.Information, "Búsqueda")
        End If
    End Sub

    Private Sub cmbBancos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedIndexChanged
        If Iniciando = False Then
            jClass.CargaCuentasBancarias(Compañia, Me.cmbBancos.SelectedValue, 5, Me.cmbCuentaBancaria)
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        imprimirCheque()
    End Sub
End Class