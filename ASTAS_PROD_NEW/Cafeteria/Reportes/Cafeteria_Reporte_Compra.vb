Imports System.Data.SqlClient
Public Class Cafeteria_Reporte_Compra
    Dim c_data As New cmbFill
    Dim c_data1 As New jarsClass
    Dim Iniciando As Boolean
    Dim ds As New DataSet
    Dim SQL As String
    Dim Tiempo As String
    'Dim doc As New Reporte1
    Dim dtareader As SqlDataReader
    Private Sub Cafeteria_Reporte_Compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        c_data.CargaCompañia(Me.cmbCOMPAÑIA)
        CargaBodegas(Compañia, 5, cmbBODEGA, "Bodega", "Descripción")
        c_data1.CargarCombo(Me.cmbTiempo, "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA " & Me.cmbCOMPAÑIA.SelectedValue.ToString() & ",'S'", "Tiempo de Comida", "Descripción")
    End Sub

    Private Sub CargaBodegas(ByVal Compañia As Object, ByVal Bandera As Object, ByVal Cmb As ComboBox, ByVal value As Object, ByVal display As Object)
        'Dim i As Integer
        Try
            Sql = "Execute sp_INVENTARIOS_CATALOGO_BODEGAS "
            Sql &= "@BANDERA=" & Bandera
            Sql &= ",@COMPAÑIA= " & Compañia
            Sql &= ",@USUARIO= '" & Usuario & "'"
            c_data1.CargarCombo(Cmb, SQL, value, display)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim Tabla As DataTable
            Dim sqlCmd As New SqlCommand
            Dim rptver As New frmReportes_Ver
            'Dim reporte_30 As New Cafeteria_Reporte_Compra_RPT
            'If CheckBox1.Checked = True Then
            '    If Me.CheckBox2.Checked = True Then
            '        sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@PROVEEDOR=" & 0 & ", @BANDERA=7, @TIEMPO=" & 0
            '    Else
            '        If TxtProveedor_Codigo.Text = "" Then
            '            MsgBox("INGRESE NUMERO DE PROVEEDOR")
            '            Return
            '        Else
            '            sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@PROVEEDOR=" & TxtProveedor_Codigo.Text & ", @BANDERA=1, @TIEMPO=" & 0
            '        End If
            '    End If
            'Else
            '    If Me.CheckBox2.Checked = True Then
            '        sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@PROVEEDOR=" & 0 & ", @BANDERA=7, @TIEMPO=" & cmbTiempo.SelectedValue
            '    Else
            '        If TxtProveedor_Codigo.Text = "" Then
            '            MsgBox("INGRESE NUMERO DE PROVEEDOR")
            '            Return
            '        Else
            '            sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_GENERADOR_REPORTES @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@PROVEEDOR=" & TxtProveedor_Codigo.Text & ", @BANDERA=1, @TIEMPO=" & cmbTiempo.SelectedValue
            '        End If
            '    End If
            'End If
            Dim reporte_30 As New Cafeteria_Reporte_Compras_Sugeridas
            If CheckBox1.Checked = True Then
                If Me.CheckBox2.Checked = True Then
                    sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_REP_COMPRAS_SUGERIDAS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@TIEMPO=" & 0 & ",@PROVEEDOR=" & 0
                Else
                    If TxtProveedor_Codigo.Text = "" Then
                        MsgBox("INGRESE NUMERO DE PROVEEDOR")
                        Return
                    Else
                        sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_REP_COMPRAS_SUGERIDAS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "',@TIEMPO=" & 0 & ",@PROVEEDOR=" & TxtProveedor_Codigo.Text
                    End If
                End If
            Else
                If Me.CheckBox2.Checked = True Then
                    sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_REP_COMPRAS_SUGERIDAS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "', @TIEMPO=" & cmbTiempo.SelectedValue & ",@PROVEEDOR=" & 0
                Else
                    If TxtProveedor_Codigo.Text = "" Then
                        MsgBox("INGRESE NUMERO DE PROVEEDOR")
                        Return
                    Else
                        sqlCmd.CommandText = "EXECUTE sp_CAFETERIA_REP_COMPRAS_SUGERIDAS @COMPAÑIA=" & Compañia & ",@BODEGA=" & cmbBODEGA.SelectedValue & ",@FECHA1='" & Format(Me.fecha_desde.Value, "dd-MM-yyyy 00:00:01") & "', @FECHA2='" & Format(Me.fecha_hasta.Value, "dd-MM-yyyy 00:00:01") & "', @TIEMPO=" & cmbTiempo.SelectedValue & ",@PROVEEDOR=" & TxtProveedor_Codigo.Text
                    End If
                End If
            End If
            Tabla = c_data1.obtenerDatos(sqlCmd)
            reporte_30.SetDataSource(Tabla)
            CrystalReportViewer1.ReportSource = reporte_30
        Catch ex As Exception
            MsgBox("Aviso...Ocurrio un problema a la hora de generar el documento, revise los parametros!", MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbTiempo.Enabled = False
        Else
            cmbTiempo.Enabled = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Busqueda As New FrmBuscarProveedor
        Busqueda.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
        Busqueda.CbxCompania.Enabled = False
        Busqueda.ShowDialog()
        If ParamNomProvee <> "" Then
            Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
            Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
            BuscarProveedor(Me.cmbCOMPAÑIA.SelectedValue, Me.TxtProveedor_Codigo.Text)
        Else
            BuscarProveedor(0, 0)

        End If
        ParamCodProvee = Nothing
        ParamNomProvee = ""
    End Sub
    Private Sub BuscarProveedor(ByVal Compañia, ByVal Proveedor)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataReader_ As SqlDataReader
        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        'Dim i As Integer
        Try
            Conexion_.Open()
            Sql = "SELECT * FROM CONTABILIDAD_CATALOGO_PROVEEDORES WHERE COMPAÑIA = "
            Sql &= Compañia & " AND PROVEEDOR = " & Proveedor
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read Then
                Me.TxtProveedor_NombreLegal.Text = DataReader_.Item("NOMBRE_PROVEEDOR")
                Me.TxtProveedor_NombreComercial.Text = DataReader_.Item("NOMBRE_COMERCIAL")
                Me.TxtProveedor_RegistroFiscal.Text = DataReader_.Item("NRC")
                Me.TxtProveedor_Nit.Text = DataReader_.Item("NIT")
                Me.TxtProveedor_Direccion.Text = DataReader_.Item("DIRECCION")
                
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub TxtProveedor_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProveedor_Codigo.TextChanged
        If Me.TxtProveedor_Codigo.Text <> "" Then
            Try
                Dim Sql As String
                Sql = "SELECT PROVEEDOR, NOMBRE_PROVEEDOR,NOMBRE_COMERCIAL,NRC,NIT,DIRECCION,TIPO_PROVEEDOR,FORMA_PAGO,CONDICION_PAGO FROM CONTABILIDAD_CATALOGO_PROVEEDORES"
                Sql = Sql & " WHERE COMPAÑIA = " & Compañia & " AND  PROVEEDOR = " & Me.TxtProveedor_Codigo.Text

                Dim Conexion_Track As New SqlConnection
                Dim Comando_Track As SqlCommand
                Dim DataAdapter As SqlDataAdapter
                'Dim DataReader As SqlDataReader
                Dim DS As New DataSet()

                Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
                Try
                    Conexion_Track.Open()
                    Comando_Track = New SqlCommand(Sql, Conexion_Track)
                    DataAdapter = New SqlDataAdapter(Comando_Track)
                    'DS = New DataTable("Datos")
                    DataAdapter.Fill(DS)
                    If DS.Tables(0).Rows.Count = 0 Then
                        MsgBox("¡No se encontró ningun proveedor!", MsgBoxStyle.Question, "Mensaje")
                        LimpiaCamposProveedor()
                    Else
                        Me.TxtProveedor_Codigo.Text = DS.Tables(0).Rows(0).Item(0)
                        Me.TxtProveedor_NombreLegal.Text = DS.Tables(0).Rows(0).Item(1)
                        Me.TxtProveedor_NombreComercial.Text = DS.Tables(0).Rows(0).Item(2)
                        Me.TxtProveedor_RegistroFiscal.Text = DS.Tables(0).Rows(0).Item(3)
                        Me.TxtProveedor_Nit.Text = DS.Tables(0).Rows(0).Item(4)
                        Me.TxtProveedor_Direccion.Text = DS.Tables(0).Rows(0).Item(5)
                        
                    End If
                Catch ex As Exception
                    'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
                Conexion_Track.Close()
            Catch ex As Exception

            End Try

        Else
            LimpiaCamposProveedor()
        End If

    End Sub
    Private Sub LimpiaCamposProveedor()
        Me.TxtProveedor_Codigo.Text = ""
        Me.TxtProveedor_NombreLegal.Text = ""
        Me.TxtProveedor_NombreComercial.Text = ""
        Me.TxtProveedor_RegistroFiscal.Text = ""
        Me.TxtProveedor_Nit.Text = ""
        Me.TxtProveedor_Direccion.Text = ""
    End Sub

    Private Sub TxtProveedor_Codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProveedor_Codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
            'Else
            '    e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            Dim Busqueda As New FrmBuscarProveedor(TxtProveedor_Codigo.Text)
            Busqueda.Compañia_Value = Me.cmbCOMPAÑIA.SelectedValue
            Busqueda.CbxCompania.Enabled = False
            Busqueda.ShowDialog()

            If ParamNomProvee <> "" Then
                Me.TxtProveedor_Codigo.Text = ParamCodProvee.ToString
                Me.TxtProveedor_NombreLegal.Text = ParamNomProvee
                BuscarProveedor(Me.cmbCOMPAÑIA.SelectedValue, Me.TxtProveedor_Codigo.Text)
            Else
                BuscarProveedor(0, 0)

            End If
            ParamCodProvee = Nothing
            ParamNomProvee = ""

        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiaCamposProveedor()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TxtProveedor_Codigo.Text = ""
            TxtProveedor_Codigo.Enabled = False
            BtnBuscar.Enabled = False
            BtnLimpiar.Enabled = False
        Else
            TxtProveedor_Codigo.Enabled = True
            BtnBuscar.Enabled = True
            BtnLimpiar.Enabled = True
        End If
    End Sub
End Class