Imports System.Data.SqlClient
Public Class Inventario_CambioPrecio_Producto
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table As DataTable
    Dim Table2 As DataTable
    Dim Table3 As DataTable
    Dim c_data2 As New jarsClass
    Dim bandera As Boolean, Actualizar As Boolean = False
    Dim DS01, DS02, DS03 As New DataSet()
    Dim intPromocion As Integer = 0
    Private Sub Inventario_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.txtCompañia1.Text = Descripcion_Compañia
        Refrescar()
        Iniciando = False
    End Sub
    Public Sub Refrescar()
        Try
            CargaBodegas(Compañia, 5, cmbBODEGA, "Bodega", "Descripción")
            CargarGrupos()
            CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1, 999)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compañia As Object, ByVal Bandera As Object, ByVal Cmb As ComboBox, ByVal value As Object, ByVal display As Object)
        'Dim i As Integer
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ",@COMPAÑIA= " & Compañia
            Sql &= ",@USUARIO= '" & Usuario & "'"
            c_data2.CargarCombo(Cmb, Sql, value, display)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub LimpiaCamposProductosBodega()
        Me.txtPrecio.Text = 0.0
        Me.TXT_CODIGO.Text = ""
        TXT_DESCRIPCION.Text = ""
    End Sub

    Private Sub LimpiaGridProductosBodega()
        Me.dgvProductosBodega.Columns(0).Width = 80
        Me.dgvProductosBodega.Columns(1).Width = 350
        Me.dgvProductosBodega.Columns(2).Width = 100
        Me.dgvProductosBodega.Columns(3).Width = 80
        Me.dgvProductosBodega.Columns(5).Width = 80
        Me.dgvProductosBodega.Columns(4).Visible = False
        Me.dgvProductosBodega.Columns(6).Visible = False
        Me.dgvProductosBodega.Columns(7).Visible = False
        Me.dgvProductosBodega.Columns(8).Visible = False
        Me.dgvProductosBodega.Columns(9).Visible = False
        Me.dgvProductosBodega.Columns(10).Visible = False
        Me.dgvProductosBodega.Columns(11).Visible = False
    End Sub

    Private Sub CargaProductosBodegaBusquedasAvanz(ByVal Compañia, ByVal Bodega, ByVal Prod, ByVal DescripcionProducto, ByVal Habilitado, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA_2 "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Prod
            Sql &= ", '" & DescripcionProducto & "'"
            Sql &= ", " & Habilitado
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvProductosBodega.Columns.Clear()
            Me.dgvProductosBodega.DataSource = Table
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub CargaProductosBodega(ByVal Compañia, ByVal Bodega, ByVal Prod, ByVal DescripcionProducto, ByVal Grupo, ByVal Bandera, ByVal subgrupo)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter

        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Prod
            Sql &= ", '" & DescripcionProducto & "'"
            Sql &= ", " & Grupo
            Sql &= ", " & Bandera
            Sql &= ", " & subgrupo
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table2 = New DataTable("Datos")
            DataAdapter_.Fill(Table2)
            'Me.dgvProductosBodega.Columns.Clear()
            Me.dgvProductosBodega.DataSource = Table2
            LimpiaGridProductosBodega()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub CargaSubGrupo(ByVal Compañia, ByVal Grupo, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS "
            Sql &= Compañia
            Sql &= ", " & Grupo
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbSUBGRUPO.DataSource = Table
            Me.cmbSUBGRUPO.ValueMember = "Sub Grupo"
            Me.cmbSUBGRUPO.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Public Sub CargarGrupos()
        c_data2.CargarCombo(cmbGRUPO, "Execute sp_INVENTARIOS_CATALOGO_GRUPOS @COMPAÑIA=" & Compañia & ", @BANDERA=4", "Grupo", "Descripción_Grupo")
    End Sub

    Private Sub Mantenimiento_ProductoBodega(ByVal Compañia, ByVal Bodega, ByVal CodProducto, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = " Update INVENTARIOS_PRODUCTOS_BODEGAS  SET PRECIO_UNITARIO = " & txtPrecio.Text & " , USUARIO_EDICION = '" & Usuario & "'" & _
            " , USUARIO_EDICION_FECHA = GETDATE() WHERE COMPAÑIA = " & Compañia & " AND BODEGA   = " & Bodega & "   AND PRODUCTO = " & CodProducto
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Producto Almacenado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Producto Actualizado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Producto Eliminado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox("La operacion no se ha podido realizar!!! El producto esta siendo utilizado!", MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1, 999)
            LimpiaCamposProductosBodega()
        End If
    End Sub

    Private Sub btnNuevoPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiaCamposProductosBodega()
    End Sub

    
    Private Sub TXT_DESCRIPCION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_DESCRIPCION.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1 '1  
        Dim Ncolumn As String = dgvProductosBodega.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvProductosBodega.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table2.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TXT_DESCRIPCION.Text = "" Then
            Me.dgvProductosBodega.DataSource = Table2
        Else
            rows = Table2.Select("[" & dgvProductosBodega.Columns(columna).Name & "] like '" & TXT_DESCRIPCION.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvProductosBodega.DataSource = tablaT
        End If

    End Sub


    Private Sub txtPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtPrecio.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtPrecio.Text = ""
                Else
                    e.Handled = txtPrecio.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtPrecio.Text = ""
            End If
        End If
    End Sub


    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro que desea eliminar el Producto de la Bodega?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_ProductoBodega(Compañia, Me.cmbBODEGA.SelectedValue, TXT_CODIGO.Text, "D")
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1, 999)
            LimpiaCamposProductosBodega()
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("¿Desea modificar el Producto de la Bodega?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If Trim(Me.TXT_CODIGO.Text) = "" Or Trim(Me.TXT_DESCRIPCION.Text) = "" Then
                MsgBox("¡Debe seleccionar un Producto poder modificarlo!", MsgBoxStyle.Critical, "Validación")
            Else
                If Trim(Me.txtPrecio.Text) = "" OrElse Val(Me.txtPrecio.Text) = 0 Then
                    MsgBox("¡Debe Ingresar el valor del Precio de Venta...!", MsgBoxStyle.Critical, "Validación")
                Else
                    Mantenimiento_ProductoBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, "U")
                End If

            End If
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, "", 999, 1, 999)
            LimpiaCamposProductosBodega()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub dgvProductosBodega_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductosBodega.CellClick
        Try
            Me.TXT_CODIGO.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(0).Value
            Me.TXT_DESCRIPCION.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(1).Value
            Me.txtPrecio.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(3).Value
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TXT_CODIGO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_CODIGO.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
       
    End Sub
    Private Sub TXT_CODIGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_CODIGO.TextChanged
        
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 0 '1  
        Dim Ncolumn As String = dgvProductosBodega.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvProductosBodega.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table2.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If TXT_CODIGO.Text = "" Then
            Me.dgvProductosBodega.DataSource = Table2
        Else
            rows = Table2.Select("[" & dgvProductosBodega.Columns(columna).Name & "] like '" & TXT_CODIGO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            ' return filtered dt            
            Me.dgvProductosBodega.DataSource = tablaT
        End If

    End Sub
    Private Sub TextBox1_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub dgvProductosBodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvProductosBodega.Click
        Try
            Me.TXT_CODIGO.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(0).Value
            Me.TXT_DESCRIPCION.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(1).Value
            Me.txtPrecio.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(3).Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TXT_CODIGO.Text = ""
        TXT_DESCRIPCION.Text = ""
        txtPrecio.Text = ""
        CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1, 999)
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
            LimpiaCamposProductosBodega()
        End If
    End Sub

    Private Sub cmbSUBGRUPO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSUBGRUPO.SelectedIndexChanged
        If Actualizar = True Then
        Else
            If Iniciando = False Then
                'lblPRODUCTO.Text = c_data2.leerDataeader("EXECUTE sp_INVENTARIO_GENERAR_CODIGO @COMPAÑIA=" & Compañia & ",@GRUPO=" & cmbGRUPO.SelectedValue & ",@SUBGRUPO=" & cmbSUBGRUPO.SelectedValue, 0).ToString.PadLeft(4, "0")
                CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", cmbGRUPO.SelectedValue, 1, cmbSUBGRUPO.SelectedValue)
                LimpiaCamposProductosBodega()
            End If
        End If
    End Sub
End Class