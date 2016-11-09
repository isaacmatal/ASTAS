Imports System.Data
Imports System.Data.SqlClient

Public Class Cooperativa_Acceso_web

    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand

    Private Sub Cooperativa_Acceso_web_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub

    Sub BusquedaDatosSocios()
        Dim CodAS, Accion As String
        Dim CBuxi As Integer
        CodAS = ""
        Accion = ""
        If Trim(ParamcodigoAs) = Nothing And Val(ParamcodigoBux) <= 0 Then
            MessageBox.Show("Ingrese al menos un CODIGO" & Chr(13) & "CODIGO AS O CODIGO BUXI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtCodAS.Focus()
            Exit Sub
        ElseIf Trim(ParamcodigoAs) <> Nothing Or Val(ParamcodigoBux) > 0 Then
            CodAS = ParamcodigoAs.Trim()
            CBuxi = Val(ParamcodigoBux)
            If CodAS <> Nothing And CBuxi <= 0 Then
                Accion = "cas"
            ElseIf CodAS = Nothing And CBuxi > 0 Then
                Accion = "cbuxi"
            ElseIf CodAS <> Nothing And CBuxi > 0 Then
                Accion = "ambos"
            End If
        End If
        Try
            sql = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','" & CodAS & "','" & Accion & "'"
            sqlCmd.CommandText = sql
            Table = jClass.obtenerDatos(sqlCmd)
            If (Table.Rows.Count) <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Hay_Datos = False
                Return
            End If
            Hay_Datos = True
            Me.TxtCodAS.Text = Table.Rows(0).Item(2)
            Me.TxtCodBuxy.Text = Table.Rows(0).Item(3)
            Me.TxtSoNombre.Text = Table.Rows(0).Item(4)
            Me.TxtSoApellido.Text = Table.Rows(0).Item(5)
            Me.TxtDUI.Text = Table.Rows(0).Item(15)
            Me.TxtNit.Text = Table.Rows(0).Item(16)
            Me.TxtDivision.Text = Table.Rows(0).Item(6)
            Me.TxtDepto.Text = Table.Rows(0).Item(7)
            Me.TxtSeccion.Text = Table.Rows(0).Item(8)
            Me.TxtCargo.Text = Table.Rows(0).Item(9)
            Me.Txt_so_direccion.Text = Table.Rows(0).Item(17)
            Me.Txt_so_telefono.Text = Table.Rows(0).Item(18)
            ParamcodigoAs = Me.TxtCodAS.Text
            ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = Me.TxtCodAS.Text
        ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
        StadoBusqueda = 2
        If Trim(Me.TxtCodAS.Text) <> "" Or Trim(Me.TxtCodBuxy.Text) <> "" Then
            BusquedaDatosSocios()
        Else
            Dim Prin As New Busquedas_empleados_avicola
            Prin.Compañia_Value = Compañia
            Prin.CbxCompania.Enabled = False
            Prin.ShowDialog()
            If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
                Me.TxtCodBuxy.Text = ParamcodigoBux
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios()
            End If
        End If
    End Sub

    Private Sub Txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress, TxtCodAS.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodAS.Text <> Nothing Then
                Me.TxtCodAS.Text = Me.TxtCodAS.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodAS.Text
                ParamcodigoBux = 0
                Btn_Socio_limpiar.PerformClick()
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios()
            End If
        End If
    End Sub

    Private Sub Btn_Socio_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click
        For Each control As Control In Me.GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.ResetText()
            End If
        Next
    End Sub

    Private Sub Btn_so_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_agregar.Click
        Dim cadena As String = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim fechahora As String = Now.ToString("ddMMHHmmss")
        Dim resultado As Integer
        Dim Clave As String
        Dim Pos1 As Integer = CInt(Mid(fechahora, 1, 2))
        Dim Pos2 As Integer = CInt(Mid(fechahora, 3, 2))
        Dim Pos3 As Integer = CInt(Mid(fechahora, 5, 2))
        If Pos3 = 0 Then
            Pos3 = 3
        End If
        Dim Pos4 As Integer = CInt(Mid(fechahora, 7, 2))
        If Pos4 = 0 Then
            Pos4 = 4
        End If
        Dim Pos5 As Integer = CInt(Mid(fechahora, 9, 2))
        If Pos5 = 0 Then
            Pos5 = 5
        End If
        Clave = Mid(cadena, Pos1, 1) & Mid(cadena, Pos2, 1) & Mid(cadena, Pos3, 1) & Mid(cadena, Pos4, 1) & Mid(cadena, Pos5, 1)
        sqlCmd.CommandText = "EXECUTE [dbo].[sp_USUARIO_SOCIO_ACTUALIZAR_CONTRASENA_WEB1] @Codigo_empleado_as = '" & Me.TxtCodAS.Text & "', @Clave_consulta = '" & Clave & "'"
        resultado = jClass.ejecutarComandoSql(sqlCmd)
        If resultado > 0 Then
            Me.TextBox1.Text = Clave
            MsgBox("Contraseña actualizada exitosamente.", MsgBoxStyle.Information, "Error")
        Else
            MsgBox("No se pudo Actualizar la contraseña..." & vbCrLf & "verifique.", MsgBoxStyle.Information, "Error")
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim rpt As New Cooperativa_Accesso_web_rpt
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        sqlCmd.CommandText = "SELECT CODIGO_EMPLEADO_AS, NOMBRE_COMPLETO, '" & Me.TextBox1.Text & "' AS CLAVE FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "' AND COMPAÑIA = " & Compañia
        Table = jClass.obtenerDatos(sqlCmd)
        rpt.SetDataSource(Table)
        TextObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        TextObj.Text = Descripcion_Compañia
        Dim frm As New frmReportes_Ver
        frm.ReportesGenericos(rpt)
        frm.ShowDialog()
    End Sub
End Class