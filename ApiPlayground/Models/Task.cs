using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlayground.Models
{
    public class Task
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        
        public int Id { get; set; }
    }
}