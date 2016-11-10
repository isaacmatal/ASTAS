Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaCodigoDetalle
    Dim Sql As String
    Dim Iniciando As Boolean
    Private Tipo As Integer
    Dim TableData As DataTable

    Private Sub Contabilidad_BusquedaCodigoDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        BuscaCodigos()
        Me.dgvTransacciones.AutoGenerateColumns = False
        Iniciando = False
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Tipo = 0

    End Sub

    Public Sub New(ByVal tipox As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Tipo = tipox

    End Sub
    Private Sub GeneraSQL()
        Sql = " SELECT CONVERT(VARCHAR, CODIGO) AS CODIGO, DESCRIPCION " & vbCrLf
        Sql &= "  FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE" & vbCrLf
        Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        If Tipo <= 3 Then
            Sql &= "   AND TIPO = " & Tipo & vbCrLf
        End If
    End Sub

    Private Sub BuscaCodigos()
        Dim Conexion_ As New SqlConnection
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            GeneraSQL()
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            TableData = New DataTable("Datos")
            DataAdapter_.Fill(TableData)
            Me.dgvTransacciones.DataSource = TableData
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCONCEPTO.Text = ""
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BuscaCodigos()
        LimpiaCampos()
    End Sub

    Private Sub dgvTransacciones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransacciones.CellClick
        If e.RowIndex > -1 Then
            Producto = Me.dgvTransacciones.CurrentRow.Cells.Item(0).Value
            Nombre_Factura = Me.dgvTransacciones.CurrentRow.Cells.Item(1).Value
            Me.Close()
            Me.Dispose()
        Else
            Producto = ""
        End If
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONCEPTO.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = TableData.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvTransacciones.DataSource = TableData
        Else
            rows = TableData.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvTransacciones.DataSource = Nothing
            Me.dgvTransacciones.DataSource = tablaT
        End If
    End Sub

    Private Sub Contabilidad_BusquedaCodigoDetalle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class