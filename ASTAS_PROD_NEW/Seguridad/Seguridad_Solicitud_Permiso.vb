Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Seguridad_Solicitud_Permiso
    Dim Sql As String
    Dim jClass As New jarsClass
    Dim Ds_ As New DataSet
    Dim tipoPerm As Integer

    Sub New(ByVal permiso As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tipoPerm = permiso

    End Sub
    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Sql = String.Empty
        Try
            Sql &= "Execute sp_CONSULTAR_PERMISO @usuario='" & txtUser.Text & "', @pin='" & txtPin.Text & "', @origen_ = " & tipoPerm
            'jClass.Ejecutar_ConsultaSQL(Sql)
            continuar_ = False
            Ds_.Clear()
            jClass.MiddleConnection(Sql)
            jClass.DataAdapter.Fill(Ds_)
            If CInt(Ds_.Tables(0).Rows(0).Item("Existe").ToString()) > 0 Then
                continuar_ = True
                Me.Dispose()
            Else
                MsgBox("Pin Incorrecto...", MsgBoxStyle.Information, "Sistema")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub
End Class