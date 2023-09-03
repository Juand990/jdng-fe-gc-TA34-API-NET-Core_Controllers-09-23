using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TA34_02.Models
{
    public partial class CieProAsigContext : DbContext
    {
        public CieProAsigContext(DbContextOptions<CieProAsigContext> options)
            : base(options)
        {
        }
        public DbSet<Cientificos> Cientificos { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<AsignadoA> AsignadoA { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientificos>(entity =>
            {
                entity.ToTable("Cientificos");

                entity.HasKey(e => e.DNI)
                .HasName("PK_DNI");

                entity.Property(c => c.DNI).HasColumnName("DNI");

                entity.Property(c => c.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Proyectos>(entity =>
            {
                entity.ToTable("Proyectos");

                entity.HasKey(p => p.Id)
                .HasName("PK_Id");

                entity.Property(p => p.Id).HasColumnName("Id");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(p => p.Horas)
                .HasColumnName("Horas");
            });
            modelBuilder.Entity<AsignadoA>(entity =>
            {
                entity.ToTable("AsignadoA");

                entity.HasKey(a => a.CientificoDni)
                .HasName("PK_CientificoDni");

                entity.Property(a => a.CientificoDni).HasColumnName("CientificoDni");

                entity.HasKey(a => a.ProyectoId)
                .HasName("PK_ProyectoId");

                entity.Property(a => a.ProyectoId).HasColumnName("ProyectoId");

                entity.Property(a => a.id).HasColumnName("id");

                entity.HasOne(a => a.Cient)
                .WithMany(c => c.AsignadoA)
                .HasForeignKey(a => a.CientificoDni)
                .HasConstraintName("FK_Cient");

                entity.HasOne(a => a.Proy)
                .WithMany(p => p.AsignadoA)
                .HasForeignKey(a => a.ProyectoId)
                .HasConstraintName("FK_Proys");
            });
        }
    }
}