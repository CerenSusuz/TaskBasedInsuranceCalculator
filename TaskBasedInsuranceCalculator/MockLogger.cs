namespace TaskBasedInsuranceCalculator
{
    public class MockLogger : ILogger
    {
        private readonly List<string> logs = new List<string>();

        public void Log(string message)
        {
            logs.Add(message);
        }

        public List<string> GetLogs()
        {
            return logs;
        }
    }
}
