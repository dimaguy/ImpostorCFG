Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.ReadOnly = True
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.ReadOnly = False
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TextBox2.Text) Then

            If RadioButton1.Checked Then
                Dim objWriter As New IO.StreamWriter("config.json")
                Dim httpClient As New Net.Http.HttpClient
                Dim ip As String = Await httpClient.GetStringAsync("https://api.ipify.org").ConfigureAwait(False)
                objWriter.Write("{
       ""Server"": { 
       ""ListenIp"": " + TextBox2.Text + ", 
       ""ListenPort"": 22023, 
       ""PublicIp"": " + ip + ", 
       ""PublicPort"": 22023 
   } 
} 
")
                objWriter.Close()
                MessageBox.Show("Done!")
            End If
            If RadioButton2.Checked Then
                Dim objWriter As New IO.StreamWriter("config.json")
                objWriter.Write("{
       ""Server"": { 
       ""ListenIp"": " + TextBox2.Text + ", 
       ""ListenPort"": 22023, 
       ""PublicIp"": " + TextBox1.Text + ", 
       ""PublicPort"": 22023 
   } 
} 
")
                objWriter.Close()
                MessageBox.Show("Done!")
            End If
        Else MessageBox.Show("You must fill all the fields")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class
