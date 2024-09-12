using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeTareas.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; } // 1 = High, 2 = Medium, 3 = Low

        public TaskItem(string title, string assignedTo, bool isCompleted, int priority)
        {
            Title = title;
            AssignedTo = assignedTo;
            IsCompleted = isCompleted;
            Priority = priority;
        }
    }
}
