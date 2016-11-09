Imports System.Data
Imports System.Data.SqlClient

Public Class FrmModificarProgramacionesVisualizarDetalles
    Public _codigo_socio As Integer
    Public _num_solicitud As Integer
    Public _nombre_socio As String
    Public _fecha_otorgado As Date
    Dim _core As New jarsClass
    Dim _sql As String
    Dim _saldo_normal As Decimal
    Dim _saldo_especial As Decimal

    Private Sub FrmModificarProgramacionesVisualizarDetalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCodigo.Text = Me._codigo_socio
        Me.TxtNombre.Text = Me._nombre_socio
        Me.txtSolicitud.Text = Me._num_solicitud
        Me.dtpFecha.Value = Date.Now
        'Me.dtpOtorgado.CustomFormat = "dd/MM/yyyy"
        Me.dtpOtorgado.Value = _fecha_otorgado

        Me.consultar(1)
        Me.formatearGrid()
    End Sub

    Private Sub formatearGrid()
        Me.dgvDetalle.Columns(0).Width = 60

        Me.dgvDetalle.Columns(1).Width = 60
        Me.dgvDetalle.Columns(1).DefaultCellStyle.Format = "#,###.00"
        Me.dgvDetalle.Columns(1).ReadOnly = True

        Me.dgvDetalle.Columns(2).Width = 75
        Me.dgvDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvDetalle.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
        Me.dgvDetalle.Columns(2).ReadOnly = True

        Me.dgvDetalle.Columns(3).Width = 60
        Me.dgvDetalle.Columns(3).ReadOnly = True
    End Sub

    Private Sub consultar(ByVal _bandera)
        Dim _table As DataTable
        Dim _table_detalle As DataTable
        Try
            If _bandera = 1 Then
                _sql = "EXECUTE dbo.SP_COOPERATIVA_VISUALIZAR_DETALLES @COMPAÑIA=" & Compañia & ", @SOCIO = " & Me._codigo_socio & ", @SOLICITUD  = " & Me._num_solicitud & ", @HASTA = '" & CDate(Me.dtpFecha.Value.ToShortDateString()) & "', @BANDERA    = " & _bandera & ", @MONTO_NORMAL = 0, @MONTO_ESPECIAL = 0"
                _table = _core.obtenerDatos(New SqlCommand(_sql))

                Dim chk As New DataGridViewCheckBoxColumn()
                dgvDetalle.Columns.Add(chk)
                chk.HeaderText = " "
                chk.Name = "chk"

                Me.dgvDetalle.DataSource = _table
            End If
            
            If _bandera = 2 Then
                _sql = "EXECUTE dbo.SP_COOPERATIVA_VISUALIZAR_DETALLES @COMPAÑIA=" & Compañia & ", @SOCIO = " & Me._codigo_socio & ", @SOLICITUD  = " & Me._num_solicitud & ", @HASTA = '" & CDate(Me.dtpFecha.Value.ToShortDateString()) & "', @BANDERA    = " & _bandera & ", @MONTO_NORMAL = " & _saldo_normal & ", @MONTO_ESPECIAL = " & _saldo_especial
                _table_detalle = _core.obtenerDatos(New SqlCommand(_sql))

                Me.txtSaldoNormal.Text = _saldo_normal.ToString()
                Me.txtInteresNormal.Text = _table_detalle.Rows(0).Item(1).ToString()
                Me.txtSeguroNormal.Text = _table_detalle.Rows(0).Item(2).ToString()
                Me.txtTotalNormal.Text = _table_detalle.Rows(0).Item(3).ToString()

                Me.txtSaldoEspecial.Text = _saldo_especial.ToString()
                Me.txtInteresEspecial.Text = _table_detalle.Rows(0).Item(6).ToString()
                Me.txtSeguroEspecial.Text = _table_detalle.Rows(0).Item(7).ToString()
                Me.txtTotalEspecial.Text = _table_detalle.Rows(0).Item(8).ToString()

                Me.txtGranTotal.Text = _table_detalle.Rows(0).Item(10).ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FrmModificarProgramacionesVisualizarDetalles_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Me.dtpFecha.Value.ToString("dd/MM/yyyy") >= Date.Now.ToString("dd/MM/yyyy") Then
            Dim i As Integer
            _saldo_especial = 0
            _saldo_normal = 0

            For i = 0 To Me.dgvDetalle.Rows.Count - 1
                If (Me.dgvDetalle.Rows(i).Cells(0).Value) Then
                    'Si es Especial
                    If (Me.dgvDetalle.Rows(i).Cells(3).Value) Then
                        _saldo_especial = _saldo_especial + Me.dgvDetalle.Rows(i).Cells(1).Value
                    End If

                    'Si es Normal
                    If Not (Me.dgvDetalle.Rows(i).Cells(3).Value) Then
                        _saldo_normal = _saldo_normal + Me.dgvDetalle.Rows(i).Cells(1).Value
                    End If
                End If
            Next
            Me.consultar(2)
        Else
            MsgBox("La fecha debe ser mayor o igual a la fecha actual.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
        Dim seleccionados As Integer
        Dim _c As Integer

        If dgvDetalle.CurrentRow.Cells(0).Value Then
            dgvDetalle.CurrentRow.Cells(0).Value = False
        Else
            dgvDetalle.CurrentRow.Cells(0).Value = True
        End If

        seleccionados = 0
        For _c = 0 To dgvDetalle.Rows.Count - 1
            If (dgvDetalle.Rows(_c).Cells(0).Value) Then
                seleccionados = seleccionados + 1
            End If
        Next

        If seleccionados > 0 Then
            Me.btnConsultar.Enabled = True
        Else
            Me.btnConsultar.Enabled = False
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim _x As Integer
        If chkSeleccionarTodo.Checked Then
            For _x = 0 To dgvDetalle.Rows.Count - 1
                dgvDetalle.Rows(_x).Cells(0).Value = True
            Next

            Me.btnConsultar.Enabled = True
        End If

        If Not chkSeleccionarTodo.Checked Then
            For _x = 0 To dgvDetalle.Rows.Count - 1
                dgvDetalle.Rows(_x).Cells(0).Value = False
            Next

            Me.btnConsultar.Enabled = False
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If CInt(Me.txtGranTotal.Text) > 0 Then
            Me.btnPrint.Visible = False
            Dim _reporte As New frmReportes_Ver()
            _reporte.CargarRptVisualizarDetalles(Compañia, Me._codigo_socio, Me._num_solicitud, Me.dtpFecha.Value, _saldo_normal, _saldo_especial)
            _reporte.ShowDialog()
            Me.btnPrint.Visible = True
        End If
    End Sub
End Class