Imports System.Data
Imports System.Data.SqlClient

Public Class socio_agregar

#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim datareader01 As SqlDataReader
    Dim DS, DS01, DS02 As New DataSet()
    Dim SQL As String
    Dim Beneficiario, Estado, Parentesco As Integer
    Dim Accion As String
    Dim PorcenBene As Double
    Dim contador As Integer

    Dim Resultado As DialogResult

    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(SQL, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
        DataAdapter.Fill(DS)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region

    Private Sub socio_agregar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargarDatosGrid_beneficiarios()
        CargarDatosComboboxCompania()
        Me.Cmb_be_parentesco.Items.Clear()
        CargarDatosComboboxParentesco()
        BorrarCajasTexto(1)
        BorrarCajasTexto(2)
        Me.Txt_Porcentaje_restante.Clear()
        contador = 1
    End Sub

    Public Sub BtnAgregarBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarBeneficiario.Click, BtnModificarBeneficiario.Click, BtnEliminarBeneficiario.Click
        TextoConversion()
        Dim result As DialogResult
        If sender Is BtnAgregarBeneficiario Then

            If Beneficiario = 0 Then
                Accion = "I"
                Estado = 1
                ValidarBeneficiarios()
            ElseIf Beneficiario <> 0 Then
                result = MessageBox.Show("¿Esta seguro(a) que desea modificar los datos de este beneficiario?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If result = Windows.Forms.DialogResult.Yes Then
                    Accion = "U"
                    Estado = 1
                    ValidarBeneficiarios()
                End If
            End If
        ElseIf sender Is BtnEliminarBeneficiario Then
            result = MessageBox.Show("Esta seguro que desea ELIMINAR este beneficiario de la lista de beneficiarios", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If result = Windows.Forms.DialogResult.Yes Then
                Accion = "D"
                Estado = 0
                ValidarBeneficiarios()
            End If
        End If
        CargarDatosGrid_beneficiarios()
    End Sub

    Sub CargarDatosGrid_beneficiarios()
     
        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Exit Sub
        End If
        Try
            DS.Reset()
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_BENEFICIARIOS_AGREGAR " & Compañia & ", '" & Beneficiario & "', '" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','" & Parentesco & "','" & Me.Txt_be_nombre.Text & "','" & Me.Txt_be_apellido.Text & "','" & Me.Txt_be_telefono1.Text & "','" & Me.Txt_be_telefono2.Text & "','" & Val(Format(Me.Txt_be_porcentaje.Text, "0")) & "','" & Me.Txt_be_direccion.Text & "','" & Usuario & "',1,'S'"
            MiddleConnection()
            DataGrid.DataSource = DS.Tables(0)
            CloseConnection()
            Me.DataGrid.Columns(0).Visible = False 'compañia
            Me.DataGrid.Columns(4).Visible = False 'codigo parentesco
            Me.DataGrid.Columns(2).Visible = False 'codigo buxi
            Me.DataGrid.Columns(3).Visible = False 'codigo as
            Me.DataGrid.Columns(12).Visible = False 'estado
        Catch ex As Exception
            'MsgBox("Codigo no Encontrado, Favor Verificar Codigo", MsgBoxStyle.Information)
            MsgBox(ex.Message)
        Finally
            CloseConnection()
            'MsgBox("Hola")
        End Try
        Me.DataGrid.Columns.Item(1).Width = 45 'codigo beneficiario
        Me.DataGrid.Columns.Item(5).Width = 250 'nombre beneficiario
        Me.DataGrid.Columns.Item(6).Width = 250 'Apellido beneficiario
        Me.DataGrid.Columns.Item(7).Width = 150 'descripcion beneficiario
        Me.DataGrid.Columns.Item(8).Width = 130 'telefono 1
        Me.DataGrid.Columns.Item(9).Width = 130 'telefono 2
        Me.DataGrid.Columns.Item(10).Width = 60 'porcentaje
        Me.DataGrid.Columns.Item(11).Width = 300 'porcentaje
        SumaPorcentajesBeneficiarios()
    End Sub

    Public Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Try

            Beneficiario = Me.DataGrid.Rows(e.RowIndex).Cells(1).Value()
            'MsgBox(Beneficiario)
            'Me.Txt_be_nombre.Text = Me.DataGrid.Rows(e.RowIndex).Cells(5).Value()
            Me.Txt_be_nombre.Text = Me.DataGrid.Rows(e.RowIndex).Cells(5).Value()
            Me.Txt_be_apellido.Text = Me.DataGrid.Rows(e.RowIndex).Cells(6).Value()
            Me.Cmb_be_parentesco.Text = Me.DataGrid.Rows(e.RowIndex).Cells(7).Value()
            'Me.Cmb_be_parentesco.SelectedValue = Me.DataGrid.Rows(e.RowIndex).Cells(7).Value()
            'MsgBox(Me.DataGrid.Rows(e.RowIndex).Cells(7).Value())
            Me.Txt_be_telefono1.Text = Me.DataGrid.Rows(e.RowIndex).Cells(8).Value()
            Me.Txt_be_telefono2.Text = Me.DataGrid.Rows(e.RowIndex).Cells(9).Value()
            Me.Txt_be_porcentaje.Text = Me.DataGrid.Rows(e.RowIndex).Cells(10).Value()
            PorcenBene = Me.DataGrid.Rows(e.RowIndex).Cells(10).Value()
            'Me.TextBox3.Text = Me.DataGrid.Rows(e.RowIndex).Cells(10).Value()
            Me.Txt_be_direccion.Text = Me.DataGrid.Rows(e.RowIndex).Cells(11).Value()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Sub ValidarBeneficiarios()
        If Me.Txt_be_nombre.Text = Nothing Then
            MessageBox.Show("Ingrese el NOMBRE del Beneficiario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_be_nombre.Focus()
        ElseIf Me.Txt_be_apellido.Text = Nothing Then
            MessageBox.Show("Ingrese el APELLIDO del Beneficiario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_be_apellido.Focus()
        ElseIf Me.Txt_be_telefono1.Text = Nothing Then
            MessageBox.Show("Ingrese el 1er Telefono del Beneficiario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_be_telefono1.Focus()
        ElseIf Val(Me.Txt_be_porcentaje.Text) <= 0 Or Val(Me.Txt_be_porcentaje.Text) > 100 Then
            MessageBox.Show("El valor del Porcentaje asignado al beneficiario no puede ser '0' ni mayor a '100'")
            Me.Txt_be_porcentaje.Focus()
        ElseIf Me.Txt_be_direccion.Text = Nothing Then
            MessageBox.Show("Ingrese la DIRECCION dle beneficiario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Txt_be_direccion.Focus()
        Else

            Dim TotalPorcentaje As Double
            TotalPorcentaje = Val(Me.Txt_be_porcentaje.Text) - Val(Me.Txt_Porcentaje_restante.Text)
            If Accion = "I" Then
                If TotalPorcentaje <= 100 Then
                    Beneficiarios_SIUD()
                Else
                    MessageBox.Show("La suma total de los porcentajes no puede ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Txt_be_porcentaje.Focus()
                End If
            ElseIf Accion = "D" Then
                Beneficiarios_SIUD()
            Else
                Beneficiarios_SIUD()
            End If
        End If
    End Sub

    Public Sub Beneficiarios_SIUD()
        Parentesco = Me.Cmb_be_parentesco.SelectedValue
        If Accion = Nothing Then
            Exit Sub
        End If
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_BENEFICIARIOS_AGREGAR " & Compañia & ", '" & _
                    Beneficiario & "', '" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','" & _
                    Parentesco & "','" & Me.Txt_be_nombre.Text & "','" & Me.Txt_be_apellido.Text & "','" & _
                    Me.Txt_be_telefono1.Text & "','" & Me.Txt_be_telefono2.Text & "','" & _
                    Val(Me.Txt_be_porcentaje.Text) & "','" & Me.Txt_be_direccion.Text & "','" & Usuario & "'," & _
                    Estado & ",'" & Accion & "'"
            MiddleConnection()
            If Accion = "I" Then
                MessageBox.Show("Se ha INSERTADO un nuevo registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Accion = "U" Then
                MessageBox.Show("Se ha MODIFICADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Accion = "D" Then
                MessageBox.Show("Se ha ELIMINADO el registro exitosamente...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
            BorrarCajasTexto(2)
        End Try


    End Sub

    Sub CargarDatosComboboxCompania()
        Me.CmbCompania.Text = ""
        Try
            OpenConnection()
            SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            'DataReader_Track = Comando_Track.ExecuteReader
            Me.CmbCompania.DataSource = table
            Me.CmbCompania.ValueMember = "COMPAÑIA"
            Me.CmbCompania.DisplayMember = "NOMBRE_COMPAÑIA"
            'DataReader_Tr ack.Close()
            Me.CmbCompania.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub CargarDatosComboboxParentesco()
        Me.Cmb_be_parentesco.Text = ""
        Try
            DS.Reset()
            OpenConnection()
            'SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            SQL = "Exec sp_COOPERATIVA_CATALOGO_PARENTESCOS_IUD'" & Compañia & "','','','','S'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            DataAdapter = New SqlDataAdapter(Comando_Track)
            Dim table As DataTable
            table = New DataTable("Datos")
            DataAdapter.Fill(table)

            'DataReader_Track = Comando_Track.ExecuteReader
            Me.Cmb_be_parentesco.DataSource = table
            Me.Cmb_be_parentesco.ValueMember = "PARENTESCO"
            Me.Cmb_be_parentesco.DisplayMember = "DESCRIPCION_PARENTESCO"

            'DataReader_Tr ack.Close()
            Me.Cmb_be_parentesco.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub SumaPorcentajesBeneficiarios()
        Me.Txt_Porcentaje_restante.Clear()
        If Me.TxtCodAS.Text = Nothing And Me.TxtCodBuxy.Text = Nothing Then
            Exit Sub
        End If
        Try
            OpenConnection()
            'SQL = "Execute sp_CATALOGO_COMPAÑIAS '" & Usuario & "',1"
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_BENEFICIARIOS_AGREGAR " & Compañia & ", '" & _
                    Beneficiario & "', '" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','" & _
                    Parentesco & "','" & Me.Txt_be_nombre.Text & "','" & Me.Txt_be_apellido.Text & "','" & _
                    Me.Txt_be_telefono1.Text & "','" & Me.Txt_be_telefono2.Text & "','" & _
                    Val(Me.Txt_be_porcentaje.Text) & "','" & Me.Txt_be_direccion.Text & "','" & Usuario & "'," & _
                    Estado & ",'P'"
            Comando_Track = New SqlCommand(SQL, Conexion_Track)
            Dim datareader_ As SqlDataReader
            datareader_ = Comando_Track.ExecuteReader()
            If datareader_.Read = True Then
                Me.Txt_Porcentaje_restante.Text = 100 + (datareader_.Item(0))
                If Me.Txt_Porcentaje_restante.Text > 100 Then
                    MsgBox("Porcentaje excede al 100% asignado." & Chr(13) & "Corregir porcentajes.", MsgBoxStyle.Exclamation, "AVISO")
                ElseIf Me.Txt_Porcentaje_restante.Text = 100 Then
                    Me.Txt_Porcentaje_restante.Text = 0
                ElseIf Me.Txt_Porcentaje_restante.Text = 0 Then
                    Me.Txt_Porcentaje_restante.Text = 100
                End If
            End If
            Me.Cmb_be_parentesco.SelectedItem = 1
            CloseConnection()
        Catch ex As Exception
            ''ERROR
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub BusquedaDatosSocios()
        DS.Reset()
        Dim CodAS, Accion As String
        Dim CBuxi As Integer
        CodAS = ""
        Accion = ""
        If Trim(Me.TxtCodAS.Text) = Nothing And Val(Me.TxtCodBuxy.Text) <= 0 Then
            MessageBox.Show("Ingrese al menos un CODIGO" & Chr(13) & "CODIGO AS O CODIGO BUXI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.TxtCodAS.Focus()
            Exit Sub
        ElseIf Trim(Me.TxtCodAS.Text) <> Nothing Or Val(Me.TxtCodBuxy.Text) > 0 Then
            CodAS = Me.TxtCodAS.Text.Trim
            CBuxi = Val(Me.TxtCodBuxy.Text)
            If CodAS <> Nothing And CBuxi <= 0 Then
                Accion = "cas"
                'CBuxi = 1
            ElseIf CodAS = Nothing And CBuxi > 0 Then
                Accion = "cbuxi"
                'CodAS = "1"
            ElseIf CodAS <> Nothing And CBuxi > 0 Then
                Accion = "ambos"
            End If
            'MsgBox(Accion)
            'Exit Sub
        End If
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIO_BUSQUEDA_en_vista'" & Compañia & "','" & CBuxi & "','" & CodAS & "','" & Accion & "'"
            MiddleConnection()
            If (DS.Tables.Item(0).Rows.Count) <= 0 Then
                MessageBox.Show("Empleado no Existe...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Hay_Datos = False
                Exit Sub
            End If
            Hay_Datos = True
            Me.TxtCodAS.Text = DS.Tables(0).Rows(0).Item(2)
            Me.TxtCodBuxy.Text = DS.Tables(0).Rows(0).Item(3)
            Me.TxtSoNombre.Text = DS.Tables(0).Rows(0).Item(4)
            Me.TxtSoApellido.Text = DS.Tables(0).Rows(0).Item(5)
            Me.TxtDUI.Text = DS.Tables(0).Rows(0).Item(15)
            Me.TxtNit.Text = DS.Tables(0).Rows(0).Item(16)
            Me.TxtDivision.Text = DS.Tables(0).Rows(0).Item(6)
            Me.TxtDepto.Text = DS.Tables(0).Rows(0).Item(7)
            Me.TxtSeccion.Text = DS.Tables(0).Rows(0).Item(8)
            Me.TxtCargo.Text = DS.Tables(0).Rows(0).Item(9)
            Me.Txt_sueldo_mensual.Text = DS.Tables(0).Rows(0).Item(19)
            If Val(Txt_sueldo_mensual.Text) > 0 Then
                Me.Txt_capacidad_pago.Text = Format((Txt_sueldo_mensual.Text / 2) * 0.4, "0.00")
            End If
            Me.TxtFechaContratacion.Text = DS.Tables(0).Rows(0).Item(12)
            Me.Txt_so_direccion.Text = DS.Tables(0).Rows(0).Item(17)
            Me.Txt_so_telefono.Text = DS.Tables(0).Rows(0).Item(18)
            paramDeducciones = DS.Tables(0).Rows(0).Item(21)
            Asociadion_Ingreso()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub Asociadion_Ingreso()
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_ASOCIACION_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "','UDRS'"
            MiddleConnection()
            DataAdapter.Fill(DS01)
            If (DS01.Tables.Item(0).Rows.Count) <= 0 Then
                Exit Sub
            End If

            If DS01.Tables(0).Rows(0).Item(0) = 1 Then
                Me.TxtEstadoAS.Text = "ACTIVO"
                Me.TxtFechaIngresoAS.Text = DS01.Tables(0).Rows(0).Item(2)
                Me.TxtFechaSalidaAS.Text = "No Indefinido"
            ElseIf DS01.Tables(0).Rows(0).Item(0) = 0 Then
                Me.TxtEstadoAS.Text = "INACTIVO"
                Me.TxtFechaSalidaAS.Text = DS01.Tables(0).Rows(1).Item(2)
                Me.TxtFechaIngresoAS.Text = DS01.Tables(0).Rows(0).Item(2)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub Deudas_socio() 'envio de datos para tabla de socios deudas 'benjamin
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_SOCIO_DEUDAS_IUD " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "'," & Me.Txt_sueldo_mensual.Text & "," & ParamDeducciones & ",0,0,0,'" & Usuario & "'"
            MiddleConnection()
            DataAdapter.Fill(DS02)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

#Region "Basic"
    Sub TextoConversion()
        For Each control As Control In GrpDatosSocios.Controls
            If TypeOf control Is TextBox Then
                control.Text = Trim(control.Text)
                control.Text = UCase(control.Text)
            End If
        Next
        For Each control As Control In GrpBeneficiarios.Controls
            If TypeOf control Is TextBox Then
                control.Text = Trim(control.Text)
                control.Text = UCase(control.Text)
            End If
        Next
    End Sub
    Sub BorrarCajasTexto(ByVal accion)
        If accion = 1 Then
            For Each control As Control In Me.GrpDatosSocios.Controls
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            Next
            Me.Txt_sueldo_mensual.Clear()
            Me.Txt_capacidad_pago.Clear()
            Me.TxtFechaContratacion.Clear()
            Me.TxtTipoContratacion.Clear()
            Me.TxtEstado.Clear()
            Me.Txt_ahorrar_total.Clear()
            Me.Txt_ahorrar_ordinario.Clear()
            Me.Txt_ahorrar_extraordinario.Clear()
            Me.TxtCodAS.Focus()

            Me.TxtFechaIngresoAS.Clear()
            Me.TxtFechaSalidaAS.Clear()
            Me.TxtEstadoAS.Clear()

        End If
        If accion = 2 Then
            For Each control As Control In Me.GrpBeneficiarios.Controls
                If TypeOf control Is TextBox Then
                    control.Text = ""
                End If
            Next
            Me.Txt_be_nombre.Focus()
        End If
        If accion = 3 Then
            Me.Txt_por_ahorrar_total.Text = "2.50"
            Me.Txt_por_ahorrar_ordinario.Clear()
            Txt_por_ahorrar_extraordinario.Clear()
            Porcentaje_ahorro()
            Me.Txt_por_ahorrar_total.Focus()
        End If
    End Sub
#End Region

    Sub Porcentaje_ahorro()
        Try
            If Val(Me.Txt_por_ahorrar_total.Text) > 0 Then
                If Val(Me.Txt_por_ahorrar_total.Text) < 2.5 Then
                    MsgBox("¡El Porcentaje de Ahorro no puede ser menor al 2.5%!", MsgBoxStyle.Critical, "Validación")
                    Me.Txt_por_ahorrar_total.Focus()
                ElseIf Val(Me.Txt_por_ahorrar_total.Text) >= 2.5 And Val(Me.Txt_por_ahorrar_total.Text) <= 5 Then
                    Me.Txt_por_ahorrar_ordinario.Text = Format(Val(Me.Txt_por_ahorrar_total.Text), "0.00")
                    Me.Txt_por_ahorrar_extraordinario.Text = "0.00"
                ElseIf Val(Me.Txt_por_ahorrar_total.Text) > 5 Then
                    Me.Txt_por_ahorrar_ordinario.Text = "5.00"
                    Me.Txt_por_ahorrar_extraordinario.Text = Format(Val(Me.Txt_por_ahorrar_total.Text) - 5, "0.00")
                End If
                'MessageBox.Show(Txt_por_ahorrar_ordinario.Text & ";" & Txt_por_ahorrar_extraordinario.Text)
                Me.Txt_ahorrar_total.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_total.Text / 100), "0.00")
                Me.Txt_ahorrar_ordinario.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_ordinario.Text / 100), ".00")
                Me.Txt_ahorrar_extraordinario.Text = Format(Val(Me.Txt_sueldo_mensual.Text) * Val(Me.Txt_por_ahorrar_extraordinario.Text / 100), ".00")
            End If
        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub TXT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    Txt_por_ahorrar_total.LostFocus, TxtCodBuxy.LostFocus, Btn_so_buscar.LostFocus, _
    Txt_be_telefono1.LostFocus, Txt_be_porcentaje.LostFocus, Txt_be_direccion.LostFocus
        If Me.TxtCodAS.Text <> Nothing Or Me.TxtCodBuxy.Text <> Nothing Then
            If sender Is Txt_por_ahorrar_total Then
                Porcentaje_ahorro()
            ElseIf sender Is TxtCodBuxy Then
                Me.Btn_so_buscar.Focus()
            ElseIf sender Is Btn_so_buscar Then
                Me.Txt_por_ahorrar_total.Focus()
            End If
        End If
    End Sub

    Public Sub Btn_so_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Socio_limpiar.Click, Btn_Beneficiario_limpiar.Click, Btn_Ahorro_limpiar.Click ', Btn_so_buscar.Click
        contador = 0
        If sender Is Btn_Socio_limpiar Then
            BorrarCajasTexto(1)
            BorrarCajasTexto(2)
            BorrarCajasTexto(3)
            Beneficiario = 0
            DS.Reset()
        ElseIf sender Is Btn_Beneficiario_limpiar Or sender Is Btn_so_buscar Then
            BorrarCajasTexto(2)
        ElseIf sender Is Btn_Ahorro_limpiar Or sender Is Btn_so_buscar Then
            BorrarCajasTexto(3)
        End If
        Beneficiario = 0
    End Sub

    Private Sub Btn_so_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_buscar.Click
        ParamcodigoAs = ""
        ParamcodigoBux = 0
        StadoBusqueda = 1
        If Me.TxtSoNombre.Text <> Nothing Then
            DS.Reset()
        End If
        If Trim(Me.TxtCodAS.Text) <> "" Or Trim(Me.TxtCodBuxy.Text) <> "" Then
            BusquedaDatosSocios()
            Porcentaje_ahorro()
            CargarDatosGrid_beneficiarios()
            SumaPorcentajesBeneficiarios()
        Else
            Dim Prin As New Busquedas_empleados_avicola
            Prin.Compañia_Value = Me.CmbCompania.SelectedValue
            Prin.CbxCompania.Enabled = False
            AppPath = System.IO.Directory.GetCurrentDirectory
            Prin.ShowDialog()
            If ParamcodigoBux <> Nothing Or ParamcodigoAs <> "" Then
                Me.TxtCodBuxy.Text = ParamcodigoBux
                Me.TxtCodAS.Text = ParamcodigoAs
                BusquedaDatosSocios()
                CargarDatosGrid_beneficiarios()
                SumaPorcentajesBeneficiarios()
            End If
        End If
        Me.Txt_por_ahorrar_total.Text = 2.5
        Me.Btn_so_agregar.Focus()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        CargarDatosGrid_beneficiarios()
    End Sub

    Sub AgregarAsociacion()
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_ADD_SOCIEDAD'" & Compañia & "','" & Me.TxtCodBuxy.Text & "','" & Me.TxtCodAS.Text & "','2','INGRESO','" & Usuario & "','U'"
            MiddleConnection()
            AhorroSocio()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Sub AhorroSocio()
        Try
            OpenConnection()
            SQL = "Execute sp_COOPERATIVA_CATALOGO_SOCIOS_PORCENTAJE_AHORRO_HISTORIAL " & Compañia & "," & Me.TxtCodBuxy.Text & ",'" & Me.TxtCodAS.Text & "'," & Val(Me.Txt_por_ahorrar_total.Text) & "," & Val(Me.Txt_ahorrar_total.Text) & ",'" & Usuario & "','I'"
            MiddleConnection()
            MessageBox.Show("El nuevo socio fue agregado con éxito...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Btn_so_limpiar_Click(Btn_Socio_limpiar, System.EventArgs.Empty)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub
  
    Private Sub Btn_so_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_so_agregar.Click
        If MsgBox("Desea adicionar nuevo empleado como socio?", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then
            If Trim(Me.TxtSoNombre.Text) = Nothing Then
                MessageBox.Show("No hay ninguna persona seleccionada...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtCodAS.Focus()
            ElseIf Val(Me.Txt_ahorrar_total.Text) < 2.5 Then
                MessageBox.Show("No se ha establecido un porcentaje de ahorro para el nuevo socio...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.TxtCodAS.Focus()
            Else
                AgregarAsociacion()
            End If
        End If
        Me.Btn_Socio_limpiar.Focus()
    End Sub

    Private Sub Txt_por_ahorrar_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_por_ahorrar_total.TextChanged
        If Me.Txt_sueldo_mensual.Text = Nothing And contador = 1 Then
            Me.TxtCodAS.Focus()
            MessageBox.Show("NO se ha seleccionado ningún empleado todavia...!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodBuxy.KeyPress, TxtCodAS.KeyPress, Txt_be_telefono2.KeyPress, Txt_be_telefono1.KeyPress, Txt_be_porcentaje.KeyPress, Txt_be_nombre.KeyPress, Txt_be_direccion.KeyPress, Txt_be_apellido.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If Me.TxtCodAS.Text <> Nothing Then
                Me.TxtCodAS.Text = Me.TxtCodAS.Text.PadLeft(6, "0")
                ParamcodigoAs = Me.TxtCodAS.Text
                ParamcodigoBux = 0
                BusquedaDatosSocios()
                If Hay_Datos Then
                    Porcentaje_ahorro()
                    CargarDatosGrid_beneficiarios()
                    SumaPorcentajesBeneficiarios()
                    Me.Txt_por_ahorrar_total.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Txt_por_ahorrar_total_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_por_ahorrar_total.Enter
        If Val(Me.Txt_por_ahorrar_total.Text) > 0 Then
            Me.Btn_so_agregar.Focus()
        End If
    End Sub
End Class
