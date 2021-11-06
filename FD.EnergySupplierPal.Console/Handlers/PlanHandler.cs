namespace FD.EnergySupplierPal.Console.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Plans;

    /// <summary>
    /// <inheritdoc cref="IPlanHandler"/>
    /// </summary>
    public class PlanHandler : IPlanHandler
    {
        public IEnumerable<IPlan> CreatePlans(string planFilePath)
        {
            if (string.IsNullOrWhiteSpace(planFilePath))
                throw new ArgumentNullException(nameof(planFilePath));

            if (!File.Exists(planFilePath))
                throw new FileNotFoundException(planFilePath);

            var plansText = File.ReadAllText(planFilePath);

            if (string.IsNullOrWhiteSpace(plansText))
                throw new InvalidOperationException("input file is empty");

            return JsonConvert.DeserializeObject<IEnumerable<SupplierPlan>>(plansText);
        }
    }
}
