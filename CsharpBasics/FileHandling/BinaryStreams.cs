// ITI LECTURE - C# Fundamentals - Binary Streams
// File 5

using System.Text;

namespace CsharpFundamentals.FileHandling
{
    internal class BinaryStreams
    {
        public static void Run()
        {
            Console.WriteLine("========== BINARY STREAMS ==========\n");

            BinaryReaderWriterExample();

            MemoryStreamExample();

            BufferedStreamExample();

            Console.WriteLine("\n====================================");
        }

        //---------------------------------------------------------
        // BinaryWriter & BinaryReader
        //---------------------------------------------------------
        static void BinaryReaderWriterExample()
        {
            Console.WriteLine("========== BinaryWriter / BinaryReader ==========");

            string path = "Student.dat";

            try
            {
                //-------------------------------------------------
                // Write Binary Data
                //-------------------------------------------------

                using (FileStream stream =
                    new FileStream(path, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(101);          // int
                    writer.Write("Ahmed");      // string
                    writer.Write(95.5);         // double
                    writer.Write(true);         // bool
                }

                Console.WriteLine("Binary Data Written.\n");

                //-------------------------------------------------
                // Read Binary Data
                //-------------------------------------------------

                using (FileStream stream =
                    new FileStream(path, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Console.WriteLine($"ID      : {reader.ReadInt32()}");
                    Console.WriteLine($"Name    : {reader.ReadString()}");
                    Console.WriteLine($"Grade   : {reader.ReadDouble()}");
                    Console.WriteLine($"Passed  : {reader.ReadBoolean()}");
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
        // MemoryStream
        //---------------------------------------------------------
        static void MemoryStreamExample()
        {
            Console.WriteLine("========== MemoryStream ==========");

            try
            {
                using MemoryStream memory = new MemoryStream();

                string message = "Hello MemoryStream";

                byte[] bytes = Encoding.UTF8.GetBytes(message);

                //-----------------------------------------
                // Write to memory
                //-----------------------------------------

                memory.Write(bytes);

                Console.WriteLine("Written To Memory.");

                //-----------------------------------------
                // Read from memory
                //-----------------------------------------

                memory.Position = 0;

                byte[] buffer = new byte[memory.Length];

                memory.Read(buffer);

                Console.WriteLine(
                    Encoding.UTF8.GetString(buffer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // BufferedStream
        //---------------------------------------------------------
        static void BufferedStreamExample()
        {
            Console.WriteLine("========== BufferedStream ==========");

            string path = "Buffer.txt";

            try
            {
                using FileStream file =
                    new FileStream(
                        path,
                        FileMode.Create,
                        FileAccess.ReadWrite);

                using BufferedStream buffer =
                    new BufferedStream(file);

                byte[] data =
                    Encoding.UTF8.GetBytes(
                        "Buffered Stream Example");

                //-----------------------------------------
                // Write
                //-----------------------------------------

                buffer.Write(data);

                buffer.Flush();

                //-----------------------------------------
                // Read
                //-----------------------------------------

                buffer.Position = 0;

                byte[] result =
                    new byte[data.Length];

                buffer.Read(result);

                Console.WriteLine(
                    Encoding.UTF8.GetString(result));

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