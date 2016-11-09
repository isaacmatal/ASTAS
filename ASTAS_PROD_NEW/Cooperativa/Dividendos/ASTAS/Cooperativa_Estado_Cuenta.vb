Imports System.Data.SqlClient
Imports iTextSharp.text 'Para trabajar con los pdf
Imports iTextSharp.text.pdf
Imports System.IO 'Para trabajar con archivos

Public Class Cooperativa_Estado_Cuenta
    Dim jClass As New jarsClass
    Dim Table As New DataTable
    Dim sqlCmd As New SqlCommand
    Dim sql As String
    'TABLA TEMPORAL PARA LA BUSQUEDAS DINAMICAS
    Dim Table1 As New DataTable
    Dim Iniciando As Boolean
    Dim ban2 As Integer = 0
    Dim division_ As Integer
    Dim departamento_ As Integer
    Dim seccion_ As Integer
    Dim divisiones_ As String

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.Label2.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.Label2.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetVal(ByVal valor As Integer)
    Sub SetVal(ByVal valor As Integer)
        If Me.pB2.InvokeRequired Then
            Dim setea As New CallBackSetVal(AddressOf SetVal)
            Me.Invoke(setea, valor)
        Else
            Me.pB2.Maximum = valor
        End If
    End Sub

#Region "Eventos"
    Private Sub Cooperativa_Estado_Cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        jClass.CargarCombo(Me.cmbDivisiones, "select DIVISION, DESCRIPCION_DIVISION from COOPERATIVA_CATALOGO_DIVISIONES order by DESCRIPCION_DIVISION asc", "DIVISION", "DESCRIPCION_DIVISION")
        jClass.CargarCombo(Me.cmbDepartamentos, "SELECT DEPARTAMENTO,DESCRIPCION_DEPARTAMENTO FROM COOPERATIVA_CATALOGO_DEPARTAMENTOS where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " ORDER BY DESCRIPCION_DEPARTAMENTO ASC", "DEPARTAMENTO", "DESCRIPCION_DEPARTAMENTO")
        jClass.CargarCombo(Me.cmbSecciones, "SELECT SECCION,DESCRIPCION_SECCION FROM COOPERATIVA_CATALOGO_SECCIONES where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and departamento=" & cmbDepartamentos.SelectedValue.ToString() & " ORDER BY DESCRIPCION_SECCION ASC", "SECCION", "DESCRIPCION_SECCION")
        jClass.CargarCombo(Me.cmbCargos, "SELECT CARGO,DESCRIPCION_CARGO FROM COOPERATIVA_CATALOGO_CARGOS where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND SECCION=" & cmbSecciones.SelectedValue.ToString() & " ORDER BY DESCRIPCION_CARGO ASC", "CARGO", "DESCRIPCION_CARGO")
        'jClass.CargarCombo(Me.cmbGerencias, "SELECT distinct Gerencia FROM PLANILLA_CATALOGO_EMPLEADOS ORDER BY Gerencia ASC", "Gerencia", "Gerencia")
        cmbGeneral.Checked = True
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = True
        Iniciando = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Rpt As New Cooperativa_Estado_Cuentas
        If txtCodigoEmpleado.Text <> "" Then
            Try
                sql = "EXEC sp_COOPERATIVA_ESTADO_CUENTA "
                sql &= "@CODIGO_EMPLEADO = " & txtCodigoEmpleado.Text
                sql &= ", @FECHA1 = '" & DateTimePicker1.Value.ToString() & "'"
                sql &= ", @FECHA2 = '" & DateTimePicker2.Value.ToString() & "'"
                sql &= ", @BANDERA = 1"
                sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
                sql &= ", @ASOCIACION = 1"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.SetDataSource(Table)

                If cmbGeneral.Checked = True Then
                    sql = "EXECUTE sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS  @COMPAÑIA = 1,@CodigoBuxis=" & txtCodigoEmpleado.Text & ",@FECHA_HASTA ='" & Format(DateTimePicker3.Value, "dd-MM-yyyy hh:mm:ss") & "' "
                Else
                    sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] @COMPAÑIA = " & Compañia & ", @DEDUCCION = 0, @CodigoBuxis =" & txtCodigoEmpleado.Text & ", @FECHA_DESDE = '" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @FECHA_HASTA = '" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
                End If


                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.Subreports.Item(0).SetDataSource(Table)


                Me.CrystalReportViewer1.ReportSource = Rpt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "¡¡No se ha podido generar reporte!!")
            End Try
        Else
            MsgBox("INGRESE CODIGO DE EMPLEADO")
            txtCodigoEmpleado.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Rpt As New Cooperativa_Estado_Cuentas
        CargarSocios()
        If Table1.Rows.Count > 0 Then
            For i As Integer = 0 To Table1.Rows.Count - 1
                sql = "EXEC sp_COOPERATIVA_ESTADO_CUENTA "
                sql &= "@CODIGO_EMPLEADO = " & Table1.Rows(i).Item(0).ToString()
                sql &= ", @FECHA1 = '" & DateTimePicker1.Value.ToString() & "'"
                sql &= ", @FECHA2 = '" & DateTimePicker2.Value.ToString() & "'"
                sql &= ", @BANDERA = 1"
                sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
                sql &= ", @ASOCIACION = 1"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.SetDataSource(Table)

                If cmbGeneral.Checked = True Then
                    sql = "EXECUTE sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS  @COMPAÑIA = 1,@CodigoBuxis=" & Table1.Rows(i).Item(0).ToString() & ",@FECHA_HASTA ='" & Format(DateTimePicker3.Value, "dd-MM-yyyy hh:mm:ss") & "' "
                Else
                    sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] @COMPAÑIA = " & Compañia & ", @DEDUCCION = 0, @CodigoBuxis =" & Table1.Rows(i).Item(0).ToString() & ", @FECHA_DESDE = '" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @FECHA_HASTA = '" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
                End If

                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.Subreports.Item(0).SetDataSource(Table)
                Rpt.PrintToPrinter(1, True, 1, 1)
            Next
        Else
            MsgBox("No hay Datos!")
        End If
    End Sub

    Private Sub cmbDepartamentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamentos.SelectedIndexChanged
        If Iniciando = False Then
            jClass.CargarCombo(Me.cmbSecciones, "SELECT SECCION,DESCRIPCION_SECCION FROM COOPERATIVA_CATALOGO_SECCIONES where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and departamento=" & cmbDepartamentos.SelectedValue.ToString() & " ORDER BY DESCRIPCION_SECCION ASC", "SECCION", "DESCRIPCION_SECCION")
            If GroupBox7.Enabled = True Then
                If RadioButton2.Checked = True Then
                    CargarSocios()
                    cmbSecciones.SelectedIndex = 0
                End If
            Else
                Table1 = Nothing
                If cmbDepartamentos.SelectedValue <> Nothing Then
                    Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct s.CODIGO_EMPLEADO, s1.DEPARTAMENTO from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " order by CODIGO_EMPLEADO asc")
                    cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.departamento=" & Me.cmbDepartamentos.SelectedValue.ToString(), 0)
                Else
                    cantidadEmpleados.Text = 0
                End If
            End If
        End If
    End Sub

    Private Sub cmbDivisiones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivisiones.SelectedIndexChanged
        If Iniciando = False Then
            jClass.CargarCombo(Me.cmbDepartamentos, "SELECT DEPARTAMENTO,DESCRIPCION_DEPARTAMENTO FROM COOPERATIVA_CATALOGO_DEPARTAMENTOS where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " ORDER BY DESCRIPCION_DEPARTAMENTO ASC", "DEPARTAMENTO", "DESCRIPCION_DEPARTAMENTO")
            cmbDepartamentos.SelectedIndex = 0
            If GroupBox7.Enabled = True Then
                If Me.RadioButton1.Checked = True Then
                    CargarSocios()
                End If
            End If
        End If
    End Sub

    Private Sub cmbCargos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCargos.SelectedIndexChanged
        If Iniciando = False Then
            If GroupBox7.Enabled = True Then
                If RadioButton4.Checked = True Then
                    CargarSocios()
                End If
            End If
        End If
    End Sub

    Private Sub cmbSecciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSecciones.SelectedIndexChanged
        If Iniciando = False Then
            cmbCargos.DataSource = Nothing
            jClass.CargarCombo(Me.cmbCargos, "SELECT CARGO,DESCRIPCION_CARGO FROM COOPERATIVA_CATALOGO_CARGOS where division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND SECCION=" & cmbSecciones.SelectedValue.ToString() & " ORDER BY DESCRIPCION_CARGO ASC", "CARGO", "DESCRIPCION_CARGO")
            If GroupBox7.Enabled = True Then
                If RadioButton3.Checked = True Then
                    CargarSocios()
                End If
            Else
                Table1 = Nothing
                If cmbSecciones.SelectedValue <> Nothing Then
                    Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct s.CODIGO_EMPLEADO, s1.DEPARTAMENTO from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.seccion=" & cmbSecciones.SelectedValue.ToString() & " order by CODIGO_EMPLEADO asc")
                    cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.seccion=" & Me.cmbSecciones.SelectedValue.ToString(), 0)
                Else
                    cantidadEmpleados.Text = 0
                End If
            End If
        End If
    End Sub

    Private Sub cmbGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGeneral.CheckedChanged
        If Me.cmbGeneral.Checked = True Then
            chkDetalle.Checked = False
        Else
            chkDetalle.Checked = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoEmpleado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) And Me.txtCodigoEmpleado.Text.Length > 0 Then
            Me.txtNombreEmpleado.Text = jClass.obtenerEscalar("SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.txtCodigoEmpleado.Text)
            Button1.PerformClick()
        End If
    End Sub

    Private Sub chkDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetalle.CheckedChanged
        If Me.chkDetalle.Checked = True Then
            cmbGeneral.Checked = False
        Else
            cmbGeneral.Checked = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Rpt As New Boleta_de_pago
        generaQuery()
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Rpt As New Constancia_ISR
        generaQuery()
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        busquedaClientes()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            'RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            'RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton4.Checked = False
            'RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            RadioButton1.Checked = False
            RadioButton3.Checked = False
            RadioButton2.Checked = False
            'RadioButton5.Checked = False
        End If
    End Sub

    'Private Sub cmbGerencias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Iniciando = False Then
    '        If GroupBox7.Enabled = True Then
    '            If RadioButton5.Checked = True Then
    '                CargarSocios()
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RadioButton5.Checked = True Then
    '        RadioButton1.Checked = False
    '        RadioButton3.Checked = False
    '        RadioButton2.Checked = False
    '        RadioButton4.Checked = False
    '    End If
    'End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If Iniciando = False Then
            cmbDepartamentos.DataSource = Nothing
            jClass.CargarCombo(Me.cmbDepartamentos, "SELECT distinct DEPARTAMENTO,DESCRIPCION_DEPARTAMENTO FROM COOPERATIVA_CATALOGO_DEPARTAMENTOS ORDER BY DESCRIPCION_DEPARTAMENTO ASC", "DEPARTAMENTO", "DESCRIPCION_DEPARTAMENTO")
            cmbDepartamentos.SelectedIndex = 0
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        If Iniciando = False Then
            cmbSecciones.DataSource = Nothing
            jClass.CargarCombo(Me.cmbSecciones, "SELECT distinct SECCION,DESCRIPCION_SECCION FROM COOPERATIVA_CATALOGO_SECCIONES ORDER BY DESCRIPCION_SECCION DESC", "SECCION", "DESCRIPCION_SECCION")
            cmbSecciones.SelectedIndex = 0

        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        If Iniciando = False Then
            cmbCargos.DataSource = Nothing
            jClass.CargarCombo(Me.cmbCargos, "SELECT distinct CARGO,DESCRIPCION_CARGO FROM COOPERATIVA_CATALOGO_CARGOS ORDER BY DESCRIPCION_CARGO ASC", "CARGO", "DESCRIPCION_CARGO")
            Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct s.CODIGO_EMPLEADO, s1.DEPARTAMENTO from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.CARGO=" & cmbCargos.SelectedValue.ToString() & " order by CODIGO_EMPLEADO asc")
            cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.CARGO=" & Me.cmbCargos.SelectedValue.ToString(), 0)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox7.Enabled = True
            GroupBox6.Enabled = False
            Me.RadioButton4.Checked = True
            Me.RadioButton6.Checked = False
            Me.RadioButton7.Checked = False
            Me.RadioButton9.Checked = False
        Else
            GroupBox7.Enabled = False
            GroupBox6.Enabled = True
            Me.RadioButton6.Checked = True
            Me.RadioButton1.Checked = False
            Me.RadioButton2.Checked = False
            Me.RadioButton3.Checked = False
            Me.RadioButton4.Checked = False
            'Me.RadioButton5.Checked = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Rpt As New Cooperativa_a_Imprimir
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = Rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "REPARTO #" & Me.NumericUpDown11.Value & "      AÑO: " & Me.DateTimePicker2.Value.Year
        'sql = "SELECT DISTINCT SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION, DIV.DESCRIPCION_DIVISION, DEP.DESCRIPCION_DEPARTAMENTO, SEC.DESCRIPCION_SECCION, CAR.DESCRIPCION_CARGO" & vbCrLf
        sql = "SELECT DISTINCT SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION, dbo.PadLeft(CONVERT(VARCHAR,s1.DIVISION),'0',2) + ' - ' + DIV.DESCRIPCION_DIVISION AS DESCRIPCION_DIVISION, dbo.PadLeft(CONVERT(VARCHAR,s1.DEPARTAMENTO),'0',2) + ' - '  + DEP.DESCRIPCION_DEPARTAMENTO AS DESCRIPCION_DEPARTAMENTO, dbo.PadLeft(CONVERT(VARCHAR,s1.SECCION),'0',2) + ' - ' + SEC.DESCRIPCION_SECCION AS DESCRIPCION_SECCION, CAR.DESCRIPCION_CARGO"
        sql &= "  FROM COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA, COOPERATIVA_CATALOGO_SOCIOS s1," & vbCrLf
        sql &= "       COOPERATIVA_CATALOGO_DIVISIONES DIV, COOPERATIVA_CATALOGO_DEPARTAMENTOS DEP, COOPERATIVA_CATALOGO_SECCIONES SEC, COOPERATIVA_CATALOGO_CARGOS CAR" & vbCrLf
        sql &= " WHERE SA.COMPAÑIA = S1.COMPAÑIA And SA.CODIGO_EMPLEADO = s1.CODIGO_EMPLEADO" & vbCrLf
        sql &= "   AND s1.COMPAÑIA = DIV.COMPAÑIA AND s1.DIVISION = DIV.DIVISION" & vbCrLf
        sql &= "   AND s1.COMPAÑIA = DEP.COMPAÑIA AND s1.DIVISION = DEP.DIVISION AND S1.DEPARTAMENTO = DEP.DEPARTAMENTO" & vbCrLf
        sql &= "   AND s1.COMPAÑIA = DEP.COMPAÑIA AND s1.DIVISION = SEC.DIVISION AND S1.DEPARTAMENTO = SEC.DEPARTAMENTO AND S1.SECCION = SEC.SECCION" & vbCrLf
        sql &= "   AND s1.COMPAÑIA = CAR.COMPAÑIA AND s1.DIVISION = CAR.DIVISION AND S1.DEPARTAMENTO = CAR.DEPARTAMENTO AND S1.SECCION = CAR.SECCION AND s1.CARGO = CAR.CARGO" & vbCrLf
        sql &= "   AND s1.ORIGEN <> 18 AND SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & vbCrLf
        sql &= "   AND s1.COMPAÑIA = " & Compañia & " AND SA.DIV_ORD > 0" & vbCrLf
        sql &= " ORDER BY s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION,s1.NOMBRE_COMPLETO "
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Rpt As New Cooperativa_Estado_Cuentas
        CargarSocios()
        If Table1.Rows.Count > 0 Then
            For i As Integer = 0 To Table1.Rows.Count - 1
                sql = "EXEC sp_COOPERATIVA_ESTADO_CUENTA "
                sql &= "@CODIGO_EMPLEADO = " & Table1.Rows(i).Item(0).ToString()
                sql &= ", @FECHA1 = '" & DateTimePicker1.Value.ToString() & "'"
                sql &= ", @FECHA2 = '" & DateTimePicker2.Value.ToString() & "'"
                sql &= ", @BANDERA = 1"
                sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
                sql &= ", @ASOCIACION = 1"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.SetDataSource(Table)

                If cmbGeneral.Checked = True Then
                    sql = "EXECUTE sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS  @COMPAÑIA = 1,@CodigoBuxis=" & Table1.Rows(i).Item(0).ToString() & ",@FECHA_HASTA ='" & Format(DateTimePicker3.Value, "dd-MM-yyyy hh:mm:ss") & "' "
                Else
                    sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] @COMPAÑIA = " & Compañia & ", @DEDUCCION = 0, @CodigoBuxis =" & Table1.Rows(i).Item(0).ToString() & ", @FECHA_DESDE = '" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @FECHA_HASTA = '" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
                End If

                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.Subreports.Item(0).SetDataSource(Table)

                If RadioButton1.Checked = True Then
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text) Then
                    Else
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text)
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                ElseIf RadioButton2.Checked = True Then
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text) Then
                    Else
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text)
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                ElseIf RadioButton3.Checked = True Then
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text) Then
                    Else
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text)
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                ElseIf RadioButton4.Checked = True Then
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text & "\" & cmbCargos.Text) Then
                    Else
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text & "\" & cmbCargos.Text)
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & cmbDivisiones.Text & "\" & cmbDepartamentos.Text & "\" & cmbSecciones.Text & "\" & cmbCargos.Text & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                End If
            Next
        Else
            MsgBox("No hay Datos!")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Rpt As New Cooperativa__Reporte_Resumen_Bancos

        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 5"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.Subreports.Item(4).SetDataSource(Table)

        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 1"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.Subreports.Item(0).SetDataSource(Table)

        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 2"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.Subreports.Item(1).SetDataSource(Table)

        'Menores a $1 Sin Renta
        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 3"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.Subreports.Item(2).SetDataSource(Table)

        'Menores a $1 Con Renta
        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 4"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.Subreports.Item(3).SetDataSource(Table)

        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Imprimir el detalle Ordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            pB2.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            bBw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            bBw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            bBw1.RunWorkerAsync()

            bBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            bBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            bBw2.RunWorkerAsync()

            Me.pB2.Enabled = True
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Imprimir el detalle Extraordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            pB2.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            eBw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            eBw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            eBw1.RunWorkerAsync()

            eBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            eBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            eBw2.RunWorkerAsync()

            Me.pB2.Enabled = True
        End If


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Imprimir el detalle general?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            pB2.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            aBw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            aBw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            aBw1.RunWorkerAsync()

            aBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            aBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            aBw2.RunWorkerAsync()

            Me.pB2.Enabled = True
        End If
    End Sub

    Private Sub btnDetGral2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetGral2.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Imprimir el Reporte General Ordinario/Extraord.?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            pB2.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            BwRepDetGral.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            BwRepDetGral.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            BwRepDetGral.RunWorkerAsync()

            aBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            aBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            aBw2.RunWorkerAsync()

            Me.pB2.Enabled = True
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Label2.Visible = True
        Label2.Text = "Generando Estados de Cuenta..."
        Me.Button13.Visible = True
        divisiones_ = cmbDivisiones.Text
        Try
            CargarSocios()
            Me.pB2.Maximum = Table1.Rows.Count
            Me.cantidadEmpleados.Text = Table1.Rows.Count
            Me.pB2.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            BwCreatePDF.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            BwCreatePDF.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            BwCreatePDF.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BwCreatePDF_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwCreatePDF.DoWork
        ' Creamos una lista de archivos para concatenar
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim Lista As New List(Of String)

        division_ = 0
        departamento_ = 0
        seccion_ = 0

        If Table1.Rows.Count > 0 Then
            For i As Integer = 0 To Table1.Rows.Count - 1
                If Me.BwCreatePDF.CancellationPending Then
                    CrearPDF(Lista)
                    e.Cancel = True
                    Exit Sub
                End If
                Dim Rpt As New Cooperativa_Estado_Cuentas
                sql = "EXEC sp_COOPERATIVA_ESTADO_CUENTA " & vbCrLf
                sql &= "@CODIGO_EMPLEADO = " & Table1.Rows(i).Item(0).ToString() & vbCrLf
                sql &= ", @FECHA1 = '" & DateTimePicker1.Value.ToString() & "'" & vbCrLf
                sql &= ", @FECHA2 = '" & DateTimePicker2.Value.ToString() & "'" & vbCrLf
                sql &= ", @BANDERA = 1" & vbCrLf
                sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString() & vbCrLf
                sql &= ", @ASOCIACION = 1" & vbCrLf
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Try
                    Rpt.SetDataSource(Table)
                Catch EX As Exception
                End Try

                If cmbGeneral.Checked = True Then
                    sql = "EXECUTE sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS  @COMPAÑIA = " & Compañia & ",@CodigoBuxis=" & Table1.Rows(i).Item(0).ToString() & ",@FECHA_HASTA ='" & Format(DateTimePicker3.Value, "dd-MM-yyyy hh:mm:ss") & "' "
                Else
                    sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] @COMPAÑIA = " & Compañia & ", @DEDUCCION = 0, @CodigoBuxis =" & Table1.Rows(i).Item(0).ToString() & ", @FECHA_DESDE = '" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @FECHA_HASTA = '" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
                End If

                sqlCmd.CommandText = sql
                Table = Nothing
                Table = jClass.obtenerDatos(sqlCmd)
                Try
                    Rpt.Subreports.Item(0).SetDataSource(Table)
                Catch EX As Exception
                End Try
                'If CheckBox1.Checked = True Then
                '    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA") Then
                '        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA")
                '        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal")
                '    Else
                '        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal") Then
                '            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal")
                '        End If
                '    End If
                '    If (division_ <> CInt(Table1.Rows(i).Item(2).ToString()) Or departamento_ <> CInt(Table1.Rows(i).Item(3).ToString()) Or seccion_ <> CInt(Table1.Rows(i).Item(4).ToString())) Then

                '        division_ = CInt(Table1.Rows(i).Item(2).ToString())
                '        departamento_ = CInt(Table1.Rows(i).Item(3).ToString())
                '        seccion_ = CInt(Table1.Rows(i).Item(4).ToString())

                '        Dim rep_sep_ As New CooperativaSeparador
                '        Dim tseparator_ As DataTable
                '        tseparator_ = jClass.ejecutaSQLl_llenaDTABLE("EXEC sp_COOPERATIVA_GENERA_SEPARADOR " & division_.ToString() & "," & departamento_.ToString() & "," & seccion_)
                '        Try
                '            rep_sep_.SetDataSource(tseparator_)
                '            tseparator_.Dispose()

                '            rep_sep_.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")
                '            ' Los añadimos a la lista
                '            AddWaterMark("SEPARADOR", My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf", My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")
                '            Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")
                '            rep_sep_.Close()
                '            rep_sep_.Dispose()
                '        Catch EX As Exception
                '        End Try
                '    End If
                '    Try
                '        Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_ & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                '        ' Los añadimos a la lista

                '        Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_ & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '    End Try
                'Else
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA") Then
                    System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA")
                    System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal")
                Else
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal") Then
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal")
                    End If
                End If
                'En caso de todos los socios
                'Generando el Separador si cambia alguno de los filtros Division, Departamento o Seccion
                If (division_ <> CInt(Table1.Rows(i).Item(2).ToString()) Or departamento_ <> CInt(Table1.Rows(i).Item(3).ToString()) Or seccion_ <> CInt(Table1.Rows(i).Item(4).ToString())) Then

                    division_ = CInt(Table1.Rows(i).Item(2).ToString())
                    departamento_ = CInt(Table1.Rows(i).Item(3).ToString())
                    seccion_ = CInt(Table1.Rows(i).Item(4).ToString())

                    Dim rep_sep_ As New CooperativaSeparador
                    Dim tseparator_ As DataTable
                    tseparator_ = jClass.ejecutaSQLl_llenaDTABLE("EXEC sp_COOPERATIVA_GENERA_SEPARADOR " & division_.ToString() & "," & departamento_.ToString() & "," & seccion_)
                    Try
                        rep_sep_.SetDataSource(tseparator_)
                        tseparator_.Dispose()

                        rep_sep_.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")

                        ' Los añadimos a la lista
                        AddWaterMark("SEPARADOR", My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Temporal\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf", My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")
                        Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\Separador" & Table1.Rows(i).Item(2).ToString() & "-" & Table1.Rows(i).Item(3).ToString() & "-" & Table1.Rows(i).Item(4).ToString() & ".pdf")
                        rep_sep_.Close()
                        rep_sep_.Dispose()
                    Catch EX As Exception
                    End Try
                End If
                Try
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                    ' Los añadimos a la lista
                    Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                Catch EX As Exception
                End Try
                'End If

                Rpt.Refresh()
                Rpt.Dispose()
                Me.BwCreatePDF.ReportProgress(i + 1)
                poneTexto("Generando Estados de Cuenta... " & Format((((i + 1) / Val(Table1.Rows.Count)) * 100), "0.00") & "%")
            Next

            'Se pasa a este metodo que crea el archivo final.
            CrearPDF(Lista)
        Else
            MsgBox("No hay Datos!")
        End If
    End Sub

    Private Sub BwCreatePDF_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BwCreatePDF.ProgressChanged
        Me.pB2.Value = e.ProgressPercentage
        If Val(e.ProgressPercentage) = Val(Me.cantidadEmpleados.Text) Then
            Me.pB2.Value = 0
        End If
    End Sub

    Private Sub BwCreatePDF_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwCreatePDF.RunWorkerCompleted
        Button13.Visible = False
        Label2.Visible = False
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("PROCESO CANCELADO POR EL USUARIO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            MsgBox("PROCESO FINALIZADO" & vbCrLf & vbCrLf & "EN BREVE SE MOSTRARA EL PDF GENERADO.")
            Me.pB2.Value = 0
            Me.pB2.Maximum = 100
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim Rpt As New Cooperativa_Estado_Cuentas_Sin_Ayuda
        ' Creamos una lista de archivos para concatenar
        Dim Lista As New List(Of String)

        'Carga los socios segun los combos seleccionados
        CargarSocios()

        If Table1.Rows.Count > 0 Then
            For i As Integer = 0 To Table1.Rows.Count - 1
                sql = "EXEC sp_COOPERATIVA_ESTADO_CUENTA "
                sql &= "@CODIGO_EMPLEADO = " & Table1.Rows(i).Item(0).ToString()
                sql &= ", @FECHA1 = '" & DateTimePicker1.Value.ToString() & "'"
                sql &= ", @FECHA2 = '" & DateTimePicker2.Value.ToString() & "'"
                sql &= ", @BANDERA = 1"
                sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
                sql &= ", @ASOCIACION = 1"
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.SetDataSource(Table)

                If cmbGeneral.Checked = True Then
                    sql = "EXECUTE sp_COOPERATIVA_REPORTE_CONSTANCIA_DEUDAS  @COMPAÑIA = 1,@CodigoBuxis=" & Table1.Rows(i).Item(0).ToString() & ",@FECHA_HASTA ='" & Format(DateTimePicker3.Value, "dd-MM-yyyy hh:mm:ss") & "' "
                Else
                    sql = "EXECUTE [dbo].[COOPERATIVA_ESTADO_CUENTA_DEUDA_SOCIOS] @COMPAÑIA = " & Compañia & ", @DEDUCCION = 0, @CodigoBuxis =" & Table1.Rows(i).Item(0).ToString() & ", @FECHA_DESDE = '" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "', @FECHA_HASTA = '" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
                End If

                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                Rpt.Subreports.Item(0).SetDataSource(Table)

                If CheckBox1.Checked = True Then
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_) Then
                    Else
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_)
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_ & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                    ' Los añadimos a la lista

                    Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & divisiones_ & "\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                Else
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA") Then
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA")
                    End If
                    Rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                    ' Los añadimos a la lista

                    Lista.Add(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\" & Table1.Rows(i).Item(0).ToString() & ".pdf")
                End If
            Next

            ' Nombre del documento resultante
            Dim sFileJoin As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\EdoCtaDividendosASTAS" & Me.NumericUpDown11.Value & ".pdf"
            Dim Doc As New Document()

            Try

                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()

                Dim Rd As PdfReader
                Dim File As String
                Dim n As Integer 'Número de páginas de cada pdf

                For Each File In Lista
                    Rd = New PdfReader(File)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
                Shell("cmd /C """ & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\EdoCtaDividendosASTAS" & Me.NumericUpDown11.Value & ".pdf""")
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf")
            Finally
                ' Cerramos el documento
                Doc.Close()
            End Try
        Else
            MsgBox("No hay Datos!")
        End If
    End Sub

    Private Sub bBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bBw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            Dim Rpt As New Cooperativa_Reporte_Dividendos_Factores

            Rpt.SetDataSource(Table)
            Me.CrystalReportViewer1.ReportSource = Rpt
            ban2 = 1
            pB2.Value = 0
        End If
    End Sub

    Private Sub bBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bBw1.DoWork


        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 6,"
        sql &= " @FECHA1 = '" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',"
        sql &= " @FECHA2 = '" & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia

        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)

    End Sub

    Private Sub bBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bBw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If bBw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban2 = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                bBw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        bBw2.ReportProgress(100)
        ban2 = 0
    End Sub

    Private Sub bBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bBw2.ProgressChanged
        pB2.Value = e.ProgressPercentage
    End Sub

    Private Sub eBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles eBw1.DoWork
        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 7,"
        sql &= " @FECHA1 = '" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',"
        sql &= " @FECHA2 = '" & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)

    End Sub

    Private Sub eBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles eBw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            Dim Rpt As New Cooperativa_Reporte_Dividendos_Extra

            Rpt.SetDataSource(Table)

            Me.CrystalReportViewer1.ReportSource = Rpt

            ban2 = 1
            pB2.Value = 0
        End If
    End Sub

    Private Sub eBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles eBw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If eBw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban2 = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                eBw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        eBw2.ReportProgress(100)
        ban2 = 0
    End Sub

    Private Sub eBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles eBw2.ProgressChanged
        pB2.Value = e.ProgressPercentage
    End Sub

    Private Sub aBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles aBw1.DoWork

        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 8,"
        sql &= " @FECHA1 = '" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',"
        sql &= " @FECHA2 = '" & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)

    End Sub

    Private Sub aBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles aBw1.RunWorkerCompleted
        Dim Rpt As New Cooperativa_Reparto_Dividendos_General
        Rpt.SetDataSource(Table)

        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Private Sub BwRepDetGral_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwRepDetGral.DoWork
        Table.Clear()
        sql = "EXEC sp_REPORTES_VARIOS_DIVIDENDOS "
        sql &= " @BANDERA = 13,"
        sql &= " @FECHA1 = '" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',"
        sql &= " @FECHA2 = '" & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "'"
        sql &= ", @NUMERO_REPARTO = " & NumericUpDown11.Value.ToString()
        sql &= ", @ASOCIACION = 1"
        sql &= ", @COMPAÑIA = " & Compañia
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
    End Sub

    Private Sub BwRepDetGral_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwRepDetGral.RunWorkerCompleted
        Dim Rpt2 As New Cooperativa_Reparto_Dividendos_General_2
        Rpt2.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt2
    End Sub

    Private Sub aBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles aBw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If aBw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban2 = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                aBw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        aBw2.ReportProgress(100)
        ban2 = 0
    End Sub

    Private Sub aBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles aBw2.ProgressChanged
        pB2.Value = e.ProgressPercentage
    End Sub
#End Region

#Region "Funciones"
    'Metodo de busqueda de Socios
    Public Sub busquedaClientes()
        Dim Socios As New Facturacion_BusquedaSocios
        Socios.Compañia_Value = Compañia
        Socios.cmbCOMPAÑIA.Enabled = False
        Socios.Bodega_Fact = Compañia

        If Producto Is Nothing Then
            Producto = ""
        End If

        Socios.ShowDialog()
        datosSocio(Producto, Numero)
    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim sqlCmd As New SqlCommand
        If numSocio <> "" Then
            Try
                'CheckDisponible.Checked = True                
                sql = " Execute Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS "
                sql &= Compañia
                sql &= ", '" & numSocio & "'"
                sql &= ", " & codEmp
                sql &= ", 13" 'BANDERA
                sqlCmd.CommandText = sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count = 1 Then
                    'TODO Cambio  del codigo que recibe por el de BUXIS
                    'Me.txtCliente.Text = Table.Rows(0).Item("CODIGO_EMPLEADO_AS")
                    Me.txtCodigoEmpleado.Text = Table.Rows(0).Item("CODIGO_EMPLEADO")
                    Me.txtNombreEmpleado.Text = Table.Rows(0).Item("NOMBRE_COMPLETO")
                    txtCodigoEmpleado.Focus()
                Else
                    MsgBox("No se encontraron datos para el socio: " + Me.txtCodigoEmpleado.Text, MsgBoxStyle.Critical, "No hay Datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    Private Sub CargarSocios()
        If Iniciando = False Then
            Table1 = Nothing
            Try
                If CheckBox1.Checked = True Then
                    'SEGUN COMBO DE DIVISIONES
                    If Me.RadioButton1.Checked = True Then
                        Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & "order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                        cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " and C.ASOCIACION = 1 AND C.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                        'SEGUN COMBO DE DEPARTAMENTOS
                    ElseIf Me.RadioButton2.Checked = True Then
                        If TextBox3.Text = "" Then
                            Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                        Else
                            Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND SA.CODIGO_EMPLEADO>" & Val(TextBox3.Text) & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                        End If
                        cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " and C.ASOCIACION = 1 AND C.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                        'SEGUN COMBO DE SECCIONES
                    ElseIf Me.RadioButton3.Checked = True Then
                        If TextBox3.Text = "" Then
                            Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND s1.SECCION=" & cmbSecciones.SelectedValue.ToString() & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                        Else
                            Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND s1.SECCION=" & cmbSecciones.SelectedValue.ToString() & " AND SA.CODIGO_EMPLEADO>" & Val(TextBox3.Text) & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                        End If
                        cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & " and C.ASOCIACION = 1 AND C.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                        'SEGUN COMBO DE CARGOS
                    ElseIf Me.RadioButton4.Checked = True Then
                        If Me.cmbCargos.SelectedValue <> Nothing Then
                            If TextBox3.Text = "" Then
                                Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND s1.SECCION=" & cmbSecciones.SelectedValue.ToString() & " and s1.CARGO=" & cmbCargos.SelectedValue.ToString() & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                            Else
                                Table1 = jClass.ejecutaSQLl_llenaDTABLE("select distinct SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION from COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO inner join COOPERATIVA_CATALOGO_SOCIOS s1 on s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO where s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " and s1.division=" & Me.cmbDivisiones.SelectedValue.ToString() & " and s1.departamento=" & cmbDepartamentos.SelectedValue.ToString() & " AND s1.SECCION=" & cmbSecciones.SelectedValue.ToString() & " and s1.CARGO=" & cmbCargos.SelectedValue.ToString() & " AND SA.CODIGO_EMPLEADO>" & Val(TextBox3.Text) & " and SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " order by division,departamento,seccion,NOMBRE_COMPLETO asc")
                            End If
                            cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT S.CODIGO_EMPLEADO) FROM COOPERATIVA_CATALOGO_SOCIOS S INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C ON C.COMPAÑIA=S.COMPAÑIA AND C.CODIGO_EMPLEADO=S.CODIGO_EMPLEADO WHERE S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & " AND S.CARGO=" & Me.cmbCargos.SelectedValue.ToString() & " and C.ASOCIACION = 1 AND C.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                        Else
                            cantidadEmpleados.Text = 0
                            Table1 = Nothing
                        End If
                        'SEGUN COMBO DE GERENCIAS
                        'ElseIf RadioButton5.Checked = True Then
                        '    Table1 = jClass.ejecutaSQLl_llenaDTABLE("SELECT DISTINCT CODIGO_EMPLEADO, P.Departamento FROM COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO S INNER JOIN PLANILLA_CATALOGO_EMPLEADOS P ON P.CodigoEmpleado=S.CODIGO_EMPLEADO WHERE P.Gerencia='" & cmbGerencias.SelectedValue.ToString() & "' and S.ASOCIACION = 1 AND S.NUMERO_REPARTO = " & Me.NumericUpDown11.Value)
                        '    cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT CODIGO_EMPLEADO) FROM COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO S INNER JOIN PLANILLA_CATALOGO_EMPLEADOS P ON P.CodigoEmpleado=S.CODIGO_EMPLEADO WHERE P.Gerencia='" & cmbGerencias.SelectedValue.ToString() & "' and C.ASOCIACION = 1 AND C.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                    End If
                Else
                    Table1 = jClass.ejecutaSQLl_llenaDTABLE("SELECT DISTINCT SA.CODIGO_EMPLEADO,s1.NOMBRE_COMPLETO,s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION FROM COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA INNER JOIN COOPERATIVA_CATALOGO_SOCIOS s1 ON SA.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO WHERE SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " ORDER BY s1.DIVISION,s1.DEPARTAMENTO,s1.SECCION,s1.NOMBRE_COMPLETO asc")
                    cantidadEmpleados.Text = jClass.leerDataeader("SELECT COUNT(DISTINCT s1.CODIGO_EMPLEADO) FROM COOPERATIVA_SOCIO_AHORROS s INNER JOIN COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO SA ON SA.COMPAÑIA=SA.COMPAÑIA AND SA.CODIGO_EMPLEADO=s.CODIGO_EMPLEADO INNER JOIN COOPERATIVA_CATALOGO_SOCIOS s1 ON s.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO WHERE  SA.ASOCIACION = 1 AND SA.NUMERO_REPARTO = " & Me.NumericUpDown11.Value, 0)
                End If
            Catch ex As Exception
                Table1 = Nothing
                cantidadEmpleados.Text = 0
            End Try
        End If
    End Sub

    Private Sub CrearPDF(ByVal lista_ As System.Collections.Generic.List(Of String))
        'Nombre del documento resultante
        'Dim sFileJoin As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\DocumentoJoin.pdf"
        Dim sFileJoin As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\EdoCtaDividendosASTAS" & Me.NumericUpDown11.Value & ".pdf"
        Dim Doc As New Document()

        Try
            Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy As New PdfCopy(Doc, fs)
            Doc.Open()
            Dim Rd As PdfReader
            Dim File As String
            Dim n As Integer 'Número de páginas de cada pdf
            Dim i As Integer = 0
            Dim poneVal As New CallBackSetVal(AddressOf SetVal)
            Dim poneTexto As New CallBackSetText(AddressOf SetText)

            poneVal(lista_.Count)

            For Each File In lista_
                i += 1
                Rd = New PdfReader(File)
                n = Rd.NumberOfPages
                Dim page As Integer = 0
                Do While page < n
                    page += 1
                    copy.AddPage(copy.GetImportedPage(Rd, page))
                Loop
                copy.FreeReader(Rd)
                Rd.Dispose()
                Me.BwCreatePDF.ReportProgress(i)
                poneTexto("Generando PDF... " & Format(((i / Val(lista_.Count)) * 100), "0.00") & "%")
            Next

            'Shell("cmd /C """ & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA\DocumentoJoin.pdf""")            
            Shell("cmd /C """ & My.Computer.FileSystem.SpecialDirectories.Desktop & "\EdoCtaDividendosASTAS" & Me.NumericUpDown11.Value & ".pdf""", AppWinStyle.NormalNoFocus, False, 10000)
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf")
        Finally
            ' Cerramos el documento
            Doc.Close()
        End Try
        Try
            'Borrando el directorio 
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ESTADOS_DE_CUENTA", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddWaterMark(ByVal texto_mostrar_ As String, ByVal ruta_archivo_ As String, ByVal ruta_archivo_salida_ As String)
        Dim pdfReader As New PdfReader(ruta_archivo_)
        Dim stream As New FileStream(ruta_archivo_salida_, FileMode.OpenOrCreate)
        Dim pdfStamper As New PdfStamper(pdfReader, stream)
        For pageIndex As Integer = 1 To pdfReader.NumberOfPages
            Dim pageRectangle As Rectangle = pdfReader.GetPageSizeWithRotation(pageIndex)
            Dim pdfData As PdfContentByte = pdfStamper.GetUnderContent(pageIndex)
            pdfData.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 60)
            Dim graphicsState As New PdfGState()
            graphicsState.FillOpacity = 0.2F
            pdfData.SetGState(graphicsState)
            pdfData.SetColorFill(BaseColor.LIGHT_GRAY)
            pdfData.BeginText()
            pdfData.ShowTextAligned(Element.ALIGN_CENTER, texto_mostrar_, pageRectangle.Width / 2, pageRectangle.Height / 2, 45)
            pdfData.EndText()
        Next
        pdfStamper.Close()
        pdfStamper.Dispose()
        stream.Close()
        stream.Dispose()
    End Sub

    Private Function generaQuery(Optional ByVal Anual As Boolean = False) As String
        sql = "DECLARE @TABLA AS TABLE(CODIGO_EMPLEADO INT, " & vbCrLf
        sql &= " CODIGO_EMPLEADO_AS VARCHAR(6), " & vbCrLf
        sql &= " VALOR NUMERIC(18,6), " & vbCrLf
        sql &= " RENTA NUMERIC(18,6), " & vbCrLf
        sql &= " LIQUIDO NUMERIC(18,6), " & vbCrLf
        sql &= " NOMBRE_COMPLETO VARCHAR(101), " & vbCrLf
        sql &= " DESCRIPCION_BANCO VARCHAR(101), " & vbCrLf
        sql &= " BANCO VARCHAR(50), " & vbCrLf
        sql &= " DUI VARCHAR(10), " & vbCrLf
        sql &= " NIT VARCHAR(17), " & vbCrLf
        sql &= " PERIODO VARCHAR(150), " & vbCrLf
        sql &= " ASOCIACION VARCHAR(200), " & vbCrLf
        sql &= " CODBANCO INT) " & vbCrLf
        sql &= " SELECT C.CODIGO_EMPLEADO, C.CODIGO_EMPLEADO_AS, SUM(C.div_ord) 'VALOR', SUM(C.div_ord)*0.1 'RENTA',SUM(C.div_ord)-SUM(C.div_ord)*0.1 'LIQUIDO',S.NOMBRE_COMPLETO, B.DESCRIPCION_BANCO, S.CUENTA_BANCARIA, S.DUI, S.NIT, [dbo].[fn_INVENTARIOS_PERIODO_SEGUN_FECHA](CONVERT(DATE, '" & IIf(Anual, "01/01/" & Me.DateTimePicker1.Value.Year, Format(Me.DateTimePicker1.Value, "dd/MM/yyyy")) & "',103),CONVERT(DATE, '" & IIf(Anual, "31/12/" & Me.DateTimePicker2.Value.Year, Format(Me.DateTimePicker2.Value, "dd/MM/yyyy")) & "',103)) AS PERIODO," & vbCrLf
        sql &= " (SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 1) AS ASOCIACION, B.BANCO" & vbCrLf
        sql &= " INTO #TABLA_TEMPORAL0" & vbCrLf
        sql &= " FROM COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO C" & vbCrLf
        sql &= " INNER JOIN COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
        sql &= " ON S.COMPAÑIA=C.COMPAÑIA AND S.CODIGO_EMPLEADO=C.CODIGO_EMPLEADO" & vbCrLf
        sql &= " INNER JOIN CONTABILIDAD_CATALOGO_BANCOS B" & vbCrLf
        sql &= " ON B.COMPAÑIA=C.COMPAÑIA AND B.BANCO=S.BANCO" & vbCrLf
        sql &= " WHERE C.ASOCIACION=1" & vbCrLf
        If Anual Then
            sql &= " AND YEAR(FECHA_1) = " & Me.DateTimePicker1.Value.Year & vbCrLf
        Else
            sql &= " AND NUMERO_REPARTO=" & NumericUpDown11.Value.ToString() & vbCrLf
        End If
        If CheckBox1.Checked = True Then
            If RadioButton1.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton2.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton3.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton4.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & " AND S.CARGO=" & Me.cmbCargos.SelectedValue.ToString() & vbCrLf
            End If
        End If
        If txtCodigoEmpleado.Text.Length > 0 Then
            'SI HAY ALGUN CODIGO ESPECIFICO EL CUAL MOSTRAR
            sql &= " AND S.CODIGO_EMPLEADO = " & Val(txtCodigoEmpleado.Text) & vbCrLf
        End If
        sql &= " GROUP BY C.CODIGO_EMPLEADO,C.CODIGO_EMPLEADO_AS,S.NOMBRE_COMPLETO,  B.DESCRIPCION_BANCO, S.CUENTA_BANCARIA,  S.DUI, S.NIT, B.BANCO" & vbCrLf
        sql &= " ORDER BY C.CODIGO_EMPLEADO ASC" & vbCrLf
        sql &= " select C.CODIGO_EMPLEADO, C.CODIGO_EMPLEADO_AS, SUM(DIV_EXT) 'VALOR', SUM(DIV_EXT)*0.1 'RENTA',SUM(DIV_EXT)- SUM(DIV_EXT)*0.1 'LIQUIDO',S.NOMBRE_COMPLETO,  B.DESCRIPCION_BANCO, S.CUENTA_BANCARIA, S.DUI, S.NIT, [dbo].[fn_INVENTARIOS_PERIODO_SEGUN_FECHA](CONVERT(DATE, '" & IIf(Anual, "01/01/" & Me.DateTimePicker1.Value.Year, Format(Me.DateTimePicker1.Value, "dd/MM/yyyy")) & "',103),CONVERT(DATE, '" & IIf(Anual, "31/12/" & Me.DateTimePicker2.Value.Year, Format(Me.DateTimePicker2.Value, "dd/MM/yyyy")) & "',103)) AS PERIODO," & vbCrLf
        sql &= " (SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 1) AS ASOCIACION, B.BANCO" & vbCrLf
        sql &= " INTO #TABLA_TEMPORAL1" & vbCrLf
        sql &= " from COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO_EXT C" & vbCrLf
        sql &= " INNER JOIN COOPERATIVA_CATALOGO_SOCIOS S" & vbCrLf
        sql &= " ON S.COMPAÑIA=C.COMPAÑIA AND S.CODIGO_EMPLEADO=C.CODIGO_EMPLEADO" & vbCrLf
        sql &= " INNER JOIN CONTABILIDAD_CATALOGO_BANCOS B" & vbCrLf
        sql &= " ON B.COMPAÑIA=C.COMPAÑIA AND B.BANCO=S.BANCO" & vbCrLf
        sql &= " WHERE C.ASOCIACION=1" & vbCrLf
        If Anual Then
            sql &= " AND YEAR(FECHA_1) = " & Me.DateTimePicker1.Value.Year & vbCrLf
        Else
            sql &= " AND NUMERO_REPARTO=" & NumericUpDown11.Value.ToString() & vbCrLf
        End If
        If CheckBox1.Checked = True Then
            If RadioButton1.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton2.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton3.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & vbCrLf
            ElseIf RadioButton4.Checked = True Then
                sql &= " AND S.DIVISION=" & Me.cmbDivisiones.SelectedValue.ToString() & " AND S.DEPARTAMENTO=" & Me.cmbDepartamentos.SelectedValue.ToString() & " AND S.SECCION=" & Me.cmbSecciones.SelectedValue.ToString() & " AND S.CARGO=" & Me.cmbCargos.SelectedValue.ToString() & vbCrLf
            End If
        End If
        If Me.txtCodigoEmpleado.Text.Length > 0 Then
            'SI HAY ALGUN CODIGO ESPECIFICO EL CUAL MOSTRAR
            sql &= " AND S.CODIGO_EMPLEADO = " & Val(txtCodigoEmpleado.Text) & vbCrLf
        End If
        sql &= " GROUP BY C.CODIGO_EMPLEADO,C.CODIGO_EMPLEADO_AS,S.NOMBRE_COMPLETO,  B.DESCRIPCION_BANCO, S.CUENTA_BANCARIA, S.DUI, S.NIT, B.BANCO" & vbCrLf
        sql &= " ORDER BY C.CODIGO_EMPLEADO ASC" & vbCrLf
        sql &= " INSERT INTO @TABLA" & vbCrLf
        sql &= " SELECT * " & vbCrLf
        sql &= " FROM #TABLA_TEMPORAL0" & vbCrLf
        sql &= " INSERT INTO @TABLA" & vbCrLf
        sql &= " SELECT * " & vbCrLf
        sql &= " FROM #TABLA_TEMPORAL1" & vbCrLf
        sql &= " SELECT " & Compañia & " AS COMPAÑIA, CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, SUM(VALOR) 'VALOR', ROUND(SUM(VALOR) * 0.1,2) 'RENTA', ROUND(SUM(VALOR) - ROUND(SUM(VALOR) * 0.1,2),2) 'LIQUIDO', NOMBRE_COMPLETO, DESCRIPCION_BANCO, BANCO, DUI, NIT, LOWER(PERIODO) AS PERIODO, ASOCIACION, CODBANCO" & vbCrLf
        sql &= " INTO #TABLA_TEMPORAL2" & vbCrLf
        sql &= " FROM @TABLA" & vbCrLf
        sql &= " GROUP BY  CODIGO_EMPLEADO, CODIGO_EMPLEADO_AS, NOMBRE_COMPLETO, DESCRIPCION_BANCO, BANCO, DUI, NIT, PERIODO, ASOCIACION, CODBANCO" & vbCrLf

        sql &= " SELECT SA.CODIGO_EMPLEADO, SA.CODIGO_EMPLEADO_AS, SA.VALOR, SA.RENTA, SA.LIQUIDO, SA.NOMBRE_COMPLETO, SA.DESCRIPCION_BANCO, SA.BANCO, SA.DUI, SA.NIT, SA.PERIODO, SA.ASOCIACION, SA.CODBANCO, dbo.PadLeft(CONVERT(VARCHAR,s1.DIVISION),'0',2) + ' - ' + DIV.DESCRIPCION_DIVISION AS DIVISION, dbo.PadLeft(CONVERT(VARCHAR,s1.DEPARTAMENTO),'0',2) + ' - '  + DEP.DESCRIPCION_DEPARTAMENTO AS DEPARTAMENTO, dbo.PadLeft(CONVERT(VARCHAR,s1.SECCION),'0',2) + ' - ' + SEC.DESCRIPCION_SECCION AS SECCION, CAR.DESCRIPCION_CARGO AS CARGO" & vbCrLf
        sql &= " FROM #TABLA_TEMPORAL2 SA, COOPERATIVA_CATALOGO_SOCIOS S1, COOPERATIVA_CATALOGO_DIVISIONES DIV, COOPERATIVA_CATALOGO_DEPARTAMENTOS DEP, COOPERATIVA_CATALOGO_SECCIONES SEC, COOPERATIVA_CATALOGO_CARGOS CAR" & vbCrLf
        sql &= "  WHERE SA.COMPAÑIA = S1.COMPAÑIA AND SA.CODIGO_EMPLEADO=s1.CODIGO_EMPLEADO " & vbCrLf
        sql &= "    AND s1.COMPAÑIA = DIV.COMPAÑIA AND s1.DIVISION = DIV.DIVISION" & vbCrLf
        sql &= "    AND s1.COMPAÑIA = DEP.COMPAÑIA AND s1.DIVISION = DEP.DIVISION AND S1.DEPARTAMENTO = DEP.DEPARTAMENTO" & vbCrLf
        sql &= "    AND s1.COMPAÑIA = DEP.COMPAÑIA AND s1.DIVISION = SEC.DIVISION AND S1.DEPARTAMENTO = SEC.DEPARTAMENTO AND S1.SECCION = SEC.SECCION" & vbCrLf
        sql &= "    AND s1.COMPAÑIA = CAR.COMPAÑIA AND s1.DIVISION = CAR.DIVISION AND S1.DEPARTAMENTO = CAR.DEPARTAMENTO AND S1.SECCION = CAR.SECCION AND s1.CARGO = CAR.CARGO" & vbCrLf
        sql &= "    AND s1.ORIGEN <> 18" & vbCrLf
        sql &= "    AND s1.COMPAÑIA = " & Compañia & " AND SA.RENTA>0" & vbCrLf
        sql &= "  ORDER BY S1.DIVISION, S1.DEPARTAMENTO, S1.SECCION, S1.NOMBRE_COMPLETO" & vbCrLf

        sql &= " DROP TABLE #TABLA_TEMPORAL0" & vbCrLf
        sql &= " DROP TABLE #TABLA_TEMPORAL1" & vbCrLf
        sql &= " DROP TABLE #TABLA_TEMPORAL2" & vbCrLf
        Return sql
    End Function
#End Region

    Private Sub btnConstanciaISRAnual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConstanciaISRAnual.Click
        Dim Rpt As New Constancia_ISR
        generaQuery(True)
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        Rpt.SetDataSource(Table)
        Me.CrystalReportViewer1.ReportSource = Rpt
    End Sub

    Public Sub ReporteGlobales()
        Try
            Dim Rpt As New Cooperativa_Reporte_Global_3
            Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
            txtObj = Rpt.Section2.ReportObjects("Text12")
            txtObj.Text = Descripcion_Compañia
            txtObj = Rpt.Section2.ReportObjects("Text14")
            txtObj.Text = "PERIODO " & jClass.obtenerEscalar("SELECT [dbo].[fn_INVENTARIOS_PERIODO_SEGUN_FECHA]('" & Format(Me.DateTimePicker1.Value, "dd/MM/yyyy") & "','" & Format(Me.DateTimePicker2.Value, "dd/MM/yyyy") & "')")
            Rpt.SetDataSource(jClass.obtenerDatos(New SqlCommand("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=12 ,@COMPAÑIA=" & Compañia & ", @AÑO='" & Me.DateTimePicker1.Value.Year.ToString() & "', @AÑO1='" & Me.DateTimePicker2.Value.Year.ToString() & "', @MES='" & Me.DateTimePicker1.Value.Month.ToString() & "',@MES1='" & Me.DateTimePicker2.Value.Month.ToString() & "',@USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1,@NUMERO_REPARTO=" & NumericUpDown11.Value)))
            Me.CrystalReportViewer1.ReportSource = Rpt
        Catch
            MsgBox("AVISO")
        End Try
    End Sub

    Private Sub btnReporteGral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporteGral.Click
        ReporteGlobales()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.BwCreatePDF.CancelAsync()
        Me.pB2.Value = 0
    End Sub
End Class