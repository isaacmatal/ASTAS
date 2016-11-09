Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Antiguedad_Saldos_Proveedores
    Dim jClass As New jarsClass
    Dim Sql As String
    Dim Table, tblProv As DataTable
    Dim sqlCmd As New SqlCommand

    Private Sub Contabilidad_Reportes_Antiguedad_Saldos_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvProveedores.AutoGenerateColumns = False
        sqlCmd.CommandText = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @SIUD = 'CXPLIST'"
        tblProv = jClass.obtenerDatos(sqlCmd)
        Me.dgvProveedores.DataSource = tblProv
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Rpt As New Contabilidad_Reportes_Programacion_Pagos_Proveedores_Rpt2
        Dim Proveedor As String = String.Empty
        Try
            For i As Integer = 0 To Me.dgvProveedores.Rows.Count - 1
                If Me.dgvProveedores.Rows(i).Cells(0).Value Then
                    If Proveedor.Length = 0 Then
                        Proveedor = Me.dgvProveedores.Rows(i).Cells(1).Value
                    Else
                        Proveedor &= "," & Me.dgvProveedores.Rows(i).Cells(1).Value
                    End If
                End If
            Next
            If Proveedor.Length = 0 Then
                Return
            End If
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_ANTIGUEDAD_SALDOS_PROVEEDORES_RPT " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @FECHA = '" & Format(Me.txtFechaI.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @BANDERA = 1" & vbCrLf
            Sql &= ", @PROVEEDOR = '" & Proveedor & "'" & vbCrLf
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Rpt.SetDataSource(Table)
                crvReporte.ReportSource = Rpt
                crvReporte.Zoom(1)
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
                crvReporte.ReportSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub chkProv_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProv.CheckedChanged
        For i As Integer = 0 To Me.dgvProveedores.Rows.Count - 1
            Me.dgvProveedores.Rows(i).Cells(0).Value = Me.chkProv.Checked
        Next
    End Sub

    Private Sub Contabilidad_Reportes_Antiguedad_Saldos_Proveedores_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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