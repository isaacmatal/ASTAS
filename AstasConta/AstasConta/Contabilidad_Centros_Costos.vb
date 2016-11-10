Imports System.Data.SqlClient

Public Class Contabilidad_Centros_Costos
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table1 As DataTable

    Private Sub Contabilidad_Centros_Costos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCentrosCosto(Compañia, 1)
        LimpiaCampos()
        Iniciando = False
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvCentrosCosto.Columns.Item(0).Width = 50
        Me.dgvCentrosCosto.Columns.Item(1).Width = 200
        Me.dgvCentrosCosto.Columns.Item(2).Width = 75
        Me.dgvCentrosCosto.Columns.Item(3).Width = 125
    End Sub

    Private Sub CargaCentrosCosto(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO  "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table1 = New DataTable("Datos")
            DataAdapter_.Fill(Table1)
            Me.dgvCentrosCosto.Columns.Clear()
            Me.dgvCentrosCosto.DataSource = Table1
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_CentroCosto(ByVal Compañia, ByVal CentroCosto, ByVal Descripcion, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim jc As New jarsClass
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO_IUD "
            Sql &= Compañia
            Sql &= ", " & CentroCosto
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Centro de Costos Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Centro de Costos Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Centro de Costos Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As SqlException
            If ex.Number = 547 Then
                MsgBox("Existen registros relacionados con la Cuenta Contable" & vbCrLf & "que está intentando eliminar.", MsgBoxStyle.Critical, "Error")
            Else
                jc.msjError(ex, "Catalogo Centros de Costo")
            End If
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCENTRO_COSTO.Text = "0"
        Me.txtDESCRIPCION_CENTRO_COSTO.Text = ""
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_CENTRO_COSTO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Trim(Me.txtCENTRO_COSTO.Text) = "0" Then
                Mantenimiento_CentroCosto(Compañia, Me.txtCENTRO_COSTO.Text, Trim(Me.txtDESCRIPCION_CENTRO_COSTO.Text), "I")
            Else
                Mantenimiento_CentroCosto(Compañia, Me.txtCENTRO_COSTO.Text, Trim(Me.txtDESCRIPCION_CENTRO_COSTO.Text), "U")
            End If
            CargaCentrosCosto(Compañia, 1)
            LimpiaCampos()
        End If
    End Sub

    Private Sub dgvCentrosCosto_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCentrosCosto.CellClick
        Me.txtCENTRO_COSTO.Text = Me.dgvCentrosCosto.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_CENTRO_COSTO.Text = Me.dgvCentrosCosto.CurrentRow.Cells.Item(1).Value
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro(a) que desea eliminar el Centro de Costo seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_CentroCosto(Compañia, Me.txtCENTRO_COSTO.Text, Trim(Me.txtDESCRIPCION_CENTRO_COSTO.Text), "D")
            CargaCentrosCosto(Compañia, 1)
            LimpiaCampos()
        End If
    End Sub


    Private Sub txtDESCRIPCION_CENTRO_COSTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_CENTRO_COSTO.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = dgvCentrosCosto.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvCentrosCosto.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_CENTRO_COSTO.Text = "" Then
            Me.dgvCentrosCosto.DataSource = Table1
        Else
            rows = Table1.Select("[" & dgvCentrosCosto.Columns(columna).Name & "] like '" & txtDESCRIPCION_CENTRO_COSTO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvCentrosCosto.DataSource = tablaT
        End If
    End Sub

    Private Sub Contabilidad_Centros_Costos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class