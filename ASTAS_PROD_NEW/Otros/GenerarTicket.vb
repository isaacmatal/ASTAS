Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D

''' <summary>
''' Permite mandar a imprimir un ticket
''' Para ello utilice el Metodo AbrirArchivo, luego
''' Escriba todo el ticket con el metodo EscribirTicket, luego ejecute el metodo
''' CerrarArchivo, cuando tenga todo el ticket generado
''' Este ultimo metodo permite mandar a imprimir el tickets
''' </summary>
Public Class GenerarTicket
    Private escritor As IO.StreamWriter
    Private clp As New PrinterClass
    Dim Text As String
    ''' <summary>
    ''' Permite abrir el archivo ticket.tx, que se utiliza para almacenar el ticket.
    ''' Y almacena el encabezado del Ticket.
    ''' De forma temporal se escribe todo el ticket un archivo de texto plano
    ''' Para luego mandar a imprimir lo que este archivo contenga
    ''' </summary>
    Public Sub AbrirArchivo()
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ticket.txt"
        Text = ""
        escritor = New IO.StreamWriter(archivo)
        
        escritor.WriteLine("NRC:82735-5                           ")
        Text += "NRC:82735-5                            " & vbCrLf
        escritor.WriteLine("NIT:0614-020994-102-1                 ")
        Text += "NIT:0614-020994-102-1                  " & vbCrLf
        
        escritor.WriteLine(" ASOCIACION DE TRABAJADORES DE AVICOLA  ")
        Text += " ASOCIACION DE TRABAJADORES DE AVICOLA  " & vbCrLf
        escritor.WriteLine("  SALVADORENA S.A DE C.V. Y FILIALES     ")
        Text += "  SALVADORENA S.A DE C.V. Y FILIALES     " & vbCrLf
        escritor.WriteLine("                 ASTAS                 ")
        Text += "                 ASTAS                 " & vbCrLf
        
        escritor.WriteLine("GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO")
        Text += "GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO " & vbCrLf
        escritor.WriteLine("CLASIFICADOS PREVIAMENTE CAFETERIAS   ")
        Text += "CLASIFICADOS PREVIAMENTE CAFETERIAS    " & vbCrLf
        escritor.WriteLine("Y FRUTERIAS                           ")
        Text += "Y FRUTERIAS                            " & vbCrLf
        clp.Ruta(archivo)
    End Sub
    'Public Sub digitalizar(ByVal numero_factura As Integer)        
    '    Dim FontColor As Color = Color.Black
    '    Dim BackColor As Color = Color.White
    '    Dim FontName As String = "Times New Roman"
    '    Dim FontSize As Integer = 11
    '    Dim Height As Integer = 800
    '    Dim Width As Integer = 375
    '    Dim FileName As String = numero_factura.ToString()
    '    Dim objBitmap As New Bitmap(Width, Height)
    '    Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
    '    Dim objColor As Color
    '    Dim objFont As New Font(FontName, FontSize)
    '    'Following PointF object defines where the text will be displayed in the
    '    'specified area of the image
    '    Dim objPoint As New PointF(5.0F, 5.0F)
    '    Dim objBrushForeColor As New SolidBrush(FontColor)
    '    Dim objBrushBackColor As New SolidBrush(BackColor)
    '    objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)
    '    objGraphics.DrawString(Text, objFont, objBrushForeColor, objPoint)
    '    objBitmap.Save(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & FileName & ".png", ImageFormat.Png)
    'End Sub
    Public Sub digitalizar(ByVal numero_factura As Integer, ByVal caja As String)
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\CINTA") Then
            'Else
            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\CINTA")
        End If
        Try
            'Dim ms As New System.IO.MemoryStream
            Dim bitmap As New Bitmap(1, 1)
            Dim font As New Font("Consolas", 11, FontStyle.Regular, GraphicsUnit.Pixel)
            'Dim font As New Font("Courier New", 11, FontStyle.Regular, GraphicsUnit.Pixel)
            Dim graphics As Graphics = Drawing.Graphics.FromImage(bitmap)
            Dim width As Integer = CInt(graphics.MeasureString(Text, font).Width)
            Dim height As Integer = CInt(graphics.MeasureString(Text, font).Height)
            bitmap = New Bitmap(bitmap, New Size(width, height))
            graphics = Drawing.Graphics.FromImage(bitmap)
            graphics.Clear(Color.White)
            graphics.SmoothingMode = SmoothingMode.AntiAlias
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            graphics.DrawString(Text, font, New SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0)
            graphics.Flush()
            graphics.Dispose()
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\CINTA\Caja " & caja.ToString().PadLeft(2, "0") & " - Cinta Auditora dia " & numero_factura.ToString() & ".jpg"
            bitmap.Save(fileName, ImageFormat.Jpeg)
            'bitmap.Save(ms, ImageFormat.Jpeg)
            'ms.Seek(0, System.IO.SeekOrigin.Begin)
            'Dim file As New System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
            'ms.WriteTo(file)
            'file.Close()
            'ms.Close()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub AbrirArchivo2()
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ticket.txt"

        escritor = New IO.StreamWriter(archivo)
        clp.Ruta(archivo)
    End Sub
    Public Sub AbrirArchivoFiscal()
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ticket1.txt"

        escritor = New IO.StreamWriter(archivo)
        escritor.WriteLine("=======================================" & "   " & "=======================================")
        escritor.WriteLine(" NRC:82735-5                           " & "   " & " NRC:82735-5                           ")
        escritor.WriteLine(" NIT:0614-020994-102-1                 " & "   " & " NIT:0614-020994-102-1                 ")
        escritor.WriteLine(" ASOCIACION DE TRABAJADORES DE         " & "   " & " ASOCIACION DE TRABAJADORES DE         ")
        escritor.WriteLine(" AVICOLA SALVADORENA                   " & "   " & " AVICOLA SALVADORENA                   ")
        escritor.WriteLine(" S.A DE C.V. Y FILIALES(ASTAS)         " & "   " & " S.A DE C.V. Y FILIALES(ASTAS)         ")
        escritor.WriteLine(" GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO" & "   " & " GIRO:OTRAS ACTIVIDADES DE SERVICIOS NO")
        escritor.WriteLine(" CLASIFICADOS PREVIAMENTE CAFETERIAS   " & "   " & " CLASIFICADOS PREVIAMENTE CAFETERIAS   ")
        escritor.WriteLine(" Y FRUTERIAS                           " & "   " & " Y FRUTERIAS                           ")
        clp.Ruta(archivo)
    End Sub

    ''' <summary>
    ''' Permite escribir una linea que sera impresa en el ticket
    ''' La longitud maxima del parametro linea debe de ser 39
    ''' </summary>
    Public Sub EscribirTicket(ByVal linea As String)
        CortarCadena(linea)        
    End Sub
    Public Sub EscribirTicketFiscal(ByVal linea As String)
        CortarCadenaFiscal(linea)
    End Sub
    Public Sub EscribirTicketSimple(ByVal linea As String)
        escritor.WriteLine(linea)
    End Sub

    'METODO RECURSIVO QUE PERMITE RECORTAR UNA CADENA DE MAS DE 39 CARACTERES
    Private Sub CortarCadena(ByVal cadena As String)
        'VERIFICAMOS QUE LA CADENA NO SABREPASA LOS 39 CARACTERES
        If cadena.Length > 39 Then
            'ESCRIBIR LA CADENA DE 39 CARACTERES
            escritor.WriteLine(cadena.Substring(0, 39))
            Text += cadena.Substring(0, 39) & vbCrLf
            'OBTENER NUEVA CADENA DESDE LA LONGITUD DE 39 CARACTERES
            Dim nuevaCadena As String = cadena.Substring(39)
            'LLAMADA RECURSIVA A ESTE MISMO METODO
            CortarCadena(nuevaCadena)
        Else
            'LA CADENA NO SOBREPASA LOS 39 REGISTROS ENTONCES SOLO ESCRIBIRLA
            'AQUI TERMINA LA LLAMADA
            escritor.WriteLine(cadena)
            Text += cadena & vbCrLf
        End If
    End Sub
    'METODO RECURSIVO QUE PERMITE RECORTAR UNA CADENA DE MAS DE 39 CARACTERES
    Private Sub CortarCadenaFiscal(ByVal cadena As String)
        'VERIFICAMOS QUE LA CADENA NO SABREPASA LOS 39 CARACTERES
        If cadena.Length > 81 Then
            'ESCRIBIR LA CADENA DE 39 CARACTERES
            escritor.WriteLine(cadena.Substring(0, 81))
            'OBTENER NUEVA CADENA DESDE LA LONGITUD DE 39 CARACTERES
            Dim nuevaCadena As String = cadena.Substring(81)
            'LLAMADA RECURSIVA A ESTE MISMO METODO
            CortarCadena(nuevaCadena)
        Else
            'LA CADENA NO SOBREPASA LOS 39 REGISTROS ENTONCES SOLO ESCRIBIRLA
            'AQUI TERMINA LA LLAMADA
            escritor.WriteLine(cadena)
        End If
    End Sub

    ''' <summary>
    ''' Permite cerrar el archivo ticket.txt, que se utiliza para almacenar el ticket.
    ''' De forma temporal se escribe todo el ticket un archivo de texto plano
    ''' Para luego mandar a imprimir lo que este archivo contenga
    ''' Ademas permite realizar el corte del papel del ticket impreso.
    ''' </summary>
    Public Sub CerrarArchivo(ByVal numero As String, ByVal caja As String)
        escritor.WriteLine(" ")
        escritor.WriteLine(".")
        escritor.Close()
        escritor.Dispose()
        'CARACTERES PARA REALIZAR EL CORTE DEL TICKET
        'digitalizar(numero, caja)
        clp.Imprimir()
    End Sub
    Public Sub CerrarArchivo2()
        For i As Integer = 0 To 3
            escritor.WriteLine(" ")
        Next
        escritor.Close()
        escritor.Dispose()
        'CARACTERES PARA REALIZAR EL CORTE DEL TICKET        
        clp.Imprimir()
    End Sub
    Public Sub CerrarArchivoSinImprimir()
        For i As Integer = 0 To 3
            escritor.WriteLine(" ")
        Next
        escritor.Close()
        escritor.Dispose()
        'CARACTERES PARA REALIZAR EL CORTE DEL TICKET
    End Sub
    Public Sub CerrarArchivoFiscal()
        For i As Integer = 0 To 3
            escritor.WriteLine(" ")
        Next
        escritor.Close()
        escritor.Dispose()
        'CARACTERES PARA REALIZAR EL CORTE DEL TICKET
        clp.ReImprimir()
    End Sub
End Class
