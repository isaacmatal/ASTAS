Imports System.Data.SqlClient
Public Class Inventario_Cierre_Periodo
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim MES_F As String
    Dim bodega As Integer
    Dim ban As Integer = 0
    Dim cadena_sql_ As String = ""
    Dim numero As String

#Region "Connection"
    Dim DS01, DS02, DS03 As New DataSet()
    Dim SQL As String
    Dim Resultado As DialogResult
#End Region

#Region "Funciones"
    Public Sub CargarGrid()
        Try
            DS01.Reset()
            SQL = "execute [DBO].[sp_INVENTARIOS_CIERRE] " & Txt_tipo_movimiento_numero.Text & ", " & Compañia & ", " & bodega & ", '" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', 0, '" & Usuario & "', 5, 1"
            c_data1.MiddleConnection(SQL)
            c_data1.DataAdapter.Fill(DS01)
            Me.dgvMovtos.DataSource = DS01.Tables(0)
            c_data1.cerrarConexion()
            For i As Integer = 1 To Me.dgvMovtos.ColumnCount
                dgvMovtos.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        Catch ex As Exception
            MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub sugerirMovTransferencia()
        Dim consulta As String = "SELECT ISNULL(MAX(CIERRE), 0) + 1 FROM INVENTARIOS_CIERRE WHERE COMPAÑIA=" & Compañia & " AND BODEGA=" & Me.cmbBODEGA.SelectedValue
        Txt_tipo_movimiento_numero.Text = c_data1.leerDataeader(consulta, 0)
    End Sub

    Public Sub Limpiar()
        Me.btnProcesar.Enabled = True
        Me.cmbBODEGA.SelectedIndex = 0
        sugerirMovTransferencia()

    End Sub

    Public Function determinar_mes(ByVal mes)
        Select Case mes <> 0
            Case mes = 1
                MES_F = "Enero"
            Case mes = 2
                MES_F = "Febrero"
            Case mes = 3
                MES_F = "Marzo"
            Case mes = 4
                MES_F = "Abril"
            Case mes = 5
                MES_F = "Mayo"
            Case mes = 6
                MES_F = "Junio"
            Case mes = 7
                MES_F = "Julio"
            Case mes = 8
                MES_F = "Agosto"
            Case mes = 9
                MES_F = "Septiembre"
            Case mes = 10
                MES_F = "Octubre"
            Case mes = 11
                MES_F = "Noviembre"
            Case mes = 12
                MES_F = "Diciembre"
            Case Else
                MES_F = ""
        End Select
        Return MES_F
    End Function
#End Region

#Region "Eventos"
    Private Sub Inventario_Cierre_Periodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 7)
        bodega = cmbBODEGA.SelectedValue
        sugerirMovTransferencia()
        CargarGrid()
        Iniciando = False
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Try
            txt_Nota.Visible = True
            Numero = c_data1.leerDataeader("execute sp_INVENTARIOS_CIERRE " & Txt_tipo_movimiento_numero.Text & ", " & Compañia & ", " & Me.cmbBODEGA.SelectedValue & ", '" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', 1, '" & Usuario & "', 6, 1", 0)
            If Numero = 0 Then
                determinar_mes(DateAdd("m", -1, Me.NumericUpDown_Mes.Value).Month)
                MsgBox("Aviso...Debe cerrar el mes anterior: " & MES_F, MsgBoxStyle.Information)
                txt_Nota.Visible = False
                Exit Sub
            End If

            Dim respuesta As MsgBoxResult

            respuesta = MsgBox("Desea cerrar el mes de: " & determinar_mes(DateAdd("m", -1, Me.NumericUpDown_Mes.Value).Month) & " y abrir el mes de: " & determinar_mes(Me.NumericUpDown_Mes.Value.Month) & "?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmación")
            If respuesta = MsgBoxResult.Yes Then
                btnProcesar.Enabled = False
                Me.btnRevertir.Enabled = False

                pB1.Value = 0
                Me.pB1.Enabled = True
                'Le indicamos al BackgroundWorker 2 que puede reportar progresos
                Bw2.WorkerReportsProgress = True
                'Le decimos al BackgroundWorker 2 que puede ser cancelado en cualquier momento
                Bw2.WorkerSupportsCancellation = True
                'Le indicamos al BackgroundWorker 1 que puede reportar progresos
                Bw1.WorkerReportsProgress = True
                'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
                Bw1.WorkerSupportsCancellation = True
                'Iniciamos el proceso pesado
                Bw1.RunWorkerAsync()

                'Iniciamos el proceso pesado
                Bw2.RunWorkerAsync()


                'txt_Nota.Visible = False
                'btnProcesar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error inesperado, comuniquese con su administrador", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Btn_Buscar_Movimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_Movimiento.Click
        CargarGrid()
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            bodega = cmbBODEGA.SelectedValue
            sugerirMovTransferencia()
            Btn_Buscar_Movimiento.PerformClick()
            pB1.Value = 0
        End If
    End Sub

    Private Sub Inventario_Cierre_Periodo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        'Bw2.RunWorkerAsync()
        'Bw1.ReportProgress(10)
        Dim fin_de_mes = c_data1.leerDataeader("execute sp_INVENTARIOS_CALCULAR_PRIMERO_ULTIMO_DIA_DE_MES '" & Me.NumericUpDown_Mes.Value.Month.ToString & "','" & Me.NumericUpDown_Mes.Value.Year.ToString() & "', 2", 0)
        'If (Convert.ToDateTime(fin_de_mes) <= Date.Now) Then
        'INGRESA EL ENCABEZADO DEL CIERRE        
        'Bw1.ReportProgress(25)
        numero = c_data1.leerDataeader("execute sp_INVENTARIOS_CIERRE " & Txt_tipo_movimiento_numero.Text & ", " & Compañia & ", " & bodega & ", '" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', 1, '" & Usuario & "', 1, 1", 0)
        'Bw1.ReportProgress(100)
    End Sub

    Private Sub Bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw2.DoWork
        While Bw1.IsBusy
            For i As Integer = 0 To 100
                If Bw1.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(500)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    Bw2.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While

        Bw2.ReportProgress(100)
    End Sub

    Private Sub Bw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw2.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub Bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw1.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            If (numero = "1") Then
                MsgBox("Aviso...Existen Salidas pendientes de procesar", MsgBoxStyle.Information)
            End If
            If (numero = "0") Then
                MsgBox("Aviso...El mes ya fue procesado", MsgBoxStyle.Information)
            End If
            If ((numero <> "0") And (numero <> "1")) Then
                MsgBox("Aviso...El Mes fue cerrado con éxito. Fueron procesados " & numero & " productos", MsgBoxStyle.Information)
            End If
            ban = 1
            CargarGrid()
            txt_Nota.Visible = False
            btnProcesar.Enabled = True
            Me.btnRevertir.Enabled = True
        End If
    End Sub

    Private Sub NumericUpDown_Mes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown_Mes.ValueChanged
        pB1.Value = 0
    End Sub

    Private Sub btnRevertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevertir.Click
        Dim result_ As MsgBoxResult

        result_ = MsgBox("Desea Revertir el Cierre para el Periodo " & Me.NumericUpDown_Mes.Text, MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Mensaje de confirmación")
        If result_ = MsgBoxResult.Yes Then        
            'Para la barra de progreso
            pB1.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            BwRevertirCierre.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            BwRevertirCierre.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            BwRevertirCierre.RunWorkerAsync()
            Me.pB1.Enabled = True
            Me.btnRevertir.Enabled = True
        End If
    End Sub

    Private Sub BwRevertirCierre_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwRevertirCierre.DoWork        
        BwRevertirCierre.ReportProgress(25)
        cadena_sql_ = c_data1.leerDataeader("execute sp_INVENTARIOS_REVERTIR_CIERRE " & Compañia & ", " & bodega & ", '" & Format(DateTimePicker1.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "', '" & Format(NumericUpDown_Mes.Value, "dd-MM-yyyy 00:00:01") & "'", 0)
        BwRevertirCierre.ReportProgress(100)
    End Sub

    Private Sub BwRevertirCierre_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwRevertirCierre.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            If cadena_sql_.Equals("Exito") Then
                CargarGrid()
                cadena_sql_ = "Se Efectuó la Reversión Satisfactoriamente..."
            End If
            MsgBox(cadena_sql_, MsgBoxStyle.Information)
        End If
    End Sub
#End Region

    Private Sub dgvMovtos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovtos.CellClick
        Try
            If e.RowIndex > -1 Then
                NumericUpDown_Mes.Value = Date.Parse("01-" & dgvMovtos.Rows(e.RowIndex).Cells(1).Value & "-" & dgvMovtos.Rows(e.RowIndex).Cells(0).Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class