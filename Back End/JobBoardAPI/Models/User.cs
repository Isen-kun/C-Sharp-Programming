using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class User
    {
        public User()
        {
            Applications = new HashSet<Application>();
            Employers = new HashSet<Employer>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[Required]
        public string? Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<Employer> Employers { get; set; }

        public virtual Role? Role { get; set; }
    }
}
