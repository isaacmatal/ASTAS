Imports System.Data.SqlClient

Public Class Inventario_Productos_Cafe
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table As DataTable
    Dim Table2 As DataTable
    Dim Table3 As DataTable
    Dim c_data2 As New jarsClass
    Dim bandera As Boolean, Actualizar As Boolean = False
    Dim DS01, DS02, DS03 As New DataSet()
    Private Sub Inventario_Productos_Cafe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.txtCompañia.Text = Descripcion_Compañia
        Me.txtCompañia1.Text = Descripcion_Compañia
        Refrescar()
        Iniciando = False
    End Sub
    Public Sub Refrescar()
        Try
            CargaTipoCosto(Compañia, 1, cmbTIPO_COSTO)
            CargaBodegas(Compañia, 5, cmbBODEGA, "Bodega", "Descripción")
            CargarGrupos()
            'CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2, cmbSUBGRUPO)
            CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
            CargaUM(Compañia, 5, cmbUNIDAD_MEDIDA)
            CargaProductos(Compañia, 999, 999, "", 1)
            'YA
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarGrupos()
        c_data2.CargarCombo(cmbGRUPO, "Execute sp_INVENTARIOS_CATALOGO_GRUPOS @COMPAÑIA=" & Compañia & ", @BANDERA=6", "Grupo", "Descripción_Grupo")
    End Sub
    Private Sub CargaBodegas(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox, ByVal value As String, ByVal display As String)
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

    Private Sub CargaUM(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_UNIDAD_MEDIDA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            c_data2.CargarCombo(Cmb, Sql, "Unidad Medida", "Descripción Unidad")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Private Sub CargaTipoCosto(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox)
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_TIPO_COSTO "
            Sql &= Compañia
            Sql &= ", " & Bandera
            c_data2.CargarCombo(Cmb, Sql, "Tipo Costo", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    'Private Sub CargaSubGrupo(ByVal Compañia As Integer, ByVal Grupo As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox)
    Private Sub CargaSubGrupo(ByVal Compañia As Integer, ByVal Grupo As Integer, ByVal Bandera As Integer)
        'Try
        '    Sql = "Execute sp_INVENTARIOS_CATALOGO_GRUPOS_SUBGRUPOS "
        '    Sql &= Compañia
        '    Sql &= ", " & Grupo
        '    Sql &= ", " & Bandera
        '    c_data2.CargarCombo(Cmb, Sql, "Sub Grupo", "Descripción")
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        'End Try
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
    Private Sub LimpiaCamposProducto()
        Me.lblPRODUCTO.Text = ""
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.chkSERVICIO.Checked = False
        Me.txtMARGEN.Text = ""
        Me.txtPRODUCTO_ANTERIOR.Text = ""
        Me.rbtnLIBRA_NO.Checked = True
        Me.chkNoStock.Checked = False
        Me.TextBox1.Text = 1
        Me.CheckBox1.Checked = True
    End Sub

    Private Sub LimpiaCamposProductosBodega()
        Me.lblDESCRIPCION_PRODUCTO_PB.Text = ""
        Me.lblExiste_Bodega.Visible = False
        Me.txtPrecio.Text = 0.0
        Me.TXT_CODIGO.Text = ""

    End Sub

    Private Sub LimpiaGridProductos()
        Me.dgvProductos.Columns(3).Visible = False
        Me.dgvProductos.Columns(8).Visible = False
        Me.dgvProductos.Columns(11).Visible = False
        Me.dgvProductos.Columns(13).Visible = False

        For i As Integer = 1 To Me.dgvProductos.Columns.Count
            Me.dgvProductos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Me.dgvProductos.Columns(15).Width = 75
        Me.dgvProductos.Columns(16).Width = 125
        Me.dgvProductos.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvProductos.Columns.Item(1).Frozen = True
        Me.dgvProductos.Columns.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        Me.dgvProductos.Columns.Item(1).DefaultCellStyle.BackColor = Color.LightGray

    End Sub

    Private Sub LimpiaGridProductosBodega()
        For i As Integer = 1 To Me.dgvProductosBodega.Columns.Count
            Me.dgvProductosBodega.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Me.dgvProductosBodega.Columns(5).Width = 75
        Me.dgvProductosBodega.Columns(6).Width = 125
        Me.dgvProductosBodega.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    End Sub

    Private Sub CargaProductos(ByVal Compañia, ByVal Grupo, ByVal SubGrupo, ByVal DescripcionProducto, ByVal Bandera)
        'Dim Conexion As New DLLConnection.Connection
        'Dim Conexion_ As New SqlConnection
        'Dim Comando_ As SqlCommand
        'Dim DataAdapter_ As SqlDataAdapter
        'Conexion.Usuario = UsuarioDB
        'Conexion.Password = PasswordDB
        'Conexion.Servidor = Servidor
        'Conexion.Catalogo = BaseDatos
        'Conexion_ = New SqlConnection(Conexion.Obtiene_Cadena_Cnn_SQL)

        'Try
        '    Conexion_.Open()
        '    Sql = "Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS_BUSQUEDA "
        '    Sql &= Compañia
        '    Sql &= ", " & Grupo
        '    Sql &= ", " & SubGrupo
        '    Sql &= ", '" & DescripcionProducto & "'"
        '    Sql &= ", " & Bandera
        '    Sql &= ", 1"
        '    Comando_ = New SqlCommand(Sql, Conexion_)
        '    DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
        '    Table3 = New DataTable("Datos")
        '    DataAdapter_.Fill(Table3)
        '    Me.dgvProductos.Columns.Clear()
        '    Me.dgvProductos.DataSource = Table3
        '    'LimpiaGridProductos()
        '    Conexion_.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        'End Try

        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS_BUSQUEDA "
            Sql &= Compañia
            Sql &= ", " & Grupo
            Sql &= ", " & SubGrupo
            Sql &= ", '" & DescripcionProducto & "'"
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table3 = New DataTable("Datos")
            DataAdapter_.Fill(Table3)
            Me.dgvProductos.Columns.Clear()
            Me.dgvProductos.DataSource = Table3
            'LimpiaGridProductos()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
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
            'LimpiaGridProductosBodega()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub CargaProductosBodega(ByVal Compañia, ByVal Bodega, ByVal Prod, ByVal DescripcionProducto, ByVal Grupo, ByVal Bandera)
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
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table2 = New DataTable("Datos")
            DataAdapter_.Fill(Table2)
            'Me.dgvProductosBodega.Columns.Clear()
            Me.dgvProductosBodega.DataSource = Table2
            'LimpiaGridProductosBodega()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub


    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_PRODUCTO.Text) = "" Then
            MsgBox("¡Ingrese una Descripción de Producto válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbGRUPO.Text = "" Then
            MsgBox("¡Seleccione un Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbSUBGRUPO.Text = "" Then
            MsgBox("¡Seleccione un Sub Grupo de Productos válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbUNIDAD_MEDIDA.Text = "" Then
            MsgBox("¡Seleccione una Unidad de Medida válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbTIPO_COSTO.Text = "" Then
            MsgBox("¡Seleccione unTipo de Costo válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Sub Mantenimiento_Producto(ByVal Compañia, ByVal CodProducto, ByVal Grupo, ByVal SubGrupo, ByVal Producto_Ant, ByVal Descripcion, _
    ByVal UnidadMedida, ByVal UMLIbra, ByVal Servicio, ByVal Stock, ByVal TipoCosto, ByVal Margen, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim si_no As String
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_PRODUCTOS_IUD "
            Sql &= Compañia
            Sql &= ", " & CodProducto
            Sql &= ", " & Grupo
            Sql &= ", " & SubGrupo
            Sql &= ", " & Producto_Ant
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & UnidadMedida
            Sql &= ", " & UMLIbra
            Sql &= ", " & Servicio
            Sql &= ", " & Stock
            Sql &= ", " & TipoCosto
            Sql &= ", " & Margen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", '" & IIf(TextBox1.Text = "", " ", TextBox1.Text) & "'"
            Sql &= ", '0'"

            si_no = c_data2.leerDataeader(Sql, 0)
            If (si_no = "0") Then
                MsgBox("¡El Producto ya existe!", MsgBoxStyle.Exclamation, "Mensaje")
                Exit Sub
            End If
            Select Case IUD
                Case "I"
                    MsgBox("¡Producto Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Producto Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Producto Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox("La operacion no se ha podido realizar!!! El producto esta siendo utilizado!", MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub Mantenimiento_ProductoBodega(ByVal Compañia, ByVal Bodega, ByVal CodProducto, ByVal IUD)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim tabla As DataTable
        tabla = c_data2.ejecutaSQLl_llenaDTABLE("SELECT BODEGA FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND  GRUPO_BODEGA=" & 2)

        Try
            For i As Integer = 0 To tabla.Rows.Count - 1
                Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_IUD "
                Sql &= Compañia
                Sql &= ", " & tabla.Rows(i).Item(0).ToString()
                Sql &= ", " & CodProducto
                Sql &= ", " & IIf(txtPrecio.Text = "", "0", txtPrecio.Text)
                Sql &= ", '" & Usuario & "'"
                Sql &= ", " & hab_busqueda.CheckState
                Sql &= ", " & chq_Tipo_precio.CheckState
                Sql &= ", '" & IUD & "'"
                c_data2.Ejecutar_ConsultaSQL(Sql)
            Next
            'Conexion_.Open()
            'Sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_IUD "
            'Sql &= Compañia
            'Sql &= ", " & Bodega
            'Sql &= ", " & CodProducto
            'Sql &= ", " & IIf(txtPrecio.Text = "", "0", txtPrecio.Text)
            'Sql &= ", '" & Usuario & "'"
            'Sql &= ", " & hab_busqueda.CheckState
            'Sql &= ", " & chq_Tipo_precio.CheckState
            'Sql &= ", '" & IUD & "'"
            'Comando_ = New SqlCommand(Sql, Conexion_)
            'Comando_.ExecuteNonQuery()
            'Conexion_.Close()
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


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCamposProducto()
        Refrescar()
        Actualizar = False
        lblPRODUCTO.Enabled = True
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargarGrupos()
            CargaUM(Compañia, 4, cmbUNIDAD_MEDIDA)
            CargaTipoCosto(Compañia, 1, cmbTIPO_COSTO)
            CargaProductos(Compañia, 999, 999, "", 1)
            Refrescar()
        End If
    End Sub

    Private Sub cmbGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGRUPO.SelectedIndexChanged
        If Iniciando = False Then
            'CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2, cmbSUBGRUPO)
            CargaSubGrupo(Compañia, Me.cmbGRUPO.SelectedValue, 2)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            'Tabla con grupos y sub grupos que requieren porcentaje operativo obligatoriamente
            Dim Requieren_Porcentaje As DataTable
            Requieren_Porcentaje = c_data2.ejecutaSQLl_llenaDTABLE("EXECUTE sp_OBTENER_PARAMETROS @BANDERA=1")
            For i As Integer = 0 To Requieren_Porcentaje.Rows.Count - 1
                If cmbGRUPO.SelectedValue = Requieren_Porcentaje.Rows(i).Item(0) Then
                    If cmbSUBGRUPO.SelectedValue = Requieren_Porcentaje.Rows(i).Item(1) Then
                        If txtMARGEN.Text = "" Then
                            MsgBox("Para este grupo y sub grupo es requerido el margen gasto operativo", MsgBoxStyle.Information, "Mensaje")
                            Exit Sub
                        End If

                    End If
                End If
            Next
            If Actualizar = False Then
                Mantenimiento_Producto(Compañia, Me.lblPRODUCTO.Text.PadLeft(4, "0"), Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue, Val(Me.txtPRODUCTO_ANTERIOR.Text), _
                Trim(Me.txtDESCRIPCION_PRODUCTO.Text.Replace("'", "")), Me.cmbUNIDAD_MEDIDA.SelectedValue, IIf(Me.rbtnLIBRA_SI.Checked = True, "1", "0"), IIf(Me.chkSERVICIO.Checked = True, "1", "0"), IIf(Me.chkNoStock.Checked = True, "0", "1"), Me.cmbTIPO_COSTO.SelectedValue, Val(Me.txtMARGEN.Text), "I")
            Else
                Mantenimiento_Producto(Compañia, Me.lblPRODUCTO.Text.PadLeft(4, "0"), Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue, Val(Me.txtPRODUCTO_ANTERIOR.Text), _
                Trim(Me.txtDESCRIPCION_PRODUCTO.Text.Replace("'", "")), Me.cmbUNIDAD_MEDIDA.SelectedValue, IIf(Me.rbtnLIBRA_SI.Checked = True, "1", "0"), IIf(Me.chkSERVICIO.Checked = True, "1", "0"), IIf(Me.chkNoStock.Checked = True, "0", "1"), Me.cmbTIPO_COSTO.SelectedValue, Val(Me.txtMARGEN.Text), "U")
                lblPRODUCTO.Enabled = True
                Actualizar = False
            End If
            CargaProductos(Compañia, Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue, Trim(Me.txtDESCRIPCION_PRODUCTO.Text), 1)
            LimpiaCamposProducto()
        End If
    End Sub

    Private Sub txtMARGEN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMARGEN.KeyPress
        Dim Cadena As String = Me.txtMARGEN.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = Cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtMARGEN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMARGEN.TextChanged

    End Sub

    Private Sub txtPRODUCTO_ANTERIOR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO_ANTERIOR.KeyPress
        Dim Cadena As String = Me.txtPRODUCTO_ANTERIOR.Text
        If e.KeyChar <> ControlChars.Back And Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = Nothing
        End If
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.lblPRODUCTO.Text) <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Producto seleccionado?" & Chr(13) & _
                      "Antes de eliminarlo deberá  eliminar los  registros  en  las" & Chr(13) & _
                      "Bodegas a donde esté especificado.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Producto(Compañia, Val(Me.lblPRODUCTO.Text), Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue, Val(Me.txtPRODUCTO_ANTERIOR.Text), _
                Trim(Me.txtDESCRIPCION_PRODUCTO.Text), Me.cmbUNIDAD_MEDIDA.SelectedValue, IIf(Me.rbtnLIBRA_SI.Checked = True, "1", "0"), IIf(Me.chkSERVICIO.Checked = True, "1", "0"), IIf(Me.chkNoStock.Checked = True, "0", "1"), Me.cmbTIPO_COSTO.SelectedValue, Val(Me.txtMARGEN.Text), "D")
                CargaProductos(Compañia, Me.cmbGRUPO.SelectedValue, Me.cmbSUBGRUPO.SelectedValue, "", 1)
                LimpiaCamposProducto()
            End If
        Else
            MsgBox("¡Debe seleccionar un Producto válido! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub cmbCOMPAÑIA_PB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaBodegas(Compañia, 5, cmbBODEGA, "Bodega", "Descripción")
        End If
    End Sub

    Private Sub btnBuscar_PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar_PB.Click
        If Me.lblPRODUCTO_PB.Text = "" Then
            Dim Productos As New Inventario_BusquedaProductos
            Productos.Compañia_Value = Compañia
            Productos.BuscaProductosStock = False
            Numero = ""
            Producto = ""
            Descripcion_Producto = ""
            Productos.ShowDialog()

            If Numero <> Nothing Then
                Me.lblPRODUCTO_PB.Text = CodigoProducto
                Me.lblDESCRIPCION_PRODUCTO_PB.Text = Numero

                CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text, Me.lblDESCRIPCION_PRODUCTO_PB.Text, 999, 1)

                If Me.dgvProductosBodega.Rows.Count > 0 Then
                    Me.lblExiste_Bodega.Visible = True
                Else
                    Me.lblExiste_Bodega.Visible = False
                End If
            End If
            Numero = ""
            Producto = ""
        Else
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text, Me.lblDESCRIPCION_PRODUCTO_PB.Text, 999, 1)
            If Me.dgvProductos.Rows.Count > 0 Then
                Me.lblExiste_Bodega.Visible = True
            Else
                Me.lblExiste_Bodega.Visible = False
            End If
        End If
    End Sub
    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1)
        End If
    End Sub

    Private Sub btnNuevoPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPB.Click
        LimpiaCamposProductosBodega()
    End Sub

    Private Sub btnGuardar_PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar_PB.Click
        If MsgBox("¿Desea adicionar Producto a la Bodega?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If Trim(Me.lblPRODUCTO_PB.Text) = "" Then
                MsgBox("¡Debe seleccionar un Producto válido para poder asignarlo a la Bodega! Verifique", MsgBoxStyle.Critical, "Validación")
            Else
                Mantenimiento_ProductoBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text, "I")
            End If
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.lblPRODUCTO_PB.Text, Me.lblDESCRIPCION_PRODUCTO_PB.Text, 999, 1)
            LimpiaCamposProductosBodega()
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If (Me.TXT_CODIGO.Text <> "" And Me.TXT_DESCRIPCION.Text = "") Then
                CargaProductosBodegaBusquedasAvanz(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.hab_busqueda.Checked.ToString(), 1)
            End If
            If (Me.TXT_CODIGO.Text = "" And Me.TXT_DESCRIPCION.Text <> "") Then
                CargaProductosBodegaBusquedasAvanz(Compañia, Me.cmbBODEGA.SelectedValue, 0, Me.txtDESCRIPCION_PRODUCTO.Text, Me.hab_busqueda.Checked.ToString(), 2)
            End If
            If (Me.TXT_CODIGO.Text <> "" And Me.TXT_DESCRIPCION.Text <> "") Then
                CargaProductosBodegaBusquedasAvanz(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, Me.txtDESCRIPCION_PRODUCTO.Text, Me.hab_busqueda.Checked.ToString(), 5)
            End If
            If (Me.TXT_CODIGO.Text = "" And Me.TXT_DESCRIPCION.Text = "") Then
                CargaProductosBodegaBusquedasAvanz(Compañia, Me.cmbBODEGA.SelectedValue, 0, 0, Me.hab_busqueda.Checked.ToString(), 3)
            End If
        Catch ex As Exception
            MessageBox.Show("VERIFIQUE LOS PARAMETROS DE BUSQUEDA")
        End Try
    End Sub

    Private Sub TXT_DESCRIPCION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_DESCRIPCION.TextChanged
        If AutoOrdenamiento.Checked = True Then
        Else
            'Else
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

                ' return filtered dt            
                Me.dgvProductosBodega.DataSource = tablaT
            End If
        End If
    End Sub
    Private Sub txtDESCRIPCION_PRODUCTO_B_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub lblPRODUCTO_PB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblPRODUCTO_PB.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                Me.lblDESCRIPCION_PRODUCTO_PB.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @PRODUCTO=" & Me.lblPRODUCTO_PB.Text & ", @BANDERA=2", 1)

                If lblDESCRIPCION_PRODUCTO_PB.Text = "" Then
                    MsgBox("AVISO...Codigo No existe en esta bodega", MsgBoxStyle.Information)
                Else
                    Me.cmbBODEGA.Focus()
                End If
            Catch ex As Exception
                lblPRODUCTO_PB.Text = ""
                MsgBox("El codigo es numerico", MsgBoxStyle.Information)
            End Try
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1)
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("¿Está seguro que desea eliminar el Producto de la Bodega?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_ProductoBodega(Compañia, Me.cmbBODEGA.SelectedValue, TXT_CODIGO.Text, "D")
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, 0, "", 999, 1)
            LimpiaCamposProductosBodega()
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("¿Desea modificar el Producto de la Bodega?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If Trim(Me.TXT_CODIGO.Text) = "" Or Trim(Me.TXT_DESCRIPCION.Text) = "" Then
                MsgBox("¡Debe seleccionar un Producto poder modificarlo!", MsgBoxStyle.Critical, "Validación")
            Else
                Mantenimiento_ProductoBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, "U")
            End If
            CargaProductosBodega(Compañia, Me.cmbBODEGA.SelectedValue, Me.TXT_CODIGO.Text, "", 999, 1)
            LimpiaCamposProductosBodega()
        End If
    End Sub

    Private Sub dgvProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvProductos.Click
        Actualizar = True
        Me.lblPRODUCTO.Text = Me.dgvProductos.CurrentRow.Cells.Item(0).Value
        Me.lblPRODUCTO.Enabled = False
        Me.txtDESCRIPCION_PRODUCTO.Text = Me.dgvProductos.CurrentRow.Cells.Item(1).Value
        Me.txtMARGEN.Text = Me.dgvProductos.CurrentRow.Cells.Item(10).Value
        Me.txtPRODUCTO_ANTERIOR.Text = Me.dgvProductos.CurrentRow.Cells.Item(2).Value
        Me.chkSERVICIO.Checked = Me.dgvProductos.CurrentRow.Cells.Item(6).Value
        Me.rbtnLIBRA_SI.Checked = Me.dgvProductos.CurrentRow.Cells.Item(5).Value
        Me.cmbGRUPO.SelectedValue = Me.dgvProductos.CurrentRow.Cells.Item(11).Value
        Me.cmbSUBGRUPO.SelectedValue = Me.dgvProductos.CurrentRow.Cells.Item(13).Value
        Me.cmbUNIDAD_MEDIDA.SelectedValue = Me.dgvProductos.CurrentRow.Cells.Item(3).Value
        Me.cmbTIPO_COSTO.SelectedValue = Me.dgvProductos.CurrentRow.Cells.Item(8).Value
        Me.chkNoStock.Checked = Not Me.dgvProductos.CurrentRow.Cells.Item(7).Value
        Me.TextBox1.Text = Me.dgvProductos.CurrentRow.Cells.Item(17).Value.ToString()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CargaProductos(Compañia, 999, 999, "", 1)
    End Sub

    Private Sub txtDESCRIPCION_PRODUCTO_B_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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
            AutoOrdenamiento.Checked = True
            Me.TXT_CODIGO.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(0).Value
            Me.TXT_DESCRIPCION.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(1).Value
            Me.txtPrecio.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(3).Value

            Me.hab_busqueda.Checked = Me.dgvProductosBodega.CurrentRow.Cells.Item(7).Value
            Me.chq_Tipo_precio.Checked = Me.dgvProductosBodega.CurrentRow.Cells.Item(8).Value

            'Me.lblExiste_Bodega.Visible = True
            bandera = True
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
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Button1.PerformClick()
        End If
    End Sub
    Private Sub TXT_CODIGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_CODIGO.TextChanged
        If AutoOrdenamiento.Checked = True Then
        Else
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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Refrescar()
    End Sub

    Private Sub dgvProductosBodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvProductosBodega.Click
        Try
            AutoOrdenamiento.Checked = True
            Me.TXT_CODIGO.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(0).Value
            Me.TXT_DESCRIPCION.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(1).Value
            Me.txtPrecio.Text = Me.dgvProductosBodega.CurrentRow.Cells.Item(3).Value

            Me.hab_busqueda.Checked = Me.dgvProductosBodega.CurrentRow.Cells.Item(7).Value
            Me.chq_Tipo_precio.Checked = Me.dgvProductosBodega.CurrentRow.Cells.Item(8).Value

            bandera = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TXT_CODIGO.Text = ""
        TXT_DESCRIPCION.Text = ""
        txtPrecio.Text = ""

        hab_busqueda.Checked = False
    End Sub

    Private Sub cmbSUBGRUPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSUBGRUPO.SelectedIndexChanged
        'If Actualizar = True Then
        'Else
        '    If Iniciando = False Then
        '        lblPRODUCTO.Text = c_data2.leerDataeader("EXECUTE sp_INVENTARIO_GENERAR_CODIGO @COMPAÑIA=" & Compañia & ",@GRUPO=" & cmbGRUPO.SelectedValue & ",@SUBGRUPO=" & cmbSUBGRUPO.SelectedValue, 0).ToString.PadLeft(4, "0")
        '        CargaProductos(Compañia, cmbGRUPO.SelectedValue, cmbSUBGRUPO.SelectedValue, "", 1)
        '    End If
        'End If

        If Actualizar = True Then

        Else
            If Iniciando = False Then
                lblPRODUCTO.Text = c_data2.leerDataeader("EXECUTE sp_INVENTARIO_GENERAR_CODIGO @COMPAÑIA=" & Compañia & ",@GRUPO=" & cmbGRUPO.SelectedValue & ",@SUBGRUPO=" & cmbSUBGRUPO.SelectedValue, 0).ToString.PadLeft(4, "0")
                CargaProductos(Compañia, cmbGRUPO.SelectedValue, cmbSUBGRUPO.SelectedValue, "", 1)
            End If
        End If
    End Sub

    Private Sub lblPRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPRODUCTO.TextChanged
        If Actualizar = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 0 '1  
            Dim Ncolumn As String = dgvProductos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProductos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table3.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If lblPRODUCTO.Text = "" Then
                Me.dgvProductos.DataSource = Table3
            Else
                rows = Table3.Select("[" & dgvProductos.Columns(columna).Name & "] like '" & lblPRODUCTO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvProductos.DataSource = tablaT
            End If
        End If

    End Sub

    Private Sub txtDESCRIPCION_PRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_PRODUCTO.TextChanged
        If Actualizar = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 1 '1  
            Dim Ncolumn As String = dgvProductos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case dgvProductos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = Table3.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If txtDESCRIPCION_PRODUCTO.Text = "" Then
                Me.dgvProductos.DataSource = Table3
            Else
                rows = Table3.Select("[" & dgvProductos.Columns(columna).Name & "] like '" & txtDESCRIPCION_PRODUCTO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                ' return filtered dt            
                Me.dgvProductos.DataSource = tablaT
            End If

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargarGrupos()
            CargaUM(Compañia, 4, cmbUNIDAD_MEDIDA)
        End If
    End Sub

    Private Sub btnPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermisos.Click
        Dim frmPermisos_ As New Seguridad_Solicitud_Permiso(1)
        frmPermisos_.ShowDialog()

        If continuar_ Then
            txtPrecio.Enabled = True
            txtPrecio.BackColor = Color.White
        End If
    End Sub
End Class