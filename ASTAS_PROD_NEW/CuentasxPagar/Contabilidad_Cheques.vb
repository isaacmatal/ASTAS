Imports System.Data.SqlClient

Public Class Contabilidad_Cheques
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim CnnStrBldr As New SqlConnectionStringBuilder
    Dim Proveedor As Integer
    Dim Identifica As String = System.Guid.NewGuid().ToString()
    Dim jclass As New jarsClass
    Dim tipCtaEmpresa As String
    Dim GenRemesa As New generarRemesa
    Dim NumTran, Cheque As Integer
    Dim Transaccion As String = String.Empty
    Dim codBancoProv As Integer = 0
    Dim frmVer As New frmReportes_Ver

    Private Sub Contabilidad_Cheques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBancos(Compañia)
        CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 4)
        CargaCuentaContable(Compañia, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        CargaProveedores()
        BuscarOC()
        CnnStrBldr.UserID = UsuarioDB
        CnnStrBldr.Password = PasswordDB
        CnnStrBldr.DataSource = Servidor
        CnnStrBldr.InitialCatalog = BaseDatos
        Me.cmbPROVEEDOR.SelectedIndex = -1
        Me.cmbBANCO.SelectedIndex = -1
        Iniciando = False
        Me.cmbPROVEEDOR.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargaProveedores()
        Dim Table As DataTable
        Try
            Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @SIUD = 'CXP'"
            Table = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbPROVEEDOR.DataSource = Table
            Me.cmbPROVEEDOR.ValueMember = "PROVEEDOR"
            Me.cmbPROVEEDOR.DisplayMember = "NOMBRE_PROVEEDOR"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBancos(ByVal Compañia)
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_BANCOS " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@BANCO    = 0" & vbCrLf
            Sql &= ",@BANDERA  = 3" & vbCrLf
            Table = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBANCO.DataSource = Table
            Me.cmbBANCO.ValueMember = "Banco"
            Me.cmbBANCO.DisplayMember = "Nombre Banco"
            Me.cmbBANCO.SelectedIndex = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasBancarias(ByVal Compañia, ByVal Banco, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_BANCOS" & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@BANCO    = " & Banco & vbCrLf
            Sql &= ",@BANDERA  = " & Bandera & vbCrLf
            Table = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCUENTA_BANCARIA.DataSource = Table
            Me.cmbCUENTA_BANCARIA.ValueMember = "Cuenta"
            Me.cmbCUENTA_BANCARIA.DisplayMember = "Descripción Cuenta"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentaContable(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Bandera)
        Dim TblCtas As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@BANCO           = " & Banco & vbCrLf
            Sql &= ",@CUENTA_BANCARIA = '" & CuentaBancaria & "'" & vbCrLf
            Sql &= ",@BANDERA         = " & Bandera & vbCrLf
            TblCtas = jclass.obtenerDatos(New SqlCommand(Sql))
            If TblCtas.Rows.Count > 0 Then
                Me.lblCUENTA_COMPLETA.Text = TblCtas.Rows(0).Item("CUENTA_COMPLETA")
                Me.lblCUENTA.Text = TblCtas.Rows(0).Item("CUENTA")
                Me.lblLIBRO_CONTABLE.Text = TblCtas.Rows(0).Item("LIBRO_CONTABLE")
                tipCtaEmpresa = TblCtas.Rows(0).Item("DESCRIPCION_TIPO_CUENTA_BANCARIA")
            Else
                Me.lblCUENTA_COMPLETA.Text = ""
                Me.lblCUENTA.Text = "0"
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarOC()
        Dim Table As DataTable
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA " & vbCrLf
            Sql &= "  @COMPAÑIA         = " & Compañia & vbCrLf
            Sql &= ", @BODEGA           = 999" & vbCrLf
            Sql &= ", @ORDEN_COMPRA     = 0" & vbCrLf
            Sql &= ", @NOMBRE_PROVEEDOR = '" & Identifica & "'" & vbCrLf
            Sql &= ", @NOMBRE_COMERCIAL = '" & Me.cmbPROVEEDOR.SelectedValue & "'" & vbCrLf
            Sql &= ", @NIT              = ''" & vbCrLf
            Sql &= ", @NRC              = ''" & vbCrLf
            Sql &= ", @FECHA_INICIAL    = '01/01/2011'" & vbCrLf
            Sql &= ", @FECHA_FINAL      = '" & Format(Me.dpFechaHasta.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @BANDERA          = 5"
            Table = jclass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvOrdenesCompra.DataSource = Table
            Me.Label3.Text = "Valor a procesar: $ 0.00"
            Me.chkTodas.Checked = False
            FormatoGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FormatoGrid()
        For i As Integer = 0 To Me.dgvOrdenesCompra.Columns.Count - 1
            If i > 0 Then
                If i <> 12 Then
                    Me.dgvOrdenesCompra.Columns.Item(i).ReadOnly = True
                End If
            End If
        Next
        For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
            Me.dgvOrdenesCompra.Rows(i).Cells(12).Value = Me.dgvOrdenesCompra.Rows(i).Cells(11).Value
        Next
        Me.dgvOrdenesCompra.Columns(0).Width = 30 'checkbox
        Me.dgvOrdenesCompra.Columns(1).Width = 60 'OC#
        Me.dgvOrdenesCompra.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(2).Width = 70 'Fecha CCF
        Me.dgvOrdenesCompra.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(3).Width = 60 'CCF#
        Me.dgvOrdenesCompra.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(4).Width = 60 'Sub Total
        Me.dgvOrdenesCompra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(5).Width = 60 'IVA
        Me.dgvOrdenesCompra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(6).Width = 60 'Total
        Me.dgvOrdenesCompra.Columns(6).DefaultCellStyle.ForeColor = Color.Blue
        Me.dgvOrdenesCompra.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(7).Width = 60 'Percepcion
        Me.dgvOrdenesCompra.Columns(7).DefaultCellStyle.ForeColor = Color.Red
        Me.dgvOrdenesCompra.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(8).Width = 60 'Retencion ISR
        Me.dgvOrdenesCompra.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(9).Width = 60 'Total Compra
        Me.dgvOrdenesCompra.Columns(9).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvOrdenesCompra.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvOrdenesCompra.Columns(10).Visible = False 'Codigo Bodega

        Me.dgvOrdenesCompra.Columns(11).Width = 60 'Saldo Pendiente
        Me.dgvOrdenesCompra.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvOrdenesCompra.Columns(12).Width = 60 'Valor A Pagar
        Me.dgvOrdenesCompra.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvOrdenesCompra.Columns(13).Width = 150 'Bodega desc
        Me.dgvOrdenesCompra.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.dgvOrdenesCompra.Columns(14).Width = 60 'Días Crédito
        Me.dgvOrdenesCompra.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(15).Width = 70 'Usuario Autorización
        Me.dgvOrdenesCompra.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(16).Width = 80 'Fecha Pago
        Me.dgvOrdenesCompra.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvOrdenesCompra.Columns(17).Width = 80 'Fecha Recepcion
        Me.dgvOrdenesCompra.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Function Mantenimiento_Cheques(ByVal OC As Integer, ByVal Bodega As Integer, ByVal TotDoc As Double, ByVal TotPagado As Double, ByVal docto As Integer, ByVal IUD As String) As Boolean
        Dim Result As Boolean = False
        Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD" & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ", @ORDEN_COMPRA = " & OC & vbCrLf
        Sql &= ", @BODEGA = " & Bodega & vbCrLf
        Sql &= ", @CHEQUE = " & Cheque & vbCrLf
        Sql &= ", @SUBTOTAL = 0" & vbCrLf
        Sql &= ", @IVA = 0" & vbCrLf
        Sql &= ", @TOTAL = " & TotPagado & vbCrLf
        Sql &= ", @RETENCION = 0" & vbCrLf
        Sql &= ", @TOTAL_FINAL = " & TotDoc & vbCrLf
        Sql &= ", @DOCUMENTO = " & docto & vbCrLf
        Sql &= ", @BANCO = " & cmbBANCO.SelectedValue & vbCrLf
        Sql &= ", @CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
        Sql &= ", @LIBRO_CONTABLE = " & Me.lblLIBRO_CONTABLE.Text & vbCrLf
        Sql &= ", @CUENTA = " & Val(Me.lblCUENTA.Text) & vbCrLf
        Sql &= ", @TRANSACCION = " & Val(Transaccion) & vbCrLf
        Sql &= ", @PARTIDA = " & Val(Me.txtPartida.Text) & vbCrLf
        Sql &= ", @FECHA_CONTABLE = '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ", @ORDENES_COMPRA = '" & Identifica & "'" & vbCrLf
        Sql &= ", @USUARIO  = '" & Usuario & "'" & vbCrLf
        Sql &= ", @IUD = '" & IUD & "'" & vbCrLf
        If jclass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            Result = True
        Else
            Result = False
        End If
        Return Result
    End Function

    Private Sub cmbPROVEEDOR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPROVEEDOR.SelectedIndexChanged
        If Iniciando = False Then
            Proveedor = Me.cmbPROVEEDOR.SelectedValue
            codBancoProv = jclass.obtenerEscalar("SELECT BANCO FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = " & Compañia & " AND PROVEEDOR = " & Me.cmbPROVEEDOR.SelectedValue)
            If codBancoProv = 0 Then
                Me.rbCheque.Checked = True
                Me.rbRemesa.Enabled = False
            Else
                Me.rbRemesa.Enabled = True
                Me.rbRemesa.Checked = True
            End If
            Me.cmbBANCO.SelectedValue = codBancoProv
            BuscarOC()
        End If
    End Sub

    Private Sub btnRemesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If Me.cmbBANCO.SelectedValue = 0 Then
            MsgBox("Debe elegir un banco", MsgBoxStyle.Information, "Cuentas por Pagar")
            Return
        End If
        If Me.rbCheque.Checked Then
            generaCheque()
        Else
            If Me.dgvCheques.Rows.Count = 0 Then
                generaRemesa()
            Else
                MsgBox("Debe imprimir los cheques generados antes" & vbCrLf & "de procesar pagos con remesas.", MsgBoxStyle.Information, "Cuentas por Pagar")
            End If
        End If
    End Sub

    Private Function PartidaContable() As Boolean
        Dim numPartida As Integer = Val(Me.txtPartida.Text)
        If numPartida > 0 Then
            NumTran = jclass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PARTIDA = " & numPartida & " AND MONTH(FECHA_CONTABLE) = " & Me.dtpFechaProceso.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dtpFechaProceso.Value.Year & " AND COMPAÑIA = " & Compañia)
            If NumTran = 0 Then
                MsgBox("No se encontró el número de partida.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                Return False
            Else
                Transaccion = NumTran
                If jclass.obtenerEscalar("SELECT PROCESADO FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE TRANSACCION = " & NumTran & " AND COMPAÑIA = " & Compañia) Then
                    MsgBox("Partida ya está actualizada.", MsgBoxStyle.Information, "NUMERO PARTIDA NO VALIDO")
                    Return False
                End If
                If jclass.obtenerEscalar("SELECT COUNT(TRANSACCION) FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion) > 0 Then
                    If MsgBox("Al procesar eliminará los registros existentes de la Partida #" & Me.txtPartida.Text & vbCrLf & "¿Está seguro(a) que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.No Then
                        MsgBox("Proceso cancelado por usuario.", MsgBoxStyle.Information, "Mensaje")
                        Return False
                    Else
                        jclass.ejecutarComandoSql(New SqlCommand("DELETE FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Transaccion))
                    End If
                End If
            End If
        Else
            If MsgBox("No ha ingresado un número de partida." & vbCrLf & vbCrLf & "¿Desea Crear la partida automaticamente?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Return False
            Else
                '***************************************************************
                If jclass.ValidaCierreContable(Compañia, CInt(Me.lblLIBRO_CONTABLE.Text), Me.dtpFechaProceso.Value.Year, Me.dtpFechaProceso.Value.Month, "E") Then
                    Transaccion = GeneraCorrelativo(Compañia, "TRA", Me.dtpFechaProceso.Value.Year, Me.dtpFechaProceso.Value.Month).ToString
                    Me.txtPartida.Text = GeneraCorrelativo(Compañia, "PAR", Me.dtpFechaProceso.Value.Year, Me.dtpFechaProceso.Value.Month).ToString
                    If Mantenimiento_TransaccionE(Compañia, Transaccion, Val(lblLIBRO_CONTABLE.Text), 36, Trim(Me.txtCheque.Text), 1, Me.txtPartida.Text, Me.dtpFechaProceso.Value, "Pago a Proveedor " & Me.cmbPROVEEDOR.Text, "0", "0", "I") = 0 Then
                        MsgBox("Error al Generar Partida", MsgBoxStyle.Critical, "Partida Contable")
                        Return False
                    End If
                Else
                    Return False
                End If
                '***************************************************************
            End If
        End If
        Return True
    End Function

    Private Sub generaRemesa()
        Dim tblProv As DataTable
        Dim xmonto As Double = 0.0
        For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
            If Me.dgvOrdenesCompra.Rows(i).Cells(0).Value Then
                xmonto += Me.dgvOrdenesCompra.Rows(i).Cells(12).Value
            End If
        Next
        If xmonto = 0 Then
            MsgBox("No hay nada que procesar")
            Return
        End If
        Sql = "SELECT P.BANCO, B.DESCRIPCION_BANCO, P.CUENTA, P.NIT, (SELECT UPPER(DESCRIPCION_TIPO_CUENTA_BANCARIA) FROM [dbo].[CONTABILIDAD_CATALOGO_BANCOS_TIPO_CUENTA] WHERE COMPAÑIA = P.COMPAÑIA AND TIPO_CUENTA_BANCARIA = P.TIPO_CUENTA) AS TIPO_CUENTA FROM CONTABILIDAD_CATALOGO_PROVEEDORES P, CONTABILIDAD_CATALOGO_BANCOS B WHERE P.COMPAÑIA = B.COMPAÑIA AND P.BANCO = B.BANCO AND P.COMPAÑIA =" & Compañia & " AND P.PROVEEDOR = " & Me.cmbPROVEEDOR.SelectedValue
        tblProv = jclass.obtenerDatos(New SqlCommand(Sql))
        Dim GenEncab As Boolean = True
        Dim montoBAC As Double = 0.0
        Dim corrBAC As String = String.Empty
        Dim Cuenta As Integer = 0
        If PartidaContable() Then
            Try
                For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
                    If Me.dgvOrdenesCompra.Rows(i).Cells(0).Value Then
                        If Not Mantenimiento_Cheques(Me.dgvOrdenesCompra.Rows(i).Cells(1).Value, _
                                              Me.dgvOrdenesCompra.Rows(i).Cells(10).Value, _
                                              Me.dgvOrdenesCompra.Rows(i).Cells(9).Value, _
                                              Me.dgvOrdenesCompra.Rows(i).Cells(12).Value, _
                                              Me.dgvOrdenesCompra.Rows(i).Cells(3).Value, "PAGADO") Then
                            Mantenimiento_Cheques(0, 0, 0, 0, 0, "REVERTIR")
                            Return
                        End If
                    End If
                Next
                montoBAC = xmonto 'jclass.obtenerEscalar("SELECT ISNULL(SUM(TOTAL_FINAL), 0.00) FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE IDENTIFICADOR = '" & Identifica & "' AND BANCO = 3")
                Cuenta = jclass.obtenerEscalar("SELECT COUNT(ORDEN_COMPRA) FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE IDENTIFICADOR = '" & Identifica & "' AND BANCO = 3")
                If GenEncab Then
                    If tblProv.Rows(0).Item("BANCO") = 3 Then
                        'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
                        corrBAC = CInt(jclass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                        corrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", corrBAC))
                        jclass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (corrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                        GenRemesa.EncabBAC = "B4978" & Format(corrBAC, "00000") & Format(Me.dtpFechaProceso.Value, "yyyyMMdd").PadLeft(33, " ") & (montoBAC * 100).ToString().PadLeft(13, " ") & Cuenta.ToString().PadLeft(5, " ")
                        GenRemesa.setEncab = GenEncab
                        GenEncab = False
                    End If
                End If
                GenRemesa.Bloque = Me.cmbCUENTA_BANCARIA.Text & "_" & Identifica
                GenRemesa.TipoTran = "PAGOS PROVEEDORES"
                GenRemesa.ctaSocio = tblProv.Rows(0).Item("CUENTA")
                GenRemesa.bco = tblProv.Rows(0).Item("BANCO")
                GenRemesa.monto = xmonto
                GenRemesa.NITSocio = tblProv.Rows(0).Item("NIT")
                GenRemesa.TipCta = tblProv.Rows(0).Item("TIPO_CUENTA")
                GenRemesa.FechaDep = Format(Me.dtpFechaProceso.Value, "yyyyMMdd")
                GenRemesa.ubicacion = "000"
                GenRemesa.socio = Me.cmbPROVEEDOR.Text
                GenRemesa.cod_Prov = Me.cmbPROVEEDOR.SelectedValue
                GenRemesa.cta_proveedor = Me.cmbCUENTA_BANCARIA.SelectedValue
                GenRemesa.cta_proveedor_tipo = tipCtaEmpresa
                GenRemesa.movRemesa = "CXP"
                GenRemesa.recibirParametros(Compañia, tblProv.Rows(0).Item("BANCO").ToString, Me.lblCUENTA.Text, Me.cmbPROVEEDOR.SelectedValue.ToString, Me.cmbPROVEEDOR.SelectedValue.ToString, Me.cmbPROVEEDOR.SelectedValue.ToString, "PAGO_PROV")
                Shell("explorer.exe root = " & GenRemesa.ruta.Substring(0, GenRemesa.ruta.LastIndexOf("\")), vbNormalFocus)
                detallePda(9)
                detallePda(10)
                Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, "Pago a Proveedor ", "A", Monto, "A")
                jclass.ejecutarComandoSql(New SqlCommand(Sql))
                Dim rpt As New Contabilidad_CxP_Carta_Remesas
                Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA" & vbCrLf
                Sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
                Sql &= ",@BODEGA           = 0" & vbCrLf
                Sql &= ",@ORDEN_COMPRA     = 0" & vbCrLf
                Sql &= ",@NOMBRE_PROVEEDOR = '" & Identifica & "'" & vbCrLf
                Sql &= ",@NOMBRE_COMERCIAL = ''" & vbCrLf
                Sql &= ",@NIT              = ''" & vbCrLf
                Sql &= ",@NRC              = ''" & vbCrLf
                Sql &= ",@FECHA_INICIAL    = '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "'" & vbCrLf
                Sql &= ",@FECHA_FINAL      = '07/02/2016'" & vbCrLf
                Sql &= ",@BANDERA          = 11" & vbCrLf
                rpt.SetDataSource(jclass.obtenerDatos(New SqlCommand(Sql)))
                Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.Section2.ReportObjects.Item("txtEmpresa")
                txtObj.Text = Descripcion_Compañia
                frmVer.crvReporte.ReportSource = rpt
                frmVer.ShowDialog()
                If CInt(Transaccion) > 0 Then
                    frmVer.CargaPartida(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, Transaccion, Me.dtpFechaProceso.Value.Year, Me.dtpFechaProceso.Value.Month, 1)
                    frmVer.ShowDialog()
                End If
                Me.txtPartida.Clear()
            Catch ex As Exception
                jclass.msjError(ex, "Cuentas por Pagar")
                Mantenimiento_Cheques(0, 0, 0, 0, 0, "REVERTIR")
            End Try
            Identifica = System.Guid.NewGuid().ToString()
            BuscarOC()
        End If
    End Sub

    Private Function detallePda(ByVal Bandera As Integer) As Integer
        Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA" & vbCrLf
        Sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
        Sql &= ",@BODEGA           = " & Transaccion & vbCrLf
        Sql &= ",@ORDEN_COMPRA     = " & Me.txtPartida.Text & vbCrLf
        Sql &= ",@NOMBRE_PROVEEDOR = '" & Usuario & "'" & vbCrLf
        Sql &= ",@NOMBRE_COMERCIAL = '" & Identifica & "'" & vbCrLf
        Sql &= ",@NIT              = ''" & vbCrLf
        Sql &= ",@NRC              = ''" & vbCrLf
        Sql &= ",@FECHA_INICIAL    = '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ",@FECHA_FINAL      = '07/02/2016'" & vbCrLf
        Sql &= ",@BANDERA          = " & Bandera & vbCrLf
        Return jclass.ejecutarComandoSql(New SqlCommand(Sql))
    End Function

    Private Sub generaCheque()
        Dim xmonto As Double = 0.0
        If Me.dgvOrdenesCompra.Rows.Count > 0 Then
            Cheque = CInt(Val(Me.txtCheque.Text))
            If Cheque > 0 Then
                If PartidaContable() Then
                    For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
                        If Me.dgvOrdenesCompra.Rows(i).Cells(0).Value Then
                            If Not Mantenimiento_Cheques(Me.dgvOrdenesCompra.Rows(i).Cells(1).Value, _
                                                  Me.dgvOrdenesCompra.Rows(i).Cells(10).Value, _
                                                  Me.dgvOrdenesCompra.Rows(i).Cells(9).Value, _
                                                  Me.dgvOrdenesCompra.Rows(i).Cells(12).Value, _
                                                  Me.dgvOrdenesCompra.Rows(i).Cells(3).Value, "PAGADO") Then
                                Mantenimiento_Cheques(0, 0, 0, 0, 0, "REVERTIR")
                                Return
                            Else
                                xmonto += Me.dgvOrdenesCompra.Rows(i).Cells(12).Value
                            End If
                        End If
                    Next
                    Monto = xmonto
                    If GuardarCheque() > 0 Then
                        detallePda(9)
                        detallePda(10)
                        Mantenimiento_TransaccionL(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, 0, 0, Me.lblCUENTA.Text, "Pago a Proveedor " & Me.cmbPROVEEDOR.Text & ", Chq.#" & Me.txtCheque.Text, "A", Monto, "A")
                        Me.txtPartida.Clear()
                        Me.txtCheque.Clear()
                        jclass.ejecutarComandoSql(New SqlCommand(Sql))
                        Identifica = System.Guid.NewGuid().ToString()
                        If CInt(Transaccion) > 0 Then
                            frmVer.CargaPartida(Compañia, Me.lblLIBRO_CONTABLE.Text, Transaccion, Transaccion, Me.dtpFechaProceso.Value.Year, Me.dtpFechaProceso.Value.Month, 1)
                            frmVer.ShowDialog()
                        End If
                    Else
                        Mantenimiento_Cheques(0, 0, 0, 0, 0, "REVERTIR")
                    End If
                End If
            Else
                MsgBox("Ingrese un número de cheque.", MsgBoxStyle.Information, "Generar Cheque")
                Me.txtCheque.Focus()
                Return
            End If
        End If
        Cheque = 0
        BuscarOC()
    End Sub

    Private Function GuardarCheque() As Integer
        Dim A As Integer
        Dim VLetras As New NumeroLetras
        Dim EnLetras As String = VLetras.Letras(Format(Monto, "0.00")).Replace("US DOLARES", "").Trim()
        Sql = "EXECUTE sp_CONTABILIDAD_CHEQUE_EMERGENCIA_IUD " & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ",@CHEQUE = " & Me.txtCheque.Text & vbCrLf
        Sql &= ",@PERSONA = '" & Me.cmbPROVEEDOR.Text & "'" & vbCrLf
        Sql &= ",@MONTO = " & Monto & vbCrLf
        Sql &= ",@MONTO_LETRAS = '" & EnLetras & "'" & vbCrLf
        Sql &= ",@CONCEPTO = 'Pago a proveedor " & Me.cmbPROVEEDOR.Text & "'" & vbCrLf
        Sql &= ",@FECHA_CONTABLE = '" & Format(Me.dtpFechaProceso.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ",@PARTIDA_LIQUIDADA = 1" & vbCrLf
        Sql &= ",@BANCO = " & Me.cmbBANCO.SelectedValue & vbCrLf
        Sql &= ",@CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
        Sql &= ",@LIBRO_CONTABLE = " & Me.lblLIBRO_CONTABLE.Text & vbCrLf
        Sql &= ",@CUENTA = " & Me.lblCUENTA.Text & vbCrLf
        Sql &= ",@TRANSACCION = " & Transaccion & vbCrLf
        Sql &= ",@PARTIDA = " & Me.txtPartida.Text & vbCrLf
        Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
        Sql &= ",@ACCION = 'I'"
        A = jclass.ejecutarComandoSql(New SqlCommand(Sql))
        If A > 0 Then
            Me.dgvCheques.Rows.Add(False, Me.txtCheque.Text, Me.cmbPROVEEDOR.Text, Monto, Me.chkNoNeg.Checked, EnLetras, Me.dtpFechaProceso.Value)
        Else
            MsgBox("El Cheque No Fue Guardado", MsgBoxStyle.Information, "Guardar Cheque")
        End If
        Return A
    End Function

    Private Sub dpFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaHasta.ValueChanged
        BuscarOC()
    End Sub

    Private Sub dgvOrdenesCompra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrdenesCompra.CellContentClick
        Dim xmonto As Double = 0.0
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 0 Then
                If Me.dgvOrdenesCompra.CurrentRow.Cells(0).Value Then
                    dgvOrdenesCompra.CurrentRow.Cells(0).Value = False
                Else
                    dgvOrdenesCompra.CurrentRow.Cells(0).Value = True
                End If
            End If
            totalPago()
        End If
    End Sub

    Private Function totalPago() As Double
        Dim xmonto As Double = 0.0
        For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
            If Me.dgvOrdenesCompra.Rows(i).Cells(0).Value Then
                xmonto += Me.dgvOrdenesCompra.Rows(i).Cells(12).Value
            End If
        Next
        Me.Label3.Text = "Valor a procesar: $ " & Format(xmonto, "#,##0.00")
        Return xmonto
    End Function

    Private Sub dgvOrdenesCompra_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrdenesCompra.CellEndEdit
        If dgvOrdenesCompra.Rows(e.RowIndex).Cells(12).Value < 0 Then
            MsgBox("Valor a pagar no puede ser menor que cero", MsgBoxStyle.Critical, "Valor A Pagar NO válido")
            dgvOrdenesCompra.Rows(e.RowIndex).Cells(12).Value = dgvOrdenesCompra.Rows(e.RowIndex).Cells(9).Value
            Return
        End If
        If dgvOrdenesCompra.Rows(e.RowIndex).Cells(12).Value > dgvOrdenesCompra.Rows(e.RowIndex).Cells(11).Value Then
            MsgBox("Valor a pagar no puede ser mayor al saldo", MsgBoxStyle.Critical, "Valor A Pagar NO válido")
            dgvOrdenesCompra.Rows(e.RowIndex).Cells(12).Value = dgvOrdenesCompra.Rows(e.RowIndex).Cells(9).Value
            Return
        End If
        totalPago()
    End Sub

    Private Sub dgvOrdenesCompra_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOrdenesCompra.Sorted
        Me.Label3.Text = "Valor a procesar: $ 0.00"
    End Sub

    Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        Dim xmonto As Double = 0.0
        For i As Integer = 0 To Me.dgvOrdenesCompra.Rows.Count - 1
            Me.dgvOrdenesCompra.Rows(i).Cells(0).Value = Me.chkTodas.Checked
            xmonto += Me.dgvOrdenesCompra.Rows(i).Cells(12).Value
        Next
        If Me.chkTodas.Checked Then
            totalPago()
        Else
            Me.Label3.Text = "Valor a procesar: $ 0.00"
        End If
    End Sub

    Private Sub rbRemesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRemesa.CheckedChanged
        If rbRemesa.Checked Then
            Me.cmbBANCO.SelectedValue = codBancoProv
            Me.GroupBox1.Height = 94
            'Me.dgvOrdenesCompra.SetBounds(11, Me.dgvOrdenesCompra.Location.Y - 30, Me.dgvOrdenesCompra.Size.Width, Me.dgvOrdenesCompra.Size.Height + 18)
            'Me.dgvCheques.SetBounds(Me.dgvCheques.Location.X, 111, Me.dgvCheques.Size.Width, 188)
            Me.cmbBANCO.Enabled = False
        End If
    End Sub

    Private Sub rbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheque.CheckedChanged
        If rbCheque.Checked Then
            Me.GroupBox1.Height = 122
            'Me.dgvOrdenesCompra.SetBounds(11, Me.dgvOrdenesCompra.Location.Y + 30, Me.dgvOrdenesCompra.Size.Width, Me.dgvOrdenesCompra.Size.Height - 18)
            'Me.dgvCheques.SetBounds(Me.dgvCheques.Location.X, 139, Me.dgvCheques.Size.Width, 160)
            Me.cmbBANCO.Enabled = True
        End If
    End Sub

    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, IIf(Me.rbRemesa.Checked, 4, 5))
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
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub txtCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheque.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnImpCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpCheque.Click
        Dim chequeTable As New DataTable
        Dim Rpts As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
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
        While Me.dgvCheques.Rows.Count > 0
            Me.dgvCheques.Rows.RemoveAt(0)
        End While
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

    Private Sub cmbPROVEEDOR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPROVEEDOR.LostFocus
        Try
            If Me.cmbPROVEEDOR.SelectedValue Is Nothing Then
                If Me.cmbPROVEEDOR.Items.Count > 0 Then
                    Me.cmbPROVEEDOR.SelectedValue = Proveedor
                Else
                    Me.cmbPROVEEDOR.ResetText()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub Contabilidad_Cheques_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class