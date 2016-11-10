Imports System.Data.SqlClient

Public Class Seguridad_Principal
    Private mMenu As New System.Windows.Forms.MainMenu()
    Dim Sql As String
    Dim Iniciando As Boolean
    Dim c_data1 As New jarsClass
    Dim bx, by As Integer
    Dim ITEM As String

    Private Sub Seguridad_Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciando = True
        Abierto_Cerrado = True
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(AppPath & "\PPG.ico")
        CargaMenus()
        Host = System.Net.Dns.GetHostName
        Dim IPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(Host)
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
        InstanciaUsuario = c_data1.obtenerEscalar("SELECT COUNT(USUARIO) + 1 FROM SEGURIDAD_USUARIOS_CONECTADOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Usuario & "' AND HOST = '" & Host & "' AND IPADDRESS='" & IP & "' AND  APP_VERSION = '" & My.Application.Info.Version.ToString & "'")
        c_data1.Ejecutar_ConsultaSQL("EXECUTE SP_USUARIOS_CONECTADOS_SIUD @COMPAÑIA=" & Compañia & ", @USUARIO='" & Usuario & "', @BANDERA='I', @HOST='" & Host & "', @IPADDRESS='" & IP & "', @APPPATH = '" & AppPath & "', @VERSION = '" & My.Application.Info.Version.ToString & "', @INSTANCIA = " & InstanciaUsuario)
        Iniciando = False
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarToolStripMenuItem.Click
        CargaMenus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim CerrarApp As Boolean
        Try
            Dim Actualizacion As Integer = c_data1.leerDataeader("SELECT VALOR FROM CONTABILIDAD_CATALOGO_CONSTANTE WHERE COMPAÑIA = " & Compañia & " AND CONSTANTE= 7", 0)
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

            If Actualizacion = 1 Then 'Verifica si hay actualizaciones urgentes que realizar
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

            CerrarApp = c_data1.leerDataeader("SELECT DESCONECTAR FROM SEGURIDAD_USUARIOS_CONECTADOS WHERE COMPAÑIA = " & Compañia & " AND USUARIO = '" & Usuario & "' AND HOST = '" & Host & "' AND IPADDRESS='" & IP & "' AND APP_VERSION = '" & My.Application.Info.Version.ToString & "'", 0)
        Catch ex As Exception
            CerrarApp = False
        End Try
        If CerrarApp Then
            Me.Close()
        End If
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

    Private Sub CargaMenus()
        Try
            Sql = "SELECT * FROM VISTA_SEGURIDAD_ACCESOS WHERE USUARIO = '" & Usuario & "' AND COD_COMPAÑIA = '" & Compañia & "' AND APP = 1 " & vbCrLf
            Sql &= "ORDER BY COD_COMPAÑIA, COD_MODULO, COD_SUB_MODULO, COD_OPCION"
            Dim table As DataTable = c_data1.obtenerDatos(New SqlCommand(Sql))
            Me.Menu = mMenu
            If table.Rows.Count > 0 Then
                Dim linea As Integer = 0
                Dim ImagenMenu As Integer = 0
                Dim strMod As String = String.Empty
                Dim strMod1 As String = String.Empty
                Dim strSubMod As String = String.Empty
                Dim mMenuItem As MenuItem
                Dim mMenuSubItem As IconMenuItem
                Dim mMenuOpcion As IconMenuItem
                strMod = table.Rows(linea).Item("Módulo")
                strMod1 = table.Rows(linea).Item("Módulo")
                While linea <= table.Rows.Count - 1
                    mMenuItem = mMenu.MenuItems.Add(table.Rows(linea).Item("Sub Módulo"))
                    strSubMod = table.Rows(linea).Item("Sub Módulo")
                    While mMenuItem.Text = strSubMod And linea <= table.Rows.Count - 1
                        ImagenMenu = CInt(table.Rows(linea).Item("ICONO"))
                        If ImagenMenu = 0 Then
                            mMenuSubItem = New IconMenuItem(mMenuItem, table.Rows(linea).Item("Opción").ToString, AddressOf mnuAcciones)
                        Else
                            mMenuSubItem = New IconMenuItem(mMenuItem, table.Rows(linea).Item("Opción").ToString, ilImagenes.Images(ImagenMenu), AddressOf mnuAcciones)
                        End If
                        menuItemStyle(mMenuSubItem, table.Rows(linea).Item("Formulario"), table.Rows(linea).Item("Ayuda"))
                        linea += 1
                        If linea <= table.Rows.Count - 1 Then
                            strSubMod = table.Rows(linea).Item("Sub Módulo")
                        Else
                            strSubMod = String.Empty
                        End If
                    End While
                    If linea <= table.Rows.Count - 1 Then
                        strMod = table.Rows(linea).Item("Módulo")
                    Else
                        strMod = String.Empty
                    End If
                    If table.Rows.Count - 1 > linea Then
                        If strMod1 <> strMod Then
                            mMenuItem = mMenu.MenuItems.Add(table.Rows(linea).Item("Módulo"))
                            strMod = table.Rows(linea).Item("Módulo")
                            While mMenuItem.Text = strMod And linea <= table.Rows.Count - 1
                                ImagenMenu = CInt(table.Rows(linea).Item("ICONO"))
                                If ImagenMenu = 0 Then
                                    mMenuSubItem = New IconMenuItem(mMenuItem, table.Rows(linea).Item("Sub Módulo").ToString, AddressOf mnuAcciones)
                                Else
                                    mMenuSubItem = New IconMenuItem(mMenuItem, table.Rows(linea).Item("Sub Módulo").ToString, ilImagenes.Images(ImagenMenu), AddressOf mnuAcciones)
                                End If
                                menuItemStyle(mMenuSubItem, "", "")
                                strSubMod = table.Rows(linea).Item("Sub Módulo")
                                While mMenuSubItem.Text = strSubMod And linea <= table.Rows.Count - 1
                                    ImagenMenu = CInt(table.Rows(linea).Item("ICONO"))
                                    If ImagenMenu = 0 Then
                                        mMenuOpcion = New IconMenuItem(mMenuSubItem, table.Rows(linea).Item("Opción").ToString, AddressOf mnuAcciones)
                                    Else
                                        mMenuOpcion = New IconMenuItem(mMenuSubItem, table.Rows(linea).Item("Opción").ToString, ilImagenes.Images(ImagenMenu), AddressOf mnuAcciones)
                                    End If
                                    menuItemStyle(mMenuOpcion, table.Rows(linea).Item("Formulario"), table.Rows(linea).Item("Ayuda"))
                                    linea += 1
                                    If linea <= table.Rows.Count - 1 Then
                                        strSubMod = table.Rows(linea).Item("Sub Módulo")
                                    Else
                                        strSubMod = String.Empty
                                    End If
                                End While
                                If linea <= table.Rows.Count - 1 Then
                                    strMod = table.Rows(linea).Item("Módulo")
                                Else
                                    strMod = String.Empty
                                End If
                            End While
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub mnuAcciones(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, MenuItem).Tag(0) <> "" Then
            Try
                Dim Objeto As Form = Activator.CreateInstance(Type.GetType(My.Application.Info.AssemblyName & "." & CType(sender, MenuItem).Tag(0)))
                Objeto.MdiParent = Me ' Para fijar las pantallas al recuadro principal, si se pone como comentario se libera.
                Objeto.AutoSize = True
                Objeto.Show()
                Abierto_Cerrado = False
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub menuItemStyle(ByRef myItemMenu As IconMenuItem, ByVal Opcion As String, ByVal TextAyuda As String)
        Dim Textos As String() = {"", ""}
        Textos(0) = Opcion
        Textos(1) = TextAyuda
        With myItemMenu
            .ColorItemSeleccionado = Color.Blue
            .ColorTextoSeleccionado = Color.Navy
            .ColorGradiente1 = Color.Aqua
            .ColorGradiente2 = Color.Snow
            .TipoLetra = New Font("Arial", 10, FontStyle.Regular)
            .ColorTexto = Color.Navy
            .Tag = Textos
            .Add()
        End With
    End Sub
End Class