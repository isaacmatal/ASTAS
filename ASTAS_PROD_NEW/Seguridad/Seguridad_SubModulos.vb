Imports System.Data.SqlClient

Public Class Seguridad_SubModulos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_SubModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 2)
        CargaSubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub CargaCompa�ia()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaModulos(ByVal Compa�ia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS "
            Sql &= Compa�ia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMODULO.DataSource = Table
            Me.cmbMODULO.ValueMember = "M�dulo"
            Me.cmbMODULO.DisplayMember = "Descripci�n"
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

    Private Sub CargaSubModulos(ByVal Compa�ia, ByVal Modulo, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS "
            Sql &= Compa�ia
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

    Private Sub Mantenimiento_SubModulos(ByVal Compa�ia, ByVal Modulo, ByVal SubModulo, ByVal Descripcion, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS_IUD "
            Sql &= Compa�ia
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
                    MsgBox("�Sub M�dulo Almacenado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�Sub M�dulo Actualizado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�Sub M�dulo Eliminado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 2)
        End If
    End Sub

    Private Sub cmbMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
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
                Mantenimiento_SubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "I")
            Else
                Mantenimiento_SubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "U")
            End If
            CargaSubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("�Ingrese una Descripci�n de Sub M�dulo v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.lblSUB_MODULO.Text) <> "" Then
            If MsgBox("�Est� seguro(a) que desela eliminar el registro seleccionado? Esto eliminar� todos los accesos de usuarios a esta opci�n.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_SubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Val(Me.lblSUB_MODULO.Text), Trim(Me.txtDESCRIPCION_SUB_MODULO.Text), "D")
                CargaSubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
            End If
        Else
            MsgBox("�Debe seleccionar un Sub M�dulo v�lido! Verifique" & Chr(13) & "No se eliminar� ning�n registro.", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub
End Class