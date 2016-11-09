Imports System.Data.SqlClient

Public Class frm_reporte_cooperativa_socio_hoja_datos

    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim sql As String
    Dim Permitir As String
    Dim Plantas02 As String
    Dim TipSoliP1, TipSoliP2 As Integer
    Dim Solicitudes As String

    Private Sub frm_reporte_cooperativa_socio_hoja_datos_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        If Solicitudes <> Nothing Then
            EliminaSolicitudesTemporales()
        End If
    End Sub

    Private Sub frm_reporte_cooperativa_socio_hoja_datos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.crvHojaDatosSocio.BackColor = Color.AliceBlue
        Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
    End Sub

    Private Sub txtCodSocio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSocio.KeyPress, txtCodBuxis.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Me.txtCodSocio.Text <> Nothing Or Me.txtCodBuxis.Text <> Nothing Then
                If Me.txtCodSocio.Text <> Nothing Then
                    Me.txtCodSocio.Text = Me.txtCodSocio.Text.PadLeft(6, "0")
                    sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.txtCodSocio.Text & "' AND COMPAÑIA = " & Compañia
                Else
                    sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & " AND COMPAÑIA = " & Compañia
                End If
                sqlCmd.CommandText = sql
                Try
                    Table = jClass.obtenerDatos(sqlCmd)
                    If Table.Rows.Count > 0 Then
                        Me.txtCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                        Me.txtCodSocio.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                        Reporte(Table.Rows(0).Item("CODIGO_EMPLEADO"), Me.txtCodSocio.Text)
                    Else
                        MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
                End Try
            End If
        End If
    End Sub

    Private Sub BtnBuscarSoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSoc.Click
        BusquedaSocio()
    End Sub

    Sub BusquedaSocio()
        Dim Prin As New FrmBuscarSocios
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2
        Prin.Compañia_Value = Compañia
        'Prin.CbxCompania.Enabled = False
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Me.txtCodBuxis.Text = ParamcodigoBux
            Me.txtCodSocio.Text = ParamcodigoAs
            Reporte(ParamcodigoBux, ParamcodigoAs)
        End If
    End Sub

    Private Sub Reporte(ByVal CodBux As Integer, ByVal CodAS As String)
        Dim Rpt As New rpt_reporte_cooperativa_socio_hoja_datos
        Dim fieldObj As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Try
            Origen = jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodBux & " AND CODIGO_EMPLEADO_AS = '" & CodAS & "'")
            Dim Autorizado As Boolean = False
            Dim arrOrig() As String = Permitir.Split(",")
            For i As Integer = 0 To arrOrig.Length - 1
                If Origen = CInt(arrOrig(i)) Then
                    Autorizado = True
                End If
            Next
            If Not Autorizado Then
                MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, CodBux & " - " & CodAS)
                Return
            End If
            If Solicitudes <> Nothing Then
                EliminaSolicitudesTemporales()
            End If
            If CInt(jClass.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CODIGO_BUXIS = " & CodBux & " AND CORRELATIVO > 2000000000 AND DEDUCCION IN (234, 245)")) = 0 Then
                NoProgCafe(CodBux)
            End If

            If CBool(jClass.obtenerEscalar("SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & CodBux & " AND CODIGO_EMPLEADO_AS = '" & CodAS & "' AND COMPAÑIA = " & Compañia)) Then
                Me.lblBloq.Visible = True
            End If

            sql = "EXEC SP_COOPERATIVA_SOCIOS_HOJA_DATOS_NEW " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @CodAS = '" & CodAS & "'" & vbCrLf
            sql &= ", @CodBuxi = " & CodBux & vbCrLf
            sql &= ", @SIUD = 'S02'"
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.SetDataSource(Table)

            If Table.Rows(0).Item("RETIRADO") Then
                'txtObj = Rpt.Section2.ReportObjects.Item("Text8")
                'txtObj.Text = "HOJA DE DATOS DEL SOCIO (RETIRADO)"
                txtObj = Rpt.Section2.ReportObjects.Item("Text1")
                txtObj.Text = "FECHA RETIRO ASOCIACION: " & Format(Table.Rows(0).Item("FECHA_RETIRO_ASOC"), "dd/MM/yyyy")
                txtObj.Color = Color.Red
                txtObj = Rpt.Section2.ReportObjects.Item("txtMotivo")
                txtObj.Text = Table.Rows(0).Item("MOTIVO")
                txtObj.ObjectFormat.EnableSuppress = False
                lblBloq.Text = "RETIRADO DE ASOCIACION"
                Me.lblBloq.Visible = True
            End If

            If Table.Rows(0).Item("BLOQUEADO") And Not Table.Rows(0).Item("RETIRADO") Then
                'txtObj = Rpt.Section2.ReportObjects.Item("Text8")
                'txtObj.Text = "HOJA DE DATOS DEL SOCIO (BLOQUEADO)"
                txtObj = Rpt.Section2.ReportObjects.Item("txtBloqueado")
                txtObj.ObjectFormat.EnableSuppress = False
            End If

            sql = "EXEC sp_COOPERATIVA_CATALOGO_SOCIOS_BENEFICIARIOS_AGREGAR " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @BENEFICIARIO = 0" & vbCrLf
            sql &= ", @CODIGOEMPLEADO = " & CodBux & vbCrLf
            sql &= ", @CODIGOEMPLEADOAS = '" & CodAS & "'" & vbCrLf
            sql &= ", @SIUD = 'S'" & vbCrLf
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.Subreports.Item(0).SetDataSource(Table)

            sql = "EXEC Coo.sp_COOPERATIVA_DEUDA_HDS " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @CodigoAS = '" & CodAS & "'" & vbCrLf
            sql &= ", @CodigoBuxis = " & CodBux & vbCrLf
            sql &= ", @SIUD = 'TESPA'" & vbCrLf
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.Subreports.Item(1).SetDataSource(Table)

            sql = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]  " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @CODIGO_EMPLEADO = " & CodBux & vbCrLf
            sql &= ", @BANDERA = 1" & vbCrLf
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.Subreports.Item(2).SetDataSource(Table)

            sql = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]  " & vbCrLf
            sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            sql &= ", @CODIGO_EMPLEADO = " & CodBux & vbCrLf
            sql &= ", @BANDERA = 4" & vbCrLf
            'sql = "EXEC [Coo].[sp_COOPERATIVA_MOSTRAR_FIADORES_SOCIO_DEUDA] " & vbCrLf
            'sql &= "@COMPAÑIA = " & Compañia & vbCrLf
            'sql &= ", @COD_BUXIS = " & CodBux & vbCrLf
            'sql &= ", @COD_AS = '" & CodAS & "'" & vbCrLf
            'sql &= ", @BANDERA = 0" & vbCrLf
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            Rpt.Subreports.Item(3).SetDataSource(Table)
            If Origen = 5 Or Origen = 6 Then
                fieldObj = Rpt.Section2.ReportObjects.Item("NOMBRECOMPAÑIA1")
                fieldObj.ObjectFormat.EnableSuppress = True
                txtObj = Rpt.Section2.ReportObjects.Item("txtATAF")
                txtObj.ObjectFormat.EnableSuppress = False
                txtObj.Text = jClass.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2")
            End If
            Me.crvHojaDatosSocio.ReportSource = Rpt
            Me.txtCodBuxis.Enabled = False
            Me.txtCodSocio.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error al generar reporte!!")
        End Try
    End Sub

    Private Sub btnLimpiarCampos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCampos.Click
        Me.txtCodBuxis.Clear()
        Me.txtCodSocio.Clear()
        Me.txtCodBuxis.Focus()
        Me.txtCodBuxis.Enabled = True
        Me.txtCodSocio.Enabled = True
        Me.lblBloq.Visible = False
        Me.crvHojaDatosSocio.ReportSource = Nothing
        Me.txtCodBuxis.Focus()
        If Solicitudes <> Nothing Then
            EliminaSolicitudesTemporales()
        End If
    End Sub

    Private Sub frm_reporte_cooperativa_socio_hoja_datos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub crvHojaDatosSocio_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles crvHojaDatosSocio.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Function NoProgCafe(ByVal CodBuxis As String) As Boolean
        Dim Table As DataTable
        Dim sqlCmd As New SqlClient.SqlCommand
        Plantas02 = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 16").ToString().Trim
        TipSoliP1 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 14")
        TipSoliP2 = jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 15")
        'SELECCIONA TODOS LOS TICKETS QUE HA CONSUMIDO EL EMPLEADO DESDE EL ULTIMO ENVIO A BUXIS
        '*****************************************************************************************************
        sqlCmd.CommandText = "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP1 & " AS TIPOSOLI, CONVERT(DATE, '" & Format(Now(), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA NOT IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS" & vbCrLf
        sqlCmd.CommandText &= "UNION" & vbCrLf
        sqlCmd.CommandText &= "SELECT A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS, SUM(A.MONTO)AS MONTO_TOTAL, MAX(B.NOMBRE_COMPLETO) AS NOMBRE, COUNT(A.CODIGO_EMPLEADO) AS TOTAL_TICKETS, " & TipSoliP2 & " AS TIPOSOLI, CONVERT(DATE, '" & Format(Now(), "dd/MM/yyyy") & "', 103) AS FECHA_PAGO" & vbCrLf
        sqlCmd.CommandText &= "		FROM  CAFETERIA_FACTURACION_ENCABEZADO A, COOPERATIVA_CATALOGO_SOCIOS B" & vbCrLf
        sqlCmd.CommandText &= "		WHERE A.COMPAÑIA = B.COMPAÑIA AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = B.CODIGO_EMPLEADO AND" & vbCrLf
        sqlCmd.CommandText &= "			A.COMPAÑIA = " & Compañia & "          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FECHA_FACTURA > CONVERT(DATE, '01/01/2014',103) AND"
        sqlCmd.CommandText &= "			A.BODEGA IN (" & Plantas02 & ") AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ANULADO  = 0          AND" & vbCrLf
        sqlCmd.CommandText &= "			A.ENVIADO = 0           AND" & vbCrLf
        sqlCmd.CommandText &= "			A.FORMA_PAGO = 2        AND" & vbCrLf
        sqlCmd.CommandText &= "			A.CODIGO_EMPLEADO = " & CodBuxis & vbCrLf
        sqlCmd.CommandText &= "		GROUP BY A.CODIGO_EMPLEADO, B.CODIGO_EMPLEADO_AS"
        'CARGA LOS DATOS EN TABLE
        Table = jClass.obtenerDatos(sqlCmd)
        '*****************************************************************************************************
        If Table.Rows.Count > 0 Then
            CrearProgramaciones(Table)
        End If
    End Function

    Private Function CrearProgramaciones(ByVal Tabla As DataTable) As Boolean
        Dim Cmd As New SqlClient.SqlCommand
        Dim FPro As New Facturacion_Procesos
        Dim cuantos As Integer
        Dim numSoli As Integer = 2147483647
        Dim RowsAfected As Integer = 0
        Dim Resultado As Boolean = False
        Solicitudes = ""
        cuantos = CInt(jClass.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli))
        For i As Integer = 0 To Tabla.Rows.Count - 1
            While cuantos > 0
                numSoli = numSoli - 1 'FPro.actualizaNumDoc(Compañia, "SOL")
                cuantos = jClass.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
            End While
            'numSoli = FPro.actualizaNumDoc(Compañia, "SOL")
            Solicitudes &= IIf(i = 0, "", ",") & numSoli
            FPro.SolicitudesFacturacionSocios(Compañia, Tabla.Rows(i).Item("TIPOSOLI"), numSoli, Tabla.Rows(i).Item("CODIGO_EMPLEADO_AS"), Tabla.Rows(i).Item("CODIGO_EMPLEADO"), Now(), 1, Tabla.Rows(i).Item("MONTO_TOTAL"), 0, 0, "QQ", 1, Tabla.Rows(i).Item("FECHA_PAGO"), "Consumo en Cafeteria", 0, 0)
            jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOLICITUDES SET USUARIO_EDICION = 'REPHOJADATOS' WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
            numSoli = numSoli - 1
            cuantos = jClass.obtenerEscalar("SELECT COUNT(CORRELATIVO) FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & numSoli)
        Next
        Return Resultado
    End Function

    Private Sub EliminaSolicitudesTemporales()
        Dim solicitudesArray As String() = Solicitudes.Split(",")
        For Each solicitud As Integer In solicitudesArray
            jClass.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & solicitud)
            jClass.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & solicitud)
            jClass.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_SOLICITUDES_AUTORIZACION WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud)
            jClass.Ejecutar_ConsultaSQL("DELETE FROM COOPERATIVA_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND CORRELATIVO = " & solicitud)
        Next
    End Sub

    Private Function SetearFechas() As Date
        Dim Fecha As Date = Now()
        If Fecha.Day <= 11 Then
            Fecha = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
        ElseIf Fecha.Day > 11 And Fecha.Day <= 27 And Fecha.Day <> 15 Then
            If Fecha.Month = 2 Then
                If Fecha.Year Mod 4 = 0 Then
                    Fecha = CDate("29/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                Else
                    Fecha = CDate("28/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
                End If
            Else
                Fecha = CDate("30/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString)
            End If
        ElseIf Fecha.Day > 27 And Fecha.Day <= 31 And Fecha.Day <> 30 Then
            Fecha = CDate("15/" & (Fecha.Month).ToString & "/" & Fecha.Year.ToString).AddMonths(1)
        End If
        Return Fecha
    End Function

    Private Sub frm_reporte_cooperativa_socio_hoja_datos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 Or Keys.F2 Or Keys.F3 Or Keys.F4 Or Keys.F5 Or Keys.F6 Or Keys.F7 Or Keys.F8 Or Keys.F9 Or Keys.F10 Or Keys.F11 Or Keys.F12 Or Keys.Escape Then
            FuncKeysModule(e.KeyValue)
            e.Handled = True
        End If
    End Sub

    Private Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action.
        Select Case value
            Case Keys.Escape
                'Add the code for the function key F3 here.
                Me.btnLimpiarCampos.PerformClick()
            Case Keys.F1
                'Add the code for the function key F1 here.
                'Me.btnCopiaPedido.PerformClick()
            Case Keys.F2
                'Add the code for the function key F2 here.
                'Me.btnAnular.PerformClick()
            Case Keys.F3
                'Add the code for the function key F5 here.
                'Me.btnBuscarCliente.PerformClick()
            Case Keys.F4
                'Add the code for the function key F6 here.
                'Me.btnProcesar.PerformClick()
            Case Keys.F5
                'Add the code for the function key F7 here.
                'Me.btnImprimir.PerformClick()
            Case Keys.F6
                'Add the code for the function key F9 here.
                'Me.btnBuscarProducto.PerformClick()
            Case Keys.F7
                'Add the code for the function key F10 here.
                'btnEliminarProducto.PerformClick()
                'crvFact.ReportSource = Nothing
                'crvFact.Visible = False
                'crvFact.Dock = DockStyle.None
            Case Keys.F8
                'algo pasaría si hubiera codigo aqui :)
        End Select
    End Sub
End Class