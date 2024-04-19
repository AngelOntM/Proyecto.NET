using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practica1.Models
{
    public class Employees
    {
        [Key]
        [JsonPropertyName("employee_id")]
        public int Employee_id { get; set; }
        
        [JsonPropertyName("first_name")]
        public string First_name { get; set; }
        
        [JsonPropertyName("last_name")]
        public string Last_name { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        
        [JsonPropertyName("hire_date")]
        public DateTime Hire_date { get; set; }

        [ForeignKey("Employees")]
        [JsonPropertyName("manager_id")]
        public int? Manager_id { get; set; }

        [JsonPropertyName("job_title")]
        public string Job_title { get; set; }
    }
}
