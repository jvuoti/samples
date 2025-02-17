﻿Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Private DataSet1 As DataSet
    Private dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    'Handler for RowUpdating event.
    Private Shared Sub OnRowUpdating(sender As Object, e As SqlRowUpdatingEventArgs)
        PrintEventArgs(e)
    End Sub 
    
    'Handler for RowUpdated event.
    Private Shared Sub OnRowUpdated(sender As Object, e As SqlRowUpdatedEventArgs)
        PrintEventArgs(e)
    End Sub 
    
    'Entry point which delegates to C-style main Private Function.
    Public Overloads Shared Sub Main()
        System.Environment.ExitCode = Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Function Main(args() As String) As Integer
        Const CONNECTION_STRING As String = "Persist Security Info=False;Integrated Security=SSPI;database=northwind;server=mySQLServer"
        Const SELECT_ALL As String = "select * from Products"
        
        'Create DataAdapter.
        Dim rAdapter As New SqlDataAdapter(SELECT_ALL, CONNECTION_STRING)
        
        'Create and fill DataSet (Select only first 5 rows.).
        Dim rDataSet As New DataSet()
        rAdapter.Fill(rDataSet, 0, 5, "Table")
        
        'Modify DataSet.
        Dim rTable As DataTable = rDataSet.Tables("Table")
        rTable.Rows(0)(1) = "new product"
        
        'Add handlers.
        AddHandler rAdapter.RowUpdating, AddressOf OnRowUpdating
        AddHandler rAdapter.RowUpdated, AddressOf OnRowUpdated
        
        'Update--this operation fires two events (RowUpdating and RowUpdated) for each changed row. 
        rAdapter.Update(rDataSet, "Table")
        
        'Remove handlers.
        RemoveHandler rAdapter.RowUpdating, AddressOf OnRowUpdating
        RemoveHandler rAdapter.RowUpdated, AddressOf OnRowUpdated
        Return 0
    End Function 
    
    Overloads Private Shared Sub PrintEventArgs(args As SqlRowUpdatingEventArgs)
        Console.WriteLine("OnRowUpdating")
        Console.WriteLine("  event args: (" & _
                        " command=" & _
                        args.Command.CommandText & _
                        " commandType=" & _
                        args.StatementType & _
                        " status=" & _
                        args.Status & _
                        ")")
    End Sub 
    
    
    Overloads Private Shared Sub PrintEventArgs(args As SqlRowUpdatedEventArgs)
        Console.WriteLine("OnRowUpdated")
        Console.WriteLine("  event args: (" & _
                        " command=" & _
                        args.Command.CommandText & _
                        " commandType=" & _
                        args.StatementType & _
                        " recordsAffected=" & _
                        args.RecordsAffected & _
                        " status=" & _
                        args.Status & _
                        ")")
    End Sub 
    ' </Snippet1>
End Class 'Form1

