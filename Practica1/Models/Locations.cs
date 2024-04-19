using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Locations
    {
        [Key]
        [JsonPropertyName("location_id")]
        public int Location_id { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("postal_code")]
        public string? Postal_code { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [ForeignKey("Countries")]
        [JsonPropertyName("country_id")]
        public string Country_id { get; set; }

        public Countries? Countries { get; set; }
    }
}
