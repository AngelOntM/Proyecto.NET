using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Product_Categories
    {
        [Key]
        [JsonPropertyName("category_id")]
        public int Category_id { get; set; }

        [JsonPropertyName("category_name")]
        public string Category_name { get; set; }

    }
}
