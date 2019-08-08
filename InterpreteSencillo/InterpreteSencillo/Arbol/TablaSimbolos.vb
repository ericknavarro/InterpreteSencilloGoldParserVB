Imports InterpreteSencillo.Simbolo

Public Class TablaSimbolos
    ' Esta clase funciona como una lista de simbolos
    ' Para no programar la funcionalidad de una lista enlazada, esta clase hereda de LinkedList
    ' Si se desea escalar este ejemplo se puede crear un apuntador al entorno padre,
    ' de esta manera se podrian crear distintos entornos por alcance y validar las variables re-declaradas
    Inherits LinkedList(Of Simbolo)

    Public Sub New()
        MyBase.New()            'Llama al constructor de la LinkedList
    End Sub

    ' Este método nos permite buscar el valor de una variable utilizando su id
    ' En caso no lo encontrara se mostrara un mensaje de error y se retornara un valor Desconocido.

    Public Function GetValor(id As String) As Object
        For Each simbolo As Simbolo In Me
            If simbolo.Id.Equals(id) Then
                Return simbolo.Valor
            End If
        Next
        Console.WriteLine("La variable con el ID: " + id + " no existe.")
        Return "Desconocido"
    End Function


    ' Este metodo nos permite asignar un valor a una variable en especifico
    ' En caso se quisiera escalar este ejemplo, en este metodo habria que realizar una validacion de tipos
    ' Que permita verificar que el valor sea del tipo de la variable
    Public Sub SetValor(id As String, valor As Object)
        For Each simbolo As Simbolo In Me
            If simbolo.Id.Equals(id) Then
                simbolo.Valor = valor
                Return
            End If
        Next
        Console.WriteLine("La variable con el ID: " + id + " no existe, no se le puede asignar un valor")
    End Sub


    ' Se creo el metodo addAll para agregar todos los simbolos del entorno anterior,
    ' de esta manera se simula una tabla de simbolos por alcance, en donde se encuentra
    ' primero la variable que fue declarada en el entorno mas proximo

    Public Sub addAll(lista As LinkedList(Of Simbolo))
        For Each sim As Simbolo In lista
            Me.AddLast(sim)
        Next
    End Sub

End Class
