Imports System.Data.SqlClient

Public Class Seguridad_Modulos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_Modulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 1)
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

    Private Sub LimpiaGrid()
        Me.dgvModulos.Columns(0).Width = 75
        Me.dgvModulos.Columns(1).Width = 200
        Me.dgvModulos.Columns(2).Width = 75
        Me.dgvModulos.Columns(3).Width = 125
    End Sub

    Private Sub CargaModulos(ByVal Compa�ia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS "
            Sql &= " @COMPA�IA = " & Compa�ia
            Sql &= ", @BANDERA = " & Bandera
            Sql &= ", @APP = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvModulos.Columns.Clear()
            Me.dgvModulos.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Modulos(ByVal Compa�ia, ByVal Modulo, ByVal Descripcion, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_MODULOS_IUD "
            Sql &= Compa�ia
            Sql &= ", " & Modulo
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "', 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("�M�dulo Almacenado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�M�dulo Actualizado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�M�dulo Eliminado con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
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

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Trim(Me.txtDESCRIPCION_MODULO.Text) <> "" Then
            If Me.lblMODULO.Text = "" Then
                Mantenimiento_Modulos(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "I")
            Else
                Mantenimiento_Modulos(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "U")
            End If
            CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("�Debe ingresar una Descripci�n de M�dulo v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblMODULO.Text <> "" Then
            If MsgBox("�Est� seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Modulos(Me.cmbCOMPA�IA.SelectedValue, Val(Me.lblMODULO.Text), Trim(Me.txtDESCRIPCION_MODULO.Text), "D")
                CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 1)
                LimpiaCampos()
            End If
        Else
            MsgBox("�Debe seleccionar un M�dulo v�lido! Verifique" & Chr(13) & "No se eliminar� ning�n registro.", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub dgvModulos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellContentClick

    End Sub

    Private Sub dgvModulos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellEnter
        Me.lblMODULO.Text = Me.dgvModulos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_MODULO.Text = Me.dgvModulos.CurrentRow.Cells.Item(1).Value
    End Sub

    Private Sub Seguridad_Modulos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class