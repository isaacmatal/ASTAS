Imports System.Data.SqlClient

Public Class Seguridad_Opciones
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_Opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaModulos(Me.cmbCOMPAÑIA.SelectedValue, 2)
        CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
        LimpiaCampos()
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
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS " & Compañia & ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMODULO.DataSource = Table
            Me.cmbMODULO.ValueMember = "Módulo"
            Me.cmbMODULO.DisplayMember = "Descripción"
            If Me.cmbMODULO.Items.Count = 0 Then
                Me.cmbSUBMODULO.DataSource = Nothing
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS " & Compañia & ", " & Modulo & ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbSUBMODULO.DataSource = Table
            Me.cmbSUBMODULO.ValueMember = "Sub Módulo"
            Me.cmbSUBMODULO.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOpciones(ByVal Compañia, ByVal Modulo, ByVal SubModulo, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_OPCIONES " & Compañia & ", " & Modulo & ", " & SubModulo & ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvOpciones.Columns.Clear()
            Me.dgvOpciones.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        For i As Integer = 1 To Me.dgvOpciones.Columns.Count
            Me.dgvOpciones.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Me.dgvOpciones.Columns(4).Width = 75
        Me.dgvOpciones.Columns(5).Width = 125
    End Sub

    Private Sub LimpiaCampos()
        Me.lblOPCION.Text = ""
        Me.txtDESCRIPCION_OPCION.Text = ""
        Me.txtFORMULARIO.Text = ""
        Me.txtAYUDA.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_OPCION.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtFORMULARIO.Text) = "" Then
            MsgBox("¡Debe ingresar un nombre de Formulario válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtAYUDA.Text) = "" Then
            MsgBox("¡Debe ingresar un Texto de Ayuda válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Opciones(ByVal Compañia, ByVal Modulo, ByVal SubModulo, ByVal Opcion, ByVal Descripcion, ByVal Formulario, ByVal Ayuda, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_OPCIONES_IUD "
            Sql &= Compañia
            Sql &= ", " & Modulo
            Sql &= ", " & SubModulo
            Sql &= ", " & Opcion
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Formulario & "'"
            Sql &= ", '" & Ayuda & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Opción Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Opción Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Opción Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
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

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbSUBMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSUBMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub dgvOpciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpciones.CellContentClick

    End Sub

    Private Sub dgvOpciones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpciones.CellEnter
        Me.lblOPCION.Text = Me.dgvOpciones.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_OPCION.Text = Me.dgvOpciones.CurrentRow.Cells.Item(1).Value
        Me.txtFORMULARIO.Text = Me.dgvOpciones.CurrentRow.Cells.Item(2).Value
        Me.txtAYUDA.Text = Me.dgvOpciones.CurrentRow.Cells.Item(3).Value
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.lblOPCION.Text = "" Then
                Mantenimiento_Opciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "I")
            Else
                Mantenimiento_Opciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "U")
            End If
            CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.lblOPCION.Text) <> "" Then
            Mantenimiento_Opciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "D")
            CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("¡Debe seleccionar un registro válido! Verifique" & Chr(13) & "No se eliminará ningún registro", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub
End Class