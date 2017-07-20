namespace ProjectMangerAppReviso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviso.active_projects")]
    public partial class active_projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public active_projects()
        {
            working_hours = new HashSet<working_hours>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string pName { get; set; }

        [Required]
        [StringLength(15)]
        public string authorName { get; set; }

        [Required]
        [StringLength(15)]
        public string customerName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime startDate { get; set; }

        public DateTime? endDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<working_hours> working_hours { get; set; }
    }
}
