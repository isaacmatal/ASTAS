Imports System.Data
Imports System.Data.SqlClient

Public Class Cuentas_x_Pagar_Carta_Remesas_Prov
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim sql As String
    Dim Table As DataTable
    Dim sqlCmd As New SqlCommand
    Dim Inicio As Boolean = True

    Private Sub Cuentas_x_Pagar_Carta_Remesas_Prov_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaBancos(Compañia, Me.cmbBanco)
        If Me.cmbBanco.Items.Count > 0 Then
            Me.cmbBanco.SelectedIndex = 1
        End If
        Me.crvRepRemesas.BackColor = Color.MintCream
        cargaRemesas()
        Inicio = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cargaRemesas()
        sqlCmd.CommandText = "EXECUTE [dbo].[sp_CONTABILIDAD_CATALOGO_PROVEEDORES] @COMPAÑIA = " & Compañia & ", @BANCO = " & Me.cmbBanco.SelectedValue & ", @SIUD = 'REPBCO', @FECHA = '" & Format(Me.dtpFechaInicial.Value, "dd/MM/yyyy") & "', @USUARIO ='" & Format(Me.dtpFechaFinal.Value, "dd/MM/yyyy") & "'"
        Table = jClass.obtenerDatos(sqlCmd)
        Me.cmbCorrRemesa.DataSource = Table
        Me.cmbCorrRemesa.ValueMember = "IDENTIFICADOR"
        Me.cmbCorrRemesa.DisplayMember = "ORDEN"
        If Me.cmbCorrRemesa.Items.Count > 0 Then
            Me.cmbCorrRemesa.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedIndexChanged
        If Not Inicio Then
            cargaRemesas()
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicial.ValueChanged
        If Not Inicio Then
            cargaRemesas()
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaFinal.ValueChanged
        If Not Inicio Then
            cargaRemesas()
        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim Reporte As New Contabilidad_CxP_Carta_Remesas
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        txtObj = Reporte.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        sql = "EXECUTE sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA" & vbCrLf
        sql &= " @COMPAÑIA         = " & Compañia & vbCrLf
        sql &= ",@BODEGA           = " & Me.cmbBanco.SelectedValue & vbCrLf
        sql &= ",@ORDEN_COMPRA     = 0" & vbCrLf
        sql &= ",@NOMBRE_PROVEEDOR = '" & Me.cmbCorrRemesa.SelectedValue & "'" & vbCrLf
        sql &= ",@NOMBRE_COMERCIAL = ''" & vbCrLf
        sql &= ",@NIT              = ''" & vbCrLf
        sql &= ",@NRC              = ''" & vbCrLf
        sql &= ",@FECHA_INICIAL    = '" & Format(Me.dtpFechaInicial.Value, "dd/MM/yyyy") & "'" & vbCrLf
        sql &= ",@FECHA_FINAL      = '" & Format(Me.dtpFechaFinal.Value, "dd/MM/yyyy") & "'" & vbCrLf
        sql &= ",@BANDERA          = 12" & vbCrLf
        sqlCmd.CommandText = sql
        Table = jClass.obtenerDatos(sqlCmd)
        If Table.Rows.Count > 0 Then
            Reporte.SetDataSource(Table)
            Me.crvRepRemesas.ReportSource = Reporte
        Else
            MsgBox("No hay datos para los paramétros especificados", MsgBoxStyle.Information, "Reporte")
            Me.crvRepRemesas.ReportSource = Nothing
        End If
    End Sub

    Private Sub Cuentas_x_Pagar_Carta_Remesas_Prov_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.MintCream, Color.LightSeaGreen, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class