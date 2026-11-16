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

        public void AssignmentTask(Project project)
        {
            Console.WriteLine("Создание задач");
            bool isContinue = true;
            while(isContinue)
            {
                Console.Write("Описание:  ");
                string description = Console.ReadLine();
                Console.Write("Срок выполнения (формат 15/06/2024):  ");
                bool isParseDeadLine = DateTime.TryParse(Console.ReadLine(), out DateTime deadLine);
                if(isParseDeadLine && description is not null)
                {
                    Task newTask = new Task(project, description, deadLine);
                    project.Tasks.Add(newTask);
                }
                else
                {
                    Console.WriteLine("Неверный ввод данных. Задача не добавлена");
                }

                Console.Write("Хотите продолжить? (д/н)");
                string answerIsContinue = Console.ReadLine();
                if(answerIsContinue == "н") { isContinue = false; }
            }

        }

        public void RemoveTask(Project project, Task task)
        {
            project.Tasks.Remove(task);
            Console.WriteLine($"Задача {task} удалена");
        }
    }
}
