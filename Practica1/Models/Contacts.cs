using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Contacts
    {
        [Key]
        [JsonPropertyName("contact_id")]
        public int Contact_id { get; set; }

        [JsonPropertyName("first_name")]
        public string First_name { get; set; }

        [JsonPropertyName("last_name")]
        public string Last_name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        public int Customer_id { get; set; }

        public Customers? Customers { get; set; }
    }
}
