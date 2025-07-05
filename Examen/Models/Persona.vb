Public Class Persona
    Private _nombreEmpresa As String
    Private _contacto As String
    Private _telefono As String

    Public Sub New()
    End Sub

    ' Constructor
    Public Sub New(nombreEmpresa As String, contacto As String, telefono As String)
        _nombreEmpresa = nombreEmpresa
        _contacto = contacto
        _telefono = telefono
    End Sub

    Public Property NombreEmpresa As String
        Get
            Return _nombreEmpresa
        End Get
        Set(value As String)
            _nombreEmpresa = value
        End Set
    End Property

    Public Property Contacto As String
        Get
            Return _contacto
        End Get
        Set(value As String)
            _contacto = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
End Class
