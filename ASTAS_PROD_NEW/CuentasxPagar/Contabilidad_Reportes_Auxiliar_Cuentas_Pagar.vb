Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Auxiliar_Cuentas_Pagar
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Table, tblProv As DataTable
    Dim Sql As String
    Dim rpt As New CuentasxPagar_Auxiliar_Proveedores_rpt
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Pagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaProveedores()
        Me.dgvProveedores.AutoGenerateColumns = False
        Me.crvEstadoCuenta.BackColor = Color.MintCream
        Me.dpFechaI.Value = Now.AddDays(-Now.Day + 1)
        Me.WindowState = FormWindowState.Maximized
        pb1.Maximum = Me.dgvProveedores.Rows.Count
    End Sub

    Private Sub CargaProveedores()
        sqlCmd.CommandText = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @SIUD = 'CXPLIST'"
        tblProv = jClass.obtenerDatos(sqlCmd)
        Me.dgvProveedores.DataSource = tblProv
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim TextObj As TextObject
        Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_ORDEN_COMPRA_AUXILIAR_PROVEEDORES]" & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ", @FECHA_INICIO = '" & Me.dpFechaI.Value.ToShortDateString & "'" & vbCrLf
        Sql &= ", @FECHA_FINAL = '" & Me.dpFechaF.Value.ToShortDateString & "'" & vbCrLf
        Sql &= ", @BANDERA = 1" & vbCrLf
        Sql &= ", @CODPROV = "
        sqlCmd.CommandText = Sql
        pb1.Value = 0
        pb1.Visible = True
        TextObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        TextObj.Text = Descripcion_Compañia
        TextObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        TextObj.Text = "PERIODO DEL: " & Me.dpFechaI.Value.ToShortDateString & " AL: " & Me.dpFechaF.Value.ToShortDateString
        BW1.RunWorkerAsync()
    End Sub

    Private Function auxiliarProv(ByVal query As String) As DataTable
        Dim tblTemporal As DataTable
        Dim tblDatos As DataTable = jClass.obtenerDatos(New SqlCommand(query & "999999999"))
        While tblDatos.Rows.Count > 0
            tblDatos.Rows.RemoveAt(0)
        End While
        For i As Integer = 0 To Me.dgvProveedores.Rows.Count - 1
            If Me.dgvProveedores.Rows(i).Cells(0).Value Then
                tblTemporal = jClass.obtenerDatos(New SqlCommand(query & Me.dgvProveedores.Rows(i).Cells(1).Value))
                For Each row As DataRow In tblTemporal.Rows
                    tblDatos.ImportRow(row)
                Next
            End If
            BW1.ReportProgress(i)
        Next
        Return tblDatos
    End Function

    Private Sub BW1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW1.DoWork
        Table = auxiliarProv(Sql)
    End Sub

    Private Sub BW1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW1.ProgressChanged
        pb1.Value = e.ProgressPercentage
    End Sub

    Private Sub BW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW1.RunWorkerCompleted
        pb1.Visible = False
        rpt.SetDataSource(Table)
        Me.crvEstadoCuenta.ReportSource = rpt
        Me.crvEstadoCuenta.Zoom(1)
    End Sub

    Private Sub chkProv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProv.CheckedChanged
        For i As Integer = 0 To Me.dgvProveedores.Rows.Count - 1
            Me.dgvProveedores.Rows(i).Cells(0).Value = Me.chkProv.Checked
        Next
    End Sub

    Private Sub Contabilidad_Reportes_Auxiliar_Cuentas_Pagar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProvedor.TextChanged, txtCodigo.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = tblProv.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvProveedores.DataSource = tblProv
        Else
            rows = tblProv.Select("[" & Ncolumn & "] like '%" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvProveedores.DataSource = Nothing
            Me.dgvProveedores.DataSource = tablaT
        End If
    End Sub
End Class