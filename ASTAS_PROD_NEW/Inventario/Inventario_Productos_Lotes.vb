Imports System.Data.SqlClient

Public Class Inventario_Productos_Lotes
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim ColorFondo As Color, bodega1 As Integer, codigo1 As Integer, bandera As Integer = 0, descripcion1 As String, unidad_medida1 As String, saldo1 As String
    Dim Table As DataTable
    Dim c_data2 As New jarsClass

    Private Sub Inventario_Productos_Lotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        CargaBodegas(Compañia, 5)
        CargaUnidadMedida(Compañia, 1)
        ColorFondo = Me.lblLoteVencido.BackColor
        If bandera = 1 Then
            lblPRODUCTO.Text = codigo1
            Me.cmbBODEGA.SelectedValue = bodega1

            Me.lblDESCRIPCION_PRODUCTO.Text = descripcion1
            Me.cmbUNIDAD_MEDIDA.Text = unidad_medida1

            cmbBODEGA.Enabled = False
            lblPRODUCTO.Enabled = False
            btnBuscar.Enabled = False

        End If
        Iniciando = False
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal bodega As Integer, ByVal codigo As Integer, ByVal descripcion As String, ByVal unidad_medida As String, ByVal saldo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        bodega1 = bodega
        codigo1 = Val(codigo)
        descripcion1 = descripcion
        unidad_medida1 = unidad_medida
        bandera = 1
        saldo1 = saldo
    End Sub

    Private Sub CargaBodegas(ByVal Compañia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)
        Dim i As Integer
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ", @COMPAÑIA=" & Compañia
            Sql &= ", @USUARIO='" & Usuario & "'"
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

    Private Sub CargaUnidadMedida(ByVal Compañia, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)
        Dim i As Integer
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbUNIDAD_MEDIDA.DataSource = Table
            Me.cmbUNIDAD_MEDIDA.ValueMember = "Unidad Medida"
            Me.cmbUNIDAD_MEDIDA.DisplayMember = "Descripción Unidad"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarProducto(ByVal Compañia, ByVal Bodega, ByVal Producto)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            Sql &= "@COMPAÑIA=" & Compañia
            Sql &= ",@BODEGA= " & Bodega
            Sql &= ",@PRODUCTO= " & Producto
            Sql &= ",@DESCRIPCION_PRODUCTO= '' " 'Descripción del Producto
            Sql &= ",@GRUPO= 0" 'Código de Grupo
            Sql &= ",@BANDERA= 2" 'Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            LimpiaCampos()
            If DataReader_.Read Then
                Me.lblPRODUCTO.Text = DataReader_.Item("PRODUCTO")
                Me.lblDESCRIPCION_PRODUCTO.Text = DataReader_.Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.SelectedValue = DataReader_.Item("UNIDAD_MEDIDA")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLotes(ByVal Compañia, ByVal Bodega, ByVal Prod, ByVal UM, ByVal Lote, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_LOTES "
            Sql &= "@COMPAÑIA=" & Compañia
            Sql &= ",@BODEGA= " & Bodega
            Sql &= ",@PRODUCTO= " & Prod
            Sql &= ",@UNIDAD_MEDIDA= " & UM
            Sql &= ",@LOTE= '" & Lote & "'"
            Sql &= ",@BANDERA= " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvLotes.Columns.Clear()
            Me.dgvLotes.DataSource = Table
            LimpiaGridLotes()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaBodegas(Compañia, 5)
            CargaUnidadMedida(Compañia, 1)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia

        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        Producto = ""
        Descripcion_Producto = ""
        Frm_Busqueda.ShowDialog()

        If Producto <> "" Then
            Me.lblPRODUCTO.Text = Producto

            BuscarProducto(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text)
            CargaLotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, "", 2)
            Producto = ""
        End If
    End Sub

    Private Sub LimpiaCampos()
        Me.lblLoteVencido.Text = "Lote :"
        Me.lblLoteVencido.ForeColor = Color.Black
        Me.lblLoteVencido.BackColor = ColorFondo
        Me.lblLoteVencido.BorderStyle = BorderStyle.None

        Me.txtLOTE.Enabled = True
        Me.lblPRODUCTO.Text = ""
        Me.lblDESCRIPCION_PRODUCTO.Text = ""
        Me.txtLOTE.Text = ""
        Me.txtDESCRIPCION_LOTE.Text = ""
        Me.chkTieneVencimiento.Checked = False
        CargaLotes(0, 0, "0", 0, "", 2)
    End Sub

    Private Function ValidaCampos() As Boolean
        If Me.lblPRODUCTO.Text = "" Then
            MsgBox("¡Debe seleccionar un Producto válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtLOTE.Text) = "" Then
            MsgBox("¡Debe ingresar un Lote válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtDESCRIPCION_LOTE.Text = "" Then
            MsgBox("¡Debe ingresar una Descripción válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.chkTieneVencimiento.Checked = True Then
            If CDate(Me.dpFECHA_VENCIMIENTO.Value.ToShortDateString) <= CDate(Now.ToShortDateString) Then
                MsgBox("¡Ingrese una Fecha de Vencimiento válida!" & Chr(13) & "Debe ser mayor al día de ahora. Verifique", MsgBoxStyle.Critical, "Validación")
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Private Sub Mantenimiento_Lotes(ByVal Compañia, ByVal Bodega, ByVal CodProducto, ByVal UM, ByVal Lote, ByVal DescLote, ByVal Vencimiento, ByVal FechaVencimiento, _
    ByVal SaldoUM, ByVal SaldoLIbra, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_LOTES_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & CodProducto
            Sql &= ", " & UM
            Sql &= ", '" & Lote & "'"
            Sql &= ", '" & DescLote & "'"
            Sql &= ", " & Vencimiento
            Sql &= ", '" & FechaVencimiento & "'"
            Sql &= ", " & IIf(saldo1 = "", 0, saldo1)
            Sql &= ", " & SaldoLIbra
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Lote Almacenado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Lote Actualizado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "A"
                    MsgBox("¡Lote Actualizado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Lote Eliminado en Bodega con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function VerificaExistencia_Lotes(ByVal Compañia, ByVal Bodega, ByVal CodProducto, ByVal UM, ByVal Lote) As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion.Usuario = UsuarioDB
        Conexion.Password = PasswordDB
        Conexion.Servidor = Servidor
        Conexion.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_LOTES "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & CodProducto
            Sql &= ", " & UM
            Sql &= ", '" & Lote & "'"
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("EXISTE") <> "" Then
                    'MsgBox("¡El Lote que desea ingresar ya Existe! Verifique", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub LimpiaGridLotes()
        For i As Integer = 1 To Me.dgvLotes.Columns.Count
            Me.dgvLotes.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Me.dgvLotes.Columns(6).Width = 75
        Me.dgvLotes.Columns(7).Width = 125

        'Me.dgvLotes.Columns(5).DefaultCellStyle.ForeColor = Color.Red
        'Me.dgvLotes.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub chkTieneVencimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTieneVencimiento.CheckedChanged
        Me.dpFECHA_VENCIMIENTO.Enabled = Me.chkTieneVencimiento.Checked
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If VerificaExistencia_Lotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Trim(Me.txtLOTE.Text)) = True Then
                Mantenimiento_Lotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Trim(Me.txtLOTE.Text), _
                                    Trim(Me.txtDESCRIPCION_LOTE.Text), IIf(Me.chkTieneVencimiento.Checked = True, "1", "0"), Format(Me.dpFECHA_VENCIMIENTO.Value, "dd-MM-yyyy 23:59:59"), 0, 0, "I")
            Else
                Mantenimiento_Lotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Trim(Me.txtLOTE.Text), _
                                    Trim(Me.txtDESCRIPCION_LOTE.Text), IIf(Me.chkTieneVencimiento.Checked = True, "1", "0"), Format(Me.dpFECHA_VENCIMIENTO.Value, "dd-MM-yyyy 23:59:59"), saldo1, 0, "A")
            End If
            Me.txtLOTE.Text = ""
            Me.txtDESCRIPCION_LOTE.Text = ""
            Me.chkTieneVencimiento.Checked = False
            CargaLotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, "", 2)
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        LimpiaCampos()
    End Sub
    Private Sub txtDESCRIPCION_LOTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_LOTE.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = dgvLotes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvLotes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_LOTE.Text = "" Then
            Me.dgvLotes.DataSource = Table
        Else
            Try
                rows = Table.Select(dgvLotes.Columns(columna).Name & " like '" & txtDESCRIPCION_LOTE.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvLotes.DataSource = tablaT
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dgvLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvLotes.Click
        Try
            Me.txtLOTE.Text = Me.dgvLotes.CurrentRow.Cells.Item(0).Value
            Me.txtDESCRIPCION_LOTE.Text = Me.dgvLotes.CurrentRow.Cells.Item(1).Value
            If Me.dgvLotes.CurrentRow.Cells.Item(2).Value <> "" Then
                Me.chkTieneVencimiento.Checked = True
                Me.dpFECHA_VENCIMIENTO.Value = CDate(Me.dgvLotes.CurrentRow.Cells.Item(2).Value)
            End If
            If Me.dgvLotes.CurrentRow.Cells.Item(5).Value = True Then
                Me.lblLoteVencido.Text = "VENCIDO"
                Me.lblLoteVencido.ForeColor = Color.Red
                Me.lblLoteVencido.BackColor = Color.Yellow
                Me.lblLoteVencido.BorderStyle = BorderStyle.FixedSingle
                Me.txtLOTE.Enabled = False
            Else
                Me.lblLoteVencido.Text = "Lote :"
                Me.lblLoteVencido.ForeColor = Color.Black
                Me.lblLoteVencido.BackColor = ColorFondo
                Me.lblLoteVencido.BorderStyle = BorderStyle.None
                Me.txtLOTE.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblPRODUCTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblPRODUCTO.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try

                Me.lblDESCRIPCION_PRODUCTO.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.lblPRODUCTO.Text & ", @BANDERA=1", 1)
                Me.cmbUNIDAD_MEDIDA.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.lblPRODUCTO.Text & ", @BANDERA=1", 2)

                If lblDESCRIPCION_PRODUCTO.Text = "" Then
                    MsgBox("AVISO...Codigo No existe en esta bodega", MsgBoxStyle.Information)
                Else
                    Me.txtLOTE.Focus()
                End If
            Catch ex As Exception
                lblPRODUCTO.Text = ""
                MsgBox("El codigo es numerico", MsgBoxStyle.Information)
            End Try
        End If
    End Sub
    Public Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F1 here.
                Me.Close()
        End Select
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("Eliminar Lote?", MsgBoxStyle.YesNo, "AVISO") = MsgBoxResult.Yes Then
            Mantenimiento_Lotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, Trim(Me.txtLOTE.Text), _
                    Trim(Me.txtDESCRIPCION_LOTE.Text), IIf(Me.chkTieneVencimiento.Checked = True, "1", "0"), Format(Me.dpFECHA_VENCIMIENTO.Value, "dd-MM-yyyy 23:59:59"), 0, 0, "D")
            CargaLotes(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO.Text, Me.cmbUNIDAD_MEDIDA.SelectedValue, "", 2)
        End If
    End Sub

    Private Sub txtLOTE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLOTE.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(27) Then
            Me.Close()
        End If
    End Sub
End Class