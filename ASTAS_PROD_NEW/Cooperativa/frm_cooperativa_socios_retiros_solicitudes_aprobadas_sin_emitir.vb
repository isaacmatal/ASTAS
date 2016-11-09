Imports System.Data
Imports System.Data.SqlClient

Public Class frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir
    Dim Permitir As String
    Dim jClass As New jarsClass
    Dim Table, TableCartaRetiro, TablePda, TableRet As DataTable
    Dim Comando_Track As New SqlCommand
    Dim genRemesa As New generarRemesa
    Dim Iniciando, Multiple, SocioRetiroAsoc, SocioRetiroEmpresa As Boolean
    Dim IDRetiro, CantidadRegistros As Integer
    Dim NombreBanco_seleccionadoSocio, SQL, NomApeSocio As String
    Dim CantidadDinero As Double
    Dim Bloque As Integer

    Private Sub frm_cooperativa_socios_retiros_cartas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Iniciando = True
        Try
            Permitir = jClass.obtenerEscalar("SELECT DETALLE FROM CATALOGO_FUNCIONES_ASOCIACION WHERE COMPAÑIA = " & Compañia & " AND DESCRIPCION_FUNCION = '" & Usuario & "'").ToString()
        Catch ex As Exception
            Permitir = "0"
        End Try
        Me.Label7.Text = Descripcion_Compañia
        CargarDatos_aprobados_no_emitidos(Compañia)
        CargarDatosBancos_socio_aprobados_noemitidos()
        Iniciando = False
        Me.CmbBanco_SelectedIndexChanged(sender, e)
        Me.Label14.Text = "Total: $ " & Format(0, "#,##0.00")
        Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", 0, 0, '0', 'SE', 'Monto'"
        TableCartaRetiro = jClass.obtenerDatos(Comando_Track)
        CrearTablaPda()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargarDatos_aprobados_no_emitidos(ByVal Compañia)
        Try
            SQL = "Execute sp_COOPERATIVA_SOCIO_RETIROS @COMPAÑIA = " & Compañia & ", @SIUD ='SANI', @ORIGENES = '" & Permitir & "'"
            Comando_Track.CommandText = SQL
            TableRet = jClass.obtenerDatos(Comando_Track)
            dgvRetirosEmitidos.DataSource = TableRet
            Me.dgvRetirosEmitidos.Columns.Item("COMPAÑIA").Visible = False
            Me.dgvRetirosEmitidos.Columns.Item("Selec").Width = 40
            Me.dgvRetirosEmitidos.Columns.Item("Tipo Documento").Visible = False
            Me.dgvRetirosEmitidos.Columns.Item("Numero Cheque").Visible = False
            Me.dgvRetirosEmitidos.Columns.Item("Estado").Visible = False
            Me.dgvRetirosEmitidos.Columns.Item("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.Label14.Text = "Total: $ 0.00"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            For i As Integer = 2 To dgvRetirosEmitidos.Columns.Count - 1
                dgvRetirosEmitidos.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dgvRetirosEmitidos.Columns.Item(i).ReadOnly = True
                If i >= 14 Then
                    Me.dgvRetirosEmitidos.Columns.Item(i).Visible = False
                End If
            Next
            Me.dgvRetirosEmitidos.Columns.Item("COMENTARIO").Visible = True
            Me.dgvRetirosEmitidos.Columns.Item("COMENTARIO").Width = 500
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMSSolicitutes_noaprobadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        CMSSolicitudes_aprobadasnoemitidas_undoactual.Click, CMSSolicitudes_aprobadasnoemitidas_undotodas.Click
        If sender Is CMSSolicitudes_aprobadasnoemitidas_undoactual Then
            If IDRetiro = Nothing Then
                MessageBox.Show("No se ha seleccionado ninguna solicitud de retiro...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MessageBox.Show("Solicitud de retiro de ahorro de:" & Chr(13) & IDRetiro & " - " & _
                                NomApeSocio & " Está en proceso de pago." & Chr(13) & _
                                "¿Esta seguro que desea anular la solicitud de retiro de ahorros seleccionada?", _
                                Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                                Windows.Forms.DialogResult.Yes Then
                Eliminar_Retiro_Solicitud(Compañia, IDRetiro, ParamcodigoBux, ParamcodigoAs, "USANE-SNA")
            End If
        ElseIf sender Is CMSSolicitudes_aprobadasnoemitidas_undotodas Then

            If MessageBox.Show("Las solicitud de retiro de ahorro estan en proceso de pago." & Chr(13) & _
                                "¿Esta seguro que desea anular las solicitudes de retiro de ahorros seleccionadas?", _
                                Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                                Windows.Forms.DialogResult.Yes Then
                Eliminar_Retiro_Solicitud(Compañia, IDRetiro, ParamcodigoBux, ParamcodigoAs, "USANE-SNAT")
            End If
        End If
    End Sub

    Private Sub Eliminar_Retiro_Solicitud(ByVal Compañia, ByVal IDRetiro, ByVal ParamcodigoBux, ByVal ParamcodigoAs, ByVal Accion)
        Try
            Comando_Track.CommandText = "Execute sp_COOPERATIVA_SOCIO_RETIROS " & IDRetiro & "," & Compañia & ",2,0,'#123456'," & ParamcodigoBux & ",'" & ParamcodigoAs & "',10,0,'SYSTEM','27/08/11','" & Accion & "'"
            CantidadRegistros = jClass.ejecutarComandoSql(Comando_Track)
            MessageBox.Show(CantidadRegistros & " Registro(s) eliminado(s)...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarDatos_aprobados_no_emitidos(Compañia)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarDatosBancos_socio_aprobados_noemitidos()
        Try
            Comando_Track.CommandText = "Execute sp_COOPERATIVA_SOCIO_RETIROS @COMPAÑIA = " & Compañia & ", @SIUD = 'SBCS_ANE', @ORIGENES = '" & Permitir & "'"
            Table = jClass.obtenerDatos(Comando_Track)
            Me.CmbBanco.DataSource = Table
            Me.CmbBanco.ValueMember = "BANCO_EMITIDO"
            Me.CmbBanco.DisplayMember = "BANCO_EMITIDO_DESCRIPCION"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  

    Private Sub DataGrid_aprobadas_no_emitidos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            IDRetiro = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("No").Value()
            ParamcodigoBux = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Cod Buxi").Value()
            ParamcodigoAs = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Cod AS").Value()
            NomApeSocio = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Nombres").Value() & " " & Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Apellidos").Value()
            NombreBanco_seleccionadoSocio = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells(8).Value()
            Asociacion_AhorrosOrdinarioExtraordinario(e.RowIndex)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Btn_Aprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aprobar.Click
        Dim Rpt As New rpt_reporte_cooperativa_retiro_ahorro_recibo1
        Dim frmver As New frmReportes_Ver
        Dim Cuenta, Cuenta1, corrBAC As Integer
        Dim MontoPda As Double
        Dim i As Integer = 0
        Dim txtObj As CrystalDecisions.CrystalReports.Engine.TextObject
        While TableCartaRetiro.Rows.Count > 0
            Me.TableCartaRetiro.Rows.RemoveAt(0)
        End While
        If Me.CmbBanco.Text = Nothing Then
            MessageBox.Show("No se ha seleccionado banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Me.CmbCuentaBancaria.Text = Nothing Then
            MessageBox.Show("No se ha seleccionado cuenta bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Me.lblProcesando.Visible = True
        For i = 0 To Me.dgvRetirosEmitidos.Rows.Count - 1
            If Me.dgvRetirosEmitidos.Rows(i).Cells("Selec").Value Then
                MontoPda += Me.dgvRetirosEmitidos.Rows(i).Cells("Monto").Value
                Cuenta += 1
            End If
        Next
        If Cuenta = 0 Then
            MsgBox("Debe seleccionar al menos un regitro para procesar.", MsgBoxStyle.Information, "Validación")
            Return
        End If
        If MessageBox.Show("¿Desea procesar la(s) solicitud(es) seleccionada(s) actualmente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
            Bloque = jClass.obtenerEscalar("SELECT ISNULL(MAX(BLOQUE),0) + 1 FROM COOPERATIVA_PROGRAMACION_SOLICITUDES_REMESAS WHERE COMPAÑIA = " & Compañia & " AND CONVERT(DATE, FECHA_CONTABLE) = CONVERT(DATE, '" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "', 103)" & " AND UBICACION = 2 AND BANCO = " & Me.CmbBanco.SelectedValue)
            genRemesa.sn = True
            For Each row As DataGridViewRow In Me.dgvRetirosEmitidos.Rows
                If row.Cells("Selec").Value Then
                    Cuenta1 += 1
                    If Cuenta1 = Cuenta Then
                        genRemesa.abrirCarpeta = True
                    Else
                        genRemesa.abrirCarpeta = False
                    End If
                    If Me.CmbBanco.SelectedValue = 3 And Cuenta1 = 1 Then
                        'El Banco de America Central exige un encabezado con el codigo de la empresa, correlativo de archivo enviado, la fecha de envio, el monto total y la cantidad de registros procesados
                        corrBAC = CInt(jClass.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia))
                        corrBAC = CInt(InputBox("SI EL NUMERO ES CORRECTO HAGA CLICK EN ACEPTAR" & vbCrLf & "DE LO CONTRARIO INGRESE EL NUEVO CORRELATIVO Y HAGA CLICK EN ACEPTAR", "CORRELATIVO DE REMESA BANCO AMERICA CENTRAL:", corrBAC))
                        jClass.Ejecutar_ConsultaSQL("UPDATE CONTABILIDAD_CATALOGO_CONSTANTE SET VALOR = " & (corrBAC + 1).ToString() & " WHERE CONSTANTE = 12 AND COMPAÑIA = " & Compañia)
                        genRemesa.EncabBAC = "B4978" & corrBAC.ToString("00000") & Format(Me.dpFechaContable.Value, "yyyyMMdd").PadLeft(33, " ") & (MontoPda * 100).ToString().PadLeft(13, " ") & Cuenta.ToString().PadLeft(5, " ")
                        genRemesa.setEncab = True
                    Else
                        genRemesa.setEncab = False
                    End If
                    Reporte_carta_ahorros(row)
                    genRemesa.sn = False
                End If
            Next
            If TableCartaRetiro.Rows.Count > 0 Then
                If Origen = 5 Or Origen = 6 Then
                    Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA1").ObjectFormat.EnableSuppress = True
                    Rpt.Section3.ReportObjects.Item("txtATAF").ObjectFormat.EnableSuppress = False
                    Rpt.Section3.ReportObjects.Item("NOMBRECOMPAÑIA2").ObjectFormat.EnableSuppress = True
                    Rpt.Section3.ReportObjects.Item("txtATAF2").ObjectFormat.EnableSuppress = False
                    txtObj = Rpt.Section3.ReportObjects.Item("Text22")
                    txtObj.Text = "NIT 0501-200694-101-6"
                End If
                Rpt.SetDataSource(TableCartaRetiro)
                frmver.ReportesGenericos(Rpt)
                frmver.ShowDialog()
            End If
            CargarDatos_aprobados_no_emitidos(Compañia)
            CargarDatosBancos_socio_aprobados_noemitidos()
            Me.SelectAll.Checked = False
            Me.lblProcesando.Visible = False
        End If
    End Sub

    Private Sub Asociacion_AhorrosOrdinarioExtraordinario(ByVal Linea As Integer)
        Dim tablaAhorro As DataTable
        Try
            SQL = "SELECT [AHORRO ORDINARIO], [AHORRO EXTRAORDINARIO], [Monto por Saldar] "
            SQL &= "FROM VISTA_COOPERATIVA_DISPONIBLE_DEL_SOCIO "
            SQL &= "WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Me.dgvRetirosEmitidos.Rows(Linea).Cells("Cod AS").Value
            SQL &= "' AND CODIGO_EMPLEADO = " & Me.dgvRetirosEmitidos.Rows(Linea).Cells("Cod Buxi").Value
            Comando_Track.CommandText = SQL
            tablaAhorro = jClass.obtenerDatos(Comando_Track)

            If tablaAhorro.Rows.Count > 0 Then
                Me.TxtTotalAhorro_Ordinario.Text = Format(tablaAhorro.Rows(0).Item("AHORRO ORDINARIO"), "0.00")
                Me.TxtTotalAhorro_ExtraOrdinario.Text = Format(tablaAhorro.Rows(0).Item("AHORRO EXTRAORDINARIO"), "0.00")
                Me.TxtTotalAhorro.Text = Format(tablaAhorro.Rows(0).Item("AHORRO ORDINARIO") + tablaAhorro.Rows(0).Item("AHORRO EXTRAORDINARIO"), "0.00")
            Else
                Me.TxtTotalAhorro_Ordinario.Text = "0.00"
                Me.TxtTotalAhorro_ExtraOrdinario.Text = "0.00"
                Me.TxtTotalAhorro.Text = "0.00"
            End If

            Me.TxtEscolaridad_porcentaje.Text = Me.dgvRetirosEmitidos.Rows(Linea).Cells("PORCENTAJE_ESCOLARIDAD").Value
            Me.TxtEscolaridad.Text = Format(Me.dgvRetirosEmitidos.Rows(Linea).Cells("TOTAL_ESCOLARIDAD").Value, "0.00")

            Me.TxtISR_porcentaje.Text = Me.dgvRetirosEmitidos.Rows(Linea).Cells("PORCENTAJE_RENTA").Value
            Me.TxtISR.Text = Format(Me.dgvRetirosEmitidos.Rows(Linea).Cells("TOTAL_RENTA").Value, "0.00")

            Me.TxtTotalBruto01.Text = Format((Val(Me.TxtTotalAhorro.Text) + Val(Me.TxtEscolaridad.Text) - Val(Me.TxtISR.Text)), "0.00")
            If Me.dgvRetirosEmitidos.Rows(Linea).Cells("RETIRO_ASOCIACION").Value Then
                Me.TxtTotalBruto02.Text = Me.TxtTotalBruto01.Text
                Me.TxtTotalDeudas.Text = Format(Me.dgvRetirosEmitidos.Rows(Linea).Cells("TOTAL_DEUDAS").Value, "0.00")
                Me.txtInteres.Text = Format(Me.dgvRetirosEmitidos.Rows(Linea).Cells("TOTAL_INTERESES").Value, "0.00")
                Me.txtSegDeuda.Text = Format(Me.dgvRetirosEmitidos.Rows(Linea).Cells("TOTAL_SEGURO_DEUDA").Value, "0.00")
                Me.TxtTotal.Text = Format((Val(Me.TxtTotalBruto02.Text) - Val(Me.TxtTotalDeudas.Text)) - Val(Me.txtInteres.Text) - Val(Me.txtSegDeuda.Text), "0.00")
            Else
                For Each control As Control In DrpDatosLibresDeuda.Controls
                    If TypeOf control Is TextBox Then
                        control.Text = "0.00"
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Reporte_carta_ahorros(ByVal row As DataGridViewRow)
        Dim Clase_letras_numeros As New NumeroLetras
        Dim CantidadLetras As String
        Dim TableRetiros As DataTable
        Asociacion_AhorrosOrdinarioExtraordinario(row.Index)
        SocioRetiroAsoc = row.Cells("RETIRO_ASOCIACION").Value
        SocioRetiroEmpresa = row.Cells("RETIRO_EMPRESA").Value
        CantidadDinero = row.Cells("Monto").Value
        Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS @RETIRO = " & row.Cells("No").Value & ", @COMPAÑIA = " & Compañia & ", @CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value & ", @CODIGO_EMPLEADO_AS = '" & row.Cells("Cod AS").Value & "', @SIUD = 'UBRAANE-1'"
        Origen = row.Cells("ORIGEN").Value
        jClass.ejecutarComandoSql(Comando_Track)
        Dim Prin02 As New frm_reporte_cooperativa_retiro_ahorro_cheque
        Dim Cheque As Integer = 0
        Dim Comentario As String
        Dim CtaContable As Integer
        CtaContable = jClass.obtenerEscalar("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_BANCOS_CUENTAS WHERE COMPAÑIA = " & Compañia & " AND BANCO = " & row.Cells("Banco").Value & " AND CUENTA_BANCARIA = '" & Me.CmbCuentaBancaria.SelectedValue & "'")
        'Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & row.Cells("No").Value & ", " & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "', 'Eliminar','" & CantidadLetras & "'"
        'jClass.ejecutarComandoSql(Comando_Track)
        If Not SocioRetiroAsoc Then
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_IUD " & Compañia & "," & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "',0,'" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "',10,0," & row.Cells("Monto").Value * -1 & ",0,0,'" & Usuario & "','I'"
            'Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_I02 " & Compañia & "," & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "','I'"
            jClass.ejecutarComandoSql(Comando_Track)
            CantidadLetras = Clase_letras_numeros.Letras(CantidadDinero.ToString("0.00"))
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & "," & row.Cells("No").Value & "," & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "','Insertar','" & CantidadLetras & "'"
            jClass.ejecutarComandoSql(Comando_Track)
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & row.Cells("No").Value & ", " & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "', 'SE', 'Monto'"
            TableRetiros = jClass.obtenerDatos(Comando_Track)
            TableCartaRetiro.ImportRow(TableRetiros.Rows(0))
        Else
            CantidadLetras = Clase_letras_numeros.Letras(Format(row.Cells("TOTAL_ESCOLARIDAD").Value, "0.00"))
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_AHORROS_IUD " & Compañia & "," & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "',0,'" & Format(row.Cells("INTERES_HASTA").Value, "dd/MM/yyyy") & "',10," & row.Cells("TOTAL_AHORRO_ORDINARIO").Value * -1 & "," & row.Cells("TOTAL_AHORRO_EXTRAORDINARIO").Value * -1 & ",0,0,'" & Usuario & "','I'"
            jClass.ejecutarComandoSql(Comando_Track)
            Comando_Track.CommandText = "EXECUTE [dbo].[sp_COOPERATIVA_SOCIO_AHORROS_IUD]" & vbCrLf
            Comando_Track.CommandText &= "	@COMPAÑIA = " & Compañia & "," & vbCrLf
            Comando_Track.CommandText &= "	@CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value & "," & vbCrLf
            Comando_Track.CommandText &= "	@CODIGO_EMPLEADO_AS = '" & row.Cells("Cod AS").Value & "'," & vbCrLf
            Comando_Track.CommandText &= "	@IUD = 'SR'"
            jClass.ejecutarComandoSql(Comando_Track)
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_RETIROS_ESCOLARIDAD 1," & row.Cells("No").Value & "," & Compañia & "," & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "'," & row.Cells("TOTAL_AHORRO_ORDINARIO").Value & "," & row.Cells("TOTAL_AHORRO_EXTRAORDINARIO").Value & "," & row.Cells("TOTAL_ESCOLARIDAD").Value & "," & row.Cells("TOTAL_RENTA").Value & ",'" & Usuario & "','" & CantidadLetras & "','I'"
            jClass.ejecutarComandoSql(Comando_Track)
            If row.Cells("TOTAL_DEUDAS").Value > 0 Then
                CancelaDeudas(row.Cells("Cod AS").Value, row.Cells("Cod Buxi").Value)
            End If
            CantidadLetras = Clase_letras_numeros.Letras(CantidadDinero.ToString("0.00"))
            Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIOS_ID_RETIRO_CARTA_RECIBO " & Compañia & ", " & row.Cells("No").Value & ", " & row.Cells("Cod Buxi").Value & ",'" & row.Cells("Cod AS").Value & "', 'Insertar','" & CantidadLetras & "'"
            jClass.ejecutarComandoSql(Comando_Track)
            Mostrar_carta_retiro_asociacion(row.Cells("Cod Buxi").Value, row.Cells("Cod AS").Value, row.Cells("No").Value)
        End If
        If row.Cells("CODIGO_DOCUMENTO").Value = 6 Then
            Cheque = row.Cells("Numero Cheque").Value
            If Cheque = 0 Then
                Comentario = InputBox("Por favor ingrese el número del cheque para continuar." & Chr(13) & "A nombre de: " & Chr(13) & row.Cells("Nombres").Value & " " & row.Cells("Apellidos").Value & Chr(13) & "Por valor de: $ " & row.Cells("Monto").Value, "Número de Cheque", GeneraCorrelativoCheque(row.Cells("Banco").Value, Me.CmbCuentaBancaria.SelectedValue))
                If Comentario = Nothing Then
                    Cheque = 0
                Else
                    Cheque = Val(Comentario)
                    Comentario = ""
                End If
            End If
            Prin02.lblRetiro.Text = row.Cells("No").Value.ToString
            Prin02.lblBuxis.Text = row.Cells("Cod Buxi").Value.ToString
            Prin02.lblSocio.Text = row.Cells("Cod AS").Value
            Prin02.Banco.Text = Cheque.ToString
            Prin02.CtaBanco.Text = row.Cells("Nombre Banco").Value
            Prin02.WindowState = FormWindowState.Maximized
            Prin02.ShowDialog()
            Comentario = "CH-" & Cheque & " " & row.Cells("Nombres").Value & " " & row.Cells("Apellidos").Value & IIf(SocioRetiroAsoc, " RETIRO DE ASOCIACION", " RETIRO AHORRO EXTRAORDINARIO")
            Try
                Monto = row.Cells("Monto").Value - 0.25
                jClass.daFormatoMonto_RCR()
                jClass.creaLineas_RCR()
                jClass.mttoChequesProgSolicitudes(Compañia, Cheque, 0, 0 _
                                                , Monto, Now.Date, row.Cells("No").Value.ToString, row.Cells("Cod Buxi").Value _
                                                , row.Cells("Cod AS").Value, IIf(Me.SocioRetiroAsoc, "Retiro Asoc.", "Retiro Ext."), row.Cells("Banco").Value, CtaContable _
                                                , Me.CmbCuentaBancaria.SelectedValue, 0 _
                                                , jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1") _
                                                , "I", row.Cells("Nombres").Value, 0.25)
            Catch ex As Exception
                'Esto se hace por que la funcion anterior no es determinante para el proceso de pago del retiro
                'ya que solo es para guardar los datos del cheque pero estos datos no se estan usando en ningun
                'otro proceso dentro de la aplicacion, por lo que no es necesario que el usuario vea el error.
            End Try
        Else
            genRemesa.Bloque = Bloque.ToString
            genRemesa.TipoTran = "RETIRO DE EXTRA"
            genRemesa.ctaSocio = row.Cells("Cuenta").Value
            genRemesa.bco = row.Cells("BcoSocio").Value
            genRemesa.monto = row.Cells("Monto").Value
            genRemesa.NITSocio = row.Cells("NIT").Value
            genRemesa.FechaDep = Format(Me.dpFechaContable.Value, "yyyyMMdd")
            genRemesa.ubicacion = jClass.obtenerEscalar("SELECT (CONVERT(NVARCHAR,S.DIVISION)+CONVERT(NVARCHAR,S.SECCION)+CONVERT(NVARCHAR,S.DEPARTAMENTO)) [Ubicación]	FROM  COOPERATIVA_CATALOGO_SOCIOS S WHERE S.CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value.ToString & " AND S.CODIGO_EMPLEADO_AS = " & row.Cells("Cod AS").Value & " AND S.COMPAÑIA = " & Compañia)
            genRemesa.socio = row.Cells("Nombres").Value & " " & row.Cells("Apellidos").Value
            genRemesa.recibirParametros(Compañia, row.Cells("Banco").Value.ToString, row.Cells("Cuenta").Value, row.Cells("No").Value.ToString, row.Cells("Cod AS").Value.ToString, row.Cells("Cod Buxi").Value.ToString, "EXTRA")
            jClass.mttoRemesasProgSolicitudes(Compañia, row.Cells("No").Value, row.Cells("No").Value, row.Cells("Cod Buxi").Value, row.Cells("Cod AS").Value _
                                            , row.Cells("Monto").Value, row.Cells("Banco").Value, Me.CmbCuentaBancaria.SelectedValue _
                                            , jClass.FechaActual_Servidor(), 2, "I", Bloque)
            Comentario = "REMESA - " & row.Cells("Nombres").Value & " " & row.Cells("Apellidos").Value & IIf(SocioRetiroAsoc, " RETIRO DE ASOCIACION", " RETIRO AHORRO EXTRAORDINARIO")
        End If
        'Por el momento se desactiva la generación de partidas contables (07/11/2013)
        If SocioRetiroAsoc Then
            'PartidaRetiroAsoc(row.Cells("ORIGEN").Value, Cheque.ToString, Comentario, CtaContable, row.Cells("Cod AS").Value, row.Cells("Cod Buxi").Value)
            Comando_Track.CommandText = "UPDATE [COOPERATIVA_CATALOGO_SOCIOS] SET ESTATUS = " & IIf(SocioRetiroEmpresa, "0", "1") & " WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & row.Cells("Cod AS").Value & "' AND CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value
            CantidadRegistros = jClass.ejecutarComandoSql(Comando_Track)
            RetirarSocioAsociacion(row.Cells("Cod AS").Value, row.Cells("Cod Buxi").Value, row.Cells("COMENTARIO").Value)
            If Me.SocioRetiroEmpresa Then
                SQL = "UPDATE CAFETERIA_EMPLEADOS_DESCUENTOS SET BLOQUEADOS = 1 WHERE CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value & " AND COMPAÑIA = " & Compañia
                jClass.Ejecutar_ConsultaSQL(SQL)
            End If
        End If
        Comando_Track.CommandText = "UPDATE [dbo].[COOPERATIVA_SOCIO_RETIROS] SET ESTADO = 3, NUMERO = " & Cheque & ", CUENTA_EMITIDO = '" & Me.CmbCuentaBancaria.SelectedValue & "' WHERE RETIRO = " & row.Cells("No").Value.ToString & " AND CODIGO_EMPLEADO = " & row.Cells("Cod Buxi").Value.ToString & " AND CODIGO_EMPLEADO_AS = '" & row.Cells("Cod AS").Value & "' AND COMPAÑIA = " & Compañia
        CantidadRegistros = jClass.ejecutarComandoSql(Comando_Track)
    End Sub

    Private Sub Mostrar_carta_retiro_asociacion(ByVal codBuxis As Integer, ByVal codAS As String, ByVal ID_retiro As String)
        ParamcodigoBux = codBuxis
        ParamcodigoAs = codAS
        Dim Prin As New frm_reporte_retiro_asociacion
        Prin.ID_Retiro = ID_retiro
        Prin.WindowState = FormWindowState.Maximized
        Prin.ShowDialog()
    End Sub

    Private Sub PartidaRetiroAsoc(ByVal Origen As Integer, ByVal Documento As String, ByVal Concepto As String, ByVal CtaBanco As Integer, ByVal CodSocio As String, ByVal CodBuxis As Integer)
        Dim TableRetiro, TableDeudas As DataTable
        Dim Sql As String
        Dim CtaContable, Libro, Transaccion, TipDoc, CtaDeuda, CentroCosto, TipoSoli As Integer
        Dim Resta, TotalCargos As Double
        Libro = jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1")
        If jClass.ValidaCierreContable(Compañia, Libro, Me.dpFechaContable.Value.Year, Me.dpFechaContable.Value.Month, "E") Then
            Sql = "SELECT TIPO_MOVIMIENTO, CUENTA, CARGO, VALOR, RESTA "
            Sql &= "FROM CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS "
            Sql &= "WHERE COMPAÑIA = " & Compañia & " AND ORIGEN = " & Origen & " AND TIPO_DOCUMENTO = 26 AND CENTRO_COSTO = 1"
            Comando_Track.CommandText = Sql
            TableRetiro = jClass.obtenerDatos(Comando_Track)
            If TableRetiro.Rows.Count > 0 Then
                Transaccion = jClass.obtenerEscalar("EXECUTE sp_CONTABILIDAD_CORRELATIVOS_DOCUMENTOS @COMPAÑIA = " & Compañia & ", @TIPO_DOCUMENTO = 'TRA', @AÑO = " & Now.Year & ", @MES = " & Now.Month & ", @ULTIMO = 0")
                jClass.EncabezadoPartida(Transaccion, 1, 26, Documento, Me.dpFechaContable.Value, Libro, Concepto, 0, 0, "I")
                If Val(Me.TxtTotalDeudas.Text) > 0 Then
                    Sql = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS "
                    Sql &= "@Compañia = " & Compañia & ", @CodigoAS = '" & CodSocio & "', @CodigoBuxis = " & CodBuxis & ", @SIUD = 'TDXSOLI'"
                    Comando_Track.CommandText = Sql
                    TableDeudas = jClass.obtenerDatos(Comando_Track)
                    If TableDeudas.Rows.Count > 0 Then
                        For i As Integer = 0 To TableDeudas.Rows.Count - 1
                            TipoSoli = TableDeudas.Rows(i).Item(0)
                            TipDoc = jClass.obtenerEscalar("SELECT TIPO_DOCUMENTO FROM dbo.COOPERATIVA_CATALOGO_SOLICITUDES WHERE COMPAÑIA = " & Compañia & " AND SOLICITUD  = " & TableDeudas.Rows(i).Item(0))
                            Select Case TipoSoli
                                Case 14
                                    CentroCosto = 2
                                Case 15
                                    CentroCosto = 4
                                Case Else
                                    CentroCosto = 1
                            End Select
                            CtaDeuda = jClass.obtenerEscalar("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_PARTIDAS_AUTOMATICAS WHERE TIPO_DOCUMENTO = " & TipDoc & " AND CENTRO_COSTO = " & CentroCosto & " AND ORIGEN = " & Origen & " AND CARGO = 1")
                            jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaDeuda, "A", 0, TableDeudas.Rows(i).Item(2), "E")
                        Next
                        If Val(Me.txtInteres.Text) > 0 Then
                            jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, 1485, "A", 0, Val(Me.txtInteres.Text), "E")
                        End If
                        If Val(Me.txtSegDeuda.Text) > 0 Then
                            jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, 435, "A", 0, Val(Me.txtSegDeuda.Text), "E")
                        End If
                    End If
                    CancelaDeudas(CodSocio, CodBuxis)
                End If
                For i As Integer = 0 To TableRetiro.Rows.Count - 1
                    CtaContable = TableRetiro.Rows(i).Item("CUENTA")
                    Select Case i
                        Case 0
                            jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "C", Val(Me.TxtTotalAhorro_Ordinario.Text), 0, "E")
                            TotalCargos += Val(Me.TxtTotalAhorro_Ordinario.Text)
                        Case 1
                            If Val(Me.TxtTotalAhorro_ExtraOrdinario.Text) > 0 Then
                                jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "C", Val(Me.TxtTotalAhorro_ExtraOrdinario.Text), 0, "E")
                                TotalCargos += Val(Me.TxtTotalAhorro_ExtraOrdinario.Text)
                            End If
                        Case 2
                            If Val(Me.TxtEscolaridad.Text) > 0 Then
                                jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "C", Val(Me.TxtEscolaridad.Text), 0, "E")
                                TotalCargos += Val(Me.TxtEscolaridad.Text)
                            End If
                        Case 3
                            If Val(Documento) > 0 Then
                                jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "A", 0, TableRetiro.Rows(i).Item("RESTA"), "E")
                                Resta = TableRetiro.Rows(i).Item("RESTA")
                            End If
                        Case 4
                            If Val(Me.TxtISR.Text) > 0 Then
                                jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "A", 0, Val(Me.TxtISR.Text), "E")
                            End If
                        Case 5
                            jClass.DetallePartida(Transaccion, 0, CodBuxis, Me.dpFechaContable.Value, Libro, Concepto, CtaBanco, "A", 0, TotalCargos - Resta - Val(Me.TxtISR.Text) - Val(Me.TxtTotalDeudas.Text) - Val(Me.txtInteres.Text) - Val(Me.txtSegDeuda.Text), "E")
                    End Select
                Next
                jClass.DetallePartida(Transaccion, 0, 0, Me.dpFechaContable.Value, Libro, Concepto, CtaContable, "A", 0, 0, "A")
                'Comando_Track.CommandText = "EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR @COMPAÑIA = " & Compañia & ", @LIBRO_CONTABLE = " & Libro & ", @TRANSACCION = " & Transaccion & ", @USUARIO = '" & Usuario & "'"
                'jClass.ejecutarComandoSql(Comando_Track)
            End If
        End If
    End Sub

    Private Sub CancelaDeudas(ByVal CodAs As String, ByVal CodBuxis As Integer)
        Dim TableSolPend As DataTable
        Dim Linea As Integer = 0
        Dim query As String
        Dim capital As Double
        Try
            Comando_Track.CommandText = "EXECUTE Coo.sp_COOPERATIVA_DEUDA_HDS @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & CodAs & "', @CodigoBuxis = " & CodBuxis & ", @SIUD = 'TDXSOLEMP'"
            TableSolPend = jClass.obtenerDatos(Comando_Track)
            For i As Integer = 0 To TableSolPend.Rows.Count - 1
                capital = CDbl(jClass.obtenerEscalar("SELECT SUM (CAPITAL) FROM [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE] WHERE COMPAÑIA = " & Compañia & " AND NUMERO_SOLICITUD = " & TableSolPend.Rows(i).Item(0) & " AND CAPITAL_D = 0"))
                Linea = Me.eliminaProgramacionesNoDescontadas(TableSolPend.Rows(i).Item(0))
                Linea += 1
                query = "INSERT INTO [dbo].[COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE]" & vbCrLf
                query &= "([COMPAÑIA]" & vbCrLf
                query &= ",[NUMERO_SOLICITUD]" & vbCrLf
                query &= ",[LINEA]" & vbCrLf
                query &= ",[ENVIADA]" & vbCrLf
                query &= ",[RECIBIDA]" & vbCrLf
                query &= ",[FECHA_PAGO]" & vbCrLf
                query &= ",[SALDO_INI]" & vbCrLf
                query &= ",[CAPITAL]" & vbCrLf
                query &= ",[CAPITAL_D]" & vbCrLf
                query &= ",[INTERES]" & vbCrLf
                query &= ",[INTERES_D]" & vbCrLf
                query &= ",[SEG_DEUDA]" & vbCrLf
                query &= ",[SEG_DEUDA_D]" & vbCrLf
                query &= ",[CUOTA]" & vbCrLf
                query &= ",[CUOTA_D]" & vbCrLf
                query &= ",[SALDO_FIN]" & vbCrLf
                query &= ",[INTERES_ACUM]" & vbCrLf
                query &= ",[REPROGRAMADA]" & vbCrLf
                query &= ",[CUOTA_NO_DESCONTADA]" & vbCrLf
                query &= ",[USUARIO_CREACION]" & vbCrLf
                query &= ",[USUARIO_CREACION_FECHA]" & vbCrLf
                query &= ",[USUARIO_EDICION]" & vbCrLf
                query &= ",[USUARIO_EDICION_FECHA]" & vbCrLf
                query &= ",[COMENTARIO])" & vbCrLf
                query &= "VALUES" & vbCrLf
                query &= "(" & Compañia & vbCrLf
                query &= "," & TableSolPend.Rows(i).Item(0) & vbCrLf
                query &= "," & Linea & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",'" & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "'" & vbCrLf
                query &= "," & capital & vbCrLf
                query &= "," & capital & vbCrLf
                query &= ",1" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",1" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",1" & vbCrLf
                query &= "," & capital & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",0" & vbCrLf
                query &= ",'" & Usuario & "'" & vbCrLf
                query &= ",GETDATE()" & vbCrLf
                query &= ",'" & Usuario & "'" & vbCrLf
                query &= ",GETDATE()" & vbCrLf
                query &= ",'CANCELADO POR RETIRO DE " & IIf(SocioRetiroEmpresa, "EMPRESA", "ASOCIACION") & " EL " & Format(Me.dpFechaContable.Value, "dd/MM/yyyy") & "')"
                jClass.Ejecutar_ConsultaSQL(query)
                'Comando_Track.CommandText = "EXECUTE Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_ANULACION @COMPAÑIA = " & Compañia & ", @NUM_SOLICITUD = " & TableSolPend.Rows(i).Item(0) & ", @MOTIVO = 'RETIRO ASOCIACION', @USUARIO = '" & Usuario & "', 1"
                'Comando_Track.CommandText = "EXECUTE sp_COOPERATIVA_SOCIO_DEUDA_PAGO_PR @COMPAÑIA = " & Compañia & ", @CodigoAS = '" & CodAs & "', @CodigoBuxis = " & CodBuxis & ", @SOLICITUD = " & TableSolPend.Rows(i).Item(0) & ", @USUARIO = '" & Usuario & "', @SIUD = 'UDSP'"
                'CantidadRegistros = jClass.ejecutarComandoSql(Comando_Track)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function eliminaProgramacionesNoDescontadas(ByVal solicitud As String) As Integer
        Dim Conexion As New DLLConnection.Connection
        Dim Conexion_Track As New SqlConnection
        Dim Comando_Track As SqlCommand
        Dim DS As New DataSet()
        Dim Sql As String
        Dim Retorno As Integer = 0
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Try
            Conexion_Track.Open()
            Sql = "exec Coo.sp_COOPERATIVA_PROGRAMACION_SOLICITUDES_DETALLE_ANULADAS_IUD "
            Sql &= Compañia & ","
            Sql &= solicitud & ","
            Sql &= "'" & Usuario & "','E'"
            Comando_Track = New SqlCommand(Sql, Conexion_Track)
            Retorno = Comando_Track.ExecuteScalar()
            Comando_Track.CommandText = "UPDATE COOPERATIVA_SOLICITUDES_AUTORIZACION SET COMENTARIO_ANULADA = 'CANCELADO POR RETIRO ASOCIACION' WHERE COMPAÑIA = " & Compañia & " AND N_SOLICITUD = " & solicitud
            Comando_Track.ExecuteNonQuery()
            Conexion_Track.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return Retorno
    End Function

    Private Sub RetirarSocioAsociacion(ByVal CodAs As String, ByVal CodBuxis As Integer, ByVal Comentario As String)
        Try
            Comando_Track.CommandText = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_ADD_SOCIEDAD" & vbCrLf
            Comando_Track.CommandText &= " @COMPAÑIA = " & Compañia & "," & vbCrLf
            Comando_Track.CommandText &= " @CODIGOEMPLEADO = " & CodBuxis & "," & vbCrLf
            Comando_Track.CommandText &= " @CODIGOEMPLEADOAS = '" & CodAs & "'," & vbCrLf
            Comando_Track.CommandText &= " @ESTADO = 0," & vbCrLf
            Comando_Track.CommandText &= " @MOTIVO = '" & Comentario & "'," & vbCrLf
            Comando_Track.CommandText &= " @USUARIO = '" & Usuario & "'," & vbCrLf
            Comando_Track.CommandText &= " @SIUD = 'U'"
            CantidadRegistros = jClass.ejecutarComandoSql(Comando_Track)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CrearTablaPda()
        TablePda = New DataTable
        TablePda.Columns.Add("Cuenta", Type.GetType("System.Int32"))
        TablePda.Columns.Add("Monto", Type.GetType("System.String"))
    End Sub

    Private Function GeneraCorrelativoCheque(ByVal Banco As Integer, ByVal CuentaBancaria As String) As Integer
        Dim chequera As Integer = 0
        Dim numChq As Integer = 0
        Try
            SQL = "SELECT TOP 1 CHEQUERA FROM CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS WHERE COMPAÑIA = " & Compañia & " AND BANCO = " & Banco & " AND CUENTA_BANCARIA = '" & CuentaBancaria & "' AND ACTIVA = 1"
            chequera = jClass.obtenerEscalar(SQL)
            If chequera = Nothing Then
                chequera = 0
            End If
            SQL = "Execute sp_CONTABILIDAD_CATALOGO_BANCOS_CUENTAS_CHEQUERAS_CORRELATIVO "
            SQL &= Compañia
            SQL &= ", " & Banco
            SQL &= ", '" & CuentaBancaria & "'"
            SQL &= ", " & chequera
            Comando_Track.CommandText = SQL
            Table = jClass.obtenerDatos(Comando_Track)
            If Table.Rows.Count > 0 Then
                numChq = Table.Rows(0).Item("NUMERO_CHEQUE")
            End If
            Return numChq
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function

    Private Sub frm_cooperativa_socios_retiros_solicitudes_aprobadas_sin_emitir_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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

    Private Sub SelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll.CheckedChanged
        Dim i As Integer
        Dim xmonto As Double = 0.0
        For Each row As DataGridViewRow In Me.dgvRetirosEmitidos.Rows
            row.Cells(1).Value = SelectAll.Checked
        Next
        If SelectAll.Checked Then
            SelectAll.Text = "Deseleccionar Todos"
        Else
            SelectAll.Text = "Seleccionar Todos"
        End If
        For i = 0 To Me.dgvRetirosEmitidos.Rows.Count - 1
            If Me.dgvRetirosEmitidos.Rows(i).Cells("Selec").Value Then
                xmonto += Me.dgvRetirosEmitidos.Rows(i).Cells("Monto").Value
            End If
        Next
        Me.Label14.Text = "Total: $ " & Format(xmonto, "#,##0.00")
    End Sub

    Private Sub CmbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBanco.SelectedIndexChanged
        If Iniciando Then
            Return
        End If
        Dim Total As Double = 0
        Try
            Dim rows As DataRow()
            Dim posicion As Integer = -1 '1  
            Dim columna As Integer = 8
            Dim Ncolumn As String = Me.dgvRetirosEmitidos.Columns(columna).Name 'Obtiene el Nombre de Columna actual del DataGridView.
            Dim Strsort As String = ""

            Select Case Me.dgvRetirosEmitidos.Columns(columna).HeaderCell.SortGlyphDirection 'Obtiene nivel de ordenación establecido sobre la columna del DataGridView. 2
                Case SortOrder.Ascending 'En Caso de ser Ascendente
                    Strsort = " Asc" 'Se fija el nombre de columna y la marca Asc
                Case SortOrder.Descending 'En Caso de ser Descendente
                    Strsort = " Desc" 'Se fija el nombre de columna y la marca Desc
            End Select
            'TableRet.DefaultView.Sort = Strsort 'Se Actualiza la vista segun el nivel de ordenación establecido. 3
            Dim tablaT As DataTable = TableRet.Clone() 'Se crea un DataTable temporal en base a la Vista del DataTable Actual. 4
            rows = TableRet.Select("[" & Me.dgvRetirosEmitidos.Columns(columna).Name & "] like '" & Me.CmbBanco.Text & "%'") 'Se establece y ejecuta filtro de llenado de arreglo de DataRow. 5                        
            For i As Integer = 0 To rows.Length - 1
                tablaT.ImportRow(rows(i))
                Total += rows(i).Item("Monto")
            Next
            Me.dgvRetirosEmitidos.DataSource = tablaT
            jClass.CargaCuentasBancarias(Compañia, Me.CmbBanco.SelectedValue, 4, Me.CmbCuentaBancaria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvRetirosEmitidos_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetirosEmitidos.CellContentClick
        Dim i As Integer
        Dim xmonto As Double = 0.0
        If e.RowIndex > -1 Then
            If dgvRetirosEmitidos.CurrentRow.Cells("Selec").Value Then
                dgvRetirosEmitidos.CurrentRow.Cells("Selec").Value = False
            Else
                dgvRetirosEmitidos.CurrentRow.Cells("Selec").Value = True
            End If
            For i = 0 To Me.dgvRetirosEmitidos.Rows.Count - 1
                If Me.dgvRetirosEmitidos.Rows(i).Cells("Selec").Value Then
                    xmonto += Me.dgvRetirosEmitidos.Rows(i).Cells("Monto").Value
                End If
            Next
            Me.Label14.Text = "Total: $ " & Format(xmonto, "#,##0.00")

            Try
                IDRetiro = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("No").Value()
                ParamcodigoBux = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Cod Buxi").Value()
                ParamcodigoAs = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Cod AS").Value()
                NomApeSocio = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Nombres").Value() & " " & Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells("Apellidos").Value()
                NombreBanco_seleccionadoSocio = Me.dgvRetirosEmitidos.Rows(e.RowIndex).Cells(8).Value()
                Asociacion_AhorrosOrdinarioExtraordinario(e.RowIndex)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class