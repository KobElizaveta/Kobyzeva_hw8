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
            Console.WriteLine("В команде простые смертные работники: ");
            foreach (Worker worker in manager.Workers)
            {
                Console.Write(worker.Name + "  ");
            }
        }

        static void Task()
        {
            TaskManager manager = new TaskManager();
            Console.WriteLine("Проект создан");
            ReadTeam(manager);

            bool CreatedProgect = false;
            while(!CreatedProgect) { manager.CreateProject(); }








            Console.WriteLine($"Текст отчета: {lastReport.Text}   Срок сдачи: {lastReport.Deadline}");
        }
        static void Main(string[] args)
        {
            Task();
        }
    }
}
