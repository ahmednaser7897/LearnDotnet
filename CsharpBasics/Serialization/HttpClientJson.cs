using System.Text.Json;

namespace CsharpFundamentals.Serialization
{
    internal class HttpClientJson
    {
        private readonly static HttpClient httpClient = new HttpClient();
        public static async Task Run()
        {
            Console.WriteLine("================== Http Client Json ==================");
            var todoesJsonContent = await httpClient.GetStringAsync("https://dummyjson.com/todos");

            var todoes = JsonSerializer.Deserialize<AllTodos>(todoesJsonContent
                , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (var item in todoes.todos)
                Console.WriteLine(item);
            Console.WriteLine("====================================\n\n\n");

        }


        public class AllTodos
        {
            public TodoClass[] todos { get; set; }
            public int total { get; set; }
            public int skip { get; set; }
            public int limit { get; set; }
        }

        public class TodoClass
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public bool Completed { get; set; }

            public string Todo { get; set; }

            public override string ToString()
            {
                return $"\n [{Id} - UserId: {UserId}] -  {Todo} {(Completed ? "completed" : "not completed")}";
            }
        }

    }
}
