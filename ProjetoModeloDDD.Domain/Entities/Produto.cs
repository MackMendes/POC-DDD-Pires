using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        
        // Virtual para que o LeaverLoad do EntityFramework, sobreescrever essa propriedade.
        public virtual Cliente Cliente { get; set; }
    }
}
