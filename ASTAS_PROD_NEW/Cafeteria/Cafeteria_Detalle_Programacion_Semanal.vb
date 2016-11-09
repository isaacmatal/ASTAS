Public Class Cafeteria_Detalle_Programacion_Semanal
    Public Compañia As Integer
    Public Bodega As Integer
    Public CodigoReceta As Integer
    Public Cantidad As Double
    Public Cantidad_P As Double

    Public Sub New()
    End Sub

    Public Sub New(ByVal compañia As Integer, ByVal bodega As Integer, ByVal codigo_receta As Integer, ByVal cantidad As Double, ByVal cantidad_1 As Double)
        Me.Compañia = compañia
        Me.Bodega = bodega
        Me.CodigoReceta = codigo_receta
        Me.Cantidad = cantidad '  CANTIDAD UTILIZADA EN EL DETALLE
        Me.Cantidad_P = cantidad_1 'CANTIDAD REQUERIDA IDEAL EN EL DETALLE
    End Sub

End Class
