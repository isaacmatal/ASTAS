Public Class Cafeteria_Catalogo_Cajeros
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim Iniciando2 As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim eliminar As Boolean = False
    Private Sub Cafeteria_Catalogo_Cajeros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        txtCompañia.Text = Descripcion_Compañia
        c_data2.CargaBodegas(Compañia, Me.cmbBODEGA, 9)
        cargarCajas()
        c_data2.CargarCombo(Me.cmbUsuarios, "Execute sp_CATALOGO_USUARIOS " & Compañia & ", '', '', 0 ", "USUARIO", "USUARIO_COMPLETO")
        cadenaSIUD(Compañia, "S")
        CargarGrid()
        Iniciando = False
    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            cadenaSIUD(Compañia, "S1")
            CargarGrid()
        End If
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD)        

        SQL = "Execute [dbo].[sp_CAFETERIA_CATALOGO_CAJEROS_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & Me.cmbBODEGA.SelectedValue
        SQL &= ",@CAJA  = " & Me.cmbCajas.SelectedValue
        SQL &= ",@USUARIO_ASIGNADO = '" & Me.cmbUsuarios.SelectedValue & "'"
        SQL &= ",@USUARIO = '" & Usuario & "'"
        SQL &= ",@FECHA = '" & Format(dtpFechaTrabajo.Value, "dd-MM-yyyy 00:00:01") & "'"
        SQL &= ",@BANDERA = '" & SIUD & "'"

    End Sub    
    Sub CargarGrid()
        Try
            DS01.Reset()
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()
            ''Ocultar columnas
            For i As Integer = 0 To 1
                Me.dgvMovtos.Columns.Item(i).Visible = False 'Compañia
            Next
            'Me.dgvMovtos.Columns.Item(0).Visible = False 'Compañia
            'justificar derecha
            'Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight            
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
            c_data2.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            c_data2.CargarCombo(Me.cmbUsuarios, "Execute sp_CATALOGO_USUARIOS " & Compañia & ", '', '', 0 ", "USUARIO", "USUARIO_COMPLETO")            
            dgvMovtos.DataSource = Nothing
        End If
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            Iniciando2 = False
        End If
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            cadenaSIUD(Compañia, "S1")
            CargarGrid()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click        

        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea agregar un nuevo Cajero?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then

            cadenaSIUD(Compañia, "I")
            c_data2.Ejecutar_ConsultaSQL(SQL)

            cadenaSIUD(Compañia, "S")
            CargarGrid()
            MsgBox("La Cajaro ha sido agregado con exito!", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Public Sub limpiar()
        Me.cmbCajas.SelectedIndex = 0
        Me.cmbUsuarios.SelectedIndex = 0
        Me.cmbBODEGA.SelectedIndex = 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea eliminar el Cajero?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            If (eliminar = True) Then

                c_data2.Ejecutar_ConsultaSQL(SQL)

                cadenaSIUD(Compañia, "S")
                CargarGrid()         
                eliminar = False
                MsgBox("La Cajaro ha sido eliminado con exito!", MsgBoxStyle.Information)
            Else
                MsgBox("Debe seleccionar un cajero a eliminar!", MsgBoxStyle.Information)
            End If
        End If
    End Sub


    Private Sub dgvMovtos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMovtos.Click
        eliminar = True
        SQL = "Execute [dbo].[sp_CAFETERIA_CATALOGO_CAJEROS_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & dgvMovtos.CurrentRow.Cells(1).Value.ToString()
        SQL &= ",@CAJA  = " & dgvMovtos.CurrentRow.Cells(2).Value.ToString()
        SQL &= ",@USUARIO_ASIGNADO = '" & dgvMovtos.CurrentRow.Cells(4).Value.ToString() & "'"
        SQL &= ",@USUARIO = '" & Usuario & "'"
        SQL &= ",@FECHA = '" & Format(dtpFechaTrabajo.Value, "dd-MM-yyyy 00:00:01") & "'"
        SQL &= ",@BANDERA = 'D'"

    End Sub
End Class