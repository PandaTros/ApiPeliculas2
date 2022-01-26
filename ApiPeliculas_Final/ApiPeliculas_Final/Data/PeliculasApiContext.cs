using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiPeliculas_Final.Modelos
{
    public partial class PeliculasApiContext : DbContext
    {
        public PeliculasApiContext()
        {
        }

        public PeliculasApiContext(DbContextOptions<PeliculasApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Peliculas2> Peliculas2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PeliculasApi.mssql.somee.com;Initial Catalog=PeliculasApi;Persist Security Info=False;User ID=joel15_SQLLogin_1;Password=wh42cqjoxs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Peliculas2>(entity =>
            {
                entity.ToTable("Peliculas2");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPublicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePelicula)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
