Imports InterpreteSencillo

Public Class If_Statement
    Implements Instruccion

    ' Condicion que determina si las sentencias se ejecutan o no
    Private ReadOnly condicion As Operacion
    ' Lista de instrucciones que se ejecutan si la condicion se cumple
    Private ReadOnly listaInstrucciones As LinkedList(Of Instruccion)
    ' Lista de instrucciones que se ejecutara si la condicion no se cumple, un else
    ' En caso de que esta no fuera una sentenia If.. Else, este atributo sera nulo
    Private ReadOnly listaInsElse As LinkedList(Of Instruccion)

    ' Este constructor se utiliza cuando es un If simple, la sentencia else se vuelve null
    Public Sub New(condicion As Operacion, instrucciones As LinkedList(Of Instruccion))
        Me.condicion = condicion
        Me.listaInstrucciones = instrucciones
        Me.listaInsElse = Nothing
    End Sub

    ' Esta instruccion se utiliza para un If...Else, recibe como parametro la condicion,
    ' las sentencias si se cumple la condicion, y las sentencias si no se cumple, en este caso, del else
    Public Sub New(condicion As Operacion, instruccionesIf As LinkedList(Of Instruccion), instruccionesElse As LinkedList(Of Instruccion))
        Me.condicion = condicion
        Me.listaInstrucciones = instruccionesIf
        Me.listaInsElse = instruccionesElse
    End Sub


    ' Metodo que ejecuta las sentencias de la instruccion If en caso de que la condicion se cumpliera
    ' Si la condicion no se cumple, y existe un else, ejecutara sus condiciones    
    ' Este metodo se hereda de la interfaz operacion.


    Public Function ejecutar(ts As TablaSimbolos) As Object Implements Instruccion.ejecutar
        If Convert.ToBoolean(condicion.ejecutar(ts)) Then
            Dim tablaLocal As New TablaSimbolos()
            tablaLocal.addAll(ts)
            For Each ins As Instruccion In listaInstrucciones
                ins.ejecutar(tablaLocal)
            Next
        ElseIf listaInsElse IsNot Nothing Then
            Dim tablaLocal As New TablaSimbolos()
            tablaLocal.addAll(ts)
            For Each ins As Instruccion In listaInsElse
                ins.ejecutar(tablaLocal)
            Next
        End If
        Return Nothing

    End Function




End Class
