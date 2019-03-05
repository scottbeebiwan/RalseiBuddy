Sub SEnd
    WScript.Quit
End Sub
Function Eval(E)
    WScript.StdOut.WriteLine(CStr(E))
End Function
Do While True
    WScript.StdOut.WriteLine("##W4C")
    On Error Resume Next
    Execute WScript.StdIn.ReadLine()
    If Err.Number <> 0 Then
        WScript.StdOut.WriteLine("TE:"&Err.Description)
    End If
    On Error Goto 0
Loop