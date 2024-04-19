using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Products
    {
        [Key]
        [JsonPropertyName("product_id")]
        public int Product_id { get; set; }

        [JsonPropertyName("product_name")]
        public string Product_name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("standard_cost")]
        public decimal Standard_cost { get; set; }

        [JsonPropertyName("list_price")]
        public decimal List_price { get; set; }


        [ForeignKey("Product_Categories")]
        [JsonPropertyName("category_id")]
        public int Category_id { get; set; }

        public Product_Categories? Product_Categories { get; set; }

    }
}
