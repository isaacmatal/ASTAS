Imports System.Data
Imports System.Data.SqlClient

Public Class Cooperativa_Facturacion_Socios_Facturas
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim T_cobro As String = 1
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim Permitir As String
    Dim jClass As New jarsClass

    Private Sub Cooperativa_Facturacion_Socios_Facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtnombre.Text = ""
        Iniciando = False
        'Carga_TipoSolicitudes()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Public Sub CargaReporte()
        Dim Rpt As Object
        If Me.RadioButton1.Checked Then
            Rpt = New Cooperativa_Reporte_Socio_Facturas_General
        Else
            Rpt = New Cooperativa_Reporte_Socio_Facturas
        End If
        Try
            DS01.Reset()
            If Me.chkDespensa.Checked And Me.chkAlmacen.Checked Then
                If Me.RadioButton2.Checked = True Then
                    Sql = "EXECUTE sp_COOPERATIVA_REPORTE_FACTURAS_SOCIO @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=1, @CODIGO_EMPLEADO='" & IIf(TextBox1.Text = "", 0, TextBox1.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(TextBox2.Text = "", 0, TextBox2.Text) & "'"
                ElseIf Me.RadioButton1.Checked = True Then
                    Sql = "EXECUTE sp_COOPERATIVA_REPORTE_FACTURAS_SOCIO @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=2, @CODIGO_EMPLEADO='" & IIf(TextBox1.Text = "", 0, TextBox1.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(TextBox2.Text = "", 0, TextBox2.Text) & "'"
                End If
            Else
                If Me.RadioButton2.Checked = True Then
                    Sql = "EXECUTE sp_COOPERATIVA_REPORTE_FACTURAS_SOCIO @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=3, @CODIGO_EMPLEADO='" & IIf(TextBox1.Text = "", 0, TextBox1.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(TextBox2.Text = "", 0, TextBox2.Text) & "', @DEDUCCION=" & IIf(Me.chkAlmacen.Checked, 14, 15)
                ElseIf Me.RadioButton1.Checked = True Then
                    Sql = "EXECUTE sp_COOPERATIVA_REPORTE_FACTURAS_SOCIO @COMPAÑIA=" & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=4, @CODIGO_EMPLEADO='" & IIf(TextBox1.Text = "", 0, TextBox1.Text) & "', @CODIGO_EMPLEADO_AS='" & IIf(TextBox2.Text = "", 0, TextBox2.Text) & "', @DEDUCCION=" & IIf(Me.chkAlmacen.Checked, 14, 15)
                End If
            End If

            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))

            Me.crvReporte.ReportSource = Rpt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            If (TextBox1.Text = "") And (TextBox2.Text = "") And (RadioButton2.Checked = True) Then
                MsgBox("Debe ingresar el codigo del empleado")
            Else
                If Not Me.chkDespensa.Checked And Not Me.chkAlmacen.Checked Then
                    MsgBox("Debe seleccionar al menos una deducción.")
                Else
                    CargaReporte()
                End If
            End If
        End If
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = Me.TextBox2.Text '""
        ParamcodigoBux = Val(Me.TextBox1.Text) '0
        StadoBusqueda = 2

        Dim Prin As New Busquedas_empleados_avicola
        Prin.Compañia_Value = Compañia
        Prin.CbxCompania.Enabled = False
        AppPath = System.IO.Directory.GetCurrentDirectory
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Me.TextBox1.Text = ParamcodigoBux
            Me.TextBox2.Text = ParamcodigoAs
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If Me.TextBox1.Text <> Nothing Or Me.TextBox2.Text <> Nothing Then
            If Me.TextBox1.Text <> Nothing Then
                Me.TextBox2.Text = Me.TextBox1.Text.PadLeft(6, "0")
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.TextBox1.Text & " AND COMPAÑIA = " & Compañia
            Else
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.TextBox2.Text & "' AND COMPAÑIA = " & Compañia
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
                    Me.TextBox2.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.TextBox1.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtnombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtorigen.Text = Table.Rows(0).Item("DESCRIPCION_ORIGEN")
                    Me.txtdivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                    Me.txtdepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                    Me.txtseccion.Text = Table.Rows(0).Item("DESCRIPCION_SECCION")

                Else
                    Me.TextBox1.Clear()
                    Me.TextBox2.Clear()
                    MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
            End Try
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.BtnBuscar.Focus()
        End If
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If Me.TextBox1.Text <> Nothing Or Me.TextBox2.Text <> Nothing Then
            If Me.TextBox1.Text <> Nothing Then
                Me.TextBox2.Text = Me.TextBox1.Text.PadLeft(6, "0")
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & Me.TextBox1.Text & " AND COMPAÑIA = " & Compañia
            Else
                Sql = "SELECT NOMBRE_COMPLETO, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, ESTATUS, DESCRIPCION_ESTATUS, ORIGEN, DESCRIPCION_ORIGEN, DESCRIPCION_DIVISION, DESCRIPCION_DEPARTAMENTO, DESCRIPCION_SECCION FROM VISTA_COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO_AS = '" & Me.TextBox2.Text & "' AND COMPAÑIA = " & Compañia
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
                    Me.TextBox2.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.TextBox1.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtnombre.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    Me.txtorigen.Text = Table.Rows(0).Item("DESCRIPCION_ORIGEN")
                    Me.txtdivision.Text = Table.Rows(0).Item("DESCRIPCION_DIVISION")
                    Me.txtdepartamento.Text = Table.Rows(0).Item("DESCRIPCION_DEPARTAMENTO")
                    Me.txtseccion.Text = Table.Rows(0).Item("DESCRIPCION_SECCION")
                Else
                    Me.TextBox1.Clear()
                    Me.TextBox2.Clear()
                    MsgBox("No se encontró código digitado.", MsgBoxStyle.Information, "Código no encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡Error en Busqueda Socio!!")
            End Try
        End If
    End Sub
End Class