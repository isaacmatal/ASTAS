Imports System.Data.SqlClient

Public Class Compras

    ''' <summary>
    ''' Especifique una sentencia para Insert, Update, Delete
    ''' </summary>
    ''' <param name="_sentencia">Instruccion Sql Valida</param>
    ''' <returns>Numero de Filas Afectadas</returns>
    ''' <remarks></remarks>
    Public Function actualizarDatos(ByVal _sentencia As String) As Integer
        Dim _retorno As Integer = 0        
        Try
            Using cn As New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                cn.Open()
                Dim _transaction As SqlTransaction
                _transaction = cn.BeginTransaction("Transaction01")
                Using cmd As New SqlCommand(_sentencia, cn)                    
                    Try
                        cmd.Transaction = _transaction
                        _retorno = cmd.ExecuteNonQuery()
                        _transaction.Commit()
                    Catch ex As Exception
                        _transaction.Rollback()
                        Throw New Exception(ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return _retorno
    End Function

    Public Function informar(ByVal _msj As String, ByVal _msjUsr As String) As Integer
        Dim _retorno As Integer = 0
        Dim sql As String = String.Empty

        sql = "INSERT INTO [dbo].[USUARIOS_MENSAJES]" & vbCrLf
        sql &= "           ([COMPAÑIA]" & vbCrLf
        sql &= "           ,[USUARIO_ENVIO]" & vbCrLf
        sql &= "           ,[USUARIO_RECEPCION]" & vbCrLf
        sql &= "           ,[MENSAJE]" & vbCrLf
        sql &= "           ,[FECHA]" & vbCrLf
        sql &= "           ,[ESTADO]" & vbCrLf
        sql &= "           ,[ASUNTO])" & vbCrLf
        sql &= "     VALUES" & vbCrLf
        sql &= "           (" & Compañia & vbCrLf
        sql &= "           ,'" & Usuario & "'" & vbCrLf
        sql &= "           ,'" & _msjUsr & "'" & vbCrLf
        sql &= "           ,'" & _msj & "'" & vbCrLf
        sql &= "           ,'" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
        sql &= "           ,1" & vbCrLf
        sql &= "           ,'REQUISICION DE COMPRA')"

        Try
            Using cn As New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                cn.Open()
                Dim _transaction As SqlTransaction
                _transaction = cn.BeginTransaction("TransactionMsg")
                Using cmd As New SqlCommand(sql, cn)
                    Try
                        cmd.Transaction = _transaction
                        _retorno = cmd.ExecuteNonQuery()
                        _transaction.Commit()
                    Catch ex As Exception
                        _transaction.Rollback()
                        Throw New Exception(ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return _retorno
    End Function

    

    ''' <summary>
    ''' Especifica una sentencia para un Insert y Retorna el ultimo ID insertado
    ''' </summary>
    ''' <param name="_sentencia_maestra">Instruccion Sql Valida</param>
    ''' <returns>Ultimo ID Insertado</returns>
    ''' <remarks></remarks>
    Public Function agregarDatos(ByVal _sentencia_maestra As String, ByVal _sentencia_detalle As String, ByVal _id As String) As Integer
        Dim _retorno As Integer = 0
        Try
            Using cn As New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                cn.Open()
                Dim _transaction As SqlTransaction
                _transaction = cn.BeginTransaction("Transaction02")
                Using cmd As New SqlCommand(_sentencia_maestra, cn)
                    Try
                        cmd.Transaction = _transaction
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = _id
                        _retorno = CInt(cmd.ExecuteScalar())

                        cmd.CommandText = _sentencia_detalle.Replace("<id>", _retorno.ToString())
                        cmd.ExecuteNonQuery()

                        _transaction.Commit()
                    Catch ex As Exception
                        _transaction.Rollback()
                        Throw New Exception(ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return _retorno
    End Function

    ''' <summary>
    ''' Obtenga un DataTable segun una consulta SQL valida
    ''' </summary>
    ''' <param name="_consulta">Consulta SQL Valida</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Function obtenerDatos(ByVal _consulta As String) As DataTable
        Dim _tabla As New DataTable("tabla")
        Dim da As SqlDataAdapter
        Try
            Using cn As New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                cn.Open()
                Using cmd As New SqlCommand(_consulta, cn)
                    da = New SqlDataAdapter(cmd)
                    da.Fill(_tabla)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return _tabla
    End Function

    Public Sub setearCombo(ByRef _combo As ComboBox, ByVal _consulta As String, ByVal _valor_visible As String, ByVal _valor_oculto As String)
        _combo.DataSource = Me.obtenerDatos(_consulta)
        _combo.DisplayMember = _valor_visible
        _combo.ValueMember = _valor_oculto
    End Sub

    Public Sub setearGridView(ByRef _gridview As DataGridView, ByVal _consulta As String)
        _gridview.DataSource = Me.obtenerDatos(_consulta)
    End Sub
End Class
