Imports System.Data.SqlClient

Public Class Contabilidad_Reportes
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        CargaReportes(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
        Iniciando = False
    End Sub

    Private Sub CargaCompa�ia()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
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

    Private Sub CargaLibrosContables(ByVal Compa�ia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripci�n"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblREPORTE.Text = ""
        Me.txtDESCRIPCION_REPORTE.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_REPORTE.Text) = "" Then
            MsgBox("�Ingrese un Descripci�n de Reporte v�lida!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Reportes(ByVal Compa�ia, ByVal Reporte, ByVal Descripcion, ByVal LC, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES_IUD "
            Sql &= Compa�ia
            Sql &= ", " & Reporte
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & LC
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("�Reporte Almacenado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�Reporte Actualizado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�Reporte Eliminado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaReportes(ByVal Compa�ia, ByVal LibroContable, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_REPORTES "
            Sql &= Compa�ia
            Sql &= ", " & LibroContable
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvReportes.Columns.Clear()
            Me.dgvReportes.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvReportes.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvReportes.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvReportes.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvReportes.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.lblREPORTE.Text = "" Then
                Mantenimiento_Reportes(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblREPORTE.Text), Trim(Me.txtDESCRIPCION_REPORTE.Text), Me.cmbLIBRO_CONTABLE.SelectedValue, "I")
            Else
                Mantenimiento_Reportes(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblREPORTE.Text), Trim(Me.txtDESCRIPCION_REPORTE.Text), Me.cmbLIBRO_CONTABLE.SelectedValue, "U")
            End If
            CargaReportes(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        If Iniciando = False Then
            CargaReportes(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub dgvReportes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportes.CellContentClick

    End Sub

    Private Sub dgvReportes_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportes.CellEnter
        Me.lblREPORTE.Text = Me.dgvReportes.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_REPORTE.Text = Me.dgvReportes.CurrentRow.Cells.Item(1).Value
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblREPORTE.Text <> "" Then
            Mantenimiento_Reportes(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblREPORTE.Text), Trim(Me.txtDESCRIPCION_REPORTE.Text), Me.cmbLIBRO_CONTABLE.SelectedValue, "D")
            CargaReportes(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("�Debe seleccionar un registro v�lido!" & Chr(13) & "No se eliminar� ning�n registro.", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub
End Class