Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Cafeteria_ProgramarPorFechas
    Dim fill As New cmbFill
    Dim jClass As New jarsClass
    Dim Sql As String
    Dim Ds_ As New DataSet
    Dim Ds2_ As New DataSet
    Dim ListaProductos As New System.Collections.Generic.List(Of String)
    Dim Iniciando As Boolean

    Private Sub Cafeteria_ProgramarPorFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        'AddHandler CustomCalendar1.cmbMonth.SelectedIndexChanged, AddressOf Activar
        'AddHandler CustomCalendar1.cmbYear.SelectedIndexChanged, AddressOf Activar
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBodegas(Compañia, Me.cmbBodega, 10)
        CargarTiempoComida(Compañia, Me.cmbTiempoComida, "S")
        Iniciando = False        
        CargarGrid("", 0)

    End Sub

    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo1 As ComboBox, ByVal IUD As Char)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            jClass.CargarCombo(cmbTiempo1, Sql, "Tiempo de Comida", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.txtBuscar.Text = ""
        Me.txtBuscar_TextChanged(New Object, New System.EventArgs)
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        Guardar(cmbBodega.SelectedValue, cmbTiempoComida.SelectedValue)
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub Guardar(ByVal bodega_ As String, ByVal tiempo_ As String)
        Dim Exito As Boolean = False

        For i As Integer = 0 To dgvRecetas.Rows.Count - 1
            If dgvRecetas.Rows(i).Cells.Item(0).Value Then
                If dgvRecetas.Rows(i).Cells.Item(4).Value > 0 Then
                    Dim cadena_fechas_ As String
                    cadena_fechas_ = CustomCalendar1.GetSelectedDates()
                    If cadena_fechas_.Length > 0 Then
                        Dim fechas_ As String()
                        fechas_ = cadena_fechas_.Split(",")
                        Sql = String.Empty

                        Try
                            Dim dias_ As String
                            For Each dias_ In fechas_
                                Sql &= "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD " & Compañia & "," & bodega_ & "," & tiempo_ & ",'" & dias_ & "'," & dgvRecetas.Rows(i).Cells.Item(1).Value & "," & dgvRecetas.Rows(i).Cells.Item(4).Value & ",'" & Usuario & "'," & " 'I' " & vbCrLf
                            Next
                            jClass.Ejecutar_ConsultaSQL(Sql)
                            Exito = True
                        Catch ex As Exception
                            Exito = False
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
                        End Try
                    Else
                        MsgBox("No ha seleccionado ninguna fecha...", MsgBoxStyle.Information, "Sistema")
                    End If
                Else
                    MsgBox("No ha asignado una cantidad para " & dgvRecetas.Rows(i).Cells.Item(2).Value, MsgBoxStyle.Information, "Sistema")
                End If
            End If
        Next

        If Exito Then
            MsgBox("Operaciòn Exitosa...", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Public Sub Activar(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal codigo_ As String)
        If Not Iniciando Then
            Dim mes_select_ As String = String.Empty
            Try
                Select Case CustomCalendar1.cmbMonth.SelectedItem
                    Case "Enero"
                        mes_select_ = "01"
                    Case "Febrero"
                        mes_select_ = "02"
                    Case "Marzo"
                        mes_select_ = "03"
                    Case "Abril"
                        mes_select_ = "04"
                    Case "Mayo"
                        mes_select_ = "05"
                    Case "Junio"
                        mes_select_ = "06"
                    Case "Julio"
                        mes_select_ = "07"
                    Case "Agosto"
                        mes_select_ = "08"
                    Case "Septiembre"
                        mes_select_ = "09"
                    Case "Octubre"
                        mes_select_ = "10"
                    Case "Noviembre"
                        mes_select_ = "11"
                    Case "Diciembre"
                        mes_select_ = "12"
                End Select
                CustomCalendar1.Crear()
                Dim dias_mes_ As Integer = Date.DaysInMonth(CustomCalendar1.cmbYear.SelectedItem, mes_select_)
                Sql = "SELECT Fecha FROM  CAFETERIA_PROGRAMACION_SEMANAL WHERE COMPAÑIA = " & Compañia & "  AND BODEGA   = " & cmbBodega.SelectedValue & " AND (FECHA BETWEEN '01/" & mes_select_ & "/" & CustomCalendar1.cmbYear.SelectedItem & "' AND '" & dias_mes_ & "/" & mes_select_ & "/" & CustomCalendar1.cmbYear.SelectedItem & "') AND TIEMPO_COMIDA = " & cmbTiempoComida.SelectedValue & " AND CODIGO_PRODUCTO = " & codigo_
                Ds_.Clear()
                jClass.MiddleConnection(Sql)
                jClass.DataAdapter.Fill(Ds_)

                For i As Integer = 0 To Ds_.Tables(0).Rows.Count - 1
                    CustomCalendar1.SetDate(Ds_.Tables(0).Rows(i).Item("Fecha"), False)
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
            End Try
        End If
    End Sub

    Private Sub cmbTiempoComida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiempoComida.SelectedIndexChanged
        'Me.Activar(New Object, New System.EventArgs)
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
        'Me.Activar(New Object, New System.EventArgs)
    End Sub

    Sub CargarGrid(ByVal PROD_DESC, ByVal BANDERA)
        Try
            Ds2_.Reset()
            Sql = "EXECUTE sp_VISTA_INVENTARIOS_BODEGAS_Y_PRODUCTOS_POR_USUARIO_S2 "
            Sql &= "@COMPAÑIA = " & Val(Compañia)
            Sql &= ",@BODEGA = " & Val(cmbBodega.SelectedValue)
            Sql &= ",@PRODUCTO = " & Val(0)
            Sql &= ",@PRODUCTO_DESCRIPCION = ''"
            Sql &= ",@USUARIO = N'" & Usuario & "'"
            Sql &= ",@SIUD = " & BANDERA
            jClass.MiddleConnection(Sql)
            jClass.DataAdapter.Fill(Ds2_)

            dgvRecetas.AutoGenerateColumns = False
            'Set Columns Count
            dgvRecetas.ColumnCount = 5

            'Add Columns
            dgvRecetas.Columns(0).Name = "Seleccionar"
            dgvRecetas.Columns(0).HeaderText = ""
            dgvRecetas.Columns(0).DataPropertyName = "Seleccionar"

            dgvRecetas.Columns(1).Name = "CODIGO"
            dgvRecetas.Columns(1).HeaderText = "Còdigo"
            dgvRecetas.Columns(1).DataPropertyName = "CODIGO"

            dgvRecetas.Columns(2).Name = "DESCRIPCION"
            dgvRecetas.Columns(2).HeaderText = "Descripciòn"
            dgvRecetas.Columns(2).DataPropertyName = "DESCRIPCION"

            dgvRecetas.Columns(3).Name = "UNIDAD"
            dgvRecetas.Columns(3).HeaderText = "Unidad"
            dgvRecetas.Columns(3).DataPropertyName = "UNIDAD"

            dgvRecetas.Columns(4).Name = "Cantidad"
            dgvRecetas.Columns(4).HeaderText = "Cantidad"
            dgvRecetas.Columns(4).DataPropertyName = "Cantidad"
            dgvRecetas.DataSource = Ds2_.Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If Iniciando = False Then
            For c As Integer = 0 To dgvRecetas.RowCount - 1
                If Val(dgvRecetas.Rows(c).Cells(0).Value.ToString()) = 1 Then
                    AgregarSeleccionados(dgvRecetas.Rows(c).Cells(1).Value.ToString(), Val(dgvRecetas.Rows(c).Cells(0).Value.ToString()), dgvRecetas.Rows(c).Cells(4).Value.ToString())
                End If
            Next

            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 1
            Dim Ncolumn As String = dgvRecetas.Columns("DESCRIPCION").Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvRecetas.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            Dim tablaT As DataTable = Ds2_.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4            

            If txtBuscar.Text = "" Then
                Me.dgvRecetas.DataSource = Ds2_.Tables(0)
            Else
                rows = Ds2_.Tables(0).Select("[" & dgvRecetas.Columns("DESCRIPCION").Name & "] like '" & txtBuscar.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next
                Me.dgvRecetas.DataSource = tablaT
            End If
        End If
    End Sub

    Private Sub AgregarSeleccionados(ByVal codigo_ As String, ByVal estado_ As Boolean, ByVal cnt_ As Decimal)
        Try
            For i As Integer = 0 To Ds2_.Tables(0).Rows.Count - 1
                If Ds2_.Tables(0).Rows(i).Item("CODIGO") = codigo_ Then
                    Ds2_.Tables(0).Rows(i).Item(4) = cnt_
                    Ds2_.Tables(0).Rows(i).Item(0) = estado_
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub dgvRecetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvRecetas.Click
        Me.Activar(New Object, New System.EventArgs, dgvRecetas.CurrentRow.Cells(1).Value.ToString())
    End Sub

    Private Sub btnAllMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
    End Sub

    'Private Sub dgvRecetas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecetas.CellClick
    '    Dim estate_ As Boolean
    '    If dgvRecetas.CurrentRow.Cells(1).Value = 0 Then
    '        estate_ = True
    '    Else
    '        estate_ = False
    '    End If
    '    AgregarSeleccionados(dgvRecetas.CurrentRow.Cells(1).Value.ToString(), estate_, dgvRecetas.CurrentRow.Cells(4).Value)
    'End Sub

    Private Sub chkSelectAllMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAllMonth.CheckedChanged
        If Me.chkSelectAllMonth.CheckState = CheckState.Checked Then
            CustomCalendar1.SetAllDateOfMonth(False)
        Else
            CustomCalendar1.SetAllDateOfMonth(True)
        End If
    End Sub
End Class