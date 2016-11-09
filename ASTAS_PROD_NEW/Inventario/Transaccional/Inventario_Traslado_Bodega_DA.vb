Imports System.Data.SqlClient
Public Class Inventario_Traslado_Bodega_DA
    Dim Iniciando As Boolean
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim dtareader As SqlDataReader
    Dim costo_uni As String
    Dim MensajeString As String
    Dim Procesos_Contables As New Contabilidad_Procesos
    Dim item As String = 0
    Dim pos_ante As String
    Dim clave As String
    Dim _guardado As Boolean

    Private Sub Inventario_Traslado_Bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        cargarBodegas(Compañia)
        sugerirMovTransferencia()
        sugerirMovSalida()
        sugerirMovEntrada()
        CargarTiempoComida(Compañia, Me.cmbTiempo, "S")
        Iniciando = False
        'Al guardar el detalle por primera vez se marca como guardado
        _guardado = False
    End Sub
    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo As ComboBox, ByVal IUD As Char)
        Try
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            c_data1.CargarCombo(Me.cmbTiempo, SQL, "Tiempo de Comida", "Descripción")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub cargarBodegas(ByVal Compañia)
        If Iniciando = True Then
            c_data1.CargaBodegas(Compañia, Me.cmbBODEGA1, 7)
            c_data1.CargaBodegas(Compañia, Me.cmbBODEGA2, 9) 'Para bodegas facturables.
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
        Label19.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13 , @BANDERA='S1'", 0)

        Label22.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)
    End Sub
    Public Sub Limpiar()
        Txt_Producto_codigo.Text = ""
        Txt_Producto_descripcion.Text = ""
        Txt_Producto_cantidad.Text = ""
        Me.txt_Unidades.Text = ""        
        Txt_tipo_movimiento_numero.Enabled = False
        btnProcesarPartida.Enabled = True
        lblProcesado.Text = "NUEVO DOCUMENTO"
        _guardado = False
    End Sub
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
        If dpFECHA_CONTABLE.Enabled = True Then

            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=4, @ITEM=" & item)
            dpFECHA_CONTABLE.Value = Date.Now
        End If
    End Sub
    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        Dim CANTIDAD As String
        If Not _guardado Then
            sugerirMovTransferencia()
        End If
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
                MessageBox.Show("LAS EXISTENCIAS NO SON SUFICIENTE")
            Else
                Dim verificar_cierre As String = c_data1.leerDataeader("EXECUTE sp_INVENTARIOS_CIERRE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA1.SelectedValue & ",@FECHA_AÑO='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA_MES='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@BIT=0", 0)
                If (verificar_cierre = 1) Then
                    MsgBox("El mes ya fue cerrado para la bodega: " & Me.cmbBODEGA1.SelectedText.ToString(), MsgBoxStyle.Information)
                    Exit Sub
                End If
                verificar_cierre = c_data1.leerDataeader("EXECUTE sp_INVENTARIOS_CIERRE @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@FECHA_AÑO='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@FECHA_MES='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "',@BIT=0", 0)
                If (verificar_cierre = 1) Then
                    MsgBox("El mes ya fue cerrado para la bodega: " & Me.cmbBODEGA2.SelectedText.ToString(), MsgBoxStyle.Information)
                    Exit Sub
                End If
                If Val(Label19.Text) = 0 Then
                    MessageBox.Show("EL PRECIO DEL PRODUCTO A TRASLADAR ES $0.0, VERIFIQUE POR FAVOR")
                    Exit Sub
                End If

                If (verificar_cierre = 0) Then

                    _guardado = True
                    'HACE LA SALIDA
                    Accion_producto_bandeja("I", cmbBODEGA1.SelectedValue, 4, numeroSalida.Text, False)
                    'HACE LA ENTRADA
                    Accion_producto_bandeja("I", cmbBODEGA2.SelectedValue, 1, numeroEntrada.Text, True)

                    'HACE EL INGRESO AL ENCABEZADO DE TRANSFERENCIA
                    c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=1, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)

                    'muestra el grid                
                    CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)

                    'ACTUALIZA PRECIO DE VENTA
                    c_data1.Ejecutar_ConsultaSQL("EXEC sp_CAFETERIA_PRECIOS_VENTA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@CODIGO=" & Txt_Producto_codigo.Text & ",@TIEMPO=" & Me.cmbTiempo.SelectedValue & ",@FECHA=N'" & dpFECHA_CONTABLE.Value.ToString("dd/MM/yyyy 00:00:01") & "', @CANTIDAD=" & Txt_Producto_cantidad.Text & ",@PRECIO=" & Label19.Text & ", @IVA=13,@IUD='U',@USUARIO='" & Usuario & "'")

                    Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                    Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

                    Label19.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)
                    Label22.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)

                    Limpiar()

                    MsgBox("EL PRODUCTO SE HA TRANSFERIDO CON EXITO " & Me.cmbBODEGA2.SelectedText.ToString(), MsgBoxStyle.Information)

                    MantenimientoProgramacion(Compañia, Me.cmbBODEGA1.SelectedValue, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "C")

                End If
            End If
        End If
    End Sub
    Sub Accion_producto_bandeja(ByVal SIUD, ByVal BODEGA, ByVal TIPO_MOV, ByVal mov, ByVal in_out)
        Try
            DS01.Reset()
            SIUD = cadenaSIUD(Compañia, SIUD, BODEGA, TIPO_MOV, mov, in_out)
            c_data1.MiddleConnection(SQL)
            c_data1.DataAdapter.Fill(DS01)


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
            DS01.Reset()
            cadenaSIUD(Compañia, SIUD, BODEGA, TIPO_MOV, mov, in_out)
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
    Public Function calcular_costo_unitario_plato(ByVal compañia As String, ByVal bodega As String, ByVal codigo As String, ByVal tiempo As String, ByVal fecha As String)
        SQL = "DECLARE @COMPAÑIA AS INT = " & compañia
        SQL &= " DECLARE @BODEGA   AS INT =" & bodega
        SQL &= " DECLARE @PRODUCTO AS INT =" & codigo
        SQL &= " DECLARE @TIEMPO   AS INT =" & tiempo
        SQL &= " DECLARE @FECHA    AS DATETIME ='" & fecha & "' "
        SQL &= "DECLARE @TABLA AS TABLE(BODEGA_INGREDIENTE INT, "
        SQL &= "CODIGO_INGREDIENTE INT, "
        SQL &= "CANTIDAD_REQUERIDA NUMERIC(18,6), "
        SQL &= "COSTO              MONEY, "
        SQL &= "TOTAL_COSTO        MONEY) "
        SQL &= "DECLARE @COSTO_PLATO        AS NUMERIC(18,6) "
        SQL &= "DECLARE @CANTIDAD_PRODUCIR        AS NUMERIC(18,6) "        
        SQL &= "INSERT INTO @TABLA "
        SQL &= "SELECT	PS.BODEGA_RECETA, "
        SQL &= "PS.CODIGO_RECETA, "
        SQL &= "PS.CANTIDAD_REQUERIDA, "
        SQL &= "((dbo.INVENTARIOS_CALCULAR_COSTOS(@COMPAÑIA, PS.BODEGA_RECETA, PS.CODIGO_RECETA, @FECHA))) AS COSTO, "
        SQL &= "((dbo.INVENTARIOS_CALCULAR_COSTOS(@COMPAÑIA, PS.BODEGA_RECETA, PS.CODIGO_RECETA, @FECHA)) * PS.CANTIDAD_REQUERIDA) AS TOTAL "
        SQL &= "FROM CAFETERIA_PROGRAMACION_SEMANAL_DETALLE PS					"
        SQL &= "WHERE PS.COMPAÑIA        = @COMPAÑIA AND "
        SQL &= "PS.BODEGA_PRODUCTO = @BODEGA   AND "
        SQL &= "PS.CODIGO_PRODUCTO = @PRODUCTO AND "
        SQL &= "PS.TIEMPO_COMIDA   = @TIEMPO   AND "
        SQL &= "CONVERT(DATE,PS.FECHA)           = CONVERT(DATE,@FECHA) "

        SQL &= "SELECT @CANTIDAD_PRODUCIR=CANTIDAD FROM CAFETERIA_PROGRAMACION_SEMANAL "
        SQL &= "WHERE BODEGA=@BODEGA AND CODIGO_PRODUCTO=@PRODUCTO AND CONVERT(DATE,FECHA)= CONVERT(DATE,@FECHA) AND TIEMPO_COMIDA=@TIEMPO "

        SQL &= "SELECT @COSTO_PLATO = ISNULL(SUM(TOTAL_COSTO),0.00) FROM @TABLA "
        SQL &= "SELECT @COSTO_PLATO = ROUND(@COSTO_PLATO,2)/@CANTIDAD_PRODUCIR "

        SQL &= "SELECT @COSTO_PLATO	"

        Return c_data1.leerDataeader(SQL, 0)
    End Function
    Function calcular_costo_produccion(ByVal codigo_prod As String)
        Dim costo As String = "0"
        'DETERMINA LA SUMATORIA DE LOS COSTOS UNITARIOS
        sql = " Select SUM(D.TOTAL) / E.CANTIDAD "
        sql &= " FROM CAFETERIA_PROGRAMACION_SEMANAL_DETALLE D "
        sql &= " INNER JOIN CAFETERIA_PROGRAMACION_SEMANAL E "
        sql &= " ON E.COMPAÑIA=D.COMPAÑIA AND E.BODEGA=D.BODEGA_PRODUCTO AND E.CODIGO_PRODUCTO=D.CODIGO_PRODUCTO AND E.FECHA=D.FECHA AND E.TIEMPO_COMIDA=D.TIEMPO_COMIDA "
        SQL &= " WHERE D.COMPAÑIA=" & Compañia & " AND D.BODEGA_PRODUCTO=" & cmbBODEGA1.SelectedValue & " AND D.CODIGO_PRODUCTO=" & codigo_prod & " AND D.FECHA='" & Me.dpFECHA_CONTABLE.Value.ToString("dd/MM/yyyy hh:mm:ss") & "' "
        sql &= " AND D.TIEMPO_COMIDA=" & cmbTiempo.SelectedValue
        sql &= " GROUP BY E.CANTIDAD"
        costo = c_data1.leerDataeader(SQL, 0)
        Return costo
    End Function
    Public Function cadenaSIUD(ByVal CIA, ByVal SIUD, ByVal BODEGA, ByVal TIPO_MOV, ByVal MOV, ByVal IN_OUT)
        If BODEGA = cmbBODEGA1.SelectedValue Then
            costo_uni = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & BODEGA & "," & Val(Me.Txt_Producto_codigo.Text) & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        End If        

        SQL = "Execute [dbo].[sp_INVENTARIOS_MOVIMIENTO_SIUD] "
        SQL &= "@COMPAÑIA = " & CIA
        SQL &= ",@BODEGA = " & BODEGA
        SQL &= ",@PROVEEDOR = 1"
        SQL &= ",@TIPO_MOVIMIENTO = " & TIPO_MOV
        SQL &= ",@MOV = " & MOV
        SQL &= ",@TIPO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@NUMERO_DOCUMENTO_CONTABLE = 0"
        SQL &= ",@FECHA_MOVIMIENTO = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        SQL &= ",@ANULADO = " & 0
        SQL &= ",@PROCESADO = " & 1
        SQL &= ",@PRODUCTO = " & Val(Me.Txt_Producto_codigo.Text)
        SQL &= ",@CANTIDAD = " & Val(Me.Txt_Producto_cantidad.Text)

        SQL &= ",@COSTO_UNIDAD = " & Val(costo_uni)
        SQL &= ",@COSTO_TOTAL = " & (Val(Me.Txt_Producto_cantidad.Text) * Val(costo_uni)).ToString()

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
            Me.dgvMovtos.Columns.Item(2).Visible = False
            Me.dgvMovtos.Columns.Item(6).Visible = False
            Me.dgvMovtos.Columns.Item(7).Visible = False
            Me.dgvMovtos.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.dgvMovtos.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            For i As Integer = 1 To dgvMovtos.ColumnCount
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
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
        Else
            Return 1
        End If
        If Me.Txt_Producto_descripcion.Text.Trim = Nothing Then
            MessageBox.Show(cf & "No ha ingresado la descripción de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnBuscarProducto.Focus()
            Return 0
        Else
            Return 1
        End If
        If Val(Me.Txt_Producto_cantidad.Text) <= 0 Then
            MessageBox.Show(cf & "No ha ingresado la cantidad de producto...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MantenimientoProgramacion(Compañia, Me.cmbBODEGA1.SelectedValue, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "C")
            Calcular_Procesadas()
        End If
    End Sub
    Public Sub compararBodegasSeleccionadas()
        If cmbBODEGA1.SelectedValue = cmbBODEGA2.SelectedValue Then
            MessageBox.Show("Debe seleccionar bodegas distintas")
        End If
    End Sub

    Private Sub cmbBODEGA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA2.SelectedIndexChanged
        If Iniciando = False Then
            sugerirMovTransferencia()
            sugerirMovSalida()
            sugerirMovEntrada()
            compararBodegasSeleccionadas()
        End If
    End Sub

    Private Sub Btn_Buscar_Movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Movimiento.Click
        If Iniciando = False Then
            'muestra el grid     
            If Txt_tipo_movimiento_numero.Text = "" Then
                MsgBox("Aviso...Debe ingresar el numero del movimiento a buscar", MsgBoxStyle.Information)
            Else
                Try
                    CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Val(Txt_tipo_movimiento_numero.Text) & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
                    If dgvMovtos.Rows(0).Cells(1).Value.ToString() = "True" Then
                        btnProcesarPartida.Enabled = False
                        lblProcesado.Text = "DOCUMENTO PROCESADO"
                    Else
                        btnProcesarPartida.Enabled = True
                        lblProcesado.Text = "DOCUMENTO NO PROCESADO"
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Sub nuevo()
        txtDIFERENCIA.Text = ""
        sugerirMovTransferencia()
        sugerirMovSalida()
        sugerirMovEntrada()
        cargarBodegas(Compañia)
        dgvMovtos.DataSource = Nothing
        txt_Unidades.Text = ""
        Button1.Enabled = True
        btnGuardarLinea.Enabled = True
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Limpiar()
        nuevo()
        If dpFECHA_CONTABLE.Enabled = True Then            
            c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=4, @ITEM=" & item)
            dpFECHA_CONTABLE.Value = Date.Now
        End If
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
            Try
                Me.Txt_Producto_descripcion.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA1.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 1)
                Me.txt_Unidades.Text = c_data1.leerDataeader("EXECUTE INVENTARIO_BUSCAR_PRODUCTO_POR_CODIGO @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cmbBODEGA1.SelectedValue & ", @PRODUCTO=" & Me.Txt_Producto_codigo.Text & ", @BANDERA=1", 2)
                Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
                Label19.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13 , @BANDERA='S1'", 0)

                Label22.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)

                Me.Txt_Producto_cantidad.Focus()
            Catch ex As Exception
                Txt_Producto_codigo.Text = ""
                MsgBox("El codigo es numerico", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub btnProcesarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarPartida.Click
        If MsgBox("Está seguro de procesar el movimiento?", MsgBoxStyle.YesNo, "PROCESAR") = MsgBoxResult.Yes Then
            If dgvMovtos.RowCount > 0 Then
                Dim COSTO_PROM As String = 0
                Dim cantidad As String = 0
                Dim Costo_Total As Double = 0
                Dim Costo_Total_doc As Double = 0

                For i As Integer = 1 To dgvMovtos.RowCount

                    COSTO_PROM = c_data1.leerDataeader("SELECT DBO.INVENTARIOS_CALCULAR_COSTOS(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & dgvMovtos.Rows(i - 1).Cells(3).Value.ToString() & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "')", 0)
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
                Button1.Enabled = False
                btnGuardarLinea.Enabled = False
                Txt_tipo_movimiento_numero.Enabled = False
                'SE DETERMINA EL NUMERO DE TRANSACCION
                'Dim Transaccion As Integer = c_data1.leerDataeader("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & dpFECHA_CONTABLE.Value.Year & ", @MES = " & dpFECHA_CONTABLE.Value.Month & ", @ULTIMO = 0", 0)
                ''SE DETERMINA EL LIBRO
                'Dim Libro As Integer = c_data1.leerDataeader("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1", 0)
                ''SE DETERMINA EL CENTRO DE COSTO
                'Dim CentCosto As Integer = c_data1.leerDataeader("SELECT CENTRO_COSTO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA1.SelectedValue, 0)
                ''SE DETERMINA LA CUENTA ABONAR
                'Dim CtaAbonada As Integer = c_data1.leerDataeader("SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA2.SelectedValue, 0)
                ''SE DETERMINA LA CUENTA A CARGAR
                'Dim CtaCargada As Integer = c_data1.leerDataeader("SELECT CUENTA_CONTABLE_INVENTARIO FROM INVENTARIOS_CATALOGO_BODEGAS WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA1.SelectedValue, 0)

                'If CtaAbonada = 0 Or CtaCargada = 0 Then
                '    MsgBox("NO SE CREARA PARTIDA, FALTA DEFINIR CUENTA PARA UNA DE LAS BODEGAS!!!", MsgBoxStyle.Information)
                'Else
                '    '**************************************************************************************************************************
                '    Procesos_Contables.EncabezadoPartida(Transaccion, 2, 34, 0, dpFECHA_CONTABLE.Value, Libro, "Partidad de Transferencia de Inventario entre " & cmbBODEGA1.SelectedText & " y " & cmbBODEGA2.SelectedText, 0, 0, "I")
                '    Procesos_Contables.DetallePartida(Transaccion, 0, CentCosto, dpFECHA_CONTABLE.Value, Libro, "Transferencia de Inventario", CtaCargada, "C", txtDIFERENCIA.Text, 0, "I")
                '    Procesos_Contables.DetallePartida(Transaccion, 0, CentCosto, dpFECHA_CONTABLE.Value, Libro, "Transferencia de Inventario", CtaAbonada, "A", 0, txtDIFERENCIA.Text, "I")
                '    'SE PROCESA LA PARTIDA
                '    Dim sqlCmd As New SqlCommand("EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPAÑIA = " & Compañia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'")
                '    c_data1.ejecutarComandoSql(sqlCmd)
                '    '**************************************************************************************************************************
                'End If

                Dim Tabla As DataTable
                Dim sqlCmd1 As New SqlCommand
                Dim rptver As New frmReportes_Ver
                If dpFECHA_CONTABLE.Enabled = True Then

                    c_data1.Ejecutar_ConsultaSQL("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=4, @ITEM=" & item)

                End If
                Dim reporte_30 As New Inventario_Reporte_Transferencias
                sqlCmd1.CommandText = "EXECUTE sp_INVENTARIOS_REPORTE_TRANSFERENCIAS @COMPAÑIA=" & Compañia & ",@BODEGA1=" & Me.cmbBODEGA1.SelectedValue & ",@BODEGA2=" & Me.cmbBODEGA2.SelectedValue & ",@TIPO_MOVIMIENTO=" & "4" & ",@ENTRADA_SALIDA =" & "0" & ",@FECHA1='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01") & "', @DOCTO='" & Me.numeroSalida.Text & "'"
                Tabla = c_data1.obtenerDatos(sqlCmd1)
                reporte_30.SetDataSource(Tabla)
                rptver.ReportesGenericos(reporte_30)
                rptver.ShowDialog()
                dpFECHA_CONTABLE.Value = Date.Now

            Else
                MsgBox("No existen recetas a transferir. Verificar.", MsgBoxStyle.Exclamation)
            End If
        End If
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

    Private Sub Txt_tipo_movimiento_numero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_tipo_movimiento_numero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Btn_Buscar_Movimiento.PerformClick()
        End If
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        EliminarDetalle("DD", cmbBODEGA1.SelectedValue, 4, numeroSalida.Text, False)
        EliminarDetalle("DD", cmbBODEGA2.SelectedValue, 1, numeroEntrada.Text, True)
        CargarGrid("EXECUTE sp_INVENTARIOS_MOVIMIENTOS_TRANSFERENCIA_IUD @COMPAÑIA=" & Compañia & ",@BODEGA_INICIAL=" & Me.cmbBODEGA1.SelectedValue & ", @BODEGA_FINAL=" & Me.cmbBODEGA2.SelectedValue & ", @MOVIMIENTO=" & Txt_tipo_movimiento_numero.Text & ", @FECHA_MOV='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @ANULADO= 0, @PROCESADO=0, @USUARIO=" & Usuario & ", @BANDERA=2, @NUMERO_SALIDA=" & numeroSalida.Text & ", @NUMERO_ENTRADA=" & numeroEntrada.Text)
        Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
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
    Public Sub Calcular_Procesadas()
        Dim si_ As String = 0, no_ As String = 0
        If (cmbBODEGA1.SelectedValue = 19) Or (cmbBODEGA1.SelectedValue = 31) Then
            For i As Integer = 0 To DgvProductos.RowCount - 1
                If DgvProductos.Rows(i).Cells(5).Value.ToString() = "Si" Then
                    si_ = si_ + 1
                Else
                    no_ = no_ + 1
                End If
            Next
        End If
        Label20.Text = si_
        Label21.Text = no_
    End Sub
    Private Sub cmbTiempo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiempo.SelectedIndexChanged
        If Iniciando = False Then
            'CargarRecetas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
            MantenimientoProgramacion(Compañia, Me.cmbBODEGA1.SelectedValue, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "C")
            Calcular_Procesadas()
        End If
    End Sub
    Sub MantenimientoProgramacion(ByVal Compañia, ByVal Bodega, ByVal Fecha, ByVal Tiempo, ByVal Codigo, ByVal Cantidad, ByVal IUD)
        Try
            DS02.Reset()
            Sql = "Execute sp_CAFETERIA_CATALOGO_PROGRAMACION_SEMANAL_IUD "
            Sql &= Compañia
            Sql &= ", " & Bodega
            Sql &= ", " & Tiempo
            Sql &= ", '" & Fecha & "'"
            Sql &= ", " & Codigo
            Sql &= ", " & Cantidad
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            c_data1.MiddleConnection(SQL)
            c_data1.DataAdapter.Fill(DS02)
            If IUD = "S" Or IUD = "C" Then
                Me.DgvProductos.DataSource = DS02.Tables(0)
                'Me.DgvProductos.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                'For i As Integer = 1 To Me.DgvProductos.ColumnCount
                '    Me.DgvProductos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                'Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    

    Private Sub DgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvProductos.CellContentClick
        Txt_Producto_codigo.Text = DgvProductos.CurrentRow.Cells(0).Value.ToString()
        Txt_Producto_descripcion.Text = DgvProductos.CurrentRow.Cells(1).Value.ToString()
        txt_Unidades.Text = DgvProductos.CurrentRow.Cells(3).Value.ToString()
        Me.Txt_Existencias.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA1.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)
        Me.Txt_Existencias2.Text = c_data1.leerDataeader("SELECT DBO.calcular_existencia_actual(" & Compañia & "," & Me.cmbBODEGA2.SelectedValue & "," & Me.Txt_Producto_codigo.Text & ",'" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "')", 0)

        Label19.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA1.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)

        Label22.Text = c_data1.leerDataeader("Execute sp_CAFETERIA_PRECIO_ESTANDAR @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA2.SelectedValue & ",@PRODUCTO=" & Me.Txt_Producto_codigo.Text & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "', @IVA=13, @BANDERA='S1'", 0)

        Txt_Producto_cantidad.Focus()
    End Sub

    Private Sub dpFECHA_CONTABLE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFECHA_CONTABLE.ValueChanged
        If Iniciando = False Then
            'CargarRecetas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
            MantenimientoProgramacion(Compañia, Me.cmbBODEGA1.SelectedValue, Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy 00:00:01"), Me.cmbTiempo.SelectedValue, 0, 0, "C")
            Calcular_Procesadas()

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
        End If
    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If Iniciando = False Then
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 1
            Dim Ncolumn As String = DgvProductos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case DgvProductos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select

            'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = DS02.Tables(0).Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            If TextBox5.Text = "" Then
                Me.DgvProductos.DataSource = DS02.Tables(0)
            Else
                rows = DS02.Tables(0).Select("[" & DgvProductos.Columns(columna).Name & "] like '" & TextBox5.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                For i As Integer = 0 To rows.Length - 1
                    tablaT.ImportRow(rows(i))
                Next

                Me.DgvProductos.DataSource = tablaT
            End If
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.txtFecheo.Text = "" Then
            Dim fecheo As New Seguridad_Pos_Ante_Fecheo(cmbBODEGA2.Text, Me.cmbBODEGA2.SelectedValue, "Inventario_Traslados_DA")
            fecheo.ShowDialog()
        Else

            clave = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=3", 0)
            item = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=3", 1)
            pos_ante = c_data1.leerDataeader("EXEC sp_INVENTARIOS_POS_ANTE_FECHEO @COMPAÑIA=" & Compañia & ",@BODEGA=" & Me.cmbBODEGA2.SelectedValue & ",@USUARIO=" & Usuario & ",@FECHA='" & Format(Me.dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@NOMBRE_VENTANA='Inventario_Traslados_DA', @BANDERA=3", 2)
            
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If txt_Contraseña_Mov.Text = "16/04/2014-Abr-Acosta" Then
            Txt_tipo_movimiento_numero.Enabled = True
        Else
            Txt_tipo_movimiento_numero.Enabled = False
        End If
    End Sub
End Class
