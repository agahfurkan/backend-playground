using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPlayground.Models
{
    public class Category
    {
        [Key]
        [Column("category_id")]
        public double CategoryId { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
    }
}
