Imports System.Data
Imports System.Data.SqlClient

Public Class FrmModificarProgramacionesVisualizarVariasSolicitudes
    Public _solicitudes As String
    Public _codigo_socio As Integer
    Public _nombre_socio As String
    Dim _core As New jarsClass
    Dim _sql As String
    Public _solicitud_tipo As String

    Private Sub FrmModificarProgramacionesVisualizarVariasSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCodigo.Text = Me._codigo_socio
        Me.TxtNombre.Text = Me._nombre_socio
        Me.txtSolicitud.Text = Me._solicitudes
        Me.dtpFecha.Value = Date.Now
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Me.dtpFecha.Value.ToString("dd/MM/yyyy") >= Date.Now.ToString("dd/MM/yyyy") Then
            btnConsultar.Visible = False
            Dim _table_detalle As DataTable
            'Dim i As Integer

            'For i = 0 To dgvTipoSolicitud.Rows.Count - 1
            '    If (dgvTipoSolicitud.Rows(i).Cells(0).Value) Then
            '        _solicitud_tipo &= Me.dgvTipoSolicitud.Rows(i).Cells(1).Value & ","
            '    End If
            'Next
            '_solicitud_tipo = _solicitud_tipo.TrimEnd(",")

            If _solicitud_tipo.Length > 0 Then
                Try
                    _sql = "EXECUTE dbo.SP_COOPERATIVA_VISUALIZAR_DETALLES_POR_SOLICITUDES @BANDERA=1, @COMPAÑIA=" & Compañia & ", @SOCIO = " & Me._codigo_socio & ", @FHASTA = '" & CDate(Me.dtpFecha.Value.ToShortDateString()) & "', @SOLICITUDES  = '" & Me._solicitudes & "', @TPO_SOLICITUDES='" & _solicitud_tipo & "'"
                    _table_detalle = _core.obtenerDatos(New SqlCommand(_sql))

                    Me.txtSaldoNormal.Text = _table_detalle.Rows(0).Item(0).ToString()
                    Me.txtInteresNormal.Text = _table_detalle.Rows(0).Item(1).ToString()
                    Me.txtSeguroNormal.Text = _table_detalle.Rows(0).Item(2).ToString()
                    Me.txtTotalNormal.Text = _table_detalle.Rows(0).Item(3).ToString()

                    Me.txtSaldoEspecial.Text = _table_detalle.Rows(0).Item(4).ToString()
                    Me.txtInteresEspecial.Text = _table_detalle.Rows(0).Item(5).ToString()
                    Me.txtSeguroEspecial.Text = _table_detalle.Rows(0).Item(6).ToString()
                    Me.txtTotalEspecial.Text = _table_detalle.Rows(0).Item(7).ToString()

                    Me.txtGranTotal.Text = _table_detalle.Rows(0).Item(8).ToString()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("Seleccione el Rubro.", MsgBoxStyle.Information)
            End If
            btnConsultar.Visible = True
        Else
            MsgBox("La fecha debe ser mayor o igual a la fecha actual.", MsgBoxStyle.Information)
        End If
    End Sub

    Public Function obtenerDatos(ByVal _consulta As String) As DataTable
        Dim _tabla As New DataTable("tabla")
        Dim da As SqlDataAdapter
        Try
            Using cn As New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                cn.Open()
                Using cmd As New SqlCommand(_consulta, cn)
                    da = New SqlDataAdapter(cmd)
                    da.Fill(_tabla)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _tabla
    End Function


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.btnConsultar.PerformClick()

        If CInt(Me.txtGranTotal.Text) > 0 Then
            Me.btnPrint.Visible = False
            Me.btnConsultar.Visible = False
            Dim _reporte As New frmReportes_Ver()
            _reporte.CargarRptVisualizarTotalizados(Compañia, Me._codigo_socio, CDate(Me.dtpFecha.Value.ToShortDateString()), Me._solicitudes, Me._solicitud_tipo)
            _reporte.ShowDialog()
            Me.btnPrint.Visible = True
            Me.btnConsultar.Visible = True
        End If
    End Sub

    Private Sub FrmModificarProgramacionesVisualizarVariasSolicitudes_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class