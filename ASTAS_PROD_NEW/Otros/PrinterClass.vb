Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

''' <summary> Clase : PrinterClass     Contiene diferentes funciones Para llamar el impresor</summary>
Public Class PrinterClass
    Private printFont As Font
    Private streamToPrint As StreamReader
    Private Shared filePath As String

    ' The PrintPage event is raised for each page to be printed. 
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        'Dim leftMargin As Single = ev.MarginBounds.Left
        Dim leftMargin As Single = 0
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Iterate over the file, printing each line. 
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
                yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page. 
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub
    Public Sub Ruta(ByVal Path As String)
        filePath = Path
    End Sub
    Public Function Imprimir() As Boolean
        Try
            streamToPrint = New StreamReader(filePath)
            Try
                'printFont = New Font("Courier New", 7.5)
                printFont = New Font("Consolas", 8.5)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                ' Print the document.
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function ' SendFileToPrinter()
    Public Function ReImprimir() As Boolean
        Try
            streamToPrint = New StreamReader(filePath)
            Try
                printFont = New Font("Consolas", 8.5)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                ' Print the document.
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function ' SendFileToPrinter()
   
End Class
