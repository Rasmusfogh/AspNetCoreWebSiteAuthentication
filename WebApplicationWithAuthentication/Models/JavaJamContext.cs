using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationWithAuthentication.Models
{
    public partial class JavaJamContext : DbContext
    {
        public JavaJamContext()
        {
        }

        public JavaJamContext(DbContextOptions<JavaJamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Job { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JavaJam;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Experience).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
