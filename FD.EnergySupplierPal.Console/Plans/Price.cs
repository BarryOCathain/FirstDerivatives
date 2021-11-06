namespace FD.EnergySupplierPal.Console.Plans
{
    using Newtonsoft.Json;

    public class Price
    {
        [JsonProperty("rate", Required = Required.Always)]
        public decimal Rate { get; set; }

        [JsonProperty("threshold")]
        public int? Threshold { get; set; }
    }
}
