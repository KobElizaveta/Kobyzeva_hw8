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
            Tasks = null;
            Status = StatusProject.Project;
        }


    }
}
