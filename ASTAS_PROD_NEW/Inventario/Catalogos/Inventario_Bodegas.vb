Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Inventario_Bodegas

    Dim fill As New cmbFill
    Dim c_data1 As New jarsClass
    Dim centroCostoActual As Integer ' obtengo el centro de costo para el actual
    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader
    Dim bandera As Boolean = False
    'Declaracion de variables
    Dim sql As String
    Dim Iniciando As Boolean    
    Dim columna As Integer = 1 'Valor numero de la columna del DataGridView.

    'Carga valores al inicio del formulario
    Private Sub Inventario_Bodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        AutoOrdenamiento.Checked = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        'Para llenado de combobox        
        Me.txtCompañia.Text = Descripcion_Compañia
        fill.CargaCentroCosto(Compañia, Me.cmbCENTRO_COSTO)
        'cmbCentroCosto()   
        fill.CargaDeducciones(Compañia, Me.cmbDEDUCCION)
        fill.CargaPeriodo(Compañia, Me.cmbPERIODO)
        cargaBodegas(1, Compañia)
        cmbTipoBodega.SelectedIndex = 0
        cmbPlantas.SelectedIndex = 0
        c_data1.CargarCombo(Me.cmbPlantas, "SELECT PLANTA, DESCRIPCION_PLANTA FROM CAFETERIA_CATALOGO_PLANTAS WHERE COMPAÑIA=" & Compañia, "PLANTA", "DESCRIPCION_PLANTA")
        Iniciando = False
    End Sub
    Private Sub cmbCentroCosto()
        sql = " Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO " & Compañia & ", 4"
        Comando_ = New SqlCommand(sql)
        Table = c_data1.obtenerDatos(Comando_)
        Me.cmbCENTRO_COSTO.DataSource = Table
        cmbCENTRO_COSTO.ValueMember = "Centro Costo"
        cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            fill.CargaCentroCosto(Compañia, Me.cmbCENTRO_COSTO)
            fill.CargaDeducciones(Compañia, Me.cmbDEDUCCION)
            fill.CargaPeriodo(Compañia, Me.cmbPERIODO)
            limpiaCampos()
            cargaBodegas(1, Compañia)
        End If
    End Sub

    Private Sub txtCuotaIni_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuotaIni.KeyPress
        fill.soloNumeros(e)
    End Sub

    Private Sub txtCuoFin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuoFin.KeyPress
        fill.soloNumeros(e)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String = ""
        'Si el centro de costo esta siendo usado por otra bodega no lo deja
        If Me.centroCostoActual <> Me.cmbCENTRO_COSTO.SelectedValue Then
            If Not esUnicoCentroCosto() Then
                MessageBox.Show("El centro de costo seleccionado esta asignado a otra bodega. ", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If
        If valCMB() = Nothing Then
            If valCamposVacios() = Nothing And valCuotas() = Nothing Then
                If Trim(Me.txtBodega.Text) <> Nothing Then
                    IUD = "U"
                Else
                    IUD = "I"
                End If
                mantenimientoBodegas(Compañia, Me.txtBodega.Text, Me.txtDescripcion.Text, Me.chkActiva.CheckState, Me.chkFDP.CheckState, Me.chkVPDF.CheckState, Me.cmbPERIODO.SelectedValue, Me.txtCuotaIni.Text, Me.txtCuoFin.Text, Me.cmbDEDUCCION.SelectedValue, Me.cmbCENTRO_COSTO.SelectedValue, IUD, Me.ck_Siempre_Fac.CheckState, cmbPlantas.SelectedValue)
                cargaBodegas(1, Compañia)
                limpiaCampos()
                cargaCMB()
            End If
        End If
    End Sub
    Private Function esUnicoCentroCosto()
        Dim totalRegistros As Integer
        Dim unico As Boolean

        sql = "SELECT count(*) FROM INVENTARIOS_CATALOGO_BODEGAS WHERE CENTRO_COSTO=" & Me.cmbCENTRO_COSTO.SelectedValue & " AND Compañia = " & Compañia
        totalRegistros = c_data1.obtenerEscalar(sql)

        If totalRegistros > 0 Then
            unico = False
        Else
            unico = True
        End If

        Return unico
    End Function
    Private Function valCuotas()
        Dim valorCuotas As String = ""
        If Val(Me.txtCuoFin.Text) < Val(Me.txtCuotaIni.Text) Then
            MsgBox("El numero de cuenta final no puede ser mayor al numero de cuenta inicial", MsgBoxStyle.Information, "Mensaje")
            valorCuotas = "No valido"
        End If
        Return valorCuotas
    End Function

    Private Function valCamposVacios()
        Dim camposVacios As String = ""
        If Me.txtDescripcion.Text = Nothing Then
            camposVacios = vbCrLf & "Descripción"
        End If
        If Me.txtCuotaIni.Text = Nothing Then
            camposVacios &= vbCrLf & "Cuota Inicial"
        End If
        If Me.txtCuoFin.Text = Nothing Then
            camposVacios &= vbCrLf & "Cuota Final"
        End If
        If camposVacios <> Nothing Then
            MsgBox("Debe llenar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    Private Function valCMB()
        Dim combosVacios As String = ""
        If Compañia = Nothing Then
            combosVacios = vbCrLf & "Compañía"
        End If
        If Me.cmbCENTRO_COSTO.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Centro de Costo"
        End If
        If Me.cmbDEDUCCION.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Deducción"
        End If
        If Me.cmbPERIODO.SelectedValue = Nothing Then
            combosVacios &= vbCrLf & "Período"
        End If
        If combosVacios <> Nothing Then
            MsgBox("No se puede continuar con la operación, debido a" & vbCrLf & "la falta de información en los siguientes campos: " & combosVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return combosVacios
    End Function

    'Mantenimiento completo para las bodegas
    Private Sub mantenimientoBodegas(ByVal compañia, ByVal bodega, ByVal descripBodega, ByVal activa, ByVal facturacion, ByVal factVariosPeriodos, ByVal Periodo, ByVal cuotInicial, ByVal cuotFinal, ByVal deduccion, ByVal centroCosto, ByVal IUD, ByVal SP, ByVal planta)
        Dim res As Integer = 0
        If bodega = Nothing Then
            bodega = 0
        End If
        If deduccion = Nothing Then
            deduccion = 0
        End If
        Try
            sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS_IUD "
            sql &= compañia
            sql &= ", " & bodega
            sql &= ", '" & descripBodega & "' "
            sql &= ", " & activa
            sql &= ", " & facturacion
            sql &= ", " & factVariosPeriodos
            sql &= ", " & Periodo
            sql &= ", " & cuotInicial
            sql &= ", " & cuotFinal
            sql &= ", " & deduccion
            sql &= ", " & centroCosto
            sql &= ", " & Usuario
            sql &= ", " & IUD
            sql &= ", " & SP
            sql &= ", " & 0
            sql &= ", " & 0
            sql &= ", " & Val(txt_Margen.Text)
            If cmbPlantas.SelectedItem = "1 - Planta Soyapango" Then
                sql &= "," & 1
            ElseIf cmbPlantas.SelectedItem = "2 - Planta Zapotitan" Then
                sql &= "," & 2
            ElseIf cmbPlantas.SelectedItem = "3 - Planta Lourdes" Then
                sql &= "," & 3
            ElseIf cmbPlantas.SelectedItem = "4 - Otra No clasificada" Then
                sql &= "," & 0
            End If

            If cmbTipoBodega.SelectedItem = "Otros" Then
                sql &= "," & 0
            ElseIf cmbTipoBodega.SelectedItem = "Almacen" Then
                sql &= "," & 1
            ElseIf cmbTipoBodega.SelectedItem = "Cafeteria" Then
                sql &= "," & 2
            ElseIf cmbTipoBodega.SelectedItem = "Despensa" Then
                sql &= "," & 3
            End If
            res = c_data1.ejecutarComandoSql(New SqlCommand(sql))
            If res <> 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Bodega almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Bodega actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Bodega eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                End Select
            End If
        Catch ex As Exception
            MsgBox("El cambio no puede realizarce! La bodega esta siendo utilizada!", MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Llenado de datagridview para bodegas
    Private Sub cargaBodegas(ByVal flag, ByVal cia)     
        Try
            sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            sql &= "@BANDERA=" & flag
            sql &= ", @COMPAÑIA=" & cia
            sql &= ", @USUARIO='" & Usuario & "'"
            Me.dgvBodegas.Columns.Clear()
            Me.dgvBodegas.DataSource = c_data1.ejecutaSQLl_llenaDTABLE(sql)
            Table = Me.dgvBodegas.DataSource
            Me.dgvBodegas.Columns.Item(2).Visible = False
            Me.dgvBodegas.Columns.Item(4).Visible = False
            Me.dgvBodegas.Columns.Item(5).Visible = False
            Me.dgvBodegas.Columns.Item(6).Visible = False
            Me.dgvBodegas.Columns.Item(7).Visible = False
            Me.dgvBodegas.Columns.Item(9).Visible = False
            Me.dgvBodegas.Columns.Item(11).Visible = False
            Me.dgvBodegas.Columns.Item(12).Visible = False
            Me.dgvBodegas.Columns.Item(14).Visible = False
            Me.dgvBodegas.Columns.Item(15).Visible = False

            fill.ajustarGrid(13, Me.dgvBodegas)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Limpia todos los campos
    Private Sub limpiaCampos()
        Me.txtDescripcion.Clear()
        Me.txtBodega.Clear()
        Me.chkActiva.CheckState = CheckState.Unchecked
        Me.chkFDP.CheckState = CheckState.Unchecked
        Me.chkVPDF.CheckState = CheckState.Unchecked
    End Sub

    Private Sub cargaCMB()
        'fill.CargaCompañia(Me.cmbCOMPAÑIA)
        fill.CargaCentroCosto(Compañia, Me.cmbCENTRO_COSTO)
        fill.CargaDeducciones(Compañia, Me.cmbDEDUCCION)
        fill.CargaPeriodo(Compañia, Me.cmbPERIODO)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiaCampos()
        bandera = False
        'cargaCMB()
        'fill.limpiargrid(Me.dgvBodegas)
    End Sub

    'Evento del datagridview para bodegas y llenado de campos del formulario
    Private Sub dgvBodegas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBodegas.CellClick
        If Me.dgvBodegas.RowCount = 0 Then
            Return
        Else
            If Me.dgvBodegas.CurrentRow.Index < Me.dgvBodegas.Rows.Count Then
                Try
                    bandera = True
                    Me.txtBodega.Text = Me.dgvBodegas.CurrentRow.Cells.Item(0).Value
                    Me.txtDescripcion.Text = Me.dgvBodegas.CurrentRow.Cells.Item(1).Value
                    Me.txtCuotaIni.Text = Me.dgvBodegas.CurrentRow.Cells.Item(6).Value
                    Me.txtCuoFin.Text = Me.dgvBodegas.CurrentRow.Cells.Item(7).Value
                    fill.validarChk(13, Me.chkActiva, Me.dgvBodegas)
                    fill.validarChk(8, Me.chkFDP, Me.dgvBodegas)
                    fill.validarChk(9, Me.chkVPDF, Me.dgvBodegas)
                    Me.cmbCENTRO_COSTO.SelectedValue = Me.dgvBodegas.CurrentRow.Cells.Item(2).Value
                    Me.cmbDEDUCCION.SelectedValue = Me.dgvBodegas.CurrentRow.Cells.Item(4).Value
                    Me.cmbPERIODO.SelectedValue = Me.dgvBodegas.CurrentRow.Cells.Item(5).Value
                    Me.cmbPlantas.SelectedValue = Me.dgvBodegas.CurrentRow.Cells.Item(16).Value

                    If Val(Me.dgvBodegas.CurrentRow.Cells.Item(17).Value) = 0 Then
                        Me.cmbTipoBodega.SelectedIndex = 0
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(17).Value) = 1 Then
                        Me.cmbTipoBodega.SelectedIndex = 1
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(17).Value) = 2 Then
                        Me.cmbTipoBodega.SelectedIndex = 2
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(17).Value) = 3 Then
                        Me.cmbTipoBodega.SelectedIndex = 3
                    End If

                    If Val(Me.dgvBodegas.CurrentRow.Cells.Item(16).Value) = 0 Then
                        Me.cmbPlantas.SelectedIndex = 4
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(16).Value) = 1 Then
                        Me.cmbPlantas.SelectedIndex = 0
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(16).Value) = 2 Then
                        Me.cmbPlantas.SelectedIndex = 1
                    ElseIf Val(Me.dgvBodegas.CurrentRow.Cells.Item(16).Value) = 3 Then
                        Me.cmbPlantas.SelectedIndex = 2
                    End If
                    Me.txt_Margen.Text = Format(Me.dgvBodegas.CurrentRow.Cells.Item(18).Value, "0.00")
                    Me.centroCostoActual = Me.dgvBodegas.CurrentRow.Cells.Item(2).Value
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
                End Try
            Else
                limpiaCampos()
                cargaCMB()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvBodegas.RowCount <> 0 Then
            If Me.txtBodega.Text <> Nothing And Me.txtBodega.Text <> "0" Then
                If MsgBox("¿Está seguro(a) que desea eliminar la Bodega Nº " & Me.txtBodega.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then                    
                    mantenimientoBodegas(Compañia, Me.txtBodega.Text, Me.txtDescripcion.Text, Me.chkActiva.CheckState, Me.chkFDP.CheckState, Me.chkVPDF.CheckState, Me.cmbPERIODO.SelectedValue, Me.txtCuotaIni.Text, Me.txtCuoFin.Text, Me.cmbDEDUCCION.SelectedValue, Me.cmbCENTRO_COSTO.SelectedValue, "D", Me.ck_Siempre_Fac.CheckState, cmbPlantas.SelectedValue)
                    cargaBodegas(1, Compañia)
                    limpiaCampos()
                    cargaCMB()
                End If
            Else
                MsgBox("Debe seleccionar una Bodega válida.", MsgBoxStyle.Critical, "Mensaje")
            End If
        Else
            MsgBox("No hay registros a eliminar", MsgBoxStyle.Exclamation, "Mensaje")
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        fill.noComillaSimple(e)
    End Sub
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        If AutoOrdenamiento.Checked = True Then
            'Else
            If bandera = False Then
                Dim rows As DataRow()
                Dim posicion As Integer = -1 '1  
                Dim Ncolumn As String = dgvBodegas.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
                Dim Strsort As String = ""

                Select Case dgvBodegas.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                    Case SortOrder.Ascending 'En Caso de ser Ascendente
                        Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                    Case SortOrder.Descending 'En Caso de ser Descendente
                        Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
                End Select

                'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
                Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
                If txtDescripcion.Text = "" Then
                    Me.dgvBodegas.DataSource = Table
                Else
                    rows = Table.Select(dgvBodegas.Columns(columna).Name & " like '" & txtDescripcion.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
                    For i As Integer = 0 To rows.Length - 1
                        tablaT.ImportRow(rows(i))
                    Next

                    ' return filtered dt            
                    Me.dgvBodegas.DataSource = tablaT
                End If

            End If
        End If        
    End Sub


End Class