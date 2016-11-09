Imports System.IO
'Imports Microsoft.Office.Interop

Public Class ExportDataExcel
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel = CreateObject("EXCEL.Application") 'As New Excel.Application
        m_Excel.Cursor = 2 'Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel = m_Excel.Workbooks.Add 'As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel = objLibroExcel.Worksheets(1) 'As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = -1 'Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "EXPORTACION A EXCEL"
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Título Reporte  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hoja de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Object 'Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                    If c.ValueType.Name.ToUpper = "DATETIME" Then
                        objCelda.EntireColumn.NumberFormat = "dd/MM/yyyy"
                    End If
                End If
            Next
            Dim objRangoEncab = objHojaExcel.Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString) 'As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, -4138) 'Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg = .Range(primeraLetra + i.ToString, strColumna + i.ToString) 'As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next
            'Dibujar el border exterior grueso  
            Dim objRango = .Range(primeraLetra + (primerNumero + 1).ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString) 'As Excel.Range = .Range(primeraLetra + (primerNumero + 1).ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.BorderAround(1, -4138) 'Excel.XlBorderWeight.xlMedium)
            objRango.Columns.Font.Name = "Courier New"
            objRango.Columns.Font.Color = RGB(0, 0, 255)
            objRango.Columns.Font.Size = 10
            objRango.Columns.AutoFit()
        End With

        m_Excel.Cursor = -4143 'Excel.XlMousePointer.xlDefault
        Dim ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ruta = ruta & "\" & titulo & " " & Now.ToString("yyyyMMdd_HHmmss") '& ".xls"
        m_Excel.ActiveWorkbook.SaveAs(ruta)
        'm_Excel.ActiveWorkbook.Close()
        'm_Excel.Quit()
    End Sub
End Class