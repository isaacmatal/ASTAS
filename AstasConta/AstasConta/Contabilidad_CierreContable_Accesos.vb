Imports System.Data.SqlClient

Public Class Contabilidad_CierreContable_Accesos
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Libro As Integer

    Private Sub Contabilidad_CierreContable_Accesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compañia)
        CargaUsuarios(Compañia)
        CargaCierres(Compañia, Libro, 1, 0, 1, "P")
        LimpiaGridUsuarios()
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE LIBRO_PRINCIPAL = 1 AND COMPAÑIA = " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            Libro = Comando_.ExecuteScalar
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
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
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

    Private Sub LimpiaGridCierres()
        Me.dgvCierres.Columns(0).Width = 75
        Me.dgvCierres.Columns(1).Width = 75
        Me.dgvCierres.Columns(2).Width = 75
        Me.dgvCierres.Columns(1).Visible = False
    End Sub

    Private Sub LimpiaGridUsuarios()
        Me.dgvUsuarios.Columns(1).Width = 175
        Me.dgvUsuarios.Columns(2).Width = 75
        Me.dgvUsuarios.Columns(3).Width = 125
        Me.dgvUsuarios.Columns(0).Visible = False
    End Sub

    Private Sub CargaCierres(ByVal Compañia, ByVal LC, ByVal Precierre, ByVal CierreFinal, ByVal Procesado, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            'Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            'Sql &= Compañia
            'Sql &= ", " & LC
            'Sql &= ", 0"
            'Sql &= ", 0"
            'Sql &= ", " & Precierre
            'Sql &= ", " & CierreFinal
            'Sql &= ", " & Procesado
            'Sql &= ", '" & Usuario & "'"
            'Sql &= ", '" & IUD & "'"

            Sql = "SELECT AÑO AS [Año]," & vbCrLf
            Sql &= "	   MES AS [CodMes]," & vbCrLf
            Sql &= "	   DESCRIPCION_MES AS [Mes]" & vbCrLf
            Sql &= "  FROM VISTA_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= "   AND PRE_CIERRE = 1" & vbCrLf
            Sql &= "   AND CIERRE_FINAL = 0"

            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvCierres.Columns.Clear()
            Me.dgvCierres.DataSource = Table
            LimpiaGridCierres()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUsuarios(ByVal Compañia, ByVal LC, ByVal Año, ByVal Mes, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_PERMISOS "
            Sql &= Compañia
            Sql &= ", " & LC
            Sql &= ", " & Año
            Sql &= ", " & Mes
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvUsuarios.Columns.Clear()
            Me.dgvUsuarios.DataSource = Table
            LimpiaGridUsuarios()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Permisos(ByVal Compañia, ByVal LC, ByVal Año, ByVal NumMes, ByVal UsuarioPermiso, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_PERMISOS_IUD "
            Sql &= Compañia
            Sql &= ", " & LC
            Sql &= ", " & Año
            Sql &= ", " & NumMes
            Sql &= ", " & UsuarioPermiso
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.dgvCierres.SelectedRows.Count = 1 Then
            Mantenimiento_Permisos(Compañia, Libro, Me.dgvCierres.CurrentRow.Cells.Item(0).Value, Me.dgvCierres.CurrentRow.Cells.Item(1).Value, Me.cmbUSUARIO.SelectedValue, "I")
            CargaUsuarios(Compañia, Libro, Me.dgvCierres.CurrentRow.Cells.Item(0).Value, Me.dgvCierres.CurrentRow.Cells.Item(1).Value, 1)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvCierres.SelectedRows.Count = 1 And Me.dgvUsuarios.SelectedRows.Count = 1 Then
            If MsgBox("¿Está seguro(a) que desea eliminar el usuario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Permisos(Compañia, Libro, Me.dgvCierres.CurrentRow.Cells.Item(0).Value, Me.dgvCierres.CurrentRow.Cells.Item(1).Value, Me.cmbUSUARIO.SelectedValue, "D")
                CargaUsuarios(Compañia, Libro, Me.dgvCierres.CurrentRow.Cells.Item(0).Value, Me.dgvCierres.CurrentRow.Cells.Item(1).Value, 1)
            End If
        End If
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaCierres(Compañia, Libro, 1, 0, 0, "P")
            CargaUsuarios(Compañia, Libro, 0, 0, 1)
        End If
    End Sub

    Private Sub dgvCierres_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCierres.CellEnter
        CargaUsuarios(Compañia, Libro, Me.dgvCierres.CurrentRow.Cells.Item(0).Value, Me.dgvCierres.CurrentRow.Cells.Item(1).Value, 1)
    End Sub

    Private Sub dgvUsuarios_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellEnter
        Me.cmbUSUARIO.SelectedValue = Me.dgvUsuarios.CurrentRow.Cells.Item(0).Value
    End Sub

    Private Sub Contabilidad_CierreContable_Accesos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class