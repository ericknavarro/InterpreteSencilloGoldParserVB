Imports InterpreteSencillo

Public Class Asignacion
    Implements Instruccion
    ' Identificador de la variable que queremos asignar
    Private ReadOnly id As String

    ' Valor que se le desea asignar a la variable
    Private ReadOnly valor As Operacion

    ' Constructor de la clase, unicamente tiene un constructor ya que la asignación siempre tiene la misma forma
    ' Un identificador y un valor
    Public Sub New(id As String, valor As Operacion)
        Me.id = id
        Me.valor = valor
    End Sub


    ' Método que se encarga de actualizar el valor de la variable
    ' En caso no existiera la variable, el error se reporta en el método SetValor
    ' Este método se hereda de la interfaz instrucción
    Public Function ejecutar(ts As TablaSimbolos) As Object Implements Instruccion.ejecutar
        ts.SetValor(id, valor.ejecutar(ts))
        Return Nothing
    End Function



End Class
