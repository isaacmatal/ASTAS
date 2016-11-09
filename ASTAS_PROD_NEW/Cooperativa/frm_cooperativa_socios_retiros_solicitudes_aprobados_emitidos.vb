Imports System.Data
Imports System.Data.SqlClient

Public Class frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos

    Dim Iniciando, Timer_flag As Boolean
    Dim IDRetiro As Integer
    Dim Contador_registros_seleccionados, CantidadRegistros As Integer
    Dim Contador_registros_seleccionados_ENA, CantidadRegistros_ENA As Integer
    Dim Fila_seleccionada, Seleccionado As Boolean
    Dim Fila_seleccionada_ANE, Seleccionado_ENA As Boolean
    Dim NombreBanco_seleccionadoSocio, NombreBanco_seleccionadoSocio_ANE As String
    Dim EjecucionCorrecta, EjecucionCorrecta02 As Boolean
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Fecha_Dia01, Fecha_Dia02, MaxDayMonth_Dia As Integer
    Dim Fecha_Month01, Fecha_Year01 As Integer
    Dim Fecha_Month02, Fecha_Year02 As Integer
    Dim Fechas_accion As String = "SAYE"
    Dim TableRet As DataTable

    Private Sub frm_cooperativa_socios_retiros_cartas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.StartPosition = FormStartPosition.CenterScreen
        Iniciando = True
        Me.DateTimePicker1.Value = Now().AddDays(-Now.Day).AddDays(1)
        CargarDatosComboboxCompania()
        MaxDayMonth()

        Timer_flag = True
        Iniciando = False

        BorrarDatosRetiroAhorros_tablatemporal()
        Me.CmbVerporfechas.Text = "Rango de fechas"

        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        CargarDatos_aprobados_y_emitidos(Compañia, Fechas_accion)
    End Sub

#Region "Connection"

    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS, DS01, DS02, DS03, DS04, DS05, DS06, DS07, DS08, DS09 As New DataSet()
    Dim DS10, DS11, DS12, DS13, DS14, DS15 As New DataSet()
    Dim SQL As String
    Dim Beneficiario, Estado, Parentesco As Integer
    Dim Accion As String
    Dim PorcenBene As Double

    Dim NonApeSocio As String


    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'DS.Reset()
        Conexion_Track.Open()
    End Sub

    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
        'DataAdapter.Fill(DS)

    End Sub

    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

    Sub CargarDatosComboboxCompania()
        Me.CmbCompania.Text = ""
        Try
            OpenConnection()
            SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            'DataReader_Track = Comando_Track.ExecuteReader
            Me.CmbCompania.DataSource = table
            Me.CmbCompania.ValueMember = "COMPAÑIA"
            Me.CmbCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            'DataReader_Tr ack.Close()
            Me.CmbCompania.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

#End Region

    'Cargar datos no aprovados en grid
    Sub CargarDatos_aprobados_y_emitidos(ByVal Compañia, ByVal StrAccion)
        Dim Fe01, Fe02 As String
        Fe01 = Fecha_Dia01 & "/" & Fecha_Month01 & "/" & Fecha_Year01
        Fe02 = Fecha_Dia02 & "/" & Fecha_Month02 & "/" & Fecha_Year02
        'MessageBox.Show("Fe01: " & Fe01 & Chr(13) & "Fe02: " & Fe02)

          If StrAccion = "SAYE" Then
            Try
                DS11.Reset()
                OpenConnection()
                SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS 1," & Compañia & ",2,0,'#123456',6166,'7096',10,0,'" & Usuario & "','27/08/11','" & StrAccion & "','" & Permitir & "'"
                MiddleConnection()
                DataAdapter.Fill(DS11)
                'DataGrid_aprobadas_y_emitidos.DataSource = DS11.Tables(0)
                TableRet = DS11.Tables(0)
                CloseConnection()

            Catch ex As Exception
                'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseConnection()
                'MsgBox("Hola")
            End Try

        ElseIf StrAccion = "SSRAFE" Or StrAccion = "SSRARF" Then
            Try
                DS11.Reset()
                OpenConnection()
                SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS_APROBADAS_MOSTRARFECHAS " & Compañia & ",'" & CDate(Fe01) & "','" & CDate(Fe02) & "','" & StrAccion & "','" & Permitir & "'"
                MiddleConnection()
                DataAdapter.Fill(DS11)
                'DataGrid_aprobadas_y_emitidos.DataSource = DS11.Tables(0)
                TableRet = DS11.Tables(0)
                CloseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseConnection()
            End Try
        End If
        chkFiltroFacturas_CheckedChanged(New Object, New System.EventArgs)
    End Sub


#Region "CMSSolicitutes_noaprobadas_ eliminar"

    Sub Eliminar_Retiro_Solicitud(ByVal Compañia, ByVal IDRetiro, ByVal ParamcodigoBux, ByVal ParamcodigoAs, ByVal Accion)

        Try
            DS02.Reset()
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS " & IDRetiro & "," & Compañia & ",2,0,'#123456'," & ParamcodigoBux & ",'" & ParamcodigoAs & "',10,0,'SYSTEM','27/08/11','" & Accion & "'"
            MiddleConnection()
            DataAdapter.Fill(DS02)
            MessageBox.Show("Registro(s) eliminado(s)...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try

    End Sub

    Sub Eliminar_Retiro_Solicitud_Tabla_Temporal(ByVal Compañia, ByVal IDRetiro, ByVal ParamcodigoBux, ByVal ParamcodigoAs, ByVal Accion)

        Try
            DS04.Reset()
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS_TEMPORAL " & IDRetiro & "," & Compañia & "," & ParamcodigoBux & ",'" & ParamcodigoAs & "','" & Accion & "'"
            MiddleConnection()
            DataAdapter.Fill(DS04)
            'MessageBox.Show("Actualizado...!!!" & Chr(13) & "Registros Ingresados: " & Contador_registros_seleccionados, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Accion = "IDTT-0" Then
                Contador_registros_seleccionados += 1
            Else
                Contador_registros_seleccionados -= 1
                If Contador_registros_seleccionados <= 0 Then
                    Contador_registros_seleccionados = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Aprobar_solicitud_todas()
    End Sub

    Sub BorrarDatosRetiroAhorros_tablatemporal()
        DS06.Reset()
        Try
            OpenConnection()
            SQL = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS_TEMPORAL 1," & Compañia & ",6166,'7096','ETTT'"
            MiddleConnection()
            DataAdapter.Fill(DS06)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

#Region "Solisitudes Aprobados"

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVerporfechas.SelectedIndexChanged

        ContenidoLabel(0)
        If Me.CmbVerporfechas.Text = "Día específico" Then
            ContenidoLabel(1)
        ElseIf Me.CmbVerporfechas.Text = "Rango de fechas" Then
            ContenidoLabel(2)
        ElseIf Me.CmbVerporfechas.Text = "Mes y año" Then
            ContenidoLabel(3)
        ElseIf Me.CmbVerporfechas.Text = "Año" Then
            ContenidoLabel(4)
        ElseIf Me.CmbVerporfechas.Text = "Todas" Then
            ContenidoLabel(5)
        End If

    End Sub
    Sub ContenidoLabel(ByVal valor)
        If valor = 0 Then
            ''Me.DateTimePicker1.Enabled = False
            ''Me.DateTimePicker2.Enabled = False
            ''Me.DateTimePicker1.Text = Today
            ''Me.DateTimePicker1.Format = DateTimePickerFormat.Long
            ''Me.DateTimePicker2.Format = DateTimePickerFormat.Long
        ElseIf valor = 1 Then
            ''Me.DateTimePicker1.Enabled = True
            ''Me.LblMensaje03.Text = "Muestra todos los registros de las solicitudes de retiro de ahorro aprobadas del día seleccionado"
            Fechas_accion = "SSRAFE"
        ElseIf valor = 2 Then
            ''Me.DateTimePicker1.Enabled = True
            ''Me.DateTimePicker2.Enabled = True
            ''Me.LblMensaje03.Text = "Muestra todos los registros de las solicitudes de retiro de ahorro aprobadas entre los periodos de las fechas seleccionadas"
            Fechas_accion = "SSRARF"
        ElseIf valor = 3 Then
            ''Me.DateTimePicker1.Enabled = True
            ' ''Me.DateTimePicker2.Enabled = True
            ''Me.DateTimePicker1.Format = DateTimePickerFormat.Custom
            ''Me.DateTimePicker2.Format = DateTimePickerFormat.Custom
            ''Me.DateTimePicker1.CustomFormat = "MMMM/yyyy"
            'Me.DateTimePicker2.CustomFormat = "yyyy"
            ''Me.LblMensaje03.Text = "Muestra todos los registros de las solicitudes de retiro de ahorro aprobadas en el mes del año seleccionado"
            Fechas_accion = "SSRARF"
        ElseIf valor = 4 Then
            ''Me.DateTimePicker1.Enabled = True
            ''Me.DateTimePicker1.Format = DateTimePickerFormat.Custom
            ''Me.DateTimePicker1.CustomFormat = "yyyy"
            ''Me.LblMensaje03.Text = "Muestra todos los registros de las solicitudes de retiro de ahorro aprobadas del año seleccionado"
            Fechas_accion = "SSRARF"
        ElseIf valor = 5 Then
            ''Me.LblMensaje03.Text = "Muestra todos los registros de las solicitudes de retiro de ahorro aprobadas hasta la fecha actual"
            Fechas_accion = "SAYE"
        End If
    End Sub

    Sub MaxDayMonth()
        'Me.DateTimePicker1.Format = DateTimePickerFormat.Long
        'Me.DateTimePicker2.Format = DateTimePickerFormat.Long
        Dim fecha01 As Date ' = Me.DateTimePicker1.Text
        Dim fecha02 As Date = Me.DateTimePicker2.Text
        'MessageBox.Show(Me.DateTimePicker1.Text)

        If Me.CmbVerporfechas.Text = "Año" Then
            fecha01 = "01/01/" & Me.DateTimePicker1.Text
            fecha02 = "31/12/" & Me.DateTimePicker1.Text
        Else
            fecha01 = Me.DateTimePicker1.Text
        End If


        If Me.CmbVerporfechas.Text = "Rango de fechas" Then
            If fecha01 > fecha02 Then
                MessageBox.Show("El rango de fechas no es valido...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        'Dim Fecha_Month01 As Integer
        'Fecha_Month01 = CInt(fecha01.Month.ToString)
        Fecha_Month01 = fecha01.Month

        'MsgBox(Fecha_Dia)
        'MaxDayMonth_Dia
        If Fecha_Month01 = 1 Or Fecha_Month01 = 3 Or Fecha_Month01 = 5 Or Fecha_Month01 = 7 Or _
        Fecha_Month01 = 8 Or Fecha_Month01 = 10 Or Fecha_Month01 = 12 Then
            MaxDayMonth_Dia = 31
        ElseIf Fecha_Month01 = 2 Then
            MaxDayMonth_Dia = 28
        Else
            MaxDayMonth_Dia = 30
        End If


        Fecha_Dia01 = fecha01.Day
        Fecha_Month01 = fecha01.Month
        Fecha_Year01 = fecha01.Year

        Fecha_Dia02 = fecha02.Day
        Fecha_Month02 = fecha02.Month
        Fecha_Year02 = fecha02.Year

        If Me.CmbVerporfechas.Text = "Mes y año" Then
            Fecha_Dia01 = "1"
            Fecha_Month01 = fecha01.Month
            Fecha_Year01 = fecha01.Year

            Fecha_Dia02 = MaxDayMonth_Dia
            Fecha_Month02 = fecha01.Month
            Fecha_Year02 = fecha01.Year
        End If

        'CargarDatos_aprobados_y_emitidos(Compañia, Fechas_accion)
    End Sub

#End Region

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_aceptar02.Click
        'If Me.DateTimePicker1.Text <> Me.DateTimePicker2.Text Then
        MaxDayMonth()
        CargarDatos_aprobados_y_emitidos(Compañia, Fechas_accion)
        'Else
        '    MessageBox.Show("El rango de fechas no es valido" & Chr(13) & "El rango de fechas no puede ser igual...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If

        'MsgBox("01: " & MaxDayMonth_Dia & "/" & Fecha_Month01 & "/" & Fecha_Year01 & Chr(13) & _
        '        "02: " & Fecha_Dia01 & "/" & Fecha_Month01 & "/" & Fecha_Year01 & Chr(13) & _
        '        "03: " & Fecha_Dia02 & "/" & Fecha_Month02 & "/" & Fecha_Year02)
        'MessageBox.Show(Fechas_accion)

    End Sub

    Private Sub frm_cooperativa_socios_retiros_solicitudes_aprobados_emitidos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub chkFiltroFacturas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltroFacturas.CheckedChanged
        Dim rows As DataRow()
        Dim tablaT As DataTable = TableRet.Clone
        If chkFiltroFacturas.Checked Then
            Me.DataGrid_aprobadas_y_emitidos.DataSource = TableRet
            rows = TableRet.Select("[COMENTARIO] like '%Factura%'")
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.DataGrid_aprobadas_y_emitidos.DataSource = Nothing
            Me.DataGrid_aprobadas_y_emitidos.DataSource = tablaT
        Else
            Me.DataGrid_aprobadas_y_emitidos.DataSource = TableRet
        End If
        Try
            For i As Integer = 0 To 15
                Me.DataGrid_aprobadas_y_emitidos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.DataGrid_aprobadas_y_emitidos.Columns.Item(i).ReadOnly = True
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.lblNumRegs.Text = Me.DataGrid_aprobadas_y_emitidos.Rows.Count.ToString() & " Registros Encontrados"
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim Reporte As New CooperativaRetirosAhorrosConsulta
        Dim frmRep As New frmReportes_Ver
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = Reporte.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = Reporte.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = "Periodo del " & Me.DateTimePicker1.Text & " al " & Me.DateTimePicker2.Text
        Reporte.SetDataSource(Me.DataGrid_aprobadas_y_emitidos.DataSource)
        frmRep.crvReporte.ReportSource = Reporte
        frmRep.ShowDialog(Me)
    End Sub
End Class