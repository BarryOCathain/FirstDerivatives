namespace FD.EnergySupplierPal.Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Handlers;
    using Plans;

    public class InputManager : IInputManager
    {
        private readonly IPlanHandler _planHandler;
        private readonly ICostHandler _costHandler;

        private IEnumerable<IPlan> _plans;

        public InputManager(IPlanHandler planHandler, ICostHandler costHandler)
        {
            _planHandler = planHandler ?? throw new ArgumentNullException(nameof(planHandler));
            _costHandler = costHandler ?? throw new ArgumentNullException(nameof(costHandler));
        }

        public void InitializePlans(string planFilePath)
        {
            if (string.IsNullOrWhiteSpace(planFilePath))
                throw new ArgumentNullException(nameof(planFilePath));

            if (!File.Exists(planFilePath))
                throw new FileNotFoundException(planFilePath);

            _plans = _planHandler.CreatePlans(planFilePath);
        }

        public IEnumerable<IPlanCost> CalculateCosts(int consumption)
        {
            if (null == _plans || !_plans.Any())
                throw new InvalidOperationException("No plans have been initialized");

            var costs = _costHandler.CalculateCosts(_plans, consumption);

            return costs;
        }
    }
}
