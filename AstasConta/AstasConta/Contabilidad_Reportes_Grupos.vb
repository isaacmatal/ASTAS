Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Grupos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Reportes_Grupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaReportes(Me.cmbCOMPAÑIA.SelectedValue, 2)
        CargaGrupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub CargaCompañia()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
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

    Private Sub CargaReportes(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES "
            Sql &= Compañia
            Sql &= ", 0" 'LIBRO_CONTABLE
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbREPORTE.DataSource = Table
            Me.cmbREPORTE.ValueMember = "REPORTE"
            Me.cmbREPORTE.DisplayMember = "DESCRIPCION"
            If Me.cmbREPORTE.Items.Count = 0 Then
                Me.dgvGrupos.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaGrupos(ByVal Compañia, ByVal Reporte, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_GRUPOS "
            Sql &= Compañia
            Sql &= ", " & Reporte
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvGrupos.Columns.Clear()
            Me.dgvGrupos.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvGrupos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvGrupos.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvGrupos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvGrupos.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub LimpiaCampos()
        Me.lblGRUPO.Text = ""
        Me.txtDESCRIPCION_GRUPO.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_GRUPO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Grupo válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Grupos(ByVal Compañia, ByVal Reporte, ByVal Grupo, ByVal Descripcion, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_GRUPOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Grupo Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Grupo Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Grupo Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaReportes(Me.cmbCOMPAÑIA.SelectedValue, 2)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbREPORTE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbREPORTE.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaGrupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.lblGRUPO.Text = "" Then
                Mantenimiento_Grupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Val(Me.lblGRUPO.Text), Trim(Me.txtDESCRIPCION_GRUPO.Text), "I")
            Else
                Mantenimiento_Grupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Val(Me.lblGRUPO.Text), Trim(Me.txtDESCRIPCION_GRUPO.Text), "U")
            End If
            CargaGrupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblGRUPO.Text <> "" Then
            Mantenimiento_Grupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Val(Me.lblGRUPO.Text), Trim(Me.txtDESCRIPCION_GRUPO.Text), "D")
            CargaGrupos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("¡Debe seleccionar un registro válido!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub dgvGrupos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupos.CellContentClick

    End Sub

    Private Sub dgvGrupos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupos.CellEnter
        Me.lblGRUPO.Text = Me.dgvGrupos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_GRUPO.Text = Me.dgvGrupos.CurrentRow.Cells.Item(1).Value
    End Sub
End Class