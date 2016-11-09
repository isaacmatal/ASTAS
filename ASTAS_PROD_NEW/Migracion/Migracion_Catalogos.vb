Imports System.Data.SqlClient

Public Class Migracion_Catalogos
    Dim Sql As String
    Dim sqlCmd As New SqlCommand
    Dim Table As DataTable
    Dim jClass As New jarsClass
    Dim Carpeta, Archivo, ArchivoAhorros As String
    Dim Textos As New ArchivosTexto
    Dim RowsAffected As Integer

    Delegate Sub PB_A_Cero(ByVal x As Integer)

    Sub SeteaPB(ByVal x As Integer)
        If Me.pB1.InvokeRequired Then
            Dim setea As New PB_A_Cero(AddressOf SeteaPB)
            Me.Invoke(setea, x)
        Else
            Me.pB1.Value = 0
        End If
    End Sub

    Private Sub Migracion_Catalogos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Carpeta = jClass.obtenerEscalar("SELECT DECRIPCION FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE = 19").ToString.Trim
        Me.OpenFD.InitialDirectory = Carpeta
        'NomArchivo(1)
    End Sub

    Private Sub NomArchivo(ByVal Tipo As Integer)
        If BwDesc.IsBusy Or BwBenef.IsBusy Then
            Return
        End If
        ArchivoAhorros = ""
        If Tipo = 1 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_02 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 3")
        ElseIf Tipo = 2 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_03 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 3")
        ElseIf Tipo = 3 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_01 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 3")
        ElseIf Tipo = 4 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_01 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
            ArchivoAhorros = jClass.obtenerEscalar("SELECT CUENTA_05 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
        ElseIf Tipo = 5 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_02 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
            ArchivoAhorros = jClass.obtenerEscalar("SELECT CUENTA_05 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
        ElseIf Tipo = 6 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_03 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
            ArchivoAhorros = jClass.obtenerEscalar("SELECT DESCRIPCION_CUENTA FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
        ElseIf Tipo = 7 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_04 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 2")
        ElseIf Tipo = 8 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_03 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 4")
        ElseIf Tipo = 9 Then
            Archivo = jClass.obtenerEscalar("SELECT CUENTA_04 FROM CUENTAS$ WHERE COMPAÑÍA = " & Compañia & " AND CUENTA = 4")
        End If
        Me.txtRutaArchivo.Text = Carpeta & "\" & Archivo
    End Sub

    'Private Sub rbCatEmpl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCatEmpl.CheckedChanged
    '    If Me.rbCatEmpl.Checked Then
    '        NomArchivo(1)
    '    End If
    'End Sub

    'Private Sub rbCatBenef_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCatBenef.CheckedChanged
    '    If Me.rbCatBenef.Checked Then
    '        NomArchivo(2)
    '    End If
    'End Sub

    'Private Sub rbAIndemnizar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAIndemnizar.CheckedChanged
    '    If Me.rbAIndemnizar.Checked Then
    '        NomArchivo(3)
    '    End If
    'End Sub

    'Private Sub rbQna1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna1.CheckedChanged
    '    If Me.rbQna1.Checked Then
    '        NomArchivo(4)
    '    End If
    'End Sub

    'Private Sub rbQna2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbQna2.CheckedChanged
    '    If Me.rbQna2.Checked Then
    '        NomArchivo(5)
    '    End If
    'End Sub

    'Private Sub rbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMensual.CheckedChanged
    '    If Me.rbMensual.Checked Then
    '        NomArchivo(6)
    '    End If
    'End Sub

    'Private Sub rbIndemnizados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIndemnizados.CheckedChanged
    '    If Me.rbIndemnizados.Checked Then
    '        NomArchivo(7)
    '    End If
    'End Sub

    'Private Sub rbBoni_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBoni.CheckedChanged
    '    If Me.rbBoni.Checked Then
    '        NomArchivo(8)
    '    End If
    'End Sub

    'Private Sub rbAguin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAguin.CheckedChanged
    '    If Me.rbAguin.Checked Then
    '        NomArchivo(9)
    '    End If
    'End Sub

    Private Sub btnMigracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigracion.Click
        If BwDesc.IsBusy Or BwBenef.IsBusy Then
            Return
        End If
        If Me.txtRutaArchivo.Text.Length = 0 Then
            MsgBox("No ha seleccionado el archivo de texto a cargar.", MsgBoxStyle.Information, "Archivo")
            Me.btnArchivo.Focus()
            Return
        End If
        Me.pB1.Maximum = 100
        Me.pB1.Value = 0
        Archivo = Me.txtRutaArchivo.Text
        If Me.rbAhorros.Checked Then
            Me.GroupBox2.Enabled = False
            ArchivoAhorros = Me.txtRutaArchivo.Text
            Me.BwAhorros.RunWorkerAsync()
        End If
        If Me.rbDescuentos.Checked Then
            Me.GroupBox2.Enabled = False
            Me.BwDesc.RunWorkerAsync()
        End If
        If Me.rbAIndemnizar.Checked Then
            Me.GroupBox2.Enabled = False
            A_Indeminizar()
            Me.GroupBox2.Enabled = True
        End If
        If Me.rbCatEmpl.Checked Then
            Me.GroupBox2.Enabled = False
            CatalogoEmpleados()
            Me.GroupBox2.Enabled = True
        End If
        If Me.rbCatBenef.Checked Then
            Me.GroupBox2.Enabled = False
            Me.BwBenef.RunWorkerAsync()
        End If
    End Sub

    Private Sub CatalogoEmpleados()
        Dim _error_ As Boolean = False
        Dim Contador As Integer = 0
        Dim result As DataTable
        If Not System.IO.File.Exists(Me.txtRutaArchivo.Text) Then
            MsgBox("El Archivo no existe.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        Table = Textos.cargaTexto("NO", Carpeta, Archivo)
        If Table.Columns.Count <> 31 Then
            MsgBox("El número de campos en el archivo: " & Archivo & vbCrLf & " es diferente al Catalogo de Empleados.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        jClass.Ejecutar_ConsultaSQL("DELETE FROM PLANILLA_CATALOGO_EMPLEADOS")
        For Each row As DataRow In Table.Rows
            Contador += 1
            If Asc(row.Item(0).ToString.Substring(0, 1)) < 65 Or Asc(row.Item(0).ToString.Substring(0, 1)) > 90 Then
                MsgBox("Hay caracteres No Válidos al inicio. " & vbCrLf & "Linea #" & Contador, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            'If row.Item(1).GetType.Name.ToUpper = "DBNULL" Then
            If IsDBNull(row.Item(0)) Or IsDBNull(row.Item(1)) Or IsDBNull(row.Item(2)) Or IsDBNull(row.Item(3)) Or IsDBNull(row.Item(4)) Or IsDBNull(row.Item(5)) Or IsDBNull(row.Item(6)) Or IsDBNull(row.Item(7)) Or IsDBNull(row.Item(8)) Then
                MsgBox("Hay campos llave con valores nulos." & vbCrLf & "Linea #" & Contador, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            Sql = "INSERT INTO [dbo].[PLANILLA_CATALOGO_EMPLEADOS]" & vbCrLf
            Sql &= "           ([Compañia]" & vbCrLf
            Sql &= "           ,[CodigoEmpleado]" & vbCrLf
            Sql &= "           ,[CodigoEmpleadoAs]" & vbCrLf
            Sql &= "           ,[Nombres]" & vbCrLf
            Sql &= "           ,[Apellidos]" & vbCrLf
            Sql &= "           ,[Division]" & vbCrLf
            Sql &= "           ,[Departamento]" & vbCrLf
            Sql &= "           ,[Seccion]" & vbCrLf
            Sql &= "           ,[Cargo]" & vbCrLf
            Sql &= "           ,[Banco]" & vbCrLf
            Sql &= "           ,[No_Cuenta_Bancaria]" & vbCrLf
            Sql &= "           ,[Tipo_Cuenta_Bancaria]" & vbCrLf
            Sql &= "           ,[PeriodoPago]" & vbCrLf
            Sql &= "           ,[F_Ingreso]" & vbCrLf
            Sql &= "           ,[FechaSalida]" & vbCrLf
            Sql &= "           ,[EsSocio]" & vbCrLf
            Sql &= "           ,[DUI]" & vbCrLf
            Sql &= "           ,[Nit]" & vbCrLf
            Sql &= "           ,[Direccion]" & vbCrLf
            Sql &= "           ,[DeptoResidencia]" & vbCrLf
            Sql &= "           ,[MunicipioResidencia]" & vbCrLf
            Sql &= "           ,[Telefono]" & vbCrLf
            Sql &= "           ,[Salario]" & vbCrLf
            Sql &= "           ,[SueldoPromedio]" & vbCrLf
            Sql &= "           ,[Contrato]" & vbCrLf
            Sql &= "           ,[Indemnizacion]" & vbCrLf
            Sql &= "           ,[Total_Deduccion]" & vbCrLf
            Sql &= "           ,[PorcAhorroOrdinario]" & vbCrLf
            Sql &= "           ,[PorcAhorroExtra]" & vbCrLf
            Sql &= "           ,[Cod_Emp]" & vbCrLf
            Sql &= "           ,[Gerencia])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           ('" & row.Item(0) & "'" & vbCrLf
            Sql &= "           ," & CInt(row.Item(1)) & vbCrLf
            Sql &= "           ,'" & row.Item(2) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(3) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(4) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(5) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(6) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(7) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(8) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(9) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(10) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(11) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(12) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(13) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(14) & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(15).ToString) & vbCrLf
            Sql &= "           ,'" & row.Item(16) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(17) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(18) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(19) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(20) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(21) & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(22).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(23).ToString) & vbCrLf
            Sql &= "           ,'" & row.Item(24).ToString & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(25).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(26).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(27).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(28).ToString) & vbCrLf
            Sql &= "           ," & CInt(row.Item(29)).ToString & vbCrLf
            Sql &= "           ,'" & row.Item(30).ToString & "')"
            sqlCmd.CommandText = Sql
            RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            If RowsAffected = 0 Then
                MsgBox("Error al insertar Linea #" & Contador & " desde el archivo de texto.", MsgBoxStyle.Critical, "Proceso cancelado")
                _error_ = True
                Exit For
            End If
        Next
        If Not _error_ Then
            sqlCmd.CommandText = "EXECUTE [dbo].[sp_MIGRACION_COOPERATIVA_CATALOGO_SOCIOS] @COMPAÑIA = " & Compañia & ", @USUARIO = 'buxis" & Format(Now, "ddMMyyy") & "'"
            result = jClass.obtenerDatos(sqlCmd)
            If result.Rows.Count > 0 Then
                Sql = result.Rows(0).Item(0)
                MsgBox("Resultados" & vbCrLf & "----------" & vbCrLf & "Empleados Nuevos: " & Sql.Substring(0, Sql.IndexOf("-")) & vbCrLf & "Empleados Actualizados: " & Sql.Substring(Sql.IndexOf("-") + 1), MsgBoxStyle.Information, "Proceso Finalizado")
            End If
        End If
    End Sub

    Private Sub A_Indeminizar()
        Dim _error_ As Boolean = False
        Dim Cnt As Integer = 0
        pB1.Value = 0
        If Not System.IO.File.Exists(Me.txtRutaArchivo.Text) Then
            MsgBox("El Archivo no existe.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        Table = Textos.cargaTexto("NO", Carpeta, Archivo)
        If Table.Columns.Count <> 5 Then
            MsgBox("El número de campos en el archivo: " & Archivo & vbCrLf & " es diferente al Listado de Empleados a Indemnizar.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        pB1.Maximum = Table.Rows.Count
        jClass.Ejecutar_ConsultaSQL("DELETE FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR")
        For Each row As DataRow In Table.Rows
            Cnt += 1
            If Asc(row.Item(0).ToString.Substring(0, 1)) < 48 Or Asc(row.Item(0).ToString.Substring(0, 1)) > 57 Then
                MsgBox("Hay caracteres No Válidos al inicio del archivo.", MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            For i As Integer = 0 To row.ItemArray.Length - 1
                If IsDBNull(row.Item(i)) Then
                    _error_ = True
                    Exit For
                End If
            Next
            If _error_ Then
                MsgBox("Hay campos con valores nulos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                Exit For
            End If
            Sql = "INSERT INTO [dbo].[PLANILLA_EMPLEADOS_A_INDEMNIZAR]" & vbCrLf
            Sql &= "           ([CodigoEmpleado]" & vbCrLf
            Sql &= "           ,[CodigoEmpleadoAS]" & vbCrLf
            Sql &= "           ,[F_Baja]" & vbCrLf
            Sql &= "           ,[F_Descuento]" & vbCrLf
            Sql &= "           ,[Cod_Emp])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           (" & Val(row.Item(0).ToString) & vbCrLf
            Sql &= "           ,'" & Val(row.Item(1).ToString) & "'" & vbCrLf
            Sql &= "           ,'" & Format(row.Item(2), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ,'" & Format(row.Item(3), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(4).ToString) & ")"
            sqlCmd.CommandText = Sql
            RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            If RowsAffected = 0 Then
                MsgBox("Error al insertar Linea #" & Cnt & " desde el archivo de texto.", MsgBoxStyle.Critical, "Proceso cancelado")
                _error_ = True
                Exit For
            End If
            pB1.Value += 1
        Next
        If _error_ Then
            jClass.Ejecutar_ConsultaSQL("DELETE FROM PLANILLA_EMPLEADOS_A_INDEMNIZAR")
            Return
        End If
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Carga Archivos")
    End Sub

    Private Sub BeneficiariosSocio()
        Dim PBCero As PB_A_Cero = AddressOf SeteaPB
        Dim _error_ As Boolean = False
        Dim Cnt As Integer = 0
        If Not System.IO.File.Exists(Me.txtRutaArchivo.Text) Then
            MsgBox("El Archivo no existe.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        Table = Textos.cargaTexto("NO", Carpeta, Archivo)
        If Table.Columns.Count <> 8 Then
            MsgBox("El número de campos en el archivo: " & Archivo & vbCrLf & " es diferente al Catalogo de Beneficiarios.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        jClass.Ejecutar_ConsultaSQL("DELETE FROM PLANILLA_CATALOGO_BENEFICIARIOS")
        For Each row As DataRow In Table.Rows
            Cnt += 1
            If Asc(row.Item(0).ToString.Substring(0, 1)) < 65 Or Asc(row.Item(0).ToString.Substring(0, 1)) > 90 Then
                MsgBox("Hay caracteres No Válidos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            'If row.Item(1).GetType.Name.ToUpper = "DBNULL" Then
            If IsDBNull(row.Item(0)) Or IsDBNull(row.Item(1)) Or IsDBNull(row.Item(2)) Then
                MsgBox("Hay campos llave con valores nulos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            Sql = "INSERT INTO [dbo].[PLANILLA_CATALOGO_BENEFICIARIOS]" & vbCrLf
            Sql &= "           ([Compañia]" & vbCrLf
            Sql &= "           ,[CodigoEmpleadoAs]" & vbCrLf
            Sql &= "           ,[CodigoEmpleado]" & vbCrLf
            Sql &= "           ,[NOMBRES_BENEFICIARIO]" & vbCrLf
            Sql &= "           ,[APELLIDOS_BENEFICIARIO]" & vbCrLf
            Sql &= "           ,[PARENTESCO]" & vbCrLf
            Sql &= "           ,[PORCENTAJE]" & vbCrLf
            Sql &= "           ,[Cod_Emp])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           ('" & row.Item(0) & vbCrLf & "'"
            Sql &= "           ,'" & Val(row.Item(1).ToString) & "'" & vbCrLf
            Sql &= "           ," & row.Item(2) & vbCrLf
            Sql &= "           ,'" & row.Item(3) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(4) & "'" & vbCrLf
            Sql &= "           ,'" & row.Item(5) & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(6).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(7).ToString) & ")"
            sqlCmd.CommandText = Sql
            RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            If RowsAffected = 0 Then
                MsgBox("Error al insertar Linea #" & Cnt & " desde el archivo de texto.", MsgBoxStyle.Critical, "Proceso cancelado")
                _error_ = True
                Exit For
            End If
            Me.BwBenef.ReportProgress((Cnt / Table.Rows.Count) * 100)
        Next
        If Not _error_ Then
            sqlCmd.CommandText = "SELECT CodigoEmpleadoAS, CodigoEmpleado FROM PLANILLA_CATALOGO_BENEFICIARIOS GROUP BY CodigoEmpleadoAS, CodigoEmpleado "
            Table = jClass.obtenerDatos(sqlCmd)
            PBCero.Invoke(0)
            For i As Integer = 0 To Table.Rows.Count - 1
                sqlCmd.CommandText = "EXECUTE [dbo].[sp_MIGRACION_CATALOGO_SOCIOS_V2_BENEFICIARIOS] @COMPAÑIA = " & Compañia & ",@CODIGO_EMPLEADO = " & Table.Rows(i).Item(1) & ",@CODAS = '" & Table.Rows(i).Item(0) & "',@USUARIO = '" & Usuario & "'"
                jClass.ejecutarComandoSql(sqlCmd)
                Me.BwBenef.ReportProgress(((i + 1) / Table.Rows.Count) * 100)
            Next
        End If
    End Sub

    Private Sub CargaDescuentosPlanilla()
        Dim _error_ As Boolean = False
        Dim Cnt As Integer = 0
        If Not System.IO.File.Exists(Me.txtRutaArchivo.Text) Then
            MsgBox("El Archivo de descuentos aplicados no existe.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        Table = Textos.cargaTexto("NO", Carpeta, Archivo)
        If Table.Columns.Count <> 12 Then
            MsgBox("El número de campos en el archivo: " & Archivo & vbCrLf & " es diferente al Listado de Descuentos.", MsgBoxStyle.Critical, "Proceso Cancelado")
            Return
        End If
        For Each row As DataRow In Table.Rows
            Cnt += 1
            If Asc(row.Item(0).ToString.Substring(0, 1)) < 48 Or Asc(row.Item(0).ToString.Substring(0, 1)) > 57 Then
                MsgBox("Hay caracteres No Válidos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            'If row.Item(1).GetType.Name.ToUpper = "DBNULL" Then
            For i As Integer = 0 To row.ItemArray.Length - 1
                If IsDBNull(row.Item(i)) Then
                    _error_ = True
                    Exit For
                End If
            Next
            If _error_ Then
                MsgBox("Hay campos con valores nulos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                Exit For
            End If
            Sql = "SELECT COUNT(COD_MV) FROM [dbo].[PLANILLA_DESCUENTOS_APLICADOS] WHERE COD_MV = " & row.Item(0) & " AND COD_MF = " & row.Item(1) & " AND JORNALES_HD = " & row.Item(4) & " AND UNID_HD = " & row.Item(6) & " AND FEC_ACU_HD = '" & Format(row.Item(2), "dd/MM/yyyy") & "'"
            If CInt(jClass.obtenerEscalar(Sql)) > 0 Then
                MsgBox("Registro ya existe en los descuentos aplicados." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            Sql = "INSERT INTO [dbo].[PLANILLA_DESCUENTOS_APLICADOS]" & vbCrLf
            Sql &= "           ([COD_MV]" & vbCrLf
            Sql &= "           ,[COD_MF]" & vbCrLf
            Sql &= "           ,[FEC_VAL_HD]" & vbCrLf
            Sql &= "           ,[FEC_ACU_HD]" & vbCrLf
            Sql &= "           ,[JORNALES_HD]" & vbCrLf
            Sql &= "           ,[HORAS_HD]" & vbCrLf
            Sql &= "           ,[UNID_HD]" & vbCrLf
            Sql &= "           ,[IMPUNI_HD]" & vbCrLf
            Sql &= "           ,[IMPTOT_HD]" & vbCrLf
            Sql &= "           ,[APLICADO]" & vbCrLf
            Sql &= "           ,[Cod_Emp]" & vbCrLf
            Sql &= "           ,[Dife_mov])" & vbCrLf
            Sql &= "    VALUES" & vbCrLf
            Sql &= "           (" & row.Item(0) & vbCrLf
            Sql &= "           ," & row.Item(1) & vbCrLf
            Sql &= "           ,'" & Format(row.Item(2), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ,'" & Format(row.Item(3), "dd/MM/yyyy") & "'" & vbCrLf
            Sql &= "           ," & row.Item(4) & vbCrLf
            Sql &= "           ,9" & vbCrLf
            Sql &= "           ," & row.Item(6) & vbCrLf
            Sql &= "           ," & row.Item(7) & vbCrLf
            Sql &= "           ," & row.Item(8) & vbCrLf
            Sql &= "           ," & row.Item(9) & vbCrLf
            Sql &= "           ," & row.Item(10) & vbCrLf
            Sql &= "           ," & row.Item(11) & ")"
            sqlCmd.CommandText = Sql
            RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            If RowsAffected = 0 Then
                MsgBox("Error al insertar Linea #" & Cnt & " desde el archivo de texto.", MsgBoxStyle.Critical, "Proceso cancelado")
                _error_ = True
                Exit For
            End If
            Me.BwDesc.ReportProgress((Cnt / (Table.Rows.Count)) * 100)
        Next
        If _error_ Then
            sqlCmd.CommandText = "DELETE FROM PLANILLA_DESCUENTOS_APLICADOS WHERE HORAS_HD = 9"
        Else
            sqlCmd.CommandText = "UPDATE PLANILLA_DESCUENTOS_APLICADOS SET HORAS_HD = 0 WHERE HORAS_HD = 9"
        End If
        jClass.ejecutarComandoSql(sqlCmd)
    End Sub

    Private Function CargaAhorrosPlanilla() As Boolean
        If ArchivoAhorros.Length = 0 Then
            Return False
        End If
        Dim TableAhorros As New DataTable
        Dim _error_ As Boolean = False
        Dim Cnt As Integer = 0
        If ArchivoAhorros.Length > 0 Then
            If Not System.IO.File.Exists(ArchivoAhorros) Then
                MsgBox("El Archivo de Ahorros descontados no existe.", MsgBoxStyle.Critical, "Proceso Cancelado")
                Return False
            End If
            TableAhorros = Textos.cargaTexto("NO", Carpeta, ArchivoAhorros)
            If TableAhorros.Columns.Count <> 9 Then
                MsgBox("El número de campos en el archivo: " & Archivo & vbCrLf & " es diferente al Listado de Descuentos de Ahorro.", MsgBoxStyle.Critical, "Proceso Cancelado")
                Return False
            End If
        End If
        For Each row As DataRow In TableAhorros.Rows
            Cnt += 1
            If Asc(row.Item(0).ToString.Substring(0, 1)) < 48 Or Asc(row.Item(0).ToString.Substring(0, 1)) > 57 Then
                MsgBox("Hay caracteres No Válidos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            'If row.Item(1).GetType.Name.ToUpper = "DBNULL" Then
            If IsDBNull(row.Item(1)) Or IsDBNull(row.Item(2)) Or IsDBNull(row.Item(8)) Then
                MsgBox("Hay campos llave con valores nulos." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            Sql = "SELECT COUNT(Cod_Emp) FROM [dbo].[PLANILLA_AHORROS_APLICADOS] WHERE CODIGO_EMPLEADO = " & row.Item(1) & " AND CODIGO_EMPLEADO_AS = '" & row.Item(2) & "' AND FECHA_DESCUENTO = '" & Format(row.Item(8), "dd/MM/yyyy") & "'"
            If CInt(jClass.obtenerEscalar(Sql)) > 0 Then
                MsgBox("Registro ya existe en los ahorros aplicados." & vbCrLf & "Linea #" & Cnt, MsgBoxStyle.Critical, "Proceso Cancelado")
                _error_ = True
                Exit For
            End If
            Sql = "INSERT INTO [dbo].[PLANILLA_AHORROS_APLICADOS]" & vbCrLf
            Sql &= "           ([Cod_Emp]" & vbCrLf
            Sql &= "           ,[CODIGO_EMPLEADO]" & vbCrLf
            Sql &= "           ,[CODIGO_EMPLEADO_AS]" & vbCrLf
            Sql &= "           ,[Valor_Ordinario]" & vbCrLf
            Sql &= "           ,[PorcAhorroOrdinario]" & vbCrLf
            Sql &= "           ,[Valor_ExtraOrdinario]" & vbCrLf
            Sql &= "           ,[PorcAhorroExtraOrdinario]" & vbCrLf
            Sql &= "           ,[Fondo_Defuncion]" & vbCrLf
            Sql &= "           ,[FECHA_DESCUENTO])" & vbCrLf
            Sql &= "     VALUES" & vbCrLf
            Sql &= "           (1" & vbCrLf
            Sql &= "           ," & row.Item(1) & vbCrLf
            Sql &= "           ,'" & row.Item(2) & "'" & vbCrLf
            Sql &= "           ," & Val(row.Item(3).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(4).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(5).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(6).ToString) & vbCrLf
            Sql &= "           ," & Val(row.Item(7).ToString) & vbCrLf
            Sql &= "           ,'" & Format(row.Item(8), "dd/MM/yyyy") & "')" & vbCrLf
            sqlCmd.CommandText = Sql
            RowsAffected = jClass.ejecutarComandoSql(sqlCmd)
            If RowsAffected = 0 Then
                MsgBox("Error al insertar Linea #" & Cnt & " desde el archivo de texto.", MsgBoxStyle.Critical, "Proceso cancelado")
                _error_ = True
                Exit For
            End If
            Me.BwAhorros.ReportProgress((Cnt / TableAhorros.Rows.Count) * 100)
        Next
        If _error_ Then
            sqlCmd.CommandText = "DELETE FROM [dbo].[PLANILLA_AHORROS_APLICADOS] WHERE Cod_Emp = 1"
        Else
            sqlCmd.CommandText = "UPDATE [dbo].[PLANILLA_AHORROS_APLICADOS] SET Cod_Emp = 0 WHERE Cod_Emp = 1"
        End If
        jClass.ejecutarComandoSql(sqlCmd)
        Return Not _error_
    End Function

    Private Sub BwDesc_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwDesc.DoWork
        CargaDescuentosPlanilla()
        e.Result = 100
    End Sub

    Private Sub BwDesc_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BwDesc.ProgressChanged
        Me.pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub BwDesc_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwDesc.RunWorkerCompleted
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Carga de Archivos")
        Me.GroupBox2.Enabled = True
    End Sub

    Private Sub BwBenef_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwBenef.DoWork
        BeneficiariosSocio()
        e.Result = 100
    End Sub

    Private Sub BwBenef_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BwBenef.ProgressChanged
        Me.pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub BwBenef_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwBenef.RunWorkerCompleted
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Carga de Archivos")
        Me.GroupBox2.Enabled = True
    End Sub

    Private Sub Migracion_Catalogos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.AliceBlue, Color.LightSkyBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub BwAhorros_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwAhorros.DoWork
        CargaAhorrosPlanilla()
    End Sub

    Private Sub BwAhorros_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BwAhorros.ProgressChanged
        Me.pB1.Value = e.ProgressPercentage
    End Sub

    Private Sub BwAhorros_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwAhorros.RunWorkerCompleted
        MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Carga de Archivos")
        Me.GroupBox2.Enabled = True
    End Sub

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
        If Me.OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtRutaArchivo.Text = Me.OpenFD.FileName
        End If
    End Sub
End Class