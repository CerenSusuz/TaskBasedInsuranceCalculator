using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Services
{
    public interface ICalculator
    {
        decimal CalculatePayment(string touristName);
    }
}
