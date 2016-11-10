Module Definitions
    Public CnnStrBldr As New SqlClient.SqlConnectionStringBuilder
    Public Propietario As String
    Public UsuarioDB As String
    Public PasswordDB As String
    Public Servidor As String
    Public BaseDatos As String
    Public Usuario As String
    Public Nombre_Usuario As String
    Public Compañia As Integer
    Public Descripcion_Compañia As String
    Public Numero As String
    Public Producto As String
    Public Descripcion_Producto As String
    Public Tipo As String
    Public AppPath As String
    Public Contribuyente As Integer  'Tipo de contribuyente es la compañía 4=Excluido, 3=grande, 2=mediana, 1=pequeña p/calcular percibido.
    Public Por_IVA As Decimal
    Public Por_Percibido As Decimal
    Public Host As String
    Public IP As String

    'Agregados por Luis Zelaya
    Public ImagenPath As String
    Public IconPath As String
    Public Iniciando As Boolean

    'Agregados por Benjamín Parada
    Public ParamcodigoAs As String
    Public ParamcodigoBux As Integer
    Public ParamNomProvee As String
    Public ParamCodProvee As Integer
    Public ParamcodSolicitud As Integer
    Public BotonProgramar As Boolean
    Public Cotizacion As Boolean
    Public NuevaFecha As Date

    'Agregados Jonathan Peña
    Public Concepto_Factura As String
    Public Nombre_Factura As String
    Public Check As Integer
    Public Numero_Factura As Integer
    Public Fecha_OV As Date
    Public Tipo_Doc As Integer
    Public Forma_Pago As Integer
    Public Condicion_Pago As Integer
    Public Monto As Double
    Public UFlag As Boolean
    Public CC As Integer
    Public varios_Conceptos(99), varias_Fechas(99), varias_CtasCompletas(99) As String
    Public varias_chequeras(99), varios_librosContables(99), varios_Bcos(99), varias_Cuentas(99) As Integer
    Public Linea1 As String
    Public Linea2 As String
    Public MontoFin As String
    Public RubroRetencion As Boolean
    Public RubroRetencion2 As Boolean
    Public RubroPrestamo As Boolean
    Public RubroPrestamo2 As Boolean

    'Agregados Joan Serrano
    Public StadoBusqueda As Integer
    Public ParamDeducciones As Double
    Public CodigoProducto As Integer

    'Agregado por Oscar Avilés
    Public Descripcion_Unidad_Medida As String
    Public TipoDocto As Integer
    Public NumeDocto As Integer
    Public ParamCon_IVA As Integer
    Public Hay_Datos As Boolean

    'Agregado por Esteban Alexander Gamez
    Public Numero_Proveedor As String
    Public Existencias As String
    Public unidades As String
    Public Abierto_Cerrado As Boolean
    Public Recibido As Boolean = False
    Public CodigoProd As Integer
    Public Tiempo_Comida As Integer
    Public Bodega_Global As Integer
    Public Contraseña_Cafeteria As String
    Public Cobrar As String
    Public cost As String
    Public bodega_cocina1 As String() = {19, 31}
    Public bodega_cocina2 As String() = {41, 42}


    'Agregados Yonathan Cedillos
    Public TipoExtensiones As String = "Todos los archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp|PNGs|*.png"
    Public FiltradoImagen As String = "Todos los Archivos"
    Public IndiceFiltrado As Int32 = 1
    Public RutaImagenes As String = ""
    Public CodigoTratamiento As String
    Public DescripcionTratamiento As String
    Public CodigoDoctor As String = "0"
    Public CodigoPaciente As String = "0"
    Public NombrePaciente As String
    Public CodigoCita As String
    Public CodigoRequerimiento As String
    Public NuevoPaciente As Boolean = False

    'Agregados por Emmanuel Isaac Mátal
    Public Numero_Bodega As Integer
    Public Numero_Serie As Integer
    Public Origen As Integer
    Public Numero_OV As Integer
    Public MaxNumLineas As Integer
    Public InstanciaUsuario As Integer

End Module
