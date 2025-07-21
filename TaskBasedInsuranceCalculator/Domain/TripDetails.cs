using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Domain
{
    public class TripDetails
    {
        public string TouristName { get; set; }
        public decimal FlyCost { get; set; }
        public decimal AccomodationCost { get; set; }
        public decimal ExcursionCost { get; set; }
    }
}
