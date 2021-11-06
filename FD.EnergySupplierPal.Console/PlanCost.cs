namespace FD.EnergySupplierPal.Console
{
    /// <summary>
    /// <inheritdoc cref="IPlanCost"/>
    /// </summary>
    public class PlanCost : IPlanCost
    {
        public string SupplierName { get; set; }
        public string PlanName { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{SupplierName},{PlanName},{Cost:F}";
        }
    }
}
