using AppDeTareas.Models;
using System.Collections.ObjectModel;

namespace AppDeTareas
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> CurrentTasks { get; set; }
        public Command AddTaskCommand { get; set; }
        public Command<TaskItem> RemoveTaskCommand { get; set; }
        public Command<TaskItem> EditTaskCommand { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Inicializar las tareas y comandos
            CurrentTasks = new ObservableCollection<TaskItem>
            {
                new TaskItem("Tarea 1", "Juan", false, 1),
                new TaskItem("Tarea 2", "Maria", true, 2)
            };

            AddTaskCommand = new Command(AddTask);
            RemoveTaskCommand = new Command<TaskItem>(RemoveTask);
            EditTaskCommand = new Command<TaskItem>(EditTask);

            BindingContext = this;
        }

        private void AddTask()
        {
            // Validaciones básicas
            if (string.IsNullOrEmpty(newTaskTitle.Text) || string.IsNullOrEmpty(newTaskAssignedTo.Text) || newTaskPriority.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Por favor complete todos los campos", "OK");
                return;
            }

            // Crear una nueva tarea usando los datos ingresados
            var newTask = new TaskItem(
                newTaskTitle.Text,
                newTaskAssignedTo.Text,
                false,
                newTaskPriority.SelectedIndex + 1
            );

            // Agregar la nueva tarea a CurrentTasks
            CurrentTasks.Add(newTask);

            // Limpiar los campos de entrada
            newTaskTitle.Text = string.Empty;
            newTaskAssignedTo.Text = string.Empty;
            newTaskPriority.SelectedIndex = -1;
        }

        // Método para eliminar la tarea
        private void RemoveTask(TaskItem task)
        {
            if (task != null)
            {
                CurrentTasks.Remove(task);
            }
        }

        // Método para modificar la tarea
        private async void EditTask(TaskItem task)
        {
            if (task != null)
            {
                // Mostrar una página o diálogo para editar la tarea
                var newTitle = await DisplayPromptAsync("Modificar Tarea", "Modificar el título de la tarea:", initialValue: task.Title);
                if (!string.IsNullOrEmpty(newTitle))
                {
                    task.Title = newTitle;
                }

                var newAssignedTo = await DisplayPromptAsync("Modificar Tarea", "Modificar la persona asignada:", initialValue: task.AssignedTo);
                if (!string.IsNullOrEmpty(newAssignedTo))
                {
                    task.AssignedTo = newAssignedTo;
                }
            }
        }
    }
}


