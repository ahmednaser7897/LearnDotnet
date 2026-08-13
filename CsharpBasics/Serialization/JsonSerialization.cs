

using Newtonsoft.Json;
using System.Text.Json;

namespace CsharpFundamentals.Serialization
{
    internal class JsonSerialization
    {
        public static void Run()
        {
            Console.WriteLine("================== Json Serialization ==================");
            var e1 = new Employee
            {
                Id = 1001,
                Fname = "Issam",
                Lname = "A.",
                Benefits = { "Pension", "Health Insurance" }
            };
            var jsonContent = SerializeToJsonStringUsingNewSoftJson(e1);
            Console.WriteLine("content json using newtonsoft");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(jsonContent);

            var e2 = DeserializeToJsonStringNewSoftJson(jsonContent);
            Console.WriteLine("content json using Json.Net");
            Console.WriteLine("-----------------------------");
            var jsonContent2 = SerializeToJsonStringUsingJSONNET(e1);
            Console.WriteLine(jsonContent2);

            var e3 = DeserializeToJsonStringJSONNET(jsonContent2);

            Console.WriteLine("====================================\n\n\n");
        }
        static string SerializeToJsonStringUsingNewSoftJson(Employee employee)
        {
            var result = "";
            result = JsonConvert.SerializeObject(employee, Formatting.Indented);

            return result;

        }
        static Employee DeserializeToJsonStringNewSoftJson(string jsonContent)
        {
            Employee employee = null;
            employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
            return employee;
        }

        static string SerializeToJsonStringUsingJSONNET(Employee employee)
        {
            var result = "";
            result = System.Text.Json.JsonSerializer.Serialize(employee,
                new JsonSerializerOptions { WriteIndented = true });

            return result;

        }
        static Employee DeserializeToJsonStringJSONNET(string jsonContent)
        {
            Employee employee = null;
            employee = System.Text.Json.JsonSerializer.Deserialize<Employee>(jsonContent);
            return employee;
        }
        private class Employee
        {
            public int Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public List<string> Benefits { get; set; } = new List<string>();
        }
    }
}
