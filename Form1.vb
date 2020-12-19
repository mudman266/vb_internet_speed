Public Class frmMain
    Private Sub btnEnterSpeed_Click(sender As Object, e As EventArgs) Handles btnEnterSpeed.Click
        ' Clear any entries that may exist
        lstSpeeds.Items.Clear()
        lblAvgSpeed.Text = "Average Internet Speed: "

        Dim strEnteredSpeed As String
        Dim intNumberEntries As Integer

        ' Try to loop 10 times and get an entry from the user
        For intNumberEntries = 1 To 10
            strEnteredSpeed = InputBox("Enter internet speed in Mbps.", "Internet Speed")

            ' If the input contains something, validate it and add to the collection
            If strEnteredSpeed <> "" Then

                ' Handle non numeric entry
                While Not IsNumeric(strEnteredSpeed)
                    MsgBox("Your input was non numeric. Try again.")
                    strEnteredSpeed = InputBox("Enter internet speed in Mbps.", "Internet Speed")
                End While

                ' Handle negative value entry
                While strEnteredSpeed < 0
                    MsgBox("Your input was a negative value. Try again.")
                    strEnteredSpeed = InputBox("Enter internet speed in Mbps.", "Internet Speed")
                    ' Handle non numeric entry
                    While Not IsNumeric(strEnteredSpeed)
                        MsgBox("Your input was non numeric. Try again.")
                        strEnteredSpeed = InputBox("Enter internet speed in Mbps.", "Internet Speed")
                    End While
                End While

                ' Valid entry, add to collection
                lstSpeeds.Items.Add(strEnteredSpeed)
            Else

                ' Blank entry or cancel pressed
                ' If no entries exist, warn user and exit sub
                If lstSpeeds.Items.Count < 1 Then
                    MsgBox("You did not enter any values.")
                    Exit Sub
                End If

                ' Entries exist, exit for loop.
                Exit For
            End If
        Next

        ' Got all entries, find the average
        Dim i As Integer
        Dim decSum As Decimal
        Dim decAvg As Decimal
        For i = 0 To (lstSpeeds.Items.Count - 1)
            decSum += lstSpeeds.Items(i)
        Next
        decAvg = decSum / lstSpeeds.Items.Count()

        ' Update the label
        lblAvgSpeed.Text = "Average Internet Speed: " & decAvg.ToString("F2") & " Mbps"
    End Sub
End Class
