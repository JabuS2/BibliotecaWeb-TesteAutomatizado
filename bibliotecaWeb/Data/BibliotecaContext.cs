using BibliotecaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Data
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<AutorLivro> AutorLivros { get; set; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorLivro>()
                .HasKey(al => new { al.AutorId, al.LivroId });

            modelBuilder.Entity<AutorLivro>()
                .HasOne(al => al.Autor)
                .WithMany(a => a.AutorLivros)
                .HasForeignKey(al => al.AutorId);

            modelBuilder.Entity<AutorLivro>()
                .HasOne(al => al.Livro)
                .WithMany(l => l.AutorLivros)
                .HasForeignKey(al => al.LivroId);
        }
    }
}
