Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Catalogo_Menu
    Dim fill As New cmbFill
    Dim jasr_fill As New jarsClass
    Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega

    Dim Sql As String, BAN As Boolean

    Dim Iniciando As Boolean
    Dim IVA As String


    Private Sub Cafeteria_Catalogo_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)        
        jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA, 10)
        jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)
        IVA = jasr_fill.leerDataeader("Execute sp_OBTENER_PARAMETROS 2, 'IVA'", 0)
        IVA = Math.Round(Convert.ToDouble(IVA), 2)
        Label13.Text = IVA + "%"
        Iniciando = False                
    End Sub
    Sub CargarGrid(ByVal CIA, ByVal PROD_COD, ByVal PROD_DESC, ByVal BANDERA)
        Try
            DS03.Reset()
            Sql = "EXECUTE sp_VISTA_INVENTARIOS_BODEGAS_Y_PRODUCTOS_POR_USUARIO_S "
            Sql &= "@COMPAÑIA = " & Val(Compañia)
            Sql &= ",@BODEGA = " & Val(cmbBODEGA.SelectedValue)
            Sql &= ",@PRODUCTO = " & Val(0)
            Sql &= ",@PRODUCTO_DESCRIPCION = '" & Me.txtDESCRIPCION1.Text & "'"
            Sql &= ",@USUARIO = N'" & Usuario & "'"
            Sql &= ",@SIUD = " & BANDERA
            jasr_fill.MiddleConnection(Sql)
            jasr_fill.DataAdapter.Fill(DS03)
            'Me.Grid_Recetas.DataSource = DS03.Tables(0)
            'Ajusntar el tamaño de las columnas del grid de forma automatica
            'For i As Integer = 0 To Me.Grid_Recetas.ColumnCount - 1
            '    Me.Grid_Recetas.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'Next
        Catch ex As Exception

        End Try
    End Sub
    Sub CargarGrid2(ByVal CIA, ByVal PROD_COD, ByVal PROD_DESC, ByVal BANDERA)
        Try
            DS02.Reset()
            Sql = "EXECUTE sp_VISTA_INVENTARIOS_BODEGAS_Y_PRODUCTOS_POR_USUARIO_S "
            Sql &= "@COMPAÑIA = " & Val(Compañia)
            Sql &= ",@BODEGA = " & Val(cmbBODEGA2.SelectedValue)
            Sql &= ",@PRODUCTO = " & Val(0)
            Sql &= ",@PRODUCTO_DESCRIPCION = '" & Me.TxtDESCRIPCION2.Text & "'"
            Sql &= ",@USUARIO = N'" & Usuario & "'"
            Sql &= ",@SIUD = " & BANDERA
            jasr_fill.MiddleConnection(Sql)
            jasr_fill.DataAdapter.Fill(DS02)
            'Me.Grid_Ingredientes.DataSource = DS02.Tables(0)
            'Ajusntar el tamaño de las columnas del grid de forma automatica
            'For i As Integer = 0 To Me.Grid_Ingredientes.ColumnCount - 1
            '    Me.Grid_Ingredientes.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'Next
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
    Sub MantenimientoMenues(ByVal BodegaProducto, ByVal CodigoProducto, ByVal BodegaReceta, ByVal CodigoReceta, ByVal Cantidad, ByVal Estado, ByVal IUD)
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CAFETERIA_CATALOGO_MENU_IUD "
            Sql &= "@COMPAÑIA=" & Compañia
            Sql &= ",@BODEGA_PRODUCTO= " & BodegaProducto
            Sql &= ",@CODIGO_PRODUCTO= " & CodigoProducto
            Sql &= ",@BODEGA_RECETA=" & BodegaReceta
            Sql &= ",@CODIGO_RECETA=" & CodigoReceta
            Sql &= ",@CANTIDAD=" & Cantidad
            Sql &= ",@ESTADO=" & Estado
            Sql &= ",@USUARIO='" & Usuario & "'"
            Sql &= ",@FECHA='" & Format(dtpFechaTrabajo.Value, "dd/MM/yyyy hh:mm:ss") & "'"
            Sql &= ",@IUD='" & IUD & "'"
            MiddleConnection()
            DataAdapter.Fill(DS01)

            If IUD = "S" Then
                Me.DgvProductos.DataSource = DS01.Tables(0)
                Me.DgvProductos.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                For i As Integer = 1 To 6
                    Me.DgvProductos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next

            End If
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub BtnBuscarCodigo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCodigo1.Click
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()


        MantenimientoMenues(Me.cmbBODEGA.SelectedValue, CodigoProducto, 0, 0, 0, 0, "S")

        txtTotalPagar.Text = "0.0"

        Me.txtCODIGO_PRODUCTO.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
        Me.TextMedida1.Text = ""
        Iniciando = True
        jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)

        calcular()

        Iniciando = False

    End Sub
    Public Sub calcular()
        'DETERMINA EL MARGEN OPERATIVO
        Dim MARGEN_O As String
        
        MARGEN_O = jasr_fill.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@PRODUCTO=" & txtCODIGO_PRODUCTO.Text & ",@FECHA='" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S2'", 0)
        MARGEN_O = Math.Round(Convert.ToDouble(MARGEN_O), 2)
        'DETERMINA LA SUMA DE LOS COSTOS TOTALES DE LOS INGREDIENTES
        txtTotalPagar.Text = "0"
        For i As Integer = 0 To DgvProductos.RowCount - 1

            txtTotalPagar.Text = (Val(txtTotalPagar.Text) + Val(DgvProductos.Rows(i).Cells(5).Value.ToString())).ToString()

        Next
        txtTotalPagar.Text = Math.Round(Convert.ToDouble(txtTotalPagar.Text), 6)
        'MONTO DE MARGEN
        Label12.Text = MARGEN_O + "%"
        'monto operativo
        TextBox1.Text = (Convert.ToDouble(MARGEN_O) / 100) * Convert.ToDouble(txtTotalPagar.Text)
        TextBox1.Text = Math.Round(Convert.ToDouble(TextBox1.Text), 6)

        'IVA
        Dim dblResultado As Double
        Dim dblCostoNeto As Double
        Dim dblTotalPagar As Double

        dblCostoNeto = Convert.ToDouble(TextBox1.Text)
        dblTotalPagar = Convert.ToDouble(txtTotalPagar.Text)
        dblResultado = dblCostoNeto + dblTotalPagar


        dblResultado = dblResultado * (IVA / 100)
        TextBox2.Text = Math.Round(Convert.ToDouble(dblResultado), 2)

        'DETERMINA EL PRECIO ESTANDAR SI
        Dim PRECIO As String
        PRECIO = jasr_fill.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@PRODUCTO=" & txtCODIGO_PRODUCTO.Text & ",@FECHA='" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "'", 0)
        txtDescuentos.Text = Math.Round(Convert.ToDouble(PRECIO), 2)

        Dim PRECIO_O As String
        PRECIO_O = jasr_fill.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@PRODUCTO=" & txtCODIGO_PRODUCTO.Text & ",@FECHA='" & Format(Me.dtpFechaTrabajo.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA='S4'", 0)
        TextBox3.Text = Math.Round(Convert.ToDouble(PRECIO_O), 2)
    End Sub
    Private Sub BtnBuscarCodigo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCodigo2.Click
        Limpiar_Campos2()
        CodigoProducto = 0
        Descripcion_Producto = ""
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA2.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA2.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()

        Me.TxtCODIGO_MENU.Text = CodigoProducto
        Me.TxtDESCRIPCION2.Text = Descripcion_Producto
        Me.TextMedida2.Text = ""
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtCODIGO_PRODUCTO.Text = "" Then
            MsgBox("Aviso...DEBE SELECCIONAR EL PRODUCTO DESDE EL BOTON BUSCAR", MsgBoxStyle.Information)
            BtnBuscarCodigo1.Focus()
        Else
            DS01.Reset()
            Limpiar_Campos1()
            Limpiar_Campos2()
        End If
    End Sub
    Private Sub Button2_Click_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Limpiar_Campos2()
    End Sub
    Private Sub Limpiar_Campos1()
        Me.cmbBODEGA.SelectedIndex = 0
        Me.cmbBODEGA2.SelectedIndex = 0
        Me.txtCODIGO_PRODUCTO.Text = 0
        Me.txtDESCRIPCION1.Text = ""
        Me.TextMedida1.Text = ""
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.txtDescuentos.Text = ""
        Me.txtTotalPagar.Text = ""
        Label12.Text = "0.00%"
    End Sub
    Private Sub Limpiar_Campos2()
        Me.TxtCODIGO_MENU.Text = 0
        Me.TxtDESCRIPCION2.Text = ""
        Me.TextMedida2.Text = ""
        Me.txtCantidad.Text = 0
        Me.chkESTADO.CheckState = 0
    End Sub
    Private Sub Btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar.Click
        If (Val(Me.TxtCODIGO_MENU.Text) <> 0) And (Val(Me.txtCODIGO_PRODUCTO.Text) <> 0) And (Me.cmbBODEGA.SelectedValue <> Nothing) And (Me.cmbBODEGA2.SelectedValue <> Nothing) Then
            If Val(Me.txtCantidad.Text) <> 0 Then
                If MsgBox("¿Está seguro que desea agregar/Modificar detalle de receta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    If chkESTADO.Checked = True Then
                        If MsgBox("¿Esta seguro de dejar fuera de uso el producto: " & TxtDESCRIPCION2.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                            MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, Me.TxtCODIGO_MENU.Text, Me.txtCantidad.Text, Me.chkESTADO.CheckState, "I")
                            MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, Me.TxtCODIGO_MENU.Text, 0, 0, "S")
                            calcular()

                        End If
                    Else

                        MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, Me.TxtCODIGO_MENU.Text, Me.txtCantidad.Text, Me.chkESTADO.CheckState, "I")
                        MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, Me.TxtCODIGO_MENU.Text, 0, 0, "S")
                        calcular()
                    End If
                End If
            Else
                MsgBox("Falta especificar Cantidad de producto a ingresar.", MsgBoxStyle.OkOnly, "Mensaje")
            End If
        Else
            MsgBox("Falta especificar un código de producto o bodega por adicionar al Menú.", MsgBoxStyle.OkOnly, "Mensaje")
        End If
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If MsgBox("¿Desea eliminar detalle de receta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, Me.TxtCODIGO_MENU.Text, 0, 0, "D")
            MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, Me.cmbBODEGA2.SelectedValue, 0, 0, 0, "S")
        End If
    End Sub
    Private Sub DgvProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvProductos.Click
        Try
            cmbBODEGA2.SelectedValue = DgvProductos.CurrentRow.Cells.Item(7).Value
            TxtCODIGO_MENU.Text = DgvProductos.CurrentRow.Cells.Item(0).Value

            TxtDESCRIPCION2.Text = DgvProductos.CurrentRow.Cells.Item(1).Value
            TextMedida2.Text = DgvProductos.CurrentRow.Cells.Item(2).Value
            txtCantidad.Text = DgvProductos.CurrentRow.Cells.Item(3).Value

            If DgvProductos.CurrentRow.Cells.Item(4).Value = 0 Then
                chkESTADO.Checked = False
            Else
                Me.chkESTADO.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbBODEGA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA2.SelectedIndexChanged
        TxtCODIGO_MENU.Text = ""
        TxtDESCRIPCION2.Text = ""
        txtCantidad.Text = ""
        CargarGrid2(Val(Compañia), 0, "", 0)
    End Sub


    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
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

    Private Sub txtCODIGO_PRODUCTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCODIGO_PRODUCTO.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            Me.txtDESCRIPCION1.Text = jasr_fill.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtCODIGO_PRODUCTO.Text & ", @BANDERA=1", 1)
            Try
                MantenimientoMenues(Me.cmbBODEGA.SelectedValue, Me.txtCODIGO_PRODUCTO.Text, 0, 0, 0, 0, "S")

                txtTotalPagar.Text = "0.0"

                Me.txtCODIGO_PRODUCTO.Text = Me.txtCODIGO_PRODUCTO.Text
                Me.txtDESCRIPCION1.Text = Me.txtDESCRIPCION1.Text
                Me.TextMedida1.Text = ""
                Iniciando = True
                jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)

                calcular()

                Iniciando = False
            Catch ex As Exception

            End Try            
        End If
    End Sub

    Private Sub TxtCODIGO_MENU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCODIGO_MENU.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(13)) Then
            Me.TxtDESCRIPCION2.Text = jasr_fill.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA2.SelectedValue & ", @PRODUCTO=" & Me.TxtCODIGO_MENU.Text & ", @BANDERA=1", 1)
        End If
    End Sub

    Private Sub txtDESCRIPCION1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDESCRIPCION1.KeyPress

    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        CargarGrid(Val(Compañia), 0, "", 0)
    End Sub

    Private Sub txtDESCRIPCION1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION1.TextChanged
        'If Iniciando = False Then
        '    Dim rows As DataRow()
        '    Dim posicion As Integer = -1 '1  
        '    Dim columna As Integer = 1
        '    Dim Ncolumn As String = Grid_Recetas.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        '    Dim Strsort As String = ""

        '    Select Case Grid_Recetas.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
        '        Case SortOrder.Ascending 'En Caso de ser Ascendente
        '            Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
        '        Case SortOrder.Descending 'En Caso de ser Descendente
        '            Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        '    End Select

        '    'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        '    Dim tablaT As DataTable = DS03.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        '    If txtDESCRIPCION1.Text = "" Then
        '        Me.Grid_Recetas.DataSource = DS03.Tables(0)
        '    Else
        '        rows = DS03.Tables(0).Select("[" & Grid_Recetas.Columns(columna).Name & "] like '" & txtDESCRIPCION1.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
        '        For i As Integer = 0 To rows.Length - 1
        '            tablaT.ImportRow(rows(i))
        '        Next

        '        Me.Grid_Recetas.DataSource = tablaT
        '    End If
        'End If
    End Sub

    Private Sub TxtDESCRIPCION2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDESCRIPCION2.TextChanged
        'If Iniciando = False Then
        '    Dim rows As DataRow()
        '    Dim posicion As Integer = -1 '1  
        '    Dim columna As Integer = 1
        '    Dim Ncolumn As String = Grid_Ingredientes.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        '    Dim Strsort As String = ""

        '    Select Case Grid_Ingredientes.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
        '        Case SortOrder.Ascending 'En Caso de ser Ascendente
        '            Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
        '        Case SortOrder.Descending 'En Caso de ser Descendente
        '            Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        '    End Select

        '    'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        '    Dim tablaT As DataTable = DS02.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        '    If TxtDESCRIPCION2.Text = "" Then
        '        Me.Grid_Ingredientes.DataSource = DS02.Tables(0)
        '    Else
        '        rows = DS02.Tables(0).Select("[" & Grid_Ingredientes.Columns(columna).Name & "] like '" & TxtDESCRIPCION2.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
        '        For i As Integer = 0 To rows.Length - 1
        '            tablaT.ImportRow(rows(i))
        '        Next

        '        Me.Grid_Ingredientes.DataSource = tablaT
        '    End If
        'End If
    End Sub

    Private Sub Grid_Recetas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_Recetas.CellContentClick
        txtCODIGO_PRODUCTO.Text = Grid_Recetas.CurrentRow.Cells(0).Value.ToString()
        txtDESCRIPCION1.Text = Grid_Recetas.CurrentRow.Cells(1).Value.ToString()

        MantenimientoMenues(Me.cmbBODEGA.SelectedValue, txtCODIGO_PRODUCTO.Text, 0, 0, 0, 0, "S")
        txtTotalPagar.Text = "0.0"

        Me.TextMedida1.Text = ""
        Iniciando = True
        jasr_fill.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)

        'DETERMINA PRECIO, COSTO Y MARGEN OPERATIVO
        calcular()

        Iniciando = False
    End Sub

    Private Sub Grid_Ingredientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_Ingredientes.CellContentClick
        TxtCODIGO_MENU.Text = Grid_Ingredientes.CurrentRow.Cells(0).Value.ToString()
        TxtDESCRIPCION2.Text = Grid_Ingredientes.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtCODIGO_PRODUCTO.Text = "" Then
            MsgBox("Debe seleccionar un Menu!", MsgBoxStyle.Information, "Mensaje")
        Else
            If Button3.Text = "Ajustar Precio de Venta" Then
                txtDescuentos.ReadOnly = False
                txtDescuentos.BackColor = Color.White
                txtDescuentos.Focus()
                Button3.Text = "Recalcular Porcentaje Operativo"
            Else
                If MsgBox("¿Esta seguro que desea cambiar el precio de venta de: " & txtDESCRIPCION1.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    Dim margen_porcentaje As String
                    Dim sub_total As String
                    txtDescuentos.ReadOnly = True
                    txtDescuentos.BackColor = Color.Yellow

                    sub_total = (Me.txtDescuentos.Text / ((IVA + 100) / 100))
                    'NUEVO IVA
                    Me.TextBox2.Text = Me.txtDescuentos.Text - sub_total
                    'monto operativo
                    TextBox1.Text = sub_total - Me.txtTotalPagar.Text

                    margen_porcentaje = (TextBox1.Text / txtTotalPagar.Text) * 100
                    margen_porcentaje = Math.Round(Convert.ToDouble(margen_porcentaje), 2)
                    Label12.Text = margen_porcentaje + "%"
                    Button3.Text = "Ajustar Precio de Venta"
                    jasr_fill.Ejecutar_ConsultaSQL("execute sp_INVENTARIOS_CATALOGO_PRODUCTOS_IUD @COMPAÑIA=" & Compañia & ", @PRODUCTO=" & txtCODIGO_PRODUCTO.Text & ", @MARGEN=" & margen_porcentaje & ", @IUD='U2'")
                    'DETERMINA PRECIO, COSTO Y MARGEN OPERATIVO
                    calcular()
                    MsgBox("Margen del menu modificado con exito?", MsgBoxStyle.Exclamation, "Mensaje")
                End If

            End If
        End If

    End Sub

    
End Class