using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Regions
    {
        [Key]
        [JsonPropertyName("region_id")]
        public int Region_id { get; set; }

        [JsonPropertyName("region_name")]
        public string Region_name { get; set; }
    }
}
