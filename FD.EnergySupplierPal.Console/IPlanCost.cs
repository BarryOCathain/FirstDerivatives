namespace FD.EnergySupplierPal.Console
{
    public interface IPlanCost
    {
        string SupplierName { get; set; }
        string PlanName { get; set; }
        decimal Cost { get; set; }
    }
}