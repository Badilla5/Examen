Imports System.Web.Razor.Tokenizer

Public Class Formulario
    Inherits System.Web.UI.Page
    Protected dbHelper As New DatabaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If Content1.Value.IsNullOrWhiteSpace Then
            ' Validar que los campos no estén vacíos
            If String.IsNullOrWhiteSpace(TxtNombreEmpresa.Text) OrElse
               String.IsNullOrWhiteSpace(TxtContacto.Text) OrElse
               String.IsNullOrWhiteSpace(TxtTelefono.Text) Then
                LblMensaje.Text = "Todos los campos son obligatorios."
                LblMensaje.ForeColor = System.Drawing.Color.Red
                Return
            End If


            Dim empresa As New Persona()
            empresa.NombreEmpresa = TxtNombreEmpresa.Text
            empresa.Contacto = TxtContacto.Text
            empresa.Telefono = TxtTelefono.Text
            Dim dbHelper As New DatabaseHelper()
            Dim resultado As String = dbHelper.CreateEmpleado(empresa)
            If resultado.Contains("exitosamente") Then

                LblMensaje.Text = "Proveedor creado exitosamente."
                LblMensaje.ForeColor = System.Drawing.Color.Green
            Else


                LblMensaje.Text = "Error al crear el proveedor: " & resultado
                LblMensaje.ForeColor = System.Drawing.Color.Red
            End If
            ' Limpiar los campos después de guardar
            TxtNombreEmpresa.Text = String.Empty
            TxtContacto.Text = String.Empty
            TxtTelefono.Text = String.Empty
        Else





        End If

    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        ' Limpiar los campos al cancelar
        TxtNombreEmpresa.Text = String.Empty
        TxtContacto.Text = String.Empty
        TxtTelefono.Text = String.Empty


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index As Integer = GridView1.SelectedIndex
        If index >= 0 AndAlso index < GridView1.Rows.Count Then
            Dim row As GridViewRow = GridView1.Rows(index)
            TxtNombreEmpresa.Text = row.Cells(2).Text
            TxtContacto.Text = row.Cells(3).Text
            TxtTelefono.Text = row.Cells(4).Text
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs)
        Dim id As Integer = Convert.ToInt32(GridView1.DataKeys(e.AffectedRows).Value)
        Dim resultado As String = dbHelper.EliminarEmpleado(id)
        ' Mostrar el mensaje de resultado en la etiqueta LblMensaje
        LblMensaje.Text = resultado

        GridView1.DataBind()
    End Sub
End Class