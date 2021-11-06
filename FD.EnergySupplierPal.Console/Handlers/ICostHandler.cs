namespace FD.EnergySupplierPal.Console.Handlers
{
    using System.Collections.Generic;
    using Plans;

    public interface ICostHandler
    {
        /// <summary>
        /// The method to calculate costs for the given plans and consumption
        /// </summary>
        /// <param name="plans"><see cref="IEnumerable{IPlan}"/> containing details of the different plans available</param>
        /// <param name="consumption"><see cref="int"/> for the annual consumption of KWh</param>
        /// <returns><see cref="IEnumerable{IPlanCost}"/></returns>
        IEnumerable<IPlanCost> CalculateCosts(IEnumerable<IPlan> plans, int consumption);
    }
}