Imports System.Data.SqlClient

Public Class Contabilidad_Reportes_Libros_Legales
    Dim Sql As String
    Dim Table As DataTable
    Dim jClass As New jarsClass
    Dim LibroPrincipal As Integer

    Private Sub Contabilidad_Reportes_Libros_Legales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        LibroPrincipal = CInt(jClass.obtenerEscalar("SELECT LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPAÑIA = " & Compañia & " AND LIBRO_PRINCIPAL = 1"))
        Niveles()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Niveles()
        Dim NivelTable As New DataTable
        NivelTable.Columns.Add("Nivel", Type.GetType("System.Int32"))
        NivelTable.Columns.Add("Nombre", Type.GetType("System.String"))
        NivelTable.Rows.Add(8, "SUBCUENTA")
        NivelTable.Rows.Add(6, "MAYOR")
        NivelTable.Rows.Add(4, "CUENTA")
        Me.cmbNivel.DataSource = NivelTable
        Me.cmbNivel.DisplayMember = "Nombre"
        Me.cmbNivel.ValueMember = "Nivel"
        Me.cmbNivel.SelectedValue = 8
    End Sub

    Private Sub btnVerBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBC.Click
        Dim Rpt As New Contabilidad_Reportes_Libros_Legales_Rpt
        Try
            Sql = "EXECUTE sp_CONTABILIDAD_REPORTES_LIBROS_LEGALES_RPT "
            Sql &= " @COMPAÑIA       = " & Compañia
            Sql &= ",@LIBRO_CONTABLE = " & LibroPrincipal
            Sql &= ",@CUENTA_MAYOR   = " & Me.cmbNivel.SelectedValue
            Sql &= ",@FECHA_FIN      = '" & Date.DaysInMonth(Me.dpFECHA_CONTABLE.Value.Year, Me.dpFECHA_CONTABLE.Value.Month).ToString() & Format(Me.dpFECHA_CONTABLE.Value, "/MM/yyyy") & "'"
            If Me.chkGober.Checked Then
                Sql &= ",@CATGOBER = 2"
            End If
            Table = jClass.obtenerDatos(New SqlCommand(Sql))
            If Table.Rows.Count > 0 Then
                Hay_Datos = True
                Rpt.SetDataSource(Table)
                Me.crvReporte.ReportSource = Rpt
            Else
                Me.crvReporte.ReportSource = Nothing
                MsgBox("NO EXISTEN DATOS PARA DICHA ESPECIFICACION.", MsgBoxStyle.Exclamation, "AVISO")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "AVISO")
        End Try
    End Sub
End Class