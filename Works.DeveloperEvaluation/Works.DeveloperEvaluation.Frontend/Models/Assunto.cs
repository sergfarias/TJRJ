using System.ComponentModel.DataAnnotations;

namespace Works.DeveloperEvaluation.Frontend.Models
{
    public class Assunto 
    {
        public int CodAs { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
