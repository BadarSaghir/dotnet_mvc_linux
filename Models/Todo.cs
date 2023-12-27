
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Status")]
        public string Status { get; set; } = "pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now ;
        
    }

}