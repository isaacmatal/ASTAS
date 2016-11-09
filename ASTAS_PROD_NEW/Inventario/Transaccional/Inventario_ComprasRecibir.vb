Imports System.Data.SqlClient

Public Class Inventario_ComprasRecibir
    Dim Sql As String
    Dim jClass As New jarsClass
    Public Compañia_Value As Integer
    Public Bodega_Value As Integer

    Private Sub Inventario_ComprasRecibir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Recibido = False
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaTipoDocumento(Compañia)
        Me.cmbTipoDocumento.SelectedValue = Compañia_Value
        NumeDocto = 0
        TipoDocto = 0
    End Sub

    Private Sub CargaTipoDocumento(ByVal Compañia)
        Dim Table As DataTable
        Try
            Sql = "SELECT TIPO_DOCUMENTO, DESCRIPCION_TIPO_DOCUMENTO FROM FACTURACION_CATALOGO_TIPO_DOCUMENTO WHERE COMPAÑIA = " & Compañia
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbTipoDocumento.DataSource = Table
            Me.cmbTipoDocumento.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTipoDocumento.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Dim Result As Boolean = True
        If Trim(Me.txtFACTURA.Text).Length = 0 Then
            MsgBox("¡Debe ingresar un N° de Crédito Fiscal / Factura válido!", MsgBoxStyle.Critical, "Validación")
            Result = False
        End If
        If Me.dtpFechaRecep.Value.Day = Me.dpFecha_Comp.Value.Day And Me.dtpFechaRecep.Value.Month = Me.dpFecha_Comp.Value.Month And Me.dtpFechaRecep.Value.Year = Me.dpFecha_Comp.Value.Year Then
            If MsgBox("La fecha de proceso y la de ingreso a inventario es la misma." & vbCrLf & vbCrLf & "¿Desea cambiar la fecha del comprobante?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.No Then
                Result = True
            Else
                Result = False
            End If
        End If
        If CInt(jClass.obtenerEscalar("SELECT DOCUMENTO FROM CONTABILIDAD_ORDEN_COMPRA_CHEQUES WHERE COMPAÑIA = " & Compañia & " AND ORDEN_COMPRA = " & Me.lblOC.Text & " AND DOCUMENTO = " & Me.txtFACTURA.Text)) > 0 Then
            MsgBox("Ya existe el número de documento para la orden de compra", MsgBoxStyle.Information, "Validación")
            Me.txtFACTURA.Select(0, Me.txtFACTURA.Text.Length)
            Me.txtFACTURA.Focus()
            Result = False
        End If
        Return Result
    End Function

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        If ValidaCampos() = True Then
            If MsgBox("¿Está seguro(a) que desea recibir el producto" & IIf(Me.chkInv.Checked, " y cargarlo a Inventario?", "?"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Cheques(Compañia, Me.lblOC.Text, Bodega_Value, 0, Me.lblSubTotal.Text, Me.lblIVA.Text, Me.lblCESC.Text, _
                                      Me.lblRetencion.Text, Me.lblTotalCompra.Text, Me.txtFACTURA.Text, 0, "", 0, 0, 0, 0, Me.dpFecha_Comp.Value, "", "I")
                Recibido = True
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

    Private Function Mantenimiento_Cheques(ByVal Compañia As Integer, ByVal OC As Integer, ByVal Bodega As Integer, _
                                           ByVal Cheque As Integer, ByVal SubTotal As Double, ByVal IVA As Double, _
                                           ByVal Total As Double, ByVal Retencion As Double, _
                                           ByVal TotalFinal As Double, ByVal CCF As Double, ByVal Banco As Double, _
                                           ByVal CuentaBancaria As String, ByVal LC As Integer, _
                                           ByVal Cuenta As Integer, ByVal Transaccion As Integer, _
                                           ByVal Partida As Integer, ByVal FechaContable As Date, _
                                           ByVal OrdenesCompra As String, ByVal IUD As String) As Boolean
        NumeDocto = CCF
        TipoDocto = Me.cmbTipoDocumento.SelectedValue
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_CHEQUES_IUD" & vbCrLf
            Sql &= "  @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ", @ORDEN_COMPRA    = " & OC & vbCrLf
            Sql &= ", @BODEGA          = " & Bodega & vbCrLf
            Sql &= ", @CHEQUE          = " & Cheque & vbCrLf
            Sql &= ", @SUBTOTAL        = " & SubTotal & vbCrLf
            Sql &= ", @IVA             = " & IVA & vbCrLf
            Sql &= ", @TOTAL           = " & SubTotal + IVA & vbCrLf
            Sql &= ", @RETENCION       = " & Retencion & vbCrLf
            Sql &= ", @TOTAL_FINAL     = " & TotalFinal & vbCrLf
            Sql &= ", @DOCUMENTO       = " & CCF & vbCrLf
            Sql &= ", @BANCO           = " & Banco & vbCrLf
            Sql &= ", @CUENTA_BANCARIA = '" & CuentaBancaria & "'" & vbCrLf
            Sql &= ", @LIBRO_CONTABLE  = " & LC & vbCrLf
            Sql &= ", @CUENTA          = " & Cuenta & vbCrLf
            Sql &= ", @TRANSACCION     = " & Transaccion & vbCrLf
            Sql &= ", @PARTIDA         = " & Partida & vbCrLf
            Sql &= ", @FECHA_CONTABLE  = '" & Format(FechaContable, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @ORDENES_COMPRA  = '" & OrdenesCompra & "'" & vbCrLf
            Sql &= ", @USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD             = '" & IUD & "'" & vbCrLf
            Sql &= ", @TIPO_DOCUMENTO  = " & Me.cmbTipoDocumento.SelectedValue & vbCrLf
            Sql &= ", @DESCUENTO       = " & Val(Me.Lbl_Descto.Text) & vbCrLf
            Sql &= ", @FECHA_RECEPCION = '" & Format(Me.dtpFechaRecep.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @RENTA           = " & Me.lblISR.Text & vbCrLf
            Sql &= ", @PAGADO          = " & IIf(Me.chkContado.Checked, "1", "0") & vbCrLf
            Sql &= ", @CESC            = " & Me.lblCESC.Text & vbCrLf
            Sql &= ", @VALOR_EXENTO    = " & Me.lblExento.Text & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Sub txtFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFACTURA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Inventario_ComprasRecibir_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class