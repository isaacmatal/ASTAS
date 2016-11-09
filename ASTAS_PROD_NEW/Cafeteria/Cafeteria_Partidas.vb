Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Partidas
    Dim c_data1 As New jarsClass, sql As String
    Dim Iniciando As Boolean, Iniciando2 As Boolean, Item As String
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim DataReader_ As SqlDataReader
    Dim Table As DataTable
    Dim DS01 As New DataSet()    
    Private Sub Cafeteria_Partidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True        
        Me.txtCompañia.Text = Descripcion_Compañia
        cargarBodegas()
        cargarCajas()
        CargaLibrosContables(Compañia)
        CargaTipoDocumento(Compañia)
        CargaTipoPartida(Compañia)
        CargaCentroCosto(Compañia)
        Iniciando = False
        proponerTransaccion()
        proponerPartida()
    End Sub
    Public Sub proponerTransaccion()
        If Iniciando = False Then
            txtTRANSACCION.Text = c_data1.leerDataeader("EXECUTE sp_CAFETERIA_GENERAR_PARTIDAS @COMPAÑIA=" & Compañia & ", @BANDERA=2", 0)
        End If        
    End Sub
    Public Sub proponerPartida()
        If Iniciando = False Then
            txtPARTIDA.Text = c_data1.leerDataeader("EXECUTE sp_CAFETERIA_GENERAR_PARTIDAS @COMPAÑIA=" & Compañia & ",@TIPO_PARTIDA=" & cmbTIPO_PARTIDA.SelectedValue & ",@BANDERA=3", 0)
        End If        
    End Sub
    Sub CargarGrid(ByVal SIUD As Integer)
        Try
            sql = "EXECUTE sp_CAFETERIA_GENERAR_PARTIDAS "
            sql &= "@COMPAÑIA=" & Compañia
            sql &= ",@BODEGA=" & cbCafeteria.SelectedValue
            sql &= ",@CAJA=" & cmbCajas.SelectedValue
            sql &= ",@FECHA_INICIAL='" & Format(dpFECHA_FACTURACION.Value, "dd-MM-yyyy") & "'"
            sql &= ",@FECHA_FINAL='" & Format(dpFECHA_FACTURACION.Value, "dd-MM-yyyy") & "'"
            sql &= ",@BANDERA=" & SIUD
            Table = c_data1.obtenerDatos(New SqlCommand(sql))
            Me.dgvMovtos.DataSource = Table

            ''justificar derecha
            'Me.dgvMovtos.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            'Me.dgvMovtos.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            'Me.dgvMovtos.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            For i As Integer = 0 To dgvMovtos.ColumnCount - 1
                dgvMovtos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: " & Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub cargarBodegas()
        Iniciando2 = True
        c_data1.CargaBodegas(Compañia, Me.cbCafeteria, 9)
        Iniciando2 = False
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data1.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4, @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data1.CargarCombo(Me.cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
        End If
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If ((Iniciando = False) And (Iniciando2 = False)) Then
            cargarCajas()
        End If
    End Sub
    'SE RETOMO CODIGO DE FASE 1
    Private Sub Conectar()
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
    End Sub
    Private Sub CargaLibrosContables(ByVal Compañia As Integer)
        Conectar()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaTipoDocumento(ByVal Compañia As Integer)
        Conectar()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO "
            sql &= Compañia
            sql &= ", 3"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_DOCUMENTO.DataSource = Table
            Me.cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaTipoPartida(ByVal Compañia As Integer)
        Conectar()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PARTIDA "
            sql &= Compañia
            sql &= ", 0"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_PARTIDA.DataSource = Table
            Me.cmbTIPO_PARTIDA.ValueMember = "TIPO_PARTIDA"
            Me.cmbTIPO_PARTIDA.DisplayMember = "DESCRIPCION_TIPO_PARTIDA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'LIMPIA EL DATAGRIDVIEW
        dgvMovtos.DataSource = Nothing
        CargarGrid(0)
        Me.txtCONCEPTO.Text = "VENTAS CON TICKETS EN " & Me.cbCafeteria.Text.Trim() & " - " & Me.cmbCajas.Text.Trim() & " DEL " & Me.dpFECHA_FACTURACION.Value.ToShortDateString()
        txtCARGOS.Text = Format(Table.Compute("Sum(MONTO)", ""), "0.00")
        txtABONOS.Text = txtCARGOS.Text
        txtDIFERENCIA.Text = Format((Math.Abs(Math.Round(Val(txtCARGOS.Text)) - Math.Round(Val(txtABONOS.Text)))), "0.00")
    End Sub
    Private Sub CargaCentroCosto(ByVal Compañia)
        Conectar()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO "
            sql &= Compañia
            sql &= ", 3"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCENTRO_COSTO.DataSource = Table
            Me.cmbCENTRO_COSTO.ValueMember = "Centro Costo"
            Me.cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbCOMPAÑIA.Enabled = False
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Cuentas.BuscaTodas = False
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Numero = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.lblCuenta.Text = Producto
            Me.txtCUENTA_COMPLETA.Text = Tipo
            If Numero = "1" Then
                Me.cmbTIPO_PARTIDA.SelectedValue = Numero
            End If
        End If
    End Sub

    Private Sub Cierre_Apertura_Grid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMovtos.Click
        Try
            txtCUENTA_COMPLETA.Text = dgvMovtos.CurrentRow.Cells(0).Value.ToString()
            txtCONCEPTO_L.Text = dgvMovtos.CurrentRow.Cells(1).Value.ToString()
            txtMONTO.Text = dgvMovtos.CurrentRow.Cells(2).Value.ToString()
            If dgvMovtos.CurrentRow.Cells(3).Value.ToString() = "CARGO" Then
                cmbCARGO_ABONO.SelectedIndex = 0
            End If
            If dgvMovtos.CurrentRow.Cells(3).Value.ToString() = "ABONO" Then
                cmbCARGO_ABONO.SelectedIndex = 1
            End If
            Item = dgvMovtos.CurrentRow.Cells(4).Value.ToString()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        MsgBox("NO SE FINALIZO ESTE FORMULARIO")
        '    If MsgBox("Esta seguro de querer procesar?", MsgBoxStyle.YesNo, "PROCESAR") = MsgBoxResult.Yes Then
        '        If (dgvMovtos.RowCount > 0) Then
        '            Dim TIP As String = "", CARGO As String = "", ABONO As String = ""
        '            If Val(txtDIFERENCIA.Text) <> 0 Then
        '                MsgBox("Aviso...La partida no esta cuadrada, no se puede procesar!", MsgBoxStyle.Information)
        '            Else
        '                If (txtDOCUMENTO.Text = "") Then
        '                    txtDOCUMENTO.Text = "."
        '                End If

        '                Dim existe As String = ""
        '                For i As Integer = 0 To dgvMovtos.RowCount - 1
        '                    If dgvMovtos.CurrentRow.Cells(0).Value.ToString() = "0" Then
        '                        MsgBox("Aviso...Debe Ingresar todas las cuentas respectivas!", MsgBoxStyle.Information)
        '                        Exit Sub
        '                    End If
        '                Next
        '                'INGRESA EL DETALLE DE LA PARTIDA A LA TABLA DE CAFETERIA
        '                existe = c_data1.leerDataeader("EXECUTE sp_CAFETERIA_PARTIDAS_PROCESADAS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cmbCajas.SelectedValue & ",@FECHA='" & Format(dpFECHA_FACTURACION.Value, "dd-MM-yyyy") & "',@ESTADO=1,@USUARIO='" & Usuario & "',@BANDERA=0", 0)
        '                If existe = 1 Then
        '                    'SE GUARDA EL ENCANEZADO DE LA FACTURA
        '                    c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD @COMPAÑIA=" & Compañia & ", @TRANSACCION=" & IIf(txtTRANSACCION.Text = "", "0", txtTRANSACCION.Text) & ",@LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & ",@TIPO_DOCUMENTO=" & cmbTIPO_DOCUMENTO.SelectedValue & ",@DOCUMENTO='" & IIf(txtDOCUMENTO.Text = "", "0", txtDOCUMENTO.Text) & "',@TIPO_PARTIDA=" & cmbTIPO_PARTIDA.SelectedValue & ",@PARTIDA=" & IIf(txtPARTIDA.Text = "", "0", txtPARTIDA.Text) & ",@FECHA_CONTABLE='" & Format(dpFECHA_CONTABLE.Value, "dd-MM-yyyy hh:mm:ss") & "',@CONCEPTO='" & IIf(txtCONCEPTO.Text = "", " ", txtCONCEPTO.Text) & "',@ANULADA=0,@TRANSACCION_ANULA= 0,@USUARIO='" & Usuario & "',@IUD='I'")

        '                    'SE GUARDA EL DETALLE DE LA PARTIDA
        '                    For i As Integer = 0 To dgvMovtos.RowCount - 1
        '                        If dgvMovtos.Rows(i).Cells(3).Value.ToString() = "CARGO" Then
        '                            TIP = "C"
        '                            CARGO = dgvMovtos.Rows(i).Cells(2).Value.ToString()
        '                            ABONO = "0.0"
        '                        Else
        '                            TIP = "A"
        '                            ABONO = dgvMovtos.Rows(i).Cells(2).Value.ToString()
        '                            CARGO = "0.0"
        '                        End If
        '                        c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD @COMPAÑIA=" & Compañia & ",@LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & ",@TRANSACCION=" & txtTRANSACCION.Text & ", @LINEA=" & (i + 1).ToString() & ",@CENTRO_COSTO=" & cmbCENTRO_COSTO.SelectedValue & ",@CUENTA=" & dgvMovtos.Rows(i).Cells(5).Value.ToString() & ",@CONCEPTO='" & dgvMovtos.Rows(i).Cells(1).Value.ToString().Trim() & "',@CARGO_ABONO='" & TIP & "',@CARGO=" & CARGO & ",@ABONO=" & ABONO & ",@USUARIO='" & Usuario & "',@IUD = 'I'")
        '                    Next
        '                    Nuevo()
        '                    MsgBox("Aviso...La partida se ha procesado con éxito!", MsgBoxStyle.Information)
        '                Else
        '                    MsgBox("Aviso...La partida ya fue procesada!", MsgBoxStyle.Information)
        '                End If
        '            End If
        '        Else
        '            MsgBox("No hay datos que procesar", MsgBoxStyle.Exclamation)
        '        End If
        '    End If
        'End Sub
        'Public Sub Nuevo()
        '    'SE ELIMINA EL DETALLE DE LA TABLA TEMPORAL DE PARTIDAS DE CAFETERIA
        '    c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_PARTIDAS_TEMPORALES @BANDERA=2")
        '    'SE LIMPIA EL DATAGRIDVIEW
        '    dgvMovtos.DataSource = Nothing
        '    txtDOCUMENTO.Text = ""
        '    txtCONCEPTO.Text = ""
        '    proponerTransaccion()
        '    proponerPartida()
    End Sub

    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        If txtCUENTA_COMPLETA.Text = "" Or txtCUENTA_COMPLETA.Text = "0" Or txtCONCEPTO_L.Text = "" Then
            MsgBox("Aviso...Debe seleccionar un detalle y establecerle cuenta y concepto!", MsgBoxStyle.Information)
        Else
            c_data1.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_PARTIDAS_TEMPORALES @ITEM=" & Item & ",@CUENTA='" & txtCUENTA_COMPLETA.Text & "',@CONCEPTO='" & txtCONCEPTO_L.Text & "',@CODIGO=" & lblCuenta.Text & ",@BANDERA=1")
            CargarGrid(4)
            limpiar()
        End If
    End Sub
    Public Sub limpiar()
        txtCUENTA_COMPLETA.Text = ""
        txtCONCEPTO_L.Text = ""
        txtMONTO.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        limpiar()
        Me.txtABONOS.Text = "0.00"
        Me.txtCARGOS.Text = "0.00"
        Me.dgvMovtos.DataSource = Nothing
    End Sub
End Class