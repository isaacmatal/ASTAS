Imports System.Data.SqlClient

Public Class Cooperativa_Corte_Cafeteria_x_Socio
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sql, Solicitudes As String
    Dim Permitir As String

    Private Sub Cooperativa_Corte_Cafeteria_x_Socio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Try
            Me.dtpDesde.Value = jClass.obtenerEscalar("EXECUTE [dbo].[sp_CAFETERIA_PARTIDAS_PROCESADAS] @COMPAÑIA = " & Compañia & ", @BANDERA = 0")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub Cooperativa_Corte_Cafeteria_x_Socio_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TxtCodBuxy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Me.dtpDesde.Focus()
        End If
        jClass.soloNumeros(e)
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'End If
    End Sub

    Private Sub TxtCodBuxy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodBuxy.LostFocus
        If Me.TxtCodBuxy.Text.Length > 0 Then
            ParamcodigoAs = ""
            ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
            Btn_Socio_limpiar.PerformClick()
            BusquedaDatosSocios(Permitir)
            ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
        End If
    End Sub

    Private Sub BusquedaDatosSocios(ByVal Origenes As String)
        Dim Accion As String
        Dim CBuxi As Integer
        Dim Autorizado As Boolean = False
        Dim arrOrig() As String = Origenes.Split(",")
        If Val(ParamcodigoBux) <= 0 Then
            MessageBox.Show("Ingrese CODIGO BUXIS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf Trim(ParamcodigoAs) <> Nothing Or Val(ParamcodigoBux) > 0 Then
            CBuxi = Val(ParamcodigoBux)
        End If
        Accion = "cbuxi"
        Try
            sql = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','000000','" & Accion & "'"
            Table = jClass.obtenerDatos(New SqlCommand(sql))

            If Table.Rows.Count <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item(3))
            For i As Integer = 0 To arrOrig.Length - 1
                If Origen = CInt(arrOrig(i)) Then
                    Autorizado = True
                End If
            Next
            If Not Autorizado Then
                MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, Table.Rows(0).Item(2) & " - " & Table.Rows(0).Item(3))
                Return
            End If

            Me.TxtCodBuxy.Text = Table.Rows(0).Item(3)
            Me.TxtSoNombre.Text = Table.Rows(0).Item(4) & " " & Table.Rows(0).Item(5)
            Me.txtDivision.Text = Table.Rows(0).Item(6)
            Me.TxtDepto.Text = Table.Rows(0).Item(7)
            Me.TxtSeccion.Text = Table.Rows(0).Item(8)
            Me.TxtCargo.Text = Table.Rows(0).Item(9)
            Me.txtEmpresa.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & Origen)
            Me.txtPeriodoPago.Text = jClass.obtenerEscalar("SELECT CASE PERIODO_PAGO WHEN 'QQ' THEN 'Quincenal' ELSE 'Mensual' END FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Table.Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & Table.Rows(0).Item(3))
            cargaTickets()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        Dim Prin As New FrmBuscarSocios
        Prin.Compañia_Value = Compañia
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Then
            Me.TxtCodBuxy.Text = ParamcodigoBux
            BusquedaDatosSocios(Permitir)
        End If
    End Sub

    Private Sub cargaTickets()
        Table = jClass.obtenerDatos(New SqlCommand("EXECUTE [dbo].[sp_CAFETERIA_PARTIDAS_PROCESADAS] @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & ", @FECHA1 = '" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "', @FECHA2 = '" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "', @BANDERA = 1"))
        For Each row As DataRow In Table.Rows
            Me.dgvDeducciones.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6))
        Next
        'Me.dgvDeducciones.DataSource = Table
        Try
            Me.txtTotalP1.Text = Format(Table.Compute("Sum(MONTO)", "PLANTA=1"), "0.00")
        Catch ex As Exception
            Me.txtTotalP1.Text = "0.00"
        End Try
        Try
            Me.txtTotalP2.Text = Format(Table.Compute("Sum(MONTO)", "PLANTA=2"), "0.00")
        Catch ex As Exception
            Me.txtTotalP2.Text = "0.00"
        End Try
    End Sub

    Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
        If Me.TxtCodBuxy.Text.Length > 0 Then
            cargaTickets()
        End If
    End Sub

    Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
        If Me.TxtCodBuxy.Text.Length > 0 Then
            cargaTickets()
        End If
    End Sub

    Private Sub CrearProgramaciones()
        Dim FPro As New Facturacion_Procesos
        Dim numSoli As Integer = 0
        Dim TipoSoliCaf1 As Integer = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
        Dim TipoSoliCaf2 As Integer = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
        Dim Periodo As String = StrDup(2, Me.txtPeriodoPago.Text.Substring(0, 1))
        Dim RowsAfected As Integer = 0
        Dim fechaPago As Date = CDate(jClass.obtenerEscalar("SELECT MAX(FECHA_PAGO) AS ULTFECHAPAGO FROM COOPERATIVA_RESUMEN_DESCUENTOS_ENVIADOS WHERE COMPAÑIA = " & Compañia & " AND PERIODO_PAGO = '" & Periodo & "'"))
        If Periodo = "QQ" Then
            fechaPago = SetearFechas(fechaPago.AddDays(10))
        Else
            fechaPago = SetearFechas(fechaPago.AddDays(20))
        End If
        Solicitudes = ""
        If Val(Me.txtTotalP1.Text) > 0 Then
            numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
            Solicitudes &= numSoli & " de Cafeteria Planta 1 por $ " & Me.txtTotalP1.Text & IIf(Val(Me.txtTotalP2.Text) > 0, vbCrLf, "")
            FPro.SolicitudesFacturacionSocios(Compañia, TipoSoliCaf1, numSoli, "0", Me.TxtCodBuxy.Text, Now(), 1, Val(Me.txtTotalP1.Text), 0, 0, Periodo, 1, fechaPago, "Consumo en Cafeteria", 0, 0)
            sql = "EXECUTE [dbo].[sp_CAFETERIA_PARTIDAS_PROCESADAS]" & vbCrLf
            sql &= "@COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@CODIGO_EMPLEADO= " & Me.TxtCodBuxy.Text & vbCrLf
            sql &= ",@FECHA1         = '" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@FECHA2         = '" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@NUMSOLI        = '" & numSoli & "'" & vbCrLf
            sql &= ",@PLANTA         = 1" & vbCrLf
            sql &= ",@BANDERA        = 2" & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(sql))
        End If
        If Val(Me.txtTotalP2.Text) > 0 Then
            numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
            Solicitudes &= numSoli & " de Cafeteria Planta 2 por $ " & Me.txtTotalP2.Text
            FPro.SolicitudesFacturacionSocios(Compañia, TipoSoliCaf2, numSoli, "0", Me.TxtCodBuxy.Text, Now(), 1, Val(Me.txtTotalP2.Text), 0, 0, Periodo, 1, fechaPago, "Consumo en Cafeteria", 0, 0)
            sql = "EXECUTE [dbo].[sp_CAFETERIA_PARTIDAS_PROCESADAS]" & vbCrLf
            sql &= "@COMPAÑIA       = " & Compañia & vbCrLf
            sql &= ",@CODIGO_EMPLEADO= " & Me.TxtCodBuxy.Text & vbCrLf
            sql &= ",@FECHA1         = '" & Format(Me.dtpDesde.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@FECHA2         = '" & Format(Me.dtpHasta.Value, "dd/MM/yyyy") & "'" & vbCrLf
            sql &= ",@NUMSOLI        = '" & numSoli & "'" & vbCrLf
            sql &= ",@PLANTA         = 2" & vbCrLf
            sql &= ",@BANDERA        = 2" & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(sql))
        End If
        If Solicitudes.Length > 0 Then
            MsgBox("Se ha" & IIf(Solicitudes.Contains(","), "n", "") & " generado la" & IIf(Solicitudes.Contains(","), "s", "") & " siguiente" & IIf(Solicitudes.Contains(","), "s", "") & " solicitud" & IIf(Solicitudes.Contains(","), "es:", ":") & vbCrLf & Solicitudes, MsgBoxStyle.Information, "Programación Generada")
            Me.Btn_Socio_limpiar.PerformClick()
        End If
    End Sub

    Private Function SetearFechas(ByVal Fecha As Date) As Date
        Dim FechaNew As Date = Fecha
        If Fecha.Day <= 15 Then
            FechaNew = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 15 And Fecha.Day <= Date.DaysInMonth(Fecha.Year, Fecha.Month) Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    FechaNew = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    FechaNew = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                FechaNew = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        End If
        Return FechaNew
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        CrearProgramaciones()
    End Sub

    Private Sub Btn_Socio_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click
        For Each control As Control In Me.GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        For Each control As Control In Me.grbCalculos.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
        'Me.dgvDeducciones.DataSource = Nothing
        While Me.dgvDeducciones.Rows.Count > 0
            Me.dgvDeducciones.Rows.RemoveAt(0)
        End While
        Me.TxtCodBuxy.Focus()
    End Sub
End Class