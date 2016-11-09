Imports System.Data
Imports System.Data.SqlClient

Public Class Cafeteria_Consumo_Detallado
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim T_cobro As String = 1

    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub Cafeteria_Consumo_Detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        RadioButton2.Checked = True
        Me.CheckBox1.Checked = True
        Me.txtnombre.Text = ""

        Iniciando = False

        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub
    Public Sub CargaReporte()
        Dim Rpt As Object
        If Me.CheckBox1.Checked Then
            Rpt = New Cafeteria_Reporte_Consumo_General
        Else
            Rpt = New Cafeteria_Reporte_Consumo_Detallado

        End If


        Try
            DS01.Reset()
            If Me.RadioButton2.Checked = True And CheckBox1.Checked = True Then
                Sql = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & "', @BANDERA=13, @TIPO_COBRO=" & T_cobro & ",@CODIGO_EMPLEADO='" & IIf(txtCodBuxis.Text = "", 0, txtCodBuxis.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(txtcodAS.Text = "", 0, txtcodAS.Text) & "'"

            ElseIf Me.RadioButton2.Checked = True And Me.CheckBox2.Checked = True Then
                Sql = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & "', @BANDERA=6, @TIPO_COBRO=" & T_cobro & ",@CODIGO_EMPLEADO='" & IIf(txtCodBuxis.Text = "", 0, txtCodBuxis.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(txtcodAS.Text = "", 0, txtcodAS.Text) & "'"

            ElseIf Me.RadioButton1.Checked = True And Me.CheckBox1.Checked = True Then

                Sql = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & "', @BANDERA=14, @TIPO_COBRO=" & T_cobro & ",@CODIGO_EMPLEADO='" & IIf(txtCodBuxis.Text = "", 0, txtCodBuxis.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(txtcodAS.Text = "", 0, txtcodAS.Text) & "'"

            ElseIf Me.RadioButton1.Checked = True And Me.CheckBox2.Checked = True Then
                Sql = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd/MM/yyyy") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd/MM/yyyy") & "', @BANDERA=9, @TIPO_COBRO=" & T_cobro & ",@CODIGO_EMPLEADO='" & IIf(txtCodBuxis.Text = "", 0, txtCodBuxis.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(txtcodAS.Text = "", 0, txtcodAS.Text) & "'"

            End If

            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))

            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            If (txtCodBuxis.Text = "") And (txtcodAS.Text = "") And (RadioButton2.Checked = True) Then
                MsgBox("Debe ingresar el codigo del empleado")
            Else
                CargaReporte()
            End If
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.RadioButton2.Checked = False
            T_cobro = 1
            Btn_so_buscar.Enabled = False
            txtcodAS.Enabled = False
            txtCodBuxis.Enabled = False
        Else
            Me.RadioButton2.Checked = True
            T_cobro = 2
            Btn_so_buscar.Enabled = True
            txtcodAS.Enabled = True
            txtCodBuxis.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            Me.RadioButton1.Checked = False
            T_cobro = 2
            Btn_so_buscar.Enabled = True
            txtcodAS.Enabled = True
            txtCodBuxis.Enabled = True
        Else
            Me.RadioButton1.Checked = True
            T_cobro = 1
            Btn_so_buscar.Enabled = False
            txtcodAS.Enabled = False
            txtCodBuxis.Enabled = False
        End If
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = Me.txtcodAS.Text '""
        ParamcodigoBux = Val(Me.txtCodBuxis.Text) '0
        StadoBusqueda = 2

        Dim Prin As New Busquedas_empleados_avicola
        Prin.Compañia_Value = Compañia
        Prin.CbxCompania.Enabled = False
        AppPath = System.IO.Directory.GetCurrentDirectory
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Me.txtCodBuxis.Text = ParamcodigoBux
            Me.txtcodAS.Text = ParamcodigoAs
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBuxis.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.BtnBuscar.Focus()
        End If
    End Sub

    Private Sub Cafeteria_Consumo_Detallado_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub txtCodBuxis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodBuxis.LostFocus
        If Me.txtCodBuxis.Text <> Nothing Or Me.txtcodAS.Text <> Nothing Then
            If Me.txtCodBuxis.Text <> Nothing Then

                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & " AND COMPAÑIA = " & Compañia
            Else
                Me.txtcodAS.Text = Me.txtCodBuxis.Text.PadLeft(6, "0")
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.txtcodAS.Text & "' AND COMPAÑIA = " & Compañia
            End If
            sqlCmd.CommandText = Sql
            Try
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Origen = CInt(Table.Rows(0).Item("ORIGEN"))
                    If Not Permitir.Contains(Origen.ToString()) Then
                        MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, Table.Rows(0).Item("CODIGO_EMPLEADO") & " - " & Table.Rows(0).Item("CODIGO_EMPLEADO_AS"))
                        Return
                    End If
                    Me.txtcodAS.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.txtCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtnombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtorigen.Text = Table.Rows(0).Item("DESCRIPCION_ORIGEN")
                    Me.txtdivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                    Me.txtdepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                    Me.txtseccion.Text = Table.Rows(0).Item("DESCRIPCION_SECCION")

                Else
                    Me.txtCodBuxis.Clear()
                    Me.txtcodAS.Clear()
                    MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
            End Try
        End If
    End Sub

    Private Sub txtcodAS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.BtnBuscar.Focus()
        End If
    End Sub

    Private Sub txtcodAS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodAS.LostFocus
        If Me.txtCodBuxis.Text <> Nothing Or Me.txtcodAS.Text <> Nothing Then
            If Me.txtCodBuxis.Text <> Nothing Then
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & " AND COMPAÑIA = " & Compañia
            Else
                Me.txtcodAS.Text = Me.txtcodAS.Text.PadLeft(6, "0")
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.txtcodAS.Text & "' AND COMPAÑIA = " & Compañia
            End If
            sqlCmd.CommandText = Sql
            Try
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 0 Then
                    Origen = CInt(Table.Rows(0).Item("ORIGEN"))
                    If Not Permitir.Contains(Origen.ToString()) Then
                        MsgBox("No esta autorizado a revisar este código", MsgBoxStyle.Information, Table.Rows(0).Item("CODIGO_EMPLEADO") & " - " & Table.Rows(0).Item("CODIGO_EMPLEADO_AS"))
                        Return
                    End If
                    Me.txtcodAS.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.txtCodBuxis.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtnombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtorigen.Text = Table.Rows(0).Item("DESCRIPCION_ORIGEN")
                    Me.txtdivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                    Me.txtdepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                    Me.txtseccion.Text = Table.Rows(0).Item("DESCRIPCION_SECCION")
                Else
                    Me.txtCodBuxis.Clear()
                    Me.txtcodAS.Clear()
                    MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
            End Try
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodAS.TextChanged

    End Sub

  

   
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.CheckBox2.Checked = False
        Else
            Me.CheckBox2.Checked = True

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Me.CheckBox1.Checked = False
        Else
            Me.CheckBox1.Checked = True

        End If
    End Sub
End Class