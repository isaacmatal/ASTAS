Imports System.Data.SqlClient

Public Class Contabilidad_BusquedaTransaccion
    Dim Sql As String
    Dim Iniciando As Boolean
    Public Compañia_Value As Integer
    Public LibroContable_Value As Integer
    Dim TableData As DataTable

    Private Sub Contabilidad_BusquedaTransaccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        CargaLibrosContables(Compañia)
        Me.cmbLIBRO_CONTABLE.SelectedValue = LibroContable_Value
        BuscaTransacciones()
        Me.dgvTransacciones.AutoGenerateColumns = False
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GeneraSQL()
        Dim Condicion As String
        Condicion = ""
        Sql = " SELECT TRANSACCION," & vbCrLf
        Sql &= "       DOCUMENTO, " & vbCrLf
        Sql &= "       CONVERT(VARCHAR, PARTIDA) AS [PARTIDA]," & vbCrLf
        Sql &= "       CONVERT(VARCHAR, FECHA_CONTABLE, 103) AS [FECHA_CONTABLE], " & vbCrLf
        Sql &= "       CONCEPTO," & vbCrLf
        Sql &= "       (CASE ANULADA WHEN 1 THEN 'ANULADA' ELSE CASE PROCESADO WHEN 1 THEN 'PROCESADA' ELSE 'NO PROCESADA' END END) AS [ESTADO], " & vbCrLf
        Sql &= "       (SELECT PARTIDA FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = VISTA_CONTABILIDAD_PARTIDAS_ENCABEZADO.COMPAÑIA AND TRANSACCION = VISTA_CONTABILIDAD_PARTIDAS_ENCABEZADO.TRANSACCION_ANULA) AS [PARTIDA_ANULA]," & vbCrLf
        Sql &= "       USUARIO_CREACION," & vbCrLf
        Sql &= "       CONVERT(VARCHAR, USUARIO_CREACION_FECHA, 103) AS [USUARIO_CREACION_FECHA] " & vbCrLf
        Sql &= "  FROM VISTA_CONTABILIDAD_PARTIDAS_ENCABEZADO" & vbCrLf
        Sql &= " WHERE COMPAÑIA = " & Compañia & vbCrLf
        Sql &= "   AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & vbCrLf
        If Trim(Me.txtDOCUMENTO.Text).Length > 0 Then
            Condicion &= "   AND DOCUMENTO LIKE '%" & Trim(Me.txtDOCUMENTO.Text) & "%'" & vbCrLf
        End If
        If Trim(Me.txtPARTIDA.Text).Length > 0 Then
            Condicion &= "   AND PARTIDA = " & Me.txtPARTIDA.Text
        End If
        If Trim(Me.txtCONCEPTO.Text).Length > 0 Then
            Condicion &= "   AND CONCEPTO LIKE '%" & Trim(Me.txtCONCEPTO.Text) & "%'" & vbCrLf
        End If
        Condicion &= "   AND CONVERT(DATE, FECHA_CONTABLE)>= CONVERT(DATE, '" & Format(Me.dpFECHA_INI.Value, "dd/MM/yyyy") & "', 103) AND CONVERT(DATE, FECHA_CONTABLE) <= CONVERT(DATE, '" & Format(Me.dpFECHA_FIN.Value, "dd/MM/yyyy") & "', 103) "
        Sql &= Condicion
    End Sub

    Private Sub BuscaTransacciones()
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
        Me.txtDOCUMENTO.Text = ""
        Me.txtPARTIDA.Text = ""
        Me.txtCONCEPTO.Text = ""
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

    Private Sub dgvTransacciones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransacciones.CellClick
        If e.RowIndex > -1 Then
            Producto = Me.dgvTransacciones.CurrentRow.Cells.Item(0).Value
            Me.Close()
            Me.Dispose()
        Else
            Producto = ""
        End If
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPARTIDA.TextChanged, txtCONCEPTO.TextChanged, txtDOCUMENTO.TextChanged, txtESTADO.TextChanged, txtFECHACONTABLE.TextChanged, txtUsuario.TextChanged
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

    Private Sub Contabilidad_BusquedaTransaccion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class