﻿namespace TodoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? Deadline { get; set; }
    }
}