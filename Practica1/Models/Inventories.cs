using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Inventories
    {
        [Key]
        [ForeignKey("Products")]
        [JsonPropertyName("product_id")]
        public int Product_id { get; set; }

        public Products? Products { get; set; }

        [ForeignKey("Warehouses")]
        [JsonPropertyName("warehouse_id")]
        public int Warehouse_id { get; set; }

        public Warehouses? Warehouses { get; set;}

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
