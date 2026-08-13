namespace CsharpFundamentals.Serialization
{
    class SerializationProgram
    {
        public static async Task Run()
        {
            XmlSerialization.Run();
            //BinarySerialization.Run();
            JsonSerialization.Run();
            await HttpClientJson.Run();
        }
    }
}
