using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD.Database
{
    public partial class CarvajaldbPrueba2Context : DbContext
    {
        public CarvajaldbPrueba2Context()
        {
        }

        public CarvajaldbPrueba2Context(DbContextOptions<CarvajaldbPrueba2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DANIELPC-CASA;Database=CarvajaldbPrueba2;User Id=sa;Password=daniel;");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.CodTipoId);

                entity.Property(e => e.CodTipoId).HasColumnName("codTipoId");

                entity.Property(e => e.AbreviTipoId)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.NombreTipoId)
                    .HasColumnName("nombreTipoId")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK_Usuarios_TipoIdentificacion");
            });

            OnModelCreatingPartial(modelBuilder);
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
