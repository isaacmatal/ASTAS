Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Balances_Saldos_Rpt
    Dim Sql As String
    Dim Rpts As New frmReportes_Ver
    Dim jClas As New jarsClass
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand

    Private Sub Contabilidad_Reportes_Balances_Saldos_Rpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.TxtCompañia.Text = Descripcion_Compañia
        CargaLibrosContables(Compañia)
        CargaLibrosContables2(Compañia)
        Niveles()
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE @COMPAÑIA = " & Compañia
            Me.cmbLIBRO_CONTABLE.DataSource = jClas.obtenerDatos(New SqlCommand(Sql))
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaLibrosContables2(ByVal Compañia)
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE @COMPAÑIA = " & Compañia
            Me.cmbLIBRO_CONTABLE2.DataSource = jClas.obtenerDatos(New SqlCommand(Sql))
            Me.cmbLIBRO_CONTABLE2.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE2.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim Rpt As New Contabilidad_Reportes_Balances_Saldos
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Me.Label.Visible = True
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_BALANCE_SALDOS " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & vbCrLf
            Sql &= ",@LIBRO_EQUIVALE = " & Me.cmbLIBRO_CONTABLE2.SelectedValue & vbCrLf
            Sql &= ",@FECHA          = '" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ",@NIVEL			 = " & Me.cmbNivelCta.SelectedValue & vbCrLf
            If Me.chkValoresCero.Checked Then
                Sql &= ",@SIN_CERO       = 1" & vbCrLf
            End If
            sqlCmd.CommandText = Sql
            Table = jClas.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                If Me.cmbNivelCta.SelectedValue < 13 Then
                    txtObj = Rpt.ReportDefinition.ReportObjects.Item("Text6")
                    txtObj.ObjectFormat.EnableSuppress = True
                End If
                If Me.cmbNivelCta.SelectedValue < 8 Then
                    txtObj = Rpt.ReportDefinition.ReportObjects.Item("Text7")
                    txtObj.ObjectFormat.EnableSuppress = True
                End If
                If Me.cmbNivelCta.SelectedValue < 6 Then
                    txtObj = Rpt.ReportDefinition.ReportObjects.Item("Text8")
                    txtObj.ObjectFormat.EnableSuppress = True
                End If
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

    Private Sub Contabilidad_Reportes_Balances_Saldos_Rpt_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class