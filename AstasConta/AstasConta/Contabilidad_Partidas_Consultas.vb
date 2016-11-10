Imports System.Data.SqlClient

Public Class Contabilidad_Partidas_Consultas
    Dim bquery As New busquedaQuery
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim FechaInicial As Date
    Dim FechaFinal As Date
    Dim jClass As New jarsClass

    'Conexion
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table, TablePdas As DataTable
    Dim DataReader_ As SqlDataReader

    'Declaracion de variables
    Dim sql As String
    Dim Iniciando As Boolean

    'Carga de valores al inicio del formulario
    Private Sub Contabilidad_Partidas_Consultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaLibrosContables(Compañia, cmbLIBRO_CONTABLE)
        fill.CargaTipoDocumento(Compañia, cmbTIPO_DOCUMENTO)
        Iniciando = False
        FechaInicial = Me.dpFechaDesde.Value.AddDays(-Me.dpFechaDesde.Value.Day + 1)
        FechaFinal = FechaInicial.AddMonths(1).AddDays(-1)
        Me.cargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, 0, False, FechaInicial, FechaFinal, "", "", Me.txtDocumento.Text, 0)
        Me.dgvPartidas.AutoGenerateColumns = False
        Me.dgvPartCon.AutoGenerateColumns = False
        Me.dgvPartDet.AutoGenerateColumns = False
    End Sub

    Public Function buscaCTA() As String
        Dim cuentas As New Contabilidad_BusquedaCuentas
        Dim cuenta As String = ""
        Dim descripcion As String = ""
        Tipo = ""
        cuentas.Compañia_Value = Compañia
        cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        cuentas.cmbLIBRO_CONTABLE.Enabled = False
        cuentas.ShowDialog()
        If Tipo <> "" Then
            cuenta = Tipo
            Tipo = ""
            busqueda(Compañia, cmbLIBRO_CONTABLE.SelectedValue, cuenta, descripcion)
        End If
        Return cuenta
    End Function

    Private Sub busqueda(ByVal compañia, ByVal libroCont, ByVal cuenta, ByVal descrip)
        Dim datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_BUSQUEDA '" & compañia & "', '" & libroCont & "', '" & cuenta & "', '" & descrip & "' "
            Comando_ = New SqlCommand(sql, Conexion_)
            datareader_ = Comando_.ExecuteReader
            If datareader_.Read = False Then
                MsgBox("No existe la Cuenta N° " & cuenta, MsgBoxStyle.Critical, "Mensaje")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        Dim FechaInicial As Date = Me.dpFechaDesde.Value.AddDays(-Me.dpFechaDesde.Value.Day + 1)
        Dim FechaFinal As Date = FechaInicial.AddMonths(1).AddDays(-1)
        cargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, False, FechaInicial, FechaFinal, "", "", Me.txtDocumento.Text, "")
    End Sub

    Private Sub cargaPartida(ByVal compañia, ByVal libroCont, ByVal tipoDoc, ByVal chkFecha, ByVal fDesde, ByVal fHasta, ByVal cInicial, ByVal cFinal, ByVal documento, ByVal cTrans)
        Dim consulta As String = ""
        consulta = bquery.generarQueryBusqueda(compañia, libroCont, tipoDoc, chkFecha, fDesde, fHasta, cInicial, cFinal, documento, cTrans)
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            TablePdas = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, consulta, TablePdas)
            'Me.dgvPartidas.Columns.Clear()
            Me.dgvPartidas.DataSource = TablePdas
            'fill.ajustarGrid(10, Me.dgvPartidas)
            Conexion_.Close()
            If TablePdas.Rows.Count > 0 Then
                mostrarConsolidacion(compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.TablePdas.Rows(0).Item(0))
                mostrarDetalle(compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.TablePdas.Rows(0).Item(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgvPartidas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartidas.CellClick
        If Not Iniciando Then
            Try
                If Me.dgvPartidas.RowCount = 0 Then
                    mostrarConsolidacion(0, 0, 0)
                    mostrarDetalle(0, 0, 0)
                    Return
                Else
                    If Me.dgvPartidas.CurrentRow.Index < Me.dgvPartidas.Rows.Count Then
                        'Variable para almacenar el valor de cmblibro_contable
                        Dim lc As String = ""
                        lc = Me.cmbLIBRO_CONTABLE.SelectedValue
                        Producto = Me.dgvPartidas.CurrentRow.Cells.Item(0).Value
                        Me.Txt_Transac.Text = Producto
                        If Producto <> Nothing Then
                            mostrarDetalle(Compañia, lc, Producto)
                            mostrarConsolidacion(Compañia, lc, Producto)
                        End If
                    Else
                        Producto = ""
                        Tipo = ""
                        Descripcion_Producto = ""
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    Private Sub mostrarDetalle(ByVal cia, ByVal lc, ByVal trans)
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_PARTIDAS_DETALLE "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & trans
            sql &= ", 6"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            If Table.Rows.Count > 0 Then
                Me.dgvPartDet.DataSource = Table
                'fill.ajustarGrid(4, Me.dgvPartDet)
            Else
                While Me.dgvPartDet.Rows.Count > 0
                    Me.dgvPartDet.Rows.RemoveAt(0)
                End While
                MsgBox("No existe detalle para esta partida", MsgBoxStyle.Information, "Mensaje")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub mostrarConsolidacion(ByVal cia, ByVal lc, ByVal trans)
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_PARTIDAS_DETALLE "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & trans
            sql &= ", 3"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            If Table.Rows.Count > 0 Then
                'Me.dgvPartCon.Columns.Clear()
                Me.dgvPartCon.DataSource = Table
                'fill.ajustarGrid(4, Me.dgvPartCon)
            Else
                While Me.dgvPartCon.Rows.Count > 0
                    Me.dgvPartCon.Rows.RemoveAt(0)
                End While
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Dim _error_ As Boolean = False
        Dim Transacciones As String = String.Empty
        Dim TransaccionIni As String = CInt(jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND PARTIDA = " & Val(Me.txtDesde.Text) & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Year)).ToString()
        If Val(Me.txtDesde.Text) > 0 And Val(Me.txtHasta.Text) > 0 Then
            If Val(TransaccionIni) = 0 Then
                MsgBox("Número Partida Inicial no válido", MsgBoxStyle.Information, "Imprimir Partidas")
                _error_ = True
                Return
            End If
            Dim TransaccionFin As String = CInt(jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND PARTIDA = " & Val(Me.txtHasta.Text) & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Year)).ToString()
            If Val(TransaccionFin) = 0 Then
                MsgBox("Número Partida Final no válido", MsgBoxStyle.Information, "Imprimir Partidas")
                _error_ = True
                Return
            End If
            If Val(TransaccionFin) < Val(TransaccionIni) Then
                MsgBox("Número Partida Final no puede ser menor que la Inicial", MsgBoxStyle.Information, "Imprimir Partidas")
                _error_ = True
                Return
            End If
            For i As Integer = CInt(Me.txtDesde.Text) To CInt(Me.txtHasta.Text)
                If i = CInt(Me.txtDesde.Text) Then
                    Transacciones &= CInt(jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND PARTIDA = " & i & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Year)).ToString()
                Else
                    Transacciones &= "," & CInt(jClass.obtenerEscalar("SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND PARTIDA = " & i & " AND MONTH(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Month & " AND YEAR(FECHA_CONTABLE) = " & Me.dpFechaDesde.Value.Year)).ToString()
                End If
            Next
            'Rpts.CargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, TransaccionIni, TransaccionFin, Me.dpFechaDesde.Value.Year, Me.dpFechaDesde.Value.Month, 1)
            Rpts.CargaPartidaIN(Me.cmbLIBRO_CONTABLE.SelectedValue, Transacciones)
        Else
            If Me.dgvPartidas.Rows.Count > 0 Then
                Rpts.CargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.dgvPartidas.CurrentRow.Cells.Item(0).Value, Me.dgvPartidas.CurrentRow.Cells.Item(0).Value, Year(CDate(Me.dgvPartidas.CurrentRow.Cells.Item(3).Value)), Month(CDate(Me.dgvPartidas.CurrentRow.Cells.Item(3).Value)), 1)
            End If
        End If
        If Me.dgvPartidas.Rows.Count > 0 Then
            Rpts.chkNoDet.Visible = True
            Rpts.ShowDialog()
        End If
    End Sub

    Private Sub BusquedaDinamica(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPARTIDA.TextChanged, txtCONCEPTO.TextChanged, txtDocumento.TextChanged, txtESTADO.TextChanged, txtFECHACONTABLE.TextChanged, txtUsuario.TextChanged
        Dim rows As DataRow()
        Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim tablaT As DataTable = TablePdas.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
        If sender.Text = "" Then
            Me.dgvPartidas.DataSource = TablePdas
        Else
            rows = TablePdas.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next
            Me.dgvPartidas.DataSource = Nothing
            Me.dgvPartidas.DataSource = tablaT
        End If
    End Sub

    Private Sub cmbTIPO_DOCUMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_DOCUMENTO.SelectedIndexChanged
        If Not Iniciando Then
            If sender.SelectedValue = 0 Then
                Me.dgvPartidas.DataSource = TablePdas
            Else
                Dim rows As DataRow()
                Dim Ncolumn As String = sender.Tag 'Obtiene el Nombre de Columna actual del DataGridView.
                Dim tablaT As DataTable = TablePdas.Clone 'Se crea un DataTable temporal en base a la Vista del DataTable Actual.
                If sender.Text = "" Then
                    Me.dgvPartidas.DataSource = TablePdas
                Else
                    rows = TablePdas.Select("[" & Ncolumn & "] like '" & sender.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow.
                    For i As Integer = 0 To rows.Length - 1
                        tablaT.ImportRow(rows(i))
                    Next
                    Me.dgvPartidas.DataSource = Nothing
                    Me.dgvPartidas.DataSource = tablaT
                End If
            End If
        End If
    End Sub

    Private Sub dpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaDesde.ValueChanged
        Dim FechaInicial As Date = Me.dpFechaDesde.Value.AddDays(-Me.dpFechaDesde.Value.Day + 1)
        Dim FechaFinal As Date = FechaInicial.AddMonths(1).AddDays(-1)
        cargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, False, FechaInicial, FechaFinal, "", "", Me.txtDocumento.Text, "")
        Me.dgvPartCon.DataSource = Nothing
        Me.dgvPartDet.DataSource = Nothing
    End Sub

    Private Sub Contabilidad_Partidas_Consultas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub
End Class