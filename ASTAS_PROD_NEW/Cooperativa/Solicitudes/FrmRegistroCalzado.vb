Imports System.Data
Imports System.Data.SqlClient
Public Class FrmRegistroCalzado
    Dim Res As Integer
    Dim IU As Integer = 1
    Dim ValorVale, PorcVale As Double
    Dim jClass As New jarsClass
    Dim sqlcmd As New SqlCommand
    Dim Table As DataTable
    Dim Sql As String

    Private Sub FrmRegistroCalzado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgvValesSolicitud.AutoGenerateColumns = False
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        DpFechaEntrega.Value = Now
        Iniciando = False
    End Sub

    Private Sub BtnBuscarSol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        LimpiarCampos()
        ParamcodSolicitud = Nothing
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSol As New FrmBusquedaSolicitudesCalzado
        FrmBuscarSol.Compañia_Value = Compañia
        FrmBuscarSol.CbxCompañia.Enabled = False
        FrmBuscarSol.ShowDialog()
        If ParamcodSolicitud <> Nothing Then
            MuestraSolicitud()
            'If SolicitudesNoModificables() = True Then
            '    Me.BtnGuardar.Enabled = False
            '    MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
            '    Return
            'Else
            '    Me.BtnGuardar.Enabled = True
            'End If
            MuestraDetalleCupones(2)
        End If
    End Sub

    Private Function VerificaRegistroCupon() As Boolean
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES_CALZADO " & Compañia & "," & TxtNumeroSol.Text & "," & 0 & "," & 0 & "," & 0 & "," & 2
            sqlcmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlcmd)
            If Table.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            jClass.msjError(ex, "VerificaRegistroCupon()")
        End Try
    End Function

    Private Sub MuestraSolicitud()
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_BUSQUEDA_SOLICITUDES " & Compañia _
            & "," & ParamcodSolicitud & "," & 0 & "," & 0 & ",''," & 1 & "," & Cotizacion
            sqlcmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlcmd)
            If Table.Rows.Count > 0 Then
                Me.TxtNumeroSol.Text = Table.Rows(0).Item("CORRELATIVO")
                Me.TxtCodigoAs.Text = Table.Rows(0).Item("CODIGO_AS")
                Me.TxtCodigoBuxis.Text = Table.Rows(0).Item("CODIGO_BUXIS")
                Me.TxtNombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Me.TxtDepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                Me.TxtDivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                Me.txtTotal.Text = Table.Rows(0).Item("VALOR_VALE")
                cargaTipoSolicitud(Table.Rows(0).Item("SOLICITUD"))
                cargaValores(Me.cmbTipoVale.SelectedValue)
            End If
        Catch ex As Exception
            jClass.msjError(ex, "MuestraSolicitud()")
        End Try
    End Sub

    Private Sub MuestraDetalleCupones(ByVal Bandera)
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_REGISTRO_VALES_CALZADO_SIUD"
            Sql &= "  @COMPAÑIA = " & Compañia
            Sql &= ", @N_SOLICITUD = " & Me.TxtNumeroSol.Text
            sqlcmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlcmd)
            Me.dgvValesSolicitud.DataSource = Table
        Catch ex As Exception
            jClass.msjError(ex, "MuestraDetalleCupones()")
        End Try
    End Sub

    Private Sub TxtCorrelativoIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCorrelativoIni.TextChanged
        Dim CantidadSumar As Integer
        If Val(Trim(TxtCorrelativoIni.Text)) <> Nothing Or Val(Trim(TxtCorrelativoIni.Text)) > 0 Then
            CantidadSumar = CInt(TxtCorrelativoIni.Text) + CInt(Cantidad.Value) - 1
            TxtCorrelativoFin.Text = CStr(CantidadSumar)
            If Trim(TxtCorrelativoIni.Text) <> Nothing Then
                TxtTotalVale.Text = Format(Cantidad.Value * (ValorVale * (PorcVale / 100)), "0.00")
            Else
                TxtTotalVale.Text = 0
            End If
        Else
            TxtCorrelativoFin.Text = 0
            TxtTotalVale.Text = 0
        End If
    End Sub

    Private Sub Cantidad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.ValueChanged
        TxtTotalVale.Text = Format(Cantidad.Value * (ValorVale * (PorcVale / 100)), "0.00")
        If Val(Trim(TxtCorrelativoIni.Text)) <> Nothing Or Val(Trim(TxtCorrelativoIni.Text)) > 0 Then
            TxtCorrelativoFin.Text = CInt(TxtCorrelativoIni.Text) + CInt(Cantidad.Value) - 1
        Else
            TxtCorrelativoFin.Text = 0
        End If
    End Sub

    Private Function ValidarDatos()
        If TxtNumeroSol.Text = 0 Then
            MessageBox.Show("Debe de seleccionar una solicitud", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnBuscarSol.Focus()
            Return True
        End If
        If Cantidad.Value = 0 Or Cantidad.Value = Nothing Then
            MessageBox.Show("El valor de cantidad no es valido", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cantidad.Focus()
            Return True
        End If
        Return False
    End Function

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim Result As Object
        If ValidarDatos() = True Then
            Return
        End If
        If IU = 1 Then
            Sql = "EXECUTE Coo.sp_COOPERATIVA_REGISTRO_VALES_CALZADO_SIUD"
            Sql &= "  @COMPAÑIA         = " & Compañia
            Sql &= ", @N_SOLICITUD      = " & Val(Me.TxtNumeroSol.Text)
            Sql &= ", @TIPO_VALE        = " & Me.cmbTipoVale.SelectedValue
            Result = jClass.obtenerEscalar(Sql)
            If Result IsNot Nothing Then
                MsgBox("Ya hay un vale del tipo:" & vbCrLf & Me.cmbTipoVale.Text & vbCrLf & vbCrLf & "SUGERENCIA: Elimine o edite el ya existente.", MsgBoxStyle.Information, "Tipo no válido")
                Return
            End If
        Else
        End If
        Mantenimiento_Cupones(IU)
        LimpiaCamposDetalle()
        MuestraDetalleCupones(1)
    End Sub
    Private Sub Mantenimiento_Cupones(ByVal Bandera As Integer)
        Try
            Sql = "EXECUTE Coo.sp_COOPERATIVA_REGISTRO_VALES_CALZADO_SIUD"
            Sql &= "  @COMPAÑIA         = " & Compañia
            Sql &= ", @N_SOLICITUD      = " & Val(Me.TxtNumeroSol.Text)
            Sql &= ", @TIPO_VALE        = " & Me.cmbTipoVale.SelectedValue
            Sql &= ", @CODIGO_AS        = '" & (Me.TxtCodigoAs.Text) & "'"
            Sql &= ", @CODIGO_BUXIS     = " & Val(Me.TxtCodigoBuxis.Text)
            Sql &= ", @FECHA_ENTREGA    = '" & Format(Me.DpFechaEntrega.Value, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", @CANTIDAD_VALES   = " & Val(Me.Cantidad.Value)
            Sql &= ", @CORRELATIVO_INI  = " & Val(TxtCorrelativoIni.Text)
            Sql &= ", @CORRELATIVO_FIN  = " & Val(TxtCorrelativoFin.Text)
            Sql &= ", @TOTAL_VALE       = " & Val(TxtTotalVale.Text)
            Sql &= ", @FECHA_EMISION    = '" & Format(Me.DpFechaEmision.Value, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", @FECHA_VENCIMIENTO= '" & Format(Me.DpFechaVencimiento.Value, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", @USUARIO          = '" & Usuario & "'"
            Sql &= ", @BANDERA          = " & Bandera
            sqlcmd.CommandText = Sql
            Res = jClass.ejecutarComandoSql(sqlcmd)
            If Res > 0 Then
                Select Case Bandera
                    Case 1
                        MsgBox("¡Registro de cupones Guardados con éxito!", MsgBoxStyle.Information, "Mensaje")
                    Case 3
                        MsgBox("¡Registro de cupones Eliminado con éxito!", MsgBoxStyle.Information, "Mensaje")
                    Case 4
                        MsgBox("¡Registro de cupones Modificado con éxito!", MsgBoxStyle.Information, "Mensaje")
                End Select
            End If
        Catch ex As Exception
            jClass.msjError(ex, "MuestraSolicitud()")
        End Try
    End Sub

    Private Function SolicitudesNoModificables() As Boolean
        Dim Resultado As Object
        Dim bandera As Boolean
        Try
            Sql = "Execute Coo.sp_COOPERATIVA_SOLICITUDES_NO_MODIFICABLES " & Compañia & "," & TxtNumeroSol.Text
            Resultado = jClass.obtenerEscalar(Sql)
            If Resultado Is Nothing Then
                bandera = True
            Else
                bandera = False
            End If
        Catch ex As Exception
            jClass.msjError(ex, "MuestraSolicitud()")
        End Try
        Return bandera
    End Function

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        LimpiarCampos()
    End Sub

    Private Sub LimpiaCamposDetalle()
        Cantidad.Value = 0
        TxtCorrelativoIni.Text = "0"
        TxtCorrelativoFin.Text = "0"
        TxtTotalVale.Text = "0.00"
        IU = 1
    End Sub

    Private Sub LimpiarCampos()
        LimpiaCamposDetalle()
        txtTotal.Text = 0
        TxtNumeroSol.Text = 0
        'Socio
        Me.TxtCodigoAs.Text = Nothing
        Me.TxtCodigoBuxis.Text = Nothing
        Me.TxtNombre.Text = Nothing
        Me.TxtDepartamento.Text = Nothing
        Me.TxtDivision.Text = Nothing
        Me.BtnGuardar.Enabled = True
        DpFechaEmision.Value = DpFechaEntrega.Value
        DpFechaVencimiento.Value = DpFechaEntrega.Value
        While Me.dgvValesSolicitud.Rows.Count > 0
            Me.dgvValesSolicitud.Rows.RemoveAt(0)
        End While
    End Sub

    Private Sub cargaTipoSolicitud(ByVal TipoSoli As Integer)
        Try
            Iniciando = True
            Me.cmbTipoVale.DataSource = Nothing
            sqlcmd.CommandText = "SELECT CODIGO_VALE, DESCRIPCION FROM dbo.COOPERATIVA_CATALOGO_VALES "
            sqlcmd.CommandText &= "WHERE COMPAÑIA = " & Compañia & " AND TIPO_SOLICITUD = " & TipoSoli
            Table = jClass.obtenerDatos(sqlcmd)
            Me.cmbTipoVale.DataSource = Table
            Me.cmbTipoVale.ValueMember = "CODIGO_VALE"
            Me.cmbTipoVale.DisplayMember = "DESCRIPCION"
            Iniciando = False
        Catch ex As Exception
            jClass.msjError(ex, "cargaTipoSolicitud()")
        End Try
    End Sub

    Private Sub cargaValores(ByVal Tipo As Integer)
        If Not Iniciando Then
            Try
                Sql = "EXECUTE sp_COOPERATIVA_CATALOGO_VALES_SIUD"
                Sql &= "  @COMPAÑIA = " & Compañia
                Sql &= ", @CODIGO   = " & Tipo
                Sql &= ", @ACTIVO  = 1"
                Sql &= ", @SIUD  = 'SC'"
                sqlcmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlcmd)
                ValorVale = Table.Rows(0).Item("VALOR")
                PorcVale = Table.Rows(0).Item("PORCENTAJE")
            Catch ex As Exception
                jClass.msjError(ex, "cargaTipoSolicitud()")
            End Try
        End If
    End Sub
    Private Sub cmbTipoVale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoVale.SelectedIndexChanged
        If Not Iniciando Then
            cargaValores(Me.cmbTipoVale.SelectedValue)
        End If
    End Sub

    Private Sub dgvValesSolicitud_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvValesSolicitud.CellEnter
        Try
            Me.cmbTipoVale.SelectedValue = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(0).Value
            Me.DpFechaEntrega.Value = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(1).Value
            Me.Cantidad.Value = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(3).Value
            Me.TxtCorrelativoIni.Text = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(4).Value
            Me.TxtCorrelativoFin.Text = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(5).Value
            Me.TxtTotalVale.Text = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(6).Value
            Me.DpFechaEmision.Value = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(7).Value
            Me.DpFechaVencimiento.Value = Me.dgvValesSolicitud.Rows(e.RowIndex).Cells(8).Value
            IU = 4
        Catch ex As Exception
            jClass.msjError(ex, "cargaTipoSolicitud()")
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.Yes Then
            Mantenimiento_Cupones(3)
        End If
        MuestraDetalleCupones(1)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaCamposDetalle()
    End Sub

    Private Sub TxtNumeroSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroSol.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNumeroSol_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroSol.LostFocus
        Dim descrip As String
        If Val(Me.TxtNumeroSol.Text) > 0 Then
            Sql = "SELECT DESCRIPCION_SOLICITUD FROM VISTA_COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND  CORRELATIVO = " & TxtNumeroSol.Text
            descrip = jClass.obtenerEscalar(Sql)
            If descrip IsNot Nothing Then
                If descrip.Contains("VALE") Then
                    ParamcodSolicitud = Val(Me.TxtNumeroSol.Text)
                    MuestraSolicitud()
                    'If SolicitudesNoModificables() = True Then
                    '    Me.BtnGuardar.Enabled = False
                    '    MsgBox("¡La Solicitud esta en proceso de autorización!" & Chr(13) & "No podrá realizar cambios a la Solicitud.", MsgBoxStyle.Critical, "Validación")
                    '    Return
                    'Else
                    '    Me.BtnGuardar.Enabled = True
                    'End If
                    MuestraDetalleCupones(2)
                Else
                    MsgBox("Tipo de Solicitud no Válida:" & vbCrLf & vbCrLf & descrip, MsgBoxStyle.Information, "Tipo de Solicitud")
                End If
            Else
                MsgBox("Solicitud no Existe!!", MsgBoxStyle.Information, "Numero No Válido")
            End If
        End If
    End Sub

    Private Sub soloNumeros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCorrelativoIni.KeyPress, TxtCorrelativoFin.KeyPress
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> Convert.ToChar(Keys.Enter) And e.KeyChar <> ControlChars.Tab And Not Char.IsDigit(e.KeyChar) Then
            MsgBox("Debe digitar sólo números.", MsgBoxStyle.Information, "Validación")
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Val(Me.TxtNumeroSol.Text) > 0 And Me.dgvValesSolicitud.Rows.Count > 0 Then
            Dim frmVer As New frmReportes_Ver
            Dim rpt As New Cooperativa_Registro_Vales
            Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
            TextObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
            TextObj.Text = Descripcion_Compañia
            Sql = "EXECUTE Coo.sp_COOPERATIVA_REGISTRO_VALES_CALZADO_SIUD"
            Sql &= "  @COMPAÑIA = " & Compañia
            Sql &= ", @N_SOLICITUD = " & Val(Me.TxtNumeroSol.Text)
            Sql &= ", @BANDERA = 5"
            sqlcmd.CommandText = Sql
            rpt.SetDataSource(jClass.obtenerDatos(sqlcmd))
            frmVer.ReportesGenericos(rpt)
            frmVer.ShowDialog()
        ElseIf Val(Me.TxtNumeroSol.Text) = 0 Then
            MsgBox("No ha ingresado un Número de Solicitud válido.", MsgBoxStyle.Information, "Solicitud")
        ElseIf Me.dgvValesSolicitud.Rows.Count = 0 Then
            MsgBox("No hay vales registrados.", MsgBoxStyle.Information, "Vales")
        End If
    End Sub

    Private Sub TxtNumeroSol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroSol.TextChanged

    End Sub
End Class