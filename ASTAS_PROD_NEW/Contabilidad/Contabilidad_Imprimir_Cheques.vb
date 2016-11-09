'------------------------------------------------------------------------------
' Pruebas para imprimir con VB .NET                                 (14/Ene/05)
' En este ejemplo no se tienen en cuenta los anchos de las columnas
'
' Revisado para Visual Basic 2005 para Ineta Latam Mag              (16/Abr/07)
' Revisado para Visual Basic 2008 para publicar en mi sitio         (03/Feb/09)
'
' ©Guillermo 'guille' Som, 2005-2009
'------------------------------------------------------------------------------
'Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Contabilidad_Imprimir_Cheques
    'Private prtDialog As PrintDialog
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private jClass As New jarsClass
    'Private prtPrev As New PrintPreviewDialog
    Private prtFont As System.Drawing.Font
    '
    Private lineaActual As Integer
    '
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        With ListView1
            .Columns.Clear()
            .Columns.Add("Fecha", 60, HorizontalAlignment.Left)
            .Columns.Add("Nombre", 100, HorizontalAlignment.Left)
            .Columns.Add("ValorLetras", 160, HorizontalAlignment.Left)
            .Columns.Add("NoNegociable", 160, HorizontalAlignment.Left)
            .Columns.Add("Cheque", 40, HorizontalAlignment.Left)
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .HideSelection = False
        End With
        '
        ' obtener un número aleatorio entre 10 y 15
        Dim r As New System.Random
        Dim n As Integer = r.Next(10, 25)
        '
        ' Rellenar el ListView con algunos datos
        For i As Integer = 0 To Me.dgvCheques.Rows.Count - 1
            Dim lvi As ListViewItem

            lvi = ListView1.Items.Add(Format(CDate(Me.dgvCheques.Rows(i).Cells(5).Value.ToString()), "dd") & Space(3) & Format(CDate(Me.dgvCheques.Rows(i).Cells(5).Value.ToString()), "MMMM").ToUpper.PadRight(12, " ") & Format(CDate(Me.dgvCheques.Rows(i).Cells(5).Value.ToString()), "yyyy") & Space(2) & Format(Me.dgvCheques.Rows(i).Cells(2).Value, "#,###.00").PadLeft(11, "*"))
            lvi.SubItems.Add(Me.dgvCheques.Rows(i).Cells(1).Value.ToString())
            lvi.SubItems.Add(Me.dgvCheques.Rows(i).Cells(3).Value.ToString())
            lvi.SubItems.Add(IIf(IIf(IsDBNull(Me.dgvCheques.Rows(i).Cells(4).Value), False, Me.dgvCheques.Rows(i).Cells(4).Value), "NO NEGOCIABLE", ""))
            lvi.SubItems.Add(i.ToString())
        Next
        '
        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 12)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings
        '
    End Sub
    '
    Private Sub btnSelImpresora_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelImpresora.Click
        ' Seleccionar la impresora (cuadro de diálogos para imprimir)
        seleccionarImpresora()
    End Sub
    '

    ''' <summary>
    ''' Seleccionar la impresora.
    ''' </summary>
    ''' <returns>
    ''' Devuelve True si todo fue bien o false si se canceló
    ''' </returns>
    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        With prtDialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = True
            prtSettings.MinimumPage = 1
            prtSettings.MaximumPage = 99
            prtSettings.FromPage = 1
            prtSettings.ToPage = 99
            '
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True
            .PrinterSettings = prtSettings

            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                prtSettings = .PrinterSettings
            Else
                Return False
            End If

        End With

        Return True
    End Function
    '
    Private Sub btnPreview_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPreview.Click
        ' Vista preliminar
        imprimir(True)
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        ' Imprimir
        imprimir(False)
    End Sub


    ' Listado 3

    Private Sub imprimir(ByVal esPreview As Boolean)
        ' imprimir o mostrar el PrintPreview

        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        If chkSelAntes.Checked Then
            If seleccionarImpresora() = False Then Return
        End If

        If prtDoc Is Nothing Then
            prtDoc = New System.Drawing.Printing.PrintDocument
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage
        End If

        ' la línea actual
        lineaActual = 0

        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings

        If esPreview Then
            Dim prtPrev As New PrintPreviewDialog
            prtPrev.Document = prtDoc
            DirectCast((prtPrev.Controls(1)), ToolStrip).Items(0).Visible = False
            prtPrev.Text = "Previsualizar documento"
            prtPrev.ShowDialog()
        Else
            prtDoc.Print()
        End If
    End Sub
    '
    ' El evento usado mientras se imprime el documento
    Private Sub prt_PrintPage(ByVal sender As Object, _
                              ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ' Este evento se produce cada vez que se va a imprimir una página
        Dim lineHeight As Single
        Dim SqlUpd As String
        Dim yPos As Single = 0 'e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim printFont As System.Drawing.Font
        'Dim sb As System.Text.StringBuilder
        Dim lvi As ListViewItem
        Dim Linea As String

        ' Asignar el tipo de letra
        printFont = New System.Drawing.Font("Courier New", 12, FontStyle.Bold)
        'printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)
        Do
            'yPos += lineHeight
            lvi = Me.ListView1.Items(lineaActual)
            ' tener en cuenta el ancho de cada columna
            'sb = New System.Text.StringBuilder
            'For i As Integer = 0 To lvi.SubItems.Count - 1
            '    Linea = lvi.SubItems(i).Text
            '    sb.AppendFormat("{0}", Linea)
            'Next
            For a As Integer = 0 To 17
                yPos += lineHeight
                Select Case a
                    Case 3
                        Linea = Space(14) & lvi.SubItems(0).Text
                    Case 5
                        Linea = lvi.SubItems(1).Text
                    Case 7
                        Linea = lvi.SubItems(2).Text
                    Case 11
                        Linea = Space(5) & lvi.SubItems(3).Text
                    Case 17
                        Linea = Space(30) '& Me.dgvCheques.Rows(CInt(lvi.SubItems(4).Text)).Cells(0).Value.ToString()
                    Case Else
                        Linea = Space(50)
                End Select
                e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos)
            Next
            SqlUpd = "UPDATE [dbo].[CONTABILIDAD_CHEQUE_EMERGENCIA]" & vbCrLf
            SqlUpd &= "   SET IMPRESO = 1" & vbCrLf
            SqlUpd &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
            SqlUpd &= "   AND CHEQUE = " & Me.dgvCheques.Rows(CInt(lvi.SubItems(4).Text)).Cells(0).Value.ToString() & vbCrLf
            SqlUpd &= "   AND PERSONA = '" & Me.dgvCheques.Rows(CInt(lvi.SubItems(4).Text)).Cells(1).Value.ToString() & "'" & vbCrLf
            SqlUpd &= "   AND FECHA_CONTABLE = '" & Format(Me.dgvCheques.Rows(CInt(lvi.SubItems(4).Text)).Cells(5).Value, "dd/MM/yyyy") & "'" & vbCrLf
            jClass.Ejecutar_ConsultaSQL(SqlUpd)
            lineaActual += 1
        Loop Until yPos >= e.MarginBounds.Bottom OrElse lineaActual >= Me.ListView1.Items.Count
        '
        If lineaActual < Me.ListView1.Items.Count Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub Contabilidad_Imprimir_Cheques_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class
