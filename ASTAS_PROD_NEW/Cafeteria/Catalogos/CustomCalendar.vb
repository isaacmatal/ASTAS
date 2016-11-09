'Calendario Personalizado
'Desarrollado por que no me gusto los que hace Microsoft

Public Class CustomCalendar
    Dim eje_x As Integer = -6
    Dim eje_y As Integer = 72
    Dim dias_en_mes_ As Integer
    Dim first_day_ As Date
    Dim ahora_ As Date
    Dim inicio_ As Boolean

    Private Sub CustomCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicio_ = True
        cmbMonth.SelectedIndex = Now.Month - 1
        cmbYear.Text = Now.Year
        first_day_ = "01/" & Now.Month & "/" & Now.Year
        CreateCalendars(first_day_, Now.Month, Now.Year)
        inicio_ = False
    End Sub

    Private Sub CreateCalendars(ByVal fecha_ As Date, ByVal month_ As Integer, ByVal year_ As Integer)
        Dim num_day_week_ As Integer = fecha_.DayOfWeek

        Select Case num_day_week_
            Case 0
                'Es Domingo 
                eje_x = -6 '150
            Case 1
                'Es Lunes
                eje_x = 20
            Case 2
                'Es martes
                eje_x = 46
            Case 3
                'Es Miercoles
                eje_x = 72
            Case 4
                'Es Jueves
                eje_x = 98
            Case 5
                'Es Viernes !Yehaa
                eje_x = 124
            Case 6
                'Es Sabado 
                eje_x = 150
        End Select
        'Dias del mes
        dias_en_mes_ = Date.DaysInMonth(year_, month_)
        Dim enabled_ As Boolean
        Dim i As Integer
        For i = 1 To dias_en_mes_

            If year_ > Now.Year Then
                enabled_ = True
            Else
                If year_ = Now.Year Then
                    If month_ > Now.Month Then
                        enabled_ = True
                    Else
                        If month_ = Now.Month Then
                            If i >= Now.Day Then
                                enabled_ = True
                            Else
                                enabled_ = False
                            End If
                        Else
                            enabled_ = False
                        End If
                    End If
                Else
                    enabled_ = False
                End If
            End If

            Dim day As New System.Windows.Forms.Label
            AddHandler day.Click, AddressOf dia_Click
            CreateDaysArray(day, "Day" & i.ToString(), i.ToString(), enabled_)
        Next
    End Sub

    Private Sub CreateDaysArray(ByRef dia_ As System.Windows.Forms.Label, ByVal day_name_ As String, ByVal day_number_ As String, ByVal habilitar_ As Boolean)
        Me.Controls.RemoveByKey("")
        If eje_x < 176 Then
            eje_x = eje_x + 26
        Else
            eje_x = 20
            eje_y = eje_y + 20
        End If
        
        dia_.AutoSize = True
        dia_.BackColor = System.Drawing.Color.White
        dia_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        If habilitar_ Then
            dia_.ForeColor = System.Drawing.Color.Black
        Else
            dia_.ForeColor = System.Drawing.Color.LightGray
        End If
        dia_.Location = New System.Drawing.Point(eje_x, eje_y)
        dia_.Name = day_name_
        dia_.Size = New System.Drawing.Size(21, 13)
        dia_.TabIndex = 0
        dia_.Text = day_number_
        Me.Controls.Add(dia_)
    End Sub

    Public Sub ClearCalendars()
        Dim c As Integer
        For c = 1 To 31
            Me.Controls.RemoveByKey("Day" & c.ToString())
        Next
    End Sub

    Private Sub dia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim day_ As New System.Windows.Forms.Label
        day_ = CType(sender, Label)
        If Not day_.ForeColor = System.Drawing.Color.LightGray And Not day_.ForeColor = System.Drawing.Color.White And Not day_.BackColor = System.Drawing.Color.Green Then
            If day_.ForeColor.Equals(System.Drawing.Color.Red) Then
                day_.ForeColor = System.Drawing.Color.Black
                day_.BorderStyle = System.Windows.Forms.BorderStyle.None
            Else
                day_.ForeColor = System.Drawing.Color.Red
                day_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            End If
        End If
    End Sub

    Public Sub Crear()
        Dim mes_param_ As Integer

        eje_x = -6
        eje_y = 72

        Select Case cmbMonth.SelectedItem
            Case "Enero"
                mes_param_ = 1
            Case "Febrero"
                mes_param_ = 2
            Case "Marzo"
                mes_param_ = 3
            Case "Abril"
                mes_param_ = 4
            Case "Mayo"
                mes_param_ = 5
            Case "Junio"
                mes_param_ = 6
            Case "Julio"
                mes_param_ = 7
            Case "Agosto"
                mes_param_ = 8
            Case "Septiembre"
                mes_param_ = 9
            Case "Octubre"
                mes_param_ = 10
            Case "Noviembre"
                mes_param_ = 11
            Case "Diciembre"
                mes_param_ = 12
            Case Else
                mes_param_ = Now.Month
        End Select

        Dim first_day_ As Date = "01/" & mes_param_ & "/" & cmbYear.SelectedItem
        ClearCalendars()
        CreateCalendars(first_day_, mes_param_, cmbYear.SelectedItem)
    End Sub

    Public Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If Not inicio_ Then
            If cmbMonth.SelectedIndex > -1 Then
                Crear()
            End If
        End If
    End Sub

    Public Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If Not inicio_ Then
            If cmbYear.SelectedIndex > -1 Then
                Crear()
            End If
        End If
    End Sub

    Public Function GetSelectedDates() As String
        Dim rango_fechas_ As String = String.Empty
        Dim c As Integer = 1
        Dim tmp_control_ As Control
        Dim select_month_ As String = String.Empty

        Select Case cmbMonth.SelectedItem
            Case "Enero"
                select_month_ = "01"
            Case "Febrero"
                select_month_ = "02"
            Case "Marzo"
                select_month_ = "03"
            Case "Abril"
                select_month_ = "04"
            Case "Mayo"
                select_month_ = "05"
            Case "Junio"
                select_month_ = "06"
            Case "Julio"
                select_month_ = "07"
            Case "Agosto"
                select_month_ = "08"
            Case "Septiembre"
                select_month_ = "09"
            Case "Octubre"
                select_month_ = "10"
            Case "Noviembre"
                select_month_ = "11"
            Case "Diciembre"
                select_month_ = "12"
            Case Else
                select_month_ = Now.Month.ToString()
        End Select

        For Each tmp_control_ In Me.Controls
            If tmp_control_.ForeColor.Equals(System.Drawing.Color.Red) Then
                rango_fechas_ = rango_fechas_ & IIf(tmp_control_.Text.Length = 1, "0" & tmp_control_.Text, tmp_control_.Text) & "/" & select_month_ & "/" & cmbYear.Text & ","
            End If
            c = c + 1
        Next
        If rango_fechas_.Length > 0 Then
            rango_fechas_ = rango_fechas_.Remove(rango_fechas_.Length - 1)
        End If

        Return rango_fechas_
    End Function

    Public Function SetDate(ByVal dia_ As String, ByVal editable_ As Boolean) As Boolean
        Dim exito_ As Boolean = False
        Dim array_date_ As String() = dia_.Split("/")

        Dim mes_ As String = String.Empty

        Select Case cmbMonth.SelectedItem
            Case "Enero"
                mes_ = "01"
            Case "Febrero"
                mes_ = "02"
            Case "Marzo"
                mes_ = "03"
            Case "Abril"
                mes_ = "04"
            Case "Mayo"
                mes_ = "05"
            Case "Junio"
                mes_ = "06"
            Case "Julio"
                mes_ = "07"
            Case "Agosto"
                mes_ = "08"
            Case "Septiembre"
                mes_ = "09"
            Case "Octubre"
                mes_ = "10"
            Case "Noviembre"
                mes_ = "11"
            Case "Diciembre"
                mes_ = "12"
        End Select

        If array_date_(1) = mes_ And array_date_(2) = cmbYear.SelectedItem Then
            Dim tmp_control_ As Control
            For Each tmp_control_ In Me.Controls
                Dim num_dia_ As String = "Day" & IIf(array_date_(0).Substring(0, 1).Equals("0"), array_date_(0).Substring(1, 1), array_date_(0))

                If TypeOf tmp_control_ Is Label And tmp_control_.Name.Equals(num_dia_) Then
                    Dim etiqueta_ As New System.Windows.Forms.Label
                    etiqueta_ = CType(tmp_control_, Label)
                    etiqueta_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                    If editable_ Then
                        etiqueta_.ForeColor = System.Drawing.Color.Red
                    Else
                        etiqueta_.ForeColor = System.Drawing.Color.White
                        etiqueta_.BackColor = System.Drawing.Color.Green
                    End If

                    exito_ = True
                End If
            Next
        End If

        Return exito_
    End Function

    Public Function SetAllDateOfMonth(ByVal unselect_ As Boolean) As Boolean
        Dim exito_ As Boolean = False
        Dim tmp_control_ As Control
        Dim c As Integer = 1
        Dim que_dia_es_ As String

        For Each tmp_control_ In Me.Controls
            Dim num_dia_ As String = "Day" & c
            If TypeOf tmp_control_ Is Label And tmp_control_.Name.Equals(num_dia_) Then
                Dim etiqueta_ As New System.Windows.Forms.Label
                etiqueta_ = CType(tmp_control_, Label)
                If Not etiqueta_.ForeColor = System.Drawing.Color.LightGray And Not etiqueta_.ForeColor = System.Drawing.Color.White And Not etiqueta_.BackColor = System.Drawing.Color.Green Then
                    Dim dia_actual_ As New Date(CInt(cmbYear.SelectedItem.ToString()), cmbMonth.SelectedIndex + 1, c)
                    que_dia_es_ = dia_actual_.DayOfWeek.ToString()
                    If unselect_ Then
                        etiqueta_.BorderStyle = System.Windows.Forms.BorderStyle.None
                        etiqueta_.ForeColor = System.Drawing.Color.Black
                    Else
                        If Not que_dia_es_.Equals("Sunday") Then
                            etiqueta_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            etiqueta_.ForeColor = System.Drawing.Color.Red
                        End If
                    End If
                End If
                exito_ = True
                c = c + 1
            End If
        Next

        Return exito_
    End Function
End Class
