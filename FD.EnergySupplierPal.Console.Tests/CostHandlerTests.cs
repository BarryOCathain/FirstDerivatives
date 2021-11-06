namespace FD.EnergySupplierPal.Console.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Handlers;
    using NUnit.Framework;
    using Plans;

    public class CostHandlerTests
    {
        [Test]
        public void CalculateCosts_NullPlans_ThorwsArgumentNullException()
        {
            var handler = new CostHandler();

            Assert.Throws<ArgumentNullException>(() => handler.CalculateCosts(null, 1));
        }

        [Test]
        public void CalculateCosts_EmptyPlans_ThorwsArgumentNullException()
        {
            var handler = new CostHandler();

            Assert.Throws<ArgumentNullException>(() => handler.CalculateCosts(new List<IPlan>(), 1));
        }

        [TestCase(99, "14.03325")]
        [TestCase(100, "14.175")]
        [TestCase(101, "14.28")]
        public void CalculateCosts_ValidCalculation_CalculatesCorrectly(int consumption, decimal expectedResult)
        {
            var handler = new CostHandler();

            var plans = new List<IPlan>
            {
                new SupplierPlan
                {
                    SupplierName = "Supplier 1",
                    PlanName = "Plan 1",
                    Prices = new Price[]
                    {
                        new Price
                        {
                            Rate = 13.5M,
                            Threshold = 100
                        },
                        new Price
                        {
                            Rate = 10
                        }
                    }
                }
            };

            var costs = handler.CalculateCosts(plans, consumption);

            Assert.That(costs.Count(), Is.EqualTo(1));
            Assert.That(costs.First().Cost, Is.EqualTo(expectedResult));
        }
    }
}
