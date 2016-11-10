Imports System.Data.SqlClient

Public Class Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas

    'Constructor
    Dim jclass As New jarsClass
    'Variables
    Dim sql As String = ""
    Dim Table As DataTable
    'Instancia Reportes
    Dim Rpt1 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_FCF_MH
    Dim Rpt2 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_CCF_MH
    Dim Rpt3 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_FCF_EC
    Dim Rpt4 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_CCF_EC
    Dim Rpt5 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_FCF_ECS
    Dim Rpt6 As New Contabilidad_CuentasxCobrar_Facturacion_LibrosVtas_CCF_ECS

    Private Sub Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        CargaTipoDocumento()
        llenarBodegas()
        asignarFechas()
    End Sub

    Private Sub llenarBodegas()
        Dim SqlCmd As SqlCommand
        sql = "Exec sp_INVENTARIOS_CATALOGO_BODEGAS 7, " & Compañia & ", 0, '" & Usuario & "'"
        SqlCmd = New SqlCommand(sql)
        Table = jclass.obtenerDatos(SqlCmd)
        Me.dgvBodegas.DataSource = Table
    End Sub

    Private Sub CargaTipoDocumento()
        Dim Table As DataTable
        Try
            sql = "SELECT TIPO_DOCUMENTO, IDENTIFICADOR + ' - ' + DESCRIPCION_TIPO_DOCUMENTO AS DESCRIPCION_TIPO_DOCUMENTO FROM FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPAÑIA = " & Compañia
            Table = jclass.obtenerDatos(New SqlCommand(sql))
            Me.cmbTIPO_DOCUMENTO.DataSource = Table
            Me.cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Asigna las fechas respectivas al servidor
    Private Sub asignarFechas()
        Me.dpFECHA_DESDE.Value = Now.AddDays(-Now.Day).AddDays(1)
        Me.dpFECHA_HASTA.Value = Now.AddMonths(1).AddDays(-Now.AddMonths(1).Day)
    End Sub

    'Metodo del boton para mostrar los reportes
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim LibroVtasCCF As Boolean = False
        Dim txtObj, txtBod As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim Bodegas As String = String.Empty
        Dim DescBodegas As String = String.Empty
        Try
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
                LibroVtasCCF = True
            End If
            For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
                If Me.dgvBodegas.Rows(i).Cells(0).Value Then
                    Bodegas &= IIf(Bodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(2).Value
                    DescBodegas &= IIf(DescBodegas.Length = 0, "", ",") & Me.dgvBodegas.Rows(i).Cells(3).Value
                End If
            Next
            If Bodegas.Length > 0 Then
                sql = "EXECUTE sp_FACTURACION_GENERADA_LIBROS_VENTAS_IVA " & vbCrLf
                sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
                sql &= ",@TIPO_DOCUMENTO   = " & Me.cmbTIPO_DOCUMENTO.SelectedValue & vbCrLf
                sql &= ",@RESUMEN          = " & IIf(Me.chkImprimirResumen.Checked, "1", "0") & vbCrLf
                sql &= ",@FECHA_DESDE      = '" & Format(Me.dpFECHA_DESDE.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= ",@FECHA_HASTA      = '" & Format(Me.dpFECHA_HASTA.Value, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= ",@BODEGA_REPORTE   = '" & Bodegas & "'" & vbCrLf
                sql &= ",@BANDERA          = 0" & vbCrLf
                Table = jclass.obtenerDatos(New SqlCommand(sql))
                txtBod = Rpt2.Section2.ReportObjects.Item("txtBodegas")
                If Table.Rows.Count > 0 Then
                    If Me.chkSimple.CheckState = 0 And Me.chkExtraContable.CheckState = 0 And (Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Or Me.cmbTIPO_DOCUMENTO.SelectedValue = 5) Then
                        Rpt1.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt1
                        txtBod = Rpt1.Section2.ReportObjects.Item("txtBodegas")
                    ElseIf Me.chkSimple.CheckState = 0 And Me.chkExtraContable.CheckState = 0 And Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
                        Rpt2.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt2
                        txtBod = Rpt2.Section2.ReportObjects.Item("txtBodegas")
                    ElseIf Me.chkSimple.CheckState = 0 And Me.chkExtraContable.CheckState = 1 And (Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Or Me.cmbTIPO_DOCUMENTO.SelectedValue = 5) Then
                        Rpt3.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt3
                        txtBod = Rpt3.Section2.ReportObjects.Item("txtBodegas")
                    ElseIf Me.chkSimple.CheckState = 0 And Me.chkExtraContable.CheckState = 1 And Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
                        Rpt4.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt4
                        txtBod = Rpt4.Section2.ReportObjects.Item("txtBodegas")
                    ElseIf Me.chkSimple.CheckState = 1 And Me.chkExtraContable.CheckState = 0 And (Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Or Me.cmbTIPO_DOCUMENTO.SelectedValue = 5) Then
                        Rpt5.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt5
                        txtBod = Rpt5.Section2.ReportObjects.Item("txtBodegas")
                    ElseIf Me.chkSimple.CheckState = 1 And Me.chkExtraContable.CheckState = 0 And Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
                        Rpt6.SetDataSource(Table)
                        crvReporte.ReportSource = Rpt6
                        txtBod = Rpt6.Section2.ReportObjects.Item("txtBodegas")
                    End If
                    If LibroVtasCCF Then
                        txtObj = Rpt2.Section2.ReportObjects.Item("txtNIT")
                        txtObj.Text = "NIT : " & jclass.obtenerEscalar("SELECT NIT FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = " & Compañia).ToString()
                    End If
                    If Me.Chk_Todas_Bodegas.Checked Then
                        txtBod.ObjectFormat.EnableSuppress = True
                    Else
                        txtBod.Text = DescBodegas
                    End If
                Else
                    txtBod.ObjectFormat.EnableSuppress = False
                    crvReporte.ReportSource = Nothing
                    MsgBox("¡No se encuentran registros de ventas para los datos seleccionados!", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                MsgBox("Debe seleccionar al menos una bodega para procesar.", MsgBoxStyle.Information, "PROCESO CANCELADO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub Chk_Todas_Bodegas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Todas_Bodegas.CheckedChanged
        For i As Integer = 0 To Me.dgvBodegas.Rows.Count - 1
            Me.dgvBodegas.Rows(i).Cells(0).Value = Me.Chk_Todas_Bodegas.Checked
        Next
    End Sub

    Private Sub Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class