using System.Collections.Generic;

namespace ApiPlayground.Models
{
    public class GetAllCategoriesResponse : GenericResponseModel
    {
        public List<Category> CategoryList { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}