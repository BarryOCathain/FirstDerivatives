namespace FD.EnergySupplierPal.Console
{
    /// <summary>
    /// The IPlanCost interface
    /// </summary>
    public interface IPlanCost
    {
        /// <summary>
        /// The Supplier Name
        /// </summary>
        string SupplierName { get; set; }

        /// <summary>
        /// The Plan Name
        /// </summary>
        string PlanName { get; set; }

        /// <summary>
        /// The Cost
        /// </summary>
        decimal Cost { get; set; }
    }
}