Imports System.Data
Imports System.Data.SqlClient
Public Class FrmCooperativaReportes
    Dim Sql As String
    Dim jClass As New jarsClass
    Private Sub FrmCooperativaReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
    End Sub
    'Public Sub CargaOC(ByVal Compañia, ByVal OC)
    '    Dim Conexion_ As New SqlConnection
    '    Dim Comando_ As SqlCommand
    '    Dim DataAdapter_ As SqlDataAdapter
    '    Dim Table As DataTable
    '    Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
    '    Dim Rpt As New Cooperativa_OC
    '    Try
    '        Conexion_.Open()
    '        Sql = "Execute Coo.sp_COOPERATIVA_ORDEN_COMPRA_RPT "
    '        Sql &= Compañia
    '        Sql &= ", " & OC
    '        Comando_ = New SqlCommand(Sql, Conexion_)
    '        DataAdapter_ = New SqlDataAdapter(Comando_)
    '        Table = New DataTable("Datos")
    '        DataAdapter_.Fill(Table)
    '        Rpt.SetDataSource(Table)
    '        Me.CrvCooReporte.ReportSource = Rpt
    '        Conexion_.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub
    Public Sub ProgramacionIlustrada(ByVal Compañia, ByVal Deduccion, ByVal Num_Cuota, ByVal Monto, ByVal Periodo, ByVal Fecha_IniPres, ByVal FechaPrimerPag, ByVal TasaInt, ByVal InteresSeg, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim Rpt As New CooperativaProgIlustrativa
        Try
            Conexion_.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_ILUSTRATIVA_RPT "
            Sql &= Compañia
            Sql &= ", " & 0
            Sql &= ", '" & Deduccion & "'"
            Sql &= ", " & Num_Cuota
            Sql &= ", " & Monto
            Sql &= ", '" & Periodo & "'"
            Sql &= ", '" & Format(Fecha_IniPres, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", '" & Format(FechaPrimerPag, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", " & TasaInt
            Sql &= ", " & InteresSeg
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            Me.CrvCooReporte.ReportSource = Rpt
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ProgramacionSolicitudes(ByVal Compañia, ByVal Nom_Compañia, ByVal N_Solicitud, ByVal Deduccion, ByVal NombreSocio, ByVal Codigo_As, ByVal CodigoBuxis, ByVal Localizacion, ByVal Num_Cuota, ByVal Monto, ByVal Periodo, ByVal Fecha_IniPres, ByVal FechaPrimerPag, ByVal TasaInt, ByVal InteresSeg, ByVal Bandera)
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim fieldObj As CrystalDecisions.CrystalReports.Engine.FieldObject
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim pctr As CrystalDecisions.CrystalReports.Engine.PictureObject
        Origen = CInt(jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodigoBuxis))
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim Rpt As New CooperativaProgramacion
        Try
            Conexion_.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_RPT "
            Sql &= Compañia
            Sql &= ", '" & Nom_Compañia & "'"
            Sql &= ", " & N_Solicitud
            Sql &= ", '" & Deduccion & "'"
            Sql &= ", '" & NombreSocio & "'"
            Sql &= ", '" & Codigo_As & "'"
            Sql &= ", " & CodigoBuxis
            Sql &= ", '" & Localizacion & "'"
            Sql &= ", " & Num_Cuota
            Sql &= ", " & Monto
            Sql &= ", '" & Periodo & "'"
            Sql &= ", '" & Format(Fecha_IniPres, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", '" & Format(FechaPrimerPag, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", " & TasaInt
            Sql &= ", " & InteresSeg
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            If Origen = 5 Or Origen = 6 Then
                pctr = Rpt.Section1.ReportObjects.Item("picture1")
                pctr.ObjectFormat.EnableSuppress = True
                pctr = Rpt.Section1.ReportObjects.Item("picture2")
                pctr.ObjectFormat.EnableSuppress = False
                fieldObj = Rpt.Section1.ReportObjects.Item("NOMBRECOMPAÑIA1")
                fieldObj.ObjectFormat.EnableSuppress = True
                txtObj = Rpt.Section1.ReportObjects.Item("txtATAF")
                txtObj.ObjectFormat.EnableSuppress = False
                txtObj.Text = jClass.obtenerEscalar("SELECT NOMBRE_COMPAÑIA FROM CATALOGO_COMPAÑIAS WHERE COMPAÑIA = 2")
            End If
            Me.CrvCooReporte.ReportSource = Rpt
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ReProgramacionSolicitudes(ByVal Compañia, ByVal Nom_Compañia, ByVal N_Solicitud, ByVal Deduccion, ByVal NombreSocio, ByVal Codigo_As, ByVal CodigoBuxis, ByVal Localizacion, ByVal Num_Cuota, ByVal Monto, ByVal Periodo, ByVal FechaPrimerPag, ByVal TasaInt, ByVal InteresSeg, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim FechaPago As Date = CDate(FechaPrimerPag)
        Dim pctr As CrystalDecisions.CrystalReports.Engine.PictureObject
        Origen = CInt(jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodigoBuxis))
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Dim Rpt As New CooperativaReProgramacion
        Try
            Conexion_.Open()
            Sql = "Execute Coo.sp_COOPERATIVA_REPROGRAMACION_SOLICITUDES_RPT "
            Sql &= Compañia
            Sql &= ", '" & Nom_Compañia & "'"
            Sql &= ", " & N_Solicitud
            Sql &= ", '" & Deduccion & "'"
            Sql &= ", '" & NombreSocio & "'"
            Sql &= ", '" & Codigo_As & "'"
            Sql &= ", " & CodigoBuxis
            Sql &= ", '" & Localizacion & "'"
            Sql &= ", " & Num_Cuota
            Sql &= ", " & Monto
            Sql &= ", '" & Periodo & "'"
            Sql &= ", '" & Format(FechaPago, "dd-MM-yyyy HH:mm:ss") & "'"
            Sql &= ", " & TasaInt
            Sql &= ", " & InteresSeg
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Rpt.SetDataSource(Table)
            If Origen = 5 Or Origen = 6 Then
                pctr = Rpt.Section1.ReportObjects.Item("picture1")
                pctr.ObjectFormat.EnableSuppress = True
                pctr = Rpt.Section1.ReportObjects.Item("picture2")
                pctr.ObjectFormat.EnableSuppress = False
            End If
            Me.CrvCooReporte.ReportSource = Rpt
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    End Class