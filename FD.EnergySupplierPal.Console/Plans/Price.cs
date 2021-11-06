namespace FD.EnergySupplierPal.Console.Plans
{
    using Newtonsoft.Json;

    public class Price
    {
        /// <summary>
        /// The Rate
        /// </summary>
        [JsonProperty("rate", Required = Required.Always)]
        public decimal Rate { get; set; }

        /// <summary>
        /// The Threshold
        /// </summary>
        [JsonProperty("threshold")]
        public int? Threshold { get; set; }
    }
}
