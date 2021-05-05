using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class AlquilerVehiculoDbContext : DbContext
    {
        public AlquilerVehiculoDbContext()
        {
        }

        public AlquilerVehiculoDbContext(DbContextOptions<AlquilerVehiculoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D5946642B8FC8BB8");

                entity.HasIndex(e => e.Cedula, "UQ__Clientes__B4ADFE3863570BFC")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.FotoLicencia).IsUnicode(false);

                entity.Property(e => e.FotoPersona).IsUnicode(false);

                entity.Property(e => e.Licencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSangre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__factura__50E7BAF160F08986");

                entity.ToTable("factura");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPagado).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__factura__IdReser__09A971A2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__factura__IdUsuar__0A9D95DB");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservas__0E49C69DEC08EF7F");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Reservas__IdClie__05D8E0BE");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK__Reservas__IdVehi__04E4BC85");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__TipoVehi__DC20741EF91DE2D2");

                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__708612157A4959E6");

                entity.Property(e => e.CapacidadCarga).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Latitud)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumSeguro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioPorDia).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .HasConstraintName("FK__Vehiculos__IdTip__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
