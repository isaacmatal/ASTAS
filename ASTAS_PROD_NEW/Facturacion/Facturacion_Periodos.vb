Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Facturacion_Periodos

    'Constructor
    Dim fill As New cmbFill

    'Declaración de variable
    Dim sql As String = ""
    Dim Iniciando As Boolean

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    Private Sub Facturacion_Periodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaPeriodos(1, Me.cmbCOMPAÑIA.SelectedValue)
        Iniciando = False
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            cargaPeriodos(1, Me.cmbCOMPAÑIA.SelectedValue)
            limpiaCampos()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        fill.noComillaSimple(e)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String = ""
        If valCamposVacios() = Nothing Then
            Try
                For i As Integer = 1 To Me.dgvPeriodos.Rows.Count
                    If Me.dgvPeriodos.Rows.Item(i - 1).Cells(0).Value = Me.txtPeriodo.Text Then
                        IUD = "U"
                        Exit For
                    Else
                        IUD = "I"
                    End If
                Next
                mttoPeriodos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtPeriodo.Text, Me.txtDescripcion.Text, Me.chkActivo.CheckState, IUD)
                cargaPeriodos(1, Me.cmbCOMPAÑIA.SelectedValue)
                limpiaCampos()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If
    End Sub

    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Me.txtPeriodo.Text = Nothing Then
            camposVacios = vbCrLf & "Período Pago"
        End If
        If Me.txtDescripcion.Text = Nothing Then
            camposVacios &= vbCrLf & "Descripción"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe completar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Sub mttoPeriodos(ByVal cia, ByVal periodo, ByVal descripcion, ByVal activo, ByVal IUD)
        Dim res As Integer = 0
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_PERIODOS_CUOTA_IUD "
            sql &= cia
            sql &= ", " & periodo
            sql &= ", '" & descripcion & "' "
            sql &= ", " & Activo
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos de Períodos de Facturación almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos de Períodos de Facturación actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos de Períodos de Facturación eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
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

    Private Sub cargaPeriodos(ByVal flag, ByVal cia)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_PERIODOS_CUOTA "
            sql &= flag
            sql &= ", " & cia
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPeriodos.Columns.Clear()
            Me.dgvPeriodos.DataSource = Table
            Me.dgvPeriodos.Columns.Item(5).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(6, Me.dgvPeriodos)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Private Sub dgvPeriodos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodos.CellClick

    'End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiaCampos()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvPeriodos.RowCount <> 0 Then
            If Me.txtPeriodo.Text <> Nothing Then
                If MsgBox("¿Está seguro(a) que desea eliminar el Período Nº " & Me.txtPeriodo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    mttoPeriodos(Me.cmbCOMPAÑIA.SelectedValue, Me.txtPeriodo.Text, Me.txtDescripcion.Text, Me.chkActivo.CheckState, "D")
                    cargaPeriodos(1, Me.cmbCOMPAÑIA.SelectedValue)
                    limpiaCampos()
                Else
                    MsgBox("Operación cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                MsgBox("Debe seleccionar un período de facturación", MsgBoxStyle.Information, "Mensaje")
            End If
        Else
            MsgBox("No hay registros para eliminar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    Private Sub limpiaCampos()
        Me.txtDescripcion.Clear()
        Me.txtPeriodo.Clear()
        Me.chkActivo.Checked = True
    End Sub

    Private Sub cargaCMB()
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
    End Sub

    Private Sub dgvPeriodos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodos.CellEnter
        If Me.dgvPeriodos.RowCount = 0 Then
            Return
        Else
            If Me.dgvPeriodos.CurrentRow.Index < Me.dgvPeriodos.Rows.Count Then
                Try
                    Me.txtPeriodo.Text = Me.dgvPeriodos.CurrentRow.Cells.Item(0).Value
                    Me.txtDescripcion.Text = Me.dgvPeriodos.CurrentRow.Cells.Item(1).Value
                    fill.validarChk(2, Me.chkActivo, Me.dgvPeriodos)
                    Me.cmbCOMPAÑIA.SelectedValue = Me.dgvPeriodos.CurrentRow.Cells.Item(5).Value
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
                End Try
            Else
                limpiaCampos()
                cargaCMB()
            End If
        End If
    End Sub

End Class