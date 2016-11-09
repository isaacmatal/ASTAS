Imports System.Data.SqlClient

Public Class Seguridad_Modulos
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim Iniciando As Boolean

    Private Sub Seguridad_Modulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaModulos(Compañia, 1)
        Iniciando = False
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvModulos.Columns(0).Width = 75
        Me.dgvModulos.Columns(1).Width = 200
        Me.dgvModulos.Columns(2).Width = 75
        Me.dgvModulos.Columns(3).Width = 125
    End Sub

    Private Sub CargaModulos(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvModulos.Columns.Clear()
            Me.dgvModulos.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Modulos(ByVal Compañia, ByVal Modulo, ByVal Descripcion, ByVal IUD)
        Dim RowsAffected As Integer
        Try
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Modulo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            RowsAffected = jClass.ejecutarComandoSql(New SqlCommand(Sql))
            If RowsAffected > 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("¡Módulo Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                    Case "U"
                        MsgBox("¡Módulo Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                    Case "D"
                        MsgBox("¡Módulo Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                End Select
            Else
                MsgBox("No se realizó nungun cambio.", MsgBoxStyle.Exclamation, "Mensaje")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblMODULO.Text = ""
        Me.txtDESCRIPCION_MODULO.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaModulos(Compañia, 1)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Trim(Me.txtDESCRIPCION_MODULO.Text) <> "" Then
            If Me.lblMODULO.Text = "" Then
                Mantenimiento_Modulos(Compañia, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "I")
            Else
                Mantenimiento_Modulos(Compañia, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "U")
            End If
            CargaModulos(Compañia, 1)
            LimpiaCampos()
        Else
            MsgBox("¡Debe ingresar una Descripción de Módulo válida! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblMODULO.Text <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Modulos(Compañia, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "D")
                CargaModulos(Compañia, 1)
                LimpiaCampos()
            End If
        Else
            MsgBox("¡Debe seleccionar un Módulo válido! Verifique" & Chr(13) & "No se eliminará ningún registro.", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub dgvModulos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellContentClick

    End Sub

    Private Sub dgvModulos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellEnter
        Me.lblMODULO.Text = Me.dgvModulos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_MODULO.Text = Me.dgvModulos.CurrentRow.Cells.Item(1).Value
    End Sub
End Class