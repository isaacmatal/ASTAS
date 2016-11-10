Imports System.Data.SqlClient

Public Class Contabilidad_Cierre_Libros_Compras_Ventas
    Dim jClass As New jarsClass
    Dim Table As DataTable
    Dim Sql As String
    Dim Iniciando As Boolean = True

    Private Sub Contabilidad_Cierre_Libros_Compras_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        llenarMeses()
        Me.cmbMeses.SelectedValue = Now.AddMonths(-1).Month
        Me.nudYear.Value = Now.AddMonths(-1).Year
    End Sub

    Private Sub llenarMeses()
        Table = jClass.obtenerDatos(New SqlCommand("SELECT MES, UPPER(DESCRIPCION_MES) AS DESCRIPCION_MES FROM CONTABILIDAD_CATALOGO_MESES"))
        Me.cmbMeses.DataSource = Table
        Me.cmbMeses.ValueMember = "MES"
        Me.cmbMeses.DisplayMember = "DESCRIPCION_MES"
    End Sub

    Private Sub Contabilidad_Cierre_Libros_Compras_Ventas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If Me.rbCompras.Checked Then
            If MsgBox("El Período Contable del Libro de Compras correspondiente a " & Me.cmbMeses.Text & "/" & Me.nudYear.Value.ToString() & " se " & IIf(Me.rbCerrar.Checked, "CERRARÁ", "REVERTIRÁ CIERRE") & "." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "Confirme Acción") = MsgBoxResult.Yes Then
                If jClass.ejecutarComandoSql(New SqlCommand("UPDATE CONTABILIDAD_LIBRO_COMPRAS_INGRESO_MANUAL SET PERIODO_CERRADO = " & IIf(Me.rbCerrar.Checked, "1", "0") & " WHERE COMPAÑIA = " & Compañia & " AND MONTH(PERIODO_LIBRO) = " & Me.cmbMeses.SelectedValue.ToString() & " AND YEAR(PERIODO_LIBRO) = " & Me.nudYear.Value.ToString())) > 0 Then
                    MsgBox("Período " & Me.cmbMeses.Text & "/" & Me.nudYear.Value.ToString() & IIf(Me.rbCerrar.Checked, " Cerrado.", " Abierto."), MsgBoxStyle.Information, "Resultado")
                End If
            End If
        End If
        If Me.rbVentas.Checked Then
            If MsgBox("El Período Contable del Libro de Ventas correspondiente a " & Me.cmbMeses.Text & "/" & Me.nudYear.Value.ToString() & " se " & IIf(Me.rbCerrar.Checked, "CERRARÁ", "REVERTIRÁ CIERRE") & "." & vbCrLf & vbCrLf & "¿Desea continuar?", MsgBoxStyle.YesNo, "Confirme Acción") = MsgBoxResult.Yes Then
                If jClass.ejecutarComandoSql(New SqlCommand("UPDATE FACTURACION_MANUAL_LIBRO_VENTAS SET PERIODO_CERRADO = " & IIf(Me.rbCerrar.Checked, "1", "0") & " WHERE COMPAÑIA = " & Compañia & " AND MONTH(FECHA_FACTURA) = " & Me.cmbMeses.SelectedValue.ToString() & " AND YEAR(FECHA_FACTURA) = " & Me.nudYear.Value.ToString())) > 0 Then
                    MsgBox("Período " & Me.cmbMeses.Text & "/" & Me.nudYear.Value.ToString() & IIf(Me.rbCerrar.Checked, " Cerrado.", " Abierto."), MsgBoxStyle.Information, "Resultado")
                End If
            End If
        End If
    End Sub
End Class