Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Contabilidad_Partidas_Anulacion

    'Constructores
    Dim fill As New cmbFill
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
    Dim Rpts As New frmReportes_Ver

    'Carga de valores en el formulario
    Private Sub Contabilidad_Partidas_Anulacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaLibrosContables(Compañia, cmbLIBRO_CONTABLE)
        fill.CargaTipoDocumento(Compañia, cmbTIPO_DOCUMENTO)
        fill.CargaTipoPartida(Compañia, cmbTIPO_PARTIDA)
        Iniciando = False
    End Sub

    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        If Trim(Me.txtNumPartida.Text) = "" Or Trim(Me.txtNumPartida.Text) = "0" Then
            Dim Transacciones As New Contabilidad_BusquedaTransaccion
            Transacciones.Compañia_Value = Compañia
            Transacciones.LibroContable_Value = Me.cmbLIBRO_CONTABLE.SelectedValue
            Transacciones.cmbLIBRO_CONTABLE.Enabled = False
            Transacciones.dpFECHA_INI.Value = Me.dpFechaAnulacion.Value.Date.AddDays(-(Me.dpFechaAnulacion.Value.Day) + 1)
            Transacciones.dpFECHA_FIN.Value = Transacciones.dpFECHA_INI.Value.AddMonths(1).AddDays(-1)
            Producto = ""
            Transacciones.ShowDialog(Me)
            If Producto <> "" Then
                BuscaPartida(Compañia, Producto)
            End If
        End If
    End Sub

    Private Sub BuscaPartida(ByVal Compañia, ByVal Transaccion)
        Conexion_ = fill.devuelveCadenaConexion()
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
                    MsgBox("La Partida no está procesada, no puede anularla", MsgBoxStyle.Information, "Mensaje")
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
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, consulta, table)
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
                Me.txtNumPartida.Text = numPartida
                Me.txtFechaCont.Text = fechaCont
                Me.txtConcepto.Text = concepto

                Me.txtTransaccion.Text = Producto

                mostrarDetalle(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Producto)

                Producto = ""

            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub mostrarDetalle(ByVal cia, ByVal lc, ByVal trans)
        Conexion_ = fill.devuelveCadenaConexion()
        Try
            Conexion_.Open()
            sql = "Execute sp_CONTABILIDAD_PARTIDAS_DETALLE "
            sql &= cia
            sql &= ", " & lc
            sql &= ", " & trans
            sql &= ", 3"
            table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, sql, table)
            If table.ToString <> Nothing Then
                Me.dgvPartidas.Columns.Clear()
                Me.dgvPartidas.DataSource = table
                fill.ajustarGrid(4, Me.dgvPartidas)
            Else
                MsgBox("No existe detalle para esa partida", MsgBoxStyle.Information, "Mensaje")
            End If
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Mensaje")
        End Try
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If Me.txtMotivo.Text.Length > 0 Then
            If Me.dgvPartidas.RowCount = 0 Then
                MsgBox("No hay partidas para anular", MsgBoxStyle.Information, "Mensaje")
            Else
                If ValidaCierreContable(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.dpFechaAnulacion.Value.Year, Me.dpFechaAnulacion.Value.Month, "E") Then
                    'Consulta al usuario si quiere anular la partida o no
                    If MsgBox("¿Está seguro(a) de querer anular la partida No." & Me.txtNumPartida.Text & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        'Si acepta anular la partida
                        'variable para almacenar el numero de transaccion anulada
                        Dim numTransAnulada As Integer = 0
                        'variable para almacenar el numero de partida anulada
                        Dim numPartAnulada As Integer = 0
                        'Asignacion a la variable del correlativo generado para la transaccion anulada
                        numTransAnulada = fill.GeneraCorrelativo(Compañia, "TRA", Year(Me.dpFechaAnulacion.Value), Month(Me.dpFechaAnulacion.Value))
                        'Asignacion a la variable del correlativo generado para la partida anulada
                        numPartAnulada = fill.GeneraCorrelativo(Compañia, "PAR", Year(Me.dpFechaAnulacion.Value), Month(Me.dpFechaAnulacion.Value))
                        'Manda a llamar la clase que contiene el metodo para anular la partida
                        fill.anulacionPartida(Compañia, Me.txtTransaccion.Text, numTransAnulada, numPartAnulada, Format(Me.dpFechaAnulacion.Value, "dd/MM/yyyy"), Me.txtMotivo.Text)
                        If numTransAnulada > 0 Then
                            Me.lblPdaAnula.Text = "Partida Anulación: " & numPartAnulada
                            Rpts.CargaPartida(Compañia, Me.cmbLIBRO_CONTABLE.SelectedValue, numTransAnulada, numTransAnulada, Year(Me.dpFechaAnulacion.Value), Month(Me.dpFechaAnulacion.Value), 1)
                            Rpts.ShowDialog()
                        End If
                    Else
                        'Si no quiere anular la partida, este MsgBox confirma la decision tomada
                        MsgBox("Operación Cancelada", MsgBoxStyle.Information, "Mensaje")
                    End If
                End If
                limpiaCampos()
            End If
        Else
            MsgBox("Digite un Motivo de anulacion", MsgBoxStyle.Information, "Operación Cancelada")
        End If
    End Sub

    Private Sub limpiaCampos()
        Me.txtNumPartida.Clear()
        Me.txtTransaccion.Clear()
        Me.txtFechaCont.Clear()
        Me.txtConcepto.Clear()
        Me.txtNumDoc.Clear()
        'fill.CargaTipoDocumento(Compañia, cmbTIPO_DOCUMENTO)
        'fill.CargaTipoPartida(Compañia, cmbTIPO_PARTIDA)
        Me.mostrarDetalle(0, 0, 0)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiaCampos()
    End Sub

    Private Sub Contabilidad_Partidas_Anulacion_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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
End Class