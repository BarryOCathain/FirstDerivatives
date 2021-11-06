namespace FD.EnergySupplierPal.Console.Handlers
{
    using System.Collections.Generic;
    using Plans;

    public interface IPlanHandler
    {
        /// <summary>
        /// The method to create the plans from the give filepath
        /// </summary>
        /// <param name="planFilePath">The filepath to the json file containing the plans</param>
        /// <returns><see cref="IEnumerable{IPlan}"/></returns>
        IEnumerable<IPlan> CreatePlans(string planFilePath);
    }
}