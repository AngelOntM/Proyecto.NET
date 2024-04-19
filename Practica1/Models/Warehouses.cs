using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Warehouses
    {
        [Key]
        [JsonPropertyName("warehouse_id")]
        public int Warehouse_id { get; set; }

        [JsonPropertyName("warehouse_name")]
        public string Warehouse_name { get; set; }

        [ForeignKey("Locations")]
        [JsonPropertyName("location_id")]
        public int Location_id { get; set; }

        public Locations? Locations { get; set; }

    }
}
