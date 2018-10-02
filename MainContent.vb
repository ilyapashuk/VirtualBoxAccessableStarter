Module MainContent
    Public VmsList As List(Of String)
    Sub Main()
        VmsList = New List(Of String)
        Dim MachinesArray As VirtualBox.IMachine()
        Dim VBox As New VirtualBox.VirtualBox
        MachinesArray = VBox.Machines
        For Each Machine As VirtualBox.IMachine In MachinesArray
            VmsList.Add(Machine.Name)
        Next
        Form1.ShowDialog()
    End Sub

    Public Function StringToLinesArray(ByVal SourceData As String) As String()
        Dim PreservedSourceData As String
        PreservedSourceData = SourceData.Replace(vbCr, "")
        Dim ResultArray As String()
        ResultArray = PreservedSourceData.Split(vbLf)
        Return ResultArray
    End Function
End Module
