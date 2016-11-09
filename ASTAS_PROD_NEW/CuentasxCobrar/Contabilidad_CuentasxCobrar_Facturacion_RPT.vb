Imports System.Data.SqlClient

Public Class Contabilidad_CuentasxCobrar_Facturacion_RPT

    'Constructor
    Dim fill As New jarsClass
    Dim ProcesosContables As New Contabilidad_Procesos
    Dim NL As New NumeroLetras

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean

    'Variables que reciben los parametros
    Public cia As Integer
    Public bodega As Integer
    Public ov As Integer
    Public factura As Integer
    Public tipoDoc As Integer
    Public totalFact As Double
    Public flag As Integer
    Public Municipio As String
    Public Multiple As Boolean
    Public Depto As String
    Public Pais As String

    'Instancia de reportes
    Dim Rpt1 As New Facturacion_Factura_Consumidor_Final_Almacen
    Dim Rpt2 As New Contabilidad_CuentasxCobrar_Facturacion_Reportes_CCF

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Cuando carga el formulario
    Private Sub Contabilidad_CuentasxCobrar_Facturacion_RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        If Multiple = True Then
            Dim cadena As String
            Dim posicion As Integer
            cadena = Trim(Pais) & Trim(Municipio) & "/"
            posicion = Trim(cadena).Length
            cadena &= Depto
            cargaMultiplesRPT(cia, bodega, tipoDoc, cadena, posicion, flag)
        Else
            cargarRPT(cia, bodega, ov, factura, tipoDoc, totalFact, flag)
        End If
        Iniciando = False
    End Sub

    'Carga el reporte para un CF/CCF simple
    Private Sub cargarRPT(ByVal cia As Integer, ByVal bodega As Integer, ByVal ov As Integer _
                          , ByVal factura As Integer, ByVal tipoDoc As Integer, ByVal totalFact As Double _
                          , ByVal flag As Integer)
        Conexion_ = fill.devuelveCadenaConexion()
        Dim documento As CrystalDecisions.CrystalReports.Engine.ReportClass
        Try
            Conexion_.Open()
            If tipoDoc = 1 Then
                documento = Rpt1
                sql = "EXECUTE sp_FACTURACION_IMPRIME_FACTURA_CONSUMIDOR_FINAL " & vbCrLf
                sql &= "  @TIPO_DOCUMENTO = " & tipoDoc & vbCrLf
                sql &= ", @NUMERO_DOCUMENTO = " & factura & vbCrLf
                sql &= ", @BANDERA = 0" & vbCrLf
                sql &= ", @COMPAÑIA = " & Compañia & vbCrLf
                sql &= ", @BODEGA = " & bodega
                sql &= ", @OV = " & ov
            Else
                documento = Rpt2
                sql = "Execute sp_FACTURACION_GENERADA_REPORTES_CCF "
                sql &= cia
                sql &= ", " & bodega
                sql &= ", " & ov
                sql &= ", " & factura
                sql &= ", " & tipoDoc
                sql &= ", '" & NL.Letras(totalFact.ToString) & "'"
                sql &= ", '" & Municipio & "'"
                sql &= ", '" & Depto & "'"
                sql &= ", '" & Pais & "'"
                sql &= ", " & flag
            End If
            'sql &= cia
            'sql &= ", " & bodega
            'sql &= ", " & ov
            'sql &= ", " & factura
            'sql &= ", " & tipoDoc
            'sql &= ", '" & NL.Letras(totalFact.ToString) & "'"
            'If tipoDoc = 2 Then
            '    sql &= ", '" & Municipio & "'"
            '    sql &= ", '" & Depto & "'"
            '    sql &= ", '" & Pais & "'"
            'End If
            'sql &= ", " & flag
            'TODO manejo de Impresión Personalizado
            Dim instance As New Printing.PrinterSettings
            Dim impresorPredt As String = instance.PrinterName
            'Dim print_name As String = Configuration.ConfigurationSettings.AppSettings("ImpresorASTAS")
            Dim print_name As String = impresorPredt
            'Obtener nombre de hoja personalizada

            Dim print_paper As String
            'If tipoDoc = 1 Then
            '    print_paper = Configuration.ConfigurationSettings.AppSettings("FacturaCF")
            'Else
            '    print_paper = Configuration.ConfigurationSettings.AppSettings("FacturaCCF")
            'End If

            If tipoDoc = 1 Then
                print_paper = fill.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 37").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCF")
            Else
                print_paper = fill.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 38").ToString().Trim() 'Configuration.ConfigurationSettings.AppSettings("FacturaCCF")
            End If

            'Opciones del Crystal Report
            Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
            'Se aplican al informe
            With documento
                'Se obtienen la opciones de impresion
                repOptions = .PrintOptions
                'Se setean las opciones
                With repOptions
                    'Obtiene el id del papel --> utiliza una función especial
                    .PaperSize = GetPapersizeID(print_name, print_paper)
                    'Señala la impresora a utilizar
                    .PrinterName = print_name
                End With
            End With
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            documento.SetDataSource(Table)
            Me.crvReporte.ReportSource = documento
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Carga el reporte para multiples CF/CCF
    Private Sub cargaMultiplesRPT(ByVal cia As Integer, ByVal bodega As Integer _
                                  , ByVal doc As Integer, ByVal cadena As String _
                                  , ByVal pos As Integer, ByVal flag As Integer)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_HISTORIAL_FACTURAS_GENERADAS_REPORTES "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & doc
            sql &= ", '" & cadena & "'"
            sql &= ", " & pos
            sql &= ", '" & Format(Now, "dd-MMM-yyyy") & "'"
            sql &= ", " & flag
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            If doc = 1 Then
                Rpt1.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt1
            Else
                Rpt2.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt2
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'TODO Función para recuperación de Tamaño de PApel Personalizado
    Public Function GetPapersizeID(ByVal PrinterName As String, ByVal PaperSizeName As String) As Integer
        Dim pdprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        pdprint.PrinterSettings.PrinterName = PrinterName
        For i As Integer = 0 To pdprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = PaperSizeName
            If pdprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(pdprint.PrinterSettings.PaperSizes(i).RawKind)
                PaperSizeID = rawKind
                Exit For
            End If
        Next
        Return PaperSizeID
    End Function

End Class