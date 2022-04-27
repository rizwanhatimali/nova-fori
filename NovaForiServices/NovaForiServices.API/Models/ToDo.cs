using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NovaForiServices.API.Models
{
    public class ToDo
    {
        [Key]
        [JsonPropertyName("id")]
        public int ItemId { get; set; } = default(int);

        [Required]
        [JsonPropertyName("description")]
        public string ItemDescription { get; set; }

        [JsonPropertyName("status")]
        public ToDoStatus ItemStatus { get; set; } = ToDoStatus.Pending;
    }

    public enum ToDoStatus
    {
        Pending = 1,
        Completed
    }
}
