Imports System.Data.SqlClient

Public Class Contabilidad_OrdenCompra_Autorizar_Cambios
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Rpts As New frmReportes_Ver
    Dim jClass As New jarsClass

    Private Sub Contabilidad_OrdenCompra_Autorizar_Cambios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaBodegas(Me.cmbCOMPA�IA.SelectedValue, 6)
        Me.dpFechaDesde.Value = Now.AddDays(-Now.Day + 1)
        Me.dpFechaDesde.Value = Me.dpFechaDesde.Value.AddMonths(-Now.Month + 1)
        BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "7")
        Iniciando = False
    End Sub

    Private Sub CargaCompa�ia()
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPA�IAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", 1"
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCOMPA�IA.DataSource = Table
            Me.cmbCOMPA�IA.ValueMember = "COMPA�IA"
            Me.cmbCOMPA�IA.DisplayMember = "NOMBRE_COMPA�IA"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBodegas(ByVal Compa�ia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA = " & Bandera & ", "
            Sql &= "@COMPA�IA= " & Compa�ia & ", "
            Sql &= "@USUARIO = '" & Usuario & "' "
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbBODEGA.DataSource = Table
            Me.cmbBODEGA.ValueMember = "Bodega"
            Me.cmbBODEGA.DisplayMember = "Descripci�n"
            Me.cmbBODEGA.SelectedValue = 999
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BuscarOC(ByVal Compa�ia, ByVal Bodega, ByVal OC, ByVal NombreProveedor, ByVal NombreComercial, ByVal NIT, ByVal NRC, ByVal FechaIni, ByVal FechaFin, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_ENCABEZADO_BUSQUEDA "
            Sql &= Compa�ia
            Sql &= ", " & Bodega
            Sql &= ", " & OC
            Sql &= ", '" & NombreProveedor & "'"
            Sql &= ", '" & NombreComercial & "'"
            Sql &= ", '" & NIT & "'"
            Sql &= ", '" & NRC & "'"
            Sql &= ", '" & Format(FechaIni, "dd-MM-yyyy 00:00:01") & "'"
            Sql &= ", '" & Format(FechaFin, "dd-MM-yyyy 23:59:59") & "'"
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvOrdenesCompra.Columns.Clear()
            Me.dgvOrdenesCompra.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        For i As Integer = 0 To Me.dgvOrdenesCompra.Columns.Count - 1
            Me.dgvOrdenesCompra.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If i <> 11 Then
                Me.dgvOrdenesCompra.Columns.Item(i).ReadOnly = True
            Else
                Me.dgvOrdenesCompra.Columns.Item(i).ReadOnly = False
            End If
        Next
        Me.dgvOrdenesCompra.Columns.Item(4).Frozen = True
        Me.dgvOrdenesCompra.Columns(0).Width = 50 'OC
        Me.dgvOrdenesCompra.Columns(1).Width = 125 'Fecha
        Me.dgvOrdenesCompra.Columns(2).Width = 0 'Bodega
        Me.dgvOrdenesCompra.Columns(3).Width = 125 'Descripcion Bodega
        Me.dgvOrdenesCompra.Columns(4).Width = 150 'Proveedor
        Me.dgvOrdenesCompra.Columns(12).Width = 75 'Usuario Solicit�
        Me.dgvOrdenesCompra.Columns(13).Width = 125 'Fecha Solicitud

        Me.dgvOrdenesCompra.Columns.Item(9).DefaultCellStyle.ForeColor = Color.Blue
        Me.dgvOrdenesCompra.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.dgvOrdenesCompra.Columns.Item(2).Visible = False
        Me.dgvOrdenesCompra.Columns.Item(5).Visible = False
        Me.dgvOrdenesCompra.Columns.Item(6).Visible = False
        Me.dgvOrdenesCompra.Columns.Item(7).Visible = False
        Me.dgvOrdenesCompra.Columns.Item(8).Visible = False
    End Sub

    Private Sub GeneraSolicitudCambio(ByVal Compa�ia, ByVal OC, ByVal Solicitud, ByVal Comentario, ByVal IUD)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_CAMBIOS_IUD "
            Sql &= Compa�ia
            Sql &= ", " & OC
            Sql &= ", " & Solicitud
            Sql &= ", " & 1
            Sql &= ", '' "
            Sql &= ", '" & Comentario & "'"
            Sql &= ", '" & Usuario & "' "
            Sql &= ", '" & IUD & "'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
            MsgBox("�Orden de Compra actualizada con �xito!", MsgBoxStyle.Information, "Mensaje")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "7")
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaBodegas(Me.cmbCOMPA�IA.SelectedValue, 6)
        End If
    End Sub

    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "7")
        End If
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If Me.dgvOrdenesCompra.CurrentRow.Cells.Item(11).Value = True Then
            Dim Comentario As String
            Comentario = ""
            Comentario = InputBox("Ingrese un comentario de Autorizaci�n de cambio de la Orden de Compra", "Comentario")
            If Trim(Comentario) <> "" Then
                GeneraSolicitudCambio(Me.cmbCOMPA�IA.SelectedValue, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(15).Value, Comentario, "U")
                BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "7")
            Else
                MsgBox("�Debe ingresar un Comentario v�lido!" & Chr(13) & "No se realizar� ning�n cambio.", MsgBoxStyle.Critical, "Validaci�n")
            End If
        End If
    End Sub

    Private Sub dgvOrdenesCompra_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrdenesCompra.CellClick
        If Me.dgvOrdenesCompra.CurrentRow.Cells.Item(11).Value = True Then
            Me.dgvOrdenesCompra.CurrentRow.Cells.Item(11).Value = False
        Else
            Me.dgvOrdenesCompra.CurrentRow.Cells.Item(11).Value = True
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If MsgBox("Desea Anular Orden de Compra", MsgBoxStyle.YesNo, "ANULACION") = MsgBoxResult.Yes Then
            If Me.dgvOrdenesCompra.CurrentRow.Cells.Item(11).Value = True Then
                Dim Comentario As String
                Comentario = ""
                Comentario = InputBox("Ingrese un comentario de la Anulaci�n de la Orden de compra", "Anulaci�n")
                If Trim(Comentario) <> "" Then
                    GeneraSolicitudCambio(Me.cmbCOMPA�IA.SelectedValue, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(15).Value, Comentario, "U")
                    Mantenimiento_OCAutorizacion(Compa�ia, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value, "0", "1", 0, 0, 0, 0, 0, Comentario, "U")
                    BuscarOC(Me.cmbCOMPA�IA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, "", "", "", "", Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, "7")
                Else
                    MsgBox("�Debe ingresar un Comentario v�lido!" & Chr(13) & "No se realizar� ning�n cambio.", MsgBoxStyle.Critical, "Validaci�n")
                End If
            End If
        End If
    End Sub
    Private Sub Mantenimiento_OCAutorizacion(ByVal Compa�ia, ByVal OrdenCompra, ByVal Autorizada, ByVal Anulada, ByVal SubTotal, ByVal IVA, ByVal Total, ByVal Percepcion, ByVal TotalCompra, ByVal Comentario, ByVal IUD)
        Try
            Sql = "Execute sp_CONTABILIDAD_ORDEN_COMPRA_AUTORIZACIONES_IUD "
            Sql &= Compa�ia
            Sql &= ", " & OrdenCompra
            Sql &= ", " & Autorizada
            Sql &= ", " & Anulada
            Sql &= ", " & SubTotal
            Sql &= ", " & IVA
            Sql &= ", " & Total
            Sql &= ", " & Percepcion
            Sql &= ", " & TotalCompra
            Sql &= ", '" & Comentario & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Me.dgvOrdenesCompra.Rows.Count > 0 Then
            Rpts.CargaOC(Me.cmbCOMPA�IA.SelectedValue, Me.dgvOrdenesCompra.CurrentRow.Cells.Item(0).Value)
            Rpts.ShowDialog()
        Else
            MsgBox("�Debe seleccionar una Orden de Compra v�lida!", MsgBoxStyle.Critical, "Validaci�n")
        End If
    End Sub
End Class