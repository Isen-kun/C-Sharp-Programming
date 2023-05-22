using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class Employer
    {
        public Employer()
        {
            Jobs = new HashSet<Job>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactPhone { get; set; }

        [Column(TypeName = "text")]
        public virtual User? User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
