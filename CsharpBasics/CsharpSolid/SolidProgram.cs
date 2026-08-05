namespace CsharpFundamentals.Solid;

public static class SolidProgram
{
    public static void Run()
    {
        RunExample(nameof(SRP_Before), SRP_Before.Run);
        RunExample(nameof(SRP_After), SRP_After.Run);

        //RunExample(nameof(OCP_Before), OCP_Before.Run);
        //RunExample(nameof(OCP_After), OCP_After.Run);

        //RunExample(nameof(LSP_Before), LSP_Before.Run);
        //RunExample(nameof(LSP_After), LSP_After.Run);

        //RunExample(nameof(ISP_Before), ISP_Before.Run);
        //RunExample(nameof(ISP_After), ISP_After.Run);

        //RunExample(nameof(DIP_Before), DIP_Before.Run);
        //RunExample(nameof(DIP_After), DIP_After.Run);

        //RunExample(nameof(LSP_vs_ISP), LSP_vs_ISP.Run);
        //RunExample(nameof(OCP_vs_DIP), OCP_vs_DIP.Run);
        //RunExample(nameof(UserDataManager), UserDataManager.Run);
    }

    private static void RunExample(string exampleName, Action run)
    {
        Console.WriteLine($"\n\n================ {exampleName} ================");

        try
        {
            run();
        }
        catch (Exception exception)
        {
            // Some "Before" examples intentionally throw to demonstrate a SOLID violation.
            Console.WriteLine($"Example ended with {exception.GetType().Name}: {exception.Message}");
        }
    }
}
