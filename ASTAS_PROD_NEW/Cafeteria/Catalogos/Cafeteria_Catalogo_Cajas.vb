Public Class Cafeteria_Catalogo_Cajas
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Private Sub Cafeteria_Catalogo_Cajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        'LLENA EL COMBO DE BODEGAS
        c_data2.CargaBodegas(Compañia, Me.cbCafeteria, 9)
        CargarGrid(Compañia, 5)
        Me.btnLimpiar.PerformClick()
        Iniciando = False
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim respuesta As MsgBoxResult            
            respuesta = MsgBox("Desea guardar los datos de la caja?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")

            If Me.Descripcion.Text = Nothing Or numeroCaja.Text = Nothing Or codigoCaja.Text = Nothing Then
                MsgBox("Descripción, Numero de caja y Contraseña no deben estar vacío", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Faltan Datos")
                Me.Descripcion.Text = ""
            Else
                If respuesta = MsgBoxResult.Yes Then
                    c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cbCafeteria.SelectedValue & ", @CAJA=" & numeroCaja.Text & ", @CODIGO_CAJA='" & codigoCaja.Text & "', @DESCRIPCION='" & Descripcion.Text & "', @DESCRIPCION_2='" & Descripcion_2.Text & "', @DESCRIPCION_3='" & Descripcion_3.Text & "', @USUARIO='" & Usuario & "', @BANDERA=1, @TIPO_IMPRESOR=" & Print_Fiscal.Checked)
                    CargarGrid(Compañia, 5)
                    soloLimpiar()
                    MsgBox("La Caja ha sido agregada con exito!", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error...Ocurrio un problema a la hora de ingresar el dato", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub soloLimpiar()
        numeroCaja.Text = ""
        Descripcion.Text = ""
        Descripcion_2.Text = ""
        Descripcion_3.Text = ""
        codigoCaja.Text = ""
    End Sub
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Public Sub limpiar()
        numeroCaja.Text = ""
        Descripcion.Text = ""
        Descripcion_2.Text = ""
        Descripcion_3.Text = ""
        codigoCaja.Text = ""
        numeroCaja.Text = c_data2.leerDataeader("SELECT ISNULL(MAX(CAJA), 0)+1 FROM CAFETERIA_CATALOGO_BODEGA_CAJA WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & cbCafeteria.SelectedValue, 0)
        c_data2.cerrarConexion()
    End Sub
    Sub CargarGrid(ByVal CIA, ByVal SIUD)
        Try
            DS01.Reset()
            cadenaSIUD(CIA, SIUD)
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.gridCajas.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()
            'Ocultar columnas
            'Me.dgvMovtos.Columns.Item(0).Visible = False 'Compañia
            'justificar derecha
            'Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight            

            For i As Integer = 0 To gridCajas.ColumnCount - 1
                gridCajas.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
            gridCajas.Columns.Item(1).Visible = False
        Catch ex As Exception
            MsgBox("Error...Ocurrio un problema a la hora de cargar Datos", MsgBoxStyle.Information)

        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD)
        SQL = "Execute [dbo].[sp_CAFETERIA_CATALOGO_BODEGA_CAJA] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & cbCafeteria.SelectedValue
        SQL &= ",@BANDERA = " & SIUD
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea eliminar la caja?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            Try
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cbCafeteria.SelectedValue & ", @CAJA=" & numeroCaja.Text & ",@BANDERA=3")
                CargarGrid(Compañia, 5)
                soloLimpiar()
                MsgBox("La Caja ha sido eliminada con exito!", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("La Caja NO ha sido eliminada!", MsgBoxStyle.Information)
            End Try            
        End If
    End Sub

    Private Sub gridCajas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCajas.CellClick
        numeroCaja.Text = gridCajas.CurrentRow.Cells(0).Value        
        codigoCaja.Text = gridCajas.CurrentRow.Cells(1).Value

        Try
            Descripcion.Text = gridCajas.CurrentRow.Cells(2).Value
        Catch ex As Exception
            Descripcion.Text = ""
        End Try
        Try
            Descripcion_2.Text = gridCajas.CurrentRow.Cells(3).Value
        Catch ex As Exception
            Descripcion_2.Text = ""
        End Try
        Try
            Descripcion_3.Text = gridCajas.CurrentRow.Cells(4).Value
        Catch ex As Exception
            Descripcion_3.Text = ""
        End Try
        Try
            Print_Fiscal.Checked = gridCajas.CurrentRow.Cells(8).Value
        Catch ex As Exception
            Print_Fiscal.Checked = False
        End Try        
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If (Iniciando = False) Then
            numeroCaja.Text = c_data2.leerDataeader("SELECT ISNULL(MAX(CAJA), 0)+1 FROM CAFETERIA_CATALOGO_BODEGA_CAJA WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & cbCafeteria.SelectedValue, 0)
            CargarGrid(Compañia, 5)
            limpiar()
        End If        
    End Sub

    Private Sub numeroCaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numeroCaja.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class