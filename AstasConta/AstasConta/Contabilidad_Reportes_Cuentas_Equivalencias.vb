Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Cuentas_Equivalencias
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass
    Dim Sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Libro As Integer

    Private Sub Contabilidad_Reportes_Cuentas_Equivalencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.WindowState = FormWindowState.Maximized
        CargaLibrosContables(Compañia)
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Rpt As New Contabilidad_Equivalencia_Cuentas
        Try
            Sql = "SELECT C.COMPAÑIA,C.CUENTA AS COD_CUENTA, " & vbCrLf
            Sql &= "       C.CUENTA_COMPLETA AS CUENTA," & vbCrLf
            Sql &= "       C.DESCRIPCION_CUENTA AS DESCRIPCION," & vbCrLf
            Sql &= "       (SELECT [DESCRIPCION_LIBRO_CONTABLE] FROM [dbo].[CONTABILIDAD_CATALOGO_LIBRO_CONTABLE] WHERE [COMPAÑIA] = C.COMPAÑIA AND [LIBRO_CONTABLE] = C.LIBRO_CONTABLE) AS LIBRO_CONTABLE," & vbCrLf
            Sql &= "	   (SELECT [DESCRIPCION_LIBRO_CONTABLE] FROM [dbo].[CONTABILIDAD_CATALOGO_LIBRO_CONTABLE] WHERE [COMPAÑIA] = E.COMPAÑIA AND [LIBRO_CONTABLE] = E.LIBRO_EQUIVALENTE) AS LIBRO_EQUIVALENTE," & vbCrLf
            Sql &= "       EQ.CUENTA_COMPLETA AS [CUENTA EQUIVALENTE], " & vbCrLf
            Sql &= "	   EQ.DESCRIPCION_CUENTA AS [DESCRIPCION EQUIVALENTE]," & vbCrLf
            Sql &= "	   '" & Descripcion_Compañia & "' AS EMPRESA" & vbCrLf
            Sql &= "  FROM CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
            Sql &= "       LEFT JOIN (SELECT COMPAÑIA, LIBRO_CONTABLE, CUENTA, LIBRO_EQUIVALENTE, COMPAÑIA_EQUIVALENTE, CUENTA_EQUIVALENTE FROM CONTABILIDAD_CATALOGO_CUENTAS_EQUIVALENCIAS " & vbCrLf
            Sql &= "                   WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Libro & " AND LIBRO_EQUIVALENTE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & ") E " & vbCrLf
            Sql &= "                         ON C.COMPAÑIA = E.COMPAÑIA AND C.LIBRO_CONTABLE = E.LIBRO_CONTABLE AND C.CUENTA = E.CUENTA" & vbCrLf
            Sql &= "	   LEFT JOIN CONTABILIDAD_CATALOGO_CUENTAS EQ ON E.COMPAÑIA_EQUIVALENTE = EQ.COMPAÑIA AND E.LIBRO_EQUIVALENTE = EQ.LIBRO_CONTABLE AND E.CUENTA_EQUIVALENTE = EQ.CUENTA" & vbCrLf
            Sql &= "       WHERE C.LIBRO_CONTABLE = " & Libro & vbCrLf
            Sql &= "   AND C.COMPAÑIA = " & Compañia & vbCrLf
            Sql &= " ORDER BY C.CUENTA_COMPLETA "
            sqlCmd.CommandText = Sql
            Table = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Rpt.SetDataSource(Table)
                crvReporte.ReportSource = Rpt
            Else
                Hay_Datos = False
                crvReporte.ReportSource = Nothing
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim TableLibro As DataTable
        Try
            Sql = "SELECT LIBRO_CONTABLE, DESCRIPCION_LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"
            TableLibro = jClass.obtenerDatos(New SqlCommand(Sql))
            If TableLibro.Rows.Count > 0 Then
                Libro = CInt(TableLibro.Rows(0).Item(0))
                Me.txtCompañia.Text = TableLibro.Rows(0).Item(1).ToString()
            End If
            Sql = "SELECT LIBRO_CONTABLE, DESCRIPCION_LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 0"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "LIBRO_CONTABLE"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "DESCRIPCION_LIBRO_CONTABLE"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Contabilidad_Reportes_Cuentas_Equivalencias_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class