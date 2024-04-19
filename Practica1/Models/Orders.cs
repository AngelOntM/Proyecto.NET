using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Orders
    {
        [Key]
        [JsonPropertyName("order_id")]
        public int Order_id { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        public int Customer_id { get; set; }

        public Customers? Customers { get; set; }


        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("salesman_id")]
        public int? Salesman_id { get; set; }

        [JsonPropertyName("order_date")]
        public DateTime Order_date { get; set; }


    }
}
