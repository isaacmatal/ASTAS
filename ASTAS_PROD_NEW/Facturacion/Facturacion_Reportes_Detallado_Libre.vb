Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlClient

Public Class Facturacion_Reportes_Detallado_Libre

    Dim multi As New multiUsos
    Dim jClass As New jarsClass
    Dim Iniciando As Boolean
    Dim Detallado As Boolean = False
    Dim Anulados As Integer
    Dim FormaPago As Integer = 0

    Private Sub Facturacion_Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        multi.CargaBodegaSeguridadUsuario(Compañia, Me.cmbBodega)
        multi.CargaTipoDocumentoFact(Compañia, Me.cmbTipDoc)
        multi.CargaOrigenes(Compañia, Me.cmbORIGEN)
        Me.cmbTipDoc.SelectedIndex = 0
        Me.cmbBodega.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
        Iniciando = False
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        CargaRPT()
    End Sub

    Private Sub CargaRPT()
        If Not Iniciando Then
            Try
                Me.CrystalReportViewer1.ReportSource = Nothing
                Dim report As New Facturacion_Facturas_Detalle_Productos
                Dim sqlcom As New SqlCommand
                Dim table As DataTable
                Dim Sql As String
                Dim TextORIGEN As CrystalDecisions.CrystalReports.Engine.TextObject
                Sql = "EXECUTE sp_FACTURACION_FACTURAS_DETALLE_RPT "
                Sql &= "@COMPAÑIA = " & Compañia
                Sql &= ", @BODEGA = " & Me.cmbBodega.SelectedValue
                Sql &= ", @FECHA_DESDE = '" & Format(Me.DateTimePicker1.Value, "Short Date") & "'"
                Sql &= ", @FECHA_HASTA = '" & Format(Me.DateTimePicker2.Value, "Short Date") & "'"
                Sql &= ", @ANULADA = " & Anulados
                Sql &= ", @TIPO_DOCUMENTO = " & Me.cmbTipDoc.SelectedValue
                If Me.chkFiltro.Checked Then
                    If Me.cmbORIGEN.SelectedValue > 0 Then
                        Sql &= ", @ORIGEN = " & Me.cmbORIGEN.SelectedValue
                    End If
                End If
                If FormaPago > 0 Then
                    Sql &= ", @FORMA_PAGO = " & FormaPago
                End If
                sqlcom.CommandText = Sql
                table = jClass.obtenerDatos(sqlcom)
                report.SetDataSource(table)
                TextORIGEN = report.Section2.ReportObjects.Item("ORIGEN")
                'TextORIGEN.Text = Me.cmbORIGEN.Text.ToUpper
                If table.Rows.Count = 0 Then
                    MsgBox("No hay Datos para los parametros establecidos", MsgBoxStyle.Information, "Reportes")
                Else
                    Me.CrystalReportViewer1.ReportSource = report
                End If
            Catch ex As Exception
                jClass.msjError(ex, "Reporte Facturación")
            End Try
        End If
    End Sub

    Private Sub chkFiltro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltro.CheckedChanged
        Me.cmbORIGEN.Enabled = Me.chkFiltro.Checked
        If Not Me.chkFiltro.Checked Then
            Me.cmbORIGEN.SelectedValue = 0
        End If
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
End Class