Imports System.Data
Imports System.Data.SqlClient
Public Class FrmBuscarSocios
    Dim sql As String
    Public Compañia_Value As Integer
    Dim jClass As New jarsClass
    Dim DS As New DataSet()

    Private Sub LimpiaGrid()
        Me.DgvSocios.Columns(0).Width = 50
        Me.DgvSocios.Columns(1).Width = 50
        Me.DgvSocios.Columns(2).Width = 200
        Me.DgvSocios.Columns(3).Width = 100
        Me.DgvSocios.Columns(4).Width = 125
        Me.DgvSocios.Columns(5).Width = 75
        Me.DgvSocios.Columns(6).Width = 100
        Me.DgvSocios.Columns(7).Width = 100
    End Sub

    Private Function GeneraSql() As String
        Dim Condicion As String
        Dim Origenes As String
        Try
            Origenes = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Origenes = "0"
        End Try
        Condicion = ""
        sql = "SELECT CODIGO_EMPLEADO_AS AS 'Código AS', CONVERT(NCHAR,CODIGO_EMPLEADO) AS 'Código Buxis', NOMBRE_COMPLETO AS 'Nombre del Socio', "
        sql &= "DUI, NIT, TELEFONO AS [Teléfono], DESCRIPCION_DEPARTAMENTO AS Departamento, DESCRIPCION_SECCION AS [Sección] "
        sql &= "FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS"

        Condicion = " WHERE COMPAÑIA = " & Compañia

        If Trim(Me.TxtNombre.Text) <> Nothing Then
            Condicion &= " AND NOMBRE_COMPLETO Like '%" & Trim(Me.TxtNombre.Text) & "%' "
        End If
        If Trim(Me.TxtDui.Text) <> Nothing Then
            Condicion &= " AND DUI Like '%" & Trim(Me.TxtDui.Text) & "%' "
        End If
        If Trim(Me.TxtTelefono.Text) <> Nothing Then
            Condicion &= " AND TELEFONO Like '%" & Trim(Me.TxtTelefono.Text) & "%' "
        End If
        If Trim(Me.CbxDepartamento.Text) <> Nothing And Me.CbxDepartamento.SelectedValue <> 9999 Then
            Condicion &= " AND DESCRIPCION_DEPARTAMENTO ='" & Trim(Me.CbxDepartamento.Text) & "' "
        End If
        sql &= Condicion & " AND ORIGEN IN (" & Origenes & ")"
        Return sql
    End Function

    Private Sub BuscaSocio()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter        
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables.Item(0).Rows.Count = 0 Then
                MsgBox("¡No se encontró ningún Socio!", MsgBoxStyle.Critical, "Mensaje")
                Me.DgvSocios.RefreshEdit()
            End If
            DgvSocios.DataSource = DS.Tables(0)
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub LImpiaCampos()
        Me.TxtNombre.Text = ""
        Me.TxtDui.Text = ""
        Me.TxtTelefono.Text = ""
    End Sub
    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        If Me.TxtNombre.Text = Nothing And Me.TxtDui.Text = Nothing And Me.TxtTelefono.Text = Nothing And CbxDepartamento.Text = "" Then
            MsgBox("¡Favor Ingresar un filtro de búsqueda válido!", MsgBoxStyle.Critical, "Mensaje")
        Else
            BuscaSocio()
            LImpiaCampos()
        End If
    End Sub

    Private Sub FrmBuscarSocios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        CargaDepartamento(Compañia)
        Iniciando = False
        BtnBuscarSoc.PerformClick()
    End Sub

    Private Sub CargaDepartamento(ByVal Compañia)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataReader_Track As SqlDataReader
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            sql = "SELECT DISTINCT DEPARTAMENTO, DESCRIPCION_DEPARTAMENTO FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia
            sql &= "UNION SELECT 9999, 'TODOS' ORDER BY DESCRIPCION_DEPARTAMENTO"
            Comando_Track = New SqlCommand(sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            DataReader_Track = Comando_Track.ExecuteReader
            Me.CbxDepartamento.DataSource = Table
            Me.CbxDepartamento.ValueMember = "DEPARTAMENTO"
            Me.CbxDepartamento.DisplayMember = "DESCRIPCION_DEPARTAMENTO"
            Me.CbxDepartamento.SelectedValue = 9999
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtDui_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDui.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub DgvSocios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSocios.CellClick
        Try
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Return
            Else
                ParamcodigoAs = DgvSocios.CurrentRow.Cells(0).Value
                ParamcodigoBux = DgvSocios.CurrentRow.Cells(1).Value
                NombrePaciente = DgvSocios.CurrentRow.Cells(2).Value
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TxtAs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAs.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 0
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtAs.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtAs.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtBuxi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuxi.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtBuxi.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtBuxi.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 2
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNombre.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtNombre.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtDui_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDui.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 3
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtDui.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtDui.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNit.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 4
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNit.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtNit.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTelefono.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 5
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtTelefono.Text = "" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & TxtTelefono.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If
    End Sub

    Private Sub FrmBuscarSocios_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub CbxDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxDepartamento.SelectedIndexChanged
        If Iniciando Then
            Return
        End If
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 6
        Dim Ncolumn As String = DgvSocios.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvSocios.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If CbxDepartamento.Text = "TODOS" Then
            Me.DgvSocios.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSocios.Columns(columna).Name & "] like '" & CbxDepartamento.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 6                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSocios.DataSource = tablaT
        End If

    End Sub
End Class