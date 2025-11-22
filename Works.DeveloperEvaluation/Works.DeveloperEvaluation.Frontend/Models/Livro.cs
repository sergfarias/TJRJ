using System.ComponentModel.DataAnnotations;

namespace Works.DeveloperEvaluation.Frontend.Models
{
    public class Livro 
    {
        public int CodL { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; } = string.Empty;
    }
}
