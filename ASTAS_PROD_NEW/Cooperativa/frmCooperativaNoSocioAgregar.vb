Imports System.Data.SqlClient

Public Class frmCooperativaNoSocioAgregar

    Dim jClass As New jarsClass
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim inicio As Boolean = True
    Dim Table As DataTable
    Dim TableCombos As DataTable
    Dim OriFont As Font

    Private Sub frmCooperativaNoSocioAgregar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        OriFont = Me.chkEsBuxis.Font
        jClass.CargaBancos(Compañia, cmbBanco)
        jClass.CargaOrigenes(Compañia, Me.cmbOrigen)
        Me.cmbOrigen.SelectedIndex = 0
        CargaDivision()
        CargaDeptos(Me.cmbDivision.SelectedValue)
        CargaSecciones(Me.cmbDivision.SelectedValue, Me.cmbDepto.SelectedValue)
        CargaCargos(Me.cmbDivision.SelectedValue, Me.cmbDepto.SelectedValue, Me.cmbSeccion.SelectedValue)
        cargaStatus()
        cargaTipoContrato()
        jClass.CargaPeriodo(Compañia, Me.cmbPeriodoPago)
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        inicio = False
    End Sub

    Private Sub txtCodBuxis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodBuxis.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodBuxis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodBuxis.LostFocus
        If Me.txtCodBuxis.Text.Length > 0 Then
            datosSocio(Me.txtCodBuxis.Text, "0")
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.chkRetirado.Checked = False
        Me.cmbDivision.SelectedIndex = 0
        Me.cmbDepto.SelectedIndex = 0
        Me.cmbSeccion.SelectedIndex = 0
        Me.cmbCargo.SelectedIndex = 0
        Me.cmbBanco.SelectedIndex = 0
        Me.cmbOrigen.SelectedIndex = 0
        Me.cmbStatusSocio.SelectedIndex = 0
        Me.cmbPeriodoPago.SelectedValue = "QQ"
        Me.dtpFechaIng.Value = Now
        Me.txtCodAS.Clear()
        Me.txtCodBuxis.Clear()
        Me.txtNombres.Clear()
        Me.txtApellidos.Clear()
        Me.txtCuentaBanco.Clear()
        Me.txtTipoCuenta.Clear()
        Me.txtDir.Clear()
        Me.txtSalario.Text = "0.00"
        Me.mktDUI.Clear()
        Me.mktNIT.Clear()
        Me.mktTel.Clear()
        Me.BtnEliminar.Enabled = False
        Me.chkEsBuxis.Font = OriFont
        Me.chkEsBuxis.ForeColor = Color.Black
        Me.chkEsBuxis.Checked = False
        Me.txtCodBuxis.Focus()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If (Me.txtCodBuxis.Text.Length = 0) Or (Me.txtCodAS.Text.Length = 0) Or (Val(Me.txtCodAS.Text) = 0) Or (Val(mktDUI.Text) = 0) Or (Val(mktNIT.Text) = 0) Then
            MsgBox("LOS CAMPOS DE CODIGO, DUI Y NIT NO PUEDEN IR VACIOS O CON CERO (0)")
        Else
            GuardaDatos(1)
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If MsgBox("¿Está seguro de eliminar a " & Me.txtNombres.Text & " " & Me.txtApellidos.Text & vbCrLf & " del Catálogo de Socios?", MsgBoxStyle.YesNo, "Eliminar Registro") = MsgBoxResult.Yes Then
            GuardaDatos(2)
            Me.BtnNuevo.PerformClick()
        End If
    End Sub

    Private Sub cargaStatus()
        Sql = "SELECT ESTATUS, DESCRIPCION_ESTATUS FROM COOPERATIVA_CATALOGO_ESTATUS_SOCIOS WHERE COMPAÑIA = " & Compañia
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbStatusSocio.DataSource = TableCombos
        Me.cmbStatusSocio.ValueMember = "ESTATUS"
        Me.cmbStatusSocio.DisplayMember = "DESCRIPCION_ESTATUS"
        If Me.cmbStatusSocio.Items.Count > 0 Then
            Me.cmbStatusSocio.SelectedIndex = 0
        End If
    End Sub

    Private Sub cargaTipoContrato()
        Sql = "SELECT CONTRATO, DESCRIPCION_TIPO_CONTRATO FROM COOPERATIVA_CATALOGO_SOCIOS_TIPO_CONTRATO WHERE COMPAÑIA = " & Compañia
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbTipoContrato.DataSource = TableCombos
        Me.cmbTipoContrato.ValueMember = "CONTRATO"
        Me.cmbTipoContrato.DisplayMember = "DESCRIPCION_TIPO_CONTRATO"
        If Me.cmbTipoContrato.Items.Count > 0 Then
            Me.cmbTipoContrato.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargaDivision()
        Sql = "SELECT DIVISION, DESCRIPCION_DIVISION FROM COOPERATIVA_CATALOGO_DIVISIONES WHERE COMPAÑIA = " & Compañia
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbDivision.DataSource = TableCombos
        Me.cmbDivision.ValueMember = "DIVISION"
        Me.cmbDivision.DisplayMember = "DESCRIPCION_DIVISION"
        If Me.cmbDivision.Items.Count > 0 Then
            Me.cmbDivision.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargaDeptos(ByVal Division As Integer)
        Sql = "SELECT DEPARTAMENTO, DESCRIPCION_DEPARTAMENTO FROM COOPERATIVA_CATALOGO_DEPARTAMENTOS WHERE COMPAÑIA = " & Compañia & " AND DIVISION = " & Division
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbDepto.DataSource = TableCombos
        Me.cmbDepto.ValueMember = "DEPARTAMENTO"
        Me.cmbDepto.DisplayMember = "DESCRIPCION_DEPARTAMENTO"
        If Me.cmbDepto.Items.Count > 0 Then
            Me.cmbDepto.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargaSecciones(ByVal Division As Integer, ByVal Depto As Integer)
        Sql = "SELECT SECCION, DESCRIPCION_SECCION FROM COOPERATIVA_CATALOGO_SECCIONES WHERE COMPAÑIA = " & Compañia & " AND DIVISION = " & Division & " AND DEPARTAMENTO = " & Depto
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbSeccion.DataSource = TableCombos
        Me.cmbSeccion.ValueMember = "SECCION"
        Me.cmbSeccion.DisplayMember = "DESCRIPCION_SECCION"
        If Me.cmbSeccion.Items.Count > 0 Then
            Me.cmbSeccion.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargaCargos(ByVal Division As Integer, ByVal Depto As Integer, ByVal Seccion As Integer)
        Sql = "SELECT CARGO, DESCRIPCION_CARGO FROM COOPERATIVA_CATALOGO_CARGOS WHERE COMPAÑIA = " & Compañia & " AND DIVISION = " & Division & " AND DEPARTAMENTO = " & Depto & " AND SECCION = " & Seccion
        sqlCmd.CommandText = Sql
        TableCombos = jClass.obtenerDatos(sqlCmd)
        Me.cmbCargo.DataSource = TableCombos
        Me.cmbCargo.ValueMember = "CARGO"
        Me.cmbCargo.DisplayMember = "DESCRIPCION_CARGO"
        If Me.cmbCargo.Items.Count > 0 Then
            Me.cmbCargo.SelectedIndex = 0
        End If
    End Sub

    Private Sub datosSocio(ByVal numSocio As String, ByVal codEmp As String)
        Dim repetidos As String = ""
        Dim linea As Integer = 0
        If numSocio <> "" Then
            Try
                Sql = "EXECUTE Coo.sp_COOPERATIVA_CATALOGO_SOCIOS_DATOS " & vbCrLf
                Sql &= " @COMPAÑIA  = " & Compañia & vbCrLf
                Sql &= ",@COD_AS    = '" & numSocio & "'" & vbCrLf
                Sql &= ",@COD_EMP   = " & codEmp & vbCrLf
                Sql &= ",@BANDERA   = 13" & vbCrLf 'BANDERA
                sqlCmd.CommandText = Sql
                Table = jClass.obtenerDatos(sqlCmd)
                If Table.Rows.Count > 1 Then
                    For i As Integer = 0 To Table.Rows.Count - 1
                        repetidos &= (i + 1).ToString & ") " & Table.Rows(i).Item("NOMBRES") & " " & Table.Rows(i).Item("APELLIDOS") & vbCrLf
                    Next
                    linea = Val(InputBox(repetidos & vbCrLf & "Por favor, ingrese el numeral para mostrar los datos correspondientes.", "Código AS: " & Me.txtCodAS.Text & " Duplicado", "1"))
                    If linea > 0 Then
                        linea = linea - 1
                    End If
                End If
                If Table.Rows.Count > 0 Then
                    Me.txtCodAS.Text = Table.Rows(linea).Item("CODIGO_EMPLEADO_AS")
                    Me.txtCodBuxis.Text = Table.Rows(linea).Item("CODIGO_EMPLEADO")
                    Me.txtNombres.Text = Table.Rows(linea).Item("NOMBRES")
                    Me.txtApellidos.Text = Table.Rows(linea).Item("APELLIDOS")
                    Me.cmbDivision.SelectedValue = Table.Rows(linea).Item("DIVISION")
                    Me.cmbDepto.SelectedValue = Table.Rows(linea).Item(4)
                    Me.cmbSeccion.SelectedValue = Table.Rows(linea).Item("SECCION")
                    Me.cmbCargo.SelectedValue = Table.Rows(linea).Item("CARGO")
                    Me.cmbBanco.SelectedValue = Table.Rows(linea).Item("BANCO")
                    Me.cmbTipoContrato.SelectedValue = Table.Rows(linea).Item("TIPO_CONTRATO")
                    Me.txtCuentaBanco.Text = Table.Rows(linea).Item("CUENTA_BANCARIA")
                    Me.txtTipoCuenta.Text = Table.Rows(linea).Item("TIPO_CUENTA_BANCARIA")
                    Me.txtSalario.Text = Format(Val(Table.Rows(linea).Item("SALARIO")), "#,##0.00")
                    Me.dtpFechaIng.Value = Table.Rows(linea).Item("FECHA_INGRESO")
                    Me.mktTel.Text = Table.Rows(linea).Item("TELEFONO")
                    Me.mktDUI.Text = Table.Rows(linea).Item("DUI")
                    Me.mktNIT.Text = Table.Rows(linea).Item("NIT")
                    Me.txtDir.Text = Table.Rows(linea).Item("DIRECCION")
                    Me.cmbOrigen.SelectedValue = Table.Rows(linea).Item("ORIGEN")
                    Me.cmbStatusSocio.SelectedValue = Table.Rows(linea).Item("ESTATUS")
                    Me.cmbPeriodoPago.SelectedValue = Table.Rows(linea).Item("PERIODO_PAGO")
                    Me.BtnEliminar.Enabled = True
                    Me.chkEsBuxis.Checked = CBool(Table.Rows(linea).Item("ES_BUXIS"))
                    Me.chkRetirado.Checked = CBool(Table.Rows(linea).Item("RETIRADO"))
                    Me.chkBloqueoConsumo.Checked = CBool(Table.Rows(linea).Item("BLOQUEADO"))
                    If Me.cmbOrigen.SelectedValue = 1 Then
                        Me.chkEsBuxis.Font = New Font("Arial", 10, FontStyle.Bold)
                        Me.chkEsBuxis.ForeColor = Color.Red
                    Else
                        Me.chkEsBuxis.Font = OriFont
                        Me.chkEsBuxis.ForeColor = Color.Black
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Datos Socio")
            End Try
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim Socios As New FrmBuscarSocios
        Socios.Compañia_Value = Compañia
        If ParamcodigoAs Is Nothing Then
            ParamcodigoAs = ""
        End If
        Socios.ShowDialog()
        Me.txtCodAS.Text = ParamcodigoAs
        Me.txtCodBuxis.Text = ParamcodigoBux
        datosSocio(Val(ParamcodigoBux), Val(ParamcodigoAs))
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged
        If Not inicio Then
            CargaDeptos(Me.cmbDivision.SelectedValue)
        End If
    End Sub

    Private Sub cmbDepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepto.SelectedIndexChanged
        If Not inicio Then
            CargaSecciones(Me.cmbDivision.SelectedValue, Me.cmbDepto.SelectedValue)
        End If
    End Sub

    Private Sub cmbSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSeccion.SelectedIndexChanged
        If Not inicio Then
            CargaCargos(Me.cmbDivision.SelectedValue, Me.cmbDepto.SelectedValue, Me.cmbSeccion.SelectedValue)
        End If
    End Sub

    Private Sub GuardaDatos(ByVal Bandera As Integer)
        Dim Resultado As Integer
        Try
            Sql = "EXECUTE [dbo].[sp_COOPERATIVA_CATALOGO_SOCIOS_IUD]" & vbCrLf
            Sql &= "  @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ", @ORIGEN = " & Me.cmbOrigen.SelectedValue & vbCrLf
            Sql &= ", @CODIGO_EMPLEADO = " & Me.txtCodBuxis.Text & vbCrLf
            Sql &= ", @CODIGO_EMPLEADO_AS = '" & Me.txtCodAS.Text & "'" & vbCrLf
            Sql &= ", @NOMBRES = '" & Me.txtNombres.Text & "'" & vbCrLf
            Sql &= ", @APELLIDOS = '" & Me.txtApellidos.Text & "'" & vbCrLf
            Sql &= ", @DIVISION = " & Me.cmbDivision.SelectedValue & vbCrLf
            Sql &= ", @DEPTO = " & Me.cmbDepto.SelectedValue & vbCrLf
            Sql &= ", @SECCION = " & Me.cmbSeccion.SelectedValue & vbCrLf
            Sql &= ", @CARGO = " & Me.cmbCargo.SelectedValue & vbCrLf
            Sql &= ", @BANCO = " & Me.cmbBanco.SelectedValue & vbCrLf
            Sql &= ", @TIPO_CUENTA_BANCARIA = '" & Me.txtTipoCuenta.Text & "'" & vbCrLf
            Sql &= ", @CUENTA_BANCO = '" & Me.txtCuentaBanco.Text & "'" & vbCrLf
            Sql &= ", @FECHA_INGRESO = '" & Me.dtpFechaIng.Value.ToString("dd/MM/yyyy") & "'" & vbCrLf
            Sql &= ", @FECHA_SALIDA = NULL" & vbCrLf
            Sql &= ", @STATUS = " & Me.cmbStatusSocio.SelectedValue & vbCrLf
            Sql &= ", @DUI = '" & Me.mktDUI.Text & "'" & vbCrLf
            Sql &= ", @NIT = '" & Me.mktNIT.Text & "'" & vbCrLf
            Sql &= ", @DIRECCION = '" & txtDir.Text & "'" & vbCrLf
            Sql &= ", @TELEFONO = '" & Me.mktTel.Text & "'" & vbCrLf
            Sql &= ", @SALARIO = " & Me.txtSalario.Text.Replace(",", String.Empty) & vbCrLf
            Sql &= ", @INDEMNIZACION = 0" & vbCrLf
            Sql &= ", @DEDUCCIONES = 0" & vbCrLf
            Sql &= ", @PERIODO_PAGO = '" & Me.cmbPeriodoPago.SelectedValue & "'" & vbCrLf
            Sql &= ", @USUARIO = " & Usuario & vbCrLf
            Sql &= ", @BANDERA = " & Bandera & vbCrLf
            Sql &= ", @ES_BUXIS = " & CInt(Me.chkEsBuxis.Checked) & vbCrLf
            Sql &= ", @RETIRADO = " & CInt(Me.chkRetirado.Checked) & vbCrLf
            Sql &= ", @TIPO_CONTRATO = " & Me.cmbTipoContrato.SelectedValue & vbCrLf
            sqlCmd.CommandText = Sql
            Resultado = jClass.ejecutarComandoSql(sqlCmd)
            If Resultado > 0 Then
                MsgBox("Actualización exitosa en Catálogo de Socios", MsgBoxStyle.Information, "Catálogo de Socios")
            Else
                MsgBox("No se Actualizaron datos en Catálogo de Socios", MsgBoxStyle.Critical, "Catálogo de Socios")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Catálogo de Socios")
        End Try
    End Sub

    Private Sub txtCodBuxis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodBuxis.TextChanged

    End Sub
End Class