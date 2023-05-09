using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class Category
    {
        public Category()
        {
            Jobs = new HashSet<Job>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
