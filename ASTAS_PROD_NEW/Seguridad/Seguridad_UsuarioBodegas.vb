Imports System.Data.SqlClient

Public Class Seguridad_UsuarioBodegas
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Seguridad_UsuarioBodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 1)
        CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
        CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue, 999, 1)
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

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA = " & Bandera
            Sql &= ", @COMPAÑIA = " & Compañia
            Sql &= ", @USUARIO = '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.chkFACTURA.Checked = False
        Me.chkCOMPRA.Checked = False
        Me.chkINVENTARIO.Checked = False
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvAccesos.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvAccesos.Columns.Item(0).Visible = False
    End Sub

    Private Sub CargaAccesos(ByVal Compañia, ByVal Bodega, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_BODEGAS_USUARIOS "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Bandera
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

    Private Sub GuardaAcceso(ByVal Compañia, ByVal Bodega, ByVal UsuarioAcceso, ByVal Factura, ByVal Compra, ByVal Inventario, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        'Dim DataAdapter_ As SqlDataAdapter
        'Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_SEGURIDAD_CATALOGO_BODEGAS_USUARIOS_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", '" & UsuarioAcceso & "'"
            Sql &= ", " & Factura
            Sql &= ", " & Compra
            Sql &= ", " & Inventario
            Sql &= ", '" & Usuario & "'"
            Sql &= ",'" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            MsgBox("¡Registro guardado con éxito!", MsgBoxStyle.Information, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, 1)
            CargaUsuarios(Me.cmbCOMPAÑIA.SelectedValue)
            CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue, 999, 1)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        GuardaAcceso(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbUSUARIO.SelectedValue, IIf(Me.chkFACTURA.Checked = True, "1", "0"), IIf(Me.chkCOMPRA.Checked = True, "1", "0"), IIf(Me.chkINVENTARIO.Checked = True, "1", "0"), "I")
        LimpiaCampos()
        CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue, 999, 1)
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro(a) que desea eliminar el registro de usuario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            GuardaAcceso(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbUSUARIO.SelectedValue, IIf(Me.chkFACTURA.Checked = True, "1", "0"), IIf(Me.chkCOMPRA.Checked = True, "1", "0"), IIf(Me.chkINVENTARIO.Checked = True, "1", "0"), "D")
            LimpiaCampos()
            CargaAccesos(Me.cmbCOMPAÑIA.SelectedValue, 999, 1)
        End If
    End Sub

    Private Sub dgvAccesos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellClick
        If Me.dgvAccesos.CurrentRow.Index < Me.dgvAccesos.Rows.Count Then
            Me.cmbBODEGA.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(0).Value
            Me.cmbUSUARIO.SelectedValue = Me.dgvAccesos.CurrentRow.Cells.Item(2).Value
            Me.chkFACTURA.Checked = Me.dgvAccesos.CurrentRow.Cells.Item(3).Value
            Me.chkCOMPRA.Checked = Me.dgvAccesos.CurrentRow.Cells.Item(4).Value
            Me.chkINVENTARIO.Checked = Me.dgvAccesos.CurrentRow.Cells.Item(5).Value
        Else
            LimpiaCampos()
        End If
    End Sub

    Private Sub dgvAccesos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellContentClick

    End Sub

    Private Sub Seguridad_UsuarioBodegas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class