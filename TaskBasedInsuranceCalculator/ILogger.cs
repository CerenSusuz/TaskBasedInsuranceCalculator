using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator
{
    public interface ILogger
    {
        void Log(string message);
    }

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
