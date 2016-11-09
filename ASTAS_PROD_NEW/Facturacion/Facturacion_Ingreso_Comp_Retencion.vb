Imports System.Data
Imports System.Data.SqlClient

Public Class Facturacion_Ingreso_Comp_Retencion
    Dim _numOV As Integer
    Dim _numFact As Integer
    Dim _Bodega As Integer
    Dim Table As DataTable
    Dim jClass As New jarsClass

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(ByVal numOv As Integer, ByVal numFact As Integer, ByVal Bodega As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _numOV = numOv
        _numFact = numFact
        _Bodega = Bodega
    End Sub

    Private Sub Facturacion_Ingreso_Comp_Retencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        Me.txtNoFact.Text = _numFact
        Table = jClass.obtenerDatos(New SqlCommand("SELECT NOMBRE_FACTURA, SUB_TOTAL, TOTAL_IVA, RETENCION, TOTAL_FACTURA, COMPROB_RETENCION FROM FACTURACION_GENERADA_ENCABEZADO WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & _Bodega & " AND ORDEN_VENTA = " & _numOV & " AND NUMERO_FACTURA = " & _numFact & " AND TIPO_DOCUMENTO = 2"))
        Me.txtNomFact.Text = Table.Rows(0).Item(0).ToString()
        Me.txtSUBTOTAL.Text = Table.Rows(0).Item(1).ToString()
        Me.txtIVA.Text = Table.Rows(0).Item(2).ToString()
        Me.txtRetencion.Text = Table.Rows(0).Item(3).ToString()
        Me.txtTotFact.Text = Table.Rows(0).Item(4).ToString()
        Me.txtNumComp.Text = Table.Rows(0).Item(5).ToString()
    End Sub

    Private Sub btnGuardaFacturaEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaFacturaEncabezado.Click
        Dim sql As String
        sql = " UPDATE FACTURACION_GENERADA_ENCABEZADO" & vbCrLf
        sql &= "   SET RETENCION = " & Me.txtRetencion.Text & ", COMPROB_RETENCION = " & Me.txtNumComp.Text & vbCrLf
        sql &= " WHERE COMPAÑIA = " & Compañia & " AND BODEGA = " & _Bodega & " AND ORDEN_VENTA = " & _numOV & " AND NUMERO_FACTURA = " & _numFact & " AND TIPO_DOCUMENTO = 2"
        If jClass.ejecutarComandoSql(New SqlCommand(sql)) > 0 Then
            MsgBox("Datos actualizados", MsgBoxStyle.Information, "Retencion")
        Else
            MsgBox("Error al actualizar datos.", MsgBoxStyle.Information, "Retencion")
        End If
    End Sub

    Private Sub txtNumComp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumComp.TextChanged
        If Val(Me.txtNumComp.Text) > 0 Then
            Me.txtRetencion.Text = Format(Math.Round(Val(Me.txtSUBTOTAL.Text) * 0.01, 2, MidpointRounding.AwayFromZero), "0.00")
        Else
            Me.txtRetencion.Text = "0.00"
        End If
    End Sub
End Class