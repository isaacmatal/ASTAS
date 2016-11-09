Imports System.Data.SqlClient
Public Class Inventario_Traslado_Bodega
    Dim Iniciando As Boolean
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim dtareader As SqlDataReader
    Dim costo_uni As String
    Dim MensajeString As String
    Dim Procesos_Contables As New Contabilidad_Procesos
    Dim item As String = 0
    Dim pos_ante As String
    Dim clave As String = ""
    Dim CONTADOR As Integer = 1

    Private Sub Inventario_Traslado_Bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        cargarBodegas(Compañia)
        sugerirMovTransferencia()
        sugerirMovSalida()
        sugerirMovEntrada()
        Iniciando = False        
    End Sub

    Public Sub cargarBodegas(ByVal Compañia)
        If Iniciando = True Then
            c_data1.CargaBodegas(Compañia, Me.cmbBODEGA1, 7)
            c_data1.CargaBodegas(Compañia, Me.cmbBODEGA2, 7)
            Me.cmbBODEGA2.SelectedIndex = 1
        End If
    End Sub

    Public Sub sugerirMovTransferencia()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_TRANSFERENCIAS_ENCABEZADOS WHERE COMPAÑIA=" & Compañia
        Txt_tipo_movimiento_numero.Text = sugerirMov(consulta)
    End Sub

    Public Sub sugerirMovSalida()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA1.SelectedValue & " AND TIPO_MOVIMIENTO = 4"
        numeroSalida.Text = sugerirMov(consulta)
    End Sub

    Public Sub sugerirMovEntrada()
        Dim consulta As String = "SELECT ISNULL(MAX(MOVIMIENTO), 0) + 1 FROM INVENTARIOS_MOVIMIENTOS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA2.SelectedValue & " AND TIPO_MOVIMIENTO = 1"
        numeroEntrada.Text = sugerirMov(consulta)
    End Sub

    Public Function sugerirMov(ByVal consulta)
        Dim mov As String        
        mov = c_data1.leerDataeader(consulta, 0)
        Return mov
    End Function

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Frm_Busqueda As New Inventario_Movimiento_busqueda_productos_por_bodega
        Frm_Busqueda.Iniciando = True
        Frm_Busqueda.TxtCompañia.Text = Descripcion_Compañia
        Frm_Busqueda.TxtCompañia_cod.Text = Compañia
        Frm_Busqueda.TxtBodega.Text = Me.cmbBODEGA1.Text
        Frm_Busqueda.TxtBodega_cod.Text = Me.cmbBODEGA1.SelectedValue
        Frm_Busqueda.Iniciando = False
        Frm_Busqueda.ShowDialog()
        Me.Txt_Producto_codigo.Text = CodigoProducto
        Me.Txt_Producto_descripcion.Text = Descripcion_Producto
        Me.txt_Unidades.Text = unidades
        Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
    End Sub

    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        If sender Is btnGuardarLinea Then
            Dim CANTIDAD As String
            'Verifica si se ha ingresado todos los parametros que el formulario requiere
            If Validacion() = 1 Then

                If Val(Txt_tipo_movimiento_numero.Text) = 0 Then
                    MsgBox("INGRESE EL NUMERO DE LA NOTA DE REMISION")
                    Exit Sub
                End If

                'Verifica si hay sificientes existencias de la bodega inicial            

                CANTIDAD = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & cmbBODEGA1.SelectedValue & "," & Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

                'si devuelve 0 es porque no hay fucientes
                If (Val(CANTIDAD) < Val(Txt_Producto_cantidad.Text)) Then
                    MessageBox.Show("LA EXISTENCIA NO ES SUFICIENTE")
                    Me.Txt_Producto_codigo.Focus()
                Else
                    Dim verificar_cierre As String = c_data1.leerDataeader("EXECUTE sp_INVENTARIOS_CIERRE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA1.SelectedValue & ",@FECHA_AÑO='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA_MES='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@BIT=0", 0)
                    If (verificar_cierre = 1) Then
                        MsgBox("El mes ya fue cerrado para la bodega: " & Me.cmbBODEGA1.SelectedText.ToString(), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    verificar_cierre = c_data1.leerDataeader("EXECUTE sp_INVENTARIOS_CIERRE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@FECHA_AÑO='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA_MES='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@BIT=0", 0)
                    If (verificar_cierre = 1) Then
                        MsgBox("El mes ya fue cerrado para la bodega: " & Me.cmbBODEGA2.SelectedText.ToString(), MsgBoxStyle.Information)
                    Else
                        If (CONTADOR = 1) Then
                            c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=1")
                            CONTADOR = 0
                        End If
                        'If dgvMovtos.RowCount = 0 Then

                        'HACE LA SALIDA
                        Accion_producto_bandeja("I", cmbBODEGA1.SelectedValue, 4, numeroSalida.Text, False, 0)

                        'HACE LA ENTRADA
                        Accion_producto_bandeja("I", cmbBODEGA2.SelectedValue, 1, numeroEntrada.Text, True, cost)

                        'HACE EL INGRESO AL ENCABEZADO DE TRANSFERENCIA
                        c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=1, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)

                        'muestra el grid                
                        CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
                        MsgBox("EL PRODUCTO SE HA TRANSFERIDO CON EXITO " & Me.cmbBODEGA2.SelectedText.ToString(), MsgBoxStyle.Information)
                        Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                        Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

                        Limpiar()

                        Me.Txt_Producto_codigo.Focus()
                        'End If
                    End If
                End If
            End If

        ElseIf sender Is BtnLimpiar Then
            Limpiar()
        End If
    End Sub

    Sub Accion_producto_bandeja(ByVal SIUD, ByVal BODEGA, ByVal TIPO_MOV, ByVal mov1, ByVal in_out, ByVal cost)
        Try
            DS02.Reset()
            SIUD = cadenaSIUD(Compañia, SIUD, BODEGA, TIPO_MOV, mov1, in_out, cost)
            c_data1.MiddleConnection(SQL)
            c_data1.DataAdapter.Fill(DS02)


        Catch ex As Exception
            If SIUD = "I" Then
                MensajeString = "No se pudo insertar los datos por: "
            ElseIf SIUD = "UR" Then
                MensajeString = "No se pudieron Actualizar los datos por: "
            ElseIf SIUD = "DR" Then
                MensajeString = "No se pudieron Eliminar los datos por: "
            End If
            MessageBox.Show(MensajeString & Chr(13) & ex.Message, "Aviso...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            c_data1.cerrarConexion()
        End Try
    End Sub

    Sub EliminarDetalle(ByVal SIUD, ByVal BODEGA, ByVal TIPO_MOV, ByVal mov, ByVal in_out)
        Try
            DS02.Reset()
            cadenaSIUD(Compañia, SIUD, BODEGA, TIPO_MOV, mov, in_out, 0)
            c_data1.Ejecutar_ConsultaSQL(SQL)
        Catch ex As Exception
            If SIUD = "DD" Then
                MensajeString = "Se ha eliminado el detalle con exito!"
            End If
            MessageBox.Show(MensajeString & Chr(13) & ex.Message, "Aviso...!!!" & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            c_data1.cerrarConexion()
        End Try
    End Sub

    Public Function cadenaSIUD(ByVal CIA, ByVal SIUD, ByVal BODEGA, ByVal TIPO_MOV, ByVal MOV1, ByVal IN_OUT, ByVal cost)
        'TIPO DE MOVIMIENTO 4: SALIDA POR TRANSFERENCIA
        'SOLO CALCULA COSTO CUANDO ES LA SALIDA
        If TIPO_MOV = 4 Then
            Dim tipo_costo As String = c_data1.leerDataeader("EXEC [dbo].[sp_INVENTARIOS_INGRESAR_COMPRAS] @COMPAÑIA=" & Compañia & ",@PRODUCTO=" & Val(Txt_Producto_codigo.Text) & ",@BANDERA='V'", 0)

            If Val(tipo_costo) = 1 Then
                'COSTO PROMEDIO
                costo_uni = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & BODEGA & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
            Else
                'UEPS
                If IN_OUT = True Then
                    c_data1.IngresarCostoUeps(Compañia, BODEGA, Val(Me.Txt_Producto_codigo.Text), Val(Txt_Producto_cantidad.Text), 0, "I", Val(cost))
                End If

                costo_uni = c_data1.IngresarCostoUeps(Compañia, BODEGA, Val(Me.Txt_Producto_codigo.Text), 0, 0, "S")
            End If
        End If
        cost = costo_uni
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & BODEGA
        SQL &= ",@PROVEEDOR = 1"
        SQL &= ",@TIPO_MOVIMIENTO = " & TIPO_MOV
        SQL &= ",@MOV = " & MOV1
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = " & Val(Txt_tipo_movimiento_numero.Text)
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & Val(Me.Txt_Producto_codigo.Text)
        SQL &= ",@CANTIDAD = " & Val(Me.Txt_Producto_cantidad.Text)

        SQL &= ",@COSTO_UNIDAD = " & Val(cost)
        SQL &= ",@COSTO_TOTAL = " & (Val(Me.Txt_Producto_cantidad.Text) * Val(cost)).ToString()

        SQL &= ",@ENTRADA_SALIDA =" & IN_OUT
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'" & SIUD & "'"

        Return costo_uni
    End Function

    Sub CargarGrid(ByVal cadena)
        Try
            DS01.Reset()
            SQL = cadena
            c_data1.MiddleConnection(SQL)
            c_data1.DataAdapter.Fill(DS01)
            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data1.cerrarConexion()
            'justificar derecha
            Me.dgvMovtos.Columns.Item(0).Visible = False
            Me.dgvMovtos.Columns.Item(1).Visible = False

            Me.dgvMovtos.Columns.Item(6).Visible = False
            Me.dgvMovtos.Columns.Item(7).Visible = False
            Me.dgvMovtos.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            For i As Integer = 1 To dgvMovtos.ColumnCount
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Código no Encontrado, Favor Verificar", MsgBoxStyle.Information)
        Finally
            c_data1.cerrarConexion()
        End Try

    End Sub

    Public Function Validacion()
        Dim cf As String = "Campo Faltante:" & Chr(13)
        If Me.Txt_Producto_codigo.Text.Trim = Nothing Then
            MessageBox.Show("No ha ingresado el código de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBuscarProducto.Focus()
            Return 0
        ElseIf Val(Me.Txt_Producto_cantidad.Text) <= 0 Then
            MessageBox.Show(cf & "Cantidad de producto no válida...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_Producto_cantidad.Clear()
            Me.Txt_Producto_cantidad.Focus()
            Return 0
        Else
            Return 1
        End If
    End Function

#Region "Connection"
    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Resultado As DialogResult
#End Region

    Private Sub CmbCompania_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            cargarBodegas(Compañia)
        End If
    End Sub

    Private Sub cmbBODEGA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA1.SelectedIndexChanged
        If Iniciando = False Then
            compararBodegasSeleccionadas()
            sugerirMovTransferencia()
            sugerirMovSalida()
            sugerirMovEntrada()
        End If        
    End Sub

    Public Sub compararBodegasSeleccionadas()
        If cmbBODEGA1.SelectedValue = cmbBODEGA2.SelectedValue Then
            MessageBox.Show("Debe seleccionar bodegas distintas")
        End If
    End Sub

    Private Sub cmbBODEGA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA2.SelectedIndexChanged
        If Iniciando = False Then
            compararBodegasSeleccionadas()            
            sugerirMovTransferencia()
            sugerirMovSalida()
            sugerirMovEntrada()        
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Limpiar()
        CONTADOR = 1
        c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=3")
        txtDIFERENCIA.Text = ""
        Txt_tipo_movimiento_numero.Clear()
        sugerirMovTransferencia()
        sugerirMovSalida()
        sugerirMovEntrada()
        cargarBodegas(Compañia)
        dgvMovtos.DataSource = Nothing
        txt_Unidades.Text = ""
        BtnEliminar.Enabled = True
        btnGuardarLinea.Enabled = True
        If dpFECHA_CONTABLE.Enabled = True Then            
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados', @BANDERA=4, @ITEM=" & item)
            dpFECHA_CONTABLE.Value = Date.Now
        End If
        clave = ""
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Public Sub Limpiar()
        Txt_Producto_codigo.Text = ""
        Txt_Producto_descripcion.Text = ""
        Txt_Producto_cantidad.Text = ""
        Me.txt_Unidades.Text = ""
        costo_uni = "0"
        btnProcesarPartida.Enabled = True
        Txt_tipo_movimiento_numero.Enabled = False
        lblProcesado.Text = "NUEVO DOCUMENTO"
    End Sub

    Private Sub Txt_Producto_codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Me.Txt_Producto_codigo.Text.Trim IsNot Nothing Then
                Try
                    Me.Txt_Producto_descripcion.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA1.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 1)
                    Me.txt_Unidades.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA1.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 2)
                    Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                    Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                    Me.Txt_Producto_cantidad.Focus()
                Catch ex As Exception
                    Txt_Producto_codigo.Text = ""
                    MsgBox("El código es numérico", MsgBoxStyle.Information)
                End Try
            End If
        End If
    End Sub

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        Dim Tipo_Costo As Integer = 1
        Dim cantidad As String = 0
        Dim COSTO_PROM As String = 0
        Dim Costo_Total As Double = 0
        Dim Costo_Total_doc As Double = 0

        For i As Integer = 1 To dgvMovtos.RowCount
            'Determina el tipo de costo perteneciente al producto
            Tipo_Costo = c_data1.leerDataeader("SELECT ISNULL(TIPO_COSTO,1) FROM INVENTARIOS_CATALOGO_PRODUCTOS WHERE COMPAÑIA=" & Compañia & " AND PRODUCTO=" & dgvMovtos.Rows(i - 1).Cells(3).Value.ToString(), 0)

            If Tipo_Costo = 1 Then ' Costo Promedio
                COSTO_PROM = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & dgvMovtos.Rows(i - 1).Cells(3).Value.ToString() & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "')", 0)
            Else                   ' Costo UEPS
                COSTO_PROM = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS_UEPS(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & dgvMovtos.Rows(i - 1).Cells(3).Value.ToString() & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "')", 0)
            End If

            cantidad = Convert.ToDouble(dgvMovtos.Rows(i - 1).Cells(5).Value.ToString())
            Costo_Total = Convert.ToDouble(cantidad) * Convert.ToDouble(COSTO_PROM.ToString())
            Costo_Total_doc = Costo_Total_doc + Costo_Total
        Next

        ActualizarCostos(Me.cmbBODEGA1.SelectedValue, 4, 0, cantidad, COSTO_PROM, Costo_Total.ToString(), 0, numeroSalida.Text)

        ActualizarCostos(Me.cmbBODEGA2.SelectedValue, 1, 0, cantidad, COSTO_PROM, Costo_Total.ToString(), 1, numeroEntrada.Text)
        Try
            CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
        Catch ex As Exception

        End Try
        txtDIFERENCIA.Text = Costo_Total_doc.ToString()
        btnProcesarPartida.Enabled = False
        BtnLimpiar.Enabled = False
        BtnEliminar.Enabled = False
        btnGuardarLinea.Enabled = False
        Txt_tipo_movimiento_numero.Enabled = False
        Try
            'SE DETERMINA LA CUENTA ABONAR
            Dim CtaAbonada As Integer = c_data1.leerDataeader("SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA2.SelectedValue, 0)
            'SE DETERMINA LA CUENTA A CARGAR
            Dim CtaCargada As Integer = c_data1.leerDataeader("SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA1.SelectedValue, 0)
            Dim Concepto1 As String = "ST: Salida por Transferencia de Inventario entre Bodegas: De " & Trim(cmbBODEGA1.SelectedText) & " a " & Trim(cmbBODEGA2.SelectedText)
            Dim Concepto2 As String = "Transferencia de Inventario."
            If CtaAbonada = 0 Or CtaCargada = 0 Then
                MsgBox("NO SE CREARA PARTIDA, FALTA DEFINIR CUENTA CONTABLE PARA UNA DE LAS BODEGAS!!!", MsgBoxStyle.Information)
            Else
                '**************************************************************************************************************************
                'SE DETERMINA EL NUMERO DE TRANSACCION
                'Dim Transaccion As Integer = c_data1.leerDataeader("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & dpFECHA_CONTABLE.Value.Year & ", @MES = " & dpFECHA_CONTABLE.Value.Month & ", @ULTIMO = 0", 0)
                'SE DETERMINA EL LIBRO
                'Dim Libro As Integer = c_data1.leerDataeader("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1", 0)
                'SE DETERMINA EL CENTRO DE COSTO
                'Dim CentCosto As Integer = c_data1.leerDataeader("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA1.SelectedValue, 0)
                'SE GENERA EL ENCABEZADO
                'Procesos_Contables.EncabezadoPartida(Transaccion, 2, 34, Txt_tipo_movimiento_numero.Text, dpFECHA_CONTABLE.Value, Libro, Concepto1, 0, 0, "I")
                ''SE GENERA EL DETALLE PARA LA CUENTA CARGADA
                'Procesos_Contables.DetallePartida(Transaccion, 0, CentCosto, dpFECHA_CONTABLE.Value, Libro, concepto2, CtaCargada, "C", txtDIFERENCIA.Text, 0, "I")
                ''SE GENERA EL DETALLE PARA LA CUENTA ABONADA
                'Procesos_Contables.DetallePartida(Transaccion, 0, CentCosto, dpFECHA_CONTABLE.Value, Libro, Concepto2, CtaAbonada, "A", 0, txtDIFERENCIA.Text, "I")
                ''SE PROCESA LA PARTIDA
                'Dim sqlCmd As New SqlCommand("EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPAÑIA = " & Compañia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'")
                'c_data1.ejecutarComandoSql(sqlCmd)
                '**************************************************************************************************************************
            End If
            If Me.dgvMovtos.Rows.Count > 0 Then
                ComprobarExisteProducto()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Traslado Bodega")
        End Try
        'FUNCION QUE ESTABLECE FECHEO
        If dpFECHA_CONTABLE.Enabled = True Then            
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados', @BANDERA=4, @ITEM=" & item)

        End If
        'SINCRONIZA LA VENTANA CON LA DE FACTURACION DE CAFETERIA.
        c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=3")
        Dim rpt As New frmReportes_Ver(Compañia, cmbBODEGA1.SelectedValue, 4, 0, Me.dpFECHA_CONTABLE.Value, Me.dpFECHA_CONTABLE.Value, 30, cmbBODEGA2.SelectedValue, numeroSalida.Text)
        rpt.ShowDialog()

        dpFECHA_CONTABLE.Value = Date.Now
        clave = ""
    End Sub

    Public Sub ActualizarCostos(ByVal bodega, ByVal tipo_mov, ByVal producto, ByVal cantidad, ByVal costo_unitario, ByVal costo_total, ByVal entrada_salida, ByVal numero_in_out)
        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & Compañia
        SQL &= ",@BODEGA = " & bodega
        SQL &= ",@PROVEEDOR = 0"
        SQL &= ",@TIPO_MOVIMIENTO = " & Val(tipo_mov)
        SQL &= ",@MOV = " & Val(numero_in_out)
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & producto
        SQL &= ",@CANTIDAD = " & cantidad
        SQL &= ",@COSTO_UNIDAD = " & Val(costo_unitario)
        SQL &= ",@COSTO_TOTAL = " & Val(costo_total)
        SQL &= ",@ENTRADA_SALIDA =" & entrada_salida
        SQL &= ",@USUARIO = N'" & Usuario & "'"
        SQL &= ",@SIUD = N'U'"
        c_data1.Ejecutar_ConsultaSQL(SQL)
    End Sub

    Private Sub Txt_Producto_cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Producto_cantidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If Txt_Producto_cantidad.Text.Equals(String.Empty) Then
                    e.Handled = True
                    Txt_Producto_cantidad.Text = ""
                Else
                    e.Handled = Txt_Producto_cantidad.Text.Contains(".")
                End If
            Else
                e.Handled = True
                Txt_Producto_cantidad.Text = ""
            End If
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnGuardarLinea.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        EliminarDetalle("DD", cmbBODEGA1.SelectedValue, 4, numeroSalida.Text, False)
        EliminarDetalle("DD", cmbBODEGA2.SelectedValue, 1, numeroEntrada.Text, True)

        Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

        CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
        
        Limpiar()
    End Sub

    Private Sub dgvMovtos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovtos.CellClick
        Try
            Me.Txt_Producto_codigo.Text = dgvMovtos.CurrentRow.Cells(3).Value.ToString()
            Txt_Producto_descripcion.Text = dgvMovtos.CurrentRow.Cells(4).Value.ToString()
            Txt_Producto_cantidad.Text = dgvMovtos.CurrentRow.Cells(5).Value.ToString()
        Catch ex As Exception
            Me.Txt_Producto_codigo.Text = "0"
            Txt_Producto_descripcion.Text = ""
            Txt_Producto_cantidad.Text = "0"
            MsgBox("DEBEN HABER PRODUCTOS EN LA BANDEJA!!!", MsgBoxStyle.Information)
        End Try
    End Sub
    
    Private Sub Btn_Buscar_Movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Movimiento.Click
        If Iniciando = False Then
            'muestra el grid     
            If Txt_tipo_movimiento_numero.Text = "" Then
                MsgBox("Aviso...Debe ingresar el número del movimiento a buscar", MsgBoxStyle.Information)
            Else
                Try
                    CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Val(Txt_tipo_movimiento_numero.Text) & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
                    If dgvMovtos.Rows(0).Cells(1).Value.ToString() = "True" Then
                        lblProcesado.Text = "DOCUMENTO PROCESADO"
                        btnProcesarPartida.Enabled = False
                        btnGuardarLinea.Enabled = False
                        BtnLimpiar.Enabled = False
                        BtnEliminar.Enabled = False
                    Else
                        lblProcesado.Text = "DOCUMENTO NO PROCESADO"
                        btnProcesarPartida.Enabled = True
                        btnGuardarLinea.Enabled = True
                        BtnLimpiar.Enabled = True
                        BtnEliminar.Enabled = True
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Tabla As DataTable
        Dim sqlCmd As New SqlCommand
        Dim rptver As New frmReportes_Ver
        Dim reporte_30 As New Inventario_Reporte_Transferencias
        sqlCmd.CommandText = "EXECUTE sp_INVENTARIOS_REPORTE_TRANSFERENCIAS @COMPAÑIA=" & Compañia & ",@BODEGA1=" & Me.cmbBODEGA1.SelectedValue & ",@BODEGA2=" & Me.cmbBODEGA1.SelectedValue & ",@TIPO_MOVIMIENTO=" & "4" & ",@ENTRADA_SALIDA =" & "0" & ",@FECHA1='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @DOCTO='" & numeroSalida.Text & "'"
        Tabla = c_data1.obtenerDatos(sqlCmd)
        reporte_30.SetDataSource(Tabla)
        rptver.ReportesGenericos(reporte_30)
        rptver.ShowDialog()
    End Sub

    Private Sub Inventario_Traslado_Bodega_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.txtFecheo.Text = "" Then
            Dim fecheo As New Seguridad_Pos_Ante_Fecheo(cmbBODEGA2.Text, Me.cmbBODEGA2.SelectedValue, "Inventario_Traslados")
            fecheo.ShowDialog()
        Else
            clave = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados', @BANDERA=3", 0)
            item = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados', @BANDERA=3", 1)
            pos_ante = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados', @BANDERA=3", 2)
        End If
    End Sub

    Private Sub dpFECHA_CONTABLE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFECHA_CONTABLE.ValueChanged
        Dim fecha_adelante As Date
        Dim fecha_atras As Date
        fecha_adelante = DateAdd("d", 1, Date.Now)
        fecha_atras = DateAdd("d", -2, Date.Now)

        If clave <> "" Then
            If pos_ante = "True" Then
                If dpFECHA_CONTABLE.Value.Date < Date.Now.Date Then
                    MsgBox("Imposible realizar un AnteFecheo porque usted solicito un PosFecheo", MsgBoxStyle.Exclamation)
                    dpFECHA_CONTABLE.Value = Date.Now
                End If
            Else
                If dpFECHA_CONTABLE.Value.Date > Date.Now.Date Then
                    MsgBox("Imposible realizar un PosFecheo porque usted solicito un AnteFecheo", MsgBoxStyle.Exclamation)
                    dpFECHA_CONTABLE.Value = Date.Now
                End If
            End If
        Else
            If (dpFECHA_CONTABLE.Value.Date > fecha_adelante) Or (dpFECHA_CONTABLE.Value.Date < fecha_atras) Then
                MsgBox("Imposible realizar un cambios de fecha de 2 dias, retorna a fecha actual " & Date.Now, MsgBoxStyle.Exclamation)
                dpFECHA_CONTABLE.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub Inventario_Traslado_Bodega_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_SEGURIDAD_SINCRONIZACION @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@MAQUINA='" & My.Computer.Name.ToString() & "', @USUARIO='" & Usuario & "', @VENTANA='TRANSFERENCIA DE INVENTARIOS', @BANDERA=3")

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Txt_tipo_movimiento_numero.Enabled = False Then
            Txt_tipo_movimiento_numero.Enabled = True
        Else
            Txt_tipo_movimiento_numero.Enabled = False
        End If
    End Sub

    'Add julio Galeas 12/01/2015
    Private Sub ComprobarExisteProducto()
        Dim CMD_ As SqlCommand
        Try
            SQL = String.Empty
            For i As Integer = 0 To Me.dgvMovtos.Rows.Count - 1
                SQL &= "Execute sp_INVENTARIOS_COMPROBAR_PRODUCTO "
                SQL &= Compañia
                SQL &= ", " & Me.cmbBODEGA2.SelectedValue  '@BODEGA
                SQL &= ", " & Me.dgvMovtos.Rows(i).Cells.Item(3).Value '@PRODUCTO
                SQL &= ", '" & Usuario & "' " & vbCrLf
            Next
            CMD_ = New SqlCommand(SQL)
            c_data1.ejecutarComandoSql(CMD_)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
