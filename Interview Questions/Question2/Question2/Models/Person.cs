using System.ComponentModel.DataAnnotations;

namespace Question2.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; } //primary Key [must]
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Age { get; set; }

        
    }
}
