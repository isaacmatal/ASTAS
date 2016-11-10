Imports System.Data.SqlClient

Public Class multiUsos

    'Herencia
    Inherits cmbFill

    'Declaracion de variables
    Dim sql As String

    'Conexion
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader

    'Devuelve la fecha con el primer o �ltimo d�a del mes vigente acorde a la fecha del servidor
    '5 Primer d�a
    '6 �ltimo d�a
    Public Function devuelvePrimerUltimoDiaMes(ByVal flag As Integer) As Date
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= 0
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                Return DataReader_.Item("Valor")
            Else
                Return FechaActual_Servidor()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Function

    'Devuelve la fecha con el primer o �ltimo d�a de un mes X acorde a la fecha del servidor
    '7 Primer d�a
    '8 �ltimo d�a
    Public Function devuelvePrimerUltimoDiaMesX(ByVal mes As Integer, ByVal flag As Integer) As Date
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= 0
            sql &= ", " & mes
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                Return DataReader_.Item("Valor")
            Else
                Return FechaActual_Servidor()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Function

    'Actualiza las facturas como impresas
    Public Sub actualizaFacturasImpresion(ByVal cia As Integer, ByVal x As Integer, ByVal y As Integer, ByVal z As Integer _
                                          , ByVal xyz As Integer, ByVal flag As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= cia
            sql &= ", " & x
            sql &= ", " & y
            sql &= ", " & z
            sql &= ", " & xyz
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Verifica si a�n tiene fecha de vigencia e correlativo
    Public Function verificaVigenciaSerieCorrelativos(ByVal cia As Integer, ByVal bodega As Integer, ByVal tipoDoc As Integer _
                                                    , ByVal serie As Integer, ByVal flag As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & tipoDoc
            sql &= ", " & serie
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                If DataReader_.Item("Valor") = 0 Then
                    MsgBox("�La serie cargada no est� vigente, no podr� generar ning�n documento!", MsgBoxStyle.Information, "Mensaje")
                    Return False
                ElseIf DataReader_.Item("Valor") = 1 Then
                    Return True
                ElseIf DataReader_.Item("Valor") = -1 Then
                    MsgBox("�No hay series asignadas, no podr� generar ning�n documento!", MsgBoxStyle.Information, "Mensaje")
                    Return False
                End If
            Else
                MsgBox("�No se encontraron registros!", MsgBoxStyle.Information, "Mensaje")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return False
    End Function

    'Verifica existe ya el rubro de retencion para la caja chica seleccionada
    Public Function verificaRubroRetencion(ByVal cia As Integer, ByVal lc As Integer, ByVal cc As Integer _
                                         , ByVal cta As Integer, ByVal flag As Integer, ByVal sn As Integer _
                                         , ByVal chk As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & cc
            sql &= ", " & cta
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                If flag = 12 Then 'Comprobamos si la cuenta que se ha enviado est� relacionada con reteneciones por servicios
                    If DataReader_.Item("Valor") = 0 Then 'Si la cuenta no es de retenci�n
                        If sn = 1 Then 'Si desea mostrar el mensaje
                            If chk = 1 Then 'Si ha seleccionado el checkbox
                                'Verifica si el usuario quiere asignar esa cuenta como rubro de retenci�n
                                If MsgBox("La cuenta que ha seleccionado parece no estar relacionada con una cuenta de retenci�n" & vbCrLf & _
                                   "�Est� seguro de querer aplicarla como rubro de retenci�n?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                                   "Mensaje") = MsgBoxResult.Yes Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else ' Si no ha seleccionado el checkbox lo mantiene as�
                                Return False
                            End If
                        Else 'En caso que no muestre el msj
                            Return False
                        End If
                    ElseIf DataReader_.Item("Valor") = 1 Then 'Si la cuenta es de retenci�n
                        If sn = 1 Then 'Si desea mostrar el msj
                            If chk = 0 Then 'Si no ha seleccionado el checkbox
                                'Verifica con el usuario si quiere utilizar la cuenta como rubro de retenci�n
                                If MsgBox("La cuenta que ha seleccionado parece estar relacionada con una cuenta de retenci�n" & vbCrLf & _
                                   "�Quiere aplicarla como rubro de retenci�n?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                                   "Mensaje") = MsgBoxResult.Yes Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else 'Si no ha seleccionado el checkbox lo mantiene as�
                                Return True
                            End If
                        Else 'En caso no muestre el msj
                            Return True
                        End If
                    ElseIf DataReader_.Item("Valor") = -1 Then 'Si ya hay un rubro de retenci�n
                        If sn = 1 Then 'Si desea mostrar el msj
                            If chk = 1 Then 'Si ha seleccionado el checkbox
                                MsgBox("�Ya existe un rubro de retenci�n para �sta caja chica!", MsgBoxStyle.Information, "Mensaje")
                                Return False
                            Else 'Si no lo ha seleccionado lo mantiene as�
                                Return False
                            End If
                        Else 'En caso que no desee mostrar el msj
                            Return False
                        End If
                    ElseIf DataReader_.Item("Valor") = -2 Then 'Si ya existe y es la misma cuenta
                        If sn = 1 Then 'Si desea mostrar el msj
                            If chk = 1 Then 'Si ha seleccionado el checkbox
                                MsgBox("��sta cuenta ya est� siendo utilizada como rubro de retenci�n!", MsgBoxStyle.Information, "Mensaje")
                                Return False
                            Else 'Si no lo ha seleccionado lo mantiene as�
                                Return False
                            End If
                        Else 'En caso que no desee mostrar el msj
                            Return False
                        End If
                    End If
                ElseIf flag = 13 Then 'Comprueba si existe un rubro para retenciones
                    If DataReader_.Item("Valor") = 0 Then
                        If sn = 1 Then
                            MsgBox("�No existe un rubro para aplicaci�n de retenciones!", MsgBoxStyle.Information, "Mensaje")
                        End If
                        Return False
                    ElseIf DataReader_.Item("Valor") = 1 Then
                        If sn = 1 Then
                            MsgBox("�Ya existe un rubro para aplicaci�n de retenciones!", MsgBoxStyle.Information, "Mensaje")
                        End If
                        Return True
                    End If
                End If
            Else
                MsgBox("�No se encontraron registros!", MsgBoxStyle.Information, "Mensaje")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return False
    End Function

    'Verifica si existe ya el rubro de prestamo para la caja chica seleccionada
    Public Function verificaRubroPrestamo(ByVal cia As Integer, ByVal lc As Integer, ByVal cc As Integer _
                                         , ByVal cta As Integer, ByVal flag As Integer, ByVal sn As Integer _
                                         , ByVal chk As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & cc
            sql &= ", " & cta
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                If flag = 14 Then 'Comprobamos si la cuenta que se ha enviado est� relacionada con prestamos
                    If DataReader_.Item("Valor") = 0 Then 'Si la cuenta no es de prestamo
                        If sn = 1 Then 'Si desea mostrar el mensaje
                            If chk = 1 Then 'Si ha seleccionado el checkbox
                                'Verifica si el usuario quiere asignar esa cuenta como rubro de prestamo
                                If MsgBox("La cuenta que ha seleccionado parece no estar relacionada con una cuenta de pr�stamo" & vbCrLf & _
                                   "�Est� seguro de querer aplicarla como rubro de pr�stamo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                                   "Mensaje") = MsgBoxResult.Yes Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else ' Si no ha seleccionado el checkbox lo mantiene as�
                                Return False
                            End If
                        Else 'En caso que no muestre el msj
                            Return False
                        End If
                    ElseIf DataReader_.Item("Valor") = 1 Then 'Si la cuenta es de prestamo
                        If sn = 1 Then 'Si desea mostrar el msj
                            If chk = 0 Then 'Si no ha seleccionado el checkbox
                                'Verifica con el usuario si quiere utilizar la cuenta como rubro de prestamo
                                If MsgBox("La cuenta que ha seleccionado parece estar relacionada con una cuenta de pr�stamo" & vbCrLf & _
                                   "�Quiere aplicarla como rubro de pr�stamo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                                   "Mensaje") = MsgBoxResult.Yes Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else 'Si no ha seleccionado el checkbox lo mantiene as�
                                Return True
                            End If
                        Else 'En caso no muestre el msj
                            Return True
                        End If
                    ElseIf DataReader_.Item("Valor") = -1 Then 'Si ya hay un rubro de prestamo
                        If sn = 1 Then 'Si desea mostrar el msj
                            If chk = 1 Then 'Si ha seleccionado el checkbox
                                MsgBox("��sta cuenta ya est� asignada como rubro de pr�stamo para �sta caja chica!", MsgBoxStyle.Information, "Mensaje")
                                Return False
                            Else 'Si no lo ha seleccionado lo mantiene as�
                                Return False
                            End If
                        Else 'En caso que no desee mostrar el msj
                            Return False
                        End If
                    End If
                    'AUN NO EXISTE
                ElseIf flag = 15 Then 'Comprueba si existe un rubro para prestamos
                    If DataReader_.Item("Valor") = 0 Then
                        If sn = 1 Then
                            MsgBox("�No existe un rubro para pr�stamo de retenciones!", MsgBoxStyle.Information, "Mensaje")
                        End If
                        Return False
                    ElseIf DataReader_.Item("Valor") = 1 Then
                        If sn = 1 Then
                            MsgBox("�Ya existe un rubro para aplicaci�n de retenciones!", MsgBoxStyle.Information, "Mensaje")
                        End If
                        Return True
                    End If
                End If
            Else
                MsgBox("�No se encontraron registros!", MsgBoxStyle.Information, "Mensaje")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return False
    End Function

    'Regres si el rubro es de retenci�n o no
    Public Function regresaRubroRetencionTF(ByVal cia As Integer, ByVal lc As Integer, ByVal cc As Integer _
                                          , ByVal rubro As Integer, ByVal flag As Integer)
        Conexion_ = devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CUENTASXCOBRAR_VARIOS "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & cc
            sql &= ", " & rubro
            sql &= ", " & 0
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If DataReader_.Read = True Then
                Return DataReader_.Item("Valor")
            Else
                If flag = 16 Then
                    Return 0
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
        Return False
    End Function

End Class
