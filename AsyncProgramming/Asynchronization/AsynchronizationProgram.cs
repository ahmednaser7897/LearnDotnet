namespace AsyncProgramming.Asynchronization
{
    internal class AsynchronizationProgram
    {
        public static void Run()
        {
            //TaskClassBasics.Run();

            //AsynchronizationBasics.Run();

            //CancellationToken.Run();

            //var task = TaskCombinators.Run();
            //task.GetAwaiter().OnCompleted(() => Console.WriteLine("TaskCombinators is over"));

            var task = ConcurrencyAndParallelism.Run();
            task.GetAwaiter().OnCompleted(() => Console.WriteLine("ConcurrencyAndParallelism is over"));

            task.Wait();
        }
    }
}
