using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Works.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um autor no sistema.
    /// </summary>
    public interface IAutor
    {
        public int CodAu { get; }
        public string Nome { get; }

    }
}


