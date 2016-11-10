Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Contabilidad_Reportes_Balances_Comprobacion_Rpt
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Private Sub Contabilidad_Reportes_Balances_Comprobacion_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaLibrosContables(Me.cmbCOMPA�IA.SelectedValue)
        CargaLibrosContables2(Me.cmbCOMPA�IA.SelectedValue)
        Iniciando = False
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02, DS03 As New DataSet()
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
    Private Sub CargaCompa�ia()
        Try
            DS01.Reset()
            OpenConnection()
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            Me.cmbCOMPA�IA.DataSource = DS01.Tables(0)
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
            CloseConnection()
            Me.cmbCOMPA�IA.SelectedValue = Compa�ia
            Me.cmbCOMPA�IA.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaLibrosContables(ByVal Compa�ia)
        Try
            DS02.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            MiddleConnection()
            DataAdapter.Fill(DS02)
            Me.cmbLIBRO_CONTABLE.DataSource = DS02.Tables(0)
            Me.cmbLIBRO_CONTABLE.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripci�n"
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub CargaLibrosContables2(ByVal Compa�ia)
        Try
            DS03.Reset()
            OpenConnection()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            MiddleConnection()
            DataAdapter.Fill(DS03)
            Me.cmbLIBRO_CONTABLE2.DataSource = DS03.Tables(0)
            Me.cmbLIBRO_CONTABLE2.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE2.DisplayMember = "Descripci�n"
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        'If MsgBox("�Est� seguro(a) que desea emitir el informe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
        Me.Label.Visible = True
        Application.DoEvents()
        Rpts.CargaBalanceComprobaci�n(Me.cmbCOMPA�IA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbLIBRO_CONTABLE2.SelectedValue, Me.dpFECHA_CONTABLE.Value, 3)
        If Hay_Datos Then
            Rpts.ShowDialog()
        End If
        Me.Label.Visible = False
        'End If
    End Sub

    Private Sub Contabilidad_Reportes_Balances_Comprobacion_Rpt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class