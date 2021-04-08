Imports System.IO.Ports

Public Class FormMain
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Получение списка доступных COM портов
        Try
            For Each sp As String In My.Computer.Ports.SerialPortNames
                ComboBoxCOMPorts.Items.Add(sp)
            Next
            'Выбрать первый по-умолчанию
            If ComboBoxCOMPorts.Items.Count > 0 Then ComboBoxCOMPorts.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка")
        End Try
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        'Если не подключен
        If Not SerialPort.IsOpen Then
            Try
                'Установка параметров и подключение
                SerialPort.PortName = ComboBoxCOMPorts.SelectedItem
                SerialPort.Open()

                'Изменение интерфейса после подключения
                ComboBoxCOMPorts.Enabled = False
                ButtonConnect.Text = "Отключиться"
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                TextBox6.Enabled = True
                TextBox7.Enabled = True
                TextBox8.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ошибка подключения")
                'MessageBox.Show(ex.Message, "Ошибка")
            End Try
        Else
            'Отключение
            SerialPort.Close()

            'Изменение интерфейса после отключения
            ComboBoxCOMPorts.Enabled = True
            ButtonConnect.Text = "Подключиться"
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
        End If

    End Sub

    'Чтение данных из COM-порта
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        'Вывод полученных данных
        Invoke(Sub() TextBox1.Text = SerialPort.ReadExisting())
    End Sub
End Class
