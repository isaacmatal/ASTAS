Public Class Cafeteria_Catalogo_Plantas
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Private Sub Cafeteria_Catalogo_Plantas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        CargarGrid(Compañia, "S1")
        Me.btnLimpiar.PerformClick()
        Iniciando = False
    End Sub
    Sub CargarGrid(ByVal CIA, ByVal SIUD)
        Try
            DS01.Reset()
            cadenaSIUD(CIA, SIUD)
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.gridPlantas.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()            

            For i As Integer = 0 To gridPlantas.ColumnCount - 1
                gridPlantas.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
            gridPlantas.Columns.Item(1).Visible = False
        Catch ex As Exception
            MsgBox("Error...Ocurrio un problema a la hora de cargar Datos", MsgBoxStyle.Information)
        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD)
        SQL = "Execute [dbo].[sp_CAFETERIA_PLANTAS] "
        SQL &= "@COMPAÑIA = " & CIA        
        SQL &= ",@BANDERA = " & SIUD
        If SIUD = "I" Or SIUD = "S" Or SIUD = "D" Then
            SQL &= ",@PLANTA = " & numeroPlanta.Text
            If SIUD = "I" Then
                SQL &= ",@DESCRIPCION_PLANTA = '" & Descripcion.Text & "'"
                SQL &= ",@USUARIO = '" & Usuario & "'"
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        numeroPlanta.Text = ""
        Descripcion.Text = ""
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Descripcion.Text.Length = 0 Then
            MsgBox("Debe asignar una descripcion a la planta!", MsgBoxStyle.Information)
        Else
            SQL = "SELECT ISNULL(MAX(PLANTA), 0)+1 FROM CAFETERIA_CATALOGO_PLANTAS WHERE COMPAÑIA=" & Compañia
            numeroPlanta.Text = c_data2.obtenerEscalar(SQL)
            cadenaSIUD(Compañia, "I")
            c_data2.Ejecutar_ConsultaSQL(SQL)            
            MsgBox("Planta creada con exito!", MsgBoxStyle.Information)
            CargarGrid(Compañia, "S1")
        End If
    End Sub

    Private Sub gridPlantas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridPlantas.Click
        numeroPlanta.Text = gridPlantas.CurrentRow.Cells(1).Value.ToString()
        Descripcion.Text = gridPlantas.CurrentRow.Cells(2).Value.ToString()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea eliminar la planta seleccionada?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            If numeroPlanta.Text.Length = 0 Then
                MsgBox("Debe seleccionar la planta a eliminar!", MsgBoxStyle.Information)
            Else
                cadenaSIUD(Compañia, "D")
                c_data2.Ejecutar_ConsultaSQL(SQL)
                MsgBox("Planta Eliminada con exito!", MsgBoxStyle.Information)
                CargarGrid(Compañia, "S1")
            End If
        End If        
    End Sub
End Class