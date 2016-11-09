Imports System.Data.SqlClient

Public Class Contabilidad_Cheques_Generar
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass

    Private Sub Contabilidad_Cheques_Generar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBancos(Compañia)
        CargaCuentasBancarias(Compañia, Me.cmbBANCO.SelectedValue, 4)
        CargaCuentaContable(COMPAÑIA, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        Me.cmbBANCO.Focus()
        Iniciando = False
    End Sub

    Private Sub CargaBancos(ByVal Compañia)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS "
            Sql &= Compañia
            Sql &= ", 0"
            Sql &= ", 3"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBANCO.DataSource = Table
            Me.cmbBANCO.ValueMember = "Banco"
            Me.cmbBANCO.DisplayMember = "Nombre Banco"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasBancarias(ByVal Compañia, ByVal Banco, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
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
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & Bandera
            TblCtas = jClass.obtenerDatos(New SqlCommand(Sql))
            If TblCtas.Rows.Count > 0 Then
                Me.lblCUENTA_COMPLETA.Text = TblCtas.Rows(0).Item("CUENTA_COMPLETA")
                Me.lblCUENTA.Text = TblCtas.Rows(0).Item("CUENTA")
                Me.lblLIBRO_CONTABLE.Text = TblCtas.Rows(0).Item("LIBRO_CONTABLE")
            Else
                Me.lblCUENTA_COMPLETA.Text = ""
                Me.lblCUENTA.Text = "0"
                Me.lblLIBRO_CONTABLE.Text = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function Mantenimiento_Cheques() As Boolean
        Dim Result As Boolean = False
        Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD" & vbCrLf
        Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
        Sql &= ", @ORDEN_COMPRA = " & Me.lblOC.Text & vbCrLf
        Sql &= ", @BODEGA = " & lblBodega.Text & vbCrLf
        Sql &= ", @CHEQUE = " & Val(Me.txtNumChq.Text) & vbCrLf
        Sql &= ", @SUBTOTAL = 0" & vbCrLf
        Sql &= ", @IVA = 0" & vbCrLf
        Sql &= ", @TOTAL = " & Me.lblTotalCheque.Text & vbCrLf
        Sql &= ", @RETENCION = 0" & vbCrLf
        Sql &= ", @TOTAL_FINAL = " & Me.lblTotalCheque.Text & vbCrLf
        Sql &= ", @DOCUMENTO = " & Me.lblFACTURA.Text & vbCrLf
        Sql &= ", @BANCO = " & cmbBANCO.SelectedValue & vbCrLf
        Sql &= ", @CUENTA_BANCARIA = '" & Me.cmbCUENTA_BANCARIA.SelectedValue & "'" & vbCrLf
        Sql &= ", @LIBRO_CONTABLE = " & Me.lblLIBRO_CONTABLE.Text & vbCrLf
        Sql &= ", @CUENTA = " & Me.lblCUENTA.Text & vbCrLf
        Sql &= ", @TRANSACCION = 0" & vbCrLf
        Sql &= ", @PARTIDA = 0" & vbCrLf
        Sql &= ", @FECHA_CONTABLE = '" & Format(Me.dpFECHA_CH.Value, "dd/MM/yyyy") & "'" & vbCrLf
        Sql &= ", @ORDENES_COMPRA = ''" & vbCrLf
        Sql &= ", @USUARIO  = '" & Usuario & "'" & vbCrLf
        Sql &= ", @IUD = 'PAGADO'" & vbCrLf
        If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            Result = True
        Else
            Result = False
        End If
        Return Result
    End Function

    Private Function ValidaCampos() As Boolean
        If Me.lblCUENTA.Text = "0" Then
            MsgBox("¡Debe seleccionar una Cuenta de Banco válida!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Val(Me.txtNumChq.Text) = 0 Then
            If MsgBox("Debe ingresar un número de cheque, en caso " & vbCrLf & "contrario se tomará como un pago con remesa" & vbCrLf & vbCrLf & "¿Desea Continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmbBANCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBANCO.SelectedIndexChanged
        If Iniciando = False Then
            CargaCuentasBancarias(COMPAÑIA, Me.cmbBANCO.SelectedValue, 4)
            CargaCuentaContable(COMPAÑIA, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub cmbCUENTA_BANCARIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCUENTA_BANCARIA.SelectedIndexChanged
        If Iniciando = False And Me.cmbCUENTA_BANCARIA.ValueMember <> "" Then
            CargaCuentaContable(COMPAÑIA, Me.cmbBANCO.SelectedValue, Me.cmbCUENTA_BANCARIA.SelectedValue, 0)
        Else
            Me.lblCUENTA_COMPLETA.Text = ""
            Me.lblCUENTA.Text = "0"
            Me.lblLIBRO_CONTABLE.Text = "0"
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If ValidaCampos() = True Then
            If Mantenimiento_Cheques() Then
                Me.Close()
            End If
        End If
    End Sub
End Class