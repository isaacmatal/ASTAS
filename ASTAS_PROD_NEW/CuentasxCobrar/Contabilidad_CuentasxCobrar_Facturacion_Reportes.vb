Imports System.Data.SqlClient

Public Class Contabilidad_CuentasxCobrar_Facturacion_Reportes

    'Constructor
    Dim multi As New multiUsos
    Dim PC As New Contabilidad_Procesos
    Dim NL As New NumeroLetras

    'Variables
    Dim sql As String = ""
    Dim Iniciando As Boolean

    'Guarda el motivo de la reimpresion
    Public motivoReimpresion As String

    Dim multiples As Boolean
    'Para contar el total de filas seleccionadas aunque no sean procesadas
    Dim k As Integer = 0
    'Para contar las filas seleccionadas y procesadas
    Dim j As Integer = 0
    Public CO, BO, OV, FACT, TIPO, CLIENTE As Integer
    Public TFACT As Double
    Public IMPRESA As Boolean
    Public proceder As Boolean

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Al cargar el formulario
    Private Sub Contabilidad_CuentasxCobrar_Facturacion_Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.cmbSELECCION.SelectedItem = "Simple"
        Me.dpFECHA.Value = PC.FechaActual_Servidor()
        multi.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaCMB(Me.cmbCOMPAÑIA.SelectedValue)
        Iniciando = False
    End Sub

    'Carga todos los combobox de acuerdo al valor de la compañia
    Private Sub cargaCMB(ByVal cia As Integer)
        multi.CargaBodegaSeguridadUsuario(cia, Me.cmbBODEGA)
        multi.CargaTipoDocumentoFact(cia, Me.cmbTIPO_DOCUMENTO)
        multi.cargaPaisDptosMunicipios(0, 0, 0, Me.cmbPAIS)
        multi.cargaPaisDptosMunicipios(Me.cmbPAIS.SelectedValue, 0, 1, Me.cmbDEPTO)
        multi.cargaPaisDptosMunicipios(Me.cmbPAIS.SelectedValue, Me.cmbDEPTO.SelectedValue, 2, Me.cmbMUNICIPIO)
    End Sub

    'Al cambiar el index de los combobox
    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            'Cambia la bodega
            multi.CargaBodegaSeguridadUsuario(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA)
            'Cambia el tipo de documento
            multi.CargaTipoDocumentoFact(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTIPO_DOCUMENTO)
            'Cambia el país
            multi.cargaPaisDptosMunicipios(0, 0, 0, Me.cmbPAIS)
            'Carga el DGV
            cargaFacturas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtNombreCliente.Text, Me.chkIncluyeFecha.CheckState, Me.dpFECHA.Value, 1, Val(Me.txtNoFact.Text))
        End If
    End Sub
    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            'Carga el DGV
            cargaFacturas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtNombreCliente.Text, Me.chkIncluyeFecha.CheckState, Me.dpFECHA.Value, 1, Val(Me.txtNoFact.Text))
        End If
    End Sub
    Private Sub cmbTIPO_DOCUMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_DOCUMENTO.SelectedIndexChanged
        If Iniciando = False Then
            'Carga el DGV
            cargaFacturas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtNombreCliente.Text, Me.chkIncluyeFecha.CheckState, Me.dpFECHA.Value, 1, Val(Me.txtNoFact.Text))
            'Habilita o deshabilita el detalle del CCF
            If Me.DgvFacturas.Rows.Count <> 0 Then
                If Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Then
                    Me.gbDetCCF.Enabled = False
                Else
                    Me.gbDetCCF.Enabled = True
                End If
            Else
                Me.gbDetCCF.Enabled = False
            End If
        End If
    End Sub
    Private Sub cmbPAIS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPAIS.SelectedIndexChanged
        If Iniciando = False Then
            'Cambia el departamento
            multi.cargaPaisDptosMunicipios(Me.cmbPAIS.SelectedValue, 0, 1, Me.cmbDEPTO)
        End If
    End Sub
    Private Sub cmbDEPTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDEPTO.SelectedIndexChanged
        If Iniciando = False Then
            'Cambian el municipio
            multi.cargaPaisDptosMunicipios(Me.cmbPAIS.SelectedValue, Me.cmbDEPTO.SelectedValue, 2, Me.cmbMUNICIPIO)
        End If
    End Sub
    Private Sub cmbSELECCION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSELECCION.SelectedIndexChanged
        If Iniciando = False Then
            If Me.DgvFacturas.Rows.Count <> 0 Then
                'Muestra u oculta la columna para seleccion multiple
                seleccionMultiple()
            Else
                MsgBox("No hay registros, opción inválida", MsgBoxStyle.Information, "Mensaje")
                Me.cmbSELECCION.Enabled = False
                Iniciando = True
                Me.cmbSELECCION.SelectedItem = "Simple"
                Iniciando = False
            End If
        End If
    End Sub

    'Para que solo ingrese letras
    Private Sub txtNombreCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreCliente.KeyPress
        multi.soloLetras(e)
    End Sub

    'Metodo del boton buscar
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'Carga el DGV
        cargaFacturas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtNombreCliente.Text, Me.chkIncluyeFecha.CheckState, Me.dpFECHA.Value, 1, val(me.txtNoFact.Text))
    End Sub

    'Metodo que llena el grid
    Private Sub cargaFacturas(ByVal cia As Integer, ByVal bodega As Integer, ByVal documento As Integer, ByVal cliente As String _
                              , ByVal condicion As Integer, ByVal fecha As Date, ByVal bandera As Integer, ByVal numFact As Integer)
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute dbo.sp_FACTURACION_HISTORIAL_FACTURAS_GENERADAS_REPORTES "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & documento
            sql &= ", '" & cliente & "'"
            sql &= ", " & condicion
            sql &= ", '" & Format(fecha, "Short Date") & "'"
            sql &= ", " & bandera
            sql &= ", " & numFact
            Table = multi.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, Table)
            Conexion_.Close()
            Me.DgvFacturas.Columns.Clear()
            Me.DgvFacturas.DataSource = Table
            Me.DgvFacturas.Columns.Item(5).Visible = False
            Me.DgvFacturas.Columns.Item(8).Visible = False
            Me.DgvFacturas.Columns.Item(9).Visible = False
            Me.DgvFacturas.Columns.Item(10).Visible = False
            Me.DgvFacturas.Columns.Item(11).Visible = False
            Me.DgvFacturas.Columns.Item(12).Visible = False
            Me.DgvFacturas.Columns.Item(13).Visible = False
            multi.ajustarGrid(14, Me.DgvFacturas)
            seleccionMultiple()
            If Me.DgvFacturas.Rows.Count <> 0 Then
                habilitar(True)
            Else
                habilitar(False)
            End If
            If Me.cmbSELECCION.SelectedItem = "Múltiple" Then
                If Me.chkAllSelected.CheckState = 0 Then
                    seleccionarTodos(False)
                Else
                    seleccionarTodos(True)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Metodo que habilita
    Private Sub habilitar(ByVal flag As Boolean)
        Me.cmbSELECCION.Enabled = flag
        Me.btnReporte.Enabled = flag
    End Sub

    Private Sub DgvFacturas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvFacturas.CellDoubleClick
        If e.RowIndex < 0 Then
            Return
        End If
        Dim form As New Facturacion_Ingreso_Comp_Retencion(OV, FACT, BO)
        form.ShowDialog(Me)
        form.Dispose()
    End Sub

    'Metodo cellenter del DGV
    Private Sub DgvFacturas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvFacturas.CellEnter
        If Me.DgvFacturas.Rows.Count = 0 Then
            Return
        Else
            If Me.DgvFacturas.CurrentRow.Index < Me.DgvFacturas.Rows.Count Then
                CO = Me.DgvFacturas.CurrentRow.Cells.Item(9).Value
                BO = Me.DgvFacturas.CurrentRow.Cells.Item(11).Value
                OV = Me.DgvFacturas.CurrentRow.Cells.Item(3).Value
                TIPO = Me.DgvFacturas.CurrentRow.Cells.Item(12).Value
                FACT = Me.DgvFacturas.CurrentRow.Cells.Item(0).Value
                TFACT = Me.DgvFacturas.CurrentRow.Cells.Item(4).Value
                IMPRESA = Me.DgvFacturas.CurrentRow.Cells.Item(7).Value
                CLIENTE = Me.DgvFacturas.CurrentRow.Cells.Item(10).Value
            End If
        End If
    End Sub

    'Selecciona todos los registros
    Private Sub chkAllSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllSelected.CheckedChanged
        If Me.chkAllSelected.CheckState = 0 Then
            seleccionarTodos(False)
        Else
            seleccionarTodos(True)
        End If
    End Sub

    'Metodo que selecciona todos o ninguno de los registros en el DGV
    Private Sub seleccionarTodos(ByVal TF As Integer)
        If Me.DgvFacturas.Rows.Count <> 0 Then
            For i As Integer = 0 To Me.DgvFacturas.Rows.Count - 1
                Me.DgvFacturas.Rows.Item(i).Cells.Item(8).Value = TF
            Next
        End If
    End Sub

    'Metodo para la seleccion multiple de registros
    Private Sub seleccionMultiple()
        Try
            If Me.DgvFacturas.Rows.Count <> 0 Then
                For i As Integer = 0 To Me.DgvFacturas.Columns.Count - 1
                    Me.DgvFacturas.Columns.Item(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    If i <> 8 Then
                        Me.DgvFacturas.Columns.Item(i).ReadOnly = True
                    End If
                Next
                Select Case Me.cmbSELECCION.Text
                    Case "Simple"
                        multiples = False
                        Me.chkAllSelected.Enabled = False
                        Me.chkAllSelected.CheckState = 0
                        Me.DgvFacturas.Columns.Item(8).Visible = False
                    Case "Múltiple"
                        multiples = True
                        Me.chkAllSelected.Enabled = True
                        Me.DgvFacturas.Columns.Item(8).Visible = True
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Metodo del boton para ver los reportes
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpt As New Contabilidad_CuentasxCobrar_Facturacion_RPT
        If Me.DgvFacturas.Rows.Count <> 0 Then
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = 2 Then
                rpt.Municipio = Me.cmbMUNICIPIO.SelectedValue.ToString
                rpt.Depto = Me.cmbDEPTO.SelectedValue.ToString
                rpt.Pais = Me.cmbPAIS.SelectedValue.ToString
            End If
            If Me.cmbSELECCION.SelectedItem = "Simple" Then
                rpt.cia = CO
                rpt.bodega = BO
                rpt.ov = OV
                rpt.factura = FACT
                rpt.tipoDoc = TIPO
                rpt.totalFact = TFACT
                rpt.flag = 1
                rpt.Multiple = False
                controlImpresion(CO, BO, CLIENTE, OV, FACT, TIPO, IMPRESA, 1)
            ElseIf Me.cmbSELECCION.SelectedItem = "Múltiple" Then
                If recorrerDGV() = True Then
                    rpt.cia = Me.cmbCOMPAÑIA.SelectedValue
                    rpt.bodega = Me.cmbBODEGA.SelectedValue
                    rpt.tipoDoc = Me.cmbTIPO_DOCUMENTO.SelectedValue
                    If Me.cmbTIPO_DOCUMENTO.SelectedValue = 1 Then
                        rpt.flag = 2
                    Else
                        rpt.flag = 3
                    End If
                    rpt.Multiple = True
                    proceder = True
                Else
                    rpt.Multiple = False
                    proceder = False
                End If
            End If
            If proceder = True Then
                'Actualiza todas las facturas como impresas
                multi.actualizaFacturasImpresion(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, 0, 9)
                'Carga el reporte
                rpt.ShowDialog()
            End If
            If Me.cmbSELECCION.SelectedItem = "Múltiple" Then
                'Borro los datos de la temporal
                llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, Me.cmbTIPO_DOCUMENTO.SelectedValue, 0, Nothing, 1)
            End If
            'Actualiza el DGV
            cargaFacturas(CO, BO, TIPO, Me.txtNombreCliente.Text, Me.chkIncluyeFecha.CheckState, Me.dpFECHA.Value, 1, Val(Me.txtNoFact.Text))
        End If
    End Sub

    'Metodo que recorre el DGV caprutando los valores
    Private Function recorrerDGV()
        j = 0
        k = 0
        'Limpia la temporal
        llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, 1, 0, Nothing, 1)
        llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, 2, 0, Nothing, 1)
        Dim tipoDoc As Integer = 0
        Dim column As Integer = 0
        'Se le quita el focus al datagriv para que pase a estado inactivo y asi pueda el metodo evaluar
        'el dgv con sus valores actuales, si no se hace no evalua el dgv como debería ser
        Me.cmbSELECCION.Focus()
        column = 8
        If Me.DgvFacturas.Rows.Count <> 0 Then
            If Me.DgvFacturas.Rows.Count > 1 Then
                If multiples = True Then
                    For i As Integer = 0 To Me.DgvFacturas.Rows.Count - 1
                        If Me.DgvFacturas.Rows.Item(i).Cells.Item(column).Value = True Then
                            k += 1
                            controlImpresion(Me.DgvFacturas.Rows.Item(i).Cells.Item(9).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(11).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(10).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(3).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(0).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(12).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(7).Value, 0)
                            If proceder = True Then
                                '    If Me.DgvFacturas.Rows.Item(i).Cells.Item(7).Value = False Then
                                'Llena una tabla temporal con los registros que se van a reportar
                                llenarTemporalFacturas(Me.DgvFacturas.Rows.Item(i).Cells.Item(9).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(0).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(3).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(10).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(12).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(11).Value, Me.DgvFacturas.Rows.Item(i).Cells.Item(4).Value, 0)
                                tipoDoc = Me.DgvFacturas.Rows.Item(i).Cells.Item(12).Value
                                j += 1
                                '    End If
                            End If
                        End If
                    Next
                    'Para evitar que mande datos nulos
                    If j = 0 And Me.DgvFacturas.Rows.Count <> 0 And k = 0 Then
                        MsgBox("¡No ha seleccionado ningún documento valido!", MsgBoxStyle.Information, "Mensaje")
                        restablecer()
                        'Borra todos los valores mandados a la temporal
                        llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, tipoDoc, 0, Nothing, 1)
                        Return False
                    ElseIf j = 0 And Me.DgvFacturas.Rows.Count <> 0 And k <> 0 Then
                        MsgBox("¡Operación Cancelada!", MsgBoxStyle.Information, "Mensaje")
                        restablecer()
                        'Borra todos los valores mandados a la temporal
                        llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, tipoDoc, 0, Nothing, 1)
                        Return False
                    ElseIf j = 1 And k <= 1 Then
                        MsgBox("¡Debe de seleccionar más de un documento si quiere procesar multiples impresiones!", MsgBoxStyle.Information, "Mensaje")
                        restablecer()
                        llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, tipoDoc, 0, Nothing, 1)
                        Return False
                        'ElseIf j >= 101 Then
                        '    MsgBox("¡No puede procesar más de 100 impresiones!", MsgBoxStyle.Information, "Mensaje")
                        '    restablecer()
                        '    llenarTemporalFacturas(Me.cmbCOMPAÑIA.SelectedValue, 0, 0, 0, tipoDoc, 0, Nothing, 1)
                        '    Return False
                    Else
                        Return True
                    End If
                End If
            Else
                MsgBox("¡Debe de seleccionar más de un documento si quiere procesar multiples impresiones!", MsgBoxStyle.Information, "Mensaje")
                restablecer()
                Return False
            End If
        Else
            MsgBox("¡No hay registros para procesar!", MsgBoxStyle.Information, "Mensaje")
            Return False
        End If
        Return False
    End Function

    'Cambiar el valor del seleccionar del dgv
    Private Sub restablecer()
        If Me.DgvFacturas.Rows.Count <> 0 Then
            If multiples = True And Me.cmbSELECCION.SelectedItem = "Múltiple" Then
                For i As Integer = 0 To Me.DgvFacturas.Rows.Count - 1
                    If Me.DgvFacturas.Rows.Item(i).Cells.Item(8).Value = True Then
                        Me.DgvFacturas.Rows.Item(i).Cells.Item(8).Value = False
                    End If
                Next
            End If
        End If
    End Sub

    'Metodo que llena la tabla tempora de donde se sacaran los datos para generar los multiples o reportes sencillos
    Private Sub llenarTemporalFacturas(ByVal cia As Integer, ByVal fact As Integer, ByVal ov As Integer, ByVal cliente As Integer _
                                      , ByVal tipodoc As Integer, ByVal bodega As Integer, ByVal Total As Double, ByVal flag As Integer)
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute dbo.sp_FACTURACION_REPORTES_DATOS_TEMPORALES "
            sql &= cia
            sql &= ", " & fact
            sql &= ", " & ov
            sql &= ", " & cliente
            sql &= ", " & tipodoc
            sql &= ", " & bodega
            sql &= ", '" & NL.Letras(Total.ToString) & "'"
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Metodo que permite controlar el motivo de la reimpresión de las facturas
    Private Function ingresarMotivoReimpresion(ByVal fact As Integer)
Corregir:
        'Se captura el motivo por medio del inputbox y se guarda en el objeto
        Dim valor As Object = InputBox("Motivo de la reimpresión de la factura: ", "Motivo por el cual se reimprime la factura Nº " & fact, "")
        'Verifica que el valor sea diferente de nada
        If valor <> Nothing Then
            'Verifica si no ha ingresado solo numeros
            If IsNumeric(valor) Then
                'Avisa al usuario que no debe ingresar solo numeros
                MsgBox("¡Ingresar valores númericos no se considera un motivo real!", MsgBoxStyle.Exclamation, "Mensaje")
                'Si es asi pide que vuelva a ingresar el motivo
                GoTo Corregir
            End If
        ElseIf valor = Nothing Then
            'En caso el valor ingresado sea nada o haya presionado Cancelar, notifica que no procederá con la operación
            MsgBox("¡No puede dejar el motivo de la reimpresión en blanco!" & vbCrLf & "¡La operación no se llevará a cabo!", MsgBoxStyle.Exclamation, "Mensaje")
        End If
        'Sea cual sea el resultado devuelve valor convertido en cadena
        Return valor.ToString
    End Function

    'Caputa el motivo y luego manda a guardar a control de reimpresion
    Private Sub controlImpresion(ByVal cia As Integer, ByVal bodega As Integer, ByVal cliente As Integer, ByVal ov As Integer _
                                 , ByVal fact As Integer, ByVal tipo As Integer, ByVal impresa As Boolean, ByVal sn As Integer)
        proceder = True
        'Actualiza la factura como impresa
        multi.actualizaFacturasImpresion(cia, ov, fact, tipo, BO, 10)
        'If impresa = False Then
        '    proceder = True
        '    'Actualiza la factura como impresa
        '    multi.actualizaFacturasImpresion(cia, ov, fact, tipo, BO, 10)
        'Else
        '    If MsgBox("La factura N° " & fact & " ya ha sido impresa." & vbCrLf & "¿Desea volver a imprimirla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje") = MsgBoxResult.Yes Then
        '        motivoReimpresion = ingresarMotivoReimpresion(fact)
        '        If motivoReimpresion <> Nothing Then
        '            controlReimpresion(CO, BO, cliente, ov, fact, tipo, motivoReimpresion, "I")
        '            proceder = True
        '        Else
        '            proceder = False
        '        End If
        '    Else
        '        If sn = 1 Then
        '            MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
        '        End If
        '        proceder = False
        '    End If
        'End If
    End Sub

    'Metodo que permite guardar el control de reimpresion de facturas
    Private Sub controlReimpresion(ByVal cia As Integer, ByVal bodega As Integer, ByVal cliente As Integer, ByVal ov As Integer _
                                   , ByVal fact As Integer, ByVal tipoDoc As Integer, ByVal motivo As String, ByVal IUD As String)
        Conexion_ = multi.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute dbo.sp_FACTURACION_GENERADA_CONTROL_REIMPRESIONES_IUD "
            sql &= 0
            sql &= ", " & cia
            sql &= ", " & bodega
            sql &= ", " & cliente
            sql &= ", " & ov
            sql &= ", " & fact
            sql &= ", " & tipoDoc
            sql &= ", " & 0
            sql &= ", '" & motivo & "'"
            sql &= ", " & Usuario
            sql &= ", " & IUD
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub DgvFacturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvFacturas.CellContentClick

    End Sub
End Class