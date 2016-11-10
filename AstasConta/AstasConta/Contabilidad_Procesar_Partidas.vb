Imports System.Data.SqlClient

Public Class Contabilidad_Procesar_Partidas
    Dim Sql As String
    Dim Iniciando As Boolean
    Public LibroContable As Integer
    Dim TableData, TableRep As DataTable
    Dim UserConta As String = String.Empty

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal user As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UserConta = user

    End Sub

    Private Sub Contabilidad_Procesar_Partidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.dgvTransacciones.AutoGenerateColumns = False
        BuscaTransacciones()
        CargaLibrosContables()
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            LibroContable = CInt(Comando_.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Private Sub BuscaTransacciones()
        Dim Conexion_ As New SqlConnection
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE [dbo].[sp_CONTABILIDAD_PARTIDAS_PROCESAR_000] @COMPAÑIA = " & Compañia & ", @MES = " & Me.dpPeriodo.Value.Month & ", @AÑO=" & Me.dpPeriodo.Value.Year & IIf(UserConta.Length > 0, ", @USUARIO = '" & UserConta & "'", "")
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            TableData = New DataTable("Datos")
            DataAdapter_.Fill(TableData)
            Me.dgvTransacciones.DataSource = TableData
            Conexion_.Close()
            TableRep = TableData
            Me.selec.ReadOnly = False
            ColorRows()
            LimpiaCampos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtPARTIDA.Clear()
        Me.txtFECHACONTABLE.Clear()
        Me.txtCONCEPTO.Clear()
        Me.txtESTADO.Clear()
        Me.txtUsuario.Clear()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscaTransacciones()
        LimpiaCampos()
    End Sub

    Private Sub txtPARTIDA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPARTIDA.KeyPress
        If Char.IsControl(e.KeyChar) And Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPARTIDA.TextChanged, txtCONCEPTO.TextChanged, txtESTADO.TextChanged, txtFECHACONTABLE.TextChanged, txtUsuario.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = TableData.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvTransacciones.DataSource = TableData
            TableRep = TableData
        Else
            rows = TableData.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvTransacciones.DataSource = Nothing
            Me.dgvTransacciones.DataSource = tablaT
            TableRep = tablaT
        End If
        ColorRows()
    End Sub

    Private Sub Contabilidad_Procesar_Partidas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub chkSelec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelec.CheckedChanged
        For i As Integer = 0 To Me.dgvTransacciones.Rows.Count - 1
            If Not Me.dgvTransacciones.Rows(i).Cells("PROCESADO").Value And Me.dgvTransacciones.Rows(i).Cells("DIFERENCIA").Value = 0 And Me.dgvTransacciones.Rows(i).Cells("ESTADO").Value <> "SIN MOVIMIENTOS" Then
                Me.dgvTransacciones.Rows(i).Cells("selec").Value = chkSelec.Checked
            End If
        Next
    End Sub

    Private Sub dgvTransacciones_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTransacciones.Sorted
        ColorRows()
    End Sub

    Private Sub Procesa_Transaccion(ByVal Compañia, ByVal LibroContable, ByVal Transaccion)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ",@TRANSACCION    = " & Transaccion & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim pdaRows As Integer
        For i As Integer = 0 To Me.dgvTransacciones.Rows.Count - 1
            If Me.dgvTransacciones.Rows(i).Cells("selec").Value Then
                pdaRows += 1
            End If
        Next
        If pdaRows = 0 Then
            MsgBox("Debe seleccionar al menos" & vbCrLf & "una partida para procesar", MsgBoxStyle.Information, "Procesar")
            Return
        End If
        If MsgBox("¿Confirma que desea procesar la partidas seleccionadas?" & vbCrLf & vbCrLf & "Una vez procesadas no podrá hacer cambios solamente anular.", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            For i As Integer = 0 To Me.dgvTransacciones.Rows.Count - 1
                If Me.dgvTransacciones.Rows(i).Cells("selec").Value Then
                    Procesa_Transaccion(Compañia, LibroContable, Me.dgvTransacciones.Rows(i).Cells("Transaccion").Value)
                End If
            Next
            BuscaTransacciones()
            MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Procesar")
        End If
    End Sub

    Private Sub ColorRows()
        For i As Integer = 0 To Me.dgvTransacciones.Rows.Count - 1
            If Me.dgvTransacciones.Rows(i).Cells("DIFERENCIA").Value <> 0 Then
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.BackColor = Color.DarkOrange
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionBackColor = Color.DarkOrange
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionForeColor = Color.White
                Me.dgvTransacciones.Rows(i).Cells("selec").ReadOnly = True
            End If
            If Me.dgvTransacciones.Rows(i).Cells("ESTADO").Value = "SIN MOVIMIENTOS" Then
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.BackColor = Color.Crimson
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Crimson
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionForeColor = Color.White
                Me.dgvTransacciones.Rows(i).Cells("selec").ReadOnly = True
            End If
            If Me.dgvTransacciones.Rows(i).Cells("PROCESADO").Value Then
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionBackColor = Color.BurlyWood
                Me.dgvTransacciones.Rows(i).DefaultCellStyle.SelectionForeColor = Color.White
                Me.dgvTransacciones.Rows(i).Cells("selec").ReadOnly = True
            End If
        Next
        Me.lblNumRegs.Text = Me.dgvTransacciones.Rows.Count & " Registro" & IIf(Me.dgvTransacciones.Rows.Count = 1, "", "s")
    End Sub

    Private Sub dpPeriodo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpPeriodo.ValueChanged
        BuscaTransacciones()
    End Sub

    Private Sub Contabilidad_Procesar_Partidas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ColorRows()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim rpt As New Contabilidad_Listado_Partidas
        Dim frmVer As New frmReportes_Ver
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        rpt.SetDataSource(TableRep)
        txtObj = rpt.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt.Section2.ReportObjects.Item("txtPeriodo")
        txtObj.Text = " PERIODO: " & Me.dpPeriodo.Text.ToUpper
        frmVer.crvReporte.ReportSource = rpt
        frmVer.ShowDialog(Me)
    End Sub
End Class