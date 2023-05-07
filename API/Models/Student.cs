using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname{get; set;}
        
        public int age { get; set;}
        [Required]
        public string HS { get; set; }
        [Required]
        public string direction { get; set; }
    }
}
