using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class Job
    {
        public Job()
        {
            Applications = new HashSet<Application>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int EmployerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string JobType { get; set; }

        public decimal? Salary { get; set; }

        public int CategoryId { get; set; }

        public int SkillId { get; set; }

        public int LocationId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual Location? Location { get; set; }

        public virtual Skill? Skill { get; set; }
    }
}
