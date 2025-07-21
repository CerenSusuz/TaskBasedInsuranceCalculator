using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Domain;

namespace TaskBasedInsuranceCalculator.Services
{
    public class InsurancePaymentCalculator
    {
        private readonly ICurrencyService currencyService;
        private readonly ITripRepository tripRepository;

        public InsurancePaymentCalculator(
            ICurrencyService currencyService,
            ITripRepository tripRepository)
        {
            this.currencyService = currencyService;
            this.tripRepository = tripRepository;
        }

        public decimal CalculatePayment(string touristName)
        {
            TripDetails trip = tripRepository.LoadTrip(touristName);

            if (trip == null)
            {
                throw new ArgumentException($"No trip found for tourist: {touristName}");
            }

            decimal rate = currencyService.LoadCurrencyRate();

            decimal payment = Constants.A * rate * trip.FlyCost
                            + Constants.B * rate * trip.AccomodationCost
                            + Constants.C * rate * trip.ExcursionCost;

            return payment;
        }
    }
}
