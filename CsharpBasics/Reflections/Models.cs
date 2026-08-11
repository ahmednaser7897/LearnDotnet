namespace CsharpFundamentals.Reflections
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Employee -> Id = {Id} Name = {Name} Address = {Address} BirthDate = {BirthDate}";
        }

    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return $"Employee -> Id = {Id} Name = {Name} Desc = {Desc} Category = {Category}";
        }
    }

}