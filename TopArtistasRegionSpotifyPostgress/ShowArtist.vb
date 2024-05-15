Imports System.Data.SqlClient
Public Class ShowArtist
    Private idartista As String
    Dim query As String

    ' Constructor que acepta el valor como parámetro
    Public Sub New(ByVal valor As String)
        InitializeComponent()
        ' Guardar el valor recibido en la variable privada
        idartista = valor
        InicializarInformacion()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPais.SelectedIndexChanged
        If ComboBoxPais.Text Is Nothing Then
            Exit Sub
        End If
    End Sub


    Private Sub InicializarInformacion()
        query = "select id, nombre from PAIS"
        ComboBoxPais.DataSource = Connection.SelectQuery(query)
        ComboBoxPais.DisplayMember = "nombre"
        ComboBoxPais.ValueMember = "id"
        ComboBoxPais.Refresh()

        ' Ejecutar un procedimiento almacenado
        Dim procedureName As String = "SP_ObtenerArtistaPorId"
        Dim parameters As SqlParameter() = {
        New SqlParameter("@IdArtista", idartista)
    }


        ' Obtener un lector de datos para el resultado del procedimiento almacenado
        Dim reader As SqlDataReader = Connection.ExecuteStoredProcedureReader(procedureName, parameters)

        ' Verificar si hay filas devueltas por el procedimiento almacenado
        If reader.HasRows Then
            ' Si hay filas, leer la primera fila (suponiendo que solo hay una fila)
            If reader.Read() Then
                ' Obtener los datos de las columnas y asignarlos a las variables de la clase Caché
                TextBoxAristaNombre.Text = Convert.ToString(reader("NombreArtista"))
                ComboBoxPais.SelectedValue = Convert.ToInt32(reader("Idpais"))
            End If
        End If
        Connection.Disconect()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim procedureName As String = "SP_ActualizarArtista"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@Id", idartista),
                New SqlParameter("@Nombre", TextBoxAristaNombre.Text),
                New SqlParameter("@IdPais", ComboBoxPais.SelectedValue),
                New SqlParameter("@idUsuarioModifica", Caché.IdUsuariopublico)
            }

            ' Ejecutar el procedimiento almacenado
            Connection.ExecuteStoredProcedure(procedureName, parameters)
            MsgBox("Artista Actualizado")
        Catch ex As Exception
            ' Manejar el error
            MessageBox.Show("Se produjo un error al actualizar el artista: " & ex.Message)
            ' Puedes hacer un retorno aquí si lo deseas
            Return
        End Try

        query = "select [Top Artist],Nombre,Pais from VW_Top_Artistas where Estatus=1"
        Form1.DataGridView1.DataSource = Connection.SelectQuery(query)
    End Sub

    Private Sub ButtonELIMINAR_Click(sender As Object, e As EventArgs) Handles ButtonELIMINAR.Click
        Try
            Dim procedureName As String = "SP_EliminarArtista"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@Id", idartista),
                New SqlParameter("@IdUsuarioModifica", Caché.IdUsuariopublico)
            }

            ' Ejecutar el procedimiento almacenado
            Connection.ExecuteStoredProcedure(procedureName, parameters)
            MsgBox("Artista Eliminado")

        Catch ex As Exception
            ' Manejar el error
            MessageBox.Show("Se produjo un error al actualizar el artista: " & ex.Message)
            ' Puedes hacer un retorno aquí si lo deseas
            Return
        End Try
        query = "select [Top Artist],Nombre,Pais from VW_Top_Artistas where Estatus=1"
        Form1.DataGridView1.DataSource = Connection.SelectQuery(query)
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub
End Class