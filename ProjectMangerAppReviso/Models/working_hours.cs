namespace ProjectMangerAppReviso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviso.working_hours")]
    public partial class working_hours
    {
        public int id { get; set; }

        public int pId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? startDT { get; set; }

        public DateTime? endDT { get; set; }

        public virtual active_projects active_projects { get; set; }
    }
}
