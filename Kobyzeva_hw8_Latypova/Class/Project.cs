using Kobyzeva_hw8_Latypova.Enum;

namespace Kobyzeva_hw8_Latypova.Class
{
    internal class Project
    {
        public string Description;
        public DateTime DeadLine;
        public Client Cleint;
        public TeamLead TeamLead;
        public List<Task> Tasks;
        public StatusProject Status;

        public Project(string description, DateTime deadLine, Client cleint, TeamLead teamLead)
        {
            Description = description;
            DeadLine = deadLine;
            Cleint = cleint;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = StatusProject.Project;
        }

        public void PrintTasks()
        {
            Console.WriteLine("Вывод всех задач");
            foreach(Task task in Tasks)
            {
                Console.Write($"Описание: {task.Description}\nСрок сдачи: {task.Deadline} Заказчик: {task.Client.Name} Ответственный: {task.Executor.Name} Статус: {task.Status}\nОтчеты: ");
                foreach(Report report in task.Reports)
                {
                    Console.WriteLine($"Текст: {report.Text} Дедлайн: {report.Deadline} Ответственный: {report.Executor}");
                }
                if(task.Reports.Count == 0) { Console.WriteLine("Пока отсутствуют"); }
            }
        }

        public Task FindTask()
        {
            Console.Write("Введите описание задачи:  ");
            string descrTask = Console.ReadLine();
            foreach (var task in Tasks)
            {
                if (task.Description == descrTask)
                {
                    return task;
                }
            }
            return null;
        }
    }
}
