using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Works.DeveloperEvaluation.ORM;

public class Context : DbContext
{
    
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Autor> Autor { get; set; }
    public DbSet<Assunto> Assunto { get; set; }

    public DbSet<LivroAssunto> Livro_Assunto { get; set; }
    public DbSet<LivroAutor> Livro_Autor { get; set; }

    public DbSet<LivroDetalhesView> LivroDetalhesView { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Livro>().ToTable("Livro");
        modelBuilder.Entity<Autor>().ToTable("Autor");
        modelBuilder.Entity<Assunto>().ToTable("Assunto");
        modelBuilder.Entity<LivroAssunto>().ToTable("Livro_Assunto");
        modelBuilder.Entity<LivroAutor>().ToTable("Livro_Autor");

        /// Chave primária composta por CategoriaId e SubCategoriaId
        modelBuilder.Entity<LivroAssunto>()
            .HasKey(a => new { a.Livro_CodL, a.Assunto_CodAs });

        // / Configurando a Foreign Key
        modelBuilder.Entity<LivroAssunto>()
        .HasOne(t => t.Livro)
        .WithMany()
        .HasForeignKey(t => t.Livro_CodL);

        modelBuilder.Entity<LivroAssunto>()
       .HasOne(t => t.Assunto)
       .WithMany()
       .HasForeignKey(t => t.Assunto_CodAs);

        modelBuilder.Entity<LivroAutor>()
            .HasKey(a => new { a.Livro_CodL, a.Autor_CodAu });

        modelBuilder.Entity<LivroAutor>()
       .HasOne(t => t.Livro)
       .WithMany()
       .HasForeignKey(t => t.Livro_CodL);

        modelBuilder.Entity<LivroAutor>()
       .HasOne(t => t.Autor)
       .WithMany()
       .HasForeignKey(t => t.Autor_CodAu);

        modelBuilder.Entity<LivroDetalhesView>(entity =>
        {
            entity.HasNoKey(); // VIEW não tem chave primária
            entity.ToView("vw_LivrosDetalhes"); // Nome da VIEW no banco
        });


    }
}
