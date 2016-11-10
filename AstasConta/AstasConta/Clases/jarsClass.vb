Imports System.Data.SqlClient

Public Class jarsClass

    'herencia
    Inherits cmbFill

    'Declaracion de variables
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader    
    Dim sql As String

    'CONSTRUCTOR, CADA VES QUE SE INSTANCIA UN OBJETO DE ESTA CLASE SE PASA LA CONEXION SIN NECESIDAD DE OBTENERLA
    'EN CADA FUNCION
    Public Sub New()
        Conexion_ = devuelveCadenaConexion()
    End Sub

    'EJECUTA UNA SENTENCIA SQL Y CON EL RESULTADO LLENA UN DATASET
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

    'FUNCION QUE LLENA UN DATATABLE CON EL RESULTADO DE UNA CONSULTA SQL
    'PARAMETROS: CONSULTA SQL   TIPO DATO: STRING
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
    'FUNCION QUE CARGA UN COMBOBOX CON DATOS DE LA BD
    'PARAMETROS: COMBOBOX                       TIPODATO COMBOBOX
    'PARAMETROS: CONSULTA SQL                   TIPO DATO: STRING
    'PARAMETROS: NOMBRE DE LA TABLA DE LA BD    TIPO DATO: STRING
    'PARAMETROS: NOMBRE DE LA COLUMNA A CARGAR  TIPO DATO: STRING
    Public Sub CargarCombo(ByVal Cmb As ComboBox, ByVal consulta As String, ByVal valueMember As String, ByVal DisplayMember As String)
        Try            
            'SE LLENA UN DATATABLE
            ejecutaSQLl_llenaDTABLE(consulta)
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
        Catch ex As Exception
            'MSJ
            MessageBox.Show(ex.Message, "Error...CargarCombo!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Llena ComboBox de Proveedores
    'Public Sub CargarProveedores(ByVal Compañia As Integer, ByVal Cmb As ComboBox)

    '    sql = "Execute sp_CONTABILIDAD_CATALOGO_PROVEEDORES" & _
    '    " " & Compañia & ", 1, 'ncr','nit','nombre_proveedor','nombrecomercial','direccion',0,2,0,'codigo astas','system','SP'"
    '    CargarCombo(Cmb, sql, "Código", "Proveedor Nombre Legal")

    'End Sub

    'Llena ComboBox de Proveedores
    Public Sub Tipo_Documento_Contable(ByVal Compañia As Integer, ByVal Bandera As Integer, ByVal Cmb As ComboBox)
        sql = "Exec sp_CONTABILIDAD_CATALOGO_TIPO_DOCUMENTO " & Compañia & ", " & Bandera & ""
        CargarCombo(Cmb, sql, "TIPO_DOCUMENTO", "DESCRIPCION_TIPO_DOCUMENTO")
    End Sub

    'Llena ComboBox de Bodegas por usuarios
    'Solo nuestra las bodegas de los cuales los usuarios tiene acceso enviar Bandera=7
    'Muestra todas las bodegas sin restriccion de usuarios enviar Bandera=1
    Public Sub CargaBodegas(ByVal Compañia As Integer, ByVal cmb As ComboBox, ByVal Bandera As Integer, Optional ByVal Bodega As Integer = 0)
        sql = " Execute sp_INVENTARIOS_CATALOGO_BODEGAS " & Bandera & ", " & Compañia & ", " & Bodega & " ,'" & Usuario & "'"
        CargarCombo(cmb, sql, "BODEGA", "DESCRIPCION_BODEGA")
    End Sub

    'ABRE LA CONEXION 
    Public Sub abrirConexion()
        Try
            Conexion_.Open()
        Catch ex As Exception
            MessageBox.Show("Error...Al abrir la conexion")
        End Try        
    End Sub
    'CIERRA LA CONEXION
    Public Sub cerrarConexion()
        Try
            Conexion_.Close()
        Catch ex As Exception
            MessageBox.Show("Error...Al cerrar la conexion")
        End Try        
    End Sub
    'Lee el datareader y retorna un valor que contiene dicho datareader como string
    Public Function leerDataeader(ByVal consulta, ByVal valor)
        Dim retornar As String = String.Empty
        Try
            DataReader_ = RetornaValor_ConsultaSQL(consulta)
            While (DataReader_.Read())
                retornar = DataReader_(valor).ToString().Trim()
            End While
            cerrarConexion()
        Catch ex As Exception
            'MSJ DE ERROR
            cerrarConexion()
            MessageBox.Show(ex.Message, "Error...leerDataeader!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return retornar
    End Function
    'Ejecuta una consulta y retorna un datareader con los resultados
    Public Function RetornaValor_ConsultaSQL(ByVal consulta As String) As SqlDataReader
        abrirConexion()
        Comando_ = New SqlCommand(consulta, Conexion_)
        Comando_.CommandTimeout = 7200
        DataReader_ = Comando_.ExecuteReader()

        Return DataReader_
    End Function
    'EJECUTA UNA CONSULTA CUALQUIERA SIN DEVOLVER NADA, PREFERIBLEMENTE PARA EJECUTAR PROCEDIMIENTOS, 
    'FUNCIONES, ETC QUE SOLO REALIZAN CUALQUIER CAMBIO DENTRO DE LA BD
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
    'EJECUTA COMANDOS UTIL PARA CUANDO HAY INSTRUCCIONES SQL CON PARAMETROS DE TIPO: IMAGE
    'RETORNA EL NUMERO DE FILAS AFECTADAS.
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

    'EJECUTA UN COMANDO Y DEVUELVE EL CONJUNTO DE RESULTADOS
    Public Function obtenerDatos(ByVal cmd As SqlCommand) As DataTable
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
            MessageBox.Show(ex.Message, "Error...obtenerDatos!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function
    'RETORNA EL PRIMER VALOR DE LA PRIMERA FILA Y COLUMNA
    Public Function obtenerEscalar(ByVal consulta As String) As Object
        Dim retorno As Object = Nothing
        Try
            abrirConexion()
            Comando_ = New SqlCommand(consulta, Conexion_)
            Comando_.CommandTimeout = 7200
            retorno = Comando_.ExecuteScalar()
        Catch ex As Exception
            msjError(ex, "obtenerEscalar")
        Finally
            cerrarConexion()
        End Try
        Return retorno
    End Function
    'RETORNA UN DATASET QUE REPRESENTA EL CONJUNTO DE 
    'RESULTADOS DE UNA CONSULTA SQL
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

    Public Sub msjError(ByVal ex As Exception, ByVal Modulo As String)
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

End Class
