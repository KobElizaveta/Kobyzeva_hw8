using Kobyzeva_hw8_Latypova.Enum;

namespace Kobyzeva_hw8_Latypova.Class
{
    internal class TeamLead
    {
        public string Name;
        public Guid Id;

        public TeamLead(string name)
        {
            Id = new Guid();
            Name = name;
        }

        public Task AssignmentTask(Project project)
        {
            Console.WriteLine("Создание задачи");
            Console.Write("Описание:  ");
            string description = Console.ReadLine();
            Console.Write("Срок выполнения (формат 15/06/2024):  ");
            bool isParseDeadLine = DateTime.TryParse(Console.ReadLine(), out DateTime deadLine);
            Task newTask = null;
            if (isParseDeadLine && description is not null && deadLine <= project.DeadLine && deadLine > DateTime.Now)
            {
                newTask = new Task(project, description, deadLine);
                project.Tasks.Add(newTask);
                Console.WriteLine("Задача создана и добавлена");
                return newTask;
            }
            else
            {
                Console.WriteLine("Неверный ввод данных. Задача не добавлена");
                return null;
            }      
        }

        public void RemoveTask(Project project, params List<Task> tasksToRemove)
        {
            Console.WriteLine("Удаление задачи");
            if(tasksToRemove.Count == 0)
            {
                tasksToRemove.Add(project.FindTask());
                if(tasksToRemove.Count == 0) { Console.WriteLine("Задача не найдена. Удаление не произошло"); }
            }

            foreach(Task task in tasksToRemove)
            {
                project.Tasks.Remove(task);
                Console.WriteLine($"Задача {task.Description} удалена");
            }
        }
    }
}
