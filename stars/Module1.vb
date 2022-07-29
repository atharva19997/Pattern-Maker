Module Module1

    Dim indent As String
    Sub Main()
InvalidInp:
        Console.SetWindowPosition(0, 0)
        Console.WindowHeight = Console.LargestWindowHeight
        Console.WindowWidth = Console.LargestWindowWidth
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight)
        Console.ForegroundColor = 2
        'Console.SetWindowPosition(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2)
        Console.WriteLine(vbCrLf & "##### PATTERN MAKER #####" & vbCrLf)
        Console.WriteLine("1. Triangle")
        Console.WriteLine("2. Right Triangle")
        Console.WriteLine("3. Inverse Triangle")
        Console.WriteLine("4. Inverse Right Triangle")
        Console.WriteLine("5. Diamond")
        Console.WriteLine("6. Half Diamond")
        Console.WriteLine("10. Exit Program")
        Console.Write(vbCrLf & "Input which shape you want: ")
        Dim sel As String = Console.ReadLine()
        Dim options = {1, 2, 3, 4, 5, 6, 10}
        'If sel <> "1" And sel <> "2" And sel <> "3" And sel <> "4" And sel <> "5" And sel <> "6" And sel <> "10" Then
        If Not options.Contains(sel) Then
            Console.WriteLine(vbCrLf & "Invalid Input")
            'Main()
            'Exit Sub
            GoTo InvalidInp
        End If
        If sel = "10" Then
            Exit Sub
        End If
SymbolKissa:
        Console.Write(vbCrLf & "Please enter Symbol for Pattern: ")
        Dim inp_char As String = Console.ReadLine()
        If check_char(inp_char) = False Then
            Console.WriteLine(vbCrLf & "Please enter only 1 symbol")
            GoTo SymbolKissa
        Else
            indent = " " + CStr(inp_char)
        End If
InputKissa:
        Console.Write(vbCrLf & "Please input integer from 1 to 40: ")
        Dim inp As String = Console.ReadLine()
        If check_int(inp) = False Then
            Console.WriteLine(vbCrLf & "Please enter valid input")
            GoTo InputKissa
        ElseIf inp <= 0 Then
            Console.WriteLine(vbCrLf & "Please add positive values")
            GoTo InputKissa
        ElseIf inp <= 40 Then
            switch(sel, inp)
            'Console.WriteLine("Press enter to end....")
            'Console.ReadLine()
        Else
            Console.WriteLine(vbCrLf & "Please enter number between 1 - 40 only")
            GoTo InputKissa
        End If
        Console.WriteLine("")
    End Sub

    Sub rt_tri(n As Integer)
        For i As Integer = 1 To n
            'Console.WriteLine(New String("*", i))
            Console.WriteLine(String.Concat(Enumerable.Repeat(indent, i)))
        Next
    End Sub

    Sub tri(n As Integer)
        For i As Integer = 1 To n : Console.WriteLine(Space(n - i) + String.Concat(Enumerable.Repeat(indent, i)))
        Next
    End Sub

    Sub tri2(n As Integer)
        For i As Integer = 1 To n
            Console.WriteLine(Space(n - i + 1) + String.Concat(Enumerable.Repeat(indent, i)))
        Next
    End Sub

    Sub inv_rt_tri(n As Integer)
        For i As Integer = n To 1 Step -1
            Console.WriteLine(String.Concat(Enumerable.Repeat(indent, i)))
        Next
    End Sub

    Sub inv_tri(n As Integer)
        For i As Integer = n To 1 Step -1
            Console.WriteLine(Space(n - i) + String.Concat(Enumerable.Repeat(indent, i)))
        Next
    End Sub

    Sub switch(num As String, count As Int16)
        Console.Clear()
        Console.ForegroundColor = 5
        Select Case num
            Case "1" : tri(count)
            Case "2" : rt_tri(count)
            Case "3" : inv_tri(count)
            Case "4" : inv_rt_tri(count)
            Case "5"
                tri2(count - 1)
                inv_tri(count)
            Case "6"
                rt_tri(count - 1)
                inv_rt_tri(count)
                'Case "10"
                '    Exit Sub
                'Case Else
                '    Console.WriteLine("Invalid case")
        End Select
        Main()
        Exit Sub
    End Sub

    Function check_int(ByVal input As String) As Boolean
        Try
            Convert.ToInt32(input)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function check_char(ByVal input As String) As Boolean
        Try
            Convert.ToChar(input)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module

'Sub Pascal(n As Integer)
'    Dim arr As Integer(,) = New Integer(n, n) {}
'    For i As Integer = 0 To n
'        For k As Integer = n To i + 1 Step -1
'            'print spaces
'            Console.Write(" ")
'        Next

'        For j As Integer = 0 To i - 1
'            If j = 0 OrElse i = j Then
'                arr(i, j) = 1
'            Else
'                arr(i, j) = arr(i - 1, j) + arr(i - 1, j - 1)
'            End If
'            Console.Write(arr(i, j) & " ")
'        Next
'        Console.WriteLine()
'    Next
'End Sub

'Try
'    count = CInt(Console.ReadLine())
'Catch e As Exception
'    Console.WriteLine("Please input numbers only, {}", e)
'    Finally
'        Main()
'End Try
