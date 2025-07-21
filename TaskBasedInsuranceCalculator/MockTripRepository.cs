using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Domain;

namespace TaskBasedInsuranceCalculator
{
    public class MockTripRepository : ITripRepository
    {
        public TripDetails LoadTrip(string touristName)
        {
            return new TripDetails
            {
                TouristName = touristName,
                FlyCost = 1000m,
                AccomodationCost = 2000m,
                ExcursionCost = 500m
            };
        }
    }
}
