namespace Kobyzeva_hw8_Latypova.Class
{
    internal class Report
    {
        public string Text;
        public DateTime Deadline;
        public Worker Executor;

        public Report(string text, DateTime deadline, Worker executor)
        {
            Text = text;
            Deadline = deadline;
            Executor = executor;
        }

    }
}
