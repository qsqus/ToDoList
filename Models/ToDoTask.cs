using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [DisplayName("Task")]
        public string Content { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
