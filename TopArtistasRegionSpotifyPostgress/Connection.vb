Imports Npgsql
Public Class Connection
    Shared cnx As New NpgsqlConnection

    Private Shared Sub Connect()
        Try
            cnx.ConnectionString = "Host=localhost;Database=topartistasregion;Username=Hector2;Password=admin"
            cnx.Open()
        Catch ex As Exception
            MsgBox("Error al conectar a la base de datos: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub Disconnect()
        Try
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        Catch ex As Exception
            MsgBox("Error al desconectar de la base de datos: " & ex.Message)
        End Try
    End Sub

    ' Método para ejecutar una consulta de selección
    Public Shared Function SelectQuery(ByVal query As String) As DataTable
        Dim dt As New DataTable
        Try
            Connect()
            Dim cmd As New NpgsqlCommand(query, cnx)
            Dim da As New NpgsqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            MsgBox("Error al ejecutar la consulta: " & ex.Message)
        Finally
            Disconnect()
        End Try
        Return dt
    End Function


    Public Shared Function ExecuteStoredProcedureReader(ByVal procedureName As String, ByVal parameters As NpgsqlParameter()) As NpgsqlDataReader
        Dim reader As NpgsqlDataReader = Nothing
        Try
            Connect()
            Dim cmd As New NpgsqlCommand(procedureName, cnx)
            cmd.CommandType = CommandType.StoredProcedure

            ' Agregar parámetros si los hay
            If parameters IsNot Nothing Then
                For Each param As NpgsqlParameter In parameters
                    cmd.Parameters.Add(param)
                Next
            End If

            reader = cmd.ExecuteReader()

            ' Verificar si hay filas antes de cerrar la conexión
            If Not reader.HasRows Then
                ' Si no hay filas, cerrar el lector y la conexión
                reader.Close()
                Disconnect()
            End If
        Catch ex As Exception
            MsgBox("Error al ejecutar el stored procedure: " & ex.Message)
            Throw
        End Try
        Return reader
    End Function

    Public Shared Function ExecuteStoredProcedure(ByVal storedProcedureName As String, ByVal parameters As NpgsqlParameter()) As DataTable
        Dim dt As New DataTable
        Try
            Connect()
            Dim cmd As New NpgsqlCommand()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = storedProcedureName

            If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                For Each param As NpgsqlParameter In parameters
                    cmd.Parameters.Add(param)
                Next
            End If

            Dim da As New NpgsqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            MsgBox("Error al ejecutar el stored procedure: " & ex.Message)
        Finally
            Disconnect()
        End Try
        Return dt
    End Function

End Class
