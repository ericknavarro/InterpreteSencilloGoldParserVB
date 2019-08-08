Imports System.IO

Module Module1

    Sub Main()
        ' Se cargan las tablas las tablas de analisis
        MyParser.Setup()

        ' Carga el archivo de entrada y lo almacena en la variable fileReader
        ' Si se desea implementar este ejemplo con una interfaz grafica, la cadena de entrada se debe pasar
        ' como parametro al metodo parse.

        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "entrada.txt"))

        If MyParser.Parse(New StringReader(fileReader)) Then
            ' Si la cadena de entrada es aceptada, se ejecutan las acciones del arbol construido
            MyParser.obtenerArbol().ejecutar()
            Console.WriteLine()
            Console.WriteLine("Ejecutado Exitosamente")
        Else
            ' Si se produce algun error lexico o sintactico, no se podra crear un arbol
            Console.WriteLine("No se pudo ejecutar")
            Console.WriteLine()
        End If

        Console.ReadLine()
    End Sub

End Module
