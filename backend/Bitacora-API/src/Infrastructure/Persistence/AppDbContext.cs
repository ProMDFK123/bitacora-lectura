using Microsoft.EntityFrameworkCore;
using Bitacora_API.Domain.Entities;

namespace Bitacora_API.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        /*
        ===============
        = CONSTRUCTOR =
        ===============
        */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /*
        ==========
        = TABLAS =
        ==========
        */
        // Usuarios
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        // Catálogo bibliográfico
        public DbSet<Obra> Obras => Set<Obra>();
        public DbSet<Edicion> Ediciones => Set<Edicion>();
        public DbSet<Autor> Autores => Set<Autor>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Saga> Sagas => Set<Saga>();

        // Biblioteca y lecturas
        public DbSet<Lectura> Lecturas => Set<Lectura>();
        public DbSet<Biblioteca> Bibliotecas => Set<Biblioteca>();
        public DbSet<SesionLectura> SesionesLectura => Set<SesionLectura>();
        public DbSet<EntradaBitacora> EntradasBitacora => Set<EntradaBitacora>();
        public DbSet<Valoracion> Valoraciones => Set<Valoracion>();

        /*
        =================
        = CONFIGURACIÓN =
        =================
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext)
                .Assembly);
        }
    }
}