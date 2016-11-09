Public Class ValidacionNit
    'FUNCION PARA LA VALIDACION DEL DIGITO VERIFICADOS PARA EL NIT DEL PROVEEDOR
    'RETORNA EL CALCULO DEL DIGITO VERIFICADOR PARA EL NIT PASADO COMO PARAMETRO,
    'ESTE PARAMETRO SE RECIBE SIN GUIONES Y CON LONGITUD DE 14 DIGITOS
    Public Function Dig_Verf(ByVal NIT As String) As String
        Dim li_sum As Integer = 0
        Dim ls_valor As String = NIT
        Dim li_digver, li_factor As Integer
        Dim li_residuo As Double
        Dim ls_dvnit As String
        Dim valor As Integer
        If Val(ls_valor.Trim.Substring(10, 3)) <= 100 Then
            For li_pos As Integer = 0 To 12
                li_sum = li_sum + Val(ls_valor.Trim.Substring(li_pos, 1)) * (14 - li_pos)
            Next
            li_digver = li_sum Mod 11
            If li_digver = 10 Then
                li_digver = 0
            End If
        Else
            For li_pos As Integer = 0 To 12
                valor = li_pos + 1
                li_factor = (3 + 6 * Math.Truncate((valor + 4) / 6)) - valor
                li_sum = li_sum + Val(ls_valor.Trim.Substring(li_pos, 1)) * li_factor
            Next
            li_residuo = li_sum Mod 11
            If li_residuo > 1 Then
                li_digver = 11 - li_residuo
            Else
                li_digver = 0
            End If
        End If
        ls_dvnit = li_digver.ToString("0")
        Return ls_dvnit
    End Function
End Class
