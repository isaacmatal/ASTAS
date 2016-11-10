Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class IconMenuItem : Inherits MenuItem

#Region "InitializeComponent"
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private components As System.ComponentModel.IContainer


    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IconMenuItem))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "icono0.bmp")

    End Sub
#End Region

    Private _ColorTexto As Color = SystemColors.MenuText
    Private _ColorTextoSeleccionado As Color = SystemColors.HighlightText
    Private _ColorGradiente1 As Color = SystemColors.Highlight
    Private _ColorGradiente2 As Color = SystemColors.Highlight
    Private _TipoGradiente As LinearGradientMode = LinearGradientMode.Horizontal
    Private _TipoLetra As Font = Form.DefaultFont
    Private _Imagen As Image
    Private _Icono As Icon
    Private _Texto As String
    Private _Delegado As EventHandler
    Private _TipoIcono As IconType
    Private _TopItem As MenuItem
    Private _UsrFont As Font = Form.DefaultFont

#Region "Constructores"

    Public Sub New()
        MyBase.New()
        MyBase.OwnerDraw = True

        InitializeComponent()
    End Sub

    Public Sub New(ByVal TopItem As MenuItem, ByVal Texto As String, ByVal Imagen As Image, ByVal Delegado As EventHandler)
        MyBase.New(Texto, Delegado)
        MyBase.OwnerDraw = True
        InitializeComponent()
        _Texto = Texto : _Delegado = Delegado
        _TopItem = TopItem : _Imagen = Imagen
        _TipoIcono = IconType.Imagen
    End Sub

    Public Sub New(ByVal TopItem As MenuItem, ByVal Texto As String, ByVal Icono As Icon, ByVal Delegado As EventHandler)
        MyBase.New(Texto, Delegado)
        MyBase.OwnerDraw = True
        InitializeComponent()
        _Texto = Texto : _Delegado = Delegado
        _TopItem = TopItem : _Icono = Icono
        _TipoIcono = IconType.Icono
    End Sub

    Public Sub New(ByVal TopItem As MenuItem, ByVal Texto As String, ByVal Delegado As EventHandler)
        MyBase.New(Texto, Delegado)
        MyBase.OwnerDraw = True
        InitializeComponent()
        _Texto = Texto : _Delegado = Delegado : _TopItem = TopItem
        _Imagen = Me.ImageList1.Images(0)
    End Sub

    Public Sub New(ByVal TopItem As MenuItem, ByVal Texto As String)
        MyBase.New(Texto)
        MyBase.OwnerDraw = True
        InitializeComponent()
        _Texto = Texto : _TopItem = TopItem
        _Imagen = Me.ImageList1.Images(0)
    End Sub

#End Region

#Region "Propiedades"

    Public Enum IconType
        Icono = 1
        Imagen
    End Enum

    Public Property TopItem() As MenuItem
        Get
            Return _TopItem
        End Get
        Set(ByVal Value As MenuItem)
            _TopItem = Value
        End Set
    End Property

    Public Property Texto() As String
        Get
            Return _Texto
        End Get
        Set(ByVal Value As String)
            _Texto = Value
        End Set
    End Property

    Public Property Delegado() As EventHandler
        Get
            Return _Delegado
        End Get
        Set(ByVal Value As EventHandler)
            _Delegado = Value
        End Set
    End Property

    Public Property TipoIcono() As IconType
        Get
            Return _TipoIcono
        End Get
        Set(ByVal Value As IconType)
            _TipoIcono = Value
        End Set
    End Property

    Public Property Imagen() As Image
        Get
            Return _Imagen
        End Get
        Set(ByVal Value As Image)
            _Imagen = Value
        End Set
    End Property

    Public Property Icono() As Icon
        Get
            Return _Icono
        End Get
        Set(ByVal Value As Icon)
            _Icono = Value
        End Set
    End Property

    Public Property ColorTexto() As Color
        Get
            Return _ColorTexto
        End Get
        Set(ByVal Value As Color)
            _ColorTexto = Value
        End Set
    End Property

    Public Property ColorTextoSeleccionado() As Color
        Get
            Return _ColorTextoSeleccionado
        End Get
        Set(ByVal Value As Color)
            _ColorTextoSeleccionado = Value
        End Set
    End Property

    Public Property TipoLetra() As Font
        Get
            Return _TipoLetra
        End Get
        Set(ByVal Value As Font)
            _TipoLetra = Value
            _UsrFont = _TipoLetra
        End Set
    End Property

    Public Property ColorGradiente1() As Color
        Get
            Return _ColorGradiente1
        End Get
        Set(ByVal Value As Color)
            _ColorGradiente1 = Value
        End Set
    End Property

    Public Property ColorGradiente2() As Color
        Get
            Return _ColorGradiente2
        End Get
        Set(ByVal Value As Color)
            _ColorGradiente2 = Value
        End Set
    End Property

    Public Property TipoGradiente() As LinearGradientMode
        Get
            Return _TipoGradiente
        End Get
        Set(ByVal Value As LinearGradientMode)
            _TipoGradiente = Value
        End Set
    End Property

    Public Property ColorItemSeleccionado() As Color
        Get
            Return _ColorGradiente1
        End Get
        Set(ByVal Value As Color)
            _ColorGradiente1 = Value
            _ColorGradiente2 = Value
        End Set
    End Property
#End Region

#Region "Métodos privados"
    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)

        MyBase.OnDrawItem(e)

        Dim pincel, boli As Brush
        Dim rec As Rectangle = e.Bounds

        Dim myForm As Form = Me.Parent.GetMainMenu.GetForm
        Dim ssBarra As StatusStrip = myForm.Controls.Item(2)
        If Convert.ToBoolean(e.State And DrawItemState.Selected) = True Then
            pincel = New LinearGradientBrush(rec, _
            _ColorGradiente1, _ColorGradiente2, _TipoGradiente)
            boli = New SolidBrush(_ColorTextoSeleccionado)
            _TipoLetra = New Font(_UsrFont.FontFamily, _UsrFont.Size, FontStyle.Bold)
            ssBarra.Items(2).Text = Me.Tag(1)
        Else
            pincel = SystemBrushes.Menu
            boli = New SolidBrush(_ColorTexto)
            _TipoLetra = _UsrFont
            ssBarra.Items(2).Text = ""
        End If

        'If Convert.ToBoolean(e.State And DrawItemState.Selected) = True Then
        '    pincel = New LinearGradientBrush(rec, _
        '    Color.White, Color.Aqua, LinearGradientMode.Vertical)
        '    boli = New SolidBrush(Color.Blue)
        'Else
        '    pincel = SystemBrushes.Menu
        '    boli = New SolidBrush(SystemColors.MenuText)
        'End If

        e.Graphics.FillRectangle(pincel, rec)

        Dim PF As PointF = New PointF(e.Bounds.Left + 2, e.Bounds.Top + 2)

        If Me.Checked = True Then
            e.Graphics.DrawImage(Me.ImageList1.Images(1), PF)
        Else
            Select Case _TipoIcono
                Case IconType.Icono
                    e.Graphics.DrawIcon(_Icono, PF.X, PF.Y)

                Case IconType.Imagen
                    e.Graphics.DrawImage(_Imagen, PF)
                    'e.Graphics.DrawIcon(Icono16, PF.X, PF.Y)

                Case Else
                    e.Graphics.DrawImage(Me.ImageList1.Images(0), PF)
            End Select
        End If

        Dim Verbo As String = _Texto

        GetItemText(Verbo)
        e.Graphics.DrawString(Verbo, _TipoLetra, _
        boli, e.Bounds.Left + 25, e.Bounds.Top + 3)

    End Sub
    Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)

        MyBase.OnMeasureItem(e)

        Dim Verbo As String = _Texto
        GetItemText(Verbo)
        e.ItemHeight = 22
        e.ItemWidth = _
        CInt(e.Graphics.MeasureString(Verbo, _TipoLetra, _
        New SizeF(e.ItemWidth, e.ItemHeight)).Width) + 35

    End Sub

    Private Sub GetItemText(ByRef Verbo As String)

        If MyBase.ShowShortcut And MyBase.Shortcut <> Windows.Forms.Shortcut.None Then
            Verbo &= " (" & _
            TypeDescriptor.GetConverter(GetType(Keys)).ConvertToString(CType(MyBase.Shortcut, Keys)) _
            & ")"
        End If
    End Sub
#End Region

#Region "Métodos públicos"

    Public Overloads Function Add() As IconMenuItem
        _TopItem.MenuItems.Add(Me)
        Return Me
    End Function

    Public Overloads Function Add(ByVal Indice As Integer) As IconMenuItem
        _TopItem.MenuItems.Add(Indice, Me)
        Return Me
    End Function

#End Region
End Class

