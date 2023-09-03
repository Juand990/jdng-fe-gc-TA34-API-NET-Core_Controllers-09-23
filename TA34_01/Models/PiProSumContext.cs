using Microsoft.EntityFrameworkCore;

namespace TA34_01.Models
{
    public partial class PiProSumContext : DbContext
    {
        public PiProSumContext(DbContextOptions<PiProSumContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Piezas> Piezas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piezas>(entity =>
            {
                entity.ToTable("Piezas");

                entity.HasKey(p => p.Codigo)
                .HasName("PrimaryKey_Codigo");              

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.ToTable("Proveedores");

                entity.HasKey(p => p.Id)
                .HasName("PrimaryKey_Id");                               

                entity.Property(p => p.Id).HasColumnName("Id");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Suministra>(entity =>
            {                
                entity.ToTable("Suministra");

                entity.HasKey(s => s.CodigoPieza)
                .HasName("PrimaryKey_CodigoPieza");

                entity.HasKey(s => s.IdProveedor )
                .HasName("PrimaryKey_IdProveedor");


        entity.Property(s => s.CodigoPieza).HasColumnName("CodigoPieza");

                entity.Property(s => s.IdProveedor).HasColumnName("IdProveedor");

                entity.Property(s => s.Precio)
                .HasColumnName("Precio")
                .HasColumnType("decimal(10,2)");

                entity.HasOne(p => p.Piezas)
                .WithMany(s => s.Suministra)
                .HasForeignKey(p => p.CodigoPieza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Piezas_Suministra");

                entity.HasOne(p => p.Proveedores)
                .WithMany(s => s.Suministra)
                .HasForeignKey(p => p.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedores_Suministra");
            });
        }
    }
}
