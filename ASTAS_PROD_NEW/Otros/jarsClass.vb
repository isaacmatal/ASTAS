Imports System.Data.SqlClient

Public Class jarsClass

    'herencia
    Inherits cmbFill

    'Declaracion de variables
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader    
    Dim sql As String

    'CONSTRUCTOR, CADA VEZ QUE SE INSTANCIA UN OBJETO DE ESTA CLASE SE PASA LA CONEXION SIN NECESIDAD DE OBTENERLA
    'EN CADA FUNCION
    Public Sub New()
        Conexion_ = devuelveCadenaConexion()

    End Sub

    ''' <summary>
    ''' EJECUTA UNA SENTENCIA SQL Y CON EL RESULTADO LLENA UN DATASET
    ''' </summary>
    Public Function ejecutaSQL_llenaDataset(ByVal consulta As String, ByVal tabla As String) As DataSet
        Try
            DS.Reset()
            abrirConexion()
            Comando_ = New SqlCommand(consulta, Conexion_)
            Comando_.CommandTimeout = 7200
            DS = New DataSet()
            DataAdapter_ = New SqlDataAdapter(Comando_)
            DataAdapter_.Fill(DS, tabla)
            Conexion_.Close()
        Catch ex As Exception
            'MSJ DE ERROR
            Conexion_.Close()
            MessageBox.Show(ex.Message, "Error...ejecutaSQL_llenaDataset!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return DS
    End Function

    ''' <summary>
    ''' FUNCION QUE LLENA UN DATATABLE CON EL RESULTADO DE UNA CONSULTA SQL
    ''' PARAMETROS: CONSULTA SQL   TIPO DATO: STRING
    ''' </summary>
    Public Function ejecutaSQLl_llenaDTABLE(ByVal consulta As String) As DataTable
        Try
            'ABRE CONEXION
            Conexion_.Open()
            'LLAMA FUNCION QUE LLENA DATATABLE SEGUN LA CONSULTA
            Table = LlenaDT(Conexion_, DataAdapter_, Comando_, consulta, Table)
            'CIERRA CONEXION
            Conexion_.Close()
            'SI HAY ALGUN ERROR SE DEBE ENVIAR UN MSJ
        Catch ex As Exception
            'MSJ DE ERROR
            Conexion_.Close()
            MessageBox.Show(ex.Message, "Error...ejecutaSQLl_llenaDTABLE!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Table
    End Function

    ''' <summary>
    '''FUNCION QUE CARGA UN COMBOBOX CON DATOS DE LA BD
    '''PARAMETROS: COMBOBOX                       TIPO DATO: COMBOBOX
    '''PARAMETROS: CONSULTA SQL                   TIPO DATO: STRING
    '''PARAMETROS: NOMBRE DE LA TABLA DE LA BD    TIPO DATO: STRING
    '''PARAMETROS: NOMBRE DE LA COLUMNA A CARGAR  TIPO DATO: STRING
    ''' </summary>
    Public Sub CargarCombo(ByVal Cmb As ComboBox, ByVal consulta As String, ByVal valueMember As String, ByVal DisplayMember As String)
        Try
            'SE LLENA UN DATATABLE
            ejecutaSQLl_llenaDTABLE(consulta)

            If Table.Rows.Count > 0 Then
                'SE LE PASA COMO FUENTE AL COMBO
                Cmb.DataSource = Table
                'SE LE INDICA EL NOMBRE DE LA TABLA
                Cmb.ValueMember = valueMember
                'SE LE INDICA EL NOMBRE DE LA COLUMNA
                Cmb.DisplayMember = DisplayMember
                'SE ESTABLECE EL VALOR INCIAL AL CARGAR EL COMBO
                If Cmb.Items.Count > 0 Then
                    Cmb.SelectedIndex = 0
                End If
                'SI SE GENERA UN ERROR SE GENERA UN MSJ
            Else
                Cmb.DataSource = Nothing
            End If
        Catch ex As Exception
            'MSJ
            MessageBox.Show(ex.Message, "Error...CargarCombo!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Llena ComboBox de Proveedores
    Public Sub CargarProveedores(ByVal Compañia As Integer, ByVal Cmb As ComboBox)

        sql = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES" & _
        " " & Compañia & ", 1, 'ncr','nit','nombre_proveedor','nombrecomercial','direccion',0,2,0,'codigo astas','system','SP'"
        CargarCombo(Cmb, sql, "Código", "Proveedor Nombre Legal")
        
    End Sub

    'Llena ComboBox de Proveedores
    Public Sub Tipo_Documento_Contable(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox)
        sql = "Exec sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO " & Compañia & ", " & Bandera & ""
        CargarCombo(Cmb, sql, "TIPO_DOCUMENTO", "DESCRIPCION_TIPO_DOCUMENTO")
    End Sub

    ''' <summary>
    ''' Llena ComboBox de Bodegas por usuarios
    ''' Solo nuestra las bodegas de los cuales los usuarios tiene acceso enviar Bandera=7
    ''' Muestra todas las bodegas sin restriccion de usuarios enviar Bandera=1
    ''' </summary>
    Public Sub CargaBodegas(ByVal Compañia As Integer, ByVal cmb As ComboBox, ByVal Bandera As Integer, Optional ByVal Bodega As Integer = 0)
        sql = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS " & Bandera & ", " & Compañia & ", " & Bodega & " ,'" & Usuario & "'"
        CargarCombo(cmb, sql, "BODEGA", "DESCRIPCION_BODEGA")
    End Sub

    'ABRE LA CONEXION 
    Public Sub abrirConexion()
        Try
            Conexion_.Open()
        Catch ex As Exception
            msjError(ex, BaseDatos)
            'MessageBox.Show("Error en la conexion a Base de Datos: " & BaseDatos & vbCrLf & ex.Message)
        End Try        
    End Sub
    'CIERRA LA CONEXION
    Public Sub cerrarConexion()
        Try
            Conexion_.Close()
        Catch ex As Exception
            msjError(ex, BaseDatos)
            'MessageBox.Show("Error...Al cerrar la conexion")
        End Try        
    End Sub
    ''' <summary> 
    ''' Lee el datareader y retorna un valor que contiene dicho datareader como string
    ''' </summary>
    Public Function leerDataeader(ByVal consulta As String, ByVal valor As Integer, Optional ByVal ShowMsjError As Boolean = True)
        Dim retornar As String = String.Empty
        Try
            DataReader_ = RetornaValor_ConsultaSQL(consulta)
            While (DataReader_.Read())
                retornar = DataReader_(valor).ToString().Trim()
            End While
        Catch ex As Exception
            'MSJ DE ERROR
            If ShowMsjError Then
                MessageBox.Show(ex.Message, "Error...leerDataeader!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            cerrarConexion()
        End Try
        Return retornar
    End Function

    ''' <summary> 
    ''' Ejecuta una consulta y retorna un datareader con los resultados
    ''' </summary>
    Public Function RetornaValor_ConsultaSQL(ByVal consulta As String) As SqlDataReader
        abrirConexion()
        Try
            Comando_ = New SqlCommand(consulta, Conexion_)
            Comando_.CommandTimeout = 7200
            DataReader_ = Comando_.ExecuteReader()
        Catch ex As Exception
            DataReader_ = Nothing
        End Try
        Return DataReader_
    End Function


    ''' <summary> 
    ''' EJECUTA UNA CONSULTA CUALQUIERA SIN DEVOLVER NADA, PREFERIBLEMENTE PARA EJECUTAR PROCEDIMIENTOS, FUNCIONES, ETC QUE SOLO REALIZAN CUALQUIER CAMBIO DENTRO DE LA BD
    ''' </summary> 
    Public Sub Ejecutar_ConsultaSQL(ByVal consulta As String)
        Try
            abrirConexion()
            Comando_ = New SqlCommand(consulta, Conexion_)
            Comando_.CommandTimeout = 7200
            Comando_.ExecuteNonQuery()
            cerrarConexion()
        Catch ex As Exception
            'MSJ DE ERROR
            cerrarConexion()
            MessageBox.Show(ex.Message, "Error...Ejecutar_ConsultaSQL!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Llena ComboBox del Tipo de Documento Inventario y ver si requiere costo y documento
    Public Function CargaTipoDocumentoInventario_rc(ByVal Compañia As Integer, ByVal Tipo_documento As Integer, ByVal Bandera As Integer, ByVal Txt_RC As TextBox, ByVal Txt_RD As TextBox) As String

        'SE PREPARA CONSULTA SQL SEGUN PARAMETROS        
        sql = "Execute [sp_INVENTARIOS_CATALOGO_TIPO_DOCUMENTO_RCD]"
        sql &= Compañia
        sql &= ", " & Tipo_documento
        sql &= ", " & Bandera

        'SE LLENA EL DATATABLE
        ejecutaSQLl_llenaDTABLE(sql)
        'SE VERIFICA VALOR COMVIRTIENDOLO EN STRING
        Txt_RC.Text = Table.Rows(0).Item("REQUIERE_COSTO").ToString()
        Txt_RD.Text = Table.Rows(0).Item("REQUIERE_DOCUMENTO").ToString()
        TipoDocto = Table.Rows(0).Item("TIPO_DOCUMENTO_CONTABLE")
        'SE RETORNA STRING
        Return Txt_RC.Text

    End Function
    'DEVUELVE O ESTABLECE UN SQLDATAADAPTER
    Property DataAdapter() As SqlDataAdapter
        Get
            Return DataAdapter_
        End Get
        Set(ByVal value As SqlDataAdapter)
            DataAdapter_ = value
        End Set
    End Property
    'EJECUTA UNA CONSULTA Y DEVUELVE UN SQLDATAADAPTER
    Sub MiddleConnection(ByVal sql)
        Try
            abrirConexion()
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.CommandTimeout = 7200
            DataAdapter_ = New SqlDataAdapter(Comando_)
            cerrarConexion()
        Catch ex As Exception
            'MSJ DE ERROR
            cerrarConexion()
            MessageBox.Show(ex.Message, "Error...MiddleConnection!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' EJECUTA COMANDOS UTIL PARA CUANDO HAY INSTRUCCIONES SQL CON PARAMETROS DE TIPO: IMAGE
    ''' RETORNA EL NUMERO DE FILAS AFECTADAS.
    ''' </summary>
    Public Function ejecutarComandoSql(ByVal cmd As SqlCommand) As Integer
        Dim actualizados As Integer = 0
        Try
            abrirConexion()
            cmd.CommandTimeout = 7200
            cmd.Connection = Conexion_
            actualizados = cmd.ExecuteNonQuery()
            cerrarConexion()
        Catch ex As Exception
            'MSJ DE ERROR
            cerrarConexion()
            MessageBox.Show(ex.Message, "Error...ejecutarComandoSql!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return actualizados
    End Function

    ''' <summary>
    ''' EJECUTA UN COMANDO Y DEVUELVE EL CONJUNTO DE RESULTADOS
    ''' </summary>
    Public Function obtenerDatos(ByVal cmd As SqlCommand, Optional ByVal verError As Integer = 0) As DataTable
        Dim dt As New DataTable("Datos")
        Try
            abrirConexion()
            cmd.Connection = Conexion_
            cmd.CommandTimeout = 7200
            'CARGAMOS EL DATATABLE CON EL CONJUNTO DE RESULTADOS
            dt.Load(cmd.ExecuteReader())
            cerrarConexion()
        Catch ex As Exception
            'MSJ DE ERROR
            cerrarConexion()
            If verError = 0 Then
                MessageBox.Show(ex.Message, "Error...obtenerDatos!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' RETORNA EL PRIMER VALOR DE LA PRIMERA FILA Y COLUMNA
    ''' </summary>
    Public Function obtenerEscalar(ByVal consulta As String, Optional ByVal verError As Boolean = True) As Object
        Dim retorno As Object = Nothing
        Try
            abrirConexion()
            Comando_ = New SqlCommand(consulta, Conexion_)
            Comando_.CommandTimeout = 7200
            retorno = Comando_.ExecuteScalar()
        Catch ex As Exception
            'MSJ DE ERROR
            If verError Then
                MessageBox.Show(ex.Message, "Error...obtenerEscalar!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            cerrarConexion()
        End Try
        Return retorno
    End Function

    ''' <summary>
    ''' RETORNA UN DATASET QUE REPRESENTA EL CONJUNTO DE 
    ''' RESULTADOS DE UNA CONSULTA SQL
    ''' </summary>
    Public Function ObtenerDataSet(ByVal consulta As String) As DataSet
        Dim retorno As New DataSet("Datos")
        Dim tabla1 As New DataTable("Datos1")
        Dim tabla2 As New DataTable("Datos2")

        retorno.Tables.Add(tabla1)
        retorno.Tables.Add(tabla2)
        abrirConexion()
        Try
            Dim command As New SqlCommand(consulta, Conexion_)

            retorno.Load(command.ExecuteReader(), LoadOption.PreserveChanges, tabla1, tabla2)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error...ObtenerDataSet!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cerrarConexion()
        Return retorno
    End Function
    'Public Sub imprimeCheque(ByVal Cheque As Integer, ByVal NomProv As String, ByVal total_cheque As Double)
    '    Dim VLetras As New NumeroLetras
    '    Dim DT01 As DataTable
    '    Dim sqlCmd As New SqlCommand
    '    Dim ImpCheque As New Contabilidad_CuentasxPagar_Emitir_Cheque_Rpt
    '    Dim letras As String
    '    Try
    '        letras = VLetras.Letras(total_cheque.ToString)
    '        sql = "EXEC sp_CONTABILIDAD_EMITIR_CHEQUE "
    '        sql &= Cheque
    '        sql &= ", '" & NomProv & "'"
    '        sql &= ", " & total_cheque
    '        sql &= ", '" & letras & "'"
    '        sqlCmd.CommandText = sql
    '        DT01 = obtenerDatos(sqlCmd)
    '        ImpCheque.SetDataSource(DT01)
    '        ImpCheque.PrintToPrinter(1, False, 1, 1)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error...imprimeCheque!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Public Sub imprimeCheque2(ByVal Cheque As Integer, ByVal NomProv As String, ByVal total_cheque As Double, ByVal Nego As Boolean)
    '    Dim VLetras As New NumeroLetras
    '    Dim DT01 As DataTable
    '    Dim sqlCmd As New SqlCommand
    '    Dim ImpCheque As New Contabilidad_CuentasxPagar_Emitir_Cheque2_Rpt
    '    Dim letras As String
    '    Try
    '        letras = VLetras.Letras(total_cheque.ToString)
    '        sql = "EXEC sp_CONTABILIDAD_EMITIR_CHEQUE2 "
    '        sql &= Cheque
    '        sql &= ", '" & NomProv & "'"
    '        sql &= ", " & total_cheque
    '        sql &= ", '" & letras & "'"
    '        sql &= ", " & IIf(Nego, 1, 0)
    '        sqlCmd.CommandText = sql
    '        DT01 = obtenerDatos(sqlCmd)
    '        ImpCheque.SetDataSource(DT01)
    '        ImpCheque.PrintToPrinter(1, False, 1, 1)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error...imprimeCheque2!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Public Function IngresarCostoUeps(ByVal Compañia, ByVal Bodega, ByVal Producto, ByVal entrada, ByVal salidas, ByVal bandera, Optional ByVal costo_uni = 0)
        Dim posicion As Integer
        sql = "Execute sp_INVENTARIOS_INGRESAR_COMPRAS "
        sql &= "@COMPAÑIA = " & Compañia
        sql &= ",@BODEGA = " & Val(Bodega)
        sql &= ",@PRODUCTO = " & Val(Producto)
        sql &= ",@ENTRADAS = " & Val(entrada)
        sql &= ",@SALIDAS = " & Val(salidas)
        sql &= ",@COSTO_UNI = " & Val(costo_uni)
        sql &= ",@BANDERA = '" & bandera & "'"
        If Val(costo_uni) <> 0 Then
            posicion = 0
        Else
            posicion = 3
        End If
        Return leerDataeader(sql, posicion)
    End Function
    'Public Function CargarConciliacionBancaria(ByVal consulta As String) As Conciliaciones_Bancarias_Source
    '    Dim tbl As New Conciliaciones_Bancarias_Source
    '    Try
    '        abrirConexion()
    '        Dim cmd As New SqlCommand
    '        cmd.Connection = Me.Conexion_
    '        cmd.CommandText = consulta
    '        tbl.Load(cmd.ExecuteReader, LoadOption.OverwriteChanges, tbl.Tables(0), tbl.Tables(1))

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Carga de Datos (CargarConciliacionBancaria)")
    '    End Try
    '    cerrarConexion()
    '    Return tbl
    'End Function
    'Public Function SocioBloqueado(ByVal CodSocio As String) As Boolean
    '    Dim Bloqueado As Boolean
    '    Dim nombre As String
    '    sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & CodSocio & "'"
    '    Bloqueado = obtenerEscalar(sql)
    '    If Bloqueado Then
    '        sql = "SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & CodSocio & "'"
    '        nombre = obtenerEscalar(sql)
    '        MsgBox("Bloqueado por falta de pago." & vbCrLf & "Solicitar autorización a Gerencia.", MsgBoxStyle.Critical, nombre)
    '    End If
    '    Return Bloqueado
    'End Function
    Public Function SocioBloqueado(ByVal CodSocio As String) As Boolean
        Dim Bloqueado As Boolean
        Dim NotieneAcceso As Boolean
        Dim monto_maximo As Double
        Dim nombre As String
        sql = "SELECT BLOQUEADO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodSocio
        Bloqueado = obtenerEscalar(sql)
        sql = "SELECT monto_maximo FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodSocio
        monto_maximo = obtenerEscalar(sql)
        If Bloqueado = True And monto_maximo = 0 Then
            sql = "SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & CodSocio
            nombre = obtenerEscalar(sql)
            MsgBox("Bloqueado." & vbCrLf & "Solicitar autorización a Gerencia.", MsgBoxStyle.Critical, nombre)
            NotieneAcceso = True
        Else
            NotieneAcceso = False
        End If
        Return NotieneAcceso
    End Function

    Public Sub msjError(ByVal ex As Exception, Optional ByVal Modulo As String = "")
        Dim msj As String
        Dim Titulo As String = "Runtime Error "
        msj = ex.Message & vbCrLf
        If ex.InnerException IsNot Nothing Then
            msj = ex.InnerException.ToString & vbCrLf
        End If
        msj &= vbCrLf
        msj &= "Detalles Soporte Técnico:" & vbCrLf
        msj &= "---------------------------" & vbCrLf
        msj &= "Aplicación: " & ex.TargetSite.Module.Name & vbCrLf
        msj &= "Clase: " & ex.TargetSite.DeclaringType.Name & vbCrLf
        If ex.TargetSite.Module.Name.LastIndexOf("dll") > 0 Then
            msj &= "Procedimiento: " & Modulo & vbCrLf
            Titulo &= ex.TargetSite.Name
        Else
            msj &= "Procedimiento: " & ex.TargetSite.Name & vbCrLf
        End If
        If ex.StackTrace.LastIndexOf("línea") > 0 Or ex.StackTrace.LastIndexOf("line") > 0 Then
            msj &= "L" & ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":") + 2) & vbCrLf
        End If
        msj &= "Tipo: " & ex.GetType.Name & vbCrLf
        msj &= "Subtipo: " & ex.GetType.BaseType.Name
        MsgBox(msj, MsgBoxStyle.Information, Titulo)
    End Sub

    Public Function CheckForm(ByVal _form As String) As Form
        Dim Result As Form = Nothing
        Try
            For Each f As Form In Application.OpenForms
                If f.Name = _form Then
                    Result = f
                End If
            Next
        Catch ex As Exception
            Result = Nothing
        End Try
        Return Result
    End Function

    ''' <summary>
    ''' Recibe un DataGridView y devuelve un DataTable con los datos que contiene el DataGridView recibido
    ''' </summary>
    Public Function DataGridView_To_DataTable(ByVal dgv As DataGridView) As DataTable
        Dim dt As New DataTable
        For i As Integer = 0 To dgv.Columns.Count - 1
            dt.Columns.Add(dgv.Columns(i).Name, Type.GetType(dgv.Rows(0).Cells(i).FormattedValueType.FullName))
        Next
        For i As Integer = 0 To dgv.Rows.Count - 1
            dt.Rows.Add()
            For j As Integer = 0 To dgv.Columns.Count - 1
                dt.Rows(i).Item(j) = dgv.Rows(i).Cells(j).Value
            Next
        Next
        Return dt
    End Function
End Class
