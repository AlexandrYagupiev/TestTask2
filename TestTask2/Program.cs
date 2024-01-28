namespace TestTask2
{
    public static class Program
    {
        static void Main(string[] args)//Тест методов 
        {
            Parallel.For(0, 50, i =>
            {
                if (i % 2 == 0)
                {
                    AddToCount(2);
                }
                else
                {
                    Console.WriteLine(GetCount());
                }
            });
            Console.WriteLine(GetCount());
            Console.WriteLine("End");
            Console.ReadKey();
        }

        private static int count;
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            count += value;
            locker.ExitWriteLock();
        }

        public static int GetCount()
        {
            locker.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
    }
}
