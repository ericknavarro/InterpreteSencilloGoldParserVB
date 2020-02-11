Imports InterpreteSencillo

Public Class Operacion
    Implements Instruccion

    Private ReadOnly tipo As Tipo_operacion         'Almacena eltipo de operacion a realizar,es una enumeración declarada mas abajo
    Private operadorIzq As Operacion                'Operador Izquierdo de la operación
    Private operadorDer As Operacion                'Operador Derecho de la operación
    Private valor As Object                         'En caso de no ser una oepración, se almacena el valor 


    'Se declaran los distintos constructores dependiendo de el tipo de operación que se desee realizar
    'Existe un constructor para operaciones aritmeticas
    'Otro constructor para un identificador 
    'Otro para valores puntuales y se puede crear uno para cada necesidad que tengamos

    ' Este constructor se utiliza para crear una operación de tipo aritmetica o relacional que involucre 
    ' dos operadores tales como suma, mayor que, menor que, etc.
    Public Sub New(operadorIzq As Operacion, operadorDer As Operacion, tipo As Tipo_operacion)
        Me.tipo = tipo
        Me.operadorIzq = operadorIzq
        Me.operadorDer = operadorDer
    End Sub

    ' Este constructor se utiliza para operaciones unarias, tales como not y -
    Public Sub New(operadorIzq As Operacion, tipo As Tipo_operacion)
        Me.tipo = tipo
        Me.operadorIzq = operadorIzq
    End Sub


    ' Este constructor se utiliza para el acceso a las variables
    Public Sub New(a As String, tipo As Tipo_operacion)
        Me.valor = a
        Me.tipo = tipo
    End Sub

    ' Constructor que se utiliza para los números
    Public Sub New(a As Double)
        Me.valor = a
        Me.tipo = Tipo_operacion.NUMERO

    End Sub


    ' Este metodo se encarga de realizar la operacion aritmetica o relacional correspondiente
    ' Seria util agregar validaciones extra si se pretende escalar este ejemplo
    ' Tales como verificar que ninguno de los operadores sea nulo, en el caso
    ' de una operacion binaria
    ' Este metodo se hereda de la interfaz instruccion

    Public Function ejecutar(ts As TablaSimbolos) As Object Implements Instruccion.ejecutar

        If tipo = Tipo_operacion.DIVISION Then
            Dim op_izq = operadorIzq.ejecutar(ts)
            Dim op_der = operadorDer.ejecutar(ts)

            If Double.Parse(op_der) = 0 Then
                Console.WriteLine("No se puede dividir entre 0. Division no aceptada: {0:G}/{1:G}", op_izq, op_der)
                Return Nothing
            Else
                Return Double.Parse(op_izq) / Double.Parse(op_der)
            End If
        ElseIf tipo = Tipo_operacion.MULTIPLICACION Then
            Return Double.Parse(operadorIzq.ejecutar(ts)) * Double.Parse(operadorDer.ejecutar(ts))
        ElseIf (tipo = Tipo_operacion.RESTA) Then
            Return Double.Parse(operadorIzq.ejecutar(ts)) - Double.Parse(operadorDer.ejecutar(ts))
        ElseIf (tipo = Tipo_operacion.SUMA) Then
            Return Double.Parse(operadorIzq.ejecutar(ts)) + Double.Parse(operadorDer.ejecutar(ts))
        ElseIf (tipo = Tipo_operacion.NEGATIVO) Then
            Return Double.Parse(operadorIzq.ejecutar(ts)) * -1
        ElseIf (tipo = Tipo_operacion.NUMERO) Then
            Return Double.Parse(valor.ToString)
        ElseIf (tipo = Tipo_operacion.IDENTIFICADOR) Then
            Return ts.GetValor(valor.ToString())
        ElseIf (tipo = Tipo_operacion.CADENA) Then
            Return valor.ToString().Replace("""", "")
        ElseIf (tipo = Tipo_operacion.MAYOR_QUE) Then
            Return (Double.Parse(operadorIzq.ejecutar(ts))) > (Double.Parse(operadorDer.ejecutar(ts)))
        ElseIf (tipo = Tipo_operacion.MENOR_QUE) Then
            Return (Double.Parse(operadorIzq.ejecutar(ts))) < (Double.Parse(operadorDer.ejecutar(ts)))
        ElseIf (tipo = Tipo_operacion.CONCATENACION) Then
            Return operadorIzq.ejecutar(ts).ToString() + operadorDer.ejecutar(ts).ToString()
        Else
            Return Nothing
        End If
    End Function


    ' Esta enumeración almacena todos los tipos posibles de operaciones.
    ' Si se desea escalar este ejemplo seria util crear una interfaz expresion
    ' Y separar cada uno de los tipos de operacion en una clase aparte en la que todas hereden de expresion
    Public Enum Tipo_operacion
        SUMA
        RESTA
        MULTIPLICACION
        DIVISION
        NEGATIVO
        NUMERO
        IDENTIFICADOR
        CADENA
        MAYOR_QUE
        MENOR_QUE
        CONCATENACION
    End Enum




End Class
