// ITI LECTURE - C# Fundamentals - Directory & Path
// File 2

namespace CsharpFundamentals.FileHandling
{
    internal class DirectoryAndPath
    {
        public static void Run()
        {
            Console.WriteLine("========== DIRECTORY & PATH ==========\n");

            DirectoryOperations();

            PathOperations();

            DirectoryInfoExample();

            SearchFilesExample();

            Console.WriteLine("\n======================================");
        }

        //---------------------------------------------------------
        // Directory Class
        //---------------------------------------------------------
        static void DirectoryOperations()
        {
            Console.WriteLine("========== Directory ==========");

            string folder = "Students";

            try
            {
                //-------------------------------------------------
                // Exists
                //-------------------------------------------------

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    Console.WriteLine("Directory Created.");
                }

                //-------------------------------------------------
                // Create Files
                //-------------------------------------------------

                File.WriteAllText(Path.Combine(folder, "Ahmed.txt"), "Ahmed");
                File.WriteAllText(Path.Combine(folder, "Ali.txt"), "Ali");
                File.WriteAllText(Path.Combine(folder, "Sara.txt"), "Sara");

                //-------------------------------------------------
                // Get Files
                //-------------------------------------------------

                Console.WriteLine("\nFiles:");

                foreach (string file in Directory.GetFiles(folder))
                {
                    Console.WriteLine(file);
                }

                //-------------------------------------------------
                // Get Directories
                //-------------------------------------------------

                Console.WriteLine("\nSub Directories:");

                foreach (string dir in Directory.GetDirectories(folder))
                {
                    Console.WriteLine(dir);
                }

                //-------------------------------------------------
                // Delete Directory
                //-------------------------------------------------

                Directory.Delete(folder, true);

                Console.WriteLine("\nDirectory Deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Path Class
        //---------------------------------------------------------
        static void PathOperations()
        {
            Console.WriteLine("========== Path ==========");

            string path =
                @"D:\Projects\Students\Ahmed.txt";

            Console.WriteLine($"Full Path      : {path}");

            Console.WriteLine($"File Name      : {Path.GetFileName(path)}");

            Console.WriteLine($"File Name Only : {Path.GetFileNameWithoutExtension(path)}");

            Console.WriteLine($"Extension      : {Path.GetExtension(path)}");

            Console.WriteLine($"Directory      : {Path.GetDirectoryName(path)}");

            Console.WriteLine($"Root           : {Path.GetPathRoot(path)}");

            Console.WriteLine();

            string newPath =
                Path.Combine("Students", "Images", "photo.jpg");

            Console.WriteLine($"Combine : {newPath}");

            Console.WriteLine();

            Console.WriteLine($"Temp Path : {Path.GetTempPath()}");

            Console.WriteLine($"Random File : {Path.GetRandomFileName()}");

            Console.WriteLine($"Temp File : {Path.GetTempFileName()}");

            Console.WriteLine();
        }
        //---------------------------------------------------------
        // DirectoryInfo Class
        //---------------------------------------------------------
        static void DirectoryInfoExample()
        {
            Console.WriteLine("========== DirectoryInfo ==========");

            string folder = "Employees";

            try
            {
                // Create directory
                DirectoryInfo directory = new DirectoryInfo(folder);

                if (!directory.Exists)
                {
                    directory.Create();
                    Console.WriteLine("Directory Created.");
                }

                // Create some files
                File.WriteAllText(Path.Combine(folder, "Ahmed.txt"), "Ahmed");
                File.WriteAllText(Path.Combine(folder, "Ali.txt"), "Ali");
                File.WriteAllText(Path.Combine(folder, "Sara.txt"), "Sara");

                Console.WriteLine();

                Console.WriteLine($"Name          : {directory.Name}");
                Console.WriteLine($"Full Name     : {directory.FullName}");
                Console.WriteLine($"Parent        : {directory.Parent?.Name}");
                Console.WriteLine($"Created       : {directory.CreationTime}");
                Console.WriteLine($"Exists        : {directory.Exists}");

                Console.WriteLine();

                Console.WriteLine("Files:");

                foreach (FileInfo file in directory.GetFiles())
                {
                    Console.WriteLine($"{file.Name,-15} {file.Length} Bytes");
                }

                directory.Delete(true);

                Console.WriteLine("\nDirectory Deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Search Files
        //---------------------------------------------------------
        static void SearchFilesExample()
        {
            Console.WriteLine("========== Search Files ==========");

            string folder = "Projects";

            try
            {
                Directory.CreateDirectory(folder);
                Directory.CreateDirectory(Path.Combine(folder, "Images"));
                Directory.CreateDirectory(Path.Combine(folder, "Documents"));

                File.WriteAllText(Path.Combine(folder, "Program.cs"), "");
                File.WriteAllText(Path.Combine(folder, "Readme.txt"), "");
                File.WriteAllText(Path.Combine(folder, "Images", "photo.jpg"), "");
                File.WriteAllText(Path.Combine(folder, "Documents", "Notes.txt"), "");

                //-------------------------------------------------
                // Search *.txt
                //-------------------------------------------------

                Console.WriteLine("TXT Files:");

                foreach (string file in Directory.GetFiles(folder, "*.txt"))
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                Console.WriteLine();

                //-------------------------------------------------
                // Recursive Search
                //-------------------------------------------------

                Console.WriteLine("All TXT Files (Recursive):");

                foreach (string file in Directory.GetFiles(
                    folder,
                    "*.txt",
                    SearchOption.AllDirectories))
                {
                    Console.WriteLine(file);
                }

                Console.WriteLine();

                //-------------------------------------------------
                // Search CS Files
                //-------------------------------------------------

                Console.WriteLine("C# Files:");

                foreach (string file in Directory.GetFiles(
                    folder,
                    "*.cs",
                    SearchOption.AllDirectories))
                {
                    Console.WriteLine(file);
                }

                Directory.Delete(folder, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}