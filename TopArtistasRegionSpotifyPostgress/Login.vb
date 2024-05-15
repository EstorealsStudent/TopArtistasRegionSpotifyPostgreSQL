Imports System.Data.SqlClient
Imports TopArtistasRegionSpotify.Caché
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub ExecuteStoredProcedure()
        ' Ejecutar un procedimiento almacenado
        Dim procedureName As String = "SP_VerificarCredenciales"
        Dim parameters As SqlParameter() = {
        New SqlParameter("@Usuario", TextBoxUsername.Text),
        New SqlParameter("@Contraseña", TextBoxPassword.Text)
    }

        Try
            ' Obtener un lector de datos para el resultado del procedimiento almacenado
            Dim reader As SqlDataReader = Connection.ExecuteStoredProcedureReader(procedureName, parameters)

            ' Verificar si hay filas devueltas por el procedimiento almacenado
            If reader.HasRows Then
                ' Si hay filas, leer la primera fila (suponiendo que solo hay una fila)
                If reader.Read() Then
                    ' Obtener los datos de las columnas y asignarlos a las variables de la clase Caché
                    Caché.IdUsuariopublico = reader("Id")
                    Caché.Nombrepublico = reader("Nombre")
                    Caché.Usernamepublico = reader("Username")

                End If
            Else
                ' Si no hay filas, las credenciales son inválidas
                ' Puedes mostrar un mensaje de error o simplemente limpiar los campos
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.")
                TextBoxUsername.Text = ""
                TextBoxPassword.Text = ""
                ' O puedes mantener al usuario en la misma página sin hacer nada
                ' Dependiendo de tu flujo de aplicación
            End If

            reader.Close()
        Catch ex As Exception
            ' Manejar cualquier excepción aquí
            MessageBox.Show("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        End Try
        Form1.Show()
        Me.Visible = False

    End Sub





    Private Sub ButtonEntrar_Click(sender As Object, e As EventArgs) Handles ButtonEntrar.Click
        If TextBoxUsername.Text.Trim() <> "" AndAlso TextBoxPassword.Text.Trim() <> "" Then
            ExecuteStoredProcedure()

        Else
            MessageBox.Show("Por favor, complete ambos campos antes de continuar.")
        End If
    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub
End Class