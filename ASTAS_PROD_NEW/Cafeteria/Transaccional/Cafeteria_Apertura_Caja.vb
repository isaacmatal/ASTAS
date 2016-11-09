Public Class Cafeteria_Apertura_Caja
    Dim c_data2 As New jarsClass
    Dim Iniciando As Boolean
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Iniciando2 As Boolean
    Dim bandera As Boolean = False

    'VARIABLES PARA EL REGISTRO DE CORTES - CODIGO AGREGADO
    Dim serie As String
    Dim correlativo_Actual As String
    Dim mensaje As String = ""
    'VARIABLES PARA LA IMPRESION DE CORTES Z Y ZZ AL MOMENTO DE GENERARSE
    Dim VentaBruta As Double = 0.0
    Dim Efectivo As Double = 0.0
    Dim Credito As Double = 0.0
    Dim Descuentos As Double = 0.0
    Dim bodega_ataf As Integer = 82

    Private Sub Cafeteria_Apertura_Caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True

        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompa�ia.Text = Descripcion_Compa�ia
        bodega_ataf = c_data2.leerDataeader("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE=29", 0)
        'LLENA EL COMBO DE BODEGAS
        c_data2.CargaBodegas(Compa�ia, Me.cbCafeteria, 9)
        'LLENA COMBO DE CAJAS DE CADA BODEGA
        cargarCajas()
        If Me.cbSeleccioneCaja.SelectedValue <> Nothing Then
            If cbCafeteria.SelectedValue = bodega_ataf Then
                c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'W'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                Label2.Text = "ASOCIACION DE TRABAJADORES DE AVICOLA SALVADORE�A Y FILIALES"
            Else
                c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'T'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
            End If
        End If        
        dtpFechaTrabajo.Value = c_data2.leerDataeader("Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA @IUD='H'", 0)
        CargarGrid(Compa�ia, 2)        
        Iniciando = False
    End Sub
    Sub CargarGrid(ByVal CIA, ByVal SIUD)
        Try
            DS01.Reset()
            cadenaSIUD(CIA, SIUD)
            c_data2.MiddleConnection(SQL)
            c_data2.DataAdapter.Fill(DS01)
            Me.Cierre_Apertura_Grid.DataSource = DS01.Tables(0)
            c_data2.cerrarConexion()

            Me.Cierre_Apertura_Grid.Columns.Item(0).Visible = False
            Me.Cierre_Apertura_Grid.Columns.Item(2).Visible = False

            For i As Integer = 0 To Cierre_Apertura_Grid.ColumnCount - 1
                Cierre_Apertura_Grid.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next

        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de cargar Datos", MsgBoxStyle.Information)

        Finally
            c_data2.cerrarConexion()
        End Try
    End Sub
    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD)
        Dim estado As Integer
        If (bandera = False) Then
            'cierre
            estado = 0
        Else
            'apertura
            estado = 1
        End If

        SQL = "Execute [dbo].[sp_CAFETERIA_APERTURA_CIERRE_IUD] "
        SQL &= "@COMPA�IA = " & CIA
        SQL &= ",@BODEGA = " & cbCafeteria.SelectedValue
        SQL &= ",@TIEMPO_COMIDA = " & cbTiempoComida.SelectedValue
        SQL &= ",@CAJA = " & cbSeleccioneCaja.SelectedValue
        SQL &= ",@FECHA = '" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "'"
        SQL &= ",@MONTO = " & Val(txtDineroInicial.Text)
        SQL &= ",@USUARIO = '" & Usuario & "'"
        SQL &= ",@ESTADO = " & estado
        SQL &= ",@BANDERA = " & SIUD
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("Esta seguro de abrir caja?", MsgBoxStyle.YesNo, "ABRIR CAJA") = MsgBoxResult.Yes Then
            Dim efec As String, verificar_otros As String
            Try
                bandera = True
                If (bandera = True) Then
                    'Verifica si existen tiempos abiertos
                    cadenaSIUD(Compa�ia, 4)
                    verificar_otros = c_data2.leerDataeader(SQL, 0)
                    If Val(verificar_otros) > 0 Then
                        MsgBox("TIENE OTROS TIEMPOS ABIERTOS, CIERRELOS Y CONTINUE", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Dim EstaCerrado As Integer = c_data2.obtenerEscalar(SQL)
                    Dim total As Integer

                    total = c_data2.obtenerEscalar("SELECT COUNT(*) FROM dbo.CAFETERIA_APERTURA_CIERRE_CAJA WHERE COMPA�IA=" & Compa�ia & " AND BODEGA=" & cbCafeteria.SelectedValue & " AND CONVERT(DATE,FECHA)=CONVERT(DATE,'" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "') AND TIEMPO_COMIDA=" & cbTiempoComida.SelectedValue & " AND CAJA=" & cbSeleccioneCaja.SelectedValue & " AND USUARIO_APERTURA='" & Usuario & "'")

                    If total > 0 Then
                        SQL = "SELECT ESTADO FROM dbo.CAFETERIA_APERTURA_CIERRE_CAJA WHERE COMPA�IA=" & Compa�ia & " AND BODEGA=" & cbCafeteria.SelectedValue & " AND CONVERT(DATE,FECHA)=CONVERT(DATE,'" & Format(dtpFechaTrabajo.Value, "yyyy-MM-dd") & "') AND TIEMPO_COMIDA=" & cbTiempoComida.SelectedValue & " AND CAJA=" & cbSeleccioneCaja.SelectedValue & " AND USUARIO_APERTURA='" & Usuario & "'"
                        EstaCerrado = c_data2.obtenerEscalar(SQL)
                    Else
                        EstaCerrado = 9
                    End If


                    Select Case EstaCerrado
                        Case 0
                            MsgBox("Ya existe Cierre de Caja.", MsgBoxStyle.Exclamation, "AVISO")
                        Case 1
                            MsgBox("Caja ya est� Abierta.", MsgBoxStyle.Exclamation, "AVISO")
                        Case 9
                            cadenaSIUD(Compa�ia, 1)
                            efec = c_data2.leerDataeader(SQL, 0)

                            If (efec = "1") Then
                                CargarGrid(Compa�ia, 2)
                                Tiempo_Comida = Me.cbTiempoComida.SelectedValue
                                Bodega_Global = cbCafeteria.SelectedValue
                                MsgBox("SE HA REALIZADO LA APERTURA DE CAJA CON EXITO!", MsgBoxStyle.Information)
                            Else
                                MsgBox("NO SE HA REALIZADO LA APERTURA DE CAJA! EXISTEN TIEMPO ABIERTOS!", MsgBoxStyle.Information)
                            End If
                    End Select

                End If
            Catch ex As Exception
                MsgBox("Aviso...Ocurrio un problema a la hora de hacer apertura!", MsgBoxStyle.Information)
            End Try
        End If
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPA�IA=" & Compa�ia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cbSeleccioneCaja.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data2.CargarCombo(Me.cbSeleccioneCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPA�IA=" & Compa�ia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=2, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")

        End If
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            Label6.Visible = False
            cargarCajas()
            If Me.cbSeleccioneCaja.SelectedValue <> Nothing Then
                If cbCafeteria.SelectedValue = bodega_ataf Then
                    c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'W'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                    Label2.Text = "ASOCIACION DE TRABAJADORES DE AVICOLA SALVADORE�A Y FILIALES"
                Else
                    c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'T'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                    Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
                End If
            End If            
            Iniciando2 = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'VALIDACIONES AL CIERRE DE CAJA
        If ValidarCampos() Then
            If MessageBox.Show("�Desea realizar el cierre de caja?", "Confirmaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Cierre_Apertura_Grid.RowCount <> 0 Then
                    Label6.Visible = False
                    'REALICE EL CIERRE DE LA CAJA RESPECTIVA
                    CierreDeCaja()
                    'ESTABLECE LA FECHA DE TRABAJO SEGUN SERVIDOR
                    dtpFechaTrabajo.Value = c_data2.leerDataeader("Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA @IUD='H'", 0)

                    If Me.cbSeleccioneCaja.SelectedValue <> Nothing Then
                        If cbCafeteria.SelectedValue = bodega_ataf Then
                            c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'W'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                            Label2.Text = "ASOCIACION DE TRABAJADORES DE AVICOLA SALVADORE�A Y FILIALES"
                        Else
                            c_data2.CargarCombo(Me.cbTiempoComida, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Compa�ia & ", " & "'T'," & Me.cbSeleccioneCaja.SelectedValue, "Tiempo de Comida", "Descripci�n")
                            Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
                        End If
                    End If

                Else
                    Label6.Visible = True
                End If
            End If
        End If
    End Sub

    'PARA EL PROCESO DE CIERRE ES NECESARIO REGISTRAR EN LA TABLA FACTURACION ENCABEZADO 
    'POR ELLO LA NECESIDAD DE OBTENER LA SERIE Y UN CORRELATIVO DEL TICKET
    Public Sub NumeroFactura()
        serie = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPA�IA=" & Compa�ia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & Me.cbSeleccioneCaja.SelectedValue & ",@BANDERA=1", 0)
        correlativo_Actual = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPA�IA=" & Compa�ia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & Me.cbSeleccioneCaja.SelectedValue & ",@BANDERA=1", 3)
    End Sub

    Private Sub CierreDeCaja()
        Try
            bandera = False
            If (bandera = False) Then
                cadenaSIUD(Compa�ia, 3)
                c_data2.Ejecutar_ConsultaSQL(SQL)

                CargarGrid(Compa�ia, 2)
                Tiempo_Comida = Me.cbTiempoComida.SelectedValue
                Bodega_Global = cbCafeteria.SelectedValue

                'REALIZAR EL CORTE RESPECTIVO - CODIGO AGREGADO

                'OBTENEMOS LA SERIE DE LA CAJA Y CORRELATIVO DEL TICKET
                'EJECUTAR ESTE METODO POR CADA VEZ QUE SE EJECUTE UN METODO DE CORTE
                NumeroFactura()

                mensaje = "Se han almacenado los cortes: "
                CorteX()

                If (cbTiempoComida.SelectedValue = 5) Then
                    'Corte Z
                    NumeroFactura()
                    CargarConsulta("28", 0, 0)
                    c_data2.Ejecutar_ConsultaSQL(SQL)
                    If Date.DaysInMonth(dtpFechaTrabajo.Value.Year, dtpFechaTrabajo.Value.Month) = dtpFechaTrabajo.Value.Day Then
                        'CORTE ZZ
                        NumeroFactura()
                        CargarConsulta("28", 0, 0)
                        c_data2.Ejecutar_ConsultaSQL(SQL)
                    End If
                End If

                MsgBox("SE HA REALIZADO EL CIERRE DE CAJA CON EXITO!", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de hacer apertura!", MsgBoxStyle.Information)
        End Try
    End Sub

    'CARGA LA CONSULTA QUE PERMITE INSERTAR EL CORTE EN LA TABLA CAFETERIA_FACTURACION_ENCABEZADO
    Private Sub CargarConsulta(ByVal TipoDocumento As String, ByVal Venta As Double, ByVal Descuento As Double)
        SQL = "Execute [dbo].[sp_CAFETERIA_ALMACENAMIENTO_CORTES_X_Z] "
        SQL &= "@COMPA�IA = " & Compa�ia
        SQL &= ",@BODEGA = " & cbCafeteria.SelectedValue
        SQL &= ",@SERIE = '" & IIf(serie = "", "NO ESTA DEFINIDO", serie) & "'"
        SQL &= ",@NUMERO_FACTURA = " & correlativo_Actual
        SQL &= ",@FECHA = N'" & Me.dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        SQL &= ",@TIEMPO = " & cbTiempoComida.SelectedValue
        SQL &= ",@CAJA = " & cbSeleccioneCaja.SelectedValue
        SQL &= ",@DESCUENTO=" & Math.Round(0, 2)
        SQL &= ",@MONTO=" & Math.Round(0, 2)
        SQL &= ",@TIPO_DOCUMENTO = " & TipoDocumento
        SQL &= ",@USUARIO_CREACION = '" & Usuario & "'"
        SQL &= ",@SERIECOMPLETA = '" & serie & "'"

    End Sub

    'DEVUELVE UN CONJUNTO DE RESULTADOS ENTRE ELLOS LA VENTA Y DESCUENTO
    'REALIZADOS EN UNA CAJA EN SU RESPECTIVO TIEMPO DE COMIDA Y FECHA
    'ESTOS DATOS DESPUES SE INSERTAN EN LA FACTURA O TICKET QUE SE GUARDARA COMO CORTE
    Private Function DevolverDataSet(ByVal TipoCorte As String) As DataTable
        Dim consulta As String = "EXEC sp_CAFETERIA_CORTE_CAJA_RPT @COMPA�IA=" & Compa�ia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cbSeleccioneCaja.SelectedValue & ",@FECHA= '" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"

        Select Case TipoCorte
            Case "X"
                consulta += ",@TIEMPO=" & cbTiempoComida.SelectedValue
                consulta += ",@TIPO_CORTE='X'"
            Case "Z"
                consulta += ",@TIPO_CORTE='Z'"
            Case "ZZ"
                consulta += ",@TIPO_CORTE='ZZ'"
        End Select
        Return c_data2.ObtenerDataSet(consulta).Tables(0)
    End Function

    'LLENA LOS VALORES DE LA VENTA Y DESCUENTO CORRESPONDIENTES A UN CORTE EN ESPECIFICO,
    'EL DATATABLE REPRESENTA EL CONJUNTO DE DATOS QUE CONTIENE UN REGISTRO AGRUPADO POR
    'TIEMPO DE COMIDA
    Private Sub CalcularVentaYDescuento(ByRef VentaBrutaRef As Double, ByRef DescuentoRef As Double, ByRef tbl As DataTable, ByVal IndiceVenta As Integer, ByVal IndiceDescuento As Integer)
        For i As Integer = 0 To tbl.Rows.Count - 1
            VentaBrutaRef += tbl.Rows(i).Item(IndiceVenta)
            DescuentoRef += tbl.Rows(i).Item(IndiceDescuento)
        Next
    End Sub

    'GUARDA EL CORTE X CON SUS RESPECTIVOS VALORES DE VENTA Y DESCUENTOS
    Private Sub CorteX()
        Dim tbl As DataTable = DevolverDataSet("X")
        Dim VentaBrutaRealizada As Double = 0.0
        Dim DescuentosRealizada As Double = 0.0
        If tbl IsNot Nothing Then
            CalcularVentaYDescuento(VentaBrutaRealizada, DescuentosRealizada, tbl, 1, 4)
        End If
        CargarConsulta("28", 0, 0)
        c_data2.Ejecutar_ConsultaSQL(SQL)
        mensaje = " X"
    End Sub

    'GUARDA EL CORTE Z CON SUS RESPECTIVOS VALORES DE VENTA Y DESCUENTOS DEL DIA
    Private Sub CorteZ()
        Dim tbl As DataTable = DevolverDataSet("Z")
        Dim VentaBrutaRealizada As Double = 0.0
        Dim DescuentosRealizada As Double = 0.0
        If tbl IsNot Nothing Then
            CalcularVentaYDescuento(VentaBrutaRealizada, DescuentosRealizada, tbl, 1, 4)
        End If
        CargarConsulta("29", VentaBruta, Descuentos)
        c_data2.Ejecutar_ConsultaSQL(SQL)
        mensaje = ", Z"
        'EL PARAMETRO INDICA QUE NO SE IMPRIMIRA EL CORTE ZZ, SINO QUE EL CORTE Z
        ImprimirTicket(False)
    End Sub

    'GUARDA EL CORTE ZZ CON SUS RESPECTIVOS VALORES DE VENTA Y DESCUENTOS DEL MES
    Private Sub CorteZZ()
        Dim tbl As DataTable = DevolverDataSet("ZZ")
        Dim VentaBrutaRealizada As Double = 0.0
        Dim DescuentosRealizados As Double = 0.0
        If tbl IsNot Nothing Then
            CalcularVentaYDescuento(VentaBrutaRealizada, DescuentosRealizados, tbl, 0, 1)
        End If
        CargarConsulta("30", VentaBruta, Descuentos)
        c_data2.Ejecutar_ConsultaSQL(SQL)
        mensaje = " y ZZ"
        'EL PARAMETRO INDICA QUE SE IMPRIMIRA EL CORTE ZZ, Y NO EL CORTE Z
        ImprimirTicket(True)
    End Sub

    Private Function ValidarCampos() As Boolean
        If cbCafeteria.SelectedIndex = -1 Then
            MsgBox("Favor seleccionar una cafeteria!", MsgBoxStyle.Critical)
            Return False
        End If
        If cbTiempoComida.SelectedIndex = -1 Then
            MsgBox("Favor seleccionar un Tiempo de Comida!", MsgBoxStyle.Critical)
            Return False
        End If
        If cbSeleccioneCaja.SelectedIndex = -1 Then
            MsgBox("Favor seleccionar una caja!", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    'DEVUELVE CIERTO O FALSO; DEPENDIENDO SI EL CORTE YA FUE REALIZADO O NO
    'CIERTO ==> NO REALIZADO
    'FALSO  ==> YA FUE HECHO EL CORTE ZZ
    Private Function ValidarCorteZZ() As Boolean

        Dim NoTicket As Integer = Convert.ToInt32(c_data2.obtenerEscalar("exec sp_CAFETERIA_OBTENER_TICKET_CORTE_ZZ @COMPA�IA=" & Compa�ia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cbSeleccioneCaja.SelectedValue & ",@TIEMPO=" & cbTiempoComida.SelectedValue & ",@FECHA='" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"))
        If NoTicket <= 0 Then
            Return True
        End If
        MsgBox("�El corte ZZ ya ha sido realizado anteriormente para esta caja!" & vbNewLine & "Favor verificar.", MsgBoxStyle.Critical)
        Return False
    End Function

    Private Sub Cierre_Apertura_Grid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cierre_Apertura_Grid.Click
        Try
            Me.dtpFechaTrabajo.Value = Cierre_Apertura_Grid.CurrentRow.Cells(5).Value
            Me.txtDineroInicial.Text = Cierre_Apertura_Grid.CurrentRow.Cells(6).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbSeleccioneCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeleccioneCaja.SelectedIndexChanged
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            Try
                Label6.Visible = False
                CargarGrid(Compa�ia, 2)
            Catch ex As Exception
                MsgBox("Aviso...No hay registros que mostrar!", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub cbTiempoComida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTiempoComida.SelectedIndexChanged
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            Try
                Label6.Visible = False
                CargarGrid(Compa�ia, 2)
                If (cbTiempoComida.SelectedValue = 5) Then
                    rbCorteZZ.Enabled = True
                Else
                    rbCorteZZ.Enabled = False
                End If
            Catch ex As Exception
                MsgBox("Aviso...No hay registros que mostrar!", MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub txtDineroInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDineroInicial.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(13))) Then
            e.Handled = False
        Else
            If ((e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
                If txtDineroInicial.Text.Equals(String.Empty) Then
                    e.Handled = True
                    txtDineroInicial.Text = ""
                Else
                    e.Handled = txtDineroInicial.Text.Contains(".")
                End If
            Else
                e.Handled = True
                txtDineroInicial.Text = ""
            End If
        End If

    End Sub

#Region "IMPRESION DE LOS CORTES Z Y ZZ AL MOMENTO DE GENERARSE"
    Private Sub ImprimirTicket(ByVal ImprimirCorteZZ As Boolean)
        'CARGAR DATOS DEL CORTE
        Dim ds As New DataSet
        ds = DevolverDataSet(ImprimirCorteZZ)

        'ACCEDER A LAS DOS DATATABLE
        Dim tbl As New DataTable
        tbl = ds.Tables(0)

        Dim tbl2 As New DataTable
        tbl2 = ds.Tables(1)

        'PREPARAMOS VARIABLES
        VentaBruta = 0.0
        Efectivo = 0.0
        Credito = 0.0
        Descuentos = 0.0

        'GENERAMOS EL TICKET
        Dim ticket As New GenerarTicket
        ticket.AbrirArchivo()

        'DIRECCION CAJA
        ticket.EscribirTicket(" " & tbl2.Rows(0).Item(3).ToString().Trim())
        ticket.EscribirTicket(" " & tbl2.Rows(0).Item(4).ToString().Trim())
        ticket.EscribirTicket(" " & tbl2.Rows(0).Item(5).ToString().Trim())

        If Not ImprimirCorteZZ Then
            ImpresionCorteZ(ticket, tbl, tbl2)
            Return
        End If

        'CONTINUAMOS IMPRIMIENDO EL CORTE ZZ
        ticket.EscribirTicket("=============== CORTE ZZ ==============")
        'TODO
        Dim FechaTemporal As Date = "01/" & dtpFechaTrabajo.Value.Month.ToString() + "/" + dtpFechaTrabajo.Value.Year.ToString()
        ticket.EscribirTicket(" DEL  " & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "  AL  " & FechaTemporal.AddMonths(1).AddHours(-1).ToString("dd/MM/yyyy") & " " & Date.Now.ToShortTimeString)

        ticket.EscribirTicket("=============== RESUMEN ===============")
        ticket.EscribirTicket(" TOTAL VENTAS EXENTAS             0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS NO SUJETAS          0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS GRAVADAS " & FormatNumber(tbl.Rows(0).Item(0), 2).PadLeft(15))
        ticket.EscribirTicket(" TOTAL VENTAS " & FormatNumber(tbl.Rows(0).Item(0), 2).PadLeft(24))
        ticket.EscribirTicket(" TICKET INICIAL " & tbl.Rows(0).Item(2).ToString().Trim().PadLeft(22))
        ticket.EscribirTicket(" TICKET FINAL " & tbl.Rows(0).Item(3).ToString().Trim().PadLeft(24))
        ticket.EscribirTicket("============= DEVOLUCIONES ============")
        ticket.EscribirTicket(" TOTAL VENTAS EXENTAS             0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS NO SUJETAS          0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS GRAVADAS (-)" & FormatNumber(tbl.Rows(0).Item(1), 2).PadLeft(14))
        ticket.EscribirTicket(" TOTAL DEVOLUCIONES (-)" & FormatNumber(tbl.Rows(0).Item(1), 2).PadLeft(17))
        ticket.EscribirTicket("================ TOTAL ================")
        ticket.EscribirTicket(" TOTAL VENTAS EXENTAS             0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS NO SUJETAS          0.00 ")
        ticket.EscribirTicket(" TOTAL VENTAS GRAVADAS " & FormatNumber(tbl.Rows(0).Item(0), 2).PadLeft(15))
        ticket.EscribirTicket(" TOTAL DEVOLUCIONES " & FormatNumber(tbl.Rows(0).Item(1), 2).PadLeft(18))
        Dim VentaTotal As Double = tbl.Rows(0).Item(0) - tbl.Rows(0).Item(1)
        ticket.EscribirTicket(" VENTA TOTAL " & FormatNumber(VentaTotal, 2).PadLeft(25))
        ticket.CerrarArchivo(tbl.Rows(0).Item(3).ToString().Trim().PadLeft(24), "CC")
        MsgBox("Corte ZZ impreso exitosamente", MsgBoxStyle.Information, "Impresi�n de Cortes")
    End Sub

    Private Sub ImpresionCorteZ(ByVal ticket As GenerarTicket, ByVal tbl As DataTable, ByVal tbl2 As DataTable)
        'TODO
        'ticket.EscribirTicket("=============== CORTE Z ===============")
        ticket.EscribirTicket("======== Corte Parcial Z Diario ========")
        ticket.EscribirTicket(" FECHA: " & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & " " & Date.Now.ToShortTimeString)

        ticket.EscribirTicket(" " & tbl2.Rows(0).Item(0)) 'DESCRIPCION DE LA CAFETERIA
        ticket.EscribirTicket(" CAJA No. " & tbl2.Rows(0).Item(1)) 'CODIGO DE CAJA
        ticket.EscribirTicket(" TICKET # " & tbl2.Rows(0).Item(2)) 'NUMERO DE TICKET

        For i As Integer = 0 To tbl.Rows.Count - 1
            ticket.EscribirTicket("=======================================")
            Dim tiempo As String = tbl.Rows(i).Item(0)
            Dim diferencia As Integer = (39 - tiempo.Length) / 2
            If diferencia > 1 Then
                ticket.EscribirTicket("" & tbl.Rows(i).Item(0).ToString().PadLeft(diferencia + tiempo.Length)) 'TIEMPO COMIDA
            Else
                ticket.EscribirTicket("" & tbl.Rows(i).Item(0)) 'TIEMPO COMIDA
            End If
            ticket.EscribirTicket("" & tbl.Rows(i).Item(0)) 'TIEMPO COMIDA
            ticket.EscribirTicket("VENTA BRUTA " & FormatNumber(tbl.Rows(i).Item(1), 2).PadLeft(27)) 'VENTA BRUTA
            ticket.EscribirTicket("EFECTIVO " & FormatNumber(tbl.Rows(i).Item(2), 2).PadLeft(30)) 'EFECTIVO
            ticket.EscribirTicket("CREDITO " & FormatNumber(tbl.Rows(i).Item(3), 2).PadLeft(31)) 'CREDITO
            ticket.EscribirTicket("DESCUENTO " & FormatNumber(tbl.Rows(i).Item(4), 2).PadLeft(29)) 'DESCUENTO
            ticket.EscribirTicket("TOTAL DEPOSITAR " & FormatNumber(tbl.Rows(i).Item(2), 2).PadLeft(23)) 'TOTAL DEPOSITAR
            ticket.EscribirTicket("TICKET INICIAL " & tbl.Rows(i).Item(6).ToString().Trim().PadLeft(24))
            ticket.EscribirTicket("TICKET FINAL " & tbl.Rows(i).Item(7).ToString().Trim().PadLeft(26))
            ticket.EscribirTicket("CANTIDAD EMPLEADOS " & tbl.Rows(i).Item(5).ToString().PadLeft(20))
            ticket.EscribirTicket("VENTA PROMEDIO " & FormatNumber((tbl.Rows(i).Item(1) / tbl.Rows(i).Item(5)), 0, TriState.False).PadLeft(24)) 'VENTA PROMEDIO

            ''TOTALES
            'ticket.EscribirTicket(" ")
            'ticket.EscribirTicket("=============== TOTALES ===============")
            'ticket.EscribirTicket("VENTA BRUTA " & FormatNumber(tbl.Rows(i).Item(1), 2)) 'VENTA BRUTA
            'ticket.EscribirTicket("EFECTIVO " & FormatNumber(tbl.Rows(i).Item(2), 2)) 'EFECTIVO
            'ticket.EscribirTicket("CREDITO " & FormatNumber(tbl.Rows(i).Item(3), 2)) 'CREDITO
            'ticket.EscribirTicket("DESCUENTO " & FormatNumber(tbl.Rows(i).Item(4), 2)) 'DESCUENTO
            'ticket.EscribirTicket("TOTAL DEPOSITAR " & FormatNumber(tbl.Rows(i).Item(2), 2)) 'TOTAL DEPOSITAR

            VentaBruta += tbl.Rows(i).Item(1)
            Efectivo += tbl.Rows(i).Item(2)
            Credito += tbl.Rows(i).Item(3)
            Descuentos += tbl.Rows(i).Item(4)
        Next
        'RESUMEN
        ticket.EscribirTicket("=============== RESUMEN ===============")
        ticket.EscribirTicket("VENTA BRUTA " & FormatNumber(VentaBruta, 2).PadLeft(27)) 'VENTA BRUTA
        ticket.EscribirTicket("EFECTIVO " & FormatNumber(Efectivo, 2).PadLeft(30)) 'EFECTIVO
        ticket.EscribirTicket("CREDITO " & FormatNumber(Credito, 2).PadLeft(31)) 'CREDITO
        ticket.EscribirTicket("DESCUENTO " & FormatNumber(Descuentos, 2).PadLeft(29)) 'DESCUENTO
        ticket.EscribirTicket("TOTAL DEPOSITAR " & FormatNumber(Efectivo, 2).PadLeft(23)) 'TOTAL DEPOSITAR

        ticket.CerrarArchivo2()
        MsgBox("Corte Z impreso exitosamente", MsgBoxStyle.Information, "Impresi�n de Cortes")
    End Sub

    Private Function DevolverDataSet(ByVal ImprimirCorteZZ As Boolean) As DataSet
        Dim sql As String = "EXEC sp_CAFETERIA_CORTE_CAJA_RPT @COMPA�IA=" & Compa�ia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cbSeleccioneCaja.SelectedValue & ",@FECHA= '" & dtpFechaTrabajo.Value.ToString("dd/MM/yyyy") & "'"
        If ImprimirCorteZZ Then
            sql += ",@TIPO_CORTE='ZZ'"
        Else
            sql += ",@TIPO_CORTE='Z'"
        End If
        Return c_data2.ObtenerDataSet(sql)
    End Function
#End Region



    Private Sub GroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtFecheo.Text = "Admin" Then
            dtpFechaTrabajo.Enabled = True
            txtFecheo.Text = ""
        End If
    End Sub
End Class