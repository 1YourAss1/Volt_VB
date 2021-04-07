Public Class FormMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Получение списка доступных COM портов
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBoxCOMPorts.Items.Add(sp)
        Next
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click

    End Sub
End Class
