using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Countries
    {
        [Key]
        [JsonPropertyName("country_id")]
        public string Country_id { get; set; }

        [JsonPropertyName("country_name")]
        public string? Country_name { get; set; }

        [ForeignKey("Regions")]
        [JsonPropertyName("region_id")]
        public int Region_id { get; set; }

        public Regions? Regions { get; set; }
    }
}
