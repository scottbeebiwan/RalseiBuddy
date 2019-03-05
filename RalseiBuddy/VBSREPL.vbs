Sub SEnd
    WScript.Quit
End Sub
Function Eval(E)
    WScript.StdOut.WriteLine(CStr(E))
End Function
Do While True
    WScript.StdOut.WriteLine("K")
    On Error Resume Next
    Execute WScript.StdIn.ReadLine()
    If Err.Number <> 0 Then
        WScript.StdOut.WriteLine(Err.Description)
    End If
    On Error Goto 0
Loop