using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Domain
{
    public interface ICurrencyService
    {
        decimal LoadCurrencyRate();
    }
}
