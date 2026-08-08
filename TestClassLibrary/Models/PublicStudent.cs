namespace TestClassLibrary.Models
{
    public class PublicStudent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public PublicStudent(string name, int age, string email, string phone, string address)
        {
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Email: {Email}, Phone: {Phone}, Address: {Address}";
        }
        public void AccessStudent()
        {
            //Create an instance of Student-> we can access its properties because they are public
            //and we can access its constructor because it is public
            InternalStudent student = new(name: "ahmed", age: 30, email: "ahmed@gmail.com", phone: "1233434", address: "cairo egypt");
            Console.WriteLine(student);
        }
    }
}
