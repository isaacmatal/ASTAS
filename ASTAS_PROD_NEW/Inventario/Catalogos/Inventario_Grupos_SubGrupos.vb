Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Inventario_Grupos_SubGrupos
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table As DataTable
    Dim Table1 As DataTable
    Dim bandera As Boolean = False
    Dim bandera1 As Boolean = False
    Dim jclass As New jarsClass

    Private Sub Inventario_Grupos_SubGrupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True        
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaGrupos(Compañia, 3)
        CargaSubGrupos(Compañia, Val(Me.lblGRUPO.Text), 1)
        Me.txtdescmaximo.Text = 0
        Iniciando = False
    End Sub
    Private Sub LimpiaCamposGrupo()
        Me.lblGRUPO.Text = ""
        Me.txtDESCRIPCION_GRUPO.Text = ""
        Me.txtMARGEN.Text = ""
        Me.chkMARGEN.Checked = False
        chkPertenece.Checked = False
    End Sub

    Private Sub LimpiaCamposSubGrupo()
        Me.lblSUB_GRUPO.Text = ""
        Me.txtDESCRIPCION_SUB_GRUPO.Text = ""
        'modificado por Mauricio José
        Me.txtdescmaximo.Text = ""
        'fin modificación
    End Sub

    Private Sub LimpiaGridGrupos()
        Me.dgvGrupos.Columns(1).Width = 200
        Me.dgvGrupos.Columns(3).Width = 85
        Me.dgvGrupos.Columns(4).Width = 75
        Me.dgvGrupos.Columns(5).Width = 125
        Me.dgvGrupos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvGrupos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Me.dgvGrupos.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvGrupos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub LimpiaGridSubGrupos()
        Me.dgvSubGrupos.Columns(1).Width = 200
        Me.dgvSubGrupos.Columns(2).Width = 75
        Me.dgvSubGrupos.Columns(3).Width = 125
        Me.dgvSubGrupos.Columns(4).Width = 75
        Me.dgvSubGrupos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvSubGrupos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub CargaGrupos(ByVal Compañia, ByVal Bandera)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvGrupos.Columns.Clear()
            Me.dgvGrupos.DataSource = Table
            dgvGrupos.Columns.Item(6).Visible = False
            LimpiaGridGrupos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaSubGrupos(ByVal Compañia, ByVal Grupo, ByVal Bandera)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS "
            Sql &= Compañia
            Sql &= ", " & Grupo
            Sql &= ", " & Bandera
            Table1 = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvSubGrupos.Columns.Clear()
            Me.dgvSubGrupos.DataSource = Table1
            LimpiaGridSubGrupos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Grupos(ByVal Compañia, ByVal Grupo, ByVal Descripcion, ByVal Margen, ByVal IUD, ByVal pertenece)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Grupo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & Margen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", " & pertenece
            jclass.ejecutarComandoSql(New SqlCommand(Sql))
            Select Case IUD
                Case "I"
                    MsgBox("¡Grupo de Productos Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Grupo de Productos Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Grupo de Productos Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_SubGrupos(ByVal Compañia, ByVal Grupo, ByVal SubGrupo, ByVal Descripcion, ByVal DescMaximo, ByVal IUD)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS_IUD  "
            Sql &= " @COMPAÑIA = " & Compañia
            Sql &= ",@GRUPO = '" & Grupo & "'"
            Sql &= ",@SUBGRUPO = '" & SubGrupo & "'"
            Sql &= ",@DESCRIPCION_SUBGRUPO = '" & Descripcion & "'"
            Sql &= ",@USUARIO = '" & Usuario & "'"
            Sql &= ",@DESCMAXIMO = " & DescMaximo
            Sql &= ",@IUD = '" & IUD & "'"
            Sql &= ",@CESC = " & IIf(Me.CheckBox1.Checked, "1", "0")
            jclass.ejecutarComandoSql(New SqlCommand(Sql))
            Select Case IUD
                Case "I"
                    MsgBox("¡Sub Grupo de Productos Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Sub Grupo de Productos Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Sub Grupo de Productos Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCamposGrupos() As Boolean
        If Trim(Me.txtDESCRIPCION_GRUPO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Grupo válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.chkMARGEN.Checked = True And Trim(Me.txtMARGEN.Text) = "" Then
            MsgBox("¡Debe ingresar un valor de Margen válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ValidaCamposSubGrupos() As Boolean
        If Trim(Me.lblGRUPO.Text) = "" Then
            MsgBox("¡Debe seleccionar un Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtDESCRIPCION_SUB_GRUPO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Sub Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If

        'agregado por Mauricio José
        If Trim(Me.txtdescmaximo.Text) = "" Then
            MsgBox("¡Debe ingresar un porcentaje maximo de descuento para el subgrupo válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        'fin modificación

        Return True
    End Function

    Private Sub chkMARGEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMARGEN.CheckedChanged
        Me.txtMARGEN.Enabled = Me.chkMARGEN.Checked
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaGrupos(Compañia, 3)
        End If
    End Sub

    Private Sub btnGuardarGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarGrupos.Click
        If ValidaCamposGrupos() = True Then
            If Trim(Me.lblGRUPO.Text) = "" Then
                Mantenimiento_Grupos(Compañia, Me.lblGRUPO.Text.PadLeft(2, "0"), Me.txtDESCRIPCION_GRUPO.Text.Trim(), Val(Me.txtMARGEN.Text), "I", chkPertenece.Checked)
            Else
                Mantenimiento_Grupos(Compañia, Me.lblGRUPO.Text.PadLeft(2, "0"), Me.txtDESCRIPCION_GRUPO.Text.Trim(), Val(Me.txtMARGEN.Text), "U", chkPertenece.Checked)
            End If
            LimpiaCamposGrupo()
            CargaGrupos(Compañia, 3)
        End If
    End Sub

    Private Sub txtMARGEN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMARGEN.KeyPress
        Dim Cadena As String = Me.txtMARGEN.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = Cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnNuevoGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoGrupos.Click
        Me.bandera = False
        LimpiaCamposGrupo()
        LimpiaCamposSubGrupo()
        CargaSubGrupos(Compañia, 0, 1)
    End Sub

    Private Sub btnNuevoSubGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoSubGrupos.Click
        LimpiaCamposSubGrupo()
    End Sub

    Private Sub btnGuardarSubGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarSubGrupos.Click
        'modificado por Mauricio José
        Dim BANDERA As Integer = 0
        For i As Integer = 0 To dgvSubGrupos.RowCount - 1
            If dgvSubGrupos.Rows(i).Cells(1).Value.ToString() = Trim(Me.txtDESCRIPCION_SUB_GRUPO.Text) Then
                MsgBox("EL ITEM YA EXISTE")
                BANDERA = 1
                Exit Sub
            End If
        Next
        If BANDERA = 0 Then
            If Trim(Me.txtdescmaximo.Text) = "" Then
                Me.txtdescmaximo.Text = "0"
            End If
            If ValidaCamposSubGrupos() = True Then
                If Me.lblSUB_GRUPO.Text = "" Then
                    Mantenimiento_SubGrupos(Compañia, Me.lblGRUPO.Text, Me.lblSUB_GRUPO.Text.PadLeft(2, "0"), Trim(Me.txtDESCRIPCION_SUB_GRUPO.Text), Me.txtdescmaximo.Text, "I")
                Else
                    Mantenimiento_SubGrupos(Compañia, Me.lblGRUPO.Text, Me.lblSUB_GRUPO.Text.PadLeft(2, "0"), Trim(Me.txtDESCRIPCION_SUB_GRUPO.Text), Me.txtdescmaximo.Text, "U")
                End If
                LimpiaCamposSubGrupo()
                CargaSubGrupos(Compañia, Me.lblGRUPO.Text, 1)
            End If
        End If
        
    End Sub

    Private Sub btnEliminarSubGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarSubGrupos.Click
        If Me.lblGRUPO.Text <> "" Then
            If Me.lblSUB_GRUPO.Text <> "" Then
                If MsgBox("¿Está seguro(a) que desea eliminar el Sub Grupo de Prodcutos seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    Mantenimiento_SubGrupos(Compañia, Me.lblGRUPO.Text, Val(Me.lblSUB_GRUPO.Text), Trim(Me.txtDESCRIPCION_SUB_GRUPO.Text), Me.txtdescmaximo.Text, "D")
                    LimpiaCamposSubGrupo()
                    CargaSubGrupos(Compañia, Me.lblGRUPO.Text, 1)
                Else
                    MsgBox("¡No se eliminará ningún registro!", MsgBoxStyle.Information, "Validación")
                End If
            Else
                MsgBox("¡Debe seleccionar un Sub Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
            End If
        Else
            MsgBox("¡Debe seleccionar un Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnEliminarGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarGrupos.Click
        If Trim(Me.lblGRUPO.Text) <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Grupo de Productos seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Grupos(Compañia, Val(Me.lblGRUPO.Text), Trim(Me.txtDESCRIPCION_GRUPO.Text), Val(Me.txtMARGEN.Text), "D", chkPertenece.Checked)
                LimpiaCamposGrupo()
                CargaGrupos(Compañia, 3)
            Else
                MsgBox("¡No se eliminará ningún registro!", MsgBoxStyle.Information, "Mensaje")
            End If
        Else
            MsgBox("¡Debe seleccionar un Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub txtDESCRIPCION_GRUPO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_GRUPO.TextChanged
        If AutoOrdenamiento.Checked = True Then
        Else
            If bandera = False Then
                Dim rows As DataRow()
                Dim columna As Integer = 1
                Dim posicion As Integer = -1 '1  
                Dim Ncolumn As String = dgvGrupos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
                Dim Strsort As String = ""

                Select Case dgvGrupos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                    Case SortOrder.Ascending 'En Caso de ser Ascendente
                        Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                    Case SortOrder.Descending 'En Caso de ser Descendente
                        Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
                End Select

                'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
                Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
                If txtDESCRIPCION_GRUPO.Text = "" Then
                    Me.dgvGrupos.DataSource = Table
                Else
                    rows = Table.Select("Descripción_Grupo" & " like '" & txtDESCRIPCION_GRUPO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                    For i As Integer = 0 To rows.Length - 1
                        tablaT.ImportRow(rows(i))
                    Next

                    ' return filtered dt            
                    Me.dgvGrupos.DataSource = tablaT
                End If
            End If
        End If        
    End Sub

    Private Sub txtDESCRIPCION_SUB_GRUPO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_SUB_GRUPO.TextChanged
        If AutoOrdenamiento2.Checked = True Then
        Else
            If bandera1 = False Then
                Dim rows As DataRow()
                Dim columna As Integer = 1
                Dim posicion As Integer = -1 '1  
                Dim Ncolumn As String = dgvSubGrupos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
                Dim Strsort As String = ""

                Select Case dgvSubGrupos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                    Case SortOrder.Ascending 'En Caso de ser Ascendente
                        Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                    Case SortOrder.Descending 'En Caso de ser Descendente
                        Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
                End Select

                'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
                Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
                If txtDESCRIPCION_SUB_GRUPO.Text = "" Then
                    Me.dgvSubGrupos.DataSource = Table1
                Else
                    rows = Table1.Select("[" & dgvSubGrupos.Columns(columna).Name & "] like '" & txtDESCRIPCION_SUB_GRUPO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                    For i As Integer = 0 To rows.Length - 1
                        tablaT.ImportRow(rows(i))
                    Next

                    ' return filtered dt            
                    Me.dgvSubGrupos.DataSource = tablaT
                End If
            End If
            
        End If
        
    End Sub

    Private Sub dgvSubGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSubGrupos.Click

        Try
            bandera1 = True
            Me.lblSUB_GRUPO.Text = Me.dgvSubGrupos.CurrentRow.Cells.Item(0).Value
            Me.txtDESCRIPCION_SUB_GRUPO.Text = Me.dgvSubGrupos.CurrentRow.Cells.Item(1).Value
            'agregado por Mauricio josé
            Me.txtdescmaximo.Text = Me.dgvSubGrupos.CurrentRow.Cells.Item(4).Value
            'fin agregacion
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvGrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvGrupos.Click
        Me.bandera = True
        Me.lblGRUPO.Text = Me.dgvGrupos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_GRUPO.Text = Me.dgvGrupos.CurrentRow.Cells.Item(1).Value
        Me.txtMARGEN.Text = Me.dgvGrupos.CurrentRow.Cells.Item(3).Value
        Me.chkMARGEN.Checked = Me.dgvGrupos.CurrentRow.Cells.Item(2).Value
        Me.chkPertenece.Checked = Me.dgvGrupos.CurrentRow.Cells.Item(6).Value
        LimpiaCamposSubGrupo()
        CargaSubGrupos(Compañia, Val(Me.lblGRUPO.Text), 1)

    End Sub
    'agregado por Maurico José
    Private Sub txtdescmaximo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescmaximo.KeyPress

        Dim cadena As String = Me.txtdescmaximo.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.btnGuardarSubGrupos.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub
    'fin agregacion
End Class