using Kobyzeva_hw8_Latypova.Enum;

namespace Kobyzeva_hw8_Latypova.Class
{
    internal class Task
    {
        public string Description;
        public DateTime Deadline;
        public Client Client;
        public Worker Executor;
        public StatusTask Status;
        public List<Report> Reports;
        public Task(Project project, string description, DateTime deadline)
        {
            Description = description;
            Deadline = deadline;
            Client = project.Cleint;
            Executor = null;
            Status = StatusTask.Assigned;
            Reports = null;
        }

        public void CreateReport(Worker executor)
        {
            if (Status is not StatusTask.InProgress)
            {
                Console.WriteLine("В текущем статусе отчет создать невозможно");
                return;
            }

            Console.Write("Введите текст отчета:  ");
            string text = Console.ReadLine();
            Report newReport = new Report(text, DateTime.Now, executor);
            Reports.Add(newReport);
            Status = StatusTask.UnderReview;

            Console.WriteLine($"{executor.Name} отправил отчет. Ожидает проверки");
        }

        public void ApproveOneTimeReport()
        {
            if(Status is not StatusTask.UnderReview) { return; }

            Report lastReport = Reports[Reports.Count - 1];
            Status = StatusTask.Completed;
            Console.WriteLine("Отчет утвержден. Задача выполнена");
        }

        public void NotApproveOneTimeReport()
        {
            if (Status is not StatusTask.UnderReview) { return; }

            Report lastReport = Reports[Reports.Count - 1];
            Status = StatusTask.InProgress;
            Console.WriteLine("Отчет НЕ утвержден. Задача отправлена на доработку");
        }
    }
}
