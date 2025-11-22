using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Works.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um assunto no sistema.
    /// </summary>
    public interface IAssunto
    {
        public int CodAs { get; }

        public string Descricao { get; }    

    }
}


