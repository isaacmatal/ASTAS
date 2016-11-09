Imports System.Data.SqlClient
Imports BioEnable.SDK.BioEnBSP
Imports NITGEN.SDK.NBioBSP

Public Class Registro
    Dim m_NBioAPI As New BioAPI
    Dim m_IndexSearch As New BioAPI.IndexSearch(m_NBioAPI)

    Private Sub Registro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As UInteger = m_IndexSearch.InitEngine()
        If ret <> NBioAPI.Error.NONE Then
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        cargaIndex()
    End Sub

    Private Sub cargaIndex()
        Dim fpInfo As NBioAPI.IndexSearch.FP_INFO()
        Dim ret As UInteger
        Dim myconnection As SqlConnection
        Dim cmd As SqlCommand = New SqlCommand("Select USERID, FPData from FingerPrintData")
        myconnection = New SqlConnection()
        myconnection.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & BaseDatos & ";uid=" & UsuarioDB & ";password=" & PasswordDB & ";" 'Set database path to connection string
        myconnection.Open()
        cmd.Connection = myconnection
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Dim nUserID As UInteger = 0
        Dim Fpdata As String = ""
        Dim textFIR As NBioAPI.Type.FIR_TEXTENCODE
        While reader.Read()
            nUserID = reader.GetInt32(0)
            Fpdata = reader.GetString(1)
            textFIR = New NBioAPI.Type.FIR_TEXTENCODE()
            textFIR.TextFIR = Fpdata
            ret = m_IndexSearch.AddFIR(textFIR, nUserID, fpInfo)
            If ret <> NBioAPI.Error.NONE Then
                MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End While

        myconnection.Close()

    End Sub

    Public Function myCallback(ByRef cbParam0 As NBioAPI.IndexSearch.CALLBACK_PARAM_0, ByVal userParam As IntPtr) As UInteger
        progressIdentify.Value = Convert.ToInt32(cbParam0.ProgressPos)
        Return NBioAPI.IndexSearch.CALLBACK_RETURN.OK
    End Function

    Private Sub DisplayErrorMsg(ByVal ret As UInteger)
        MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnIdentify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim hCapturedFIR As NBioAPI.Type.HFIR
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        ' Get FIR data
        m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)
        Dim ret As UInteger = m_NBioAPI.Capture(hCapturedFIR)
        If ret <> NBioAPI.Error.NONE Then
            DisplayErrorMsg(ret)
            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)
            Return

        End If

        m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

        Dim nMax As UInteger
        m_IndexSearch.GetDataCount(nMax)
        progressIdentify.Minimum = 0
        progressIdentify.Maximum = Convert.ToInt32(nMax)
        Dim cbInfo0 As NBioAPI.IndexSearch.CALLBACK_INFO_0 = New NBioAPI.IndexSearch.CALLBACK_INFO_0()
        cbInfo0.CallBackFunction = New NBioAPI.IndexSearch.INDEXSEARCH_CALLBACK(AddressOf myCallback)

        ' Identify FIR to IndexSearch DB
        Dim fpInfo As NBioAPI.IndexSearch.FP_INFO
        ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, fpInfo, cbInfo0)
        If ret <> NBioAPI.Error.NONE Then
            DisplayErrorMsg(ret)
            Return
        End If
        Me.TextBox1.Text = fpInfo.ID.ToString()
        Dim myconnection As New SqlConnection("Data Source=" & Servidor & ";Initial Catalog=" & BaseDatos & ";uid=" & UsuarioDB & ";password=" & PasswordDB & ";") 'Set database path to connection string)
        Dim cmd As New SqlCommand("SELECT NOMBRE_COMPLETO FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & fpInfo.ID.ToString())
        Try
            myconnection.Open()
            cmd.Connection = myconnection
            Me.TextBox2.Text = cmd.ExecuteScalar().ToString()
            cmd.CommandText = "SELECT DUI FROM COOPERATIVA_CATALOGO_SOCIOS WHERE CODIGO_EMPLEADO = " & fpInfo.ID.ToString()
            Me.TextBox3.Text = cmd.ExecuteScalar().ToString()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
