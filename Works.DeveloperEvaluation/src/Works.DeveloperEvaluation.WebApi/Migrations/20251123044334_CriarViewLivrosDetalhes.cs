using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Works.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CriarViewLivrosDetalhes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criar a VIEW
            migrationBuilder.Sql(@"
            CREATE VIEW vw_LivrosDetalhes AS
            SELECT 
					L.CodL,
					L.Titulo, 
					L.Editora,
					L.Edicao, 
					L.AnoPublicacao, 
		 
					(SELECT Descricao  FROM [DeveloperEvaluation].[dbo].[Assunto] A 
							JOIN [DeveloperEvaluation].[dbo].[Livro_Assunto] LS on ls.Livro_CodL = L.CodL) as Assunto,
		 
					(SELECT Nome  FROM [DeveloperEvaluation].[dbo].[Autor] A 
							JOIN [DeveloperEvaluation].[dbo].[Livro_Autor] LA on LA.Livro_CodL = L.CodL)as Autor
		 
			FROM [DeveloperEvaluation].[dbo].[Livro] L 
				--JOIN [DeveloperEvaluation].[dbo].[Livro_Assunto] LS on ls.Livro_CodL = l.CodL
				--JOIN [DeveloperEvaluation].[dbo].[Assunto] A ON A.CodAs = LS.Assunto_CodAs
				--JOIN [DeveloperEvaluation].[dbo].[Livro_Autor] LA on LA.Livro_CodL = l.CodL
				--JOIN [DeveloperEvaluation].[dbo].[Autor] Au ON Au.CodAu = LA.Autor_CodAu
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
