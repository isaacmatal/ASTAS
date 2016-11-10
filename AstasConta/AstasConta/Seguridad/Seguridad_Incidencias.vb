Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Seguridad_Incidencias
    Dim c_data1 As New jarsClass
    Dim sql As String

    Private Sub Seguridad_Incidencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Usuario
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        Me.DataGridView1.DataSource = c_data1.ejecutaSQLl_llenaDTABLE("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='S'")

        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" Then
            If TextBox3.Text <> "" Then
                c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO='" & Usuario & "', @BANDERA='I', @CLASE='" & ComboBox1.SelectedItem.ToString() & "',@PRIORIDAD='" & ComboBox2.SelectedItem.ToString() & "', @TITULO='" & TextBox2.Text & "', @DESCRIPCION='" & TextBox3.Text & "', @ESTADO='REPORTADO'")

                Me.DataGridView1.DataSource = c_data1.ejecutaSQLl_llenaDTABLE("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='S'")

                For i As Integer = 0 To DataGridView1.ColumnCount - 1
                    DataGridView1.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
                MsgBox("REPORTADO! ESPERE EL SOPORTE")
                Button2.PerformClick()
            Else
                MsgBox("No ha escrito ninguna descripcion")
            End If
        Else
            MsgBox("No ha escrito el titulo")
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = Usuario
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02, DS03, DS04 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Dim arrFilename() As String = Split(Text, "\")
        Array.Reverse(arrFilename)

        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer

        Dim ms1 As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage1() As Byte = ms1.GetBuffer

        Dim ms2 As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage2() As Byte = ms2.GetBuffer

        Dim ms3 As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage3() As Byte = ms3.GetBuffer

        Dim ms4 As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage4() As Byte = ms4.GetBuffer

        OpenConnection()
        Comando_Track = New SqlCommand("UPDATE SEGURIDAD_INCIDENCIAS_IMAGENES SET IMAGEN1=@IMAGEN1, IMAGEN2=@IMAGEN2, IMAGEN3=@IMAGEN3,IMAGEN4=@IMAGEN4, IMAGEN5=@IMAGEN5 WHERE  COMPAÑIA=1 AND ITEM=@ITEM", Conexion_Track)
        With Comando_Track
            .Parameters.Add(New SqlParameter("@ITEM", SqlDbType.Int)).Value = Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value.ToString())
            .Parameters.Add(New SqlParameter("@IMAGEN1", SqlDbType.Image)).Value = arrImage
            .Parameters.Add(New SqlParameter("@IMAGEN2", SqlDbType.Image)).Value = arrImage1
            .Parameters.Add(New SqlParameter("@IMAGEN3", SqlDbType.Image)).Value = arrImage2
            .Parameters.Add(New SqlParameter("@IMAGEN4", SqlDbType.Image)).Value = arrImage3
            .Parameters.Add(New SqlParameter("@IMAGEN5", SqlDbType.Image)).Value = arrImage4
        End With
        Comando_Track.ExecuteNonQuery()
        CloseConnection()
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        With OpenFileDialog1
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox1
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
                Me.Button8.Enabled = True
            End With
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        TextBox9.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        With OpenFileDialog1
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox2
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
                Me.Button8.Enabled = True

            End With
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        With OpenFileDialog1
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox3
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
                Me.Button8.Enabled = True

            End With
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        With OpenFileDialog1
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox4
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
                Me.Button8.Enabled = True

            End With
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        With OpenFileDialog1
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Filter = "Excel 93-2003|*.xls|Excel 2010|*.xlsx"
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim Conexion_Excel As New OleDbConnection
            Dim Comando_Excel As New OleDbCommand
            Dim DataAdapter_Excel As New OleDbDataAdapter
            Dim Table As New DataTable
            Dim CadenaCnn As String
            Dim CarAbo As String = String.Empty, sql As String
            Dim Valor As Decimal = 0
            Dim _error_ As Boolean = False
            Try
                'CadenaCnn = "Provider=Microsoft.Jet.Oledb.4.0; data source= " + Me.lblArchivoExcel.Text + " ;Extended properties=Excel 8.0;"
                CadenaCnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" & OpenFileDialog1.FileName & """;Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
                Conexion_Excel = New OleDbConnection(CadenaCnn)
                Conexion_Excel.Open()
                'Inserta Líneas de Partida en "CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO"
                sql = "SELECT * FROM [PROVEEDORES$]"
                Comando_Excel = New OleDbCommand(Sql, Conexion_Excel)
                DataAdapter_Excel.SelectCommand = Comando_Excel
                DataAdapter_Excel.Fill(Table)
                Conexion_Excel.Close()
                Conexion_Excel.Dispose()
                If Table.Rows.Count = 0 Then
                    MsgBox("¡El archivo de Excel está vacío! Verifique...", MsgBoxStyle.Critical, "Archivo Excel")
                    Return
                End If
                Me.DataGridView1.DataSource = Table
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error Carga Excel")
                _error_ = True
            Finally
                Conexion_Excel.Close()
                Conexion_Excel.Dispose()
            End Try
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If CInt(Me.DataGridView1.Rows(i).Cells("PAGADO").Value) = 1 Then
                sql = "INSERT INTO [dbo].[CONTABILIDAD_ORDEN_COMPRA_CHEQUES_PAGOS_EFECTUADOS]" & vbCrLf
                sql &= "           ([COMPAÑIA]" & vbCrLf
                sql &= "           ,[ORDEN_COMPRA]" & vbCrLf
                sql &= "           ,[BODEGA]" & vbCrLf
                sql &= "           ,[CHEQUE]" & vbCrLf
                sql &= "           ,[TOTAL_PAGADO]" & vbCrLf
                sql &= "           ,[TIPO_DOCUMENTO]" & vbCrLf
                sql &= "           ,[DOCUMENTO]" & vbCrLf
                sql &= "           ,[BANCO]" & vbCrLf
                sql &= "           ,[CUENTA_BANCARIA]" & vbCrLf
                sql &= "           ,[LIBRO_CONTABLE]" & vbCrLf
                sql &= "           ,[CUENTA]" & vbCrLf
                sql &= "           ,[FECHA_PAGO]" & vbCrLf
                sql &= "           ,[TRANSACCION]" & vbCrLf
                sql &= "           ,[PARTIDA]" & vbCrLf
                sql &= "           ,[IDENTIFICADOR]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION]" & vbCrLf
                sql &= "           ,[USUARIO_CREACION_FECHA]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION]" & vbCrLf
                sql &= "           ,[USUARIO_EDICION_FECHA])" & vbCrLf
                sql &= "     VALUES" & vbCrLf
                sql &= "           (" & Compañia & vbCrLf
                sql &= "           ," & Me.DataGridView1.Rows(i).Cells("ORDEN_COMPRA").Value & vbCrLf
                sql &= "           ," & Me.DataGridView1.Rows(i).Cells("BODEGA").Value & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ," & Me.DataGridView1.Rows(i).Cells("TOTAL_FINAL").Value & vbCrLf
                sql &= "           ," & Me.DataGridView1.Rows(i).Cells("TIPO_DOCUMENTO").Value & vbCrLf
                sql &= "           ," & Me.DataGridView1.Rows(i).Cells("DOCUMENTO").Value & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,''" & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,'" & Format(Me.DataGridView1.Rows(i).Cells("FECHA_RECEPCION").Value, "dd/MM/yyyy") & " 23:59:59" & "'" & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,0" & vbCrLf
                sql &= "           ,'REGISTRO INSERTADO PARA AJUSTE MANUAL'" & vbCrLf
                sql &= "           ,'USAURIO'" & vbCrLf
                sql &= "           ,GETDATE()" & vbCrLf
                sql &= "           ,'USAURIO'" & vbCrLf
                sql &= "           ,GETDATE())" & vbCrLf
                c_data1.ejecutarComandoSql(New SqlCommand(sql))
                sql = "UPDATE CONTABILIDAD_ORDEN_COMPRA_CHEQUES SET PAGADO = 1, SALDO = 0 WHERE " & vbCrLf
                sql &= " COMPAÑIA = " & Compañia & vbCrLf
                sql &= "   AND ORDEN_COMPRA = " & Me.DataGridView1.Rows(i).Cells("ORDEN_COMPRA").Value & vbCrLf
                sql &= "   AND BODEGA = " & Me.DataGridView1.Rows(i).Cells("BODEGA").Value & vbCrLf
                sql &= "   AND DOCUMENTO = " & Me.DataGridView1.Rows(i).Cells("DOCUMENTO").Value & vbCrLf
                c_data1.ejecutarComandoSql(New SqlCommand(sql))
                Me.BackgroundWorker1.ReportProgress(CInt(Me.DataGridView1.Rows(i).Cells("ORDEN_COMPRA").Value))
            End If
        Next
    End Sub
End Class