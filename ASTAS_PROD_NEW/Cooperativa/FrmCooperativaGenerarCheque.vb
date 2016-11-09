Imports System.Data.SqlClient
Public Class FrmCooperativaGenerarCheque
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim ProcesosContables As New jarsClass
    Public Compañia_Value As Integer
    Public VariasOC As Boolean

    'Agregado por Jonathan Peña
    Public varios_NumOCs(99), varios_Correlativo(99) As Integer
    Public varios_SubTotales(99), varios_IVA(99), varios_Totales(99), varios_Retenciones(99), varios_TotalesCheques(99) As Double
    Public j As Integer

    Private Sub FrmCooperativaGenerarCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompany(Usuario, 1)
        CargaBancos()
        CargaCuentasBancarias()
        CargaCuentaContable()
        CargaChequeras()
        CargaCentroCosto()
        cmbCENTRO_COSTO.SelectedValue = 1
        If ParamCodProvee = 0 Then
            Me.BtnBuscarProv.Enabled = True
        Else
            Me.BtnBuscarProv.Enabled = False
        End If
        If VariasOC = False Then
            Me.txtCONCEPTO.Text = " Pago Factura " & Trim(Me.TxtCreditoFiscal.Text) & " " & Format(Me.dpFECHA_OC.Value, "dd-MMM-yyyy").ToString
        Else
            Me.txtCONCEPTO.Text = " Pago Factura de OCs: " & Trim(Me.TxtCreditoFiscal.Text)
            For i As Integer = 0 To j - 1
                Me.txtCONCEPTO.Text &= varios_NumOCs(i) & ", "
            Next
            Me.txtCONCEPTO.Text &= Format(Me.dpFECHA_OC.Value, "dd-MMM-yyyy").ToString
        End If
        Me.cmbBANCO.Focus()
        Iniciando = False
    End Sub
    Private Sub CargaCompany(ByVal USUARIO, ByVal BANDERA)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "Execute sp_CATALOGO_COMPAÑIAS '" & USUARIO & "'," & BANDERA
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            DataAdapter_ = New SqlDataAdapter(Comando_Track)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCOMPAÑIA.DataSource = Table
            Me.cmbCOMPAÑIA.ValueMember = "COMPAÑIA"
            Me.cmbCOMPAÑIA.DisplayMember = "NOMBRE_COMPAÑIA"
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaBancos()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            Sql &= cmbCOMPAÑIA.SelectedValue
            Sql &= ", 0"
            Sql &= ", 3"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbBANCO.DataSource = Table
            Me.cmbBANCO.ValueMember = "Banco"
            Me.cmbBANCO.DisplayMember = "Nombre Banco"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaCuentasBancarias()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", " & Me.cmbBANCO.SelectedValue
            Sql &= ", " & 4
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCUENTA_BANCARIA.DataSource = Table
            Me.cmbCUENTA_BANCARIA.ValueMember = "Cuenta"
            Me.cmbCUENTA_BANCARIA.DisplayMember = "Descripción Cuenta"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaCuentaContable()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", " & Me.cmbBANCO.SelectedValue
            Sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= ", " & 0
            Comando_ = New SqlCommand(Sql, Conexion_)
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
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", " & Me.cmbBANCO.SelectedValue
            Sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= ", " & 2
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
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
    Private Sub CargaCentroCosto()
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", 3"
            Comando_ = New SqlCommand(Sql, Conexion_)
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
    Private Function BuscaCentroCosto() As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Select * From VISTA_INVENTARIOS_CATALOGOS_BODEGAS Where "
            Sql &= "COMPAÑIA = " & Me.cmbCOMPAÑIA.SelectedValue
            Sql &= " And BODEGA = " & 1
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then
                Me.cmbCENTRO_COSTO.SelectedValue = DataReader_.Item("CENTRO_COSTO")
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function
    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            CargaCuentasBancarias()
            CargaCuentaContable()
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        If Trim(Me.TxtCreditoFiscal.Text) = "" Then
            MsgBox("¡Debe ingresar un número de crédito fiscal válido!", MsgBoxStyle.Critical, "Validación")
            Me.TxtCreditoFiscal.Focus()
            Return False
            Exit Function
        End If
        If Trim(Me.txtCONCEPTO.Text) = "" Then
            MsgBox("¡Debe ingresar un Concepto válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.lblCUENTA.Text = "0" Then
            MsgBox("¡Debe seleccionar una Cuenta de Banco válida!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If ParamCodProvee = 0 Then
            MsgBox("¡Debe seleccionar Proveedor a pagar!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Function GeneraCorrelativoCheque() As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS_CORRELATIVO "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", " & Me.cmbBANCO.SelectedValue
            Sql &= ", '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= ", " & Me.cmbCHEQUERA.SelectedValue
            Comando_ = New SqlCommand(Sql, Conexion_)
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
    Private Function Mantenimiento_Cheques(ByVal Cheque As Integer, ByVal Partida As Integer, ByVal IUD As String) As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_ORDEN_COMPRA_CHEQUES_IUD "
            Sql &= Me.cmbCOMPAÑIA.SelectedValue
            Sql &= ", " & Me.lblOC.Text
            Sql &= " ," & Cheque
            Sql &= " ," & Me.lblSubTotal.Text
            Sql &= " ," & Me.lblIVA.Text
            Sql &= " ," & Me.lblTotal.Text
            Sql &= " ," & Me.lblRetencion.Text
            Sql &= " ," & Me.lblTotalCheque.Text
            Sql &= ", " & Me.TxtCreditoFiscal.Text
            Sql &= " ," & Me.cmbBANCO.SelectedValue
            Sql &= " ,'" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
            Sql &= " ," & Me.lblLIBRO_CONTABLE.Text
            Sql &= " ," & Me.lblCUENTA.Text
            Sql &= " ," & 0
            Sql &= " ," & Partida
            Sql &= " ,'" & Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= " ,'" & Usuario & "'"
            Sql &= " ,'" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Sql = "UPDATE COOPERATIVA_ORDEN_COMPRA_AUTORIZACIONES SET SUBTOTAL=" & Val(Me.lblSubTotal.Text) & ", IVA=" & Val(Me.lblIVA.Text) & ", TOTAL=" & Val(Me.lblTotal.Text) & _
            ", PERCEPCION=" & Val(Me.lblRetencion.Text) & ", TOTAL_FINAL=" & Val(Me.lblTotalCheque.Text) & " WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & Me.lblOC.Text
            ProcesosContables.Ejecutar_ConsultaSQL(Sql)
            Sql = "UPDATE COOPERATIVA_ORDEN_COMPRA_ENCABEZADO SET PROVEEDOR=" & ParamCodProvee & " WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & Me.lblOC.Text
            ProcesosContables.Ejecutar_ConsultaSQL(Sql)
            Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROVEEDOR= " & ParamCodProvee & ", VALOR_VALE=" & Val(Me.lblTotalCheque.Text) & " WHERE COMPAÑIA=" & Compañia & " AND CORRELATIVO=" & Me.Lbl_Correlativo.Text
            ProcesosContables.Ejecutar_ConsultaSQL(Sql)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Function Mantenimiento_Cheques_VariasOC(ByVal Cheque, ByVal Partida, ByVal IUD) As Boolean
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            For i As Integer = 0 To j - 1
                Conexion_.Open()
                Sql = "Execute Coo.sp_COOPERATIVA_ORDEN_COMPRA_CHEQUES_IUD "
                Sql &= Me.cmbCOMPAÑIA.SelectedValue
                Sql &= ", " & varios_NumOCs(i)
                Sql &= " ," & Cheque
                Sql &= " ," & varios_SubTotales(i)
                Sql &= " ," & varios_IVA(i)
                Sql &= " ," & varios_Totales(i)
                Sql &= " ," & varios_Retenciones(i)
                Sql &= " ," & varios_TotalesCheques(i)
                Sql &= ", " & Me.TxtCreditoFiscal.Text
                Sql &= " ," & Me.cmbBANCO.SelectedValue
                Sql &= " ,'" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'"
                Sql &= " ," & Me.lblLIBRO_CONTABLE.Text
                Sql &= " ," & Me.lblCUENTA.Text
                Sql &= " ," & 0
                Sql &= " ," & Partida
                Sql &= " ,'" & Format(Me.dpFECHA_OC.Value, "dd-MM-yyyy HH:mm:ss") & "'"
                Sql &= " ,'" & Usuario & "'"
                Sql &= " ,'" & IUD & "'"
                Comando_ = New SqlCommand(Sql, Conexion_)
                Comando_.ExecuteNonQuery()
                Conexion_.Close()
                Sql = "UPDATE COOPERATIVA_ORDEN_COMPRA_AUTORIZACIONES SET SUBTOTAL=" & varios_SubTotales(i) & ", IVA=" & varios_IVA(i) & ", TOTAL=" & varios_Totales(i) & _
                ", PERCEPCION=" & varios_Retenciones(i) & ", TOTAL_FINAL=" & varios_TotalesCheques(i) & " WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & varios_NumOCs(i)
                ProcesosContables.Ejecutar_ConsultaSQL(Sql)
                Sql = "UPDATE COOPERATIVA_ORDEN_COMPRA_ENCABEZADO SET PROVEEDOR=" & ParamCodProvee & " WHERE COMPAÑIA=" & Compañia & " AND ORDEN_COMPRA=" & varios_NumOCs(i)
                ProcesosContables.Ejecutar_ConsultaSQL(Sql)
                Sql = "UPDATE COOPERATIVA_SOLICITUDES SET PROVEEDOR= " & ParamCodProvee & ", VALOR_VALE=" & varios_TotalesCheques(i) & " WHERE COMPAÑIA=" & Compañia & " AND CORRELATIVO=" & varios_Correlativo(i)
                ProcesosContables.Ejecutar_ConsultaSQL(Sql)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        MsgBox("¡No se generará ningún cheque!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
        Me.Close()
        Me.Dispose()
    End Sub

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

    Private Sub TxtCreditoFiscal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCreditoFiscal.LostFocus
        Me.txtCONCEPTO.Text = " Pago Factura " & Trim(Me.TxtCreditoFiscal.Text) & " el " & Format(Me.dpFECHA_OC.Value, "dd-MMM-yyyy").ToString & " y OC # "
        If VariasOC = False Then
            Me.txtCONCEPTO.Text &= lblOC.Text
        Else
            For i As Integer = 0 To j - 1
                Me.txtCONCEPTO.Text &= varios_NumOCs(i) & ", "
            Next
        End If
        Me.txtCONCEPTO.Text &= " a nombre de:" & lblNOMBRE_PROVEEDOR.Text
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim Cheque As Integer
        If ValidaCampos() = True Then
            Cheque = 0
            Cheque = GeneraCorrelativoCheque()
            If Cheque > 0 Then
                ProcesosContables.Contabiliza_Partida_Automatica_Standard(Me.cmbCOMPAÑIA.SelectedValue _
                   , Me.cmbCENTRO_COSTO.SelectedValue, 6, 2, Cheque, Format(Me.dpFECHA_OC.Value, "dd-MM-yyy HH:mm:ss") _
                  , Me.lblCUENTA.Text, Val(Me.lblOC.Text), Val(lblTotalCheque.Text), Trim(Me.txtCONCEPTO.Text))
                Dim Partida As Integer = ProcesosContables.obtenerEscalar("SELECT ISNULL(PARTIDA,0) FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA=" & Compañia & " AND TIPO_DOCUMENTO=6 AND DOCUMENTO=" & Cheque)
                If VariasOC = False Then
                    Mantenimiento_Cheques(Cheque, Partida, "I")
                Else
                    Mantenimiento_Cheques_VariasOC(Cheque, Partida, "I")
                End If
                'ProcesosContables.imprimeCheque2(Cheque, Me.lblNOMBRE_PROVEEDOR.Text, Val(lblTotalCheque.Text), Me.chkNoNeg.CheckState)
                Me.Close()
                Me.Dispose()
            Else
                MsgBox("¡No se pudo generar el Número de Cheque!", MsgBoxStyle.Critical, "Mensaje")
            End If
        End If
    End Sub

    'Private Sub imprimeCheque(ByVal Cheque As Integer, ByVal NomProv As String, ByVal total_cheque As Double)
    '    Dim DS01 As New DataSet
    '    Dim DataAdapter As New SqlDataAdapter
    '    Dim Conexion As New DLLConnection.Connection
    '    Dim Conexion_ As New SqlConnection
    '    Dim Comando_ As SqlCommand
    '    Dim DataReader_ As SqlDataReader
    '    Dim ImpCheque As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
    '    Dim valor As Double
    '    Dim letras, nombre As String
    '    Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
    '    Conexion_.Open()
    '    letras = VLetras.Letras(Me.lblTotalCheque.Text)
    '    Sql = "EXEC sp_CONTABILIDAD_EMITIR_CHEQUE "
    '    Sql &= Cheque
    '    Sql &= ", '" & NomProv & "'"
    '    Sql &= ", " & total_cheque
    '    Sql &= ", '" & letras & "'"
    '    Comando_ = New SqlCommand(Sql, Conexion_)
    '    DataAdapter = New SqlDataAdapter(Comando_)
    '    DataAdapter.Fill(DS01)
    '    ImpCheque.SetDataSource(DS01.Tables(0))
    '    ImpCheque.PrintToPrinter(1, False, 1, 1)
    'End Sub

    Private Sub BtnProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProveedor.Click
        If Me.lblNOMBRE_PROVEEDOR.ReadOnly = False Then
            Me.lblNOMBRE_PROVEEDOR.ReadOnly = True
            Me.lblNOMBRE_PROVEEDOR.BackColor = Color.LightGray
        Else
            Me.lblNOMBRE_PROVEEDOR.ReadOnly = False
            Me.lblNOMBRE_PROVEEDOR.BackColor = Color.Snow
            Me.lblNOMBRE_PROVEEDOR.Focus()
        End If
    End Sub

    Private Sub btnEditarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarConcepto.Click
        If Me.txtCONCEPTO.ReadOnly = True Then
            Me.txtCONCEPTO.ReadOnly = False
            Me.txtCONCEPTO.BackColor = Color.Snow
            Me.txtCONCEPTO.Focus()
        Else
            Me.txtCONCEPTO.ReadOnly = True
            Me.txtCONCEPTO.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub BtnBuscarProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProv.Click
        If ParamCodProvee = 0 Then
            Dim FrmBuscarProvee As New FrmBuscarProveedor
            FrmBuscarProvee.Compañia_Value = cmbCOMPAÑIA.SelectedValue
            FrmBuscarProvee.CbxCompania.Enabled = False
            FrmBuscarProvee.ShowDialog()
            lblNOMBRE_PROVEEDOR.Text = ParamNomProvee
        End If
    End Sub
End Class