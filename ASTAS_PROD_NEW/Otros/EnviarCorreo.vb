Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class EnviarCorreo
    Public Function Enviar(ByVal EmailPara As String, ByVal EmailDe As String, ByVal Asunto As String, ByVal mensaje As String, Optional ByVal Attached As String = "") As Boolean
        Dim Worker As BackgroundWorker = New BackgroundWorker
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        AddHandler Worker.DoWork, AddressOf WorkerDoWork
        Dim args(2) As Object
        Dim smtp As New SmtpClient
        Dim correo As New MailMessage
        Dim adjunto As Attachment
        Dim jClass As New jarsClass
        Dim Resultado As Boolean
        Dim smtpUser, smtpPswd, smtpHost As String
        Dim smtpSSL As Boolean
        Dim smtpPort As Integer

        If EmailDe.Length = 0 Or EmailPara.Length = 0 Then
            Return False
        End If
        Try
            smtpUser = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = 1 AND CONSTANTE = 47").ToString().Trim()
            smtpPswd = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = 1 AND CONSTANTE = 48").ToString().Trim()
            smtpHost = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = 1 AND CONSTANTE = 49").ToString().Trim()
            smtpPort = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = 1 AND CONSTANTE = 50"))
            smtpSSL = CBool(CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = 1 AND CONSTANTE = 51")))

            With smtp
                .Port = smtpPort
                .Host = smtpHost
                .Credentials = New System.Net.NetworkCredential(smtpUser, smtpPswd)
                .EnableSsl = smtpSSL
            End With

            With correo
                .From = New System.Net.Mail.MailAddress(EmailDe)
                .To.Add(EmailPara)
                .Subject = Asunto
                .Body = mensaje
                .IsBodyHtml = True
                .Priority = System.Net.Mail.MailPriority.Normal
            End With

            If Attached.Length > 0 Then
                adjunto = New System.Net.Mail.Attachment(Attached)
                correo.Attachments.Add(adjunto)
            End If
            args(0) = smtp
            args(1) = correo
            Worker.RunWorkerAsync(args)
            'smtp.Send(correo)
            Resultado = True
        Catch ex As Exception
            Resultado = False
        End Try
        Return Resultado
    End Function

    Private Sub WorkerDoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim objsmtp As SmtpClient = DirectCast(e.Argument(0), SmtpClient)
        Dim objcorreo As MailMessage = DirectCast(e.Argument(1), MailMessage)
        Try
            objsmtp.Send(objcorreo)
        Catch ex As SmtpException
            guardarError(ex, objcorreo)
        End Try
    End Sub

    Private Sub guardarError(ByVal ex As SmtpException, ByVal msj As MailMessage)
        Dim sqlCnn As New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim sqlcmd As SqlCommand
        Try
            sqlCnn.Open()
            sqlcmd = New SqlCommand("EXECUTE [dbo].[sp_CLINICA_CATALOGO_DOCTORES_SIUD] @COMPAÑIA = " & Compañia & ", @NOMBRES = '" & msj.From.Address & "', @APELLIDOS = '" & msj.Subject & "', @PROFESION = '" & msj.To(0).Address & "', @DIRECCION = '" & ex.InnerException.ToString & "', @TELEFONO = '" & ex.Message & "', @HORARIO = '" & msj.Body & "', @BANDERA = 'I', @USUARIO = '" & Usuario & "'", sqlCnn)
            sqlcmd.ExecuteNonQuery()
        Catch nex As Exception
            'no se debe mostrar mensaje, porque el envio de correo no es obligatorio, solo se captura el error para no detener la ejecucion de la aplicacion
            'MsgBox(nex.Message)
        Finally
            sqlCnn.Close()
        End Try
    End Sub
End Class
