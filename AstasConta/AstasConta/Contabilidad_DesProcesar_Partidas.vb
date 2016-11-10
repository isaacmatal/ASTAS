Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Contabilidad_DesProcesar_Partidas

    'Constructores
    Dim jClass As New jarsClass
    Dim bquery As New busquedaQuery
    Dim PC As New Contabilidad_Procesos

    'Conexion
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim table As DataTable
    Dim DataReader_ As SqlDataReader

    'Declaración variables publicas
    Public tipoDoc As String
    Public tipoPartida As String
    Public numPartida As String
    Public documento As String
    Public fechaCont As String
    Public concepto As String

    'Declaracion de variable
    Dim sql As String
    Dim Iniciando As Boolean

    'Carga de valores en el formulario
    Private Sub Contabilidad_DesProcesar_Partidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        jClass.CargaLibrosContables(Compañia, cmbLIBRO_CONTABLE)
        jClass.CargaTipoDocumento(Compañia, cmbTIPO_DOCUMENTO)
        jClass.CargaTipoPartida(Compañia, cmbTIPO_PARTIDA)
        Iniciando = False
    End Sub

    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        If Trim(Me.txtPartida.Text) = "" Or Trim(Me.txtPartida.Text) = "0" Then
            Dim Transacciones As New Contabilidad_BusquedaTransaccion
            Transacciones.Compañia_Value = Compañia
            Transacciones.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
            Transacciones.cmbLIBRO_CONTABLE.Enabled = False
            Transacciones.dpFECHA_INI.Value = Me.dpFECHA_CONTABLE.Value.Date.AddDays(-(Me.dpFECHA_CONTABLE.Value.Day) + 1)
            Transacciones.dpFECHA_FIN.Value = Transacciones.dpFECHA_INI.Value.AddMonths(1).AddDays(-1)
            Producto = ""
            Transacciones.ShowDialog(Me)
            If Producto <> "" Then
                Me.txtTransaccion.Text = Producto
                BuscaPartida(Compañia, Producto)
            End If
        End If
    End Sub

    Private Sub BuscaPartida(ByVal Compañia, ByVal Transaccion)
        Conexion_ = jClass.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "EXECUTE sp_CONTABILIDAD_PARTIDAS_ENCABEZADO " & vbCrLf
            sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            sql &= ",@TRANSACCION = " & Transaccion & vbCrLf
            sql &= ",@BANDERA = 1"
            Comando_ = New SqlCommand(sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            If DataReader_.Read = True Then

                tipoDoc = DataReader_.Item("TIPO_DOCUMENTO")
                tipoPartida = DataReader_.Item("TIPO_PARTIDA")

                documento = DataReader_.Item("DOCUMENTO")
                numPartida = DataReader_.Item("PARTIDA")
                fechaCont = DataReader_.Item("FECHA_CONTABLE")
                concepto = DataReader_.Item("CONCEPTO")
                Dim Procesada As Boolean = DataReader_.Item("PROCESADO")
                If Procesada Then
                    CargaPartida(Compañia, numPartida)
                Else
                    MsgBox("La Partida no está procesada.", MsgBoxStyle.Information, "Mensaje")
                End If
            Else
                MsgBox("No existe la Transacción N° " & Transaccion & ", no se puede encontrar la Partida", MsgBoxStyle.Information, "Mensaje")
                limpiaCampos()
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaPartida(ByVal Compañia, ByVal Partida)
        Dim consulta As String = ""
        Dim nulled As Boolean = False
        consulta = bquery.generarQueryBusqueda(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, "", 1, "", "", "", "", "", Partida)
        Conexion_ = jClass.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            table = jClass.LlenaDT(Conexion_, DataAdapter_, Comando_, consulta, table)
            For i As Integer = 1 To table.Rows.Count
                If table.Rows(i - 1)(6).ToString = "Anulada" Then
                    nulled = True
                    Exit For
                End If
            Next
            Conexion_.Close()
            If nulled = True Then
                MsgBox("La partida ya está anulada, elija otra", MsgBoxStyle.Information, "Mensaje")
            Else

                Me.cmbTIPO_DOCUMENTO.SelectedValue = tipoDoc
                Me.cmbTIPO_PARTIDA.SelectedValue = tipoPartida

                Me.txtNumDoc.Text = documento
                Me.txtPartida.Text = numPartida
                Me.dpFECHA_CONTABLE.Value = CDate(jClass.obtenerEscalar("SELECT FECHA_CONTABLE FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE COMPAÑIA= " & Compañia & " AND TRANSACCION = " & Me.txtTransaccion.Text))
                Me.txtConcepto.Text = concepto

                'Me.txtTransaccion.Text = Producto

                mostrarDetalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Val(Me.txtTransaccion.Text))

                Producto = ""

            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub mostrarDetalle(ByVal cia, ByVal lc, ByVal trans)
        Conexion_ = jClass.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_PARTIDAS_DETALLE "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & trans
            sql &= ", 3"
            table = jClass.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, table)
            If table.ToString <> Nothing Then
                Me.dgvPartidas.Columns.Clear()
                Me.dgvPartidas.DataSource = table
                jClass.ajustarGrid(4, Me.dgvPartidas)
            Else
                MsgBox("No existe detalle para esa partida", MsgBoxStyle.Information, "Mensaje")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim Correlativo As Integer
        Try
            If Me.dgvPartidas.RowCount = 0 Then
                MsgBox("No hay partidas para anular", MsgBoxStyle.Information, "Mensaje")
            Else
                If Me.txtMotivo.Text.Length = 0 Then
                    MsgBox("Debe ingresar un motivo para reprocesar.", MsgBoxStyle.Information, "Validación")
                    Return
                End If
                'Consulta al usuario si quiere anular la partida o no
                If MsgBox("¿Está seguro(a) de desbloquear la partida No." & Me.txtPartida.Text & "?", MsgBoxStyle.YesNo, "CONFIRMAR ACCION") = MsgBoxResult.Yes Then
                    'Si acepta
                    DesProcesa_Transaccion(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, CInt(Me.txtTransaccion.Text))
                    'Inserta registro de auditoria
                    Correlativo = jClass.obtenerEscalar("SELECT ISNULL(MAX(CORRELATIVO),0) + 1 FROM CONTABILIDAD_AUDITORIA_PARTIDAS_DESPROCESADAS WHERE COMPAÑIA = " & Compañia & " AND TRANSACCION = " & Me.txtTransaccion.Text)
                    sql = "INSERT INTO [dbo].[CONTABILIDAD_AUDITORIA_PARTIDAS_DESPROCESADAS]"
                    sql &= "           ([COMPAÑIA]"
                    sql &= "           ,[PARTIDA]"
                    sql &= "           ,[TRANSACCION]"
                    sql &= "           ,[FECHA_PARTIDA]"
                    sql &= "           ,[MOTIVO]"
                    sql &= "           ,[CORRELATIVO]"
                    sql &= "           ,[USUARIO_CREACION]"
                    sql &= "           ,[USUARIO_CREACION_FECHA])"
                    sql &= "     VALUES"
                    sql &= "           (" & Compañia
                    sql &= "           ," & Me.txtPartida.Text
                    sql &= "           ," & Me.txtTransaccion.Text
                    sql &= "           ,'" & Format(Me.dpFECHA_CONTABLE.Value, "dd/MM/yyyy") & "'"
                    sql &= "           ,'" & Me.txtMotivo.Text & "'"
                    sql &= "           ," & Correlativo
                    sql &= "           ,'" & Usuario & "'"
                    sql &= "           ,GETDATE())"
                    Correlativo = jClass.ejecutarComandoSql(New SqlCommand(sql))
                    MsgBox("Proceso Finalizado", MsgBoxStyle.Information, "Información")
                Else
                    'Si no quiere, este MsgBox confirma la decision tomada
                    MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                End If
            End If
            limpiaCampos()
        Catch ex As Exception
            jClass.msjError(ex, "Desbloquear Partidas")
        End Try
    End Sub

    Private Sub limpiaCampos()
        Me.txtPartida.Clear()
        Me.txtTransaccion.Clear()
        Me.txtConcepto.Clear()
        Me.txtNumDoc.Clear()
        Me.mostrarDetalle(0, 0, 0)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiaCampos()
    End Sub

    Private Sub Contabilidad_DesProcesar_Partidas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Function ValidaCierreContablePermisos(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA       = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO            = " & Año & vbCrLf
            Sql &= ",@MES            = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE     = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL   = 0" & vbCrLf
            Sql &= ",@PROCESADO      = 0" & vbCrLf
            Sql &= ",@USUARIO        = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD            = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                Return True
                Exit Function
            End If
            Conexion_.Close()
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function ValidaCierreContable(ByVal Compañia As Integer, ByVal LC As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal IUD As String) As Boolean
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim Datareader_ As SqlDataReader
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "EXECUTE sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD " & vbCrLf
            Sql &= " @COMPAÑIA = " & Compañia & vbCrLf
            Sql &= ",@LIBRO_CONTABLE = " & LC & vbCrLf
            Sql &= ",@AÑO = " & Año & vbCrLf
            Sql &= ",@MES = " & Mes & vbCrLf
            Sql &= ",@PRE_CIERRE = 0" & vbCrLf
            Sql &= ",@CIERRE_FINAL = 0" & vbCrLf
            Sql &= ",@PROCESADO = 0" & vbCrLf
            Sql &= ",@USUARIO = '" & Usuario & "'" & vbCrLf
            Sql &= ",@IUD = '" & IUD & "' "
            Comando_ = New SqlCommand(Sql, Conexion_)
            Datareader_ = Comando_.ExecuteReader
            If Datareader_.Read = True Then
                If Datareader_.Item("PROCESADO") = True Then
                    MsgBox("¡El Período Contable ya está CERRADO y PROCESADO!" & vbCrLf & "No es posible generar la Transacción.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("CIERRE_FINAL") = True Then
                    MsgBox("¡El Período Contable ya está en CIERRE FINAL!" & vbCrLf & "No es posible generar la Transacción. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
                If Datareader_.Item("PRE_CIERRE") = True Then
                    If ValidaCierreContablePermisos(Compañia, LC, Año, Mes, "L") = False Then
                        MsgBox("!El Período Contable se encuentra en PRE CIERRE!" & vbCrLf & "No podrá registrar partidas en dicho período. Verifique la Fecha Contable y comuníquese con el Contador General.", MsgBoxStyle.Critical, "Validación")
                        Return False
                        Exit Function
                    End If
                End If
            Else
                If IUD = "E" Then
                    MsgBox("¡No existe el Período Contable! Llame al Contador General" & vbCrLf & "No podrá registrar partidas en dicho período.", MsgBoxStyle.Critical, "Validación")
                    Return False
                    Exit Function
                End If
            End If
            Conexion_.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub txtPARTIDA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPARTIDA_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPARTIDA.Leave
        If Me.txtPARTIDA.Text.Length > 0 Then
            Sql = "SELECT TRANSACCION FROM CONTABILIDAD_PARTIDAS_ENCABEZADO "
            Sql &= " WHERE COMPAÑIA = " & Compañia
            Sql &= "   AND MONTH(FECHA_CONTABLE) = " & Me.dpFECHA_CONTABLE.Value.Month
            Sql &= "   AND YEAR(FECHA_CONTABLE) = " & Me.dpFECHA_CONTABLE.Value.Year
            Sql &= "   AND PARTIDA = " & Me.txtPARTIDA.Text
            Me.txtTRANSACCION.Text = jClass.obtenerEscalar(Sql)
            If Me.txtTRANSACCION.Text.Length > 0 Then
                BuscaPartida(Compañia, Val(Me.txtTransaccion.Text))
            Else
                MsgBox("No existe Partida N° " & Me.txtPartida.Text & vbCrLf & "para el periodo contable: " & vbCrLf & Format(Me.dpFECHA_CONTABLE.Value, "MMMM-yyyy").ToUpper(), MsgBoxStyle.Information, "Búsqueda")
            End If
        End If
    End Sub

    Private Sub DesProcesa_Transaccion(ByVal Compañia As Integer, ByVal LibroContable As Integer, ByVal Transaccion As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            sql = "UPDATE CONTABILIDAD_PARTIDAS_ENCABEZADO " & vbCrLf
            sql &= " SET PROCESADO = 0, USUARIO_EDICION = '" & Usuario & "', USUARIO_EDICION_FECHA = GETDATE()" & vbCrLf
            sql &= " WHERE COMPAÑIA  = " & Compañia & vbCrLf
            sql &= "  AND TRANSACCION    = " & Transaccion
            Comando_ = New SqlCommand(sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class