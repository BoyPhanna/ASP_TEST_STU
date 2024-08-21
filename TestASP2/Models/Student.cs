using System.ComponentModel.DataAnnotations;

namespace TestASP2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }  
    }
}
