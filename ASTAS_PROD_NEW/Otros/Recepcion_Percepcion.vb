Public Class Recepcion_Percepcion

    'Tipos de contribuyentes:
    '1-Pequeño
    '2-Mediano
    '3-Grande
    'Se ha establecido que todo aquel contribuyente grande sea agente de recepcion y percepcion
    'sino esta dentro de esa clasificacion no puede ser agente

    'Reglas:
    'Si yo soy gran contribuyente y me compra o vende uno igual que yo; "grande" no se afectan entre si.
    'Si yo soy gran contribuyente y me compra uno mas "pequeño" que yo; le PERCIBO el 1%
    'Si yo soy gran contribuyente y me vende uno mas "pequeño" que yo; le RETENGO el 1%
    'Si yo NO soy gran contribuyente no le puedo percibir ni retener a los mas pequeños que yo.
    Dim c_data2 As New jarsClass
    Dim PERCEPCION As String, Total As String, RETENCION As String
    Public Function recepcion_percepcion(ByVal accion, ByVal proveedor, ByVal sub_total)
        Dim retenido_percibido As String

        PERCEPCION = c_data2.leerDataeader("EXECUTE sp_CONTABILIDAD_CATALOGO_CONSTANTES @COMPAÑIA=" & Compañia & ",@CONSTANTE=2", 0)
        retenido_percibido = (Val(PERCEPCION) / 100) * Val(sub_total)

        Return retenido_percibido
    End Function
    'SI SE LE COMPRA UN SERVICIO A UNA EMPRESA NATURAL SE LE DEBE RETENER EL PORCENTAJE DE RENTA ESTABLECIDO
    'A MENOS QUE AMBOS SEAN IGUALES
    'QUE HASTA EL DIA DE AHORA ES DEL 10% 09/08/2012
    Public Function Renta(ByVal Tipo_Proveedor, ByVal sub_total)
        Dim renta_ As String = 0, retenido As String = 0

        renta_ = c_data2.leerDataeader("EXECUTE sp_CONTABILIDAD_CATALOGO_CONSTANTES @COMPAÑIA=" & Compañia & ",@CONSTANTE=5", 0)
        retenido = (Val(renta_) / 100) * Val(sub_total)

        Return retenido
    End Function
End Class
