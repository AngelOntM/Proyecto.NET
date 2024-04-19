using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Order_Items
    {
        [Key]
        [ForeignKey("Orders")]
        [JsonPropertyName("order_id")]
        public int Order_id { get; set; }

        public Orders? Orders { get; set; }


        [JsonPropertyName("item_id")]
        public int Item_id { get; set; }

        [ForeignKey("Products")]
        [JsonPropertyName("product_id")]
        public int Product_id { get; set; }

        public Products? Products { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal? Unit_price { get; set; }

    }
}
