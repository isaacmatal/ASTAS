Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Catalogo_programacion_Semanal
    Dim fill As New cmbFill
    Dim jasr_fill As New jarsClass
    Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
    Dim Frm_Bodegas As New Cafeteria_Busqueda_Recetas_por_Bodega
    Dim Sql As String

    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader

    Dim Iniciando As Boolean


    Private Sub Cafeteria_Catalogo_programacion_Semanal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 10)
        CargarTiempoComida(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTiempo, "S")

        CargarTiempoComida(Me.cmbCOMPAÑIA.SelectedValue, Me.ComboBox1, "S")
        CargarGrid(0, "", 0)
        Iniciando = False
    End Sub

    Sub CargarGrid(ByVal PROD_COD, ByVal PROD_DESC, ByVal BANDERA)
        Try
            DS02.Reset()
            Sql = "EXECUTE sp_VISTA_INVENTARIOS_BODEGAS_Y_PRODUCTOS_POR_USUARIO_S "
            Sql &= "@COMPAÑIA = " & Val(Compañia)
            Sql &= ",@BODEGA = " & Val(cmbBODEGA.SelectedValue)
            Sql &= ",@PRODUCTO = " & Val(0)
            Sql &= ",@PRODUCTO_DESCRIPCION = ''"
            Sql &= ",@USUARIO = N'" & Usuario & "'"
            Sql &= ",@SIUD = " & BANDERA
            jasr_fill.MiddleConnection(Sql)
            jasr_fill.DataAdapter.Fill(DS02)
            Me.Catalogo.DataSource = DS02.Tables(0)
            'Ajusntar el tamaño de las columnas del grid de forma automatica
            For i As Integer = 0 To Me.Catalogo.ColumnCount - 1
                Me.Catalogo.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception

        End Try
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region
    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo1 As ComboBox, ByVal IUD As Char)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            jasr_fill.CargarCombo(cmbTiempo1, Sql, "Tiempo de Comida", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub CargarRecetas(ByVal Compañia As Integer, ByVal Bodega As Integer)
        Try
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "Execute sp_CAFETERIA_CATALOGO_RECETA_BODEGA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '0'"
            Sql &= ", '1'"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            DataAdapter_.Fill(Table)
            'Me.txtProducto.Text = Table.Columns.Contains("Código")
            'Me.txtDESCRIPCION1.Text = Table.Columns.Contains("Descripción")
            'Me.txtMedida.Text = Table.Columns.Contains("Medida")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub MantenimientoProgramacion(ByVal Compañia As String, ByVal Bodega As String, ByVal Fecha As String, ByVal Tiempo As String, ByVal Codigo As String, ByVal Cantidad As String, ByVal IUD As String)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Codigo
            Sql &= ", " & Cantidad
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"

            DS01.Reset()
            OpenConnection()
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If IUD = "S" Then
                Me.DgvProductos.DataSource = DS01.Tables(0)
                'Me.DgvProductos.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                'For i As Integer = 1 To Me.DgvProductos.ColumnCount
                '    Me.DgvProductos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                'Next
            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub Vercomparativos(ByVal Compañia As String, ByVal Bodega As String, ByVal Fecha As String, ByVal Tiempo As String, ByVal Codigo As String, ByVal Cantidad As String, ByVal IUD As String)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Codigo
            Sql &= ", " & Cantidad
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"

            DS03.Reset()
            OpenConnection()
            MiddleConnection()
            DataAdapter.Fill(DS03)
            If IUD = "S1" Then
                Me.DataGridView2.DataSource = DS03.Tables(0)
                'Me.DgvProductos.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
               
            End If

            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub CargarRecetaIndividual(ByVal Compañia As Integer, ByVal Bodega As Integer, ByVal Receta As Integer, ByVal IUD As Integer)
        Try
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "Execute sp_CAFETERIA_CATALOGO_RECETA_BODEGA "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", '" & Usuario & "'"
            Sql &= ", " & Receta
            Sql &= ", " & IUD
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            DataAdapter_.Fill(Table)
            Me.txtProducto.Text = Table.Columns.Contains("Código")
            Me.txtDESCRIPCION1.Text = Table.Columns.Contains("Descripción")
            Me.txtMedida.Text = Table.Columns.Contains("Medida")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub ObtenerDatosMenu()
        Me.txtProducto.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
        Me.txtMedida.Text = unidades
    End Sub

    Private Sub btnNuevoCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCB.Click
        btnProcesarPartida.Enabled = True
        Limpiar_Campos1()
    End Sub
    Private Sub Limpiar_Campos1()
        Me.txtProducto.Text = 0
        Me.txtDESCRIPCION1.Text = ""
        Me.txtCantidad.Text = 0
        Me.txtMedida.Text = ""
    End Sub
    Public Function VerificarExistencias(ByVal BodegaE, ByVal TiempoE, ByVal FechaE, ByVal CodigoE) As Integer
        DS03.Reset()
        OpenConnection()
        Sql = "Execute sp_CAFETERIA_VERIFICAR_EXISTENCIAS_RECETA "
        Sql &= "@COMPAÑIA=" & Compañia
        Sql &= ", @BODEGA=" & BodegaE
        Sql &= ", @CODIGO=" & CodigoE
        Sql &= ", @TIEMPO=" & TiempoE
        Sql &= ", @FECHA='" & FechaE & "'"
        MiddleConnection()
        DataAdapter.Fill(DS03)
        DataGridView1.DataSource = DS03.Tables(0)
        Dim contador As Integer = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If Val(DataGridView1.Rows(i).Cells(9).Value.ToString()) = 0 Then
                contador = contador + 1
            End If
        Next

        Return contador
    End Function

    Private Sub btnGuardarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCB.Click
        If MsgBox("¿Está seguro que desea Agregar/Modificar detalle de Programación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If (Val(Me.txtCantidad.Text) <> 0) And (Val(Me.txtProducto.Text) <> 0) Then
                Dim Ultima_Fecha As Date = _
                    jasr_fill.obtenerEscalar("SELECT ISNULL(MAX(FECHA),'01-01-2000') FROM  CAFETERIA_PROGRAMACION_SEMANAL WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue & " AND CODIGO_PRODUCTO=" & Me.txtProducto.Text & " AND FECHA_PROCESO IS NOT NULL")
                Dim Dias As Integer = DateDiff(DateInterval.Day, Ultima_Fecha, Me.txtFecha.Value)
                If Dias <= 15 Then
                    If MsgBox("Receta ha sido elaborada hace " & Dias.ToString & " días." & Chr(13) & _
                              "Desea producirla siempre?", MsgBoxStyle.YesNo, "AVISO") = MsgBoxResult.Yes Then
                        MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, Me.txtProducto.Text, Me.txtCantidad.Text, "I")
                        MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
                    End If
                Else
                    MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, Me.txtProducto.Text, Me.txtCantidad.Text, "I")
                    MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
                End If
            Else
                MsgBox("Falta especificar código de producto o cantidad por adicionar.", MsgBoxStyle.OkOnly, "Mensaje")
            End If
        End If
        Limpiar_Campos1()
    End Sub
    Private Sub cmbTiempo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiempo.SelectedIndexChanged
        If Iniciando = False Then
            MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
            'CargarRecetas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)

            BtnBuscar.PerformClick()

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            'CargarRecetas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
            MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
        End If
    End Sub

    Private Sub btnEliminarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCB.Click
        If MsgBox("¿Está seguro que desea Eliminar detalle de Programación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            If (Val(Me.txtCantidad.Text) <> 0) And (Val(Me.txtProducto.Text) <> 0) Then
                MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, Me.txtProducto.Text, Me.txtCantidad.Text, "D")
                MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "S")
                Limpiar_Campos1()
            Else
                MsgBox("Falta especificar código de producto o cantidad por adicionar.", MsgBoxStyle.OkOnly, "Mensaje")
            End If
        End If
    End Sub
    Private Sub BtnBuscarCodigo1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCodigo1.Click
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Me.cmbCOMPAÑIA.Text
        Frm_Busqueda.TxtCompañia_cod.Text = Me.cmbCOMPAÑIA.SelectedValue
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()

        ObtenerDatosMenu()

    End Sub

    Private Sub txtProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProducto.TextChanged
        'If Me.txtProducto.Text <> Nothing Then
        '    CargarRecetaIndividual(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtProducto.Text, 2) ' El 2 para obtener el item digitado.
        'End If
    End Sub

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        btnProcesarPartida.Enabled = False
        Dim i As Integer
        For i = 0 To Me.DgvProductos.RowCount - 1
            If DgvProductos.Rows(i).Cells(4).Value.ToString() = "Si" Then
                MsgBox("El producto: " & DgvProductos.Rows(i).Cells(0).Value.ToString() & ", ya esta procesado, cambio no efectuado.", MsgBoxStyle.Information)
            Else
                jasr_fill.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & Me.DgvProductos.Rows(i).Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=1, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
            End If
        Next
        MsgBox("Se proceso con exito todos los productos, excepto los que ya estab procesados", MsgBoxStyle.Information)
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Try
                Me.txtDESCRIPCION1.Text = jasr_fill.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto.Text & ", @BANDERA=1", 1)
                Me.txtMedida.Text = jasr_fill.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto.Text & ", @BANDERA=1", 2)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            btnGuardarCB.Focus()
        End If

        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13)))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtCantidad.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtCantidad.Text = ""
                Else
                    e.Handled = txtCantidad.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtCantidad.Text = ""
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 1
            Dim Ncolumn As String = Catalogo.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case Catalogo.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = DS02.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TextBox5.Text = "" Then
                Me.Catalogo.DataSource = DS02.Tables(0)
            Else
                rows = DS02.Tables(0).Select("[" & Catalogo.Columns(columna).Name & "] like '" & TextBox5.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                Me.Catalogo.DataSource = tablaT
            End If
        End If
    End Sub

    Private Sub Catalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Catalogo.Click
        'If Catalogo.SelectedRows.Count > 0 Then
        '    Dim indice_ As Integer = Catalogo.CurrentRow.Index - 1
        '    Dim seleccionado_ As Boolean = Catalogo.SelectedRows.Item(indice_).Selected()
        '    Me.AgregarSeleccionados(Catalogo.CurrentRow.Cells(0).Value.ToString(), seleccionado_)
        'End If

        Me.txtProducto.Text = Catalogo.CurrentRow.Cells(0).Value.ToString()
        Me.txtDESCRIPCION1.Text = Catalogo.CurrentRow.Cells(1).Value.ToString()
        Me.txtMedida.Text = Catalogo.CurrentRow.Cells(2).Value.ToString()
        txtCantidad.Focus()
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        If Iniciando = False Then
            BtnBuscar.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If DgvProductos.CurrentRow.Cells(4).Value.ToString() = "Si" Then
            MsgBox("NO se ha procesado el producto seleccionado, ya esta procesado", MsgBoxStyle.Information)
        Else
            jasr_fill.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & Me.DgvProductos.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=1, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
            MsgBox("Se proceso con exito el producto seleccionado", MsgBoxStyle.Information)
        End If


    End Sub

  

    Private Sub DgvProductos_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProductos.CellContentClick
        Me.txtProducto.Text = Me.DgvProductos.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION1.Text = Me.DgvProductos.CurrentRow.Cells.Item(1).Value
        Me.txtCantidad.Text = Me.DgvProductos.CurrentRow.Cells.Item(2).Value
        Me.txtMedida.Text = Me.DgvProductos.CurrentRow.Cells.Item(3).Value

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Iniciando = False Then
            'CargarRecetas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
            Vercomparativos(Me.cmbCOMPAÑIA.SelectedValue.ToString(), Me.cmbBODEGA.SelectedValue.ToString(), Format(Me.DateTimePicker1.Value, "dd-MM-yyyy 00:00:01"), Me.ComboBox1.SelectedValue.ToString(), "0", "0", "S1")
        End If
    End Sub

 
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Iniciando = False Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Iniciando = False Then
            Vercomparativos(Me.cmbCOMPAÑIA.SelectedValue.ToString(), Me.cmbBODEGA.SelectedValue.ToString(), Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.ComboBox1.SelectedValue.ToString(), "0", "0", "S")
            Button3.PerformClick()

        End If
    End Sub
    
#Region "Repintar el Calendario"
    'Protected Shared WM_PAINT As Integer = &HF
    'Private _warningDates As New List(Of String)

    'Public Property WarningDates() As List(Of String)
    '    Get
    '        Return _warningDates
    '    End Get
    '    Set(ByVal value As List(Of String))
    '        _warningDates = value
    '    End Set
    'End Property

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    MyBase.WndProc(m)
    '    If m.Msg = WM_PAINT Then
    '        Dim graphics__l As Graphics = Graphics.FromHwnd(Me.Handle)
    '        Dim pe As New PaintEventArgs(graphics__l, New Rectangle(0, 0, Me.Width, Me.Height))
    '        OnPaint(pe)
    '    End If
    'End Sub

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

    '    MyBase.OnPaint(e)
    '    Dim graphics As Graphics = e.Graphics
    '    Dim dayBoxWidth As Integer = 0
    '    Dim dayBoxHeight As Integer = 0
    '    Dim firstWeekPosition As Integer = 0
    '    Dim lastWeekPosition As Integer = Height
    '    Dim visibleWarningDates As New List(Of DateTime)
    'End Sub

#End Region

    'Private Sub Catalogo_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Catalogo.CellMouseUp
    '    If e.Button = MouseButtons.Right Then
    '        ContextMenuStrip1.Show(Cursor.Position)
    '    End If
    'End Sub

    'Private Sub AgregarMenuARangoDeFechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm_Calendario As New Cafeteria_ProgramarPorFechas
    '    frm_Calendario.txtCodigo.Text = Catalogo.CurrentRow.Cells(0).Value.ToString()
    '    frm_Calendario.txtMenu.Text = Catalogo.CurrentRow.Cells(1).Value.ToString()
    '    frm_Calendario.txtMedida.Text = Catalogo.CurrentRow.Cells(2).Value.ToString()
    '    frm_Calendario.ShowDialog()
    'End Sub

    Private Sub btnMenusVariosDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenusVariosDias.Click
        Dim frm_Calendario As New Cafeteria_ProgramarPorFechas
        frm_Calendario.ShowDialog()
    End Sub
End Class