﻿' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesBitArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a BitArray.
        Dim myBA As New BitArray(5)
        
        ' Displays the properties and values of the BitArray.
        Console.WriteLine("myBA values:")
        PrintIndexAndValues(myBA)
        
        ' Sets all the elements to true.
        myBA.SetAll(True)
        
        ' Displays the properties and values of the BitArray.
        Console.WriteLine("After setting all elements to true,")
        PrintIndexAndValues(myBA)
        
        ' Sets the last index to false.
        myBA.Set(myBA.Count - 1, False)
        
        ' Displays the properties and values of the BitArray.
        Console.WriteLine("After setting the last element to false,")
        PrintIndexAndValues(myBA)
        
        ' Gets the value of the last two elements.
        Console.WriteLine("The last two elements are: ")
        Console.WriteLine("    at index {0} : {1}", _
           myBA.Count - 2, myBA.Get(myBA.Count - 2))
        Console.WriteLine("    at index {0} : {1}", _
           myBA.Count - 1, myBA.Get(myBA.Count - 1))
    End Sub 'Main

    Public Shared Sub PrintIndexAndValues(myCol As IEnumerable)
        Dim i As Integer
        Dim obj As Object
        i = 0
        For Each obj In  myCol
            Console.WriteLine("    [{0}]:    {1}", i, obj)
            i = i + 1
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class

' This code produces the following output.
' 
' myBA values:
'     [0]:    False
'     [1]:    False
'     [2]:    False
'     [3]:    False
'     [4]:    False
' 
' After setting all elements to true,
'     [0]:    True
'     [1]:    True
'     [2]:    True
'     [3]:    True
'     [4]:    True
' 
' After setting the last element to false,
'     [0]:    True
'     [1]:    True
'     [2]:    True
'     [3]:    True
'     [4]:    False
' 
' The last two elements are:
'     at index 3 : True
'     at index 4 : False

' </Snippet1>
