Public Interface Instruccion

    'Interfaz que implementan todas las clases que son instrucción y que contiene 
    'todas las acciones (métodos) que pueden realizar todas las instrucciones

    ' Si se desea escalar el ejemplo, es conveniente que se cree una interfaz llamada expresion 
    ' y todas las sentencias que retornen un valor heredarian de ella, en el caso de las sentencias if, while, etc
    ' seguirian heredando de instruccion


    ' Metodo que define el comportamiento de cada instruccion
    ' Se sobreescribe en cada una de las clases que implementa esta interfaz
    ' Recibe como parametro la tabla de simbolos correspondiente
    ' Su tipo de retorno es Object y de esta manera permite retornar cualquier tipo de valor
    Function ejecutar(ts As TablaSimbolos) As Object

End Interface
