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

        public virtual DbSet<Active_projects> Active_projects { get; set; }
        public virtual DbSet<Working_hours> Working_hours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Active_projects>()
                .Property(e => e.PName)
                .IsUnicode(false);

            modelBuilder.Entity<Active_projects>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Active_projects>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Active_projects>()
                .HasMany(e => e.Working_hours)
                .WithRequired(e => e.Active_projects)
                .HasForeignKey(e => e.PId)
                .WillCascadeOnDelete(false);
        }
    }
}
