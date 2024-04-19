using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Customers
    {
        [Key]
        [JsonPropertyName("customer_id")]
        public int? Customer_id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("credit_limit")]
        public decimal Credit_limit { get; set; }

    }
}
