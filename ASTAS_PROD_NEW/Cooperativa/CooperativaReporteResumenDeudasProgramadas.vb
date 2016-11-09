Imports System.Data.SqlClient

Public Class CooperativaReporteResumenDeudasProgramadas
    Dim Rpts As New frmReportes_Ver
    Dim c_data1 As New jarsClass
    Dim rubros_ As String

    Private Sub CooperativaReporteResumenDeudasProgramadas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub CooperativaReporteResumenDeudasProgramadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.lblNombre.Text = String.Empty
        loadRubros()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.txtCodigo.Text.Length > 0 Then
            If MsgBox("Desea imprimir el reporte?", MsgBoxStyle.YesNo, "IMPRESION") = MsgBoxResult.Yes Then
                Me.getRubros()
                If rubros_.Length = 0 Then
                    MsgBox("Seleccione un Rubro", MsgBoxStyle.Information, "Sistema")
                    Return
                End If

                Dim _periodo As String = String.Empty

                If (Me.radTodas.Checked) Then
                    _periodo = "AG,BO,MM,QQ"
                End If
                If (Me.radQuincenal.Checked) Then
                    _periodo = "QQ"
                End If
                If (Me.radMensual.Checked) Then
                    _periodo = "MM"
                End If
                If (Me.radEspecial.Checked) Then
                    _periodo = "AG,BO"
                End If

                Me.btnPrint.Visible = False
                Rpts.RepResumenDeudasProgramadas(Compañia, Usuario, rubros_, Me.txtCodigo.Text, _periodo)
                Rpts.ShowDialog()
                Me.btnPrint.Visible = True
            End If
        Else
            MsgBox("Ingrese un Código de Empleado", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub loadRubros()
        Try
            dgvRubros.DataSource = Nothing
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = "SELECT DEDUCCION, DESCRIPCION_DEDUCCION FROM COOPERATIVA_CATALOGO_DEDUCCIONES WHERE DEDUCCION <> 0 AND COMPAÑIA = " & Compañia

            Tabla = c_data1.obtenerDatos(sqlCmd)
            Dim tbl_ As New DataTable
            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("DEDUCCION", Type.GetType("System.Int32"))
            tbl_.Columns.Add("DESCRIPCION_DEDUCCION", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next
            'Add Columns
            dgvRubros.Columns(0).Name = "Seleccionar"
            dgvRubros.Columns(0).HeaderText = "Seleccionar"
            dgvRubros.Columns(0).DataPropertyName = "Seleccionar"
            dgvRubros.Columns(1).Name = "DEDUCCION"
            dgvRubros.Columns(1).HeaderText = "Codigo"
            dgvRubros.Columns(1).DataPropertyName = "DEDUCCION"
            dgvRubros.Columns(2).Name = "DESCRIPCION_DEDUCCION"
            dgvRubros.Columns(2).HeaderText = "Descripciòn"
            dgvRubros.Columns(2).DataPropertyName = "DESCRIPCION_DEDUCCION"
            dgvRubros.Columns(1).Visible = False
            dgvRubros.DataSource = tbl_

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub allRubros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allRubros.CheckedChanged
        If allRubros.Checked Then
            For Each fila As DataGridViewRow In dgvRubros.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvRubros.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub getRubros()
        rubros_ = String.Empty
        For Each oRow As DataGridViewRow In dgvRubros.Rows
            If oRow.Cells("SELECCIONAR").Value = True Then
                rubros_ = rubros_ & oRow.Cells("DEDUCCION").Value & ","
            End If
        Next
        rubros_ = rubros_.TrimEnd(",")
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        If Me.txtCodigo.Text.Length > 0 Then
            buscar()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.txtCodigo.Text = String.Empty
        Me.lblNombre.Text = String.Empty
        Me.btnBuscar.Visible = False
        Dim _buscar As New FrmBuscarSocios
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2
        _buscar.ShowDialog()

        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Me.txtCodigo.Text = ParamcodigoBux
            buscar()
        End If
        _buscar.Dispose()
        Me.btnBuscar.Visible = True
    End Sub

    Private Sub buscar()
        Dim _socio_tbl As DataTable
        Dim _sql_cmd As New SqlCommand
        _sql_cmd.CommandText = "SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.txtCodigo.Text & " AND COMPAÑIA = " & Compañia
        _socio_tbl = c_data1.obtenerDatos(_sql_cmd)

        Me.lblNombre.Text = _socio_tbl.Rows(0).Item(0).ToString()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Me.txtCodigo.Text = String.Empty
        Me.lblNombre.Text = String.Empty
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Me.txtCodigo.Text.Length > 0 Then
                buscar()
            End If
        End If
    End Sub
End Class