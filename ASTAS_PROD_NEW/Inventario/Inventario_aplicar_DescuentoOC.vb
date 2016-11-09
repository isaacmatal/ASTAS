
Imports System.Data.SqlClient

Public Class Inventario_aplicar_DescuentoOC
    Dim intpOC As Integer
    Dim intpCompania As Integer
    Dim intpbodega As Integer
    Dim intlinea As Integer
    '
    Dim strCodigo As String
    Dim strDescripcion As String
    Dim dblCantidad As Double
    Dim dblCostoUni As Double
    Dim dblTotal As Double
    '
    Dim c_data1 As New jarsClass

    Private Sub Inventario_aplicar_DescuentoOC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPRODUCTO.Text = strCodigo
        txtDESCRIPCION_PRODUCTO.Text = strDescripcion
        txtCANTIDAD.Text = dblCantidad
        txtCOSTO_UNITARIO.Text = dblCostoUni
        txtCOSTO_TOTAL.Text = dblTotal
    End Sub

    Private Sub btnGuardarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        If ValidaCamposLinea() = True Then
            Dim dblCostoNuevo As Double = txtCOSTO_UNITARIO.Text - ((txtCOSTO_UNITARIO.Text * Val(Txt_PorDescto.Text)) / 100)
            c_data1.Ejecutar_ConsultaSQL(" update CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO set COSTO_UNITARIO_ORIGINAL = " & Me.txtCOSTO_UNITARIO.Text & " ,  costo_unitario = " & dblCostoNuevo & ",  LIBRAS = " & Val(Txt_PorDescto.Text) & " where COMPAÑIA = " & intpCompania & " and orden_compra = " & intpOC & " and linea = " & intlinea)
            MsgBox("¡Descuento Aplicado...!", MsgBoxStyle.Critical, "Confirmacion")
            Me.Close()
        End If
    End Sub


    Private Function ValidaCamposLinea() As Boolean
        If Val(Trim(Me.txtCANTIDAD.Text)) <= 0 Then
            MsgBox("¡Debe seleccionar una Cantidad mayor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        'JASC21082013
        If Val(Trim(Me.txtCOSTO_UNITARIO.Text)) <= 0 Then
            MsgBox("¡El costo unitario es menor que cero! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If

        If Val(Trim(Me.Txt_ValDescto.Text)) <= 0 Then
            MsgBox("¡Debe de ingresar el Valor del Descuento! Verifique", MsgBoxStyle.Critical, "Validación")
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

        Me.txtCOSTO_UNITARIO.Text = ""
        Me.txtPRODUCTO.Enabled = True
        
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
                Me.btnAplicar.Focus()
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
            Me.btnAplicar.Focus()
        End If
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub


    'Dim dblCostoNuevo As Double = Me.dgvDetalleOC.CurrentRow.Cells.Item(6).Value - ((Me.dgvDetalleOC.CurrentRow.Cells.Item(6).Value * Val(strValor)) / 100)
    'c_data1.Ejecutar_ConsultaSQL(" update CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO set costo_unitario = " & dblCostoNuevo & ",  LIBRAS = " & Val(strValor) & " where COMPAÑIA = " & Compañia & " and orden_compra = " & Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value & " and linea = " & Me.dgvDetalleOC.CurrentRow.Cells.Item(0).Value)


End Class