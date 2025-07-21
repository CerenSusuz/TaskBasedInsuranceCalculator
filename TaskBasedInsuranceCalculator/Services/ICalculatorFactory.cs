using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Services
{
    public interface ICalculatorFactory
    {
        ICalculator CreateCalculator();
        ICalculator CreateCachedCalculator();
        ICalculator CreateLoggingCalculator();
        ICalculator CreateRoundingCalculator();
    }
}
