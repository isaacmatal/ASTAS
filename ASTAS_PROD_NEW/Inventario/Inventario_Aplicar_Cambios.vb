Imports System.Data.SqlClient
Public Class Inventario_Aplicar_Cambios

    Dim intpOC As Integer
    Dim intpCompania As Integer
    Dim jClass As New jarsClass

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        If validar() > 0 Then
            Dim dblCantidadNueva As Double
            Dim dblCostoNuevo As Double
            '
            If Val(Me.txtNuevaCantidad.Text) >= 0 Then
                dblCantidadNueva = CDbl(Me.txtNuevaCantidad.Text)
            Else
                dblCantidadNueva = CDbl(Me.txtCantidad.Text)
            End If
            '
            If Val(Me.txtNuevaCantidad.Text) = 0 And Val(Me.txtNuevoCostoUnitario.Text) = 0 Then
                dblCostoNuevo = 0
            ElseIf Val(Me.txtNuevoCostoUnitario.Text) > 0 Then
                dblCostoNuevo = CDbl(Me.txtNuevoCostoUnitario.Text)
            Else
                dblCostoNuevo = CDbl(Me.txtCostoUnitario.Text)
            End If
            '
            If MsgBox("Esta Aseguro de Aplicar los Cambios, se Afectara la Orden de Compras...", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                CambioLineaDetalleOC(Compañia, intpOC, Me.txtLinea.Text, dblCantidadNueva, Me.txtLibras.Text, dblCostoNuevo, 1)
                CargaOC_Detalle(intpCompania, intpOC, 3)
                Me.txtNuevaCantidad.Text = "0.00"
                Me.txtNuevoCostoUnitario.Text = "0.00"
            Else
                MsgBox("¡No se realizará ningún cambio!", MsgBoxStyle.Critical, "Validación")
            End If
        End If
        
    End Sub

    Private Sub CambioLineaDetalleOC(ByVal Compañia, ByVal OC, ByVal Linea, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Bandera)
        Dim Sql As String
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_CAMBIOS  "
            Sql &= Compañia
            Sql &= ", " & OC
            Sql &= ", " & Linea
            Sql &= ", " & Cantidad
            Sql &= ", " & Libras
            Sql &= ", " & CostoUnitario
            Sql &= ", '" & Usuario & "' "
            Sql &= ", " & Bandera
            If jClass.ejecutarComandoSql(New SqlCommand(Sql)) > 0 Then
                MsgBox("¡Datos Actualizados con éxito!", MsgBoxStyle.Information, "Mensaje")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaOC_Detalle(ByVal Compañia, ByVal OrdenCompra, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim Sql As String
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_RECIBIDO1 "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Me.dtsOC.Tables(0).Rows.Clear()
            DataAdapter_.Fill(Me.dtsOC.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub


    Private Sub Inventario_Aplicar_Cambios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaOC_Detalle(intpCompania, intpOC, 3)
        Me.Label1.Text = intpOC.ToString
        Me.ActiveControl = Me.txtNuevaCantidad
    End Sub

    Private Function validar() As Integer
        If Val(Me.txtNuevaCantidad.Text) < 0 Then
            Return 0
        Else
            Return 1
        End If
        If Val(Me.txtNuevoCostoUnitario.Text) < 0 Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtNuevaCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNuevaCantidad.TextChanged
        If Not IsNumeric(txtNuevaCantidad.Text) Then
            txtNuevaCantidad.Text = "0.00"
            txtNuevaCantidad.Focus()
        Else
            If Val(txtNuevaCantidad.Text) = 0 Then
                Me.txtNuevoCostoUnitario.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txtNuevoCostoUnitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNuevoCostoUnitario.TextChanged
        If Not IsNumeric(txtNuevoCostoUnitario.Text) Then
            txtNuevoCostoUnitario.Text = "0.00"
            txtNuevoCostoUnitario.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("Esta Aseguro de Eliminar el registro de la Orden de Compras...", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Mantenimiento_Detalle(Compañia, intpOC, Me.txtLinea.Text, "0", "0", 0, 0, 0, 0, 0, "D", 0)
            CargaOC_Detalle(intpCompania, intpOC, 3)
        Else
            MsgBox("¡No se realizará ningún cambio!", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub Mantenimiento_Detalle(ByVal Compañia, ByVal OrdenCompra, ByVal Linea, ByVal Producto, ByVal Descripcion, ByVal UnidadMedida, ByVal Cantidad, ByVal Libras, ByVal CostoUnitario, ByVal Servicio, ByVal IUD, ByVal bono)
        Dim Sql As String
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_DETALLE_IUD "
            Sql &= Compañia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Linea
            Sql &= ", " & Producto
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", " & UnidadMedida
            Sql &= ", " & Cantidad
            Sql &= ", " & Libras
            Sql &= ", " & CostoUnitario
            Sql &= ", " & Servicio
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Sql &= ", '" & bono & "'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class