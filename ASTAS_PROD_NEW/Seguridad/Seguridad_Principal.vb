Imports System.Data.SqlClient

Public Class Seguridad_Principal
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim c_data1 As New jarsClass
    Dim ITEM As String

    Private Sub Seguridad_Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Abierto_Cerrado = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(IconPath)
        CargaMenus()
        Host = System.Net.Dns.GetHostName
        Dim IPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(Host) 'System.Net.Dns.Resolve(Host) -Resolve function obselete according Microsoft
        If IPs.AddressList.Length > 0 Then
            For i As Integer = 0 To IPs.AddressList.Length - 1
                If IPs.AddressList(i).AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    IP = IPs.AddressList(i).ToString
                    Exit For
                End If
            Next
        End If
        If IP.Length = 0 Then
            IP = "No Definida"
        End If
        'If IPs.AddressList.Length = 1 Then
        '    IP = IPs.AddressList(0).ToString
        'ElseIf IPs.AddressList.Length > 1 Then
        '    IP = IPs.AddressList(1).ToString
        'End If
        InstanciaUsuario = c_data1.obtenerEscalar("SELECT COUNT(USUARIO) + 1 FROM SEGURIDAD_USUARIOS_CONECTADOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Usuario & "' AND HOST = '" & Host & "' AND IPADDRESS='" & IP & "' AND APP_VERSION = '" & My.Application.Info.Version.ToString & "'")
        c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_USUARIOS_CONECTADOS_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO='" & Usuario & "', @BANDERA='I', @HOST='" & Host & "', @IPADDRESS='" & IP & "', @APPPATH = '" & AppPath & "', @VERSION = '" & My.Application.Info.Version.ToString & "', @INSTANCIA = " & InstanciaUsuario)
        Me.tssbtnBarra.DropDownItems.Item(4).Text = "Instancia: " & InstanciaUsuario
        Iniciando = False
    End Sub

    Private Sub CargaMenus()
        Dim Conexion_ As SqlConnection
        Dim Comando_ As SqlCommand
        Dim DataAdapter_ As SqlDataAdapter
        Dim DataReader_ As SqlDataReader

        Dim Compañia_ As String
        Dim Modulo As String
        Dim SubModulo As String
        Dim Opcion As String

        Dim Compañias As Integer
        Dim Modulos As Integer
        Dim SubModulos As Integer
        Dim Opciones As Integer

        Compañia_ = ""
        Modulo = ""
        SubModulo = ""
        Opcion = ""

        Compañias = 0
        Modulos = 0
        SubModulos = 0
        Opciones = 0

        Conexion_ = New SqlConnection("User ID=" & UsuarioDB & "; Password=" & PasswordDB & "; Initial Catalog=" & BaseDatos & "; Data Source=" & Servidor & ";")
        Try
            Me.treeMenu.Nodes.Clear()
            Conexion_.Open()
            Sql = "SELECT * FROM VISTA_SEGURIDAD_ACCESOS WHERE USUARIO = '" & Usuario & "' AND COD_COMPAÑIA = '" & Compañia & "' "
            Sql &= "AND APP = 0 "
            Sql &= "ORDER BY COD_COMPAÑIA, COD_MODULO, COD_SUB_MODULO, COD_OPCION"
            Comando_ = New SqlCommand(Sql, Conexion_)
            DataReader_ = Comando_.ExecuteReader
            DataAdapter_ = New SqlDataAdapter(Comando_)
            While DataReader_.Read = True
                If Compañia_ <> DataReader_.Item("Compañía") Then
                    Compañia_ = DataReader_.Item("Compañía")
                    Compañias = Compañias + 1
                    Me.treeMenu.Nodes.Add(Compañia_)
                    Me.treeMenu.Nodes.Item(Compañias - 1).ImageIndex = 4
                    If Modulo <> DataReader_.Item("Módulo") Then
                        Modulo = DataReader_.Item("Módulo")
                        Modulos = Modulos + 1
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Add(Modulo)
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).ImageIndex = 1
                        If SubModulo <> DataReader_.Item("Sub Módulo") Then
                            SubModulo = DataReader_.Item("Sub Módulo")
                            SubModulos = SubModulos + 1
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Add(SubModulo)
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).ImageIndex = 2
                            If Opcion <> DataReader_.Item("Opción") Then
                                Opciones = Opciones + 1
                                Opcion = DataReader_.Item("Opción")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Add(Opcion)
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).Name = DataReader_.Item("Formulario")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ToolTipText = DataReader_.Item("Ayuda")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ImageIndex = 3
                            End If
                        End If

                    End If
                Else
                    If Modulo = DataReader_.Item("Módulo") Then
                        'SubModulo = 0
                        If SubModulo <> DataReader_.Item("Sub Módulo") Then
                            SubModulo = DataReader_.Item("Sub Módulo")
                            SubModulos = SubModulos + 1
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Add(SubModulo)
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).ImageIndex = 2
                            Opciones = 0
                            If Opcion <> DataReader_.Item("Opción") Then
                                Opciones = Opciones + 1
                                Opcion = DataReader_.Item("Opción")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Add(Opcion)
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).Name = DataReader_.Item("Formulario")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ToolTipText = DataReader_.Item("Ayuda")
                                Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ImageIndex = 3
                            End If
                        Else
                            Opciones = Opciones + 1
                            Opcion = DataReader_.Item("Opción")
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Add(Opcion)
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).Name = DataReader_.Item("Formulario")
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ToolTipText = DataReader_.Item("Ayuda")
                            Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ImageIndex = 3
                        End If
                    Else
                        Modulo = DataReader_.Item("Módulo")
                        Modulos = Modulos + 1
                        SubModulos = 0
                        Opciones = 0
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Add(Modulo)
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).ImageIndex = 1
                        SubModulo = DataReader_.Item("Sub Módulo")
                        SubModulos = SubModulos + 1
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Add(SubModulo)
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).ImageIndex = 2
                        Opciones = Opciones + 1
                        Opcion = DataReader_.Item("Opción")
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Add(Opcion)
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).Name = DataReader_.Item("Formulario")
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ToolTipText = DataReader_.Item("Ayuda")
                        Me.treeMenu.Nodes.Item(Compañias - 1).Nodes.Item(Modulos - 1).Nodes.Item(SubModulos - 1).Nodes.Item(Opciones - 1).ImageIndex = 3
                    End If
                End If
            End While

            Conexion_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub treeMenu_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeMenu.AfterSelect
        If Iniciando = False Then
            If e.Node.Name <> "" Then
                Try
                    Dim Objeto As Form = Activator.CreateInstance(Type.GetType("ASTAS." & e.Node.Name))
                    'Dim Objeto As CrystalDecisions.CrystalReports.Engine.ReportClass = Activator.CreateInstance(Type.GetType("ASTAS_Pantallas." & "Nombre de la Clase del Reporte"))
                    ' -------------------------------*****-------------------------------
                    Objeto.MdiParent = Me ' Para fijar las pantallas al recuadro principal, si se pone como comentario se libera.
                    Objeto.AutoSize = True
                    Me.Label1.Visible = False

                    'For i As Integer = 370 To 10 Step -20
                    '    treeMenu.SetBounds(0, 0, i, 0)
                    treeMenu.SetBounds(0, 0, 0, 0)
                    'Next
                    Objeto.Show()

                    Abierto_Cerrado = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarToolStripMenuItem.Click
        CargaMenus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim i As Integer
        If Abierto_Cerrado = False Then
            'For i = 0 To 380 Step 20
            '    treeMenu.SetBounds(0, 0, i, 0)  ' Para abrir la barra del menú principal
            treeMenu.SetBounds(0, 0, 370, 0)  ' Para abrir la barra del menú principal
            'Next
            Me.Label1.Visible = True
            Abierto_Cerrado = True
        Else
            Me.Label1.Visible = False
            'For i = 370 To 10 Step -20
            '    treeMenu.SetBounds(0, 0, i, 0)  ' Para cerrar la barra del menú principal
            treeMenu.SetBounds(0, 0, 0, 0)  ' Para cerrar la barra del menú principal
            'Next
            Abierto_Cerrado = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim Actualizacion As Integer = c_data1.obtenerEscalar("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE= 7", False)
            Dim MSJ As String = String.Empty 'c_data1.leerDataeader("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ", @ESTADO=1, @BANDERA='S'", 3)
            Dim asunto As String = String.Empty 'c_data1.leerDataeader("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ", @ESTADO=1, @BANDERA='S'", 6)
            Dim u_enviado As String = String.Empty 'c_data1.leerDataeader("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ", @ESTADO=1, @BANDERA='S'", 1)
            ITEM = String.Empty 'c_data1.leerDataeader("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ", @ESTADO=1, @BANDERA='S'", 7)
            Dim tblMensaje As DataTable = c_data1.obtenerDatos(New SqlCommand("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ", @ESTADO=1, @BANDERA='S'"))
            If tblMensaje.Rows.Count > 0 Then
                MSJ = tblMensaje.Rows(0).Item("MENSAJE").ToString()
                asunto = tblMensaje.Rows(0).Item("ASUNTO").ToString()
                u_enviado = tblMensaje.Rows(0).Item("USUARIO_ENVIO").ToString()
                ITEM = tblMensaje.Rows(0).Item("ITEM").ToString()
            End If

            If Actualizacion = 1 Then
                PictureMantenimiento.Visible = True
            Else
                PictureMantenimiento.Visible = False
            End If

            If MSJ <> "" Then
                Label4.Text = u_enviado
                TextBox2.Text = asunto
                TextBox1.Text = MSJ

                Panel2.Visible = True
            Else
                Label4.Text = ""
                TextBox2.Text = ""
                TextBox1.Text = ""
                Panel2.Visible = False
            End If
            Dim CerrarApp As Boolean = c_data1.obtenerEscalar("SELECT DESCONECTAR FROM SEGURIDAD_USUARIOS_CONECTADOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Usuario & "' AND HOST = '" & Host & "' AND IPADDRESS='" & IP & "' AND APP_VERSION = '" & My.Application.Info.Version.ToString & "'", False)
            If CerrarApp Then
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Seguridad_Principal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_USUARIOS_CONECTADOS_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO=" & Usuario & ", @BANDERA='D', @HOST='" & Host & "', @IPADDRESS='" & IP & "',  @INSTANCIA = " & InstanciaUsuario & ", @VERSION = '" & My.Application.Info.Version.ToString & "'")
    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_MENSAJES_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO_RECEPCION=" & Usuario & ",@USUARIO_ENVIO=" & Label4.Text & ", @ESTADO=1, @BANDERA='D', @ITEM=" & ITEM)
        Label4.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        Panel2.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SOPORTE As New Seguridad_Incidencias
        SOPORTE.MdiParent = Me
        SOPORTE.Show()
    End Sub
End Class