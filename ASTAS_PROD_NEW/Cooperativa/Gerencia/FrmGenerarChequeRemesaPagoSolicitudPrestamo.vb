Imports System.Data.sqlClient

Public Class FrmGenerarChequeRemesaPagoSolicitudPrestamo

    'Constructor
    Dim PC As New jarsClass
    Dim Cheque As Integer = 0
    Dim Permitir As String
    Dim CnnStrBldr As New SqlConnectionStringBuilder
    Dim OrigenEmpl As Integer

    'Variables
    Dim sql As String
    Dim Iniciando As Boolean
    Dim cerrar As Boolean = False

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New sqlConnection
    Dim Comando_ As New SqlCommand
    Dim DataAdapter_ As sqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As sqlDataReader

    'Agregado por Jonathan Peña
    'Variables para procesar multiples cheques o remesas
    Dim j As Integer
    Public k As Integer
    Public multiples As Boolean
    Public chequeRemesa As Integer
    'Para ambos casos
    Public Cod_AS As String
    Public Cod_Buxis As Double
    Public Nombre_Socio As String
    'Para cuando se generara un documento
    Public NumSolicitud As Integer
    Public Periodo, cpus As String
    Public MontoFrm, Interes, Seguro As Double

    Private Sub FrmGenerarChequeRemesaPagoSolicitudPrestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dpFECHA.Value = Now()
        PC.CargaBancos2(Compañia, Me.cmbBANCO)
        Me.cmbBANCO.SelectedIndex = 1
        PC.CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 5, Me.cmbCUENTA_BANCARIA)
        CargaCuentaContable()
        CargaChequeras()
        Me.cmbBANCO.Focus()
        Iniciando = False
        CnnStrBldr.UserID = UsuarioDB
        CnnStrBldr.Password = PasswordDB
        CnnStrBldr.DataSource = Servidor
        CnnStrBldr.InitialCatalog = BaseDatos
        cpus = PC.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 45 AND COMPAÑIA = " & Compañia).ToString().Trim()
        If cpus.Contains(Host) Then
            Me.txtPartida.Visible = False
            Me.Label1.Visible = False
            Me.dgvCheques.Location = New System.Drawing.Point(0, 0)
            Me.Button2.Location = New System.Drawing.Point(0, 0)
            Me.Button2.Visible = False
            Me.dgvCheques.Visible = False
            Me.Width = 475
        End If
        Try
            Permitir = PC.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    'Metodos del selectedindexchange
    Private Sub cmbCUENTA_BANCARIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCUENTA_BANCARIA.SelectedIndexChanged
        If Iniciando = False And Me.cmbCUENTA_BANCARIA.ValueMember <> "" Then
            CargaCuentaContable()
            CargaChequeras()
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub
    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            PC.CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 4, Me.cmbCUENTA_BANCARIA)
            CargaCuentaContable()
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    'Metodo del boton editar
    Private Sub btnEditarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarConcepto.Click
        If Me.txtConcepto.ReadOnly = True Then
            Me.txtConcepto.ReadOnly = False
            Me.txtConcepto.BackColor = Color.White
            Me.txtConcepto.Focus()
        Else
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.BackColor = Color.LightGray
        End If
    End Sub

    'Evento lostfocus del txtCONCEPTO
    Private Sub txtCONCEPTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConcepto.LostFocus
        If Me.txtConcepto.ReadOnly = False Then
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub cargarValores()
        Dim TotalPendiente As Double = 0
        sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_PRESTAMOS"
        sql &= " @COMPAÑIA = " & Compañia & ","
        sql &= " @SOLICITUD = " & Me.lblSolicitud.Text & ","
        sql &= " @CODIGOAS = '0',"
        sql &= " @CODIGOBUXIS = 0,"
        sql &= " @NOMBRE = '',"
        sql &= " @BANDERA = 1"
        Comando_.CommandText = sql
        Table = PC.obtenerDatos(Comando_)
        Me.lblCantidad.Text = Format(Table.Rows(0).Item("CANTIDAD"), "0.00")
        Me.lblCodigoAS.Text = Table.Rows(0).Item("CODIGO_AS")
        Me.TxtBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
        Me.lblSocio.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
        OrigenEmpl = Table.Rows(0).Item("ORIGEN")
        Periodo = Table.Rows(0).Item("PERIODO")
        Me.txtConcepto.Text = " Pago Ptmo.Solicitud Nº " & Trim(Me.lblSolicitud.Text) & " Cód." & Me.TxtBuxis.Text
        sql = "Execute [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES_IUD]"
        sql &= " @COMPAÑIA = " & Compañia & ","
        sql &= " @SOLICITUD = " & ParamcodSolicitud & ","
        sql &= " @PERIODO = '" & Periodo & "',"
        sql &= " @BANDERA = 'T'"
        Comando_.CommandText = sql
        Table = PC.obtenerDatos(Comando_)
        Me.lblPagado.Text = Format(Table.Rows(0).Item(0), "0.00")
        TotalPendiente = Val(Me.lblCantidad.Text) - Table.Rows(0).Item(0)
        Me.btnGenerar.Enabled = Not (TotalPendiente = 0)
        Me.txtMonto.Text = Format(TotalPendiente, "0.00")
        Comando_.CommandText = "SELECT BANCO, DESCRIPCION_BANCO, CUENTA_BANCARIA FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Me.lblCodigoAS.Text & "' AND CODIGO_EMPLEADO = " & Me.TxtBuxis.Text
        Table = PC.obtenerDatos(Comando_)
        Me.lblBancoSocio.Tag = Table.Rows(0).Item(0)
        Me.lblBancoSocio.Text = Table.Rows(0).Item(1)
        Me.lblCtaSocio.Text = Table.Rows(0).Item(2)
        If Val(Me.txtMonto.Text) < 150.0 Then
            Me.chkNoNeg.Checked = False
        Else
            Me.chkNoNeg.Checked = True
        End If
    End Sub

    Private Sub CargaCuentaContable()
        Conexion_ = PC.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            sql &= Compañia
            sql &= ", " & Me.cmbBANCO.SelectedValue
            sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            sql &= ", " & 0
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Me.lblCUENTA_COMPLETA.Text = DataReader_.Item("CUENTA_COMPLETA")
                Me.lblCUENTA.Text = DataReader_.Item("CUENTA")
                Me.lblLIBRO_CONTABLE.Text = DataReader_.Item("LIBRO_CONTABLE")
            Else
                Me.lblCUENTA_COMPLETA.Text = ""
                Me.lblCUENTA.Text = "0"
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaChequeras()
        Conexion_ = PC.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS "
            sql &= Compañia
            sql &= ", " & Me.cmbBANCO.SelectedValue
            sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            sql &= ", " & 2
            Comando_ = New sqlCommand(sql, Conexion_)
            DataAdapter_ = New sqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCHEQUERA.DataSource = Table
            Me.cmbCHEQUERA.ValueMember = "Chequera"
            Me.cmbCHEQUERA.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Metodo que genera el correlativo del cheque
    Private Function GeneraCorrelativoCheque() As Integer
        Conexion_ = PC.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS_CORRELATIVO "
            sql &= Compañia
            sql &= ", " & Me.cmbBANCO.SelectedValue
            sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            sql &= ", " & Me.cmbCHEQUERA.SelectedValue
            Comando_ = New sqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Return DataReader_.Item("NUMERO_CHEQUE")
                Exit Function
            End If
            Conexion_.Close()
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    'Metodo del Boton para generar un soo cheque o remesa
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim TablaRecTemp As New DataTable("rectemp")
        Dim TablaRecibos As New DataTable
        Dim frmVer As New frmReportes_Ver
        'En esta variable si el documento es un cheque se guarda el correlativo del cheque, mientras que si es una remesa
        'guardamos el mismo numero de solicitud
        Dim Documento As Integer = 0
        'El tipo de documento se deterima si es cheque o remesa, si es cheque seria el 23, si es remesa es 22
        Dim tipoDoc As Integer = 0
        'Variables para la partida contable
        Dim numPartida As Integer = Val(Me.txtPartida.Text)
        Dim NumTran As Integer
        Dim Transaccion As String = String.Empty
        'Comprobamos que no haya ningun campo vacio
        If validaDatosCamposCMB() = True Then
            Me.txtConcepto.Text &= " chq.#" & Me.txtCheque.Text & " - " & Me.lblSocio.Text
            tipoDoc = 23
            Documento = GeneraCorrelativoCheque()
            Cheque = Val(Me.txtCheque.Text)
            If Cheque > 0 Then
                Monto = Val(Me.txtMonto.Text) - IIf(Me.chkPapeleria.Checked, 0.25, 0)
                PC.daFormatoMonto_RCR()
                PC.creaLineas_RCR()
                If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                    If numPartida > 0 Then
                        NumTran = PC.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & numPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFECHA.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFECHA.Value.Year & " AND COMPAÑIA = " & Compañia)
                        If NumTran = 0 Then
                            MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                            Return
                        Else
                            Transaccion = NumTran
                            If PC.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                                MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                                Return
                            End If
                            If PC.obtenerEscalar("SELECT COUNT(TRANSACCION) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
                                If MsgBox("Al procesar eliminará los registros existentes de la Partida #" & Me.txtPartida.Text & vbCrLf & "¿Está seguro(a) que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.No Then
                                    MsgBox("Proceso cancelado por usuario.", MsgBoxStyle.Information, "Mensaje")
                                    Return
                                Else
                                    PC.ejecutarComandoSql(New SqlCommand("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion))
                                End If
                            End If
                        End If
                    Else
                        If MsgBox("No ha ingresado un número de partida." & vbCrLf & vbCrLf & "¿Desea Crear la partida automaticamente?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                            Return
                        Else
                            '***************************************************************
                            Transaccion = GeneraCorrelativo(Compañia, "TRA", Me.dpFECHA.Value.Year, Me.dpFECHA.Value.Month).ToString
                            Me.txtPartida.Text = GeneraCorrelativo(Compañia, "PAR", Me.dpFECHA.Value.Year, Me.dpFECHA.Value.Month).ToString
                            If Mantenimiento_TransaccionE(Compañia, Transaccion, Val(lblLIBRO_CONTABLE.Text), 7, Trim(Me.txtCheque.Text), 1, Me.txtPartida.Text, Me.dpFECHA.Value, Trim(Me.txtConcepto.Text), "0", "0", "I") = 0 Then
                                MsgBox("Error al Generar Partida", MsgBoxStyle.Critical, "Partida Contable")
                                Return
                            End If
                            '***************************************************************
                        End If
                    End If
                End If
                Tipo_Doc = 6 'Cheque.
                If GuardarCheque() > 0 Then
                    If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", Monto, "E")
                        If Me.chkPapeleria.Checked Then
                            Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, PC.obtenerEscalar("SELECT CONVERT(INT, VALOR) AS CONSTANTE FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 23"), Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", 0.25, "E")
                        End If
                        sql = "SELECT P.CUENTA FROM COOPERATIVA_SOLICITUDES S, COOPERATIVA_CATALOGO_SOLICITUDES C, CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS P" & vbCrLf
                        sql &= " WHERE S.COMPAÑIA = C.COMPAÑIA AND S.SOLICITUD = C.SOLICITUD" & vbCrLf
                        sql &= "   AND C.COMPAÑIA = P.COMPAÑIA AND C.TIPO_DOCUMENTO = P.TIPO_DOCUMENTO AND P.CENTRO_COSTO = 1" & vbCrLf
                        sql &= "   AND P.CARGO = 1 AND P.ORIGEN = " & OrigenEmpl & vbCrLf
                        sql &= "   AND S.COMPAÑIA = " & Compañia & vbCrLf
                        sql &= "   AND S.CORRELATIVO = " & Me.lblSolicitud.Text & vbCrLf
                        NumTran = PC.obtenerEscalar(sql)
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, Me.TxtBuxis.Text, NumTran, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "C", Me.txtMonto.Text, "E")
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", Me.txtMonto.Text, "A")
                    End If
                    PC.mttoChequesProgSolicitudes(Compañia, Cheque, Val(Me.lblCantidad.Text), Val(Me.lblPagado.Text) _
                                                    , Val(Me.txtMonto.Text), Me.dpFECHA.Value, Val(Me.lblSolicitud.Text), Me.TxtBuxis.Text _
                                                    , Me.lblCodigoAS.Text, Periodo, Me.cmbBANCO.SelectedValue, Val(Me.lblCUENTA.Text) _
                                                    , Me.cmbCUENTA_BANCARIA.SelectedValue, Me.cmbCHEQUERA.SelectedValue _
                                                    , Val(Me.lblLIBRO_CONTABLE.Text), "I", Me.lblSocio.Text, IIf(Me.chkPapeleria.Checked, 0.25, 0))
                End If
                'imprimirCheque(Cheque, Me.lblSocio.Text, Monto, Me.chkNoNeg.Checked)
                TablaRecTemp.Reset()
                TablaRecTemp = PC.cargaRPT_RCR(Compañia, 1, Me.cmbBANCO.SelectedValue, 0, Me.dpFECHA.Value.Date, Cheque, 0, 3)
                If TablaRecibos.Rows.Count = 0 Then
                    TablaRecibos = TablaRecTemp.Clone()
                End If
                TablaRecibos.ImportRow(TablaRecTemp.Rows(0))
            Else
                MsgBox("No se pudo generar el Número de Cheque.", MsgBoxStyle.Information, "Mensaje")
            End If
            If TablaRecibos.Rows.Count > 0 Then
                Dim Rpts As New CooperativaSolicitudesPrestamosRecibos
                Dim Rpts1 As New CooperativaSolicitudesPrestamosRecibosATAF
                If OrigenEmpl = 5 Or OrigenEmpl = 6 Then
                    Rpts1.SetDataSource(TablaRecibos)
                    frmVer.ReportesGenericos(Rpts1)
                Else
                    Rpts.SetDataSource(TablaRecibos)
                    frmVer.ReportesGenericos(Rpts)
                End If
                frmVer.ShowDialog()
            End If
            'cmbCHEQUERA_SelectedIndexChanged(sender, e)
            If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                If Transaccion > 0 Then
                    frmVer.CargaPartida(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, Transaccion, Me.dpFECHA.Value.Year, Me.dpFECHA.Value.Month, 1)
                    frmVer.ShowDialog()
                End If
            End If

            cargarValores()

            sql = "UPDATE COOPERATIVA_SOLICITUDES"
            sql &= " SET FECHA_SOLICITUD = '" & Format(Me.dpFECHA.Value, "dd/MM/yyyy") & "'"
            sql &= " WHERE COMPAÑIA = " & Compañia
            sql &= " AND CORRELATIVO = " & Me.lblSolicitud.Text
            PC.ejecutarComandoSql(New SqlCommand(sql))

            If Val(Me.txtMonto.Text) <= 0 Then
                PC.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOLICITUDES_PRESTAMOS SET PAGADA = 1 WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & Me.lblSolicitud.Text)
            End If
            Me.txtCheque.Clear()
        End If
    End Sub

    'Comprueba que todos los campos, como combobox y otros datos
    'esten completos para proseguir con la operación
    Private Function validaDatosCamposCMB()
        Dim camposVacios As String = Nothing
        Dim cmbVacios As String = Nothing
        Dim datosVacios As String = Nothing
        Dim mensaje As String = Nothing
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.cmbBANCO.SelectedValue = Nothing Then
            cmbVacios &= vbCrLf & "Banco"
        End If
        If Me.cmbCUENTA_BANCARIA.SelectedValue = Nothing Then
            cmbVacios &= vbCrLf & "Cuenta Bancaria"
        End If
        If Me.cmbCHEQUERA.SelectedValue = Nothing Then
            cmbVacios &= vbCrLf & "Chequera"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.lblCodigoAS.Text = "" Then
            camposVacios = "Código AS"
        End If
        If Me.txtCheque.Text = "" Then
            camposVacios = "Cheque #"
        End If
        If Me.TxtBuxis.Text = "" Then
            camposVacios &= vbCrLf & "Código Buxis"
        End If
        If Me.lblSocio.Text = "" Then
            camposVacios &= vbCrLf & "Socio"
        End If
        If Me.txtConcepto.Text = "" Then
            camposVacios &= vbCrLf & "Concepto"
        End If
        If Me.lblSolicitud.Text = "" Then
            camposVacios &= vbCrLf & "Codigo Solicitud"
        End If
        If Me.lblCantidad.Text = "" Then
            camposVacios &= vbCrLf & "Interes"
        End If
        If Me.lblPagado.Text = "" Then
            camposVacios &= vbCrLf & "Seguro"
        End If
        If Me.txtMonto.Text = "" Then
            camposVacios &= vbCrLf & "Monto"
        End If
        If Me.lblCUENTA_COMPLETA.Text = "" Then
            camposVacios &= vbCrLf & "Cuenta"
        End If
        If Not PC.ValidaCierreContable(Compañia, Me.lblLIBRO_CONTABLE.Text, Me.dpFECHA.Value.Year, Me.dpFECHA.Value.Month, "E") Then
            camposVacios &= vbCrLf & "Hay problemas con el Periodo Contable."
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.lblLIBRO_CONTABLE.Text = "" Then
            datosVacios = "Libro Contable"
        End If
        If Me.lblCUENTA.Text = "" Then
            datosVacios &= vbCrLf & "Cuenta"
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        If datosVacios <> Nothing Or camposVacios <> Nothing Or cmbVacios <> Nothing Then
            mensaje = "La operación no puede continuar debido a que:"
            mensaje &= vbCrLf
            If cmbVacios <> Nothing Then
                mensaje &= "No se han cargado los siguientes campos:"
                mensaje &= vbCrLf & cmbVacios
            End If
            If mensaje <> Nothing Then
                mensaje &= vbCrLf
            End If
            If camposVacios <> Nothing Then
                mensaje &= "No se han completado los siguientes campos:"
                mensaje &= vbCrLf & camposVacios
            End If
            If mensaje <> Nothing Then
                mensaje &= vbCrLf
            End If
            If datosVacios <> Nothing Then
                mensaje &= "No se cargaron todos los valores."
                mensaje &= vbCrLf & "la cuenta bancaria seleccionada."
            End If
            MsgBox(mensaje, MsgBoxStyle.Information, "Mensaje")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub imprimirCheque(ByVal Cheque As Integer, ByVal NomProv As String, ByVal total_cheque As Double, ByVal NoNeg As Boolean)
        Dim VLetras As New NumeroLetras
        Dim DT01 As DataTable
        Dim sqlCmd As New SqlCommand
        Dim ImpCheque As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
        Dim letras As String
        Dim textObj As CrystalDecisions.CrystalReports.Engine.TextObject = ImpCheque.Section2.ReportObjects.Item("txtNoNeg")
        letras = VLetras.Letras(total_cheque.ToString).Replace("US DOLARES", "").Trim
        sql = "EXEC sp_CONTABILIDAD_EMITIR_CHEQUE "
        sql &= Cheque
        sql &= ", '" & NomProv & "'"
        sql &= ", " & total_cheque
        sql &= ", '" & letras & "'"
        sql &= ", " & IIf(Me.chkNoNeg.Checked, 1, 0)
        sqlCmd.CommandText = sql
        DT01 = PC.obtenerDatos(sqlCmd)
        ImpCheque.SetDataSource(DT01)
        Dim frmVer As New frmReportes_Ver
        'ImpCheque.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        'ImpCheque.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopeB6
        frmVer.ReportesGenericos(ImpCheque)
        frmVer.ShowDialog()
        'ImpCheque.PrintToPrinter(1, False, 1, 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.lblSocio.ReadOnly = True Then
            Me.lblSocio.ReadOnly = False
            Me.lblSocio.BackColor = Color.White
            Me.lblSocio.Focus()
        Else
            Me.lblSocio.ReadOnly = True
            Me.lblSocio.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub BtnBuscarSol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        ParamcodSolicitud = Nothing
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Me.txtPartida.Clear()
        Dim FrmBuscarSol As New FrmBuscarSolicitudesPrestamo
        FrmBuscarSol.Bandera = 2
        FrmBuscarSol.origenes = Permitir
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
            Me.lblSolicitud.Text = ParamcodSolicitud
            cargarValores()
        End If
    End Sub

    Private Sub FrmGenerarChequeRemesaPagoSolicitudPrestamo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged
        If Val(Me.lblCantidad.Text) - Val(Me.lblPagado.Text) < Val(Me.txtMonto.Text) Then
            MsgBox("Monto pendiente menor que cantidad ingresada", MsgBoxStyle.Information, "Validación")
            Me.txtMonto.Text = Format(Val(Me.lblCantidad.Text) - Val(Me.lblPagado.Text), "0.00")
        End If
    End Sub

    Private Sub cmbCHEQUERA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCHEQUERA.SelectedIndexChanged
        'If Not Iniciando Then
        '    Me.txtCheque.Text = PC.obtenerEscalar("SELECT ACTUAL FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS WHERE COMPAÑIA = " & Compañia & " AND BANCO = " & Me.cmbBANCO.SelectedValue & " AND CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "' AND CHEQUERA = " & Me.cmbCHEQUERA.SelectedValue).ToString()
        'End If
    End Sub

    Private Function GuardarCheque() As Integer
        Dim A As Integer
        Dim VLetras As New NumeroLetras
        Dim EnLetras As String = VLetras.Letras(Format(Monto, "0.00")).Replace("US DOLARES", "").Trim()
        If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
            sql = "EXECUTE sp_CONTABILIDAD_CHEQUE_EMERGENCIA_IUD " & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ",@CHEQUE = " & Me.txtCheque.Text & vbCrLf
            sql &= ",@PERSONA = '" & Me.lblSocio.Text & "'" & vbCrLf
            sql &= ",@MONTO = " & Monto & vbCrLf
            sql &= ",@MONTO_LETRAS = '" & EnLetras & "'" & vbCrLf
            sql &= ",@CONCEPTO = '" & Me.txtConcepto.Text & "'" & vbCrLf
            sql &= ",@FECHA_CONTABLE = '" & Format(Me.dpFECHA.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@PARTIDA_LIQUIDADA = 1" & vbCrLf
            sql &= ",@BANCO = " & Me.cmbBANCO.SelectedValue & vbCrLf
            sql &= ",@CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & Me.lblLIBRO_CONTABLE.Text & vbCrLf
            sql &= ",@CUENTA = " & Me.lblCUENTA.Text & vbCrLf
            sql &= ",@TRANSACCION = 0" & vbCrLf
            sql &= ",@PARTIDA = " & Me.txtPartida.Text & vbCrLf
            sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            sql &= ",@ACCION = 'I'"
            A = PC.ejecutarComandoSql(New SqlCommand(sql))
            If A > 0 Then
                Me.dgvCheques.Rows.Add(False, Me.txtCheque.Text, Me.lblSocio.Text, Monto, Me.chkNoNeg.Checked, EnLetras, Me.dpFECHA.Value)
            Else
                MsgBox("El Cheque No Fue Guardado", MsgBoxStyle.Information, "Guardar Cheque")
            End If
        Else
            A = 1
        End If
        Return A
    End Function

    Private Function GeneraCorrelativo(ByVal Compañia, ByVal TipoDocumento, ByVal Año, ByVal Mes) As Integer
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS" & vbCrLf
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
            sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO_IUD " & vbCrLf
            sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            sql &= ",@TIPO_DOCUMENTO = " & TipoDocumento & vbCrLf
            sql &= ",@DOCUMENTO      = '" & Documento & "'" & vbCrLf
            sql &= ",@TIPO_PARTIDA   = " & TipoPartida & vbCrLf
            sql &= ",@PARTIDA        = " & Partida & vbCrLf
            sql &= ",@FECHA_CONTABLE = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@CONCEPTO       = '" & Concepto & "'" & vbCrLf
            sql &= ",@ANULADA        = " & Anulada & vbCrLf
            sql &= ",@TRANSACCION_ANULA = " & AnuladaPor & vbCrLf
            sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            sql &= ",@IUD            = '" & IUD & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
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

    Private Sub GenerarCheque()
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
        For i As Integer = 0 To Me.dgvCheques.Rows.Count - 1
            chequeTable.Rows.Add(Me.dgvCheques.Rows(i).Cells("numcheque").Value, Me.dgvCheques.Rows(i).Cells("nombre").Value, Me.dgvCheques.Rows(i).Cells("montochq").Value, Me.dgvCheques.Rows(i).Cells("montoletras").Value, Me.dgvCheques.Rows(i).Cells("noneg").Value, Me.dgvCheques.Rows(i).Cells("fecha").Value)
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
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GenerarCheque()
    End Sub
End Class