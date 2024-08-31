using Microsoft.EntityFrameworkCore;

namespace ShippingSystemPDD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Remitente> Remitentes { get; set; }
        public DbSet<TipoPaquete> TiposDePaquete { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Destinario> Destinarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la herencia de TipoDePaquete
            modelBuilder.Entity<TipoPaquete>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<TipoPaquete>("TipoDePaquete");

            // Configura las relaciones
            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.TipoDePaquete)
                .WithMany()
                .HasForeignKey(p => p.TipoDePaqueteId);

            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.Remitente)
                .WithMany()
                .HasForeignKey(p => p.RemitenteId);

            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.Destinario)
                .WithMany()
                .HasForeignKey(p => p.DestinarioId);

            modelBuilder.Entity<Destinario>()
                .HasOne(d => d.Direccion)
                .WithMany()
                .HasForeignKey(d => d.DireccionId);
        }
    }
}
