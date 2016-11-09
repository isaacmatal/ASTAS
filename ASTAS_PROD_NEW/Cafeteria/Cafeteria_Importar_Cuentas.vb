Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel
Public Class Cafeteria_Importar_Cuentas

    Private Sub Cafeteria_Importar_Cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "Hoja1"
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
            txtRutaXLS.Text = openFileDialog1.FileName

            'Instanciamos nuestra cadena de conexion especial para excel,indicando la ruta del fichero
            Dim cadconex As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.txtRutaXLS.Text.Trim & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
            Dim cn As New OleDb.OleDbConnection(cadconex)
            Dim cmd As New OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            cmd.Connection = cn
            'Consultamos la hoja llamada Clientes de nuestro archivo *.xls
            If TextBox1.Text = "" Then
                MsgBox("DEBE ESTABLECER EL NOMBRE DE LA HOJA DE SU LIBRO DE EXCEL")
                Exit Sub
            End If

            cmd.CommandText = "select * from [" & Me.TextBox1.Text & "$]"
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
End Class