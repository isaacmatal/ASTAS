Imports System.Data.SqlClient

Public Class Contabilidad_Cuentas
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim Table1 As New DataTable
    Dim jClass As New jarsClass
    Dim ctaInvalida As Boolean = False

    Private Sub Contabilidad_Cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables(Compañia)
        CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", "", 1)
        CargaTipoCuenta()
        TipoCatalogoAsociado()
        LimpiaCampos()
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "Código"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoCuenta()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_CUENTA_SIUD " & Compañia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTipoCuenta.DataSource = Table
            Me.cmbTipoCuenta.ValueMember = "TIPO_CUENTA"
            Me.cmbTipoCuenta.DisplayMember = "DESCRIPCION_TIPO_CUENTA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TipoCatalogoAsociado()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT TIPO, CATALOGO FROM CONTABILIDAD_CATALOGO_CODIGO_DETALLE WHERE COMPAÑIA = " & Compañia & " GROUP BY TIPO, CATALOGO" & vbCrLf
            Sql &= " UNION SELECT 0 AS TIPO, 'Ninguno' AS CATALOGO ORDER BY TIPO"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCatalogoAsociado.DataSource = Table
            Me.cmbCatalogoAsociado.ValueMember = "TIPO"
            Me.cmbCatalogoAsociado.DisplayMember = "CATALOGO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Mantenimiento_Cuentas(ByVal Compañia, ByVal LibroContable, ByVal Cuenta, ByVal CuentaCompleta, ByVal Descripcion, ByVal Mayor, ByVal TipoPartida, ByVal IUD, ByVal TipoCuenta, ByVal EsBalance, ByVal Catalogo)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim jc As New jarsClass
        Dim RowsAffected As Integer
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CUENTAS_IUD " & vbCrLf
            Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @LIBRO_CONTABLE = " & LibroContable & vbCrLf
            Sql &= ", @CUENTA = " & Cuenta & vbCrLf
            Sql &= ", @CUENTA_COMPLETA = '" & CuentaCompleta & "'" & vbCrLf
            Sql &= ", @DESCRIPCION_CUENTA = '" & Descripcion & "'" & vbCrLf
            Sql &= ", @CUENTA_MAYOR = " & Mayor & vbCrLf
            Sql &= ", @TIPO_PARTIDA = " & TipoPartida & vbCrLf
            Sql &= ", @USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ", @IUD = '" & IUD & "'" & vbCrLf
            Sql &= ", @TIPO_CUENTA = " & TipoCuenta & vbCrLf
            Sql &= ", @ES_BALANCE = " & EsBalance & vbCrLf
            Sql &= ", @CATALOGO = " & Catalogo
            Comando_ = New SqlCommand(Sql, Conexion_)
            RowsAffected = Comando_.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("¡Cuenta Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                    Case "U"
                        MsgBox("¡Cuenta Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                    Case "D"
                        MsgBox("¡Cuenta Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                End Select
            Else
                MsgBox("No se Registraron los cambios", MsgBoxStyle.Exclamation, "Mensaje")
            End If
        Catch ex As SqlException
            If ex.Number = 547 Then
                MsgBox("Existen registros relacionados con la Cuenta Contable" & vbCrLf & "que está intentando eliminar.", MsgBoxStyle.Critical, "Error")
            Else
                jc.msjError(ex, "Catalogo Cuentas")
            End If
        Finally
            Conexion_.Close()
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.txtCUENTA.Text = "0"
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
        Me.chkCUENTA_MAYOR.Checked = False
        Me.cmbTipoCuenta.SelectedItem = 0
        Me.chkEs_Balance.Checked = False
    End Sub

    Private Function ValidaCamposCuenta() As Boolean
        If Trim(Me.txtCUENTA_COMPLETA.Text) = "" Then
            MsgBox("¡Debe Ingresar una Cuenta Contable válida!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Trim(Me.txtDESCRIPCION_CUENTA.Text) = "" Then
            MsgBox("¡Debe Ingresar una Descripción a la Cuenta Contable!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If CInt(Trim(Me.txtCUENTA_COMPLETA.Text).Substring(0, 1)) <> Me.cmbTipoCuenta.SelectedValue Then
            MsgBox("¡El tipo de cuenta no coincide!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
            If Me.txtCUENTA_COMPLETA.Text.Length = 2 Or Me.txtCUENTA_COMPLETA.Text.Length = 4 Or Me.txtCUENTA_COMPLETA.Text.Length = 6 Or Me.txtCUENTA_COMPLETA.Text.Length = 8 Or Me.txtCUENTA_COMPLETA.Text.Length = 13 Then
                Return True
            Else
                MsgBox("¡Debe Ingresar una Cuenta Contable válida!", MsgBoxStyle.Critical, "Validación")
                Return False
            End If
        End If
        If ctaInvalida Then
            MsgBox("¡Debe Ingresar una Cuenta Contable válida!", MsgBoxStyle.Critical, "Validación")
            Return False
        End If
        Return True
    End Function

    Private Sub LimpiaGrid()
        Me.dgvCuentas.Columns.Item(2).Width = 300
        Me.dgvCuentas.Columns(0).Visible = False
        Me.dgvCuentas.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(4).Visible = False
        Me.dgvCuentas.Columns.Item(5).Visible = False
        Me.dgvCuentas.Columns.Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentas.Columns.Item(8).Visible = False
        Me.dgvCuentas.Columns.Item("CATALOGO").Visible = False
    End Sub

    Private Sub CargaCuentas(ByVal Compañia, ByVal LibroContable, ByVal CuentaCompleta, ByVal DescripcionCuenta, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Dim RowsCtas As DataRow()
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", '" & CuentaCompleta & "'"
            Sql &= ", '" & DescripcionCuenta & "'"
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Table1.Reset()
            Table1 = Table.Clone()
            RowsCtas = Table.Select(Nothing, "Cuenta")
            For Each Row As DataRow In RowsCtas
                Table1.ImportRow(Row)
            Next
            Me.dgvCuentas.Columns.Clear()
            Me.dgvCuentas.DataSource = Table1
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCuenta(ByVal Compañia, ByVal LibroContable, ByVal CuentaCompleta, ByVal DescripcionCuenta, ByVal Bandera) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Dim Result As Boolean = False
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_VALIDACION "
            Sql &= Compañia
            Sql &= ", " & LibroContable
            Sql &= ", '" & CuentaCompleta & "'"
            Sql &= ", '" & DescripcionCuenta & "'"
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True And Val(Me.txtCUENTA.Text) = 0 Then
                MsgBox("¡Ya existe la Cuenta " & DataReader_.Item("Cuenta") & " - " & DataReader_.Item("Descripción Cuenta") & "!", MsgBoxStyle.Information, "Validación")
                Result = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Result = True
        Finally
            Conexion_.Close()
        End Try
        Return Result
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim IUD As String
        If ValidaCamposCuenta() = True Then
            If ValidaCuenta(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Trim(Me.txtCUENTA_COMPLETA.Text), "", 0) = False Then
                'Me.txtCUENTA_COMPLETA.Text = Me.txtCUENTA_COMPLETA.Text & Space(8)
                If Trim(Me.txtCUENTA.Text) = "0" Then
                    IUD = "I"
                Else
                    IUD = "U"
                End If
                Mantenimiento_Cuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text), IIf(Me.chkCUENTA_MAYOR.Checked = True, "1", "0"), 2, IUD, Me.cmbTipoCuenta.SelectedValue, Me.chkEs_Balance.Checked, Me.cmbCatalogoAsociado.SelectedValue)
                CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", "", 1)
                LimpiaCampos()
            End If
        End If
    End Sub


    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        If Iniciando = False Then
            CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", "", 1)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Val(Me.txtCUENTA.Text) > 0 Then
            If CInt(jClass.obtenerEscalar("SELECT COUNT(CUENTA) FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA LIKE '" & Me.txtCUENTA_COMPLETA.Text & "%'")) > 1 Then
                MsgBox("Debe eliminar las cuentas de orden inferior antes de eliminar la cuenta: " & vbCrLf & Me.txtCUENTA_COMPLETA.Text & " " & Me.txtDESCRIPCION_CUENTA.Text, MsgBoxStyle.Information, "Registros Relacionados")
                Return
            End If
            If MsgBox("¿Está seguro(a) que desea eliminar la Cuenta Contable seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Cuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.txtCUENTA.Text, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text), IIf(Me.chkCUENTA_MAYOR.Checked = True, "1", "0"), 2, "D", Me.cmbTipoCuenta.SelectedValue, Me.chkEs_Balance.Checked, 0)
                CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", "", 1)
                LimpiaCampos()
            End If
        Else
            MsgBox("Debe seleccionar una Cuenta Contable válida.", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub dgvCuentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentas.CellClick
        Me.txtCUENTA.Text = Me.dgvCuentas.CurrentRow.Cells.Item(0).Value
        Me.txtCUENTA_COMPLETA.Text = Me.dgvCuentas.CurrentRow.Cells.Item(1).Value
        Me.txtDESCRIPCION_CUENTA.Text = Me.dgvCuentas.CurrentRow.Cells.Item(2).Value
        If Me.dgvCuentas.CurrentRow.Cells.Item(3).Value = 0 Then
            Me.chkCUENTA_MAYOR.Checked = False
        Else
            Me.chkCUENTA_MAYOR.Checked = True
        End If
        Me.cmbTipoCuenta.SelectedValue = Me.dgvCuentas.CurrentRow.Cells.Item(8).Value
        Me.chkEs_Balance.Checked = Me.dgvCuentas.CurrentRow.Cells.Item(9).Value
        Me.cmbCatalogoAsociado.SelectedValue = Me.dgvCuentas.CurrentRow.Cells.Item("CATALOGO").Value
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Trim(Me.txtCUENTA_COMPLETA.Text) = "" And Trim(Me.txtDESCRIPCION_CUENTA.Text) = "" Then
            CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", "", 1)
            'MsgBox("Ingrese datos en la 'Cuenta' o en la 'Descripción' para poder realizar la búsqueda.", MsgBoxStyle.Critical, "Validación")
        Else
            CargaCuentas(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Trim(Me.txtCUENTA_COMPLETA.Text), Trim(Me.txtDESCRIPCION_CUENTA.Text), 2)
            LimpiaCampos()
        End If
    End Sub


    Private Sub btnNuevoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCuenta.Click
        LimpiaCampos()
    End Sub

    Private Sub Contabilidad_Cuentas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.LostFocus
        If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
            If Not ctaInvalida Then
                If Me.txtCUENTA_COMPLETA.Text.Length > 0 Then
                    Me.cmbTipoCuenta.SelectedValue = CInt(Me.txtCUENTA_COMPLETA.Text.Substring(0, 1))
                    If Me.txtCUENTA_COMPLETA.Text.Length < 13 Then
                        Me.chkCUENTA_MAYOR.Checked = True
                    Else
                        Me.chkCUENTA_MAYOR.Checked = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.TextChanged
        ctaInvalida = False
        If Me.cmbLIBRO_CONTABLE.SelectedValue = 1 Then
            If txtCUENTA_COMPLETA.Text.Length > 0 Then
                If txtCUENTA_COMPLETA.Text.Length = 1 Then
                    If Not "12345678".Contains(txtCUENTA_COMPLETA.Text) Then
                        MsgBox("Cuenta no corresponde a la nomenclatura establecida", MsgBoxStyle.Information, "Cuenta No Válida")
                        ctaInvalida = True
                    End If
                ElseIf txtCUENTA_COMPLETA.Text.Length > 1 Then
                    Sql = "SELECT COUNT(CUENTA) FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue & vbCrLf
                    Sql &= " AND CUENTA_COMPLETA LIKE '" & Me.txtCUENTA_COMPLETA.Text.Substring(0, Me.txtCUENTA_COMPLETA.Text.Length - 1) & "%'"
                    If jClass.obtenerEscalar(Sql) = 0 Then
                        MsgBox("No existe cuenta de orden superior relacionada a lo digitado.", MsgBoxStyle.Information, "Cuenta No Válida")
                        ctaInvalida = True
                    End If
                End If
            End If
        End If
    End Sub
End Class