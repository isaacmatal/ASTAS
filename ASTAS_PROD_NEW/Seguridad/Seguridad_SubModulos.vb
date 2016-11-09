Imports System.Data.SqlClient

Public Class Seguridad_SubModulos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_SubModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaModulos(Me.cmbCOMPAÑIA.SelectedValue, 2)
        CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaModulos(ByVal Compañia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMODULO.DataSource = Table
            Me.cmbMODULO.ValueMember = "Módulo"
            Me.cmbMODULO.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvSubModulos.Columns(0).Width = 75
        Me.dgvSubModulos.Columns(1).Width = 200
        Me.dgvSubModulos.Columns(2).Width = 75
        Me.dgvSubModulos.Columns(3).Width = 125
    End Sub

    Private Sub CargaSubModulos(ByVal Compañia, ByVal Modulo, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS "
            Sql &= Compañia
            Sql &= ", " & Modulo
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvSubModulos.Columns.Clear()
            Me.dgvSubModulos.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblSUB_MODULO.Text = ""
        Me.txtDESCRIPCION_SUB_MODULO.Text = ""
    End Sub

    Private Sub Mantenimiento_SubModulos(ByVal Compañia, ByVal Modulo, ByVal SubModulo, ByVal Descripcion, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Modulo
            Sql &= ", " & SubModulo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Sub Módulo Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Sub Módulo Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Sub Módulo Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaModulos(Me.cmbCOMPAÑIA.SelectedValue, 2)
        End If
    End Sub

    Private Sub cmbMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        End If
    End Sub

    Private Sub dgvSubModulos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubModulos.CellContentClick

    End Sub

    Private Sub dgvSubModulos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubModulos.CellEnter
        Me.lblSUB_MODULO.Text = Me.dgvSubModulos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_SUB_MODULO.Text = Me.dgvSubModulos.CurrentRow.Cells.Item(1).Value
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Trim(Me.txtDESCRIPCION_SUB_MODULO.Text) <> "" Then
            If Me.lblSUB_MODULO.Text = "" Then
                Mantenimiento_SubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "I")
            Else
                Mantenimiento_SubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "U")
            End If
            CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("¡Ingrese una Descripción de Sub Módulo válida! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.lblSUB_MODULO.Text) <> "" Then
            If MsgBox("¿Está seguro(a) que desela eliminar el registro seleccionado? Esto eliminará todos los accesos de usuarios a esta opción.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_SubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "D")
                CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
            End If
        Else
            MsgBox("¡Debe seleccionar un Sub Módulo válido! Verifique" & Chr(13) & "No se eliminará ningún registro.", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub
End Class