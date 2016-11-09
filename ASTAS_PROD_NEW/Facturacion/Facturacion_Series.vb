Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Facturacion_Series

    Dim fill As New cmbFill

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Declaracion de variables
    Dim Iniciando As Boolean
    Dim sql As String = ""

    Private Sub Facturacion_Series_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        fill.CargaBodegaSeguridadUsuario(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA)
        fill.CargaTipoDocumentoFact(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTIPO_DOCUMENTO)
        cargaSeries(1, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
        Iniciando = False
    End Sub

    Private Sub txtCoInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoInicial.KeyPress
        fill.soloNumeros(e)
    End Sub

    Private Sub txtCoFinal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoFinal.KeyPress
        fill.soloNumeros(e)
    End Sub

    Private Sub txtCoActual_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoActual.KeyPress
        fill.soloNumeros(e)
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        fill.noComillaSimple(e)
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            limpiaCampos()
            cargaSeries(1, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String = ""
        Dim msj_parcial As String
        If valCamposVacios() = Nothing And valCorrelativos() = Nothing Then
            If Trim(Me.txtSerie.Text) <> Nothing Then
                IUD = "U"
                msj_parcial = "modificar"
            Else
                IUD = "I"
                msj_parcial = "agregar"
            End If
            If MsgBox("¿Está seguro que desea " & msj_parcial & " la serie de facturacion?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                mantenimientoFactSeries(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtSerie.Text, Me.txtDescripcion.Text, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtCoInicial.Text, Me.txtCoFinal.Text, Me.txtCoActual.Text, Me.chkActiva.CheckState, Me.chkFactLibre.CheckState, Me.dpFechaInicial.Value, Me.dpFechaFinal.Value, IUD, Me.TxtN_Resolucion.Text)
                cargaSeries(1, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
                limpiaCampos()
            End If
            
        End If
    End Sub

    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Me.txtDescripcion.Text = Nothing Then
            camposVacios = vbCrLf & "Descripción"
        End If
        If Me.txtCoInicial.Text = Nothing Then
            camposVacios &= vbCrLf & "Cuota Inicial"
        End If
        If Me.txtCoFinal.Text = Nothing Then
            camposVacios &= vbCrLf & "Cuota Final"
        End If
        If Me.txtCoActual.Text = Nothing Then
            camposVacios &= vbCrLf & "Cuota Actual"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe completar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Function valCorrelativos()
        Dim valorCuotas As String = ""
        If Val(Me.txtCoInicial.Text) >= Val(Me.txtCoFinal.Text) Then
            valorCuotas = "Correlativo Inicial no puede ser mayor o igual al Correlativo Final" & vbCrLf
        End If
        If Val(Me.txtCoActual.Text) > Val(Me.txtCoFinal.Text) Then
            valorCuotas &= "Correlativo Actual no puede ser mayor al Correlativo Final" & vbCrLf
        End If
        If Val(Me.txtCoActual.Text) < Val(Me.txtCoInicial.Text) Then
            valorCuotas &= "Correlativo Actual no puede ser menor al Correlativo Inicial"
        End If
        If valorCuotas <> Nothing Then
            MsgBox(valorCuotas, MsgBoxStyle.Information, "Mensaje")
        End If
        Return valorCuotas
    End Function

    Private Sub mantenimientoFactSeries(ByVal compañia, ByVal bodega, ByVal serie, ByVal descripSerie, ByVal tipoDoc, ByVal coInicial, ByVal coFinal, ByVal coActual, ByVal activa, ByVal libre, ByVal fechaInicial, ByVal fechaFinal, ByVal IUD, ByVal Resolucion)
        Dim res As Integer = 0
        If serie = Nothing Then
            serie = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_IUD "
            sql &= compañia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", '" & descripSerie & "' "
            sql &= ", " & tipoDoc
            sql &= ", " & coInicial
            sql &= ", " & coFinal
            sql &= ", " & coActual
            sql &= ", " & activa
            sql &= ", " & libre
            sql &= ", '" & Format(fechaInicial, "dd-MM-yyyy HH:mm:ss") & "' "
            sql &= ", '" & Format(fechaFinal, "dd-MM-yyyy HH:mm:ss") & "' "
            sql &= ", " & Usuario
            sql &= ", " & IUD
            sql &= ", '" & Resolucion & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res > 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Serie de Facturación almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Serie de Facturación actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Serie de Facturación eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                End Select
            ElseIf res = -1 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Serie de Facturación NO almacenados", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Serie de Facturación NO actualizados", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Serie de Facturación NO eliminados", MsgBoxStyle.Information, "Mensaje")
                End Select
            End If
            Conexion_.Close()
        Catch ex As SqlClient.SqlException
            If ex.Number = 547 Then
                MsgBox("¡Este registro tiene dependencias, no podrá eliminarlo!", MsgBoxStyle.Critical, "Mensaje")
            Else
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub cargaSeries(ByVal flag, ByVal cia, ByVal bodega)
        If bodega = Nothing Then
            bodega = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS "
            sql &= flag
            sql &= ", " & cia
            sql &= ", " & bodega
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvSeriesFact.Columns.Clear()
            Me.dgvSeriesFact.DataSource = Table
            Me.dgvSeriesFact.Columns.Item(2).Visible = False
            Me.dgvSeriesFact.Columns.Item(13).Visible = False
            Me.dgvSeriesFact.Columns.Item(14).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(15, Me.dgvSeriesFact)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub cargaSeriesBusquedas(ByVal cia As Integer, ByVal bodega As Integer, ByVal descripcion As String _
                                     , ByVal tipoDoc As Integer, ByVal flag As Integer)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_SERIES_CORRELATIVOS_BUSQUEDAS "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", '" & descripcion & "'"
            sql &= ", " & tipoDoc
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvSeriesFact.Columns.Clear()
            Me.dgvSeriesFact.DataSource = Table
            Me.dgvSeriesFact.Columns.Item(2).Visible = False
            Me.dgvSeriesFact.Columns.Item(13).Visible = False
            Me.dgvSeriesFact.Columns.Item(14).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(15, Me.dgvSeriesFact)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.txtCoActual.Enabled = True
        limpiaCampos()
    End Sub

    Private Sub limpiaCampos()
        Me.txtDescripcion.Clear()
        Me.txtCoInicial.Clear()
        Me.txtCoFinal.Clear()
        Me.txtCoActual.Clear()
        Me.txtSerie.Clear()
        Me.TxtN_Resolucion.Clear()
        Me.dpFechaInicial.Value = Now
        Me.dpFechaFinal.Value = Now
        Me.chkActiva.Checked = True
        Me.chkFactLibre.Checked = False
    End Sub

    Private Sub cargaCMB()
        fill.CargaBodega(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA)
        fill.CargaTipoDocumentoFact(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTIPO_DOCUMENTO)
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvSeriesFact.RowCount <> 0 Then
            If Me.txtSerie.Text <> Nothing And Me.txtSerie.Text <> "0" Then
                If MsgBox("¿Está seguro(a) que desea eliminar la Serie Nº " & Me.txtSerie.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    mantenimientoFactSeries(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtSerie.Text, Me.txtDescripcion.Text, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtCoInicial.Text, Me.txtCoFinal.Text, Me.txtCoActual.Text, Me.chkActiva.CheckState, Me.chkFactLibre.CheckState, Me.dpFechaInicial.Value, Me.dpFechaFinal.Value, "D", Me.TxtN_Resolucion.Text)
                    limpiaCampos()
                    Me.txtCoActual.Enabled = True
                    cargaSeries(1, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue)
                Else
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                MsgBox("Debe seleccionar una Serie válida.", MsgBoxStyle.Critical, "Mensaje")
            End If
        Else
            MsgBox("No hay registros a eliminar", MsgBoxStyle.Exclamation, "Mensaje")
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        limpiaCampos()
        Me.txtCoActual.Enabled = True
        cargaSeriesBusquedas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.txtDescripcion.Text, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
    End Sub

    Private Sub dgvSeriesFact_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeriesFact.CellEnter
        If Me.dgvSeriesFact.RowCount = 0 Then
            Return
        Else
            If Me.dgvSeriesFact.CurrentRow.Index < Me.dgvSeriesFact.Rows.Count Then
                Try
                    Me.txtSerie.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(0).Value
                    Me.txtDescripcion.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(1).Value
                    Me.txtCoInicial.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(4).Value
                    Me.txtCoFinal.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(5).Value
                    Me.txtCoActual.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(6).Value
                    fill.validarChk(7, Me.chkActiva, Me.dgvSeriesFact)
                    Me.cmbCOMPAÑIA.SelectedValue = Me.dgvSeriesFact.CurrentRow.Cells.Item(13).Value
                    Me.cmbBODEGA.SelectedValue = Me.dgvSeriesFact.CurrentRow.Cells.Item(2).Value
                    Me.cmbTIPO_DOCUMENTO.SelectedValue = Me.dgvSeriesFact.CurrentRow.Cells.Item(14).Value
                    Me.dpFechaInicial.Value = Me.dgvSeriesFact.CurrentRow.Cells.Item(9).Value
                    Me.dpFechaFinal.Value = Me.dgvSeriesFact.CurrentRow.Cells.Item(10).Value
                    Me.TxtN_Resolucion.Text = Me.dgvSeriesFact.CurrentRow.Cells.Item(15).Value
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
                End Try
            Else
                limpiaCampos()
                cargaCMB()
            End If
        End If
    End Sub

    Private Sub Facturacion_Series_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, Me.Width, Me.Height)
    End Sub
End Class