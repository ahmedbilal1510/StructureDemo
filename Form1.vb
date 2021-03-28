Public Class Form1
    Private myCustomer As New ArrayList

    Public ReadOnly Property SelectedCustomer As Customer
        Get
            Dim index As Integer = lstCustomers.SelectedIndex
            If index <> -1 Then
                Return lstCustomers.Items(index)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub NewCustomer(ByVal fn As String,
                            ByVal ln As String,
                            ByVal a As Integer,
                            ByVal e As String)
        Dim temp As Customer
        temp.firstName = fn
        temp.lastName = ln
        temp.age = a
        temp.email = e
        myCustomer.Add(temp)
        Me.lstCustomers.Items.Add(temp)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        NewCustomer("Ren", "Hoek", 12, "ren@apu.ac.jp")
        NewCustomer("Stimpson", "Cat", 4, "stimpy@apu.ac.jp")
        NewCustomer("Muddy", "Mudskipper", 1, "muddy@apu.ac.jp")

    End Sub

    Public Sub DisplayCustomer(ByVal temp As Customer)
        Me.txtName.Text = temp.Name
        Me.txtFirstName.Text = temp.firstName
        Me.txtLastName.Text = temp.lastName
        Me.txtAge.Text = temp.age
        Me.txtEmail.Text = temp.email

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not Me.SelectedCustomer.IsEmpty Then
            Dim result As DialogResult = MessageBox.Show("Please verify deletion of " & SelectedCustomer.Name & ".",
                                                         "Verify",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button1)

            If result = DialogResult.OK Then
                myCustomer.Remove(SelectedCustomer)
                lstCustomers.Items.Remove(SelectedCustomer)
            End If
        Else
            MessageBox.Show("Please Select A Customer. ")
        End If
    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCustomers.SelectedIndexChanged

        If SelectedCustomer.IsEmpty Then
            DisplayCustomer(New Customer)
        Else
            DisplayCustomer(SelectedCustomer())
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstCustomers.Items.Add(txtName.Text And " " And txtEmail.Text)


    End Sub
End Class

