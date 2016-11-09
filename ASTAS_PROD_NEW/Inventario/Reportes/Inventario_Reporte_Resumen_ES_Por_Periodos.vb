Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Inventario_Reporte_Resumen_ES_Por_Periodos
    Dim jClass As New jarsClass
    Dim Table As New DataTable
    Dim sqlCmd As New SqlCommand
    Dim sql As String
    Dim Iniciando As Boolean
    Dim c_data1 As New jarsClass
    Dim bodegas_ As String
    Dim grupos_ As String
    Dim subgrupos_ As String
    Dim productos_ As String
    Dim TablaExec As DataTable
    Public report_show_ As New Inventario_Reporte_Resumen_ES_Por_Periodos_Show

    Private Sub Inventario_Reporte_Resumen_ES_Por_Periodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        Me.loadBodegas()
        Me.loadSubGrupos()
        Me.loadProductos(False, String.Empty)
    End Sub

    Private Sub loadBodegas()
        Try
            dgvBodegas.DataSource = Nothing
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = "SELECT BODEGA, DESCRIPCION_BODEGA FROM dbo.INVENTARIOS_CATALOGO_BODEGAS WHERE CAFETERIA = 0 AND ALMACEN = 1 OR DESPENSA = 1"

            Tabla = c_data1.obtenerDatos(sqlCmd)
            Dim tbl_ As New DataTable
            tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl_.Columns.Add("BODEGA", Type.GetType("System.Int32"))
            tbl_.Columns.Add("DESCRIPCION_BODEGA", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                tbl_.Rows.Add(False, row(0), row(1))
            Next
            'Add Columns
            dgvBodegas.Columns(0).Name = "Seleccionar"
            dgvBodegas.Columns(0).HeaderText = "Seleccionar"
            dgvBodegas.Columns(0).DataPropertyName = "Seleccionar"
            dgvBodegas.Columns(1).Name = "BODEGA"
            dgvBodegas.Columns(1).HeaderText = "Bodega"
            dgvBodegas.Columns(1).DataPropertyName = "BODEGA"
            dgvBodegas.Columns(2).Name = "DESCRIPCION_BODEGA"
            dgvBodegas.Columns(2).HeaderText = "Descripciòn"
            dgvBodegas.Columns(2).DataPropertyName = "DESCRIPCION_BODEGA"
            dgvBodegas.Columns(1).Visible = False
            dgvBodegas.DataSource = tbl_

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub loadProductos(ByVal clear_ As Boolean, ByVal descrip_ As String)
        Try
            Dim prod_tbl_ As New DataTable
            Me.getSubGrupos()
            Dim parameter_ As String = String.Empty
            If descrip_.Trim().Length > 0 Then
                parameter_ = ", @DESCRIP='" + descrip_ + "'"
            End If

            dgvProductos.DataSource = Nothing
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            sqlCmd.CommandText = "Exec dbo.SP_RESUMEN_COMPRAS_VENTAS_POR_PERIODOS @BANDERA=2, @COMPAÑIA=1, @BODEGAS='', @GRUPOS='" & Me.grupos_ & "', @SUBGRUPOS='" & Me.subgrupos_ & "', @EXISTENCIA=1 " & parameter_

            Tabla = c_data1.obtenerDatos(sqlCmd)


            prod_tbl_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            prod_tbl_.Columns.Add("PRODUCTO", Type.GetType("System.Int32"))
            prod_tbl_.Columns.Add("DESCRIPCION_PRODUCTO", Type.GetType("System.String"))

            For Each row As DataRow In Tabla.Rows
                prod_tbl_.Rows.Add(False, row(0), row(1))
            Next
            'Add Columns
            If Not clear_ Then
                dgvProductos.Columns(0).Name = "Seleccionar"
                dgvProductos.Columns(0).HeaderText = "Seleccionar"
                dgvProductos.Columns(0).DataPropertyName = "Seleccionar"
                dgvProductos.Columns(1).Name = "PRODUCTO"
                dgvProductos.Columns(1).HeaderText = "Código"
                dgvProductos.Columns(1).DataPropertyName = "PRODUCTO"
                dgvProductos.Columns(2).Name = "DESCRIPCION_PRODUCTO"
                dgvProductos.Columns(2).HeaderText = "Descripciòn"
                dgvProductos.Columns(2).DataPropertyName = "DESCRIPCION_PRODUCTO"
                dgvProductos.Columns(1).Visible = False
            End If
            dgvProductos.DataSource = prod_tbl_
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub loadSubGrupos()
        Try
            dgvSubGrupos.DataSource = Nothing
            Dim TablaSubGroup As DataTable
            Dim sqlCmd2 As New SqlCommand
            sqlCmd2.CommandText = "SELECT G.GRUPO, S.SUBGRUPO, (RTRIM(LTRIM(G.DESCRIPCION_GRUPO)) + ' - ' + (RTRIM(LTRIM(S.DESCRIPCION_SUBGRUPO)))) As 'DESCIPCION' FROM dbo.INVENTARIOS_CATALOGO_GRUPOS G INNER JOIN dbo.INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS S ON G.GRUPO=S.GRUPO WHERE G.COMPAÑIA=" & Compañia & " AND G.CAFETERIA = 0 ORDER BY G.GRUPO, S.SUBGRUPO"

            TablaSubGroup = c_data1.obtenerDatos(sqlCmd2)
            Dim tbl2_ As New DataTable
            tbl2_.Columns.Add("Seleccionar", Type.GetType("System.Boolean"))
            tbl2_.Columns.Add("GRUPO", Type.GetType("System.Int32"))
            tbl2_.Columns.Add("SUBGRUPO", Type.GetType("System.Int32"))
            tbl2_.Columns.Add("DESCIPCION", Type.GetType("System.String"))

            For Each row As DataRow In TablaSubGroup.Rows
                tbl2_.Rows.Add(False, row(0), row(1), row(2))
            Next
            'Add Columns
            dgvSubGrupos.Columns(0).Name = "Seleccionar"
            dgvSubGrupos.Columns(0).HeaderText = "Seleccionar"
            dgvSubGrupos.Columns(0).DataPropertyName = "Seleccionar"
            dgvSubGrupos.Columns(1).Name = "GRUPO"
            dgvSubGrupos.Columns(1).HeaderText = "Grupo"
            dgvSubGrupos.Columns(1).DataPropertyName = "GRUPO"
            dgvSubGrupos.Columns(2).Name = "SUBGRUPO"
            dgvSubGrupos.Columns(2).HeaderText = "Sub Grupo"
            dgvSubGrupos.Columns(2).DataPropertyName = "SUBGRUPO"
            dgvSubGrupos.Columns(3).Name = "DESCIPCION"
            dgvSubGrupos.Columns(3).HeaderText = "Grupo y Sub Grupo"
            dgvSubGrupos.Columns(3).DataPropertyName = "DESCIPCION"

            dgvSubGrupos.Columns(1).Visible = False
            dgvSubGrupos.Columns(2).Visible = False
            dgvSubGrupos.DataSource = tbl2_

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub getBodegas()
        bodegas_ = String.Empty
        For Each oRow As DataGridViewRow In dgvBodegas.Rows
            If oRow.Cells("SELECCIONAR").Value = True Then
                bodegas_ = bodegas_ & oRow.Cells("BODEGA").Value & ","
            End If
        Next
        bodegas_ = bodegas_.TrimEnd(",")
    End Sub

    Private Sub getSubGrupos()
        subgrupos_ = String.Empty
        grupos_ = String.Empty
        Dim single_value_ As String = String.Empty
        For Each oRow As DataGridViewRow In dgvSubGrupos.Rows
            If oRow.Cells("SELECCIONAR").Value = True Then
                subgrupos_ = subgrupos_ & oRow.Cells("SUBGRUPO").Value & ","
                If Not single_value_.Equals(oRow.Cells("GRUPO").Value.ToString()) Then
                    single_value_ = oRow.Cells("GRUPO").Value.ToString()
                    grupos_ = grupos_ & oRow.Cells("GRUPO").Value & ","
                End If
            End If
        Next
        subgrupos_ = subgrupos_.TrimEnd(",")
        grupos_ = grupos_.TrimEnd(",")
    End Sub

    Private Sub getProductos()
        Me.productos_ = String.Empty
        For Each oRow As DataGridViewRow In dgvProductos.Rows
            If oRow.Cells("SELECCIONAR").Value = True Then
                Me.productos_ = Me.productos_ & oRow.Cells("PRODUCTO").Value & ","
            End If
        Next
        Me.productos_ = Me.productos_.TrimEnd(",")
    End Sub

    Private Sub allBodegas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allBodegas.CheckedChanged
        If allBodegas.Checked Then
            For Each fila As DataGridViewRow In dgvBodegas.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvBodegas.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            For Each fila As DataGridViewRow In dgvSubGrupos.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvSubGrupos.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub allProducts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allProducts.CheckedChanged
        If allProducts.Checked Then
            For Each fila As DataGridViewRow In dgvProductos.Rows
                fila.Cells(0).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvProductos.Rows
                fila.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.dtpDesde.Value <= Me.dtpHasta.Value Then
            Me.getBodegas()
            Me.getSubGrupos()
            Me.getProductos()

            If bodegas_.Trim().Length > 0 Then
                If subgrupos_.Trim().Length > 0 Then
                    btnPrint.Visible = False
                    BackgroundWorker1.RunWorkerAsync()
                Else
                    MsgBox("No ha seleccionado Sub Grupos", MsgBoxStyle.Critical, "Sistema")
                End If
            Else
                MsgBox("No ha selecciones una bodega", MsgBoxStyle.Critical, "Sistema")
            End If

        Else
            MsgBox("La fecha Desde debe ser menor que la fecha Hasta.", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim _months As Integer
        Dim _years As Integer
        Dim _in_month As Integer = Me.dtpDesde.Value.Month
        Dim _range As String = String.Empty
        Dim _current_year As String = String.Empty

        _months = DateDiff(DateInterval.Month, Me.dtpDesde.Value, Me.dtpHasta.Value) + Me.dtpDesde.Value.Month
        _years = DateDiff(DateInterval.Year, Me.dtpDesde.Value, Me.dtpHasta.Value)

        '========================================================================='
        For number As Integer = Me.dtpDesde.Value.Month To _months Step 1
            If number <= 12 Then
                _current_year = "/" & Me.dtpDesde.Value.Year.ToString()
            Else
                _current_year = "/" & Me.dtpHasta.Value.Year.ToString()
            End If

            If _in_month = 13 Then
                _in_month = 1
            End If

            If _in_month <= 9 Then
                _range &= "01/0" & _in_month.ToString() & _current_year & ","
            Else
                _range &= "01/" & _in_month.ToString() & _current_year & ","
            End If
            _in_month = _in_month + 1
        Next

        '========================================================================='
        _in_month = Me.dtpDesde.Value.Month
        Dim _encabe_columns As String = String.Empty
        _current_year = String.Empty

        For number As Integer = Me.dtpDesde.Value.Month To _months Step 1
            If number <= 12 Then
                _current_year = Me.dtpDesde.Value.Year.ToString()
            Else
                _current_year = Me.dtpHasta.Value.Year.ToString()
            End If

            If _in_month = 13 Then
                _in_month = 1
            End If

            _encabe_columns &= "[" & getMonthInText(_in_month) & _current_year & "],"
            _in_month = _in_month + 1
        Next


        '========================================================================='
        Dim _all_columns As String = String.Empty

        _in_month = Me.dtpDesde.Value.Month
        Dim _T1_columns As String = String.Empty
        Dim _entradas_totales As String = String.Empty
        _current_year = String.Empty

        For number As Integer = Me.dtpDesde.Value.Month To _months Step 1
            If number <= 12 Then
                _current_year = Me.dtpDesde.Value.Year.ToString()
            Else
                _current_year = Me.dtpHasta.Value.Year.ToString()
            End If

            If _in_month = 13 Then
                _in_month = 1
            End If

            _T1_columns &= "Tmp1." & getMonthInText(_in_month) & _current_year & " As [Ingresos " & getMonthInText(_in_month) & _current_year & "],"
            _entradas_totales &= "Tmp1." & getMonthInText(_in_month) & _current_year & "+"
            _all_columns &= "Tmp1." & getMonthInText(_in_month) & _current_year & ","
            _in_month = _in_month + 1
        Next

        '========================================================================='
        _in_month = Me.dtpDesde.Value.Month
        Dim _T2_columns As String = String.Empty
        Dim _salidas_totales As String = String.Empty
        _current_year = String.Empty

        For number As Integer = Me.dtpDesde.Value.Month To _months Step 1
            If number <= 12 Then
                _current_year = Me.dtpDesde.Value.Year.ToString()
            Else
                _current_year = Me.dtpHasta.Value.Year.ToString()
            End If

            If _in_month = 13 Then
                _in_month = 1
            End If

            _T2_columns &= "Tmp2." & getMonthInText(_in_month) & _current_year & " As [Salidas " & getMonthInText(_in_month) & _current_year & "],"
            _salidas_totales &= "Tmp2." & getMonthInText(_in_month) & _current_year & "+"
            _all_columns &= "Tmp2." & getMonthInText(_in_month) & _current_year & ","
            _in_month = _in_month + 1
        Next

        _entradas_totales = "(" & _entradas_totales.TrimEnd("+") & ") As [Cant. Ingresadas en el Año], Tmp1.COSTO_UNITARIO As [Costo Unitario Actual]"
        Dim columns_ As String = _T1_columns & _entradas_totales & ", Tmp2.PRODUCTO As [Salidas Codigo], " & _T2_columns.TrimEnd(",")
        _salidas_totales = "(" & _salidas_totales.TrimEnd("+") & ")"
        _range = _range.TrimEnd(",")
        _all_columns = _all_columns.TrimEnd(",")
        _encabe_columns = _encabe_columns.TrimEnd(",")
        BackgroundWorker1.ReportProgress(0)
        BackgroundWorker1.ReportProgress(20)
        Dim sqlCmdExec As New SqlCommand
        BackgroundWorker1.ReportProgress(35)
        sqlCmdExec.CommandText = "Exec dbo.SP_RESUMEN_COMPRAS_VENTAS_POR_PERIODOS @BANDERA=1, @COMPAÑIA = " & Compañia & ", @USUARIO='" & Usuario & "', @FECHA_DESDE='" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "', @FECHA_HASTA='" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "', @BODEGAS='" & Me.bodegas_.Trim() & "', @GRUPOS='" & Me.grupos_.Trim() & "', @SUBGRUPOS='" & Me.subgrupos_.Trim() & "', @PRODUCTOS='" & Me.productos_.Trim() & "', @EXISTENCIA=" & IIf(Me.radConExistencias.Checked, 1, 0) & ", @RANGO_FRECHAS ='" & _range & "', @RANGO_ENCABE='" & _encabe_columns & "', @COLUMNS='" & columns_ & "', @SALIDAS_ANUALES='" & _salidas_totales & "', @ALLCOLUMNS='" & _all_columns & "'"
        BackgroundWorker1.ReportProgress(50)
        TablaExec = c_data1.obtenerDatos(sqlCmdExec)
        BackgroundWorker1.ReportProgress(100)
    End Sub

    Public Function getMonthInText(ByVal number As Integer) As String
        Dim _mont As String
        Select Case number
            Case 1
                _mont = "Ene"
            Case 2
                _mont = "Feb"
            Case 3
                _mont = "Mar"
            Case 4
                _mont = "Abr"
            Case 5
                _mont = "May"
            Case 6
                _mont = "Jun"
            Case 7
                _mont = "Jul"
            Case 8
                _mont = "Ago"
            Case 9
                _mont = "Sep"
            Case 10
                _mont = "Oct"
            Case 11
                _mont = "Nov"
            Case Else
                _mont = "Dic"
        End Select
        Return _mont
    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        btnPrint.Visible = True
        'RemoveEmptyColumns(TablaExec)
        report_show_._table_rep = TablaExec
        report_show_.ShowDialog()
        'Try
        '    If MsgBox("Desea exportar el reporte directamente a Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
        '        Dim Rpt As New Inventarios_Reporte_Analisis_Rotacion_Excel
        '        Rpt.SetDataSource(TablaExec)
        '        Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ReporteAnalizarInventarios.xls")
        '        MsgBox("Se exporto el reporte con el nombre: ReporteAnalizarInventarios, en Mis Documentos", MsgBoxStyle.Information, "Sistema")
        '    Else
        '        
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub

    Function RemoveEmptyColumns(ByVal Datatable As DataTable) As Boolean
        Dim mynetable As DataTable = Datatable.Copy
        Dim counter As Integer = mynetable.Rows.Count

        For Each col As DataColumn In mynetable.Columns
            Dim dr() As DataRow = mynetable.Select(col.ColumnName + " is   Null ")
            If dr.Length = counter Then
                Datatable.Columns.Remove(col.ColumnName)
                Datatable.AcceptChanges()
            End If
        Next col
        
        Return True
    End Function

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub txtFinderProducts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinderProducts.TextChanged
        Me.loadProductos(True, Me.txtFinderProducts.Text.Trim())
    End Sub

    Private Sub dgvSubGrupos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubGrupos.CellClick
        dgvProductos.DataSource = Nothing
        Me.loadProductos(True, String.Empty)
    End Sub

    'Public Overloads Function DateDiff( ByVal Interval As [DateInterval | String ], ByVal Date1 As DateTime, ByVal Date2 As DateTime, Optional ByVal DayOfWeek As FirstDayOfWeek = FirstDayOfWeek.Sunday, Optional ByVal  WeekOfYear As FirstWeekOfYear = FirstWeekOfYear.Jan1) As Long

End Class