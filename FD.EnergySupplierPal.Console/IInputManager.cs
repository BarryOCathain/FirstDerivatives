namespace FD.EnergySupplierPal.Console
{
    using System.Collections.Generic;

    /// <summary>
    /// The IInputManager interface
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// Initializes the plans on the instance of <see cref="IInputManager"/>
        /// </summary>
        /// <param name="planFilePath">the path to the json file for the plans</param>
        void InitializePlans(string planFilePath);

        /// <summary>
        /// Calculates the costs for the given consumption
        /// </summary>
        /// <param name="consumption">The annual consumption in KWh</param>
        /// <returns><see cref="IEnumerable{IPlanCost}"/></returns>
        IEnumerable<IPlanCost> CalculateCosts(int consumption);
    }
}