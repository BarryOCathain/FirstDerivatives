namespace FD.EnergySupplierPal.Console.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Plans;

    public class CostHandler : ICostHandler
    {
        private const int DaysInYear = 365;

        public IEnumerable<IPlanCost> CalculateCosts(IEnumerable<IPlan> plans, int consumption)
        {
            if (null == plans || !plans.Any())
                throw new ArgumentNullException(nameof(plans));

            var results = new List<IPlanCost>();

            foreach (var plan in plans)
            {
                var cost = 0M;
                var remainder = consumption;

                if (plan.StandingCharge.HasValue)
                    cost += DaysInYear * plan.StandingCharge.Value;

                foreach (var price in plan.Prices.Where(p => p.Threshold.HasValue))
                {
                    var threshold = 0;

                    if (remainder >= price.Threshold.Value)
                        threshold = price.Threshold.Value;
                    else if (remainder < price.Threshold.Value)
                        threshold = remainder;

                    cost += threshold * price.Rate;

                    remainder -= price.Threshold.Value;

                    if (remainder <= 0)
                        break;
                }

                var coverCharge = plan.Prices.FirstOrDefault(p => !p.Threshold.HasValue);

                if (null != coverCharge && remainder > 0)
                    cost += remainder * coverCharge.Rate;

                //plus VAT
                cost *= 1.05M;

                //pence to pounds
                cost /= 100;

                var result = new PlanCost
                {
                    SupplierName = plan.SupplierName,
                    PlanName = plan.PlanName,
                    Cost = cost
                };

                results.Add(result);

            }

            return results;
        }
    }
}
