Imports System.Data
Imports System.Data.SqlClient
Public Class socio_division_departamento
    Dim Sql As String
    Dim Bandera As String
    Dim sqlCmd As SqlCommand
    Dim Proc As New jarsClass
    Dim Iniciando As Boolean = True
    Private Sub socio_division_departamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.PbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Sql = "SELECT DIVISION,DESCRIPCION_DIVISION FROM COOPERATIVA_CATALOGO_DIVISIONES WHERE COMPAÑIA=" & Compañia
        Proc.CargarCombo(CmbDivision, Sql, "DIVISION", "DESCRIPCION_DIVISION")
        Iniciando = False
    End Sub
    Private Sub LlenarTabla(ByVal Division As Integer)
        Me.DGV_Datos.DataSource = Proc.ejecutaSQLl_llenaDTABLE("EXECUTE dbo.sp_COOPERATIVA_CATALOGO_DIVISIONES_DEPARTAMENTO_SIUD " & Compañia & ", " & Division & ", " & 0 & " , 'X', '" & Usuario & "', 'S'")
        Me.DGV_Datos.Columns.Item(0).Visible = False
        Me.DGV_Datos.Columns.Item(1).Visible = False
        Me.DGV_Datos.Columns.Item(2).Width = 40 'Codigo
        Me.DGV_Datos.Columns.Item(3).Width = 330 'Descripción
    End Sub
    Private Sub CmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDivision.SelectedIndexChanged
        If Iniciando = False Then
            LlenarTabla(CmbDivision.SelectedValue)
            Limpiar()
        End If
    End Sub
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub
    Private Sub Limpiar()
        Me.TxtCodigo.Clear()
        Me.TxtDivision.Clear()
        Me.TxtDivision.Focus()
    End Sub
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.TxtDivision.Text.Trim > "" Then
            If MsgBox("Esta correcto y actualizar la base de datos", MsgBoxStyle.YesNo, "Adicionar/Modficar") = MsgBoxResult.Yes Then
                Bandera = IIf(Me.TxtCodigo.Text.Trim = "", "I", "U")
                sqlCmd = New SqlCommand("EXECUTE dbo.sp_COOPERATIVA_CATALOGO_DIVISIONES_DEPARTAMENTO_SIUD " & Compañia & ", " & Me.CmbDivision.SelectedValue & ", " & Val(Me.TxtCodigo.Text) & ", '" & Me.TxtDivision.Text & "', '" & Usuario & "', '" & Bandera & "'")
                Dim Resulta As Integer = Proc.ejecutarComandoSql(sqlCmd)
                If Resulta > 0 Then
                    MsgBox("Actualización Realizada Correctamente.", MsgBoxStyle.Exclamation)
                End If
                LlenarTabla(Me.CmbDivision.SelectedValue)
            End If
        Else
            MsgBox("No está definido la Descripción.", MsgBoxStyle.Exclamation)
            Me.TxtDivision.Focus()
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If MsgBox("Esta correcto y desea eliminar registro de la base de datos", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            sqlCmd = New SqlCommand("EXECUTE dbo.sp_COOPERATIVA_CATALOGO_DIVISIONES_DEPARTAMENTO_SIUD " & Compañia & ", " & Me.CmbDivision.SelectedValue & ", " & Val(Me.TxtCodigo.Text) & ", '" & Me.TxtDivision.Text & "', '" & Usuario & "', 'D'")
            Dim Resulta As Integer = Proc.ejecutarComandoSql(sqlCmd)
            If Resulta > 0 Then
                MsgBox("Eliminación Realizada Correctamente.", MsgBoxStyle.Exclamation)
            End If
            LlenarTabla(Me.CmbDivision.SelectedValue)
        End If
    End Sub

    Private Sub DGV_Datos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Datos.CellEnter
        Try
            Me.TxtCodigo.Text = Me.DGV_Datos.Rows(e.RowIndex).Cells(2).Value()
            Me.TxtDivision.Text = Me.DGV_Datos.Rows(e.RowIndex).Cells(3).Value()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub socio_division_departamento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class