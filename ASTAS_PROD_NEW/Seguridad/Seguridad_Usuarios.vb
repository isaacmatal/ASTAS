Imports System.Data.SqlClient

Public Class Seguridad_Usuarios
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
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
            'Me.cmbCOMPAÑIA.SelectedItem = 1
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUsuarios(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_USUARIOS " & Compañia & ", 'SYSTEM', ' ' , 2 "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvUsuarios.Columns.Clear()
            Me.dgvUsuarios.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvUsuarios.Columns.Item(0).Width = 75
        Me.dgvUsuarios.Columns.Item(1).Width = 200
        Me.dgvUsuarios.Columns.Item(2).Width = 50
        Me.dgvUsuarios.Columns.Item(3).Width = 75
        Me.dgvUsuarios.Columns.Item(4).Width = 75
        Me.dgvUsuarios.Columns.Item(5).Width = 75
        Me.dgvUsuarios.Columns.Item(6).Width = 75
    End Sub

    Private Sub LimpiaCampos()
        Me.txtUSUARIO.Text = ""
        Me.txtNOMBRE_USUARIO.Text = ""
        Me.txtCONTRASEÑA.Text = ""
        Me.txtCONTRASEÑA_CONFIRMA.Text = ""
        Me.chkACTIVO.Checked = True
        Me.chkPuedeAutorizar.Checked = False
        Me.chkPuedeProcesar.Checked = False
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtUSUARIO.Text) = "" Then
            MsgBox("¡Debe ingresar un código de usuario.!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtNOMBRE_USUARIO.Text) = "" Then
            MsgBox("¡Debe ingresar un Nombre de usuario.!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtCONTRASEÑA.Text <> Me.txtCONTRASEÑA_CONFIRMA.Text Then
            MsgBox("¡La confirmación de la contraseña es diferente!. Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub Mantenimiento_Usuarios(ByVal Compañia, ByVal CodigoUsuario, ByVal Nombre, ByVal Contraseña, ByVal Activo, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_USUARIOS_IUD "
            Sql &= Compañia
            Sql &= ", '" & CodigoUsuario & "'"
            Sql &= ", '" & Nombre & "'"
            Sql &= ", '" & Contraseña & "'"
            Sql &= ", " & Activo
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", " & IIf(Me.chkPuedeProcesar.Checked, "1", "0")
            Sql &= ", " & IIf(Me.chkPuedeAutorizar.Checked, "1", "0")
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Usuario Almacenado con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡Usuario Actualizado con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("¡Usuario Eliminado con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            Mantenimiento_Usuarios(Me.cmbCOMPAÑIA.SelectedValue, Me.txtUSUARIO.Text, Trim(Me.txtNOMBRE_USUARIO.Text), Trim(Me.txtCONTRASEÑA.Text), IIf(Me.chkACTIVO.Checked = True, "1", "0"), "I")
            LimpiaCampos()
            CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.txtUSUARIO.Text <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Usuario con todos sus accesos asociados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Usuarios(Me.cmbCOMPAÑIA.SelectedValue, Me.txtUSUARIO.Text, Trim(Me.txtNOMBRE_USUARIO.Text), Trim(Me.txtCONTRASEÑA.Text), IIf(Me.chkACTIVO.Checked = True, "1", "0"), "D")
                LimpiaCampos()
                CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
            End If
        Else
            MsgBox("Debe seleccionar un Usuario válido.", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub dgvUsuarios_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        If Me.dgvUsuarios.CurrentRow.Index < Me.dgvUsuarios.Rows.Count Then
            Me.txtUSUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(0).Value
            Me.txtNOMBRE_USUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(1).Value
            Me.chkACTIVO.Checked = Me.dgvUsuarios.CurrentRow.Cells.Item(2).Value
            Me.chkPuedeAutorizar.Checked = Me.dgvUsuarios.CurrentRow.Cells.Item(5).Value
            Me.chkPuedeProcesar.Checked = Me.dgvUsuarios.CurrentRow.Cells.Item(6).Value
        Else
            Me.txtUSUARIO.Text = ""
            Me.txtNOMBRE_USUARIO.Text = ""
            Me.chkACTIVO.Checked = True
            Me.chkPuedeAutorizar.Checked = False
            Me.chkPuedeProcesar.Checked = False
        End If
    End Sub


    Private Sub txtCONTRASEÑA_CONFIRMA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTRASEÑA_CONFIRMA.LostFocus
        If Me.txtCONTRASEÑA.Text <> Me.txtCONTRASEÑA_CONFIRMA.Text Then
            MsgBox("¡La contraseña ingresada es diferente a la confiramción!. Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

End Class