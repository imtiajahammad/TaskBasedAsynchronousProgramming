// See https://aka.ms/new-console-template for more information

/*

        * In C#.NET, task is basically used to implement Asynchronous Programming. In simple words, executing operations 
            asynchronously.
        * The task-related classes belong to System.Threading.Tasks namespace.
        * The Task class will always represent a single operation and that operation will be executed asynchronously on 
            a thread pool thread rather than synchronously on the main thread of the application.
        * As you can see in the above output, two threads are used to execute the application code. The main thread and the child thread. And you can observe both threads are running asynchronously.
        * It will give you the same output as the previous example. The only difference between the previous example and this example is here we creating and running the thread using a single statement.
        * A Task in C# is used to implement Task-based Asynchronous programming. The Task object is typically executed asynchronously on a thread pool rather than synchronously on the main thread of the application.
        * A Task scheduler is responsible for starting the Task and also responsible for managing it. By default, the Task scheduler uses threads from the thread pool to execute the Task.
        * A thread pool in C# is a collection of threads that can be used to perform a number of tasks in the background. Once 
            a thread completes its task, then again it is sent to the thread pool, so that it can be reused. The reusability of 
            threads avoids an application to create a number of threads which ultimately uses less memory consumption.
        * Tasks in C# basically used to make your application more responsive. If the thread that manages the user interface 
            offloads the works to other threads from the thread pool, then it can keep processing user events which will ensure 
            that the application can still be used.

*/
Console.WriteLine("Task-based Asynchronous Programming in C#:");



Console.WriteLine("Using the Task class and Start method in C#:");
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
Task task1 = new Task(PrintCounter);
task1.Start();
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

Console.WriteLine("---------------------------------------------");

Console.WriteLine("Example: Creating a Task object using Factory Property:");

Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
Task task2 =  Task.Factory.StartNew(PrintCounter); 
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");

Console.WriteLine("---------------------------------------------");


Console.WriteLine("Example: Creating a Task object using the Run method");

Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
Task task3 = Task.Run(() => { PrintCounter(); });
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
Console.WriteLine("---------------------------------------------");

Console.WriteLine("Task using Wait in C#:");
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
Task task4 = Task.Run(() => 
    {
        PrintCounter();
    });
task4.Wait();
Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
Console.WriteLine("---------------------------------------------");





Console.ReadKey();


static void PrintCounter()
{
    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
    for (int count = 1; count <= 5; count++)
        {
        Console.WriteLine($"count value: {count}");
        }
    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
}
