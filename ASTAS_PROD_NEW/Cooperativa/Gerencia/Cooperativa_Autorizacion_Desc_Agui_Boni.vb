Imports System.Data.SqlClient

Public Class Cooperativa_Autorizacion_Desc_Agui_Boni
    Dim jClass As New jarsClass
    Dim TSql As String
    Dim Table As DataTable

    Private Sub Cooperativa_Autorizacion_Desc_Agui_Boni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Private Sub Cooperativa_Autorizacion_Desc_Agui_Boni_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub BtnBuscarSocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSocio.Click
        ParamcodigoAs = Nothing
        ParamcodigoBux = Nothing
        Dim FrmBuscarSocio As New FrmBuscarSocios
        FrmBuscarSocio.ShowDialog()
        If ParamcodigoBux <> Nothing Then
            Me.TxtCodigoBuxis.Text = ParamcodigoBux
            BuscaSocio(Me.TxtCodigoBuxis.Text)
        End If
    End Sub

    Private Sub TxtCodigoBuxis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoBuxis.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCodigoBuxis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigoBuxis.LostFocus
        If Me.TxtCodigoBuxis.Text.Length > 0 Then
            BuscaSocio(Me.TxtCodigoBuxis.Text)
        End If
    End Sub

    Private Sub BuscaSocio(ByVal Codigo As Integer)
        Dim tblNombre As DataTable
        tblNombre = jClass.obtenerDatos(New SqlCommand("SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Codigo))
        If tblNombre.Rows.Count > 0 Then
            Me.lblNombre.Text = tblNombre.Rows(0)(0).ToString()
            Me.txtValAgui.Text = Format(jClass.obtenerEscalar("SELECT ISNULL(SUM(INTERES_DEUDA), 0.00) FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Codigo & " AND CUENTA_CONTABLE = 'A'"), "0.00")
            Me.txtValBoni.Text = Format(jClass.obtenerEscalar("SELECT ISNULL(SUM(INTERES_DEUDA), 0.00) FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Codigo & " AND CUENTA_CONTABLE = 'B'"), "0.00")
        Else
            MsgBox("Código no encontrado", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.lblNombre.Text = ""
        Me.TxtCodigoBuxis.Text = ""
        Me.txtValAgui.Text = "0.00"
        Me.txtValBoni.Text = "0.00"
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Val(Me.txtValAgui.Text) > 0 Then
            TSql = "DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.TxtCodigoBuxis.Text & " AND CUENTA_CONTABLE = 'A'"
            TSql &= ""
            TSql &= "INSERT INTO [dbo].[CATALOGO_DEDUCCIONES]" & vbCrLf
            TSql &= "           ([COMPAÑIA]" & vbCrLf
            TSql &= "           ,[CODIGO_DEDUCCION]" & vbCrLf
            TSql &= "           ,[CONCEPTO]" & vbCrLf
            TSql &= "           ,[CUENTA_CONTABLE]" & vbCrLf
            TSql &= "           ,[INTERES_DEUDA]" & vbCrLf
            TSql &= "           ,[USUARIO_CREACION]" & vbCrLf
            TSql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
            TSql &= "           ,[USUARIO_EDICION]" & vbCrLf
            TSql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
            TSql &= "     VALUES" & vbCrLf
            TSql &= "           (" & Compañia & vbCrLf
            TSql &= "           ," & Me.TxtCodigoBuxis.Text & vbCrLf
            TSql &= "           ,'CONCEPTO'" & vbCrLf
            TSql &= "           ,'A'" & vbCrLf
            TSql &= "           ," & Me.txtValAgui.Text & vbCrLf
            TSql &= "           ,'" & Usuario & "'" & vbCrLf
            TSql &= "           ,GETDATE()" & vbCrLf
            TSql &= "           ,'" & Usuario & "'" & vbCrLf
            TSql &= "           ,GETDATE())" & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(TSql))
        Else
            TSql = "DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.TxtCodigoBuxis.Text & " AND CUENTA_CONTABLE = 'A'"
            jClass.ejecutarComandoSql(New SqlCommand(TSql))
        End If
        If Val(Me.txtValBoni.Text) > 0 Then
            TSql = "DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.TxtCodigoBuxis.Text & " AND CUENTA_CONTABLE = 'B'"
            TSql &= ""
            TSql &= "INSERT INTO [dbo].[CATALOGO_DEDUCCIONES]" & vbCrLf
            TSql &= "           ([COMPAÑIA]" & vbCrLf
            TSql &= "           ,[CODIGO_DEDUCCION]" & vbCrLf
            TSql &= "           ,[CONCEPTO]" & vbCrLf
            TSql &= "           ,[CUENTA_CONTABLE]" & vbCrLf
            TSql &= "           ,[INTERES_DEUDA]" & vbCrLf
            TSql &= "           ,[USUARIO_CREACION]" & vbCrLf
            TSql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
            TSql &= "           ,[USUARIO_EDICION]" & vbCrLf
            TSql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
            TSql &= "     VALUES" & vbCrLf
            TSql &= "           (" & Compañia & vbCrLf
            TSql &= "           ," & Me.TxtCodigoBuxis.Text & vbCrLf
            TSql &= "           ,'CONCEPTO'" & vbCrLf
            TSql &= "           ,'B'" & vbCrLf
            TSql &= "           ," & Me.txtValBoni.Text & vbCrLf
            TSql &= "           ,'" & Usuario & "'" & vbCrLf
            TSql &= "           ,GETDATE()" & vbCrLf
            TSql &= "           ,'" & Usuario & "'" & vbCrLf
            TSql &= "           ,GETDATE())" & vbCrLf
            jClass.ejecutarComandoSql(New SqlCommand(TSql))
        Else
            TSql = "DELETE FROM [dbo].[CATALOGO_DEDUCCIONES] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_DEDUCCION = " & Me.TxtCodigoBuxis.Text & " AND CUENTA_CONTABLE = 'B'"
            jClass.ejecutarComandoSql(New SqlCommand(TSql))
        End If
        MsgBox("PROCESO FINALIZADO", MsgBoxStyle.Information, Me.Text)
    End Sub
End Class