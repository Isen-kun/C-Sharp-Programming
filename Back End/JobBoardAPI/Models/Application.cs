using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class Application
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime AppliedAt { get; set; }

        public string Resume { get; set; }

        public virtual Job Job { get; set; }

        public virtual User User { get; set; }
    }
}
