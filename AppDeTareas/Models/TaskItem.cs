using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeTareas.Models
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string assignedTo;
        public string AssignedTo
        {
            get => assignedTo;
            set
            {
                if (assignedTo != value)
                {
                    assignedTo = value;
                    OnPropertyChanged(nameof(AssignedTo));
                }
            }
        }

        public bool IsCompleted { get; set; }
        public int Priority { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TaskItem(string title, string assignedTo, bool isCompleted, int priority)
        {
            Title = title;
            AssignedTo = assignedTo;
            IsCompleted = isCompleted;
            Priority = priority;
        }
    }
}
