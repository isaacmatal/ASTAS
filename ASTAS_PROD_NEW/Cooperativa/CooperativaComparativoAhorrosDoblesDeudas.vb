Imports System.Data.SqlClient

Public Class CooperativaComparativoAhorrosDoblesDeudas
    Dim Rpts As New frmReportes_Ver
    Dim c_data1 As New jarsClass
    Dim _sql_string As String
    Dim _cmd As New SqlCommand
    Dim _filter_socios As New DataTable()
    Dim _rubros As New DataTable()
    Dim _seleccionados As New DataTable()
    Dim _resultados As New DataTable()
    Dim _origenes As New DataTable()
    Dim _cod_origenes As String = String.Empty
    Dim _cod_rubros As String = String.Empty
    Dim _tblprocesada As New DataTable("tbl_procesada")
    Dim Exportar_Excel As New ExportDataExcel

    Private Sub CooperativaComparativoAhorrosDoblesDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)

        _sql_string = "SELECT SOLICITUD,DESCRIPCION_SOLICITUD As [Descripción del Rubro] FROM dbo.COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA=" & Compañia
        _cmd.CommandText = _sql_string
        _rubros = c_data1.obtenerDatos(_cmd)
        _rubros.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
        For Each _selrow As DataRow In _rubros.Rows
            _selrow("Seleccione") = False
        Next _selrow

        Me.dgvRubros.DataSource = _rubros

        With dgvRubros
            .Columns("SOLICITUD").Visible = False
            .Columns("SOLICITUD").DisplayIndex = 0
            .Columns("Seleccione").DisplayIndex = 1
            .Columns("Descripción del Rubro").DisplayIndex = 2
            .Columns("Descripción del Rubro").Width = 300
        End With

        _sql_string = "SELECT ORIGEN,DESCRIPCION_ORIGEN FROM [dbo].COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia
        _cmd.CommandText = _sql_string
        _origenes = c_data1.obtenerDatos(_cmd)
        _origenes.Columns.Add("Seleccione", Type.GetType("System.Boolean"))
        For Each _selrow As DataRow In _origenes.Rows
            _selrow("Seleccione") = False
        Next _selrow

        Me.dgvOrigenes.DataSource = _origenes

        With dgvOrigenes
            .Columns("ORIGEN").Visible = False
            .Columns("ORIGEN").DisplayIndex = 0
            .Columns("ORIGEN").Width = 60
            .Columns("Seleccione").DisplayIndex = 1
            .Columns("DESCRIPCION_ORIGEN").DisplayIndex = 2
            .Columns("DESCRIPCION_ORIGEN").Width = 180
            .Columns("DESCRIPCION_ORIGEN").HeaderText = "Empresas"
        End With
    End Sub


    Private Sub CooperativaComparativoAhorrosDoblesDeudas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    'Private Sub txtnombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombres.TextChanged
    '    If Me.txtnombres.Text.Length > 0 Then
    '        _sql_string = "SELECT CODIGO_EMPLEADO, NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA=" & Compañia & " AND RETIRADO=0 AND (NOMBRES LIKE '%" & Me.txtnombres.Text & "%' OR APELLIDOS LIKE '%" & Me.txtnombres.Text & "%' OR CODIGO_EMPLEADO LIKE '%" & Me.txtnombres.Text & "%')"
    '        _cmd.CommandText = _sql_string
    '        _filter_socios = c_data1.obtenerDatos(_cmd)
    '        dgvSocios1.DataSource = _filter_socios
    '    End If
    'End Sub

    'Private Sub dgvSocios2_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSocios2.DragDrop
    '    Try
    '        Dim index As Integer = Convert.ToInt32(e.Data.GetData(Type.GetType("System.Int32")))
    '        Dim _codigo As Integer
    '        Dim _nombres As String
    '        _codigo = dgvSocios1.Rows(index).Cells("CODIGO_EMPLEADO").Value
    '        _nombres = dgvSocios1.Rows(index).Cells("NOMBRE_COMPLETO").Value.ToString
    '        Dim Dr As DataRow
    '        Dr = _seleccionados.NewRow
    '        Dr("CODIGO_EMPLEADO") = _codigo
    '        Dr("NOMBRE_COMPLETO") = _nombres
    '        _seleccionados.Rows.Add(Dr)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub dgvSocios1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSocios1.MouseDown
    '    Dim Index As Integer
    '    Index = dgvSocios1.HitTest(e.X, e.Y).RowIndex
    '    If Index > -1 Then
    '        dgvSocios1.DoDragDrop(Index, DragDropEffects.Move)
    '    End If
    'End Sub

    'Private Sub dgvSocios2_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSocios2.DragOver
    '    e.Effect = DragDropEffects.Move
    'End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If dgvSocios2.Rows.Count > 0 Then

            Me.btnConsultarPorRubros.Visible = False
            Dim _codigos As String = String.Empty
            Dim i As Integer

            For i = 0 To dgvSocios2.Rows.Count - 1
                _codigos &= Me.dgvSocios2.Rows(i).Cells(0).Value & ","
            Next

            _codigos = _codigos.TrimEnd(",")

            Dim _rubros As String = String.Empty
            _resultados = c_data1.obtenerDatos(New SqlCommand("EXECUTE SP_COMPARATIVO_DOBLE_AHORRO_VRS_DEUDAS @MCOMPAÑIA = " & Compañia & ", @SOCIOS = '" & _codigos & "', @FECHA_HASTA='" & CDate(Me.dtpHasta.Value.ToShortDateString()) & "', @RUBROS=''"))

            'Ordenando por Codigo
            Dim sortExp As String = "CODIGO"
            Dim drarray() As DataRow
            drarray = _resultados.Select(Nothing, sortExp, DataViewRowState.CurrentRows)

            If _resultados.Rows.Count > 0 Then
                Dim _tabla As New DataTable()
                Dim _tipocol As String = String.Empty

                For Each row As DataRow In _resultados.Rows
                    If Not _tipocol.Equals(row("TIPODEUDA")) Then
                        _tipocol = row("TIPODEUDA")
                        _resultados.Columns.Add(_tipocol, Type.GetType("System.String"))
                    End If
                Next

                'Esta tendra las columnas y la data final
                Dim _tbl_final As New DataTable()
                _tbl_final = _resultados.Clone()

                Dim _cod As Integer = 0
                For Each _fila As DataRow In drarray
                    If Not _cod = _fila("CODIGO") Then
                        Dim R As DataRow = _tbl_final.NewRow
                        R("CODIGO") = _fila("CODIGO")
                        R("NOMBRE_COMPLETO") = _fila("NOMBRE_COMPLETO")
                        R("AHORRO") = _fila("AHORRO")
                        R("DOBLEAHORRO") = _fila("DOBLEAHORRO")
                        R("SALDO") = _fila("SALDO")
                        R("DISPONIBILIDAD") = _fila("DISPONIBILIDAD")
                        R("DISPONIBILIDAD_DOBLE") = _fila("DISPONIBILIDAD_DOBLE")
                        _tbl_final.Rows.Add(R)
                        _cod = _fila("CODIGO")
                    End If
                Next

                'Los indices son 4 por que cada vez que se quita una columna 
                'se reduce el largo y la siguiente pasa a ser 4
                'TIPO_SOLICITUD
                _tbl_final.Columns.RemoveAt(4)
                'FECHA
                _tbl_final.Columns.RemoveAt(4)
                'TIPODEUDA
                _tbl_final.Columns.RemoveAt(4)

                Dim _total As Integer = _resultados.Columns.Count - 1
                Dim _col As Integer = 7
                Dim _codigo_socio As String = String.Empty

                For Each this_row As DataRow In _tbl_final.Rows

                    If Not _codigo_socio.Equals(this_row("CODIGO")) Then
                        For Each _fila As DataRow In _resultados.Rows
                            If _fila("CODIGO") = this_row("CODIGO") Then
                                this_row(_fila("TIPODEUDA")) = _fila("SALDO").ToString()
                            Else
                                this_row(_fila("TIPODEUDA")) = "0.00"
                            End If
                        Next

                    End If
                    _codigo_socio = this_row("CODIGO")
                Next

                Me.dgvResultados.DataSource = _tbl_final
            End If
        Else
            MessageBox.Show("Seleccione los socios para continuar...", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnConsultarPorRubros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarPorRubros.Click
        Dim i As Integer
        _cod_rubros = String.Empty
        For i = 0 To dgvRubros.Rows.Count - 1
            If (Me.dgvRubros.Rows(i).Cells(2).Value) Then
                _cod_rubros &= CInt(Me.dgvRubros.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _cod_rubros = _cod_rubros.TrimEnd(",")

        i = 0
        _cod_origenes = String.Empty
        For i = 0 To Me.dgvOrigenes.Rows.Count - 1
            If (Me.dgvOrigenes.Rows(i).Cells(2).Value) Then
                _cod_origenes &= CInt(Me.dgvOrigenes.Rows(i).Cells(0).Value).ToString() & ","
            End If
        Next
        _cod_origenes = _cod_origenes.TrimEnd(",")

        Dim _continuar As Boolean = True

        If Not _cod_origenes.Length > 0 Then
            _continuar = False
            MessageBox.Show("Seleccione las Empresas para continuar...", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If Not _cod_rubros.Length > 0 Then
            _continuar = False
            MessageBox.Show("Seleccione los rubros para continuar...", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If _continuar Then
            dgvResultados.DataSource = Nothing
            Me.pbLoad.Visible = True
            btnConsultarPorRubros.Visible = False
            btnExportar.Visible = False
            dtpHasta.Enabled = False                       

            Me.BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub dgvRubros_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvRubros.CurrentRow.Cells(2).Value Then
            dgvRubros.CurrentRow.Cells(2).Value = False
        Else
            dgvRubros.CurrentRow.Cells(2).Value = True
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim _cadena As String = "EXECUTE SP_COMPARATIVO_DOBLE_AHORRO_VRS_DEUDAS @MCOMPAÑIA = " & Compañia & ", @FECHA_HASTA='" & CDate(Me.dtpHasta.Value.ToShortDateString()) & "', @RUBROS='" & _cod_rubros & "', @ORIGENES='" & _cod_origenes & "'"
        _resultados = c_data1.obtenerDatos(New SqlCommand(_cadena))

        'Ordenando por Codigo
        Dim sortExp As String = "CODIGO"
        Dim drarray() As DataRow
        drarray = _resultados.Select(Nothing, sortExp, DataViewRowState.CurrentRows)

        If _resultados.Rows.Count > 0 Then
            Dim _tabla As New DataTable()
            Dim _tipocol As String = String.Empty

            'Agregando las nuevas columnas
            For Each row As DataRow In _resultados.Rows
                If Not _tipocol.Equals(row("TIPODEUDA")) And Not row("TIPODEUDA").Equals("") Then
                    _tipocol = row("TIPODEUDA")
                    _resultados.Columns.Add(_tipocol, Type.GetType("System.String"))
                End If
            Next

            'Esta tendra las columnas y la data final
            Dim _tbl_final As New DataTable()
            _tbl_final = _resultados.Clone()

            Dim _cod As Integer = 0
            For Each _fila As DataRow In drarray
                If Not _cod = _fila("CODIGO") Then
                    Dim R As DataRow = _tbl_final.NewRow
                    R("CODIGO") = _fila("CODIGO")
                    R("NOMBRE_COMPLETO") = _fila("NOMBRE_COMPLETO")
                    R("AHORRO") = _fila("AHORRO")
                    R("DOBLEAHORRO") = _fila("DOBLEAHORRO")
                    R("SALDO") = _fila("SALDO")
                    R("DISPONIBILIDAD") = _fila("DISPONIBILIDAD")
                    R("DISPONIBILIDAD_DOBLE") = _fila("DISPONIBILIDAD_DOBLE")
                    _tbl_final.Rows.Add(R)
                    _cod = _fila("CODIGO")
                End If
            Next

            'Los indices son 4 por que cada vez que se quita una columna 
            'se reduce el largo y la siguiente pasa a ser 4
            'TIPO_SOLICITUD
            _tbl_final.Columns.RemoveAt(4)
            'FECHA
            _tbl_final.Columns.RemoveAt(4)
            'TIPODEUDA
            _tbl_final.Columns.RemoveAt(4)

            Dim _codigo_socio As String = String.Empty

            For Each this_row As DataRow In _tbl_final.Rows

                If Not _codigo_socio.Equals(this_row("CODIGO")) Then
                    For Each _fila As DataRow In _resultados.Rows
                        Dim _nombre_fila = _fila("TIPODEUDA").ToString()
                        If _fila("CODIGO") = this_row("CODIGO") And Not _nombre_fila.Equals("") Then
                            this_row(_nombre_fila) = _fila("SALDO").ToString()
                        End If
                    Next

                End If
                _codigo_socio = this_row("CODIGO")
            Next

            Dim _x As Integer = 7
            For _x = 7 To _tbl_final.Columns.Count - 1
                For Each _filas As DataRow In _tbl_final.Rows
                    If IsDBNull(_filas(_x).ToString()) Or String.IsNullOrEmpty(_filas(_x).ToString()) Then
                        _filas(_x) = "0.00"
                    End If
                Next
            Next

            _tbl_final.Columns.RemoveAt(4)

            _tbl_final.Columns.Add("Disponibilidad Ahorro Normal", Type.GetType("System.Decimal"))
            _tbl_final.Columns.Add("Disponibilidad Doble del Ahorro", Type.GetType("System.Decimal"))

            For Each _fila As DataRow In _tbl_final.Rows
                _fila("Disponibilidad Ahorro Normal") = _fila("DISPONIBILIDAD")
                _fila("Disponibilidad Doble del Ahorro") = _fila("DISPONIBILIDAD_DOBLE")
            Next

            'Quitando la columna DISPONIBILIDAD y DISPONIBILIDAD_DOBLE
            _tbl_final.Columns.RemoveAt(4)
            _tbl_final.Columns.RemoveAt(4)
            Me.pasarDatos(_tbl_final)
        End If
    End Sub

    Private Sub pasarDatos(ByVal _tabla)
        _tblprocesada = _tabla
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.dgvResultados.DataSource = _tblprocesada
        Me.dgvResultados.Columns(0).HeaderText = "Código"
        Me.dgvResultados.Columns(0).Width = 60
        Me.dgvResultados.Columns(1).HeaderText = "Nombre del Socio"
        Me.dgvResultados.Columns(1).Width = 300
        Me.dgvResultados.Columns(2).HeaderText = "Ahorro Ordinario"
        Me.dgvResultados.Columns(3).HeaderText = "Doble del Ahorro"
        'Me.dgvResultados.Columns(4).HeaderText = "Disponibilidad Ahorro Normal"
        'Me.dgvResultados.Columns(5).HeaderText = "Disponibilidad Doble del Ahorro"

        'Dim _tot_col1 As Integer = Me.dgvResultados.Columns.Count - 1
        'Dim _tot_col2 As Integer = Me.dgvResultados.Columns.Count - 1

        'With dgvResultados
        '    .Columns("DISPONIBILIDAD").DisplayIndex = _tot_col1
        '    .Columns("DISPONIBILIDAD_DOBLE").DisplayIndex = _tot_col2
        'End With

        Me.pbLoad.Visible = False
        btnConsultarPorRubros.Visible = True
        dtpHasta.Enabled = True
        btnExportar.Visible = True
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim _s As Integer
        If chkAll.Checked Then
            For _s = 0 To dgvRubros.Rows.Count - 1
                dgvRubros.Rows(_s).Cells(2).Value = True
            Next
        End If

        If Not chkAll.Checked Then
            For _s = 0 To dgvRubros.Rows.Count - 1
                dgvRubros.Rows(_s).Cells(2).Value = False
            Next
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Me.dgvResultados.Rows.Count > 0 Then
            Exportar_Excel.ExportarDatosExcel(Me.dgvResultados, "Comparativo Doble Ahorro")
        Else
            MessageBox.Show("No existen datos para exportar.", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim _s As Integer
        If CheckBox1.Checked Then
            For _s = 0 To dgvOrigenes.Rows.Count - 1
                dgvOrigenes.Rows(_s).Cells(2).Value = True
            Next
        End If

        If Not CheckBox1.Checked Then
            For _s = 0 To dgvOrigenes.Rows.Count - 1
                dgvOrigenes.Rows(_s).Cells(2).Value = False
            Next
        End If
    End Sub
End Class