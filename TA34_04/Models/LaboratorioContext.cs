using Microsoft.EntityFrameworkCore;

namespace TA34_04.Models
{
    public class LaboratorioContext : DbContext
    {
        public LaboratorioContext(DbContextOptions<LaboratorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Investigadores> Investigadores { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.ToTable("Facultad");

                entity.HasKey(f => f.Codigo).HasName("PrimaryKey_Codigo");

                entity.Property(f => f.Codigo).HasColumnName("Codigo");

                entity.Property(f => f.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Investigadores>(entity =>
            {
                entity.ToTable("Investigadores");

                entity.HasKey(i => i.DNI).HasName("PrimaryKey_DNI");

                entity.Property(i => i.DNI).HasColumnName("DNI");

                entity.Property(i => i.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.HasOne(i => i.Fac)
                .WithMany(f => f.Investigadores)
                .HasForeignKey(i => i.FacCod)
                .HasConstraintName("FK_Facultad");
            });
            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.ToTable("Equipos");

                entity.HasKey(e => e.Numserie).HasName("PrimaryKey_Numserie");

                entity.Property(e => e.Numserie).HasColumnName("Numserie");

                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasOne(f => f.Fac)
                .WithMany(e => e.Equipos)
                .HasForeignKey(i => i.FacCod)
                .HasConstraintName("FK_Facultad");
            });
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");

                entity.HasKey(r => r.DniInv).HasName("PrimaryKey_DniInv");

                entity.HasKey(r => r.NumSerieEqu).HasName("PrimaryKey_NumSerieEqu");

                entity.Property(r => r.DniInv).HasColumnName("DniInv");

                entity.Property(r => r.NumSerieEqu).HasColumnName("NumSerieEqu");

                entity.Property(r => r.Comienzo)
                .HasColumnName("Comienzo")
                .HasColumnType("date");

                entity.Property(r => r.Fin)
                .HasColumnName("Fin")
                .HasColumnType("date");

                entity.HasOne(f => f.Inv)
                .WithMany(r => r.Reserva)
                .HasForeignKey(i => i.DniInv)
                .HasConstraintName("FK_Invest");

                entity.HasOne(e => e.Eq)
                .WithMany(r => r.Reserva)
                .HasForeignKey(r => r.NumSerieEqu)
                .HasConstraintName("FK_Equipos");
            });
        }
    }
}
