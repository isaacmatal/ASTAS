Imports System.Data.SqlClient

Public Class Contabilidad_Partidas_Automaticas
    Dim Sql As String
    Dim Iniciando As Boolean

    Private Sub Contabilidad_Partidas_Automaticas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaOrigen(Compañia)
        CargaCentroCosto(Compañia)
        CargaTipoDocumento(Compañia)
        CargaTipoMovimiento(Compañia)
        CargaLibrosContables(COMPAÑIA)
        CargaTipoValor(Compañia)
        CargaPartidasAutomaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
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
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE_PRINCIPAL " & Compañia
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

    Private Sub CargaOrigen(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_COOPERATIVA_CATALOGO_ORIGENES "
            Sql &= Compañia
            Sql &= ", 0"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbORIGEN.DataSource = Table
            Me.cmbORIGEN.ValueMember = "ORIGEN"
            Me.cmbORIGEN.DisplayMember = "DESCRIPCION_ORIGEN"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub CargaTipoDocumento(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO "
            Sql &= Compañia
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_DOCUMENTO.DataSource = Table
            Me.cmbTIPO_DOCUMENTO.ValueMember = "TIPO_DOCUMENTO"
            Me.cmbTIPO_DOCUMENTO.DisplayMember = "DESCRIPCION_TIPO_DOCUMENTO"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoMovimiento(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_MOVIMIENTO "
            Sql &= Compañia
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_MOVIMIENTO.DataSource = Table
            Me.cmbTIPO_MOVIMIENTO.ValueMember = "Tipo Movimiento"
            Me.cmbTIPO_MOVIMIENTO.DisplayMember = "Descripción"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCentroCosto(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CENTRO_COSTO "
            Sql &= Compañia
            Sql &= ", 3"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCENTRO_COSTO.DataSource = Table
            Me.cmbCENTRO_COSTO.ValueMember = "Centro Costo"
            Me.cmbCENTRO_COSTO.DisplayMember = "Descripción Centro Costo"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaTipoValor(ByVal Compañia)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_TIPO_VALOR "
            Sql &= Compañia
            Sql &= ", 1"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_VALOR.DataSource = Table
            Me.cmbTIPO_VALOR.ValueMember = "TIPO_VALOR"
            Me.cmbTIPO_VALOR.DisplayMember = "DESCRIPCION_TIPO_VALOR"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaCampos()
        Me.lblLINEA.Text = "0"
        Me.lblCUENTA.Text = "0"
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
        Me.txtOBSERVACIONES.Text = ""
        Me.txtVALOR.Text = "100"
        Me.TxtResta.Text = "0.00"
    End Sub

    Private Sub LimpiaGrid()
        Dim Fill As New cmbFill
        Me.dgvPartidas.Columns(1).Visible = False
        Me.dgvPartidas.Columns(3).Visible = False
        Me.dgvPartidas.Columns(5).Visible = False
        Me.dgvPartidas.Columns(10).Visible = False
        Me.dgvPartidas.Columns(13).Visible = False
        Me.dgvPartidas.Columns.Item(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dgvPartidas.Columns.Item(12).DefaultCellStyle.ForeColor = Color.Navy
        Fill.ajustarGrid(16, Me.dgvPartidas)

    End Sub

    Private Sub Mantenimiento_Partidas_Automaticas(ByVal Compañia As Integer, ByVal CentroCosto As Integer, ByVal TipoDocumento As Integer, ByVal TipoMovimiento As Integer, ByVal Linea As Integer, ByVal LC As Integer, ByVal Cuenta As Integer, ByVal Cargo As Double, ByVal Abono As Double, ByVal TipoValor As Integer, ByVal Valor As Double, ByVal Resta As Double, ByVal Observaciones As String, ByVal Origen As Integer, ByVal IUD As String)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS_IUD "
            Sql &= Compañia
            Sql &= ", " & CentroCosto
            Sql &= ", " & TipoDocumento
            Sql &= ", " & TipoMovimiento
            Sql &= ", " & Linea
            Sql &= ", " & LC
            Sql &= ", " & Cuenta
            Sql &= ", " & Cargo
            Sql &= ", " & Abono
            Sql &= ", " & TipoValor
            Sql &= ", " & Valor
            Sql &= ", " & Resta
            Sql &= ", '" & Observaciones & "'"
            Sql &= ", " & Origen
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Partida Automática Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Partida Automática Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Partida Automática Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        'If Trim(Me.lblCUENTA.Text) = "0" Then
        '    MsgBox("¡Debe seleccionar una Cuenta Contable válida!", MsgBoxStyle.Critical, "Validación")
        '    Return False
        '    Exit Function
        'End If
        If Trim(Me.txtCUENTA_COMPLETA.Text) = "" Then
            MsgBox("¡Debe seleccionar una Cuenta Contable válida!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        'If Trim(Me.txtOBSERVACIONES.Text) = "" Then
        '    MsgBox("¡Debe ingresar una Observación válida!", MsgBoxStyle.Critical, "Validación")
        '    Return False
        '    Exit Function
        'End If
        If Trim(Me.txtVALOR.Text) = "" Then
            MsgBox("¡Debe ingresar un Valor válido!", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        'If Trim(Me.TxtResta.Text) = "" Then
        '    MsgBox("¡Debe ingresar un valor numèrico válido!", MsgBoxStyle.Critical, "Validación")
        '    Return False
        '    Exit Function
        'End If
        Return True
    End Function

    Private Sub CargaPartidasAutomaticas(ByVal Compañia, ByVal CentroCosto, ByVal TipoDocumento, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS  "
            Sql &= Compañia
            Sql &= ", " & CentroCosto
            Sql &= ", " & TipoDocumento
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvPartidas.Columns.Clear()
            Me.dgvPartidas.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = Compañia
        Cuentas.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
        Cuentas.cmbLIBRO_CONTABLE.Enabled = False
        Producto = ""
        Tipo = ""
        Descripcion_Producto = ""
        Cuentas.ShowDialog()
        If Producto <> "" Then
            Me.lblCUENTA.Text = Producto
            Me.txtCUENTA_COMPLETA.Text = Tipo
            Me.txtDESCRIPCION_CUENTA.Text = Descripcion_Producto
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
        End If
    End Sub

    Private Sub btnNuevoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCuenta.Click
        LimpiaCampos()
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        LimpiaCampos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            If Me.lblLINEA.Text = "0" Then
                Mantenimiento_Partidas_Automaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbTIPO_MOVIMIENTO.SelectedValue, Me.lblLINEA.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.lblCUENTA.Text, IIf(Me.rbtnCARGO.Checked = True, "1", "0"), IIf(Me.rbtnABONO.Checked = True, "1", "0"), Me.cmbTIPO_VALOR.SelectedValue, Val(Me.txtVALOR.Text), Val(Me.TxtResta.Text), Trim(Me.txtOBSERVACIONES.Text), Me.cmbORIGEN.SelectedValue, "I")
            Else
                Mantenimiento_Partidas_Automaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbTIPO_MOVIMIENTO.SelectedValue, Me.lblLINEA.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.lblCUENTA.Text, IIf(Me.rbtnCARGO.Checked = True, "1", "0"), IIf(Me.rbtnABONO.Checked = True, "1", "0"), Me.cmbTIPO_VALOR.SelectedValue, Val(Me.txtVALOR.Text), Val(Me.TxtResta.Text), Trim(Me.txtOBSERVACIONES.Text), Me.cmbORIGEN.SelectedValue, "U")
            End If
            LimpiaCampos()
            CargaPartidasAutomaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
        End If
    End Sub

    Private Sub cmbTIPO_DOCUMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_DOCUMENTO.SelectedIndexChanged
        If Iniciando = False And Me.cmbTIPO_DOCUMENTO.ValueMember <> "" Then
            LimpiaCampos()
            CargaPartidasAutomaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
        End If
    End Sub

    Private Sub cmbCENTRO_COSTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCENTRO_COSTO.SelectedIndexChanged
        If Iniciando = False And Me.cmbCENTRO_COSTO.ValueMember <> "" Then
            LimpiaCampos()
            CargaPartidasAutomaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.lblLINEA.Text <> "0" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Partidas_Automaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbTIPO_MOVIMIENTO.SelectedValue, Me.lblLINEA.Text, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.lblCUENTA.Text, IIf(Me.rbtnCARGO.Checked = True, "1", "0"), IIf(Me.rbtnABONO.Checked = True, "1", "0"), Me.cmbTIPO_VALOR.SelectedValue, Me.txtVALOR.Text, Me.TxtResta.Text, Trim(Me.txtOBSERVACIONES.Text), Me.cmbORIGEN.SelectedValue, "D")
                LimpiaCampos()
                CargaPartidasAutomaticas(Compañia, Me.cmbCENTRO_COSTO.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, 1)
            End If
        End If
    End Sub

    Private Sub dgvPartidas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartidas.CellEnter
        Me.lblLINEA.Text = Me.dgvPartidas.CurrentRow.Cells.Item(0).Value
        Me.cmbTIPO_MOVIMIENTO.SelectedValue = Me.dgvPartidas.CurrentRow.Cells.Item(1).Value
        Me.cmbLIBRO_CONTABLE.SelectedValue = Me.dgvPartidas.CurrentRow.Cells.Item(3).Value
        Me.lblCUENTA.Text = Me.dgvPartidas.CurrentRow.Cells.Item(5).Value
        Me.txtCUENTA_COMPLETA.Text = Me.dgvPartidas.CurrentRow.Cells.Item(6).Value
        Me.txtDESCRIPCION_CUENTA.Text = Me.dgvPartidas.CurrentRow.Cells.Item(7).Value
        Me.rbtnCARGO.Checked = Me.dgvPartidas.CurrentRow.Cells.Item(8).Value
        Me.rbtnABONO.Checked = Me.dgvPartidas.CurrentRow.Cells.Item(9).Value
        Me.cmbTIPO_VALOR.SelectedValue = Me.dgvPartidas.CurrentRow.Cells.Item(10).Value
        Me.txtVALOR.Text = Me.dgvPartidas.CurrentRow.Cells.Item(12).Value
        Me.cmbORIGEN.SelectedValue = Me.dgvPartidas.CurrentRow.Cells.Item(13).Value
        Me.txtOBSERVACIONES.Text = Me.dgvPartidas.CurrentRow.Cells.Item(15).Value
        Me.TxtResta.Text = Me.dgvPartidas.CurrentRow.Cells.Item(16).Value
    End Sub

    Private Sub cmbTIPO_MOVIMIENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_MOVIMIENTO.SelectedIndexChanged
        'LimpiaCampos()
    End Sub

    Private Sub txtVALOR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVALOR.KeyPress
        Dim cadena As String = Me.txtVALOR.Text
        Dim Ocurrencias As Byte = 0
        Dim str As String() = cadena.Split(".")
        For I As Integer = 0 To str.Length - 1
            Ocurrencias = Ocurrencias + 1
        Next
        Ocurrencias = Ocurrencias - 1
        If e.KeyChar <> ControlChars.Back And (Char.IsDigit(e.KeyChar) = False And e.KeyChar <> (".")) Or (e.KeyChar = (".") And Ocurrencias <> 0) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cmbTIPO_VALOR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_VALOR.SelectedIndexChanged
        Me.lblValor.Text = Me.cmbTIPO_VALOR.Text
    End Sub

    Private Sub Contabilidad_Partidas_Automaticas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = Nothing
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.LostFocus
        Dim jc As New jarsClass
        If txtCUENTA_COMPLETA.Text.Length > 0 Then
            Dim tbl As DataTable = jc.ejecutaSQLl_llenaDTABLE("SELECT DESCRIPCION_CUENTA,CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_COMPLETA.Text.Trim & "' AND CUENTA_MAYOR=0")

            If tbl IsNot Nothing And tbl.Rows.Count > 0 Then
                Dim DescripcionCuentaSeleccionada As String = tbl.Rows(0)(0)

                If DescripcionCuentaSeleccionada = "" Then
                    txtCUENTA_COMPLETA.Text = ""
                    lblCUENTA.Text = ""
                    MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                Else
                    lblCUENTA.Text = tbl.Rows(0)(1).ToString.Trim
                    Me.txtDESCRIPCION_CUENTA.Text = DescripcionCuentaSeleccionada
                End If
            Else
                MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class