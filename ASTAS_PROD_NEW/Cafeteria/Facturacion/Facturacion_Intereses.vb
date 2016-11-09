Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Facturacion_Intereses
    Dim c_data2 As New jarsClass
    Dim DATA01 As New DataTable
    Dim Iniciando2 As Boolean
    Dim CajaAbierta As Boolean = False
    'VARIABLES PARA EL REGISTRO DE CORTES - CODIGO AGREGADO
    Dim serie As String
    Dim correlativo_Actual As String
    Dim codigo_as As String, codigo_buxi As String
    Dim Movimiento As String
    Dim listaEmpl As New List(Of String)
    Dim Table As DataTable
    Dim Table2 As DataTable
    Dim Table3 As DataTable
    Dim bodega, caja As Integer
    Dim fechaProc As Date
    Dim reporte As New Cafeteria_Reporte_Intereses

    Private Sub Facturacion_Intereses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        'LLENA EL COMBO DE BODEGAS
        c_data2.CargaBodegas(Compañia, Me.cbCafeteria, 9)
        'LLENA COMBO DE CAJAS DE CADA BODEGA
        cargarCajas()
        Me.rbQna1.Checked = True
        Iniciando = False
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cbCaja.DataSource = Nothing
            'MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data2.CargarCombo(Me.cbCaja, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & Me.cbCafeteria.SelectedValue & ",@BANDERA=2, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
            serie = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cbCaja.SelectedValue & ",@BANDERA=1", 0)
            correlativo_Actual = c_data2.leerDataeader("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & cbCafeteria.SelectedValue & ",@CAJA=" & cbCaja.SelectedValue & ",@BANDERA=1", 3)

        End If
    End Sub

    Private Sub btnCargaMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargaMan.Click
        'Instanciamos nuestro cuadro de dialogo
        Dim openFileDialog1 As New OpenFileDialog
        'Directorio Predeterminado
        openFileDialog1.InitialDirectory = openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'Filtramos solo archivos con extension *.xls, *.xlsx
        openFileDialog1.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos de Excel 97-2003|*.xls"
        Dim response As Windows.Forms.DialogResult
        response = openFileDialog1.ShowDialog()
        'Si se presiona abrir entonces...
        If response = Windows.Forms.DialogResult.OK Then
            'Asignamos la ruta donde se almacena el fichero excel que se va a importar
            txtRutaMan.Text = openFileDialog1.FileName

            'Instanciamos nuestra cadena de conexion especial para excel,indicando la ruta del fichero
            'Dim cadconex As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.txtRutaMan.Text.Trim & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
            Dim cadconex As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & Me.txtRutaMan.Text & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
            Dim cn As New OleDb.OleDbConnection(cadconex)
            Dim cmd As New OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            cmd.Connection = cn
            'Consultamos la hoja llamada Clientes de nuestro archivo *.xls
            If txtRutaMan.Text = "" Then
                MsgBox("DEBE ESTABLECER EL NOMBRE DE LA HOJA DE SU LIBRO DE EXCEL")
                Exit Sub
            End If
            Try
                cmd.CommandText = "SELECT BUXIS, COD_AS, DEDUCCION, FECHA, MONTO FROM [" & txtHojaMan.Text & "$]"
                cmd.CommandType = CommandType.Text

                da.SelectCommand = cmd
                'Llenamos el datatable
                da.Fill(dt)
                'Llenamos el Datagridview
                Me.dgvDatosManuales.DataSource = dt
                'Ajustamos las columnas del DataGridView
                dgvDatosManuales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                dgvDatosManuales.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDatosManuales.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDatosManuales.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDatosManuales.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDatosManuales.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvDatosManuales.Columns(4).DefaultCellStyle.Format = "0.00"
                txtTotalMan.Text = Format(Val(dt.Compute("SUM(MONTO)", "MONTO > 0")), "#,##0.00")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf response = Windows.Forms.DialogResult.Cancel Then
            MsgBox("PROCESO CANCELADO POR USUARIO")
        End If
    End Sub

    Private Sub cargaDatosAutomaticos()
        dgvAutomaticos.DataSource = DATA01
        txtTotalAuto.Text = Format(Val(DATA01.Compute("SUM(TOTAL)", "TOTAL > 0")), "#,##0.00")
        dgvAutomaticos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvAutomaticos.Columns(0).HeaderText = "COD.EMPL."
        dgvAutomaticos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAutomaticos.Columns(1).HeaderText = "NOMBRE COMPLETO"
        dgvAutomaticos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvAutomaticos.Columns(2).HeaderText = "FECHA DESC."
        dgvAutomaticos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvAutomaticos.Columns(3).DefaultCellStyle.Format = "0.00"
        dgvAutomaticos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvAutomaticos.Columns(4).HeaderText = "TICKET#"
        dgvAutomaticos.Columns(5).Visible = False
    End Sub

    Private Sub btnNvoMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNvoMan.Click
        Me.dgvDatosManuales.DataSource = Nothing
    End Sub

    Private Sub dgvAutomaticos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAutomaticos.CellEnter
        Dim sql As String
        Dim tblDetalle As DataTable
        If e.RowIndex >= 0 Then
            Try
                sql = "EXECUTE sp_PLANILLA_INTERESES @FECHA='" & Format(Me.dgvAutomaticos.Rows(e.RowIndex).Cells(2).Value, "dd/MM/yyyy") & "',@CODIGO_EMPLEADO=" & Me.dgvAutomaticos.Rows(e.RowIndex).Cells(0).Value.ToString() & ",@BANDERA=" & Me.dgvAutomaticos.Rows(e.RowIndex).Cells(5).Value.ToString()
                tblDetalle = c_data2.ejecutaSQLl_llenaDTABLE(sql)
                dgvDetallesInt.DataSource = tblDetalle
                dgvDetallesInt.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDetallesInt.Columns(0).HeaderText = "COD.EMPL."
                dgvDetallesInt.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgvDetallesInt.Columns(1).HeaderText = "NOMBRE COMPLETO"
                dgvDetallesInt.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDetallesInt.Columns(2).HeaderText = "DEDUCCION"
                dgvDetallesInt.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvDetallesInt.Columns(3).HeaderText = "FECHA DESC."
                dgvDetallesInt.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgvDetallesInt.Columns(4).DefaultCellStyle.Format = "0.00"
                txtDetAuto.Text = Format(Val(tblDetalle.Compute("SUM(TOTAL)", "TOTAL > 0")), "0.00")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub NumeroMovimiento()
        Dim bdClass As New jarsClass
        Try
            Movimiento = bdClass.leerDataeader("SELECT ISNULL(MAX(NUMERO_FACTURA),0)+1 FROM CAFETERIA_FACTURACION_ENCABEZADO WHERE BODEGA=" & bodega & " AND CAJA=" & caja & " AND RTRIM(SERIE) = '" & serie & "' AND COMPAÑIA = " & Compañia, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnProcesarman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarMan.Click
        Me.txt_Manuales1.Text = Val(Me.txt_Automaticos2.Text) + 1
        Me.Pb1.Maximum = dgvDatosManuales.Rows.Count
        Pb1.Visible = True
        Pb1.Value = 0
        Me.btnProcesarAuto.Enabled = False
        Me.btnProcesarMan.Enabled = False
        Me.btnProcesarMan.Text = "Procesando"
        bodega = Me.cbCafeteria.SelectedValue
        caja = Me.cbCaja.SelectedValue
        fechaProc = Me.dtpFechaProceso.Value
        Table3 = Me.dgvDatosManuales.DataSource
        Me.bwManuales.RunWorkerAsync(2)
    End Sub

    Private Sub cbCafeteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCafeteria.SelectedIndexChanged
        If Iniciando = False Then
            Iniciando2 = True
            cargarCajas()
            Iniciando2 = False
        End If
    End Sub

    Private Sub btnProcesarAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarAuto.Click
        If MsgBox("Desea procesar los intereses automaticos?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion") = MsgBoxResult.Yes Then
            Me.btnProcesarAuto.Enabled = False
            Table2 = Me.dgvAutomaticos.DataSource
            Me.txt_Automatico1.Text = Table2.Rows(0).Item(4).ToString()
            Me.Pb1.Maximum = dgvAutomaticos.Rows.Count
            Pb1.Visible = True
            Pb1.Value = 0
            Me.btnProcesarAuto.Enabled = False
            Me.btnProcesarMan.Enabled = False
            Me.btnCancelar.Visible = True
            bodega = Me.cbCafeteria.SelectedValue
            caja = Me.cbCaja.SelectedValue
            fechaProc = Me.dtpFechaProceso.Value
            Me.bwAutomaticos.RunWorkerAsync()
        End If
    End Sub

    Public Sub validar_Empleado(ByVal codigo As String, ByVal valor As String)
        Dim sql As String
        Dim escalar As String
        sql = "SELECT COUNT(*) FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO= " & IIf(codigo = "", 1010101010, codigo)
        escalar = c_data2.obtenerEscalar(sql)
        If escalar = 0 Then
            listaEmpl.Add("Problemas con el registro de valor: " & valor & " y codigo: " & codigo)
        End If
    End Sub

    Private Sub btnValidaMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidaMan.Click
        Dim message As String
        listaEmpl.Clear()
        For i As Integer = 0 To dgvDatosManuales.RowCount - 1
            validar_Empleado(dgvDatosManuales.Rows(i).Cells(0).Value.ToString(), dgvDatosManuales.Rows(i).Cells(4).Value.ToString())
        Next
        message = "CODIGOS EMPLEADOS INEXISTENTES" & vbCrLf & vbCrLf
        For Each emp As String In listaEmpl
            message &= emp & vbCrLf
        Next
        MsgBox(message, MsgBoxStyle.Information, "Codigos Erróneos")
    End Sub

    Public Sub cadenaSIUD(ByVal CIA, ByVal SIUD, ByVal estado)
        Dim sql As String

        sql = "Execute [dbo].[sp_CAFETERIA_APERTURA_CIERRE_IUD] " & vbCrLf
        sql &= "@COMPAÑIA = " & CIA & vbCrLf
        sql &= ",@BODEGA = " & cbCafeteria.SelectedValue & vbCrLf
        sql &= ",@TIEMPO_COMIDA = 5" & vbCrLf
        sql &= ",@CAJA = " & cbCaja.SelectedValue & vbCrLf
        sql &= ",@FECHA = '" & Format(dtpFechaProceso.Value, "yyyy-MM-dd") & "'" & vbCrLf
        sql &= ",@MONTO = 0" & vbCrLf
        sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        sql &= ",@ESTADO = " & estado & vbCrLf
        sql &= ",@BANDERA = " & SIUD & vbCrLf

        Try
            c_data2.Ejecutar_ConsultaSQL(sql)
        Catch ex As Exception
            MsgBox("La caja fue Aperturada con Exito!", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btnCerrarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCaja.Click
        If Me.bwCargaAutomaticos.IsBusy Or Me.bwManuales.IsBusy Then
            MsgBox("NO SE PUEDE CERRAR CAJA MIENTRAS TODAVIA ESTA PROCESANDO", MsgBoxStyle.Information, Me.Text)
            Return
        End If
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea cerrar la caja para el dia " & dtpFechaProceso.Value & " y cerrar la ventana?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            cadenaSIUD(Compañia, 3, 0)
            NumeroMovimiento()
            CargarConsulta("28", 0, 0) 'CORTE X
            NumeroMovimiento()
            CargarConsulta("28", 0, 0) 'CORTE Z
            If rbQna2.Checked Then
                NumeroMovimiento()
                CargarConsulta("28", 0, 0) 'CORTE ZZ
            End If
            Me.TabControl1.Enabled = False
            CajaAbierta = False
            MsgBox("Caja Cerrada con Exito!", MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub
    'CARGA LA CONSULTA QUE PERMITE INSERTAR EL CORTE EN LA TABLA CAFETERIA_FACTURACION_ENCABEZADO
    Private Sub CargarConsulta(ByVal TipoDocumento As String, ByVal Venta As Double, ByVal Descuento As Double)
        Dim sql As String
        sql = "Execute [dbo].[sp_CAFETERIA_ALMACENAMIENTO_CORTES_X_Z] " & vbCrLf
        sql &= "@COMPAÑIA = " & Compañia & vbCrLf
        sql &= ",@BODEGA = " & cbCafeteria.SelectedValue & vbCrLf
        sql &= ",@SERIE = '" & IIf(serie.Length = 0, "NO ESTA DEFINIDO", serie) & "'" & vbCrLf
        sql &= ",@NUMERO_FACTURA = " & Movimiento & vbCrLf
        sql &= ",@FECHA = N'" & Me.dtpFechaProceso.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
        sql &= ",@TIEMPO = 5" & vbCrLf
        sql &= ",@CAJA = " & cbCaja.SelectedValue & vbCrLf
        sql &= ",@DESCUENTO=0" & vbCrLf
        sql &= ",@MONTO=0" & vbCrLf
        sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
        sql &= ",@USUARIO_CREACION = '" & Usuario & "'" & vbCrLf
        sql &= ",@SERIECOMPLETA = '" & serie & "'"
        c_data2.ejecutarComandoSql(New SqlCommand(sql))
    End Sub

    Private Sub dtpFechaProceso_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaProceso.ValueChanged
        If dtpFechaProceso.Value.Day > 15 Then
            Me.rbQna2.Checked = True
        End If
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        fechaProc = Me.dtpFechaProceso.Value
        Me.Pb1.Maximum = 100
        Me.Pb1.Value = 0
        Me.Pb1.Visible = True
        Me.bwTabla.RunWorkerAsync()
        Me.bwAvance.RunWorkerAsync()
    End Sub

    Private Sub btnBuscaGlobal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaGlobal.Click
        Dim sql As String
        sql = "EXECUTE sp_PLANILLA_INTERESES " & Compañia & ", '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "', " & Val(correlativo_Actual) & ",@BANDERA=1"
        If (c_data2.obtenerEscalar(sql) > 0) Then
            btnProcesarAuto.Enabled = False
            btnCargaMan.Enabled = False
            btnProcesarMan.Enabled = False
            Label19.Visible = True
            btnExportExcel.Enabled = True
            MsgBox("Los registros ya estan procesados!", MsgBoxStyle.Information)
            CajaAbierta = False
        Else
            Dim cantidad As Integer
            sql = "EXECUTE sp_PLANILLA_INTERESES @FECHA='" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "',@BANDERA=3"
            cantidad = c_data2.obtenerEscalar(sql)
            If (cantidad > 0) Then
                Dim respuesta As MsgBoxResult
                respuesta = MsgBox("Hay " & cantidad & " registros para procesar, ¿desea hacerlo ahora?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                If respuesta = MsgBoxResult.Yes Then
                    Timer1.Enabled = True
                    btnProcesarAuto.Enabled = True
                    btnCargaMan.Enabled = True
                    btnProcesarMan.Enabled = True
                    Label19.Visible = False
                    btnCerrarCaja.Enabled = True
                    btnExportExcel.Enabled = True
                    cadenaSIUD(Compañia, 1, 1)
                    TabControl1.Enabled = True
                    CajaAbierta = True
                    bwCargaAutomaticos.RunWorkerAsync()
                    'btnAbrirCaja.PerformClick()
                End If
            Else
                MsgBox("NO HAY DATOS PARA ESTA FECHA!", MsgBoxStyle.Information)
                Label19.Visible = False
            End If
        End If
    End Sub

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.txt_Automaticos2.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.txt_Automaticos2.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText3(ByVal texto As String)
    Sub SetText3(ByVal texto As String)
        If Me.txt_Manuales2.InvokeRequired Then
            Dim setea As New CallBackSetText3(AddressOf SetText3)
            Me.Invoke(setea, texto)
        Else
            Me.txt_Manuales2.Text = texto
        End If
    End Sub

    Private Sub bwAutomaticos_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAutomaticos.DoWork
        Dim jClass As New jarsClass
        Dim tblLineas As DataTable
        Dim sql As String
        Dim sql1 As String
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        For i As Integer = 0 To dgvAutomaticos.RowCount - 1
            If Me.bwAutomaticos.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
            NumeroMovimiento()
            codigo_as = jClass.obtenerEscalar("SELECT CODIGO_EMPLEADO_AS FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Table2.Rows(i).Item(0).ToString())
            Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Table2.Rows(i).Item(0).ToString())
            'SE RECOGEN LOS DETALLES DE LOS INTERESES POR EMPLEADO
            sql1 = "EXEC sp_PLANILLA_INTERESES @FECHA='" & Format(fechaProc, "dd/MM/yyyy") & "',@CODIGO_EMPLEADO=" & Table2.Rows(i).Item(0).ToString() & ",@BANDERA=" & Table2.Rows(i).Item(5).ToString()
            tblLineas = jClass.ejecutaSQLl_llenaDTABLE(sql1)
            For j As Integer = 0 To tblLineas.Rows.Count - 1
                'SE INGRESA A LA BASE CADA UNO DE LOS DETALLES DE LA FACTURACION
                sql = "EXECUTE [dbo].[sp_CAFETERIA_FACTURACION_SIUD] " & vbCrLf
                sql &= "@COMPAÑIA = " & Compañia & vbCrLf
                sql &= ",@BODEGA = " & bodega & vbCrLf
                sql &= ",@SERIE = '" & serie & "'" & vbCrLf
                sql &= ",@NUMERO_FACTURA = " & Movimiento & vbCrLf
                sql &= ",@FECHA = N'" & Format(fechaProc, "dd/MM/yyyy") & "'" & vbCrLf
                sql &= ",@TIEMPO = 5" & vbCrLf
                sql &= ",@CAJA = " & caja & vbCrLf
                sql &= ",@CODIGO_EMPLEADO = " & Table2.Rows(i).Item(0).ToString() & vbCrLf
                sql &= ",@CODIGO_EMPLEADO_AS = '" & codigo_as.PadLeft(6, "0") & "'" & vbCrLf
                sql &= ",@ANULADO = 0" & vbCrLf
                sql &= ",@FORMA_PAGO = " & Forma_Pago & vbCrLf
                sql &= ",@IVA = 0" & vbCrLf
                sql &= ",@DEUDA = 0" & vbCrLf
                sql &= ",@MONTO = " & Table2.Rows(i).Item(3).ToString() & vbCrLf
                sql &= ",@TIPO_DOCUMENTO = 27" & vbCrLf 'TICKET DE CAJA DEFINIDO EN CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO
                sql &= ",@ORIGEN = " & Origen & vbCrLf
                sql &= ",@PROCESADO = 1" & vbCrLf
                sql &= ",@USUARIO_CREACION = '" & Usuario & "'" & vbCrLf
                sql &= ",@BANDERA = 'I'" & vbCrLf
                sql &= ",@PRODUCTO = " & tblLineas.Rows(j).Item(5).ToString() & vbCrLf
                sql &= ",@CANTIDAD = 1" & vbCrLf
                sql &= ",@COSTO_UNITARIO = " & tblLineas.Rows(j).Item(4).ToString() & vbCrLf
                sql &= ",@PRECIO_UNITARIO = " & tblLineas.Rows(j).Item(4).ToString() & vbCrLf
                sql &= ",@PRECIO_TOTAL = " & tblLineas.Rows(j).Item(4).ToString() & vbCrLf
                sql &= ",@TIPO_MOV = 0" & vbCrLf
                sql &= ",@MOV = 0" & vbCrLf
                sql &= ",@SERIECOMPLETA = '" & serie & "'"
                jClass.Ejecutar_ConsultaSQL(sql)
            Next
            'SE CARGA EL DETALLE DE LA FACTURA, INCREMENTA EL CORRELATIVO, ACTUALIZA LA TABLA DE CORRELATIVOS
            jClass.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & bodega & ",@CAJA=" & caja & ",@BANDERA=4")
            poneTexto(Table2.Rows(i).Item(4).ToString())
            Me.bwAutomaticos.ReportProgress(i + 1)
        Next
    End Sub

    Private Sub bwAutomaticos_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwAutomaticos.ProgressChanged
        Try
            Me.Pb1.Value = e.ProgressPercentage
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bwAutomaticos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAutomaticos.RunWorkerCompleted
        Dim sql As String
        If e.Cancelled Then
            MsgBox("Cancelado por usuario", MsgBoxStyle.Information)
        ElseIf e.Error IsNot Nothing Then
            MsgBox("OCURRIO UN ERROR" & vbCrLf & vbCrLf & e.Error.Message)
            Try
                MsgBox("ERROR INTERNO" & vbCrLf & vbCrLf & e.Error.InnerException.Message)
            Catch ex As Exception
            End Try
        Else
            MsgBox("Carga realizada con exito!", MsgBoxStyle.Information)
        End If
        Me.btnCancelar.Visible = False
        sql = "SELECT MIN(NUMERO_FACTURA),MAX(NUMERO_FACTURA)" & vbCrLf
        sql &= " FROM CAFETERIA_FACTURACION_ENCABEZADO" & vbCrLf
        sql &= " WHERE BODEGA=" & Me.cbCafeteria.SelectedValue & " AND CAJA=" & Me.cbCaja.SelectedValue & " AND CONVERT(DATE,FECHA_FACTURA)=CONVERT(DATE,'" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "')" & vbCrLf

        Me.txt_Automatico1.Text = c_data2.leerDataeader(sql, 0)
        Me.txt_Automaticos2.Text = c_data2.leerDataeader(sql, 1)

        Me.btnProcesarAuto.Enabled = True
        Me.btnProcesarMan.Enabled = True
        Pb1.Visible = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.bwAutomaticos.IsBusy Then
            Me.bwAutomaticos.CancelAsync()
        ElseIf Me.bwManuales.IsBusy Then
            Me.bwManuales.CancelAsync()
        End If
    End Sub

    Private Sub bwManuales_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwManuales.DoWork
        Dim Sql As String
        Dim jClass1 As New jarsClass
        Dim poneTexto3 As New CallBackSetText3(AddressOf SetText3)

        For i As Integer = 0 To Table3.Rows.Count - 1
            NumeroMovimiento()
            Try
                Origen = jClass1.leerDataeader("EXECUTE sp_CAFETERIA_BUSCAR_EMPLEADO_POR_CODIGO @COMPAÑIA=" & Compañia & ",@CODIGO='" & Table3.Rows(i).Item(0).ToString().PadLeft(6, "0") & "',@BANDERA=0", 2)
            Catch ex As Exception
                Origen = 0
            End Try
            Sql = "Execute [dbo].[sp_CAFETERIA_FACTURACION_SIUD] " & vbCrLf
            Sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@BODEGA = " & bodega & vbCrLf
            Sql &= ",@SERIE = '" & serie & "'" & vbCrLf
            Sql &= ",@NUMERO_FACTURA = " & Movimiento & vbCrLf
            Sql &= ",@FECHA = N'" & Format(fechaProc, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@TIEMPO = 5" & vbCrLf
            Sql &= ",@CAJA = " & caja.ToString() & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Table3.Rows(i).Item(0).ToString() & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO_AS = '" & Table3.Rows(i).Item(1).ToString() & "'" & vbCrLf
            Sql &= ",@ANULADO = 0" & vbCrLf
            Sql &= ",@FORMA_PAGO = " & Forma_Pago & vbCrLf
            Sql &= ",@IVA = 0" & vbCrLf 'JNJN
            Sql &= ",@DEUDA = 0" & vbCrLf
            Sql &= ",@MONTO = " & Table3.Rows(i).Item(4).ToString() & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = 27" & vbCrLf 'TICKET DE CAJA (DEFINIDO EN CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO)
            Sql &= ",@ORIGEN = " & Origen & vbCrLf
            Sql &= ",@PROCESADO = 1" & vbCrLf
            Sql &= ",@USUARIO_CREACION = '" & Usuario & "'" & vbCrLf
            Sql &= ",@BANDERA = 'I'" & vbCrLf
            Sql &= ",@PRODUCTO = " & Table3.Rows(i).Item(2).ToString() & vbCrLf
            Sql &= ",@CANTIDAD = 1" & vbCrLf
            Sql &= ",@COSTO_UNITARIO = " & Table3.Rows(i).Item(4).ToString() & vbCrLf
            Sql &= ",@PRECIO_UNITARIO = " & Table3.Rows(i).Item(4).ToString() & vbCrLf
            Sql &= ",@PRECIO_TOTAL = " & Table3.Rows(i).Item(4).ToString() & vbCrLf
            Sql &= ",@TIPO_MOV = 2" & vbCrLf
            Sql &= ",@MOV = 0" & vbCrLf
            Sql &= ",@SERIECOMPLETA = '" & serie & "'"
            'SE CARGA EL DETALLE DE LA FACTURA
            jClass1.Ejecutar_ConsultaSQL(Sql)
            'INCREMENTA EL CORRELATIVO, ACTUALIZA LA TABLA DE CORRELATIVOS
            jClass1.Ejecutar_ConsultaSQL("EXECUTE sp_CAFETERIA_FACTURACION_OBTENER_SERIE @COMPAÑIA=" & Compañia & ",@BODEGA=" & bodega & ",@CAJA=" & caja & ",@BANDERA=4")
            poneTexto3(Movimiento.ToString())
            bwManuales.ReportProgress(i + 1)
        Next
    End Sub

    Private Sub bwManuales_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwManuales.ProgressChanged
        Try
            Pb1.Value = e.ProgressPercentage
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bwManuales_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwManuales.RunWorkerCompleted
        Dim sql As String
        If e.Cancelled Then
            MsgBox("Cancelado por usuario", MsgBoxStyle.Information)
        ElseIf e.Error IsNot Nothing Then
            MsgBox("OCURRIO UN ERROR" & vbCrLf & vbCrLf & e.Error.Message)
            Try
                MsgBox("ERROR INTERNO" & vbCrLf & vbCrLf & e.Error.InnerException.Message)
            Catch ex As Exception
            End Try
        Else
            MsgBox("Carga realizada con exito!", MsgBoxStyle.Information)
        End If
        Me.btnCancelar.Visible = False

        sql = "SELECT MIN(NUMERO_FACTURA),MAX(NUMERO_FACTURA)" & vbCrLf
        sql &= " FROM CAFETERIA_FACTURACION_ENCABEZADO" & vbCrLf
        sql &= " WHERE BODEGA=" & Me.cbCafeteria.SelectedValue & " AND CAJA=" & Me.cbCaja.SelectedValue & " AND CONVERT(DATE,FECHA_FACTURA)=CONVERT(DATE,'" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "')" & vbCrLf
        Me.txt_Manuales2.Text = c_data2.leerDataeader(sql, 1)

        Me.btnProcesarAuto.Enabled = True
        Me.btnProcesarMan.Enabled = True
        Me.btnProcesarMan.Text = "Procesar"
        Pb1.Visible = False
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
    Private Sub TabPage3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Facturacion_Intereses_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CajaAbierta And (Val(Me.txt_Automatico1.Text) > 0 Or Val(Me.txt_Manuales1.Text) > 0) Then
            MsgBox("No puede cerrar esta ventana" & vbCrLf & vbCrLf & "Caja todavía está Abierta")
            e.Cancel = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Label15.Visible = Not Me.Label15.Visible
    End Sub

    Private Sub bwCargaAutomaticos_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCargaAutomaticos.DoWork
        Dim sql As String
        sql = "EXECUTE sp_PLANILLA_INTERESES " & Compañia & ", '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "', " & Val(correlativo_Actual) & ",@BANDERA=0"
        DATA01 = c_data2.ejecutaSQLl_llenaDTABLE(sql)
    End Sub

    Private Sub bwCargaAutomaticos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCargaAutomaticos.RunWorkerCompleted
        cargaDatosAutomaticos()
        Timer1.Enabled = False
        Me.Label15.Visible = False
        Me.btnBuscaGlobal.Enabled = False
        MsgBox("Caja Aperturada con Exito!", MsgBoxStyle.Information)
    End Sub

    Private Sub bwAvance_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAvance.DoWork
        While bwTabla.IsBusy
            For i As Integer = 0 To 100
                If bwTabla.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(500)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    bwAvance.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While
        bwAvance.ReportProgress(100)
    End Sub

    Private Sub bwTabla_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwTabla.DoWork
        Table = c_data2.ObtenerDataSet("EXECUTE sp_PLANILLA_INTERESES @COMPAÑIA=" & Compañia & ", @FECHA='" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "',@BANDERA=4").Tables(0)
    End Sub

    Private Sub bwAvance_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwAvance.ProgressChanged
        Try
            Pb1.Value = e.ProgressPercentage
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bwTabla_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTabla.RunWorkerCompleted
        Dim filename As String = ""
        With OpenFD
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .FileName = "Libro de Excel"
            .Filter = "Libro de Excel 97-2003|*.xls"
        End With
        If OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = OpenFD.FileName
            reporte.SetDataSource(Table)
            reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, filename)
            If System.IO.File.Exists(filename) Then
                If MsgBox("Archivo " & filename & " creado exitosamente" & vbCrLf & vbCrLf & "¿Desea abrirlo en este momento?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    Process.Start(filename)
                End If
            End If
            CrystalReportViewer1.ReportSource = reporte
            Me.TabControl1.Enabled = True
            Me.TabControl1.SelectedTab = TabPage4
            For Each ctrl As Control In Me.GroupBox2.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = False
                End If
            Next
            For Each ctrl As Control In Me.GroupBox5.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = False
                End If
            Next
        End If
    End Sub

    Private Sub bwAvance_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAvance.RunWorkerCompleted
        Me.Pb1.Visible = False
    End Sub
End Class