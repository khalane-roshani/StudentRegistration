using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact {  get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
