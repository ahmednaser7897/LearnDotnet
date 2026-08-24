using Linq.DataPartitioning;
using Linq.FunctionalProgramming;
using Linq.GenerationOperations;
using Linq.GroupingData;
using Linq.JoinOperations;
using Linq.Projection;
using Linq.Quantifiers;
using Linq.Sorting;
namespace Linq
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LinqBasics.Run();
            LinqFunctionalProgramming.Run();
            CoreOfLINQ.Run();
            LinqProjection.Run();
            LinqSorting.Run();
            LinqDataPartitioning.Run();
            LinqQuantifiers.Run();
            LinqGroupingData.Run();
            LinqJoins.Run();
            LinqGeneration.Run();
        }
    }
}
