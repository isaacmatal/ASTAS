Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel
Public Class FrmManAportesElecutivos
    Dim Sql As String
    Dim SqlCmd As New SqlCommand
    Dim Iniciando As Boolean
    Dim Proc As New jarsClass
    Dim ban As Integer = 0
    Dim Origen As Integer = 0
    Private Sub FrmManAportesElecutivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCompañia.Text = Descripcion_Compañia
        Proc.CargarCombo(Me.CmbOrigenes, "SELECT ORIGEN,DESCRIPCION_ORIGEN FROM COOPERATIVA_CATALOGO_ORIGENES WHERE COMPAÑIA=" & Compañia, "ORIGEN", "DESCRIPCION_ORIGEN")
        TextBox1.Text = "Hoja1"
        Origen = CmbOrigenes.SelectedValue
        Iniciando = False
    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Instanciamos nuestro cuadro de dialogo
        Dim openFileDialog1 As New OpenFileDialog
        'Directorio Predeterminado
        openFileDialog1.InitialDirectory = "C:\"
        'Filtramos solo archivos con extension *.xls
        openFileDialog1.Filter = "Archivos de Microsoft Office Excel (*.xls)|*.xls"

        'Si se presiona abrir entonces...
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Asignamos la ruta donde se almacena el fichero excel que se va a importar
            TextBox1.Text = openFileDialog1.FileName

            'Instanciamos nuestra cadena de conexion especial para excel,indicando la ruta del fichero
            Dim cadconex As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.TextBox1.Text.Trim & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
            Dim cn As New OleDb.OleDbConnection(cadconex)
            Dim cmd As New OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            cmd.Connection = cn
            'Consultamos la hoja llamada Clientes de nuestro archivo *.xls
            If TextBox1.Text = "" Then
                MsgBox("DEBE SELECCIONAR EL ARCHIVO DE EXCEL")
                Exit Sub
            End If

            cmd.CommandText = "select * from [Hoja1$]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            'Llenamos el datatable
            da.Fill(dt)
            'Llenamos el Datagridview
            Me.DataGridView1.DataSource = dt
            'Ajustamos las columnas del DataGridView
            DataGridView1.AutoSizeColumnsMode = 6
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Cuantos As Integer
        If DataGridView1.Columns.Count >= 6 Then
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If IsDBNull(DataGridView1.Rows(i).Cells(0).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(2).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(3).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(4).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(5).Value) Then
                    Me.ListBox1.Items.Add("LA FILA: " & (i + 1).ToString() & " CONTIENE UN CAMPO VACIO")
                Else
                    If (Val(DataGridView1.Rows(i).Cells(0).Value) >= 0) Then
                        If (IsDate(DataGridView1.Rows(i).Cells(2).Value) = True) Then
                            If (Val(DataGridView1.Rows(i).Cells(3).Value) >= 0) Then
                                Cuantos = CInt(Proc.obtenerEscalar("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ", @BANDERA=1, @CODIGO_EMPLEADO=" & DataGridView1.Rows(i).Cells(0).Value.ToString() & ", @ORIGEN=" & CmbOrigenes.SelectedValue & ",@FECHA_AHORRO='" & DataGridView1.Rows(i).Cells(2).Value.ToString() & "', @PORCENTAJE=" & DataGridView1.Rows(i).Cells(3).Value.ToString() & ", @CUOTA_ORD=" & DataGridView1.Rows(i).Cells(4).Value.ToString() & ",@CUOTA_EXT=" & DataGridView1.Rows(i).Cells(5).Value.ToString()))
                                If Cuantos = 0 Then
                                    Me.ListBox1.Items.Add(DataGridView1.Rows(i).Cells(1).Value & "No existe empleado")
                                End If
                            Else
                                MsgBox("LA FILA: " & (i + 1).ToString() & " CONTIENE UN ERROR DE PORCENTAJE")
                                Exit Sub
                            End If
                            Else
                                MsgBox("LA FILA: " & (i + 1).ToString() & " CONTIENE UN ERROR DE FECHA")
                                Exit Sub
                            End If
                    Else
                        MsgBox("LA FILA: " & (i + 1).ToString() & " CONTIENE UN ERROR DE CODIGO BUXIS")
                        Exit Sub
                    End If
                End If
            Next
            MsgBox("VERIFIQUE LOS DETALLES AL LADO DERECHO DE ESTA VENTANA")
        End If

    End Sub
  
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.ListBox1.Items.Clear()
        Me.DataGridView1.DataSource = Nothing
        Button4.Enabled = True
        Label2.Visible = False
        pB1.Value = 0
    End Sub

    Private Sub CmbOrigenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOrigenes.SelectedIndexChanged
        Me.ListBox1.Items.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.Enabled = False
        Label2.Visible = True
        Origen = Val(CmbOrigenes.SelectedValue.ToString())
        'Le indicamos al BackgroundWorker que puede reportar progresos
        Bw1.WorkerReportsProgress = True
        'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
        Bw1.WorkerSupportsCancellation = True
        'Iniciamos el proceso pesado
        Bw1.RunWorkerAsync()

        pB1.Value = 0
        Bw2.WorkerReportsProgress = True
        'Le decimos al BackgroundWorker que puede ser cancelado en cualquier momento
        Bw2.WorkerSupportsCancellation = True
        'Iniciamos el proceso pesado
        Bw2.RunWorkerAsync()

        Me.pB1.Enabled = True

    End Sub

    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw1.DoWork
        Try
            
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If IsDBNull(DataGridView1.Rows(i).Cells(0).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(2).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(3).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(4).Value) Or IsDBNull(DataGridView1.Rows(i).Cells(5).Value) Then
                    MsgBox("LA FILA:" & i & " CONTIENE UN CAMPO VACIO, NO SE CARGO EN LA BASE")
                Else
                    Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @COMPAÑIA=" & Compañia & ",@BANDERA=2, @CODIGO_EMPLEADO=" & DataGridView1.Rows(i).Cells(0).Value.ToString() & ", @ORIGEN=" & Origen & ",@FECHA_AHORRO='" & DataGridView1.Rows(i).Cells(2).Value.ToString() & "', @PORCENTAJE=" & DataGridView1.Rows(i).Cells(3).Value.ToString() & ", @CUOTA_ORD=" & DataGridView1.Rows(i).Cells(4).Value.ToString() & ",@CUOTA_EXT=" & DataGridView1.Rows(i).Cells(5).Value.ToString() & ",@USUARIO=" & Usuario)
                    Bw1.ReportProgress(i)
                End If
            Next

            MsgBox("INFORMACION ENVIADA CON EXITO")
        Catch ex As Exception
            MsgBox("NO SE ENVIO LA INFORMACION")
        End Try
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
    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw1.RunWorkerCompleted
        If e.Cancelled Then
            'Se muestra si fue cancelado manualmente
            MsgBox("SE CANCELO EL PROCESO")
        ElseIf e.Error IsNot Nothing Then
            'Se muestra, si fue cancelado debido a un error
            MsgBox("OCURRIO UN ERROR")
        Else
            ban = 1
            Label2.Visible = False
        End If
    End Sub


    Private Sub Bw2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw2.ProgressChanged
        pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Me.DataGridView1.DataSource = Proc.ejecutaSQLl_llenaDTABLE("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=13, @USUARIO=" & Usuario & ", @FECHA_AHORRO='" & Me.DateTimePicker1.Text.ToString() & "',@FECHA_AHORRO_FINAL='" & Me.DateTimePicker2.Text.ToString() & "', @ORIGEN=" & CmbOrigenes.SelectedValue.ToString())
        Catch ex As Exception
            MsgBox("NO SE HA PODIDO CARGAR EL DETALLE DE AHORROS")
        End Try        
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MsgBox("¿Está seguro que desea Eliminar detalle de ahorro? Esta accion es irreversible!", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
            Try
                Proc.Ejecutar_ConsultaSQL("EXECUTE sp_INGRESO_PLANILLA_ESPECIAL_AHORROS @BANDERA=14, @USUARIO=" & Usuario & ", @FECHA_AHORRO='" & Me.DateTimePicker1.Text.ToString() & "',@FECHA_AHORRO_FINAL='" & Me.DateTimePicker2.Text.ToString() & "', @ORIGEN=" & CmbOrigenes.SelectedValue.ToString())
                Button3.PerformClick()
                MsgBox("SE HA ELIMINADO EL DETALLE DE AHORROS")
            Catch ex As Exception
                MsgBox("NO SE HA PODIDO ELIMINAR EL DETALLE DE AHORROS")
            End Try
        End If
        
    End Sub

    Private Sub FrmManAportesElecutivos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        'Dim LinearBrush As Drawing2D.LinearGradientBrush = _
        '       New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
        '       Drawing2D.LinearGradientMode.Vertical)
        'Dim g As Graphics = e.Graphics
        'g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class