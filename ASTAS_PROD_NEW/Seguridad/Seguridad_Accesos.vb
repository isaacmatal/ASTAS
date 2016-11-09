Imports System.Data.SqlClient

Public Class Seguridad_Accesos
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_Accesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue)
        CargaModulos(Me.cmbCOMPAÑIA.SelectedValue, 2)
        CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
        CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        'AccesosMenu(Compañia)
        '        Accesos(Me.mnuPrincipal, )
        Iniciando = False
    End Sub

    Private Function ValidaAcceso(ByVal Compañia, ByVal Modulo, ByVal SubModulo, ByVal Opcion) As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_ACCESOS "
            Sql &= Compañia
            Sql &= ",  '" & Modulo & "'"
            Sql &= ",  '" & SubModulo & "'"
            Sql &= ",  '" & Opcion & "'"
            Sql &= ",  '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Conexion_.Close()
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try

    End Function

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

    Private Sub CargaUsuarios(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_CATALOGO_USUARIOS " & Compañia & ", '', '', 0 "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbUSUARIO.DataSource = Table
            Me.cmbUSUARIO.ValueMember = "USUARIO"
            Me.cmbUSUARIO.DisplayMember = "USUARIO_COMPLETO"
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
            If Me.cmbSUBMODULO.Items.Count = 0 Then
                Me.cmbOPCION.DataSource = Nothing
            End If
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
        If SubModulo = Nothing Then
            SubModulo = -1
        End If
        If Modulo = Nothing Then
            Modulo = -1
        End If
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_OPCIONES " & Compañia & ", " & Modulo & ", " & SubModulo & ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbOPCION.DataSource = Table
            Me.cmbOPCION.ValueMember = "Opción"
            Me.cmbOPCION.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GuardaAcceso(ByVal Compañia, ByVal Modulo, ByVal SubModulo, ByVal Opcion, ByVal CodigoUsuario, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_ACCESOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Modulo
            Sql &= ", " & SubModulo
            Sql &= ", " & Opcion
            Sql &= ", '" & CodigoUsuario & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ",'" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            If IUD = "I" Then
                MsgBox("¡Registro guardado con éxito!", MsgBoxStyle.Information, "Mensaje")
            Else
                MsgBox("¡Registro eliminado con éxito!", MsgBoxStyle.Information, "Mensaje")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If Me.cmbCOMPAÑIA.SelectedValue = Nothing Then
            MsgBox("¡Seleccione una Compañía válida!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbMODULO.SelectedValue = Nothing Then
            MsgBox("¡Seleccione un Módulo válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbSUBMODULO.SelectedValue = Nothing Then
            MsgBox("¡Seleccione un Sub Módulo válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbOPCION.SelectedValue = Nothing Then
            MsgBox("¡Seleccione una Opción válida!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbUSUARIO.SelectedValue = Nothing Then
            MsgBox("¡Seleccione un Usuario válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub LimpiaGrid()
        Me.dgvAccesos.Columns.Item(0).Width = 100
        Me.dgvAccesos.Columns.Item(1).Width = 125
        Me.dgvAccesos.Columns.Item(2).Width = 150
        Me.dgvAccesos.Columns.Item(3).Width = 200
        Me.dgvAccesos.Columns.Item(4).Width = 75
        Me.dgvAccesos.Columns.Item(5).Width = 125
    End Sub

    Private Sub CargaAccesos(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_ACCESOS " & Compañia & ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvAccesos.Columns.Clear()
            Me.dgvAccesos.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue)
            CargaModulos(Me.cmbCOMPAÑIA.SelectedValue, 2)
            CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub cmbMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubModulos(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, 1)
        End If
    End Sub

    Private Sub cmbSUBMODULO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSUBMODULO.SelectedIndexChanged
        If Iniciando = False Then
            CargaOpciones(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            GuardaAcceso(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Me.cmbOPCION.SelectedValue, Me.cmbUSUARIO.SelectedValue, "I")
            CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub LibrosContablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim LC As New Contabilidad_LibrosContables
        '    LC.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        'End If
    End Sub

    Private Sub CuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim Cuentas As New Contabilidad_Cuentas
        '    Cuentas.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        'End If
    End Sub

    Private Sub CentrosCostosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim CC As New Contabilidad_Centros_Costos
        '    CC.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        'End If
    End Sub

    Private Sub BancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim Bank As New Contabilidad_Bancos
        '    Bank.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        'End If
    End Sub

    'Private Sub CajasChicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
    '        Dim Caja As New Contabilidad_CajaChica
    '        Caja.Show()
    '    Else
    '        MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
    '    End If
    'End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub SolicitudesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub SinCotizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub ConCotizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub PréstamosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub AprobaciónDeSolicitudesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub AnularOrdenCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub SolicitudesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub CálculoIlustrativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            Dim Usuarios As New Seguridad_Usuarios
            Usuarios.Show()
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub AccesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            MsgBox("OK", MsgBoxStyle.Exclamation, "Mensaje")
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
            sender.Enabled = False
        End If
    End Sub

    Private Sub CuentasEquivalentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim EQ As New Contabilidad_CuentasEquivalentes
        '    EQ.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        '    sender.Enabled = False
        'End If
    End Sub

    Private Sub RegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
            'Dim Partidas As New Contabilidad_Partidas
            'Partidas.Show()
            Dim Prueba As New Frm_Cooperativa_Reporte_Retiros
            Prueba.Show()
        Else
            MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
            sender.Enabled = False
        End If
    End Sub

    Private Sub AnulaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim AnulacionPartidas As New Contabilidad_Partidas_Anulacion
        '    AnulacionPartidas.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        '    sender.Enabled = False
        'End If
    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ValidaAcceso(Compañia, sender.OwnerItem.OwnerItem.Text, sender.OwnerItem.Text, sender.Text) = True Then
        '    Dim PartidasConsultas As New Contabilidad_Partidas_Consultas
        '    PartidasConsultas.Show()
        'Else
        '    MsgBox("¡No tiene acceso a esta opción!", MsgBoxStyle.Critical, "Validación")
        '    sender.Enabled = False
        'End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If ValidaCampos() = True Then
            If MsgBox("¿Está seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                GuardaAcceso(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbMODULO.SelectedValue, Me.cmbSUBMODULO.SelectedValue, Me.cmbOPCION.SelectedValue, Me.cmbUSUARIO.SelectedValue, "D")
                CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue)
            End If
        End If
    End Sub
    Private Sub dgvAccesos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellClick
        Me.cmbMODULO.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(6).Value
        Me.cmbSUBMODULO.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(7).Value
        Me.cmbOPCION.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(8).Value
        Me.cmbUSUARIO.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(9).Value
    End Sub

    Private Sub Seguridad_Accesos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class