namespace ProjectMangerAppReviso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviso.active_projects")]
    public partial class Active_projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Active_projects()
        {
            Working_hours = new HashSet<Working_hours>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PName { get; set; }

        [Required]
        [StringLength(15)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Working_hours> Working_hours { get; set; }
    }
}
