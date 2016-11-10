Imports System.Data.SqlClient

Public Class Contabilidad_Bancos
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim c_data2 As New jarsClass
    Dim Table1 As DataTable
    Dim Table2 As DataTable
    Dim dt As DataTable

    Private Sub Contabilidad_Bancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaBancos(Compañia, 0)
        CargaLibrosContables(Compañia)
        CargaTipoCuentaBancaria(Compañia, 0)
        Iniciando = False
        LimpiaCamposBanco()
        LimpiaCamposCuenta()
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

    Private Sub CargaTipoCuentaBancaria(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_TIPO_CUENTA "
            Sql &= Compañia
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbTIPO_CUENTA_BANCARIA.DataSource = Table
            Me.cmbTIPO_CUENTA_BANCARIA.ValueMember = "TIPO_CUENTA_BANCARIA"
            Me.cmbTIPO_CUENTA_BANCARIA.DisplayMember = "DESCRIPCION_TIPO_CUENTA_BANCARIA"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function ValidaCamposBanco() As Boolean
        If Trim(Me.txtDESCRIPCION_BANCO.Text) = "" Then
            MsgBox("¡Debe ingresar una Descripción de Banco válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ValidaCamposCuentaBancaria() As Boolean
        If Trim(Me.txtBANCO.Text) = "" Or Trim(Me.txtBANCO.Text) = "0" Then
            MsgBox("¡Debe seleccionar un Banco válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtCUENTA_BANCARIA.Text) = "" Then
            MsgBox("¡Debe ingresar una Cuenta Bancaria válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.lblCUENTA.Text) = "" Then
            MsgBox("¡Debe seleccionar una Cuenta Contable válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Function ValidaCamposChequera() As Boolean
        If Me.txtBANCO.Text = "" Then
            MsgBox("¡Debe seleccionar un Banco válido! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Me.cmbCUENTA_BANCARIA.Text = "" Then
            MsgBox("¡Debe seleccionar una Cuenta Bancaria válida! Verifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtDESCRIPCION_CHEQUERA.Text) = "" Then
            MsgBox("¡Debe ingresar una descripción válida a la Chequera! Verrifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtINICIAL.Text) = "" Then
            MsgBox("¡Debe ingresar un correlativo Inicial válido! Verrifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtFINAL.Text) = "" Then
            MsgBox("¡Debe ingresar un correlativo Final válido! Verrifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Trim(Me.txtACTUAL.Text) = "" Then
            MsgBox("¡Debe ingresar un correlativo Actual válido! Verrifique", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Val(Me.txtINICIAL.Text) >= Val(Me.txtFINAL.Text) Then
            MsgBox("El Valor Inicial no puede ser mayo o igual al valor Final", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        If Val(Me.txtACTUAL.Text) >= Val(Me.txtFINAL.Text) Or Val(Me.txtACTUAL.Text) < Val(Me.txtINICIAL.Text) Then
            MsgBox("El Valor Actual debe estar en el rago definido por [<Valor Inicial> - <Valor Final>] ", MsgBoxStyle.Critical, "Validación")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub LimpiaCamposBanco()
        Me.txtBANCO.Text = ""
        Me.txtDESCRIPCION_BANCO.Text = ""
    End Sub

    Private Sub LimpiaCamposCuenta()
        Me.txtCUENTA_BANCARIA.Text = ""
        Me.lblCUENTA.Text = ""
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
    End Sub

    Private Sub LimpiaCamposChequera()
        Me.lblCHEQUERA.Text = ""
        Me.txtDESCRIPCION_CHEQUERA.Text = ""
        Me.txtINICIAL.Text = ""
        Me.txtFINAL.Text = ""
        Me.txtACTUAL.Text = ""
        Me.chkACTIVA.Checked = False
    End Sub

    Private Sub Mantenimiento_Bancos(ByVal Compañia, ByVal Banco, ByVal Descripcion, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim jc As New jarsClass
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_IUD "
            Sql &= Compañia
            Sql &= ", " & IIf(Banco = "", "0", Banco)
            Sql &= ", '" & Descripcion & "'"
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Banco Almacenado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Banco Actualizado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Banco Eliminado con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As SqlException
            If ex.Number = 547 Then
                MsgBox("Existen registros relacionados con el Banco" & vbCrLf & "que está intentando eliminar.", MsgBoxStyle.Critical, "Error")
            Else
                jc.msjError(ex, "Catalogo Cuentas")
            End If
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_CuentasBancarias(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal TipoCuenta, ByVal LibroContable, ByVal Cuenta, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim jc As New jarsClass
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_IUD "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & TipoCuenta
            Sql &= ", " & LibroContable
            Sql &= ", " & Cuenta
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Cuenta Bancaria Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Cuenta Bancaria Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Cuenta Bancaria Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As SqlException
            If ex.Number = 547 Then
                MsgBox("Existen registros relacionados con la Cuenta Bancaria" & vbCrLf & "que está intentando eliminar.", MsgBoxStyle.Critical, "Error")
            Else
                jc.msjError(ex, "Catalogo Cuentas")
            End If
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Mantenimiento_Chequeras(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Chequera, ByVal DescripcionCH, ByVal Inicial, ByVal Final, ByVal Actual, ByVal Activa, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS_IUD "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & CuentaBancaria & "'"
            Sql &= ", " & Chequera
            Sql &= ", '" & DescripcionCH & "'"
            Sql &= ", " & Inicial
            Sql &= ", " & Final
            Sql &= ", " & Actual
            Sql &= ", " & Activa
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
            Select Case IUD
                Case "I"
                    MsgBox("¡Chequera Almacenada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "U"
                    MsgBox("¡Chequera Actualizada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
                Case "D"
                    MsgBox("¡Chequera Eliminada con éxito!", MsgBoxStyle.Exclamation, "Mensaje")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaBancos(ByVal Compañia, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter        
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Compañia
            Sql &= ", 0" 'Banco
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table1 = New DataTable("Datos")
            DataAdapter_.Fill(Table1)
            Me.dgvBancos.Columns.Clear()
            Me.dgvBancos.DataSource = Table1
            LImpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasBancarias(ByVal Compañia, ByVal Banco, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table2 = New DataTable("Datos")
            DataAdapter_.Fill(Table2)
            Me.dgvCuentasBancarias.Columns.Clear()
            Me.dgvCuentasBancarias.DataSource = Table2
            LImpiaGridCuentasBancarias()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaCuentasBancariasCH(ByVal Compañia, ByVal Banco, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS  "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbCUENTA_BANCARIA.DataSource = Table
            Me.cmbCUENTA_BANCARIA.ValueMember = "Cuenta"
            Me.cmbCUENTA_BANCARIA.DisplayMember = "Descripción Cuenta"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaChequeras(ByVal Compañia, ByVal Banco, ByVal CuentaBancaria, ByVal Bandera)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Dim validacion As Integer
        Try
            validacion = CuentaBancaria
        Catch ex As Exception
            CuentaBancaria = 0
        End Try
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS  "
            Sql &= Compañia
            Sql &= ", " & Banco
            Sql &= ", '" & Val(CuentaBancaria) & "'"
            Sql &= ", " & Bandera
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvChequeras.Columns.Clear()
            Me.dgvChequeras.DataSource = Table
            LimpiaGridChequeras()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvBancos.Columns.Item(0).Width = 50
        Me.dgvBancos.Columns.Item(1).Width = 200
        Me.dgvBancos.Columns.Item(2).Width = 75
        Me.dgvBancos.Columns.Item(3).Width = 125
    End Sub

    Private Sub LimpiaGridCuentasBancarias()
        Me.dgvCuentasBancarias.Columns.Item(0).Width = 100
        Me.dgvCuentasBancarias.Columns.Item(1).Width = 0 'Tipo Cuenta
        Me.dgvCuentasBancarias.Columns.Item(2).Width = 100 'Descripcion Tipo Cuenta
        Me.dgvCuentasBancarias.Columns.Item(3).Width = 0 'Cuenta
        Me.dgvCuentasBancarias.Columns.Item(4).Width = 75 'Cuenta Contable
        Me.dgvCuentasBancarias.Columns.Item(5).Width = 200 'Descaripción Cuenta
        Me.dgvCuentasBancarias.Columns.Item(6).Width = 0 'LC
        Me.dgvCuentasBancarias.Columns.Item(7).Width = 150 'Descripción LC
        Me.dgvCuentasBancarias.Columns.Item(8).Width = 75
        Me.dgvCuentasBancarias.Columns.Item(9).Width = 125
        Me.dgvCuentasBancarias.Columns(1).Visible = False
        Me.dgvCuentasBancarias.Columns(3).Visible = False
        Me.dgvCuentasBancarias.Columns(6).Visible = False

        Me.dgvCuentasBancarias.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentasBancarias.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCuentasBancarias.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub LimpiaGridChequeras()
        Me.dgvChequeras.Columns.Item(0).Width = 50
        Me.dgvChequeras.Columns.Item(1).Width = 150
        Me.dgvChequeras.Columns.Item(2).Width = 50
        Me.dgvChequeras.Columns.Item(3).Width = 50
        Me.dgvChequeras.Columns.Item(4).Width = 50
        Me.dgvChequeras.Columns.Item(5).Width = 50
        Me.dgvChequeras.Columns.Item(6).Width = 75
        Me.dgvChequeras.Columns.Item(7).Width = 125

        Me.dgvChequeras.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvChequeras.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvChequeras.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCamposBanco() = True Then
            If Trim(Me.txtBANCO.Text) = "" Then
                Mantenimiento_Bancos(Compañia, Me.txtBANCO.Text, Trim(Me.txtDESCRIPCION_BANCO.Text), "I")
            Else
                Mantenimiento_Bancos(Compañia, Me.txtBANCO.Text, Trim(Me.txtDESCRIPCION_BANCO.Text), "U")
            End If
            CargaBancos(Compañia, 0)
            LimpiaCamposBanco()
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCamposBanco()
    End Sub

    Private Sub dgvBancos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBancos.CellClick
        Try
            If Iniciando = False Then
                Me.txtBANCO.Text = Me.dgvBancos.CurrentRow.Cells.Item(0).Value
                Me.txtDESCRIPCION_BANCO.Text = Me.dgvBancos.CurrentRow.Cells.Item(1).Value
                LimpiaCamposCuenta()
                CargaCuentasBancarias(COMPAÑIA, Me.txtBANCO.Text, 1)
                LimpiaCamposChequera()
                CargaCuentasBancariasCH(Compañia, Me.txtBANCO.Text, 2)
                'CargaChequeras(Compañia, Val(Me.txtBANCO.Text), Me.cmbCUENTA_BANCARIA.SelectedValue, 1)
            End If
        Catch ex As Exception

        End Try        
    End Sub


    Private Sub btnNuevoCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCB.Click
        LimpiaCamposCuenta()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(Me.txtBANCO.Text) <> "" And Trim(Me.txtBANCO.Text) <> "0" Then
            If MsgBox("¿Está seguro(a) que desea eliminar el Banco seleccionado y todas sus Cuentas Bancarias asociadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Bancos(Compañia, Me.txtBANCO.Text, Trim(Me.txtDESCRIPCION_BANCO.Text), "D")
                CargaBancos(Compañia, 0)
                CargaCuentasBancarias(Compañia, 0, 1)
                LimpiaCamposBanco()
                LimpiaCamposCuenta()
            End If
        Else
            MsgBox("¡Debe seleccionar un Banco válido! Verifique", MsgBoxStyle.Critical, "Validación")
        End If

    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Dim Cuentas As New Contabilidad_BusquedaCuentas
        Cuentas.Compañia_Value = COMPAÑIA
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

    Private Sub btnGuardarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCB.Click
        If ValidaCamposCuentaBancaria() = True Then
            Mantenimiento_CuentasBancarias(Compañia, Me.txtBANCO.Text, Trim(Me.txtCUENTA_BANCARIA.Text), Me.cmbTIPO_CUENTA_BANCARIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.lblCUENTA.Text, "I")
            CargaCuentasBancarias(Compañia, Me.txtBANCO.Text, 1)
            LimpiaCamposCuenta()
        End If
    End Sub

    Private Sub btnEliminarCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCB.Click
        If ValidaCamposCuentaBancaria() = True Then
            If MsgBox("¿Está seguro(a) que desea eliminar la Cuenta Bancaria seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_CuentasBancarias(Compañia, Me.txtBANCO.Text, Trim(Me.txtCUENTA_BANCARIA.Text), Me.cmbTIPO_CUENTA_BANCARIA.SelectedValue, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.lblCUENTA.Text, "D")
                CargaCuentasBancarias(Compañia, Me.txtBANCO.Text, 1)
                LimpiaCamposCuenta()
            End If
        End If
    End Sub

    Private Sub dgvCuentasBancarias_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasBancarias.CellEnter
        If e.RowIndex > -1 Then
            txtCUENTA_BANCARIA.Text = dgvCuentasBancarias.Rows(e.RowIndex).Cells(0).Value.ToString()
            cmbTIPO_CUENTA_BANCARIA.SelectedValue = dgvCuentasBancarias.Rows(e.RowIndex).Cells(1).Value
            cmbLIBRO_CONTABLE.SelectedValue = dgvCuentasBancarias.Rows(e.RowIndex).Cells(6).Value
            txtCUENTA_COMPLETA.Text = dgvCuentasBancarias.Rows(e.RowIndex).Cells(4).Value.ToString()
            Me.lblCUENTA.Text = c_data2.obtenerEscalar("SELECT CUENTA FROM VISTA_CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND  CUENTA_COMPLETA='" & Me.txtCUENTA_COMPLETA.Text & "'")
            Me.txtDESCRIPCION_CUENTA.Text = c_data2.obtenerEscalar("SELECT DESCRIPCION_CUENTA FROM VISTA_CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & Me.cmbLIBRO_CONTABLE.SelectedValue & " AND  CUENTA_COMPLETA='" & Me.txtCUENTA_COMPLETA.Text & "'")
            'Cargar datos de chequeras
            Me.cmbCUENTA_BANCARIA.SelectedValue = txtCUENTA_BANCARIA.Text 'Me.dgvCuentasBancarias.CurrentRow.Cells(1).Value
            cargaDetalleChequeras(txtCUENTA_BANCARIA.Text)
        End If
    End Sub

    Private Sub cargaDetalleChequeras(ByVal cuentaBancaria As String)
        Dim query As String
        Dim dt As DataTable
        Dim Comando_ As SqlCommand

        query = "SELECT CHEQUERA, DESCRIPCION_CHEQUERA, INICIAL, FINAL, ACTUAL, ACTIVA "
        query &= "FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS "
        query &= "WHERE Compañia = " & Compañia
        query &= " AND BANCO=" & Me.txtBANCO.Text
        query &= " AND CUENTA_BANCARIA='" & cuentaBancaria.Trim & "'"

        Comando_ = New SqlCommand(query)
        dt = c_data2.obtenerDatos(Comando_)

        Me.dgvChequeras.DataSource = dt
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        Me.lblCUENTA.Text = ""
        Me.txtCUENTA_COMPLETA.Text = ""
        Me.txtDESCRIPCION_CUENTA.Text = ""
    End Sub

    Private Sub btnGuardarCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCH.Click
        If ValidaCamposChequera() = True Then
            If Me.lblCHEQUERA.Text = "" Then
                Mantenimiento_Chequeras(Compañia, Me.txtBANCO.Text, Me.cmbCUENTA_BANCARIA.SelectedValue, Val(Me.lblCHEQUERA.Text), _
                Trim(Me.txtDESCRIPCION_CHEQUERA.Text), Me.txtINICIAL.Text, Me.txtFINAL.Text, Me.txtACTUAL.Text, IIf(Me.chkACTIVA.Checked = True, "1", "0"), "I")
            Else
                Mantenimiento_Chequeras(Compañia, Me.txtBANCO.Text, Me.cmbCUENTA_BANCARIA.SelectedValue, Val(Me.lblCHEQUERA.Text), _
                Trim(Me.txtDESCRIPCION_CHEQUERA.Text), Me.txtINICIAL.Text, Me.txtFINAL.Text, Me.txtACTUAL.Text, IIf(Me.chkACTIVA.Checked = True, "1", "0"), "U")
            End If
            LimpiaCamposChequera()
            cargaDetalleChequeras(Me.cmbCUENTA_BANCARIA.SelectedValue)
        End If
    End Sub

    Private Sub btnNuevoCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCH.Click
        LimpiaCamposChequera()
    End Sub

    Private Sub txtINICIAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtINICIAL.KeyPress
        If e.KeyChar <> ControlChars.Back And Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtFINAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFINAL.KeyPress
        If e.KeyChar <> ControlChars.Back And Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtACTUAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtACTUAL.KeyPress
        If e.KeyChar <> ControlChars.Back And Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub btnEliminarCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCH.Click
        If Trim(Me.lblCHEQUERA.Text) <> "" Then
            If MsgBox("¿Está seguro(a) que desea eliminar la Chequera seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
                Mantenimiento_Chequeras(Compañia, Me.txtBANCO.Text, Me.cmbCUENTA_BANCARIA.SelectedValue, Val(Me.lblCHEQUERA.Text), _
                                Trim(Me.txtDESCRIPCION_CHEQUERA.Text), Me.txtINICIAL.Text, Me.txtFINAL.Text, Me.txtACTUAL.Text, IIf(Me.chkACTIVA.Checked = True, "1", "0"), "D")
            End If
            cargaDetalleChequeras(Me.cmbCUENTA_BANCARIA.SelectedValue)
        Else
            MsgBox("¡Debe seleccionar una Chequera válida! Verifique", MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCUENTA_COMPLETA.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            If txtCUENTA_COMPLETA.Text = "" Then
                MsgBox("Favor ingresar un codigo de cuenta", MsgBoxStyle.Information)
            Else
                Dim tbl As DataTable = c_data2.ejecutaSQLl_llenaDTABLE("SELECT DESCRIPCION_CUENTA,CUENTA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPAÑIA=" & Compañia & " AND LIBRO_CONTABLE=" & cmbLIBRO_CONTABLE.SelectedValue & " AND CUENTA_COMPLETA='" & txtCUENTA_COMPLETA.Text.Trim & "' AND CUENTA_MAYOR=0")

                If tbl IsNot Nothing And tbl.Rows.Count > 0 Then
                    txtDESCRIPCION_CUENTA.Text = tbl.Rows(0)(0)

                    If txtDESCRIPCION_CUENTA.Text = "" Then
                        txtCUENTA_COMPLETA.Text = ""
                        lblCUENTA.Text = ""
                        MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                    Else
                        btnNuevoCB.Focus()
                        lblCUENTA.Text = tbl.Rows(0)(1).ToString.Trim
                    End If
                Else
                    MsgBox("La cuenta ingresada no existe o es cuenta de mayor. Favor verificar", MsgBoxStyle.Information)
                End If
            End If

        End If
    End Sub

    Private Sub txtDESCRIPCION_BANCO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles txtDESCRIPCION_BANCO.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 1
        Dim Ncolumn As String = dgvBancos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvBancos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table1.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtDESCRIPCION_BANCO.Text = "" Then
            Me.dgvBancos.DataSource = Table1
        Else
            rows = Table1.Select("[" & dgvBancos.Columns(columna).Name & "] like '" & txtDESCRIPCION_BANCO.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvBancos.DataSource = tablaT
        End If
    End Sub

    Private Sub txtCUENTA_BANCARIA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles txtCUENTA_BANCARIA.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 0
        Dim Ncolumn As String = dgvCuentasBancarias.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvCuentasBancarias.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table2.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtCUENTA_BANCARIA.Text = "" Then
            Me.dgvCuentasBancarias.DataSource = Table2
        Else
            rows = Table2.Select("[" & dgvCuentasBancarias.Columns(columna).Name & "] like '" & txtCUENTA_BANCARIA.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvCuentasBancarias.DataSource = tablaT
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles txtCUENTA_COMPLETA.TextChanged
        Dim rows As DataRow()
        Dim posicion As Integer = -1 '1  
        Dim columna As Integer = 4
        Dim Ncolumn As String = dgvCuentasBancarias.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
        Dim Strsort As String = ""

        Select Case dgvCuentasBancarias.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
            Case SortOrder.Ascending 'En Caso de ser Ascendente
                Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
            Case SortOrder.Descending 'En Caso de ser Descendente
                Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
        End Select

        'Table.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
        Dim tablaT As DataTable = Table2.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
        If txtCUENTA_COMPLETA.Text = "" Then
            Me.dgvCuentasBancarias.DataSource = Table2
        Else
            rows = Table2.Select("[" & dgvCuentasBancarias.Columns(columna).Name & "] like '" & txtCUENTA_COMPLETA.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
            Next

            Me.dgvCuentasBancarias.DataSource = tablaT
        End If
    End Sub

    Private Sub dgvChequeras_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles dgvChequeras.CellClick
        Dim indiceCuenta As Integer
        Dim totalCuentas As Integer
        Dim i As Integer

        totalCuentas = Me.cmbCUENTA_BANCARIA.Items.Count
        indiceCuenta = 0

        Me.lblCHEQUERA.Text = Me.dgvChequeras.CurrentRow.Cells(0).Value
        Me.txtDESCRIPCION_CHEQUERA.Text = Me.dgvChequeras.CurrentRow.Cells(1).Value
        Me.txtINICIAL.Text = Me.dgvChequeras.CurrentRow.Cells(2).Value
        Me.txtFINAL.Text = Me.dgvChequeras.CurrentRow.Cells(3).Value
        Me.txtACTUAL.Text = Me.dgvChequeras.CurrentRow.Cells(4).Value
        Me.chkACTIVA.Checked = Me.dgvChequeras.CurrentRow.Cells(5).Value

        For i = 0 To totalCuentas - 1
            Me.cmbCUENTA_BANCARIA.SelectedIndex = i

            If Me.cmbCUENTA_BANCARIA.SelectedValue = Me.txtCUENTA_BANCARIA.Text.Trim Then
                Return
            End If
        Next
    End Sub

    Private Sub Contabilidad_Bancos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub tabChequeras_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabChequeras.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub tabCuentasBancarias_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabCuentasBancarias.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
            New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub cmbCUENTA_BANCARIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCUENTA_BANCARIA.SelectedIndexChanged
        Try
            cargaDetalleChequeras(Me.cmbCUENTA_BANCARIA.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvChequeras_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChequeras.CellEnter
        If e.RowIndex > -1 Then
            Me.lblCHEQUERA.Text = Me.dgvChequeras.Rows(e.RowIndex).Cells(0).Value
            Me.txtDESCRIPCION_CHEQUERA.Text = Me.dgvChequeras.Rows(e.RowIndex).Cells(1).Value
            Me.txtINICIAL.Text = Me.dgvChequeras.Rows(e.RowIndex).Cells(2).Value
            Me.txtFINAL.Text = Me.dgvChequeras.Rows(e.RowIndex).Cells(3).Value
            Me.txtACTUAL.Text = Me.dgvChequeras.Rows(e.RowIndex).Cells(4).Value
            Me.chkACTIVA.Checked = Me.dgvChequeras.Rows(e.RowIndex).Cells(5).Value
        End If
    End Sub

    Private Sub txtCUENTA_COMPLETA_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUENTA_COMPLETA.TextChanged

    End Sub
End Class