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
    public interface ILivroAssunto
    {
        public int Livro_CodL { get; }
        public int Assunto_CodAs { get; }
    }
}


