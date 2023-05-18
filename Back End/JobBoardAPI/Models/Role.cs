using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobBoardAPI.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
