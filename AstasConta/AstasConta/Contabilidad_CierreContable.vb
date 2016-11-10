Imports System.Data.SqlClient

Public Class Contabilidad_CierreContable
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim jClass As New jarsClass

    Private Sub Contabilidad_CierreContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Me.pbImagen.Image = System.Drawing.Image.FromFile(ImagenPath)
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaLibrosContables()
        CargaMeses()
        CargaCierres(Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
        Me.nudA�O.Value = Year(Now)
        Iniciando = False
    End Sub

    Private Sub CargaLibrosContables()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_LIBRO_CONTABLE " & Compa�ia
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbLIBRO_CONTABLE.DataSource = Table
            Me.cmbLIBRO_CONTABLE.ValueMember = "C�digo"
            Me.cmbLIBRO_CONTABLE.DisplayMember = "Descripci�n"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargaMeses()
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)
        Try
            Conexion_.Open()
            Sql = "SELECT MES, DESCRIPCION_MES FROM CONTABILIDAD_CATALOGO_MESES "
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Comando_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.cmbMES.DataSource = Table
            Me.cmbMES.ValueMember = "MES"
            Me.cmbMES.DisplayMember = "DESCRIPCION_MES"
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LimpiaGrid()
        Me.dgvCierres.Columns.Item(0).Width = 50
        Me.dgvCierres.Columns.Item(1).Width = 50
        Me.dgvCierres.Columns.Item(2).Width = 75
        Me.dgvCierres.Columns.Item(3).Width = 75
        Me.dgvCierres.Columns.Item(4).Width = 75
        Me.dgvCierres.Columns.Item(5).Width = 75
        Me.dgvCierres.Columns.Item(6).Width = 75
        Me.dgvCierres.Columns.Item(7).Width = 125
        Me.dgvCierres.Columns(1).Visible = False
    End Sub

    Private Sub CargaCierres(ByVal LC As Integer, ByVal Bandera As Integer)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim Table As DataTable
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            'Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE "
            'Sql &= Compa�ia
            'Sql &= ", " & LC
            'Sql &= ", " & Bandera
            Sql = "	SELECT	A�O AS [A�o],"
            Sql &= "			MES AS [CodMes],"
            Sql &= "			DESCRIPCION_MES AS [Mes],"
            Sql &= "			PRE_CIERRE AS [Pre-Cierre],"
            Sql &= "			CIERRE_FINAL AS [Cierre Final],"
            Sql &= "			CASE (SELECT COUNT(TRANSACCION) FROM CONTABILIDAD_PARTIDAS_ENCABEZADO WHERE PROCESADO = 0 AND MONTH(FECHA_CONTABLE) = VISTA_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE.MES AND YEAR(FECHA_CONTABLE) = VISTA_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE.A�O AND COMPA�IA = " & Compa�ia & ") WHEN 0 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END AS Procesado,"
            Sql &= "			USUARIO_CREACION AS [Usuario Creaci�n],"
            Sql &= "			USUARIO_CREACION_FECHA AS [Fecha Creaci�n]"
            Sql &= "  FROM VISTA_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE"
            Sql &= "	WHERE COMPA�IA = " & Compa�ia
            Sql &= "		AND LIBRO_CONTABLE = " & LC
            Sql &= "	ORDER BY A�O DESC , [CodMes] DESC"

            Comando_ = New SqlCommand(Sql, Conexion_)
            DataAdapter_ = New SqlDataAdapter(Sql, Conexion_)
            Table = New DataTable("Datos")
            DataAdapter_.Fill(Table)
            Me.dgvCierres.Columns.Clear()
            Me.dgvCierres.DataSource = Table
            LimpiaGrid()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Mantenimiento_Cierres(ByVal Compa��a, ByVal LC, ByVal A�o, ByVal Mes, ByVal PreCierre, ByVal CierreFinal, ByVal Procesado, ByVal IUD)
        Dim Conexion_ As New SqlConnection
        Dim Comando_ As SqlCommand
        Conexion_ = New SqlConnection(CnnStrBldr.ConnectionString)

        Try
            Conexion_.Open()
            Sql = "Execute sp_CONTABILIDAD_CATALOGO_CIERRE_CONTABLE_IUD "
            Sql &= Compa�ia
            Sql &= ", " & LC
            Sql &= ", " & A�o
            Sql &= ", " & Mes
            Sql &= ", " & PreCierre
            Sql &= ", " & CierreFinal
            Sql &= ", " & Procesado
            Sql &= ", '" & Usuario & "'"
            Sql &= ", '" & IUD & "'"
            Comando_ = New SqlCommand(Sql, Conexion_)
            Comando_.ExecuteNonQuery()
            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Dim Validated As Boolean = True
        If Trim(Me.nudA�O.Text) = "" Then
            MsgBox("�Ingrese un n�mero de A�o v�lido! Verfique", MsgBoxStyle.Critical, "Validaci�n")
            Validated = False
            Exit Function
        End If
        Return Validated
    End Function

    Private Sub LimpiaCampos()
        Me.chkPRE_CIERRE.Checked = False
        Me.chkCIERRE_FINAL.Checked = False
        Me.lblPROCESADO.Visible = False
        Me.btnGuardar.Enabled = True
    End Sub

    Private Sub cmbCOMPA�IA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Iniciando = False Then
            CargaLibrosContables()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaCampos() = True Then
            Mantenimiento_Cierres(Compa�ia, Me.cmbLIBRO_CONTABLE.SelectedValue, Me.nudA�O.Value, Me.cmbMES.SelectedValue, IIf(Me.chkPRE_CIERRE.Checked = True, "1", "0"), IIf(Me.chkCIERRE_FINAL.Checked = True, "1", "0"), IIf(Me.lblPROCESADO.Visible = True, "1", "0"), "I")
        End If
        CargaCierres(Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
        LimpiaCampos()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim frmProc As New Contabilidad_Procesar_Partidas
        frmProc.dpPeriodo.Value = CDate(Me.nudA�O.Value & "-" & Me.cmbMES.SelectedValue.ToString.PadLeft(2, "0") & "-01")
        frmProc.ShowInTaskbar = False
        frmProc.ShowDialog(Me)
    End Sub

    Private Sub dgvCierres_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCierres.CellEnter
        If Me.dgvCierres.CurrentRow.Cells.Item(5).Value = True Then
            Me.lblPROCESADO.Visible = True
        Else
            Me.lblPROCESADO.Visible = False
        End If
        Me.nudA�O.Value = Me.dgvCierres.CurrentRow.Cells.Item(0).Value
        Me.cmbMES.SelectedValue = Me.dgvCierres.CurrentRow.Cells.Item(1).Value
        Me.chkPRE_CIERRE.Checked = Me.dgvCierres.CurrentRow.Cells.Item(3).Value
        Me.chkCIERRE_FINAL.Checked = Me.dgvCierres.CurrentRow.Cells.Item(4).Value
    End Sub

    Private Sub cmbLIBRO_CONTABLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLIBRO_CONTABLE.SelectedIndexChanged
        If Iniciando = False Then
            CargaCierres(Me.cmbLIBRO_CONTABLE.SelectedValue, 1)
        End If
    End Sub

    Private Sub Contabilidad_CierreContable_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Rect As Rectangle = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim LinearBrush As Drawing2D.LinearGradientBrush = _
               New Drawing2D.LinearGradientBrush(Rect, Color.Gray, Color.PowderBlue, _
               Drawing2D.LinearGradientMode.Vertical)
        Dim g As Graphics = e.Graphics
        g.FillRectangle(LinearBrush, 0, 0, sender.Width, sender.Height)
    End Sub

    Private Sub chkCIERRE_FINAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCIERRE_FINAL.CheckedChanged
        If Me.chkCIERRE_FINAL.Checked Then
            If Not Me.lblPROCESADO.Visible Then
                MsgBox("NO SE PUEDE CERRAR EL PERIODO CONTABLE" & vbCrLf & "EXISTEN PARTIDAS PENDIENTES DE PROCESAR.", MsgBoxStyle.Information, "Cierre Contable")
                Me.chkCIERRE_FINAL.Checked = False
            End If
        End If
    End Sub

    Private Sub btnRegeneraSaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegeneraSaldos.Click
        If MsgBox("Se van a recalcular los saldos para el periodo contable: " & Me.cmbMES.Text.ToUpper() & "/" & Me.nudA�O.Value.ToString() & vbCrLf & vbCrLf & "�Desea Continuar?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes Then
            Sql = SaldosMes()
            jClass.Ejecutar_ConsultaSQL(Sql)
            Sql = SaldosMesDetalle()
            jClass.Ejecutar_ConsultaSQL(Sql)
        End If
    End Sub

    Private Function SaldosMes() As String
        Dim query As String
        query = "DECLARE @FECHACIERRE DATETIME = '01/" & Me.cmbMES.SelectedValue.ToString.PadLeft(2, "0") & "/" & Me.nudA�O.Value.ToString() & "'" & vbCrLf
        query &= "DECLARE @FECHAFINMES DATETIME " & vbCrLf
        query &= "SET @FECHAFINMES = DBO.EOMONTH(@FECHACIERRE)" & vbCrLf
        query &= "DECLARE @CUENTA INT, @CUENTA_COMPLETA VARCHAR(15), @MES INT = MONTH(@FECHACIERRE), @A�O INT = YEAR(@FECHACIERRE)" & vbCrLf
        query &= "DECLARE @TRANSACCION INT, @USUARIO VARCHAR(12) = '" & Usuario & "'" & vbCrLf
        query &= "" & vbCrLf
        query &= "DELETE FROM CONTABILIDAD_CATALOGO_CUENTAS_SALDOS WHERE COMPA�IA = " & Compa�ia & " AND MES = @MES AND A�O = @A�O" & vbCrLf
        query &= "DELETE FROM [dbo].[CONTABILIDAD_PARTIDAS_IMPRESION] WHERE TRANSACCION > 1 AND COMPA�IA = " & Compa�ia & vbCrLf
        query &= "" & vbCrLf
        query &= "DECLARE CUENTAS_ CURSOR FOR" & vbCrLf
        query &= "SELECT CUENTA, CUENTA_COMPLETA FROM CONTABILIDAD_CATALOGO_CUENTAS WHERE COMPA�IA = " & Compa�ia & " AND LIBRO_CONTABLE = " & Me.cmbLIBRO_CONTABLE.SelectedValue.ToString() & " AND CUENTA_MAYOR = 0" & vbCrLf
        query &= "" & vbCrLf
        query &= "OPEN CUENTAS_" & vbCrLf
        query &= "FETCH NEXT FROM CUENTAS_ INTO @CUENTA, @CUENTA_COMPLETA" & vbCrLf
        query &= "" & vbCrLf
        query &= "WHILE @@FETCH_STATUS = 0" & vbCrLf
        query &= "BEGIN" & vbCrLf
        query &= "      Execute sp_CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_IUD" & vbCrLf
        query &= "		" & Compa�ia & "," & vbCrLf
        query &= "		" & Me.cmbLIBRO_CONTABLE.SelectedValue.ToString() & "," & vbCrLf
        query &= "		@A�O," & vbCrLf
        query &= "		@MES," & vbCrLf
        query &= "		@CUENTA," & vbCrLf
        query &= "		@CUENTA_COMPLETA," & vbCrLf
        query &= "		0," & vbCrLf
        query &= "		0," & vbCrLf
        query &= "      'inicial'" & vbCrLf
        query &= "" & vbCrLf
        query &= "      FETCH NEXT FROM CUENTAS_ INTO @CUENTA, @CUENTA_COMPLETA" & vbCrLf
        query &= "END" & vbCrLf
        query &= "" & vbCrLf
        query &= "CLOSE CUENTAS_" & vbCrLf
        query &= "DEALLOCATE CUENTAS_" & vbCrLf
        query &= "" & vbCrLf
        query &= "DECLARE PROCESAR CURSOR FOR" & vbCrLf
        query &= "SELECT TRANSACCION, USUARIO_EDICION " & vbCrLf
        query &= "  FROM CONTABILIDAD_PARTIDAS_ENCABEZADO" & vbCrLf
        query &= " WHERE FECHA_CONTABLE >= @FECHACIERRE AND FECHA_CONTABLE <=@FECHAFINMES AND COMPA�IA = " & Compa�ia & vbCrLf
        query &= "" & vbCrLf
        query &= "OPEN PROCESAR" & vbCrLf
        query &= "FETCH NEXT FROM PROCESAR INTO @TRANSACCION, @USUARIO" & vbCrLf
        query &= "" & vbCrLf
        query &= "WHILE @@FETCH_STATUS = 0" & vbCrLf
        query &= "BEGIN" & vbCrLf
        query &= "	EXECUTE sp_CONTABILIDAD_PARTIDAS_PROCESAR " & Compa�ia & ", " & Me.cmbLIBRO_CONTABLE.SelectedValue.ToString() & ", @TRANSACCION, @USUARIO, 1" & vbCrLf
        query &= "" & vbCrLf
        query &= "	FETCH NEXT FROM PROCESAR INTO @TRANSACCION, @USUARIO" & vbCrLf
        query &= "END" & vbCrLf
        query &= "" & vbCrLf
        query &= "CLOSE PROCESAR" & vbCrLf
        query &= "DEALLOCATE PROCESAR"
        Return query
    End Function

    Private Function SaldosMesDetalle() As String
        Dim query As String
        query = "DECLARE @COMPA�IA INT=" & Compa�ia & ", @LIBRO_CONTABLE INT, @MES INT, @A�O INT, @FECHAAPERTURA AS DATETIME = '01/" & Me.cmbMES.SelectedValue.ToString.PadLeft(2, "0") & "/" & Me.nudA�O.Value.ToString() & "'" & vbCrLf
        query &= "" & vbCrLf
        query &= "SET @MES = MONTH(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @A�O = YEAR(@FECHAAPERTURA)" & vbCrLf
        query &= "SET @FECHAAPERTURA = DATEADD(M, 1, @FECHAAPERTURA)" & vbCrLf
        query &= "SELECT @LIBRO_CONTABLE = LIBRO_CONTABLE FROM CONTABILIDAD_CATALOGO_LIBRO_CONTABLE WHERE COMPA�IA = @COMPA�IA AND LIBRO_PRINCIPAL = 1" & vbCrLf
        query &= "" & vbCrLf
        query &= "DELETE FROM [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE] WHERE COMPA�IA = @COMPA�IA AND MES = @MES AND A�O = @A�O" & vbCrLf
        query &= "" & vbCrLf
        query &= "INSERT INTO [dbo].[CONTABILIDAD_CATALOGO_CUENTAS_SALDOS_DETALLE]" & vbCrLf
        query &= "SELECT @COMPA�IA AS COMPA�IA, A.LIBRO_CONTABLE," & vbCrLf
        query &= "	   @A�O AS A�O," & vbCrLf
        query &= "	   @MES AS MES," & vbCrLf
        query &= "	   A.CUENTA_CONTABLE," & vbCrLf
        query &= "	   C.CUENTA_COMPLETA, " & vbCrLf
        query &= "       A.COD_DETALLE, " & vbCrLf
        query &= "       CASE WHEN C.TIPO_CUENTA = 1 OR C.TIPO_CUENTA = 4 THEN A.CARGOS - A.ABONOS ELSE A.ABONOS - A.CARGOS END AS SALDO, " & vbCrLf
        query &= "	   '" & Usuario & "' AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	   @FECHAAPERTURA AS USUARIO_CREACION_FECHA," & vbCrLf
        query &= "	   '" & Usuario & "' AS USUARIO_EDICION_FECHA," & vbCrLf
        query &= "	   @FECHAAPERTURA AS USUARIO_EDICION_FECHA" & vbCrLf
        query &= "  FROM (SELECT COMPA�IA, CUENTA_CONTABLE, COD_DETALLE, SUM(CARGOS) AS CARGOS, SUM(ABONOS) AS ABONOS, @LIBRO_CONTABLE AS LIBRO_CONTABLE" & vbCrLf
        query &= "          FROM CONTABILIDAD_PARTIDAS_DETALLE_EXTENDIDO" & vbCrLf
        query &= "	     WHERE FECHA_TRAN < @FECHAAPERTURA" & vbCrLf
        query &= "	     GROUP BY COMPA�IA, CUENTA_CONTABLE, COD_DETALLE) A, CONTABILIDAD_CATALOGO_CUENTAS C" & vbCrLf
        query &= "         WHERE A.COMPA�IA = C.COMPA�IA And A.LIBRO_CONTABLE = C.LIBRO_CONTABLE And A.CUENTA_CONTABLE = C.CUENTA" & vbCrLf
        query &= "		 AND C.COMPA�IA = @COMPA�IA AND C.LIBRO_CONTABLE = @LIBRO_CONTABLE"
        Return query
    End Function
End Class