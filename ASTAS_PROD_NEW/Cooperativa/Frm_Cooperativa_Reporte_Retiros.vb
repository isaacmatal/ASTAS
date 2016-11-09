Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_Cooperativa_Reporte_Retiros
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim T_cobro As String = 1

    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Tabla As DataTable
    Dim tbl_ As New DataTable
    Dim empresas_ As String

    Private Sub Frm_Cooperativa_Reporte_Retiros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.rdbasoc.Checked = True
        Me.WindowState = FormWindowState.Maximized
        Try
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = "SELECT ORIGEN, DESCRIPCION_ORIGEN FROM dbo.COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia
            Tabla = c_data1.obtenerDatos(sqlCmd)

            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("ORIGEN", Type.GetType("System.Int32"))
            tbl_.Columns.Add("DESCRIPCION_ORIGEN", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next

            dgvOrigen.AutoGenerateColumns = False
            'Set Columns Count
            dgvOrigen.ColumnCount = 3

            'Add Columns
            dgvOrigen.Columns(0).Name = "Seleccionar"
            dgvOrigen.Columns(0).HeaderText = "Seleccionar"
            dgvOrigen.Columns(0).DataPropertyName = "Seleccionar"

            dgvOrigen.Columns(1).Name = "ORIGEN"
            dgvOrigen.Columns(1).HeaderText = "ORIGEN"
            dgvOrigen.Columns(1).DataPropertyName = "ORIGEN"

            dgvOrigen.Columns(2).Name = "DESCRIPCION_ORIGEN"
            dgvOrigen.Columns(2).HeaderText = "Empresa"
            dgvOrigen.Columns(2).DataPropertyName = "DESCRIPCION_ORIGEN"

            dgvOrigen.DataSource = tbl_
            Me.dgvOrigen.Columns("ORIGEN").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub Frm_Cooperativa_Reporte_Retiros_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub btngenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngenerar.Click
        CargaReporte()
    End Sub
    Public Sub CargaReporte()
        Dim Rpt As Object
        Dim RPT1 As String = "RPT1"
        Dim RPT2 As String = "RPT2"
        Dim RPT3 As String = "RPT3"        

        Rpt = New Cooperativa_Reporte_Retiros
        Try
            DS01.Reset()
            getEmpresas()

            If Me.rdbasoc.Checked = True Then
                Sql = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS @COMPAÑIA=" & Compañia & " ,@FECHA_DESDE='" & Format(DateTimePicker1.Value, "dd-MM-yyyy") & "',@FECHA_HASTA='" & Format(DateTimePicker2.Value, "dd-MM-yyyy ") & "', @SIUD='" & RPT1 & "', @ORIGENES='" & empresas_ & "'"
            ElseIf Me.rdbempresa.Checked = True Then
                Sql = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS @COMPAÑIA=" & Compañia & " ,@FECHA_DESDE='" & Format(DateTimePicker1.Value, "dd-MM-yyyy") & "',@FECHA_HASTA='" & Format(DateTimePicker2.Value, "dd-MM-yyyy") & "', @SIUD='" & RPT2 & "', @ORIGENES='" & empresas_ & "'"
            ElseIf Me.rbTodos.Checked Then
                Sql = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS @COMPAÑIA=" & Compañia & " ,@FECHA_DESDE='" & Format(DateTimePicker1.Value, "dd-MM-yyyy") & "',@FECHA_HASTA='" & Format(DateTimePicker2.Value, "dd-MM-yyyy") & "', @SIUD='" & RPT3 & "', @ORIGENES='" & empresas_ & "'"

            End If

            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))

            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub getEmpresas()
        empresas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvOrigen.Rows
            If oRow.Cells("Seleccionar").Value = True Then
                empresas_ = empresas_ & oRow.Cells("ORIGEN").Value & ","
            End If
        Next

        empresas_ = empresas_.TrimEnd(",")
    End Sub

    Private Sub chkTodasEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasEmpresas.CheckedChanged
        If Me.chkTodasEmpresas.Checked Then
            For Each oRow As DataGridViewRow In dgvOrigen.Rows
                oRow.Cells("Seleccionar").Value = True
            Next
        Else
            For Each oRow As DataGridViewRow In dgvOrigen.Rows
                oRow.Cells("Seleccionar").Value = False
            Next
        End If
    End Sub

End Class