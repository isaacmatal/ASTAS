Imports System.Data
Imports System.Data.SqlClient

Public Class frm_hojadatos_fiadordesocios

    Public Fiador As Integer = 1

#Region "Connection"

    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS01 As New DataSet()
    Dim SQL As String
    Dim Beneficiario, Estado, Parentesco As Integer
    Dim Accion As String
    Dim PorcenBene, DeudaSocio As Double
    Dim contador As Integer

    'Dim CodBeneficiario As Integer
    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'DS.Reset()
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

#Region "Fiadores"

    Sub CargarDatosGrid_SocioFiador_deSocios(ByVal opcion As Integer)

        Try
            DS01.Reset()
            OpenConnection()
            If opcion = 1 Then
                'SQL = "EXECUTE [Coo].[sp_COOPERATIVA_MOSTRAR_SOCIO_DEPENDIENTE_FIADOR_DEUDA] " & Compañia & ",0," & ParamcodigoBux & ",'" & ParamcodigoAs & "',1"
                SQL = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]  " & vbCrLf
                SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
                SQL &= ", @CODIGO_EMPLEADO = " & ParamcodigoBux & vbCrLf
                SQL &= ", @BANDERA = 4" & vbCrLf
                Me.Text = "Cooperativa - Socio es Fiador de:"
            Else
                'SQL = "execute [Coo].[sp_COOPERATIVA_MOSTRAR_FIADORES_SOCIO_DEUDA] " & Compañia & ", " & ParamcodigoBux & ",'" & ParamcodigoAs & "',0"
                SQL = "EXEC [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD]  " & vbCrLf
                SQL &= "@COMPAÑIA = " & Compañia & vbCrLf
                SQL &= ", @CODIGO_EMPLEADO = " & ParamcodigoBux & vbCrLf
                SQL &= ", @BANDERA = 1" & vbCrLf
                Me.Text = "Cooperativa - Socio Tiene como Fiadores a:"
            End If
            MiddleConnection()
            DataAdapter.Fill(DS01)

            DataGrid01.DataSource = DS01.Tables(0)
            CloseConnection()

            'Me.DataGrid01.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DataGrid01.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DataGrid01.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DataGrid01.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'Me.DataGrid01.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DataGrid01.Columns.Item(4).DefaultCellStyle.Format = "$ #,##0.00"
            'Me.DataGrid01.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DataGrid01.Columns.Item(5).DefaultCellStyle.Format = "$ #,##0.00"
            'Me.DataGrid01.Columns.Item(0).Width = 60
            'Me.DataGrid01.Columns.Item(1).Width = 60
            'Me.DataGrid01.Columns.Item(2).Width = 60
            If opcion = 1 Then
                Me.DataGrid01.Columns("codfiad").Visible = False
                'Me.DataGrid01.Columns.Item(3).Width = 250
                'Me.DataGrid01.Columns.Item(4).Width = 80
                'Me.DataGrid01.Columns.Item(5).Width = 80
            Else
                Me.DataGrid01.Columns("codempl").Visible = False
                'Me.DataGrid01.Columns.Item(3).Width = 300
                'Me.DataGrid01.Columns.Item(4).Visible = False
                'Me.DataGrid01.Columns.Item(5).Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try

    End Sub

#End Region
End Class