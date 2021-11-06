namespace FD.EnergySupplierPal.Console.Tests
{
    using System;
    using System.IO;
    using Handlers;
    using NUnit.Framework;

    public class PlanHandlerTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CreatePlans_NullOrEmptyFilePath_ThrowsArgumentNullException(string filePath)
        {
            var handler = new PlanHandler();

            Assert.Throws<ArgumentNullException>(() => handler.CreatePlans(filePath));
        }

        [Test]
        public void CreatePlans_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var handler = new PlanHandler();

            Assert.Throws<FileNotFoundException>(() => handler.CreatePlans("badTest.json"));
        }

        [Test]
        public void CreatePlans_EmptyFile_ThrowsInvalidOperationException()
        {
            var handler = new PlanHandler();

            Assert.Throws<InvalidOperationException>(() => handler.CreatePlans("EmptyTestPlan.json"));
        }

        [Test]
        public void CreatePlans_ValidFile_DoesNotThrowException()
        {
            var handler = new PlanHandler();

            Assert.DoesNotThrow(() => handler.CreatePlans("TestPlan.json"));
        }
    }
}
