Imports System.Data.SqlClient

Public Class EntidadGenerica
    Dim Sql As String
    Dim Iniciando As Boolean
    Public entidad_ As String
    Public where_filter_ As String
    Public fields_ As String
    Public cadena_ As String = String.Empty

    Public Sub FillGrid(ByVal entidad_ As String, ByRef grv_ As System.Windows.Forms.DataGrid)
        grv_.DataSource = getData()
    End Sub

    Function getData() As DataTable
        If Not cadena_.Length > 0 Then
            cadena_ = Me.setStatement()
        End If
        Dim Conexion_ As New SqlConnection
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As New DataTable
        Try
            Conexion_.Open()
            Comando_ = New SqlCommand(cadena_, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos_" & entidad_)
            DataAdapter_.Fill(Table)
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Table
    End Function

    Function getData(ByVal _cadena As String) As DataTable
        Dim Table As New DataTable
        If _cadena.Length > 0 Then
            Dim Conexion_ As New SqlConnection
            Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
            Dim Comando_ As SqlCommand
            Dim DataAdapter_ As SqlDataAdapter
            Try
                Conexion_.Open()
                Comando_ = New SqlCommand(_cadena, Conexion_)
                DataAdapter_ = New SqlDataAdapter(Comando_)
                Table = New DataTable("consulta")
                DataAdapter_.Fill(Table)
                Conexion_.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

        Return Table
    End Function

    Function setStatement() As String
        Dim cadena_ As String
        cadena_ = "SELECT " & fields_ & " FROM " & entidad_ & " WHERE " & where_filter_
        Return cadena_
    End Function

    Public Sub fillComboBox(ByRef dd_ As ComboBox, ByVal cadena_ As String, ByVal value_ As String, ByVal display_ As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim TableData As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_ = New SqlCommand(cadena_, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            TableData = New DataTable("ddl_" & entidad_)
            DataAdapter_.Fill(TableData)
            dd_.DataSource = TableData
            dd_.ValueMember = value_
            dd_.DisplayMember = display_
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function checkFor(ByVal _cadena As String, ByVal _field As String, ByRef _value As String) As Boolean
        Dim _retorno As Boolean = False
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim TableData As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_ = New SqlCommand(_cadena, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            TableData = New DataTable("checkfor")
            DataAdapter_.Fill(TableData)
            If TableData.Rows.Count > 0 Then
                _retorno = True
                _value = TableData.Rows(0).Item(_field)
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return _retorno
    End Function

    Public Sub execute(ByVal cadena As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim jc As New jarsClass
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Comando_ = New SqlCommand(cadena, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class
