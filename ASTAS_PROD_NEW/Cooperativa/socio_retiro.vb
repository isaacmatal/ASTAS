Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class socio_retiro
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim TableDeudas As New DataTable
    Dim SQL As String
    Dim ISR, Escolaridad, Deudas As Double

    Private Sub socio_retiro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        TextoConversion()
        Me.btnCalculo.Enabled = False
        crearTabla()
        Porcentajes()
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 2
        If Trim(Me.TxtCodAS.Text) <> "" Or Trim(Me.TxtCodBuxy.Text) <> "" Then
            BusquedaDatosSocios()
        Else
            Dim Prin As New FrmBuscarSocios
            Prin.Compañia_Value = Compañia
            Prin.ShowDialog()
            If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
                Me.TxtCodBuxy.Text = ParamcodigoBux
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios()
            End If
        End If
    End Sub

    Private Sub BusquedaDatosSocios()
        Dim CodAS As String = "", Accion As String = ""
        Dim CBuxi As Integer
        Dim tblDatosEmp As DataTable
        If Trim(Me.TxtCodAS.Text) = Nothing And Val(Me.TxtCodBuxy.Text) <= 0 Then
            MessageBox.Show("Ingrese al menos un CODIGO" & vbCrLf & "CODIGO AS O CODIGO BUXI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtCodAS.Focus()
            Return
        ElseIf Trim(Me.TxtCodAS.Text) <> Nothing Or Val(Me.TxtCodBuxy.Text) > 0 Then
            CodAS = Me.TxtCodAS.Text.Trim
            CBuxi = Val(Me.TxtCodBuxy.Text)
            If CodAS <> Nothing And CBuxi <= 0 Then
                Accion = "cas"
            ElseIf CodAS = Nothing And CBuxi > 0 Then
                Accion = "cbuxi"
            ElseIf CodAS <> Nothing And CBuxi > 0 Then
                Accion = "ambos"
            End If
        End If
        Try
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','" & CodAS & "','" & Accion & "'"
            tblDatosEmp = jClass.obtenerDatos(New SqlCommand(SQL))

            If (tblDatosEmp.Rows.Count) <= 0 Then
                MessageBox.Show("Código de Socio no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Hay_Datos = False
                Return
            End If
            Origen = tblDatosEmp.Rows(0).Item("ORIGEN") 'jClass.obtenerEscalar("SELECT ORIGEN FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & tblDatosEmp.Rows(0).Item(2) & "' AND CODIGO_EMPLEADO = " & tblDatosEmp.Rows(0).Item(3))
            If Not Permitir.Contains(Origen.ToString()) Then
                MsgBox("No esta autorizado a retirar este código", MsgBoxStyle.Information, tblDatosEmp.Rows(0).Item(2) & " - " & tblDatosEmp.Rows(0).Item(3))
                Hay_Datos = False
                Return
            End If
            Hay_Datos = True
            Me.TxtCodAS.Text = tblDatosEmp.Rows(0).Item(2)
            Me.TxtCodBuxy.Text = tblDatosEmp.Rows(0).Item(3)
            Me.TxtSoNombre.Text = tblDatosEmp.Rows(0).Item(4)
            Me.TxtSoApellido.Text = tblDatosEmp.Rows(0).Item(5)
            Me.TxtDUI.Text = tblDatosEmp.Rows(0).Item(15)
            Me.TxtNit.Text = tblDatosEmp.Rows(0).Item(16)
            Me.TxtDivision.Text = tblDatosEmp.Rows(0).Item(6)
            Me.TxtDepto.Text = tblDatosEmp.Rows(0).Item(7)
            Me.TxtSeccion.Text = tblDatosEmp.Rows(0).Item(8)
            Me.TxtCargo.Text = tblDatosEmp.Rows(0).Item(9)
            Me.Txt_so_direccion.Text = tblDatosEmp.Rows(0).Item(17)
            Me.Txt_so_telefono.Text = tblDatosEmp.Rows(0).Item(18)
            Me.txtEmpresa.Text = tblDatosEmp.Rows(0).Item("DESCRIPCION_ORIGEN")
            ParamcodigoAs = Me.TxtCodAS.Text.Trim
            ParamcodigoBux = Val(Me.TxtCodBuxy.Text)
            CargarDatosGrid_deudas()
            Asociacion_AhorrosOrdinarioExtraordinario()
            If Me.DataGrid_deudas.Rows.Count > 0 Then
                Me.DataGrid_deudas.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGrid_deudas.Columns.Item(2).DefaultCellStyle.Format = "###,###.00"
                Me.DataGrid_deudas.Columns.Item(0).Visible = False
                Me.DataGrid_deudas.Rows(Me.DataGrid_deudas.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro
                Me.DataGrid_deudas.Rows(Me.DataGrid_deudas.Rows.Count - 1).DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 10, FontStyle.Bold, GraphicsUnit.Point)
                Me.DataGrid_deudas.ResumeLayout(True)
            End If
            BusquedaBancos()
            CargarDatosGrid_SocioFiador_deSocios()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BusquedaBancos()
        Dim tblDatosBco As DataTable
        Try
            SQL = "EXECUTE sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','SDB'"
            tblDatosBco = jClass.obtenerDatos(New SqlCommand(SQL))
            If (tblDatosBco.Rows.Count) <= 0 Then
                Return
            End If
            Me.TxtBanco_cod.Text = tblDatosBco.Rows(0).Item(0)
            Me.TxtBanco_nombre.Text = tblDatosBco.Rows(0).Item(1)
            If (tblDatosBco.Rows(0).Item(2)) = Nothing Then
                Me.TxtBanco_cuenta.Text = "Sin cuenta "
            Else
                Me.TxtBanco_cuenta.Text = tblDatosBco.Rows(0).Item(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Porcentajes()
        Try
            SQL = "EXECUTE sp_CONTABILIDAD_CATALOGO_CONSTANTES " & Compañia & ",5"
            ISR = jClass.obtenerEscalar(SQL)
            SQL = "EXECUTE sp_CONTABILIDAD_CATALOGO_CONSTANTES " & Compañia & ",6"
            'Escolaridad = jClass.obtenerEscalar(SQL)
            Escolaridad = 0
            If Escolaridad = Nothing Then
                Escolaridad = 0
            End If
            If ISR = Nothing Then
                ISR = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Asociacion_AhorrosOrdinarioExtraordinario()
        Dim tblAhorros As DataTable
        Try
            Me.chkSinDeudas.Checked = False
            SQL = "Execute sp_COOPERATIVA_SOCIOS_AHORROS_MOSTRAR " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','SAOE'"
            tblAhorros = jClass.obtenerDatos(New SqlCommand(SQL))
            If (tblAhorros.Rows.Count) <= 0 Then
                MessageBox.Show("No hay ahorros que mostrar...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtTotalAhorro_Ordinario.Text = "0.00"
                Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                Me.TxtTotalAhorro.Text = "0.00"
                Return
            End If
            Me.TxtTotalAhorro_Ordinario.Text = Format(Val(tblAhorros.Rows(0).Item(0)), "0.00")
            Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(Val(tblAhorros.Rows(0).Item(1)), "0.00")
            Me.TxtTotalAhorro.Text = Format(Val(tblAhorros.Rows(0).Item(2)), "0.00")
            Me.TxtEscolaridad_porcentaje.Text = Escolaridad
            Me.TxtEscolaridad.Text = Format((TxtTotalAhorro_Ordinario.Text * (Escolaridad / 100)), "0.00")
            Me.TxtISR_porcentaje.Text = ISR
            Me.TxtISR.Text = Format((Me.TxtEscolaridad.Text * (ISR / 100)), "0.00")
            Me.TxtTotalBruto01.Text = Format((Val(Me.TxtTotalAhorro.Text) + Val(Me.TxtEscolaridad.Text) - Val(Me.TxtISR.Text)), "0.00")
            Me.TxtTotalBruto02.Text = Me.TxtTotalBruto01.Text
            Me.TxtTotal.Text = Format((Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtIntereses.Text) - Val(Me.txtSegDeuda.Text)), "0.00")
            If Val(Me.TxtTotal.Text) < 0 Then
                Me.TxtComentario.Enabled = False
                Me.BtnGuardar.Enabled = False
                MessageBox.Show("El socio no puede retirarse de la asociación porque la deuda es mayor a los ahorros totales que posee", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.btnCalculo.Enabled = True
                Me.TxtComentario.Enabled = True
            Else
                Me.TxtComentario.Enabled = True
                Me.BtnGuardar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextoConversion()
        For Each control As Control In GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                control.Tag = ""
            End If
        Next
        For Each control As Control In GrpDatosAhorro.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                control.Tag = ""
            End If
        Next
        For Each control As Control In DrpDatosLibresDeuda.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                control.Tag = ""
            End If
        Next
        Me.btnCalculo.Enabled = False
        Me.TxtComentario.Clear()
        Me.TxtCodBuxy.Focus()
    End Sub

    Private Sub CargarDatosGrid_deudas()
        Try
            SQL = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS " & Compañia & ",'" & ParamcodigoAs & "'," & ParamcodigoBux & ",'TDSP'"
            DataGrid_deudas.DataSource = jClass.obtenerDatos(New SqlCommand(SQL))
            If DataGrid_deudas.Rows.Count > 0 Then
                Me.TxtTotalDeudas.Text = Format(Val(Me.DataGrid_deudas.Rows(DataGrid_deudas.Rows.Count - 1).Cells(2).Value), "0.00")
                CalcularInteresSeguro()
                Me.TxtTotal.Text = (Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtIntereses.Text) - Val(Me.txtSegDeuda.Text)).ToString("0.00")
            End If
            crearTabla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For i As Integer = 1 To 2
            DataGrid_deudas.Columns.Item(i - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

    Private Sub CargarDatosGrid_SocioFiador_deSocios()
        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Return
        End If
        Try
            SQL = "EXECUTE [dbo].[sp_COOPERATIVA_SOLICITUDES_FIADORES_DEL_SOCIO_SIUD] @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO = " & ParamcodigoBux & ", @BANDERA = 4"
            DataGrid_Fiadorde.DataSource = jClass.obtenerDatos(New SqlCommand(SQL))
            If (Me.DataGrid_Fiadorde.Rows.Count) > 0 Then
                MessageBox.Show("Este Socio es Fiador de otros socios...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.DataGrid_Fiadorde.Columns.Item(0).Visible = False
            Me.DataGrid_Fiadorde.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGrid_Fiadorde.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGrid_Fiadorde.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For i As Integer = 0 To Me.DataGrid_Fiadorde.Columns.Count - 1
            Me.DataGrid_Fiadorde.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub

    Private Sub Btn_Socio_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click
        TextoConversion()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If MsgBox("¿Está seguro de procesar este retiro?", MsgBoxStyle.YesNo, "PROCESO") = MsgBoxResult.Yes Then
            If Me.TxtCodBuxy.Text.Trim <> "" And Me.TxtCodAS.Text.Trim <> "" And Me.TxtComentario.Text.Trim <> "" Then
                RetiroAhorro()
                TextoConversion()
            Else
                If Me.TxtCodBuxy.Text = Nothing Or Me.TxtCodAS.Text = Nothing Then
                    MessageBox.Show("No se ha seleccionado ningún Socio o los códigos no son válidos...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If Me.TxtComentario.Text.Trim = Nothing Then
                    MessageBox.Show("Debe ingresar la razón por la cual el socio se retirará de la asociación...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub RetiroAhorro() 'almacenamiento de retiro de ahorro en tabla cooperativa_socio_retiros
        Dim idRet As Integer
        Try
            SQL = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS"
            SQL &= "  @RETIRO = 0"
            SQL &= ", @COMPAÑIA = " & Compañia
            SQL &= ", @BANCO = " & Val(Me.TxtBanco_cod.Text)
            SQL &= ", @TIPO_DOCUMENTO = " & IIf(Val(Me.TxtBanco_cod.Text) = 0, "6", "3")
            SQL &= ", @CUENTA = '" & Me.TxtBanco_cuenta.Text & "'"
            SQL &= ", @CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text
            SQL &= ", @CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "'"
            SQL &= ", @CANTIDAD = " & Me.TxtTotal.Text
            SQL &= ", @ESTADO = 1"
            SQL &= ", @USUARIO = '" & Usuario & "'"
            SQL &= ", @FECHA = '" & Format(Now, "dd/MM/yyyy") & "'"
            SQL &= ", @SIUD = 'I'"
            SQL &= ", @FECHA_DESDE = '" & Me.dpHasta.Value.ToShortDateString & "'"
            SQL &= ", @FECHA_HASTA = '" & Me.dpHasta.Value.ToShortDateString & "'"
            SQL &= ", @TOTAL_INTERESES = " & Val(Me.txtIntereses.Text)
            SQL &= ", @TOTAL_SEGURODEUDA = " & Val(Me.txtSegDeuda.Text)
            SQL &= ", @TOTAL_DEUDAS = " & Me.TxtTotalDeudas.Text
            SQL &= ", @TOTAL_AHORROS_ORD = " & Me.TxtTotalAhorro_Ordinario.Text
            SQL &= ", @TOTAL_AHORROS_EXT = " & Me.TxtTotalAhorro_ExtraOrdinario.Text
            SQL &= ", @RETIRO_ASOC = 1"
            SQL &= ", @PORCENTAJE_ESCOLARIDAD = " & Me.TxtEscolaridad_porcentaje.Text
            SQL &= ", @TOTAL_ESCOLARIDAD = " & Me.TxtEscolaridad.Text
            SQL &= ", @PORCENTAJE_RENTA = " & Me.TxtISR_porcentaje.Text
            SQL &= ", @TOTAL_RENTA = " & Me.TxtISR.Text
            SQL &= ", @COMENTARIO = '" & Me.TxtComentario.Text & "'"
            If UCase(jClass.obtenerEscalar(SQL)) = "EXISTE" Then
                MessageBox.Show("El registro ya existe, y está en proceso de aplicación...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            idRet = jClass.obtenerEscalar("SELECT RETIRO FROM COOPERATIVA_SOCIO_RETIROS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text & " AND CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "' AND ESTADO = 1")
            If Me.chkEmpresa.Checked Then
                jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOCIO_RETIROS SET CUENTA_CONTABLE_BANCO = 1 WHERE COMPAÑIA = " & Compañia & " AND RETIRO = " & idRet)
            Else
                jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_SOCIO_RETIROS SET CUENTA_CONTABLE_BANCO = 0 WHERE COMPAÑIA = " & Compañia & " AND RETIRO = " & idRet)
                jClass.Ejecutar_ConsultaSQL("UPDATE COOPERATIVA_CATALOGO_SOCIOS SET ESTATUS = 1 WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Me.TxtCodBuxy.Text)
            End If
            If Val(Me.TxtTotalDeudas.Text) > 0 Then
                For Each row As DataRow In TableDeudas.Rows
                    SQL = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO_IUD]" & vbCrLf
                    SQL &= " @COMPAÑIA           = " & Compañia & vbCrLf
                    SQL &= ",@CODIGO_EMPLEADO    = " & Me.TxtCodBuxy.Text & vbCrLf
                    SQL &= ",@CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "'" & vbCrLf
                    SQL &= ",@PRESTAMO           = " & row.Item(3) & vbCrLf
                    SQL &= ",@INTERES            = 0" & vbCrLf
                    SQL &= ",@MONTO_PRESTAMO     = " & row.Item(2) & vbCrLf
                    SQL &= ",@FECHA_INICIO       = '" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
                    SQL &= ",@DEDUCCION          = " & idRet & vbCrLf
                    SQL &= ",@ANULADO            = 0 " & vbCrLf
                    SQL &= ",@USUARIO            = '" & Usuario & "'" & vbCrLf
                    SQL &= ",@IUD                = 'I'"
                    jClass.Ejecutar_ConsultaSQL(SQL)
                Next
            End If
            If Val(Me.txtIntereses.Text) > 0 Or Val(Me.txtSegDeuda.Text) > 0 Then
                SQL = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO_IUD]" & vbCrLf
                SQL &= " @COMPAÑIA           = " & Compañia & vbCrLf
                SQL &= ",@CODIGO_EMPLEADO    = " & Me.TxtCodBuxy.Text & vbCrLf
                SQL &= ",@CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "'" & vbCrLf
                SQL &= ",@PRESTAMO           = 0" & vbCrLf
                SQL &= ",@INTERES            = 0" & vbCrLf
                SQL &= ",@MONTO_PRESTAMO     = 0" & vbCrLf
                SQL &= ",@FECHA_INICIO       = '" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
                SQL &= ",@DEDUCCION          = " & idRet & vbCrLf
                SQL &= ",@ANULADO            = 0 " & vbCrLf
                SQL &= ",@USUARIO            = '" & Usuario & "'" & vbCrLf
                SQL &= ",@IUD                = 'U'"
                jClass.Ejecutar_ConsultaSQL(SQL)
            End If
            MessageBox.Show("El trámite de retiro de ahorros del socio ha sido agregado exitosamente!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCodAS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodAS.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodAS.Text <> Nothing Then
                Me.TxtCodAS.Text = Me.TxtCodAS.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodAS.Text
                ParamcodigoBux = 0
                BusquedaDatosSocios()
            End If
        End If
    End Sub

    Private Sub TxtEscolaridad_porcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEscolaridad_porcentaje.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEscolaridad_porcentaje_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEscolaridad_porcentaje.Leave
        Me.TxtEscolaridad.Text = Format((TxtTotalAhorro_Ordinario.Text * (TxtEscolaridad_porcentaje.Text / 100)), "0.00")
        Me.TxtISR.Text = Format((Me.TxtEscolaridad.Text * (ISR / 100)), "0.00")
        Me.TxtTotalBruto01.Text = Format((Val(Me.TxtTotalAhorro.Text) + Val(Me.TxtEscolaridad.Text) - Val(Me.TxtISR.Text)), "0.00")
        Me.TxtTotalBruto02.Text = Me.TxtTotalBruto01.Text
        Me.TxtTotal.Text = (Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtIntereses.Text) - Val(Me.txtSegDeuda.Text)).ToString("0.00")
    End Sub

    Private Sub chkCalcInt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCalcInt.CheckedChanged
        If Me.chkCalcInt.Checked Then
            CalcularInteresSeguro()
        Else
            crearTabla()
            Me.txtIntereses.Text = "0.00"
            Me.txtSegDeuda.Text = "0.00"
        End If
        Me.TxtTotal.Text = (Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtIntereses.Text) - Val(Me.txtSegDeuda.Text)).ToString("0.00")
    End Sub

    Private Sub CalcularInteresSeguro()
        If TxtCodBuxy.Text.Length = 0 Then
            Return
        End If
        Dim Solicitud As String
        Dim codigoBux As Integer = TxtCodBuxy.Text
        Dim desde, hasta As Date
        Dim DiasInt, Deduc, TipSol As Integer
        Dim SqlCmd As New SqlCommand
        Dim TablaDeduc As New DataTable("Deduc")
        Dim TablaPorcentajes As New DataTable("Procentajes")
        Dim tblRep As New DataTable
        Dim TablaDeducciones As New DataTable("Deducciones")
        Dim Capital, Intereses, SegDeuda As Double
        hasta = Me.dpHasta.Value
        SqlCmd.CommandText = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & TxtCodAS.Text & "',@CodigoBuxis = " & codigoBux & ", @SIUD = 'INTRET'"
        TablaDeduc = jClass.obtenerDatos(SqlCmd)
        If TablaDeduc.Rows.Count > 0 Then
            tblRep = TablaDeduc.Clone
            Deduc = TablaDeduc.Rows(0).Item(3)
            TipSol = TablaDeduc.Rows(0).Item(0)
            Solicitud = TablaDeduc.Rows(0).Item(1)
            Capital = 0
            Intereses = 0
            SegDeuda = 0
            For i As Integer = 0 To TablaDeduc.Rows.Count - 1
                If TablaDeduc.Rows(i).Item(6).ToString() = "N" Then
                    desde = TablaDeduc.Rows(i).Item(7)
                Else
                    desde = TablaDeduc.Rows(i).Item(5)
                End If
                DiasInt = DateDiff(DateInterval.Day, desde, hasta)
                ' si los dias son negativos es que no es fecha de descuento, por lo tanto no se generaron intereses
                If (DiasInt < 0) Then
                    DiasInt = 0
                Else
                    DiasInt += 1
                End If
                SQL = "SELECT CD.INTERES, CDS.INTERES AS SEGURO " & vbCrLf
                SQL &= "FROM dbo.COOPERATIVA_CATALOGO_DEDUCCIONES CD, dbo.COOPERATIVA_CATALOGO_DEDUCCIONES_SEGURO CDS " & vbCrLf
                SQL &= "WHERE CD.COMPAÑIA = CDS.COMPAÑIA " & vbCrLf
                SQL &= "AND CD.DEDUCCION = CDS.DEDUCCION " & vbCrLf
                SQL &= "AND CD.COMPAÑIA  = " & Compañia & vbCrLf
                SQL &= "AND CD.DEDUCCION = " & TablaDeduc.Rows(i).Item(3) & vbCrLf
                SqlCmd.CommandText = SQL
                TablaPorcentajes.Reset()
                TablaPorcentajes = jClass.obtenerDatos(SqlCmd)
                If TablaPorcentajes.Rows.Count > 0 Then
                    Capital += TablaDeduc.Rows(i).Item(2)
                    Intereses += Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(0) / 100) * DiasInt) / 360), 2)
                    SegDeuda += Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(1) / 100) * DiasInt) / 30), 2)
                    tblRep.Rows.Add(TablaDeduc.Rows(i).Item(0), TablaDeduc.Rows(i).Item(1), TablaDeduc.Rows(i).Item(2), TablaDeduc.Rows(i).Item(3), TablaDeduc.Rows(i).Item(4), TablaDeduc.Rows(i).Item(5), TablaDeduc.Rows(i).Item(6), TablaDeduc.Rows(i).Item(7), Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(0) / 100) * DiasInt) / 360), 2), Math.Round(((TablaDeduc.Rows(i).Item(2) * (TablaPorcentajes.Rows(0).Item(1) / 100) * DiasInt) / 30), 2))
                End If
            Next
            GuardarCalculos(tblRep, codigoBux, Now)
            Me.btnCalculo.Enabled = True
        End If
        Me.txtIntereses.Text = Intereses.ToString("0.00")
        Me.txtSegDeuda.Text = SegDeuda.ToString("0.00")
    End Sub

    Private Sub GuardarCalculos(ByVal tblDatos As DataTable, ByVal codigoBux As Integer, ByVal FechaProceso As Date)
        SQL = "DELETE FROM [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_ENVIADAS] WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & codigoBux & " AND FECHA_PROCESO = '" & Format(FechaProceso, "dd/MM/yyyy") & "'"
        jClass.Ejecutar_ConsultaSQL(SQL)
        For i As Integer = 0 To tblDatos.Rows.Count - 1
            SQL = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_ENVIADAS]" & vbCrLf
            SQL &= "           ([COMPAÑIA]" & vbCrLf
            SQL &= "           ,[NUMERO_SOLICITUD]" & vbCrLf
            SQL &= "           ,[CODIGO_EMPLEADO]" & vbCrLf
            SQL &= "           ,[FECHA_PROCESO]" & vbCrLf
            SQL &= "           ,[FECHA_PAGO]" & vbCrLf
            SQL &= "           ,[FECHA_SOLICITUD]" & vbCrLf
            SQL &= "           ,[CAPITAL]" & vbCrLf
            SQL &= "           ,[INTERES]" & vbCrLf
            SQL &= "           ,[SEG_DEUDA]" & vbCrLf
            SQL &= "           ,[TOTAL_ENVIADO]" & vbCrLf
            SQL &= "           ,[TIPO_CUOTA]" & vbCrLf
            SQL &= "           ,[BUXIS])" & vbCrLf
            SQL &= "    VALUES(" & Compañia & vbCrLf
            SQL &= "           ," & tblDatos.Rows(i).Item("NUMSOL") & vbCrLf
            SQL &= "           ," & codigoBux & vbCrLf
            SQL &= "           ,'" & Format(FechaProceso, "dd/MM/yyyy") & "'" & vbCrLf
            SQL &= "           ,'" & Format(tblDatos.Rows(i).Item("ULTFECPAGO"), "dd/MM/yyyy") & "'" & vbCrLf
            SQL &= "           ,'" & Format(tblDatos.Rows(i).Item("FECHASOL"), "dd/MM/yyyy") & "'" & vbCrLf
            SQL &= "           ," & tblDatos.Rows(i).Item("DEUDA") & vbCrLf
            SQL &= "           ," & tblDatos.Rows(i).Item("INTERES") & vbCrLf
            SQL &= "           ," & tblDatos.Rows(i).Item("SEGDEUDA") & vbCrLf
            SQL &= "           ," & Format(Val(tblDatos.Rows(i).Item("DEUDA")) + Val(tblDatos.Rows(i).Item("INTERES")) + Val(tblDatos.Rows(i).Item("SEGDEUDA")), "0.00") & vbCrLf
            SQL &= "           ,'" & tblDatos.Rows(i).Item("TIPO_PAGO") & "'" & vbCrLf
            SQL &= "           ,0)" & vbCrLf
            jClass.Ejecutar_ConsultaSQL(SQL)
        Next
    End Sub

    Private Sub dpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpHasta.ValueChanged
        If Me.chkCalcInt.Checked Then
            Me.CalcularInteresSeguro()
        End If
    End Sub

    Private Sub socio_retiro_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TabPage3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage3.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub TxtCodBuxy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodBuxy.Text <> Nothing Then
                ParamcodigoAs = Me.TxtCodAS.Text.PadLeft(6, "0")
                ParamcodigoBux = Me.TxtCodBuxy.Text
                BusquedaDatosSocios()
            End If
        End If
    End Sub

    Private Sub chkSinDeudas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSinDeudas.CheckedChanged
        If Me.chkSinDeudas.Checked Then
            Me.TxtTotal.Tag = Me.TxtTotal.Text
            Me.TxtTotalDeudas.Tag = Me.TxtTotalDeudas.Text
            Me.txtIntereses.Tag = Me.txtIntereses.Text
            Me.txtSegDeuda.Tag = Me.txtSegDeuda.Text
            Me.TxtTotal.Text = Me.TxtTotalBruto02.Text
            Me.TxtTotalDeudas.Text = "0.00"
            Me.txtIntereses.Text = "0.00"
            Me.txtSegDeuda.Text = "0.00"
            Me.BtnGuardar.Enabled = True
            Me.btnCalculo.Enabled = False
        Else
            Me.TxtTotal.Text = Me.TxtTotal.Tag
            Me.TxtTotalDeudas.Text = Me.TxtTotalDeudas.Tag
            Me.txtIntereses.Text = Me.txtIntereses.Tag
            Me.txtSegDeuda.Text = Me.txtSegDeuda.Tag
            Me.TxtTotalDeudas.Tag = "0.00"
            Me.txtIntereses.Tag = "0.00"
            Me.txtSegDeuda.Tag = "0.00"
            If Val(Me.TxtTotal.Text) > 0 Then
                Me.BtnGuardar.Enabled = True
            Else
                Me.BtnGuardar.Enabled = False
            End If
        End If
    End Sub

    Private Sub crearTabla()
        Dim sqlCmd As New SqlCommand
        sqlCmd.CommandText = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & ParamcodigoAs & "',@CodigoBuxis = " & ParamcodigoBux & ", @SIUD = 'TDXSOLI'"
        While TableDeudas.Rows.Count > 0
            TableDeudas.Rows.RemoveAt(0)
        End While
        TableDeudas = jClass.obtenerDatos(sqlCmd)
    End Sub

    Private Sub TxtEscolaridad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEscolaridad.TextChanged
        Try
            If Val(Me.TxtEscolaridad.Text) > 0 And Val(Me.TxtTotalAhorro_Ordinario.Text) > 0 Then
                Me.TxtEscolaridad_porcentaje.Text = Format((Val(Me.TxtEscolaridad.Text) / Val(Me.TxtTotalAhorro_Ordinario.Text)) * 100, "0.00")
                Me.TxtISR.Text = Format((Val(Me.TxtEscolaridad.Text) * (ISR / 100)), "0.00")
                Me.TxtTotalBruto01.Text = Format((Val(Me.TxtTotalAhorro.Text) + Val(Me.TxtEscolaridad.Text) - Val(Me.TxtISR.Text)), "0.00")
                Me.TxtTotalBruto02.Text = Me.TxtTotalBruto01.Text
                Me.TxtTotal.Text = (Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtIntereses.Text) - Val(Me.txtSegDeuda.Text)).ToString("0.00")
            Else
                Me.TxtEscolaridad_porcentaje.Text = "0.00"
            End If
        Catch ex As Exception
            Me.TxtEscolaridad_porcentaje.Text = "0.00"
        End Try
    End Sub

    Private Sub btnCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculo.Click
        Dim rpt1 As New Cooperativa_calculo_intereses_retiros
        Dim frmVer As New frmReportes_Ver
        Dim txtObj As TextObject

        txtObj = rpt1.Section2.ReportObjects.Item("txtEmpresa")
        txtObj.Text = Descripcion_Compañia
        txtObj = rpt1.Section2.ReportObjects.Item("txtFProceso")
        txtObj.Text = "FECHA DE PROCESO: " & Format(Now, "dd/MM/yyyy")

        SQL = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_PRESTAMOS_ENCABEZADO_IUD]" & vbCrLf
        SQL &= " @COMPAÑIA           = " & Compañia & vbCrLf
        SQL &= ",@CODIGO_EMPLEADO    = " & Me.TxtCodBuxy.Text & vbCrLf
        SQL &= ",@CODIGO_EMPLEADO_AS = '" & Me.TxtCodAS.Text & "'" & vbCrLf
        SQL &= ",@PRESTAMO           = 0" & vbCrLf
        SQL &= ",@INTERES            = 0" & vbCrLf
        SQL &= ",@MONTO_PRESTAMO     = 0" & vbCrLf
        SQL &= ",@FECHA_INICIO       = '" & Format(Now, "dd/MM/yyyy") & "'" & vbCrLf
        SQL &= ",@DEDUCCION          = 0" & vbCrLf
        SQL &= ",@ANULADO            = 0 " & vbCrLf
        SQL &= ",@USUARIO            = '" & Usuario & "'" & vbCrLf
        SQL &= ",@IUD                = 'R'"
        rpt1.SetDataSource(jClass.obtenerDatos(New SqlCommand(SQL)))
        frmVer.crvReporte.ReportSource = rpt1
        frmVer.ShowDialog()
    End Sub
End Class