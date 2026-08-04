// ITI LECTURE - C# Fundamentals - File Handling
// File 1 : FileBasics.cs

namespace CsharpFundamentals.FileHandling
{
    internal class FileBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== FILE BASICS ==========\n");

            TextFileOperations();

            LineOperations();

            BinaryOperations();

            CopyMoveReplaceOperations();

            FileInfoExample();

            OpenReadWriteExample();

            Console.WriteLine("\n================================");
        }

        //---------------------------------------------------------
        // Text File Operations
        //---------------------------------------------------------
        static void TextFileOperations()
        {
            Console.WriteLine("========== Text File Operations ==========");

            string path = "Student.txt";

            try
            {
                //-------------------------------------------------
                // Exists
                //-------------------------------------------------

                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    Console.WriteLine("File Created.");
                }

                //-------------------------------------------------
                // Write
                //-------------------------------------------------

                File.WriteAllText(path,
@"Name : Ahmed
Age : 22
Department : Computer Science");

                Console.WriteLine("\nAfter WriteAllText()\n");

                Console.WriteLine(File.ReadAllText(path));


                //-------------------------------------------------
                // Append
                //-------------------------------------------------

                File.AppendAllText(path,
                    Environment.NewLine +
                    "Grade : A");

                Console.WriteLine("\nAfter AppendAllText()\n");

                Console.WriteLine(File.ReadAllText(path));

                //-------------------------------------------------
                // Delete
                //-------------------------------------------------

                File.Delete(path);

                Console.WriteLine("\nFile Deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
        //---------------------------------------------------------
        // ReadAllLines() & WriteAllLines()
        //---------------------------------------------------------
        static void LineOperations()
        {
            Console.WriteLine("========== Line Operations ==========");

            string path = "Employees.txt";

            try
            {
                string[] employees =
                {
                    "Ahmed",
                    "Ali",
                    "Mohamed",
                    "Sara",
                    "Mona"
                };

                // Write array to file
                File.WriteAllLines(path, employees);

                Console.WriteLine("Employees Written Successfully.\n");

                // Read array from file
                string[] result = File.ReadAllLines(path);

                Console.WriteLine("Employees:");

                foreach (string employee in result)
                {
                    Console.WriteLine(employee);
                }

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // ReadAllBytes() & WriteAllBytes()
        //---------------------------------------------------------
        static void BinaryOperations()
        {
            Console.WriteLine("========== Binary Operations ==========");

            string path = "Numbers.bin";

            try
            {
                byte[] numbers =
                {
                    10,20,30,40,50
                };

                // Write bytes
                File.WriteAllBytes(path, numbers);

                Console.WriteLine("Bytes Written.\n");

                // Read bytes
                byte[] result = File.ReadAllBytes(path);

                Console.WriteLine("Bytes Inside File:");

                foreach (byte number in result)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Copy - Move - Replace
        //---------------------------------------------------------
        static void CopyMoveReplaceOperations()
        {
            Console.WriteLine("========== Copy / Move / Replace ==========");

            string source = "File1.txt";
            string copy = "File2.txt";
            string moved = "File3.txt";
            string replace = "File4.txt";

            try
            {
                File.WriteAllText(source, "Original File");

                //-------------------------------------------------
                // Copy
                //-------------------------------------------------

                File.Copy(source, copy, true);

                Console.WriteLine("File Copied.");

                //-------------------------------------------------
                // Move
                //-------------------------------------------------

                File.Move(copy, moved, true);

                Console.WriteLine("File Moved.");

                //-------------------------------------------------
                // Replace
                //-------------------------------------------------

                File.WriteAllText(replace, "Old Data");

                File.Replace(source, replace, null);

                Console.WriteLine("File Replaced.");

                Console.WriteLine();

                Console.WriteLine("Content of File4:");

                Console.WriteLine(File.ReadAllText(replace));

                File.Delete(moved);
                File.Delete(replace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // FileInfo
        //---------------------------------------------------------
        static void FileInfoExample()
        {
            Console.WriteLine("========== FileInfo ==========");

            string path = "Student.txt";

            File.WriteAllText(path,
@"Ahmed
Computer Science");

            FileInfo file = new FileInfo(path);

            Console.WriteLine($"Name          : {file.Name}");
            Console.WriteLine($"Extension     : {file.Extension}");
            Console.WriteLine($"Directory     : {file.DirectoryName}");
            Console.WriteLine($"Size          : {file.Length} Bytes");
            Console.WriteLine($"Created       : {file.CreationTime}");
            Console.WriteLine($"Last Modified : {file.LastWriteTime}");
            Console.WriteLine($"Exists        : {file.Exists}");

            File.Delete(path);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // OpenRead() & OpenWrite()
        //---------------------------------------------------------
        static void OpenReadWriteExample()
        {
            Console.WriteLine("========== OpenRead / OpenWrite ==========");

            string path = "Sample.txt";

            try
            {
                File.WriteAllText(path, "Hello ITI");

                //------------------------------------------
                // OpenRead
                //------------------------------------------

                using (FileStream readStream = File.OpenRead(path))
                {
                    Console.WriteLine($"Length : {readStream.Length}");
                    Console.WriteLine($"Can Read : {readStream.CanRead}");
                    Console.WriteLine($"Can Write : {readStream.CanWrite}");
                }

                //------------------------------------------
                // OpenWrite
                //------------------------------------------

                using (FileStream writeStream = File.OpenWrite(path))
                {
                    Console.WriteLine($"Can Write : {writeStream.CanWrite}");
                    Console.WriteLine($"Position : {writeStream.Position}");
                }

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}