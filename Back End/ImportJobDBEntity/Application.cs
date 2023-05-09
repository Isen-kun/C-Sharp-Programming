namespace ImportJobDBEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime AppliedAt { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual Job Job { get; set; }

        public virtual User User { get; set; }
    }
}
