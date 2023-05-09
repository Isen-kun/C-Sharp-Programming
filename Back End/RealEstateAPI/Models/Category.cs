using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category name can't be null or empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category image URL can't be null or empty")]
        public string ImageUrl { get; set; }

        //public string Description { get; set; }
        //deleted column
        public ICollection<Property> Properties { get; set; }
    }
}
