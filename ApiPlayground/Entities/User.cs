using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayground.Entities
{
    public class User
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Key] [JsonIgnore] [Column("user_id")] public long UserId { get; set; }
    }
}