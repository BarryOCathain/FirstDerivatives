namespace FD.EnergySupplierPal.Console.Plans
{
    using System.Collections.Generic;

    public interface IPlan
    {
        string SupplierName { get; set; }
        string PlanName { get; set; }
        Price[] Prices { get; set; }
        int? StandingCharge { get; set; }
    }
}