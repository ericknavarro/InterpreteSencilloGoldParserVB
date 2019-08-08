Imports InterpreteSencillo

Public Class Simbolo

    ' La Clase simbolo representa un nodo de la tabla de simbolos,
    ' Se debe de crear un simbolo por cada varibale que se registra
    ' Permite almacenar su id, tipo y valor.
    ' Se utilizo una enum para tener la posibilidad de agregar mas tipos en un futuro



    Private ReadOnly _tipo As Tipo_Var      'Almacena el tipo de la variable
    Private ReadOnly _id As String          'Almacena el ID de la variable
    Private _valor As Object                'Almacena el valor de la variable

    Public Sub New(id As String, tipo As Tipo_Var)
        Me._tipo = tipo
        Me._id = id
    End Sub

    Public Property Valor As Object
        Get
            Return _valor
        End Get
        Set(_valor As Object)
            Me._valor = _valor
        End Set
    End Property

    Public ReadOnly Property Tipo As Tipo_Var
        Get
            Return _tipo
        End Get
    End Property

    Public ReadOnly Property Id As String
        Get
            Return _id
        End Get
    End Property

    ' Son los distintos tipos que pueden tener las variables
    ' Por ejemplo int,double,String, etc... 
    Public Enum Tipo_Var
        Numero
    End Enum


End Class
