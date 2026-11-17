using Kobyzeva_hw8_Latypova.Enum;

namespace Kobyzeva_hw8_Latypova.Class
{
    internal class Worker
    {
        public string Name;
        public Guid Id;
        public List<Task> Tasks;
        
        public Worker(string name)
        {
            Guid Id = Guid.NewGuid();
            Name = name;
            Tasks = new List<Task>();
        }

        public (SolutionWorker, Worker?) DecisionAcceptTask(Task task, List<Worker> workers)
        {
            Console.Write("Решение о задачe (Accept, Delegate, Reject)");
            Console.WriteLine($"{task.Description} сроки: {task.Deadline}");
            SolutionWorker.TryParse(Console.ReadLine(), out SolutionWorker solution);
            if(solution == SolutionWorker.Accept)
            {
                Tasks.Add(task);
                return (SolutionWorker.Accept, null);
            }
            else if(solution == SolutionWorker.Delegate)
            {
                Console.Write("Введите id сотрудника, которому передадите задачу:  ");
                Guid.TryParse(Console.ReadLine(), out Guid idWhomDelegate);
                foreach(Worker worker in workers)
                {
                    if(worker.Id == idWhomDelegate)
                    {
                        return (SolutionWorker.Delegate, worker);
                    }
                }
                Console.WriteLine("Неверно введен id. Задача переходит в категорию отклоненной");
                return (SolutionWorker.Reject, null);
            }
            else
            {
                return (SolutionWorker.Reject, null);
            }
        }


    }
}
