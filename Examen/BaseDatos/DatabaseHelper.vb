Imports System.Data.SqlClient
Public Class DatabaseHelper
     Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Public Function CreateEmpresa(Empresa As Persona) As String
        Try
            Dim fechaDate As Date = Date.Now

            Dim query As String = "INSERT INTO Proveedores (NombreEmpresa, Contacto, Telefono) VALUES
                            (@NombreEmpresa, @Contacto, @Telefono)"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@NombreEmpresa", Empresa.NombreEmpresa),
                New SqlParameter("@Contacto", Empresa.Contacto),
                New SqlParameter("@Telefono", Empresa.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Proveedor creada exitosamente."
        Catch ex As FormatException
            Return "Formato de fecha inválido. Por favor, use el formato 'dd/MM/yyyy'."
        Catch ex As Exception
            Return "Error al crear el empleado: " & ex.Message
        End Try
    End Function

    Public Function EliminarEmpleado(id As Integer) As String
        Try
            Dim query As String = "DELETE FROM Proveedores WHERE ProveedorId = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Return "No se encontró la empresa con el ID especificado."
                    End If
                End Using
            End Using
            Return "Proveedor eliminada exitosamente."
        Catch ex As Exception
            Return "Error al eliminar el empleado: " & ex.Message
        End Try
    End Function

    Friend Function UpdateEmpresa(id As String, Empresa As Persona) As String
        Try
            Dim query As String = "UPDATE Proveedores SET NombreEmpresa = @NombreEmpresa,
                Contacto = @Contacto, Telefono = @Telefono, WHERE ProveedorId = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id),
                 New SqlParameter("@NombreEmpresa", Empresa.NombreEmpresa),
                New SqlParameter("@Contacto", Empresa.Contacto),
                New SqlParameter("@Telefono", Empresa.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Proveedor actualizado exitosamente."
        Catch ex As Exception
            Return "Error al actualizar el empleado: " & ex.Message
        End Try
    End Function
End Class
