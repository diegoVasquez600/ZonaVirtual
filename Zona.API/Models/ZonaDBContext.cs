using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

#nullable disable

namespace Zona.API.Models
{
    public partial class ZonaDBContext : DbContext
    {
        public ZonaDBContext()
        {
        }

        public ZonaDBContext(DbContextOptions<ZonaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comercio> Comercios { get; set; }
        public virtual DbSet<TransEstado> TransEstados { get; set; }
        public virtual DbSet<TransMedioPago> TransMedioPagos { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configurationBuilder = new ConfigurationBuilder();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
                string con = configurationBuilder.Build().GetSection("ConnectionStrings:ZonaDB").Value;
                optionsBuilder.UseSqlServer(con);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.HasKey(e => e.ComercioCodigo)
                    .HasName("PK__COMERCIO__8A219B90F0F79AE4");

                entity.ToTable("COMERCIO");

                entity.Property(e => e.ComercioCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("comercio_codigo");

                entity.Property(e => e.ComercioDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("comercio_direccion");

                entity.Property(e => e.ComercioNit)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("comercio_nit");

                entity.Property(e => e.ComercioPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("comercio_password");

                entity.Property(e => e.ComercioSalt)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("comercio_salt");

                entity.Property(e => e.ComericoNombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("comerico_nombre");
            });

            modelBuilder.Entity<TransEstado>(entity =>
            {
                entity.HasKey(e => e.EstadoCodigo)
                    .HasName("PK__TRANS_ES__3324761C14DF7FD2");

                entity.ToTable("TRANS_ESTADO");

                entity.Property(e => e.EstadoCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("estado_codigo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");
            });

            modelBuilder.Entity<TransMedioPago>(entity =>
            {
                entity.HasKey(e => e.MedioPagoCodigo)
                    .HasName("PK__TRANS_ME__D9538C4B4520CADC");

                entity.ToTable("TRANS_MEDIO_PAGO");

                entity.Property(e => e.MedioPagoCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("medio_pago_codigo");

                entity.Property(e => e.NombreMedioPago)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre_medio_pago");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK__TRANSACC__9E5DDB3C6C9D9C03");

                entity.ToTable("TRANSACCION");

                entity.Property(e => e.ComercioCodigo).HasColumnName("comercio_codigo");

                entity.Property(e => e.TransCodigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Trans_codigo");

                entity.Property(e => e.TransConcepto)
                    .HasColumnType("text")
                    .HasColumnName("Trans_concepto");

                entity.Property(e => e.TransEstado).HasColumnName("Trans_estado");

                entity.Property(e => e.TransFecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Trans_fecha");

                entity.Property(e => e.TransMedioPago).HasColumnName("Trans_medio_pago");

                entity.Property(e => e.TransTotal).HasColumnName("Trans_total");

                entity.Property(e => e.UsuarioIdentificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_identificacion");

                entity.HasOne(d => d.ComercioCodigoNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.ComercioCodigo)
                    .HasConstraintName("FK__TRANSACCI__comer__6754599E");

                entity.HasOne(d => d.TransEstadoNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.TransEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TRANSACCI__Trans__66603565");

                entity.HasOne(d => d.TransMedioPagoNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.TransMedioPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TRANSACCI__Trans__656C112C");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A659E08DD5");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.UsuarioIdentificacion, "UQ__USUARIO__D95D4B94C0C88302")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.UsuarioEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_email");

                entity.Property(e => e.UsuarioIdentificacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_identificacion");

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario_nombre");

                entity.Property(e => e.UsuarioPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("usuario_password");

                entity.Property(e => e.UsuarioSalt)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("usuario_salt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
