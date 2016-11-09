Public Class Cafeteria_Ajuste_Produccion
    Dim c_data2 As New jarsClass
    Dim c_data As New cmbFill
    Dim Iniciando As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim numeroSalida As String, Bodega_encabezado As String, cantidad_encabezado As String, cantidad_encabezado_p As String, sql As String
    Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
    'Lista generica del detalle de la receta
    Dim ListaDetalle As New List(Of Cafeteria_Detalle_Programacion_Semanal)
    'Lista generica de codigos de bodegas
    Dim ListaBodegas As New List(Of Integer)
    'VARIABLES DE BUSQUEDA USADAS PARA DISTINGIR EL REGISTRO DEL ENCABEZADO
    'PARA ACTUALIZAR LA CANTIDAD PRODUCIDA
    Dim CompañiaSeleccionada As Integer
    Dim BodegaSeleccionada As Integer
    Dim TiempoComida As Integer
    Dim FechaSeleccionada As String
    'FIN VARIABLES DE BUSQUEDA
    Dim indiceColumna As Integer
    Dim indiceFila As Integer
    Dim bandera1 As Boolean = False

    Private Sub Cafeteria_Ajuste_Produccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        'Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        'CARGA EL COMBODE LAS COMPAÑIAS
        c_data.CargaCompañia(Me.cmbCOMPAÑIA)
        c_data2.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 10)
        c_data2.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.ComboBox1, 7)
        c_data2.CargarCombo(Me.cmbTiempo, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Me.cmbCOMPAÑIA.SelectedValue.ToString() & ",'S'", "Tiempo de Comida", "Descripción")
        CargarEncabezado("Execute sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @FECHA1='" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "', @BANDERA=3")
        CodigoProd = 0
        Iniciando = False
    End Sub
    Public Sub CargarEncabezado(ByVal cadena)
        CargarGrid(cadena, DS01)
        Me.EncabezadosProgramacion.DataSource = DS01.Tables(0)
        c_data2.cerrarConexion()
        For i As Integer = 1 To Me.EncabezadosProgramacion.ColumnCount
            Me.EncabezadosProgramacion.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.EncabezadosProgramacion.Columns.Item(i - 1).ReadOnly = True
            'Me.EncabezadosProgramacion.Columns.Item(i - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            If i > 6 Then
                Me.EncabezadosProgramacion.Columns.Item(i - 1).Visible = False
            End If
        Next
        Me.EncabezadosProgramacion.Columns.Item(11).Visible = True
        Me.EncabezadosProgramacion.Columns.Item(12).Visible = True
        Me.EncabezadosProgramacion.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.EncabezadosProgramacion.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.EncabezadosProgramacion.Columns.Item(3).ReadOnly = False

        'ASIGNAR LAS VARIABLES DE BUSQUEDA USADAS PARA DISTINGIR EL REGISTRO DEL ENCABEZADO
        'PARA ACTUALIZAR LA CANTIDAD PRODUCIDA 
        CompañiaSeleccionada = Me.cmbCOMPAÑIA.SelectedValue
        BodegaSeleccionada = Me.cmbBODEGA.SelectedValue
        TiempoComida = Me.cmbTiempo.SelectedValue
        FechaSeleccionada = Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01")

    End Sub
    Public Sub CargarDetalle(ByVal cadena)
        CargarGrid(cadena, DS02)
        Me.DetalleProgramacion.DataSource = DS02.Tables(0)
        c_data2.cerrarConexion()

        For i As Integer = 1 To Me.DetalleProgramacion.ColumnCount
            Me.DetalleProgramacion.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Me.DetalleProgramacion.Columns("BODEGA_RECETA").Visible = False
        Me.DetalleProgramacion.Columns("DESCRIPCION_BODEGA").Visible = True
        Me.DetalleProgramacion.Columns("USUARIO_CREACION").Visible = False
        Me.DetalleProgramacion.Columns("USUARIO_CREACION_FECHA").Visible = False
        Me.DetalleProgramacion.Columns("USUARIO_MODIFICA").Visible = False
        Me.DetalleProgramacion.Columns("USUARIO_MODIFICA_FECHA").Visible = False
        Me.DetalleProgramacion.Columns("BODEGA_PRODUCTO").Visible = False

        Me.DetalleProgramacion.Columns("CODIGO_RECETA").HeaderText = "RECETA"
        Me.DetalleProgramacion.Columns("DESCRIPCION_PRODUCTO").HeaderText = "DESCRIPCION PRODUCTO"
        Me.DetalleProgramacion.Columns("CANTIDAD_CALCULADA").HeaderText = "CANTIDAD CALCULADA"
        Me.DetalleProgramacion.Columns("CANTIDAD_REQUERIDA").HeaderText = "CANTIDAD UTILIZADA"
        Me.DetalleProgramacion.Columns("COSTO").HeaderText = "COSTO"
        Me.DetalleProgramacion.Columns("TOTAL").HeaderText = "TOTAL"
        Me.DetalleProgramacion.Columns("UNIDAD_MEDIDA").HeaderText = "UNIDAD MEDIDA"

        Me.DetalleProgramacion.Columns("CODIGO_RECETA").ReadOnly = True
        Me.DetalleProgramacion.Columns("DESCRIPCION_PRODUCTO").ReadOnly = True
        Me.DetalleProgramacion.Columns("COSTO").ReadOnly = True
        Me.DetalleProgramacion.Columns("TOTAL").ReadOnly = True
        Me.DetalleProgramacion.Columns("UNIDAD_MEDIDA").ReadOnly = True
        Me.DetalleProgramacion.Columns("CANTIDAD_CALCULADA").ReadOnly = True

        Me.DetalleProgramacion.Columns("CANTIDAD_CALCULADA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DetalleProgramacion.Columns("CANTIDAD_REQUERIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DetalleProgramacion.Columns("COSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DetalleProgramacion.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
    Public Sub CargarGrid(ByVal cadena, ByVal ds)
        Try
            ds.Reset()
            c_data2.MiddleConnection(cadena)
            c_data2.DataAdapter.Fill(ds)
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar la grilla", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub buscar()
        Try
            DetalleProgramacion.DataSource = Nothing
            CargarEncabezado("Execute sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @FECHA1='" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "', @BANDERA=3")

            If (Me.EncabezadosProgramacion.Rows(0).Cells(10).Value = True) Then
                lblProcesado.Text = "RECETA PROCESADA"
                btnProcesarPartida.Enabled = False
            Else
                lblProcesado.Text = "NUEVO AJUSTE"
                btnProcesarPartida.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar los datos", MsgBoxStyle.Information)
        End Try
    End Sub
    
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        Dim CIERRE As Boolean

        CIERRE = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_VERIFICAR_APERTURA_CIERRE @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ", @FECHA='" & Format(txtFecha.Value, "yyyy-MM-dd") & "',@USUARIO_LOGEO='" & Usuario & "', @BANDERA=3", 0)

        If (CIERRE = False) Then
            Label7.Visible = True
            MsgBox("AVISO...DEBE CERRAR EL MES ANTERIO Y ABRIR EL MES PRINCIPAL!", MsgBoxStyle.Information)
        Else
            Label7.Visible = False
            buscar()
        End If

    End Sub
    Public Sub PROC()
        Try
            'DECLARACION DE VARIABLES
            Dim respuesta As MsgBoxResult
            Dim numero_salida_9 As Integer, numero_Salida_7 As Integer, numero_Salida_12 As Integer
            ', numero_Salida_6 As Integer
            respuesta = MsgBox("Desea producir este Receta?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                Dim CANTIDAD As String = 1
                'SI YA SE PRE-PROCESO 
                'SOLAMENTE PONE LAS BANDERAS EN ALTO
                '*********************************************************************************************************************
                If (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value = "Si") Then
                    c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=8, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
                    MsgBox("La Receta ha sido procesada, No se podra modificar", MsgBoxStyle.Information)
                    btnProcesarPartida.Enabled = False
                    Exit Sub
                End If
                '*********************************************************************************************************************
                Dim listaTicket As New List(Of String)
                Dim prod_sin_exist As Integer = 0

                'VERIFICA la cantidad
                '*********************************************************************************************************************
                Dim cantidad_1 As Integer = 0
                For i As Integer = 0 To Me.DetalleProgramacion.RowCount - 1
                    If DetalleProgramacion.Rows(i).Cells(6).Value = 0 Then
                        cantidad_1 = cantidad_1 + 1
                    End If
                Next

                If cantidad_1 = Me.DetalleProgramacion.RowCount Then
                    MsgBox("Al menos un ingrediente del menú debe llevar cantidad", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'VERIFICA SI HAY SUFICIENTES EXISTENCIAS DE INGREDIENTES
                '*********************************************************************************************************************
                For i As Integer = 0 To Me.DetalleProgramacion.RowCount - 1

                    CANTIDAD = c_data2.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.DetalleProgramacion.Rows(i).Cells(0).Value & "," & Me.DetalleProgramacion.Rows(i).Cells(2).Value & ",'" & Format(Me.txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

                    If (CANTIDAD < Me.DetalleProgramacion.Rows(i).Cells("CANTIDAD_REQUERIDA").Value) Then
                        listaTicket.Add(Me.DetalleProgramacion.Rows(i).Cells(3).Value.ToString())
                        prod_sin_exist = prod_sin_exist + 1
                    End If
                Next

                Dim mesage As New Productos_Sin_Existencias(listaTicket)
                mesage.ShowDialog()
                '*********************************************************************************************************************
                'SINO HAY SUFICIENTES SALE DE LO CONTRARIO PROCEDE
                '*********************************************************************************************************************
                If (prod_sin_exist > 0) Then
                    Exit Sub
                Else
                    'LIMPIAMOS LA LISTA GENERICA
                    ListaDetalle.Clear()
                    ListaBodegas.Clear()

                    'ACTUALIZA COSTOS
                    actualiza_costos_ingredientes()

                    'RECORREMOS EL DETALLE PARA AGRUPAR ITEMS POR BODEGAS
                    For i As Integer = 0 To Me.DetalleProgramacion.RowCount - 1
                        c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @BODEGA_RECETA=" & Me.DetalleProgramacion.Rows(i).Cells(0).Value.ToString() & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @CODIGO_RECETA=" & Me.DetalleProgramacion.Rows(i).Cells(2).Value.ToString() & ", @CANTIDAD_REQUERIDA=" & Me.DetalleProgramacion.Rows(i).Cells("CANTIDAD_REQUERIDA").Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=5")
                        ListaDetalle.Add(New Cafeteria_Detalle_Programacion_Semanal(Me.cmbCOMPAÑIA.SelectedValue, Me.DetalleProgramacion.Rows(i).Cells(0).Value, Me.DetalleProgramacion.Rows(i).Cells(2).Value, Me.DetalleProgramacion.Rows(i).Cells("CANTIDAD_REQUERIDA").Value, Me.DetalleProgramacion.Rows(i).Cells("CANTIDAD_CALCULADA").Value))

                        'GENERAMOS UNA LISTA DE BODEGAS AGRUPADAAS
                        If ListaBodegas.Count > 0 Then
                            'VERIFICAMOS SI NO EXISTE PARA EVITAR DUPLICIDAD
                            If Not ListaBodegas.Contains(Me.DetalleProgramacion.Rows(i).Cells(0).Value) Then
                                ListaBodegas.Add(Me.DetalleProgramacion.Rows(i).Cells(0).Value)
                            End If
                        Else
                            ListaBodegas.Add(Me.DetalleProgramacion.Rows(i).Cells(0).Value)
                        End If
                    Next

                    'REALIZAR LOS MOVIMIENTOS CORRESPONDIENTES POR CADA BODEGA
                    For i As Integer = 0 To Me.ListaBodegas.Count - 1
                        BodegaSeleccionada = ListaBodegas(i)
                        'EL NUMERO DE MOVIMIENTO SE CALCULA SEGUN EL AGRUPAMIENTO DE LAS BODEGAS DE LOS INGREDIENTES
                        numero_salida_9 = sugerirMovSalida(BodegaSeleccionada, 9)
                        numero_Salida_7 = sugerirMovSalida(BodegaSeleccionada, 7)

                        Dim filtrados As List(Of Cafeteria_Detalle_Programacion_Semanal) = ListaDetalle.FindAll(AddressOf FiltrarPorBodega)
                        If filtrados IsNot Nothing Then
                            For j As Integer = 0 To filtrados.Count - 1
                                'SI LA CANTIDAD UTILIZADA ES MAYOR QUE LA CANTIDAD REQUERIDA
                                If filtrados(j).Cantidad_P < filtrados(j).Cantidad Then
                                    'DETERMINA LA DIFERENCIA
                                    Dim VAR2 As Double = filtrados(j).Cantidad - filtrados(j).Cantidad_P

                                    'INGRESA EL NUMERO DE SALIDAS POR PRODUCCION LLAVE 9 DE TIPO_MOV
                                    cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, ListaBodegas(i), 9, numero_salida_9, filtrados(j).CodigoReceta, filtrados(j).Cantidad_P, 0)
                                    'INGRESA EL NUMERO DE SALIDAS POR AJUSTE
                                    cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, ListaBodegas(i), 7, numero_Salida_7, filtrados(j).CodigoReceta, VAR2, 0)

                                Else
                                    'INGRESA EL NUMERO DE SALIDAS POR PRODUCCION LLAVE 9 DE TIPO_MOV
                                    cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, ListaBodegas(i), 9, numero_salida_9, filtrados(j).CodigoReceta, filtrados(j).Cantidad, 0)
                                End If
                            Next
                        End If
                    Next

                    'ACTUALIZAR CAMPO EN EL ENCABEZADO
                    c_data2.Ejecutar_ConsultaSQL("EXEC sp_CAFETERIA_ACTUALIZAR_ENCABEZADO_PROGRAMACION @COMPAÑIA=" & CompañiaSeleccionada & ",@BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@FECHA='" & FechaSeleccionada & "',@TIEMPO_COMIDA=" & TiempoComida & ",@CODIGO_PRODUCTO=" & CodigoProd & ",@PRODUCIDO=" & ObtenerCantidadProducida())

                    numero_Salida_12 = sugerirMovSalida(cmbBODEGA.SelectedValue, 12)
                    If Val(cantidad_encabezado_p) < Val(cantidad_encabezado) Then
                        Dim VAR1 As Double
                        VAR1 = cantidad_encabezado - cantidad_encabezado_p
                        'INGRESA DE PRODUCTOS TERMINADOS DE COCINA

                        cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 12, numero_Salida_12, CodigoProd, cantidad_encabezado_p, 1)

                    Else
                        'INGRESA DE PRODUCTOS TERMINADOS
                        cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 12, numero_Salida_12, CodigoProd, cantidad_encabezado_p, 1)
                    End If

                    'ACTUALIZA PRECIO DE VENTA
                    c_data2.Ejecutar_ConsultaSQL("EXEC sp_CAFETERIA_PRECIOS_VENTA_IUD @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@CODIGO=" & CodigoProd & ",@TIEMPO=" & Me.cmbTiempo.SelectedValue & ",@FECHA=N'" & txtFecha.Value.ToString("dd/MM/yyyy 00:00:01") & "', @CANTIDAD=" & cantidad_encabezado_p & ",@IVA=13,@IUD='I',@USUARIO='" & Usuario & "'")

                    MsgBox("La Receta ha sido procesada, No se podra modificar", MsgBoxStyle.Information)
                    btnProcesarPartida.Enabled = False

                End If
            End If
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar los datos", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub PROC_INV()
        Try
            Dim respuesta As MsgBoxResult

            'Dim numero_entrada_9 As Integer, numero_entrada_7 As Integer, numero_entrada_12 As Integer, numero_entrada_6 As Integer
            respuesta = MsgBox("Desea Revertir el procesado de esta Receta?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                

            End If

        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar los datos", MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        bandera1 = False
        If Me.DetalleProgramacion.RowCount = 0 Then
            MsgBox("Aviso...El menu debe contener ingredientes!", MsgBoxStyle.Information)
        Else
            'And ValidarDetalle()
            If ValidarEncabezado() Then
                PROC()

                CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

                CargarEncabezado("Execute sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @FECHA1='" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "', @BANDERA=3")

            End If
        End If

    End Sub

    Private Function ValidarEncabezado() As Boolean
        If ObtenerCantidadProducida() > 0 Then
            Return True
        Else
            MsgBox("Favor ingrese una cantidad producida mayor de 0.", MsgBoxStyle.Critical)
            Return False
        End If
    End Function

    Private Function ValidarDetalle() As Boolean
        Dim cantidad_o As Integer = 0
        For i As Integer = 0 To DetalleProgramacion.RowCount - 1
            With Me.DetalleProgramacion.Rows(i)
                If .Cells("CANTIDAD_REQUERIDA").Value <= 0 Then
                    cantidad_o = cantidad_o + 1
                    If cantidad_o > 1 Then
                        MsgBox("Favor ingrese una cantidad utilizada mayor de 0," & vbNewLine & "para el producto: " & .Cells("DESCRIPCION_PRODUCTO").Value, MsgBoxStyle.Critical)
                        Return False
                    End If
                End If
            End With
        Next
        Return True
    End Function

    Private Function FiltrarPorBodega(ByVal c As Cafeteria_Detalle_Programacion_Semanal) As Boolean
        If c.Bodega = BodegaSeleccionada Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ObtenerCantidadProducida() As Double
        Dim rows As DataRow()
        Dim tbl As DataTable
        tbl = EncabezadosProgramacion.DataSource
        rows = tbl.Select("[" & EncabezadosProgramacion.Columns(0).Name & "] = " & CodigoProd)
        If rows.Length > 0 Then
            Return Val(rows(0).Item(3))
        Else
            Return 0.0
        End If
    End Function

    Public Function sugerirMovSalida(ByVal bodega, ByVal Tipo_Mov)
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & " AND BODEGA=" & bodega & " AND TIPO_MOVIMIENTO =" & Tipo_Mov
        numeroSalida = sugerirMov(consulta)
        Return numeroSalida
    End Function
    Public Function sugerirMov(ByVal consulta)
        Dim mov As String
        mov = c_data2.leerDataeader(consulta, 0)
        Return mov
    End Function
    Public Sub cadenaSIUD(ByVal CIA, ByVal BODEGA, ByVal TIPO, ByVal MOV, ByVal codigo, ByVal cantidad, ByVal Entrada_salida)
        Dim SQL As String, Costo_Uni_X As String, Costo_Total_X As String
        'BODEGAS DE COCINA PRODUCTO TERMINADO 1 Y 2
        If Val(BODEGA) = 19 Or Val(BODEGA) = 31 Then
            Costo_Uni_X = calcular_costo_produccion(codigo)
            txtTotalPagar.Text = calcular_costo_produccion(codigo)
        Else
            Costo_Uni_X = c_data2.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & CIA & "," & BODEGA & "," & codigo & ", '" & Me.txtFecha.Value.ToString("dd/MM/yyyy hh:mm:ss") & "')", 0)
        End If
        Costo_Total_X = (Val(Costo_Uni_X) * cantidad).ToString()
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & BODEGA
        SQL &= ",@PROVEEDOR = 1"
        SQL &= ",@TIPO_MOVIMIENTO=" & TIPO
        SQL &= ",@MOV = " & MOV
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@FECHA_MOVIMIENTO = N'" & Me.txtFecha.Value.ToString("dd/MM/yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & Val(codigo)
        SQL &= ",@CANTIDAD = " & Val(cantidad)
        SQL &= ",@COSTO_UNIDAD = " & Costo_Uni_X
        SQL &= ",@COSTO_TOTAL = " & Costo_Total_X
        SQL &= ",@ENTRADA_SALIDA =" & Entrada_salida
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'I'"
        c_data2.Ejecutar_ConsultaSQL(SQL)
    End Sub
    Private Sub EncabezadosProgramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncabezadosProgramacion.Click
        Try
            If (Me.EncabezadosProgramacion.CurrentRow.Cells(10).Value = True) And (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value.ToString() = "Si") Then
                lblProcesado.Text = "RECETA PRE-PROCESADA Y PROCESADA"
                btnProcesarPartida.Enabled = False
                Button2.Enabled = False
            ElseIf (Me.EncabezadosProgramacion.CurrentRow.Cells(10).Value = False) And (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value.ToString() = "Si") Then
                lblProcesado.Text = "RECETA PRE-PROCESADA"
                btnProcesarPartida.Enabled = True
                Button2.Enabled = False
            ElseIf (Me.EncabezadosProgramacion.CurrentRow.Cells(10).Value = True) And (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value.ToString() = "Si") Then
                lblProcesado.Text = "RECETA PROCESADA"
                btnProcesarPartida.Enabled = False
                Button2.Enabled = False
            Else
                lblProcesado.Text = "NUEVO AJUSTE"
                btnProcesarPartida.Enabled = True
                Button2.Enabled = True
            End If

            CodigoProd = Me.EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString()
            cantidad_encabezado = Me.EncabezadosProgramacion.CurrentRow.Cells(2).Value.ToString()
            cantidad_encabezado_p = Me.EncabezadosProgramacion.CurrentRow.Cells(3).Value.ToString()

            'ACTUALIZA CANTIDADES PROGRAMADAS, EXISTENCIAS Y COSTOS
            'Button1.PerformClick()

            CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

            Dim inactivos As String = "0"
            inactivos = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=13, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'", 0)
            If inactivos > 0 Then
                Label8.Visible = True
            Else
                Label8.Visible = False
            End If

            Dim precio As String = "0"            

            'DETERMINA EL MARGEN OPERATIVO
            '****************************************************
            Dim MARGEN_O As String
            MARGEN_O = c_data2.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ",@FECHA='" & Format(Me.txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S2'", 0)
            TextBox1.Text = MARGEN_O
            '****************************************************

            'DETERMINA EL COSTO
            '****************************************************
            txtTotalPagar.Text = calcular_costo_produccion(EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString())
            '****************************************************

            'PRECIO MODIFICADO
            '****************************************************
            Dim PRECIO_O As String
            PRECIO_O = c_data2.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ",@FECHA='" & Format(Me.txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S4'", 0)
            TextBox2.Text = PRECIO_O
            '***************************************************

            'PRECIO SUJERIDO POR EL SISTEMA
            '****************************************************
            precio = ((txtTotalPagar.Text) + (txtTotalPagar.Text) * (MARGEN_O / 100)) + (((txtTotalPagar.Text) + (txtTotalPagar.Text) * (MARGEN_O / 100)) * 0.13)
            txtDescuentos.Text = precio
            '****************************************************

        Catch ex As Exception

        End Try
    End Sub
    Function calcular_costo_produccion(ByVal codigo_prod As String)
        Dim costo As String = "0"
        'DETERMINA LA SUMATORIA DE LOS COSTOS UNITARIOS
        sql = " Select SUM(D.TOTAL) / E.CANTIDAD "
        sql &= " FROM CAFETERIA_PROGRAMACION_SEMANAL_DETALLE D "
        sql &= " INNER JOIN CAFETERIA_PROGRAMACION_SEMANAL E "
        sql &= " ON E.COMPAÑIA=D.COMPAÑIA AND E.BODEGA=D.BODEGA_PRODUCTO AND E.CODIGO_PRODUCTO=D.CODIGO_PRODUCTO AND E.FECHA=D.FECHA AND E.TIEMPO_COMIDA=D.TIEMPO_COMIDA "
        sql &= " WHERE D.COMPAÑIA=" & Compañia & " AND D.BODEGA_PRODUCTO=" & cmbBODEGA.SelectedValue & " AND D.CODIGO_PRODUCTO=" & codigo_prod & " AND D.FECHA='" & Me.txtFecha.Value.ToString("dd/MM/yyyy hh:mm:ss") & "' "
        sql &= " AND D.TIEMPO_COMIDA=" & cmbTiempo.SelectedValue
        sql &= " GROUP BY E.CANTIDAD"
        costo = c_data2.leerDataeader(sql, 0)
        Return costo
    End Function
    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        Me.EncabezadosProgramacion.DataSource = Nothing
        Me.DetalleProgramacion.DataSource = Nothing
    End Sub


    Private Sub cmbTiempo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiempo.SelectedIndexChanged
        If Iniciando = False Then
            BtnBuscar.PerformClick()
        End If

    End Sub
    Sub MantenimientoProgramacion(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo, ByVal Codigo, ByVal Cantidad, ByVal IUD)
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
            c_data2.Ejecutar_ConsultaSQL(sql)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() = "" Then
            MsgBox("Seleccione el producto!")
        Else
            'SE ACTUALIZAN LAS CANTIDADES PROGRAMADAS
            If (Me.EncabezadosProgramacion.CurrentRow.Cells(10).Value = True) Or (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value = "Si") Then
            Else
                Dim VAR As String = EncabezadosProgramacion.CurrentRow.Cells(3).Value.ToString()
                'ELIMINA EL ENCABEZADO Y EL DETALLE
                MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString(), 0, "D")

                'INSERTA EL ENCABEZADO
                MantenimientoProgramacion(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString(), Val(VAR).ToString, "I")

                'INSERTA EL DETALLE
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=1, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

                CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

                CargarEncabezado("Execute sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @FECHA1='" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "', @BANDERA=3")

                MsgBox("Actualizado con exito!")
            End If
        End If
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        'If Iniciando = False Then
        '    BtnBuscar.PerformClick()
        'End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() = "" Then
            MsgBox("Seleccione el producto!")
        Else
            PROC()

            If bandera1 = True Then
                MsgBox("Pre-procesado NO se ha realizado por falta de existencias!")
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=7, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
            Else
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=10, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
                MsgBox("Pre-procesado con exito!")
            End If
            CargarEncabezado("Execute sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @FECHA1='" & Format(Me.txtFecha.Value, "dd-MM-yyyy 00:00:01") & "', @BANDERA=3")

        End If
    End Sub

    Public Sub actualiza_costos_ingredientes()
        If (Me.EncabezadosProgramacion.CurrentRow.Cells(10).Value <> True) Or (Me.EncabezadosProgramacion.CurrentRow.Cells(11).Value <> "Si") Then
            'ACTUALIZAR EL DETALLE
            For i As Integer = 0 To DetalleProgramacion.RowCount - 1

                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=9, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "', @BODEGA_RECETA=" & DetalleProgramacion.Rows(i).Cells(0).Value.ToString() & ",@CODIGO_RECETA=" & DetalleProgramacion.Rows(i).Cells(2).Value.ToString() & ",@CANTIDAD_REQUERIDA=" & DetalleProgramacion.Rows(i).Cells(6).Value.ToString())

            Next

            CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        actualiza_costos_ingredientes()
        txtTotalPagar.Text = calcular_costo_produccion(EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString())
        MsgBox("COSTOS ACTUALIZADOS CON EXITO!")      
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea revertir el procesado?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            If (Me.EncabezadosProgramacion.CurrentRow.Cells(12).Value = "Si") Then
                MsgBox("Ya habia sido anulada!")
            Else
                Dim numero_Salida_6 As Integer
                Dim VAR1 As String
                Dim bodega1 As String
                For I As Integer = 0 To DetalleProgramacion.RowCount - 1

                    VAR1 = DetalleProgramacion.Rows(I).Cells(6).Value.ToString()
                    bodega1 = DetalleProgramacion.Rows(I).Cells(13).Value.ToString()
                    numero_Salida_6 = sugerirMovSalida(BodegaSeleccionada, 12)
                    'INGRESA DE PRODUCTOS TERMINADOS POR EXCEDENTES
                    cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, bodega1, 12, numero_Salida_6, CodigoProd, VAR1, 1)
                Next

                VAR1 = EncabezadosProgramacion.CurrentRow.Cells(2).Value.ToString()
                numero_Salida_6 = sugerirMovSalida(BodegaSeleccionada, 6)
                'INGRESA DE PRODUCTOS TERMINADOS POR EXCEDENTES
                cadenaSIUD(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 6, numero_Salida_6, CodigoProd, VAR1, 0)
                'ESTABLECE LA BANDERA DE ANULADO
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & EncabezadosProgramacion.CurrentRow.Cells(0).Value.ToString() & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=11, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")

            End If
            
        End If

       
    End Sub

    Private Sub EncabezadosProgramacion_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles EncabezadosProgramacion.CellValidating
        'If Not Integer.TryParse(e.FormattedValue.ToString, EncabezadosProgramacion.CurrentRow.Cells(3).Value) Then
        '    MessageBox.Show("Sólo se permiten números")
        '    e.Cancel = True
        'End If
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
                Me.txtDESCRIPCION1.Text = c_data2.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @PRODUCTO=" & Me.txtProducto.Text & ", @BANDERA=1", 1)

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub BtnBuscarCodigo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCodigo1.Click
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Me.cmbCOMPAÑIA.Text
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.ComboBox1.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.ComboBox1.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        ObtenerDatosMenu()
        TextBox3.Focus()
    End Sub
    Sub ObtenerDatosMenu()
        Me.txtProducto.Text = CodigoProducto
        Me.txtDESCRIPCION1.Text = Descripcion_Producto
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If TextBox3.Text.Equals(String.Empty) Then
                    e.Handled = True
                    TextBox3.Text = ""
                Else
                    e.Handled = TextBox3.Text.Contains(".")
                End If
            Else
                e.Handled = True
                TextBox3.Text = ""
            End If
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (txtProducto.Text = "") Or (txtDESCRIPCION1.Text = "") Then
            MsgBox("Debe ingresar un nuevo ingrediente", MsgBoxStyle.Exclamation)
        Else
            If TextBox3.Text = "" Then
                MsgBox("Debe ingresar una cantidad!", MsgBoxStyle.Exclamation)
            Else
                'INGRESA LOS PRODUCTOS EXTRAS DENTRO DEL DETALLE DE LOS PROGRAMADO, SIN ALTERAR LA RECETA MADRE
                c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BODEGA_RECETA=" & ComboBox1.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=12, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "',  @CODIGO_RECETA='" & txtProducto.Text & "',@CANTIDAD_CALCULADA=" & TextBox3.Text & ",@CANTIDAD_REQUERIDA=" & TextBox3.Text & ",@USUARIO='" & Usuario & "'")
                CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
                txtProducto.Text = ""
                txtDESCRIPCION1.Text = ""
                TextBox3.Text = ""

            End If

        End If
        
    End Sub



    Private Sub btnEliminarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCB.Click
        If (txtProducto.Text = "") Or (txtDESCRIPCION1.Text = "") Then
            MsgBox("Debe ingresar un nuevo ingrediente", MsgBoxStyle.Exclamation)
        Else
            'ELIMINA EL DETALLE SELECCIONADO DE LA RECETA PROGRAMADA SIN ALTERAR LA RECETA MADRE O CUALQUIER OTRA RECETA.
            c_data2.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ",@BODEGA_RECETA=" & ComboBox1.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=14, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "',  @CODIGO_RECETA='" & txtProducto.Text & "',@CANTIDAD_CALCULADA=" & TextBox3.Text & ",@CANTIDAD_REQUERIDA=" & TextBox3.Text & ",@USUARIO='" & Usuario & "'")
            CargarDetalle("EXECUTE sp_CAFETERIA_INGRESAR_DETALLES_PROGRAMACION @COMPAÑIA=" & Me.cmbCOMPAÑIA.SelectedValue & ", @BODEGA=" & Me.cmbBODEGA.SelectedValue & ", @CODIGO_PRODUCTO=" & CodigoProd & ", @TIEMPO=" & Me.cmbTiempo.SelectedValue & ", @BANDERA=4, @FECHA='" & Format(txtFecha.Value, "dd-MM-yyyy hh:mm:ss") & "'")
            txtProducto.Text = ""
            txtDESCRIPCION1.Text = ""
            TextBox3.Text = ""

        End If
    End Sub

    Private Sub DetalleProgramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleProgramacion.Click
        txtProducto.Text = DetalleProgramacion.CurrentRow.Cells(2).Value.ToString()
        txtDESCRIPCION1.Text = DetalleProgramacion.CurrentRow.Cells(3).Value.ToString()
        ComboBox1.SelectedValue = DetalleProgramacion.CurrentRow.Cells(0).Value
        TextBox3.Text = DetalleProgramacion.CurrentRow.Cells(6).Value.ToString()
    End Sub

    Private Sub btnNuevoCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCB.Click
        txtProducto.Text = ""
        txtDESCRIPCION1.Text = ""
        TextBox3.Text = ""
    End Sub
End Class