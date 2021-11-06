namespace FD.EnergySupplierPal.Console.Handlers
{
    using System.Collections.Generic;
    using Plans;

    public interface ICostHandler
    {
        IEnumerable<IPlanCost> CalculateCosts(IEnumerable<IPlan> plans, int consumption);
    }
}