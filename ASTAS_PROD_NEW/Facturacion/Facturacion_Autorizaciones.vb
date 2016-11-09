Imports System.Data.SqlClient
Public Class Facturacion_Autorizaciones
    Dim jClass As New jarsClass
    Public idAutotizacion As Integer = -1
    Dim idtipo As String
    Dim idparTipo As Integer

    Public Sub New(ByVal partipo As Integer)
        ' 3 Param
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        idparTipo = partipo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If prConfirma_Autorizacion() Then
            If (idtipo = 1 And idparTipo = 1) Or (idtipo = 2 And idparTipo = 2) Or (idtipo = 3 And idparTipo = 1) Or (idtipo = 3 And idparTipo = 2) Then
                MessageBox.Show("Autorizacion Confirmada...", "ASTAS", MessageBoxButtons.OK)
                Me.Close()
            Else
                idAutotizacion = -1
                MessageBox.Show("Usuario no esta autorizado para este tipo de transaccion...", "ASTAS", MessageBoxButtons.OK)
                Me.Close()
            End If
            
        Else
        End If
    End Sub

    Private Function prConfirma_Autorizacion() As Boolean
        Dim sqlCmd As New SqlCommand("Execute sp_CATALOGO_USUARIOS " & 1 & ", '" & Trim(Me.txtUsuario.Text) & "', '" & Me.txtClave.Text & "' , 4 ")
        If Me.txtUsuario.Text <> "" And Me.txtClave.Text <> "" Then
            Dim Table As DataTable = jClass.obtenerDatos(sqlCmd)
            If Table.Rows.Count > 0 Then
                For a As Integer = 0 To Table.Rows.Count - 1
                    idAutotizacion = Trim(Table.Rows(a).Item("IDAUTORIZACION"))
                    idtipo = Trim(Table.Rows(a).Item("TIPO_AUTORIZACION"))
                Next
                Return True
            Else
                MsgBox("Autorizacion Denegada...." & Chr(13) & "Verifique la información digitada.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        Else
            MsgBox("Favor ingrese 'Usuario' y 'Contraseña' válidos.", MsgBoxStyle.Critical, "Error")
        End If
    End Function

    Private Sub Facturacion_Autorizaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If idparTipo = 1 Then
            Me.Text = "Confirmacion de Autorizacion de Autoconsumo...."
        Else
            Me.Text = "Confirmacion de Autorizacion de Descuento por Producto...."
        End If
    End Sub


End Class