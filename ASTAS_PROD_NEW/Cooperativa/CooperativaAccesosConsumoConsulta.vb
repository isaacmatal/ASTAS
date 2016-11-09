Imports System.Data
Imports System.Data.SqlClient

Public Class CooperativaAccesosConsumoConsulta
    Dim sql As String
    Dim Table As DataTable
    Dim jClass As New jarsClass

    Private Sub CooperativaAccesosConsumoConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        ConsultaBloqueados()
        Me.dgvAccesos.AutoGenerateColumns = False
    End Sub

    Private Sub ConsultaBloqueados()
        sql = "SELECT CONVERT(VARCHAR, CODIGO_EMPLEADO) AS CODIGO_EMPLEADO, NOMBRE_COMPLETO, MOTIVO_BLOQUEO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND BLOQUEADO = 1 AND ESTATUS > 0"
        Table = jClass.obtenerDatos(New SqlCommand(sql))
        Me.dgvAccesos.DataSource = Table
    End Sub

    Private Sub dgvAccesos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellDoubleClick
        Dim codBuxis As Integer
        Dim FechaUltPago As Date
        Dim frmVer As New frmReportes_Ver
        Dim rpt As New ReporteDescuentoNoBuxis
        Dim Rpt1 As New CooperativaReporteDescuentosNoAplicados
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim tblNoAplicados, tblUltFecPago As DataTable
        If e.RowIndex > -1 Then
            codBuxis = Me.dgvAccesos.Rows(e.RowIndex).Cells(0).Value
            tblUltFecPago = jClass.obtenerDatos(New SqlCommand("SELECT MAX(FEC_ACU_HD) AS FECHA FROM PLANILLA_DESCUENTOS_APLICADOS WHERE COD_MF = " & codBuxis))
            If tblUltFecPago.Rows.Count > 0 Then
                If Not IsDBNull(tblUltFecPago.Rows(0).Item("FECHA")) Then
                    FechaUltPago = CDate(tblUltFecPago.Rows(0).Item("FECHA"))
                Else
                    Return
                End If
            Else
                Return
            End If
            sql = "EXECUTE [Coo].[sp_COOPERATIVA_PROGRAMACIONES_PARA_BUXIS] "
            sql &= "@COMPAÑIA = " & Compañia & ", "
            sql &= "@FECHA_PERIODO = '" & Format(FechaUltPago, "dd/MM/yyyy") & "', "
            sql &= "@NUM_SOLICITUD = 0, "
            sql &= "@BANDERA = 9, "
            sql &= "@CODAS = '" & Me.txtCodigo.Text & "', "
            sql &= "@CODBUXIS = " & codBuxis
            tblNoAplicados = jClass.obtenerDatos(New SqlCommand(sql))
            TextObj = Rpt1.Section2.ReportObjects.Item("Text13")
            TextObj.Text = Descripcion_Compañia
            Rpt1.SetDataSource(tblNoAplicados)
            frmVer.ReportesGenericos(Rpt1)
            frmVer.crvReporte.DisplayGroupTree = False
            frmVer.ShowDialog()
        End If
    End Sub

    Private Sub dgvAccesos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccesos.CellEnter
        If e.RowIndex > -1 Then
            cargaDatos(Me.dgvAccesos.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub cargaDatos(ByVal _codBuxis As Integer)
        Try
            While Me.dgvAutorizados.Rows.Count > 0
                Me.dgvAutorizados.Rows.RemoveAt(0)
            End While
            Dim TableData As DataTable
            sql = "  SELECT S.DESCRIPCION_SOLICITUD, A.MONTO_MAXIMO, A.SOLICITUD, A.VIGENTE_HASTA " & vbCrLf
            sql &= "    FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO] A, COOPERATIVA_CATALOGO_SOLICITUDES S" & vbCrLf
            sql &= "   WHERE A.COMPAÑIA = S.COMPAÑIA AND A.SOLICITUD = S.SOLICITUD" & vbCrLf
            sql &= "     AND A.COMPAÑIA = " & Compañia & vbCrLf
            sql &= "     AND A.CODIGO_EMPLEADO = " & _codBuxis & vbCrLf
            sql &= "     AND A.MONTO_MAXIMO > 0"
            TableData = jClass.obtenerDatos(New SqlCommand(sql))
            If TableData.Rows.Count > 0 Then
                For i As Integer = 0 To TableData.Rows.Count - 1
                    Me.dgvAutorizados.Rows.Add(TableData.Rows(i).Item(0), TableData.Rows(i).Item(1), TableData.Rows(i).Item(3), TableData.Rows(i).Item(2))
                Next
            Else
                Me.dgvAutorizados.Rows.Add("No tiene consumos autorizados", 0, Now, 0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged, txtNombre.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = Table.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvAccesos.DataSource = Table
        Else
            rows = Table.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvAccesos.DataSource = Nothing
            Me.dgvAccesos.DataSource = tablaT
        End If
    End Sub

    Private Sub CooperativaAccesosConsumoConsulta_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub dgvAutorizados_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAutorizados.CellDoubleClick
        Dim tblHistorial As DataTable
        Dim rpt2 As New Cooperativa_Accesos_Consumo_Historial_rpt
        Dim frmVer As New frmReportes_Ver
        Try
            sql = "SELECT S.DESCRIPCION_SOLICITUD, A.MONTO_MAXIMO, A.USUARIO_CREACION, A.USUARIO_CREACION_FECHA, SOC.NOMBRE_COMPLETO, '" & Descripcion_Compañia & "' AS ASOCIACION" & vbCrLf
            sql &= "  FROM [dbo].[COOPERATIVA_ACCESO_CONSUMO_BLOQUEADO_HISTORIAL] A, COOPERATIVA_CATALOGO_SOLICITUDES S,COOPERATIVA_CATALOGO_SOCIOS SOC" & vbCrLf
            sql &= " WHERE A.COMPAÑIA = S.COMPAÑIA And A.SOLICITUD = S.SOLICITUD" & vbCrLf
            sql &= "   AND A.COMPAÑIA = SOC.COMPAÑIA AND A.CODIGO_EMPLEADO = SOC.CODIGO_EMPLEADO" & vbCrLf
            sql &= "   AND A.COMPAÑIA = " & Compañia & vbCrLf
            sql &= "   AND A.CODIGO_EMPLEADO = " & Me.dgvAccesos.CurrentRow.Cells(0).Value & vbCrLf
            sql &= "   AND A.MONTO_MAXIMO > 0"
            tblHistorial = jClass.obtenerDatos(New SqlCommand(sql))
            rpt2.SetDataSource(tblHistorial)
            frmVer.ReportesGenericos(rpt2)
            frmVer.ShowDialog()
        Catch EX As Exception
            MsgBox("No se pudieron cargar los datos" & vbCrLf & EX.Message, MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub
End Class