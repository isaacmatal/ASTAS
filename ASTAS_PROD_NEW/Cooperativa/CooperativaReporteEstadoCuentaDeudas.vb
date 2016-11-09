Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaReporteEstadoCuentaDeudas
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub CooperativaReporteEstadoCuentaDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.crvReporte.BackColor = Color.AliceBlue
        Me.crvReporte.ForeColor = Color.Navy
        Me.dgvTipoSolicitud.AutoGenerateColumns = False
        Me.dpDesde.Value = Now.AddDays(-Now.Day).AddDays(1)
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargaTipos()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CooperativaReporteEstadoCuentaDeudas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub CargaTipos()
        Sql = "SELECT SOLICITUD, DESCRIPCION_SOLICITUD AS DESCRIPCION FROM COOPERATIVA_CATALOGO_SOLICITUDES"
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        Me.dgvTipoSolicitud.DataSource = Table
    End Sub

    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        BusquedaSocio()
    End Sub

    Sub BusquedaSocio()
        Dim Prin As New FrmBuscarSocios
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2
        NombrePaciente = ""
        Prin.Compañia_Value = Compañia
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Me.txtCodBuxis.Text = ParamcodigoBux
            Me.txtCodSocio.Text = ParamcodigoAs
            Me.lblNombreSocio.Text = NombrePaciente
        End If
    End Sub

    Private Sub btnLimpiarCampos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCampos.Click
        Me.txtCodBuxis.Clear()
        Me.txtCodSocio.Clear()
        Me.lblNombreSocio.Text = ""
        Me.txtCodBuxis.Focus()
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.ReportSource = Nothing
        Me.txtRetiroConcepto.Visible = False
        Me.crvReporte.BackColor = Color.AliceBlue
        Me.crvReporte.ForeColor = Color.Navy
        Me.txtCodBuxis.Focus()
    End Sub

    Private Sub Reporte(ByVal CodBux As Integer, ByVal CodAS As String)
        Dim rpt As New CooperativaEstadoCuentaDeudas
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim tipos As String = String.Empty
        For i As Integer = 0 To Me.dgvTipoSolicitud.Rows.Count - 1
            If Me.dgvTipoSolicitud.Rows(i).Cells("selec").Value Then
                If tipos.Length = 0 Then
                    tipos &= Me.dgvTipoSolicitud.Rows(i).Cells("tiposoli").Value.ToString()
                Else
                    tipos &= "," & Me.dgvTipoSolicitud.Rows(i).Cells("tiposoli").Value.ToString()
                End If
            End If
        Next
        If tipos.Length = 0 Then
            MsgBox("Seleccione al menos un tipo de solicitud.", MsgBoxStyle.Information, "Seleccionar Tipo")
            Return
        End If
        If tipos.Contains(",") Then
            Me.crvReporte.DisplayGroupTree = True
        Else
            Me.crvReporte.DisplayGroupTree = False
        End If
        txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        If Origen = 5 Or Origen = 6 Then
            txtObj.Text = jClass.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2").ToString()
        Else
            txtObj.Text = Descripcion_Compañia
        End If
        If VerificaRetiro() Then
            txtObj = rpt.Section2.ReportObjects.Item("txtRet")
            txtObj.Text = Me.txtRetiroConcepto.Text
            txtObj.ObjectFormat.EnableSuppress = False
        End If
        txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "PERIODO DEL " & Me.dpDesde.Value.ToShortDateString & " AL " & Me.dpHasta.Value.ToShortDateString
        txtObj = rpt.Section2.ReportObjects.Item("txtNombre")
        txtObj.Text = "B" & Me.txtCodBuxis.Text & " - AS" & Me.txtCodSocio.Text & " " & Me.lblNombreSocio.Text
        Sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] " & vbCrLf
        Sql &= "	@COMPAÑIA = " & Compañia & "," & vbCrLf
        Sql &= "	@DEDUCCION = '" & tipos & "'," & vbCrLf
        Sql &= "	@CodigoBuxis = " & Me.txtCodBuxis.Text & "," & vbCrLf
        Sql &= "	@FECHA_DESDE = '" & Format(Me.dpDesde.Value, "dd/MM/yyyy") & "'," & vbCrLf
        Sql &= "	@FECHA_HASTA = '" & Format(Me.dpHasta.Value, "dd/MM/yyyy") & "'" & vbCrLf
        sqlCmd.CommandText = Sql
        Table = jClass.obtenerDatos(sqlCmd)
        rpt.SetDataSource(Table)
        Me.crvReporte.ReportSource = rpt
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Me.txtCodBuxis.Text <> Nothing Then
            Try
                Reporte(Me.txtCodBuxis.Text, Me.txtCodSocio.Text)
            Catch ex As Exception
                jClass.msjError(ex, "EstadoCtaDeudas")
            End Try
        End If
    End Sub

    Private Sub txtCodBuxis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBuxis.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btnGenerar.Focus()
        End If
    End Sub

    Private Sub txtCodBuxis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodBuxis.LostFocus
        If Me.txtCodBuxis.Text <> Nothing Then
            Try
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & " AND COMPAÑIA = " & Compañia
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Origen = CInt(Table.Rows(0).Item("ORIGEN"))
                    If Not Permitir.Contains(Origen.ToString()) Then
                        MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, Table.Rows(0).Item("CODIGO_EMPLEADO") & " - " & Table.Rows(0).Item("CODIGO_EMPLEADO_AS"))
                        Return
                    End If
                    Me.txtCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtCodSocio.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.lblNombreSocio.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                Else
                    Me.txtCodSocio.Clear()
                    Me.txtCodBuxis.Clear()
                    MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
            End Try
        End If
    End Sub

    Private Function VerificaRetiro() As Boolean
        Dim tblIngreso, tblRetiro As DataTable
        Dim Retirado As Boolean = False
        Dim Total_Ahorro As Double = jClass.obtenerEscalar("SELECT ISNULL(SUM(CUOTA_ORDINARIO), 0.00) FROM COOPERATIVA_SOCIO_AHORROS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text)
        If Total_Ahorro <= 0 Then
            Sql = "SELECT TOP 1 USUARIO_CREACION_FECHA" & vbCrLf
            Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS_ASOCIACION_HISTORIAL" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO_AS = '" & Me.txtCodSocio.Text & "'" & vbCrLf
            Sql &= "   AND ESTADO = 1" & vbCrLf
            Sql &= " ORDER BY USUARIO_CREACION_FECHA DESC"
            tblIngreso = jClass.obtenerDatos(New SqlCommand(Sql))
            Sql = "SELECT TOP 1 USUARIO_CREACION_FECHA, MOTIVO" & vbCrLf
            Sql &= "  FROM COOPERATIVA_CATALOGO_SOCIOS_ASOCIACION_HISTORIAL" & vbCrLf
            Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & vbCrLf
            Sql &= "   AND CODIGO_EMPLEADO_AS = '" & Me.txtCodSocio.Text & "'" & vbCrLf
            Sql &= "   AND ESTADO = 0" & vbCrLf
            Sql &= " ORDER BY USUARIO_CREACION_FECHA DESC"
            tblRetiro = jClass.obtenerDatos(New SqlCommand(Sql))
            If tblRetiro.Rows.Count > 0 And tblIngreso.Rows.Count > 0 Then
                If tblRetiro.Rows(0).Item(0) > tblIngreso.Rows(0).Item(0) Then
                    Me.txtRetiroConcepto.Text = "Fecha Retiro: " & Format(tblRetiro.Rows(0).Item(0), "dd/MM/yyyy") & vbCrLf & tblRetiro.Rows(0).Item(1)
                    Me.txtRetiroConcepto.Visible = True
                    Retirado = True
                End If
            End If
        End If
        Return Retirado
    End Function

    Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        For i As Integer = 0 To Me.dgvTipoSolicitud.Rows.Count - 1
            Me.dgvTipoSolicitud.Rows(i).Cells("selec").Value = Me.chkTodas.Checked
        Next
    End Sub
End Class