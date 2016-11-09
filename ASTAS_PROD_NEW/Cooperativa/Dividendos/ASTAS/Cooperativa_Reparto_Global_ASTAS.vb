Public Class Cooperativa_Reparto_Global_ASTAS
    Dim Sql As String
    Dim Proc As New jarsClass
    Dim dataset01 As New DataSet()
    Dim dataset02 As New DataSet()
    Dim ban As Integer = 0
    Dim ban1 As Integer = 0
    Dim ban2 As Integer = 0
    Dim ban3 As Integer = 0
    Dim ban4 As Integer = 0
    Dim ban5 As Integer = 0
    Dim Inicio As Boolean = True
    Dim a_repartir, totalExtra As Double
    Dim ciclo As Integer = 0
    Dim Exportar_Excel As New ExportDataExcel

    Delegate Sub CallBackSetText(ByVal texto As String)
    Sub SetText(ByVal texto As String)
        If Me.lbl_Residuo.InvokeRequired Then
            Dim setea As New CallBackSetText(AddressOf SetText)
            Me.Invoke(setea, texto)
        Else
            Me.lbl_Residuo.Text = texto
        End If
    End Sub

    Delegate Sub CallBackSetText1(ByVal texto As String)
    Sub SetText1(ByVal texto As String)
        If Me.Lb_Repartido_Ordinario_Final.InvokeRequired Then
            Dim setea As New CallBackSetText1(AddressOf SetText1)
            Me.Invoke(setea, texto)
        Else
            Me.Lb_Repartido_Ordinario_Final.Text = texto
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Button2.Enabled = False
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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Guardar la utilidad y aportes del mes de " & Me.txtMes.Text & "?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
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

    Private Sub Cooperativa_Reparto_Global_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio = False
        CargarGrid()
        NumericUpDown1.Value = Date.Now.Year
        NumericUpDown4.Value = Date.Now.Year
        NumericUpDown6.Value = Date.Now.Year
        NumericUpDown5.Value = Date.Now.Year
        NumericUpDown9.Value = Date.Now.Year
        Me.txtAño.Value = Date.Now.Year

        NumericUpDown2.Value = 1
        NumericUpDown3.Value = Date.Now.Month
        NumericUpDown7.Value = 1
        NumericUpDown8.Value = Date.Now.Month
        NumericUpDown10.Value = Date.Now.Month        
        Me.dgvRepartos.AutoGenerateColumns = False
        cargarSocios_y_casos_especiales()
        Me.dgvRepartos.DataSource = Proc.obtenerDatos(New SqlClient.SqlCommand("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=26, @ASOCIACION=1"))
        Inicio = True
    End Sub
    Public Sub cargarSocios_y_casos_especiales()
        cargarGridSociosEspeciales()
        cargarCasosEspeciales()
        cargarGridSociosEspecialesEncabezados()
    End Sub
    Public Sub cargarGridSociosEspecialesEncabezados()
        DataGridView2.DataSource = Proc.ObtenerDataSet("EXECUTE sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @COMPAÑIA=" & Compañia & ", @BANDERA=8").Tables(0)
        For i As Integer = 0 To DataGridView2.ColumnCount - 1
            DataGridView2.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub
    Public Sub cargarGridSociosEspeciales()
        DtSocios_Especiales.DataSource = Proc.ObtenerDataSet("EXECUTE sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @COMPAÑIA=" & Compañia & ", @BANDERA=4").Tables(0)
        For i As Integer = 0 To DtSocios_Especiales.ColumnCount - 1
            DtSocios_Especiales.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub
    Public Sub cargarCasosEspeciales()
        dgvCasosEspeciales.DataSource = Proc.ObtenerDataSet("EXECUTE sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @COMPAÑIA=" & Compañia & ", @BANDERA=6, @MES=" & NumericUpDown10.Value & ",@AÑO=" & NumericUpDown9.Value).Tables(0)
        Me.lblRegs.Text = Me.dgvCasosEspeciales.Rows.Count & " Empleados"
        'For i As Integer = 0 To dgvCasosEspeciales.ColumnCount - 1
        '    dgvCasosEspeciales.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Next
    End Sub

    Public Sub CargarGrid()
        DataGridView1.DataSource = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=0, @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value.ToString()).Tables(0)
        For i As Integer = 0 To Me.DataGridView1.Columns.Count - 1
            If i > 1 Then
                Me.DataGridView1.Columns.Item(i).Width = 100
                Me.DataGridView1.Columns.Item(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                Me.DataGridView1.Columns.Item(i).Width = 50
                Me.DataGridView1.Columns.Item(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea hacer el reparto de dividendos Extraordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            lbl_Msj_Repartir_Extra.Visible = True

            pB3.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            cBw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            cBw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            cBw1.RunWorkerAsync()

            cBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            cBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            cBw2.RunWorkerAsync()

            Me.pB3.Enabled = True
        End If
    End Sub
    
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim respuesta As MsgBoxResult
        lbl_Msj_Repartir_Ord.Text = "Repartiendo Ordinario..."
        respuesta = MsgBox("Desea hacer el reparto de dividendos Ordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            a_repartir = Val(lbl_arepartir_Final.Text.Replace(",", ""))
            totalExtra = Val(lbl_Repartido_Extra_Final.Text.Replace(",", ""))
            Me.lbl_Msj_Repartir_Ord.Visible = True
            pB4.Value = 0

            'Le indicamos al BackgroundWorker que puede reportar progresos
            dBw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            dBw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            dBw1.RunWorkerAsync()

            dBw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            dBw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            dBw2.RunWorkerAsync()
            Timer1.Enabled = True
            Me.pB4.Enabled = True
        End If
    End Sub

    Public Sub intervaloFecha(ByVal var As Boolean)
        Me.NumericUpDown1.Enabled = var
        Me.NumericUpDown2.Enabled = var
        Me.NumericUpDown3.Enabled = var
        Me.NumericUpDown4.Enabled = var
        Button5.Enabled = var
        Me.NumericUpDown11.Value = Proc.obtenerEscalar("SELECT MAX(NUMERO_REPARTO) + 1 FROM COOPERATIVA_DIVIDENDOS_GLOBAL WHERE ASOCIACION = 1")
    End Sub
    Public Sub habilitar(ByVal var1 As Boolean)
        GroupBox3.Enabled = var1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea establecer las fechas de incio y fin del reparto?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            Button5.Enabled = False
            pB1.Value = 0
            'Le indicamos al BackgroundWorker que puede reportar progresos
            Bw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            Bw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            Bw1.RunWorkerAsync()

            Bw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            Bw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            Bw2.RunWorkerAsync()

            Me.pB1.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        intervaloFecha(True)
        pB1.Value = 0
        Me.TextBox7.Text = "0.00"
        Me.TextBox9.Text = "0.00"
        Me.TextBox12.Text = "0.00"
        Me.TextBox11.Text = "0.00"
        Me.TextBox16.Text = "0.00"
        Me.TextBox15.Text = "0.00"
        Me.TextBox14.Text = "0.00"
        Me.TextBox13.Text = "0.00"

    End Sub

    Private Sub txtUtilidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilidad.KeyPress
        If (((e.KeyChar >= Microsoft.VisualBasic.ChrW(48)) And (e.KeyChar <= Microsoft.VisualBasic.ChrW(57))) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(46))) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Button1.PerformClick()
        End If
    End Sub
    Public Sub TotalRepartir()
        lbl_arepartir.Text = 0

        For i As Integer = 0 To DataGridView1.RowCount - 1
            lbl_arepartir.Text = Val(lbl_arepartir.Text.Replace(",", "")) + Val(DataGridView1.Rows(i).Cells(8).Value)
        Next
        lbl_arepartir_Final.Text = lbl_arepartir.Text
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim respuesta As MsgBoxResult
            respuesta = MsgBox("Desea Iniciar la reparticion? No podra retroceder", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
            If respuesta = MsgBoxResult.Yes Then
                'Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=9, @AÑO='" & NumericUpDown1.Value.ToString() & "',@MES='" & NumericUpDown2.Value.ToString() & "',@AÑO1='" & NumericUpDown4.Value.ToString() & "',@MES1='" & NumericUpDown3.Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'")
                habilitar(False)
                GroupBox6.Enabled = True
                TotalRepartir()
            End If            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMes.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Button2.Focus()
        End If
    End Sub

    Private Sub txtAño_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAño.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtMes.Focus()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea reajustar el factor Ordinario", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            ciclo = ciclo + 1
            Lbl_Mensaje_Reajustando.Visible = True
            pB4.Value = 0
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

            Me.pB4.Enabled = True
        End If
    End Sub

    Private Sub Bw1_DoWork_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        
        Bw1.ReportProgress(10)
        Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=6, @AÑO='" & NumericUpDown1.Value.ToString() & "',@MES='" & NumericUpDown2.Value.ToString() & "',@AÑO1='" & NumericUpDown4.Value.ToString() & "',@MES1='" & NumericUpDown3.Value.ToString() & "', @USUARIO_CREACION=" & Usuario & ",@USUARIO_EDICION=" & Usuario & ",@ASOCIACION=1,@NUMERO_REPARTO=" & NumericUpDown11.Value)
        Bw1.ReportProgress(85)
        MsgBox("LAS FECHAS DEL REPARTO SE HAN GUARDADO CON EXITO")            
        Bw1.ReportProgress(100)
        
    End Sub

    Private Sub Bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If Bw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                Bw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        Bw2.ReportProgress(100)
        ban = 0
    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else            
            intervaloFecha(False)
            habilitar(True)
            txtAño.Value = NumericUpDown1.Value
            txtMes.Value = NumericUpDown2.Value
            ban = 1
        End If
    End Sub

    Private Sub Bw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw2.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub
    
    Private Sub aBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles aBw1.DoWork
        dataset01 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @FECHA_AHORRO='" & "01/" & Me.txtMes.Value & "/" & Me.txtAño.Value.ToString() & "',@BANDERA=3, @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value.ToString())
        'ordinario ASTAS        
    End Sub

    Private Sub aBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles aBw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            TextBox1.Text = Val(dataset01.Tables(0).Rows(0).Item(0).ToString())
            TextBox6.Text = Val(dataset01.Tables(0).Rows(0).Item(1).ToString())
            TextBox2.Text = Val(dataset01.Tables(0).Rows(0).Item(2).ToString())
            TextBox5.Text = Val(dataset01.Tables(0).Rows(0).Item(3).ToString())
            TextBox3.Text = Val(dataset01.Tables(0).Rows(0).Item(4).ToString())
            TextBox4.Text = dataset01.Tables(0).Rows(0).Item(5).ToString()
            Me.totalHorizontal1.Text = Format(Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text), "$#,##0.00")
            Me.totalHorizontal2.Text = Format(Val(TextBox6.Text) + Val(TextBox5.Text) + Val(TextBox4.Text), "$#,##0.00")
            Me.totalVertical1.Text = Format(Val(TextBox1.Text) + Val(TextBox6.Text), "$#,##0.00")
            Me.totalVertical2.Text = Format(Val(TextBox2.Text) + Val(TextBox5.Text), "$#,##0.00")
            Me.totalVertical3.Text = Format(Val(TextBox3.Text) + Val(TextBox4.Text), "$#,##0.00")
            Button2.Enabled = True
            ban1 = 1
            pB2.Value = 0
        End If        
    End Sub

    Private Sub aBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles aBw2.DoWork
        For i As Integer = 0 To 100

            'Pregunta si está pendiente de cancelación

            If aBw2.CancellationPending Then

                'Si hay cancelacion, cancelamos y terminamos el for

                e.Cancel = True

                Exit For
            End If

            If (ban1 = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                aBw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        aBw2.ReportProgress(100)
        ban1 = 0
    End Sub

    Private Sub aBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles aBw2.ProgressChanged
        pB2.Value = e.ProgressPercentage
    End Sub

    Private Sub bBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bBw1.DoWork
        If Val(txtUtilidad.Text) = 0 Then
            MsgBox("DEBE INGRESAR LA UTILIDAD EN NUMEROS!")
        Else
            If (NumericUpDown2.Value > NumericUpDown3.Value) Or (NumericUpDown1.Value > NumericUpDown4.Value) Then
                MsgBox("EL INTERVALO DESDE DEBE SER MENOR QUE EL HASTA!")
            Else
                Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=5 ,@COMPAÑIA=" & Compañia & ", @AÑO='" & txtAño.Value.ToString() & "', @MES='" & txtMes.Value.ToString() & "', @UTIL_GENER=" & txtUtilidad.Text & ",@FECHA_AHORRO=" & "'01/" & NumericUpDown2.Value.ToString() + "/" + NumericUpDown1.Value.ToString() & "',@FECHA_AHORRO_FINAL='" & "01/" & txtMes.Value.ToString() + "/" + txtAño.Value.ToString() & "',@USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value.ToString())
            End If
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
            CargarGrid()
            If txtMes.Value < 12 Then
                txtMes.Value = txtMes.Value + 1
            Else
                txtMes.Value = 1
            End If
            ban2 = 1

            TextBox1.Text = "0.00"
            TextBox2.Text = "0.00"
            TextBox3.Text = "0.00"
            TextBox4.Text = "0.00"
            TextBox5.Text = "0.00"
            TextBox6.Text = "0.00"
            Me.totalHorizontal1.Text = "0.00"
            Me.totalHorizontal2.Text = "0.00"
            Me.totalVertical1.Text = "0.00"
            Me.totalVertical2.Text = "0.00"
            Me.totalVertical3.Text = "0.00"
            lbl_arepartir.Text = 0

            For i As Integer = 0 To DataGridView1.RowCount - 1
                lbl_arepartir.Text = Val(lbl_arepartir.Text.Replace(",", "")) + Val(DataGridView1.Rows(i).Cells(8).Value)
            Next            
            lbl_arepartir_Final.Text = lbl_arepartir.Text
            pB2.Value = 0
            MsgBox("LOS DATOS DE SALDOS SE GUARDARON EXITOSAMENTE", MsgBoxStyle.Information, "Guardar Datos")
        End If

    End Sub

    Private Sub bBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bBw2.DoWork
        While bBw1.IsBusy
            For i As Integer = 0 To 100
                If bBw1.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(1000)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    bBw2.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While
        'For i As Integer = 0 To 100

        '    'Pregunta si está pendiente de cancelación

        '    If bBw2.CancellationPending Then

        '        'Si hay cancelacion, cancelamos y terminamos el for

        '        e.Cancel = True

        '        Exit For
        '    End If

        '    If (ban2 = 0) Then
        '        'Hacemos una pausa para hacerlo más lento

        '        Threading.Thread.Sleep(300)

        '        'Reportamos que hay progreso donde i es el porcentaje de avance

        '        bBw2.ReportProgress(i)
        '    Else
        '        Exit For
        '    End If
        'Next
        bBw2.ReportProgress(100)
        ban2 = 0
    End Sub

    Private Sub bBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bBw2.ProgressChanged
        pB2.Value = e.ProgressPercentage
    End Sub

 
    Public Sub DatosExtraordinario()
        GroupBox6.Enabled = False
        GroupBox8.Enabled = True
        ban3 = 1
        pB3.Value = 0
        'TOTAL EXTRAORDINARIO REPARTIDO PARA ASTAS
        TextBox9.Text = Val(dataset02.Tables(0).Rows(0).Item(0).ToString())
        'TOTAL EXTRAORDINARIO REPARTIDO PARA EJECUTIVOS
        TextBox12.Text = Val(dataset02.Tables(0).Rows(0).Item(2).ToString())
        'TOTAL EXTRAORDINARIO REPARTIDO PARA PLANILLA GENERAL
        TextBox7.Text = Val(dataset02.Tables(0).Rows(0).Item(4).ToString())

        'SUMATORIA DE EXTRA
        TextBox11.Text = Val(TextBox9.Text.Replace(",", "")) + Val(TextBox12.Text.Replace(",", "")) + Val(TextBox7.Text.Replace(",", ""))

        Me.lbl_arepartir_ord.Text = Val(Me.lbl_arepartir.Text.Replace(",", "")) - Val(TextBox11.Text.Replace(",", ""))
        lbl_Repartido_Extra_Final.Text = TextBox11.Text
        lbl_Msj_Repartir_Extra.Visible = False
    End Sub
    Private Sub cBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles cBw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            DatosExtraordinario()
            MsgBox("SE HA REPARTIDO DIVIDENDOS EXTRAORDINARIOS EXITOSAMENTE")
        End If
    End Sub

    Private Sub dBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles dBw1.DoWork
        Dim poneTexto As New CallBackSetText(AddressOf SetText)
        Dim poneTexto1 As New CallBackSetText1(AddressOf SetText1)
        Dim totalOrdinario As Double = 0
        Try
            While a_repartir - totalExtra - totalOrdinario > 0.1
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    If dBw1.CancellationPending Then
                        e.Cancel = True
                        Exit Sub
                    End If
                    Sql = "INSERT INTO COOPERATIVA_SOCIO_AHORROS_HISTORIAL_ACTIVOS" & vbCrLf
                    Sql &= "SELECT * FROM COOPERATIVA_SOCIO_AHORROS WHERE CODIGO_EMPLEADO IN (SELECT CODIGO_EMPLEADO FROM COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES)" & vbCrLf
                    Sql &= "" & vbCrLf
                    Sql &= "DELETE FROM COOPERATIVA_SOCIO_AHORROS WHERE CODIGO_EMPLEADO IN (SELECT CODIGO_EMPLEADO FROM COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES)" & vbCrLf
                    Proc.ejecutarComandoSql(New SqlClient.SqlCommand(Sql))

                    Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=7, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "',@ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value.ToString())

                    Sql = "INSERT INTO COOPERATIVA_SOCIO_AHORROS" & vbCrLf
                    Sql &= "SELECT * FROM COOPERATIVA_SOCIO_AHORROS_HISTORIAL_ACTIVOS WHERE CODIGO_EMPLEADO IN (SELECT CODIGO_EMPLEADO FROM COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES)" & vbCrLf
                    Sql &= "" & vbCrLf
                    Sql &= "DELETE FROM COOPERATIVA_SOCIO_AHORROS_HISTORIAL_ACTIVOS WHERE CODIGO_EMPLEADO IN (SELECT CODIGO_EMPLEADO FROM COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES)" & vbCrLf
                    Proc.ejecutarComandoSql(New SqlClient.SqlCommand(Sql))
                Next
                dataset02 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=20, @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'" & ", @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value)
                totalOrdinario = Val(dataset02.Tables(0).Rows(0).Item(1).ToString()) + Val(dataset02.Tables(0).Rows(0).Item(3).ToString()) + Val(dataset02.Tables(0).Rows(0).Item(5).ToString())
                poneTexto(Format(a_repartir - totalExtra - totalOrdinario, "0.00"))
                poneTexto1(Format(totalOrdinario, "0.00"))
                If a_repartir - totalExtra - totalOrdinario > 0.1 Then
                    For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                        Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=8, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1,@NUMERO_REPARTO=" & NumericUpDown11.Value)
                    Next
                End If
                ciclo = ciclo + 1
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles cBw2.DoWork
        While cBw1.IsBusy
            For i As Integer = 0 To 100000

                'Pregunta si está pendiente de cancelación

                If cBw2.CancellationPending Then

                    'Si hay cancelacion, cancelamos y terminamos el for

                    e.Cancel = True

                    Exit For
                End If

                If (ban3 = 0) Then
                    'Hacemos una pausa para hacerlo más lento

                    Threading.Thread.Sleep(1000)

                    'Reportamos que hay progreso donde i es el porcentaje de avance

                    cBw2.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
        End While
        cBw2.ReportProgress(100)
        ban3 = 0

    End Sub

    Private Sub cBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles cBw2.ProgressChanged
        Try
            pB3.Value = e.ProgressPercentage
        Catch ex As Exception

        End Try        
    End Sub
    Public Sub DatosOrdinarios()
        Button8.Enabled = True
        ban4 = 1
        pB4.Value = 0
        'TOTAL ORDINARIO REPARTIDO PARA ASTAS
        TextBox16.Text = Val(dataset02.Tables(0).Rows(0).Item(1).ToString())
        'TOTAL ORDINARIO REPARTIDO PARA EJECUTIVOS
        TextBox15.Text = Val(dataset02.Tables(0).Rows(0).Item(3).ToString())
        'TOTAL ORDINARIO REPARTIDO PARA PLANILLA GENERAL
        TextBox14.Text = Val(dataset02.Tables(0).Rows(0).Item(5).ToString())

        'SUMATORIA DE ORDINARIO
        TextBox13.Text = Val(TextBox16.Text.Replace(",", "")) + Val(TextBox15.Text.Replace(",", "")) + Val(TextBox14.Text.Replace(",", ""))

        Lb_Repartido_Ordinario_Final.Text = TextBox13.Text
        lbl_Residuo.Text = (Math.Round(Val(lbl_arepartir_Final.Text.Replace(",", "")) - (Val(lbl_Repartido_Extra_Final.Text.Replace(",", "")) + Val(Lb_Repartido_Ordinario_Final.Text.Replace(",", ""))), 2)).ToString()
        Me.lbl_Msj_Repartir_Ord.Visible = False        
    End Sub
    Private Sub dBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles dBw1.RunWorkerCompleted
        Try
            If e.Cancelled Then
                'Se muestra si fue cancelado manualmente
                MsgBox("SE CANCELO EL PROCESO")
            Else
                DatosOrdinarios()
                'If Val(Me.lbl_Residuo) > 1 Then
                '    Me.Button8.PerformClick()
                'Else
                MsgBox("SE HA REPARTIDO DIVIDENDOS ORDINARIOS EXITOSAMENTE")
                'End If
            End If
        Catch ex As Exception
            MsgBox("HA OCURRIDO UN PROBLEMA")
        End Try
        Timer1.Enabled = False
    End Sub

    Private Sub dBw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles dBw2.DoWork
        While dBw1.IsBusy
            For i As Integer = 0 To 100
                If dBw1.IsBusy Then
                    'Hacemos una pausa para hacerlo más lento
                    Threading.Thread.Sleep(1000)
                    'Reportamos que hay progreso donde i es el porcentaje de avance
                    dBw2.ReportProgress(i)
                Else
                    Exit For
                End If
            Next
            'For i As Integer = 0 To 10000000

            '    'Pregunta si está pendiente de cancelación

            '    If dBw2.CancellationPending Then

            '        'Si hay cancelacion, cancelamos y terminamos el for

            '        e.Cancel = True

            '        Exit For
            '    End If

            '    If (ban4 = 0) Then
            '        'Hacemos una pausa para hacerlo más lento

            '        Threading.Thread.Sleep(10000)

            '        'Reportamos que hay progreso donde i es el porcentaje de avance

            '        dBw2.ReportProgress(i)
            '    Else
            '        Exit For
            '    End If
            'Next
        End While
        dBw2.ReportProgress(100)
        ban4 = 0
    End Sub

    Private Sub dBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles dBw2.ProgressChanged
        Try
            pB4.Value = e.ProgressPercentage
        Catch ex As Exception

        End Try        
    End Sub

    Private Sub eBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles eBw1.DoWork        
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=8, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1,@NUMERO_REPARTO=" & NumericUpDown11.Value)
        Next
    End Sub

    Private Sub eBw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles eBw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else            
            ban5 = 1
            ban4 = 1
            pB4.Value = 0
            Me.TextBox16.Text = "0.00"
            Me.TextBox15.Text = "0.00"
            Me.TextBox14.Text = "0.00"
            Me.TextBox13.Text = "0.00"
            Lb_Repartido_Ordinario_Final.Text = "0.00"
            MsgBox("FACTOR RECALCULADO, DEBE REALIZAR EL REPARTO DE ORDINARIO NUEVAMENTE!")
            lbl_Residuo.Text = "0.00"
            Lbl_Mensaje_Reajustando.Visible = False
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

            If (ban5 = 0) Then
                'Hacemos una pausa para hacerlo más lento

                Threading.Thread.Sleep(300)

                'Reportamos que hay progreso donde i es el porcentaje de avance

                eBw2.ReportProgress(i)
            Else
                Exit For
            End If
        Next
        eBw2.ReportProgress(100)
        ban5 = 0
    End Sub

    Private Sub eBw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles eBw2.ProgressChanged
        pB4.Value = e.ProgressPercentage
    End Sub

    Private Sub cBw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles cBw1.DoWork
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=4, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value)
        Next
        dataset02 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=20, @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'" & ", @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value)
    End Sub

    
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim Rpt As New Cooperativa_Reporte_Global_3
        ReporteGlobales(Rpt)
        GroupBox8.Enabled = False
    End Sub
    Public Sub ReporteGlobales(ByVal Rpt As Object)
        Try
            Dim DS01 As New DataSet()
            Proc.MiddleConnection("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=12 ,@COMPAÑIA=" & Compañia & ", @AÑO='" & NumericUpDown1.Value.ToString() & "', @AÑO1='" & NumericUpDown4.Value.ToString() & "', @MES='" & NumericUpDown2.Value.ToString() & "',@MES1='" & NumericUpDown3.Value.ToString() & "',@USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "', @ASOCIACION=1,@NUMERO_REPARTO=" & NumericUpDown11.Value)
            Proc.DataAdapter.Fill(DS01)
            Rpt.SetDataSource(DS01.Tables(0))
            Dim rptver As New frmReportes_Ver
            rptver.ReportesGenericos(Rpt)
            rptver.ShowDialog()
        Catch
            MsgBox("AVISO")
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Eliminar el reparto de dividendos Ordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=21, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'")
            Next
            dataset02 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=20, @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'")
            'TOTAL ORDINARIO REPARTIDO PARA ASTAS
            TextBox16.Text = Val(dataset02.Tables(0).Rows(0).Item(1).ToString())
            'TOTAL ORDINARIO REPARTIDO PARA EJECUTIVOS
            TextBox15.Text = Val(dataset02.Tables(0).Rows(0).Item(3).ToString())
            'TOTAL ORDINARIO REPARTIDO PARA PLANILLA GENERAL
            TextBox14.Text = Val(dataset02.Tables(0).Rows(0).Item(5).ToString())
            'SUMATORIA DE ORDINARIO
            TextBox13.Text = Val(TextBox16.Text.Replace(",", "")) + Val(TextBox15.Text.Replace(",", "")) + Val(TextBox14.Text.Replace(",", ""))
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea Eliminar el reparto de dividendos Extraordinario?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=21, @AÑO='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "',@AÑO1='" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "',@MES1='" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "', @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'")
            Next
            dataset02 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=20, @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'")
            'TOTAL EXTRAORDINARIO REPARTIDO PARA ASTAS
            TextBox9.Text = Val(dataset02.Tables(0).Rows(0).Item(0).ToString())
            'TOTAL EXTRAORDINARIO REPARTIDO PARA EJECUTIVOS
            TextBox12.Text = Val(dataset02.Tables(0).Rows(0).Item(2).ToString())
            'TOTAL EXTRAORDINARIO REPARTIDO PARA PLANILLA GENERAL
            TextBox7.Text = Val(dataset02.Tables(0).Rows(0).Item(4).ToString())
            'SUMATORIA DE EXTRA
            TextBox11.Text = Val(TextBox9.Text.Replace(",", "")) + Val(TextBox12.Text.Replace(",", "")) + Val(TextBox7.Text.Replace(",", ""))

            Me.lbl_arepartir_ord.Text = Val(Me.lbl_arepartir.Text.Replace(",", "")) - Val(TextBox11.Text.Replace(",", ""))
            lbl_Repartido_Extra_Final.Text = TextBox11.Text
            lbl_Msj_Repartir_Extra.Visible = False
        End If
    End Sub

    
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim saldo, saldo_ord As String
        For i As Integer = 0 To DtSocios_Especiales.RowCount - 1
            If i = 0 Then
                saldo = 0
                saldo_ord = 0
                Proc.Ejecutar_ConsultaSQL("EXEC sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @BANDERA=5," & "@CODIGO_EMPLEADO=" & DtSocios_Especiales.Rows(i).Cells(0).Value.ToString() & ",@FECHA='" & Format(DtSocios_Especiales.Rows(i).Cells(3).Value, "dd/MM/yyyy") & "', @AHORRO=" & DtSocios_Especiales.Rows(i).Cells(12).Value.ToString() & ",@SALDO_EXTRA=" & saldo & ", @SALDO_ORD=" & saldo_ord)
            Else
                If DtSocios_Especiales.Rows(i).Cells(0).Value.ToString() = DtSocios_Especiales.Rows(i - 1).Cells(0).Value.ToString() Then
                    saldo = DtSocios_Especiales.Rows(i).Cells(4).Value + DtSocios_Especiales.Rows(i - 1).Cells(5).Value
                    saldo_ord = DtSocios_Especiales.Rows(i).Cells(6).Value + DtSocios_Especiales.Rows(i - 1).Cells(7).Value
                    Proc.Ejecutar_ConsultaSQL("EXEC sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @BANDERA=5," & "@CODIGO_EMPLEADO=" & DtSocios_Especiales.Rows(i).Cells(0).Value.ToString() & ",@FECHA='" & Format(DtSocios_Especiales.Rows(i).Cells(3).Value, "dd/MM/yyyy") & "', @AHORRO=" & DtSocios_Especiales.Rows(i).Cells(12).Value.ToString() & ",@SALDO_EXTRA=" & saldo & ", @SALDO_ORD=" & saldo_ord)
                Else
                    saldo = 0
                    saldo_ord = 0
                    Proc.Ejecutar_ConsultaSQL("EXEC sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @BANDERA=5," & "@CODIGO_EMPLEADO=" & DtSocios_Especiales.Rows(i).Cells(0).Value.ToString() & ",@FECHA='" & Format(DtSocios_Especiales.Rows(i).Cells(3).Value, "dd/MM/yyyy") & "', @AHORRO=" & DtSocios_Especiales.Rows(i).Cells(12).Value.ToString() & ",@SALDO_EXTRA=" & saldo & ", @SALDO_ORD=" & saldo_ord)
                End If
            End If
            cargarGridSociosEspeciales()
        Next
    End Sub

    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        Me.NumericUpDown9.Value = Me.NumericUpDown5.Value
        Me.NumericUpDown4.Value = Me.NumericUpDown5.Value
    End Sub

    Private Sub NumericUpDown8_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown8.ValueChanged
        Me.NumericUpDown10.Value = Me.NumericUpDown8.Value
        Me.NumericUpDown3.Value = Me.NumericUpDown8.Value
    End Sub

    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown6.ValueChanged
        Me.NumericUpDown1.Value = Me.NumericUpDown6.Value        
    End Sub

    Private Sub NumericUpDown7_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown7.ValueChanged
        Me.NumericUpDown2.Value = Me.NumericUpDown7.Value
    End Sub

    Private Sub NumericUpDown9_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown9.ValueChanged
        If Inicio = False Then
            cargarGridSociosEspecialesEncabezados()
        End If
    End Sub

    Private Sub NumericUpDown10_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown10.ValueChanged
        If Inicio = False Then
            cargarGridSociosEspecialesEncabezados()
        End If
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        cargarCasosEspeciales()
        Me.chkSelec.Checked = False
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        'Dim respuesta As MsgBoxResult

        For i As Integer = 0 To dgvCasosEspeciales.RowCount - 1
            Try
                If dgvCasosEspeciales.Rows(i).Cells(0).Value Then
                    'respuesta = MsgBox("Desea completar los registros con cuotas 0 para el empleado " & dgvCasosEspeciales.Rows(i).Cells(2).Value.ToString() & " ?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
                    'If respuesta = MsgBoxResult.Yes Then
                    Proc.Ejecutar_ConsultaSQL("execute sp_COOPERATIVA_DIVIDENDOS_SOCIOS_ESPECIALES @COMPAÑIA=" & Compañia & ", @CODIGO_EMPLEADO=" & dgvCasosEspeciales.Rows(i).Cells(1).Value.ToString() & ", @FECHA='" & Format(dgvCasosEspeciales.Rows(i).Cells(3).Value, "dd/MM/yyyy") & "',@MES=" & NumericUpDown10.Value & ", @AÑO=" & NumericUpDown9.Value & ", @BANDERA=9")
                    'End If
                End If
            Catch ex As Exception
                Exit For
            End Try
        Next
        Me.chkSelec.Checked = False
        cargarCasosEspeciales()
    End Sub


    Private Sub NumericUpDown11_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown11.ValueChanged
        CargarGrid()
        dataset02 = Proc.ObtenerDataSet("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=20, @USUARIO_CREACION='" & Usuario & "',@USUARIO_EDICION='" & Usuario & "'" & ", @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value)
        TotalRepartir()
        DatosExtraordinario()        
        DatosOrdinarios()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        cargarSocios_y_casos_especiales()
        TabPage3.Focus()
        Me.TabControl1.SelectedIndex = 1
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        TabPage6.Focus()
        Me.TabControl1.SelectedIndex = 2
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        TabPage1.Focus()
        Me.TabControl1.SelectedIndex = 3
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        cargarSocios_y_casos_especiales()
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Dim respuesta As MsgBoxResult
        respuesta = MsgBox("Desea eliminar este registro de mes?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Mensaje de confirmacion")
        If respuesta = MsgBoxResult.Yes Then
            Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=25 ,@COMPAÑIA=" & Compañia & ", @AÑO='" & DataGridView1.CurrentRow.Cells.Item(0).Value.ToString() & "', @MES='" & DataGridView1.CurrentRow.Cells.Item(1).Value.ToString() & "', @ASOCIACION=1, @NUMERO_REPARTO=" & NumericUpDown11.Value.ToString())
            CargarGrid()
        End If        
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim fecha2 As Date
            Dim jClass As New jarsClass
            fecha2 = jClass.obtenerEscalar("select MAX(FECHA_2) from [dbo].[COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO] where NUMERO_REPARTO = " & Me.NumericUpDown11.Value.ToString & " and ASOCIACION = 1")
            lbl_Msj_Repartir_Ord.Text = "Repartiendo Ordinario..." & IIf(ciclo = 0, " ->", " AJUSTE: " & ciclo.ToString & " ->") & " MES EN PROCESO: " & IIf(Month(fecha2) = Me.NumericUpDown3.Value, Month(fecha2).ToString.PadLeft(2, "0"), (Month(fecha2) + 1).ToString.PadLeft(2, "0"))
        Catch ex As Exception
            'MsgBox(ex.Message)
            lbl_Msj_Repartir_Ord.Text = "Repartiendo Ordinario..." & IIf(ciclo = 0, " ->", " AJUSTE: " & ciclo.ToString & " ->") & " MES EN PROCESO: " & Me.NumericUpDown2.Value.ToString.PadLeft(2, "0")
        End Try
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If MsgBox("Está seguro de eliminar el reparto #" & Me.NumericUpDown11.Value, MsgBoxStyle.OkCancel, "Se Eliminarán todos los datos") = MsgBoxResult.Ok Then
            Sql = "DELETE FROM [dbo].[COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO_EXT] WHERE NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " and ASOCIACION = 1" & vbCrLf
            Sql &= "DELETE FROM [dbo].[COOPERATIVA_DETALLE_DIVIDENDOS_POR_SOCIO] WHERE NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " and ASOCIACION = 1" & vbCrLf
            Sql &= "DELETE FROM [dbo].[COOPERATIVA_DIVIDENDOS_CONSTANTES] WHERE NUMERO_REPARTO = " & Me.NumericUpDown11.Value & " and ASOCIACION = 1" & vbCrLf
            Sql &= "DELETE FROM [dbo].[COOPERATIVA_DIVIDENDOS_GLOBAL] WHERE ASOCIACION = 1 AND NUMERO_REPARTO = " & Me.NumericUpDown11.Value & vbCrLf
            Proc.Ejecutar_ConsultaSQL(Sql)
            CargarGrid()
            ciclo = 0
            Me.TextBox7.Text = "0.00"
            Me.TextBox9.Text = "0.00"
            Me.TextBox12.Text = "0.00"
            Me.TextBox11.Text = "0.00"
            Me.TextBox16.Text = "0.00"
            Me.TextBox15.Text = "0.00"
            Me.TextBox14.Text = "0.00"
            Me.TextBox13.Text = "0.00"
            Me.lbl_arepartir.Text = "0.00"
            Me.lbl_arepartir_ord.Text = "0.00"
            Me.lbl_arepartir_Final.Text = "0.00"
            Me.lbl_Repartido_Extra_Final.Text = "0.00"
            Me.Lb_Repartido_Ordinario_Final.Text = "0.00"
            Me.lbl_Residuo.Text = "0.00"
        End If
    End Sub

    Private Sub chkSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelec.CheckedChanged
        For i As Integer = 0 To Me.dgvCasosEspeciales.Rows.Count - 1
            Me.dgvCasosEspeciales.Rows(i).Cells(0).Value = Me.chkSelec.Checked
        Next
        If Me.chkSelec.Checked Then
            Me.chkSelec.Text = "Deseleccionar Todos"
        Else
            Me.chkSelec.Text = "Seleccionar Todos"
        End If
    End Sub

    Private Sub txtCancReparto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCancReparto.Click
        dBw1.CancelAsync()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Exportar_Excel.ExportarDatosExcel(Me.dgvRepartos, "REPARTOS REALIZADOS")
    End Sub

    Private Sub dgvRepartos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRepartos.CellContentClick

    End Sub
End Class