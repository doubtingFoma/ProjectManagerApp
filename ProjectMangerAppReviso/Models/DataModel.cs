namespace ProjectMangerAppReviso.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<active_projects> active_projects { get; set; }
        public virtual DbSet<working_hours> working_hours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<active_projects>()
                .Property(e => e.pName)
                .IsUnicode(false);

            modelBuilder.Entity<active_projects>()
                .Property(e => e.authorName)
                .IsUnicode(false);

            modelBuilder.Entity<active_projects>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<active_projects>()
                .HasMany(e => e.working_hours)
                .WithRequired(e => e.active_projects)
                .HasForeignKey(e => e.pId)
                .WillCascadeOnDelete(false);
        }
    }
}
