using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class Priority
    {
        [Key]
        public int Priority_Id { get; set; }

        [Display(Name = "Priority")]
        [Required]
        [MaxLength(50)]
        public string? Priority_Name { get; set; }
    }
}
