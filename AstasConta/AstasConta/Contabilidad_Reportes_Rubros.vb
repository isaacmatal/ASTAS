Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Rubros
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Reportes_Rubros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaReportes(Me.cmbCOMPAÑIA.SelectedValue, 2)
        CargaClasificacion(Me.cmbCOMPAÑIA.SelectedValue)
        CargaGrupo(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 0)
        CargaRubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 1)
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
                Me.dgvRubros.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaGrupo(ByVal Compañia, ByVal Reporte, ByVal Bandera)
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
            Me.cmbGRUPO.DataSource = Table
            Me.cmbGRUPO.ValueMember = "GRUPO"
            Me.cmbGRUPO.DisplayMember = "DESCRIPCION_GRUPO"
            If Me.cmbGRUPO.Items.Count = 0 Then
                Me.dgvRubros.Columns.Clear()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaClasificacion(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Select * From CONTABILIDAD_CATALOGO_REPORTES_RUBROS_CLASIFICACION "
            Sql &= "Where COMPAÑIA = " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCLASIFICACION.DataSource = Table
            Me.cmbCLASIFICACION.ValueMember = "CLASIFICACION"
            Me.cmbCLASIFICACION.DisplayMember = "DESCRIPCION_CLASIFICACION"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaRubros(ByVal Compañia, ByVal Reporte, ByVal Grupo, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_RUBROS "
            Sql &= Compañia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvRubros.Columns.Clear()
            Me.dgvRubros.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblRUBRO.Text = ""
        Me.txtDESCRIPCION_RUBRO.Text = ""
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvRubros.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRubros.Columns.Item(2).Visible = False
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_RUBRO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Rubro válida! Verifique.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Rubros(ByVal Compañia, ByVal Reporte, ByVal Grupo, ByVal Rubro, ByVal Descripcion, ByVal Clasificacion, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_RUBROS_IUD "
            Sql &= Compañia
            Sql &= ", " & Reporte
            Sql &= ", " & Grupo
            Sql &= ", " & Rubro
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & Clasificacion
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Rubro Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Rubro Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Rubro Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaReportes(Me.cmbCOMPAÑIA.SelectedValue, 2)
            CargaClasificacion(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.lblRUBRO.Text = "" Then
                Mantenimiento_Rubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Val(Me.lblRUBRO.Text), Trim(Me.txtDESCRIPCION_RUBRO.Text), Me.cmbCLASIFICACION.SelectedValue, "I")
            Else
                Mantenimiento_Rubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Val(Me.lblRUBRO.Text), Trim(Me.txtDESCRIPCION_RUBRO.Text), Me.cmbCLASIFICACION.SelectedValue, "U")
            End If
            CargaRubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub cmbREPORTE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbREPORTE.SelectedIndexChanged
        If Iniciando = False Then
            CargaGrupo(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, 0)
        End If
    End Sub

    Private Sub dgvRubros_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRubros.CellContentClick

    End Sub

    Private Sub dgvRubros_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRubros.CellEnter
        Me.lblRUBRO.Text = Me.dgvRubros.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_RUBRO.Text = Me.dgvRubros.CurrentRow.Cells.Item(1).Value
        Me.cmbCLASIFICACION.SelectedValue = Me.dgvRubros.CurrentRow.Cells.Item(2).Value
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblRUBRO.Text <> "" Then
            Mantenimiento_Rubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, Val(Me.lblRUBRO.Text), Trim(Me.txtDESCRIPCION_RUBRO.Text), Me.cmbCLASIFICACION.SelectedValue, "D")
            CargaRubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("¡Seleccione un registro válido! Verifique" & Chr(13) & "No se eliminará ningún registro.", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            LimpiaCampos()
            CargaRubros(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbREPORTE.SelectedValue, Me.cmbGRUPO.SelectedValue, 1)
        End If
    End Sub
End Class