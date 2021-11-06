namespace FD.EnergySupplierPal.Console.Plans
{
    using System.Collections.Generic;

    /// <summary>
    /// The IPlan interface
    /// </summary>
    public interface IPlan
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
        /// The array of <see cref="Price"/>
        /// </summary>
        Price[] Prices { get; set; }

        /// <summary>
        /// The Standing Charge
        /// </summary>
        int? StandingCharge { get; set; }
    }
}