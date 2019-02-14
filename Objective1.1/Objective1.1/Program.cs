using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

///Take from:
///https://www.youtube.com/watch?v=RhLLxew4-TY&t=0s&index=4&list=PLfiJgYpcZc9t1A_Hp2xsVxNc6Shxe3aVE
namespace Objective1._1
{
    class Program
    {
        #region partea 1 - join asteapta threadul de pe care a fost apelat sa se termine
        //public static void ThreadMethod()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("ThreadProc {0}", i);
        //        Thread.Sleep(0);
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(new ThreadStart(ThreadMethod));
        //    t.Start();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Console.WriteLine("Main thread: Do some work");
        //        Thread.Sleep(0);
        //    }
        //    t.Join(); //ASTEAPTA // sa nu treci peste linia asta pana cand nu termina ThreadMethod de executat codul
        //    Console.ReadKey();
        //}
        #endregion
        #region partea 2 - forground vs background threads
        //public static void ThreadMethod()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("ThreadProc {0}", i);
        //        Thread.Sleep(1000);
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(new ThreadStart(ThreadMethod));
        //    t.IsBackground = true;  // a foreground thread keeps application  for closing; a background thread doesn't
        //    t.Start();
        //    Console.ReadKey();
        //}
        #endregion
        #region partea 3 - parametereized thread
        //public static void ThreadMethod(object o)
        //{
        //    for (int i = 0; i < (int)o; i++)                          // object unboxing
        //    {
        //        Console.WriteLine("ThreadProc {0}", i);
        //        Thread.Sleep(1000);
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
        //    t.Start(15);
        //    Console.ReadKey();
        //}
        #endregion
        #region partea 4 - stop threads; thread static
        //every variable created in one tread it is unique and exist only in that thread 
        //normal global variables => all the treads will use the same variable

        // thread static => every single thread will have its own copy of it

        //[ThreadStatic]                          /// static thread => for variable static _field is created a copy for every thread 
        //public static int _field;
        //static void Main(string[] args)
        //{
        //    Thread t1 = new Thread(new ThreadStart(()=>
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            _field++;
        //            Console.WriteLine("Thread A : {0}", _field);
        //        }
        //    }));
        //    t1.Start();
        //    t1.Join();
        //    Thread t2 = new Thread(new ThreadStart(() =>
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            _field++;
        //            Console.WriteLine("Thread B : {0}", _field);
        //        }
        //    }));
        //    t2.Start();
        //    t2.Join();
        //    Console.ReadKey();
        //}
        #endregion
        #region partea 5  - queuing some work to the thread pool
        // - new thread for many many requests (eg. On server side  => trouble(overload)) => the solution = threadpools
        //static void Main(string[] args)
        //{
        //    //adds the work on this thread pool
        //    //s is for state
        //    ThreadPool.QueueUserWorkItem((s) =>
        //    {
        //        Console.WriteLine("Working on a thread from the thread pool");
        //    });
        //    Console.ReadLine();
        //}
        #endregion
        #region partea 6 - Start working with TASK
        //public static void ThreadMethod()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.Write('*');
        //    }

        //}
        //tasks use the thread pool
        //tasks = managed thread pool threads; tasks can return values (return an task for ex)
        //static void Main(string[] args)
        //{
        //    //Action = predefined delegates has no param and returns nothing
        //    //Task t = Task.Run(() =>
        //    //{
        //    //    for (int i = 0; i < 100; i++)
        //    //    {
        //    //        Console.Write('*');
        //    //    }
        //    //});
        //    Task t = Task.Run(action:ThreadMethod);
        //    t.Wait();
        //    Console.ReadKey();
        //}
        #endregion
        #region partea 7 Tasks that returns values
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }
            ).ContinueWith((taskInt) =>
            {
                return taskInt.Result * 2;
            }
            );

            t = t.ContinueWith((i) =>
            {
                return i.Result * 2;
            }
            ); 
            Console.WriteLine(t.Result); //t do not have to wait. using Result implies that we have to wait until the task is ended
            Console.ReadKey();
            //after task finishes we can do continuations to do some more work
        }
        #endregion
        #region partea 8

        #endregion
    }
}
