// ITI LECTURE - C# Fundamentals - Text Streams
// File 4

namespace CsharpFundamentals.FileHandling
{
    internal class TextStreams
    {
        public static void Run()
        {
            Console.WriteLine("========== TEXT STREAMS ==========\n");

            StreamWriterReaderExample();

            ReadMethodsExample();

            StringReaderWriterExample();

            Console.WriteLine("\n==================================");
        }

        //---------------------------------------------------------
        // StreamWriter & StreamReader
        //---------------------------------------------------------
        static void StreamWriterReaderExample()
        {
            Console.WriteLine("========== StreamWriter / StreamReader ==========");

            string path = "Students.txt";

            try
            {
                //-------------------------------------------------
                // StreamWriter
                //-------------------------------------------------

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("Ahmed");
                    writer.WriteLine("Ali");
                    writer.WriteLine("Sara");
                    writer.WriteLine("Mona");

                    // Make sure everything is written
                    writer.Flush();
                }

                Console.WriteLine("Data Written.\n");

                //-------------------------------------------------
                // StreamReader
                //-------------------------------------------------

                using (StreamReader reader = new StreamReader(path))
                {
                    string? line;

                    Console.WriteLine("Students:");

                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Read Methods
        //---------------------------------------------------------
        static void ReadMethodsExample()
        {
            Console.WriteLine("========== Read Methods ==========");

            string path = "Message.txt";

            try
            {
                File.WriteAllText(path,
@"Hello
Welcome To ITI
C# Fundamentals");

                using (StreamReader reader = new StreamReader(path))
                {
                    //-------------------------------------------------
                    // ReadLine
                    //-------------------------------------------------

                    Console.WriteLine("ReadLine():");

                    Console.WriteLine(reader.ReadLine());

                    //-------------------------------------------------
                    // Read
                    //-------------------------------------------------

                    Console.WriteLine();

                    Console.WriteLine("Read() (Next Character):");

                    Console.WriteLine((char)reader.Read());

                    //-------------------------------------------------
                    // ReadToEnd
                    //-------------------------------------------------

                    Console.WriteLine();

                    Console.WriteLine("ReadToEnd():");

                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // StringReader & StringWriter
        //---------------------------------------------------------
        static void StringReaderWriterExample()
        {
            Console.WriteLine("========== StringReader / StringWriter ==========");

            try
            {
                StringWriter writer = new StringWriter();

                writer.WriteLine("Ahmed");
                writer.WriteLine("Ali");
                writer.WriteLine("Sara");

                string data = writer.ToString();

                Console.WriteLine("StringWriter Output:");

                Console.WriteLine(data);

                Console.WriteLine();

                StringReader reader = new StringReader(data);

                Console.WriteLine("Reading From String:");

                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                reader.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}