using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Services;

namespace TaskBasedInsuranceCalculator
{
    public class LoggingCalculator : ICalculator
    {
        private readonly ICalculator baseCalculator;
        private readonly ILogger logger;

        public LoggingCalculator(ICalculator baseCalculator, ILogger logger)
        {
            this.baseCalculator = baseCalculator;
            this.logger = logger;
        }

        public decimal CalculatePayment(string touristName)
        {
            logger.Log("Start");

            var result = baseCalculator.CalculatePayment(touristName);

            logger.Log("End");

            return result;
        }
    }
}
