Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Facturacion_FormaPago

    'constructor
    Dim fill As New cmbFill

    'variables
    Dim sql As String = ""
    Dim Iniciando As Boolean

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    Private Sub Facturacion_FormaPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        fill.CargaCompañia(cmbCOMPAÑIA)
        cargaPagos(1, Me.cmbCOMPAÑIA.SelectedValue)
        Iniciando = False
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            cargaPagos(1, Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        fill.noComillaSimple(e)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String = ""
        If valCamposVacios() = Nothing Then
            If Trim(Me.txtPago.Text) <> Nothing Then
                IUD = "U"
            Else
                IUD = "I"
            End If
            mantenimientoPagos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtPago.Text, Me.txtDescripcion.Text, IUD)
            cargaPagos(1, Me.cmbCOMPAÑIA.SelectedValue)
            limpiaCampos()
        End If
    End Sub

    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Me.txtDescripcion.Text = Nothing Then
            camposVacios = vbCrLf & "Descripción"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe llenar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Sub mantenimientoPagos(ByVal compañia, ByVal formaPago, ByVal descripFormaPago, ByVal IUD)
        Dim res As Integer = 0
        If formaPago = Nothing Then
            formaPago = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO_IUD "
            sql &= compañia
            sql &= ", " & formaPago
            sql &= ", '" & descripFormaPago & "' "
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Forma de Pago almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Forma de Pago actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Forma de Pago eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
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

    Private Sub cargaPagos(ByVal flag, ByVal cia)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_FORMA_PAGO "
            sql &= flag
            sql &= ", " & cia
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPagos.Columns.Clear()
            Me.dgvPagos.DataSource = Table
            Me.dgvPagos.Columns.Item(4).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(5, Me.dgvPagos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Private Sub dgvPagos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPagos.CellClick

    'End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiaCampos()
    End Sub

    Private Sub limpiaCampos()
        Me.txtDescripcion.Clear()
        Me.txtPago.Clear()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvPagos.RowCount <> 0 Then
            If Trim(Me.txtPago.Text) <> Nothing And Trim(Me.txtPago.Text) <> "0" Then
                If MsgBox("¿Está seguro(a) que desea la Forma de Pago Nº " & Me.txtPago.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    mantenimientoPagos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtPago.Text, Me.txtDescripcion.Text, "D")
                    cargaPagos(1, Me.cmbCOMPAÑIA.SelectedValue)
                    limpiaCampos()
                Else
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Información")
                End If
            Else
                MsgBox("Debe seleccionar una Forma de Pago correcto", MsgBoxStyle.Information, "Mensaje")
            End If
        Else
            MsgBox("No hay registros a eliminar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    Private Sub dgvPagos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPagos.CellEnter
        If Me.dgvPagos.RowCount = 0 Then
            Return
        Else
            If Me.dgvPagos.CurrentRow.Index < Me.dgvPagos.Rows.Count Then
                Try
                    Me.txtPago.Text = Me.dgvPagos.CurrentRow.Cells.Item(0).Value
                    Me.txtDescripcion.Text = Me.dgvPagos.CurrentRow.Cells.Item(1).Value
                    Me.cmbCOMPAÑIA.SelectedValue = Me.dgvPagos.CurrentRow.Cells.Item(4).Value
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
                End Try
            Else
                limpiaCampos()
                'cargaCMB()
            End If
        End If
    End Sub
End Class