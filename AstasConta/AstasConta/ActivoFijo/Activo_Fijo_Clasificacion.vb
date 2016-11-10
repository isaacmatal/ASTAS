Public Class Activo_Fijo_Clasificacion
    Public codigo_ As Integer
    Public accion_ As String
    Public cuenta_completa_ As String
    Public cuenta_real_ As Integer
    Dim objEntidad As New EntidadGenerica
    Public _contenido As String

    Private Sub Activo_Fijo_Clasificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.btnGuardar.Enabled = True
        If Me.accion_.Equals("delete") Then
            Me.btnGuardar.Text = "Eliminar"
        Else
            Me.btnGuardar.Text = "Guardar"
        End If

        If Not Me.accion_.Equals("insert") Then
            Me.txtDescripcion.Text = Me._contenido
            Me.txtCuenta.Text = Me.cuenta_completa_
        Else
            Me.txtDescripcion.Text = String.Empty
        End If

        If Me.accion_.Equals("select") Then
            Me.btnGuardar.Text = "Aceptar"
            Me.txtDescripcion.Enabled = False
        Else
            Me.txtDescripcion.Enabled = True
            Me.btnGuardar.Text = "Guardar"
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim statement_ As String = String.Empty
        Dim value_ As String = String.Empty
        Dim existe_cuenta_ As Boolean = objEntidad.checkFor("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_CUENTAS WHERE CUENTA_COMPLETA = '" & Me.txtCuenta.Text.Trim() & "' AND COMPAÑIA=" & Compañia, "CUENTA", value_)
        Dim salvar_ As Boolean = True

        If txtDescripcion.Text.Length > 0 Then
            Me.btnGuardar.Enabled = False
            errP.SetError(txtDescripcion, "")

            Select Case accion_
                Case "insert"
                    statement_ = "INSERT INTO dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION (DESCRIPCION_CLASIFICACION, COMPAÑIA, CUENTACONTABLE, CUENTACOMPLETA) VALUES ('" & txtDescripcion.Text & "', " & Compañia & ", " & value_ & ", '" & Me.txtCuenta.Text & "')"
                Case "update"
                    statement_ = "UPDATE dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION  SET DESCRIPCION_CLASIFICACION = '" & txtDescripcion.Text & "', CUENTACONTABLE=" & value_ & ", CUENTACOMPLETA='" & Me.txtCuenta.Text & "' WHERE COMPAÑIA=" & Compañia & " AND CLASIFICACION = " & Me.codigo_
                Case "delete"
                    statement_ = "DELETE FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CLASIFICACION WHERE COMPAÑIA=" & Compañia & " AND CLASIFICACION = " & Me.codigo_
                Case "select"
                    salvar_ = False
            End Select

            If salvar_ Then
                objEntidad.execute(statement_)
                MsgBox("Operación Exitosa", MsgBoxStyle.Information, "Contabilidad Activo Fijo")
            End If
            Me.Close()
        Else
            errP.SetError(txtDescripcion, "Requerido")
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFindCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCuentas.Click
        Dim cuentas_ As New Contabilidad_BusquedaCuentas
        cuentas_.LibroContable_Value = 1
        cuentas_.ShowDialog()
        Me.txtCuenta.Text = Tipo
    End Sub
End Class