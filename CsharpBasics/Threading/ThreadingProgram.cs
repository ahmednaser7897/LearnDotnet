namespace CsharpFundamentals.Threading
{
    internal class ThreadingProgram
    {
        public static void Run()
        {
            ThreadingBasics.Run();
            //RaceCondition.Run();
            //DeadLock.Run();
            //TestThreadPool.Run();
        }
    }
}
