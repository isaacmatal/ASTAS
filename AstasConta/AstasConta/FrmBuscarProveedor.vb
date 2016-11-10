Imports System.Data
Imports System.Data.SqlClient

Public Class FrmBuscarProveedor
    Dim sql As String
    Public Compañia_Value As Integer
    Dim DS As New DataSet()

    Private Function GeneraSql() As String
        Dim Condicion As String
        Condicion = ""
        'JASC II
        sql = "SELECT CONVERT(NCHAR,PROVEEDOR) AS Código, CODIGO_ASTAS [Código ASTAS], NOMBRE_PROVEEDOR as [Nombre del Proveedor],  Nombre_comercial as  [Nombre Comercial], "
        sql &= "NRC [Registro Fiscal], NIT FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
        Condicion = " WHERE ESTADO  = 1 AND COMPAÑIA = " & Compañia
        If Trim(TxtProveedor.Text) <> Nothing Then
            Condicion &= " AND NOMBRE_PROVEEDOR LIKE '%" & Trim(Me.TxtProveedor.Text) & "%' "
        End If
        If Trim(TxtCodigoAsta.Text) <> Nothing Then
            Condicion &= " AND CODIGO_ASTAS LIKE '" & Trim(Me.TxtCodigoAsta.Text) & "%' "
        End If
        If Trim(TxtCodigoProv.Text) <> Nothing Then
            Condicion &= " AND PROVEEDOR = " & Trim(Me.TxtCodigoProv.Text)
        End If
        If Trim(Me.TxtNit.Text) <> Nothing Then
            Condicion &= " AND NIT LIKE '" & Trim(Me.TxtNit.Text) & "%' "
        End If
        If Trim(Me.TxtNrc.Text) <> Nothing Then
            Condicion &= " AND NRC LIKE '" & Trim(Me.TxtNrc.Text) & "%' "
        End If
        sql &= Condicion + "ORDER BY PROVEEDOR"
        Return sql
    End Function

    Public Sub BuscarProveedor()
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter As SqlDataAdapter
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_Track.Open()
            Comando_Track = New SqlCommand(GeneraSql(), Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            DataAdapter.Fill(DS)
            If DS.Tables.Item(0).Rows.Count = 0 Then
                MsgBox("¡No se encontró ningun proveedor!", MsgBoxStyle.Question, "Mensaje")
                Me.DgvProveedor.RefreshEdit()
            End If
            DgvProveedor.DataSource = DS.Tables(0)
            LimpiaGrid()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.DgvProveedor.Columns(0).Width = 50
        Me.DgvProveedor.Columns(1).Width = 50
        Me.DgvProveedor.Columns(2).Width = 250
        Me.DgvProveedor.Columns(3).Width = 250
        Me.DgvProveedor.Columns(4).Width = 75
        Me.DgvProveedor.Columns(5).Width = 100
    End Sub

    Private Sub LimpiaCampos()
        Me.TxtCodigoProv.Text = ""
        Me.TxtProveedor.Text = ""
        Me.TxtNit.Text = ""
        Me.TxtNrc.Text = ""
        Me.TxtCodigoAsta.Text = ""
    End Sub

    Private Sub BtnBuscarProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProv.Click
        BuscarProveedor()
        LimpiaCampos()
    End Sub

    Private Sub TxtCodigoProv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoProv.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If DgvProveedor.RowCount > 0 Then
                ParamNomProvee = ""
                ParamCodProvee = Nothing
                Try
                    ParamNomProvee = DgvProveedor.Rows(0).Cells(2).Value()
                    ParamCodProvee = DgvProveedor.Rows(0).Cells(0).Value()
                Catch ex As Exception
                End Try
                Me.Close()
            End If
        End If
    End Sub

    Private Sub FrmBuscarProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        BtnBuscarProv.PerformClick()
    End Sub

    Private Sub TxtNit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNit.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If DgvProveedor.RowCount > 0 Then
                ParamNomProvee = ""
                ParamCodProvee = Nothing
                Try
                    ParamNomProvee = DgvProveedor.Rows(0).Cells(2).Value()
                    ParamCodProvee = DgvProveedor.Rows(0).Cells(0).Value()
                Catch ex As Exception
                End Try
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TxtNrc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNrc.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If DgvProveedor.RowCount > 0 Then
                ParamNomProvee = ""
                ParamCodProvee = Nothing
                Try
                    ParamNomProvee = DgvProveedor.Rows(0).Cells(2).Value()
                    ParamCodProvee = DgvProveedor.Rows(0).Cells(0).Value()
                Catch ex As Exception
                End Try
                Me.Close()
            End If
        End If
    End Sub

    Private Sub DgvProveedor_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProveedor.CellClick
        ParamNomProvee = ""
        ParamCodProvee = Nothing
        Try
            ParamNomProvee = DgvProveedor.CurrentRow.Cells(2).Value()
            ParamCodProvee = DgvProveedor.CurrentRow.Cells(0).Value()
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub

    Private Sub TxtProveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProveedor.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If DgvProveedor.RowCount > 0 Then
                ParamNomProvee = ""
                ParamCodProvee = Nothing
                Try
                    ParamNomProvee = DgvProveedor.Rows(0).Cells(2).Value()
                    ParamCodProvee = DgvProveedor.Rows(0).Cells(0).Value()
                Catch ex As Exception
                End Try
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TxtCodigoAsta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoAsta.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            BtnBuscarProv.PerformClick()
        End If
    End Sub

    Private Sub TxtCodigoProv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProv.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 0
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtCodigoProv.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & TxtCodigoProv.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT


        End If
    End Sub

    Private Sub TxtProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 2
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtProveedor.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & TxtProveedor.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT
        End If
    End Sub

    Private Sub TxtCodigoAsta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoAsta.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtCodigoAsta.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & TxtCodigoAsta.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT


        End If
    End Sub

    Private Sub TxtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNit.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 5
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNit.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & TxtNit.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT

        End If
    End Sub

    Private Sub TxtNrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNrc.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 4
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TxtNrc.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & TxtNrc.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT

        End If
    End Sub

    Private Sub txtComercial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComercial.KeyPress
        If InStr(1, "'" & Chr(8), e.KeyChar) = 1 Then
            e.KeyChar = ""
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If DgvProveedor.RowCount > 0 Then
                ParamNomProvee = ""
                ParamCodProvee = Nothing
                Try
                    ParamNomProvee = DgvProveedor.Rows(0).Cells(2).Value()
                    ParamCodProvee = DgvProveedor.Rows(0).Cells(0).Value()
                Catch ex As Exception
                End Try
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtComercial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComercial.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 3
        Dim Ncolumn As String = DgvProveedor.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case DgvProveedor.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = DS.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If Me.txtComercial.Text = "" Then
            Me.DgvProveedor.DataSource = DS.Tables(0)
        Else
            rows = DS.Tables(0).Select("[" & DgvProveedor.Columns(columna).Name & "] like '" & Me.txtComercial.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.DgvProveedor.DataSource = tablaT
        End If
    End Sub

    Private Sub FrmBuscarProveedor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class