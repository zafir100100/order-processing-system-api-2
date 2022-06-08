using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace demoPro
{
    public partial class DemoProContext : DbContext
    {
        public DemoProContext()
        {
        }

        public DemoProContext(DbContextOptions<DemoProContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=DemoPro;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Color>(entity =>
            {
                //entity.HasKey(e => new { e.Id, e.Name });
                entity.ToTable("colors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Represent)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("represent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
