using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Services
{
    public class RoundingCalculator : ICalculator
    {
        private readonly ICalculator baseCalculator;

        public RoundingCalculator(ICalculator baseCalculator)
        {
            this.baseCalculator = baseCalculator;
        }

        public decimal CalculatePayment(string touristName)
        {
            decimal result = baseCalculator.CalculatePayment(touristName);

            return Math.Round(result);
        }
    }
}
