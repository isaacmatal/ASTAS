Imports System.Data.SqlClient

Public Class Seguridad_Compañias
    Dim Sql As String
    Dim jClass As New jarsClass

    Private Sub Seguridad_Compañias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompañias(2)
        CargaTipoContribuyente(1, 1)
    End Sub

    Private Sub CargaTipoContribuyente(ByVal Compañia, ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_PROVEEDOR "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.cmbCONTRIBUYENTE.DataSource = Table
            Me.cmbCONTRIBUYENTE.ValueMember = "TIPO_PROVEEDOR"
            Me.cmbCONTRIBUYENTE.DisplayMember = "DESCRIPCION_TIPO_PROVEEDOR"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvCompañias.Columns.Item(0).Width = 50
        Me.dgvCompañias.Columns.Item(1).Width = 200
        'Me.dgvCompañias.Columns.Item(2).Width = 75
        'Me.dgvCompañias.Columns.Item(3).Width = 125
        Me.dgvCompañias.Columns(2).Visible = False
        Me.dgvCompañias.Columns(3).Visible = False
        Me.dgvCompañias.Columns(4).Visible = False
        Me.dgvCompañias.Columns(6).Visible = False
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCOMPAÑIA.Text = ""
        Me.txtDESCRIPCION_COMPAÑIA.Text = ""
        Me.txtDIRECCION.Text = ""
        Me.txtTELEFONOS.Text = ""
        Me.txtREPRESENTANTE_LEGAL.Text = ""
        Me.txtLOGO.Text = ""
        Me.txtNIT.Text = ""
        Me.txtNRC.Text = ""
    End Sub

    Private Sub CargaCompañias(ByVal Bandera)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS "
            Sql &= "'" & Usuario & "'"
            Sql &= ", " & Bandera
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvCompañias.Columns.Clear()
            Me.dgvCompañias.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MantenimientoCompañias(ByVal Compañia, ByVal Descripcion, ByVal Direccion, ByVal Telefonos, ByVal TipoContribuyente, ByVal RepLegal, ByVal Logo, ByVal NIT, ByVal NRC, ByVal IUD)
        Try
            Sql = "Execute sp_CATALOGO_COMPAÑIAS_IUD "
            Sql &= Compañia
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Direccion & "'"
            Sql &= ", '" & Telefonos & "'"
            Sql &= ", " & TipoContribuyente
            Sql &= ", '" & RepLegal & "'"
            Sql &= ", '" & Logo & "'"
            Sql &= ", '" & NIT & "'"
            Sql &= ", '" & NRC & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            jClass.ejecutarComandoSql(New SqlCommand(Sql))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtDESCRIPCION_COMPAÑIA.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Compañía válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtDIRECCION.Text) = "" Then
            MsgBox("¡Debe ingresar una Dirección de Compañía válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtTELEFONOS.Text) = "" Then
            MsgBox("¡Debe ingresar un Teléfono válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtREPRESENTANTE_LEGAL.Text) = "" Then
            MsgBox("¡Debe ingresar un nombre de Representante Legal de la Compañía válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtLOGO.Text) = "" Then
            MsgBox("¡Debe ingresar un Logo válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Len(Me.txtNIT.Text) <> 17 Then
            MsgBox("¡Debe ingresar un número de NIT válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtNRC.Text) = "" Then
            MsgBox("¡Debe ingresar un número de Registro Fiscal válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function DevuelveNombreLogo(ByVal ArchivoLargo) As String
        Dim Pos As Integer
        Pos = Len(ArchivoLargo)
        If Pos > 0 Then
            While Mid(ArchivoLargo, Pos, 1) <> "\"
                Pos = Pos - 1
            End While
            Return Mid(ArchivoLargo, Pos + 1, Len(ArchivoLargo) - Pos)
        End If
        Return String.Empty
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            MantenimientoCompañias(Val(Me.txtCOMPAÑIA.Text), Trim(Me.txtDESCRIPCION_COMPAÑIA.Text), Trim(Me.txtDIRECCION.Text), Trim(Me.txtTELEFONOS.Text), Me.cmbCONTRIBUYENTE.SelectedValue, Trim(Me.txtREPRESENTANTE_LEGAL.Text), Me.txtLOGO.Text, Trim(Me.txtNIT.Text), Trim(Me.txtNRC.Text), IIf(Trim(Me.txtCOMPAÑIA.Text) = "", "I", "U"))
            CargaCompañias(2)
            LimpiaCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Val(Me.txtCOMPAÑIA.Text) > 0 Then
            If MsgBox("¿Está seguro(a) que desea eliminar la Compañía seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                MantenimientoCompañias(Val(Me.txtCOMPAÑIA.Text), Trim(Me.txtDESCRIPCION_COMPAÑIA.Text), Trim(Me.txtDIRECCION.Text), Trim(Me.txtTELEFONOS.Text), Me.cmbCONTRIBUYENTE.SelectedValue, Trim(Me.txtREPRESENTANTE_LEGAL.Text), Me.txtLOGO.Text, Trim(Me.txtNIT.Text), Trim(Me.txtNRC.Text), "D")
                CargaCompañias(2)
                LimpiaCampos()
            End If
        Else
            MsgBox("¡Debe seleccionar una Compañía válida!", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub dgvCompañias_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompañias.CellClick
        If Me.dgvCompañias.CurrentRow.Index < Me.dgvCompañias.Rows.Count Then
            Me.txtCOMPAÑIA.Text = Me.dgvCompañias.CurrentRow.Cells.Item(0).Value
            Me.txtDESCRIPCION_COMPAÑIA.Text = Me.dgvCompañias.CurrentRow.Cells.Item(1).Value
            Me.txtDIRECCION.Text = Me.dgvCompañias.CurrentRow.Cells.Item(2).Value
            Me.txtTELEFONOS.Text = Me.dgvCompañias.CurrentRow.Cells.Item(3).Value
            Me.cmbCONTRIBUYENTE.SelectedValue = Me.dgvCompañias.CurrentRow.Cells.Item(4).Value
            Me.txtREPRESENTANTE_LEGAL.Text = Me.dgvCompañias.CurrentRow.Cells.Item(6).Value
            Me.txtLOGO.Text = Me.dgvCompañias.CurrentRow.Cells.Item(7).Value
            Me.txtNIT.Text = Me.dgvCompañias.CurrentRow.Cells.Item(8).Value
            Me.txtNRC.Text = Me.dgvCompañias.CurrentRow.Cells.Item(9).Value
        Else
            Me.txtCOMPAÑIA.Text = ""
            Me.txtDESCRIPCION_COMPAÑIA.Text = ""
            Me.txtDIRECCION.Text = ""
            Me.txtTELEFONOS.Text = ""
            Me.txtREPRESENTANTE_LEGAL.Text = ""
            Me.txtLOGO.Text = ""
            Me.txtNIT.Text = ""
            Me.txtNRC.Text = ""
        End If
    End Sub

    Private Sub dgvCompañias_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompañias.CellContentClick

    End Sub

    Private Sub btnLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogo.Click
        Me.OpenFileDialogAbrir.Filter = "Imagen JPG (*.jpg)|*.jpg|Imagen BMP (*.bmp)|*.bmp|Imagen PNG (*.png)|*.png"
        Me.OpenFileDialogAbrir.ShowDialog()
        Me.txtLOGO.Text = DevuelveNombreLogo(Me.OpenFileDialogAbrir.FileName)
    End Sub
End Class
