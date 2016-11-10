Imports System.Data.SqlClient

Public Class Activo_Fijo_Bien

    Public accion_ As String
    Dim objEntidad As New EntidadGenerica

    Public id_bien As Integer
    Public codigo_ As String
    Public codigo_explicado As String
    Public estatus_ As Integer
    Public empresa_ As Integer
    Public clasificacion_ As Integer
    Public asignacion_ As Integer
    Public tipo_bien_ As Integer
    Public ubicacion_ As Integer
    Public unidad_medida_ As Integer
    Public condicion_ As Integer
    Public centro_costos_ As Integer
    Public alta_ As Boolean
    Public motivo_baja_ As Integer
    Public baja_parcial_ As Boolean
    Public baja_total_ As Boolean
    Public destino_baja_ As String
    Public observaciones_baja_ As String
    Public descripcion_bien_ As String
    Public marca_ As String
    Public modelo_ As String
    Public numero_serie_ As String
    Public otras_especificaciones_ As String
    Public asignado_a_ As String
    Public division_ As Integer
    Public departamento_area_ As Integer
    Public aplicar_depreciacion_ As Boolean
    Public num_cff_ As String
    Public fecha_cff_ As Date
    Public valor_cff_ As Decimal
    Public responsable_ As String

    Public cantidad_ As Integer
    Public fecha_adquisicion_ As Date
    Public precio_original_finan_ As Decimal
    Public valor_depreciar_finan_ As Decimal
    Public vida_util_finan_ As Integer
    Public depreciacion_mensual_finan_ As Decimal
    Public remanente_finan_ As Decimal
    Public precio_original_fiscal_ As Decimal
    Public valor_depreciar_fiscal_ As Decimal
    Public vida_util_fiscal_ As Integer
    Public depreciacion_mensual_fiscal_ As Decimal
    Public remanente_fiscal_ As Decimal
    Public encargado_ As String
    Public activa_ As Boolean
    Public fecha_vencimiento_finan_ As Date
    Public fecha_vencimiento_fiscal_ As Date
    Public fecha_baja_ As Date
    Dim inicio_ As Boolean
    Dim dt As New DataTable
    Dim una_ves_ As Boolean = True
    Dim _porcentaje As Decimal = 0
    Public porcentaje_finan_ As Decimal
    Public porcentaje_fiscal_ As Decimal
    Public valor_residual_finan_ As Decimal
    Public valor_residual_fiscal_ As Decimal
    Dim cargando_ As Boolean
    Dim _params As String = String.Empty
    Dim _params_movimiento As String = String.Empty
    Dim _datos As New DataTable()

    Private Sub Activo_Fijo_Bien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtComentarios.Text = String.Empty
        Iniciando = True
        Me.setTitle()
        Me.dgvCuentasContables.DataSource = Nothing
        Me.dgvMovimientos.DataSource = Nothing
        Me.btnGuardar.Enabled = True
        inicio_ = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        objEntidad.fillComboBox(Me.cmbEmpresa, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_empresa', @COMPAÑIA = " & Compañia, "EMPRESA", "NOMBRE_EMPRESA")
        objEntidad.fillComboBox(Me.cmbClasificacion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_clasificacion', @COMPAÑIA = " & Compañia, "CLASIFICACION", "DESCRIPCION_CLASIFICACION")
        objEntidad.fillComboBox(Me.cmbAsignacion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_asignacion', @COMPAÑIA = " & Compañia, "ASIGNACION", "DESCRIPCION_ASIGNACION")
        objEntidad.fillComboBox(Me.cmbUnidadMedida, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_unid_medida', @COMPAÑIA = " & Compañia, "UNIDAD_MEDIDA", "DESCRIPCION")
        objEntidad.fillComboBox(Me.cmbEstatus, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_estatus', @COMPAÑIA = " & Compañia, "ESTATUS", "DESCRIPCION")
        objEntidad.fillComboBox(Me.cmbCondicion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_condicion'", "CONDICION", "DESCRIPCION")
        objEntidad.fillComboBox(Me.cmbMotivoBaja, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_motivobaja'", "MOTIVO_BAJA", "DESCRIPCION")
        objEntidad.fillComboBox(Me.cmbCentroCostos, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_cc', @COMPAÑIA = " & Compañia, "CENTRO_COSTO", "DESCRIPCION_CENTRO_COSTO")
        objEntidad.fillComboBox(Me.cmbDivision, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_division', @COMPAÑIA = " & Compañia, "DIVISION", "DESCRIPCION_DIVISION")
        objEntidad.fillComboBox(Me.cmbUbicacion, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_ubicacion'", "UBICACION", "DESCRIPCION_UBICACION")

        Me.cmbEmpresa.SelectedValue = -1
        Me.cmbClasificacion.SelectedValue = -1
        Me.cmbAsignacion.SelectedValue = -1
        Me.cmbTipoBien.SelectedValue = -1
        Me.cmbUbicacion.SelectedValue = -1

        If una_ves_ Then
            'Me.dgvCuentas.AutoGenerateColumns = False
            'Me.dgvCuentas.ColumnCount = 5

            'Me.dgvCuentas.Columns(0).Name = "CUENTA"
            'Me.dgvCuentas.Columns(0).HeaderText = "CUENTA"
            'Me.dgvCuentas.Columns(0).DataPropertyName = "CUENTA"
            'Me.dgvCuentas.Columns(0).Visible = False

            'Me.dgvCuentas.Columns(1).Name = "BIEN"
            'Me.dgvCuentas.Columns(1).HeaderText = "BIEN"
            'Me.dgvCuentas.Columns(1).DataPropertyName = "BIEN"
            'Me.dgvCuentas.Columns(1).Visible = False

            'Me.dgvCuentas.Columns(2).Name = "CUENTACONTABLE"
            'Me.dgvCuentas.Columns(2).HeaderText = "Cuenta Cont. Centro Costo"
            'Me.dgvCuentas.Columns(2).DataPropertyName = "CUENTACONTABLE"
            'Me.dgvCuentas.Columns(2).Width = 300

            'Me.dgvCuentas.Columns(3).Name = "PORCENTAGE_ASIGNADO"
            'Me.dgvCuentas.Columns(3).HeaderText = "Porcentaje Asignado"
            'Me.dgvCuentas.Columns(3).DataPropertyName = "PORCENTAGE_ASIGNADO"
            'Me.dgvCuentas.Columns(3).Width = 300

            'Me.dgvCuentas.Columns(4).Name = "CUENTAREAL"
            'Me.dgvCuentas.Columns(4).HeaderText = "CUENTAREAL"
            'Me.dgvCuentas.Columns(4).DataPropertyName = "CUENTAREAL"
            'Me.dgvCuentas.Columns(4).Visible = False
            una_ves_ = False
        End If

        If Not Me.accion_.Equals("insert") Then
            Me.consultar()
            Me.lblComentarios.Visible = True
            Me.txtComentarios.Visible = True

            dt = objEntidad.getData("SELECT  CUENTA, BIEN, CUENTACONTABLE, PORCENTAGE_ASIGNADO, CUENTAREAL FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CUENTACONTABLE WHERE BIEN=" & id_bien)

            Me.dgvCuentasContables.AutoGenerateColumns = False
            Me.dgvCuentasContables.DataSource = dt


            Me.calcularAcumulado("fiscal")
            Me.calcularAcumulado("financiero")

            Me.cmbEmpresa.SelectedValue = Me.empresa_
            Me.cmbClasificacion.SelectedValue = Me.clasificacion_
            Me.cmbAsignacion.SelectedValue = Me.asignacion_
            If Me.cmbClasificacion.SelectedValue > 0 Then
                objEntidad.fillComboBox(Me.cmbTipoBien, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_tpobien', @COMPAÑIA = " & Compañia & ",@CLASIFICACION=" & Me.cmbClasificacion.SelectedValue, "TIPO_BIEN", "DESCRPCION")
            End If
            Me.cmbTipoBien.SelectedValue = Me.tipo_bien_
            Me.cmbUbicacion.SelectedValue = Me.ubicacion_
            Me.cmbMotivoBaja.SelectedValue = Me.motivo_baja_
            Me.cmbUnidadMedida.SelectedValue = Me.unidad_medida_
            Me.cmbCondicion.SelectedValue = Me.condicion_
            Me.cmbDivision.SelectedValue = Me.division_
            If Me.cmbDivision.SelectedValue > 0 Then
                objEntidad.fillComboBox(Me.cmbDepartamentoArea, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_depto', @DIVISION=" & Me.cmbDivision.SelectedValue & ", @COMPAÑIA = " & Compañia, "DEPARTAMENTO", "DESCRIPCION_DEPARTAMENTO")
            End If
            Me.cmbDepartamentoArea.SelectedValue = Me.departamento_area_
            Me.cmbCentroCostos.SelectedValue = Me.centro_costos_
            Me.cmbEstatus.SelectedValue = Me.estatus_

            Me.dtpAdqicicion.Value = Me.fecha_adquisicion_
            Me.dtpVencimientoFinanciero.Value = Me.fecha_vencimiento_finan_
            Me.dtpVencimientoFiscal.Value = Me.fecha_vencimiento_fiscal_
            Me.dtpFechaBaja.Value = Me.fecha_baja_
            Me.dtpFechaCff.Value = Me.fecha_cff_

            Me.nudPrecioOriginalFinanciero.Value = Me.precio_original_finan_
            Me.nudValorDepreciarFinanciero.Value = Me.valor_depreciar_finan_
            Me.nudVidaUtilFinanciero.Value = Me.vida_util_finan_
            Me.nudDepreciaMensualFinanciero.Value = Me.depreciacion_mensual_finan_
            Me.nudRemanenteFinanciero.Value = Me.remanente_finan_
            Me.nudPorcentajeNoDepreFinan.Value = Me.porcentaje_finan_
            Me.nudPorcentajeNoDepreFiscal.Value = Me.porcentaje_fiscal_
            Me.nudValorResidualFinanciero.Value = Me.valor_residual_finan_
            Me.nudValorResidualFiscal.Value = Me.valor_residual_fiscal_
            Me.nudPrecioOriginalFiscal.Value = Me.precio_original_fiscal_
            Me.nudValorDepreciarFiscal.Value = Me.valor_depreciar_fiscal_
            Me.nudVidaUtilFiscal.Value = Me.vida_util_fiscal_
            Me.nudDepreciaMensualFiscal.Value = Me.depreciacion_mensual_fiscal_
            Me.nudRemanenteFiscal.Value = Me.remanente_fiscal_
            Me.nudCantidad.Value = Me.cantidad_
            Me.nudValorCff.Value = Me.valor_cff_

            Me.radDepreciable.Checked = IIf(Me.aplicar_depreciacion_, True, False)
            Me.radNoDepreciable.Checked = IIf(Me.aplicar_depreciacion_, False, True)
            Me.radAlta.Checked = IIf(Me.alta_, True, False)
            Me.radBaja.Checked = IIf(Me.alta_, False, True)
            Me.radParcial.Checked = Me.baja_parcial_
            Me.radTotal.Checked = Me.baja_total_

            Me.txtNumeroSerie.Text = Me.numero_serie_
            Me.txtAsignado.Text = Me.asignado_a_
            Me.txtResponsableArea.Text = Me.responsable_
            Me.txtDestinoDadoBaja.Text = Me.destino_baja_
            Me.txtObservacionesBaja.Text = Me.observaciones_baja_
            Me.txtDescripcionBien.Text = Me.descripcion_bien_
            Me.txtMarca.Text = Me.marca_
            Me.txtModelo.Text = Me.modelo_
            Me.txtModelo.Text = Me.modelo_
            Me.txtOtrasEspecificaciones.Text = Me.otras_especificaciones_
            Me.txtNoCff.Text = Me.num_cff_
            Me.txtCodigo.Text = Me.codigo_
            Me.lblCodigoExplicado.Text = Me.codigo_explicado

            Me.dgvMovimientos.DataSource = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_movimientos', @BIEN=" & Me.id_bien & ", @COMPAÑIA = " & Compañia)
            Me.dgvMovimientos.ReadOnly = True
        Else
            Me.lblComentarios.Visible = False
            Me.txtComentarios.Visible = False

            Me.cmbEmpresa.SelectedValue = -1
            Me.cmbClasificacion.SelectedValue = -1
            Me.cmbAsignacion.SelectedValue = -1
            Me.cmbTipoBien.SelectedValue = -1
            Me.cmbUbicacion.SelectedValue = -1
            Me.cmbMotivoBaja.SelectedValue = -1
            Me.cmbUnidadMedida.SelectedValue = -1
            Me.cmbCondicion.SelectedValue = -1
            Me.cmbDivision.SelectedValue = -1
            Me.cmbDepartamentoArea.SelectedValue = -1
            Me.cmbCentroCostos.SelectedValue = -1
            Me.cmbEstatus.SelectedValue = -1

            Me.dtpAdqicicion.Value = Date.Now
            Me.dtpVencimientoFinanciero.Value = Date.Now
            Me.dtpVencimientoFiscal.Value = Date.Now
            Me.dtpFechaBaja.Value = Date.Now
            Me.dtpFechaCff.Value = Date.Now

            Me.nudPrecioOriginalFinanciero.Value = 0
            Me.nudValorDepreciarFinanciero.Value = 0
            Me.nudVidaUtilFinanciero.Value = 0
            Me.nudDepreciaMensualFinanciero.Value = 0
            Me.nudRemanenteFinanciero.Value = 0
            Me.nudPorcentajeNoDepreFinan.Value = 0
            Me.nudPorcentajeNoDepreFiscal.Value = 0
            Me.nudValorResidualFinanciero.Value = 0
            Me.nudValorResidualFiscal.Value = 0
            Me.nudPrecioOriginalFiscal.Value = 0
            Me.nudValorDepreciarFiscal.Value = 0
            Me.nudVidaUtilFiscal.Value = 0
            Me.nudDepreciaMensualFiscal.Value = 0
            Me.nudRemanenteFiscal.Value = 0
            Me.nudCantidad.Value = 1
            Me.nudValorCff.Value = 0

            Me.radDepreciable.Checked = True
            Me.radNoDepreciable.Checked = False
            Me.radAlta.Checked = True
            Me.radBaja.Checked = False
            Me.radParcial.Checked = False
            Me.radTotal.Checked = False

            Me.txtNumeroSerie.Text = String.Empty
            Me.txtAsignado.Text = String.Empty
            Me.txtResponsableArea.Text = String.Empty
            Me.txtDestinoDadoBaja.Text = "No Aplica"
            Me.txtObservacionesBaja.Text = "No Aplica"
            Me.txtDescripcionBien.Text = String.Empty
            Me.txtMarca.Text = String.Empty
            Me.txtModelo.Text = String.Empty
            Me.txtModelo.Text = String.Empty
            Me.txtOtrasEspecificaciones.Text = String.Empty
            Me.txtNoCff.Text = String.Empty
            Me.txtCodigo.Text = String.Empty
            Me.lblCodigoExplicado.Text = String.Empty
        End If

        If Not Me.accion_.Equals("insert") Then
            Me.calcularAcumulado("financiero")
            Me.calcularAcumulado("fiscal")
        End If

        If Me.accion_.Equals("select") Then
            Me.enabledControls(False)
            Me.btnPrintBien.Enabled = True
        Else
            Me.enabledControls(True)
        End If

        'Estos ya no son editables
        Me.cmbEmpresa.Enabled = False
        Me.cmbClasificacion.Enabled = False
        Me.cmbAsignacion.Enabled = False
        Me.cmbTipoBien.Enabled = False

        If Me.accion_.Equals("insert") Then
            Me.btnPrintBien.Enabled = False
            Me.cmbEmpresa.Enabled = True
            Me.cmbClasificacion.Enabled = True
            Me.cmbAsignacion.Enabled = True
            Me.cmbTipoBien.Enabled = True
        End If

        If Me.accion_.Equals("update") Then
            Me.setearParametrosMovimientos()
        End If
        Iniciando = False
    End Sub

    Private Sub consultar()
        _datos = objEntidad.getData("Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'select', @BIEN=" & Me.id_bien & ", @COMPAÑIA = " & Compañia)
        If _datos.Rows.Count > 0 Then
            Me.codigo_ = _datos.Rows(0).Item("CODIGO")
            Me.codigo_explicado = _datos.Rows(0).Item("CODIGOEXPLICADO")
            Me.estatus_ = _datos.Rows(0).Item("ESTATUS")
            Me.empresa_ = _datos.Rows(0).Item("EMPRESA")
            Me.clasificacion_ = _datos.Rows(0).Item("CLASIFICACION")
            Me.asignacion_ = _datos.Rows(0).Item("ASIGNACION")
            Me.tipo_bien_ = _datos.Rows(0).Item("TIPO_BIEN")
            Me.ubicacion_ = _datos.Rows(0).Item("UBICACION")
            Me.unidad_medida_ = _datos.Rows(0).Item("UNIDAD_MEDIDA")
            Me.condicion_ = _datos.Rows(0).Item("CONDICION")
            Me.centro_costos_ = _datos.Rows(0).Item("CENTRO_COSTO")
            Me.alta_ = _datos.Rows(0).Item("ALTA")
            Me.motivo_baja_ = _datos.Rows(0).Item("MOTIVO_BAJA")
            Me.baja_parcial_ = _datos.Rows(0).Item("BAJA_PARCIAL")
            Me.baja_total_ = _datos.Rows(0).Item("BAJA_TOTAL")
            Me.destino_baja_ = _datos.Rows(0).Item("DESTINO_DADO_BAJA")
            Me.observaciones_baja_ = _datos.Rows(0).Item("OBSERVACIONES_BAJA")
            Me.descripcion_bien_ = _datos.Rows(0).Item("DESCRIPCION_BIEN")
            Me.marca_ = _datos.Rows(0).Item("MARCA")
            Me.modelo_ = _datos.Rows(0).Item("MODELO")
            Me.numero_serie_ = _datos.Rows(0).Item("NUMERO_SERIE")
            Me.otras_especificaciones_ = _datos.Rows(0).Item("OTRAS_ESPECIFICACIONES")
            Me.asignado_a_ = _datos.Rows(0).Item("ASIGNADO")
            Me.division_ = _datos.Rows(0).Item("DIVISION")
            Me.departamento_area_ = _datos.Rows(0).Item("DEPARTAMENTO_AREA")
            Me.fecha_adquisicion_ = _datos.Rows(0).Item("FECHA_ADQUICICION")
            Me.fecha_vencimiento_finan_ = _datos.Rows(0).Item("FECHA_VENCIMIENTO_FINAN")
            Me.precio_original_finan_ = _datos.Rows(0).Item("PRECIO_ORIGINAL_FINAN")
            Me.valor_depreciar_finan_ = _datos.Rows(0).Item("VALOR_DEPRECIAR_FINAN")
            Me.vida_util_finan_ = _datos.Rows(0).Item("VIDA_UTIL_FINAN")
            Me.depreciacion_mensual_finan_ = _datos.Rows(0).Item("DEPRECIACION_MENSUAL_FINAN")
            Me.remanente_finan_ = _datos.Rows(0).Item("REMANENTE_FINAN")
            Me.fecha_vencimiento_fiscal_ = _datos.Rows(0).Item("FECHA_VENCIMIENTO_FISCAL")
            Me.precio_original_fiscal_ = _datos.Rows(0).Item("PRECIO_ORIGINAL_FISCAL")
            Me.valor_depreciar_fiscal_ = _datos.Rows(0).Item("VALOR_DEPRECIAR_FISCAL")
            Me.vida_util_fiscal_ = _datos.Rows(0).Item("VIDA_UTIL_FISCAL")
            Me.depreciacion_mensual_fiscal_ = _datos.Rows(0).Item("DEPRECIACION_MENSUAL_FISCAL")
            Me.remanente_fiscal_ = _datos.Rows(0).Item("REMANENTE_FISCAL")
            Me.aplicar_depreciacion_ = _datos.Rows(0).Item("APLICAR_DEPRECIACION")
            Me.cantidad_ = _datos.Rows(0).Item("CANTIDAD")
            Me.fecha_baja_ = _datos.Rows(0).Item("FECHABAJA")
            Me.porcentaje_finan_ = _datos.Rows(0).Item("PORCENTAJENODEPFINAN")
            Me.porcentaje_fiscal_ = _datos.Rows(0).Item("PORCENTAJENODEPFISCAL")
            Me.valor_residual_finan_ = _datos.Rows(0).Item("VALOR_RESIDUAL_FINAN")
            Me.valor_residual_fiscal_ = _datos.Rows(0).Item("VALOR_RESIDUAL_FISCAL")
            Me.num_cff_ = _datos.Rows(0).Item("NUM_CFF")
            Me.fecha_cff_ = _datos.Rows(0).Item("FECHA_CCF")
            Me.valor_cff_ = _datos.Rows(0).Item("VALOR_CFF")
            Me.responsable_ = _datos.Rows(0).Item("RESPONSABLE")

        End If
    End Sub

    Function validarCambios() As Boolean
        Dim result_ As Boolean = False

        '==================================================='
        If Not Me.cmbEmpresa.SelectedValue = Me.empresa_ Then
            result_ = True
        End If
        If Not Me.cmbClasificacion.SelectedValue = Me.clasificacion_ Then
            result_ = True
        End If
        If Not Me.cmbAsignacion.SelectedValue = Me.asignacion_ Then
            result_ = True
        End If
        If Not Me.cmbTipoBien.SelectedValue = Me.tipo_bien_ Then
            result_ = True
        End If
        If Not Me.cmbUbicacion.SelectedValue = Me.ubicacion_ Then
            result_ = True
        End If
        If Not Me.cmbMotivoBaja.SelectedValue = Me.motivo_baja_ Then
            result_ = True
        End If
        If Not Me.cmbUnidadMedida.SelectedValue = Me.unidad_medida_ Then
            result_ = True
        End If
        If Not Me.cmbCondicion.SelectedValue = Me.condicion_ Then
            result_ = True
        End If
        If Not Me.cmbDivision.SelectedValue = Me.division_ Then
            result_ = True
        End If
        If Not Me.cmbDepartamentoArea.SelectedValue = Me.departamento_area_ Then
            result_ = True
        End If
        If Not Me.cmbCentroCostos.SelectedValue = Me.centro_costos_ Then
            result_ = True
        End If
        If Not Me.cmbEstatus.SelectedValue = Me.estatus_ Then
            result_ = True
        End If
        '==================================================='
        If Not Me.dtpAdqicicion.Value = Me.fecha_adquisicion_ Then
            result_ = True
        End If
        If Not Me.dtpVencimientoFinanciero.Value = Me.fecha_vencimiento_finan_ Then
            result_ = False
        End If
        If Not Me.dtpVencimientoFiscal.Value = Me.fecha_vencimiento_fiscal_ Then
            result_ = True
        End If
        If Not Me.dtpFechaBaja.Value = Me.fecha_baja_ Then
            result_ = True
        End If
        If Not Me.dtpFechaCff.Value = Me.fecha_cff_ Then
            result_ = True
        End If
        '==================================================='
        If Not Math.Round(Me.nudPrecioOriginalFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.precio_original_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudValorDepreciarFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.valor_depreciar_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudVidaUtilFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.vida_util_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudDepreciaMensualFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.depreciacion_mensual_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudRemanenteFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.remanente_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudPorcentajeNoDepreFinan.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.porcentaje_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudPorcentajeNoDepreFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.porcentaje_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudValorResidualFinanciero.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.valor_residual_finan_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudValorResidualFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.valor_residual_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudPrecioOriginalFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.precio_original_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudValorDepreciarFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.valor_depreciar_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudVidaUtilFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.vida_util_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudDepreciaMensualFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.depreciacion_mensual_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudRemanenteFiscal.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.remanente_fiscal_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudCantidad.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.cantidad_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        If Not Math.Round(Me.nudValorCff.Value, 2, MidpointRounding.AwayFromZero) = Math.Round(Me.valor_cff_, 2, MidpointRounding.AwayFromZero) Then
            result_ = True
        End If
        '==================================================='
        If Not Me.radDepreciable.Checked = IIf(Me.aplicar_depreciacion_, True, False) Then
            result_ = True
        End If
        If Not Me.radNoDepreciable.Checked = IIf(Me.aplicar_depreciacion_, False, True) Then
            result_ = True
        End If
        If Not Me.radAlta.Checked = IIf(Me.alta_, True, False) Then
            result_ = True
        End If
        If Not Me.radBaja.Checked = IIf(Me.alta_, False, True) Then
            result_ = True
        End If
        If Not Me.radParcial.Checked = Me.baja_parcial_ Then
            result_ = True
        End If
        If Not Me.radTotal.Checked = Me.baja_total_ Then
            result_ = True
        End If
        '==================================================='
        If Not Me.txtNumeroSerie.Text = Me.numero_serie_ Then
            result_ = True
        End If
        If Not Me.txtAsignado.Text = Me.asignado_a_ Then
            result_ = True
        End If
        If Not Me.txtResponsableArea.Text = Me.responsable_ Then
            result_ = True
        End If
        If Not Me.txtDestinoDadoBaja.Text = Me.destino_baja_ Then
            result_ = True
        End If
        If Not Me.txtObservacionesBaja.Text = Me.observaciones_baja_ Then
            result_ = True
        End If
        If Not Me.txtDescripcionBien.Text = Me.descripcion_bien_ Then
            result_ = True
        End If
        If Not Me.txtMarca.Text = Me.marca_ Then
            result_ = True
        End If
        If Not Me.txtModelo.Text = Me.modelo_ Then
            result_ = True
        End If
        If Not Me.txtModelo.Text = Me.modelo_ Then
            result_ = True
        End If
        If Not Me.txtOtrasEspecificaciones.Text = Me.otras_especificaciones_ Then
            result_ = True
        End If
        If Not Me.txtNoCff.Text = Me.num_cff_ Then
            result_ = True
        End If
        If Not Me.txtCodigo.Text = Me.codigo_ Then
            result_ = True
        End If

        Return result_
    End Function

    Private Sub cmbClasificacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClasificacion.SelectedIndexChanged
        If Not Iniciando Then
            cargando_ = True
            If Me.cmbClasificacion.SelectedValue = 0 Then
                Me.cmbTipoBien.DataSource = Nothing
            Else
                objEntidad.fillComboBox(Me.cmbTipoBien, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_tpobien', @COMPAÑIA = " & Compañia & ",@CLASIFICACION=" & Me.cmbClasificacion.SelectedValue, "TIPO_BIEN", "DESCRPCION")
            End If
            cargando_ = False
        End If
    End Sub

    Private Sub nudValorDepreciarFinanciero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudValorDepreciarFinanciero.Leave
        Me.nudValorDepreciarFiscal.Value = Me.nudValorDepreciarFinanciero.Value
        Me.nudPrecioOriginalFiscal.Value = Me.nudValorDepreciarFinanciero.Value
    End Sub

    Private Sub calcularAcumulado(ByVal tipo_ As String)
        Select Case tipo_
            Case "financiero"
                If nudVidaUtilFinanciero.Value > 0 And radDepreciable.Checked And dtpVencimientoFinanciero.Value >= Now Then
                    If Me.dtpAdqicicion.Value < Now Then
                        Dim dias_pasados_ As Integer = Math.Abs(DateDiff(DateInterval.Day, Now, Me.dtpAdqicicion.Value))
                        Dim dias_total_ As Integer = Math.Abs(DateDiff(DateInterval.Day, Me.dtpAdqicicion.Value, Me.dtpVencimientoFinanciero.Value))
                        Dim valor_dia_ As Decimal = (IIf(Me.nudValorResidualFinanciero.Value > 0, Me.nudValorResidualFinanciero.Value, Me.nudPrecioOriginalFinanciero.Value) / dias_total_)
                        Me.nudRemanenteFinanciero.Value = ((dias_total_ * valor_dia_) - (dias_pasados_ * valor_dia_))
                    End If
                End If
            Case "fiscal"
                If nudVidaUtilFiscal.Value > 0 And radDepreciable.Checked And dtpVencimientoFiscal.Value >= Now Then
                    If Me.dtpAdqicicion.Value < Now Then
                        Dim dias_pasados_ As Integer = Math.Abs(DateDiff(DateInterval.Day, Now, Me.dtpAdqicicion.Value))
                        Dim dias_total_ As Integer = Math.Abs(DateDiff(DateInterval.Day, Me.dtpAdqicicion.Value, Me.dtpVencimientoFiscal.Value))
                        Dim valor_dia_ As Decimal = (IIf(Me.nudValorResidualFiscal.Value > 0, Me.nudValorResidualFiscal.Value, Me.nudPrecioOriginalFiscal.Value) / dias_total_)
                        Me.nudRemanenteFiscal.Value = ((dias_total_ * valor_dia_) - (dias_pasados_ * valor_dia_))
                    End If
                End If
        End Select
    End Sub

    Private Sub setTitle()
        Me.Text = String.Empty
        Select Case Me.accion_
            Case "insert"
                Me.Text = "Depreciación Activo Fijo  [Nuevo Registro]"
                Me.btnGuardar.Text = "&Guardar"
                enabledControls(True)
            Case "update"
                Me.Text = "Depreciación Activo Fijo  [Modificación]"
                Me.btnGuardar.Text = "&Guardar"
                enabledControls(True)
            Case "select"
                Me.Text = "Depreciación Activo Fijo  [Consulta]"
                Me.btnGuardar.Text = "&Aceptar"
                enabledControls(False)
            Case "delete"
                Me.Text = "Depreciación Activo Fijo  [Eliminación]"
                Me.btnGuardar.Text = "&Eliminar"
                enabledControls(False)
        End Select
    End Sub

    Private Sub enabledControls(ByVal val_ As Boolean)
        If val_ Then
            Me.cmbEmpresa.Enabled = True
            Me.cmbClasificacion.Enabled = True
            Me.cmbAsignacion.Enabled = True
            Me.cmbTipoBien.Enabled = True
            Me.cmbUbicacion.Enabled = True
            Me.cmbMotivoBaja.Enabled = True
            Me.cmbUnidadMedida.Enabled = True
            Me.cmbCondicion.Enabled = True
            Me.cmbDivision.Enabled = True
            Me.cmbDepartamentoArea.Enabled = True
            Me.cmbCentroCostos.Enabled = True
            Me.cmbEstatus.Enabled = True
            Me.dtpUserCreacionFecha.Enabled = True
            Me.dtpAdqicicion.Enabled = True
            Me.dtpVencimientoFinanciero.Enabled = True
            Me.dtpVencimientoFiscal.Enabled = True
            Me.dtpFechaBaja.Enabled = True
            Me.dtpFechaCff.Enabled = True
            Me.nudPrecioOriginalFinanciero.Enabled = True
            Me.nudValorDepreciarFinanciero.Enabled = True
            Me.nudVidaUtilFinanciero.Enabled = True
            Me.nudDepreciaMensualFinanciero.Enabled = True
            Me.nudRemanenteFinanciero.Enabled = True
            Me.nudPorcentajeNoDepreFinan.Enabled = True
            Me.nudPorcentajeNoDepreFiscal.Enabled = True
            Me.nudValorResidualFinanciero.Enabled = True
            Me.nudValorResidualFiscal.Enabled = True
            Me.nudPrecioOriginalFiscal.Enabled = True
            Me.nudValorDepreciarFiscal.Enabled = True
            Me.nudVidaUtilFiscal.Enabled = True
            Me.nudDepreciaMensualFiscal.Enabled = True
            Me.nudRemanenteFiscal.Enabled = True
            Me.nudCantidad.Enabled = True
            Me.nudValorCff.Enabled = True
            Me.radDepreciable.Enabled = True
            Me.radNoDepreciable.Enabled = True
            Me.radAlta.Enabled = True
            Me.radBaja.Enabled = True
            Me.radParcial.Enabled = True
            Me.radTotal.Enabled = True
            Me.txtNumeroSerie.Enabled = True
            Me.txtAsignado.Enabled = True
            Me.txtResponsableArea.Enabled = True
            Me.txtDestinoDadoBaja.Enabled = True
            Me.txtObservacionesBaja.Enabled = True
            Me.txtDescripcionBien.Enabled = True
            Me.txtMarca.Enabled = True
            Me.txtModelo.Enabled = True
            Me.txtModelo.Enabled = True
            Me.txtOtrasEspecificaciones.Enabled = True
            Me.txtNoCff.Enabled = True
            Me.txtCodigo.Enabled = True

            Me.dgvCuentasContables.ReadOnly = False
        Else
            Me.cmbEmpresa.Enabled = False
            Me.cmbClasificacion.Enabled = False
            Me.cmbAsignacion.Enabled = False
            Me.cmbTipoBien.Enabled = False
            Me.cmbUbicacion.Enabled = False
            Me.cmbMotivoBaja.Enabled = False
            Me.cmbUnidadMedida.Enabled = False
            Me.cmbCondicion.Enabled = False
            Me.cmbDivision.Enabled = False
            Me.cmbDepartamentoArea.Enabled = False
            Me.cmbCentroCostos.Enabled = False
            Me.cmbEstatus.Enabled = False
            Me.dtpUserCreacionFecha.Enabled = True
            Me.dtpAdqicicion.Enabled = False
            Me.dtpVencimientoFinanciero.Enabled = False
            Me.dtpVencimientoFiscal.Enabled = False
            Me.dtpFechaBaja.Enabled = False
            Me.dtpFechaCff.Enabled = False
            Me.nudPrecioOriginalFinanciero.Enabled = False
            Me.nudValorDepreciarFinanciero.Enabled = False
            Me.nudVidaUtilFinanciero.Enabled = False
            Me.nudDepreciaMensualFinanciero.Enabled = False
            Me.nudRemanenteFinanciero.Enabled = False
            Me.nudPorcentajeNoDepreFinan.Enabled = False
            Me.nudPorcentajeNoDepreFiscal.Enabled = False
            Me.nudValorResidualFinanciero.Enabled = False
            Me.nudValorResidualFiscal.Enabled = False
            Me.nudPrecioOriginalFiscal.Enabled = False
            Me.nudValorDepreciarFiscal.Enabled = False
            Me.nudVidaUtilFiscal.Enabled = False
            Me.nudDepreciaMensualFiscal.Enabled = False
            Me.nudRemanenteFiscal.Enabled = False
            Me.nudCantidad.Enabled = False
            Me.nudValorCff.Enabled = False
            Me.radDepreciable.Enabled = False
            Me.radNoDepreciable.Enabled = False
            Me.radAlta.Enabled = False
            Me.radBaja.Enabled = False
            Me.radParcial.Enabled = False
            Me.radTotal.Enabled = False
            Me.txtNumeroSerie.Enabled = False
            Me.txtAsignado.Enabled = False
            Me.txtResponsableArea.Enabled = False
            Me.txtDestinoDadoBaja.Enabled = False
            Me.txtObservacionesBaja.Enabled = False
            Me.txtDescripcionBien.Enabled = False
            Me.txtMarca.Enabled = False
            Me.txtModelo.Enabled = False
            Me.txtModelo.Enabled = False
            Me.txtOtrasEspecificaciones.Enabled = False
            Me.txtNoCff.Enabled = False
            Me.txtCodigo.Enabled = False

            Me.dgvCuentasContables.ReadOnly = True
        End If

        Me.txtCodigo.Enabled = False
    End Sub

    Function validFields() As Boolean
        Dim result_ As Boolean = False

        If txtCodigo.Text.Length > 0 And nudPrecioOriginalFinanciero.Value > 0 And nudValorDepreciarFinanciero.Value > 0 And nudVidaUtilFinanciero.Value > 0 And nudDepreciaMensualFinanciero.Value > 0 And txtAsignado.Text.Length > 0 And Me.txtResponsableArea.Text.Length > 0 And Me.cmbEmpresa.SelectedValue > 0 And Me.cmbClasificacion.SelectedValue > 0 And Me.cmbAsignacion.SelectedValue > 0 And Me.cmbTipoBien.SelectedValue > 0 And Me.cmbUbicacion.SelectedValue > 0 And Me.cmbUnidadMedida.SelectedValue > 0 And Me.cmbCondicion.SelectedValue > 0 And Me.cmbDivision.SelectedValue > 0 And Me.cmbDepartamentoArea.SelectedValue > 0 And Me.cmbCentroCostos.SelectedValue > 0 And Me.cmbEstatus.SelectedValue > 0 And Me.txtDescripcionBien.Text.Length > 0 Then
            Me.btnGuardar.Enabled = False
            errP.SetError(txtCodigo, "")
            errP.SetError(nudPrecioOriginalFinanciero, "")
            errP.SetError(nudValorDepreciarFinanciero, "")
            errP.SetError(nudVidaUtilFinanciero, "")
            errP.SetError(nudDepreciaMensualFinanciero, "")
            errP.SetError(txtAsignado, "")
            errP.SetError(txtDestinoDadoBaja, "")

            errP.SetError(Me.cmbEmpresa, "")
            errP.SetError(Me.cmbClasificacion, "")
            errP.SetError(Me.cmbAsignacion, "")
            errP.SetError(Me.cmbTipoBien, "")
            errP.SetError(Me.cmbUbicacion, "")
            errP.SetError(Me.cmbUnidadMedida, "")
            errP.SetError(Me.cmbCondicion, "")
            errP.SetError(Me.cmbDivision, "")
            errP.SetError(Me.cmbDepartamentoArea, "")
            errP.SetError(Me.cmbCentroCostos, "")
            errP.SetError(Me.cmbEstatus, "")

            errP.SetError(nudPrecioOriginalFiscal, "")
            errP.SetError(nudValorDepreciarFiscal, "")
            errP.SetError(nudVidaUtilFiscal, "")
            errP.SetError(nudDepreciaMensualFiscal, "")
            errP.SetError(dtpVencimientoFiscal, "")
            errP.SetError(nudRemanenteFiscal, "")
            errP.SetError(nudRemanenteFiscal, "")

            errP.SetError(Me.txtDescripcionBien, "")
            errP.SetError(Me.txtCodigo, "")

            result_ = True
        Else
            If Not Me.cmbEmpresa.SelectedValue > 0 Then
                errP.SetError(Me.cmbEmpresa, "Requerido")
            End If
            If Not Me.cmbClasificacion.SelectedValue > 0 Then
                errP.SetError(Me.cmbClasificacion, "Requerido")
            End If
            If Not Me.cmbAsignacion.SelectedValue > 0 Then
                errP.SetError(Me.cmbAsignacion, "Requerido")
            End If
            If Not Me.cmbTipoBien.SelectedValue > 0 Then
                errP.SetError(Me.cmbTipoBien, "Requerido")
            End If
            If Not Me.cmbUbicacion.SelectedValue > 0 Then
                errP.SetError(Me.cmbUbicacion, "Requerido")
            End If
            If Not Me.cmbUnidadMedida.SelectedValue > 0 Then
                errP.SetError(Me.cmbUnidadMedida, "Requerido")
            End If
            If Not Me.cmbCondicion.SelectedValue > 0 Then
                errP.SetError(Me.cmbCondicion, "Requerido")
            End If
            If Not Me.cmbDivision.SelectedValue > 0 Then
                errP.SetError(Me.cmbDivision, "Requerido")
            End If
            If Not Me.cmbDepartamentoArea.SelectedValue > 0 Then
                errP.SetError(Me.cmbDepartamentoArea, "Requerido")
            End If
            If Not Me.cmbCentroCostos.SelectedValue > 0 Then
                errP.SetError(Me.cmbCentroCostos, "Requerido")
            End If
            If Not Me.cmbEstatus.SelectedValue > 0 Then
                errP.SetError(Me.cmbEstatus, "Requerido")
            End If
            If Not txtCodigo.Text.Length > 0 Then
                errP.SetError(txtCodigo, "Requerido")
            End If
            If Not nudPrecioOriginalFinanciero.Value > 0 Then
                errP.SetError(nudPrecioOriginalFinanciero, "Requerido")
            End If
            If Not nudValorDepreciarFinanciero.Value > 0 Then
                errP.SetError(nudValorDepreciarFinanciero, "Requerido")
            End If
            If Not nudVidaUtilFinanciero.Value > 0 Then
                errP.SetError(nudVidaUtilFinanciero, "Requerido")
            End If
            If Not nudDepreciaMensualFinanciero.Value > 0 Then
                errP.SetError(nudDepreciaMensualFinanciero, "Requerido")
            End If
            If Not txtAsignado.Text.Length > 0 Then
                errP.SetError(txtAsignado, "Requerido")
            End If
            If Not txtDestinoDadoBaja.Text.Length > 0 Then
                errP.SetError(txtDestinoDadoBaja, "Requerido")
            End If

            If Not Me.txtDescripcionBien.Text.Length > 0 Then
                errP.SetError(Me.txtDescripcionBien, "Requerido")
            End If
            If Not Me.txtCodigo.Text.Length > 0 Then
                errP.SetError(Me.txtCodigo, "Requerido")
            End If

            result_ = False
        End If

        Return result_
    End Function

    Private Sub nudValorResidualFiscal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudValorResidualFiscal.Leave
        If Me.nudValorResidualFiscal.Value > 0 Then
            Me.nudValorDepreciarFiscal.Value = Me.nudValorResidualFiscal.Value
        End If
    End Sub

    Private Sub cmbTipoBien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoBien.SelectedIndexChanged
        If Not Iniciando And Not cargando_ Then
            Me.generarCodigo()
        Else
            Me.txtCodigo.Text = String.Empty
            Me.lblCodigoExplicado.Text = String.Empty
        End If
    End Sub

    Private Sub generarCodigo()
        If Me.accion_.Equals("insert") Then
            If Me.cmbClasificacion.SelectedValue > 0 And Me.cmbEmpresa.SelectedValue > 0 And Me.cmbAsignacion.SelectedValue > 0 And cmbTipoBien.SelectedValue > 0 Then
                Dim _correla As New DataTable
                _correla = objEntidad.getData("SELECT ISNULL((SELECT COUNT(*) FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIEN WHERE COMPAÑIA = " & Compañia & " AND ASIGNACION = " & Me.cmbAsignacion.SelectedValue & " AND TIPO_BIEN = " & Me.cmbTipoBien.SelectedValue & " GROUP BY ASIGNACION,TIPO_BIEN ),0) + 1 As Correlativo")

                If _correla.Rows.Count > 0 Then
                    Me.txtCodigo.Text = Me.cmbEmpresa.SelectedValue.ToString().PadLeft(2, "0") & Me.cmbClasificacion.SelectedValue.ToString().PadLeft(2, "0") & Me.cmbAsignacion.SelectedValue.ToString().PadLeft(2, "0") & Me.cmbTipoBien.SelectedValue.ToString().PadLeft(3, "0") & _correla.Rows(0).Item("Correlativo").ToString().PadLeft(3, "0")
                    Me.lblCodigoExplicado.Text = "Empresa:[" & Me.cmbEmpresa.SelectedValue.ToString().PadLeft(2, "0") & "] - Clasificación:[" & Me.cmbClasificacion.SelectedValue.ToString().PadLeft(2, "0") & "] - Asignación:[" & Me.cmbAsignacion.SelectedValue.ToString().PadLeft(2, "0") & "] - Tipo:[" & Me.cmbTipoBien.SelectedValue.ToString().PadLeft(3, "0") & "] - Correlativo:[" & _correla.Rows(0).Item("Correlativo").ToString().PadLeft(3, "0") & "]"
                End If
            End If
        End If
    End Sub

    Private Sub cmbAsignacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAsignacion.SelectedIndexChanged
        If Not Iniciando Then
            Me.generarCodigo()
        Else
            Me.txtCodigo.Text = String.Empty
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If Not Iniciando Then
            Me.generarCodigo()
        Else
            Me.txtCodigo.Text = String.Empty
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.accion_.Equals("select") Then
            Me.Close()
        Else
            If Me.accion_.Equals("update") And Not Me.txtComentarios.Text.Length > 0 Then
                MessageBox.Show("Agrege un comentario que explique por que modifico el registro, en la casilla Comentario del Movimiento.")
                Return
            End If

            Dim statement_ As String = String.Empty
            Dim validar_ As Boolean

            If radDepreciable.Checked Then
                validar_ = Me.validFields()
            Else
                validar_ = True
            End If

            If validar_ Then
                If Me.presistir(accion_) Then
                    MsgBox("Operación Exitosa", MsgBoxStyle.Information, "Contabilidad Activo Fijo")
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Function getDataFromGrid(ByVal _id As Integer) As String
        Dim i As Integer = 0
        _porcentaje = 0
        Dim _qry As String = String.Empty
        For _idx As Integer = 0 To dgvCuentasContables.Rows.Count - 2
            _qry = _qry & "INSERT INTO dbo.CONTABILIDAD_ACTIVO_FIJO_CUENTACONTABLE (BIEN,CUENTACONTABLE,PORCENTAGE_ASIGNADO, CUENTAREAL)VALUES(" & _id & ", '" & dgvCuentasContables.Item(3, _idx).Value.ToString & "', " & dgvCuentasContables.Item(4, _idx).Value.ToString & ", " & dgvCuentasContables.Item(5, _idx).Value.ToString() & "); "
            _porcentaje += dgvCuentasContables.Item(4, _idx).Value
        Next
        Return _qry
    End Function

    Function presistir(ByVal _accion As String) As Boolean
        Dim _exito As Boolean = False
        If Me.txtCodigo.Text.Length > 0 Then
            Dim Conexion_ As New SqlConnection(CnnStrBldr.ConnectionString)
            Conexion_.Open()
            Dim _id As Integer = 0
            Dim _transaction As SqlTransaction
            _transaction = Conexion_.BeginTransaction("add_depresiacion")

            Try
                Dim Comando_ As New SqlCommand
                Comando_.Connection = Conexion_
                Comando_.Transaction = _transaction

                Me.setearParametros(_accion)

                Select Case _accion
                    Case "insert"
                        Comando_.CommandText = _params & " Select @@Identity"
                        _id = CInt(Comando_.ExecuteScalar())
                        _exito = True
                        If Me.getDataFromGrid(_id).Trim().Length > 0 Then
                            Comando_.CommandText = Me.getDataFromGrid(_id)
                            Comando_.ExecuteNonQuery()

                            If Me._porcentaje <> 100 Then
                                Me.btnGuardar.Enabled = True
                                _transaction.Rollback()
                                MsgBox("El porcentaje de asignación de las cuentas debe sumar el 100%", MsgBoxStyle.Critical, "Error")
                            Else
                                Me.btnGuardar.Enabled = False
                                _exito = True
                            End If
                        End If

                        Me.btnGuardar.Enabled = False
                    Case "update"

                        'Si se hizo algun cambio se genera un movimiento
                        If Me.validarCambios() Then
                            _params_movimiento &= ",@COMENTARIOS='" & Me.txtComentarios.Text & "'"
                            Comando_.CommandText = _params_movimiento
                            Comando_.ExecuteNonQuery()
                        End If

                        Comando_.CommandText = "DELETE FROM dbo.CONTABILIDAD_ACTIVO_FIJO_CUENTACONTABLE WHERE BIEN=" & id_bien
                        Comando_.ExecuteNonQuery()
                        Comando_.CommandText = _params
                        Comando_.ExecuteNonQuery()
                        _exito = True
                        If Me.getDataFromGrid(id_bien).Trim().Length > 0 Then
                            Comando_.CommandText = Me.getDataFromGrid(id_bien)
                            Comando_.ExecuteNonQuery()

                            If Me._porcentaje <> 100 Then
                                Me.btnGuardar.Enabled = True
                                _transaction.Rollback()
                                _exito = False
                                MsgBox("El porcentaje de asignación de las cuentas debe sumar el 100%", MsgBoxStyle.Critical, "Error")
                            Else
                                _exito = True
                            End If
                        End If
                    Case "delete"
                        'Validar si no tiene movimientos
                        Comando_.CommandText = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA  = 'borrar_bien', @COMPAÑIA=" & Compañia & ", @BIEN=" & id_bien
                        Comando_.ExecuteNonQuery()
                        'Comando_.CommandText = "DELETE FROM dbo.CONTABILIDAD_ACTIVO_FIJO_BIENES WHERE COMPAÑIA= " & Compañia & " AND BIEN=" & id_bien
                        'Comando_.ExecuteNonQuery()
                        _exito = True
                        Me.btnGuardar.Enabled = True
                End Select

                If _exito Then
                    _transaction.Commit()
                    Conexion_.Close()    
                End If

            Catch ex As SqlException
                _transaction.Rollback()
                _exito = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox("No se ha creado el codigo del activo fijo..", MsgBoxStyle.Critical, "Error")
        End If

        Return _exito
    End Function

    Public Sub setearParametros(ByVal _bandera)
        _params = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS "
        _params &= " @BIEN=" & IIf(String.IsNullOrEmpty(id_bien), "NULL", Me.id_bien)
        _params &= ",@BANDERA='" & _bandera & "'"
        _params &= ",@COMPAÑIA=" & Compañia
        _params &= ",@CODIGO=" & IIf(Me.txtCodigo.Text.Length > 0, "'" & Me.txtCodigo.Text & "'", "NULL")
        _params &= ",@CODIGOEXPLICADO=" & IIf(Me.lblCodigoExplicado.Text.Length > 0, "'" & Me.lblCodigoExplicado.Text & "'", "NULL")
        _params &= ",@EMPRESA=" & IIf(Me.cmbEmpresa.SelectedValue = 0, "NULL", Me.cmbEmpresa.SelectedValue)
        _params &= ",@CLASIFICACION=" & IIf(Me.cmbClasificacion.SelectedValue = 0, "NULL", Me.cmbClasificacion.SelectedValue)
        _params &= ",@ASIGNACION=" & IIf(Me.cmbAsignacion.SelectedValue = 0, "NULL", Me.cmbAsignacion.SelectedValue)
        _params &= ",@TIPO_BIEN=" & IIf(Me.cmbTipoBien.SelectedValue = 0, "NULL", Me.cmbTipoBien.SelectedValue)
        _params &= ",@ESTATUS=" & IIf(Me.cmbEstatus.SelectedValue = 0, "NULL", Me.cmbEstatus.SelectedValue)
        _params &= ",@UBICACION=" & IIf(Me.cmbUbicacion.SelectedValue = 0, "NULL", Me.cmbUbicacion.SelectedValue)
        _params &= ",@UNIDAD_MEDIDA=" & IIf(Me.cmbUnidadMedida.SelectedValue = 0, "NULL", Me.cmbUnidadMedida.SelectedValue)
        _params &= ",@CONDICION=" & IIf(Me.cmbCondicion.SelectedValue = 0, "NULL", Me.cmbCondicion.SelectedValue)
        _params &= ",@CENTRO_COSTO=" & IIf(Me.cmbCentroCostos.SelectedValue = 0, "NULL", Me.cmbCentroCostos.SelectedValue)
        _params &= ",@ALTA=" & IIf(Me.radAlta.Checked, 1, 0)
        _params &= ",@MOTIVO_BAJA=" & IIf(Me.cmbMotivoBaja.SelectedValue = 0, "NULL", Me.cmbMotivoBaja.SelectedValue)
        _params &= ",@BAJA_PARCIAL=" & IIf(Me.radParcial.Checked, 1, 0)
        _params &= ",@BAJA_TOTAL=" & IIf(Me.radTotal.Checked, 1, 0)
        _params &= ",@MARCA=" & IIf(Me.txtMarca.Text.Length > 0, "'" & Me.txtMarca.Text & "'", "NULL")
        _params &= ",@MODELO=" & IIf(Me.txtModelo.Text.Length > 0, "'" & Me.txtModelo.Text & "'", "NULL")
        _params &= ",@NUMERO_SERIE=" & IIf(Me.txtNumeroSerie.Text.Length > 0, "'" & Me.txtNumeroSerie.Text & "'", "NULL")
        _params &= ",@OTRAS_ESPECIFICACIONES=" & IIf(Me.txtOtrasEspecificaciones.Text.Length > 0, "'" & Me.txtOtrasEspecificaciones.Text & "'", "NULL")
        _params &= ",@ASIGNADO=" & IIf(Me.txtAsignado.Text.Length > 0, "'" & Me.txtAsignado.Text & "'", "NULL")
        _params &= ",@RESPONSABLE=" & IIf(Me.txtResponsableArea.Text.Length > 0, "'" & Me.txtResponsableArea.Text & "'", "NULL")
        _params &= ",@DIVISION=" & IIf(Me.cmbDivision.SelectedValue = 0, "NULL", Me.cmbDivision.SelectedValue)
        _params &= ",@DEPARTAMENTO_AREA=" & IIf(Me.cmbDepartamentoArea.SelectedValue = 0, "NULL", Me.cmbDepartamentoArea.SelectedValue)
        _params &= ",@FECHA_ADQUICICION='" & Me.dtpAdqicicion.Value.ToShortDateString() & "'"
        _params &= ",@FECHA_VENCIMIENTO_FINAN='" & dtpVencimientoFinanciero.Value.ToShortDateString() & "'"
        _params &= ",@DESTINO_DADO_BAJA=" & IIf(Me.txtDestinoDadoBaja.Text.Length > 0, "'" & Me.txtDestinoDadoBaja.Text & "'", "NULL")
        _params &= ",@OBSERVACIONES_BAJA=" & IIf(Me.txtObservacionesBaja.Text.Length > 0, "'" & Me.txtObservacionesBaja.Text & "'", "NULL")
        _params &= ",@DESCRIPCION_BIEN=" & IIf(Me.txtDescripcionBien.Text.Length > 0, "'" & Me.txtDescripcionBien.Text & "'", "NULL")
        _params &= ",@PRECIO_ORIGINAL_FINAN=" & nudPrecioOriginalFinanciero.Value
        _params &= ",@VALOR_DEPRECIAR_FINAN=" & nudValorDepreciarFinanciero.Value
        _params &= ",@VIDA_UTIL_FINAN=" & nudVidaUtilFinanciero.Value
        _params &= ",@DEPRECIACION_MENSUAL_FINAN=" & nudDepreciaMensualFinanciero.Value
        _params &= ",@REMANENTE_FINAN=" & nudRemanenteFinanciero.Value
        _params &= ",@FECHA_VENCIMIENTO_FISCAL='" & dtpVencimientoFiscal.Value.ToShortDateString() & "'"
        _params &= ",@PRECIO_ORIGINAL_FISCAL=" & nudPrecioOriginalFiscal.Value
        _params &= ",@VALOR_DEPRECIAR_FISCAL=" & Me.nudValorDepreciarFiscal.Value
        _params &= ",@VIDA_UTIL_FISCAL=" & nudVidaUtilFiscal.Value
        _params &= ",@DEPRECIACION_MENSUAL_FISCAL=" & nudDepreciaMensualFiscal.Value
        _params &= ",@REMANENTE_FISCAL=" & nudRemanenteFiscal.Value
        _params &= ",@USUARIO_CREACION='" & Usuario & "'"
        _params &= ",@USUARIO_EDICION='" & Usuario & "'"
        _params &= ",@APLICAR_DEPRECIACION=" & IIf(Me.radDepreciable.Checked, 1, 0)
        _params &= ",@CANTIDAD=" & Me.nudCantidad.Value
        _params &= ",@FECHABAJA='" & Me.dtpFechaBaja.Value.ToShortDateString() & "'"
        _params &= ",@PORCENTAJENODEPFINAN=" & nudPorcentajeNoDepreFinan.Value
        _params &= ",@PORCENTAJENODEPFISCAL=" & Me.nudPorcentajeNoDepreFiscal.Value
        _params &= ",@VALOR_RESIDUAL_FINAN=" & nudValorResidualFinanciero.Value
        _params &= ",@VALOR_RESIDUAL_FISCAL=" & nudValorResidualFiscal.Value
        _params &= ",@NUM_CFF=" & IIf(Me.txtNoCff.Text.Length > 0, "'" & Me.txtNoCff.Text & "'", "NULL")
        _params &= ",@FECHA_CCF='" & Me.dtpFechaCff.Value.ToShortDateString() & "'"
        _params &= ",@VALOR_CFF=" & IIf(Me.nudValorCff.Value > 0, "'" & Me.nudValorCff.Value & "'", "NULL")        
    End Sub

    Public Sub setearParametrosMovimientos()
        _params_movimiento = "Exec dbo.SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS "
        _params_movimiento &= " @BIEN=" & IIf(String.IsNullOrEmpty(id_bien), "NULL", Me.id_bien)
        _params_movimiento &= ",@BANDERA='movimiento'"
        _params_movimiento &= ",@COMPAÑIA=" & Compañia
        _params_movimiento &= ",@CODIGO=" & IIf(Me.txtCodigo.Text.Length > 0, "'" & Me.txtCodigo.Text & "'", "NULL")
        _params_movimiento &= ",@CODIGOEXPLICADO=" & IIf(Me.lblCodigoExplicado.Text.Length > 0, "'" & Me.lblCodigoExplicado.Text & "'", "NULL")
        _params_movimiento &= ",@EMPRESA=" & IIf(Me.cmbEmpresa.SelectedValue = 0, "NULL", Me.cmbEmpresa.SelectedValue)
        _params_movimiento &= ",@CLASIFICACION=" & IIf(Me.cmbClasificacion.SelectedValue = 0, "NULL", Me.cmbClasificacion.SelectedValue)
        _params_movimiento &= ",@ASIGNACION=" & IIf(Me.cmbAsignacion.SelectedValue = 0, "NULL", Me.cmbAsignacion.SelectedValue)
        _params_movimiento &= ",@TIPO_BIEN=" & IIf(Me.cmbTipoBien.SelectedValue = 0, "NULL", Me.cmbTipoBien.SelectedValue)
        _params_movimiento &= ",@ESTATUS=" & IIf(Me.cmbEstatus.SelectedValue = 0, "NULL", Me.cmbEstatus.SelectedValue)
        _params_movimiento &= ",@UBICACION=" & IIf(Me.cmbUbicacion.SelectedValue = 0, "NULL", Me.cmbUbicacion.SelectedValue)
        _params_movimiento &= ",@UNIDAD_MEDIDA=" & IIf(Me.cmbUnidadMedida.SelectedValue = 0, "NULL", Me.cmbUnidadMedida.SelectedValue)
        _params_movimiento &= ",@CONDICION=" & IIf(Me.cmbCondicion.SelectedValue = 0, "NULL", Me.cmbCondicion.SelectedValue)
        _params_movimiento &= ",@CENTRO_COSTO=" & IIf(Me.cmbCentroCostos.SelectedValue = 0, "NULL", Me.cmbCentroCostos.SelectedValue)
        _params_movimiento &= ",@ALTA=" & IIf(Me.radAlta.Checked, 1, 0)
        _params_movimiento &= ",@MOTIVO_BAJA=" & IIf(Me.cmbMotivoBaja.SelectedValue = 0, "NULL", Me.cmbMotivoBaja.SelectedValue)
        _params_movimiento &= ",@BAJA_PARCIAL=" & IIf(Me.radParcial.Checked, 1, 0)
        _params_movimiento &= ",@BAJA_TOTAL=" & IIf(Me.radTotal.Checked, 1, 0)
        _params_movimiento &= ",@MARCA=" & IIf(Me.txtMarca.Text.Length > 0, "'" & Me.txtMarca.Text & "'", "NULL")
        _params_movimiento &= ",@MODELO=" & IIf(Me.txtModelo.Text.Length > 0, "'" & Me.txtModelo.Text & "'", "NULL")
        _params_movimiento &= ",@NUMERO_SERIE=" & IIf(Me.txtNumeroSerie.Text.Length > 0, "'" & Me.txtNumeroSerie.Text & "'", "NULL")
        _params_movimiento &= ",@OTRAS_ESPECIFICACIONES=" & IIf(Me.txtOtrasEspecificaciones.Text.Length > 0, "'" & Me.txtOtrasEspecificaciones.Text & "'", "NULL")
        _params_movimiento &= ",@ASIGNADO=" & IIf(Me.txtAsignado.Text.Length > 0, "'" & Me.txtAsignado.Text & "'", "NULL")
        _params_movimiento &= ",@RESPONSABLE=" & IIf(Me.txtResponsableArea.Text.Length > 0, "'" & Me.txtResponsableArea.Text & "'", "NULL")
        _params_movimiento &= ",@DIVISION=" & IIf(Me.cmbDivision.SelectedValue = 0, "NULL", Me.cmbDivision.SelectedValue)
        _params_movimiento &= ",@DEPARTAMENTO_AREA=" & IIf(Me.cmbDepartamentoArea.SelectedValue = 0, "NULL", Me.cmbDepartamentoArea.SelectedValue)
        _params_movimiento &= ",@FECHA_ADQUICICION='" & Me.dtpAdqicicion.Value.ToShortDateString() & "'"
        _params_movimiento &= ",@FECHA_VENCIMIENTO_FINAN='" & dtpVencimientoFinanciero.Value.ToShortDateString() & "'"
        _params_movimiento &= ",@DESTINO_DADO_BAJA=" & IIf(Me.txtDestinoDadoBaja.Text.Length > 0, "'" & Me.txtDestinoDadoBaja.Text & "'", "NULL")
        _params_movimiento &= ",@OBSERVACIONES_BAJA=" & IIf(Me.txtObservacionesBaja.Text.Length > 0, "'" & Me.txtObservacionesBaja.Text & "'", "NULL")
        _params_movimiento &= ",@DESCRIPCION_BIEN=" & IIf(Me.txtDescripcionBien.Text.Length > 0, "'" & Me.txtDescripcionBien.Text & "'", "NULL")
        _params_movimiento &= ",@PRECIO_ORIGINAL_FINAN=" & nudPrecioOriginalFinanciero.Value
        _params_movimiento &= ",@VALOR_DEPRECIAR_FINAN=" & nudValorDepreciarFinanciero.Value
        _params_movimiento &= ",@VIDA_UTIL_FINAN=" & nudVidaUtilFinanciero.Value
        _params_movimiento &= ",@DEPRECIACION_MENSUAL_FINAN=" & nudDepreciaMensualFinanciero.Value
        _params_movimiento &= ",@REMANENTE_FINAN=" & nudRemanenteFinanciero.Value
        _params_movimiento &= ",@FECHA_VENCIMIENTO_FISCAL='" & dtpVencimientoFiscal.Value.ToShortDateString() & "'"
        _params_movimiento &= ",@PRECIO_ORIGINAL_FISCAL=" & nudPrecioOriginalFiscal.Value
        _params_movimiento &= ",@VALOR_DEPRECIAR_FISCAL=" & Me.nudValorDepreciarFiscal.Value
        _params_movimiento &= ",@VIDA_UTIL_FISCAL=" & nudVidaUtilFiscal.Value
        _params_movimiento &= ",@DEPRECIACION_MENSUAL_FISCAL=" & nudDepreciaMensualFiscal.Value
        _params_movimiento &= ",@REMANENTE_FISCAL=" & nudRemanenteFiscal.Value
        _params_movimiento &= ",@USUARIO_CREACION='" & Usuario & "'"
        _params_movimiento &= ",@USUARIO_EDICION='" & Usuario & "'"
        _params_movimiento &= ",@APLICAR_DEPRECIACION=" & IIf(Me.radDepreciable.Checked, 1, 0)
        _params_movimiento &= ",@CANTIDAD=" & Me.nudCantidad.Value
        _params_movimiento &= ",@FECHABAJA='" & Me.dtpFechaBaja.Value.ToShortDateString() & "'"
        _params_movimiento &= ",@PORCENTAJENODEPFINAN=" & nudPorcentajeNoDepreFinan.Value
        _params_movimiento &= ",@PORCENTAJENODEPFISCAL=" & Me.nudPorcentajeNoDepreFiscal.Value
        _params_movimiento &= ",@VALOR_RESIDUAL_FINAN=" & nudValorResidualFinanciero.Value
        _params_movimiento &= ",@VALOR_RESIDUAL_FISCAL=" & nudValorResidualFiscal.Value
        _params_movimiento &= ",@NUM_CFF=" & IIf(Me.txtNoCff.Text.Length > 0, "'" & Me.txtNoCff.Text & "'", "NULL")
        _params_movimiento &= ",@FECHA_CCF='" & Me.dtpFechaCff.Value.ToShortDateString() & "'"
        _params_movimiento &= ",@VALOR_CFF=" & IIf(Me.nudValorCff.Value > 0, "'" & Me.nudValorCff.Value & "'", "NULL")        
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    ' evento Keypress  
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvCuentasContables.CurrentCell.ColumnIndex
        If columna = 1 Or columna = 2 Then
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged
        If Not Iniciando Then
            Me.cmbDepartamentoArea.DataSource = Nothing
            objEntidad.fillComboBox(Me.cmbDepartamentoArea, "Exec SP_CONTABILIDAD_ACTIVO_FIJO_PROCESOS @BANDERA = 'consulta_depto', @DIVISION=" & Me.cmbDivision.SelectedValue & ", @COMPAÑIA = " & Compañia, "DEPARTAMENTO", "DESCRIPCION_DEPARTAMENTO")
        End If
    End Sub

    Private Sub dgvMovimientos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovimientos.CellClick
        If MsgBox("¿Desea ver el detalle de este movimiento?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            Dim _reportes As New frmReportes_Ver()
            _reportes.RepActivoFijoMovimientosBienes(Compañia, dgvMovimientos.Rows(dgvMovimientos.SelectedCells(0).RowIndex).Cells(0).Value)
            _reportes.ShowDialog()
        End If        
    End Sub

    Private Sub btnPrintBien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBien.Click
        Me.btnPrintBien.Visible = False
        Dim _reportes As New frmReportes_Ver()
        _reportes.RepActivoFijoFicha(Compañia, Me.id_bien)
        _reportes.ShowDialog()
        Me.btnPrintBien.Visible = True
    End Sub

    Private Sub nudPrecioOriginalFinanciero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPrecioOriginalFinanciero.Leave

        Me.nudValorDepreciarFinanciero.Value = Me.nudPrecioOriginalFinanciero.Value

    End Sub

    Private Sub nudPorcentajeNoDepreFinan_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPorcentajeNoDepreFinan.Leave
        If Me.nudPorcentajeNoDepreFinan.Value > 0 Then
            nudValorResidualFinanciero.Value = Me.nudPrecioOriginalFinanciero.Value * Me.nudPorcentajeNoDepreFinan.Value / 100
            nudValorDepreciarFinanciero.Value = Me.nudPrecioOriginalFinanciero.Value - nudValorResidualFinanciero.Value
        Else
            nudValorDepreciarFinanciero.Value = Me.nudPrecioOriginalFinanciero.Value
            nudValorResidualFinanciero.Value = 0
        End If
    End Sub

    Private Sub nudDepreciaMensualFinanciero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDepreciaMensualFinanciero.Leave
        Me.calcularAcumulado("financiero")
        'If Me.dtpVencimientoFiscal.Value >= Date.Now Then
        '    Dim liMeses As Integer
        '    Me.dtpVencimientoFiscal.Value = DateAdd(DateInterval.Month, nudVidaUtilFinanciero.Value, Me.dtpAdqicicion.Value).Date
        '    liMeses = DatePart("m", Date.Now) - DatePart("m", Me.dtpAdqicicion.Value)
        '    Me.nudRemanenteFinanciero.Value = nudValorDepreciarFinanciero.Value - (liMeses * Me.nudDepreciaMensualFinanciero.Value)
        'End If
        
    End Sub

    Private Sub dgvCuentasContables_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasContables.CellEndEdit
        If dgvCuentasContables.Columns(e.ColumnIndex).Name = "CUENTACONTABLE" Then
            If Not DBNull.Value.Equals(Me.dgvCuentasContables(3, e.RowIndex).Value) Then
                Dim value_ As String = String.Empty
                Dim _ok As Boolean = objEntidad.checkFor("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_CUENTAS WHERE CUENTA_COMPLETA = '" & Me.dgvCuentasContables(3, e.RowIndex).Value & "' AND COMPAÑIA=" & Compañia, "CUENTA", value_)
                If _ok Then
                    dgvCuentasContables.Item(5, e.RowIndex).Value = value_
                    'Colocando 0 en el porcentaje 
                    If DBNull.Value.Equals(Me.dgvCuentasContables(4, e.RowIndex).Value) Then
                        dgvCuentasContables.Item(2, e.RowIndex).Value = 0
                    End If
                Else
                    MsgBox("Cuenta Contable No Valida..", MsgBoxStyle.Critical, "Error")
                    Me.dgvCuentasContables.CurrentCell = dgvCuentasContables.Rows(e.RowIndex).Cells(3)
                End If
            End If
        End If
    End Sub

    Private Sub dgvCuentasContables_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCuentasContables.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub dgvCuentasContables_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasContables.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            Dim Cuentas As New Contabilidad_BusquedaCuentas
            Cuentas.Compañia_Value = Compañia
            Cuentas.LibroContable_Value = 1
            Cuentas.cmbLIBRO_CONTABLE.Enabled = True
            Cuentas.BuscaTodas = True
            Producto = ""
            Tipo = ""
            Descripcion_Producto = ""
            Numero = ""
            Cuentas.ShowDialog()
  
            If Tipo <> "" Then
                Me.dgvCuentasContables(3, e.RowIndex).Value = Tipo
            End If
        End If
    End Sub

    Private Sub nudVidaUtilFinanciero_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudVidaUtilFinanciero.ValueChanged
        If nudVidaUtilFinanciero.Value > 0 And Me.radDepreciable.Checked Then
            Me.nudVidaUtilFiscal.Value = nudVidaUtilFinanciero.Value

            Dim _tot_dias As Int16 = 0
            If nudVidaUtilFinanciero.Value = 12 Then
                _tot_dias = 365
            End If
            If nudVidaUtilFinanciero.Value = 24 Then
                _tot_dias = 730
            End If
            If nudVidaUtilFinanciero.Value = 48 Then
                _tot_dias = 1460
            End If
            If nudVidaUtilFinanciero.Value = 60 Then
                _tot_dias = 1825
            End If
            If nudVidaUtilFinanciero.Value = 72 Then
                _tot_dias = 2190
            End If
            If nudVidaUtilFinanciero.Value = 120 Then
                _tot_dias = 3650
            End If

            Me.nudDepreciaMensualFinanciero.Value = (IIf(Me.nudValorResidualFinanciero.Value > 0, Me.nudValorResidualFinanciero.Value, Me.nudPrecioOriginalFinanciero.Value) / Me.nudVidaUtilFinanciero.Value)
            Me.nudDepreciaMensualFiscal.Value = (IIf(Me.nudValorResidualFinanciero.Value > 0, Me.nudValorResidualFinanciero.Value, Me.nudPrecioOriginalFinanciero.Value) / Me.nudVidaUtilFinanciero.Value)

            Me.dtpVencimientoFinanciero.Value = DateAdd(DateInterval.Day, _tot_dias, Me.dtpAdqicicion.Value).Date
            'Me.dtpVencimientoFinanciero.Value = DateAdd(DateInterval.Month, nudVidaUtilFinanciero.Value, Me.dtpAdqicicion.Value).Date
            'Me.dtpVencimientoFinanciero.Value = DateAdd(DateInterval.Day, -1, Me.dtpVencimientoFinanciero.Value).Date

            Me.dtpVencimientoFiscal.Value = DateAdd(DateInterval.Day, _tot_dias, Me.dtpAdqicicion.Value).Date
            'Me.dtpVencimientoFiscal.Value = DateAdd(DateInterval.Month, nudVidaUtilFinanciero.Value, Me.dtpAdqicicion.Value).Date
            'Me.dtpVencimientoFiscal.Value = DateAdd(DateInterval.Day, -1, Me.dtpVencimientoFiscal.Value).Date

            Me.dtpFechaBaja.Value = DateAdd(DateInterval.Month, nudVidaUtilFinanciero.Value, Me.dtpAdqicicion.Value).Date
            Me.dtpFechaBaja.Value = DateAdd(DateInterval.Day, -1, Me.dtpFechaBaja.Value).Date

            Me.calcularAcumulado("financiero")
        End If
    End Sub

    Private Sub nudVidaUtilFiscal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudVidaUtilFiscal.ValueChanged
        If nudVidaUtilFiscal.Value > 0 And radDepreciable.Checked Then
            Dim _tot_dias As Int16 = 0
            If nudVidaUtilFiscal.Value = 12 Then
                _tot_dias = 365
            End If
            If nudVidaUtilFiscal.Value = 24 Then
                _tot_dias = 730
            End If
            If nudVidaUtilFiscal.Value = 48 Then
                _tot_dias = 1460
            End If
            If nudVidaUtilFiscal.Value = 60 Then
                _tot_dias = 1825
            End If
            If nudVidaUtilFiscal.Value = 72 Then
                _tot_dias = 2190
            End If
            If nudVidaUtilFiscal.Value = 120 Then
                _tot_dias = 3650
            End If

            Me.nudDepreciaMensualFiscal.Value = (IIf(Me.nudValorResidualFiscal.Value > 0, Me.nudValorResidualFiscal.Value, Me.nudPrecioOriginalFiscal.Value) / Me.nudVidaUtilFiscal.Value)
            Me.dtpVencimientoFiscal.Value = DateAdd(DateInterval.Day, _tot_dias, Me.dtpAdqicicion.Value).Date
            Me.calcularAcumulado("fiscal")
        End If
    End Sub

    Private Sub dgvCuentasContables_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuentasContables.CellLeave
        'If dgvCuentasContables.Columns(e.ColumnIndex).Name = "CUENTACONTABLE" Then
        If Not DBNull.Value.Equals(Me.dgvCuentasContables(3, e.RowIndex).Value) Then
            Dim value_ As String = String.Empty
            Dim _ok As Boolean = objEntidad.checkFor("SELECT CUENTA FROM dbo.CONTABILIDAD_CATALOGO_CUENTAS WHERE CUENTA_COMPLETA = '" & Me.dgvCuentasContables(3, e.RowIndex).Value & "' AND COMPAÑIA=" & Compañia, "CUENTA", value_)
            If _ok Then
                dgvCuentasContables.Item(5, e.RowIndex).Value = value_
                'Colocando 0 en el porcentaje 
                If DBNull.Value.Equals(Me.dgvCuentasContables(4, e.RowIndex).Value) Then
                    dgvCuentasContables.Item(2, e.RowIndex).Value = 0
                End If
                'Else
                '    MsgBox("Cuenta Contable No Valida..", MsgBoxStyle.Critical, "Error")
                '    Me.dgvCuentasContables.CurrentCell = dgvCuentasContables.Rows(e.RowIndex).Cells(3)
            End If
        End If
        'End If
    End Sub

    Private Sub nudVidaUtilFinanciero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudVidaUtilFinanciero.Leave
        If nudVidaUtilFinanciero.Value > 0 And Me.radDepreciable.Checked Then

            Dim _tot_dias As Int16 = 0
            If nudVidaUtilFinanciero.Value = 12 Then
                _tot_dias = 365
            End If
            If nudVidaUtilFinanciero.Value = 24 Then
                _tot_dias = 730
            End If
            If nudVidaUtilFinanciero.Value = 48 Then
                _tot_dias = 1460
            End If
            If nudVidaUtilFinanciero.Value = 60 Then
                _tot_dias = 1825
            End If
            If nudVidaUtilFinanciero.Value = 72 Then
                _tot_dias = 2190
            End If
            If nudVidaUtilFinanciero.Value = 120 Then
                _tot_dias = 3650
            End If

            Me.nudDepreciaMensualFinanciero.Value = (IIf(Me.nudValorResidualFinanciero.Value > 0, Me.nudValorResidualFinanciero.Value, Me.nudPrecioOriginalFinanciero.Value) / Me.nudVidaUtilFinanciero.Value)
            Me.dtpVencimientoFinanciero.Value = DateAdd(DateInterval.Day, _tot_dias, Me.dtpAdqicicion.Value).Date

            Me.dtpFechaBaja.Value = DateAdd(DateInterval.Month, nudVidaUtilFinanciero.Value, Me.dtpAdqicicion.Value).Date
            Me.dtpFechaBaja.Value = DateAdd(DateInterval.Day, -1, Me.dtpFechaBaja.Value).Date

            Me.calcularAcumulado("financiero")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Button1.Visible = False
        Dim _reportes As New frmReportes_Ver()
        _reportes.RepActivoFijoFichaActualizacion(Compañia, Me.id_bien)
        _reportes.ShowDialog()
        Me.Button1.Visible = True
    End Sub
End Class