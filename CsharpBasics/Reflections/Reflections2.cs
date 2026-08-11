using System.Reflection;

namespace CsharpFundamentals.Reflections
{
    internal class Reflections2
    {
        public static void Run()
        {

            //TestGetTypes();
            //Console.WriteLine("==========================================");
            //DateTimeData();
            //Console.WriteLine("==========================================");
            IntData();
            Console.WriteLine("==========================================");


        }
        public static void TestGetTypes()
        {
            Console.WriteLine("===================== Test Get Types =====================");
            object obj = new object();
            // Returns a Type object which represent this object instance.
            var item = obj.GetType();// get data about the type of object
            //var item = typeof(object);//get data about type off class or type
            Console.WriteLine($"item.Name --> {item.Name} , item.Namespace --> {item.Namespace} ,item.BaseType --> {item.BaseType}");
            var assembly = Assembly.GetExecutingAssembly();
            // return the typs in my assembly
            //var types = assembly.GetTypes();
            // return the public typs in my assembly
            var types = assembly.GetExportedTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"type.Name --> {type.Name} , type.Namespace --> {type.Namespace} ,type.BaseType --> {type.BaseType}");
            }
            Console.WriteLine();
        }
        public static void DateTimeData()
        {
            Console.WriteLine("===================== Date Time Data =====================");
            //using typeof we can get all data about this type
            var type = typeof(DateTime);//get data about type off class or type
            // we can see all things in a type using GetMembers();
            //var members = type.GetMembers();
            //we can send item of BindingFlags to filter the output but we must use flage to find
            // must use mor the one flag 
            var members = type.GetMembers(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var item in members)
            {
                Console.WriteLine($"item.Name --> {item.Name} , item.MemberType --> {item.MemberType}");
            }
            Console.WriteLine("==========================================");
            // GetProperties(); the same like GetMembers();
            //but works on properties only
            var properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var item in properties)
            {
                Console.WriteLine($"item.Name --> {item.Name} , item.MemberType --> {item.MemberType} Read only? {item.SetMethod==null}");
            }
            //and the same for GetMethods() ,GetEvents ....
            Console.WriteLine();
        }

        public static void IntData()
        {
            Console.WriteLine("===================== Date Time Data =====================");
            var type = typeof(int);//get data about type off class or type 
            var method = type.GetMethod("Min");
            foreach (var item in method.GetParameters())
            {
                Console.WriteLine($"item.Name --> {item.Name} , item.ParameterType --> {item.ParameterType}");
            }
            Console.WriteLine($"int.Min(5,10) --> {int.Min(5,10)}");
            // we can call this method throw Reflections
            // we send 2 thing
            // 1- the object that we perform the method on it if not static method->here its null becous its static method
            // 2- the list of parimetars
            Console.WriteLine($"method.Invoke(null, [5,10]) --> {method.Invoke(null, [5,10])}");

            //we can do it for a instans method
            var dateTime = typeof(DateTime);
            var addDays = dateTime.GetMethod("AddDays");
            var date1=DateTime.Now;
            Console.WriteLine($"Date1 --> {date1}");
            var date2 = addDays.Invoke(date1, [10]);
            Console.WriteLine($"Date2 --> {date2}");
            Console.WriteLine();
        }
    }
}
