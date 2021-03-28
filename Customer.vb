Public Structure Customer
    Public firstName As String
    Public lastName As String
    Public age As Integer
    Public email As String

    Public ReadOnly Property Name As String
        Get
            Return Me.firstName & " " _
                & Me.lastName
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.Name & " (" & Me.email & ")"
    End Function

    Public ReadOnly Property IsEmpty As Boolean
        Get
            If (Me.firstName = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
End Structure
