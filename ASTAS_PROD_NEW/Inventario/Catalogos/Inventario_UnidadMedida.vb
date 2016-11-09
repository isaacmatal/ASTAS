Imports System.Data.SqlClient

Public Class Inventario_UnidadMedida
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table As DataTable

    Private Sub Inventario_UnidadMedida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompa�ia.Text = Descripcion_Compa�ia
        CargaUM(Compa�ia, 3)
        LimpiaCampos()
        Iniciando = True
    End Sub
    Private Sub LimpiaCampos()
        Me.lblUNIDAD_MEDIDA.Text = ""
        Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text = ""
        Chkpertenece.Checked = False
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text) = "" Then
            MsgBox("�Debe ingresar una Descripci�n de Unidad de Medida v�lida! Verifique.", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_UM(ByVal Compa�ia, ByVal UM, ByVal Descripcion, ByVal IUD, ByVal pertenece)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA_IUD "
            Sql &= Compa�ia
            Sql &= ", " & UM
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", " & pertenece
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("�Unidad de Medida Almacenada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�Unidad de Medida Actualizada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�Unidad de Medida Eliminada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUM(ByVal Compa�ia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter        
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            sql &= Compa�ia
            sql &= ", " & Bandera
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvUnidadesMedida.Columns.Clear()
            Me.dgvUnidadesMedida.DataSource = Table
            'dgvUnidadesMedida.Columns.Item(4).Visible = False
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvUnidadesMedida.Columns(0).Width = 75
        Me.dgvUnidadesMedida.Columns(1).Width = 200
        Me.dgvUnidadesMedida.Columns(2).Width = 75
        Me.dgvUnidadesMedida.Columns(3).Width = 125
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Trim(Me.lblUNIDAD_MEDIDA.Text) = "" Then
                Mantenimiento_UM(Compa�ia, "0", Trim(Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text), "I", Chkpertenece.Checked)
            Else
                Mantenimiento_UM(Compa�ia, Me.lblUNIDAD_MEDIDA.Text, Trim(Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text), "U", Chkpertenece.Checked)
            End If
            CargaUM(Compa�ia, 3)
            LimpiaCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblUNIDAD_MEDIDA.Text <> "" Then
            If MsgBox("�Est� seguro(a) que desea eliminar la Unidad de Medida seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_UM(Compa�ia, Me.lblUNIDAD_MEDIDA.Text, Trim(Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text), "D", Chkpertenece.Checked)
                CargaUM(Compa�ia, 3)
                LimpiaCampos()
            End If
        Else
            MsgBox("�Debe seleccionar una Unidad de Medida v�lida!" & Chr(13) & "No se eliminar� ning�n registro.", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaUM(Compa�ia, 3)
        End If
    End Sub

    Private Sub dgvUnidadesMedida_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUnidadesMedida.CellContentClick

    End Sub

    Private Sub txtDESCRIPCION_UNIDAD_MEDIDA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_UNIDAD_MEDIDA.TextChanged
        Dim columna As Integer = 1 'Valor numero de la columna del DataGridView.
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim Ncolumn As String = dgvUnidadesMedida.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvUnidadesMedida.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenaci�n establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenaci�n establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_UNIDAD_MEDIDA.Text = "" Then
            Me.dgvUnidadesMedida.DataSource = Table
        Else
            rows = Table.Select("[" & dgvUnidadesMedida.Columns(columna).Name & "] like '" & txtDESCRIPCION_UNIDAD_MEDIDA.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            ' return filtered dt            
            Me.dgvUnidadesMedida.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvUnidadesMedida_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUnidadesMedida.CellClick
        Me.lblUNIDAD_MEDIDA.Text = Me.dgvUnidadesMedida.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_UNIDAD_MEDIDA.Text = Me.dgvUnidadesMedida.CurrentRow.Cells.Item(1).Value
        Chkpertenece.Checked = Me.dgvUnidadesMedida.CurrentRow.Cells.Item(4).Value
    End Sub
End Class