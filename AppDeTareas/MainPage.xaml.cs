using AppDeTareas.Models;
using System.Collections.ObjectModel;

namespace AppDeTareas
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Project> Projects { get; set; }
        public Command AddTaskCommand { get; set; }
        public ObservableCollection<TaskItem> CurrentTasks { get; set; }


        public MainPage()
        {
            InitializeComponent();

            // Crear algunos proyectos hardcodeados con tareas, asegurándonos de que Tasks es ObservableCollection
            Projects = new ObservableCollection<Project>
    {
        new Project("Proyecto 1", "Descripción del Proyecto 1", DateTime.Now.AddDays(-5), DateTime.Now.AddMonths(1))
        {
            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem("Tarea 1", "Juan", false, 1),
                new TaskItem("Tarea 2", "Maria", true, 2),
            }
        },
        new Project("Proyecto 2", "Descripción del Proyecto 2", DateTime.Now, DateTime.Now.AddMonths(2))
        {
            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem("Tarea 3", "Carlos", false, 3),
                new TaskItem("Tarea 4", "Lucia", true, 1),
            }
        }
    };

            // Inicializamos CurrentTasks con las tareas del primer proyecto
            CurrentTasks = Projects[0].Tasks;

            // Inicializar el comando para agregar tareas
            AddTaskCommand = new Command(AddTask);
            BindingContext = this;
        }

        // Método para agregar una nueva tarea al primer proyecto (Projects[0])
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
                newTaskTitle.Text,              // Título de la tarea
                newTaskAssignedTo.Text,         // Persona asignada
                false,                          // La tarea comienza como no completada
                newTaskPriority.SelectedIndex + 1 // La prioridad es seleccionada en el Picker (índice +1)
            );

            // Agregar la nueva tarea a CurrentTasks (que está vinculada a las tareas del primer proyecto)
            CurrentTasks.Add(newTask);

            // Limpiar los campos de entrada
            newTaskTitle.Text = string.Empty;
            newTaskAssignedTo.Text = string.Empty;
            newTaskPriority.SelectedIndex = -1;
        }
    }
}
