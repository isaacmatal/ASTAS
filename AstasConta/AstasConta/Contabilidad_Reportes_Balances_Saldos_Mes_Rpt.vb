Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Contabilidad_Reportes_Balances_Saldos_Mes_Rpt
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim Clas As New jarsClass
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Operar As New frmReportes_Ver
    Private Sub Contabilidad_Reportes_Balances_Saldos_Mes_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCompañia.Text = Descripcion_Compañia
        CargaLibrosContables(Compañia)
        CargaLibrosContables2(Compañia)
        Niveles()
        Iniciando = False
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS02, DS03 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(CnnStrBldr.ConnectionString)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub
#End Region

    Private Sub CargaLibrosContables(ByVal Compañia)
        Try
            DS02.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            MiddleConnection()
            DataAdapter.Fill(DS02)
            Me.cmbLIBRO_CONTABLE.DataSource = DS02.Tables(0)
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaLibrosContables2(ByVal Compañia)
        Try
            DS03.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Me.cmbLIBRO_CONTABLE2.DataSource = DS03.Tables(0)
            Me.cmbLIBRO_CONTABLE2.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE2.DisplayMember = "Descripción"
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        'If MsgBox("¿Está seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
        CargaBalanceSaldosMes(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbLIBRO_CONTABLE2.SelectedValue, Me.dpFECHA_CONTABLE.Value)
        'End If
    End Sub
    Sub CargaBalanceSaldosMes(ByVal Compañia As Integer, ByVal Libro1 As Integer, ByVal Libro2 As Integer, ByVal Fecha As DateTime)
        Dim Rpt As New Contabilidad_Reportes_Balances_Saldos_Mes
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_BALANCE_SALDOS_MES " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Libro1  & vbCrLf
            Sql &= ",@LIBRO_EQUIVALE = " & Libro2 & vbCrLf
            Sql &= ",@FECHA          = '" & Format(Fecha, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@NIVEL			= " & Me.cmbNivelCta.SelectedValue & vbCrLf
            If Me.chkValoresCero.Checked Then
                Sql &= ",@SALDOSCERO = 1" & vbCrLf
            End If
            sqlCmd.CommandText = Sql
            Table = Clas.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                Me.Label.Visible = True
                Rpt.SetDataSource(Table)
                Rpts.crvReporte.ReportSource = Rpt
                Rpts.ShowDialog()
                Me.Label.Visible = False
            Else
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub

    Private Sub Contabilidad_Reportes_Balances_Saldos_Mes_Rpt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub Niveles()
        Dim NivelTable As New DataTable
        NivelTable.Columns.Add("Nivel", Type.GetType("System.Int32"))
        NivelTable.Columns.Add("Nombre", Type.GetType("System.String"))
        NivelTable.Rows.Add(13, "DETALLE")
        NivelTable.Rows.Add(8, "SUBCUENTA")
        NivelTable.Rows.Add(6, "MAYOR")
        NivelTable.Rows.Add(4, "CUENTA")
        Me.cmbNivelCta.DataSource = NivelTable
        Me.cmbNivelCta.DisplayMember = "Nombre"
        Me.cmbNivelCta.ValueMember = "Nivel"
    End Sub
End Class