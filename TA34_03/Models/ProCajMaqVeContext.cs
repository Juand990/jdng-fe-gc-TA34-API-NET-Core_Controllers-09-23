using Microsoft.EntityFrameworkCore;

namespace TA34_03.Models
{
    public class ProCajMaqVeContext : DbContext
    {
        public ProCajMaqVeContext(DbContextOptions<ProCajMaqVeContext> options)
        : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Cajeros> Cajeros { get; set; }
        public DbSet<Maq_Registradoras> Maquinas { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>(entity=>
            {
                entity.ToTable("Productos");

                entity.HasKey(p => p.Codigo)
                    .HasName("PrimaryKey_Codigo");

                entity.Property(p => p.Codigo).HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(p => p.Precio)
                .HasColumnName("Precio")
                .HasColumnType("integer");
            });
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.ToTable("Productos");

                entity.HasKey(c => c.Codigo)
                    .HasName("PrimaryKey_Codigo");

                entity.Property(c => c.Codigo).HasColumnName("Codigo");

                entity.Property(c => c.NomApels)
                .HasColumnName("NomApels")
                .HasMaxLength(255)
                .IsUnicode(false);                
            });
            modelBuilder.Entity<Maq_Registradoras>(entity =>
            {
                entity.ToTable("Maq_Registradoras");

                entity.HasKey(m => m.Codigo)
                    .HasName("PrimaryKey_Codigo");

                entity.Property(m => m.Codigo).HasColumnName("Codigo");

                entity.Property(m => m.Piso)
                .HasColumnName("Piso")
                .HasColumnType("integer");
            });
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");

                entity.HasKey(v => v.CajeroCod)
                    .HasName("PrimaryKey_Cajero");

                entity.Property(v => v.CajeroCod).HasColumnName("Cajero");

                entity.HasKey(v => v.ProductoCod)
                    .HasName("PrimaryKey_Producto");

                entity.Property(v => v.ProductoCod).HasColumnName("Producto");

                entity.HasKey(v => v.MaquinaCod)
                    .HasName("PrimaryKey_Maquina");

                entity.Property(v => v.MaquinaCod).HasColumnName("Maquina");

                entity.HasOne(p => p.Pro)
                .WithMany(v => v.Venta)
                .HasForeignKey(p => p.ProductoCod)
                .HasConstraintName("FK_Prod");

                entity.HasOne(p => p.Caj)
                .WithMany(v => v.Venta)
                .HasForeignKey(p => p.CajeroCod)
                .HasConstraintName("FK_Caj");

                entity.HasOne(p => p.Maq)
                .WithMany(v => v.Venta)
                .HasForeignKey(p => p.MaquinaCod)
                .HasConstraintName("FK_Maq");
            });
        }
    }
}
