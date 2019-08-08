Imports InterpreteSencillo

Public Class Mientras
    Implements Instruccion
    ' Condición que debera ser evaluada para la ejecución de las instrucciones
    Private ReadOnly condicion As Operacion
    ' Lista de instrucciones que se deberan de ejecutar si la condición se cumple
    Private ReadOnly instrucciones As LinkedList(Of Instruccion)


    'Unicamente posee un constructor ya que el while siempre tiene la misma forma
    'Una condición y una lista de sentencias

    Public Sub New(condicion As Operacion, instrucciones As LinkedList(Of Instruccion))
        Me.condicion = condicion
        Me.instrucciones = instrucciones
    End Sub

    ' Este metodo evalua la condición y en caso fuera verdadero ejecuta la lista de instrucciones
    ' en caso no se cumple, no ejecuta nada
    ' Este metodo se hereda de la interfaz instrucción.

    Public Function ejecutar(ts As TablaSimbolos) As Object Implements Instruccion.ejecutar
        While Convert.ToBoolean(condicion.ejecutar(ts))
            Dim tablaLocal As New TablaSimbolos()
            tablaLocal.addAll(ts)

            For Each ins As Instruccion In instrucciones
                ins.ejecutar(tablaLocal)
            Next
        End While
        Return Nothing
    End Function
End Class
