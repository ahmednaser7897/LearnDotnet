// ITI LECTURE - C# Fundamentals - Serialization
// File 6

using System.Text.Json;
using System.Xml.Serialization;

namespace CsharpFundamentals.FileHandling
{
    internal class SerializationBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== SERIALIZATION ==========\n");

            JsonSerializationExample();

            XmlSerializationExample();

            Console.WriteLine("\n==================================");
        }

        //---------------------------------------------------------
        // Class To Serialize
        //---------------------------------------------------------
        public class Student
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public double GPA { get; set; }

            // Required for XML Serialization
            public Student()
            {

            }

            public Student(int id, string name, int age, double gpa)
            {
                Id = id;
                Name = name;
                Age = age;
                GPA = gpa;
            }
        }

        //---------------------------------------------------------
        // JSON Serialization
        //---------------------------------------------------------
        static void JsonSerializationExample()
        {
            Console.WriteLine("========== JSON ==========");

            string path = "Student.json";

            try
            {
                Student student =
                    new Student(
                        1,
                        "Ahmed",
                        22,
                        3.85);

                //------------------------------------------
                // Object -> JSON
                //------------------------------------------

                string json =
                    JsonSerializer.Serialize(
                        student,
                        new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });

                Console.WriteLine("Serialized JSON:");

                Console.WriteLine(json);

                File.WriteAllText(path, json);

                //------------------------------------------
                // JSON -> Object
                //------------------------------------------

                string jsonFromFile =
                    File.ReadAllText(path);

                Student? loadedStudent =
                    JsonSerializer.Deserialize<Student>(
                        jsonFromFile);

                Console.WriteLine();

                Console.WriteLine("Deserialized Object:");

                Console.WriteLine($"ID   : {loadedStudent?.Id}");
                Console.WriteLine($"Name : {loadedStudent?.Name}");
                Console.WriteLine($"Age  : {loadedStudent?.Age}");
                Console.WriteLine($"GPA  : {loadedStudent?.GPA}");

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // XML Serialization
        //---------------------------------------------------------
        static void XmlSerializationExample()
        {
            Console.WriteLine("========== XML ==========");

            string path = "Student.xml";

            try
            {
                Student student =
                    new Student(
                        2,
                        "Sara",
                        21,
                        3.95);

                XmlSerializer serializer =
                    new XmlSerializer(typeof(Student));

                //------------------------------------------
                // Object -> XML
                //------------------------------------------

                using (FileStream stream =
                    new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(stream, student);
                }

                Console.WriteLine("XML File Created.");

                //------------------------------------------
                // XML -> Object
                //------------------------------------------

                using (FileStream stream =
                    new FileStream(path, FileMode.Open))
                {
                    Student loadedStudent =
                        (Student)serializer.Deserialize(stream)!;

                    Console.WriteLine();

                    Console.WriteLine("Deserialized Object:");

                    Console.WriteLine($"ID   : {loadedStudent.Id}");
                    Console.WriteLine($"Name : {loadedStudent.Name}");
                    Console.WriteLine($"Age  : {loadedStudent.Age}");
                    Console.WriteLine($"GPA  : {loadedStudent.GPA}");
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