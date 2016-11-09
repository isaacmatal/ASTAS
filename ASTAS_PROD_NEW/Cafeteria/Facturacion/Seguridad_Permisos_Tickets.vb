Public Class Seguridad_Permisos_Tickets
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim Iniciando2 As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim eliminar As Boolean = False

    Private Sub Seguridad_Permisos_Tickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Iniciando = True
        Me.lblFecha.Text = Date.Now.ToString()
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        txtCompañia.Text = Descripcion_Compañia
        c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 9)
        Iniciando = False
    End Sub

    Sub CargarGrid()
        Try
            SQL = "Execute sp_CAFETERIA_PERMISOS_TICKETS @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue.ToString() & ", @CAJA=" & Me.cmbCajas.SelectedValue.ToString() & ", @BANDERA = 'C'"
            DS01.Reset()
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()
            ''Ocultar columnas
            'For i As Integer = 0 To 1
            '    Me.dgvMovtos.Columns.Item(i).Visible = False 'Compañia
            'Next
            For i As Integer = 0 To dgvMovtos.ColumnCount - 1
                dgvMovtos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar Datos", MsgBoxStyle.Information)

        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub

    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            Iniciando = True
            c_data2.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
            Iniciando = False
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Not Iniciando Then
            cargarCajas()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtNumeroTckets.Text.Length > 0 Then
            Dim respuesta As MsgBoxResult
            respuesta = MsgBox("Desea registrar el Ticket a anular?", MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                SQL = String.Empty
                SQL = "SELECT COUNT(*) FROM CAFETERIA_FACTURACION_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA = " & Me.cmbBODEGA.SelectedValue & " AND CAJA = " & Me.cmbCajas.SelectedValue & " AND CONVERT(DATE, FECHA_FACTURA) = CONVERT(DATE, '" & Date.Now.Date.ToShortDateString() & "') AND NUMERO_FACTURA = " & txtNumeroTckets.Text.Trim()
                Dim existe_ As Integer = c_data2.obtenerEscalar(SQL)
                If existe_ > 0 Then
                    SQL = String.Empty
                    SQL = "Execute sp_CAFETERIA_PERMISOS_TICKETS @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CAJA=" & Me.cmbCajas.SelectedValue & ", @NUMEROTKT= " & txtNumeroTckets.Text.Trim() & ", @USUARIO='" & Usuario & "', @BANDERA = 'I'"
                    c_data2.Ejecutar_ConsultaSQL(SQL)
                    CargarGrid()
                    SQL = String.Empty
                    MsgBox("Registro agregado con exito!", MsgBoxStyle.Information)
                Else
                    MsgBox("Numero de Ticket no existe para las condiciones ingresadas.", MsgBoxStyle.Information)
                End If
                
            End If
        Else
            MsgBox("Ingrese un numero de Ticket.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged
        If Not Iniciando Then
            CargarGrid()
        End If
    End Sub

    Private Sub dgvMovtos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMovtos.Click
        SQL = "Execute sp_CAFETERIA_PERMISOS_TICKETS @COMPAÑIA=" & Compañia & ", @BODEGA=" & dgvMovtos.CurrentRow.Cells(0).Value.ToString() & ", @CAJA=" & dgvMovtos.CurrentRow.Cells(2).Value.ToString().Trim() & ", @NUMEROTKT= " & dgvMovtos.CurrentRow.Cells(3).Value.ToString().Trim() & ", @USUARIO='" & Usuario & "', @BANDERA = 'D'"
        btnEliminar.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Not SQL.Equals(String.Empty) Then
            Dim respuesta As MsgBoxResult
            respuesta = MsgBox("Desea eliminar el registro seleccionado?", MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                Dim tot_rows_ As Integer = dgvMovtos.RowCount
                c_data2.Ejecutar_ConsultaSQL(SQL)
                CargarGrid()
                btnEliminar.Enabled = False
                If Not tot_rows_ = dgvMovtos.RowCount Then
                    MsgBox("Registro eliminado con exito!", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Seleccione un registro para eliminar.", MsgBoxStyle.Information)
        End If
    End Sub
End Class