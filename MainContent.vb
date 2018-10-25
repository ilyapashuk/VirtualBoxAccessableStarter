Module MainContent
    Sub Main()
        Try
            BoxClient = New VirtualBox.VirtualBoxClient

        Catch ex As Exception
            MsgBox(LocalizeString("can not to connect to VirtualBox. make sure that it is installed correctly. ErrorMessage:") & ex.Message, vbCritical, LocalizeString("error"))
            End
        End Try
        Form1.ShowDialog()
    End Sub

End Module
