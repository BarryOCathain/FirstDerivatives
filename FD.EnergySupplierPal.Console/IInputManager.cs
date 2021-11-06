namespace FD.EnergySupplierPal.Console
{
    using System.Collections.Generic;
    using Handlers;

    public interface IInputManager
    {
        void InitializePlans(string planFilePath);
        IEnumerable<IPlanCost> CalculateCosts(int consumption);
    }
}