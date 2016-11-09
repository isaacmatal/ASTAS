Imports System.Data
Imports System.Data.SqlClient

Public Class frm_reporte_cooperativa_retiro_ahorro_carta

#Region "Connection"

    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim DS04, DS05, DS06 As New DataSet()
    Dim SQL As String

    Dim ID_Retiro, Accion As String
    'Dim CodBeneficiario As Integer
    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        'DS.Reset()
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
        'DataAdapter.Fill(DS01)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

#Region "Busqueda Socio"
    Sub BusquedaSocio()
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2


        Dim Prin As New Busquedas_empleados_avicola
        Prin.Compañia_Value = Compañia
        Prin.CbxCompania.Enabled = False
        AppPath = System.IO.Directory.GetCurrentDirectory
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            'Reporte(ParamcodigoBux, ParamcodigoAs)
            Reporte(ID_Retiro, Accion)
        End If

    End Sub

#End Region

#Region "Reporte cooperativa socios ahorros historial"
    Public Sub Reporte(ByVal ID_Retiro, ByVal Accion)

        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim Rpt As New rpt_reporte_cooperativa_retiro_ahorro_carta
        Try
            Conexion_.Open()
            SQL = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO 1,1,62,'571','SE'"
            Comando_ = New SqlCommand(SQL, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            Me.CrystalReportViewer1.ReportSource = Rpt
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region

End Class