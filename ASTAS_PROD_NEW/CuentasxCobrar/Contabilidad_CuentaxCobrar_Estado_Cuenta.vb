Imports System.Data.SqlClient

Public Class Contabilidad_CuentaxCobrar_Estado_Cuenta

    Dim jClass As New jarsClass
    Dim sql As String
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable

    Private Sub Contabilidad_CuentaxCobrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.WindowState = FormWindowState.Maximized
        Me.dpFECHA_DESDE.Value = Now.AddDays(-Now.Day).AddDays(1)
        Me.dpFECHA_HASTA.Value = Now
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = False
    End Sub

    'Boton Buscar Cliente
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Iniciando = True
        Dim clientes As New Contabilidad_BusquedaClientes
        clientes.Compañia_Value = Compañia
        clientes.cmbCOMPAÑIA.Enabled = False
        clientes.ShowDialog()
        busquedaClientes(1, 2)
        Iniciando = False
    End Sub

    'Metodo de busqueda de clientes
    Public Sub busquedaClientes(ByVal tb As Integer, ByVal flag As Integer)
        If Trim(Producto) <> Nothing And Compañia <> 0 And Trim(Numero) <> Nothing Then
            Try
                sql = " Execute sp_CONTABILIDAD_CATALOGO_CLIENTES "
                sql &= Compañia
                If flag = 2 Then
                    sql &= ", " & Producto
                ElseIf flag = 3 Then
                    sql &= ", '" & Producto & "'"
                End If
                sql &= ", '" & Numero & "' "
                sql &= ", " & flag
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Me.txtCliente.Text = Table.Rows(0).Item("Cliente")
                    Me.txtNombre.Text = Table.Rows(0).Item("Nombre")
                Else
                    MsgBox("No existe Cliente... Verifique.", MsgBoxStyle.Information, "Búsqueda")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    'Metodo que carga el historial de facturas-abonos
    Private Sub cargaReporte(ByVal cliente As Integer, ByVal fdesde As DateTime, ByVal fhasta As DateTime)
        Dim rpt As New Contabilidad_CuentasxCobrar_Estado_Cuenta_Clientes_Individual 'CrystalDecisions.CrystalReports.Engine.ReportClass
        Try
            sql = "EXECUTE sp_FACTURACION_ABONOS" & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            If cliente > 0 Then
                sql &= ",@CLIENTE = " & cliente & vbCrLf
                Me.crvEstadoCuenta.DisplayGroupTree = False
            Else
                Me.crvEstadoCuenta.DisplayGroupTree = True
            End If
            sql &= ",@FECHA_DESDE = '" & fdesde.Date.ToString("dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@FECHA_HASTA = '" & fhasta.Date.ToString("dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@BANDERA = 1" & vbCrLf
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Me.chkCorteGrupo.Checked Then
                rpt.GroupFooterSection2.SectionFormat.EnableNewPageAfter = True
            End If
            If Table.Rows.Count > 0 Then
                rpt.SetDataSource(Table)
                crvEstadoCuenta.ReportSource = rpt
            Else
                MsgBox("No hay datos para el reporte.", MsgBoxStyle.Information, "Reporte")
                crvEstadoCuenta.ReportSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        Producto = Me.txtCliente.Text
        Numero = "0"
        busquedaClientes(2, 2)
    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        cargaReporte(Val(Me.txtCliente.Text), Me.dpFECHA_DESDE.Value, Me.dpFECHA_HASTA.Value)
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        If Val(Me.txtCliente.Text) > 0 Then
            sql = "EXECUTE [dbo].[sp_FACTURACION_ABONOS_IUD]"
            sql &= "	 @COMPAÑIA      = " & Compañia & vbCrLf
            sql &= "	,@BODEGA        = 14" & vbCrLf
            sql &= "	,@ORDEN_VENTA   = 0" & vbCrLf
            sql &= "	,@NUMERO_FACTURA= 0" & vbCrLf
            sql &= "	,@CLIENTE       = " & Me.txtCliente.Text & vbCrLf
            sql &= "	,@TIPO_DOCUMENTO= 0" & vbCrLf
            sql &= "	,@FORMA_PAGO    = 0" & vbCrLf
            sql &= "	,@NUMERO_REMESA = ''" & vbCrLf
            sql &= "	,@CARGO         = " & Val(Me.txtValorLiq.Text) & vbCrLf
            sql &= "	,@ABONO         = 0.0" & vbCrLf
            sql &= "	,@FECHA_CONTABLE= '" & Format(Me.dtpFechaLiq.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= "	,@CONCEPTO      = '" & Me.txtConcepto.Text & "'" & vbCrLf
            sql &= "	,@USUARIO       = '" & Usuario & "'" & vbCrLf
            sql &= "	,@IUD           = 'I'" & vbCrLf
            jClass.Ejecutar_ConsultaSQL(sql)
            Me.txtValorLiq.Clear()
            Me.txtConcepto.Clear()
            Me.grbLiqRem.Enabled = False
            Me.btnImprimir.PerformClick()
        End If
    End Sub

    Private Sub chkLiquidar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLiquidar.CheckedChanged
        If Val(Me.txtCliente.Text) > 0 Then
            Me.grbLiqRem.Enabled = Me.chkLiquidar.Checked
            If Me.chkLiquidar.Checked Then
                Me.txtValorLiq.Text = Format(jClass.obtenerEscalar("EXECUTE [dbo].[sp_FACTURACION_ABONOS] @COMPAÑIA = " & Compañia & ", @CLIENTE = " & Val(Me.txtCliente.Text) & ", @BANDERA = 2"), "0.00")
                If Val(Me.txtValorLiq.Text) <= 0 Then
                    MsgBox("No hay saldo que liquidar.", MsgBoxStyle.Information, "Liquidación")
                    Me.grbLiqRem.Enabled = False
                End If
            Else
                Me.txtValorLiq.Clear()
                Me.txtConcepto.Clear()
            End If
        Else
            MsgBox("Debe ingresar un Código de Cliente antes de continuar.", MsgBoxStyle.Information, "Cliente")
            Me.grbLiqRem.Enabled = False
        End If
    End Sub
End Class