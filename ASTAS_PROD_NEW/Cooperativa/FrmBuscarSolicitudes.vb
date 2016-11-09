Imports System.Data
Imports System.Data.SqlClient

Public Class FrmBuscarSolicitudes
    Dim sql As String
    Public Compañia_Value As Integer
    Dim jClass As New jarsClass
    Dim DS As New DataSet()

    Private Function GeneraSql() As String
        Dim Origenes As String
        Try
            Origenes = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Origenes = "0"
        End Try
        sql = "EXECUTE Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES" & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
        sql &= " @SOLICITUD = " & IIf(Trim(TxtNumSolicitud.Text) = "", "0", Trim(Me.TxtNumSolicitud.Text)) & "," & vbCrLf
        sql &= " @CODIGOAS = '" & IIf(Trim(TxtCodigoAs.Text) = "", "0", Trim(Me.TxtCodigoAs.Text)) & "'," & vbCrLf
        sql &= " @CODIGOBUXIS = " & IIf(Trim(TxtCodigoBuxis.Text) = "", "0", Trim(Me.TxtCodigoBuxis.Text)) & "," & vbCrLf
        sql &= " @NOMBRE = '" & Trim(Me.TxtNombre.Text) & "'," & vbCrLf
        sql &= " @BANDERA = 0," & vbCrLf
        sql &= " @COTIZACION = " & Cotizacion.ToString() & "," & vbCrLf
        sql &= " @ORIGENES = '" & Origenes & "'" & vbCrLf
        Return sql
    End Function

    Private Sub BuscaSolicitudes()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            DgvSolicitudes.DataSource = DS.Tables(0)
            LimpiaGrid()
            If Me.DgvSolicitudes.Rows.Count = 0 Then
                MsgBox("¡No se ha encontrado ninguna Solicitud!", MsgBoxStyle.Critical, "Mensaje")
                DgvSolicitudes.DataSource = Nothing
            End If
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvSolicitudes.Columns(0).Width = 50
        Me.DgvSolicitudes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(1).Visible = False
        Me.DgvSolicitudes.Columns(2).Width = 150
        Me.DgvSolicitudes.Columns(3).Visible = False
        Me.DgvSolicitudes.Columns(4).Width = 50
        Me.DgvSolicitudes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(5).Width = 50
        Me.DgvSolicitudes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(6).Width = 230
        Me.DgvSolicitudes.Columns(7).Width = 70
        Me.DgvSolicitudes.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DgvSolicitudes.Columns(8).Width = 100
        Me.DgvSolicitudes.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DgvSolicitudes.Columns(9).Width = 75
        Me.DgvSolicitudes.Columns(10).Visible = False
    End Sub

    Private Sub LimpiaCampos()
        Me.TxtCodigoAs.Text = ""
        Me.TxtCodigoBuxis.Text = ""
        Me.TxtNumSolicitud.Text = ""
        Me.TxtNombre.Text = ""
    End Sub

    Private Sub BtnBuscarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSolicitudes.Click
        If Me.TxtNombre.Text = Nothing And Me.TxtNumSolicitud.Text = Nothing And Me.TxtCodigoAs.Text = Nothing And Me.TxtCodigoBuxis.Text = Nothing Then
            MsgBox("¡Favor ingresar un filtro de búsqueda válido!", MsgBoxStyle.Critical, "Mensaje")
            DgvSolicitudes.DataSource = Nothing
        Else
            BuscaSolicitudes()
            LimpiaGrid()
        End If
    End Sub

    Private Sub FrmBuscarSolicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        BuscaSolicitudes()
        LimpiaCampos()
    End Sub

    Private Sub TxtNumSolicitud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumSolicitud.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCodigoAs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAs.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
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

    Private Sub DgvSolicitudes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitudes.CellClick
        Try
            If DgvSolicitudes.RowCount = 0 Then
                Return
            Else
                ParamcodSolicitud = DgvSolicitudes.CurrentRow.Cells(0).Value()
                ParamcodigoAs = DgvSolicitudes.CurrentRow.Cells(4).Value()
                ParamcodigoBux = DgvSolicitudes.CurrentRow.Cells(5).Value()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FrmBuscarSolicitudes_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 6
        Dim Ncolumn As String = DgvSolicitudes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case Me.DgvSolicitudes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If Me.TxtNombre.Text = "" Then
            Me.DgvSolicitudes.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSolicitudes.Columns(columna).Name & "] like '" & TxtNombre.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSolicitudes.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtCodigoAs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoAs.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 4
        Dim Ncolumn As String = DgvSolicitudes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case Me.DgvSolicitudes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If Me.TxtCodigoAs.Text = "" Then
            Me.DgvSolicitudes.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSolicitudes.Columns(columna).Name & "] like '" & Me.TxtCodigoAs.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSolicitudes.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtCodigoBuxis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoBuxis.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 5
        Dim Ncolumn As String = DgvSolicitudes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case Me.DgvSolicitudes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If Me.TxtCodigoBuxis.Text = "" Then
            Me.DgvSolicitudes.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSolicitudes.Columns(columna).Name & "] like '" & Me.TxtCodigoBuxis.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSolicitudes.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtNumSolicitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumSolicitud.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 0
        Dim Ncolumn As String = DgvSolicitudes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case Me.DgvSolicitudes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If Me.TxtNumSolicitud.Text = "" Then
            Me.DgvSolicitudes.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvSolicitudes.Columns(columna).Name & "] like '" & Me.TxtNumSolicitud.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvSolicitudes.DataSource = tablaT
        End If
    End Sub
End Class