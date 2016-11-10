Imports System.Data.SqlClient

Public Class Contabilidad_LibrosContables
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table1 As DataTable

    Private Sub Contabilidad_LibrosContables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañia()
        CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        LimpiaCampos()
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
            Me.cmbCOMPAÑIA.SelectedValue = Compañia
            Me.cmbCOMPAÑIA.Enabled = False
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Dim Fill As New cmbFill
        Fill.ajustarGrid(6, Me.dgvLibros_Contables)
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter        
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            'DataAdapter_ = New SqlDataAdapter(Comando_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table1 = New DataTable("Datos")
            DataAdapter_.Fill(Table1)
            Me.dgvLibros_Contables.Columns.Clear()
            Me.dgvLibros_Contables.DataSource = Table1
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtLIBRO_CONTABLE.Text = "0"
        Me.txtDESCRIPCION_LIBRO_CONTABLE.Text = ""
        Me.txtLIBRO_CONTABLE_INICIALES.Text = ""
        Me.chkLIBRO_PRINCIPAL.Checked = False
    End Sub

    Private Sub Mantenimiento_LibrosContables(ByVal Compañia, ByVal LibroContable, ByVal Descripcion, ByVal Iniciales, ByVal LibroPrincipal, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE_IUD "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Iniciales & "'"
            Sql &= ", " & LibroPrincipal
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Libro Contable Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Libro Contable Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Libro Contable Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_LIBRO_CONTABLE.Text) = "" Then
            MsgBox("Debe ingresar una descripción al Libro Contable para poder guardar.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtLIBRO_CONTABLE_INICIALES.Text) = "" Then
            MsgBox("Debe ingresar iniciales al Libro Contable para poder guardar.", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String
        If Trim(Me.txtLIBRO_CONTABLE.Text) = "0" Then
            IUD = "I"
        Else
            IUD = "U"
        End If
        If ValidaCampos() = True Then
            Mantenimiento_LibrosContables(Me.cmbCOMPAÑIA.SelectedValue, Me.txtLIBRO_CONTABLE.Text, Trim(Me.txtDESCRIPCION_LIBRO_CONTABLE.Text), Trim(Me.txtLIBRO_CONTABLE_INICIALES.Text), IIf(Me.chkLIBRO_PRINCIPAL.Checked, "1", "0"), IUD)
            LimpiaCampos()
            CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.txtLIBRO_CONTABLE.Text <> "0" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Libro Contable con todas sus cuentas asociadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_LibrosContables(Me.cmbCOMPAÑIA.SelectedValue, Me.txtLIBRO_CONTABLE.Text, Trim(Me.txtDESCRIPCION_LIBRO_CONTABLE.Text), Trim(Me.txtLIBRO_CONTABLE_INICIALES.Text), IIf(Me.chkLIBRO_PRINCIPAL.Checked, "1", "0"), "D")
                LimpiaCampos()
                CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
            End If
        Else
            MsgBox("Debe seleccionar un Libro Contable válido.", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub miMenu_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMenu_Eliminar.Click
        If Me.dgvLibros_Contables.CurrentRow.Cells.Item(1).Value <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Libro Contable con todas sus cuentas asociadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_LibrosContables(Me.cmbCOMPAÑIA.SelectedValue, Me.dgvLibros_Contables.CurrentRow.Cells.Item(0).Value, Me.dgvLibros_Contables.CurrentRow.Cells.Item(1).Value, Me.dgvLibros_Contables.CurrentRow.Cells.Item(2).Value, IIf(Me.chkLIBRO_PRINCIPAL.Checked, "1", "0"), "D")
                LimpiaCampos()
                CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
            End If
        Else
            MsgBox("Debe seleccionar un Libro Contable válido.", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            CargaLibrosContables(Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub txtDESCRIPCION_LIBRO_CONTABLE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_LIBRO_CONTABLE.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = dgvLibros_Contables.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvLibros_Contables.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_LIBRO_CONTABLE.Text = "" Then
            Me.dgvLibros_Contables.DataSource = Table1
        Else
            rows = Table1.Select("[" & dgvLibros_Contables.Columns(columna).Name & "] like '" & txtDESCRIPCION_LIBRO_CONTABLE.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvLibros_Contables.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvLibros_Contables_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLibros_Contables.CellClick
        If Iniciando = False Then
            Me.txtLIBRO_CONTABLE.Text = Me.dgvLibros_Contables.CurrentRow.Cells.Item(0).Value
            Me.txtDESCRIPCION_LIBRO_CONTABLE.Text = Me.dgvLibros_Contables.CurrentRow.Cells.Item(1).Value
            Me.txtLIBRO_CONTABLE_INICIALES.Text = Me.dgvLibros_Contables.CurrentRow.Cells.Item(2).Value
            Me.chkLIBRO_PRINCIPAL.Checked = Me.dgvLibros_Contables.CurrentRow.Cells.Item(3).Value
        End If
    End Sub

    Private Sub Contabilidad_LibrosContables_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class

