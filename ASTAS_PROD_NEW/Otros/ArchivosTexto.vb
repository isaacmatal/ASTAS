Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ArchivosTexto
    Dim jClass As New jarsClass

    Public Function cargaTexto(ByVal Encabezado As String, ByVal Ruta As String, ByVal Archivo As String) As DataTable
        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Ruta & ";" & _
            "Extended Properties='text;CharacterSet=ANSI;HDR=" & Encabezado & ";FMT=Delimited'"

        Dim dt As DataTable = New DataTable("miTabla")
        Try
            Using conn As OleDbConnection = New OleDbConnection(connectionString)
                Using da As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & Archivo, conn)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            jClass.msjError(ex, "ArchivosTexto.crearArchivo")
        End Try
        Return dt
    End Function

    Public Function crearArchivo(ByVal fichero As String, ByVal cadena As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sw As New StreamWriter(fichero, True)
            sw.WriteLine(cadena)
            ' Cerramos el fichero
            sw.Close()
            result = True
        Catch ex As Exception
            jClass.msjError(ex, "ArchivosTexto.crearArchivo")
        End Try
        Return result
    End Function

    Public Function enviarDatos(ByVal Datos As DataTable, ByVal Archivo As String) As Boolean
        Dim Success As Boolean
        Dim cadena As String = String.Empty
        Dim secuencia As Integer = 0
        Dim items() As Object
        Try
            Dim sw As New StreamWriter(Archivo, False)
            For Each row As DataRow In Datos.Rows
                secuencia += 1
                items = row.ItemArray()
                cadena = String.Empty
                For Each itemRow As Object In items
                    If cadena.Length = 0 Then
                        If itemRow.GetType.Name.ToUpper = "DATE" Or itemRow.GetType.Name.ToUpper = "DATETIME" Then
                            cadena &= Format(itemRow, "dd/MM/yyyy")
                        Else
                            cadena &= itemRow.ToString
                        End If
                    Else
                        If itemRow.GetType.Name.ToUpper = "DATE" Or itemRow.GetType.Name.ToUpper = "DATETIME" Then
                            cadena &= Chr(9) & Format(itemRow, "dd/MM/yyyy")
                        Else
                            cadena &= Chr(9) & itemRow.ToString
                        End If
                    End If
                Next
                sw.WriteLine(cadena)
            Next
            ' Cerramos el Archivo
            sw.Close()
            Success = True
        Catch ex As Exception
            jClass.msjError(ex, "ArchivosTexto.enviarDatos")
            Success = False
        End Try
        Return Success
    End Function
End Class
