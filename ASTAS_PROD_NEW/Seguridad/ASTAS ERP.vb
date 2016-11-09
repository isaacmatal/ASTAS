Imports System.Runtime.Serialization.Formatters.Binary
Public NotInheritable Class ASTAS_ERP
    Friend WithEvents Label4 As System.Windows.Forms.Label
    'TODO: Este formulario se puede establecer fácilmente como pantalla de bienvenida para la aplicación desde la ficha "Aplicación"
    '  del Diseñador de proyectos ("Propiedades" bajo el menú "Proyecto").


    Private Sub ASTAS_ERP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        'Configure el texto del cuadro de diálogo en tiempo de ejecución según la información del ensamblado de la aplicación.  

        'TODO: Personalice la información del ensamblado de la aplicación en el panel "Aplicación" del cuadro de diálogo 
        '  propiedades del proyecto (bajo el menú "Proyecto").


        'Dé formato a la información de versión usando el texto establecido en el control de versión en tiempo de diseño como
        '  cadena de formato. Esto le permite una localización efectiva si lo desea.
        '  Se pudo incluir la información de generación y revisión usando el siguiente código y cambiando el 
        '  texto en tiempo de diseño del control de versión a "Versión {0}.{1:00}.{2}.{3}" o algo parecido. Consulte
        '  String.Format() en la Ayuda para obtener más información.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Información de Copyright
        Copyright.Text = "Astas 2013 Todos los derechos reservados"

        Dim AppVersion As String = My.Application.Info.Version.ToString
        Dim split As String() = AppVersion.Split(New [Char]() {"."c, ","c, CChar(vbTab)})
        Dim fechaVersion As Date = CDate("01/01/2000").AddDays(CInt(split(2)))
        Version.Text &= " " & AppVersion & vbCrLf & "Fecha Versión: " & fechaVersion.ToString("dd/MM/yyyy")

    End Sub

End Class
