Module CodeLocalizer
    Public Function LocalizeString(ByVal SourceString As String) As String
        Select Case System.Threading.Thread.CurrentThread.CurrentCulture.Name
            Case "ru-RU"
                Select Case SourceString
                    Case "error"
                        Return "ошибка"
                    Case "can not to connect to VirtualBox. make sure that it is installed correctly. ErrorMessage:"
                        Return "Не удалось подключиться к VirtualBox. Убедитесь, Что он корректно установлен на этом компьютере. Подробности: "
                    Case "current state"
                        Return "текущее состояние"
                    Case "snapshots of"
                        Return "снимки"
                    Case "enter the snapshot name"
                        Return "введите имя снимка"
                    Case Else
                        Return SourceString
                End Select
            Case Else
                Return SourceString
        End Select
    End Function
End Module
