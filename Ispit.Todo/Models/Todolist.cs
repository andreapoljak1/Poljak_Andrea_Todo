using Ispit.Todo.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models
{
    public class Todolist
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Naziv grupe zadataka")]
        public string Title { get; set; }

        [Display(Name = "Opis grupe zadataka")]
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }
        [NotMapped]
        public ICollection<TaskTodo>? Tasks { get; set; }



    }

}
