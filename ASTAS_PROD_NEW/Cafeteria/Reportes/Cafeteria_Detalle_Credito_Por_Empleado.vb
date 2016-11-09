Public Class Cafeteria_Detalle_Credito_Por_Empleado
    Dim c_data1 As New jarsClass
    Dim DS01 As New DataSet
    Dim Sql As String
    Dim Iniciando2 As Boolean
    Dim origen As String
    Dim caja As String
    Dim bodega As String
    Dim ban As Integer = 0
    Dim Rpt As New Cafeteria_Reporte_Ventas_Credito_Empleados
    Private Sub Cafeteria_Detalle_Credito_Por_Empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        c_data1.CargaBodegas(Compañia, Me.cmbBODEGA, 9)
        c_data1.CargarCombo(CmbOrigen, "SELECT * FROM COOPERATIVA_CATALOGO_ORIGENES", "ORIGEN", "DESCRIPCION_ORIGEN")
        cargarCajas()
        RadioButton1.Checked = True
        Iniciando = False
    End Sub
    Public Sub cambio()
        origen = Me.CmbOrigen.SelectedValue.ToString
        caja = Me.cmbCajas.SelectedValue.ToString
        bodega = Me.cmbBODEGA.SelectedValue.ToString
    End Sub
    Public Sub cargarCajas()
        Dim a As String = c_data1.leerDataeader("EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=4 , @USUARIO='" & Usuario & "'", 0)
        If (Val(a) = 0) Then
            Me.cmbCajas.DataSource = Nothing
            MsgBox("Aviso...La bodega no tiene caja asignada", MsgBoxStyle.Information)
        Else
            c_data1.CargarCombo(cmbCajas, "EXECUTE sp_CAFETERIA_CATALOGO_BODEGA_CAJA @COMPAÑIA=" & Compañia & ", @BODEGA=" & cmbBODEGA.SelectedValue & ",@BANDERA=5, @USUARIO='" & Usuario & "'", "CAJA", "DESCRIPCION")
            cambio()
        End If
    End Sub

    Public Sub CargaReporte()        
        Try
            DS01.Reset()
            Bw1.ReportProgress(5)
            Dim periodo As String
            If RadioButton1.Checked = True Then
                periodo = "QQ"
            Else
                periodo = "MM"
            End If
            If CheckBox2.Checked = True Then
                Sql = " EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA = " & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=4, @ORIGEN=" & origen & ", @PERIODO=" & periodo & ",@BODEGA=" & bodega & ",@CAJA=0"
            Else
                Sql = " EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA = " & Compañia & " ,@FECHA1='" & Format(DateTimePicker1.Value, "dd-MM-yyyy hh:mm:ss") & "',@FECHA2='" & Format(DateTimePicker2.Value, "dd-MM-yyyy hh:mm:ss") & "', @BANDERA=4, @ORIGEN=" & origen & ", @PERIODO=" & periodo & ",@BODEGA=" & bodega & ",@CAJA=" & caja
            End If
            Bw1.ReportProgress(30)
            c_data1.ejecutaSQLl_llenaDTABLE(Sql)
            Bw1.ReportProgress(55)
            Rpt.SetDataSource(c_data1.ejecutaSQLl_llenaDTABLE(Sql))
            Bw1.ReportProgress(100)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Iniciando = False Then
            'Le indicamos al BackgroundWorker que puede reportar progresos
            Bw1.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            Bw1.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            Bw1.RunWorkerAsync()

            'Le indicamos al BackgroundWorker que puede reportar progresos
            Bw2.WorkerReportsProgress = True
            'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
            Bw2.WorkerSupportsCancellation = True
            'Iniciamos el proceso pesado
            Bw2.RunWorkerAsync()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        Try
            If Iniciando = False Then
                Iniciando2 = True
                cargarCajas()
                cambio()
                Iniciando2 = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Me.cmbBODEGA.Enabled = False
            Me.cmbCajas.Enabled = False
        Else
            Me.cmbBODEGA.Enabled = True
            Me.cmbCajas.Enabled = True
        End If
    End Sub

    Private Sub Bw1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw1.ProgressChanged
        
    End Sub

    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        CargaReporte()
    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCajas.SelectedIndexChanged
        If Iniciando = False Then
            cambio()
        End If        
    End Sub

    Private Sub CmbOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOrigen.SelectedIndexChanged
        If Iniciando = False Then
            cambio()
        End If
    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        Me.crvReporte.ReportSource = Rpt
        pB1.Value = 0
        ban = 1
    End Sub

    Private Sub Bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw2.DoWork
        For i As Integer = 0 To 100
            'Al reportar el progreso, actualizamos el progressBar

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
    End Sub

    Private Sub Bw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw2.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub
End Class