// ITI LECTURE - C# Fundamentals - Streams
// File 3

using System.Text;

namespace CsharpFundamentals.FileHandling
{
    internal class Streams
    {
        public static void Run()
        {
            Console.WriteLine("========== STREAMS ==========\n");

            FileStreamBasics();

            StreamProperties();

            SeekExample();

            ReadWriteUsingBuffer();

            Console.WriteLine("\n=============================");
        }

        //---------------------------------------------------------
        // FileStream Basics
        //---------------------------------------------------------
        static void FileStreamBasics()
        {
            Console.WriteLine("========== FileStream Basics ==========");

            string path = "Message.txt";

            try
            {
                //-------------------------------------------------
                // Create FileStream
                //-------------------------------------------------

                using FileStream stream =
                    new FileStream(
                        path,
                        FileMode.Create,
                        FileAccess.ReadWrite);

                //-------------------------------------------------
                // Write bytes
                //-------------------------------------------------

                string message = "Hello ITI Students";

                byte[] data = Encoding.UTF8.GetBytes(message);

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Data Written.");

                //-------------------------------------------------
                // Move to beginning
                //-------------------------------------------------

                stream.Position = 0;

                //-------------------------------------------------
                // Read bytes
                //-------------------------------------------------

                byte[] buffer = new byte[data.Length];

                stream.Read(buffer, 0, buffer.Length);

                Console.WriteLine(
                    Encoding.UTF8.GetString(buffer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Stream Properties
        //---------------------------------------------------------
        static void StreamProperties()
        {
            Console.WriteLine("========== Stream Properties ==========");

            string path = "Data.txt";

            File.WriteAllText(path, "ABCDEFG");

            using FileStream stream =
                File.OpenRead(path);

            Console.WriteLine($"Length     : {stream.Length}");

            Console.WriteLine($"Position   : {stream.Position}");

            Console.WriteLine($"Can Read   : {stream.CanRead}");

            Console.WriteLine($"Can Write  : {stream.CanWrite}");

            Console.WriteLine($"Can Seek   : {stream.CanSeek}");

            Console.WriteLine();

            byte[] buffer = new byte[3];

            stream.Read(buffer);

            Console.WriteLine(
                Encoding.UTF8.GetString(buffer));

            Console.WriteLine();

            Console.WriteLine($"Position : {stream.Position}");

            File.Delete(path);

            Console.WriteLine();
        }
        //---------------------------------------------------------
        // Seek()
        //---------------------------------------------------------
        static void SeekExample()
        {
            Console.WriteLine("========== Seek ==========");

            string path = "Seek.txt";

            try
            {
                File.WriteAllText(path, "ABCDEFGHIJ");

                using FileStream stream = File.OpenRead(path);

                //-------------------------------------------------
                // Read first character
                //-------------------------------------------------

                Console.WriteLine((char)stream.ReadByte());

                //-------------------------------------------------
                // Move to index 5 (Letter F)
                //-------------------------------------------------

                stream.Seek(5, SeekOrigin.Begin);

                Console.WriteLine((char)stream.ReadByte());

                //-------------------------------------------------
                // Move 2 bytes forward from current position
                //-------------------------------------------------

                stream.Seek(2, SeekOrigin.Current);

                Console.WriteLine((char)stream.ReadByte());

                //-------------------------------------------------
                // Move 2 bytes before the end
                //-------------------------------------------------

                stream.Seek(-2, SeekOrigin.End);

                Console.WriteLine((char)stream.ReadByte());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Read & Write Using Buffer
        //---------------------------------------------------------
        static void ReadWriteUsingBuffer()
        {
            Console.WriteLine("========== Buffer ==========");

            string path = "Buffer.txt";

            try
            {
                using FileStream stream =
                    new FileStream(
                        path,
                        FileMode.Create,
                        FileAccess.ReadWrite);

                string text =
                    "Learning FileStream is easy!";

                byte[] writeBuffer =
                    Encoding.UTF8.GetBytes(text);

                //-----------------------------------------------
                // Write Buffer
                //-----------------------------------------------

                stream.Write(
                    writeBuffer,
                    0,
                    writeBuffer.Length);

                // Ensure all buffered data is written to disk
                stream.Flush();

                Console.WriteLine("Data Written.");

                //-----------------------------------------------
                // Read Buffer
                //-----------------------------------------------

                stream.Position = 0;

                byte[] readBuffer =
                    new byte[stream.Length];

                int bytesRead =
                    stream.Read(
                        readBuffer,
                        0,
                        readBuffer.Length);

                Console.WriteLine($"Bytes Read : {bytesRead}");

                Console.WriteLine(
                    Encoding.UTF8.GetString(readBuffer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);

            Console.WriteLine();
        }
    }
}