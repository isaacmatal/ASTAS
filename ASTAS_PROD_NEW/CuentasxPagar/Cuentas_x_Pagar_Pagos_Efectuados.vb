Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient
Public Class Cuentas_x_Pagar_Pagos_Efectuados
    Dim jClass As New jarsClass
    Dim sqlCmd As New SqlCommand
    Dim Table, tblProv As DataTable
    Dim Sql As String

    Private Sub Contabilidad_Reportes_Programacion_Pagos_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvProveedores.AutoGenerateColumns = False
        sqlCmd.CommandText = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @SIUD = 'CXPLIST'"
        tblProv = jClass.obtenerDatos(sqlCmd)
        Me.dgvProveedores.DataSource = tblProv
        sqlCmd.CommandText = "SELECT BANCO, DESCRIPCION_BANCO FROM CONTABILIDAD_CATALOGO_BANCOS WHERE COMPAÑIA = " & Compañia & " AND BANCO > 0"
        Table = jClass.obtenerDatos(sqlCmd)
        Me.dgvBancos.DataSource = Table
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim rpt As New CuentasxPagar_Pagos_Efectuados
        Dim TextObj, txtUsuario As TextObject
        Dim Proveedor As String = String.Empty
        Dim Bancos As String = String.Empty
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
                MsgBox("No seleccionó ningun proveedor", MsgBoxStyle.Information, "Cuentas por Pagar")
                Return
            End If
            If Me.chkPagoChq.Checked Then
                Bancos = "0"
            End If
            For i As Integer = 0 To Me.dgvBancos.Rows.Count - 1
                If Me.dgvBancos.Rows(i).Cells(0).Value Then
                    If Bancos.Length = 0 Then
                        Bancos = Me.dgvBancos.Rows(i).Cells(1).Value
                    Else
                        Bancos &= "," & Me.dgvBancos.Rows(i).Cells(1).Value
                    End If
                End If
            Next
            If Bancos.Length = 0 Then
                MsgBox("No seleccionó ningun Banco o Pago con Cheque", MsgBoxStyle.Information, "Cuentas por Pagar")
                Return
            End If
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_PROGRAMACION_PAGOS_PROVEEDORES_RPT" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @FECHAFINAL = '" & Format(Me.dpFechaF.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @PROVEEDOR = '" & Proveedor & "'" & vbCrLf
            Sql &= ", @BODEGA = '" & Bancos & "'" & vbCrLf
            Sql &= ", @BANDERA = 2" & vbCrLf
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            rpt.SetDataSource(Table)
            TextObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
            Sql = "SELECT dbo.fn_INVENTARIOS_PERIODO_SEGUN_FECHA ('" & Format(Me.dpFechaF.Value, "dd-MM-yyyy") & "', '" & Format(Me.dpFechaF.Value, "dd-MM-yyyy") & "')"
            TextObj.Text = "FECHA DE PAGO: " & jClass.obtenerEscalar(Sql)
            txtUsuario = rpt.Section4.ReportObjects.Item("txtUsuario")
            txtUsuario.Text = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 53").ToString().Trim()
            Me.crvReporte.ReportSource = rpt
            Me.crvReporte.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub chkProv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProv.CheckedChanged
        For i As Integer = 0 To Me.dgvProveedores.Rows.Count - 1
            Me.dgvProveedores.Rows(i).Cells(0).Value = Me.chkProv.Checked
        Next
    End Sub

    Private Sub chkBancos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBancos.CheckedChanged
        For i As Integer = 0 To Me.dgvBancos.Rows.Count - 1
            Me.dgvBancos.Rows(i).Cells(0).Value = Me.chkBancos.Checked
        Next
    End Sub

    Private Sub Contabilidad_Reportes_Programacion_Pagos_Proveedores_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Contabilidad_Reportes_Programacion_Pagos_Proveedores_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.chkBancos_CheckedChanged(New Object, New System.EventArgs)
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