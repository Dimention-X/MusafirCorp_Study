Module Module1
    Public Class Reactangle
        Private len As Double
        Private bre As Double

        'Public Methods'
        Public Sub AcceptDetails()
            len = 4.56
            bre = 5.08

        End Sub

        Public Function GetArea() As Double
            GetArea = len * bre
        End Function

        Public Sub Display()
            Console.WriteLine("Length:Breadth:Area {0},{1},{2}", len, bre, GetArea())


        End Sub


    End Class

    Sub Main()
        Dim r As New Reactangle()
        r.AcceptDetails()
        r.Display()
    End Sub

End Module
