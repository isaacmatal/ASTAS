Imports System.Data.SqlClient
Public Class Contabilidad_Generar_Cheque_Emergencia
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim ProcesosContables As New Contabilidad_Procesos
    Dim VLetras As New NumeroLetras
    Dim Table As DataTable
    Dim Cheque As Integer
    Dim Iniciando As Boolean
    Dim NumTran As Integer = 0
    Dim registrar_cheque_ As [Delegate]

    Private Sub Contabilidad_Generar_Cheque_Emergencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        CargaBancos(Compañia)
        CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 5)
        CargaCuentaContable(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        CargaChequeras(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 2)
        Me.dpFECHA_CH.Value = Now
        Iniciando = False
    End Sub

    'FUNCIONES PARA LA SELECCIÓN DEL BANCO

    Private Sub CargaBancos(ByVal Compañia)
        Dim sqlCmd As New SqlCommand

        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            Sql &= Compañia
            Sql &= ", 0"
            Sql &= ", 3"
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            Me.cmbBANCO.DataSource = Table
            Me.cmbBANCO.ValueMember = "Banco"
            Me.cmbBANCO.DisplayMember = "Nombre Banco"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasBancarias(ByVal Compañia, ByVal Banco, ByVal Bandera)
        Dim sqlCmd As New SqlCommand
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", " & Bandera
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)

            Me.cmbCUENTA_BANCARIA.DataSource = Table
            Me.cmbCUENTA_BANCARIA.ValueMember = "Cuenta"
            Me.cmbCUENTA_BANCARIA.DisplayMember = "Descripción Cuenta"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentaContable(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Bandera)
        Dim sqlCmd As New SqlCommand
        Try

            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & Bandera

            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)

            If Table.Rows.Count <> 0 Then
                Me.lblCUENTA_COMPLETA.Text = Table.Rows(0).Item("CUENTA_COMPLETA")
                Me.lblCUENTA.Text = Table.Rows(0).Item("CUENTA")
                Me.lblLIBRO_CONTABLE.Text = Table.Rows(0).Item("LIBRO_CONTABLE")
            Else
                Me.lblCUENTA_COMPLETA.Text = ""
                Me.lblCUENTA.Text = "0"
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaChequeras(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Bandera)
        Dim sqlCmd As New SqlCommand
        Try

            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & Bandera

            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)

            Me.cmbCHEQUERA.DataSource = Table
            Me.cmbCHEQUERA.ValueMember = "Chequera"
            Me.cmbCHEQUERA.DisplayMember = "Descripción"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 4)
            CargaCuentaContable(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub cmbCUENTA_BANCARIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCUENTA_BANCARIA.SelectedIndexChanged
        If Iniciando = False And Me.cmbCUENTA_BANCARIA.ValueMember <> "" Then
            CargaCuentaContable(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
            CargaChequeras(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 2)
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub cmbCHEQUERA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCHEQUERA.SelectedIndexChanged
        Dim sqlCmd As New SqlCommand

        If Iniciando = False And Me.cmbCUENTA_BANCARIA.ValueMember <> "" And Me.cmbCHEQUERA.ValueMember <> "" Then
            Sql = "SELECT ISNULL(ACTUAL,0) FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS "
            Sql &= "WHERE BANCO = " & Me.cmbBANCO.SelectedValue
            Sql &= " AND CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= " AND CHEQUERA = " & Me.cmbCHEQUERA.SelectedValue
            Sql &= " AND ACTIVA = 1"

            sqlCmd.CommandText = Sql
            Dim cheque = jClass.obtenerEscalar(Sql)
            Me.txtNumCheque.Text = cheque
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Not validarcampos() Then
            Return
        End If
        
        Cheque = GeneraCorrelativoCheque(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, Me.cmbCHEQUERA.SelectedValue)
        Cheque = Val(Me.txtNumCheque.Text)
        Dim frm_ As New Contabilidad_Partidas
        Dim numPartida As Integer = Val(Me.txtPartida.Text)
        Dim Transaccion As String = String.Empty
        If numPartida > 0 Then
            NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & numPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFECHA_CH.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFECHA_CH.Value.Year & " AND COMPAÑIA = " & Compañia)
            If NumTran = 0 Then
                MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                Return
            Else
                Transaccion = NumTran
                If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                    MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                    Return
                End If
            End If
        Else
            If MsgBox("No ha ingresado un número de partida." & vbCrLf & vbCrLf & "¿Desea Crear la partida automaticamente?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Return
            Else
                '***************************************************************
                Transaccion = GeneraCorrelativo(Compañia, "TRA", Me.dpFECHA_CH.Value.Year, Me.dpFECHA_CH.Value.Month).ToString
                Me.txtPartida.Text = GeneraCorrelativo(Compañia, "PAR", Me.dpFECHA_CH.Value.Year, Me.dpFECHA_CH.Value.Month).ToString
                Mantenimiento_TransaccionE(Compañia, Transaccion, Val(lblLIBRO_CONTABLE.Text), 7, Trim(Me.txtNumCheque.Text), 1, Me.txtPartida.Text, Me.dpFECHA_CH.Value, Trim(Me.txtConcepto.Text), "0", "0", "I")
                '***************************************************************
            End If
        End If

        If Cheque > 0 Then
            Tipo_Doc = Me.obtener_tipo_documento("CK") 'Cheque de Emergencia.
            If GuardarCheque() > 0 Then
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtNumCheque.Text, "A", Me.txtMonto.Text, "E")
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtNumCheque.Text, "A", Me.txtMonto.Text, "A")
                'frm_.txtTRANSACCION.Text = Transaccion
                'frm_.txtCONCEPTO.Text = Me.txtConcepto.Text
                'frm_.txtDOCUMENTO.Text = Me.txtNumCheque.Text
                'frm_.txtCUENTA_COMPLETA.Text = Me.lblCUENTA_COMPLETA.Text
                'frm_.lblCuenta.Text = Me.lblCUENTA.Text
                'frm_.txtCONCEPTO_L.Text = "Cheque Numero: " & Me.txtNumCheque.Text
                frm_.txtPARTIDA.Text = Me.txtPartida.Text
                'frm_.txtMONTO.Text = Me.txtMonto.Text
                'frm_.txtCodDetalle.Text = "0"
                frm_.ShowDialog()
            End If
        Else
            MsgBox("No fue posible generar el Número de Cheque", MsgBoxStyle.Critical, "Mensaje")
        End If
        frm_.Dispose()
    End Sub

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = '" & TipoDocumento & "'" & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@ULTIMO         = 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("ULTIMO")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Function Mantenimiento_TransaccionE(ByVal Compañia As Integer, ByVal Transaccion As Integer, ByVal LibroContable As Integer, ByVal TipoDocumento As Integer, ByVal Documento As String, ByVal TipoPartida As Integer, ByVal Partida As Integer, ByVal FechaContable As Date, ByVal Concepto As String, ByVal Anulada As Integer, ByVal AnuladaPor As Integer, ByVal IUD As String) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim A As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            Sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            Sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            Sql &= ",@PARTIDA        = " & Partida & vbCrLf
            Sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@ANULADA        = " & Anulada & vbCrLf
            Sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            A = Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Partida Reservada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Partida Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Partida Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return A
    End Function

    Private Function Mantenimiento_TransaccionL(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer, ByVal Linea As Integer, ByVal CentroCosto As Integer, ByVal Cuenta As Integer, ByVal Concepto As String, ByVal CargoAbono As String, ByVal Monto As Double, ByVal IUD As String) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim A As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_DETALLE_IUD" & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@LINEA          = " & Linea & vbCrLf
            Sql &= ",@CENTRO_COSTO   = " & CentroCosto & vbCrLf
            Sql &= ",@CUENTA         = " & Cuenta & vbCrLf
            Sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            Sql &= ",@CARGO_ABONO    = '" & CargoAbono & "'" & vbCrLf
            Sql &= ",@CARGO          = " & IIf(CargoAbono = "C", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@ABONO          = " & IIf(CargoAbono = "A", Monto.ToString("0.00"), "0.00") & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "'" & vbCrLf
            Sql &= ",@CUENTANEW	     = 0" & vbCrLf
            Sql &= ",@DETALLENEW     = 0" & vbCrLf
            Comando_ = New SqlCommand(Sql, Conexion_)
            A = Comando_.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return A
    End Function

    Private Function validarcampos() As Boolean        
        Dim Result As Boolean = True
        If Not ValidaCierreContable(Compañia, jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"), Me.dpFECHA_CH.Value.Year, Me.dpFECHA_CH.Value.Month, "E") Then
            Result = False
        End If
        If Me.txtNumCheque.Text.Length = 0 Then
            MsgBox("Debe ingresar un número para el cheque", MsgBoxStyle.Critical, "No.Cheque invalido")
            Me.txtNumCheque.Focus()
            Result = False
        End If
        If Me.txtMonto.Text = "" Then
            MsgBox("Debe ingresar un monto para el cheque", MsgBoxStyle.Critical, "Monto invalido")
            Me.txtMonto.Focus()
            Result = False
        End If
        If Me.txtPersona.Text = "" Then
            MsgBox("Debe ingresar el nombre a quien seá emitido el cheque", MsgBoxStyle.Critical, "Nombre invalido")
            Me.txtPersona.Focus()
            Result = False
        End If
        If Me.txtConcepto.Text = "" Then
            MsgBox("Debe ingresar un concepto para el cheque", MsgBoxStyle.Critical, "Concepto invalido")
            Me.txtConcepto.Focus()
            Result = False
        End If
        If Me.cmbCUENTA_BANCARIA.Text.Length = 0 Then
            MsgBox("Debe seleccionar una cuenta bancaria válida", MsgBoxStyle.Critical, "Dato invalido")
            Me.cmbCUENTA_BANCARIA.Focus()
            Result = False
        End If
        If Me.cmbCHEQUERA.Text.Length = 0 Then
            MsgBox("Debe seleccionar una Chequera válida", MsgBoxStyle.Critical, "Dato invalido")
            Me.cmbCHEQUERA.Focus()
            Result = False
        End If
        'If numPartida > 0 Then
        '    NumTran = jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & numPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFECHA_CH.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFECHA_CH.Value.Year & " AND COMPAÑIA = " & Compañia)
        '    If NumTran = 0 Then
        '        MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
        '        Result = False
        '    Else
        '        If jClass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
        '            MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
        '            Result = False
        '        End If
        '    End If
        'Else
        '    MsgBox("Debe ingresar un número de partida válido", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
        '    Result = False
        'End If
        Return Result
    End Function

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        Dim cadena As String = Me.txtMonto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtPersona.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    '*******************************************************
    '******** FUNCIONES PARA GENERAR EL CHEQUE *************
    Private Function obtener_tipo_documento(ByVal indicador) As Integer
        Dim tipo_documento As Integer
        Sql = "SELECT TIPO_DOCUMENTO FROM CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO WHERE IDENTIFICADOR= '" & indicador & "'"
        tipo_documento = jClass.obtenerEscalar(Sql)
        Return tipo_documento
    End Function

    Private Function GeneraCorrelativoCheque(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Chequera) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Dim Cheque As Integer = 0
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS_CORRELATIVO "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & Chequera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Cheque = DataReader_.Item("NUMERO_CHEQUE")
            End If
            Conexion_.Close()
            Return Cheque
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return Cheque
        End Try
    End Function

    Private Function GuardarCheque() As Integer
        Dim A As Integer
        Dim EnLetras As String = VLetras.Letras(Me.txtMonto.Text).Replace("US DOLARES", "").Trim()
        Sql = "EXECUTE sp_CONTABILIDAD_CHEQUE_EMERGENCIA_IUD " & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ",@CHEQUE = " & Me.txtNumCheque.Text & vbCrLf
        Sql &= ",@PERSONA = '" & Me.txtPersona.Text & "'" & vbCrLf
        Sql &= ",@MONTO = " & Me.txtMonto.Text & vbCrLf
        Sql &= ",@MONTO_LETRAS = '" & EnLetras & "'" & vbCrLf
        Sql &= ",@CONCEPTO = '" & Me.txtConcepto.Text & "'" & vbCrLf
        Sql &= ",@FECHA_CONTABLE = '" & Format(Me.dpFECHA_CH.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ",@PARTIDA_LIQUIDADA = 1" & vbCrLf
        Sql &= ",@BANCO = " & Me.cmbBANCO.SelectedValue & vbCrLf
        Sql &= ",@CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
        Sql &= ",@LIBRO_CONTABLE = " & Me.lblLIBRO_CONTABLE.Text & vbCrLf
        Sql &= ",@CUENTA = " & Me.lblCUENTA.Text & vbCrLf
        Sql &= ",@TRANSACCION = 0" & vbCrLf
        Sql &= ",@PARTIDA = " & Me.txtPartida.Text & vbCrLf
        Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        Sql &= ",@ACCION = 'I'"
        A = jClass.ejecutarComandoSql(New SqlCommand(Sql))
        If A > 0 Then
            Me.dgvCheques.Rows.Add(False, Me.txtNumCheque.Text, Me.txtPersona.Text, Me.txtMonto.Text, Me.chkNoNeg.Checked, EnLetras, Me.dpFECHA_CH.Value)
        Else
            MsgBox("El Cheque No Fue Guardado", MsgBoxStyle.Information, "Guardar Cheque")
        End If
        Return A
    End Function

    Private Sub GenerarCheque(ByVal Opcion As Integer)
        Dim chequeTable As New DataTable
        Dim Rpts As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
        Dim FrmVer As New frmReportes_Ver
        Dim contch As New Contabilidad_Imprimir_Cheques
        chequeTable.Columns.Add("Numero Cheque", Type.GetType("System.Int32"))
        chequeTable.Columns.Add("Nombre", Type.GetType("System.String"))
        chequeTable.Columns.Add("Valor Cheque", Type.GetType("System.Double"))
        chequeTable.Columns.Add("Letras", Type.GetType("System.String"))
        chequeTable.Columns.Add("Negociable", Type.GetType("System.Boolean"))
        chequeTable.Columns.Add("Fecha", Type.GetType("System.DateTime"))
        If Opcion = 1 Then
            If Me.dgvCheques.CurrentRow IsNot Nothing Then
                chequeTable.Rows.Add(Me.dgvCheques.CurrentRow.Cells("numcheque").Value, Me.dgvCheques.CurrentRow.Cells("nombre").Value, Me.dgvCheques.CurrentRow.Cells("monto").Value, Me.dgvCheques.CurrentRow.Cells("montoletras").Value, Me.dgvCheques.CurrentRow.Cells("noneg").Value, Me.dgvCheques.CurrentRow.Cells("fecha").Value)
                Rpts.SetDataSource(chequeTable)
                FrmVer.crvReporte.ReportSource = Rpts
                FrmVer.ShowDialog(Me)
            Else
                MsgBox("Por favor, Seleccione un cheque del listado inferior", MsgBoxStyle.Information, "Seleccionar")
            End If
        Else
            For i As Integer = 0 To Me.dgvCheques.Rows.Count - 1
                chequeTable.Rows.Add(Me.dgvCheques.Rows(i).Cells("numcheque").Value, Me.dgvCheques.Rows(i).Cells("nombre").Value, Me.dgvCheques.Rows(i).Cells("monto").Value, Me.dgvCheques.Rows(i).Cells("montoletras").Value, Me.dgvCheques.Rows(i).Cells("noneg").Value, Me.dgvCheques.Rows(i).Cells("fecha").Value)
            Next
            contch.dgvCheques.DataSource = chequeTable
            contch.dgvCheques.Columns(0).Width = 50
            contch.dgvCheques.Columns(1).Width = 200
            contch.dgvCheques.Columns(2).Width = 80
            contch.dgvCheques.Columns(2).DefaultCellStyle.Format = "#,###.00"
            contch.dgvCheques.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            contch.dgvCheques.Columns(3).Width = 160
            contch.dgvCheques.Columns(4).Width = 70
            contch.ShowDialog(Me)
        End If
    End Sub

    Private Sub bntNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNuevo.Click
        Me.txtMonto.Clear()
        Me.txtPersona.Clear()
        Me.txtConcepto.Clear()
        Me.txtPartida.Clear()
        Me.lblLIBRO_CONTABLE.Text = 0
        Me.lblCUENTA.Text = 0
        Me.txtNumCheque.Clear()
        Me.cmbBANCO.SelectedValue = 0
        CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 5)
    End Sub

    Private Sub Contabilidad_Generar_Cheque_Emergencia_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub Imprimir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir1.Click
        GenerarCheque(1)
    End Sub

    Private Sub Imprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir2.Click
        GenerarCheque(Me.dgvCheques.Rows.Count)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Producto = ""
        Nombre_Factura = ""
        Dim FrmCodigos As New Contabilidad_BusquedaCodigoDetalle(4)
        FrmCodigos.ShowDialog(Me)
        Me.txtPersona.Text = Nombre_Factura
    End Sub

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO = " & Año & vbCrLf
            Sql &= ",@MES = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            Sql &= ",@PROCESADO = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") = True Then
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            Sql &= ",@PROCESADO      = 0" & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function
End Class