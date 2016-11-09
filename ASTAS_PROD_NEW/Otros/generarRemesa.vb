Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class generarRemesa

    'Constructores
    Dim fill As New cmbFill
    Dim PC As New Contabilidad_Procesos

    'Variables
    Dim sql As String

    'Conexion
    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DataReader_ As SqlDataReader

    'Variables publicas para los datos que iran a la remesa

    'Los valores son asignados desde el metodo "recibirParametros"
    'Para mostrar o no el mensaje
    Public sn As Boolean
    'Para indicar cuando abrir la carpeta donde esta el archivo generado
    Public abrirCarpeta As Boolean
    'Codigo empleado
    Public Cod_AS As String
    'Codigo buxis
    Public Cod_Buxis As Integer
    
    'Para almacenar que es un EXTRA, un PRESTAMO u otro
    Public movRemesa As String
    Public TipCta As String
    Public Bloque As String = String.Empty
    'Estas variables reciben su valor del metodo "estableceValores"

    'Cuenta de banco del socio
    Public ctaSocio As String
    'Nombre completo del socio
    Public socio As String
    'El monto por el que se le ha generado la solicitud
    Public monto As Double
    'El nombre del banco
    Public bco As String
    'Es la ubicacion del socio, son 3 digitos, el id de la division, seccion y departamento al que pertenecen
    Public ubicacion As String
    'Se usa para guardar la fecha completa
    Public fechaRemesa As String

    'Aqui se almacena la ruta donde se creara la carpeta y se guardara el archivo de las remesas
    Public ruta As String

    'Datos  proveedor
    Public cod_Prov As Integer
    Public proveedor As String
    Public cta_proveedor As String
    Public cta_proveedor_tipo As String

    'Datos para Banco America Central
    Public EncabBAC As String = String.Empty
    Public setEncab As Boolean = False
    Public NITSocio As String = String.Empty
    Public FechaDep As String = String.Empty
    Public TipoTran As String = String.Empty

    'Unico metodo al que pueden llamar en esta clase lo demás se ejecuta dentro de ella
    Public Sub recibirParametros(ByVal cia As Integer, ByVal bco As Integer, ByVal ctaBco As String, ByVal solicitud As Integer, ByVal codAS As String, ByVal codBuxis As Integer, ByVal movimiento As String)
        'Llama al metodo que llenara los valores
        If monto = 0 Then
            estableceValores(cia, codBuxis, codAS, solicitud, 0)
        End If
        'Asignamos el codigo del empleado y del buxis a sus respectivas variables para evitar estar
        'mandandolas entre metodos ademas que se usan seguido
        Cod_AS = codAS
        Cod_Buxis = codBuxis
        If TipCta Is Nothing Then
            TipCta = ObtenerTipoCtaBancoSocio()
        End If
        'Si los valores son diferentes a null entonces procede
        If ctaSocio <> Nothing And socio <> Nothing And monto <> 0.0 And bco <> Nothing Then
            'Carga la fecha completa en mayuscula
            If monto = 0 Then
                estableceValores(0, 0, Nothing, 0, 1)
            End If
            'Explicación: Temporalmente las remesas se están guardando en la unidad C: en una carpeta llamada
            'Remesas_Generadas, dentro de estas iran otras carpetas cuya nomenclatura se compone del mes actual
            'junto al año en curso (ej. 2011-Diciembre), y dentro de estas mismas estaran otras subcarpetas cuya nomenclatura es
            'la fecha completa (ej. 2011-12-08),donde se guardaran los .txt, que serían las remesas, las remesas
            'se nombran empezando con el nombre del banco, luego con el moviemiento ya sea EXTRA o PRESTAMO
            'y van seguidas por el numero de la caja chica y una C (ej. C147)
            'Se crea el nombre del archivo
            Dim nombreArchivo As String = Nothing
            'El nombre de la subcarpeta bancos
            Dim nombreSubCarpetaTerciaria As String = Nothing
            '1 es Agricola, 2 es Citi, 3 es Banco America Central
            If bco = 1 Then
                nombreArchivo = "PCBAC_" & movimiento.ToUpper & "_" & Bloque & ".txt"
                nombreSubCarpetaTerciaria = "BAC"
            ElseIf bco = 2 Then
                nombreArchivo = "CITI_" & movimiento.ToUpper & "_" & Bloque & ".txt"
                nombreSubCarpetaTerciaria = "CITI"
            ElseIf bco = 3 Then
                nombreArchivo = "BAC_" & movimiento.ToUpper & "_" & Bloque & ".prn"
                nombreSubCarpetaTerciaria = "BcoAC"
            ElseIf bco = 7 Then
                nombreArchivo = "GT_" & movimiento.ToUpper & "_" & Bloque & ".txt"
                nombreSubCarpetaTerciaria = "GT"
            Else
                nombreArchivo = "BCO_" & movimiento.ToUpper & "_" & Bloque & ".txt"
                nombreSubCarpetaTerciaria = "BCO"
            End If
            'El nombre de la subcarpeta diaria (ej. 2012-11-15)
            Dim nombreSubCarpetaSecundaria As String = Format(Now, "yyyy-MM-dd")
            'Cuando obtenemos el nombre del mes, lo devuelve con minuscula
            'Para obetener el nombre del mes con la primera letra en mayuscula:
            Dim letra As String = Nothing
            Dim Letras As String = Format(Now, "MMMM")
            'Substrae toda la palabra menos la 1era letra
            letra = Mid(Letras, 2, Letras.Length)
            'Saca la 1era letra
            Letras = Mid(Letras, 1, 1).ToUpper
            'Concatena
            Letras &= letra
            'El nombre de la subcarpeta mensual (ej. 2011-Diciembre)
            Dim nombreSubCarpetaPrincipal As String = Format(Now, "yyyy") & "-" & Letras
            'Metodo que crea las carpetas
            crearCarpetaPrincipal(nombreSubCarpetaPrincipal, nombreSubCarpetaSecundaria, nombreSubCarpetaTerciaria)
            'Guardamos el archivo, para eso mandamos la ruta ya completada, ponemos una / para indicarle que de ahi se creara el archivo
            'y luego llamamos al metodo con el detalle del archivo
            If setEncab Then
                guardarDatos(ruta & "/" & nombreArchivo, EncabBAC)
            End If
            guardarDatos(ruta & "/" & nombreArchivo, parteRemesaDetalle(bco))
        End If
    End Sub

    'Asiga los valores a los atributos de la clase
    Private Sub estableceValores(ByVal cia As Integer, ByVal buxis As Integer, ByVal codAS As String, ByVal solicitud As Integer, ByVal flag As Integer)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = " Execute Coo.sp_COOPERATIVA_VALORES_REMESAS "
            sql &= cia
            sql &= ", " & buxis
            sql &= ", '" & codAS & "'"
            sql &= ", " & solicitud
            sql &= ", " & flag
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader()
            If flag = 0 Then
                If DataReader_.Read = True Then
                    'Por cada variable publica que hay asigna un los valores obtenidos de la consulta
                    ctaSocio = DataReader_.Item("Cuenta Socio")
                    socio = DataReader_.Item("Socio")
                    monto = Format(DataReader_.Item("Monto"), "0.00")
                    bco = DataReader_.Item("Banco Remesa")
                    ubicacion = DataReader_.Item("Ubicación")
                    NITSocio = DataReader_.Item("NIT")
                Else
                    'En caso que no haya encontrado resultados dejara nulas las variables
                    ctaSocio = Nothing
                    socio = Nothing
                    monto = 0.0
                    bco = Nothing
                    ubicacion = Nothing
                End If
            ElseIf flag = 1 Then
                'Este flag se dejo para que devolviera la fecha entera ej. 08 de diciembre de 2011
                'Al final se convertía la cadena a mayúsculas pero se ha dejado por si se usa en un futuro cercano
                If DataReader_.Read = True Then
                    fechaRemesa = DataReader_.Item("Valor").ToString
                Else
                    'En caso de valores nulos se deja la variable nula
                    fechaRemesa = Nothing
                End If
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Function ObtenerTipoCtaBancoSocio() As String
        Dim Conx As SqlConnection
        Dim SqlCmd As SqlCommand
        Dim Tipo As String = String.Empty
        Try
            Conx = fill.devuelveCadenaConexion()
            Conx.Open()
            'sql = "SELECT TIPO_CUENTA_BANCARIA AS TIPCTA FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO_AS = '" & Cod_AS & "' AND CODIGO_EMPLEADO = " & Cod_Buxis
            sql = "SELECT TIPO_CUENTA_BANCARIA AS TIPCTA FROM COOPERATIVA_CATALOGO_SOCIOS WHERE COMPAÑIA = " & Compañia & " AND CODIGO_EMPLEADO = " & Cod_Buxis
            SqlCmd = New SqlCommand(sql, Conx)
            Tipo = SqlCmd.ExecuteScalar
            Conx.Close()
        Catch EX As Exception
            MsgBox(EX.Message, MsgBoxStyle.Information, "Error Generar Remesa")
        End Try
        Return Tipo
    End Function
    'Metodo que crea la carpeta principal temporalmente en la unida C: si ya existe no la crea
    Private Sub crearCarpetaPrincipal(ByVal subPrincipal As String, ByVal subSecundario As String, ByVal subTeciaria As String)
        'Aqui asignamos la ruta madre
        ruta = "C:\Remesas_Generadas"
        'Aqui le concatenamos las sub carpetas
        ruta &= "\" & subPrincipal & "\" & subSecundario & "\" & subTeciaria
        Try
            'Comprueba que no exista el directorio
            If Dir(ruta, vbDirectory) = vbNullString Then
                'Si no existe lo crea
                Call MkDir(ruta)
                'Mandamos el mensaje
                If sn = True Then
                    MsgBox("¡" & ruta & " creado con éxito!" & vbCrLf & "Sus remesas se almacenarán ahí.", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                'Si ya existe el directorio le decimos al usuario donde se guardaran las remesas
                If sn = True Then
                    MsgBox("¡Sus remesas se almacenarán en " & ruta & "!", MsgBoxStyle.Information, "Mensaje")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    'Funciones para el armado de la remesa
    Private Function parteRemesaDetalle(ByVal bco As Integer) As String
        If bco = 1 Then
            'Para el banco agricola
            'Es la cuenta del socio, el nombre completo del socio, el monto solicitado, el codigo empleado, la ubcacion, la fecha de impresion y damos un salto de linea
            Return ctaSocio.Replace("-", "").PadLeft(11, "0") & "; " & socio & ";;" & Format(monto, "0000000.00") & ";" & Cod_Buxis & ";" & ubicacion & "     " & Format(Now, "ddMMyy")
        ElseIf bco = 2 Then
            'Para el citi bank
            If movRemesa = "CXP" Then
                'Cuenta de la empresa 15 careacteres completados con ceros a la izq,Tipo de cuenta 3=Corriente 4=Ahorro, la cuenta del prov  15 careacteres completados con ceros a la izq,Tipo de cuenta 3=Corriente 4=Ahorro, el monto a pagar, codigo del proveedor,  el nombre del proveedor sin limites
                Return cta_proveedor.Replace("-", "").PadLeft(15, "0") & Chr(Keys.Tab) & IIf(cta_proveedor_tipo.ToUpper.Contains("AHORRO"), "4", "3") & Chr(Keys.Tab) & Format(monto, "0.00") & Chr(Keys.Tab) & ctaSocio.Replace("-", "").PadLeft(15, "0") & Chr(Keys.Tab) & IIf(TipCta.Contains("AHORRO"), "4", "3") & Chr(Keys.Tab) & cod_Prov.ToString() & Chr(Keys.Tab) & socio.Trim
            Else
                'Tipo de cuenta 3=Corriente y Tarj.Pago Seguro 4=Ahorro, la cuenta del socio, el nombre completo del socio (aunque solo admite 30 caracteres por eso se le pone el metodo "evaluarNombre"), el monto y un salto de linea
                Return IIf(TipCta.Contains("AHORRO"), "4", "3") & Chr(Keys.Tab) & ctaSocio.Replace("-", "") & Chr(Keys.Tab) & Cod_Buxis.ToString().PadLeft(5, "0") & Chr(Keys.Tab) & evaluarNombre().Trim & Chr(Keys.Tab) & Format(monto, "0000000.00")
            End If
            'Formato para deposito de dividendos de ATAF
            'Return IIf(TipCta.Contains("AHORRO"), "4", "3") & ";" & ctaSocio.Replace("-", "") & ";" & Format(monto, "00000.00") & ";" & Cod_Buxis.ToString().PadLeft(5, "0") & ";" & evaluarNombre().Trim
            ElseIf bco = 3 Then
                'Para el Banco de America Central
                'Valor constante dado por el banco T4978, correlativo de envio (5), NIT socio (14), valor 1 rellenado con 10 espacios a la izq., fecha deposito formato yyyyMMdd, 
                'Monto transacción sin punto decimal rellenado con espacios a la izq.(13), 5 espacios en blanco, texto que indica el tipo de operacion rellenado con espacios a la derecha (31),
                'el nombre completo del socio rellenado con espacios al final (60), valor constante dado por el banco=FACT rellenado con espacios en blanco a la der.(30), cuenta del socio
                Return "T" & EncabBAC.Substring(1, 9) & NITSocio.Replace("-", "") & "1".PadLeft(11, " ") & FechaDep & Format(monto, "0.00").Replace(".", "").PadLeft(13, " ") & StrDup(5, " ") & TipoTran.PadRight(31, " ") & socio.PadRight(60, " ") & "FACT".PadRight(30, " ") & ctaSocio.Replace("-", "")
            ElseIf bco = 7 Then
                'Para el Banco G&T
                'Campo 1: Cuenta
                'Campo 2: Monto
                'Campo 3: Descripción
                'Campo 4: Numero de NIT
                Return ctaSocio & "," & Format(monto, "00.00") & "," & socio & "," & NITSocio
            Else
                'Para cualquier otro banco
                'Tipo de cuenta, la cuenta del socio, CODIGO BUXIS, el nombre completo del socio, el monto y un salto de linea
                Return TipCta & ";" & ctaSocio.Replace("-", "") & ";" & Cod_Buxis.ToString().PadLeft(5, "0") & ";" & socio & ";" & Format(monto, "00000.00")
            End If
            Return String.Empty
    End Function

    'Metodo que evalua si el nombre del socio tiene o no 30 caracteres contando los espacios en blanco
    Private Function evaluarNombre() As String
        'Si el largo del nombre es menor de 30 
        'usamos esta variable para completar los espacios
        Dim espaciosNecesarios As Integer = 0
        'Esta variable almacenará el nombre ajustado
        Dim nombre As String = Nothing
        If Trim(socio).Length > 30 Then 'Evaluamos si el largo del nombre es mayor de 30
            'Si es asi solo tomamos los primeros 30 caracteres
            nombre = Mid(socio, 1, 30)
        ElseIf Trim(socio).Length < 30 Then 'Luego evaluamos si es menor de 30
            'Calculamos los espacios necesarios
            espaciosNecesarios = 30 - Trim(socio).Length
            nombre = Trim(socio) & Space(espaciosNecesarios) 'Agregamos los espacios necesarios
        ElseIf Trim(socio).Length = 30 Then 'Evaluamos si tiene 30 caracteres
            'Si es asi solo asignamos
            nombre = socio
        Else 'De lo contrario devolvera 30 espacios en blanco
            nombre = Space(30)
        End If
        Return nombre
    End Function

    'Metodo que valida los archivos para guardarlos
    Private Sub guardarDatos(ByVal fichero As String, ByVal cadena As String)
        'Comprobamos si existe el archivo
        If File.Exists(fichero) = True Then
            'Si existe entonces llamamos a la funcion leerDatos que devolveria el contenido
            'del fichero existente, lo concatena a un salto de linea y luego al texto nuevo
            escribirDatos(fichero, leerDatos(fichero) & cadena)
        Else
            'Si no existe crea el archivo con el texto enviado
            escribirDatos(fichero, cadena)
        End If
        If abrirCarpeta = True Then
            Shell("explorer.exe root = " & ruta, AppWinStyle.NormalFocus)
        End If
    End Sub

    'Metodo que escribe en los archivos ya sea que existan o no
    Private Sub escribirDatos(ByVal fichero As String, ByVal cadena As String)
        Dim sw As System.IO.StreamWriter
        'Eliminar caracteres extendidos para evitar problemas por compatibilidad
        cadena = cadena.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("Ñ", "N")
        cadena = cadena.Replace("À", "A").Replace("È", "E").Replace("Ì", "I").Replace("Ò", "O").Replace("Ù", "U").Replace("Ü", "U")
        cadena = cadena.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n")
        cadena = cadena.Replace("à", "a").Replace("è", "e").Replace("ì", "i").Replace("ò", "o").Replace("ù", "u").Replace("ü", "u")
        ' Abrimos el fichero para escribir, (no añadir),
        If Me.bco.ToUpper.Contains("CITI") Then
            ' Se cambió a ANSI por compatilidad con BANCO CITI
            sw = New System.IO.StreamWriter(fichero, False, Encoding.ASCII)
        Else
            ' usando la codificación predeterminada: UTF-8
            sw = New System.IO.StreamWriter(fichero, False)
        End If
        sw.WriteLine(cadena)
        ' Cerramos el fichero
        sw.Close()
    End Sub

    'Metodo que lee el archivo existente y devuelve su contenido
    Private Function leerDatos(ByVal fichero As String) As String
        ' Abrimos el fichero para leer
        ' usando la codificación UTF-8 (la predeterminada de .NET)
        Dim sr As New System.IO.StreamReader(fichero, True)
        ' leemos todo el contenido del fichero
        Dim ret As String = sr.ReadToEnd()
        ' lo cerramos
        sr.Close()
        ' devolvemos lo leído
        Return ret
    End Function
    '-------------------------------------------------------------------------------------------------------------
    ' Metodo alternativo para generar remesa a proveedores
    Public Sub recibirParametrosProv(ByVal cia As Integer, ByVal bco As Integer, ByVal ctaBco As String, ByVal codProveedor As Integer, ByVal nombrePro As String, ByVal ctaprov As String, ByVal movimiento As String, ByVal montoTotal As Double)
        Dim jars As New jarsClass

        'Llama al metodo que llenara los valores
        cod_Prov = codProveedor
        proveedor = nombrePro
        cta_proveedor = ctaprov
        monto = montoTotal
        TipCta = ObtenerTipoCtaBancoSocio().ToString
        Dim nombreArchivo As String = Nothing
        'El nombre de la subcarpeta bancos
        Dim nombreSubCarpetaTerciaria As String = Nothing
        '1 es Agricola, 2 es Citi
        If bco = 1 Then
            nombreArchivo = "PCBAC-" & movimiento.ToUpper & "_" & ".txt"
            'Queda pendiente el numero de caja va despues del _
            nombreSubCarpetaTerciaria = "BAC"
        ElseIf bco = 2 Then
            nombreArchivo = "CITI-" & movimiento.ToUpper & "_" & ".txt"
            'Queda pendiente el numero de caja va despues del _
            nombreSubCarpetaTerciaria = "CITI"
        ElseIf bco = 3 Then
            nombreArchivo = "BAC-" & movimiento.ToUpper & "_" & ".txt"
            'Queda pendiente el numero de caja va despues del _
            nombreSubCarpetaTerciaria = "BAC"
        Else
            nombreArchivo = "BCO-" & movimiento.ToUpper & "_" & ".txt"
            'Queda pendiente el numero de caja va despues del _
            nombreSubCarpetaTerciaria = "BCO"
        End If
        'El nombre de la subcarpeta diaria (ej. 2012-11-15)
        Dim nombreSubCarpetaSecundaria As String = Format(Now, "yyyy-MM-dd")
        'Cuando obtenemos el nombre del mes, lo devuelve con minuscula
        'Para obetener el nombre del mes con la primera letra en mayuscula:
        Dim letra As String = Nothing
        Dim Letras As String = Format(Now, "MMMM")
        'Substrae toda la palabra menos la 1era letra
        letra = Mid(Letras, 2, Letras.Length)
        'Saca la 1era letra
        Letras = Mid(Letras, 1, 1).ToUpper
        'Concatena
        Letras &= letra
        'El nombre de la subcarpeta mensual (ej. 2011-Diciembre)
        Dim nombreSubCarpetaPrincipal As String = Format(Now, "yyyy") & "-" & Letras
        'Metodo que crea las carpetas
        crearCarpetaPrincipal(nombreSubCarpetaPrincipal, nombreSubCarpetaSecundaria, nombreSubCarpetaTerciaria)
        guardarDatos(ruta & "/" & nombreArchivo, parteRemesaDetalle2(bco))
    End Sub

    'Funciones para el armado de la remesa
    Private Function parteRemesaDetalle2(ByVal bco As Integer) As String
        Dim codigo As String = cod_Prov.ToString

        ubicacion = "000"
        TipCta = cta_proveedor_tipo

        If bco = 1 Then
            'Para el banco agricola
            'Es la cuenta del socio, el nombre completo del socio, el monto solicitado, el codigo empleado, la ubcacion, la fecha de impresion y damos un salto de linea
            Return cta_proveedor.Replace("-", "").PadLeft(11, "0") & "; " & evaluarNombreProv().Trim & ";;" & Format(monto, "0000000.00") & ";" & cod_Prov & ";" & ubicacion & "     " & Format(Now, "ddMMyy")
        ElseIf bco = 2 Then
            'Para el citi bank
            'Tipo de cuenta 3=Corriente 4=Ahorro, la cuenta del socio, el nombre completo del socio (aunque solo admite 30 caracteres por eso se le pone el metodo "evaluarNombre"), el monto y un salto de linea
            Return TipCta & Chr(Keys.Tab) & cta_proveedor.Replace("-", "") & Chr(Keys.Tab) & codigo.Substring(1) & Chr(Keys.Tab) & evaluarNombreProv().Trim & Chr(Keys.Tab) & Format(monto, "0000000.00")
        ElseIf bco = 3 Then
            'Para el Banco de America Central
            Return TipCta & Chr(Keys.Tab) & cta_proveedor.Replace("-", "") & Chr(Keys.Tab) & codigo.Substring(1) & Chr(Keys.Tab) & evaluarNombreProv() & Chr(Keys.Tab) & Format(monto, "0000000.00")
        Else
            'Para cualquier otro banco
            'Tipo de cuenta 3=Corriente 4=Ahorro, la cuenta del socio, el nombre completo del socio (aunque solo admite 30 caracteres por eso se le pone el metodo "evaluarNombre"), el monto y un salto de linea
            Return TipCta & Chr(Keys.Tab) & cta_proveedor.Replace("-", "") & Chr(Keys.Tab) & codigo.Substring(1) & Chr(Keys.Tab) & evaluarNombreProv() & Chr(Keys.Tab) & Format(monto, "0000000.00")
        End If
    End Function
    Private Function evaluarNombreProv() As String
        'Si el largo del nombre es menor de 30 
        'usamos esta variable para completar los espacios
        Dim espaciosNecesarios As Integer = 0
        'Esta variable almacenará el nombre ajustado
        Dim nombre As String = Nothing
        If Trim(proveedor).Length > 30 Then 'Evaluamos si el largo del nombre es mayor de 30
            'Si es asi solo tomamos los primeros 30 caracteres
            nombre = Mid(proveedor, 1, 30)
        ElseIf Trim(proveedor).Length < 30 Then 'Luego evaluamos si es menor de 30
            'Calculamos los espacios necesarios
            espaciosNecesarios = 30 - Trim(proveedor).Length
            nombre = Trim(proveedor) & Space(espaciosNecesarios) 'Agregamos los espacios necesarios
        ElseIf Trim(proveedor).Length = 30 Then 'Evaluamos si tiene 30 caracteres
            'Si es asi solo asignamos
            nombre = proveedor
        Else 'De lo contrario devolvera 30 espacios en blanco
            nombre = Space(30)
        End If
        Return nombre
    End Function
End Class

