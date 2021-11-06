namespace FD.EnergySupplierPal.Console.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Handlers;
    using NSubstitute;
    using NUnit.Framework;
    using Plans;

    public class InputManagerTests
    {
        private IPlanHandler _planHandler;
        private ICostHandler _costHandler;

        [SetUp]
        public void Setup()
        {
            _planHandler = Substitute.For<IPlanHandler>();
            _costHandler = Substitute.For<ICostHandler>();
        }

        [Test]
        public void Constructor_NullPlanHandler_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new InputManager(null, _costHandler));
        }

        [Test]
        public void Constructor_NullCOstHandler_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new InputManager(_planHandler, null));
        }

        [Test]
        public void Constructor_NullPlanHandlerANdNullCostHandler_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new InputManager(null, null));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void InitializePlans_EmptyFilePath_ThrowsArgumentNullException(string filePath)
        {
            var manager = new InputManager(_planHandler, _costHandler);

            Assert.Throws<ArgumentNullException>(() => manager.InitializePlans(filePath));
        }

        [Test]
        public void InitializePlans_FilePathDoesNotExist_ThrowsArgumentNullException()
        {
            var manager = new InputManager(_planHandler, _costHandler);

            Assert.Throws<FileNotFoundException>(() => manager.InitializePlans("badTest.json"));
        }

        [Test]
        public void InitializePlans_ValidFilePath_DoesNotThrowException()
        {
            var manager = new InputManager(_planHandler, _costHandler);

            Assert.DoesNotThrow(() => manager.InitializePlans("TestPlan.json"));
        }

        [Test]
        public void CalculateCosts_NoPlans_ThrowsInvalidOperationException()
        {
            _planHandler.CreatePlans(Arg.Any<string>()).Returns((IEnumerable<IPlan>)null);

            var manager = new InputManager(_planHandler, _costHandler);

            Assert.Throws<InvalidOperationException>(() => manager.CalculateCosts(1));
        }

        [Test]
        public void CalculateCosts_1ValidPlan_DoesNotThrowException()
        {
            _planHandler.CreatePlans(Arg.Any<string>())
                .Returns(new List<IPlan>
                {
                    new SupplierPlan
                    {
                        PlanName = "Test Plan",
                        SupplierName = "Test Supplier",
                        Prices = new Price[] {}
                    }
                });

            var manager = new InputManager(_planHandler, _costHandler);

            manager.InitializePlans("TestPlan.json");

            Assert.DoesNotThrow(() => manager.CalculateCosts(1));
        }
    }
}