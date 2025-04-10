using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class TaskViewModel
    {
        public string Description { get; set; }
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Срок выполнения обязателен.")]
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}