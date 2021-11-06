namespace FD.EnergySupplierPal.Console.Plans
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SupplierPlan : IPlan
    {
        [JsonProperty("supplier_name", Required = Required.Always)]
        public string SupplierName { get; set; }

        [JsonProperty("plan_name", Required = Required.Always)]
        public string PlanName { get; set; }

        [JsonProperty("prices", Required = Required.Always)]
        public Price[] Prices { get; set; }

        [JsonProperty("standing_charge")]
        public int? StandingCharge { get; set; }
    }
}
