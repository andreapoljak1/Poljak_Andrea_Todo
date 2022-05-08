using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Todo.Models
{
    public class TaskTodo
    {
        public int Id { get; set; }

        [ForeignKey("TodolistId")]
        public Todolist Todolist { get; set; }
        [Display(Name = "Grupa zadataka")]
        public int TodolistId { get; set; }

        [Required]
        [Display(Name = "Zadatak")]
        public string TitleTask { get; set; }

        [Required]
        [Display(Name = "Opis zadatka")]
        public string DescriptionTask { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Datum početka")]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
    }
}
