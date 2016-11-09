Imports System.Windows.Forms

Public Class Productos_Sin_Existencias
    Dim listaTicket As New List(Of String)
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Productos_Sin_Existencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("LOS SIGUIENTES PRODUCTOS NO TIENEN EXISTENCIAS:")
        ListBox1.Items.Add(" ")
        For i As Integer = 0 To listaTicket.Count - 1
            ListBox1.Items.Add("-" + listaTicket.Item(i).Trim())
        Next
    End Sub
    Public Sub New(ByVal lista As List(Of String))

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        listaTicket = lista
    End Sub
End Class
