Imports System.Data.SqlClient

Public Class Facturacion_Usuarios_Autorizadores
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass
    Dim intDato As Integer
    Dim intAct As Integer

    Private Sub Seguridad_Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaCompa�ia()
        CargaUsuarios(Me.cmbCOMPA�IA.SelectedValue)
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
            'Me.cmbCOMPA�IA.SelectedItem = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaUsuarios(ByVal Compa�ia)
        Dim Table As DataTable
        Try
            Sql = "Execute sp_CATALOGO_USUARIOS " & Compa�ia & ", 'SYSTEM', ' ' , 2 "
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            Me.dgvUsuarios.Columns.Clear()
            Me.dgvUsuarios.DataSource = Table
            LimpiaGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvUsuarios.Columns.Item(0).Width = 75
        Me.dgvUsuarios.Columns.Item(1).Width = 200
        Me.dgvUsuarios.Columns.Item(2).Width = 50
        Me.dgvUsuarios.Columns.Item(3).Width = 75
        Me.dgvUsuarios.Columns.Item(4).Width = 75
    End Sub

    Private Sub LimpiaCampos()
        Me.txtUSUARIO.Text = ""
        Me.txtNOMBRE_USUARIO.Text = ""
        chkAutoconsumo.Checked = False
        chkProducto.Checked = False
    End Sub

    Private Function ValidaCampos() As Boolean
        If Trim(Me.txtUSUARIO.Text) = "" Then
            MsgBox("�Debe ingresar un c�digo de usuario.!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If Trim(Me.txtNOMBRE_USUARIO.Text) = "" Then
            MsgBox("�Debe ingresar un Nombre de usuario.!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If
        If intDato = 0 And intAct = 0 Then
            MsgBox("�Debe Seleccion una Accion para Autorizar..!", MsgBoxStyle.Critical, "Validaci�n")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub Mantenimiento_Usuarios(ByVal Compa�ia, ByVal CodigoUsuario, ByVal idCodigo, ByVal IUD)
        '
        Dim cmd As New SqlCommand
        If IUD = "I" Then
            Sql = " INSERT INTO  CATALOGO_AUTORIZADORES (COMPA�IA, USUARIO, TIPO_AUTORIZACION, USUARIO_CREACION, USUARIO_CREACION_FECHA, USUARIO_EDICION, USUARIO_EDICION_FECHA) VALUES " & _
                  " ( " & Compa�ia & ",'" & CodigoUsuario & "' , " & idCodigo & ", '" & Usuario & "' , GETDATE() , '" & Usuario & "', GETDATE()  ) "
            cmd.CommandText = Sql
        Else
            Sql = " UPDATE CATALOGO_AUTORIZADORES SET TIPO_AUTORIZACION = " & idCodigo & ", USUARIO_EDICION = '" & Usuario & "', USUARIO_EDICION_FECHA = GETDATE() " & _
                            " WHERE  COMPA�IA = " & Compa�ia & " AND USUARIO = '" & CodigoUsuario & "'"
            cmd.CommandText = Sql
        End If

        intDato = CInt(jClass.ejecutarComandoSql(cmd))

        MsgBox("�Transaccion Realizada con Exito...!", MsgBoxStyle.Information, "Mensaje")

    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPA�IA.SelectedIndexChanged
        If Iniciando = False Then
            CargaUsuarios(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            Dim strAccion As String
            If intDato = -1 Then
                strAccion = "I"
            Else
                strAccion = "U"
            End If
            Mantenimiento_Usuarios(Me.cmbCOMPA�IA.SelectedValue, Me.txtUSUARIO.Text, intAct, strAccion)
            LimpiaCampos()
            CargaUsuarios(Me.cmbCOMPA�IA.SelectedValue)
        End If
    End Sub


    Private Sub dgvUsuarios_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        If Me.dgvUsuarios.CurrentRow.Index < Me.dgvUsuarios.Rows.Count Then
            Me.txtUSUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(0).Value
            Me.txtNOMBRE_USUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(1).Value
            '
            Sql = " SELECT count(*) as dato FROM CATALOGO_AUTORIZADORES WHERE COMPA�IA = " & Compa�ia & " AND USUARIO = '" & Me.txtUSUARIO.Text.Trim & "'"
            intDato = CInt(jClass.obtenerEscalar(Sql))
            '
            If intDato = 0 Then
                intDato = -1
                chkAutoconsumo.Checked = False
                chkProducto.Checked = False
            Else
                Sql = " SELECT ISNULL(TIPO_AUTORIZACION,0) FROM CATALOGO_AUTORIZADORES WHERE COMPA�IA = " & Compa�ia & " AND USUARIO = '" & Me.txtUSUARIO.Text.Trim & "'"
                intDato = CInt(jClass.obtenerEscalar(Sql))
                If intDato = 0 Then
                    chkAutoconsumo.Checked = False
                    chkProducto.Checked = False
                ElseIf intDato = 1 Then
                    chkAutoconsumo.Checked = True
                    chkProducto.Checked = False
                ElseIf intDato = 2 Then
                    chkAutoconsumo.Checked = False
                    chkProducto.Checked = True
                ElseIf intDato = 3 Then
                    chkAutoconsumo.Checked = True
                    chkProducto.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub chkAutoconsumo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoconsumo.CheckedChanged
        prDatos()
    End Sub

    Private Sub chkProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProducto.CheckedChanged
        prDatos()
    End Sub
    Private Sub prDatos()
        If chkAutoconsumo.Checked = True And Me.chkProducto.Checked = False Then
            intAct = 1
        ElseIf chkAutoconsumo.Checked = False And Me.chkProducto.Checked = True Then
            intAct = 2
        ElseIf chkAutoconsumo.Checked = True And Me.chkProducto.Checked = True Then
            intAct = 3
        ElseIf chkAutoconsumo.Checked = False And Me.chkProducto.Checked = False Then
            intAct = 0
        End If
    End Sub

    Private Sub dgvUsuarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUsuarios.Click
        If Me.dgvUsuarios.CurrentRow.Index < Me.dgvUsuarios.Rows.Count Then
            Me.txtUSUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(0).Value
            Me.txtNOMBRE_USUARIO.Text = Me.dgvUsuarios.CurrentRow.Cells.Item(1).Value
            '
            Sql = " SELECT count(*) as dato FROM CATALOGO_AUTORIZADORES WHERE COMPA�IA = " & Compa�ia & " AND USUARIO = '" & Me.txtUSUARIO.Text.Trim & "'"
            intDato = CInt(jClass.obtenerEscalar(Sql))
            '
            If intDato = 0 Then
                intDato = -1
                chkAutoconsumo.Checked = False
                chkProducto.Checked = False
            Else
                Sql = " SELECT ISNULL(TIPO_AUTORIZACION,0) FROM CATALOGO_AUTORIZADORES WHERE COMPA�IA = " & Compa�ia & " AND USUARIO = '" & Me.txtUSUARIO.Text.Trim & "'"
                intDato = CInt(jClass.obtenerEscalar(Sql))
                If intDato = 0 Then
                    chkAutoconsumo.Checked = False
                    chkProducto.Checked = False
                ElseIf intDato = 1 Then
                    chkAutoconsumo.Checked = True
                    chkProducto.Checked = False
                ElseIf intDato = 2 Then
                    chkAutoconsumo.Checked = False
                    chkProducto.Checked = True
                ElseIf intDato = 3 Then
                    chkAutoconsumo.Checked = True
                    chkProducto.Checked = True
                End If
            End If
        End If
    End Sub
End Class