Public Class Cafeteria_Descuento_X_Empleado
    Dim comandos As New jarsClass
    'TABLA TEMPORAL PARA LA BUSQUEDAS DINAMICAS
    Dim Table As New DataTable("Datos")
    Dim Iniciando As Boolean

    Private Sub Cafeteria_Descuento_X_Empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        'Iniciamos el proceso pesado
        'Bw1.RunWorkerAsync() 
        CargarSocios()
        FiltrarSocios()
        Iniciando = False

        Me.TxtNombreB.Focus()
    End Sub

    
    Private Sub CargarSocios()
        Table = comandos.ejecutaSQLl_llenaDTABLE("EXEC sp_CAFETERIA_DESCUENTOS_X_EMPLEADOS_SIUD @COMPAÑIA=" & Compañia & ",@CODIGO_EMPLEADO=0,@CODIGO_EMPLEADO_AS='',@CODIGO=0 ,@BANDERA= 3, @BLOQUEADO=0,@USUARIO='" & Usuario & "'")
    End Sub

#Region "Metodo de filtrado de empleados"
    Private Sub FiltrarSocios()
        If Table.Rows.Count > 0 Then
            Dim colNombre As Integer = 3 'Valor numero de la columna "Nombre" del DataGridView.
            Dim colCod As Integer = 2 'valor numero de la columna "codigo empleado"
            Dim colBuxis As Integer = 1 'valor numer de la columna "codigo buxis"

            If TxtNombreB.Text = "" And TxtCodigoAsB.Text = "" And TxtCodigoBuxisB.Text = "" Then
                Me.DgvDescuentoSocios.DataSource = Table
                Me.DgvDescuentoSocios.Columns(0).Visible = False
                Me.DgvDescuentoSocios.Columns(1).HeaderText = "CODIGO BUXIS"
                Me.DgvDescuentoSocios.Columns(2).HeaderText = "CODIGO AS"
                Me.DgvDescuentoSocios.Columns(3).HeaderText = "NOMBRE"
                Me.DgvDescuentoSocios.Sort(Me.DgvDescuentoSocios.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
            Else
                Dim tablaT As DataTable = Table.Clone()
                Dim cadenaFiltrado As String = ""

                'FILTRADO POR NOMBRE
                'cadenaFiltrado += "[" & DgvDescuentoSocios.Columns(colNombre).Name & "] like '%" & TxtNombreB.Text & "%'"
                cadenaFiltrado += "[NOMBRE_COMPLETO] like '" & TxtNombreB.Text & "%'"

                'FILTRADO POR COD EMPLEADO
                If TxtCodigoAsB.Text <> "" Then
                    'cadenaFiltrado += " AND [" & DgvDescuentoSocios.Columns(colCod).Name & "] = '" & TxtCodigoAsB.Text & "'"
                    cadenaFiltrado += " AND [CODIGO_EMPLEADO_AS] = '" & TxtCodigoAsB.Text & "'"
                End If

                'FILTRADO POR COD BUXIS
                If TxtCodigoBuxisB.Text <> "" Then
                    'cadenaFiltrado += " AND [" & DgvDescuentoSocios.Columns(colBuxis).Name & "] = " & TxtCodigoBuxisB.Text
                    cadenaFiltrado += " AND [CODIGO_EMPLEADO] = " & TxtCodigoBuxisB.Text
                End If

                Dim rows As DataRow()
                rows = Table.Select(cadenaFiltrado)
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.DgvDescuentoSocios.DataSource = tablaT
                Me.DgvDescuentoSocios.Columns(0).Visible = False
                'Me.DgvDescuentoSocios.Columns(5).Visible = False
                Me.DgvDescuentoSocios.Columns(1).HeaderText = "CODIGO BUXIS"
                Me.DgvDescuentoSocios.Columns(2).HeaderText = "CODIGO AS"
                Me.DgvDescuentoSocios.Columns(3).HeaderText = "NOMBRE"
                Me.DgvDescuentoSocios.Sort(Me.DgvDescuentoSocios.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Else
            MsgBox("No se ha terminado de almacenar en memoria los datos." & vbNewLine & "Favor espere un momento, para realizar nuevamente la busqueda.")
        End If
        
    End Sub
#End Region



    'DEVUELVE LAS FILAS DE SOCIOS CKEKEADAS
    'Private Function EmpleadosSeleccionados() As DataRow()
    '    Dim tbl As DataTable = DgvDescuentoSocios.DataSource
    '    If tbl IsNot Nothing Then
    '        Return tbl.Select("[" & DgvDescuentoSocios.Columns(6).Name & "] = 'True'")
    '    Else
    '        Return Nothing
    '    End If
    'End Function

#Region "Eventos que permiten el filtrado de empleados"
    Private Sub TxtNombreB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreB.TextChanged
        If Iniciando = False Then
            Try
                FiltrarSocios()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Validación")
            End Try
        End If
        
    End Sub

    Private Sub TxtCodigoBuxisB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoBuxisB.TextChanged
        If Iniciando = False Then
            Try
                FiltrarSocios()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Validación")
            End Try
        End If
    End Sub

    Private Sub TxtCodigoAsB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoAsB.TextChanged
        If Iniciando = False Then
            Try
                FiltrarSocios()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Validación")
            End Try
        End If       
    End Sub
#End Region

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Iniciando = False Then
            'If Me.CheckBox1.Checked = True Then

            'Else
            '    If MsgBox("Adicionar empleado a tipo descuento escogido?.", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then

            '        Dim rows As DataRow() = EmpleadosSeleccionados()
            '        If rows IsNot Nothing Then
            '            'Try
            '            'EJECUTAR LA ACTUALIZACION POR CADA UNA DE LAS FILAS SELECCIONADAS
            '            For i As Integer = 0 To rows.Length - 1
            '                'comandos.Ejecutar_ConsultaSQL("exec sp_CAFETERIA_DESCUENTOS_X_EMPLEADOS_SIUD @COMPAÑIA=" & rows(i).Item(0) & ",@CODIGO_EMPLEADO=" & rows(i).Item(1) & ",@CODIGO_EMPLEADO_AS='" & rows(i).Item(2).ToString().Trim() & "',@CODIGO= 1 ,@BANDERA=" & 1 & ",@BLOQUEADO=" & bloqueado)
            '            Next
            '            'Catch ex As Exception
            '            '    MsgBox(ex.Message, MsgBoxStyle.Information, "Error")
            '            'End Try
            '            ReiniciarDataTable()
            '        Else
            '            MsgBox("Favor seleccionar al menos un empleado.!!", MsgBoxStyle.Information, "Validación")
            '        End If

            '    End If
            'End If

            'If MsgBox("Adicionar Todos los empleado a tipo descuento escogido?.", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then

            'End If
            If MsgBox("Desea aplicar los cambios?.", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then
                If DgvDescuentoSocios.RowCount > 0 Then
                    Try
                        Me.BtnGuardar.Enabled = False
                        'EJECUTAR LA ACTUALIZACION POR CADA UNA DE LAS FILAS SELECCIONADAS
                        Dim _bloquear As String = String.Empty
                        For i As Integer = 0 To DgvDescuentoSocios.RowCount - 1
                            If DgvDescuentoSocios.Rows(i).Cells(6).Value Then
                                _bloquear = "1"
                            Else
                                _bloquear = "0"
                            End If
                            comandos.Ejecutar_ConsultaSQL("exec sp_CAFETERIA_DESCUENTOS_X_EMPLEADOS_SIUD @COMPAÑIA=" & DgvDescuentoSocios.Rows(i).Cells(0).Value.ToString() & ",@CODIGO_EMPLEADO=" & DgvDescuentoSocios.Rows(i).Cells(1).Value.ToString() & ",@CODIGO_EMPLEADO_AS='" & DgvDescuentoSocios.Rows(i).Cells(2).Value.ToString().Trim() & "',@CODIGO= 1 ,@BANDERA= 1, @BLOQUEADO=" & _bloquear & ",@USUARIO='" & Usuario & "'")
                        Next

                        ReiniciarDataTable()
                        Me.BtnGuardar.Enabled = True
                        MsgBox("Operación exitosa.", MsgBoxStyle.Information, "Sistema")
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Error")
                    End Try                    
                Else
                    MsgBox("Favor seleccionar al menos un empleado.!!", MsgBoxStyle.Information, "Validación")
                End If
            End If
            

        End If
        
    End Sub

    Private Sub ReiniciarDataTable()
        Dim CeldaSeleccionada As Integer = DgvDescuentoSocios.CurrentRow.Index
        CargarSocios()
        FiltrarSocios()
        Try
            DgvDescuentoSocios.Rows(CeldaSeleccionada).Selected = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Validación")
        End Try
    End Sub

    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        CargarSocios()
    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then

            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.Hide()
        Dim _frm_imprimir As New Cafeteria_Reporte_Empleados_Bloqueados()
        _frm_imprimir.ShowDialog()
        Me.Show()
    End Sub
End Class