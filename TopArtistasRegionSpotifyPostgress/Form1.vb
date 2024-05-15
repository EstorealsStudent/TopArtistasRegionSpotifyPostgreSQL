Imports System.Data.SqlClient
Imports System.Windows

Public Class Form1
    Dim query As String
    Dim auto As Boolean
    'Create a constructor
    Public Sub New()
        auto = True

        ' This call is required by the designer.
        InitializeComponent()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        ' Add any initialization after the InitializeComponent() call.
        'Create a new instance of the Connection class
        Connection.Disconnect()
        query = "select id, nombre from PAIS"
        ComboBoxPaises.DataSource = Connection.SelectQuery(query)
        ComboBoxPaises.DisplayMember = "nombre"
        ComboBoxPaises.ValueMember = "id"
        auto = False
        DataGridView1.ReadOnly = True

        query = "select [Top Artist],Nombre,Pais from VW_Top_Artistas where Estatus=1"
        DataGridView1.DataSource = Connection.SelectQuery(query)
    End Sub



    Private Sub ComboBoxPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaises.SelectedIndexChanged
        If ComboBoxPaises.Text Is Nothing Then
            Exit Sub
        End If
        query = "select [Top Artist],Nombre,Pais from VW_Top_Artistas
where Pais='" & ComboBoxPaises.Text & "' and Estatus=1"
        DataGridView1.DataSource = Connection.SelectQuery(query)
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Dim buscarTexto As String = TextBoxBuscar.Text.Trim()
        Dim query As String = ""
        query = "select [Top Artist],Nombre,Pais from VW_Top_Artistas
where Nombre LIKE '%" & buscarTexto & "%' and Estatus=1"
        ' Ejecutar la consulta SQL y mostrar los resultados en el DataGridView
        Dim dt As DataTable = Connection.SelectQuery(query)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ' Verificar si se hizo clic en una celda válida y no en los encabezados de columna
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Obtener el valor de la primera celda de la fila en la que se hizo clic
            Dim valorCelda As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()

            Dim form2 As New ShowArtist(valorCelda)
            form2.Show()

        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Visible = True

    End Sub
End Class
