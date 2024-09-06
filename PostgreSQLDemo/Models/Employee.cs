using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreSQLDemo.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int age { get; set; }
        public string? address { get; set; }
        public string? mobilenumber { get; set; }
    }
}
