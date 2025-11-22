using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Works.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um livro no sistema.
    /// </summary>
    public interface ILivro
    {
        public int CodL { get; }
        public string Titulo { get; }
        public string Editora { get; }
        public int Edicao { get; }
        public string AnoPublicacao { get; }


    }
}


