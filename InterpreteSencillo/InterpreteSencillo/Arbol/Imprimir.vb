Imports InterpreteSencillo

Public Class Imprimir
    Implements Instruccion

    ' Variable que almacena el contenido que sera impreso
    Private ReadOnly contenido As Instruccion

    ' Posee solo un contructor ya que la sentencia imprimir
    ' unicamente puede tener un contenido

    Public Sub New(contenido As Instruccion)
        Me.contenido = contenido
    End Sub


    ' Obtiene el valor a imprimir y luego lo muestra en la consola
    ' Este metodo se hereda de la interfaz Operación
    Public Function ejecutar(ts As TablaSimbolos) As Object Implements Instruccion.ejecutar
        Console.WriteLine(contenido.ejecutar(ts))
        Return Nothing
    End Function
End Class
