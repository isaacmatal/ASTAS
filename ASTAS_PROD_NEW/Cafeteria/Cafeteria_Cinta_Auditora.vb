Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Cafeteria_Cinta_Auditora
    Dim Sql As String
    Dim fill As New cmbFill
    Dim Rpts As New frmReportes_Ver
    Dim jasr_fill As New jarsClass
    Dim Frm_Bodegas As New Cafeteria_Busqueda_Recetas_por_Bodega

    Dim Conexion As New DLLConnection.Connection
    Dim Conexion_ As New SqlConnection
    Dim Comando_ As SqlCommand
    Dim DataAdapter_ As SqlDataAdapter
    Dim Table As DataTable
    Dim DS As New DataSet
    Dim DataReader_ As SqlDataReader
    Dim TICKET As New GenerarTicket

    Dim Iniciando As Boolean
    Private Sub Cafeteria_Cinta_Auditora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        fill.CargaCompañia(Me.cmbCOMPAÑIA)
        jasr_fill.CargaBodegas(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbBODEGA, 7)
        CargarTiempoComida(Me.cmbCOMPAÑIA.SelectedValue, Me.cmbTiempo, "S")
        Iniciando = False
    End Sub
#Region "Connection"
    Dim Conexion_Track As New SqlConnection
    Dim Comando_Track As SqlCommand
    Dim DataReader_Track As SqlDataReader
    Dim DataAdapter As SqlDataAdapter
    Dim DataReader01 As SqlDataReader
    Dim DS01, DS02 As New DataSet()
    Dim Resultado As DialogResult
    Sub OpenConnection()
        Conexion_Track = New SqlConnection(DLLConnection.Connection.Obtiene_Cadena_Cnn_SQL)
        Conexion_Track.Open()
    End Sub
    Sub MiddleConnection()
        Comando_Track = New SqlCommand(Sql, Conexion_Track)
        DataAdapter = New SqlDataAdapter(Comando_Track)
    End Sub
    Sub CloseConnection()
        Conexion_Track.Close()
    End Sub

#End Region
    Sub CargarTiempoComida(ByVal Compañia As Integer, ByVal cmbTiempo As ComboBox, ByVal IUD As Char)
        Try
            Conexion_ = jasr_fill.devuelveCadenaConexion()
            Sql = "Execute sp_CAFETERIA_CATALOGO_TIEMPO_COMIDA "
            Sql &= Compañia
            Sql &= ", '" & IUD & "'"
            Table = fill.LlenaDT(Conexion_, DataAdapter_, Comando_, Sql, Table)
            Conexion_.Close()
            cmbTiempo.DataSource = Table
            cmbTiempo.ValueMember = "Tiempo de Comida"
            cmbTiempo.DisplayMember = "Descripción"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    'Public Sub GuardarTicket()

    '    TICKET.AbrirArchivo()
    '    TICKET.EscribirTicket(direccion)
    '    TICKET.EscribirTicket("Ticket # " & correlativo_Actual & " " & descripcion_bodega & " CAJA No." & Caja)
    '    TICKET.EscribirTicket("Fecha   :" & dtpFechaTrabajo.Value.ToString())
    '    TICKET.EscribirTicket("---------------------------------------")
    '    TICKET.EscribirTicket("Resolucion: " & Me.Resolucion)
    '    TICKET.EscribirTicket("Fecha de Resolucion: " & Format(Me.fecha_resolucion, "Long Date"))
    '    TICKET.EscribirTicket("Autorizada: " & Format(Me.fecha_autorizacion, "Long Date"))
    '    TICKET.EscribirTicket("  Del " & serie.PadRight(6, "0") & del.PadLeft(6, "0"))
    '    TICKET.EscribirTicket("   al " & serie.PadRight(6, "0") & al.PadLeft(6, "0"))
    '    TICKET.EscribirTicket("---------------------------------------")
    '    TICKET.EscribirTicket("Codigo C:" & txtCodigoEmpleado.Text)
    '    TICKET.EscribirTicket("Cliente :" & txtNombreEmpleado.Text)
    '    TICKET.EscribirTicket("Tiempo C:" & tiempo_c)
    '    TICKET.EscribirTicket("---------------------------------------")
    '    '23 ESPACIOS PARA EL PRODUCTO
    '    TICKET.EscribirTicket("Cant Producto---------------P/U--Prec.T")

    '    For i As Integer = 0 To listaTicket.Count - 1
    '        TICKET.EscribirTicket(listaTicket.Item(i).Trim)
    '    Next
    '    TICKET.EscribirTicket("")
    '    Dim total As Double, descuento1 As Double, gravada As Double

    '    gravada = Convert.ToDouble(txtTotalPagar.Text)

    '    descuento1 = Convert.ToDouble(Me.DESCUENTO)


    '    TICKET.EscribirTicket("         Desc.Aplicar    :" & descuento1.ToString("0.00").PadLeft(13, "."))
    '    TICKET.EscribirTicket("         Dispon Desc.    :" & saldo.ToString("0.00").PadLeft(13, "."))
    '    If (rbEfectivo.Checked = True) Then
    '        total = Val(txtTotalPagar.Text) + Val(Me.DESCUENTO)
    '    Else
    '        'CREDITO 
    '        total = Val(A)
    '    End If
    '    TICKET.EscribirTicket("Subtt. Vta. Gravada     $:" & total.ToString("0.00").PadLeft(9, "."))
    '    TICKET.EscribirTicket("Subtt. Vta. Exenta      $:.........0.00")
    '    TICKET.EscribirTicket("Subtt. Vta. Disponible  $:.........0.00")
    '    TICKET.EscribirTicket("Subtt. Vta. No Suj.     $:.........0.00")

    '    TICKET.EscribirTicket("Venta Total             $:" & total.ToString("0.00").PadLeft(9, "."))
    '    TICKET.EscribirTicket("")

    '    If (txtTotalPagar.Text > 200) Then
    '        TICKET.EscribirTicket("")
    '        TICKET.EscribirTicket("Nombre: ")
    '        TICKET.EscribirTicket("Nit/Dui:")
    '        TICKET.EscribirTicket("F.______________")
    '    End If

    '    TICKET.EscribirTicket("")
    '    TICKET.EscribirTicketFiscal(Chr(27) & Chr(105))
    '    TICKET.EscribirTicketFiscal(Chr(25))
    '    TICKET.CerrarArchivo()
    'End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

    End Sub
End Class