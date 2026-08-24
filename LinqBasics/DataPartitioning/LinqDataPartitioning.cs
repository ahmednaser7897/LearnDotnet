namespace Linq.DataPartitioning
{
    internal class LinqDataPartitioning
    {
        public static void Run()
        {
            // Run Skip examples.
            // SkipExamples();

            // Run Take examples.
            // TakeExamples();

            // Run Chunk examples.
            // ChunkExamples();

            // Run pagination examples.
            PaginateExamples();
        }


        // ============================================================
        // Skip Examples
        // ============================================================

        public static void SkipExamples()
        {
            Console.WriteLine("===================== Skip Examples =====================");

            // Load employees from the repository.
            var emps = Repository.LoadEmployees();


            // Skip the first 10 employees.
            var q1 = emps.Skip(10);

            q1.Print("Skip First 10 Employees");


            // Skip elements until the condition becomes true.
            var q2 = emps.SkipWhile(x => x.Salary != 214400);

            q2.Print("Skip While Salary Does Not Equal 214,400");


            // Skip the last 10 elements.
            var q3 = emps.SkipLast(10);

            q3.Print("Skip Last 10 Elements");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Take Examples
        // ============================================================

        public static void TakeExamples()
        {
            Console.WriteLine("===================== Take Examples =====================");

            // Load employees from the repository.
            var emps = Repository.LoadEmployees();


            // Take the first 10 employees.
            var q1 = emps.Take(10);

            q1.Print("Take First 10 Employees");


            // Take elements until the condition becomes false.
            var q2 = emps.TakeWhile(x => x.Salary != 214400);

            q2.Print("Take While Salary Does Not Equal 214,400");


            // Take the last 10 elements.
            var q3 = emps.TakeLast(10);

            q3.Print("Take Last 10 Elements");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Chunk Examples
        // ============================================================

        public static void ChunkExamples()
        {
            Console.WriteLine("===================== Chunk Examples =====================");

            // Load employees from the repository.
            var emps = Repository.LoadEmployees();

            // Split the employees into chunks of 10.
            var chuncks = emps.Chunk(10).ToList();


            // Loop through all chunks.
            for (int i = 0; i < chuncks.Count; i++)
            {
                // Print each chunk with its number.
                chuncks[i].Print($"Chunk #{i + 1}");
            }


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Paginate Examples
        // ============================================================

        public static void PaginateExamples()
        {
            Console.WriteLine("===================== Paginate Examples =====================");

            // Set the default page number.
            var page = 1;

            // Set the default page size.
            var size = 10;


            // Ask the user for the number of results per page.
            Console.WriteLine("Results per page:");

            if (int.TryParse(Console.ReadLine(), out int resultPerPage))
            {
                // Use the user's page size if the input is valid.
                size = resultPerPage;
            }


            // Ask the user for the page number.
            Console.WriteLine("Page No.:");

            if (int.TryParse(Console.ReadLine(), out int pageNo))
            {
                // Use the user's page number if the input is valid.
                page = pageNo;
            }


            // Load employees from the repository.
            var emps = Repository.LoadEmployees();


            // Get the employees for the requested page.
            var result = emps.Paginate(page, size);


            // Count the employees in the current page.
            var resultCount = result.Count();


            // Calculate the first record number.
            var startRecord = ((page - 1) * size) + 1;


            // Calculate the last record number.
            var endRecord =
                resultCount < size
                    ? startRecord + resultCount - 1
                    : size * (page - 1) + size;


            // Print the employees and their record range.
            result.Print($"Showing Employees {startRecord} - {endRecord}");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }


    // ============================================================
    // Pagination Extension
    // ============================================================

    public static class Extensions
    {
        // Returns only the records that belong to the requested page.
        public static IEnumerable<T> Paginate<T>(
            this IEnumerable<T> source,
            int page = 1,
            int size = 10) where T : class
        {
            // Use page 1 when the page number is invalid.
            if (page <= 0)
            {
                page = 1;
            }


            // Use 10 items per page when the size is invalid.
            if (size <= 0)
            {
                size = 10;
            }


            // Get the total number of records.
            var total = source.Count();


            // Calculate the total number of pages.
            var pages = (int)Math.Ceiling((decimal)total / size);


            // Skip previous pages and take the requested page.
            var result = source
                .Skip((page - 1) * size)
                .Take(size);


            // Return the records for the requested page.
            return result;
        }
    }
}
