Imports System.Data.SqlClient

Public Class FrmCooperativaBloqueoSelectivo
    Dim Sql As String
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub FrmCooperativaBloqueoSelectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub FrmCooperativaBloqueoSelectivo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TxtCodigoEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoEmpleado.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            cargaDatos()
        End If
    End Sub

    Private Sub cargaDatos()
        Dim tblDatos As DataTable
        If Me.TxtCodigoEmpleado.Text.Length > 0 Then
            Sql = "EXECUTE sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO = " & Me.TxtCodigoEmpleado.Text & ", @CODIGO_EMPLEADO_AS = '000000', @IUD = 'CBUXI'"
            tblDatos = jClass.obtenerDatos(New SqlCommand(Sql))
            If (tblDatos.Rows.Count) <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & tblDatos.Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & tblDatos.Rows(0).Item(3))
            Dim Autorizado As Boolean = False
            Dim arrOrig() As String = Permitir.Split(",")
            For i As Integer = 0 To arrOrig.Length - 1
                If Origen = CInt(arrOrig(i)) Then
                    Autorizado = True
                End If
            Next
            If Not Autorizado Then
                MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, tblDatos.Rows(0).Item(2) & " - " & tblDatos.Rows(0).Item(3))
                Return
            End If

            Me.txtNOMBRE.Text = tblDatos.Rows(0).Item(4) & " " & tblDatos.Rows(0).Item(5)
            Me.txtEmpresa.Text = jClass.obtenerEscalar("SELECT DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & Origen)
            Me.TxtDepto.Text = tblDatos.Rows(0).Item(7)
            Me.TxtCargo.Text = tblDatos.Rows(0).Item(9)

            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS] " & Compañia & ", " & Me.TxtCodigoEmpleado.Text & ", 0, 0"
            tblDatos = jClass.obtenerDatos(New SqlCommand(Sql))
            While Me.dgvSeleccion.Rows.Count > 0
                Me.dgvSeleccion.Rows.RemoveAt(0)
            End While
            For i As Integer = 0 To tblDatos.Rows.Count - 1
                Me.dgvSeleccion.Rows.Add(tblDatos.Rows(i).Item(0), tblDatos.Rows(i).Item(1), tblDatos.Rows(i).Item(2), tblDatos.Rows(i).Item(3), tblDatos.Rows(i).Item(4), "N")
            Next
        End If
    End Sub

    Private Sub dgvSeleccion_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccion.CellEndEdit
        Me.dgvSeleccion.Rows(e.RowIndex).Cells("modified").Value = "S"
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        For i As Integer = 0 To Me.dgvSeleccion.Rows.Count - 1
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS_IUD]" & vbCrLf
            Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
            Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoEmpleado.Text & vbCrLf
            Sql &= ",@SOLICITUD       = " & Me.dgvSeleccion.Rows(i).Cells("solic").Value & vbCrLf
            Sql &= ",@LIMITE_APROBADO = " & Me.dgvSeleccion.Rows(i).Cells("autorizedlimit").Value & vbCrLf
            Sql &= ",@MOTIVO          = '" & Me.dgvSeleccion.Rows(i).Cells("blockedreason").Value & "'" & vbCrLf
            Sql &= ",@USUARIO         = '" & Usuario & "'" & vbCrLf
            Sql &= ",@MODIFICADO      = " & IIf(Me.dgvSeleccion.Rows(i).Cells("modified").Value = "S", "1", "0") & vbCrLf
            Sql &= ",@IUD             = '" & IIf(Me.dgvSeleccion.Rows(i).Cells("blocked").Value, "I", "D") & "'" & vbCrLf
            jClass.Ejecutar_ConsultaSQL(Sql)
        Next
        MsgBox("PROCESO FINALIZADO", MsgBoxStyle.Information, "Bloqueo Selectivo")
        cargaDatos()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        For Each ctrl As Control In Me.Controls
            If TypeOf (ctrl) Is TextBox Then
                CType(ctrl, TextBox).Clear()
            End If
        Next
        While Me.dgvSeleccion.Rows.Count > 0
            Me.dgvSeleccion.Rows.RemoveAt(0)
        End While
        Me.TxtCodigoEmpleado.Focus()
    End Sub

    Private Sub btnHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorial.Click
        Dim tblHistorico As DataTable
        Dim Rpt As New Cooperativa_Bloqueo_Selectivo_Historial
        Dim frmVer As New frmReportes_Ver
        Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_TIEMPO_LABOR_CREDITOS]" & vbCrLf
        Sql &= " @COMPAÑIA        = " & Compañia & vbCrLf
        Sql &= ",@CODIGO_EMPLEADO = " & Me.TxtCodigoEmpleado.Text & vbCrLf
        Sql &= ",@SOLICITUD       = 0" & vbCrLf
        Sql &= ",@BANDERA         = 2" & vbCrLf
        tblHistorico = jClass.obtenerDatos(New SqlCommand(Sql))
        Rpt.SetDataSource(tblHistorico)
        frmVer.crvReporte.ReportSource = Rpt
        frmVer.ShowDialog()
    End Sub
End Class