Imports System.IO
Imports System.Data.SqlClient
Public Class Seguridad_Incidencias
    Dim c_data1 As New jarsClass
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
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Dim arrFilename() As String = Split(Text, "\")
        Array.Reverse(arrFilename)

        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer

        Dim arrFilename1() As String = Split(Text, "\")
        Array.Reverse(arrFilename1)

        Dim ms1 As New MemoryStream
        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
        Dim arrImage1() As Byte = ms1.GetBuffer

        Dim arrFilename2() As String = Split(Text, "\")
        Array.Reverse(arrFilename2)

        Dim ms2 As New MemoryStream
        PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
        Dim arrImage2() As Byte = ms2.GetBuffer

        Dim arrFilename3() As String = Split(Text, "\")
        Array.Reverse(arrFilename3)

        Dim ms3 As New MemoryStream
        PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)
        Dim arrImage3() As Byte = ms3.GetBuffer

        Dim arrFilename4() As String = Split(Text, "\")
        Array.Reverse(arrFilename4)

        Dim ms4 As New MemoryStream
        PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)
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
        If TextBox9.Text = "" Then
            MsgBox("Seleccione una incidencia")
        Else
            MiddleConnection()
            MsgBox("IMAGEN CARGADA!")
        End If
        
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
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox5
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.CenterImage
                .BorderStyle = BorderStyle.Fixed3D
                Me.Button8.Enabled = True

            End With
        End If
    End Sub

    Private Sub Seguridad_Incidencias_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub GroupBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class