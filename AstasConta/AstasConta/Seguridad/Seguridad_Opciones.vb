Imports System.Data.SqlClient

Public Class Seguridad_Opciones
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_Opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaModulos(Me.cmbCOMPA�IA.SelectedValue, 2)
        CargaSubModulos(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        CargaOpciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
        LimpiaCampos()
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

    Private Sub CargaModulos(ByVal Compa�ia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_SEGURIDAD_CATALOGO_MODULOS @COMPA�IA = " & Compa�ia & ", @BANDERA = " & Bandera & ", @APP = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMODULO.DataSource = Table
            Me.cmbMODULO.ValueMember = "M�dulo"
            Me.cmbMODULO.DisplayMember = "Descripci�n"
            If Me.cmbMODULO.Items.Count = 0 Then
                Me.cmbSUBMODULO.DataSource = Nothing
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaSubModulos(ByVal Compa�ia, ByVal Modulo, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_SUBMODULOS @COMPA�IA = " & Compa�ia & ", @MODULO = " & Modulo & ", @BANDERA = " & Bandera & ", @APP = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbSUBMODULO.DataSource = Table
            Me.cmbSUBMODULO.ValueMember = "Sub M�dulo"
            Me.cmbSUBMODULO.DisplayMember = "Descripci�n"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOpciones(ByVal Compa�ia, ByVal Modulo, ByVal SubModulo, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_OPCIONES @COMPA�IA = " & Compa�ia & ", @MODULO = " & Modulo & ", @SUB_MODULO = " & SubModulo & ", @BANDERA = " & Bandera & ", @APP = 1"
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
            MsgBox("�Debe ingresar una Descripci�n v�lida! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.txtFORMULARIO.Text) = "" Then
            MsgBox("�Debe ingresar un nombre de Formulario v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.txtAYUDA.Text) = "" Then
            MsgBox("�Debe ingresar un Texto de Ayuda v�lido! Verifique", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_Opciones(ByVal Compa�ia, ByVal Modulo, ByVal SubModulo, ByVal Opcion, ByVal Descripcion, ByVal Formulario, ByVal Ayuda, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_OPCIONES_IUD "
            Sql &= "  @COMPA�IA = " & Compa�ia
            Sql &= ", @MODULO = " & Modulo
            Sql &= ", @SUB_MODULO = " & SubModulo
            Sql &= ", @OPCION = " & Opcion
            Sql &= ", @DESCRIPCION_OPCION = '" & Descripcion & "'"
            Sql &= ", @FORMULARIO = '" & Formulario & "'"
            Sql &= ", @AYUDA = '" & Ayuda & "'"
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Sql &= ", @IUD = '" & IUD & "'"
            Sql &= ", @APP = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("�Opci�n Almacenada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("�Opci�n Actualizada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("�Opci�n Eliminada con �xito!", MsgBoxStyle.Exclamation, "Mensaje")
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

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbSUBMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSUBMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaOpciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
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
                Mantenimiento_Opciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "I")
            Else
                Mantenimiento_Opciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "U")
            End If
            CargaOpciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.lblOPCION.Text) <> "" Then
            Mantenimiento_Opciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Val(Me.lblOPCION.Text), Trim(Me.txtDESCRIPCION_OPCION.Text), Trim(Me.txtFORMULARIO.Text), Trim(Me.txtAYUDA.Text), "D")
            CargaOpciones(Me.cmbCOMPA�IA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
            LimpiaCampos()
        Else
            MsgBox("�Debe seleccionar un registro v�lido! Verifique" & Chr(13) & "No se eliminar� ning�n registro", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub

    Private Sub Seguridad_Opciones_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class