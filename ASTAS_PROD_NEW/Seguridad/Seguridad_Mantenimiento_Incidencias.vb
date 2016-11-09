Imports System.IO
Imports System.Data.SqlClient
Public Class Seguridad_Mantenimiento_Incidencias
    Dim c_data1 As New jarsClass
    Private Sub Seguridad_Mantenimiento_Incidencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridView1.DataSource = c_data1.ejecutaSQLl_llenaDTABLE("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='C'")

        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
        TextBox4.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()
        TextBox7.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        TextBox6.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString()
        TextBox9.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox8.Text = "" Then
                MessageBox.Show("INGRESE NOMBRE DEL SOPORTE")
            Else
                c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO='" & TextBox1.Text & "', @BANDERA='U', @CLASE='" & TextBox2.Text & "',@PRIORIDAD='" & TextBox3.Text & "', @TITULO='" & TextBox5.Text & "', @DESCRIPCION='" & TextBox4.Text & "', @ESTADO='" & TextBox7.Text & "', @FECHA='" & TextBox6.Text & "'")

                c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_INCIDENCIAS_IMAGENES @COMPAÑIA=" & Compañia & ", @FECHA_FINALIZACION='" & DateTimePicker1.Value & "', @SOPORTE='" & TextBox8.Text & "'," & "@ITEM=" & TextBox9.Text)

                Me.DataGridView1.DataSource = c_data1.ejecutaSQLl_llenaDTABLE("EXECUTE SP_INCIDENCIAS @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='C'")

                For i As Integer = 0 To DataGridView1.ColumnCount - 1
                    DataGridView1.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox5.Text = ""
                TextBox4.Text = ""
                TextBox7.Text = ""
                TextBox6.Text = ""
            End If
            
        Catch ex As Exception

        End Try

    End Sub
    Function ExtraerImagen1(ByVal Foto As Integer, ByVal Imagen As Integer) As Byte()
        Dim SqlSelect As String = "Select IMAGEN" & Imagen.ToString() & " From SEGURIDAD_INCIDENCIAS_IMAGENES Where ITEM = " & Foto
        OpenConnection()
        Comando_Track = New SqlCommand(SqlSelect, Conexion_Track)

        Dim MyPhoto() As Byte = CType(Comando_Track.ExecuteScalar(), Byte())
        CloseConnection()
        Return MyPhoto
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            'El MemoryStream nos permite crear un almacen de memoria..
            Dim ms As New MemoryStream(ExtraerImagen1(CInt(Me.TextBox9.Text), 1))
            Me.PictureBox1.Image = Image.FromStream(ms)
            ms.Close()

            'El MemoryStream nos permite crear un almacen de memoria..
            Dim ms1 As New MemoryStream(ExtraerImagen1(CInt(Me.TextBox9.Text), 2))
            Me.PictureBox2.Image = Image.FromStream(ms1)
            ms1.Close()

            'El MemoryStream nos permite crear un almacen de memoria..
            Dim ms2 As New MemoryStream(ExtraerImagen1(CInt(Me.TextBox9.Text), 3))
            Me.PictureBox3.Image = Image.FromStream(ms2)
            ms2.Close()

            'El MemoryStream nos permite crear un almacen de memoria..
            Dim ms3 As New MemoryStream(ExtraerImagen1(CInt(Me.TextBox9.Text), 4))
            Me.PictureBox4.Image = Image.FromStream(ms3)
            ms3.Close()

            'El MemoryStream nos permite crear un almacen de memoria..
            Dim ms4 As New MemoryStream(ExtraerImagen1(CInt(Me.TextBox9.Text), 5))
            Me.PictureBox5.Image = Image.FromStream(ms4)
            ms4.Close()
        Catch ex As Exception
        End Try
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
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("¿Está seguro que desea eliminar este ticket?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then

        End If
    End Sub
End Class