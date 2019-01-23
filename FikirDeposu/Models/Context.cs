namespace FikirDeposu.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Ideas> Ideas { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ideas>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Ideas>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Ideas>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Ideas>()
                .Property(e => e._event)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetails>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetails>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetails>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetails>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
