Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Facturacion_TipoDocumento

    'Constructor
    Dim fill As New cmbFill

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Declaración de variables
    Dim sql As String = ""
    Dim Iniciando As Boolean

    Private Sub Facturacion_TipoDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        fill.CargaTipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbDOC_CONTABLE)
        cargaTipoDocs(1, Me.cmbCOMPAÑIA.SelectedValue)
        Iniciando = False
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            limpiaCampos()
            fill.CargaTipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbDOC_CONTABLE)
            cargaTipoDocs(1, Me.cmbCOMPAÑIA.SelectedValue)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiaCampos()
    End Sub

    Private Sub limpiaCampos()
        Me.txtDescripcion.Clear()
        Me.txtIdentificador.Clear()
        Me.txtTipo.Clear()
        fill.CargaTipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbDOC_CONTABLE)
    End Sub

    Private Sub cargaCMB()
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        fill.CargaTipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbDOC_CONTABLE)
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        fill.noComillaSimple(e)
    End Sub

    Private Sub txtIdentificador_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdentificador.KeyPress
        fill.noComillaSimple(e)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String = ""
        If valCMB() = Nothing Then
            If valCamposVacios() = Nothing Then
                If Trim(Me.txtTipo.Text) <> Nothing Then
                    IUD = "U"
                Else
                    IUD = "I"
                End If
                mantenimientoTipoDocs(Me.cmbCOMPAÑIA.SelectedValue, Me.txtTipo.Text, Me.txtDescripcion.Text, Me.txtIdentificador.Text, Me.cmbDOC_CONTABLE.SelectedValue, IUD)
                cargaTipoDocs(1, Me.cmbCOMPAÑIA.SelectedValue)
                limpiaCampos()
            End If
        End If
    End Sub

    Private Function valCMB()
        Dim combosVacios As String = ""
        If Me.cmbCOMPAÑIA.SelectedValue = Nothing Then
            combosVacios = vbCrLf & "Compañía"
        End If
        If Me.cmbDOC_CONTABLE.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Documento Contable"
        End If
        If combosVacios <> Nothing Then
            MsgBox("No se puede continuar con la operación, debido a" & vbCrLf & "la falta de información en los siguientes campos: " & combosVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return combosVacios
    End Function

    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Me.txtDescripcion.Text = Nothing Then
            camposVacios = vbCrLf & "Descripción"
        End If
        If Me.txtIdentificador.Text = Nothing Then
            camposVacios &= vbCrLf & "Identificador"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe llenar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Sub mantenimientoTipoDocs(ByVal compañia, ByVal tipoDoc, ByVal descripTipoDoc, ByVal identificador, ByVal tipoDocContable, ByVal IUD)
        Dim res As Integer = 0
        If tipoDoc = Nothing Then
            tipoDoc = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO_IUD "
            sql &= compañia
            sql &= ", " & tipoDoc
            sql &= ", '" & descripTipoDoc & "' "
            sql &= ", '" & identificador & "' "
            sql &= ", '" & tipoDocContable & "' "
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Tipo de Documento almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Tipo de Documento actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Tipo de Documento eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
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

    Private Sub cargaTipoDocs(ByVal flag, ByVal cia)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_FACTURACION_CATALOGO_TIPO_DOCUMENTO "
            sql &= flag
            sql &= ", " & cia
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvTipoDocumento.Columns.Clear()
            Me.dgvTipoDocumento.DataSource = Table
            Me.dgvTipoDocumento.Columns.Item(3).Visible = False
            Me.dgvTipoDocumento.Columns.Item(7).Visible = False
            Conexion_.Close()
            fill.ajustarGrid(8, Me.dgvTipoDocumento)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Private Sub dgvTipoDocumento_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoDocumento.CellClick

    'End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvTipoDocumento.RowCount <> 0 Then
            If Me.txtTipo.Text <> Nothing And Me.txtTipo.Text <> "0" Then
                If MsgBox("¿Está seguro(a) que desea eliminar el Tipo de Documento Nº " & Me.txtTipo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                    mantenimientoTipoDocs(Me.cmbCOMPAÑIA.SelectedValue, Me.txtTipo.Text, Me.txtDescripcion.Text, Me.txtIdentificador.Text, Me.cmbDOC_CONTABLE.SelectedValue, "D")
                    cargaTipoDocs(1, Me.cmbCOMPAÑIA.SelectedValue)
                    limpiaCampos()
                    cargaCMB()
                Else
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                MsgBox("Debe seleccionar un Tipo de Documento", MsgBoxStyle.Critical, "Mensaje")
            End If
        Else
            MsgBox("No hay registros a eliminar", MsgBoxStyle.Exclamation, "Mensaje")
        End If
    End Sub

    Private Sub dgvTipoDocumento_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipoDocumento.CellEnter
        If Me.dgvTipoDocumento.RowCount = 0 Then
            Return
        Else
            If Me.dgvTipoDocumento.CurrentRow.Index < Me.dgvTipoDocumento.Rows.Count Then
                Try
                    Me.txtTipo.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(0).Value
                    Me.txtIdentificador.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(1).Value
                    Me.txtDescripcion.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(2).Value
                    Me.cmbCOMPAÑIA.SelectedValue = Me.dgvTipoDocumento.CurrentRow.Cells.Item(7).Value
                    Me.cmbDOC_CONTABLE.SelectedValue = Me.dgvTipoDocumento.CurrentRow.Cells.Item(3).Value
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