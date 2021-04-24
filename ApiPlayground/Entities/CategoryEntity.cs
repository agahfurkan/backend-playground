using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlayground.Entities
{
    public class CategoryEntity
    {
        [Key] [Column("category_id")] public int CategoryId { get; set; }

        [Column("category_name")] public string CategoryName { get; set; }
    }
}