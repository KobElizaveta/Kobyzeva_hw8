using Kobyzeva_hw8_Latypova.Enum;

namespace Kobyzeva_hw8_Latypova.Class
{
    internal class TaskManager
    {
        public List<TeamLead> TeamLeads = new List<TeamLead>();
        public List<Worker> Workers = new List<Worker>();
        public TaskManager()
        {
            TeamLead petrovEI = new TeamLead("Петров Егор Иванович");
            TeamLead sigorovVS = new TeamLead("Сидоров Владимир Степанович");
            TeamLead ezhovaAV = new TeamLead("Ежова Анна Владимировна");
            TeamLeads.AddRange(new[] { petrovEI, sigorovVS, ezhovaAV });

            Worker pavlovaVR = new Worker("Павлова Виолетта Романовна");
            Worker vasilyevDR = new Worker("Васильев Дмитрий Романович");
            Worker kirpichnikovIE = new Worker("Кирпичников Илья Евгеньевич");
            Worker smirnovaMS = new Worker("Смирнова Мария Сергеевна");
            Worker popovaEV = new Worker("Попова Елена Владимировна");
            Worker sokolovMA = new Worker("Соколов Максим Андреевич");
            Worker lebedevaON = new Worker("Лебедева Ольга Николаевна");
            Workers.AddRange(new[] { pavlovaVR, vasilyevDR, kirpichnikovIE, smirnovaMS, popovaEV, sokolovMA, lebedevaON});
        }

        public Project CreateProject()
        {
            Console.WriteLine("Создание проекта");
            Console.Write("Описание:  ");
            string description = Console.ReadLine();
            Console.Write("Срок выполнения:  ");
            bool isParseDate = DateTime.TryParse(Console.ReadLine(), out DateTime deadLine);
            Console.Write("Имя клиента(фио):  ");
            string infoClient = Console.ReadLine();
            Console.Write("Человек, ответственный за проект(фио или id):  ");
            string infoTeamLead = Console.ReadLine();
            bool isParseIDTeamLead = Guid.TryParse(infoTeamLead, out Guid _);
            TeamLead teamLead = null;
            if(!isParseDate || deadLine <= DateTime.Now || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(infoTeamLead) || string.IsNullOrEmpty(infoClient)) 
            { 
                Console.WriteLine("Неверно введены данные. Проект не создан");
                return null;
            }
            else if(isParseIDTeamLead)
            {
                Guid.TryParse(infoTeamLead, out Guid idTeamLead);
                foreach(TeamLead tl in TeamLeads)
                {
                    if(tl.Id == idTeamLead) 
                    { 
                        teamLead = tl;
                        break;
                    } 
                }
            }
            else if (!isParseIDTeamLead)
            {
                foreach (TeamLead tl in TeamLeads)
                {
                    if (tl.Name.Trim() == infoTeamLead.Trim())
                    {
                        teamLead = tl;
                        break;
                    }   
                }
            }

            if(teamLead is not null)
            {
                Client client = new Client(infoClient);
                Project newProject = new Project(description, deadLine, client, teamLead);
                Console.WriteLine("Проект создан");
                return newProject;
            }
            else 
            {
                Console.WriteLine("Тимлид не найден");
                Console.WriteLine("Проект не создан");
                return CreateProject();
            }
        }

        public bool AssignmentExecutor(Project project, Task task)
        {
            if (task.Status != StatusTask.Assigned)
            {
                Console.WriteLine("Задача уже назначена");
                return true;
            }

            List<Worker> history = new List<Worker>();
            Worker correntWorker = Workers.First();

            bool isAssignment = false;
            while (!isAssignment)
            {
                if (history.Contains(correntWorker))
                {
                    if(Workers.Count == history.Count)
                    {
                        Console.WriteLine("Все сотрудники отказались");
                        return false;
                    }
                    foreach(Worker workerNext in Workers)
                    {
                        if(!history.Contains(workerNext))
                        {
                            correntWorker = workerNext;
                            break;
                        }
                    }
                }
                Console.WriteLine($"Задача предлагается {correntWorker.Name}");
                (SolutionWorker solutionWorker, Worker? delegatedWorker) = correntWorker.DecisionAcceptTask(task, Workers);
                if(solutionWorker is SolutionWorker.Accept) 
                {
                    task.Executor = correntWorker;
                    task.Status = StatusTask.InProgress;
                    Console.WriteLine($"{correntWorker.Name} взял задачу {task.Description}");
                    return true;              
                }
                else if(solutionWorker is SolutionWorker.Delegate && delegatedWorker is not null)
                {
                    history.Add(correntWorker);
                    Console.WriteLine($"{correntWorker.Name} делегировал задачу {delegatedWorker.Name}");
                    correntWorker = delegatedWorker;
                }
                else if(solutionWorker is SolutionWorker.Reject)
                {
                    Console.WriteLine($"{correntWorker.Name} отклонил задачу {task.Description}");
                    history.Add(correntWorker);
                }
            }
            return false;
        }

        public void IsAllTaskAssignment(Project project)
        {
            bool isAllTaskAssignment = true;
            foreach (Task task in project.Tasks)
            {
                if(task.Status is StatusTask.Assigned) { isAllTaskAssignment = false; }
            }

            if(isAllTaskAssignment)
            {
                project.Status = StatusProject.Execution;
                Console.WriteLine("Статус проекта - Исполнение");
            }
        }

        public void IsAllTaskComplected(Project project)
        {
            bool isAllTaskComplected = true;
            foreach (Task task in project.Tasks)
            {
                if (task.Status is not StatusTask.Completed) { isAllTaskComplected = false; }
            }

            if (isAllTaskComplected)
            {
                project.Status = StatusProject.Execution;
                Console.WriteLine("Статус проекта - Закрыт");
            }
        }
        
    }
}
