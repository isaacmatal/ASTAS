Imports System.Data.SqlClient

Public Class Contabilidad_LineasMaximo_TipoDocumento

    'Constructor
    Dim fill As New cmbFill

    'Declaración de Variables
    Dim sql As String
    Dim Iniciando As Boolean
    Dim numLinea As Integer

    'Variable para controlar la busqueda de lineas
    Dim ys As String = "y"

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Cuando carga el formulario
    Private Sub Contabilidad_LineasMaximo_TipoDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        cargaCMB(Me.cmbCOMPAÑIA.SelectedValue)
        cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
        Iniciando = False
    End Sub

    'Carga todos los combobox acorde a la compañía
    Private Sub cargaCMB(ByVal cia)
        fill.CargaBodega(cia, Me.cmbBODEGA)
        fill.CargaTipoDocumentoFact(cia, Me.cmbTIPO_DOCUMENTO)
        fill.CargaSerieFactTodas(cia, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbSERIE)
        Me.lblLibreSiNo.Text = fill.devuelveSiNoSerieLibre(cia, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue)
    End Sub

    'Validaciones
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLineas.KeyPress
        fill.soloNumeros(e)
    End Sub

    'Al cambiar el valor de la compañía
    Private Sub cmbCOMPAÑIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPAÑIA.SelectedIndexChanged
        If Iniciando = False Then
            cargaCMB(Me.cmbCOMPAÑIA.SelectedValue)
            cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
        End If
    End Sub

    'Al cambiar el valor de la bodega
    Private Sub cmbBODEGA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBODEGA.SelectedIndexChanged
        If Iniciando = False Then
            fill.CargaSerieFactTodas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbSERIE)
            Me.lblLibreSiNo.Text = fill.devuelveSiNoSerieLibre(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue)
            If ys = "y" Then
                ys = "n"
                cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
                ys = "y"
            End If
        End If
    End Sub

    'Valida si los combobox están llenos
    Private Function valCMB(ByVal sector As GroupBox)
        Dim cmb As String = ""
        'Datos Generales
        If sector.Name = "gbDG" Then
            'Compañía
            If Me.cmbCOMPAÑIA.SelectedValue = Nothing Then
                cmb = vbCrLf & "Compañia"
            End If
            'Bodega
            If Me.cmbBODEGA.SelectedValue = Nothing Then
                cmb &= vbCrLf & "Bodega"
            End If
            'Serie
            If Me.cmbSERIE.SelectedValue = Nothing Then
                cmb &= vbCrLf & "Serie"
            End If
            'Tipo de Documento
            If Me.cmbTIPO_DOCUMENTO.SelectedValue = Nothing Then
                cmb &= vbCrLf & "Tipo Documento"
            End If
        End If
        'Mensaje de advertencia
        If cmb <> Nothing Then
            MsgBox("No se puede continuar con la operacion debido a" & vbCrLf & "la falta de información en los siguientes campos: " & cmb, MsgBoxStyle.Information, "Mensaje")
        End If
        Return cmb
    End Function

    'Valida si no hay campos vacios
    Private Function valCamposVacios(ByVal sector As GroupBox)
        Dim camposVacios As String = ""
        If sector.Name = "gbDG" Then
            'Nº Líneas máximo
            If Trim(Me.txtLineas.Text) = "" Then
                camposVacios &= vbCrLf & "Nº Líneas"
            End If
        End If
        'Mensaje de advertencia
        If camposVacios <> Nothing Then
            MsgBox("Debe llenar los siguientes campos: " & camposVacios, MsgBoxStyle.Information, "Mensaje")
        End If
        Return camposVacios
    End Function

    'Limpia campos
    Private Sub limpiaCampos(ByVal sector As GroupBox)
        If sector.Name = "gbDG" Then
            fill.CargaCompañia(Me.cmbCOMPAÑIA)
            cargaCMB(Me.cmbCOMPAÑIA.SelectedValue)
            Me.txtLineas.Clear()
        End If
        Me.BarraEstado1.Text = ""
    End Sub

    'Boton guardar
    Private Sub btnGuardarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarLinea.Click
        Dim IUD As String = ""
        If valCMB(Me.gbDG) = Nothing Then
            If valCamposVacios(Me.gbDG) = Nothing Then
                If numLinea = Nothing Or numLinea = 0 Then
                    IUD = "I"
                Else
                    IUD = "U"
                End If
                If IUD = "U" Then
                    If MsgBox("¿Quiere actualizar el máximo de líneas seleccionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje") = MsgBoxResult.Yes Then
                        mttoMaximoLineas(numLinea, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtLineas.Text, IUD)
                    Else
                        numLinea = 0
                    End If
                Else
                    mttoMaximoLineas(numLinea, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtLineas.Text, IUD)
                End If
                cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
                limpiaCampos(Me.gbDG)
            End If
        End If
    End Sub

    'Boton Eliminar
    Private Sub btnEliminarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarLinea.Click
        Dim IUD As String = ""
        If Me.dgvLineas.RowCount = 0 Then
            MsgBox("No hay registros para eliminar", MsgBoxStyle.Information, "Mensaje")
        Else
            If numLinea = 0 Or numLinea = Nothing Then
                MsgBox("Debe elegir un máximo de líneas válido", MsgBoxStyle.Critical, "Mensaje")
            ElseIf numLinea > 0 Then
                IUD = "D"
                If MsgBox("¿Está seguro(a) de querer eliminar el máximo de líneas seleccionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje") = MsgBoxResult.Yes Then
                    mttoMaximoLineas(numLinea, Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtLineas.Text, IUD)
                Else
                    MsgBox("Operación cancelada", MsgBoxStyle.Information, "Mensaje")
                    numLinea = 0
                End If
                fill.limpiargrid(Me.dgvLineas)
                cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
            End If
        End If
    End Sub

    'Boton buscar
    Private Sub btnBuscarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarLinea.Click
        If valCMB(Me.gbDG) = Nothing Then
            cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.txtLineas.Text, 1, 1)
        End If
    End Sub

    'Boton nuevo
    Private Sub btnNuevaLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaLinea.Click
        limpiaCampos(Me.gbDG)
        numLinea = 0
        cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
    End Sub

    'Mtto del Maximo de Lineas
    Private Sub mttoMaximoLineas(ByVal numLinea, ByVal cia, ByVal bodega, ByVal serie, ByVal tipoDoc, ByVal lineas, ByVal IUD)
        Dim res As Integer = 0
        If numLinea = Nothing Or numLinea = 0 Then
            numLinea = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_LINEAS_TIPO_DOCUMENTO_IUD "
            sql &= numLinea
            sql &= ", " & cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", " & lineas
            sql &= ", '" & Usuario & "'"
            sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(sql, Conexion_)
            res = Comando_.ExecuteNonQuery()
            Conexion_.Close()
            If res > 0 Then
                Select Case IUD
                    Case "I"
                        MsgBox("Datos Máximo de Líneas almacenados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "U"
                        MsgBox("Datos Máximo de Líneas actualizados con éxito", MsgBoxStyle.Information, "Mensaje")
                    Case "D"
                        MsgBox("Datos Máximo de Líneas eliminados con éxito", MsgBoxStyle.Information, "Mensaje")
                End Select
                numLinea = 0
            ElseIf res = -1 Then
                MsgBox("Ya existe un registro con los datos enviados", MsgBoxStyle.Critical, "Mensaje")
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = 547 Then
                MsgBox("¡Este registro tiene dependencias, no podrá eliminarlo!", MsgBoxStyle.Critical, "Mensaje")
            Else
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Carga los maximos de linea para cada documento
    Private Sub cargaLinea(ByVal cia, ByVal bodega, ByVal serie, ByVal tipoDoc, ByVal lineas, ByVal flag, ByVal sn)
        If cia = "0" Or cia = Nothing Then
            cia = 0
        End If
        If bodega = "0" Or bodega = Nothing Then
            bodega = 0
        End If
        If serie = "0" Or serie = Nothing Then
            serie = 0
        End If
        If tipoDoc = "0" Or tipoDoc = Nothing Then
            tipoDoc = 0
        End If
        If lineas = "0" Or lineas = Nothing Then
            lineas = 0
        End If
        If flag = "0" Or flag = Nothing Then
            flag = 0
        End If
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute sp_FACTURACION_LINEAS_TIPO_DOCUMENTO "
            sql &= cia
            sql &= ", " & bodega
            sql &= ", " & serie
            sql &= ", " & tipoDoc
            sql &= ", " & lineas
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            If Table.Rows.Count > 0 Then
                Me.dgvLineas.Columns.Clear()
                Me.dgvLineas.DataSource = Table
                Me.dgvLineas.Columns.Item(1).Visible = False
                Me.dgvLineas.Columns.Item(2).Visible = False
                Me.dgvLineas.Columns.Item(3).Visible = False
                Me.dgvLineas.Columns.Item(5).Visible = False
                Me.dgvLineas.Columns.Item(7).Visible = False
                Conexion_.Close()
                fill.ajustarGrid(12, Me.dgvLineas)
            Else
                If sn = 1 Then
                    MsgBox("No se encontraron registros", MsgBoxStyle.Information, "Mensaje")
                End If
                Iniciando = True
                ys = "n"
                fill.limpiargrid(Me.dgvLineas)
                ys = "y"
                Me.txtLineas.Clear()
                Me.BarraEstado1.Text = ""
                Iniciando = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Metodo para el evento cellenter del DGV
    Private Sub lineaSeleccionada()
        If Me.dgvLineas.RowCount = 0 Then
            Me.txtLineas.Clear()
            numLinea = 0
            Return
        Else
            If Me.dgvLineas.CurrentRow.Index < Me.dgvLineas.RowCount Then
                Try
                    numLinea = Val(Me.dgvLineas.CurrentRow.Cells.Item(0).Value)
                    Me.cmbCOMPAÑIA.SelectedValue = Me.dgvLineas.CurrentRow.Cells.Item(1).Value
                    Me.cmbBODEGA.SelectedValue = Me.dgvLineas.CurrentRow.Cells.Item(3).Value
                    Me.cmbSERIE.SelectedValue = Me.dgvLineas.CurrentRow.Cells.Item(5).Value
                    Me.cmbTIPO_DOCUMENTO.SelectedValue = Me.dgvLineas.CurrentRow.Cells.Item(7).Value
                    Me.txtLineas.Text = Me.dgvLineas.CurrentRow.Cells.Item(9).Value
                    Me.BarraEstado1.Text = "Ha seleccionado el máximo de línea Nº " & Me.dgvLineas.CurrentRow.Cells.Item(0).Value
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
                End Try
            Else
                numLinea = 0
            End If
        End If
    End Sub

    Private Sub cmbSERIE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSERIE.SelectedIndexChanged
        If Iniciando = False Then
            cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbSERIE.SelectedValue, 0, 0, 1, 0)
        End If
    End Sub

    Private Sub cmbTIPO_DOCUMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPO_DOCUMENTO.SelectedIndexChanged
        If Iniciando = False Then
            fill.CargaSerieFactTodas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue, Me.cmbSERIE)
            Me.lblLibreSiNo.Text = fill.devuelveSiNoSerieLibre(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, Me.cmbTIPO_DOCUMENTO.SelectedValue)
            If ys = "y" Then
                ys = "n"
                cargaLinea(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA.SelectedValue, 0, Me.cmbTIPO_DOCUMENTO.SelectedValue, 0, 1, 0)
                ys = "y"
            End If
        End If
    End Sub

    Private Sub dgvLineas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLineas.CellEnter
        If ys <> "n" Then
            lineaSeleccionada()
        End If
    End Sub

End Class