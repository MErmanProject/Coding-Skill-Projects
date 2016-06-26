Public Class Form1
  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 100
             console.WriteLine(FizzBuzz(i))
        Next i
    End Sub  

    Private Function FizzBuzz(num) As String
        Dim output As String
        If num Mod 3=0 AndAlso num Mod 5=0 Then
             output="FizzBuzz"
        ElseIf num Mod 3=0 then
            output="Fizz"
        ElseIf num Mod 5=0 then
            output="Buzz"
        Else
            output = num
        End If
       
        Return output
    End Function
End Class
