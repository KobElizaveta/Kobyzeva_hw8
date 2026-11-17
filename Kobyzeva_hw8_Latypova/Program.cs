using Kobyzeva_hw8_Latypova.Class;

namespace Kobyzeva_hw8_Latypova
{
    internal class Program
    {
        static void ReadTeam(TaskManager manager)
        {
            Console.WriteLine("В команде тимлиды: ");
            foreach (TeamLead teamLead in manager.TeamLeads)
            {
                Console.Write(teamLead.Name + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("В команде простые смертные работники: ");
            foreach (Worker worker in manager.Workers)
            {
                Console.Write(worker.Name + "  ");
            }
            Console.WriteLine();
        }

        static void Task()
        {
            TaskManager manager = new TaskManager();
            ReadTeam(manager);

            Project currentProject = manager.CreateProject();

            TeamLead currentTeamLead = currentProject.TeamLead;
            bool isContinue = true;
            while(isContinue)
            {
                Console.WriteLine("Выберите действие (Create Task, Delete Task, Print Tasks, Assign Executor For Task, Create Report, Check Report)");
                string action = Console.ReadLine();
                switch(action)
                {
                    case "Create Task":
                        var newTask = currentTeamLead.AssignmentTask(currentProject);
                        if(newTask is not null)
                        {
                            bool isExecutor = manager.AssignmentExecutor(currentProject, newTask);
                            if (!isExecutor) { Console.WriteLine("Вы можете позже назначить кого-то на задчау или удалить ее"); }
                        }
                        break;
                    case "Delete Task":
                        currentTeamLead.RemoveTask(currentProject);
                        break;
                    case "Print Tasks":
                        currentProject.PrintTasks();
                        break;
                    case "Assign Executor For Task":
                        var currentTask = currentProject.FindTask();
                        manager.AssignmentExecutor(currentProject, currentTask);
                        break;
                    case "Create Report":
                        currentTask = currentProject.FindTask();
                        var currentWorker = currentTask.Executor;
                        if(currentTask is not null) { currentTask.CreateReport(currentWorker); }
                        break;
                    case "Check Report":
                        currentTask = currentProject.FindTask();
                        currentTask.Print();
                        Console.WriteLine("Принять последний отчет? (Accept / Not Accept)");
                        string isAssept = Console.ReadLine();
                        if(isAssept == "Accept") { currentTask.ApproveOneTimeReport();  }
                        else if(isAssept == "Not Accept") { currentTask.NotApproveOneTimeReport(); }
                        else { Console.WriteLine("Не удалось распознать решение"); }
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Task();
        }
    }
}
