Imports System.Data.SqlClient

Public Class Inventario_Agregar_Bonificacion_Descuento
    Dim intpOC As Integer
    Dim intpCompania As Integer
    Dim intpbodega As Integer
    Dim intlinea As Integer
    Dim bonificacion As Integer = 1
    Dim intmedida As Integer
    Dim intidproducto As Integer
    Dim c_data1 As New jarsClass

    Public Sub New(ByVal pOC As Integer, ByVal PIDcompania As Integer, ByVal idpbodega As Integer, ByVal pidLinea As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        intpOC = pOC
        intpCompania = PIDcompania
        intpbodega = idpbodega
        intlinea = pidLinea
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click
        If ValidaCamposLinea() = True Then
            prRecibir(intpOC)
            Me.Close()
        End If
    End Sub

    Private Function ValidaCamposLinea() As Boolean
        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar una Cantidad mayor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.txtLIBRAS.Enabled = True And Val(Trim(Me.txtLIBRAS.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar una Cantidad en Libras válida para el producto! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        'JASC21082013
        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 And bonificacion = 0 Then
            MsgBox("¡El costo unitario es menor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub LimpiaCamposProducto()
        Me.Txt_PorDescto.Text = ""
        Me.Txt_ValDescto.Text = ""
        Me.txtCOSTO_TOTAL.Text = ""
        Me.txtPRODUCTO.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.txtDESCRIPCION_PRODUCTO.Text = ""
        Me.txtCANTIDAD.Text = ""
        Me.txtLIBRAS.Text = ""
        Me.txtCOSTO_UNITARIO.Text = ""
        Me.txtPRODUCTO.Enabled = True
        Me.btnBuscarProducto.Enabled = True
    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Dim Busqueda As New Inventario_BusquedaProductosBodega("", 1)
        Busqueda.Compañia_Value = intpCompania
        Busqueda.Bodega_Value = intpbodega
        Busqueda.cmbBODEGA.Enabled = False
        Busqueda.BuscaTodos = True
        Busqueda.ShowDialog()
        If Producto <> "" Then
            Me.txtPRODUCTO.Text = Producto
            BuscarProducto(intpCompania, intpbodega, Me.txtPRODUCTO.Text)
            Producto = ""
        End If
        Me.txtCANTIDAD.Focus()
    End Sub


    Private Sub BuscarProducto(ByVal Compañia, ByVal Bodega, ByVal Producto)
        Dim sql As String
        Dim valor As String
        Dim tblProd As DataTable
        Try

            'JASC
            '18082013
            If Producto.ToString = "" Then
                valor = "''"
            Else
                valor = Producto.ToString
            End If
            sql = "Execute sp_INVENTARIOS_PRODUCTOS_BODEGAS_BUSQUEDA "
            sql &= Compañia
            sql &= ", " & Bodega
            sql &= ", " & valor
            sql &= ", '' " 'Descripción del Producto
            sql &= ", 0" 'Código de Grupo
            sql &= ", 2" 'Bandera
            tblProd = c_data1.obtenerDatos(New SqlCommand(sql))
            'LimpiaCamposProducto()
            If tblProd.Rows.Count > 0 Then
                Me.txtPRODUCTO.Text = tblProd.Rows(0).Item("PRODUCTO")
                intidproducto = tblProd.Rows(0).Item("PRODUCTO")
                Me.txtDESCRIPCION_PRODUCTO.Text = tblProd.Rows(0).Item("DESCRIPCION_PRODUCTO")
                Me.cmbUNIDAD_MEDIDA.Items.Clear()
                Me.cmbUNIDAD_MEDIDA.Items.Add(tblProd.Rows(0).Item("DESCRIPCION_UNIDAD_MEDIDA"))
                Me.cmbUNIDAD_MEDIDA.SelectedIndex = 0
                intmedida = tblProd.Rows(0).Item("UNIDAD_MEDIDA")
                Me.txtLIBRAS.Enabled = tblProd.Rows(0).Item("UNIDAD_LIBRA")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtCANTIDAD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCANTIDAD.KeyPress
        Dim cadena As String = Me.txtCANTIDAD.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCOSTO_UNITARIO.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtCOSTO_UNITARIO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOSTO_UNITARIO.KeyPress
        Dim cadena As String = Me.txtCOSTO_UNITARIO.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Val(txtCOSTO_UNITARIO.Text) = 0 Then
                txtCOSTO_UNITARIO.Text = 0
                txtCOSTO_TOTAL.Focus()
            Else
                txtCOSTO_TOTAL.Text = Val(txtCANTIDAD.Text) * Val(txtCOSTO_UNITARIO.Text)
                Me.Txt_PorDescto.Focus()
            End If
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtCOSTO_TOTAL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOSTO_TOTAL.KeyPress
        Dim cadena As String = Me.txtCOSTO_TOTAL.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txtCOSTO_TOTAL.Text > 0 Then
                txtCOSTO_UNITARIO.Text = Math.Round(Val(txtCOSTO_TOTAL.Text) / Val(txtCANTIDAD.Text), 6)
            End If
            Me.Txt_PorDescto.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub Txt_PorDescto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PorDescto.KeyPress
        Dim cadena As String = Me.Txt_PorDescto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Val(Me.Txt_PorDescto.Text) = 0 Then
                Me.Txt_ValDescto.Focus()
            Else
                Me.Txt_ValDescto.Text = Math.Round((Val(Me.txtCOSTO_TOTAL.Text) * Val(Me.Txt_PorDescto.Text)) / 100, 2)
                Me.btnGuardarDetalle.Focus()
            End If
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub Txt_ValDescto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ValDescto.KeyPress
        Dim cadena As String = Me.Txt_ValDescto.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If (Val(Me.Txt_ValDescto.Text) > 0) And (Val(txtCOSTO_TOTAL.Text) > 0) Then
                Txt_PorDescto.Text = Math.Round((Val(Txt_ValDescto.Text) / Val(txtCOSTO_TOTAL.Text)) * 100, 2)
            Else
                Txt_PorDescto.Text = 0
            End If
            Me.btnGuardarDetalle.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub


    Private Sub prRecibir(ByVal poc As Integer)
        Dim Sql As String
        Sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO_IUD "
        Sql &= " @COMPAÑIA             = " & Compañia
        Sql &= ",@ORDEN_COMPRA         = " & poc
        Sql &= ",@LINEA                = 0"
        Sql &= ",@PRODUCTO             = " & Me.txtPRODUCTO.Text
        Sql &= ",@DESCRIPCION_PRODUCTO = '" & Me.txtDESCRIPCION_PRODUCTO.Text & "'"
        Sql &= ",@UNIDAD_MEDIDA        = " & intmedida
        Sql &= ",@CANTIDAD             = " & Me.txtCANTIDAD.Text
        Sql &= ",@LIBRAS               = 0"
        Sql &= ",@COSTO_UNITARIO       = " & Me.txtCOSTO_UNITARIO.Text
        Sql &= ",@SERVICIO             = " & IIf(Me.chkSERVICIO.Checked, "0", "1")
        Sql &= ",@CANTIDAD_RECIBIDO    = 0"
        Sql &= ",@LIBRAS_RECIBIDO      = 0"
        Sql &= ",@CANTIDAD_PENDIENTE   = " & Me.txtCANTIDAD.Text
        Sql &= ",@LIBRAS_PENDIENTE     = 0"
        Sql &= ",@RECIBIDO             = 1"
        Sql &= ",@A_INVENTARIO         = " & IIf(Me.chkSERVICIO.Checked, "0", "1")
        Sql &= ",@USUARIO              = '" & Usuario & "' "
        Sql &= ",@IUD                  = 'B'"
        Sql &= ",@DESCUENTO            = " & intpbodega
        If c_data1.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
            MessageBox.Show("Producto Ingresado de Forma correcta", "Recibir Compras - Bonificación", MessageBoxButtons.OK)
        End If
    End Sub


    Private Sub txtPRODUCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRODUCTO.TextChanged
        If Not IsNumeric(txtPRODUCTO.Text) Then
            txtPRODUCTO.Text = ""
            txtPRODUCTO.Focus()
        Else
            BuscarProducto(intpCompania, intpbodega, Me.txtPRODUCTO.Text)
        End If
    End Sub

    Private Sub txtPRODUCTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRODUCTO.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.txtCANTIDAD.Focus()
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub Inventario_Agregar_Bonificacion_Descuento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class