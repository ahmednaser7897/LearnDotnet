using System.IO.Compression;

namespace CsharpFundamentals.Streams
{
    internal class StreamDecorator
    {
        public static void Run()
        {
            Console.WriteLine("================== Stream Decorator ==================");


            using (var stream = File.Create("data.bin"))
            {
                using (var ds = new DeflateStream(stream, CompressionMode.Compress))
                {
                    ds.WriteByte(65);
                    ds.WriteByte(66);
                }
            }

            using (var stream = File.OpenRead("data.bin"))
            {
                using (var ds = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    for (int i = 0; i < stream.Length; i++)
                    {
                        Console.WriteLine(ds.ReadByte());
                    }
                }
            }

            Console.WriteLine("====================================\n\n\n");
        }
    }

}
