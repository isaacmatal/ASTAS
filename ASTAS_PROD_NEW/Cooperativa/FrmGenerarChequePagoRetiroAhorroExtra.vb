Imports System.Data.sqlClient

Public Class FrmGenerarChequePagoRetiroAhorroExtra

    'Constructor
    Dim Clase_letras_numeros As New NumeroLetras
    Dim CantidadLetras As String
    Dim PC As New jarsClass
    Dim Cheque As Integer = 0
    Dim row As DataRow
    Dim TableRetiros As DataTable
    Dim Permitir As String
    Dim CnnStrBldr As New SqlConnectionStringBuilder
    Dim OrigenEmpl As Integer

    'Variables
    Dim sql As String
    Dim Iniciando, RetiroEmpresa As Boolean
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
    Public Nombre_Socio, cpus As String
    'Para cuando se generara un documento
    Public NumSolicitud As Integer
    Public Periodo As String = "Retiro Ext"
    Public MontoFrm, TotDeuda, Seguro As Double

    Private Sub FrmGenerarChequePagoRetiroAhorroExtra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        sql = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_RETIROS]" & vbCrLf
        sql &= " @RETIRO = " & Me.lblSolicitud.Text & "," & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
        sql &= " @SIUD = 'S'"
        Comando_.CommandText = sql
        Table = PC.obtenerDatos(Comando_)
        row = Table.Rows(0)
        Me.lblCantidad.Text = Format(Table.Rows(0).Item("CANTIDAD"), "0.00")
        Me.lblCodigoAS.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
        Me.TxtBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
        Me.lblSocio.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
        OrigenEmpl = Table.Rows(0).Item("ORIGEN")
        cerrar = Table.Rows(0).Item("RETIRO_ASOCIACION")
        TotDeuda = Table.Rows(0).Item("TOTAL_DEUDAS")
        RetiroEmpresa = Table.Rows(0).Item("CUENTA_CONTABLE_BANCO")
        If cerrar Then
            Periodo = "Retiro Aso"
            Me.txtConcepto.Text = "Liquidación de Ahorros por Retiro de la " & IIf(RetiroEmpresa, "Empresa", "Asociación")
        Else
            Periodo = "Retiro Ext"
            Me.txtConcepto.Text = "Retiro de Ahorro Extraordinario"
        End If
        sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_CHEQUES_IUD]" & vbCrLf
        sql &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
        sql &= " @SOLICITUD = " & ParamcodSolicitud & "," & vbCrLf
        sql &= " @PERIODO = '" & Periodo & "'," & vbCrLf
        sql &= " @BANDERA = 'T'"
        Comando_.CommandText = sql
        Table = PC.obtenerDatos(Comando_)
        Me.lblPagado.Text = Format(Table.Rows(0).Item(0), "0.00")
        TotalPendiente = Val(Me.lblCantidad.Text) - Table.Rows(0).Item(0)
        Me.btnGenerar.Enabled = (TotalPendiente > 0)
        Me.txtMonto.Text = Format(TotalPendiente, "0.00")
        Comando_.CommandText = "SELECT BANCO, DESCRIPCION_BANCO, CUENTA_BANCARIA FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.TxtBuxis.Text
        Table = PC.obtenerDatos(Comando_)
        Me.lblBancoSocio.Tag = Table.Rows(0).Item(0)
        Me.lblBancoSocio.Text = Table.Rows(0).Item(1)
        Me.lblCtaSocio.Text = Table.Rows(0).Item(2)
        Me.chkNoNeg.Checked = (Val(Me.txtMonto.Text) > 150.0)
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
        Dim Rpt As New rpt_reporte_cooperativa_retiro_ahorro_recibo1
        Dim frmver As New frmReportes_Ver
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim ctaOrd, ctaExt As Integer
        'En esta variable si el documento es un cheque se guarda el correlativo del cheque, mientras que si es una remesa
        'guardamos el mismo numero de solicitud
        Dim Documento As Integer = 0
        'El tipo de documento se deterima si es cheque o remesa, si es cheque seria el 23, si es remesa es 22
        'Variables para la partida contable
        Dim numPartida As Integer = Val(Me.txtPartida.Text)
        Dim NumTran As Integer
        Dim Transaccion As String = String.Empty
        Dim tipoDoc As Integer = 0
        Table = PC.obtenerDatos(New SqlCommand("SELECT CUENTA_CONTABLE_AHORROS_ORD, CUENTA_CONTABLE_AHORROS_EXTORD FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & OrigenEmpl))
        If Table.Rows.Count > 0 Then
            ctaOrd = Table.Rows(0).Item(0)
            ctaExt = Table.Rows(0).Item(1)
        Else
            ctaOrd = 0
            ctaExt = 0
        End If
        'Comprobamos que no haya ningun campo vacio
        If validaDatosCamposCMB() = True Then
            Me.txtConcepto.Text &= " chq.#" & Me.txtCheque.Text & " - " & Me.lblSocio.Text
            Me.lblProcesando.Visible = True
            Me.btnGenerar.Enabled = False
            Documento = GeneraCorrelativoCheque()
            Cheque = CInt(Val(Me.txtCheque.Text))
            If Cheque > 0 Then
                Monto = Val(Me.txtMonto.Text) - IIf(Me.chkPapeleria.Checked, 0.25, 0)
                PC.daFormatoMonto_RCR()
                PC.creaLineas_RCR()
                'Por el momento se desactiva la función de crear partida contable 2013-11-08
                'PC.Contabiliza_Partida_Automatica_Standard(Compañia, 0, tipoDoc _
                '                                  , PC.devuelveBcoOrigen(Compañia, Cod_Buxis, Cod_AS, 3), NumSolicitud _
                '                                  , Format(Me.dpFECHA.Value, "dd-MMM-yyyy HH:mm:ss"), Val(Me.lblCUENTA.Text), Documento, Val(Me.txtMonto.Text), Me.txtConcepto.Text)
                'Se genera nuevamente la partida 20/05/2015 pero ya no es automática
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
                If GuardarCheque() > 0 Then
                    If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", Monto, "E")
                        If Me.chkPapeleria.Checked Then
                            Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, PC.obtenerEscalar("SELECT CONVERT(INT, VALOR) AS CONSTANTE FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 23"), Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", 0.25, "E")
                        End If
                    End If
                    PC.mttoChequesProgSolicitudes(Compañia, Cheque, Val(Me.lblCantidad.Text), Val(Me.lblPagado.Text), _
                                                  Val(Me.txtMonto.Text), Me.dpFECHA.Value, Val(Me.lblSolicitud.Text), Me.TxtBuxis.Text, _
                                                  Me.lblCodigoAS.Text, IIf(cerrar, "Retiro Asoc.", "Retiro Ext"), Me.cmbBANCO.SelectedValue, Val(Me.lblCUENTA.Text), _
                                                  Me.cmbCUENTA_BANCARIA.SelectedValue, Me.cmbCHEQUERA.SelectedValue, _
                                                  Val(Me.lblLIBRO_CONTABLE.Text), "I", Me.lblSocio.Text, IIf(Me.chkPapeleria.Checked, 0.25, 0))
                End If
                'imprimirCheque(Cheque, Me.lblSocio.Text, Monto, Me.chkNoNeg.Checked)
            Else
                MsgBox("No se pudo generar el Cheque.", MsgBoxStyle.Critical, "Mensaje")
                Return
            End If
            'cmbCHEQUERA_SelectedIndexChanged(sender, e)
            sql = "UPDATE COOPERATIVA_SOCIO_RETIROS" & vbCrLf
            sql &= " SET BANCO_EMITIDO = " & Me.cmbBANCO.SelectedValue & "," & vbCrLf
            sql &= " CUENTA_EMITIDO = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'," & vbCrLf
            sql &= " NUMERO = " & Cheque & "," & vbCrLf
            sql &= " BANCO = 0," & vbCrLf
            sql &= " CUENTA = ''," & vbCrLf
            sql &= " TIPO_DOCUMENTO = 6," & vbCrLf
            sql &= " USUARIO_MODIFICACION  = '" & Usuario & "'," & vbCrLf
            sql &= " USUARIO_MODIFICACION_FECHA = GETDATE()" & vbCrLf
            sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            sql &= " AND RETIRO = " & Me.lblSolicitud.Text
            PC.Ejecutar_ConsultaSQL(sql)
            Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & Me.lblSolicitud.Text & ", " & Me.TxtBuxis.Text & ",'" & Me.lblCodigoAS.Text & "', 'Eliminar','" & CantidadLetras & "'"
            PC.ejecutarComandoSql(Comando_)
            If cerrar Then
                tipoDoc = 26
                CantidadLetras = Clase_letras_numeros.Letras(Format(row.Item("TOTAL_ESCOLARIDAD"), "0.00"))
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_IUD " & Compañia & "," & row.Item("CODIGO_EMPLEADO") & ",'" & row.Item("CODIGO_EMPLEADO_AS") & "',0,'" & Format(row.Item("INTERES_HASTA"), "dd/MM/yyyy") & "',10," & row.Item("TOTAL_AHORRO_ORDINARIO") * -1 & "," & row.Item("TOTAL_AHORRO_EXTRAORDINARIO") * -1 & ",0,0,'" & Usuario & "','I'"
                PC.ejecutarComandoSql(Comando_)
                Comando_.CommandText = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_AHORROS_IUD]" & vbCrLf
                Comando_.CommandText &= "	@COMPAÑIA = " & Compañia & "," & vbCrLf
                Comando_.CommandText &= "	@CODIGO_EMPLEADO = " & row.Item("CODIGO_EMPLEADO") & "," & vbCrLf
                Comando_.CommandText &= "	@CODIGO_EMPLEADO_AS = '" & row.Item("CODIGO_EMPLEADO_AS") & "'," & vbCrLf
                Comando_.CommandText &= "	@IUD = 'SR'"
                PC.ejecutarComandoSql(Comando_)
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS_ESCOLARIDAD 1," & row.Item("RETIRO") & "," & Compañia & "," & row.Item("CODIGO_EMPLEADO") & ",'" & row.Item("CODIGO_EMPLEADO_AS") & "'," & row.Item("TOTAL_AHORRO_ORDINARIO") & "," & row.Item("TOTAL_AHORRO_EXTRAORDINARIO") & "," & row.Item("TOTAL_ESCOLARIDAD") & "," & row.Item("TOTAL_RENTA") & ",'" & Usuario & "','" & CantidadLetras & "','I'"
                PC.ejecutarComandoSql(Comando_)
                CantidadLetras = Clase_letras_numeros.Letras(Me.txtMonto.Text)
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & row.Item("RETIRO") & ", " & row.Item("CODIGO_EMPLEADO") & ",'" & row.Item("CODIGO_EMPLEADO_AS") & "', 'Insertar','" & CantidadLetras & "'"
                PC.ejecutarComandoSql(Comando_)
                Comando_.CommandText = "UPDATE [COOPERATIVA_CATALOGO_SOCIOS] SET ESTATUS = " & IIf(RetiroEmpresa, "0", "1") & " WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Me.lblCodigoAS.Text & "' AND CODIGO_EMPLEADO = " & Me.TxtBuxis.Text
                PC.ejecutarComandoSql(Comando_)
                If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                    'registro ordinario partida contable
                    Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, Me.TxtBuxis.Text, ctaOrd, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "C", row.Item("TOTAL_AHORRO_ORDINARIO"), "E")
                    If CDbl(row.Item("TOTAL_AHORRO_EXTRAORDINARIO")) > 0.0 Then
                        'registro extraordinario partida contable
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, Me.TxtBuxis.Text, ctaExt, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "C", row.Item("TOTAL_AHORRO_EXTRAORDINARIO"), "E")
                    End If
                End If
                If RetiroEmpresa Then
                    sql = "UPDATE CAFETERIA_EMPLEADOS_DESCUENTOS SET BLOQUEADOS = 1 WHERE CODIGO_EMPLEADO = " & Me.TxtBuxis.Text & " AND COMPAÑIA = " & Compañia
                    PC.Ejecutar_ConsultaSQL(sql)
                End If
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_CATALOGO_SOCIOS_ADD_SOCIEDAD" & vbCrLf
                Comando_.CommandText &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
                Comando_.CommandText &= " @CODIGOEMPLEADO = " & Me.TxtBuxis.Text & "," & vbCrLf
                Comando_.CommandText &= " @CODIGOEMPLEADOAS = '" & Me.lblCodigoAS.Text & "'," & vbCrLf
                Comando_.CommandText &= " @ESTADO = 0," & vbCrLf
                Comando_.CommandText &= " @MOTIVO = '" & row.Item("COMENTARIO") & "'," & vbCrLf
                Comando_.CommandText &= " @USUARIO = '" & Usuario & "'," & vbCrLf
                Comando_.CommandText &= " @SIUD = 'U'"
                PC.ejecutarComandoSql(Comando_)
                Mostrar_carta_retiro_asociacion(Me.TxtBuxis.Text, Me.lblCodigoAS.Text, Me.lblSolicitud.Text)
                If TotDeuda > 0 Then
                    CancelaDeudas(Me.lblCodigoAS.Text, Me.TxtBuxis.Text)
                    '-----
                    If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                        sql = " SELECT A.CUENTA, P.MONTO_PRESTAMO" & vbCrLf
                        sql &= "  FROM [dbo].[COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO] P, COOPERATIVA_CATALOGO_SOLICITUDES S, CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS A" & vbCrLf
                        sql &= " WHERE P.COMPAÑIA = S.COMPAÑIA AND P.PRESTAMO = S.DEDUCCION" & vbCrLf
                        sql &= "   AND S.COMPAÑIA = A.COMPAÑIA AND S.TIPO_DOCUMENTO = A.TIPO_DOCUMENTO " & vbCrLf
                        sql &= "   AND A.CENTRO_COSTO = CASE P.PRESTAMO WHEN 236 THEN 4 WHEN 257 THEN 2 ELSE 1 END " & vbCrLf
                        sql &= "   AND A.CARGO = 1" & vbCrLf
                        sql &= "   AND A.ORIGEN = " & OrigenEmpl & vbCrLf
                        sql &= "   AND P.DEDUCCION = " & Me.lblSolicitud.Text & vbCrLf
                        sql &= "   AND P.COMPAÑIA = " & Compañia & vbCrLf
                        Table = PC.obtenerDatos(New SqlCommand(sql))
                        For i As Integer = 0 To Table.Rows.Count - 1
                            Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, Me.TxtBuxis.Text, Table.Rows(i).Item("CUENTA"), Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", Table.Rows(i).Item("MONTO_PRESTAMO"), "E")
                        Next
                        If CDbl(row.Item("TOTAL_INTERESES")) > 0.0 Then
                            NumTran = PC.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 21")
                            Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, NumTran, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", CDbl(row.Item("TOTAL_INTERESES")), "E")
                        End If
                        If CDbl(row.Item("TOTAL_SEGURO_DEUDA")) > 0.0 Then
                            NumTran = PC.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 22")
                            Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, NumTran, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", CDbl(row.Item("TOTAL_SEGURO_DEUDA")), "E")
                        End If
                    End If
                    '-----
                End If
                If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                    If CDbl(row.Item("TOTAL_ESCOLARIDAD")) > 0.0 Then
                        NumTran = PC.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = " & IIf(RetiroEmpresa, "41", "40"))
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, NumTran, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "C", CDbl(row.Item("TOTAL_ESCOLARIDAD")), "E")
                    End If
                    If CDbl(row.Item("TOTAL_RENTA")) > 0.0 Then
                        NumTran = PC.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 42")
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, NumTran, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", CDbl(row.Item("TOTAL_RENTA")), "E")
                    End If
                End If
            Else
                tipoDoc = 25
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_IUD " & Compañia & "," & row.Item("CODIGO_EMPLEADO") & ",'" & row.Item("CODIGO_EMPLEADO_AS") & "',0,'" & Format(Me.dpFECHA.Value, "dd/MM/yyyy") & "',10,0," & (Val(Me.txtMonto.Text) * -1) & ",0,0,'" & Usuario & "','I'"
                PC.ejecutarComandoSql(Comando_)
                If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                    Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, Me.TxtBuxis.Text, ctaExt, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "C", row.Item("CANTIDAD"), "E")
                End If
                CantidadLetras = Clase_letras_numeros.Letras(Me.txtMonto.Text)
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & "," & Me.lblSolicitud.Text & "," & Me.TxtBuxis.Text & ",'" & Me.lblCodigoAS.Text & "','Insertar','" & CantidadLetras & "'"
                PC.ejecutarComandoSql(Comando_)
                Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & Me.lblSolicitud.Text & ", " & Me.TxtBuxis.Text & ",'" & Me.lblCodigoAS.Text & "', 'SE', 'Monto'"
                TableRetiros = PC.obtenerDatos(Comando_)
                Rpt.SetDataSource(TableRetiros)
                If OrigenEmpl = 5 Or OrigenEmpl = 6 Then
                    Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                    Rpt.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                    Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                    Rpt.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                    txtObj = Rpt.Section3.ReportObjects.Item("Text22")
                    txtObj.Text = "NIT 0501-200694-101-6"
                End If
                frmver.ReportesGenericos(Rpt)
                frmver.ShowDialog()
            End If
            If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, Trim(Me.txtConcepto.Text) & ", Chq.#" & Me.txtCheque.Text, "A", Me.txtMonto.Text, "A")
            End If
            cargarValores()
            If Val(Me.txtMonto.Text) <= 0 Then
                PC.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOCIO_RETIROS SET ESTADO = 3 WHERE COMPAÑIA = " & Compañia & " AND RETIRO = " & Me.lblSolicitud.Text)
            End If
            If Not (OrigenEmpl = 5 Or OrigenEmpl = 6) Then
                If CInt(Transaccion) > 0 Then
                    frmver.CargaPartida(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, Transaccion, Me.dpFECHA.Value.Year, Me.dpFECHA.Value.Month, 1)
                    frmver.ShowDialog()
                End If
            End If
            Me.lblProcesando.Visible = False
        End If
    End Sub

    Private Sub Mostrar_carta_retiro_asociacion(ByVal codBuxis As Integer, ByVal codAS As String, ByVal ID_retiro As String)
        ParamcodigoBux = codBuxis
        ParamcodigoAs = codAS
        Dim Prin As New frm_reporte_retiro_asociacion
        Prin.ID_Retiro = ID_retiro
        Prin.WindowState = FormWindowState.Maximized
        Prin.ShowDialog()
    End Sub

    Private Function eliminaProgramacionesNoDescontadas(ByVal solicitud As String) As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Dim Retorno As Integer = 0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD "
            Sql &= Compañia & ","
            Sql &= solicitud & ","
            Sql &= "'" & Usuario & "','E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Retorno = Comando_Track.ExecuteScalar()
            Comando_Track.CommandText = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET COMENTARIO_ANULADA = 'CANCELADO POR RETIRO ASOCIACION' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Retorno
    End Function

    Private Sub CancelaDeudas(ByVal CodAs As String, ByVal CodBuxis As Integer)
        Dim TableSolPend As DataTable
        Dim Linea As Integer
        Dim query As String
        Dim capital As Double
        Try
            Comando_.CommandText = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & CodAs & "', @CodigoBuxis = " & CodBuxis & ", @SIUD = 'TDXSOLEMP' "
            TableSolPend = PC.obtenerDatos(Comando_)
            For i As Integer = 0 To TableSolPend.Rows.Count - 1
                capital = CDbl(PC.obtenerEscalar("SELECT SUM (CAPITAL) FROM [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE] WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & TableSolPend.Rows(i).Item(0) & " AND CAPITAL_D = 0"))
                Linea = Me.eliminaProgramacionesNoDescontadas(TableSolPend.Rows(i).Item(0))
                Linea += 1
                query = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]" & vbCrLf
                query &= "([COMPAÑIA]" & vbCrLf
                query &= ",[NUMERO_SOLICITUD]" & vbCrLf
                query &= ",[LINEA]" & vbCrLf
                query &= ",[ENVIADA]" & vbCrLf
                query &= ",[RECIBIDA]" & vbCrLf
                query &= ",[FECHA_PAGO]" & vbCrLf
                query &= ",[SALDO_INI]" & vbCrLf
                query &= ",[CAPITAL]" & vbCrLf
                query &= ",[CAPITAL_D]" & vbCrLf
                query &= ",[INTERES]" & vbCrLf
                query &= ",[INTERES_D]" & vbCrLf
                query &= ",[SEG_DEUDA]" & vbCrLf
                query &= ",[SEG_DEUDA_D]" & vbCrLf
                query &= ",[CUOTA]" & vbCrLf
                query &= ",[CUOTA_D]" & vbCrLf
                query &= ",[SALDO_FIN]" & vbCrLf
                query &= ",[INTERES_ACUM]" & vbCrLf
                query &= ",[REPROGRAMADA]" & vbCrLf
                query &= ",[CUOTA_NO_DESCONTADA]" & vbCrLf
                query &= ",[USUARIO_CREACION]" & vbCrLf
                query &= ",[USUARIO_CREACION_FECHA]" & vbCrLf
                query &= ",[USUARIO_EDICION]" & vbCrLf
                query &= ",[USUARIO_EDICION_FECHA]" & vbCrLf
                query &= ",[COMENTARIO])" & vbCrLf
                query &= "VALUES" & vbCrLf
                query &= "(" & Compañia & vbCrLf
                query &= "," & TableSolPend.Rows(i).Item(0) & vbCrLf
                query &= "," & Linea & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",'" & Format(Me.dpFECHA.Value, "dd/MM/yyyy") & "'" & vbCrLf
                query &= "," & capital & vbCrLf
                query &= "," & capital & vbCrLf
                query &= ",1" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",1" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",1" & vbCrLf
                query &= "," & capital & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",'" & Usuario & "'" & vbCrLf
                query &= ",GETDATE()" & vbCrLf
                query &= ",'" & Usuario & "'" & vbCrLf
                query &= ",GETDATE()" & vbCrLf
                query &= ",'CANCELADO POR RETIRO DE " & IIf(RetiroEmpresa, "EMPRESA", "ASOCIACION") & " EL " & Format(Me.dpFECHA.Value, "dd/MM/yyyy") & "')"
                PC.Ejecutar_ConsultaSQL(query)
                'Comando_.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_DEUDA_PAGO_PR @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & CodAs & "', @CodigoBuxis = " & CodBuxis & ", @SOLICITUD = " & TableSolPend.Rows(i).Item(0) & ", @USUARIO = '" & Usuario & "', @SIUD = 'UDSP'"
                'PC.ejecutarComandoSql(Comando_)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                mensaje &= "No se cargaron todos los valores al cargar"
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
        'ImpCheque.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        'ImpCheque.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopeItaly
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
        FrmBuscarSol.Text = "Cooperativa - Búsqueda de Solicitudes de Retiro Ahorros Extra"
        FrmBuscarSol.Bandera = 3
        FrmBuscarSol.origenes = Permitir
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
            Me.lblSolicitud.Text = ParamcodSolicitud
            cargarValores()
        End If
    End Sub

    Private Sub FrmGenerarChequePagoRetiroAhorroExtra_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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