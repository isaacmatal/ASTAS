Imports System.Data
Imports System.Data.SqlClient

Public Class frm_reporte_retiro_asociacion
    Public ID_Retiro, Accion As String
    Dim jClass As New jarsClass

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Reporte(ID_Retiro, Accion)
    End Sub

#Region "Connection"

    'Dim DLLConexion As New DLLConnection.Connection
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
    Dim DS04, DS05, DS06 As New DataSet()
    Dim SQL As String

    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter.Dispose()
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

#Region "Busqueda Socio"
    Sub BusquedaSocio()
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2


        Dim Prin As New Busquedas_empleados_avicola
        Prin.Compañia_Value = Compañia
        Prin.CbxCompania.Enabled = False
        AppPath = System.IO.Directory.GetCurrentDirectory
        Prin.ShowDialog()
        If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
            Reporte(ID_Retiro, Accion)
        End If

    End Sub

#End Region

#Region "Reporte cooperativa socios ahorros historial"
    Public Sub Reporte(ByVal ID_Retiro, ByVal Accion)
        Dim deudas As Double
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table, TableDeudas As DataTable
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        'Dim DUI As String
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        'Dim Rpt As New rpt_Cooperativa_socio_porcentaje_ahorro_historial
        Dim Rpt As New rpt_reporte_retiro_asociacion
        Try
            deudas = jClass.obtenerEscalar("SELECT TOTAL_DEUDAS + TOTAL_INTERESES + TOTAL_SEGURO_DEUDA AS DEUDA_PAGADA FROM COOPERATIVA_SOCIO_RETIROS WHERE COMPAÑIA = " & Compañia & " AND RETIRO = " & ID_Retiro)
            Conexion_.Open()
            SQL = "SELECT COMPAÑIA, NOMBRE_COMPAÑIA, NIT, CODIGO_EMPLEADO [Cod Buxis], CODIGO_EMPLEADO_AS [Cod AS], NOMBRE_COMPLETO," & vbCrLf
            SQL &= "Retiro, (Escolaridad - ISR + AHORRO_O + AHORRO_OE - " & Format(deudas, "0.00") & ") as Monto, AHORRO_O, AHORRO_OE , Escolaridad, ISR, (AHORRO_O + AHORRO_OE) [Ahorro Total]," & vbCrLf
            SQL &= "CANTIDAD_LETRAS, NIT_SOCIO, DUI, " & Format(deudas, "0.00") & " AS TOTAL_DEUDAS" & vbCrLf
            SQL &= "FROM VISTA_COOPERATIVA_RETIRO_ASOCIACION" & vbCrLf
            SQL &= "WHERE COMPAÑIA= " & Compañia & " AND" & vbCrLf
            SQL &= "CODIGO_EMPLEADO=" & ParamcodigoBux & " AND" & vbCrLf
            SQL &= "CODIGO_EMPLEADO_AS=" & ParamcodigoAs & " AND" & vbCrLf
            SQL &= "RETIRO=" & ID_Retiro
            'SQL = "EXECUTE sp_SELECT_VISTA_COOPERATIVA_RETIRO_ASOCIACION " & Compañia & "," & ParamcodigoBux & ",'" & ParamcodigoAs & "'," & ID_Retiro & ",'SE'"
            Comando_ = New SqlCommand(SQL, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            SQL = "SELECT E.ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS E" & vbCrLf
            SQL &= " WHERE E.COMPAÑIA = " & Compañia & vbCrLf
            SQL &= "   AND E.CODIGO_EMPLEADO = " & ParamcodigoBux & vbCrLf
            SQL &= "   AND E.CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "'"
            Origen = CInt(jClass.obtenerEscalar(SQL))
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            TableDeudas = New DataTable("Deudas")
            SQL = "SELECT D.DEDUCCION AS TIPO_SOLI, D.DESCRIPCION_DEDUCCION AS [DESCRIPCION DEDUCCION], E.MONTO_PRESTAMO AS DEUDA, E.PRESTAMO AS Deduccion" & vbCrLf
            SQL &= "FROM [dbo].[COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO] E, COOPERATIVA_CATALOGO_DEDUCCIONES D" & vbCrLf
            SQL &= "WHERE E.COMPAÑIA = D.COMPAÑIA" & vbCrLf
            SQL &= "  AND E.PRESTAMO = D.DEDUCCION" & vbCrLf
            SQL &= "  AND E.COMPAÑIA = " & Compañia & vbCrLf
            SQL &= "  AND E.DEDUCCION = " & ID_Retiro & vbCrLf
            SQL &= "  AND E.CODIGO_EMPLEADO = " & ParamcodigoBux & vbCrLf
            SQL &= "  AND E.CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "'"
            DataAdapter_.SelectCommand.CommandText = SQL '"EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & ParamcodigoAs & "'," & ParamcodigoBux & ",'TDXSOLI'"
            DataAdapter_.Fill(TableDeudas)
            Rpt.Subreports.Item(0).SetDataSource(TableDeudas)
            If TableDeudas.Rows.Count > 0 Then
                Rpt.Subreports.Item(0).ReportDefinition.Sections.Item("ReportHeaderSection1").SectionFormat.EnableSuppress = False
                Rpt.Subreports.Item(0).ReportDefinition.Sections.Item("ReportHeaderSection2").SectionFormat.EnableSuppress = False
                Rpt.Subreports.Item(0).ReportDefinition.Sections.Item("DetailSection1").SectionFormat.EnableSuppress = False
                Rpt.Subreports.Item(0).ReportDefinition.Sections.Item("ReportFooterSection1").SectionFormat.EnableSuppress = False
            End If
            'Comando_.CommandText = "SELECT DUI FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & ParamcodigoBux & " AND CODIGO_EMPLEADO_AS = '" & ParamcodigoAs & "' AND COMPAÑIA = " & Compañia
            'DUI = Comando_.ExecuteScalar
            'txtObj = Rpt.Section3.ReportObjects.Item("txtDUI")
            'txtObj.Text = DUI
            Comando_.CommandText = "SELECT CUENTA_CONTABLE_BANCO FROM COOPERATIVA_SOCIO_RETIROS WHERE RETIRO = " & ID_Retiro & " AND COMPAÑIA = " & Compañia
            Accion = Comando_.ExecuteScalar.ToString
            txtObj = Rpt.Section3.ReportObjects.Item("txtEncab")
            txtObj.Text = "LIQUIDACION POR RETIRO DE LA " & IIf(Accion = "1", "EMPRESA", "ASOCIACION")
            Comando_.CommandText = "SELECT COMENTARIO FROM COOPERATIVA_SOCIO_RETIROS WHERE RETIRO = " & ID_Retiro & " AND COMPAÑIA = " & Compañia
            Accion = Comando_.ExecuteScalar.ToString
            txtObj = Rpt.Section3.ReportObjects.Item("txtMotivo")
            txtObj.Text = "Motivo Retiro: " & Accion
            If Origen = 5 Or Origen = 6 Then
                Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                Rpt.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                Rpt.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                txtObj = Rpt.Section3.ReportObjects.Item("Text2")
                txtObj.Text = "NIT 0501-200694-101-6"
            End If
            Me.CrystalReportViewer1.ReportSource = Rpt
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region


End Class