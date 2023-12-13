using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace mythread
{
    public class Program
    {
        static void Main(string[] args)
        {

            Test.TestThree();
            //Test.TestTwo();

            //Test.TestOne();

            //Console.WriteLine("Я работаю в "+Thread.CurrentThread.ManagedThreadId+ " потоке");

            //new Thread(() => Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке")).Start();
            //new Thread(() => Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке")).Start();
            //new Thread(() => Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке")).Start();
            //new Thread(() => Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке")).Start();
            //new Thread(() => Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке")).Start();

            //Thread.Sleep(1000);
            //Console.WriteLine("Я работаю в " + Thread.CurrentThread.ManagedThreadId + " потоке");
        }

     
    }

    class Test
    {
        public static void TestOne()
        {
            Console.WriteLine("TheOne начал работу в потоке" + Thread.CurrentThread.ManagedThreadId);
            Test.myWait();
            Console.WriteLine("TheOne закночил работу в потоке" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        public static async Task myWait()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("myWait Начал ждать в потоке " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);
                Console.WriteLine("myWait Закончил ждать в потоке " + Thread.CurrentThread.ManagedThreadId);
            });
        }

        public static void TestTwo()
        {
            ParallelThreeMethod(() => TestMethod1(), () => TestMethod2(), () => TestMethod3());
            Thread.Sleep(1000);
            Console.WriteLine("The End Test 2");

        }

        public static void TestMethod1()
        {
            Console.WriteLine($"Выполняется метод 1 в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void TestMethod2()
        {
            while (true)
                Console.WriteLine($"Выполняется метод 2 в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void TestMethod3()
        {
            Console.WriteLine($"Выполняется метод 3 в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async void ParallelThreeMethod(Action MyMethod1, Action MyMethod2, Action MyMethod3)
        {
            _ = Task.Run(() =>
            {
                Parallel.Invoke(() => MyMethod1(), () => MyMethod2(), () => MyMethod3());
            });

        }

        public static void TestThree()
        {
            WaitWork().ContinueWith((Any => StartWork())); // Выполнится после выполнения WaitWork
            Parallel.Invoke(()=> StartWork(), ()=> StartWork());// Выполняется паралельно WaitWork
            Console.ReadLine();
           
        }


        private static async Task WaitWork()
        {
           await Task.Run(() =>
            {
                int i = 0;
                while (i<100) {
                    Console.WriteLine("WaitWork начал работать в потоке:" + Thread.CurrentThread.ManagedThreadId);
                    i++;
                }
                
            });

        }

        private static async Task StartWork()
        {

            _ = Task.Run(() =>
            {
                    Console.WriteLine("StartWork начал работать в потоке:" + Thread.CurrentThread.ManagedThreadId);
            });
          
        }



    }
}
