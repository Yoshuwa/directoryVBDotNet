Imports System.Data.SqlClient

Public Class directoryData

    Public Shared Function GetConnection() As SqlConnection
        Dim connectionString As String _
            = "Data Source=DESKTOP-KEKO94D;Initial Catalog=directory;Integrated Security=SSPI;"
        Return New SqlConnection(connectionString)
    End Function

End Class

 
