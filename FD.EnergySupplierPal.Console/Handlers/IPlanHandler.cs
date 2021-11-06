namespace FD.EnergySupplierPal.Console.Handlers
{
    using System.Collections.Generic;
    using Plans;

    public interface IPlanHandler
    {
        IEnumerable<IPlan> CreatePlans(string planFilePath);
    }
}