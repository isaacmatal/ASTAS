'' =============================================
'' Modified:	Joan Serrano
'' Create date: 03-Feb-2011
'' Description:	Movimiento de Inventarios Tipo Documento
'' =============================================

Imports System.Data.SqlClient

Public Class Inventario_TipoDocumento
    Dim Sql As String
    Dim Iniciando As Boolean

    ' Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable

    Private Sub Inventario_TipoDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        'Imagen e Icono
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtCompañia.Text = Descripcion_Compañia
        CargaTipoDocumentoContable(Compañia, 4)
        CargaTipos(Compañia, 1)
        Iniciando = False
    End Sub

    Private Sub CargaTipoDocumentoContable(ByVal Compañia, ByVal Bandera)
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbDOCUMENTO_CONTABLE.DataSource = Table
            Me.cmbDOCUMENTO_CONTABLE.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbDOCUMENTO_CONTABLE.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblTIPO_DOCUMENTO.Text = ""
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text = ""
        Me.txtIDENTIFICADOR.Text = ""
        Me.cmbES.Text = ""
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvTipoDocumento.Columns(3).Visible = False

        'For i As Integer = 1 To Me.dgvTipoDocumento.Columns.Count
        '    Me.dgvTipoDocumento.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Next
        Me.dgvTipoDocumento.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvTipoDocumento.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvTipoDocumento.Columns(0).Width = 50
        Me.dgvTipoDocumento.Columns(1).Width = 70
        Me.dgvTipoDocumento.Columns(5).Width = 50
        Me.dgvTipoDocumento.Columns(6).Width = 75
        Me.dgvTipoDocumento.Columns(7).Width = 125
        'Me.dgvLotes.Columns(5).DefaultCellStyle.ForeColor = Color.Red
        'Me.dgvLotes.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub CargaTipos(ByVal Compañia, ByVal Bandera)
        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_TIPO_DOCUMENTO "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvTipoDocumento.Columns.Clear()
            Me.dgvTipoDocumento.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text) = "" Then
            MsgBox("¡Ingrese una Descripción válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtIDENTIFICADOR.Text) = "" Then
            MsgBox("¡Ingrese un Identificador válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.cmbES.Text) = "" Then
            MsgBox("¡Debe definir si es Entrada o Salida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Mantenimiento_TipoDocumento(ByVal Compañia, ByVal TipoDoc, ByVal DescTipoDoc, ByVal Identificador, ByVal TipoDocContable, ByVal ES, ByVal RC, ByVal RD, ByVal IUD)

        DLLConnection.Connection.Usuario = UsuarioDB
        DLLConnection.Connection.Password = PasswordDB
        DLLConnection.Connection.Servidor = Servidor
        DLLConnection.Connection.Catalogo = BaseDatos
        Conexion_ = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)

        Try
            Conexion_.Open()
            Sql = "Execute sp_INVENTARIOS_CATALOGO_TIPO_DOCUMENTO_IUD "
            Sql &= Compañia
            Sql &= ", " & TipoDoc
            Sql &= ", '" & DescTipoDoc & "'"
            Sql &= ", " & Identificador
            Sql &= ", " & TipoDocContable
            Sql &= ", " & ES
            Sql &= ", '" & Usuario & "'"
            Sql &= ", " & RC
            Sql &= ", " & RD
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Tipo de Documento de Inventario Almacenado con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "U"
                    MsgBox("¡Tipo de Documento de Inventario Actualizado con éxito!", MsgBoxStyle.Information, "Mensaje")
                Case "D"
                    MsgBox("¡Tipo de Documento de Inventario Eliminado con éxito!", MsgBoxStyle.Information, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaTipoDocumentoContable(Compañia, 4)
            CargaTipos(Compañia, 1)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then

            Dim RC As Integer
            Dim RD As Integer
            'si requiere costo y esta habilitado y seleccionado
            If Me.Chb_Requiere_costo.Enabled = True And Me.Chb_Requiere_costo.Checked = True Then
                RC = 1 : Else : RC = 0
            End If
            'si requiere documento y esta habilitado y seleccionado
            If Me.Chb_Requiere_documento.Enabled = True And Me.Chb_Requiere_documento.Checked = True Then
                RD = 1 : Else : RD = 0
            End If
            'MessageBox.Show(RC)

            'si lblTIPO_DOCUMENTO esta vacio es porque es un nuevo sino solo es actualizacion

            If Me.lblTIPO_DOCUMENTO.Text.Trim = "" Then
                'Mantenimiento_TipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), RC, "I")
                Mantenimiento_TipoDocumento(Compañia, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), RC, RD, "I")
            Else
                'Mantenimiento_TipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), RC, "U")
                Mantenimiento_TipoDocumento(Compañia, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), RC, RD, "U")
            End If
            CargaTipos(Compañia, 1)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblTIPO_DOCUMENTO.Text <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Tipo de Documento de Inventario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                'Mantenimiento_TipoDocumento(Me.cmbCOMPAÑIA.SelectedValue, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), 0, "D")
                Mantenimiento_TipoDocumento(Compañia, Val(Me.lblTIPO_DOCUMENTO.Text), Trim(Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text), Trim(Me.txtIDENTIFICADOR.Text), Me.cmbDOCUMENTO_CONTABLE.SelectedValue, IIf(Me.cmbES.Text = "Entrada", "1", "0"), 0, 0, "D")
                CargaTipos(Compañia, 1)
                LimpiaCampos()
            End If
        Else
            MsgBox("¡Debe seleccionar un Tipo de Documento de Inventario válido! Verifique" & Chr(13) & "No se eliminará ningún registro.", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub
    Private Sub cmbES_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbES.SelectedIndexChanged
        If Me.cmbES.Text = "Entrada" Then
            Me.Chb_Requiere_costo.Enabled = True
        Else : Me.Chb_Requiere_costo.Enabled = False
        End If
    End Sub

    Private Sub txtDESCRIPCION_TIPO_DOCUMENTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDESCRIPCION_TIPO_DOCUMENTO.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 2 '1  
        Dim Ncolumn As String = dgvTipoDocumento.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvTipoDocumento.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_TIPO_DOCUMENTO.Text = "" Then
            Me.dgvTipoDocumento.DataSource = Table
        Else
            rows = Table.Select("[" & dgvTipoDocumento.Columns(columna).Name & "] like '" & txtDESCRIPCION_TIPO_DOCUMENTO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            ' return filtered dt            
            Me.dgvTipoDocumento.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvTipoDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTipoDocumento.Click
        Me.lblTIPO_DOCUMENTO.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(0).Value
        Me.txtDESCRIPCION_TIPO_DOCUMENTO.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(2).Value
        Me.txtIDENTIFICADOR.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(1).Value
        Me.cmbDOCUMENTO_CONTABLE.SelectedValue = Me.dgvTipoDocumento.CurrentRow.Cells.Item(3).Value
        Me.cmbES.Text = Me.dgvTipoDocumento.CurrentRow.Cells.Item(5).Value
        If Me.dgvTipoDocumento.CurrentRow.Cells.Item(6).Value = "Si" Then
            Me.Chb_Requiere_costo.Checked = True
        Else : Me.Chb_Requiere_costo.Checked = False
        End If
        If Me.dgvTipoDocumento.CurrentRow.Cells.Item(7).Value = "Si" Then
            Me.Chb_Requiere_documento.Checked = True
        Else : Me.Chb_Requiere_documento.Checked = False
        End If
    End Sub
End Class